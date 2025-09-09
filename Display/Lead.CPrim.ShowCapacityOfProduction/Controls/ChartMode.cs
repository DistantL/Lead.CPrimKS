using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Sunny.UI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lead.CPrim.ShowCapacityOfProduction.Controls
{
    public partial class ChartMode : UIPage
    {
        #region Field
        /// <summary>OK计数</summary>
        private Dictionary<int, int> dicOK = new Dictionary<int, int>();
        /// <summary>OK计数</summary>
        private Dictionary<int, int> dicNG = new Dictionary<int, int>();
        /// <summary>良率统计</summary>
        private Dictionary<int, double> dicRate = new Dictionary<int, double>();
        #endregion



        #region Ctor
        public ChartMode()
        {
            InitializeComponent();
            CustomChart.InitChartOKAndRate(chart1, "BY小时良率统计");
            DataInit();
        } 
        #endregion



        #region Method_ExternalUsing
        /// <summary>清除所有数据</summary>
        public void ClearData()
        {
            DataInit();
            ChartRefresh();
        }
        /// <summary>数据更新</summary>
        /// <param name="hour"></param>
        /// <param name="result"></param>
        public void DataProcessing(int hour, bool result)
        {
            if(result)
            {
                dicOK[hour]++;
            }
            else
            {
                dicNG[hour]++;
            }
            dicRate[hour] = (dicOK[hour] * 1.0) / (dicOK[hour] + dicNG[hour]);
            ChartRefresh();
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>图表数据初始化</summary>
        private void DataInit()
        {
            for (int i = 0; i < 24; i++)
            {
                if (dicOK.ContainsKey(i))
                {
                    dicOK[i] = 0;
                }
                else
                {
                    dicOK.Add(i, 0);
                }
                if (dicNG.ContainsKey(i))
                {
                    dicNG[i] = 0;
                }
                else
                {
                    dicNG.Add(i, 0);
                }
                if (dicRate.ContainsKey(i))
                {
                    dicRate[i] = 0;
                }
                else
                {
                    dicRate.Add(i, 0);
                }
            }
        }
        /// <summary>图表刷新</summary>
        private void ChartRefresh()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            for (int i = 0; i < 24; i++)
            {
                chart1.Series[0].Points.AddXY(i, dicOK[i]);
                chart1.Series[1].Points.AddXY(i, dicRate[i]);
            }
        }
        #endregion
    }
}
