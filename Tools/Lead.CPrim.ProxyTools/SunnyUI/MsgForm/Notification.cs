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

using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.CustomControl;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 弹窗帮助类
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// 提示弹窗<br/>
        /// 默认显示5s
        /// </summary>
        /// <param name="infotext">消息</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void ShowInfo(string infotext, int floor = 0)
        {
            Show(infotext, UINotifierType.OK, 5000, floor);
        }

        /// <summary>
        /// 警告弹窗<br/>
        /// 默认显示5s
        /// </summary>
        /// <param name="infotext">消息</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void ShowWarn(string infotext, int floor = 0)
        {
            Show(infotext, UINotifierType.WARNING, 5000, floor);
        }

        /// <summary>
        /// 失败弹窗<br/>
        /// 默认显示5s
        /// </summary>
        /// <param name="infotext">消息</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void ShowError(string infotext, int floor = 0)
        {
            Show(infotext, UINotifierType.ERROR, 5000, floor);
        }

        /// <summary>
        /// 弹窗（消息+颜色+时间）
        /// </summary>
        /// <param name="infotext">消息</param>
        /// <param name="type">颜色</param>
        /// <param name="tims">时间</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void Show(string infotext, UINotifierType type, int tims = 0, int floor = 0)
        {
            if (floor != 0)
            {
                DataHelper.GetNamespaceClassMethodName(ref infotext, 3);
            }

            Application.OpenForms[0].BeginInvoke(new Action<string, UINotifierType, int, int>(ShowEventHandle), new object[] { infotext, type, tims, floor });
        }

        /// <summary>
        /// 以委托形式显示UI
        /// </summary>
        /// <param name="infotext"></param>
        /// <param name="type"></param>
        /// <param name="tims"></param>
        /// <param name="floor"></param>
        private static void ShowEventHandle(string infotext, UINotifierType type, int tims = 0, int floor = 0)
        {
            MessageFrm frm = new MessageFrm(infotext, type, tims);
            frm.Show();
        }
    }
}
