/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIDropDown.cs
 * Author: Victor
 * Description: 下拉框弹出窗体控制类
 * CreateTime: 2020-01-01
 * Inherit：UIControl
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 *
 * <3.3.22.1010><Victor><20221011>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.DropItem
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.DropItem
{
    /// <summary>下拉框弹出窗体控制类</summary>
    [ToolboxItem(false)]
    public sealed class UIDropDown : ToolStripDropDown
    {
        private IContainer components;

        /// <summary>析构函数</summary>
        /// <param name="disposing">disposing</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();

                if (Item != null)
                {
                    UIDropDownItem _content = Item;
                    Item = null;
                    _content.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
        }

        private UIDropDownItem Item;
        private Control OpenItem;

        /// <summary>数值切换事件</summary>
        /// <param name="sender">sender</param>
        /// <param name="value">数值</param>
        public delegate void OnValueChanged(object sender, object value);

        /// <summary>
        /// 数值切换事件
        /// </summary>
        public event OnValueChanged ValueChanged;

        private void DoValueChanged(object sender, object value)
        {
            ValueChanged?.Invoke(this, value);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="item">下拉框弹出窗体基类</param>
        public UIDropDown(UIDropDownItem item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            Item.ValueChanged += DoValueChanged;

            InitializeComponent();
            AutoSize = false;
            DoubleBuffered = true;
            //ResizeRedraw = true;
            ToolStripControlHost _host = new ToolStripControlHost(item);
            Padding = Margin = _host.Padding = _host.Margin = Padding.Empty;
            item.MinimumSize = item.Size;
            item.MaximumSize = item.Size;
            Size = item.Size;
            TabStop = item.TabStop = true;
            item.Location = Point.Empty;
            Items.Add(_host);
            item.Disposed += (sender, e) =>
            {
                item = null;
                Dispose(true);
            };

            item.RegionChanged += (sender, e) => UpdateRegion();
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (Region != null)
            {
                Region.Dispose();
                Region = null;
            }

            if (Item.Region != null)
            {
                Region = Item.Region.Clone();
            }
        }

        /// <summary>显示</summary>
        /// <param name="control">Control</param>
        public void Show(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            Show(control, control.ClientRectangle, new Point(0, 0));
        }

        /// <summary>显示</summary>
        /// <param name="control">Control</param>
        /// <param name="size">大小</param>
        /// <param name="offset"></param>
        public void Show(Control control, Size size, Point offset)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            Size = size;
            Show(control, control.ClientRectangle, offset);
        }

        /// <summary>显示</summary>
        /// <param name="control">Control</param>
        /// <param name="size">大小</param>
        public void Show(Control control, Size size)
        {
            Size = size;
            Show(control);
        }

        /// <summary>显示</summary>
        /// <param name="area">区域</param>
        public void Show(Rectangle area)
        {
            Point location = new Point(area.Left, area.Top + area.Height);
            Rectangle screen = Screen.FromControl(this).WorkingArea;
            if (location.X + Size.Width > screen.Left + screen.Width)
            {
                location.X = screen.Left + screen.Width - Size.Width;
            }

            if (location.Y + Size.Height > screen.Top + screen.Height)
            {
                location.Y -= Size.Height + area.Height;
            }

            Show(location, ToolStripDropDownDirection.BelowRight);
        }

        /// <summary>显示</summary>
        /// <param name="control">Control</param>
        /// <param name="area">区域</param>
        /// <param name="offset"></param>
        public void Show(Control control, Rectangle area, Point offset)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            SetOwnerItem(control);

            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;

            location.X += offset.X;
            location.Y += offset.Y;

            if (location.X + Size.Width > screen.Left + screen.Width)
            {
                location.X = screen.Left + screen.Width - Size.Width;
            }

            if (location.Y + Size.Height > screen.Top + screen.Height)
            {
                location.Y -= Size.Height + area.Height;
            }

            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        private void SetOwnerItem(Control control)
        {
            if (control == null)
            {
                return;
            }

            if (control is UIDropDown ctrl)
            {
                OwnerItem = ctrl.Items[0];
                return;
            }
            else if (OpenItem == null)
            {
                OpenItem = control;
            }

            if (control.Parent != null)
            {
                SetOwnerItem(control.Parent);
            }
        }

        /// <summary>OnSizeChanged</summary>
        /// <param name="e">e</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Item != null)
            {
                Item.MinimumSize = Size;
                Item.MaximumSize = Size;
                Item.Size = Size;
                Item.Location = Point.Empty;
            }

            base.OnSizeChanged(e);
        }

        /// <summary>OnLayout</summary>
        /// <param name="e">e</param>
        protected override void OnLayout(LayoutEventArgs e)
        {
            Size suggestedSize = GetPreferredSize(Size.Empty);
            if (AutoSize && suggestedSize != Size)
            {
                Size = suggestedSize;
            }

            SetDisplayedItems();
            OnLayoutCompleted(EventArgs.Empty);
            Invalidate();
        }

        /// <summary>OnOpening</summary>
        /// <param name="e">e</param>
        protected override void OnOpening(CancelEventArgs e)
        {
            if (Item.IsDisposed || Item.Disposing)
            {
                e.Cancel = true;
                return;
            }

            UpdateRegion();
            base.OnOpening(e);
        }

        /// <summary>OnOpened</summary>
        /// <param name="e">e</param>
        protected override void OnOpened(EventArgs e)
        {
            Item.Focus();
            Item.InitShow();
            base.OnOpened(e);
        }

        /// <summary>OnClosed</summary>
        /// <param name="e">e</param>
        protected override void OnClosed(ToolStripDropDownClosedEventArgs e)
        {
            OpenItem = null;
            base.OnClosed(e);
        }

        /// <summary>设置边框颜色</summary>
        /// <param name="color">颜色</param>
        public void SetRectColor(Color color)
        {
            Item?.SetRectColor(color);
        }

        /// <summary>设置填充颜色</summary>
        /// <param name="color">颜色</param>
        public void SetFillColor(Color color)
        {
            Item?.SetFillColor(color);
        }

        /// <summary>设置字体颜色</summary>
        /// <param name="color">颜色</param>
        public void SetForeColor(Color color)
        {
            Item?.SetForeColor(color);
        }

        public void SetStyle(UIBaseStyle style)
        {
            Item?.SetStyleColor(style);
        }
    }
}