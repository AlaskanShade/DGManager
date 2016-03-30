using System;
using System.Drawing;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
	public partial class AdvancedGMapsDialog : Form
	{
		private Color lineColour;
		private int lineWidth;
		private int lineOpacity;
		private bool specifyLineColour;
		private bool specifyLineWidth;
		private bool specifyLineOpacity;
		private bool differentTrackColours;
		private bool dropPoints;
		private int dropPointsThreshold;
		private double dropPointsMinDistance;
		private string apiKey;
        private ColorPick.frmColorPicker colorPicker = new ColorPick.frmColorPicker(Color.Blue);

		public Color LineColour
		{
			get
			{
				return lineColour;
			}
			set
			{
				lineColour = value;

				ColourButton.BackColor = value;
			}
		}

		public int LineWidth
		{
			get
			{
				return lineWidth;
			}
			set
			{
				lineWidth = value;

				WidthUpDown.Value = value;
			}
		}

		public int LineOpacity
		{
			get
			{
				return lineOpacity;
			}
			set
			{
				lineOpacity = value;

				OpacityUpDown.Value = value;
			}
		}

		public bool SpecifyLineColour
		{
			get
			{
				return specifyLineColour;
			}
			set
			{
				specifyLineColour = value;

				ColourCheckBox.Checked = value;
			}
		}

		public bool SpecifyLineWidth
		{
			get
			{
				return specifyLineWidth;
			}
			set
			{
				specifyLineWidth = value;

				WidthCheckBox.Checked = value;
			}
		}

		public bool SpecifyLineOpacity
		{
			get
			{
				return specifyLineOpacity;
			}
			set
			{
				specifyLineOpacity = value;

				OpacityCheckBox.Checked = value;
			}
		}

		public bool DifferentTrackColours
		{
			get
			{
				return differentTrackColours;
			}
			set
			{
				differentTrackColours = value;

				DifferentTrackColoursCheckBox.Checked = value;
			}
		}

		public bool DropPoints
		{
			get
			{
				return dropPoints;
			}
			set
			{
				dropPoints = value;

				DropPointsCheckBox.Checked = value;
			}
		}

		public int DropPointsThreshold
		{
			get
			{
				return dropPointsThreshold;
			}
			set
			{
				dropPointsThreshold = value;

				DropPointsThresholdUpDown.Value = value;
			}
		}

		//This value will be fudged before it is used
		//so that there is more granularity at the bottom end
		public double DropPointsMinDistance
		{
			get
			{
				return dropPointsMinDistance;
			}
			set
			{
				dropPointsMinDistance = value;

				DropPointsMinDistanceTrackBar.Value = value < 50 ? (int) value : 50;
			}
		}

		public string ApiKey
		{
			get
			{
				return apiKey;
			}
			set
			{
				apiKey = value;

				ApiKeyTextBox.Text = value;
			}
		}

        public bool DisplayStartIcon { get { return ckStartIcon.Checked; } set { ckStartIcon.Checked = value; } }

        public string StartIconUrl { get { return txtStartIcon.Text; } set { txtStartIcon.Text = value; } }

        public bool DisplayEndIcon { get { return ckEndIcon.Checked; } set { ckEndIcon.Checked = value; } }

        public string EndIconUrl { get { return txtEndIcon.Text; } set { txtEndIcon.Text = value; } }

        public bool StrictHtml { get; set; }

		public AdvancedGMapsDialog()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			LineColour = ColourButton.BackColor;
			LineWidth = (int) WidthUpDown.Value;
			LineOpacity = (int) OpacityUpDown.Value;
			SpecifyLineColour = ColourCheckBox.Checked;
			SpecifyLineWidth = WidthCheckBox.Checked;
			SpecifyLineOpacity = OpacityCheckBox.Checked;
			DropPoints = DropPointsCheckBox.Checked;
			DropPointsThreshold = (int) DropPointsThresholdUpDown.Value;
			DropPointsMinDistance = DropPointsMinDistanceTrackBar.Value;
			DifferentTrackColours = DifferentTrackColoursCheckBox.Checked;
			ApiKey = ApiKeyTextBox.Text;
            StrictHtml = ckStrict.Checked;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void ColourButton_Click(object sender, EventArgs e)
		{
            colorPicker.PrimaryColor = ColourButton.BackColor;
            if (colorPicker.ShowDialog(this) == DialogResult.OK)
                ColourButton.BackColor = colorPicker.PrimaryColor;
		}

		private void ResetApiKeyButton_Click(object sender, EventArgs e)
		{
			ApiKeyTextBox.Text = Constants.GMAPS_DEFAULT_API_KEY;
		}
	}
}