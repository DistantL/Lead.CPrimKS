
namespace Lead.CPrim.ProxyTools
{
    partial class TossingInfoStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpStatic = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lb_Title = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.dgv_Tossing = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.reasonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.显示原因 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpStatic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tossing)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpStatic
            // 
            this.tlpStatic.BackColor = System.Drawing.Color.LightGray;
            this.tlpStatic.ColumnCount = 4;
            this.tlpStatic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpStatic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatic.Controls.Add(this.lb_Title, 1, 1);
            this.tlpStatic.Controls.Add(this.dgv_Tossing, 1, 2);
            this.tlpStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatic.Location = new System.Drawing.Point(0, 0);
            this.tlpStatic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 3);
            this.tlpStatic.Name = "tlpStatic";
            this.tlpStatic.RowCount = 3;
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatic.Size = new System.Drawing.Size(376, 306);
            this.tlpStatic.TabIndex = 54;
            this.tlpStatic.TagString = null;
            // 
            // lb_Title
            // 
            this.lb_Title.AutoSize = true;
            this.lb_Title.BackColor = System.Drawing.Color.Transparent;
            this.tlpStatic.SetColumnSpan(this.lb_Title, 2);
            this.lb_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Title.Location = new System.Drawing.Point(23, 100);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(330, 30);
            this.lb_Title.TabIndex = 0;
            this.lb_Title.Text = "Tossing Summary";
            this.lb_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Title.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dgv_Tossing
            // 
            this.dgv_Tossing.AllowUserToAddRows = false;
            this.dgv_Tossing.AllowUserToDeleteRows = false;
            this.dgv_Tossing.AllowUserToResizeColumns = false;
            this.dgv_Tossing.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_Tossing.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Tossing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Tossing.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgv_Tossing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Tossing.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Tossing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Tossing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Tossing.ColumnHeadersHeight = 32;
            this.dgv_Tossing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Tossing.ColumnHeadersVisible = false;
            this.dgv_Tossing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reasonName,
            this.显示原因,
            this.Value});
            this.tlpStatic.SetColumnSpan(this.dgv_Tossing, 2);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Tossing.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Tossing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Tossing.EnableHeadersVisualStyles = false;
            this.dgv_Tossing.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Tossing.GridColor = System.Drawing.Color.Black;
            this.dgv_Tossing.Location = new System.Drawing.Point(23, 133);
            this.dgv_Tossing.MultiSelect = false;
            this.dgv_Tossing.Name = "dgv_Tossing";
            this.dgv_Tossing.ReadOnly = true;
            this.dgv_Tossing.RectColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Tossing.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Tossing.RowHeadersVisible = false;
            this.dgv_Tossing.RowHeadersWidth = 5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_Tossing.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Tossing.RowTemplate.Height = 30;
            this.dgv_Tossing.RowTemplate.ReadOnly = true;
            this.dgv_Tossing.ScrollBarBackColor = System.Drawing.Color.LightGray;
            this.dgv_Tossing.ScrollBarColor = System.Drawing.Color.Gray;
            this.dgv_Tossing.ScrollBarRectColor = System.Drawing.Color.Gray;
            this.dgv_Tossing.SelectedIndex = -1;
            this.dgv_Tossing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Tossing.Size = new System.Drawing.Size(330, 170);
            this.dgv_Tossing.StripeEvenColor = System.Drawing.Color.LightGray;
            this.dgv_Tossing.StripeOddColor = System.Drawing.Color.LightGray;
            this.dgv_Tossing.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgv_Tossing.StyleCustomMode = true;
            this.dgv_Tossing.TabIndex = 1;
            this.dgv_Tossing.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // reasonName
            // 
            this.reasonName.DataPropertyName = "Name";
            this.reasonName.FillWeight = 5F;
            this.reasonName.HeaderText = "原因";
            this.reasonName.Name = "reasonName";
            this.reasonName.ReadOnly = true;
            this.reasonName.Visible = false;
            // 
            // 显示原因
            // 
            this.显示原因.DataPropertyName = "DisplayName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.显示原因.DefaultCellStyle = dataGridViewCellStyle3;
            this.显示原因.HeaderText = "显示原因";
            this.显示原因.Name = "显示原因";
            this.显示原因.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Count";
            this.Value.FillWeight = 25F;
            this.Value.HeaderText = "个数";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // TossingInfoStatistics
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(376, 306);
            this.Controls.Add(this.tlpStatic);
            this.Name = "TossingInfoStatistics";
            this.tlpStatic.ResumeLayout(false);
            this.tlpStatic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tossing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SunnyUI.Controls.UITableLayoutPanel tlpStatic;
        private SunnyUI.Controls.UILabel lb_Title;
        private SunnyUI.Controls.UIDataGridView dgv_Tossing;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 显示原因;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}
