namespace DGManager
{
  partial class GMapLocationSelecterDialog
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
		 this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		 this.button1 = new System.Windows.Forms.Button();
		 this.button2 = new System.Windows.Forms.Button();
		 this.PleaseWaitLabel = new System.Windows.Forms.Label();
		 this.SuspendLayout();
		 // 
		 // webBrowser1
		 // 
		 this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
		 this.webBrowser1.Location = new System.Drawing.Point(0, 0);
		 this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		 this.webBrowser1.Name = "webBrowser1";
		 this.webBrowser1.ScrollBarsEnabled = false;
		 this.webBrowser1.Size = new System.Drawing.Size(726, 548);
		 this.webBrowser1.TabIndex = 0;
		 this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
		 // 
		 // button1
		 // 
		 this.button1.Location = new System.Drawing.Point(457, 495);
		 this.button1.Name = "button1";
		 this.button1.Size = new System.Drawing.Size(135, 41);
		 this.button1.TabIndex = 1;
		 this.button1.Text = "Use Selected Location";
		 this.button1.UseVisualStyleBackColor = true;
		 this.button1.Click += new System.EventHandler(this.button1_Click);
		 // 
		 // button2
		 // 
		 this.button2.Location = new System.Drawing.Point(598, 495);
		 this.button2.Name = "button2";
		 this.button2.Size = new System.Drawing.Size(115, 41);
		 this.button2.TabIndex = 2;
		 this.button2.Text = "Cancel";
		 this.button2.UseVisualStyleBackColor = true;
		 this.button2.Click += new System.EventHandler(this.button2_Click);
		 // 
		 // PleaseWaitLabel
		 // 
		 this.PleaseWaitLabel.AutoSize = true;
		 this.PleaseWaitLabel.BackColor = System.Drawing.SystemColors.Window;
		 this.PleaseWaitLabel.Location = new System.Drawing.Point(283, 268);
		 this.PleaseWaitLabel.Name = "PleaseWaitLabel";
		 this.PleaseWaitLabel.Size = new System.Drawing.Size(161, 13);
		 this.PleaseWaitLabel.TabIndex = 3;
		 this.PleaseWaitLabel.Text = "Please wait for the map to load...";
		 // 
		 // GMapLocationSelecterDialog
		 // 
		 this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		 this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		 this.ClientSize = new System.Drawing.Size(726, 548);
		 this.Controls.Add(this.PleaseWaitLabel);
		 this.Controls.Add(this.button1);
		 this.Controls.Add(this.button2);
		 this.Controls.Add(this.webBrowser1);
		 this.Name = "GMapLocationSelecterDialog";
		 this.Text = "Please Select A Location On The Map";
		 this.Load += new System.EventHandler(this.Form1_Load);
		 this.ResumeLayout(false);
		 this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.WebBrowser webBrowser1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
	  private System.Windows.Forms.Label PleaseWaitLabel;
  }
}

