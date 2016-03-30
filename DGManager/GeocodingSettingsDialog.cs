using System;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
	public partial class GeocodingSettingsDialog : Form
	{
		private bool cameraOffsetEnabled;
		private TimeSpan cameraOffsetTimespan;
		private TimespanSign cameraOffsetSign;
		private bool setImageModDateToGeocodeDate;
		private bool geocodePlanBThresholdEnabled;
		private int geocodePlanBThresholdMins;
		private int geocodeInterpolationThresholdSecs;
		private static bool revGeoEnabled;
		private static bool revGeoSetImageDescription;
		private static bool revGeoSetXPComment;
		private static bool revGeoSetXPKeywords;
		private static bool revGeoSetXPSubject;
		private static bool revGeoSetUserComment;
		private static bool revGeoSetIptcKeywords;
		private static bool revGeoSetIptcCaption;
		private static bool revGeoUseGoogleMaps;

		public bool CameraOffsetEnabled
		{
			get
			{
				return cameraOffsetEnabled;
			}
			set
			{
				cameraOffsetEnabled = value;

				CameraOffsetEnabledCheckBox.Checked = value;
			}
		}

		public TimeSpan CameraOffsetTimespan
		{
			get
			{
				return cameraOffsetTimespan;
			}
			set
			{
				cameraOffsetTimespan = value;

				HoursUpDown.Value = value.Hours + value.Days * 24;
				MinutesUpDown.Value = value.Minutes;
				SecondsUpDown.Value = value.Seconds;
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

				CameraOffsetSignComboBox.SelectedIndex = (value == TimespanSign.Positive) ? 0 : 1;
			}
		}

		public bool SetImageModDateToGeocodeDate
		{
			get
			{
				return setImageModDateToGeocodeDate;
			}
			set
			{
				setImageModDateToGeocodeDate = value;

				SetImageModDateToGeocodeDateCheckBox.Checked = value;
			}
		}

		public bool GeocodePlanBThresholdEnabled
		{
			get
			{
				return geocodePlanBThresholdEnabled;
			}
			set
			{
				geocodePlanBThresholdEnabled = value;

				GeocodePlanBThresholdEnabledCheckBox.Checked = value;
			}
		}

		public int GeocodePlanBThresholdMins
		{
			get
			{
				return geocodePlanBThresholdMins;
			}
			set
			{
				geocodePlanBThresholdMins = value;

				GeocodePlanBThresholdMinsUpDown.Value = value;
			}
		}

		public int GeocodeInterpolationThresholdSecs
		{
			get
			{
				return geocodeInterpolationThresholdSecs;
			}
			set
			{
				geocodeInterpolationThresholdSecs = value;
				
				GeocodeInterpolationThresholdSecsUpDown.Value = value;
			}
		}

		public bool RevGeoEnabled
		{
			get
			{
				return revGeoEnabled;
			}
			set
			{
				revGeoEnabled = value;

				RevGeoEnabledCheckBox.Checked = value;
			}
		}

		public bool RevGeoSetImageDescription
		{
			get
			{
				return revGeoSetImageDescription;
			}
			set
			{
				revGeoSetImageDescription = value;

				RevGeoSetImageDescriptionCheckBox.Checked = value;
			}
		}

		public bool RevGeoSetXPComment
		{
			get
			{
				return revGeoSetXPComment;
			}
			set
			{
				revGeoSetXPComment = value;

				RevGeoSetXPCommentCheckBox.Checked = value;
			}
		}

		public bool RevGeoSetXPKeywords
		{
			get
			{
				return revGeoSetXPKeywords;
			}
			set
			{
				revGeoSetXPKeywords = value;

				RevGeoSetXPKeywordsCheckBox.Checked = value;
			}
		}

		public bool RevGeoSetXPSubject
		{
			get
			{
				return revGeoSetXPSubject;
			}
			set
			{
				revGeoSetXPSubject = value;

				RevGeoSetXPSubjectCheckBox.Checked = value;
			}
		}

		public bool RevGeoSetUserComment
		{
			get
			{
				return revGeoSetUserComment;
			}
			set
			{
				revGeoSetUserComment = value;

				RevGeoSetUserCommentCheckBox.Checked = value;
			}
		}

		public bool RevGeoSetIptcKeywords
		{
			get
			{
				return revGeoSetIptcKeywords;
			}
			set
			{
				revGeoSetIptcKeywords = value;

				RevGeoSetIptcKeywordsCheckBox.Checked = value;
			}
		}

		public bool RevGeoSetIptcCaption
		{
			get
			{
				return revGeoSetIptcCaption;
			}
			set
			{
				revGeoSetIptcCaption = value;

				RevGeoSetIptcCaptionCheckBox.Checked = value;
			}
		}

		public bool RevGeoUseGoogleMaps
		{
			get
			{
				return revGeoUseGoogleMaps;
			}
			set
			{
				revGeoUseGoogleMaps = value;

				if (revGeoUseGoogleMaps)
				{
					RevGeoUseGMapsRadioButton.Checked = true;
				}
				else
				{
					RevGeoDoNotUseGMapsRadioButton.Checked = true;
				}
			}
		}

		public GeocodingSettingsDialog()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			CameraOffsetEnabled = CameraOffsetEnabledCheckBox.Checked;
			CameraOffsetTimespan = new TimeSpan((int)HoursUpDown.Value, (int)MinutesUpDown.Value, (int)SecondsUpDown.Value);
			CameraOffsetSign = (TimespanSign) ((string)CameraOffsetSignComboBox.SelectedItem)[0];
			SetImageModDateToGeocodeDate = SetImageModDateToGeocodeDateCheckBox.Checked;
			GeocodePlanBThresholdEnabled = GeocodePlanBThresholdEnabledCheckBox.Checked;
			GeocodePlanBThresholdMins = (int) GeocodePlanBThresholdMinsUpDown.Value;
			GeocodeInterpolationThresholdSecs = (int)GeocodeInterpolationThresholdSecsUpDown.Value;
			RevGeoEnabled = RevGeoEnabledCheckBox.Checked;
			RevGeoSetImageDescription = RevGeoSetImageDescriptionCheckBox.Checked;
			RevGeoSetXPComment = RevGeoSetXPCommentCheckBox.Checked;
			RevGeoSetXPKeywords = RevGeoSetXPKeywordsCheckBox.Checked;
			RevGeoSetXPSubject = RevGeoSetXPSubjectCheckBox.Checked;
			RevGeoSetUserComment = RevGeoSetUserCommentCheckBox.Checked;
			RevGeoSetIptcKeywords = RevGeoSetIptcKeywordsCheckBox.Checked;
			RevGeoSetIptcCaption = RevGeoSetIptcCaptionCheckBox.Checked;
			RevGeoUseGoogleMaps = RevGeoUseGMapsRadioButton.Checked;
			
			DialogResult = DialogResult.OK;
			Close();
		}

		private void GeocodeInterpolationThresholdSecsUpDown_ValueChanged(object sender, EventArgs e)
		{
			EnsureThresholdsDoNotOverlap();
		}

		private void GeocodePlanBThresholdMinsUpDown_ValueChanged(object sender, EventArgs e)
		{
			EnsureThresholdsDoNotOverlap();
		}
		
		private void EnsureThresholdsDoNotOverlap()
		{
			if ((GeocodeInterpolationThresholdSecsUpDown.Value / 60) >=
				GeocodePlanBThresholdMinsUpDown.Value)
			{
				GeocodePlanBThresholdMinsUpDown.Value = (GeocodeInterpolationThresholdSecsUpDown.Value / 60) + 1;
			}
		}
	}
}