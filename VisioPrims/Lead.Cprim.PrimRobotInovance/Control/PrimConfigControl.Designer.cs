namespace Lead.Cprim.PrimRobotInovance
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbConnState = new System.Windows.Forms.TextBox();
            this.tbRunState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrimName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbRobotId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPassward = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRobotIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.itemRowCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPasteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox.SuspendLayout();
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
            this.lbTitle.Size = new System.Drawing.Size(810, 43);
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
            this.panel1.Size = new System.Drawing.Size(810, 44);
            this.panel1.TabIndex = 25;
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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(810, 429);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnApply);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbRobotId);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbPassward);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(18, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 81);
            this.groupBox2.TabIndex = 145;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登录设置";
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
            this.cmbRobotId.Location = new System.Drawing.Point(83, 30);
            this.cmbRobotId.Name = "cmbRobotId";
            this.cmbRobotId.Size = new System.Drawing.Size(58, 30);
            this.cmbRobotId.TabIndex = 135;
            this.cmbRobotId.SelectedIndexChanged += new System.EventHandler(this.cmbRobotId_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 124;
            this.label4.Text = "机器人ID：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(163, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 122;
            this.label5.Text = "管理员密码：";
            // 
            // tbPassward
            // 
            this.tbPassward.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPassward.Location = new System.Drawing.Point(268, 33);
            this.tbPassward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPassward.Name = "tbPassward";
            this.tbPassward.Size = new System.Drawing.Size(96, 27);
            this.tbPassward.TabIndex = 120;
            this.tbPassward.TextChanged += new System.EventHandler(this.tbPassward_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbRobotIp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(18, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 81);
            this.groupBox1.TabIndex = 144;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 124;
            this.label2.Text = "IP：";
            // 
            // tbRobotIp
            // 
            this.tbRobotIp.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRobotIp.Location = new System.Drawing.Point(57, 33);
            this.tbRobotIp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRobotIp.Name = "tbRobotIp";
            this.tbRobotIp.Size = new System.Drawing.Size(169, 27);
            this.tbRobotIp.TabIndex = 123;
            this.tbRobotIp.TextChanged += new System.EventHandler(this.tbRobotIp_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(240, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 122;
            this.label3.Text = "端口：";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPort.Location = new System.Drawing.Point(308, 33);
            this.tbPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(56, 27);
            this.tbPort.TabIndex = 120;
            this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(688, 314);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(78, 34);
            this.btnApply.TabIndex = 127;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(462, 283);
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
            this.Size = new System.Drawing.Size(810, 516);
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRobotIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPassward;
        private System.Windows.Forms.ComboBox cmbRobotId;
    }
}
