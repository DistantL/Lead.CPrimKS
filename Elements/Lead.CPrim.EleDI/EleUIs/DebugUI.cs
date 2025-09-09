using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleDI
{
    public partial class DebugUI : UserControl
    {
        private EleDIConfig _config;

        private IEle _ele;
        private EleDI _eleDI;
        public string msg = "";

        public DebugUI(EleDI ele)
        {
            InitializeComponent();
            InitializeUI();
            _ele = ele;
        }

        private void DebugUI_Load(object sender, EventArgs e)
        {
            if (_eleDI.EleRunStat == EleRunState.Other) _eleDI.IEleInit();
            //tmrUpdateSensor.Start();
        }

        private void InitializeUI()
        {
            lbName.Text = ProxyTools.NLocalizer.GetString("EleDI_DebugUI_Name", "Name");
        }

        private void tmrSensorUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                tBoxName.Text = _eleDI.Name;
                if (_eleDI.EleRunStat == EleRunState.Other) _eleDI.IEleInit();
                if (_eleDI.EleRunStat != EleRunState.Running)
                {
                    tBoxDI.BackColor = SystemColors.GradientActiveCaption;
                    textBox1.Text = "Not Work";
                    if (_eleDI.EleRunStat == EleRunState.Other) return;
                }

                tBoxDI.BackColor = _eleDI.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;
                textBox1.Text = "- - - - ->";
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public new void Dispose()
        {
            if (tmrUpdateSensor != null)
            {
                //tmrUpdateSensor.Dispose();
            }
        }

        public void SetEleConfig(EleDI eleDI)
        {
            _eleDI = eleDI;
            //_ele = ele;
            tBoxName.Text = _eleDI.Name;
        }

        public void SetEleRunState(EleRunState state)
        {
            if (tBoxName.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                UpdateEleRunState update = SetEleRunState;
                Invoke(update, state);
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
            if (tmrUpdateSensor != null)
            {
                //tmrUpdateSensor.Stop();
            }
        }

        public void UiRefresh()
        {
            try
            {
                if (_eleDI == null || _config == null) return;

                if (InvokeRequired)
                {
                    var update = new UpdateControl(UiRefresh);
                    BeginInvoke(update);
                }
                else
                {
                    tBoxName.Text = _eleDI.Name;
                    if (_eleDI.EleRunStat == EleRunState.Other) _eleDI.IEleInit();
                    if (_eleDI.EleRunStat != EleRunState.Running)
                    {
                        tBoxDI.BackColor = SystemColors.GradientActiveCaption;
                        textBox1.Text = "Not Work";
                        if (_eleDI.EleRunStat == EleRunState.Other) return;
                    }

                    if (_eleDI.DiEnable)
                        tBoxDI.BackColor = _eleDI.Read() ? Color.LawnGreen : SystemColors.GradientActiveCaption;

                    textBox1.Text = "- - - - ->";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void UpdataEleConfig(EleDIConfig Config)
        {
            _config = Config;

            tBoxName.Text = _eleDI.Name;
        }

        private delegate void UpdateControl();

        private delegate void UpdateEleRunState(EleRunState state);
    }
}