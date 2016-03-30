using System;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
    public partial class QueryPathDialog : Form
    {

        public PointOfInterestList Track { get; set; }

        public QueryPathDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			string start = String.IsNullOrEmpty(txtStartName.Text) ? String.Format("{0} {1}", txtStartLat.Text, txtStartLong.Text) : txtStartName.Text;
			string end = String.IsNullOrEmpty(txtEndName.Text) ? String.Format("{0} {1}", txtEndLat.Text, txtEndLong.Text) : txtEndName.Text;
            Track = GeoUtil.DownloadPath(start, end);
        }
    }
}