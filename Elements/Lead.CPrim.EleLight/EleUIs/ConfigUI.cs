using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleLight
{
    public partial class ConfigUI : UserControl
    {
        private EleLightConfig _config;

        private EleLight _eleLight;

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

            if (string.IsNullOrEmpty(tbName.Text)) return;
            if (!string.IsNullOrEmpty(tbName.Text)) _eleLight.Name = tbName.Text;
            if (!string.IsNullOrEmpty(tbInfo.Text)) _eleLight.Info = tbInfo.Text;
            if (!string.IsNullOrEmpty(cmbType.Text))
                _eleLight.LightType = cmbType.Text == "Tricolour_Light"
                    ? EleLightType.Tricolour_Light
                    : EleLightType.Button_Light;
            if (!string.IsNullOrEmpty(tbDevName.Text)) _eleLight.DevName = tbDevName.Text;
            if (!string.IsNullOrEmpty(tbRed.Text)) _eleLight.RedAddress = double.Parse(tbRed.Text);
            if (!string.IsNullOrEmpty(tbGreen.Text)) _eleLight.GreenAddress = double.Parse(tbGreen.Text);
            if (!string.IsNullOrEmpty(tbYellow.Text)) _eleLight.YellowAddress = double.Parse(tbYellow.Text);
            if (!string.IsNullOrEmpty(tbBuzz.Text)) _eleLight.BuzzAddress = double.Parse(tbBuzz.Text);
            _eleLight.Enable = chkEnable.Checked;
            _eleLight.IsSimulateMode = chkSimulate.Checked;
            _eleLight.RedEnable = chkRedEnable.Checked;
            _eleLight.GreenEnable = chkGreenEnable.Checked;
            _eleLight.YellowEnable = chkYellowEnable.Checked;
            _eleLight.BuzzEnable = chkBuzzEnable.Checked;
        }

        private void btnSetBuzz_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleLight.ReadBuzz() == 0)
                {
                    if (!string.IsNullOrEmpty(tbBuzz.Text) && chkBuzzEnable.Checked) _eleLight.WriteBuzz(true);
                }
                else if (_eleLight.ReadBuzz() == 1)
                {
                    if (!string.IsNullOrEmpty(tbBuzz.Text) && chkBuzzEnable.Checked) _eleLight.WriteBuzz(false);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSetGreen_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleLight.ReadGreen() == 0)
                {
                    if (!string.IsNullOrEmpty(tbGreen.Text) && chkGreenEnable.Checked) _eleLight.WriteGreen(true);
                }
                else if (_eleLight.ReadGreen() == 1)
                {
                    if (!string.IsNullOrEmpty(tbGreen.Text) && chkGreenEnable.Checked) _eleLight.WriteGreen(false);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSetRed_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleLight.ReadRed() == 0)
                {
                    if (!string.IsNullOrEmpty(tbRed.Text) && chkRedEnable.Checked) _eleLight.WriteRed(true);
                }
                else if (_eleLight.ReadRed() == 1)
                {
                    if (!string.IsNullOrEmpty(tbRed.Text) && chkRedEnable.Checked) _eleLight.WriteRed(false);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSetYellow_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleLight.ReadYellow() == 0)
                {
                    if (!string.IsNullOrEmpty(tbYellow.Text) && chkYellowEnable.Checked) _eleLight.WriteYellow(true);
                }
                else if (_eleLight.ReadYellow() == 1)
                {
                    if (!string.IsNullOrEmpty(tbYellow.Text) && chkYellowEnable.Checked)
                        _eleLight.WriteYellow(false);
                }
            }
            catch (Exception)
            {
            }
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnable.Checked)
            {
                var prim = PrimsManagerTransfer.GetPrimByName(_eleLight.DevName);
                if (prim == null)
                    //MessageBox.Show(string.Format(NLocalizer.GetString("EleLight_ConfigUI_NotFoundDevice", "Device with Name： {0} not found! "), _eleLight.DevName));
                    return;
            }
        }

        private void chkSimulate_CheckedChanged(object sender, EventArgs e)
        {
            if (_eleLight == null) return;

            _eleLight.IsSimulateMode = chkSimulate.Checked;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.Text == "Button_Light")
            {
                tbBuzz.ReadOnly = true;
                chkBuzzEnable.Checked = false;
                chkBuzzEnable.Enabled = false;
                btnSetBuzz.Enabled = false;
            }
            else
            {
                tbBuzz.ReadOnly = false;
                chkBuzzEnable.Enabled = true;
                btnSetBuzz.Enabled = true;
            }
        }

        private void ConfigUI_Click(object sender, EventArgs e)
        {
            _eleLight.IsSelected = !_eleLight.IsSelected;
        }

        private void ConfigUI_Load(object sender, EventArgs e)
        {
            if (_eleLight.Enable)
                if (_eleLight.EleRunStat == EleRunState.Other)
                    _eleLight.IEleInit();
            //tmrUpdateLight.Start();
        }

        private void lbState_Click(object sender, EventArgs e)
        {
            if (_eleLight.EleRunStat == EleRunState.Other) _eleLight.IEleInit();

            if (_eleLight.EleRunStat == EleRunState.Err) _eleLight.IEleReset();
        }

        private void tmrBtnYellow_Tick(object sender, EventArgs e)
        {
            //_eleLight.WriteYellow(true);
            //Thread.Sleep(1000);
            //_eleLight.WriteYellow(false);
        }

        private void tmrBuzz_Tick(object sender, EventArgs e)
        {
            if (_eleLight.ReadBuzz() == 1)
                _eleLight.WriteBuzz(false);
            else if (_eleLight.ReadBuzz() == 0) _eleLight.WriteBuzz(true);
        }

        private void tmrLightUpdate_Tick(object sender, EventArgs e)
        {
            if (_eleLight == null || !_eleLight.IsSimulateMode) return;

            if (_eleLight.EleRunStat == EleRunState.Other) _eleLight.IEleInit();

            SetEleRunState(_eleLight.EleRunStat);
            if (_eleLight.EleRunStat == EleRunState.Running)
            {
                tbDevName.BackColor = Color.LawnGreen;
            }
            else
            {
                tbDevName.BackColor = SystemColors.GradientActiveCaption;
                return;
            }

            if (_eleLight.ReadYellow() == 0)
                btnSetYellow.Text = "置位";
            else if (_eleLight.ReadYellow() == 1) btnSetYellow.Text = "复位";
            if (_eleLight.ReadGreen() == 0)
                btnSetGreen.Text = "置位";
            else if (_eleLight.ReadGreen() == 1) btnSetGreen.Text = "复位";
            if (_eleLight.ReadRed() == 0)
                btnSetRed.Text = "置位";
            else if (_eleLight.ReadRed() == 1) btnSetRed.Text = "复位";
            if (_eleLight.ReadBuzz() == 0)
                btnSetBuzz.Text = "置位";
            else if (_eleLight.ReadBuzz() == 1) btnSetBuzz.Text = "复位";
            var val = -1;

            if (chkRedEnable.Checked)
            {
                val = -1;
                val = _eleLight.ReadRed();
                if (val != -1)
                    tbRed.BackColor = val == 0
                        ? SystemColors.GradientActiveCaption
                        : Color.LawnGreen;
            }

            if (chkGreenEnable.Checked)
            {
                val = -1;
                val = _eleLight.ReadGreen();
                if (val != -1)
                    tbGreen.BackColor = val == 0
                        ? SystemColors.GradientActiveCaption
                        : Color.LawnGreen;
            }

            if (chkYellowEnable.Checked)
            {
                val = -1;
                val = _eleLight.ReadYellow();
                if (val != -1)
                    tbYellow.BackColor = val == 0
                        ? SystemColors.GradientActiveCaption
                        : Color.LawnGreen;
            }

            if (chkBuzzEnable.Checked)
            {
                val = -1;
                val = _eleLight.ReadBuzz();
                if (val != -1)
                    tbBuzz.BackColor = val == 0
                        ? SystemColors.GradientActiveCaption
                        : Color.LawnGreen;
            }
        }

        internal void SetManualEnable(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetManualEnable), value);
            }
            else
            {
                btnSetBuzz.Enabled = value;
                btnSetGreen.Enabled = value;
                btnSetRed.Enabled = value;
                btnSetYellow.Enabled = value;
            }
        }

        private void tmrYellow_Tick(object sender, EventArgs e)
        {
            if (_eleLight.ReadYellow() == 1)
                _eleLight.WriteYellow(false);
            else if (_eleLight.ReadYellow() == 0) _eleLight.WriteYellow(true);
        }

        public new void Dispose()
        {
            if (tmrUpdateLight != null) tmrUpdateLight.Dispose();
            if (tmrBtnYellow != null) tmrBtnYellow.Dispose();
            if (tmrBuzz != null) tmrBuzz.Dispose();
            if (tmrYellow != null) tmrYellow.Dispose();
        }

        public void SetEleConfig(EleLight eleLight)
        {
            _eleLight = eleLight;
            chkEnable.Checked = _eleLight.Enable;
            tbDevName.Text = _eleLight.DevName;
            tbRed.Text = _eleLight.RedAddress.ToString("F2");
            tbGreen.Text = _eleLight.GreenAddress.ToString("F2");
            tbYellow.Text = _eleLight.YellowAddress.ToString("F2");
            tbBuzz.Text = _eleLight.BuzzAddress.ToString("F2");

            cmbType.Text = _eleLight.LightType == EleLightType.Tricolour_Light ? "Tricolour_Light" : "Button_Light";

            tbName.Text = _eleLight.Name;
            tbInfo.Text = _eleLight.Info;

            //cBoxAllEnable.Checked = _eleLight.Enable;
            chkSimulate.Checked = _eleLight.IsSimulateMode;

            chkRedEnable.Checked = _eleLight.RedEnable;
            chkGreenEnable.Checked = _eleLight.GreenEnable;
            chkYellowEnable.Checked = _eleLight.YellowEnable;
            chkBuzzEnable.Checked = _eleLight.BuzzEnable;
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

        public void SetSimulateMode(bool simulate)
        {
            if (tbState.InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetSimulateMode), simulate);
            }
            else
            {
                chkSimulate.Checked = simulate;
            }
        }

        public void Stop()
        {
            if (tmrUpdateLight != null) tmrUpdateLight.Stop();
            if (tmrBtnYellow != null) tmrBtnYellow.Stop();
            if (tmrBuzz != null) tmrBuzz.Stop();
            if (tmrYellow != null) tmrYellow.Stop();
        }

        public void UiRefresh()
        {
            try
            {
                if (_eleLight == null) return;

                if (_eleLight.EleRunStat == EleRunState.Other) _eleLight.IEleInit();

                SetEleRunState(_eleLight.EleRunStat);
                if (_eleLight.EleRunStat == EleRunState.Running)
                {
                    tbDevName.BackColor = Color.LawnGreen;
                }
                else
                {
                    tbDevName.BackColor = SystemColors.GradientActiveCaption;
                    return;
                }

                if (_eleLight.ReadYellow() == 0)
                    btnSetYellow.Text = "置位";
                else if (_eleLight.ReadYellow() == 1) btnSetYellow.Text = "复位";
                if (_eleLight.ReadGreen() == 0)
                    btnSetGreen.Text = "置位";
                else if (_eleLight.ReadGreen() == 1) btnSetGreen.Text = "复位";
                if (_eleLight.ReadRed() == 0)
                    btnSetRed.Text = "置位";
                else if (_eleLight.ReadRed() == 1) btnSetRed.Text = "复位";
                if (_eleLight.ReadBuzz() == 0)
                    btnSetBuzz.Text = "置位";
                else if (_eleLight.ReadBuzz() == 1) btnSetBuzz.Text = "复位";
                var val = -1;

                if (chkRedEnable.Checked)
                {
                    val = -1;
                    val = _eleLight.ReadRed();
                    if (val != -1)
                        tbRed.BackColor = val == 0
                            ? SystemColors.GradientActiveCaption
                            : Color.LawnGreen;
                }

                if (chkGreenEnable.Checked)
                {
                    val = -1;
                    val = _eleLight.ReadGreen();
                    if (val != -1)
                        tbGreen.BackColor = val == 0
                            ? SystemColors.GradientActiveCaption
                            : Color.LawnGreen;
                }

                if (chkYellowEnable.Checked)
                {
                    val = -1;
                    val = _eleLight.ReadYellow();
                    if (val != -1)
                        tbYellow.BackColor = val == 0
                            ? SystemColors.GradientActiveCaption
                            : Color.LawnGreen;
                }

                if (chkBuzzEnable.Checked)
                {
                    val = -1;
                    val = _eleLight.ReadBuzz();
                    if (val != -1)
                        tbBuzz.BackColor = val == 0
                            ? SystemColors.GradientActiveCaption
                            : Color.LawnGreen;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
        }

        public void UpdataEleConfig(EleLightConfig Config)
        {
            _config = Config;

            chkEnable.Checked = _config.Enable;
            tbDevName.Text = _config.DevName;
            tbRed.Text = _eleLight.RedAddress.ToString("F2");
            tbGreen.Text = _eleLight.GreenAddress.ToString("F2");
            tbYellow.Text = _eleLight.YellowAddress.ToString("F2");
            tbBuzz.Text = _eleLight.BuzzAddress.ToString("F2");

            cmbType.Text = _eleLight.LightType == EleLightType.Tricolour_Light ? "Tricolour_Light" : "Button_Light";

            tbName.Text = _config.Name;
            tbInfo.Text = _config.Info;

            //cBoxAllEnable.Checked = _eleLight.Enable;
            chkSimulate.Checked = _eleLight.IsSimulateMode;

            chkRedEnable.Checked = _eleLight.RedEnable;
            chkGreenEnable.Checked = _eleLight.GreenEnable;
            chkYellowEnable.Checked = _eleLight.YellowEnable;
            chkBuzzEnable.Checked = _eleLight.BuzzEnable;
        }

        public void OnLanguageChanged()
        {
            lbName.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Name", "名称");
            lbInfo.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Info", "信息");
            lbState.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_State", "状态");
            chkEnable.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Enable", "使能");
            lbType.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Type", "指示灯类型");
            lbDevName.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_DevName", "设备名称");
            lbRed.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Light_Red", "红灯");
            lb_Green.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Light_Grren", "绿灯");
            lb_Yellow.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Light_Yellow", "黄灯");
            lb_Buzzer.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Buzzer", "蜂鸣器");
            btnConfigApply.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Apply", "应用");
            chkRedEnable.Text = chkGreenEnable.Text = chkYellowEnable.Text = chkBuzzEnable.Text = chkEnable.Text;
            btnSetRed.Text = btnSetGreen.Text = btnSetYellow.Text = btnSetBuzz.Text = NLocalizer.GetString("Lead_CPrim_EleLight_ConfigUI_Set", "设置");
        }
    }
}