/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowAtlasCurve.cs
 * Author: Victor
 * Description: Atlas 基元管理类
 * CreateTime: 2022-09-13
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0904><Victor><20220913>
 * 1、初版1.0
 * 2、该显示基元继承了接口IManualAuto，手自动状态下对UI进行控制
 * 
 * <3.3.22.1117><Victor><20221118>
 * 1、ChartControl方法增加方法index，解决不同模式下存储不同路径
 * 
 * <3.3.22.1124><Victor><20221124>
 * 1、位置压力曲线与时间压力曲线共存，通过不同接口进行调用
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ShowPlcCurve.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.ShowPlcCurve
{
    /// <summary>压力曲线管理器</summary>
    public class Show : IShow, IShowPlcCurve, IManualAuto
    {
        //****************************************************************************************************
        #region Field
        /// <summary>压力曲线配置管理器</summary>
        public Config _config;
        /// <summary>ConfigUi</summary>
        Control _configUi;
        /// <summary>OutputUi</summary>
        Control _outputUi;
        #endregion



        #region Prop
        /// <summary>数量</summary>
        internal int ChartNum
        {
            get
            {
                return _config.ChartNum;
            }
            set
            {
                if (_config.ChartNum != value)
                {
                    _config.ChartNum = value;
                    ((ShowOutputControl)_outputUi).ShowChartNum(value);
                }
            }
        }

        /// <summary>
        /// X轴间隔
        /// </summary>
        internal double XInterval
        {
            get => _config.XInterval;
            set
            {
                if (_config.XInterval != value)
                {
                    //LogAddAuthority($"XInterval > {_config.XInterval} > {value}", LogLevel.Trace);
                    _config.XInterval = value;
                }
            }
        }

        /// <summary>
        /// X轴格式
        /// </summary>
        internal string XFormat
        {
            get => _config.XFormat;
            set
            {
                if (_config.XFormat != value)
                {
                    //LogAddAuthority($"XFormat > {_config.XFormat} > {value}", LogLevel.Trace);
                    _config.XFormat = value;
                }
            }
        }
        /// <summary>Atlas曲线路径</summary>
        internal string PlcPath { get => _config.PlcPath; set => _config.PlcPath = value; }
        /// <summary>PLC曲线路径2</summary>
        internal string PlcPath2 { get => _config.PlcPath2; set => _config.PlcPath2 = value; }

        /// <summary>
        /// X最小值启用
        /// </summary>
        internal bool XMinEnable 
        { 
            get => _config.XMinEnable; 
            set
            {
                if(_config.XMinEnable != value)
                {
                    _config.XMinEnable = value;
                }
            }
        }

        /// <summary>
        /// X最大值启用
        /// </summary>
        internal bool XMaxEnable
        {
            get => _config.XMaxEnable;
            set
            {
                if (_config.XMaxEnable != value)
                {
                    _config.XMaxEnable = value;
                }
            }
        }

        /// <summary>
        /// Y最小值启用
        /// </summary>
        internal bool YMinEnable
        {
            get => _config.YMinEnable;
            set
            {
                if (_config.YMinEnable != value)
                {
                    _config.YMinEnable = value;
                }
            }
        }

        /// <summary>
        /// Y最大值启用
        /// </summary>
        internal bool YMaxEnable
        {
            get => _config.YMaxEnable;
            set
            {
                if (_config.YMaxEnable != value)
                {
                    _config.YMaxEnable = value;
                }
            }
        }

        /// <summary>
        /// X最小值
        /// </summary>
        internal double XMin
        {
            get => _config.XMin;
            set
            {
                if (_config.XMin != value)
                {
                    _config.XMin = value;
                }
            }
        }

        /// <summary>
        /// X最大值
        /// </summary>
        internal double XMax
        {
            get => _config.XMax;
            set
            {
                if (_config.XMax != value)
                {
                    _config.XMax = value;
                }
            }
        }

        /// <summary>
        /// Y最小值
        /// </summary>
        internal double YMin
        {
            get => _config.YMin;
            set
            {
                if (_config.YMin != value)
                {
                    _config.YMin = value;
                }
            }
        }

        /// <summary>
        /// Y最大值
        /// </summary>
        internal double YMax
        {
            get => _config.YMax;
            set
            {
                if (_config.YMax != value)
                {
                    _config.YMax = value;
                }
            }
        }

        /// <summary>
        /// 源数据保存启用
        /// </summary>
        internal bool SourceDataSaveEnable
        {
            get => _config.SourceDataSaveEnable;
            set
            {
                if (_config.SourceDataSaveEnable != value)
                {
                    _config.SourceDataSaveEnable = value;
                }
            }
        }

        /// <summary>
        /// 源数据保存位置
        /// </summary>
        internal string SourceDataSave
        {
            get => _config.SourceDataSave;
            set
            {
                if (_config.SourceDataSave != value)
                {
                    _config.SourceDataSave = value;
                }
            }
        }

        /// <summary>
        /// true：保存目录增时间目录（/年/月日/）；false：保存目录不增加时间，按照设定目录存储；
        /// </summary>
        internal bool PathAddDate
        {
            get => _config.PathAddDate;
            set
            {
                if (_config.PathAddDate != value)
                {
                    //LogAddAuthority($"PathAddDate > {_config.PathAddDate} > {value}", LogLevel.Trace);
                    _config.PathAddDate = value;
                }
            }
        }
        #endregion



        #region Ctor
        public Show()
        {
            _config = new Config();

            _configUi = new ShowConfigControl(this);
            _outputUi = new ShowOutputControl(this);
        }

        public Show(XmlNode xmlNode)
        {
            _config = XMLHelper.XMLToObject(xmlNode, typeof(Config)) as Config;
            if (_config == null)
            {
                throw new NullReferenceException("Config Is Null");
            }

            _configUi = new ShowConfigControl(this);
            _outputUi = new ShowOutputControl(this);
        }
        #endregion



        //****************************************************************************************************
        #region Override IShow
        public Guid Id { get => _config.Id; set => _config.Id = value; }
        public string Name
        {
            get => _config.Name;
            set
            {
                if (_config.Name != value)
                {
                    _config.Name = value;
                    ((ShowConfigControl)ConfigUi).SetShowName(value);
                }
            }
        }
        public string ShowTypeName { get => _config.ShowTypeName; set => _config.ShowTypeName = value; }
        public bool Enable { get => _config.Enable; set => _config.Enable = value; }
        public string Version { get; set; } = "V1.5_20240112";
        public Control ConfigUi => _configUi;
        public Control OutputUi => _outputUi;
        public int IShowDispose()
        {
            var iRet = 0;
            return iRet;
        }
        public XmlNode IShowExportConfigXml()
        {
            if (_config == null) return null;
            return ProxyTools.XMLHelper.ObjectToXML(_config);
        }
        public int IShowImportConfigXml(XmlNode xmlNode)
        {
            if (xmlNode == null) return -1;
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(Config)) as Config;
            return _config == null ? -1 : 0;
        }
        #endregion



        //****************************************************************************************************
        #region Override IShowPlcCurve
        public void ChartControl(int id, string sn, Dictionary<double, double> keyValues, int index = 1, string xName = "", string yName = "")
        {
            ((ShowOutputControl)_outputUi).ChartControl(id, sn, keyValues, index, xName, yName);
        }
        public void ChartControl(int id, string sn, List<PointF> points, int index = 1, string xName = "", string yName = "")
        {
            ((ShowOutputControl)_outputUi).ChartControl(id, sn, points, index, xName, yName);
        }
        public void ChartControl(int id, string sn, Dictionary<DateTime, double> keyValues, int index = 1, string xName = "", string yName = "")
        {
            ((ShowOutputControl)_outputUi).ChartControl(id, sn, keyValues, index, xName, yName);
        }
        #endregion



        //****************************************************************************************************
        #region Override IManualAuto
        public void EnableHandle(bool enable)
        {
            ((ShowOutputControl)_outputUi).EnableHandle(enable);
        }
        #endregion



        //****************************************************************************************************
        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"{Name} -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.PrimCommon}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimCommon.ToString(), LogClassification.Module, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
    }
}
