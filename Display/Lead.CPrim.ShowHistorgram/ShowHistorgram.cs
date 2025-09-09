/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowHistorgram.cs
 * Author: Victor
 * Description: 直方图实现类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、代码风格重新布局以及增加备注
 * 2、显示基元增加LogAdd函数
 * 3、增加日志使能属性
******************************************************************************/


using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ShowHistorgram.Controls;
using Lead.CPrim.ShowHistorgram.FaiAnaylise;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.ShowHistorgram
{
    public class ShowHistorgram : IShow, IHistorgram
    {
        #region Field
        private HistorgramConfig _config;
        /// <summary>FAI项集合</summary>
        public Dictionary<string, FaiCount> faisDic = new Dictionary<string, FaiCount>();
        #endregion



        #region Ctor
        public ShowHistorgram()
        {
            _config = new HistorgramConfig();
            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);
        }
        public ShowHistorgram(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(HistorgramConfig)) as HistorgramConfig;
            else
                return;

            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);
        }
        #endregion



        #region Prop

        public double TotalRate { get; set; } = 1.0;

        public double BarcodeRate { get; set; } = 1.0;
        /// <summary>正常区域分组数</summary>
        public int NormalParts { get => _config.NormalParts; set => _config.NormalParts = value; }
        /// <summary>超下限分组数</summary>
        public int LowerParts { get => _config.LowerParts; set => _config.LowerParts = value; }
        /// <summary>超上限分组数</summary>
        public int UperParts { get => _config.UperParts; set => _config.UperParts = value; }
        /// <summary>图片保存文件夹</summary>
        public string SavePicPath { get => _config.PicSavePath; set => _config.PicSavePath = value; }
        /// <summary>良率显示使能</summary>
        public bool EnableBarcode { get => _config.EnableBarcode; set => _config.EnableBarcode = value; }
        /// <summary>true：显示日志；false：不显示日志</summary>
        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }
        /// <summary>排序类型</summary>
        public SortType SortType { get; set; }
        #endregion



        //*****************************************************************************
        #region Override IHistorgram
        public void AddSingleFaiVal(string faiName, double faivalue, double Uper, double lower)
        {
            if (faisDic.ContainsKey(faiName))
            {
                faisDic[faiName].AddFai(faivalue);
            }
            else
            {
                var fai = new FaiCount(faiName, Uper, lower, this);
                fai.AddFai(faivalue);
                faisDic.Add(fai.FaiName, fai);
            }
        }
        public void ClrData()
        {
            foreach (var fai in faisDic.Values)
            {
                fai.clrData();
            }
        }
        public void refreshOutputUi()
        {
            ((ShowOutputControl)OutputUi).RefreshOutput();
        }
        public int GetCpk(string faiName, out double cpk)
        {
            if (faisDic.ContainsKey(faiName))
            {
                cpk = faisDic[faiName].Cpk;
                return 0;
            }
            else
            {
                cpk = -1;
                LogAdd($"直方图不包含FAI项{faiName}", LogLevel.Warn);
                return (int)SoftWareAlarm.Historgram_FAI不存在;
            }
        }
        public int GetCp(string faiName, out double cp)
        {
            if (faisDic.ContainsKey(faiName))
            {
                cp = faisDic[faiName].Cp;
                return 0;
            }
            else
            {
                cp = -1;
                LogAdd($"直方图不包含FAI项{faiName}", LogLevel.Warn);
                return (int)SoftWareAlarm.Historgram_FAI不存在;
            }
        }
        public int GetOkRate(string faiName, out double rate)
        {
            if (faisDic.ContainsKey(faiName))
            {
                rate = faisDic[faiName].OkRate;
                return 0;
            }
            else
            {
                rate = -1;
                LogAdd($"直方图不包含FAI项{faiName}", LogLevel.Warn);
                return (int)SoftWareAlarm.Historgram_FAI不存在;
            }
        }
        public void RefreshTotalResult(double TotalRate, double BarcodeRate = 1.0)
        {
            this.TotalRate = TotalRate;
            this.BarcodeRate = BarcodeRate;
        }
        #endregion



        //*****************************************************************************
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
        public int IShowImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(HistorgramConfig)) as HistorgramConfig;
            else
                return -1;
            return iRet;
        }
        public XmlNode IShowExportConfigXml()
        {
            if (_config == null) return null;

            var node = ProxyTools.XMLHelper.ObjectToXML(_config);

            return node;
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>日志增加</summary>
        /// <param name="msg">消息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示报警弹窗；false：不显示报警弹窗</param>
        public void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            if (!LogEnable)
            {
                return;
            }

            string tempId = $"{(int)lv}{(int)PrimLogId.ShowHistorgram}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, msg, PrimLogId.ShowHistorgram.ToString(), LogClassification.VisioPrim, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
        #endregion
    }
}