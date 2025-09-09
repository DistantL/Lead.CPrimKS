using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManualButton
{
    partial class ManualButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualButton));
            this.btnStop = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.txtSN2 = new System.Windows.Forms.TextBox();
            this.lblSn2 = new System.Windows.Forms.Label();
            this.txtSN1 = new System.Windows.Forms.TextBox();
            this.lblSn1 = new System.Windows.Forms.Label();
            this.plMain = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tlpMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.AutoSize = true;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(250, 2);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 46);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止所有";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblInfo, 0, 4);
            this.tlpMain.Controls.Add(this.panel3, 0, 3);
            this.tlpMain.Controls.Add(this.rtbMsg, 0, 2);
            this.tlpMain.Controls.Add(this.tlpTitle, 0, 0);
            this.tlpMain.Controls.Add(this.plMain, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(1105, 826);
            this.tlpMain.TabIndex = 4;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblInfo.Location = new System.Drawing.Point(4, 776);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1097, 50);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblNum);
            this.panel3.Controls.Add(this.txtNum);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnStop);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 726);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1097, 50);
            this.panel3.TabIndex = 0;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNum.Location = new System.Drawing.Point(12, 12);
            this.lblNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(57, 27);
            this.lblNum.TabIndex = 1;
            this.lblNum.Text = "次数:";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNum.Location = new System.Drawing.Point(88, 8);
            this.txtNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(149, 34);
            this.txtNum.TabIndex = 2;
            this.txtNum.Text = "1";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.AutoSize = true;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(412, 2);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 46);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbMsg
            // 
            this.rtbMsg.BackColor = System.Drawing.SystemColors.Control;
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMsg.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rtbMsg.Location = new System.Drawing.Point(4, 557);
            this.rtbMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(1097, 169);
            this.rtbMsg.TabIndex = 4;
            this.rtbMsg.Text = "";
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 4;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.Controls.Add(this.txtSN2, 3, 0);
            this.tlpTitle.Controls.Add(this.lblSn2, 2, 0);
            this.tlpTitle.Controls.Add(this.txtSN1, 1, 0);
            this.tlpTitle.Controls.Add(this.lblSn1, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Location = new System.Drawing.Point(4, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTitle.Size = new System.Drawing.Size(1097, 50);
            this.tlpTitle.TabIndex = 5;
            // 
            // txtSN2
            // 
            this.txtSN2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSN2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSN2.Location = new System.Drawing.Point(675, 10);
            this.txtSN2.Margin = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.txtSN2.Name = "txtSN2";
            this.txtSN2.Size = new System.Drawing.Size(420, 29);
            this.txtSN2.TabIndex = 1;
            // 
            // lblSn2
            // 
            this.lblSn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSn2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblSn2.Location = new System.Drawing.Point(550, 2);
            this.lblSn2.Margin = new System.Windows.Forms.Padding(2);
            this.lblSn2.Name = "lblSn2";
            this.lblSn2.Size = new System.Drawing.Size(121, 46);
            this.lblSn2.TabIndex = 0;
            this.lblSn2.Text = "SN2：";
            this.lblSn2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSN1
            // 
            this.txtSN1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSN1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSN1.Location = new System.Drawing.Point(127, 10);
            this.txtSN1.Margin = new System.Windows.Forms.Padding(2, 10, 2, 2);
            this.txtSN1.Name = "txtSN1";
            this.txtSN1.Size = new System.Drawing.Size(419, 29);
            this.txtSN1.TabIndex = 1;
            // 
            // lblSn1
            // 
            this.lblSn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSn1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblSn1.Location = new System.Drawing.Point(2, 2);
            this.lblSn1.Margin = new System.Windows.Forms.Padding(2);
            this.lblSn1.Name = "lblSn1";
            this.lblSn1.Size = new System.Drawing.Size(121, 46);
            this.lblSn1.TabIndex = 0;
            this.lblSn1.Text = "SN1：";
            this.lblSn1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSn1.DoubleClick += new System.EventHandler(this.lblSn1_DoubleClick);
            // 
            // plMain
            // 
            this.plMain.AutoScroll = true;
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(4, 54);
            this.plMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1097, 499);
            this.plMain.TabIndex = 6;
            // 
            // ManualButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1105, 826);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1120, 863);
            this.Name = "ManualButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手动测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualTestFrm_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnStop;
        private TableLayoutPanel tlpMain;
        private Label lblInfo;
        private ToolTip toolTip1;
        private TextBox txtNum;
        private Label lblNum;
        private Label lblSn2;
        private TextBox txtSN1;
        private TextBox txtSN2;
        private Label lblSn1;
        private Panel panel3;
        private RichTextBox rtbMsg;
        private Button btnClear;
        private TableLayoutPanel tlpTitle;
        private Panel plMain;
    }
}
