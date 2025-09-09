/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2022.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明
 *
 * 3.3.33.0617 -> 
 * 1、代码风格重新布局以及增加备注
******************************************************************************/


using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Communicate;
using Lead.CPrim.LocalizationService;
using Lead.CPrim.Authority;

namespace Lead.CPrim.PrimSerial
{
    public partial class PrimConfigControl : UserControl
    {
        #region Field
        private readonly PrimSerial _primSerial;
        #endregion



        #region Prop
        public string PrimSerialName { set => tTaskBoxName.Text = value; }
        #endregion



        #region Ctor
        public PrimConfigControl()
        {
            InitializeComponent();
            InitializeUI();
        }
        public PrimConfigControl(PrimSerial prim) : this()
        {
            _primSerial = prim;
        }
        #endregion



        #region System_Event
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            PrimSerialName = _primSerial.Name;

            comboComPort.DataSource = SerialPort.GetPortNames();
            for (var i = 0; i < comboComPort.Items.Count; i++)
                if (string.Equals(comboComPort.Items[i].ToString(), _primSerial.ComPort,
                    StringComparison.CurrentCultureIgnoreCase))
                    comboComPort.SelectedIndex = i;

            cBoxBoudRate.Text = _primSerial.BoudRate;
            cBoxDataBits.Text = _primSerial.DataBits;
            cBoxStopBits.Text = _primSerial.StopBits;

            switch (_primSerial.SerialParity)
            {
                case ParityMode.None:
                    comboParity.SelectedIndex = 0;
                    break;
                case ParityMode.Odd:
                    comboParity.SelectedIndex = 1;
                    break;
                case ParityMode.Even:
                    comboParity.SelectedIndex = 2;
                    break;
                default:
                    comboParity.SelectedIndex = 0;
                    break;
            }

            if (_primSerial.NotifyMode == SerialNotifyMode.DataEvent)
                cBoxNotifyMode.SelectedIndex = 0;
            else if (_primSerial.NotifyMode == SerialNotifyMode.DataQueue) cBoxNotifyMode.SelectedIndex = 1;
            tBoxSendQueueCnt.Text = _primSerial.SendQueueCnt.ToString();

            tBoxRevQueueCnt.Text = _primSerial.RevQueueCnt.ToString();

            if (!string.IsNullOrEmpty(_primSerial.NetName)) tBoxNetName.Text = _primSerial.NetName;
            tTaskBoxName.Text = _primSerial.Name;

            tBoxCode1.Text = _primSerial.Code1;
            tBoxCode2.Text = _primSerial.Code2;
            cBoxCalCheckCode.Checked = _primSerial.CalCheckCode;

            cBoxIsBinary.Checked = _primSerial.IsBinary;

            cBoxLogEnable.Checked = _primSerial.LogEnable;

            cBoxDebug.Checked = _primSerial.PrimDebug;
        }
        #endregion



        #region Button_Event
        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_primSerial.PrimRunStat == PrimRunState.Stop || _primSerial.PrimRunStat == PrimRunState.Err)
            {
                _primSerial.IPrimDispose();
                _primSerial.IPrimInit();
            }
            else
            {
                _primSerial.IPrimInit();
            }
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
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.Level < OpLevel.Maintenance &&
                AuthorityManager.Instance.Level != OpLevel.Other)
            {
                MessageBox.Show(
                    NLocalizer.GetString("PrimSerial_PrimConfigControl_ConfirmPermission",
                        "The current user does not have permission. Please confirm that the permission is in operation."),
                    NLocalizer.GetString("PrimSerial_PrimConfigControl_Info", "Info"), MessageBoxButtons.OK);
                return;
            }

            if (cBoxNotifyMode.SelectedIndex == 0)
                _primSerial.NotifyMode = SerialNotifyMode.DataEvent;
            else if (cBoxNotifyMode.SelectedIndex == 1) _primSerial.NotifyMode = SerialNotifyMode.DataQueue;

            if (!string.IsNullOrEmpty(comboComPort.Text)) _primSerial.ComPort = comboComPort.Text;

            if (!string.IsNullOrEmpty(cBoxBoudRate.Text)) _primSerial.BoudRate = cBoxBoudRate.Text;

            if (!string.IsNullOrEmpty(cBoxDataBits.Text)) _primSerial.DataBits = cBoxDataBits.Text;

            if (!string.IsNullOrEmpty(cBoxStopBits.Text)) _primSerial.StopBits = cBoxStopBits.Text;

            switch (comboParity.SelectedIndex)
            {
                case 0:
                    _primSerial.SerialParity = ParityMode.None;
                    break;
                case 1:
                    _primSerial.SerialParity = ParityMode.Odd;
                    break;
                case 2:
                    _primSerial.SerialParity = ParityMode.Even;
                    break;
                default:
                    _primSerial.SerialParity = ParityMode.None;
                    break;
            }

            if (!string.IsNullOrEmpty(tBoxSendQueueCnt.Text))
                _primSerial.SendQueueCnt = int.Parse(tBoxSendQueueCnt.Text);
            if (!string.IsNullOrEmpty(tBoxRevQueueCnt.Text)) _primSerial.RevQueueCnt = int.Parse(tBoxRevQueueCnt.Text);

            _primSerial.NetName = tBoxNetName.Text;
            _primSerial.Name = tTaskBoxName.Text;

            _primSerial.IsBinary = cBoxIsBinary.Checked;
            _primSerial.Code1 = tBoxCode1.Text;
            _primSerial.Code2 = tBoxCode2.Text;
            _primSerial.CalCheckCode = cBoxCalCheckCode.Checked;

            _primSerial.LogEnable = cBoxLogEnable.Checked;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            _primSerial?.SendInfo("", tBoxMsg.Text);
        }
        private void cBoxDebug_CheckedChanged(object sender, EventArgs e)
        {
            _primSerial.PrimDebug = cBoxDebug.Checked;
        }
        #endregion



        #region Method_ExternalUsing
        public void ShowRevMsg(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowRevMsg), new object[] { msg });
            }
            else
            {
                if (cBoxShowTime.Checked)
                {
                    tBoxInfo.AppendText($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}][Rev]：{msg}{Environment.NewLine}");
                }
                else
                {
                    tBoxInfo.AppendText($"[Rev]：{msg}{Environment.NewLine}");
                }
            }
        }
        public void SetPrimConnState(PrimConnState state)
        {
            if (tBoxConnState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), new object[] { state });
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
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), new object[] { state });
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
        #endregion



        #region Method_InternalUsing
        private void InitializeUI()
        {
            lbTitle.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_SerialConfig", "Serial Config");
            label1.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_SerialName", "Serial Name");
            tabPage1.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_Config", "Config");
            tabPage2.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_Debug", "Debug");
            label7.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_ComPort", "Com Port:");
            label8.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_BaudRate", "BoudRate:");
            label22.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_DataBits", "DataBits:");
            label23.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_StopBits", "StopBits:");
            label24.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_Parity", "Parity:");
            cBoxIsBinary.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_IsBinary", "IsBinary");
            cBoxCalCheckCode.Text =
                NLocalizer.GetString("PrimSerial_PrimConfigControl_AutoCalCheckCode", "AutoCalCheckCode");
            label10.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_NotifyMode", "NotifyMode:");
            label11.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_SendQueueCount", "SendQueueCnt:");
            label12.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_ReceiveQueueCount", "RevQueueCnt:");
            label13.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_NetName", "NetName:");
            groupBox.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_Execute", "EXE");
            btnInit.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_Initialize", "Init");
            btnRun.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_Run", "Run");
            btnStop.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_Stop", "Stop");
            btnApply.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_Apply", "Apply");
            cBoxLogEnable.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_LogEnable", "LogEnable");

            label5.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_DataReceive", "Data Rev:");
            label4.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_DataSend", "Data Send:");
            btnSend.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_SendMessage", "Send Msg");
            cBoxShowTime.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_TimeDisplay", "Time Display");
            cBoxDebug.Text = NLocalizer.GetString("PrimSerial_PrimConfigControl_DebugEnable", "DebugEnable");
        }
        #endregion



        private void tBoxInfo_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        private void tBoxCode1_TextChanged(object sender, EventArgs e)
        {
            _primSerial.Code1 = tBoxCode1.Text;
        }
        private void tBoxCode2_TextChanged(object sender, EventArgs e)
        {
            _primSerial.Code2 = tBoxCode2.Text;
        }
        private void cBoxCalCheckCode_CheckedChanged(object sender, EventArgs e)
        {
            _primSerial.CalCheckCode = cBoxCalCheckCode.Checked;
        }
        private void cBoxIsBinary_CheckedChanged(object sender, EventArgs e)
        {
            _primSerial.IsBinary = cBoxIsBinary.Checked;
        }

        private void cBoxLogEnable_CheckedChanged(object sender, EventArgs e)
        {
            _primSerial.LogEnable = cBoxLogEnable.Checked;
        }

        private void cBoxShowTime_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}