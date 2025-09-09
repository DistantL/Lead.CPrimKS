using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.Proxy
{
    public partial class 单项柱状图 : UserControl
    {
        /// <summary>最近32片OK产品Cpk数据</summary>
        public List<double> CpkData = new List<double>();

        /// <summary>柱子集合</summary>
        public List<double>[] AverageV;
        /// <summary>X轴计数</summary>
        public string[] X;
        /// <summary>Y轴计数</summary>
        public int[] Y;
        /// <summary>柱状图范围</summary>
        double[] Range;

        /// <summary>FAI名称</summary>
        public string FAIName;
        /// <summary>下限</summary>
        public double LimitMin;
        /// <summary>上限</summary>
        public double LimitMax;
        /// <summary>标准值</summary>
        public double LimitNormal;
        /// <summary>柱状图数量</summary>
        public int Num;
        /// <summary>NG数量</summary>
        public int YieldNGNum = 0;
        /// <summary>无效NG数量</summary>
        public int YieldInvalidNum = 0;
        /// <summary>OK数量</summary>
        public int YieldOKNum = 0;
        /// <summary>良率</summary>
        public double YieldRate = 100.00;
        /// <summary>平均值</summary>
        public double AverageValue = 0.00;
        /// <summary>Cpk</summary>
        public double CpkValue = 0.00;
        /// <summary>Cp</summary>
        public double CpValue = 1.00;
        /// <summary>Ca</summary>
        public double CaValue = 1.00;


        #region Ctor
        public 单项柱状图()
        {
            InitializeComponent();
        }
        public 单项柱状图(string name, double limitNormal, double limitMin, double limitMax) : this()
        {
            ChartDataIni(name, limitMin, limitMax, limitNormal, 14);
        }
        #endregion



        #region Button_Event
        /// <summary>双击</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cht1_DoubleClick(object sender, EventArgs e)
        {
            foreach (Form TMEP in Application.OpenForms)
            {
                if (TMEP.Text == FAIName) return;
            }
            Form form1 = new Form();
            单项柱状图 newchart = new 单项柱状图();
            newchart.ChartDataIni(this.FAIName, this.LimitMin, this.LimitMax, this.LimitNormal, this.Num);
            newchart.IsShowAxisYLabel(true);
            newchart.X = X;
            newchart.Y = Y;
            newchart.CpkData = CpkData;
            newchart.AverageV = AverageV;
            newchart.ChartRefresh();
            newchart.IsShowAxisXLabel(true);
            newchart.Dock = DockStyle.Fill;
            form1.Controls.Add(newchart);
            form1.Height = 500;
            form1.Width = 640;
            form1.Text = FAIName;
            form1.Show();
        }
        /// <summary>右击保存图像</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string savePath;
            try
            {
                saveFileDialog1.Filter = "*.png|*.PNG";
                saveFileDialog1.FileName = this.FAIName;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileInfo _fi = new FileInfo(saveFileDialog1.FileName);
                    savePath = _fi.DirectoryName;
                    Stream imageStream = null;
                    SaveChart(this.FAIName, this.LimitMin, this.LimitMax, this.LimitNormal, this.Num, savePath, imageStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>数据填充</summary>
        /// <param name="FAIValue"></param>
        public void ChartDataRefresh(double FAIValue)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<double>(ChartDataRefresh), new object[1] { FAIValue });
            }
            else
            {
                if (FAIValue >= LimitMin && FAIValue <= LimitMax)
                {
                    if (CpkData.Count < 33)
                    {
                        CpkData.Add(FAIValue);
                    }
                    else
                    {
                        CpkData.RemoveAt(0);
                        CpkData.Add(FAIValue);
                    }
                }

                if (FAIValue < Range[1])
                {
                    AverageV[0].Add(FAIValue);
                    Y[0]++;
                }
                else if (FAIValue >= Range[Num - 1])
                {
                    AverageV[Num - 1].Add(FAIValue);
                    Y[Num - 1]++;
                }
                else
                {
                    for (int j = 1; j < Num - 2; j++)
                    {
                        if (FAIValue >= Range[j] && FAIValue < Range[j + 1])
                        {
                            AverageV[j].Add(FAIValue);
                            Y[j]++;
                        }
                    }
                }
            }
        }
        /// <summary>界面显示</summary>
        public void ChartRefresh()
        {
            try
            {
                YieldNGNum = 0;
                YieldOKNum = 0;
                YieldInvalidNum = 0;
                //绑定数据
                cht1.Series[0].Points.Clear();
                cht1.Series[0].Points.DataBindXY(X, Y);
                if (Num < 15)
                {
                    cht1.Series[0].Points[0].Color = Color.Yellow;
                    cht1.Series[0].Points[1].Color = Color.Red;
                    cht1.Series[0].Points[Num - 2].Color = Color.Red;
                    cht1.Series[0].Points[Num - 1].Color = Color.Yellow;
                    YieldNGNum = Y[1] + Y[Num - 2];
                    YieldInvalidNum = Y[0] + Y[Num - 1];
                    for (int j = 2; j < Num - 2; j++)
                    {
                        YieldOKNum = YieldOKNum + Y[j];
                    }
                    if ((YieldOKNum + YieldNGNum) != 0)
                    {
                        YieldRate = Convert.ToDouble(YieldOKNum) / Convert.ToDouble(YieldOKNum + YieldNGNum) * 100.0;
                        cht1.Titles[4].Text = ("Yield:" + YieldRate.ToString("f2") + "%");
                    }
                    else
                    {
                        YieldRate = 100.00;
                        cht1.Titles[4].Text = ("Yield:" + YieldRate.ToString("f2") + "%");
                    }
                    cht1.Titles[5].Text = "Aver:" + GetAverage(AverageV).ToString("f3");
                }
                else
                {

                    cht1.Series[0].Points[0].Color = Color.Yellow;
                    cht1.Series[0].Points[1].Color = Color.Red;
                    cht1.Series[0].Points[2].Color = Color.Red;
                    cht1.Series[0].Points[3].Color = Color.Red;
                    cht1.Series[0].Points[4].Color = Color.Red;
                    cht1.Series[0].Points[Num - 5].Color = Color.Red;
                    cht1.Series[0].Points[Num - 4].Color = Color.Red;
                    cht1.Series[0].Points[Num - 3].Color = Color.Red;
                    cht1.Series[0].Points[Num - 2].Color = Color.Red;
                    cht1.Series[0].Points[Num - 1].Color = Color.Yellow;

                    YieldNGNum = Y[1] + Y[2] + Y[3] + Y[4] + Y[5] + Y[Num - 6] + Y[Num - 5] + Y[Num - 4] + Y[Num - 3] + Y[Num - 2];
                    YieldInvalidNum = Y[0] + Y[Num - 1];
                    for (int j = 6; j < Num - 6; j++)
                    {
                        YieldOKNum += Y[j];
                    }
                    if ((YieldOKNum + YieldNGNum + YieldInvalidNum) != 0)
                    {
                        YieldRate = YieldOKNum / Convert.ToDouble(YieldOKNum + YieldNGNum + YieldInvalidNum);
                        cht1.Titles[4].Text = $"Yield:{YieldRate.ToString("P2")}";
                    }
                    else
                    {
                        YieldRate = 1.0;
                        cht1.Titles[4].Text = $"Yield:{YieldRate.ToString("P2")}";
                    }
                    AverageValue = GetAverage(AverageV);
                    cht1.Titles[5].Text = "Aver:" + AverageValue.ToString("f2");
                    CpkValue = GetCpk();
                    cht1.Titles[6].Text = "Cpk:" + CpkValue.ToString("f2");
                }
            }
            catch
            {

            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>生成图形</summary>
        /// <param name="FAIName"></param>
        /// <param name="LimitMin"></param>
        /// <param name="LimitMax"></param>
        /// <param name="LimitNormal"></param>
        /// <param name="num"></param>
        public void ChartDataIni(string FAIName, double LimitMin, double LimitMax, double LimitNormal, int num)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, double, double, double, int>(ChartDataIni), new object[5] { FAIName, LimitMin, LimitMax, LimitNormal, num });
            }
            else
            {
                YieldRate = 0.0;
                //柱状图
                ////标题
                cht1.Titles.Add(FAIName);
                cht1.Titles[0].ForeColor = Color.Black;
                cht1.Titles[0].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                cht1.Titles[0].Alignment = ContentAlignment.TopCenter;
                //cht1.Titles[0].Position.Auto =false;
                //cht1.Titles[0].Position.Width = 30;
                //cht1.Titles[0].Position.X = 0;
                //cht1.Titles[0].Position.Y = 2;

                cht1.Titles.Add("DownVale:" + LimitMin.ToString("f3"));
                cht1.Titles[1].ForeColor = Color.Black;
                cht1.Titles[1].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                cht1.Titles[1].Position.Auto = false;
                cht1.Titles[1].Position.Width = 50;
                cht1.Titles[1].Position.Height = 9;
                cht1.Titles[1].Position.X = 0;
                cht1.Titles[1].Position.Y = 2;
                cht1.Titles[1].Alignment = ContentAlignment.MiddleLeft;

                cht1.Titles.Add("NomVaule:" + LimitNormal.ToString("f3"));
                cht1.Titles[2].ForeColor = Color.Black;
                cht1.Titles[2].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                cht1.Titles[2].Position.Auto = false;
                cht1.Titles[2].Position.Width = 50;
                cht1.Titles[2].Position.Height = 9;
                cht1.Titles[2].Position.X = 0;
                cht1.Titles[2].Position.Y = 2 + 1 * cht1.Titles[1].Position.Height;
                cht1.Titles[2].Alignment = ContentAlignment.MiddleLeft;

                cht1.Titles.Add("UpValue:" + LimitMax.ToString("f3"));
                cht1.Titles[3].ForeColor = Color.Black;
                cht1.Titles[3].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                cht1.Titles[3].Position.Auto = false;
                cht1.Titles[3].Position.Width = 50;
                cht1.Titles[3].Position.Height = 9;
                cht1.Titles[3].Position.X = 0;
                cht1.Titles[3].Position.Y = 2 + 2 * cht1.Titles[1].Position.Height;
                cht1.Titles[3].Alignment = ContentAlignment.MiddleLeft;

                cht1.Titles.Add("Yield:" + YieldRate.ToString("p2"));
                cht1.Titles[4].ForeColor = Color.Black;
                cht1.Titles[4].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                cht1.Titles[4].Position.Auto = false;
                cht1.Titles[4].Position.Width = 50;
                cht1.Titles[4].Position.Height = 9;
                cht1.Titles[4].Position.X = 0;
                cht1.Titles[4].Position.Y = 2 + 3 * cht1.Titles[1].Position.Height;
                cht1.Titles[4].Alignment = ContentAlignment.MiddleLeft;

                cht1.Titles.Add("Aver:" + AverageValue.ToString("f2"));
                cht1.Titles[5].ForeColor = Color.Black;
                cht1.Titles[5].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                cht1.Titles[5].Position.Auto = false;
                cht1.Titles[5].Position.Width = 50;
                cht1.Titles[5].Position.Height = 9;
                cht1.Titles[5].Position.X = 0;
                cht1.Titles[5].Position.Y = 2 + 4 * cht1.Titles[1].Position.Height;
                cht1.Titles[5].Alignment = ContentAlignment.MiddleLeft;

                #region CPK
                cht1.Titles.Add("Cpk:" + this.AverageValue.ToString("f2"));
                cht1.Titles[6].ForeColor = Color.Black;
                cht1.Titles[6].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
                cht1.Titles[6].Position.Auto = false;
                cht1.Titles[6].Position.Width = 50;
                cht1.Titles[6].Position.Height = 9;
                cht1.Titles[6].Position.X = 0;
                cht1.Titles[6].Position.Y = 2 + 5 * cht1.Titles[1].Position.Height;
                cht1.Titles[6].Alignment = ContentAlignment.MiddleLeft;
                #endregion

                //控件背景
                cht1.BackColor = Color.Transparent;
                //图表区背景
                cht1.ChartAreas[0].BackColor = Color.Transparent;
                cht1.ChartAreas[0].BorderColor = Color.Transparent;
                //X轴标签间距
                cht1.ChartAreas[0].AxisX.Interval = 1;
                cht1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
                //cht1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                cht1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 2f, FontStyle.Regular);
                cht1.ChartAreas[0].AxisX.TitleForeColor = Color.Black;
                IsShowAxisXLabel(false);

                //X坐标轴颜色
                cht1.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#38587a"); ;
                cht1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                cht1.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
                cht1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                //X坐标轴标题
                //cht1.ChartAreas[0].AxisX.Title = "数量(Pcs)";
                cht1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 2f, FontStyle.Regular);
                cht1.ChartAreas[0].AxisX.TitleForeColor = Color.Black;
                cht1.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
                cht1.ChartAreas[0].AxisX.ToolTip = "数量(Pcs)";
                //X轴网络线条
                //cht1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                cht1.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

                //Y坐标轴颜色
                cht1.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
                cht1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                cht1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
                cht1.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = false;
                //Y坐标轴标题
                //cht1.ChartAreas[0].AxisY.Title = "数量(Pcs)";
                cht1.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
                cht1.ChartAreas[0].AxisY.TitleForeColor = Color.Black;
                cht1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
                cht1.ChartAreas[0].AxisY.ToolTip = "数量(Pcs)";
                //Y轴网格线条
                cht1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                cht1.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

                cht1.ChartAreas[0].AxisY2.LineColor = Color.Transparent;
                //cht1.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;
                Legend legend = new Legend("legend");
                legend.Title = "legendTitle";

                //设置上下限
                StripLine _StripLineMax = new StripLine();
                _StripLineMax.BackColor = Color.Red;
                _StripLineMax.IntervalOffset = num > 15 ? num - 4.5 : num - 2.5;
                _StripLineMax.StripWidth = 0.01;
                _StripLineMax.TextOrientation = TextOrientation.Horizontal;

                StripLine _StripLineMin = new StripLine();
                _StripLineMin.BackColor = Color.Red;
                _StripLineMin.IntervalOffset = num > 15 ? 5.5 : 3.5;
                _StripLineMin.StripWidth = 0.01;
                _StripLineMin.TextOrientation = TextOrientation.Horizontal;

                cht1.ChartAreas[0].AxisX.StripLines.Add(_StripLineMax);
                cht1.ChartAreas[0].AxisX.StripLines.Add(_StripLineMin);


                cht1.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
                IsShowAxisYLabel(false);
                cht1.Series[0].LabelForeColor = Color.Black;
                cht1.Series[0].ToolTip = "#VALX:#VAL";     //鼠标移动到对应点显示数值
                cht1.Series[0].ChartType = SeriesChartType.Column;    //图类型(柱形图)
                cht1.Series[0].Color = Color.Green;
                cht1.Series[0].LegendText = legend.Name;
                cht1.Series[0].IsValueShownAsLabel = false;
                cht1.Series[0].CustomProperties = "DrawingStyle = Cylinder";
                cht1.Series[0]["PointWidth"] = "1";

                AverageV = new List<double>[num];
                for (int i = 0; i < num; i++)
                {
                    AverageV[i] = new List<double>();
                }

                X = new string[num];
                Y = new int[num];
                Range = new double[num + 1];
                for (int i = 0; i < num; i++)
                {
                    X[i] = "";
                    Y[i] = 0;
                    Range[i] = 0;
                }
                Range[num] = 0;

                if (num > 15)
                {
                    //5倍规格公差
                    Range[0] = LimitMin - (LimitMax - LimitMin) * 5;
                    Range[1] = LimitMin - (LimitMax - LimitMin) * 1;
                    Range[2] = LimitMin - (LimitMax - LimitMin) * 0.6;
                    Range[3] = LimitMin - (LimitMax - LimitMin) * 0.4;
                    Range[4] = LimitMin - (LimitMax - LimitMin) * 0.2;
                    Range[5] = LimitMin;
                    for (int i = 6; i < num - 5; i++)
                    {
                        Range[i] = Range[i - 1] + (LimitMax - LimitMin) / (num - 10);
                    }
                    Range[num - 5] = LimitMax;
                    Range[num - 4] = LimitMax + (LimitMax - LimitMin) * 0.2;
                    Range[num - 3] = LimitMax + (LimitMax - LimitMin) * 0.4;
                    Range[num - 2] = LimitMax + (LimitMax - LimitMin) * 0.6;
                    Range[num - 1] = LimitMax + (LimitMax - LimitMin) * 1;
                    Range[num] = LimitMax + (LimitMax - LimitMin) * 5;
                }
                else
                {
                    //5倍规格公差
                    Range[0] = LimitMin - (LimitMax - LimitMin) * 5;
                    Range[1] = LimitMin - (LimitMax - LimitMin) * 1;
                    Range[2] = LimitMin - (LimitMax - LimitMin) * 0.2;
                    Range[3] = LimitMin;
                    for (int i = 4; i < num - 3; i++)
                    {
                        Range[i] = Range[i - 1] + (LimitMax - LimitMin) / (num - 6);
                    }
                    Range[num - 3] = LimitMax;
                    Range[num - 2] = LimitMax + (LimitMax - LimitMin) * 0.2;
                    Range[num - 1] = LimitMax + (LimitMax - LimitMin) * 1;
                    Range[num] = LimitMax + (LimitMax - LimitMin) * 5;
                }
                //更新数组X
                for (int i = 0; i < num; i++)
                {
                    X[i] = ((Range[i] + Range[i + 1]) / 2).ToString("f2");
                }

                this.FAIName = FAIName;
                this.LimitMin = Convert.ToDouble(LimitMin.ToString("f3"));
                this.LimitMax = Convert.ToDouble(LimitMax.ToString("f3"));
                this.LimitNormal = Convert.ToDouble(LimitNormal.ToString("f3"));
                Num = num;
            }
        }
        /// <summary>计算平均值</summary>
        /// <param name="AverageVTemp"></param>
        /// <returns></returns>
        private double GetAverage(List<double>[] AverageVTemp)
        {
            double AverageValueFinal = 0;
            double AllData = 0;
            int AllDataCount = 0;

            for (int i = 0; i < AverageVTemp.Length; i++)
            {
                for (int j = 0; j < AverageVTemp[i].Count; j++)
                {
                    AllData += AverageVTemp[i][j];
                    AllDataCount++;
                }
            }

            if (AllDataCount == 0)
            {
                AverageValueFinal = 0;
            }
            else
            {
                AverageValueFinal = AllData / AllDataCount;
            }
            return AverageValueFinal;
        }

        /// <summary>计算方差</summary>
        /// <returns></returns>
        private double GetStdev()
        {
            double sum = 0;
            foreach (var cpk in CpkData)
            {
                sum += (cpk - AverageValue) * (cpk - AverageValue);
            }

            return Math.Sqrt(sum / (CpkData.Count - 1));
        }
        /// <summary>计算Cp</summary>
        /// <returns></returns>
        private double GetCp()
        {
            return (LimitMax - LimitMin) / (6 * GetStdev());
        }
        /// <summary>计算Ca</summary>
        /// <returns></returns>
        private double GetCa()
        {
            return (AverageValue - LimitNormal) / ((LimitMax - LimitMin) / 2);
        }
        /// <summary>Cpk计算</summary>
        /// <returns></returns>
        private double GetCpk()
        {
            return GetCp() * (1 - Math.Abs(GetCa()));
        }
        /// <summary>X轴标签显示</summary>
        /// <param name="temp">true：显示；false：不显示</param>
        public void IsShowAxisXLabel(bool temp)
        {
            cht1.ChartAreas[0].Axes[0].LabelStyle.Enabled = temp;
        }
        /// <summary>Y轴标签显示</summary>
        /// <param name="temp">true：显示；false：不显示</param>
        public void IsShowAxisYLabel(bool temp)
        {
            cht1.Series[0].Label = temp ? "#VAL" : null;
        }
        /// <summary>保存图表</summary>
        /// <param name="FAIName"></param>
        /// <param name="LimitMin"></param>
        /// <param name="LimitMax"></param>
        /// <param name="LimitNormal"></param>
        /// <param name="num"></param>
        /// <param name="path"></param>
        /// <param name="imageStream"></param>
        private void SaveChart(string FAIName, double LimitMin, double LimitMax, double LimitNormal, int num, string path, Stream imageStream)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, double, double, double, int>(ChartDataIni), new object[5] { FAIName, LimitMin, LimitMax, LimitNormal, num });
            }
            else
            {
                单项柱状图 newchart = new 单项柱状图();
                newchart.ChartDataIni(FAIName, LimitMin, LimitMax, LimitNormal, num);
                newchart.X = this.X;
                newchart.Y = this.Y;
                //newchart.xArray = this.xArray;
                //newchart.yArray = this.yArray;
                newchart.CpkData = this.CpkData;
                newchart.AverageV = this.AverageV;
                ////标题
                newchart.ChartRefresh();
                newchart.IsShowAxisYLabel(true);
                newchart.IsShowAxisXLabel(true);
                newchart.cht1.BackColor = Color.White;
                newchart.cht1.BorderlineDashStyle = ChartDashStyle.Solid;
                newchart.cht1.BorderlineColor = Color.Black;
                newchart.Dock = DockStyle.Fill;
                newchart.Width = 800;
                newchart.Height = 600;

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);//创建文件夹
                newchart.cht1.SaveImage(path + @"\" + FAIName + ".Png", ImageFormat.Png);
                if (imageStream != null)
                {
                    newchart.cht1.SaveImage(imageStream, ImageFormat.Png);
                }
            }
        }
        #endregion



        #region Method_Obsolete
        [Obsolete]
        public void SaveImageToxls(string savePath)
        {
            Stream imageStream = null;

            SaveChart(this.FAIName, this.LimitMin, this.LimitMax, this.LimitNormal, this.Num, savePath, imageStream);
        }
        [Obsolete]
        public void EnableColor(bool TEMP)
        {
            if (TEMP)
            {
                cht1.ChartAreas[0].BackColor = Color.White;
                cht1.BackColor = Color.White;
            }
            else
            {
                cht1.ChartAreas[0].BackColor = Color.LightGray;
                cht1.BackColor = Color.LightGray;
            }
        }
        #endregion
    }
}
