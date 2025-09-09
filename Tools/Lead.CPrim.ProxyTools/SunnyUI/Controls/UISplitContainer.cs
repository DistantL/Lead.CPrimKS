/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UISplitContainer.cs
 * Author: Victor
 * Description: 分割容器
 * CreateTime: 2021-10-30
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2021-10-30: V3.0.8 增加文件说明
 * 2022-04-03: V3.1.3 增加主题样式
 * 
 * <3.3.23.0101><Victor><20230115>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Fonts;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    public sealed class UISplitContainer : SplitContainer, IStyleInterface, IZoomScale
    {
        #region Event
        public event EventHandler CollapseClick
        {
            add => Events.AddHandler(EventCollapseClick, value);
            remove => Events.RemoveHandler(EventCollapseClick, value);
        }
        #endregion



        #region Field
        private enum UIMouseType
        {
            None,
            Button,
            Split
        }
        /// <summary>UISplitContainer状态</summary>
        public enum UISplitPanelState
        {
            /// <summary>关闭状态</summary>
            Collapsed = 0,
            /// <summary>展开状态</summary>
            Expanded = 1,
        }

        private enum UIControlState
        {
            /// <summary>正常。</summary>
            Normal,
            /// <summary>鼠标进入。</summary>
            Hover,
        }

        public enum UICollapsePanel
        {
            None = 0,
            Panel1 = 1,
            Panel2 = 2,
        }

        private UICollapsePanel _collapsePanel = UICollapsePanel.Panel1;
        private UISplitPanelState _splitPanelState = UISplitPanelState.Expanded;
        private UIControlState _uiControlState;
        private int _lastDistance;
        private int _minSize;
        private UIMouseType _uiMouseType;
        private readonly object EventCollapseClick = new object();
        #endregion



        #region Prop
        private Color barColor = Color.FromArgb(56, 56, 56);
        /// <summary>分割栏背景色</summary>
        [DefaultValue(typeof(Color), "56, 56, 56"), Category("SunnyUI")]
        [Description("分割栏背景色")]
        public Color BarColor
        {
            get => barColor;
            set
            {
                barColor = value;
                Invalidate();
            }
        }

        private Color handleColor = Color.FromArgb(106, 106, 106);
        /// <summary>分割栏按钮背景色</summary>
        [DefaultValue(typeof(Color), "106, 106, 106"), Category("SunnyUI")]
        [Description("分割栏按钮背景色")]
        public Color HandleColor
        {
            get => handleColor;
            set
            {
                handleColor = value;
                Invalidate();
            }
        }

        private Color handleHoverColor = Color.FromArgb(186, 186, 186);
        /// <summary>分割栏按钮鼠标移上背景色</summary>
        [DefaultValue(typeof(Color), "186, 186, 186"), Category("SunnyUI")]
        [Description("分割栏按钮鼠标移上背景色")]
        public Color HandleHoverColor
        {
            get => handleHoverColor;
            set
            {
                handleHoverColor = value;
                Invalidate();
            }
        }

        private Color arrowColor = Color.FromArgb(80, 160, 255);
        /// <summary>分割栏按钮箭头背景色</summary>
        [DefaultValue(typeof(Color), "80, 160, 255"), Category("SunnyUI")]
        [Description("分割栏按钮箭头背景色")]
        public Color ArrowColor
        {
            get => arrowColor;
            set
            {
                arrowColor = value;
                SetStyleCustom();
            }
        }

        [DefaultValue(UICollapsePanel.Panel1), Category("SunnyUI")]
        [Description("点击后收起的Panel")]
        public UICollapsePanel CollapsePanel
        {
            get => _collapsePanel;
            set
            {
                if (_collapsePanel != value)
                {
                    Expand();
                    _collapsePanel = value;
                    Invalidate();
                }
            }
        }

        private Rectangle CollapseRect
        {
            get
            {
                if (_collapsePanel == UICollapsePanel.None)
                {
                    return Rectangle.Empty;
                }

                Rectangle rect = SplitterRectangle;
                if (Orientation == Orientation.Horizontal)
                {
                    rect.X = (Width - DefaultCollapseWidth) / 2;
                    rect.Width = DefaultCollapseWidth;
                }
                else
                {
                    rect.Y = (Height - DefaultCollapseWidth) / 2;
                    rect.Height = DefaultCollapseWidth;
                }

                return rect;
            }
        }

        public UISplitPanelState SplitPanelState
        {
            get => _splitPanelState;
            set
            {
                if (_splitPanelState != value)
                {
                    switch (value)
                    {
                        case UISplitPanelState.Expanded:
                            Expand();
                            break;
                        case UISplitPanelState.Collapsed:
                            Collapse();
                            break;

                    }

                    _splitPanelState = value;
                }
            }
        }

        private UIControlState ControlState
        {
            set
            {
                if (_uiControlState != value)
                {
                    _uiControlState = value;
                    Invalidate(CollapseRect);
                }
            }
        }

        private int DefaultCollapseWidth => 80;

        private int DefaultArrowWidth => 24;
        #endregion



        #region Ctor
        public UISplitContainer()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
            _lastDistance = SplitterDistance;
            SplitterWidth = 10;
            MinimumSize = new Size(20, 20);
            Version = UIGlobal.UIVersion;
        }
        #endregion



        #region System_Event
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
            Invalidate(SplitterRectangle);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Panel1Collapsed || Panel2Collapsed)
            {
                return;
            }

            Rectangle rect = SplitterRectangle;
            bool bHorizontal = Orientation == Orientation.Horizontal;

            e.Graphics.FillRectangle(BarColor, rect);
            if (_collapsePanel == UICollapsePanel.None)
            {
                return;
            }

            if (SplitterWidth < 11) SplitterWidth = 11;

            Rectangle arrowRect = CalcArrowRect(CollapseRect);
            Color handleRectColor = _uiControlState == UIControlState.Hover ? handleHoverColor : HandleColor;
            Point[] points = GetHandlePoints();
            using (Brush br = new SolidBrush(handleRectColor))
            {
                e.Graphics.SetHighQuality();
                e.Graphics.FillPolygon(br, points);
                e.Graphics.SetDefaultQuality();
            }

            switch (_collapsePanel)
            {
                case UICollapsePanel.Panel1:
                    if (bHorizontal)
                    {
                        e.Graphics.DrawFontImage(SplitPanelState == UISplitPanelState.Collapsed ? 61703 : 61702,
                            22, arrowColor, arrowRect);
                    }
                    else
                    {
                        e.Graphics.DrawFontImage(SplitPanelState == UISplitPanelState.Collapsed ? 61701 : 61700,
                            22, arrowColor, arrowRect);
                    }
                    break;
                case UICollapsePanel.Panel2:
                    if (bHorizontal)
                    {
                        e.Graphics.DrawFontImage(SplitPanelState == UISplitPanelState.Collapsed ? 61702 : 61703,
                            22, arrowColor, arrowRect);
                    }
                    else
                    {
                        e.Graphics.DrawFontImage(SplitPanelState == UISplitPanelState.Collapsed ? 61700 : 61701,
                            22, arrowColor, arrowRect);
                    }
                    break;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //如果鼠标的左键没有按下，重置鼠标状态
            if (e.Button != MouseButtons.Left)
            {
                _uiMouseType = UIMouseType.None;
            }

            Rectangle collapseRect = CollapseRect;
            Point mousePoint = e.Location;

            //鼠标在Button矩形里，并且不是在拖动
            if (collapseRect.Contains(mousePoint) && _uiMouseType != UIMouseType.Split)
            {
                Capture = false;
                SetCursor(Cursors.Hand);
                ControlState = UIControlState.Hover;
                return;
            }

            //鼠标在分隔栏矩形里
            if (SplitterRectangle.Contains(mousePoint))
            {
                ControlState = UIControlState.Normal;

                //如果已经在按钮按下了鼠标或者已经收缩，就不允许拖动了
                if (_uiMouseType == UIMouseType.Button ||
                    _collapsePanel != UICollapsePanel.None && SplitPanelState == UISplitPanelState.Collapsed)
                {
                    Capture = false;
                    Cursor = Cursors.Default;
                    return;
                }

                //鼠标没有按下，设置Split光标
                if (_uiMouseType == UIMouseType.None && !IsSplitterFixed)
                {
                    SetCursor(Orientation == Orientation.Horizontal ? Cursors.HSplit : Cursors.VSplit);
                    return;
                }
            }

            ControlState = UIControlState.Normal;

            //正在拖动分隔栏
            if (_uiMouseType == UIMouseType.Split && !IsSplitterFixed)
            {
                SetCursor(Orientation == Orientation.Horizontal ? Cursors.HSplit : Cursors.VSplit);
                base.OnMouseMove(e);
                return;
            }

            Cursor = Cursors.Default;
            base.OnMouseMove(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            Cursor = Cursors.Default;
            ControlState = UIControlState.Normal;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Rectangle collapseRect = CollapseRect;
            Point mousePoint = e.Location;

            if (collapseRect.Contains(mousePoint) ||
                _collapsePanel != UICollapsePanel.None &&
                 SplitPanelState == UISplitPanelState.Collapsed)
            {
                _uiMouseType = UIMouseType.Button;
                return;
            }

            if (SplitterRectangle.Contains(mousePoint))
            {
                _uiMouseType = UIMouseType.Split;
            }

            base.OnMouseDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            Invalidate(SplitterRectangle);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Invalidate(SplitterRectangle);

            Rectangle collapseRect = CollapseRect;
            Point mousePoint = e.Location;

            if (_uiMouseType == UIMouseType.Button && e.Button == MouseButtons.Left && collapseRect.Contains(mousePoint))
            {
                OnCollapseClick(EventArgs.Empty);
            }

            _uiMouseType = UIMouseType.None;
        }
        #endregion



        #region Override IStyleInterface
        private UIStyle _style = UIStyle.Blue;
        [DefaultValue(UIStyle.Blue), Description("主题样式"), Category("SunnyUI")]
        public UIStyle Style
        {
            get => _style;
            set => SetStyle(value);
        }

        [DefaultValue(false)]
        [Description("获取或设置可以自定义主题风格"), Category("SunnyUI")]
        public bool StyleCustomMode { get; set; }

        public string Version
        {
            get;
        }

        [DefaultValue(null)]
        [Description("获取或设置包含有关控件的数据的对象字符串"), Category("SunnyUI")]
        public string TagString
        {
            get; set;
        }

        [Browsable(false), DefaultValue(false)]
        public bool IsScaled { get; set; }

        public void SetStyleColor(UIBaseStyle uiColor)
        {
            arrowColor = uiColor.SplitContainerArrowColor;
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
        public void SetDPIScale()
        {
            //
        }
        #endregion



        #region Override IZoomScale
        [DefaultValue(false), Category("SunnyUI"), Description("禁止控件跟随窗体缩放")]
        public bool ZoomScaleDisabled { get; set; }

        [Browsable(false)]
        public Rectangle ZoomScaleRect { get; set; }

        public void SetZoomScale(float scale)
        {

        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>关闭</summary>
        public void Collapse()
        {
            if (_collapsePanel != UICollapsePanel.None && SplitPanelState == UISplitPanelState.Expanded)
            {
                _lastDistance = SplitterDistance;
                if (_collapsePanel == UICollapsePanel.Panel1)
                {
                    _minSize = Panel1MinSize;
                    Panel1MinSize = 0;
                    SplitterDistance = 0;
                }
                else
                {
                    int width = Orientation == Orientation.Horizontal ?
                        Height : Width;
                    _minSize = Panel2MinSize;
                    Panel2MinSize = 0;
                    SplitterDistance = width - SplitterWidth - Padding.Vertical;
                }

                Invalidate(SplitterRectangle);
            }
        }
        /// <summary>展开</summary>
        public void Expand()
        {
            if (_collapsePanel != UICollapsePanel.None &&
                SplitPanelState == UISplitPanelState.Collapsed)
            {
                if (_collapsePanel == UICollapsePanel.Panel1)
                {
                    Panel1MinSize = _minSize;
                }
                else
                {
                    Panel2MinSize = _minSize;
                }

                SplitterDistance = _lastDistance;
                Invalidate(SplitterRectangle);
            }
        }
        #endregion



        #region Method_InternalUsing
        private void SetStyleCustom(bool needRefresh = true)
        {
            _style = UIStyle.Custom;
            if (needRefresh) Invalidate();
        }
        private void OnCollapseClick(EventArgs e)
        {
            SplitPanelState = SplitPanelState == UISplitPanelState.Collapsed ?
                UISplitPanelState.Expanded : UISplitPanelState.Collapsed;
            EventHandler handler = Events[EventCollapseClick] as EventHandler;
            handler?.Invoke(this, e);
        }
        private Point[] GetHandlePoints()
        {
            bool bCollapsed = SplitPanelState == UISplitPanelState.Collapsed;

            if (Orientation == Orientation.Horizontal)
            {
                if (CollapsePanel == UICollapsePanel.Panel1 && !bCollapsed ||
                    CollapsePanel == UICollapsePanel.Panel2 && bCollapsed)
                {
                    return new[]
                    {
                        new Point(CollapseRect.Left + 2, CollapseRect.Top),
                        new Point(CollapseRect.Right - 2, CollapseRect.Top),
                        new Point(CollapseRect.Right, CollapseRect.Bottom),
                        new Point(CollapseRect.Left, CollapseRect.Bottom),
                        new Point(CollapseRect.Left + 2, CollapseRect.Top)
                    };
                }

                if (CollapsePanel == UICollapsePanel.Panel1 && bCollapsed ||
                    CollapsePanel == UICollapsePanel.Panel2 && !bCollapsed)
                {
                    return new[]
                    {
                        new Point(CollapseRect.Left, CollapseRect.Top),
                        new Point(CollapseRect.Right, CollapseRect.Top),
                        new Point(CollapseRect.Right - 2, CollapseRect.Bottom),
                        new Point(CollapseRect.Left + 2, CollapseRect.Bottom),
                        new Point(CollapseRect.Left, CollapseRect.Top)
                    };
                }
            }

            if (Orientation == Orientation.Vertical)
            {
                if (CollapsePanel == UICollapsePanel.Panel1 && !bCollapsed ||
                    CollapsePanel == UICollapsePanel.Panel2 && bCollapsed)
                {
                    return new[]
                    {
                        new Point(CollapseRect.Left, CollapseRect.Top + 2),
                        new Point(CollapseRect.Right, CollapseRect.Top),
                        new Point(CollapseRect.Right, CollapseRect.Bottom),
                        new Point(CollapseRect.Left, CollapseRect.Bottom - 2),
                        new Point(CollapseRect.Left, CollapseRect.Top + 2)
                    };
                }

                if (CollapsePanel == UICollapsePanel.Panel1 && bCollapsed ||
                    CollapsePanel == UICollapsePanel.Panel2 && !bCollapsed)
                {
                    return new[]
                    {
                        new Point(CollapseRect.Left,CollapseRect.Top),
                        new Point(CollapseRect.Right,CollapseRect.Top+2),
                        new Point(CollapseRect.Right,CollapseRect.Bottom-2),
                        new Point(CollapseRect.Left,CollapseRect.Bottom),
                        new Point(CollapseRect.Left,CollapseRect.Top)
                    };
                }
            }

            return new Point[0];
        }
        private void SetCursor(Cursor cursor)
        {
            if (Cursor != cursor)
            {
                Cursor = cursor;
            }
        }
        private Rectangle CalcArrowRect(Rectangle collapseRect)
        {
            if (Orientation == Orientation.Horizontal)
            {
                int width = (collapseRect.Width - DefaultArrowWidth) / 2;
                return new Rectangle(
                    collapseRect.X + width,
                    collapseRect.Y - 1,
                    DefaultArrowWidth,
                    collapseRect.Height);
            }
            else
            {
                int width = (collapseRect.Height - DefaultArrowWidth) / 2;
                return new Rectangle(
                    collapseRect.X - 1,
                    collapseRect.Y + width,
                    collapseRect.Width,
                    DefaultArrowWidth);
            }
        }
        #endregion
    }
}
