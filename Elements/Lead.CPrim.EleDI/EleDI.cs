using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.EleDI
{
    /// <summary>DI管理器</summary>
    public class EleDI : IEle, IEleDI
    {
        #region Field
        /// <summary>元件被选择</summary>
        private bool _isSelected;
        /// <summary>ConfigUI</summary>
        private readonly ConfigUI _eleConfigUI;
        /// <summary>DebugUI</summary>
        private readonly DebugUI _eleDebugUI;
        /// <summary>运行状态</summary>
        public EleRunState _eleRunState = EleRunState.Other;



        public EleDIConfig _config;




        private bool _isRegistered;

        private IIoModule _motionCard;
        public bool IsInitialed = false;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public EleDI()
        {
            _config = new EleDIConfig();

            _eleConfigUI = new ConfigUI(this);
            _eleDebugUI = new DebugUI(this);

            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }
        /// <summary>Ctor有1个参数</summary>
        public EleDI(XmlNode xmlNode)
        {
            if (xmlNode == null) return;

            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleDIConfig)) as EleDIConfig;

            _eleConfigUI = new ConfigUI(this);
            _eleDebugUI = new DebugUI(this);

            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }
        #endregion



        #region Override 【接口】IEle
        public Guid Id { get => _config.Id; set => _config.Id = value; }
        public string DevName { get => _config.DevName; set => _config.DevName = value; }
        public string Name { get => _config.Name; set => _config.Name = value; }
        public string Info { get => _config.Info; set => _config.Info = value; }
        public bool IsSelected
        {
            set
            {
                if (value == _isSelected) return;

                _isSelected = value;
                _eleConfigUI.BackColor = value ? Color.Green : Color.LightGray;
            }
            get => _isSelected;
        }
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
        public bool Enable { get => _config.Enable; set => _config.Enable = value; }
        public string EleTypeName { get => _config.EleTypeName; set => _config.EleTypeName = value; }
        public string LineMark { get => _config.LineMark; set => _config.LineMark = value; }
        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }
        public LogLevel EleAlarmLv { get; set; }
        public bool LogDisplay { get => _config.LogDisplay; set => _config.LogDisplay = value; }
        public bool ManualEnable { get; set; }
        public bool IsSimulateMode
        {
            get => _config.IsSimulateMode;
            set
            {
                _config.IsSimulateMode = value;
                _eleConfigUI?.SetSimulateMode(value);
            }
        }

        public event EleStateChangedEventHandle OnEleStateChanged;

        public PrimRunState IEleCheckPrimRunState()
        {
            if (_motionCard == null) return PrimRunState.Other;
            return ((IPrim)_motionCard).PrimRunStat;
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
        public int IEleInit()
        {
            if (!Enable) return 0;
            if (EleRunStat == EleRunState.Running) return 0;

            var prim = PrimsManagerTransfer.GetPrimByName(_config.DevName);
            if (prim == null)
            {
                //MessageBox.Show(string.Format(NLocalizer.GetString("EleDI_EleDI_NotFoundDevice", "Device with name: {0} not found! "), _config.DevName));
                EleRunStat = EleRunState.Err;
                _eleConfigUI.SetEleRunState(EleRunStat);
                return -1;
            }

            if (_motionCard != prim) _motionCard = (IIoModule)prim;

            if (!_isRegistered)
            {
                DiRegisterEvent();
                _isRegistered = true;
            }

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
                // throw;
                return -1;
            }
            return 0;
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
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleDIConfig)) as EleDIConfig;
            else
                return -1;

            _eleConfigUI.UpdataEleConfig(_config);
            //_eleInfoUI.UpdataEleConfig();
            _eleDebugUI.UpdataEleConfig(_config);

            return iRet;
        }
        #endregion Override 【接口】IEle



        #region Override 【接口】IEleDI
        public double DiAddress { get => _config.DiAddress; set => _config.DiAddress = value; }
        public bool DiEnable { get => _config.DiEnable; set => _config.DiEnable = value; }
        public EleDIType DiType { get => _config.DiType; set => _config.DiType = value; }
        public bool EnFallEvent { get => _config.EnFallEvent; set => _config.EnFallEvent = value; }
        public bool EnRiseEvent { get => _config.EnRiseEvent; set => _config.EnRiseEvent = value; }
        public bool Read()
        {
            try
            {
                if (Enable && DiEnable && _motionCard != null &&
                    ((IPrim)_motionCard).PrimRunStat == PrimRunState.Running)
                {
                    _motionCard.ReadSingleDInput(DiAddress, out var val);
                    return DiType == EleDIType.NO ? val : !val;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion Override 【接口】IEleDI



        #region Others
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

            string tempId = $"{(int)lv}{(int)PrimLogId.EleDI}0000";

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

        public void DiRegisterEvent()
        {
            if (EnFallEvent && EnRiseEvent)
                _motionCard.RegisterDIChanged(DiAddress, 3);
            else if (EnFallEvent)
                _motionCard.RegisterDIChanged(DiAddress, 2);
            else if (EnRiseEvent) _motionCard.RegisterDIChanged(DiAddress, 1);
        }
        #endregion Others

    }
}