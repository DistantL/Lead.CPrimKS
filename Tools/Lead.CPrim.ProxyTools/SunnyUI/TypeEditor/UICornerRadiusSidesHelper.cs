using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 圆角位置/边框属性编辑器帮助类
    /// </summary>
    public static class UICornerRadiusSidesHelper
    {
        /// <summary>
        /// 获取圆角是否设置
        /// </summary>
        /// <param name="sides">所有圆角</param>
        /// <param name="side">当前圆角</param>
        /// <returns>是否有当前圆角</returns>
        public static bool GetValue(this UICornerRadiusSides sides, UICornerRadiusSides side)
        {
            return (sides & side) == side;
        }

        /// <summary>
        /// 获取边框是否设置
        /// </summary>
        /// <param name="sides">所有边框</param>
        /// <param name="side">当前边框</param>
        /// <returns>是否有当前边框</returns>
        public static bool GetValue(this ToolStripStatusLabelBorderSides sides, ToolStripStatusLabelBorderSides side)
        {
            return (sides & side) == side;
        }
    }
}
