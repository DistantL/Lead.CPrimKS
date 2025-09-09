using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.ComplexInterpolation;

namespace Lead.CPrim.CmpTrigHelper
{
	public class DelayCtrl : UserControl, ICmpCtrl
	{
		public ActionConfig _action;

		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private Label labID;

		private Label label2;

		private Label label5;

		private TextBox txbMsg;

		private TextBox txbTims;

		public DelayCtrl()
		{
			InitializeComponent();
		}

		public DelayCtrl(ActionConfig actionConfig)
		{
			InitializeComponent();
			_action = actionConfig;
			RefreshUI();
		}

		public void RefreshUI()
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new Action(RefreshUI));
				return;
			}
			labID.Text = _action.Index.ToString();
			txbTims.Text = _action.DelayTime1S_1.ToString();
		}

		public void ApplyConfig()
		{
			_action.DelayTime1S_1 = (double.TryParse(txbTims.Text, out var result) ? result : 1.0);
			_action.Msg = txbMsg.Text;
		}

		public void RefreshIndex(int index)
		{
			if (labID.InvokeRequired)
			{
				BeginInvoke(new Action<int>(RefreshIndex), index);
			}
			else
			{
				_action.Index = index;
				labID.Text = index.ToString();
			}
		}

		private void label2_DoubleClick(object sender, EventArgs e)
		{
			_action.IsSelected = !_action.IsSelected;
		}

		private void DelayCtrl_Load(object sender, EventArgs e)
		{
			txbMsg.Text = _action.Msg;
			RefreshUI();
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labID = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txbMsg = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txbTims = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel1.Controls.Add(this.labID, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.txbMsg, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label5, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.txbTims, 4, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 33);
			this.tableLayoutPanel1.TabIndex = 0;
			this.labID.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.labID.AutoSize = true;
			this.labID.Font = new System.Drawing.Font("幼圆", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.labID.Location = new System.Drawing.Point(5, 8);
			this.labID.Name = "labID";
			this.labID.Size = new System.Drawing.Size(44, 16);
			this.labID.TabIndex = 0;
			this.labID.Text = "01";
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("幼圆", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label2.Location = new System.Drawing.Point(57, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "延时等待";
			this.label2.DoubleClick += new System.EventHandler(label2_DoubleClick);
			this.txbMsg.Location = new System.Drawing.Point(139, 5);
			this.txbMsg.Name = "txbMsg";
			this.txbMsg.Size = new System.Drawing.Size(144, 21);
			this.txbMsg.TabIndex = 8;
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("幼圆", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label5.Location = new System.Drawing.Point(291, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "时间(S)";
			this.txbTims.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txbTims.Location = new System.Drawing.Point(368, 6);
			this.txbTims.Name = "txbTims";
			this.txbTims.Size = new System.Drawing.Size(54, 21);
			this.txbTims.TabIndex = 7;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.LightGray;
			base.Controls.Add(this.tableLayoutPanel1);
			base.Name = "DelayCtrl";
			base.Size = new System.Drawing.Size(1000, 33);
			base.Load += new System.EventHandler(DelayCtrl_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
