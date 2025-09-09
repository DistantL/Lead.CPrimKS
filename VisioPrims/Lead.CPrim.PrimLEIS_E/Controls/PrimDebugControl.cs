using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimLEIS_E
{
    public partial class PrimDebugControl : UserControl
    {

        private readonly PrimLESI_E _primLESI;

        public PrimDebugControl()
        {
            InitializeComponent();
        }

        public PrimDebugControl(PrimLESI_E prim)
        {
            InitializeComponent();

            _primLESI = prim;
        }

        private delegate void UpdatePrimConnState(PrimConnState state);

        private delegate void UpdatePrimRunState(PrimRunState state);

        public string LESIName
        {
            set => tBoxLESIName.Text = value;
        }
        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_primLESI == null) return;

            _primLESI.IPrimInit();

            var result = "";
            _primLESI.IPrimConnect(ref result);
        }

      
        private void btnRun1_Click(object sender, EventArgs e)
        {
            _primLESI.IPrimStart();

            //btnLoadConfig_Click(null, null);

            tmrUpdateUI.Start();
        }

        
        private void btnStop1_Click(object sender, EventArgs e)
        {
            _primLESI.IPrimStop();
        }

        private void PrimDebugControl_Load(object sender, EventArgs e)
        {
            tBoxLESIName.Text = _primLESI.Name;
        }
        
        public void SetPrimConnState(PrimConnState state)
        {
            if (tBoxConnState.InvokeRequired)
            {
                UpdatePrimConnState update = SetPrimConnState;
                Invoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        break;

                    case PrimConnState.Connected:
                        tBoxConnState.BackColor = Color.LightGreen;
                        tBoxConnState.Text = "Connected";
                        break;

                    case PrimConnState.Other:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        break;
                }
            }
        }

        public void SetPrimRunState(PrimRunState state)
        {
            if (tBoxRunState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdatePrimRunState(SetPrimRunState);
                Invoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = "Idle";
                        break;

                    case PrimRunState.Running:
                        tBoxRunState.BackColor = Color.LightGreen;
                        tBoxRunState.Text = "Running";
                        break;

                    case PrimRunState.Err:
                        tBoxRunState.BackColor = Color.SandyBrown;
                        tBoxRunState.Text = "Err";
                        break;

                    case PrimRunState.Other:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = "Idle";
                        break;
                }
            }
        }
    }
}