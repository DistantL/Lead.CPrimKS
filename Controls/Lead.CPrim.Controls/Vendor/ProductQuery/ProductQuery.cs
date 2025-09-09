/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: HistoryQueryByMongoDb.cs
 * Author: Victor
 * Description: 产品历史数据
 * CreateTime: 2023-1-1
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230101>
 * 1、历史数据与曲线数据进行合并
******************************************************************************/

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProductInfoHelper;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using LeadScriptLibrary;
using ScriptLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>产品历史数据</summary>
    public partial class ProductQuery : UIPage
    {
        #region Field
        /// <summary>查询集合</summary>
        private List<ProductInfo> _queryProductInfos = null;

        /// <summary>计时</summary>
        Stopwatch sw = new Stopwatch();

        /// <summary>产品历史数据对象</summary>
        private static ProductQuery _instance = new ProductQuery();
        #endregion



        #region Prop
        /// <summary>产品历史数据对象</summary>
        public static ProductQuery Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        public ProductQuery()
        {
            InitializeComponent();
            //SetStyle();

            dgvResult.SetStyle(true, false, false, DataGridViewAutoSizeColumnsMode.DisplayedCells);
            dgvResult.ReadOnly = true;

            tlpMain.SetDoubleBuffered();
            tlpTitle.SetDoubleBuffered();
            tlpStatic.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void HistoryQueryByMongoDb_Load(object sender, EventArgs e)
        {
            //界面数据
            DateTime now = DateTime.Now;
            dtpStartTime.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            dtpEndTime.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(1);
            lbUph.Text = "";

            //结果表单设置
            dgvResult.ScrollBars = ScrollBars.Both;
        }
        #endregion



        #region Button_Event
        /// <summary>查询</summary>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            QueryData();
        }
        /// <summary>删除</summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ShowAskDialog("删除后数据无法恢复，确定进行数据删除吗？"))
                {
                    return;
                }
                Cursor = Cursors.WaitCursor;

                sw.Restart();
                dgvResult.DataSource = null;
                tbOk.Text = "";
                tbNg.Text = "";
                tbTotal.Text = "";
                tbRate.Text = "";
                tbCt.Text = "";
                lbUph.Text = "";

                string beginTime = dtpStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                string station = "";
                string product = "";

                if (cmbStations.SelectedItem == null || string.IsNullOrEmpty(cmbStations.SelectedItem.ToString()))
                {
                    throw new Exception("请选择工站");
                }

                if (cmbProducts.SelectedItem == null || string.IsNullOrEmpty(cmbProducts.SelectedItem.ToString()))
                {
                    throw new Exception("请选择产品");
                }

                station = cmbStations.SelectedItem.ToString();
                product = cmbProducts.SelectedItem.ToString();

                _ = MongodbHelper.DeleteAllByTime<ProductInfo>(beginTime, endTime, station + "_" + product, null);
                sw.Stop();
                Notification.ShowInfo("删除成功: " + sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                ProxyTools.Notification.ShowError("删除失败: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        /// <summary>复杂查询</summary>
        private void btnComplexQuery_Click(object sender, EventArgs e)
        {
            string filePath = SwManager.Instance.ComplexQueryTaskFilePath;
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("复杂查询所用脚本不存在，请检查！");
                return;
            }
            List<ProductInfo> listPros = QueryData();
            if (listPros == null)
            {
                MessageBox.Show("未查询到记录");
                return;
            }
            string[] filePaths = new string[1] { filePath };
            try
            {
                AsmHelper helper = new AsmHelper(LeadScript.LoadFiles(filePaths, Array.Empty<string>()));
                object instance = helper.TryCreateObject("RunState", Array.Empty<object>());
                object result = helper.InvokeInst(instance, "Init", new object[4]
                {
                    listPros,
                    dtpStartTime.Value,
                    dtpEndTime.Value,
                    (cmbProducts.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbProducts.SelectedItem.ToString())) ? cmbProducts.SelectedItem.ToString() : SwManager.Instance.CurrentProduct
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>复制</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dgvResult.CurrentCell.Value?.ToString());
        }
        /// <summary>导出</summary>
        private void tmsiExport_Click(object sender, EventArgs e)
        {
            string errorTxet = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(dgvResult, true, ref errorTxet, 0))
            {
                Notification.ShowError(errorTxet);
            }
        }
        /// <summary>清除</summary>
        private void tsmiClear_Click(object sender, EventArgs e)
        {
            dgvResult.DataSource = null;
            dgvResult.Rows.Clear();

            tbOk.Text = "";
            tbNg.Text = "";
            tbTotal.Text = "";
            tbRate.Text = "";
            tbCt.Text = "";
            lbUph.Text = "";

            _queryProductInfos = null;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>产品更新</summary>
        /// <param name="products">产品集合</param>
        public void UpdateProducts(List<string> stations, List<string> products)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<List<string>, List<string>>(UpdateProducts), new object[2] { stations, products });
                return;
            }

            if (stations != null && stations.Count > 0)
            {
                if (cmbStations.SelectedItem == null)
                {
                    cmbStations.Items.Clear();
                    cmbStations.Items.AddRange(stations.ToArray());
                }
                else
                {
                    string name = cmbStations.SelectedItem.ToString();
                    cmbStations.Items.Clear();
                    cmbStations.Items.AddRange(stations.ToArray());
                    if (stations.Contains(name))
                    {
                        cmbStations.SelectedItem = name;
                    }
                    else
                    {
                        cmbStations.SelectedItem = null;
                    }
                }
            }

            if (products != null && products.Count > 0)
            {
                if (cmbProducts.SelectedItem == null)
                {
                    cmbProducts.Items.Clear();
                    cmbProducts.Items.AddRange(products.ToArray());
                    cmbProducts.Items.Add("");
                    cmbProducts.Items.Add("GRR");
                }
                else
                {
                    string name = cmbProducts.SelectedItem.ToString();
                    cmbProducts.Items.Clear();
                    cmbProducts.Items.AddRange(products.ToArray());
                    cmbProducts.Items.Add("");
                    cmbProducts.Items.Add("GRR");
                    if(products.Contains(name))
                    {
                        cmbProducts.SelectedItem = name;
                    }
                    else
                    {
                        cmbProducts.SelectedItem = null;
                    }
                }
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>数据查询</summary>
        /// <returns>集合</returns>
        private List<ProductInfo> QueryData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                sw.Restart();
                dgvResult.DataSource = null;
                tbOk.Text = "";
                tbNg.Text = "";
                tbTotal.Text = "";
                tbRate.Text = "";
                tbCt.Text = "";
                lbUph.Text = "";

                string beginTime = dtpStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                string station = "";
                string product = "";
                if (cmbStations.SelectedItem == null || string.IsNullOrEmpty(cmbStations.SelectedItem.ToString()))
                {
                    throw new Exception("请选择工站");
                }

                if (cmbProducts.SelectedItem == null || string.IsNullOrEmpty(cmbProducts.SelectedItem.ToString()))
                {
                    throw new Exception("请选择产品");
                }

                station = cmbStations.SelectedItem.ToString();
                product = cmbProducts.SelectedItem.ToString();
                long okCount = default(long);
                long ngCount = default(long);
                double uph = default(double);

                if (!string.IsNullOrEmpty(tbId.Text.Trim()))
                {
                    int iRet = MongodbHelper.QueryMany("Sn", tbId.Text, out _queryProductInfos, station + "_" + product);
                    if (iRet != 0)
                    {
                        dgvResult.DataSource = null;
                        sw.Stop();
                        Notification.ShowError("QueryMany失败: " + sw.ElapsedMilliseconds + "，异常原因 + " + (SoftWareAlarm)iRet);
                        return null;
                    }
                }
                else
                {
                    int iRet = MongodbHelper.QueryManyByTime(beginTime, endTime, out _queryProductInfos, out okCount, out ngCount, out uph, cbNoIncludeOk.Checked, cbNoIncludeNg.Checked, station + "_" + product, null);
                    if (iRet != 0)
                    {
                        dgvResult.DataSource = null;
                        sw.Stop();
                        Notification.ShowError("QueryMany失败: " + sw.ElapsedMilliseconds + "，异常原因 + " + (SoftWareAlarm)iRet);
                        return null;
                    }
                }

                if (_queryProductInfos == null || _queryProductInfos.Count == 0)
                {
                    throw new Exception("该时间范围内无数据，请改变查询时间");
                }

                dgvResult.DataSource = DataHelper.ListToDataTable(_queryProductInfos);
                DgvRefresh(dgvResult);
                tbOk.Text = okCount.ToString();
                tbNg.Text = ngCount.ToString();
                tbTotal.Text = (okCount + ngCount).ToString();
                if (okCount <= 0)
                {
                    tbRate.Text = "0.0%";
                }
                else
                {
                    tbRate.Text = (okCount / (okCount + ngCount)).ToString("P2");
                }
                lbUph.Text = uph.ToString("F0");
                if (_queryProductInfos.Count > 0)
                {
                    double ctAverage = _queryProductInfos.Average((ProductInfo t) => t.CT);
                    tbCt.Text = ctAverage.ToString("F2");
                }
                sw.Stop();
                Notification.ShowInfo("QueryMany: spend time :" + sw.ElapsedMilliseconds + "ms");
                return _queryProductInfos;
            }
            catch (Exception ex)
            {
                this.ShowWarningDialog("查询失败: " + ex.Message);
                return null;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>时间格式设置</summary>
        /// <param name="dgv">DataGridView</param>
        private void DgvRefresh(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Name.Contains("CreateTime"))
                {
                    dgv.Columns[i].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
            }
            dgv.Refresh();
        }
        #endregion

        public void OnLanguageChanged()
        {
            lb_StartTime.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_StartTime", "起始时间：");
            lb_EndTime.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_EndTime", "结束时间：");
            lb_StationName.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_StationName", "工站：");
            lb_ProductionName.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_ProductionName", "产品：");
            btnSearch.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_Search", "查询");
            btnDelete.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_Delete", "删除");
            btnComplexQuery.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_ComplexQuery", "复杂查询");
            cbNoIncludeOk.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_NoIncludeOk", "筛除OK结果");
            cbNoIncludeNg.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_NoIncludeNg", "筛除NG结果");
            lb_Yield.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_Yield", "良率：");
            lb_Total.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_Total", "总计：");
            lb_CT.Text = NLocalizer.GetString("Lead_CPrim_Controls_ProductQuery_CT", "平均CT：");
        }
    }
}
