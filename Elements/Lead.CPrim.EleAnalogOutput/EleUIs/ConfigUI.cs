using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleAnalogOutput
{
    public partial class ConfigUI : UserControl
    {
        public EleAnalogOutputConfig _config;

        public IEle _ele;
        public EleAnalogOutput _eleAnalog;

        public ConfigUI()
        {
            InitializeComponent();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        private void btnConfigApply_Click(object sender, EventArgs e)
        {
            if (!AuthorityManager.Instance.VerifyLevel2Permission(true))
            {
                return;
            }

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

        private void ConfigUI_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            if (PrimsManagerTransfer.GetAllIPrim().Count > 0)
            {
                cmbPrim.Items.Clear();
                PrimsManagerTransfer.GetAllIPrim().ForEach(p => cmbPrim.Items.Add(p.Name));
                if (_eleAnalog.DevName != null)
                    cmbPrim.Text = _eleAnalog.DevName;
                else
                    cmbPrim.Text = cmbPrim.Items[1].ToString();

                if (_eleAnalog.EleRunStat == EleRunState.Other) _eleAnalog.IEleInit();
            }
        }

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

        public void Stop()
        {
        }

        public void SetEleConfig(EleAnalogOutput eleAnalog)
        {
            _eleAnalog = eleAnalog;
            cmbPrim.Text = _eleAnalog.DevName;
            tbAddress.Text = _eleAnalog.Address;

            cmbType.Text = _eleAnalog.EleTypeName;

            tbName.Text = _eleAnalog.Name;
            tbInfo.Text = _eleAnalog.Info;

            chkEnable.Checked = _eleAnalog.Enable;
            chkSimulate.Checked = _eleAnalog.IsSimulateMode;
        }

        public void UpdataEleConfig(EleAnalogOutputConfig Config)
        {
            _config = Config;

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
            tBoxSetValue.Text = _config.SetValue.ToString();
            if (_config.AnalogType == EleAnalogType.Voltage)
            {
            }
            else if (_config.AnalogType == EleAnalogType.Electricity)
            {
            }
        }

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

                cmbPrim.BackColor = _eleAnalog.EleRunStat == EleRunState.Running
                    ? Color.LawnGreen
                    : SystemColors.GradientActiveCaption;
                tBoxSetValue.Text = _eleAnalog.SetValue.ToString("0.000");
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            float result = 0;
            var flag = float.TryParse(tBoxSetValue.Text, out result);
            if (!flag)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_ErrMsg_InputValueIsError", "输入内容有误,请重新输入!"));
                return;
            }

            try
            {
                _eleAnalog.SetValue = result;
                _eleAnalog.Write(float.Parse(tBoxSetValue.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            _eleAnalog.IsSelected = !_eleAnalog.IsSelected;
        }

        private void LbState_Click(object sender, EventArgs e)
        {
            if (_eleAnalog.EleRunStat == EleRunState.Other) _eleAnalog.IEleInit();
            if (_eleAnalog.EleRunStat == EleRunState.Err) _eleAnalog.IEleReset();
        }

        private void cBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnSet_Click_1(object sender, EventArgs e)
        {

        }

        public void OnLanguageChanged()
        {
            lbName.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_Name", "名称");
            lbInfo.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_Info", "信息");
            lbState.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_State", "状态");
            chkEnable.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_Enable", "使能");
            chkSimulate.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_Simulate", "模拟");
            lbDevName.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_DevName", "设备名称");
            lbType.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_Type", "类型");
            lb_Address.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_Address", "通道地址");
            lb_ActMin.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_ActMin", "数字量最小值");
            lb_ActMax.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_ActMax", "数字量最大值");
            lb_LimitMin.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_LimitMin", "数字量下限");
            lb_LimitMax.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_LimitMax", "数字量上限");
            lb_FeedBackMin.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_FeedBackMin", "模拟量最小值");
            lb_FeedBackMax.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_FeedBackMax", "模拟量最大值");
            lb_SetValue.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_SetValue", "设定值");
            btnSet.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_Set", "写入");
            btnConfigApply.Text = NLocalizer.GetString("Lead_CPrim_EleAnalogOutput_ConfigUI_ConfigApply", "应用");

        }
    }
}