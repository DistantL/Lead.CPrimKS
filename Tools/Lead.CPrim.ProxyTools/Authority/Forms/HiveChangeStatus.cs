using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ProxyTools.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    public partial class HiveChangeStatus : UIForm
    {
        #region Field

        /// <summary>UI按钮</summary>
        UIButton[] btns = new UIButton[] { };

        public List<string> _pdSelects = new List<string>();
        #endregion



        #region Ctor
        public HiveChangeStatus()
        {
            InitializeComponent();
            btns = new UIButton[] { btnRun, btnDT, btnPlanDT, btnIdle, btnEngineering };
            SetStyle();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event

        private void HiveChangeStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        #endregion



        #region Audio_Button_Event
        /// <summary>
        /// Running状态切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Audio_BtnRun_Click(object sender, EventArgs e)
        {
            string msg = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HiveChangeStatus_ConfirmToRunning", "确认切换HIVE状态为[Running]!");
            DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
            {
                if(ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                {
                    HiveManager.SetHiveStatusByManual(HiveStatus.Running);
                    this.Close();
                }
            });
        }

        /// <summary>
        /// Idle状态切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Audio_BtnIdle_Click(object sender, EventArgs e)
        {
            string msg = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HiveChangeStatus_ConfirmToIdle", "确认切换HIVE状态为[Idle]!");
            DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
            {
                if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                {
                    HiveManager.SetHiveStatusByManual(HiveStatus.Idle);
                    this.Close();
                }
            });
        }

        /// <summary>
        /// Engineering状态切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Audio_Btn_Hive_Engineering_Click(object sender, EventArgs e)
        {
            string msg = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HiveChangeStatus_ConfirmToEngineering", "确认切换HIVE状态为[Engineering]!");
            DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
            {
                if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                {
                    HiveManager.SetHiveStatusByManual(HiveStatus.Engineering);
                    this.Close();
                }
            });
        }

        /// <summary>
        /// DT状态切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Audio_BtnDT_Click(object sender, EventArgs e)
        {
            string msg = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HiveChangeStatus_ConfirmToDowntime", "确认切换HIVE状态为[Downtime]!");
            DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
            {
                if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                {
                    LogHelper.LogAdd(LogLevel.Warn, "(Y-1)Manually Downtime In Hive Statue Change Select UI", "UI");
                    HiveManager.SetHiveStatusByManual(HiveStatus.DT);
                    this.Close();
                }
            });
        }

        private HivePlannedDowntime frm = new HivePlannedDowntime();

        /// <summary>Plan_DT状态切换</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Audio_Btn_Hive_PlannedDowntime_Click(object sender, EventArgs e)
        {
            _pdSelects.Clear();
            frm.StartPosition = FormStartPosition.CenterScreen;

            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                frm.GetResult().ForEach(p => _pdSelects.Add(p));
                if (_pdSelects.Count > 0)
                {
                    switch (_pdSelects[0].Substring(_pdSelects[0].IndexOf('(')))
                    {
                        case "(PD-08)":
                            {
                                if (AuthorityManager.Instance.AccessaryNames == null || AuthorityManager.Instance.AccessaryNames.Count == 0)
                                {
                                    MessageBox.Show(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HiveChangeStatus_AccessaryNamesisEmpty", "无辅料名称,请设置[系统设置->界面设置->辅料名称]"));
                                    return;
                                }
                                string msg = ChangePDtoShow(_pdSelects[0]);
                                DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
                                {
                                    if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                                    {
                                        var accessaryChangeFrm = new InputAccessarySN_Form(ChangePDtoShow(_pdSelects[0]), AuthorityManager.Instance.CurrentOperatorID);
                                        DialogResult = accessaryChangeFrm.ShowDialog();
                                        if (DialogResult == DialogResult.OK)
                                        {
                                            HiveManager.PlanedDowntimeSelect = "(PD-08);" + (accessaryChangeFrm.Old_SN ?? " ") + ";" + (accessaryChangeFrm.New_SN ?? " ") + ";";
                                            HiveManager.SetHiveStatusByManual(HiveStatus.Plan_DT);
                                            DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                    }
                                });
                            }
                            break;
                        case "(PD-11)":
                            {
                                var modeSelectFrm = new Frm_LAD_ModeSelect();
                                modeSelectFrm.ShowDialog();
                                if (modeSelectFrm.DialogResult == DialogResult.OK)
                                {
                                    string msg = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HiveChangeStatus_ConfirmToLAD", "PD-11:LAD \n 设备将切换为Audit模式");
                                    DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
                                    {
                                        if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                                        {
                                            HiveManager.PlanedDowntimeSelect = "LAD (PD-11)" + modeSelectFrm.TagString;
                                            HiveManager.SetHiveStatusByManual(HiveStatus.Plan_DT);
                                            DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                    });
                                }
                            }
                            break;
                        case "(PD-13)":
                            {
                                var ccdTestModeSelectFrm = new Frm_CCD_Repeatability_Test_ModeSelect();
                                ccdTestModeSelectFrm.ShowDialog();
                                if (ccdTestModeSelectFrm.DialogResult == DialogResult.OK)
                                {
                                    var modeSelectFrm = new Frm_LAD_ModeSelect();
                                    modeSelectFrm.ShowDialog();
                                    if (modeSelectFrm.DialogResult == DialogResult.OK)
                                    {
                                        string msg = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HiveChangeStatus_ConfirmToCCDTest", "PD-13:CCD 动静态测试\r\n设备将切换为Audit模式");
                                        DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
                                        {
                                            if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                                            {
                                                HiveManager.PlanedDowntimeSelect = "(PD-13)" + ccdTestModeSelectFrm.TagString + "_" + modeSelectFrm.TagString;
                                                HiveManager.SetHiveStatusByManual(HiveStatus.Plan_DT);
                                                DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        });
                                    }
                                }
                            }
                            break;
                        case "(PD-15)":
                            {
                                string msg = ChangePDtoShow(_pdSelects[0]);
                                DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
                                {
                                    if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                                    {
                                        HiveManager.PlanedDowntimeSelect = _pdSelects[0];
                                        HiveManager.SetHiveStatusByManual(HiveStatus.Plan_DT);
                                        DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                });
                            }
                            break;
                        default:
                            {
                                string msg = ChangePDtoShow(_pdSelects[0]);
                                DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
                                {
                                    if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                                    {
                                        HiveManager.PlanedDowntimeSelect = _pdSelects[0];
                                        HiveManager.SetHiveStatusByManual(HiveStatus.Plan_DT);
                                        DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                });
                            }
                            break;
                    }
                }
            }
        }
        #endregion




        #region Method_ExternalUsing
        /// <summary>按钮状态设置</summary>
        public void SetEnable()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(SetEnable));
                return;
            }

            foreach (var btn in btns)
            {
                btn.Enabled = false;
                btn.ForeColor = Color.FromArgb(64, 64, 64);
            }

            switch (AuthorityManager.Instance.Level)
            {
                case OpLevel.Level1:
                    {
                    }
                    break;
                case OpLevel.Level2:
                    {
                        switch (HiveManager.GetCurrentHiveStatus())
                        {
                            case HiveStatus.Running:
                            case HiveStatus.Idle:
                            case HiveStatus.Engineering:
                                foreach (var btn in btns)
                                {
                                    if (btn.Name == btnPlanDT.Name || btn.Name == btnDT.Name)
                                    {
                                        btn.Enabled = true;
                                        btn.ForeColor = Color.Black;
                                    }
                                }
                                break;
                            case HiveStatus.Plan_DT:
                            case HiveStatus.DT:
                                foreach (var btn in btns)
                                {
                                    if (btn.Name == btnRun.Name || btn.Name == btnEngineering.Name)
                                    {
                                        btn.Enabled = true;
                                        btn.ForeColor = Color.Black;
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case OpLevel.Level3:
                    {
                        switch (HiveManager.GetCurrentHiveStatus())
                        {
                            case HiveStatus.Running:
                                foreach (var btn in btns)
                                {
                                    if (btn.Name == btnIdle.Name || btn.Name == btnPlanDT.Name || btn.Name == btnDT.Name)
                                    {
                                        btn.Enabled = true;
                                        btn.ForeColor = Color.Black;
                                    }
                                }
                                break;
                            case HiveStatus.Idle:
                                foreach (var btn in btns)
                                {
                                    if (btn.Name == btnRun.Name || btn.Name == btnEngineering.Name || btn.Name == btnPlanDT.Name || btn.Name == btnDT.Name)
                                    {
                                        btn.Enabled = true;
                                        btn.ForeColor = Color.Black;
                                    }
                                }
                                break;
                            case HiveStatus.Engineering:
                                foreach (var btn in btns)
                                {
                                    if (btn.Name == btnIdle.Name || btn.Name == btnPlanDT.Name || btn.Name == btnDT.Name)
                                    {
                                        btn.Enabled = true;
                                        btn.ForeColor = Color.Black;
                                    }
                                }
                                break;
                            case HiveStatus.Plan_DT:
                            case HiveStatus.DT:
                                foreach (var btn in btns)
                                {
                                    if (btn.Name == btnRun.Name || btn.Name == btnEngineering.Name)
                                    {
                                        btn.Enabled = true;
                                        btn.ForeColor = Color.Black;
                                    }
                                }
                                break;
                        }
                    }
                    break;
                default:
                    foreach (var btn in btns)
                    {
                        btn.Enabled = false;
                        btn.ForeColor = Color.FromArgb(64, 64, 64);
                    }
                    break;
            }
        }
        /// <summary>设置按钮背景颜色</summary>
        /// <param name="status"></param>
        public void SetButtonBackColor(HiveStatus status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<HiveStatus>(SetButtonBackColor), new object[1] { status });
                return;
            }
            switch (status)
            {
                case HiveStatus.DT:
                    SetButtonBackColor(btnDT);
                    break;
                case HiveStatus.Engineering:
                    SetButtonBackColor(btnEngineering);
                    break;
                case HiveStatus.Idle:
                    SetButtonBackColor(btnIdle);
                    break;
                case HiveStatus.Plan_DT:
                    SetButtonBackColor(btnPlanDT);
                    break;
                case HiveStatus.Running:
                    SetButtonBackColor(btnRun);
                    break;
                case HiveStatus.Disable:
                default:
                    SetButtonBackColor();
                    break;
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

        /// <summary>设置按钮背景颜色</summary>
        /// <param name="btn"></param>
        private void SetButtonBackColor(UIButton btn = null)
        {
            foreach (var button in btns)
            {
                if (btn != null && button.Name == btn.Name)
                {
                    button.FillColor = Color.FromArgb(26, 137, 255); ;
                }
                else
                {
                    button.FillColor = BackColor;
                }
            }
        }

        private string ChangePDtoShow(string pd)
        {
            string result = "";
            if (!string.IsNullOrWhiteSpace(pd))
            {
                int startIndex = pd.IndexOf('(');
                int endIndex = pd.IndexOf(')');

                if (startIndex != -1 && endIndex != -1 && startIndex < endIndex)
                {
                    result = pd.Substring(startIndex + 1, endIndex - startIndex - 1) + " : " + pd.Substring(0, startIndex);
                }
            }
            return result;
        }

        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HiveChangeStatus_Title", "HIVE手动切换");
        }
        #endregion
    }
}
