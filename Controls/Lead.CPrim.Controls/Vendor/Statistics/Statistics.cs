using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Controls
{
    internal class Statistics
    {
        /// <summary>
        /// 报警次数
        /// </summary>
        public int LimitCount { get; set; } = 9999;

        /// <summary>
        /// 一级名称
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string LastClearTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 二级名称
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// 使用次数
        /// </summary>
        public int UsedCount { get; set; }

        /// <summary>
        /// 警告次数
        /// </summary>
        public int WarnCount { get; set; } = 8888;
    }
}
