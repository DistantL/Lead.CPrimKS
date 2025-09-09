using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 动画标志
    /// </summary>
    [Flags]
    public enum AnimationFlags
    {
        /// <summary>
        /// 常数：1<br/>
        /// 自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略<br/>
        /// </summary>
        AW_HOR_POSITIVE = 0x00000001,

        /// <summary>
        /// 常数：2<br/>
        /// 自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略<br/>
        /// </summary>
        AW_HOR_NEGATIVE = 0x00000002,

        /// <summary>
        /// 常数：4<br/>
        /// 自上向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略<br/>
        /// </summary>
        AW_VER_POSITIVE = 0x00000004,

        /// <summary>
        /// 常数：8<br/>
        /// 自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略<br/>
        /// </summary>
        AW_VER_NEGATIVE = 0x00000008,

        /// <summary>
        /// 常数：16<br/>
        /// 若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展<br/>
        /// </summary>
        AW_CENTER = 0x00000010,

        /// <summary>
        /// 常数：65536<br/>
        /// 隐藏窗口，缺省则显示窗口<br/>
        /// </summary>
        AW_HIDE = 0x00010000,

        /// <summary>
        /// 常数：131072<br/>
        /// 激活窗口。在使用AW_HIDE标志后不要使用这个标志<br/>
        /// </summary>
        AW_ACTIVE = 0x00020000,

        /// <summary>
        /// 常数：262144<br/>
        /// 使用滑动类型。默认则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略<br/>
        /// </summary>
        AW_SLIDE = 0x00040000,

        /// <summary>
        /// 常数：524288<br/>
        /// 使用淡出效果。只有当hwnd为顶层窗口的时候才可以使用这个标志<br/>
        /// </summary>
        AW_BLEND = 0x00080000,
    }
}
