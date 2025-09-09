using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.ShowAQCI.Controls;
using Lead.CPrim.TaskHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.ShowAQCI
{
    /// <summary>AQCI管理器</summary>
    public class ShowAQCI : IShow, IAShowCommon
    {
        #region Field
        private string _barCode;
        /// <summary>AQCI配置管理器</summary>
        private AQCIConfig _config;
        /// <summary>OK数量</summary>
        private double _numOk;
        /// <summary>NG数量</summary>
        private double _numNg;
        /// <summary>总数量</summary>
        private double _numCount;
        /// <summary>CT</summary>
        private double _ct;
        /// <summary>良率</summary>
        private double _passRate;

        private string _productType;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowAQCI()
        {
            _config = new AQCIConfig();
            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode"></param>
        public ShowAQCI(XmlNode xmlNode)
        {
            if (xmlNode == null) return;

            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(AQCIConfig)) as AQCIConfig;
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
        }
        #endregion



        #region Prop
        /// <summary>OK数量</summary>
        internal double NumOk
        {
            set
            {
                _numOk = value;
                ((ShowOutputControl)OutputUi).UpdateNumOk(value);
            }
            get => _numOk;
        }
        /// <summary>NG数量</summary>
        internal double NumNg
        {
            set
            {
                _numNg = value;
                ((ShowOutputControl)OutputUi).UpdateNumNg(value);
            }
            get => _numNg;
        }

        /// <summary>总数量</summary>
        internal double NumCount
        {
            set
            {
                _numCount = value;
                ((ShowOutputControl)OutputUi).UpdateNumCount(value);
            }
            get => _numCount;
        }
        /// <summary>Ct</summary>
        internal double Ct
        {
            set
            {
                _ct = value;
                ((ShowOutputControl)OutputUi).UpdateCt(value);
            }
            get => _ct;
        }
        /// <summary>良率</summary>
        internal double PassRate
        {
            set
            {
                _passRate = value;
                ((ShowOutputControl)OutputUi).UpdatePassRate(value);
            }
            get => _passRate;
        }

        internal string ProductType
        {
            set
            {
                _productType = value;
                ((ShowOutputControl)OutputUi).UpdateProductType(value);
            }
            get => _productType;
        }

        internal string BarCode
        {
            set
            {
                _barCode = BarCode;
                ((ShowOutputControl)OutputUi).UpdateBarCode(value);
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
        /// <summary>图片名称</summary>
        internal string PicFileName { set => _config.PicFileName = value; get => _config.PicFileName; }
        /// <summary>图片路径</summary>
        internal string PicFilePath { set => _config.PicFilePath = value; get => _config.PicFilePath; }
        /// <summary>[ShowConfigControl]调用（界面设计）</summary>
        internal void LoadTablePanel()
        {
            ((ShowOutputControl)OutputUi).LoadTablePanel();
        }
        /// <summary>[ShowConfigControl]调用（颜色更新）</summary>
        internal void LoadProColors()
        {
            ((ShowOutputControl)OutputUi).LoadProColors();
        }
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
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(AQCIConfig)) as AQCIConfig;
            return _config == null ? -1 : 0;
        }
        #endregion



        #region Override IAShowCommon
        public event ChangeCurrentProColor OnChangeCurrentProColor;
        public event UpdateProColors OnUpdateProColors;


        public bool ShowRtData { set => _config.ShowRtData = value; get => _config.ShowRtData; }
        public bool ShowPic { set => _config.ShowPic = value; get => _config.ShowPic; }
        public float PerRow1 { set => _config.PerRow1 = value; get => _config.PerRow1; }
        public float PerRow2 { set => _config.PerRow2 = value; get => _config.PerRow2; }
        public float PerRow3 { set => _config.PerRow3 = value; get => _config.PerRow3; }
        public float PerCol1 { set => _config.PerCol1 = value; get => _config.PerCol1; }
        public float PerCol2 { set => _config.PerCol2 = value; get => _config.PerCol2; }
        public float PerCol3 { set => _config.PerCol3 = value; get => _config.PerCol3; }

        public int AddFaiByLocation(string faiName, double faiValue, int xPos, int yPos, ShowColor labelColor = ShowColor.Black)
        {
            var font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            Color color;
            switch (labelColor)
            {
                case ShowColor.Red:
                    color = Color.Red;
                    break;
                case ShowColor.Black:
                    color = Color.Black;
                    break;
                case ShowColor.White:
                    color = Color.White;
                    break;
                case ShowColor.Yellow:
                    color = Color.Yellow;
                    break;
                case ShowColor.Blue:
                    color = Color.Blue;
                    break;
                case ShowColor.Green:
                    color = Color.Green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(labelColor), labelColor, null);
            }
            ((ShowOutputControl)OutputUi).AddFaiByLocation(faiName, faiValue, xPos, yPos, font, color);
            return 0;
        }
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
        public int AddResultByLocation(string labelName, int xPos, int yPos, ShowColor labelColor = ShowColor.Black, string labelFont = null)
        {
            var font = SystemFonts.DefaultFont;
            Color color;
            switch (labelColor)
            {
                case ShowColor.Red:
                    color = Color.Red;
                    break;

                case ShowColor.Black:
                    color = Color.Black;
                    break;

                case ShowColor.White:
                    color = Color.White;
                    break;

                case ShowColor.Yellow:
                    color = Color.Yellow;
                    break;

                case ShowColor.Blue:
                    color = Color.Blue;
                    break;

                case ShowColor.Green:
                    color = Color.Green;
                    break;

                default:
                    color = Color.Black;
                    break;
            }

            if (!string.IsNullOrEmpty(labelFont)) font = new FontConverter().ConvertFromString(labelFont) as Font;

            ((ShowOutputControl)OutputUi).AddLabelByLocation(labelName, xPos, yPos, font, color);

            return 0;
        }
        public int ClearPicture()
        {
            ((ShowOutputControl)OutputUi).ClearPicture();
            return 0;
        }
        public int ClearResults()
        {
            ((ShowOutputControl)OutputUi).ClearLabels();
            return 0;
        }
        public int LoadPicture(string productName = null)
        {
            ((ShowOutputControl)OutputUi).LoadPicture(
                string.IsNullOrEmpty(productName) ? PicFilePath : $@"{PicFilePath}\{productName}", PicFileName);

            ClearResults();

            return 0;
        }
        public void UpdateBarcode(string barCode)
        {
            if (!string.IsNullOrEmpty(barCode)) BarCode = barCode;
        }
        public void UpdateCt(double ct)
        {
            Ct = ct;
        }
        public void UpdateProduct(string result = "ok", string barCode = "")
        {
            if (result == "ok")
            {
                NumOk++;
                ((ShowOutputControl)OutputUi).UpdateProductResult(1);
            }
            else
            {
                NumNg++;
                ((ShowOutputControl)OutputUi).UpdateProductResult(0);
            }

            NumCount++;

            PassRate = NumOk / NumCount;

            if (!string.IsNullOrEmpty(barCode)) BarCode = barCode;
        }
        public void UpdateProduct(int result = 1, string barCode = "")
        {
            if (result == 1)
            {
                NumOk++;
                ((ShowOutputControl)OutputUi).UpdateProductResult(1);
            }
            else
            {
                NumNg++;
                ((ShowOutputControl)OutputUi).UpdateProductResult(0);
            }

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
    }
}