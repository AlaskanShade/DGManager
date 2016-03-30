namespace DGManager
{
	partial class DownloadLatestTracksDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.DaysUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DaysUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// CanclButton
			// 
			this.CanclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanclButton.Location = new System.Drawing.Point(148, 57);
			this.CanclButton.Name = "CanclButton";
			this.CanclButton.Size = new System.Drawing.Size(75, 23);
			this.CanclButton.TabIndex = 6;
			this.CanclButton.Text = "Cancel";
			this.CanclButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(69, 57);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 5;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Download tracks created in the last";
			// 
			// DaysUpDown
			// 
			this.DaysUpDown.Location = new System.Drawing.Point(192, 17);
			this.DaysUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.DaysUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DaysUpDown.Name = "DaysUpDown";
			this.DaysUpDown.Size = new System.Drawing.Size(46, 20);
			this.DaysUpDown.TabIndex = 8;
			this.DaysUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(243, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "days";
			// 
			// DownloadLatestTracksDialog
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CanclButton;
			this.ClientSize = new System.Drawing.Size(292, 92);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DaysUpDown);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CanclButton);
			this.Controls.Add(this.OkButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DownloadLatestTracksDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Download Latest Tracks";
			((System.ComponentModel.ISupportInitialize)(this.DaysUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CanclButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown DaysUpDown;
		private System.Windows.Forms.Label label2;
	}
}