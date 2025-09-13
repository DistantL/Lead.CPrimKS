namespace Lead.CPrim.ProxyTools.Authority
{
    partial class AlarmInfoEx
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_AlertInfo = new System.Windows.Forms.DataGridView();
            this.colVendorAlarmCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorDetailInEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorDetailInVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colHasParams = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPromptMethod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAlarmCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContinuousThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCumulativeThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolutionInEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolutionInVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorLevelInEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AlertInfo)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_AlertInfo
            // 
            this.dgv_AlertInfo.AllowUserToAddRows = false;
            this.dgv_AlertInfo.AllowUserToDeleteRows = false;
            this.dgv_AlertInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_AlertInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_AlertInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_AlertInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgv_AlertInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_AlertInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_AlertInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AlertInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVendorAlarmCode,
            this.colErrorDetail,
            this.colErrorDetailInEN,
            this.colErrorDetailInVN,
            this.colErrorCode,
            this.colErrorMessage,
            this.colErrorLevel,
            this.colHasParams,
            this.colPromptMethod,
            this.colAlarmCount,
            this.colContinuousThreshold,
            this.colCumulativeThreshold,
            this.colSolution,
            this.colSolutionInEN,
            this.colSolutionInVN,
            this.colErrorLevelInEN,
            this.colLastTime,
            this.colSequence});
            this.dgv_AlertInfo.ContextMenuStrip = this.cms;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_AlertInfo.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_AlertInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_AlertInfo.EnableHeadersVisualStyles = false;
            this.dgv_AlertInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_AlertInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.dgv_AlertInfo.Location = new System.Drawing.Point(0, 0);
            this.dgv_AlertInfo.Name = "dgv_AlertInfo";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_AlertInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_AlertInfo.RowHeadersWidth = 20;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_AlertInfo.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_AlertInfo.RowTemplate.Height = 27;
            this.dgv_AlertInfo.Size = new System.Drawing.Size(1142, 537);
            this.dgv_AlertInfo.TabIndex = 1;
            this.dgv_AlertInfo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            this.dgv_AlertInfo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_CurrentCellDirtyStateChanged);
            this.dgv_AlertInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            // 
            // colVendorAlarmCode
            // 
            this.colVendorAlarmCode.HeaderText = "供应商报警编号";
            this.colVendorAlarmCode.Name = "colVendorAlarmCode";
            this.colVendorAlarmCode.Width = 146;
            // 
            // colErrorDetail
            // 
            this.colErrorDetail.DataPropertyName = "ErrorDetail";
            this.colErrorDetail.HeaderText = "报警详细信息";
            this.colErrorDetail.MinimumWidth = 6;
            this.colErrorDetail.Name = "colErrorDetail";
            this.colErrorDetail.Width = 130;
            // 
            // colErrorDetailInEN
            // 
            this.colErrorDetailInEN.DataPropertyName = "ErrorDetailInEN";
            this.colErrorDetailInEN.HeaderText = "Error Detail";
            this.colErrorDetailInEN.MinimumWidth = 6;
            this.colErrorDetailInEN.Name = "colErrorDetailInEN";
            this.colErrorDetailInEN.Width = 120;
            // 
            // colErrorDetailInVN
            // 
            this.colErrorDetailInVN.DataPropertyName = "ErrorDetailInVN";
            this.colErrorDetailInVN.HeaderText = "Chi tiết lỗi";
            this.colErrorDetailInVN.MinimumWidth = 6;
            this.colErrorDetailInVN.Name = "colErrorDetailInVN";
            this.colErrorDetailInVN.Width = 111;
            // 
            // colErrorCode
            // 
            this.colErrorCode.DataPropertyName = "ErrorCode";
            this.colErrorCode.HeaderText = "报警代码";
            this.colErrorCode.MinimumWidth = 6;
            this.colErrorCode.Name = "colErrorCode";
            this.colErrorCode.Width = 98;
            // 
            // colErrorMessage
            // 
            this.colErrorMessage.DataPropertyName = "ErrorMessage";
            this.colErrorMessage.HeaderText = "报警类型";
            this.colErrorMessage.MinimumWidth = 6;
            this.colErrorMessage.Name = "colErrorMessage";
            this.colErrorMessage.Width = 98;
            // 
            // colErrorLevel
            // 
            this.colErrorLevel.DataPropertyName = "ErrorLevel";
            this.colErrorLevel.HeaderText = "报警级别";
            this.colErrorLevel.MinimumWidth = 6;
            this.colErrorLevel.Name = "colErrorLevel";
            this.colErrorLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colErrorLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colErrorLevel.Width = 98;
            // 
            // colHasParams
            // 
            this.colHasParams.DataPropertyName = "HasParams";
            this.colHasParams.HeaderText = "包含参数";
            this.colHasParams.MinimumWidth = 6;
            this.colHasParams.Name = "colHasParams";
            this.colHasParams.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHasParams.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colHasParams.Width = 98;
            // 
            // colPromptMethod
            // 
            this.colPromptMethod.DataPropertyName = "PromptMethod";
            this.colPromptMethod.HeaderText = "提示方式";
            this.colPromptMethod.MinimumWidth = 6;
            this.colPromptMethod.Name = "colPromptMethod";
            this.colPromptMethod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPromptMethod.Width = 79;
            // 
            // colAlarmCount
            // 
            this.colAlarmCount.DataPropertyName = "AlarmCount";
            this.colAlarmCount.HeaderText = "当前次数";
            this.colAlarmCount.MinimumWidth = 6;
            this.colAlarmCount.Name = "colAlarmCount";
            this.colAlarmCount.Width = 98;
            // 
            // colContinuousThreshold
            // 
            this.colContinuousThreshold.DataPropertyName = "ContinuousThreshold";
            this.colContinuousThreshold.HeaderText = "连续阈值";
            this.colContinuousThreshold.Name = "colContinuousThreshold";
            this.colContinuousThreshold.Width = 98;
            // 
            // colCumulativeThreshold
            // 
            this.colCumulativeThreshold.DataPropertyName = "CumulativeThreshold";
            this.colCumulativeThreshold.HeaderText = "累计阈值";
            this.colCumulativeThreshold.MinimumWidth = 6;
            this.colCumulativeThreshold.Name = "colCumulativeThreshold";
            this.colCumulativeThreshold.Width = 98;
            // 
            // colSolution
            // 
            this.colSolution.DataPropertyName = "Solution";
            this.colSolution.HeaderText = "解决方案";
            this.colSolution.MinimumWidth = 6;
            this.colSolution.Name = "colSolution";
            this.colSolution.Width = 98;
            // 
            // colSolutionInEN
            // 
            this.colSolutionInEN.DataPropertyName = "SolutionInEN";
            this.colSolutionInEN.HeaderText = "Solution";
            this.colSolutionInEN.MinimumWidth = 6;
            this.colSolutionInEN.Name = "colSolutionInEN";
            this.colSolutionInEN.Width = 97;
            // 
            // colSolutionInVN
            // 
            this.colSolutionInVN.DataPropertyName = "SolutionInVN";
            this.colSolutionInVN.HeaderText = "Giải pháp";
            this.colSolutionInVN.MinimumWidth = 6;
            this.colSolutionInVN.Name = "colSolutionInVN";
            this.colSolutionInVN.Width = 107;
            // 
            // colErrorLevelInEN
            // 
            this.colErrorLevelInEN.DataPropertyName = "ErrorLevelInEN";
            this.colErrorLevelInEN.HeaderText = "ErrorLevelInEN";
            this.colErrorLevelInEN.MinimumWidth = 6;
            this.colErrorLevelInEN.Name = "colErrorLevelInEN";
            this.colErrorLevelInEN.Visible = false;
            this.colErrorLevelInEN.Width = 146;
            // 
            // colLastTime
            // 
            this.colLastTime.DataPropertyName = "LastTime";
            this.colLastTime.HeaderText = "LastTime";
            this.colLastTime.MinimumWidth = 6;
            this.colLastTime.Name = "colLastTime";
            this.colLastTime.Visible = false;
            this.colLastTime.Width = 101;
            // 
            // colSequence
            // 
            this.colSequence.DataPropertyName = "Sequence";
            this.colSequence.HeaderText = "Sequence";
            this.colSequence.MinimumWidth = 6;
            this.colSequence.Name = "colSequence";
            this.colSequence.ReadOnly = true;
            this.colSequence.Visible = false;
            this.colSequence.Width = 108;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiDelete});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(100, 22);
            this.tsmiAdd.Text = "新增";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // AlarmInfoEx
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgv_AlertInfo);
            this.Name = "AlarmInfoEx";
            this.Size = new System.Drawing.Size(1142, 537);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AlertInfo)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //private ProxyTools.SunnyUI.Controls.UIDataGridView dgv_AlertInfo;
        private System.Windows.Forms.DataGridView dgv_AlertInfo;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendorAlarmCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorDetailInEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorDetailInVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorMessage;
        private System.Windows.Forms.DataGridViewComboBoxColumn colErrorLevel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHasParams;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPromptMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlarmCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContinuousThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCumulativeThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolutionInEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolutionInVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorLevelInEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequence;
    }
}
