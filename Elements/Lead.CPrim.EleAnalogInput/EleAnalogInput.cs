using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.EleAnalogInput
{
    /// <summary>
    /// 模拟量输入模块管理器
    /// </summary>
    public class EleAnalogInput : IEle, IEleAD
    {
        //****************************************************************************************************
        #region Field
        /// <summary>模拟量输入模块配置</summary>
        public EleAnalogInputConfig _config;
        /// <summary>模拟量模块ConfigUI</summary>
        public ConfigUI _eleConfigUI;
        /// <summary>模拟量模块DebugUI</summary>
        public DebugUI _eleDebugUI;
        /// <summary>运行状态</summary>
        public EleRunState _eleRunState = EleRunState.Other;
        /// <summary>模拟量模块被选择</summary>
        private bool _isSelected;
        /// <summary>模拟量模块对应</summary>
        public IIoModule _motionCard;

        //public IEle _ele = null; 
        #endregion


        #region Ctor
        /// <summary>Ctor无参</summary>
        public EleAnalogInput()
        {
            _config = new EleAnalogInputConfig();

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();
            _eleConfigUI.SetEleConfig(this);
            //_eleDebugUI.SetEleConfig(this);
        }
        /// <summary>Ctor有一个参数</summary>
        public EleAnalogInput(XmlNode xmlNode)
        {
            if (xmlNode == null)
                return;

            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleAnalogInputConfig)) as EleAnalogInputConfig;

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();
            _eleConfigUI.SetEleConfig(this);
            //_eleDebugUI.SetEleConfig(this);
        } 
        #endregion


        //****************************************************************************************************
        #region 接口【IEle】实现
        #region Prop
        public string DevName { get => _config.DevName; set => _config.DevName = value; }
        public Guid Id { get => _config.Id; set => _config.Id = value; }
        public string Name { get => _config.Name; set => _config.Name = value; }
        public string Info { get => _config.Info; set => _config.Info = value; }
        public bool IsSelected
        {
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                if (value) _eleConfigUI.BackColor = Color.Green;
                else _eleConfigUI.BackColor = Color.LightGray;
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
                if(_eleRunState == value)
                {
                    return;
                }
                OnEleStateChanged?.Invoke(value);
                _eleRunState = value;
            }
        }
        public bool Enable { get => _config.Enable; set => _config.Enable = value; }
        public string EleTypeName { get => _config.EleTypeName; set => _config.EleTypeName = value; }
        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }
        public LogLevel EleAlarmLv { get; set; }
        public bool LogDisplay { get => _config.LogDisplay; set => _config.LogDisplay = value; }
        public bool ManualEnable { get; set; }
        public bool IsSimulateMode { get => _config.IsSimulateMode; set => _config.IsSimulateMode = value; }
        #endregion


        #region Define_Event
        public event EleStateChangedEventHandle OnEleStateChanged;
        #endregion


        #region Method
        public PrimRunState IEleCheckPrimRunState()
        {
            if (_motionCard == null) return PrimRunState.Other;
            return ((IPrim)_motionCard).PrimRunStat;
        }
        /// <summary>元件释放</summary>
        /// <returns></returns>
        public int IEleDispose()
        {
            IEleStop();
            if (_eleConfigUI != null && !_eleConfigUI.Disposing && !_eleConfigUI.IsDisposed) _eleConfigUI.Dispose();

            if (_eleDebugUI != null && !_eleDebugUI.Disposing && !_eleDebugUI.IsDisposed) _eleDebugUI.Dispose();

            EleRunStat = EleRunState.Other;
            return 0;
        }
        public int IEleInit()
        {
            if (!Enable) return 0;
            if (EleRunStat == EleRunState.Running) return 0;

            var prim = PrimsManagerTransfer.GetPrimByName(DevName);
            if (prim == null)
            {
                EleRunStat = EleRunState.Err;
                _eleConfigUI.SetEleRunState(EleRunStat);
                return -1;
            }

            if (_motionCard != prim) _motionCard = (IIoModule)prim;

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

            if (_eleDebugUI != null)
            {
                //_eleDebugUI.Stop();
            }
            return 0;
        }
        public int IEleUiRefresh()
        {
            var iRet = 0;
            ActFeedBack = Read();
            ActValue = Transform(ActFeedBack);
            _eleConfigUI.UiRefresh();
            return iRet;
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
        public XmlNode IEleExportConfigXml()
        {
            if (_config == null) return null;
            var node = ProxyTools.XMLHelper.ObjectToXML(_config);
            return node;
            throw new NotImplementedException();
        }
        public int IEleImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleAnalogInputConfig)) as EleAnalogInputConfig;
            else
                return -1;

            _eleConfigUI.UpdataEleConfig(_config);
            //_eleInfoUI.UpdataEleConfig();
            //_eleDebugUI.UpdataEleConfig(_config);

            return iRet;
        }
        #endregion
        #endregion



        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region 接口【IEleAD】实现
        public float ActFeedBack
        {
            get => _config.ActFeedBack;
            //{
            //    double analogValue;
            //    var val = (uint)_config.ActFeedBack;
            //    //判断第16位是否为1
            //    if (((val >> 15) & 1) == 1)
            //    {
            //        var analog = ((int)val ^ ((int)(Math.Pow(2, 15) - 1) * -10)) + 1;
            //        analogValue = (analog - Math.Pow(2, 15)) / (Math.Pow(2, 15) - 1) * -10;
            //    }
            //    else
            //    {
            //        analogValue = val / Math.Pow(2, 15) * 10;
            //    }

            //    return (float)analogValue;
            //}
            set => _config.ActFeedBack = value;
        }
        public float ActValue { get => _config.ActValue; set => _config.ActValue = value; }
        public float ActMax { get => _config.ActMax; set => _config.ActMax = value; }
        public float ActMin { set => _config.ActMin = value; get => _config.ActMin; }
        public string Address { set => _config.Address = value; get => _config.Address; }
        public EleAnalogType EleType { get => _config.AnalogType; set => _config.AnalogType = value; }
        public float FeedBackMax { get => _config.FeedBackMax; set => _config.FeedBackMax = value; }
        public float FeedBackMin { get => _config.FeedBackMin; set => _config.FeedBackMin = value; }
        public float LimitMax {  get => _config.LimitMax; set => _config.LimitMax = value; }
        public float LimitMin { get => _config.LimitMin; set => _config.LimitMin = value; }


        public float Read()
        {
            var iRet = 0;

            if ((_motionCard == null) || ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running) return 0;
            try
            {
                iRet = _motionCard.ReadSingleAInput(double.Parse(Address), EleType, out var value);
                return (float)value;
            }
            catch
            {
                return iRet;
            }
        }

        public float GetActValue()
        {
            var iRet = 0;

            if ((_motionCard == null) || ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running) return 0;
            try
            {
                iRet = _motionCard.ReadSingleAInput(double.Parse(Address), EleType, out var value);
                return (float)((ActMax - ActMin) / (FeedBackMax - FeedBackMin) * (value - FeedBackMin) + ActMin);
            }
            catch
            {
                return iRet;
            }
        }
        #endregion



        #region Other
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, long id = 0)
        {
            if (!LogEnable) return;

            string tempId = $"{(int)lv}{(int)PrimLogId.EleAnalogInput}0000";

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
                    _eleConfigUI.SetEleRunState(EleRunStat);
                    _eleDebugUI.SetEleRunState(EleRunStat);
                    break;

                case LogLevel.Error:
                    EleAlarmLv = LogLevel.Error;
                    EleRunStat = EleRunState.Err;
                    _eleConfigUI.SetEleRunState(EleRunStat);
                    _eleDebugUI.SetEleRunState(EleRunStat);
                    break;

                case LogLevel.Warn:
                    EleAlarmLv = LogLevel.Warn;
                    EleRunStat = EleRunState.Err;
                    _eleConfigUI.SetEleRunState(EleRunStat);
                    _eleDebugUI.SetEleRunState(EleRunStat);
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
        /// <summary>将模拟量值转换为数字量值</summary>
        /// <param name="value">模拟量值</param>
        /// <returns>数字量值</returns>
        public float Transform(float value)
        {
            var i = (ActMax - ActMin) / (FeedBackMax - FeedBackMin) * (value - FeedBackMin) + ActMin;
            return i;
        }


        #endregion
    }
}