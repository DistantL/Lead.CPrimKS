using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.Win32;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public class DynamicUIShow
    {
        #region Field
        /// <summary>
        /// 常数：1<br/>
        /// 自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略<br/>
        /// </summary>
        private const int AW_HOR_POSITIVE = 0x00000001;

        /// <summary>
        /// 常数：2<br/>
        /// 自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略<br/>
        /// </summary>
        private const int AW_HOR_NEGATIVE = 0x00000002;

        /// <summary>
        /// 常数：4<br/>
        /// 自上向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略<br/>
        /// </summary>
        private const int AW_VER_POSITIVE = 0x00000004;

        /// <summary>
        /// 常数：8<br/>
        /// 自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略<br/>
        /// </summary>
        private const int AW_VER_NEGATIVE = 0x00000008;

        /// <summary>
        /// 常数：16<br/>
        /// 若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展<br/>
        /// </summary>
        private const int AW_CENTER = 0x00000010;

        /// <summary>
        /// 常数：65536<br/>
        /// 隐藏窗口，缺省则显示窗口<br/>
        /// </summary>
        private const int AW_HIDE = 0x00010000;

        /// <summary>
        /// 常数：131072<br/>
        /// 激活窗口。在使用AW_HIDE标志后不要使用这个标志<br/>
        /// </summary>
        private const int AW_ACTIVE = 0x00020000;

        /// <summary>
        /// 常数：262144<br/>
        /// 使用滑动类型。默认则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略<br/>
        /// </summary>
        private const int AW_SLIDE = 0x00040000;

        /// <summary>
        /// 常数：524288<br/>
        /// 使用淡出效果。只有当hwnd为顶层窗口的时候才可以使用这个标志<br/>
        /// </summary>
        private const int AW_BLEND = 0x00080000;
        #endregion



        #region Method_ExternalUsing
        public static void Show(Form frm, FormShowAlignment alignment, Padding padding)
        {
            int x;
            int y;
            AnimationFlags flags;

            RECT rect = new RECT();
            Form findFrm = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "MainForm")
                {
                    findFrm = item;
                    break;
                }
            }

            if (findFrm != null)
            {
                User.GetWindowRect(findFrm.Handle, ref rect);
            }
            else
            {
                rect.Left = Screen.PrimaryScreen.WorkingArea.Left;
                rect.Top = Screen.PrimaryScreen.WorkingArea.Top;
                rect.Right = Screen.PrimaryScreen.WorkingArea.Right;
                rect.Bottom = Screen.PrimaryScreen.WorkingArea.Bottom;
            }

            switch (alignment)
            {
                case FormShowAlignment.LeftTop:
                    x = rect.Left + padding.Left;
                    y = rect.Top + padding.Top;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_HOR_POSITIVE;
                    break;

                case FormShowAlignment.LeftCenter:
                    x = rect.Left + padding.Left;
                    y = rect.Top + (rect.Bottom - rect.Top - frm.Height) / 2;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_HOR_POSITIVE;
                    break;

                case FormShowAlignment.LeftBottom:
                    x = rect.Left + padding.Left;
                    y = (rect.Bottom - frm.Height) - padding.Bottom;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_HOR_POSITIVE;
                    break;

                case FormShowAlignment.TopLeft:
                    x = rect.Left + padding.Left;
                    y = rect.Top + padding.Top;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_VER_POSITIVE;
                    break;

                case FormShowAlignment.TopCenter:
                    x = rect.Left + (rect.Right - rect.Left - frm.Width) / 2;
                    y = rect.Top + padding.Top;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_VER_POSITIVE;
                    break;

                case FormShowAlignment.TopRight:
                    x = rect.Right - frm.Width - padding.Right;
                    y = rect.Top + padding.Top;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_VER_POSITIVE;
                    break;

                case FormShowAlignment.RightTop:
                    x = rect.Right - frm.Width - padding.Right;
                    y = rect.Top + padding.Top;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_HOR_NEGATIVE;
                    break;

                case FormShowAlignment.RightCenter:
                    x = rect.Right - frm.Width - padding.Right;
                    y = rect.Top + (rect.Bottom - rect.Top - frm.Height) / 2;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_HOR_NEGATIVE;
                    break;

                case FormShowAlignment.RightBottom:
                    x = rect.Right - frm.Width - padding.Right;
                    y = (rect.Bottom - frm.Height) - padding.Bottom;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_HOR_NEGATIVE;
                    break;

                case FormShowAlignment.BottomLeft:
                    x = rect.Left + padding.Left;
                    y = (rect.Bottom - frm.Height) - padding.Bottom;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_VER_NEGATIVE;
                    break;

                case FormShowAlignment.BottomCenter:
                    x = rect.Left + (rect.Right - rect.Left - frm.Width) / 2;
                    y = (rect.Bottom - frm.Height) - padding.Bottom;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_VER_NEGATIVE;
                    break;

                case FormShowAlignment.BottomRight:
                    x = rect.Right - frm.Width - padding.Right;
                    y = (rect.Bottom - frm.Height) - padding.Bottom;
                    flags = AnimationFlags.AW_SLIDE | AnimationFlags.AW_VER_NEGATIVE;
                    break;

                default:
                    return;
            }

            frm.Location = new Point(x, y);
             User.AnimateWindow(frm.Handle, 300, (int)flags);
        }
        #endregion
    }
}
