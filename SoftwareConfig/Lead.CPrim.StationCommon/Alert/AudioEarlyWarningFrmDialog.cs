using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Authority.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.Alert
{
    /// <summary>报警弹窗控件</summary>
    public partial class AudioEarlyWarningFrmDialog : UIForm
    {
        #region Define_Event
        #endregion



        #region Field
        private bool _isMuted = false;

        private Stopwatch _stopwatch = new Stopwatch();
        #endregion



        #region Ctor
        public AudioEarlyWarningFrmDialog()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(255, 149, 202);
            grpOptions.FillColor = BackColor;

            btnMute.SetStyle(ControlStyle.Light);
            btnConfirm.SetStyle(ControlStyle.Light);

            _stopwatch.Start();
            timer1.Enabled = true;
            

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Event_System
        private void FrmError_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _isMuted = true;
                _stopwatch.Stop();
                timer1.Enabled = false;
               
                List<IEle> eles = Global.ElesManagerTransfer.GetAllIEle();
                IEle _ele = eles.FirstOrDefault(p => p.Name == "三色灯_蜂鸣器");
                if (_ele != null)
                {
                    _ele.IEleInit();
                    IEleDO _do = (IEleDO)_ele;
                    _do.Write(false);
                }

                _ele = eles.FirstOrDefault(p => p.Name == "三色灯_红");
                if (_ele != null)
                {
                    _ele.IEleInit();
                    IEleDO _do = (IEleDO)_ele;
                    _do.Write(false);
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion



        #region Event_Button
        /// <summary>静音</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMute_Click(object sender, EventArgs e)
        {
            _isMuted = !_isMuted;
        }

        /// <summary>确认</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            TopMost = false;
            var form = new AudioPassWord2StepForm(Color.FromArgb(255, 149, 202))
            {
                Text = "Close the notification after have you read it"
            };
            AuthorityManager.Instance.ShowLevelLoginUI = true;
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Close();
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>数据更新</summary>
        /// <param name="info"></param>
        public void UpdateUI(string info)
        {
            DisplayUI(info);
        }
        #endregion



        #region Method_InternalUsing
        private void DisplayUI(string info) 
        {
            lblStartTimeValue.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            rtbDetailValue.Text = info;
            rtb_ErrMessage.Text = info;

            cboErrDealHandle.Items.AddRange(new string[] { lblStartTimeValue.Text });
            if (cboErrDealHandle.Items.Count > 0)
            {
                cboErrDealHandle.SelectedIndex = 0;
            }
        }
        #endregion

        public void OnLanguageChanged()
        {
            lblStartTime.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_StartTime", "开始时间:");
            labDetail.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_ErrorDetail", "报警信息:");
            grpOptions.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_Options", "处理选项");
            btnMute.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_Mute", "静音");
            btnConfirm.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_AudioAlertFrmDialog_Confirm", "确认");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                List<IEle> eles = Global.ElesManagerTransfer.GetAllIEle();
                IEle _ele = eles.FirstOrDefault(p => p.Name == "三色灯_蜂鸣器");
                if (_ele != null) 
                {
                    _ele.IEleInit();
                    IEleDO _do = (IEleDO)_ele;
                    if (_do.Read())
                    {
                        if (_isMuted)
                        {
                            _do.Write(false);
                        }
                        else if (_stopwatch.ElapsedMilliseconds > 2000)
                        {
                            _do.Write(false);
                            _stopwatch.Restart();
                        }
                    }
                    else 
                    {
                        if (!_isMuted && _stopwatch.ElapsedMilliseconds > 1000)
                        {
                            _do.Write(true);
                            _stopwatch.Restart();
                        }
                    }
                }

                _ele = eles.FirstOrDefault(p => p.Name == "三色灯_绿");
                if (_ele != null)
                {
                    _ele.IEleInit();
                    IEleDO _do = (IEleDO)_ele;
                    if (!_do.Read())
                    {
                        _do.Write(true);
                    }
                }

                _ele = eles.FirstOrDefault(p => p.Name == "三色灯_红");
                if (_ele != null)
                {
                    _ele.IEleInit();
                    IEleDO _do = (IEleDO)_ele;
                    if (!_do.Read())
                    {
                        _do.Write(true);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
