using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    partial class LogMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.pnlUp = new System.Windows.Forms.Panel();
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.cbFatal = new System.Windows.Forms.CheckBox();
            this.switchSelect = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISwitch();
            this.cbError = new System.Windows.Forms.CheckBox();
            this.cbOther = new System.Windows.Forms.CheckBox();
            this.cbTrace = new System.Windows.Forms.CheckBox();
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.cbInfo = new System.Windows.Forms.CheckBox();
            this.cbWarn = new System.Windows.Forms.CheckBox();
            this.dgvInfo = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.columnsTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnsLogClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnsLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnsMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alertInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlpLog.SuspendLayout();
            this.pnlUp.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLog
            // 
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.Controls.Add(this.pnlUp, 0, 0);
            this.tlpLog.Controls.Add(this.dgvInfo, 0, 1);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(0, 0);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 2;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.Size = new System.Drawing.Size(1285, 830);
            this.tlpLog.TabIndex = 0;
            // 
            // pnlUp
            // 
            this.pnlUp.Controls.Add(this.tlpTitle);
            this.pnlUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUp.Location = new System.Drawing.Point(0, 0);
            this.pnlUp.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(1285, 40);
            this.pnlUp.TabIndex = 2;
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 10;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTitle.Controls.Add(this.cbFatal, 1, 0);
            this.tlpTitle.Controls.Add(this.switchSelect, 8, 0);
            this.tlpTitle.Controls.Add(this.cbError, 2, 0);
            this.tlpTitle.Controls.Add(this.cbOther, 7, 0);
            this.tlpTitle.Controls.Add(this.cbTrace, 6, 0);
            this.tlpTitle.Controls.Add(this.cbDebug, 5, 0);
            this.tlpTitle.Controls.Add(this.cbInfo, 4, 0);
            this.tlpTitle.Controls.Add(this.cbWarn, 3, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(1285, 40);
            this.tlpTitle.TabIndex = 4;
            // 
            // cbFatal
            // 
            this.cbFatal.AutoSize = true;
            this.cbFatal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFatal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbFatal.Location = new System.Drawing.Point(246, 4);
            this.cbFatal.Margin = new System.Windows.Forms.Padding(4);
            this.cbFatal.Name = "cbFatal";
            this.cbFatal.Size = new System.Drawing.Size(92, 32);
            this.cbFatal.TabIndex = 0;
            this.cbFatal.Text = "Fatal";
            this.cbFatal.UseVisualStyleBackColor = true;
            this.cbFatal.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // switchSelect
            // 
            this.switchSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.switchSelect.Location = new System.Drawing.Point(946, 4);
            this.switchSelect.Margin = new System.Windows.Forms.Padding(4);
            this.switchSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.switchSelect.Name = "switchSelect";
            this.switchSelect.Size = new System.Drawing.Size(92, 32);
            this.switchSelect.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.switchSelect.TabIndex = 3;
            this.switchSelect.Text = "uiSwitch1";
            this.switchSelect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.switchSelect.ValueChanged += new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISwitch.OnValueChanged(this.switchSelect_ValueChanged);
            // 
            // cbError
            // 
            this.cbError.AutoSize = true;
            this.cbError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbError.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbError.Location = new System.Drawing.Point(346, 4);
            this.cbError.Margin = new System.Windows.Forms.Padding(4);
            this.cbError.Name = "cbError";
            this.cbError.Size = new System.Drawing.Size(92, 32);
            this.cbError.TabIndex = 0;
            this.cbError.Text = "Error";
            this.cbError.UseVisualStyleBackColor = true;
            this.cbError.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbOther
            // 
            this.cbOther.AutoSize = true;
            this.cbOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbOther.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbOther.Location = new System.Drawing.Point(846, 4);
            this.cbOther.Margin = new System.Windows.Forms.Padding(4);
            this.cbOther.Name = "cbOther";
            this.cbOther.Size = new System.Drawing.Size(92, 32);
            this.cbOther.TabIndex = 0;
            this.cbOther.Text = "Other";
            this.cbOther.UseVisualStyleBackColor = true;
            this.cbOther.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbTrace
            // 
            this.cbTrace.AutoSize = true;
            this.cbTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTrace.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTrace.Location = new System.Drawing.Point(746, 4);
            this.cbTrace.Margin = new System.Windows.Forms.Padding(4);
            this.cbTrace.Name = "cbTrace";
            this.cbTrace.Size = new System.Drawing.Size(92, 32);
            this.cbTrace.TabIndex = 0;
            this.cbTrace.Text = "Trace";
            this.cbTrace.UseVisualStyleBackColor = true;
            this.cbTrace.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbDebug
            // 
            this.cbDebug.AutoSize = true;
            this.cbDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDebug.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDebug.Location = new System.Drawing.Point(646, 4);
            this.cbDebug.Margin = new System.Windows.Forms.Padding(4);
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.Size = new System.Drawing.Size(92, 32);
            this.cbDebug.TabIndex = 0;
            this.cbDebug.Text = "Debug";
            this.cbDebug.UseVisualStyleBackColor = true;
            this.cbDebug.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbInfo
            // 
            this.cbInfo.AutoSize = true;
            this.cbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbInfo.Location = new System.Drawing.Point(546, 4);
            this.cbInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cbInfo.Name = "cbInfo";
            this.cbInfo.Size = new System.Drawing.Size(92, 32);
            this.cbInfo.TabIndex = 0;
            this.cbInfo.Text = "Info";
            this.cbInfo.UseVisualStyleBackColor = true;
            this.cbInfo.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // cbWarn
            // 
            this.cbWarn.AutoSize = true;
            this.cbWarn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbWarn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWarn.Location = new System.Drawing.Point(446, 4);
            this.cbWarn.Margin = new System.Windows.Forms.Padding(4);
            this.cbWarn.Name = "cbWarn";
            this.cbWarn.Size = new System.Drawing.Size(92, 32);
            this.cbWarn.TabIndex = 0;
            this.cbWarn.Text = "Warn";
            this.cbWarn.UseVisualStyleBackColor = true;
            this.cbWarn.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInfo.ColumnHeadersHeight = 32;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnsTime,
            this.columnsLogClassification,
            this.columnsLevel,
            this.columnsMessage});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EnableHeadersVisualStyles = false;
            this.dgvInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.dgvInfo.Location = new System.Drawing.Point(3, 43);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInfo.RowHeadersWidth = 60;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvInfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvInfo.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvInfo.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvInfo.SelectedIndex = -1;
            this.dgvInfo.Size = new System.Drawing.Size(1279, 784);
            this.dgvInfo.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.dgvInfo.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvInfo.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgvInfo.TabIndex = 3;
            this.dgvInfo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // columnsTime
            // 
            this.columnsTime.HeaderText = "时间";
            this.columnsTime.MinimumWidth = 6;
            this.columnsTime.Name = "columnsTime";
            this.columnsTime.Width = 190;
            // 
            // columnsLogClassification
            // 
            this.columnsLogClassification.HeaderText = "分类";
            this.columnsLogClassification.MinimumWidth = 6;
            this.columnsLogClassification.Name = "columnsLogClassification";
            this.columnsLogClassification.Width = 60;
            // 
            // columnsLevel
            // 
            this.columnsLevel.HeaderText = "级别";
            this.columnsLevel.MinimumWidth = 6;
            this.columnsLevel.Name = "columnsLevel";
            this.columnsLevel.Width = 80;
            // 
            // columnsMessage
            // 
            this.columnsMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnsMessage.HeaderText = "信息";
            this.columnsMessage.MinimumWidth = 6;
            this.columnsMessage.Name = "columnsMessage";
            // 
            // alertInfoBindingSource
            // 
            this.alertInfoBindingSource.DataSource = typeof(Lead.CPrim.Interfaces.AlertInfo);
            // 
            // LogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1285, 830);
            this.Controls.Add(this.tlpLog);
            this.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "LogMain";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "日志";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DevLogForm_FormClosing);
            this.Load += new System.EventHandler(this.DevLogForm_Load);
            this.tlpLog.ResumeLayout(false);
            this.pnlUp.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpLog;
        private CheckBox cbFatal;
        private CheckBox cbError;
        private CheckBox cbWarn;
        private CheckBox cbInfo;
        private CheckBox cbDebug;
        private CheckBox cbTrace;
        private CheckBox cbOther;
        private Panel pnlUp;
        private ProxyTools.SunnyUI.Controls.UISwitch switchSelect;
        private UIDataGridView dgvInfo;
        private BindingSource alertInfoBindingSource;
        private TableLayoutPanel tlpTitle;
        private DataGridViewTextBoxColumn columnsTime;
        private DataGridViewTextBoxColumn columnsLogClassification;
        private DataGridViewTextBoxColumn columnsLevel;
        private DataGridViewTextBoxColumn columnsMessage;
    }
}
