using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.EleAxisByCard
{
    /// <summary>元件调试_轴组_手动调试</summary>
    public partial class SingleAxisManualControl : UserControl
    {
        #region Field
        /// <summary>轴接口【IEleAxis】对接用户</summary>
        private IEleAxis _axis;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public SingleAxisManualControl()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="axis"></param>
        public SingleAxisManualControl(IEleAxis axis)
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
        }
        #endregion



        #region Button_Event
        /// <summary>回零</summary>
        private async void btnHome_Click(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            if (_axis.FeedBackType == FeedBackType.Absolute)
            {
                if (!this.ShowAskDialog(NLocalizer.AxisIsAbsoluteServoConfirmBackToZero, UIStyle.Orange))
                {
                    return;
                }
            }

            await Task.Run(() => _axis.Home(null, 50));
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
        /// <summary>右键选择</summary>
        private void mnutConfigUiSelected_Click(object sender, EventArgs e)
        {
            _axis.IsSelected = !_axis.IsSelected;
            mnutConfigUiSelected.Text = _axis.IsSelected ?
                NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_Deselect", "取消选择")
                : NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_Select", "选择");
        }
        /// <summary>使能</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServoOn_Click(object sender, EventArgs e)
        {
            if (!_axis.CheckManualEnable())
            {
                return;
            }

            if (_axis.DriveType == AxisType.Step)
            {
                _axis.ServoEnable(null, _axis.IsServoOn);
            }
            else
            {
                _axis.ServoEnable(null, !_axis.IsServoOn);
            }
        }
        /// <summary>正方向停止</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJogPlus_MouseUp(object sender, MouseEventArgs e)
        {
            _axis.StopMove();
        }
        /// <summary>正方向运动</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJogPlus_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (!_axis.CheckManualEnable())
                {
                    return;
                }

                double speed = GetSpeed();

                if (!_axis.IsStop)
                    _axis.ChangeVel(speed);
                else
                    _axis.MoveVel(null, speed);
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_MoveForwardDirectionFail", "正方向运动失败:") + ex.Message);
            }
        }
        /// <summary>负方向停止</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJogMinus_MouseUp(object sender, MouseEventArgs e)
        {
            _axis.StopMove();
        }
        /// <summary>负方向运动</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJogMinus_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (!_axis.CheckManualEnable())
                {
                    return;
                }

                double speed = GetSpeed();

                if (!_axis.IsStop)
                    _axis.ChangeVel(-speed);
                else
                    _axis.MoveVel(null, -speed);
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_MoveNegativeDirectionFail", "负方向运动失败:") + ex.Message);
            }
        }
        /// <summary>绝对运动</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveAbs_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_axis.CheckManualEnable())
                {
                    return;
                }

                double speed = GetSpeed();
                double pos = GetPos();
                Task.Run(() =>
                {
                    _axis.MoveAbs(null, pos, speed);
                });
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_MoveAbsFail", "绝对移动失败:") + ex.Message);
            }
        }
        /// <summary>相对运动</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveRel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_axis.CheckManualEnable())
                {
                    return;
                }

                double speed = GetSpeed();
                double pos = GetPos();

                Task.Run(() =>
                {
                    _axis.MoveRel(null, pos, speed);
                });
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_MoveRelFail", "相对移动失败:") + ex.Message);
            }
        }

        /// <summary>
        /// 清报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblALM_Click(object sender, EventArgs e)
        {
            _axis.ResetAlarm();
        }
        #endregion



        #region Others
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
                pnlMain.Enabled = value;
            }
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
                lblActualPos.Text = _axis.ActualPos.ToString();

                lblALM.BackColor = _axis.IsAlarm ? Color.Red : Color.Gray;
                lblPEL.BackColor = _axis.InPel ? Color.Red : Color.Gray;
                lblMEL.BackColor = _axis.InMel ? Color.Red : Color.Gray;
                lblORG.BackColor = _axis.InOrigin ? Color.Green : Color.Gray;

                btnServoOn.BackColor = _axis.IsServoOn ? Color.Green : Color.Red;
            }
        }
        /// <summary>更新轴接口【IEleAxis】对接用户及名称</summary>
        public void UpdateAxisAndControls(IEleAxis axis)
        {
            _axis = axis;
            UpdateAxisName(axis.Name);
        }
        /// <summary>[元件调试_轴组_手动调试]名称更新</summary>
        internal void UpdateAxisName(string newAxisName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(UpdateAxisName), newAxisName);
            }
            else
            {
                lblName.Text = newAxisName;
            }
        }
        /// <summary>轴名称更新</summary>
        internal void UpdateAxisName()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdateAxisName));
            }
            else
            {
                lblName.Text = _axis.Name;
            }
        }
        private double GetSpeed()
        {
            string speed = txtSpeed.Text.Trim();
            double speedAfter = 0;
            if (string.IsNullOrEmpty(speed))
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_SpeedIsEmpty", "速度值为空"));
            }
            if (!double.TryParse(speed, out speedAfter))
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_SpeedIsError", "速度值无效"));
            }
            if (speedAfter <= 0)
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_SpeedUnder0", "速度值小于等于0"));
            }
            return speedAfter;
        }
        private double GetPos()
        {
            string targetPos = txtTargetPosition.Text.Trim();
            double targetPosAfter = 0;
            if (string.IsNullOrEmpty(targetPos))
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_TargetPosIsEmpty", "目标位置为空"));
            }
            if (!double.TryParse(targetPos, out targetPosAfter))
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ErrMsg_TargetPosIsError", "目标位置值无效"));
            }
            return targetPosAfter;
        }
        #endregion

        public void OnLanguageChanged()
        {
            btnServoOn.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_ServoOn", "使能");
            labelPos.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_Pos", "编码器位置");
            labelSpeedSet.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_SpeedSet", "速度");
            labelPosSet.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_PosSet", "目标位置");
            btnMoveAbs.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_MoveAbs", "绝对定位");
            btnMoveRel.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_MoveRel", "相对定位");
            btnStop.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_Stop", "立即停止");
            btnHome.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_Home", "回零");
            lb_P.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_lb_P", "正限");
            lb_O.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_lb_O", "原点");
            lb_N.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_lb_N", "负限");
            lb_Alarm.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisManualControl_lb_Alarm", "报警");
        }
    }
}