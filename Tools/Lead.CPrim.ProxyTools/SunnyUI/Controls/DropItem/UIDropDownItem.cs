/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIDropDownItem.cs
 * Author: Victor
 * Description: 下拉框弹出窗体基类
 * CreateTime: 2020-01-01
 * Inherit：UIPanel、UIUserControl
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 *
 * <3.3.22.1010><Victor><20221010>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.DropItem
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System.ComponentModel;
using System.Drawing;

namespace Lead.CPrim.ProxyTools.SunnyUI.DropItem
{
    /// <summary>
    /// 下拉框弹出窗体基类
    /// </summary>
    [ToolboxItem(false)]
    public partial class UIDropDownItem : UIPanel
    {
        #region delegate And event
        /// <summary>数值切换事件定义</summary>
        /// <param name="sender">sender</param>
        /// <param name="value">数值</param>
        public delegate void OnValueChanged(object sender, object value);
        /// <summary>数值切换事件</summary>
        public event OnValueChanged ValueChanged;
        #endregion



        #region Ctor
        /// <summary>构造函数</summary>
        public UIDropDownItem()
        {
            InitializeComponent();
            SetStyleFlags(true, false);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>数值切换事件</summary>
        /// <param name="sender">sender</param>
        /// <param name="value">数值</param>
        protected void DoValueChanged(object sender, object value)
        {
            ValueChanged?.Invoke(this, value);
        }
        /// <summary>关闭弹出窗口</summary>
        public void Close()
        {
            UIDropDown parent = (UIDropDown)Parent;
            parent?.Close();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>设置边框颜色</summary>
        /// <param name="color">颜色</param>
        public virtual void SetRectColor(Color color)
        {
        }
        /// <summary>设置填充颜色</summary>
        /// <param name="color">颜色</param>
        public virtual void SetFillColor(Color color)
        {
        }
        /// <summary>设置字体颜色</summary>
        /// <param name="color">颜色</param>
        public virtual void SetForeColor(Color color)
        {
        }
        public virtual void InitShow()
        {

        } 
        #endregion
    }
}