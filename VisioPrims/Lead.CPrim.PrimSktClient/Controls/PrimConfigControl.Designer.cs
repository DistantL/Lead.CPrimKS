using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.PrimSktClient
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.txtRunState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtConnState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cBoxMode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbNotifyMode = new System.Windows.Forms.ComboBox();
            this.cbLogEnable = new System.Windows.Forms.CheckBox();
            this.chkHeart = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbHeartTime = new System.Windows.Forms.TextBox();
            this.tbSendQueueCnt = new System.Windows.Forms.TextBox();
            this.tbNetName = new System.Windows.Forms.TextBox();
            this.tbReConnCnt = new System.Windows.Forms.TextBox();
            this.tbHeartInfo = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cBoxDebug = new System.Windows.Forms.CheckBox();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.btnClearReceived = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tBoxMsg = new System.Windows.Forms.TextBox();
            this.tbRevInfo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 44);
            this.panel1.TabIndex = 24;
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 5;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpTitle.Controls.Add(this.txtRunState, 4, 0);
            this.tlpTitle.Controls.Add(this.txtName, 1, 0);
            this.tlpTitle.Controls.Add(this.txtConnState, 3, 0);
            this.tlpTitle.Controls.Add(this.label1, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(841, 44);
            this.tlpTitle.TabIndex = 0;
            this.tlpTitle.TagString = null;
            // 
            // txtRunState
            // 
            this.txtRunState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRunState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRunState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRunState.Location = new System.Drawing.Point(713, 2);
            this.txtRunState.Margin = new System.Windows.Forms.Padding(2);
            this.txtRunState.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtRunState.Name = "txtRunState";
            this.txtRunState.ShowText = false;
            this.txtRunState.Size = new System.Drawing.Size(126, 40);
            this.txtRunState.TabIndex = 135;
            this.txtRunState.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtRunState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(132, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(126, 40);
            this.txtName.TabIndex = 135;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtConnState
            // 
            this.txtConnState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConnState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConnState.Location = new System.Drawing.Point(583, 2);
            this.txtConnState.Margin = new System.Windows.Forms.Padding(2);
            this.txtConnState.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtConnState.Name = "txtConnState";
            this.txtConnState.ShowText = false;
            this.txtConnState.Size = new System.Drawing.Size(126, 40);
            this.txtConnState.TabIndex = 135;
            this.txtConnState.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtConnState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 40);
            this.label1.TabIndex = 12;
            this.label1.Text = "Client Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(841, 43);
            this.lbTitle.TabIndex = 23;
            this.lbTitle.Text = "Socket Client Config";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 87);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(841, 375);
            this.tabMain.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.tabPage1.Controls.Add(this.cmbEncoding);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.cBoxMode);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.cmbNotifyMode);
            this.tabPage1.Controls.Add(this.cbLogEnable);
            this.tabPage1.Controls.Add(this.chkHeart);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbPort);
            this.tabPage1.Controls.Add(this.tbHeartTime);
            this.tabPage1.Controls.Add(this.tbSendQueueCnt);
            this.tabPage1.Controls.Add(this.tbNetName);
            this.tabPage1.Controls.Add(this.tbReConnCnt);
            this.tabPage1.Controls.Add(this.tbHeartInfo);
            this.tabPage1.Controls.Add(this.tbIP);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config";
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Items.AddRange(new object[] {
            "UTF8",
            "ASCII",
            "Unicode",
            "GB2312",
            "HEX"});
            this.cmbEncoding.Location = new System.Drawing.Point(143, 266);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(97, 25);
            this.cmbEncoding.TabIndex = 134;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(139, 235);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 20);
            this.label15.TabIndex = 133;
            this.label15.Text = "编码类型：";
            // 
            // cBoxMode
            // 
            this.cBoxMode.FormattingEnabled = true;
            this.cBoxMode.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.cBoxMode.Location = new System.Drawing.Point(23, 266);
            this.cBoxMode.Name = "cBoxMode";
            this.cBoxMode.Size = new System.Drawing.Size(97, 25);
            this.cBoxMode.TabIndex = 132;
            this.cBoxMode.Text = "TCP";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(18, 235);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 20);
            this.label14.TabIndex = 131;
            this.label14.Text = "Mode:";
            // 
            // cmbNotifyMode
            // 
            this.cmbNotifyMode.FormattingEnabled = true;
            this.cmbNotifyMode.Items.AddRange(new object[] {
            "Event",
            "Queue"});
            this.cmbNotifyMode.Location = new System.Drawing.Point(278, 192);
            this.cmbNotifyMode.Name = "cmbNotifyMode";
            this.cmbNotifyMode.Size = new System.Drawing.Size(121, 25);
            this.cmbNotifyMode.TabIndex = 129;
            this.cmbNotifyMode.SelectedIndexChanged += new System.EventHandler(this.cBoxNotifyMode_SelectedIndexChanged);
            // 
            // cbLogEnable
            // 
            this.cbLogEnable.AutoSize = true;
            this.cbLogEnable.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLogEnable.Location = new System.Drawing.Point(261, 266);
            this.cbLogEnable.Name = "cbLogEnable";
            this.cbLogEnable.Size = new System.Drawing.Size(88, 24);
            this.cbLogEnable.TabIndex = 128;
            this.cbLogEnable.Text = "启用日志";
            this.cbLogEnable.UseVisualStyleBackColor = true;
            this.cbLogEnable.CheckedChanged += new System.EventHandler(this.cBoxHeart_CheckedChanged);
            // 
            // chkHeart
            // 
            this.chkHeart.AutoSize = true;
            this.chkHeart.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeart.Location = new System.Drawing.Point(399, 113);
            this.chkHeart.Name = "chkHeart";
            this.chkHeart.Size = new System.Drawing.Size(117, 24);
            this.chkHeart.TabIndex = 128;
            this.chkHeart.Text = "HeartEnable";
            this.chkHeart.UseVisualStyleBackColor = true;
            this.chkHeart.CheckedChanged += new System.EventHandler(this.cBoxHeart_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Controls.Add(this.btnApply);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(377, 230);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(437, 84);
            this.groupBox.TabIndex = 126;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "EXE";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Location = new System.Drawing.Point(220, 28);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 41);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Location = new System.Drawing.Point(113, 28);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 41);
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
            this.btnInit.Size = new System.Drawing.Size(100, 41);
            this.btnInit.TabIndex = 105;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(327, 28);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 41);
            this.btnApply.TabIndex = 127;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(273, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 122;
            this.label3.Text = "Port:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(344, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 20);
            this.label8.TabIndex = 125;
            this.label8.Text = "ms";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(273, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 125;
            this.label7.Text = "HeartCycle:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(273, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 20);
            this.label10.TabIndex = 125;
            this.label10.Text = "NotifyMode:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(643, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 20);
            this.label11.TabIndex = 125;
            this.label11.Text = "SendQueueCnt:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(643, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 20);
            this.label13.TabIndex = 125;
            this.label13.Text = "NetName:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(18, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 20);
            this.label9.TabIndex = 125;
            this.label9.Text = "ReConnect Cnt:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(18, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 125;
            this.label6.Text = "HeartInfo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 125;
            this.label2.Text = "IP:";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPort.Location = new System.Drawing.Point(278, 41);
            this.tbPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 27);
            this.tbPort.TabIndex = 120;
            this.tbPort.TextChanged += new System.EventHandler(this.tBoxPort_TextChanged);
            // 
            // tbHeartTime
            // 
            this.tbHeartTime.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHeartTime.Location = new System.Drawing.Point(278, 112);
            this.tbHeartTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbHeartTime.Name = "tbHeartTime";
            this.tbHeartTime.Size = new System.Drawing.Size(64, 27);
            this.tbHeartTime.TabIndex = 121;
            this.tbHeartTime.TextChanged += new System.EventHandler(this.tBoxHeartTime_TextChanged);
            // 
            // tbSendQueueCnt
            // 
            this.tbSendQueueCnt.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSendQueueCnt.Location = new System.Drawing.Point(643, 41);
            this.tbSendQueueCnt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSendQueueCnt.Name = "tbSendQueueCnt";
            this.tbSendQueueCnt.Size = new System.Drawing.Size(163, 27);
            this.tbSendQueueCnt.TabIndex = 121;
            this.tbSendQueueCnt.TextChanged += new System.EventHandler(this.tBoxSendQueueCnt_TextChanged);
            // 
            // tbNetName
            // 
            this.tbNetName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbNetName.Location = new System.Drawing.Point(643, 191);
            this.tbNetName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbNetName.Name = "tbNetName";
            this.tbNetName.Size = new System.Drawing.Size(163, 27);
            this.tbNetName.TabIndex = 121;
            this.tbNetName.TextChanged += new System.EventHandler(this.tBoxNetName_TextChanged);
            // 
            // tbReConnCnt
            // 
            this.tbReConnCnt.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbReConnCnt.Location = new System.Drawing.Point(23, 191);
            this.tbReConnCnt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbReConnCnt.Name = "tbReConnCnt";
            this.tbReConnCnt.Size = new System.Drawing.Size(163, 27);
            this.tbReConnCnt.TabIndex = 121;
            this.tbReConnCnt.TextChanged += new System.EventHandler(this.tBoxReConnCnt_TextChanged);
            // 
            // tbHeartInfo
            // 
            this.tbHeartInfo.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHeartInfo.Location = new System.Drawing.Point(23, 112);
            this.tbHeartInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbHeartInfo.Name = "tbHeartInfo";
            this.tbHeartInfo.Size = new System.Drawing.Size(163, 27);
            this.tbHeartInfo.TabIndex = 121;
            this.tbHeartInfo.TextChanged += new System.EventHandler(this.tBoxHeartInfo_TextChanged);
            // 
            // tbIP
            // 
            this.tbIP.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbIP.Location = new System.Drawing.Point(23, 41);
            this.tbIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(163, 27);
            this.tbIP.TabIndex = 121;
            this.tbIP.TextChanged += new System.EventHandler(this.tBoxIP_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.tabPage2.Controls.Add(this.cBoxDebug);
            this.tabPage2.Controls.Add(this.btnClearSend);
            this.tabPage2.Controls.Add(this.btnClearReceived);
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.tBoxMsg);
            this.tabPage2.Controls.Add(this.tbRevInfo);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            // 
            // cBoxDebug
            // 
            this.cBoxDebug.AutoSize = true;
            this.cBoxDebug.Location = new System.Drawing.Point(408, 251);
            this.cBoxDebug.Name = "cBoxDebug";
            this.cBoxDebug.Size = new System.Drawing.Size(105, 21);
            this.cBoxDebug.TabIndex = 136;
            this.cBoxDebug.Text = "DebugEnable";
            this.cBoxDebug.UseVisualStyleBackColor = true;
            this.cBoxDebug.CheckedChanged += new System.EventHandler(this.cBoxDebug_CheckedChanged);
            // 
            // btnClearSend
            // 
            this.btnClearSend.Location = new System.Drawing.Point(537, 168);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(119, 37);
            this.btnClearSend.TabIndex = 135;
            this.btnClearSend.Text = "清除发送";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // btnClearReceived
            // 
            this.btnClearReceived.Location = new System.Drawing.Point(392, 168);
            this.btnClearReceived.Name = "btnClearReceived";
            this.btnClearReceived.Size = new System.Drawing.Size(119, 37);
            this.btnClearReceived.TabIndex = 135;
            this.btnClearReceived.Text = "清除接收";
            this.btnClearReceived.UseVisualStyleBackColor = true;
            this.btnClearReceived.Click += new System.EventHandler(this.btnClearReceived_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(682, 168);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(119, 37);
            this.btnSend.TabIndex = 135;
            this.btnSend.Text = "Send Msg";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tBoxMsg
            // 
            this.tBoxMsg.Location = new System.Drawing.Point(392, 60);
            this.tBoxMsg.Multiline = true;
            this.tBoxMsg.Name = "tBoxMsg";
            this.tBoxMsg.Size = new System.Drawing.Size(409, 93);
            this.tBoxMsg.TabIndex = 134;
            // 
            // tbRevInfo
            // 
            this.tbRevInfo.Location = new System.Drawing.Point(11, 60);
            this.tbRevInfo.Multiline = true;
            this.tbRevInfo.Name = "tbRevInfo";
            this.tbRevInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRevInfo.Size = new System.Drawing.Size(376, 227);
            this.tbRevInfo.TabIndex = 133;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 131;
            this.label5.Text = "Data Rev:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(387, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 132;
            this.label4.Text = "Data Send:";
            // 
            // PrimConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrimConfigControl";
            this.Size = new System.Drawing.Size(841, 462);
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.panel1.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tBoxMsg;
        private System.Windows.Forms.TextBox tbRevInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbHeartTime;
        private System.Windows.Forms.TextBox tbHeartInfo;
        private System.Windows.Forms.CheckBox chkHeart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbReConnCnt;
        private System.Windows.Forms.ComboBox cmbNotifyMode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSendQueueCnt;
        private System.Windows.Forms.CheckBox cBoxDebug;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbNetName;
        private System.Windows.Forms.ComboBox cBoxMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbLogEnable;
        private UITableLayoutPanel tlpTitle;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Button btnClearReceived;
        private UITextBox txtRunState;
        private UITextBox txtName;
        private UITextBox txtConnState;
    }
}
