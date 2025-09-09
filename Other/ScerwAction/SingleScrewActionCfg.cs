using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScerwActionHelper
{
    public class SingleScrewActionCfg
    {

        /// <summary>
        /// 插补表名称-对应工艺轴动作(对应任务需要轴运动才关联，不需要设为“”)
        /// </summary>
        public string StrInterpolationName { get; } = string.Empty;
        /// <summary>
        /// 打螺丝任务名称
        /// </summary>
        public string ScrewTaskName { get; }
        /// <summary>
        /// 螺丝编号
        /// </summary>
        public int ScrewIndex { get; }
        /// <summary>
        /// 螺丝枪对象
        /// </summary>
        public object Screwobject { get; }
        /// <summary>
        /// 螺丝枪任务位输出IO名称数组[任务1，任务2，任务3，任务4]
        /// </summary>
        public bool[] ScrewActionCmd { get; }
        /// <summary>
        /// 超时时间（ms）
        /// </summary>
        public int Timeout { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout">超时时间（ms）</param>
        /// <param name="screwobject">螺丝枪对象</param>
        /// <param name="screwTaskName">打螺丝任务名称</param>
        /// <param name="strInterpolationName">插补表名称-对应工艺轴动作(对应任务需要轴运动才关联，不需要设为“”)</param>
        /// <param name="screwIndex">螺丝编号</param>
        /// <param name="screwActionCmd">螺丝枪任务位输出IO名称数组[任务1，任务2，任务3，任务4]</param>
        public SingleScrewActionCfg(object screwobject, string screwTaskName, string strInterpolationName, int screwIndex, bool[] screwActionCmd,  int timeout)
        {
            StrInterpolationName = strInterpolationName;
            ScrewTaskName = screwTaskName;
            ScrewIndex = screwIndex;
            Screwobject = screwobject;
            ScrewActionCmd = screwActionCmd;     
            Timeout = timeout;
        }
    }
}
