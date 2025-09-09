/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIWaitForm.cs
 * Author: Victor
 * Description: 等待窗体
 * CreateTime: 2020-10-13
 * Inherit：UIForm
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1010><Victor><20221015>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.CustomControl
******************************************************************************/

using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System.ComponentModel;

namespace Lead.CPrim.ProxyTools.CustomControl
{
    public sealed partial class UIWaitForm : UIForm
    {
        #region Prop
        [DefaultValue(false), Browsable(false)]
        public bool NeedClose { get; set; }
        #endregion



        #region Ctor
        public UIWaitForm()
        {
            InitializeComponent();
            base.Text = ULocalize.InfoTitle;
            SetDescription(ULocalize.SystemProcessing);
        }

        public UIWaitForm(string desc) : this()
        {
            SetDescription(desc);
        }
        #endregion



        #region Event_ExternalUsing
        public void SetDescription(string text)
        {
            labelDescription.SetText(text);
            labelDescription.Invalidate();
        }
        #endregion



        #region Method_InternalUsing
        private void Bar_Tick(object sender, System.EventArgs e)
        {
            if (NeedClose)
            {
                Close();
            }
        } 
        #endregion
    }
}
