
namespace RotmgPCap.Forms
{
    partial class SessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionForm));
            this.SessionDetailsPanel = new System.Windows.Forms.Panel();
            this.TypesValueLabel = new System.Windows.Forms.Label();
            this.ImportedValueLabel = new System.Windows.Forms.Label();
            this.CapturedValueLabel = new System.Windows.Forms.Label();
            this.PacketCoultValueLabel = new System.Windows.Forms.Label();
            this.TypesLabel = new System.Windows.Forms.Label();
            this.ImportedLabel = new System.Windows.Forms.Label();
            this.CapturedLabel = new System.Windows.Forms.Label();
            this.PacketCountLabel = new System.Windows.Forms.Label();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ExportModeLabel = new System.Windows.Forms.Label();
            this.ExportModeComboBox = new System.Windows.Forms.ComboBox();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathPickButton = new System.Windows.Forms.Button();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SessionDetailsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SessionDetailsPanel
            // 
            this.SessionDetailsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SessionDetailsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.SessionDetailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SessionDetailsPanel.Controls.Add(this.TypesValueLabel);
            this.SessionDetailsPanel.Controls.Add(this.ImportedValueLabel);
            this.SessionDetailsPanel.Controls.Add(this.CapturedValueLabel);
            this.SessionDetailsPanel.Controls.Add(this.PacketCoultValueLabel);
            this.SessionDetailsPanel.Controls.Add(this.TypesLabel);
            this.SessionDetailsPanel.Controls.Add(this.ImportedLabel);
            this.SessionDetailsPanel.Controls.Add(this.CapturedLabel);
            this.SessionDetailsPanel.Controls.Add(this.PacketCountLabel);
            this.SessionDetailsPanel.Location = new System.Drawing.Point(12, 12);
            this.SessionDetailsPanel.Name = "SessionDetailsPanel";
            this.SessionDetailsPanel.Size = new System.Drawing.Size(193, 113);
            this.SessionDetailsPanel.TabIndex = 0;
            // 
            // TypesValueLabel
            // 
            this.TypesValueLabel.AutoSize = true;
            this.TypesValueLabel.Location = new System.Drawing.Point(74, 67);
            this.TypesValueLabel.Name = "TypesValueLabel";
            this.TypesValueLabel.Size = new System.Drawing.Size(0, 13);
            this.TypesValueLabel.TabIndex = 7;
            // 
            // ImportedValueLabel
            // 
            this.ImportedValueLabel.AutoSize = true;
            this.ImportedValueLabel.Location = new System.Drawing.Point(74, 48);
            this.ImportedValueLabel.Name = "ImportedValueLabel";
            this.ImportedValueLabel.Size = new System.Drawing.Size(10, 13);
            this.ImportedValueLabel.TabIndex = 6;
            this.ImportedValueLabel.Text = " ";
            // 
            // CapturedValueLabel
            // 
            this.CapturedValueLabel.AutoSize = true;
            this.CapturedValueLabel.Location = new System.Drawing.Point(74, 29);
            this.CapturedValueLabel.Name = "CapturedValueLabel";
            this.CapturedValueLabel.Size = new System.Drawing.Size(10, 13);
            this.CapturedValueLabel.TabIndex = 5;
            this.CapturedValueLabel.Text = " ";
            // 
            // PacketCoultValueLabel
            // 
            this.PacketCoultValueLabel.AutoSize = true;
            this.PacketCoultValueLabel.Location = new System.Drawing.Point(74, 10);
            this.PacketCoultValueLabel.Name = "PacketCoultValueLabel";
            this.PacketCoultValueLabel.Size = new System.Drawing.Size(10, 13);
            this.PacketCoultValueLabel.TabIndex = 4;
            this.PacketCoultValueLabel.Text = " ";
            // 
            // TypesLabel
            // 
            this.TypesLabel.AutoSize = true;
            this.TypesLabel.Location = new System.Drawing.Point(4, 67);
            this.TypesLabel.Name = "TypesLabel";
            this.TypesLabel.Size = new System.Drawing.Size(39, 13);
            this.TypesLabel.TabIndex = 3;
            this.TypesLabel.Text = "Types:";
            // 
            // ImportedLabel
            // 
            this.ImportedLabel.AutoSize = true;
            this.ImportedLabel.Location = new System.Drawing.Point(4, 48);
            this.ImportedLabel.Name = "ImportedLabel";
            this.ImportedLabel.Size = new System.Drawing.Size(51, 13);
            this.ImportedLabel.TabIndex = 2;
            this.ImportedLabel.Text = "Imported:";
            // 
            // CapturedLabel
            // 
            this.CapturedLabel.AutoSize = true;
            this.CapturedLabel.Location = new System.Drawing.Point(4, 29);
            this.CapturedLabel.Name = "CapturedLabel";
            this.CapturedLabel.Size = new System.Drawing.Size(53, 13);
            this.CapturedLabel.TabIndex = 1;
            this.CapturedLabel.Text = "Captured:";
            // 
            // PacketCountLabel
            // 
            this.PacketCountLabel.AutoSize = true;
            this.PacketCountLabel.Location = new System.Drawing.Point(4, 10);
            this.PacketCountLabel.Name = "PacketCountLabel";
            this.PacketCountLabel.Size = new System.Drawing.Size(74, 13);
            this.PacketCountLabel.TabIndex = 0;
            this.PacketCountLabel.Text = "Packet count:";
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.Location = new System.Drawing.Point(213, 84);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(116, 23);
            this.ExportButton.TabIndex = 1;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.Location = new System.Drawing.Point(211, 12);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(116, 23);
            this.ImportButton.TabIndex = 2;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // ExportModeLabel
            // 
            this.ExportModeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportModeLabel.AutoSize = true;
            this.ExportModeLabel.Location = new System.Drawing.Point(210, 41);
            this.ExportModeLabel.Name = "ExportModeLabel";
            this.ExportModeLabel.Size = new System.Drawing.Size(69, 13);
            this.ExportModeLabel.TabIndex = 4;
            this.ExportModeLabel.Text = "Export mode:";
            // 
            // ExportModeComboBox
            // 
            this.ExportModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExportModeComboBox.FormattingEnabled = true;
            this.ExportModeComboBox.Items.AddRange(new object[] {
            "Combined",
            "Sorted combined",
            "Individual"});
            this.ExportModeComboBox.Location = new System.Drawing.Point(213, 57);
            this.ExportModeComboBox.Name = "ExportModeComboBox";
            this.ExportModeComboBox.Size = new System.Drawing.Size(116, 21);
            this.ExportModeComboBox.TabIndex = 5;
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.Location = new System.Drawing.Point(12, 133);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(285, 20);
            this.PathTextBox.TabIndex = 7;
            // 
            // PathPickButton
            // 
            this.PathPickButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PathPickButton.Location = new System.Drawing.Point(303, 131);
            this.PathPickButton.Name = "PathPickButton";
            this.PathPickButton.Size = new System.Drawing.Size(25, 23);
            this.PathPickButton.TabIndex = 8;
            this.PathPickButton.Text = "...";
            this.PathPickButton.UseVisualStyleBackColor = true;
            this.PathPickButton.Click += new System.EventHandler(this.PathPickButton_Click);
            // 
            // ImportFileDialog
            // 
            this.ImportFileDialog.FileName = "ImportFileDialogFile";
            this.ImportFileDialog.Filter = "Binary files (*.bin)|*.bin";
            this.ImportFileDialog.Multiselect = true;
            // 
            // SessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 165);
            this.Controls.Add(this.PathPickButton);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.ExportModeComboBox);
            this.Controls.Add(this.ExportModeLabel);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.SessionDetailsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(310, 186);
            this.Name = "SessionForm";
            this.Text = "RotmgPCap - Session";
            this.Load += new System.EventHandler(this.SessionForm_Load);
            this.SessionDetailsPanel.ResumeLayout(false);
            this.SessionDetailsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SessionDetailsPanel;
        private System.Windows.Forms.Label PacketCountLabel;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Label ExportModeLabel;
        private System.Windows.Forms.ComboBox ExportModeComboBox;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button PathPickButton;
        private System.Windows.Forms.Label TypesValueLabel;
        private System.Windows.Forms.Label ImportedValueLabel;
        private System.Windows.Forms.Label CapturedValueLabel;
        private System.Windows.Forms.Label PacketCoultValueLabel;
        private System.Windows.Forms.Label TypesLabel;
        private System.Windows.Forms.Label ImportedLabel;
        private System.Windows.Forms.Label CapturedLabel;
        private System.Windows.Forms.OpenFileDialog ImportFileDialog;
        private System.Windows.Forms.FolderBrowserDialog PathDialog;
    }
}