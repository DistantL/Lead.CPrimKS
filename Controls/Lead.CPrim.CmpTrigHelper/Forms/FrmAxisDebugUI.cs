using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.ComplexInterpolation;
using Lead.CPrim.Interfaces.Ele;

namespace Lead.CPrim.CmpTrigHelper
{
	public class FrmAxisDebugUI : Form
	{
		private IEleCartesian ele;

		private IContainer components = null;

		private FlowLayoutPanel flowLayoutPanel1;

		private Timer timer1;

		public FrmAxisDebugUI(IEleCartesian ele)
		{
			InitializeComponent();
			this.ele = ele;
		}

		private void FrmAxisDebugUI_Load(object sender, EventArgs e)
		{
			if (ele != null)
			{
				for (int i = 0; i < ele.Axises.Count; i++)
				{
					flowLayoutPanel1.Controls.Add(new AxisTeach(ele, i));
				}
				timer1.Start();
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			foreach (object control in flowLayoutPanel1.Controls)
			{
				((AxisTeach)control).CycleUpdate();
			}
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
			this.components = new System.ComponentModel.Container();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(891, 508);
			this.flowLayoutPanel1.TabIndex = 0;
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new System.EventHandler(timer1_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(891, 508);
			base.Controls.Add(this.flowLayoutPanel1);
			base.Name = "FrmAxisDebugUI";
			this.Text = "FrmAxisDebugUI";
			base.Load += new System.EventHandler(FrmAxisDebugUI_Load);
			base.ResumeLayout(false);
		}
	}
}
