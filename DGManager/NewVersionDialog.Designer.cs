namespace DGManager
{
	partial class NewVersionDialog
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
			this.CloseButton = new System.Windows.Forms.Button();
			this.VersionAvailableLabel = new System.Windows.Forms.Label();
			this.DownloadLinkLabel = new System.Windows.Forms.LinkLabel();
			this.ReleaseNotesLinkLabel = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// CloseButton
			// 
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Location = new System.Drawing.Point(77, 103);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 5;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			// 
			// VersionAvailableLabel
			// 
			this.VersionAvailableLabel.AutoSize = true;
			this.VersionAvailableLabel.Location = new System.Drawing.Point(12, 15);
			this.VersionAvailableLabel.Name = "VersionAvailableLabel";
			this.VersionAvailableLabel.Size = new System.Drawing.Size(161, 13);
			this.VersionAvailableLabel.TabIndex = 6;
			this.VersionAvailableLabel.Text = "Version 1.0.xxxx is now available";
			// 
			// DownloadLinkLabel
			// 
			this.DownloadLinkLabel.AutoSize = true;
			this.DownloadLinkLabel.Location = new System.Drawing.Point(23, 42);
			this.DownloadLinkLabel.Name = "DownloadLinkLabel";
			this.DownloadLinkLabel.Size = new System.Drawing.Size(132, 13);
			this.DownloadLinkLabel.TabIndex = 7;
			this.DownloadLinkLabel.TabStop = true;
			this.DownloadLinkLabel.Text = "Go to the downloads page";
			this.DownloadLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DownloadLinkLabel_LinkClicked);
			// 
			// ReleaseNotesLinkLabel
			// 
			this.ReleaseNotesLinkLabel.AutoSize = true;
			this.ReleaseNotesLinkLabel.Location = new System.Drawing.Point(23, 67);
			this.ReleaseNotesLinkLabel.Name = "ReleaseNotesLinkLabel";
			this.ReleaseNotesLinkLabel.Size = new System.Drawing.Size(188, 13);
			this.ReleaseNotesLinkLabel.TabIndex = 8;
			this.ReleaseNotesLinkLabel.TabStop = true;
			this.ReleaseNotesLinkLabel.Text = "View the release notes and changelog";
			this.ReleaseNotesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ReleaseNotesLinkLabel_LinkClicked);
			// 
			// NewVersionDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size(229, 143);
			this.Controls.Add(this.ReleaseNotesLinkLabel);
			this.Controls.Add(this.DownloadLinkLabel);
			this.Controls.Add(this.VersionAvailableLabel);
			this.Controls.Add(this.CloseButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewVersionDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Version Available";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Label VersionAvailableLabel;
		private System.Windows.Forms.LinkLabel DownloadLinkLabel;
		private System.Windows.Forms.LinkLabel ReleaseNotesLinkLabel;
	}
}