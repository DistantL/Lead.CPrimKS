using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.Controls
{
    public partial class CustomChartFrm : UIUserControl
    {
        public CustomChartFrm()
        {
            InitializeComponent();
            cpStart.Value = Color.Red;
            cpEnd.Value = Color.Green;
            nudCount.Value = 6;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder();
            text.Append("111,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("111,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");

            text.Append("222,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("222,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18");
            text.Append("\n");

            text.Append("333,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("333,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19");
            text.Append("\n");

            text.Append("444,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("444,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20");
            text.Append("\n");

            text.Append("555,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("555,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21");
            text.Append("\n");

            text.Append("666,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("666,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22");
            text.Append("\n");

            text.Append("777,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("777,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23");
            text.Append("\n");

            text.Append("888,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("888,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24");
            text.Append("\n");

            text.Append("999,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            text.Append("\n");
            text.Append("999,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25");
            text.Append("\n");

            string path = "";
            if (!FileHelper.SaveFileDialogMethod("", Interfaces.FilterType.CSV, Interfaces.DefaultExt.CSV, true, false, true, ref path))
            {
                return;
            }

            CsvHelper.WriteStringToCsv(path, text.ToString(), false);
        }

        private void btnInitChart_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                if (!FileHelper.OpenFileDialogMethod(ref path))
                {
                    return;
                }

                List<string> lData = new List<string>();
                CsvHelper.ReadCsvToListString(path, Encoding.Default, false, out lData);
                if (!lData.IsValid())
                {
                    throw new Exception("数据为空");
                }

                bool xMinIsValid = false;
                bool xMaxIsValid = false;
                double xMinDefine = 0;
                double xMaxDefine = 0;
                string minValue = txtXMin.Text;
                string maxValue = txtXMax.Text;

                xMinIsValid = minValue.IsNullOrEmpty() ? false : true;
                xMaxIsValid = maxValue.IsNullOrEmpty() ? false : true;

                if (xMinIsValid && !double.TryParse(minValue, out xMinDefine))
                {
                    throw new Exception("xMin值无效");
                }
                if (xMaxIsValid && !double.TryParse(maxValue, out xMaxDefine))
                {
                    throw new Exception("xMax值无效");
                }

                double xMin = int.MaxValue;
                double xMax = int.MinValue;
                Dictionary<string, Dictionary<double, double>> chartDatas = new Dictionary<string, Dictionary<double, double>>();
                for (int i = 0; i < lData.Count - 1; i++)
                {
                    Dictionary<double, double> dic = new Dictionary<double, double>();
                    string[] line1 = lData[i].Split(new char[] { ',' });
                    string[] line2 = lData[i + 1].Split(new char[] { ',' });
                    string name = line1[0];
                    if (line1[0] != line2[0] || line1.Length != line2.Length || name.IsNullOrEmpty())
                    {
                        continue;
                    }

                    for (int j = 1; j < line1.Length; j++)
                    {
                        double value1 = double.Parse(line1[j]);
                        double value2 = double.Parse(line2[j]);

                        if (!dic.ContainsKey(value1))
                        {
                            if (value1 < xMin)
                            {
                                xMin = value1;
                            }
                            if (value1 > xMax)
                            {
                                xMax = value1;
                            }
                            dic.Add(value1, value2);
                        }
                    }

                    if (!chartDatas.ContainsKey(name))
                    {
                        chartDatas.Add(name, dic);
                    }
                    i++;
                }

                if (chartDatas == null || chartDatas.Count == 0)
                {
                    throw new Exception("CSV表格数据无效");
                }

                if ((xMinIsValid && xMinDefine > xMin) || !xMinIsValid)
                {
                    txtXMin.Text = xMin.ToString();
                    xMinDefine = xMin;
                }

                if ((xMaxIsValid && xMaxDefine < xMax) || !xMaxIsValid)
                {
                    txtXMax.Text = xMax.ToString();
                    xMaxDefine = xMax;
                }

                Color start = cpStart.Value;
                Color end = cpEnd.Value;
                Color[] colors = start.GradientColors(end, (int)nudCount.Value);
                List<ChartDatas> charts = new List<ChartDatas>();
                int index = 0;
                foreach (var item in chartDatas)
                {
                    int mode = index++ % (int)nudCount.Value;
                    charts.Add(new ChartDatas
                    {
                        Name = item.Key,
                        ChartType = SeriesChartType.Spline,
                        ChartColor = colors[mode],
                        IsValueShownAsLabel = false,
                    });
                }

                CustomChart.InitChart(ref chart1, charts, xMaxDefine, xMinDefine, 0.5, DateTimeIntervalType.Number, "0.00", null, false, "Distance(mm)", "Force(N)", "0.0");

                index = 0;
                foreach (var item in chartDatas.Values)
                {
                    foreach (var dic in item)
                    {
                        chart1.Series[index].Points.AddXY(dic.Key, dic.Value);
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog($"InitChart失败：{ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = "";
            if (!FileHelper.SaveFileDialogMethod("", Interfaces.FilterType.ALL, Interfaces.DefaultExt.ALL, true, false, false, ref path))
            {
                return;
            }

            chart1.SaveImage(path, ChartImageFormat.Bmp);
        }
    }
}
