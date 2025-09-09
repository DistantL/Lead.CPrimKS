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
        /// <summary>
        /// setting界面中显示报警的列表
        /// </summary>
        private BindingList<AlarmInfo> _list = new BindingList<AlarmInfo>();



        public AlarmInfoEx(ref BindingList<AlarmInfo> list)
        {
            _list = list;
            InitializeComponent();
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            ErrorLevel.DataSource = new List<string> { "一级报警", "二级报警", "三级报警" };

            PromptMethod.DataSource = new List<string> { "不停机界面提示", "停机黄灯", "DT红灯" };
            ErrorLevel.DataSource = new ErrorLevel[] { ProxyTools.ErrorLevel.一级报警, ProxyTools.ErrorLevel.二级报警, ProxyTools.ErrorLevel.三级报警 };
            ErrorLevel.ValueType = typeof(ErrorLevel);

            try
            {
                dgv_AlertInfo.AutoGenerateColumns = false;
                dgv_AlertInfo.DataSource = _list;
            }
            catch (Exception ex)
            {
                LogHelper.Warn(nameof(AlarmInfoEx), ex);
            }

            dgv_AlertInfo.DoubleBuffered(true);
        }

        private void OnLanguageChanged()
        {
            dgv_AlertInfo.Columns["ErrorCode"].HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlarmInfo_ErrorCode", "报警代码");
            dgv_AlertInfo.Columns["ErrorMessage"].HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlarmInfo_ErrorMessage", "报警类型");
            dgv_AlertInfo.Columns["ErrorDetail"].HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlarmInfo_ErrorDetail", "报警信息");
        }

        public int Save()
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
                    sw.Write(row.Cells["ErrorCode"].Value); sw.Write(',');

                    switch (row.Cells["ErrorLevel"].Value.ToString())
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
                    sw.Write(row.Cells["ErrorMessage"].Value); sw.Write(',');
                    sw.Write(row.Cells["ErrorDetail"].Value); sw.Write(',');
                    sw.Write(row.Cells["ErrorDetailInEN"].Value); sw.Write(',');
                    sw.Write(row.Cells["ErrorDetailInVN"].Value); sw.Write(',');
                    sw.Write(row.Cells["AlarmCount"].Value); sw.Write(',');
                    sw.Write(row.Cells["dgvCumulativeThreshold"].Value); sw.Write(',');
                    sw.Write(row.Cells["ErrorLevel"].Value); sw.Write(',');
                    sw.Write(row.Cells["PromptMethod"].Value); sw.Write(',');
                    sw.Write(row.Cells["dgvSolution"].Value); sw.Write(',');
                    sw.Write(row.Cells["dgvSolutionInEN"].Value); sw.Write(',');
                    sw.Write(row.Cells["dgvSolutionInVN"].Value); sw.Write(',');
                    sw.Write(row.Cells["HasParams"].Value); sw.Write(',');
                    sw.Write(row.Cells["Sequence"].Value); sw.Write(',');
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warn($"{nameof(AlarmInfoEx)}.{nameof(Save)}", ex);
            }

            return 0;
        }
    }
}
