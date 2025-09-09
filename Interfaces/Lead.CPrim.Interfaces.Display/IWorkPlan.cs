using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Display
{
    /// <summary>工单记录表（用户接口）</summary>
    public interface IWorkPlan
    {
        /// <summary>OK加一</summary>
        void OKIncrease();
        /// <summary>NG加一</summary>
        void NGIncrease();
    }
}
