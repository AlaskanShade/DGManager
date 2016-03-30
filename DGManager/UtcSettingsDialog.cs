using System;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
	public partial class UtcSettingsDialog : Form
	{
		private UtcShiftType utcShiftType;
		private int utcShift;

		public UtcShiftType UtcShiftType
		{
			get
			{
				return utcShiftType;
			}
			set
			{
				utcShiftType = value;

				if (utcShiftType == UtcShiftType.None)
				{
					NoneRadioButton.Checked = true;
				}
				else if (utcShiftType == UtcShiftType.Specified)
				{
					FixedRadioButton.Checked = true;
				}
				else
				{
					AutoRadioButton.Checked = true;
				}
			}
		}

		public int UtcShift
		{
			get
			{
				return utcShift;
			}
			set
			{
				utcShift = value;
				HoursUpDown.Value = value;
			}
		}

		public UtcSettingsDialog()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			UtcShift = (int) HoursUpDown.Value;

			if (NoneRadioButton.Checked)
			{
				UtcShiftType = UtcShiftType.None;
			}
			else if (FixedRadioButton.Checked)
			{
				UtcShiftType = UtcShiftType.Specified;
			}
			else
			{
				UtcShiftType = UtcShiftType.Auto;
			}

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}