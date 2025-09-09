using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.EleAnalogOutput
{
    public class EleAnalogOutput : IEle, IEleDA
    {
        public EleAnalogOutputConfig _config;
        public IEle _ele = null;

        public Control _eleConfigUI;
        public Control _eleDebugUI;
        public EleRunState _eleRunState = EleRunState.Other;
        private bool _isSelected;
        public IIoModule _motionCard;

        public EleAnalogOutput()
        {
            _config = new EleAnalogOutputConfig();

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();

            ((ConfigUI) _eleConfigUI).SetEleConfig(this);
            //_eleDebugUI.SetEleConfig(this);
        }

        public EleAnalogOutput(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleAnalogOutputConfig)) as EleAnalogOutputConfig;
            else
                return;

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();

            ((ConfigUI) _eleConfigUI).SetEleConfig(this);
            //_eleDebugUI.SetEleConfig(this);
        }

        public event EleStateChangedEventHandle OnEleStateChanged;
        public Control EleConfigUI => _eleConfigUI;

        public Control EleDebugUI => _eleDebugUI;

        /// <summary>
        ///     模拟量模块名称
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string Name
        {
            get => _config.Name;
            set => _config.Name = value;
        }

        /// <summary>
        ///     模拟量模块备注信息
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string Info
        {
            get => _config.Info;
            set => _config.Info = value;
        }

        /// <summary>
        ///     模拟量模块隶属类型
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string EleTypeName
        {
            get => _config.EleTypeName;
            set => _config.EleTypeName = value;
        }

        /// <summary>
        ///     模拟量模块对应基元名称
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string DevName
        {
            get => _config.DevName;
            set => _config.DevName = value;
        }

        /// <summary>
        ///     模拟量模块对应唯一ID
        /// </summary>
        public Guid Id
        {
            get => _config.Id;
            set => _config.Id = value;
        }

        /// <summary>
        ///     模拟量模块是否启用
        /// </summary>
        public bool Enable
        {
            get => _config.Enable;
            set => _config.Enable = value;
        }

        /// <summary>
        ///     模拟量模块是否被选中
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
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

        /// <summary>
        ///     模拟量模块是否为仿真模式
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public bool IsSimulateMode
        {
            get => _config.IsSimulateMode;
            set => _config.IsSimulateMode = value;
        }

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

        /// <summary>
        ///     模拟量模块Log是否启用
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public bool LogEnable
        {
            get => _config.LogEnable;
            set => _config.LogEnable = value;
        }

        /// <summary>
        ///     模拟量模块Log显示
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public bool LogDisplay
        {
            get => _config.LogDisplay;
            set => _config.LogDisplay = value;
        }

        /// <summary>
        ///     模拟量模块报警级别
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public LogLevel EleAlarmLv { get; set; }


        public XmlNode IEleExportConfigXml()
        {
            //config turn to xmlNode
            if (_config == null) return null;

            var node = ProxyTools.XMLHelper.ObjectToXML(_config);

            return node;
            throw new NotImplementedException();
        }

        public int IEleImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleAnalogOutputConfig)) as EleAnalogOutputConfig;
            else
                return -1;

            ((ConfigUI) _eleConfigUI).UpdataEleConfig(_config);
            //_eleInfoUI.UpdataEleConfig();
            //_eleDebugUI.UpdataEleConfig(_config);

            return iRet;
        }

        /// <summary>
        ///     Ele块初始化
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public int IEleInit()
        {
            if (!Enable) return 0;
            if (EleRunStat == EleRunState.Running) return 0;

            var prim = PrimsManagerTransfer.GetPrimByName(DevName);
            if (prim == null)
            {
                //MessageBox.Show("Device with name: " + DevName + " not found! ");
                EleRunStat = EleRunState.Err;
                ((ConfigUI) _eleConfigUI).SetEleRunState(EleRunStat);
                return -1;
            }

            if (_motionCard != prim) _motionCard = (IIoModule) prim;

            if (prim.PrimRunStat == PrimRunState.Running)
            {
                EleRunStat = EleRunState.Running;
                ((ConfigUI) _eleConfigUI).SetEleRunState(EleRunStat);
                return 0;
            }

            EleRunStat = EleRunState.Other;
            ((ConfigUI) _eleConfigUI).SetEleRunState(EleRunStat);
            return -2;
        }

        /// <summary>
        ///     Ele报错复位
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public int IEleReset()
        {
            var iRet = 0;
            return iRet;
        }

        /// <summary>
        ///     Ele停止运行
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public int IEleStop()
        {
            if (_eleConfigUI != null) ((ConfigUI) _eleConfigUI).Stop();

            if (_eleDebugUI != null)
            {
                //_eleDebugUI.Stop();
            }

            return 0;
        }

        public PrimRunState IEleCheckPrimRunState()
        {
            if (_motionCard == null) return PrimRunState.Other;
            return ((IPrim) _motionCard).PrimRunStat;
        }

        /// <summary>
        ///     Ele资源释放
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public int IEleDispose()
        {
            IEleStop();
            if (_eleConfigUI != null && !_eleConfigUI.Disposing && !_eleConfigUI.IsDisposed) _eleConfigUI.Dispose();

            if (_eleDebugUI != null && !_eleDebugUI.Disposing && !_eleDebugUI.IsDisposed) _eleDebugUI.Dispose();

            EleRunStat = EleRunState.Other;
            return 0;
        }

        /// <summary>
        ///     UI界面刷新
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public int IEleUiRefresh()
        {
            var iRet = 0;
            //ActFeedBack = Read();
            //ActValue = Transform(Read());
            ((ConfigUI) _eleConfigUI).UiRefresh();
            return iRet;
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     模拟量模块电压/电流类型
        /// </summary>
        public EleAnalogType EleType
        {
            get => _config.AnalogType;
            set => _config.AnalogType = value;
        }

        /// <summary>
        ///     模拟量模块地址
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public string Address
        {
            set => _config.Address = value;
            get => _config.Address;
        }

        /// <summary>
        ///     数字量最小值
        /// </summary>
        /// <value></value>
        /// <remarks>Lead.CPrim</remarks>
        public float ActMin
        {
            set => _config.ActMin = value;
            get => _config.ActMin;
        }

        /// <summary>
        ///     数字量最大值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float ActMax
        {
            get => _config.ActMax;
            set => _config.ActMax = value;
        }

        /// <summary>
        ///     设置的数字量最低下限
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float LimitMin
        {
            get => _config.LimitMin;
            set => _config.LimitMin = value;
        }

        /// <summary>
        ///     设置的数字量最大上限
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float LimitMax
        {
            get => _config.LimitMax;
            set => _config.LimitMax = value;
        }

        /// <summary>
        ///     电压/电流的最小值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float FeedBackMin
        {
            get => _config.FeedBackMin;
            set => _config.FeedBackMin = value;
        }

        /// <summary>
        ///     电压/电流的最大值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float FeedBackMax
        {
            get => _config.FeedBackMax;
            set => _config.FeedBackMax = value;
        }

        /// <summary>
        ///     经转换后的输入值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float SetValue
        {
            get => _config.SetValue;
            set => _config.SetValue = value;
        }
        public bool ManualEnable { get; set; }

        /// <summary>
        ///     读取当前模拟量值
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public int Write(float value)
        {
            var iRet = 0;
            if (_motionCard == null || ((IPrim) _motionCard).PrimRunStat != PrimRunState.Running)
                iRet = -10;
            else
                iRet = _motionCard.WriteSingleAOutput(double.Parse(Address), value);

            return iRet;
        }
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, long id = 0)
        {
            if (!LogEnable) return;

            string tempId = $"{(int)lv}{(int)PrimLogId.EleAnalogOutput}0000";

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

        /// <summary>
        ///     将数字量转换为模拟量
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public float Transform(float value)
        {
            var i = (SetValue - ActMin) / (ActMin - ActMin) *
                (FeedBackMax - FeedBackMin) + FeedBackMin;
            return i;
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