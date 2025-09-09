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
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowAtlasCurve.Controls;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.ShowAtlasCurve
{
    /// <summary>压力曲线管理器</summary>
    public class ShowAtlasCurve : IShow, IShowAtlasCurve, IManualAuto
    {
        //****************************************************************************************************
        #region Field
        /// <summary>压力曲线配置管理器</summary>
        public ShowAtlasCurveConfig _config;
        /// <summary>ConfigUi</summary>
        Control _configUi;
        /// <summary>OutputUi</summary>
        Control _outputUi;
        #endregion



        #region Prop
        /// <summary>名称1</summary>
        public string Atlas1Name
        {
            get
            {
                return _config.Atlas1Name;
            }
            set
            {
                _config.Atlas1Name = value;
                ((ShowOutputControl)_outputUi).NameUpdate1(value);
            }
        }
        /// <summary>名称2</summary>
        public string Atlas2Name
        {
            get
            {
                return _config.Atlas2Name;
            }
            set
            {
                _config.Atlas2Name = value;
                ((ShowOutputControl)_outputUi).NameUpdate2(value);
            }
        }
        /// <summary>名称3</summary>
        public string Atlas3Name
        {
            get
            {
                return _config.Atlas3Name;
            }
            set
            {
                _config.Atlas3Name = value;
                ((ShowOutputControl)_outputUi).NameUpdate3(value);
            }
        }
        /// <summary>名称4</summary>
        public string Atlas4Name
        {
            get
            {
                return _config.Atlas4Name;
            }
            set
            {
                _config.Atlas4Name = value;
                ((ShowOutputControl)_outputUi).NameUpdate4(value);
            }
        }
        /// <summary>数量</summary>
        public int AtlasNum
        {
            get
            {
                return _config.AtlasNum;
            }
            set
            {
                if(_config.AtlasNum == value)
                {
                    return;
                }
                _config.AtlasNum = value;
                ((ShowOutputControl)_outputUi).AtlasShowNum(value);
            }
        }
        /// <summary>数量</summary>
        public int ChartNum
        {
            get
            {
                return _config.ChartNum;
            }
            set
            {
                if (_config.ChartNum == value)
                {
                    return;
                }
                _config.ChartNum = value;
                ((ShowOutputControl)_outputUi).ShowChartNum(value);
            }
        }
        /// <summary>Atlas曲线路径</summary>
        public string AtlasPath { get => _config.AtlasPath; set => _config.AtlasPath = value; }
        /// <summary>Atlas曲线路径2</summary>
        public string AtlasPath2 { get => _config.AtlasPath2; set => _config.AtlasPath2 = value; }
        /// <summary>启用曲线Y限位</summary>
        public bool EnableChartYMax { get => _config.EnableChartYMax; set => _config.EnableChartYMax = value; }
        /// <summary>曲线Y限位</summary>
        public double ChartYMax { get => _config.ChartYMax; set => _config.ChartYMax = value; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowAtlasCurve()
        {
            _config = new ShowAtlasCurveConfig();

            _configUi = new ShowConfigControl(this);
            _outputUi = new ShowOutputControl(this);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode">参数</param>
        public ShowAtlasCurve(XmlNode xmlNode)
        {
            if (xmlNode == null) return;
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ShowAtlasCurveConfig)) as ShowAtlasCurveConfig;

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
                if(_config.Name == value)
                {
                    return;
                }
                _config.Name = value;
                ((ShowConfigControl)ConfigUi).ShowNameUpdate(value);
            }
        }
        public string ShowTypeName { get => _config.ShowTypeName; set => _config.ShowTypeName = value; }
        public bool Enable { get => _config.Enable; set => _config.Enable = value; }
        public string Version { get => _config.Version; set => _config.Version = value; }
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
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ShowAtlasCurveConfig)) as ShowAtlasCurveConfig;
            return _config == null ? -1 : 0;
        }
        #endregion Override IShow



        //****************************************************************************************************
        #region Override IShowAtlasCurve
        public void ChartControl(WatchData watchData, int index = 1)
        {
            ((ShowOutputControl)_outputUi).ChartControl(watchData, index);
        }
        public void ChartControl(WatchData watchData, int chartIndex, string snIndex, double limit_up, double limit_down, double normal, int index = 1)
        {
            ((ShowOutputControl)_outputUi).ChartControl(watchData, chartIndex,  snIndex,  limit_up,  limit_down,  normal,  index);
        }


        public void AtlasStatusSet(int num, bool state)
        {
            ((ShowOutputControl)_outputUi).AtlasStatusSet(num, state);
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
        /// <summary>日志增加</summary>
        /// <param name="msg">消息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示报警弹窗；false：不显示报警弹窗</param>
        public void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            msg = $"{Name} -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.ShowAtlasCurve}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.ShowAtlasCurve.ToString(), LogClassification.Other, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
    }
}
