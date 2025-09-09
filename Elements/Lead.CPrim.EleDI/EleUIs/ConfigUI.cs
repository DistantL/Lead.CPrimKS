using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleDI
{
    public partial class ConfigUI : UserControl
    {
        private EleDIConfig _config;

        private IEle _ele;
        private EleDI _eleDI;

        public ConfigUI(EleDI ele)
        {
            InitializeComponent();
            InitializeUI();
            _ele = ele;
        }

        private void btnConfigApply_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.VerifyLevel1Permission())
            {
                return;
            }

            if (string.IsNullOrEmpty(tBoxName.Text)) return;

            if (!string.IsNullOrEmpty(tBoxDevName.Text)) _eleDI.DevName = tBoxDevName.Text;

            if (!string.IsNullOrEmpty(tBoxName.Text)) _eleDI.Name = tBoxName.Text;

            if (!string.IsNullOrEmpty(tBoxInfo.Text)) _eleDI.Info = tBoxInfo.Text;

            if (!string.IsNullOrEmpty(comBoxType.Text))
            {
                if (comBoxType.Text == "NO")
                    _eleDI.DiType = EleDIType.NO;
                else if (comBoxType.Text == "NC") _eleDI.DiType = EleDIType.NC;
            }

            if (!string.IsNullOrEmpty(tBoxDiAddress.Text)) _eleDI.DiAddress = double.Parse(tBoxDiAddress.Text);

            _eleDI.DiEnable = cBoxDIEnable.Checked;
            _eleDI.Enable = cBoxEnable.Checked;
            _eleDI.IsSimulateMode = cBoxSimulate.Checked;
            _eleDI.EnRiseEvent = chbRise.Checked;
            _eleDI.EnFallEvent = chbFall.Checked;

            _eleDI.DiRegisterEvent();
        }

        private void cBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            _eleDI.Enable = cBoxEnable.Checked;
            if (cBoxEnable.Checked)
            {
                var val = _eleDI.IEleInit();
                if (val == -1) return;
                //tmrUpdateSensor.Start();
            }
        }

        private void cBoxEnable_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cBoxEnable.Checked)
            {
                var prim = PrimsManagerTransfer.GetPrimByName(_eleDI.DevName);
                if (prim == null)
                    //MessageBox.Show(string.Format(NLocalizer.GetString("EleDI_ConfigUI_NotFoundDevice", "Device with Name：{0} not found! "), _eleDI.DevName));
                    return;
            }
        }

        private void cBoxSimulate_CheckedChanged(object sender, EventArgs e)
        {
            if (_eleDI == null) return;

            _eleDI.IsSimulateMode = cBoxSimulate.Checked;
        }

        private void ConfigUI_Click(object sender, EventArgs e)
        {
            _eleDI.IsSelected = !_eleDI.IsSelected;
        }

        private void ConfigUI_Load(object sender, EventArgs e)
        {
            if (_eleDI.Enable)
                if (_eleDI.EleRunStat == EleRunState.Other)
                    _eleDI.IEleInit();
            //tmrUpdateSensor.Start();
        }

        private void InitializeUI()
        {
            lbName.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_Name", "Name");
            lbInfo.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_Info", "Info");
            lbState.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_State", "State");
            cBoxEnable.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_Enable", "Enable");
            cBoxSimulate.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_Simulate", "Simulate");

            lbType.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_Type", "Type");
            lbDevName.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_DevName", "DevName");
            lbDI.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_DI", "DI");
            cBoxDIEnable.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_DIEnable", "Enable");
            btnConfigApply.Text = ProxyTools.NLocalizer.GetString("EleDI_ConfigUI_Apply", "Apply");
        }

        private void lbState_Click(object sender, EventArgs e)
        {
            if (_eleDI.EleRunStat == EleRunState.Other) _eleDI.IEleInit();
            if (_eleDI.EleRunStat == EleRunState.Err) _eleDI.IEleReset();
        }

        private void tmrSensorUpdate_Tick(object sender, EventArgs e)
        {
            if (_eleDI == null) return;

            if (_eleDI.EleRunStat == EleRunState.Other)
            {
                _eleDI.IEleInit();
                return;
            }

            if (_eleDI.EleRunStat == EleRunState.Running)
            {
                tBoxDevName.BackColor = Color.LawnGreen;
            }
            else
            {
                tBoxDevName.BackColor = SystemColors.GradientActiveCaption;
                return;
            }

            if (cBoxDIEnable.Checked)
                tBoxDiAddress.BackColor = _eleDI.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;
        }

        public new void Dispose()
        {
            if (tmrUpdateSensor != null)
            {
                //tmrUpdateSensor.Dispose();
            }
        }

        public void SetEleConfig(EleDI eleDi)
        {
            _eleDI = eleDi;
            tBoxDevName.Text = _eleDI.DevName;
            tBoxDiAddress.Text = _eleDI.DiAddress.ToString("F2");

            comBoxType.Text = _eleDI.DiType.ToString();

            tBoxName.Text = _eleDI.Name;
            tBoxInfo.Text = _eleDI.Info;

            cBoxDIEnable.Checked = _eleDI.DiEnable;
            cBoxEnable.Checked = _eleDI.Enable;
            cBoxSimulate.Checked = _eleDI.IsSimulateMode;
            chbRise.Checked = _eleDI.EnRiseEvent;
            chbFall.Checked = _eleDI.EnFallEvent;
        }

        public void SetEleRunState(EleRunState state)
        {
            if (tBoxState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdateEleRunState(SetEleRunState);
                Invoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case EleRunState.Idle:
                        tBoxState.BackColor = Color.Khaki;
                        tBoxState.Text = "Idle";
                        break;

                    case EleRunState.Running:
                        tBoxState.BackColor = Color.LightGreen;
                        tBoxState.Text = "Running";
                        break;

                    case EleRunState.Err:
                        tBoxState.BackColor = Color.SandyBrown;
                        tBoxState.Text = "Err";
                        break;

                    case EleRunState.Other:
                        tBoxState.BackColor = Color.Khaki;
                        tBoxState.Text = "Other";
                        break;
                }
            }
        }

        public void SetSimulateMode(bool simulate)
        {
            if (tBoxState.InvokeRequired)
            {
                var update = new UpdateEleSimulateMode(SetSimulateMode);
                BeginInvoke(update, simulate);
            }
            else
            {
                cBoxSimulate.Checked = simulate;
            }
        }

        public void Stop()
        {
            if (tmrUpdateSensor != null)
            {
                //tmrUpdateSensor.Stop();
            }
        }

        public void UiRefresh()
        {
            if (_eleDI == null) return;

            if (InvokeRequired)
            {
                UpdateControl update = UiRefresh;
                BeginInvoke(update);
            }
            else
            {
                if (_eleDI.EleRunStat == EleRunState.Other)
                {
                    _eleDI.IEleInit();
                    return;
                }

                if (_eleDI.EleRunStat == EleRunState.Running)
                {
                    tBoxDevName.BackColor = Color.LawnGreen;
                }
                else
                {
                    tBoxDevName.BackColor = SystemColors.GradientActiveCaption;
                    return;
                }

                if (_eleDI.DiEnable)
                    tBoxDiAddress.BackColor = _eleDI.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;
            }
        }

        public void UpdataEleConfig(EleDIConfig Config)
        {
            _config = Config;

            tBoxDevName.Text = _config.DevName;
            tBoxDiAddress.Text = _config.DiAddress.ToString("F2");
            comBoxType.Text = _config.DiType.ToString();

            tBoxName.Text = _config.Name;
            tBoxInfo.Text = _config.Info;

            cBoxDIEnable.Checked = _config.DiEnable;
            cBoxEnable.Checked = _config.Enable;
            cBoxSimulate.Checked = _config.IsSimulateMode;
            chbRise.Checked = _config.EnRiseEvent;
            chbFall.Checked = _config.EnFallEvent;
        }

        private delegate void UpdateControl();

        private delegate void UpdateEleRunState(EleRunState state);

        private delegate void UpdateEleSimulateMode(bool simulate);
    }
}