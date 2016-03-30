namespace DGManager
{
	partial class SetCameraOffsetDialog
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
			this.CanclButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.OpenPhotoDialog = new System.Windows.Forms.OpenFileDialog();
			this.PhotoGroupBox = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.PhotoTakenAtLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PhotoPictureBox = new System.Windows.Forms.PictureBox();
			this.OpenPhotoButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.PhotoFilePathTextBox = new System.Windows.Forms.TextBox();
			this.GpsGroupBox = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.GpsDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.ManualPointsListBox = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.EnterTimeRadioButton = new System.Windows.Forms.RadioButton();
			this.ManualPointRadioButton = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.OffsetLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.PhotoGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PhotoPictureBox)).BeginInit();
			this.GpsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// CanclButton
			// 
			this.CanclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanclButton.Location = new System.Drawing.Point(321, 491);
			this.CanclButton.Name = "CanclButton";
			this.CanclButton.Size = new System.Drawing.Size(75, 23);
			this.CanclButton.TabIndex = 4;
			this.CanclButton.Text = "Cancel";
			this.CanclButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(242, 491);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 3;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// OpenPhotoDialog
			// 
			this.OpenPhotoDialog.Filter = "JPEG Images (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif";
			// 
			// PhotoGroupBox
			// 
			this.PhotoGroupBox.Controls.Add(this.label8);
			this.PhotoGroupBox.Controls.Add(this.label7);
			this.PhotoGroupBox.Controls.Add(this.label6);
			this.PhotoGroupBox.Controls.Add(this.PhotoTakenAtLabel);
			this.PhotoGroupBox.Controls.Add(this.label2);
			this.PhotoGroupBox.Controls.Add(this.PhotoPictureBox);
			this.PhotoGroupBox.Controls.Add(this.OpenPhotoButton);
			this.PhotoGroupBox.Controls.Add(this.label1);
			this.PhotoGroupBox.Controls.Add(this.PhotoFilePathTextBox);
			this.PhotoGroupBox.Location = new System.Drawing.Point(12, 35);
			this.PhotoGroupBox.Name = "PhotoGroupBox";
			this.PhotoGroupBox.Size = new System.Drawing.Size(369, 415);
			this.PhotoGroupBox.TabIndex = 5;
			this.PhotoGroupBox.TabStop = false;
			this.PhotoGroupBox.Text = "Photo";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 53);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(242, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "the current time (including seconds) clearly visible.";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(346, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "was created, or a photo taken of a GPS device or computer screen with";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(358, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Select a photo taken of the DG-100 at the exact time when a manual point";
			// 
			// PhotoTakenAtLabel
			// 
			this.PhotoTakenAtLabel.AutoSize = true;
			this.PhotoTakenAtLabel.Location = new System.Drawing.Point(62, 117);
			this.PhotoTakenAtLabel.Name = "PhotoTakenAtLabel";
			this.PhotoTakenAtLabel.Size = new System.Drawing.Size(0, 13);
			this.PhotoTakenAtLabel.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 117);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Taken at:";
			// 
			// PhotoPictureBox
			// 
			this.PhotoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PhotoPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.PhotoPictureBox.Location = new System.Drawing.Point(9, 144);
			this.PhotoPictureBox.Name = "PhotoPictureBox";
			this.PhotoPictureBox.Size = new System.Drawing.Size(350, 262);
			this.PhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PhotoPictureBox.TabIndex = 3;
			this.PhotoPictureBox.TabStop = false;
			this.PhotoPictureBox.Click += new System.EventHandler(this.PhotoPictureBox_Click);
			// 
			// OpenPhotoButton
			// 
			this.OpenPhotoButton.Location = new System.Drawing.Point(301, 79);
			this.OpenPhotoButton.Name = "OpenPhotoButton";
			this.OpenPhotoButton.Size = new System.Drawing.Size(58, 23);
			this.OpenPhotoButton.TabIndex = 2;
			this.OpenPhotoButton.Text = "Browse";
			this.OpenPhotoButton.UseVisualStyleBackColor = true;
			this.OpenPhotoButton.Click += new System.EventHandler(this.OpenPhotoButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 84);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "File:";
			// 
			// PhotoFilePathTextBox
			// 
			this.PhotoFilePathTextBox.BackColor = System.Drawing.Color.White;
			this.PhotoFilePathTextBox.Location = new System.Drawing.Point(38, 81);
			this.PhotoFilePathTextBox.Name = "PhotoFilePathTextBox";
			this.PhotoFilePathTextBox.ReadOnly = true;
			this.PhotoFilePathTextBox.Size = new System.Drawing.Size(257, 20);
			this.PhotoFilePathTextBox.TabIndex = 0;
			// 
			// GpsGroupBox
			// 
			this.GpsGroupBox.Controls.Add(this.label5);
			this.GpsGroupBox.Controls.Add(this.GpsDateTimePicker);
			this.GpsGroupBox.Controls.Add(this.ManualPointsListBox);
			this.GpsGroupBox.Controls.Add(this.label4);
			this.GpsGroupBox.Controls.Add(this.EnterTimeRadioButton);
			this.GpsGroupBox.Controls.Add(this.ManualPointRadioButton);
			this.GpsGroupBox.Location = new System.Drawing.Point(387, 35);
			this.GpsGroupBox.Name = "GpsGroupBox";
			this.GpsGroupBox.Size = new System.Drawing.Size(238, 415);
			this.GpsGroupBox.TabIndex = 6;
			this.GpsGroupBox.TabStop = false;
			this.GpsGroupBox.Text = "GPS";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(84, 297);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "(local time)";
			// 
			// GpsDateTimePicker
			// 
			this.GpsDateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
			this.GpsDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.GpsDateTimePicker.Location = new System.Drawing.Point(35, 274);
			this.GpsDateTimePicker.Name = "GpsDateTimePicker";
			this.GpsDateTimePicker.ShowUpDown = true;
			this.GpsDateTimePicker.Size = new System.Drawing.Size(154, 20);
			this.GpsDateTimePicker.TabIndex = 9;
			this.GpsDateTimePicker.Value = new System.DateTime(2000, 1, 1, 12, 0, 0, 0);
			this.GpsDateTimePicker.ValueChanged += new System.EventHandler(this.UpdateOffset);
			// 
			// ManualPointsListBox
			// 
			this.ManualPointsListBox.FormattingEnabled = true;
			this.ManualPointsListBox.Location = new System.Drawing.Point(35, 46);
			this.ManualPointsListBox.Name = "ManualPointsListBox";
			this.ManualPointsListBox.Size = new System.Drawing.Size(154, 134);
			this.ManualPointsListBox.TabIndex = 6;
			this.ManualPointsListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateOffset);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(14, 203);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(25, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "OR";
			// 
			// EnterTimeRadioButton
			// 
			this.EnterTimeRadioButton.AutoSize = true;
			this.EnterTimeRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EnterTimeRadioButton.Location = new System.Drawing.Point(17, 240);
			this.EnterTimeRadioButton.Name = "EnterTimeRadioButton";
			this.EnterTimeRadioButton.Size = new System.Drawing.Size(213, 17);
			this.EnterTimeRadioButton.TabIndex = 1;
			this.EnterTimeRadioButton.Text = "Enter the time shown on the GPS";
			this.EnterTimeRadioButton.UseVisualStyleBackColor = true;
			this.EnterTimeRadioButton.CheckedChanged += new System.EventHandler(this.UpdateOffset);
			// 
			// ManualPointRadioButton
			// 
			this.ManualPointRadioButton.AutoSize = true;
			this.ManualPointRadioButton.Checked = true;
			this.ManualPointRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ManualPointRadioButton.Location = new System.Drawing.Point(17, 23);
			this.ManualPointRadioButton.Name = "ManualPointRadioButton";
			this.ManualPointRadioButton.Size = new System.Drawing.Size(154, 17);
			this.ManualPointRadioButton.TabIndex = 0;
			this.ManualPointRadioButton.TabStop = true;
			this.ManualPointRadioButton.Text = "Choose a manual point";
			this.ManualPointRadioButton.UseVisualStyleBackColor = true;
			this.ManualPointRadioButton.CheckedChanged += new System.EventHandler(this.UpdateOffset);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(193, 459);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 25);
			this.label3.TabIndex = 7;
			this.label3.Text = "Calculated Offset:";
			// 
			// OffsetLabel
			// 
			this.OffsetLabel.AutoSize = true;
			this.OffsetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OffsetLabel.Location = new System.Drawing.Point(355, 459);
			this.OffsetLabel.Name = "OffsetLabel";
			this.OffsetLabel.Size = new System.Drawing.Size(90, 25);
			this.OffsetLabel.TabIndex = 8;
			this.OffsetLabel.Text = "00:00:00";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(16, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(55, 17);
			this.label9.TabIndex = 9;
			this.label9.Text = "Step 1";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(391, 9);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(55, 17);
			this.label10.TabIndex = 10;
			this.label10.Text = "Step 2";
			// 
			// SetCameraOffsetDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(638, 521);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.OffsetLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.GpsGroupBox);
			this.Controls.Add(this.PhotoGroupBox);
			this.Controls.Add(this.CanclButton);
			this.Controls.Add(this.OkButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SetCameraOffsetDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Camera Time Offset Helper";
			this.Shown += new System.EventHandler(this.SetCameraOffsetDialog_Shown);
			this.PhotoGroupBox.ResumeLayout(false);
			this.PhotoGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PhotoPictureBox)).EndInit();
			this.GpsGroupBox.ResumeLayout(false);
			this.GpsGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CanclButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.OpenFileDialog OpenPhotoDialog;
		private System.Windows.Forms.GroupBox PhotoGroupBox;
		private System.Windows.Forms.Button OpenPhotoButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PhotoFilePathTextBox;
		private System.Windows.Forms.GroupBox GpsGroupBox;
		private System.Windows.Forms.Label PhotoTakenAtLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox PhotoPictureBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label OffsetLabel;
		private System.Windows.Forms.RadioButton EnterTimeRadioButton;
		private System.Windows.Forms.RadioButton ManualPointRadioButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox ManualPointsListBox;
		private System.Windows.Forms.DateTimePicker GpsDateTimePicker;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
	}
}