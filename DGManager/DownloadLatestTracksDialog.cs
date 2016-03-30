using System;
using System.Windows.Forms;

namespace DGManager
{
	public partial class DownloadLatestTracksDialog : Form
	{
		public int LastDays
		{
			get
			{
				return (int) DaysUpDown.Value;
			}
			set
			{
				DaysUpDown.Value = value;
			}
		}

		public DownloadLatestTracksDialog()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}