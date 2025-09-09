using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Sunny.UI.Win32;

namespace Lead.CPrim.PrimE404
{
    public class Prim : IPrim, ICmpTrig
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
        #endregion



        #region Ctor

        public Prim()
        {
            _config = new Config();

            PrimDebugUI = new PrimDebugControl();
            PrimConfigUI = new PrimConfigControl(this);
            PrimOutputUI = new PrimOutputControl();

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

            PrimConnStat = PrimConnState.Other;
            PrimRunStat = PrimRunState.Other;
        }
        #endregion



        #region Prop
        /// <summary>
        /// 从站号<br>
        /// 从1开始
        /// </summary>
        public int SlaveId
        {
            get => _config.SlaveId;
            set
            {
                if (_config.SlaveId != value)
                {
                    _config.SlaveId = value;
                }
            }
        }

        /// <summary>
        /// 是否开启别名，0-不开启 ，1-开启
        /// </summary>
        public bool OpenOtherName
        {
            get => _config.OpenOtherName;
            set
            {
                if (_config.OpenOtherName != value)
                {
                    _config.OpenOtherName = value;
                }
            }
        }

        /// <summary>
        /// 触发数据源
        /// </summary>
        public BindingList<TriggerData> TriggerDatas
        {
            get => _config.TriggerDatas ?? (_config.TriggerDatas = new BindingList<TriggerData>());
            set
            {
                if (_config.TriggerDatas != value)
                {
                    _config.TriggerDatas = value;
                }
            }
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

                int slaveNum = 0;//从站个数
                int option = OpenOtherName ? 1 : 0;//是否开启别名
                int ret = MiniEcatLib.Mb_InitEcat(ref slaveNum, option);
                if (slaveNum > 0)
                {
                    int[] slavealias = new int[slaveNum];
                    MiniEcatLib.Mb_GetSlaveAlias(ref slavealias[0]);
                    string[] slavenames = new string[slaveNum];

                    for (int i = 0; i < slaveNum; i++)
                    {
                        IntPtr intPtr = IntPtr.Zero;
                        intPtr = MiniEcatLib.Mb_GetSlaveName(slavealias[i]);
                        slavenames[i] = Marshal.PtrToStringAnsi(intPtr);   //LctMiniEcatLib.LctMiniEcat_GetDeviceName(i+1);
                    }

                    if (slavenames.Any(x => string.IsNullOrEmpty(x)))
                    {
                        throw new Exception(NLocalizer.SlaveNameIsNull);
                    }

                    if (!slavenames.Any(a => a.Contains("E4O4")))
                    {
                        throw new Exception($"{NLocalizer.SlaveNameIsNull}：E404");
                    }
                }
                else
                {
                    throw new Exception($"Mb_InitEcat <= {ret}");
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
                    throw new Exception(NLocalizer.NotConnected);
                }

                if (TriggerDatas.IsNullOrEmpty())
                {
                    throw new Exception(NLocalizer.TriggerChannelCountIsZero);
                }

                //int ret = -1;
                //foreach (var trig in TriggerDatas)
                //{
                //    ret = MiniEcatLib.Mb_E4O4Encoder_Initial(SlaveId, trig.EncoderId, (int)trig.EncoderMode, (int)trig.EncoderDir, 1);
                //    if (ret != 0)
                //    {
                //        throw new Exception($"Mb_E4O4Encoder_Initial <= {ret}");
                //    }


                //    //设置编码器的当前位置，一般给0，用于与实际位置对齐
                //    ret = MiniEcatLib.Mb_E4O4Encoder_SetCurrentData(SlaveId, trig.EncoderId, 0);
                //    if (ret != 0)
                //    {
                //        throw new Exception($"Mb_E4O4Encoder_SetCurrentData <= {ret}");
                //    }
                //}

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



        #region Override ICmpTrig

        public int AddTrigPoint(int trigCh, int value)
        {
            throw new NotImplementedException(NLocalizer.NotSupport);
        }

        public int GetTriggerCount(int trigCh, ref int count)
        {
            int ret = MiniEcatLib.Mb_E4O4TrigOut_GetCounter(SlaveId, trigCh, ref count);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4TrigOut_GetCounter <- {ret}");
            }
            return ret;
        }

        public int ResetTriggerCount(int trigCh)
        {
            int ret = MiniEcatLib.Mb_E4O4TrigOut_ResetCounter(SlaveId, trigCh);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4TrigOut_ResetCounter <- {ret}");
            }
            return ret;
        }

        public int SetLinearCompareTrig(int trigCh, int trigStart, int freq, int count)
        {
            var trig = TriggerDatas.FirstOrDefault(t => t.TriggerId == trigCh);
            if (trig == null)
            {
                throw new Exception(NLocalizer.TriggerChannelNotConfig);
            }

            int lineCompare = (int)Math.Log((int)trig.LineCompareMask, 2);
            int ret = MiniEcatLib.Mb_E4O4LineCmp_SetTriggerData(SlaveId, lineCompare, trigStart, trigStart + (count - 1) * freq, freq);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4LineCmp_SetTriggerData <- {ret}");
            }

            ret = MiniEcatLib.Mb_E4O4LineCmp_SetEnable(SlaveId, lineCompare, 1);//启用比较器0
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4LineCmp_SetEnable <- {ret}");
            }
            return 0;
        }

        public int SetManualTrig(int trigCh, int pulseWidth = 200)
        {
            SetTrigOutputPulseWidth(trigCh, pulseWidth);

            int ret = MiniEcatLib.Mb_E4O4TrigOut_SetManualOutput(SlaveId, trigCh);//将指定通道设置为手动触发模式
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4TrigOut_SetManualOutput <- {ret}");
            }
            return ret;
        }

        public int SetTrigDir(int trigCh, int dir)
        {
            var trig = TriggerDatas.FirstOrDefault(t => t.TriggerId == trigCh);
            if (trig == null)
            {
                throw new Exception(NLocalizer.TriggerChannelNotConfig);
            }

            int ret = MiniEcatLib.Mb_E4O4Encoder_Initial(SlaveId, trig.EncoderId, (int)trig.EncoderMode, (int)trig.EncoderDir, 1);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4Encoder_Initial <= {ret}");
            }

            //设置触发通道的输出模式。从站号从0开始，模式0是GPIO,1是脉冲，2是PWM
            ret = MiniEcatLib.Mb_E4O4TrigOut_SetOutMode(SlaveId, (int)trig.OutMode);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4TrigOut_SetOutMode <= {ret}");
            }
            
            //设置触发输出口输出为脉冲输出还是电平翻转模式，从站号从0开始，通道从0开始(0-3),模式：0-脉冲信号，1-电平翻转模
            ret =MiniEcatLib.Mb_E4O4TrigOut_SetTrigMode(SlaveId, trig.EncoderId, (int)trig.TrigMode);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4TrigOut_SetTrigMode <= {ret}");
            }
            return ret;
        }

        public int SetTriggerChannelMode(int channel, int mode)
        {
            if (mode != 0 && mode != 4 && mode != 5)
            {
                throw new Exception(NLocalizer.NotSupport);
            }

            var trig = TriggerDatas.FirstOrDefault(t => t.TriggerId == channel);
            if (trig == null)
            {
                throw new Exception(NLocalizer.TriggerChannelNotConfig);
            }


            int lineCompare = (int)Math.Log((int)trig.LineCompareMask, 2);
            int preCompare = (int)Math.Log((int)trig.PreCompareMask, 2);
            if (mode == 0)
            {
                int ret = MiniEcatLib.Mb_E4O4LineCmp_SetEnable(SlaveId, lineCompare, 0);//启用比较器0
                if (ret != 0)
                {
                    throw new Exception($"Mb_E4O4LineCmp_SetEnable <- {ret}");
                }

                ret = MiniEcatLib.Mb_E4O4PreCmp_SetEnable(SlaveId, preCompare, 0);//开启预设定比较器
                if (ret != 0)
                {
                    throw new Exception($"Mb_E4O4PreCmp_SetEnable <- {ret}");
                }

                return ret;
            }
            else
            {
                int ret = -1;
                if (mode == 4)
                {
                    ret = MiniEcatLib.Mb_E4O4TrigOut_BandingCompare(SlaveId, channel, 0, (uint)trig.PreCompareMask, (uint)trig.PulsePolarity);
                    if (ret != 0)
                    {
                        throw new Exception($"Mb_E4O4TrigOut_BandingCompare <- {ret}");
                    }

                    ret = MiniEcatLib.Mb_E4O4PreCmp_ResetTrigData(SlaveId, preCompare);//重置比较器0的触发计数
                    if (ret != 0)
                    {
                        throw new Exception($"Mb_E4O4PreCmp_ResetTrigData <- {ret}");
                    }

                    ret = MiniEcatLib.Mb_E4O4PreCmp_BindingEncoder(SlaveId, trig.EncoderId, preCompare);//将编码器通道与预设定比较器0绑定
                    if (ret != 0)
                    {
                        throw new Exception($"Mb_E4O4PreCmp_BindingEncoder <- {ret}");
                    }

                    ret = MiniEcatLib.Mb_E4O4PreCmp_SetTrigDir(SlaveId, preCompare, 2);//设置 比较器触发方向0-正向，1-反向，2-双向
                    if (ret != 0)
                    {
                        throw new Exception($"Mb_E4O4PreCmp_SetTrigDir <- {ret}");
                    }
                }
                else if (mode == 5)
                {
                    ret = MiniEcatLib.Mb_E4O4TrigOut_BandingCompare(SlaveId, channel, (uint)trig.LineCompareMask, 0, (uint)trig.PulsePolarity);
                    if (ret != 0)
                    {
                        throw new Exception($"Mb_E4O4TrigOut_BandingCompare <- {ret}");
                    }

                    ret = MiniEcatLib.Mb_E4O4LineCmp_BingdingEncoder(SlaveId, trig.EncoderId, lineCompare);//将编码器通道与线性比较器0绑定
                    if (ret != 0)
                    {
                        throw new Exception($"Mb_E4O4LineCmp_BingdingEncoder <- {ret}");
                    }
                }
                return ret;
            }
        }

        public int SetTriggerConfig(int trigChannel, int axisId, int trigSource, int trigLogic, double widthTime)
        {
            var trig = TriggerDatas.FirstOrDefault(t => t.TriggerId == trigChannel);
            if (trig == null)
            {
                throw new Exception(NLocalizer.TriggerChannelNotConfig);
            }

            //设置编码器的当前位置，一般给0，用于与实际位置对齐
            int ret = MiniEcatLib.Mb_E4O4Encoder_SetCurrentData(SlaveId, trig.EncoderId, trigSource);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4Encoder_SetCurrentData <- {ret}");
            }
            return SetTrigOutputPulseWidth(trigChannel, widthTime);
        }

        public int SetTriggerTable(int tCmpCh, double[] arry, int arrSize)
        {
            if (arry.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(arry));
            }

            var trig = TriggerDatas.FirstOrDefault(t => t.TriggerId == tCmpCh);
            if (trig == null)
            {
                throw new Exception(NLocalizer.TriggerChannelNotConfig);
            }

            int[] datas = new int[arry.Length];
            for (int i = 0; i < datas.Length; i++)
            {
                datas[i] = (int)arry[i];
            }

            int preCompare = (int)Math.Log((int)trig.PreCompareMask, 2);
            int ret = MiniEcatLib.Mb_E4O4PreCmp_SetTrigData(SlaveId, preCompare, ref datas[0], arrSize);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4Encoder_SetCurrentData <- {ret}");
            }

            ret = MiniEcatLib.Mb_E4O4PreCmp_SetEnable(SlaveId, preCompare, 1);//开启预设定比较器
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4PreCmp_SetEnable <- {ret}");
            }
            return ret;
        }

        public int SetTrigOutputLogic(int trigCh, int logic)
        {
            return 0;
        }

        public int SetTrigOutputPulseWidth(int trigCh, double widthTime)
        {
            //100~9999999
            int time = (int)(widthTime * 100);
            time = Math.Max(100, time);
            time = Math.Min(9999999, time);
            int ret = MiniEcatLib.Mb_E4O4TrigOut_SetPulseWidth(SlaveId, trigCh, time);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4TrigOut_ResetCounter <- {ret}");
            }
            return ret;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 获取编码器当前数值
        /// </summary>
        /// <param name="encoderId"></param>
        /// <returns></returns>
        internal int GetEncoderPos(int encoderId)
        {
            int pos = 0;
            int ret = MiniEcatLib.Mb_E4O4Encoder_GetEncoderData(SlaveId, encoderId, ref pos);
            if (ret != 0)
            {
                throw new Exception($"Mb_E4O4Encoder_GetEncoderData <= {ret}");
            }
            return pos;
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
        #endregion
    }
}