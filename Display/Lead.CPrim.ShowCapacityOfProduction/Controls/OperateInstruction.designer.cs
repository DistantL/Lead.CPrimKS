namespace Lead.CPrim.ShowCapacityOfProduction.Controls
{
    partial class OperateInstruction
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.labRunningSta = new System.Windows.Forms.Label();
            this.labOperate = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.labRunningSta, 0, 1);
            this.tlpMain.Controls.Add(this.labOperate, 0, 3);
            this.tlpMain.Controls.Add(this.lbState, 0, 0);
            this.tlpMain.Controls.Add(this.label3, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Size = new System.Drawing.Size(782, 180);
            this.tlpMain.TabIndex = 0;
            // 
            // labRunningSta
            // 
            this.labRunningSta.AutoSize = true;
            this.labRunningSta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.labRunningSta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labRunningSta.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labRunningSta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labRunningSta.Location = new System.Drawing.Point(0, 45);
            this.labRunningSta.Margin = new System.Windows.Forms.Padding(0);
            this.labRunningSta.Name = "labRunningSta";
            this.labRunningSta.Size = new System.Drawing.Size(782, 45);
            this.labRunningSta.TabIndex = 29;
            this.labRunningSta.Text = "等待初始化";
            this.labRunningSta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labOperate
            // 
            this.labOperate.AutoSize = true;
            this.labOperate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.labOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labOperate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOperate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labOperate.Location = new System.Drawing.Point(0, 135);
            this.labOperate.Margin = new System.Windows.Forms.Padding(0);
            this.labOperate.Name = "labOperate";
            this.labOperate.Size = new System.Drawing.Size(782, 45);
            this.labOperate.TabIndex = 30;
            this.labOperate.Text = "请执行初始化操作";
            this.labOperate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labOperate.DoubleClick += new System.EventHandler(this.labOperate_DoubleClick);
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbState.ForeColor = System.Drawing.Color.Blue;
            this.lbState.Location = new System.Drawing.Point(0, 0);
            this.lbState.Margin = new System.Windows.Forms.Padding(0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(782, 45);
            this.lbState.TabIndex = 28;
            this.lbState.Text = "当前状态";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(0, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(782, 45);
            this.label3.TabIndex = 27;
            this.label3.Text = "操作指引";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OperateInstruction
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpMain);
            this.Name = "OperateInstruction";
            this.Size = new System.Drawing.Size(782, 180);
            this.Load += new System.EventHandler(this.OperateInstruction_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label labOperate;
        private System.Windows.Forms.Label labRunningSta;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label label3;
    }
}
