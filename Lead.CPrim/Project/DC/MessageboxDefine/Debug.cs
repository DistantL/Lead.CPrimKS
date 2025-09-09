using Automation;
using Lead.CPrim.CommonParam;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Robot;
using Lead.CPrim.PrimCommon;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageboxDefine
{
    public partial class Debug : Form
    {
        public delegate void Tray_Click_Del(string btn_text, Button btn);
        Button[] _buttons = new Button[24];
        public static Debug Instance = new Debug();
        LinkSF _sf = null;
        /// <summary>PDCA客户端基元</summary>
        ISktClient _sktClientPDCA;
        IPrim _sktClientPDCAManage;


        private Debug()
        {
            InitializeComponent();
        }

        private void Debug_Load(object sender, EventArgs e)
        {
            if (_sf == null) _sf = new LinkSF();
            tbPDCACode.Focus();

            //PDCA客户端
            {
                _sktClientPDCAManage = PrimsManager.Instance.GetPrimByName("PDCAClientC");
                _sktClientPDCAManage.IPrimTaskInit();
                _sktClientPDCA = (ISktClient)_sktClientPDCAManage;
                _sktClientPDCA.OnMsgReved -= PDCA_OnMsgReved;
                _sktClientPDCA.OnMsgReved += PDCA_OnMsgReved;
            }

            {
                /// <summary>汇川机械手</summary>
                _robotPrim = (IRobotInovance)PrimsManager.Instance.GetPrimByName("RobotInovance0");
            }

            {
                PrimsManager.Instance.GetPrimByName("SocketServer0").IPrimTaskInit();
                _skt = (ISktServer)PrimsManager.Instance.GetPrimByName("SocketServer0");
            }

            //动静态
            {
                moveButton = new Button[] { btnCameraUpDynamic, btnCameraUpStatic, btnCameraDownDynamic, btnCameraDownStatic };
            }
            timer1.Enabled = true;
        }

        private void Debug_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        #region SFL
        private void btnSFL_Click(object sender, EventArgs e)
        {
            try
            {
                string code = tbPDCACode.Text.Trim();
                if (string.IsNullOrEmpty(code))
                    throw new Exception("SFL二维码不能为空，请输入二维码");

                if (!SFLQuery(code))
                    throw new Exception("二维码查询失败");

                if (!SFLAdd(code))
                    throw new Exception("二维码过站失败");

                tbPDCACode.SelectAll();
                AddMessage(string.Format("ID={0}发送SFL成功", code));
            }
            catch (Exception ex)
            {
                AddMessage("SFL手动过站失败：" + ex.Message);
            }
        }
        #endregion


        #region PDCA
        private List<PDCAInfo> productInfos = new List<PDCAInfo>();
        private void AddMessage(string mes)
        {
            if (rtbPDCAMes.InvokeRequired)
            {
                BeginInvoke(new Action<string>(AddMessage), mes);
                return;
            }
            mes = $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}：{mes}\r\n";
            rtbPDCAMes.AppendText(mes);
            rtbPDCAMes.ScrollToCaret();
        }
        private void btnPDCA_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    string code = tbPDCACode.Text.Trim();
                    if (string.IsNullOrEmpty(code))
                        throw new Exception("PDCA二维码不能为空，请输入二维码");

                    double x = 0;
                    double y = 0;
                    double dt = 0;
                    if (!double.TryParse(tbX.Text.Trim(), out x))
                        throw new Exception("X转换失败");

                    if (!double.TryParse(tbY.Text.Trim(), out y))
                        throw new Exception("X转换失败");

                    if (!double.TryParse(tbDT.Text.Trim(), out dt))
                        throw new Exception("X转换失败");

                    _pdcaReceived = "";
                    PDCASend(code, x, y, dt);
                    Thread.Sleep(100);
                    if (SpinWait.SpinUntil(() => _pdcaReceived.StartsWith("ok@{}@"), 5000))
                        AddMessage(string.Format("ID={0}发送PDCA成功", code));
                    else
                        throw new Exception(string.Format("ID={0}发送PDCA超时", code));

                    tbPDCACode.SelectAll();
                }
                catch (Exception ex)
                {
                    AddMessage("PDCA手动过站失败：" + ex.Message);
                }
            });
        }
        private void btnManyPDCA_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                if (!FileHelper.OpenFileDialogMethod(ref path))
                {
                    return;
                }

                string ngPath = Path.Combine(path.Substring(0, path.LastIndexOf('\\')), "PDCA批量上传NG.csv");
                if(File.Exists(ngPath))
                {
                    File.Delete(ngPath);
                }
                List<string> list = new List<string>();
                if (!CsvHelper.ReadCsvToListString(path, Encoding.Default, true, out list))
                {
                    throw new Exception("CSV读取失败");
                }
                productInfos.Clear();
                foreach (var item in list)
                {
                    string[] strs = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if(strs.Length < 5)
                    {
                        continue;
                    }
                    PDCAInfo info = new PDCAInfo();
                    info.ID = strs[0].Trim();
                    info.X = double.TryParse(strs[1], out var x) ? x : 0.89;
                    info.Y = double.TryParse(strs[2], out var y) ? y : 1.16;
                    info.DT = double.TryParse(strs[3], out var dt) ? dt : 0;
                    info.Isload = strs[4].Trim().ToLower() == "ok" ? "ok" : "ng";
                    productInfos.Add(info);
                }
                Task.Run(() =>
                {
                    try
                    {
                        foreach (var item in productInfos)
                        {
                            if(item.Isload == "ok")
                            {
                                continue;
                            }

                            _pdcaReceived = "";
                            PDCASend(item.ID, item.X, item.Y, item.DT);
                            Thread.Sleep(100);
                            if (SpinWait.SpinUntil(() => _pdcaReceived.StartsWith("ok@{}@"), 5000))
                            {
                                AddMessage(string.Format("ID={0}发送PDCA成功", item.ID));
                            }
                            else
                            {
                                string data = $"{item.ID},{item.X},{item.Y},{item.DT},false";
                                CsvHelper.WriteStringToCsv(ngPath, data, true);
                                AddMessage(string.Format("ID={0}发送PDCA超时", item.ID));
                            }

                            tbPDCACode.SelectAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        AddMessage("PDCA手动过站失败：" + ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                AddMessage("PDCA手动批量过站失败：" + ex.Message);
            }
        }
        #endregion


        #region 动静态测试
        /// <summary>测试次数</summary>
        private int testCount = 1;
        /// <summary>机械手基元</summary>
        IRobotInovance _robotPrim;
        /// <summary>服务器基元</summary>
        ISktServer _skt;
        /// <summary>指令手</summary>
        int command = -1;
        /// <summary>上相机步骤号</summary>
        int stepUp = 0;
        /// <summary>上相机步骤号</summary>
        int stepUpStatic = 0;
        /// <summary>下相机步骤号</summary>
        int stepDown = 0;
        /// <summary>下相机步骤号</summary>
        int stepDownStatic = 0;
        /// <summary>取消标志</summary>
        CancellationTokenSource cts = new CancellationTokenSource();
        /// <summary>运行中标志</summary>
        static bool isRunning = false;
        /// <summary>按钮数组</summary>
        Button[] moveButton = new Button[4];
        /// <summary>拍照前延时</summary>
        decimal delay = 0;
        Stopwatch sw = new Stopwatch();


        /// <summary>上相机动态</summary>
        private void btnCameraUpDynamic_Click(object sender, EventArgs e)
        {
            try
            {
                isRunning = true;
                delay = numericUpDown1.Value;
                cts = new CancellationTokenSource();
                PcToRobot(10, 0);
                PcToRobot(11, 0);
                command = (int)RobotPos.安全位;
                PcToRobot(10, command);
                sw.Restart();
                while (RobotToPc(11, command) != 0)
                {
                    if(sw.ElapsedMilliseconds >= 10*1000)
                    {
                        throw new Exception("非正常结束");
                    }
                    Thread.Sleep(10);
                }
                Task.Run(() =>
                {
                    try
                    {
                        testCount = 1;
                        stepUp = 10;
                        while (testCount <= int.Parse(tbCount.Text.Trim()))
                        {
                            if (cts.IsCancellationRequested)
                            {
                                return;
                            }
                            Invoke(new Action(() =>
                            {
                                lbState.Text = $"当前是第{testCount}次测试";
                            }));
                            switch (stepUp)
                            {
                                case 10:
                                    #region 通知机械手移至【下相机拍照】
                                    command = (int)RobotPos.下相机拍照;
                                    if (PcToRobot(10, command) == 0)
                                    {
                                        stepUp = 20;
                                    }
                                    #endregion
                                    break;
                                case 20:
                                    #region 确认机械手到位
                                    if (RobotToPc(11, command) == 0)
                                    {
                                        stepUp = 100;
                                    }
                                    #endregion
                                    break;
                                case 100:
                                    #region 通知机械手移至【飞达拍照位】
                                    command = (int)RobotPos.飞达拍照位;
                                    if (PcToRobot(10, command) == 0)
                                    {
                                        stepUp = 110;
                                    }
                                    #endregion
                                    break;
                                case 110:
                                    #region 确认机械手到位
                                    if (RobotToPc(11, command) == 0)
                                    {
                                        stepUp = 200;
                                    }
                                    #endregion
                                    break;
                                case 200:
                                    #region 通知视觉进行拍照_引导取料
                                    _skt.SendInfoByNetName("", "CK,1,1,1,1,0,0,0,0,0,0,0;");
                                    stepUp = 210;
                                    #endregion
                                    break;
                                case 210:
                                    #region 延时
                                    Thread.Sleep((int)delay);
                                    stepUp = 10;
                                    testCount++;
                                    #endregion
                                    break;
                                default:
                                    break;

                            }
                            Thread.Sleep(10);
                        }
                    }
                    catch
                    {
                        isRunning = false;
                    }
                    finally
                    {
                        isRunning = false;
                    }
                    
                }, cts.Token);
            }
            catch (Exception ex)
            {
                isRunning = false;
                lbState.Text = $"测试失败：{ex.Message}";
            } 
        }
        /// <summary>上相机静态</summary>
        private void btnCameraUpStatic_Click(object sender, EventArgs e)
        {
            try
            {
                isRunning = true;
                delay = numericUpDown1.Value;
                cts = new CancellationTokenSource();
                PcToRobot(10, 0);
                PcToRobot(11, 0);
                command = (int)RobotPos.安全位;
                PcToRobot(10, command);
                while (RobotToPc(11, command) != 0)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                Task.Run(() =>
                {
                    try
                    {
                        testCount = 1;
                        stepUpStatic = 10;
                        while (testCount <= int.Parse(tbCount.Text.Trim()))
                        {
                            if (cts.IsCancellationRequested)
                            {
                                return;
                            }
                            Invoke(new Action(() =>
                            {
                                lbState.Text = $"当前是第{testCount}次测试";
                            }));
                            switch (stepUpStatic)
                            {
                                case 10:
                                    #region 通知机械手移至【飞达拍照位】
                                    command = (int)RobotPos.飞达拍照位;
                                    if (PcToRobot(10, command) == 0)
                                    {
                                        stepUpStatic = 110;
                                    }
                                    #endregion
                                    break;
                                case 110:
                                    #region 确认机械手到位
                                    if (RobotToPc(11, command) == 0)
                                    {
                                        stepUpStatic = 200;
                                    }
                                    #endregion
                                    break;
                                case 200:
                                    #region 通知视觉进行拍照_引导取料
                                    _skt.SendInfoByNetName("", "CK,1,1,1,1,0,0,0,0,0,0,0;");
                                    stepUpStatic = 210;
                                    #endregion
                                    break;
                                case 210:
                                    #region 延时
                                    Thread.Sleep((int)delay);
                                    stepUpStatic = 10;
                                    testCount++;
                                    #endregion
                                    break;
                                default:
                                    break;

                            }
                            Thread.Sleep(10);
                        }
                    }
                    catch
                    {
                        isRunning = false;
                    }
                    finally
                    {
                        isRunning = false;
                    }
                    
                }, cts.Token);
            }
            catch { } 
        }
        /// <summary>下相机动态</summary>
        private void btnCameraDownDynamic_Click(object sender, EventArgs e)
        {
            try
            {
                isRunning = true;
                delay = numericUpDown1.Value;
                cts = new CancellationTokenSource();
                PcToRobot(10, 0);
                PcToRobot(11, 0);
                command = (int)RobotPos.安全位;
                PcToRobot(10, command);
                while (RobotToPc(11, command) != 0)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                Task.Run(() =>
                {
                    try
                    {
                        testCount = 1;
                        stepDown = 10;
                        while (testCount <= int.Parse(tbCount.Text.Trim()))
                        {
                            if (cts.IsCancellationRequested)
                            {
                                return;
                            }
                            Invoke(new Action(() =>
                            {
                                lbState.Text = $"当前是第{testCount}次测试";
                            }));
                            switch (stepDown)
                            {
                                case 10:
                                    #region 通知机械手移至【下相机拍照】
                                    command = (int)RobotPos.下相机拍照;
                                    if (PcToRobot(10, command) == 0)
                                    {
                                        stepDown = 20;
                                    }
                                    #endregion
                                    break;
                                case 20:
                                    #region 确认机械手到位
                                    if (RobotToPc(11, command) == 0)
                                    {
                                        stepDown = 30;
                                    }
                                    #endregion
                                    break;
                                case 30:
                                    #region 通知视觉进行拍照_引导取料
                                    _skt.SendInfoByNetName("", "CK,2,1,1,1,0,0,0,0,0,0,0;");
                                    stepDown = 40;
                                    #endregion
                                    break;
                                case 40:
                                    #region 延时
                                    Thread.Sleep((int)delay);
                                    stepDown = 50;
                                    #endregion
                                    break;
                                case 50:
                                    #region 通知机械手移至【飞达拍照位】
                                    command = (int)RobotPos.飞达拍照位;
                                    if (PcToRobot(10, command) == 0)
                                    {
                                        stepDown = 60;
                                    }
                                    #endregion
                                    break;
                                case 60:
                                    #region 确认机械手到位
                                    if (RobotToPc(11, command) == 0)
                                    {
                                        stepDown = 10;
                                        testCount++;
                                    }
                                    #endregion
                                    break;
                                default:
                                    break;

                            }
                            Thread.Sleep(10);
                        }
                    }
                    catch (Exception)
                    {
                        isRunning = false;
                    }
                    finally
                    {
                        isRunning = false;
                    }
                    
                }, cts.Token);
            }
            catch { }
        }
        /// <summary>下相机静态</summary>
        private void btnCameraDownStatic_Click(object sender, EventArgs e)
        {
            try
            {
                isRunning = true;
                delay = numericUpDown1.Value;
                cts = new CancellationTokenSource();
                PcToRobot(10, 0);
                PcToRobot(11, 0);
                command = (int)RobotPos.安全位;
                PcToRobot(10, command);
                while (RobotToPc(11, command) != 0)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                Task.Run(() =>
                {
                    try
                    {
                        testCount = 1;
                        stepDownStatic = 10;
                        while (testCount <= int.Parse(tbCount.Text.Trim()))
                        {
                            if (cts.IsCancellationRequested)
                            {
                                return;
                            }
                            Invoke(new Action(() =>
                            {
                                lbState.Text = $"当前是第{testCount}次测试";
                            }));
                            switch (stepDownStatic)
                            {
                                case 10:
                                    #region 通知机械手移至【下相机拍照】
                                    command = (int)RobotPos.下相机拍照;
                                    if (PcToRobot(10, command) == 0)
                                    {
                                        stepDownStatic = 20;
                                    }
                                    #endregion
                                    break;
                                case 20:
                                    #region 确认机械手到位
                                    if (RobotToPc(11, command) == 0)
                                    {
                                        stepDownStatic = 30;
                                    }
                                    #endregion
                                    break;
                                case 30:
                                    #region 通知视觉进行拍照_引导取料
                                    _skt.SendInfoByNetName("", "CK,2,1,1,1,0,0,0,0,0,0,0;");
                                    stepDownStatic = 40;
                                    #endregion
                                    break;
                                case 40:
                                    #region 延时
                                    Thread.Sleep((int)delay);
                                    stepDownStatic = 10;
                                    testCount++;
                                    #endregion
                                    break;
                                default:
                                    break;

                            }
                            Thread.Sleep(10);
                        }
                    }
                    catch
                    {
                        isRunning = false;
                    }
                    finally
                    {
                        isRunning = false;
                    }
                    
                }, cts.Token);
            }
            catch { }
        }
        /// <summary>定时器</summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //动静态
            {
                moveButton.ToList().ForEach(p => p.Enabled = !isRunning);
            }
        }
        /// <summary>双击停止</summary>
        private void lbCount_DoubleClick(object sender, EventArgs e)
        {
            cts.Cancel();
        }
        #endregion


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region PDCA客户端
        private string _pdcaReceived = "";
        private string _currentCode = null;
        private void PDCA_OnMsgReved(string send, object context)
        {
            try
            {
                //打印收到信息
                string data = context.ToString();

                if (string.IsNullOrEmpty(data))
                    return;

                _pdcaReceived = data;
                string PDCA_Path = @"D:\CPrimlog\PDCA_Log\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\";
                if (!Directory.Exists(PDCA_Path))
                    Directory.CreateDirectory(PDCA_Path);

                if (string.IsNullOrEmpty(_currentCode))
                    _currentCode = DateTime.Now.ToString("yyyyMMddHHmmss");

                PDCA_Path += _currentCode + ".log";
                WriteLog(PDCA_Path, data);
                AddMessage(data);
            }
            catch (Exception ex)
            {
                AddMessage("扫码返回数据出现异常：" + ex.Message);
            }
        }
        private void PDCASend(string SN, double x, double y, double dt)
        {
            string str = UpToPdca(SN, x, y, dt);
            string PDCA_Path = @"D:\CPrimlog\PDCA_Log\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\";
            if (!Directory.Exists(PDCA_Path))
                Directory.CreateDirectory(PDCA_Path);

            PDCA_Path += SN + ".log";
            WriteLog(PDCA_Path, str);
            AddMessage(str);
            _currentCode = SN;
            _sktClientPDCA.SendInfo("", str);
        }
        #endregion

        #region 相关方法
        private string UpToPdca(string BC_SN, double x, double y, double dt)//SN@功能@名称@值@下限@上限@单位
        {
            string sourceDirPath = @"E:\Image\" + DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MMdd") + @"\" + BC_SN;
            if (!Directory.Exists(sourceDirPath))
                Directory.CreateDirectory(sourceDirPath);
            CopyPictureToMacMini(BC_SN);
            #region PDCA上传项                
            StringBuilder cmdAll = new StringBuilder();
            cmdAll.Append("{\n");
            int snLeng = BC_SN.Length > 17 ? 17 : BC_SN.Length;
            string UPSN = BC_SN.Substring(0, snLeng);
            string picFilePath = @"smb://" + CommonParam.Instance.PDCA_IP + @"/PDCA/" + BC_SN + ".zip";
            cmdAll.Append(UPSN + "@start\n");
            cmdAll.Append(UPSN + "@attr@SN@" + BC_SN + "\n");
            cmdAll.Append(UPSN + "@attr@AssemStatus@" + "True" + "\n");
            cmdAll.Append(UPSN + "@attr@AssemNum@" + "R100071-001" + "\n");
            cmdAll.Append(UPSN + "@pdata@X@" + x + "\n");
            cmdAll.Append(UPSN + "@pdata@Y@" + y + "\n");
            cmdAll.Append(UPSN + "@pdata@DT@" + dt + "@@@deg\n");
            cmdAll.Append(UPSN + "@attr@Version@" + (string)CommonParam.Instance.视觉软件版本 + "\n");//视觉软件版本
            cmdAll.Append(UPSN + "@log_file@" + picFilePath + "@user@1\n");
            cmdAll.Append(UPSN + "@dut_pos@" + (string)CommonParam.Instance.设备编号 + "@A5\n");//设备编号
            cmdAll.Append(UPSN + "@attr@Station@" + (string)CommonParam.Instance.设备名称 + "\n");//站名(设备名称)
            cmdAll.Append(UPSN + "@submit@" + (string)CommonParam.Instance.软件版本 + "\n");//软件版本
            cmdAll.Append("}\n");
            return cmdAll.ToString();
            #endregion

        }
        private bool CopyPictureToMacMini(string BCSN)
        {
            bool ret = false;
            string sourceDirPath = @"E:\Image\" + DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MMdd") + @"\" + BCSN;
            string saveDirPath = @"//" + CommonParam.Instance.PDCA_IP + @"/PDCA/" + BCSN + ".zip";
            try
            {
                if (Directory.Exists(sourceDirPath))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        try
                        {
                            if (!Directory.Exists(Path.GetDirectoryName(saveDirPath)))
                                Directory.CreateDirectory(Path.GetDirectoryName(saveDirPath));
                            if (File.Exists(saveDirPath)) File.Delete(saveDirPath);
                            System.IO.Compression.ZipFile.CreateFromDirectory(sourceDirPath, saveDirPath);
                            /*
                            string str1 = "";
                            if (ZipFile(sourceDirPath, saveDirPath, out str1))
                            {
                                ret = true;
                                break;
                            }
                            */
                            ret = true;
                            break;
                        }
                        catch
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                    }
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        #endregion


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region SFL上传操作
        object objSfl = new object();
        public SflReturnDataType SflSendInfo(object objData, string mesInfo, string removeStr = "")//例如："errcode,不需要"
        {
            SflReturnDataType sflReturn = null;
            string sflPath = @"D:\CPrimlog\SFL_Log\" + DateTime.Now.ToString("yyyy-MM-dd") + @"\";
            if (!Directory.Exists(sflPath))
                Directory.CreateDirectory(sflPath);
            lock (objSfl)
            {
                try
                {
                    if (objData is SflQueryDataType || objData is SflAddDataType)
                    {
                        string str = JsonHelper.SerializeObject(objData);
                        string retStr = "";
                        str = "[" + str + "]";
                        if (removeStr != "")
                        {
                            string s = string.Format(",\r\n  \"{0}\": \"{1}\"", removeStr.Split(',')[0], removeStr.Split(',')[1]);
                            str = str.Replace(s, "");// "errcode,不需要"1
                        }
                        if (objData is SflQueryDataType)
                        {
                            retStr = _sf.Query(str);
                            sflPath += ((SflQueryDataType)objData).sn + ".txt";
                        }
                        else if (objData is SflAddDataType)
                        {
                            retStr = _sf.ADD(str);
                            sflPath += ((SflAddDataType)objData).sn + ".txt";
                        }
                        sflReturn = JsonHelper.DeserializeJsonToObject<SflReturnDataType>(retStr);
                        WriteLog(sflPath, "SFL发送→\r\n" + str);
                        AddMessage("SFL发送→\r\n" + str);
                        WriteLog(sflPath, "SFL接收←\r\n" + retStr);
                        AddMessage("SFL接收←\r\n" + retStr);
                    }
                }
                catch
                {

                }

            }
            return sflReturn;
        }
        public bool SFLQuery(string SN)
        {
            bool brtn = false;
            SflQueryDataType varTemp = new SflQueryDataType()
            {
                sn = SN,
                line = CommonParam.Instance.线体,
                station = "DC-Shield to Magnet Press",
                app = "PQC",
                fixid = "",
                barcode = "",
                p = "checkrouting",
                carrier = "",
                errcode = "PASS",
            };
            SflReturnDataType retData = SflSendInfo(varTemp, "CheckPCBRouting:查询上个动作过站");
            if (retData.Result == "OK" && retData.Info != null && retData.Info[0].msg.Contains("checkrouting=OK"))
                brtn = true;
            return brtn;
        }
        public bool SFLAdd(string SN)
        {
            bool brtn = false;
            SflAddDataType varTemp1 = new SflAddDataType()
            {
                sn = SN,
                line = CommonParam.Instance.线体,
                station = "DC-Shield to Magnet Press",
                app = "PQC",
                fixid = (string)CommonParam.Instance.设备编号,
                barcode = "",
                carrier = "",
                errcode = "PASS",
            };
            var retData = SflSendInfo(varTemp1, "TransferNopart:本站过站");
            if (retData.Result == "OK" && retData.Info != null && retData.Info[0].msg.Contains("OK"))
                brtn = true;
            return brtn;
        }
        public bool sflLinkIsOK(string BC_SN, string ANT_SN)
        {
            bool brtn = false;
            #region 已屏蔽
            //#region 查询前站是否OK
            //SflQueryDataType varTemp = new SflQueryDataType()
            //{
            //    sn = BC_SN,
            //    line = CommonParam.Instance.线体,
            //    station = "Link BCM-ANT",
            //    app = "PTL",
            //    fixid = "",
            //    barcode = "",
            //    p = "checkrouting",
            //    carrier = "",
            //    errcode = "PASS",
            //};
            //SflReturnDataType retData = SflSendInfo(varTemp, "CheckLinkRouting:查上一站过站");
            //if (retData.Result == "OK" && retData.Info != null && retData.Info[0].msg.Contains("checkrouting=OK"))
            //{

            //    _task.Log("SFL查询成功", LogLevel.Info);
            //}
            //else
            //{
            //    _task.Log("SFL查询失败", LogLevel.Info);
            //    return brtn;
            //}
            //#endregion

            //#region 查询是否可以LINK
            //varTemp = new SflQueryDataType()
            //{
            //    sn = BC_SN,
            //    line = CommonParam.Instance.线体,
            //    station = "Link BCM-ANT",
            //    app = "PTL",
            //    fixid = "",
            //    barcode = "BCM ANT|" + ANT_SN,
            //    p = "checkcomp,complist",
            //    carrier = "",
            //    errcode = "不需要",
            //};
            //retData = SflSendInfo(varTemp, "CheckBom:查询是否可以绑定", "errcode,不需要");
            //if (retData.Result == "OK" && retData.Info != null && retData.Info[0].msg.Contains("checkcomp=OK"))
            //{
            //    _task.Log("SFL查询是否可以LINGK成功", LogLevel.Info);
            //}
            //else
            //{
            //    _task.Log("SFL查询失败", LogLevel.Info);
            //    return brtn;
            //}
            //#endregion

            //#region LINK操作
            //SflAddDataType varTemp1 = new SflAddDataType()
            //{
            //    sn = BC_SN,
            //    line = CommonParam.Instance.线体,
            //    station = "Link BCM-ANT",
            //    app = "PTL",
            //    fixid = "",
            //    barcode = "BCM ANT|" + ANT_SN,
            //    carrier = "N/A",
            //    errcode = "不需要",
            //};
            //retData = SflSendInfo(varTemp1, "Transfer:执行绑定", "errcode,不需要");
            //if (retData.Result == "OK" && retData.Info != null && retData.Info[0].msg.Contains("OK"))
            //{
            //    _task.Log("SFL执行LINGK成功", LogLevel.Info);
            //}
            //else
            //{
            //    _task.Log("SFL执行LINGK失败", LogLevel.Info);
            //    return brtn;
            //}
            //#endregion 
            #endregion

            #region 查询当站工艺
            SflQueryDataType varTemp = new SflQueryDataType()
            {
                sn = BC_SN,
                line = CommonParam.Instance.线体,
                station = "DC-Shield to Magnet Press",
                app = "PQC",
                fixid = "",
                barcode = "",
                p = "checkrouting",
                carrier = "",
                errcode = "PASS",
            };
            SflReturnDataType retData = SflSendInfo(varTemp, "CheckPCBRouting:查询上个动作过站");
            if (retData.Result == "OK" && retData.Info != null && retData.Info[0].msg.Contains("checkrouting=OK"))
            {
                //_task.Log("SFL查询成功", LogLevel.Info);
            }
            else
            {
                //_task.Log("SFL查询失败", LogLevel.Info);
                return brtn;
            }
            #endregion

            #region 当站过站
            SflAddDataType varTemp1 = new SflAddDataType()
            {
                sn = BC_SN,
                line = CommonParam.Instance.线体,
                station = "DC-Shield to Magnet Press",
                app = "PQC",
                fixid = (string)CommonParam.Instance.设备编号,
                barcode = "",
                carrier = "",
                errcode = "PASS",
            };
            retData = SflSendInfo(varTemp1, "TransferNopart:本站过站");
            if (retData.Result == "OK" && retData.Info != null && retData.Info[0].msg.Contains("OK"))
            {
                //_task.Log("SFL上传成功", LogLevel.Info);
                brtn = true;
            }
            else
            {
                //_task.Log("SFL上传失败", LogLevel.Info);
            }
            #endregion

            return brtn;
        }
        #endregion

        #region SFL上传相关
        /// <summary>
        /// 查询数据类型
        /// </summary>
        public class SflQueryDataType
        {
            public string sn { get; set; }
            public string line { get; set; }
            public string station { get; set; }
            public string app { get; set; }
            public string fixid { get; set; }
            public string barcode { get; set; }
            public string p { get; set; }
            public string carrier { get; set; }
            public string errcode { get; set; }
        }
        /// <summary>
        /// 上传过站数据类型
        /// </summary>
        public class SflAddDataType
        {
            public string sn { get; set; }
            public string line { get; set; }
            public string station { get; set; }
            public string app { get; set; }
            public string fixid { get; set; }
            public string barcode { get; set; }
            public string carrier { get; set; }
            public string errcode { get; set; }
        }

        /// <summary>
        /// 返回数据类型
        /// </summary>
        public class SflReturnDataType
        {
            public string Result { get; set; }
            public List<mesInfo> Info { get; set; }
        }
        public class mesInfo
        {
            public string msg { get; set; }
        }
        #endregion


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region 日志相关
        private void WriteLog(string path, string msg)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(msg);
                sw.WriteLine();
            }
        }

        #endregion


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region 机械手方法
        /// <summary>
        /// 机械手报错字典
        /// </summary>
        private Dictionary<int, RobotAlarm> _dicRobotAlarm = new Dictionary<int, RobotAlarm>();
        /// <summary>
        /// 任务号发送给机械手
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="command">指令</param>
        /// <returns></returns>
        private int PcToRobot(int address, int command)
        {
            return _robotPrim.WriteBVar(address, command);
        }
        /// <summary>
        /// 任务号_机械手收到
        /// </summary>
        /// <param name="address"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private int RobotToPc(int address, int command)
        {
            int result = -1;
            int ret = _robotPrim.ReadBVar(address, out result);
            if (ret == 0)
            {
                if (result == command)
                {
                    if (PcToRobot(address, 0) != 0)
                    {
                        return -10;
                    }
                }
                else
                {
                    return -10;
                }
            }
            return ret;
        }
        /// <summary>
        /// 读偏移值
        /// </summary>
        /// <param name="ov"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private int ReadD(offsetVison ov, ref double offset)
        {
            //直接进行读取
            return _robotPrim.ReadDVar((int)ov, out offset); ;
        }
        /// <summary>写偏移值</summary>
        /// <param name="ov"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private int WriteD(offsetVison ov, double offset)
        {
            //先读取=0，然后再进行写入
            double result = -1;
            int ret = ReadD(ov, ref result);
            if (ret == 0)
            {
                if (result == 0)
                {
                    ret = _robotPrim.WriteDVar((int)ov, offset);
                }
            }
            return ret;
        }
        /// <summary>
        /// 机械手变量
        /// </summary>
        public enum offsetVison
        {
            X = 10,
            Y = 11,
            A = 12,
        }

        /// <summary>
        /// 获取机械手报警信息
        /// </summary>
        /// <returns></returns>
        private int GetRobotAlarm()
        {
            int ret = -1;
            _dicRobotAlarm.Clear();
            for (int i = (int)RobotAlarm.Min + 1; i < (int)RobotAlarm.Max; i++)
            {
                _dicRobotAlarm.Add(i, (RobotAlarm)i);
            }
            ret = 0;
            return ret;
        }
        #endregion

        #region 机械手信息
        /// <summary>
        /// 机械手报警
        /// </summary>
        private enum RobotAlarm
        {
            Min = -1,
            清除报警 = 0,
            升降气缸伸位错误,
            升降气缸缩位错误,
            真空吸错误 = 3,
            真空破错误,
            ROB运动过程掉料,
            机械手返回任务号错误 = 6,
            Max,
        }

        public enum RobotPos
        {
            安全位 = 1,
            飞达拍照位 = 3,
            飞达取料 = 4,
            撕膜位,
            撕膜上升位 = 6,
            下相机拍照 = 7,
            NG位 = 8,
            A线上相机拍照位 = 9,
            A线组装位 = 10,
            B线上相机拍照位 = 11,
            B线组装位 = 12,
            九点标定中心位 = 13,
            九点标定第1点 = 14,
            九点标定第9点 = 22,
            旋转标定中心位 = 23,
            旋转标定第1点 = 24,
            旋转标定第5点 = 28,
            关系标定下相机A线 = 29,
            关系标定上相机A线 = 30,
            关系标定下相机B线 = 31,
            关系标定上相机B线 = 32,
            飞达取料上放点 = 33,
            A线组装上方点 = 34,
            B线组装上方点 = 35,
            B线安全位 = 36,
            动静态拍照位1,
            动静态拍照位2,
        }
        #endregion
    }


    public class PDCAInfo
    {
        public string ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double DT { get; set; }
        public string Isload { get; set; }
    }
}
