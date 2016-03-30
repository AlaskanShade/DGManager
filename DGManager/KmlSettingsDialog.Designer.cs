namespace DGManager
{
	partial class KmlSettingsDialog
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
			this.SavingKmlFilesGroupBox = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.KmlPhotoPathPrefixTextBox = new System.Windows.Forms.TextBox();
			this.KmlUsePhotoPathPrefixCheckBox = new System.Windows.Forms.CheckBox();
			this.SavingKmlFilesGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// CanclButton
			// 
			this.CanclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanclButton.Location = new System.Drawing.Point(187, 254);
			this.CanclButton.Name = "CanclButton";
			this.CanclButton.Size = new System.Drawing.Size(75, 23);
			this.CanclButton.TabIndex = 4;
			this.CanclButton.Text = "Cancel";
			this.CanclButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(108, 254);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 3;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// SavingKmlFilesGroupBox
			// 
			this.SavingKmlFilesGroupBox.Controls.Add(this.label7);
			this.SavingKmlFilesGroupBox.Controls.Add(this.label6);
			this.SavingKmlFilesGroupBox.Controls.Add(this.label5);
			this.SavingKmlFilesGroupBox.Controls.Add(this.label4);
			this.SavingKmlFilesGroupBox.Controls.Add(this.label3);
			this.SavingKmlFilesGroupBox.Controls.Add(this.label2);
			this.SavingKmlFilesGroupBox.Controls.Add(this.label1);
			this.SavingKmlFilesGroupBox.Controls.Add(this.KmlPhotoPathPrefixTextBox);
			this.SavingKmlFilesGroupBox.Controls.Add(this.KmlUsePhotoPathPrefixCheckBox);
			this.SavingKmlFilesGroupBox.Location = new System.Drawing.Point(12, 12);
			this.SavingKmlFilesGroupBox.Name = "SavingKmlFilesGroupBox";
			this.SavingKmlFilesGroupBox.Size = new System.Drawing.Size(350, 227);
			this.SavingKmlFilesGroupBox.TabIndex = 5;
			this.SavingKmlFilesGroupBox.TabStop = false;
			this.SavingKmlFilesGroupBox.Text = "Photo Paths";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(11, 142);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(333, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "You must include a backslash or forward slash at the end of the path!";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 115);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(121, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "This will be used like so:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(135, 115);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(181, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Specified path + image.jpg = full path";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 89);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(214, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "http://www.mysite.com/Photos/MyHoliday/";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(181, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Eg. \\\\MyServer\\Photos\\My Holiday\\";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(337, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "specify the path to their location and give the KML file to other people.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(307, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "If your photos are stored on a website or network share you can";
			// 
			// KmlPhotoPathPrefixTextBox
			// 
			this.KmlPhotoPathPrefixTextBox.Location = new System.Drawing.Point(27, 192);
			this.KmlPhotoPathPrefixTextBox.Name = "KmlPhotoPathPrefixTextBox";
			this.KmlPhotoPathPrefixTextBox.Size = new System.Drawing.Size(299, 20);
			this.KmlPhotoPathPrefixTextBox.TabIndex = 3;
			// 
			// KmlUsePhotoPathPrefixCheckBox
			// 
			this.KmlUsePhotoPathPrefixCheckBox.AutoSize = true;
			this.KmlUsePhotoPathPrefixCheckBox.Location = new System.Drawing.Point(10, 169);
			this.KmlUsePhotoPathPrefixCheckBox.Name = "KmlUsePhotoPathPrefixCheckBox";
			this.KmlUsePhotoPathPrefixCheckBox.Size = new System.Drawing.Size(115, 17);
			this.KmlUsePhotoPathPrefixCheckBox.TabIndex = 2;
			this.KmlUsePhotoPathPrefixCheckBox.Text = "Specify photo path";
			this.KmlUsePhotoPathPrefixCheckBox.UseVisualStyleBackColor = true;
			// 
			// KmlSettingsDialog
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CanclButton;
			this.ClientSize = new System.Drawing.Size(371, 290);
			this.Controls.Add(this.SavingKmlFilesGroupBox);
			this.Controls.Add(this.CanclButton);
			this.Controls.Add(this.OkButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "KmlSettingsDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "KML Settings";
			this.TopMost = true;
			this.SavingKmlFilesGroupBox.ResumeLayout(false);
			this.SavingKmlFilesGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CanclButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.GroupBox SavingKmlFilesGroupBox;
		private System.Windows.Forms.CheckBox KmlUsePhotoPathPrefixCheckBox;
		private System.Windows.Forms.TextBox KmlPhotoPathPrefixTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}