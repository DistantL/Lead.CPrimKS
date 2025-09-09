using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.EleAnalogInputPro
{
    /// <summary>
    /// 模拟量输入模块管理器
    /// </summary>
    public class EleAnalogInput : IEle, IEleADPro
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
        public EleAnalogInput()
        {
            _config = new EleAnalogInputConfig();

            _eleConfigUI = new ConfigUI();
            _eleDebugUI = new DebugUI();
            _eleConfigUI.SetEleConfig(this);
            //_eleDebugUI.SetEleConfig(this);
        }
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
                if (_isSelected != value)
                {
                    _isSelected = value;
                    if (value)
                    {
                        _eleConfigUI.FillColor = Color.Green;
                    }
                    else
                    {
                        _eleConfigUI.FillColor = Color.FromArgb(236, 236, 236);
                    }
                }
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
            RealTimeAnalog = Read();
            RealTimeDigital = Transform(RealTimeAnalog);
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
        public float RealTimeAnalog
        {
            get => _config.RealTimeAnalog;
            set => _config.RealTimeAnalog = value;
        }
        public float RealTimeDigital { get => _config.RealTimeDigital; set => _config.RealTimeDigital = value; }
        public string Address { set => _config.Address = value; get => _config.Address; }
        public EleAnalogType EleType { get => _config.AnalogType; set => _config.AnalogType = value; }
        public BindingList<AnalogCalculate> AnalogCalculates { get => _config.AnalogCalculates; set => _config.AnalogCalculates = value; }



        public float Read()
        {
            var iRet = 0;

            if ((_motionCard == null) || ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running)
            {
                return 0;
            }

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
        #endregion



        #region Other
        /// <summary>将模拟量值转换为数字量值</summary>
        /// <param name="value">模拟量值</param>
        /// <returns>数字量值</returns>
        public float Transform(float value)
        {
            if(AnalogCalculates == null || AnalogCalculates.Count < 2)
            {
                return 0;
            }

            double min = AnalogCalculates.Min(analog => analog.RealTimeAnalog);
            double max = AnalogCalculates.Max(analog => analog.RealTimeAnalog);
            if(value < min || value >= max)
            {
                return 0;
            }

            bool isFind = false;
            AnalogCalculate analog1 = new AnalogCalculate();
            AnalogCalculate analog2 = new AnalogCalculate();
            List<AnalogCalculate> analogs = AnalogCalculates.ToList().OrderBy(analog => analog.RealTimeAnalog).ToList();
            for (int i = 0; i < analogs.Count - 1; i++)
            {
                if(value >= analogs[i].RealTimeAnalog && value < analogs[i + 1].RealTimeAnalog)
                {
                    isFind = true;
                    analog1 = AnalogCalculates[i];
                    analog2 = AnalogCalculates[i + 1];
                    break;
                }
            }

            if(isFind)
            {
                double k = (analog2.RealTimeDigital - analog1.RealTimeDigital) / (analog2.RealTimeAnalog - analog1.RealTimeAnalog);
                return (float)(k * value + analog1.RealTimeDigital - k * analog1.RealTimeAnalog);
            }
            else
            {
                return 0;
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        internal void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            if (!LogEnable && lv != LogLevel.Warn && lv != LogLevel.Error && lv != LogLevel.Fatal)
            {
                return;
            }

            msg = $"EleAnalogInput -> { Name} -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.EleAnalogInput}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, Name, LogClassification.Elements, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, "警告", false, UIStyle.Orange, false, true);
            }
        }
        #endregion
    }
}