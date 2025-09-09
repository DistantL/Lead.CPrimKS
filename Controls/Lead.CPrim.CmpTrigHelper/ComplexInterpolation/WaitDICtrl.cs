using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.ComplexInterpolation;

namespace Lead.CPrim.CmpTrigHelper
{
	public class WaitDICtrl : UserControl, ICmpCtrl
	{
		public ActionConfig _action;

		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private TextBox txbDelay;

		private Label label5;

		private Label label4;

		private Label label3;

		private Label labID;

		private Label label2;

		private TextBox txbAdr;

		private ComboBox cmbOn_Off;

		private TextBox txbMsg;

		public WaitDICtrl()
		{
			InitializeComponent();
		}

		public WaitDICtrl(ActionConfig actionConfig)
		{
			InitializeComponent();
			_action = actionConfig;
		}

		public void RefreshUI()
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new Action(RefreshUI));
				return;
			}
			txbAdr.Text = _action.IoAdr.ToString();
			txbDelay.Text = _action.DelayTime1S_2.ToString();
			cmbOn_Off.SelectedIndex = ((!_action.On_Off) ? 1 : 0);
			labID.Text = _action.Index.ToString();
		}

		public void ApplyConfig()
		{
			_action.IoAdr = (ushort)(ushort.TryParse(txbAdr.Text, out var result) ? result : 0);
			_action.DelayTime1S_2 = (double.TryParse(txbDelay.Text, out var result2) ? result2 : 0.0);
			_action.On_Off = ((cmbOn_Off.SelectedIndex == 0) ? true : false);
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

		private void WaitDICtrl_Load(object sender, EventArgs e)
		{
			RefreshUI();
			txbMsg.Text = _action.Msg;
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
            this.label3 = new System.Windows.Forms.Label();
            this.txbAdr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOn_Off = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txbMsg, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txbAdr, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txbDelay, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbOn_Off, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1250, 41);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labID
            // 
            this.labID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labID.AutoSize = true;
            this.labID.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labID.Location = new System.Drawing.Point(6, 10);
            this.labID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(54, 20);
            this.labID.TabIndex = 0;
            this.labID.Text = "01";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(70, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "等待DI";
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // txbMsg
            // 
            this.txbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbMsg.Location = new System.Drawing.Point(172, 6);
            this.txbMsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbMsg.Name = "txbMsg";
            this.txbMsg.Size = new System.Drawing.Size(180, 25);
            this.txbMsg.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(362, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "DI序号";
            // 
            // txbAdr
            // 
            this.txbAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAdr.Location = new System.Drawing.Point(458, 8);
            this.txbAdr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbAdr.Name = "txbAdr";
            this.txbAdr.Size = new System.Drawing.Size(67, 25);
            this.txbAdr.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(535, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "DI触发模式";
            // 
            // txbDelay
            // 
            this.txbDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDelay.Location = new System.Drawing.Point(960, 8);
            this.txbDelay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbDelay.Name = "txbDelay";
            this.txbDelay.Size = new System.Drawing.Size(73, 25);
            this.txbDelay.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(770, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "等待超时时间(S)";
            // 
            // cmbOn_Off
            // 
            this.cmbOn_Off.FormattingEnabled = true;
            this.cmbOn_Off.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this.cmbOn_Off.Location = new System.Drawing.Point(662, 6);
            this.cmbOn_Off.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbOn_Off.Name = "cmbOn_Off";
            this.cmbOn_Off.Size = new System.Drawing.Size(98, 23);
            this.cmbOn_Off.TabIndex = 5;
            // 
            // WaitDICtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WaitDICtrl";
            this.Size = new System.Drawing.Size(1250, 41);
            this.Load += new System.EventHandler(this.WaitDICtrl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
