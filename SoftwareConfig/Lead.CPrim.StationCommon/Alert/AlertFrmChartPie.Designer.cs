
using Lead.CPrim.ProxyTools.SunnyUI.Charts;

namespace Lead.CPrim.StationCommon.Alert
{
    partial class AlertFrmChartPie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingTop10BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlpPie = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lb_Title = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.dgvTop10 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingTop10BindingSource)).BeginInit();
            this.tlpPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingTop10BindingSource
            // 
            this.bindingTop10BindingSource.DataSource = typeof(Lead.CPrim.Interfaces.DowntimeData);
            // 
            // tlpPie
            // 
            this.tlpPie.ColumnCount = 2;
            this.tlpPie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPie.Controls.Add(this.lb_Title, 0, 0);
            this.tlpPie.Controls.Add(this.dgvTop10, 0, 1);
            this.tlpPie.Controls.Add(this.chart1, 1, 0);
            this.tlpPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPie.Location = new System.Drawing.Point(0, 0);
            this.tlpPie.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPie.Name = "tlpPie";
            this.tlpPie.RowCount = 2;
            this.tlpPie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPie.Size = new System.Drawing.Size(680, 319);
            this.tlpPie.TabIndex = 4;
            this.tlpPie.TagString = null;
            // 
            // lb_Title
            // 
            this.lb_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Title.Location = new System.Drawing.Point(3, 0);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(334, 50);
            this.lb_Title.TabIndex = 3;
            this.lb_Title.Text = " Downtime Statistic (Top10)";
            this.lb_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Title.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dgvTop10
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvTop10.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTop10.AutoGenerateColumns = false;
            this.dgvTop10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTop10.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvTop10.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTop10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTop10.ColumnHeadersHeight = 50;
            this.dgvTop10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTop10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colorNameDataGridViewTextBoxColumn,
            this.error,
            this.totalTime,
            this.countTotal});
            this.dgvTop10.DataSource = this.bindingTop10BindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTop10.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTop10.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTop10.EnableHeadersVisualStyles = false;
            this.dgvTop10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvTop10.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvTop10.Location = new System.Drawing.Point(3, 53);
            this.dgvTop10.Name = "dgvTop10";
            this.dgvTop10.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTop10.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTop10.RowHeadersVisible = false;
            this.dgvTop10.RowHeadersWidth = 51;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvTop10.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTop10.RowTemplate.Height = 27;
            this.dgvTop10.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvTop10.SelectedIndex = -1;
            this.dgvTop10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTop10.Size = new System.Drawing.Size(334, 263);
            this.dgvTop10.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgvTop10.TabIndex = 2;
            this.dgvTop10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvTop10.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Yellow;
            chartArea1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(343, 3);
            this.chart1.Name = "chart1";
            this.tlpPie.SetRowSpan(this.chart1, 2);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(334, 313);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // colorNameDataGridViewTextBoxColumn
            // 
            this.colorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colorNameDataGridViewTextBoxColumn.DataPropertyName = "ColorName";
            this.colorNameDataGridViewTextBoxColumn.FillWeight = 30F;
            this.colorNameDataGridViewTextBoxColumn.HeaderText = "";
            this.colorNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.colorNameDataGridViewTextBoxColumn.Name = "colorNameDataGridViewTextBoxColumn";
            this.colorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorNameDataGridViewTextBoxColumn.Width = 30;
            // 
            // error
            // 
            this.error.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.error.DataPropertyName = "Error";
            this.error.FillWeight = 70F;
            this.error.HeaderText = "Error";
            this.error.MinimumWidth = 8;
            this.error.Name = "error";
            this.error.ReadOnly = true;
            // 
            // totalTime
            // 
            this.totalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.totalTime.DataPropertyName = "TotalTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.totalTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.totalTime.FillWeight = 50F;
            this.totalTime.HeaderText = "Total Time(Min)";
            this.totalTime.MinimumWidth = 8;
            this.totalTime.Name = "totalTime";
            this.totalTime.ReadOnly = true;
            this.totalTime.Width = 60;
            // 
            // countTotal
            // 
            this.countTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.countTotal.DataPropertyName = "CountTotal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.countTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.countTotal.FillWeight = 50F;
            this.countTotal.HeaderText = "Count Total";
            this.countTotal.MinimumWidth = 8;
            this.countTotal.Name = "countTotal";
            this.countTotal.ReadOnly = true;
            this.countTotal.Width = 50;
            // 
            // AlertFrmChartPie
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.tlpPie);
            this.Name = "AlertFrmChartPie";
            this.Size = new System.Drawing.Size(680, 319);
            this.Load += new System.EventHandler(this.FrmPieChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingTop10BindingSource)).EndInit();
            this.tlpPie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView dgvTop10;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lb_Title;
        private ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpPie;
        private System.Windows.Forms.BindingSource bindingTop10BindingSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn error;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn countTotal;
    }
}