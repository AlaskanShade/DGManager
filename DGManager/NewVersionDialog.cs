using System;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
	public partial class NewVersionDialog : Form
	{
		private SoftwareVersion version;

		public SoftwareVersion Version
		{
			get
			{
				return version;
			}
			set
			{
				version = value;

				VersionAvailableLabel.Text = String.Format("Version {0} is now available", Version.VersionNumber);
			}
		}

		public NewVersionDialog()
		{
			InitializeComponent();
		}

		private void DownloadLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(Version.DownloadUrl);
		}

		private void ReleaseNotesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(Version.ReleaseNotesUrl);
		}
	}
}