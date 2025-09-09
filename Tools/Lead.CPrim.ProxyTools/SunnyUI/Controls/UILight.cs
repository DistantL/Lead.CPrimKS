/******************************************************************************
 * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
 * CopyRight (C) 2012-2022 ShenYongHua(沈永华).
 * QQ群：56829229 QQ：17612584 EMail：SunnyUI@QQ.Com
 *
 * Blog:   https://www.cnblogs.com/yhuse
 * Gitee:  https://gitee.com/yhuse/SunnyUI
 * GitHub: https://github.com/yhuse/SunnyUI
 *
 * SunnyUI.dll can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 文件名称: UILight.cs
 * 文件说明: 提示灯
 * 当前版本: V3.1
 * 创建日期: 2020-01-01
 *
 * 2020-01-01: V2.2.0 增加文件说明
 * 2021-06-19: V3.0.4 增加方形显示，优化渐变色
 * 2021-08-07: V3.0.5 默认不显示灯光亮线
******************************************************************************/

using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#pragma warning disable CS1591
namespace Sunny.UI
{
    public enum UILightState
    {
        On,
        Off,
        Blink
    }

    [ToolboxItem(true)]
    public sealed class UILight : UIControl
    {
        #region Field
        /// <summary>定时器</summary>
        private Timer timer;
        /// <summary>闪烁状态</summary>
        private bool blinkState;
        #endregion



        #region Prop
        private UIShape sharpType = UIShape.Circle;
        /// <summary>显示形状：圆形，正方形</summary>
        [DefaultValue(UIShape.Circle), Description("显示形状：圆形，正方形"), Category("SunnyUI")]
        public UIShape Shape
        {
            get => sharpType;
            set
            {
                if (sharpType != value)
                {
                    sharpType = value;
                    Invalidate();
                }
            }
        }

        private int interval = 500;
        [DefaultValue(500), Description("闪烁显示间隔（100-10000）"), Category("SunnyUI")]
        public int Interval
        {
            get => interval;
            set
            {
                interval = Math.Max(100, value);
                interval = Math.Min(interval, 10000);
                if (timer != null)
                {
                    bool isRun = timer.Enabled;
                    timer.Stop();
                    timer.Interval = interval;
                    if (isRun)
                    {
                        timer.Start();
                    }
                }
            }
        }

        private UILightState state = UILightState.On;
        [DefaultValue(UILightState.On), Description("显示状态"), Category("SunnyUI")]
        public UILightState State
        {
            get => state;
            set
            {
                state = value;
                timer?.Stop();

                if (state == UILightState.Blink)
                {
                    if (timer == null)
                    {
                        timer = new Timer { Interval = interval };
                        timer.Tick += Timer_Tick;
                    }

                    blinkState = true;
                    timer.Start();
                }

                Invalidate();
            }
        }

        private bool showCenterColor = true;
        [DefaultValue(true), Description("是否显示中心颜色"), Category("SunnyUI")]
        public bool ShowCenterColor
        {
            get => showCenterColor;
            set
            {
                showCenterColor = value;
                Invalidate();
            }
        }

        private bool showLightLine;
        [DefaultValue(false), Description("显示灯光亮线"), Category("SunnyUI")]
        public bool ShowLightLine
        {
            get => showLightLine;
            set
            {
                showLightLine = value;
                Invalidate();
            }
        }

        private Color _onColor = UIColor.Green;
        [DefaultValue(typeof(Color), "110, 190, 40"), Description("打开状态边缘颜色"), Category("SunnyUI")]
        public Color OnColor
        {
            get => _onColor;
            set
            {
                _onColor = value;
                Invalidate();
            }
        }

        private Color _centerColor = UIColor.White;
        [DefaultValue(typeof(Color), "White"), Description("打开状态中心颜色"), Category("SunnyUI")]
        public Color OnCenterColor
        {
            get => _centerColor;
            set => _centerColor = value;
        }

        private Color _offColor = UIColor.Gray;
        [DefaultValue(typeof(Color), "140, 140, 140"), Description("关闭状态边缘颜色"), Category("SunnyUI")]
        public Color OffColor
        {
            get => _offColor;
            set
            {
                _offColor = value;
                Invalidate();
            }
        }

        private Color _offCenterColor = UIColor.White;
        [DefaultValue(typeof(Color), "White"), Description("关闭状态中心颜色"), Category("SunnyUI")]
        public Color OffCenterColor
        {
            get => _offCenterColor;
            set
            {
                _offCenterColor = value;
                Invalidate();
            }
        }
        #endregion



        #region Ctor
        public UILight()
        {
            SetStyleFlags(true, false);
            ShowRect = false;
            ShowText = false;
            Radius = Width = Height = 35;
        }
        #endregion



        #region System_Event
        protected override void OnPaintFill(Graphics g, GraphicsPath path)
        {
            int ShowSize = Math.Min(Width, Height);

            //边缘颜色
            Color color = State == UILightState.On ? OnColor: 
                (State == UILightState.Off ? OffColor :
                (blinkState ? _onColor : _offColor));

            //中心颜色
            Color cColor = state == UILightState.On ? OnCenterColor :
                (State == UILightState.Off ? OffCenterColor : 
                (blinkState ? OnCenterColor : OffCenterColor));

            if (Shape == UIShape.Circle)
            {
                if (Radius != ShowSize) Radius = ShowSize;
                using (GraphicsPath CirclePath = new GraphicsPath())
                {
                    CirclePath.AddEllipse(2, 2, ShowSize - 4, ShowSize - 4);
                    g.Smooth();

                    if (ShowCenterColor)
                    {
                        PathGradientBrush gradientBrush = new PathGradientBrush(path)
                        {
                            CenterPoint = new PointF(ShowSize / 2.0f, ShowSize / 2.0f),
                            CenterColor = cColor,
                            SurroundColors = new Color[] { color }
                        };
                        g.FillPath(gradientBrush, CirclePath);
                        gradientBrush.Dispose();
                    }
                    else
                    {
                        g.FillPath(color, CirclePath);
                    }
                }

                if (ShowLightLine)
                {
                    int size = (ShowSize - 4) / 5;
                    g.DrawArc(cColor, size, size, ShowSize - size * 2, ShowSize - size * 2, 45, -155);
                }
            }
            else if (Shape == UIShape.Square)
            {
                if (Radius != 0) Radius = 0;

                if (ShowCenterColor)
                {
                    GraphicsPath CirclePath = new GraphicsPath();
                    Point[] p = {
                        new Point(3,3),new Point(ShowSize-3,3),
                        new Point(ShowSize-3,ShowSize-3),new Point(3,ShowSize-3)
                    };

                    CirclePath.AddLines(p);
                    g.Smooth();

                    Color[] surroundColor = new Color[] { color };
                    PathGradientBrush gradientBrush = new PathGradientBrush(path);
                    gradientBrush.CenterPoint = new PointF(ShowSize / 2.0f, ShowSize / 2.0f);
                    gradientBrush.CenterColor = cColor;
                    gradientBrush.SurroundColors = surroundColor;
                    g.FillPath(gradientBrush, CirclePath);
                    gradientBrush.Dispose();
                    CirclePath.Dispose();
                }
                else
                {
                    g.FillRoundRectangle(color, 2, 2, ShowSize - 4, ShowSize - 4, 5);
                }
            }
        }
        #endregion



        #region Method_InternalUsing
        private void Timer_Tick(object sender, EventArgs e)
        {
            blinkState = !blinkState;
            Invalidate();
        }
        #endregion
    }
}