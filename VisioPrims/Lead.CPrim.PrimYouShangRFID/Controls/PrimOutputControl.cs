using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.PrimYouShangRFID
{
	public class PrimOutputControl : UserControl
	{
		private IContainer components = null;

		public PrimOutputControl()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		}
	}
}
