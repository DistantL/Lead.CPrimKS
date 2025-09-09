using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.EleLight
{
    public class EleLight : IEle, IEleLight
    {
        private readonly ConfigUI _eleConfigUI;
        private readonly DebugUI _eleDebugUI;
        public EleLightConfig _config;
        private bool _cycleFlag;
        private bool _isSelected;
        private IIoModule _motionCard;
        private Thread _taskTriLight;
        public bool IsInitialed = false;
        private bool _manualEnable = false;
        /// <summary>运行状态</summary>
        public EleRunState _eleRunState = EleRunState.Other;

        public EleLight()
        {
            _config = new EleLightConfig();

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();

            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }

        public EleLight(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleLightConfig)) as EleLightConfig;
            else
                return;

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();

            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }

        public event EleStateChangedEventHandle OnEleStateChanged;

        public string DevName
        {
            get => _config.DevName;

            set => _config.DevName = value;
        }

        public LogLevel EleAlarmLv { get; set; }
        public Control EleConfigUI => _eleConfigUI;

        public Control EleDebugUI => _eleDebugUI;

        public EleRunState EleRunStat
        {
            get => _eleRunState;
            set
            {
                if (_eleRunState == value)
                {
                    return;
                }
                OnEleStateChanged?.Invoke(value);
                _eleRunState = value;
            }
        }

        public string EleTypeName
        {
            get => _config.EleTypeName;

            set => _config.EleTypeName = value;
        }

        public bool Enable
        {
            get => _config.Enable;

            set => _config.Enable = value;
        }

        public Guid Id
        {
            get => _config.Id;

            set => _config.Id = value;
        }

        public string Info
        {
            get => _config.Info;

            set => _config.Info = value;
        }

        public bool IsSelected
        {
            set
            {
                if (value == _isSelected) return;

                _isSelected = value;
                if (value)
                    _eleConfigUI.BackColor = Color.Green;
                else
                    _eleConfigUI.BackColor = Color.LightGray;
            }
            get => _isSelected;
        }

        public bool IsSimulateMode
        {
            get => _config.IsSimulateMode;

            set
            {
                _config.IsSimulateMode = value;
                _eleConfigUI?.SetSimulateMode(value);
            }
        }

        public bool LogDisplay
        {
            get => _config.LogDisplay;
            set => _config.LogDisplay = value;
        }

        public bool LogEnable
        {
            get => _config.LogEnable;
            set => _config.LogEnable = value;
        }

        public string Name
        {
            get => _config.Name;

            set => _config.Name = value;
        }

        public PrimRunState IEleCheckPrimRunState()
        {
            if (_motionCard == null) return PrimRunState.Other;
            return ((IPrim) _motionCard).PrimRunStat;
        }

        public int IEleDispose()
        {
            try
            {
                IEleStop();
                if (_eleConfigUI != null && !_eleConfigUI.Disposing && !_eleConfigUI.IsDisposed) _eleConfigUI.Dispose();

                if (_eleDebugUI != null && !_eleDebugUI.Disposing && !_eleDebugUI.IsDisposed) _eleDebugUI.Dispose();
                EleRunStat = EleRunState.Other;
                return 0;
            }
            catch (Exception)
            {
                EleRunStat = EleRunState.Other;
                return -1;
            }
        }

        public XmlNode IEleExportConfigXml()
        {
            if (_config == null) return null;

            var node = ProxyTools.XMLHelper.ObjectToXML(_config);

            return node;
        }

        public int IEleImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleLightConfig)) as EleLightConfig;
            else
                return -1;

            _eleConfigUI.UpdataEleConfig(_config);
            _eleDebugUI.UpdataEleConfig(_config);
            return iRet;
        }

        public int IEleInit()
        {
            if (!Enable) return 0;
            if (EleRunStat == EleRunState.Running) return 0;

            var prim = PrimsManagerTransfer.GetPrimByName(_config.DevName);
            if (prim == null)
            {
                EleRunStat = EleRunState.Err;
                _eleConfigUI.SetEleRunState(EleRunStat);
                return -1;
            }

            if (_motionCard != prim) _motionCard = (IIoModule) prim;

            if (prim.PrimRunStat == PrimRunState.Running)
            {
                if (_taskTriLight == null)
                {
                    _cycleFlag = true;
                    _taskTriLight = new Thread(CycleLight);
                    _taskTriLight.IsBackground = true;
                    _taskTriLight.Priority = ThreadPriority.Normal;
                    //_taskCyld.Start();
                }

                EleRunStat = EleRunState.Running;
                _eleConfigUI.SetEleRunState(EleRunStat);
                AllOff();
                return 0;
            }

            EleRunStat = EleRunState.Other;
            _eleConfigUI.SetEleRunState(EleRunStat);
            return -2;
        }

        public int IEleReset()
        {
            var iRet = 0;
            return iRet;
        }

        public int IEleStop()
        {
            if (_eleConfigUI != null) _eleConfigUI.Stop();

            if (_eleDebugUI != null) _eleDebugUI.Stop();

            if (_taskTriLight != null && _taskTriLight.IsAlive)
            {
                _cycleFlag = false;
                Thread.Sleep(20);
                _taskTriLight.Abort();
            }
            else
            {
                return 1;
            }

            var st1 = DateTime.Now.Ticks / 10000;
            while (true)
            {
                if (_taskTriLight.ThreadState != ThreadState.Aborted &&
                    _taskTriLight.ThreadState != ThreadState.Stopped)
                {
                    var end = DateTime.Now.Ticks / 10000;
                    var dt = end - st1;
                    if (dt >= 3000)
                        //MessageBox.Show("Task'init Dispose Timeout !");
                        return -1;
                }
                else
                {
                    break;
                }

                Thread.Sleep(50);
            }

            _taskTriLight = null;
            return 0;
        }

        public int IEleUiRefresh()
        {
            try
            {
                if (_motionCard == null) return 0;
                _eleConfigUI.UiRefresh();
                _eleDebugUI.UiRefresh();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

            return 0;
        }

        public double BuzzAddress
        {
            get => _config.BuzzAddress;
            set => _config.BuzzAddress = value;
        }

        public bool BuzzEnable
        {
            get => _config.BuzzEnable;
            set => _config.BuzzEnable = value;
        }

        public double GreenAddress
        {
            get => _config.GreenAddress;
            set => _config.GreenAddress = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool GreenEnable
        {
            get => _config.GreenEnable;
            set => _config.GreenEnable = value;
        }

        public EleLightState LightState { get; set; } = EleLightState.Stopping;

        public EleLightType LightType
        {
            get => _config.LightType;

            set => _config.LightType = value;
        }

        public double RedAddress
        {
            get => _config.RedAddress;
            set => _config.RedAddress = value;
        }

        public bool RedEnable
        {
            get => _config.RedEnable;
            set => _config.RedEnable = value;
        }

        public double YellowAddress
        {
            get => _config.YellowAddress;
            set => _config.YellowAddress = value;
        }

        public bool YellowEnable
        {
            get => _config.YellowEnable;
            set => _config.YellowEnable = value;
        }
        public bool ManualEnable
        {
            get
            {
                return _manualEnable;
            }
            set
            {
                _manualEnable = value;
                ((ConfigUI)EleConfigUI).SetManualEnable(value);
            }
        }

        public int AllOff()
        {
            if (_config.LightType == EleLightType.Button_Light)
            {
                WriteGreen(false);
                WriteRed(false);
                WriteYellow(false);
            }
            else if (_config.LightType == EleLightType.Tricolour_Light)
            {
                WriteGreen(false);
                WriteRed(false);
                WriteYellow(false);
                WriteBuzz(false);
            }

            return 0;
        }

        public int Debug()
        {
            return 0;
        }

        public int Error()
        {
            if (_config.LightType == EleLightType.Button_Light)
            {
                WriteRed(true);
                WriteGreen(false);
                WriteYellow(true);
                Thread.Sleep(500);
                WriteYellow(false);
                Thread.Sleep(500);
            }
            else if (_config.LightType == EleLightType.Tricolour_Light)
            {
                WriteRed(true);
                WriteGreen(false);
                WriteYellow(true);
                Thread.Sleep(500);
                WriteYellow(false);
                Thread.Sleep(500);
                WriteBuzz(false);
                Thread.Sleep(300);
                WriteBuzz(true);
                Thread.Sleep(300);
            }

            return 0;
        }

        public int Fatal()
        {
            if (_config.LightType == EleLightType.Button_Light)
            {
                WriteRed(true);
                WriteGreen(false);
                WriteYellow(true);
                Thread.Sleep(500);
                WriteYellow(false);
            }
            else if (_config.LightType == EleLightType.Tricolour_Light)
            {
                WriteRed(true);
                WriteGreen(false);
                WriteYellow(false);
                WriteBuzz(true);
            }

            return 0;
        }

        public int Inform()
        {
            return 0;
        }

        public int ReadBuzz()
        {
            try
            {
                if (_motionCard == null)
                {
                    return -10;
                }
                if (BuzzEnable)
                {
                    _motionCard.ReadSingleDOutput(BuzzAddress, out var val);
                    return val ? 1 : 0;
                }

                return 0;
            }
            catch (Exception)
            {
                // msg = "Read failed!";
                return -2;
            }
        }

        public int ReadGreen()
        {
            try
            {
                if (_motionCard == null)
                {
                    return -10;
                }
                if (GreenEnable)
                {
                    _motionCard.ReadSingleDOutput(GreenAddress, out var val);
                    return val ? 1 : 0;
                }

                return 0;
            }
            catch (Exception)
            {
                // msg = "Read failed!";
                return -2;
            }
        }

        public int ReadRed()
        {
            try
            {
                if (_motionCard == null)
                {
                    return -10;
                }
                if (RedEnable)
                {
                    _motionCard.ReadSingleDOutput(RedAddress, out var val);
                    return val ? 1 : 0;
                }

                return 0;
            }
            catch (Exception)
            {
                // msg = "Read failed!";
                return -2;
            }
        }

        public int ReadYellow()
        {
            try
            {
                if (_motionCard == null)
                {
                    return -10;
                }
                if (YellowEnable)
                {
                    _motionCard.ReadSingleDOutput(YellowAddress, out var val);
                    return val ? 1 : 0;
                }

                return 0;
            }
            catch (Exception)
            {
                // msg = "Read failed!";
                return -2;
            }
        }

        public int Running()
        {
            if (_config.LightType == EleLightType.Button_Light)
            {
                WriteRed(false);
                WriteGreen(true);
                WriteYellow(false);
            }
            else if (_config.LightType == EleLightType.Tricolour_Light)
            {
                WriteRed(false);
                WriteGreen(true);
                WriteYellow(false);
                WriteBuzz(false);
            }

            return 0;
        }

        public int Stopping()
        {
            if (_config.LightType == EleLightType.Button_Light)
            {
                WriteRed(false);
                WriteYellow(false);
                WriteGreen(true);
                Thread.Sleep(500);
                WriteGreen(false);
                Thread.Sleep(500);
            }
            else if (_config.LightType == EleLightType.Tricolour_Light)
            {
                WriteRed(false);
                WriteGreen(false);
                WriteYellow(true);
                WriteBuzz(false);
            }

            return 0;
        }

        public int Warn()
        {
            if (_config.LightType == EleLightType.Button_Light)
            {
                WriteGreen(true);
                WriteRed(false);
                WriteYellow(false);
                Thread.Sleep(500);
                WriteYellow(true);
                Thread.Sleep(500);
            }
            else if (_config.LightType == EleLightType.Tricolour_Light)
            {
                WriteRed(false);
                WriteGreen(true);
                WriteBuzz(true);
                Thread.Sleep(1000);
                WriteBuzz(false);
                Thread.Sleep(1000);
                WriteYellow(false);
                Thread.Sleep(500);
                WriteYellow(true);
                Thread.Sleep(500);
            }

            return 0;
        }

        public int WriteBuzz(bool on_off)
        {
            try
            {
                if (_motionCard == null)
                {
                    on_off = false;
                    return -10;
                }
                if (BuzzEnable) _motionCard.WriteSingleDOutput(BuzzAddress, on_off);
                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }

        public int WriteGreen(bool on_off)
        {
            try
            {
                if (_motionCard == null)
                {
                    on_off = false;
                    return -10;
                }
                if (GreenEnable) _motionCard.WriteSingleDOutput(GreenAddress, on_off);
                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }

        public int WriteRed(bool on_off)
        {
            try
            {
                if (_motionCard == null)
                {
                    on_off = false;
                    return -10;
                }
                if (RedEnable) _motionCard.WriteSingleDOutput(RedAddress, on_off);
                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }

        public int WriteYellow(bool on_off)
        {
            try
            {
                if (_motionCard == null)
                {
                    on_off = false;
                    return -10;
                }
                if (YellowEnable) _motionCard.WriteSingleDOutput(YellowAddress, on_off);
                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, long id = 0)
        {
            if (!LogEnable) return;

            string tempId = $"{(int)lv}{(int)PrimLogId.EleLight}0000";

            if (long.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, log, Name, LogClassification.Elements, id);

            switch (lv)
            {
                case LogLevel.Fatal:
                    EleAlarmLv = LogLevel.Fatal;
                    EleRunStat = EleRunState.Err;
                    ((ConfigUI)_eleConfigUI).SetEleRunState(EleRunStat);
                    ((DebugUI)_eleDebugUI).SetEleRunState(EleRunStat);
                    break;
                case LogLevel.Error:
                    EleAlarmLv = LogLevel.Error;
                    EleRunStat = EleRunState.Err;
                    ((ConfigUI)_eleConfigUI).SetEleRunState(EleRunStat);
                    ((DebugUI)_eleDebugUI).SetEleRunState(EleRunStat);
                    break;
                case LogLevel.Warn:
                    EleAlarmLv = LogLevel.Warn;
                    EleRunStat = EleRunState.Err;
                    ((ConfigUI)_eleConfigUI).SetEleRunState(EleRunStat);
                    ((DebugUI)_eleDebugUI).SetEleRunState(EleRunStat);
                    break;
                case LogLevel.Info:
                    EleAlarmLv = LogLevel.Info;
                    break;
                case LogLevel.Debug:
                    EleAlarmLv = LogLevel.Debug;
                    break;
                case LogLevel.Trace:
                    EleAlarmLv = LogLevel.Trace;
                    break;
            }
        }

        public void CycleLight()
        {
            while (_cycleFlag) Thread.Sleep(1);
        }
        public string GetCsvValue()
        {
            return "";
        }

        public string GetCsvHeader()
        {
            return "";
        }

        public int CsvToValue(string csvString)
        {

            return 0;
        }
    }
}