using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    public sealed class UISwitchStyle : UICheckBox
    {
        public UISwitchStyle() : base()
        {
            SetStyleFlags();
            AutoSize = false;
            Width = 180;
            Height = 35;
        }

        private bool _autoSize = false;
        [Browsable(false), DefaultValue(false)]
        public new bool AutoSize
        {
            get => _autoSize;
            set
            {
                _autoSize = value;
                Invalidate();
            }
        }

        private Color _backColor = Color.FromArgb(235, 235, 235);
        [Browsable(true), DefaultValue(typeof(Color), "235, 235, 235"), Description("背景色")]
        [Category("Appearance")]
        public new Color BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                Invalidate();
            }
        }

        private Color _outlineColor = Color.FromArgb(203, 203, 203);
        [Browsable(true), DefaultValue(typeof(Color), "203, 203, 203"), Description("按钮外框颜色")]
        [Category("Appearance")]
        public Color OutlineColor 
        { 
            get => _outlineColor; 
            set
            {
                _outlineColor = value;
                Invalidate();
            }
        }

        private int _outlineSize = 2;
        [Browsable(true), DefaultValue(2), Description("内外边框的距离")]
        [Category("Appearance")]
        public int OutlineSize
        {
            get => _outlineSize;
            set
            {
                _outlineSize = value;
                Invalidate();
            }
        }

        private Color _inlineColor = Color.White;
        [Browsable(true), DefaultValue(typeof(Color), "White"), Description("悬浮框颜色")]
        [Category("Appearance")]
        public Color InlineColor
        {
            get => _inlineColor;
            set
            {
                _inlineColor = value;
                Invalidate();
            }
        }

        private int _inlineSize = 2;
        [Browsable(true), DefaultValue(2), Description("悬浮框距离内边框的距离")]
        [Category("Appearance")]
        public int InlineSize 
        { 
            get => _inlineSize; 
            set
            {
                _inlineSize = value;
                Invalidate();
            }
        }

        public int _cornerRadius = 5;
        [Browsable(true), DefaultValue(5), Description("圆弧半径")]
        [Category("Appearance")]
        public int CornerRadius 
        {
            get => _cornerRadius; 
            set
            {
                _cornerRadius = value;
                Invalidate();
            }
        }

        private string _unCheckedText = "Main";
        [Browsable(true), DefaultValue("Main"), Description("非选中状态，选中左侧区域")]
        [Category("Appearance")]
        public string UnCheckedText
        {
            get => _unCheckedText;
            set
            {
                _unCheckedText = value;
                Invalidate();
            }
        }

        private string _checkedText = "Vendor";
        [Browsable(true), DefaultValue("Vendor"), Description("选中状态，选中右侧区域")]
        [Category("Appearance")]
        public string CheckedText
        {
            get => _checkedText;
            set
            {
                _checkedText = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;
            g.Smooth();
            g.Clear(this.BackColor);
            var rt1 = new Rectangle(OutlineSize + InlineSize, OutlineSize + InlineSize, this.Size.Width / 2 - OutlineSize * 2 - InlineSize * 2, this.Size.Height - OutlineSize * 2 - InlineSize * 2);

            var rt2 = new Rectangle(OutlineSize + InlineSize + this.Size.Width / 2, OutlineSize + InlineSize, this.Size.Width / 2 - OutlineSize * 2 - InlineSize * 2, this.Size.Height - OutlineSize * 2 - InlineSize * 2
             );

            FillRoundRectangle(g, new SolidBrush(Color.White), new Rectangle(0, 0, this.Size.Width, this.Size.Height), CornerRadius + 2);
            FillRoundRectangle(g, new SolidBrush(OutlineColor), new Rectangle(OutlineSize, OutlineSize, this.Size.Width - OutlineSize * 2, this.Size.Height - OutlineSize * 2), CornerRadius);

            if (!Checked)
            {
                FillRoundRectangle(g, new SolidBrush(InlineColor), rt1, CornerRadius);
            }
            else
            {
                FillRoundRectangle(g, new SolidBrush(InlineColor), rt2, CornerRadius);
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            if (!Checked)
            {
                g.DrawString(UnCheckedText, this.Font, new SolidBrush(Color.Black), rt1, sf);
                g.DrawString(CheckedText, this.Font, new SolidBrush(Color.White), rt2, sf);
            }
            else
            {
                g.DrawString(UnCheckedText, this.Font, new SolidBrush(Color.White), rt1, sf);
                g.DrawString(CheckedText, this.Font, new SolidBrush(Color.Black), rt2, sf);
            }
        }

        public static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }

        internal static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }

}
