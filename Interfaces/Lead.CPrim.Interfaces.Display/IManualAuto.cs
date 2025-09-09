using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Display
{
    /// <summary>手自动接口</summary>
    public interface IManualAuto
    {
        /// <summary>手自动</summary>
        /// <param name="enable">自动：false；手动：true；</param>
        void EnableHandle(bool enable);
    }
}
