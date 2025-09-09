using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.PrimFinsNet
{
    partial class PrimConfigControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtConnState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtRunState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblError = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.pnl3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblWriteStartAddress = new System.Windows.Forms.Label();
            this.lblReadStartAddress = new System.Windows.Forms.Label();
            this.txtReadLength = new System.Windows.Forms.TextBox();
            this.txtWriteStartAddress = new System.Windows.Forms.TextBox();
            this.lblReadLength = new System.Windows.Forms.Label();
            this.lblWriteLength = new System.Windows.Forms.Label();
            this.txtWriteLength = new System.Windows.Forms.TextBox();
            this.txtReadStartAddress = new System.Windows.Forms.TextBox();
            this.pnl2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblCycleTimeShow = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblFinsType = new System.Windows.Forms.Label();
            this.lblCycleTime = new System.Windows.Forms.Label();
            this.tBoxReConnCnt = new System.Windows.Forms.TextBox();
            this.tBoxCycleTime = new System.Windows.Forms.TextBox();
            this.lblReConnectCnt = new System.Windows.Forms.Label();
            this.cBoxNotifyMode = new System.Windows.Forms.ComboBox();
            this.cbFinsType = new System.Windows.Forms.ComboBox();
            this.lblNotifyMode = new System.Windows.Forms.Label();
            this.pnl1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblIP = new System.Windows.Forms.Label();
            this.cbLogEnable = new System.Windows.Forms.CheckBox();
            this.lblSA1 = new System.Windows.Forms.Label();
            this.tBoxPort = new System.Windows.Forms.TextBox();
            this.tBoxSA1 = new System.Windows.Forms.TextBox();
            this.tBoxDA1 = new System.Windows.Forms.TextBox();
            this.tBoxIP = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblDA2 = new System.Windows.Forms.Label();
            this.lblDA1 = new System.Windows.Forms.Label();
            this.tBoxDA2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splData = new System.Windows.Forms.SplitContainer();
            this.dgvDataConfig = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPermission = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colModifyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReadMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEventNotify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colWriteValue = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportDll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tBoxTableDataPath = new System.Windows.Forms.TextBox();
            this.btnTableBrowse = new System.Windows.Forms.Button();
            this.cBoxMonitor = new System.Windows.Forms.CheckBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splData)).BeginInit();
            this.splData.Panel1.SuspendLayout();
            this.splData.Panel2.SuspendLayout();
            this.splData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataConfig)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 44);
            this.panel1.TabIndex = 25;
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 5;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTitle.Controls.Add(this.label1, 0, 0);
            this.tlpTitle.Controls.Add(this.txtName, 1, 0);
            this.tlpTitle.Controls.Add(this.txtConnState, 3, 0);
            this.tlpTitle.Controls.Add(this.txtRunState, 4, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(800, 44);
            this.tlpTitle.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpTitle.TabIndex = 0;
            this.tlpTitle.TagString = null;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 42);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fins Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(152, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(146, 40);
            this.txtName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txtName.TabIndex = 13;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtConnState
            // 
            this.txtConnState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConnState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConnState.Location = new System.Drawing.Point(502, 2);
            this.txtConnState.Margin = new System.Windows.Forms.Padding(2);
            this.txtConnState.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtConnState.Name = "txtConnState";
            this.txtConnState.ShowText = false;
            this.txtConnState.Size = new System.Drawing.Size(146, 40);
            this.txtConnState.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txtConnState.TabIndex = 13;
            this.txtConnState.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtConnState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRunState
            // 
            this.txtRunState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRunState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRunState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRunState.Location = new System.Drawing.Point(652, 2);
            this.txtRunState.Margin = new System.Windows.Forms.Padding(2);
            this.txtRunState.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtRunState.Name = "txtRunState";
            this.txtRunState.ShowText = false;
            this.txtRunState.Size = new System.Drawing.Size(146, 40);
            this.txtRunState.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txtRunState.TabIndex = 13;
            this.txtRunState.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtRunState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tabMain.Location = new System.Drawing.Point(0, 44);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(800, 456);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.lblError);
            this.tabPage1.Controls.Add(this.lblVersion);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Controls.Add(this.pnl3);
            this.tabPage1.Controls.Add(this.pnl2);
            this.tabPage1.Controls.Add(this.pnl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config";
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblError.Location = new System.Drawing.Point(10, 325);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(765, 23);
            this.lblError.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblError.TabIndex = 154;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblVersion.Location = new System.Drawing.Point(670, 395);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(31, 20);
            this.lblVersion.TabIndex = 153;
            this.lblVersion.Text = "Ver";
            this.lblVersion.DoubleClick += new System.EventHandler(this.lblVersion_DoubleClick);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnApply);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.groupBox.Location = new System.Drawing.Point(10, 345);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(500, 70);
            this.groupBox.TabIndex = 152;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "EXE";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnStop.Location = new System.Drawing.Point(260, 23);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 40);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.SkyBlue;
            this.btnInit.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnInit.Location = new System.Drawing.Point(20, 23);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(100, 40);
            this.btnInit.TabIndex = 105;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRun.Location = new System.Drawing.Point(140, 23);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 40);
            this.btnRun.TabIndex = 105;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnApply.Location = new System.Drawing.Point(380, 23);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 40);
            this.btnApply.TabIndex = 127;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pnl3
            // 
            this.pnl3.Controls.Add(this.lblWriteStartAddress);
            this.pnl3.Controls.Add(this.lblReadStartAddress);
            this.pnl3.Controls.Add(this.txtReadLength);
            this.pnl3.Controls.Add(this.txtWriteStartAddress);
            this.pnl3.Controls.Add(this.lblReadLength);
            this.pnl3.Controls.Add(this.lblWriteLength);
            this.pnl3.Controls.Add(this.txtWriteLength);
            this.pnl3.Controls.Add(this.txtReadStartAddress);
            this.pnl3.FillColor = System.Drawing.Color.Silver;
            this.pnl3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl3.Location = new System.Drawing.Point(414, 193);
            this.pnl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl3.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(361, 125);
            this.pnl3.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnl3.TabIndex = 150;
            this.pnl3.Text = null;
            this.pnl3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblWriteStartAddress
            // 
            this.lblWriteStartAddress.AutoSize = true;
            this.lblWriteStartAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblWriteStartAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblWriteStartAddress.Location = new System.Drawing.Point(13, 68);
            this.lblWriteStartAddress.Name = "lblWriteStartAddress";
            this.lblWriteStartAddress.Size = new System.Drawing.Size(129, 20);
            this.lblWriteStartAddress.TabIndex = 125;
            this.lblWriteStartAddress.Text = "WriteStartAddress";
            // 
            // lblReadStartAddress
            // 
            this.lblReadStartAddress.AutoSize = true;
            this.lblReadStartAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblReadStartAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblReadStartAddress.Location = new System.Drawing.Point(13, 9);
            this.lblReadStartAddress.Name = "lblReadStartAddress";
            this.lblReadStartAddress.Size = new System.Drawing.Size(127, 20);
            this.lblReadStartAddress.TabIndex = 125;
            this.lblReadStartAddress.Text = "ReadStartAddress";
            // 
            // txtReadLength
            // 
            this.txtReadLength.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtReadLength.Location = new System.Drawing.Point(196, 33);
            this.txtReadLength.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReadLength.Name = "txtReadLength";
            this.txtReadLength.Size = new System.Drawing.Size(140, 25);
            this.txtReadLength.TabIndex = 120;
            // 
            // txtWriteStartAddress
            // 
            this.txtWriteStartAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWriteStartAddress.Location = new System.Drawing.Point(13, 92);
            this.txtWriteStartAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWriteStartAddress.Name = "txtWriteStartAddress";
            this.txtWriteStartAddress.Size = new System.Drawing.Size(140, 25);
            this.txtWriteStartAddress.TabIndex = 121;
            // 
            // lblReadLength
            // 
            this.lblReadLength.AutoSize = true;
            this.lblReadLength.BackColor = System.Drawing.Color.Transparent;
            this.lblReadLength.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblReadLength.Location = new System.Drawing.Point(196, 9);
            this.lblReadLength.Name = "lblReadLength";
            this.lblReadLength.Size = new System.Drawing.Size(90, 20);
            this.lblReadLength.TabIndex = 122;
            this.lblReadLength.Text = "ReadLength";
            // 
            // lblWriteLength
            // 
            this.lblWriteLength.AutoSize = true;
            this.lblWriteLength.BackColor = System.Drawing.Color.Transparent;
            this.lblWriteLength.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblWriteLength.Location = new System.Drawing.Point(196, 68);
            this.lblWriteLength.Name = "lblWriteLength";
            this.lblWriteLength.Size = new System.Drawing.Size(92, 20);
            this.lblWriteLength.TabIndex = 122;
            this.lblWriteLength.Text = "WriteLength";
            // 
            // txtWriteLength
            // 
            this.txtWriteLength.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWriteLength.Location = new System.Drawing.Point(196, 92);
            this.txtWriteLength.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWriteLength.Name = "txtWriteLength";
            this.txtWriteLength.Size = new System.Drawing.Size(140, 25);
            this.txtWriteLength.TabIndex = 120;
            // 
            // txtReadStartAddress
            // 
            this.txtReadStartAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtReadStartAddress.Location = new System.Drawing.Point(13, 33);
            this.txtReadStartAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReadStartAddress.Name = "txtReadStartAddress";
            this.txtReadStartAddress.Size = new System.Drawing.Size(140, 25);
            this.txtReadStartAddress.TabIndex = 121;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.lblCycleTimeShow);
            this.pnl2.Controls.Add(this.lblFinsType);
            this.pnl2.Controls.Add(this.lblCycleTime);
            this.pnl2.Controls.Add(this.tBoxReConnCnt);
            this.pnl2.Controls.Add(this.tBoxCycleTime);
            this.pnl2.Controls.Add(this.lblReConnectCnt);
            this.pnl2.Controls.Add(this.cBoxNotifyMode);
            this.pnl2.Controls.Add(this.cbFinsType);
            this.pnl2.Controls.Add(this.lblNotifyMode);
            this.pnl2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnl2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl2.Location = new System.Drawing.Point(414, 9);
            this.pnl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl2.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(361, 162);
            this.pnl2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnl2.TabIndex = 146;
            this.pnl2.Text = null;
            this.pnl2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblCycleTimeShow
            // 
            this.lblCycleTimeShow.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblCycleTimeShow.Location = new System.Drawing.Point(303, 47);
            this.lblCycleTimeShow.Name = "lblCycleTimeShow";
            this.lblCycleTimeShow.Size = new System.Drawing.Size(55, 23);
            this.lblCycleTimeShow.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblCycleTimeShow.TabIndex = 143;
            this.lblCycleTimeShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCycleTimeShow.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.lblCycleTimeShow.DoubleClick += new System.EventHandler(this.lblCycleTimeShow_DoubleClick);
            // 
            // lblFinsType
            // 
            this.lblFinsType.AutoSize = true;
            this.lblFinsType.BackColor = System.Drawing.Color.Transparent;
            this.lblFinsType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblFinsType.Location = new System.Drawing.Point(13, 20);
            this.lblFinsType.Name = "lblFinsType";
            this.lblFinsType.Size = new System.Drawing.Size(67, 20);
            this.lblFinsType.TabIndex = 122;
            this.lblFinsType.Text = "FinsType";
            // 
            // lblCycleTime
            // 
            this.lblCycleTime.AutoSize = true;
            this.lblCycleTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCycleTime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblCycleTime.Location = new System.Drawing.Point(196, 20);
            this.lblCycleTime.Name = "lblCycleTime";
            this.lblCycleTime.Size = new System.Drawing.Size(136, 20);
            this.lblCycleTime.TabIndex = 140;
            this.lblCycleTime.Text = "CycleTime(5-10ms)";
            this.lblCycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBoxReConnCnt
            // 
            this.tBoxReConnCnt.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tBoxReConnCnt.Location = new System.Drawing.Point(13, 113);
            this.tBoxReConnCnt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxReConnCnt.Name = "tBoxReConnCnt";
            this.tBoxReConnCnt.Size = new System.Drawing.Size(140, 25);
            this.tBoxReConnCnt.TabIndex = 121;
            // 
            // tBoxCycleTime
            // 
            this.tBoxCycleTime.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tBoxCycleTime.Location = new System.Drawing.Point(196, 46);
            this.tBoxCycleTime.Name = "tBoxCycleTime";
            this.tBoxCycleTime.Size = new System.Drawing.Size(100, 25);
            this.tBoxCycleTime.TabIndex = 141;
            // 
            // lblReConnectCnt
            // 
            this.lblReConnectCnt.AutoSize = true;
            this.lblReConnectCnt.BackColor = System.Drawing.Color.Transparent;
            this.lblReConnectCnt.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblReConnectCnt.Location = new System.Drawing.Point(13, 87);
            this.lblReConnectCnt.Name = "lblReConnectCnt";
            this.lblReConnectCnt.Size = new System.Drawing.Size(105, 20);
            this.lblReConnectCnt.TabIndex = 125;
            this.lblReConnectCnt.Text = "ReConnectCnt";
            // 
            // cBoxNotifyMode
            // 
            this.cBoxNotifyMode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cBoxNotifyMode.FormattingEnabled = true;
            this.cBoxNotifyMode.Items.AddRange(new object[] {
            "Event",
            "Queue"});
            this.cBoxNotifyMode.Location = new System.Drawing.Point(196, 112);
            this.cBoxNotifyMode.Name = "cBoxNotifyMode";
            this.cBoxNotifyMode.Size = new System.Drawing.Size(140, 27);
            this.cBoxNotifyMode.TabIndex = 129;
            // 
            // cbFinsType
            // 
            this.cbFinsType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cbFinsType.FormattingEnabled = true;
            this.cbFinsType.Items.AddRange(new object[] {
            "FinsUdp",
            "FinsNet"});
            this.cbFinsType.Location = new System.Drawing.Point(13, 45);
            this.cbFinsType.Name = "cbFinsType";
            this.cbFinsType.Size = new System.Drawing.Size(140, 27);
            this.cbFinsType.TabIndex = 129;
            // 
            // lblNotifyMode
            // 
            this.lblNotifyMode.AutoSize = true;
            this.lblNotifyMode.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifyMode.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblNotifyMode.Location = new System.Drawing.Point(196, 87);
            this.lblNotifyMode.Name = "lblNotifyMode";
            this.lblNotifyMode.Size = new System.Drawing.Size(90, 20);
            this.lblNotifyMode.TabIndex = 125;
            this.lblNotifyMode.Text = "NotifyMode";
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.lblIP);
            this.pnl1.Controls.Add(this.cbLogEnable);
            this.pnl1.Controls.Add(this.lblSA1);
            this.pnl1.Controls.Add(this.tBoxPort);
            this.pnl1.Controls.Add(this.tBoxSA1);
            this.pnl1.Controls.Add(this.tBoxDA1);
            this.pnl1.Controls.Add(this.tBoxIP);
            this.pnl1.Controls.Add(this.lblPort);
            this.pnl1.Controls.Add(this.lblDA2);
            this.pnl1.Controls.Add(this.lblDA1);
            this.pnl1.Controls.Add(this.tBoxDA2);
            this.pnl1.FillColor = System.Drawing.Color.Gray;
            this.pnl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl1.Location = new System.Drawing.Point(10, 9);
            this.pnl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl1.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(361, 309);
            this.pnl1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnl1.TabIndex = 149;
            this.pnl1.Text = null;
            this.pnl1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblIP.Location = new System.Drawing.Point(15, 20);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(22, 20);
            this.lblIP.TabIndex = 125;
            this.lblIP.Text = "IP";
            // 
            // cbLogEnable
            // 
            this.cbLogEnable.AutoSize = true;
            this.cbLogEnable.BackColor = System.Drawing.Color.Transparent;
            this.cbLogEnable.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cbLogEnable.Location = new System.Drawing.Point(15, 276);
            this.cbLogEnable.Name = "cbLogEnable";
            this.cbLogEnable.Size = new System.Drawing.Size(99, 24);
            this.cbLogEnable.TabIndex = 142;
            this.cbLogEnable.Text = "LogEnable";
            this.cbLogEnable.UseVisualStyleBackColor = false;
            // 
            // lblSA1
            // 
            this.lblSA1.AutoSize = true;
            this.lblSA1.BackColor = System.Drawing.Color.Transparent;
            this.lblSA1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblSA1.Location = new System.Drawing.Point(15, 87);
            this.lblSA1.Name = "lblSA1";
            this.lblSA1.Size = new System.Drawing.Size(35, 20);
            this.lblSA1.TabIndex = 145;
            this.lblSA1.Text = "SA1";
            // 
            // tBoxPort
            // 
            this.tBoxPort.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tBoxPort.Location = new System.Drawing.Point(204, 46);
            this.tBoxPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxPort.Name = "tBoxPort";
            this.tBoxPort.Size = new System.Drawing.Size(140, 25);
            this.tBoxPort.TabIndex = 120;
            // 
            // tBoxSA1
            // 
            this.tBoxSA1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tBoxSA1.Location = new System.Drawing.Point(15, 113);
            this.tBoxSA1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxSA1.Name = "tBoxSA1";
            this.tBoxSA1.Size = new System.Drawing.Size(140, 25);
            this.tBoxSA1.TabIndex = 144;
            // 
            // tBoxDA1
            // 
            this.tBoxDA1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tBoxDA1.Location = new System.Drawing.Point(204, 113);
            this.tBoxDA1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxDA1.Name = "tBoxDA1";
            this.tBoxDA1.Size = new System.Drawing.Size(140, 25);
            this.tBoxDA1.TabIndex = 142;
            // 
            // tBoxIP
            // 
            this.tBoxIP.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tBoxIP.Location = new System.Drawing.Point(15, 46);
            this.tBoxIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxIP.Name = "tBoxIP";
            this.tBoxIP.Size = new System.Drawing.Size(140, 25);
            this.tBoxIP.TabIndex = 121;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblPort.Location = new System.Drawing.Point(204, 20);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 20);
            this.lblPort.TabIndex = 122;
            this.lblPort.Text = "Port";
            // 
            // lblDA2
            // 
            this.lblDA2.AutoSize = true;
            this.lblDA2.BackColor = System.Drawing.Color.Transparent;
            this.lblDA2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblDA2.Location = new System.Drawing.Point(15, 155);
            this.lblDA2.Name = "lblDA2";
            this.lblDA2.Size = new System.Drawing.Size(38, 20);
            this.lblDA2.TabIndex = 131;
            this.lblDA2.Text = "DA2";
            // 
            // lblDA1
            // 
            this.lblDA1.AutoSize = true;
            this.lblDA1.BackColor = System.Drawing.Color.Transparent;
            this.lblDA1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblDA1.Location = new System.Drawing.Point(204, 87);
            this.lblDA1.Name = "lblDA1";
            this.lblDA1.Size = new System.Drawing.Size(38, 20);
            this.lblDA1.TabIndex = 143;
            this.lblDA1.Text = "DA1";
            // 
            // tBoxDA2
            // 
            this.tBoxDA2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tBoxDA2.Location = new System.Drawing.Point(15, 184);
            this.tBoxDA2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxDA2.Name = "tBoxDA2";
            this.tBoxDA2.Size = new System.Drawing.Size(140, 25);
            this.tBoxDA2.TabIndex = 130;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.splData);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data";
            // 
            // splData
            // 
            this.splData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.splData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splData.Location = new System.Drawing.Point(3, 3);
            this.splData.Margin = new System.Windows.Forms.Padding(0);
            this.splData.Name = "splData";
            this.splData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splData.Panel1
            // 
            this.splData.Panel1.Controls.Add(this.dgvDataConfig);
            // 
            // splData.Panel2
            // 
            this.splData.Panel2.Controls.Add(this.tBoxTableDataPath);
            this.splData.Panel2.Controls.Add(this.btnTableBrowse);
            this.splData.Panel2.Controls.Add(this.cBoxMonitor);
            this.splData.Size = new System.Drawing.Size(786, 418);
            this.splData.SplitterDistance = 370;
            this.splData.TabIndex = 0;
            // 
            // dgvDataConfig
            // 
            this.dgvDataConfig.AllowUserToAddRows = false;
            this.dgvDataConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataConfig.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colType,
            this.colLength,
            this.colAddress,
            this.colPermission,
            this.colModifyValue,
            this.colCurrentValue,
            this.colReadMode,
            this.colEventNotify,
            this.colWriteValue});
            this.dgvDataConfig.ContextMenuStrip = this.cms;
            this.dgvDataConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataConfig.Location = new System.Drawing.Point(0, 0);
            this.dgvDataConfig.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDataConfig.Name = "dgvDataConfig";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataConfig.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataConfig.RowHeadersWidth = 55;
            this.dgvDataConfig.RowTemplate.Height = 27;
            this.dgvDataConfig.Size = new System.Drawing.Size(786, 370);
            this.dgvDataConfig.TabIndex = 2;
            this.dgvDataConfig.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataConfig_CellContentClick);
            this.dgvDataConfig.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataConfig_CellEnter);
            this.dgvDataConfig.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataConfig_CellValueChanged);
            this.dgvDataConfig.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDataConfig_CurrentCellDirtyStateChanged);
            this.dgvDataConfig.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDataConfig_DataError);
            this.dgvDataConfig.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDataConfig_RowsAdded);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colName.FillWeight = 771.5736F;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colName.Width = 200;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colType.FillWeight = 25.38071F;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colLength.FillWeight = 25.38071F;
            this.colLength.HeaderText = "Length";
            this.colLength.Name = "colLength";
            this.colLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAddress.FillWeight = 25.38071F;
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPermission
            // 
            this.colPermission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPermission.FillWeight = 25.38071F;
            this.colPermission.HeaderText = "Permission";
            this.colPermission.Name = "colPermission";
            // 
            // colModifyValue
            // 
            this.colModifyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colModifyValue.FillWeight = 25.38071F;
            this.colModifyValue.HeaderText = "ModifyValue";
            this.colModifyValue.Name = "colModifyValue";
            this.colModifyValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colModifyValue.Width = 200;
            // 
            // colCurrentValue
            // 
            this.colCurrentValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCurrentValue.FillWeight = 25.38071F;
            this.colCurrentValue.HeaderText = "CurrentValue";
            this.colCurrentValue.Name = "colCurrentValue";
            this.colCurrentValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCurrentValue.Width = 200;
            // 
            // colReadMode
            // 
            this.colReadMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colReadMode.FillWeight = 25.38071F;
            this.colReadMode.HeaderText = "ReadMode";
            this.colReadMode.Name = "colReadMode";
            // 
            // colEventNotify
            // 
            this.colEventNotify.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEventNotify.FillWeight = 25.38071F;
            this.colEventNotify.HeaderText = "EventNotify";
            this.colEventNotify.Name = "colEventNotify";
            // 
            // colWriteValue
            // 
            this.colWriteValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colWriteValue.FillWeight = 25.38071F;
            this.colWriteValue.HeaderText = "WriteValue";
            this.colWriteValue.Name = "colWriteValue";
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportCsv,
            this.tsmiImportCsv,
            this.tsmiExportDll,
            this.tsmiRefresh,
            this.tsmiSave,
            this.tsmiAdd,
            this.tsmiDelete,
            this.tsmiClear});
            this.cms.Name = "contextMenuStrip1";
            this.cms.Size = new System.Drawing.Size(137, 180);
            // 
            // tsmiExportCsv
            // 
            this.tsmiExportCsv.Name = "tsmiExportCsv";
            this.tsmiExportCsv.Size = new System.Drawing.Size(136, 22);
            this.tsmiExportCsv.Text = "ExportCsv";
            this.tsmiExportCsv.Click += new System.EventHandler(this.tsmiExportCsv_Click);
            // 
            // tsmiImportCsv
            // 
            this.tsmiImportCsv.Name = "tsmiImportCsv";
            this.tsmiImportCsv.Size = new System.Drawing.Size(136, 22);
            this.tsmiImportCsv.Text = "ImportCsv";
            this.tsmiImportCsv.Click += new System.EventHandler(this.tsmiImportCsv_Click);
            // 
            // tsmiExportDll
            // 
            this.tsmiExportDll.Name = "tsmiExportDll";
            this.tsmiExportDll.Size = new System.Drawing.Size(136, 22);
            this.tsmiExportDll.Text = "ExportDll";
            this.tsmiExportDll.Click += new System.EventHandler(this.tsmiExportDll_Click);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(136, 22);
            this.tsmiRefresh.Text = "Refresh";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(136, 22);
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(136, 22);
            this.tsmiAdd.Text = "Add";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(136, 22);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(136, 22);
            this.tsmiClear.Text = "Clear";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // tBoxTableDataPath
            // 
            this.tBoxTableDataPath.Location = new System.Drawing.Point(8, 10);
            this.tBoxTableDataPath.Name = "tBoxTableDataPath";
            this.tBoxTableDataPath.Size = new System.Drawing.Size(378, 25);
            this.tBoxTableDataPath.TabIndex = 138;
            this.tBoxTableDataPath.TextChanged += new System.EventHandler(this.tBoxTableDataPath_TextChanged);
            // 
            // btnTableBrowse
            // 
            this.btnTableBrowse.Location = new System.Drawing.Point(392, 9);
            this.btnTableBrowse.Name = "btnTableBrowse";
            this.btnTableBrowse.Size = new System.Drawing.Size(68, 26);
            this.btnTableBrowse.TabIndex = 137;
            this.btnTableBrowse.Text = "...";
            this.btnTableBrowse.UseVisualStyleBackColor = true;
            this.btnTableBrowse.Click += new System.EventHandler(this.btnTableBrowse_Click);
            // 
            // cBoxMonitor
            // 
            this.cBoxMonitor.AutoSize = true;
            this.cBoxMonitor.Location = new System.Drawing.Point(469, 10);
            this.cBoxMonitor.Name = "cBoxMonitor";
            this.cBoxMonitor.Size = new System.Drawing.Size(83, 24);
            this.cBoxMonitor.TabIndex = 134;
            this.cBoxMonitor.Text = "Monitor";
            this.cBoxMonitor.UseVisualStyleBackColor = true;
            this.cBoxMonitor.CheckedChanged += new System.EventHandler(this.cBoxMonitor_CheckedChanged);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // PrimConfigControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.FillColor = System.Drawing.Color.LightGray;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrimConfigControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.panel1.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splData.Panel1.ResumeLayout(false);
            this.splData.Panel2.ResumeLayout(false);
            this.splData.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splData)).EndInit();
            this.splData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataConfig)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cBoxNotifyMode;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblNotifyMode;
        private System.Windows.Forms.Label lblReConnectCnt;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox tBoxPort;
        private System.Windows.Forms.TextBox tBoxReConnCnt;
        private System.Windows.Forms.TextBox tBoxIP;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblDA2;
        private System.Windows.Forms.TextBox tBoxDA2;
        private System.Windows.Forms.SplitContainer splData;
        private System.Windows.Forms.DataGridView dgvDataConfig;
        private System.Windows.Forms.TextBox tBoxTableDataPath;
        private System.Windows.Forms.Button btnTableBrowse;
        private System.Windows.Forms.CheckBox cBoxMonitor;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.TextBox tBoxCycleTime;
        private System.Windows.Forms.Label lblCycleTime;
        private System.Windows.Forms.Label lblSA1;
        private System.Windows.Forms.TextBox tBoxSA1;
        private System.Windows.Forms.Label lblDA1;
        private System.Windows.Forms.TextBox tBoxDA1;
        private System.Windows.Forms.Label lblFinsType;
        private System.Windows.Forms.ComboBox cbFinsType;
        private System.Windows.Forms.CheckBox cbLogEnable;
        private UITableLayoutPanel tlpTitle;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportCsv;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportCsv;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.Label lblWriteStartAddress;
        private System.Windows.Forms.Label lblReadStartAddress;
        private System.Windows.Forms.TextBox txtWriteStartAddress;
        private System.Windows.Forms.Label lblWriteLength;
        private System.Windows.Forms.TextBox txtReadStartAddress;
        private System.Windows.Forms.TextBox txtWriteLength;
        private System.Windows.Forms.Label lblReadLength;
        private System.Windows.Forms.TextBox txtReadLength;
        private UIPanel pnl3;
        private UIPanel pnl2;
        private UIPanel pnl1;
        private UILabel lblCycleTimeShow;
        private UITextBox txtName;
        private UITextBox txtConnState;
        private UITextBox txtRunState;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportDll;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPermission;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn colReadMode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEventNotify;
        private System.Windows.Forms.DataGridViewButtonColumn colWriteValue;
        private UILabel lblError;
    }
}
