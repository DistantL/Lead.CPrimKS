using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority
{
    public partial class AlarmInfoEx : UserControl
    {
        #region Field
        /// <summary>
        /// 报警列表锁
        /// </summary>
        static readonly object _lockAlarm = new object();

        /// <summary>
        /// 报警列表
        /// </summary>
        private BindingList<AlarmInfo> _alarmsBinding = new BindingList<AlarmInfo>();
        #endregion



        #region Ctor
        public AlarmInfoEx(ref BindingList<AlarmInfo> list)
        {
            InitializeComponent();
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            _alarmsBinding = list;
            colErrorLevel.DataSource = new ErrorLevel[] { ErrorLevel.一级报警, ErrorLevel.二级报警, ErrorLevel.三级报警 };
            colErrorLevel.ValueType = typeof(ErrorLevel);

            try
            {
                dgv_AlertInfo.RowHeadersVisible = true;
                dgv_AlertInfo.RowHeadersWidth = 60;
                dgv_AlertInfo.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("微软雅黑", 9.0f, FontStyle.Italic),
                };
                dgv_AlertInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_AlertInfo.AutoGenerateColumns = false;
                dgv_AlertInfo.SetDoubleBuffered();
                RefreshDatas();
                dgv_AlertInfo.DataSource = _alarmsBinding;
            }
            catch (Exception ex)
            {
                LogHelper.Warn(nameof(AlarmInfoEx), ex);
            }
        }
        #endregion



        #region EventSystem
        /// <summary>
        /// 当单元格收到输入焦点，从而成为 DataGridView 中的当前单元格时发生<br/>
        /// 解决DataGridViewComboBoxColumn首次必须点击2次才可弹出<br/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }

            if (e.RowIndex != -1 && dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                SendKeys.Send("{F4}");
            }
        }
        /// <summary>
        /// 单元格状态因其内容更改而更改时发生<br/>
        /// 解决DataGridViewCheckBoxColumn必须按Enter键才生效<br/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }

            if (dgv.IsCurrentCellDirty)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        /// <summary>
        /// 外部数据分析或验证操作引发异常时，或将数据提交到数据源的尝试失败时发生。<br/>
        /// 解决报错时一直抛异常，目前是忽略异常<br/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        /// <summary>
        /// 行首计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = $"{e.Row.Index + 1}";
        }
        #endregion



        #region EventButton

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            lock (_lockAlarm)
            {
                _alarmsBinding.Add(new AlarmInfo());
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            lock (_lockAlarm)
            {
                var selectRows = dgv_AlertInfo.SelectedRows;
                if (selectRows.Count <= 0)
                {
                    return;
                }

                for (int i = selectRows.Count - 1; i >= 0; i--)
                {
                    var row = selectRows[i];
                    _alarmsBinding.RemoveAt(row.Index);
                }
            }
        }
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        internal int Save()
        {
            try
            {
                if (_alarmsBinding.IsNullOrEmpty())
                {
                    return 0;
                }

                RefreshDatas();
                return CsvHelper.WriteToCsv(AlarmManager.Instance.ConfigFilePath, _alarmsBinding, true, true, true) ? 0 : -1;
            }
            catch (Exception ex)
            {
                LogHelper.Warn($"{nameof(AlarmInfoEx)}.{nameof(Save)}", ex);
                return -1;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        internal int SaveBackup()
        {
            FileInfo fileInfo = new FileInfo(AlarmManager.Instance.ConfigFilePath);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            try
            {
                using StreamWriter sw = new StreamWriter(fileInfo.FullName, false, Encoding.UTF8);
                sw.WriteLine("ErrorCode,ErrorLevelInEN,ErrorMessage,ErrorDetail,ErrorDetailInEN,ErrorDetailInVN,AlarmCount,AlarmThreshold,ErrorLevel,PromptMethod,AlarmHandlingDetails,AlarmHandlingDetailsInEN,AlarmHandlingDetailsInVN,HasParams,Sequence");

                foreach (DataGridViewRow row in dgv_AlertInfo.Rows)
                {
                    sw.Write(row.Cells["colErrorCode"].Value); sw.Write(',');

                    switch (row.Cells["colErrorLevel"].Value.ToString())
                    {
                        case "一级报警":
                            sw.Write("critical"); sw.Write(',');
                            break;
                        case "二级报警":
                            sw.Write("error"); sw.Write(',');
                            break;
                        case "三级报警":
                            sw.Write("warning"); sw.Write(',');
                            break;
                        default:
                            sw.Write(""); sw.Write(',');
                            break;
                    }
                    sw.Write(row.Cells["colErrorMessage"].Value); sw.Write(',');
                    sw.Write(row.Cells["colErrorDetail"].Value); sw.Write(',');
                    sw.Write(row.Cells["colErrorDetailInEN"].Value); sw.Write(',');
                    sw.Write(row.Cells["colErrorDetailInVN"].Value); sw.Write(',');
                    sw.Write(row.Cells["colAlarmCount"].Value); sw.Write(',');
                    sw.Write(row.Cells["colCumulativeThreshold"].Value); sw.Write(',');
                    sw.Write(row.Cells["colErrorLevel"].Value); sw.Write(',');
                    sw.Write(row.Cells["colPromptMethod"].Value); sw.Write(',');
                    sw.Write(row.Cells["colSolution"].Value); sw.Write(',');
                    sw.Write(row.Cells["colSolutionInEN"].Value); sw.Write(',');
                    sw.Write(row.Cells["colSolutionInVN"].Value); sw.Write(',');
                    sw.Write(row.Cells["colHasParams"].Value); sw.Write(',');
                    sw.Write(row.Cells["colSequence"].Value); sw.Write(',');
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warn($"{nameof(AlarmInfoEx)}.{nameof(Save)}", ex);
            }

            return 0;
        }
        #endregion



        #region MethodInternalUsing
        void OnLanguageChanged()
        {
            colErrorCode.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlarmInfo_ErrorCode", "报警代码");
            colErrorMessage.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlarmInfo_ErrorMessage", "报警类型");
            colErrorDetail.HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlarmInfo_ErrorDetail", "报警信息");

            tsmiAdd.Text = NLocalizer.Add;
            tsmiDelete.Text = NLocalizer.Delete;
        }

        /// <summary>
        /// 数据防呆
        /// </summary>
        void RefreshDatas()
        {
            if (_alarmsBinding.IsNullOrEmpty())
            {
                return;
            }

            foreach (var data in _alarmsBinding)
            {
                if (data.ErrorLevel == ErrorLevel.一级报警 || data.ErrorLevel == ErrorLevel.二级报警)
                {
                    data.ContinuousThreshold = 1;
                    data.CumulativeThreshold = 1;
                    data.Algorithm = new ContinuousCumulativeStatisticsAlgorithm(data.VendorAlarmCode);
                    data.Algorithm.Init(data.ContinuousThreshold, data.CumulativeThreshold, 60);
                }
            }
        }
        #endregion
    }
}
