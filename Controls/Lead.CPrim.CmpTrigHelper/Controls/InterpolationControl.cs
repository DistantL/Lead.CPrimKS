using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.CmpTrigHelper.CmpTrigUIs
{
    public class InterpolationControl : UserControl
	{
		private IEle _ele;

		private InterPolationCfg _interPolationCfg;

		private bool _teachFormOpend;

		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private DataGridView dgTraj;

		private Panel panel1;

		private ComboBox cmbSpeed;

		private Label lb_Speed;

		private Button button4;

		private Button btnUp;

		private Button btnDel;

		private Button btnAdd;

		private Button btnApply;

		private Button btnTeach;

		private ComboBox cmbElementName;

		private Label lbElement;

		private TextBox tbTrajId;

		private Label label1;

		private TextBox tbTrajName;

		private Label lbTrigName;

		private TextBox tbTAccDec;

		private Label lb_TAccDec;

		private DataGridViewTextBoxColumn colPosID;

		private DataGridViewTextBoxColumn colPosX;

		private DataGridViewTextBoxColumn colPosY;

		private DataGridViewTextBoxColumn colPosZ;

		private DataGridViewTextBoxColumn colPosU;

		private DataGridViewTextBoxColumn colPosV;

		private DataGridViewTextBoxColumn colPosW;

		private DataGridViewButtonColumn colTest;

		private DataGridViewButtonColumn colGetPos;

		private DataGridViewTextBoxColumn colVM;

		private DataGridViewTextBoxColumn colRemark;

		private DataGridViewComboBoxColumn colOffset;

		private ComboBox cmbCrd;

		private Label lb_Crd;

		public InterpolationControl()
		{
			InitializeComponent();
		}

		public InterpolationControl(InterPolationCfg interPolationCfg)
		{
			InitializeComponent();
			_interPolationCfg = interPolationCfg;

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tbTrajName.Text) || string.IsNullOrEmpty(tbTrajId.Text))
			{
				MessageBox.Show(NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_ErrMsg_TrigNameIsEmpty", "轨迹名称或轨迹ID不允许为空！"));
				return;
			}
			_interPolationCfg.Name = tbTrajName.Text;
			_interPolationCfg.EleName = cmbElementName.SelectedItem?.ToString();
			if (int.TryParse(tbTrajId.Text, out var result))
			{
				_interPolationCfg.Id = result;
			}
			if (int.TryParse(cmbSpeed.SelectedItem.ToString(), out var result2))
			{
				_interPolationCfg.SpeedRate = result2;
			}
			if (int.TryParse(tbTAccDec.Text, out var result3))
			{
				_interPolationCfg.TAccDec = result3;
			}
			if (ushort.TryParse(cmbCrd.SelectedItem.ToString(), out var result4))
			{
				_interPolationCfg.Crd = result4;
			}
			DgvTransData(ref _interPolationCfg);
		}

		private void btnTeach_Click(object sender, EventArgs e)
		{
			if (_teachFormOpend || _ele == null)
			{
				return;
			}
			List<Pos> list = new List<Pos>();
			foreach (InterPolationPos interPolationPose in _interPolationCfg.InterPolationPoses)
			{
				list.Add(interPolationPose.Pos);
			}
			PlatformDebug platformDebug = new PlatformDebug(_ele, list, ConfigType.Traj, _interPolationCfg.Gid);
			platformDebug.EventUpdatePos += TeachFormOnEventUpdatePos;
			platformDebug.EventUpdateStatus += TeachFormOnEventUpdateStatus;
			platformDebug.Show();
			_teachFormOpend = true;
		}

		private void cmbElementName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbElementName.SelectedIndex != -1 && !string.IsNullOrEmpty(cmbElementName.SelectedItem.ToString()))
			{
				_ele = ElesManagerTransfer.GetEleByName(cmbElementName.SelectedItem.ToString());
			}
		}

		private void DgvFillData(InterPolationCfg interPolation)
		{
			if (interPolation.InterPolationPoses.Count == 0)
			{
				return;
			}
			dgTraj.Rows.Clear();
			int i;
			for (i = 0; i < interPolation.InterPolationPoses.Count; i++)
			{
				dgTraj.Rows.Insert(i);
				InterPolationPos interPolationPos = interPolation.InterPolationPoses.FirstOrDefault((InterPolationPos p) => p.Id == i);
				dgTraj.Rows[i].Cells[1].Value = interPolationPos.Pos.X;
				dgTraj.Rows[i].Cells[2].Value = interPolationPos.Pos.Y;
				dgTraj.Rows[i].Cells[3].Value = interPolationPos.Pos.Z;
				dgTraj.Rows[i].Cells[4].Value = interPolationPos.Pos.U;
				dgTraj.Rows[i].Cells[5].Value = interPolationPos.Pos.V;
				dgTraj.Rows[i].Cells[6].Value = interPolationPos.Pos.W;
				dgTraj.Rows[i].Cells["colRemark"].Value = ((interPolationPos.Pos.Name == "") ? i.ToString() : interPolationPos.Pos.Name);
				dgTraj.Rows[i].Cells["colVM"].Value = interPolationPos.Vm;
				dgTraj.Rows[i].Cells[0].Value = interPolationPos.Id;
				dgTraj.Rows[i].Cells["colOffset"].Value = interPolationPos.offsetType.ToString();
			}
		}

		private void DgvTrajInit()
		{
		}

		private void DgvTransData(ref InterPolationCfg data)
		{
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Expected O, but got Unknown
			data.InterPolationPoses.Clear();
			for (int i = 0; i < dgTraj.Rows.Count; i++)
			{
				InterPolationPos item = new InterPolationPos
				{
					Pos = new Pos(Convert.ToString(dgTraj.Rows[i].Cells["colRemark"].Value), Convert.ToDouble(dgTraj.Rows[i].Cells[1].Value), Convert.ToDouble(dgTraj.Rows[i].Cells[2].Value), Convert.ToDouble(dgTraj.Rows[i].Cells[3].Value), Convert.ToDouble(dgTraj.Rows[i].Cells[4].Value), Convert.ToDouble(dgTraj.Rows[i].Cells[5].Value), Convert.ToDouble(dgTraj.Rows[i].Cells[6].Value)),
					Vm = Convert.ToDouble(dgTraj.Rows[i].Cells["colVM"].Value),
					Id = Convert.ToInt32(dgTraj.Rows[i].Cells["colPosID"].Value),
					offsetType = Convert.ToInt32(dgTraj.Rows[i].Cells["colOffset"].Value)
				};
				data.InterPolationPoses.Add(item);
			}
		}

		private void FindEleAndAxis(string eleName)
		{
			if (!string.IsNullOrEmpty(eleName))
			{
				if (!cmbElementName.Items.Contains(eleName))
				{
					cmbElementName.Items.Add(eleName);
				}
				cmbElementName.SelectedItem = eleName;
				_ele = ElesManagerTransfer.GetEleByName(_interPolationCfg.EleName);
				if (_ele == null)
				{
				}
			}
		}

		private void lbElement_Click(object sender, EventArgs e)
		{
			UpdateEles();
		}

		private void panel1_DoubleClick(object sender, EventArgs e)
		{
			_interPolationCfg.IsSelected = !_interPolationCfg.IsSelected;
		}

		private void TbCmbInit(InterPolationCfg trajData)
		{
			UpdateEles();
			tbTrajName.Text = trajData.Name;
			tbTrajId.Text = trajData.Id.ToString();
			if (!cmbSpeed.Items.Contains(trajData.SpeedRate.ToString()))
			{
				cmbSpeed.Items.Add(trajData.SpeedRate.ToString());
			}
			cmbSpeed.SelectedItem = trajData.SpeedRate.ToString();
			cmbCrd.SelectedItem = trajData.Crd.ToString();
			tbTAccDec.Text = trajData.TAccDec.ToString();
		}

		private void tbTrajId_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void TeachFormOnEventUpdatePos(ConfigType config, Guid gId, object obj)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			Pos techPos = (Pos)obj;
			_interPolationCfg.InterPolationPoses.FirstOrDefault((InterPolationPos p) => p.Pos.Name == techPos.Name).Pos = techPos;
			DgvFillData(_interPolationCfg);
		}

		private void TeachFormOnEventUpdateStatus(Guid gid)
		{
			if (gid == _interPolationCfg.Gid)
			{
				_teachFormOpend = false;
			}
		}

		private void TrajConfigControl_Load(object sender, EventArgs e)
		{
			TbCmbInit(_interPolationCfg);
			FindEleAndAxis(_interPolationCfg.EleName);
			DgvTrajInit();
			DgvFillData(_interPolationCfg);
		}

		private void UpdateEles()
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

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (dgTraj.Rows.Count == 0)
			{
				num = dgTraj.Rows.Add();
			}
			else
			{
				num = dgTraj.CurrentRow.Index + 1;
				dgTraj.Rows.Insert(num, 1);
			}
			dgTraj.Rows[num].Cells[0].Value = num;
			for (int i = 1; i < 7; i++)
			{
				dgTraj.Rows[num].Cells[i].Value = 0;
			}
			dgTraj.Rows[num].Cells["colVm"].Value = 0;
			dgTraj.Rows[num].Cells["colOffset"].Value = "-1";
			RefreshDg();
		}

		private void BtnDel_Click(object sender, EventArgs e)
		{
			if (dgTraj.Rows.Count != 0)
			{
				dgTraj.Rows.RemoveAt(dgTraj.CurrentRow.Index);
				RefreshDg();
			}
		}

		private void BtnDown_Click(object sender, EventArgs e)
		{
			int index = dgTraj.CurrentRow.Index;
			if (index != dgTraj.Rows.Count - 1)
			{
				DataGridViewRow dataGridViewRow = dgTraj.Rows[index];
				dgTraj.Rows.RemoveAt(index);
				dgTraj.Rows.Insert(index + 1, dataGridViewRow);
				RefreshDg();
			}
		}

		private void BtnUp_Click(object sender, EventArgs e)
		{
			if (dgTraj.Rows.Count != 0)
			{
				int index = dgTraj.CurrentRow.Index;
				if (index != 0)
				{
					DataGridViewRow dataGridViewRow = dgTraj.Rows[index];
					dgTraj.Rows.RemoveAt(index);
					dgTraj.Rows.Insert(index - 1, dataGridViewRow);
					RefreshDg();
				}
			}
		}

		private void DgTraj_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int rowIndex = e.RowIndex;
				int columnIndex = e.ColumnIndex;
				if (columnIndex < 0 || rowIndex < 0)
				{
					return;
				}
				if (dgTraj.Columns[columnIndex].Name == "colTest")
				{
					if (_ele == null)
					{
						return;
					}
					DialogResult dialogResult = MessageBox.Show(NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Tip_AxisesMove", "移动轴组？")
                        , NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Tip_Warn", "注意！"), MessageBoxButtons.OKCancel);
					if (dialogResult == DialogResult.Cancel)
					{
						return;
					}
					double num = Convert.ToDouble(dgTraj.Rows[rowIndex].Cells["colVM"].Value);
					Pos val = new Pos("", Convert.ToDouble(dgTraj.Rows[rowIndex].Cells[1].Value), Convert.ToDouble(dgTraj.Rows[rowIndex].Cells[2].Value), Convert.ToDouble(dgTraj.Rows[rowIndex].Cells[3].Value), Convert.ToDouble(dgTraj.Rows[rowIndex].Cells[4].Value), Convert.ToDouble(dgTraj.Rows[rowIndex].Cells[5].Value), Convert.ToDouble(dgTraj.Rows[rowIndex].Cells[6].Value));
					((IEleCartesian)_ele).GroupMoveAbs(val, (ushort)20, -1, false, true, (ITask)null, (EleAlarmLevel)2);
				}
				if (dgTraj.Columns[columnIndex].Name == "colGetPos" && _ele != null)
				{
					DialogResult dialogResult2 = MessageBox.Show(NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Tip_GetCurrentPos", "获取当前点位？")
                        , NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Tip_Warn", "注意！"), MessageBoxButtons.OKCancel);
					if (dialogResult2 != DialogResult.Cancel)
					{
						Pos actualPos = ((IEleCartesian)_ele).GetActualPos();
						dgTraj.Rows[rowIndex].Cells[1].Value = actualPos.X;
						dgTraj.Rows[rowIndex].Cells[2].Value = actualPos.Y;
						dgTraj.Rows[rowIndex].Cells[3].Value = actualPos.Z;
						dgTraj.Rows[rowIndex].Cells[4].Value = actualPos.U;
						dgTraj.Rows[rowIndex].Cells[5].Value = actualPos.V;
						dgTraj.Rows[rowIndex].Cells[6].Value = actualPos.W;
					}
				}
			}
			catch
			{
			}
		}

		private void RefreshDg()
		{
			for (int i = 0; i < dgTraj.Rows.Count; i++)
			{
				dgTraj.Rows[i].Cells[0].Value = i;
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
            this.dgTraj = new System.Windows.Forms.DataGridView();
            this.colPosID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colGetPos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colVM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOffset = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCrd = new System.Windows.Forms.ComboBox();
            this.lb_Crd = new System.Windows.Forms.Label();
            this.tbTAccDec = new System.Windows.Forms.TextBox();
            this.lb_TAccDec = new System.Windows.Forms.Label();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.lb_Speed = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnTeach = new System.Windows.Forms.Button();
            this.cmbElementName = new System.Windows.Forms.ComboBox();
            this.lbElement = new System.Windows.Forms.Label();
            this.tbTrajId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTrajName = new System.Windows.Forms.TextBox();
            this.lbTrigName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTraj)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgTraj, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.90396F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.09605F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1286, 442);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgTraj
            // 
            this.dgTraj.AllowUserToAddRows = false;
            this.dgTraj.AllowUserToDeleteRows = false;
            this.dgTraj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTraj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPosID,
            this.colPosX,
            this.colPosY,
            this.colPosZ,
            this.colPosU,
            this.colPosV,
            this.colPosW,
            this.colTest,
            this.colGetPos,
            this.colVM,
            this.colRemark,
            this.colOffset});
            this.dgTraj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTraj.Location = new System.Drawing.Point(4, 96);
            this.dgTraj.Margin = new System.Windows.Forms.Padding(4);
            this.dgTraj.Name = "dgTraj";
            this.dgTraj.RowHeadersWidth = 51;
            this.dgTraj.RowTemplate.Height = 23;
            this.dgTraj.Size = new System.Drawing.Size(1278, 342);
            this.dgTraj.TabIndex = 3;
            this.dgTraj.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgTraj_CellContentClick_1);
            // 
            // colPosID
            // 
            this.colPosID.Frozen = true;
            this.colPosID.HeaderText = "序号";
            this.colPosID.MinimumWidth = 6;
            this.colPosID.Name = "colPosID";
            this.colPosID.ReadOnly = true;
            this.colPosID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPosID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosID.Width = 60;
            // 
            // colPosX
            // 
            this.colPosX.HeaderText = "Pos_X";
            this.colPosX.MinimumWidth = 6;
            this.colPosX.Name = "colPosX";
            this.colPosX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosX.Width = 80;
            // 
            // colPosY
            // 
            this.colPosY.HeaderText = "Pos_Y";
            this.colPosY.MinimumWidth = 6;
            this.colPosY.Name = "colPosY";
            this.colPosY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosY.Width = 80;
            // 
            // colPosZ
            // 
            this.colPosZ.HeaderText = "Pos_Z";
            this.colPosZ.MinimumWidth = 6;
            this.colPosZ.Name = "colPosZ";
            this.colPosZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosZ.Width = 80;
            // 
            // colPosU
            // 
            this.colPosU.HeaderText = "Pos_U";
            this.colPosU.MinimumWidth = 6;
            this.colPosU.Name = "colPosU";
            this.colPosU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosU.Width = 80;
            // 
            // colPosV
            // 
            this.colPosV.HeaderText = "Pos_V";
            this.colPosV.MinimumWidth = 6;
            this.colPosV.Name = "colPosV";
            this.colPosV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosV.Width = 80;
            // 
            // colPosW
            // 
            this.colPosW.HeaderText = "Pos_W";
            this.colPosW.MinimumWidth = 6;
            this.colPosW.Name = "colPosW";
            this.colPosW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosW.Width = 80;
            // 
            // colTest
            // 
            this.colTest.HeaderText = "测试移动";
            this.colTest.MinimumWidth = 6;
            this.colTest.Name = "colTest";
            this.colTest.Text = "移动";
            this.colTest.Width = 60;
            // 
            // colGetPos
            // 
            this.colGetPos.HeaderText = "获取位置";
            this.colGetPos.MinimumWidth = 6;
            this.colGetPos.Name = "colGetPos";
            this.colGetPos.Width = 60;
            // 
            // colVM
            // 
            this.colVM.HeaderText = "VM";
            this.colVM.MinimumWidth = 6;
            this.colVM.Name = "colVM";
            this.colVM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVM.Width = 125;
            // 
            // colRemark
            // 
            this.colRemark.HeaderText = "Remark";
            this.colRemark.MinimumWidth = 6;
            this.colRemark.Name = "colRemark";
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemark.Width = 125;
            // 
            // colOffset
            // 
            this.colOffset.HeaderText = "点位偏移类型";
            this.colOffset.Items.AddRange(new object[] {
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.colOffset.MinimumWidth = 6;
            this.colOffset.Name = "colOffset";
            this.colOffset.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOffset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colOffset.Width = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbCrd);
            this.panel1.Controls.Add(this.lb_Crd);
            this.panel1.Controls.Add(this.tbTAccDec);
            this.panel1.Controls.Add(this.lb_TAccDec);
            this.panel1.Controls.Add(this.cmbSpeed);
            this.panel1.Controls.Add(this.lb_Speed);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnTeach);
            this.panel1.Controls.Add(this.cmbElementName);
            this.panel1.Controls.Add(this.lbElement);
            this.panel1.Controls.Add(this.tbTrajId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbTrajName);
            this.panel1.Controls.Add(this.lbTrigName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 84);
            this.panel1.TabIndex = 4;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // cmbCrd
            // 
            this.cmbCrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCrd.DropDownWidth = 96;
            this.cmbCrd.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCrd.FormattingEnabled = true;
            this.cmbCrd.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbCrd.Location = new System.Drawing.Point(1155, 50);
            this.cmbCrd.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCrd.Name = "cmbCrd";
            this.cmbCrd.Size = new System.Drawing.Size(73, 25);
            this.cmbCrd.TabIndex = 86;
            // 
            // lb_Crd
            // 
            this.lb_Crd.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Crd.Location = new System.Drawing.Point(1065, 50);
            this.lb_Crd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Crd.Name = "lb_Crd";
            this.lb_Crd.Size = new System.Drawing.Size(82, 31);
            this.lb_Crd.TabIndex = 85;
            this.lb_Crd.Text = "坐标系";
            this.lb_Crd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTAccDec
            // 
            this.tbTAccDec.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbTAccDec.Location = new System.Drawing.Point(956, 52);
            this.tbTAccDec.Margin = new System.Windows.Forms.Padding(4);
            this.tbTAccDec.Name = "tbTAccDec";
            this.tbTAccDec.Size = new System.Drawing.Size(85, 24);
            this.tbTAccDec.TabIndex = 84;
            // 
            // lb_TAccDec
            // 
            this.lb_TAccDec.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_TAccDec.Location = new System.Drawing.Point(749, 51);
            this.lb_TAccDec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TAccDec.Name = "lb_TAccDec";
            this.lb_TAccDec.Size = new System.Drawing.Size(212, 25);
            this.lb_TAccDec.TabIndex = 83;
            this.lb_TAccDec.Text = "加减速度（mm/s²）：";
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeed.DropDownWidth = 96;
            this.cmbSpeed.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50",
            "40",
            "30",
            "20",
            "10"});
            this.cmbSpeed.Location = new System.Drawing.Point(621, 51);
            this.cmbSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(119, 25);
            this.cmbSpeed.TabIndex = 82;
            // 
            // lb_Speed
            // 
            this.lb_Speed.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Speed.Location = new System.Drawing.Point(492, 49);
            this.lb_Speed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Speed.Name = "lb_Speed";
            this.lb_Speed.Size = new System.Drawing.Size(119, 31);
            this.lb_Speed.TabIndex = 81;
            this.lb_Speed.Text = "速度百分比";
            this.lb_Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(362, 44);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 36);
            this.button4.TabIndex = 80;
            this.button4.Text = "↓";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnUp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUp.Location = new System.Drawing.Point(246, 44);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(105, 36);
            this.btnUp.TabIndex = 79;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.SystemColors.Control;
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(135, 44);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(105, 36);
            this.btnDel.TabIndex = 78;
            this.btnDel.Text = "一";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(20, 44);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 36);
            this.btnAdd.TabIndex = 77;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(945, 6);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(124, 36);
            this.btnApply.TabIndex = 76;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnTeach
            // 
            this.btnTeach.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTeach.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTeach.Location = new System.Drawing.Point(830, 6);
            this.btnTeach.Margin = new System.Windows.Forms.Padding(4);
            this.btnTeach.Name = "btnTeach";
            this.btnTeach.Size = new System.Drawing.Size(105, 36);
            this.btnTeach.TabIndex = 75;
            this.btnTeach.Text = "示教";
            this.btnTeach.UseVisualStyleBackColor = false;
            this.btnTeach.Click += new System.EventHandler(this.btnTeach_Click);
            // 
            // cmbElementName
            // 
            this.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElementName.DropDownWidth = 96;
            this.cmbElementName.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbElementName.FormattingEnabled = true;
            this.cmbElementName.Items.AddRange(new object[] {
            "Robot",
            "MotionCard"});
            this.cmbElementName.Location = new System.Drawing.Point(491, 11);
            this.cmbElementName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbElementName.Name = "cmbElementName";
            this.cmbElementName.Size = new System.Drawing.Size(119, 25);
            this.cmbElementName.TabIndex = 74;
            this.cmbElementName.SelectedIndexChanged += new System.EventHandler(this.cmbElementName_SelectedIndexChanged);
            // 
            // lbElement
            // 
            this.lbElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbElement.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbElement.Location = new System.Drawing.Point(362, 9);
            this.lbElement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbElement.Name = "lbElement";
            this.lbElement.Size = new System.Drawing.Size(118, 31);
            this.lbElement.TabIndex = 73;
            this.lbElement.Text = "元件关联：";
            this.lbElement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbElement.Click += new System.EventHandler(this.lbElement_Click);
            // 
            // tbTrajId
            // 
            this.tbTrajId.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbTrajId.Location = new System.Drawing.Point(301, 11);
            this.tbTrajId.Margin = new System.Windows.Forms.Padding(4);
            this.tbTrajId.Name = "tbTrajId";
            this.tbTrajId.Size = new System.Drawing.Size(50, 24);
            this.tbTrajId.TabIndex = 72;
            this.tbTrajId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTrajId_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(241, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 71;
            this.label1.Text = "ID：";
            // 
            // tbTrajName
            // 
            this.tbTrajName.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbTrajName.Location = new System.Drawing.Point(135, 11);
            this.tbTrajName.Margin = new System.Windows.Forms.Padding(4);
            this.tbTrajName.Name = "tbTrajName";
            this.tbTrajName.Size = new System.Drawing.Size(95, 24);
            this.tbTrajName.TabIndex = 70;
            // 
            // lbTrigName
            // 
            this.lbTrigName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTrigName.Location = new System.Drawing.Point(15, 11);
            this.lbTrigName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTrigName.Name = "lbTrigName";
            this.lbTrigName.Size = new System.Drawing.Size(110, 25);
            this.lbTrigName.TabIndex = 69;
            this.lbTrigName.Text = "轨迹名称：";
            // 
            // InterpolationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InterpolationControl";
            this.Size = new System.Drawing.Size(1286, 442);
            this.Load += new System.EventHandler(this.TrajConfigControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTraj)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		public void OnLanguageChanged()
		{
			lbTrigName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_TrigName", "轨迹名称:");
			lbElement.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Element", "元件关联:");
			btnTeach.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Teach", "示教");
			btnApply.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Apply", "应用");
            lb_Speed.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Speed", "速度百分比");
            lb_TAccDec.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_TAccDec", "加减速度(mm/s²):");
            lb_Crd.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_Crd", "坐标系");

            dgTraj.Columns["colPosID"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_colPosID", "序号");
            dgTraj.Columns["colTest"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_colTest", "测试移动");
            dgTraj.Columns["colGetPos"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_colGetPos", "获取位置");
            dgTraj.Columns["colVM"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_colVM", "速度比");
            dgTraj.Columns["colRemark"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_colRemark", "备注");
            dgTraj.Columns["colOffset"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_InterpolationControl_colOffset", "点位偏移类型");
        }
	}
}
