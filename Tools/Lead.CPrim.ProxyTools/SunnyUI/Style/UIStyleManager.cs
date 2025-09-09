/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIStyleManager.cs
 * Author: Victor
 * Description: 主题样式管理类
 * CreateTime: 2020-01-01
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2021-10-16: V3.0.8 增加系统DPI缩放自适应
 * 
 * <3.3.23.0101><Victor><20230107>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.ProxyTools;
using System.ComponentModel;

namespace Lead.CPrim.ProxyTools.SunnyUI.Style
{
    /// <summary>主题样式管理类</summary>
    public class UIStyleManager : Component
    {
        /// <summary>
        /// 主题样式
        /// </summary>
        [DefaultValue(UIStyle.Blue), Description("主题样式"), Category("SunnyUI")]
        public UIStyle Style
        {
            get => UIStyles.Style;
            set
            {
                if (UIStyles.Style != value && value != UIStyle.Custom)
                {
                    UIStyles.SetStyle(value);
                }
            }
        }

        public void Render()
        {
            if (Style != UIStyle.Custom)
            {
                UIStyles.SetStyle(Style);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UIStyleManager()
        {
            Version = UIGlobal.UIVersion;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="container"></param>
        public UIStyleManager(IContainer container) : this()
        {
            container.Add(this);
            Version = UIGlobal.UIVersion;
        }

        [DefaultValue(false), Description("DPI缩放"), Category("SunnyUI")]
        public bool DPIScale
        {
            get => UIStyles.DPIScale;
            set => UIStyles.DPIScale = value;
        }

        [DefaultValue(12f), Description("DPI缩放开启后，可调字体大小，默认12"), Category("SunnyUI")]
        public float FontSize
        {
            get => UIStyles.FontSize;
            set => UIStyles.FontSize = value;
        }

        /// <summary>版本</summary>
        public string Version { get; }
    }
}