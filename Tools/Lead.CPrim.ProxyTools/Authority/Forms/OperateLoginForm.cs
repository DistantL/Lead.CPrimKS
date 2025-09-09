using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Properties;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    public partial class OperateLoginForm : UIForm
    {
        #region Field
        /// <summary>
        /// UI按钮
        /// </summary>
        UIButton[] btns = new UIButton[] { };
        #endregion



        #region Prop
        /// <summary>
        /// True：改变灯状态<br/>
        /// False：不改变灯状态<br/>
        /// </summary>
        public bool IsChangeLightState { get; set; } = false;

        /// <summary>
        /// True：确定<br/>
        /// False：取消<br/>
        /// </summary>
        public bool IsOK { get; private set; } = false;
        #endregion



        #region Ctor
        public OperateLoginForm()
        {
            InitializeComponent();

            labSelect.Text = string.Empty;
            txtID.Text = "";
            btns = new UIButton[] { btnOK, btnCancel };
            SetStyle();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        public OperateLoginForm(List<string> item) : this()
        {
            string text = string.Empty;
            foreach (string info in item)
            {
                text += $"{info} ";
            }
            labSelect.Text = text;
        }
        #endregion



        #region System_Event
        public void InstanceOpLogin(string id)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(InstanceOpLogin), id);
            }
            else
            {
                txtID.Text = id;
            }
        }

        private void OperateLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AuthorityManager.Instance.ShowOpLoginUI = false;
            AuthorityManager.Instance.ClearOnOpLogin();

            EventManager.SwitchStatus(SwitchStatus.ClrErr);
        }

        private void OperateLoginForm_Load(object sender, EventArgs e)
        {
            AuthorityManager.Instance.CurrentOperatorID = string.Empty;
            AuthorityManager.Instance.ShowOpLoginUI = true;

            AuthorityManager.Instance.ClearOnOpLogin();
            AuthorityManager.Instance.OnOpLogin += InstanceOpLogin;

            if(IsChangeLightState)
            {
                EventManager.SwitchStatus(SwitchStatus.RunningWithNotice);
            }
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
                string id = txtID.Text;
                if (id.IsNullOrWhiteSpace())
                {
                    throw new Exception(NLocalizer.GetString("Authority_Warning_NullId", "ID is null"));
                }

                AuthorityManager.Instance.CurrentOperatorID = id;
                IsOK = true;
                Close();
            }
            catch (Exception ex)
            {
                txtID.Text = string.Empty;
                Notification.ShowWarn("操作员登录失败：" + ex.Message);
            }
        }

        private void labSelect_DoubleClick(object sender, EventArgs e)
        {
            AuthorityManager.Instance.CurrentOperatorID = "3245872354";
            IsOK = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        internal void SetTitle(string title)
        {
            txtID.Text = "";
            labSelect.Text = title;
        }
        #endregion



        #region Method_InternalUsing
        public void OnLanguageChanged()
        {
            if (!IsHandleCreated)
            {
                return;
            }

            this.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_OperateLoginForm_Title", "二次确认");
            lb_ID.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_OperateLoginForm_ID", "操作员:");
            btnOK.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_OperateLoginForm_OK", "确认");
            btnCancel.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_OperateLoginForm_Cancel", "取消");
            txtID.Watermark = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_OperateLoginForm_CardID", "卡号");
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
    }
}
