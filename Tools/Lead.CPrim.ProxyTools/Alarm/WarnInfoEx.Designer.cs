namespace Lead.CPrim.ProxyTools.Authority
{
    partial class UIWarnInfoEx
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
            this.rtb_WarnInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_WarnInfo
            // 
            this.rtb_WarnInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_WarnInfo.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_WarnInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rtb_WarnInfo.Location = new System.Drawing.Point(0, 0);
            this.rtb_WarnInfo.Name = "rtb_WarnInfo";
            this.rtb_WarnInfo.ReadOnly = true;
            this.rtb_WarnInfo.Size = new System.Drawing.Size(822, 591);
            this.rtb_WarnInfo.TabIndex = 0;
            this.rtb_WarnInfo.Text = "";
            // 
            // UIWarnInfoEx
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.rtb_WarnInfo);
            this.Name = "UIWarnInfoEx";
            this.Size = new System.Drawing.Size(822, 591);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_WarnInfo;
    }
}
