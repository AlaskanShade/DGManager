using System;
using System.Windows.Forms;

namespace DGManager
{
	public class RadioCheckRenderer : ToolStripProfessionalRenderer
	{
		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
		{
			if ((string)e.Item.Tag == "Radio")
			{
				RadioButtonRenderer.DrawRadioButton(e.Graphics, e.ImageRectangle.Location,
				                                    System.Windows.Forms.VisualStyles.RadioButtonState.CheckedNormal);
			}
			else
			{
				base.OnRenderItemCheck(e);
			}
		}
	}
}
