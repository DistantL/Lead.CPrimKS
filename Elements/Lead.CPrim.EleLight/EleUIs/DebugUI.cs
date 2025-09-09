using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleLight
{
    public partial class DebugUI : UserControl
    {
        private EleLightConfig _config;

        private EleLight _eleLight;

        public DebugUI()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Stopping")
                _eleLight.Stopping();
            else if (comboBox1.Text == "Running")
                _eleLight.Running();
            else if (comboBox1.Text == "Error")
                _eleLight.Error();
            else if (comboBox1.Text == "Warn")
                _eleLight.Warn();
            else if (comboBox1.Text == "Fatal") _eleLight.Fatal();
        }

        private void DebugUI_Load(object sender, EventArgs e)
        {
            if (_eleLight.EleRunStat == EleRunState.Other) _eleLight.IEleInit();
            //tmrUpdateLight.Start();
        }

        private void InitializeUI()
        {
            lbName.Text = ProxyTools.NLocalizer.GetString("EleLight_DebugUI_Name", "Name");
            label1.Text = ProxyTools.NLocalizer.GetString("EleLight_DebugUI_Red", "Red");
            label3.Text = ProxyTools.NLocalizer.GetString("EleLight_DebugUI_Yellow", "Yellow");
            label2.Text = ProxyTools.NLocalizer.GetString("EleLight_DebugUI_Green", "Green");
            label4.Text = ProxyTools.NLocalizer.GetString("EleLight_DebugUI_Buzzer", "Buzz");
        }

        private void tmrLightUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                tBoxName.Text = _eleLight.Name;
                var val = -1;
                if (_eleLight.EleRunStat == EleRunState.Other) _eleLight.IEleInit();
                val = _eleLight.ReadRed();
                if (val != -1) RedDO.BackColor = val == 0 ? SystemColors.GradientActiveCaption : Color.LawnGreen;
                val = -1;
                val = _eleLight.ReadGreen();
                if (val != -1) GreenDO.BackColor = val == 0 ? SystemColors.GradientActiveCaption : Color.LawnGreen;

                val = -1;
                val = _eleLight.ReadYellow();
                if (val != -1) YellowDO.BackColor = val == 0 ? SystemColors.GradientActiveCaption : Color.LawnGreen;
                if (_eleLight.LightType == EleLightType.Button_Light) return;

                val = _eleLight.ReadBuzz();
                if (val != -1) BuzzDO.BackColor = val == 0 ? SystemColors.GradientActiveCaption : Color.LawnGreen;
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

        public void SetEleConfig(EleLight eleLight)
        {
            _eleLight = eleLight;
            //_ele = ele;
            tBoxName.Text = _eleLight.Name;
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
                tBoxName.Text = _eleLight.Name;
                var val = -1;
                if (_eleLight.EleRunStat == EleRunState.Other) _eleLight.IEleInit();
                val = _eleLight.ReadRed();
                if (val != -1) RedDO.BackColor = val == 0 ? SystemColors.GradientActiveCaption : Color.LawnGreen;
                val = -1;
                val = _eleLight.ReadGreen();
                if (val != -1) GreenDO.BackColor = val == 0 ? SystemColors.GradientActiveCaption : Color.LawnGreen;

                val = -1;
                val = _eleLight.ReadYellow();
                if (val != -1) YellowDO.BackColor = val == 0 ? SystemColors.GradientActiveCaption : Color.LawnGreen;
                if (_eleLight.LightType == EleLightType.Button_Light) return;

                val = _eleLight.ReadBuzz();
                if (val != -1) BuzzDO.BackColor = val == 0 ? SystemColors.GradientActiveCaption : Color.LawnGreen;
            }
            catch (Exception)
            {
            }
        }

        public void UpdataEleConfig(EleLightConfig Config)
        {
            _config = Config;
            tBoxName.Text = _config.Name;
        }

        private delegate void UpdateEleRunState(EleRunState state);
    }
}