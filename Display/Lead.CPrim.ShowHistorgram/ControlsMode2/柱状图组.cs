using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.Proxy
{
    public partial class 柱状图组 : UserControl
    {
        #region Field
        Dictionary<string, 单项柱状图> dic柱状图组 = new Dictionary<string, 单项柱状图>();
        private static readonly object objChart = new object();
        #endregion



        #region Ctor
        public 柱状图组()
        {
            InitializeComponent();
        }
        #endregion



        #region Button_Event
        /// <summary>柱状图清除</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            flpChart.Controls.Clear();
            dic柱状图组.Clear();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>柱状图显示</summary>
        /// <param name="faiName">FAI名称</param>
        /// <param name="limitMin">下限</param>
        /// <param name="limitNormal">标准值</param>
        /// <param name="limitMax">上限</param>
        /// <param name="value">FAI值</param>
        public void Update柱状图(string faiName, double limitMin, double limitNormal, double limitMax, double value)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action<string, double, double, double, double>(Update柱状图), new object[5] { faiName, limitMin, limitNormal, limitMax, value });
                return;
            }
            lock (objChart)
            {
                flpChart.SuspendLayout();
                if (!dic柱状图组.ContainsKey(faiName))
                {
                    var x = new 单项柱状图(faiName, limitNormal, limitMin, limitMax);
                    x.Dock = DockStyle.Top;
                    x.ChartDataRefresh(value);
                    x.ChartRefresh();
                    x.Show();
                    dic柱状图组.Add(faiName, x);
                    flpChart.Controls.Add(x);
                }
                else
                {
                    dic柱状图组[faiName].ChartDataRefresh(value);
                    dic柱状图组[faiName].ChartRefresh();
                }
                flpChart.ResumeLayout(true);
            }
        }
        #endregion
    }
}
