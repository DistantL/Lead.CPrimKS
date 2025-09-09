using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.PrimKeyencePLC
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lblTaskBoxName = new System.Windows.Forms.Label();
            this.txtName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtConnState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtRunState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnl4 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.pnl1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.lblCycleTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLogEnable = new System.Windows.Forms.CheckBox();
            this.tBoxPort = new System.Windows.Forms.TextBox();
            this.lbCycTime = new System.Windows.Forms.Label();
            this.tBoxIP = new System.Windows.Forms.TextBox();
            this.tBoxReConnCnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxCycleTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splData = new System.Windows.Forms.SplitContainer();
            this.dgvDataConfig = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColAddressType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPermission = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colModifyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReadMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEventNotify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colWriteValue = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBoxTableDataPath = new System.Windows.Forms.TextBox();
            this.btnTableSaveAs = new System.Windows.Forms.Button();
            this.btnTableBrowse = new System.Windows.Forms.Button();
            this.cBoxMonitor = new System.Windows.Forms.CheckBox();
            this.btnConfigApply = new System.Windows.Forms.Button();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splData)).BeginInit();
            this.splData.Panel1.SuspendLayout();
            this.splData.Panel2.SuspendLayout();
            this.splData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataConfig)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(800, 43);
            this.lbTitle.TabIndex = 24;
            this.lbTitle.Text = "KeyencePLC Config";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 43);
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
            this.tlpTitle.Controls.Add(this.lblTaskBoxName, 0, 0);
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
            this.tlpTitle.TabIndex = 0;
            this.tlpTitle.TagString = null;
            // 
            // lblTaskBoxName
            // 
            this.lblTaskBoxName.BackColor = System.Drawing.Color.SkyBlue;
            this.lblTaskBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTaskBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTaskBoxName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTaskBoxName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTaskBoxName.Location = new System.Drawing.Point(1, 1);
            this.lblTaskBoxName.Margin = new System.Windows.Forms.Padding(1);
            this.lblTaskBoxName.Name = "lblTaskBoxName";
            this.lblTaskBoxName.Size = new System.Drawing.Size(148, 42);
            this.lblTaskBoxName.TabIndex = 12;
            this.lblTaskBoxName.Text = "FinsNet Name";
            this.lblTaskBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtRunState.TabIndex = 13;
            this.txtRunState.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtRunState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 87);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(800, 413);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.tabPage1.Controls.Add(this.pnl4);
            this.tabPage1.Controls.Add(this.pnl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config";
            // 
            // pnl4
            // 
            this.pnl4.Controls.Add(this.btnStop);
            this.pnl4.Controls.Add(this.btnInit);
            this.pnl4.Controls.Add(this.btnApply);
            this.pnl4.Controls.Add(this.btnRun);
            this.pnl4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl4.Location = new System.Drawing.Point(7, 299);
            this.pnl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl4.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(778, 66);
            this.pnl4.TabIndex = 151;
            this.pnl4.Text = null;
            this.pnl4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Location = new System.Drawing.Point(465, 15);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(74, 41);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.SkyBlue;
            this.btnInit.Location = new System.Drawing.Point(19, 15);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(74, 41);
            this.btnInit.TabIndex = 105;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(688, 15);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(74, 41);
            this.btnApply.TabIndex = 127;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Location = new System.Drawing.Point(242, 15);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(74, 41);
            this.btnRun.TabIndex = 105;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.lblCycleTime);
            this.pnl1.Controls.Add(this.label2);
            this.pnl1.Controls.Add(this.cbLogEnable);
            this.pnl1.Controls.Add(this.tBoxPort);
            this.pnl1.Controls.Add(this.lbCycTime);
            this.pnl1.Controls.Add(this.tBoxIP);
            this.pnl1.Controls.Add(this.tBoxReConnCnt);
            this.pnl1.Controls.Add(this.label3);
            this.pnl1.Controls.Add(this.tBoxCycleTime);
            this.pnl1.Controls.Add(this.label9);
            this.pnl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl1.Location = new System.Drawing.Point(7, 5);
            this.pnl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl1.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(778, 284);
            this.pnl1.TabIndex = 149;
            this.pnl1.Text = null;
            this.pnl1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblCycleTime
            // 
            this.lblCycleTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCycleTime.Location = new System.Drawing.Point(334, 165);
            this.lblCycleTime.Name = "lblCycleTime";
            this.lblCycleTime.Size = new System.Drawing.Size(55, 23);
            this.lblCycleTime.TabIndex = 143;
            this.lblCycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCycleTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 24);
            this.label2.TabIndex = 125;
            this.label2.Text = "IP";
            // 
            // cbLogEnable
            // 
            this.cbLogEnable.AutoSize = true;
            this.cbLogEnable.BackColor = System.Drawing.Color.Transparent;
            this.cbLogEnable.Location = new System.Drawing.Point(19, 204);
            this.cbLogEnable.Name = "cbLogEnable";
            this.cbLogEnable.Size = new System.Drawing.Size(114, 31);
            this.cbLogEnable.TabIndex = 142;
            this.cbLogEnable.Text = "日志启用";
            this.cbLogEnable.UseVisualStyleBackColor = false;
            // 
            // tBoxPort
            // 
            this.tBoxPort.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxPort.Location = new System.Drawing.Point(306, 46);
            this.tBoxPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxPort.Name = "tBoxPort";
            this.tBoxPort.Size = new System.Drawing.Size(140, 31);
            this.tBoxPort.TabIndex = 120;
            // 
            // lbCycTime
            // 
            this.lbCycTime.AutoSize = true;
            this.lbCycTime.BackColor = System.Drawing.Color.Transparent;
            this.lbCycTime.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.lbCycTime.Location = new System.Drawing.Point(227, 134);
            this.lbCycTime.Name = "lbCycTime";
            this.lbCycTime.Size = new System.Drawing.Size(176, 24);
            this.lbCycTime.TabIndex = 140;
            this.lbCycTime.Text = "CycleTime(5-10ms)";
            this.lbCycTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBoxIP
            // 
            this.tBoxIP.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxIP.Location = new System.Drawing.Point(15, 46);
            this.tBoxIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxIP.Name = "tBoxIP";
            this.tBoxIP.Size = new System.Drawing.Size(259, 31);
            this.tBoxIP.TabIndex = 121;
            // 
            // tBoxReConnCnt
            // 
            this.tBoxReConnCnt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxReConnCnt.Location = new System.Drawing.Point(15, 163);
            this.tBoxReConnCnt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tBoxReConnCnt.Name = "tBoxReConnCnt";
            this.tBoxReConnCnt.Size = new System.Drawing.Size(140, 34);
            this.tBoxReConnCnt.TabIndex = 121;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.label3.Location = new System.Drawing.Point(306, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 122;
            this.label3.Text = "Port";
            // 
            // tBoxCycleTime
            // 
            this.tBoxCycleTime.Location = new System.Drawing.Point(227, 162);
            this.tBoxCycleTime.Name = "tBoxCycleTime";
            this.tBoxCycleTime.Size = new System.Drawing.Size(100, 34);
            this.tBoxCycleTime.TabIndex = 141;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(15, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 24);
            this.label9.TabIndex = 125;
            this.label9.Text = "ReConnect Cnt(0-3)";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.splData);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 380);
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
            this.splData.Panel2.Controls.Add(this.btnTableSaveAs);
            this.splData.Panel2.Controls.Add(this.btnTableBrowse);
            this.splData.Panel2.Controls.Add(this.cBoxMonitor);
            this.splData.Panel2.Controls.Add(this.btnConfigApply);
            this.splData.Panel2.Controls.Add(this.btnDelRow);
            this.splData.Panel2.Controls.Add(this.btnAddRow);
            this.splData.Size = new System.Drawing.Size(786, 374);
            this.splData.SplitterDistance = 315;
            this.splData.TabIndex = 0;
            // 
            // dgvDataConfig
            // 
            this.dgvDataConfig.AllowUserToAddRows = false;
            this.dgvDataConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataConfig.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDataConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colType,
            this.colLength,
            this.dgvColAddressType,
            this.colAddress,
            this.colPermission,
            this.colModifyValue,
            this.colCurrentValue,
            this.colReadMode,
            this.colEventNotify,
            this.colWriteValue});
            this.dgvDataConfig.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDataConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataConfig.Location = new System.Drawing.Point(0, 0);
            this.dgvDataConfig.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDataConfig.Name = "dgvDataConfig";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataConfig.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataConfig.RowHeadersWidth = 55;
            this.dgvDataConfig.RowTemplate.Height = 27;
            this.dgvDataConfig.Size = new System.Drawing.Size(786, 315);
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
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colType.FillWeight = 25.38071F;
            this.colType.HeaderText = "值类型";
            this.colType.MinimumWidth = 6;
            this.colType.Name = "colType";
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colType.Width = 125;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colLength.FillWeight = 25.38071F;
            this.colLength.HeaderText = "长度";
            this.colLength.MinimumWidth = 6;
            this.colLength.Name = "colLength";
            this.colLength.Width = 125;
            // 
            // dgvColAddressType
            // 
            this.dgvColAddressType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvColAddressType.FillWeight = 25.38071F;
            this.dgvColAddressType.HeaderText = "地址类型";
            this.dgvColAddressType.MinimumWidth = 6;
            this.dgvColAddressType.Name = "dgvColAddressType";
            this.dgvColAddressType.Width = 125;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAddress.FillWeight = 25.38071F;
            this.colAddress.HeaderText = "地址";
            this.colAddress.MinimumWidth = 6;
            this.colAddress.Name = "colAddress";
            this.colAddress.Width = 125;
            // 
            // colPermission
            // 
            this.colPermission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPermission.FillWeight = 25.38071F;
            this.colPermission.HeaderText = "读写权限";
            this.colPermission.MinimumWidth = 6;
            this.colPermission.Name = "colPermission";
            this.colPermission.Width = 125;
            // 
            // colModifyValue
            // 
            this.colModifyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colModifyValue.FillWeight = 25.38071F;
            this.colModifyValue.HeaderText = "修改值";
            this.colModifyValue.MinimumWidth = 6;
            this.colModifyValue.Name = "colModifyValue";
            this.colModifyValue.Width = 125;
            // 
            // colCurrentValue
            // 
            this.colCurrentValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCurrentValue.FillWeight = 25.38071F;
            this.colCurrentValue.HeaderText = "当前值";
            this.colCurrentValue.MinimumWidth = 6;
            this.colCurrentValue.Name = "colCurrentValue";
            this.colCurrentValue.Width = 125;
            // 
            // colReadMode
            // 
            this.colReadMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colReadMode.FillWeight = 25.38071F;
            this.colReadMode.HeaderText = "数据读取模式";
            this.colReadMode.MinimumWidth = 6;
            this.colReadMode.Name = "colReadMode";
            this.colReadMode.Width = 125;
            // 
            // colEventNotify
            // 
            this.colEventNotify.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEventNotify.FillWeight = 25.38071F;
            this.colEventNotify.HeaderText = "触发事件";
            this.colEventNotify.MinimumWidth = 6;
            this.colEventNotify.Name = "colEventNotify";
            this.colEventNotify.Width = 125;
            // 
            // colWriteValue
            // 
            this.colWriteValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colWriteValue.FillWeight = 25.38071F;
            this.colWriteValue.HeaderText = "更改";
            this.colWriteValue.MinimumWidth = 6;
            this.colWriteValue.Name = "colWriteValue";
            this.colWriteValue.Width = 125;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出CSVToolStripMenuItem,
            this.导入CSVToolStripMenuItem,
            this.导出代码ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 100);
            // 
            // 导出CSVToolStripMenuItem
            // 
            this.导出CSVToolStripMenuItem.Name = "导出CSVToolStripMenuItem";
            this.导出CSVToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.导出CSVToolStripMenuItem.Text = "导出CSV";
            this.导出CSVToolStripMenuItem.Click += new System.EventHandler(this.导出CSVToolStripMenuItem_Click);
            // 
            // 导入CSVToolStripMenuItem
            // 
            this.导入CSVToolStripMenuItem.Name = "导入CSVToolStripMenuItem";
            this.导入CSVToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.导入CSVToolStripMenuItem.Text = "导入CSV";
            this.导入CSVToolStripMenuItem.Click += new System.EventHandler(this.导入CSVToolStripMenuItem_Click);
            // 
            // 导出代码ToolStripMenuItem
            // 
            this.导出代码ToolStripMenuItem.Name = "导出代码ToolStripMenuItem";
            this.导出代码ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.导出代码ToolStripMenuItem.Text = "导出代码";
            this.导出代码ToolStripMenuItem.Click += new System.EventHandler(this.导出代码ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // tBoxTableDataPath
            // 
            this.tBoxTableDataPath.Location = new System.Drawing.Point(19, 16);
            this.tBoxTableDataPath.Name = "tBoxTableDataPath";
            this.tBoxTableDataPath.Size = new System.Drawing.Size(266, 27);
            this.tBoxTableDataPath.TabIndex = 138;
            // 
            // btnTableSaveAs
            // 
            this.btnTableSaveAs.Location = new System.Drawing.Point(352, 14);
            this.btnTableSaveAs.Name = "btnTableSaveAs";
            this.btnTableSaveAs.Size = new System.Drawing.Size(50, 26);
            this.btnTableSaveAs.TabIndex = 135;
            this.btnTableSaveAs.Text = "Save As";
            this.btnTableSaveAs.UseVisualStyleBackColor = true;
            this.btnTableSaveAs.Click += new System.EventHandler(this.btnTableSaveAs_Click);
            // 
            // btnTableBrowse
            // 
            this.btnTableBrowse.Location = new System.Drawing.Point(292, 14);
            this.btnTableBrowse.Name = "btnTableBrowse";
            this.btnTableBrowse.Size = new System.Drawing.Size(50, 26);
            this.btnTableBrowse.TabIndex = 137;
            this.btnTableBrowse.Text = "...";
            this.btnTableBrowse.UseVisualStyleBackColor = true;
            this.btnTableBrowse.Click += new System.EventHandler(this.btnTableBrowse_Click);
            // 
            // cBoxMonitor
            // 
            this.cBoxMonitor.AutoSize = true;
            this.cBoxMonitor.Location = new System.Drawing.Point(569, 17);
            this.cBoxMonitor.Name = "cBoxMonitor";
            this.cBoxMonitor.Size = new System.Drawing.Size(61, 24);
            this.cBoxMonitor.TabIndex = 134;
            this.cBoxMonitor.Text = "监控";
            this.cBoxMonitor.UseVisualStyleBackColor = true;
            this.cBoxMonitor.CheckedChanged += new System.EventHandler(this.cBoxMonitor_CheckedChanged);
            // 
            // btnConfigApply
            // 
            this.btnConfigApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfigApply.Location = new System.Drawing.Point(649, 12);
            this.btnConfigApply.Name = "btnConfigApply";
            this.btnConfigApply.Size = new System.Drawing.Size(118, 31);
            this.btnConfigApply.TabIndex = 131;
            this.btnConfigApply.Text = "数据保存";
            this.btnConfigApply.UseVisualStyleBackColor = false;
            this.btnConfigApply.Click += new System.EventHandler(this.btnConfigApply_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Location = new System.Drawing.Point(472, 14);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(50, 26);
            this.btnDelRow.TabIndex = 129;
            this.btnDelRow.Text = "-";
            this.btnDelRow.UseVisualStyleBackColor = true;
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(412, 14);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(50, 26);
            this.btnAddRow.TabIndex = 130;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // PrimConfigControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrimConfigControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.panel1.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnl4.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splData.Panel1.ResumeLayout(false);
            this.splData.Panel2.ResumeLayout(false);
            this.splData.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splData)).EndInit();
            this.splData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataConfig)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTaskBoxName;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxPort;
        private System.Windows.Forms.TextBox tBoxReConnCnt;
        private System.Windows.Forms.TextBox tBoxIP;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splData;
        private System.Windows.Forms.DataGridView dgvDataConfig;
        private System.Windows.Forms.TextBox tBoxTableDataPath;
        private System.Windows.Forms.Button btnTableSaveAs;
        private System.Windows.Forms.Button btnTableBrowse;
        private System.Windows.Forms.CheckBox cBoxMonitor;
        private System.Windows.Forms.Button btnConfigApply;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.TextBox tBoxCycleTime;
        private System.Windows.Forms.Label lbCycTime;
        private System.Windows.Forms.CheckBox cbLogEnable;
        private UITableLayoutPanel tlpTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出CSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入CSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出代码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private UIPanel pnl4;
        private UIPanel pnl1;
        private UILabel lblCycleTime;
        private UITextBox txtName;
        private UITextBox txtConnState;
        private UITextBox txtRunState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColAddressType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPermission;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn colReadMode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEventNotify;
        private System.Windows.Forms.DataGridViewButtonColumn colWriteValue;
    }
}
