using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 报警类型<br/>
    /// 报警、某个弹窗<br/>
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// 普通报警
        /// </summary>
        Alarm,

        /// <summary>
        /// UIMessageForm弹窗
        /// </summary>
        DialogForUIMessageForm,
    }
}
