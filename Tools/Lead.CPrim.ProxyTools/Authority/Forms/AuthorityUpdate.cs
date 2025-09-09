using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Properties;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    public partial class AuthorityUpdate : UIForm
    {
        #region Field
        private OpLevel _level;
        /// <summary>UI按钮</summary>
        UIButton[] btns = new UIButton[] { };
        #endregion



        #region System_Event
        public AuthorityUpdate()
        {
            InitializeComponent();
            btns = new UIButton[] { btnOK, btnCancel };
            SetStyle();
        }
        public AuthorityUpdate(OpLevel level) : this()
        {
            _level = level;
        }
        #endregion




        #region System_Event
        private void AuthorityMngForm_Load(object sender, EventArgs e)
        {
            txtUserName.Text = AuthorityManager.Instance.CurrentUserName;
            txtUserName.Enabled = false;
        }
        #endregion




        #region Button_Event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception("UserName为空");
                }
                if (txtOldPassWord.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception("OldPassWord为空");
                }
                if (txtNewPassWord.Text.IsNullOrEmpty())
                {
                    throw new Exception("NewPassWord为空");
                }
                if (txtConfirmNewPassWord.Text.IsNullOrEmpty())
                {
                    throw new Exception("ConfirmNewPassWord为空");
                }
                if (txtNewPassWord.Text.Trim() != txtConfirmNewPassWord.Text.Trim())
                {
                    throw new Exception("二次输入密码不一致");
                }

                string name = txtUserName.Text;
                AuthorityDb author = null;
                int ret = -1;
                MongodbHelper.QueryOneFirst<AuthorityDb>("UserName", name, out author, UIGlobal.AuthorityDb, null);
                if (author == null)
                {
                    throw new Exception("Don't exist this user");
                }
                if (author.PassWord != DESHelper.Encrypt(txtOldPassWord.Text.Trim(), Resources.passWordKey))
                {
                    throw new Exception("OldPassWordError");
                }

                string newPwd = DESHelper.Encrypt(txtNewPassWord.Text.Trim(), Resources.passWordKey);
                ret = MongodbHelper.ReplaceOne("UserName", author.UserName, new AuthorityDb
                {
                    Level = AuthorityManager.Instance.Level,
                    UserName = name,
                    PassWord = newPwd,
                }, UIGlobal.AuthorityDb);
                if (ret == 0)
                {
                    ShowSuccessTip("User infomation changed");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception("ReplaceOne返回值 = " + ret);
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog("更新失败：" + ex.Message);
            }
        }
        #endregion




        #region Method_InternalUsing
        /// <summary>设置样式</summary>
        private void SetStyle()
        {
            //UIForm
            TitleColor = Color.WhiteSmoke;
            TitleForeColor = Color.FromArgb(64, 64, 64);
            TitleFont = new Font("微软雅黑", 14.0f, FontStyle.Bold);
            BackColor = Color.WhiteSmoke;
            RectColor = Color.Gray;
            ControlBoxForeColor = Color.FromArgb(64, 64, 64);

            //UIButton
            foreach (var btn in btns)
            {
                btn.Style = UIStyle.Gray;
                btn.FillColor = BackColor;
                btn.ForeColor = Color.FromArgb(64, 64, 64);
                btn.Radius = 10;
                btn.ForeHoverColor = BackColor;
                btn.FillHoverColor = Color.FromArgb(26, 137, 255);
                btn.FillPressColor = Color.FromArgb(26, 137, 255);
                btn.FillSelectedColor = Color.FromArgb(26, 137, 255);
                btn.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            }
        }
        #endregion
    }
}

