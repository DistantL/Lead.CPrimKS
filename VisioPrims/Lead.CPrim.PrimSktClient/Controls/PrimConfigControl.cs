using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Lead.CPrim.PrimSktClient
{
    /// <summary>PrimConfigControl</summary>
    public partial class PrimConfigControl : UserControl
    {
        #region Field
        /// <summary>客户端管理器</summary>
        private readonly PrimClient _primClient;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public PrimConfigControl()
        {
            InitializeComponent();
            InitializeUI();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="prim">客户端管理器</param>
        public PrimConfigControl(PrimClient prim)
        {
            InitializeComponent();
            InitializeUI();
            _primClient = prim;

            txtName.SetStyle(Color.OldLace, default);
            txtConnState.SetStyle(Color.Khaki, default);
            txtRunState.SetStyle(Color.Khaki, default);
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {

            txtName.Text = _primClient.Name;

            tbIP.Text = _primClient.Ip;

            tbPort.Text = _primClient.Port;

            tbHeartInfo.Text = _primClient.HeartInfo;

            tbHeartTime.Text = _primClient.HeartInfoCycleTime.ToString();

            chkHeart.Checked = _primClient.HeartFlag;

            tbReConnCnt.Text = _primClient.ReconnectCnt.ToString();

            if (_primClient.NotifyMode == SktNotifyMode.DataEvent)
                cmbNotifyMode.SelectedIndex = 0;
            else if (_primClient.NotifyMode == SktNotifyMode.DataQueue) 
                cmbNotifyMode.SelectedIndex = 1;

            cBoxMode.SelectedItem = _primClient.ConnMode.ToString();

            cmbEncoding.SelectedIndex = (int)_primClient.TransEncodingType;

            tbSendQueueCnt.Text = _primClient.SendQueueCnt.ToString();

            //tbRevQueueCnt.Text = _primClient.RevQueueCnt.ToString();

            tbNetName.Text = _primClient.NetName;
            cbLogEnable.Checked = _primClient.LogEnable;

            SetPrimRunState(_primClient.PrimRunStat);
            SetPrimConnState(_primClient.PrimConnStat);
        }
        #endregion



        #region Button_Event
        /// <summary>初始化</summary>
        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = 0;
                ret = _primClient.IPrimInit();
                if(ret != 0)
                {
                    throw new Exception(((SoftWareAlarm)ret).ToString());
                }
                var result = "";
                ret = _primClient.IPrimConnect(ref result);
                if(ret != 0)
                {
                    throw new Exception(((SoftWareAlarm)ret).ToString());
                }
            }
            catch (Exception ex)
            {
                _primClient.LogAdd($"初始化失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>运行</summary>
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = 0;
                ret = _primClient.IPrimStart();
                if (ret != 0)
                {
                    throw new Exception(((SoftWareAlarm)ret).ToString());
                }
            }
            catch (Exception ex)
            {
                _primClient.LogAdd($"运行失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>停止</summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = 0;
                if (_primClient.PrimRunStat == PrimRunState.Err)
                {
                    ret = _primClient.IPrimReset();
                }
                else
                {
                    ret = _primClient.IPrimTaskStop();
                }

                if (ret != 0)
                {
                    throw new Exception(((SoftWareAlarm)ret).ToString());
                }
            }
            catch (Exception ex)
            {
                _primClient.LogAdd($"停止失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if(!IPAddress.TryParse(tbIP.Text, out var ip))
                {
                    throw new Exception("IP值无效");
                }
                if(string.IsNullOrEmpty(tbPort.Text))
                {
                    throw new Exception("端口值无效");
                }
                if (int.Parse(tbHeartTime.Text) < 0)
                {
                    throw new Exception("心跳循环时间不能为负数");
                }
                _primClient.Ip = tbIP.Text;
                _primClient.Port = tbPort.Text;

                tBoxHeartInfo_TextChanged(null, null);

                tBoxHeartTime_TextChanged(null, null);

                cBoxHeart_CheckedChanged(null, null);

                tBoxReConnCnt_TextChanged(null, null);

                cBoxNotifyMode_SelectedIndexChanged(null, null);

                _primClient.ConnMode = Enum.TryParse(cBoxMode.SelectedIndex.ToString(), out SktConnMode mode) ? mode : SktConnMode.TCP;

                _primClient.TransEncodingType = Enum.TryParse(cmbEncoding.SelectedIndex.ToString(), out EncodingType encoding) ? encoding : EncodingType.UTF8;

                tBoxSendQueueCnt_TextChanged(null, null);

                tBoxNetName_TextChanged(null, null);

                _primClient.Name = txtName.Text.Trim();

                _primClient.LogEnable = cbLogEnable.Checked;
                _primClient.LogAdd($"应用成功", LogLevel.Info);
            }
            catch (Exception ex)
            {
                _primClient.LogAdd($"应用失败：{ex.Message}", LogLevel.Warn);
            }

        }
        /// <summary>IP设置</summary>
        private void tBoxIP_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbIP.Text.Trim()))
                _primClient.Ip = tbIP.Text;
        }
        /// <summary>端口设置</summary>
        private void tBoxPort_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPort.Text.Trim()))
                _primClient.Port = tbPort.Text;
        }
        /// <summary>心跳信息</summary>
        private void tBoxHeartInfo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbHeartInfo.Text.Trim()))
                _primClient.HeartInfo = tbHeartInfo.Text;
        }
        /// <summary>心跳循环时间</summary>
        private void tBoxHeartTime_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbHeartTime.Text.Trim()))
                _primClient.HeartInfoCycleTime = int.Parse(tbHeartTime.Text);
        }
        /// <summary>心跳是否开启</summary>
        private void cBoxHeart_CheckedChanged(object sender, EventArgs e)
        {
            _primClient.HeartFlag = chkHeart.Checked;
        }
        /// <summary>重连次数</summary>
        private void tBoxReConnCnt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbReConnCnt.Text.Trim()))
                _primClient.ReconnectCnt = int.Parse(tbReConnCnt.Text);
        }
        /// <summary>通知模式</summary>
        private void cBoxNotifyMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNotifyMode.SelectedIndex == 0)
                _primClient.NotifyMode = SktNotifyMode.DataEvent;
            else if (cmbNotifyMode.SelectedIndex == 1)
                _primClient.NotifyMode = SktNotifyMode.DataQueue;
        }
        /// <summary>发送队列数量</summary>
        private void tBoxSendQueueCnt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSendQueueCnt.Text.Trim()))
                _primClient.SendQueueCnt = int.Parse(tbSendQueueCnt.Text);
        }
        /// <summary>网络名称</summary>
        private void tBoxNetName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNetName.Text.Trim()))
                _primClient.NetName = tbNetName.Text;
        }
        /// <summary>启用调试</summary>
        private void cBoxDebug_CheckedChanged(object sender, EventArgs e)
        {
            _primClient.PrimDebug = cBoxDebug.Checked;
        }
        /// <summary>发送消息</summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBoxMsg.Text)) 
                _primClient.SendInfo("", tBoxMsg.Text);
        }

        /// <summary>
        /// 清除接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearReceived_Click(object sender, EventArgs e)
        {
            tbRevInfo.Clear();
        }

        /// <summary>
        /// 清除发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSend_Click(object sender, EventArgs e)
        {
            tBoxMsg.Clear();
        }
        #endregion



        #region Others
        /// <summary>基元名称设置</summary>
        /// <param name="name">名称</param>
        public void SetPrimName(string name)
        {
            txtName.SetText(name);
        }
        /// <summary>连接状态设置</summary>
        /// <param name="state">连接状态</param>
        public void SetPrimConnState(PrimConnState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
            if (txtConnState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                    case PrimConnState.Other:
                        txtConnState.FillColor = Color.Khaki;
                        txtConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnRun.BackColor = Color.Gray;
                        btnInit.Enabled = true;
                        btnRun.Enabled = false;
                        break;
                    case PrimConnState.Connected:
                        txtConnState.FillColor = Color.LightGreen;
                        txtConnState.Text = "Connected";
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        break;
                }
            }
        }
        /// <summary>运行状态设置</summary>
        /// <param name="state">运行状态</param>
        public void SetPrimRunState(PrimRunState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }

            if (txtRunState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        txtRunState.FillColor = Color.Khaki;
                        txtRunState.Text = "Idle";
                        break;
                    case PrimRunState.Running:
                        txtRunState.FillColor = Color.LightGreen;
                        txtRunState.Text = "Running";

                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Stop:
                        txtRunState.FillColor = Color.Brown;
                        txtRunState.Text = "Stop";

                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                    case PrimRunState.Err:
                        txtRunState.FillColor = Color.SandyBrown;
                        txtRunState.Text = "Err";

                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Other:
                        txtRunState.FillColor = Color.Khaki;
                        txtRunState.Text = "Idle";

                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }
        /// <summary>消息接收</summary>
        /// <param name="msg">消息</param>
        public void ShowRevMsg(string msg)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }

            if (tbRevInfo.InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowRevMsg), msg);
            }
            else
            {
                tbRevInfo.AppendText(msg + "\r\n");
            }
        }
        /// <summary>中英互译</summary>
        private void InitializeUI()
        {
            lbTitle.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_SocketClientConfig",
                "Socket Client Config");
            label1.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_ClientName", "Client Name");
            tabPage1.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Config", "Config");
            tabPage2.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Debug", "Debug");
            label2.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_IP", "IP:");
            label3.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Port", "Port:");
            label6.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_HeartInfo", "HeartInfo:");
            label7.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_HeartCycle", "HeartCycle:");
            chkHeart.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_HeartEnable", "HeartEnable");
            label9.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_ReConnectCount", "ReConnect Cnt:");
            label10.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_NotifyMode", "NotifyMode:");
            label14.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Mode", "Mode:");
            label11.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_SendQueueCount", "SendQueueCnt:");
            label13.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_NetName", "NetName:");
            groupBox.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Execute", "EXE");
            btnInit.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Initialize", "Init");
            btnRun.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Run", "Run");
            btnStop.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Stop", "Stop");
            btnApply.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Apply", "Apply");

            label5.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_DataReceive", "Data Rev:");
            label4.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_DataSend", "Data Send:");
            btnSend.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_SendMessage", "Send Msg");
            cBoxDebug.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_DebugEnable", "DebugEnable");
        }
        #endregion
    }
}