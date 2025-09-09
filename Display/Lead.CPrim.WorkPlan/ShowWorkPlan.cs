using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Lead.CPrim.Interfaces;
using Lead.CPrim.WorkPlan.Controls;
using Lead.CPrim.Interfaces.Display;

namespace Lead.CPrim.WorkPlan
{
    /// <summary>压力曲线管理器</summary>
    public class ShowWorkPlan : IShow, IWorkPlan
    {
        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Field
        /// <summary>压力曲线配置管理器</summary>
        public ShowWorkPlanConfig _config;
        /// <summary>ConfigUi</summary>
        Control _configUi;
        /// <summary>OutputUi</summary>
        Control _outputUi;
        #endregion



        #region Prop
        /// <summary>配置地址</summary>
        public string ConfigPath
        {
            get
            {
                return _config.ConfigPath;
            }
            set
            {
                _config.ConfigPath = value;
            }
        }
        /// <summary>工单号</summary>
        public string WorkSheetId
        {
            get
            {
                return _config.WorkSheetId;
            }
            set
            {
                _config.WorkSheetId = value;
            }
        }
        /// <summary>PSASN</summary>
        public  string WorkSheetPSASN
        {
            get
            {
                return _config.WorkSheetPSASN;
            }
            set
            {
                _config.WorkSheetPSASN = value;
            }
        }
        /// <summary>工单数量</summary>
        public int WorkSheetCount
        {
            get
            {
                return _config.WorkSheetCount;
            }
            set
            {
                _config.WorkSheetCount = value;
            }
        }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowWorkPlan()
        {
            _config = new ShowWorkPlanConfig();

            _configUi = new ShowConfigControl(this);
            _outputUi = new ShowOutputControl(this);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode">参数</param>
        public ShowWorkPlan(XmlNode xmlNode)
        {
            if (xmlNode == null) return;
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ShowWorkPlanConfig)) as ShowWorkPlanConfig;

            _configUi = new ShowConfigControl(this);
            _outputUi = new ShowOutputControl(this);
        }
        #endregion



        //****************************************************************************************************
        //****************************************************************************************************
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
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ShowWorkPlanConfig)) as ShowWorkPlanConfig;
            return _config == null ? -1 : 0;
        }
        #endregion Override IShow



        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Override IWorkPlan
        public void OKIncrease()
        {
            ((ShowOutputControl)OutputUi).OKIncrease();
        }
        public void NGIncrease()
        {
            ((ShowOutputControl)OutputUi).NGIncrease();
        }
        #endregion Override IWorkPlan
    }
}
