namespace Lead.CPrim.PrimVarManager.Controls
{
    partial class ConfigUiControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbConnState = new System.Windows.Forms.TextBox();
            this.tbRunState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tPageVarsConfig = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvVars = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPermisson = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCurrentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReadMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEventNotify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.tbParamsPath = new System.Windows.Forms.TextBox();
            this.btnLoadParams = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.tPageParamConfig = new System.Windows.Forms.TabPage();
            this.tbCycleTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkCycleEnable = new System.Windows.Forms.CheckBox();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.tbServerPCName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVarsType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tPageVarsConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVars)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tPageParamConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.tbConnState);
            this.panel1.Controls.Add(this.tbRunState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 11, 5, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 55);
            this.panel1.TabIndex = 32;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.OldLace;
            this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Location = new System.Drawing.Point(163, 0);
            this.tbName.Margin = new System.Windows.Forms.Padding(5, 11, 5, 11);
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(184, 55);
            this.tbName.TabIndex = 16;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbConnState
            // 
            this.tbConnState.BackColor = System.Drawing.Color.Khaki;
            this.tbConnState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConnState.Location = new System.Drawing.Point(855, 0);
            this.tbConnState.Margin = new System.Windows.Forms.Padding(5, 11, 5, 11);
            this.tbConnState.Multiline = true;
            this.tbConnState.Name = "tbConnState";
            this.tbConnState.Size = new System.Drawing.Size(149, 55);
            this.tbConnState.TabIndex = 15;
            this.tbConnState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRunState
            // 
            this.tbRunState.BackColor = System.Drawing.Color.Khaki;
            this.tbRunState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbRunState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRunState.Location = new System.Drawing.Point(1004, 0);
            this.tbRunState.Margin = new System.Windows.Forms.Padding(5, 11, 5, 11);
            this.tbRunState.Multiline = true;
            this.tbRunState.Name = "tbRunState";
            this.tbRunState.Size = new System.Drawing.Size(146, 55);
            this.tbRunState.TabIndex = 14;
            this.tbRunState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 55);
            this.label1.TabIndex = 12;
            this.label1.Text = "名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1150, 50);
            this.lbTitle.TabIndex = 31;
            this.lbTitle.Text = "远程变量配置";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnApply.Location = new System.Drawing.Point(316, 30);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(70, 42);
            this.btnApply.TabIndex = 151;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Controls.Add(this.btnApply);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.groupBox.Location = new System.Drawing.Point(736, 6);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox.Size = new System.Drawing.Size(395, 105);
            this.groupBox.TabIndex = 150;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "EXE";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Location = new System.Drawing.Point(217, 30);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(70, 42);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Location = new System.Drawing.Point(118, 30);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(70, 42);
            this.btnRun.TabIndex = 105;
            this.btnRun.Text = "运行";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.SkyBlue;
            this.btnInit.Location = new System.Drawing.Point(10, 30);
            this.btnInit.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(79, 42);
            this.btnInit.TabIndex = 105;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tPageVarsConfig);
            this.tabControl1.Controls.Add(this.tPageParamConfig);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 105);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1150, 501);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 171;
            // 
            // tPageVarsConfig
            // 
            this.tPageVarsConfig.Controls.Add(this.splitContainer1);
            this.tPageVarsConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tPageVarsConfig.Location = new System.Drawing.Point(4, 29);
            this.tPageVarsConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tPageVarsConfig.Name = "tPageVarsConfig";
            this.tPageVarsConfig.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tPageVarsConfig.Size = new System.Drawing.Size(1142, 468);
            this.tPageVarsConfig.TabIndex = 0;
            this.tPageVarsConfig.Text = "变量配置";
            this.tPageVarsConfig.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvVars);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1136, 460);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvVars
            // 
            this.dgvVars.AllowUserToAddRows = false;
            this.dgvVars.ColumnHeadersHeight = 29;
            this.dgvVars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colType,
            this.colPermisson,
            this.colCurrentValue,
            this.colModifyValue,
            this.colReadMode,
            this.colEventNotify});
            this.dgvVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVars.Location = new System.Drawing.Point(0, 0);
            this.dgvVars.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvVars.Name = "dgvVars";
            this.dgvVars.RowHeadersWidth = 51;
            this.dgvVars.RowTemplate.Height = 23;
            this.dgvVars.Size = new System.Drawing.Size(1134, 333);
            this.dgvVars.TabIndex = 37;
            this.dgvVars.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVars_CellEndEdit);
            this.dgvVars.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVars_CellEnter);
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 120;
            // 
            // colType
            // 
            this.colType.DropDownWidth = 121;
            this.colType.HeaderText = "类型";
            this.colType.Items.AddRange(new object[] {
            "BOOL",
            "INT",
            "DOUBLE",
            "STRING",
            "Other"});
            this.colType.MinimumWidth = 6;
            this.colType.Name = "colType";
            this.colType.Width = 60;
            // 
            // colPermisson
            // 
            this.colPermisson.DropDownWidth = 121;
            this.colPermisson.HeaderText = "远程权限";
            this.colPermisson.Items.AddRange(new object[] {
            "R",
            "W",
            "RW"});
            this.colPermisson.MinimumWidth = 6;
            this.colPermisson.Name = "colPermisson";
            this.colPermisson.Width = 80;
            // 
            // colCurrentValue
            // 
            this.colCurrentValue.HeaderText = "当前值";
            this.colCurrentValue.MinimumWidth = 6;
            this.colCurrentValue.Name = "colCurrentValue";
            this.colCurrentValue.ReadOnly = true;
            this.colCurrentValue.Width = 125;
            // 
            // colModifyValue
            // 
            this.colModifyValue.HeaderText = "更改值";
            this.colModifyValue.MinimumWidth = 6;
            this.colModifyValue.Name = "colModifyValue";
            this.colModifyValue.Width = 125;
            // 
            // colReadMode
            // 
            this.colReadMode.DropDownWidth = 121;
            this.colReadMode.HeaderText = "读取模式";
            this.colReadMode.Items.AddRange(new object[] {
            "NonCycle",
            "Cycle",
            "Queue"});
            this.colReadMode.MinimumWidth = 6;
            this.colReadMode.Name = "colReadMode";
            this.colReadMode.Width = 80;
            // 
            // colEventNotify
            // 
            this.colEventNotify.HeaderText = "事件通知";
            this.colEventNotify.MinimumWidth = 6;
            this.colEventNotify.Name = "colEventNotify";
            this.colEventNotify.Width = 80;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.76923F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.23077F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemoveRow, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbParamsPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadParams, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddRow, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1134, 117);
            this.tableLayoutPanel1.TabIndex = 176;
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemoveRow.Location = new System.Drawing.Point(659, 42);
            this.btnRemoveRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(55, 33);
            this.btnRemoveRow.TabIndex = 172;
            this.btnRemoveRow.Text = "-";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // tbParamsPath
            // 
            this.tbParamsPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbParamsPath.Location = new System.Drawing.Point(25, 45);
            this.tbParamsPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbParamsPath.Name = "tbParamsPath";
            this.tbParamsPath.Size = new System.Drawing.Size(390, 27);
            this.tbParamsPath.TabIndex = 175;
            this.tbParamsPath.TextChanged += new System.EventHandler(this.tbParamsPath_TextChanged);
            // 
            // btnLoadParams
            // 
            this.btnLoadParams.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadParams.Location = new System.Drawing.Point(461, 42);
            this.btnLoadParams.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadParams.Name = "btnLoadParams";
            this.btnLoadParams.Size = new System.Drawing.Size(64, 33);
            this.btnLoadParams.TabIndex = 173;
            this.btnLoadParams.Text = "载入";
            this.btnLoadParams.UseVisualStyleBackColor = true;
            this.btnLoadParams.Click += new System.EventHandler(this.btnLoadParams_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddRow.Location = new System.Drawing.Point(566, 42);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(55, 33);
            this.btnAddRow.TabIndex = 171;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // tPageParamConfig
            // 
            this.tPageParamConfig.Controls.Add(this.tbCycleTime);
            this.tPageParamConfig.Controls.Add(this.label6);
            this.tPageParamConfig.Controls.Add(this.chkCycleEnable);
            this.tPageParamConfig.Controls.Add(this.tbServerIp);
            this.tPageParamConfig.Controls.Add(this.tbServerPCName);
            this.tPageParamConfig.Controls.Add(this.label5);
            this.tPageParamConfig.Controls.Add(this.label4);
            this.tPageParamConfig.Controls.Add(this.tbServerName);
            this.tPageParamConfig.Controls.Add(this.label8);
            this.tPageParamConfig.Controls.Add(this.label7);
            this.tPageParamConfig.Controls.Add(this.label3);
            this.tPageParamConfig.Controls.Add(this.label2);
            this.tPageParamConfig.Controls.Add(this.cmbVarsType);
            this.tPageParamConfig.Location = new System.Drawing.Point(4, 29);
            this.tPageParamConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tPageParamConfig.Name = "tPageParamConfig";
            this.tPageParamConfig.Size = new System.Drawing.Size(1142, 468);
            this.tPageParamConfig.TabIndex = 1;
            this.tPageParamConfig.Text = "参数配置";
            this.tPageParamConfig.UseVisualStyleBackColor = true;
            // 
            // tbCycleTime
            // 
            this.tbCycleTime.Location = new System.Drawing.Point(147, 249);
            this.tbCycleTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCycleTime.Name = "tbCycleTime";
            this.tbCycleTime.Size = new System.Drawing.Size(140, 27);
            this.tbCycleTime.TabIndex = 8;
            this.tbCycleTime.Text = "50";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "循环扫描时间：";
            // 
            // chkCycleEnable
            // 
            this.chkCycleEnable.AutoSize = true;
            this.chkCycleEnable.Location = new System.Drawing.Point(19, 305);
            this.chkCycleEnable.Name = "chkCycleEnable";
            this.chkCycleEnable.Size = new System.Drawing.Size(121, 24);
            this.chkCycleEnable.TabIndex = 6;
            this.chkCycleEnable.Text = "循环扫描使能";
            this.chkCycleEnable.UseVisualStyleBackColor = true;
            this.chkCycleEnable.CheckedChanged += new System.EventHandler(this.chkCycleEnable_CheckedChanged);
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(147, 196);
            this.tbServerIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(140, 27);
            this.tbServerIp.TabIndex = 5;
            this.tbServerIp.Text = "127.0.0.1";
            // 
            // tbServerPCName
            // 
            this.tbServerPCName.Location = new System.Drawing.Point(147, 143);
            this.tbServerPCName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbServerPCName.Name = "tbServerPCName";
            this.tbServerPCName.Size = new System.Drawing.Size(140, 27);
            this.tbServerPCName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "主站IP地址：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "主站PC名称：";
            // 
            // tbServerName
            // 
            this.tbServerName.Location = new System.Drawing.Point(147, 90);
            this.tbServerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(140, 27);
            this.tbServerName.TabIndex = 3;
            this.tbServerName.Text = "VarServer0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(16, 391);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "　　　主站PC名称：备用；";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(16, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(464, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "备注：客户端：以【主站名称】做为数据表；服务器：以【名称】做为数据表；";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "主站名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "变量管理器类型：";
            // 
            // cmbVarsType
            // 
            this.cmbVarsType.FormattingEnabled = true;
            this.cmbVarsType.Items.AddRange(new object[] {
            "Server",
            "Client"});
            this.cmbVarsType.Location = new System.Drawing.Point(147, 36);
            this.cmbVarsType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVarsType.Name = "cmbVarsType";
            this.cmbVarsType.Size = new System.Drawing.Size(140, 28);
            this.cmbVarsType.TabIndex = 0;
            this.cmbVarsType.Text = "Server";
            // 
            // ConfigUiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigUiControl";
            this.Size = new System.Drawing.Size(1150, 629);
            this.Load += new System.EventHandler(this.ConfigUiControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tPageVarsConfig.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVars)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tPageParamConfig.ResumeLayout(false);
            this.tPageParamConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbConnState;
        private System.Windows.Forms.TextBox tbRunState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tPageVarsConfig;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvVars;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPermisson;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn colReadMode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEventNotify;
        private System.Windows.Forms.TextBox tbParamsPath;
        private System.Windows.Forms.Button btnLoadParams;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.TabPage tPageParamConfig;
        private System.Windows.Forms.TextBox tbServerPCName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVarsType;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkCycleEnable;
        private System.Windows.Forms.TextBox tbCycleTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
