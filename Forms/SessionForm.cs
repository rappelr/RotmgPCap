using RotmgPCap.Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Windows.Forms;

namespace RotmgPCap.Forms
{
    internal partial class SessionForm : Form
    {
        private static string exportPath;

        private readonly PacketCaptureForm captureForm;

        internal SessionForm(PacketCaptureForm captureForm)
        {
            this.captureForm = captureForm;

            InitializeComponent();

            MaximizeBox = false;
        }

        private void SessionForm_Load(object sender, EventArgs e)
        {
            ExportModeComboBox.SelectedIndex = 0;
            exportPath = exportPath ?? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Sessions";

            if (!Directory.Exists(exportPath))
                Directory.CreateDirectory(exportPath);

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            int count = captureForm.Packets.Count;
            List<byte> foundTypes = new List<byte>();
            int captured = 0;
            int imported = 0;
            int types = 0;

            foreach(Packet packet in captureForm.Packets.Values)
            {
                if (packet.Captured)
                    captured++;
                else
                    imported++;

                if(!foundTypes.Contains(packet.Structure.Id))
                {
                    foundTypes.Add(packet.Structure.Id);
                    types++;
                }
            }

            PacketCoultValueLabel.Text = count.ToString();
            CapturedValueLabel.Text = captured.ToString();
            ImportedValueLabel.Text = imported.ToString();
            TypesValueLabel.Text = types.ToString();
            PathTextBox.Text = exportPath;

            ExportButton.Enabled = count > 0;
        }

        private void ImportFiles(string[] files)
        {
            int failures = 0;
            int packets = 0;
            string error = null;

            foreach(string file in files)
            {
                try
                {
                    foreach (Packet packet in Packet.Parse(captureForm.RotmgPCap.PacketManager, File.ReadAllBytes(file)))
                    {
                        captureForm.AddPacket(packet);
                        packets++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    error = e.Message;
                    failures++;
                }
            }

            if (failures == 0)
                MessageBox.Show("Successfully imported " + packets + " packets.",
                    "Import complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (failures < files.Length)
                MessageBox.Show("Failed to import " + failures + "/" + files.Length + " files:\n" + error + "\nImported " + packets + " packets.",
                    "Import complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Failed to import files:\n" + error, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            UpdateInfo();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(exportPath))
            {
                MessageBox.Show("Export path does not exist.", "Session export failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var export = captureForm.Export(ExportModeComboBox.SelectedIndex);

                int count = 0;

                foreach ((string name, byte[] data) in export)
                {
                    File.WriteAllBytes((exportPath.EndsWith("\\") ? exportPath : (exportPath + "\\")) + name, data);
                    count++;
                }

                MessageBox.Show("Created " + count + " files.", "Session export success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Session export failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (ImportFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = new string[0];

                try
                {
                    files = ImportFileDialog.FileNames;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show(ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (files.Length > 0)
                    ImportFiles(files);
            }
        }

        private void PathPickButton_Click(object sender, EventArgs e)
        {
            if (PathDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    exportPath = PathDialog.SelectedPath;
                    UpdateInfo();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show(ex.Message, "Export path selection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
