using System;
using System.Windows.Forms;
using System.IO;
using DGManager.Backend;

namespace DGManager
{
	public partial class GMapLocationSelecterDialog : Form
	{
		public string Latitude = "";
		public string Longitude = "";

		public GMapLocationSelecterDialog()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string currentDir = Path.GetDirectoryName(Application.ExecutablePath);
			string latitude = Settings.ManualGeocodeLastLocationLat; //grab latitude from settings
			string longitude = Settings.ManualGeocodeLastLocationLon;//grab longitude from settings
			string rememberLocation = Settings.ManualGeocodeRememberLastLocation.ToString();
            string argumentString = String.Format("?lat={0}&lon={1}&rememberlocation={2}", latitude, longitude, rememberLocation);
            string filePath = Path.Combine(currentDir, String.Format("GMap.html{0}", argumentString));//pass coordinates on to map in html file
            // Removed the second parameter from contructor because it is deprecated and always false
			Uri fileUri = new Uri(filePath);//true is needed in order not to encode '?' and '&' (this avoids error in javascript)
			webBrowser1.Navigate(fileUri);
		}

		//'Use Selected Location' button
		private void button1_Click(object sender, EventArgs e)
		{
			//IHTMLDocument3 doc = (IHTMLDocument3)webBrowser1.Document.DomDocument;

			////Selected coordinates can be accessed from other forms via these public attributes
			//Latitude = ((HTMLInputElement)doc.getElementById("latbox")).value;
			//Longitude = ((HTMLInputElement)doc.getElementById("lonbox")).value;

			////update settings
			//bool rememberLocation = ((HTMLInputElement)doc.getElementById("rememberlocationbox")).@checked;
			//if (rememberLocation)
			//{
			//	Settings.ManualGeocodeLastLocationLat = Latitude;
			//	Settings.ManualGeocodeLastLocationLon = Longitude;
			//}

			//Settings.ManualGeocodeRememberLastLocation = ((HTMLInputElement)doc.getElementById("rememberlocationbox")).@checked;

			DialogResult = DialogResult.OK;//signal that coordinates can be used
			Close();
		}

		//'Cancel' button
		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel; //signal that user has cancelled (don't use coordinates)
			Close();
		}

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			PleaseWaitLabel.Visible = false;
		}
	}
}
