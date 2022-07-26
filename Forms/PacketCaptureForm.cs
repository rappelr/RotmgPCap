using RotmgPCap.Capture;
using RotmgPCap.Packets;
using RotmgPCap.Util;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotmgPCap.Forms
{
    internal partial class PacketCaptureForm : Form
    {
        private static readonly Color START_COLOR = Color.FromArgb(125, 233, 120);
        private static readonly Color STOP_COLOR = Color.FromArgb(249, 121, 121);

        internal readonly Dictionary<ushort, Packet> Packets;

        internal readonly RotmgPCapCore RotmgPCap;

        private ushort packetIdCounter;
        private int packetsCaught;
        private bool active, stopping, ignorePacketTypeSelection;

        internal PacketCaptureForm(RotmgPCapCore rotmgPCap)
        {
            this.RotmgPCap = rotmgPCap;
            Packets = new Dictionary<ushort, Packet>();
            packetIdCounter = 0;

            InitializeComponent();

            MaximizeBox = false;
        }

        // modes: 0 = Combined, 1 = Combined Sorted, 2 = Individual
        internal List<(string name, byte[] data)> Export(int mode)
        {
            var result = new List<(string name, byte[] data)>();

            string timeString = DateTime.Now.ToString("HH.mm.ss");

            if (mode == 0)
            {
                var packets = new List<byte[]>();
                long totalLength = 0;

                foreach (Packet packet in Packets.Values)
                {
                    byte[] export = packet.Data;
                    totalLength += export.Length;
                    packets.Add(export);
                }

                byte[] combined = new byte[totalLength];
                int index = 0;
                foreach(byte[] packet in packets)
                {
                    Array.Copy(packet, 0, combined, index, packet.Length);
                    index += packet.Length;
                }

                result.Add(("Session " + timeString + ".bin", combined));
            }
            else if(mode == 1)
            {
                var packets = new Dictionary<PacketStructure, List<byte[]>>();

                foreach (Packet packet in Packets.Values)
                {
                    byte[] export = packet.Data;

                    if (packets.ContainsKey(packet.Structure))
                        packets[packet.Structure].Add(export);
                    else
                        packets.Add(packet.Structure, new List<byte[]>
                        {
                            export
                        });
                }

                foreach(KeyValuePair<PacketStructure, List<byte[]>> pair in packets)
                {
                    int length = 0;

                    foreach (byte[] packet in pair.Value)
                        length += packet.Length;

                    byte[] combined = new byte[length];
                    int index = 0;
                    foreach (byte[] packet in pair.Value)
                    {
                        Array.Copy(packet, 0, combined, index, packet.Length);
                        index += packet.Length;
                    }

                    result.Add(("Packet group " + pair.Key.Name + " " + timeString + ".bin", combined));
                }
            }
            else if(mode == 2)
            {
                foreach (KeyValuePair<ushort, Packet> pair in Packets)
                    result.Add(("Packet " + pair.Value.Structure.Name + " (" + pair.Key + ") " + timeString + ".bin", pair.Value.Data));
            }

            return result;
        }

        private void PacketCaptureForm_Load(object sender, EventArgs e)
        {
            foreach (string device in RotmgPCap.CaptureManager.NetworkDevices.Keys)
                NetworkDeviceComboBox.Items.Add(device);

            PacketTypeComboBox.Items.Add("Unknown type");
            foreach (PacketStructure structure in RotmgPCap.PacketManager.Structures.Values)
                PacketTypeComboBox.Items.Add(structure.Name);

            NetworkDeviceComboBox.SelectedIndex = 0;
            SocketTimeoutComboBox.SelectedIndex = 0;
            PacketTypeComboBox.SelectedIndex = 0;
            DirectionComboBox.SelectedIndex = 0;

            StartStopButton.BackColor = START_COLOR;
        }

        private CaptureOptions ParseOptions()
        {
            if (!RotmgPCap.CaptureManager.NetworkDevices.TryGetValue((string)NetworkDeviceComboBox.SelectedItem, out ICaptureDevice device))
                return null;

            if (!ushort.TryParse(PortTextBox.Text, out ushort port))
                return null;

            int? socketTimeout = null;
            if (SocketTimeoutComboBox.SelectedIndex != 0)
            {
                if (!int.TryParse((string)SocketTimeoutComboBox.SelectedItem, out int intSocketTimeout))
                    return null;

                socketTimeout = intSocketTimeout;
            }

            byte? packetId = null;
            if(SpecificPacketCheckBox.Checked && PacketIdTextBox.Text.Length > 0)
            {
                if (!byte.TryParse(PacketIdTextBox.Text, out byte bytePacketId))
                    return null;

                packetId = bytePacketId;
            }

            bool? direction = null;
            if (DirectionComboBox.SelectedIndex > 1)
                direction = false;
            else if (DirectionComboBox.SelectedIndex > 0)
                direction = true;

            return new CaptureOptions()
            {
                CaptureDevice = device,
                Port = port,
                PacketId = packetId,
                SocketTimeout = socketTimeout,
                FilterUntilSync = HaltUntilSyncCheckBox.Checked,
                FilterACK = IngoreAckCheckBox.Checked,
                FilterPacket = SpecificPacketCheckBox.Checked,
                Direction = direction
            };
        }

        private void StartToggle()
        {
            NetworkDeviceComboBox.Enabled = false;
            PortTextBox.Enabled = false;
            SocketTimeoutComboBox.Enabled = false;

            HaltUntilSyncCheckBox.Enabled = false;
            IngoreAckCheckBox.Enabled = false;
            SpecificPacketCheckBox.Enabled = false;
            PacketTypeComboBox.Enabled = false;
            PacketIdTextBox.Enabled = false;
            DirectionComboBox.Enabled = false;

            AnalyzeButton.Enabled = false;
            RemoveButton.Enabled = false;
            ClearButton.Enabled = false;
            SessionButton.Enabled = false;

            PacketListBox.Enabled = false;
            PacketListBox.SelectedItem = null;

            packetsCaught = 0;
            PacketsCaughtValueLabel.Text = "0";

            StartStopButton.Text = "Stop";
            StartStopButton.BackColor = STOP_COLOR;

            active = true;
        }

        private void StopToggle()
        {
            NetworkDeviceComboBox.Enabled = true;
            PortTextBox.Enabled = true;
            SocketTimeoutComboBox.Enabled = true;

            HaltUntilSyncCheckBox.Enabled = true;
            IngoreAckCheckBox.Enabled = true;
            SpecificPacketCheckBox.Enabled = true;
            PacketTypeComboBox.Enabled = SpecificPacketCheckBox.Checked;
            PacketIdTextBox.Enabled = SpecificPacketCheckBox.Checked;
            DirectionComboBox.Enabled = true;
            SessionButton.Enabled = true;

            PacketListBox.Enabled = true;

            if (PacketListBox.Items.Count > 0)
                ClearButton.Enabled = true;

            IncomingSyncValueLabel.Text = "false";
            IncomingSyncValueLabel.ForeColor = Color.Red;
            OutgoingSyncValueLabel.Text = "false";
            OutgoingSyncValueLabel.ForeColor = Color.Red;
            StartStopButton.Text = "Start";
            StartStopButton.BackColor = START_COLOR;

            active = false;
        }

        internal void SetSync(bool incoming) => Invoke(new OnSync(OnSync), incoming);

        private void OnSync(bool incoming)
        {
            if(incoming)
            {
                IncomingSyncValueLabel.Text = "true";
                IncomingSyncValueLabel.ForeColor = Color.Green;
            }
            else
            {
                OutgoingSyncValueLabel.Text = "true";
                OutgoingSyncValueLabel.ForeColor = Color.Green;
            }
        }

        internal void AddPacketsCaught(int count) => Invoke(new OnUpdateCaught(OnCaught), count);

        private void OnCaught(int addative)
        {
            packetsCaught += addative;
            PacketsCaughtValueLabel.Text = packetsCaught.ToString();
        }

        internal void AddPacket(Packet packet) => Invoke(new OnPacket(OnPacket), packet);
        private void OnPacket(Packet packet)
        {
            if (IngoreAckCheckBox.Checked && packet.Structure.Name.EndsWith("Ack"))
                return;

            ushort id = packetIdCounter == ushort.MaxValue ? (packetIdCounter = default) : ++packetIdCounter;

            string name = packet.FormatName();
            name = name.Length > 14 ? name.Substring(0, 14) : name.PadRight(14, ' ');

            PacketListBox.Items.Add(id.ToString().PadLeft(5, '0') + " | " + packet.FormatTime().PadRight(8, ' ') + " | "
                + packet.FormatDirection(false) + " | " + name + " | "  + packet.FormatData());

            Packets.Add(id, packet);
        }

        internal void AddressDetected(string address) => Invoke(new OnAddressDetected(OnAddressDetected), address);
        private void OnAddressDetected(string address) => DetectedAddressTextBox.Text = address;

        internal void FinishCapturing(bool timeout) => Invoke(new OnFinishCapturing(OnFinishCapturing), timeout);
        private void OnFinishCapturing(bool timeout)
        {
            if (timeout)
                MessageBox.Show("Socket timed out", "RotmgPCap", MessageBoxButtons.OK, MessageBoxIcon.Information);

            StopToggle();
            stopping = false;
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!active)
            {
                CaptureOptions options = ParseOptions();

                if (options != null)
                    if (RotmgPCap.CaptureManager.Start(options))
                    {
                        StartToggle();
                        return;
                    }
                
                MessageBox.Show("Failed to start capturing", "RotmgPCap", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!stopping)
            {
                stopping = true;
                StartStopButton.Text = "Stopping...";
                Task.Run(() => RotmgPCap.CaptureManager.Stop());
            }
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            if (PacketListBox.SelectedItem != null)
                if (ushort.TryParse(((string)PacketListBox.SelectedItem).Substring(0, 5), out ushort val))
                    if (Packets.TryGetValue(val, out Packet packet))
                        RotmgPCap.OpenPacketAnalyzer(packet);
                    else
                        MessageBox.Show("Packet not found", "RotmgPCap", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (PacketListBox.SelectedItem != null)
            {
                if (ushort.TryParse(((string)PacketListBox.SelectedItem).Substring(0, 5), out ushort val))
                    Packets.Remove(val);

                PacketListBox.Items.Remove(PacketListBox.SelectedItem);
            }

            AnalyzeButton.Enabled = RemoveButton.Enabled = false;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            PacketListBox.Items.Clear();
            Packets.Clear();

            AnalyzeButton.Enabled = RemoveButton.Enabled = ClearButton.Enabled = false;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (active)
                return;

            SessionForm sessionForm = new SessionForm(this);
            Enabled = false;
            sessionForm.ShowDialog(this);
            Enabled = true;
            sessionForm.Dispose();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A Realm of the Mad God packet capturing tool.\n\nVersion: " + RotmgPCapCore.VERSION + "\nBy Rappelr#2228", "RotmgPCap", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void PacketListBox_SelectedIndexChanged(object sender, EventArgs e) => RemoveButton.Enabled = AnalyzeButton.Enabled = true;

        private void PacketListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (PacketListBox.SelectedItem != null)
                if (ushort.TryParse(((string)PacketListBox.SelectedItem).Substring(0, 5), out ushort val))
                    if (Packets.TryGetValue(val, out Packet packet))
                        RotmgPCap.OpenPacketAnalyzer(packet);
                    else
                        MessageBox.Show("Packet not found", "RotmgPCap", MessageBoxButtons.OK, MessageBoxIcon.Error);

            PacketListBox_SelectedIndexChanged(sender, null);
        }

        private void PacketListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PacketListBox_MouseDoubleClick(sender, null);
            }
        }

        private void SpecificPacketCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PacketTypeComboBox.Enabled = SpecificPacketCheckBox.Checked;
            PacketIdTextBox.Enabled = SpecificPacketCheckBox.Checked;
        }

        private void PacketTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignorePacketTypeSelection)
                return;

            ignorePacketTypeSelection = true;

            if ((string)PacketTypeComboBox.SelectedItem == "Unknown type")
                PacketIdTextBox.Text = "";
            else
                PacketIdTextBox.Text = ((int)(RotmgPCap.PacketManager.ByName((string)PacketTypeComboBox.SelectedItem)?.Id??0)).ToString();

            ignorePacketTypeSelection = false;
        }

        private void PacketIdTextBox_KeyUp(object sender, KeyEventArgs e) => PacketIdTextBox_TextChanged(sender, e);

        private void PacketIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ignorePacketTypeSelection)
                return;

            ignorePacketTypeSelection = true;

            if (PacketIdTextBox.Text.Length != 0)
                if(byte.TryParse(PacketIdTextBox.Text, out byte id))
                    if (RotmgPCap.PacketManager.Structures.TryGetValue(id, out PacketStructure structure))
                        PacketTypeComboBox.SelectedItem = structure.Name;
                    else
                        PacketTypeComboBox.SelectedIndex = 0;
                else
                    PacketIdTextBox.Text = "255";

            ignorePacketTypeSelection = false;
        }

        private void PacketCaptureForm_FormClosing(object sender, FormClosingEventArgs e) => RotmgPCap.Close();
    }

    internal delegate void OnSync(bool incoming);
    internal delegate void OnUpdateCaught(int addative);
    internal delegate void OnPacket(Packet packet);
    internal delegate void OnAddressDetected(string address);
    internal delegate void OnFinishCapturing(bool timeout);
}
