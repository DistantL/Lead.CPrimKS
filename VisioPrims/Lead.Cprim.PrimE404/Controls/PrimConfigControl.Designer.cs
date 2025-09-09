namespace Lead.CPrim.PrimE404
{
    partial class PrimConfigControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSlaveId = new System.Windows.Forms.TextBox();
            this.lblSlaveId = new System.Windows.Forms.Label();
            this.btnOpenDemo = new System.Windows.Forms.Button();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtConnState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtRunState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.gbExe = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.chkOpenOtherName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.dgvData = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.colTriggerId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEncoderId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLineCompareMask = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPreCompareMask = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTrigMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colOutMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPulsePolarity = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEncoderMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEncoderDir = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.triggerDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkMonitor = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.lblState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.tlpTitle.SuspendLayout();
            this.gbExe.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triggerDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSlaveId
            // 
            this.txtSlaveId.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSlaveId.Location = new System.Drawing.Point(5, 41);
            this.txtSlaveId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSlaveId.Name = "txtSlaveId";
            this.txtSlaveId.Size = new System.Drawing.Size(80, 25);
            this.txtSlaveId.TabIndex = 177;
            this.txtSlaveId.TextChanged += new System.EventHandler(this.tbDeviceCount_TextChanged);
            // 
            // lblSlaveId
            // 
            this.lblSlaveId.AutoSize = true;
            this.lblSlaveId.BackColor = System.Drawing.Color.Transparent;
            this.lblSlaveId.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSlaveId.Location = new System.Drawing.Point(5, 16);
            this.lblSlaveId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSlaveId.Name = "lblSlaveId";
            this.lblSlaveId.Size = new System.Drawing.Size(48, 19);
            this.lblSlaveId.TabIndex = 176;
            this.lblSlaveId.Text = "从站号";
            // 
            // btnOpenDemo
            // 
            this.btnOpenDemo.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenDemo.Location = new System.Drawing.Point(535, 455);
            this.btnOpenDemo.Name = "btnOpenDemo";
            this.btnOpenDemo.Size = new System.Drawing.Size(75, 30);
            this.btnOpenDemo.TabIndex = 159;
            this.btnOpenDemo.Text = "Demo";
            this.btnOpenDemo.UseVisualStyleBackColor = true;
            this.btnOpenDemo.Click += new System.EventHandler(this.btnOpenDemo_Click);
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 5;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpTitle.Controls.Add(this.label1, 0, 0);
            this.tlpTitle.Controls.Add(this.txtName, 1, 0);
            this.tlpTitle.Controls.Add(this.txtConnState, 3, 0);
            this.tlpTitle.Controls.Add(this.txtRunState, 4, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(800, 44);
            this.tlpTitle.TabIndex = 188;
            this.tlpTitle.TagString = null;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 42);
            this.label1.TabIndex = 12;
            this.label1.Text = "E404";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(182, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(176, 40);
            this.txtName.TabIndex = 13;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtConnState
            // 
            this.txtConnState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConnState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConnState.Location = new System.Drawing.Point(502, 2);
            this.txtConnState.Margin = new System.Windows.Forms.Padding(2);
            this.txtConnState.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtConnState.Name = "txtConnState";
            this.txtConnState.ShowText = false;
            this.txtConnState.Size = new System.Drawing.Size(146, 40);
            this.txtConnState.TabIndex = 13;
            this.txtConnState.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtConnState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRunState
            // 
            this.txtRunState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRunState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRunState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRunState.Location = new System.Drawing.Point(652, 2);
            this.txtRunState.Margin = new System.Windows.Forms.Padding(2);
            this.txtRunState.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtRunState.Name = "txtRunState";
            this.txtRunState.ShowText = false;
            this.txtRunState.Size = new System.Drawing.Size(146, 40);
            this.txtRunState.TabIndex = 13;
            this.txtRunState.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtRunState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // gbExe
            // 
            this.gbExe.Controls.Add(this.btnStop);
            this.gbExe.Controls.Add(this.btnRun);
            this.gbExe.Controls.Add(this.btnInit);
            this.gbExe.Controls.Add(this.btnApply);
            this.gbExe.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbExe.Location = new System.Drawing.Point(10, 427);
            this.gbExe.Name = "gbExe";
            this.gbExe.Size = new System.Drawing.Size(500, 70);
            this.gbExe.TabIndex = 189;
            this.gbExe.TabStop = false;
            this.gbExe.Text = "EXE";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnStop.Location = new System.Drawing.Point(260, 23);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 40);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRun.Location = new System.Drawing.Point(140, 23);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 40);
            this.btnRun.TabIndex = 105;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.SkyBlue;
            this.btnInit.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnInit.Location = new System.Drawing.Point(20, 23);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(100, 40);
            this.btnInit.TabIndex = 105;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnApply.Location = new System.Drawing.Point(380, 23);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 40);
            this.btnApply.TabIndex = 127;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.chkOpenOtherName);
            this.pnlConfig.Controls.Add(this.lblSlaveId);
            this.pnlConfig.Controls.Add(this.txtSlaveId);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfig.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlConfig.Location = new System.Drawing.Point(0, 44);
            this.pnlConfig.Margin = new System.Windows.Forms.Padding(0);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(800, 100);
            this.pnlConfig.TabIndex = 190;
            // 
            // chkOpenOtherName
            // 
            this.chkOpenOtherName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkOpenOtherName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOpenOtherName.Location = new System.Drawing.Point(100, 43);
            this.chkOpenOtherName.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkOpenOtherName.Name = "chkOpenOtherName";
            this.chkOpenOtherName.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkOpenOtherName.Size = new System.Drawing.Size(76, 20);
            this.chkOpenOtherName.TabIndex = 178;
            this.chkOpenOtherName.Text = "开启别名";
            this.chkOpenOtherName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblVersion.Location = new System.Drawing.Point(670, 472);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(31, 20);
            this.lblVersion.TabIndex = 192;
            this.lblVersion.Text = "Ver";
            this.lblVersion.DoubleClick += new System.EventHandler(this.lblVersion_DoubleClick);
            // 
            // dgvData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 32;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTriggerId,
            this.colEncoderId,
            this.colLineCompareMask,
            this.colPreCompareMask,
            this.colTrigMode,
            this.colOutMode,
            this.colPulsePolarity,
            this.colEncoderMode,
            this.colEncoderDir});
            this.dgvData.ContextMenuStrip = this.cms;
            this.dgvData.DataSource = this.triggerDataBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvData.Location = new System.Drawing.Point(0, 144);
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvData.SelectedIndex = -1;
            this.dgvData.Size = new System.Drawing.Size(800, 200);
            this.dgvData.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgvData.TabIndex = 191;
            this.dgvData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvData.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEle_CellEnter);
            this.dgvData.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvEle_CurrentCellDirtyStateChanged);
            this.dgvData.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvData_DataError);
            // 
            // colTriggerId
            // 
            this.colTriggerId.DataPropertyName = "TriggerId";
            this.colTriggerId.HeaderText = "TriggerId";
            this.colTriggerId.Name = "colTriggerId";
            this.colTriggerId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTriggerId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colEncoderId
            // 
            this.colEncoderId.DataPropertyName = "EncoderId";
            this.colEncoderId.HeaderText = "EncoderId";
            this.colEncoderId.Name = "colEncoderId";
            this.colEncoderId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEncoderId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colLineCompareMask
            // 
            this.colLineCompareMask.DataPropertyName = "LineCompareMask";
            this.colLineCompareMask.HeaderText = "LineCompareMask";
            this.colLineCompareMask.Name = "colLineCompareMask";
            this.colLineCompareMask.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLineCompareMask.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPreCompareMask
            // 
            this.colPreCompareMask.DataPropertyName = "PreCompareMask";
            this.colPreCompareMask.HeaderText = "PreCompareMask";
            this.colPreCompareMask.Name = "colPreCompareMask";
            this.colPreCompareMask.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPreCompareMask.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTrigMode
            // 
            this.colTrigMode.DataPropertyName = "TrigMode";
            this.colTrigMode.HeaderText = "TrigMode";
            this.colTrigMode.Name = "colTrigMode";
            this.colTrigMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTrigMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colOutMode
            // 
            this.colOutMode.DataPropertyName = "OutMode";
            this.colOutMode.HeaderText = "OutMode";
            this.colOutMode.Name = "colOutMode";
            this.colOutMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOutMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPulsePolarity
            // 
            this.colPulsePolarity.DataPropertyName = "PulsePolarity";
            this.colPulsePolarity.HeaderText = "PulsePolarity";
            this.colPulsePolarity.Name = "colPulsePolarity";
            this.colPulsePolarity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPulsePolarity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colEncoderMode
            // 
            this.colEncoderMode.DataPropertyName = "EncoderMode";
            this.colEncoderMode.HeaderText = "EncoderMode";
            this.colEncoderMode.Name = "colEncoderMode";
            this.colEncoderMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEncoderMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colEncoderDir
            // 
            this.colEncoderDir.DataPropertyName = "EncoderDir";
            this.colEncoderDir.HeaderText = "EncoderDir";
            this.colEncoderDir.Name = "colEncoderDir";
            this.colEncoderDir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEncoderDir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(100, 22);
            this.tsmiAdd.Text = "新增";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // triggerDataBindingSource
            // 
            this.triggerDataBindingSource.DataSource = typeof(Lead.CPrim.PrimE404.TriggerData);
            // 
            // chkMonitor
            // 
            this.chkMonitor.BackColor = System.Drawing.Color.Transparent;
            this.chkMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMonitor.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chkMonitor.Location = new System.Drawing.Point(10, 390);
            this.chkMonitor.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkMonitor.Name = "chkMonitor";
            this.chkMonitor.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chkMonitor.Size = new System.Drawing.Size(76, 21);
            this.chkMonitor.TabIndex = 194;
            this.chkMonitor.Text = "Monitor";
            this.chkMonitor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.chkMonitor.CheckedChanged += new System.EventHandler(this.chkMonitor_CheckedChanged);
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.Location = new System.Drawing.Point(110, 387);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(420, 26);
            this.lblState.TabIndex = 193;
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tmr
            // 
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // PrimConfigControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.chkMonitor);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.gbExe);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.btnOpenDemo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PrimConfigControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.Load += new System.EventHandler(this.PrimConfigControl_Load);
            this.tlpTitle.ResumeLayout(false);
            this.gbExe.ResumeLayout(false);
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.triggerDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenDemo;
        private System.Windows.Forms.TextBox txtSlaveId;
        private System.Windows.Forms.Label lblSlaveId;
        private ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpTitle;
        private System.Windows.Forms.Label label1;
        private ProxyTools.SunnyUI.Controls.UITextBox txtName;
        private ProxyTools.SunnyUI.Controls.UITextBox txtConnState;
        private ProxyTools.SunnyUI.Controls.UITextBox txtRunState;
        private System.Windows.Forms.GroupBox gbExe;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.BindingSource triggerDataBindingSource;
        private ProxyTools.SunnyUI.Controls.UIDataGridView dgvData;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private ProxyTools.SunnyUI.Controls.UICheckBox chkOpenOtherName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTriggerId;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEncoderId;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLineCompareMask;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPreCompareMask;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTrigMode;
        private System.Windows.Forms.DataGridViewComboBoxColumn colOutMode;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPulsePolarity;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEncoderMode;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEncoderDir;
        private ProxyTools.SunnyUI.Controls.UICheckBox chkMonitor;
        private ProxyTools.SunnyUI.Controls.UILabel lblState;
        private System.Windows.Forms.Timer tmr;
    }
}
