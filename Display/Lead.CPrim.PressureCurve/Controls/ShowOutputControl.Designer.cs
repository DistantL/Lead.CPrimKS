
namespace Lead.CPrim.PressureCurve.Controls
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeftDownMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLeftDownStop = new System.Windows.Forms.Button();
            this.cbLeftDownHistory = new System.Windows.Forms.CheckBox();
            this.btnLeftDownClear = new System.Windows.Forms.Button();
            this.btnLeftDownStart = new System.Windows.Forms.Button();
            this.tlpRightDownMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRightDownStop = new System.Windows.Forms.Button();
            this.cbRightDownHistory = new System.Windows.Forms.CheckBox();
            this.btnRightDownClear = new System.Windows.Forms.Button();
            this.btnRightDownStart = new System.Windows.Forms.Button();
            this.tlpLeftUpMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpLeftUpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.btnLeftUpStop = new System.Windows.Forms.Button();
            this.cbLeftUpHistory = new System.Windows.Forms.CheckBox();
            this.btnLeftUpClear = new System.Windows.Forms.Button();
            this.btnLeftUpStart = new System.Windows.Forms.Button();
            this.tlpRightUpMain = new System.Windows.Forms.TableLayoutPanel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRightUpStop = new System.Windows.Forms.Button();
            this.cbRightUpHistory = new System.Windows.Forms.CheckBox();
            this.btnRightUpClear = new System.Windows.Forms.Button();
            this.btnRightUpStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpLeftDownMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpRightDownMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tlpLeftUpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tlpLeftUpTitle.SuspendLayout();
            this.tlpRightUpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.tlpLeftDownMain, 0, 1);
            this.tlpMain.Controls.Add(this.tlpRightDownMain, 1, 1);
            this.tlpMain.Controls.Add(this.tlpLeftUpMain, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRightUpMain, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(984, 561);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpLeftDownMain
            // 
            this.tlpLeftDownMain.ColumnCount = 1;
            this.tlpLeftDownMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftDownMain.Controls.Add(this.chart3, 0, 1);
            this.tlpLeftDownMain.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tlpLeftDownMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeftDownMain.Location = new System.Drawing.Point(3, 283);
            this.tlpLeftDownMain.Name = "tlpLeftDownMain";
            this.tlpLeftDownMain.RowCount = 2;
            this.tlpLeftDownMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeftDownMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftDownMain.Size = new System.Drawing.Size(486, 275);
            this.tlpLeftDownMain.TabIndex = 5;
            // 
            // chart3
            // 
            chartArea1.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea1);
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart3.Legends.Add(legend1);
            this.chart3.Location = new System.Drawing.Point(3, 43);
            this.chart3.Name = "chart3";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart3.Series.Add(series1);
            this.chart3.Size = new System.Drawing.Size(480, 229);
            this.chart3.TabIndex = 0;
            this.chart3.Text = "chart4";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99954F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel3.Controls.Add(this.btnLeftDownStop, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbLeftDownHistory, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnLeftDownClear, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnLeftDownStart, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(480, 34);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnLeftDownStop
            // 
            this.btnLeftDownStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftDownStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftDownStop.Location = new System.Drawing.Point(120, 0);
            this.btnLeftDownStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeftDownStop.Name = "btnLeftDownStop";
            this.btnLeftDownStop.Size = new System.Drawing.Size(120, 34);
            this.btnLeftDownStop.TabIndex = 2;
            this.btnLeftDownStop.Text = "停止";
            this.btnLeftDownStop.UseVisualStyleBackColor = true;
            this.btnLeftDownStop.Click += new System.EventHandler(this.btnLeftDownStop_Click);
            // 
            // cbLeftDownHistory
            // 
            this.cbLeftDownHistory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbLeftDownHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLeftDownHistory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLeftDownHistory.Location = new System.Drawing.Point(359, 0);
            this.cbLeftDownHistory.Margin = new System.Windows.Forms.Padding(0);
            this.cbLeftDownHistory.Name = "cbLeftDownHistory";
            this.cbLeftDownHistory.Size = new System.Drawing.Size(121, 34);
            this.cbLeftDownHistory.TabIndex = 1;
            this.cbLeftDownHistory.Text = "实时/历史";
            this.cbLeftDownHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLeftDownHistory.UseVisualStyleBackColor = true;
            // 
            // btnLeftDownClear
            // 
            this.btnLeftDownClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftDownClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftDownClear.Location = new System.Drawing.Point(240, 0);
            this.btnLeftDownClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeftDownClear.Name = "btnLeftDownClear";
            this.btnLeftDownClear.Size = new System.Drawing.Size(119, 34);
            this.btnLeftDownClear.TabIndex = 1;
            this.btnLeftDownClear.Text = "清空";
            this.btnLeftDownClear.UseVisualStyleBackColor = true;
            this.btnLeftDownClear.Click += new System.EventHandler(this.btnLeftDownClear_Click);
            // 
            // btnLeftDownStart
            // 
            this.btnLeftDownStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftDownStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftDownStart.Location = new System.Drawing.Point(0, 0);
            this.btnLeftDownStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeftDownStart.Name = "btnLeftDownStart";
            this.btnLeftDownStart.Size = new System.Drawing.Size(120, 34);
            this.btnLeftDownStart.TabIndex = 0;
            this.btnLeftDownStart.Text = "开始";
            this.btnLeftDownStart.UseVisualStyleBackColor = true;
            this.btnLeftDownStart.Click += new System.EventHandler(this.btnLeftDownStart_Click);
            // 
            // tlpRightDownMain
            // 
            this.tlpRightDownMain.ColumnCount = 1;
            this.tlpRightDownMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightDownMain.Controls.Add(this.chart4, 0, 1);
            this.tlpRightDownMain.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tlpRightDownMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRightDownMain.Location = new System.Drawing.Point(495, 283);
            this.tlpRightDownMain.Name = "tlpRightDownMain";
            this.tlpRightDownMain.RowCount = 2;
            this.tlpRightDownMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRightDownMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightDownMain.Size = new System.Drawing.Size(486, 275);
            this.tlpRightDownMain.TabIndex = 4;
            // 
            // chart4
            // 
            chartArea2.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea2);
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chart4.Legends.Add(legend2);
            this.chart4.Location = new System.Drawing.Point(3, 43);
            this.chart4.Name = "chart4";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart4.Series.Add(series2);
            this.chart4.Size = new System.Drawing.Size(480, 229);
            this.chart4.TabIndex = 0;
            this.chart4.Text = "chart4";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99954F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel6.Controls.Add(this.btnRightDownStop, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbRightDownHistory, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnRightDownClear, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnRightDownStart, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(480, 34);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // btnRightDownStop
            // 
            this.btnRightDownStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightDownStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightDownStop.Location = new System.Drawing.Point(120, 0);
            this.btnRightDownStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnRightDownStop.Name = "btnRightDownStop";
            this.btnRightDownStop.Size = new System.Drawing.Size(120, 34);
            this.btnRightDownStop.TabIndex = 2;
            this.btnRightDownStop.Text = "停止";
            this.btnRightDownStop.UseVisualStyleBackColor = true;
            this.btnRightDownStop.Click += new System.EventHandler(this.btnRightDownStop_Click);
            // 
            // cbRightDownHistory
            // 
            this.cbRightDownHistory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbRightDownHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbRightDownHistory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbRightDownHistory.Location = new System.Drawing.Point(359, 0);
            this.cbRightDownHistory.Margin = new System.Windows.Forms.Padding(0);
            this.cbRightDownHistory.Name = "cbRightDownHistory";
            this.cbRightDownHistory.Size = new System.Drawing.Size(121, 34);
            this.cbRightDownHistory.TabIndex = 1;
            this.cbRightDownHistory.Text = "实时/历史";
            this.cbRightDownHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRightDownHistory.UseVisualStyleBackColor = true;
            // 
            // btnRightDownClear
            // 
            this.btnRightDownClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightDownClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightDownClear.Location = new System.Drawing.Point(240, 0);
            this.btnRightDownClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnRightDownClear.Name = "btnRightDownClear";
            this.btnRightDownClear.Size = new System.Drawing.Size(119, 34);
            this.btnRightDownClear.TabIndex = 1;
            this.btnRightDownClear.Text = "清空";
            this.btnRightDownClear.UseVisualStyleBackColor = true;
            this.btnRightDownClear.Click += new System.EventHandler(this.btnRightDownClear_Click);
            // 
            // btnRightDownStart
            // 
            this.btnRightDownStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightDownStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightDownStart.Location = new System.Drawing.Point(0, 0);
            this.btnRightDownStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnRightDownStart.Name = "btnRightDownStart";
            this.btnRightDownStart.Size = new System.Drawing.Size(120, 34);
            this.btnRightDownStart.TabIndex = 0;
            this.btnRightDownStart.Text = "开始";
            this.btnRightDownStart.UseVisualStyleBackColor = true;
            this.btnRightDownStart.Click += new System.EventHandler(this.btnRightDownStart_Click);
            // 
            // tlpLeftUpMain
            // 
            this.tlpLeftUpMain.ColumnCount = 1;
            this.tlpLeftUpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftUpMain.Controls.Add(this.chart1, 0, 1);
            this.tlpLeftUpMain.Controls.Add(this.tlpLeftUpTitle, 0, 0);
            this.tlpLeftUpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeftUpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpLeftUpMain.Name = "tlpLeftUpMain";
            this.tlpLeftUpMain.RowCount = 2;
            this.tlpLeftUpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeftUpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftUpMain.Size = new System.Drawing.Size(486, 274);
            this.tlpLeftUpMain.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(3, 43);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(480, 228);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tlpLeftUpTitle
            // 
            this.tlpLeftUpTitle.ColumnCount = 4;
            this.tlpLeftUpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tlpLeftUpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tlpLeftUpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99954F));
            this.tlpLeftUpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tlpLeftUpTitle.Controls.Add(this.btnLeftUpStop, 0, 0);
            this.tlpLeftUpTitle.Controls.Add(this.cbLeftUpHistory, 3, 0);
            this.tlpLeftUpTitle.Controls.Add(this.btnLeftUpClear, 1, 0);
            this.tlpLeftUpTitle.Controls.Add(this.btnLeftUpStart, 0, 0);
            this.tlpLeftUpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeftUpTitle.Location = new System.Drawing.Point(3, 3);
            this.tlpLeftUpTitle.Name = "tlpLeftUpTitle";
            this.tlpLeftUpTitle.RowCount = 1;
            this.tlpLeftUpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftUpTitle.Size = new System.Drawing.Size(480, 34);
            this.tlpLeftUpTitle.TabIndex = 1;
            // 
            // btnLeftUpStop
            // 
            this.btnLeftUpStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftUpStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftUpStop.Location = new System.Drawing.Point(120, 0);
            this.btnLeftUpStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeftUpStop.Name = "btnLeftUpStop";
            this.btnLeftUpStop.Size = new System.Drawing.Size(120, 34);
            this.btnLeftUpStop.TabIndex = 2;
            this.btnLeftUpStop.Text = "停止";
            this.btnLeftUpStop.UseVisualStyleBackColor = true;
            this.btnLeftUpStop.Click += new System.EventHandler(this.btnLeftUpStop_Click);
            // 
            // cbLeftUpHistory
            // 
            this.cbLeftUpHistory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbLeftUpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLeftUpHistory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLeftUpHistory.Location = new System.Drawing.Point(359, 0);
            this.cbLeftUpHistory.Margin = new System.Windows.Forms.Padding(0);
            this.cbLeftUpHistory.Name = "cbLeftUpHistory";
            this.cbLeftUpHistory.Size = new System.Drawing.Size(121, 34);
            this.cbLeftUpHistory.TabIndex = 1;
            this.cbLeftUpHistory.Text = "实时/历史";
            this.cbLeftUpHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLeftUpHistory.UseVisualStyleBackColor = true;
            // 
            // btnLeftUpClear
            // 
            this.btnLeftUpClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftUpClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftUpClear.Location = new System.Drawing.Point(240, 0);
            this.btnLeftUpClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeftUpClear.Name = "btnLeftUpClear";
            this.btnLeftUpClear.Size = new System.Drawing.Size(119, 34);
            this.btnLeftUpClear.TabIndex = 1;
            this.btnLeftUpClear.Text = "清空";
            this.btnLeftUpClear.UseVisualStyleBackColor = true;
            this.btnLeftUpClear.Click += new System.EventHandler(this.btnLeftUpClear_Click);
            // 
            // btnLeftUpStart
            // 
            this.btnLeftUpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeftUpStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLeftUpStart.Location = new System.Drawing.Point(0, 0);
            this.btnLeftUpStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeftUpStart.Name = "btnLeftUpStart";
            this.btnLeftUpStart.Size = new System.Drawing.Size(120, 34);
            this.btnLeftUpStart.TabIndex = 0;
            this.btnLeftUpStart.Text = "开始";
            this.btnLeftUpStart.UseVisualStyleBackColor = true;
            this.btnLeftUpStart.Click += new System.EventHandler(this.btnLeftUpStart_Click);
            // 
            // tlpRightUpMain
            // 
            this.tlpRightUpMain.ColumnCount = 1;
            this.tlpRightUpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightUpMain.Controls.Add(this.chart2, 0, 1);
            this.tlpRightUpMain.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpRightUpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRightUpMain.Location = new System.Drawing.Point(495, 3);
            this.tlpRightUpMain.Name = "tlpRightUpMain";
            this.tlpRightUpMain.RowCount = 2;
            this.tlpRightUpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpRightUpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightUpMain.Size = new System.Drawing.Size(486, 274);
            this.tlpRightUpMain.TabIndex = 2;
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Alignment = System.Drawing.StringAlignment.Center;
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(3, 43);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(480, 228);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99954F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00016F));
            this.tableLayoutPanel2.Controls.Add(this.btnRightUpStop, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbRightUpHistory, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRightUpClear, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRightUpStart, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(480, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnRightUpStop
            // 
            this.btnRightUpStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightUpStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightUpStop.Location = new System.Drawing.Point(120, 0);
            this.btnRightUpStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnRightUpStop.Name = "btnRightUpStop";
            this.btnRightUpStop.Size = new System.Drawing.Size(120, 34);
            this.btnRightUpStop.TabIndex = 2;
            this.btnRightUpStop.Text = "停止";
            this.btnRightUpStop.UseVisualStyleBackColor = true;
            this.btnRightUpStop.Click += new System.EventHandler(this.btnRightUpStop_Click);
            // 
            // cbRightUpHistory
            // 
            this.cbRightUpHistory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbRightUpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbRightUpHistory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbRightUpHistory.Location = new System.Drawing.Point(359, 0);
            this.cbRightUpHistory.Margin = new System.Windows.Forms.Padding(0);
            this.cbRightUpHistory.Name = "cbRightUpHistory";
            this.cbRightUpHistory.Size = new System.Drawing.Size(121, 34);
            this.cbRightUpHistory.TabIndex = 1;
            this.cbRightUpHistory.Text = "实时/历史";
            this.cbRightUpHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRightUpHistory.UseVisualStyleBackColor = true;
            // 
            // btnRightUpClear
            // 
            this.btnRightUpClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightUpClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightUpClear.Location = new System.Drawing.Point(240, 0);
            this.btnRightUpClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnRightUpClear.Name = "btnRightUpClear";
            this.btnRightUpClear.Size = new System.Drawing.Size(119, 34);
            this.btnRightUpClear.TabIndex = 1;
            this.btnRightUpClear.Text = "清空";
            this.btnRightUpClear.UseVisualStyleBackColor = true;
            this.btnRightUpClear.Click += new System.EventHandler(this.btnRightUpClear_Click);
            // 
            // btnRightUpStart
            // 
            this.btnRightUpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRightUpStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRightUpStart.Location = new System.Drawing.Point(0, 0);
            this.btnRightUpStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnRightUpStart.Name = "btnRightUpStart";
            this.btnRightUpStart.Size = new System.Drawing.Size(120, 34);
            this.btnRightUpStart.TabIndex = 0;
            this.btnRightUpStart.Text = "开始";
            this.btnRightUpStart.UseVisualStyleBackColor = true;
            this.btnRightUpStart.Click += new System.EventHandler(this.btnRightUpStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // ShowOutputControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpMain);
            this.Name = "ShowOutputControl";
            this.Size = new System.Drawing.Size(984, 561);
            this.Text = "压力曲线";
            this.Load += new System.EventHandler(this.ShowOutputControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpLeftDownMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tlpRightDownMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tlpLeftUpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tlpLeftUpTitle.ResumeLayout(false);
            this.tlpRightUpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpLeftUpMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel tlpLeftUpTitle;
        private System.Windows.Forms.CheckBox cbLeftUpHistory;
        private System.Windows.Forms.Button btnLeftUpClear;
        private System.Windows.Forms.Button btnLeftUpStart;
        private System.Windows.Forms.Button btnLeftUpStop;
        private System.Windows.Forms.TableLayoutPanel tlpRightDownMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnRightDownStop;
        private System.Windows.Forms.CheckBox cbRightDownHistory;
        private System.Windows.Forms.Button btnRightDownClear;
        private System.Windows.Forms.Button btnRightDownStart;
        private System.Windows.Forms.TableLayoutPanel tlpRightUpMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnRightUpStop;
        private System.Windows.Forms.CheckBox cbRightUpHistory;
        private System.Windows.Forms.Button btnRightUpClear;
        private System.Windows.Forms.Button btnRightUpStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.TableLayoutPanel tlpLeftDownMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnLeftDownStop;
        private System.Windows.Forms.CheckBox cbLeftDownHistory;
        private System.Windows.Forms.Button btnLeftDownClear;
        private System.Windows.Forms.Button btnLeftDownStart;
    }
}
