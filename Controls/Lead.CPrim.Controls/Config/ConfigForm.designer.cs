
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.Controls
{
    partial class ConfigForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMachineConfigs = new System.Windows.Forms.Panel();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dgvSpecLimit = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.KeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnSave = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnEdit = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.tlpMain.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecLimit)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.Controls.Add(this.pnlMachineConfigs, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(802, 501);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlMachineConfigs
            // 
            this.pnlMachineConfigs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMachineConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMachineConfigs.Location = new System.Drawing.Point(5, 5);
            this.pnlMachineConfigs.Margin = new System.Windows.Forms.Padding(5);
            this.pnlMachineConfigs.Name = "pnlMachineConfigs";
            this.pnlMachineConfigs.Size = new System.Drawing.Size(524, 491);
            this.pnlMachineConfigs.TabIndex = 0;
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.pnlTitle, 0, 0);
            this.tlpRight.Controls.Add(this.pnlDgv, 0, 1);
            this.tlpRight.Controls.Add(this.pnlButton, 0, 2);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(534, 0);
            this.tlpRight.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 3;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRight.Size = new System.Drawing.Size(268, 501);
            this.tlpRight.TabIndex = 1;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblName);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(268, 40);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(268, 40);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Spec Limits";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.lblName.DoubleClick += new System.EventHandler(this.lblName_DoubleClick);
            // 
            // pnlDgv
            // 
            this.pnlDgv.Controls.Add(this.dgvSpecLimit);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(0, 40);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlDgv.Size = new System.Drawing.Size(268, 421);
            this.pnlDgv.TabIndex = 1;
            // 
            // dgvSpecLimit
            // 
            this.dgvSpecLimit.AllowUserToAddRows = false;
            this.dgvSpecLimit.AllowUserToDeleteRows = false;
            this.dgvSpecLimit.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvSpecLimit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSpecLimit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvSpecLimit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSpecLimit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpecLimit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSpecLimit.ColumnHeadersHeight = 32;
            this.dgvSpecLimit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSpecLimit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyName,
            this.LSL,
            this.USL});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpecLimit.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSpecLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpecLimit.EnableHeadersVisualStyles = false;
            this.dgvSpecLimit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvSpecLimit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvSpecLimit.Location = new System.Drawing.Point(10, 0);
            this.dgvSpecLimit.Margin = new System.Windows.Forms.Padding(0);
            this.dgvSpecLimit.Name = "dgvSpecLimit";
            this.dgvSpecLimit.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpecLimit.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSpecLimit.RowHeadersVisible = false;
            this.dgvSpecLimit.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvSpecLimit.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSpecLimit.RowTemplate.Height = 27;
            this.dgvSpecLimit.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvSpecLimit.SelectedIndex = -1;
            this.dgvSpecLimit.Size = new System.Drawing.Size(248, 421);
            this.dgvSpecLimit.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgvSpecLimit.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgvSpecLimit.TabIndex = 2;
            this.dgvSpecLimit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // KeyName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.KeyName.DefaultCellStyle = dataGridViewCellStyle3;
            this.KeyName.FillWeight = 150F;
            this.KeyName.HeaderText = "Key Name";
            this.KeyName.MinimumWidth = 6;
            this.KeyName.Name = "KeyName";
            this.KeyName.ReadOnly = true;
            this.KeyName.Width = 112;
            // 
            // LSL
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LSL.DefaultCellStyle = dataGridViewCellStyle4;
            this.LSL.HeaderText = "LSL";
            this.LSL.MinimumWidth = 6;
            this.LSL.Name = "LSL";
            this.LSL.ReadOnly = true;
            this.LSL.Width = 75;
            // 
            // USL
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.USL.DefaultCellStyle = dataGridViewCellStyle5;
            this.USL.HeaderText = "USL";
            this.USL.MinimumWidth = 6;
            this.USL.Name = "USL";
            this.USL.ReadOnly = true;
            this.USL.Width = 75;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnSave);
            this.pnlButton.Controls.Add(this.btnEdit);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButton.Location = new System.Drawing.Point(0, 461);
            this.pnlButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(268, 40);
            this.pnlButton.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(159, 7);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(40, 7);
            this.btnEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 29);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(802, 501);
            this.Controls.Add(this.tlpMain);
            this.Name = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecLimit)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private UIDataGridView dgvSpecLimit;
        private UILabel lblName;
        private System.Windows.Forms.Panel pnlMachineConfigs;
        private UIButton btnEdit;
        private UIButton btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn USL;
    }
}
