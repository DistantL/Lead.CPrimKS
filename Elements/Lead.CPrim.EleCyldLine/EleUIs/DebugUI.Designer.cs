namespace Lead.CPrim.EleCyldLine
{
    partial class DebugUI
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
            this.lblName = new System.Windows.Forms.Label();
            this.RestractDI = new System.Windows.Forms.Label();
            this.StretchDI = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.SandyBrown;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(8, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(210, 50);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "名称";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // RestractDI
            // 
            this.RestractDI.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.RestractDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RestractDI.Location = new System.Drawing.Point(225, 35);
            this.RestractDI.Name = "RestractDI";
            this.RestractDI.Size = new System.Drawing.Size(31, 23);
            this.RestractDI.TabIndex = 12;
            this.RestractDI.Text = "原";
            this.RestractDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StretchDI
            // 
            this.StretchDI.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.StretchDI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StretchDI.Location = new System.Drawing.Point(225, 8);
            this.StretchDI.Name = "StretchDI";
            this.StretchDI.Size = new System.Drawing.Size(31, 23);
            this.StretchDI.TabIndex = 14;
            this.StretchDI.Text = "伸";
            this.StretchDI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DebugUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.RestractDI);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.StretchDI);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DebugUI";
            this.Size = new System.Drawing.Size(265, 65);
            this.Load += new System.EventHandler(this.DebugUI_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label StretchDI;
        private System.Windows.Forms.Label RestractDI;
    }
}
