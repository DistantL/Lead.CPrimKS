/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UILabel.cs
 * Author: Victor
 * Description: 标签
 * CreateTime: 2020-01-01
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-23: V2.2.4 增加UISymbolLabel
 * 2020-04-25: V2.2.4 更新主题配置类
 * 2020-11-12: V3.0.8 增加文字旋转角度
 * 2022-03-19: V3.1.1 重构主题配色
 *
 * <3.3.22.1010><Victor><20221010>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Controls
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    [ToolboxItem(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    public class UILabel : Label, IStyleInterface, IZoomScale
    {
        public UILabel()
        {
            base.Font = UIFontColor.Font();
            Version = UIGlobal.UIVersion;
            base.TextAlign = ContentAlignment.MiddleLeft;
            foreColor = UIStyles.Blue.LabelForeColor;
        }

        [DefaultValue(false), Category("SunnyUI"), Description("禁止控件跟随窗体缩放")]
        public bool ZoomScaleDisabled { get; set; }

        [Browsable(false)]
        public Rectangle ZoomScaleRect { get; set; }

        public virtual void SetZoomScale(float scale)
        {

        }

        private int angle;

        [DefaultValue(0), Category("SunnyUI"), Description("居中时旋转角度")]
        public int Angle
        {
            get => angle;
            set
            {
                angle = value;
                Invalidate();
            }
        }

        [Browsable(false), DefaultValue(false)]
        public bool IsScaled { get; set; }

        public void SetDPIScale()
        {
            if (!IsScaled)
            {
                this.SetDPIScaleFont();
                IsScaled = true;
            }
        }

        /// <summary>
        /// Tag字符串
        /// </summary>
        [DefaultValue(null)]
        [Description("获取或设置包含有关控件的数据的对象字符串"), Category("SunnyUI")]
        public string TagString { get; set; }

        private Color foreColor;
        /// <summary>
        /// 字体颜色
        /// </summary>
        [Description("字体颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "48, 48, 48")]
        public override Color ForeColor
        {
            get => foreColor;
            set
            {
                if (foreColor != value)
                {
                    foreColor = value;
                    SetStyleCustom();
                }
            }
        }

        protected void SetStyleCustom(bool needRefresh = true)
        {
            _style = UIStyle.Custom;
            if (needRefresh) Invalidate();
        }

        public string Version { get; }

        public void SetStyle(UIStyle style)
        {
            if (!style.IsCustom())
            {
                SetStyleColor(style.Colors());
                Invalidate();
            }

            _style = style;
        }

        /// <summary>
        /// 自定义主题风格
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置可以自定义主题风格"), Category("SunnyUI")]
        public bool StyleCustomMode { get; set; }

        public virtual void SetStyleColor(UIBaseStyle uiColor)
        {
            ForeColor = uiColor.LabelForeColor;
        }

        private UIStyle _style = UIStyle.Blue;

        /// <summary>
        /// 主题样式
        /// </summary>
        [DefaultValue(UIStyle.Blue), Description("主题样式"), Category("SunnyUI")]
        public UIStyle Style
        {
            get => _style;
            set => SetStyle(value);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (TextAlign == ContentAlignment.MiddleCenter && Angle != 0 && !AutoSize)
            {
                e.Graphics.DrawStringRotateAtCenter(Text, Font, ForeColor, ClientRectangle.Center(), Angle);
            }
            else
            {
                base.OnPaint(e);
            }
        }
    }

    [ToolboxItem(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    public sealed class UILinkLabel : LinkLabel, IStyleInterface, IZoomScale
    {
        public UILinkLabel()
        {
            Font = UIFontColor.Font();
            LinkBehavior = LinkBehavior.AlwaysUnderline;
            Version = UIGlobal.UIVersion;

            ActiveLinkColor = UIColor.Orange;
            VisitedLinkColor = UIColor.Red;

            foreColor = UIStyles.Blue.LabelForeColor;
            base.LinkColor = linkColor = UIColor.Blue;
        }

        [DefaultValue(false), Category("SunnyUI"), Description("禁止控件跟随窗体缩放")]
        public bool ZoomScaleDisabled { get; set; }

        [Browsable(false)]
        public Rectangle ZoomScaleRect { get; set; }

        public void SetZoomScale(float scale)
        {

        }

        [Browsable(false)]
        public bool IsScaled { get; private set; }

        public void SetDPIScale()
        {
            if (!IsScaled)
            {
                this.SetDPIScaleFont();
                IsScaled = true;
            }
        }

        /// <summary>
        /// Tag字符串
        /// </summary>
        [DefaultValue(null)]
        [Description("获取或设置包含有关控件的数据的对象字符串"), Category("SunnyUI")]
        public string TagString { get; set; }

        public string Version { get; }

        /// <summary>
        /// 自定义主题风格
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置可以自定义主题风格"), Category("SunnyUI")]
        public bool StyleCustomMode { get; set; }

        public void SetStyle(UIStyle style)
        {
            if (!style.IsCustom())
            {
                SetStyleColor(style.Colors());
                Invalidate();
            }

            _style = style;
        }

        public void SetStyleColor(UIBaseStyle uiColor)
        {
            foreColor = uiColor.LabelForeColor;
            linkColor = uiColor.PrimaryColor;
            base.LinkColor = linkColor;
        }

        private UIStyle _style = UIStyle.Blue;

        /// <summary>
        /// 主题样式
        /// </summary>
        [DefaultValue(UIStyle.Blue), Description("主题样式"), Category("SunnyUI")]
        public UIStyle Style
        {
            get => _style;
            set => SetStyle(value);
        }

        private Color foreColor;
        /// <summary>
        /// 字体颜色
        /// </summary>
        [Description("字体颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "48, 48, 48")]
        public override Color ForeColor
        {
            get => foreColor;
            set
            {
                if (foreColor != value)
                {
                    foreColor = value;
                    SetStyleCustom();
                }
            }
        }

        private void SetStyleCustom(bool needRefresh = true)
        {
            _style = UIStyle.Custom;
            if (needRefresh) Invalidate();
        }

        private Color linkColor;
        /// <summary>
        /// 字体颜色
        /// </summary>
        [Description("字体颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "80, 160, 255")]
        public new Color LinkColor
        {
            get => linkColor;
            set
            {
                if (linkColor != value)
                {
                    linkColor = value;
                    base.LinkColor = value;
                    SetStyleCustom();
                }
            }
        }
    }
}