/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIInputForm.cs
 * Author: Victor
 * Description: 输入框
 * CreateTime: 2020-01-01
 * Inherit：UIEditForm
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * <3.2.23.1028><Victor><20231126>
 * UIInputForm版本V1.0、UIInputForm代码美化，对应接口UIInputDialog代码美化，同时增加测试UI
******************************************************************************/

using System;
using System.ComponentModel;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.ProxyTools.CustomControl
{
    public sealed partial class UIInputForm : UIEditForm
    {
        #region Prop

        public int MaxLength
        {
            get => edit.MaxLength;
            set => edit.MaxLength = value;
        }

        /// <summary>
        /// 输入框
        /// </summary>
        public UITextBox Editor => edit;

        /// <summary>
        /// 描述
        /// </summary>
        public UILabel Label => label;

        /// <summary>
        /// true：检查输入框为空；false：不检查输入框为空；
        /// </summary>
        public bool CheckInputEmpty { get; set; }

        /// <summary>
        /// true：启用键盘输入；false：禁用键盘输入;
        /// </summary>
        [DefaultValue(false)]
        public bool EnableKeyBoard { get; set; }
        #endregion



        #region Ctor
        public UIInputForm()
        {
            InitializeComponent();
        }
        #endregion



        #region Event_System
        private void UIInputForm_Shown(object sender, System.EventArgs e)
        {
            edit.SelectAll();
        }

        private void edit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !EnableKeyBoard;
        }
        #endregion



        #region Event_Override
        protected override bool CheckData()
        {
            Editor.CheckMaxMin();

            if (CheckInputEmpty)
            {
                bool result = edit.Text.IsNullOrWhiteSpace();
                if (result)
                {
                    ShowWarningDialog("编辑框内容不能为空。");
                }
                return !result;
            }

            return true;
        }

        protected override void DoEnter()
        {
            if (btnCancel.Focused || btnOK.Focused)
            {
                return;
            }

            btnOK_Click(null, null);
        }
        #endregion
    }
}