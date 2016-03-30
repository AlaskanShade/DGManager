using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
	public partial class SetCameraOffsetDialog : Form
	{
		private Jpeg photo;
		private List<PointOfInterest> allPoints;
		private List<PointOfInterest> manualPoints = new List<PointOfInterest>();
		private TimeSpan cameraOffsetTimespan;
		private TimespanSign cameraOffsetSign;

		public Jpeg Photo
		{
			get
			{
				return photo;
			}
			set
			{
				photo = value;
				PhotoPictureBox.ImageLocation = photo.FilePath;
				PhotoPictureBox.Cursor = Cursors.Hand;
				PhotoFilePathTextBox.Text = photo.FilePath.Length < 47
				                            	? photo.FilePath
                                                : String.Format("...{0}", photo.FilePath.Substring(photo.FilePath.Length - 44));
                PhotoTakenAtLabel.Text = String.Format("{0} {1}", photo.OriginalDateTime.ToShortDateString(), photo.OriginalDateTime.ToLongTimeString());

				SelectClosestManualPoint();
				GpsDateTimePicker.Value = Photo.OriginalDateTime;
				UpdateOffset(this, EventArgs.Empty);
			}
		}

        public int UtcShift { get; set; }

		public TimeSpan CameraOffsetTimespan
		{
			get
			{
				return cameraOffsetTimespan;
			}
			set
			{
				cameraOffsetTimespan = value;
				DisplayOffset();
			}
		}

		public TimespanSign CameraOffsetSign
		{
			get
			{
				return cameraOffsetSign;
			}
			set
			{
				cameraOffsetSign = value;
				DisplayOffset();
			}
		}

		public SetCameraOffsetDialog()
		{
			InitializeComponent();
		}

        public void SetAllPoints(List<PointOfInterest> points)
        {
            allPoints = points;
        }

		private void OkButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void OpenPhotoButton_Click(object sender, EventArgs e)
		{
			if (OpenPhotoDialog.ShowDialog() == DialogResult.OK)
			{	
				Photo = JpegHelper.GetJpegFromFile(OpenPhotoDialog.FileName);
			}
		}

		private void SetCameraOffsetDialog_Shown(object sender, EventArgs e)
		{
			FindManualPoints();
		}

		private void FindManualPoints()
		{
			manualPoints.Clear();
			ManualPointsListBox.Items.Clear();

			if (allPoints.Count >= 5)
			{
				for (int i = 2; i < allPoints.Count - 2; i++)
				{
					int prevTimeGap = (int) allPoints[i - 1].When.Subtract(allPoints[i - 2].When).TotalSeconds;
					int currentTimeGap = (int) allPoints[i].When.Subtract(allPoints[i - 1].When).TotalSeconds;
					int nextTimeGap = (int) allPoints[i + 1].When.Subtract(allPoints[i].When).TotalSeconds;
					int nextNextTimeGap = (int) allPoints[i + 2].When.Subtract(allPoints[i + 1].When).TotalSeconds;

					if (currentTimeGap != prevTimeGap &&
					    currentTimeGap < prevTimeGap &&
					    prevTimeGap == nextNextTimeGap &&
					    nextTimeGap == (prevTimeGap - currentTimeGap))
					{
                        ManualPointsListBox.Items.Add(String.Format("{0} {1}", allPoints[i].When.ToShortDateString(), allPoints[i].When.AddHours(UtcShift).ToLongTimeString()));
						manualPoints.Add(allPoints[i]);
					}
				}
			}
		}

		private void SelectClosestManualPoint()
		{
			TimeSpan closestPointDiff = TimeSpan.MaxValue;
			int? closestPointIndex = null;

			for (int i = 0; i < manualPoints.Count; i++)
			{
				if (!closestPointIndex.HasValue ||
					manualPoints[i].When.AddHours(UtcShift).Subtract(Photo.OriginalDateTime).Duration() < closestPointDiff.Duration())
				{
					closestPointIndex = i;
					closestPointDiff = manualPoints[i].When.AddHours(UtcShift).Subtract(Photo.OriginalDateTime).Duration();
				}
			}

			if (closestPointIndex.HasValue)
			{
				ManualPointsListBox.SelectedIndex = closestPointIndex.Value;
			}
		}

		private void UpdateOffset(object sender, EventArgs e)
		{
			if (Photo == null)
			{
				return;
			}

			DateTime? gpsDate = null;

			if (ManualPointRadioButton.Checked)
			{
				if (ManualPointsListBox.SelectedIndex >= 0)
				{
					gpsDate = manualPoints[ManualPointsListBox.SelectedIndex].When.AddHours(UtcShift);
				}
			}
			else
			{
				gpsDate = GpsDateTimePicker.Value;
			}

			if (!gpsDate.HasValue)
			{
				gpsDate = Photo.OriginalDateTime;
			}

			CameraOffsetTimespan = gpsDate.Value.Subtract(Photo.OriginalDateTime).Duration();
			CameraOffsetSign = gpsDate.Value.Subtract(Photo.OriginalDateTime).TotalSeconds >= 0
			                   	? TimespanSign.Positive
			                   	: TimespanSign.Negative;

			DisplayOffset();
		}

		private void DisplayOffset()
		{
			OffsetLabel.Text = (char) CameraOffsetSign
									 + String.Format("{0:00}:{1:00}:{2:00}",
														  CameraOffsetTimespan.Hours + CameraOffsetTimespan.Days * 24,
														  CameraOffsetTimespan.Minutes,
														  CameraOffsetTimespan.Seconds);
		}

		private void PhotoPictureBox_Click(object sender, EventArgs e)
		{
			if (Photo != null)
			{
				System.Diagnostics.Process.Start(Photo.FilePath);
			}
		}
	}
}