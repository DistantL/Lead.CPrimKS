using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces
{
    public enum 运行模式
    {
        正常生产 = 0,
        空运行模式带载具,
        空运行模式不带载具,
        点检模式,
        轴精度模式,
        CCD动静态模式,
        标定模式,
        单流程模式,
        直通模式,
        Other
    }
}
