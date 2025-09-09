/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: Notification.cs
 * Author: Victor
 * Description: 弹窗帮助类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230109>
 * 初版1.0
******************************************************************************/

using Lead.CPrim.MsgForm;
using System.Drawing;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>弹窗帮助类</summary>
    public class Notification
    {
        /// <summary>提示弹窗（默认显示2s）</summary>
        /// <param name="infotext">消息</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void ShowInfo(string infotext, int floor = 0)
        {
            Show(infotext, Color.Blue, 2000, floor);
        }
        /// <summary>警告弹窗（默认显示3s）</summary>
        /// <param name="infotext">消息</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void ShowWarn(string infotext, int floor = 0)
        {
            Show(infotext, Color.OrangeRed, 3000, floor);
        }
        /// <summary>失败弹窗（默认一直显示）</summary>
        /// <param name="infotext">消息</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void ShowError(string infotext, int floor = 0)
        {
            Show(infotext, Color.Red, 0, floor);
        }
        /// <summary>弹窗（消息+颜色+时间）</summary>
        /// <param name="infotext">消息</param>
        /// <param name="color">颜色</param>
        /// <param name="tims">时间</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void Show(string infotext, Color color, int tims = 0, int floor = 0)
        {
            MessageFrm.Show(infotext, color, tims, floor);
        }
    }
}
