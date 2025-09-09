using Lead.CPrim.CmpTrigHelper.ComplexInterpolation;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
    public class ComplexInterPolationCfgUi : UserControl
	{
		private ComplexInterPolationCfg _cfg;

		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel1;

		private Panel panel1;

		private Button btnApply;

		private Button btnTeach;

		private TextBox tbTrajId;

		private Label label1;

		private TextBox tbTrajName;

		private Label lbTrigName;

		private ToolStrip tsMain;

		private FlowLayoutPanel flowMain;

		private ToolStripButton tsBtnMove;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton tsBtnDelay;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton tsBtnIoCtrl;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripButton tsbLag;

		private ToolStripSeparator toolStripSeparator4;

		private ComboBox cmbCrd;

		private Label label4;

		private ComboBox cmbElementName;

		private Label lbElement;

		private ToolStripButton tsDelConfig;

		private ToolStripButton tsBtnUp;

		private ToolStripButton tsBtnDown;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripSeparator toolStripSeparator6;

		private TextBox tbTAccDec;

		private Label label3;

		private ComboBox cmbSpeed;

		private Label label2;

		private ToolStripButton toolStripButton1;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripButton tsbAdvance;

		private ToolStripSeparator toolStripSeparator8;

		public ComplexInterPolationCfgUi()
		{
			InitializeComponent();
		}

		public ComplexInterPolationCfgUi(ComplexInterPolationCfg cfg)
		{
			InitializeComponent();
			_cfg = cfg;
		}

		public void LoadConfig()
		{
			tbTrajName.Text = _cfg.Name;
			tbTrajId.Text = _cfg.Id.ToString();
			cmbCrd.SelectedIndex = _cfg.Crd;
			tbTAccDec.Text = _cfg.TAccDec.ToString();
			cmbSpeed.SelectedIndex = 10 - _cfg.SpeedRate / 10;
			RefreshActionUi();
			RefreshEleComb();
			if (_cfg.EleName != null)
			{
				if (cmbElementName.Items.Contains(_cfg.EleName))
				{
					cmbElementName.SelectedItem = _cfg.EleName;
					return;
				}
				cmbElementName.Items.Add(_cfg.EleName);
				cmbElementName.SelectedItem = _cfg.EleName;
			}
		}

		private void RefreshActionUi()
		{
			_cfg.Actions.ForEach(delegate(ActionConfig p)
			{
				p.CrdManger = _cfg;
			});
			_cfg.Actions.Sort();
			flowMain.Controls.Clear();
			foreach (ActionConfig action in _cfg.Actions)
			{
				if (action.ConfigUi == null)
				{
					switch (action.actionType)
					{
					case ActionType.Move:
						action.ConfigUi = new MoveIcon(action);
						break;
					case ActionType.Delay:
						action.ConfigUi = new DelayCtrl(action);
						break;
					case ActionType.IOCtrl:
						action.ConfigUi = new IOControl(action);
						break;
					case ActionType.WaitIO:
						action.ConfigUi = new WaitDICtrl(action);
						break;
					}
				}
				flowMain.Controls.Add(action.ConfigUi);
			}
			foreach (object control in flowMain.Controls)
			{
				((ICmpCtrl)control).RefreshUI();
			}
		}

		private void tsBtnMove_Click(object sender, EventArgs e)
		{
			ActionConfig actionConfig = new ActionConfig(ActionType.Move, _cfg);
			_cfg.Actions.Add(actionConfig);
			actionConfig.Index = _cfg.Actions.Count - 1;
			flowMain.Controls.Add(actionConfig.ConfigUi);
		}

		private void tsBtnDelay_Click(object sender, EventArgs e)
		{
			ActionConfig actionConfig = new ActionConfig(ActionType.Delay, _cfg);
			_cfg.Actions.Add(actionConfig);
			actionConfig.Index = _cfg.Actions.Count - 1;
			flowMain.Controls.Add(actionConfig.ConfigUi);
		}

		private void tsBtnIoCtrl_Click(object sender, EventArgs e)
		{
			ActionConfig actionConfig = new ActionConfig(ActionType.IOCtrl, _cfg);
			_cfg.Actions.Add(actionConfig);
			actionConfig.Index = _cfg.Actions.Count - 1;
			flowMain.Controls.Add(actionConfig.ConfigUi);
		}

		private void tsBtnWaitIo_Click(object sender, EventArgs e)
		{
			ActionConfig actionConfig = new ActionConfig(ActionType.WaitIO, _cfg);
			_cfg.Actions.Add(actionConfig);
			actionConfig.Index = _cfg.Actions.Count - 1;
			flowMain.Controls.Add(actionConfig.ConfigUi);
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			_cfg.Crd = (ushort)cmbCrd.SelectedIndex;
			_cfg.Id = (int.TryParse(tbTrajId.Text, out var result) ? result : 999);
			_cfg.Name = tbTrajName.Text;
			SortActions();
			_cfg.Actions.ForEach(delegate(ActionConfig p)
			{
				((ICmpCtrl)p.ConfigUi).ApplyConfig();
			});
			int result2;
			int tAccDec = (int.TryParse(tbTAccDec.Text, out result2) ? result2 : 10000);
			_cfg.TAccDec = tAccDec;
		}

		private void SortActions()
		{
			int num = 0;
			foreach (object control in flowMain.Controls)
			{
				((ICmpCtrl)control).RefreshIndex(num);
				num++;
			}
		}

		private void lbElement_Click(object sender, EventArgs e)
		{
			RefreshEleComb();
		}

		private void RefreshEleComb()
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
			if (cmbElementName.SelectedIndex != -1 && !string.IsNullOrEmpty(cmbElementName.SelectedItem.ToString()))
			{
				_cfg.EleName = cmbElementName.SelectedItem.ToString();
			}
		}

		private void ComplexInterPolationCfgUi_Load(object sender, EventArgs e)
		{
			LoadConfig();
		}

		private void tsDelConfig_Click(object sender, EventArgs e)
		{
			List<ActionConfig> delActions = new List<ActionConfig>();
			_cfg.Actions.Where((ActionConfig p) => p.IsSelected).ToList().ForEach(delegate(ActionConfig p)
			{
				delActions.Add(p);
			});
			delActions.ForEach(delegate(ActionConfig p)
			{
				flowMain.Controls.Remove(p.ConfigUi);
			});
			delActions.ForEach(delegate(ActionConfig p)
			{
				_cfg.Actions.Remove(p);
			});
		}

		private void RefreshIndex()
		{
		}

		private void tsBtnUp_Click(object sender, EventArgs e)
		{
			SortActions();
			IEnumerable<ActionConfig> source = _cfg.Actions.Where((ActionConfig p) => p.IsSelected);
			if (source.Count() != 1)
			{
				MessageBox.Show("请选择一项需要移动的动作！");
				return;
			}
			int oldIndex = source.First().Index;
			if (source.First().Index > 0)
			{
				_cfg.Actions.FirstOrDefault((ActionConfig p) => p.Index == oldIndex - 1).Index = oldIndex;
				source.First().Index = oldIndex - 1;
				LoadConfig();
			}
		}

		private void tsBtnDown_Click(object sender, EventArgs e)
		{
			SortActions();
			IEnumerable<ActionConfig> source = _cfg.Actions.Where((ActionConfig p) => p.IsSelected);
			if (source.Count() != 1)
			{
				MessageBox.Show("请选择一项需要移动的动作！");
				return;
			}
			int oldIndex = source.First().Index;
			if (source.First().Index < _cfg.Actions.Count - 1)
			{
				_cfg.Actions.FirstOrDefault((ActionConfig p) => p.Index == oldIndex + 1).Index = oldIndex;
				source.First().Index = oldIndex + 1;
				LoadConfig();
			}
		}

		private void btnTeach_Click(object sender, EventArgs e)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			IEleCartesian val = (IEleCartesian)ElesManagerTransfer.GetEleByName(_cfg.EleName);
			if (val != null)
			{
				FrmAxisDebugUI frmAxisDebugUI = new FrmAxisDebugUI(val);
				frmAxisDebugUI.Show();
			}
		}

		private void panel1_DoubleClick(object sender, EventArgs e)
		{
			_cfg.IsSelected = !_cfg.IsSelected;
		}

		private void cmbSpeed_SelectedIndexChanged(object sender, EventArgs e)
		{
			int result;
			int speedRate = (int.TryParse(cmbSpeed.Text, out result) ? result : 100);
			_cfg.SpeedRate = speedRate;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lead.CPrim.CmpTrigHelper.ComplexInterPolationCfgUi));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbTAccDec = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbSpeed = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbElementName = new System.Windows.Forms.ComboBox();
			this.lbElement = new System.Windows.Forms.Label();
			this.cmbCrd = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnTeach = new System.Windows.Forms.Button();
			this.tbTrajId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbTrajName = new System.Windows.Forms.TextBox();
			this.lbTrigName = new System.Windows.Forms.Label();
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsBtnMove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnDelay = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnIoCtrl = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbAdvance = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbLag = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnUp = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnDown = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsDelConfig = new System.Windows.Forms.ToolStripButton();
			this.flowMain = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tsMain.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tsMain, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowMain, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1018, 800);
			this.tableLayoutPanel1.TabIndex = 0;
			this.panel1.Controls.Add(this.tbTAccDec);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cmbSpeed);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cmbElementName);
			this.panel1.Controls.Add(this.lbElement);
			this.panel1.Controls.Add(this.cmbCrd);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.btnApply);
			this.panel1.Controls.Add(this.btnTeach);
			this.panel1.Controls.Add(this.tbTrajId);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tbTrajName);
			this.panel1.Controls.Add(this.lbTrigName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 4);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1012, 102);
			this.panel1.TabIndex = 0;
			this.panel1.DoubleClick += new System.EventHandler(panel1_DoubleClick);
			this.tbTAccDec.Font = new System.Drawing.Font("微软雅黑", 7.5f);
			this.tbTAccDec.Location = new System.Drawing.Point(687, 62);
			this.tbTAccDec.Name = "tbTAccDec";
			this.tbTAccDec.Size = new System.Drawing.Size(85, 21);
			this.tbTAccDec.TabIndex = 102;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label3.Location = new System.Drawing.Point(518, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(170, 20);
			this.label3.TabIndex = 101;
			this.label3.Text = "加减速度（mm/s²）：";
			this.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSpeed.DropDownWidth = 96;
			this.cmbSpeed.Font = new System.Drawing.Font("微软雅黑", 7.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.cmbSpeed.FormattingEnabled = true;
			this.cmbSpeed.Items.AddRange(new object[10] { "100", "90", "80", "70", "60", "50", "40", "30", "20", "10" });
			this.cmbSpeed.Location = new System.Drawing.Point(397, 62);
			this.cmbSpeed.Name = "cmbSpeed";
			this.cmbSpeed.Size = new System.Drawing.Size(96, 24);
			this.cmbSpeed.TabIndex = 100;
			this.cmbSpeed.SelectedIndexChanged += new System.EventHandler(cmbSpeed_SelectedIndexChanged);
			this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label2.Location = new System.Drawing.Point(294, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 25);
			this.label2.TabIndex = 99;
			this.label2.Text = "速度百分比";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbElementName.DropDownWidth = 96;
			this.cmbElementName.Font = new System.Drawing.Font("微软雅黑", 7.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.cmbElementName.FormattingEnabled = true;
			this.cmbElementName.Items.AddRange(new object[2] { "Robot", "MotionCard" });
			this.cmbElementName.Location = new System.Drawing.Point(397, 10);
			this.cmbElementName.Name = "cmbElementName";
			this.cmbElementName.Size = new System.Drawing.Size(96, 24);
			this.cmbElementName.TabIndex = 98;
			this.cmbElementName.SelectedIndexChanged += new System.EventHandler(cmbElementName_SelectedIndexChanged);
			this.lbElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbElement.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.lbElement.Location = new System.Drawing.Point(296, 11);
			this.lbElement.Name = "lbElement";
			this.lbElement.Size = new System.Drawing.Size(95, 25);
			this.lbElement.TabIndex = 97;
			this.lbElement.Text = "元件关联：";
			this.lbElement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbElement.Click += new System.EventHandler(lbElement_Click);
			this.cmbCrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCrd.DropDownWidth = 96;
			this.cmbCrd.Font = new System.Drawing.Font("微软雅黑", 7.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.cmbCrd.FormattingEnabled = true;
			this.cmbCrd.Items.AddRange(new object[2] { "0", "1" });
			this.cmbCrd.Location = new System.Drawing.Point(593, 10);
			this.cmbCrd.Name = "cmbCrd";
			this.cmbCrd.Size = new System.Drawing.Size(59, 24);
			this.cmbCrd.TabIndex = 96;
			this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label4.Location = new System.Drawing.Point(521, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 25);
			this.label4.TabIndex = 95;
			this.label4.Text = "坐标系";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
			this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnApply.Location = new System.Drawing.Point(831, 4);
			this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(115, 41);
			this.btnApply.TabIndex = 84;
			this.btnApply.Text = "应用";
			this.btnApply.UseVisualStyleBackColor = false;
			this.btnApply.Click += new System.EventHandler(btnApply_Click);
			this.btnTeach.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.btnTeach.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnTeach.Location = new System.Drawing.Point(727, 5);
			this.btnTeach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnTeach.Name = "btnTeach";
			this.btnTeach.Size = new System.Drawing.Size(98, 41);
			this.btnTeach.TabIndex = 83;
			this.btnTeach.Text = "示教";
			this.btnTeach.UseVisualStyleBackColor = false;
			this.btnTeach.Click += new System.EventHandler(btnTeach_Click);
			this.tbTrajId.Font = new System.Drawing.Font("微软雅黑", 7.5f);
			this.tbTrajId.Location = new System.Drawing.Point(232, 13);
			this.tbTrajId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbTrajId.Name = "tbTrajId";
			this.tbTrajId.Size = new System.Drawing.Size(47, 21);
			this.tbTrajId.TabIndex = 80;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.label1.Location = new System.Drawing.Point(199, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 28);
			this.label1.TabIndex = 79;
			this.label1.Text = "ID：";
			this.tbTrajName.Font = new System.Drawing.Font("微软雅黑", 7.5f);
			this.tbTrajName.Location = new System.Drawing.Point(107, 14);
			this.tbTrajName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tbTrajName.Name = "tbTrajName";
			this.tbTrajName.Size = new System.Drawing.Size(89, 21);
			this.tbTrajName.TabIndex = 78;
			this.lbTrigName.Font = new System.Drawing.Font("微软雅黑", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.lbTrigName.Location = new System.Drawing.Point(16, 13);
			this.lbTrigName.Name = "lbTrigName";
			this.lbTrigName.Size = new System.Drawing.Size(103, 28);
			this.lbTrigName.TabIndex = 77;
			this.lbTrigName.Text = "轨迹名称：";
			this.tsMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[17]
			{
				this.tsBtnMove, this.toolStripSeparator1, this.tsBtnDelay, this.toolStripSeparator2, this.tsBtnIoCtrl, this.toolStripSeparator3, this.toolStripButton1, this.toolStripSeparator7, this.tsbAdvance, this.toolStripSeparator8,
				this.tsbLag, this.toolStripSeparator4, this.tsBtnUp, this.toolStripSeparator5, this.tsBtnDown, this.toolStripSeparator6, this.tsDelConfig
			});
			this.tsMain.Location = new System.Drawing.Point(0, 110);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(1018, 35);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "toolStrip1";
			this.tsBtnMove.BackColor = System.Drawing.Color.SpringGreen;
			this.tsBtnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnMove.Image = (System.Drawing.Image)resources.GetObject("tsBtnMove.Image");
			this.tsBtnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnMove.Name = "tsBtnMove";
			this.tsBtnMove.Size = new System.Drawing.Size(49, 32);
			this.tsBtnMove.Text = "MOVE";
			this.tsBtnMove.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnMove.Click += new System.EventHandler(tsBtnMove_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			this.tsBtnDelay.BackColor = System.Drawing.Color.SpringGreen;
			this.tsBtnDelay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnDelay.Image = (System.Drawing.Image)resources.GetObject("tsBtnDelay.Image");
			this.tsBtnDelay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnDelay.Name = "tsBtnDelay";
			this.tsBtnDelay.Size = new System.Drawing.Size(49, 32);
			this.tsBtnDelay.Text = "DELAY";
			this.tsBtnDelay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnDelay.Click += new System.EventHandler(tsBtnDelay_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			this.tsBtnIoCtrl.BackColor = System.Drawing.Color.SpringGreen;
			this.tsBtnIoCtrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnIoCtrl.Image = (System.Drawing.Image)resources.GetObject("tsBtnIoCtrl.Image");
			this.tsBtnIoCtrl.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnIoCtrl.Name = "tsBtnIoCtrl";
			this.tsBtnIoCtrl.Size = new System.Drawing.Size(55, 32);
			this.tsBtnIoCtrl.Text = "IOCTRL";
			this.tsBtnIoCtrl.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnIoCtrl.Click += new System.EventHandler(tsBtnIoCtrl_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
			this.toolStripButton1.BackColor = System.Drawing.Color.SpringGreen;
			this.toolStripButton1.CheckOnClick = true;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripButton1.Image");
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(57, 32);
			this.toolStripButton1.Text = "WAITIO";
			this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 35);
			this.tsbAdvance.BackColor = System.Drawing.Color.SpringGreen;
			this.tsbAdvance.CheckOnClick = true;
			this.tsbAdvance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbAdvance.Image = (System.Drawing.Image)resources.GetObject("tsbAdvance.Image");
			this.tsbAdvance.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdvance.Name = "tsbAdvance";
			this.tsbAdvance.Size = new System.Drawing.Size(55, 32);
			this.tsbAdvance.Text = "DO超前";
			this.tsbAdvance.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 35);
			this.tsbLag.BackColor = System.Drawing.Color.SpringGreen;
			this.tsbLag.CheckOnClick = true;
			this.tsbLag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbLag.Image = (System.Drawing.Image)resources.GetObject("tsbLag.Image");
			this.tsbLag.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbLag.Name = "tsbLag";
			this.tsbLag.Size = new System.Drawing.Size(63, 32);
			this.tsbLag.Text = " DO滞后 ";
			this.tsbLag.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsbLag.Click += new System.EventHandler(tsBtnWaitIo_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
			this.tsBtnUp.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tsBtnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnUp.Name = "tsBtnUp";
			this.tsBtnUp.Size = new System.Drawing.Size(23, 32);
			this.tsBtnUp.Text = "↑";
			this.tsBtnUp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.tsBtnUp.Click += new System.EventHandler(tsBtnUp_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
			this.tsBtnDown.BackColor = System.Drawing.Color.AntiqueWhite;
			this.tsBtnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsBtnDown.Image = (System.Drawing.Image)resources.GetObject("tsBtnDown.Image");
			this.tsBtnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnDown.Name = "tsBtnDown";
			this.tsBtnDown.Size = new System.Drawing.Size(23, 32);
			this.tsBtnDown.Text = "↓";
			this.tsBtnDown.Click += new System.EventHandler(tsBtnDown_Click);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 35);
			this.tsDelConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsDelConfig.Image = (System.Drawing.Image)resources.GetObject("tsDelConfig.Image");
			this.tsDelConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsDelConfig.Name = "tsDelConfig";
			this.tsDelConfig.Size = new System.Drawing.Size(23, 32);
			this.tsDelConfig.Text = "移除已选中成员";
			this.tsDelConfig.Click += new System.EventHandler(tsDelConfig_Click);
			this.flowMain.AutoScroll = true;
			this.flowMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowMain.Location = new System.Drawing.Point(3, 148);
			this.flowMain.Name = "flowMain";
			this.flowMain.Size = new System.Drawing.Size(1012, 649);
			this.flowMain.TabIndex = 2;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			base.Name = "ComplexInterPolationCfgUi";
			base.Size = new System.Drawing.Size(1018, 800);
			base.Load += new System.EventHandler(ComplexInterPolationCfgUi_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
