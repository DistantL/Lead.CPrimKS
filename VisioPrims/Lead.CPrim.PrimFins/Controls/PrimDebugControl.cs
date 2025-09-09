using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CommunicationBase;
using CommunicationBase.BasicFramework;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;

namespace Lead.CPrim.PrimFinsNet
{
    public partial class PrimDebugControl : UIUserControl
    {
        #region Field

        private readonly Prim _primFins; 
        #endregion



        #region Ctor
        public PrimDebugControl()
        {
            InitializeComponent();
            InitializeUI();
            SetStyleFlags();
        }
        public PrimDebugControl(Prim prim) : this()
        {
            _primFins = prim;
        }
        #endregion



        #region Prop
        public string PrimModbusTcpName
        {
            set => tTaskBoxName.Text = value;
        }
        #endregion



        #region Button_Event
        /// <summary>初始化</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            _primFins.IPrimInit();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            var result = "";
            _primFins.IPrimConnect(ref result);
            _primFins.IPrimStart();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            _primFins.IPrimStop();
        }


        #region Read
        /// <summary>读取short变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadShort_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadInt16(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取int变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadInt_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadInt32(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取long变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadLong_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadInt64(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取float变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadFloat_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadFloat(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取ushort变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadUShort_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadUInt16(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取uint变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadUInt_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadUInt32(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取ulong变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnULong_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadUInt64(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取double变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadDouble_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadDouble(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取bool变量</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCoil_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadBool(txtReadAddr.Text), txtReadAddr.Text, tBoxReadResult);
        }
        /// <summary>读取字符串</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadString_Click(object sender, EventArgs e)
        {
            readResultRender(_primFins._omronPlc.ReadString(txtReadAddr.Text, ushort.Parse(txtReadLength.Text)),
                txtReadAddr.Text, tBoxReadResult);
        }
        #endregion

        #region 写入
        /// <summary>short写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteShort_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteInt16(txtWriteAddr.Text, short.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteShort失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>int写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteInt_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteInt32(txtWriteAddr.Text, int.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteInt失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>long写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteLong_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteInt64(txtWriteAddr.Text, long.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteLong失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>float写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteFloat_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteFloat(txtWriteAddr.Text, float.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteFloat失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>ushort写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteUShort_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteUInt16(txtWriteAddr.Text, ushort.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteUShort失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>uint写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteUInt_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteUInt32(txtWriteAddr.Text, uint.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteUInt失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>ulong写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteULong_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteUInt64(txtWriteAddr.Text, ulong.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteULong失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>double写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteDouble_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteDouble(txtWriteAddr.Text, double.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteDouble失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>bool写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteCoil_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteBool(txtWriteAddr.Text, bool.Parse(txtWriteValue.Text)),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteCoil失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>string写入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteString_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            try
            {
                writeResultRender(_primFins._omronPlc.WriteString(txtWriteAddr.Text, txtWriteValue.Text),
                    txtWriteAddr.Text);
            }
            catch (Exception ex)
            {
                _primFins.LogAdd($"WriteString失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        #endregion

        private void btnReadBatch_Click(object sender, EventArgs e)
        {
            try
            {
                var read = _primFins._omronPlc.ReadRegister(tBoxReadBatchAddr.Text, ushort.Parse(tBoxReadBatchLength.Text));
                if (read.IsSuccess)
                {
                    //tBoxReadBathResult.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Result", "Result:") + SoftBasic.ByteToHexString(read.Content);
                    tBoxReadBathResult.Text = TransString(read.Content, 12, 20, Encoding.ASCII);
                    
                    
                }
                else
                {
                    MessageBox.Show(
                        NLocalizer.GetString("PrimModbusClient_PrimDebugControl_ReadFailed", "Read failed:") +
                        read.ToMessageShowString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(NLocalizer.GetString("PrimModbusClient_PrimDebugControl_ReadFailed", "Read failed:") +
                                ex.Message);
            }
        }
        public string TransString(byte[] buffer, int index, int length, Encoding encoding)
        {
            byte[] array = new byte[length];
            Array.Copy(buffer, index, array, 0, length);
            return _primFins._omronPlc.ReadString("", 0, array).Content;
        }
        private void btnReadMessage_Click(object sender, EventArgs e)
        {
            try
            {
                var read = _primFins._omronPlc.ReadFromCoreServer(SoftBasic.HexStringToBytes(tBoxMessage.Text));
                if (read.IsSuccess)
                    tBoxMessageResult.Text =
                        NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Result", "Result:") +
                        SoftBasic.ByteToHexString(read.Content);
                else
                    MessageBox.Show(
                        NLocalizer.GetString("PrimModbusClient_PrimDebugControl_ReadFailed", "Read failed:") +
                        read.ToMessageShowString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(NLocalizer.GetString("PrimModbusClient_PrimDebugControl_ReadFailed", "Read failed:") +
                                ex.Message);
            }
        }
        #endregion



        #region System_Event
        private void PrimDebugControl_Load(object sender, EventArgs e)
        {
            PrimModbusTcpName = _primFins.Name;
            SetPrimConnState(_primFins.PrimConnStat);
            SetPrimRunState(_primFins.PrimRunStat);
        } 
        #endregion



        #region Method_InternalUsing
        /// <summary>统一的读取结果的数据解析，显示</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        private void readResultRender<T>(OperateResult<T> result, string address, TextBox textBox)
        {
            if (result.IsSuccess)
            {
                textBox.Text = DateTime.Now.ToString("[HH:mm:ss]：") + $"{address} -> {result.Content}";
            }
            else
            {
                _primFins.LogAdd($"地址 {address} 读取失败", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>统一的数据写入的结果显示</summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void writeResultRender(OperateResult result, string address)
        {
            if (result.IsSuccess)
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + string.Format(
                    NLocalizer.GetString("PrimModbusClient_PrimDebugControl_WirttenSuccessfully",
                        "[{0}] successfully written"), address));
            else
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + string.Format(
                    NLocalizer.GetString("PrimModbusClient_PrimDebugControl_WriteFailureAndReason",
                        "[{0}] write failure{1}Reason:{2}"), address, Environment.NewLine,
                    result.ToMessageShowString()));
        }
        /// <summary>中英转换</summary>
        private void InitializeUI()
        {
            lbTitle.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_FinsNetDebug", "FinsNet Debug");
            label1.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_FinsNetName", "FinsNet Name");
            tabPage1.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_ReadDataDebug", "Debug1");
            tabPage2.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_ReadPacketDebug", "Debug2");
            groupBox1.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_SingleDataReadTest",
                "Single data read test");
            label6.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Address", "Addr:");
            label8.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Length", "Length:");
            groupBox3.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_BatchReadTest", "Batch read test");
            label11.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Address", "Addr:");
            label12.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Length", "Length:");
            btnReadBatch.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_BatchRead", "Batch Read");

            groupBox2.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_SingleDataWriteTest",
                "Single data write test");
            label10.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Address", "Addr:");
            label9.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Value", "Value:");
            btnPressureTest.Text =
                NLocalizer.GetString("PrimModbusClient_PrimDebugControl_StressTestThreeThousandTimes",
                    "Stress test, fast reading and writing 3000 times");

            groupBox.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Execute", "EXE");
            btnInit.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Initialize", "Init");
            btnRun.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Run", "Run");
            btnStop.Text = NLocalizer.GetString("PrimModbusClient_PrimDebugControl_Stop", "Stop");
        }
        /// <summary>权限确认</summary>
        /// <returns></returns>
        private bool VerifyAuthority()
        {
            return AuthorityManager.Instance.VerifyLevel3Permission(true);
        }
        #endregion




        #region 压力测试

        private int failed;

        private int thread_status;

        private DateTime thread_time_start = DateTime.Now;

        private void btnPressureTest_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            PressureTest2();
        }

        // 压力测试，开3个线程，每个线程进行读写操作，看使用时间
        private void PressureTest2()
        {
            thread_status = 3;
            failed = 0;
            thread_time_start = DateTime.Now;
            new Thread(thread_test2) {IsBackground = true}.Start();
            new Thread(thread_test2) {IsBackground = true}.Start();
            new Thread(thread_test2) {IsBackground = true}.Start();
            btnPressureTest.Enabled = false;
        }

        private void thread_end()
        {
            if (Interlocked.Decrement(ref thread_status) == 0)
                // 执行完成
                Invoke(new Action(() =>
                {
                    btnPressureTest.Enabled = true;
                    MessageBox.Show(
                        NLocalizer.GetString("PrimModbusClient_PrimDebugControl_TimeConsuming", "Time consuming：") +
                        (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine +
                        NLocalizer.GetString("PrimModbusClient_PrimDebugControl_FailureTimes", "Failure times：") +
                        failed);
                }));
        }

        private void thread_test2()
        {
            var count = 500;
            while (count > 0)
            {
                if (!_primFins._omronPlc.WriteInt16("100", 1234).IsSuccess) failed++;

                if (!_primFins._omronPlc.ReadInt16("100").IsSuccess) failed++;

                count--;
            }

            thread_end();
        }

        #endregion 压力测试

        #region 定时器测试

        private bool isThreadRun;

        // 外加曲线显示
        private Thread thread; // 后台读取的线程

        private int timeSleep = 300; // 读取的间隔
        // 用来标记线程的运行状态

        private void AddDataCurve(short data)
        {
            userCurve1.AddCurveData("A", data);
        }

        private void tBoxReadTimingStart_Click(object sender, EventArgs e)
        {
            // 启动后台线程，定时读取PLC中的数据，然后在曲线控件中显示

            if (!isThreadRun)
            {
                if (!int.TryParse(tBoxReadTimingInterval.Text, out timeSleep))
                {
                    MessageBox.Show(NLocalizer.GetString("PrimModbusClient_PrimDebugControl_IntervalFormatInputError",
                        "Interval format input error!"));
                    return;
                }

                tBoxReadTimingStart.Text = "Stop";
                isThreadRun = true;
                thread = new Thread(ThreadReadServer);
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                tBoxReadTimingStart.Text = "Start";
                isThreadRun = false;
            }
        }

        private void ThreadReadServer()
        {
            while (isThreadRun)
            {
                Thread.Sleep(timeSleep);

                try
                {
                    var read = _primFins._omronPlc.ReadInt16(tBoxReadTimingAddr.Text);
                    if (read.IsSuccess)
                        // 显示曲线
                        if (isThreadRun)
                            Invoke(new Action<short>(AddDataCurve), read.Content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        NLocalizer.GetString("PrimModbusClient_PrimDebugControl_ReadFailed", "Read failed:") +
                        ex.Message);
                }
            }
        }

        #endregion 定时器测试



        #region 框架内
        /// <summary>连接状态设置</summary>
        /// <param name="state">连接状态</param>
        public void SetPrimConnState(PrimConnState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
            if (InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                    case PrimConnState.Other:
                        tbConnState.BackColor = Color.Khaki;
                        tbConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnInit.Enabled = true;
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        break;
                    case PrimConnState.Connected:
                        tbConnState.BackColor = Color.LightGreen;
                        tbConnState.Text = "Connected";
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnRun.BackColor = Color.SkyBlue;
                        btnRun.Enabled = true;
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

            if (InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = "Idle";
                        break;
                    case PrimRunState.Running:
                        tbRunState.BackColor = Color.LightGreen;
                        tbRunState.Text = "Running";

                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Stop:
                        tbRunState.BackColor = Color.Brown;
                        tbRunState.Text = "Stop";

                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                    case PrimRunState.Err:
                        tbRunState.BackColor = Color.SandyBrown;
                        tbRunState.Text = "Err";

                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Other:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = "Idle";

                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }
        #endregion
    }
}