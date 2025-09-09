using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.Global;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper.ComplexInterpolation
{
    public class MoveIcon : UserControl, ICmpCtrl
	{
		private MoveConfig _configForm;

		private ActionConfig _action;

		private IEleCartesian _cart;

		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private TextBox txbPos;

		private Label label4;

		private Label label3;

		private Label labID;

		private Label label2;

		private TextBox txbSpeed;

		private Button btnMove;

		private TextBox txbMsg;

		private Button btnGet;

		public MoveIcon()
		{
			InitializeComponent();
		}

		public MoveIcon(ActionConfig action)
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			InitializeComponent();
			_action = action;
			_cart = (IEleCartesian)ElesManagerTransfer.GetEleByName(_action.CartesianName);
		}

		private void tsmMovePoint_Click(object sender, EventArgs e)
		{
		}

		private void tsmConfig_Click(object sender, EventArgs e)
		{
			if (_configForm == null || _configForm.IsDisposed)
			{
				_configForm = new MoveConfig(_action);
			}
			_configForm.Show();
		}

		public void RefreshUI()
		{
			labID.Text = _action.Index.ToString();
			txbSpeed.Text = _action.Vm.ToString();
			string text = "";
			double[] array = _action.Pos;
			if (array == null)
			{
				array = new double[8];
			}
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i];
				if (i != array.Length - 1)
				{
					text += ",";
				}
			}
			txbPos.Text = text;
		}

		public void ApplyConfig()
		{
			string[] array = txbPos.Text.Split(',');
			double[] array2 = new double[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = (double.TryParse(array[i], out var result) ? result : 0.0);
			}
			_action.Pos = array2;
			_action.CartesianName = _action.CrdManger.EleName;
			_action.Vm = (double.TryParse(txbSpeed.Text, out var result2) ? result2 : 10.0);
			_action.Msg = txbMsg.Text;
		}

		private void btnGet_Click(object sender, EventArgs e)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			_cart = (IEleCartesian)ElesManagerTransfer.GetEleByName(_action.CartesianName);
			if (_cart == null)
			{
				MessageBox.Show("请重新选择轴组！", "", MessageBoxButtons.OK);
				return;
			}
			double[] array = _cart.PosToArray(_cart.GetActualPos());
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i];
				if (i != array.Length - 1)
				{
					text += ",";
				}
			}
			txbPos.Text = text;
		}

		private void MoveIcon_Load(object sender, EventArgs e)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			if (_action != null)
			{
				_cart = (IEleCartesian)ElesManagerTransfer.GetEleByName(_action.CartesianName);
				RefreshUI();
				txbMsg.Text = _action.Msg;
			}
		}

		private void label2_DoubleClick(object sender, EventArgs e)
		{
			_action.IsSelected = !_action.IsSelected;
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

		private void btnMove_Click(object sender, EventArgs e)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			_cart = (IEleCartesian)ElesManagerTransfer.GetEleByName(_action.CartesianName);
			if (_cart == null)
			{
				MessageBox.Show("请重新选择轴组！", "", MessageBoxButtons.OK);
			}
			else
			{
				_cart.GroupMoveAbs(_action.Pos, (ushort)50, -1, true, true, (ITask)null, (EleAlarmLevel)2);
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labID = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txbMsg = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txbSpeed = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txbPos = new System.Windows.Forms.TextBox();
			this.btnMove = new System.Windows.Forms.Button();
			this.btnGet = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel1.ColumnCount = 10;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.labID, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.txbMsg, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.txbSpeed, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.txbPos, 6, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnMove, 7, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnGet, 8, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 33);
			this.tableLayoutPanel1.TabIndex = 1;
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
			this.label2.Text = "运动控制";
			this.label2.DoubleClick += new System.EventHandler(label2_DoubleClick);
			this.txbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txbMsg.Location = new System.Drawing.Point(139, 5);
			this.txbMsg.Name = "txbMsg";
			this.txbMsg.Size = new System.Drawing.Size(144, 23);
			this.txbMsg.TabIndex = 8;
			this.txbMsg.Text = "启动位置";
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("幼圆", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label3.Location = new System.Drawing.Point(291, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "段速度";
			this.txbSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txbSpeed.Location = new System.Drawing.Point(368, 5);
			this.txbSpeed.Name = "txbSpeed";
			this.txbSpeed.Size = new System.Drawing.Size(54, 23);
			this.txbSpeed.TabIndex = 3;
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("幼圆", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label4.Location = new System.Drawing.Point(430, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "点位:";
			this.txbPos.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txbPos.Location = new System.Drawing.Point(487, 5);
			this.txbPos.Name = "txbPos";
			this.txbPos.Size = new System.Drawing.Size(274, 23);
			this.txbPos.TabIndex = 5;
			this.txbPos.Text = "0.00,0.00,0.00,0.00,0.00,0.00";
			this.btnMove.Location = new System.Drawing.Point(769, 5);
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new System.Drawing.Size(74, 23);
			this.btnMove.TabIndex = 7;
			this.btnMove.Text = "移动测试";
			this.btnMove.UseVisualStyleBackColor = true;
			this.btnMove.Click += new System.EventHandler(btnMove_Click);
			this.btnGet.Location = new System.Drawing.Point(851, 5);
			this.btnGet.Name = "btnGet";
			this.btnGet.Size = new System.Drawing.Size(69, 23);
			this.btnGet.TabIndex = 6;
			this.btnGet.Text = "获取点位";
			this.btnGet.UseVisualStyleBackColor = true;
			this.btnGet.Click += new System.EventHandler(btnGet_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.LightGray;
			base.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "MoveIcon";
			base.Size = new System.Drawing.Size(1000, 33);
			base.Load += new System.EventHandler(MoveIcon_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
