using Microsoft.Win32;
using System;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools.Properties;

namespace Lead.CPrim.ProxyTools.Register
{
    public partial class RegistrationCode : Form
    {
        public RegistrationCode()
        {
            InitializeComponent();
            lblSerialNumber.Visible = Settings1.Default.SpecialRegistration;
            txtSerialNumber.Visible = Settings1.Default.SpecialRegistration;
            txtSerialNumber.Text = Register.GetCode();
        }

        private void btnCteate_Click(object sender, EventArgs e)
        {
            if(txtDateTime.Text.Trim().Length != 6)
            {
                MessageBox.Show(this, "日期格式有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string result = null;
            string error = null;
            string key = null;
            string value = null;
            if (Settings1.Default.SpecialRegistration)
            {
                if(txtSerialNumber.Text.Trim().Length != 24)
                {
                    MessageBox.Show(this, "序列号格式有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                key = txtSerialNumber.Text.Trim().Substring(8, 8);
                value = txtSerialNumber.Text.Trim().Substring(16, 8);
                
            }
            else
            {
                key = Resources.RegisterKey;
                value = Resources.RegisterIV;
            }
            if (DESHelper.EncryptString(txtDateTime.Text.Trim(), key, value, ref result, ref error) == 0)
            {
                txtCode.Text = result.Substring(0, 4) + result.Substring(8, 4) + result.Substring(4, 4) + result.Substring(12, 4);
            }
            else
            {
                MessageBox.Show(this, "错误信息：" + error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCode.Text))
            {
                return;
            }
            Clipboard.SetText(txtCode.Text);
        }

        private void btnCancellation_Click(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Lead", true))
                {
                    if(registryKey != null)
                    {
                        registryKey.DeleteSubKey("cc");
                    }
                    MessageBox.Show(this,"删除成功","删除提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "删除失败："+ex.Message, "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
