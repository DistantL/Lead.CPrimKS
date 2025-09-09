namespace IpcConnection
{
    partial class Form1
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
            this.LblIPCInfo = new System.Windows.Forms.Label();
            this.BtnChangeIPCState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblIPCInfo
            // 
            this.LblIPCInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblIPCInfo.Location = new System.Drawing.Point(24, 51);
            this.LblIPCInfo.Name = "LblIPCInfo";
            this.LblIPCInfo.Size = new System.Drawing.Size(261, 23);
            this.LblIPCInfo.TabIndex = 0;
            this.LblIPCInfo.Tag = "IPC状态";
            this.LblIPCInfo.Text = "IPC状态";
            // 
            // BtnChangeIPCState
            // 
            this.BtnChangeIPCState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnChangeIPCState.Location = new System.Drawing.Point(291, 42);
            this.BtnChangeIPCState.Name = "BtnChangeIPCState";
            this.BtnChangeIPCState.Size = new System.Drawing.Size(101, 41);
            this.BtnChangeIPCState.TabIndex = 1;
            this.BtnChangeIPCState.Text = "连接";
            this.BtnChangeIPCState.UseVisualStyleBackColor = true;
            this.BtnChangeIPCState.Click += new System.EventHandler(this.BtnChangeIPCState_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 121);
            this.Controls.Add(this.BtnChangeIPCState);
            this.Controls.Add(this.LblIPCInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblIPCInfo;
        private System.Windows.Forms.Button BtnChangeIPCState;
    }
}

