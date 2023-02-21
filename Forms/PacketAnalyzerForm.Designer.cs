
namespace RotmgPCap.Forms
{
    partial class PacketAnalyzerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketAnalyzerForm));
            this.PacketTreeView = new System.Windows.Forms.TreeView();
            this.AlgorythmGroupBox = new System.Windows.Forms.GroupBox();
            this.ReloadProtoFileButton = new System.Windows.Forms.Button();
            this.OpenProtoFileButton = new System.Windows.Forms.Button();
            this.RawValuePanel = new System.Windows.Forms.Panel();
            this.UtfLengthTextBox = new System.Windows.Forms.TextBox();
            this.UtfValueTextBox = new System.Windows.Forms.TextBox();
            this.CompressedValueTextBox = new System.Windows.Forms.TextBox();
            this.CompressedLengthTextBox = new System.Windows.Forms.TextBox();
            this.UtfLabel = new System.Windows.Forms.Label();
            this.CompressedLabel = new System.Windows.Forms.Label();
            this.BooleanValueTextBox = new System.Windows.Forms.TextBox();
            this.FloatValueTextBox = new System.Windows.Forms.TextBox();
            this.BooleanLabel = new System.Windows.Forms.Label();
            this.FloatLabel = new System.Windows.Forms.Label();
            this.UInt32ValueTextBox = new System.Windows.Forms.TextBox();
            this.Int32ValueTextBox = new System.Windows.Forms.TextBox();
            this.UInt32Label = new System.Windows.Forms.Label();
            this.Int32Label = new System.Windows.Forms.Label();
            this.UInt16ValueTextBox = new System.Windows.Forms.TextBox();
            this.Int16ValueTextBox = new System.Windows.Forms.TextBox();
            this.UInt16Label = new System.Windows.Forms.Label();
            this.Int16Label = new System.Windows.Forms.Label();
            this.ByteValueTextBox = new System.Windows.Forms.TextBox();
            this.SByteValueTextBox = new System.Windows.Forms.TextBox();
            this.ByteLabel = new System.Windows.Forms.Label();
            this.SByteLabel = new System.Windows.Forms.Label();
            this.PacketDataView = new System.Windows.Forms.Panel();
            this.PacketTimeValueLabel = new System.Windows.Forms.Label();
            this.PacketSizeValueLabel = new System.Windows.Forms.Label();
            this.PacketDirectionValueLabel = new System.Windows.Forms.Label();
            this.PacketTypeValueLabel = new System.Windows.Forms.Label();
            this.PacketTimeLabel = new System.Windows.Forms.Label();
            this.PacketSizeLabel = new System.Windows.Forms.Label();
            this.PacketDirectionLabel = new System.Windows.Forms.Label();
            this.PacketTypeLabel = new System.Windows.Forms.Label();
            this.ObjectValueLabel = new System.Windows.Forms.Label();
            this.ObjectValueTextBox = new System.Windows.Forms.TextBox();
            this.SelectionDetails = new System.Windows.Forms.Label();
            this.HexModeCheckBox = new System.Windows.Forms.CheckBox();
            this.BinaryView = new RotmgPCap.Forms.Components.BinaryView();
            this.AlgorythmGroupBox.SuspendLayout();
            this.RawValuePanel.SuspendLayout();
            this.PacketDataView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryView)).BeginInit();
            this.SuspendLayout();
            // 
            // PacketTreeView
            // 
            this.PacketTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PacketTreeView.Location = new System.Drawing.Point(12, 89);
            this.PacketTreeView.Name = "PacketTreeView";
            this.PacketTreeView.Size = new System.Drawing.Size(232, 520);
            this.PacketTreeView.TabIndex = 2;
            this.PacketTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PacketTreeView_AfterSelect);
            this.PacketTreeView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // AlgorythmGroupBox
            // 
            this.AlgorythmGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AlgorythmGroupBox.Controls.Add(this.ReloadProtoFileButton);
            this.AlgorythmGroupBox.Controls.Add(this.OpenProtoFileButton);
            this.AlgorythmGroupBox.Location = new System.Drawing.Point(11, 712);
            this.AlgorythmGroupBox.Name = "AlgorythmGroupBox";
            this.AlgorythmGroupBox.Size = new System.Drawing.Size(233, 55);
            this.AlgorythmGroupBox.TabIndex = 0;
            this.AlgorythmGroupBox.TabStop = false;
            this.AlgorythmGroupBox.Text = "Analysis";
            // 
            // ReloadProtoFileButton
            // 
            this.ReloadProtoFileButton.Location = new System.Drawing.Point(6, 19);
            this.ReloadProtoFileButton.Name = "ReloadProtoFileButton";
            this.ReloadProtoFileButton.Size = new System.Drawing.Size(78, 23);
            this.ReloadProtoFileButton.TabIndex = 1;
            this.ReloadProtoFileButton.Text = "Refresh";
            this.ReloadProtoFileButton.UseVisualStyleBackColor = true;
            this.ReloadProtoFileButton.Click += new System.EventHandler(this.ReloadProtoFileButton_Click);
            // 
            // OpenProtoFileButton
            // 
            this.OpenProtoFileButton.Location = new System.Drawing.Point(90, 19);
            this.OpenProtoFileButton.Name = "OpenProtoFileButton";
            this.OpenProtoFileButton.Size = new System.Drawing.Size(78, 23);
            this.OpenProtoFileButton.TabIndex = 0;
            this.OpenProtoFileButton.Text = "Open proto file";
            this.OpenProtoFileButton.UseVisualStyleBackColor = true;
            this.OpenProtoFileButton.Click += new System.EventHandler(this.OpenProtoFileButton_Click);
            // 
            // RawValuePanel
            // 
            this.RawValuePanel.BackColor = System.Drawing.SystemColors.Window;
            this.RawValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RawValuePanel.Controls.Add(this.UtfLengthTextBox);
            this.RawValuePanel.Controls.Add(this.UtfValueTextBox);
            this.RawValuePanel.Controls.Add(this.CompressedValueTextBox);
            this.RawValuePanel.Controls.Add(this.CompressedLengthTextBox);
            this.RawValuePanel.Controls.Add(this.UtfLabel);
            this.RawValuePanel.Controls.Add(this.CompressedLabel);
            this.RawValuePanel.Controls.Add(this.BooleanValueTextBox);
            this.RawValuePanel.Controls.Add(this.FloatValueTextBox);
            this.RawValuePanel.Controls.Add(this.BooleanLabel);
            this.RawValuePanel.Controls.Add(this.FloatLabel);
            this.RawValuePanel.Controls.Add(this.UInt32ValueTextBox);
            this.RawValuePanel.Controls.Add(this.Int32ValueTextBox);
            this.RawValuePanel.Controls.Add(this.UInt32Label);
            this.RawValuePanel.Controls.Add(this.Int32Label);
            this.RawValuePanel.Controls.Add(this.UInt16ValueTextBox);
            this.RawValuePanel.Controls.Add(this.Int16ValueTextBox);
            this.RawValuePanel.Controls.Add(this.UInt16Label);
            this.RawValuePanel.Controls.Add(this.Int16Label);
            this.RawValuePanel.Controls.Add(this.ByteValueTextBox);
            this.RawValuePanel.Controls.Add(this.SByteValueTextBox);
            this.RawValuePanel.Controls.Add(this.ByteLabel);
            this.RawValuePanel.Controls.Add(this.SByteLabel);
            this.RawValuePanel.Location = new System.Drawing.Point(250, 12);
            this.RawValuePanel.Name = "RawValuePanel";
            this.RawValuePanel.Size = new System.Drawing.Size(576, 47);
            this.RawValuePanel.TabIndex = 4;
            // 
            // UtfLengthTextBox
            // 
            this.UtfLengthTextBox.Location = new System.Drawing.Point(437, 22);
            this.UtfLengthTextBox.Name = "UtfLengthTextBox";
            this.UtfLengthTextBox.ReadOnly = true;
            this.UtfLengthTextBox.Size = new System.Drawing.Size(24, 20);
            this.UtfLengthTextBox.TabIndex = 19;
            // 
            // UtfValueTextBox
            // 
            this.UtfValueTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.UtfValueTextBox.Location = new System.Drawing.Point(459, 22);
            this.UtfValueTextBox.Name = "UtfValueTextBox";
            this.UtfValueTextBox.ReadOnly = true;
            this.UtfValueTextBox.Size = new System.Drawing.Size(112, 20);
            this.UtfValueTextBox.TabIndex = 18;
            // 
            // CompressedValueTextBox
            // 
            this.CompressedValueTextBox.Location = new System.Drawing.Point(460, 3);
            this.CompressedValueTextBox.Name = "CompressedValueTextBox";
            this.CompressedValueTextBox.ReadOnly = true;
            this.CompressedValueTextBox.Size = new System.Drawing.Size(111, 20);
            this.CompressedValueTextBox.TabIndex = 18;
            // 
            // CompressedLengthTextBox
            // 
            this.CompressedLengthTextBox.Location = new System.Drawing.Point(437, 3);
            this.CompressedLengthTextBox.Name = "CompressedLengthTextBox";
            this.CompressedLengthTextBox.ReadOnly = true;
            this.CompressedLengthTextBox.Size = new System.Drawing.Size(24, 20);
            this.CompressedLengthTextBox.TabIndex = 18;
            // 
            // UtfLabel
            // 
            this.UtfLabel.AutoSize = true;
            this.UtfLabel.Location = new System.Drawing.Point(398, 25);
            this.UtfLabel.Name = "UtfLabel";
            this.UtfLabel.Size = new System.Drawing.Size(21, 13);
            this.UtfLabel.TabIndex = 17;
            this.UtfLabel.Text = "Utf";
            // 
            // CompressedLabel
            // 
            this.CompressedLabel.AutoSize = true;
            this.CompressedLabel.Location = new System.Drawing.Point(398, 6);
            this.CompressedLabel.Name = "CompressedLabel";
            this.CompressedLabel.Size = new System.Drawing.Size(40, 13);
            this.CompressedLabel.TabIndex = 16;
            this.CompressedLabel.Text = "Compr.";
            // 
            // BooleanValueTextBox
            // 
            this.BooleanValueTextBox.Location = new System.Drawing.Point(337, 22);
            this.BooleanValueTextBox.Name = "BooleanValueTextBox";
            this.BooleanValueTextBox.ReadOnly = true;
            this.BooleanValueTextBox.Size = new System.Drawing.Size(55, 20);
            this.BooleanValueTextBox.TabIndex = 15;
            // 
            // FloatValueTextBox
            // 
            this.FloatValueTextBox.Location = new System.Drawing.Point(337, 3);
            this.FloatValueTextBox.Name = "FloatValueTextBox";
            this.FloatValueTextBox.ReadOnly = true;
            this.FloatValueTextBox.Size = new System.Drawing.Size(55, 20);
            this.FloatValueTextBox.TabIndex = 14;
            // 
            // BooleanLabel
            // 
            this.BooleanLabel.AutoSize = true;
            this.BooleanLabel.Location = new System.Drawing.Point(300, 25);
            this.BooleanLabel.Name = "BooleanLabel";
            this.BooleanLabel.Size = new System.Drawing.Size(31, 13);
            this.BooleanLabel.TabIndex = 13;
            this.BooleanLabel.Text = "Bool.";
            // 
            // FloatLabel
            // 
            this.FloatLabel.AutoSize = true;
            this.FloatLabel.Location = new System.Drawing.Point(300, 6);
            this.FloatLabel.Name = "FloatLabel";
            this.FloatLabel.Size = new System.Drawing.Size(30, 13);
            this.FloatLabel.TabIndex = 12;
            this.FloatLabel.Text = "Float";
            // 
            // UInt32ValueTextBox
            // 
            this.UInt32ValueTextBox.Location = new System.Drawing.Point(222, 22);
            this.UInt32ValueTextBox.Name = "UInt32ValueTextBox";
            this.UInt32ValueTextBox.ReadOnly = true;
            this.UInt32ValueTextBox.Size = new System.Drawing.Size(72, 20);
            this.UInt32ValueTextBox.TabIndex = 11;
            // 
            // Int32ValueTextBox
            // 
            this.Int32ValueTextBox.Location = new System.Drawing.Point(222, 3);
            this.Int32ValueTextBox.Name = "Int32ValueTextBox";
            this.Int32ValueTextBox.ReadOnly = true;
            this.Int32ValueTextBox.Size = new System.Drawing.Size(72, 20);
            this.Int32ValueTextBox.TabIndex = 10;
            // 
            // UInt32Label
            // 
            this.UInt32Label.AutoSize = true;
            this.UInt32Label.Location = new System.Drawing.Point(180, 25);
            this.UInt32Label.Name = "UInt32Label";
            this.UInt32Label.Size = new System.Drawing.Size(38, 13);
            this.UInt32Label.TabIndex = 9;
            this.UInt32Label.Text = "Uint32";
            // 
            // Int32Label
            // 
            this.Int32Label.AutoSize = true;
            this.Int32Label.Location = new System.Drawing.Point(180, 6);
            this.Int32Label.Name = "Int32Label";
            this.Int32Label.Size = new System.Drawing.Size(31, 13);
            this.Int32Label.TabIndex = 8;
            this.Int32Label.Text = "Int32";
            // 
            // UInt16ValueTextBox
            // 
            this.UInt16ValueTextBox.Location = new System.Drawing.Point(121, 22);
            this.UInt16ValueTextBox.Name = "UInt16ValueTextBox";
            this.UInt16ValueTextBox.ReadOnly = true;
            this.UInt16ValueTextBox.Size = new System.Drawing.Size(53, 20);
            this.UInt16ValueTextBox.TabIndex = 7;
            // 
            // Int16ValueTextBox
            // 
            this.Int16ValueTextBox.Location = new System.Drawing.Point(121, 3);
            this.Int16ValueTextBox.Name = "Int16ValueTextBox";
            this.Int16ValueTextBox.ReadOnly = true;
            this.Int16ValueTextBox.Size = new System.Drawing.Size(53, 20);
            this.Int16ValueTextBox.TabIndex = 6;
            // 
            // UInt16Label
            // 
            this.UInt16Label.AutoSize = true;
            this.UInt16Label.Location = new System.Drawing.Point(80, 25);
            this.UInt16Label.Name = "UInt16Label";
            this.UInt16Label.Size = new System.Drawing.Size(38, 13);
            this.UInt16Label.TabIndex = 5;
            this.UInt16Label.Text = "Uint16";
            // 
            // Int16Label
            // 
            this.Int16Label.AutoSize = true;
            this.Int16Label.Location = new System.Drawing.Point(80, 6);
            this.Int16Label.Name = "Int16Label";
            this.Int16Label.Size = new System.Drawing.Size(31, 13);
            this.Int16Label.TabIndex = 4;
            this.Int16Label.Text = "Int16";
            // 
            // ByteValueTextBox
            // 
            this.ByteValueTextBox.Location = new System.Drawing.Point(44, 22);
            this.ByteValueTextBox.Name = "ByteValueTextBox";
            this.ByteValueTextBox.ReadOnly = true;
            this.ByteValueTextBox.Size = new System.Drawing.Size(30, 20);
            this.ByteValueTextBox.TabIndex = 3;
            // 
            // SByteValueTextBox
            // 
            this.SByteValueTextBox.Location = new System.Drawing.Point(44, 3);
            this.SByteValueTextBox.Name = "SByteValueTextBox";
            this.SByteValueTextBox.ReadOnly = true;
            this.SByteValueTextBox.Size = new System.Drawing.Size(30, 20);
            this.SByteValueTextBox.TabIndex = 2;
            // 
            // ByteLabel
            // 
            this.ByteLabel.AutoSize = true;
            this.ByteLabel.Location = new System.Drawing.Point(3, 25);
            this.ByteLabel.Name = "ByteLabel";
            this.ByteLabel.Size = new System.Drawing.Size(28, 13);
            this.ByteLabel.TabIndex = 1;
            this.ByteLabel.Text = "Byte";
            // 
            // SByteLabel
            // 
            this.SByteLabel.AutoSize = true;
            this.SByteLabel.Location = new System.Drawing.Point(3, 6);
            this.SByteLabel.Name = "SByteLabel";
            this.SByteLabel.Size = new System.Drawing.Size(35, 13);
            this.SByteLabel.TabIndex = 0;
            this.SByteLabel.Text = "SByte";
            // 
            // PacketDataView
            // 
            this.PacketDataView.BackColor = System.Drawing.SystemColors.Window;
            this.PacketDataView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PacketDataView.Controls.Add(this.PacketTimeValueLabel);
            this.PacketDataView.Controls.Add(this.PacketSizeValueLabel);
            this.PacketDataView.Controls.Add(this.PacketDirectionValueLabel);
            this.PacketDataView.Controls.Add(this.PacketTypeValueLabel);
            this.PacketDataView.Controls.Add(this.PacketTimeLabel);
            this.PacketDataView.Controls.Add(this.PacketSizeLabel);
            this.PacketDataView.Controls.Add(this.PacketDirectionLabel);
            this.PacketDataView.Controls.Add(this.PacketTypeLabel);
            this.PacketDataView.Location = new System.Drawing.Point(12, 12);
            this.PacketDataView.Name = "PacketDataView";
            this.PacketDataView.Size = new System.Drawing.Size(232, 71);
            this.PacketDataView.TabIndex = 7;
            // 
            // PacketTimeValueLabel
            // 
            this.PacketTimeValueLabel.AutoSize = true;
            this.PacketTimeValueLabel.Location = new System.Drawing.Point(55, 51);
            this.PacketTimeValueLabel.Name = "PacketTimeValueLabel";
            this.PacketTimeValueLabel.Size = new System.Drawing.Size(10, 13);
            this.PacketTimeValueLabel.TabIndex = 7;
            this.PacketTimeValueLabel.Text = " ";
            // 
            // PacketSizeValueLabel
            // 
            this.PacketSizeValueLabel.AutoSize = true;
            this.PacketSizeValueLabel.Location = new System.Drawing.Point(55, 35);
            this.PacketSizeValueLabel.Name = "PacketSizeValueLabel";
            this.PacketSizeValueLabel.Size = new System.Drawing.Size(10, 13);
            this.PacketSizeValueLabel.TabIndex = 6;
            this.PacketSizeValueLabel.Text = " ";
            // 
            // PacketDirectionValueLabel
            // 
            this.PacketDirectionValueLabel.AutoSize = true;
            this.PacketDirectionValueLabel.Location = new System.Drawing.Point(55, 19);
            this.PacketDirectionValueLabel.Name = "PacketDirectionValueLabel";
            this.PacketDirectionValueLabel.Size = new System.Drawing.Size(10, 13);
            this.PacketDirectionValueLabel.TabIndex = 5;
            this.PacketDirectionValueLabel.Text = " ";
            // 
            // PacketTypeValueLabel
            // 
            this.PacketTypeValueLabel.AutoSize = true;
            this.PacketTypeValueLabel.Location = new System.Drawing.Point(55, 3);
            this.PacketTypeValueLabel.Name = "PacketTypeValueLabel";
            this.PacketTypeValueLabel.Size = new System.Drawing.Size(10, 13);
            this.PacketTypeValueLabel.TabIndex = 4;
            this.PacketTypeValueLabel.Text = " ";
            // 
            // PacketTimeLabel
            // 
            this.PacketTimeLabel.AutoSize = true;
            this.PacketTimeLabel.Location = new System.Drawing.Point(3, 51);
            this.PacketTimeLabel.Name = "PacketTimeLabel";
            this.PacketTimeLabel.Size = new System.Drawing.Size(33, 13);
            this.PacketTimeLabel.TabIndex = 3;
            this.PacketTimeLabel.Text = "Time:";
            // 
            // PacketSizeLabel
            // 
            this.PacketSizeLabel.AutoSize = true;
            this.PacketSizeLabel.Location = new System.Drawing.Point(3, 35);
            this.PacketSizeLabel.Name = "PacketSizeLabel";
            this.PacketSizeLabel.Size = new System.Drawing.Size(30, 13);
            this.PacketSizeLabel.TabIndex = 2;
            this.PacketSizeLabel.Text = "Size:";
            // 
            // PacketDirectionLabel
            // 
            this.PacketDirectionLabel.AutoSize = true;
            this.PacketDirectionLabel.Location = new System.Drawing.Point(3, 19);
            this.PacketDirectionLabel.Name = "PacketDirectionLabel";
            this.PacketDirectionLabel.Size = new System.Drawing.Size(52, 13);
            this.PacketDirectionLabel.TabIndex = 1;
            this.PacketDirectionLabel.Text = "Direction:";
            // 
            // PacketTypeLabel
            // 
            this.PacketTypeLabel.AutoSize = true;
            this.PacketTypeLabel.Location = new System.Drawing.Point(3, 3);
            this.PacketTypeLabel.Name = "PacketTypeLabel";
            this.PacketTypeLabel.Size = new System.Drawing.Size(44, 13);
            this.PacketTypeLabel.TabIndex = 0;
            this.PacketTypeLabel.Text = "Packet:";
            // 
            // ObjectValueLabel
            // 
            this.ObjectValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ObjectValueLabel.AutoSize = true;
            this.ObjectValueLabel.Location = new System.Drawing.Point(9, 612);
            this.ObjectValueLabel.Name = "ObjectValueLabel";
            this.ObjectValueLabel.Size = new System.Drawing.Size(49, 13);
            this.ObjectValueLabel.TabIndex = 9;
            this.ObjectValueLabel.Text = "Value ( ):";
            // 
            // ObjectValueTextBox
            // 
            this.ObjectValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ObjectValueTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ObjectValueTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectValueTextBox.Location = new System.Drawing.Point(12, 628);
            this.ObjectValueTextBox.Multiline = true;
            this.ObjectValueTextBox.Name = "ObjectValueTextBox";
            this.ObjectValueTextBox.ReadOnly = true;
            this.ObjectValueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ObjectValueTextBox.Size = new System.Drawing.Size(232, 78);
            this.ObjectValueTextBox.TabIndex = 10;
            // 
            // SelectionDetails
            // 
            this.SelectionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectionDetails.AutoSize = true;
            this.SelectionDetails.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionDetails.ForeColor = System.Drawing.SystemColors.GrayText;
            this.SelectionDetails.Location = new System.Drawing.Point(250, 758);
            this.SelectionDetails.Name = "SelectionDetails";
            this.SelectionDetails.Size = new System.Drawing.Size(14, 15);
            this.SelectionDetails.TabIndex = 11;
            this.SelectionDetails.Text = " ";
            // 
            // HexModeCheckBox
            // 
            this.HexModeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HexModeCheckBox.AutoSize = true;
            this.HexModeCheckBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HexModeCheckBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.HexModeCheckBox.Location = new System.Drawing.Point(779, 757);
            this.HexModeCheckBox.Name = "HexModeCheckBox";
            this.HexModeCheckBox.Size = new System.Drawing.Size(47, 19);
            this.HexModeCheckBox.TabIndex = 0;
            this.HexModeCheckBox.Text = "Hex";
            this.HexModeCheckBox.UseVisualStyleBackColor = false;
            this.HexModeCheckBox.CheckedChanged += new System.EventHandler(this.HexModeCheckBox_CheckedChanged);
            // 
            // BinaryView
            // 
            this.BinaryView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BinaryView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BinaryView.Location = new System.Drawing.Point(250, 65);
            this.BinaryView.Name = "BinaryView";
            this.BinaryView.Size = new System.Drawing.Size(576, 689);
            this.BinaryView.TabIndex = 8;
            this.BinaryView.TabStop = false;
            // 
            // PacketAnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 779);
            this.Controls.Add(this.HexModeCheckBox);
            this.Controls.Add(this.SelectionDetails);
            this.Controls.Add(this.ObjectValueTextBox);
            this.Controls.Add(this.ObjectValueLabel);
            this.Controls.Add(this.BinaryView);
            this.Controls.Add(this.PacketDataView);
            this.Controls.Add(this.RawValuePanel);
            this.Controls.Add(this.AlgorythmGroupBox);
            this.Controls.Add(this.PacketTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(854, 480);
            this.Name = "PacketAnalyzerForm";
            this.Text = "RotmgPCap - Packet Analyzer";
            this.Load += new System.EventHandler(this.PacketAnalyzerForm_Load);
            this.SizeChanged += new System.EventHandler(this.PacketAnalyzerForm_SizeChanged);
            this.AlgorythmGroupBox.ResumeLayout(false);
            this.RawValuePanel.ResumeLayout(false);
            this.RawValuePanel.PerformLayout();
            this.PacketDataView.ResumeLayout(false);
            this.PacketDataView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView PacketTreeView;
        private System.Windows.Forms.GroupBox AlgorythmGroupBox;
        private System.Windows.Forms.Panel RawValuePanel;
        private System.Windows.Forms.Panel PacketDataView;
        private System.Windows.Forms.Label PacketTypeLabel;
        private System.Windows.Forms.Label PacketTimeValueLabel;
        private System.Windows.Forms.Label PacketSizeValueLabel;
        private System.Windows.Forms.Label PacketDirectionValueLabel;
        private System.Windows.Forms.Label PacketTypeValueLabel;
        private System.Windows.Forms.Label PacketTimeLabel;
        private System.Windows.Forms.Label PacketSizeLabel;
        private System.Windows.Forms.Label PacketDirectionLabel;
        private RotmgPCap.Forms.Components.BinaryView BinaryView;
        private System.Windows.Forms.Label ObjectValueLabel;
        private System.Windows.Forms.TextBox ObjectValueTextBox;
        private System.Windows.Forms.Label SelectionDetails;
        private System.Windows.Forms.CheckBox HexModeCheckBox;
        private System.Windows.Forms.TextBox UInt16ValueTextBox;
        private System.Windows.Forms.TextBox Int16ValueTextBox;
        private System.Windows.Forms.Label UInt16Label;
        private System.Windows.Forms.Label Int16Label;
        private System.Windows.Forms.TextBox ByteValueTextBox;
        private System.Windows.Forms.TextBox SByteValueTextBox;
        private System.Windows.Forms.Label ByteLabel;
        private System.Windows.Forms.Label SByteLabel;
        private System.Windows.Forms.TextBox UInt32ValueTextBox;
        private System.Windows.Forms.TextBox Int32ValueTextBox;
        private System.Windows.Forms.Label UInt32Label;
        private System.Windows.Forms.Label Int32Label;
        private System.Windows.Forms.TextBox UtfLengthTextBox;
        private System.Windows.Forms.TextBox CompressedLengthTextBox;
        private System.Windows.Forms.Label UtfLabel;
        private System.Windows.Forms.Label CompressedLabel;
        private System.Windows.Forms.TextBox FloatValueTextBox;
        private System.Windows.Forms.Label BooleanLabel;
        private System.Windows.Forms.TextBox UtfValueTextBox;
        private System.Windows.Forms.TextBox CompressedValueTextBox;
        private System.Windows.Forms.Label FloatLabel;
        private System.Windows.Forms.TextBox BooleanValueTextBox;
        private System.Windows.Forms.Button ReloadProtoFileButton;
        private System.Windows.Forms.Button OpenProtoFileButton;
    }
}