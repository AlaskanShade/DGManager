using System;
using System.Reflection;
using System.Windows.Forms;

namespace DGManager
{
	public partial class AboutDialog : Form
	{
		public AboutDialog()
		{
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.pixel.k.free.fr/");
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.gpsvisualizer.com/");
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://sourceforge.net/projects/dgmanager-net/");
		}

		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/AlaskanShade/DGManager");
		}
		
		private void AboutDialog_Load(object sender, EventArgs e)
		{
			Version assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
			VersionLabel.Text = String.Format("{0}.{1}.{2}", assemblyVersion.Major, assemblyVersion.Minor, assemblyVersion.Build);
			
		}
	}
}