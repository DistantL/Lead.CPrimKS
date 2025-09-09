using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Global;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper.ComplexInterpolation
{
    public class MoveConfig : Form
	{
		private IEleCartesian _cart;

		private ActionConfig _action;

		private IContainer components = null;

		private SplitContainer splitContainer1;

		private TextBox tbTAccDec;

		private Label label3;

		private ComboBox cmbSpeed;

		private Label label2;

		private ComboBox cmbElementName;

		private Label lbElement;

		private FlowLayoutPanel flowMain;

		public MoveConfig()
		{
			InitializeComponent();
		}

		public MoveConfig(ActionConfig action)
		{
			InitializeComponent();
			_action = action;
		}

		private void lbElement_Click(object sender, EventArgs e)
		{
			if (ElesManagerTransfer.GetAllIEle().Count < 1)
			{
				return;
			}
			cmbElementName.SelectedIndex = -1;
			cmbElementName.Items.Clear();
			ElesManagerTransfer.GetAllIEle().ForEach(delegate(IEle ele)
			{
				if (ele is IEleCartesian)
				{
					cmbElementName.Items.Add(ele.Name);
				}
			});
		}

		private void cmbElementName_SelectedIndexChanged(object sender, EventArgs e)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			if (cmbElementName.SelectedIndex != -1 && !string.IsNullOrEmpty(cmbElementName.SelectedItem.ToString()))
			{
				_cart = (IEleCartesian)ElesManagerTransfer.GetEleByName(cmbElementName.SelectedItem.ToString());
				UpdateAxises();
			}
		}

		private void UpdateAxises()
		{
			flowMain.Controls.Clear();
			for (int i = 0; i < _cart.Axises.Count; i++)
			{
				flowMain.Controls.Add(new AxisTeach(_cart, i));
			}
		}

		private void MoveConfig_Load(object sender, EventArgs e)
		{
			lbElement_Click(null, null);
			if (!string.IsNullOrEmpty(_action.CartesianName))
			{
				if (!cmbElementName.Items.Contains(_action.CartesianName))
				{
					cmbElementName.Items.Add(_action.CartesianName);
				}
				cmbElementName.SelectedItem = _action.CartesianName;
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tbTAccDec = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbSpeed = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbElementName = new System.Windows.Forms.ComboBox();
			this.lbElement = new System.Windows.Forms.Label();
			this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
			((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.splitContainer1.Panel1.Controls.Add(this.tbTAccDec);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.cmbSpeed);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.cmbElementName);
			this.splitContainer1.Panel1.Controls.Add(this.lbElement);
			this.splitContainer1.Panel2.Controls.Add(this.flowMain);
			this.splitContainer1.Size = new System.Drawing.Size(984, 612);
			this.splitContainer1.SplitterDistance = 42;
			this.splitContainer1.TabIndex = 0;
			this.tbTAccDec.Font = new System.Drawing.Font("微软雅黑", 7.5f);
			this.tbTAccDec.Location = new System.Drawing.Point(638, 12);
			this.tbTAccDec.Name = "tbTAccDec";
			this.tbTAccDec.Size = new System.Drawing.Size(90, 21);
			this.tbTAccDec.TabIndex = 92;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label3.Location = new System.Drawing.Point(461, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(171, 20);
			this.label3.TabIndex = 91;
			this.label3.Text = "加减速度（mm/s²）：";
			this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSpeed.DropDownWidth = 96;
			this.cmbSpeed.Font = new System.Drawing.Font("微软雅黑", 7.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.cmbSpeed.FormattingEnabled = true;
			this.cmbSpeed.Items.AddRange(new object[10] { "100", "90", "80", "70", "60", "50", "40", "30", "20", "10" });
			this.cmbSpeed.Location = new System.Drawing.Point(348, 10);
			this.cmbSpeed.Name = "cmbSpeed";
			this.cmbSpeed.Size = new System.Drawing.Size(96, 24);
			this.cmbSpeed.TabIndex = 90;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label2.Location = new System.Drawing.Point(245, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 25);
			this.label2.TabIndex = 89;
			this.label2.Text = "速度百分比";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbElementName.DropDownWidth = 96;
			this.cmbElementName.Font = new System.Drawing.Font("微软雅黑", 7.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.cmbElementName.FormattingEnabled = true;
			this.cmbElementName.Items.AddRange(new object[2] { "Robot", "MotionCard" });
			this.cmbElementName.Location = new System.Drawing.Point(119, 10);
			this.cmbElementName.Name = "cmbElementName";
			this.cmbElementName.Size = new System.Drawing.Size(96, 24);
			this.cmbElementName.TabIndex = 88;
			this.cmbElementName.SelectedIndexChanged += new System.EventHandler(cmbElementName_SelectedIndexChanged);
			this.lbElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbElement.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.lbElement.Location = new System.Drawing.Point(16, 10);
			this.lbElement.Name = "lbElement";
			this.lbElement.Size = new System.Drawing.Size(95, 25);
			this.lbElement.TabIndex = 87;
			this.lbElement.Text = "元件关联：";
			this.lbElement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbElement.Click += new System.EventHandler(lbElement_Click);
			this.flowMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowMain.Location = new System.Drawing.Point(0, 0);
			this.flowMain.Name = "flowMain";
			this.flowMain.Size = new System.Drawing.Size(984, 566);
			this.flowMain.TabIndex = 0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(984, 612);
			base.Controls.Add(this.splitContainer1);
			this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "MoveConfig";
			this.Text = "MoveConfig";
			base.Load += new System.EventHandler(MoveConfig_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
			this.splitContainer1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
