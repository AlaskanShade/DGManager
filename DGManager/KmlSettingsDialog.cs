using System;
using System.Windows.Forms;

namespace DGManager
{
	public partial class KmlSettingsDialog : Form
	{
		private bool kmlUsePhotoPathPrefix;
		private string kmlPhotoPathPrefix;

		public bool KmlUsePhotoPathPrefix
		{
			get
			{
				return kmlUsePhotoPathPrefix;
			}
			set
			{
				kmlUsePhotoPathPrefix = value;

				KmlUsePhotoPathPrefixCheckBox.Checked = value;
			}
		}

		public string KmlPhotoPathPrefix
		{
			get
			{
				return kmlPhotoPathPrefix;
			}
			set
			{
				kmlPhotoPathPrefix = value;

				KmlPhotoPathPrefixTextBox.Text = value;
			}
		}

		public KmlSettingsDialog()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			KmlUsePhotoPathPrefix = KmlUsePhotoPathPrefixCheckBox.Checked;
			KmlPhotoPathPrefix = KmlPhotoPathPrefixTextBox.Text;

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}