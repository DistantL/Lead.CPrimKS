using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.ShowCapacityOfProduction.Controls
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
            this.cmsDgvResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.splData = new UISplitContainer();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.rdoList = new Sunny.UI.UIRadioButton();
            this.rdoChart = new Sunny.UI.UIRadioButton();
            this.rdoAnalysis = new Sunny.UI.UIRadioButton();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInfoAll = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tlpInfoUp = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.uiLabel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel8 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lbVersion = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lbTaskVer = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel11 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel12 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel13 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel14 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnMachineLog = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.uiButton2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.tlpStatic = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lblCT = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel5 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel10 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblUPH = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel4 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel9 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel7 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblPass = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblInput = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel6 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblYield = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblResult = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiGroupBox1 = new UIGroupBox();
            this.smShow = new Lead.CPrim.ShowCapacityOfProduction.Controls.OperateInstruction();
            this.cmsDgvResult.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splData)).BeginInit();
            this.splData.Panel1.SuspendLayout();
            this.splData.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tlpInfoAll.SuspendLayout();
            this.tlpInfoUp.SuspendLayout();
            this.tlpStatic.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsDgvResult
            // 
            this.cmsDgvResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsDgvResult.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDgvResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.cmsDgvResult.Name = "contextMenuStrip";
            this.cmsDgvResult.Size = new System.Drawing.Size(127, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.clearToolStripMenuItem.Text = "清除数据";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.Controls.Add(this.splData, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1020, 500);
            this.tlpMain.TabIndex = 46;
            // 
            // splData
            // 
            this.splData.BarColor = System.Drawing.SystemColors.ControlLight;
            this.splData.Cursor = System.Windows.Forms.Cursors.Default;
            this.splData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splData.HandleColor = System.Drawing.SystemColors.Control;
            this.splData.Location = new System.Drawing.Point(4, 4);
            this.splData.Margin = new System.Windows.Forms.Padding(0);
            this.splData.MinimumSize = new System.Drawing.Size(20, 20);
            this.splData.Name = "splData";
            this.splData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splData.Panel1
            // 
            this.splData.Panel1.ContextMenuStrip = this.cmsDgvResult;
            this.splData.Panel1.Controls.Add(this.tlpTitle);
            this.splData.Size = new System.Drawing.Size(674, 492);
            this.splData.SplitterDistance = 34;
            this.splData.SplitterWidth = 11;
            this.splData.TabIndex = 50;
            this.splData.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 3;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTitle.Controls.Add(this.rdoList, 0, 0);
            this.tlpTitle.Controls.Add(this.rdoChart, 1, 0);
            this.tlpTitle.Controls.Add(this.rdoAnalysis, 2, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTitle.Size = new System.Drawing.Size(674, 34);
            this.tlpTitle.TabIndex = 0;
            this.tlpTitle.TagString = null;
            // 
            // rdoList
            // 
            this.rdoList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoList.Location = new System.Drawing.Point(3, 3);
            this.rdoList.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoList.Name = "rdoList";
            this.rdoList.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoList.Size = new System.Drawing.Size(218, 28);
            this.rdoList.TabIndex = 2;
            this.rdoList.Text = "列表模式";
            this.rdoList.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdoList.CheckedChanged += new System.EventHandler(this.rdoModeExchange_CheckedChanged);
            // 
            // rdoChart
            // 
            this.rdoChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoChart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoChart.Location = new System.Drawing.Point(227, 3);
            this.rdoChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoChart.Name = "rdoChart";
            this.rdoChart.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoChart.Size = new System.Drawing.Size(218, 28);
            this.rdoChart.TabIndex = 3;
            this.rdoChart.Text = "图表模式";
            this.rdoChart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdoChart.CheckedChanged += new System.EventHandler(this.rdoModeExchange_CheckedChanged);
            // 
            // rdoAnalysis
            // 
            this.rdoAnalysis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAnalysis.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoAnalysis.Location = new System.Drawing.Point(451, 3);
            this.rdoAnalysis.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoAnalysis.Name = "rdoAnalysis";
            this.rdoAnalysis.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.rdoAnalysis.Size = new System.Drawing.Size(220, 28);
            this.rdoAnalysis.TabIndex = 4;
            this.rdoAnalysis.Text = "分析模式";
            this.rdoAnalysis.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.rdoAnalysis.CheckedChanged += new System.EventHandler(this.rdoModeExchange_CheckedChanged);
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.uiGroupBox1, 0, 2);
            this.tlpRight.Controls.Add(this.smShow, 0, 0);
            this.tlpRight.Controls.Add(this.tlpStatic, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(679, 4);
            this.tlpRight.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 3;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpRight.Size = new System.Drawing.Size(337, 492);
            this.tlpRight.TabIndex = 51;
            // 
            // tlpInfoAll
            // 
            this.tlpInfoAll.ColumnCount = 7;
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfoAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpInfoAll.Controls.Add(this.tlpInfoUp, 1, 0);
            this.tlpInfoAll.Controls.Add(this.uiLabel12, 1, 1);
            this.tlpInfoAll.Controls.Add(this.uiLabel13, 3, 1);
            this.tlpInfoAll.Controls.Add(this.uiLabel14, 5, 1);
            this.tlpInfoAll.Controls.Add(this.btnMachineLog, 1, 2);
            this.tlpInfoAll.Controls.Add(this.uiButton2, 4, 2);
            this.tlpInfoAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfoAll.Location = new System.Drawing.Point(3, 32);
            this.tlpInfoAll.Name = "tlpInfoAll";
            this.tlpInfoAll.RowCount = 3;
            this.tlpInfoAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpInfoAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpInfoAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpInfoAll.Size = new System.Drawing.Size(323, 119);
            this.tlpInfoAll.Style = UIStyle.Custom;
            this.tlpInfoAll.TabIndex = 1;
            this.tlpInfoAll.TagString = null;
            // 
            // tlpInfoUp
            // 
            this.tlpInfoUp.ColumnCount = 2;
            this.tlpInfoAll.SetColumnSpan(this.tlpInfoUp, 6);
            this.tlpInfoUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpInfoUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfoUp.Controls.Add(this.uiLabel1, 0, 0);
            this.tlpInfoUp.Controls.Add(this.uiLabel2, 0, 1);
            this.tlpInfoUp.Controls.Add(this.uiLabel3, 0, 2);
            this.tlpInfoUp.Controls.Add(this.uiLabel8, 0, 3);
            this.tlpInfoUp.Controls.Add(this.lbVersion, 1, 1);
            this.tlpInfoUp.Controls.Add(this.lbTaskVer, 1, 2);
            this.tlpInfoUp.Controls.Add(this.uiLabel11, 1, 3);
            this.tlpInfoUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfoUp.Location = new System.Drawing.Point(9, 3);
            this.tlpInfoUp.Name = "tlpInfoUp";
            this.tlpInfoUp.RowCount = 4;
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpInfoUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tlpInfoUp.Size = new System.Drawing.Size(311, 77);
            this.tlpInfoUp.Style = UIStyle.Custom;
            this.tlpInfoUp.TabIndex = 0;
            this.tlpInfoUp.TagString = null;
            // 
            // uiLabel1
            // 
            this.tlpInfoUp.SetColumnSpan(this.uiLabel1, 2);
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(305, 21);
            this.uiLabel1.Style = UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "BTN01 #1";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 21);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(124, 18);
            this.uiLabel2.Style = UIStyle.Custom;
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "MainVersion:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(3, 39);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(124, 18);
            this.uiLabel3.Style = UIStyle.Custom;
            this.uiLabel3.TabIndex = 1;
            this.uiLabel3.Text = "ProjectVersion:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(3, 57);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(124, 20);
            this.uiLabel8.Style = UIStyle.Custom;
            this.uiLabel8.TabIndex = 1;
            this.uiLabel8.Text = "ConfigPath:";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbVersion
            // 
            this.lbVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbVersion.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbVersion.Location = new System.Drawing.Point(133, 21);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(175, 18);
            this.lbVersion.Style = UIStyle.Custom;
            this.lbVersion.TabIndex = 2;
            this.lbVersion.Text = "3.3.23.0101";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbVersion.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbTaskVer
            // 
            this.lbTaskVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTaskVer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTaskVer.Location = new System.Drawing.Point(133, 39);
            this.lbTaskVer.Name = "lbTaskVer";
            this.lbTaskVer.Size = new System.Drawing.Size(175, 18);
            this.lbTaskVer.Style = UIStyle.Custom;
            this.lbTaskVer.TabIndex = 2;
            this.lbTaskVer.Text = "V1.0";
            this.lbTaskVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTaskVer.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel11
            // 
            this.uiLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(133, 57);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(175, 20);
            this.uiLabel11.Style = UIStyle.Custom;
            this.uiLabel11.TabIndex = 2;
            this.uiLabel11.Text = "D:\\Config";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel11.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel12
            // 
            this.tlpInfoAll.SetColumnSpan(this.uiLabel12, 2);
            this.uiLabel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel12.Location = new System.Drawing.Point(9, 83);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(98, 17);
            this.uiLabel12.Style = UIStyle.Custom;
            this.uiLabel12.TabIndex = 1;
            this.uiLabel12.Text = "HIVE Disconnected";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel12.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel13
            // 
            this.tlpInfoAll.SetColumnSpan(this.uiLabel13, 2);
            this.uiLabel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel13.Location = new System.Drawing.Point(113, 83);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(98, 17);
            this.uiLabel13.Style = UIStyle.Custom;
            this.uiLabel13.TabIndex = 1;
            this.uiLabel13.Text = "MES Disconnected";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel13.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel14
            // 
            this.tlpInfoAll.SetColumnSpan(this.uiLabel14, 2);
            this.uiLabel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel14.Location = new System.Drawing.Point(217, 83);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(103, 17);
            this.uiLabel14.Style = UIStyle.Custom;
            this.uiLabel14.TabIndex = 1;
            this.uiLabel14.Text = "PDCA Disconnected";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel14.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnMachineLog
            // 
            this.tlpInfoAll.SetColumnSpan(this.btnMachineLog, 3);
            this.btnMachineLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMachineLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMachineLog.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMachineLog.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMachineLog.Location = new System.Drawing.Point(26, 102);
            this.btnMachineLog.Margin = new System.Windows.Forms.Padding(20, 2, 30, 2);
            this.btnMachineLog.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMachineLog.Name = "btnMachineLog";
            this.btnMachineLog.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMachineLog.Size = new System.Drawing.Size(106, 15);
            this.btnMachineLog.Style = UIStyle.Custom;
            this.btnMachineLog.TabIndex = 2;
            this.btnMachineLog.Text = "Machine Log";
            this.btnMachineLog.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMachineLog.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnMachineLog.Click += new System.EventHandler(this.btnMachineLog_Click);
            // 
            // uiButton2
            // 
            this.tlpInfoAll.SetColumnSpan(this.uiButton2, 3);
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(182, 102);
            this.uiButton2.Margin = new System.Windows.Forms.Padding(20, 2, 30, 2);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(111, 15);
            this.uiButton2.Style = UIStyle.Custom;
            this.uiButton2.TabIndex = 2;
            this.uiButton2.Text = "HIVE Log";
            this.uiButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpStatic
            // 
            this.tlpStatic.ColumnCount = 3;
            this.tlpStatic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatic.Controls.Add(this.lblCT, 2, 6);
            this.tlpStatic.Controls.Add(this.uiLabel5, 0, 2);
            this.tlpStatic.Controls.Add(this.uiLabel10, 0, 6);
            this.tlpStatic.Controls.Add(this.lblUPH, 2, 5);
            this.tlpStatic.Controls.Add(this.uiLabel4, 0, 1);
            this.tlpStatic.Controls.Add(this.uiLabel9, 0, 5);
            this.tlpStatic.Controls.Add(this.uiLabel7, 0, 4);
            this.tlpStatic.Controls.Add(this.lblPass, 2, 4);
            this.tlpStatic.Controls.Add(this.lblInput, 2, 2);
            this.tlpStatic.Controls.Add(this.uiLabel6, 0, 3);
            this.tlpStatic.Controls.Add(this.lblYield, 2, 3);
            this.tlpStatic.Controls.Add(this.lblResult, 0, 0);
            this.tlpStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatic.Location = new System.Drawing.Point(3, 167);
            this.tlpStatic.Name = "tlpStatic";
            this.tlpStatic.RowCount = 7;
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpStatic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpStatic.Size = new System.Drawing.Size(331, 158);
            this.tlpStatic.TabIndex = 52;
            this.tlpStatic.TagString = null;
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.BackColor = System.Drawing.Color.Transparent;
            this.lblCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCT.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCT.Location = new System.Drawing.Point(178, 134);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(150, 24);
            this.lblCT.TabIndex = 0;
            this.lblCT.Text = "12";
            this.lblCT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCT.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(3, 62);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(149, 18);
            this.uiLabel5.TabIndex = 0;
            this.uiLabel5.Text = "Input:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel10
            // 
            this.uiLabel10.AutoSize = true;
            this.uiLabel10.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(3, 134);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(149, 24);
            this.uiLabel10.TabIndex = 0;
            this.uiLabel10.Text = "CT:";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblUPH
            // 
            this.lblUPH.AutoSize = true;
            this.lblUPH.BackColor = System.Drawing.Color.Transparent;
            this.lblUPH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUPH.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUPH.Location = new System.Drawing.Point(178, 116);
            this.lblUPH.Name = "lblUPH";
            this.lblUPH.Size = new System.Drawing.Size(150, 18);
            this.lblUPH.TabIndex = 0;
            this.lblUPH.Text = "234";
            this.lblUPH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUPH.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.tlpStatic.SetColumnSpan(this.uiLabel4, 3);
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(3, 44);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(325, 18);
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "I/O Summary";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel9
            // 
            this.uiLabel9.AutoSize = true;
            this.uiLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(3, 116);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(149, 18);
            this.uiLabel9.TabIndex = 0;
            this.uiLabel9.Text = "UPH:";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.AutoSize = true;
            this.uiLabel7.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(3, 98);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(149, 18);
            this.uiLabel7.TabIndex = 0;
            this.uiLabel7.Text = "Pass/Fail:";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPass.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPass.Location = new System.Drawing.Point(178, 98);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(150, 18);
            this.lblPass.TabIndex = 0;
            this.lblPass.Text = "1230/4";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPass.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.BackColor = System.Drawing.Color.Transparent;
            this.lblInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInput.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInput.Location = new System.Drawing.Point(178, 62);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(150, 18);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "1234";
            this.lblInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInput.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.AutoSize = true;
            this.uiLabel6.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(3, 80);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(149, 18);
            this.uiLabel6.TabIndex = 0;
            this.uiLabel6.Text = "Yield:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblYield
            // 
            this.lblYield.AutoSize = true;
            this.lblYield.BackColor = System.Drawing.Color.Transparent;
            this.lblYield.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYield.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblYield.Location = new System.Drawing.Point(178, 80);
            this.lblYield.Name = "lblYield";
            this.lblYield.Size = new System.Drawing.Size(150, 18);
            this.lblYield.TabIndex = 0;
            this.lblYield.Text = "99.54%";
            this.lblYield.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblYield.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.Gray;
            this.tlpStatic.SetColumnSpan(this.lblResult, 3);
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.Location = new System.Drawing.Point(30, 5);
            this.lblResult.Margin = new System.Windows.Forms.Padding(30, 5, 30, 5);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(271, 34);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "ASDFJKLASDFJKLASDFJK";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.tlpInfoAll);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 333);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(3, 32, 3, 3);
            this.uiGroupBox1.Radius = 20;
            this.uiGroupBox1.RectColor = System.Drawing.Color.DimGray;
            this.uiGroupBox1.RectSize = 2;
            this.uiGroupBox1.Size = new System.Drawing.Size(329, 154);
            this.uiGroupBox1.Style = UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // smShow
            // 
            this.smShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.smShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smShow.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.smShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.smShow.Location = new System.Drawing.Point(5, 5);
            this.smShow.Margin = new System.Windows.Forms.Padding(5);
            this.smShow.MinimumSize = new System.Drawing.Size(1, 1);
            this.smShow.Name = "smShow";
            this.smShow.Size = new System.Drawing.Size(327, 154);
            this.smShow.TabIndex = 51;
            this.smShow.Text = null;
            this.smShow.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.smShow.Visible = false;
            this.smShow.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.Size = new System.Drawing.Size(1020, 500);
            this.Load += new System.EventHandler(this.ShowOutputControl_Load);
            this.cmsDgvResult.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.splData.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splData)).EndInit();
            this.splData.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tlpInfoAll.ResumeLayout(false);
            this.tlpInfoUp.ResumeLayout(false);
            this.tlpStatic.ResumeLayout(false);
            this.tlpStatic.PerformLayout();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ContextMenuStrip cmsDgvResult;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private OperateInstruction smShow;
        private UISplitContainer splData;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private UILabel uiLabel4;
        private UILabel uiLabel6;
        private UILabel uiLabel5;
        private UILabel lblCT;
        private UILabel lblUPH;
        private UILabel uiLabel10;
        private UILabel uiLabel9;
        private UILabel lblPass;
        private UILabel lblYield;
        private UILabel uiLabel7;
        private UILabel lblInput;
        private UITableLayoutPanel tlpTitle;
        private UITableLayoutPanel tlpStatic;
        private UILabel lblResult;
        private Sunny.UI.UIRadioButton rdoList;
        private Sunny.UI.UIRadioButton rdoChart;
        private Sunny.UI.UIRadioButton rdoAnalysis;
        private UITableLayoutPanel tlpInfoUp;
        private UILabel uiLabel1;
        private UILabel uiLabel2;
        private UILabel uiLabel3;
        private UILabel uiLabel8;
        private UILabel lbVersion;
        private UILabel lbTaskVer;
        private UILabel uiLabel11;
        private UITableLayoutPanel tlpInfoAll;
        private UILabel uiLabel12;
        private UILabel uiLabel13;
        private UILabel uiLabel14;
        private UIButton btnMachineLog;
        private UIButton uiButton2;
        private UIGroupBox uiGroupBox1;
    }
}
