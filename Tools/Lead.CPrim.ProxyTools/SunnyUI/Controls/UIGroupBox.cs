/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIGroupBox.cs
 * Author: Victor
 * Description: 组框
 * CreateTime: 2020-01-01
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-25: V2.2.4 更新主题配置类
 * 
 * <3.3.23.0101><Victor><20230110>
 * 1、初版1.0
******************************************************************************/

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    [DefaultProperty("Text")]
    public partial class UIGroupBox : UIPanel
    {
        public UIGroupBox()
        {
            InitializeComponent();
            SetStyleFlags(true, false);
        }

        protected override void OnPaintFill(Graphics g, GraphicsPath path)
        {
            g.Clear(FillColor);
        }

        protected override void OnPaintRect(Graphics g, GraphicsPath path)
        {
            path = new Rectangle(0, TitleTop, Width - 1, Height - _titleTop - 1).CreateRoundedRectanglePath(Radius, RadiusSides);
            base.OnPaintRect(g, path);
        }

        protected override void OnPaintFore(Graphics g, GraphicsPath path)
        {
            SizeF sf = g.MeasureString(Text, Font);

            float left = TitleInterval;
            if (TitleAlignment == HorizontalAlignment.Right)
                left = Width - TitleInterval - sf.Width;
            if (TitleAlignment == HorizontalAlignment.Center)
                left = (Width - sf.Width) / 2.0f;

            float top = TitleTop - sf.Height / 2.0f;
            g.FillRectangle(FillColor, left - 2, top, sf.Width + 2, sf.Height);
            g.DrawString(Text, Font, ForeColor, left, top);
        }

        private int _titleTop = 16;

        [DefaultValue(16)]
        [Description("标题高度"), Category("SunnyUI")]
        public int TitleTop
        {
            get => _titleTop;
            set
            {
                if (_titleTop != value)
                {
                    _titleTop = value;
                    Padding = new Padding(0, value + 16, 0, 0);
                    Invalidate();
                }
            }
        }

        private int _titleInterval = 10;

        [DefaultValue(10)]
        [Description("标题显示间隔"), Category("SunnyUI")]
        public int TitleInterval
        {
            get => _titleInterval;
            set
            {
                if (_titleInterval != value)
                {
                    _titleInterval = value;
                    Invalidate();
                }
            }
        }

        public HorizontalAlignment titleAlignment = HorizontalAlignment.Left;

        [DefaultValue(HorizontalAlignment.Left)]
        [Description("文字显示位置"), Category("SunnyUI")]
        public HorizontalAlignment TitleAlignment
        {
            get => titleAlignment;
            set
            {
                if (titleAlignment != value)
                {
                    titleAlignment = value;
                    Invalidate();
                }
            }
        }
    }
}