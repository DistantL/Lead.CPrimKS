
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.ShowCapacityOfProduction.Controls
{
    partial class AnalysisMode
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splMain = new UISplitContainer();
            this.cbFai = new System.Windows.Forms.ComboBox();
            this.lblFai = new UILabel();
            this.btnQuery = new UISymbolButton();
            this.lblStart = new UILabel();
            this.lblEnd = new UILabel();
            this.dpStart = new System.Windows.Forms.DateTimePicker();
            this.dpEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1100, 439);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // splMain
            // 
            this.splMain.BarColor = System.Drawing.SystemColors.ControlLight;
            this.splMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.HandleColor = System.Drawing.SystemColors.Control;
            this.splMain.Location = new System.Drawing.Point(0, 0);
            this.splMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.splMain.Name = "splMain";
            this.splMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.dpEnd);
            this.splMain.Panel1.Controls.Add(this.dpStart);
            this.splMain.Panel1.Controls.Add(this.btnQuery);
            this.splMain.Panel1.Controls.Add(this.lblEnd);
            this.splMain.Panel1.Controls.Add(this.lblStart);
            this.splMain.Panel1.Controls.Add(this.lblFai);
            this.splMain.Panel1.Controls.Add(this.cbFai);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.chart1);
            this.splMain.Size = new System.Drawing.Size(1100, 500);
            this.splMain.SplitterWidth = 11;
            this.splMain.Style = UIStyle.Custom;
            this.splMain.TabIndex = 1;
            this.splMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbFai
            // 
            this.cbFai.FormattingEnabled = true;
            this.cbFai.Location = new System.Drawing.Point(700, 11);
            this.cbFai.Name = "cbFai";
            this.cbFai.Size = new System.Drawing.Size(178, 29);
            this.cbFai.TabIndex = 0;
            // 
            // lblFai
            // 
            this.lblFai.AutoSize = true;
            this.lblFai.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFai.Location = new System.Drawing.Point(627, 15);
            this.lblFai.Name = "lblFai";
            this.lblFai.Size = new System.Drawing.Size(67, 21);
            this.lblFai.TabIndex = 1;
            this.lblFai.Text = "FAI集合";
            this.lblFai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFai.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Blue;
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(908, 8);
            this.btnQuery.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(166, 35);
            this.btnQuery.Symbol = 61454;
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStart.Location = new System.Drawing.Point(25, 15);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(74, 21);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "开始时间";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEnd.Location = new System.Drawing.Point(321, 15);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(74, 21);
            this.lblEnd.TabIndex = 1;
            this.lblEnd.Text = "结束时间";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEnd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dpStart
            // 
            this.dpStart.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpStart.Location = new System.Drawing.Point(105, 11);
            this.dpStart.Name = "dpStart";
            this.dpStart.Size = new System.Drawing.Size(200, 29);
            this.dpStart.TabIndex = 3;
            // 
            // dpEnd
            // 
            this.dpEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpEnd.Location = new System.Drawing.Point(401, 11);
            this.dpEnd.Name = "dpEnd";
            this.dpEnd.Size = new System.Drawing.Size(200, 29);
            this.dpEnd.TabIndex = 3;
            // 
            // AnalysisMode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1100, 500);
            this.Controls.Add(this.splMain);
            this.Name = "AnalysisMode";
            this.Style = UIStyle.Custom;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel1.PerformLayout();
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private UISplitContainer splMain;
        private UISymbolButton btnQuery;
        private UILabel lblEnd;
        private UILabel lblStart;
        private UILabel lblFai;
        private System.Windows.Forms.ComboBox cbFai;
        private System.Windows.Forms.DateTimePicker dpEnd;
        private System.Windows.Forms.DateTimePicker dpStart;
    }
}
