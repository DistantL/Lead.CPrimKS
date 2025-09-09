using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleAnalogInput
{
    public partial class ConfigUI : UserControl
    {
        #region Field
        /// <summary>模拟量输入模块配置</summary>
        public EleAnalogInputConfig _config;
        /// <summary>元件公共接口</summary>
        public IEle _ele;
        /// <summary>模拟量输入模块管理器</summary>
        public EleAnalogInput _eleAnalog; 
        #endregion


        #region Ctor
        /// <summary>Ctor无参</summary>
        public ConfigUI()
        {
            InitializeComponent();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion


        #region System_Event
        /// <summary>Load事件</summary>
        private void ConfigUI_Load(object sender, EventArgs e)
        {
            if (PrimsManagerTransfer.GetAllIPrim().Count > 0)
            {
                cmbPrim.Items.Clear();
                PrimsManagerTransfer.GetAllIPrim().ForEach(p => cmbPrim.Items.Add(p.Name));
                if (_eleAnalog.DevName != null)
                {
                    cmbPrim.Text = _eleAnalog.DevName;
                }
                else
                {
                    cmbPrim.Text = cmbPrim.Items[1].ToString();
                }

                if (_eleAnalog.EleRunStat == EleRunState.Other) _eleAnalog.IEleInit();
            }
            UpdataEleConfig(_config);
        }
        #endregion


        #region Button_Event
        /// <summary>应用</summary>
        private void btnConfigApply_Click(object sender, EventArgs e)
        {
            if (!AuthorityManager.Instance.VerifyLevel2Permission(true))
                return;

            _eleAnalog.Enable = chkEnable.Checked;
            _eleAnalog.IsSimulateMode = chkSimulate.Checked;
            if (!string.IsNullOrEmpty(tbName.Text)) _eleAnalog.Name = tbName.Text;
            if (!string.IsNullOrEmpty(tbInfo.Text)) _eleAnalog.Info = tbInfo.Text;
            if (!string.IsNullOrEmpty(tbAddress.Text)) _eleAnalog.Address = tbAddress.Text;
            if (!string.IsNullOrEmpty(cmbPrim.Text)) _eleAnalog.DevName = cmbPrim.Text;
            if (!string.IsNullOrEmpty(tbActMin.Text)) _eleAnalog.ActMin = float.Parse(tbActMin.Text);
            if (!string.IsNullOrEmpty(tbActMax.Text)) _eleAnalog.ActMax = float.Parse(tbActMax.Text);
            if (!string.IsNullOrEmpty(tbLimitMin.Text)) _eleAnalog.LimitMin = float.Parse(tbLimitMin.Text);
            if (!string.IsNullOrEmpty(tbLimitMax.Text)) _eleAnalog.LimitMax = float.Parse(tbLimitMax.Text);
            if (!string.IsNullOrEmpty(tbFeedBackMin.Text)) _eleAnalog.FeedBackMin = float.Parse(tbFeedBackMin.Text);
            if (!string.IsNullOrEmpty(tbFeedBackMax.Text)) _eleAnalog.FeedBackMax = float.Parse(tbFeedBackMax.Text);
            if (cmbType.Text == "Voltage(V)")
                _eleAnalog.EleType = EleAnalogType.Voltage;
            else
                _eleAnalog.EleType = EleAnalogType.Electricity;
        }
        #endregion

       
        /// <summary>刷新当前状态</summary>
        private void LbState_Click(object sender, EventArgs e)
        {
            if (_eleAnalog.EleRunStat == EleRunState.Other) _eleAnalog.IEleInit();
            if (_eleAnalog.EleRunStat == EleRunState.Err) _eleAnalog.IEleReset();
        }
        /// <summary>当前界面被选择</summary>
        private void panel1_Click(object sender, EventArgs e)
        {
            _eleAnalog.IsSelected = !_eleAnalog.IsSelected;
        }

        #region 界面更新
        /// <summary>界面更新（界面所有信息）</summary>
        /// <param name="Config"></param>
        public void UpdataEleConfig(EleAnalogInputConfig Config)
        {
            _config = Config;

            //if (!Created || !IsHandleCreated)
            //    return;

            if(InvokeRequired)
            {
                BeginInvoke(new Action<EleAnalogInputConfig>(UpdataEleConfig), Config);
                return;
            }
            tbName.Text = _config.Name;
            tbInfo.Text = _config.Info;
            chkSimulate.Checked = _config.IsSimulateMode;
            chkEnable.Checked = _config.Enable;
            cmbType.Text = _config.EleTypeName;
            cmbPrim.Text = _config.DevName;
            tbAddress.Text = _config.Address;
            tbActMin.Text = _config.ActMin.ToString();
            tbActMax.Text = _config.ActMax.ToString();
            tbLimitMin.Text = _config.LimitMin.ToString();
            tbLimitMax.Text = _config.LimitMax.ToString();
            tbFeedBackMin.Text = _config.FeedBackMin.ToString();
            tbFeedBackMax.Text = _config.FeedBackMax.ToString();
            if (_config.AnalogType == EleAnalogType.Voltage)
                cmbType.SelectedIndex = 0;
            else if (_config.AnalogType == EleAnalogType.Electricity)
                cmbType.SelectedIndex = 1;
        }
        /// <summary>界面更新（构造函数调用）</summary>
        /// <param name="eleAnalog"></param>
        public void SetEleConfig(EleAnalogInput eleAnalog)
        {
            _eleAnalog = eleAnalog;
            _config = eleAnalog._config;

            if (InvokeRequired)
            {
                BeginInvoke(new Action<EleAnalogInput>(SetEleConfig), eleAnalog);
                return;
            }
            cmbPrim.Text = _eleAnalog.DevName;
            tbAddress.Text = _eleAnalog.Address;

            cmbType.Text = _eleAnalog.EleTypeName;

            tbName.Text = _eleAnalog.Name;
            tbInfo.Text = _eleAnalog.Info;

            chkEnable.Checked = _eleAnalog.Enable;
            chkSimulate.Checked = _eleAnalog.IsSimulateMode;
        }
        /// <summary>界面更新（实时模拟量/实时数字量刷新）</summary>
        public void UiRefresh()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UiRefresh));
            }
            else
            {
                if (_eleAnalog == null || _config == null) return;
                if (_eleAnalog.EleRunStat == EleRunState.Other)
                {
                    _eleAnalog.IEleInit();
                    return;
                }

                cmbPrim.BackColor = _eleAnalog.EleRunStat == EleRunState.Running ? Color.LawnGreen : SystemColors.GradientActiveCaption;
                tbActFeedBack.Text = _eleAnalog.ActFeedBack.ToString("0.000");
                tbActValue.Text = _eleAnalog.ActValue.ToString("0.000");
            }
        }
        /// <summary>界面更新（输入模拟量状态刷新）</summary>
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
                        tbState.Text = "Idle";
                        break;

                    case EleRunState.Running:
                        tbState.BackColor = Color.LightGreen;
                        tbState.Text = "Running";
                        break;

                    case EleRunState.Err:
                        tbState.BackColor = Color.SandyBrown;
                        tbState.Text = "Err";
                        break;

                    case EleRunState.Other:
                        tbState.BackColor = Color.Khaki;
                        tbState.Text = "Other";
                        break;
                }
            }
        }
        #endregion


        #region Other
        /// <summary>模拟量停止</summary>
        public void Stop()
        {
        }
        #endregion Other

        public void OnLanguageChanged()
        {
            lbName.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_Name", "名称");
            lbInfo.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_Info", "信息");
            lbState.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_State", "状态");
            chkEnable.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_Enable", "使能");
            chkSimulate.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_Simulate", "模拟");
            lbDevName.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_DevName", "设备名称");
            lbType.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_Type", "类型");
            lbAddress.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_Address", "通道地址");
            lbActMin.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_ActMin", "数字量最小值");
            lbActMax.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_ActMax", "数字量最大值");
            lbLimitMin.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_LimitMin", "数字量下限");
            lbLimitMax.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_LimitMax", "数字量上限");
            lbFeedBackMin.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_FeedBackMin", "模拟量最小值");
            lbFeedBackMax.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_FeedBackMax", "模拟量最大值");
            lbActFeedBack.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_ActFeedBack", "实时模拟量");
            lbActValue.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_ActValue", "实时数字量");
            btnConfigApply.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogInput_ConfigUI_ConfigApply", "应用");
        }
    }
}