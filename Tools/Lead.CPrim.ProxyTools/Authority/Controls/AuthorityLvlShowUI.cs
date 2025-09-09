/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: AuthorityLvlShowUI.cs
 * Author: Victor
 * Description: 用来管理登录权限UI
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0712><Victor><20220726>
 * 1、登录权限UI新增机台运行模式
******************************************************************************/


using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Authority.Forms;
using Lead.CPrim.ProxyTools.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Controls
{
    /// <summary>
    /// 主界面登录UI
    /// </summary>
    public partial class AuthorityLvlShowUI : UserControl
    {
        #region Define_Event
        /// <summary>
        /// 导航栏背景色根据Hive状态改变事件
        /// </summary>
        public event Action<HiveStatus> OnToolStripStatus;

        public event Action<HiveStatus, string> OnHiveStatus;
        #endregion



        #region Field
        /// <summary>
        /// 当前Hive状态
        /// </summary>
        private HiveStatus _lastStatus = HiveStatus.Disable;
        private AudioPassWordForm frm = null;
        private FrmLogOutConfirm LogOutConfirm = new FrmLogOutConfirm();

        private HiveChangeStatus hiveStatusUI = new HiveChangeStatus();
        #endregion



        #region Prop
        /// <summary>
        /// true：启动登陆；false：禁止登陆；
        /// </summary>
        public bool EnableLogin { get; set; }
        /// <summary>
        /// 开启远程时 显示HIVE状态
        /// </summary>
        public bool EnableRemoteQualification { get; set; } = false;
        #endregion



        #region Ctor
        public AuthorityLvlShowUI()
        {
            InitializeComponent();
            btnLogin.Image = Resources.No_login;
        }
        #endregion



        #region Button_Event
        /// <summary>
        /// 登录
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.CheckSoftLock(out var err) != 0)
            {
                Notification.ShowError("加密狗无效");
                return;
            }

            frm = new AudioPassWordForm();
            frm.TopLevel = true;
            frm.TopMost = true;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        /// <summary>Hive状态切换</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHive_Click(object sender, EventArgs e)
        {
            hiveStatusUI.SetEnable();
            hiveStatusUI.StartPosition = FormStartPosition.CenterScreen;
            hiveStatusUI.ShowDialog();
        }

        /// <summary>
        /// 图标双击，用于登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppleImage_DoubleClick(object sender, EventArgs e)
        {
            if (EnableLogin)
            {
                AuthorityManager.Instance.CurrentUserName = "Admin";
                AuthorityManager.Instance.CurrentUserID = "3127804314";
                AuthorityManager.Instance.CurrentVendor = "LEAD_SUPPER";
                AuthorityManager.Instance.Level = OpLevel.Level3;
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 级别显示
        /// </summary>
        public void UpdateShow()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdateShow));
                return;
            }
            switch (AuthorityManager.Instance.Level)
            {
                case OpLevel.Level1:
                    btnLogin.Image = Resources.Level1;
                    btnLogin.ContextMenuStrip = uiContextMenuStrip1;
                    break;
                case OpLevel.Level2:
                    btnLogin.Image = Resources.Level2;
                    btnLogin.ContextMenuStrip = uiContextMenuStrip1;
                    break;
                case OpLevel.Level3:
                    btnLogin.Image = Resources.Level3;
                    btnLogin.ContextMenuStrip = uiContextMenuStrip1;
                    break;
                case OpLevel.NoLogin:
                case OpLevel.Other:
                    btnLogin.Image = Resources.No_login;
                    btnLogin.ContextMenuStrip = null;
                    break;
            }
        }

        /// <summary>
        /// HIVE使能控制
        /// </summary>
        /// <param name="enable"></param>
        public void SetEnable(bool enable)
        {
            btnHive.SetEnable(enable);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// Hive状态变更
        /// </summary>
        /// <param name="hive"></param>
        private void ChangeHive(HiveStatus hive)
        {
            if (hive == _lastStatus)
            {
                return;
            }

            btnHive.Image = hive switch
            {
                HiveStatus.DT => Resources.HIVE_DT,
                HiveStatus.Engineering => Resources.HIVE_Engineering,
                HiveStatus.Idle => Resources.HIVE_Idle,
                HiveStatus.Plan_DT => Resources.HIVE_Plan_DT,
                HiveStatus.Running => Resources.HIVE_Running,
                _ => Resources.HIVE_Disabled,
            };
            this.BackColor = hive switch
            {
                HiveStatus.Engineering => Color.FromArgb(204, 171, 216),
                HiveStatus.Plan_DT => Color.FromArgb(255, 215, 212),
                HiveStatus.DT => Color.FromArgb(235, 115, 115),
                _ => Color.Transparent,
            };

            OnToolStripStatus?.Invoke(hive);
            OnHiveStatus?.Invoke(hive, HiveManager.PlanedDowntimeSelect);

            _lastStatus = hive;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (HiveManager.GetHiveDisableStatus() && !EnableRemoteQualification)
            {
                ChangeHive(HiveStatus.Disable);
            }
            else
            {
                ChangeHive(HiveManager.GetCurrentHiveStatus());
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = LogOutConfirm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                AuthorityManager.Instance.ChangeLevel(OpLevel.NoLogin);
            }
        }
        #endregion
    }
}
