
namespace Lead.CPrim.Controls
{
    partial class CustomChartFrm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomChartFrm));
            this.uiLine1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMethod1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtXMax = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtXMin = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnInitChart = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.cpStart = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.cpEnd = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.btnSave = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.btnExport = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(38, 8);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(900, 29);
            this.uiLine1.TabIndex = 6;
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(38, 334);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(900, 535);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // lblMethod1
            // 
            this.lblMethod1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMethod1.Location = new System.Drawing.Point(34, 40);
            this.lblMethod1.Name = "lblMethod1";
            this.lblMethod1.Size = new System.Drawing.Size(380, 280);
            this.lblMethod1.TabIndex = 8;
            this.lblMethod1.Text = resources.GetString("lblMethod1.Text");
            this.lblMethod1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMethod1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtXMax
            // 
            this.txtXMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtXMax.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXMax.Location = new System.Drawing.Point(448, 40);
            this.txtXMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXMax.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtXMax.Name = "txtXMax";
            this.txtXMax.ShowText = false;
            this.txtXMax.Size = new System.Drawing.Size(140, 35);
            this.txtXMax.TabIndex = 10;
            this.txtXMax.Watermark = "xMax";
            this.txtXMax.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtXMin
            // 
            this.txtXMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtXMin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXMin.Location = new System.Drawing.Point(623, 40);
            this.txtXMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXMin.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtXMin.Name = "txtXMin";
            this.txtXMin.ShowText = false;
            this.txtXMin.Size = new System.Drawing.Size(140, 35);
            this.txtXMin.TabIndex = 10;
            this.txtXMin.Watermark = "xMin";
            this.txtXMin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnInitChart
            // 
            this.btnInitChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInitChart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInitChart.Location = new System.Drawing.Point(623, 230);
            this.btnInitChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnInitChart.Name = "btnInitChart";
            this.btnInitChart.Size = new System.Drawing.Size(140, 35);
            this.btnInitChart.TabIndex = 11;
            this.btnInitChart.Text = "InitChart";
            this.btnInitChart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInitChart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnInitChart.Click += new System.EventHandler(this.btnInitChart_Click);
            // 
            // cpStart
            // 
            this.cpStart.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cpStart.FillColor = System.Drawing.Color.White;
            this.cpStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpStart.Location = new System.Drawing.Point(448, 131);
            this.cpStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpStart.MinimumSize = new System.Drawing.Size(63, 0);
            this.cpStart.Name = "cpStart";
            this.cpStart.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cpStart.Size = new System.Drawing.Size(140, 35);
            this.cpStart.TabIndex = 12;
            this.cpStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cpEnd
            // 
            this.cpEnd.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cpEnd.FillColor = System.Drawing.Color.White;
            this.cpEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpEnd.Location = new System.Drawing.Point(623, 131);
            this.cpEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpEnd.MinimumSize = new System.Drawing.Size(63, 0);
            this.cpEnd.Name = "cpEnd";
            this.cpEnd.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cpEnd.Size = new System.Drawing.Size(140, 35);
            this.cpEnd.TabIndex = 12;
            this.cpEnd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(798, 230);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 35);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(798, 134);
            this.nudCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(140, 39);
            this.nudCount.TabIndex = 13;
            this.nudCount.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(448, 230);
            this.btnExport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 35);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // CustomChartFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.cpEnd);
            this.Controls.Add(this.cpStart);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnInitChart);
            this.Controls.Add(this.txtXMin);
            this.Controls.Add(this.txtXMax);
            this.Controls.Add(this.lblMethod1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.uiLine1);
            this.Name = "CustomChartFrm";
            this.Size = new System.Drawing.Size(960, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProxyTools.SunnyUI.Controls.UILine uiLine1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ProxyTools.SunnyUI.Controls.UILabel lblMethod1;
        private ProxyTools.SunnyUI.Controls.UITextBox txtXMax;
        private ProxyTools.SunnyUI.Controls.UITextBox txtXMin;
        private ProxyTools.SunnyUI.Controls.UIButton btnInitChart;
        private ProxyTools.SunnyUI.Controls.UIColorPicker cpStart;
        private ProxyTools.SunnyUI.Controls.UIColorPicker cpEnd;
        private ProxyTools.SunnyUI.Controls.UIButton btnSave;
        private System.Windows.Forms.NumericUpDown nudCount;
        private ProxyTools.SunnyUI.Controls.UIButton btnExport;
    }
}
