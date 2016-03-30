namespace DGManager
{
	partial class GpxSettingsDialog
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
			this.LoadingGpxFilesGroupBox = new System.Windows.Forms.GroupBox();
			this.TracksCheckBox = new System.Windows.Forms.CheckBox();
			this.RoutesCheckBox = new System.Windows.Forms.CheckBox();
			this.WaypointsCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CanclButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.SavingGpxFilesGroupBox = new System.Windows.Forms.GroupBox();
			this.SaveSpeedCheckBox = new System.Windows.Forms.CheckBox();
			this.LoadingGpxFilesGroupBox.SuspendLayout();
			this.SavingGpxFilesGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// LoadingGpxFilesGroupBox
			// 
			this.LoadingGpxFilesGroupBox.Controls.Add(this.TracksCheckBox);
			this.LoadingGpxFilesGroupBox.Controls.Add(this.RoutesCheckBox);
			this.LoadingGpxFilesGroupBox.Controls.Add(this.WaypointsCheckBox);
			this.LoadingGpxFilesGroupBox.Controls.Add(this.label1);
			this.LoadingGpxFilesGroupBox.Location = new System.Drawing.Point(12, 12);
			this.LoadingGpxFilesGroupBox.Name = "LoadingGpxFilesGroupBox";
			this.LoadingGpxFilesGroupBox.Size = new System.Drawing.Size(234, 117);
			this.LoadingGpxFilesGroupBox.TabIndex = 0;
			this.LoadingGpxFilesGroupBox.TabStop = false;
			this.LoadingGpxFilesGroupBox.Text = "Loading GPX Files";
			// 
			// TracksCheckBox
			// 
			this.TracksCheckBox.AutoSize = true;
			this.TracksCheckBox.Location = new System.Drawing.Point(10, 87);
			this.TracksCheckBox.Name = "TracksCheckBox";
			this.TracksCheckBox.Size = new System.Drawing.Size(92, 17);
			this.TracksCheckBox.TabIndex = 3;
			this.TracksCheckBox.Text = "Tracks - <trk>";
			this.TracksCheckBox.UseVisualStyleBackColor = true;
			// 
			// RoutesCheckBox
			// 
			this.RoutesCheckBox.AutoSize = true;
			this.RoutesCheckBox.Location = new System.Drawing.Point(10, 64);
			this.RoutesCheckBox.Name = "RoutesCheckBox";
			this.RoutesCheckBox.Size = new System.Drawing.Size(93, 17);
			this.RoutesCheckBox.TabIndex = 2;
			this.RoutesCheckBox.Text = "Routes - <rte>";
			this.RoutesCheckBox.UseVisualStyleBackColor = true;
			// 
			// WaypointsCheckBox
			// 
			this.WaypointsCheckBox.AutoSize = true;
			this.WaypointsCheckBox.Location = new System.Drawing.Point(10, 41);
			this.WaypointsCheckBox.Name = "WaypointsCheckBox";
			this.WaypointsCheckBox.Size = new System.Drawing.Size(167, 17);
			this.WaypointsCheckBox.TabIndex = 1;
			this.WaypointsCheckBox.Text = "Ungrouped waypoints - <wpt>";
			this.WaypointsCheckBox.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Interpret the following as tracks:";
			// 
			// CanclButton
			// 
			this.CanclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanclButton.Location = new System.Drawing.Point(131, 211);
			this.CanclButton.Name = "CanclButton";
			this.CanclButton.Size = new System.Drawing.Size(75, 23);
			this.CanclButton.TabIndex = 4;
			this.CanclButton.Text = "Cancel";
			this.CanclButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(52, 211);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 3;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// SavingGpxFilesGroupBox
			// 
			this.SavingGpxFilesGroupBox.Controls.Add(this.SaveSpeedCheckBox);
			this.SavingGpxFilesGroupBox.Location = new System.Drawing.Point(12, 135);
			this.SavingGpxFilesGroupBox.Name = "SavingGpxFilesGroupBox";
			this.SavingGpxFilesGroupBox.Size = new System.Drawing.Size(234, 60);
			this.SavingGpxFilesGroupBox.TabIndex = 5;
			this.SavingGpxFilesGroupBox.TabStop = false;
			this.SavingGpxFilesGroupBox.Text = "Saving GPX Files";
			// 
			// SaveSpeedCheckBox
			// 
			this.SaveSpeedCheckBox.AutoSize = true;
			this.SaveSpeedCheckBox.Location = new System.Drawing.Point(10, 28);
			this.SaveSpeedCheckBox.Name = "SaveSpeedCheckBox";
			this.SaveSpeedCheckBox.Size = new System.Drawing.Size(117, 17);
			this.SaveSpeedCheckBox.TabIndex = 2;
			this.SaveSpeedCheckBox.Text = "Include speed data";
			this.SaveSpeedCheckBox.UseVisualStyleBackColor = true;
			// 
			// GpxSettingsDialog
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CanclButton;
			this.ClientSize = new System.Drawing.Size(258, 245);
			this.Controls.Add(this.SavingGpxFilesGroupBox);
			this.Controls.Add(this.CanclButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.LoadingGpxFilesGroupBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GpxSettingsDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GPX Settings";
			this.TopMost = true;
			this.LoadingGpxFilesGroupBox.ResumeLayout(false);
			this.LoadingGpxFilesGroupBox.PerformLayout();
			this.SavingGpxFilesGroupBox.ResumeLayout(false);
			this.SavingGpxFilesGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox LoadingGpxFilesGroupBox;
		private System.Windows.Forms.Button CanclButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.CheckBox WaypointsCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox TracksCheckBox;
		private System.Windows.Forms.CheckBox RoutesCheckBox;
		private System.Windows.Forms.GroupBox SavingGpxFilesGroupBox;
		private System.Windows.Forms.CheckBox SaveSpeedCheckBox;
	}
}