using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleCyldLine
{
    public partial class ConfigUI : UserControl
    {
        #region Field
        private EleCyldLineConfig _config;
        private IEle _ele;
        private EleCylinderLine _eleCyldLine;
        #endregion


        #region Ctor
        public ConfigUI(EleCylinderLine ele)
        {
            InitializeComponent();
            InitializeUI();
            _ele = ele;
        }
        #endregion


        #region Button_Event
        private void btnConfigApply_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.VerifyLevel1Permission())
            {
                return;
            }

            if (string.IsNullOrEmpty(tBoxName.Text)) return;

            if (!string.IsNullOrEmpty(tBoxName.Text)) _eleCyldLine.Name = tBoxName.Text;

            if (!string.IsNullOrEmpty(tBoxInfo.Text)) _eleCyldLine.Info = tBoxInfo.Text;

            if (!string.IsNullOrEmpty(comBoxType.Text))
            {
                if (comBoxType.Text == "Vacuum")
                    _eleCyldLine.CyldType = EleCyldType.Vacuum;
                else if (comBoxType.Text == "Cylinder")
                    _eleCyldLine.CyldType = EleCyldType.Cylinder;
                else
                    _eleCyldLine.CyldType = EleCyldType.Other;
            }

            if (!string.IsNullOrEmpty(tBoxStretchDI.Text))
                _eleCyldLine.StretchDiAddress = double.Parse(tBoxStretchDI.Text);

            if (!string.IsNullOrEmpty(tBoxDevName.Text)) _eleCyldLine.DevName = tBoxDevName.Text;

            if (!string.IsNullOrEmpty(tBoxStretchT.Text)) _eleCyldLine.StretchTimeOut = int.Parse(tBoxStretchT.Text);

            if (!string.IsNullOrEmpty(tBoxRestractT.Text)) _eleCyldLine.RestractTimeOut = int.Parse(tBoxRestractT.Text);
            if (!string.IsNullOrEmpty(tBoxBlowT.Text)) _eleCyldLine.BlowTime = int.Parse(tBoxBlowT.Text);

            if (!string.IsNullOrEmpty(tBoxRestractDI.Text))
                _eleCyldLine.RestractDiAddress = double.Parse(tBoxRestractDI.Text);

            if (!string.IsNullOrEmpty(tBoxStretchDO.Text))
                _eleCyldLine.StretchDoAddress = double.Parse(tBoxStretchDO.Text);

            if (!string.IsNullOrEmpty(tBoxRestractDO.Text))
                _eleCyldLine.RestractDoAddress = double.Parse(tBoxRestractDO.Text);

            _eleCyldLine.Enable = cBoxEnable.Checked;
            _eleCyldLine.StretchDiEnable = cBoxStretchDIEnable.Checked;
            _eleCyldLine.RestractDiEnable = cBoxRestractDIEnable.Checked;
            _eleCyldLine.StretchDoEnable = cBoxStretchDOEnable.Checked;
            _eleCyldLine.RestractDoEnable = cBoxRestractDOEnable.Checked;
            _eleCyldLine.IsSimulateMode = cBoxSimulate.Checked;
        }

        private void btnRestractSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleCyldLine.Enable)
                {
                    if (_eleCyldLine.ReadRestractDO() == 0)
                    {
                        if (!string.IsNullOrEmpty(tBoxRestractDO.Text) && cBoxRestractDOEnable.Checked)
                            _eleCyldLine.WriteRestractDO(true);
                    }
                    else if (_eleCyldLine.ReadRestractDO() == 1)
                    {
                        if (!string.IsNullOrEmpty(tBoxRestractDO.Text) && cBoxRestractDOEnable.Checked)
                            _eleCyldLine.WriteRestractDO(false);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnStretchSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleCyldLine.Enable)
                {
                    if (_eleCyldLine.ReadStretchDO() == 1)
                    {
                        if (!string.IsNullOrEmpty(tBoxStretchDO.Text) && cBoxStretchDOEnable.Checked)
                            _eleCyldLine.WriteStretchDO(false);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(tBoxStretchDO.Text) && cBoxStretchDOEnable.Checked)
                            _eleCyldLine.WriteStretchDO(true);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void ConfigUI_Click(object sender, EventArgs e)
        {
            _eleCyldLine.IsSelected = !_eleCyldLine.IsSelected;
        }
        private void lbState_Click(object sender, EventArgs e)
        {
            if (_eleCyldLine.EleRunStat == EleRunState.Other) _eleCyldLine.IEleInit();
            if (_eleCyldLine.EleRunStat == EleRunState.Err) _eleCyldLine.IEleReset();
        }
        #endregion


        #region System_Event
        private void ConfigUI_Load(object sender, EventArgs e)
        {
            if (_eleCyldLine.Enable)
                if (_eleCyldLine.EleRunStat == EleRunState.Other)
                    _eleCyldLine.IEleInit();

            if (!_eleCyldLine.StretchDiEnable) tBoxStretchDI.ReadOnly = true;

            if (!_eleCyldLine.RestractDiEnable) tBoxRestractDI.ReadOnly = true;

            if (!_eleCyldLine.StretchDoEnable) tBoxStretchDO.ReadOnly = true;

            if (!_eleCyldLine.RestractDoEnable) tBoxRestractDO.ReadOnly = true;

            cBoxRestractDIEnable.CheckedChanged += cBoxRestractDIEnable_CheckedChanged;
            cBoxStretchDIEnable.CheckedChanged += cBoxStretchDIEnable_CheckedChanged;
            cBoxRestractDOEnable.CheckedChanged += cBoxRestractDOEnable_CheckedChanged;
            cBoxStretchDOEnable.CheckedChanged += cBoxStretchDOEnable_CheckedChanged;

            comBoxType.SelectedIndexChanged += comBoxType_SelectedIndexChanged;
        }
        private void cBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            _ele.Enable = cBoxEnable.Checked;
            if (cBoxEnable.Checked)
            {
                var val = _ele.IEleInit();
                if (val == -1) return;
            }
        }
        private void cBoxEnable_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cBoxEnable.Checked)
            {
                var prim = PrimsManagerTransfer.GetPrimByName(_eleCyldLine.DevName);
                if (prim == null)
                    return;
            }
        }
        private void cBoxRestractDIEnable_CheckedChanged(object sender, EventArgs e)
        {
            tBoxRestractDI.ReadOnly = !cBoxRestractDIEnable.Checked;
        }
        private void cBoxRestractDOEnable_CheckedChanged(object sender, EventArgs e)
        {
            tBoxRestractDO.ReadOnly = !cBoxRestractDOEnable.Checked;
        }
        private void cBoxSimulate_CheckedChanged(object sender, EventArgs e)
        {
            if (_eleCyldLine == null) return;

            _eleCyldLine.IsSimulateMode = cBoxSimulate.Checked;
        }
        private void cBoxStretchDIEnable_CheckedChanged(object sender, EventArgs e)
        {
            tBoxStretchDI.ReadOnly = !cBoxStretchDIEnable.Checked;
        }
        private void cBoxStretchDOEnable_CheckedChanged(object sender, EventArgs e)
        {
            tBoxStretchDO.ReadOnly = !cBoxStretchDOEnable.Checked;
        }
        private void comBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comBoxType.Text == "Cylinder")
            {
                tBoxBlowT.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                tBoxRestractDI.ReadOnly = false;
                cBoxRestractDIEnable.Enabled = true;
            }
            else if (comBoxType.Text == "Vacuum")
            {
                tBoxBlowT.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                tBoxRestractDI.ReadOnly = true;
                cBoxRestractDIEnable.Enabled = false;
            }
        }
        #endregion



        #region Method_ExternalUsing
        public void SetEleConfig(EleCylinderLine eleCyldLine)
        {
            _eleCyldLine = eleCyldLine;
            cBoxEnable.Checked = _eleCyldLine.Enable;
            cBoxSimulate.Checked = _eleCyldLine.IsSimulateMode;
            comBoxType.Text = _eleCyldLine.CyldType.ToString();
            tBoxDevName.Text = _eleCyldLine.DevName;
            tBoxStretchDI.Text = _eleCyldLine.StretchDiAddress.ToString("F2");
            tBoxRestractDI.Text = _eleCyldLine.RestractDiAddress.ToString("F2");
            tBoxStretchDO.Text = _eleCyldLine.StretchDoAddress.ToString("F2");
            tBoxRestractDO.Text = _eleCyldLine.RestractDoAddress.ToString("F2");
            cBoxStretchDIEnable.Checked = _eleCyldLine.StretchDiEnable;
            cBoxRestractDIEnable.Checked = _eleCyldLine.RestractDiEnable;
            cBoxStretchDOEnable.Checked = _eleCyldLine.StretchDoEnable;
            cBoxRestractDOEnable.Checked = _eleCyldLine.RestractDoEnable;
            tBoxStretchT.Text = _eleCyldLine.StretchTimeOut.ToString();
            tBoxRestractT.Text = _eleCyldLine.RestractTimeOut.ToString();
            tBoxBlowT.Text = _eleCyldLine.BlowTime.ToString();
            tBoxName.Text = _eleCyldLine.Name;
            tBoxInfo.Text = _eleCyldLine.Info;
        }
        public void SetEleRunState(EleRunState state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<EleRunState>(SetEleRunState), state);
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
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetSimulateMode), simulate);
            }
            else
            {
                cBoxSimulate.Checked = simulate;
            }
        }
        public void UiRefresh()
        {
            if (_eleCyldLine == null || _config == null || _eleCyldLine.IsSimulateMode) return;

            if (InvokeRequired)
            {
                BeginInvoke(new Action(UiRefresh));
            }
            else
            {
                if (_eleCyldLine.EleRunStat == EleRunState.Other)
                {
                    _eleCyldLine.IEleInit();
                    return;
                }

                tBoxDevName.BackColor = _eleCyldLine.EleRunStat == EleRunState.Running
                    ? Color.LawnGreen
                    : SystemColors.GradientActiveCaption;

                if (_eleCyldLine.StretchDiEnable)
                    tBoxStretchDI.BackColor =
                        _eleCyldLine.StretchDi_On ? Color.LawnGreen : SystemColors.GradientActiveCaption;

                if (_eleCyldLine.RestractDiEnable)
                    tBoxRestractDI.BackColor = _eleCyldLine.RestractDi_On
                        ? Color.LawnGreen
                        : SystemColors.GradientActiveCaption;

                if (_eleCyldLine.StretchDoEnable)
                {
                    btnStretchSet.Enabled = true;
                    btnStretchSet.BackColor = SystemColors.Control;
                    if (_eleCyldLine.StretchDo_On)
                    {
                        tBoxStretchDO.BackColor = Color.LawnGreen;
                        btnStretchSet.Tag = 1;
                        btnStretchSet.Text = "Reset";
                    }
                    else
                    {
                        tBoxStretchDO.BackColor = SystemColors.GradientActiveCaption;
                        btnStretchSet.Tag = 0;
                        btnStretchSet.Text = "Set";
                    }
                }
                else
                {
                    btnStretchSet.Enabled = false;
                    btnStretchSet.BackColor = Color.Gray;
                }

                if (_eleCyldLine.RestractDoEnable)
                {
                    btnRestractSet.Enabled = true;
                    btnRestractSet.BackColor = SystemColors.Control;
                    if (_eleCyldLine.RestractDo_On)
                    {
                        tBoxRestractDO.BackColor = Color.LawnGreen;
                        btnRestractSet.BackColor = SystemColors.Control;
                        btnRestractSet.Tag = 1;
                        btnRestractSet.Text = "Reset";
                    }
                    else
                    {
                        tBoxRestractDO.BackColor = SystemColors.GradientActiveCaption;
                        btnRestractSet.Tag = 0;
                        btnRestractSet.Text = "Set";
                    }
                }
                else
                {
                    btnRestractSet.Enabled = false;
                    btnRestractSet.BackColor = Color.Gray;
                }
            }
        }
        public void UpdataEleConfig(EleCyldLineConfig Config)
        {
            _config = Config;

            cBoxSimulate.Checked = _config.IsSimulateMode;
            cBoxEnable.Checked = _config.Enable;
            comBoxType.Text = _config.CyldType.ToString();
            tBoxDevName.Text = _config.DevName;
            tBoxStretchDI.Text = _config.StretchDiAddress.ToString("F2");
            tBoxRestractDI.Text = _config.RestractDiAddress.ToString("F2");
            tBoxStretchDO.Text = _config.StretchDoAddress.ToString("F2");
            tBoxRestractDO.Text = _config.RestractDoAddress.ToString("F2");
            cBoxStretchDIEnable.Checked = _config.StretchDiEnable;
            cBoxRestractDIEnable.Checked = _config.RestractDiEnable;
            cBoxStretchDOEnable.Checked = _config.StretchDoEnable;
            cBoxRestractDOEnable.Checked = _config.RestractDoEnable;
            tBoxStretchT.Text = _config.StretchTimeOut.ToString();
            tBoxRestractT.Text = _config.RestractTimeOut.ToString();
            tBoxBlowT.Text = _eleCyldLine.BlowTime.ToString();
            tBoxName.Text = _config.Name;
            tBoxInfo.Text = _config.Info;
            if (_config.CyldType == EleCyldType.Vacuum)
            {
                tBoxBlowT.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                tBoxRestractDI.ReadOnly = true;
                cBoxRestractDIEnable.Enabled = false;
            }
            else
            {
                tBoxBlowT.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                tBoxRestractDI.ReadOnly = false;
                cBoxRestractDIEnable.Enabled = true;
            }

            //tBoxId.Text = _ele.Id.ToString();
            //tBoxState.Text = _ele.EleRunStat.ToString();
        }
        #endregion



        #region Method_InternalUsing
        private void InitializeUI()
        {
            lbName.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Name", "Name");
            lbInfo.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Info", "Info");
            lbState.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_State", "State");
            cBoxEnable.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Enable", "Enable");
            cBoxSimulate.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Simulate", "Simulate");
            lbType.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Type", "Type");
            lbDevName.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_DevName", "DevName");
            lbStretchDI.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_StretchDI", "StretchDI");
            lbRestractDI.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_RestractDI", "RestractDI");
            lbStretchDO.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_StretchDO", "StretchDO");
            lbRestractDO.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_RestractDO", "RestractDO");

            cBoxStretchDIEnable.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Enable", "Enable");
            cBoxRestractDIEnable.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Enable", "Enable");
            cBoxStretchDOEnable.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Enable", "Enable");
            cBoxRestractDOEnable.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Enable", "Enable");
            btnStretchSet.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Set", "Set");
            btnRestractSet.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Set", "Set");
            btnConfigApply.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_Apply", "Apply");

            lbStretchT.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_StretchTime", "StretchT");
            lbRestractT.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_RestractTime", "RestractT");
            label4.Text = ProxyTools.NLocalizer.GetString("EleCyldLine_ConfigUI_BlowName", "BlowTime");
        }
        #endregion
    }
}