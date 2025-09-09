using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.PressureCurve.Controls;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.PressureCurve
{
    /// <summary>压力曲线管理器</summary>
    public class ShowPressureCurve : IShow, IShowPressureCurve, IManualAuto
    {
        //****************************************************************************************************
        #region Field
        /// <summary>压力曲线配置管理器</summary>
        public ShowPressureCurveConfig _config;
        /// <summary>ConfigUi</summary>
        Control _configUi;
        /// <summary>OutputUi</summary>
        Control _outputUi;
        #endregion



        #region Prop
        /// <summary>曲线1是否显示</summary>
        public bool PressVisible1
        {
            get
            {
                return _config.PressVisible1;
            }
            set
            {
                _config.PressVisible1 = value;
                ((ShowOutputControl)_outputUi).LeftUpVisible(value);
            }
        }
        /// <summary>曲线2是否显示</summary>
        public bool PressVisible2
        {
            get
            {
                return _config.PressVisible2;
            }
            set
            {
                _config.PressVisible2 = value;
                ((ShowOutputControl)_outputUi).RightUpVisible(value);
            }
        }
        /// <summary>曲线3是否显示</summary>
        public bool PressVisible3
        {
            get
            {
                return _config.PressVisible3;
            }
            set
            {
                _config.PressVisible3 = value;
                ((ShowOutputControl)_outputUi).LeftDownVisible(value);
            }
        }
        /// <summary>曲线4是否显示</summary>
        public bool PressVisible4
        {
            get
            {
                return _config.PressVisible4;
            }
            set
            {
                _config.PressVisible4 = value;
                ((ShowOutputControl)_outputUi).RightDownVisible(value);
            }
        }
        /// <summary>曲线1名称</summary>
        public string PressName1
        {
            get
            {
                return _config.PressName1;
            }
            set
            {
                _config.PressName1 = value;
                ((ShowOutputControl)_outputUi).ChartNameUpdate1(value);
            }
        }
        /// <summary>曲线2名称</summary>
        public string PressName2
        {
            get
            {
                return _config.PressName2;
            }
            set
            {
                _config.PressName2 = value;
                ((ShowOutputControl)_outputUi).ChartNameUpdate2(value);
            }
        }
        /// <summary>曲线3名称</summary>
        public string PressName3
        {
            get
            {
                return _config.PressName3;
            }
            set
            {
                _config.PressName3 = value;
                ((ShowOutputControl)_outputUi).ChartNameUpdate3(value);
            }
        }
        /// <summary>曲线4名称</summary>
        public string PressName4
        {
            get
            {
                return _config.PressName4;
            }
            set
            {
                _config.PressName4 = value;
                ((ShowOutputControl)_outputUi).ChartNameUpdate4(value);
            }
        }
        public string ImagePath { get => _config.ImagePath; set => _config.ImagePath = value; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowPressureCurve()
        {
            _config = new ShowPressureCurveConfig();

            _configUi = new ShowConfigControl(this);
            _outputUi = new ShowOutputControl(this);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode">参数</param>
        public ShowPressureCurve(XmlNode xmlNode)
        {
            if (xmlNode == null) return;
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ShowPressureCurveConfig)) as ShowPressureCurveConfig;

            _configUi = new ShowConfigControl(this);
            _outputUi = new ShowOutputControl(this);
        }
        #endregion



        //****************************************************************************************************
        #region Override IShow
        public Guid Id { get => _config.Id; set => _config.Id = value; }
        public string Name { get => _config.Name; set => _config.Name = value; }
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
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ShowPressureCurveConfig)) as ShowPressureCurveConfig;
            return _config == null ? -1 : 0;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"ShowPressureCurve -> { Name} -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.ShowPressureCurve}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, Name, LogClassification.VisioPrim, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
        #endregion



        //****************************************************************************************************
        #region Override IShowPressureCurve
        public int Start(int id, string SN)
        {
            if(string.IsNullOrEmpty(SN))
            {
                return (int)SoftWareAlarm.参数为空;
            }
            if(((ShowOutputControl)_outputUi).Start(id, SN) == 0)
            {
                return 0;
            }
            return (int)SoftWareAlarm.方法逻辑错误 ;
        }
        public int Stop(int id, string SN = "")
        {
            if (((ShowOutputControl)_outputUi).Stop(id, SN) == 0)
            {
                return 0;
            }
            return -1;
        }
        public float GetPress(int id)
        {
            return ((ShowOutputControl)_outputUi).GetPress(id);
        }
        #endregion



        //****************************************************************************************************
        #region Override IManualAuto
        public void EnableHandle(bool enable)
        {
            ((ShowOutputControl)_outputUi).EnableHandle(enable);
        }
        #endregion



        #region Test
        public void Test()
        {
            ((ShowOutputControl)_outputUi).Test();
        }
        #endregion
    }
}
