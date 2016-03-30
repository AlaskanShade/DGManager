namespace DGManager.Backend.PointConverters.Dialog
{
    partial class CsvFormatDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLineSep = new System.Windows.Forms.ComboBox();
            this.txtLineSepOther = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFieldSep = new System.Windows.Forms.ComboBox();
            this.txtFieldSepOther = new System.Windows.Forms.TextBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblRecords = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWarnings = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAltitude = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbLongitude = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLatitude = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckHeaderRow = new System.Windows.Forms.CheckBox();
            this.listData = new System.Windows.Forms.ListView();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtQuoteOther = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbComments = new System.Windows.Forms.ComboBox();
            this.cmbQuote = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbIndex = new System.Windows.Forms.ComboBox();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line Separator";
            // 
            // cmbLineSep
            // 
            this.cmbLineSep.FormattingEnabled = true;
            this.cmbLineSep.Items.AddRange(new object[] {
            "CR/LF",
            "Semi-colon (;)",
            "Pipe (|)",
            "Other"});
            this.cmbLineSep.Location = new System.Drawing.Point(94, 12);
            this.cmbLineSep.Name = "cmbLineSep";
            this.cmbLineSep.Size = new System.Drawing.Size(101, 21);
            this.cmbLineSep.TabIndex = 1;
            this.cmbLineSep.SelectedIndexChanged += new System.EventHandler(this.cmbLineSep_SelectedIndexChanged);
            // 
            // txtLineSepOther
            // 
            this.txtLineSepOther.Enabled = false;
            this.txtLineSepOther.Location = new System.Drawing.Point(201, 13);
            this.txtLineSepOther.Name = "txtLineSepOther";
            this.txtLineSepOther.Size = new System.Drawing.Size(27, 20);
            this.txtLineSepOther.TabIndex = 2;
            this.txtLineSepOther.Text = ";";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Field Separator";
            // 
            // cmbFieldSep
            // 
            this.cmbFieldSep.FormattingEnabled = true;
            this.cmbFieldSep.Items.AddRange(new object[] {
            "Comma (,)",
            "Tab",
            "Space",
            "Semi-colon (;)",
            "Pipe (|)",
            "Other"});
            this.cmbFieldSep.Location = new System.Drawing.Point(94, 40);
            this.cmbFieldSep.Name = "cmbFieldSep";
            this.cmbFieldSep.Size = new System.Drawing.Size(101, 21);
            this.cmbFieldSep.TabIndex = 1;
            this.cmbFieldSep.SelectedIndexChanged += new System.EventHandler(this.cmbFieldSep_SelectedIndexChanged);
            // 
            // txtFieldSepOther
            // 
            this.txtFieldSepOther.Enabled = false;
            this.txtFieldSepOther.Location = new System.Drawing.Point(201, 41);
            this.txtFieldSepOther.MaxLength = 1;
            this.txtFieldSepOther.Name = "txtFieldSepOther";
            this.txtFieldSepOther.Size = new System.Drawing.Size(27, 20);
            this.txtFieldSepOther.TabIndex = 2;
            this.txtFieldSepOther.Text = ",";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnCancel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnOk);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.groupBox1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ckHeaderRow);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listData);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtComment);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtQuoteOther);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtFieldSepOther);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtLineSepOther);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbLineSep);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbComments);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbQuote);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbFieldSep);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(583, 378);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(583, 400);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRecords,
            this.lblWarnings});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(583, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // lblRecords
            // 
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(83, 17);
            this.lblRecords.Text = "0 records found";
            // 
            // lblWarnings
            // 
            this.lblWarnings.Name = "lblWarnings";
            this.lblWarnings.Size = new System.Drawing.Size(0, 17);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(327, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(170, 347);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbDescription);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbIndex);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbAltitude);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbLongitude);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbLatitude);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(244, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 125);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fields";
            // 
            // cmbDescription
            // 
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Location = new System.Drawing.Point(223, 73);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(98, 21);
            this.cmbDescription.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Desc:";
            // 
            // cmbName
            // 
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(223, 47);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(98, 21);
            this.cmbName.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Name:";
            // 
            // cmbDate
            // 
            this.cmbDate.FormattingEnabled = true;
            this.cmbDate.Location = new System.Drawing.Point(223, 20);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(98, 21);
            this.cmbDate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Date:";
            // 
            // cmbAltitude
            // 
            this.cmbAltitude.FormattingEnabled = true;
            this.cmbAltitude.Location = new System.Drawing.Point(60, 73);
            this.cmbAltitude.Name = "cmbAltitude";
            this.cmbAltitude.Size = new System.Drawing.Size(98, 21);
            this.cmbAltitude.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Altitude:";
            // 
            // cmbLongitude
            // 
            this.cmbLongitude.FormattingEnabled = true;
            this.cmbLongitude.Location = new System.Drawing.Point(60, 46);
            this.cmbLongitude.Name = "cmbLongitude";
            this.cmbLongitude.Size = new System.Drawing.Size(98, 21);
            this.cmbLongitude.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Longitude:";
            // 
            // cmbLatitude
            // 
            this.cmbLatitude.FormattingEnabled = true;
            this.cmbLatitude.Location = new System.Drawing.Point(60, 19);
            this.cmbLatitude.Name = "cmbLatitude";
            this.cmbLatitude.Size = new System.Drawing.Size(98, 21);
            this.cmbLatitude.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Latitude:";
            // 
            // ckHeaderRow
            // 
            this.ckHeaderRow.AutoSize = true;
            this.ckHeaderRow.Location = new System.Drawing.Point(15, 120);
            this.ckHeaderRow.Name = "ckHeaderRow";
            this.ckHeaderRow.Size = new System.Drawing.Size(188, 17);
            this.ckHeaderRow.TabIndex = 4;
            this.ckHeaderRow.Text = "First Row Contains Column Names";
            this.ckHeaderRow.UseVisualStyleBackColor = true;
            this.ckHeaderRow.CheckedChanged += new System.EventHandler(this.ckHeaderRow_CheckedChanged);
            // 
            // listData
            // 
            this.listData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listData.Location = new System.Drawing.Point(15, 143);
            this.listData.Name = "listData";
            this.listData.Size = new System.Drawing.Size(556, 198);
            this.listData.TabIndex = 3;
            this.listData.UseCompatibleStateImageBehavior = false;
            this.listData.View = System.Windows.Forms.View.Details;
            // 
            // txtComment
            // 
            this.txtComment.Enabled = false;
            this.txtComment.Location = new System.Drawing.Point(201, 94);
            this.txtComment.MaxLength = 1;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(27, 20);
            this.txtComment.TabIndex = 2;
            this.txtComment.Text = "#";
            // 
            // txtQuoteOther
            // 
            this.txtQuoteOther.Enabled = false;
            this.txtQuoteOther.Location = new System.Drawing.Point(201, 68);
            this.txtQuoteOther.MaxLength = 1;
            this.txtQuoteOther.Name = "txtQuoteOther";
            this.txtQuoteOther.Size = new System.Drawing.Size(27, 20);
            this.txtQuoteOther.TabIndex = 2;
            this.txtQuoteOther.Text = "\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Comments";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quote Symbol";
            // 
            // cmbComments
            // 
            this.cmbComments.FormattingEnabled = true;
            this.cmbComments.Items.AddRange(new object[] {
            "None",
            "Hash (#)",
            "Other"});
            this.cmbComments.Location = new System.Drawing.Point(94, 93);
            this.cmbComments.Name = "cmbComments";
            this.cmbComments.Size = new System.Drawing.Size(101, 21);
            this.cmbComments.TabIndex = 1;
            this.cmbComments.SelectedIndexChanged += new System.EventHandler(this.cmbComments_SelectedIndexChanged);
            // 
            // cmbQuote
            // 
            this.cmbQuote.FormattingEnabled = true;
            this.cmbQuote.Items.AddRange(new object[] {
            "None",
            "Double Quote (\")",
            "Single Quote (\')",
            "Other"});
            this.cmbQuote.Location = new System.Drawing.Point(94, 67);
            this.cmbQuote.Name = "cmbQuote";
            this.cmbQuote.Size = new System.Drawing.Size(101, 21);
            this.cmbQuote.TabIndex = 1;
            this.cmbQuote.SelectedIndexChanged += new System.EventHandler(this.cmbQuote_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Index:";
            // 
            // cmbIndex
            // 
            this.cmbIndex.FormattingEnabled = true;
            this.cmbIndex.Location = new System.Drawing.Point(60, 100);
            this.cmbIndex.Name = "cmbIndex";
            this.cmbIndex.Size = new System.Drawing.Size(98, 21);
            this.cmbIndex.TabIndex = 6;
            // 
            // CsvFormatDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(583, 400);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "CsvFormatDialog";
            this.Text = "CSV Options";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLineSep;
        private System.Windows.Forms.TextBox txtLineSepOther;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFieldSep;
        private System.Windows.Forms.TextBox txtFieldSepOther;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecords;
        private System.Windows.Forms.ListView listData;
        private System.Windows.Forms.ToolStripStatusLabel lblWarnings;
        private System.Windows.Forms.TextBox txtQuoteOther;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbQuote;
        private System.Windows.Forms.CheckBox ckHeaderRow;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbComments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLatitude;
        private System.Windows.Forms.ComboBox cmbDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbAltitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbLongitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbIndex;
        private System.Windows.Forms.Label label11;
    }
}