using System;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
	public partial class TrackSettingsDialog : Form
	{
		private TrackMode trackMode;
		private int newTrackThresholdMins;
		private bool applyTrackModeWhenLoadingGSD;
		private bool guessManualPoints;

		public TrackMode TrackMode
		{
			get
			{
				return trackMode;
			}
			set
			{
				trackMode = value;

				if (trackMode == TrackMode.GlobalSat)
				{
					GlobalSatRadioButton.Checked = true;
				}
				else
				{
					LogicalRadioButton.Checked = true;
				}
			}
		}

		public int NewTrackThresholdMins
		{
			get
			{
				return newTrackThresholdMins;
			}
			set
			{
				newTrackThresholdMins = value;

				TrackThresholdUpDown.Value = value;
			}
		}
		
		public bool ApplyTrackModeWhenLoadingGSD
		{
			get
			{
				return applyTrackModeWhenLoadingGSD;
			}
			set
			{
				applyTrackModeWhenLoadingGSD = value;
				
				ApplyTrackModeWhenLoadingGSDCheckBox.Checked = value;
			}
		}

		public bool GuessManualPoints
		{
			get
			{
				return guessManualPoints;
			}
			set
			{
				guessManualPoints = value;

				GuessManualPointsCheckBox.Checked = value;
			}
		}

        public string TimeDisplayFormat
        {
            get { return txtTimeFormat.Text; }
            set
            {
                txtTimeFormat.Text = value;
                switch (value)
                {
                    case "yyyy-MM-dd HH:mm":
                        cmbTimeFormat.SelectedIndex = 0;
                        break;
                    case "yyyy-MM-dd HH:mm:ss":
                        cmbTimeFormat.SelectedIndex = 1;
                        break;
                    case "yyyy-MM-dd hh:mm tt":
                        cmbTimeFormat.SelectedIndex = 2;
                        break;
                    case "yyyy-MM-dd hh:mm:ss tt":
                        cmbTimeFormat.SelectedIndex = 3;
                        break;
                }
            }
        }

		public TrackSettingsDialog()
		{
			InitializeComponent();
		}

		private void GlobalSatRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			LogicalPanel.Enabled = false;
		}

		private void LogicalRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			LogicalPanel.Enabled = true;
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			NewTrackThresholdMins = (int)TrackThresholdUpDown.Value;

			if (GlobalSatRadioButton.Checked)
			{
				TrackMode = TrackMode.GlobalSat;
			}
			else
			{
				TrackMode = TrackMode.Logical;
			}

			ApplyTrackModeWhenLoadingGSD = ApplyTrackModeWhenLoadingGSDCheckBox.Checked;
			GuessManualPoints = GuessManualPointsCheckBox.Checked;

			DialogResult = DialogResult.OK;
			Close();
		}

        private void cmbTimeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTimeFormat.Enabled = cmbTimeFormat.SelectedIndex == 4;
            switch (cmbTimeFormat.SelectedIndex)
            {
                case 0:
                    txtTimeFormat.Text = "yyyy-MM-dd HH:mm";
                    break;
                case 1:
                    txtTimeFormat.Text = "yyyy-MM-dd HH:mm:ss";
                    break;
                case 2:
                    txtTimeFormat.Text = "yyyy-MM-dd hh:mm tt";
                    break;
                case 3:
                    txtTimeFormat.Text = "yyyy-MM-dd hh:mm:ss tt";
                    break;
            }
        }
	}
}