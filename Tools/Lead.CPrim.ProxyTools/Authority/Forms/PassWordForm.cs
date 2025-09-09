/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PassWordForm.cs
 * Author: Victor
 * Description: 权限登录UI
 * CreateTime: 2023-1-2
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230115>
 * 1、屏蔽密码框的粘贴及右键粘贴功能（ShortcutsEnabled = false）
******************************************************************************/

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
    public partial class PassWordForm : UIForm
    {
        #region Field
        /// <summary>登录标志</summary>
        public bool _pwdFlag = false;
        /// <summary>UI按钮</summary>
        UIButton[] btns = new UIButton[] { };
        #endregion


        #region Ctor
        /// <summary>Ctro有一个参数</summary>
        public PassWordForm()
        {
            InitializeComponent();
            btns = new UIButton[] { btnOK, btnCancel, btnLogout, btnLogoutCancel, btnUpdate };
            SetStyle();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion


        #region System_Event
        /// <summary>Load事件</summary>
        private void PassWordForm_Load(object sender, EventArgs e)
        {
            string errMsg;
            string errMsg2;
            if (AuthorityManager.Instance.CheckSoftLock(out errMsg) != -1 &&
                !string.IsNullOrEmpty(AuthorityManager.Instance.CurRegisterCode) &&
                AuthorityManager.Instance.GetMaxLvlByRegisterCode(AuthorityManager.Instance.CurRegisterCode, out errMsg2) != OpLevel.Other)
            {
                switch (AuthorityManager.Instance.AccessLvl)
                {
                    case OpLevel.Level3:
                        break;
                    case OpLevel.Level2:
                        break;
                    case OpLevel.Level1:
                        break;
                }
            }

            if (!AuthorityManager.Instance.CurrentUserName.IsNullOrEmpty())
            {
                gbLogin.Visible = false;
                gbLogout.Visible = true;
                txtUserName.Text = AuthorityManager.Instance.CurrentUserName;
                txtUserName.Enabled = false;
                if(AuthorityManager.Instance.CurrentUserName == "Administrator")
                {
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnUpdate.Visible = true;
                }
            }
            else
            {
                gbLogin.Visible = true;
                gbLogout.Visible = false;
                txtUserName.Enabled = true;
            }
        }

        private void PassWordForm_Shown(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
        /// <summary>gbLogin_Paint事件（去除边框）</summary>
        private void gbLogin_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
        }
        /// <summary>gbLogout_Paint事件（去除边框）</summary>
        private void gbLogout_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
        }
        #endregion


        #region Button_Event
        /// <summary>登录</summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception(NLocalizer.GetString("Authority_Warning_NullLevel", "Level is null"));
                }
                if (txtPassWord.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception(NLocalizer.GetString("Authority_Warning_NullPassword", "PassWord is null"));
                }

                string userName = txtUserName.Text;
                string passWord = txtPassWord.Text;
                if (userName == "Administrator" && DESHelper.Encrypt(passWord, Resources.passWordKey) == "0D11E45ECAC0F038F6423C52FE22718C")
                {
                    AuthorityManager.Instance.CurrentUserName = userName;
                    AuthorityManager.Instance.Level = OpLevel.Level3;
                    _pwdFlag = true;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    AuthorityDb authority = null;
                    MongodbHelper.QueryOneFirst("UserName", userName, out authority, UIGlobal.AuthorityDb, null);
                    if (authority == null)
                    {
                        throw new Exception(NLocalizer.GetString("Authority_Warning_EnterPassword", "Please enter the correct password!"));
                    }

                    if (DESHelper.Encrypt(passWord, Resources.passWordKey) == authority.PassWord)
                    {
                        AuthorityManager.Instance.CurrentUserName = userName;
                        AuthorityManager.Instance.Level = authority.Level;
                        _pwdFlag = true;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        throw new Exception(NLocalizer.GetString("Authority_Warning_EnterPassword", "Please enter the correct password!"));
                    }
                }
            }
            catch (Exception ex)
            {
                AuthorityManager.Instance.Level = OpLevel.NoLogin;
                txtPassWord.Text = "";
                txtPassWord.Focus();
                Notification.ShowWarn(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_PassWordForm_LoginFail", "登录失败：") + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>登出</summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthorityManager.Instance.Level = OpLevel.NoLogin;
            DialogResult = DialogResult.OK;
        }
        /// <summary>登出取消</summary>
        private void btnLogoutCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>修改</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AuthorityUpdate update = new AuthorityUpdate();
            update.StartPosition = FormStartPosition.CenterScreen;
            update.ShowDialog();
        }
        #endregion


        #region Method_InternalUsing
        /// <summary>获取登录标志</summary>
        /// <returns>bool</returns>
        public bool GetPwdFlag()
        {
            return _pwdFlag;
        }
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

        public void OnLanguageChanged()
        {
            lb_Username.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_PassWordForm_Username", "用户名:");
            lb_Password.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_PassWordForm_Password", "密码:");
            btnOK.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_PassWordForm_Ok", "登录");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_PassWordForm_Cancel", "取消");
            btnLogout.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_PassWordForm_Logout", "登出");
            btnLogoutCancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_PassWordForm_LogoutCancel", "登出取消");
            btnUpdate.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_PassWordForm_Update", "升级");
        }
    }
}

