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
        /// 报警列表
        /// </summary>
        private BindingList<AlarmInfo> _alarmsBinding = new BindingList<AlarmInfo>();

        /// <summary>
        /// 报警列表锁
        /// </summary>
        static readonly object _lockAlarm = new object();
        #endregion



        #region Ctor
        public AlarmInfoEx(ref BindingList<AlarmInfo> list)
        {
            InitializeComponent();
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            _alarmsBinding = list;
            colPromptMethod.DataSource = new List<string> { "不停机界面提示", "停机黄灯", "DT红灯" };
            colErrorLevel.DataSource = new ErrorLevel[] { ProxyTools.ErrorLevel.一级报警, ProxyTools.ErrorLevel.二级报警, ProxyTools.ErrorLevel.三级报警 };
            colErrorLevel.ValueType = typeof(ErrorLevel);

            try
            {
                dgv_AlertInfo.AutoGenerateColumns = false;
                dgv_AlertInfo.DataSource = _alarmsBinding;
            }
            catch (Exception ex)
            {
                LogHelper.Warn(nameof(AlarmInfoEx), ex);
            }

            dgv_AlertInfo.DoubleBuffered(true);
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
                
            };
        }
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        internal int Save()
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
        #endregion
    }
}
