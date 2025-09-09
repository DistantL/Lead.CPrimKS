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
    public partial class Frm_LAD_ModeSelect : UIForm
    {
        public Frm_LAD_ModeSelect()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rq_ModeSelect.SelectedIndex == -1)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_LAD_ModeSelect_NoSelect", "未选择测试项目!"));
                return;
            }

            this.TagString = rq_ModeSelect.Items[rq_ModeSelect.SelectedIndex].ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_LAD_ModeSelect_Title", "LAD模式选择");
            btnOK.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_LAD_ModeSelect_OK", "确认");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_Frm_LAD_ModeSelect_Cancel", "取消");
        }
    }
}
