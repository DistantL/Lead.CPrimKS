/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UITableLayoutPanel.cs
 * Author: Victor
 * Description: 动态布局面板
 * CreateTime: 2021-07-18
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2021-07-18: V3.0.5 增加文件说明
 * 2021-07-18: V3.0.5 更新了放在TableLayoutPanel里控件的自定义颜色问题
 * 
 * <3.3.22.1207><Victor><20221228>
 * 1、初版
******************************************************************************/

using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    public sealed class UITableLayoutPanel : TableLayoutPanel, IStyleInterface
    {
        public UITableLayoutPanel()
        {
            Version = UIGlobal.UIVersion;
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

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is IStyleInterface ctrl)
            {
                if (!ctrl.StyleCustomMode) ctrl.Style = Style;
            }

            UIStyleHelper.SetRawControlStyle(e, Style);
        }

        /// <summary>
        /// 自定义主题风格
        /// </summary>
        [DefaultValue(false)]
        [Description("获取或设置可以自定义主题风格"), Category("SunnyUI")]
        public bool StyleCustomMode
        {
            get; set;
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

        public string Version
        {
            get;
        }

        public string TagString
        {
            get; set;
        }

        public void SetStyle(UIStyle style)
        {
            SuspendLayout();
            UIStyleHelper.SetChildUIStyle(this, style);
            _style = style;
            ResumeLayout();
        }

        public void SetStyleColor(UIBaseStyle uiColor)
        {
            //
        }
    }
}
