
namespace Lead.CPrim.StationCommon.Alert
{
    partial class AudioEarlyWarningFrmDialog
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
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.labDetail = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblStartTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.rtbDetailValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpOptions = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIGroupBox();
            this.cboErrDealHandle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.rtb_ErrMessage = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIRichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConfirm = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnMute = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lblStartTimeValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.tlpMain.Controls.Add(this.labDetail, 1, 1);
            this.tlpMain.Controls.Add(this.lblStartTime, 1, 0);
            this.tlpMain.Controls.Add(this.rtbDetailValue, 2, 1);
            this.tlpMain.Controls.Add(this.panel1, 0, 3);
            this.tlpMain.Controls.Add(this.panel3, 0, 4);
            this.tlpMain.Controls.Add(this.lblStartTimeValue, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 35);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(500, 565);
            this.tlpMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpMain.TabIndex = 3;
            this.tlpMain.TagString = null;
            // 
            // labDetail
            // 
            this.labDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDetail.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDetail.Location = new System.Drawing.Point(17, 50);
            this.labDetail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labDetail.Name = "labDetail";
            this.tlpMain.SetRowSpan(this.labDetail, 2);
            this.labDetail.Size = new System.Drawing.Size(131, 100);
            this.labDetail.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.labDetail.TabIndex = 7;
            this.labDetail.Text = "Detail Msg:";
            this.labDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labDetail.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            // rtbDetailValue
            // 
            this.rtbDetailValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDetailValue.FillColor = System.Drawing.Color.White;
            this.rtbDetailValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbDetailValue.Location = new System.Drawing.Point(154, 55);
            this.rtbDetailValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbDetailValue.MinimumSize = new System.Drawing.Size(1, 1);
            this.rtbDetailValue.Name = "rtbDetailValue";
            this.rtbDetailValue.Padding = new System.Windows.Forms.Padding(2);
            this.tlpMain.SetRowSpan(this.rtbDetailValue, 2);
            this.rtbDetailValue.ShowText = false;
            this.rtbDetailValue.Size = new System.Drawing.Size(327, 90);
            this.rtbDetailValue.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.rtbDetailValue.TabIndex = 8;
            this.rtbDetailValue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.rtbDetailValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel1
            // 
            this.tlpMain.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 354);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpOptions);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 354);
            this.panel2.TabIndex = 10;
            // 
            // grpOptions
            // 
            this.grpOptions.BackColor = System.Drawing.Color.Transparent;
            this.grpOptions.Controls.Add(this.cboErrDealHandle);
            this.grpOptions.Controls.Add(this.rtb_ErrMessage);
            this.grpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOptions.FillColor = System.Drawing.Color.Transparent;
            this.grpOptions.FillColor2 = System.Drawing.Color.Transparent;
            this.grpOptions.FillDisableColor = System.Drawing.Color.Transparent;
            this.grpOptions.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpOptions.ForeColor = System.Drawing.Color.Black;
            this.grpOptions.Location = new System.Drawing.Point(0, 0);
            this.grpOptions.Margin = new System.Windows.Forms.Padding(10);
            this.grpOptions.MinimumSize = new System.Drawing.Size(1, 1);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Padding = new System.Windows.Forms.Padding(5, 26, 5, 3);
            this.grpOptions.RectColor = System.Drawing.Color.White;
            this.grpOptions.Size = new System.Drawing.Size(494, 354);
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
            this.cboErrDealHandle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboErrDealHandle.FillColor = System.Drawing.Color.White;
            this.cboErrDealHandle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboErrDealHandle.Location = new System.Drawing.Point(5, 26);
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
            this.rtb_ErrMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb_ErrMessage.FillColor = System.Drawing.Color.White;
            this.rtb_ErrMessage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_ErrMessage.Location = new System.Drawing.Point(5, 67);
            this.rtb_ErrMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtb_ErrMessage.MinimumSize = new System.Drawing.Size(1, 1);
            this.rtb_ErrMessage.Name = "rtb_ErrMessage";
            this.rtb_ErrMessage.Padding = new System.Windows.Forms.Padding(2);
            this.rtb_ErrMessage.ShowText = false;
            this.rtb_ErrMessage.Size = new System.Drawing.Size(484, 284);
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
            // timer1
            //
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AudioEarlyWarningFrmDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(202)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.ControlBox = false;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Movable = false;
            this.Name = "AudioEarlyWarningFrmDialog";
            this.RectColor = System.Drawing.Color.Transparent;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "Dialog";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.TitleColor = System.Drawing.Color.Gainsboro;
            this.TitleFont = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleForeColor = System.Drawing.Color.Black;
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
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIGroupBox grpOptions;
        private ProxyTools.SunnyUI.Controls.UIRichTextBox rtb_ErrMessage;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnConfirm;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnMute;
        private ProxyTools.SunnyUI.Controls.UILabel labDetail;
        private ProxyTools.SunnyUI.Controls.UIRichTextBox rtbDetailValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ProxyTools.SunnyUI.Controls.UITextBox lblStartTimeValue;
        private System.Windows.Forms.Timer timer1;
        private ProxyTools.SunnyUI.Controls.UIComboBox cboErrDealHandle;
    }
}