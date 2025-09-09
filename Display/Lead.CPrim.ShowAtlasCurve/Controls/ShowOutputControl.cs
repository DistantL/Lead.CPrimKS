/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowOutputControl.cs
 * Author: Victor
 * Description: Atlas ouput界面，用来显示曲线
 * CreateTime: 2022-09-13
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 3.3.22.0904 -> 
 * <Author> (Victor)    <Time> (20220913)
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.ShowAtlasCurve.Controls
{
    public partial class ShowOutputControl : UIUserControl
    {
        #region Field
        /// <summary>压力曲线配置管理器</summary>
        public ShowAtlasCurve _show;
        /// <summary>Atlas名称集合</summary>
        UILabel[] lblStatus = new UILabel[4];
        /// <summary>曲线1数据集合</summary>
        List<PointF> xyPoint1 = new List<PointF>();
        /// <summary>曲线2数据集合</summary>
        List<PointF> xyPoint2 = new List<PointF>();
        /// <summary>曲线3数据集合</summary>
        List<PointF> xyPoint3 = new List<PointF>();
        /// <summary>曲线4数据集合</summary>
        List<PointF> xyPoint4 = new List<PointF>();
        /// <summary>曲线5数据集合</summary>
        List<PointF> xyPoint5 = new List<PointF>();
        /// <summary>曲线6数据集合</summary>
        List<PointF> xyPoint6 = new List<PointF>();
        /// <summary>曲线数据集合</summary>
        List<PointF>[] xyPoints;
        /// <summary>曲线1</summary>
        private Chart chart1 = new Chart();
        /// <summary>曲线2</summary>
        private Chart chart2 = new Chart();
        /// <summary>曲线3</summary>
        private Chart chart3 = new Chart();
        /// <summary>曲线4</summary>
        private Chart chart4 = new Chart();
        /// <summary>曲线5</summary>
        private Chart chart5 = new Chart();
        /// <summary>曲线6</summary>
        private Chart chart6 = new Chart();
        /// <summary>曲线集合</summary>
        private Chart[] charts;
        /// <summary>曲线路径集合</summary>
        string[] chartPicPath;
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="show"></param>
        public ShowOutputControl(ShowAtlasCurve show)
        {
            InitializeComponent();
            SetStyleFlags();

            tlpLayout.SetDoubleBuffered();
            tlpMain.SetDoubleBuffered();
            tlpAtlasName.SetDoubleBuffered();

            _show = show;
            lblStatus = new UILabel[4] { lblAtlas1Status, lblAtlas2Status, lblAtlas3Status, lblAtlas4Status };
            charts = new Chart[6] { chart1, chart2, chart3, chart4, chart5, chart6 };
            xyPoints = new List<PointF>[] { xyPoint1, xyPoint2, xyPoint3, xyPoint4, xyPoint5, xyPoint6 };
            chartPicPath = new string[6];
            ShowChartNum(_show.ChartNum);
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowOutputControl_Load(object sender, EventArgs e)
        {
            lblAtlas1Status.Text = _show.Atlas1Name;
            lblAtlas2Status.Text = _show.Atlas2Name;
            lblAtlas3Status.Text = _show.Atlas3Name;
            lblAtlas4Status.Text = _show.Atlas4Name;
            AtlasShowNum(_show.AtlasNum);
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
            tlpMain.ColumnStyles.Clear();
            tlpMain.RowStyles.Clear();
            if (num == 1)
            {
                tlpMain.ColumnCount = 1;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 1;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                for (int i = 0; i < num; i++)
                {
                    charts[i].Dock = DockStyle.Fill;
                }
                tlpMain.Controls.Add(chart1, 0, 0);
            }
            else if (num == 2)
            {
                tlpMain.ColumnCount = 1;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                for (int i = 0; i < num; i++)
                {
                    charts[i].Dock = DockStyle.Fill;
                }
                tlpMain.Controls.Add(chart1, 0, 0);
                tlpMain.Controls.Add(chart2, 0, 1);
            }
            else if (num == 3)
            {
                tlpMain.ColumnCount = 2;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                for (int i = 0; i < num; i++)
                {
                    charts[i].Dock = DockStyle.Fill;
                }
                tlpMain.Controls.Add(chart1, 0, 0);
                tlpMain.Controls.Add(chart2, 1, 0);
                tlpMain.Controls.Add(chart3, 0, 1);
            }
            else if (num == 4)
            {
                tlpMain.ColumnCount = 2;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                for (int i = 0; i < num; i++)
                {
                    charts[i].Dock = DockStyle.Fill;
                }
                tlpMain.Controls.Add(chart1, 0, 0);
                tlpMain.Controls.Add(chart2, 1, 0);
                tlpMain.Controls.Add(chart3, 0, 1);
                tlpMain.Controls.Add(chart4, 1, 1);
            }
            else if (num == 5)
            {
                tlpMain.ColumnCount = 3;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                for (int i = 0; i < num; i++)
                {
                    charts[i].Dock = DockStyle.Fill;
                }
                tlpMain.Controls.Add(chart1, 0, 0);
                tlpMain.Controls.Add(chart2, 1, 0);
                tlpMain.Controls.Add(chart3, 2, 0);
                tlpMain.Controls.Add(chart4, 0, 1);
                tlpMain.Controls.Add(chart5, 1, 1);
            }
            else if (num == 6)
            {
                tlpMain.ColumnCount = 3;
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpMain.RowCount = 2;
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                for (int i = 0; i < num; i++)
                {
                    charts[i].Dock = DockStyle.Fill;
                }
                tlpMain.Controls.Add(chart1, 0, 0);
                tlpMain.Controls.Add(chart2, 1, 0);
                tlpMain.Controls.Add(chart3, 2, 0);
                tlpMain.Controls.Add(chart4, 0, 1);
                tlpMain.Controls.Add(chart5, 1, 1);
                tlpMain.Controls.Add(chart6, 2, 1);
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
        /// <summary>Atlas状态设置</summary>
        /// <param name="num">1/2/3/4</param>
        /// <param name="state"></param>
        public void AtlasStatusSet(int num, bool state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int, bool>(AtlasStatusSet), new object[] { num, state });
                return;
            }
            if (num >= 1 && num <= 4)
            {
                lblStatus[num - 1].BackColor = state ? Color.LimeGreen : Color.Red;
            }
        }
        /// <summary>UI刷新</summary>
        /// <param name="watchData"></param>
        /// <param name="index"></param>
        public void ChartControl(WatchData watchData, int index)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<WatchData, int>(ChartControl), new object[] { watchData, index });
                return;
            }
            if (watchData == null)
            {
                _show.LogAdd("WatchData为空", LogLevel.Warn);
                return;
            }
            //初始化chart
            double pressureLimt = 0.2;

            for (int i = 0; i < _show.ChartNum; i++)
            {
                if (watchData.atlasData[i]?.TorqueData?.Count > 1)
                {
                    double limit = Math.Abs(watchData.atlasData[i].FinalTorque);
                    double[] limitTemp = new double[] { watchData.atlasData[i].FinalTorque, watchData.atlasData[i].TorqueData.Max(), watchData.atlasData[i].TorqueData.Min() };
                    limit = Math.Abs(limitTemp.OrderByDescending(x => Math.Abs(x)).First());
                    double xMax1 = watchData.atlasData[i].MaxAngle;
                    double xMin1 = watchData.atlasData[i].MinAngle;
                    double yMax;
                    double yMin;
                    if (_show.EnableChartYMax)
                    {
                        yMax = _show.ChartYMax == 0 ? 0.4 : Math.Abs(_show.ChartYMax);
                        yMin = _show.ChartYMax == 0 ? -0.4 : -Math.Abs(_show.ChartYMax); ;
                    }
                    else
                    {
                        double max = Math.Max(watchData.atlasData[i].TorqueData.Max(), Math.Abs(watchData.atlasData[i].TorqueData.Min()));
                        yMax = max == 0 ? 0.4 : max;
                        yMin = max == 0 ? -0.4 : -max;
                    }
                    if (limit == 0)
                    {
                        limit = 0.3;
                    }
                    CustomChart.InitAtlas(ref charts[i], yMax, yMin, pressureLimt, xMax1, xMin1);
                }
            }

            //填充数据
            RefreshForceData(watchData);

            //保存图片
            string hsgSN = watchData.HsgSn;
            string path;
            for (int i = 0; i < _show.ChartNum; i++)
            {
                if (watchData.atlasData[i]?.TorqueData?.Count > 1)
                {
                    if (string.IsNullOrEmpty(_show.AtlasPath))
                    {
                        path = $"D:\\CPrimlog\\Atlas\\{DateTime.Now.ToString("yyyy")}\\{DateTime.Now.ToString("MMdd")}\\";
                        chartPicPath[i] = path + watchData.HsgSn + "\\" + watchData.CarrierId + watchData.WatchId + $"_{i + 1}" + ".Bmp";
                    }
                    else
                    {
                        string tempPath = index == 1 ? _show.AtlasPath : _show.AtlasPath2;
                        path = $"{tempPath}\\{DateTime.Now.ToString("yyyy")}\\{DateTime.Now.ToString("MMdd")}\\";
                        chartPicPath[i] = path + watchData.HsgSn + "\\" + watchData.CarrierId + watchData.WatchId + $"_{i + 1}" + ".Bmp";
                    }

                    SaveChartPic(ref charts[i], chartPicPath[i]);
                }
            }
        }

        public void ChartControl(WatchData watchData, int chartIndex, string snIndex, double limit_up, double limit_down, double normal, int index)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<WatchData, int, string, double, double, double, int>(ChartControl), new object[] { watchData, chartIndex, snIndex, limit_up, limit_down, normal, index });
                return;
            }
            if (watchData == null)
            {
                _show.LogAdd("WatchData为空", LogLevel.Warn);
                return;
            }
            //初始化chart
            int i = 0;
            if (watchData.atlasData[i]?.TorqueData?.Count > 1)
            {
                double limit = Math.Abs(watchData.atlasData[i].FinalTorque);
                double[] limitTemp = new double[] { watchData.atlasData[i].FinalTorque, watchData.atlasData[i].TorqueData.Max(), watchData.atlasData[i].TorqueData.Min() };
                limit = Math.Abs(limitTemp.OrderByDescending(x => Math.Abs(x)).First());
                double xMax1 = watchData.atlasData[i].MaxAngle;
                double xMin1 = watchData.atlasData[i].MinAngle;
                double yMax;
                double yMin;
                if (_show.EnableChartYMax)
                {
                    yMax = _show.ChartYMax == 0 ? 0.4 : Math.Abs(_show.ChartYMax);

                    yMin = watchData.atlasData[i].TorqueData.Min() - 0.1;
                }
                else
                {
                    double max = watchData.atlasData[i].TorqueData.Max();
                    if (max < 0.1 + limit_up)
                    {
                        max = 0.1 + limit_up;
                    }
                    else
                    {
                        max += 0.1;
                    }
                    double min = watchData.atlasData[i].TorqueData.Min();
                    if (min > -0.1 + limit_down)
                    {
                        min = -0.1 + limit_down;
                    }
                    else
                    {
                        min -= 0.1;
                    }
                    yMax = max;
                    yMin = min;
                }
                if (limit == 0)
                {
                    limit = 0.3;
                }
                CustomChart.InitAtlas(ref charts[chartIndex - 1], yMax, yMin, xMax1, xMin1);
            }

            //填充数据
            RefreshForceData(watchData, chartIndex - 1, limit_up, limit_down, normal);

            //保存图片
            string hsgSN = watchData.HsgSn;
            string path;
            i = 0;
            {
                if (watchData.atlasData[i]?.TorqueData?.Count > 1)
                {
                    if (string.IsNullOrEmpty(_show.AtlasPath))
                    {
                        path = $"D:\\CPrimlog\\Atlas\\{DateTime.Now.ToString("yyyy")}\\{DateTime.Now.ToString("MMdd")}\\";
                        chartPicPath[i] = path + watchData.HsgSn + "\\" + watchData.CarrierId + watchData.WatchId + $"_{chartIndex}" + ".Bmp";
                    }
                    else
                    {
                        string tempPath = index == 1 ? _show.AtlasPath : _show.AtlasPath2;
                        path = $"{tempPath}\\{DateTime.Now.ToString("yyyy")}\\{DateTime.Now.ToString("MMdd")}\\";
                        chartPicPath[i] = path + watchData.HsgSn + "\\" + watchData.CarrierId + watchData.WatchId + $"_{chartIndex}" + ".Bmp";
                    }

                    SaveChartPic(ref charts[chartIndex - 1], chartPicPath[i]);

                    if (!string.IsNullOrEmpty(_show.AtlasPath2))
                    {
                        string tempPath = _show.AtlasPath2;
                        path = $"{tempPath}\\";
                        chartPicPath[i] = path + snIndex + "\\" + watchData.CarrierId + watchData.WatchId + $"_{chartIndex}" + ".Bmp";
                    }

                    SaveChartPic(ref charts[chartIndex - 1], chartPicPath[i]);



                    if (string.IsNullOrEmpty(_show.AtlasPath))
                    {
                        path = $"D:\\CPrimlog\\Atlas\\{DateTime.Now.ToString("yyyy")}\\{DateTime.Now.ToString("MMdd")}\\";
                        chartPicPath[i] = path + watchData.HsgSn + "\\" + watchData.CarrierId + watchData.WatchId + $"_{chartIndex}" + ".csv";
                    }
                    else
                    {
                        string tempPath = index == 1 ? _show.AtlasPath : _show.AtlasPath2;
                        path = $"{tempPath}\\{DateTime.Now.ToString("yyyy")}\\{DateTime.Now.ToString("MMdd")}\\";
                        chartPicPath[i] = path + watchData.HsgSn + "\\" + watchData.CarrierId + watchData.WatchId + $"_{chartIndex}" + ".csv";
                    }
                    SaveToCsv(ref charts[chartIndex - 1], chartPicPath[i]);
                }
            }
        }


        /// <summary>名称1更新</summary>
        /// <param name="name">名称</param>
        public void NameUpdate1(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(NameUpdate1), name);
                return;
            }

            lblAtlas1Status.Text = string.IsNullOrEmpty(name) ? "Atlas1Status" : name;
        }
        /// <summary>名称2更新</summary>
        /// <param name="name">名称</param>
        public void NameUpdate2(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(NameUpdate2), name);
                return;
            }

            lblAtlas2Status.Text = string.IsNullOrEmpty(name) ? "Atlas2Status" : name;
        }
        /// <summary>名称3更新</summary>
        /// <param name="name">名称</param>
        public void NameUpdate3(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(NameUpdate3), name);
                return;
            }

            lblAtlas3Status.Text = string.IsNullOrEmpty(name) ? "Atlas3Status" : name;
        }
        /// <summary>名称4更新</summary>
        /// <param name="name">名称</param>
        public void NameUpdate4(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(NameUpdate4), name);
                return;
            }

            lblAtlas4Status.Text = string.IsNullOrEmpty(name) ? "Atlas4Status" : name;
        }
        /// <summary>Atlas显示数量更新</summary>
        /// <param name="num"></param>
        public void AtlasShowNum(int num)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(AtlasShowNum), num);
                return;
            }

            for (int i = 0; i < lblStatus.Length; i++)
            {
                lblStatus[i].Visible = false;
            }
            for (int i = 0; i < num; i++)
            {
                lblStatus[i].Visible = true;
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>填充数据</summary>
        /// <param name="forceData"></param>
        private void RefreshForceData(WatchData forceData)
        {
            for (int i = 0; i < _show.ChartNum; i++)
            {
                if (forceData.atlasData[i]?.TorqueData?.Count > 1)
                {
                    xyPoints[i] = new List<PointF>();
                    PointF pointF = new PointF();
                    for (int j = 0; j < forceData?.atlasData[i]?.AngleData?.Count; j++)
                    {
                        if (pointF.X == (float)forceData.atlasData[i].AngleData[j] && xyPoints[i].Count > 0)
                        {
                            xyPoints[i].RemoveAt(xyPoints[i].Count - 1);
                            pointF.Y = ((float)forceData.atlasData[i].TorqueData[j] + pointF.Y) / 2;
                        }
                        else
                        {
                            pointF.X = (float)forceData.atlasData[i].AngleData[j];
                            pointF.Y = (float)forceData.atlasData[i].TorqueData[j];
                        }
                        xyPoints[i].Add(pointF);
                    }
                    if (xyPoints[i].Count > 0)
                    {
                        if (xyPoints[i][xyPoints[i].Count - 1].X == 0)
                        {
                            xyPoints[i].RemoveAt(xyPoints[i].Count - 1);
                        }
                    }

                    foreach (var item in xyPoints[i])
                    {
                        charts[i].Series[0].Points.AddXY(item.X, item.Y);
                    }
                }

                //2023-05-13-50994 
                ChartExtend(i, charts[i], forceData);
            }
        }

        private void RefreshForceData(WatchData forceData, int index, double limit_up, double limit_down, double normal)
        {
            int i = 0;
            {
                if (forceData.atlasData[i]?.TorqueData?.Count > 1)
                {
                    xyPoints[i] = new List<PointF>();
                    PointF pointF = new PointF();
                    for (int j = 0; j < forceData?.atlasData[i]?.AngleData?.Count; j++)
                    {
                        if (pointF.X == (float)forceData.atlasData[i].AngleData[j] && xyPoints[i].Count > 0)
                        {
                            xyPoints[i].RemoveAt(xyPoints[i].Count - 1);
                            pointF.Y = ((float)forceData.atlasData[i].TorqueData[j] + pointF.Y) / 2;
                        }
                        else
                        {
                            pointF.X = (float)forceData.atlasData[i].AngleData[j];
                            pointF.Y = (float)forceData.atlasData[i].TorqueData[j];
                        }
                        xyPoints[i].Add(pointF);
                    }
                    if (xyPoints[i].Count > 0)
                    {
                        if (xyPoints[i][xyPoints[i].Count - 1].X == 0)
                        {
                            xyPoints[i].RemoveAt(xyPoints[i].Count - 1);
                        }
                    }

                    foreach (var item in xyPoints[i])
                    {
                        charts[index].Series[0].Points.AddXY(item.X, item.Y);
                    }
                    double x1 = forceData.atlasData[i].AngleData.Min();
                    double x2 = forceData.atlasData[i].AngleData.Max();

                    charts[index].Series["上限"].Points.AddXY(x1, limit_up);
                    charts[index].Series["上限"].Points.AddXY(x1 + 50, limit_up);
                    charts[index].Series["上限"].Points[1].IsValueShownAsLabel = true;
                    charts[index].Series["上限"].Points.AddXY(x2, limit_up);


                    charts[index].Series["标准值"].Points.AddXY(x1, normal);
                    charts[index].Series["标准值"].Points.AddXY(x1 + 50, normal);
                    charts[index].Series["标准值"].Points[1].IsValueShownAsLabel = true;
                    charts[index].Series["标准值"].Points.AddXY(x2, normal);

                    charts[index].Series["下限"].Points.AddXY(x1, limit_down);
                    charts[index].Series["下限"].Points.AddXY(x1 + 50, limit_down);
                    charts[index].Series["下限"].Points[1].IsValueShownAsLabel = true;
                    charts[index].Series["下限"].Points.AddXY(x2, limit_down);
                }

                ChartSingleExtend(index, charts[index], forceData);
            }
        }


        /// <summary>保存图片</summary>
        /// <param name="chart"></param>
        /// <param name="path"></param>
        private void SaveChartPic(ref Chart chart, string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Directory.Exists)
            {
                FileHelper.CreateNewFolder(path);
            }
            chart.SaveImage(path, ChartImageFormat.Bmp);
        }

        private void SaveToCsv(ref Chart chart, string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Directory.Exists)
            {
                FileHelper.CreateNewFolder(path);
            }

            try
            {
                if (chart != null && chart.Series != null && chart.Series.Count() != 0
                    && chart.Series[0].Points != null)
                {
                    //StringBuilder sb = new StringBuilder(10240);
                    using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                    {
                        sw.WriteLine("Angle,Torque");
                        foreach (var item in chart.Series[0].Points)
                        {
                            sw.Write(item.XValue);
                            sw.Write(',');
                            sw.WriteLine(item.YValues[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void ChartExtend(int i, Chart chart, WatchData forceData)
        {
            chart.Titles.Clear();
            chart.Titles.Add(forceData.CarrierId + "_" + forceData.WatchId + "_" + i);
            chart.Legends.Clear();
            if (i < 1)
            {
                return;
            }

            var legend = new Legend();
            legend.Title = "Result";
            chart.Legends.Add(legend);

            /*FinalTorque
            FinalAngle
            StepClampTorque
            StepClampAngle*/
            var legendItem = new LegendItem();
            legendItem.SeparatorType = LegendSeparatorStyle.Line;
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, "FinalTorque", ContentAlignment.MiddleRight));
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, forceData.atlasData[i].FinalTorque.ToString("f3"), ContentAlignment.MiddleLeft));
            legend.CustomItems.Add(legendItem);
            legendItem = new LegendItem();
            legendItem.SeparatorType = LegendSeparatorStyle.Line;
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, "FinalAngle", ContentAlignment.MiddleRight));
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, forceData.atlasData[i].FinalAngle.ToString("f3"), ContentAlignment.MiddleLeft));
            legend.CustomItems.Add(legendItem);
            legendItem = new LegendItem();
            legendItem.SeparatorType = LegendSeparatorStyle.Line;
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, "StepClampTorque", ContentAlignment.MiddleRight));
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, forceData.atlasData[i].StepClampTorque.ToString("f3"), ContentAlignment.MiddleLeft));
            legend.CustomItems.Add(legendItem);
            legendItem = new LegendItem();
            legendItem.SeparatorType = LegendSeparatorStyle.Line;
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, "StepClampAngle", ContentAlignment.MiddleRight));
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, forceData.atlasData[i].StepClampAngle.ToString("f3"), ContentAlignment.MiddleLeft));
            legend.CustomItems.Add(legendItem);
        }


        private void ChartSingleExtend(int i, Chart chart, WatchData forceData)
        {
            chart.Titles.Clear();
            chart.Titles.Add(forceData.CarrierId + "_" + forceData.WatchId + "_" + i);
            chart.Legends.Clear();

            i = 0;

            var legend = new Legend();
            legend.Title = "Result";
            chart.Legends.Add(legend);

            /*FinalTorque
            FinalAngle
            StepClampTorque
            StepClampAngle*/
            var legendItem = new LegendItem();
            legendItem.SeparatorType = LegendSeparatorStyle.Line;
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, "FinalTorque", ContentAlignment.MiddleRight));
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, forceData.atlasData[i].FinalTorque.ToString("f3"), ContentAlignment.MiddleLeft));
            legend.CustomItems.Add(legendItem);
            legendItem = new LegendItem();
            legendItem.SeparatorType = LegendSeparatorStyle.Line;
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, "FinalAngle", ContentAlignment.MiddleRight));
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, forceData.atlasData[i].FinalAngle.ToString("f3"), ContentAlignment.MiddleLeft));
            legend.CustomItems.Add(legendItem);
            legendItem = new LegendItem();
            legendItem.SeparatorType = LegendSeparatorStyle.Line;
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, "StepClampTorque", ContentAlignment.MiddleRight));
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, forceData.atlasData[i].StepClampTorque.ToString("f3"), ContentAlignment.MiddleLeft));
            legend.CustomItems.Add(legendItem);
            legendItem = new LegendItem();
            legendItem.SeparatorType = LegendSeparatorStyle.Line;
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, "StepClampAngle", ContentAlignment.MiddleRight));
            legendItem.Cells.Add(new LegendCell(LegendCellType.Text, forceData.atlasData[i].StepClampAngle.ToString("f3"), ContentAlignment.MiddleLeft));
            legend.CustomItems.Add(legendItem);
        }


        #endregion
    }
}
