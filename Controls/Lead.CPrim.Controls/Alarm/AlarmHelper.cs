using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.Controls
{
    public class AlarmHelper
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="level"></param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public static void LogAdd(string msg, LogLevel level, bool isShowDialog = false)
        {
            LogHelper.LogAdd(level, msg, nameof(AlarmHelper), LogClassification.Other);

            if (isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
    }
}
