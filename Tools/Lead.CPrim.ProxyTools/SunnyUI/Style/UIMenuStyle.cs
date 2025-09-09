/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIMenuStyle.cs
 * Author: Victor
 * Description: 控件样式定义类
 * CreateTime: 2020-01-01
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230107>
 * 1、初版1.0
******************************************************************************/

using System;
using Sunny.UI;
using System.Drawing;

namespace Lead.CPrim.ProxyTools.SunnyUI.Style
{
    /// <summary>
    /// 菜单主题样色
    /// </summary>
    public enum UIMenuStyle
    {
        /// <summary>
        /// 自定义
        /// </summary>
        [DisplayText("Custom")]
        Custom,

        /// <summary>
        /// 黑
        /// </summary>
        [DisplayText("Black")]
        Black,

        /// <summary>
        /// 白
        /// </summary>
        [DisplayText("White")]
        White
    }

    public abstract class UIMenuColor
    {
        public abstract UIMenuStyle Style { get; }
        public virtual Color BackColor => Color.FromArgb(56, 56, 56);
        public virtual Color SelectedColor => Color.FromArgb(36, 36, 36);
        public virtual Color SelectedColor2 => Color.FromArgb(36, 36, 36);
        public virtual Color UnSelectedForeColor => Color.FromArgb(240, 240, 240);
        public virtual Color HoverColor => Color.FromArgb(76, 76, 76);
        public virtual Color SecondBackColor => Color.FromArgb(66, 66, 66);

        public override string ToString()
        {
            return Style.DisplayText();
        }
    }

    public class UIMenuCustomColor : UIMenuColor
    {
        public override UIMenuStyle Style => UIMenuStyle.Custom;
    }

    public class UIMenuBlackColor : UIMenuColor
    {
        public override UIMenuStyle Style => UIMenuStyle.Black;
    }

    public class UIMenuWhiteColor : UIMenuColor
    {
        public override UIMenuStyle Style => UIMenuStyle.White;
        public override Color BackColor => Color.FromArgb(240, 240, 240);
        public override Color SelectedColor => Color.FromArgb(250, 250, 250);
        public override Color SelectedColor2 => Color.FromArgb(250, 250, 250);
        public override Color UnSelectedForeColor => UIFontColor.Primary;
        public override Color HoverColor => Color.FromArgb(230, 230, 230);
        public override Color SecondBackColor => Color.FromArgb(235, 235, 235);
    }
}