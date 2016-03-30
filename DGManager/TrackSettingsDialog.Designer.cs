namespace DGManager
{
	partial class TrackSettingsDialog
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
            this.TrackGenerationGroupBox = new System.Windows.Forms.GroupBox();
            this.ApplyTrackModeWhenLoadingGSDCheckBox = new System.Windows.Forms.CheckBox();
            this.LogicalPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TrackThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.LogicalRadioButton = new System.Windows.Forms.RadioButton();
            this.GlobalSatRadioButton = new System.Windows.Forms.RadioButton();
            this.CanclButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.MiscGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GuessManualPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTimeFormat = new System.Windows.Forms.ComboBox();
            this.txtTimeFormat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TrackGenerationGroupBox.SuspendLayout();
            this.LogicalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackThresholdUpDown)).BeginInit();
            this.MiscGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrackGenerationGroupBox
            // 
            this.TrackGenerationGroupBox.Controls.Add(this.ApplyTrackModeWhenLoadingGSDCheckBox);
            this.TrackGenerationGroupBox.Controls.Add(this.LogicalPanel);
            this.TrackGenerationGroupBox.Controls.Add(this.LogicalRadioButton);
            this.TrackGenerationGroupBox.Controls.Add(this.GlobalSatRadioButton);
            this.TrackGenerationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.TrackGenerationGroupBox.Name = "TrackGenerationGroupBox";
            this.TrackGenerationGroupBox.Size = new System.Drawing.Size(315, 156);
            this.TrackGenerationGroupBox.TabIndex = 0;
            this.TrackGenerationGroupBox.TabStop = false;
            this.TrackGenerationGroupBox.Text = "Track Generation";
            // 
            // ApplyTrackModeWhenLoadingGSDCheckBox
            // 
            this.ApplyTrackModeWhenLoadingGSDCheckBox.AutoSize = true;
            this.ApplyTrackModeWhenLoadingGSDCheckBox.Location = new System.Drawing.Point(15, 130);
            this.ApplyTrackModeWhenLoadingGSDCheckBox.Name = "ApplyTrackModeWhenLoadingGSDCheckBox";
            this.ApplyTrackModeWhenLoadingGSDCheckBox.Size = new System.Drawing.Size(199, 17);
            this.ApplyTrackModeWhenLoadingGSDCheckBox.TabIndex = 7;
            this.ApplyTrackModeWhenLoadingGSDCheckBox.Text = "Also apply when loading existing files";
            this.ApplyTrackModeWhenLoadingGSDCheckBox.UseVisualStyleBackColor = true;
            // 
            // LogicalPanel
            // 
            this.LogicalPanel.Controls.Add(this.label2);
            this.LogicalPanel.Controls.Add(this.label3);
            this.LogicalPanel.Controls.Add(this.TrackThresholdUpDown);
            this.LogicalPanel.Controls.Add(this.label1);
            this.LogicalPanel.Location = new System.Drawing.Point(33, 72);
            this.LogicalPanel.Name = "LogicalPanel";
            this.LogicalPanel.Size = new System.Drawing.Size(263, 44);
            this.LogicalPanel.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "is more than";
            // 
            // TrackThresholdUpDown
            // 
            this.TrackThresholdUpDown.Location = new System.Drawing.Point(72, 21);
            this.TrackThresholdUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.TrackThresholdUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TrackThresholdUpDown.Name = "TrackThresholdUpDown";
            this.TrackThresholdUpDown.Size = new System.Drawing.Size(39, 20);
            this.TrackThresholdUpDown.TabIndex = 2;
            this.TrackThresholdUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start a new track if the time gap between two points";
            // 
            // LogicalRadioButton
            // 
            this.LogicalRadioButton.AutoSize = true;
            this.LogicalRadioButton.Location = new System.Drawing.Point(15, 52);
            this.LogicalRadioButton.Name = "LogicalRadioButton";
            this.LogicalRadioButton.Size = new System.Drawing.Size(268, 17);
            this.LogicalRadioButton.TabIndex = 1;
            this.LogicalRadioButton.TabStop = true;
            this.LogicalRadioButton.Text = "Smart track generation - group points based on time";
            this.LogicalRadioButton.UseVisualStyleBackColor = true;
            this.LogicalRadioButton.CheckedChanged += new System.EventHandler(this.LogicalRadioButton_CheckedChanged);
            // 
            // GlobalSatRadioButton
            // 
            this.GlobalSatRadioButton.AutoSize = true;
            this.GlobalSatRadioButton.Location = new System.Drawing.Point(15, 28);
            this.GlobalSatRadioButton.Name = "GlobalSatRadioButton";
            this.GlobalSatRadioButton.Size = new System.Drawing.Size(182, 17);
            this.GlobalSatRadioButton.TabIndex = 0;
            this.GlobalSatRadioButton.TabStop = true;
            this.GlobalSatRadioButton.Text = "Leave existing tracks unchanged";
            this.GlobalSatRadioButton.UseVisualStyleBackColor = true;
            this.GlobalSatRadioButton.CheckedChanged += new System.EventHandler(this.GlobalSatRadioButton_CheckedChanged);
            // 
            // CanclButton
            // 
            this.CanclButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CanclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CanclButton.Location = new System.Drawing.Point(172, 323);
            this.CanclButton.Name = "CanclButton";
            this.CanclButton.Size = new System.Drawing.Size(75, 23);
            this.CanclButton.TabIndex = 4;
            this.CanclButton.Text = "Cancel";
            this.CanclButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OkButton.Location = new System.Drawing.Point(91, 323);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MiscGroupBox
            // 
            this.MiscGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.MiscGroupBox.Controls.Add(this.label7);
            this.MiscGroupBox.Controls.Add(this.txtTimeFormat);
            this.MiscGroupBox.Controls.Add(this.cmbTimeFormat);
            this.MiscGroupBox.Controls.Add(this.label6);
            this.MiscGroupBox.Controls.Add(this.label5);
            this.MiscGroupBox.Controls.Add(this.label4);
            this.MiscGroupBox.Controls.Add(this.GuessManualPointsCheckBox);
            this.MiscGroupBox.Location = new System.Drawing.Point(12, 179);
            this.MiscGroupBox.Name = "MiscGroupBox";
            this.MiscGroupBox.Size = new System.Drawing.Size(315, 134);
            this.MiscGroupBox.TabIndex = 5;
            this.MiscGroupBox.TabStop = false;
            this.MiscGroupBox.Text = "Misc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "(only works when the DG-100 is set to time interval mode)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "button on the DG-100.";
            // 
            // GuessManualPointsCheckBox
            // 
            this.GuessManualPointsCheckBox.AutoSize = true;
            this.GuessManualPointsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.GuessManualPointsCheckBox.Name = "GuessManualPointsCheckBox";
            this.GuessManualPointsCheckBox.Size = new System.Drawing.Size(285, 17);
            this.GuessManualPointsCheckBox.TabIndex = 0;
            this.GuessManualPointsCheckBox.Text = "Try to guess which points were created by pressing the";
            this.GuessManualPointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Time Format:";
            // 
            // cmbTimeFormat
            // 
            this.cmbTimeFormat.FormattingEnabled = true;
            this.cmbTimeFormat.Items.AddRange(new object[] {
            "24-Hour",
            "24-Hour w/seconds",
            "12-Hour",
            "12-Hour w/seconds",
            "Custom..."});
            this.cmbTimeFormat.Location = new System.Drawing.Point(72, 78);
            this.cmbTimeFormat.Name = "cmbTimeFormat";
            this.cmbTimeFormat.Size = new System.Drawing.Size(121, 21);
            this.cmbTimeFormat.TabIndex = 4;
            this.cmbTimeFormat.SelectedIndexChanged += new System.EventHandler(this.cmbTimeFormat_SelectedIndexChanged);
            // 
            // txtTimeFormat
            // 
            this.txtTimeFormat.Location = new System.Drawing.Point(72, 106);
            this.txtTimeFormat.Name = "txtTimeFormat";
            this.txtTimeFormat.Size = new System.Drawing.Size(121, 20);
            this.txtTimeFormat.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Custom:";
            // 
            // TrackSettingsDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CanclButton;
            this.ClientSize = new System.Drawing.Size(338, 358);
            this.Controls.Add(this.MiscGroupBox);
            this.Controls.Add(this.CanclButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TrackGenerationGroupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrackSettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Track Settings";
            this.TopMost = true;
            this.TrackGenerationGroupBox.ResumeLayout(false);
            this.TrackGenerationGroupBox.PerformLayout();
            this.LogicalPanel.ResumeLayout(false);
            this.LogicalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackThresholdUpDown)).EndInit();
            this.MiscGroupBox.ResumeLayout(false);
            this.MiscGroupBox.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox TrackGenerationGroupBox;
		private System.Windows.Forms.RadioButton LogicalRadioButton;
		private System.Windows.Forms.RadioButton GlobalSatRadioButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown TrackThresholdUpDown;
		private System.Windows.Forms.Panel LogicalPanel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button CanclButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.CheckBox ApplyTrackModeWhenLoadingGSDCheckBox;
		private System.Windows.Forms.GroupBox MiscGroupBox;
		private System.Windows.Forms.CheckBox GuessManualPointsCheckBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTimeFormat;
        private System.Windows.Forms.ComboBox cmbTimeFormat;
	}
}