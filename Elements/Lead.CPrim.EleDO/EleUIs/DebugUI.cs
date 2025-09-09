using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleDO
{
    public partial class DebugUI : UserControl
    {
        private EleDOConfig _config;

        private EleDO _eleDO;

        public DebugUI()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void btnReSet_Click(object sender, EventArgs e)
        {
            if (_eleDO.Enable)
                _eleDO.Write(false);
            else
                MessageBox.Show(ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_NotEnable", "It is not enable!"));
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (_eleDO.Enable)
                _eleDO.Write(true);
            else
                MessageBox.Show(ProxyTools.NLocalizer.GetString("EleDO_ConfigUI_NotEnable", "It is not enable!"));
        }

        private void DebugUI_Load(object sender, EventArgs e)
        {
            if (_eleDO.EleRunStat == EleRunState.Other) _eleDO.IEleInit();
            //tmrUpdateLight.Start();
        }

        private void InitializeUI()
        {
            lbName.Text = ProxyTools.NLocalizer.GetString("EleDO_DebugUI_Name", "Name");
        }

        private void tmrLightUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                tBoxName.Text = _eleDO.Name;
                if (_eleDO.EleRunStat == EleRunState.Other)
                {
                    _eleDO.IEleInit();
                    return;
                }

                if (_eleDO.EleRunStat != EleRunState.Running)
                {
                    btnSet.BackColor = SystemColors.GradientActiveCaption;
                    btnReSet.BackColor = SystemColors.GradientActiveCaption;
                    textBox1.Text = "Not Work";
                }

                btnSet.BackColor = _eleDO.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;
                btnReSet.BackColor = !_eleDO.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;
                textBox1.Text = "<- - - - - - >";
            }
            catch (Exception)
            {
            }
        }

        public new void Dispose()
        {
            if (tmrUpdateLight != null)
            {
                //tmrUpdateLight.Dispose();
            }
        }

        public void SetEleConfig(EleDO eleLight)
        {
            _eleDO = eleLight;
            //_ele = ele;
            tBoxName.Text = _eleDO.Name;
        }

        public void SetEleRunState(EleRunState state)
        {
            if (tBoxName.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                UpdateEleRunState update = SetEleRunState;
                BeginInvoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case EleRunState.Idle:
                        tBoxName.BackColor = Color.Khaki;
                        break;

                    case EleRunState.Running:
                        tBoxName.BackColor = Color.LightGreen;
                        break;

                    case EleRunState.Err:
                        tBoxName.BackColor = Color.SandyBrown;
                        break;

                    case EleRunState.Other:
                        tBoxName.BackColor = Color.Khaki;
                        break;
                }
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
                if (_eleDO == null || _config == null) return;

                if (InvokeRequired)
                {
                    UpdateControl update = UiRefresh;
                    BeginInvoke(update);
                }
                else
                {
                    tBoxName.Text = _eleDO.Name;
                    if (_eleDO.EleRunStat == EleRunState.Other)
                    {
                        _eleDO.IEleInit();
                        return;
                    }

                    if (_eleDO.EleRunStat != EleRunState.Running)
                    {
                        btnSet.BackColor = SystemColors.GradientActiveCaption;
                        btnReSet.BackColor = SystemColors.GradientActiveCaption;
                        textBox1.Text = "Not Work";
                    }

                    btnSet.BackColor = _eleDO.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;
                    btnReSet.BackColor = !_eleDO.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;
                    textBox1.Text = "<- - - - - - >";
                }
            }
            catch (Exception)
            {
            }
        }

        public void UpdataEleConfig(EleDOConfig Config)
        {
            _config = Config;
            tBoxName.Text = _config.Name;
        }

        private delegate void UpdateControl();

        private delegate void UpdateEleRunState(EleRunState state);
    }
}