using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    partial class Vendor
    {

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private IContainer components = null;



        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
            base.Dispose(disposing);
		}

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
		{
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.tBoxStationIdx = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.tabMain = new Sunny.UI.UITabControl();
            this.tPageMonitor = new System.Windows.Forms.TabPage();
            this.tlpMonitor = new System.Windows.Forms.TableLayoutPanel();
            this.uiGroupBox1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIGroupBox();
            this.tlpButton = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.btnStationEvent1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.btnStationEvent2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.btnStationEvent3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.tbRunningState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.gp_MonitorParameter = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIGroupBox();
            this.pnlRtData = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.lb_SelectProduction = new System.Windows.Forms.Label();
            this.gp_Monitor = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIGroupBox();
            this.flpTask = new System.Windows.Forms.FlowLayoutPanel();
            this.tpProductQuery = new System.Windows.Forms.TabPage();
            this.tpChart = new System.Windows.Forms.TabPage();
            this.tpLogMain = new System.Windows.Forms.TabPage();
            this.tpLogTask = new System.Windows.Forms.TabPage();
            this.tpLogQuery = new System.Windows.Forms.TabPage();
            this.tpStatistics = new System.Windows.Forms.TabPage();
            this.tpAlertInfo = new System.Windows.Forms.TabPage();
            this.tpDispalyNGReason = new System.Windows.Forms.TabPage();
            this.tpWarnInfo = new System.Windows.Forms.TabPage();
            this.tlpMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tPageMonitor.SuspendLayout();
            this.tlpMonitor.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.tlpButton.SuspendLayout();
            this.gp_MonitorParameter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gp_Monitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(388, 2);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(1305, 28);
            this.miniToolStrip.TabIndex = 0;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(171, 40);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(129, 25);
            this.textBox11.TabIndex = 20;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tBoxStationIdx
            // 
            this.tBoxStationIdx.Location = new System.Drawing.Point(486, 40);
            this.tBoxStationIdx.Margin = new System.Windows.Forms.Padding(4);
            this.tBoxStationIdx.Name = "tBoxStationIdx";
            this.tBoxStationIdx.Size = new System.Drawing.Size(129, 25);
            this.tBoxStationIdx.TabIndex = 20;
            this.tBoxStationIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Location = new System.Drawing.Point(7, 43);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 19, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 15);
            this.label17.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(322, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 19, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(6, 79);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 19, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 23;
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlMain, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1291, 600);
            this.tlpMain.TabIndex = 12;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.tabMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1289, 598);
            this.pnlMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlMain.StyleCustomMode = true;
            this.pnlMain.TabIndex = 14;
            this.pnlMain.Text = null;
            this.pnlMain.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tPageMonitor);
            this.tabMain.Controls.Add(this.tpDispalyNGReason);
            this.tabMain.Controls.Add(this.tpProductQuery);
            this.tabMain.Controls.Add(this.tpChart);
            this.tabMain.Controls.Add(this.tpLogMain);
            this.tabMain.Controls.Add(this.tpLogTask);
            this.tabMain.Controls.Add(this.tpLogQuery);
            this.tabMain.Controls.Add(this.tpStatistics);
            this.tabMain.Controls.Add(this.tpAlertInfo);
            this.tabMain.Controls.Add(this.tpWarnInfo);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMain.ItemSize = new System.Drawing.Size(150, 40);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.MainPage = "";
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1289, 598);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tabMain.StyleCustomMode = true;
            this.tabMain.TabIndex = 13;
            this.tabMain.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tPageMonitor
            // 
            this.tPageMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tPageMonitor.Controls.Add(this.tlpMonitor);
            this.tPageMonitor.Location = new System.Drawing.Point(0, 40);
            this.tPageMonitor.Name = "tPageMonitor";
            this.tPageMonitor.Size = new System.Drawing.Size(1289, 558);
            this.tPageMonitor.TabIndex = 3;
            this.tPageMonitor.Text = "线程监控";
            // 
            // tlpMonitor
            // 
            this.tlpMonitor.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMonitor.ColumnCount = 2;
            this.tlpMonitor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMonitor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 242F));
            this.tlpMonitor.Controls.Add(this.uiGroupBox1, 1, 0);
            this.tlpMonitor.Controls.Add(this.gp_MonitorParameter, 0, 1);
            this.tlpMonitor.Controls.Add(this.panel1, 1, 1);
            this.tlpMonitor.Controls.Add(this.gp_Monitor, 0, 0);
            this.tlpMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMonitor.Location = new System.Drawing.Point(0, 0);
            this.tlpMonitor.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMonitor.Name = "tlpMonitor";
            this.tlpMonitor.RowCount = 2;
            this.tlpMonitor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMonitor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMonitor.Size = new System.Drawing.Size(1289, 558);
            this.tlpMonitor.TabIndex = 1;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.tlpButton);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(1050, 6);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(3, 32, 3, 3);
            this.uiGroupBox1.Radius = 20;
            this.uiGroupBox1.RectColor = System.Drawing.Color.DarkGray;
            this.uiGroupBox1.Size = new System.Drawing.Size(234, 465);
            this.uiGroupBox1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 7;
            this.uiGroupBox1.Text = null;
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpButton
            // 
            this.tlpButton.ColumnCount = 1;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Controls.Add(this.btnStationEvent1, 0, 14);
            this.tlpButton.Controls.Add(this.btnStationEvent2, 0, 12);
            this.tlpButton.Controls.Add(this.btnStationEvent3, 0, 10);
            this.tlpButton.Controls.Add(this.tbRunningState, 0, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(3, 32);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 15;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpButton.Size = new System.Drawing.Size(228, 430);
            this.tlpButton.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpButton.TabIndex = 0;
            this.tlpButton.TagString = null;
            // 
            // btnStationEvent1
            // 
            this.btnStationEvent1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStationEvent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStationEvent1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStationEvent1.Location = new System.Drawing.Point(3, 388);
            this.btnStationEvent1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStationEvent1.Name = "btnStationEvent1";
            this.btnStationEvent1.Size = new System.Drawing.Size(222, 39);
            this.btnStationEvent1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnStationEvent1.Symbol = 261604;
            this.btnStationEvent1.TabIndex = 0;
            this.btnStationEvent1.Text = "事件1";
            this.btnStationEvent1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStationEvent1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnStationEvent1.Click += new System.EventHandler(this.DevMainButtonPress_Click);
            // 
            // btnStationEvent2
            // 
            this.btnStationEvent2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStationEvent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStationEvent2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStationEvent2.Location = new System.Drawing.Point(3, 333);
            this.btnStationEvent2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStationEvent2.Name = "btnStationEvent2";
            this.btnStationEvent2.Size = new System.Drawing.Size(222, 34);
            this.btnStationEvent2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnStationEvent2.Symbol = 261604;
            this.btnStationEvent2.TabIndex = 0;
            this.btnStationEvent2.Text = "事件2";
            this.btnStationEvent2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStationEvent2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnStationEvent2.Click += new System.EventHandler(this.DevMainButtonPress_Click);
            // 
            // btnStationEvent3
            // 
            this.btnStationEvent3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStationEvent3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStationEvent3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStationEvent3.Location = new System.Drawing.Point(3, 278);
            this.btnStationEvent3.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStationEvent3.Name = "btnStationEvent3";
            this.btnStationEvent3.Size = new System.Drawing.Size(222, 34);
            this.btnStationEvent3.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnStationEvent3.Symbol = 261604;
            this.btnStationEvent3.TabIndex = 0;
            this.btnStationEvent3.Text = "事件3";
            this.btnStationEvent3.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStationEvent3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnStationEvent3.Click += new System.EventHandler(this.DevMainButtonPress_Click);
            // 
            // tbRunningState
            // 
            this.tbRunningState.BackColor = System.Drawing.Color.DimGray;
            this.tbRunningState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRunningState.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRunningState.Location = new System.Drawing.Point(3, 3);
            this.tbRunningState.Margin = new System.Windows.Forms.Padding(3);
            this.tbRunningState.Name = "tbRunningState";
            this.tbRunningState.Size = new System.Drawing.Size(222, 34);
            this.tbRunningState.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbRunningState.TabIndex = 1;
            this.tbRunningState.Text = "未初始化";
            this.tbRunningState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbRunningState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // gp_MonitorParameter
            // 
            this.gp_MonitorParameter.Controls.Add(this.pnlRtData);
            this.gp_MonitorParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_MonitorParameter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.gp_MonitorParameter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gp_MonitorParameter.Location = new System.Drawing.Point(5, 482);
            this.gp_MonitorParameter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gp_MonitorParameter.MinimumSize = new System.Drawing.Size(1, 1);
            this.gp_MonitorParameter.Name = "gp_MonitorParameter";
            this.gp_MonitorParameter.Padding = new System.Windows.Forms.Padding(3, 32, 3, 3);
            this.gp_MonitorParameter.Radius = 20;
            this.gp_MonitorParameter.RectColor = System.Drawing.Color.DarkGray;
            this.gp_MonitorParameter.Size = new System.Drawing.Size(1036, 70);
            this.gp_MonitorParameter.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.gp_MonitorParameter.TabIndex = 1;
            this.gp_MonitorParameter.Text = "实时变量";
            this.gp_MonitorParameter.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gp_MonitorParameter.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlRtData
            // 
            this.pnlRtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRtData.Location = new System.Drawing.Point(3, 32);
            this.pnlRtData.Name = "pnlRtData";
            this.pnlRtData.Size = new System.Drawing.Size(1030, 35);
            this.pnlRtData.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbProducts);
            this.panel1.Controls.Add(this.lb_SelectProduction);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1049, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 74);
            this.panel1.TabIndex = 0;
            // 
            // cmbProducts
            // 
            this.cmbProducts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(0, 39);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(236, 35);
            this.cmbProducts.TabIndex = 0;
            // 
            // lb_SelectProduction
            // 
            this.lb_SelectProduction.AutoSize = true;
            this.lb_SelectProduction.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SelectProduction.Location = new System.Drawing.Point(53, 11);
            this.lb_SelectProduction.Name = "lb_SelectProduction";
            this.lb_SelectProduction.Size = new System.Drawing.Size(92, 27);
            this.lb_SelectProduction.TabIndex = 1;
            this.lb_SelectProduction.Text = "产品选择";
            // 
            // gp_Monitor
            // 
            this.gp_Monitor.Controls.Add(this.flpTask);
            this.gp_Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gp_Monitor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.gp_Monitor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gp_Monitor.Location = new System.Drawing.Point(5, 6);
            this.gp_Monitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gp_Monitor.MinimumSize = new System.Drawing.Size(1, 1);
            this.gp_Monitor.Name = "gp_Monitor";
            this.gp_Monitor.Padding = new System.Windows.Forms.Padding(3, 32, 3, 3);
            this.gp_Monitor.Radius = 20;
            this.gp_Monitor.RectColor = System.Drawing.Color.DarkGray;
            this.gp_Monitor.Size = new System.Drawing.Size(1036, 465);
            this.gp_Monitor.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.gp_Monitor.TabIndex = 6;
            this.gp_Monitor.Text = "线程监控";
            this.gp_Monitor.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gp_Monitor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // flpTask
            // 
            this.flpTask.AutoScroll = true;
            this.flpTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTask.Location = new System.Drawing.Point(3, 32);
            this.flpTask.Margin = new System.Windows.Forms.Padding(0);
            this.flpTask.Name = "flpTask";
            this.flpTask.Size = new System.Drawing.Size(1030, 430);
            this.flpTask.TabIndex = 4;
            // 
            // tpProductQuery
            // 
            this.tpProductQuery.Location = new System.Drawing.Point(0, 40);
            this.tpProductQuery.Margin = new System.Windows.Forms.Padding(0);
            this.tpProductQuery.Name = "tpProductQuery";
            this.tpProductQuery.Size = new System.Drawing.Size(1289, 558);
            this.tpProductQuery.TabIndex = 4;
            this.tpProductQuery.Text = "产品查询";
            this.tpProductQuery.UseVisualStyleBackColor = true;
            // 
            // tpChart
            // 
            this.tpChart.Location = new System.Drawing.Point(0, 40);
            this.tpChart.Margin = new System.Windows.Forms.Padding(0);
            this.tpChart.Name = "tpChart";
            this.tpChart.Size = new System.Drawing.Size(1289, 558);
            this.tpChart.TabIndex = 5;
            this.tpChart.Text = "产品曲线";
            this.tpChart.UseVisualStyleBackColor = true;
            // 
            // tpLogMain
            // 
            this.tpLogMain.Location = new System.Drawing.Point(0, 40);
            this.tpLogMain.Margin = new System.Windows.Forms.Padding(0);
            this.tpLogMain.Name = "tpLogMain";
            this.tpLogMain.Size = new System.Drawing.Size(1289, 558);
            this.tpLogMain.TabIndex = 7;
            this.tpLogMain.Text = "日志主页";
            this.tpLogMain.UseVisualStyleBackColor = true;
            // 
            // tpLogTask
            // 
            this.tpLogTask.Location = new System.Drawing.Point(0, 40);
            this.tpLogTask.Margin = new System.Windows.Forms.Padding(0);
            this.tpLogTask.Name = "tpLogTask";
            this.tpLogTask.Size = new System.Drawing.Size(1289, 558);
            this.tpLogTask.TabIndex = 8;
            this.tpLogTask.Text = "任务日志";
            this.tpLogTask.UseVisualStyleBackColor = true;
            // 
            // tpLogQuery
            // 
            this.tpLogQuery.Location = new System.Drawing.Point(0, 40);
            this.tpLogQuery.Margin = new System.Windows.Forms.Padding(0);
            this.tpLogQuery.Name = "tpLogQuery";
            this.tpLogQuery.Size = new System.Drawing.Size(1289, 558);
            this.tpLogQuery.TabIndex = 6;
            this.tpLogQuery.Text = "日志查询";
            this.tpLogQuery.UseVisualStyleBackColor = true;
            // 
            // tpStatistics
            // 
            this.tpStatistics.Location = new System.Drawing.Point(0, 40);
            this.tpStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.tpStatistics.Name = "tpStatistics";
            this.tpStatistics.Size = new System.Drawing.Size(1289, 558);
            this.tpStatistics.TabIndex = 0;
            this.tpStatistics.Text = "统计";
            this.tpStatistics.UseVisualStyleBackColor = true;
            // 
            // tpAlertInfo
            // 
            this.tpAlertInfo.Location = new System.Drawing.Point(0, 40);
            this.tpAlertInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tpAlertInfo.Name = "tpAlertInfo";
            this.tpAlertInfo.Size = new System.Drawing.Size(1289, 558);
            this.tpAlertInfo.TabIndex = 9;
            this.tpAlertInfo.Text = "三语报警信息";
            this.tpAlertInfo.UseVisualStyleBackColor = true;
            // 
            // tpDispalyNGReason
            // 
            this.tpDispalyNGReason.Location = new System.Drawing.Point(0, 40);
            this.tpDispalyNGReason.Name = "tpDispalyNGReason";
            this.tpDispalyNGReason.Size = new System.Drawing.Size(1289, 558);
            this.tpDispalyNGReason.TabIndex = 10;
            this.tpDispalyNGReason.Text = "抛料信息";
            this.tpDispalyNGReason.UseVisualStyleBackColor = true;
            // 
            // tpWarnInfo
            // 
            this.tpWarnInfo.Location = new System.Drawing.Point(0, 40);
            this.tpWarnInfo.Name = "tpWarnInfo";
            this.tpWarnInfo.Size = new System.Drawing.Size(1289, 558);
            this.tpWarnInfo.TabIndex = 11;
            this.tpWarnInfo.Text = "警告信息";
            this.tpWarnInfo.UseVisualStyleBackColor = true;
            // 
            // Vendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1291, 600);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Vendor";
            this.RectColor = System.Drawing.Color.Transparent;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "Lead";
            this.Load += new System.EventHandler(this.DevMainForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tPageMonitor.ResumeLayout(false);
            this.tlpMonitor.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.tlpButton.ResumeLayout(false);
            this.gp_MonitorParameter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gp_Monitor.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        #endregion

		private ToolStrip miniToolStrip;

		private TextBox textBox11;

		private TextBox tBoxStationIdx;

		private Label label17;

		private Label label2;

		private Label label10;

		private TableLayoutPanel tlpMain;
        private ProxyTools.SunnyUI.Controls.UIPanel pnlMain;
        private Sunny.UI.UITabControl tabMain;
        private TabPage tPageMonitor;
        private TableLayoutPanel tlpMonitor;
        private ProxyTools.SunnyUI.Controls.UIGroupBox uiGroupBox1;
        private ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpButton;
        private ProxyTools.SunnyUI.Controls.UISymbolButton btnStationEvent1;
        private ProxyTools.SunnyUI.Controls.UISymbolButton btnStationEvent2;
        private ProxyTools.SunnyUI.Controls.UISymbolButton btnStationEvent3;
        private ProxyTools.SunnyUI.Controls.UILabel tbRunningState;
        private ProxyTools.SunnyUI.Controls.UIGroupBox gp_MonitorParameter;
        private Panel pnlRtData;
        private Panel panel1;
        private ComboBox cmbProducts;
        private Label lb_SelectProduction;
        private ProxyTools.SunnyUI.Controls.UIGroupBox gp_Monitor;
        private FlowLayoutPanel flpTask;
        private TabPage tpProductQuery;
        private TabPage tpChart;
        private TabPage tpLogMain;
        private TabPage tpLogTask;
        private TabPage tpLogQuery;
        private TabPage tpStatistics;
        private TabPage tpAlertInfo;
        private TabPage tpDispalyNGReason;
        private TabPage tpWarnInfo;
    }
}
