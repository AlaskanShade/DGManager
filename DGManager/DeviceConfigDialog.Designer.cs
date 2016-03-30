namespace DGManager
{
	partial class DeviceConfigDialog
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
			this.LoggingFormatGroupBox = new System.Windows.Forms.GroupBox();
			this.Type2RadioButton = new System.Windows.Forms.RadioButton();
			this.Type1RadioButton = new System.Windows.Forms.RadioButton();
			this.Type0RadioButton = new System.Windows.Forms.RadioButton();
			this.ModeAGroupBox = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ModeADistanceUpDown = new System.Windows.Forms.NumericUpDown();
			this.ModeATimeUpDown = new System.Windows.Forms.NumericUpDown();
			this.ModeADistanceRadioButton = new System.Windows.Forms.RadioButton();
			this.ModeATimeRadioButton = new System.Windows.Forms.RadioButton();
			this.ModeBGroupBox = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ModeBDistanceUpDown = new System.Windows.Forms.NumericUpDown();
			this.ModeBTimeUpDown = new System.Windows.Forms.NumericUpDown();
			this.ModeBDistanceRadioButton = new System.Windows.Forms.RadioButton();
			this.ModeBTimeRadioButton = new System.Windows.Forms.RadioButton();
			this.ModeCGroupBox = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.ModeCDistanceUpDown = new System.Windows.Forms.NumericUpDown();
			this.ModeCTimeUpDown = new System.Windows.Forms.NumericUpDown();
			this.ModeCDistanceRadioButton = new System.Windows.Forms.RadioButton();
			this.ModeCTimeRadioButton = new System.Windows.Forms.RadioButton();
			this.DontLogSpeedCheckBox = new System.Windows.Forms.CheckBox();
			this.DontLogSpeedUpDown = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.DontLogDistanceUpDown = new System.Windows.Forms.NumericUpDown();
			this.DontLogDistanceCheckBox = new System.Windows.Forms.CheckBox();
			this.MemoryProgressBar = new System.Windows.Forms.ProgressBar();
			this.label9 = new System.Windows.Forms.Label();
			this.CanclButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.MemoryLabel = new System.Windows.Forms.Label();
			this.LoggingFormatGroupBox.SuspendLayout();
			this.ModeAGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModeADistanceUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ModeATimeUpDown)).BeginInit();
			this.ModeBGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModeBDistanceUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ModeBTimeUpDown)).BeginInit();
			this.ModeCGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModeCDistanceUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ModeCTimeUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DontLogSpeedUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DontLogDistanceUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// LoggingFormatGroupBox
			// 
			this.LoggingFormatGroupBox.Controls.Add(this.Type2RadioButton);
			this.LoggingFormatGroupBox.Controls.Add(this.Type1RadioButton);
			this.LoggingFormatGroupBox.Controls.Add(this.Type0RadioButton);
			this.LoggingFormatGroupBox.Location = new System.Drawing.Point(12, 12);
			this.LoggingFormatGroupBox.Name = "LoggingFormatGroupBox";
			this.LoggingFormatGroupBox.Size = new System.Drawing.Size(231, 90);
			this.LoggingFormatGroupBox.TabIndex = 0;
			this.LoggingFormatGroupBox.TabStop = false;
			this.LoggingFormatGroupBox.Text = "Logging Format";
			// 
			// Type2RadioButton
			// 
			this.Type2RadioButton.AutoSize = true;
			this.Type2RadioButton.Location = new System.Drawing.Point(7, 65);
			this.Type2RadioButton.Name = "Type2RadioButton";
			this.Type2RadioButton.Size = new System.Drawing.Size(207, 17);
			this.Type2RadioButton.TabIndex = 2;
			this.Type2RadioButton.TabStop = true;
			this.Type2RadioButton.Text = "Position, time, date, speed and altitude";
			this.Type2RadioButton.UseVisualStyleBackColor = true;
			// 
			// Type1RadioButton
			// 
			this.Type1RadioButton.AutoSize = true;
			this.Type1RadioButton.Location = new System.Drawing.Point(7, 42);
			this.Type1RadioButton.Name = "Type1RadioButton";
			this.Type1RadioButton.Size = new System.Drawing.Size(167, 17);
			this.Type1RadioButton.TabIndex = 1;
			this.Type1RadioButton.TabStop = true;
			this.Type1RadioButton.Text = "Position, time, date and speed";
			this.Type1RadioButton.UseVisualStyleBackColor = true;
			// 
			// Type0RadioButton
			// 
			this.Type0RadioButton.AutoSize = true;
			this.Type0RadioButton.Location = new System.Drawing.Point(7, 19);
			this.Type0RadioButton.Name = "Type0RadioButton";
			this.Type0RadioButton.Size = new System.Drawing.Size(62, 17);
			this.Type0RadioButton.TabIndex = 0;
			this.Type0RadioButton.TabStop = true;
			this.Type0RadioButton.Text = "Position";
			this.Type0RadioButton.UseVisualStyleBackColor = true;
			// 
			// ModeAGroupBox
			// 
			this.ModeAGroupBox.Controls.Add(this.label2);
			this.ModeAGroupBox.Controls.Add(this.label1);
			this.ModeAGroupBox.Controls.Add(this.ModeADistanceUpDown);
			this.ModeAGroupBox.Controls.Add(this.ModeATimeUpDown);
			this.ModeAGroupBox.Controls.Add(this.ModeADistanceRadioButton);
			this.ModeAGroupBox.Controls.Add(this.ModeATimeRadioButton);
			this.ModeAGroupBox.Location = new System.Drawing.Point(256, 12);
			this.ModeAGroupBox.Name = "ModeAGroupBox";
			this.ModeAGroupBox.Size = new System.Drawing.Size(231, 70);
			this.ModeAGroupBox.TabIndex = 1;
			this.ModeAGroupBox.TabStop = false;
			this.ModeAGroupBox.Text = "Mode A";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(161, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "meters";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(161, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "seconds";
			// 
			// ModeADistanceUpDown
			// 
			this.ModeADistanceUpDown.Location = new System.Drawing.Point(98, 42);
			this.ModeADistanceUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.ModeADistanceUpDown.Name = "ModeADistanceUpDown";
			this.ModeADistanceUpDown.Size = new System.Drawing.Size(56, 20);
			this.ModeADistanceUpDown.TabIndex = 3;
			this.ModeADistanceUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ModeATimeUpDown
			// 
			this.ModeATimeUpDown.Location = new System.Drawing.Point(98, 19);
			this.ModeATimeUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.ModeATimeUpDown.Name = "ModeATimeUpDown";
			this.ModeATimeUpDown.Size = new System.Drawing.Size(56, 20);
			this.ModeATimeUpDown.TabIndex = 2;
			this.ModeATimeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ModeADistanceRadioButton
			// 
			this.ModeADistanceRadioButton.AutoSize = true;
			this.ModeADistanceRadioButton.Location = new System.Drawing.Point(6, 42);
			this.ModeADistanceRadioButton.Name = "ModeADistanceRadioButton";
			this.ModeADistanceRadioButton.Size = new System.Drawing.Size(86, 17);
			this.ModeADistanceRadioButton.TabIndex = 1;
			this.ModeADistanceRadioButton.TabStop = true;
			this.ModeADistanceRadioButton.Text = "By distance :";
			this.ModeADistanceRadioButton.UseVisualStyleBackColor = true;
			// 
			// ModeATimeRadioButton
			// 
			this.ModeATimeRadioButton.AutoSize = true;
			this.ModeATimeRadioButton.Location = new System.Drawing.Point(6, 19);
			this.ModeATimeRadioButton.Name = "ModeATimeRadioButton";
			this.ModeATimeRadioButton.Size = new System.Drawing.Size(65, 17);
			this.ModeATimeRadioButton.TabIndex = 0;
			this.ModeATimeRadioButton.TabStop = true;
			this.ModeATimeRadioButton.Text = "By time :";
			this.ModeATimeRadioButton.UseVisualStyleBackColor = true;
			// 
			// ModeBGroupBox
			// 
			this.ModeBGroupBox.Controls.Add(this.label3);
			this.ModeBGroupBox.Controls.Add(this.label4);
			this.ModeBGroupBox.Controls.Add(this.ModeBDistanceUpDown);
			this.ModeBGroupBox.Controls.Add(this.ModeBTimeUpDown);
			this.ModeBGroupBox.Controls.Add(this.ModeBDistanceRadioButton);
			this.ModeBGroupBox.Controls.Add(this.ModeBTimeRadioButton);
			this.ModeBGroupBox.Location = new System.Drawing.Point(256, 88);
			this.ModeBGroupBox.Name = "ModeBGroupBox";
			this.ModeBGroupBox.Size = new System.Drawing.Size(231, 70);
			this.ModeBGroupBox.TabIndex = 6;
			this.ModeBGroupBox.TabStop = false;
			this.ModeBGroupBox.Text = "Mode B";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(161, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "meters";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(161, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "seconds";
			// 
			// ModeBDistanceUpDown
			// 
			this.ModeBDistanceUpDown.Location = new System.Drawing.Point(98, 42);
			this.ModeBDistanceUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.ModeBDistanceUpDown.Name = "ModeBDistanceUpDown";
			this.ModeBDistanceUpDown.Size = new System.Drawing.Size(56, 20);
			this.ModeBDistanceUpDown.TabIndex = 3;
			this.ModeBDistanceUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ModeBTimeUpDown
			// 
			this.ModeBTimeUpDown.Location = new System.Drawing.Point(98, 19);
			this.ModeBTimeUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.ModeBTimeUpDown.Name = "ModeBTimeUpDown";
			this.ModeBTimeUpDown.Size = new System.Drawing.Size(56, 20);
			this.ModeBTimeUpDown.TabIndex = 2;
			this.ModeBTimeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ModeBDistanceRadioButton
			// 
			this.ModeBDistanceRadioButton.AutoSize = true;
			this.ModeBDistanceRadioButton.Location = new System.Drawing.Point(6, 42);
			this.ModeBDistanceRadioButton.Name = "ModeBDistanceRadioButton";
			this.ModeBDistanceRadioButton.Size = new System.Drawing.Size(86, 17);
			this.ModeBDistanceRadioButton.TabIndex = 1;
			this.ModeBDistanceRadioButton.TabStop = true;
			this.ModeBDistanceRadioButton.Text = "By distance :";
			this.ModeBDistanceRadioButton.UseVisualStyleBackColor = true;
			// 
			// ModeBTimeRadioButton
			// 
			this.ModeBTimeRadioButton.AutoSize = true;
			this.ModeBTimeRadioButton.Location = new System.Drawing.Point(6, 19);
			this.ModeBTimeRadioButton.Name = "ModeBTimeRadioButton";
			this.ModeBTimeRadioButton.Size = new System.Drawing.Size(65, 17);
			this.ModeBTimeRadioButton.TabIndex = 0;
			this.ModeBTimeRadioButton.TabStop = true;
			this.ModeBTimeRadioButton.Text = "By time :";
			this.ModeBTimeRadioButton.UseVisualStyleBackColor = true;
			// 
			// ModeCGroupBox
			// 
			this.ModeCGroupBox.Controls.Add(this.label5);
			this.ModeCGroupBox.Controls.Add(this.label6);
			this.ModeCGroupBox.Controls.Add(this.ModeCDistanceUpDown);
			this.ModeCGroupBox.Controls.Add(this.ModeCTimeUpDown);
			this.ModeCGroupBox.Controls.Add(this.ModeCDistanceRadioButton);
			this.ModeCGroupBox.Controls.Add(this.ModeCTimeRadioButton);
			this.ModeCGroupBox.Location = new System.Drawing.Point(256, 164);
			this.ModeCGroupBox.Name = "ModeCGroupBox";
			this.ModeCGroupBox.Size = new System.Drawing.Size(231, 70);
			this.ModeCGroupBox.TabIndex = 7;
			this.ModeCGroupBox.TabStop = false;
			this.ModeCGroupBox.Text = "Mode C";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(161, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "meters";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(161, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "seconds";
			// 
			// ModeCDistanceUpDown
			// 
			this.ModeCDistanceUpDown.Location = new System.Drawing.Point(98, 42);
			this.ModeCDistanceUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.ModeCDistanceUpDown.Name = "ModeCDistanceUpDown";
			this.ModeCDistanceUpDown.Size = new System.Drawing.Size(56, 20);
			this.ModeCDistanceUpDown.TabIndex = 3;
			this.ModeCDistanceUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ModeCTimeUpDown
			// 
			this.ModeCTimeUpDown.Location = new System.Drawing.Point(98, 19);
			this.ModeCTimeUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.ModeCTimeUpDown.Name = "ModeCTimeUpDown";
			this.ModeCTimeUpDown.Size = new System.Drawing.Size(56, 20);
			this.ModeCTimeUpDown.TabIndex = 2;
			this.ModeCTimeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ModeCDistanceRadioButton
			// 
			this.ModeCDistanceRadioButton.AutoSize = true;
			this.ModeCDistanceRadioButton.Location = new System.Drawing.Point(6, 42);
			this.ModeCDistanceRadioButton.Name = "ModeCDistanceRadioButton";
			this.ModeCDistanceRadioButton.Size = new System.Drawing.Size(86, 17);
			this.ModeCDistanceRadioButton.TabIndex = 1;
			this.ModeCDistanceRadioButton.TabStop = true;
			this.ModeCDistanceRadioButton.Text = "By distance :";
			this.ModeCDistanceRadioButton.UseVisualStyleBackColor = true;
			// 
			// ModeCTimeRadioButton
			// 
			this.ModeCTimeRadioButton.AutoSize = true;
			this.ModeCTimeRadioButton.Location = new System.Drawing.Point(6, 19);
			this.ModeCTimeRadioButton.Name = "ModeCTimeRadioButton";
			this.ModeCTimeRadioButton.Size = new System.Drawing.Size(65, 17);
			this.ModeCTimeRadioButton.TabIndex = 0;
			this.ModeCTimeRadioButton.TabStop = true;
			this.ModeCTimeRadioButton.Text = "By time :";
			this.ModeCTimeRadioButton.UseVisualStyleBackColor = true;
			// 
			// DontLogSpeedCheckBox
			// 
			this.DontLogSpeedCheckBox.AutoSize = true;
			this.DontLogSpeedCheckBox.Location = new System.Drawing.Point(19, 129);
			this.DontLogSpeedCheckBox.Name = "DontLogSpeedCheckBox";
			this.DontLogSpeedCheckBox.Size = new System.Drawing.Size(193, 17);
			this.DontLogSpeedCheckBox.TabIndex = 8;
			this.DontLogSpeedCheckBox.Text = "Don\'t log data if speed is less than :";
			this.DontLogSpeedCheckBox.UseVisualStyleBackColor = true;
			// 
			// DontLogSpeedUpDown
			// 
			this.DontLogSpeedUpDown.Location = new System.Drawing.Point(37, 152);
			this.DontLogSpeedUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.DontLogSpeedUpDown.Name = "DontLogSpeedUpDown";
			this.DontLogSpeedUpDown.Size = new System.Drawing.Size(63, 20);
			this.DontLogSpeedUpDown.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(106, 156);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "km/h";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(106, 210);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "meters";
			// 
			// DontLogDistanceUpDown
			// 
			this.DontLogDistanceUpDown.Location = new System.Drawing.Point(37, 206);
			this.DontLogDistanceUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.DontLogDistanceUpDown.Name = "DontLogDistanceUpDown";
			this.DontLogDistanceUpDown.Size = new System.Drawing.Size(63, 20);
			this.DontLogDistanceUpDown.TabIndex = 12;
			// 
			// DontLogDistanceCheckBox
			// 
			this.DontLogDistanceCheckBox.AutoSize = true;
			this.DontLogDistanceCheckBox.Location = new System.Drawing.Point(19, 183);
			this.DontLogDistanceCheckBox.Name = "DontLogDistanceCheckBox";
			this.DontLogDistanceCheckBox.Size = new System.Drawing.Size(204, 17);
			this.DontLogDistanceCheckBox.TabIndex = 11;
			this.DontLogDistanceCheckBox.Text = "Don\'t log data if distance is less than :";
			this.DontLogDistanceCheckBox.UseVisualStyleBackColor = true;
			// 
			// MemoryProgressBar
			// 
			this.MemoryProgressBar.Location = new System.Drawing.Point(129, 267);
			this.MemoryProgressBar.Name = "MemoryProgressBar";
			this.MemoryProgressBar.Size = new System.Drawing.Size(114, 23);
			this.MemoryProgressBar.Step = 1;
			this.MemoryProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.MemoryProgressBar.TabIndex = 14;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 272);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(82, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "Memory usage :";
			// 
			// CanclButton
			// 
			this.CanclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanclButton.Location = new System.Drawing.Point(372, 267);
			this.CanclButton.Name = "CanclButton";
			this.CanclButton.Size = new System.Drawing.Size(75, 23);
			this.CanclButton.TabIndex = 17;
			this.CanclButton.Text = "Cancel";
			this.CanclButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(291, 267);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 16;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// MemoryLabel
			// 
			this.MemoryLabel.AutoSize = true;
			this.MemoryLabel.Location = new System.Drawing.Point(96, 272);
			this.MemoryLabel.Name = "MemoryLabel";
			this.MemoryLabel.Size = new System.Drawing.Size(33, 13);
			this.MemoryLabel.TabIndex = 18;
			this.MemoryLabel.Text = "100%";
			// 
			// DeviceConfigDialog
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CanclButton;
			this.ClientSize = new System.Drawing.Size(498, 302);
			this.Controls.Add(this.MemoryLabel);
			this.Controls.Add(this.CanclButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.MemoryProgressBar);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.DontLogDistanceUpDown);
			this.Controls.Add(this.DontLogDistanceCheckBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.DontLogSpeedUpDown);
			this.Controls.Add(this.DontLogSpeedCheckBox);
			this.Controls.Add(this.ModeCGroupBox);
			this.Controls.Add(this.ModeBGroupBox);
			this.Controls.Add(this.ModeAGroupBox);
			this.Controls.Add(this.LoggingFormatGroupBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeviceConfigDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DG-100 Configuration";
			this.TopMost = true;
			this.LoggingFormatGroupBox.ResumeLayout(false);
			this.LoggingFormatGroupBox.PerformLayout();
			this.ModeAGroupBox.ResumeLayout(false);
			this.ModeAGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModeADistanceUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ModeATimeUpDown)).EndInit();
			this.ModeBGroupBox.ResumeLayout(false);
			this.ModeBGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModeBDistanceUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ModeBTimeUpDown)).EndInit();
			this.ModeCGroupBox.ResumeLayout(false);
			this.ModeCGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModeCDistanceUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ModeCTimeUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DontLogSpeedUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DontLogDistanceUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox LoggingFormatGroupBox;
		private System.Windows.Forms.GroupBox ModeAGroupBox;
		private System.Windows.Forms.NumericUpDown ModeADistanceUpDown;
		private System.Windows.Forms.NumericUpDown ModeATimeUpDown;
		private System.Windows.Forms.RadioButton ModeADistanceRadioButton;
		private System.Windows.Forms.RadioButton ModeATimeRadioButton;
		private System.Windows.Forms.RadioButton Type1RadioButton;
		private System.Windows.Forms.RadioButton Type0RadioButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton Type2RadioButton;
		private System.Windows.Forms.GroupBox ModeBGroupBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown ModeBDistanceUpDown;
		private System.Windows.Forms.NumericUpDown ModeBTimeUpDown;
		private System.Windows.Forms.RadioButton ModeBDistanceRadioButton;
		private System.Windows.Forms.RadioButton ModeBTimeRadioButton;
		private System.Windows.Forms.GroupBox ModeCGroupBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown ModeCDistanceUpDown;
		private System.Windows.Forms.NumericUpDown ModeCTimeUpDown;
		private System.Windows.Forms.RadioButton ModeCDistanceRadioButton;
		private System.Windows.Forms.RadioButton ModeCTimeRadioButton;
		private System.Windows.Forms.CheckBox DontLogSpeedCheckBox;
		private System.Windows.Forms.NumericUpDown DontLogSpeedUpDown;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown DontLogDistanceUpDown;
		private System.Windows.Forms.CheckBox DontLogDistanceCheckBox;
		private System.Windows.Forms.ProgressBar MemoryProgressBar;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button CanclButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label MemoryLabel;
	}
}