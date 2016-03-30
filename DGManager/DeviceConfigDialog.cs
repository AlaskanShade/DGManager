using System;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
	public partial class DeviceConfigDialog : Form
	{
		private DeviceConfig config;

		public DeviceConfig Config
		{
			get
			{
				return config;
			}
			set
			{
				config = value;

				ReflectConfigInUI();
			}
		}

		public DeviceConfigDialog()
		{
			InitializeComponent();
		}

        private void ReflectConfigInUI()
        {
            switch (Config.LogFormat)
            {
                case DeviceConfig.LogFormatType.Pos:
                    Type0RadioButton.Checked = true;
                    break;
                case DeviceConfig.LogFormatType.PosDateSpeed:
                    Type1RadioButton.Checked = true;
                    break;
                case DeviceConfig.LogFormatType.PosDateSpeedAltitude:
                    Type2RadioButton.Checked = true;
                    break;
            }

            DontLogSpeedCheckBox.Checked = config.SpeedThresholdEnabled;
            DontLogSpeedUpDown.Value = config.SpeedThreshold;
            DontLogDistanceCheckBox.Checked = config.DistanceThresholdEnabled;
            DontLogDistanceUpDown.Value = config.DistanceThreshold;

            if (config.ModeAIsByDistance)
            {
                ModeADistanceRadioButton.Checked = true;
            }
            else
            {
                ModeATimeRadioButton.Checked = true;
            }

            ModeATimeUpDown.Value = config.ModeATimeInterval / 1000;
            ModeADistanceUpDown.Value = config.ModeADistanceInterval;

            if (config.ModeBIsByDistance)
            {
                ModeBDistanceRadioButton.Checked = true;
            }
            else
            {
                ModeBTimeRadioButton.Checked = true;
            }

            ModeBTimeUpDown.Value = config.ModeBTimeInterval / 1000;
            ModeBDistanceUpDown.Value = config.ModeBDistanceInterval;

            if (config.ModeCIsByDistance)
            {
                ModeCDistanceRadioButton.Checked = true;
            }
            else
            {
                ModeCTimeRadioButton.Checked = true;
            }

            ModeCTimeUpDown.Value = config.ModeCTimeInterval / 1000;
            ModeCDistanceUpDown.Value = config.ModeCDistanceInterval;

            MemoryLabel.Text = String.Format("{0}%", (100 - config.MemoryUsage));
            MemoryProgressBar.Value = (100 - config.MemoryUsage);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (Type0RadioButton.Checked)
            {
                config.LogFormat = DeviceConfig.LogFormatType.Pos;
            }
            else if (Type1RadioButton.Checked)
            {
                config.LogFormat = DeviceConfig.LogFormatType.PosDateSpeed;
            }
            else
            {
                config.LogFormat = DeviceConfig.LogFormatType.PosDateSpeedAltitude;
            }

            config.SpeedThresholdEnabled = DontLogSpeedCheckBox.Checked;
            config.SpeedThreshold = (int)DontLogSpeedUpDown.Value;
            config.DistanceThresholdEnabled = DontLogDistanceCheckBox.Checked;
            config.DistanceThreshold = (int)DontLogDistanceUpDown.Value;

            config.ModeAIsByDistance = ModeADistanceRadioButton.Checked;
            config.ModeBIsByDistance = ModeBDistanceRadioButton.Checked;
            config.ModeCIsByDistance = ModeCDistanceRadioButton.Checked;

            config.ModeATimeInterval = (int)ModeATimeUpDown.Value * 1000;
            config.ModeBTimeInterval = (int)ModeBTimeUpDown.Value * 1000;
            config.ModeCTimeInterval = (int)ModeCTimeUpDown.Value * 1000;

            config.ModeADistanceInterval = (int)ModeADistanceUpDown.Value;
            config.ModeBDistanceInterval = (int)ModeBDistanceUpDown.Value;
            config.ModeCDistanceInterval = (int)ModeCDistanceUpDown.Value;

            DialogResult = DialogResult.OK;
        }
	}
}