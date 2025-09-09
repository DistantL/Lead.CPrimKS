/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: LogsHistoryQuery.cs
 * Author: Victor
 * Description: 日志历史查询
 * CreateTime: 2023-1-9
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230109>
 * 1、List<LogClass>绑定至DataGridView优化，方案三效率最高(相比1/2提升20倍)
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/// <summary>日志历史查询</summary>
namespace Lead.CPrim.Controls
{
    public partial class LogsQuery : UIUserControl
    {
        #region Field
        /// <summary>DataGridView绑定</summary>
        List<BindLogsQuery> _bindLogsQuerys = new List<BindLogsQuery>();
        #endregion



        #region Prop
        [Category("CPrim")]
        [Browsable(true)]
        [Description("Logs集合名称")]
        public string LogsCollection { get; set; } = "CPrimLog";

        /// <summary>日志历史查询对象</summary>
        private static LogsQuery _instance = new LogsQuery();
        #endregion



        #region Prop
        /// <summary>日志历史查询对象</summary>
        public static LogsQuery Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        private LogsQuery()
        {
            InitializeComponent();

            dgvLogHistory.SetStyle(false, false, false, DataGridViewAutoSizeColumnsMode.None, DataGridViewContentAlignment.MiddleLeft, 9.0f);
            timeStamp.DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "yyyyMMdd HH:mm:ss fff",
            };
            tlpTitle.SetDoubleBuffered();
            tlpMain.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void LogsHistoryQuery_Load(object sender, EventArgs e)
        {
            cmbLevel.Items.Clear();
            string[] level = Enum.GetNames(typeof(LogLevel));
            foreach (var item in level)
            {
                cmbLevel.Items.Add(item);
            }
            cmbLevel.Items.Add("");
            cmbLevel.SelectedIndex = -1;


            cmbClassfication.Items.Clear();
            string[] classfication = Enum.GetNames(typeof(LogClassification));
            foreach (var item in classfication)
            {
                cmbClassfication.Items.Add(item);
            }
            cmbClassfication.Items.Add("");
            cmbClassfication.SelectedIndex = -1;

            DateTime now = DateTime.Now;
            dtPickerStart.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            dtPickEnd.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).AddDays(1);

            dgvLogHistory.DataSource = _bindLogsQuerys;
        }
        #endregion



        #region Button_Event
        /// <summary>查询</summary>
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                _bindLogsQuerys = new List<BindLogsQuery>();
                List<LogClass> listLogs = default(List<LogClass>);
                int ret = -1;
                string beginTime = dtPickerStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = dtPickEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
                ret = MongodbHelper.QueryLogsByTime<LogClass>(beginTime, endTime, out listLogs, LogsCollection);
                if (ret != 0)
                {
                    throw new Exception($"QueryLogsByTime返回值 = {ret}");
                }
                LogsToDgv(listLogs);
                sw.Stop();
                LogAdd($"查询成功，耗时{sw.ElapsedMilliseconds}ms，查询数据合计{dgvLogHistory.Rows.Count}条", LogLevel.Info);
            }
            catch (Exception ex)
            {
                Cursor = DefaultCursor;
                LogAdd($"查询失败：{ex.Message}", LogLevel.Warn);
            }
            finally
            {
                Cursor = DefaultCursor;
            }
        }

        /// <summary>右键复制</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dgvLogHistory.CurrentCell.Value?.ToString());
        }

        /// <summary>右键导出</summary>
        private void tsmiExport_Click(object sender, EventArgs e)
        {
            string errorTxet = "";
            if (!ControlHelper.SaveDgvDataToCsvFile(dgvLogHistory, true, ref errorTxet, 1))
            {
                Notification.ShowError(errorTxet);
            }
        }

        /// <summary>右键清除</summary>
        private void tsmiClear_Click(object sender, EventArgs e)
        {
            dgvLogHistory.DataSource = null;
            dgvLogHistory.Refresh();
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>Dgv → DataTable</summary>
        /// <param name="dgv">Dgv</param>
        /// <returns>DataTable</returns>
        private DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count2 = 0; count2 < dgv.Columns.Count; count2++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count2].Name.ToString());
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>数据显示</summary>
        /// <param name="listLogs"></param>
        private void LogsToDgv(List<LogClass> listLogs)
        {
            List<LogClass> bindTemp = new List<LogClass>();

            bool idFlag = !tbId.Text.IsNullOrEmpty();
            bool levelFlag = !string.IsNullOrEmpty(cmbLevel.SelectedItem?.ToString());
            bool classificationFlag = !string.IsNullOrEmpty(cmbClassfication.SelectedItem?.ToString());
            bool locationFlag = !tbLocation.Text.IsNullOrEmpty();
            bool messageFlag = !tbMessage.Text.IsNullOrEmpty();
            foreach (LogClass log in listLogs)
            {
                if ((!idFlag || log.Properties.LogId == long.Parse(tbId.Text)) &&
                    (!levelFlag || log.Level.ToLower() == cmbLevel.SelectedItem.ToString().ToLower()) &&
                    (!classificationFlag || log.Properties.Classification == cmbClassfication.SelectedItem.ToString()) &&
                    (!locationFlag || log.Properties.Location.ToLower().Contains(tbLocation.Text.ToLower())) &&
                    (!messageFlag || log.Properties.Message.ToLower().Contains(tbMessage.Text.ToLower())))
                {
                    //方案一
                    //int row = dgLogHistory.Rows.Add();
                    //dgLogHistory.Rows[row].Cells[0].Value = log.TimeStamp.ToString("yyyy/MM/dd HH:mm:ss.fff");
                    //dgLogHistory.Rows[row].Cells[1].Value = log.Level;
                    //dgLogHistory.Rows[row].Cells[2].Value = log.Properties.Message;
                    //dgLogHistory.Rows[row].Cells[3].Value = log.Properties.Location;
                    //dgLogHistory.Rows[row].Cells[4].Value = log.Properties.Classification;
                    //dgLogHistory.Rows[row].Cells[5].Value = log.Properties.LogId;

                    //方案二
                    //dgLogHistory.AddRow(new object[6] { log.TimeStamp.ToString() , log.Level , log.Properties.Message, log.Properties.Location, log.Properties.Classification, log.Properties.LogId});

                    //方案三
                    bindTemp.Add(log);
                }
            }
            _bindLogsQuerys = bindTemp.Select(s => new BindLogsQuery
            {
                TimeStamp = s.TimeStamp,
                Level = s.Level,
                Message = s.Properties.Message,
                Location = s.Properties.Location,
                Classification = s.Properties.Classification,
            }).ToList();
            dgvLogHistory.DataSource = _bindLogsQuerys;
        }

        /// <summary>日志增加</summary>
        /// <param name="msg">消息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示报警弹窗；false：不显示报警弹窗</param>
        private void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            string tempId = $"{(int)lv}{(int)PrimLogId.LogsHistoryQuery}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, msg, PrimLogId.LogsHistoryQuery.ToString(), LogClassification.Other, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
        #endregion


        public void OnLanguageChanged()
        {
            lb_StartTime.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_StartTime", "起始时间:");
            lb_EndTime.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_EndTime", "终止时间:");
            lb_Level.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_Level", "等级")+":";
            lb_Message.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_Message", "包含信息:");
            lb_Classfication.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_Classfication", "分类") + ":";
            lb_Location.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_Location", "来源") + ":";
            btnQuery.Text = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_Query", "查询");

            timeStamp.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_TimeStamp", "时间");
            level.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_Level", "等级");
            message.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_MessageInfo", "信息");
            classification.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_Classfication", "分类");
            location.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_LogsQuery_Location", "来源");
        }
    }

    
    public class BindLogsQuery
    {
        public DateTime TimeStamp { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }

        public string Location { get; set; }

        public string Classification { get; set; }

        public long LogId { get; set; }
    }
}
