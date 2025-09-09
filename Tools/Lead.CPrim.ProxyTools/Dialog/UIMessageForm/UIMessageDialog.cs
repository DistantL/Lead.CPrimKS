using Lead.CPrim.ProxyTools.CustomControl;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 对话框<br/>
    /// 主要针对UI
    /// </summary>
    public static class UIMessageDialog
    {
        //*****************************************************************************Form扩展
        /// <summary>
        /// Form扩展_正确对话框<br/>
        /// 按钮确认，标题正确，默认主题绿
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowSuccessDialog(this Form form, string msg, UIStyle style = UIStyle.Green)
        {
            form.ShowMessageDialog(msg, ULocalize.SuccessTitle, false, style);
        }

        /// <summary>
        /// Form扩展_正确对话框<br/>
        /// 按钮确认，标题自定义，默认主题绿
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowSuccessDialog(this Form form, string title, string msg, UIStyle style = UIStyle.Green)
        {
            form.ShowMessageDialog(msg, title, false, style);
        }

        /// <summary>
        /// Form扩展_消息对话框<br/>
        /// 按钮确认，标题提示，默认主题灰
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowInfoDialog(this Form form, string msg, UIStyle style = UIStyle.Gray)
        {
            form.ShowMessageDialog(msg, ULocalize.InfoTitle, false, style);
        }

        /// <summary>
        /// Form扩展_消息对话框<br/>
        /// 按钮确认，标题自定义，默认主题灰
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowInfoDialog(this Form form, string title, string msg, UIStyle style = UIStyle.Gray)
        {
            form.ShowMessageDialog(msg, title, false, style);
        }

        /// <summary>
        /// Form扩展_警告对话框<br/>
        /// 按钮确认，标题警告，默认主题橙
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowWarningDialog(this Form form, string msg, UIStyle style = UIStyle.Orange)
        {
            form.ShowMessageDialog(msg, ULocalize.WarningTitle, false, style);
        }

        /// <summary>
        /// Form扩展_警告对话框<br/>
        /// 按钮确认，标题自定义，默认主题橙
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowWarningDialog(this Form form, string title, string msg, UIStyle style = UIStyle.Orange)
        {
            form.ShowMessageDialog(msg, title, false, style);
        }

        /// <summary>
        /// Form扩展_错误对话框<br/>
        /// 按钮确认，标题错误，默认主题红
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowErrorDialog(this Form form, string msg, UIStyle style = UIStyle.Red)
        {
            form.ShowMessageDialog(msg, ULocalize.ErrorTitle, false, style);
        }

        /// <summary>
        /// Form扩展_错误对话框<br/>
        /// 按钮确认，标题自定义，默认主题红
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowErrorDialog(this Form form, string title, string msg, UIStyle style = UIStyle.Red)
        {
            form.ShowMessageDialog(msg, title, false, style);
        }

        /// <summary>
        /// Form扩展_确认对话框<br/>
        /// 按钮确认取消，标题提示，默认主题橙
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowAskDialog(this Form form, string msg, UIStyle style = UIStyle.Blue)
        {
            return form.ShowMessageDialog(msg, ULocalize.AskTitle, true, style);
        }

        /// <summary>
        /// Form扩展_确认对话框<br/>
        /// 按钮确认取消，标题自定义，默认主题橙
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowAskDialog(this Form form, string title, string msg, UIStyle style = UIStyle.Blue)
        {
            return form.ShowMessageDialog(msg, title, true, style);
        }

        /// <summary>
        /// Form扩展_对话框基方法<br/>
        /// 按钮确认取消（取消可显示隐藏），标题自定义，主题自定义
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <param name="isShowCancel">true：显示取消按钮；false：不显示取消按钮</param>
        /// <param name="style">主题</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowMessageDialog(
            this Form form,
            string message,
            string title,
            bool isShowCancel,
            UIStyle style)
        {
            object obj = Application.OpenForms[0].Invoke((Func<bool>)delegate
            {
                UIMessageForm frm = new UIMessageForm
                {
                    TopMost = form != null && form.TopMost
                };
                frm.ShowMessage(message, title, isShowCancel, style);
                frm.ShowDialog();
                bool isOk = frm.IsOK;
                frm.Dispose();
                return isOk;
            });

            return (bool)obj;
        }


        //*****************************************************************************Form扩展
        /// <summary>
        /// Control扩展_正确对话框<br/>
        /// 按钮确认，标题正确，默认主题绿
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowSuccessDialog(this Control control, string msg, UIStyle style = UIStyle.Green)
        {
            control.ShowMessageDialog(msg, ULocalize.SuccessTitle, false, style);
        }
        /// <summary>
        /// Control扩展_正确对话框<br/>
        /// 按钮确认，标题自定义，默认主题绿
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowSuccessDialog(this Control control, string title, string msg, UIStyle style = UIStyle.Green)
        {
            control.ShowMessageDialog(msg, title, false, style);
        }

        /// <summary>
        /// Control扩展_消息对话框<br/>
        /// 按钮确认，标题提示，默认主题灰
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowInfoDialog(this Control control, string msg, UIStyle style = UIStyle.Gray)
        {
            control.ShowMessageDialog(msg, ULocalize.InfoTitle, false, style);
        }
        /// <summary>
        /// Control扩展_消息对话框<br/>
        /// 按钮确认，标题自定义，默认主题灰
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowInfoDialog(this Control control, string title, string msg, UIStyle style = UIStyle.Gray)
        {
            control.ShowMessageDialog(msg, title, false, style);
        }

        /// <summary>
        /// Control扩展_警告对话框<br/>
        /// 按钮确认，标题警告，默认主题橙
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowWarningDialog(this Control control, string msg, UIStyle style = UIStyle.Orange)
        {
            control.ShowMessageDialog(msg, ULocalize.WarningTitle, false, style);
        }
        /// <summary>
        /// Control扩展_警告对话框<br/>
        /// 按钮确认，标题自定义，默认主题橙
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowWarningDialog(this Control control, string title, string msg, UIStyle style = UIStyle.Orange)
        {
            control.ShowMessageDialog(msg, title, false, style);
        }

        /// <summary>
        /// Control扩展_错误对话框<br/>
        /// 按钮确认，标题错误，默认主题红
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowErrorDialog(this Control control, string msg, UIStyle style = UIStyle.Red)
        {
            control.ShowMessageDialog(msg, ULocalize.ErrorTitle, false, style);
        }
        /// <summary>
        /// Control扩展_错误对话框<br/>
        /// 按钮确认，标题自定义，默认主题红
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        public static void ShowErrorDialog(this Control control, string title, string msg, UIStyle style = UIStyle.Red)
        {
            control.ShowMessageDialog(msg, title, false, style);
        }

        /// <summary>
        /// Control扩展_确认对话框<br/>
        /// 按钮确认取消，标题提示，默认主题橙
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowAskDialog(this Control control, string msg, UIStyle style = UIStyle.Blue)
        {
            return control.ShowMessageDialog(msg, ULocalize.AskTitle, true, style);
        }
        /// <summary>
        /// Control扩展_确认对话框<br/>
        /// 按钮确认取消，标题自定义，默认主题橙
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="title">标题</param>
        /// <param name="msg">信息</param>
        /// <param name="style">主题</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowAskDialog(this Control control, string title, string msg, UIStyle style = UIStyle.Orange)
        {
            return control.ShowMessageDialog(msg, title, true, style);
        }

        /// <summary>
        /// Control扩展_对话框基方法<br/>
        /// 按钮确认取消（取消可显示隐藏），标题自定义，主题自定义
        /// </summary>
        /// <param name="control">窗体</param>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <param name="isShowCancel">true：显示取消按钮；false：不显示取消按钮</param>
        /// <param name="style">主题</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowMessageDialog(
            this Control control,
            string message,
            string title,
            bool isShowCancel,
            UIStyle style)
        {
            object obj = Application.OpenForms[0].Invoke((Func<bool>)delegate
            {
                UIMessageForm frm = new UIMessageForm();
                frm.TopMost = true;
                frm.ShowMessage(message, title, isShowCancel, style);
                frm.ShowDialog();
                bool isOk = frm.IsOK;
                frm.Dispose();
                return isOk;
            });

            return (bool)obj;
        }


        //*****************************************************************************通用
        /// <summary>
        /// 通用_对话框基方法<br/>
        /// 按钮确认取消（取消可显示隐藏），标题自定义，主题自定义
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <param name="showCancelButton">true：显示取消按钮；false：不显示取消按钮</param>
        /// <param name="style">主题</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层</param>
        /// <param name="topMost">true：置顶；false：不置顶</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowMessageDialog(
            string message,
            string title,
            bool showCancelButton,
            UIStyle style,
            bool showMask = false,
            bool topMost = true)
        {
            object obj = Application.OpenForms[0].Invoke((Func<bool>)delegate
            {
                UIMessageForm frm = new UIMessageForm();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowMessage(message, title, showCancelButton, style);
                frm.ShowInTaskbar = false;
                frm.TopMost = topMost;

                if (showMask)
                    frm.ShowDialogWithMask();
                else
                    frm.ShowDialog();

                bool isOk = frm.IsOK;
                frm.Dispose();
                return isOk;
            });

            return (bool)obj;
        }
        /// <summary>
        /// 通用_对话框基方法<br/>
        /// 按钮自定义（右侧按钮可显示隐藏），标题自定义，主题自定义
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <param name="showCancelButton">true：显示取消按钮；false：不显示取消按钮</param>
        /// <param name="btnOKName">左按钮名称</param>
        /// <param name="btnCancelName">右按钮名称</param>
        /// <param name="style">主题</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层</param>
        /// <param name="topMost">true：置顶；false：不置顶</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowMessageDialog(
            string message,
            string title,
            bool showCancelButton,
            string btnOKName,
            string btnCancelName,
            UIStyle style,
            bool showMask = false,
            bool topMost = true)
        {
            return ShowMessageDialog(message, title, showCancelButton, btnOKName, btnCancelName, 0, style, showMask, topMost);
        }

        /// <summary>
        /// 通用_对话框基方法<br/>
        /// 按钮自定义（右侧按钮可显示隐藏），标题自定义，主题自定义
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="title">标题</param>
        /// <param name="showCancelButton">true：显示取消按钮；false：不显示取消按钮</param>
        /// <param name="btnOKName">左按钮名称</param>
        /// <param name="btnCancelName">右按钮名称</param>
        /// <param name="existTime">退出时间</param>
        /// <param name="style">主题</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层</param>
        /// <param name="topMost">true：置顶；false：不置顶</param>
        /// <returns>true：左侧按钮；false：右侧按钮</returns>
        public static bool ShowMessageDialog(
            string message,
            string title,
            bool showCancelButton,
            string btnOKName,
            string btnCancelName,
            int existTime,
            UIStyle style,
            bool showMask = false,
            bool topMost = true)
        {
            object obj = Application.OpenForms[0].Invoke((Func<bool>)delegate
            {
                UIMessageForm frm = new UIMessageForm(btnOKName, btnCancelName);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowMessage(message, title, showCancelButton, existTime, style);
                frm.ShowInTaskbar = false;
                frm.TopMost = topMost;

                if (showMask)
                    frm.ShowDialogWithMask();
                else
                    frm.ShowDialog();

                bool isOk = frm.IsOK;
                frm.Dispose();
                return isOk;
            });

            return (bool)obj;
        }
    }
}
