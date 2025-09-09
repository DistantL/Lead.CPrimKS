/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIMessageDialog.cs
 * Author: Victor
 * Description: 窗体帮助类
 * CreateTime: 2020-01-01
 * Inherit：UIControl
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-05-05: V2.2.5 增加下拉选择框，进度提升窗体
 * 2021-05-09: V3.0.3 增加RemovePage接口，更改GetTopMost为原生接口TopMost
 * 2021-06-27: V3.0.4 增加一个反馈的接口，Feedback，Page可将对象反馈给Frame
 * 2021-12-13: V3.0.9 增加全屏遮罩，Form的ShowDialogWithMask()扩展方法
 * 
 * <3.3.22.1010><Victor><20221010>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Forms 
 * <3.3.22.1010><Victor><20221016>
 * 1、帮助类文档统一放入Common文件下，命名空间统一变更为Lead.CPrim.ProxyTools
 * <3.3.22.1207><Victor><20221228>
 * 1、UMessageDialog之ShowMessageDialog TopMost进行优化
******************************************************************************/

using Lead.CPrim.ProxyTools.CustomControl;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ProxyTools.Win32;
using Sunny.UI;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>含计时，含事件弹窗（脚本中无法使用）</summary>
    public static class UINotifierHelper
    {
        /// <summary>计时弹窗，可根据isDialog确定窗口位置（脚本中无法使用）</summary>
        /// <param name="desc">弹窗内容</param>
        /// <param name="type">提醒类型</param>
        /// <param name="title">标题</param>
        /// <param name="isDialog">true：弹窗位于中间且包含确定按钮；false：弹窗位于右下角并且不包含按钮</param>
        /// <param name="timeout"> 小于500：不进行计时；大于等于500：延时指定时间后消失</param>
        /// <param name="inApp">位于窗口</param>
        public static void ShowNotifier(string desc, UINotifierType type = UINotifierType.INFO, string title = "Notifier", bool isDialog = false, int timeout = 0, Form inApp = null)
        {
            UINotifier.Show(desc, type, title, isDialog, timeout, inApp);
        }
        /// <summary>计时事件弹窗，位于右下角（脚本中无法使用）</summary>
        /// <param name="desc">弹窗内容</param>
        /// <param name="clickEvent">点击事件</param>
        /// <param name="type">提醒类型</param>
        /// <param name="title">标题</param>
        /// <param name="timeout">小于500：不进行计时；大于等于500：延时指定时间后消失</param>
        public static void ShowNotifier(string desc, EventHandler clickEvent, UINotifierType type = UINotifierType.INFO, string title = "Notifier", int timeout = 0)
        {
            UINotifier.Show(desc, type, title, false, timeout, null, clickEvent);
        }
    }


    public static class UIMessageBox
    {
        public static void Show(string text, bool showMask = true, bool topMost = false)
        {
            Show(text, ULocalize.InfoTitle, UIStyle.Blue, UIMessageBoxButtons.OK, showMask, topMost);
        }

        public static void ShowInfo(string text, bool showMask = true, bool topMost = false)
        {
            Show(text, ULocalize.InfoTitle, UIStyle.Gray, UIMessageBoxButtons.OK, showMask, topMost);
        }

        public static void ShowSuccess(string text, bool showMask = true, bool topMost = false)
        {
            Show(text, ULocalize.SuccessTitle, UIStyle.Green, UIMessageBoxButtons.OK, showMask, topMost);
        }

        public static void ShowWarning(string text, bool showMask = true, bool topMost = false)
        {
            Show(text, ULocalize.WarningTitle, UIStyle.Orange, UIMessageBoxButtons.OK, showMask, topMost);
        }

        public static void ShowError(string text, bool showMask = true, bool topMost = false)
        {
            Show(text, ULocalize.ErrorTitle, UIStyle.Red, UIMessageBoxButtons.OK, showMask, topMost);
        }

        public static bool ShowAsk(string text, bool showMask = true, bool topMost = false)
        {
            return Show(text, ULocalize.AskTitle, UIStyle.Blue, UIMessageBoxButtons.OKCancel, showMask, topMost);
        }

        public static bool Show(string text, string caption, UIStyle style = UIStyle.Blue, UIMessageBoxButtons buttons = UIMessageBoxButtons.OK, bool showMask = true, bool topMost = false)
        {
            return UIMessageDialog.ShowMessageDialog(text, caption, buttons == UIMessageBoxButtons.OKCancel, style, showMask, topMost);
        }
    }


    public static class UISelectDialog
    {
        public static bool ShowSelectDialog(this Form form, ref int selectIndex, IList items, string title, string description, UIStyle style = UIStyle.Blue, bool topMost = false)
        {
            UISelectForm frm = new UISelectForm();
            frm.TopMost = topMost;
            frm.Style = style;
            frm.SetItems(items);
            frm.SelectedIndex = selectIndex;
            if (title.IsValid()) frm.Title = title;
            if (description.IsValid()) frm.Description = description;
            frm.ShowDialog();

            bool result = frm.IsOK;
            if (frm.IsOK)
            {
                selectIndex = frm.SelectedIndex;
            }

            frm.Dispose();
            return result;
        }

        public static bool ShowSelectDialog(this Form form, ref int selectIndex, IList items, UIStyle style = UIStyle.Blue)
        {
            return form.ShowSelectDialog(ref selectIndex, items, ULocalize.SelectTitle, "", style, form != null && form.TopMost);
        }

        public static bool ShowSelectDialog(this UIForm form, ref int selectIndex, IList items)
        {
            return form.ShowSelectDialog(ref selectIndex, items, form.Style);
        }

        public static bool ShowSelectDialog(this UIPage form, ref int selectIndex, IList items)
        {
            return form.ShowSelectDialog(ref selectIndex, items, form.Style);
        }

        public static bool ShowSelectDialog(this UIForm form, ref int selectIndex, IList items, string title, string description)
        {
            return form.ShowSelectDialog(ref selectIndex, items, title, description, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost);
        }

        public static bool ShowSelectDialog(this UIPage form, ref int selectIndex, IList items, string title, string description)
        {
            return form.ShowSelectDialog(ref selectIndex, items, title, description, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost);
        }
    }


    public static class FormEx
    {
        internal class FMask : Form
        {
            public FMask()
            {
                this.SuspendLayout();
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                this.BackColor = Color.Black;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Name = "FMask";
                this.Opacity = 0.5D;
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "FMask";
                this.TopMost = true;
                this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FMask_MouseClick);
                this.ResumeLayout(false);
            }

            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                int num = 256;
                int num2 = 260;
                if (msg.Msg == num | msg.Msg == num2)
                {
                    if (keyData == Keys.Escape)
                    {
                        Close();
                    }
                }

                return base.ProcessCmdKey(ref msg, keyData);
            }

            private void FMask_MouseClick(object sender, MouseEventArgs e)
            {
                Close();
            }

            private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }

                base.Dispose(disposing);
            }
        }
        public static DialogResult ShowDialogWithMask(this Form form)
        {
            Point pt = SystemEx.GetCursorPos();
            Rectangle screen = Screen.GetBounds(pt);
            FMask mask = new FMask();
            mask.Bounds = screen;
            mask.Show();

            form.ShowInTaskbar = false;
            form.TopMost = true;
            DialogResult dr = form.ShowDialog();
            mask.Dispose();

            return dr;
        }
        [Obsolete("已弃用，直接调用Form的ShowDialogWithMask扩展方法")]
        public static Form ShowFullMask(this Form form)
        {
            Point pt = SystemEx.GetCursorPos();
            Rectangle screen = Screen.GetBounds(pt);

            Form mask = new Form();
            mask.FormBorderStyle = FormBorderStyle.None;
            mask.BackColor = Color.FromArgb(0, 0, 0);
            mask.Opacity = 0.5;
            mask.ShowInTaskbar = false;
            mask.StartPosition = FormStartPosition.Manual;
            mask.Bounds = screen;
            mask.TopMost = true;
            mask.Show();
            return mask;
        }

        [Obsolete("已弃用，直接调用Form的ShowDialogWithMask扩展方法")]
        public static Form ShowControlMask(this Control control)
        {
            bool topmost = false;
            Form baseForm = control.RootForm();
            if (baseForm != null)
            {
                topmost = baseForm.TopMost;
                baseForm.TopMost = true;
            }

            Form mask = new Form();
            mask.FormBorderStyle = FormBorderStyle.None;
            mask.BackColor = Color.FromArgb(0, 0, 0);
            mask.Opacity = 0.5;
            mask.ShowInTaskbar = false;
            mask.StartPosition = FormStartPosition.Manual;
            mask.Bounds = control.Bounds;
            mask.Tag = baseForm;
            mask.Text = topmost.ToString();

            var pt = control.ScreenLocation();
            mask.Left = pt.X;
            mask.Top = pt.Y;
            mask.Show();
            mask.TopMost = true;
            return mask;
        }
        [Obsolete("已弃用，直接调用Form的ShowDialogWithMask扩展方法")]
        public static void EndShow(this Form maskForm)
        {
            if (maskForm.Tag is Form form)
            {
                form.TopMost = maskForm.Text.ToBoolean();
            }
        }
        [Obsolete("已弃用，直接调用Form的ShowDialogWithMask扩展方法")]
        public static void ShowInMask(this Form frm, Form maskForm)
        {
            frm.StartPosition = FormStartPosition.Manual;
            frm.Left = maskForm.Left + (maskForm.Width - frm.Width) / 2;
            frm.Top = maskForm.Top + (maskForm.Height - frm.Height) / 2;
            frm.ShowInTaskbar = false;
            frm.TopMost = true;
        }
        public static UIEditForm CreateForm(this UIEditOption option)
        {
            return new UIEditForm(option);
        }
        /// <summary>设置窗体的圆角矩形</summary>
        /// <param name="form">需要设置的窗体</param>
        /// <param name="rgnRadius">圆角矩形的半径</param>
        public static void SetFormRoundRectRegion(Form form, int rgnRadius)
        {
            if (form != null && form.FormBorderStyle == FormBorderStyle.None)
            {
                int region = Sunny.UI.Win32.GDI.CreateRoundRectRgn(0, 0, form.Width + 1, form.Height + 1, rgnRadius, rgnRadius);
                User.SetWindowRgn(form.Handle, region, true);
                Sunny.UI.Win32.GDI.DeleteObject(region);
            }
        }
    }
}