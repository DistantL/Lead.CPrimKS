using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.PrimSktServer
{
    #region Del
    /// <summary>
    /// 更新连接状态
    /// </summary>
    /// <param name="state"></param>
    public delegate void UpdatePrimConnState(PrimConnState state);
    /// <summary>
    /// 更新运行状态
    /// </summary>
    /// <param name="state"></param>
    public delegate void UpdatePrimRunState(PrimRunState state);
    /// <summary>
    /// 更新接收消息
    /// </summary>
    /// <param name="msg"></param>
    public delegate void UpdateRevMag(string msg);
    #endregion

    public partial class PrimConfigControl : UserControl
    {
        /// <summary>tool</summary>
        private readonly PrimServer _primServer;
        /// <summary>配置</summary>
        private ServerConfig _config;

        #region Ctor
        public PrimConfigControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        public PrimConfigControl(PrimServer prim)
        {
            InitializeComponent();
            InitializeUI();
            _primServer = prim;
            _config = _primServer._config;
            _primServer.UpdateUIEvent -= UpdateUI;
            _primServer.UpdateUIEvent += UpdateUI;
        } 
        #endregion

        /// <summary>
        /// 中英转换
        /// </summary>
        private void InitializeUI()
        {
            lbTitle.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_SocketClientConfig",
                "Socket Server Config");
            label1.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_ServerName", "Server Name");
            tabPage1.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_Config", "Config");
            tabPage2.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_Debug", "Debug");

            label2.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_IP", "IP:");
            label3.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_Port", "Port:");
            label6.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_HeartInfo", "HeartInfo:");
            cBoxHeart.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_HeartEnable", "HeartEnable");
            label10.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_NotifyMode", "NotifyMode:");

            label11.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_SendQueueCount", "SendQueueCnt:");
            label12.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_RevQueueCount", "RevQueueCnt:");
            label13.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_NetName", "NetName:");

            groupBox.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_Execute", "EXE");
            btnInit.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_Initialize", "Init");
            btnRun.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_Run", "Run");
            btnStop.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_Stop", "Stop");
            btnApply.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_Apply", "Apply");

            label7.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_ClientList", "Client List:");
            label5.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_DataReceive", "Data Rev:");
            label4.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_DataSend", "Data Send:");
            btnSend.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_SendMessage", "Send Msg");
            cBoxDebug.Text = ProxyTools.NLocalizer.GetString("PrimSktServer_PrimConfigControl_DebugEnable", "DebugEnable");
        }

        
        


        #region Event
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            tTaskBoxName.Text = _primServer.Name;
            if (!string.IsNullOrEmpty(_primServer.BindIp)) tBoxIP.Text = _primServer.BindIp;
            if (!string.IsNullOrEmpty(_primServer.Port)) tBoxPort.Text = _primServer.Port;
            if (!string.IsNullOrEmpty(_primServer.HeartInfo)) tBoxHeartInfo.Text = _primServer.HeartInfo;
            cBoxHeart.Checked = _primServer.HeartFlag;
            if (_primServer.NotifyMode == SktNotifyMode.DataEvent)
                cBoxNotifyMode.SelectedIndex = 0;
            else if (_primServer.NotifyMode == SktNotifyMode.DataQueue) cBoxNotifyMode.SelectedIndex = 1;
            tBoxSendQueueCnt.Text = _primServer.SendQueueCnt.ToString();
            tBoxRevQueueCnt.Text = _primServer.RevQueueCnt.ToString();
            if (!string.IsNullOrEmpty(_primServer.NetName)) tBoxNetName.Text = _primServer.NetName;
            cBoxDebug.Checked = _primServer.PrimDebug;
            SetPrimRunState(_primServer.PrimRunStat);
            SetPrimConnState(_primServer.PrimConnStat);
            if(_primServer._listName != null && _primServer._listName.Count != 0)
            {
                UpdateUI();
            }
        }
        #endregion


        #region 按钮
        /// <summary>
        /// 基元初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                if(_primServer.IPrimInit() != 0)
                {
                    throw new Exception("IPrimInit失败");
                }
                var result = "";
                if(_primServer.IPrimConnect(ref result) != 0)
                {
                    throw new Exception("IPrimConnect失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,$"初始化失败="+ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 基元运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primServer.IPrimStart() != 0)
                {
                    throw new Exception("IPrimStart失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"启动失败=" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 基元停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_primServer.IPrimStop() != 0)
                {
                    throw new Exception("IPrimStop失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"停止失败=" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!AuthorityManager.Instance.VerifyLevel1Permission(true))
            {
                return;
            }

            _primServer.Name = tTaskBoxName.Text;
            if (!string.IsNullOrEmpty(tBoxIP.Text)) _primServer.BindIp = tBoxIP.Text;
            if (!string.IsNullOrEmpty(tBoxPort.Text)) _primServer.Port = tBoxPort.Text;
            if (!string.IsNullOrEmpty(tBoxHeartInfo.Text)) _primServer.HeartInfo = tBoxHeartInfo.Text;
            _primServer.HeartFlag = cBoxHeart.Checked;
            _primServer.Heart();
            if (cBoxNotifyMode.SelectedIndex == 0)
                _primServer.NotifyMode = SktNotifyMode.DataEvent;
            else if (cBoxNotifyMode.SelectedIndex == 1) _primServer.NotifyMode = SktNotifyMode.DataQueue;
            if (!string.IsNullOrEmpty(tBoxRevQueueCnt.Text)) _primServer.RevQueueCnt = int.Parse(tBoxRevQueueCnt.Text);
            if (!string.IsNullOrEmpty(tBoxSendQueueCnt.Text))
                _primServer.SendQueueCnt = int.Parse(tBoxSendQueueCnt.Text);
            _primServer.NetName = tBoxNetName.Text;
            _primServer.PrimDebug = cBoxDebug.Checked;
        }
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBoxMsg.Text) && !string.IsNullOrEmpty(cboIpPort.Text))
            {
                var port = cboIpPort.Text;
                _primServer.SendInfoByPoint(port, tBoxMsg.Text);
            }
            else if (string.IsNullOrEmpty(cboIpPort.Text))
            {
                _primServer.SendInfoByNetName("", tBoxMsg.Text);
            }
        } 
        #endregion


        #region UI更新
        /// <summary>
        /// IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxIP_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBoxIP.Text)) _primServer.BindIp = tBoxIP.Text;
        }
        /// <summary>
        /// 端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxPort_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBoxPort.Text)) _primServer.Port = tBoxPort.Text;
        }
        /// <summary>
        /// 心跳信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxHeartInfo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBoxHeartInfo.Text)) _primServer.HeartInfo = tBoxHeartInfo.Text;
        }
        /// <summary>
        /// 通知模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxNotifyMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxNotifyMode.SelectedIndex == 0)
                _primServer.NotifyMode = SktNotifyMode.DataEvent;
            else if (cBoxNotifyMode.SelectedIndex == 1) _primServer.NotifyMode = SktNotifyMode.DataQueue;
        }
        /// <summary>
        /// 发送队列数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxSendQueueCnt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBoxSendQueueCnt.Text))
                _primServer.SendQueueCnt = int.Parse(tBoxSendQueueCnt.Text);
        }
        /// <summary>
        /// 接收队列数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxRevQueueCnt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBoxRevQueueCnt.Text)) _primServer.RevQueueCnt = int.Parse(tBoxRevQueueCnt.Text);
        }
        /// <summary>
        /// 测试模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxDebug_CheckedChanged(object sender, EventArgs e)
        {
            _primServer.PrimDebug = cBoxDebug.Checked;
        }
        /// <summary>
        /// 基元名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxNetName_TextChanged(object sender, EventArgs e)
        {
            _primServer.NetName = tBoxNetName.Text;
        }
        /// <summary>
        /// 心跳标志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxHeart_CheckedChanged(object sender, EventArgs e)
        {
            _primServer.HeartFlag = cBoxHeart.Checked;
        }
        #endregion


        #region 通过委托进行更新
        /// <summary>
        /// 接收消息更新
        /// </summary>
        /// <param name="msg"></param>
        public void ShowRevMsg(string msg)
        {
            if (tBoxInfo.InvokeRequired)
            {
                var updateMsg = new UpdateRevMag(ShowRevMsg);
                tBoxInfo.Invoke(updateMsg, msg);
            }
            else
            {
                tBoxInfo.AppendText(msg + "\r\n");
            }
        }
        /// <summary>
        /// UI更新
        /// </summary>
        public void UpdateUI()
        {
            Action ac = () =>
            {
                cboIpPort.Items.Clear();
                foreach (var item in _primServer._listName)
                {
                    cboIpPort.Items.Add(item);
                }
            };
            this.Invoke(ac, null);
        }
        /// <summary>
        /// 连接状态更新
        /// </summary>
        /// <param name="state"></param>
        public void SetPrimConnState(PrimConnState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
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
        /// <summary>
        /// 运行状态更新
        /// </summary>
        /// <param name="state"></param>
        public void SetPrimRunState(PrimRunState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
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
        #endregion
    }
}