using Lead.CPrim.Controls;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ShowAudio.Controls;
using Lead.CPrim.StationCommon;
using Lead.CPrim.StationCommon.Alert;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static Lead.CPrim.Controls.SensorFrm;

namespace Lead.CPrim.ShowAudio
{
    /// <summary>Audio主界面</summary>
    public class ShowAudio : IShow, IShowAudio
    {
        #region Field
        private string _barCode;
        /// <summary>配置管理器</summary>
        private AudioConfig _config;

        /// <summary>当前产品</summary>
        private string _productType;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowAudio()
        {
            _config = new AudioConfig();
            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode"></param>
        public ShowAudio(XmlNode xmlNode)
        {
            if (xmlNode == null) return;

            _config = XMLHelper.XMLToObject(xmlNode, typeof(AudioConfig)) as AudioConfig;

            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);

            if (SwManager.Instance.CurrentProduct != null)
            {
                ProductType = SwManager.Instance.CurrentProduct;
            }
            SwManager.Instance.OnSoftwareConfigChangeCurrentProduct += InstanceSoftwareConfigChangeCurrentProduct;
        }
        #endregion



        #region Prop
        /// <summary>总数量</summary>
        internal double NumCount { get; set; }
        /// <summary>良率</summary>
        internal double PassRate { get; set; }
        /// <summary>OK数量</summary>
        internal double NumOk { get; set; }
        /// <summary>NG数量</summary>
        internal double NumNg { get; set; }
        /// <summary>Ct</summary>
        internal double Ct { get; set; }
        /// <summary>当前产品</summary>
        internal string ProductType
        {
            set => _productType = value;
            get => _productType;
        }
        /// <summary>二维码</summary>
        internal string BarCode
        {
            set
            {
                _barCode = value;
            }
            get => _barCode;
        }


        #endregion



        #region [ShowConfigControl]调用
        /// <summary>工站名称</summary>
        internal string StationName { set => _config.StationName = value; get => _config.StationName; }
        /// <summary>颜色集合</summary>
        internal List<string> ProColors { set => _config.ProColors = value; get => _config.ProColors; }
        /// <summary>当前颜色</summary>
        internal string CurProColor { set => _config.CurProColor = value; get => _config.CurProColor; }
        /// <summary>当前FAI名称</summary>
        public string CurrentFAIName { set => _config.CurrentFAIName = value; get => _config.CurrentFAIName; }
        #endregion



        #region Override IShow
        public Guid Id { set => _config.Id = value; get => _config.Id; }
        public string Name { set => _config.Name = value; get => _config.Name; }
        public string ShowTypeName { set => _config.ShowTypeName = value; get => _config.ShowTypeName; }
        public bool Enable { set => _config.Enable = value; get => _config.Enable; }
        public string Version { set => _config.Version = value; get => _config.Version; }
        public Control ConfigUi { get; }
        public Control OutputUi { get; }
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
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(AudioConfig)) as AudioConfig;
            return _config == null ? -1 : 0;
        }
        #endregion



        #region Override IShowAudio
        public int AddProInfo<T>(List<T> listEntiy, bool saveDataBase = false, string proTypeName = "", Dictionary<string, bool> results = null) where T : class
        {
            var iRet = 0;

            if (string.IsNullOrEmpty(proTypeName))
            {
                proTypeName = !string.IsNullOrEmpty(ProductType) ? ProductType : @"parts";
            }

            ((ShowOutputControl)OutputUi).AddMultiPartInfo(listEntiy, saveDataBase, proTypeName, results);
            StationManager.Instance.CurrentStation.AddRtData(listEntiy, false, proTypeName, results);

            return iRet;
        }

        public int AddProInfo<T>(T entiy, bool saveDataBase = false, string proTypeName = "", Dictionary<string, bool> results = null) where T : class
        {
            var iRet = 0;

            var listEntiy = new List<T> { entiy };

            if (string.IsNullOrEmpty(proTypeName))
            {
                proTypeName = !string.IsNullOrEmpty(ProductType) ? ProductType : @"parts";
            }

            ((ShowOutputControl)OutputUi).AddMultiPartInfo(listEntiy, saveDataBase, proTypeName, results);
            StationManager.Instance.CurrentStation.AddRtData(entiy, false, proTypeName, results);

            return iRet;
        }

        public void UpdateProductType(string newType)
        {
            ProductType = newType;
        }

        public void SetHive(bool state)
        {
            SoftWareInfo.Instance.SetHive(state);
        }

        public void SetMes(bool state)
        {
            SoftWareInfo.Instance.SetMes(state);
        }

        public void SetPDCA(bool state)
        {
            SoftWareInfo.Instance.SetPDCA(state);
        }


        public bool GetRemoteQualificationEnable()
        {
            return SwManager.Instance.RemoteQualificationEnable;
        }

        public string GetOperatorID()
        {
            return AuthorityManager.Instance.CurrentOperatorID;
        }

        public SoftWareData GetSoftWareData()
        {
            SoftWareData softWareData = new SoftWareData
            {
                SoftWareName = SwManager.Instance.SwName,
                TaskVersion = SwManager.Instance.TaskVer,
                SoftWareVersion = UIGlobal.Version,
                SoftWareHashCode = SwManager.Instance.SoftWareHashCode,
                VisionHashCode = SwManager.Instance.VisionHashCode
            };
            return softWareData;
        }

        public void SetSiteInfo(string site)
        {
            SwManager.Instance.Site = site;
        }

        public bool SiteAlert(string site)
        {
            return SwManager.Instance.SiteAlert(site);
        }

        public void SetSensorStatus(List<StationStatus> stations, List<SensorStatus> sensors, List<Tuple<string, string>> arrows)
        {
            ProxyData.Instance.UpdateSensorStatus(stations, sensors, arrows);
        }

        public void SetFaiInUIbyFaiName(string faiName)
        {
            ((ShowOutputControl)OutputUi).ChangeFaiByName(faiName);
        }

        #endregion



        #region Method_ExternalUsing
        /// <summary>日志增加</summary>
        /// <param name="msg">消息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示报警弹窗；false：不显示报警弹窗</param>
        public void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            string tempId = $"{(int)lv}{(int)PrimLogId.ShowCapacityOfProduction}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.ShowCapacityOfProduction.ToString(), LogClassification.Other, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>软件配置切换当前产品时发生</summary>
        /// <param name="productName"></param>
        /// <param name="products">产品集合</param>
        private void InstanceSoftwareConfigChangeCurrentProduct(string productName, List<string> products)
        {
            ProductType = productName;
        }

        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        #endregion
    }
}