using System;
using System.Windows.Forms;

namespace DGManager
{
    public partial class ReducePointsDialog : Form
    {
        public int TargetNumber { get { return (int)upDownTarget.Value; } set { upDownTarget.Maximum = value; upDownTarget.Value = value; } }

        public ReducePointsDialog()
        {
            InitializeComponent();
        }
    }
}