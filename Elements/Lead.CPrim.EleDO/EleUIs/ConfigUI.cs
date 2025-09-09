using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleDO
{
    public partial class ConfigUI : UserControl
    {
        private EleDOConfig _config;

        private EleDO _eleDO;
        public string msg = "";

        public ConfigUI()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void btnConfigApply_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.VerifyLevel1Permission())
            {
                return;
            }

            if (string.IsNullOrEmpty(tBoxName.Text)) return;

            if (!string.IsNullOrEmpty(tBoxName.Text)) _eleDO.Name = tBoxName.Text;

            if (!string.IsNullOrEmpty(tBoxInfo.Text)) _eleDO.Info = tBoxInfo.Text;

            if (!string.IsNullOrEmpty(comBoxType.Text))
                _eleDO.DoType = comBoxType.Text == "NO" ? EleDOType.NO : EleDOType.NC;

            if (!string.IsNullOrEmpty(tBoxDoAddress.Text)) _eleDO.DoAddress = double.Parse(tBoxDoAddress.Text);

            if (!string.IsNullOrEmpty(tBoxDevName.Text)) _eleDO.DevName = tBoxDevName.Text;

            _eleDO.DoEnable = cBoxDOEnable.Checked;
            _eleDO.Enable = cBoxEnable.Checked;
            _eleDO.IsSimulateMode = cBoxSimulate.Checked;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleDO.Enable)
                {
                    if (!_eleDO.Read())
                    {
                        if (!string.IsNullOrEmpty(tBoxDoAddress.Text) && cBoxDOEnable.Checked) _eleDO.Write(true);
                    }
                    else if (_eleDO.Read())
                    {
                        if (!string.IsNullOrEmpty(tBoxDoAddress.Text) && cBoxDOEnable.Checked) _eleDO.Write(false);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void cBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            _eleDO.Enable = cBoxEnable.Checked;
            if (cBoxEnable.Checked)
            {
                var val = _eleDO.IEleInit();
                if (val == -1)
                {
                }

                //tmrUpdateLight.Start();
            }
        }

        private void cBoxEnable_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cBoxEnable.Checked)
            {
                var prim = PrimsManagerTransfer.GetPrimByName(_eleDO.DevName);
                if (prim == null)
                {
                    //MessageBox.Show(string.Format(NLocalizer.GetString("EleDO_ConfigUI_DeviceNotFound", "Device with Name：{0} not found! "), _eleDO.DevName));
                }
            }
        }

        private void cBoxSimulate_CheckedChanged(object sender, EventArgs e)
        {
            if (_eleDO == null) return;

            _eleDO.IsSimulateMode = cBoxSimulate.Checked;
        }

        private void ConfigUI_Click(object sender, EventArgs e)
        {
            _eleDO.IsSelected = !_eleDO.IsSelected;
        }

        private void ConfigUI_Load(object sender, EventArgs e)
        {
            if (_eleDO.Enable)
                if (_eleDO.EleRunStat == EleRunState.Other)
                    _eleDO.IEleInit();
            //tmrUpdateLight.Start();
        }

        private void InitializeUI()
        {
            lbName.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_Name", "Name");
            lbInfo.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_Info", "Info");
            lbState.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_State", "State");
            cBoxEnable.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_Enable", "Enable");
            cBoxSimulate.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_Simulate", "Simulate");

            lbType.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_Type", "Type");
            lbDevName.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_DevName", "DevName");
            lbDO.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_DO", "DO");
            cBoxDOEnable.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_DOEnable", "Enable");
            btnSet.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_Set", "Set");
            btnConfigApply.Text = ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_Apply", "Apply");
        }

        private void lbState_Click(object sender, EventArgs e)
        {
            if (_eleDO.EleRunStat == EleRunState.Other) _eleDO.IEleInit();

            if (_eleDO.EleRunStat == EleRunState.Err) _eleDO.IEleReset();
        }

        private void tmrLightUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_eleDO == null || !_eleDO.IsSimulateMode) return;

                if (_eleDO.EleRunStat == EleRunState.Other)
                {
                    _eleDO.IEleInit();
                    return;
                }

                if (_eleDO.EleRunStat == EleRunState.Running)
                    tBoxDevName.BackColor = Color.LawnGreen;
                else
                    tBoxDevName.BackColor = SystemColors.GradientActiveCaption;
                if (_eleDO.Read())
                {
                    btnSet.Tag = 1;
                    btnSet.Text = "Reset";
                }
                else if (!_eleDO.Read())
                {
                    btnSet.Tag = 0;
                    btnSet.Text = "Set";
                }

                if (cBoxDOEnable.Checked)
                    tBoxDoAddress.BackColor = _eleDO.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;
                else
                    tBoxDoAddress.ReadOnly = true;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public new void Dispose()
        {
            if (tmrUpdateLight != null)
            {
                //tmrUpdateLight.Dispose();
            }
        }

        public void SetEleConfig(EleDO eleDO)
        {
            _eleDO = eleDO;
            cBoxEnable.Checked = _eleDO.Enable;
            tBoxDevName.Text = _eleDO.DevName;
            tBoxDoAddress.Text = _eleDO.DoAddress.ToString("F2");

            comBoxType.Text = _eleDO.DoType == EleDOType.NO ? "NO" : "NC";

            tBoxName.Text = _eleDO.Name;
            tBoxInfo.Text = _eleDO.Info;

            cBoxDOEnable.Checked = _eleDO.DoEnable;
            cBoxSimulate.Checked = _eleDO.IsSimulateMode;
        }

        public void SetEleRunState(EleRunState state)
        {
            if (tBoxState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                UpdateEleRunState update = SetEleRunState;
                BeginInvoke(update, state);
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
                UpdateEleSimulateMode update = SetSimulateMode;
                BeginInvoke(update, simulate);
            }
            else
            {
                cBoxSimulate.Checked = simulate;
            }
        }

        public void Stop()
        {
            if (tmrUpdateLight != null)
            {
                //tmrUpdateLight.Stop();
            }
        }

        public void UiRefresh()
        {
            try
            {
                if (_eleDO == null) return;

                if (InvokeRequired)
                {
                    UpdateControl update = UiRefresh;
                    BeginInvoke(update);
                }
                else
                {
                    if (_eleDO.EleRunStat == EleRunState.Other)
                    {
                        _eleDO.IEleInit();
                        return;
                    }

                    tBoxDevName.BackColor = _eleDO.EleRunStat == EleRunState.Running
                        ? Color.LawnGreen
                        : SystemColors.GradientActiveCaption;

                    if (_eleDO.Read())
                    {
                        btnSet.Tag = 1;
                        btnSet.Text = "Reset";
                        tBoxDoAddress.BackColor = Color.LawnGreen;
                    }
                    else
                    {
                        btnSet.Tag = 0;
                        btnSet.Text = "Set";
                        tBoxDoAddress.BackColor = SystemColors.GradientActiveCaption;
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public void UpdataEleConfig(EleDOConfig Config)
        {
            _config = Config;

            cBoxEnable.Checked = _config.Enable;
            tBoxDevName.Text = _config.DevName;
            tBoxDoAddress.Text = _config.DoAddress.ToString("F2");

            comBoxType.Text = _config.DoType == EleDOType.NO ? "NO" : "NC";

            tBoxName.Text = _config.Name;
            tBoxInfo.Text = _config.Info;

            cBoxDOEnable.Checked = _config.DoEnable;
            cBoxSimulate.Checked = _config.IsSimulateMode;
        }

        private delegate void UpdateControl();

        private delegate void UpdateEleRunState(EleRunState state);

        private delegate void UpdateEleSimulateMode(bool simulate);
    }
}