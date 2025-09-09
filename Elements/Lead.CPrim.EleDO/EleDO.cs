using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.EleDO
{
    public class EleDO : IEle, IEleDO
    {
        private readonly ConfigUI _eleConfigUI;
        private readonly DebugUI _eleDebugUI;
        public EleDOConfig _config;
        private bool _isSelected;
        private IIoModule _motionCard;
        public bool IsInitialed = false;
        /// <summary>运行状态</summary>
        public EleRunState _eleRunState = EleRunState.Other;

        public EleDO()
        {
            _config = new EleDOConfig();

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();

            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }

        public EleDO(XmlNode xmlNode)
        {
            //xmlNode turn to _config
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleDOConfig)) as EleDOConfig;
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

        public string LineMark
        {
            get => _config.LineMark;

            set => _config.LineMark = value;
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
                // _eleInfoUI.BackColor = System.Drawing.Color.Green;
                else
                    _eleConfigUI.BackColor = Color.LightGray;
                //_eleInfoUI.BackColor = System.Drawing.Color.LightGray;
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
            //config turn to xmlNode
            if (_config == null) return null;

            var node = ProxyTools.XMLHelper.ObjectToXML(_config);

            return node;
        }

        public int IEleImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleDOConfig)) as EleDOConfig;
            else
                return -1;

            _eleConfigUI.UpdataEleConfig(_config);
            // _eleInfoUI.UpdataEleConfig();
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
                //MessageBox.Show(string.Format(NLocalizer.GetString("EleDO_EleDO_NotFoundDevice", "Device with name: {0} not found! "), _config.DevName));
                EleRunStat = EleRunState.Err;
                _eleConfigUI.SetEleRunState(EleRunStat);
                return -1;
            }

            if (_motionCard != prim) _motionCard = (IIoModule) prim;

            if (prim.PrimRunStat == PrimRunState.Running)
            {
                EleRunStat = EleRunState.Running;
                _eleConfigUI.SetEleRunState(EleRunStat);
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

            return 0;
        }

        public int IEleUiRefresh()
        {
            try
            {
                _eleConfigUI.UiRefresh();
                //_eleDebugUI.UiRefresh();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
                return -1;
            }

            return 0;
        }

        public double DoAddress
        {
            get => _config.DoAddress;
            set => _config.DoAddress = value;
        }

        public bool DoEnable
        {
            get => _config.DoEnable;
            set => _config.DoEnable = value;
        }

        public EleDOType DoType
        {
            get => _config.DoType;

            set => _config.DoType = value;
        }
        public bool ManualEnable { get; set; }

        public bool Read()
        {
            try
            {
                if (Enable && DoEnable && _motionCard != null &&
                    ((IPrim) _motionCard).PrimRunStat == PrimRunState.Running)
                {
                    _motionCard.ReadSingleDOutput(DoAddress, out var val);
                    return DoType == EleDOType.NO ? val : !val;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Toggle()
        {
            return Write(Read() ? false : true);
        }

        public int Write(bool value)
        {
            try
            {
                if (Enable && DoEnable && _motionCard != null &&
                    ((IPrim) _motionCard).PrimRunStat == PrimRunState.Running)
                    _motionCard.WriteSingleDOutput(DoAddress, DoType == EleDOType.NO ? value : !value);

                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }

        private void LogAdd(string log)
        {
            if (!LogEnable) return;

            if (LogDisplay)
            {
                //((EleConfigUI)_primConfigUI).AddText(log);
                //((PrimConfigControl)_primConfigUI).AddText(log);
            }
        }
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, long id = 0)
        {
            if (!LogEnable) return;

            string tempId = $"{(int)lv}{(int)PrimLogId.EleDO}0000";

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
        public string GetCsvValue()
        {
            return _config.CsvValue();
        }

        public string GetCsvHeader()
        {
            return _config.CsvHeader();
        }

        public int CsvToValue(string csvString)
        {
            _config.CsvToValue(csvString);
            return 0;
        }
    }
}