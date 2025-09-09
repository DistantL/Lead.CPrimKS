using Lead.CPrim.Interfaces;
using Lead.CPrim.ProductInfoHelper;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public partial class ProductInfos : UIPage
    {
        #region Field
        private BindingList<ProductInfo> _products = new BindingList<ProductInfo>();
        #endregion



        #region Ctor
        public ProductInfos()
        {
            InitializeComponent();

            dgvRtData.ReadOnly = true;
            dgvRtData.DataSource = _products;
            dgvRtData.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Event_System
        private void dgvRtData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRtData.Columns[e.ColumnIndex].Name == "Pass" && e.Value != null)
            {
                if (e.Value.ToString() == "OK")
                {
                    e.CellStyle.BackColor = Color.LawnGreen;
                    e.Value = "True";
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.Value = "False";
                }
            }
        }

        #endregion



        #region Event_Button

        #endregion



        #region Method_ExternalUsing

        public void InsertData(ProductInfo value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<ProductInfo>(InsertData), value);
            }
            else
            {
                try
                {
                    this.SuspendLayout();
                    var rowIndex = dgvRtData.FirstDisplayedScrollingRowIndex;

                    _products.Insert(0, value);

                    foreach (ProductInfo product in _products.OrderBy(p => p.CreateTime))
                    {
                        if ((DateTime.Now - product.CreateTime).TotalHours > 1)
                        {
                            _products.Remove(product);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (dgvRtData.Rows.Count > 0 && rowIndex >= 0 && rowIndex < dgvRtData.Rows.Count)
                    {
                        dgvRtData.FirstDisplayedScrollingRowIndex = rowIndex;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogAdd(LogLevel.Debug, $"ProductInfos.InsertData异常：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
                }
                finally
                {
                    this.ResumeLayout();
                }
            }
        }

        public void InsertData(List<ProductInfo> list)
        {
            dgvRtData.DataSource = _products = new BindingList<ProductInfo>(list);
        }

        public int UPH_Count()
        {
            int count = 0;
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
            foreach (var item in _products)
            {
                if (item.CreateTime.CompareTo(startTime) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>导出数据</summary>
        public void ExportData()
        {
            /*
            string errorText = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(dgvRtData, true, ref errorText))
            {
                Notification.ShowError(errorText);
            }
            */
            if (_products.Count <= 0)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.csv|*.CSV";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false))
                {
                    sw.WriteLine("序号,日期,班次,载具SN,开始时间,结束时间,物料SN,结果,CT/s,抛辅料数量,抛辅料原因,HIVE状态,NG原因");
                    int i = 0;
                    foreach (var item in _products)
                    {
                        i++;
                        sw.Write(i.ToString());
                        sw.Write(',');
                        sw.Write(item.CreateTime.ToString("yyyy-MM-dd"));
                        sw.Write(',');
                        sw.Write(item.Shift);
                        sw.Write(',');
                        sw.Write(item.FixtureID);
                        sw.Write(',');
                        sw.Write(item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        sw.Write(',');
                        sw.Write(item.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        sw.Write(',');
                        sw.Write(item.Sn);
                        sw.Write(',');
                        sw.Write(item.Result);
                        sw.Write(',');
                        sw.Write(item.CT);
                        sw.Write(',');
                        sw.Write(item.TossingCount);
                        sw.Write(',');
                        sw.Write(item.TossingReason);
                        sw.Write(',');
                        sw.Write(item.HIVE_State);
                        sw.Write(',');
                        sw.Write(item.NGReason);
                        sw.WriteLine();
                    }
                }
            }
        }

        public void SetHasAccessary(bool flag)
        {
            if (dgvRtData.Columns.Contains("TossingCount"))
            {
                dgvRtData.Columns["TossingCount"].Visible = flag;
            }
            if (dgvRtData.Columns.Contains("TossingReason"))
            {
                dgvRtData.Columns["TossingReason"].Visible = flag;
            }
        }

        /// <summary>清除所有数据</summary>
        /// <param name="isShowDialog">true：弹窗；false：不弹窗</param>
        public void ClearData(bool isShowDialog = true)
        {
            if (isShowDialog)
            {
                if (!ShowAskDialog(NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_ConfirmToDeleteAll", "确认删除所有数据吗？")))
                {
                    return;
                }
            }

            dgvRtData.Rows.Clear();
            dgvRtData.Refresh();
        }
        #endregion



        #region Method_InternalUsing
        void OnLanguageChanged()
        {
            dgvRtData.Columns["Date"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Date", "日期");
            dgvRtData.Columns["Shift"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Shift", "班次");
            dgvRtData.Columns["FixtureID"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Unit_SN", "载具SN");
            dgvRtData.Columns["Start_Time"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Start_Time", "开始时间");
            dgvRtData.Columns["End_Time"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_End_Time", "结束时间");
            dgvRtData.Columns["Component_SN"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Component_SN", "物料SN");
            dgvRtData.Columns["Pass"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Pass", "结果");
            dgvRtData.Columns["HIVE_State"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_HIVE_State", "HIVE状态");
            dgvRtData.Columns["TossingCount"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_TossingCount", "抛辅料数量");
            dgvRtData.Columns["TossingReason"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_TossingReason", "抛辅料原因");
            dgvRtData.Columns["NGReason"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_ReasonNG", "NG原因");
        }
        #endregion
    }
}
