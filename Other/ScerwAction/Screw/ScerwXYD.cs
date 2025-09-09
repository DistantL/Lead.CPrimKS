using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScerwActionHelper
{
    public class ScerwXYD
    {
        /// <summary>
        /// 螺丝枪名称
        /// </summary>
        public string ScrewName { get; private set; }
        /// <summary>
        /// 关联任务
        /// </summary>
        public ITask Task { get; private set; }

        /// <summary>
        /// 结果反馈输入IO名称
        /// </summary>
        public string Di_结果反馈 { get; private set; }
        /// <summary>
        /// 螺丝枪Busy信号输入IO名称
        /// </summary>
        public string Di_螺丝枪Busy { get; private set; }
        /// <summary>
        /// 螺丝枪启动输出IO名称
        /// </summary>
        public string Do_螺丝枪启动 { get; private set; }
        /// <summary>
        /// 螺丝枪自由转动输出IO名称   
        /// </summary>
        public string Do_螺丝枪自由转动 { get; private set; }
        /// <summary>
        /// 螺丝枪任务位输出IO名称数组[任务1，任务2，任务3，任务4]
        /// </summary>
        public string[] Do_螺丝枪任务位 { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="screwName">螺丝枪名称</param>
        /// <param name="task">关联任务</param>
        /// <param name="di_结果反馈">结果反馈输入IO名称</param>
        /// <param name="di_螺丝枪Busy">螺丝枪Busy信号输入IO名称</param>
        /// <param name="do_螺丝枪启动">螺丝枪启动输出IO名称</param>
        /// <param name="do_螺丝枪自由转动">螺丝枪自由转动输出IO名称 </param>
        /// <param name="do_螺丝枪任务位">螺丝枪任务位输出IO名称数组[任务1，任务2，任务3，任务4]</param>
        public ScerwXYD(string screwName, ITask task, string di_结果反馈, string di_螺丝枪Busy, string do_螺丝枪启动, string do_螺丝枪自由转动, string[] do_螺丝枪任务位)
        {
            this.ScrewName = screwName;
            Task = task;
            this.Di_结果反馈 = di_结果反馈;
            this.Di_螺丝枪Busy = di_螺丝枪Busy;
            this.Do_螺丝枪启动 = do_螺丝枪启动;
            this.Do_螺丝枪自由转动 = do_螺丝枪自由转动;
            this.Do_螺丝枪任务位 = do_螺丝枪任务位;
        }

    }
}
