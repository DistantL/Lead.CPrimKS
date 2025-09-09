using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.LocalizationService;

namespace Lead.CPrim.PrimSerial
{
    public partial class PrimDebugControl : UserControl
    {
        private readonly PrimSerial _primSerial;

        public PrimDebugControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        public PrimDebugControl(PrimSerial prim)
        {
            InitializeComponent();
            InitializeUI();
            _primSerial = prim;
        }

        private void InitializeUI()
        {
            lbTitle.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialDebug", "Serial Debug");
            label1.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_SerialName", "Serial Name");
            tabPage2.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_Debug", "Debug");
            label5.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_DataReceive", "Data Rev:");
            label4.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_DataSend", "Data Send:");
            btnSend.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_SendMessage", "Send Msg");
            cBoxShowTime.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_TimeDisplay", "Time Display");
            cBoxDebug.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_DebugEnable", "DebugEnable");
            groupBox.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_Execute", "EXE");
            btnInit.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_Initialize", "Init");
            btnRun.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_Run", "Run");
            btnStop.Text = NLocalizer.GetString("PrimSerial_PrimDebugControl_Stop", "Stop");
        }

        public void SetPrimConnState(PrimConnState state)
        {
            if (tBoxConnState.InvokeRequired)
            {
                var update = new UpdatePrimConnState(SetPrimConnState);
                Invoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnRun.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.Enabled = true;
                        break;
                    case PrimConnState.Connected:
                        tBoxConnState.BackColor = Color.LightGreen;
                        tBoxConnState.Text = "Connected";
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        break;
                    case PrimConnState.Other:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnRun.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.Enabled = true;
                        break;
                }
            }
        }

        public void SetPrimRunState(PrimRunState state)
        {
            if (tBoxRunState.InvokeRequired)
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
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Stop:
                        tBoxRunState.BackColor = Color.Brown;
                        tBoxRunState.Text = "Stop";
                        btnRun.BackColor = Color.LightGreen;
                        btnRun.Enabled = true;
                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                    case PrimRunState.Err:
                        tBoxRunState.BackColor = Color.SandyBrown;
                        tBoxRunState.Text = "Err";
                        break;
                    case PrimRunState.Other:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = "Idle";
                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }


        public void ShowRevMsg(string msg)
        {
            if (tBoxInfo.InvokeRequired)
            {
                var updateMsg = new UpdateRevMag(ShowRevMsg);
                tBoxInfo.BeginInvoke(updateMsg, msg);
            }
            else
            {
                if (cBoxShowTime.Checked)
                    tBoxInfo.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "][Rev]   " + msg +
                                        Environment.NewLine);
                else
                    tBoxInfo.AppendText(msg + Environment.NewLine);
            }
        }

        private void PrimDebugControl_Load(object sender, EventArgs e)
        {
            tTaskBoxName.Text = _primSerial.Name;
            cBoxDebug.Checked = _primSerial.PrimDebug;
        }

        private void cBoxDebug_CheckedChanged(object sender, EventArgs e)
        {
            _primSerial.PrimDebug = cBoxDebug.Checked;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _primSerial?.SendInfo("", tBoxMsg.Text);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            _primSerial.IPrimInit();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var result = "";
            _primSerial.IPrimConnect(ref result);
            _primSerial.IPrimStart();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _primSerial.IPrimStop();
        }

        private delegate void UpdatePrimConnState(PrimConnState state);

        private delegate void UpdatePrimRunState(PrimRunState state);

        private delegate void UpdateRevMag(string msg);
    }
}