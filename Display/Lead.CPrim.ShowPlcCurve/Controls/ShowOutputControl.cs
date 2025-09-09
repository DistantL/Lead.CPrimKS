/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowOutputControl.cs
 * Author: Victor
 * Description: ouput界面，用来显示曲线
 * CreateTime: 2022-09-13
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0904><Victor><20220913>
 * 1、初版1.0
 * <3.3.22.1125><Victor><20221206>
 * 1、plc曲线命名方式变更为：SN+当前时间.Bmp
 * 
 * <3.2.23.0315><Victor><20230331>
 * 1、见优化01（保存时指定图片的大小）
 * 
 * <3.2.23.0401><Victor><20230331>
 * 1、见优化02（将UI上的chart直接放到代码内实例化）
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.ShowPlcCurve.Controls
{
    public partial class ShowOutputControl : UIUserControl
    {
        #region Field
        /// <summary>
        /// 压力曲线配置管理器
        /// </summary>
        public Show _show;

        /// <summary>
        /// 曲线集合（用于显示）
        /// </summary>
        private Chart[] chartsShow;

        /// <summary>
        /// 曲线集合（用于保存）
        /// </summary>
        private Chart[] chartsSave; //优化02
        #endregion



        #region Ctor
        public ShowOutputControl(Show show)
        {
            InitializeComponent();
            SetStyleFlags();

            this.BackColor = Colors.PrimaryBackColor211;
            tlpMain.BackColor = Colors.PrimaryBackColor211;
            tlpMain.SetDoubleBuffered();

            _show = show;
            chartsShow = new Chart[6] { new Chart(), new Chart(), new Chart(), new Chart(), new Chart(), new Chart() };
            chartsSave = new Chart[6] { new Chart(), new Chart(), new Chart(), new Chart(), new Chart(), new Chart() };
            for (int i = 0; i < chartsShow.Length; i++)
            {
                chartsShow[i].BackColor = Colors.PrimaryBackColor211;
            }
            ShowChartNum(_show.ChartNum);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>显示曲线数量</summary>
        /// <param name="num"></param>
        public void ShowChartNum(int num)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(ShowChartNum), num);
                return;
            }
            if (num < 1 || num > 6)
            {
                num = 6;
            }
            tlpMain.Controls.Clear();
            tlpMain.ColumnStyles.Clear();
            tlpMain.RowStyles.Clear();
            if (num == 1)
            {
                tlpMain.ColumnCount = 1;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 1;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            }
            else if (num == 2)
            {
                tlpMain.ColumnCount = 1;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            }
            else if (num == 3 || num == 4)
            {
                tlpMain.ColumnCount = 2;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            }
            else if (num == 5 || num == 6)
            {
                tlpMain.ColumnCount = 3;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            }

            for (int i = 0; i < tlpMain.ColumnCount * tlpMain.RowCount; i++)
            {
                chartsShow[i].Dock = DockStyle.Fill;
            }
            for (int i = 0; i < tlpMain.ColumnCount; i++)
            {
                for (int j = 0; j < tlpMain.RowCount; j++)
                {
                    tlpMain.Controls.Add(chartsShow[i + j * tlpMain.ColumnCount], i, j);
                }
            }
        }

        /// <summary>手自动</summary>
        /// <param name="enable">自动：false；手动：true；</param>
        public void EnableHandle(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(EnableHandle), new object[] { enable });
            }
            else
            {
                tlpMain.Enabled = enable;
            }
        }

        public void ChartControl(int id, string sn, Dictionary<double, double> keyValues, int index, string xName = "", string yName = "")
        {
            List<PointF> points = new List<PointF>();
            foreach (var item in keyValues)
            {
                points.Add(new PointF((float)item.Key, (float)item.Value));
            }
            ChartControl(id, sn, points, index, xName, yName);
        }

        public void ChartControl(int id, string sn, List<PointF> points, int index, string xName = "", string yName = "")
        {
            if (chartsShow[id - 1].InvokeRequired)
            {
                chartsShow[id - 1].BeginInvoke(new Action<int, string, List<PointF>, int, string, string>(ChartControl), new object[] { id, sn, points, index, xName, yName });
                return;
            }

            try
            {
                #region 防呆
                if (id < 1 || id > 6)
                {
                    throw new Exception($"validId 1-6，currentId = {id}");
                }
                if (id > _show.ChartNum)
                {
                    id = _show.ChartNum;
                }
                if (!points.IsValid())
                {
                    throw new Exception("data is null");
                }
                if (index != 1 && index != 2)
                {
                    index = 1;
                }
                if (sn.IsNullOrWhiteSpace())
                {
                    sn = DateTime.Now.ToString("HHmmssfff");
                }
                if (chartsShow[id - 1].Series.IsValid())
                {
                    chartsShow[id - 1].Series[0].Points.Clear();
                }
                if (chartsSave[id - 1].Series.IsValid())
                {
                    chartsSave[id - 1].Series[0].Points.Clear();
                }
                #endregion

                #region 初始化图表
                double xMin = _show.XMinEnable ? _show.XMin : points.Min(p => p.X);
                double xMax = _show.XMaxEnable ? _show.XMax : points.Max(p => p.X);
                double yMin = _show.YMinEnable ? _show.YMin : points.Min(p => p.Y);
                double yMax = _show.YMaxEnable ? _show.YMax : points.Max(p => p.Y);

                CustomChart.InitChart(ref chartsShow[id - 1], yMax, yMin, xMax, xMin, DateTimeIntervalType.Number, "0.0", sn, true, xName, yName);
                CustomChart.InitChart(ref chartsSave[id - 1], yMax, yMin, xMax, xMin, DateTimeIntervalType.Number, "0.0", sn, true, xName, yName);

                double intervalX = _show.XInterval < 0.01 ? 0.01 : _show.XInterval;
                //chartsShow[id - 1].ChartAreas[0].AxisX.Interval = xMin;
                //chartsShow[id - 1].ChartAreas[0].AxisX.Interval = xMin;
                #endregion

                #region 填充数据
                foreach (var item in points)
                {
                    if (item.X >= xMin && item.X <= xMax && item.Y >= yMin && item.Y <= yMax)
                    {
                        chartsShow[id - 1].Series[0].Points.AddXY(item.X, item.Y);
                        chartsSave[id - 1].Series[0].Points.AddXY(item.X, item.Y);
                    }
                }
                #endregion

                #region 保存数据
                string name = $"{sn}_{id}_{DateTime.Now:HHmmssfff}.Png";
                SaveChartPic(ref chartsSave[id - 1], index, sn, name);
                if (_show.SourceDataSaveEnable && !_show.SourceDataSave.IsNullOrWhiteSpace())
                {
                    SaveCsv(sn, points, null);
                }
                #endregion
            }
            catch (Exception ex)
            {
                _show.LogAdd("position press cure save error：" + ex.Message, LogLevel.Warn);
            }
        }

        public void ChartControl(int id, string sn, Dictionary<DateTime, double> keyValues, int index, string xName, string yName = "")
        {
            if (chartsShow[id - 1].InvokeRequired)
            {
                chartsShow[id - 1].BeginInvoke(new Action<int, string, Dictionary<DateTime, double>, int, string, string>(ChartControl), new object[] { id, sn, keyValues, index, xName, yName });
                return;
            }

            try
            {
                #region 防呆
                if (id < 1 || id > 6)
                {
                    throw new Exception($"validId 1-6，currentId = {id}");
                }
                if (id > _show.ChartNum)
                {
                    id = _show.ChartNum;
                }
                if (keyValues == null || keyValues.Count <= 1)
                {
                    throw new Exception("data is null");
                }
                if (index != 1 && index != 2)
                {
                    index = 1;
                }
                if (sn.IsNullOrWhiteSpace())
                {
                    sn = DateTime.Now.ToString("HHmmssfff");
                }
                if (chartsShow[id - 1].Series.IsValid())
                {
                    chartsShow[id - 1].Series[0].Points.Clear();
                }
                if (chartsSave[id - 1].Series.IsValid())
                {
                    chartsSave[id - 1].Series[0].Points.Clear();
                }
                #endregion

                #region 初始化图表
                DateTime timeMin = keyValues.Keys.ToList().Min();
                DateTime timeMax = keyValues.Keys.ToList().Max();
                double yMin = _show.YMinEnable ? _show.YMin : keyValues.Values.ToList().Min();
                double yMax = _show.YMaxEnable ? _show.YMax : keyValues.Values.ToList().Max();

                CustomChart.InitChart(ref chartsShow[id - 1], yMax, yMin, timeMax, timeMin, DateTimeIntervalType.Seconds, _show.XInterval < 0.01 ? 0.01 : _show.XInterval, _show.XFormat, sn, true, xName, yName);
                CustomChart.InitChart(ref chartsSave[id - 1], yMax, yMin, timeMax, timeMin, DateTimeIntervalType.Seconds, _show.XInterval < 0.01 ? 0.01 : _show.XInterval, _show.XFormat, sn, true, xName, yName);
                #endregion

                #region 填充数据
                foreach (var item in keyValues)
                {
                    if (item.Value >= yMin && item.Value <= yMax)
                    {
                        chartsShow[id - 1].Series[0].Points.AddXY(item.Key, item.Value);
                        chartsSave[id - 1].Series[0].Points.AddXY(item.Key, item.Value);
                    }
                }
                #endregion

                #region 保存数据
                string name = $"{sn}_{id}_{DateTime.Now:HHmmssfff}.Png";
                SaveChartPic(ref chartsSave[id - 1], index, sn, name);
                if (_show.SourceDataSaveEnable && !_show.SourceDataSave.IsNullOrWhiteSpace())
                {
                    SaveCsv(sn, keyValues, null);
                }
                #endregion
            }
            catch (Exception ex)
            {
                _show.LogAdd("time press cure save error：" + ex.Message, LogLevel.Warn);
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="index"></param>
        /// <param name="sn"></param>
        /// <param name="name"></param>
        private void SaveChartPic(ref Chart chart, int index, string sn, string name)
        {
            string path;
            if (index == 1 && !_show.PlcPath.IsNullOrWhiteSpace())
            {
                path = _show.PlcPath;
            }
            else if (index == 2 && !_show.PlcPath2.IsNullOrWhiteSpace())
            {
                path = _show.PlcPath2;
            }
            else
            {
                path = $"D:\\CPrimlog\\{_show.Name}";
            }

            if (_show.PathAddDate)
            {
                path = $@"{path}\{DateTime.Now.ToString("yyyy")}\{DateTime.Now.ToString("MMdd")}";
            }

            path = $@"{path}\{sn}\{name}";
            FileHelper.CreateNewFolder(path);

            chart.Size = new Size(800, 400); //优化01
            chart.SaveImage(path, ChartImageFormat.Png);
        }

        /// <summary>
        /// 地址处理
        /// </summary>
        /// <param name="path"></param>
        private bool PathDeal(ref string path)
        {
            if (!Directory.Exists(_show.SourceDataSave))
            {
                Directory.CreateDirectory(_show.SourceDataSave);
            }
            path = Path.Combine(_show.SourceDataSave, $"{DateTime.Now.ToString("yyyyMMdd")}.csv");
            return true;
        }

        /// <summary>
        /// 保存csv
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="points"></param>
        /// <param name="datas"></param>
        private void SaveCsv(string sn, List<PointF> points, string[] datas)
        {
            if (!_show.SourceDataSaveEnable || _show.SourceDataSave.IsNullOrWhiteSpace())
            {
                return;
            }

            string path = Path.Combine(_show.SourceDataSave, $"{DateTime.Now.ToString("yyyyMMdd")}.csv");

            StringBuilder text = new StringBuilder();
            if (datas.IsValid())
            {
                text.Append(string.Join(",", datas))
                .Append(",");
            }
            text.Append(sn + ",")
            .Append(string.Join(",", points.Select(p => p.X).ToArray()))
            .Append(Environment.NewLine);

            if (datas.IsValid())
            {
                text.Append(string.Join(",", datas))
                .Append(",");
            }
            text.Append(sn + ",");
            text.Append(string.Join(",", points.Select(p => p.Y).ToArray()));

            ModelMessage model = new ModelMessage
            {
                IsStringBuilder = true,
                ContentsStringBuilder = new List<StringBuilder>() { text },
                IsReadOnly = true,
                Path = path,
                ModelFormat = ModelFormat.CSV,
            };
            ProducerConsumerModel.Instance.Add(model);
        }

        /// <summary>
        /// 保存csv
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="keyValues"></param>
        /// <param name="datas"></param>
        private void SaveCsv(string sn, Dictionary<DateTime, double> keyValues, string[] datas)
        {
            if (!_show.SourceDataSaveEnable || _show.SourceDataSave.IsNullOrWhiteSpace())
            {
                return;
            }

            string path = Path.Combine(_show.SourceDataSave, $"{DateTime.Now.ToString("yyyyMMdd")}.csv");

            StringBuilder text = new StringBuilder();
            if (datas.IsValid())
            {
                text.Append(string.Join(",", datas))
                .Append(",");
            }
            text.Append(sn + ",")
            .Append(string.Join(",", keyValues.Keys.ToArray()))
            .Append(Environment.NewLine);

            if (datas.IsValid())
            {
                text.Append(string.Join(",", datas))
                .Append(",");
            }
            text.Append(sn + ",")
            .Append(string.Join(",", keyValues.Values.ToArray()));

            ModelMessage model = new ModelMessage
            {
                IsStringBuilder = true,
                ContentsStringBuilder = new List<StringBuilder>() { text },
                IsReadOnly = true,
                Path = path,
                ModelFormat = ModelFormat.CSV,
            };
            ProducerConsumerModel.Instance.Add(model);
        }
        #endregion
    }
}