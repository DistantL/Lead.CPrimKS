using Lead.CPrim.ProxyTools;
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

namespace Lead.CPrim.Controls
{
    public partial class ScanningSN_Form : UIForm
    {
        public ScanningSN_Form()
        {
            InitializeComponent();
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_SN.Text))
            {
                MessageBox.Show("SN为空");
            }
            this.TagString = tb_SN.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private DateTime _dt;
        private void tb_SN_KeyDown(object sender, KeyEventArgs e)
        {
            _dt = DateTime.Now;
        }

        private void tb_SN_KeyUp(object sender, KeyEventArgs e)
        {
            if (DateTime.Now.Subtract(_dt).Milliseconds > 50)
            {
                tb_SN.Text = "";
            }
        }

        public void OnLanguageChanged()
        {
            lb_Scanning.Text = NLocalizer.GetString("Lead_CPrim_Controls_ScanningSNForm_lbScanning", "二维码:");
            bt_OK.Text = NLocalizer.GetString("Lead_CPrim_Controls_ScanningSNForm_btOK", "确认");
            bt_Cancel.Text = NLocalizer.GetString("Lead_CPrim_Controls_ScanningSNForm_btCancel", "取消");
        }
    }
}
