using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.Alert
{
    /// <summary>
    /// 报警弹窗控件
    /// </summary>
    public partial class AudioAlertFrmDialog : UIForm
    {
        #region Define_Event
        /// <summary>清除报警时发生(Audio)</summary>
        public event Action<bool, string> OnClrAudioErr;
        #endregion



        #region Field

        private bool _isMuted = false;

        private List<AlertInfo> _listAlertInfos = new List<AlertInfo>();
        #endregion



        #region Ctor
        public AudioAlertFrmDialog()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(235, 161, 151);
            grpOptions.FillColor = BackColor;

            btnMute.SetStyle(ControlStyle.Light);
            btnShieldedAlarm.SetStyle(ControlStyle.Light);
            btnConfirm.SetStyle(ControlStyle.Light);
            //btnMute.SetStyle(Color.WhiteSmoke, Color.FromArgb(64, 64, 64));
            //btnShieldedAlarm.SetStyle(Color.WhiteSmoke, Color.FromArgb(64, 64, 64));
            //btnConfirm.SetStyle(Color.WhiteSmoke, Color.FromArgb(64, 64, 64));
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Event_System
        private void FrmError_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventManager.SwitchStatus(SwitchStatus.ClrErr);
        }
        #endregion



        #region Event_Button
        /// <summary>确认</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!AuthorityManager.Instance.VerifyLevel2Permission(true))
            {
                return;
            }

            DialogForOperateLoginForm.Instance.EnqueueDialog("请刷卡", ok =>
            {
                if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                {
                    string errCode = cboErrCodeValue.SelectedItem?.ToString().Trim();
                    OnClrAudioErr?.Invoke(true, errCode);

                    cboErrCodeValue.Items.Remove(errCode);
                    _listAlertInfos.RemoveAll(p => p.ErrorCode == errCode);

                    if (cboErrCodeValue.Items.Count <= 0)
                    {
                        Close();
                    }
                    else
                    {
                        DisplayUI();
                    }
                }
            });
        }

        /// <summary>静音</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMute_Click(object sender, EventArgs e)
        {

        }

        /// <summary>屏蔽胶阀报警</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShieldedAlarm_Click(object sender, EventArgs e)
        {

        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="alertInfos"></param>
        internal void UpdateUI(List<AlertInfo> alertInfos)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<AlertInfo>>(UpdateUI), alertInfos);
            }
            else
            {
                _listAlertInfos.Clear();
                cboErrCodeValue.Items.Clear();
                foreach (AlertInfo alertInfo in alertInfos)
                {
                    cboErrCodeValue.Items.Add(alertInfo.ErrorCode);
                    _listAlertInfos.Add(alertInfo);
                }

                DisplayUI();
            }
        }
        #endregion



        #region Method_InternalUsing
        private void DisplayUI()
        {
            cboErrCodeValue.SelectedIndex = 0;
            AlertInfo info = _listAlertInfos.Find(p => p.ErrorCode == cboErrCodeValue.SelectedItem?.ToString().Trim());
            lblStartTimeValue.Text = info.CreateTime.ToString("yyyy/MM/dd HH:mm:ss");
            lblErrMsgValue.Text = info.ErrorMessage;
            AlarmInfo alarmInfo = AlarmManager.Instance.GetAlarmInfoByErrorMessage("(" + info.ErrorCode + ")" + info.ErrorDetail);
            if (alarmInfo != null)
            {
                switch (NLocalizer.Language)
                {
                    case "en-US":
                        rtbErrDetailValue.Text = alarmInfo.ErrorDetailInEN;
                        rtb_ErrMessage.Text = alarmInfo.ErrorDetailInEN;
                        break;
                    case "vi-VN":
                        rtbErrDetailValue.Text = alarmInfo.ErrorDetailInVN;
                        rtb_ErrMessage.Text = alarmInfo.ErrorDetailInVN;
                        break;
                    default:
                        rtbErrDetailValue.Text = alarmInfo.ErrorDetail;
                        rtb_ErrMessage.Text = alarmInfo.ErrorDetail;
                        break;
                }

                if (alarmInfo.ErrorLevel == ErrorLevel.三级报警)
                {
                    EventManager.SwitchStatus(SwitchStatus.RunningWithNotice);
                }
            }
            else
            {
                rtbErrDetailValue.Text = info.ErrorDetail;
                rtb_ErrMessage.Text = info.ErrorDetail;
            }

            if (info.ErrorDealHandle != null && info.ErrorDealHandle.Count > 0)
            {
                cboErrDealHandle.Items.AddRange(info.ErrorDealHandle.ToArray());
                if (cboErrDealHandle.Items.Count > 0)
                {
                    cboErrDealHandle.SelectedIndex = 0;
                }
            }
        }

        public void OnLanguageChanged()
        {
            lblErrCode.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_ErrorCode", "报警代码:");
            lblStartTime.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_StartTime", "开始时间:");
            lblErrMsg.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_ErrorCatergory", "报警类型:");
            labErrDetail.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_ErrorDetail", "报警信息:");
            grpOptions.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_Options", "处理选项");
            btnMute.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_Mute", "静音");
            btnConfirm.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_Confirm", "确认");
        }
        #endregion
    }
}
