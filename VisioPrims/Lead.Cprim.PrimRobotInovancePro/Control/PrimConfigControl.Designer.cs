using Sunny.UI;

namespace Lead.CPrim.PrimRobotInovancePro
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
            this.cmbRobotId = new System.Windows.Forms.ComboBox();
            this.txtPassward = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.itemRowCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPasteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtConnState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtRunState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.gbExe = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lineConfig = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.lblIp = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblPort = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblRobotId = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblPassWord = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lineDebug = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.numVel = new Sunny.UI.UIDoubleUpDown();
            this.lblVelocity = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblPosition = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.chkType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.txtAdress = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtResult = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnRead = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnWrite = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lblType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblAddress = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblResult = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.chkMonitor = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.lblState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cmbVer = new System.Windows.Forms.ComboBox();
            this.lblVer = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnEnable = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnEnableSta = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.tmrEnableSta = new System.Windows.Forms.Timer(this.components);
            this.tlpTitle.SuspendLayout();
            this.gbExe.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRobotId
            // 
            this.cmbRobotId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRobotId.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmbRobotId.FormattingEnabled = true;
            this.cmbRobotId.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cmbRobotId.Location = new System.Drawing.Point(320, 118);
            this.cmbRobotId.Name = "cmbRobotId";
            this.cmbRobotId.Size = new System.Drawing.Size(150, 35);
            this.cmbRobotId.TabIndex = 135;
            // 
            // txtPassward
            // 
            this.txtPassward.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPassward.Location = new System.Drawing.Point(475, 119);
            this.txtPassward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassward.Name = "txtPassward";
            this.txtPassward.Size = new System.Drawing.Size(150, 34);
            this.txtPassward.TabIndex = 120;
            // 
            // txtIp
            // 
            this.txtIp.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtIp.Location = new System.Drawing.Point(10, 119);
            this.txtIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(150, 34);
            this.txtIp.TabIndex = 123;
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtPort.Location = new System.Drawing.Point(165, 119);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(150, 34);
            this.txtPort.TabIndex = 120;
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
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 5;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTitle.Controls.Add(this.label1, 0, 0);
            this.tlpTitle.Controls.Add(this.txtName, 1, 0);
            this.tlpTitle.Controls.Add(this.txtConnState, 3, 0);
            this.tlpTitle.Controls.Add(this.txtRunState, 4, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(800, 44);
            this.tlpTitle.TabIndex = 27;
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
            this.label1.Size = new System.Drawing.Size(178, 42);
            this.label1.TabIndex = 12;
            this.label1.Text = "Robot Inovance Pro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(182, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(176, 40);
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
            // gbExe
            // 
            this.gbExe.Controls.Add(this.btnStop);
            this.gbExe.Controls.Add(this.btnRun);
            this.gbExe.Controls.Add(this.btnInit);
            this.gbExe.Controls.Add(this.btnApply);
            this.gbExe.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbExe.Location = new System.Drawing.Point(10, 427);
            this.gbExe.Name = "gbExe";
            this.gbExe.Size = new System.Drawing.Size(500, 70);
            this.gbExe.TabIndex = 146;
            this.gbExe.TabStop = false;
            this.gbExe.Text = "EXE";
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
            // lineConfig
            // 
            this.lineConfig.Cursor = System.Windows.Forms.Cursors.No;
            this.lineConfig.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lineConfig.Location = new System.Drawing.Point(10, 50);
            this.lineConfig.MinimumSize = new System.Drawing.Size(1, 1);
            this.lineConfig.Name = "lineConfig";
            this.lineConfig.Size = new System.Drawing.Size(780, 29);
            this.lineConfig.TabIndex = 147;
            this.lineConfig.Text = "Config";
            this.lineConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lineConfig.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.BackColor = System.Drawing.Color.Transparent;
            this.lblIp.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblIp.Location = new System.Drawing.Point(10, 90);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(30, 27);
            this.lblIp.TabIndex = 148;
            this.lblIp.Text = "IP";
            this.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblPort.Location = new System.Drawing.Point(165, 90);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(52, 27);
            this.lblPort.TabIndex = 148;
            this.lblPort.Text = "Port";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPort.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblRobotId
            // 
            this.lblRobotId.AutoSize = true;
            this.lblRobotId.BackColor = System.Drawing.Color.Transparent;
            this.lblRobotId.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblRobotId.Location = new System.Drawing.Point(320, 90);
            this.lblRobotId.Name = "lblRobotId";
            this.lblRobotId.Size = new System.Drawing.Size(33, 27);
            this.lblRobotId.TabIndex = 148;
            this.lblRobotId.Text = "ID";
            this.lblRobotId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRobotId.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.BackColor = System.Drawing.Color.Transparent;
            this.lblPassWord.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblPassWord.Location = new System.Drawing.Point(475, 90);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(107, 27);
            this.lblPassWord.TabIndex = 148;
            this.lblPassWord.Text = "PassWord";
            this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPassWord.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lineDebug
            // 
            this.lineDebug.BackColor = System.Drawing.Color.Transparent;
            this.lineDebug.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lineDebug.Location = new System.Drawing.Point(10, 170);
            this.lineDebug.MinimumSize = new System.Drawing.Size(1, 1);
            this.lineDebug.Name = "lineDebug";
            this.lineDebug.Size = new System.Drawing.Size(780, 29);
            this.lineDebug.TabIndex = 147;
            this.lineDebug.Text = "Debug";
            this.lineDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lineDebug.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // numVel
            // 
            this.numVel.Decimal = 0;
            this.numVel.DecimalPlaces = 0;
            this.numVel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.numVel.HasMaximum = true;
            this.numVel.HasMinimum = true;
            this.numVel.Location = new System.Drawing.Point(10, 240);
            this.numVel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numVel.Maximum = 100D;
            this.numVel.MaximumEnabled = true;
            this.numVel.Minimum = 1D;
            this.numVel.MinimumEnabled = true;
            this.numVel.MinimumSize = new System.Drawing.Size(100, 0);
            this.numVel.Name = "numVel";
            this.numVel.ShowText = false;
            this.numVel.Size = new System.Drawing.Size(150, 25);
            this.numVel.Step = 5D;
            this.numVel.TabIndex = 152;
            this.numVel.Text = null;
            this.numVel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.numVel.Value = 20D;
            this.numVel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblVelocity
            // 
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblVelocity.Location = new System.Drawing.Point(10, 210);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(88, 27);
            this.lblVelocity.TabIndex = 148;
            this.lblVelocity.Text = "Velocity";
            this.lblVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVelocity.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblVersion.Location = new System.Drawing.Point(670, 472);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 27);
            this.lblVersion.TabIndex = 154;
            this.lblVersion.Text = "Ver";
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_DoubleClick);
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblPosition.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPosition.Location = new System.Drawing.Point(110, 387);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(420, 26);
            this.lblPosition.TabIndex = 170;
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPosition.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chkType
            // 
            this.chkType.DataSource = null;
            this.chkType.FillColor = System.Drawing.Color.White;
            this.chkType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkType.Items.AddRange(new object[] {
            "B",
            "R",
            "D"});
            this.chkType.Location = new System.Drawing.Point(10, 320);
            this.chkType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkType.MinimumSize = new System.Drawing.Size(63, 0);
            this.chkType.Name = "chkType";
            this.chkType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.chkType.Size = new System.Drawing.Size(63, 31);
            this.chkType.TabIndex = 171;
            this.chkType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAdress
            // 
            this.txtAdress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAdress.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtAdress.Location = new System.Drawing.Point(80, 321);
            this.txtAdress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdress.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.ShowText = false;
            this.txtAdress.Size = new System.Drawing.Size(80, 29);
            this.txtAdress.TabIndex = 172;
            this.txtAdress.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtResult
            // 
            this.txtResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResult.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtResult.Location = new System.Drawing.Point(170, 321);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtResult.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtResult.Name = "txtResult";
            this.txtResult.ShowText = false;
            this.txtResult.Size = new System.Drawing.Size(80, 29);
            this.txtResult.TabIndex = 172;
            this.txtResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnRead
            // 
            this.btnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRead.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRead.Location = new System.Drawing.Point(260, 318);
            this.btnRead.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(80, 35);
            this.btnRead.TabIndex = 173;
            this.btnRead.Text = "Read";
            this.btnRead.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRead.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWrite.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnWrite.Location = new System.Drawing.Point(350, 318);
            this.btnWrite.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(80, 35);
            this.btnWrite.TabIndex = 173;
            this.btnWrite.Text = "Write";
            this.btnWrite.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWrite.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnWrite.Click += new System.EventHandler(this.Write_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblType.Location = new System.Drawing.Point(10, 290);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(58, 27);
            this.lblType.TabIndex = 148;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblAddress.Location = new System.Drawing.Point(80, 290);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(89, 27);
            this.lblAddress.TabIndex = 148;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddress.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblResult.Location = new System.Drawing.Point(170, 290);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(69, 27);
            this.lblResult.TabIndex = 148;
            this.lblResult.Text = "Result";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tmr
            // 
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // chkMonitor
            // 
            this.chkMonitor.BackColor = System.Drawing.Color.Transparent;
            this.chkMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMonitor.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkMonitor.Location = new System.Drawing.Point(10, 390);
            this.chkMonitor.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkMonitor.Name = "chkMonitor";
            this.chkMonitor.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkMonitor.Size = new System.Drawing.Size(76, 21);
            this.chkMonitor.TabIndex = 174;
            this.chkMonitor.Text = "Monitor";
            this.chkMonitor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.chkMonitor.CheckedChanged += new System.EventHandler(this.chkMonitor_CheckedChanged);
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.Location = new System.Drawing.Point(550, 387);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(121, 26);
            this.lblState.TabIndex = 170;
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmbVer
            // 
            this.cmbVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVer.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmbVer.FormattingEnabled = true;
            this.cmbVer.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cmbVer.Location = new System.Drawing.Point(630, 118);
            this.cmbVer.Name = "cmbVer";
            this.cmbVer.Size = new System.Drawing.Size(150, 35);
            this.cmbVer.TabIndex = 135;
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.BackColor = System.Drawing.Color.Transparent;
            this.lblVer.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblVer.Location = new System.Drawing.Point(630, 90);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(45, 27);
            this.lblVer.TabIndex = 148;
            this.lblVer.Text = "Ver";
            this.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVer.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnEnable
            // 
            this.btnEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnable.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnEnable.Location = new System.Drawing.Point(440, 318);
            this.btnEnable.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(80, 35);
            this.btnEnable.TabIndex = 175;
            this.btnEnable.Text = "Enable";
            this.btnEnable.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnEnableSta
            // 
            this.btnEnableSta.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEnableSta.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnEnableSta.Location = new System.Drawing.Point(530, 318);
            this.btnEnableSta.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEnableSta.Name = "btnEnableSta";
            this.btnEnableSta.Size = new System.Drawing.Size(90, 35);
            this.btnEnableSta.TabIndex = 176;
            this.btnEnableSta.TabStop = false;
            this.btnEnableSta.Text = "Unknown";
            this.btnEnableSta.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnableSta.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEnableSta.Click += new System.EventHandler(this.btnEnableSta_Click);
            // 
            // tmrEnableSta
            // 
            this.tmrEnableSta.Interval = 1000;
            this.tmrEnableSta.Tick += new System.EventHandler(this.tmrEnableSta_Tick);
            // 
            // PrimConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnEnableSta);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.chkMonitor);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.chkType);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.numVel);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblVelocity);
            this.Controls.Add(this.lblRobotId);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.cmbVer);
            this.Controls.Add(this.cmbRobotId);
            this.Controls.Add(this.lineDebug);
            this.Controls.Add(this.lineConfig);
            this.Controls.Add(this.txtPassward);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.gbExe);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrimConfigControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.tlpTitle.ResumeLayout(false);
            this.gbExe.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem itemRowCopy;
        private System.Windows.Forms.ToolStripMenuItem itemPasteRow;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtPassward;
        private System.Windows.Forms.ComboBox cmbRobotId;
        private CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpTitle;
        private System.Windows.Forms.Label label1;
        private CPrim.ProxyTools.SunnyUI.Controls.UITextBox txtName;
        private CPrim.ProxyTools.SunnyUI.Controls.UITextBox txtConnState;
        private CPrim.ProxyTools.SunnyUI.Controls.UITextBox txtRunState;
        private System.Windows.Forms.GroupBox gbExe;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnApply;
        private CPrim.ProxyTools.SunnyUI.Controls.UILine lineConfig;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblIp;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblPort;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblRobotId;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblPassWord;
        private CPrim.ProxyTools.SunnyUI.Controls.UILine lineDebug;
        private UIDoubleUpDown numVel;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblVelocity;
        private System.Windows.Forms.Label lblVersion;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblPosition;
        private CPrim.ProxyTools.SunnyUI.Controls.UIComboBox chkType;
        private CPrim.ProxyTools.SunnyUI.Controls.UITextBox txtAdress;
        private CPrim.ProxyTools.SunnyUI.Controls.UITextBox txtResult;
        private CPrim.ProxyTools.SunnyUI.Controls.UIButton btnRead;
        private CPrim.ProxyTools.SunnyUI.Controls.UIButton btnWrite;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblType;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblAddress;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblResult;
        private System.Windows.Forms.Timer tmr;
        private CPrim.ProxyTools.SunnyUI.Controls.UICheckBox chkMonitor;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblState;
        private System.Windows.Forms.ComboBox cmbVer;
        private CPrim.ProxyTools.SunnyUI.Controls.UILabel lblVer;
        private ProxyTools.SunnyUI.Controls.UIButton btnEnable;
        private ProxyTools.SunnyUI.Controls.UIButton btnEnableSta;
        private System.Windows.Forms.Timer tmrEnableSta;
    }
}
