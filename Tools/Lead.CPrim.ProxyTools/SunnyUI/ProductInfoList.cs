
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public partial class ProductInfoList : UIPage
    {
        #region Ctor
        public ProductInfoList()
        {
            InitializeComponent();
            dgvRtData.SetStyle(true, false, false, DataGridViewAutoSizeColumnsMode.Fill);

            dgvRtData.ReadOnly = true;
            //dgvRtData .DataSource = new List<ProductionInfo>()
            //{
            //    new ProductionInfo(){Date = DateTime.Now ,Shift = "SD",UnitSN="DDSSr2323",ComponentSN = "fwrwefwef",StartTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(200)),Pass = "ture",CT = 12.3,HiveState = "Idle"},
            //    new ProductionInfo(){Date = DateTime.Now ,Shift = "SD",UnitSN="DDSSr2323",ComponentSN = "fwrwefwef",StartTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(200)),Pass = "ture",CT = 12.3,HiveState = "Idle"},
            //};
        }
        #endregion



        #region Event_System
        private void ProductInfoListMode_Load(object sender, EventArgs e)
        {

        }

        private void ProductInfoListMode_Initialize(object sender, EventArgs e)
        {

        }
        #endregion



        #region Event_Button
        /// <summary>导出数据</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExport_Click(object sender, EventArgs e)
        {

        }
        /// <summary>清除数据</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiClear_Click(object sender, EventArgs e)
        {

        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>DataGridView插入数据</summary>
        /// <param name="titles">标题</param>
        /// <param name="values">值</param>
        /// <param name="results">FAI值结果</param>
        public void InsertData(Dictionary<int, string> titles, object[] values, Dictionary<string, bool> results)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Dictionary<int, string>, object[], Dictionary<string, bool>>(InsertData), new object[3] { titles, values, results });
            }
            else
            {
                SuspendLayout();
                if (dgvRtData.Columns.Count == 0)
                {
                    foreach (var colName in titles)
                    {
                        dgvRtData.Columns.Add(colName.Value, colName.Value);
                    }
                }

                dgvRtData.Rows.Insert(0, values);

                if (results != null)
                {
                    foreach (var fai in results.Keys)
                    {
                        foreach (var col in titles)
                        {
                            if (col.Value.Contains("."))
                            {
                                var colNames = col.Value.Split('.');
                                if (colNames[1] == fai)
                                {
                                    dgvRtData.Rows[0].Cells[col.Key].Style.ForeColor = results[fai] ? Color.DarkGreen : Color.Red;
                                }
                            }
                        }
                    }
                }

                var resultIndex = -1;
                foreach (DataGridViewColumn column in dgvRtData.Columns)
                {
                    if (column.HeaderText == @"Result" || column.HeaderText == @"结果")
                    {
                        resultIndex = column.Index;
                        break;
                    }
                }

                if (resultIndex != -1)
                {
                    dgvRtData.Rows[0].Cells[resultIndex].Style.BackColor = dgvRtData.Rows[0].Cells[resultIndex].Value?.ToString().ToLower() == "ok" || dgvRtData.Rows[0].Cells[resultIndex].Value.ToString() == "1" ? Color.LawnGreen : Color.Red;
                }
                ResumeLayout();
            }
        }

        /// <summary>导出数据</summary>
        public void ExportData()
        {
            string errorText = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(dgvRtData, true, ref errorText))
            {
                Notification.ShowError(errorText);
            }
        }

        /// <summary>清除所有数据</summary>
        /// <param name="isShowDialog">true：弹窗；false：不弹窗</param>
        public void ClearData(bool isShowDialog = true)
        {
            if (isShowDialog)
            {
                if (!ShowAskDialog("确认删除所有数据吗？"))
                {
                    return;
                }
            }

            dgvRtData.Rows.Clear();
            dgvRtData.Refresh();
        }
        #endregion
    }
}
