using Lead.CPrim.ProxyTools.CustomControl;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 输入框帮助类
    /// </summary>
    public static class UIInputDialog
    {
        /// <summary>
        /// 字符串输入框
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="enableKeyBoard">true：启用键盘；false：不启用键盘；</param>
        /// <param name="desc">描述（默认请输入字符串：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="topMost">true：置顶；false：不置顶；（默认置顶）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputStringDialog(
            ref string value,
            bool checkEmpty = true,
            bool enableKeyBoard = false,
            string desc = "请输入字符串：",
            UIStyle style = UIStyle.Blue,
            bool topMost = true,
            bool showMask = false)
        {
            string result = value;
            object obj = Application.OpenForms[0].Invoke((Func<string, bool>)delegate
            {
                UIInputForm frm = new UIInputForm();
                frm.TopMost = topMost;
                frm.Style = style;
                frm.Editor.Text = result;
                frm.Text = ULocalize.InputTitle;
                frm.Label.Text = desc;
                frm.CheckInputEmpty = checkEmpty;
                frm.EnableKeyBoard = enableKeyBoard;
                if (showMask)
                {
                    frm.ShowDialogWithMask();
                }
                else
                {
                    frm.ShowDialog();
                }

                if (frm.IsOK)
                {
                    result = frm.Editor.Text;
                    return true;
                }

                return false;
            }, result);

            value = result;
            return (bool)obj;
        }

        /// <summary>
        /// 字符串输入框
        /// </summary>
        /// <param name="form">UIForm</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入字符串：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputStringDialog(this UIForm form, ref string value, bool checkEmpty = true,
            string desc = "请输入字符串：", bool showMask = false)
        {
            return InputStringDialog(ref value, checkEmpty, true, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 字符串输入框
        /// </summary>
        /// <param name="form">UIPage</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入字符串：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputStringDialog(this UIPage form, ref string value, bool checkEmpty = true,
            string desc = "请输入字符串：", bool showMask = false)
        {
            return InputStringDialog(ref value, checkEmpty, true, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 字符串输入框
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入字符串：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        public static bool InputStringDialog(this Form form, ref string value, bool checkEmpty = true,
            string desc = "请输入字符串：", UIStyle style = UIStyle.Blue, bool showMask = false)
        {
            return InputStringDialog(ref value, checkEmpty, true, desc, style, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 密码输入框
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入密码：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="topMost">true：置顶；false：不置顶；（默认置顶）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputPasswordDialog(
            ref string value,
            bool checkEmpty = true,
            string desc = "请输入密码：",
            UIStyle style = UIStyle.Blue,
            bool topMost = true,
            bool showMask = false)
        {
            string result = value;
            object obj = Application.OpenForms[0].Invoke((Func<string, bool>)delegate
            {
                UIInputForm frm = new UIInputForm();
                frm.TopMost = topMost;
                frm.Style = style;
                frm.Text = ULocalize.InputTitle;
                frm.Label.Text = desc;
                frm.Editor.PasswordChar = '*';
                frm.CheckInputEmpty = checkEmpty;
                if (showMask)
                {
                    frm.ShowDialogWithMask();
                }
                else
                {
                    frm.ShowDialog();
                }

                if (frm.IsOK)
                {
                    result = frm.Editor.Text;
                    return true;
                }

                return false;
            }, result);

            value = result;
            return (bool)obj;
        }

        /// <summary>
        /// 密码输入框
        /// </summary>
        /// <param name="form">UIForm</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入密码：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputPasswordDialog(this UIForm form, ref string value, bool checkEmpty = true,
            string desc = "请输入密码：", bool showMask = false)
        {
            return InputPasswordDialog(ref value, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 密码输入框
        /// </summary>
        /// <param name="form">UIPage</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入密码：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputPasswordDialog(this UIPage form, ref string value, bool checkEmpty = true,
            string desc = "请输入密码：", bool showMask = false)
        {
            return InputPasswordDialog(ref value, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 密码输入框
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入密码：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputPasswordDialog(this Form form, ref string value, bool checkEmpty = true,
            string desc = "请输入密码：", UIStyle style = UIStyle.Blue, bool showMask = false)
        {
            return InputPasswordDialog(ref value, checkEmpty, desc, style, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 整数输入框（不含最小值最大值）
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入整数：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="topMost">true：置顶；false：不置顶；（默认置顶）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputIntegerDialog(
            ref int value,
            bool checkEmpty = true,
            string desc = "请输入整数：",
            UIStyle style = UIStyle.Blue,
            bool topMost = true,
            bool showMask = false)
        {
            int result = value;
            object obj = Application.OpenForms[0].Invoke((Func<string, bool>)delegate
            {
                UIInputForm frm = new UIInputForm();
                frm.TopMost = topMost;
                frm.Style = style;
                frm.Editor.Type = UITextBox.UIEditType.Integer;
                frm.Editor.IntValue = result;
                frm.Text = ULocalize.InputTitle;
                frm.Label.Text = desc;
                frm.CheckInputEmpty = checkEmpty;
                if (showMask)
                {
                    frm.ShowDialogWithMask();
                }
                else
                {
                    frm.ShowDialog();
                }

                if (frm.IsOK)
                {
                    result = frm.Editor.IntValue;
                    return true;
                }

                return false;
            }, result);

            value = result;
            return (bool)obj;
        }

        /// <summary>
        /// 整数输入框（含最小值最大值）
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="minimum">最小值</param>
        /// <param name="maximum">最大值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入整数：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="topMost">true：置顶；false：不置顶；（默认置顶）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputIntegerDialog(
            ref int value,
            int minimum,
            int maximum,
            bool checkEmpty = true,
            string desc = "请输入整数：",
            UIStyle style = UIStyle.Blue,
            bool topMost = true,
            bool showMask = false)
        {
            int result = value;
            object obj = Application.OpenForms[0].Invoke((Func<string, bool>)delegate
            {
                UIInputForm frm = new UIInputForm();
                frm.TopMost = topMost;
                frm.Style = style;
                frm.Editor.Type = UITextBox.UIEditType.Integer;
                frm.Editor.IntValue = result;
                frm.Text = ULocalize.InputTitle;
                frm.Label.Text = desc;
                frm.CheckInputEmpty = checkEmpty;
                frm.Editor.MaxLength = 11;
                frm.Editor.Minimum = minimum;
                frm.Editor.Maximum = maximum;
                frm.Editor.HasMaximum = true;
                frm.Editor.HasMinimum = true;
                if (showMask)
                {
                    frm.ShowDialogWithMask();
                }
                else
                {
                    frm.ShowDialog();
                }

                if (frm.IsOK)
                {
                    result = frm.Editor.IntValue;
                    return true;
                }

                return false;
            }, result);

            value = result;
            return (bool)obj;
        }

        /// <summary>
        /// 整数输入框（不含最小值最大值）
        /// </summary>
        /// <param name="form">UIForm</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入整数：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputIntegerDialog(this UIForm form, ref int value, bool checkEmpty = true,
            string desc = "请输入整数：", bool showMask = false)
        {
            return InputIntegerDialog(ref value, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 整数输入框（不含最小值最大值）
        /// </summary>
        /// <param name="form">UIPage</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入整数：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputIntegerDialog(this UIPage form, ref int value, bool checkEmpty = true,
            string desc = "请输入整数：", bool showMask = false)
        {
            return InputIntegerDialog(ref value, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 整数输入框（不含最小值最大值）
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="value">值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入整数：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputIntegerDialog(this Form form, ref int value, bool checkEmpty = true,
            string desc = "请输入整数：", UIStyle style = UIStyle.Blue, bool showMask = false)
        {
            return InputIntegerDialog(ref value, checkEmpty, desc, style, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 整数输入框（含最小值最大值）
        /// </summary>
        /// <param name="form">UIForm</param>
        /// <param name="value">值</param>
        /// <param name="minimum">最小值</param>
        /// <param name="maximum">最大值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入整数：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputIntegerDialog(this UIForm form, ref int value, int minimum, int maximum, bool checkEmpty = true, string desc = "请输入整数：", bool showMask = false)
        {
            return InputIntegerDialog(ref value, minimum, maximum, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 整数输入框（含最小值最大值）
        /// </summary>
        /// <param name="form">UIForm</param>
        /// <param name="value">值</param>
        /// <param name="minimum">最小值</param>
        /// <param name="maximum">最大值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入整数：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        public static bool InputIntegerDialog(this UIPage form, ref int value, int minimum, int maximum, bool checkEmpty = true, string desc = "请输入整数：", bool showMask = false)
        {
            return InputIntegerDialog(ref value, minimum, maximum, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 整数输入框（含最小值最大值）
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="value">值</param>
        /// <param name="minimum">最小值</param>
        /// <param name="maximum">最大值</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入整数：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        public static bool InputIntegerDialog(this Form form, ref int value, int minimum, int maximum, bool checkEmpty = true,
            string desc = "请输入整数：", UIStyle style = UIStyle.Blue, bool showMask = false)
        {
            return InputIntegerDialog(ref value, minimum, maximum, checkEmpty, desc, style, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 浮点输入框（不含最小值最大值）
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="decimals">小数位数</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入浮点数：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="topMost">true：置顶；false：不置顶；（默认置顶）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputDoubleDialog(
            ref double value,
            int decimals = 2,
            bool checkEmpty = true,
            string desc = "请输入浮点数：",
            UIStyle style = UIStyle.Blue,
            bool topMost = true,
            bool showMask = false)
        {
            double result = value;
            object obj = Application.OpenForms[0].Invoke((Func<string, bool>)delegate
            {
                UIInputForm frm = new UIInputForm();
                frm.TopMost = topMost;
                frm.Style = style;
                frm.Editor.Type = UITextBox.UIEditType.Double;
                frm.Editor.DecLength = decimals;
                frm.Editor.DoubleValue = result;
                frm.Text = ULocalize.InputTitle;
                frm.Label.Text = desc;
                frm.CheckInputEmpty = checkEmpty;
                if (showMask)
                {
                    frm.ShowDialogWithMask();
                }
                else
                {
                    frm.ShowDialog();
                }

                if (frm.IsOK)
                {
                    result = frm.Editor.DoubleValue;
                    return true;
                }

                return false;
            }, result);

            value = result;
            return (bool)obj;
        }

        /// <summary>
        /// 浮点输入框（含最小值最大值）
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="minimum">最小值</param>
        /// <param name="maximum">最大值</param>
        /// <param name="decimals">小数位数</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入浮点数：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="topMost">true：置顶；false：不置顶；（默认置顶）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputDoubleDialog(
            ref double value,
            double minimum,
            double maximum,
            int decimals = 2,
            bool checkEmpty = true,
            string desc = "请输入浮点数：",
            UIStyle style = UIStyle.Blue,
            bool topMost = true,
            bool showMask = false)
        {
            double result = value;
            object obj = Application.OpenForms[0].Invoke((Func<string, bool>)delegate
            {
                UIInputForm frm = new UIInputForm();
                frm.TopMost = topMost;
                frm.Style = style;
                frm.Editor.Type = UITextBox.UIEditType.Double;
                frm.Editor.DecLength = decimals;
                frm.Editor.DoubleValue = result;
                frm.Text = ULocalize.InputTitle;
                frm.Label.Text = desc;
                frm.CheckInputEmpty = checkEmpty;
                frm.Editor.Minimum = minimum;
                frm.Editor.Maximum = maximum;
                frm.Editor.HasMaximum = true;
                frm.Editor.HasMinimum = true;
                if (showMask)
                {
                    frm.ShowDialogWithMask();
                }
                else
                {
                    frm.ShowDialog();
                }

                if (frm.IsOK)
                {
                    result = frm.Editor.DoubleValue;
                    return true;
                }

                return false;
            }, result);

            value = result;
            return (bool)obj;
        }

        /// <summary>
        /// 浮点输入框（不含最小值最大值）
        /// </summary>
        /// <param name="form">UIForm</param>
        /// <param name="value">值</param>
        /// <param name="decimals">小数位数</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入浮点数：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        public static bool InputDoubleDialog(this UIForm form, ref double value, int decimals = 2, bool checkEmpty = true,
            string desc = "请输入浮点数：", bool showMask = false)
        {
            return InputDoubleDialog(ref value, decimals, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 浮点输入框（不含最小值最大值）
        /// </summary>
        /// <param name="form">UIPage</param>
        /// <param name="value">值</param>
        /// <param name="decimals">小数位数</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入浮点数：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        public static bool InputDoubleDialog(this UIPage form, ref double value, int decimals = 2, bool checkEmpty = true,
            string desc = "请输入浮点数：", bool showMask = false)
        {
            return InputDoubleDialog(ref value, decimals, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 浮点输入框（不含最小值最大值）
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="value">值</param>
        /// <param name="decimals">小数位数</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入浮点数：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        public static bool InputDoubleDialog(this Form form, ref double value, int decimals = 2, bool checkEmpty = true,
            string desc = "请输入浮点数：", UIStyle style = UIStyle.Blue, bool showMask = false)
        {
            return InputDoubleDialog(ref value, decimals, checkEmpty, desc, style, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 浮点输入框（含最小值最大值）
        /// </summary>
        /// <param name="form">UIForm</param>
        /// <param name="value">值</param>
        /// <param name="minimum">最小值</param>
        /// <param name="maximum">最大值</param>
        /// <param name="decimals">小数位数</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入浮点数：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputDoubleDialog(this UIForm form, ref double value, double minimum, double maximum, int decimals = 2, bool checkEmpty = true, string desc = "请输入浮点数：", bool showMask = false)
        {
            return InputDoubleDialog(ref value, minimum, maximum, decimals, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 浮点输入框（含最小值最大值）
        /// </summary>
        /// <param name="form">UIPage</param>
        /// <param name="value">值</param>
        /// <param name="minimum">最小值</param>
        /// <param name="maximum">最大值</param>
        /// <param name="decimals">小数位数</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入浮点数：）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputDoubleDialog(this UIPage form, ref double value, double minimum, double maximum, int decimals = 2, bool checkEmpty = true, string desc = "请输入浮点数：", bool showMask = false)
        {
            return InputDoubleDialog(ref value, minimum, maximum, decimals, checkEmpty, desc, form != null ? form.Style : UIStyle.Blue, form != null && form.TopMost, showMask);
        }

        /// <summary>
        /// 浮点输入框（含最小值最大值）
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="value">值</param>
        /// <param name="minimum">最小值</param>
        /// <param name="maximum">最大值</param>
        /// <param name="decimals">小数位数</param>
        /// <param name="checkEmpty">true：检查输入框为空；false：不检查输入框为空；（默认检查）</param>
        /// <param name="desc">描述（默认请输入浮点数：）</param>
        /// <param name="style">主题样式（默认蓝色）</param>
        /// <param name="showMask">true：显示遮罩层；false：不显示遮罩层；（默认不显示）</param>
        /// <returns></returns>
        public static bool InputDoubleDialog(this Form form, ref double value, double minimum, double maximum, int decimals = 2, bool checkEmpty = true, string desc = "请输入浮点数：", UIStyle style = UIStyle.Blue, bool showMask = false)
        {
            return InputDoubleDialog(ref value, minimum, maximum, decimals, checkEmpty, desc, style, form != null && form.TopMost, showMask);
        }
    }
}
