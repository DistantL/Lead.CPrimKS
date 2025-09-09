using Lead.CPrim.ProxyTools.Properties;
using System;
using System.ComponentModel;

namespace Lead.CPrim.ProxyTools.SunnyUI.Forms
{
    [DefaultProperty("Text")]
    [DefaultEvent("OnLogin")]
    public partial class UILoginForm : UIForm
    {
        #region Event
        [Description("确认按钮事件"), Category("SunnyUI")]
        public event EventHandler ButtonLoginClick;
        [Description("取消按钮事件"), Category("SunnyUI")]
        public event EventHandler ButtonCancelClick;

        public delegate bool OnLoginHandle(string userName, string password);
        [Description("登录校验事件"), Category("SunnyUI")]
        public event OnLoginHandle OnLogin;
        #endregion



        #region Field
        public enum UILoginImage
        {
            Login1,
            Login2,
            Login3,
            Login4,
            Login5,
            Login6
        }
        #endregion



        #region Prop
        [Description("顶部标题"), Category("SunnyUI")]
        [DefaultValue(null)]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }
        [Description("底部说明"), Category("SunnyUI")]
        [DefaultValue(null)]
        public string SubText
        {
            get => lblSubText.Text;
            set => lblSubText.Text = value;
        }

        private UILoginImage loginImage;
        [DefaultValue(UILoginImage.Login1)]
        [Description("背景图片"), Category("SunnyUI")]
        public UILoginImage LoginImage
        {
            get => loginImage;
            set
            {
                if (loginImage != value)
                {
                    loginImage = value;

                    if (loginImage == UILoginImage.Login1) BackgroundImage = Resources.Login1;
                    if (loginImage == UILoginImage.Login2) BackgroundImage = Resources.Login2;
                    if (loginImage == UILoginImage.Login3) BackgroundImage = Resources.Login3;
                    if (loginImage == UILoginImage.Login4) BackgroundImage = Resources.Login4;
                    if (loginImage == UILoginImage.Login5) BackgroundImage = Resources.Login5;
                    if (loginImage == UILoginImage.Login6) BackgroundImage = Resources.Login6;
                }
            }
        }
        [DefaultValue(false), Browsable(false)]
        public bool IsLogin { get; protected set; }
        [DefaultValue(null)]
        [Description("账号"), Category("SunnyUI")]
        public string UserName
        {
            get => edtUser.Text;
            set => edtUser.Text = value;
        }
        [DefaultValue(null)]
        [Description("密码"), Category("SunnyUI")]
        public string Password
        {
            get => edtPassword.Text;
            set => edtPassword.Text = value;
        }
        #endregion



        #region Ctor
        public UILoginForm()
        {
            InitializeComponent();
            lblSubText.Text = lblSubText.Version;
        }
        /// <summary>Ctor</summary>
        /// <param name="title">标题</param>
        /// <param name="ver">版本</param>
        public UILoginForm(string title, string ver)
        {
            InitializeComponent();
            Title = title;
            lblSubText.Text = ver;
        }
        #endregion



        #region Button_Event
        /// <summary>登录</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ButtonLoginClick != null)
            {
                ButtonLoginClick?.Invoke(this, e);
            }
            else
            {
                IsLogin = OnLogin != null && OnLogin(edtUser.Text, edtPassword.Text);
                if (IsLogin)
                {
                    Close();
                }
            }
        }
        /// <summary>取消</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ButtonCancelClick != null)
            {
                ButtonCancelClick?.Invoke(this, e);
            }
            else
            {
                Close();
            }
        }
        #endregion
    }
}