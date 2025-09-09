/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: DoubleBufferedHelper.cs
 * Author: Victor
 * Description: 用来将控件设置为双缓存
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0712><Victor><20220722>    
 * 1、将双缓存帮助类封装为扩展方法
 * 
 * <3.3.22.1017><Victor><20221026>    
 * 1、DataGridView、FlowLayoutPanel、TableLayoutPanel、SplitContainer均继承于Control，直接使用Control进行双缓存封装
******************************************************************************/

using Lead.CPrim.Interfaces;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 双缓存
    /// </summary>
    public static class DoubleBufferedHelper
    {
        /// <summary>
        /// Control控件设置双缓存
        /// </summary>
        /// <param name="control">Control</param>
        /// <returns></returns>
        public static bool SetDoubleBuffered(this Control control)
        {
            try
            {
                Type dgvType = control.GetType();
                PropertyInfo properInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                properInfo.SetValue(control, true, null);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"Control双缓存设置失败 -> {ex.Message}", PrimLogId.Tool.ToString());
                return false;
            }
        }
    }
}
