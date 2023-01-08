
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
            this.DetectedAddressTextBox = new System.Windows.Forms.TextBox();
            this.DetectedAddressLabel = new System.Windows.Forms.Label();
            this.SocketTimeoutComboBox = new System.Windows.Forms.ComboBox();
            this.SocketTimeoutLabel = new System.Windows.Forms.Label();
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
            this.IncomingSyncLabel = new System.Windows.Forms.Label();
            this.IncomingSyncValueLabel = new System.Windows.Forms.Label();
            this.OutgoingSyncLabel = new System.Windows.Forms.Label();
            this.OutgoingSyncValueLabel = new System.Windows.Forms.Label();
            this.PacketsCaughtLabel = new System.Windows.Forms.Label();
            this.PacketsCaughtValueLabel = new System.Windows.Forms.Label();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.PortTextBox = new RotmgPCap.Forms.Components.NumericTextbox();
            this.PacketListView = new System.Windows.Forms.ListView();
            this.PIndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PDirectionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PDataColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FilterGroupBox.SuspendLayout();
            this.ControlGroupBox.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
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
            // DetectedAddressTextBox
            // 
            this.DetectedAddressTextBox.Location = new System.Drawing.Point(103, 35);
            this.DetectedAddressTextBox.Name = "DetectedAddressTextBox";
            this.DetectedAddressTextBox.ReadOnly = true;
            this.DetectedAddressTextBox.Size = new System.Drawing.Size(109, 20);
            this.DetectedAddressTextBox.TabIndex = 7;
            // 
            // DetectedAddressLabel
            // 
            this.DetectedAddressLabel.AutoSize = true;
            this.DetectedAddressLabel.Location = new System.Drawing.Point(3, 38);
            this.DetectedAddressLabel.Name = "DetectedAddressLabel";
            this.DetectedAddressLabel.Size = new System.Drawing.Size(94, 13);
            this.DetectedAddressLabel.TabIndex = 6;
            this.DetectedAddressLabel.Text = "Detected address:";
            // 
            // SocketTimeoutComboBox
            // 
            this.SocketTimeoutComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SocketTimeoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SocketTimeoutComboBox.FormattingEnabled = true;
            this.SocketTimeoutComboBox.Items.AddRange(new object[] {
            "None",
            "1",
            "2",
            "5",
            "10",
            "30"});
            this.SocketTimeoutComboBox.Location = new System.Drawing.Point(558, 8);
            this.SocketTimeoutComboBox.Name = "SocketTimeoutComboBox";
            this.SocketTimeoutComboBox.Size = new System.Drawing.Size(80, 21);
            this.SocketTimeoutComboBox.TabIndex = 5;
            // 
            // SocketTimeoutLabel
            // 
            this.SocketTimeoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SocketTimeoutLabel.AutoSize = true;
            this.SocketTimeoutLabel.Location = new System.Drawing.Point(448, 11);
            this.SocketTimeoutLabel.Name = "SocketTimeoutLabel";
            this.SocketTimeoutLabel.Size = new System.Drawing.Size(104, 13);
            this.SocketTimeoutLabel.TabIndex = 4;
            this.SocketTimeoutLabel.Text = "Socket timeout (sec)";
            // 
            // PortLabel
            // 
            this.PortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(374, 11);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(29, 13);
            this.PortLabel.TabIndex = 2;
            this.PortLabel.Text = "Port:";
            // 
            // NetworkDeviceComboBox
            // 
            this.NetworkDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NetworkDeviceComboBox.FormattingEnabled = true;
            this.NetworkDeviceComboBox.Location = new System.Drawing.Point(103, 8);
            this.NetworkDeviceComboBox.Name = "NetworkDeviceComboBox";
            this.NetworkDeviceComboBox.Size = new System.Drawing.Size(265, 21);
            this.NetworkDeviceComboBox.TabIndex = 1;
            // 
            // NetworkDeviceLabel
            // 
            this.NetworkDeviceLabel.AutoSize = true;
            this.NetworkDeviceLabel.Location = new System.Drawing.Point(3, 11);
            this.NetworkDeviceLabel.Name = "NetworkDeviceLabel";
            this.NetworkDeviceLabel.Size = new System.Drawing.Size(85, 13);
            this.NetworkDeviceLabel.TabIndex = 0;
            this.NetworkDeviceLabel.Text = "Network device:";
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
            this.FilterGroupBox.Location = new System.Drawing.Point(7, 79);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(163, 188);
            this.FilterGroupBox.TabIndex = 1;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filter";
            // 
            // DirectionComboBox
            // 
            this.DirectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DirectionComboBox.FormattingEnabled = true;
            this.DirectionComboBox.Items.AddRange(new object[] {
            "Both",
            "Incoming",
            "Outgoing"});
            this.DirectionComboBox.Location = new System.Drawing.Point(10, 154);
            this.DirectionComboBox.Name = "DirectionComboBox";
            this.DirectionComboBox.Size = new System.Drawing.Size(147, 21);
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
            this.PacketIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacketIdTextBox.Enabled = false;
            this.PacketIdTextBox.Location = new System.Drawing.Point(10, 114);
            this.PacketIdTextBox.MaxLength = 3;
            this.PacketIdTextBox.Name = "PacketIdTextBox";
            this.PacketIdTextBox.Size = new System.Drawing.Size(147, 20);
            this.PacketIdTextBox.TabIndex = 10;
            this.PacketIdTextBox.Text = "0";
            this.PacketIdTextBox.TextChanged += new System.EventHandler(this.PacketIdTextBox_TextChanged);
            this.PacketIdTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PacketIdTextBox_KeyUp);
            // 
            // PacketTypeComboBox
            // 
            this.PacketTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacketTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PacketTypeComboBox.Enabled = false;
            this.PacketTypeComboBox.FormattingEnabled = true;
            this.PacketTypeComboBox.Location = new System.Drawing.Point(10, 87);
            this.PacketTypeComboBox.Name = "PacketTypeComboBox";
            this.PacketTypeComboBox.Size = new System.Drawing.Size(147, 21);
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
            this.AnalyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalyzeButton.Enabled = false;
            this.AnalyzeButton.Location = new System.Drawing.Point(10, 48);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(147, 23);
            this.AnalyzeButton.TabIndex = 6;
            this.AnalyzeButton.Text = "Analyze";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(10, 106);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(147, 23);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(10, 77);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(147, 23);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartStopButton.BackColor = System.Drawing.Color.Transparent;
            this.StartStopButton.Location = new System.Drawing.Point(10, 19);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(147, 23);
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
            this.ControlGroupBox.Location = new System.Drawing.Point(7, 273);
            this.ControlGroupBox.Name = "ControlGroupBox";
            this.ControlGroupBox.Size = new System.Drawing.Size(163, 198);
            this.ControlGroupBox.TabIndex = 2;
            this.ControlGroupBox.TabStop = false;
            this.ControlGroupBox.Text = "Control";
            // 
            // AboutButton
            // 
            this.AboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutButton.Location = new System.Drawing.Point(10, 164);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(147, 23);
            this.AboutButton.TabIndex = 2;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // SessionButton
            // 
            this.SessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SessionButton.Location = new System.Drawing.Point(10, 135);
            this.SessionButton.Name = "SessionButton";
            this.SessionButton.Size = new System.Drawing.Size(147, 23);
            this.SessionButton.TabIndex = 0;
            this.SessionButton.Text = "Session";
            this.SessionButton.UseVisualStyleBackColor = true;
            this.SessionButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // IncomingSyncLabel
            // 
            this.IncomingSyncLabel.AutoSize = true;
            this.IncomingSyncLabel.Location = new System.Drawing.Point(218, 38);
            this.IncomingSyncLabel.Name = "IncomingSyncLabel";
            this.IncomingSyncLabel.Size = new System.Drawing.Size(78, 13);
            this.IncomingSyncLabel.TabIndex = 4;
            this.IncomingSyncLabel.Text = "Incoming sync:";
            // 
            // IncomingSyncValueLabel
            // 
            this.IncomingSyncValueLabel.AutoSize = true;
            this.IncomingSyncValueLabel.ForeColor = System.Drawing.Color.Red;
            this.IncomingSyncValueLabel.Location = new System.Drawing.Point(302, 38);
            this.IncomingSyncValueLabel.Name = "IncomingSyncValueLabel";
            this.IncomingSyncValueLabel.Size = new System.Drawing.Size(29, 13);
            this.IncomingSyncValueLabel.TabIndex = 5;
            this.IncomingSyncValueLabel.Text = "false";
            // 
            // OutgoingSyncLabel
            // 
            this.OutgoingSyncLabel.AutoSize = true;
            this.OutgoingSyncLabel.Location = new System.Drawing.Point(337, 38);
            this.OutgoingSyncLabel.Name = "OutgoingSyncLabel";
            this.OutgoingSyncLabel.Size = new System.Drawing.Size(78, 13);
            this.OutgoingSyncLabel.TabIndex = 6;
            this.OutgoingSyncLabel.Text = "Outgoing sync:";
            // 
            // OutgoingSyncValueLabel
            // 
            this.OutgoingSyncValueLabel.AutoSize = true;
            this.OutgoingSyncValueLabel.ForeColor = System.Drawing.Color.Red;
            this.OutgoingSyncValueLabel.Location = new System.Drawing.Point(421, 38);
            this.OutgoingSyncValueLabel.Name = "OutgoingSyncValueLabel";
            this.OutgoingSyncValueLabel.Size = new System.Drawing.Size(29, 13);
            this.OutgoingSyncValueLabel.TabIndex = 7;
            this.OutgoingSyncValueLabel.Text = "false";
            // 
            // PacketsCaughtLabel
            // 
            this.PacketsCaughtLabel.AutoSize = true;
            this.PacketsCaughtLabel.Location = new System.Drawing.Point(457, 38);
            this.PacketsCaughtLabel.Name = "PacketsCaughtLabel";
            this.PacketsCaughtLabel.Size = new System.Drawing.Size(85, 13);
            this.PacketsCaughtLabel.TabIndex = 8;
            this.PacketsCaughtLabel.Text = "Packets caught:";
            // 
            // PacketsCaughtValueLabel
            // 
            this.PacketsCaughtValueLabel.AutoSize = true;
            this.PacketsCaughtValueLabel.Location = new System.Drawing.Point(548, 38);
            this.PacketsCaughtValueLabel.Name = "PacketsCaughtValueLabel";
            this.PacketsCaughtValueLabel.Size = new System.Drawing.Size(13, 13);
            this.PacketsCaughtValueLabel.TabIndex = 9;
            this.PacketsCaughtValueLabel.Text = "0";
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeaderPanel.Controls.Add(this.DetectedAddressTextBox);
            this.HeaderPanel.Controls.Add(this.IncomingSyncLabel);
            this.HeaderPanel.Controls.Add(this.DetectedAddressLabel);
            this.HeaderPanel.Controls.Add(this.PacketsCaughtValueLabel);
            this.HeaderPanel.Controls.Add(this.SocketTimeoutComboBox);
            this.HeaderPanel.Controls.Add(this.IncomingSyncValueLabel);
            this.HeaderPanel.Controls.Add(this.SocketTimeoutLabel);
            this.HeaderPanel.Controls.Add(this.PacketsCaughtLabel);
            this.HeaderPanel.Controls.Add(this.PortTextBox);
            this.HeaderPanel.Controls.Add(this.OutgoingSyncLabel);
            this.HeaderPanel.Controls.Add(this.PortLabel);
            this.HeaderPanel.Controls.Add(this.OutgoingSyncValueLabel);
            this.HeaderPanel.Controls.Add(this.NetworkDeviceComboBox);
            this.HeaderPanel.Controls.Add(this.NetworkDeviceLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(4, 4);
            this.HeaderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderPanel.MinimumSize = new System.Drawing.Size(2, 64);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(643, 64);
            this.HeaderPanel.TabIndex = 10;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PortTextBox.Location = new System.Drawing.Point(409, 8);
            this.PortTextBox.MaxLength = 5;
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(33, 20);
            this.PortTextBox.TabIndex = 3;
            this.PortTextBox.Text = "2050";
            // 
            // PacketListView
            // 
            this.PacketListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacketListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PIndexColumn,
            this.PTimeColumn,
            this.PDirectionColumn,
            this.PNameColumn,
            this.PDataColumn});
            this.PacketListView.FullRowSelect = true;
            this.PacketListView.GridLines = true;
            this.PacketListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PacketListView.HideSelection = false;
            this.PacketListView.Location = new System.Drawing.Point(176, 71);
            this.PacketListView.Name = "PacketListView";
            this.PacketListView.Size = new System.Drawing.Size(468, 560);
            this.PacketListView.TabIndex = 11;
            this.PacketListView.UseCompatibleStateImageBehavior = false;
            this.PacketListView.View = System.Windows.Forms.View.Details;
            this.PacketListView.SelectedIndexChanged += new System.EventHandler(this.PacketListView_SelectedIndexChanged);
            this.PacketListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PacketListView_KeyPress);
            this.PacketListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PacketListView_MouseDoubleClick);
            // 
            // PIndexColumn
            // 
            this.PIndexColumn.Text = "#";
            this.PIndexColumn.Width = 50;
            // 
            // PTimeColumn
            // 
            this.PTimeColumn.Text = "Time";
            // 
            // PDirectionColumn
            // 
            this.PDirectionColumn.Text = "Direction";
            // 
            // PNameColumn
            // 
            this.PNameColumn.Text = "Type";
            this.PNameColumn.Width = 180;
            // 
            // PDataColumn
            // 
            this.PDataColumn.Text = "Data";
            this.PDataColumn.Width = 80;
            // 
            // PacketCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 638);
            this.Controls.Add(this.PacketListView);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.ControlGroupBox);
            this.Controls.Add(this.FilterGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(590, 515);
            this.Name = "PacketCaptureForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "RotmgPCap - Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacketCaptureForm_FormClosing);
            this.Load += new System.EventHandler(this.PacketCaptureForm_Load);
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            this.ControlGroupBox.ResumeLayout(false);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Label PacketsCaughtLabel;
        private System.Windows.Forms.Label PacketsCaughtValueLabel;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.ListView PacketListView;
        private System.Windows.Forms.ColumnHeader PIndexColumn;
        private System.Windows.Forms.ColumnHeader PTimeColumn;
        private System.Windows.Forms.ColumnHeader PDirectionColumn;
        private System.Windows.Forms.ColumnHeader PNameColumn;
        private System.Windows.Forms.ColumnHeader PDataColumn;
    }
}