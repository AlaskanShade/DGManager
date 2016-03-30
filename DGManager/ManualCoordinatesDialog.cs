using System;
using System.Globalization;
using System.Windows.Forms;

namespace DGManager
{
	public partial class ManualCoordinatesDialog : Form
	{
		public ManualCoordinatesDialog()
		{
			InitializeComponent();
		}

		public double Latitude
		{
			get
			{
				return Convert.ToDouble(textBox1.Text, CultureInfo.InvariantCulture);
			}
		}
		
		public double Longitude
		{
			get
			{
				return Convert.ToDouble(textBox2.Text, CultureInfo.InvariantCulture);
			}
		}
		
		public bool CalculateSurroundingCoordinates
		{
			get
			{
				return checkBox1.Checked;
			}
		}

		//'Cancel' button
		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
			return;
		}

		//'OK' button
		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length == 0 || textBox1.Text.Length == 0)
			{
				MessageBox.Show("Please enter the coordinates");
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
			return;
		}

		//'Select Location On A Map'
		private void button3_Click(object sender, EventArgs e)
		{
			GMapLocationSelecterDialog form = new GMapLocationSelecterDialog();
			DialogResult result = form.ShowDialog();
			if (result == DialogResult.OK)
			{
				textBox1.Text = form.Latitude;
				textBox2.Text = form.Longitude;
			}
		}
	}
}