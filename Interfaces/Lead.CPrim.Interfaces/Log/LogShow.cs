using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    /// 防止相同LOG频繁写入
    /// </summary>
    public class LogShow
    {
        /// <summary>
        /// 写入时间
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
    }
}
