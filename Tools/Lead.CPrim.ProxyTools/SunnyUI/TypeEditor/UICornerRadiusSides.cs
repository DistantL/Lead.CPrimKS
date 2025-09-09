using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 圆角位置
    /// </summary>
    [ComVisible(true)]
    [ToolboxItem(false)]
    [Editor("Lead.CPrim.ProxyTools.UIRadiusSidesEditor, " + AssemblyRefEx.SystemDesign, typeof(UITypeEditor))]
    [Flags]
    public enum UICornerRadiusSides
    {
        /// <summary>四个角都有圆角</summary>
        All = 15,
        /// <summary>左下角有圆角</summary>
        LeftBottom = 8,
        /// <summary>右下角有圆角</summary>
        RightBottom = 4,
        /// <summary>右上角有圆角</summary>
        RightTop = 2,
        /// <summary>左上角有圆角</summary>
        LeftTop = 1,
        /// <summary>没有圆角</summary>
        None = 0,
    }
}
