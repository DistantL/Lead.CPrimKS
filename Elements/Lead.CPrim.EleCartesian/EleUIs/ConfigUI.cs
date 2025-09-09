using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.EleAxisByCard;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.EleCartesian.EleUIs
{
    public partial class ConfigUI : UserControl
    {
        #region Field
        /// <summary>轴组管理器</summary>
        private readonly EleCartesian _ele;
        /// <summary>点位管理UI</summary>
        private AxisesPointsConfig _pointsForm;
        /// <summary>轴组配置UI集合</summary>
        private readonly ConcurrentDictionary<int, Control> _axisConfigControls = new ConcurrentDictionary<int, Control>();
        /// <summary>轴组状态UI集合</summary>
        private readonly ConcurrentDictionary<int, Control> _axisStatusControls = new ConcurrentDictionary<int, Control>();

        //正负移动
        /// <summary>负向移动Button</summary>
        private readonly Button[] _btnJogMinus;
        /// <summary>正向移动Button</summary>
        private readonly Button[] _btnJogPlus;

        //移动距离
        /// <summary>移动距离（长中短）</summary>
        private readonly RadioButton[] _radStepDistance;
        /// <summary>移动距离（XYZUVW距离）</summary>
        private readonly ComboBox[] _cmbStep;

        //极限&原点信号
        /// <summary>正极限信号数组</summary>
        private readonly TextBox[] _tbPel;
        /// <summary>负极限信号数组</summary>
        private readonly TextBox[] _tbMel;
        /// <summary>原点信号数组</summary>
        private readonly TextBox[] _tbOrg;

        //实时位置&实时速度
        /// <summary>实时位置</summary>
        private readonly TextBox[] _tbPos;
        /// <summary>实时速度</summary>
        private readonly TextBox[] _tbVel;


        //回零
        /// <summary>回零（XYZUVW使能）</summary>
        private readonly Button[] _btnServo;
        /// <summary>回零（XYZUVW回零顺序）</summary>
        private readonly ComboBox[] _cmbHomeOrder;
        /// <summary>回零（XYZUVW回零按钮）</summary>
        private readonly Button[] _btnHome;
        /// <summary>XYZUVW（点位列表用于增加列）</summary>
        private readonly string[] _axisName;


        private readonly double[] _curPos;
        private string[] _btnJogMinusName;
        private string[] _btnJogPlusName;
        private int _oldAxisesNum;
        #endregion


        #region Ctor
        /// <summary>Ctor无参</summary>
        public ConfigUI()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="ele">轴组管理器</param>
        public ConfigUI(EleCartesian ele)
        {
            InitializeComponent();
            _ele = ele;

            //移动距离
            _radStepDistance = new[] { radLong, radMedium, radShort };
            _radStepDistance.ToList().ForEach(p => p.CheckedChanged += RadStepDistance_CheckedChanged);
            _cmbStep = new[] { cmbStepX, cmbStepY, cmbStepZ, cmbStepU, cmbStepV, cmbStepW };

            //回零
            _btnServo = new[] { btnServoX, btnServoY, btnServoZ, btnServoU, btnServoV, btnServoW };
            _btnServo.ToList().ForEach(p => p.Click += BtnServo_Click);
            _cmbHomeOrder = new[] { cmbHomeOrderX, cmbHomeOrderY, cmbHomeOrderZ, cmbHomeOrderU, cmbHomeOrderV, cmbHomeOrderW };
            _btnHome = new[] { btnHomeX, btnHomeY, btnHomeZ, btnHomeU, btnHomeV, btnHomeW };
            _btnHome.ToList().ForEach(p => p.Click += BtnHome_Click);

            //正向移动/负向移动
            _btnJogPlus = new[] { btnPlusX, btnPlusY, btnPlusZ, btnPlusU, btnPlusV, btnPlusW };
            _btnJogMinus = new[] { btnMinusX, btnMinusY, btnMinusZ, btnMinusU, btnMinusV, btnMinusW };
            _btnJogPlus.ToList().ForEach(p => p.Click += BtnJog_Click);
            _btnJogMinus.ToList().ForEach(p => p.Click += BtnJog_Click);

            //点位列表
            _axisName = new[] { "X", "Y", "Z", "U", "V", "W" };

            //实时位置&实时速度
            _tbPos = new[] { tbPosX, tbPosY, tbPosZ, tbPosU, tbPosV, tbPosW };
            _tbVel = new[] { tbVelX, tbVelY, tbVelZ, tbVelU, tbVelV, tbVelW };

            //正负极限&原点信号
            _tbPel = new[] { tbPelX, tbPelY, tbPelZ, tbPelU, tbPelV, tbPelW };
            _tbMel = new[] { tbMelX, tbMelY, tbMelZ, tbMelU, tbMelV, tbMelW };
            _tbOrg = new[] { tbOrgX, tbOrgY, tbOrgZ, tbOrgU, tbOrgV, tbOrgW };

            _btnJogPlusName = new[] { "X+", "Y+", "Z+", "U+", "V+", "W+" };
            _btnJogMinusName = new[] { "X-", "Y-", "Z-", "U-", "V-", "W-" };
            _curPos = new double[6];

            _oldAxisesNum = _ele.Axises.Count;
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion


        #region System_Event
        /// <summary>Load事件</summary>
        private void ConfigUI_Load(object sender, EventArgs e)
        {
            if (_ele == null || string.IsNullOrEmpty(_ele.Name))
            {
                return;
            }

            UiInit();

            LoadAxises();

            if (_ele?.EleRunStat == EleRunState.Other) _ele.IEleInit();

            LoadManualPanel();

            LoadTeachPanel();

            LoadPositionPanel();

            OnLanguageChanged();
        }
        #endregion


        #region Button_Event
        /// <summary>增加轴</summary>
        private void btnAddAxis_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            AddNewSingleAxis();
        }
        /// <summary>移除轴</summary>
        private void btnRemoveAxis_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            RemoveAxises();
        }
        /// <summary>手动调试_移动_停止</summary>
        private void BtnAllStop_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }
            _ele.GroupStop();
        }
        /// <summary>手动调试_回零_所有轴上使能</summary>
        private void BtnServoOnAll_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (MessageBox.Show($@"请确认将{_ele.Name}的所有轴上使能？", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    var ret = _ele.GroupSetEnable(true) == 0;
                    MessageBox.Show($"{_ele.Name}所有轴上使能" + (ret ? "成功！" : "失败！"));
                }
                catch
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show($"{_ele.Name}所有轴上使能失败！");
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        /// <summary>手动调试_回零_所有轴下使能</summary>
        private void BtnServoOffAll_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (MessageBox.Show($@"请确认将{_ele.Name}的所有轴下使能？", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    var ret = _ele.GroupSetEnable(false) == 0;
                    MessageBox.Show($@"{_ele.Name}所有轴下使能" + (ret ? "成功！" : "失败！"));
                }
                catch
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show($@"{_ele.Name}所有轴下使能失败！");
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        /// <summary>手动调试_回零_轴组回零</summary>
        private void BtnHomeAll_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (MessageBox.Show($@"请确认将{_ele.Name}的所有轴进行回原点运动？", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    var ret = _ele.GroupHome() == 0;
                    MessageBox.Show($@"{_ele.Name}所有轴回原点" + (ret ? "成功！" : "失败！"));
                }
                catch
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show($@"{_ele.Name}所有轴回原点失败！");
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        /// <summary>示教</summary>
        private void BtnPosTeach_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (string.IsNullOrEmpty(cmbPointTeach.Text))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_TeachingPointNameAbnormal", "Teaching point name is abnormal"));
                return;
            }

            if (_ele.Points.GroupPoints.ToList().Exists(p => p.Value.Name == cmbPointTeach.Text))
            {
                var lastPos = _ele.Points.GroupPoints.ToList().First(p => p.Value.Name == cmbPointTeach.Text);

                if (MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_UpdatePoint", "Update point") + $@" {lastPos.Key} {lastPos.Value.Name} : {string.Join(",", lastPos.Value.Pos.Select(v => v.ToString("F3")))} to {string.Join(",", _curPos.Select(v => v.ToString("F3")))}?", ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"), MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            else
            {
                if (MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_TeachingPointMessage", "Teaching point") + $" {_ele.Points.GroupPoints.Count} {cmbPointTeach.Text} : {string.Join(",", _curPos.Select(v => v.ToString("F3")))}?", ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"), MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            TeachPos(cmbPointTeach.Text);

            LoadTeachPanel(cmbPointTeach.Text);

            LoadPositionPanel();

            _ele.ExportPointsToPath(_ele.PointsPath);
        }
        /// <summary>删除</summary>
        private void BtnPosDelete_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (string.IsNullOrEmpty(cmbPointTeach.Text))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_TeachingPointNameAbnormal",
                    "Teaching point name is abnormal"));
                return;
            }

            var delPos = _ele.Points.GroupPoints.FirstOrDefault(p => p.Value.Name == cmbPointTeach.Text);

            if (MessageBox.Show(
                    string.Format(ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_DeletePoint", "Delete point {0} {1}"),
                        delPos.Key,
                        delPos.Value.Name), ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"),
                    MessageBoxButtons.YesNo) ==
                DialogResult.No)
                return;

            _ele.Points.GroupPoints.TryRemove(delPos.Key, out var oldPos);
            _ele.GroupToMotion();
            _ele.ExportPointsToPath(_ele.PointsPath);
            LoadPositionPanel();
            LoadTeachPanel(delPos.Value.Name);
            cmbPointTeach.Text = string.Empty;
            cmbPointMove.Text = string.Empty;
        }
        /// <summary>MoveP</summary>
        private void BtnPosMoveP_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (string.IsNullOrEmpty(cmbPointMove.Text))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_AbsoluteMotionPointNameAbnormal",
                    "Absolute motion point name is abnormal!"));
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
                    StartPosition = FormStartPosition.CenterParent
                };

                moveForm.ShowDialog();
            }
        }
        /// <summary>Jump</summary>
        private void BtnPosJump_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (string.IsNullOrEmpty(cmbPointMove.Text))
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCartesian_ConfigUI_JumpExceptionPointNameAbnormal",
                    "JUMP exception: point name is abnormal"));
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
                    StartPosition = FormStartPosition.CenterParent
                };

                moveForm.ShowDialog();
            }
        }
        /// <summary>载入</summary>
        private void BtnAxisesLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_ele.CheckManualEnable())
                {
                    return;
                }

                if (_ele == null) return;

                if (string.IsNullOrEmpty(_ele.AxisesConfigPath))
                {
                    if (!string.IsNullOrEmpty(tbAxisesConfigPath.Text))
                    {
                        _ele.AxisesConfigPath = tbAxisesConfigPath.Text;
                    }
                    else
                    {
                        var openFile = new OpenFileDialog
                        {
                            Filter = @"json File|*.json|All File|"".""",
                            RestoreDirectory = true
                        };
                        var dialogResult = openFile.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            _ele.AxisesConfigPath = openFile.FileName;
                            tbAxisesConfigPath.Text = openFile.FileName;
                            ConfigApply();
                        }
                    }
                }

                if (_ele.ImportAxisesConfigFromPath() == 0) AddAxises();
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError($"载入失败：{ex.Message}");
            }
        }
        /// <summary>点位管理</summary>
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
        /// <summary>应用</summary>
        private void BtnAxisesSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_ele.CheckManualEnable())
                {
                    return;
                }

                ConfigApply();
                if (string.IsNullOrEmpty(_ele.AxisesConfigPath))
                {
                    var saveFile = new SaveFileDialog
                    {
                        Filter = @"json File|*.json|All File|"".""",
                        RestoreDirectory = true
                    };
                    var dialogResult = saveFile.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        _ele.ExportAxisesConfigToPath(saveFile.FileName);
                        _ele.AxisesConfigPath = saveFile.FileName;
                        tbAxisesConfigPath.Text = saveFile.FileName;
                        ConfigApply();
                    }
                }
                else
                {
                    var dirPath = tbAxisesConfigPath.Text?.Substring(0, tbAxisesConfigPath.Text.LastIndexOf(@"\"));
                    if (!string.IsNullOrEmpty(tbAxisesConfigPath.Text) && dirPath != null && Directory.Exists(dirPath))
                    {
                        _ele.AxisesConfigPath = tbAxisesConfigPath.Text;
                        _ele.ExportAxisesConfigToPath(_ele.AxisesConfigPath);
                    }
                    else
                    {
                        MessageBox.Show($@"轴组信息保存路径有误，请重新输入", "警告", MessageBoxButtons.OK);
                        return;
                    }
                }

                _ele.RefreshAxisesInDebugUi();

                if (_pointsForm != null)
                {
                    _pointsForm.RefreshAxises();
                }
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError("应用失败：" + ex.Message);
            }
        }


        /// <summary>右键保存</summary>
        private void TsmSave_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }
            SavePositionPanel();
            LoadTeachPanel();
        }
        /// <summary>右键重新载入</summary>
        private void TsmReLoad_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }
            _ele.ImportPointsFromPath(_ele.PointsPath);
            LoadTeachPanel();
            LoadPositionPanel();
        }
        /// <summary>右键更新</summary>
        private void TsmUpdate_Click(object sender, EventArgs e)
        {
        }
        /// <summary>右键移动至</summary>
        private void TsmToPoint_Click(object sender, EventArgs e)
        {
        }
        #endregion


        #region Others
        /// <summary>名称双击</summary>
        private void ConfigUI_Click(object sender, EventArgs e)
        {
            _ele.IsSelected = !_ele.IsSelected;
        }
        /// <summary>增加轴</summary>
        private void AddNewSingleAxis()
        {
            if (cBoxVelMode.SelectedItem == null)
            {
                ProxyTools.Notification.ShowWarn("请选择速度模式后进行添加！！！");
                return;
            }

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

            if (_ele.Axises == null)
            {
                _ele.Axises = new ConcurrentDictionary<int, IEleAxis>();
            }

            var axisCount = _ele.Axises.Count;
            var axis = new EleAxisByCard.EleAxisByCard($"Axis{axisCount}", axisCount, _ele.VelMode);

            axis.OnAxisByTypeUpdated += AxisOnOnAxisByTypeUpdated;
            axis.ConfigUi.Dock = DockStyle.Top;
            _axisConfigControls.TryAdd(axisCount, axis.ConfigUi);
            flowPanelConfig.Controls.Add(axis.ConfigUi);

            axis.StatusUi.Dock = DockStyle.Top;
            _axisStatusControls.TryAdd(axisCount, axis.StatusUi);
            flowPanelStatus.Controls.Add(axis.StatusUi);

            _ele.AddAxisToDebugUi(axis, axisCount);

            if (_pointsForm != null)
            {
                _pointsForm.AddAxis(axis, axisCount);
            }

            _ele.Axises.TryAdd(axisCount, axis);

            tbAxisNum.Text = _ele.Axises.Count.ToString();

            axis.ManualEnable = true;
        }
        /// <summary>移除轴</summary>
        private void RemoveAxises()
        {
            if (_ele.Axises == null || _ele.Axises.Count <= 0) return;

            foreach (var axis in _ele.Axises)
                if (axis.Value.IsSelected)
                {
                    _axisConfigControls.TryRemove(axis.Key, out var removedConfigUi);
                    flowPanelConfig.Controls.Remove(axis.Value.ConfigUi);
                    _axisStatusControls.TryRemove(axis.Key, out var removedStatusUi);
                    flowPanelStatus.Controls.Remove(axis.Value.StatusUi);

                    _ele.RemoveAxisToDebugUi(axis.Value, axis.Key);

                    if (_pointsForm != null)
                    {
                        _pointsForm.RemoveAxis(axis.Value, axis.Key);
                    }

                    _ele.Axises.TryRemove(axis.Key, out var removedAxis);
                }

            tbAxisNum.Text = _ele.Axises.Count.ToString();
        }
        /// <summary>轴组状态刷新</summary>
        private void lbState_DoubleClick(object sender, EventArgs e)
        {
            if (_ele.EleRunStat == EleRunState.Other) _ele.IEleInit();
            if (_ele.EleRunStat == EleRunState.Err) _ele.IEleReset();
        }
        /// <summary>手动状态设置</summary>
        /// <param name="value">值</param>
        internal void SetManualEnable(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetManualEnable), value);
            }
            else
            {
                _btnJogMinus.ToList().ForEach(p => p.Enabled = value);
                _btnJogPlus.ToList().ForEach(p => p.Enabled = value);
                btnAllStop.Enabled = value;

                _btnServo.ToList().ForEach(p => p.Enabled = value);
                _cmbHomeOrder.ToList().ForEach(p => p.Enabled = value);
                _btnHome.ToList().ForEach(p => p.Enabled = value);
                btnServoOnAll.Enabled = value;
                btnServoOffAll.Enabled = value;
                btnHomeAll.Enabled = value;
                btnHomeStop.Enabled = value;

                btnAddAxis.Enabled = value;
                btnRemoveAxis.Enabled = value;

                btnAxisesLoad.Enabled = value;
                btnAxisesSave.Enabled = value;
                btnConfigApply.Enabled = value;

                btnPosTeach.Enabled = value;
                btnPosDelete.Enabled = value;
                btnPosMoveP.Enabled = value;
                btnPosJump.Enabled = value;

                if (value)
                {
                    LoadAxises();
                }
            }
        }
        /// <summary>移动距离（长中短）点击事件</summary>
        private void RadStepDistance_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;

            if (rb == null)
            {
                return;
            }

            var i = Array.IndexOf(_radStepDistance, rb);
            if (i < 0)
            {
                return;
            }

            foreach (var t in _cmbStep)
            {
                if (i == 0)
                {
                    t.SelectedItem = 50;
                }
                else if (i == 1)
                {
                    t.SelectedItem = 5;
                }
                else if (i == 2)
                {
                    t.SelectedItem = 0.5;
                }
            }
        }
        /// <summary>回零（XYZUVW使能）</summary>
        private void BtnServo_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (!(sender is Button btn)) return;

            var i = Array.IndexOf(_btnServo, btn);

            if (i < 0 || _ele.AxisIndex[i] == -1) return;

            var ret = _ele.SingleSetEnable(_ele.AxisIndex[i], !_ele.Axises[_ele.AxisIndex[i]].IsServoOn);
            MessageBox.Show(ret == 0 ? $@"{_ele.Axises[_ele.AxisIndex[i]].Name} 使能成功。 " : $@"{_ele.Axises[_ele.AxisIndex[i]].Name} 使能失败。 ");
        }
        /// <summary>回零（XYZUVW回零）</summary>
        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            try
            {
                if (!(sender is Button btn)) return;

                var i = Array.IndexOf(_btnHome, btn);
                if (i < 0 || _ele.AxisIndex[i] == -1) return;

                if (MessageBox.Show($@"{_ele.Axises[_ele.AxisIndex[i]].Name} 开始回零？", "回零", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                var ret = _ele.SingleHome(_ele.AxisIndex[i]);

                MessageBox.Show(ret == 0 ? $@"{_ele.Axises[_ele.AxisIndex[i]].Name} 回零成功。 " : $@"{_ele.Axises[_ele.AxisIndex[i]].Name} 回零失败。 ");
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"{_ele.Name} 回零出错：{ex.Message} 。");
            }
        }
        /// <summary>正负向移动</summary>
        private void BtnJog_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            var btn = sender as Button;
            try
            {
                if (btn == null) return;
                btn.Enabled = false;
                Cursor = Cursors.WaitCursor;
                if (btn.Text.Contains("+"))
                {
                    var i = Array.IndexOf(_btnJogPlus, btn);
                    if (i < 0 || _ele.AxisIndex[i] == -1) return;
                    var step = double.Parse(_cmbStep[i].Text);

                    if (step > 10 || _ele.Axises[_ele.AxisIndex[i]].InPel)
                        if (MessageBox.Show(
                            $@"确认将轴{_ele.Axises[_ele.AxisIndex[i]].Name} 移动 {step}mm ？：正限位- {_ele.Axises[_ele.AxisIndex[i]].InPel} ?",
                            @"警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;

                    var ret = _ele.SingleMoveRel(_ele.AxisIndex[i], step,
                         _ele.Axises[_ele.AxisIndex[i]].JogVel,
                         _ele.Axises[_ele.AxisIndex[i]].JogAcc,
                         _ele.Axises[_ele.AxisIndex[i]].JogDec);
                    if (ret != 0)
                        MessageBox.Show(
                            $@"{_ele.Axises[_ele.AxisIndex[i]].Name} 移动出错。");
                }
                else if (btn.Text.Contains("-"))
                {
                    var i = Array.IndexOf(_btnJogMinus, btn);
                    if (i < 0 || _ele.AxisIndex[i] == -1) return;
                    var step = double.Parse(_cmbStep[i].Text);

                    if (step > 10 || _ele.Axises[_ele.AxisIndex[i]].InMel)
                        if (MessageBox.Show(
                            $@"确认将轴{_ele.Axises[_ele.AxisIndex[i]].Name} 移动 {step}mm ？：负限位- {_ele.Axises[_ele.AxisIndex[i]].InMel} ?",
                            @"警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;

                    var ret = _ele.SingleMoveRel(_ele.AxisIndex[i], -step,
                         _ele.Axises[_ele.AxisIndex[i]].JogVel,
                         _ele.Axises[_ele.AxisIndex[i]].JogAcc,
                         _ele.Axises[_ele.AxisIndex[i]].JogDec);
                    if (ret != 0)
                        MessageBox.Show(
                            $@"{_ele.Axises[_ele.AxisIndex[i]].Name} 移动出错。");
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($@"{_ele.Name} 移动出错: {ex.Message} 。");
            }
            finally
            {
                Cursor = Cursors.Default;
                if (btn != null) btn.Enabled = true;
            }
        }
        /// <summary>轴组基本信息/轴状态/轴配置/DebugUI/点位列表显示</summary>
        private void UiInit()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UiInit));
            }
            else
            {
                if (_ele == null) return;

                tbName.Text = _ele.Name;
                tbInfo.Text = _ele.Info;
                tbType.Text = _ele.EleTypeName;
                cBoxVelMode.SelectedItem = _ele.VelMode.ToString();
                tbAxisNum.Text = _ele.AxisNum.ToString();
                tbAxisesConfigPath.Text = _ele.AxisesConfigPath;
                cBoxEnable.Checked = _ele.Enable;
                cBoxSimulate.Checked = _ele.IsSimulateMode;
                cBoxLogEnable.Checked = _ele.LogEnable;
                cBoxLogDisplay.Checked = _ele.LogDisplay;
                AddAxises();
            }
        }
        /// <summary>轴状态/轴配置/DebugUI/点位列表显示</summary>
        private void AddAxises()
        {
            if (_ele?.Axises == null || _ele.Axises.IsEmpty) return;

            _axisConfigControls.Clear();
            _axisStatusControls.Clear();
            flowPanelConfig.Controls.Clear();
            flowPanelStatus.Controls.Clear();

            foreach (var axis in _ele.Axises)
            {
                axis.Value.ManualEnable = _ele.ManualEnable;

                ((SingleAxisConfigControl)axis.Value.ConfigUi)?.UpdateAxisAndControls(axis.Value);
                _axisConfigControls.TryAdd(axis.Key, axis.Value.ConfigUi);
                flowPanelConfig.Controls.Add(axis.Value.ConfigUi ?? throw new InvalidOperationException());

                ((SingleAxisStatusControl)axis.Value.StatusUi)?.UpdateAxisAndControls(axis.Value);
                _axisStatusControls.TryAdd(axis.Key, axis.Value.StatusUi);
                flowPanelStatus.Controls.Add(axis.Value.StatusUi ?? throw new InvalidOperationException());

                _ele.AddAxisToDebugUi(axis.Value, axis.Key);

                if (_pointsForm != null)
                {
                    _pointsForm.AddAxis(axis.Value, axis.Key);
                }
            }

            tbAxisNum.Text = _ele.Axises.Count.ToString();
        }
        /// <summary>[手动调试_移动_回零UI显示处理]</summary>
        private void LoadAxises()
        {
            if (_ele.Axises.Count <= 0)
            {
                return;
            }

            //X轴
            if (_ele.X == null)
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
                btnMinusX.Text = _ele.X.Name + @"-";
                btnPlusX.Text = _ele.X.Name + @"+";
            }

            if (_ele.Y == null)
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
                btnMinusY.Text = _ele.Y.Name + @"-";
                btnPlusY.Text = _ele.Y.Name + @"+";
            }

            if (_ele.Z == null)
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
                btnMinusZ.Text = _ele.Z.Name + @"-";
                btnPlusZ.Text = _ele.Z.Name + @"+";
            }

            if (_ele.U == null)
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
                btnMinusU.Text = _ele.U.Name + @"-";
                btnPlusU.Text = _ele.U.Name + @"+";
            }

            if (_ele.V == null)
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
                btnMinusV.Text = _ele.V.Name + @"-";
                btnPlusV.Text = _ele.V.Name + @"+";
            }

            if (_ele.W == null)
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
                btnMinusW.Text = _ele.W.Name + @"-";
                btnPlusW.Text = _ele.W.Name + @"+";
            }
        }
        /// <summary>移动距离加载/回零序号加载</summary>
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

            //回零
            for (var i = 0; i < _cmbHomeOrder.Length; i++)
            {
                var cb = _cmbHomeOrder[i];
                cb.Items.Clear();
                cb.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5 });

                _btnHome[i].BackColor = Color.White;
                _btnServo[i].BackColor = Color.White;
            }
        }
        /// <summary>示教/MoveP/Jump列表更新</summary>
        /// <param name="lastpos"></param>
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
        /// <summary>点位示教</summary>
        /// <param name="name">名称</param>
        private void TeachPos(string name)
        {
            if (_ele.Points.GroupPoints.ToList().Exists(p => p.Value.Name == name))
            {
                var oldPos = _ele.Points.GroupPoints.FirstOrDefault(p => p.Value.Name == name);
                for (var i = 0; i < oldPos.Value.Pos.Length; i++) oldPos.Value.Pos[i] = _ele.Axises[i].ActualPos;

                _ele.Points.GroupPoints.TryUpdate(oldPos.Key, oldPos.Value, oldPos.Value);
                _ele.GroupToMotion();
            }
            else
            {
                var newPos = new PosCartesian
                {
                    Index = _ele.Points.GroupPoints.Count,
                    Name = name,
                    Pos = new double[_ele.AxisNum]
                };
                for (var i = 0; i < newPos.Pos.Length; i++) newPos.Pos[i] = _ele.Axises[i].ActualPos;

                _ele.Points.GroupPoints.TryAdd(newPos.Index, newPos);
                _ele.GroupToMotion();
            }
        }
        /// <summary>DataGridView点位列表更新</summary>
        private void LoadPositionPanel()
        {
            dgPoints.AllowUserToOrderColumns = false;
            dgPoints.Rows.Clear();
            dgPoints.Columns.Clear();

            var colIndex = dgPoints.Columns.Add("Index", "Index");
            dgPoints.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;

            var colName = dgPoints.Columns.Add("Name", "Name");
            dgPoints.Columns[colName].SortMode = DataGridViewColumnSortMode.NotSortable;

            //点位列表增加XYZUVW列
            foreach (var p in _axisName)
            {
                var col = dgPoints.Columns.Add(p, p);
                dgPoints.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

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
            }
        }
        /// <summary>轴组基本信息/配置UI/状态UI保存</summary>
        private void ConfigApply()
        {
            if (_ele == null)
            {
                return;
            }

            _ele.Name = !string.IsNullOrEmpty(tbName.Text) ? tbName.Text : throw new Exception("轴组名称不能为空");

            if (string.IsNullOrEmpty(tbInfo.Text))
            {
                tbInfo.Text = NLocalizer.GetString(_ele.Name, _ele.Name);
            }
            _ele.Info = tbInfo.Text;

            if (cBoxVelMode.SelectedItem == null)
            {
                throw new Exception("速度模式不能为空");
            }

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

            _ele.AxisNum = int.TryParse(tbAxisNum.Text, out var axisNum) ? axisNum : throw new Exception("轴总数→int失败");

            lock (_ele.LockAxises)
            {
                foreach (var axis in _ele.Axises)
                {
                    ((SingleAxisConfigControl)axis.Value.ConfigUi).ConfigsSave();
                    ((SingleAxisStatusControl)axis.Value.StatusUi).ConfigsSave();
                }
            }

            _ele.LoadAxisIndex();

            LoadAxises();
        }
        /// <summary>UI刷新</summary>
        public void UiRefresh()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UiRefresh));
            }
            else
            {
                if (_ele.EleRunStat == EleRunState.Other) return;

                for (var i = 0; i < _ele.AxisIndex.Length; i++)
                {
                    if (_ele.AxisIndex[i] == -1)
                    {
                        continue;
                    }
                    IEleAxis eleAxis = _ele.Axises[_ele.AxisIndex[i]];
                    if (eleAxis == null)
                    {
                        continue;
                    }

                    _tbPos[i].Text = eleAxis?.ActualPos.ToString();
                    _tbPos[i].BackColor = eleAxis.IsStop ? Color.White : Color.Lime;
                    _tbVel[i].Text = eleAxis.ActualVel.ToString();
                    _tbVel[i].BackColor = eleAxis.SignalInp ? Color.White : Color.Lime;
                    if (eleAxis.IsAlarm)
                    {
                        _btnServo[i].BackColor = Color.Red;
                        _btnJogMinus[i].BackColor = Color.Red;
                        _btnJogPlus[i].BackColor = Color.Red;
                    }
                    else
                    {
                        _btnServo[i].BackColor = eleAxis.IsServoOn ? Color.Lime : Color.White;
                        _btnJogPlus[i].BackColor = eleAxis.IsServoOn ? Color.White : Color.LightGray;
                        _btnJogMinus[i].BackColor = eleAxis.IsServoOn ? Color.White : Color.LightGray;
                    }

                    _tbMel[i].BackColor = eleAxis.InMel ? Color.Red : Color.White;
                    _tbPel[i].BackColor = eleAxis.InPel ? Color.Red : Color.White;
                    _tbOrg[i].BackColor = eleAxis.InOrigin ? Color.Lime : Color.White;
                    if (_axisConfigControls.Count > 0 && _axisConfigControls.Keys.Contains(_ele.AxisIndex[i]))
                    {
                        ((SingleAxisStatusControl)_axisStatusControls[_ele.AxisIndex[i]]).CycleUpdate();
                    }
                }
            }
        }
        /// <summary>基元类型切换时发生响应</summary>
        /// <param name="updatedAxis">轴接口</param>
        private void AxisOnOnAxisByTypeUpdated(IEleAxis updatedAxis)
        {
            _ele.UpdateAxisByType(updatedAxis);
        }



        /// <summary>右键保存</summary>
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
                if (int.TryParse(dgPoints.Rows[i].Cells[0].Value?.ToString(), out var index))
                {
                    listIndex.Add(index);
                }
                else
                {
                    MessageBox.Show($@"第{i}行的点序号填写有误，请查证。");
                    return;
                }

            if (IsSameWithHashSet(listIndex))
            {
                MessageBox.Show(@"表格中有重复的点位序列，请查证。");
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
                    W = double.TryParse(dgPoints.Rows[i].Cells[7].Value?.ToString(), out var w) ? w : -1
                };

                _ele.Points.MotionPoints.Add(newPoint);
            }

            _ele.MotionToGroup();
            _ele.ExportPointsToPath(_ele.PointsPath);
        }
        /// <summary>设置元件运行状态</summary>
        /// <param name="state">运行状态</param>
        public void SetEleRunState(EleRunState state)
        {
            if (tbState.InvokeRequired)
            {
                BeginInvoke(new Action<EleRunState>(SetEleRunState), state);
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
        /// <summary>更新点位</summary>
        internal void UpdatePoints()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdatePoints));
            }
            else
            {
                if (_pointsForm != null)
                {
                    _pointsForm.UpdatePoints();
                }
            }
        }

        private static bool IsSameWithHashSet(List<int> list)
        {
            ISet<int> set = new HashSet<int>();

            for (var i = 0; i < list.Count; i++)
                // 这里可利用该元素来实现统计重复的原理有哪些，及重复个数。
                //bool state = set.Add(arr[i]); // 如果返回false，表示set中已经有该元素。
                //Console.WriteLine(state);
                set.Add(list[i]);

            return set.Count != list.Count;
        }
        #endregion


        #region NoUsing
        private static bool IsSameWithHashSet(string[] arr)
        {
            ISet<string> set = new HashSet<string>();

            for (var i = 0; i < arr.Length; i++)
                // 这里可利用该元素来实现统计重复的原理有哪些，及重复个数。
                //bool state = set.Add(arr[i]); // 如果返回false，表示set中已经有该元素。
                //Console.WriteLine(state);
                set.Add(arr[i]);

            return set.Count != arr.Length;
        }

        private void AddNewSingleAxis(int num)
        {
            var count = num;
            flowPanelConfig.Controls.Clear();
            flowPanelStatus.Controls.Clear();

            if (_ele.Axises == null) _ele.Axises = new ConcurrentDictionary<int, IEleAxis>();

            _ele.Axises.Clear();

            for (var i = 0; i < count; i++)
            {
                var axis = new EleAxisByCard.EleAxisByCard($"Axis{i}", i, _ele.VelMode);
                _ele.Axises.TryAdd(i, axis);

                axis.ConfigUi.Dock = DockStyle.Top;
                _axisConfigControls.TryAdd(i, axis.ConfigUi);
                flowPanelConfig.Controls.Add(axis.ConfigUi);

                axis.StatusUi.Dock = DockStyle.Top;
                _axisStatusControls.TryAdd(i, axis.StatusUi);
                flowPanelStatus.Controls.Add(axis.StatusUi);

                _ele.AddAxisToDebugUi(axis, i);

                if (_pointsForm != null)
                {
                    _pointsForm.AddAxis(axis, i);
                }
            }
        }

        public void SetSimulateMode(bool simulate)
        {
            if (cBoxSimulate.InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetSimulateMode), simulate);
            }
            else
            {
                cBoxSimulate.Checked = simulate;
            }
        }
        #endregion


        public void OnLanguageChanged()
        {
            lbName.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_Name", "名称");
            lbInfo.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_Info", "信息");
            lbType.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_Type", "类型");
            lbState.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_State", "状态");
            lbVelMode.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_VelMode", "速度模式");
            lbFeedBackType.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_AxisCount", "轴数");
            tabPageAxisStatus.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_AxisStatus", "状态");
            tabPageAxisConfig.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_Config", "配置");
            tabPageManual.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_Manual", "手动调试");
            btnAxisesSave.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_AxisesSave", "保存");
            btnAxisesLoad.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_AxisesLoad", "载入");
            cBoxEnable.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_Enable", "使能");
            cBoxSimulate.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_Simulate", "模拟");
            cBoxLogEnable.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_LogEnable", "Log使能");
            cBoxLogDisplay.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_LogDisplay", "Log显示");
            btnOpenPoints.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_OpenPoints", "点位管理");
            btnConfigApply.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_ConfigApply", "应用");
            tsmSave.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_tsmSave", "保存");
            tsmReLoad.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_tsmReLoad", "重新载入");
            tsmUpdate.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_tsmUpdate", "更新");
            tsmToPoint.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_tsmToPoint", "移动至");

            groupBox3.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ConfigUI_Debug", "调试");
            tbInfo.Text = NLocalizer.GetString(_ele.Name, _ele.Name);

            tabPage3.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Move", "移动");
            btnAllStop.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_AllStop", "停止");
            tabPage4.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Home", "回零");

            string str_ServoOn = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOn", "使能");
            btnServoX.Text = "X-" + str_ServoOn;
            btnServoY.Text = "Y-" + str_ServoOn;
            btnServoZ.Text = "Z-" + str_ServoOn;
            btnServoU.Text = "U-" + str_ServoOn;
            btnServoV.Text = "V-" + str_ServoOn;
            btnServoW.Text = "W-" + str_ServoOn;
            btnHomeX.Text = "X-" + tabPage4.Text;
            btnHomeY.Text = "Y-" + tabPage4.Text;
            btnHomeZ.Text = "Z-" + tabPage4.Text;
            btnHomeU.Text = "U-" + tabPage4.Text;
            btnHomeV.Text = "V-" + tabPage4.Text;
            btnHomeW.Text = "W-" + tabPage4.Text;

            btnServoOnAll.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOnAll", "所有轴上使能");
            btnServoOffAll.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOffAll", "所有轴下使能");
            btnHomeAll.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_HomeAll", "轴组回零");
            btnHomeStop.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_HomeStop", "停止");
            groupBox5.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_MoveDistance", "移动距离");
            groupBox4.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ActivePosition", "实时位置");
            groupBox2.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Test", "测试");
            btnPosTeach.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_PosTeach", "示教");
            btnPosDelete.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_PosDelete", "删除");
            btnPosMoveP.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_PosMoveP", "点动");
            btnPosJump.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_PosJump", "门型动");
        }
    }
}