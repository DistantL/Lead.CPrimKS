namespace Lead.CPrim.PrimSerial
{
    partial class PrimDebugControl
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
            this.cBoxShowTime = new System.Windows.Forms.CheckBox();
            this.cBoxDebug = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tBoxMsg = new System.Windows.Forms.TextBox();
            this.tBoxInfo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBoxConnState = new System.Windows.Forms.TextBox();
            this.tBoxRunState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tTaskBoxName = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxShowTime
            // 
            this.cBoxShowTime.AutoSize = true;
            this.cBoxShowTime.Checked = true;
            this.cBoxShowTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxShowTime.Location = new System.Drawing.Point(524, 232);
            this.cBoxShowTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxShowTime.Name = "cBoxShowTime";
            this.cBoxShowTime.Size = new System.Drawing.Size(125, 19);
            this.cBoxShowTime.TabIndex = 138;
            this.cBoxShowTime.Text = "Time Display";
            this.cBoxShowTime.UseVisualStyleBackColor = true;
            // 
            // cBoxDebug
            // 
            this.cBoxDebug.AutoSize = true;
            this.cBoxDebug.Location = new System.Drawing.Point(524, 314);
            this.cBoxDebug.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBoxDebug.Name = "cBoxDebug";
            this.cBoxDebug.Size = new System.Drawing.Size(117, 19);
            this.cBoxDebug.TabIndex = 136;
            this.cBoxDebug.Text = "DebugEnable";
            this.cBoxDebug.UseVisualStyleBackColor = true;
            this.cBoxDebug.CheckedChanged += new System.EventHandler(this.cBoxDebug_CheckedChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(909, 210);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(159, 46);
            this.btnSend.TabIndex = 135;
            this.btnSend.Text = "Send Msg";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tBoxMsg
            // 
            this.tBoxMsg.Location = new System.Drawing.Point(523, 75);
            this.tBoxMsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBoxMsg.Multiline = true;
            this.tBoxMsg.Name = "tBoxMsg";
            this.tBoxMsg.Size = new System.Drawing.Size(544, 115);
            this.tBoxMsg.TabIndex = 134;
            // 
            // tBoxInfo
            // 
            this.tBoxInfo.Location = new System.Drawing.Point(15, 75);
            this.tBoxInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBoxInfo.Multiline = true;
            this.tBoxInfo.Name = "tBoxInfo";
            this.tBoxInfo.Size = new System.Drawing.Size(500, 283);
            this.tBoxInfo.TabIndex = 133;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.groupBox);
            this.tabPage2.Controls.Add(this.cBoxShowTime);
            this.tabPage2.Controls.Add(this.cBoxDebug);
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.tBoxMsg);
            this.tabPage2.Controls.Add(this.tBoxInfo);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1113, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(775, 314);
            this.groupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox.Size = new System.Drawing.Size(293, 105);
            this.groupBox.TabIndex = 139;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "EXE";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Location = new System.Drawing.Point(187, 35);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(99, 51);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Location = new System.Drawing.Point(96, 35);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(80, 51);
            this.btnRun.TabIndex = 105;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.SkyBlue;
            this.btnInit.Location = new System.Drawing.Point(8, 35);
            this.btnInit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(80, 51);
            this.btnInit.TabIndex = 105;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 131;
            this.label5.Text = "Data Rev:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(516, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 25);
            this.label4.TabIndex = 132;
            this.label4.Text = "Data Send:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 108);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 470);
            this.tabControl1.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tBoxConnState);
            this.panel1.Controls.Add(this.tBoxRunState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tTaskBoxName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 55);
            this.panel1.TabIndex = 27;
            // 
            // tBoxConnState
            // 
            this.tBoxConnState.BackColor = System.Drawing.Color.Khaki;
            this.tBoxConnState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tBoxConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxConnState.Location = new System.Drawing.Point(561, 0);
            this.tBoxConnState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBoxConnState.Multiline = true;
            this.tBoxConnState.Name = "tBoxConnState";
            this.tBoxConnState.Size = new System.Drawing.Size(280, 55);
            this.tBoxConnState.TabIndex = 15;
            this.tBoxConnState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBoxRunState
            // 
            this.tBoxRunState.BackColor = System.Drawing.Color.Khaki;
            this.tBoxRunState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tBoxRunState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBoxRunState.Location = new System.Drawing.Point(841, 0);
            this.tBoxRunState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBoxRunState.Multiline = true;
            this.tBoxRunState.Name = "tBoxRunState";
            this.tBoxRunState.Size = new System.Drawing.Size(280, 55);
            this.tBoxRunState.TabIndex = 14;
            this.tBoxRunState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 55);
            this.label1.TabIndex = 12;
            this.label1.Text = "Serial Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tTaskBoxName
            // 
            this.tTaskBoxName.BackColor = System.Drawing.Color.OldLace;
            this.tTaskBoxName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tTaskBoxName.Location = new System.Drawing.Point(269, 4);
            this.tTaskBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tTaskBoxName.Multiline = true;
            this.tTaskBoxName.Name = "tTaskBoxName";
            this.tTaskBoxName.ReadOnly = true;
            this.tTaskBoxName.Size = new System.Drawing.Size(280, 48);
            this.tTaskBoxName.TabIndex = 13;
            this.tTaskBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1121, 53);
            this.lbTitle.TabIndex = 26;
            this.lbTitle.Text = "Serial Debug";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrimDebugControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PrimDebugControl";
            this.Size = new System.Drawing.Size(1121, 578);
            this.Load += new System.EventHandler(this.PrimDebugControl_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox cBoxShowTime;
        private System.Windows.Forms.CheckBox cBoxDebug;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tBoxMsg;
        private System.Windows.Forms.TextBox tBoxInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tBoxConnState;
        private System.Windows.Forms.TextBox tBoxRunState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tTaskBoxName;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
    }
}
