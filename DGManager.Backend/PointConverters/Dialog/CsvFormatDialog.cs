using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace DGManager.Backend.PointConverters.Dialog
{
    public partial class CsvFormatDialog : Form
    {
        private string _filename;
        private string _data;
        private List<string> _fields;

        public string Filename 
        { 
            get { return _filename; } 
            set 
            { 
                _filename = value;
                _data = File.ReadAllText(_filename);
                RefreshView();
            } 
        }

        public string LineSeparator
        {
            get
            {
                switch (cmbLineSep.SelectedIndex)
                {
                    case 0:
                        return "CR/LF";
                    case 1:
                        return ";";
                    case 2:
                        return "|";
                    case 3:
                        return txtLineSepOther.Text;
                }
                return "CR/LF";
            }
            set
            {
                switch (value)
                {
                    case "CR/LF":
                        cmbLineSep.SelectedIndex = 0;
                        break;
                    case ";":
                        cmbLineSep.SelectedIndex = 1;
                        break;
                    case "|":
                        cmbLineSep.SelectedIndex = 2;
                        break;
                    default:
                        cmbLineSep.SelectedIndex = 3;
                        txtLineSepOther.Text = value;
                        break;
                }
            }
        }

        public string FieldSeparator
        {
            get
            {
                switch (cmbFieldSep.SelectedIndex)
                {
                    case 0:
                        return ",";
                    case 1:
                        return "\t";
                    case 2:
                        return " ";
                    case 3:
                        return ";";
                    case 4:
                        return "|";
                    case 5:
                        return txtFieldSepOther.Text;
                }
                return ",";
            }
            set
            {
                switch (value)
                {
                    case ",":
                        cmbFieldSep.SelectedIndex = 0;
                        break;
                    case "\t":
                        cmbFieldSep.SelectedIndex = 1;
                        break;
                    case " ":
                        cmbFieldSep.SelectedIndex = 2;
                        break;
                    case ";":
                        cmbFieldSep.SelectedIndex = 3;
                        break;
                    case "|":
                        cmbFieldSep.SelectedIndex = 4;
                        break;
                    default:
                        cmbFieldSep.SelectedIndex = 5;
                        txtFieldSepOther.Text = value;
                        break;
                }
            }
        }

        public string QuoteSymbol
        {
            get
            {
                switch (cmbQuote.SelectedIndex)
                {
                    case 1:
                        return "\"";
                    case 2:
                        return "'";
                    case 3:
                        return txtQuoteOther.Text;
                }
                return String.Empty;
            }
            set
            {
                switch (value)
                {
                    case "":
                        cmbQuote.SelectedIndex = 0;
                        break;
                    case "\"":
                        cmbQuote.SelectedIndex = 1;
                        break;
                    case "'":
                        cmbQuote.SelectedIndex = 2;
                        break;
                    default:
                        cmbQuote.SelectedIndex = 3;
                        txtQuoteOther.Text = value;
                        break;
                }
            }
        }

        public string CommentCharacter
        {
            get
            {
                switch (cmbComments.SelectedIndex)
                {
                    case 0:
                        return String.Empty;
                    case 1:
                        return "#";
                }
                return String.Empty;
            }
            set
            {
                switch (value)
                {
                    case "":
                        cmbComments.SelectedIndex = 0;
                        break;
                    case "#":
                        cmbComments.SelectedIndex = 1;
                        break;
                    default:
                        cmbComments.SelectedIndex = 2;
                        txtComment.Text = value;
                        break;
                }
            }
        }

        public List<PointOfInterestList> Tracks { get; private set; }

        public CsvFormatDialog()
        {
            InitializeComponent();
            // TODO: Add these to settings
            cmbLineSep.SelectedIndex = 0;
            cmbFieldSep.SelectedIndex = 0;
            cmbQuote.SelectedIndex = 0;
            cmbComments.SelectedIndex = 0;
            Tracks = new List<PointOfInterestList>();
            _fields = new List<string>();
        }

        private void cmbLineSep_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLineSepOther.Enabled = (cmbLineSep.SelectedItem.ToString() == "Other");
            RefreshView();
        }

        private void cmbQuote_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuoteOther.Enabled = (cmbQuote.SelectedItem.ToString() == "Other");
            RefreshView();
        }

        private void cmbFieldSep_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFieldSepOther.Enabled = (cmbFieldSep.SelectedItem.ToString() == "Other");
            RefreshView();
        }

        private void cmbComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtComment.Enabled = (cmbComments.SelectedItem.ToString() == "Other");
            RefreshView();
        }

        private void ckHeaderRow_CheckedChanged(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            // Options: Line Separator (auto, CR/LF, semi-colon, other)
            //          Field Separator (auto, tab, semi-colon, comma, space, other); 
            //          Text Qualifier (auto, double quotes, quotes, none)
            //          First row (auto, column names, data)
            //          Comment Character ()
            if (_data == null) return;
            listData.Clear();
            lblWarnings.Text = "";
            _fields.Clear();
            // This code avoids infinite loops
            string[] lines = Regex.Split(_data, LineSeparator.Replace("CR/LF", Environment.NewLine));
            string regex = String.Format("(?:([^{0}]+))", FieldSeparator);
            if (!String.IsNullOrEmpty(QuoteSymbol))
                regex = String.Format("(?:((?:{1}[^{1}]*{1})|[^{1}{0}]+)+?)",
                    FieldSeparator, QuoteSymbol == "|" ? "\\|" : QuoteSymbol);
            Regex reParse = new Regex(regex, RegexOptions.Singleline | RegexOptions.Multiline);
            int minFields = int.MaxValue, maxFields = int.MinValue;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                MatchCollection matches = reParse.Matches(line);
                if (matches.Count > 0)
                {
                    if (ckHeaderRow.Checked && i == 0)
                        foreach (Match m in matches)
                        {
                            listData.Columns.Add(m.Value.Trim());
                            _fields.Add(m.Value.Trim());
                        }
                    else if (String.IsNullOrEmpty(CommentCharacter) || !line.Trim().StartsWith(CommentCharacter))
                    {
                        ListViewItem newItem = new ListViewItem();
                        if (matches.Count < minFields) minFields = matches.Count;
                        if (matches.Count > maxFields) maxFields = matches.Count;
                        for (int j = 0; j < matches.Count; j++)
                        {
                            if (listData.Columns.Count < j + 1 && j < 50)
                            {
                                listData.Columns.Add(String.Format("Column {0}", j + 1));
                                _fields.Add(String.Format("Column {0}", j + 1));
                            }
                            if (j == 0)
                                newItem.Text = matches[j].Value.Trim();
                            else if (j < 50)
                                newItem.SubItems.Add(matches[j].Value.Trim());
                        }
                        listData.Items.Add(newItem);
                    }
                }
            }
            /*  This code is robust, but sometimes has infinite loop issues in the regular expression
            string regex = String.Format("(?:([^{1}{2}]+){1}?)+?({0}|\\z)",
                    LineSeparator.Replace("CR/LF", "\\r\\n"),
                    FieldSeparator, LineSeparator.Replace("CR/LF", "\n"));
            if (!String.IsNullOrEmpty(QuoteSymbol))
                regex = String.Format("(?:((?:{2}[^{2}]*{2})|[^{2}{1}]+)+?{1}?)+?({0}|\\z)",
                    LineSeparator.Replace("CR/LF", "\\r\\n"),
                    FieldSeparator, QuoteSymbol == "|" ? "\\|" : QuoteSymbol);
            Regex reParse = new Regex(regex,
                RegexOptions.Singleline | RegexOptions.Multiline);
            int minFields = int.MaxValue, maxFields = int.MinValue;
            foreach (Match m in reParse.Matches(_data))
            {
                ListViewItem newItem = new ListViewItem();
                Group g = m.Groups[1];
                if (g.Captures.Count < minFields) minFields = g.Captures.Count;
                if (g.Captures.Count > maxFields) maxFields = g.Captures.Count;
                for (int i = 0; i < g.Captures.Count; i++)
                {
                    if (listData.Columns.Count < i + 1 && i < 50)
                        listData.Columns.Add(String.Format("Column {0}", i + 1));
                    if (i == 0)
                        newItem.Text = g.Captures[i].Value.Trim();
                    else if (i < 50)
                        newItem.SubItems.Add(g.Captures[i].Value.Trim());
                }
                listData.Items.Add(newItem);
            }
            */
            lblRecords.Text = String.Format("{0} records", listData.Items.Count);
            for (int i = 0; i < listData.Columns.Count; i++)
                listData.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            if (minFields != maxFields)
                lblWarnings.Text = "Field mismatch between records";
            RefreshColumnSelectors();
        }

        private void RefreshColumnSelectors()
        {
            // latitude, longitude, altitude, name, description, when
            foreach (Control c in groupBox1.Controls)
            {
                ComboBox cmb = c as ComboBox;
                if (cmb != null)
                {
                    int selIndex = cmb.SelectedIndex;
                    string selItem = (cmb.SelectedItem == null) ? String.Empty : cmb.SelectedItem.ToString();
                    cmb.Items.Clear();
                    cmb.Items.Add("None");
                    _fields.ForEach(s => cmb.Items.Add(s));
                    if (cmb.Items.Contains(selItem))
                        cmb.SelectedValue = selItem;
                    else if (cmb.Items.Count > selIndex && selIndex != -1)
                        cmb.SelectedIndex = selIndex;
                    else
                        cmb.SelectedIndex = 0;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbLatitude.SelectedIndex < 1)
            {
                MessageBox.Show("You must select a latitude field");
                return;
            }
            if (cmbLongitude.SelectedIndex < 1)
            {
                MessageBox.Show("You must select a longitude field");
                return;
            }
            Tracks.Clear();
            string index = String.Empty;
            PointOfInterestList track = null;
            foreach (ListViewItem item in listData.Items)
            {
                if (track == null || cmbIndex.SelectedIndex == 0)
                {
                    track = new PointOfInterestList();
                    Tracks.Add(track);
                }
                PointOfInterest point = new PointOfInterest();
                double value;
                DateTime dateValue;
                if (!double.TryParse(item.SubItems[cmbLatitude.SelectedIndex - 1].Text, out value))
                    break;
                point.Latitude = value;
                if (!double.TryParse(item.SubItems[cmbLongitude.SelectedIndex - 1].Text, out value))
                    break;
                point.Longitude = value;
                if (cmbAltitude.SelectedIndex > 0 && double.TryParse(item.SubItems[cmbAltitude.SelectedIndex - 1].Text, out value))
                {
                    point.Altitude.SetValue(value);
                    point.TypePoi = 1;
                }
                if (cmbDate.SelectedIndex > 0 && DateTime.TryParse(item.SubItems[cmbDate.SelectedIndex - 1].Text, out dateValue))
                    point.When = dateValue;
                if (cmbName.SelectedIndex > 0)
                {
                    point.Name = item.SubItems[cmbName.SelectedIndex - 1].Text;
                    track.ListName = point.Name;
                }
                if (cmbDescription.SelectedIndex > 0)
                    point.Description = item.SubItems[cmbDescription.SelectedIndex - 1].Text;
                if (cmbIndex.SelectedIndex > 0)
                {
                    string nextIndex = item.SubItems[cmbIndex.SelectedIndex - 1].Text;
                    if (index != nextIndex && !String.IsNullOrEmpty(index))
                    {
                        track = new PointOfInterestList();
                        Tracks.Add(track);
                    }
                    index = nextIndex;
                }
                track.Add(point);
            }
        }
    }
}