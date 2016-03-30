using System;
using System.Windows.Forms;

namespace DGManager
{
	public partial class GpxSettingsDialog : Form
	{
		private bool gpxIncludeWaypoints;
		private bool gpxIncludeRoutes;
		private bool gpxIncludeTracks;
		private bool gpxSaveSpeedData;

		public bool GpxIncludeWaypoints
		{
			get
			{
				return gpxIncludeWaypoints;
			}
			set
			{
				gpxIncludeWaypoints = value;

				WaypointsCheckBox.Checked = value;
			}
		}

		public bool GpxIncludeRoutes
		{
			get
			{
				return gpxIncludeRoutes;
			}
			set
			{
				gpxIncludeRoutes = value;

				RoutesCheckBox.Checked = value;
			}
		}

		public bool GpxIncludeTracks
		{
			get
			{
				return gpxIncludeTracks;
			}
			set
			{
				gpxIncludeTracks = value;

				TracksCheckBox.Checked = value;
			}
		}

		public bool GpxSaveSpeedData
		{
			get
			{
				return gpxSaveSpeedData;
			}
			set
			{
				gpxSaveSpeedData = value;

				SaveSpeedCheckBox.Checked = value;
			}
		}

		public GpxSettingsDialog()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			GpxIncludeWaypoints = WaypointsCheckBox.Checked;
			GpxIncludeRoutes = RoutesCheckBox.Checked;
			GpxIncludeTracks = TracksCheckBox.Checked;
			GpxSaveSpeedData = SaveSpeedCheckBox.Checked;

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}