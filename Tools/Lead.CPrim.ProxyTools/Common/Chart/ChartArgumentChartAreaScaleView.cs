using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 轴的缩放视图
    /// </summary>
    public class ChartArgumentChartAreaScaleView
    {
        /// <summary>
        /// true如果启用了缩放用户界面;否则为false。<br/>
        /// 默认值：true<br/>
        /// </summary>
        public bool Zoomable { get; set; }



        public ChartArgumentChartAreaScaleView()
        {
            Zoomable = true;
        }
    }
}
