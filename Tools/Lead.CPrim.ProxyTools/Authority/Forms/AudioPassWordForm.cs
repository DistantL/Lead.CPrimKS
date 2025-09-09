/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: AudioPassWordForm.cs
 * Author: CC
 * Description: 权限登录UI
 * CreateTime: 2023-04-17
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><CC><20230417>
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
    public partial class AudioPassWordForm : UIForm
    {
        #region Field

        /// <summary>
        /// 界面中权限
        /// </summary>
        private OpLevel _opLevel = OpLevel.NoLogin;

        /// <summary>
        /// 二次授权界面弹出
        /// </summary>
        private bool flag_2Step = false;
        #endregion



        #region Prop
        #endregion



        #region Ctor
        public AudioPassWordForm()
        {
            InitializeComponent();
            SetStyle();

            AuthorityManager.Instance.OnUpdateLogin -= InstanceUpdateLogin;
            AuthorityManager.Instance.OnUpdateLogin += InstanceUpdateLogin;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void PassWordForm_Load(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.CheckSoftLock(out string errMsg) != -1 &&
                !string.IsNullOrEmpty(AuthorityManager.Instance.CurRegisterCode) &&
                AuthorityManager.Instance.GetMaxLvlByRegisterCode(AuthorityManager.Instance.CurRegisterCode, out string errMsg2) != OpLevel.Other)
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

            InstanceUpdateLogin(AuthorityManager.Instance.CurrentUserName
                , AuthorityManager.Instance.CurrentUserID
                , AuthorityManager.Instance.CurrentVendor
                , (int)AuthorityManager.Instance.Level);

            if (!string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentUserName))
            {
                btnOK.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_LoginOut", "登出");
            }
            else
            {
                btnOK.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_LoginIn", "登入");
            }

            AuthorityManager.Instance.ShowLevelLoginUI = true;
        }

        /// <summary>gbLogin_Paint事件（去除边框）</summary>
        private void gbLogin_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
        }
        #endregion



        #region Button_Event
        /// <summary>
        /// 登录
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                #region Load有登录权限时，当前为登出指令
                switch (AuthorityManager.Instance.Level)
                {
                    case OpLevel.Level1:
                    case OpLevel.Level2:
                    case OpLevel.Level3:
                        {
                            LogHelper.LogAdd(LogLevel.Info, "User logout", "Login");

                            AuthorityManager.Instance.CurrentUserName = string.Empty;
                            AuthorityManager.Instance.CurrentUserID = string.Empty;
                            AuthorityManager.Instance.CurrentVendor = string.Empty;

                            AuthorityManager.Instance.CurrentAuthorizeName = string.Empty;
                            AuthorityManager.Instance.CurrentAuthorizeID = string.Empty;
                            AuthorityManager.Instance.CurrentAuthorizeVendor = string.Empty;

                            AuthorityManager.Instance.Level = OpLevel.NoLogin;
                            InstanceUpdateLogin(null, null, null, (int)OpLevel.NoLogin);
                            this.Close();
                            return;
                        }
                }
                #endregion

                if (txtUserName.Text.IsNullOrWhiteSpace() || txtID.Text.IsNullOrWhiteSpace())
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_NullLevel", "用户名或卡号ID为空"));
                }

                if (_opLevel == OpLevel.NoLogin)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_CurrentHasNoAuthority", "当前用户没有权限!"));
                }
                string function = txtFun.Text.ToUpper();
                bool flag = function.Contains("APPLE") || function.Contains("ICT") || function.Contains("GTK") || function.Contains("LEAD_SUPPER");
                if (!flag && _opLevel == OpLevel.Level3)
                {
                    AuthorityManager.Instance.Level = OpLevel.NoLogin;
                    var form = new AudioPassWord2StepForm(Color.WhiteSmoke);
                    form.FormClosed += Form_FormClosed;
                    this.Hide();

                    flag_2Step = true;
                    if (DialogResult.OK != form.ShowDialog())
                    {
                        DialogResult = DialogResult.OK;
                        AuthorityManager.Instance.ShowLevelLoginUI = false;
                        return;
                    }
                }
                else
                {
                    AuthorityManager.Instance.CurrentAuthorizeName = string.Empty;
                    AuthorityManager.Instance.CurrentAuthorizeID = string.Empty;
                    AuthorityManager.Instance.CurrentAuthorizeVendor = string.Empty;
                }

                AuthorityManager.Instance.CurrentUserName = txtUserName.Text;
                AuthorityManager.Instance.CurrentUserID = txtID.Text;
                AuthorityManager.Instance.CurrentVendor = txtFun.Text;
                AuthorityManager.Instance.Level = _opLevel;
                DialogResult = DialogResult.OK;
                AuthorityManager.Instance.ShowLevelLoginUI = false;
                LogHelper.LogAdd(LogLevel.Info, "User login", "Login");
                this.Close();
            }
            catch (Exception ex)
            {
                // AuthorityManager.Instance.Level = OpLevel.NoLogin;
                // txtUserName.Text = string.Empty;
                // txtID.Text = string.Empty;
                // txtFun.Text = string.Empty;
                // labLevel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_NoLogin", "未登录");
                Notification.ShowWarn(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_LoginFail", "登录失败：") + ex.Message);
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            flag_2Step = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            AuthorityManager.Instance.ShowLevelLoginUI = false;
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
        }
        #endregion



        private void AudioPassWordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorityManager.Instance.OnUpdateLogin -= InstanceUpdateLogin;
            NLocalizer.LanguageChanged -= OnLanguageChanged;
        }

        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Title", "登录界面");
            labUser.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_User", "用户名") + ":";
            labID.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_ID", "卡号") + ":";
            labFun.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Vendor", "供应商") + ":";
            labTip.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Tip", "用户的登录权限是");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Cancel", "取消");

            txtUserName.Watermark = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_User", "用户名");
            txtID.Watermark = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_ID", "卡号");
            txtFun.Watermark = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Vendor", "供应商");
        }

        public void InstanceUpdateLogin(string user, string id, string vendor, int level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, string, string, int>(InstanceUpdateLogin), user, id, vendor, level);
            }
            else
            {
                try
                {
                    if (flag_2Step)
                    {
                        return;
                    }

                    if (!string.IsNullOrWhiteSpace(user))
                    {
                        //有用户名
                        txtUserName.Text = user;
                        txtID.Text = id;
                        txtFun.Text = vendor;
                        switch (level)
                        {
                            case (int)OpLevel.Level1:
                            case (int)OpLevel.Level2:
                            case (int)OpLevel.Level3:
                                _opLevel = (OpLevel)level;
                                labLevel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Level", "权限") + level;
                                break;
                            case (int)OpLevel.NoLogin:
                            default:
                                _opLevel = OpLevel.NoLogin;
                                labLevel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_NoLogin", "未登录");
                                break;
                        }
                    }
                    else
                    {
                        //无用户名
                        txtUserName.Text = string.Empty;
                        txtID.Text = string.Empty;
                        txtFun.Text = string.Empty;
                        _opLevel = OpLevel.NoLogin;
                        labLevel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_NoLogin", "未登录");
                    }
                }
                catch
                {
                    //无用户名
                    txtUserName.Text = string.Empty;
                    txtID.Text = string.Empty;
                    txtFun.Text = string.Empty;
                    _opLevel = OpLevel.NoLogin;
                    labLevel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_NoLogin", "未登录");
                }
            }
        }
    }
}

