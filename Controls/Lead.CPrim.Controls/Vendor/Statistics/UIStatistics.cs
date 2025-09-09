using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Authority.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.Win32;
using Sunny.UI.Win32;
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
    public partial class UIStatistics : UserControl
    {
        #region Field
        /// <summary>
        /// Dgv数据源
        /// </summary>
        private BindingList<Statistics> _bindingDgv = new BindingList<Statistics>();

        /// <summary>
        /// 更新锁
        /// </summary>
        private object locker = new object();

        /// <summary>
        /// 统计数据库名称
        /// </summary>
        const string _statisticsDbName = "Statistics";

        /// <summary>
        /// 只读单元格
        /// </summary>
        List<string> _namesReadOnly = new List<string>();

        /// <summary>
        /// 默认
        /// </summary>
        DataGridViewCellStyle _styleDefault = new DataGridViewCellStyle()
        {
            BackColor = Color.FromArgb(232, 232, 232),
        };

        /// <summary>
        /// 黄色背景
        /// </summary>
        DataGridViewCellStyle _styleYellow = new DataGridViewCellStyle()
        {
            BackColor = Color.Orange,
        };
        /// <summary>
        /// 红色背景
        /// </summary>
        DataGridViewCellStyle _styleRed = new DataGridViewCellStyle()
        {
            BackColor = Color.Red,
        };
        #endregion



        #region Ctor
        public UIStatistics()
        {
            InitializeComponent();

            MongodbHelper.QueryAll(out List<Statistics> resultlist, _statisticsDbName);
            if (resultlist != null)
            {
                foreach (var item in resultlist)
                {
                    _bindingDgv.Add(item);
                }
                _bindingDgv = new BindingList<Statistics>(_bindingDgv.OrderBy(p => p.ID).ToList());
                dgvStatistics.AutoGenerateColumns = false;
                dgvStatistics.DataSource = _bindingDgv;
                dgvStatistics.Refresh();
            }

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
        }
        #endregion



        #region EventSystem
        private void dgv_Statistics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DialogForOperateLoginForm.Instance.EnqueueDialog("是否确认清零", ok =>
                {
                    if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                    {
                        string firstName = dgvStatistics.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                        string secondName = dgvStatistics.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                        string usedCount = dgvStatistics.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                        var list = _bindingDgv.Where(x => x.WorkName == firstName && x.ValueName == secondName);
                        if (list != null && list.Count() > 0)
                        {
                            Statistics result = list.First();
                            result.UsedCount = 0;
                            result.LastClearTime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";

                            // 更新数据库
                            MongodbHelper.ReplaceOne("ID", result.ID, result, _statisticsDbName);

                            // 记录
                            string msg = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},卡号{AuthorityManager.Instance.CurrentOperatorID}将{result.ID}清零，已使用{usedCount}";
                            ControlsHelper.LogAdd(msg, LogLevel.Info);
                            LogToTxt(msg);
                        }

                        dgvStatistics.Refresh();
                    }
                });
            }
        }

        private void dgvStatistics_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                e.Cancel = true;
                return;
            }

            var name1 = dgvStatistics.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
            var name2 = dgvStatistics.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
            string name = $"{name1}.{name2}";
            if (_namesReadOnly.Contains(name))
            {
                e.Cancel = true;
                return;
            }

            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                var list = _bindingDgv.Where(x => x.WorkName == name1 && x.ValueName == name2);
                if (list == null || list.Count() <= 0)
                {
                    e.Cancel = true;
                    return;
                }

                Statistics result = list.First();
                DialogForOperateLoginForm.Instance.EnqueueDialog("记录卡号", ok =>
                {
                    if (!ok || string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                    {
                        e.Cancel = true;
                    }
                });
            }
        }

        private void dgv_Statistics_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                string firstName = dgvStatistics.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                string secondName = dgvStatistics.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                var list = _bindingDgv.Where(x => x.WorkName == firstName && x.ValueName == secondName);
                if (list == null || list.Count() <= 0)
                {
                    return;
                }

                Statistics result = list.First();
                result.LastClearTime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                string name = e.ColumnIndex == 3 ? "警告阈值" : "报警阈值";
                int value = e.ColumnIndex == 3 ? result.WarnCount : result.LimitCount;
                string msg = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},卡号{AuthorityManager.Instance.CurrentOperatorID}变更{firstName}.{secondName}的{name} = {value}";
                ControlsHelper.LogAdd(msg, LogLevel.Info);
                LogToTxt(msg);
                MongodbHelper.ReplaceOne("ID", result.ID, result, _statisticsDbName);
            }
        }

        private void dgvStatistics_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvStatistics.Rows)
            {
                if (!int.TryParse(row.Cells[2].Value?.ToString() ?? "", out int userNUm))
                {
                    return;
                }
                if (!int.TryParse(row.Cells[3].Value?.ToString() ?? "", out int warnNum))
                {
                    return;
                }
                if (!int.TryParse(row.Cells[4].Value?.ToString() ?? "", out int errorNum))
                {
                    return;
                }

                int columns = dgvStatistics.Columns.Count;
                if (userNUm >= errorNum)
                {
                    SetDataGridViewRowStyle(row, columns, _styleRed);
                }
                else if (userNUm >= warnNum)
                {
                    SetDataGridViewRowStyle(row, columns, _styleYellow);
                }
                else
                {
                    SetDataGridViewRowStyle(row, columns, _styleDefault);
                }
            }
        }
        #endregion



        #region MethodInstance
        private void InstanceUpdateLevel(OpLevel level)
        {
            //SetEnable(AuthorityManager.Instance.VerifyLevel3Permission());
        }
        #endregion



        #region MethodExternalUsing
        public int GetValue(string workName, string valueName)
        {
            Statistics temp;

            lock (locker)
            {
                var _list = _bindingDgv.Where(x => x.WorkName == workName && x.ValueName == valueName);
                if (_list != null && _list.Count() > 0)
                {
                    temp = _list.First();
                    return temp.UsedCount;
                }
                return -1;
            }
        }

        /// <summary>
        /// 统计增加次数设置
        /// 0：成功<br/>
        /// -1：超出报警次数<br/>
        /// -2：超出警告次数<br/>
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int SetValue(string firstName, string secondName, int num, int warnCount, int errorCount)
        {
            int result = 0;
            Statistics statistics;

            lock (locker)
            {
                var lists = _bindingDgv.Where(x => x.WorkName == firstName && x.ValueName == secondName);
                if (lists != null && lists.Count() > 0)
                {
                    statistics = lists.First();
                    if (warnCount > 0)
                    {
                        statistics.WarnCount = warnCount;
                    }
                    if (errorCount > 0)
                    {
                        statistics.LimitCount = errorCount;
                    }
                    statistics.UsedCount += num;
                }
                else
                {
                    statistics = new Statistics()
                    {
                        ID = firstName + "_" + secondName,
                        WorkName = firstName,
                        ValueName = secondName,
                        UsedCount = num
                    };
                    if (warnCount > 0)
                    {
                        statistics.WarnCount = warnCount;
                    }
                    if (errorCount > 0)
                    {
                        statistics.LimitCount = errorCount;
                    }

                    _bindingDgv.Add(statistics);
                }

                //更新数据库
                MongodbHelper.ReplaceOne("ID", statistics.ID, statistics, _statisticsDbName);
            }

            if (statistics.UsedCount > statistics.LimitCount)
            {
                result = -1;
            }
            else if (statistics.UsedCount > statistics.WarnCount)
            {
                result = -2;
            }

            if (result == -1)
            {
                string msg = $"{statistics.WorkName}.{statistics.ValueName}，超过限制次数 = {statistics.LimitCount}";
                ControlsHelper.LogAdd(msg, LogLevel.Warn);
                DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
                {
                    if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                    {
                        int usedCount = statistics.UsedCount;
                        lock (locker)
                        {
                            var lists = _bindingDgv.Where(x => x.WorkName == firstName && x.ValueName == secondName);
                            if (lists != null && lists.Count() > 0)
                            {
                                statistics = lists.First();
                                statistics.UsedCount = 0;
                            }

                            MongodbHelper.ReplaceOne("ID", statistics.ID, statistics, _statisticsDbName);
                        }

                        msg = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},卡号{AuthorityManager.Instance.CurrentOperatorID}将{statistics.ID}清零，已使用{usedCount}";
                        ControlsHelper.LogAdd(msg, LogLevel.Info);
                        LogToTxt(msg);
                    }
                }, true);
            }
            else if (result == -2)
            {
                string msg = $"{statistics.WorkName}.{statistics.ValueName}，超过警告次数 = {statistics.WarnCount}";
                ControlsHelper.LogAdd(msg, LogLevel.Warn);
            }

            Invoke((Action)delegate
            {
                dgvStatistics.Refresh();
            });

            if (num <= 0 && (warnCount > 0 || errorCount > 0))
            {
                Invoke((Action)delegate
                {
                    string msg = $"{statistics.WorkName}.{statistics.ValueName}，通过任务设置次数";
                    LogToTxt(msg);
                    foreach (DataGridViewRow row in dgvStatistics.Rows)
                    {
                        var name1 = row.Cells[0].Value?.ToString() ?? "";
                        var name2 = row.Cells[1].Value?.ToString() ?? "";
                        if (firstName == name1 && secondName == name2)
                        {
                            string name = $"{name1}.{name2}";
                            if (!_namesReadOnly.Contains(name))
                            {
                                _namesReadOnly.Add(name);
                            }
                            break;
                        }
                    }

                    dgvStatistics.Invalidate();
                });
            }

            return result;
        }
        #endregion



        #region Method_InternalUsing
        private void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(SetEnable), enable);
            }
            else
            {
                colErrorNum.ReadOnly = !enable;
            }
        }

        /// <summary>
        /// 设置DataGridView行样式
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columns"></param>
        /// <param name="style"></param>
        void SetDataGridViewRowStyle(DataGridViewRow row, int columns, DataGridViewCellStyle style)
        {
            for (int i = 0; i < columns; i++)
            {
                row.Cells[i].Style = style;
            }
        }

        void OnLanguageChanged()
        {
            foreach (DataGridViewRow row in dgvStatistics.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                        cell.ToolTipText = NLocalizer.GetString("Lead_CPrim_Controls_UIStatistics_" + cell, cell.Value.ToString());
                }
            }

            colFirstName.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIStatistics_WorkName", "位置");
            colSecondName.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIStatistics_ItemName", "名称");
            colUsedNum.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIStatistics_UsedCount", "使用次数");
            colErrorNum.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIStatistics_LimitCount", "限制次数");
            colClearStatistics.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIStatistics_ClearStatistics", "清零");
            colLastClearTime.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIStatistics_LastClearTime", "最后一次修改时间");

            dgvStatistics.Invalidate();
        }

        void LogToTxt(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                return;
            }

            FileInfo fileInfo = new FileInfo(@"D:\CPrimlog\统计\" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            using (StreamWriter sw = new StreamWriter(fileInfo.FullName, true, Encoding.Default))
            {
                sw.WriteLine(msg);
            }
        }
        #endregion
    }
}
