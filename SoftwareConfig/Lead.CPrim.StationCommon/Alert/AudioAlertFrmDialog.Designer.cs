
namespace Lead.CPrim.StationCommon.Alert
{
    partial class AudioAlertFrmDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lblErrMsgValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.labErrDetail = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblErrMsg = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblStartTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblErrCode = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cboErrCodeValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.rtbErrDetailValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpOptions = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIGroupBox();
            this.cboErrDealHandle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.rtb_ErrMessage = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIRichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConfirm = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnMute = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnShieldedAlarm = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lblStartTimeValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.lblErrMsgValue, 2, 2);
            this.tlpMain.Controls.Add(this.labErrDetail, 1, 3);
            this.tlpMain.Controls.Add(this.lblErrMsg, 1, 2);
            this.tlpMain.Controls.Add(this.lblStartTime, 1, 0);
            this.tlpMain.Controls.Add(this.lblErrCode, 1, 1);
            this.tlpMain.Controls.Add(this.cboErrCodeValue, 2, 1);
            this.tlpMain.Controls.Add(this.rtbErrDetailValue, 2, 3);
            this.tlpMain.Controls.Add(this.panel1, 0, 5);
            this.tlpMain.Controls.Add(this.panel3, 0, 6);
            this.tlpMain.Controls.Add(this.lblStartTimeValue, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 35);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpMain.Size = new System.Drawing.Size(500, 565);
            this.tlpMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpMain.TabIndex = 3;
            this.tlpMain.TagString = null;
            // 
            // lblErrMsgValue
            // 
            this.lblErrMsgValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblErrMsgValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrMsgValue.FillColor2 = System.Drawing.Color.White;
            this.lblErrMsgValue.FillDisableColor = System.Drawing.Color.White;
            this.lblErrMsgValue.FillReadOnlyColor = System.Drawing.Color.White;
            this.lblErrMsgValue.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblErrMsgValue.ForeColor = System.Drawing.Color.Black;
            this.lblErrMsgValue.ForeDisableColor = System.Drawing.Color.Black;
            this.lblErrMsgValue.ForeReadOnlyColor = System.Drawing.Color.Black;
            this.lblErrMsgValue.Location = new System.Drawing.Point(154, 105);
            this.lblErrMsgValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblErrMsgValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.lblErrMsgValue.Name = "lblErrMsgValue";
            this.lblErrMsgValue.ReadOnly = true;
            this.lblErrMsgValue.RectColor = System.Drawing.Color.Transparent;
            this.lblErrMsgValue.RectDisableColor = System.Drawing.Color.Transparent;
            this.lblErrMsgValue.RectReadOnlyColor = System.Drawing.Color.Transparent;
            this.lblErrMsgValue.ShowText = false;
            this.lblErrMsgValue.Size = new System.Drawing.Size(327, 40);
            this.lblErrMsgValue.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblErrMsgValue.StyleCustomMode = true;
            this.lblErrMsgValue.TabIndex = 13;
            this.lblErrMsgValue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErrMsgValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labErrDetail
            // 
            this.labErrDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labErrDetail.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labErrDetail.Location = new System.Drawing.Point(17, 150);
            this.labErrDetail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labErrDetail.Name = "labErrDetail";
            this.tlpMain.SetRowSpan(this.labErrDetail, 2);
            this.labErrDetail.Size = new System.Drawing.Size(131, 100);
            this.labErrDetail.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.labErrDetail.TabIndex = 7;
            this.labErrDetail.Text = "Error Detail:";
            this.labErrDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labErrDetail.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrMsg.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblErrMsg.Location = new System.Drawing.Point(17, 100);
            this.lblErrMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(131, 50);
            this.lblErrMsg.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblErrMsg.TabIndex = 2;
            this.lblErrMsg.Text = "Error Msg:";
            this.lblErrMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErrMsg.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblStartTime
            // 
            this.lblStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartTime.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartTime.Location = new System.Drawing.Point(17, 0);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(131, 50);
            this.lblStartTime.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "Start Time:";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStartTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblErrCode
            // 
            this.lblErrCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrCode.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblErrCode.Location = new System.Drawing.Point(17, 50);
            this.lblErrCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrCode.Name = "lblErrCode";
            this.lblErrCode.Size = new System.Drawing.Size(131, 50);
            this.lblErrCode.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblErrCode.TabIndex = 1;
            this.lblErrCode.Text = "Error Code:";
            this.lblErrCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblErrCode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cboErrCodeValue
            // 
            this.cboErrCodeValue.DataSource = null;
            this.cboErrCodeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboErrCodeValue.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cboErrCodeValue.FillColor = System.Drawing.Color.White;
            this.cboErrCodeValue.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboErrCodeValue.Items.AddRange(new object[] {
            "F-12"});
            this.cboErrCodeValue.Location = new System.Drawing.Point(154, 55);
            this.cboErrCodeValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboErrCodeValue.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboErrCodeValue.Name = "cboErrCodeValue";
            this.cboErrCodeValue.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboErrCodeValue.RectColor = System.Drawing.Color.Transparent;
            this.cboErrCodeValue.Size = new System.Drawing.Size(327, 40);
            this.cboErrCodeValue.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cboErrCodeValue.StyleCustomMode = true;
            this.cboErrCodeValue.TabIndex = 6;
            this.cboErrCodeValue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboErrCodeValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rtbErrDetailValue
            // 
            this.rtbErrDetailValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbErrDetailValue.FillColor = System.Drawing.Color.White;
            this.rtbErrDetailValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbErrDetailValue.Location = new System.Drawing.Point(154, 155);
            this.rtbErrDetailValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbErrDetailValue.MinimumSize = new System.Drawing.Size(1, 1);
            this.rtbErrDetailValue.Name = "rtbErrDetailValue";
            this.rtbErrDetailValue.Padding = new System.Windows.Forms.Padding(2);
            this.tlpMain.SetRowSpan(this.rtbErrDetailValue, 2);
            this.rtbErrDetailValue.ShowText = false;
            this.rtbErrDetailValue.Size = new System.Drawing.Size(327, 90);
            this.rtbErrDetailValue.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.rtbErrDetailValue.TabIndex = 8;
            this.rtbErrDetailValue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rtbErrDetailValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel1
            // 
            this.tlpMain.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 254);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpOptions);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 254);
            this.panel2.TabIndex = 10;
            // 
            // grpOptions
            // 
            this.grpOptions.BackColor = System.Drawing.Color.Transparent;
            this.grpOptions.Controls.Add(this.cboErrDealHandle);
            this.grpOptions.Controls.Add(this.rtb_ErrMessage);
            this.grpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOptions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(127)))), ((int)(((byte)(126)))));
            this.grpOptions.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(127)))), ((int)(((byte)(126)))));
            this.grpOptions.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(127)))), ((int)(((byte)(126)))));
            this.grpOptions.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpOptions.ForeColor = System.Drawing.Color.Black;
            this.grpOptions.Location = new System.Drawing.Point(0, 0);
            this.grpOptions.Margin = new System.Windows.Forms.Padding(10);
            this.grpOptions.MinimumSize = new System.Drawing.Size(1, 1);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Padding = new System.Windows.Forms.Padding(5, 26, 5, 3);
            this.grpOptions.RectColor = System.Drawing.Color.White;
            this.grpOptions.Size = new System.Drawing.Size(494, 254);
            this.grpOptions.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.grpOptions.StyleCustomMode = true;
            this.grpOptions.TabIndex = 4;
            this.grpOptions.Text = "处理选项";
            this.grpOptions.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.grpOptions.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cboErrDealHandle
            // 
            this.cboErrDealHandle.DataSource = null;
            this.cboErrDealHandle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cboErrDealHandle.FillColor = System.Drawing.Color.White;
            this.cboErrDealHandle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboErrDealHandle.Location = new System.Drawing.Point(5, 210);
            this.cboErrDealHandle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboErrDealHandle.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboErrDealHandle.Name = "cboErrDealHandle";
            this.cboErrDealHandle.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboErrDealHandle.Size = new System.Drawing.Size(484, 41);
            this.cboErrDealHandle.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cboErrDealHandle.TabIndex = 1;
            this.cboErrDealHandle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cboErrDealHandle.Watermark = "";
            this.cboErrDealHandle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rtb_ErrMessage
            // 
            this.rtb_ErrMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_ErrMessage.FillColor = System.Drawing.Color.White;
            this.rtb_ErrMessage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_ErrMessage.Location = new System.Drawing.Point(5, 26);
            this.rtb_ErrMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtb_ErrMessage.MinimumSize = new System.Drawing.Size(1, 1);
            this.rtb_ErrMessage.Name = "rtb_ErrMessage";
            this.rtb_ErrMessage.Padding = new System.Windows.Forms.Padding(2);
            this.rtb_ErrMessage.ShowText = false;
            this.rtb_ErrMessage.Size = new System.Drawing.Size(484, 225);
            this.rtb_ErrMessage.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.rtb_ErrMessage.TabIndex = 0;
            this.rtb_ErrMessage.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rtb_ErrMessage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel3
            // 
            this.tlpMain.SetColumnSpan(this.panel3, 4);
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Controls.Add(this.btnMute);
            this.panel3.Controls.Add(this.btnShieldedAlarm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 513);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(494, 49);
            this.panel3.TabIndex = 10;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(350, 7);
            this.btnConfirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(130, 35);
            this.btnConfirm.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnMute
            // 
            this.btnMute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMute.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMute.Location = new System.Drawing.Point(15, 7);
            this.btnMute.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(130, 35);
            this.btnMute.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnMute.TabIndex = 0;
            this.btnMute.Text = "静音";
            this.btnMute.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMute.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnShieldedAlarm
            // 
            this.btnShieldedAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShieldedAlarm.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShieldedAlarm.Location = new System.Drawing.Point(168, 7);
            this.btnShieldedAlarm.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnShieldedAlarm.Name = "btnShieldedAlarm";
            this.btnShieldedAlarm.Radius = 1;
            this.btnShieldedAlarm.Size = new System.Drawing.Size(159, 35);
            this.btnShieldedAlarm.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnShieldedAlarm.TabIndex = 1;
            this.btnShieldedAlarm.Text = "屏蔽胶阀报警";
            this.btnShieldedAlarm.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShieldedAlarm.Visible = false;
            this.btnShieldedAlarm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnShieldedAlarm.Click += new System.EventHandler(this.btnShieldedAlarm_Click);
            // 
            // lblStartTimeValue
            // 
            this.lblStartTimeValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblStartTimeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartTimeValue.FillColor2 = System.Drawing.Color.White;
            this.lblStartTimeValue.FillDisableColor = System.Drawing.Color.White;
            this.lblStartTimeValue.FillReadOnlyColor = System.Drawing.Color.White;
            this.lblStartTimeValue.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblStartTimeValue.ForeColor = System.Drawing.Color.Black;
            this.lblStartTimeValue.ForeDisableColor = System.Drawing.Color.Black;
            this.lblStartTimeValue.ForeReadOnlyColor = System.Drawing.Color.Black;
            this.lblStartTimeValue.Location = new System.Drawing.Point(154, 5);
            this.lblStartTimeValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblStartTimeValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.lblStartTimeValue.Name = "lblStartTimeValue";
            this.lblStartTimeValue.ReadOnly = true;
            this.lblStartTimeValue.RectColor = System.Drawing.Color.Transparent;
            this.lblStartTimeValue.RectDisableColor = System.Drawing.Color.Transparent;
            this.lblStartTimeValue.RectReadOnlyColor = System.Drawing.Color.Transparent;
            this.lblStartTimeValue.ShowText = false;
            this.lblStartTimeValue.Size = new System.Drawing.Size(327, 40);
            this.lblStartTimeValue.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblStartTimeValue.StyleCustomMode = true;
            this.lblStartTimeValue.TabIndex = 11;
            this.lblStartTimeValue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStartTimeValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AudioAlertFrmDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(127)))), ((int)(((byte)(126)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.ControlBox = false;
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioAlertFrmDialog";
            this.RectColor = System.Drawing.Color.Transparent;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "DownTime报警弹窗";
            this.TitleColor = System.Drawing.Color.Gray;
            this.TopMost = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 477, 478);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmError_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpMain;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblStartTime;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblErrCode;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lblErrMsg;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIGroupBox grpOptions;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox cboErrDealHandle;
        private ProxyTools.SunnyUI.Controls.UIRichTextBox rtb_ErrMessage;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnConfirm;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnShieldedAlarm;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnMute;
        private ProxyTools.SunnyUI.Controls.UIComboBox cboErrCodeValue;
        private ProxyTools.SunnyUI.Controls.UILabel labErrDetail;
        private ProxyTools.SunnyUI.Controls.UIRichTextBox rtbErrDetailValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ProxyTools.SunnyUI.Controls.UITextBox lblErrMsgValue;
        private ProxyTools.SunnyUI.Controls.UITextBox lblStartTimeValue;
    }
}