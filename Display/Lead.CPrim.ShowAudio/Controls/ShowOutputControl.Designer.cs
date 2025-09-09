using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.ShowAudio.Controls
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
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel3 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel4 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel5 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel6 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel7 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel8 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel9 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel10 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel11 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel12 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel13 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel14 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel15 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTop10 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.dtpDayEnd = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDatetimePicker();
            this.dtpDayStart = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDatetimePicker();
            this.hsbDay = new Sunny.UI.UIHorScrollBar();
            this.chartTop10 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMachine = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.chartMachineState = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStatistics = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.pnlParam = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.dgvFai = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.KeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.failBindDgvBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblParam = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlInfo = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.pnlSensor = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.btnConnect = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.lblSensor = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tmrMachineState = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_ErrorStatisticsDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain.SuspendLayout();
            this.pnlTop10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTop10)).BeginInit();
            this.pnlMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMachineState)).BeginInit();
            this.tlpRight.SuspendLayout();
            this.pnlParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failBindDgvBindingSource)).BeginInit();
            this.pnlSensor.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.Controls.Add(this.pnlTop10, 0, 1);
            this.tlpMain.Controls.Add(this.pnlMachine, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1021, 522);
            this.tlpMain.TabIndex = 46;
            // 
            // pnlTop10
            // 
            this.pnlTop10.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop10.Controls.Add(this.dtpDayEnd);
            this.pnlTop10.Controls.Add(this.dtpDayStart);
            this.pnlTop10.Controls.Add(this.hsbDay);
            this.pnlTop10.Controls.Add(this.chartTop10);
            this.pnlTop10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTop10.Location = new System.Drawing.Point(0, 263);
            this.pnlTop10.Margin = new System.Windows.Forms.Padding(0, 2, 2, 0);
            this.pnlTop10.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTop10.Name = "pnlTop10";
            this.pnlTop10.Size = new System.Drawing.Size(678, 259);
            this.pnlTop10.TabIndex = 54;
            this.pnlTop10.Text = null;
            this.pnlTop10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTop10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dtpDayEnd
            // 
            this.dtpDayEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDayEnd.FillColor = System.Drawing.Color.White;
            this.dtpDayEnd.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDayEnd.Location = new System.Drawing.Point(541, 0);
            this.dtpDayEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDayEnd.MaxLength = 19;
            this.dtpDayEnd.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtpDayEnd.Name = "dtpDayEnd";
            this.dtpDayEnd.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtpDayEnd.Size = new System.Drawing.Size(130, 20);
            this.dtpDayEnd.SymbolDropDown = 61555;
            this.dtpDayEnd.SymbolNormal = 61555;
            this.dtpDayEnd.TabIndex = 57;
            this.dtpDayEnd.Text = "2023-01-09 01:43:42";
            this.dtpDayEnd.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtpDayEnd.Value = new System.DateTime(2023, 1, 9, 1, 43, 42, 702);
            this.dtpDayEnd.Watermark = "";
            this.dtpDayEnd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dtpDayEnd.OnComfirmOK += new System.Action(this.dtpDayEnd_OnComfirmOK);
            this.dtpDayEnd.DropDownClosed += new System.EventHandler(this.dtpDayEnd_DropDownClosed);
            // 
            // dtpDayStart
            // 
            this.dtpDayStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDayStart.FillColor = System.Drawing.Color.White;
            this.dtpDayStart.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDayStart.Location = new System.Drawing.Point(396, 0);
            this.dtpDayStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDayStart.MaxLength = 19;
            this.dtpDayStart.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtpDayStart.Name = "dtpDayStart";
            this.dtpDayStart.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtpDayStart.Size = new System.Drawing.Size(130, 20);
            this.dtpDayStart.SymbolDropDown = 61555;
            this.dtpDayStart.SymbolNormal = 61555;
            this.dtpDayStart.TabIndex = 58;
            this.dtpDayStart.Text = "2023-01-09 01:43:42";
            this.dtpDayStart.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtpDayStart.Value = new System.DateTime(2023, 1, 9, 1, 43, 42, 702);
            this.dtpDayStart.Watermark = "";
            this.dtpDayStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dtpDayStart.OnComfirmOK += new System.Action(this.dtpDayStart_OnComfirmOK);
            this.dtpDayStart.DropDownClosed += new System.EventHandler(this.dtpDayStart_DropDownClosed);
            // 
            // hsbDay
            // 
            this.hsbDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbDay.Cursor = System.Windows.Forms.Cursors.Default;
            this.hsbDay.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hsbDay.Location = new System.Drawing.Point(396, 23);
            this.hsbDay.Maximum = 7;
            this.hsbDay.MinimumSize = new System.Drawing.Size(1, 1);
            this.hsbDay.Name = "hsbDay";
            this.hsbDay.Size = new System.Drawing.Size(275, 12);
            this.hsbDay.TabIndex = 54;
            this.hsbDay.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.hsbDay.ValueChanged += new System.EventHandler(this.hsbDay_ValueChanged);
            // 
            // chartTop10
            // 
            this.chartTop10.BackColor = System.Drawing.Color.LightGray;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            customLabel1.ForeColor = System.Drawing.Color.Black;
            customLabel1.FromPosition = 0.5D;
            customLabel1.Text = "PDI\nError";
            customLabel1.ToPosition = 1.5D;
            customLabel2.ForeColor = System.Drawing.Color.Black;
            customLabel2.FromPosition = 1.5D;
            customLabel2.Text = "Sensor\nError";
            customLabel2.ToPosition = 2.5D;
            customLabel3.ForeColor = System.Drawing.Color.Black;
            customLabel3.FromPosition = 2.5D;
            customLabel3.Text = "Motion\nError";
            customLabel3.ToPosition = 3.5D;
            customLabel4.ForeColor = System.Drawing.Color.Black;
            customLabel4.FromPosition = 3.5D;
            customLabel4.Text = "Cylinder\nError";
            customLabel4.ToPosition = 4.5D;
            customLabel5.ForeColor = System.Drawing.Color.Black;
            customLabel5.FromPosition = 4.5D;
            customLabel5.Text = "Vision\nError";
            customLabel5.ToPosition = 5.5D;
            customLabel6.ForeColor = System.Drawing.Color.Black;
            customLabel6.FromPosition = 5.5D;
            customLabel6.Text = "Scanning\nError";
            customLabel6.ToPosition = 6.5D;
            customLabel7.ForeColor = System.Drawing.Color.Black;
            customLabel7.FromPosition = 6.5D;
            customLabel7.Text = "Safety\nError";
            customLabel7.ToPosition = 7.5D;
            customLabel8.ForeColor = System.Drawing.Color.Black;
            customLabel8.FromPosition = 7.5D;
            customLabel8.Text = "MES Error";
            customLabel8.ToPosition = 8.5D;
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.CustomLabels.Add(customLabel2);
            chartArea1.AxisX.CustomLabels.Add(customLabel3);
            chartArea1.AxisX.CustomLabels.Add(customLabel4);
            chartArea1.AxisX.CustomLabels.Add(customLabel5);
            chartArea1.AxisX.CustomLabels.Add(customLabel6);
            chartArea1.AxisX.CustomLabels.Add(customLabel7);
            chartArea1.AxisX.CustomLabels.Add(customLabel8);
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(10)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Maximum = 8.6D;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.chartTop10.ChartAreas.Add(chartArea1);
            this.chartTop10.ContextMenuStrip = this.contextMenuStrip1;
            this.chartTop10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTop10.Location = new System.Drawing.Point(0, 0);
            this.chartTop10.Name = "chartTop10";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            this.chartTop10.Series.Add(series1);
            this.chartTop10.Size = new System.Drawing.Size(678, 259);
            this.chartTop10.TabIndex = 53;
            this.chartTop10.Text = "chart3";
            title1.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title1.Name = "Title1";
            title1.Text = "Machine Error Statistics (Top10)";
            this.chartTop10.Titles.Add(title1);
            this.chartTop10.DoubleClick += new System.EventHandler(this.chartTop10_DoubleClick);
            // 
            // pnlMachine
            // 
            this.pnlMachine.Controls.Add(this.chartMachineState);
            this.pnlMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMachine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMachine.Location = new System.Drawing.Point(0, 0);
            this.pnlMachine.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.pnlMachine.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMachine.Name = "pnlMachine";
            this.pnlMachine.Size = new System.Drawing.Size(678, 259);
            this.pnlMachine.TabIndex = 56;
            this.pnlMachine.Text = null;
            this.pnlMachine.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMachine.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chartMachineState
            // 
            this.chartMachineState.BackColor = System.Drawing.Color.LightGray;
            customLabel9.ForeColor = System.Drawing.Color.Black;
            customLabel9.FromPosition = 0.5D;
            customLabel9.Text = "T-6";
            customLabel9.ToPosition = 1.5D;
            customLabel10.ForeColor = System.Drawing.Color.Black;
            customLabel10.FromPosition = 1.5D;
            customLabel10.Text = "T-5";
            customLabel10.ToPosition = 2.5D;
            customLabel11.ForeColor = System.Drawing.Color.Black;
            customLabel11.FromPosition = 2.5D;
            customLabel11.Text = "T-4";
            customLabel11.ToPosition = 3.5D;
            customLabel12.ForeColor = System.Drawing.Color.Black;
            customLabel12.FromPosition = 3.5D;
            customLabel12.Text = "T-3";
            customLabel12.ToPosition = 4.5D;
            customLabel13.ForeColor = System.Drawing.Color.Black;
            customLabel13.FromPosition = 4.5D;
            customLabel13.LabelMark = System.Windows.Forms.DataVisualization.Charting.LabelMarkStyle.SideMark;
            customLabel13.Text = "T-2";
            customLabel13.ToPosition = 5.5D;
            customLabel14.ForeColor = System.Drawing.Color.Black;
            customLabel14.FromPosition = 5.5D;
            customLabel14.Text = "T-1";
            customLabel14.ToPosition = 6.5D;
            customLabel15.ForeColor = System.Drawing.Color.Black;
            customLabel15.FromPosition = 6.5D;
            customLabel15.Text = "T(YYMMDD)";
            customLabel15.ToPosition = 7.5D;
            chartArea2.AxisX.CustomLabels.Add(customLabel9);
            chartArea2.AxisX.CustomLabels.Add(customLabel10);
            chartArea2.AxisX.CustomLabels.Add(customLabel11);
            chartArea2.AxisX.CustomLabels.Add(customLabel12);
            chartArea2.AxisX.CustomLabels.Add(customLabel13);
            chartArea2.AxisX.CustomLabels.Add(customLabel14);
            chartArea2.AxisX.CustomLabels.Add(customLabel15);
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.Maximum = 7.9D;
            chartArea2.AxisY.LabelStyle.Format = "{0:P0}";
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartMachineState.ChartAreas.Add(chartArea2);
            this.chartMachineState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartMachineState.Location = new System.Drawing.Point(0, 0);
            this.chartMachineState.Margin = new System.Windows.Forms.Padding(0);
            this.chartMachineState.Name = "chartMachineState";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Color = System.Drawing.SystemColors.MenuHighlight;
            series2.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Name = "Series1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Color = System.Drawing.Color.LimeGreen;
            series3.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Name = "Series2";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series4.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Name = "Series3";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series5.Color = System.Drawing.Color.Red;
            series5.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.Name = "Series4";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series6.Color = System.Drawing.Color.Fuchsia;
            series6.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series6.Name = "Series5";
            this.chartMachineState.Series.Add(series2);
            this.chartMachineState.Series.Add(series3);
            this.chartMachineState.Series.Add(series4);
            this.chartMachineState.Series.Add(series5);
            this.chartMachineState.Series.Add(series6);
            this.chartMachineState.Size = new System.Drawing.Size(678, 259);
            this.chartMachineState.TabIndex = 52;
            this.chartMachineState.Text = "chart2";
            title2.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Machine State Changes (7D)";
            this.chartMachineState.Titles.Add(title2);
            // 
            // tlpRight
            // 
            this.tlpRight.BackColor = System.Drawing.Color.LightGray;
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.pnlStatistics, 0, 0);
            this.tlpRight.Controls.Add(this.pnlParam, 0, 1);
            this.tlpRight.Controls.Add(this.pnlInfo, 0, 2);
            this.tlpRight.Controls.Add(this.pnlSensor, 0, 3);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(680, 0);
            this.tlpRight.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 4;
            this.tlpMain.SetRowSpan(this.tlpRight, 2);
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpRight.Size = new System.Drawing.Size(341, 522);
            this.tlpRight.TabIndex = 51;
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatistics.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlStatistics.Location = new System.Drawing.Point(2, 0);
            this.pnlStatistics.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.pnlStatistics.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Size = new System.Drawing.Size(337, 160);
            this.pnlStatistics.TabIndex = 54;
            this.pnlStatistics.Text = null;
            this.pnlStatistics.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlStatistics.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlParam
            // 
            this.pnlParam.Controls.Add(this.dgvFai);
            this.pnlParam.Controls.Add(this.lblParam);
            this.pnlParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlParam.Location = new System.Drawing.Point(2, 164);
            this.pnlParam.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.pnlParam.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlParam.Name = "pnlParam";
            this.pnlParam.Padding = new System.Windows.Forms.Padding(5);
            this.pnlParam.Radius = 0;
            this.pnlParam.Size = new System.Drawing.Size(339, 158);
            this.pnlParam.TabIndex = 55;
            this.pnlParam.Text = null;
            this.pnlParam.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlParam.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dgvFai
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvFai.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFai.AutoGenerateColumns = false;
            this.dgvFai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFai.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFai.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvFai.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFai.ColumnHeadersHeight = 25;
            this.dgvFai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyName,
            this.Value,
            this.USL,
            this.LSL});
            this.dgvFai.DataSource = this.failBindDgvBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFai.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFai.EnableHeadersVisualStyles = false;
            this.dgvFai.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvFai.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.dgvFai.Location = new System.Drawing.Point(5, 40);
            this.dgvFai.Name = "dgvFai";
            this.dgvFai.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFai.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFai.RowHeadersVisible = false;
            this.dgvFai.RowHeadersWidth = 10;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvFai.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFai.RowTemplate.Height = 27;
            this.dgvFai.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvFai.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvFai.ScrollBarHandleWidth = 4;
            this.dgvFai.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dgvFai.SelectedIndex = -1;
            this.dgvFai.Size = new System.Drawing.Size(329, 113);
            this.dgvFai.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.dgvFai.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvFai.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgvFai.StyleCustomMode = true;
            this.dgvFai.TabIndex = 1;
            this.dgvFai.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvFai.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFai_CellFormatting);
            // 
            // KeyName
            // 
            this.KeyName.DataPropertyName = "KeyName";
            this.KeyName.FillWeight = 200F;
            this.KeyName.HeaderText = "Key Name";
            this.KeyName.MinimumWidth = 6;
            this.KeyName.Name = "KeyName";
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            // 
            // USL
            // 
            this.USL.DataPropertyName = "USL";
            this.USL.HeaderText = "USL";
            this.USL.MinimumWidth = 6;
            this.USL.Name = "USL";
            // 
            // LSL
            // 
            this.LSL.DataPropertyName = "LSL";
            this.LSL.HeaderText = "LSL";
            this.LSL.MinimumWidth = 6;
            this.LSL.Name = "LSL";
            // 
            // failBindDgvBindingSource
            // 
            this.failBindDgvBindingSource.DataSource = typeof(Lead.CPrim.ShowAudio.Controls.FailBindDgv);
            // 
            // lblParam
            // 
            this.lblParam.BackColor = System.Drawing.Color.Transparent;
            this.lblParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblParam.Location = new System.Drawing.Point(5, 5);
            this.lblParam.Margin = new System.Windows.Forms.Padding(0);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(329, 35);
            this.lblParam.TabIndex = 0;
            this.lblParam.Text = "Critical Param Dashboard";
            this.lblParam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblParam.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlInfo.Location = new System.Drawing.Point(2, 326);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.pnlInfo.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Radius = 0;
            this.pnlInfo.RadiusSides = Lead.CPrim.ProxyTools.UICornerRadiusSides.None;
            this.pnlInfo.RectColor = System.Drawing.Color.Transparent;
            this.pnlInfo.RectDisableColor = System.Drawing.Color.Transparent;
            this.pnlInfo.Size = new System.Drawing.Size(339, 165);
            this.pnlInfo.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlInfo.StyleCustomMode = true;
            this.pnlInfo.TabIndex = 56;
            this.pnlInfo.Text = null;
            this.pnlInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlInfo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlSensor
            // 
            this.pnlSensor.Controls.Add(this.btnConnect);
            this.pnlSensor.Controls.Add(this.lblSensor);
            this.pnlSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSensor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlSensor.Location = new System.Drawing.Point(2, 491);
            this.pnlSensor.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.pnlSensor.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSensor.Name = "pnlSensor";
            this.pnlSensor.Radius = 0;
            this.pnlSensor.RectColor = System.Drawing.Color.Transparent;
            this.pnlSensor.RectDisableColor = System.Drawing.Color.Transparent;
            this.pnlSensor.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pnlSensor.Size = new System.Drawing.Size(339, 31);
            this.pnlSensor.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlSensor.TabIndex = 57;
            this.pnlSensor.Text = null;
            this.pnlSensor.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlSensor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnConnect
            // 
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(182, 4);
            this.btnConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(30, 25);
            this.btnConnect.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnConnect.Symbol = 61515;
            this.btnConnect.TabIndex = 1;
            this.btnConnect.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblSensor
            // 
            this.lblSensor.AutoSize = true;
            this.lblSensor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSensor.Location = new System.Drawing.Point(25, 6);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(170, 24);
            this.lblSensor.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblSensor.TabIndex = 0;
            this.lblSensor.Text = "Sensor Connection";
            this.lblSensor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSensor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tmrMachineState
            // 
            this.tmrMachineState.Interval = 3600000;
            this.tmrMachineState.Tick += new System.EventHandler(this.tmrMachineState_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ErrorStatisticsDetail,
            this.tsmi_Export});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 80);
            // 
            // tsmi_ErrorStatisticsDetail
            // 
            this.tsmi_ErrorStatisticsDetail.Name = "tsmi_ErrorStatisticsDetail";
            this.tsmi_ErrorStatisticsDetail.Size = new System.Drawing.Size(210, 24);
            this.tsmi_ErrorStatisticsDetail.Text = "细节";
            this.tsmi_ErrorStatisticsDetail.Click += new System.EventHandler(this.tsmi_ErrorStatisticsDetail_Click);
            // 
            // tsmi_Export
            // 
            this.tsmi_Export.Name = "tsmi_Export";
            this.tsmi_Export.Size = new System.Drawing.Size(210, 24);
            this.tsmi_Export.Text = "导出";
            this.tsmi_Export.Click += new System.EventHandler(this.tsmi_Export_Click);
            // 
            // ShowOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowOutputControl";
            this.Radius = 0;
            this.RectColor = System.Drawing.Color.Transparent;
            this.RectDisableColor = System.Drawing.Color.Transparent;
            this.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.Size = new System.Drawing.Size(1021, 522);
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Load += new System.EventHandler(this.ShowOutputControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlTop10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTop10)).EndInit();
            this.pnlMachine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMachineState)).EndInit();
            this.tlpRight.ResumeLayout(false);
            this.pnlParam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failBindDgvBindingSource)).EndInit();
            this.pnlSensor.ResumeLayout(false);
            this.pnlSensor.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private UILabel lblParam;
        private UIDataGridView dgvFai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMachineState;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTop10;
        private System.Windows.Forms.BindingSource failBindDgvBindingSource;
        private UIPanel pnlTop10;
        private Sunny.UI.UIHorScrollBar hsbDay;
        private UIPanel pnlMachine;
        private UIPanel pnlStatistics;
        private UIPanel pnlParam;
        private UIPanel pnlInfo;
        private UIDatetimePicker dtpDayEnd;
        private UIDatetimePicker dtpDayStart;
        private UIPanel pnlSensor;
        private UISymbolButton btnConnect;
        private UILabel lblSensor;
        private System.Windows.Forms.Timer tmrMachineState;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn USL;
        private System.Windows.Forms.DataGridViewTextBoxColumn LSL;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ErrorStatisticsDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Export;
    }
}
