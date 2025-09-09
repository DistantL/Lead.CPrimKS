using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.View
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.bgwInitialize = new System.ComponentModel.BackgroundWorker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbarStatus = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // bgwInitialize
            // 
            this.bgwInitialize.WorkerReportsProgress = true;
            this.bgwInitialize.WorkerSupportsCancellation = true;
            this.bgwInitialize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwInitialize_DoWork);
            this.bgwInitialize.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwInitialize_ProgressChanged);
            this.bgwInitialize.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwInitialize_RunWorkerCompleted);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(642, 347);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Inital……";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pbarStatus
            // 
            this.pbarStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbarStatus.Location = new System.Drawing.Point(0, 347);
            this.pbarStatus.Name = "pbarStatus";
            this.pbarStatus.Size = new System.Drawing.Size(642, 27);
            this.pbarStatus.TabIndex = 1;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(642, 374);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbarStatus);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WelcomeForm_FormClosing);
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private BackgroundWorker bgwInitialize;
        private Label lblStatus;
        private ProgressBar pbarStatus;
    }
}
