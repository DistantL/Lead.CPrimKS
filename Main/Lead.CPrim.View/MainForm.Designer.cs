using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiViewVersionExplanation = new System.Windows.Forms.ToolStripMenuItem();
            this.panelAuthority = new System.Windows.Forms.Panel();
            this.ttConfig = new System.Windows.Forms.ToolTip(this.components);
            this.tmrAuthority = new System.Windows.Forms.Timer(this.components);
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.stuStatus = new System.Windows.Forms.StatusStrip();
            this.tssl_LogTask = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_DisplayNGInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Warning = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtn = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAuthority = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTesuFuc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tslblMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblMemory = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblCpuRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl_Light = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblAutoManual = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrAlarm = new System.Windows.Forms.Timer(this.components);
            this.tmrSoftWare = new System.Windows.Forms.Timer(this.components);
            this.tmrUIRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.uiLine3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.BtnHome = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.BtnAlert = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.BtnConfig = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.BtnData = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.BtnVision = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.BtnSetting = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.btnRun = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.btnPaused = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.btnStop = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIImageButton();
            this.uiLine1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.uiLine2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.tlpState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lblAlarmTag = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnClear = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblLogTag = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblAlarm = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblLog = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.tlpButton.SuspendLayout();
            this.cms.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.stuStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnVision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaused)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).BeginInit();
            this.tlpState.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpButton
            // 
            this.tlpButton.BackColor = System.Drawing.Color.Transparent;
            this.tlpButton.ColumnCount = 24;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpButton.Controls.Add(this.pnlTitle, 14, 0);
            this.tlpButton.Controls.Add(this.uiLine3, 13, 0);
            this.tlpButton.Controls.Add(this.panelAuthority, 23, 0);
            this.tlpButton.Controls.Add(this.BtnHome, 1, 0);
            this.tlpButton.Controls.Add(this.BtnAlert, 3, 0);
            this.tlpButton.Controls.Add(this.BtnConfig, 5, 0);
            this.tlpButton.Controls.Add(this.BtnData, 7, 0);
            this.tlpButton.Controls.Add(this.BtnVision, 9, 0);
            this.tlpButton.Controls.Add(this.BtnSetting, 11, 0);
            this.tlpButton.Controls.Add(this.btnRun, 16, 0);
            this.tlpButton.Controls.Add(this.btnPaused, 18, 0);
            this.tlpButton.Controls.Add(this.btnStop, 20, 0);
            this.tlpButton.Controls.Add(this.uiLine1, 21, 0);
            this.tlpButton.Controls.Add(this.uiLine2, 15, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(0, 0);
            this.tlpButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(1184, 76);
            this.tlpButton.TabIndex = 5;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewVersionExplanation});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(221, 26);
            // 
            // tsmiViewVersionExplanation
            // 
            this.tsmiViewVersionExplanation.Name = "tsmiViewVersionExplanation";
            this.tsmiViewVersionExplanation.Size = new System.Drawing.Size(220, 22);
            this.tsmiViewVersionExplanation.Text = "View version explanation";
            this.tsmiViewVersionExplanation.Click += new System.EventHandler(this.tsmlViewVersionExplanation_Click);
            // 
            // panelAuthority
            // 
            this.panelAuthority.BackColor = System.Drawing.Color.Transparent;
            this.panelAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuthority.Location = new System.Drawing.Point(974, 0);
            this.panelAuthority.Margin = new System.Windows.Forms.Padding(0);
            this.panelAuthority.Name = "panelAuthority";
            this.panelAuthority.Size = new System.Drawing.Size(210, 76);
            this.panelAuthority.TabIndex = 21;
            // 
            // tmrAuthority
            // 
            this.tmrAuthority.Enabled = true;
            this.tmrAuthority.Interval = 1000;
            this.tmrAuthority.Tick += new System.EventHandler(this.tmrAuthority_Tick);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpButton, 0, 0);
            this.tlpMain.Controls.Add(this.tlpState, 0, 2);
            this.tlpMain.Controls.Add(this.pnlMain, 0, 1);
            this.tlpMain.Controls.Add(this.stuStatus, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1184, 561);
            this.tlpMain.TabIndex = 23;
            // 
            // stuStatus
            // 
            this.stuStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stuStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stuStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stuStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_LogTask,
            this.tssl_DisplayNGInfo,
            this.tssl_Warning,
            this.tsbtn,
            this.tslblMode,
            this.tslblMemory,
            this.tslblCpuRate,
            this.tslblTimer,
            this.tslbl_Light,
            this.tslblAutoManual});
            this.stuStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.stuStatus.Location = new System.Drawing.Point(0, 535);
            this.stuStatus.Name = "stuStatus";
            this.stuStatus.Size = new System.Drawing.Size(1184, 26);
            this.stuStatus.TabIndex = 23;
            this.stuStatus.Text = "statusStrip1";
            // 
            // tssl_LogTask
            // 
            this.tssl_LogTask.Margin = new System.Windows.Forms.Padding(10, 4, 0, 2);
            this.tssl_LogTask.Name = "tssl_LogTask";
            this.tssl_LogTask.Size = new System.Drawing.Size(56, 20);
            this.tssl_LogTask.Text = "任务日志";
            this.tssl_LogTask.Click += new System.EventHandler(this.tssl_LogTask_Click);
            // 
            // tssl_DisplayNGInfo
            // 
            this.tssl_DisplayNGInfo.Margin = new System.Windows.Forms.Padding(10, 4, 0, 2);
            this.tssl_DisplayNGInfo.Name = "tssl_DisplayNGInfo";
            this.tssl_DisplayNGInfo.Size = new System.Drawing.Size(56, 20);
            this.tssl_DisplayNGInfo.Text = "抛料信息";
            this.tssl_DisplayNGInfo.Click += new System.EventHandler(this.tssl_DisplayNGInfo_Click);
            // 
            // tssl_Warning
            // 
            this.tssl_Warning.Margin = new System.Windows.Forms.Padding(10, 4, 0, 2);
            this.tssl_Warning.Name = "tssl_Warning";
            this.tssl_Warning.Size = new System.Drawing.Size(32, 20);
            this.tssl_Warning.Text = "警告";
            this.tssl_Warning.Click += new System.EventHandler(this.tssl_Warning_Click);
            // 
            // tsbtn
            // 
            this.tsbtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTest,
            this.tsmiAuthority,
            this.tsmiTesuFuc,
            this.tsmiLesson,
            this.tsmiAbout});
            this.tsbtn.Image = global::Lead.CPrim.View.Properties.Resources.up;
            this.tsbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn.Name = "tsbtn";
            this.tsbtn.Size = new System.Drawing.Size(36, 24);
            this.tsbtn.Text = "toolStripSplitButton1";
            // 
            // tsmiTest
            // 
            this.tsmiTest.Name = "tsmiTest";
            this.tsmiTest.Size = new System.Drawing.Size(180, 22);
            this.tsmiTest.Text = "软件测试";
            this.tsmiTest.Click += new System.EventHandler(this.tsmiTest_Click);
            // 
            // tsmiAuthority
            // 
            this.tsmiAuthority.Name = "tsmiAuthority";
            this.tsmiAuthority.Size = new System.Drawing.Size(180, 22);
            this.tsmiAuthority.Text = "超级权限";
            this.tsmiAuthority.Click += new System.EventHandler(this.tsmiAuthority_Click);
            // 
            // tsmiTesuFuc
            // 
            this.tsmiTesuFuc.Name = "tsmiTesuFuc";
            this.tsmiTesuFuc.Size = new System.Drawing.Size(180, 22);
            this.tsmiTesuFuc.Text = "单一功能测试";
            this.tsmiTesuFuc.Click += new System.EventHandler(this.tsmiTesuFuc_Click);
            // 
            // tsmiLesson
            // 
            this.tsmiLesson.Name = "tsmiLesson";
            this.tsmiLesson.Size = new System.Drawing.Size(180, 22);
            this.tsmiLesson.Text = "教程";
            this.tsmiLesson.Click += new System.EventHandler(this.tsmiLesson_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(180, 22);
            this.tsmiAbout.Text = "关于";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // tslblMode
            // 
            this.tslblMode.AutoSize = false;
            this.tslblMode.Image = global::Lead.CPrim.View.Properties.Resources.mode;
            this.tslblMode.Name = "tslblMode";
            this.tslblMode.Size = new System.Drawing.Size(130, 20);
            this.tslblMode.Click += new System.EventHandler(this.tslblMode_Click);
            // 
            // tslblMemory
            // 
            this.tslblMemory.AutoSize = false;
            this.tslblMemory.Image = global::Lead.CPrim.View.Properties.Resources.memory;
            this.tslblMemory.Name = "tslblMemory";
            this.tslblMemory.Size = new System.Drawing.Size(100, 20);
            // 
            // tslblCpuRate
            // 
            this.tslblCpuRate.AutoSize = false;
            this.tslblCpuRate.Image = global::Lead.CPrim.View.Properties.Resources.cpu;
            this.tslblCpuRate.Name = "tslblCpuRate";
            this.tslblCpuRate.Size = new System.Drawing.Size(100, 20);
            // 
            // tslblTimer
            // 
            this.tslblTimer.AutoSize = false;
            this.tslblTimer.Image = global::Lead.CPrim.View.Properties.Resources.timer;
            this.tslblTimer.Name = "tslblTimer";
            this.tslblTimer.Size = new System.Drawing.Size(130, 20);
            // 
            // tslbl_Light
            // 
            this.tslbl_Light.AutoSize = false;
            this.tslbl_Light.Name = "tslbl_Light";
            this.tslbl_Light.Size = new System.Drawing.Size(100, 21);
            this.tslbl_Light.Text = "照明";
            this.tslbl_Light.Click += new System.EventHandler(this.tslbl_Light_Click);
            // 
            // tslblAutoManual
            // 
            this.tslblAutoManual.AutoSize = false;
            this.tslblAutoManual.Name = "tslblAutoManual";
            this.tslblAutoManual.Size = new System.Drawing.Size(100, 21);
            this.tslblAutoManual.Text = "自动";
            this.tslblAutoManual.Click += new System.EventHandler(this.tslblAutoManual_Click);
            // 
            // tmrAlarm
            // 
            this.tmrAlarm.Interval = 300;
            this.tmrAlarm.Tick += new System.EventHandler(this.tmrAlarm_Tick);
            // 
            // tmrSoftWare
            // 
            this.tmrSoftWare.Interval = 1000;
            this.tmrSoftWare.Tick += new System.EventHandler(this.tmrSoftWare_Tick);
            // 
            // tmrUIRefresh
            // 
            this.tmrUIRefresh.Tick += new System.EventHandler(this.tmrUIRefresh_Tick);
            // 
            // pnlTitle
            // 
            this.pnlTitle.ContextMenuStrip = this.cms;
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitle.FillColor = System.Drawing.Color.Transparent;
            this.pnlTitle.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.ForeColor = System.Drawing.Color.White;
            this.pnlTitle.Location = new System.Drawing.Point(501, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Radius = 1;
            this.pnlTitle.RectColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Size = new System.Drawing.Size(202, 70);
            this.pnlTitle.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlTitle.StyleCustomMode = true;
            this.pnlTitle.TabIndex = 0;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine3
            // 
            this.uiLine3.Direction = Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine.LineDirection.Vertical;
            this.uiLine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.uiLine3.Location = new System.Drawing.Point(493, 3);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(4, 70);
            this.uiLine3.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLine3.TabIndex = 26;
            this.uiLine3.Text = "uiLine3";
            this.uiLine3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.Transparent;
            this.BtnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnHome.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnHome.Image = ((System.Drawing.Image)(resources.GetObject("BtnHome.Image")));
            this.BtnHome.ImageDisabled = ((System.Drawing.Image)(resources.GetObject("BtnHome.ImageDisabled")));
            this.BtnHome.ImageSelected = ((System.Drawing.Image)(resources.GetObject("BtnHome.ImageSelected")));
            this.BtnHome.Location = new System.Drawing.Point(12, 5);
            this.BtnHome.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(66, 66);
            this.BtnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnHome.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.BtnHome.TabIndex = 22;
            this.BtnHome.TabStop = false;
            this.BtnHome.Text = null;
            this.ttConfig.SetToolTip(this.BtnHome, "Home");
            this.BtnHome.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.BtnHome.Click += new System.EventHandler(this.BtnBar_Click);
            // 
            // BtnAlert
            // 
            this.BtnAlert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAlert.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAlert.Image = ((System.Drawing.Image)(resources.GetObject("BtnAlert.Image")));
            this.BtnAlert.ImageDisabled = ((System.Drawing.Image)(resources.GetObject("BtnAlert.ImageDisabled")));
            this.BtnAlert.ImageSelected = ((System.Drawing.Image)(resources.GetObject("BtnAlert.ImageSelected")));
            this.BtnAlert.Location = new System.Drawing.Point(92, 5);
            this.BtnAlert.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.BtnAlert.Name = "BtnAlert";
            this.BtnAlert.Size = new System.Drawing.Size(66, 66);
            this.BtnAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnAlert.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.BtnAlert.TabIndex = 22;
            this.BtnAlert.TabStop = false;
            this.BtnAlert.Text = null;
            this.ttConfig.SetToolTip(this.BtnAlert, "Alert");
            this.BtnAlert.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.BtnAlert.Click += new System.EventHandler(this.BtnBar_Click);
            // 
            // BtnConfig
            // 
            this.BtnConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConfig.Image = ((System.Drawing.Image)(resources.GetObject("BtnConfig.Image")));
            this.BtnConfig.ImageDisabled = ((System.Drawing.Image)(resources.GetObject("BtnConfig.ImageDisabled")));
            this.BtnConfig.ImageSelected = ((System.Drawing.Image)(resources.GetObject("BtnConfig.ImageSelected")));
            this.BtnConfig.Location = new System.Drawing.Point(172, 5);
            this.BtnConfig.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.BtnConfig.Name = "BtnConfig";
            this.BtnConfig.Size = new System.Drawing.Size(66, 66);
            this.BtnConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnConfig.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.BtnConfig.TabIndex = 22;
            this.BtnConfig.TabStop = false;
            this.BtnConfig.Text = null;
            this.ttConfig.SetToolTip(this.BtnConfig, "Config");
            this.BtnConfig.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.BtnConfig.Click += new System.EventHandler(this.BtnBar_Click);
            // 
            // BtnData
            // 
            this.BtnData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnData.Image = ((System.Drawing.Image)(resources.GetObject("BtnData.Image")));
            this.BtnData.ImageDisabled = ((System.Drawing.Image)(resources.GetObject("BtnData.ImageDisabled")));
            this.BtnData.ImageSelected = ((System.Drawing.Image)(resources.GetObject("BtnData.ImageSelected")));
            this.BtnData.Location = new System.Drawing.Point(252, 5);
            this.BtnData.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.BtnData.Name = "BtnData";
            this.BtnData.Size = new System.Drawing.Size(66, 66);
            this.BtnData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnData.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.BtnData.TabIndex = 22;
            this.BtnData.TabStop = false;
            this.BtnData.Text = null;
            this.ttConfig.SetToolTip(this.BtnData, "Data");
            this.BtnData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.BtnData.Click += new System.EventHandler(this.BtnBar_Click);
            // 
            // BtnVision
            // 
            this.BtnVision.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnVision.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnVision.Image = ((System.Drawing.Image)(resources.GetObject("BtnVision.Image")));
            this.BtnVision.ImageDisabled = ((System.Drawing.Image)(resources.GetObject("BtnVision.ImageDisabled")));
            this.BtnVision.ImageSelected = ((System.Drawing.Image)(resources.GetObject("BtnVision.ImageSelected")));
            this.BtnVision.Location = new System.Drawing.Point(332, 5);
            this.BtnVision.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.BtnVision.Name = "BtnVision";
            this.BtnVision.Size = new System.Drawing.Size(66, 66);
            this.BtnVision.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnVision.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.BtnVision.TabIndex = 22;
            this.BtnVision.TabStop = false;
            this.BtnVision.Text = null;
            this.ttConfig.SetToolTip(this.BtnVision, "Vision");
            this.BtnVision.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.BtnVision.Click += new System.EventHandler(this.BtnBar_Click);
            // 
            // BtnSetting
            // 
            this.BtnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetting.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSetting.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetting.Image")));
            this.BtnSetting.ImageDisabled = ((System.Drawing.Image)(resources.GetObject("BtnSetting.ImageDisabled")));
            this.BtnSetting.ImageSelected = ((System.Drawing.Image)(resources.GetObject("BtnSetting.ImageSelected")));
            this.BtnSetting.Location = new System.Drawing.Point(412, 5);
            this.BtnSetting.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(66, 66);
            this.BtnSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnSetting.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.BtnSetting.TabIndex = 22;
            this.BtnSetting.TabStop = false;
            this.BtnSetting.Text = null;
            this.ttConfig.SetToolTip(this.BtnSetting, "Setting");
            this.BtnSetting.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.BtnSetting.Click += new System.EventHandler(this.BtnBar_Click);
            // 
            // btnRun
            // 
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.Location = new System.Drawing.Point(716, 5);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(66, 66);
            this.btnRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRun.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnRun.TabIndex = 23;
            this.btnRun.TabStop = false;
            this.btnRun.Text = null;
            this.btnRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnPaused
            // 
            this.btnPaused.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaused.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPaused.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPaused.Image = ((System.Drawing.Image)(resources.GetObject("btnPaused.Image")));
            this.btnPaused.Location = new System.Drawing.Point(791, 5);
            this.btnPaused.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnPaused.Name = "btnPaused";
            this.btnPaused.Size = new System.Drawing.Size(66, 66);
            this.btnPaused.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPaused.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnPaused.TabIndex = 23;
            this.btnPaused.TabStop = false;
            this.btnPaused.Text = null;
            this.btnPaused.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnPaused.Click += new System.EventHandler(this.btnPaused_Click);
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(866, 5);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(66, 66);
            this.btnStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnStop.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnStop.TabIndex = 23;
            this.btnStop.TabStop = false;
            this.btnStop.Text = null;
            this.btnStop.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // uiLine1
            // 
            this.uiLine1.Direction = Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine.LineDirection.Vertical;
            this.uiLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.uiLine1.Location = new System.Drawing.Point(937, 3);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(4, 70);
            this.uiLine1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLine1.TabIndex = 24;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine2
            // 
            this.uiLine2.Direction = Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine.LineDirection.Vertical;
            this.uiLine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.uiLine2.Location = new System.Drawing.Point(707, 3);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(4, 70);
            this.uiLine2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLine2.TabIndex = 25;
            this.uiLine2.Text = "uiLine2";
            this.uiLine2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpState
            // 
            this.tlpState.ColumnCount = 6;
            this.tlpState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpState.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpState.Controls.Add(this.lblAlarmTag, 0, 0);
            this.tlpState.Controls.Add(this.btnClear, 2, 0);
            this.tlpState.Controls.Add(this.lblLogTag, 4, 0);
            this.tlpState.Controls.Add(this.lblAlarm, 1, 0);
            this.tlpState.Controls.Add(this.lblLog, 5, 0);
            this.tlpState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpState.Location = new System.Drawing.Point(0, 509);
            this.tlpState.Margin = new System.Windows.Forms.Padding(0);
            this.tlpState.Name = "tlpState";
            this.tlpState.RowCount = 1;
            this.tlpState.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpState.Size = new System.Drawing.Size(1184, 26);
            this.tlpState.TabIndex = 21;
            this.tlpState.TagString = null;
            // 
            // lblAlarmTag
            // 
            this.lblAlarmTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmTag.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAlarmTag.Image = global::Lead.CPrim.View.Properties.Resources.alarm;
            this.lblAlarmTag.Location = new System.Drawing.Point(1, 1);
            this.lblAlarmTag.Margin = new System.Windows.Forms.Padding(1);
            this.lblAlarmTag.Name = "lblAlarmTag";
            this.lblAlarmTag.Size = new System.Drawing.Size(26, 24);
            this.lblAlarmTag.TabIndex = 0;
            this.lblAlarmTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlarmTag.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Image = global::Lead.CPrim.View.Properties.Resources.clearAlarm;
            this.btnClear.Location = new System.Drawing.Point(576, 1);
            this.btnClear.Margin = new System.Windows.Forms.Padding(1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(26, 24);
            this.btnClear.TabIndex = 1;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // lblLogTag
            // 
            this.lblLogTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogTag.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLogTag.Image = global::Lead.CPrim.View.Properties.Resources.info;
            this.lblLogTag.Location = new System.Drawing.Point(609, 1);
            this.lblLogTag.Margin = new System.Windows.Forms.Padding(1);
            this.lblLogTag.Name = "lblLogTag";
            this.lblLogTag.Size = new System.Drawing.Size(26, 24);
            this.lblLogTag.TabIndex = 2;
            this.lblLogTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogTag.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblAlarm
            // 
            this.lblAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAlarm.Location = new System.Drawing.Point(29, 1);
            this.lblAlarm.Margin = new System.Windows.Forms.Padding(1);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(545, 24);
            this.lblAlarm.TabIndex = 3;
            this.lblAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlarm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblLog
            // 
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLog.Location = new System.Drawing.Point(637, 1);
            this.lblLog.Margin = new System.Windows.Forms.Padding(1);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(546, 24);
            this.lblLog.TabIndex = 3;
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLog.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FillColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Location = new System.Drawing.Point(4, 81);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RectColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMain.Size = new System.Drawing.Size(1176, 423);
            this.pnlMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlMain.StyleCustomMode = true;
            this.pnlMain.TabIndex = 22;
            this.pnlMain.Text = null;
            this.pnlMain.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.tlpMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C Prim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tlpButton.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.stuStatus.ResumeLayout(false);
            this.stuStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnVision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaused)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).EndInit();
            this.tlpState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttConfig;
        private System.Windows.Forms.Timer tmrAuthority;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Timer tmrAlarm;
        private System.Windows.Forms.Timer tmrSoftWare;
        private UITableLayoutPanel tlpState;
        private UILabel lblAlarmTag;
        private UILabel btnClear;
        private UILabel lblLogTag;
        private UILabel lblAlarm;
        private UILabel lblLog;
        private System.Windows.Forms.TableLayoutPanel tlpButton;
        private System.Windows.Forms.Panel panelAuthority;
        private UIImageButton BtnHome;
        private UIImageButton BtnAlert;
        private UIImageButton BtnConfig;
        private UIImageButton BtnData;
        private UIImageButton BtnVision;
        private UIImageButton BtnSetting;
        private UIImageButton btnRun;
        private UIImageButton btnPaused;
        private UIImageButton btnStop;
        private UILine uiLine1;
        private UILine uiLine2;
        private UIPanel pnlMain;
        private System.Windows.Forms.Timer tmrUIRefresh;
        private System.Windows.Forms.StatusStrip stuStatus;
        private System.Windows.Forms.ToolStripStatusLabel tslblTimer;
        private System.Windows.Forms.ToolStripStatusLabel tslblCpuRate;
        private System.Windows.Forms.ToolStripStatusLabel tslblMemory;
        private System.Windows.Forms.ToolStripStatusLabel tslblMode;
        private System.Windows.Forms.ToolStripStatusLabel tslblAutoManual;
        private System.Windows.Forms.ToolStripSplitButton tsbtn;
        private System.Windows.Forms.ToolStripMenuItem tsmiTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiLesson;
        private System.Windows.Forms.ToolStripMenuItem tsmiAuthority;
        private System.Windows.Forms.ToolStripMenuItem tsmiTesuFuc;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_Light;
        private UILine uiLine3;
        private UIPanel pnlTitle;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Warning;
        private System.Windows.Forms.ToolStripStatusLabel tssl_LogTask;
        private System.Windows.Forms.ToolStripStatusLabel tssl_DisplayNGInfo;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewVersionExplanation;
    }
}