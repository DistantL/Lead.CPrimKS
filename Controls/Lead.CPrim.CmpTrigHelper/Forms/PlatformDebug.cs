using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.StateMachine;

namespace Lead.CPrim.CmpTrigHelper.CmpTrigUIs
{
	public class PlatformDebug : Form
	{
		private delegate void Del_GuiRefresh();

		private delegate void UpdateEleRunState(EleRunState state);

		private delegate void UpdateEleSimulateMode(bool simulate);

		public delegate void DelUpdateStatus(Guid gid);

		public delegate void UpdatePos(ConfigType config, Guid gid, object obj);

		private ConfigType _configType;

		private IEle _ele;

		private Guid _gId;

		private string[] _axisName;

		private Button[] _btnHome;

		private Button[] _btnJogMinus;

		private string[] _btnJogMinusName;

		private Button[] _btnJogPlus;

		private string[] _btnJogPlusName;

		private Button[] _btnServo;

		private ComboBox[] _cmbHomeOrder;

		private ComboBox[] _cmbStep;

		private double[] _curPos;

		private List<Pos> _posList = new List<Pos>();

		private TextBox[] _tbPos;

		private IContainer components = null;

		private TableLayoutPanel tabPanelBase;

		private TableLayoutPanel tableLayoutPanel2;

		private TabControl tabControl2;

		private TabPage tabPage3;

		private Button btnMinusZ;

		private Button btnMinusX;

		private Button btnPlusY;

		private Button btnMinusW;

		private Button btnMinusV;

		private Button btnMinusU;

		private Button btnMinusY;

		private Button btnPlusZ;

		private Button btnAllStop;

		private Button btnPlusX;

		private Button btnPlusW;

		private Button btnPlusV;

		private Button btnPlusU;

		private TabPage tabPage4;

		private Button btnServoOffAll;

		private Button btnHomeStop;

		private Button btnHomeAll;

		private Button btnServoOnAll;

		private ComboBox cmbHomeOrderW;

		private ComboBox cmbHomeOrderV;

		private ComboBox cmbHomeOrderZ;

		private ComboBox cmbHomeOrderY;

		private ComboBox cmbHomeOrderX;

		private Button btnServoW;

		private Button btnHomeW;

		private Button btnServoV;

		private Button btnHomeV;

		private Button btnServoU;

		private Button btnHomeU;

		private Button btnServoZ;

		private Button btnHomeZ;

		private Button btnServoY;

		private Button btnHomeY;

		private Button btnServoX;

		private Button btnHomeX;

		private ComboBox cmbHomeOrderU;

		private TableLayoutPanel tableLayoutPanel3;

		private GroupBox groupBox2;

		private Button btnPosMoveP;

		private Button btnPosTeach;

		private ComboBox cmbPointMove;

		private ComboBox cmbPointTeach;

		private GroupBox groupBox4;

		private TextBox tbPosW;

		private Label label4;

		private Label label3;

		private TextBox tbPosZ;

		private TextBox tbPosX;

		private Label label6;

		private Label label5;

		private Label label2;

		private Label label1;

		private TextBox tbPosY;

		private TextBox tbPosU;

		private TextBox tbPosV;

		private GroupBox groupBox5;

		private Label label30;

		private ComboBox cmbStepX;

		private Label label29;

		private ComboBox cmbStepU;

		private Label label28;

		private ComboBox cmbStepW;

		private ComboBox cmbStepY;

		private ComboBox cmbStepZ;

		private ComboBox cmbStepV;

		private Label label27;

		private Label label25;

		private Label label26;

		private Panel panel1;

		private TextBox tbState;

		private Label lbState;

		private TextBox tbInfo;

		private Label lbInfo;

		private TextBox tbName;

		private Label lbName;

		private Timer tmrRefresh;

		public event UpdatePos EventUpdatePos;

		public event DelUpdateStatus EventUpdateStatus;

		public PlatformDebug()
		{
			InitializeComponent();
		}

		public PlatformDebug(IEle ele)
		{
			InitializeComponent();
			_ele = ele;
			tbName.Text = _ele.Name;
			tbInfo.Text = _ele.Info;
			tbName.Enabled = false;
			tbInfo.Enabled = false;
			_curPos = new double[6];
			_axisName = new string[6] { "X", "Y", "Z", "U", "V", "W" };
			_btnJogPlus = new Button[6] { btnPlusX, btnPlusY, btnPlusZ, btnPlusU, btnPlusV, btnPlusW };
			_btnJogMinus = new Button[6] { btnMinusX, btnMinusY, btnMinusZ, btnMinusU, btnMinusV, btnMinusW };
			_btnJogPlus.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnJog_Click;
			});
			_btnJogMinus.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnJog_Click;
			});
			_tbPos = new TextBox[6] { tbPosX, tbPosY, tbPosZ, tbPosU, tbPosV, tbPosW };
			_cmbStep = new ComboBox[6] { cmbStepX, cmbStepY, cmbStepZ, cmbStepU, cmbStepV, cmbStepW };
			_btnServo = new Button[6] { btnServoX, btnServoY, btnServoZ, btnServoU, btnServoV, btnServoW };
			_btnServo.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnServo_Click;
			});
			_btnHome = new Button[6] { btnHomeX, btnHomeY, btnHomeZ, btnHomeU, btnHomeV, btnHomeW };
			_btnHome.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnHome_Click;
			});
			_cmbHomeOrder = new ComboBox[6] { cmbHomeOrderX, cmbHomeOrderY, cmbHomeOrderZ, cmbHomeOrderU, cmbHomeOrderV, cmbHomeOrderW };
			_btnJogPlusName = new string[6] { "X+", "Y+", "Z+", "U+", "V+", "W+" };
			_btnJogMinusName = new string[6] { "X-", "Y-", "Z-", "U-", "V-", "W-" };
		}

		public PlatformDebug(IEle ele, List<Pos> posList, Guid gId)
		{
			InitializeComponent();
			_ele = ele;
			_gId = gId;
			tbName.Text = _ele.Name;
			tbInfo.Text = _ele.Info;
			tbName.Enabled = false;
			tbInfo.Enabled = false;
			_curPos = new double[6];
			_axisName = new string[6] { "X", "Y", "Z", "U", "V", "W" };
			_btnJogPlus = new Button[6] { btnPlusX, btnPlusY, btnPlusZ, btnPlusU, btnPlusV, btnPlusW };
			_btnJogMinus = new Button[6] { btnMinusX, btnMinusY, btnMinusZ, btnMinusU, btnMinusV, btnMinusW };
			_btnJogPlus.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnJog_Click;
			});
			_btnJogMinus.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnJog_Click;
			});
			_tbPos = new TextBox[6] { tbPosX, tbPosY, tbPosZ, tbPosU, tbPosV, tbPosW };
			_cmbStep = new ComboBox[6] { cmbStepX, cmbStepY, cmbStepZ, cmbStepU, cmbStepV, cmbStepW };
			_btnServo = new Button[6] { btnServoX, btnServoY, btnServoZ, btnServoU, btnServoV, btnServoW };
			_btnServo.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnServo_Click;
			});
			_btnHome = new Button[6] { btnHomeX, btnHomeY, btnHomeZ, btnHomeU, btnHomeV, btnHomeW };
			_btnHome.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnHome_Click;
			});
			_cmbHomeOrder = new ComboBox[6] { cmbHomeOrderX, cmbHomeOrderY, cmbHomeOrderZ, cmbHomeOrderU, cmbHomeOrderV, cmbHomeOrderW };
			_btnJogPlusName = new string[6] { "X+", "Y+", "Z+", "U+", "V+", "W+" };
			_btnJogMinusName = new string[6] { "X-", "Y-", "Z-", "U-", "V-", "W-" };
			_posList.Clear();
			foreach (Pos pos in posList)
			{
				_posList.Add(pos);
			}
			LoadTeachPanel();
		}

		public PlatformDebug(IEle ele, List<Pos> posList, ConfigType configType, Guid gId)
		{
			InitializeComponent();
			_ele = ele;
			_gId = gId;
			_configType = configType;
			tbName.Text = _ele.Name;
			tbInfo.Text = _ele.Info;
			tbName.Enabled = false;
			tbInfo.Enabled = false;
			_curPos = new double[6];
			_axisName = new string[6] { "X", "Y", "Z", "U", "V", "W" };
			_btnJogPlus = new Button[6] { btnPlusX, btnPlusY, btnPlusZ, btnPlusU, btnPlusV, btnPlusW };
			_btnJogMinus = new Button[6] { btnMinusX, btnMinusY, btnMinusZ, btnMinusU, btnMinusV, btnMinusW };
			_btnJogPlus.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnJog_Click;
			});
			_btnJogMinus.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnJog_Click;
			});
			_tbPos = new TextBox[6] { tbPosX, tbPosY, tbPosZ, tbPosU, tbPosV, tbPosW };
			_cmbStep = new ComboBox[6] { cmbStepX, cmbStepY, cmbStepZ, cmbStepU, cmbStepV, cmbStepW };
			_btnServo = new Button[6] { btnServoX, btnServoY, btnServoZ, btnServoU, btnServoV, btnServoW };
			_btnServo.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnServo_Click;
			});
			_btnHome = new Button[6] { btnHomeX, btnHomeY, btnHomeZ, btnHomeU, btnHomeV, btnHomeW };
			_btnHome.ToList().ForEach(delegate(Button p)
			{
				p.Click += BtnHome_Click;
			});
			_cmbHomeOrder = new ComboBox[6] { cmbHomeOrderX, cmbHomeOrderY, cmbHomeOrderZ, cmbHomeOrderU, cmbHomeOrderV, cmbHomeOrderW };
			_btnJogPlusName = new string[6] { "X+", "Y+", "Z+", "U+", "V+", "W+" };
			_btnJogMinusName = new string[6] { "X-", "Y-", "Z-", "U-", "V-", "W-" };
			_posList.Clear();
			foreach (Pos pos in posList)
			{
				_posList.Add(pos);
			}
			if (_configType == ConfigType.Traj || _configType == ConfigType.IncrementTrig)
			{
				cmbPointMove.DropDownStyle = ComboBoxStyle.DropDownList;
				cmbPointTeach.DropDownStyle = ComboBoxStyle.DropDownList;
			}
			LoadTeachPanel();
		}

		private void BtnAllStop_Click(object sender, EventArgs e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			((IEleCartesian)_ele).GroupStop();
		}

		private void BtnHome_Click(object sender, EventArgs e)
		{
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				if (sender is Button value)
				{
					int num = Array.IndexOf(_btnHome, value);
					if (num >= 0 && ((IEleCartesian)_ele).AxisIndex[num] != -1 && MessageBox.Show(((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].Name + " 开始回零？", "回零", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
					{
						MessageBox.Show((((IEleCartesian)_ele).SingleHome(((IEleCartesian)_ele).AxisIndex[num], -1, (ITask)null, (EleAlarmLevel)2) == 0) ? (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].Name + " 回零成功。 ") : (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].Name + " 回零失败。 "));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(_ele.Name + " 回零出错：" + ex.Message + " 。");
			}
		}

		private void BtnHomeAll_Click(object sender, EventArgs e)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			if (MessageBox.Show("请确认将" + _ele.Name + "的所有轴进行回原点运动？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Cursor = Cursors.WaitCursor;
				bool flag = ((IEleCartesian)_ele).GroupHome(-1, (ITask)null, (EleAlarmLevel)2) == 0;
				Cursor = Cursors.Default;
				MessageBox.Show(_ele.Name + "所有轴回原点" + (flag ? "成功！" : "失败！"));
			}
		}

		private void BtnJog_Click(object sender, EventArgs e)
		{
			Button button = sender as Button;
			try
			{
				if (button == null)
				{
					return;
				}
				button.Enabled = false;
				Cursor = Cursors.WaitCursor;
				if (button.Text.Contains("+"))
				{
					int num = Array.IndexOf(_btnJogPlus, button);
					if (num >= 0 && ((IEleCartesian)_ele).AxisIndex[num] != -1)
					{
						double num2 = double.Parse(_cmbStep[num].Text);
						if (((!(num2 > 10.0) && !((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].InPel) || MessageBox.Show($"确认将轴{((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].Name} 移动 {num2}mm ？：正限位- {((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].InPel} ?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No) && ((IEleCartesian)_ele).SingleMoveRel(((IEleCartesian)_ele).AxisIndex[num], num2, ((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].JogVel, ((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].JogAcc, ((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].JogDec, (ushort)100, true, false, (ITask)null, (EleAlarmLevel)2) != 0)
						{
							MessageBox.Show(((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].Name + " 移动出错。");
						}
					}
				}
				else
				{
					if (!button.Text.Contains("-"))
					{
						return;
					}
					int num3 = Array.IndexOf(_btnJogMinus, button);
					if (num3 >= 0 && ((IEleCartesian)_ele).AxisIndex[num3] != -1)
					{
						double num4 = double.Parse(_cmbStep[num3].Text);
						if (((!(num4 > 10.0) && !((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num3]].InMel) || MessageBox.Show($"确认将轴{((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num3]].Name} 移动 {num4}mm ？：负限位- {((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num3]].InMel} ?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No) && ((IEleCartesian)_ele).SingleMoveRel(((IEleCartesian)_ele).AxisIndex[num3], 0.0 - num4, ((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num3]].JogVel, ((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num3]].JogAcc, ((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num3]].JogDec, (ushort)100, true, false, (ITask)null, (EleAlarmLevel)2) != 0)
						{
							MessageBox.Show(((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num3]].Name + " 移动出错。");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MessageBox.Show(_ele.Name + " 移动出错: " + ex.Message + " 。");
			}
			finally
			{
				Cursor = Cursors.Default;
				if (button != null)
				{
					button.Enabled = true;
				}
			}
		}

		private void BtnPosDelete_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cmbPointTeach.Text))
			{
				MessageBox.Show("点位名称有误。");
				return;
			}
			Pos item = _posList.FirstOrDefault((Pos p) => p.Name == cmbPointTeach.Text);
			_posList.Remove(item);
			LoadTeachPanel();
			cmbPointTeach.Text = string.Empty;
			cmbPointMove.Text = string.Empty;
		}

		private void BtnPosMoveP_Click(object sender, EventArgs e)
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrEmpty(cmbPointMove.Text))
			{
				MessageBox.Show("点位名称有误。");
				return;
			}
			Pos val = _posList.FirstOrDefault((Pos p) => p.Name == cmbPointMove.Text);
			((IEleCartesian)_ele).GroupMoveAbs(val, (ushort)90, -1, false, true, (ITask)null, (EleAlarmLevel)2);
		}

		private void BtnPosTeach_Click(object sender, EventArgs e)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrEmpty(cmbPointTeach.Text))
			{
				MessageBox.Show("示教点位名称有误。");
				return;
			}
			Pos actualPos = ((IEleCartesian)_ele).GetActualPos();
			if (_posList.Exists((Pos p) => p.Name == cmbPointTeach.Text))
			{
				Pos val = _posList.First((Pos p) => p.Name == cmbPointTeach.Text);
				if (MessageBox.Show($"确认要将点位 {val.Name} : X-{val.X:F3},Y-{val.Y:F3},Z-{val.Z:F3},U-{val.U:F3},V-{val.V:F3},W-{val.W:F3} 更新为\r\n                    X-{actualPos.X:F3},Y-{actualPos.Y:F3},Z-{actualPos.Z:F3},U-{actualPos.U:F3},V-{actualPos.V:F3},W-{actualPos.W:F3}?", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					return;
				}
			}
			else if (MessageBox.Show($"确认添加一个新的点位 {cmbPointTeach.Text} ：X-{actualPos.X:F3},Y-{actualPos.Y:F3},Z-{actualPos.Z:F3},U-{actualPos.U:F3},V-{actualPos.V:F3},W-{actualPos.W:F3}?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				return;
			}
			TeachPos(cmbPointTeach.Text);
			LoadTeachPanel(cmbPointTeach.Text);
		}

		private void BtnServo_Click(object sender, EventArgs e)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			if (sender is Button value)
			{
				int num = Array.IndexOf(_btnServo, value);
				if (num >= 0 && ((IEleCartesian)_ele).AxisIndex[num] != -1)
				{
					MessageBox.Show((((IEleCartesian)_ele).SingleSetEnable(((IEleCartesian)_ele).AxisIndex[num], !((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].IsServoOn, (ITask)null, (EleAlarmLevel)2) == 0) ? (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].Name + " 使能成功。 ") : (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[num]].Name + " 使能失败。 "));
				}
			}
		}

		private void BtnServoOffAll_Click(object sender, EventArgs e)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			if (MessageBox.Show("请确认将" + _ele.Name + "的所有轴下使能？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Cursor = Cursors.WaitCursor;
				bool flag = ((IEleCartesian)_ele).GroupSetEnable(false, (ITask)null, (EleAlarmLevel)2) == 0;
				Cursor = Cursors.Default;
				MessageBox.Show(_ele.Name + "所有轴下使能" + (flag ? "成功！" : "失败！"));
			}
		}

		private void BtnServoOnAll_Click(object sender, EventArgs e)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			if (MessageBox.Show("请确认将" + _ele.Name + "的所有轴上使能？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Cursor = Cursors.WaitCursor;
				bool flag = ((IEleCartesian)_ele).GroupSetEnable(true, (ITask)null, (EleAlarmLevel)2) == 0;
				Cursor = Cursors.Default;
				MessageBox.Show(_ele.Name + "所有轴上使能" + (flag ? "成功！" : "失败！"));
			}
		}

		private void DebugUI_Load(object sender, EventArgs e)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Invalid comparison between Unknown and I4
			if (_ele == null || !string.IsNullOrEmpty(_ele.Name))
			{
			}
			if (_ele != null)
			{
				IEle ele = _ele;
				if (ele != null && (int)ele.EleRunStat == 100)
				{
					_ele.IEleInit();
				}
				LoadAxises();
				LoadManualPanel();
				tmrRefresh.Interval = 100;
				tmrRefresh.Start();
			}
		}

		private void LbState_Click(object sender, EventArgs e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Invalid comparison between Unknown and I4
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Invalid comparison between Unknown and I4
			if ((int)_ele.EleRunStat == 100)
			{
				_ele.IEleInit();
			}
			if ((int)_ele.EleRunStat == 4)
			{
				_ele.IEleReset();
			}
		}

		private void LoadAxises()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0350: Unknown result type (might be due to invalid IL or missing references)
			//IL_040d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_045e: Unknown result type (might be due to invalid IL or missing references)
			//IL_051b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0546: Unknown result type (might be due to invalid IL or missing references)
			//IL_056c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0629: Unknown result type (might be due to invalid IL or missing references)
			//IL_0654: Unknown result type (might be due to invalid IL or missing references)
			if (((IEleCartesian)_ele).Axises.Count > 0)
			{
				if (((IEleCartesian)_ele).X == null)
				{
					btnMinusX.BackColor = Color.Gray;
					btnPlusX.BackColor = Color.Gray;
					btnServoX.BackColor = Color.Gray;
					btnHomeX.BackColor = Color.Gray;
					cmbHomeOrderX.BackColor = Color.Gray;
					btnMinusX.Enabled = false;
					btnPlusX.Enabled = false;
					btnServoX.Enabled = false;
					btnHomeX.Enabled = false;
					cmbHomeOrderX.Enabled = false;
				}
				else
				{
					btnMinusX.Text = ((IEleCartesian)_ele).X.Name + "-";
					btnPlusX.Text = ((IEleCartesian)_ele).X.Name + "+";
				}
				if (((IEleCartesian)_ele).Y == null)
				{
					btnMinusY.BackColor = Color.Gray;
					btnPlusY.BackColor = Color.Gray;
					btnServoY.BackColor = Color.Gray;
					btnHomeY.BackColor = Color.Gray;
					cmbHomeOrderY.BackColor = Color.Gray;
					btnMinusY.Enabled = false;
					btnPlusY.Enabled = false;
					btnServoY.Enabled = false;
					btnHomeY.Enabled = false;
					cmbHomeOrderY.Enabled = false;
				}
				else
				{
					btnMinusY.Text = ((IEleCartesian)_ele).Y.Name + "-";
					btnPlusY.Text = ((IEleCartesian)_ele).Y.Name + "+";
				}
				if (((IEleCartesian)_ele).Z == null)
				{
					btnMinusZ.BackColor = Color.Gray;
					btnPlusZ.BackColor = Color.Gray;
					btnServoZ.BackColor = Color.Gray;
					btnHomeZ.BackColor = Color.Gray;
					cmbHomeOrderZ.BackColor = Color.Gray;
					btnMinusZ.Enabled = false;
					btnPlusZ.Enabled = false;
					btnServoZ.Enabled = false;
					btnHomeZ.Enabled = false;
					cmbHomeOrderZ.Enabled = false;
				}
				else
				{
					btnMinusZ.Text = ((IEleCartesian)_ele).Z.Name + "-";
					btnPlusZ.Text = ((IEleCartesian)_ele).Z.Name + "+";
				}
				if (((IEleCartesian)_ele).U == null)
				{
					btnMinusU.BackColor = Color.Gray;
					btnPlusU.BackColor = Color.Gray;
					btnServoU.BackColor = Color.Gray;
					btnHomeU.BackColor = Color.Gray;
					cmbHomeOrderU.BackColor = Color.Gray;
					btnMinusU.Enabled = false;
					btnPlusU.Enabled = false;
					btnServoU.Enabled = false;
					btnHomeU.Enabled = false;
					cmbHomeOrderU.Enabled = false;
				}
				else
				{
					btnMinusU.Text = ((IEleCartesian)_ele).U.Name + "-";
					btnPlusU.Text = ((IEleCartesian)_ele).U.Name + "+";
				}
				if (((IEleCartesian)_ele).V == null)
				{
					btnMinusV.BackColor = Color.Gray;
					btnPlusV.BackColor = Color.Gray;
					btnServoV.BackColor = Color.Gray;
					btnHomeV.BackColor = Color.Gray;
					cmbHomeOrderV.BackColor = Color.Gray;
					btnMinusV.Enabled = false;
					btnPlusV.Enabled = false;
					btnServoV.Enabled = false;
					btnHomeV.Enabled = false;
					cmbHomeOrderV.Enabled = false;
				}
				else
				{
					btnMinusV.Text = ((IEleCartesian)_ele).V.Name + "-";
					btnPlusV.Text = ((IEleCartesian)_ele).V.Name + "+";
				}
				if (((IEleCartesian)_ele).W == null)
				{
					btnMinusW.BackColor = Color.Gray;
					btnPlusW.BackColor = Color.Gray;
					btnServoW.BackColor = Color.Gray;
					btnHomeW.BackColor = Color.Gray;
					cmbHomeOrderW.BackColor = Color.Gray;
					btnMinusW.Enabled = false;
					btnPlusW.Enabled = false;
					btnServoW.Enabled = false;
					btnHomeW.Enabled = false;
					cmbHomeOrderW.Enabled = false;
				}
				else
				{
					btnMinusW.Text = ((IEleCartesian)_ele).W.Name + "-";
					btnPlusW.Text = ((IEleCartesian)_ele).W.Name + "+";
				}
			}
		}

		private void LoadManualPanel()
		{
			for (int i = 0; i < _cmbStep.Length; i++)
			{
				ComboBox comboBox = _cmbStep[i];
				comboBox.Items.Clear();
				comboBox.Items.AddRange(new object[12]
				{
					0.02, 0.1, 0.5, 1, 5, 10, 20, 30, 40, 50,
					100, 150
				});
				comboBox.SelectedItem = 10;
				_btnJogPlus[i].BackColor = Color.White;
				_btnJogMinus[i].BackColor = Color.White;
			}
			for (int j = 0; j < _cmbHomeOrder.Length; j++)
			{
				ComboBox comboBox2 = _cmbHomeOrder[j];
				comboBox2.Items.Clear();
				comboBox2.Items.AddRange(new object[6] { 0, 1, 2, 3, 4, 5 });
				_btnHome[j].BackColor = Color.White;
				_btnServo[j].BackColor = Color.White;
			}
		}

		private void LoadTeachPanel(string lastpos = null)
		{
			string[] array = _posList.Select((Pos p) => p.Name ?? "").ToArray();
			cmbPointTeach.Items.Clear();
			ComboBox.ObjectCollection items = cmbPointTeach.Items;
			object[] items2 = array;
			items.AddRange(items2);
			cmbPointTeach.SelectedItem = lastpos;
			cmbPointMove.Items.Clear();
			ComboBox.ObjectCollection items3 = cmbPointMove.Items;
			items2 = array;
			items3.AddRange(items2);
			cmbPointMove.SelectedItem = lastpos;
		}

		private void PlatformDebug_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.EventUpdateStatus?.Invoke(_gId);
		}

		private PosCartesian PosToPosCartesian(int index, Pos pos)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			PosCartesian val = new PosCartesian();
			val.Index = index;
			val.Name = pos.Name;
			val. Pos = new double[6];
			PosCartesian val2 = val;
			if (((IEleCartesian)_ele).AxisXIndex != -1)
			{
				val2.Pos[((IEleCartesian)_ele).AxisXIndex] = pos.X;
			}
			if (((IEleCartesian)_ele).AxisYIndex != -1)
			{
				val2.Pos[((IEleCartesian)_ele).AxisYIndex] = pos.Y;
			}
			if (((IEleCartesian)_ele).AxisZIndex != -1)
			{
				val2.Pos[((IEleCartesian)_ele).AxisZIndex] = pos.Z;
			}
			if (((IEleCartesian)_ele).AxisUIndex != -1)
			{
				val2.Pos[((IEleCartesian)_ele).AxisUIndex] = pos.U;
			}
			if (((IEleCartesian)_ele).AxisVIndex != -1)
			{
				val2.Pos[((IEleCartesian)_ele).AxisVIndex] = pos.V;
			}
			if (((IEleCartesian)_ele).AxisWIndex != -1)
			{
				val2.Pos[((IEleCartesian)_ele).AxisWIndex] = pos.W;
			}
			return val2;
		}

		private void SetEleRunState(EleRunState state)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected I4, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Invalid comparison between Unknown and I4
			if (tbState.InvokeRequired)
			{
				UpdateEleRunState method = SetEleRunState;
				BeginInvoke(method, state);
				return;
			}
			switch ((int)state)
			{
			case 0:
				tbState.BackColor = Color.Khaki;
				tbState.Text = "Idle";
				return;
			case 1:
				tbState.BackColor = Color.LightGreen;
				tbState.Text = "Running";
				return;
			case 4:
				tbState.BackColor = Color.SandyBrown;
				tbState.Text = "Err";
				return;
			case 2:
			case 3:
				return;
			}
			if ((int)state == 100)
			{
				tbState.BackColor = Color.Khaki;
				tbState.Text = "Other";
			}
		}

		private void TeachPos(string name)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			Pos val = new Pos();
			val.Name = name;
			IEleAxis obj = ((IEleCartesian)_ele).X;
			val.X = (obj != null) ? obj.ActualPos : 0.0;
			IEleAxis obj2 = ((IEleCartesian)_ele).Y;
			val.Y = (obj2 != null) ? obj2.ActualPos : 0.0;
			IEleAxis z = ((IEleCartesian)_ele).Z;
			val.Z = (z != null) ? z.ActualPos : 0.0;
			IEleAxis u = ((IEleCartesian)_ele).U;
			val.U = (u != null) ? u.ActualPos : 0.0;
			IEleAxis v = ((IEleCartesian)_ele).V;
			val.V = (v != null) ? v.ActualPos : 0.0;
			IEleAxis w = ((IEleCartesian)_ele).W;
			val.W = (w != null) ? w.ActualPos : 0.0;
			Pos val2 = val;
			if (_posList.Exists((Pos p) => p.Name == name))
			{
				Pos val3 = _posList.FirstOrDefault((Pos p) => p.Name == name);
				if (val3 != null)
				{
					val2 = ((IEleCartesian)_ele).UpdatePos(val3);
				}
			}
			else
			{
				_posList.Add(val2);
			}
			if (_configType == ConfigType.TableTrig)
			{
				this.EventUpdatePos?.Invoke(_configType, _gId, _posList);
			}
			else
			{
				this.EventUpdatePos?.Invoke(_configType, _gId, val2);
			}
		}

		private void TmrRefresh_Tick(object sender, EventArgs e)
		{
			UiRefresh();
		}

		public Pos GetCurPos()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return ((IEleCartesian)_ele).GetActualPos();
		}

		public List<Pos> GetPosList()
		{
			return _posList;
		}

		public void UiRefresh()
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Invalid comparison between Unknown and I4
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			if (base.InvokeRequired)
			{
				Del_GuiRefresh method = UiRefresh;
				BeginInvoke(method);
				return;
			}
			SetEleRunState(_ele.EleRunStat);
			if ((int)_ele.EleRunStat != 1)
			{
				return;
			}
			for (int i = 0; i < ((IEleCartesian)_ele).AxisIndex.Length; i++)
			{
				if (((IEleCartesian)_ele).AxisIndex[i] != -1)
				{
					_tbPos[i].Text = ((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].ActualPos.ToString();
					_tbPos[i].BackColor = (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].IsStop ? Color.White : Color.Lime);
					if (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].IsAlarm)
					{
						_btnServo[i].BackColor = Color.Red;
						_btnJogMinus[i].BackColor = Color.Red;
						_btnJogPlus[i].BackColor = Color.Red;
					}
					else
					{
						_btnServo[i].BackColor = (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].IsServoOn ? Color.Lime : Color.White);
						_btnJogPlus[i].BackColor = (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].IsServoOn ? Color.White : Color.LightGray);
						_btnJogMinus[i].BackColor = (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].IsServoOn ? Color.White : Color.LightGray);
					}
					_btnJogPlus[i].ForeColor = (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].InPel ? Color.Red : Color.Black);
					_btnJogMinus[i].ForeColor = (((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].InMel ? Color.Red : Color.Black);
				}
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
			this.tabPanelBase = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnMinusZ = new System.Windows.Forms.Button();
			this.btnMinusX = new System.Windows.Forms.Button();
			this.btnPlusY = new System.Windows.Forms.Button();
			this.btnMinusW = new System.Windows.Forms.Button();
			this.btnMinusV = new System.Windows.Forms.Button();
			this.btnMinusU = new System.Windows.Forms.Button();
			this.btnMinusY = new System.Windows.Forms.Button();
			this.btnPlusZ = new System.Windows.Forms.Button();
			this.btnAllStop = new System.Windows.Forms.Button();
			this.btnPlusX = new System.Windows.Forms.Button();
			this.btnPlusW = new System.Windows.Forms.Button();
			this.btnPlusV = new System.Windows.Forms.Button();
			this.btnPlusU = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.btnServoOffAll = new System.Windows.Forms.Button();
			this.btnHomeStop = new System.Windows.Forms.Button();
			this.btnHomeAll = new System.Windows.Forms.Button();
			this.btnServoOnAll = new System.Windows.Forms.Button();
			this.cmbHomeOrderW = new System.Windows.Forms.ComboBox();
			this.cmbHomeOrderV = new System.Windows.Forms.ComboBox();
			this.cmbHomeOrderZ = new System.Windows.Forms.ComboBox();
			this.cmbHomeOrderY = new System.Windows.Forms.ComboBox();
			this.cmbHomeOrderX = new System.Windows.Forms.ComboBox();
			this.btnServoW = new System.Windows.Forms.Button();
			this.btnHomeW = new System.Windows.Forms.Button();
			this.btnServoV = new System.Windows.Forms.Button();
			this.btnHomeV = new System.Windows.Forms.Button();
			this.btnServoU = new System.Windows.Forms.Button();
			this.btnHomeU = new System.Windows.Forms.Button();
			this.btnServoZ = new System.Windows.Forms.Button();
			this.btnHomeZ = new System.Windows.Forms.Button();
			this.btnServoY = new System.Windows.Forms.Button();
			this.btnHomeY = new System.Windows.Forms.Button();
			this.btnServoX = new System.Windows.Forms.Button();
			this.btnHomeX = new System.Windows.Forms.Button();
			this.cmbHomeOrderU = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnPosMoveP = new System.Windows.Forms.Button();
			this.btnPosTeach = new System.Windows.Forms.Button();
			this.cmbPointMove = new System.Windows.Forms.ComboBox();
			this.cmbPointTeach = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tbPosW = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPosZ = new System.Windows.Forms.TextBox();
			this.tbPosX = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbPosY = new System.Windows.Forms.TextBox();
			this.tbPosU = new System.Windows.Forms.TextBox();
			this.tbPosV = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label30 = new System.Windows.Forms.Label();
			this.cmbStepX = new System.Windows.Forms.ComboBox();
			this.label29 = new System.Windows.Forms.Label();
			this.cmbStepU = new System.Windows.Forms.ComboBox();
			this.label28 = new System.Windows.Forms.Label();
			this.cmbStepW = new System.Windows.Forms.ComboBox();
			this.cmbStepY = new System.Windows.Forms.ComboBox();
			this.cmbStepZ = new System.Windows.Forms.ComboBox();
			this.cmbStepV = new System.Windows.Forms.ComboBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbState = new System.Windows.Forms.TextBox();
			this.lbState = new System.Windows.Forms.Label();
			this.tbInfo = new System.Windows.Forms.TextBox();
			this.lbInfo = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.lbName = new System.Windows.Forms.Label();
			this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
			this.tabPanelBase.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.tabPanelBase.ColumnCount = 1;
			this.tabPanelBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tabPanelBase.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tabPanelBase.Controls.Add(this.panel1, 0, 0);
			this.tabPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPanelBase.Location = new System.Drawing.Point(0, 0);
			this.tabPanelBase.Name = "tabPanelBase";
			this.tabPanelBase.RowCount = 2;
			this.tabPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
			this.tabPanelBase.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tabPanelBase.Size = new System.Drawing.Size(765, 366);
			this.tabPanelBase.TabIndex = 1;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.42496f));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.57504f));
			this.tableLayoutPanel2.Controls.Add(this.tabControl2, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 33);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(759, 330);
			this.tableLayoutPanel2.TabIndex = 2;
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl2.ItemSize = new System.Drawing.Size(80, 25);
			this.tabControl2.Location = new System.Drawing.Point(4, 4);
			this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(450, 322);
			this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl2.TabIndex = 5;
			this.tabPage3.Controls.Add(this.btnMinusZ);
			this.tabPage3.Controls.Add(this.btnMinusX);
			this.tabPage3.Controls.Add(this.btnPlusY);
			this.tabPage3.Controls.Add(this.btnMinusW);
			this.tabPage3.Controls.Add(this.btnMinusV);
			this.tabPage3.Controls.Add(this.btnMinusU);
			this.tabPage3.Controls.Add(this.btnMinusY);
			this.tabPage3.Controls.Add(this.btnPlusZ);
			this.tabPage3.Controls.Add(this.btnAllStop);
			this.tabPage3.Controls.Add(this.btnPlusX);
			this.tabPage3.Controls.Add(this.btnPlusW);
			this.tabPage3.Controls.Add(this.btnPlusV);
			this.tabPage3.Controls.Add(this.btnPlusU);
			this.tabPage3.Location = new System.Drawing.Point(4, 29);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage3.Size = new System.Drawing.Size(442, 289);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Move";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.btnMinusZ.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnMinusZ.Location = new System.Drawing.Point(339, 106);
			this.btnMinusZ.Margin = new System.Windows.Forms.Padding(4);
			this.btnMinusZ.Name = "btnMinusZ";
			this.btnMinusZ.Size = new System.Drawing.Size(100, 50);
			this.btnMinusZ.TabIndex = 0;
			this.btnMinusZ.Text = "Z-";
			this.btnMinusZ.UseVisualStyleBackColor = true;
			this.btnMinusX.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnMinusX.Location = new System.Drawing.Point(8, 58);
			this.btnMinusX.Margin = new System.Windows.Forms.Padding(4);
			this.btnMinusX.Name = "btnMinusX";
			this.btnMinusX.Size = new System.Drawing.Size(100, 50);
			this.btnMinusX.TabIndex = 0;
			this.btnMinusX.Text = "X-";
			this.btnMinusX.UseVisualStyleBackColor = true;
			this.btnPlusY.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnPlusY.Location = new System.Drawing.Point(118, 8);
			this.btnPlusY.Margin = new System.Windows.Forms.Padding(4);
			this.btnPlusY.Name = "btnPlusY";
			this.btnPlusY.Size = new System.Drawing.Size(100, 50);
			this.btnPlusY.TabIndex = 0;
			this.btnPlusY.Text = "Y+";
			this.btnPlusY.UseVisualStyleBackColor = true;
			this.btnMinusW.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnMinusW.Location = new System.Drawing.Point(228, 226);
			this.btnMinusW.Margin = new System.Windows.Forms.Padding(4);
			this.btnMinusW.Name = "btnMinusW";
			this.btnMinusW.Size = new System.Drawing.Size(100, 50);
			this.btnMinusW.TabIndex = 0;
			this.btnMinusW.Text = "W-";
			this.btnMinusW.UseVisualStyleBackColor = true;
			this.btnMinusV.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnMinusV.Location = new System.Drawing.Point(119, 226);
			this.btnMinusV.Margin = new System.Windows.Forms.Padding(4);
			this.btnMinusV.Name = "btnMinusV";
			this.btnMinusV.Size = new System.Drawing.Size(100, 50);
			this.btnMinusV.TabIndex = 0;
			this.btnMinusV.Text = "V-";
			this.btnMinusV.UseVisualStyleBackColor = true;
			this.btnMinusU.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnMinusU.Location = new System.Drawing.Point(8, 226);
			this.btnMinusU.Margin = new System.Windows.Forms.Padding(4);
			this.btnMinusU.Name = "btnMinusU";
			this.btnMinusU.Size = new System.Drawing.Size(100, 50);
			this.btnMinusU.TabIndex = 0;
			this.btnMinusU.Text = "U-";
			this.btnMinusU.UseVisualStyleBackColor = true;
			this.btnMinusY.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnMinusY.Location = new System.Drawing.Point(119, 106);
			this.btnMinusY.Margin = new System.Windows.Forms.Padding(4);
			this.btnMinusY.Name = "btnMinusY";
			this.btnMinusY.Size = new System.Drawing.Size(100, 50);
			this.btnMinusY.TabIndex = 0;
			this.btnMinusY.Text = "Y-";
			this.btnMinusY.UseVisualStyleBackColor = true;
			this.btnPlusZ.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnPlusZ.Location = new System.Drawing.Point(339, 8);
			this.btnPlusZ.Margin = new System.Windows.Forms.Padding(4);
			this.btnPlusZ.Name = "btnPlusZ";
			this.btnPlusZ.Size = new System.Drawing.Size(100, 50);
			this.btnPlusZ.TabIndex = 0;
			this.btnPlusZ.Text = "Z+";
			this.btnPlusZ.UseVisualStyleBackColor = true;
			this.btnAllStop.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnAllStop.Location = new System.Drawing.Point(339, 163);
			this.btnAllStop.Margin = new System.Windows.Forms.Padding(4);
			this.btnAllStop.Name = "btnAllStop";
			this.btnAllStop.Size = new System.Drawing.Size(100, 113);
			this.btnAllStop.TabIndex = 0;
			this.btnAllStop.Text = "Stop";
			this.btnAllStop.UseVisualStyleBackColor = true;
			this.btnPlusX.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnPlusX.Location = new System.Drawing.Point(228, 58);
			this.btnPlusX.Margin = new System.Windows.Forms.Padding(4);
			this.btnPlusX.Name = "btnPlusX";
			this.btnPlusX.Size = new System.Drawing.Size(100, 50);
			this.btnPlusX.TabIndex = 0;
			this.btnPlusX.Text = "X+";
			this.btnPlusX.UseVisualStyleBackColor = true;
			this.btnPlusW.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnPlusW.Location = new System.Drawing.Point(228, 163);
			this.btnPlusW.Margin = new System.Windows.Forms.Padding(4);
			this.btnPlusW.Name = "btnPlusW";
			this.btnPlusW.Size = new System.Drawing.Size(100, 50);
			this.btnPlusW.TabIndex = 0;
			this.btnPlusW.Text = "W+";
			this.btnPlusW.UseVisualStyleBackColor = true;
			this.btnPlusV.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnPlusV.Location = new System.Drawing.Point(118, 163);
			this.btnPlusV.Margin = new System.Windows.Forms.Padding(4);
			this.btnPlusV.Name = "btnPlusV";
			this.btnPlusV.Size = new System.Drawing.Size(100, 50);
			this.btnPlusV.TabIndex = 0;
			this.btnPlusV.Text = "V+";
			this.btnPlusV.UseVisualStyleBackColor = true;
			this.btnPlusU.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnPlusU.Location = new System.Drawing.Point(8, 163);
			this.btnPlusU.Margin = new System.Windows.Forms.Padding(4);
			this.btnPlusU.Name = "btnPlusU";
			this.btnPlusU.Size = new System.Drawing.Size(100, 50);
			this.btnPlusU.TabIndex = 0;
			this.btnPlusU.Text = "U+";
			this.btnPlusU.UseVisualStyleBackColor = true;
			this.tabPage4.Controls.Add(this.btnServoOffAll);
			this.tabPage4.Controls.Add(this.btnHomeStop);
			this.tabPage4.Controls.Add(this.btnHomeAll);
			this.tabPage4.Controls.Add(this.btnServoOnAll);
			this.tabPage4.Controls.Add(this.cmbHomeOrderW);
			this.tabPage4.Controls.Add(this.cmbHomeOrderV);
			this.tabPage4.Controls.Add(this.cmbHomeOrderZ);
			this.tabPage4.Controls.Add(this.cmbHomeOrderY);
			this.tabPage4.Controls.Add(this.cmbHomeOrderX);
			this.tabPage4.Controls.Add(this.btnServoW);
			this.tabPage4.Controls.Add(this.btnHomeW);
			this.tabPage4.Controls.Add(this.btnServoV);
			this.tabPage4.Controls.Add(this.btnHomeV);
			this.tabPage4.Controls.Add(this.btnServoU);
			this.tabPage4.Controls.Add(this.btnHomeU);
			this.tabPage4.Controls.Add(this.btnServoZ);
			this.tabPage4.Controls.Add(this.btnHomeZ);
			this.tabPage4.Controls.Add(this.btnServoY);
			this.tabPage4.Controls.Add(this.btnHomeY);
			this.tabPage4.Controls.Add(this.btnServoX);
			this.tabPage4.Controls.Add(this.btnHomeX);
			this.tabPage4.Controls.Add(this.cmbHomeOrderU);
			this.tabPage4.Location = new System.Drawing.Point(4, 29);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage4.Size = new System.Drawing.Size(442, 289);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Origin";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.btnServoOffAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnServoOffAll.Location = new System.Drawing.Point(121, 223);
			this.btnServoOffAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnServoOffAll.Name = "btnServoOffAll";
			this.btnServoOffAll.Size = new System.Drawing.Size(100, 45);
			this.btnServoOffAll.TabIndex = 4;
			this.btnServoOffAll.Text = "All Axis Servo-OFF";
			this.btnServoOffAll.UseVisualStyleBackColor = true;
			this.btnServoOffAll.Click += new System.EventHandler(BtnServoOffAll_Click);
			this.btnHomeStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnHomeStop.Location = new System.Drawing.Point(349, 7);
			this.btnHomeStop.Margin = new System.Windows.Forms.Padding(4);
			this.btnHomeStop.Name = "btnHomeStop";
			this.btnHomeStop.Size = new System.Drawing.Size(88, 262);
			this.btnHomeStop.TabIndex = 3;
			this.btnHomeStop.Text = "Stop";
			this.btnHomeStop.UseVisualStyleBackColor = true;
			this.btnHomeStop.Click += new System.EventHandler(BtnAllStop_Click);
			this.btnHomeAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnHomeAll.Location = new System.Drawing.Point(243, 220);
			this.btnHomeAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnHomeAll.Name = "btnHomeAll";
			this.btnHomeAll.Size = new System.Drawing.Size(100, 51);
			this.btnHomeAll.TabIndex = 2;
			this.btnHomeAll.Text = "All Axis Zero";
			this.btnHomeAll.UseVisualStyleBackColor = true;
			this.btnHomeAll.Click += new System.EventHandler(BtnHomeAll_Click);
			this.btnServoOnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnServoOnAll.Location = new System.Drawing.Point(8, 224);
			this.btnServoOnAll.Margin = new System.Windows.Forms.Padding(4);
			this.btnServoOnAll.Name = "btnServoOnAll";
			this.btnServoOnAll.Size = new System.Drawing.Size(100, 45);
			this.btnServoOnAll.TabIndex = 2;
			this.btnServoOnAll.Text = "All Axis Servo-ON";
			this.btnServoOnAll.UseVisualStyleBackColor = true;
			this.btnServoOnAll.Click += new System.EventHandler(BtnServoOnAll_Click);
			this.cmbHomeOrderW.FormattingEnabled = true;
			this.cmbHomeOrderW.Location = new System.Drawing.Point(116, 188);
			this.cmbHomeOrderW.Margin = new System.Windows.Forms.Padding(4);
			this.cmbHomeOrderW.Name = "cmbHomeOrderW";
			this.cmbHomeOrderW.Size = new System.Drawing.Size(117, 23);
			this.cmbHomeOrderW.TabIndex = 0;
			this.cmbHomeOrderV.FormattingEnabled = true;
			this.cmbHomeOrderV.Location = new System.Drawing.Point(116, 152);
			this.cmbHomeOrderV.Margin = new System.Windows.Forms.Padding(4);
			this.cmbHomeOrderV.Name = "cmbHomeOrderV";
			this.cmbHomeOrderV.Size = new System.Drawing.Size(117, 23);
			this.cmbHomeOrderV.TabIndex = 0;
			this.cmbHomeOrderZ.FormattingEnabled = true;
			this.cmbHomeOrderZ.Location = new System.Drawing.Point(116, 80);
			this.cmbHomeOrderZ.Margin = new System.Windows.Forms.Padding(4);
			this.cmbHomeOrderZ.Name = "cmbHomeOrderZ";
			this.cmbHomeOrderZ.Size = new System.Drawing.Size(117, 23);
			this.cmbHomeOrderZ.TabIndex = 0;
			this.cmbHomeOrderY.FormattingEnabled = true;
			this.cmbHomeOrderY.Location = new System.Drawing.Point(116, 43);
			this.cmbHomeOrderY.Margin = new System.Windows.Forms.Padding(4);
			this.cmbHomeOrderY.Name = "cmbHomeOrderY";
			this.cmbHomeOrderY.Size = new System.Drawing.Size(117, 23);
			this.cmbHomeOrderY.TabIndex = 0;
			this.cmbHomeOrderX.FormattingEnabled = true;
			this.cmbHomeOrderX.Location = new System.Drawing.Point(116, 7);
			this.cmbHomeOrderX.Margin = new System.Windows.Forms.Padding(4);
			this.cmbHomeOrderX.Name = "cmbHomeOrderX";
			this.cmbHomeOrderX.Size = new System.Drawing.Size(117, 23);
			this.cmbHomeOrderX.TabIndex = 0;
			this.btnServoW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnServoW.Location = new System.Drawing.Point(8, 186);
			this.btnServoW.Margin = new System.Windows.Forms.Padding(4);
			this.btnServoW.Name = "btnServoW";
			this.btnServoW.Size = new System.Drawing.Size(100, 29);
			this.btnServoW.TabIndex = 1;
			this.btnServoW.Text = "W -Servo";
			this.btnServoW.UseVisualStyleBackColor = true;
			this.btnHomeW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnHomeW.Location = new System.Drawing.Point(243, 188);
			this.btnHomeW.Margin = new System.Windows.Forms.Padding(4);
			this.btnHomeW.Name = "btnHomeW";
			this.btnHomeW.Size = new System.Drawing.Size(100, 29);
			this.btnHomeW.TabIndex = 1;
			this.btnHomeW.Text = "W -Zero";
			this.btnHomeW.UseVisualStyleBackColor = true;
			this.btnServoV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnServoV.Location = new System.Drawing.Point(8, 150);
			this.btnServoV.Margin = new System.Windows.Forms.Padding(4);
			this.btnServoV.Name = "btnServoV";
			this.btnServoV.Size = new System.Drawing.Size(100, 29);
			this.btnServoV.TabIndex = 1;
			this.btnServoV.Text = "V -Servo";
			this.btnServoV.UseVisualStyleBackColor = true;
			this.btnHomeV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnHomeV.Location = new System.Drawing.Point(243, 152);
			this.btnHomeV.Margin = new System.Windows.Forms.Padding(4);
			this.btnHomeV.Name = "btnHomeV";
			this.btnHomeV.Size = new System.Drawing.Size(100, 29);
			this.btnHomeV.TabIndex = 1;
			this.btnHomeV.Text = "V -Zero";
			this.btnHomeV.UseVisualStyleBackColor = true;
			this.btnServoU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnServoU.Location = new System.Drawing.Point(8, 113);
			this.btnServoU.Margin = new System.Windows.Forms.Padding(4);
			this.btnServoU.Name = "btnServoU";
			this.btnServoU.Size = new System.Drawing.Size(100, 29);
			this.btnServoU.TabIndex = 1;
			this.btnServoU.Text = "U -Servo";
			this.btnServoU.UseVisualStyleBackColor = true;
			this.btnHomeU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnHomeU.Location = new System.Drawing.Point(243, 116);
			this.btnHomeU.Margin = new System.Windows.Forms.Padding(4);
			this.btnHomeU.Name = "btnHomeU";
			this.btnHomeU.Size = new System.Drawing.Size(100, 29);
			this.btnHomeU.TabIndex = 1;
			this.btnHomeU.Text = "U -Zero";
			this.btnHomeU.UseVisualStyleBackColor = true;
			this.btnServoZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnServoZ.Location = new System.Drawing.Point(8, 77);
			this.btnServoZ.Margin = new System.Windows.Forms.Padding(4);
			this.btnServoZ.Name = "btnServoZ";
			this.btnServoZ.Size = new System.Drawing.Size(100, 29);
			this.btnServoZ.TabIndex = 1;
			this.btnServoZ.Text = "Z -Servo";
			this.btnServoZ.UseVisualStyleBackColor = true;
			this.btnHomeZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnHomeZ.Location = new System.Drawing.Point(243, 80);
			this.btnHomeZ.Margin = new System.Windows.Forms.Padding(4);
			this.btnHomeZ.Name = "btnHomeZ";
			this.btnHomeZ.Size = new System.Drawing.Size(100, 29);
			this.btnHomeZ.TabIndex = 1;
			this.btnHomeZ.Text = "Z -Zero";
			this.btnHomeZ.UseVisualStyleBackColor = true;
			this.btnServoY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnServoY.Location = new System.Drawing.Point(8, 41);
			this.btnServoY.Margin = new System.Windows.Forms.Padding(4);
			this.btnServoY.Name = "btnServoY";
			this.btnServoY.Size = new System.Drawing.Size(100, 29);
			this.btnServoY.TabIndex = 1;
			this.btnServoY.Text = "Y -Servo";
			this.btnServoY.UseVisualStyleBackColor = true;
			this.btnHomeY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnHomeY.Location = new System.Drawing.Point(243, 43);
			this.btnHomeY.Margin = new System.Windows.Forms.Padding(4);
			this.btnHomeY.Name = "btnHomeY";
			this.btnHomeY.Size = new System.Drawing.Size(100, 29);
			this.btnHomeY.TabIndex = 1;
			this.btnHomeY.Text = "Y -Zero";
			this.btnHomeY.UseVisualStyleBackColor = true;
			this.btnServoX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnServoX.Location = new System.Drawing.Point(8, 4);
			this.btnServoX.Margin = new System.Windows.Forms.Padding(4);
			this.btnServoX.Name = "btnServoX";
			this.btnServoX.Size = new System.Drawing.Size(100, 29);
			this.btnServoX.TabIndex = 1;
			this.btnServoX.Text = "X -Servo";
			this.btnServoX.UseVisualStyleBackColor = true;
			this.btnHomeX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnHomeX.Location = new System.Drawing.Point(243, 7);
			this.btnHomeX.Margin = new System.Windows.Forms.Padding(4);
			this.btnHomeX.Name = "btnHomeX";
			this.btnHomeX.Size = new System.Drawing.Size(100, 29);
			this.btnHomeX.TabIndex = 1;
			this.btnHomeX.Text = "X -Zero";
			this.btnHomeX.UseVisualStyleBackColor = true;
			this.cmbHomeOrderU.FormattingEnabled = true;
			this.cmbHomeOrderU.Location = new System.Drawing.Point(116, 116);
			this.cmbHomeOrderU.Margin = new System.Windows.Forms.Padding(4);
			this.cmbHomeOrderU.Name = "cmbHomeOrderU";
			this.cmbHomeOrderU.Size = new System.Drawing.Size(117, 23);
			this.cmbHomeOrderU.TabIndex = 0;
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.groupBox5, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(461, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 3;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.75f));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.8125f));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.125f));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(295, 324);
			this.tableLayoutPanel3.TabIndex = 6;
			this.groupBox2.Controls.Add(this.btnPosMoveP);
			this.groupBox2.Controls.Add(this.btnPosTeach);
			this.groupBox2.Controls.Add(this.cmbPointMove);
			this.groupBox2.Controls.Add(this.cmbPointTeach);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.groupBox2.Location = new System.Drawing.Point(4, 235);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(287, 85);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Test";
			this.btnPosMoveP.Location = new System.Drawing.Point(118, 52);
			this.btnPosMoveP.Margin = new System.Windows.Forms.Padding(4);
			this.btnPosMoveP.Name = "btnPosMoveP";
			this.btnPosMoveP.Size = new System.Drawing.Size(59, 29);
			this.btnPosMoveP.TabIndex = 6;
			this.btnPosMoveP.Text = "MoveP";
			this.btnPosMoveP.UseVisualStyleBackColor = true;
			this.btnPosMoveP.Click += new System.EventHandler(BtnPosMoveP_Click);
			this.btnPosTeach.Location = new System.Drawing.Point(118, 14);
			this.btnPosTeach.Margin = new System.Windows.Forms.Padding(4);
			this.btnPosTeach.Name = "btnPosTeach";
			this.btnPosTeach.Size = new System.Drawing.Size(59, 29);
			this.btnPosTeach.TabIndex = 4;
			this.btnPosTeach.Text = "Teach";
			this.btnPosTeach.UseVisualStyleBackColor = true;
			this.btnPosTeach.Click += new System.EventHandler(BtnPosTeach_Click);
			this.cmbPointMove.FormattingEnabled = true;
			this.cmbPointMove.Location = new System.Drawing.Point(8, 54);
			this.cmbPointMove.Margin = new System.Windows.Forms.Padding(4);
			this.cmbPointMove.Name = "cmbPointMove";
			this.cmbPointMove.Size = new System.Drawing.Size(102, 23);
			this.cmbPointMove.TabIndex = 2;
			this.cmbPointTeach.FormattingEnabled = true;
			this.cmbPointTeach.Location = new System.Drawing.Point(8, 19);
			this.cmbPointTeach.Margin = new System.Windows.Forms.Padding(4);
			this.cmbPointTeach.Name = "cmbPointTeach";
			this.cmbPointTeach.Size = new System.Drawing.Size(102, 23);
			this.cmbPointTeach.TabIndex = 1;
			this.groupBox4.Controls.Add(this.tbPosW);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.tbPosZ);
			this.groupBox4.Controls.Add(this.tbPosX);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.tbPosY);
			this.groupBox4.Controls.Add(this.tbPosU);
			this.groupBox4.Controls.Add(this.tbPosV);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.groupBox4.Location = new System.Drawing.Point(4, 129);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox4.Size = new System.Drawing.Size(287, 98);
			this.groupBox4.TabIndex = 26;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Position";
			this.tbPosW.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tbPosW.Location = new System.Drawing.Point(197, 72);
			this.tbPosW.Margin = new System.Windows.Forms.Padding(4);
			this.tbPosW.Name = "tbPosW";
			this.tbPosW.ReadOnly = true;
			this.tbPosW.Size = new System.Drawing.Size(80, 21);
			this.tbPosW.TabIndex = 5;
			this.tbPosW.Text = "0.000";
			this.tbPosW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(233, 56);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(18, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = "W";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new System.Drawing.Point(233, 18);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Z";
			this.tbPosZ.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tbPosZ.Location = new System.Drawing.Point(197, 34);
			this.tbPosZ.Margin = new System.Windows.Forms.Padding(4);
			this.tbPosZ.Name = "tbPosZ";
			this.tbPosZ.ReadOnly = true;
			this.tbPosZ.Size = new System.Drawing.Size(80, 21);
			this.tbPosZ.TabIndex = 2;
			this.tbPosZ.Text = "0.000";
			this.tbPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPosX.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tbPosX.Location = new System.Drawing.Point(3, 34);
			this.tbPosX.Margin = new System.Windows.Forms.Padding(4);
			this.tbPosX.Name = "tbPosX";
			this.tbPosX.ReadOnly = true;
			this.tbPosX.Size = new System.Drawing.Size(80, 21);
			this.tbPosX.TabIndex = 0;
			this.tbPosX.Text = "0.000";
			this.tbPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new System.Drawing.Point(38, 56);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 15);
			this.label6.TabIndex = 1;
			this.label6.Text = "U";
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(136, 56);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 15);
			this.label5.TabIndex = 1;
			this.label5.Text = "V";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(135, 18);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Y";
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(38, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(15, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "X";
			this.tbPosY.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tbPosY.Location = new System.Drawing.Point(100, 34);
			this.tbPosY.Margin = new System.Windows.Forms.Padding(4);
			this.tbPosY.Name = "tbPosY";
			this.tbPosY.ReadOnly = true;
			this.tbPosY.Size = new System.Drawing.Size(80, 21);
			this.tbPosY.TabIndex = 0;
			this.tbPosY.Text = "0.000";
			this.tbPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPosU.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tbPosU.Location = new System.Drawing.Point(3, 72);
			this.tbPosU.Margin = new System.Windows.Forms.Padding(4);
			this.tbPosU.Name = "tbPosU";
			this.tbPosU.ReadOnly = true;
			this.tbPosU.Size = new System.Drawing.Size(80, 21);
			this.tbPosU.TabIndex = 0;
			this.tbPosU.Text = "0.000";
			this.tbPosU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPosV.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tbPosV.Location = new System.Drawing.Point(100, 72);
			this.tbPosV.Margin = new System.Windows.Forms.Padding(4);
			this.tbPosV.Name = "tbPosV";
			this.tbPosV.ReadOnly = true;
			this.tbPosV.Size = new System.Drawing.Size(80, 21);
			this.tbPosV.TabIndex = 0;
			this.tbPosV.Text = "0.000";
			this.tbPosV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.groupBox5.Controls.Add(this.label30);
			this.groupBox5.Controls.Add(this.cmbStepX);
			this.groupBox5.Controls.Add(this.label29);
			this.groupBox5.Controls.Add(this.cmbStepU);
			this.groupBox5.Controls.Add(this.label28);
			this.groupBox5.Controls.Add(this.cmbStepW);
			this.groupBox5.Controls.Add(this.cmbStepY);
			this.groupBox5.Controls.Add(this.cmbStepZ);
			this.groupBox5.Controls.Add(this.cmbStepV);
			this.groupBox5.Controls.Add(this.label27);
			this.groupBox5.Controls.Add(this.label25);
			this.groupBox5.Controls.Add(this.label26);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.groupBox5.Location = new System.Drawing.Point(4, 4);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox5.Size = new System.Drawing.Size(287, 117);
			this.groupBox5.TabIndex = 25;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Step Length";
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label30.Location = new System.Drawing.Point(37, 63);
			this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(16, 15);
			this.label30.TabIndex = 1;
			this.label30.Text = "U";
			this.cmbStepX.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbStepX.FormattingEnabled = true;
			this.cmbStepX.Location = new System.Drawing.Point(2, 39);
			this.cmbStepX.Margin = new System.Windows.Forms.Padding(4);
			this.cmbStepX.Name = "cmbStepX";
			this.cmbStepX.Size = new System.Drawing.Size(81, 24);
			this.cmbStepX.TabIndex = 1;
			this.cmbStepX.Text = "10";
			this.label29.AutoSize = true;
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label29.Location = new System.Drawing.Point(133, 63);
			this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(14, 15);
			this.label29.TabIndex = 1;
			this.label29.Text = "V";
			this.cmbStepU.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbStepU.FormattingEnabled = true;
			this.cmbStepU.Location = new System.Drawing.Point(2, 79);
			this.cmbStepU.Margin = new System.Windows.Forms.Padding(4);
			this.cmbStepU.Name = "cmbStepU";
			this.cmbStepU.Size = new System.Drawing.Size(81, 24);
			this.cmbStepU.TabIndex = 1;
			this.cmbStepU.Text = "10";
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label28.Location = new System.Drawing.Point(229, 63);
			this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(18, 15);
			this.label28.TabIndex = 1;
			this.label28.Text = "W";
			this.cmbStepW.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbStepW.FormattingEnabled = true;
			this.cmbStepW.Location = new System.Drawing.Point(194, 79);
			this.cmbStepW.Margin = new System.Windows.Forms.Padding(4);
			this.cmbStepW.Name = "cmbStepW";
			this.cmbStepW.Size = new System.Drawing.Size(81, 24);
			this.cmbStepW.TabIndex = 1;
			this.cmbStepW.Text = "10";
			this.cmbStepY.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbStepY.FormattingEnabled = true;
			this.cmbStepY.Location = new System.Drawing.Point(98, 39);
			this.cmbStepY.Margin = new System.Windows.Forms.Padding(4);
			this.cmbStepY.Name = "cmbStepY";
			this.cmbStepY.Size = new System.Drawing.Size(81, 24);
			this.cmbStepY.TabIndex = 1;
			this.cmbStepY.Text = "10";
			this.cmbStepZ.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbStepZ.FormattingEnabled = true;
			this.cmbStepZ.Location = new System.Drawing.Point(194, 39);
			this.cmbStepZ.Margin = new System.Windows.Forms.Padding(4);
			this.cmbStepZ.Name = "cmbStepZ";
			this.cmbStepZ.Size = new System.Drawing.Size(81, 24);
			this.cmbStepZ.TabIndex = 1;
			this.cmbStepZ.Text = "10";
			this.cmbStepV.Font = new System.Drawing.Font("Arial Narrow", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbStepV.FormattingEnabled = true;
			this.cmbStepV.Location = new System.Drawing.Point(98, 79);
			this.cmbStepV.Margin = new System.Windows.Forms.Padding(4);
			this.cmbStepV.Name = "cmbStepV";
			this.cmbStepV.Size = new System.Drawing.Size(81, 24);
			this.cmbStepV.TabIndex = 1;
			this.cmbStepV.Text = "10";
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label27.Location = new System.Drawing.Point(229, 20);
			this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(14, 15);
			this.label27.TabIndex = 1;
			this.label27.Text = "Z";
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label25.Location = new System.Drawing.Point(37, 20);
			this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(15, 15);
			this.label25.TabIndex = 1;
			this.label25.Text = "X";
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label26.Location = new System.Drawing.Point(133, 20);
			this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(14, 15);
			this.label26.TabIndex = 1;
			this.label26.Text = "Y";
			this.panel1.Controls.Add(this.tbState);
			this.panel1.Controls.Add(this.lbState);
			this.panel1.Controls.Add(this.tbInfo);
			this.panel1.Controls.Add(this.lbInfo);
			this.panel1.Controls.Add(this.tbName);
			this.panel1.Controls.Add(this.lbName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(759, 24);
			this.panel1.TabIndex = 1;
			this.tbState.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbState.Location = new System.Drawing.Point(498, 0);
			this.tbState.Multiline = true;
			this.tbState.Name = "tbState";
			this.tbState.Size = new System.Drawing.Size(100, 24);
			this.tbState.TabIndex = 9;
			this.tbState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.lbState.BackColor = System.Drawing.SystemColors.Highlight;
			this.lbState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbState.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbState.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.lbState.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbState.Location = new System.Drawing.Point(423, 0);
			this.lbState.Name = "lbState";
			this.lbState.Size = new System.Drawing.Size(75, 24);
			this.lbState.TabIndex = 8;
			this.lbState.Text = "State";
			this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbState.Click += new System.EventHandler(LbState_Click);
			this.tbInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbInfo.Location = new System.Drawing.Point(298, 0);
			this.tbInfo.Multiline = true;
			this.tbInfo.Name = "tbInfo";
			this.tbInfo.Size = new System.Drawing.Size(125, 24);
			this.tbInfo.TabIndex = 7;
			this.tbInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.lbInfo.BackColor = System.Drawing.SystemColors.Highlight;
			this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbInfo.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.lbInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbInfo.Location = new System.Drawing.Point(199, 0);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Size = new System.Drawing.Size(99, 24);
			this.lbInfo.TabIndex = 6;
			this.lbInfo.Text = "Info";
			this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbName.Location = new System.Drawing.Point(74, 0);
			this.tbName.Multiline = true;
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(125, 24);
			this.tbName.TabIndex = 5;
			this.lbName.BackColor = System.Drawing.SystemColors.Highlight;
			this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbName.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbName.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.lbName.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.lbName.Location = new System.Drawing.Point(0, 0);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(74, 24);
			this.lbName.TabIndex = 4;
			this.lbName.Text = "Name";
			this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.tmrRefresh.Tick += new System.EventHandler(TmrRefresh_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(765, 366);
			base.Controls.Add(this.tabPanelBase);
			this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Name = "PlatformDebug";
			this.Text = "PlatformDebug";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(PlatformDebug_FormClosing);
			base.Load += new System.EventHandler(DebugUI_Load);
			this.tabPanelBase.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
