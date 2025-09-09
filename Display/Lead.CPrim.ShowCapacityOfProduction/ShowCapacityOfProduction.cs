using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ShowCapacityOfProduction.Controls;
using Lead.CPrim.TaskHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.ShowCapacityOfProduction
{
    /// <summary>AQCI管理器</summary>
    public class ShowCapacityOfProduction : IShow, IShowCapacityOfProduction
    {
        #region Field
        private string _barCode;
        /// <summary>配置管理器</summary>
        private CapacityOfProductionConfig _config;
        public Production _product;
        /// <summary>产品数据默认保存路径</summary>
        private string _productDefaultPath = @"‪D:\Config\SaveConfig\Production.json";

        private string _productType;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowCapacityOfProduction()
        {
            _config = new CapacityOfProductionConfig();
            _product = new Production();
            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode"></param>
        public ShowCapacityOfProduction(XmlNode xmlNode)
        {
            if (xmlNode == null) return;

            _config = XMLHelper.XMLToObject(xmlNode, typeof(CapacityOfProductionConfig)) as CapacityOfProductionConfig;
            if (_config != null && !string.IsNullOrEmpty(_config.ProductPath))
            {
                _product = JsonHelper.DeserializeJsonFileToObject<Production>(_config.ProductPath);
            }
            else
            {
                _product = JsonHelper.DeserializeJsonFileToObject<Production>(_productDefaultPath);
            }
            if (TaskSmManger.Instance.TaskSMs != null && !string.IsNullOrEmpty(StationName) &&
                TaskSmManger.Instance.TaskSMs.ContainsKey(StationName))
            {
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[StationName]).ChangeUIStateEvent += OnChangeUIStateEvent;
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[StationName]).RefreshOperaInfoEvent += OnRefreshOperaInfoEvent;
            }

            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);

            if (SwManager.Instance.CurrentProduct != null) ProductType = SwManager.Instance.CurrentProduct;
            SwManager.Instance.OnSoftwareConfigChangeCurrentProduct += InstanceSoftwareConfigChangeCurrentProduct;

            DataUpdate(_product);
        }
        #endregion



        #region Prop
        /// <summary>总数量</summary>
        internal double NumCount
        {
            set
            {
                _product.Input = value;
                ((ShowOutputControl)OutputUi).UpdateNumCount(value);
            }
            get => _product.Input;
        }
        /// <summary>良率</summary>
        internal double PassRate
        {
            set
            {
                _product.Rate = value;
                ((ShowOutputControl)OutputUi).UpdatePassRate(value);
            }
            get => _product.Rate;
        }
        /// <summary>OK数量</summary>
        internal double NumOk
        {
            set
            {
                _product.OKCount = value;
            }
            get => _product.OKCount;
        }
        /// <summary>NG数量</summary>
        internal double NumNg
        {
            set
            {
                _product.NGCount = value;
            }
            get => _product.NGCount;
        }
        /// <summary>Ct</summary>
        internal double Ct
        {
            set
            {
                _product.CT = value;
                ((ShowOutputControl)OutputUi).UpdateCt(value);
            }
            get => _product.CT;
        }
        /// <summary>产品类型</summary>
        internal string ProductType
        {
            set
            {
                _productType = value;
            }
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
        /// <summary>产能路径</summary>
        public string ProductPath { set => _config.ProductPath = value; get => _config.ProductPath; }
        /// <summary>当前FAI名称</summary>
        public string CurrentFAIName { set => _config.CurrentFAIName = value; get => _config.CurrentFAIName; }
        /// <summary>工站切换</summary>
        /// <param name="newStationName"></param>
        internal void ChangeStation(string newStationName)
        {
            if (string.IsNullOrEmpty(newStationName)) return;

            if (string.IsNullOrEmpty(StationName)) StationName = newStationName;
            if (TaskSmManger.Instance.TaskSMs.ContainsKey(StationName))
            {
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[StationName]).ChangeUIStateEvent -= OnChangeUIStateEvent;
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[StationName]).RefreshOperaInfoEvent -= OnRefreshOperaInfoEvent;
            }

            if (TaskSmManger.Instance.TaskSMs.ContainsKey(newStationName))
            {
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[newStationName]).ChangeUIStateEvent += OnChangeUIStateEvent;
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[newStationName]).RefreshOperaInfoEvent += OnRefreshOperaInfoEvent;
            }

            StationName = newStationName;
        }
        /// <summary>运行状态栏更新</summary>
        /// <param name="sta">状态栏信息</param>
        /// <param name="color">颜色</param>
        private void OnChangeUIStateEvent(string sta, Color color)
        {
            ((ShowOutputControl)OutputUi).ChangeUIState(sta, color);
        }
        /// <summary>运行提示栏更新</summary>
        /// <param name="msg">提示栏信息</param>
        /// <param name="isTwinkle">是否闪烁</param>
        private void OnRefreshOperaInfoEvent(string msg, bool isTwinkle)
        {
            ((ShowOutputControl)OutputUi).RefreshOperaInfo(msg, isTwinkle);
        }
        /// <summary>切换颜色集合</summary>
        /// <param name="proColors">颜色集合</param>
        internal void UpdateProColors(List<string> proColors)
        {
            OnUpdateProColors?.Invoke(proColors);
        }
        /// <summary>切换当前颜色</summary>
        /// <param name="proColor"></param>
        internal void ChangeCurrentProColor(string proColor)
        {
            CurProColor = proColor;
            OnChangeCurrentProColor?.Invoke(proColor);
        }
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
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(CapacityOfProductionConfig)) as CapacityOfProductionConfig;
            return _config == null ? -1 : 0;
        }
        #endregion



        #region Override IShowCapacityOfProduction
        public event ChangeCurrentProColor OnChangeCurrentProColor;
        public event UpdateProColors OnUpdateProColors;

        public int AddProInfo<T>(List<T> listEntiy, bool saveDataBase = false, string proTypeName = "", bool updateStatistic = false, Dictionary<string, bool> results = null) where T : class
        {
            var iRet = 0;

            if (string.IsNullOrEmpty(proTypeName))
            {
                proTypeName = !string.IsNullOrEmpty(ProductType) ? ProductType : @"parts";
            }

            ((ShowOutputControl)OutputUi).AddMultiPartInfo(listEntiy, saveDataBase, proTypeName, updateStatistic, results);

            return iRet;
        }
        public int AddProInfo<T>(T entiy, bool saveDataBase = false, string proTypeName = "",
            bool updateStatistic = false, Dictionary<string, bool> results = null) where T : class
        {
            var iRet = 0;

            var listEntiy = new List<T> { entiy };

            if (string.IsNullOrEmpty(proTypeName))
            {
                proTypeName = !string.IsNullOrEmpty(ProductType) ? ProductType : @"parts";
            }

            ((ShowOutputControl)OutputUi).AddMultiPartInfo(listEntiy, saveDataBase, proTypeName, updateStatistic, results);

            return iRet;
        }
        public void UpdateBarcode(string barCode)
        {
            if (!string.IsNullOrEmpty(barCode)) BarCode = barCode;
        }
        public void UpdateCt(double ct)
        {
            Ct = ct;
        }
        public void UpdateProduct(int result = 1, string barCode = "")
        {
            if (result == 1)
            {
                NumOk++;
                ((ShowOutputControl)OutputUi).UpdateProductResult(1, barCode);
            }
            else
            {
                NumNg++;
                ((ShowOutputControl)OutputUi).UpdateProductResult(0, barCode);
            }
            ((ShowOutputControl)OutputUi).UpdateNum($"{NumOk}/{NumNg}");
            NumCount++;

            PassRate = NumOk / NumCount;

            if (!string.IsNullOrEmpty(barCode)) BarCode = barCode;
        }
        public void UpdateProductType(string newType)
        {
            ProductType = newType;
        }
        public void RefreshOperaMode(string mode)
        {
            ((ShowOutputControl)OutputUi).RefreshOperaMode(mode);
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
        /// <summary>保存产品数据</summary>
        public void SaveProduct()
        {
            JsonHelper.SerializeObjectToFile(_product, string.IsNullOrEmpty(ProductPath) ? _productDefaultPath : ProductPath);
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>软件配置切换当前产品时发生</summary>
        /// <param name="productName"></param>
        /// <param name="porducts">产品集合</param>
        private void InstanceSoftwareConfigChangeCurrentProduct(string productName, List<string> porducts)
        {
            ProductType = productName;
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        /// <summary>数据更新</summary>
        private void DataUpdate(Production production = null)
        {
            if (production == null)
            {
                NumCount = 0;
                PassRate = 1;
                NumOk = 0;
                NumNg = 0;
                Ct = 0;
                ((ShowOutputControl)OutputUi).UpdateNum("0/0");
            }
            else
            {
                NumCount = production.Input;
                PassRate = production.Rate;
                NumOk = production.OKCount;
                NumNg = production.NGCount;
                Ct = production.CT;
            }
            ((ShowOutputControl)OutputUi).UpdateProductResult(-1);
        }
        #endregion
    }
}