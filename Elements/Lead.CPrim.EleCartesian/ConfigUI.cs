using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.LocalizationService;

namespace Lead.CPrim.EleCartesian.EleUIs
{
    public partial class ConfigUI : UserControl
    {
        private delegate void UpdateEleRunState(EleRunState state);
        private delegate void UpdateEleSimulateMode(bool simulate);

        private delegate void Del_GuiRefresh();
        private EleCartesian _ele;
        private ConcurrentDictionary<int, SingleAxisConfigControl> _axisConfigControls = new ConcurrentDictionary<int, SingleAxisConfigControl>();
        private ConcurrentDictionary<int, SingleAxisStatusControl> _axisStatusControls = new ConcurrentDictionary<int, SingleAxisStatusControl>();

        private AxisesPointsConfig _pointsForm;

        private int _oldAxisesNum;
        private bool _firstLoadAxisNum;

        #region Manual TabPage

        private Button[] _btnJogPlus;
        private Button[] _btnJogMinus;
        private string[] _btnJogPlusName;
        private string[] _btnJogMinusName;

        private TextBox[] _tbPos;
        private ComboBox[] _cmbStep;
        private TextBox[] _tbVel;
        private TextBox[] _tbMel;
        private TextBox[] _tbPel;
        private TextBox[] _tbOrg;

        private Button[] _btnServo;
        private Button[] _btnHome;
        private ComboBox[] _cmbHomeOrder;

        private RadioButton[] _radStepDistance;

        private double[] _curPos;
        private string[] _axisName;

        private SingleAxis[] _axis = new SingleAxis[6];
        private int[] _axisIndex = new int[6];
        #endregion
        public ConfigUI()
        {
            InitializeComponent();
            InitializeUI();
        }

        public ConfigUI(EleCartesian ele)
        {
            InitializeComponent();
            InitializeUI();
            _ele = ele;

            _curPos = new double[6];
            _axisName = new[] {"X", "Y", "Z", "U", "V", "W"};
            _axisIndex = new[] {-1, -1, -1, -1, -1, -1};

            _btnJogPlus = new[] {btnPlusX, btnPlusY, btnPlusZ, btnPlusU, btnPlusV, btnPlusW};
            _btnJogMinus = new[] {btnMinusX, btnMinusY, btnMinusZ, btnMinusU, btnMinusV, btnMinusW};
            _btnJogPlus.ToList().ForEach(p => p.Click += BtnJog_Click);

            _tbPos = new[] {tbPosX, tbPosY, tbPosZ, tbPosU, tbPosV, tbPosW};
            _tbVel = new[] {tbVelX, tbVelY, tbVelZ, tbVelU, tbVelV, tbVelW};
            _cmbStep = new[] {cmbStepX, cmbStepY, cmbStepZ, cmbStepU, cmbStepV, cmbStepW};
            _tbPel = new[] {tbPelX, tbPelY, tbPelZ, tbPelU, tbPelV, tbPelW};
            _tbMel = new[] {tbMelX, tbMelY, tbMelZ, tbMelU, tbMelV, tbMelW};
            _tbOrg = new[] {tbOrgX, tbOrgY, tbOrgZ, tbOrgU, tbOrgV, tbOrgW};

            _btnServo = new[] {btnServoX, btnServoY, btnServoZ, btnServoU, btnServoV, btnServoW};
            _btnServo.ToList().ForEach(p => p.Click += BtnServo_Click);

            _btnHome = new[] {btnHomeX, btnHomeY, btnHomeZ, btnHomeU, btnHomeV, btnHomeW};
            _btnHome.ToList().ForEach(p => p.Click += BtnHome_Click);

            _cmbHomeOrder = new[]
                {cmbHomeOrderX, cmbHomeOrderY, cmbHomeOrderZ, cmbHomeOrderU, cmbHomeOrderV, cmbHomeOrderW};
            _btnJogPlusName = new[] {"X+", "Y+", "Z+", "U+", "V+", "W+"};
            _btnJogMinusName = new[] {"X-", "Y-", "Z-", "U-", "V-", "W-"};

            _radStepDistance = new[] {radLong, radMedium, radShort};
            _radStepDistance.ToList().ForEach(p => p.CheckedChanged += RadStepDistance_CheckedChanged);

            LoadAxises();
            _oldAxisesNum = _ele.Axises.Count;
        }

        public void UpdateConfig()
        {
            if (InvokeRequired)
            {
                var update = new Del_GuiRefresh(UpdateConfig);
                BeginInvoke(update);
            }
            else
            {
                LoadAxises();
                _oldAxisesNum = _ele.Axises.Count;
            }
        }

        private void RadStepDistance_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb == null) return;
            var i = Array.IndexOf(_radStepDistance, rb);
            if (i < 0) return;
            foreach (var t in _cmbStep)
            {
                if (i == 0)
                {
                    t.SelectedItem = 10;
                }
                else if (i == 1)
                {
                    t.SelectedItem = 1;
                }
                else if (i == 2)
                {
                    t.SelectedItem = 0.1;
                }
            }
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                if (btn != null)
                {
                    var i = Array.IndexOf(_btnHome, btn);
                    if (i >= 0 && _axisIndex[i] != -1)
                    {
                        if (MessageBox.Show(string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_AxisStartHoming", "{0} Start homing?"), _ele.Axises[_axisIndex[i]].Name), NLocalizer.GetString("EleCartesian_ConfigUI_Homing", "Homing"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }

                        var ret = _ele.SingleHome((_axisIndex[i]));
                        MessageBox.Show(ret == 0
                            ? string.Format(
                                NLocalizer.GetString("EleCartesian_ConfigUI_SpecificAxisHomingSucceeded",
                                    "{0} {1} homing succeeded."), _ele.Axises[_axisIndex[i]].Name, i)
                            : string.Format(
                                NLocalizer.GetString("EleCartesian_ConfigUI_SpecificAxisHomingFailure",
                                    "{0} {1} homing failure."), _ele.Axises[_axisIndex[i]].Name, i));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_MoveError", "Move Error:{0}"), ex.Message));
            }
        }

        private void BtnServo_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                var i = Array.IndexOf(_btnServo, btn);
                if (i >= 0 && _axisIndex[i] != -1)
                {
                    var ret = _ele.SingleSetEnable(_axisIndex[i], !_ele.Axises[_axisIndex[i]].Enable);
                    MessageBox.Show(ret != 0
                        ? string.Format(
                            NLocalizer.GetString("EleCartesian_ConfigUI_SpecificAxisEnableSucceeded",
                                "{0} enable succeeded."), _ele.Axises[_axisIndex[i]].Name)
                        : string.Format(
                            NLocalizer.GetString("EleCartesian_ConfigUI_SpecificAxisEnableFailure",
                                "{0} enable failure."), _ele.Axises[_axisIndex[i]].Name));
                }
            }
        }

        private void BtnJog_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            _ele.IsPause = false;
            try
            {
                if (btn == null) return;
                btn.Enabled = false;
                Cursor = Cursors.WaitCursor;
                if (btn.Text.Contains("+"))
                {
                    var i = Array.IndexOf(_btnJogPlus, btn);
                    if (i < 0 || _axisIndex[i] == -1) return;
                    var step = double.Parse(_cmbStep[i].Text);

                    if (step > 10 || _ele.Axises[_axisIndex[i]].InMel || _ele.Axises[_axisIndex[i]].InPel)
                    {
                        if (MessageBox.Show(string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_MoveWarning", "{0} start move {1} mm  Positive limit {2} Negative limit {3}?"), _ele.Axises[_axisIndex[i]].Name, step, _ele.Axises[_axisIndex[i]].InPel, _ele.Axises[_axisIndex[i]].InMel),
                                NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    var ret = _ele.SingleMoveRel(_axisIndex[i], step, _ele.Axises[_axisIndex[i]].JogVel, false);
                    if (ret != 0)
                    {
                        MessageBox.Show(string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_MoveException", "{0} move exception!"), _ele.Axises[_axisIndex[i]].Name));
                    }
                }
                else if (btn.Text.Contains("-"))
                {
                    var i = Array.IndexOf(_btnJogMinus, btn);
                    if (i < 0 || _axisIndex[i] == -1) return;
                    var step = double.Parse(_cmbStep[i].Text);

                    if (step > 10 || _ele.Axises[_axisIndex[i]].InMel || _ele.Axises[_axisIndex[i]].InPel)
                    {
                        if (MessageBox.Show(string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_MoveWarning", "{0} start move {1} mm  Positive limit {2} Negative limit {3}?"), _ele.Axises[_axisIndex[i]].Name, step, _ele.Axises[_axisIndex[i]].InPel, _ele.Axises[_axisIndex[i]].InMel),
                                NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    var ret = _ele.SingleMoveRel(_axisIndex[i], step, _ele.Axises[_axisIndex[i]].JogVel, false);
                    if (ret != 0)
                    {
                        MessageBox.Show(string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_MoveException", "{0} move exception!"), _ele.Axises[_axisIndex[i]].Name));
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_MoveError", "Move Error:{0}"), ex.Message));
            }
            finally
            {
                Cursor = Cursors.Default;
                if (btn != null)
                {
                    btn.Enabled = true;
                }
            }
        }

        private void LoadAxises()
        {
            if (_ele.Axises.Count <= 0)
            {
                return;
            }

            try
            {
                var axisX = _ele.Axises.First(p => p.Value.Name.ToLower().Contains("_x"));
                _axis[0] = axisX.Value;
                _axisIndex[0] = axisX.Key;
            }
            catch (Exception e)
            {
                _axis[0] = null;
                _axisIndex[0] = -1;
            }

            try
            {
                var axisY = _ele.Axises.First(p => p.Value.Name.ToLower().Contains("_y"));
                _axis[1] = axisY.Value;
                _axisIndex[1] = axisY.Key;
            }
            catch (Exception e)
            {
                _axis[1] = null;
                _axisIndex[1] = -1;
            }

            try
            {
                var axisZ = _ele.Axises.First(p => p.Value.Name.ToLower().Contains("_z"));
                _axis[2] = axisZ.Value;
                _axisIndex[2] = axisZ.Key;
            }
            catch (Exception e)
            {
                _axis[2] = null;
                _axisIndex[2] = -1;
            }

            try
            {
                var axisU = _ele.Axises.First(p => p.Value.Name.ToLower().Contains("_u"));
                _axis[3] = axisU.Value;
                _axisIndex[3] = axisU.Key;
            }
            catch (Exception e)
            {
                _axis[3] = null;
                _axisIndex[3] = -1;
            }

            try
            {
                var axisV = _ele.Axises.First(p => p.Value.Name.ToLower().Contains("_v"));
                _axis[4] = axisV.Value;
                _axisIndex[4] = axisV.Key;
            }
            catch (Exception e)
            {
                _axis[4] = null;
                _axisIndex[4] = -1;
            }

            try
            {
                var axisW = _ele.Axises.First(p => p.Value.Name.ToLower().Contains("_w"));
                _axis[5] = axisW.Value;
                _axisIndex[5] = axisW.Key;
            }
            catch (Exception e)
            {
                _axis[5] = null;
                _axisIndex[5] = -1;
            }

        }

        private void InitializeUI()
        {
            lbName.Text = NLocalizer.GetString("EleCartesian_ConfigUI_Name", "Name");
            lbInfo.Text = NLocalizer.GetString("EleCartesian_ConfigUI_Info", "Info");
            lbType.Text = NLocalizer.GetString("EleCartesian_ConfigUI_Type", "Type");
            lbState.Text = NLocalizer.GetString("EleCartesian_ConfigUI_State", "State");
            lbDevName.Text = NLocalizer.GetString("EleCartesian_ConfigUI_DevName", "DevName");
            lbVelMode.Text = NLocalizer.GetString("EleCartesian_ConfigUI_VelocityMode", "VelMode");
            lbFeedBackType.Text = NLocalizer.GetString("EleCartesian_ConfigUI_AxisNum", "AxisNum");

            tabPageAxisConfig.Text = NLocalizer.GetString("EleCartesian_ConfigUI_AxisConfig", "AxisConfig");
            tabPageAxisStatus.Text = NLocalizer.GetString("EleCartesian_ConfigUI_AxisStatus", "AxisStatus");
            tabPageInterpolation.Text = NLocalizer.GetString("EleCartesian_ConfigUI_Interpolation", "Interpolation");
        }
        private void ConfigUI_Load(object sender, EventArgs e)
        {
            if (_ele != null && !string.IsNullOrEmpty(_ele.Name))
            {
                UiInit();
            }

            if (_ele == null || string.IsNullOrEmpty(_ele.DevName))
            {
                return;
            }

            if (_ele?.EleRunStat == EleRunState.Other)
            {
                _ele.IEleInit();
            }

            LoadManualPanel();
            LoadTeachPanel();
            LoadPositionPanel();

            tmrRefresh.Interval = 100;
            tmrRefresh.Start();
        }
        private void LoadManualPanel()
        {
            for (var i = 0; i < _cmbStep.Length; i++)
            {
                var cb = _cmbStep[i];
                cb.Items.Clear();
                cb.Items.AddRange(new object[] { 0.02, 0.1, 0.5, 1, 5, 10, 20, 30, 40, 50, 100, 150 });
                cb.SelectedItem = 10;

                _btnJogPlus[i].BackColor = Color.White;
                _btnJogMinus[i].BackColor = Color.White;
            }
            radLong.Checked = true;

            //load home order
            for (var i = 0; i < _cmbHomeOrder.Length; i++)
            {
                var cb = _cmbHomeOrder[i];
                cb.Items.Clear();
                cb.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5 });

                _btnHome[i].BackColor = Color.White;
                _btnServo[i].BackColor = Color.White;
            }
        }

        private void LoadTeachPanel(string lastpos = null)
        {
            var pos = _ele.Points.GroupPoints.Select(p => $"{p.Value.Name}").ToArray();

            //teach pos
            cmbPointTeach.Items.Clear();
            cmbPointTeach.Items.AddRange(pos);
            cmbPointTeach.SelectedItem = lastpos;

            //test pos
            cmbPointMove.Items.Clear();
            cmbPointMove.Items.AddRange(pos);
            cmbPointMove.SelectedItem = lastpos;

            //test jump height
            cmbJumpHeightZ.Items.Clear();
            cmbJumpHeightZ.Items.AddRange(new object[] { 0, -5, -10, -20, -30, -50 });
            cmbJumpHeightZ.SelectedItem = -10;
        }
        private void LoadPositionPanel()
        {
            dgPoints.AllowUserToOrderColumns = false;
            dgPoints.Rows.Clear();
            dgPoints.Columns.Clear();

            var colIndex = dgPoints.Columns.Add("Index", "Index");
            dgPoints.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;

            var colName = dgPoints.Columns.Add("Name", "Name");
            dgPoints.Columns[colName].SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (var p in _axisName)
            {
                var col = dgPoints.Columns.Add(p, p);
                dgPoints.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            var colRatio = dgPoints.Columns.Add("SPeedRatio", "SPeedRatio");
            dgPoints.Columns[colRatio].SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (var p in _ele.Points.MotionPoints)
            {
                var r = dgPoints.Rows.Add(1);

                dgPoints.Rows[r].Cells[colIndex].Value = p.Index;
                dgPoints.Rows[r].Cells[colName].Value = p.Name;

                dgPoints.Rows[r].Cells[colName + 1].Value = p.X.ToString("F3");
                dgPoints.Rows[r].Cells[colName + 2].Value = p.Y.ToString("F3");
                dgPoints.Rows[r].Cells[colName + 3].Value = p.Z.ToString("F3");
                dgPoints.Rows[r].Cells[colName + 4].Value = p.U.ToString("F3");
                dgPoints.Rows[r].Cells[colName + 5].Value = p.V.ToString("F3");
                dgPoints.Rows[r].Cells[colName + 6].Value = p.W.ToString("F3");

                dgPoints.Rows[r].Cells[colRatio].Value = p.SpeedRatio;
            }
        }
        private void UiInit()
        {
            if (InvokeRequired)
            {
                var update = new Del_GuiRefresh(UiInit);
                Invoke(update, null);
            }
            else
            {
                if (_ele == null)
                {
                    return;
                }

                tbName.Text = _ele.Name;
                tbInfo.Text = _ele.Info;
                tbType.Text = _ele.EleTypeName;
                lbDevName_Click(null, null);
                cBoxDevName.SelectedItem = _ele.DevName;
                cBoxVelMode.SelectedItem = _ele.VelMode.ToString();
                cBoxAxisNum.SelectedItem = _ele.AxisNum.ToString();
                tbAxisesConfigPath.Text = _ele.AxisesConfigPath;
                cBoxEnable.Checked = _ele.Enable;
                cBoxSimulate.Checked = _ele.IsSimulateMode;
                cBoxLogEnable.Checked = _ele.LogEnable;
                cBoxLogDisplay.Checked = _ele.LogDisplay;
                AddSingleAxis();
            }
        }

        private void lbDevName_Click(object sender, EventArgs e)
        {
            if (PrimsManager.Instance.ListPrim.Count < 1) { return; }

            cBoxDevName.SelectedIndex = -1;
            cBoxDevName.Items.Clear();

            var prims = PrimsManager.Instance.ListPrim.FindAll(p => p.PrimTypeName.Contains("ADLink") || p.PrimTypeName.Contains("LEIS"));
            var all = prims.All(p => cBoxDevName.Items.Add(p.Name) != -1);
        }

        private void cBoxAxisNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_firstLoadAxisNum)
            {
                _firstLoadAxisNum = true;
                return;
            }
            var num = int.Parse(cBoxAxisNum.SelectedItem.ToString());
            if (num == _oldAxisesNum) return;
            _axisConfigControls.Clear();
            _axisStatusControls.Clear();

            AddNewSingleAxis(num);
        }

        private void AddNewSingleAxis(int num)
        {
            var count = num;
            flowPanelConfig.Controls.Clear();
            flowPanelStatus.Controls.Clear();

            if (_ele.Axises == null)
            {
                _ele.Axises = new ConcurrentDictionary<int, SingleAxis>();
            }

            _ele.Axises.Clear();

            for (var i = 0; i < count; i++)
            {
                var axis = new SingleAxis($"Axis{i}", i);
                _ele.Axises.TryAdd(i, axis);

                var axisControl = new SingleAxisConfigControl(i, axis, _ele)
                {
                    Dock = DockStyle.Top
                };
                axisControl.Event_UpdateAxisName -= UpdateAxisName;
                axisControl.Event_UpdateAxisName += UpdateAxisName;

                _axisConfigControls.TryAdd(i, axisControl);
                flowPanelConfig.Controls.Add(axisControl);

                var axisStatus = new SingleAxisStatusControl(i, axis, _ele)
                {
                    Dock = DockStyle.Top
                };
                axisStatus.Event_AddSingleAxisPos -= AxisStatusOnEventAddSingleAxisPos;
                axisStatus.Event_AddSingleAxisPos += AxisStatusOnEventAddSingleAxisPos;
                _axisStatusControls.TryAdd(i, axisStatus);
                flowPanelStatus.Controls.Add(axisStatus);
            }

        }

        private void AxisStatusOnEventAddSingleAxisPos(int axisIndex)
        {
            if (_pointsForm == null)
            {
                BtnOpenPoints_Click(null, null);
            }

            _pointsForm?.AddSingleAxisPos(axisIndex);
        }

        private void AddSingleAxis()
        {
            if (_ele?.Axises == null || _ele.Axises.Count <= 0)
            {
                return;
            }

            flowPanelConfig.Controls.Clear();
            flowPanelStatus.Controls.Clear();

            foreach (var axis in _ele.Axises)
            {
                var axisControl = new SingleAxisConfigControl(axis.Key, axis.Value, _ele)
                {
                    Dock = DockStyle.Top
                };
                axisControl.Event_UpdateAxisName -= UpdateAxisName;
                axisControl.Event_UpdateAxisName += UpdateAxisName;

                _axisConfigControls.TryAdd(axis.Key, axisControl);
                flowPanelConfig.Controls.Add(axisControl);

                var axisStatus = new SingleAxisStatusControl(axis.Key, axis.Value, _ele)
                {
                    Dock = DockStyle.Top
                };

                axisStatus.Event_AddSingleAxisPos -= AxisStatusOnEventAddSingleAxisPos;
                axisStatus.Event_AddSingleAxisPos += AxisStatusOnEventAddSingleAxisPos;

                _axisStatusControls.TryAdd(axis.Key, axisStatus);
                flowPanelStatus.Controls.Add(axisStatus);
            }
        }

        private void UpdateAxisName(int id, string newAxisName)
        {
            if (_axisStatusControls.ContainsKey(id))
            {
                _axisStatusControls[id].UpdateAxisName(newAxisName);
            }
        }
        #region Public method
        public void SetEleRunState(EleRunState state)
        {
            if (tbState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                UpdateEleRunState update = SetEleRunState;
                BeginInvoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case EleRunState.Idle:
                        tbState.BackColor = Color.Khaki;
                        tbState.Text = @"Idle";
                        break;
                    case EleRunState.Running:
                        tbState.BackColor = Color.LightGreen;
                        tbState.Text = @"Running";
                        break;
                    case EleRunState.Err:
                        tbState.BackColor = Color.SandyBrown;
                        tbState.Text = @"Err";
                        break;
                    case EleRunState.Other:
                        tbState.BackColor = Color.Khaki;
                        tbState.Text = @"Other";
                        break;
                }
            }
        }

        public void SetSimulateMode(bool simulate)
        {
            if (tbState.InvokeRequired)
            {
                UpdateEleSimulateMode update = SetSimulateMode;
                BeginInvoke(update, simulate);
            }
            else
            {
                cBoxSimulate.Checked = simulate;
            }
        }
        #endregion

        private void btnConfigApply_Click(object sender, EventArgs e)
        {
            if (_ele.EleRunStat == EleRunState.Running)
            {
                MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_CannotModifyParameters", "The current element is running. No parameter modification is allowed. Please switch to non-running state."));
                return;
            }
            _ele.Name = tbName.Text;
            _ele.Info = tbInfo.Text;
            _ele.DevName = cBoxDevName.SelectedIndex != -1 ? cBoxDevName.SelectedItem.ToString() : "";
            switch (cBoxVelMode.SelectedItem.ToString())
            {
                case "Velocity":
                    _ele.VelMode = AccDecType.Velocity;
                    break;
                case "Time":
                    _ele.VelMode = AccDecType.Time;
                    break;
                default:
                    _ele.VelMode = AccDecType.Other;
                    break;
            }

            if (int.TryParse(cBoxAxisNum.SelectedItem.ToString(), out var axisNum))
            {
                _ele.AxisNum = axisNum;
            }
            else
            {
                MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_NotSettingAxisNumber", "Axis number is not set"));
                return;
            }

            _ele.Axises.Clear();
            for (var i = 0; i < _axisConfigControls.Count; i++)
            {
                _axisConfigControls[i].ConfigsSave();
            }
        }

        private void ConfigUI_Click(object sender, EventArgs e)
        {
            if (_ele.IsSelected)
            {
                return;
            }

            _ele.EleCartesianSelected();
        }

        private void BtnOpenPoints_Click(object sender, EventArgs e)
        {
            if (_ele == null || _pointsForm == null || _pointsForm.IsDisposed)
            {
                _pointsForm = new AxisesPointsConfig(_ele);
                _pointsForm.Show();
            }
            else
            {
                _pointsForm.TopMost = true;
                _pointsForm.Visible = true;
                _pointsForm.Activate();
                if (_pointsForm.WindowState == FormWindowState.Minimized)
                {
                    _pointsForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void CBoxDevName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxDevName.Items.Count <= 0)
            {
                lbDevName_Click(null, null);
            }
        }

        private void BtnAxisesBrowse_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            tbAxisesConfigPath.Text = openFileDialog.FileName;

            if (string.IsNullOrEmpty(tbAxisesConfigPath.Text))
            {
                return;
            }

            if (!File.Exists(tbAxisesConfigPath.Text))
            {
                MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_SelectedFileNotExist", "The selected file does not exist!"));
                return;
            }

            if (_ele?.AxisesConfigPath != null)
            {
                _ele.AxisesConfigPath = tbAxisesConfigPath.Text;
            }
        }

        private void BtnAxisesLoad_Click(object sender, EventArgs e)
        {
            if (_ele == null)
            {
                return;
            }

            if (_ele.ImportAxisesConfigFromPath() != 0)
            {
            }
        }

        private void BtnAxisesSaveAs_Click(object sender, EventArgs e)
        {
            if (_ele == null || saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _ele.ExportAxisesConfigToPath(saveFileDialog.FileName);
        }

        private void BtnAllStop_Click(object sender, EventArgs e)
        {
            _ele.GroupStop();
        }

        private void BtnServoOnAll_Click(object sender, EventArgs e)
        {
            _ele.GroupSetEnable(true);
        }

        private void BtnServoOffAll_Click(object sender, EventArgs e)
        {
            _ele.GroupSetEnable(false);
        }

        private void BtnHomeAll_Click(object sender, EventArgs e)
        {
            //各轴相对移动至安全位，待添加

            _ele.GroupHome();
        }

        private void BtnPosTeach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPointTeach.Text))
            {
                MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_TeachingPointNameAbnormal", "Teaching point name is abnormal"));
                return;
            }

            if (_ele.Points.GroupPoints.ToList().Exists(p => p.Value.Name == cmbPointTeach.Text))
            {
                var lastPos = _ele.Points.GroupPoints.ToList().First(p => p.Value.Name == cmbPointTeach.Text);

                if (MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_UpdatePoint", "Update point") + $@" { lastPos.Key} {lastPos.Value.Name} : {string.Join(",", lastPos.Value.Pos.Select(v => v.ToString("F3")))} to {string.Join(",", _curPos.Select(v => v.ToString("F3")))}?",
                        NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_TeachingPointMessage", "Teaching point") + $" { _ele.Points.GroupPoints.Count} {cmbPointTeach.Text} : {string.Join(",", _curPos.Select(v => v.ToString("F3")))}?",
                        NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            TeachPos(cmbPointTeach.Text);
            LoadTeachPanel(cmbPointTeach.Text);
            LoadPositionPanel();
            _ele.ExportPointsToPath(_ele.PointsPath);
        }

        private void TeachPos(string name)
        {
            if (_ele.Points.GroupPoints.ToList().Exists(p => p.Value.Name == name))
            {
                var oldPos = _ele.Points.GroupPoints.FirstOrDefault(p => p.Value.Name == name);
                for (var i = 0; i < oldPos.Value.Pos.Length; i++)
                {
                    oldPos.Value.Pos[i] = _ele.Axises[i].ActualPos;
                }

                _ele.Points.GroupPoints.TryUpdate(oldPos.Key,oldPos.Value,oldPos.Value);
                _ele.GroupToMotion();
            }
            else
            {
                var newPos = new PosCartesian
                {
                    Index = _ele.Points.GroupPoints.Count, Name = name, SpeedRatio = 50,
                    Pos = new double[_ele.Axises.Count]
                };
                for (var i = 0; i < newPos.Pos.Length; i++)
                {
                    newPos.Pos[i] = _ele.Axises[i].ActualPos;
                }

                _ele.Points.GroupPoints.TryAdd(newPos.Index, newPos);
                _ele.GroupToMotion();
            }

        }

        private void BtnPosDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPointTeach.Text))
            {
                MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_TeachingPointNameAbnormal", "Teaching point name is abnormal"));
                return;
            }

            var delPos = _ele.Points.GroupPoints.FirstOrDefault(p => p.Value.Name == cmbPointTeach.Text);

            if (MessageBox.Show(
                    string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_DeletePoint", "Delete point {0} {1}"), delPos.Key,
                        delPos.Value.Name), NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"), MessageBoxButtons.YesNo) ==
                DialogResult.No)
            {
                return;
            }
            
            _ele.Points.GroupPoints.TryRemove(delPos.Key, out var oldPos);
            _ele.GroupToMotion();
            _ele.ExportPointsToPath(_ele.PointsPath);
            LoadPositionPanel();
            LoadTeachPanel(delPos.Value.Name);
            cmbPointTeach.Text = string.Empty;
            cmbPointMove.Text = string.Empty;
        }

        private void BtnPosMoveP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPointMove.Text))
            {
                MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_AbsoluteMotionPointNameAbnormal", "Absolute motion point name is abnormal!"));
                return;
            }

            var pos = _ele.Points.GroupPoints.FirstOrDefault(p => p.Value.Name == cmbPointMove.Text);
            if (!pos.Equals(default(KeyValuePair<int, PosCartesian>)))
            {
                var moveForm = new MoveForm
                {
                    ObjPos = pos.Value,
                    MoveMode = "MoveP",
                    JumpHeight = 0,
                    Ele = _ele,
                    StartPosition = FormStartPosition.CenterParent,
                };

                moveForm.ShowDialog();
            }
        }

        private void BtnPosJump_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPointMove.Text))
            {
                MessageBox.Show(NLocalizer.GetString("EleCartesian_ConfigUI_JumpExceptionPointNameAbnormal", "JUMP exception: point name is abnormal"));
                return;
            }

            var pos = _ele.Points.GroupPoints.FirstOrDefault(p => p.Value.Name == cmbPointMove.Text);
            if (!pos.Equals(default(KeyValuePair<int, PosCartesian>)))
            {
                var moveForm = new MoveForm
                {
                    ObjPos = pos.Value,
                    MoveMode = "Jump",
                    JumpHeight = double.Parse(cmbJumpHeightZ.Text),
                    Ele = _ele,
                    StartPosition = FormStartPosition.CenterParent,
                };

                moveForm.ShowDialog();
            }
        }

        public void UiRefresh()
        {
            if (InvokeRequired)
            {
                var update = new Del_GuiRefresh(UiRefresh);
                BeginInvoke(update);
            }
            else
            {
                if (_ele.EleRunStat != EleRunState.Running) return;

                for (var i = 0; i < _axisIndex.Length; i++)
                {
                    if (_axisIndex[i] != -1)
                    {
                        _curPos[i] = _ele.Axises[_axisIndex[i]].ActualPos;
                        _tbPos[i].Text = _ele.Axises[_axisIndex[i]].ActualPos.ToString("F3");
                        _tbPos[i].BackColor = _ele.Axises[_axisIndex[i]].IsStop ? Color.White : Color.Lime;
                        _tbVel[i].Text = _ele.Axises[_axisIndex[i]].ActualVel.ToString("F2");
                        _tbVel[i].BackColor = _ele.Axises[_axisIndex[i]].SignalInp ? Color.White : Color.Lime;
                        if (_ele.Axises[_axisIndex[i]].IsAlarm)
                        {
                            _btnServo[i].BackColor = Color.Red;
                            _btnJogMinus[i].BackColor = Color.Red;
                            _btnJogPlus[i].BackColor = Color.Red;
                        }
                        else
                        {
                            _btnServo[i].BackColor = _ele.Axises[_axisIndex[i]].Enable ? Color.Lime : Color.White;
                            _btnJogPlus[i].BackColor = _ele.Axises[_axisIndex[i]].Enable ? Color.White : Color.LightGray;
                            _btnJogMinus[i].BackColor = _ele.Axises[_axisIndex[i]].Enable ? Color.White : Color.LightGray;
                        }
                        _tbMel[i].BackColor = _ele.Axises[_axisIndex[i]].InMel ? Color.Red : Color.White;
                        _tbPel[i].BackColor = _ele.Axises[_axisIndex[i]].InPel ? Color.Red : Color.White;
                        _tbOrg[i].BackColor = _ele.Axises[_axisIndex[i]].InOrigin ? Color.Lime : Color.White;
                    }
                }
            }
        }

        private void TsmSave_Click(object sender, EventArgs e)
        {
            SavePositionPanel();
            LoadTeachPanel();
        }

        private void SavePositionPanel()
        {
            //var prop = typeof(PosMotion).GetProperties();
            //for (var i = 0; i < _ele.Points.MotionPoints.Count; i++)
            //{
            //    var pos = _ele.Points.MotionPoints[i];
            //    var row = dgPoints.Rows[i];
            //    for (var index = 0; index < prop.Length; index++)
            //    {
            //        prop[index].SetValue(pos, row.Cells[index].Value);
            //    }
            //}

            var listIndex = new List<int>();
            for (var i = 0; i < dgPoints.Rows.Count - 1; i++)
            {
                if (int.TryParse(dgPoints.Rows[i].Cells[0].Value?.ToString(), out var index))
                {
                    listIndex.Add(index);
                }
                else
                {
                    MessageBox.Show($@"第{i}行的点序号填写有误，请查证。");
                    return;
                }
            }

            if (IsSameWithHashSet(listIndex))
            {
                MessageBox.Show($@"表格中有重复的点位序列，请查证。");
                return;
            }

            _ele.Points.MotionPoints.Clear();
            for (var i = 0; i < dgPoints.Rows.Count - 1; i++)
            {
                var newPoint = new PosMotion
                {
                    Index = int.Parse(dgPoints.Rows[i].Cells[0].Value.ToString()),
                    Name = dgPoints.Rows[i].Cells[1].Value?.ToString(),
                    X = double.TryParse(dgPoints.Rows[i].Cells[2].Value?.ToString(), out var x) ? x : -1,
                    Y = double.TryParse(dgPoints.Rows[i].Cells[3].Value?.ToString(), out var y) ? y : -1,
                    Z = double.TryParse(dgPoints.Rows[i].Cells[4].Value?.ToString(), out var z) ? z : -1,
                    U = double.TryParse(dgPoints.Rows[i].Cells[5].Value?.ToString(), out var u) ? u : -1,
                    V = double.TryParse(dgPoints.Rows[i].Cells[6].Value?.ToString(), out var v) ? v : -1,
                    W = double.TryParse(dgPoints.Rows[i].Cells[7].Value?.ToString(), out var w) ? w : -1,
                    SpeedRatio = double.TryParse(dgPoints.Rows[i].Cells[8].Value?.ToString(), out var ratio)
                        ? ratio
                        : 100
                };

                _ele.Points.MotionPoints.Add(newPoint);
            }

            _ele.MotionToGroup();
            _ele.ExportPointsToPath(_ele.PointsPath);
        }

        static bool IsSameWithHashSet(string[] arr)
        {
            ISet<string> set = new HashSet<string>();

            for (var i = 0; i < arr.Length; i++)
            {
                // 这里可利用该元素来实现统计重复的原理有哪些，及重复个数。
                //bool state = set.Add(arr[i]); // 如果返回false，表示set中已经有该元素。
                //Console.WriteLine(state);
                set.Add(arr[i]);
            }

            return set.Count != arr.Length;
        }

        static bool IsSameWithHashSet(List<int> list)
        {
            ISet<int> set = new HashSet<int>();

            for (var i = 0; i < list.Count; i++)
            {
                // 这里可利用该元素来实现统计重复的原理有哪些，及重复个数。
                //bool state = set.Add(arr[i]); // 如果返回false，表示set中已经有该元素。
                //Console.WriteLine(state);
                set.Add(list[i]);
            }

            return set.Count != list.Count;
        }

        private void TsmReLoad_Click(object sender, EventArgs e)
        {
            _ele.ImportPointsFromPath(_ele.PointsPath);
            LoadTeachPanel();
            LoadPositionPanel();
        }

        private void TsmUpdate_Click(object sender, EventArgs e)
        {

        }

        private void TsmToPoint_Click(object sender, EventArgs e)
        {

        }
    }
}
