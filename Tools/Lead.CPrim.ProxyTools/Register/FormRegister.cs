using Lead.CPrim.ProxyTools.Properties;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Register
{
    public partial class FormRegister : Form
    {
        #region Field
        /// <summary>注册框</summary>
        private TextBox[] _tbCodes;
        #endregion



        #region Ctor
        /// <summary>无参构造函数</summary>
        public FormRegister()
        {
            InitializeComponent();
        }
        /// <summary>有参构造函数</summary>
        /// <param name="info"></param>
        public FormRegister(string info):this()
        {
            lblInfo.Text = info;
            _tbCodes = new TextBox[4]
            {
                tbCode1,
                tbCode2,
                tbCode3,
                tbCode4
            };
        }
        #endregion



        #region System_Event
        /// <summary>粘贴</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V & e.KeyCode == Keys.Control)
            {
                string text = Clipboard.GetText().Trim();
                if (text.Length == 16)
                {
                    for (int i = 0; i < text.Length / 4; i++)
                    {
                        _tbCodes[i].Text = text.Substring(i * 4, 4);
                    }
                }
                else if (text.Length == 19)
                {
                    string[] code = text.Split(new char[] { '-', '_', '/', '\\' });
                    if (code.Length == 4)
                    {
                        for (int i = 0; i < code.Length; i++)
                        {
                            _tbCodes[i].Text = code[i];
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "注册码有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "注册码有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// 粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText().Trim();
            if (text.Length == 16)
            {
                for (int i = 0; i < text.Length / 4; i++)
                {
                    _tbCodes[i].Text = text.Substring(i * 4, 4);
                }
            }
            else if (text.Length == 19)
            {
                string[] code = text.Split(new char[] { '-', '_', '/', '\\' });
                if (code.Length == 4)
                {
                    for (int i = 0; i < code.Length; i++)
                    {
                        _tbCodes[i].Text = code[i];
                    }
                }
                else
                {
                    MessageBox.Show(this, "注册码有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "注册码有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        #region Button_Event
        /// <summary>
        /// 超级权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInfo_DoubleClick(object sender, EventArgs e)
        {
            SuperPermissions super = new SuperPermissions();
            super.StartPosition = FormStartPosition.CenterScreen;
            super.ShowDialog();
        }
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_tbCodes.Any((TextBox t) => string.IsNullOrEmpty(t.Text) || t.Text.Length != 4))
                {
                    string pToDecrypt = _tbCodes[0].Text + _tbCodes[2].Text + _tbCodes[1].Text + _tbCodes[3].Text;
                    string str = null;
                    string error = null;
                    string key = Settings1.Default.SpecialRegistration ? Register.GetDiskVolumeSerialNumber() : Resources.RegisterKey;
                    string iv = Settings1.Default.SpecialRegistration ? Register.getCpu().Substring(0, 8) : Resources.RegisterIV;
                    if (DESHelper.DecryptString(pToDecrypt, key, iv, ref str, ref error) != 0)
                    {
                        foreach (var item in _tbCodes)
                        {
                            item.Clear();
                        }
                        throw new Exception("注册码无效，请重新输入！");
                    }
                    IFormatProvider provider = new CultureInfo("zh-CN", useUserOverride: true);
                    if (!DateTime.TryParseExact("20" + str, "yyyyMMdd", provider, DateTimeStyles.None, out DateTime result))
                    {
                        foreach (var item in _tbCodes)
                        {
                            item.Clear();
                        }
                        throw new Exception("注册码无效，请重新输入！");
                    }
                    if (DateTime.Compare(result, DateTime.Now) < 0)
                    {
                        foreach (var item in _tbCodes)
                        {
                            item.Clear();
                        }
                        throw new Exception("注册码已失效，请重新输入！");
                    }
                    WriteSetting("cc", _tbCodes[0].Text + _tbCodes[1].Text + _tbCodes[2].Text + _tbCodes[3].Text);
                    MessageBox.Show($"软件注册成功！截至使用日期：{result:yyyy-MM-dd}");
                    base.DialogResult = DialogResult.Yes;
                }
                else
                {
                    throw new Exception("注册码框不足4位");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "注册失败" + ex.Message, "注册提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 写注册表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void WriteSetting(string key, string value)
        {
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Lead\\cc"))
            {
                registryKey.SetValue(key, value);
            }
        }
        #endregion
    }
}

