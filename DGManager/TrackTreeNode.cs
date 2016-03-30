using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DGManager.Backend;

namespace DGManager
{
    public class TrackTreeNode : TreeNode
    {
        public PointOfInterestList Track { get; set; }

        public TrackTreeNode(string text)
            : base(text)
        {
        }
    }
}
