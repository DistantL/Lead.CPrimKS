/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UISelectForm.cs
 * Author: Victor
 * Description: 选择框
 * CreateTime: 2020-05-05
 * Inherit：UIEditForm
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * <3.2.23.1028><Victor><20231127>
 * UISelectForm版本V1.0、UISelectForm代码美化，对应接口UISelectDialog代码美化，同时增加测试UI
******************************************************************************/

using System.Collections;

namespace Lead.CPrim.ProxyTools.CustomControl
{
    /// <summary>
    /// 选择框
    /// </summary>
    public sealed partial class UISelectForm : UIEditForm
    {
        #region Prop
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get => label.Text;
            set => label.Text = value;
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get => Text;
            set => Text = value;
        }

        /// <summary>
        /// 选择框索引
        /// </summary>
        public int SelectedIndex
        {
            get => ComboBox.SelectedIndex;
            set => ComboBox.SelectedIndex = value;
        }
        #endregion



        #region Ctor
        public UISelectForm()
        {
            InitializeComponent();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 设置选择框内容
        /// </summary>
        /// <param name="items"></param>
        public void SetItems(IList items)
        {
            ComboBox.Items.Clear();

            foreach (var item in items)
            {
                ComboBox.Items.Add(item);
            }
        }
        #endregion
    }
}