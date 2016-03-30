namespace DGManager
{
	partial class UtcSettingsDialog
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
			this.MainGroupBox = new System.Windows.Forms.GroupBox();
			this.HoursLabel = new System.Windows.Forms.Label();
			this.HoursUpDown = new System.Windows.Forms.NumericUpDown();
			this.AutoRadioButton = new System.Windows.Forms.RadioButton();
			this.FixedRadioButton = new System.Windows.Forms.RadioButton();
			this.NoneRadioButton = new System.Windows.Forms.RadioButton();
			this.OkButton = new System.Windows.Forms.Button();
			this.CanclButton = new System.Windows.Forms.Button();
			this.MainGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.HoursUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// MainGroupBox
			// 
			this.MainGroupBox.Controls.Add(this.HoursLabel);
			this.MainGroupBox.Controls.Add(this.HoursUpDown);
			this.MainGroupBox.Controls.Add(this.AutoRadioButton);
			this.MainGroupBox.Controls.Add(this.FixedRadioButton);
			this.MainGroupBox.Controls.Add(this.NoneRadioButton);
			this.MainGroupBox.Location = new System.Drawing.Point(13, 12);
			this.MainGroupBox.Name = "MainGroupBox";
			this.MainGroupBox.Size = new System.Drawing.Size(218, 128);
			this.MainGroupBox.TabIndex = 0;
			this.MainGroupBox.TabStop = false;
			this.MainGroupBox.Text = "UTC Shift";
			// 
			// HoursLabel
			// 
			this.HoursLabel.AutoSize = true;
			this.HoursLabel.Location = new System.Drawing.Point(145, 62);
			this.HoursLabel.Name = "HoursLabel";
			this.HoursLabel.Size = new System.Drawing.Size(35, 13);
			this.HoursLabel.TabIndex = 4;
			this.HoursLabel.Text = "Hours";
			// 
			// HoursUpDown
			// 
			this.HoursUpDown.Location = new System.Drawing.Point(80, 59);
			this.HoursUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.HoursUpDown.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147483648});
			this.HoursUpDown.Name = "HoursUpDown";
			this.HoursUpDown.Size = new System.Drawing.Size(59, 20);
			this.HoursUpDown.TabIndex = 3;
			// 
			// AutoRadioButton
			// 
			this.AutoRadioButton.AutoSize = true;
			this.AutoRadioButton.Location = new System.Drawing.Point(16, 93);
			this.AutoRadioButton.Name = "AutoRadioButton";
			this.AutoRadioButton.Size = new System.Drawing.Size(47, 17);
			this.AutoRadioButton.TabIndex = 2;
			this.AutoRadioButton.TabStop = true;
			this.AutoRadioButton.Text = "Auto";
			this.AutoRadioButton.UseVisualStyleBackColor = true;
			// 
			// FixedRadioButton
			// 
			this.FixedRadioButton.AutoSize = true;
			this.FixedRadioButton.Location = new System.Drawing.Point(16, 60);
			this.FixedRadioButton.Name = "FixedRadioButton";
			this.FixedRadioButton.Size = new System.Drawing.Size(53, 17);
			this.FixedRadioButton.TabIndex = 1;
			this.FixedRadioButton.TabStop = true;
			this.FixedRadioButton.Text = "Fixed:";
			this.FixedRadioButton.UseVisualStyleBackColor = true;
			// 
			// NoneRadioButton
			// 
			this.NoneRadioButton.AutoSize = true;
			this.NoneRadioButton.Location = new System.Drawing.Point(16, 28);
			this.NoneRadioButton.Name = "NoneRadioButton";
			this.NoneRadioButton.Size = new System.Drawing.Size(51, 17);
			this.NoneRadioButton.TabIndex = 0;
			this.NoneRadioButton.TabStop = true;
			this.NoneRadioButton.Text = "None";
			this.NoneRadioButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(44, 162);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 1;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// CanclButton
			// 
			this.CanclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanclButton.Location = new System.Drawing.Point(125, 162);
			this.CanclButton.Name = "CanclButton";
			this.CanclButton.Size = new System.Drawing.Size(75, 23);
			this.CanclButton.TabIndex = 2;
			this.CanclButton.Text = "Cancel";
			this.CanclButton.UseVisualStyleBackColor = true;
			// 
			// UtcSettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(244, 195);
			this.Controls.Add(this.CanclButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.MainGroupBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UtcSettingsDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UTC Shift";
			this.TopMost = true;
			this.MainGroupBox.ResumeLayout(false);
			this.MainGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.HoursUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox MainGroupBox;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CanclButton;
		private System.Windows.Forms.NumericUpDown HoursUpDown;
		private System.Windows.Forms.RadioButton AutoRadioButton;
		private System.Windows.Forms.RadioButton FixedRadioButton;
		private System.Windows.Forms.RadioButton NoneRadioButton;
		private System.Windows.Forms.Label HoursLabel;
	}
}