using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.ConfigClass;

namespace Lead.CPrim.CmpTrigHelper.CmpTrigUIs
{
	public class LinearTrigConfigControl : UserControl
	{
		private LinearTrigData _linearTrigData;

		private IContainer components = null;

		private Button btnApply;

		private ToolStrip tsLinearTrig;

		private ToolStripLabel toolStripLabel1;

		private ToolStripTextBox tsTbName;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tsTbId;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox tsTbIncrement;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox tsTbTrigCount;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox tsTbStartPos;

		public LinearTrigConfigControl(LinearTrigData linearTrigData)
		{
			InitializeComponent();
			_linearTrigData = linearTrigData;
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tsTbName.Text) || string.IsNullOrEmpty(tsTbId.Text))
			{
				MessageBox.Show("线性触发名称或ID不允许为空！");
				return;
			}
			_linearTrigData.Name = tsTbName.Text;
			_linearTrigData.Id = int.Parse(tsTbId.Text);
			_linearTrigData.Increment = double.Parse(tsTbIncrement.Text);
			_linearTrigData.TrigCount = int.Parse(tsTbTrigCount.Text);
			_linearTrigData.StartPos = double.Parse(tsTbStartPos.Text);
		}

		private void LinearTrigConfigControl_Load(object sender, EventArgs e)
		{
			TbCmbInit(_linearTrigData);
		}

		private void TbCmbInit(LinearTrigData linearTrigData)
		{
			tsTbName.Text = linearTrigData.Name;
			tsTbId.Text = linearTrigData.Id.ToString();
			tsTbIncrement.Text = linearTrigData.Increment.ToString();
			tsTbTrigCount.Text = linearTrigData.TrigCount.ToString();
			tsTbStartPos.Text = linearTrigData.StartPos.ToString();
		}

		private void ToolStripLabel1_Click(object sender, EventArgs e)
		{
			_linearTrigData.IsSelected = !_linearTrigData.IsSelected;
		}

		private void tsLinearTrig_DoubleClick(object sender, EventArgs e)
		{
			_linearTrigData.IsSelected = !_linearTrigData.IsSelected;
		}

		private void tsTbId_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
			{
				e.Handled = true;
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
			this.btnApply = new System.Windows.Forms.Button();
			this.tsLinearTrig = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tsTbName = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tsTbId = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tsTbIncrement = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.tsTbTrigCount = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.tsTbStartPos = new System.Windows.Forms.ToolStripTextBox();
			this.tsLinearTrig.SuspendLayout();
			base.SuspendLayout();
			this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
			this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnApply.Location = new System.Drawing.Point(727, 0);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(62, 29);
			this.btnApply.TabIndex = 67;
			this.btnApply.Text = "应用";
			this.btnApply.UseVisualStyleBackColor = false;
			this.btnApply.Click += new System.EventHandler(btnApply_Click);
			this.tsLinearTrig.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tsLinearTrig.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tsLinearTrig.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.toolStripLabel1, this.tsTbName, this.toolStripLabel2, this.tsTbId, this.toolStripLabel3, this.tsTbIncrement, this.toolStripLabel4, this.tsTbTrigCount, this.toolStripSeparator1, this.toolStripLabel5,
				this.tsTbStartPos
			});
			this.tsLinearTrig.Location = new System.Drawing.Point(0, 0);
			this.tsLinearTrig.Name = "tsLinearTrig";
			this.tsLinearTrig.Size = new System.Drawing.Size(792, 27);
			this.tsLinearTrig.TabIndex = 68;
			this.tsLinearTrig.Text = "toolStrip1";
			this.tsLinearTrig.DoubleClick += new System.EventHandler(tsLinearTrig_DoubleClick);
			this.toolStripLabel1.Enabled = false;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(92, 24);
			this.toolStripLabel1.Text = "线性触发名称：";
			this.toolStripLabel1.Click += new System.EventHandler(ToolStripLabel1_Click);
			this.toolStripLabel1.DoubleClick += new System.EventHandler(tsLinearTrig_DoubleClick);
			this.tsTbName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
			this.tsTbName.Name = "tsTbName";
			this.tsTbName.Size = new System.Drawing.Size(100, 27);
			this.tsTbName.ToolTipText = "线性触发名称";
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(33, 24);
			this.toolStripLabel2.Text = "ID：";
			this.tsTbId.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
			this.tsTbId.Name = "tsTbId";
			this.tsTbId.Size = new System.Drawing.Size(50, 27);
			this.tsTbId.ToolTipText = "线性触发ID";
			this.tsTbId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tsTbId_KeyPress);
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(44, 24);
			this.toolStripLabel3.Text = "增量：";
			this.tsTbIncrement.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
			this.tsTbIncrement.Name = "tsTbIncrement";
			this.tsTbIncrement.Size = new System.Drawing.Size(60, 27);
			this.tsTbIncrement.ToolTipText = "增量值";
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(68, 24);
			this.toolStripLabel4.Text = "触发次数：";
			this.tsTbTrigCount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
			this.tsTbTrigCount.Name = "tsTbTrigCount";
			this.tsTbTrigCount.Size = new System.Drawing.Size(80, 27);
			this.tsTbTrigCount.ToolTipText = "触发次数";
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(68, 24);
			this.toolStripLabel5.Text = "触发起始：";
			this.tsTbStartPos.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
			this.tsTbStartPos.Name = "tsTbStartPos";
			this.tsTbStartPos.Size = new System.Drawing.Size(80, 27);
			this.tsTbStartPos.ToolTipText = "触发次数";
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			base.Controls.Add(this.btnApply);
			base.Controls.Add(this.tsLinearTrig);
			this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "LinearTrigConfigControl";
			base.Size = new System.Drawing.Size(792, 27);
			base.Load += new System.EventHandler(LinearTrigConfigControl_Load);
			this.tsLinearTrig.ResumeLayout(false);
			this.tsLinearTrig.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
