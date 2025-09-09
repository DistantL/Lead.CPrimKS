using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using CommonStruct.Type3D;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Sensor3d;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ProxyTools.Win32;
using Sunny.UI.Win32;

namespace Lead.CPrim.PrimSSZN
{
    public class Prim : IPrim, IPrimSensor3d
    {
        #region Feilds
        private Config _config;

        /// <summary>
        /// 连接状态
        /// </summary>
        PrimConnState _primConnStat;

        /// <summary>
        /// 运行状态
        /// </summary>
        PrimRunState _primRunStat;

        /// <summary>
        /// x方向数据数量
        /// </summary>
        int m_XPoints = 3200;

        /// <summary>
        /// x方向点间距
        /// </summary>
        double m_XPitch = 0.02;

        /// <summary>
        /// 批处理数量
        /// </summary>
        int m_BatchPoints = 0;

        /// <summary>
        /// 点云数据
        /// </summary>
        private readonly List<int[]>[] _laserData;

        /// <summary>
        /// 点云数量
        /// </summary>
        private int[] _laserDataCount;



        /********回调***********/
        /// <summary>
        /// 高速回调
        /// </summary>
        private HighSpeedDataCallBack _callback;

        /// <summary>
        /// 一次回调
        /// </summary>
        private SR7IF_BatchOneTimeCallBack batchOneTimeCallBack;

        /// <summary>
        /// 一次回调完成<br/>
        /// 1：完成
        /// </summary>
        public int bBatchFinish = 0;

        static int m_curBatchNo = 0;                   //回调函数中用到--当前批处理行数编号
        static int m_BatchWidth = 0;                   //回调中轮廓宽度
        static int BatchCallBackPoint = 0;             //回调中当前批处理总行数
        static bool b_MemoryErr = false;                    //内存不足

        /// <summary>
        /// 高度数据缓存
        /// </summary>
        public int[][] HeightData = new int[2][] { null, null };

        /// <summary>
        /// 灰度数据缓存
        /// </summary>
        public byte[][] GrayData = new byte[2][] { null, null };

        /// <summary>
        /// 编码器数据缓存
        /// </summary>
        public int[][] EncoderData = new int[2][] { null, null };

        /// <summary>
        /// 控制最大数量
        /// </summary>
        public const int DeviceNo = 6;
        #endregion



        #region Ctor

        public Prim()
        {
            _config = new Config();

            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            _laserData = new List<int[]>[2];
            _laserDataCount = new int[2];
            for (var i = 0; i < 2; i++)
            {
                _laserData[i] = new List<int[]>();
            }

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
        }

        public Prim(XmlNode xmlNode)
        {
            _config = XMLHelper.XMLToObject(xmlNode, typeof(Config)) as Config;
            if (_config == null)
            {
                throw new NullReferenceException(NLocalizer.ConfigIsNullPleaseCheckPrimsConfigsXMLFile);
            }

            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

            _laserData = new List<int[]>[2];
            _laserDataCount = new int[2];
            for (var i = 0; i < 2; i++)
            {
                _laserData[i] = new List<int[]>();
            }

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
        }
        #endregion



        #region Prop
        /// <summary>
        /// 控制器数量
        /// </summary>
        public int DeviceCount
        {
            set => _config.DeviceCount = value;
            get => _config.DeviceCount;
        }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string[] DeviceName
        {
            set => _config.DeviceName = value;
            get => _config.DeviceName ?? (_config.DeviceName = new string[DeviceNo]);
        }

        /// <summary>
        /// 控制器IP
        /// </summary>
        public string[] IpAddress
        {
            set => _config.IpAddress = value;
            get => _config.IpAddress ?? (_config.IpAddress = new string[DeviceNo]);
        }

        /// <summary>
        /// 程序编号
        /// </summary>
        public byte[] KeyProNO
        {
            set => _config.KeyProNO = value;
            get => _config.KeyProNO ?? (_config.KeyProNO = new byte[DeviceNo]);
        }

        /// <summary>
        /// 批处理个数
        /// </summary>
        public int[] BatchPointNum
        {
            set => _config.BatchPointNum = value;
            get => _config.BatchPointNum ?? (_config.BatchPointNum = new int[DeviceNo]);
        }

        /// <summary>
        /// X点间距
        /// </summary>
        public double[] IntervalX
        {
            set => _config.IntervalX = value;
            get => _config.IntervalX ?? (_config.IntervalX = new double[DeviceNo]);
        }

        /// <summary>
        /// Y点间距
        /// </summary>
        public double[] IntervalY
        {
            set => _config.IntervalY = value;
            get => _config.IntervalY ?? (_config.IntervalY = new double[DeviceNo]);
        }

        /// <summary>
        /// 每行点个数
        /// </summary>
        public int[] RowPointNum
        {
            set => _config.RowPointNum = value;
            get => _config.RowPointNum ?? (_config.RowPointNum = new int[DeviceNo]);
        }

        /// <summary>
        /// 回调返回行数
        /// </summary>
        internal int CallbackLineCount
        {
            set => _config.CallbackLineCount = value;
            get => _config.CallbackLineCount;
        }

        public bool[] DeviceEnable
        {
            set => _config.DeviceEnable = value;
            get => _config.DeviceEnable;
        }

        public CallBackMethod CallBackMethod
        {
            set
            {
                if (_config.CallBackMethod != value)
                {
                    _config.CallBackMethod = value;
                }
            }
            get => _config.CallBackMethod;
        }

        internal bool DebugMode
        {
            set; get;
        }

        public PrimManufacture Manu { get; set; }

        public bool PrimSimulator { get; set; }

        public bool PrimDebug { get; set; }

        public bool LogEnable { get; set; }

        public LogLevel PrimAlarmLv { get; set; }

        public RunMode PrimRunMode { get; set; }

        #endregion



        #region Override IPrim
        public Guid Id
        {
            set => _config.Id = value;
            get => _config.Id;
        }
        public string Name
        {
            get => _config.Name;
            set
            {
                if (_config.Name != value)
                {
                    LogAddAuthority($"Name > {_config.Name} > {value}", LogLevel.Trace);
                    ((PrimConfigControl)PrimConfigUI).SetPrimName(value);
                    _config.Name = value;
                }
            }
        }
        public bool PrimEnable
        {
            set => _config.PrimEnable = value;
            get => _config.PrimEnable;
        }
        public PrimType HSType { set; get; } = PrimType.Camera;
        public string PrimTypeName
        {
            set => _config.PrimTypeName = value;
            get => _config.PrimTypeName;
        }
        public Control PrimConfigUI { get; }
        public Control PrimDebugUI { get; }
        public Control PrimOutputUI { get; }
        public PrimConnState PrimConnStat
        {
            set
            {
                if (_primConnStat != value)
                {
                    _primConnStat = value;
                    ((PrimConfigControl)PrimConfigUI).SetPrimConnState(value);
                }
            }
            get => _primConnStat;
        }
        public PrimRunState PrimRunStat
        {
            set
            {
                if (_primRunStat != value)
                {
                    _primRunStat = value;
                    ((PrimConfigControl)PrimConfigUI).SetPrimRunState(value);
                }
            }
            get => _primRunStat;
        }
        public PrimVer Ver { get; set; } = PrimVer.Other;
        public int CurrentImageIndex { get => _config.CurrentImageIndex; set => _config.CurrentImageIndex = value; }


        public int IPrimInit()
        {
            try
            {
                if ((PrimRunStat == PrimRunState.Running || PrimRunStat == PrimRunState.Stop) && PrimConnStat == PrimConnState.Connected)
                {
                    return 0;
                }

                PrimConnStat = PrimConnState.Connected;
                PrimRunStat = PrimRunState.Stop;

                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"IPrimInit_Error：{ex.Message}", LogLevel.Warn);
                return -1;
            }
        }
        public int IPrimConnect(ref string result)
        {
            return 0;
        }
        public int IPrimStart()
        {
            bool state = false;
            try
            {
                if (PrimRunStat == PrimRunState.Running)
                {
                    return 0;
                }

                if (PrimConnStat != PrimConnState.Connected || PrimRunStat != PrimRunState.Stop)
                {
                    throw new Exception($"未连接");
                }

                for (int i = 0; i < DeviceCount; i++)
                {
                    if (!DeviceEnable[i])
                    {
                        continue;
                    }

                    SR7IF_ETHERNET_CONFIG _ethernetConfig;
                    string[] ipTmp = _config.IpAddress[i].Split('.');
                    if (ipTmp.Length != 4)
                    {
                        return -2;
                    }
                    _ethernetConfig.abyIpAddress = new Byte[]
                    {
                        Convert.ToByte(ipTmp[0]),
                        Convert.ToByte(ipTmp[1]),
                        Convert.ToByte(ipTmp[2]),
                        Convert.ToByte(ipTmp[3])
                    };
                    int ret = SR7LinkFunc.SR7IF_EthernetOpen(i, ref _ethernetConfig);
                    if (ret != 0)
                    {
                        throw new Exception($"SR7IF_EthernetOpen <= {ret}");
                    }

                    switch (CallBackMethod)
                    {
                        case CallBackMethod.一次回调:
                            {
                                batchOneTimeCallBack = new SR7IF_BatchOneTimeCallBack(BatchOneTimeCallBack);
                                ret = SR7LinkFunc.SR7IF_SetBatchOneTimeDataHandler(i, batchOneTimeCallBack);
                                if (ret != 0)
                                {
                                    throw new Exception($"SR7IF_SetBatchOneTimeDataHandler <= {ret}");
                                }
                                SR7LinkFunc.SR7IF_StartMeasureWithCallback(i, 1);
                            }
                            break;
                        case CallBackMethod.高速回调:
                            {
                                _callback = new HighSpeedDataCallBack(ReceiveHighSpeedData);
                                uint dwProfileCnt = Convert.ToUInt32(CallbackLineCount);
                                ret = SR7LinkFunc.SR7IF_HighSpeedDataEthernetCommunicationInitalize(i, ref _ethernetConfig, 0, _callback, dwProfileCnt, 0);
                                if (ret < 0)
                                {
                                    throw new Exception($"SR7IF_HighSpeedDataEthernetCommunicationInitalize <= {ret}");
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    double heightRange = 0;
                    IntPtr str_Model = SR7LinkFunc.SR7IF_GetModels(i);
                    String s_model = Marshal.PtrToStringAnsi(str_Model);
                    if (s_model == "SR7050")
                        heightRange = 2.5;
                    else if (s_model == "SR7080")
                        heightRange = 6;
                    else if (s_model == "SR7140")
                        heightRange = 12;
                    else if (s_model == "SR7240")
                        heightRange = 20;
                    else if (s_model == "SR7400")
                        heightRange = 50;
                    LogAdd("当前相机型号：" + s_model + "；高度区域：" + heightRange + "；", LogLevel.Trace);


                    ////写入批处理个数
                    //IntPtr intPtr = new IntPtr(_config.BatchPointNum[0]);
                    //int[] target = new int[4] { 0, 0, 0, 0 };
                    //SR7LinkFunc.SR7IF_SetSetting(0, 0x02, 0x10, 0x00, 0x0a, target, intPtr, 2);
                }

                state = true;
            }
            catch (Exception ex)
            {
                LogAdd($"IPrimStart_Error：{ex.Message}", LogLevel.Warn);
            }

            PrimConnStat = state ? PrimConnState.Connected : PrimConnState.UnConnected;
            PrimRunStat = state ? PrimRunState.Running : PrimRunState.Other;

            return state ? 0 : -1;
        }
        public int IPrimStop()
        {
            bool state = false;

            try
            {
                for (int i = 0; i < DeviceCount; i++)
                {
                    if (!DeviceEnable[i])
                    {
                        continue;
                    }

                    int ret = SR7LinkFunc.SR7IF_StopMeasure(i);
                    if (ret != 0)
                    {
                        throw new Exception($"SR7IF_StopMeasure <= {ret}");
                    }

                    ret = SR7LinkFunc.SR7IF_CommClose(i);
                    if (ret != 0)
                    {
                        throw new Exception($"SR7IF_CommClose <= {ret}");
                    }
                }
                state = true;
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
                LogAdd($"IPrimStop_Error：{ex.Message}", LogLevel.Warn);
            }
            finally
            {

            }

            PrimConnStat = PrimConnState.UnConnected;
            PrimRunStat = !state ? PrimRunState.Err : PrimRunState.Other;
            return state ? 0 : -1;
        }
        public int IPrimDispose()
        {
            bool state = false;
            try
            {

                state = true;
            }
            catch (Exception ex)
            {
                LogAdd($"IPrimDispose_Error：{ex.Message}", LogLevel.Warn);
            }

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = !state ? PrimRunState.Err : PrimRunState.Other;
            return state ? 0 : -1;
        }
        public int IPrimTaskInit()
        {
            int ret = -1;

            if ((ret = IPrimInit()) != 0)
            {
                return -1;
            }

            var connRet = "";
            if ((ret = IPrimConnect(ref connRet)) != 0)
            {
                return -2;
            }

            if ((ret = IPrimStart()) != 0)
            {
                return -3;
            }

            return ret;
        }
        public int IPrimTaskPause()
        {
            return 0;
        }
        public int IPrimTaskReset()
        {
            return 0;
        }
        public int IPrimTaskStop()
        {
            int ret = -1;

            if ((ret = IPrimStop()) != 0)
            {
                return ret;
            }

            if ((ret = IPrimDispose()) != 0)
            {
                return ret;
            }

            return 0;
        }
        public XmlNode IPrimExportConfigXml()
        {
            return XMLHelper.ObjectToXML(_config);
        }
        public int IPrimImportConfigXml(XmlNode xmlNode)
        {
            _config = XMLHelper.XMLToObject(xmlNode, typeof(Config)) as Config;
            return _config != null ? 0 : -1;
        }
        #endregion



        #region Override PIPrimSensor3d
        public int StartMeasure(int deviceId)
        {
            int iRet = 0;
            switch (CallBackMethod)
            {
                case CallBackMethod.一次回调:
                    {
                        SR7LinkFunc.SR7IF_StartMeasureWithCallback(deviceId, 0);
                        init(deviceId);
                    }
                    break;

                case CallBackMethod.高速回调:
                    {
                        IntPtr DataObject = new IntPtr();
                        iRet = SR7LinkFunc.SR7IF_StartMeasure(deviceId, 200 * 1000);
                        // 获取轮廓宽度
                        m_XPoints = SR7LinkFunc.SR7IF_ProfileDataWidth(deviceId, DataObject);
                        for (var i = 0; i < 2; i++)
                        {
                            _laserDataCount[i] = 0;
                        }
                    }
                    break;
                default:
                    break;
            }
            bBatchFinish = 0;
            return iRet;
        }
        public int StopMeasure(int deviceId)
        {
            ClearBatchData(deviceId);
            return SR7LinkFunc.SR7IF_StopMeasure(deviceId);
        }
        public int ClearBatchData(int deviceId = 0)
        {
            var count = _laserData.Length;
            if (deviceId < count)
            {
                _laserData[deviceId] = new List<int[]>();
                _laserDataCount[deviceId] = 0;
                return 0;
            }

            return -1;
        }
        public int ChangeActiveJob(object productType, int deviceId = 0)
        {
            throw new NotImplementedException();
        }
        public int GetBatchDataCount(int deviceId = 0)
        {
            return _laserData[0].Count;
        }
        public List<List<PointFS>> GetBatchData(List<double> yPoses, int deviceId = 0, bool isMirror = false, int layerIndex = 0)
        {
            double x_Step = SR7LinkFunc.SR7IF_ProfileData_XPitch(0, new IntPtr());
            List<List<PointFS>> data = new List<List<PointFS>>();
            for (int i = 0; i < _laserData[0].Count; i++)
            {
                List<PointFS> line = new List<PointFS>();
                for (int j = 0; j < _laserData[0][i].Length; j++)
                {
                    PointFS point = new PointFS();
                    point.Z = _laserData[0][i][j] / 100000.0;
                    point.X = j * m_XPitch;
                    point.Y = yPoses[i];
                    line.Add(point);
                }
                data.Add(line);
            }
            return data;
        }
        public List<int[]> GetBatchArray(int deviceId)
        {
            //var count = _laserData.Length;
            return _laserData[0];
        }
        /// <summary>
        /// 程序号切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public int SwitchProgram(int device, int number)
        {
            int reT = SR7LinkFunc.SR7IF_SwitchProgram(device, number);
            if (reT < 0)
                MessageBox.Show("程序切换失败！", "提示", MessageBoxButtons.OK);
            return reT;
        }
        #endregion



        #region Method_ExternalUsing

        internal void Write3dDataToCsv(bool line, string fileName, List<List<PointFS>> datas)
        {
            var dirPath = fileName?.Substring(0, fileName.LastIndexOf(@"\"));
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

            var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(fs, new UnicodeEncoding());
            if (line)
            {
                foreach (var item in datas)
                {
                    foreach (var item1 in item) sw.Write($"{item1.X},{item1.Y},{item1.Z},");
                    sw.Write("\r\n");
                }

                sw.Flush();
                sw.Close();
            }
            else
            {
                sw = new StreamWriter(fs, new UnicodeEncoding());
                var text0 = new StringBuilder();
                foreach (var item in datas)
                    foreach (var item1 in item)
                    {
                        text0.Clear();
                        text0.Append($"{item1.X},{item1.Y},{item1.Z}\r\n");
                        sw.Write(text0);
                    }

                sw.Flush();
                sw.Close();
            }

            fs.Close();
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        internal void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            msg = $"{Name} -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.PrimSSZN}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimSSZN.ToString(), LogClassification.VisioPrim, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        internal void LogAddAuthority(string msg, LogLevel lv)
        {
            msg = $"{AuthorityManager.Instance.CurrentUserName} > {Name} > " + msg;

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimSSZN.ToString(), LogClassification.VisioPrim, 0L);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 高速回调订阅
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="size"></param>
        /// <param name="count"></param>
        /// <param name="notify"></param>
        /// <param name="user"></param>
        public void ReceiveHighSpeedData(IntPtr buffer, uint size, uint count, uint notify, uint user)
        {
            if (notify != 0)
            {
                if (Convert.ToBoolean(notify & 0x08))
                {
                    SR7LinkFunc.SR7IF_StopMeasure(0);
                    System.Console.Write("批处理超时!\n");
                    MessageBox.Show("批处理超时", "提示", MessageBoxButtons.OK);
                    m_curBatchNo = 0;
                }
            }


            if (count == 0 || size == 0)
                return;

            if (b_MemoryErr)
            {
                return;
            }

            uint profileSize = (uint)(size / Marshal.SizeOf(typeof(int)));   //轮廓宽度

            // 获取批处理总行数
            IntPtr DataObject = new IntPtr();
            int TempBatchPoint = SR7LinkFunc.SR7IF_ProfilePointSetCount(0, DataObject);
            BatchCallBackPoint = TempBatchPoint;
            m_BatchWidth = Convert.ToInt32(profileSize);


            //数据拷贝
            int[] bufferArray = new int[profileSize * count];
            Marshal.Copy(buffer, bufferArray, 0, (int)(profileSize * count));
            int TmpNum = Convert.ToInt32(m_curBatchNo * profileSize);

            for (int i = 0; i < count; i++)
            {
                int[] HeightData = new int[m_XPoints];
                Array.Copy(bufferArray, i * profileSize, HeightData, TmpNum, m_XPoints);
                _laserData[user].Add(HeightData);
            }

            _laserDataCount[user] += (int)count;
            //_laserIntensityCount[user] += (int)count;
            if (DebugMode)
            {
                ((PrimConfigControl)PrimConfigUI).UpdateDataCount((int)user, _laserDataCount[user]);
            }
        }

        /// <summary>
        /// 一次回调订阅
        /// </summary>
        /// <param name="info"></param>
        /// <param name="data"></param>
        private void BatchOneTimeCallBack(IntPtr info, IntPtr data)
        {
            try
            {
                LogAdd("BatchOneTimeCallBack!", LogLevel.Trace);

                SR7IF_STR_CALLBACK_INFO coninfo = new SR7IF_STR_CALLBACK_INFO();
                coninfo = (SR7IF_STR_CALLBACK_INFO)Marshal.PtrToStructure(info, typeof(SR7IF_STR_CALLBACK_INFO));
                if (coninfo.returnStatus == -100)
                {
                    return;
                }

                m_BatchPoints = coninfo.BatchPoints;
                m_XPitch = coninfo.xPixth;
                m_XPoints = coninfo.xPoints;

                IntPtr[] mTmpData = new IntPtr[2];
                IntPtr[] mTmpGraydata = new IntPtr[2];
                IntPtr[] mTmpEncoderdata = new IntPtr[2];
                for (int index = 0; index < coninfo.HeadNumber; index++)
                {
                    mTmpData[index] = SR7LinkFunc.SR7IF_GetBatchProfilePoint(data, index);
                    mTmpGraydata[index] = SR7LinkFunc.SR7IF_GetBatchIntensityPoint(data, index);
                    mTmpEncoderdata[index] = SR7LinkFunc.SR7IF_GetBatchEncoderPoint(data, index);

                    if (mTmpData[index] != IntPtr.Zero)
                    {
                        Marshal.Copy(mTmpData[index], HeightData[index], 0, m_BatchPoints * m_XPoints);
                        for (int i = 0; i < m_BatchPoints; i++)
                        {
                            int[] HeightDataTmp = new int[m_XPoints];
                            Array.Copy(HeightData[index], i * m_XPoints, HeightDataTmp, 0, m_XPoints);
                            _laserData[0].Add(HeightDataTmp);
                        }
                    }
                    else
                    {
                        throw new Exception("内存不足,相机头A高度数据获取失败");
                    }

                    if (mTmpGraydata[index] != IntPtr.Zero)
                    {
                        Marshal.Copy(mTmpGraydata[index], GrayData[index], 0, m_BatchPoints * m_XPoints);
                    }
                    else
                    {
                        throw new Exception("内存不足,相机头A灰度数据获取失败");
                    }

                    if (mTmpEncoderdata[index] != IntPtr.Zero)
                    {
                        Marshal.Copy(mTmpEncoderdata[index], EncoderData[index], 0, m_BatchPoints);
                    }
                    else
                    {
                        throw new Exception("内存不足,相机头A编码器获取失败");
                    }
                }
            }
            catch (Exception ex)
            {
                LogAdd($"BatchOneTimeCallBack error：{ex.Message}", LogLevel.Warn);
            }

            GC.Collect();
            bBatchFinish = 1;
        }

        public int init(int id)
        {
            try
            {
                if (id < 0)
                {
                    return -2;
                }

                for (int index = 0; index < 2; index++)
                {

                    HeightData[index] = new int[1500 * 3200];
                    GrayData[index] = new byte[1500 * 3200];
                    EncoderData[index] = new int[1500];

                    for (int i = 0; i < HeightData[index].Length; i++)
                    {
                        HeightData[index][i] = -1000000000;
                    }

                    for (int i = 0; i < GrayData[index].Length; i++)
                    {
                        GrayData[index][i] = byte.MinValue;
                    }

                    for (int i = 0; i < EncoderData[index].Length; i++)
                    {
                        EncoderData[index][i] = int.MinValue;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }
        #endregion
    }
}