/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIControl.cs
 * Author: Victor
 * Description: 控件基类
 * CreateTime: 2020-01-01
 * Inherit：Control
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-25: V2.2.4 更新主题配置类
 * 2021-12-13: V3.0.9 边框线宽可设置1或者2
 * 2022-01-10: V3.1.0 调整边框和圆角的绘制
 * 2022-02-16: V3.1.1 基类增加只读颜色设置
 * 2022-03-19: V3.1.1 重构主题配色
 * 2022-07-16: V3.1.1 代码风格重构
 *
 * <3.3.22.0728><Victor><20220807>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Controls
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Sunny.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    /// <summary>控件基类</summary>
    [ToolboxItem(false)]
    public class UIControl : Control, IStyleInterface, IZoomScale
    {
        #region Field
        /// <summary>被选择</summary>
        protected bool selected;
        /// <summary>是否显示浅色背景</summary>
        protected bool _lightStyle;
        /// <summary>true：只读;</summary>
        protected bool isReadOnly;
        /// <summary>填充鼠标移上颜色</summary>
        protected Color fillHoverColor = UIStyles.Blue.ButtonFillColor;
        /// <summary>填充鼠标按下颜色</summary>
        protected Color fillPressColor = UIStyles.Blue.ButtonFillColor;
        /// <summary>选中颜色</summary>
        protected Color fillSelectedColor = UIStyles.Blue.ButtonFillColor;
        /// <summary>填充不可用颜色</summary>
        protected Color fillDisableColor = UIStyles.Blue.FillDisableColor;
        /// <summary>填充只读颜色</summary>
        protected Color fillReadOnlyColor = UIStyles.Blue.FillDisableColor;

        /// <summary>true：渐变色填充;</summary>
        protected bool fillColorGradient = false;
        /// <summary>填充颜色</summary>
        protected Color fillColor = UIStyles.Blue.ButtonFillColor;
        /// <summary>填充颜色</summary>
        protected Color fillColor2 = UIStyles.Blue.ButtonFillColor2;

        /// <summary>边框颜色</summary>
        protected Color rectColor = UIStyles.Blue.ButtonRectColor;
        /// <summary>边框鼠标移上颜色</summary>
        protected Color rectHoverColor = UIStyles.Blue.ButtonRectColor;
        /// <summary>边框鼠标按下颜色</summary>
        protected Color rectPressColor = UIStyles.Blue.ButtonRectColor;
        /// <summary>边框选中颜色</summary>
        protected Color rectSelectedColor = UIStyles.Blue.ButtonRectColor;
        /// <summary>边框不可用颜色</summary>
        protected Color rectDisableColor = UIStyles.Blue.RectDisableColor;
        /// <summary>边框只读颜色</summary>
        protected Color rectReadOnlyColor = UIStyles.Blue.RectDisableColor;
        /// <summary>字体颜色</summary>
        protected Color foreColor = UIStyles.Blue.ButtonForeColor;
        /// <summary>字体鼠标移上颜色</summary>
        protected Color foreHoverColor = UIStyles.Blue.ButtonForeColor;
        /// <summary>字体鼠标按下颜色</summary>
        protected Color forePressColor = UIStyles.Blue.ButtonForeColor;
        /// <summary>字体选中颜色</summary>
        protected Color foreSelectedColor = UIStyles.Blue.ButtonForeColor;
        /// <summary>字体不可用颜色</summary>
        protected Color foreDisableColor = UIStyles.Blue.ForeDisableColor;
        /// <summary>字体只读颜色</summary>
        protected Color foreReadOnlyColor = UIStyles.Blue.ForeDisableColor;


        /// <summary>是否鼠标移上</summary>
        [Browsable(false)]
        public bool IsHover;
        /// <summary>是否鼠标按下</summary>
        [Browsable(false)]
        public bool IsPress;
        #endregion



        #region Prop
        private int _radius = 5;
        private int baseRadius = 5;
        /// <summary>圆角角度</summary>
        [DefaultValue(5), Description("圆角角度"), Category("SunnyUI")]
        public int Radius
        {
            get => _radius;
            set
            {
                if (_radius != value)
                {
                    baseRadius = _radius = Math.Max(0, value);
                    Invalidate();
                }
            }
        }

        private UICornerRadiusSides _radiusSides = UICornerRadiusSides.All;
        /// <summary>圆角显示位置</summary>
        [DefaultValue(UICornerRadiusSides.All), Description("圆角显示位置"), Category("SunnyUI")]
        public UICornerRadiusSides RadiusSides
        {
            get => _radiusSides;
            set
            {
                _radiusSides = value;
                OnRadiusSidesChange();
                Invalidate();
            }
        }

        private ToolStripStatusLabelBorderSides _rectSides = ToolStripStatusLabelBorderSides.All;
        /// <summary>边框显示位置</summary>
        [DefaultValue(ToolStripStatusLabelBorderSides.All), Description("边框显示位置"), Category("SunnyUI")]
        public ToolStripStatusLabelBorderSides RectSides
        {
            get => _rectSides;
            set
            {
                _rectSides = value;
                OnRectSidesChange();
                Invalidate();
            }
        }

        private int rectSize = 1;
        /// <summary>边框宽度（1/2）</summary>
        [DefaultValue(1), Description("边框宽度（1/2）"), Category("SunnyUI")]
        public int RectSize
        {
            get => rectSize;
            set
            {
                int v = value;
                if (v > 2) v = 2;
                if (v < 1) v = 1;
                if (rectSize != v)
                {
                    rectSize = v;
                    Invalidate();
                }
            }
        }

        /// <summary>是否在设计期</summary>
        protected bool IsDesignMode
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                {
                    return true;
                }

                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                {
                    return true;
                }

                return false;
            }
        }

        private bool showText = true;
        /// <summary>是否显示文字</summary>
        [DefaultValue(true), Description("是否显示文字"), Category("SunnyUI")]
        protected bool ShowText
        {
            get => showText;
            set
            {
                if (showText != value)
                {
                    showText = value;
                    Invalidate();
                }
            }
        }

        private bool showRect = true;
        /// <summary>是否显示边框</summary>
        protected bool ShowRect
        {
            get => showRect;
            set
            {
                if (showRect != value)
                {
                    showRect = value;
                    Invalidate();
                }
            }
        }

        private bool showFill = true;
        /// <summary>是否显示填充</summary>
        protected bool ShowFill
        {
            get => showFill;
            set
            {
                if (showFill != value)
                {
                    showFill = value;
                    Invalidate();
                }
            }
        }

        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
        /// <summary>文字对齐方向</summary>
        [DefaultValue(ContentAlignment.MiddleCenter), Description("文字对齐方向"), Category("SunnyUI")]
        public ContentAlignment TextAlign
        {
            get => textAlign;
            set
            {
                if (textAlign != value)
                {
                    textAlign = value;
                    Invalidate();
                }
            }
        }

        private bool useDoubleClick;
        [DefaultValue(false), Description("是否启用双击事件"), Category("SunnyUI")]
        public bool UseDoubleClick
        {
            get
            {
                return useDoubleClick;
            }
            set
            {
                if (useDoubleClick != value)
                {
                    useDoubleClick = value;
                    SetStyle(ControlStyles.StandardDoubleClick, useDoubleClick);
                    //Invalidate();
                }
            }
        }

        [DefaultValue(false), Description("是否显示激活状态颜色"), Category("SunnyUI")]
        public bool ShowFocusColor { get; set; }
        #endregion



        #region Ctor
        /// <summary>构造函数</summary>
        public UIControl()
        {
            Version = UIGlobal.UIVersion;
            base.Font = UIFontColor.Font();
            Size = new Size(100, 35);
            base.MinimumSize = new Size(1, 1);
        }
        #endregion



        #region System_Event
        /// <summary>Size改变时发生</summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
        /// <summary>OnPaint</summary>
        /// <param name="e">e</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Visible || Width <= 0 || Height <= 0) return;
            if (IsDisposed) return;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = rect.CreateRoundedRectanglePath(_radius, RadiusSides, RectSize);

            //填充背景色
            if (ShowFill && fillColor.IsValid())
            {
                OnPaintFill(e.Graphics, path);
            }

            //填充边框色
            if (ShowRect)
            {
                OnPaintRect(e.Graphics, path);
            }

            //填充文字
            if (ShowText)
            {
                OnPaintFore(e.Graphics, path);
            }

            path.Dispose();
            base.OnPaint(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        /// <summary>引发 <see cref="E:System.Windows.Forms.Control.GotFocus" /> 事件。</summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }
        /// <summary>引发 <see cref="M:System.Windows.Forms.ButtonBase.OnLostFocus(System.EventArgs)" /> 事件。</summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs" />。</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }
        #endregion



        #region virtual
        /// <summary>圆角显示位置改变时发生</summary>
        protected virtual void OnRadiusSidesChange()
        {
        }
        /// <summary>边框显示位置改变时发生</summary>
        protected virtual void OnRectSidesChange()
        {
        }
        #endregion



        #region Override IStyleInterface
        protected UIStyle _style = UIStyle.Blue;
        [DefaultValue(UIStyle.Blue), Description("主题样式"), Category("SunnyUI")]
        public UIStyle Style
        {
            get => _style;
            set => SetStyle(value);
        }

        [DefaultValue(false), Description("获取或设置可以自定义主题风格"), Category("SunnyUI")]
        public bool StyleCustomMode { get; set; }

        public string Version { get; }

        [DefaultValue(null), Description("获取或设置包含有关控件的数据的对象字符串"), Category("SunnyUI")]
        public string TagString { get; set; }

        [Browsable(false), DefaultValue(false)]
        public bool IsScaled { get; set; }

        public virtual void SetStyleColor(UIBaseStyle uiColor)
        {
            fillColor = uiColor.ButtonFillColor;
            fillColor2 = uiColor.ButtonFillColor2;
            foreColor = uiColor.ButtonForeColor;
            rectColor = uiColor.ButtonRectColor;

            fillDisableColor = uiColor.FillDisableColor;
            foreDisableColor = uiColor.ForeDisableColor;
            rectDisableColor = uiColor.RectDisableColor;

            fillReadOnlyColor = uiColor.FillDisableColor;
            rectReadOnlyColor = uiColor.RectDisableColor;
            foreReadOnlyColor = uiColor.ForeDisableColor;

            fillHoverColor = fillColor;
            foreHoverColor = foreColor;
            rectHoverColor = rectColor;

            fillPressColor = fillColor;
            forePressColor = foreColor;
            rectPressColor = rectColor;

            fillSelectedColor = fillColor;
            foreSelectedColor = foreColor;
            rectSelectedColor = rectColor;
        }
        public void SetStyle(UIStyle style)
        {
            if (!style.IsCustom())
            {
                SetStyleColor(style.Colors());
                Invalidate();
            }

            _style = style;
        }
        public virtual void SetDPIScale()
        {
            if (!IsScaled)
            {
                this.SetDPIScaleFont();
                IsScaled = true;
            }
        }
        #endregion



        #region Override IZoomScale
        [Browsable(false)]
        public Rectangle ZoomScaleRect { get; set; }
        [DefaultValue(false), Category("SunnyUI"), Description("获取或设置控件跟随窗体缩放")]
        public bool ZoomScaleDisabled { get; set; }

        public virtual void SetZoomScale(float scale)
        {
            _radius = UIZoomScale.Calc(baseRadius, scale);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>Control样式设置</summary>
        /// <param name="supportTransparent">true：支持透明；false：不支持透明</param>
        /// <param name="selectable">true：可以被选择；false：不可以被选择</param>
        /// <param name="resizeRedraw">true：调整大小时重绘该控件；false：调整大小时不重绘该控件</param>
        protected void SetStyleFlags(bool supportTransparent = true, bool selectable = true, bool resizeRedraw = false)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            if (supportTransparent) SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            if (selectable) SetStyle(ControlStyles.Selectable, true);
            if (resizeRedraw) SetStyle(ControlStyles.ResizeRedraw, true);
            base.DoubleBuffered = true;
            UpdateStyles();
        }
        /// <summary>主题样式设置</summary>
        /// <param name="needRefresh"></param>
        protected void SetStyleCustom(bool needRefresh = true)
        {
            _style = UIStyle.Custom;
            if (needRefresh) Invalidate();
        }
        /// <summary>绘制填充</summary>
        /// <param name="g">GDI绘图图面</param>
        /// <param name="path">路径</param>
        protected virtual void OnPaintFill(Graphics g, GraphicsPath path)
        {
            Color color = GetFillColor();
            g.FillPath(color, path);
        }
        /// <summary>绘制边框</summary>
        /// <param name="g">GDI绘图图面</param>
        /// <param name="path">路径</param>
        protected virtual void OnPaintRect(Graphics g, GraphicsPath path)
        {
            _radius = Math.Min(_radius, Math.Min(Width, Height));
            if (RadiusSides == UICornerRadiusSides.None || Radius == 0)
            {
                //IsRadius为False时，显示左侧边线
                bool ShowRectLeft = RectSides.GetValue(ToolStripStatusLabelBorderSides.Left);
                //IsRadius为False时，显示上侧边线
                bool ShowRectTop = RectSides.GetValue(ToolStripStatusLabelBorderSides.Top);
                //IsRadius为False时，显示右侧边线
                bool ShowRectRight = RectSides.GetValue(ToolStripStatusLabelBorderSides.Right);
                //IsRadius为False时，显示下侧边线
                bool ShowRectBottom = RectSides.GetValue(ToolStripStatusLabelBorderSides.Bottom);

                if (ShowRectLeft)
                    g.DrawLine(GetRectColor(), RectSize - 1, 0, RectSize - 1, Height, false, RectSize);
                if (ShowRectTop)
                    g.DrawLine(GetRectColor(), 0, RectSize - 1, Width, RectSize - 1, false, RectSize);
                if (ShowRectRight)
                    g.DrawLine(GetRectColor(), Width - 1, 0, Width - 1, Height, false, RectSize);
                if (ShowRectBottom)
                    g.DrawLine(GetRectColor(), 0, Height - 1, Width, Height - 1, false, RectSize);
            }
            else
            {
                g.DrawPath(GetRectColor(), path, true, RectSize);
                PaintRectDisableSides(g);
            }
        }
        /// <summary>绘制字体</summary>
        /// <param name="g">GDI绘图图面</param>
        /// <param name="path">路径</param>
        protected virtual void OnPaintFore(Graphics g, GraphicsPath path)
        {
            Color color = GetForeColor();
            g.DrawString(Text, Font, color, Size, Padding, TextAlign);
        }
        /// <summary>获取填充颜色</summary>
        /// <returns>颜色</returns>
        protected Color GetFillColor()
        {
            //填充
            Color color = _lightStyle ? _style.Colors().ButtonFillLightColor : fillColor;
            if (IsHover)
            {
                color = fillHoverColor;
            }
            if (IsPress)
            {
                color = fillPressColor;
            }
            if (selected)
            {
                color = fillSelectedColor;
            }
            if (ShowFocusColor && Focused)
            {
                color = fillPressColor;
            }
            if (isReadOnly)
            {
                color = fillReadOnlyColor;
            }
            return Enabled ? color : fillDisableColor;
        }
        /// <summary>获取边框颜色</summary>
        /// <returns>颜色</returns>
        protected Color GetRectColor()
        {
            //边框
            Color color = rectColor;
            if (IsHover)
                color = rectHoverColor;
            if (IsPress)
                color = rectPressColor;
            if (selected)
                color = rectSelectedColor;
            if (ShowFocusColor && Focused)
                color = rectPressColor;
            if (isReadOnly)
                color = rectReadOnlyColor;
            return Enabled ? color : rectDisableColor;
        }
        /// <summary> 获取字体颜色 </summary>
        /// <returns>颜色</returns>
        protected Color GetForeColor()
        {
            //文字
            Color color = _lightStyle ? _style.Colors().ButtonForeLightColor : foreColor;
            if (IsHover)
                color = foreHoverColor;
            if (IsPress)
                color = forePressColor;
            if (selected)
                color = foreSelectedColor;
            if (ShowFocusColor && Focused)
                color = forePressColor;
            if (isReadOnly)
                color = foreReadOnlyColor;
            return Enabled ? color : foreDisableColor;
        }
        /// <summary>设置选中颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetFillSelectedColor(Color color)
        {
            if (fillSelectedColor != color)
            {
                fillSelectedColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设置选中颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetForeSelectedColor(Color color)
        {
            if (foreSelectedColor != color)
            {
                foreSelectedColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设置选中颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetRectSelectedColor(Color color)
        {
            if (rectSelectedColor != color)
            {
                rectSelectedColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设置填充鼠标移上颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetFillHoverColor(Color color)
        {
            if (fillHoverColor != color)
            {
                fillHoverColor = color;
                SetStyleCustom(false);
            }
        }
        /// <summary>设置填充鼠标按下颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetFillPressColor(Color color)
        {
            if (fillPressColor != color)
            {
                fillPressColor = color;
                SetStyleCustom(false);
            }
        }
        /// <summary>设置填充不可用颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetFillDisableColor(Color color)
        {
            if (fillDisableColor != color)
            {
                fillDisableColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设置填充只读颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetFillReadOnlyColor(Color color)
        {
            if (fillReadOnlyColor != color)
            {
                fillReadOnlyColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设备边框鼠标移上颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetRectHoverColor(Color color)
        {
            if (rectHoverColor != color)
            {
                rectHoverColor = color;
                SetStyleCustom(false);
            }
        }
        /// <summary>设置边框鼠标按下颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetRectPressColor(Color color)
        {
            if (rectPressColor != color)
            {
                rectPressColor = color;
                SetStyleCustom(false);
            }
        }
        /// <summary>设置边框不可用颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetRectDisableColor(Color color)
        {
            if (rectDisableColor != color)
            {
                rectDisableColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设置边框只读颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetRectReadOnlyColor(Color color)
        {
            if (rectReadOnlyColor != color)
            {
                rectReadOnlyColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设置字体鼠标移上颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetForeHoverColor(Color color)
        {
            if (foreHoverColor != color)
            {
                foreHoverColor = color;
                SetStyleCustom(false);
            }
        }
        /// <summary>设置字体鼠标按下颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetForePressColor(Color color)
        {
            if (forePressColor != color)
            {
                forePressColor = color;
                SetStyleCustom(false);
            }
        }
        /// <summary>设置字体不可用颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetForeDisableColor(Color color)
        {
            if (foreDisableColor != color)
            {
                foreDisableColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设置字体只读颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetForeReadonlyColor(Color color)
        {
            if (foreReadOnlyColor != color)
            {
                foreReadOnlyColor = color;
                SetStyleCustom();
            }
        }
        /// <summary>设置边框颜色</summary>
        /// <param name="value">颜色</param>
        protected void SetRectColor(Color value)
        {
            if (rectColor != value)
            {
                rectColor = value;
                SetStyleCustom();
            }
        }
        /// <summary>设置填充颜色</summary>
        /// <param name="value">颜色</param>
        protected void SetFillColor(Color value)
        {
            if (fillColor != value)
            {
                fillColor = value;
                SetStyleCustom();
            }
        }
        /// <summary>设置填充颜色</summary>
        /// <param name="value">颜色</param>
        protected void SetFillColor2(Color value)
        {
            if (fillColor2 != value)
            {
                fillColor2 = value;
                SetStyleCustom();
            }
        }
        /// <summary>设置字体颜色</summary>
        /// <param name="value">颜色</param>
        protected void SetForeColor(Color value)
        {
            if (foreColor != value)
            {
                foreColor = value;
                SetStyleCustom();
            }
        }
        #endregion



        #region Method_InternalUsing
        private void PaintRectDisableSides(Graphics g)
        {
            //IsRadius为False时，显示左侧边线
            bool ShowRectLeft = RectSides.GetValue(ToolStripStatusLabelBorderSides.Left);
            //IsRadius为False时，显示上侧边线
            bool ShowRectTop = RectSides.GetValue(ToolStripStatusLabelBorderSides.Top);
            //IsRadius为False时，显示右侧边线
            bool ShowRectRight = RectSides.GetValue(ToolStripStatusLabelBorderSides.Right);
            //IsRadius为False时，显示下侧边线
            bool ShowRectBottom = RectSides.GetValue(ToolStripStatusLabelBorderSides.Bottom);

            //IsRadius为True时，显示左上圆角
            bool RadiusLeftTop = RadiusSides.GetValue(UICornerRadiusSides.LeftTop);
            //IsRadius为True时，显示左下圆角
            bool RadiusLeftBottom = RadiusSides.GetValue(UICornerRadiusSides.LeftBottom);
            //IsRadius为True时，显示右上圆角
            bool RadiusRightTop = RadiusSides.GetValue(UICornerRadiusSides.RightTop);
            //IsRadius为True时，显示右下圆角
            bool RadiusRightBottom = RadiusSides.GetValue(UICornerRadiusSides.RightBottom);

            var ShowRadius = RadiusSides > 0 && Radius > 0;//肯定少有一个角显示圆角
            if (!ShowRadius) return;

            if (!ShowRectLeft && !RadiusLeftBottom && !RadiusLeftTop)
            {
                g.DrawLine(GetFillColor(), RectSize - 1, 0, RectSize - 1, Height, false, RectSize);
            }

            if (!ShowRectTop && !RadiusRightTop && !RadiusLeftTop)
            {
                g.DrawLine(GetFillColor(), 0, RectSize - 1, Width, RectSize - 1, false, RectSize);
            }

            if (!ShowRectRight && !RadiusRightTop && !RadiusRightBottom)
            {
                g.DrawLine(GetFillColor(), Width - 1, 0, Width - 1, Height, false, RectSize);
            }

            if (!ShowRectBottom && !RadiusLeftBottom && !RadiusRightBottom)
            {
                g.DrawLine(GetFillColor(), 0, Height - 1, Width, Height - 1, false, RectSize);
            }
        }
        #endregion
    }
}