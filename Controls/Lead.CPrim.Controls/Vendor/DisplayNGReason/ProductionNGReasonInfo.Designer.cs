using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.Controls
{
    partial class UIProductionNGReasonInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRtData = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出所有SNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_Update = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lb_NextUpdateTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.timer_Update = new System.Windows.Forms.Timer(this.components);
            this.timer_UpdateTime = new System.Windows.Forms.Timer(this.components);
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Component_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HIVE_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fai2D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fai3D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessaryInProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlotIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRtData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRtData
            // 
            this.dgvRtData.AllowUserToAddRows = false;
            this.dgvRtData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvRtData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRtData.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvRtData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRtData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRtData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRtData.ColumnHeadersHeight = 32;
            this.dgvRtData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRtData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Shift,
            this.Unit_SN,
            this.Start_Time,
            this.End_Time,
            this.Component_SN,
            this.Pass,
            this.CT_s,
            this.ProductType,
            this.HIVE_State,
            this.Fai,
            this.Fai2D,
            this.Fai3D,
            this.AccessaryInProduct,
            this.SlotIndex});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvRtData, 2);
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRtData.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvRtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRtData.EnableHeadersVisualStyles = false;
            this.dgvRtData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvRtData.GridColor = System.Drawing.Color.Black;
            this.dgvRtData.Location = new System.Drawing.Point(3, 36);
            this.dgvRtData.Name = "dgvRtData";
            this.dgvRtData.RectColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRtData.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvRtData.RowHeadersVisible = false;
            this.dgvRtData.RowHeadersWidth = 62;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvRtData.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvRtData.RowTemplate.Height = 23;
            this.dgvRtData.ScrollBarBackColor = System.Drawing.Color.LightGray;
            this.dgvRtData.ScrollBarColor = System.Drawing.Color.DarkGray;
            this.dgvRtData.ScrollBarRectColor = System.Drawing.Color.LightGray;
            this.dgvRtData.SelectedIndex = -1;
            this.dgvRtData.Size = new System.Drawing.Size(1105, 197);
            this.dgvRtData.StripeEvenColor = System.Drawing.Color.Empty;
            this.dgvRtData.StripeOddColor = System.Drawing.Color.Empty;
            this.dgvRtData.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgvRtData.StyleCustomMode = true;
            this.dgvRtData.TabIndex = 0;
            this.dgvRtData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvRtData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRtData_CellFormatting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.导出所有SNToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 52);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 导出所有SNToolStripMenuItem
            // 
            this.导出所有SNToolStripMenuItem.Name = "导出所有SNToolStripMenuItem";
            this.导出所有SNToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.导出所有SNToolStripMenuItem.Text = "导出所有SN";
            this.导出所有SNToolStripMenuItem.Click += new System.EventHandler(this.导出所有SNToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvRtData, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.bt_Update, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_NextUpdateTime, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1111, 256);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bt_Update
            // 
            this.bt_Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_Update.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Update.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Update.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_Update.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Update.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Update.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Update.Location = new System.Drawing.Point(3, 3);
            this.bt_Update.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_Update.Name = "bt_Update";
            this.bt_Update.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Update.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_Update.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Update.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Update.Size = new System.Drawing.Size(94, 27);
            this.bt_Update.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.bt_Update.StyleCustomMode = true;
            this.bt_Update.TabIndex = 1;
            this.bt_Update.Text = "更新";
            this.bt_Update.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Update.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bt_Update.Click += new System.EventHandler(this.bt_Update_Click);
            // 
            // lb_NextUpdateTime
            // 
            this.lb_NextUpdateTime.AutoSize = true;
            this.lb_NextUpdateTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_NextUpdateTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_NextUpdateTime.Location = new System.Drawing.Point(103, 0);
            this.lb_NextUpdateTime.Name = "lb_NextUpdateTime";
            this.lb_NextUpdateTime.Size = new System.Drawing.Size(54, 33);
            this.lb_NextUpdateTime.TabIndex = 2;
            this.lb_NextUpdateTime.Text = "time";
            this.lb_NextUpdateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_NextUpdateTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // timer_Update
            // 
            this.timer_Update.Enabled = true;
            this.timer_Update.Interval = 600000;
            this.timer_Update.Tick += new System.EventHandler(this.timer_Update_Tick);
            // 
            // timer_UpdateTime
            // 
            this.timer_UpdateTime.Enabled = true;
            this.timer_UpdateTime.Interval = 1000;
            this.timer_UpdateTime.Tick += new System.EventHandler(this.timer_UpdateTime_Tick);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "CreateTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle3;
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 80;
            // 
            // Shift
            // 
            this.Shift.DataPropertyName = "Shift";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Shift.DefaultCellStyle = dataGridViewCellStyle4;
            this.Shift.HeaderText = "Shift";
            this.Shift.MinimumWidth = 6;
            this.Shift.Name = "Shift";
            this.Shift.ReadOnly = true;
            this.Shift.Width = 60;
            // 
            // Unit_SN
            // 
            this.Unit_SN.DataPropertyName = "FixtureID";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Unit_SN.DefaultCellStyle = dataGridViewCellStyle5;
            this.Unit_SN.HeaderText = "Unit SN";
            this.Unit_SN.MinimumWidth = 6;
            this.Unit_SN.Name = "Unit_SN";
            this.Unit_SN.ReadOnly = true;
            this.Unit_SN.Width = 200;
            // 
            // Start_Time
            // 
            this.Start_Time.DataPropertyName = "CreateTime";
            dataGridViewCellStyle6.Format = "HH:mm:ss:ff";
            this.Start_Time.DefaultCellStyle = dataGridViewCellStyle6;
            this.Start_Time.HeaderText = "Start Time";
            this.Start_Time.MinimumWidth = 6;
            this.Start_Time.Name = "Start_Time";
            this.Start_Time.ReadOnly = true;
            this.Start_Time.Width = 125;
            // 
            // End_Time
            // 
            this.End_Time.DataPropertyName = "EndTime";
            dataGridViewCellStyle7.Format = "HH:mm:ss:ff";
            this.End_Time.DefaultCellStyle = dataGridViewCellStyle7;
            this.End_Time.HeaderText = "End Time";
            this.End_Time.MinimumWidth = 6;
            this.End_Time.Name = "End_Time";
            this.End_Time.ReadOnly = true;
            this.End_Time.Width = 125;
            // 
            // Component_SN
            // 
            this.Component_SN.ContextMenuStrip = this.contextMenuStrip1;
            this.Component_SN.DataPropertyName = "Sn";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Component_SN.DefaultCellStyle = dataGridViewCellStyle8;
            this.Component_SN.HeaderText = "Sn";
            this.Component_SN.MinimumWidth = 6;
            this.Component_SN.Name = "Component_SN";
            this.Component_SN.ReadOnly = true;
            this.Component_SN.Width = 175;
            // 
            // Pass
            // 
            this.Pass.DataPropertyName = "Result";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle9.NullValue = null;
            this.Pass.DefaultCellStyle = dataGridViewCellStyle9;
            this.Pass.HeaderText = "Pass";
            this.Pass.MinimumWidth = 6;
            this.Pass.Name = "Pass";
            this.Pass.ReadOnly = true;
            this.Pass.Width = 50;
            // 
            // CT_s
            // 
            this.CT_s.DataPropertyName = "CT";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.CT_s.DefaultCellStyle = dataGridViewCellStyle10;
            this.CT_s.HeaderText = "CT/s";
            this.CT_s.MinimumWidth = 6;
            this.CT_s.Name = "CT_s";
            this.CT_s.ReadOnly = true;
            this.CT_s.Width = 70;
            // 
            // ProductType
            // 
            this.ProductType.DataPropertyName = "ProductType";
            this.ProductType.HeaderText = "ProductType";
            this.ProductType.MinimumWidth = 6;
            this.ProductType.Name = "ProductType";
            this.ProductType.ReadOnly = true;
            this.ProductType.Visible = false;
            this.ProductType.Width = 125;
            // 
            // HIVE_State
            // 
            this.HIVE_State.DataPropertyName = "HIVE_State";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HIVE_State.DefaultCellStyle = dataGridViewCellStyle11;
            this.HIVE_State.HeaderText = "HIVE State";
            this.HIVE_State.MinimumWidth = 6;
            this.HIVE_State.Name = "HIVE_State";
            this.HIVE_State.ReadOnly = true;
            this.HIVE_State.Width = 125;
            // 
            // Fai
            // 
            this.Fai.DataPropertyName = "Fai";
            this.Fai.HeaderText = "Fai";
            this.Fai.MinimumWidth = 6;
            this.Fai.Name = "Fai";
            this.Fai.ReadOnly = true;
            this.Fai.Visible = false;
            this.Fai.Width = 50;
            // 
            // Fai2D
            // 
            this.Fai2D.DataPropertyName = "Fai2D";
            this.Fai2D.HeaderText = "Fai2D";
            this.Fai2D.MinimumWidth = 6;
            this.Fai2D.Name = "Fai2D";
            this.Fai2D.ReadOnly = true;
            this.Fai2D.Visible = false;
            this.Fai2D.Width = 50;
            // 
            // Fai3D
            // 
            this.Fai3D.DataPropertyName = "Fai3D";
            this.Fai3D.HeaderText = "Fai3D";
            this.Fai3D.MinimumWidth = 6;
            this.Fai3D.Name = "Fai3D";
            this.Fai3D.ReadOnly = true;
            this.Fai3D.Visible = false;
            this.Fai3D.Width = 50;
            // 
            // AccessaryInProduct
            // 
            this.AccessaryInProduct.DataPropertyName = "AccessaryCount";
            this.AccessaryInProduct.HeaderText = "AccessaryInProduct";
            this.AccessaryInProduct.MinimumWidth = 6;
            this.AccessaryInProduct.Name = "AccessaryInProduct";
            this.AccessaryInProduct.ReadOnly = true;
            this.AccessaryInProduct.Visible = false;
            this.AccessaryInProduct.Width = 50;
            // 
            // SlotIndex
            // 
            this.SlotIndex.DataPropertyName = "SlotIndex";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SlotIndex.DefaultCellStyle = dataGridViewCellStyle12;
            this.SlotIndex.HeaderText = "工位";
            this.SlotIndex.MinimumWidth = 6;
            this.SlotIndex.Name = "SlotIndex";
            this.SlotIndex.ReadOnly = true;
            this.SlotIndex.Width = 50;
            // 
            // UIProductionNGReasonInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UIProductionNGReasonInfo";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Size = new System.Drawing.Size(1111, 256);
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvRtData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UIDataGridView dgvRtData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UIButton bt_Update;
        private UILabel lb_NextUpdateTime;
        private System.Windows.Forms.Timer timer_Update;
        private System.Windows.Forms.Timer timer_UpdateTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出所有SNToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shift;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn End_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_s;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn HIVE_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fai2D;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fai3D;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessaryInProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotIndex;
    }
}
