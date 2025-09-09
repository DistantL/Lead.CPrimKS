using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.EleAxisByCard
{
    /// <summary>元件配置_轴组_状态</summary>
    public partial class SingleAxisStatusControl : UserControl
    {
        #region Field
        /// <summary>轴接口【IEleAxis】对接用户</summary>
        private IEleAxis _axis;
        /// <summary>Jog</summary>
        private Button[] _btnJog;
        /// <summary>移动距离</summary>
        private RadioButton[] _radioButtonStepDistance;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public SingleAxisStatusControl()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="axis">轴接口【IEleAxis】对接用户</param>
        public SingleAxisStatusControl(IEleAxis axis)
        {
            InitializeComponent();
            _axis = axis;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void SingleAxisStatusControl_Load(object sender, EventArgs e)
        {
            UpdateAxisName(_axis.Name);
            tBoxJogAcc.Text = _axis.JogAcc.ToString(CultureInfo.InvariantCulture);
            tBoxJogDec.Text = _axis.JogDec.ToString(CultureInfo.InvariantCulture);
            tBoxJogVel.Text = _axis.JogVel.ToString(CultureInfo.InvariantCulture);

            _radioButtonStepDistance = new[] { rBtnStepLong, rBtnStepMedium, rBtnStepShort };
            _radioButtonStepDistance.ToList().ForEach(p => p.CheckedChanged += radioButtonStep_CheckedChanged);

            _btnJog = new[] { btnJogAdd, btnJogDec };
            _btnJog.ToList().ForEach(p =>
            {
                p.Click -= BtnJog_Click;
                p.Click += BtnJog_Click;
            });

            LoadJogPanel();
        }
        #endregion



        #region Button_Event
        /// <summary>使能</summary>
        private void btnServoOn_Click(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            if (_axis.DriveType == AxisType.Step)
                _axis.ServoEnable(null, _axis.IsServoOn);
            else
                _axis.ServoEnable(null, !_axis.IsServoOn);
        }
        /// <summary>清报警</summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            _axis.ResetAlarm();
        }
        /// <summary>回零</summary>
        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            if (!_axis.IsStop)
            {
                ProxyTools.Notification.ShowWarn(string.Format(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ErrMsg_CannotHomeAxisIsMoving", "轴[{0}]正在运行中,请停止后进行回零!!!"), _axis.Name));

                return;
            }

            if (_axis.FeedBackType == FeedBackType.Absolute)
            {
                var dialogResult = MessageBox.Show(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Tip_ConfirmToAxisHome", "该轴是绝对式伺服，确认要回零吗?")
                    , ""
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Information
                    , MessageBoxDefaultButton.Button2
                    , MessageBoxOptions.ServiceNotification);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            Task.Run(() =>
            {
                _axis.Home(null, 50);
            });
        }
        /// <summary>速度模式正方向启动</summary>
        private void btnVelAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            if (!_axis.IsStop)
            {
                _axis.ChangeVel(_axis.JogVel);
            }
            else
            {
                _axis.MoveVel(null, _axis.JogVel);
            }
        }
        /// <summary>速度模式正方向停止</summary>
        private void btnVelAdd_MouseUp(object sender, MouseEventArgs e)
        {
            _axis.StopMove();
        }
        /// <summary>速度模式负方向启动</summary>
        private void btnVelDec_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            if (!_axis.IsStop)
                _axis.ChangeVel(-_axis.JogVel);
            else
                _axis.MoveVel(null, -_axis.JogVel);
        }
        /// <summary>速度模式负方向停止</summary>
        private void btnVelDec_MouseUp(object sender, MouseEventArgs e)
        {
            _axis.StopMove();
        }
        /// <summary>停止</summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            _axis.StopMove();
        }
        /// <summary>移至</summary>
        private void btnGoPos_Click(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            if(string.IsNullOrEmpty(tBoxGoPos.Text))
            {
                ProxyTools.Notification.ShowWarn(string.Format(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ErrMsg_SetPosIsEmpty", "轴[{0}]位置为空!!!") ,_axis.Name));
                return;
            }

            if (!_axis.IsStop)
            {
                ProxyTools.Notification.ShowWarn(string.Format(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ErrMsg_CannotMoveAxisIsMoving", "轴[{0}]正在运行中,请停止后进行移动!!!"), _axis.Name ));
                return;
            }

            var strPos = tBoxGoPos.Text;

            Task.Run(() =>
            {
                if (strPos.Contains("+"))
                {
                    if (double.TryParse(strPos.Split('+')[1], out var pos)) _axis.MoveRel(null, pos, _axis.JogVel);
                }
                else if (strPos.Contains("--"))
                {
                    if (double.TryParse(strPos.Substring(2), out var pos)) _axis.MoveRel(null, -pos, _axis.JogVel);
                }
                else
                {
                    if (double.TryParse(strPos, out var pos)) _axis.MoveAbs(null, pos, _axis.JogVel);
                }
            });
        }
        /// <summary>设置</summary>
        private void btnSetPos_Click(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            if (string.IsNullOrEmpty(tBoxSetPos.Text)) _axis.SetPosition(0);

            if (double.TryParse(tBoxSetPos.Text, out var pos)) _axis.SetPosition(pos);
        }
        /// <summary>右键选择</summary>
        private void mnutConfigUiSelected_Click(object sender, EventArgs e)
        {
            _axis.IsSelected = !_axis.IsSelected;
            mnutConfigUiSelected.Text = _axis.IsSelected
                ? NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Deselect", "取消选择")
                : NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Select", "选择");
        }
        /// <summary>加速时间切换</summary>
        private void TBoxJogAcc_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tBoxJogAcc.Text, out var acc)) _axis.JogAcc = acc;
        }
        /// <summary>减速时间切换</summary>
        private void TBoxJogDec_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tBoxJogDec.Text, out var dec)) _axis.JogDec = dec;
        }
        /// <summary>手动速度切换</summary>
        private void TBoxJogVel_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tBoxJogVel.Text, out var vel)) _axis.JogVel = vel;
        }
        /// <summary>位置双击（轴指令位置设置为编码器位置）</summary>
        private void lbSetPos_DoubleClick(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            _axis.SetFeedbackToPostion();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>更新轴接口【IEleAxis】对接用户及名称</summary>
        /// <param name="axis"></param>
        public void UpdateAxisAndControls(IEleAxis axis)
        {
            _axis = axis;
            UpdateAxisName(axis.Name);
        }
        /// <summary>轴名称更新</summary>
        internal void UpdateAxisName()
        {
            if (gBoxAxisName.InvokeRequired)
            {
                BeginInvoke(new Action(UpdateAxisName));
            }
            else
            {
                gBoxAxisName.Text = _axis.Name;
            }
        }
        /// <summary>被选择</summary>
        internal void Selected()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(Selected));
            }
            else
            {
                BackColor = _axis.IsSelected ? Color.Green : SystemColors.Control;
            }
        }
        /// <summary>保存</summary>
        public void ConfigsSave()
        {
            TBoxJogAcc_TextChanged(null, null);
            TBoxJogDec_TextChanged(null, null);
            TBoxJogVel_TextChanged(null, null);
            _axis.UpdateJogVel();
        }
        /// <summary>UI更新</summary>
        public void CycleUpdate()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CycleUpdate));
            }
            else
            {
                lbelCmdPos.Text = _axis.CmdPos.ToString();
                lbelCmdVel.Text = _axis.CmdVel.ToString();
                lbelActualPos.Text = _axis.ActualPos.ToString();
                lbelActualVel.Text = _axis.ActualVel.ToString();

                labelALM.BackColor = _axis.IsAlarm ? Color.Red : Color.Gray;
                labelPEL.BackColor = _axis.InPel ? Color.Red : Color.Gray;
                labelMEL.BackColor = _axis.InMel ? Color.Red : Color.Gray;
                labelORG.BackColor = _axis.InOrigin ? Color.Green : Color.Gray;
                labelEMG.BackColor = _axis.SignalEmg ? Color.Red : Color.Gray;
                labelINP.BackColor = _axis.SignalInp ? Color.Green : Color.Gray;
                labelCSTP.BackColor = _axis.IsStop ? Color.Red : Color.Gray;
                labelSPEL.BackColor = _axis.InSPel ? Color.Red : Color.Gray;
                labelSMEL.BackColor = _axis.InSMel ? Color.Red : Color.Gray;
                lbSInp.BackColor = _axis.SInp ? Color.Red : Color.Gray;

                btnServoOn.BackColor = _axis.IsServoOn ? Color.Green : Color.Red;
            }
        }
        /// <summary>手动设置</summary>
        /// <param name="value"></param>
        internal void SetManualEnable(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetManualEnable), value);
            }
            else
            {
                btnServoOn.Enabled = value;
                btnReset.Enabled = value;
                btnHome.Enabled = value;
                btnJogAdd.Enabled = value;
                btnJogDec.Enabled = value;
                btnVelAdd.Enabled = value;
                btnVelDec.Enabled = value;
                btnStop.Enabled = value;
                btnGoPos.Enabled = value;
                btnSetPos.Enabled = value;
                lbSetPos.Enabled = value;
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>[元件配置_轴组_状态]名称更新</summary>
        /// <param name="newAxisName">名称</param>
        private void UpdateAxisName(string newAxisName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(UpdateAxisName), newAxisName);
            }
            else
            {
                gBoxAxisName.Text = newAxisName;
            }
        }
        /// <summary>移动距离按钮切换</summary>
        private void radioButtonStep_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                var i = Array.IndexOf(_radioButtonStepDistance, rb);

                if (i < 0)
                {
                    return;
                }

                comboBoxJogStep.SelectedItem = i == 0 ? 50 : (i == 1 ? 5 : 0.5);
            }
        }
        /// <summary>Jog</summary>
        private void BtnJog_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var err = string.Format(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ErrMsg_AxisJog", "轴[{0}]JOG运动"),_axis.Name);

            try
            {
                if (!_axis.CheckManualEnable())
                {
                    return;
                }

                if (!_axis.IsStop)
                {
                    return;
                }

                if (btn == null)
                {
                    throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ErrMsg_ButtonIsEmpty", ":按钮为空"));
                }

                if (comboBoxJogStep.SelectedItem == null)
                {
                    throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ErrMsg_JogStepValueIsEmpty", ":步进值为空"));
                }

                btn.Enabled = false;

                if (!double.TryParse(comboBoxJogStep.SelectedItem.ToString(), out var jogStep)) return;

                Task.Run(() =>
                {
                    if (btn.Text.Contains("+"))
                    {
                        _axis.MoveRel(null, jogStep, _axis.JogVel);
                    }
                    else if (btn.Text.Contains("-"))
                    {
                        _axis.MoveRel(null, -jogStep, _axis.JogVel);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ErrMsg_MoveFail", ":移动错误:") +ex.Message);
            }
            finally
            {
                if (btn != null)
                {
                    btn.Enabled = true;
                }
            }
        }
        /// <summary>移动距离加载</summary>
        private void LoadJogPanel()
        {
            comboBoxJogStep.Items.Clear();
            comboBoxJogStep.Items.AddRange(new object[] { 0.02, 0.1, 0.5, 1, 5, 10, 20, 30, 40, 50, 100, 150, 1000, 100000 });

            foreach (var t in _btnJog)
            {
                t.BackColor = Color.White;
                t.BackColor = Color.White;
            }
            
            _radioButtonStepDistance[2].Checked = true;
        }
        #endregion

        public void OnLanguageChanged()
        {
            gBoxMonitor.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_gBoxMonitor", "状态");
            lb_CommandPos.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_CommandPos", "命令位置:");
            lb_CommandSpeed.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_CommandSpeed", "命令速度:");
            lb_ActivePos.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ActivePos", "实际位置:");
            lb_ActiveSpeed.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ActiveSpeed", "实际速度:");
            gBoxDebug.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_gBoxDebug", "调试");
            btnServoOn.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_ServoOn", "使能");
            btnReset.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Reset", "清报警");
            btnHome.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Home", "回零");
            btnStop.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Stop", "停止");
            lbSetPos.Text = lb_GoPos.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Pos", "位置");
            btnGoPos.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_GoPos", "移至");
            btnSetPos.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_SetPos", "设置");
            tabJogStep.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_JogStep", "Jog距离");
            rBtnStepLong.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_StepLong", "长距离");
            rBtnStepMedium.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_StepMedium", "中等距离");
            rBtnStepShort.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_StepShort", "短距离");
            lb_JogStepValue.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_JogStepValue", "步进值");
            lb_SpeedValue.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_SpeedValue", "速度");
            tabJogVel.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_tabJogVel", "Jog加减速");
            lbelDefaultAcc.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Acc", "加速:");
            lbelDefaultDec.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisStatusControl_Dec", "减速:");
        }
    }
}