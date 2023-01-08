using RotmgPCap.Forms.Components;
using RotmgPCap.Packets;
using RotmgPCap.Packets.DataTypes;
using RotmgPCap.Packets.DataTypes.Primitive;
using RotmgPCap.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotmgPCap.Forms
{
    internal partial class PacketAnalyzerForm : Form
    {
        internal Packet packet;

        private readonly RotmgPCapCore rotmgPCap;
        private readonly ManualLogic[] manualLogic;

        private TextBox manualSelection;
        private int manualIndex;

        internal PacketAnalyzerForm(RotmgPCapCore rotmgPCap, Packet packet)
        {
            this.packet = packet;
            this.rotmgPCap = rotmgPCap;

            InitializeComponent();

            manualLogic = new ManualLogic[]
            {
                new ManualLogic(new ASByte(), SByteValueTextBox, ManualSelect),
                new ManualLogic(new AByte(), ByteValueTextBox, ManualSelect),
                new ManualLogic(new AInt16(), Int16ValueTextBox, ManualSelect),
                new ManualLogic(new AUInt16(), UInt16ValueTextBox, ManualSelect),
                new ManualLogic(new AInt32(), Int32ValueTextBox, ManualSelect),
                new ManualLogic(new AUInt32(), UInt32ValueTextBox, ManualSelect),
                new ManualLogic(new AFloat(), FloatValueTextBox, ManualSelect),
                new ManualLogic(new ABoolean(), BooleanValueTextBox, ManualSelect),
                new ManualLogic(new ACompressed(), CompressedValueTextBox, ManualSelect, CompressedLengthTextBox),
                new ManualLogic(new AUtf(), UtfValueTextBox, ManualSelect, UtfLengthTextBox),
            };

            PacketTreeView.HideSelection = false;
            BinaryView.SetOnSelect(OnBinaryViewerSelect);
        }

        private void PacketAnalyzerForm_Load(object sender, EventArgs e)
        {
            BinaryView.SetData(packet.Data);

            PacketTypeValueLabel.Text = packet.FormatName();
            PacketDirectionValueLabel.Text = packet.FormatDirection();
            PacketSizeValueLabel.Text = packet.FormatData();
            PacketTimeValueLabel.Text = packet.FormatTime(true);

            #pragma warning disable 4014
            ReadPacket();
            #pragma warning restore 4014
        }

        private void SelectNode(PacketObjectNode node)
        {
            ObjectValueLabel.Text = "Value: (" + node.Type + "):";
            ObjectValueTextBox.Text = node.Value;

            if (manualSelection != null)
            {
                manualSelection.BackColor = SystemColors.Control;
                manualSelection = null;
            }

            UpdatePointerInfo(node.DataIndex, node.DataIndex, node.DataIndex + node.Length);
            BinaryView.Select(node.Failure ? SelectionType.FAILURE : node.Header ? SelectionType.PACKET_HEADER
                : node.Container ? SelectionType.CONTAINER : SelectionType.TYPE, node.DataIndex, node.Length);
        }

        private async Task ReadPacket()
        {
            await Task.Run(() =>
            {
                rotmgPCap.PacketManager.Read(packet);
                Invoke(new OnFinishParsing(DoOnFinishParsing));
            });
        }

        private void DoOnFinishParsing()
        {
            PacketTreeView.Nodes.Clear();
            UpdatePointerInfo(0, 0, 0);
            BinaryView.Select(SelectionType.NOTHING, 0, 0);

            foreach (TypeInstance type in packet.Proto.Types)
                PacketTreeView.Nodes.Add(new PacketObjectNode(type));
        }

        private void DoOnFinishReloading()
        {
            MessageBox.Show("Parsed " + rotmgPCap.PacketManager.PacketProtoDict.Count + " packet structures.",
                    "Proto file reloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private (SelectionType type, int startIndex, int length) OnBinaryViewerSelect(int index)
        {
            PacketObjectNode node = RecursiveSearchTreeNode(PacketTreeView.Nodes, index);
            
            if(node != null && node.Length > 0)
            {
                PacketTreeView.SelectedNode = node;
                SelectionType type = node.Failure ? SelectionType.FAILURE : node.Header ? SelectionType.PACKET_HEADER
                : node.Container ? SelectionType.CONTAINER : SelectionType.TYPE;
                UpdatePointerInfo(index, node.DataIndex, node.DataIndex + node.Length);
                return (type, node.DataIndex, node.Length);
            }

            if (manualSelection != null)
            {
                manualSelection.BackColor = SystemColors.Control;
                manualSelection = null;
            }

            UpdatePointerInfo(index, index, index + 1);
            return (SelectionType.UNKNOWN, index, 1);
        }

        private PacketObjectNode RecursiveSearchTreeNode(TreeNodeCollection collection, int targetIndex)
        {
            foreach(TreeNode rawNode in collection)
            {
                PacketObjectNode node = (PacketObjectNode)rawNode;

                if (node.DataIndex <= targetIndex && node.DataIndex + node.Length > targetIndex)
                    if (node.Nodes.Count != 0)
                        return RecursiveSearchTreeNode(node.Nodes, targetIndex);
                    else
                        return node;
            }
            return null;
        }

        private void UpdatePointerInfo(int pointerCore, int selectionStart, int selectionStop)
        {
            string core = BinaryView.HexMode ? pointerCore.ToString("X5") : pointerCore.ToString().PadLeft(5, '0');
            string start = BinaryView.HexMode ? selectionStart.ToString("X5") : selectionStart.ToString().PadLeft(5, '0');
            string stop = BinaryView.HexMode ? selectionStop.ToString("X5") : selectionStop.ToString().PadLeft(5, '0');
            string length = (selectionStop - selectionStart).ToString().PadLeft(5, '0');

            SelectionDetails.Text = "Pointer: " + core + " | Sel. start: " + start + " | Sel. stop: " + stop + " | Length: " + length;

            if(pointerCore != manualIndex)
            {
                manualIndex = pointerCore;
                UpdateManual();
            }
        }

        private void UpdateManual()
        {
            if (manualIndex >= packet.Data.Length)
                return;

            byte[] streamData = new byte[Math.Max(0, packet.Data.Length - manualIndex)];

            if(streamData.Length != 0)
                Array.Copy(packet.Data, manualIndex, streamData, 0, streamData.Length);

            foreach (ManualLogic m in manualLogic)
                m.Read(streamData);
        }

        private void ManualSelect(TextBox textBox, int length)
        {
            if (manualSelection != null)
                manualSelection.BackColor = SystemColors.Control;

            UpdatePointerInfo(manualIndex, manualIndex, manualIndex + length);
            BinaryView.Select(SelectionType.MANUAL, manualIndex, length);

            manualSelection = textBox;
        }

        private void PacketTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is PacketObjectNode node)
                SelectNode(node);
        }

        private void PacketAnalyzerForm_SizeChanged(object sender, EventArgs e) => BinaryView.OnResize();

        private void HexModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BinaryView.SetHexMode(HexModeCheckBox.Checked);
            UpdatePointerInfo(BinaryView.SelectionIndex, BinaryView.SelectionStart, BinaryView.SelectionStop);
        }

        private class ManualLogic
        {
            private readonly TypeInstance instance;
            private readonly OnManualSelect manualSelect;
            private readonly TextBox valueTextBox, lengthTextBox;

            private int lastLength;

            internal ManualLogic(DataType type, TextBox valueTextBox, OnManualSelect manualSelect, TextBox lengthTextBox = null)
            {
                instance = new TypeInstance(type, null);
                this.valueTextBox = valueTextBox;
                this.manualSelect = manualSelect;
                this.lengthTextBox = lengthTextBox;

                lastLength = 0;

                valueTextBox.Click += new EventHandler(HandleClick);
            }

            internal void Read(byte[] bytes)
            {
                if(bytes.Length < instance.Type.MinLength)
                {
                    valueTextBox.BackColor = SystemColors.ControlDarkDark;
                    valueTextBox.Text = "";
                    lastLength = 0;
                    return;
                }

                MemoryStream stream = new MemoryStream(bytes);
                PacketReader reader = new PacketReader(null, stream);

                if(reader.Read(instance))
                {
                    valueTextBox.BackColor = SystemColors.Control;
                    valueTextBox.Text = instance.Result.StringValue;
                    lastLength = instance.Result.BytesRead;
                }
                else
                {
                    valueTextBox.BackColor = SystemColors.ControlDarkDark;
                    valueTextBox.Text = "";
                    lastLength = 0;
                }

                if (lengthTextBox != null)
                    lengthTextBox.Text = instance.Result.Error ? "" : instance.Result.BytesRead.ToString();

                stream.Close();
                instance.Clear();
            }

            private void HandleClick(object sender, EventArgs e)
            {
                if (lastLength != 0)
                    manualSelect.Invoke(valueTextBox, lastLength);
            }
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (manualSelection == null)
                return;

            if (e.KeyChar == (char)Keys.Left)
            {
                e.Handled = true;
                manualIndex = Math.Max(0, --manualIndex);
                UpdateManual();
            }
            if (e.KeyChar == (char)Keys.Left)
            {
                e.Handled = true;
                manualIndex = Math.Min(packet.Data.Length - 1, ++manualIndex);
                UpdateManual();
            }
        }

        private void OpenProtoFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + Resources.ProtoFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to open proto file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadProtoFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                string result = rotmgPCap.HotReloadProto();

                if(result != null)
                    throw new Exception(result);

                packet.ApplyProto(rotmgPCap.PacketManager);

                ReadPacket().ContinueWith((r) => Invoke(new OnFinishReloading(DoOnFinishReloading)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to reload proto file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    internal delegate void OnManualSelect(TextBox textBox, int length);
    internal delegate void OnFinishParsing();
    internal delegate void OnFinishReloading();
}
