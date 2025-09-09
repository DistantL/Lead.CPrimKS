using Lead.CPrim.ProxyTools.SunnyUI.Forms;
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
    public partial class FrmLogOutConfirm : UIForm
    {
        public FrmLogOutConfirm()
        {
            InitializeComponent();
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_FrmLogOutConfirm_Title", "登出");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_FrmLogOutConfirm_Cancel", "取消");
            btnOK.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_FrmLogOutConfirm_OK", "确认");
            lb_Tip.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_FrmLogOutConfirm_Tip", "确认登出？");
        }
    }
}
