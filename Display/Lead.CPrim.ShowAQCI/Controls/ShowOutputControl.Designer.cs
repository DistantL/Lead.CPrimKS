namespace Lead.CPrim.ShowAQCI.Controls
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grpProductInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label28 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbProType = new System.Windows.Forms.Label();
            this.cmbProColor = new System.Windows.Forms.ComboBox();
            this.grpStatics = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbCt = new System.Windows.Forms.Label();
            this.lbNgNum = new System.Windows.Forms.Label();
            this.lbOkNum = new System.Windows.Forms.Label();
            this.lbPassRate = new System.Windows.Forms.Label();
            this.lbTotalNum = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.btnClearStatistics = new System.Windows.Forms.Button();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.cmsDgvResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbDatas = new System.Windows.Forms.TabControl();
            this.机台数据 = new System.Windows.Forms.TabPage();
            this.dgvRtData = new System.Windows.Forms.DataGridView();
            this.按小时统计 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelProShow = new System.Windows.Forms.Panel();
            this.grpRtData = new System.Windows.Forms.GroupBox();
            this.splitProInfo = new System.Windows.Forms.SplitContainer();
            this.smShow = new Lead.CPrim.ShowAQCI.Controls.OperateInstruction();
            this.grpProductInfo.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grpStatics.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.cmsDgvResult.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tbDatas.SuspendLayout();
            this.机台数据.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRtData)).BeginInit();
            this.按小时统计.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panelProShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitProInfo)).BeginInit();
            this.splitProInfo.Panel1.SuspendLayout();
            this.splitProInfo.Panel2.SuspendLayout();
            this.splitProInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProductInfo
            // 
            this.grpProductInfo.Controls.Add(this.tableLayoutPanel3);
            this.grpProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProductInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpProductInfo.Location = new System.Drawing.Point(0, 0);
            this.grpProductInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grpProductInfo.Name = "grpProductInfo";
            this.grpProductInfo.Padding = new System.Windows.Forms.Padding(0);
            this.grpProductInfo.Size = new System.Drawing.Size(420, 64);
            this.grpProductInfo.TabIndex = 42;
            this.grpProductInfo.TabStop = false;
            this.grpProductInfo.Text = "产品信息";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.label28, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbBarCode, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label14, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbProType, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbProColor, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(420, 48);
            this.tableLayoutPanel3.TabIndex = 43;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Gray;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(0, 24);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(84, 24);
            this.label28.TabIndex = 9;
            this.label28.Text = "颜色";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "条码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbBarCode
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.tbBarCode, 3);
            this.tbBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBarCode.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbBarCode.Location = new System.Drawing.Point(84, 0);
            this.tbBarCode.Margin = new System.Windows.Forms.Padding(0);
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.Size = new System.Drawing.Size(336, 27);
            this.tbBarCode.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Gray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(210, 24);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 24);
            this.label14.TabIndex = 2;
            this.label14.Text = "型号";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbProType
            // 
            this.lbProType.AutoSize = true;
            this.lbProType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbProType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbProType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProType.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbProType.ForeColor = System.Drawing.Color.Black;
            this.lbProType.Location = new System.Drawing.Point(294, 24);
            this.lbProType.Margin = new System.Windows.Forms.Padding(0);
            this.lbProType.Name = "lbProType";
            this.lbProType.Size = new System.Drawing.Size(126, 24);
            this.lbProType.TabIndex = 7;
            this.lbProType.Text = "ABC";
            this.lbProType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbProColor
            // 
            this.cmbProColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProColor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProColor.FormattingEnabled = true;
            this.cmbProColor.Location = new System.Drawing.Point(87, 27);
            this.cmbProColor.Name = "cmbProColor";
            this.cmbProColor.Size = new System.Drawing.Size(120, 27);
            this.cmbProColor.TabIndex = 10;
            this.cmbProColor.SelectedIndexChanged += new System.EventHandler(this.cmbProColor_SelectedIndexChanged);
            // 
            // grpStatics
            // 
            this.grpStatics.Controls.Add(this.tableLayoutPanel4);
            this.grpStatics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatics.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpStatics.Location = new System.Drawing.Point(0, 0);
            this.grpStatics.Margin = new System.Windows.Forms.Padding(0);
            this.grpStatics.Name = "grpStatics";
            this.grpStatics.Padding = new System.Windows.Forms.Padding(0);
            this.grpStatics.Size = new System.Drawing.Size(420, 72);
            this.grpStatics.TabIndex = 43;
            this.grpStatics.TabStop = false;
            this.grpStatics.Text = "检测统计";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Controls.Add(this.lbCt, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbNgNum, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbOkNum, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbPassRate, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbTotalNum, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label36, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label32, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label33, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label35, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnClearStatistics, 5, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(420, 56);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lbCt
            // 
            this.lbCt.AutoSize = true;
            this.lbCt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbCt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCt.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCt.ForeColor = System.Drawing.Color.Black;
            this.lbCt.Location = new System.Drawing.Point(0, 28);
            this.lbCt.Margin = new System.Windows.Forms.Padding(0);
            this.lbCt.Name = "lbCt";
            this.lbCt.Size = new System.Drawing.Size(69, 28);
            this.lbCt.TabIndex = 14;
            this.lbCt.Text = "0";
            this.lbCt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNgNum
            // 
            this.lbNgNum.AutoSize = true;
            this.lbNgNum.BackColor = System.Drawing.Color.Gray;
            this.lbNgNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNgNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNgNum.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNgNum.ForeColor = System.Drawing.Color.Black;
            this.lbNgNum.Location = new System.Drawing.Point(138, 28);
            this.lbNgNum.Margin = new System.Windows.Forms.Padding(0);
            this.lbNgNum.Name = "lbNgNum";
            this.lbNgNum.Size = new System.Drawing.Size(69, 28);
            this.lbNgNum.TabIndex = 13;
            this.lbNgNum.Text = "0";
            this.lbNgNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOkNum
            // 
            this.lbOkNum.AutoSize = true;
            this.lbOkNum.BackColor = System.Drawing.Color.Gray;
            this.lbOkNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOkNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOkNum.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOkNum.ForeColor = System.Drawing.Color.Black;
            this.lbOkNum.Location = new System.Drawing.Point(69, 28);
            this.lbOkNum.Margin = new System.Windows.Forms.Padding(0);
            this.lbOkNum.Name = "lbOkNum";
            this.lbOkNum.Size = new System.Drawing.Size(69, 28);
            this.lbOkNum.TabIndex = 12;
            this.lbOkNum.Text = "0";
            this.lbOkNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPassRate
            // 
            this.lbPassRate.AutoSize = true;
            this.lbPassRate.BackColor = System.Drawing.Color.Gray;
            this.lbPassRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPassRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPassRate.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPassRate.ForeColor = System.Drawing.Color.Black;
            this.lbPassRate.Location = new System.Drawing.Point(276, 28);
            this.lbPassRate.Margin = new System.Windows.Forms.Padding(0);
            this.lbPassRate.Name = "lbPassRate";
            this.lbPassRate.Size = new System.Drawing.Size(69, 28);
            this.lbPassRate.TabIndex = 11;
            this.lbPassRate.Text = "100%";
            this.lbPassRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalNum
            // 
            this.lbTotalNum.AutoSize = true;
            this.lbTotalNum.BackColor = System.Drawing.Color.Gray;
            this.lbTotalNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotalNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotalNum.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalNum.ForeColor = System.Drawing.Color.Black;
            this.lbTotalNum.Location = new System.Drawing.Point(207, 28);
            this.lbTotalNum.Margin = new System.Windows.Forms.Padding(0);
            this.lbTotalNum.Name = "lbTotalNum";
            this.lbTotalNum.Size = new System.Drawing.Size(69, 28);
            this.lbTotalNum.TabIndex = 10;
            this.lbTotalNum.Text = "0";
            this.lbTotalNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 28);
            this.label9.TabIndex = 2;
            this.label9.Text = "CT/S";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Gray;
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(69, 0);
            this.label36.Margin = new System.Windows.Forms.Padding(0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(69, 28);
            this.label36.TabIndex = 6;
            this.label36.Text = "OK数";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Gray;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label32.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(138, 0);
            this.label32.Margin = new System.Windows.Forms.Padding(0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(69, 28);
            this.label32.TabIndex = 7;
            this.label32.Text = "NG数";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Gray;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(207, 0);
            this.label33.Margin = new System.Windows.Forms.Padding(0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 28);
            this.label33.TabIndex = 8;
            this.label33.Text = "总数";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Gray;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.label35, 2);
            this.label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label35.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(276, 0);
            this.label35.Margin = new System.Windows.Forms.Padding(0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(144, 28);
            this.label35.TabIndex = 9;
            this.label35.Text = "良率";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClearStatistics
            // 
            this.btnClearStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearStatistics.Location = new System.Drawing.Point(345, 28);
            this.btnClearStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearStatistics.Name = "btnClearStatistics";
            this.btnClearStatistics.Size = new System.Drawing.Size(75, 28);
            this.btnClearStatistics.TabIndex = 15;
            this.btnClearStatistics.Text = "清零";
            this.btnClearStatistics.UseVisualStyleBackColor = true;
            this.btnClearStatistics.Click += new System.EventHandler(this.btnClearStatistics_Click);
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.lbResult);
            this.grpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResult.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpResult.Location = new System.Drawing.Point(422, 1);
            this.grpResult.Margin = new System.Windows.Forms.Padding(0);
            this.grpResult.Name = "grpResult";
            this.grpResult.Padding = new System.Windows.Forms.Padding(0);
            this.grpResult.Size = new System.Drawing.Size(138, 140);
            this.grpResult.TabIndex = 44;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "结果";
            // 
            // lbResult
            // 
            this.lbResult.BackColor = System.Drawing.Color.Gray;
            this.lbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResult.Font = new System.Drawing.Font("宋体", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbResult.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbResult.Location = new System.Drawing.Point(0, 16);
            this.lbResult.Margin = new System.Windows.Forms.Padding(0);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(138, 124);
            this.lbResult.TabIndex = 43;
            this.lbResult.Text = "-";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsDgvResult
            // 
            this.cmsDgvResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsDgvResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDgvResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.cmsDgvResult.Name = "contextMenuStrip";
            this.cmsDgvResult.Size = new System.Drawing.Size(127, 48);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.clearToolStripMenuItem.Text = "清除数据";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.exportToolStripMenuItem.Text = "导出数据";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.52631F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.36842F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.10527F));
            this.tlpMain.Controls.Add(this.tbDatas, 0, 1);
            this.tlpMain.Controls.Add(this.panelProShow, 0, 2);
            this.tlpMain.Controls.Add(this.grpResult, 1, 0);
            this.tlpMain.Controls.Add(this.splitProInfo, 0, 0);
            this.tlpMain.Controls.Add(this.smShow, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Size = new System.Drawing.Size(1222, 566);
            this.tlpMain.TabIndex = 46;
            // 
            // tbDatas
            // 
            this.tlpMain.SetColumnSpan(this.tbDatas, 3);
            this.tbDatas.Controls.Add(this.机台数据);
            this.tbDatas.Controls.Add(this.按小时统计);
            this.tbDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDatas.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDatas.ItemSize = new System.Drawing.Size(120, 22);
            this.tbDatas.Location = new System.Drawing.Point(1, 142);
            this.tbDatas.Margin = new System.Windows.Forms.Padding(0);
            this.tbDatas.Name = "tbDatas";
            this.tbDatas.Padding = new System.Drawing.Point(0, 0);
            this.tbDatas.SelectedIndex = 0;
            this.tbDatas.Size = new System.Drawing.Size(1220, 281);
            this.tbDatas.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbDatas.TabIndex = 48;
            // 
            // 机台数据
            // 
            this.机台数据.Controls.Add(this.dgvRtData);
            this.机台数据.Location = new System.Drawing.Point(4, 26);
            this.机台数据.Margin = new System.Windows.Forms.Padding(0);
            this.机台数据.Name = "机台数据";
            this.机台数据.Size = new System.Drawing.Size(1212, 251);
            this.机台数据.TabIndex = 0;
            this.机台数据.Text = "机台数据";
            this.机台数据.UseVisualStyleBackColor = true;
            // 
            // dgvRtData
            // 
            this.dgvRtData.AllowUserToAddRows = false;
            this.dgvRtData.AllowUserToDeleteRows = false;
            this.dgvRtData.AllowUserToOrderColumns = true;
            this.dgvRtData.AllowUserToResizeColumns = false;
            this.dgvRtData.AllowUserToResizeRows = false;
            this.dgvRtData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRtData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRtData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRtData.ContextMenuStrip = this.cmsDgvResult;
            this.dgvRtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRtData.Location = new System.Drawing.Point(0, 0);
            this.dgvRtData.Margin = new System.Windows.Forms.Padding(0);
            this.dgvRtData.Name = "dgvRtData";
            this.dgvRtData.ReadOnly = true;
            this.dgvRtData.RowHeadersVisible = false;
            this.dgvRtData.RowHeadersWidth = 51;
            this.dgvRtData.RowTemplate.Height = 40;
            this.dgvRtData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRtData.Size = new System.Drawing.Size(1212, 251);
            this.dgvRtData.TabIndex = 45;
            // 
            // 按小时统计
            // 
            this.按小时统计.Controls.Add(this.chart1);
            this.按小时统计.Location = new System.Drawing.Point(4, 26);
            this.按小时统计.Margin = new System.Windows.Forms.Padding(0);
            this.按小时统计.Name = "按小时统计";
            this.按小时统计.Size = new System.Drawing.Size(1212, 251);
            this.按小时统计.TabIndex = 1;
            this.按小时统计.Text = "按小时统计";
            this.按小时统计.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowOffset = 5;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1212, 251);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panelProShow
            // 
            this.panelProShow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelProShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tlpMain.SetColumnSpan(this.panelProShow, 3);
            this.panelProShow.Controls.Add(this.grpRtData);
            this.panelProShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProShow.Location = new System.Drawing.Point(1, 424);
            this.panelProShow.Margin = new System.Windows.Forms.Padding(0);
            this.panelProShow.Name = "panelProShow";
            this.panelProShow.Size = new System.Drawing.Size(1220, 141);
            this.panelProShow.TabIndex = 45;
            this.panelProShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelProShow_MouseDown);
            // 
            // grpRtData
            // 
            this.grpRtData.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpRtData.Location = new System.Drawing.Point(54, 41);
            this.grpRtData.Name = "grpRtData";
            this.grpRtData.Size = new System.Drawing.Size(72, 53);
            this.grpRtData.TabIndex = 47;
            this.grpRtData.TabStop = false;
            this.grpRtData.Text = "测量结果";
            // 
            // splitProInfo
            // 
            this.splitProInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProInfo.Location = new System.Drawing.Point(1, 1);
            this.splitProInfo.Margin = new System.Windows.Forms.Padding(0);
            this.splitProInfo.Name = "splitProInfo";
            this.splitProInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitProInfo.Panel1
            // 
            this.splitProInfo.Panel1.Controls.Add(this.grpProductInfo);
            // 
            // splitProInfo.Panel2
            // 
            this.splitProInfo.Panel2.Controls.Add(this.grpStatics);
            this.splitProInfo.Size = new System.Drawing.Size(420, 140);
            this.splitProInfo.SplitterDistance = 64;
            this.splitProInfo.TabIndex = 46;
            // 
            // smShow
            // 
            this.smShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smShow.Location = new System.Drawing.Point(561, 1);
            this.smShow.Margin = new System.Windows.Forms.Padding(0);
            this.smShow.Name = "smShow";
            this.smShow.Size = new System.Drawing.Size(660, 140);
            this.smShow.TabIndex = 47;
            // 
            // ShowOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowOutputControl";
            this.Size = new System.Drawing.Size(1222, 566);
            this.Load += new System.EventHandler(this.ShowOutputControl_Load);
            this.grpProductInfo.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.grpStatics.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.grpResult.ResumeLayout(false);
            this.cmsDgvResult.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tbDatas.ResumeLayout(false);
            this.机台数据.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRtData)).EndInit();
            this.按小时统计.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panelProShow.ResumeLayout(false);
            this.splitProInfo.Panel1.ResumeLayout(false);
            this.splitProInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitProInfo)).EndInit();
            this.splitProInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpProductInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBarCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbProType;
        private System.Windows.Forms.ComboBox cmbProColor;
        private System.Windows.Forms.GroupBox grpStatics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbCt;
        private System.Windows.Forms.Label lbNgNum;
        private System.Windows.Forms.Label lbOkNum;
        private System.Windows.Forms.Label lbPassRate;
        private System.Windows.Forms.Label lbTotalNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnClearStatistics;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel panelProShow;
        private System.Windows.Forms.SplitContainer splitProInfo;
        private OperateInstruction smShow;
        private System.Windows.Forms.ContextMenuStrip cmsDgvResult;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.TabControl tbDatas;
        private System.Windows.Forms.TabPage 机台数据;
        private System.Windows.Forms.TabPage 按小时统计;
        private System.Windows.Forms.DataGridView dgvRtData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox grpRtData;
    }
}
