using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Controls
{
    public class ControlsHelper
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="level"></param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public static void LogAdd(string msg, LogLevel level, bool isShowDialog = false)
        {
            LogHelper.LogAdd(level, msg, PrimLogId.Controls.ToString(), LogClassification.Other);

            if (isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
    }
}
