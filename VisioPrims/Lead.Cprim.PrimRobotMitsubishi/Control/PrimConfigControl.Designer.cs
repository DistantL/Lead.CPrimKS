namespace Lead.CPrim.PrimRobotMitsubishi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimConfigControl));
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbConnState = new System.Windows.Forms.TextBox();
            this.tbRunState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrimName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.axMelfaRxM1 = new AxMELFARXMLib.AxMelfaRxM();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRobotId = new System.Windows.Forms.ComboBox();
            this.textBMain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxVR = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnDisEnable = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbIndex1 = new System.Windows.Forms.TextBox();
            this.btnWriteOut = new System.Windows.Forms.Button();
            this.tbValue1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnReadIn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbIndex2 = new System.Windows.Forms.TextBox();
            this.btnWriteInt = new System.Windows.Forms.Button();
            this.btnReadFloat = new System.Windows.Forms.Button();
            this.btnReadInt = new System.Windows.Forms.Button();
            this.tbValue2 = new System.Windows.Forms.TextBox();
            this.btnWriteFloat = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbPos = new System.Windows.Forms.TextBox();
            this.btnReadPos = new System.Windows.Forms.Button();
            this.itemRowCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPasteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMelfaRxM1)).BeginInit();
            this.groupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.lbTitle.Size = new System.Drawing.Size(1050, 43);
            this.lbTitle.TabIndex = 24;
            this.lbTitle.Text = "Robot Inovance Config";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel1.Size = new System.Drawing.Size(1050, 44);
            this.panel1.TabIndex = 25;
            // 
            // tbConnState
            // 
            this.tbConnState.BackColor = System.Drawing.Color.Khaki;
            this.tbConnState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConnState.Location = new System.Drawing.Point(628, 0);
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
            this.tbRunState.Location = new System.Drawing.Point(839, 0);
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
            this.label1.Size = new System.Drawing.Size(200, 44);
            this.label1.TabIndex = 12;
            this.label1.Text = "RobotInovance Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPrimName
            // 
            this.tbPrimName.BackColor = System.Drawing.Color.OldLace;
            this.tbPrimName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPrimName.Location = new System.Drawing.Point(202, 3);
            this.tbPrimName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPrimName.Multiline = true;
            this.tbPrimName.Name = "tbPrimName";
            this.tbPrimName.Size = new System.Drawing.Size(184, 39);
            this.tbPrimName.TabIndex = 13;
            this.tbPrimName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1050, 507);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1042, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "配置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.axMelfaRxM1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbRobotId);
            this.groupBox2.Controls.Add(this.textBMain);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxVR);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1036, 160);
            this.groupBox2.TabIndex = 145;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通讯配置";
            // 
            // axMelfaRxM1
            // 
            this.axMelfaRxM1.Enabled = true;
            this.axMelfaRxM1.Location = new System.Drawing.Point(881, 60);
            this.axMelfaRxM1.Name = "axMelfaRxM1";
            this.axMelfaRxM1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMelfaRxM1.OcxState")));
            this.axMelfaRxM1.Size = new System.Drawing.Size(100, 50);
            this.axMelfaRxM1.TabIndex = 151;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(515, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 150;
            this.label7.Text = "Main函数名称：";
            // 
            // cmbRobotId
            // 
            this.cmbRobotId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRobotId.FormattingEnabled = true;
            this.cmbRobotId.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cmbRobotId.Location = new System.Drawing.Point(142, 72);
            this.cmbRobotId.Name = "cmbRobotId";
            this.cmbRobotId.Size = new System.Drawing.Size(58, 30);
            this.cmbRobotId.TabIndex = 135;
            this.cmbRobotId.SelectedIndexChanged += new System.EventHandler(this.cmbRobotId_SelectedIndexChanged);
            // 
            // textBMain
            // 
            this.textBMain.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBMain.Location = new System.Drawing.Point(652, 74);
            this.textBMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBMain.Name = "textBMain";
            this.textBMain.Size = new System.Drawing.Size(150, 27);
            this.textBMain.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(41, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 124;
            this.label4.Text = "机器人ID：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(217, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 148;
            this.label6.Text = "全局变量名称：";
            // 
            // textBoxVR
            // 
            this.textBoxVR.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxVR.Location = new System.Drawing.Point(348, 74);
            this.textBoxVR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxVR.Name = "textBoxVR";
            this.textBoxVR.Size = new System.Drawing.Size(150, 27);
            this.textBoxVR.TabIndex = 147;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnApply);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(501, 275);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(334, 84);
            this.groupBox.TabIndex = 126;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "EXE";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Location = new System.Drawing.Point(146, 28);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(74, 41);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(230, 28);
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
            this.btnRun.Location = new System.Drawing.Point(76, 28);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(60, 41);
            this.btnRun.TabIndex = 105;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
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
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1042, 477);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "调试";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1042, 477);
            this.tableLayoutPanel1.TabIndex = 144;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEnable);
            this.panel2.Controls.Add(this.btnMain);
            this.panel2.Controls.Add(this.btnDisEnable);
            this.panel2.Controls.Add(this.btnPause);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1036, 113);
            this.panel2.TabIndex = 0;
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(49, 42);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(107, 37);
            this.btnEnable.TabIndex = 0;
            this.btnEnable.Text = "使能";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnMain
            // 
            this.btnMain.Location = new System.Drawing.Point(311, 42);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(107, 37);
            this.btnMain.TabIndex = 137;
            this.btnMain.Text = "执行main";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnDisEnable
            // 
            this.btnDisEnable.Location = new System.Drawing.Point(180, 42);
            this.btnDisEnable.Name = "btnDisEnable";
            this.btnDisEnable.Size = new System.Drawing.Size(107, 37);
            this.btnDisEnable.TabIndex = 1;
            this.btnDisEnable.Text = "使能断";
            this.btnDisEnable.UseVisualStyleBackColor = true;
            this.btnDisEnable.Click += new System.EventHandler(this.btnDisEnable_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(442, 42);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(107, 37);
            this.btnPause.TabIndex = 138;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbIndex1);
            this.panel3.Controls.Add(this.btnWriteOut);
            this.panel3.Controls.Add(this.tbValue1);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.btnReadIn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1036, 113);
            this.panel3.TabIndex = 1;
            // 
            // tbIndex1
            // 
            this.tbIndex1.Location = new System.Drawing.Point(311, 27);
            this.tbIndex1.Name = "tbIndex1";
            this.tbIndex1.Size = new System.Drawing.Size(100, 23);
            this.tbIndex1.TabIndex = 126;
            // 
            // btnWriteOut
            // 
            this.btnWriteOut.Location = new System.Drawing.Point(180, 20);
            this.btnWriteOut.Name = "btnWriteOut";
            this.btnWriteOut.Size = new System.Drawing.Size(107, 37);
            this.btnWriteOut.TabIndex = 128;
            this.btnWriteOut.Text = "写 Q";
            this.btnWriteOut.UseVisualStyleBackColor = true;
            this.btnWriteOut.Click += new System.EventHandler(this.btnWriteOut_Click);
            // 
            // tbValue1
            // 
            this.tbValue1.Location = new System.Drawing.Point(311, 65);
            this.tbValue1.Name = "tbValue1";
            this.tbValue1.Size = new System.Drawing.Size(100, 23);
            this.tbValue1.TabIndex = 127;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 133;
            this.label8.Text = "index";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(442, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 17);
            this.label9.TabIndex = 134;
            this.label9.Text = "value";
            // 
            // btnReadIn
            // 
            this.btnReadIn.Location = new System.Drawing.Point(49, 20);
            this.btnReadIn.Name = "btnReadIn";
            this.btnReadIn.Size = new System.Drawing.Size(107, 37);
            this.btnReadIn.TabIndex = 125;
            this.btnReadIn.Text = "读  I";
            this.btnReadIn.UseVisualStyleBackColor = true;
            this.btnReadIn.Click += new System.EventHandler(this.btnReadIn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbIndex2);
            this.panel4.Controls.Add(this.btnWriteInt);
            this.panel4.Controls.Add(this.btnReadFloat);
            this.panel4.Controls.Add(this.btnReadInt);
            this.panel4.Controls.Add(this.tbValue2);
            this.panel4.Controls.Add(this.btnWriteFloat);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 241);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1036, 113);
            this.panel4.TabIndex = 2;
            // 
            // tbIndex2
            // 
            this.tbIndex2.Location = new System.Drawing.Point(595, 33);
            this.tbIndex2.Name = "tbIndex2";
            this.tbIndex2.Size = new System.Drawing.Size(100, 23);
            this.tbIndex2.TabIndex = 130;
            // 
            // btnWriteInt
            // 
            this.btnWriteInt.Location = new System.Drawing.Point(442, 26);
            this.btnWriteInt.Name = "btnWriteInt";
            this.btnWriteInt.Size = new System.Drawing.Size(107, 37);
            this.btnWriteInt.TabIndex = 142;
            this.btnWriteInt.Text = "写 INT";
            this.btnWriteInt.UseVisualStyleBackColor = true;
            this.btnWriteInt.Click += new System.EventHandler(this.btnWriteInt_Click);
            // 
            // btnReadFloat
            // 
            this.btnReadFloat.Location = new System.Drawing.Point(49, 26);
            this.btnReadFloat.Name = "btnReadFloat";
            this.btnReadFloat.Size = new System.Drawing.Size(107, 37);
            this.btnReadFloat.TabIndex = 129;
            this.btnReadFloat.Text = "读变量F";
            this.btnReadFloat.UseVisualStyleBackColor = true;
            this.btnReadFloat.Click += new System.EventHandler(this.btnReadFloat_Click);
            // 
            // btnReadInt
            // 
            this.btnReadInt.Location = new System.Drawing.Point(311, 26);
            this.btnReadInt.Name = "btnReadInt";
            this.btnReadInt.Size = new System.Drawing.Size(107, 37);
            this.btnReadInt.TabIndex = 139;
            this.btnReadInt.Text = "读变量INT";
            this.btnReadInt.UseVisualStyleBackColor = true;
            this.btnReadInt.Click += new System.EventHandler(this.btnReadInt_Click);
            // 
            // tbValue2
            // 
            this.tbValue2.Location = new System.Drawing.Point(595, 76);
            this.tbValue2.Name = "tbValue2";
            this.tbValue2.Size = new System.Drawing.Size(100, 23);
            this.tbValue2.TabIndex = 131;
            // 
            // btnWriteFloat
            // 
            this.btnWriteFloat.Location = new System.Drawing.Point(180, 26);
            this.btnWriteFloat.Name = "btnWriteFloat";
            this.btnWriteFloat.Size = new System.Drawing.Size(107, 37);
            this.btnWriteFloat.TabIndex = 132;
            this.btnWriteFloat.Text = "写 Float";
            this.btnWriteFloat.UseVisualStyleBackColor = true;
            this.btnWriteFloat.Click += new System.EventHandler(this.btnWriteFloat_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(729, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 136;
            this.label10.Text = "value";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(729, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 17);
            this.label11.TabIndex = 135;
            this.label11.Text = "index";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbPos);
            this.panel5.Controls.Add(this.btnReadPos);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 360);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1036, 114);
            this.panel5.TabIndex = 3;
            // 
            // tbPos
            // 
            this.tbPos.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPos.Location = new System.Drawing.Point(180, 56);
            this.tbPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPos.Name = "tbPos";
            this.tbPos.Size = new System.Drawing.Size(425, 27);
            this.tbPos.TabIndex = 124;
            // 
            // btnReadPos
            // 
            this.btnReadPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReadPos.Location = new System.Drawing.Point(49, 46);
            this.btnReadPos.Name = "btnReadPos";
            this.btnReadPos.Size = new System.Drawing.Size(107, 37);
            this.btnReadPos.TabIndex = 2;
            this.btnReadPos.Text = "读位置";
            this.btnReadPos.UseVisualStyleBackColor = true;
            this.btnReadPos.Click += new System.EventHandler(this.btnReadPos_Click);
            // 
            // itemRowCopy
            // 
            this.itemRowCopy.Name = "itemRowCopy";
            this.itemRowCopy.Size = new System.Drawing.Size(32, 19);
            // 
            // itemPasteRow
            // 
            this.itemPasteRow.Name = "itemPasteRow";
            this.itemPasteRow.Size = new System.Drawing.Size(32, 19);
            // 
            // PrimConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrimConfigControl";
            this.Size = new System.Drawing.Size(1050, 594);
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMelfaRxM1)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbConnState;
        private System.Windows.Forms.TextBox tbRunState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrimName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem itemRowCopy;
        private System.Windows.Forms.ToolStripMenuItem itemPasteRow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRobotId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBMain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxVR;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnWriteInt;
        private System.Windows.Forms.Button btnReadInt;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnDisEnable;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnReadPos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnReadIn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbIndex1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbValue1;
        private System.Windows.Forms.Button btnWriteFloat;
        private System.Windows.Forms.Button btnWriteOut;
        private System.Windows.Forms.TextBox tbValue2;
        private System.Windows.Forms.Button btnReadFloat;
        private System.Windows.Forms.TextBox tbIndex2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private AxMELFARXMLib.AxMelfaRxM axMelfaRxM1;
    }
}
