using Lead.CPrim.Interfaces.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.MachineHelper
{
    public class UserMsg
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public PriorityLevel Level { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string MessageString { get; set; }



        public UserMsg(string msg, PriorityLevel level)
        {
            MessageString = msg;
            Level = level;
            EventTime = DateTime.Now;
        }
    }
}
