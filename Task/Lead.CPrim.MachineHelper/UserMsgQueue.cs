using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.MachineHelper
{
    public class UserMsgQueue
    {
        private UserMsg _userMsg;

        public string GetMesg(UserMsg msg)
        {
            if (_userMsg == null)
            {
                _userMsg = msg;
            }
            else
            {
                double msCount = (msg.EventTime - _userMsg.EventTime).TotalMilliseconds;
                if (Math.Abs(msCount) > 500.0)
                {
                    _userMsg = msg;
                }
                else if (_userMsg.Level <= msg.Level && msCount > 0.0)
                {
                    _userMsg = msg;
                }
            }
            return _userMsg.MessageString;
        }
    }
}
