/******************************************************************************
 * CPrim;
 * CopyRight (C) 2020-2030.
 * FileName: ShowOutputControl.cs
 * Author: Victor
 * Description: 显示基元ShowCapacityOfProduction之output界面
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1010><Victor><20221010>
 * 1、将界面上控件进行双缓存设置
******************************************************************************/

using Lead.CPrim.FaiHelper;
using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lead.CPrim.ShowCapacityOfProduction.Controls
{
    /// <summary>输出UI</summary>
    public partial class ShowOutputControl : UIUserControl
    {
        #region Field
        /// <summary>AQCI管理器</summary>
        private readonly ShowCapacityOfProduction _show;
        /// <summary>列表模式</summary>
        ProductInfoList _listMode;
        /// <summary>图表模式</summary>
        ChartMode _chartMode;
        /// <summary>分析模式</summary>
        AnalysisMode _analysisMode;
        /// <summary>最近10片CT</summary>
        private List<double> _lCt = new List<double>();
        /// <summary>FAI集合</summary>
        private List<string> _lFaiName = new List<string>();
        /// <summary>LogPath</summary>
        private string logPath = @"D:\CPrimlog";
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="show">AQCI管理器</param>
        public ShowOutputControl(ShowCapacityOfProduction show)
        {
            InitializeComponent();
            SetStyleFlags();
            _show = show;

            _listMode = new ProductInfoList();
            _chartMode = new ChartMode();
            _analysisMode = new AnalysisMode();
            tlpTitle.SetDoubleBuffered();
            tlpRight.SetDoubleBuffered();
            tlpStatic.SetDoubleBuffered();
            tlpMain.SetDoubleBuffered();
            splData.SetDoubleBuffered();
            tlpInfoAll.SetDoubleBuffered();
            tlpInfoUp.SetDoubleBuffered();
            lbVersion.Text = UIGlobal.Version;
            lbTaskVer.Text = $"{SwManager.Instance.TaskVer}";
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowOutputControl_Load(object sender, EventArgs e)
        {
            rdoList.Checked = true;
            if (!string.IsNullOrEmpty(_show.CurrentFAIName) && FaiManager.Instance.Products.ContainsKey(SwManager.Instance.CurrentProduct))
            {
                foreach (var item in FaiManager.Instance.Products[SwManager.Instance.CurrentProduct].SimpleConfigs.Values.FirstOrDefault(fai => fai.Name == _show.CurrentFAIName).FaiConfigs.Values)
                {
                    if (item.Enable)
                    {
                        _lFaiName.Add(item.Name);
                    }
                }
                _analysisMode.CbInit(_lFaiName);
            }
        }
        #endregion



        #region Button_Event
        /// <summary>清除所有数据</summary>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"你确定要清除当前产能吗?", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DataInit();
            }
        }
        /// <summary>模式选择</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoModeExchange_CheckedChanged(object sender, EventArgs e)
        {
            UIRadioButton rdo = sender as UIRadioButton;
            if (rdo == null)
            {
                return;
            }

            splData.Panel2.Controls.Clear();
            if (rdo.Text == "列表模式" && rdo.Checked)
            {
                _listMode.Dock = DockStyle.Fill;
                _listMode.Show();
                splData.Panel2.Controls.Add(_listMode);
            }
            else if (rdo.Text == "图表模式" && rdo.Checked)
            {
                _chartMode.Dock = DockStyle.Fill;
                _chartMode.Show();
                splData.Panel2.Controls.Add(_chartMode);
            }
            else if (rdo.Text == "分析模式" && rdo.Checked)
            {
                _analysisMode.Dock = DockStyle.Fill;
                _analysisMode.Show();
                splData.Panel2.Controls.Add(_analysisMode);
            }
            smShow.Show();
        }
        /// <summary>机台日志</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMachineLog_Click(object sender, EventArgs e)
        {
            try
            {
                string machineLog = SwManager.Instance.MachinePath;
                if (Directory.Exists(machineLog))
                {
                    Process.Start(machineLog);
                    return;
                }

                if (Directory.Exists(logPath))
                {
                    Process.Start(logPath);
                }
            }
            catch
            {
                
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>更新产品结果</summary>
        /// <param name="result">1：OK；0：NG；other：不显示</param>
        /// <param name="id"></param>
        internal void UpdateProductResult(int result, string id = "")
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int, string>(UpdateProductResult), new object[2] { result, id });
            }
            else
            {
                SuspendLayout();
                lblResult.BackColor = result == 1 ? Color.FromArgb(0, 249, 0) : (result == 0 ? Color.FromArgb(236, 93, 87) : Color.Gray);
                lblResult.Text = id.IsNullOrWhiteSpace() ? "-" : id;
                ResumeLayout();
            }
        }
        /// <summary>更新总数量</summary>
        /// <param name="value">数量</param>
        internal void UpdateNumCount(double value)
        {
            ControlHelper.SetText(lblInput, value.ToString());
        }
        /// <summary>更新良率</summary>
        /// <param name="value">良率</param>
        internal void UpdatePassRate(double value)
        {
            ControlHelper.SetText(lblYield, $@"{value * 100.0:F1}%");
        }
        /// <summary>pass/fail统计</summary>
        /// <param name="value">pass/fail</param>
        internal void UpdateNum(string value)
        {
            ControlHelper.SetText(lblPass, value);
        }
        /// <summary>更新CT</summary>
        /// <param name="value">CT</param>
        internal void UpdateCt(double value)
        {
            ControlHelper.SetText(lblCT, value.ToString("F2"));
        }
        /// <summary>UI[OperateInstruction]运行状态栏更新</summary>
        /// <param name="sta">内容</param>
        /// <param name="color">颜色</param>
        internal void ChangeUIState(string sta, Color color)
        {
            if (smShow.InvokeRequired)
            {
                BeginInvoke(new Action<string, Color>(ChangeUIState), sta, color);
            }
            else
            {
                smShow.ChangeState(sta, color);
            }
        }
        /// <summary>UI[OperateInstruction]运行提示栏更新</summary>
        /// <param name="msg">内容</param>
        /// <param name="isTwinkle">是否闪烁</param>
        internal void RefreshOperaInfo(string msg, bool isTwinkle)
        {
            if (smShow.InvokeRequired)
            {
                BeginInvoke(new Action<string, bool>(RefreshOperaInfo), msg, isTwinkle);
            }
            else
            {
                smShow.ShowOperaInfo(msg, isTwinkle);
            }
        }
        /// <summary>UI[OperateInstruction]运行模式更新</summary>
        /// <param name="mode">模式</param>
        internal void RefreshOperaMode(string mode)
        {
            if (smShow.InvokeRequired)
                BeginInvoke(new Action<string>(RefreshOperaMode), mode);
            else
                smShow.ShowOperaMode(mode);
        }
        /// <summary>添加数据</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntiy"></param>
        /// <param name="saveDataBase"></param>
        /// <param name="productName"></param>
        /// <param name="updateStatistic"></param>
        /// <param name="results"></param>
        internal void AddMultiPartInfo<T>(List<T> listEntiy, bool saveDataBase, string productName, bool updateStatistic = false, Dictionary<string, bool> results = null) where T : class
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<List<T>, bool, string, bool, Dictionary<string, bool>>(AddMultiPartInfo),
                    new object[5] { listEntiy, saveDataBase, productName, updateStatistic, results });
            }
            else
            {
                if (listEntiy == null || listEntiy.Count <= 0)
                {
                    return;
                }

                if (_show.StationName != null)
                {
                    if (productName.IsNullOrEmpty())
                    {
                        productName = "parts";
                    }

                    productName = $"{_show.StationName}_{productName}";
                }

                //写入数据库
                if (saveDataBase)
                {
                    if (listEntiy.Count > 1)
                    {
                        _ = MongodbHelper.InsertManyAsync(listEntiy, productName);
                    }
                    else
                    {
                        _ = MongodbHelper.InsertOneAsync(listEntiy[0], productName);
                    }
                }

                var propInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (propInfo == null || propInfo.Length <= 0)
                {
                    return;
                }
                var propertyCreateTime = typeof(T).GetProperty("CreateTime");
                var propertyID = typeof(T).GetProperty("ID");
                var propertyResult = typeof(T).GetProperty("Result");
                var propertyCt = typeof(T).GetProperty("CT");

                var dicColName = DataHelper.GetDataTableColumns(listEntiy, ref propInfo);

                foreach (var item in listEntiy)
                {
                    var values = DataHelper.GetDataTableRowValue(item, propInfo, dicColName);
                    string id = propertyID == null ? "" : propertyID.GetValue(item).ToString();
                    if (propertyResult != null)
                    {
                        if (propertyResult.GetValue(item).ToString().ToLower() == "ok" || propertyResult.GetValue(item).ToString() == "1")
                        {
                            _show.UpdateProduct(1, id);

                        }
                        else
                        {
                            _show.UpdateProduct(0, id);
                        }
                    }

                    if (propertyCt != null && double.TryParse(propertyCt.GetValue(item).ToString(), out var retCt))
                    {
                        if (_lCt.Count > 10)
                        {
                            _lCt.RemoveAt(0);
                        }
                        _lCt.Add(retCt);
                    }

                    _listMode.InsertData(dicColName, values, results);
                }

                _show.UpdateCt(_lCt.Average());


                //BY Hour统计
                if (propertyCreateTime != null && propertyResult != null)
                {
                    foreach (var entiy in listEntiy)
                    {
                        DateTime dateTime;
                        if (DateTime.TryParse(propertyCreateTime.GetValue(entiy).ToString(), out dateTime) &&
                            (propertyResult.GetValue(entiy).ToString().ToLower() == "ok" || propertyResult.GetValue(entiy).ToString() == "1"))
                        {
                            _chartMode.DataProcessing(dateTime.Hour, true);
                        }
                        else
                        {
                            _chartMode.DataProcessing(dateTime.Hour, false);
                        }
                    }
                }

                _show.SaveProduct();
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>数据初始化</summary>
        private void DataInit(bool isClear = true)
        {
            if (isClear)
            {
                _show.NumCount = 0;
                _show.PassRate = 0;
                _show.NumOk = 0;
                _show.NumNg = 0;
                _show.Ct = 0;
                _listMode.ClearData(false);
                _chartMode.ClearData();
            }
            UpdateProductResult(-1);
            _show.SaveProduct();

        }
        #endregion
    }
}