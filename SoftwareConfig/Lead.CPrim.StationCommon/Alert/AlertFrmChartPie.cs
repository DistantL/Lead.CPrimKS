using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.StationCommon.Alert
{
    public partial class AlertFrmChartPie : UserControl
    {
        #region Field
        /// <summary>Top10颜色</summary>
        private string[] _colorTop10 = new string[] { "#6F7980", "#5497C1", "#53AC7A", "#F8C35C", "#F3965B", "#E45E69", "#7D72BB", "#4CAAE9", "#66D938", "#C24886" };

        /// <summary>时间统计</summary>
        private Dictionary<string, double> _dic = new Dictionary<string, double>();

        /// <summary>数据表绑定项</summary>
        BindingList<DowntimeData> _downtimeDatas = new BindingList<DowntimeData>();
        #endregion



        #region Ctor
        public AlertFrmChartPie()
        {
            InitializeComponent();
            dgvTop10.SetStyle(false, false, false, DataGridViewAutoSizeColumnsMode.None, DataGridViewContentAlignment.MiddleCenter, 10.0f, FontStyle.Regular, Color.FromArgb(211, 211, 211));
            tlpPie.BackColor = Color.FromArgb(211, 211, 211);

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Event_System
        private void FrmPieChart_Load(object sender, EventArgs e)
        {
            dgvTop10.DataSource = _downtimeDatas;
            dgvTop10.ReadOnly = true;
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTop10.Columns[e.ColumnIndex].DataPropertyName == "ColorName")
            {
                e.CellStyle.BackColor = ColorTranslator.FromHtml(e.Value.ToString());
                e.CellStyle.SelectionBackColor = ColorTranslator.FromHtml(e.Value.ToString());
                e.Value = "";
            }
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            if (dgvTop10.Columns[e.ColumnIndex].DataPropertyName == "Error")
            {
                e.Value = NLocalizer.GetString("Lead_CPrim_ShowAudio_Controls_ShowOutputControl_" + e.Value, e.Value.ToString());
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>图表刷新数据（建议数据一次性进行更新）</summary>
        /// <param name="datas"></param>
        internal void ChartControl(List<DowntimeData> datas)
        {
            if (datas.Count.Equals(0)) 
            {
                return;
            }

            //数据进行处理
            int index = 0;
            foreach (var item in datas.OrderByDescending(time => time.TotalTime))
            {
                item.ColorName = _colorTop10[index++];
                item.TotalTime = double.Parse(item.TotalTime.ToString("f2"));
                _downtimeDatas.Add(item);

                if(index >= 10)
                {
                    break;
                }
            }

            //表格初始化
            List<ChartDatas> _lDatas = new List<ChartDatas>();
            foreach (var item in _downtimeDatas)
            {
                _lDatas.Add(new ChartDatas { Name = item.Error, ChartColor = ColorTranslator.FromHtml(item.ColorName), ChartType = SeriesChartType.Pie });
            }

            //增加数据
            CustomChart.InitChart(ref chart1, _lDatas, null, null, false);
            int i = 0;
            foreach (var item in _downtimeDatas)
            {
                chart1.Series[0].Points.AddXY(item.Error, item.TotalTime);
                chart1.Series[0].Points[i++].Color = ColorTranslator.FromHtml(item.ColorName);
            }

            chart1.Series[0].LabelForeColor = Color.White;
            chart1.Series[0].Font = new Font(chart1.Series[0].Font,FontStyle.Bold);
        }

        internal void ChartClear() 
        {
            _downtimeDatas.Clear();
            CustomChart.InitChart(ref chart1, new List<ChartDatas>(), null, null, false);
        }
        #endregion

        public void OnLanguageChanged()
        {
            lb_Title.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrmChartPie_Title", "报警统计 (前10)");
            error.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrmChartPie_ErrorType", "报警类型");
            totalTime.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrmChartPie_TotalTime", "总时间");
            countTotal.HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_Alert_AlertFrmChartPie_TotalCount", "总次数");
        }
    }
}
