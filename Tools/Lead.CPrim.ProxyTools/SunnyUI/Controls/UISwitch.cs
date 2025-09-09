/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UISwitch.cs
 * Author: Victor
 * Description: 开关
 * CreateTime: 2020-01-01
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-25: V2.2.4 更新主题配置类
 * 2021-05-06: V3.0.3 更新Active状态改变时触发ValueChanged事件
 * 2021-09-14: V3.0.7 增加Disabled颜色
 * 2022-01-02: V3.0.9 增加是否只读属性
 * 2022-03-19: V3.1.1 重构主题配色
 *
 * <3.3.22.1010><Victor><20221010>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Controls
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Active")]
    [ToolboxItem(true)]
    public sealed class UISwitch : UIControl
    {
        #region EventHandle & Event
        /// <summary>值改变时发生委托</summary>
        /// <param name="sender">对象</param>
        /// <param name="value">开关值</param>
        public delegate void OnValueChanged(object sender, bool value);
        /// <summary>值改变时发生</summary>
        public event OnValueChanged ValueChanged;
        /// <summary>激活改变时发生</summary>
        public event EventHandler ActiveChanged;
        #endregion



        #region Field
        public enum UISwitchShape
        {
            Round,
            Square
        }
        #endregion



        #region Prop
        /// <summary>true：只读</summary>
        [DefaultValue(false)]
        [Description("是否只读"), Category("SunnyUI")]
        public bool ReadOnly { get; set; }

        private UISwitchShape switchShape = UISwitchShape.Round;
        /// <summary>开关形状</summary>
        [Description("开关形状"), Category("SunnyUI")]
        [DefaultValue(UISwitchShape.Round)]
        public UISwitchShape SwitchShape
        {
            get => switchShape;
            set
            {
                switchShape = value;
                Invalidate();
            }
        }
        /// <summary>字体颜色</summary>
        [Description("字体颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "White")]
        public override Color ForeColor
        {
            get => foreColor;
            set => SetForeColor(value);
        }

        private bool activeValue;
        /// <summary>是否打开</summary>
        [DefaultValue(false)]
        [Description("是否打开"), Category("SunnyUI")]
        public bool Active
        {
            get => activeValue;
            set
            {
                if (activeValue != value)
                {
                    activeValue = value;
                    ValueChanged?.Invoke(this, value);
                    ActiveChanged?.Invoke(this, new EventArgs());
                    Invalidate();
                }
            }
        }

        private string activeText = "开";
        /// <summary>打开文字</summary>
        [DefaultValue("开")]
        [Description("打开文字"), Category("SunnyUI")]
        public string ActiveText
        {
            get => activeText;
            set
            {
                activeText = value;
                Invalidate();
            }
        }

        private string inActiveText = "关";
        /// <summary>关闭文字</summary>
        [DefaultValue("关")]
        [Description("关闭文字"), Category("SunnyUI")]
        public string InActiveText
        {
            get => inActiveText;
            set
            {
                inActiveText = value;
                Invalidate();
            }
        }

        private Color inActiveColor;
        /// <summary>关闭颜色</summary>
        [DefaultValue(typeof(Color), "Gray")]
        [Description("关闭颜色"), Category("SunnyUI")]
        public Color InActiveColor
        {
            get => inActiveColor;
            set
            {
                inActiveColor = value;
                Invalidate();
            }
        }

        /// <summary>填充颜色，当值为背景色或透明色或空值则不填充</summary>
        [Description("填充颜色，当值为背景色或透明色或空值则不填充"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "White")]
        public Color ButtonColor
        {
            get => fillColor;
            set => SetFillColor(value);
        }

        /// <summary>边框颜色</summary>
        [Description("打开颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "80, 160, 255")]
        public Color ActiveColor
        {
            get => rectColor;
            set => SetRectColor(value);
        }

        /// <summary>不可用颜色</summary>
        [Description("不可用颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "173, 178, 181")]
        public Color DisabledColor
        {
            get => rectDisableColor;
            set => SetRectDisableColor(value);
        }
        #endregion



        #region Ctor
        public UISwitch()
        {
            SetStyleFlags();
            Height = 29;
            Width = 75;
            ShowText = false;
            ShowRect = false;

            inActiveColor = Color.Gray;
            fillColor = Color.White;

            rectColor = UIStyles.Blue.SwitchActiveColor;
            fillColor = UIStyles.Blue.SwitchFillColor;
            inActiveColor = UIStyles.Blue.SwitchInActiveColor;
            rectDisableColor = UIStyles.Blue.SwitchRectDisableColor;
        }
        #endregion



        #region Method_Override
        protected override void OnClick(EventArgs e)
        {
            if (!ReadOnly) Active = !Active;
            base.OnClick(e);
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            if (!UseDoubleClick)
            {
                Active = !Active;
                base.OnClick(e);
            }
            else
            {
                base.OnDoubleClick(e);
            }
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }
        protected override void OnPaintFill(Graphics g, GraphicsPath path)
        {
            Color color = Active ? ActiveColor : InActiveColor;
            if (!Enabled) color = rectDisableColor;

            if (SwitchShape == UISwitchShape.Round)
            {
                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                g.FillRoundRectangle(color, rect, rect.Height);

                int width = Width - 3 - 1 - 3 - (rect.Height - 6);
                if (!Active)
                {
                    g.FillEllipse(fillColor.IsValid() ? fillColor : Color.White, 3, 3, rect.Height - 6, rect.Height - 6);
                    SizeF sf = g.MeasureString(InActiveText, Font);
                    g.DrawString(InActiveText, Font, fillColor.IsValid() ? fillColor : Color.White, 3 + rect.Height - 6 + (width - sf.Width) / 2, 3 + (rect.Height - 6 - sf.Height) / 2);
                }
                else
                {
                    g.FillEllipse(fillColor.IsValid() ? fillColor : Color.White, Width - 3 - 1 - (rect.Height - 6), 3, rect.Height - 6, rect.Height - 6);
                    SizeF sf = g.MeasureString(ActiveText, Font);
                    g.DrawString(ActiveText, Font, fillColor.IsValid() ? fillColor : Color.White, 3 + (width - sf.Width) / 2, 3 + (rect.Height - 6 - sf.Height) / 2);
                }
            }

            if (SwitchShape == UISwitchShape.Square)
            {
                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
                g.FillRoundRectangle(color, rect, Radius);

                int width = Width - 3 - 1 - 3 - (rect.Height - 6);
                if (!Active)
                {
                    g.FillRoundRectangle(fillColor.IsValid() ? fillColor : Color.White, 3, 3, rect.Height - 6, rect.Height - 6, Radius);
                    SizeF sf = g.MeasureString(InActiveText, Font);
                    g.DrawString(InActiveText, Font, fillColor.IsValid() ? fillColor : Color.White, 3 + rect.Height - 6 + (width - sf.Width) / 2, 3 + (rect.Height - 6 - sf.Height) / 2);
                }
                else
                {
                    g.FillRoundRectangle(fillColor.IsValid() ? fillColor : Color.White, Width - 3 - 1 - (rect.Height - 6), 3, rect.Height - 6, rect.Height - 6, Radius);
                    SizeF sf = g.MeasureString(ActiveText, Font);
                    g.DrawString(ActiveText, Font, fillColor.IsValid() ? fillColor : Color.White, 3 + (width - sf.Width) / 2, 3 + (rect.Height - 6 - sf.Height) / 2);
                }
            }
        }
        public override void SetStyleColor(UIBaseStyle uiColor)
        {
            base.SetStyleColor(uiColor);

            rectColor = uiColor.SwitchActiveColor;
            fillColor = uiColor.SwitchFillColor;
            inActiveColor = uiColor.SwitchInActiveColor;
            rectDisableColor = uiColor.SwitchRectDisableColor;
        }
        #endregion
    }
}