using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DGManager
{
	/// <summary>
	/// Summary description for TreeViewMultiSelect.
	/// </summary>
	public class TreeViewMultiSelect : TreeView
	{
		private List<TreeNode>		_coll;
		private TreeNode		_firstNode;

		public TreeViewMultiSelect()
		{
			_coll = new List<TreeNode>();
		}

        public IEnumerable<TreeNode> SelectedNodes
        {
            get
            {
                foreach (TreeNode node in _coll)
                    yield return node;
            }
        }

// Triggers
//
// (overriden method, and base class called to ensure events are triggered)


		protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
		{
			base.OnBeforeSelect(e);
				
			bool bControl = (ModifierKeys==Keys.Control);
			bool bShift = (ModifierKeys==Keys.Shift);

			// selecting twice the node while pressing CTRL ?
			if (bControl && _coll.Contains( e.Node ) )
			{
				// unselect it (let framework know we don't want selection this time)
				e.Cancel = true;
	
				// update nodes
				RemovePaintFromNodes();
				_coll.Remove( e.Node );
				PaintSelectedNodes();
				return;
			}

			//m_lastNode = e.Node;
			if (!bShift) _firstNode = e.Node; // store begin of shift sequence
		}


		protected override void OnAfterSelect(TreeViewEventArgs e)
		{
			base.OnAfterSelect(e);

			bool bControl = (ModifierKeys==Keys.Control);
			bool bShift = (ModifierKeys==Keys.Shift);

			if (bControl)
			{
				if ( !_coll.Contains( e.Node ) ) // new node ?
				{
					_coll.Add( e.Node );
				}
				else  // not new, remove it from the collection
				{
					RemovePaintFromNodes();
					_coll.Remove( e.Node );
				}
				PaintSelectedNodes();
			}
			else 
			{
				// SHIFT is pressed
				if (bShift)
				{
					Queue<TreeNode> myQueue = new Queue<TreeNode>();
					
					TreeNode uppernode = _firstNode;
					TreeNode bottomnode = e.Node;
					// case 1 : begin and end nodes are parent
					bool bParent = IsParent(_firstNode, e.Node); // is m_firstNode parent (direct or not) of e.Node
					if (!bParent)
					{
						bParent = IsParent(bottomnode, uppernode);
						if (bParent) // swap nodes
						{
							TreeNode t = uppernode;
							uppernode = bottomnode;
							bottomnode = t;
						}
					}
					if (bParent)
					{
						TreeNode n = bottomnode;
						while ( n != uppernode.Parent)
						{
							if ( !_coll.Contains( n ) ) // new node ?
								myQueue.Enqueue( n );

							n = n.Parent;
						}
					}
						// case 2 : nor the begin nor the end node are descendant one another
					else
					{
						if ( (uppernode.Parent==null && bottomnode.Parent==null) || (uppernode.Parent!=null && uppernode.Parent.Nodes.Contains( bottomnode )) ) // are they siblings ?
						{
							int nIndexUpper = uppernode.Index;
							int nIndexBottom = bottomnode.Index;
							if (nIndexBottom < nIndexUpper) // reversed?
							{
								TreeNode t = uppernode;
								uppernode = bottomnode;
								bottomnode = t;
								nIndexUpper = uppernode.Index;
								nIndexBottom = bottomnode.Index;
							}

							TreeNode n = uppernode;
							while (nIndexUpper <= nIndexBottom)
							{
								if ( !_coll.Contains( n ) ) // new node ?
									myQueue.Enqueue( n );
								
								n = n.NextNode;

								nIndexUpper++;
							} // end while
							
						}
						else
						{
							if ( !_coll.Contains( uppernode ) ) myQueue.Enqueue( uppernode );
							if ( !_coll.Contains( bottomnode ) ) myQueue.Enqueue( bottomnode );
						}
					}

					_coll.AddRange( myQueue );

					PaintSelectedNodes();
					_firstNode = e.Node; // let us chain several SHIFTs if we like it
				} // end if m_bShift
				else
				{
					// in the case of a simple click, just add this item
					if (_coll!=null && _coll.Count>0)
					{
						RemovePaintFromNodes();
						_coll.Clear();
					}
					_coll.Add( e.Node );
				}
			}
		}



// Helpers
//
//


		protected static bool IsParent(TreeNode parentNode, TreeNode childNode)
		{
			if (parentNode==childNode)
				return true;

			TreeNode n = childNode;
			bool bFound = false;
			while (!bFound && n!=null)
			{
				n = n.Parent;
				bFound = (n == parentNode);
			}
			return bFound;
		}

		protected void PaintSelectedNodes()
		{
            _coll.ForEach(n =>
            {
                n.BackColor = SystemColors.Highlight;
                n.ForeColor = SystemColors.HighlightText;
            });
		}

		protected void RemovePaintFromNodes()
		{
			if (_coll.Count==0) return;

			TreeNode n0 = (TreeNode) _coll[0];

			if (n0 == null || n0.TreeView == null || n0.TreeView.BackColor == null)
			{
				return;
			}

			Color back = n0.TreeView.BackColor;
			Color fore = n0.TreeView.ForeColor;

            _coll.ForEach(n =>
            {
                n.BackColor = back;
                n.ForeColor = fore;
            });

		}

	}
}
