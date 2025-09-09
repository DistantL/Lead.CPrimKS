using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.PrimYouShangRFID
{
	public class PrimDebugControl : UserControl
	{
		private IContainer components = null;

		public PrimDebugControl()
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
