
namespace Lead.CPrim.WorkPlan.Controls
{
    partial class ShowOutputControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartWorkSheet = new System.Windows.Forms.Button();
            this.tbWorkSheetCount = new System.Windows.Forms.TextBox();
            this.tbWorkSheetPSASN = new System.Windows.Forms.TextBox();
            this.tbWorkSheetId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvWorkSheet = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkSheetId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkSheetPSASN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkSheetCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbWorkSheetOK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbWorkSheetNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkSheet)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvWorkSheet, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1222, 566);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartWorkSheet);
            this.groupBox1.Controls.Add(this.tbWorkSheetCount);
            this.groupBox1.Controls.Add(this.tbWorkSheetPSASN);
            this.groupBox1.Controls.Add(this.tbWorkSheetId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1212, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工单录入";
            // 
            // btnStartWorkSheet
            // 
            this.btnStartWorkSheet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartWorkSheet.Location = new System.Drawing.Point(1022, 37);
            this.btnStartWorkSheet.Name = "btnStartWorkSheet";
            this.btnStartWorkSheet.Size = new System.Drawing.Size(178, 29);
            this.btnStartWorkSheet.TabIndex = 2;
            this.btnStartWorkSheet.Text = "启用工单";
            this.btnStartWorkSheet.UseVisualStyleBackColor = true;
            this.btnStartWorkSheet.Click += new System.EventHandler(this.btnStartWorkSheet_Click);
            // 
            // tbWorkSheetCount
            // 
            this.tbWorkSheetCount.Location = new System.Drawing.Point(875, 37);
            this.tbWorkSheetCount.Name = "tbWorkSheetCount";
            this.tbWorkSheetCount.Size = new System.Drawing.Size(100, 29);
            this.tbWorkSheetCount.TabIndex = 1;
            // 
            // tbWorkSheetPSASN
            // 
            this.tbWorkSheetPSASN.Location = new System.Drawing.Point(459, 37);
            this.tbWorkSheetPSASN.Name = "tbWorkSheetPSASN";
            this.tbWorkSheetPSASN.Size = new System.Drawing.Size(250, 29);
            this.tbWorkSheetPSASN.TabIndex = 1;
            // 
            // tbWorkSheetId
            // 
            this.tbWorkSheetId.Location = new System.Drawing.Point(93, 37);
            this.tbWorkSheetId.Name = "tbWorkSheetId";
            this.tbWorkSheetId.Size = new System.Drawing.Size(250, 29);
            this.tbWorkSheetId.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(749, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "当前工单数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "PSASN：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "工单号：";
            // 
            // dgvWorkSheet
            // 
            this.dgvWorkSheet.AllowUserToAddRows = false;
            this.dgvWorkSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCreateTime,
            this.colWorkSheetId,
            this.colWorkSheetPSASN,
            this.colWorkSheetCount,
            this.cbWorkSheetOK,
            this.cbWorkSheetNG,
            this.colRemark});
            this.dgvWorkSheet.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvWorkSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkSheet.Location = new System.Drawing.Point(3, 103);
            this.dgvWorkSheet.Name = "dgvWorkSheet";
            this.dgvWorkSheet.RowTemplate.Height = 23;
            this.dgvWorkSheet.Size = new System.Drawing.Size(1216, 460);
            this.dgvWorkSheet.TabIndex = 1;
            this.dgvWorkSheet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkSheet_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出ToolStripMenuItem,
            this.删除选中行ToolStripMenuItem,
            this.删除所有ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 删除选中行ToolStripMenuItem
            // 
            this.删除选中行ToolStripMenuItem.Name = "删除选中行ToolStripMenuItem";
            this.删除选中行ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除选中行ToolStripMenuItem.Text = "删除选中行";
            this.删除选中行ToolStripMenuItem.Click += new System.EventHandler(this.删除选中行ToolStripMenuItem_Click);
            // 
            // 删除所有ToolStripMenuItem
            // 
            this.删除所有ToolStripMenuItem.Name = "删除所有ToolStripMenuItem";
            this.删除所有ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除所有ToolStripMenuItem.Text = "删除所有";
            this.删除所有ToolStripMenuItem.Click += new System.EventHandler(this.删除所有ToolStripMenuItem_Click);
            // 
            // colCreateTime
            // 
            this.colCreateTime.HeaderText = "创建时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Width = 200;
            // 
            // colWorkSheetId
            // 
            this.colWorkSheetId.HeaderText = "工单号";
            this.colWorkSheetId.Name = "colWorkSheetId";
            this.colWorkSheetId.Width = 250;
            // 
            // colWorkSheetPSASN
            // 
            this.colWorkSheetPSASN.HeaderText = "PSASN";
            this.colWorkSheetPSASN.Name = "colWorkSheetPSASN";
            this.colWorkSheetPSASN.Width = 250;
            // 
            // colWorkSheetCount
            // 
            this.colWorkSheetCount.HeaderText = "当前工单数量";
            this.colWorkSheetCount.Name = "colWorkSheetCount";
            this.colWorkSheetCount.Width = 140;
            // 
            // cbWorkSheetOK
            // 
            this.cbWorkSheetOK.HeaderText = "OK统计";
            this.cbWorkSheetOK.Name = "cbWorkSheetOK";
            // 
            // cbWorkSheetNG
            // 
            this.cbWorkSheetNG.HeaderText = "NG统计";
            this.cbWorkSheetNG.Name = "cbWorkSheetNG";
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemark.HeaderText = "备注";
            this.colRemark.Name = "colRemark";
            // 
            // ShowOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ShowOutputControl";
            this.Size = new System.Drawing.Size(1222, 566);
            this.Load += new System.EventHandler(this.ShowOutputControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkSheet)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartWorkSheet;
        private System.Windows.Forms.TextBox tbWorkSheetCount;
        private System.Windows.Forms.TextBox tbWorkSheetPSASN;
        private System.Windows.Forms.TextBox tbWorkSheetId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvWorkSheet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除选中行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除所有ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkSheetId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkSheetPSASN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkSheetCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbWorkSheetOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbWorkSheetNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
    }
}
