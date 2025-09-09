/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIUserControl.cs
 * Author: Victor
 * Description: 用户控件基类（UserControl）
 * CreateTime: 2020-01-01
 * Inherit：UserControl
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2022-04-02: V3.1.1 增加用户控件基类
 * 2022-04-02: V3.1.2 默认设置AutoScaleMode为None
 *
 * <3.3.22.1010><Victor><20221010>
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
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    [DefaultEvent("Click"), DefaultProperty("Text")]
    public partial class UIUserControl : UserControl, IStyleInterface, IZoomScale
    {
        #region delegate And event

        public delegate void OnTextAlignmentChange(object sender, ContentAlignment alignment);

        public event OnTextAlignmentChange TextAlignmentChange;
        public event EventHandler FillColorChanged;
        public event EventHandler RectColorChanged;
        #endregion



        #region Field
        protected Color rectColor = UIStyles.Blue.PanelRectColor;
        protected Color fillColor = UIStyles.Blue.PanelFillColor;
        protected Color foreColor = UIStyles.Blue.PanelForeColor;
        protected Color fillColor2 = UIStyles.Blue.PanelFillColor2;
        protected Color foreDisableColor = UIStyles.Blue.ForeDisableColor;
        protected Color rectDisableColor = UIStyles.Blue.RectDisableColor;
        protected Color fillDisableColor = UIStyles.Blue.FillDisableColor;
        /// <summary>字体只读颜色</summary>
        protected Color foreReadOnlyColor = UIStyles.Blue.ForeDisableColor;
        /// <summary>边框只读颜色</summary>
        protected Color rectReadOnlyColor = UIStyles.Blue.RectDisableColor;
        /// <summary>填充只读颜色</summary>
        protected Color fillReadOnlyColor = UIStyles.Blue.FillDisableColor;
        protected bool InitializeComponentEnd;
        protected bool isReadOnly;

        protected bool showText = false;
        #endregion



        #region Prop
        /// <summary>显示文字</summary>
        private string _text;
        /// <summary>显示文字</summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(""), Description("显示文字"), Category("SunnyUI"), Browsable(true)]
        public override string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    Invalidate();
                }
            }
        }

        protected bool IsDesignMode
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                {
                    return true;
                }
                else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                {
                    return true;
                }

                return false;
            }
        }
        /// <summary>边框显示位置</summary>
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

        private UICornerRadiusSides _radiusSides = UICornerRadiusSides.All;
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

        /// <summary>是否显示圆角</summary>
        [Description("是否显示圆角"), Category("SunnyUI")]
        protected bool ShowRadius => (int)RadiusSides > 0;

        /// <summary>圆角角度</summary>
        private int _radius = 5;
        /// <summary>圆角角度</summary>
        [DefaultValue(5), Description("圆角角度"), Category("SunnyUI")]
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (_radius != value)
                {
                    _radius = Math.Max(0, value);
                    OnRadiusChanged(_radius);
                    Invalidate();
                }
            }
        }

        /// <summary>是否显示边框</summary>
        [DefaultValue(true), Description("是否显示边框"), Category("SunnyUI")]
        protected bool ShowRect => (int)RectSides > 0;

        /// <summary>边框颜色</summary>
        [DefaultValue(typeof(Color), "80, 160, 255"), Description("边框颜色"), Category("SunnyUI")]
        public Color RectColor
        {
            get
            {
                return rectColor;
            }
            set
            {
                if (rectColor != value)
                {
                    rectColor = value;
                    RectColorChanged?.Invoke(this, null);
                    SetStyleCustom();
                }

                AfterSetRectColor(value);
            }
        }

        /// <summary>填充颜色，当值为背景色或透明色或空值则不填充</summary>
        [DefaultValue(typeof(Color), "243, 249, 255"), Description("填充颜色，当值为背景色或透明色或空值则不填充"), Category("SunnyUI")]
        public Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                if (fillColor != value)
                {
                    fillColor = value;
                    FillColorChanged?.Invoke(this, null);
                    SetStyleCustom();
                }

                AfterSetFillColor(value);
            }
        }

        private bool _fillColorGradient;
        [DefaultValue(false), Description("填充颜色渐变"), Category("SunnyUI")]
        public bool FillColorGradient
        {
            get => _fillColorGradient;
            set
            {
                if (_fillColorGradient != value)
                {
                    _fillColorGradient = value;
                    Invalidate();
                }
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

        /// <summary>填充颜色，当值为背景色或透明色或空值则不填充</summary>
        [DefaultValue(typeof(Color), "243, 249, 255"), Description("填充颜色"), Category("SunnyUI")]
        public Color FillColor2
        {
            get => fillColor2;
            set => SetFillColor2(value);
        }

        private bool _showFill = true;
        /// <summary>是否显示填充</summary>
        protected bool ShowFill
        {
            get => _showFill;
            set
            {
                if (_showFill != value)
                {
                    _showFill = value;
                    Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "244, 244, 244"), Description("不可用时填充颜色"), Category("SunnyUI")]
        public Color FillDisableColor
        {
            get => fillDisableColor;
            set => SetFillDisableColor(value);
        }

        [DefaultValue(typeof(Color), "173, 178, 181"), Description("不可用时边框颜色"), Category("SunnyUI")]
        public Color RectDisableColor
        {
            get => rectDisableColor;
            set => SetRectDisableColor(value);
        }

        /// <summary>屏蔽原属性，获取或设置一个值，该值指示是否在 Windows 任务栏中显示窗体。</summary>
        /// <value><c>true</c> if [show in taskbar]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("禁用该属性！", true)]
        public new BorderStyle BorderStyle => BorderStyle.None;


        private int _rectSize = 1;
        /// <summary>边框宽度（1/2）</summary>
        [DefaultValue(1), Description("边框宽度（1/2）"), Category("SunnyUI")]
        public int RectSize
        {
            get => _rectSize;
            set
            {
                int v = value;
                if (v > 2) v = 2;
                if (v < 1) v = 1;
                if (_rectSize != v)
                {
                    _rectSize = v;
                    Invalidate();
                }
            }
        }

        [Browsable(false)]
        public new bool AutoScroll { get; set; } = false;

        private ContentAlignment _textAlignment = ContentAlignment.MiddleCenter;
        /// <summary>文字对齐方向</summary>
        [DefaultValue(ContentAlignment.MiddleLeft), Description("文字对齐方向"), Category("SunnyUI")]
        public ContentAlignment TextAlignment
        {
            get => _textAlignment;
            set
            {
                _textAlignment = value;
                TextAlignmentChange?.Invoke(this, value);
                Invalidate();
            }
        }
        #endregion



        //*****************************************************************************
        #region Ctor
        public UIUserControl()
        {
            InitializeComponent();
            Version = UIGlobal.UIVersion;
            AutoScaleMode = AutoScaleMode.None;
            base.Font = UIFontColor.Font();
            base.MinimumSize = new System.Drawing.Size(1, 1);
            SetStyleFlags(true, false);
        }
        #endregion



        //*****************************************************************************
        #region System_Event
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is IStyleInterface ctrl)
            {
                if (!ctrl.StyleCustomMode) ctrl.Style = Style;
            }

            UIStyleHelper.SetRawControlStyle(e, Style);
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (AutoScaleMode == AutoScaleMode.Font)
            {
                AutoScaleMode = AutoScaleMode.None;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Visible || Width <= 0 || Height <= 0) return;
            if (IsDisposed) return;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = rect.CreateRoundedRectanglePath(_radius, RadiusSides, RectSize);

            //填充背景色
            if (BackgroundImage == null && ShowFill && fillColor.IsValid())
            {
                OnPaintFill(e.Graphics, path);
            }

            //填充边框色
            if (ShowRect)
            {
                OnPaintRect(e.Graphics, path);
            }

            //填充文字
            rect = new Rectangle(1, 1, Width - 3, Height - 3);
            using (var path1 = rect.GraphicsPath())
            {
                OnPaintFore(e.Graphics, path1);
            }

            path.Dispose();
            base.OnPaint(e);
        }
        #endregion



        //*****************************************************************************
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
            fillColor2 = uiColor.PanelFillColor2;
            fillColor = uiColor.PanelFillColor;
            rectColor = uiColor.PanelRectColor;
            foreColor = uiColor.PanelForeColor;

            fillDisableColor = uiColor.FillDisableColor;
            rectDisableColor = uiColor.RectDisableColor;
            foreDisableColor = uiColor.ForeDisableColor;

            fillReadOnlyColor = uiColor.FillDisableColor;
            rectReadOnlyColor = uiColor.RectDisableColor;
            foreReadOnlyColor = uiColor.ForeDisableColor;
        }
        public void SetStyle(UIStyle style)
        {
            this.SuspendLayout();
            UIStyleHelper.SetChildUIStyle(this, style);

            if (!style.IsCustom())
            {
                SetStyleColor(style.Colors());
                Invalidate();
            }

            _style = style;
            this.ResumeLayout();
        }
        public virtual void SetDPIScale()
        {
            if (DesignMode) return;
            if (!IsScaled)
            {
                this.SetDPIScaleFont();
                IsScaled = true;
            }
        }
        #endregion



        //*****************************************************************************
        #region Override IZoomScale 
        [Browsable(false)]
        public Rectangle ZoomScaleRect { get; set; }
        [DefaultValue(false), Category("SunnyUI"), Description("获取或设置控件跟随窗体缩放")]
        public bool ZoomScaleDisabled { get; set; }
        public virtual void SetZoomScale(float scale)
        {

        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
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
        /// <summary>边框显示位置改变时发生</summary>
        protected virtual void OnRectSidesChange()
        {
        }
        /// <summary>圆角显示位置改变时发生</summary>
        protected virtual void OnRadiusSidesChange()
        {
        }
        protected virtual void OnPaintFill(Graphics g, GraphicsPath path)
        {
            Color color = GetFillColor();

            if (_fillColorGradient)
            {
                LinearGradientBrush br = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), FillColor, FillColor2);
                br.GammaCorrection = true;

                if (RadiusSides == UICornerRadiusSides.None)
                    g.FillRectangle(br, ClientRectangle);
                else
                    g.FillPath(br, path);

                br.Dispose();
            }
            else
            {
                if (RadiusSides == UICornerRadiusSides.None || Radius == 0)
                    g.Clear(color);
                else
                    g.FillPath(color, path);
            }
        }
        /// <summary>重绘边框</summary>
        /// <param name="g"></param>
        /// <param name="path"></param>
        protected virtual void OnPaintRect(Graphics g, GraphicsPath path)
        {
            _radius = Math.Min(_radius, Math.Min(Width, Height));
            if (RectSides == ToolStripStatusLabelBorderSides.None)
            {
                return;
            }

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
        protected virtual void OnPaintFore(Graphics g, GraphicsPath path)
        {
            string text = Text;
            if (!showText && Text.IsValid()) text = "";
            g.DrawString(text, Font, GetForeColor(), Size, Padding, TextAlignment);
        }
        protected Color GetRectColor()
        {
            return Enabled ? (isReadOnly ? rectReadOnlyColor : rectColor) : rectDisableColor;
        }
        protected Color GetForeColor()
        {
            return Enabled ? (isReadOnly ? foreReadOnlyColor : foreColor) : foreDisableColor;
        }
        protected Color GetFillColor()
        {
            return Enabled ? (isReadOnly ? fillReadOnlyColor : fillColor) : fillDisableColor;
        }
        /// <summary>圆角角度改变时发生</summary>
        /// <param name="value"></param>
        protected virtual void OnRadiusChanged(int value)
        {
        }
        protected virtual void AfterSetFillColor(Color color)
        {
        }

        protected virtual void AfterSetRectColor(Color color)
        {
        }

        protected virtual void AfterSetForeColor(Color color)
        {
        }

        protected virtual void AfterSetFillReadOnlyColor(Color color)
        {
        }

        protected virtual void AfterSetRectReadOnlyColor(Color color)
        {
        }

        protected virtual void AfterSetForeReadOnlyColor(Color color)
        {
        }

        /// <summary>设置填充只读颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetFillReadOnlyColor(Color color)
        {
            fillReadOnlyColor = color;
            AfterSetFillReadOnlyColor(color);
            SetStyleCustom();
        }
        /// <summary>设置边框只读颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetRectReadOnlyColor(Color color)
        {
            rectReadOnlyColor = color;
            AfterSetRectReadOnlyColor(color);
            SetStyleCustom();
        }
        protected void SetFillDisableColor(Color color)
        {
            fillDisableColor = color;
            SetStyleCustom();
        }
        protected void SetRectDisableColor(Color color)
        {
            rectDisableColor = color;
            SetStyleCustom();
        }
        protected void SetForeDisableColor(Color color)
        {
            foreDisableColor = color;
            SetStyleCustom();
        }
        protected void SetStyleCustom(bool needRefresh = true)
        {
            _style = UIStyle.Custom;
            if (needRefresh) Invalidate();
        }
        #endregion



        //*****************************************************************************
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
