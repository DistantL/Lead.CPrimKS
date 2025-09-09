using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.PrimYouShangRFID
{
    public partial class PrimConfigControl : UserControl
    {
        private readonly PrimRFID _primRFID;

        public PrimConfigControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        public PrimConfigControl(PrimRFID prim)
        {
            InitializeComponent();
            InitializeUI();
            _primRFID = prim;
        }

        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            if (_primRFID != null)
            {
                tbPrimName.Text = _primRFID.Name;
                tbIP.Text = _primRFID.Ip;
                tbPort.Text = _primRFID.Port.ToString();
                tbReConnCnt.Text = _primRFID.ReTries.ToString();
                SetPrimRunState(_primRFID.PrimRunStat);
                SetPrimConnState(_primRFID.PrimConnStat);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                int iRet = _primRFID.IPrimInit();
                if (iRet != 0)
                {
                    throw new Exception($"IPrimInit返回值 =》 {iRet}");
                }
                string result = "";
                iRet = _primRFID.IPrimConnect(ref result);
                if (iRet != 0)
                {
                    throw new Exception($"IPrimConnect返回值 =》 {iRet}");
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError("初始化失败，失败原因：" + ex.Message);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = 0;
                ret = _primRFID.IPrimStart();
                if (ret != 0)
                {
                    throw new Exception("停止失败，返回值 =》 " + ret);
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError("运行失败，失败原因：" + ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = 0;
                ret = _primRFID.IPrimTaskStop();
                if (ret != 0)
                {
                    throw new Exception("停止失败，返回值 =》 " + ret);
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError("停止失败，失败原因：" + ex.Message);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbIP.Text.Trim()))
                {
                    _primRFID.Ip = tbIP.Text;
                }
                if (!string.IsNullOrEmpty(tbPort.Text.Trim()))
                {
                    PrimRFID primRFID = _primRFID;
                    if (!int.TryParse(tbPort.Text, out var value2))
                    {
                        throw new Exception("Port =》 int 失败");
                    }
                    primRFID.Port = value2;
                }
                if (!string.IsNullOrEmpty(tbPrimName.Text))
                {
                    _primRFID.Name = tbPrimName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(tbReConnCnt.Text))
                {
                    PrimRFID primRFID2 = _primRFID;
                    if (!int.TryParse(tbReConnCnt.Text, out var value))
                    {
                        throw new Exception("ReTries =》 int 失败");
                    }
                    primRFID2.ReTries = value;
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError("应用失败 -> " + ex.Message);
            }
        }

        public void SetPrimName(string name)
        {
            tbPrimName.SetText(name);
        }

        public void SetPrimConnState(PrimConnState state)
        {
            if (!base.Created || !base.IsHandleCreated)
            {
                return;
            }
            if (tbConnState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else if ((int)state != 0)
            {
                if ((int)state == 1 || (int)state == 100)
                {
                    tbConnState.BackColor = Color.Khaki;
                    tbConnState.Text = "UnConnected";
                    btnInit.BackColor = Color.SkyBlue;
                    btnRun.BackColor = Color.Gray;
                    btnInit.Enabled = true;
                    btnRun.Enabled = false;
                }
            }
            else
            {
                tbConnState.BackColor = Color.LightGreen;
                tbConnState.Text = "Connected";
                btnInit.BackColor = Color.Gray;
                btnInit.Enabled = false;
            }
        }

        public void SetPrimRunState(PrimRunState state)
        {
            if (!base.Created || !base.IsHandleCreated)
            {
                return;
            }
            if (tbRunState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
                return;
            }
            switch ((int)state)
            {
                default:
                    if ((int)state == 100)
                    {
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = "Idle";
                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                    }
                    break;
                case 0:
                    tbRunState.BackColor = Color.Khaki;
                    tbRunState.Text = "Idle";
                    break;
                case 1:
                    tbRunState.BackColor = Color.LightGreen;
                    tbRunState.Text = "Running";
                    btnRun.BackColor = Color.Gray;
                    btnRun.Enabled = false;
                    btnInit.BackColor = Color.Gray;
                    btnInit.Enabled = false;
                    btnStop.Enabled = true;
                    btnStop.BackColor = Color.SandyBrown;
                    break;
                case 3:
                    tbRunState.BackColor = Color.Brown;
                    tbRunState.Text = "Stop";
                    btnInit.BackColor = Color.LightGreen;
                    btnInit.Enabled = true;
                    btnRun.BackColor = Color.Gray;
                    btnRun.Enabled = true;
                    btnStop.Enabled = false;
                    btnStop.BackColor = Color.Gray;
                    break;
                case 4:
                    tbRunState.BackColor = Color.SandyBrown;
                    tbRunState.Text = "Err";
                    btnStop.Enabled = true;
                    btnStop.BackColor = Color.SandyBrown;
                    break;
                case 2:
                    break;
            }
        }

        public void ShowRevMsg(string msg)
        {
            if (base.Created && base.IsHandleCreated)
            {
                if (tb_ReadInfo.InvokeRequired)
                {
                    BeginInvoke(new Action<string>(ShowRevMsg), msg);
                }
                else
                {
                    tb_ReadInfo.AppendText(msg + "\r\n");
                }
            }
        }

        private void InitializeUI()
        {
            lbTitle.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_SocketClientConfig", "Socket Client Config");
            label1.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_ClientName", "Client Name");
            tabPage1.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Config", "Config");
            tabPage2.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Debug", "Debug");
            label2.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_IP", "IP:");
            label3.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Port", "Port:");
            label9.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_ReConnectCount", "ReConnect Cnt:");
            groupBox.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Execute", "EXE");
            btnInit.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Initialize", "Init");
            btnRun.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Run", "Run");
            btnStop.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Stop", "Stop");
            btnApply.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_Apply", "Apply");
            label5.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_DataReceive", "Data Rev:");
            label4.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_DataSend", "Data Send:");
            bt_Write.Text = ProxyTools.NLocalizer.GetString("PrimSktClient_PrimConfigControl_SendMessage", "Send Msg");
            //cb_Debug.Text = ProxyTools.ProxyTools.GetString("PrimSktClient_PrimConfigControl_DebugEnable", "DebugEnable");
        }

        private void cb_RF1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_RF1.Focused == true)
            {
                cb_RF2.Checked = false;
                cb_RF3.Checked = false;
                cb_RF4.Checked = false;
            }
        }

        private void cb_RF2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_RF2.Focused == true)
            {
                cb_RF1.Checked = false;
                cb_RF3.Checked = false;
                cb_RF4.Checked = false;
            }
        }

        private void cb_RF3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_RF3.Focused == true)
            {
                cb_RF1.Checked = false;
                cb_RF2.Checked = false;
                cb_RF4.Checked = false;
            }
        }

        private void cb_RF4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_RF4.Focused == true)
            {
                cb_RF1.Checked = false;
                cb_RF2.Checked = false;
                cb_RF3.Checked = false;
            }
        }

        private void bt_Read_Click(object sender, EventArgs e)
        {
            int datanum; int index;
            if (cb_RF1.Checked == true)
            {
                index = 0;
            }
            else if (cb_RF2.Checked == true)
            {
                index = 1;
            }
            else if (cb_RF3.Checked == true)
            {
                index = 2;
            }
            else
            {
                index = 3;
            }
            try
            {
                if (!int.TryParse(tb_ReadByteNum.Text, out datanum))
                {
                    MessageBox.Show("请设置[需要读入数据个数]");
                    return;
                }
                if (datanum > 140 || datanum <= 0)
                {
                    MessageBox.Show("请设置[需要读入数据个数]的数据在(0,140)之间");
                    return;
                }

                if (_primRFID.EnableRfid(index) == 0)
                {
                    string txt = _primRFID.ReadRfid(index, (ushort)datanum);
                    tb_ReadInfo.Text = txt;
                }
                else
                {
                    MessageBox.Show($"使能失败{index}");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("读参数失败 => " + ex.Message);
            }
        }

        private void bt_Write_Click(object sender, EventArgs e)
        {
            int datanum; int index;
            if (cb_RF1.Checked == true)
            {
                index = 0;
            }
            else if (cb_RF2.Checked == true)
            {
                index = 1;
            }
            else if (cb_RF3.Checked == true)
            {
                index = 2;
            }
            else
            {
                index = 3;
            }
            try
            {
                if (tb_WriteInfo.Text == null)
                {
                    MessageBox.Show("写数据窗口无数据");
                    return;
                }

                datanum = tb_WriteInfo.Text.Length;

                if (datanum > 140 || datanum <= 0)
                {
                    MessageBox.Show("请将写入数据的长度控制在(0,140)之间");
                    return;
                }

                int i = _primRFID.WriteRifd(index, tb_WriteInfo.Text);
                if (i == 0)
                {
                    MessageBox.Show("写入成功！");
                }
                else
                {
                    MessageBox.Show("写入失败！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("读参数失败 => " + ex.Message);
            }
        }
    }
}
