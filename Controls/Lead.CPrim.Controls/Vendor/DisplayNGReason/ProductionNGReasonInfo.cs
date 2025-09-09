using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProductInfoHelper;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.StationCommon;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    public partial class UIProductionNGReasonInfo : UIUserControl
    {
        private DateTime _lastUpdateTime = DateTime.Now;
        private BindingList<ProductInfo> _list = new BindingList<ProductInfo>();
        private object locker = new object();
        public UIProductionNGReasonInfo()
        {
            InitializeComponent();

            dgvRtData.ReadOnly = true;
            dgvRtData.DataSource = _list;
            _lastUpdateTime = DateTime.Now.AddMinutes(10);

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            dgvRtData.Columns["TossingCount"].Visible = false;
            dgvRtData.Columns["TossingReason"].Visible = false;

            dgvRtData.Columns["NGReason"].Width = 200;
        }

        public void OnLanguageChanged()
        {
            dgvRtData.Columns["Date"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Date", "日期");
            dgvRtData.Columns["Shift"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Shift", "班次");
            dgvRtData.Columns["Unit_SN"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Unit_SN", "载具SN");
            dgvRtData.Columns["Start_Time"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Start_Time", "开始时间");
            dgvRtData.Columns["End_Time"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_End_Time", "结束时间");
            dgvRtData.Columns["Component_SN"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Component_SN", "物料SN");
            dgvRtData.Columns["Pass"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_Pass", "结果");
            dgvRtData.Columns["HIVE_State"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_HIVE_State", "HIVE状态");
            dgvRtData.Columns["TossingCount"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_TossingCount", "抛辅料数量");
            dgvRtData.Columns["TossingReason"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_TossingReason", "抛辅料原因");
            dgvRtData.Columns["NGReason"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_ReasonNG", "NG原因");
            dgvRtData.Columns["SlotIndex"].HeaderText = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfos_SlotIndex", "工位");
        }

        private void dgvRtData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRtData.Columns[e.ColumnIndex].Name == "Pass" && e.Value != null)
            {
                if (e.Value.ToString() == "True")
                {
                    e.CellStyle.BackColor = Color.LawnGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }

        private async void bt_Update_Click(object sender, EventArgs e)
        {
            bt_Update.Enabled = false;
            try
            {
                DateTime time = DateTime.Now;
                DateTime startTime = DateTime.Now;
                if (time.Hour >= 8 && time.Hour < 20)
                {
                    startTime = new DateTime(time.Year, time.Month, time.Day, 8, 0, 0);
                }
                else if (time.Hour < 8)
                {
                    startTime = new DateTime(time.Year, time.Month, time.Day, 20, 0, 0).AddDays(-1);
                }
                else
                {
                    startTime = new DateTime(time.Year, time.Month, time.Day, 20, 0, 0);
                }

                var list = await GetDataFromDb(startTime, time);
                if (list != null)
                {
                    _list = new BindingList<ProductInfo>(list);
                    dgvRtData.DataSource = _list;
                    _lastUpdateTime = DateTime.Now.AddMinutes(10);
                    timer_Update.ReStart();
                }
            }
            catch (Exception)
            {
            }
            finally 
            { 
                bt_Update.Enabled = true; 
            }
        }

        private void timer_UpdateTime_Tick(object sender, EventArgs e)
        {
            lb_NextUpdateTime.Text = string.Format("距离下次刷新时间[{0}]还有[{1}]s", _lastUpdateTime.ToString("yyyy-MM-dd HH:mm:ss"), (_lastUpdateTime - DateTime.Now).TotalSeconds.ToString("F0"));
        }

        private void timer_Update_Tick(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => { bt_Update_Click(null, null); }));
        }


        private Task<List<ProductInfo>> GetDataFromDb(DateTime startTime, DateTime endTime)
        {
            return Task<List<ProductInfo>>.Factory.StartNew(() =>
            {
                //查询数据库
                string product = string.IsNullOrWhiteSpace(SwManager.Instance.CurrentProduct) ? @"parts" : SwManager.Instance.CurrentProduct;

                List<ProductInfo> productInfos;
                string db = $"{StationManager.Instance.CurrentStationName}_{product}";

                MongodbHelper.QueryManyByTime(new string[] { "Result" }, new string[] { "NG" }, startTime, endTime, out productInfos, db);
                return productInfos;
            });
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dgvRtData.CurrentCell.Value?.ToString());
        }

        private void 导出所有SNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.csv|*.csv";
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                try
                {
                    int index = dgvRtData.Columns["Component_SN"].Index;
                    if (index >= 0 && index < dgvRtData.Columns.Count)
                    {
                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                        {
                            if (dgvRtData != null || dgvRtData.Rows != null)
                            {
                                foreach (DataGridViewRow row in dgvRtData.Rows)
                                {
                                    if (!string.IsNullOrWhiteSpace(row.Cells[index].Value.ToString()))
                                    {
                                        sw.WriteLine(row.Cells[index].Value.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
