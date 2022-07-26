
using RotmgPCap.Forms.Components;

namespace RotmgPCap.Forms
{
    partial class PacketCaptureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketCaptureForm));
            this.HaltUntilSyncCheckBox = new System.Windows.Forms.CheckBox();
            this.ConnectionGroupBox = new System.Windows.Forms.GroupBox();
            this.DetectedAddressTextBox = new System.Windows.Forms.TextBox();
            this.DetectedAddressLabel = new System.Windows.Forms.Label();
            this.SocketTimeoutComboBox = new System.Windows.Forms.ComboBox();
            this.SocketTimeoutLabel = new System.Windows.Forms.Label();
            this.PortTextBox = new RotmgPCap.Forms.Components.NumericTextbox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.NetworkDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.NetworkDeviceLabel = new System.Windows.Forms.Label();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.DirectionComboBox = new System.Windows.Forms.ComboBox();
            this.DirectionLabel = new System.Windows.Forms.Label();
            this.PacketIdTextBox = new RotmgPCap.Forms.Components.NumericTextbox();
            this.PacketTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SpecificPacketCheckBox = new System.Windows.Forms.CheckBox();
            this.IngoreAckCheckBox = new System.Windows.Forms.CheckBox();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.ControlGroupBox = new System.Windows.Forms.GroupBox();
            this.AboutButton = new System.Windows.Forms.Button();
            this.SessionButton = new System.Windows.Forms.Button();
            this.PacketListBox = new System.Windows.Forms.ListBox();
            this.IncomingSyncLabel = new System.Windows.Forms.Label();
            this.IncomingSyncValueLabel = new System.Windows.Forms.Label();
            this.OutgoingSyncLabel = new System.Windows.Forms.Label();
            this.OutgoingSyncValueLabel = new System.Windows.Forms.Label();
            this.PacketsCauchtLabel = new System.Windows.Forms.Label();
            this.PacketsCaughtValueLabel = new System.Windows.Forms.Label();
            this.ConnectionGroupBox.SuspendLayout();
            this.FilterGroupBox.SuspendLayout();
            this.ControlGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // HaltUntilSyncCheckBox
            // 
            this.HaltUntilSyncCheckBox.AutoSize = true;
            this.HaltUntilSyncCheckBox.Checked = true;
            this.HaltUntilSyncCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HaltUntilSyncCheckBox.Location = new System.Drawing.Point(10, 19);
            this.HaltUntilSyncCheckBox.Name = "HaltUntilSyncCheckBox";
            this.HaltUntilSyncCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HaltUntilSyncCheckBox.Size = new System.Drawing.Size(80, 17);
            this.HaltUntilSyncCheckBox.TabIndex = 7;
            this.HaltUntilSyncCheckBox.Text = "Await sync.";
            this.HaltUntilSyncCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConnectionGroupBox
            // 
            this.ConnectionGroupBox.Controls.Add(this.DetectedAddressTextBox);
            this.ConnectionGroupBox.Controls.Add(this.DetectedAddressLabel);
            this.ConnectionGroupBox.Controls.Add(this.SocketTimeoutComboBox);
            this.ConnectionGroupBox.Controls.Add(this.SocketTimeoutLabel);
            this.ConnectionGroupBox.Controls.Add(this.PortTextBox);
            this.ConnectionGroupBox.Controls.Add(this.PortLabel);
            this.ConnectionGroupBox.Controls.Add(this.NetworkDeviceComboBox);
            this.ConnectionGroupBox.Controls.Add(this.NetworkDeviceLabel);
            this.ConnectionGroupBox.Location = new System.Drawing.Point(13, 13);
            this.ConnectionGroupBox.Name = "ConnectionGroupBox";
            this.ConnectionGroupBox.Size = new System.Drawing.Size(132, 188);
            this.ConnectionGroupBox.TabIndex = 0;
            this.ConnectionGroupBox.TabStop = false;
            this.ConnectionGroupBox.Text = "Connection";
            // 
            // DetectedAddressTextBox
            // 
            this.DetectedAddressTextBox.Location = new System.Drawing.Point(10, 157);
            this.DetectedAddressTextBox.Name = "DetectedAddressTextBox";
            this.DetectedAddressTextBox.ReadOnly = true;
            this.DetectedAddressTextBox.Size = new System.Drawing.Size(112, 20);
            this.DetectedAddressTextBox.TabIndex = 7;
            // 
            // DetectedAddressLabel
            // 
            this.DetectedAddressLabel.AutoSize = true;
            this.DetectedAddressLabel.Location = new System.Drawing.Point(8, 141);
            this.DetectedAddressLabel.Name = "DetectedAddressLabel";
            this.DetectedAddressLabel.Size = new System.Drawing.Size(91, 13);
            this.DetectedAddressLabel.TabIndex = 6;
            this.DetectedAddressLabel.Text = "Detected address";
            // 
            // SocketTimeoutComboBox
            // 
            this.SocketTimeoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SocketTimeoutComboBox.FormattingEnabled = true;
            this.SocketTimeoutComboBox.Items.AddRange(new object[] {
            "None",
            "1",
            "2",
            "5",
            "10",
            "30"});
            this.SocketTimeoutComboBox.Location = new System.Drawing.Point(10, 117);
            this.SocketTimeoutComboBox.Name = "SocketTimeoutComboBox";
            this.SocketTimeoutComboBox.Size = new System.Drawing.Size(112, 21);
            this.SocketTimeoutComboBox.TabIndex = 5;
            // 
            // SocketTimeoutLabel
            // 
            this.SocketTimeoutLabel.AutoSize = true;
            this.SocketTimeoutLabel.Location = new System.Drawing.Point(8, 101);
            this.SocketTimeoutLabel.Name = "SocketTimeoutLabel";
            this.SocketTimeoutLabel.Size = new System.Drawing.Size(104, 13);
            this.SocketTimeoutLabel.TabIndex = 4;
            this.SocketTimeoutLabel.Text = "Socket timeout (sec)";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(10, 78);
            this.PortTextBox.MaxLength = 5;
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(112, 20);
            this.PortTextBox.TabIndex = 3;
            this.PortTextBox.Text = "2050";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(8, 61);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 2;
            this.PortLabel.Text = "Port";
            // 
            // NetworkDeviceComboBox
            // 
            this.NetworkDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NetworkDeviceComboBox.FormattingEnabled = true;
            this.NetworkDeviceComboBox.Location = new System.Drawing.Point(10, 37);
            this.NetworkDeviceComboBox.Name = "NetworkDeviceComboBox";
            this.NetworkDeviceComboBox.Size = new System.Drawing.Size(112, 21);
            this.NetworkDeviceComboBox.TabIndex = 1;
            // 
            // NetworkDeviceLabel
            // 
            this.NetworkDeviceLabel.AutoSize = true;
            this.NetworkDeviceLabel.Location = new System.Drawing.Point(8, 20);
            this.NetworkDeviceLabel.Name = "NetworkDeviceLabel";
            this.NetworkDeviceLabel.Size = new System.Drawing.Size(82, 13);
            this.NetworkDeviceLabel.TabIndex = 0;
            this.NetworkDeviceLabel.Text = "Network device";
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.DirectionComboBox);
            this.FilterGroupBox.Controls.Add(this.DirectionLabel);
            this.FilterGroupBox.Controls.Add(this.PacketIdTextBox);
            this.FilterGroupBox.Controls.Add(this.PacketTypeComboBox);
            this.FilterGroupBox.Controls.Add(this.SpecificPacketCheckBox);
            this.FilterGroupBox.Controls.Add(this.HaltUntilSyncCheckBox);
            this.FilterGroupBox.Controls.Add(this.IngoreAckCheckBox);
            this.FilterGroupBox.Location = new System.Drawing.Point(13, 207);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(132, 188);
            this.FilterGroupBox.TabIndex = 1;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filter";
            // 
            // DirectionComboBox
            // 
            this.DirectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DirectionComboBox.FormattingEnabled = true;
            this.DirectionComboBox.Items.AddRange(new object[] {
            "Both",
            "Incoming",
            "Outgoing"});
            this.DirectionComboBox.Location = new System.Drawing.Point(10, 154);
            this.DirectionComboBox.Name = "DirectionComboBox";
            this.DirectionComboBox.Size = new System.Drawing.Size(112, 21);
            this.DirectionComboBox.TabIndex = 12;
            // 
            // DirectionLabel
            // 
            this.DirectionLabel.AutoSize = true;
            this.DirectionLabel.Location = new System.Drawing.Point(8, 137);
            this.DirectionLabel.Name = "DirectionLabel";
            this.DirectionLabel.Size = new System.Drawing.Size(52, 13);
            this.DirectionLabel.TabIndex = 11;
            this.DirectionLabel.Text = "Direction:";
            // 
            // PacketIdTextBox
            // 
            this.PacketIdTextBox.Enabled = false;
            this.PacketIdTextBox.Location = new System.Drawing.Point(10, 114);
            this.PacketIdTextBox.MaxLength = 3;
            this.PacketIdTextBox.Name = "PacketIdTextBox";
            this.PacketIdTextBox.Size = new System.Drawing.Size(112, 20);
            this.PacketIdTextBox.TabIndex = 10;
            this.PacketIdTextBox.Text = "0";
            this.PacketIdTextBox.TextChanged += new System.EventHandler(this.PacketIdTextBox_TextChanged);
            this.PacketIdTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PacketIdTextBox_KeyUp);
            // 
            // PacketTypeComboBox
            // 
            this.PacketTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PacketTypeComboBox.Enabled = false;
            this.PacketTypeComboBox.FormattingEnabled = true;
            this.PacketTypeComboBox.Location = new System.Drawing.Point(10, 87);
            this.PacketTypeComboBox.Name = "PacketTypeComboBox";
            this.PacketTypeComboBox.Size = new System.Drawing.Size(112, 21);
            this.PacketTypeComboBox.TabIndex = 9;
            this.PacketTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.PacketTypeComboBox_SelectedIndexChanged);
            // 
            // SpecificPacketCheckBox
            // 
            this.SpecificPacketCheckBox.AutoSize = true;
            this.SpecificPacketCheckBox.Location = new System.Drawing.Point(10, 65);
            this.SpecificPacketCheckBox.Name = "SpecificPacketCheckBox";
            this.SpecificPacketCheckBox.Size = new System.Drawing.Size(103, 17);
            this.SpecificPacketCheckBox.TabIndex = 8;
            this.SpecificPacketCheckBox.Text = "Specific packet:";
            this.SpecificPacketCheckBox.UseVisualStyleBackColor = true;
            this.SpecificPacketCheckBox.CheckedChanged += new System.EventHandler(this.SpecificPacketCheckBox_CheckedChanged);
            // 
            // IngoreAckCheckBox
            // 
            this.IngoreAckCheckBox.AutoSize = true;
            this.IngoreAckCheckBox.Checked = true;
            this.IngoreAckCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IngoreAckCheckBox.Location = new System.Drawing.Point(10, 42);
            this.IngoreAckCheckBox.Name = "IngoreAckCheckBox";
            this.IngoreAckCheckBox.Size = new System.Drawing.Size(72, 17);
            this.IngoreAckCheckBox.TabIndex = 0;
            this.IngoreAckCheckBox.Text = "Filter ACK";
            this.IngoreAckCheckBox.UseVisualStyleBackColor = true;
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Enabled = false;
            this.AnalyzeButton.Location = new System.Drawing.Point(10, 48);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(112, 23);
            this.AnalyzeButton.TabIndex = 6;
            this.AnalyzeButton.Text = "Analyze";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(10, 106);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(112, 23);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(10, 77);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(112, 23);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // StartStopButton
            // 
            this.StartStopButton.BackColor = System.Drawing.Color.Transparent;
            this.StartStopButton.Location = new System.Drawing.Point(10, 19);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(112, 23);
            this.StartStopButton.TabIndex = 4;
            this.StartStopButton.Text = "Start";
            this.StartStopButton.UseVisualStyleBackColor = false;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // ControlGroupBox
            // 
            this.ControlGroupBox.Controls.Add(this.AboutButton);
            this.ControlGroupBox.Controls.Add(this.StartStopButton);
            this.ControlGroupBox.Controls.Add(this.AnalyzeButton);
            this.ControlGroupBox.Controls.Add(this.RemoveButton);
            this.ControlGroupBox.Controls.Add(this.ClearButton);
            this.ControlGroupBox.Controls.Add(this.SessionButton);
            this.ControlGroupBox.Location = new System.Drawing.Point(13, 401);
            this.ControlGroupBox.Name = "ControlGroupBox";
            this.ControlGroupBox.Size = new System.Drawing.Size(132, 198);
            this.ControlGroupBox.TabIndex = 2;
            this.ControlGroupBox.TabStop = false;
            this.ControlGroupBox.Text = "Control";
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(10, 164);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(112, 23);
            this.AboutButton.TabIndex = 2;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // SessionButton
            // 
            this.SessionButton.Location = new System.Drawing.Point(10, 135);
            this.SessionButton.Name = "SessionButton";
            this.SessionButton.Size = new System.Drawing.Size(112, 23);
            this.SessionButton.TabIndex = 0;
            this.SessionButton.Text = "Session";
            this.SessionButton.UseVisualStyleBackColor = true;
            this.SessionButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // PacketListBox
            // 
            this.PacketListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PacketListBox.FormattingEnabled = true;
            this.PacketListBox.ItemHeight = 14;
            this.PacketListBox.Location = new System.Drawing.Point(152, 27);
            this.PacketListBox.Name = "PacketListBox";
            this.PacketListBox.Size = new System.Drawing.Size(408, 578);
            this.PacketListBox.TabIndex = 3;
            this.PacketListBox.SelectedIndexChanged += new System.EventHandler(this.PacketListBox_SelectedIndexChanged);
            this.PacketListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PacketListBox_KeyPress);
            this.PacketListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PacketListBox_MouseDoubleClick);
            // 
            // IncomingSyncLabel
            // 
            this.IncomingSyncLabel.AutoSize = true;
            this.IncomingSyncLabel.Location = new System.Drawing.Point(152, 8);
            this.IncomingSyncLabel.Name = "IncomingSyncLabel";
            this.IncomingSyncLabel.Size = new System.Drawing.Size(78, 13);
            this.IncomingSyncLabel.TabIndex = 4;
            this.IncomingSyncLabel.Text = "Incoming sync:";
            // 
            // IncomingSyncValueLabel
            // 
            this.IncomingSyncValueLabel.AutoSize = true;
            this.IncomingSyncValueLabel.ForeColor = System.Drawing.Color.Red;
            this.IncomingSyncValueLabel.Location = new System.Drawing.Point(236, 8);
            this.IncomingSyncValueLabel.Name = "IncomingSyncValueLabel";
            this.IncomingSyncValueLabel.Size = new System.Drawing.Size(29, 13);
            this.IncomingSyncValueLabel.TabIndex = 5;
            this.IncomingSyncValueLabel.Text = "false";
            // 
            // OutgoingSyncLabel
            // 
            this.OutgoingSyncLabel.AutoSize = true;
            this.OutgoingSyncLabel.Location = new System.Drawing.Point(271, 8);
            this.OutgoingSyncLabel.Name = "OutgoingSyncLabel";
            this.OutgoingSyncLabel.Size = new System.Drawing.Size(78, 13);
            this.OutgoingSyncLabel.TabIndex = 6;
            this.OutgoingSyncLabel.Text = "Outgoing sync:";
            // 
            // OutgoingSyncValueLabel
            // 
            this.OutgoingSyncValueLabel.AutoSize = true;
            this.OutgoingSyncValueLabel.ForeColor = System.Drawing.Color.Red;
            this.OutgoingSyncValueLabel.Location = new System.Drawing.Point(355, 8);
            this.OutgoingSyncValueLabel.Name = "OutgoingSyncValueLabel";
            this.OutgoingSyncValueLabel.Size = new System.Drawing.Size(29, 13);
            this.OutgoingSyncValueLabel.TabIndex = 7;
            this.OutgoingSyncValueLabel.Text = "false";
            // 
            // PacketsCauchtLabel
            // 
            this.PacketsCauchtLabel.AutoSize = true;
            this.PacketsCauchtLabel.Location = new System.Drawing.Point(391, 8);
            this.PacketsCauchtLabel.Name = "PacketsCauchtLabel";
            this.PacketsCauchtLabel.Size = new System.Drawing.Size(85, 13);
            this.PacketsCauchtLabel.TabIndex = 8;
            this.PacketsCauchtLabel.Text = "Packets caught:";
            // 
            // PacketsCaughtValueLabel
            // 
            this.PacketsCaughtValueLabel.AutoSize = true;
            this.PacketsCaughtValueLabel.Location = new System.Drawing.Point(482, 8);
            this.PacketsCaughtValueLabel.Name = "PacketsCaughtValueLabel";
            this.PacketsCaughtValueLabel.Size = new System.Drawing.Size(13, 13);
            this.PacketsCaughtValueLabel.TabIndex = 9;
            this.PacketsCaughtValueLabel.Text = "0";
            // 
            // PacketCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 619);
            this.Controls.Add(this.PacketsCaughtValueLabel);
            this.Controls.Add(this.PacketsCauchtLabel);
            this.Controls.Add(this.OutgoingSyncValueLabel);
            this.Controls.Add(this.OutgoingSyncLabel);
            this.Controls.Add(this.IncomingSyncValueLabel);
            this.Controls.Add(this.IncomingSyncLabel);
            this.Controls.Add(this.PacketListBox);
            this.Controls.Add(this.ControlGroupBox);
            this.Controls.Add(this.FilterGroupBox);
            this.Controls.Add(this.ConnectionGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(590, 658);
            this.MinimumSize = new System.Drawing.Size(590, 658);
            this.Name = "PacketCaptureForm";
            this.Text = "RotmgPCap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacketCaptureForm_FormClosing);
            this.Load += new System.EventHandler(this.PacketCaptureForm_Load);
            this.ConnectionGroupBox.ResumeLayout(false);
            this.ConnectionGroupBox.PerformLayout();
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            this.ControlGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ConnectionGroupBox;
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.GroupBox ControlGroupBox;
        private System.Windows.Forms.ComboBox NetworkDeviceComboBox;
        private System.Windows.Forms.Label PortLabel;
        private RotmgPCap.Forms.Components.NumericTextbox PortTextBox;
        private System.Windows.Forms.ComboBox SocketTimeoutComboBox;
        private System.Windows.Forms.Label SocketTimeoutLabel;
        private System.Windows.Forms.TextBox DetectedAddressTextBox;
        private System.Windows.Forms.Label DetectedAddressLabel;
        private System.Windows.Forms.CheckBox IngoreAckCheckBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Button SessionButton;
        private System.Windows.Forms.Label NetworkDeviceLabel;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.ListBox PacketListBox;
        private System.Windows.Forms.CheckBox HaltUntilSyncCheckBox;
        private System.Windows.Forms.Label DirectionLabel;
        private RotmgPCap.Forms.Components.NumericTextbox PacketIdTextBox;
        private System.Windows.Forms.ComboBox PacketTypeComboBox;
        private System.Windows.Forms.CheckBox SpecificPacketCheckBox;
        private System.Windows.Forms.ComboBox DirectionComboBox;
        private System.Windows.Forms.Label IncomingSyncLabel;
        private System.Windows.Forms.Label IncomingSyncValueLabel;
        private System.Windows.Forms.Label OutgoingSyncLabel;
        private System.Windows.Forms.Label OutgoingSyncValueLabel;
        private System.Windows.Forms.Label PacketsCauchtLabel;
        private System.Windows.Forms.Label PacketsCaughtValueLabel;
    }
}