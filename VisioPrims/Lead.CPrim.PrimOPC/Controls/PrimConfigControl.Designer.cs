namespace Lead.CPrim.PrimOPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimConfigControl));
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cmbLoginMode = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbServerAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenCertFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCertificateFilePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSecretKey = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tlpNodeConfig = new System.Windows.Forms.TableLayoutPanel();
            this.tViewNodeList = new System.Windows.Forms.TreeView();
            this.cmsRefreshNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefreshNode = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tlpBody = new System.Windows.Forms.TableLayoutPanel();
            this.dgvNodeConfig = new System.Windows.Forms.DataGridView();
            this.colNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbNodeConfigPath = new System.Windows.Forms.TextBox();
            this.btnOpenNodeConfig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbConnState = new System.Windows.Forms.TextBox();
            this.tbRunState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrimName = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.saveFileDialogConfig = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tlpNodeConfig.SuspendLayout();
            this.cmsRefreshNode.SuspendLayout();
            this.tlpBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeConfig)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(18, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 121);
            this.groupBox1.TabIndex = 144;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "账号登陆";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 124;
            this.label2.Text = "用户名：";
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUserName.Location = new System.Drawing.Point(90, 33);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(136, 27);
            this.tbUserName.TabIndex = 123;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 122;
            this.label3.Text = "密码：";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPassword.Location = new System.Drawing.Point(90, 76);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(136, 27);
            this.tbPassword.TabIndex = 120;
            // 
            // cmbLoginMode
            // 
            this.cmbLoginMode.FormattingEnabled = true;
            this.cmbLoginMode.Items.AddRange(new object[] {
            "匿名登陆",
            "账号登陆",
            "证书登陆"});
            this.cmbLoginMode.Location = new System.Drawing.Point(108, 19);
            this.cmbLoginMode.Name = "cmbLoginMode";
            this.cmbLoginMode.Size = new System.Drawing.Size(121, 25);
            this.cmbLoginMode.TabIndex = 143;
            this.cmbLoginMode.Text = "匿名登陆";
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Location = new System.Drawing.Point(72, 28);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(60, 41);
            this.btnRun.TabIndex = 105;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(14, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 142;
            this.label5.Text = "登陆方式：";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(714, 340);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(78, 34);
            this.btnApply.TabIndex = 127;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click_1);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(488, 309);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(220, 84);
            this.groupBox.TabIndex = 126;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "EXE";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Location = new System.Drawing.Point(140, 28);
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
            this.btnInit.Location = new System.Drawing.Point(6, 28);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(60, 41);
            this.btnInit.TabIndex = 105;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(810, 429);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.tbServerAddress);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.cmbLoginMode);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnApply);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config";
            // 
            // tbServerAddress
            // 
            this.tbServerAddress.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.tbServerAddress.Location = new System.Drawing.Point(336, 20);
            this.tbServerAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbServerAddress.Name = "tbServerAddress";
            this.tbServerAddress.Size = new System.Drawing.Size(456, 22);
            this.tbServerAddress.TabIndex = 148;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(233, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 147;
            this.label8.Text = "服务器地址：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenCertFile);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbCertificateFilePath);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbSecretKey);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(276, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 121);
            this.groupBox2.TabIndex = 145;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "证书登陆";
            // 
            // btnOpenCertFile
            // 
            this.btnOpenCertFile.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOpenCertFile.Location = new System.Drawing.Point(465, 31);
            this.btnOpenCertFile.Name = "btnOpenCertFile";
            this.btnOpenCertFile.Size = new System.Drawing.Size(31, 33);
            this.btnOpenCertFile.TabIndex = 147;
            this.btnOpenCertFile.Text = "...";
            this.btnOpenCertFile.UseVisualStyleBackColor = true;
            this.btnOpenCertFile.Click += new System.EventHandler(this.btnOpenCertFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 124;
            this.label6.Text = "证书：";
            // 
            // tbCertificateFilePath
            // 
            this.tbCertificateFilePath.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.tbCertificateFilePath.Location = new System.Drawing.Point(60, 37);
            this.tbCertificateFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCertificateFilePath.Name = "tbCertificateFilePath";
            this.tbCertificateFilePath.Size = new System.Drawing.Size(399, 22);
            this.tbCertificateFilePath.TabIndex = 123;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 122;
            this.label7.Text = "密钥：";
            // 
            // tbSecretKey
            // 
            this.tbSecretKey.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.tbSecretKey.Location = new System.Drawing.Point(60, 80);
            this.tbSecretKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSecretKey.Name = "tbSecretKey";
            this.tbSecretKey.Size = new System.Drawing.Size(399, 22);
            this.tbSecretKey.TabIndex = 120;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.tlpNodeConfig);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(802, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Node";
            // 
            // tlpNodeConfig
            // 
            this.tlpNodeConfig.ColumnCount = 2;
            this.tlpNodeConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpNodeConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpNodeConfig.Controls.Add(this.tViewNodeList, 0, 0);
            this.tlpNodeConfig.Controls.Add(this.tlpBody, 1, 0);
            this.tlpNodeConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNodeConfig.Location = new System.Drawing.Point(3, 3);
            this.tlpNodeConfig.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNodeConfig.Name = "tlpNodeConfig";
            this.tlpNodeConfig.RowCount = 1;
            this.tlpNodeConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNodeConfig.Size = new System.Drawing.Size(796, 393);
            this.tlpNodeConfig.TabIndex = 0;
            // 
            // tViewNodeList
            // 
            this.tViewNodeList.ContextMenuStrip = this.cmsRefreshNode;
            this.tViewNodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tViewNodeList.ImageIndex = 0;
            this.tViewNodeList.ImageList = this.imageList;
            this.tViewNodeList.Location = new System.Drawing.Point(0, 0);
            this.tViewNodeList.Margin = new System.Windows.Forms.Padding(0);
            this.tViewNodeList.Name = "tViewNodeList";
            this.tViewNodeList.SelectedImageIndex = 0;
            this.tViewNodeList.ShowLines = false;
            this.tViewNodeList.Size = new System.Drawing.Size(159, 393);
            this.tViewNodeList.TabIndex = 0;
            this.tViewNodeList.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tViewNodeList_BeforeExpand);
            this.tViewNodeList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tViewNodeList_AfterSelect);
            this.tViewNodeList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tViewNodeList_MouseClick);
            // 
            // cmsRefreshNode
            // 
            this.cmsRefreshNode.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRefreshNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshNode});
            this.cmsRefreshNode.Name = "cmsRefreshNode";
            this.cmsRefreshNode.Size = new System.Drawing.Size(101, 26);
            // 
            // RefreshNode
            // 
            this.RefreshNode.Name = "RefreshNode";
            this.RefreshNode.Size = new System.Drawing.Size(100, 22);
            this.RefreshNode.Text = "刷新";
            this.RefreshNode.Click += new System.EventHandler(this.RefreshNode_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Activity_16xLG.png");
            this.imageList.Images.SetKeyName(1, "brackets_Square_16xMD.png");
            this.imageList.Images.SetKeyName(2, "Class_489.png");
            this.imageList.Images.SetKeyName(3, "ClassIcon.ico");
            this.imageList.Images.SetKeyName(4, "ClassIcon.png");
            this.imageList.Images.SetKeyName(5, "Cloud_16xLG.png");
            this.imageList.Images.SetKeyName(6, "Copy_6524.png");
            this.imageList.Images.SetKeyName(7, "Default.png");
            this.imageList.Images.SetKeyName(8, "Delegate_8339.png");
            this.imageList.Images.SetKeyName(9, "docview_xaml_on_16x16.png");
            this.imageList.Images.SetKeyName(10, "Enum_582.png");
            this.imageList.Images.SetKeyName(11, "Event_594.png");
            this.imageList.Images.SetKeyName(12, "Event_594_exp.png");
            this.imageList.Images.SetKeyName(13, "glasses_16xLG.png");
            this.imageList.Images.SetKeyName(14, "grid_Data_16xLG.png");
            this.imageList.Images.SetKeyName(15, "haitun.png");
            this.imageList.Images.SetKeyName(16, "haitun32x32.png");
            this.imageList.Images.SetKeyName(17, "lightningBolt_16xLG.png");
            this.imageList.Images.SetKeyName(18, "ListView_687.png");
            this.imageList.Images.SetKeyName(19, "loading.gif");
            this.imageList.Images.SetKeyName(20, "Method_636.png");
            this.imageList.Images.SetKeyName(21, "Module_648.png");
            this.imageList.Images.SetKeyName(22, "RegistryEditor_5838.ico");
            this.imageList.Images.SetKeyName(23, "SingleMessage_5727.ico");
            this.imageList.Images.SetKeyName(24, "Structure_507.png");
            this.imageList.Images.SetKeyName(25, "Table_748.png");
            this.imageList.Images.SetKeyName(26, "Tag_7213.png");
            this.imageList.Images.SetKeyName(27, "usbcontroller.png");
            this.imageList.Images.SetKeyName(28, "UserInterfaceEditor_5845.ico");
            this.imageList.Images.SetKeyName(29, "VirtualMachine.png");
            this.imageList.Images.SetKeyName(30, "WindowsForm_817.ico");
            // 
            // tlpBody
            // 
            this.tlpBody.ColumnCount = 1;
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBody.Controls.Add(this.dgvNodeConfig, 0, 0);
            this.tlpBody.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBody.Location = new System.Drawing.Point(159, 0);
            this.tlpBody.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBody.Name = "tlpBody";
            this.tlpBody.RowCount = 2;
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpBody.Size = new System.Drawing.Size(637, 393);
            this.tlpBody.TabIndex = 1;
            // 
            // dgvNodeConfig
            // 
            this.dgvNodeConfig.AllowUserToAddRows = false;
            this.dgvNodeConfig.AllowUserToDeleteRows = false;
            this.dgvNodeConfig.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvNodeConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNodeConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNum,
            this.colNodeName,
            this.value,
            this.Type,
            this.colNodeID});
            this.dgvNodeConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNodeConfig.Location = new System.Drawing.Point(0, 0);
            this.dgvNodeConfig.Margin = new System.Windows.Forms.Padding(0);
            this.dgvNodeConfig.Name = "dgvNodeConfig";
            this.dgvNodeConfig.RowHeadersWidth = 51;
            this.dgvNodeConfig.RowTemplate.Height = 27;
            this.dgvNodeConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNodeConfig.Size = new System.Drawing.Size(637, 353);
            this.dgvNodeConfig.TabIndex = 0;
            this.dgvNodeConfig.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNodeConfig_CellContentClick);
            this.dgvNodeConfig.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNodeConfig_CellEndEdit);
            // 
            // colNum
            // 
            this.colNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNum.HeaderText = "序号";
            this.colNum.MinimumWidth = 6;
            this.colNum.Name = "colNum";
            this.colNum.Width = 57;
            // 
            // colNodeName
            // 
            this.colNodeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNodeName.HeaderText = "节点名";
            this.colNodeName.MinimumWidth = 6;
            this.colNodeName.Name = "colNodeName";
            this.colNodeName.Width = 69;
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.MinimumWidth = 6;
            this.value.Name = "value";
            this.value.Width = 80;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.Width = 80;
            // 
            // colNodeID
            // 
            this.colNodeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNodeID.HeaderText = "节点ID";
            this.colNodeID.MinimumWidth = 6;
            this.colNodeID.Name = "colNodeID";
            this.colNodeID.Width = 70;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.Controls.Add(this.tbNodeConfigPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenNodeConfig, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 353);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(637, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tbNodeConfigPath
            // 
            this.tbNodeConfigPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNodeConfigPath.Location = new System.Drawing.Point(3, 6);
            this.tbNodeConfigPath.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.tbNodeConfigPath.Name = "tbNodeConfigPath";
            this.tbNodeConfigPath.Size = new System.Drawing.Size(430, 23);
            this.tbNodeConfigPath.TabIndex = 0;
            // 
            // btnOpenNodeConfig
            // 
            this.btnOpenNodeConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenNodeConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenNodeConfig.Location = new System.Drawing.Point(439, 3);
            this.btnOpenNodeConfig.Name = "btnOpenNodeConfig";
            this.btnOpenNodeConfig.Size = new System.Drawing.Size(103, 34);
            this.btnOpenNodeConfig.TabIndex = 1;
            this.btnOpenNodeConfig.Text = "...";
            this.btnOpenNodeConfig.UseVisualStyleBackColor = true;
            this.btnOpenNodeConfig.Click += new System.EventHandler(this.btnOpenNodeConfig_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(548, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbConnState);
            this.panel1.Controls.Add(this.tbRunState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbPrimName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 44);
            this.panel1.TabIndex = 28;
            // 
            // tbConnState
            // 
            this.tbConnState.BackColor = System.Drawing.Color.Khaki;
            this.tbConnState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConnState.Location = new System.Drawing.Point(388, 0);
            this.tbConnState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbConnState.Multiline = true;
            this.tbConnState.Name = "tbConnState";
            this.tbConnState.Size = new System.Drawing.Size(211, 44);
            this.tbConnState.TabIndex = 15;
            this.tbConnState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRunState
            // 
            this.tbRunState.BackColor = System.Drawing.Color.Khaki;
            this.tbRunState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbRunState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRunState.Location = new System.Drawing.Point(599, 0);
            this.tbRunState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRunState.Multiline = true;
            this.tbRunState.Name = "tbRunState";
            this.tbRunState.Size = new System.Drawing.Size(211, 44);
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
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 44);
            this.label1.TabIndex = 12;
            this.label1.Text = "OPC UA Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPrimName
            // 
            this.tbPrimName.BackColor = System.Drawing.Color.OldLace;
            this.tbPrimName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPrimName.Location = new System.Drawing.Point(203, 3);
            this.tbPrimName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPrimName.Multiline = true;
            this.tbPrimName.Name = "tbPrimName";
            this.tbPrimName.Size = new System.Drawing.Size(183, 39);
            this.tbPrimName.TabIndex = 13;
            this.tbPrimName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(810, 43);
            this.lbTitle.TabIndex = 27;
            this.lbTitle.Text = "OPC UA Config";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrimConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrimConfigControl";
            this.Size = new System.Drawing.Size(810, 516);
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tlpNodeConfig.ResumeLayout(false);
            this.cmsRefreshNode.ResumeLayout(false);
            this.tlpBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNodeConfig)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialogConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.ComboBox cmbLoginMode;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCertificateFilePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSecretKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbConnState;
        private System.Windows.Forms.TextBox tbRunState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrimName;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox tbServerAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOpenCertFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tlpNodeConfig;
        private System.Windows.Forms.TreeView tViewNodeList;
        private System.Windows.Forms.TableLayoutPanel tlpBody;
        private System.Windows.Forms.ContextMenuStrip cmsRefreshNode;
        private System.Windows.Forms.ToolStripMenuItem RefreshNode;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridView dgvNodeConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbNodeConfigPath;
        private System.Windows.Forms.Button btnOpenNodeConfig;
        private System.Windows.Forms.SaveFileDialog saveFileDialogConfig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeID;
    }
}
