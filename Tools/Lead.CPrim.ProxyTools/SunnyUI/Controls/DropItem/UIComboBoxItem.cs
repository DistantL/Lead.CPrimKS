/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIComboBoxItem.cs
 * Author: Victor
 * Description: 组合框弹出窗体
 * CreateTime: 2020-01-01
 * Inherit：UIDropDownItem、UIPanel、UIUserControl
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
using System;
using System.Drawing;

namespace Lead.CPrim.ProxyTools.SunnyUI.DropItem
{
    /// <summary>组合框弹出窗体</summary>
    public partial class UIComboBoxItem : UIDropDownItem
    {
        #region Field
        /// <summary>列表框</summary>
        public UIListBox ListBox => listBox;
        #endregion



        #region Ctor
        /// <summary>构造函数</summary>
        public UIComboBoxItem()
        {
            InitializeComponent();
        }
        #endregion



        #region Method_Subscribe
        private void ListBox_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void listBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter || e.KeyCode == System.Windows.Forms.Keys.Space)
            {
                Close();
            }
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoValueChanged(this, ListBox.SelectedValue);
        }
        #endregion



        #region Method_Override
        /// <summary>设置边框颜色</summary>
        /// <param name="color">颜色</param>
        public override void SetRectColor(Color color)
        {
            //listBox.ItemSelectBackColor = color;
        }
        /// <summary>设置填充颜色</summary>
        /// <param name="color">颜色</param>
        public override void SetFillColor(Color color)
        {
            //ListBox.ItemSelectForeColor = color;
        } 
        #endregion
    }
}