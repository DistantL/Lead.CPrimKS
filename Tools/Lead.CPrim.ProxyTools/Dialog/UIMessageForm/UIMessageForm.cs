/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIMessageForm.cs
 * Author: Victor
 * Description: 消息提示窗体
 * CreateTime: 2020-01-01
 * Inherit：UIControl
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2021-11-09: V3.0.8 多个按钮显示时增加FocusLine
 *
 * <3.3.22.1010><Victor><20221015>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.CustomControl
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.CustomControl
{
    public sealed partial class UIMessageForm : UIForm
    {
        #region Field
        /// <summary>
        /// 定时器
        /// </summary>
        private Timer time = null;
        #endregion



        #region Prop
        int _existTime;
        public int ExistTime
        {
            get => _existTime;
            set
            {
                _existTime = value;
                lblTime.Text = value <= 0 ? "" : value.ToString();
            }
        }

        public bool IsOK { get; private set; }

        private bool _showCancel = true;
        /// <summary>
        /// True：显示取消按钮；<br/>
        /// False：不显示取消按钮；<br/>
        /// </summary>
        public bool ShowCancel
        {
            get => _showCancel;
            set
            {
                _showCancel = value;
                btnCancel.Visible = value;
                OnSizeChanged(null);
            }
        }
        #endregion



        #region Ctor

        public UIMessageForm()
        {
            InitializeComponent();
            lblTime.Text = "";

            btnOK.Text = ULocalize.OK;
            btnCancel.Text = ULocalize.Cancel;
        }
        public UIMessageForm(string btnOKName, string btnCancelName) : this()
        {
            btnOK.Text = btnOKName;
            btnCancel.Text = btnCancelName;
        }
        #endregion



        #region EventSystem
        public override void SetStyleColor(UIBaseStyle uiColor)
        {
            base.SetStyleColor(uiColor);

            if (btnOK != null)
            {
                btnOK.FillColor = BackColor;
                btnOK.RectColor = Color.FromArgb(36, uiColor.ButtonRectColor);
                btnOK.ForeColor = uiColor.LabelForeColor;
            }

            if (btnCancel != null)
            {
                btnCancel.FillColor = BackColor;
                btnCancel.RectColor = Color.FromArgb(36, uiColor.ButtonRectColor);
                btnCancel.ForeColor = uiColor.LabelForeColor;
            }

            if (lbMsg != null)
            {
                lbMsg.ForeColor = uiColor.LabelForeColor;
                lbMsg.BackColor = BackColor;
                lbMsg.SelectionColor = RectColor;
            }
        }

        protected override void DoEnter()
        {
            base.DoEnter();
            btnOK_Click(null, null);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (btnOK == null || btnCancel == null)
            {
                return;
            }

            if (_showCancel)
            {
                btnOK.RectSides = ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right;
                btnOK.Width = btnCancel.Width = Width / 2 - 2;
                btnCancel.Left = btnOK.Left + btnOK.Width - 1;
                btnCancel.Width = Width - btnCancel.Left - 2;
            }
            else
            {
                btnOK.RectSides = ToolStripStatusLabelBorderSides.Top;
                btnOK.Width = Width - 4;
            }

            btnCancel.Left = btnOK.Right - 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            IsOK = false;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            IsOK = true;
            Close();
        }

        private void btnOK_MouseEnter(object sender, EventArgs e)
        {
            ((UIButton)sender).RadiusSides = UICornerRadiusSides.All;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            ((UIButton)sender).RadiusSides = UICornerRadiusSides.None;
        }

        private void UIMessageForm_Load(object sender, EventArgs e)
        {
            if (ExistTime < 1)
            {
                return;
            }

            time = new Timer
            {
                Interval = 1000
            };
            time.Tick += InstanceTick;
            time.Start();
        }

        private void UIMessageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (time != null && time.Enabled)
            {
                time.Stop();
                time.Dispose();
                time = null;
            }
        }
        #endregion



        #region MethodExternalUsing
        public void ShowMessage(string message, string title, bool showCancel, UIStyle style = UIStyle.Blue)
        {
            Style = style;
            Text = title;
            lbMsg.Text = message;
            ShowCancel = showCancel;
            btnOK.ShowFocusLine = btnCancel.ShowFocusLine = showCancel;
        }
        public void ShowMessage(string message, string title, bool showCancel, int existTime, UIStyle style = UIStyle.Blue)
        {
            Style = style;
            Text = title;
            lbMsg.Text = message;
            ShowCancel = showCancel;
            ExistTime = existTime;
            btnOK.ShowFocusLine = btnCancel.ShowFocusLine = showCancel;
        }
        #endregion



        #region MethodInternalUsing
        void InstanceTick(object sender, EventArgs e)
        {
            if (ExistTime >= 0)
            {
                lblTime.Text = ExistTime.ToString();
                ExistTime--;
            }
            else
            {
                btnCancel_Click(null, null);
            }
        }
        #endregion
    }
}