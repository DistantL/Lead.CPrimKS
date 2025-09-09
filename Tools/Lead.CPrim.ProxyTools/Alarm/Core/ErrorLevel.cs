using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public enum ErrorLevel
    {
        /// <summary>
        /// DT状态<br/>
        /// 机台暂停<br/>
        /// 红灯常亮、蜂鸣器闪烁<br/>
        /// 需要机台复位<br/>
        /// 急停、轴类重大故障、机械手故障、软件类需要初始化<br/>
        /// </summary>
        一级报警 = 1,

        /// <summary>
        /// DT状态<br/>
        /// 机台暂停<br/>
        /// 红灯常亮、蜂鸣器闪烁<br/>
        /// 需要清除报警可继续<br/>
        /// </summary>
        二级报警 = 2,

        /// <summary>
        /// Running状态<br/>
        /// 机台暂停<br/>
        /// 绿灯常亮、黄灯闪烁、蜂鸣器闪烁<br/>
        /// 需要清除报警可继续<br/>
        /// </summary>
        三级报警 = 4,
    }
}
