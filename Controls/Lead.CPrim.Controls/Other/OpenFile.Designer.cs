namespace Lead.CPrim.Controls
{
    partial class OpenFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSFLLog = new System.Windows.Forms.Button();
            this.btnPDCALog = new System.Windows.Forms.Button();
            this.btnMachineLog = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSFLLog
            // 
            this.btnSFLLog.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSFLLog.Location = new System.Drawing.Point(199, 48);
            this.btnSFLLog.Name = "btnSFLLog";
            this.btnSFLLog.Size = new System.Drawing.Size(132, 49);
            this.btnSFLLog.TabIndex = 0;
            this.btnSFLLog.Text = "SFL_Log";
            this.btnSFLLog.UseVisualStyleBackColor = true;
            this.btnSFLLog.Click += new System.EventHandler(this.btnSFLLog_Click);
            // 
            // btnPDCALog
            // 
            this.btnPDCALog.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPDCALog.Location = new System.Drawing.Point(352, 48);
            this.btnPDCALog.Name = "btnPDCALog";
            this.btnPDCALog.Size = new System.Drawing.Size(132, 49);
            this.btnPDCALog.TabIndex = 0;
            this.btnPDCALog.Text = "PDCA_Log";
            this.btnPDCALog.UseVisualStyleBackColor = true;
            this.btnPDCALog.Click += new System.EventHandler(this.btnPDCALog_Click);
            // 
            // btnMachineLog
            // 
            this.btnMachineLog.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMachineLog.Location = new System.Drawing.Point(505, 48);
            this.btnMachineLog.Name = "btnMachineLog";
            this.btnMachineLog.Size = new System.Drawing.Size(132, 49);
            this.btnMachineLog.TabIndex = 0;
            this.btnMachineLog.Text = "Machine_Log";
            this.btnMachineLog.UseVisualStyleBackColor = true;
            this.btnMachineLog.Click += new System.EventHandler(this.btnMachineLog_Click);
            // 
            // btnData
            // 
            this.btnData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnData.Location = new System.Drawing.Point(46, 48);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(132, 49);
            this.btnData.TabIndex = 0;
            this.btnData.Text = "Data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // OpenFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 141);
            this.Controls.Add(this.btnMachineLog);
            this.Controls.Add(this.btnPDCALog);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.btnSFLLog);
            this.MaximizeBox = false;
            this.Name = "OpenFile";
            this.Text = "文件打开";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSFLLog;
        private System.Windows.Forms.Button btnPDCALog;
        private System.Windows.Forms.Button btnMachineLog;
        private System.Windows.Forms.Button btnData;
    }
}