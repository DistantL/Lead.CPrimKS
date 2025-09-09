using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    #region 螺丝信息（与XYD线程交互）

    public class InteractiveScrewInfo
    {
        /// <summary>
        /// 产品SN
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 载具SN
        /// </summary>
        public string UCSN { get; set; }
        /// <summary>
        /// 锁螺丝位置
        /// </summary>
        public int PosNo { get; set; }
        /// <summary>
        /// 复锁次数
        /// </summary>
        public int ScrewNo { get; set; }

        public bool SendDataToTCM { get; set; }
    }

    #endregion
}
