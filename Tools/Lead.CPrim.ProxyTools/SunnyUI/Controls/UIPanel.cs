/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIPanel.cs
 * Author: Victor
 * Description: 面板
 * CreateTime: 2020-01-01
 * Inherit：UIUserControl
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2020-04-25: V2.2.4 更新主题配置类
 * 2021-05-09: V3.0.3 增加双缓冲，减少闪烁
 * 2021-09-03: V3.0.6 支持背景图片显示
 * 2021-12-11: V3.0.9 增加了渐变色
 * 2021-12-13: V3.0.9 边框线宽可设置1或者2
 * 2022-01-10: V3.1.0 调整边框和圆角的绘制
 * 2022-01-27: V3.1.0 禁止显示滚动条
 * 2022-02-16: V3.1.1 基类增加只读颜色设置
 * 2022-03-19: V3.1.1 重构主题配色
 *
 * <3.3.22.1010><Victor><20221010>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Controls
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.ComponentModel;
using System.Drawing;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    public partial class UIPanel : UIUserControl
    {
        #region Prop
        /// <summary>字体颜色</summary>
        [Description("字体颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "48, 48, 48")]
        public override Color ForeColor
        {
            get => foreColor;
            set
            {
                foreColor = value;
                AfterSetForeColor(value);
                SetStyleCustom();
            }
        }

        [DefaultValue(typeof(Color), "109, 109, 103")]
        [Description("不可用时字体颜色"), Category("SunnyUI")]
        public Color ForeDisableColor
        {
            get => foreDisableColor;
            set => SetForeDisableColor(value);
        }

        [Description("是否显示文字"), Category("SunnyUI")]
        [DefaultValue(true)]
        [Browsable(false)]
        public bool ShowText
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
        #endregion



        #region Ctor
        public UIPanel()
        {
            InitializeComponent();
            base.Font = UIFontColor.Font();
            base.MinimumSize = new System.Drawing.Size(1, 1);
            showText = true;
            SetStyleFlags(true, false);
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>设置字体只读颜色</summary>
        /// <param name="color">颜色</param>
        protected void SetForeReadOnlyColor(Color color)
        {
            foreReadOnlyColor = color;
            AfterSetForeReadOnlyColor(color);
            SetStyleCustom();
        } 
        #endregion
    }
}