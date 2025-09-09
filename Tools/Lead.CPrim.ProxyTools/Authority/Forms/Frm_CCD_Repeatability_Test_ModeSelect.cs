using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    public partial class Frm_CCD_Repeatability_Test_ModeSelect : UIForm
    {
        public Frm_CCD_Repeatability_Test_ModeSelect()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.TagString = "";
            rb_Test1.Checked = true;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string str = null;

            foreach (var item in uiGroupBox1.Controls)
            {
                if (item is UIRadioButton)
                {
                    var rb = item as UIRadioButton;
                    if(rb.Checked)
                    {
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            MessageBox.Show("请只选一项");
                            return;
                        }
                        str = rb.TagString;
                    }
                }
            }
            this.TagString = str;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_CCD_Repeatability_Test_ModeSelect_Title", "CCD动静态模式选择");
            btnOK.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_CCD_Repeatability_Test_ModeSelect_OK", "确认");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_CCD_Repeatability_Test_ModeSelect_Cancel", "取消");
            rb_Test1.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_CCD_Repeatability_Test_ModeSelect_Test1", "测试1:CCD静态重复性,(UC和CCD保持静态.测试100次)");
            rb_Test2.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_CCD_Repeatability_Test_ModeSelect_Test2", "测试2:CCD动态重复性_模式1,(CCD保持静止,UC移动.测试100次)");
            rb_Test3.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_CCD_Repeatability_Test_ModeSelect_Test3", "测试3:CCD动态重复性_模式2,(UC保持静止,CCD移动.测试100次)");
        }
    }
}
