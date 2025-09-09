
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Sunny.UI;

namespace Lead.CPrim.StationCommon
{
    partial class DataForm
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SWBn_Day_Hour = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISwitchStyle();
            this.SWBn_IO_Tossing_Yield = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISelectText();
            this.pnl_Chart1 = new System.Windows.Forms.Panel();
            this.dtp_Chart1_EndTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDatetimePicker();
            this.dtp_Chart1_StartTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDatetimePicker();
            this.hsb_Chart1 = new Sunny.UI.UIHorScrollBar();
            this.pnl_Chart2 = new System.Windows.Forms.Panel();
            this.dtp_Chart2_EndTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDatetimePicker();
            this.dtp_Chart2_StartTime = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDatetimePicker();
            this.hsb_Chart2 = new Sunny.UI.UIHorScrollBar();
            this.btnExport = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.pnlStatistics = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.time_Updata_StationStatistic = new System.Windows.Forms.Timer(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Chart1.SuspendLayout();
            this.pnl_Chart2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Transparent;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Controls.Add(this.btnExport, 1, 1);
            this.tlpMain.Controls.Add(this.pnlStatistics, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1155, 489);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpLeft
            // 
            this.tlpLeft.BackColor = System.Drawing.Color.LightGray;
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.panel1, 0, 0);
            this.tlpLeft.Controls.Add(this.pnl_Chart1, 0, 1);
            this.tlpLeft.Controls.Add(this.pnl_Chart2, 0, 3);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(0, 0);
            this.tlpLeft.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 5;
            this.tlpMain.SetRowSpan(this.tlpLeft, 2);
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeft.Size = new System.Drawing.Size(914, 489);
            this.tlpLeft.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SWBn_Day_Hour);
            this.panel1.Controls.Add(this.SWBn_IO_Tossing_Yield);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 34);
            this.panel1.TabIndex = 1;
            // 
            // SWBn_Day_Hour
            // 
            this.SWBn_Day_Hour.BackColor = System.Drawing.Color.LightGray;
            this.SWBn_Day_Hour.CheckedText = "Hour";
            this.SWBn_Day_Hour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SWBn_Day_Hour.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SWBn_Day_Hour.Location = new System.Drawing.Point(560, 2);
            this.SWBn_Day_Hour.MinimumSize = new System.Drawing.Size(1, 1);
            this.SWBn_Day_Hour.Name = "SWBn_Day_Hour";
            this.SWBn_Day_Hour.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.SWBn_Day_Hour.Size = new System.Drawing.Size(140, 30);
            this.SWBn_Day_Hour.TabIndex = 14;
            this.SWBn_Day_Hour.Text = "uiSwitchStyle1";
            this.SWBn_Day_Hour.UnCheckedText = "Day";
            this.SWBn_Day_Hour.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // SWBn_IO_Tossing_Yield
            // 
            this.SWBn_IO_Tossing_Yield.BackColor = System.Drawing.Color.LightGray;
            this.SWBn_IO_Tossing_Yield.FillColor = System.Drawing.Color.LightGray;
            this.SWBn_IO_Tossing_Yield.FillColor2 = System.Drawing.Color.LightGray;
            this.SWBn_IO_Tossing_Yield.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SWBn_IO_Tossing_Yield.Location = new System.Drawing.Point(10, 2);
            this.SWBn_IO_Tossing_Yield.MinimumSize = new System.Drawing.Size(1, 1);
            this.SWBn_IO_Tossing_Yield.Name = "SWBn_IO_Tossing_Yield";
            this.SWBn_IO_Tossing_Yield.RectColor = System.Drawing.Color.LightGray;
            this.SWBn_IO_Tossing_Yield.RectDisableColor = System.Drawing.Color.LightGray;
            this.SWBn_IO_Tossing_Yield.Size = new System.Drawing.Size(300, 30);
            this.SWBn_IO_Tossing_Yield.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.SWBn_IO_Tossing_Yield.StyleCustomMode = true;
            this.SWBn_IO_Tossing_Yield.TabIndex = 0;
            this.SWBn_IO_Tossing_Yield.Text = "uiSelectText1";
            this.SWBn_IO_Tossing_Yield.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.SWBn_IO_Tossing_Yield.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnl_Chart1
            // 
            this.pnl_Chart1.Controls.Add(this.dtp_Chart1_EndTime);
            this.pnl_Chart1.Controls.Add(this.dtp_Chart1_StartTime);
            this.pnl_Chart1.Controls.Add(this.hsb_Chart1);
            this.pnl_Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Chart1.Location = new System.Drawing.Point(3, 43);
            this.pnl_Chart1.Name = "pnl_Chart1";
            this.pnl_Chart1.Size = new System.Drawing.Size(908, 137);
            this.pnl_Chart1.TabIndex = 2;
            // 
            // dtp_Chart1_EndTime
            // 
            this.dtp_Chart1_EndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_Chart1_EndTime.FillColor = System.Drawing.Color.White;
            this.dtp_Chart1_EndTime.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_Chart1_EndTime.Location = new System.Drawing.Point(774, 5);
            this.dtp_Chart1_EndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp_Chart1_EndTime.MaxLength = 19;
            this.dtp_Chart1_EndTime.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtp_Chart1_EndTime.Name = "dtp_Chart1_EndTime";
            this.dtp_Chart1_EndTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtp_Chart1_EndTime.Size = new System.Drawing.Size(130, 20);
            this.dtp_Chart1_EndTime.SymbolDropDown = 61555;
            this.dtp_Chart1_EndTime.SymbolNormal = 61555;
            this.dtp_Chart1_EndTime.TabIndex = 60;
            this.dtp_Chart1_EndTime.Text = "2023-01-09 01:43:42";
            this.dtp_Chart1_EndTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtp_Chart1_EndTime.Value = new System.DateTime(2023, 1, 9, 1, 43, 42, 702);
            this.dtp_Chart1_EndTime.Watermark = "";
            this.dtp_Chart1_EndTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dtp_Chart1_EndTime.OnComfirmOK += new System.Action(this.dtp_Chart1_EndTime_OnComfirmOK);
            this.dtp_Chart1_EndTime.DropDownClosed += new System.EventHandler(this.dtp_Chart1_EndTime_DropDownClosed);
            // 
            // dtp_Chart1_StartTime
            // 
            this.dtp_Chart1_StartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_Chart1_StartTime.FillColor = System.Drawing.Color.White;
            this.dtp_Chart1_StartTime.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_Chart1_StartTime.Location = new System.Drawing.Point(629, 5);
            this.dtp_Chart1_StartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp_Chart1_StartTime.MaxLength = 19;
            this.dtp_Chart1_StartTime.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtp_Chart1_StartTime.Name = "dtp_Chart1_StartTime";
            this.dtp_Chart1_StartTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtp_Chart1_StartTime.Size = new System.Drawing.Size(130, 20);
            this.dtp_Chart1_StartTime.SymbolDropDown = 61555;
            this.dtp_Chart1_StartTime.SymbolNormal = 61555;
            this.dtp_Chart1_StartTime.TabIndex = 61;
            this.dtp_Chart1_StartTime.Text = "2023-01-09 01:43:42";
            this.dtp_Chart1_StartTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtp_Chart1_StartTime.Value = new System.DateTime(2023, 1, 9, 1, 43, 42, 702);
            this.dtp_Chart1_StartTime.Watermark = "";
            this.dtp_Chart1_StartTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dtp_Chart1_StartTime.OnComfirmOK += new System.Action(this.dtp_Chart1_StartTime_OnComfirmOK);
            this.dtp_Chart1_StartTime.DropDownClosed += new System.EventHandler(this.dtp_Chart1_StartTime_DropDownClosed);
            // 
            // hsb_Chart1
            // 
            this.hsb_Chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsb_Chart1.Cursor = System.Windows.Forms.Cursors.Default;
            this.hsb_Chart1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hsb_Chart1.Location = new System.Drawing.Point(629, 28);
            this.hsb_Chart1.Maximum = 7;
            this.hsb_Chart1.MinimumSize = new System.Drawing.Size(1, 1);
            this.hsb_Chart1.Name = "hsb_Chart1";
            this.hsb_Chart1.Size = new System.Drawing.Size(275, 12);
            this.hsb_Chart1.TabIndex = 59;
            this.hsb_Chart1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.hsb_Chart1.ValueChanged += new System.EventHandler(this.hsb_Chart1_ValueChanged);
            // 
            // pnl_Chart2
            // 
            this.pnl_Chart2.Controls.Add(this.dtp_Chart2_EndTime);
            this.pnl_Chart2.Controls.Add(this.dtp_Chart2_StartTime);
            this.pnl_Chart2.Controls.Add(this.hsb_Chart2);
            this.pnl_Chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Chart2.Location = new System.Drawing.Point(3, 206);
            this.pnl_Chart2.Name = "pnl_Chart2";
            this.pnl_Chart2.Size = new System.Drawing.Size(908, 137);
            this.pnl_Chart2.TabIndex = 3;
            // 
            // dtp_Chart2_EndTime
            // 
            this.dtp_Chart2_EndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_Chart2_EndTime.FillColor = System.Drawing.Color.White;
            this.dtp_Chart2_EndTime.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_Chart2_EndTime.Location = new System.Drawing.Point(774, 5);
            this.dtp_Chart2_EndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp_Chart2_EndTime.MaxLength = 19;
            this.dtp_Chart2_EndTime.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtp_Chart2_EndTime.Name = "dtp_Chart2_EndTime";
            this.dtp_Chart2_EndTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtp_Chart2_EndTime.Size = new System.Drawing.Size(130, 20);
            this.dtp_Chart2_EndTime.SymbolDropDown = 61555;
            this.dtp_Chart2_EndTime.SymbolNormal = 61555;
            this.dtp_Chart2_EndTime.TabIndex = 60;
            this.dtp_Chart2_EndTime.Text = "2023-01-09 01:43:42";
            this.dtp_Chart2_EndTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtp_Chart2_EndTime.Value = new System.DateTime(2023, 1, 9, 1, 43, 42, 702);
            this.dtp_Chart2_EndTime.Watermark = "";
            this.dtp_Chart2_EndTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dtp_Chart2_EndTime.OnComfirmOK += new System.Action(this.dtp_Chart2_EndTime_OnComfirmOK);
            this.dtp_Chart2_EndTime.DropDownClosed += new System.EventHandler(this.dtp_Chart2_EndTime_DropDownClosed);
            // 
            // dtp_Chart2_StartTime
            // 
            this.dtp_Chart2_StartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_Chart2_StartTime.FillColor = System.Drawing.Color.White;
            this.dtp_Chart2_StartTime.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_Chart2_StartTime.Location = new System.Drawing.Point(629, 5);
            this.dtp_Chart2_StartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp_Chart2_StartTime.MaxLength = 19;
            this.dtp_Chart2_StartTime.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtp_Chart2_StartTime.Name = "dtp_Chart2_StartTime";
            this.dtp_Chart2_StartTime.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtp_Chart2_StartTime.Size = new System.Drawing.Size(130, 20);
            this.dtp_Chart2_StartTime.SymbolDropDown = 61555;
            this.dtp_Chart2_StartTime.SymbolNormal = 61555;
            this.dtp_Chart2_StartTime.TabIndex = 61;
            this.dtp_Chart2_StartTime.Text = "2023-01-09 01:43:42";
            this.dtp_Chart2_StartTime.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dtp_Chart2_StartTime.Value = new System.DateTime(2023, 1, 9, 1, 43, 42, 702);
            this.dtp_Chart2_StartTime.Watermark = "";
            this.dtp_Chart2_StartTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dtp_Chart2_StartTime.OnComfirmOK += new System.Action(this.dtp_Chart2_StartTime_OnComfirmOK);
            this.dtp_Chart2_StartTime.DropDownClosed += new System.EventHandler(this.dtp_Chart2_StartTime_DropDownClosed);
            // 
            // hsb_Chart2
            // 
            this.hsb_Chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hsb_Chart2.Cursor = System.Windows.Forms.Cursors.Default;
            this.hsb_Chart2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hsb_Chart2.Location = new System.Drawing.Point(629, 28);
            this.hsb_Chart2.Maximum = 7;
            this.hsb_Chart2.MinimumSize = new System.Drawing.Size(1, 1);
            this.hsb_Chart2.Name = "hsb_Chart2";
            this.hsb_Chart2.Size = new System.Drawing.Size(275, 12);
            this.hsb_Chart2.TabIndex = 59;
            this.hsb_Chart2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.hsb_Chart2.ValueChanged += new System.EventHandler(this.hsb_Chart2_ValueChanged);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(944, 449);
            this.btnExport.Margin = new System.Windows.Forms.Padding(20, 10, 20, 5);
            this.btnExport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(191, 35);
            this.btnExport.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatistics.FillColor = System.Drawing.Color.LightGray;
            this.pnlStatistics.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlStatistics.Location = new System.Drawing.Point(924, 0);
            this.pnlStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatistics.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnlStatistics.RectColor = System.Drawing.Color.LightGray;
            this.pnlStatistics.Size = new System.Drawing.Size(231, 439);
            this.pnlStatistics.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlStatistics.TabIndex = 3;
            this.pnlStatistics.Text = null;
            this.pnlStatistics.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlStatistics.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // time_Updata_StationStatistic
            // 
            this.time_Updata_StationStatistic.Enabled = true;
            this.time_Updata_StationStatistic.Tick += new System.EventHandler(this.time_Updata_StationStatistic_Tick);
            // 
            // DataForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1155, 489);
            this.Controls.Add(this.tlpMain);
            this.Name = "DataForm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Load += new System.EventHandler(this.DataForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnl_Chart1.ResumeLayout(false);
            this.pnl_Chart2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private UIButton btnExport;
        private UIPanel pnlStatistics;
        private System.Windows.Forms.Timer time_Updata_StationStatistic;
        private UISwitchStyle SWBn_Day_Hour;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.Panel panel1;
        private UISelectText SWBn_IO_Tossing_Yield;
        private System.Windows.Forms.Panel pnl_Chart1;
        private System.Windows.Forms.Panel pnl_Chart2;
        private UIDatetimePicker dtp_Chart1_EndTime;
        private UIDatetimePicker dtp_Chart1_StartTime;
        private UIHorScrollBar hsb_Chart1;
        private UIDatetimePicker dtp_Chart2_EndTime;
        private UIDatetimePicker dtp_Chart2_StartTime;
        private UIHorScrollBar hsb_Chart2;
    }
}
