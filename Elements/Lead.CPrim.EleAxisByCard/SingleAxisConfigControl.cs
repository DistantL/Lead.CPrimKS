using Lead.CPrim.Global;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.EleAxisByCard
{
    /// <summary>元件配置_轴组_配置UI</summary>
    public partial class SingleAxisConfigControl : UserControl
    {
        #region Field
        /// <summary>轴接口【IEleAxis】对接用户</summary>
        private IEleAxis _axis;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public SingleAxisConfigControl()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="axis"></param>
        public SingleAxisConfigControl(IEleAxis axis)
        {
            InitializeComponent();
            _axis = axis;
            UpdateControls();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Button_Event
        /// <summary>基元名单击</summary>
        private void lbDevName_Click(object sender, EventArgs e)
        {
            if (PrimsManagerTransfer.GetAllIPrim().Count < 1)
            {
                return;
            }

            cmbDevName.SelectedIndex = -1;
            cmbDevName.Items.Clear();

            var prims = PrimsManagerTransfer.GetAllIPrim().FindAll(p => p is IMotionCard);
            var all = prims.All(p => cmbDevName.Items.Add(p.Name) != -1);
        }
        /// <summary>基元名双击</summary>
        private void LbDevName_DoubleClick(object sender, EventArgs e)
        {
            _axis.FindPrim();
        }
        /// <summary>基元类型切换</summary>
        private void cmbByType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbByType.SelectedItem.ToString() != _axis.DeviceType.ToString())
            {
                _axis.UpdateAxisByType((ByType)Enum.Parse(typeof(ByType), cmbByType.SelectedItem.ToString()));
            }
        }
        /// <summary>基元名切换</summary>
        private void cbDevName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDevName.Items.Count <= 0)
            {
                lbDevName_Click(null, null);
            }
        }
        /// <summary>轴名称更新</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxName_TextChanged(object sender, EventArgs e)
        {
            grpAxisName.Text = tbName.Text;
            _axis.UpdateAxisName(tbName.Text);
        }
        /// <summary>右键选择</summary>
        private void mnutConfigUiSelected_DoubleClick(object sender, EventArgs e)
        {
            _axis.IsSelected = !_axis.IsSelected;
            mnutConfigUiSelected.Text = _axis.IsSelected
                ? NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_NoSelect", "取消选择")
                : NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Select", "选择");
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>更新元件配置</summary>
        /// <param name="axis"></param>
        public void UpdateAxisAndControls(IEleAxis axis)
        {
            _axis = axis;
            UpdateControls();
        }
        /// <summary>保存</summary>
        /// <returns></returns>
        public IEleAxis ConfigsSave()
        {
            _axis.Name = !string.IsNullOrEmpty(tbName.Text) 
                ? tbName.Text.Trim() 
                : throw new Exception(NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_AxisNameIsEmpty", "轴的名称不能为空"));

            var err = string.Format(
                NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_AxisSettingError", "轴[{0}]配置错误:"), tbName.Text);

            string tempName = tbName.Text.ToLower();
            if (!tempName.Contains("_x") && !tempName.Contains("_y") && !tempName.Contains("_z") && !tempName.Contains("_u") && !tempName.Contains("_v") && !tempName.Contains("_w"))
            {
                throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_AxisNameRuleError", "轴的名称命名规则有误，必须以(_X|_Y|_Z|_U|_V|_W)结尾"));
            }

            if (cmbByType.SelectedItem == null || string.IsNullOrEmpty(cmbByType.SelectedItem.ToString()))
            {
                throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_PrimTypeIsEmpty", "基元类型为空"));
            }
            switch (cmbByType.SelectedItem)
            {
                case "MotionCard":
                    _axis.DeviceType = ByType.MotionCard;
                    break;
                default:
                    _axis.DeviceType = ByType.MotionCard;
                    break;
            }

            if (cmbDevName.SelectedItem == null || string.IsNullOrEmpty(cmbDevName.SelectedItem.ToString()))
            {
                throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_PrimNameIsEmpty", "基元名为空"));
            }
            else
            {
                _axis.DevName = cmbDevName.SelectedItem.ToString();
                var prim = PrimsManagerTransfer.GetPrimByName(cmbDevName.SelectedItem.ToString());
                if (prim == null)
                {
                    throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_PrimNameNoFind", "未找到基元名:") + cmbDevName.SelectedItem);
                }
                _axis.DevName = prim.Name;
            }

            _axis.Id = (!string.IsNullOrEmpty(tbId.Text) && int.TryParse(tbId.Text, out var id)) ? id 
                : throw new Exception(string.Format(
                    NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_AxisIdError", "轴Id = {0} => int 失败")
                    , tbId.Text));

            if (cmbVelMode.SelectedItem == null || string.IsNullOrEmpty(cmbVelMode.SelectedItem.ToString()))
            {
                throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_SpeedModeIsEmpty", "速度模式为空"));
            }
            switch (cmbVelMode.SelectedItem)
            {
                case "Time":
                    _axis.VelMode = AccDecType.Time;
                    break;
                case "Velocity":
                    _axis.VelMode = AccDecType.Velocity;
                    break;
                default:
                    _axis.VelMode = AccDecType.Velocity;
                    break;
            }

            if (cmbDriveType.SelectedItem == null || string.IsNullOrEmpty(cmbDriveType.SelectedItem.ToString()))
            {
                throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_DriveTypeIsEmpty", "驱动类型为空"));
            }
            switch (cmbDriveType.SelectedItem)
            {
                case "Servo":
                    _axis.DriveType = AxisType.Servo;
                    break;
                case "Step":
                    _axis.DriveType = AxisType.Step;
                    break;
                default:
                    _axis.DriveType = AxisType.Other;
                    break;
            }

            if (cmbControlType.SelectedItem == null || string.IsNullOrEmpty(cmbControlType.SelectedItem.ToString()))
            {
                throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_ControlTypeIsEmpty", "控制类型为空"));
            }
            switch (cmbControlType.SelectedItem)
            {
                case "ClosedLoop":
                    _axis.ControlType = ControlType.ClosedLoop;
                    break;
                case "OpendLoop":
                    _axis.ControlType = ControlType.OpendLoop;
                    break;
                default:
                    _axis.ControlType = ControlType.Other;
                    break;
            }

            if (cmbFeedBackType.SelectedItem == null || string.IsNullOrEmpty(cmbFeedBackType.SelectedItem.ToString()))
            {
                throw new Exception(err + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrMsg_FeedBackTypeIsEmpty", "反馈类型为空"));
            }
            switch (cmbFeedBackType.SelectedItem)
            {
                case "Absolute":
                    _axis.FeedBackType = FeedBackType.Absolute;
                    break;
                case "Incremental":
                    _axis.FeedBackType = FeedBackType.Incremental;
                    break;
                default:
                    _axis.FeedBackType = FeedBackType.Other;
                    break;
            }

            _axis.Lead = (!string.IsNullOrEmpty(tbLead.Text) && double.TryParse(tbLead.Text, out var lead)) ? lead 
                : throw new Exception(err 
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Lead", "导程:") 
                + tbLead.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.PlsPerRoll = (!string.IsNullOrEmpty(tbPlsPerRoll.Text) && double.TryParse(tbPlsPerRoll.Text, out var pls)) ? pls
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_PlsPerRoll", "每转脉冲数:")
                + tbPlsPerRoll.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.LimitVelP = (!string.IsNullOrEmpty(tbLimitVelP.Text) && double.TryParse(tbLimitVelP.Text, out var limitVelP)) ? limitVelP
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_LimitVelP", "正向速度限定:")
                + tbLimitVelP.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.LimitVelN = (!string.IsNullOrEmpty(tbLimitVelN.Text) && double.TryParse(tbLimitVelN.Text, out var limitVelN)) ? limitVelN
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_LimitVelN", "负向速度限定:")
                + tbLimitVelN.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.LimitPosP = (!string.IsNullOrEmpty(tbLimitPosP.Text) && double.TryParse(tbLimitPosP.Text, out var limitPosP)) ? limitPosP
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_LimitPosP", "正向位置限定:")
                + tbLimitPosP.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.LimitPosN = (!string.IsNullOrEmpty(tbLimitPosN.Text) && double.TryParse(tbLimitPosN.Text, out var limitPosN)) ? limitPosN
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_LimitPosN", "负向位置限定:")
                + tbLimitPosN.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.DefaultStartVel = (!string.IsNullOrEmpty(tbDefaultStartVel.Text) && double.TryParse(tbDefaultStartVel.Text, out var startVel)) ? startVel
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultStartVel", "起始速度:")
                + tbDefaultStartVel.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.DefaultMaxVel = (!string.IsNullOrEmpty(tbDefaultMaxVel.Text) && double.TryParse(tbDefaultMaxVel.Text, out var maxVel)) ? maxVel
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultMaxVel", "最大速度:")
                + tbDefaultMaxVel.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.DefaultStopVel = (!string.IsNullOrEmpty(tbDefaultStopVel.Text) && double.TryParse(tbDefaultStopVel.Text, out var stopVel)) ? stopVel
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultStopVel", "停止速度:")
                + tbDefaultStopVel.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            if (_axis.VelMode == AccDecType.Time)
            {
                _axis.DefaultAccTime = (!string.IsNullOrEmpty(tbDefaultAcc.Text) && double.TryParse(tbDefaultAcc.Text, out var accTime)) ? accTime
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultAccTime", "加速时间:")
                + tbDefaultAcc.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

                _axis.DefaultDecTime = (!string.IsNullOrEmpty(tbDefaultDec.Text) && double.TryParse(tbDefaultDec.Text, out var decTime)) ? decTime
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultDecTime", "减速时间:")
                + tbDefaultDec.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));
            }
            else
            {
                _axis.DefaultAcc = (!string.IsNullOrEmpty(tbDefaultAcc.Text) && double.TryParse(tbDefaultAcc.Text, out var acc)) ? acc
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultAcc", "加速度:")
                + tbDefaultAcc.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

                _axis.DefaultDec = (!string.IsNullOrEmpty(tbDefaultDec.Text) && double.TryParse(tbDefaultDec.Text, out var dec)) ? dec
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultDec", "减速度:")
                + tbDefaultDec.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));
            }

            _axis.ErrChkEnable = chkErrChkEnable.Checked;
            if (_axis.ErrChkEnable)
            {
                _axis.ErrChkRange = (!string.IsNullOrEmpty(tbErrChkRange.Text) && double.TryParse(tbErrChkRange.Text, out var tempErrChkRange)) ? tempErrChkRange
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrChkRange", "偏差检测范围:")
                + tbErrChkRange.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));
            }

            _axis.HomeMode = (!string.IsNullOrEmpty(tbHomeMode.Text) && int.TryParse(tbHomeMode.Text, out var homeMode)) ? homeMode
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeMode", "回零模式:")
                + tbHomeMode.Text
                + "int"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.HomeAcc = (!string.IsNullOrEmpty(tbHomeAcc.Text) && double.TryParse(tbHomeAcc.Text, out var homeAcc)) ? homeAcc
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeAcc", "回零加减速:")
                + tbHomeAcc.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.HomeVel = (!string.IsNullOrEmpty(tbHomeVel.Text) && double.TryParse(tbHomeVel.Text, out var homeVel)) ? homeVel
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeVel", "回零高速:")
                + tbHomeVel.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.HomeVo = (!string.IsNullOrEmpty(tbHomeVo.Text) && double.TryParse(tbHomeVo.Text, out var homeVo)) ? homeVo
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeVo", "回零低速:")
                + tbHomeVo.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.HomeIndex = (!string.IsNullOrEmpty(tbHomeIndex.Text) && int.TryParse(tbHomeIndex.Text, out var homeIndex)) ? homeIndex
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeIndex", "回零顺序:")
                + tbHomeIndex.Text
                + "int"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.SafePos = (!string.IsNullOrEmpty(tbSafePos.Text) && double.TryParse(tbSafePos.Text, out var safePos)) ? safePos
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_SafePos", "回零后安全位:")
                + tbSafePos.Text
                + "double"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.WaitIndex = (!string.IsNullOrEmpty(tbSafeIndex.Text) && int.TryParse(tbSafeIndex.Text, out var safeIndex)) ? safeIndex
                : throw new Exception(err
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_SafeIndex", "回安全位顺序:")
                + tbSafeIndex.Text
                + "int"
                + NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Fail", "失败"));

            _axis.Enable = chkEnable.Checked;
            _axis.Simulate = chkSimulate.Checked;

            return _axis;
        }
        /// <summary>被选择</summary>
        public void Selected()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(Selected));
            }
            else
            {
                this.BackColor = _axis.IsSelected ? Color.Green : SystemColors.Control;
            }
        }
        /// <summary>手动状态设置（未使用）</summary>
        /// <param name="value">true：手动；false：自动</param>
        internal void SetManualEnable(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetManualEnable), value);
                return;
            }
            grpAxisName.Enabled = value;
        }
        #endregion



        #region Others
        /// <summary>元件配置_轴组_配置UI更新</summary>
        private void UpdateControls()
        {
            lbDevName_Click(null, null);
            if (_axis == null) return;

            grpAxisName.Text = _axis.Name;

            //常用
            tbDefaultStartVel.Text = _axis.DefaultStartVel.ToString(CultureInfo.InvariantCulture);
            tbDefaultMaxVel.Text = _axis.DefaultMaxVel.ToString(CultureInfo.InvariantCulture);
            tbDefaultStopVel.Text = _axis.DefaultStopVel.ToString(CultureInfo.InvariantCulture);
            if (_axis.VelMode == AccDecType.Time)
            {
                lbDefaultAcc.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultAccTime", "加速时间:");
                lbDefaultDec.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultDecTime", "减速时间:");
                tbDefaultAcc.Text = _axis.DefaultAccTime.ToString(CultureInfo.InvariantCulture);
                tbDefaultDec.Text = _axis.DefaultDecTime.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                lbDefaultAcc.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultAcc", "加速度:");
                lbDefaultDec.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultDec", "减速度:");
                tbDefaultAcc.Text = _axis.DefaultAcc.ToString(CultureInfo.InvariantCulture);
                tbDefaultDec.Text = _axis.DefaultDec.ToString(CultureInfo.InvariantCulture);
            }
            chkErrChkEnable.Checked = _axis.ErrChkEnable;
            tbErrChkRange.Text = _axis.ErrChkRange.ToString(CultureInfo.InvariantCulture);
            tbHomeMode.Text = _axis.HomeMode.ToString(CultureInfo.InvariantCulture);
            tbHomeAcc.Text = _axis.HomeAcc.ToString(CultureInfo.InvariantCulture);
            tbHomeVel.Text = _axis.HomeVel.ToString(CultureInfo.InvariantCulture);
            tbHomeVo.Text = _axis.HomeVo.ToString(CultureInfo.InvariantCulture);
            tbHomeIndex.Text = _axis.HomeIndex.ToString();
            tbSafePos.Text = _axis.SafePos.ToString(CultureInfo.InvariantCulture);
            tbSafeIndex.Text = _axis.WaitIndex.ToString();
            chkEnable.Checked = _axis.Enable;
            chkSimulate.Checked = _axis.Simulate;


            //轴配置
            tbName.Text = _axis.Name;
            if (!cmbByType.Items.Contains(_axis.DeviceType.ToString()))
                cmbByType.Items.Add(_axis.DeviceType.ToString());
            cmbByType.SelectedItem = _axis.DeviceType.ToString();
            if (!cmbDevName.Items.Contains(_axis.DevName))
                cmbDevName.Items.Add(_axis.DevName);
            cmbDevName.SelectedItem = _axis.DevName;
            tbId.Text = _axis.Id.ToString();
            cmbVelMode.SelectedItem = _axis.VelMode.ToString();
            cmbDriveType.SelectedItem = _axis.DriveType.ToString();
            cmbControlType.SelectedItem = _axis.ControlType.ToString();
            cmbFeedBackType.SelectedItem = _axis.FeedBackType.ToString();
            tbLead.Text = _axis.Lead.ToString(CultureInfo.InvariantCulture);
            tbPlsPerRoll.Text = _axis.PlsPerRoll.ToString(CultureInfo.InvariantCulture);
            tbLimitVelP.Text = _axis.LimitVelP.ToString(CultureInfo.InvariantCulture);
            tbLimitVelN.Text = _axis.LimitVelN.ToString(CultureInfo.InvariantCulture);
            tbLimitPosP.Text = _axis.LimitPosP.ToString(CultureInfo.InvariantCulture);
            tbLimitPosN.Text = _axis.LimitPosN.ToString(CultureInfo.InvariantCulture);
        }
        #endregion

        public void OnLanguageChanged()
        {
            tabPage1.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Common", "常用");
            tabPage2.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_AxisSetting", "轴配置");
            groupBox1.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultSpeedParam", "默认速度参数");
            lb_DefaultStartVel.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultStartVel", "起始速度:");
            lb_DefaultMaxVel.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultMaxVel", "最大速度:");
            lb_DefaultStopVel.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultStopVel", "停止速度:");

            chkErrChkEnable.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ErrChkEnable", "偏差检测使能");
            groupBox2.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeParam", "回零参数");
            lb_HomeMode.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeMode", "回零模式:");
            lb_HomeAcc.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeAcc", "回零加减速:");
            lb_HomeVel.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeVel", "回零高速:");
            lb_HomeVo.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeVo", "回零低速:");
            lb_HomeIndex.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_HomeIndex", "回零顺序:");
            lb_SafePos.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_SafePos", "回零后安全位:");
            lb_SafeIndex.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_SafeIndex", "回安全位顺序:");
            chkEnable.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Enable", "使能");
            chkSimulate.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Simulate", "模拟");
            lb_Name.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_AxisName", "名称:");
            grpPrim.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Prim", "基元");
            lb_ByType.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ByType", "类型:");
            lbDevName.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DevName", "基元名:");
            lb_AxisId.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_AxisId", "轴Id:");
            lb_VelMode.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_VelMode", "速度模式:");
            grpDrive.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Drive", "驱动");
            lb_DriveType.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DriveType", "驱动类型:");
            lb_ControlType.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_ControlType", "控制类型:");
            lb_FeedBackType.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_FeedBackType", "反馈类型:");
            lb_Lead.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Lead", "导程:");
            lb_PlsPerRoll.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_PlsPerRoll", "每转脉冲数:");
            grpLimit.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_Limit", "限定");
            lb_LimitVelP.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_LimitVelP", "正向速度限定:");
            lb_LimitVelN.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_LimitVelN", "负向速度限定:");
            lb_LimitPosP.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_LimitPosP", "正向位置限定:");
            lb_LimitPosN.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_LimitPosN", "负向位置限定:");

            if (_axis.VelMode == AccDecType.Time)
            {
                lbDefaultAcc.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultAccTime", "加速时间:");
                lbDefaultDec.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultDecTime", "减速时间:");
            }
            else
            {
                lbDefaultAcc.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultAcc", "加速度:");
                lbDefaultDec.Text = NLocalizer.GetString("Lead_CPrim_EleAxisByCard_SingleAxisConfigControl_DefaultDec", "减速度:");
            }
        }
    }
}