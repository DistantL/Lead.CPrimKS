using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.CustomControl;
using Lead.CPrim.ProxyTools.Win32;
using Sunny.UI.Win32;

namespace Lead.CPrim.EleCartesian.EleUIs
{
    /// <summary>手动调试UI</summary>
    public partial class ManualUI : UserControl
    {
        #region Field
        /// <summary>轴组元件</summary>
        private readonly EleCartesian _ele;
        /// <summary>正向移动Button</summary>
        private readonly Button[] _btnJogPlus;
        /// <summary>负向移动Button</summary>
        private readonly Button[] _btnJogMinus;
        /// <summary>步进距离</summary>
        private readonly ComboBox[] _cmbStep;
        /// <summary>
        /// 速度
        /// </summary>
        private readonly ComboBox[] _cmbSpeed;
        /// <summary>实时位置</summary>
        private readonly TextBox[] _tbPos;


        /// <summary>轴使能Button</summary>
        private readonly Button[] _btnServo;
        /// <summary>轴回原点Button</summary>
        private readonly Button[] _btnHome;
        /// <summary>轴回原点顺序</summary>
        private readonly ComboBox[] _cmbHomeOrder;

        /// <summary>
        /// 点位列表
        /// </summary>
        private BindingList<Pos> _posList = new BindingList<Pos>();
        /// <summary>
        /// DataGridView用来显示点位列表
        /// </summary>
        private DataGridView _dgPoints;
        /// <summary>
        /// 手动使能
        /// </summary>
        private bool _manualEnable = false;
        #endregion



        #region Ctor
        public ManualUI()
        {
            InitializeComponent();
            this.SetStyleALL(ControlStyle.Light);
        }

        public ManualUI(IEleCartesian ele) : this()
        {
            _ele = (EleCartesian)ele;

            _btnJogPlus = new[] { btnPlusX, btnPlusY, btnPlusZ, btnPlusU, btnPlusV, btnPlusW };
            _btnJogMinus = new[] { btnMinusX, btnMinusY, btnMinusZ, btnMinusU, btnMinusV, btnMinusW };
            _btnJogPlus.ToList().ForEach(p => p.Click += BtnJog_Click);
            _btnJogMinus.ToList().ForEach(p => p.Click += BtnJog_Click);

            _cmbStep = new[] { cmbStepX, cmbStepY, cmbStepZ, cmbStepU, cmbStepV, cmbStepW };
            _cmbSpeed = new[] { cmbSpeedX, cmbSpeedY, cmbSpeedZ, cmbSpeedU, cmbSpeedV, cmbSpeedW };
            _tbPos = new[] { tbPosX, tbPosY, tbPosZ, tbPosU, tbPosV, tbPosW };

            _btnServo = new[] { btnServoX, btnServoY, btnServoZ, btnServoU, btnServoV, btnServoW };
            _btnServo.ToList().ForEach(p => p.Click += BtnServo_Click);

            _btnHome = new[] { btnHomeX, btnHomeY, btnHomeZ, btnHomeU, btnHomeV, btnHomeW };
            _btnHome.ToList().ForEach(p => p.Click += BtnHome_Click);

            _cmbHomeOrder = new[] { cmbHomeOrderX, cmbHomeOrderY, cmbHomeOrderZ, cmbHomeOrderU, cmbHomeOrderV, cmbHomeOrderW };

            txtSafePosition.Text = _ele.SafetyAxisDefaultHeight.ToString();
        }

        public ManualUI(IEleCartesian ele, List<Pos> poslist, bool timerEnable = false, bool manualEnable = false) : this(ele)
        {
            //点位列表处理
            _posList.Clear();
            foreach (var p in poslist)
            {
                _posList.Add(new Pos(
                p.Name,
                Math.Round(p.X, 3),
                Math.Round(p.Y, 3),
                Math.Round(p.Z, 3),
                Math.Round(p.U, 3),
                Math.Round(p.V, 3),
                Math.Round(p.W, 3)));
            }

            _dgPoints = new DataGridView
            {
                Dock = DockStyle.Fill,
                ContextMenuStrip = contextMenuStrip1,
                AllowUserToAddRows = false
            };
            _dgPoints.KeyDown += DgPointsOnKeyDown;
            _dgPoints.CellClick += DgPointsOnCellClick;

            tlpMain.Controls.Add(_dgPoints, 0, 1);
            DgvRefresh();

            //测试区初始化
            LoadTeachPanel();

            if (timerEnable)
            {
                tmrRefresh.Interval = 100;
                tmrRefresh.Start();
            }
            else
            {
                tmrRefresh.Stop();
            }

            _manualEnable = manualEnable;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            chkIsGateMotion.Checked = true;
        }
        #endregion



        #region System_Event
        private void DebugUI_Load(object sender, EventArgs e)
        {
            if (_ele != null && !string.IsNullOrEmpty(_ele.Name))
            {
                //UiInit();
            }

            if (_ele == null) return;

            if (_ele?.EleRunStat == EleRunState.Other) _ele.IEleInit();

            LoadAxises();

            LoadManualPanel();
            //LoadTeachPanel();
            //LoadPositionPanel();
            SetManualEnable(_manualEnable);
        }

        /// <summary>
        /// 点位列表KeyDown事件（复制粘贴操作）
        /// </summary>
        private void DgPointsOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                _dgPoints.Copy();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                ControlHelper.DgvPaste(ref _dgPoints);
            }
        }

        /// <summary>
        /// 点位表点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgPointsOnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }

            cmbPointTeach.SelectedItem = _dgPoints.Rows[e.RowIndex].Cells[0].Value;
        }

        /// <summary>
        /// 门型运动切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIsGateMotion_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIsGateMotion.Checked && _ele.AxisZIndex != -1)
            {
                txtSafePosition.Text = _posList.Min(p => p.Z).ToString();
            }
        }
        #endregion



        #region Button_Event
        /// <summary>
        /// 手动移动Event
        /// </summary>
        private async void BtnJog_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            var btn = sender as Button;
            try
            {
                if (btn == null)
                {
                    return;
                }

                Cursor = Cursors.WaitCursor;
                if (btn != null)
                {
                    btn.Enabled = false;
                }

                if (btn.Text.Contains("+"))
                {
                    //在一个一维数组中搜索指定对象，并返回其首个匹配项的索引。。（第一个值匹配值=0）
                    var i = Array.IndexOf(_btnJogPlus, btn);
                    if (i < 0 || _ele.AxisIndex[i] == -1)
                    {
                        return;
                    }

                    var axis = _ele.Axises[_ele.AxisIndex[i]];
                    double step = _cmbStep[i].Text.ToDouble();
                    double speed = _cmbSpeed[i].Text.ToDouble();

                    if (axis.InPel)
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_PosSenerOn", "检测到正极限"));
                    }

                    if (step > 10)
                    {
                        if (MessageBox.Show(
                            string.Format(
                            NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_FuncBack", "确认将轴{0} 移动 {1}mm ?")
                            , axis.Name
                            , step)
                            , "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    await Task.Run(() =>
                    {
                        var ret = _ele.SingleMoveRel(_ele.AxisIndex[i], step, speed, axis.JogAcc, axis.JogDec);
                        if (ret != 0)
                        {
                            throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_FuncBack", "函数反馈:") + ret);
                        }
                    });
                }
                else if (btn.Text.Contains("-"))
                {
                    var i = Array.IndexOf(_btnJogMinus, btn);
                    if (i < 0 || _ele.AxisIndex[i] == -1)
                    {
                        return;
                    }

                    var axis = _ele.Axises[_ele.AxisIndex[i]];
                    double step = double.Parse(_cmbStep[i].Text);
                    double speed = _cmbSpeed[i].Text.ToDouble();

                    if (axis.InMel)
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_NegSenerOn", "检测到负极限"));
                    }

                    if (step > 10)
                    {
                        if (MessageBox.Show(
                            string.Format(
                            NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_FuncBack", "确认将轴{0} 移动 {1}mm ?")
                            , axis.Name
                            , step)
                            , "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    await Task.Run(() =>
                    {
                        var ret = _ele.SingleMoveRel(_ele.AxisIndex[i], -step, speed, axis.JogAcc, axis.JogDec);
                        if (ret != 0)
                        {
                            throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_FuncBack", "函数反馈:") + ret);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError(string.Format(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_MoveFail", "[{0}]移动失败:"), _ele.Name) + ex.Message);
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
                if (i < 0 || ((IEleCartesian)_ele).AxisIndex[i] == -1) return;
                if (MessageBox.Show($@"{((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].Name} " + NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_ConfirmToHome", "开始回零?"),
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

                var ret = ((IEleCartesian)_ele).SingleHome(((IEleCartesian)_ele).AxisIndex[i]);
                MessageBox.Show(ret == 0
                    ? $@"{((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].Name} " + NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_HomeSuccess", "回零成功")
                    : $@"{((IEleCartesian)_ele).Axises[((IEleCartesian)_ele).AxisIndex[i]].Name} " + NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_HomeFail", "回零失败"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"{_ele.Name} 回零出错：{ex.Message} 。");
            }
        }

        private void BtnServo_Click(object sender, EventArgs e)
        {
            if (_ele == null)
            {
                return;
            }

            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (!(sender is Button btn))
            {
                return;
            }

            var i = Array.IndexOf(_btnServo, btn);
            if (i < 0 || ((IEleCartesian)_ele).AxisIndex[i] == -1)
            {
                return;
            }

            IEleCartesian ele = (IEleCartesian)_ele;
            var ret = ele.SingleSetEnable(ele.AxisIndex[i], !ele.Axises[ele.AxisIndex[i]].IsServoOn);
            MessageBox.Show(ret == 0
                ? $@"{ele.Axises[ele.AxisIndex[i]].Name} " + NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOnSuccess", "使能成功")
                : $@"{ele.Axises[ele.AxisIndex[i]].Name} " + NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOnFail", "使能失败"));
        }

        /// <summary>所有轴上使能</summary>
        private void BtnServoOnAll_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (MessageBox.Show(
                string.Format(
               NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ConfirmToServoOnAll", "请确认将{0}的所有轴上使能")
                , _ele.Name)
                , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                var ret = _ele.GroupSetEnable(true) == 0;
                Cursor = Cursors.Default;
                MessageBox.Show(_ele.Name
                + NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOnAll", "所有轴上使能")
                + (ret
                ? NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_Success", "成功！")
                : NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_Fail", "失败！")));
            }
        }
        /// <summary>所有轴下使能</summary>
        private void BtnServoOffAll_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (MessageBox.Show(
                    string.Format(
                                NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ConfirmToServoOffAll", "请确认将{0}的所有轴下使能")
                                            , _ele.Name)
                                            , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                var ret = _ele.GroupSetEnable(false) == 0;
                Cursor = Cursors.Default;
                MessageBox.Show(_ele.Name
                                + NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOffAll", "所有轴下使能")
                                + (ret
                                ? NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_Success", "成功！")
                                : NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_Fail", "失败！")));

            }
        }
        /// <summary>轴组回零</summary>
        private void BtnHomeAll_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (MessageBox.Show(
                string.Format(
                        NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_ConfirmToAllAxisesToHome", "请确认将[{0}]的所有轴进行回原点运动?"), _ele.Name)
                , "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                var ret = _ele.GroupHome() == 0;
                Cursor = Cursors.Default;
                MessageBox.Show(_ele.Name
                    + NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_AllAxisesToHome", "所有轴回原点")
                    + (ret
                    ? NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_Success", "成功！")
                    : NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_Fail", "失败！")));
            }
        }
        /// <summary>停止</summary>
        private void BtnAllStop_Click(object sender, EventArgs e)
        {
            _ele.GroupStop();
        }
        /// <summary>示教</summary>
        private void BtnPosTeach_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (_ele.EleRunStat != EleRunState.Running)
            {
                return;
            }

            if (string.IsNullOrEmpty(cmbPointTeach.Text))
            {
                Notification.ShowWarn(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_TeachPosNameError", "示教点位名称有误"));
                return;
            }

            var curPos = ((IEleCartesian)_ele).GetActualPos();
            if (_posList.ToList().Exists(p => p.Name == cmbPointTeach.Text))
            {
                var lastPos = _posList.First(p => p.Name == cmbPointTeach.Text);
                UIPointCompare frm = new UIPointCompare(cmbPointTeach.Text);
                frm.SetPos(lastPos.PosToString(), curPos.PosToString());
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show(
                        string.Format(
                                    NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_ConfirmToAddPos", "确认添加一个新的点位 {0} ：X-{1},Y-{2},Z-{3},U-{4},V-{5},W-{6}?")
                                                , cmbPointTeach.Text
                                                , curPos.X.ToString("F3")
                                                , curPos.Y.ToString("F3")
                                                , curPos.Z.ToString("F3")
                                                , curPos.U.ToString("F3")
                                                , curPos.V.ToString("F3")
                                                , curPos.W.ToString("F3")
                                                ),
                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            TeachPos(cmbPointTeach.Text);
            LoadTeachPanel(cmbPointTeach.Text);
            DgvRefresh();
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
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_PosNameError", "点位名称有误"));
                return;
            }

            var delPos = _posList.FirstOrDefault(p => p.Name == cmbPointTeach.Text);

            //if (MessageBox.Show(
            //        string.Format(NLocalizer.GetString("EleCartesian_ConfigUI_DeletePoint", "Delete point {0} {1}"),
            //            delPos.Name), NLocalizer.GetString("EleCartesian_ConfigUI_Warning", "Warning"), MessageBoxButtons.YesNo) ==
            //    DialogResult.No)
            //{
            //    return;
            //}
            _posList.Remove(delPos);
            LoadTeachPanel();
            cmbPointTeach.Text = string.Empty;
            DgvRefresh();
        }

        /// <summary>MoveP</summary>
        private async void BtnPosMoveP_Click(object sender, EventArgs e)
        {
            try
            {
                btnPosMoveP.Enabled = false;

                string point = cmbPointTeach.Text.Trim();

                if (!_ele.CheckManualEnable())
                {
                    return;
                }

                string posName = cmbPointTeach.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(posName))
                {
                    throw new Exception( NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_NoSelectPos", "未选择点位"));
                }

                Vel vel = new Vel()
                {
                    X = _cmbSpeed[0].Text.ToDouble(),
                    Y = _cmbSpeed[1].Text.ToDouble(),
                    Z = _cmbSpeed[2].Text.ToDouble(),
                    U = _cmbSpeed[3].Text.ToDouble(),
                    V = _cmbSpeed[4].Text.ToDouble(),
                    W = _cmbSpeed[5].Text.ToDouble()
                };
                double safePosition = double.TryParse(txtSafePosition.Text.Trim(), out var value1) ? value1
                    : throw new Exception(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_SetSafePosFailDouble", "安全位置 => double失败"));

                var pos = _posList.FirstOrDefault(p => p.Name == cmbPointTeach.SelectedItem.ToString());
                if (pos == null)
                {
                    throw new Exception("点位不存在");
                }

                bool gateMotion = chkIsGateMotion.Checked;
                if (!gateMotion)
                {
                    await Task.Run(() =>
                    {
                        int ret = _ele.GroupMoveAbs(pos, vel);
                        if (ret != 0)
                        {
                            throw new Exception("GroupMoveAbs异常");
                        }
                    });

                    return;
                }

                if (_ele.AxisZIndex != -1)
                {
                    if (MessageBox.Show(
                        string.Format(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_ConfirmToContinue", "安全位高度 = [{0}],确定继续吗?"), safePosition)
                        , "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    {
                        return;
                    }
                }

                await Task.Run(() =>
                {
                    int ret = -1;
                    //Z移动至安全位
                    if (_ele.AxisZIndex != -1)
                    {
                        ret = _ele.Z.MoveAbs(null, safePosition, vel.Z);
                        if (ret != 0)
                        {
                            throw new Exception("MoveAbs异常");
                        }
                    }

                    //XYUVW移动
                    if (_ele.AxisXIndex != -1 || _ele.AxisYIndex != -1 || _ele.AxisUIndex != -1 || _ele.AxisVIndex != -1 || _ele.AxisWIndex != -1)
                    {
                        ret = _ele.GroupMoveAbs(new Pos
                        {
                            X = pos.X,
                            Y = pos.Y,
                            Z = safePosition,
                            U = pos.U,
                            V = pos.V,
                            W = pos.W
                        }, vel);
                        if (ret != 0)
                        {
                            throw new Exception("GroupMoveAbs异常");
                        }
                    }

                    //Z移动到位
                    if (_ele.AxisZIndex != -1)
                    {
                        ret = _ele.Z.MoveAbs(null, pos.Z, vel.Z);
                        if (ret != 0)
                        {
                            throw new Exception("MoveAbs异常");
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Notification.ShowError(ex.Message);
                string error = string.Format(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_MovePosFial", "轴组[{0}]点运动失败:"), _ele.Name) + ex.Message;
                LogHelper.LogAdd(LogLevel.Error, error, nameof(ManualUI));
            }
            finally
            {
                btnPosMoveP.Enabled = true;
            }
        }

        /// <summary>导出CSV文件</summary>
        private void 导出CSV文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(_dgPoints, true, ref errorText))
            {
                Notification.ShowError(errorText);
            }
        }

        /// <summary>导入CSV文件</summary>
        private void 导入CSV文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FileName = (string)null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var newListPos = new List<Pos>();

                Stream stream = openFileDialog.OpenFile();
                StreamReader streamReader = new StreamReader(stream, GlobalVariables.EncodingChinese);
                try
                {
                    streamReader.ReadLine();
                    do
                    {
                        var line = streamReader.ReadLine();
                        if (string.IsNullOrEmpty(line))
                        {
                            break;
                        }

                        var posInfo = line.Split(',').ToList();
                        var newPos = new Pos();
                        if (posInfo.Count < 7)
                        {
                            for (var i = posInfo.Count; i < 7; i++)
                            {
                                posInfo.Add("0.0");
                            }
                        }

                        newPos.Name = posInfo[0];
                        newPos.X = double.TryParse(posInfo[1], out var x) ? x : 0.0;
                        newPos.Y = double.TryParse(posInfo[2], out var y) ? y : 0.0;
                        newPos.Z = double.TryParse(posInfo[3], out var z) ? z : 0.0;
                        newPos.U = double.TryParse(posInfo[4], out var u) ? u : 0.0;
                        newPos.V = double.TryParse(posInfo[5], out var v) ? v : 0.0;
                        newPos.W = double.TryParse(posInfo[6], out var w) ? w : 0.0;
                        newListPos.Add(newPos);

                    } while (true);
                    streamReader.Close();
                    stream.Close();

                    if (newListPos.Count > 0)
                    {
                        var dialogResult = MessageBox.Show(
                            NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Tip_ConfirmToAddOrReplace", "请确认是要追加数据(选是)还是做数据替换(选否)?")
                            , "",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.ServiceNotification);
                        if (dialogResult == DialogResult.Yes)
                        {
                            for (var i = 0; i < newListPos.Count; i++)
                            {
                                _posList.Add(newListPos[i]);
                            }
                        }

                        if (dialogResult == DialogResult.No)
                        {
                            _posList.Clear();
                            for (var i = 0; i < newListPos.Count; i++)
                            {
                                _posList.Add(newListPos[i]);
                            }
                        }

                        DgvRefresh();
                        LoadTeachPanel();
                    }

                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ErrMsg_ImportDataFail", "数据导入异常:") + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        /// <summary>清除数据</summary>
        private void 清除数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _posList = new BindingList<Pos>();
            LoadTeachPanel();
            DgvRefresh();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 手动状态设置
        /// </summary>
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
                _btnServo.ToList().ForEach(p => p.Enabled = value);
                _btnHome.ToList().ForEach(p => p.Enabled = value);
                _cmbHomeOrder.ToList().ForEach(p => p.Enabled = value);

                btnAllStop.Enabled = value;

                btnServoOnAll.Enabled = value;
                btnServoOffAll.Enabled = value;
                btnHomeStop.Enabled = value;

                btnPosTeach.Enabled = value;
                btnPosDelete.Enabled = value;
                btnPosMoveP.Enabled = value;

                if (value)
                {
                    LoadAxises();
                }
            }
        }

        public List<Pos> GetPosList()
        {
            return _posList.ToList();
        }

        public void OnLanguageChanged()
        {
            tpMove.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Move", "移动");
            btnAllStop.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_AllStop", "停止");
            tpZero.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Home", "回零");

            string str_ServoOn = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOn", "使能");
            btnServoX.Text = "X-" + str_ServoOn;
            btnServoY.Text = "Y-" + str_ServoOn;
            btnServoZ.Text = "Z-" + str_ServoOn;
            btnServoU.Text = "U-" + str_ServoOn;
            btnServoV.Text = "V-" + str_ServoOn;
            btnServoW.Text = "W-" + str_ServoOn;
            btnHomeX.Text = "X-" + tpZero.Text;
            btnHomeY.Text = "Y-" + tpZero.Text;
            btnHomeZ.Text = "Z-" + tpZero.Text;
            btnHomeU.Text = "U-" + tpZero.Text;
            btnHomeV.Text = "V-" + tpZero.Text;
            btnHomeW.Text = "W-" + tpZero.Text;

            btnServoOnAll.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOnAll", "所有轴上使能");
            btnServoOffAll.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_ServoOffAll", "所有轴下使能");
            btnHomeStop.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_HomeStop", "停止");
            groupBox5.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_MoveDistance", "移动距离");
            uiLabel1.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_MoveJog", "寸动距离");
            uiLabel2.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_MovePosition", "实时位置");
            uiLabel3.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_MoveVel", "设定速度");
            groupBox2.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_Test", "测试");
            btnPosTeach.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_PosTeach", "示教");
            btnPosDelete.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_PosDelete", "删除");
            btnPosMoveP.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_ManualUI_PosMoveP", "点动");
        }
        #endregion



        #region 定时器相关
        private void TmrRefresh_Tick(object sender, EventArgs e)
        {
            UiRefresh();
        }

        /// <summary>
        /// UI刷新
        /// </summary>
        public void UiRefresh()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UiRefresh));
            }
            else
            {
                SetEleRunState(_ele.EleRunStat);
                if (_ele.EleRunStat != EleRunState.Running)
                {
                    return;
                }

                bool flag = false;
                for (var i = 0; i < ((IEleCartesian)_ele).AxisIndex.Length; i++)
                {
                    if (((IEleCartesian)_ele).AxisIndex[i] == -1)
                    {
                        continue;
                    }

                    IEleAxis axis = _ele.Axises[((IEleCartesian)_ele).AxisIndex[i]];

                    //编码器位置
                    _tbPos[i].Text = axis.ActualPos.ToString();

                    //编码器位置背景色
                    _tbPos[i].BackColor = axis.IsStop ? Color.White : Color.Lime;

                    //使能/正负移动背景色（背景色由报警决定）
                    _btnServo[i].BackColor = axis.IsAlarm ? Color.Red : axis.IsServoOn ? Color.Lime : Color.White;
                    _btnJogMinus[i].BackColor = axis.IsAlarm ? Color.Red : axis.IsServoOn ? Color.White : Color.LightGray;
                    _btnJogPlus[i].BackColor = axis.IsAlarm ? Color.Red : axis.IsServoOn ? Color.White : Color.LightGray;

                    //正负移动前景色（前景色由极限决定）
                    _btnJogPlus[i].ForeColor = axis.InPel ? Color.Red : Color.Black;
                    _btnJogMinus[i].ForeColor = axis.InMel ? Color.Red : Color.Black;

                    if (!axis.IsStop || axis.IsAlarm || !axis.IsServoOn || axis.InPel || axis.InMel)
                    {
                        flag = true;
                    }
                }

                if (!flag)
                {
                    btnPosMoveP.Enabled = true;
                }
                else
                {
                    btnPosMoveP.Enabled = false;
                }

                if (GetOnPause())
                {
                    _ele.GroupStop();
                }
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 测试区初始化（示教/MoveP）
        /// </summary>
        /// <param name="lastpos">点位名称</param>
        private void LoadTeachPanel(string lastpos = null)
        {
            var pos = _posList.Select(p => NLocalizer.GetString(p.Name, p.Name)).ToArray();

            //teach pos
            cmbPointTeach.Items.Clear();
            cmbPointTeach.Items.AddRange(pos);
            cmbPointTeach.SelectedItem = lastpos;
        }

        /// <summary>
        /// 点位列表刷新
        /// </summary>
        private void DgvRefresh()
        {
            SuspendLayout();
            _dgPoints.DataSource = null;
            _dgPoints.DataSource = _posList;
            for (int i = 0; i < _dgPoints.ColumnCount; i++)
            {
                _dgPoints.Columns[i].Width = i == 0 ? 300 : 100;
            }
            //for (int i = 0; i < _dgPoints.RowCount; i++)
            //{
            //    _dgPoints.Rows[i].Cells[0].Value = NLocalizer.GetString(_dgPoints.Rows[i].Cells[0].Value.ToString(), _dgPoints.Rows[i].Cells[0].Value.ToString());
            //}
            ResumeLayout();
        }

        private void LoadManualPanel()
        {
            for (var i = 0; i < _cmbStep.Length; i++)
            {
                var cb = _cmbStep[i];
                cb.Items.Clear();
                cb.Items.AddRange(new object[] { 0.001, 0.01, 0.1, 0.5, 1, 5, 10, 20, 30, 40, 50, 100, 150 });
                cb.SelectedItem = 1;

                _btnJogPlus[i].BackColor = Color.White;
                _btnJogMinus[i].BackColor = Color.White;
            }

            for (var i = 0; i < _cmbSpeed.Length; i++)
            {
                var cb = _cmbSpeed[i];
                cb.Items.Clear();
                cb.Items.AddRange(new object[] { 0.001, 0.01, 0.1, 1, 5, 10, 20, 50 });
                cb.SelectedItem = 5;
            }

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

        private void LbState_Click(object sender, EventArgs e)
        {
            if (_ele.EleRunStat == EleRunState.Other) _ele.IEleInit();
            if (_ele.EleRunStat == EleRunState.Err) _ele.IEleReset();
        }

        private bool GetOnPause()
        {
            bool flag = false;
            try
            {
                var eles = ElesManagerTransfer.GetAllIEle().FindAll(p => p.EleRunStat == EleRunState.Running && p.Enable && p.Name.Contains("暂停按钮") && p.EleTypeName == "DI");
                foreach (var ele in eles)
                {
                    if (((IEleDI)ele).Read())
                    {
                        flag = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }

        private void LoadAxises()
        {
            if (((IEleCartesian)_ele).Axises.Count <= 0) return;

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
                btnMinusX.Text = ((IEleCartesian)_ele).X.Name + @"-";
                btnPlusX.Text = ((IEleCartesian)_ele).X.Name + @"+";
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
                btnMinusY.Text = ((IEleCartesian)_ele).Y.Name + @"-";
                btnPlusY.Text = ((IEleCartesian)_ele).Y.Name + @"+";
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
                btnMinusZ.Text = ((IEleCartesian)_ele).Z.Name + @"-";
                btnPlusZ.Text = ((IEleCartesian)_ele).Z.Name + @"+";
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
                btnMinusU.Text = ((IEleCartesian)_ele).U.Name + @"-";
                btnPlusU.Text = ((IEleCartesian)_ele).U.Name + @"+";
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
                btnMinusV.Text = ((IEleCartesian)_ele).V.Name + @"-";
                btnPlusV.Text = ((IEleCartesian)_ele).V.Name + @"+";
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
                btnMinusW.Text = ((IEleCartesian)_ele).W.Name + @"-";
                btnPlusW.Text = ((IEleCartesian)_ele).W.Name + @"+";
            }
        }

        private PosCartesian PosToPosCartesian(int index, Pos pos)
        {
            var posCartesian = new PosCartesian
            {
                Index = index,
                Name = pos.Name,
                Pos = new double[6]
            };
            if (_ele.AxisXIndex != -1) posCartesian.Pos[_ele.AxisXIndex] = pos.X;
            if (_ele.AxisYIndex != -1) posCartesian.Pos[_ele.AxisYIndex] = pos.Y;
            if (_ele.AxisZIndex != -1) posCartesian.Pos[_ele.AxisZIndex] = pos.Z;
            if (_ele.AxisUIndex != -1) posCartesian.Pos[_ele.AxisUIndex] = pos.U;
            if (_ele.AxisVIndex != -1) posCartesian.Pos[_ele.AxisVIndex] = pos.V;
            if (_ele.AxisWIndex != -1) posCartesian.Pos[_ele.AxisWIndex] = pos.W;
            return posCartesian;
        }

        private void SetEleRunState(EleRunState state)
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

        private void TeachPos(string name)
        {
            if (_posList.ToList().Exists(p => p.Name == name))
            {
                var oldPos = _posList.FirstOrDefault(p => p.Name == name);
                if (oldPos != null) _ele.UpdatePos(oldPos);
            }
            else
            {
                var newPos = new Pos
                {
                    Name = name,
                    X = _ele.X?.ActualPos ?? -999.999,
                    Y = _ele.Y?.ActualPos ?? -999.999,
                    Z = _ele.Z?.ActualPos ?? -999.999,
                    U = _ele.U?.ActualPos ?? -999.999,
                    V = _ele.V?.ActualPos ?? -999.999,
                    W = _ele.W?.ActualPos ?? -999.999,
                };
                _posList.Add(newPos);
            }
        }
        #endregion

        private void tbSafePosition_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtSafePosition.Text, out double height))
            {
                _ele.SafetyAxisDefaultHeight = height;
            }
        }
    }
}