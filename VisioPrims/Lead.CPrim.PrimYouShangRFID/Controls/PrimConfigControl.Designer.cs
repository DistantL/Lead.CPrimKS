using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.PrimYouShangRFID
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbConnState = new System.Windows.Forms.TextBox();
            this.tbRunState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrimName = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbReConnCnt = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cb_RF4 = new System.Windows.Forms.CheckBox();
            this.cb_RF3 = new System.Windows.Forms.CheckBox();
            this.cb_RF2 = new System.Windows.Forms.CheckBox();
            this.cb_RF1 = new System.Windows.Forms.CheckBox();
            this.bt_Read = new System.Windows.Forms.Button();
            this.bt_Write = new System.Windows.Forms.Button();
            this.tb_WriteInfo = new System.Windows.Forms.TextBox();
            this.tb_ReadInfo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ReadByteNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(841, 44);
            this.panel1.TabIndex = 24;
            // 
            // tbConnState
            // 
            this.tbConnState.BackColor = System.Drawing.Color.Khaki;
            this.tbConnState.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConnState.Location = new System.Drawing.Point(419, 0);
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
            this.tbRunState.Location = new System.Drawing.Point(630, 0);
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
            this.label1.Text = "基元名称";
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
            this.tbPrimName.Size = new System.Drawing.Size(211, 39);
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
            this.lbTitle.Size = new System.Drawing.Size(841, 43);
            this.lbTitle.TabIndex = 23;
            this.lbTitle.Text = "思谷TCP网关RFID  配置";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(841, 375);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbPort);
            this.tabPage1.Controls.Add(this.tbReConnCnt);
            this.tabPage1.Controls.Add(this.tbIP);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "配置";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Controls.Add(this.btnApply);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(346, 220);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(437, 84);
            this.groupBox.TabIndex = 126;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "操作";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Location = new System.Drawing.Point(220, 28);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 41);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "停止";
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
            this.btnRun.Text = "运行";
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
            this.btnInit.Text = "初始化";
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
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(251, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 122;
            this.label3.Text = "端口号:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(553, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 125;
            this.label9.Text = "重连次数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 125;
            this.label2.Text = "IP地址:";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPort.Location = new System.Drawing.Point(317, 48);
            this.tbPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(150, 27);
            this.tbPort.TabIndex = 120;
            // 
            // tbReConnCnt
            // 
            this.tbReConnCnt.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbReConnCnt.Location = new System.Drawing.Point(633, 48);
            this.tbReConnCnt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbReConnCnt.Name = "tbReConnCnt";
            this.tbReConnCnt.Size = new System.Drawing.Size(150, 27);
            this.tbReConnCnt.TabIndex = 121;
            // 
            // tbIP
            // 
            this.tbIP.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbIP.Location = new System.Drawing.Point(79, 48);
            this.tbIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(150, 27);
            this.tbIP.TabIndex = 121;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tb_ReadByteNum);
            this.tabPage2.Controls.Add(this.cb_RF4);
            this.tabPage2.Controls.Add(this.cb_RF3);
            this.tabPage2.Controls.Add(this.cb_RF2);
            this.tabPage2.Controls.Add(this.cb_RF1);
            this.tabPage2.Controls.Add(this.bt_Read);
            this.tabPage2.Controls.Add(this.bt_Write);
            this.tabPage2.Controls.Add(this.tb_WriteInfo);
            this.tabPage2.Controls.Add(this.tb_ReadInfo);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "调试";
            // 
            // cb_RF4
            // 
            this.cb_RF4.AutoSize = true;
            this.cb_RF4.Location = new System.Drawing.Point(383, 31);
            this.cb_RF4.Name = "cb_RF4";
            this.cb_RF4.Size = new System.Drawing.Size(48, 21);
            this.cb_RF4.TabIndex = 140;
            this.cb_RF4.Text = "RF4";
            this.cb_RF4.UseVisualStyleBackColor = true;
            this.cb_RF4.CheckedChanged += new System.EventHandler(this.cb_RF4_CheckedChanged);
            // 
            // cb_RF3
            // 
            this.cb_RF3.AutoSize = true;
            this.cb_RF3.Location = new System.Drawing.Point(259, 31);
            this.cb_RF3.Name = "cb_RF3";
            this.cb_RF3.Size = new System.Drawing.Size(48, 21);
            this.cb_RF3.TabIndex = 139;
            this.cb_RF3.Text = "RF3";
            this.cb_RF3.UseVisualStyleBackColor = true;
            this.cb_RF3.CheckedChanged += new System.EventHandler(this.cb_RF3_CheckedChanged);
            // 
            // cb_RF2
            // 
            this.cb_RF2.AutoSize = true;
            this.cb_RF2.Location = new System.Drawing.Point(135, 31);
            this.cb_RF2.Name = "cb_RF2";
            this.cb_RF2.Size = new System.Drawing.Size(48, 21);
            this.cb_RF2.TabIndex = 138;
            this.cb_RF2.Text = "RF2";
            this.cb_RF2.UseVisualStyleBackColor = true;
            this.cb_RF2.CheckedChanged += new System.EventHandler(this.cb_RF2_CheckedChanged);
            // 
            // cb_RF1
            // 
            this.cb_RF1.AutoSize = true;
            this.cb_RF1.Checked = true;
            this.cb_RF1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_RF1.Location = new System.Drawing.Point(11, 31);
            this.cb_RF1.Name = "cb_RF1";
            this.cb_RF1.Size = new System.Drawing.Size(48, 21);
            this.cb_RF1.TabIndex = 137;
            this.cb_RF1.Text = "RF1";
            this.cb_RF1.UseVisualStyleBackColor = true;
            this.cb_RF1.CheckedChanged += new System.EventHandler(this.cb_RF1_CheckedChanged);
            // 
            // bt_Read
            // 
            this.bt_Read.Location = new System.Drawing.Point(267, 293);
            this.bt_Read.Name = "bt_Read";
            this.bt_Read.Size = new System.Drawing.Size(119, 37);
            this.bt_Read.TabIndex = 136;
            this.bt_Read.Text = "读";
            this.bt_Read.UseVisualStyleBackColor = true;
            this.bt_Read.Click += new System.EventHandler(this.bt_Read_Click);
            // 
            // bt_Write
            // 
            this.bt_Write.Location = new System.Drawing.Point(682, 293);
            this.bt_Write.Name = "bt_Write";
            this.bt_Write.Size = new System.Drawing.Size(119, 37);
            this.bt_Write.TabIndex = 135;
            this.bt_Write.Text = "写";
            this.bt_Write.UseVisualStyleBackColor = true;
            this.bt_Write.Click += new System.EventHandler(this.bt_Write_Click);
            // 
            // tb_WriteInfo
            // 
            this.tb_WriteInfo.Location = new System.Drawing.Point(391, 96);
            this.tb_WriteInfo.Multiline = true;
            this.tb_WriteInfo.Name = "tb_WriteInfo";
            this.tb_WriteInfo.Size = new System.Drawing.Size(409, 191);
            this.tb_WriteInfo.TabIndex = 134;
            // 
            // tb_ReadInfo
            // 
            this.tb_ReadInfo.Location = new System.Drawing.Point(10, 96);
            this.tb_ReadInfo.Multiline = true;
            this.tb_ReadInfo.Name = "tb_ReadInfo";
            this.tb_ReadInfo.Size = new System.Drawing.Size(376, 191);
            this.tb_ReadInfo.TabIndex = 133;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 131;
            this.label5.Text = "读出数据:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(387, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 132;
            this.label4.Text = "写入数据:";
            // 
            // tb_ReadByteNum
            // 
            this.tb_ReadByteNum.Location = new System.Drawing.Point(135, 300);
            this.tb_ReadByteNum.Name = "tb_ReadByteNum";
            this.tb_ReadByteNum.Size = new System.Drawing.Size(100, 23);
            this.tb_ReadByteNum.TabIndex = 141;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 17);
            this.label6.TabIndex = 142;
            this.label6.Text = "需要读入数据个数：";
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
            this.Size = new System.Drawing.Size(841, 462);
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private TextBox tbConnState;
        private TextBox tbRunState;
        private Label label1;
        private TextBox tbPrimName;
        private Label lbTitle;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnApply;
        private GroupBox groupBox;
        private Button btnStop;
        private Button btnRun;
        private Button btnInit;
        private Label label3;
        private Label label2;
        private TextBox tbPort;
        private TextBox tbIP;
        private TabPage tabPage2;
        private Button bt_Write;
        private TextBox tb_WriteInfo;
        private TextBox tb_ReadInfo;
        private Label label5;
        private Label label4;
        private Label label9;
        private TextBox tbReConnCnt;
        private CheckBox cb_RF4;
        private CheckBox cb_RF3;
        private CheckBox cb_RF2;
        private CheckBox cb_RF1;
        private Button bt_Read;
        private Label label6;
        private TextBox tb_ReadByteNum;
    }
}
