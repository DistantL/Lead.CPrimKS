using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Register
{
    partial class FormRegisteSpecial
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
            this.components = new System.ComponentModel.Container();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tbCode1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCode2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCode3 = new System.Windows.Forms.TextBox();
            this.tbCode4 = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblInfo.Location = new System.Drawing.Point(30, 82);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(182, 31);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "请输入注册码：";
            this.lblInfo.DoubleClick += new System.EventHandler(this.lblInfo_DoubleClick);
            // 
            // tbCode1
            // 
            this.tbCode1.ContextMenuStrip = this.contextMenuStrip1;
            this.tbCode1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tbCode1.Location = new System.Drawing.Point(36, 118);
            this.tbCode1.Name = "tbCode1";
            this.tbCode1.ShortcutsEnabled = false;
            this.tbCode1.Size = new System.Drawing.Size(100, 29);
            this.tbCode1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.粘贴ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(142, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(271, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // tbCode2
            // 
            this.tbCode2.ContextMenuStrip = this.contextMenuStrip1;
            this.tbCode2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tbCode2.Location = new System.Drawing.Point(165, 116);
            this.tbCode2.Name = "tbCode2";
            this.tbCode2.Size = new System.Drawing.Size(100, 29);
            this.tbCode2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(400, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "-";
            // 
            // tbCode3
            // 
            this.tbCode3.ContextMenuStrip = this.contextMenuStrip1;
            this.tbCode3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tbCode3.Location = new System.Drawing.Point(294, 116);
            this.tbCode3.Name = "tbCode3";
            this.tbCode3.Size = new System.Drawing.Size(100, 29);
            this.tbCode3.TabIndex = 5;
            // 
            // tbCode4
            // 
            this.tbCode4.ContextMenuStrip = this.contextMenuStrip1;
            this.tbCode4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tbCode4.Location = new System.Drawing.Point(423, 116);
            this.tbCode4.Name = "tbCode4";
            this.tbCode4.Size = new System.Drawing.Size(100, 29);
            this.tbCode4.TabIndex = 7;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.Location = new System.Drawing.Point(235, 160);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(88, 39);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(434, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 39);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(30, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "注册序列号：";
            this.label4.DoubleClick += new System.EventHandler(this.lblInfo_DoubleClick);
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblNum.Location = new System.Drawing.Point(36, 48);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(61, 23);
            this.lblNum.TabIndex = 10;
            this.lblNum.Text = "序列号";
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCopy.Location = new System.Drawing.Point(36, 160);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 39);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FormRegisteSpecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(555, 212);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.tbCode4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCode3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCode2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCode1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegisteSpecial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件注册";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblInfo;
        private TextBox tbCode1;
        private TextBox tbCode2;
        private TextBox tbCode3;
        private TextBox tbCode4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnRegister;
        private Button btnCancel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 粘贴ToolStripMenuItem;
        private Label label4;
        private Label lblNum;
        private Button btnCopy;
    }
}
