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
    public partial class AudioPassWord2StepForm : UIForm
    {
        #region Field

        /// <summary>
        /// 界面中权限
        /// </summary>
        private OpLevel _opLevel = OpLevel.NoLogin;

        #endregion


        #region Ctor
        /// <summary>Ctro有一个参数</summary>
        public AudioPassWord2StepForm(Color color)
        {
            InitializeComponent();
            SetStyle(color);

            AuthorityManager.Instance.OnUpdateLogin -= InstanceUpdateLogin;
            AuthorityManager.Instance.OnUpdateLogin += InstanceUpdateLogin;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion


        #region System_Event

        #endregion

        
        #region Button_Event
        /// <summary>登录</summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_opLevel != OpLevel.Level3)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_CurrentHasNoAuthority", "当前用户没有权限!"));
                }

                AuthorityManager.Instance.CurrentAuthorizeName = txtUserName.Text;
                AuthorityManager.Instance.CurrentAuthorizeID = txtID.Text;
                AuthorityManager.Instance.CurrentAuthorizeVendor = txtFun.Text;
     
                DialogResult = DialogResult.OK;
                AuthorityManager.Instance.ShowLevelLoginUI = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Notification.ShowWarn(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_LoginFail", "登录失败：") + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

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
                    if (!string.IsNullOrWhiteSpace(user))
                    {
                        //if (!vendor.Contains("Authorize"))
                        //{
                        //    return;
                        //}
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

                        btnOK.Enabled = _opLevel == OpLevel.Level3;
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

        #region Method_InternalUsing

        /// <summary>设置样式</summary>
        private void SetStyle(Color color)
        {
            //UIForm
            TitleColor = Color.WhiteSmoke;
            TitleForeColor = Color.FromArgb(64, 64, 64);
            TitleFont = new Font("微软雅黑", 12f);
            BackColor = color;
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
           // this.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Title", "登录界面");
            labUser.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_User", "用户名") + ":";
            labID.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_ID", "卡号") + ":";
            labFun.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Vendor", "供应商") + ":";
            labTip.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Tip", "用户的登录权限是");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Cancel", "取消");

            txtUserName.Watermark = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_User", "用户名");
            txtID.Watermark = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_ID", "卡号");
            txtFun.Watermark = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_Vendor", "供应商");
            lb_Tips.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_AudioPassWordForm_2StepTips", "需要二次确认");
        }
    }
}

