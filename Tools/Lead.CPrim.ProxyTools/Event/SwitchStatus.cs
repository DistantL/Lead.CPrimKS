using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 切换状态机状态
    /// </summary>
    public enum SwitchStatus
    {
        ClrErr,
        Abnormal,
        RunningWithNotice,
        ESTOP,
    }
}
