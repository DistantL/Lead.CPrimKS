/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowOutputControl.cs
 * Author: Victor
 * Description: 压力曲线基元output界面
 * CreateTime: 2021-09-28
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 3.3.22.0904 -> 
 * <Author> (Victor)    <Time> (20220913)
 * 1、继承变更为UIUserControl
******************************************************************************/

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lead.CPrim.PressureCurve.Controls
{
    public partial class ShowOutputControl : UIUserControl
    {
        #region Field
        /// <summary>压力曲线配置管理器</summary>
        public ShowPressureCurve _show;
        /// <summary>压力曲线初始化数据</summary>
        private List<ChartData> datas = new List<ChartData>();
        /// <summary>曲线1压力值集合</summary>
        private List<float> listPressValue1 = new List<float>();
        /// <summary>曲线2压力值集合</summary>
        private List<float> listPressValue2 = new List<float>();
        /// <summary>曲线3压力值集合</summary>
        private List<float> listPressValue3 = new List<float>();
        /// <summary>曲线4压力值集合</summary>
        private List<float> listPressValue4 = new List<float>();
        #endregion



        #region Ctor
        /// <summary>Ctro无参</summary>
        public ShowOutputControl()
        {
            InitializeComponent();
            SetStyleFlags();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="show"></param>
        public ShowOutputControl(ShowPressureCurve show) : this()
        {
            _show = show;

            datas.Add(new ChartData() { Name = _show.PressName1, color = Color.DarkBlue });
            new DynamicChart().InitChart(chart1, datas, _show.PressName1);
            datas.Clear();
            datas.Add(new ChartData() { Name = _show.PressName2, color = Color.DarkBlue });
            new DynamicChart().InitChart(chart2, datas, _show.PressName2);
            datas.Clear();
            datas.Add(new ChartData() { Name = _show.PressName3, color = Color.DarkBlue });
            new DynamicChart().InitChart(chart3, datas, _show.PressName3);
            datas.Clear();
            datas.Add(new ChartData() { Name = _show.PressName4, color = Color.DarkBlue });
            new DynamicChart().InitChart(chart4, datas, _show.PressName4);
        }
        #endregion



        #region System_Event
        private void ShowOutputControl_Load(object sender, EventArgs e)
        {
            tlpLeftUpMain.Visible = false;
            tlpRightUpMain.Visible = false;
            tlpLeftDownMain.Visible = false;
            tlpRightDownMain.Visible = false;
            LeftUpVisible(_show.PressVisible1);
            RightUpVisible(_show.PressVisible2);
            LeftDownVisible(_show.PressVisible3);
            RightDownVisible(_show.PressVisible4);
        }
        #endregion



        #region 左上
        /// <summary>左上启动</summary>
        private void btnLeftUpStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                if (chart1.Series[0].Points.Count >= 0)
                {
                    chart1.Series[0].Points.Clear();
                }
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                listPressValue1.Clear();
                timer1.Enabled = true;
            }
        }
        /// <summary>左上停止</summary>
        private void btnLeftUpStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        /// <summary>左上清除</summary>
        private void btnLeftUpClear_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }

            chart1.Series[0].Points.Clear();
            listPressValue1.Clear();
        }
        #endregion



        #region 右上
        /// <summary>右上启动</summary>
        private void btnRightUpStart_Click(object sender, EventArgs e)
        {
            if (!timer2.Enabled)
            {
                if (chart2.Series[0].Points.Count >= 0)
                {
                    chart2.Series[0].Points.Clear();
                }
                chart2.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                listPressValue2.Clear();
                timer2.Enabled = true;
            }
        }
        /// <summary>右上停止</summary>
        private void btnRightUpStop_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }
        /// <summary>右上清除</summary>
        private void btnRightUpClear_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                timer2.Enabled = false;
            }

            chart2.Series[0].Points.Clear();
            listPressValue2.Clear();
        }
        #endregion



        #region 左下
        /// <summary>左下开始</summary>
        private void btnLeftDownStart_Click(object sender, EventArgs e)
        {
            if (!timer3.Enabled)
            {
                if (chart3.Series[0].Points.Count >= 0)
                {
                    chart3.Series[0].Points.Clear();
                }
                chart3.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                listPressValue3.Clear();
                timer3.Enabled = true;
            }
        }
        /// <summary>左下停止</summary>
        private void btnLeftDownStop_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
        }
        /// <summary>左下清除</summary>
        private void btnLeftDownClear_Click(object sender, EventArgs e)
        {
            if (timer3.Enabled)
            {
                timer3.Enabled = false;
            }

            chart3.Series[0].Points.Clear();
            listPressValue3.Clear();
        }
        #endregion



        #region 右下
        /// <summary>右下开始</summary>
        private void btnRightDownStart_Click(object sender, EventArgs e)
        {
            if (!timer4.Enabled)
            {
                if (chart4.Series[0].Points.Count >= 0)
                {
                    chart4.Series[0].Points.Clear();
                }
                chart4.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                listPressValue4.Clear();
                timer4.Enabled = true;
            }
        }
        /// <summary>右下停止</summary>
        private void btnRightDownStop_Click(object sender, EventArgs e)
        {
            timer4.Enabled = false;
        }
        /// <summary>右下清除</summary>
        private void btnRightDownClear_Click(object sender, EventArgs e)
        {
            if (timer4.Enabled)
            {
                timer4.Enabled = false;
            }

            chart4.Series[0].Points.Clear();
            listPressValue4.Clear();
        }
        #endregion



        #region 定时器
        /// <summary>压力曲线1</summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // 添加数据
                for (int i = 0; i < 1; i++)
                {
                    float temp = GetAi(_show.PressName1);
                    this.chart1.Series[i].Points.AddXY(DateTime.Now.ToOADate(), temp);
                    listPressValue1.Add(temp);
                }

                // X坐标后移1秒
                this.chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();

                if (cbLeftUpHistory.Checked == true)
                    chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>压力曲线2</summary>
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                // 添加数据
                for (int i = 0; i < 1; i++)
                {
                    float temp = GetAi(_show.PressName2);
                    this.chart2.Series[i].Points.AddXY(DateTime.Now.ToOADate(), temp);
                    listPressValue2.Add(temp);
                }

                // X坐标后移1秒
                this.chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();

                if (cbRightUpHistory.Checked == true)
                    chart2.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>压力曲线3</summary>
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                // 添加数据
                for (int i = 0; i < 1; i++)
                {
                    float temp = GetAi(_show.PressName3);
                    this.chart3.Series[i].Points.AddXY(DateTime.Now.ToOADate(), temp);
                    listPressValue3.Add(temp);
                }

                // X坐标后移1秒
                this.chart3.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();

                if (cbLeftDownHistory.Checked == true)
                    chart3.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>压力曲线4</summary>
        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                // 添加数据
                for (int i = 0; i < 1; i++)
                {
                    float temp = GetAi(_show.PressName3);
                    this.chart4.Series[i].Points.AddXY(DateTime.Now.ToOADate(), temp);
                    listPressValue4.Add(temp);
                }

                // X坐标后移1秒
                this.chart4.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(1).ToOADate();

                if (cbRightDownHistory.Checked == true)
                    chart4.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();//此刻后10分钟作为最初X轴，
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>曲线1是否显示</summary>
        /// <param name="value">bool</param>
        public void LeftUpVisible(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(LeftUpVisible), value);
                return;
            }

            tlpLeftUpMain.Visible = value;
        }
        /// <summary>曲线2是否显示</summary>
        /// <param name="value">bool</param>
        public void RightUpVisible(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(RightUpVisible), value);
                return;
            }

            tlpRightUpMain.Visible = value;
        }
        /// <summary>曲线3是否显示</summary>
        /// <param name="value">bool</param>
        public void LeftDownVisible(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(LeftDownVisible), value);
                return;
            }

            tlpLeftDownMain.Visible = value;
        }
        /// <summary>曲线=4是否显示</summary>
        /// <param name="value">bool</param>
        public void RightDownVisible(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(RightDownVisible), value);
                return;
            }

            tlpRightDownMain.Visible = value;
        }
        /// <summary>曲线1名称更新</summary>
        /// <param name="name">名称</param>
        public void ChartNameUpdate1(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ChartNameUpdate1), name);
                return;
            }

            chart1.Titles[0].Text = name;
            chart1.Series[0].Name = name;
        }
        /// <summary>曲线2名称更新</summary>
        /// <param name="name">名称</param>
        public void ChartNameUpdate2(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ChartNameUpdate2), name);
                return;
            }

            chart2.Titles[0].Text = name;
            chart2.Series[0].Name = name;
        }
        /// <summary>曲线3名称更新</summary>
        /// <param name="name">名称</param>
        public void ChartNameUpdate3(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ChartNameUpdate3), name);
                return;
            }

            chart3.Titles[0].Text = name;
            chart3.Series[0].Name = name;
        }
        /// <summary>曲线4名称更新</summary>
        /// <param name="name">名称</param>
        public void ChartNameUpdate4(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(ChartNameUpdate4), name);
                return;
            }

            chart4.Titles[0].Text = name;
            chart4.Series[0].Name = name;
        }

        /// <summary>开始采集</summary>
        /// <param name="id">id</param>
        /// <param name="SN">二维码</param>
        public int Start(int id, string SN)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Func<int, string, int>(Start), id, SN);
                return 0;
            }
            if (id == _show._config.ID1)
            {
                btnLeftUpClear_Click(null, null);
                btnLeftUpStart_Click(null, null);
                chart1.Titles[0].Text = SN;
                return 0;
            }
            else if (id == _show._config.ID2)
            {
                btnRightUpClear_Click(null, null);
                btnRightUpStart_Click(null, null);
                chart2.Titles[0].Text = SN;
                return 0;
            }
            else if (id == _show._config.ID3)
            {
                btnLeftDownClear_Click(null, null);
                btnLeftDownStart_Click(null, null);
                chart3.Titles[0].Text = SN;
                return 0;
            }
            else if (id == _show._config.ID4)
            {
                btnRightDownClear_Click(null, null);
                btnRightDownStart_Click(null, null);
                chart4.Titles[0].Text = SN;
                return 0;
            }
            return -1;
        }
        /// <summary>停止采集</summary>
        /// <param name="id">id</param>
        /// <param name="SN">二维码</param>
        public int Stop(int id, string SN)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Func<int, string, int>(Stop), id, SN);
                return 0;
            }
            if (id == _show._config.ID1)
            {
                btnLeftUpStop_Click(null, null);

                SavePng(SN, chart1);
                return 0;
            }
            else if (id == _show._config.ID2)
            {
                btnRightUpStop_Click(null, null);

                SavePng(SN, chart2);
                return 0;
            }
            else if (id == _show._config.ID3)
            {
                btnLeftDownStop_Click(null, null);

                SavePng(SN, chart3);
                return 0;
            }
            else if (id == _show._config.ID4)
            {
                btnRightDownStop_Click(null, null);

                SavePng(SN, chart4);
                return 0;
            }
            return -1;
        }
        /// <summary>获取压力值</summary>
        /// <param name="id">id</param>
        /// <param name="SN">二维码</param>
        public float GetPress(int id)
        {
            if (id == _show._config.ID1)
            {
                return GetListMidValue(listPressValue1);
            }
            else if (id == _show._config.ID2)
            {
                return GetListMidValue(listPressValue2);
            }
            else if (id == _show._config.ID3)
            {
                return GetListMidValue(listPressValue3);
            }
            else if (id == _show._config.ID4)
            {
                return GetListMidValue(listPressValue4);
            }

            return 0;
        }
        /// <summary>手自动传递</summary>
        /// <param name="value"></param>
        public void EnableHandle(bool value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(EnableHandle), value);
                return;
            }
            btnLeftUpStart.Enabled = value;
            btnLeftUpStop.Enabled = value;
            btnLeftUpClear.Enabled = value;
            cbLeftUpHistory.Enabled = value;

            btnRightUpStart.Enabled = value;
            btnRightUpStop.Enabled = value;
            btnRightUpClear.Enabled = value;
            cbRightUpHistory.Enabled = value;

            btnLeftDownStart.Enabled = value;
            btnLeftDownStop.Enabled = value;
            btnLeftDownClear.Enabled = value;
            cbLeftDownHistory.Enabled = value;

            btnRightDownStart.Enabled = value;
            btnRightDownStop.Enabled = value;
            btnRightDownClear.Enabled = value;
            cbRightDownHistory.Enabled = value;

            if (!value)
            {
                cbLeftUpHistory.Checked = false;
                cbRightUpHistory.Checked = false;
                cbLeftDownHistory.Checked = false;
                cbRightDownHistory.Checked = false;
            }
        }
        #endregion



        #region Others
        private ConcurrentDictionary<string, IEleAD> AiDictionary = new ConcurrentDictionary<string, IEleAD>();
        /// <summary>
        /// 获取输入状态新
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        private float GetAi(string ai)
        {
            try
            {
                if (!AiDictionary.ContainsKey(ai))
                {
                    IEle _elet = ElesManagerTransfer.GetEleByName(ai.ToString());
                    if (_elet == null)
                    {
                        throw new Exception(string.Format("模拟量输入信号={0} 未配置", ai.ToString()));
                    }
                    IEleAD _ai = (IEleAD)_elet;
                    AiDictionary.TryAdd(ai, _ai);

                    _elet.IEleInit();
                }
                ((IEle)AiDictionary[ai.ToString()]).IEleUiRefresh();
                return AiDictionary[ai.ToString()].ActValue;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>保存图片</summary>
        /// <param name="sn">二维码</param>
        /// <param name="chart">图表</param>
        private void SavePng(string sn, Chart chart)
        {
            try
            {
                string path;
                if (!string.IsNullOrEmpty(sn))
                {
                    chart.Titles[0].Text = sn;
                }
                if (string.IsNullOrEmpty(_show.ImagePath))
                {
                    path = @"D:\CPrimlog\" + DateTime.Now.ToString("yyyyMMdd") + @"\";
                }
                else
                {
                    path = _show.ImagePath + @"\" + DateTime.Now.ToString("yyyyMMdd") + @"\";
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Thread.Sleep(150);
                chart.SaveImage(path + sn + "_" + DateTime.Now.ToString("HHmmss") + @".Png", ChartImageFormat.Png);
            }
            catch (Exception ex)
            {
                _show.LogAdd($"保存图片失败：{ex.Message}", LogLevel.Warn);
            }
        }
        /// <summary>求List(float)中值</summary>
        /// <param name="l">List(float)</param>
        /// <returns>float</returns>
        private float GetListMidValue(List<float> l)
        {
            List<float> listTemp = new List<float>();
            l.ForEach(f =>
            {
                if (Math.Abs(f) >= 0.1)
                {
                    listTemp.Add(f);
                }
            });

            if (listTemp.Count == 0)
            {
                return 0;
            }

            listTemp.Sort();
            return listTemp[listTemp.Count / 2];
        }
        #endregion



        #region Test
        /// <summary>模块测试</summary>
        public void Test()
        {
            DateTime now = DateTime.Now;
            chart1.ChartAreas[0].AxisX.Minimum = now.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(10).ToOADate();
            for (int i = 0; i < 10; i++)
            {
                chart1.Series[0].Points.AddXY(now.AddSeconds(i).ToOADate(), i / 2.0);
            }
            string path = @"D:\123.bmp";
            chart1.SaveImage(path, ChartImageFormat.Bmp);
        }
        #endregion
    }
}
