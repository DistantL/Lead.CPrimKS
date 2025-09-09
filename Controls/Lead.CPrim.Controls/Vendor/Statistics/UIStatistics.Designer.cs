
namespace Lead.CPrim.Controls
{ 
    partial class UIStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvStatistics = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsedNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClearStatistics = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colLastClearTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStatistics
            // 
            this.dgvStatistics.AllowUserToAddRows = false;
            this.dgvStatistics.AllowUserToDeleteRows = false;
            this.dgvStatistics.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvStatistics.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatistics.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvStatistics.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatistics.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStatistics.ColumnHeadersHeight = 32;
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFirstName,
            this.colSecondName,
            this.colUsedNum,
            this.colWarnNum,
            this.colErrorNum,
            this.colClearStatistics,
            this.colLastClearTime});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatistics.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatistics.EnableHeadersVisualStyles = false;
            this.dgvStatistics.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvStatistics.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.dgvStatistics.Location = new System.Drawing.Point(0, 0);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatistics.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStatistics.RowHeadersWidth = 20;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvStatistics.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStatistics.RowTemplate.Height = 23;
            this.dgvStatistics.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvStatistics.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvStatistics.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvStatistics.SelectedIndex = -1;
            this.dgvStatistics.Size = new System.Drawing.Size(756, 421);
            this.dgvStatistics.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.dgvStatistics.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvStatistics.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgvStatistics.StyleCustomMode = true;
            this.dgvStatistics.TabIndex = 0;
            this.dgvStatistics.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvStatistics.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvStatistics_CellBeginEdit);
            this.dgvStatistics.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Statistics_CellContentClick);
            this.dgvStatistics.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Statistics_CellEndEdit);
            this.dgvStatistics.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStatistics_CellFormatting);
            // 
            // colFirstName
            // 
            this.colFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFirstName.DataPropertyName = "WorkName";
            this.colFirstName.FillWeight = 432.4222F;
            this.colFirstName.HeaderText = "位置";
            this.colFirstName.MinimumWidth = 240;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            this.colFirstName.Width = 240;
            // 
            // colSecondName
            // 
            this.colSecondName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSecondName.DataPropertyName = "ValueName";
            this.colSecondName.FillWeight = 33.33254F;
            this.colSecondName.HeaderText = "名称";
            this.colSecondName.MinimumWidth = 240;
            this.colSecondName.Name = "colSecondName";
            this.colSecondName.ReadOnly = true;
            this.colSecondName.Width = 240;
            // 
            // colUsedNum
            // 
            this.colUsedNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUsedNum.DataPropertyName = "UsedCount";
            this.colUsedNum.FillWeight = 11.11085F;
            this.colUsedNum.HeaderText = "使用次数";
            this.colUsedNum.MinimumWidth = 120;
            this.colUsedNum.Name = "colUsedNum";
            this.colUsedNum.ReadOnly = true;
            this.colUsedNum.Width = 120;
            // 
            // colWarnNum
            // 
            this.colWarnNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colWarnNum.DataPropertyName = "WarnCount";
            this.colWarnNum.FillWeight = 22.22169F;
            this.colWarnNum.HeaderText = "警告次数";
            this.colWarnNum.MinimumWidth = 120;
            this.colWarnNum.Name = "colWarnNum";
            this.colWarnNum.Width = 120;
            // 
            // colErrorNum
            // 
            this.colErrorNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colErrorNum.DataPropertyName = "LimitCount";
            this.colErrorNum.FillWeight = 11.11085F;
            this.colErrorNum.HeaderText = "报警次数";
            this.colErrorNum.MinimumWidth = 120;
            this.colErrorNum.Name = "colErrorNum";
            this.colErrorNum.Width = 120;
            // 
            // colClearStatistics
            // 
            this.colClearStatistics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colClearStatistics.FillWeight = 6.666508F;
            this.colClearStatistics.HeaderText = "清零";
            this.colClearStatistics.MinimumWidth = 120;
            this.colClearStatistics.Name = "colClearStatistics";
            this.colClearStatistics.Width = 120;
            // 
            // colLastClearTime
            // 
            this.colLastClearTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colLastClearTime.DataPropertyName = "LastClearTime";
            this.colLastClearTime.FillWeight = 22.22169F;
            this.colLastClearTime.HeaderText = "最后一次修改时间";
            this.colLastClearTime.MinimumWidth = 240;
            this.colLastClearTime.Name = "colLastClearTime";
            this.colLastClearTime.ReadOnly = true;
            this.colLastClearTime.Width = 240;
            // 
            // UIStatistics
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgvStatistics);
            this.Name = "UIStatistics";
            this.Size = new System.Drawing.Size(756, 421);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProxyTools.SunnyUI.Controls.UIDataGridView dgvStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsedNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarnNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorNum;
        private System.Windows.Forms.DataGridViewButtonColumn colClearStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastClearTime;
    }
}
