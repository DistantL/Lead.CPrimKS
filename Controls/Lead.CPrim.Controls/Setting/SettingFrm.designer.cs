using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.Controls
{
    partial class SettingFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblHardware = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblGeneral = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnLoad = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.pnlGeneral = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.tlpGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.cbproductionType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.lblproductionType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cbStation = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.cbSite = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.lblSite = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblLine = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cbLanguage = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.cbLine = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.lblLanguage = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cbMachine = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.lblStation = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lblMachine = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.pnlHardWare = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.tvHardwareSetting = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITreeView();
            this.imgParam = new System.Windows.Forms.ImageList(this.components);
            this.splMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISplitContainer();
            this.tlpControl = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.pnlMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.line = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.tabControl = new Sunny.UI.UITabControl();
            this.tp_General = new System.Windows.Forms.TabPage();
            this.tp_Administration = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvNames = new System.Windows.Forms.DataGridView();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardUIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.functionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processStationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userAccessInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiTableLayoutPanel8 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.btnImportCSV = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnAdminEdit = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnAdminSave = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.tp_Maintenance = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEidt = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnExport = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Enrgz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countdown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new Lead.CPrim.ProxyTools.SunnyUI.Controls.DataGridViewCustomButtonColumn();
            this.Remove = new Lead.CPrim.ProxyTools.SunnyUI.Controls.DataGridViewCustomButtonColumn();
            this.maintenanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddItem = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.tp_HashKey = new System.Windows.Forms.TabPage();
            this.uiTableLayoutPanel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.uiPanel4 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.uiPanel2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.uiTableLayoutPanel7 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.uiPanel3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.uiLabel13 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiTableLayoutPanel2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.btnPlcPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnIdePath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnRobotPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnLaserPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnVisionPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.tbIdePath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.uiLabel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel4 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel5 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel6 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel7 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tbMainPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tbVisionPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tbLaserPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tbRobotPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tbPlcPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnMainPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.uiTableLayoutPanel3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tbFunction = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.uiLabel8 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnLogOut = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnEdit = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnSave = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.uiLabel9 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel10 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel11 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tbUserName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.tbUid = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.uiTableLayoutPanel4 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.HashKeyItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HashValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiTableLayoutPanel5 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.btnUploadMes = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnCancelHash = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnExportHash = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnRefeshHash = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.uiTableLayoutPanel6 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.uiPanel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.uiLabel12 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tb_Test = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uiPanel5 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tlpMain.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.tlpGeneral.SuspendLayout();
            this.pnlHardWare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            this.tlpControl.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tp_General.SuspendLayout();
            this.tp_Administration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNames)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAccessInfoBindingSource)).BeginInit();
            this.uiTableLayoutPanel8.SuspendLayout();
            this.tp_Maintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maintenanceBindingSource)).BeginInit();
            this.tp_HashKey.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiTableLayoutPanel7.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.uiTableLayoutPanel3.SuspendLayout();
            this.uiTableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.uiTableLayoutPanel5.SuspendLayout();
            this.uiTableLayoutPanel6.SuspendLayout();
            this.tb_Test.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblHardware, 1, 2);
            this.tlpMain.Controls.Add(this.lblGeneral, 1, 0);
            this.tlpMain.Controls.Add(this.btnLoad, 1, 4);
            this.tlpMain.Controls.Add(this.pnlGeneral, 1, 1);
            this.tlpMain.Controls.Add(this.pnlHardWare, 1, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(502, 522);
            this.tlpMain.TabIndex = 0;
            // 
            // lblHardware
            // 
            this.lblHardware.AutoSize = true;
            this.lblHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHardware.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHardware.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblHardware.Location = new System.Drawing.Point(13, 273);
            this.lblHardware.Margin = new System.Windows.Forms.Padding(3);
            this.lblHardware.Name = "lblHardware";
            this.lblHardware.Size = new System.Drawing.Size(486, 26);
            this.lblHardware.TabIndex = 0;
            this.lblHardware.Text = "软件配置";
            this.lblHardware.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHardware.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblGeneral
            // 
            this.lblGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGeneral.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGeneral.Location = new System.Drawing.Point(10, 0);
            this.lblGeneral.Margin = new System.Windows.Forms.Padding(0);
            this.lblGeneral.Name = "lblGeneral";
            this.lblGeneral.Size = new System.Drawing.Size(492, 30);
            this.lblGeneral.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblGeneral.TabIndex = 0;
            this.lblGeneral.Text = "基本信息";
            this.lblGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGeneral.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnLoad
            // 
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.FillColor = System.Drawing.Color.White;
            this.btnLoad.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoad.ForeColor = System.Drawing.Color.Black;
            this.btnLoad.Location = new System.Drawing.Point(50, 475);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(40, 3, 40, 3);
            this.btnLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Radius = 1;
            this.btnLoad.RectColor = System.Drawing.Color.Silver;
            this.btnLoad.Size = new System.Drawing.Size(412, 44);
            this.btnLoad.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load Config";
            this.btnLoad.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoad.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tlpGeneral);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlGeneral.Location = new System.Drawing.Point(10, 30);
            this.pnlGeneral.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGeneral.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(5);
            this.pnlGeneral.Radius = 10;
            this.pnlGeneral.Size = new System.Drawing.Size(492, 240);
            this.pnlGeneral.TabIndex = 5;
            this.pnlGeneral.Text = null;
            this.pnlGeneral.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlGeneral.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpGeneral
            // 
            this.tlpGeneral.ColumnCount = 2;
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeneral.Controls.Add(this.cbproductionType, 1, 2);
            this.tlpGeneral.Controls.Add(this.lblproductionType, 0, 2);
            this.tlpGeneral.Controls.Add(this.cbStation, 1, 6);
            this.tlpGeneral.Controls.Add(this.cbSite, 1, 0);
            this.tlpGeneral.Controls.Add(this.lblSite, 0, 0);
            this.tlpGeneral.Controls.Add(this.lblLine, 0, 4);
            this.tlpGeneral.Controls.Add(this.cbLanguage, 1, 10);
            this.tlpGeneral.Controls.Add(this.cbLine, 1, 4);
            this.tlpGeneral.Controls.Add(this.lblLanguage, 0, 10);
            this.tlpGeneral.Controls.Add(this.cbMachine, 1, 8);
            this.tlpGeneral.Controls.Add(this.lblStation, 0, 6);
            this.tlpGeneral.Controls.Add(this.lblMachine, 0, 8);
            this.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeneral.Location = new System.Drawing.Point(5, 5);
            this.tlpGeneral.Margin = new System.Windows.Forms.Padding(0);
            this.tlpGeneral.Name = "tlpGeneral";
            this.tlpGeneral.RowCount = 11;
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpGeneral.Size = new System.Drawing.Size(482, 230);
            this.tlpGeneral.TabIndex = 0;
            // 
            // cbproductionType
            // 
            this.cbproductionType.DataSource = null;
            this.cbproductionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbproductionType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbproductionType.FillColor = System.Drawing.Color.White;
            this.cbproductionType.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbproductionType.FormattingEnabled = true;
            this.cbproductionType.Location = new System.Drawing.Point(106, 43);
            this.cbproductionType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbproductionType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbproductionType.Name = "cbproductionType";
            this.cbproductionType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbproductionType.Size = new System.Drawing.Size(372, 30);
            this.cbproductionType.TabIndex = 2;
            this.cbproductionType.Tag = "2";
            this.cbproductionType.Watermark = "";
            this.cbproductionType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbproductionType.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // lblproductionType
            // 
            this.lblproductionType.AutoSize = true;
            this.lblproductionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblproductionType.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblproductionType.Location = new System.Drawing.Point(3, 41);
            this.lblproductionType.Margin = new System.Windows.Forms.Padding(3);
            this.lblproductionType.Name = "lblproductionType";
            this.lblproductionType.Size = new System.Drawing.Size(96, 34);
            this.lblproductionType.TabIndex = 6;
            this.lblproductionType.Text = "类型：";
            this.lblproductionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblproductionType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbStation
            // 
            this.cbStation.DataSource = null;
            this.cbStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStation.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbStation.FillColor = System.Drawing.Color.White;
            this.cbStation.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbStation.FormattingEnabled = true;
            this.cbStation.Location = new System.Drawing.Point(106, 119);
            this.cbStation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbStation.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbStation.Name = "cbStation";
            this.cbStation.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbStation.Size = new System.Drawing.Size(372, 30);
            this.cbStation.TabIndex = 1;
            this.cbStation.Tag = "4";
            this.cbStation.Watermark = "";
            this.cbStation.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbStation.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // cbSite
            // 
            this.cbSite.DataSource = null;
            this.cbSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSite.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbSite.FillColor = System.Drawing.Color.White;
            this.cbSite.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSite.FormattingEnabled = true;
            this.cbSite.Location = new System.Drawing.Point(106, 5);
            this.cbSite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSite.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbSite.Name = "cbSite";
            this.cbSite.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbSite.Size = new System.Drawing.Size(372, 30);
            this.cbSite.TabIndex = 1;
            this.cbSite.Tag = "1";
            this.cbSite.Watermark = "";
            this.cbSite.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbSite.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSite.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSite.Location = new System.Drawing.Point(3, 3);
            this.lblSite.Margin = new System.Windows.Forms.Padding(3);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(96, 34);
            this.lblSite.TabIndex = 1;
            this.lblSite.Text = "工厂：";
            this.lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSite.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLine.Location = new System.Drawing.Point(3, 79);
            this.lblLine.Margin = new System.Windows.Forms.Padding(3);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(96, 34);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "线体：";
            this.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLine.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbLanguage
            // 
            this.cbLanguage.DataSource = null;
            this.cbLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLanguage.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbLanguage.FillColor = System.Drawing.Color.White;
            this.cbLanguage.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(106, 195);
            this.cbLanguage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLanguage.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbLanguage.Size = new System.Drawing.Size(372, 30);
            this.cbLanguage.TabIndex = 0;
            this.cbLanguage.Tag = "6";
            this.cbLanguage.Watermark = "";
            this.cbLanguage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // cbLine
            // 
            this.cbLine.DataSource = null;
            this.cbLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLine.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbLine.FillColor = System.Drawing.Color.White;
            this.cbLine.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLine.FormattingEnabled = true;
            this.cbLine.Location = new System.Drawing.Point(106, 81);
            this.cbLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLine.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbLine.Name = "cbLine";
            this.cbLine.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbLine.Size = new System.Drawing.Size(372, 30);
            this.cbLine.TabIndex = 0;
            this.cbLine.Tag = "3";
            this.cbLine.Watermark = "";
            this.cbLine.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbLine.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLanguage.Location = new System.Drawing.Point(3, 193);
            this.lblLanguage.Margin = new System.Windows.Forms.Padding(3);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(96, 34);
            this.lblLanguage.TabIndex = 5;
            this.lblLanguage.Text = "语言：";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLanguage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbMachine
            // 
            this.cbMachine.DataSource = null;
            this.cbMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMachine.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbMachine.FillColor = System.Drawing.Color.White;
            this.cbMachine.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbMachine.FormattingEnabled = true;
            this.cbMachine.Location = new System.Drawing.Point(106, 157);
            this.cbMachine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMachine.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbMachine.Name = "cbMachine";
            this.cbMachine.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbMachine.Size = new System.Drawing.Size(372, 30);
            this.cbMachine.TabIndex = 0;
            this.cbMachine.Tag = "5";
            this.cbMachine.Watermark = "";
            this.cbMachine.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbMachine.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStation.Location = new System.Drawing.Point(3, 117);
            this.lblStation.Margin = new System.Windows.Forms.Padding(3);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(96, 34);
            this.lblStation.TabIndex = 3;
            this.lblStation.Text = "工站：";
            this.lblStation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStation.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMachine.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMachine.Location = new System.Drawing.Point(3, 155);
            this.lblMachine.Margin = new System.Windows.Forms.Padding(3);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(96, 34);
            this.lblMachine.TabIndex = 4;
            this.lblMachine.Text = "设备：";
            this.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMachine.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlHardWare
            // 
            this.pnlHardWare.Controls.Add(this.tvHardwareSetting);
            this.pnlHardWare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHardWare.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlHardWare.Location = new System.Drawing.Point(10, 302);
            this.pnlHardWare.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHardWare.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlHardWare.Name = "pnlHardWare";
            this.pnlHardWare.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.pnlHardWare.Radius = 10;
            this.pnlHardWare.Size = new System.Drawing.Size(492, 170);
            this.pnlHardWare.TabIndex = 6;
            this.pnlHardWare.Text = null;
            this.pnlHardWare.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlHardWare.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tvHardwareSetting
            // 
            this.tvHardwareSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHardwareSetting.FillColor = System.Drawing.Color.White;
            this.tvHardwareSetting.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvHardwareSetting.ImageIndex = 0;
            this.tvHardwareSetting.ImageList = this.imgParam;
            this.tvHardwareSetting.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tvHardwareSetting.Location = new System.Drawing.Point(5, 10);
            this.tvHardwareSetting.Margin = new System.Windows.Forms.Padding(0);
            this.tvHardwareSetting.MinimumSize = new System.Drawing.Size(1, 1);
            this.tvHardwareSetting.Name = "tvHardwareSetting";
            this.tvHardwareSetting.Radius = 1;
            this.tvHardwareSetting.SelectedImageIndex = 0;
            this.tvHardwareSetting.ShowText = false;
            this.tvHardwareSetting.Size = new System.Drawing.Size(482, 155);
            this.tvHardwareSetting.TabIndex = 1;
            this.tvHardwareSetting.Text = null;
            this.tvHardwareSetting.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tvHardwareSetting.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tvHardwareSetting.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvHardwareSetting_AfterSelect);
            // 
            // imgParam
            // 
            this.imgParam.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgParam.ImageStream")));
            this.imgParam.TransparentColor = System.Drawing.Color.Transparent;
            this.imgParam.Images.SetKeyName(0, "config.png");
            this.imgParam.Images.SetKeyName(1, "system.png");
            this.imgParam.Images.SetKeyName(2, "station.png");
            this.imgParam.Images.SetKeyName(3, "fai.png");
            this.imgParam.Images.SetKeyName(4, "Authority.png");
            this.imgParam.Images.SetKeyName(5, "Language.png");
            this.imgParam.Images.SetKeyName(6, "");
            this.imgParam.Images.SetKeyName(7, "Trigger.png");
            this.imgParam.Images.SetKeyName(8, "prim.png");
            this.imgParam.Images.SetKeyName(9, "show.png");
            this.imgParam.Images.SetKeyName(10, "task.png");
            this.imgParam.Images.SetKeyName(11, "element.png");
            this.imgParam.Images.SetKeyName(12, "config.png");
            this.imgParam.Images.SetKeyName(13, "debug.png");
            this.imgParam.Images.SetKeyName(14, "param.png");
            this.imgParam.Images.SetKeyName(15, "commonparam.png");
            // 
            // splMain
            // 
            this.splMain.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.splMain.BarColor = System.Drawing.Color.Transparent;
            this.splMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.HandleColor = System.Drawing.Color.LightGray;
            this.splMain.Location = new System.Drawing.Point(0, 0);
            this.splMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.tlpMain);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.tlpControl);
            this.splMain.Size = new System.Drawing.Size(1548, 522);
            this.splMain.SplitPanelState = Lead.CPrim.ProxyTools.SunnyUI.Controls.UISplitContainer.UISplitPanelState.Expanded;
            this.splMain.SplitterDistance = 502;
            this.splMain.SplitterWidth = 11;
            this.splMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.splMain.TabIndex = 1;
            this.splMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpControl
            // 
            this.tlpControl.ColumnCount = 2;
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControl.Controls.Add(this.pnlMain, 1, 0);
            this.tlpControl.Controls.Add(this.line, 0, 0);
            this.tlpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControl.Location = new System.Drawing.Point(0, 0);
            this.tlpControl.Margin = new System.Windows.Forms.Padding(0);
            this.tlpControl.Name = "tlpControl";
            this.tlpControl.RowCount = 1;
            this.tlpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControl.Size = new System.Drawing.Size(1035, 522);
            this.tlpControl.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tlpControl.TabIndex = 1;
            this.tlpControl.TagString = null;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Location = new System.Drawing.Point(25, 15);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(15);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMain.Radius = 0;
            this.pnlMain.Size = new System.Drawing.Size(995, 492);
            this.pnlMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Text = null;
            this.pnlMain.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // line
            // 
            this.line.Direction = Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine.LineDirection.Vertical;
            this.line.Dock = System.Windows.Forms.DockStyle.Fill;
            this.line.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.line.Location = new System.Drawing.Point(3, 3);
            this.line.MinimumSize = new System.Drawing.Size(1, 1);
            this.line.Name = "line";
            this.line.RectSize = 2;
            this.line.Size = new System.Drawing.Size(4, 516);
            this.line.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.line.TabIndex = 1;
            this.line.Text = "uiLine1";
            this.line.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tp_General);
            this.tabControl.Controls.Add(this.tp_Administration);
            this.tabControl.Controls.Add(this.tp_Maintenance);
            this.tabControl.Controls.Add(this.tp_HashKey);
            this.tabControl.Controls.Add(this.tb_Test);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tabControl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.ItemSize = new System.Drawing.Size(150, 40);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.MainPage = "";
            this.tabControl.MenuStyle = Lead.CPrim.ProxyTools.SunnyUI.Style.UIMenuStyle.Custom;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1548, 562);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tabControl.TabBackColor = System.Drawing.Color.Silver;
            this.tabControl.TabIndex = 0;
            this.tabControl.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabControl.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tabControl.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tabControl.TabUnSelectedForeColor = System.Drawing.Color.White;
            this.tabControl.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Select);
            // 
            // tp_General
            // 
            this.tp_General.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tp_General.Controls.Add(this.splMain);
            this.tp_General.Location = new System.Drawing.Point(0, 40);
            this.tp_General.Name = "tp_General";
            this.tp_General.Size = new System.Drawing.Size(1548, 522);
            this.tp_General.TabIndex = 0;
            this.tp_General.Text = "General";
            // 
            // tp_Administration
            // 
            this.tp_Administration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tp_Administration.Controls.Add(this.splitContainer2);
            this.tp_Administration.Location = new System.Drawing.Point(0, 40);
            this.tp_Administration.Name = "tp_Administration";
            this.tp_Administration.Size = new System.Drawing.Size(1548, 522);
            this.tp_Administration.TabIndex = 3;
            this.tp_Administration.Text = "Administration";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvNames);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.uiTableLayoutPanel8);
            this.splitContainer2.Size = new System.Drawing.Size(1548, 522);
            this.splitContainer2.SplitterDistance = 1308;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvNames
            // 
            this.dgvNames.AllowUserToAddRows = false;
            this.dgvNames.AllowUserToDeleteRows = false;
            this.dgvNames.AutoGenerateColumns = false;
            this.dgvNames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNames.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNames.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNames.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Active,
            this.siteDataGridViewTextBoxColumn,
            this.projectDataGridViewTextBoxColumn,
            this.vendorNameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.accessLevelDataGridViewTextBoxColumn,
            this.cardUIDDataGridViewTextBoxColumn,
            this.functionDataGridViewTextBoxColumn,
            this.processStationIDDataGridViewTextBoxColumn});
            this.dgvNames.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvNames.DataSource = this.userAccessInfoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNames.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNames.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvNames.GridColor = System.Drawing.SystemColors.Desktop;
            this.dgvNames.Location = new System.Drawing.Point(0, 0);
            this.dgvNames.MultiSelect = false;
            this.dgvNames.Name = "dgvNames";
            this.dgvNames.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNames.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNames.RowHeadersVisible = false;
            this.dgvNames.RowHeadersWidth = 51;
            this.dgvNames.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvNames.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dgvNames.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvNames.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNames.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.dgvNames.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvNames.RowTemplate.Height = 27;
            this.dgvNames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNames.Size = new System.Drawing.Size(1308, 522);
            this.dgvNames.TabIndex = 1;
            this.dgvNames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dgvNames.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellEndEdit);
            this.dgvNames.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView3_DataBindingComplete);
            // 
            // Active
            // 
            this.Active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Active.HeaderText = "";
            this.Active.MinimumWidth = 6;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 19;
            // 
            // siteDataGridViewTextBoxColumn
            // 
            this.siteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.siteDataGridViewTextBoxColumn.DataPropertyName = "Site";
            this.siteDataGridViewTextBoxColumn.HeaderText = "Site";
            this.siteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.siteDataGridViewTextBoxColumn.Name = "siteDataGridViewTextBoxColumn";
            // 
            // projectDataGridViewTextBoxColumn
            // 
            this.projectDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            this.projectDataGridViewTextBoxColumn.HeaderText = "Project";
            this.projectDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            // 
            // vendorNameDataGridViewTextBoxColumn
            // 
            this.vendorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vendorNameDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Name";
            this.vendorNameDataGridViewTextBoxColumn.HeaderText = "Vendor_Name";
            this.vendorNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.vendorNameDataGridViewTextBoxColumn.Name = "vendorNameDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // accessLevelDataGridViewTextBoxColumn
            // 
            this.accessLevelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accessLevelDataGridViewTextBoxColumn.DataPropertyName = "Access_Level";
            this.accessLevelDataGridViewTextBoxColumn.HeaderText = "Access_Level";
            this.accessLevelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.accessLevelDataGridViewTextBoxColumn.Name = "accessLevelDataGridViewTextBoxColumn";
            // 
            // cardUIDDataGridViewTextBoxColumn
            // 
            this.cardUIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cardUIDDataGridViewTextBoxColumn.DataPropertyName = "Card_UID";
            this.cardUIDDataGridViewTextBoxColumn.HeaderText = "Card_UID";
            this.cardUIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cardUIDDataGridViewTextBoxColumn.Name = "cardUIDDataGridViewTextBoxColumn";
            // 
            // functionDataGridViewTextBoxColumn
            // 
            this.functionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.functionDataGridViewTextBoxColumn.DataPropertyName = "Function";
            this.functionDataGridViewTextBoxColumn.HeaderText = "Function";
            this.functionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.functionDataGridViewTextBoxColumn.Name = "functionDataGridViewTextBoxColumn";
            // 
            // processStationIDDataGridViewTextBoxColumn
            // 
            this.processStationIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.processStationIDDataGridViewTextBoxColumn.DataPropertyName = "Station_ID";
            this.processStationIDDataGridViewTextBoxColumn.HeaderText = "Station_ID";
            this.processStationIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.processStationIDDataGridViewTextBoxColumn.Name = "processStationIDDataGridViewTextBoxColumn";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加用户ToolStripMenuItem,
            this.删除用户ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 添加用户ToolStripMenuItem
            // 
            this.添加用户ToolStripMenuItem.Name = "添加用户ToolStripMenuItem";
            this.添加用户ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加用户ToolStripMenuItem.Text = "添加用户";
            this.添加用户ToolStripMenuItem.Click += new System.EventHandler(this.添加用户ToolStripMenuItem_Click);
            // 
            // 删除用户ToolStripMenuItem
            // 
            this.删除用户ToolStripMenuItem.Name = "删除用户ToolStripMenuItem";
            this.删除用户ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除用户ToolStripMenuItem.Text = "删除用户";
            this.删除用户ToolStripMenuItem.Click += new System.EventHandler(this.删除用户ToolStripMenuItem_Click);
            // 
            // userAccessInfoBindingSource
            // 
            this.userAccessInfoBindingSource.DataSource = typeof(Lead.CPrim.Controls.UserAccessInfo);
            // 
            // uiTableLayoutPanel8
            // 
            this.uiTableLayoutPanel8.ColumnCount = 1;
            this.uiTableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel8.Controls.Add(this.btnImportCSV, 0, 2);
            this.uiTableLayoutPanel8.Controls.Add(this.btnAdminEdit, 0, 3);
            this.uiTableLayoutPanel8.Controls.Add(this.btnAdminSave, 0, 4);
            this.uiTableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel8.Name = "uiTableLayoutPanel8";
            this.uiTableLayoutPanel8.RowCount = 6;
            this.uiTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel8.Size = new System.Drawing.Size(236, 522);
            this.uiTableLayoutPanel8.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiTableLayoutPanel8.TabIndex = 0;
            this.uiTableLayoutPanel8.TagString = null;
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportCSV.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImportCSV.Location = new System.Drawing.Point(3, 316);
            this.btnImportCSV.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(230, 46);
            this.btnImportCSV.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnImportCSV.TabIndex = 0;
            this.btnImportCSV.Text = "ImportCSV";
            this.btnImportCSV.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImportCSV.Visible = false;
            this.btnImportCSV.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // btnAdminEdit
            // 
            this.btnAdminEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdminEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdminEdit.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdminEdit.Location = new System.Drawing.Point(3, 368);
            this.btnAdminEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdminEdit.Name = "btnAdminEdit";
            this.btnAdminEdit.Size = new System.Drawing.Size(230, 46);
            this.btnAdminEdit.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnAdminEdit.TabIndex = 1;
            this.btnAdminEdit.Text = "Edit";
            this.btnAdminEdit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdminEdit.Visible = false;
            this.btnAdminEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdminEdit.Click += new System.EventHandler(this.btnAdminEdit_Click);
            // 
            // btnAdminSave
            // 
            this.btnAdminSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdminSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdminSave.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdminSave.Location = new System.Drawing.Point(3, 420);
            this.btnAdminSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdminSave.Name = "btnAdminSave";
            this.btnAdminSave.Size = new System.Drawing.Size(230, 46);
            this.btnAdminSave.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnAdminSave.TabIndex = 2;
            this.btnAdminSave.Text = "Save";
            this.btnAdminSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdminSave.Visible = false;
            this.btnAdminSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdminSave.Click += new System.EventHandler(this.btnAdminSave_Click);
            // 
            // tp_Maintenance
            // 
            this.tp_Maintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tp_Maintenance.Controls.Add(this.splitContainer1);
            this.tp_Maintenance.Location = new System.Drawing.Point(0, 40);
            this.tp_Maintenance.Name = "tp_Maintenance";
            this.tp_Maintenance.Size = new System.Drawing.Size(200, 60);
            this.tp_Maintenance.TabIndex = 1;
            this.tp_Maintenance.Text = "Maintenance";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(200, 60);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnEidt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(21, 56);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnEidt
            // 
            this.btnEidt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEidt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEidt.FillColor = System.Drawing.Color.Gray;
            this.btnEidt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEidt.Location = new System.Drawing.Point(3, 23);
            this.btnEidt.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEidt.Name = "btnEidt";
            this.btnEidt.Radius = 8;
            this.btnEidt.RectColor = System.Drawing.Color.Transparent;
            this.btnEidt.Size = new System.Drawing.Size(15, 34);
            this.btnEidt.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnEidt.TabIndex = 0;
            this.btnEidt.Text = "Edit";
            this.btnEidt.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEidt.Visible = false;
            this.btnEidt.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEidt.Click += new System.EventHandler(this.btnEidt_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FillColor = System.Drawing.Color.Gray;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(3, 73);
            this.btnExport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Radius = 8;
            this.btnExport.RectColor = System.Drawing.Color.Transparent;
            this.btnExport.Size = new System.Drawing.Size(15, 34);
            this.btnExport.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(3, 123);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 8;
            this.btnCancel.RectColor = System.Drawing.Color.Transparent;
            this.btnCancel.Size = new System.Drawing.Size(15, 34);
            this.btnCancel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.7869F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.213097F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddItem, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.231708F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.7683F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(167, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeight = 70;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enrgz,
            this.project,
            this.lineType,
            this.headID,
            this.item,
            this.period,
            this.countdown,
            this.threshold,
            this.record,
            this.time,
            this.status,
            this.Add,
            this.Remove});
            this.dataGridView1.DataSource = this.maintenanceBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Desktop;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.tableLayoutPanel2.SetRowSpan(this.dataGridView1, 2);
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(147, 50);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // Enrgz
            // 
            this.Enrgz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Enrgz.FillWeight = 2.126293F;
            this.Enrgz.HeaderText = "激活 enrgz";
            this.Enrgz.MinimumWidth = 50;
            this.Enrgz.Name = "Enrgz";
            this.Enrgz.ReadOnly = true;
            this.Enrgz.Width = 50;
            // 
            // project
            // 
            this.project.DataPropertyName = "Project";
            this.project.FillWeight = 8F;
            this.project.HeaderText = "项目代码 Project";
            this.project.MinimumWidth = 80;
            this.project.Name = "project";
            this.project.Width = 80;
            // 
            // lineType
            // 
            this.lineType.DataPropertyName = "LineType";
            this.lineType.FillWeight = 8F;
            this.lineType.HeaderText = "线别   Line type";
            this.lineType.MinimumWidth = 80;
            this.lineType.Name = "lineType";
            this.lineType.Width = 80;
            // 
            // headID
            // 
            this.headID.DataPropertyName = "HeadID";
            this.headID.FillWeight = 7F;
            this.headID.HeaderText = "治具编号 Head ID";
            this.headID.MinimumWidth = 70;
            this.headID.Name = "headID";
            this.headID.Width = 70;
            // 
            // item
            // 
            this.item.DataPropertyName = "Item";
            this.item.FillWeight = 10F;
            this.item.HeaderText = "保养项目 Maint. Item";
            this.item.MinimumWidth = 100;
            this.item.Name = "item";
            this.item.Width = 125;
            // 
            // period
            // 
            this.period.DataPropertyName = "Period";
            this.period.FillWeight = 10F;
            this.period.HeaderText = "保养周期 Maint. Period";
            this.period.MinimumWidth = 100;
            this.period.Name = "period";
            this.period.Width = 125;
            // 
            // countdown
            // 
            this.countdown.DataPropertyName = "Countdown";
            this.countdown.FillWeight = 10F;
            this.countdown.HeaderText = "倒计时 Maint. Countdown";
            this.countdown.MinimumWidth = 100;
            this.countdown.Name = "countdown";
            this.countdown.ReadOnly = true;
            this.countdown.Width = 125;
            // 
            // threshold
            // 
            this.threshold.DataPropertyName = "Threshold";
            this.threshold.FillWeight = 16F;
            this.threshold.HeaderText = "预警阀值  Alarm-triggering Threshold";
            this.threshold.MinimumWidth = 160;
            this.threshold.Name = "threshold";
            this.threshold.Width = 160;
            // 
            // record
            // 
            this.record.DataPropertyName = "Record";
            this.record.FillWeight = 15F;
            this.record.HeaderText = "最近的维护记录 Latest maintenance record";
            this.record.MinimumWidth = 150;
            this.record.Name = "record";
            this.record.ReadOnly = true;
            this.record.Width = 150;
            // 
            // time
            // 
            this.time.DataPropertyName = "Time";
            this.time.FillWeight = 15F;
            this.time.HeaderText = "计划保养时间 Scheduled Maint. Time";
            this.time.MinimumWidth = 150;
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 150;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.FillWeight = 10F;
            this.status.HeaderText = "健康状态 Health Status";
            this.status.MinimumWidth = 100;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 125;
            // 
            // Add
            // 
            this.Add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add.DefaultCellStyle = dataGridViewCellStyle5;
            this.Add.FillWeight = 5F;
            this.Add.HeaderText = "";
            this.Add.MinimumWidth = 6;
            this.Add.Name = "Add";
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Add.Text = "Maint./Add";
            this.Add.UseColumnTextForButtonValue = true;
            this.Add.Width = 19;
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Remove.FillWeight = 5F;
            this.Remove.HeaderText = "";
            this.Remove.MinimumWidth = 6;
            this.Remove.Name = "Remove";
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Remove.Text = "Remove";
            this.Remove.UseColumnTextForButtonValue = true;
            this.Remove.Width = 19;
            // 
            // maintenanceBindingSource
            // 
            this.maintenanceBindingSource.DataSource = typeof(Lead.CPrim.Controls.Maintenance);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddItem.FillColor = System.Drawing.Color.Gray;
            this.btnAddItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddItem.Location = new System.Drawing.Point(156, 3);
            this.btnAddItem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Radius = 8;
            this.btnAddItem.RectColor = System.Drawing.Color.Transparent;
            this.btnAddItem.Size = new System.Drawing.Size(8, 1);
            this.btnAddItem.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddItem.Visible = false;
            this.btnAddItem.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // tp_HashKey
            // 
            this.tp_HashKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tp_HashKey.Controls.Add(this.uiTableLayoutPanel1);
            this.tp_HashKey.Location = new System.Drawing.Point(0, 40);
            this.tp_HashKey.Name = "tp_HashKey";
            this.tp_HashKey.Size = new System.Drawing.Size(200, 60);
            this.tp_HashKey.TabIndex = 2;
            this.tp_HashKey.Text = "Hash Key";
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 3;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiPanel4, 2, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiPanel2, 1, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel7, 2, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel2, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel3, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel4, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel6, 1, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiTableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 3;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(200, 60);
            this.uiTableLayoutPanel1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiPanel4
            // 
            this.uiPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel4.Location = new System.Drawing.Point(138, 40);
            this.uiPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel4.Name = "uiPanel4";
            this.uiPanel4.Size = new System.Drawing.Size(58, 15);
            this.uiPanel4.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiPanel4.TabIndex = 12;
            this.uiPanel4.Text = null;
            this.uiPanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiPanel2
            // 
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(72, 40);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(58, 15);
            this.uiPanel2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiPanel2.TabIndex = 11;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTableLayoutPanel7
            // 
            this.uiTableLayoutPanel7.ColumnCount = 1;
            this.uiTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel7.Controls.Add(this.uiPanel3, 0, 1);
            this.uiTableLayoutPanel7.Controls.Add(this.uiLabel13, 0, 0);
            this.uiTableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel7.Location = new System.Drawing.Point(137, 3);
            this.uiTableLayoutPanel7.Name = "uiTableLayoutPanel7";
            this.uiTableLayoutPanel7.RowCount = 2;
            this.uiTableLayoutPanel1.SetRowSpan(this.uiTableLayoutPanel7, 2);
            this.uiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.995862F));
            this.uiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.00414F));
            this.uiTableLayoutPanel7.Size = new System.Drawing.Size(60, 29);
            this.uiTableLayoutPanel7.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiTableLayoutPanel7.TabIndex = 10;
            this.uiTableLayoutPanel7.TagString = null;
            // 
            // uiPanel3
            // 
            this.uiPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel3.Location = new System.Drawing.Point(4, 7);
            this.uiPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(52, 17);
            this.uiPanel3.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiPanel3.TabIndex = 1;
            this.uiPanel3.Text = null;
            this.uiPanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel13
            // 
            this.uiLabel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel13.Location = new System.Drawing.Point(3, 0);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(54, 2);
            this.uiLabel13.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel13.TabIndex = 2;
            this.uiLabel13.Text = "Vision Template Parts";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel13.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 3;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.63473F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.20359F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.86228F));
            this.uiTableLayoutPanel2.Controls.Add(this.btnPlcPath, 2, 6);
            this.uiTableLayoutPanel2.Controls.Add(this.btnIdePath, 2, 5);
            this.uiTableLayoutPanel2.Controls.Add(this.btnRobotPath, 2, 4);
            this.uiTableLayoutPanel2.Controls.Add(this.btnLaserPath, 2, 3);
            this.uiTableLayoutPanel2.Controls.Add(this.btnVisionPath, 2, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.tbIdePath, 1, 5);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLabel1, 0, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLabel2, 0, 1);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLabel3, 0, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLabel4, 0, 3);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLabel5, 0, 4);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLabel6, 0, 5);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLabel7, 0, 6);
            this.uiTableLayoutPanel2.Controls.Add(this.tbMainPath, 1, 1);
            this.uiTableLayoutPanel2.Controls.Add(this.tbVisionPath, 1, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.tbLaserPath, 1, 3);
            this.uiTableLayoutPanel2.Controls.Add(this.tbRobotPath, 1, 4);
            this.uiTableLayoutPanel2.Controls.Add(this.tbPlcPath, 1, 6);
            this.uiTableLayoutPanel2.Controls.Add(this.btnMainPath, 2, 1);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 7;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(62, 10);
            this.uiTableLayoutPanel2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiTableLayoutPanel2.TabIndex = 0;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // btnPlcPath
            // 
            this.btnPlcPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlcPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlcPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnPlcPath.Location = new System.Drawing.Point(52, 9);
            this.btnPlcPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPlcPath.Name = "btnPlcPath";
            this.btnPlcPath.Size = new System.Drawing.Size(7, 1);
            this.btnPlcPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnPlcPath.TabIndex = 18;
            this.btnPlcPath.Text = "Setting";
            this.btnPlcPath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlcPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnPlcPath.Click += new System.EventHandler(this.btnHashPath_Click);
            // 
            // btnIdePath
            // 
            this.btnIdePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIdePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIdePath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnIdePath.Location = new System.Drawing.Point(52, 8);
            this.btnIdePath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnIdePath.Name = "btnIdePath";
            this.btnIdePath.Size = new System.Drawing.Size(7, 1);
            this.btnIdePath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnIdePath.TabIndex = 17;
            this.btnIdePath.Text = "Setting";
            this.btnIdePath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIdePath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnIdePath.Click += new System.EventHandler(this.btnHashPath_Click);
            // 
            // btnRobotPath
            // 
            this.btnRobotPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRobotPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRobotPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnRobotPath.Location = new System.Drawing.Point(52, 7);
            this.btnRobotPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRobotPath.Name = "btnRobotPath";
            this.btnRobotPath.Size = new System.Drawing.Size(7, 1);
            this.btnRobotPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnRobotPath.TabIndex = 16;
            this.btnRobotPath.Text = "Setting";
            this.btnRobotPath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRobotPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRobotPath.Click += new System.EventHandler(this.btnHashPath_Click);
            // 
            // btnLaserPath
            // 
            this.btnLaserPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaserPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLaserPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnLaserPath.Location = new System.Drawing.Point(52, 6);
            this.btnLaserPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLaserPath.Name = "btnLaserPath";
            this.btnLaserPath.Size = new System.Drawing.Size(7, 1);
            this.btnLaserPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnLaserPath.TabIndex = 15;
            this.btnLaserPath.Text = "Setting";
            this.btnLaserPath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLaserPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnLaserPath.Click += new System.EventHandler(this.btnHashPath_Click);
            // 
            // btnVisionPath
            // 
            this.btnVisionPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisionPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVisionPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnVisionPath.Location = new System.Drawing.Point(52, 5);
            this.btnVisionPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnVisionPath.Name = "btnVisionPath";
            this.btnVisionPath.Size = new System.Drawing.Size(7, 1);
            this.btnVisionPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnVisionPath.TabIndex = 14;
            this.btnVisionPath.Text = "Setting";
            this.btnVisionPath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVisionPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnVisionPath.Click += new System.EventHandler(this.btnHashPath_Click);
            // 
            // tbIdePath
            // 
            this.tbIdePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbIdePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIdePath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbIdePath.Location = new System.Drawing.Point(24, 10);
            this.tbIdePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIdePath.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbIdePath.Name = "tbIdePath";
            this.tbIdePath.ReadOnly = true;
            this.tbIdePath.ShowText = false;
            this.tbIdePath.Size = new System.Drawing.Size(21, 20);
            this.tbIdePath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbIdePath.TabIndex = 11;
            this.tbIdePath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbIdePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHashPath_KeyPress);
            // 
            // uiLabel1
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiLabel1, 3);
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(56, 1);
            this.uiLabel1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Software Parts";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 1);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(14, 1);
            this.uiLabel2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "Main SW Path:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.Location = new System.Drawing.Point(3, 2);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(14, 1);
            this.uiLabel3.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "Vision SW Path:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel4.Location = new System.Drawing.Point(3, 3);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(14, 1);
            this.uiLabel4.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel4.TabIndex = 3;
            this.uiLabel4.Text = "Laser Program Path:";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel5.Location = new System.Drawing.Point(3, 4);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(14, 1);
            this.uiLabel5.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel5.TabIndex = 4;
            this.uiLabel5.Text = "Robot Program Path:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel6.Location = new System.Drawing.Point(3, 5);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(14, 1);
            this.uiLabel6.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel6.TabIndex = 5;
            this.uiLabel6.Text = "IDE Path:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel7.Location = new System.Drawing.Point(3, 6);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(14, 4);
            this.uiLabel7.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel7.TabIndex = 6;
            this.uiLabel7.Text = "PLC Program Path:";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tbMainPath
            // 
            this.tbMainPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMainPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMainPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbMainPath.Location = new System.Drawing.Point(24, 6);
            this.tbMainPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMainPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbMainPath.Name = "tbMainPath";
            this.tbMainPath.ReadOnly = true;
            this.tbMainPath.ShowText = false;
            this.tbMainPath.Size = new System.Drawing.Size(21, 20);
            this.tbMainPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbMainPath.TabIndex = 7;
            this.tbMainPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbMainPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHashPath_KeyPress);
            // 
            // tbVisionPath
            // 
            this.tbVisionPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbVisionPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVisionPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbVisionPath.Location = new System.Drawing.Point(24, 7);
            this.tbVisionPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVisionPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbVisionPath.Name = "tbVisionPath";
            this.tbVisionPath.ReadOnly = true;
            this.tbVisionPath.ShowText = false;
            this.tbVisionPath.Size = new System.Drawing.Size(21, 20);
            this.tbVisionPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbVisionPath.TabIndex = 8;
            this.tbVisionPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbVisionPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHashPath_KeyPress);
            // 
            // tbLaserPath
            // 
            this.tbLaserPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbLaserPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLaserPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbLaserPath.Location = new System.Drawing.Point(24, 8);
            this.tbLaserPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLaserPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbLaserPath.Name = "tbLaserPath";
            this.tbLaserPath.ReadOnly = true;
            this.tbLaserPath.ShowText = false;
            this.tbLaserPath.Size = new System.Drawing.Size(21, 20);
            this.tbLaserPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbLaserPath.TabIndex = 9;
            this.tbLaserPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbLaserPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHashPath_KeyPress);
            // 
            // tbRobotPath
            // 
            this.tbRobotPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbRobotPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRobotPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbRobotPath.Location = new System.Drawing.Point(24, 9);
            this.tbRobotPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRobotPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbRobotPath.Name = "tbRobotPath";
            this.tbRobotPath.ReadOnly = true;
            this.tbRobotPath.ShowText = false;
            this.tbRobotPath.Size = new System.Drawing.Size(21, 20);
            this.tbRobotPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbRobotPath.TabIndex = 10;
            this.tbRobotPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbRobotPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHashPath_KeyPress);
            // 
            // tbPlcPath
            // 
            this.tbPlcPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPlcPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPlcPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbPlcPath.Location = new System.Drawing.Point(24, 11);
            this.tbPlcPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPlcPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbPlcPath.Name = "tbPlcPath";
            this.tbPlcPath.ReadOnly = true;
            this.tbPlcPath.ShowText = false;
            this.tbPlcPath.Size = new System.Drawing.Size(21, 20);
            this.tbPlcPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbPlcPath.TabIndex = 12;
            this.tbPlcPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tbPlcPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHashPath_KeyPress);
            // 
            // btnMainPath
            // 
            this.btnMainPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMainPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainPath.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnMainPath.Location = new System.Drawing.Point(52, 4);
            this.btnMainPath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnMainPath.Name = "btnMainPath";
            this.btnMainPath.Size = new System.Drawing.Size(7, 1);
            this.btnMainPath.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnMainPath.TabIndex = 13;
            this.btnMainPath.Text = "Setting";
            this.btnMainPath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMainPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnMainPath.Click += new System.EventHandler(this.btnHashPath_Click);
            // 
            // uiTableLayoutPanel3
            // 
            this.uiTableLayoutPanel3.ColumnCount = 4;
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.44311F));
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.06587F));
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.34132F));
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.1497F));
            this.uiTableLayoutPanel3.Controls.Add(this.tbFunction, 1, 3);
            this.uiTableLayoutPanel3.Controls.Add(this.uiLabel8, 0, 0);
            this.uiTableLayoutPanel3.Controls.Add(this.btnLogOut, 3, 0);
            this.uiTableLayoutPanel3.Controls.Add(this.btnEdit, 0, 4);
            this.uiTableLayoutPanel3.Controls.Add(this.btnSave, 3, 4);
            this.uiTableLayoutPanel3.Controls.Add(this.uiLabel9, 0, 1);
            this.uiTableLayoutPanel3.Controls.Add(this.uiLabel10, 0, 2);
            this.uiTableLayoutPanel3.Controls.Add(this.uiLabel11, 0, 3);
            this.uiTableLayoutPanel3.Controls.Add(this.tbUserName, 1, 1);
            this.uiTableLayoutPanel3.Controls.Add(this.tbUid, 1, 2);
            this.uiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            this.uiTableLayoutPanel3.RowCount = 5;
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel3.Size = new System.Drawing.Size(62, 13);
            this.uiTableLayoutPanel3.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiTableLayoutPanel3.TabIndex = 7;
            this.uiTableLayoutPanel3.TagString = null;
            // 
            // tbFunction
            // 
            this.uiTableLayoutPanel3.SetColumnSpan(this.tbFunction, 3);
            this.tbFunction.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFunction.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFunction.Location = new System.Drawing.Point(21, 10);
            this.tbFunction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFunction.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbFunction.Name = "tbFunction";
            this.tbFunction.ReadOnly = true;
            this.tbFunction.ShowText = false;
            this.tbFunction.Size = new System.Drawing.Size(37, 20);
            this.tbFunction.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbFunction.TabIndex = 8;
            this.tbFunction.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiTableLayoutPanel3.SetColumnSpan(this.uiLabel8, 2);
            this.uiLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(3, 0);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(21, 1);
            this.uiLabel8.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel8.TabIndex = 0;
            this.uiLabel8.Text = "2-Step-Verification";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogOut.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogOut.Location = new System.Drawing.Point(48, 3);
            this.btnLogOut.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Radius = 1;
            this.btnLogOut.Size = new System.Drawing.Size(11, 1);
            this.btnLogOut.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogOut.Visible = false;
            this.btnLogOut.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnLogOut.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnLogOut_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(3, 10);
            this.btnEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Radius = 1;
            this.btnEdit.Size = new System.Drawing.Size(11, 1);
            this.btnEdit.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(48, 10);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 1;
            this.btnSave.Size = new System.Drawing.Size(11, 1);
            this.btnSave.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Visible = false;
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(3, 1);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(11, 2);
            this.uiLabel9.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel9.TabIndex = 4;
            this.uiLabel9.Text = "User Name:";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel10
            // 
            this.uiLabel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(3, 3);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(11, 2);
            this.uiLabel10.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel10.TabIndex = 5;
            this.uiLabel10.Text = "Card_UID:";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel11
            // 
            this.uiLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(3, 5);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(11, 2);
            this.uiLabel11.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel11.TabIndex = 6;
            this.uiLabel11.Text = "Function:";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel11.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tbUserName
            // 
            this.uiTableLayoutPanel3.SetColumnSpan(this.tbUserName, 3);
            this.tbUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUserName.Location = new System.Drawing.Point(21, 6);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.ReadOnly = true;
            this.tbUserName.ShowText = false;
            this.tbUserName.Size = new System.Drawing.Size(37, 20);
            this.tbUserName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbUserName.TabIndex = 7;
            this.tbUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tbUid
            // 
            this.uiTableLayoutPanel3.SetColumnSpan(this.tbUid, 3);
            this.tbUid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUid.Location = new System.Drawing.Point(21, 8);
            this.tbUid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUid.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbUid.Name = "tbUid";
            this.tbUid.ReadOnly = true;
            this.tbUid.ShowText = false;
            this.tbUid.Size = new System.Drawing.Size(37, 20);
            this.tbUid.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbUid.TabIndex = 8;
            this.tbUid.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTableLayoutPanel4
            // 
            this.uiTableLayoutPanel4.ColumnCount = 1;
            this.uiTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel4.Controls.Add(this.dataGridView2, 0, 0);
            this.uiTableLayoutPanel4.Controls.Add(this.uiTableLayoutPanel5, 0, 1);
            this.uiTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel4.Location = new System.Drawing.Point(3, 38);
            this.uiTableLayoutPanel4.Name = "uiTableLayoutPanel4";
            this.uiTableLayoutPanel4.RowCount = 2;
            this.uiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.79536F));
            this.uiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.20463F));
            this.uiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel4.Size = new System.Drawing.Size(62, 19);
            this.uiTableLayoutPanel4.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiTableLayoutPanel4.TabIndex = 8;
            this.uiTableLayoutPanel4.TagString = null;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HashKeyItem,
            this.HashValue});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.GridColor = System.Drawing.Color.Black;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dataGridView2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(56, 6);
            this.dataGridView2.TabIndex = 10;
            // 
            // HashKeyItem
            // 
            this.HashKeyItem.HeaderText = "Hash key Item";
            this.HashKeyItem.MinimumWidth = 6;
            this.HashKeyItem.Name = "HashKeyItem";
            this.HashKeyItem.ReadOnly = true;
            this.HashKeyItem.Width = 155;
            // 
            // HashValue
            // 
            this.HashValue.HeaderText = "Hash value";
            this.HashValue.MinimumWidth = 6;
            this.HashValue.Name = "HashValue";
            this.HashValue.ReadOnly = true;
            this.HashValue.Width = 360;
            // 
            // uiTableLayoutPanel5
            // 
            this.uiTableLayoutPanel5.BackColor = System.Drawing.Color.LightGray;
            this.uiTableLayoutPanel5.ColumnCount = 3;
            this.uiTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.99065F));
            this.uiTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.19938F));
            this.uiTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.80997F));
            this.uiTableLayoutPanel5.Controls.Add(this.btnUploadMes, 2, 1);
            this.uiTableLayoutPanel5.Controls.Add(this.btnCancelHash, 0, 1);
            this.uiTableLayoutPanel5.Controls.Add(this.btnExportHash, 2, 0);
            this.uiTableLayoutPanel5.Controls.Add(this.btnRefeshHash, 0, 0);
            this.uiTableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel5.Location = new System.Drawing.Point(3, 15);
            this.uiTableLayoutPanel5.Name = "uiTableLayoutPanel5";
            this.uiTableLayoutPanel5.RowCount = 2;
            this.uiTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel5.Size = new System.Drawing.Size(56, 1);
            this.uiTableLayoutPanel5.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiTableLayoutPanel5.TabIndex = 9;
            this.uiTableLayoutPanel5.TagString = null;
            // 
            // btnUploadMes
            // 
            this.btnUploadMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUploadMes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUploadMes.Location = new System.Drawing.Point(36, 3);
            this.btnUploadMes.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnUploadMes.Name = "btnUploadMes";
            this.btnUploadMes.Radius = 1;
            this.btnUploadMes.Size = new System.Drawing.Size(17, 1);
            this.btnUploadMes.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnUploadMes.TabIndex = 5;
            this.btnUploadMes.Text = "Upload to MES";
            this.btnUploadMes.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUploadMes.Visible = false;
            this.btnUploadMes.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnUploadMes.Click += new System.EventHandler(this.btnUploadMes_Click);
            // 
            // btnCancelHash
            // 
            this.btnCancelHash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelHash.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelHash.Location = new System.Drawing.Point(3, 3);
            this.btnCancelHash.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancelHash.Name = "btnCancelHash";
            this.btnCancelHash.Radius = 1;
            this.btnCancelHash.Size = new System.Drawing.Size(18, 1);
            this.btnCancelHash.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnCancelHash.TabIndex = 3;
            this.btnCancelHash.Text = "Cancel";
            this.btnCancelHash.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelHash.Visible = false;
            this.btnCancelHash.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancelHash.Click += new System.EventHandler(this.btnCancelHash_Click);
            // 
            // btnExportHash
            // 
            this.btnExportHash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportHash.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportHash.Location = new System.Drawing.Point(36, 3);
            this.btnExportHash.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExportHash.Name = "btnExportHash";
            this.btnExportHash.Radius = 1;
            this.btnExportHash.Size = new System.Drawing.Size(17, 1);
            this.btnExportHash.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnExportHash.TabIndex = 2;
            this.btnExportHash.Text = "Export all hash keys";
            this.btnExportHash.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportHash.Visible = false;
            this.btnExportHash.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExportHash.Click += new System.EventHandler(this.btnExportHash_Click);
            // 
            // btnRefeshHash
            // 
            this.btnRefeshHash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefeshHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefeshHash.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefeshHash.Location = new System.Drawing.Point(3, 3);
            this.btnRefeshHash.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRefeshHash.Name = "btnRefeshHash";
            this.btnRefeshHash.Radius = 1;
            this.btnRefeshHash.Size = new System.Drawing.Size(18, 1);
            this.btnRefeshHash.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnRefeshHash.TabIndex = 0;
            this.btnRefeshHash.Text = "Refresh all hash keys";
            this.btnRefeshHash.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefeshHash.Visible = false;
            this.btnRefeshHash.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRefeshHash.Click += new System.EventHandler(this.btnRefeshHash_Click);
            // 
            // uiTableLayoutPanel6
            // 
            this.uiTableLayoutPanel6.ColumnCount = 1;
            this.uiTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel6.Controls.Add(this.uiPanel1, 0, 1);
            this.uiTableLayoutPanel6.Controls.Add(this.uiLabel12, 0, 0);
            this.uiTableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel6.Location = new System.Drawing.Point(71, 3);
            this.uiTableLayoutPanel6.Name = "uiTableLayoutPanel6";
            this.uiTableLayoutPanel6.RowCount = 2;
            this.uiTableLayoutPanel1.SetRowSpan(this.uiTableLayoutPanel6, 2);
            this.uiTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.995862F));
            this.uiTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.00414F));
            this.uiTableLayoutPanel6.Size = new System.Drawing.Size(60, 29);
            this.uiTableLayoutPanel6.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiTableLayoutPanel6.TabIndex = 9;
            this.uiTableLayoutPanel6.TagString = null;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(4, 7);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(52, 17);
            this.uiPanel1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel12
            // 
            this.uiLabel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel12.Location = new System.Drawing.Point(3, 0);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(54, 2);
            this.uiLabel12.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLabel12.TabIndex = 1;
            this.uiLabel12.Text = "Glue Path / Machine Config Parts";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel12.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tb_Test
            // 
            this.tb_Test.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tb_Test.Controls.Add(this.tableLayoutPanel3);
            this.tb_Test.Location = new System.Drawing.Point(0, 40);
            this.tb_Test.Name = "tb_Test";
            this.tb_Test.Size = new System.Drawing.Size(200, 60);
            this.tb_Test.TabIndex = 4;
            this.tb_Test.Text = "Test";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.88372F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.11628F));
            this.tableLayoutPanel3.Controls.Add(this.uiPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.25288F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.747127F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 60);
            this.tableLayoutPanel3.TabIndex = 0;
            this.tableLayoutPanel3.Visible = false;
            // 
            // uiPanel5
            // 
            this.uiPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiPanel5.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiPanel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel5.Location = new System.Drawing.Point(4, 5);
            this.uiPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel5.Name = "uiPanel5";
            this.uiPanel5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiPanel5.RectSize = 2;
            this.uiPanel5.Size = new System.Drawing.Size(61, 46);
            this.uiPanel5.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.uiPanel5.TabIndex = 1;
            this.uiPanel5.Text = null;
            this.uiPanel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SettingFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1548, 562);
            this.Controls.Add(this.tabControl);
            this.Name = "SettingFrm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingFrm_FormClosed);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.pnlGeneral.ResumeLayout(false);
            this.tlpGeneral.ResumeLayout(false);
            this.tlpGeneral.PerformLayout();
            this.pnlHardWare.ResumeLayout(false);
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.tlpControl.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tp_General.ResumeLayout(false);
            this.tp_Administration.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNames)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userAccessInfoBindingSource)).EndInit();
            this.uiTableLayoutPanel8.ResumeLayout(false);
            this.tp_Maintenance.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maintenanceBindingSource)).EndInit();
            this.tp_HashKey.ResumeLayout(false);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTableLayoutPanel7.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.uiTableLayoutPanel3.ResumeLayout(false);
            this.uiTableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.uiTableLayoutPanel5.ResumeLayout(false);
            this.uiTableLayoutPanel6.ResumeLayout(false);
            this.tb_Test.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private ProxyTools.SunnyUI.Controls.UILabel lblLine;
        private ProxyTools.SunnyUI.Controls.UILabel lblSite;
        private ProxyTools.SunnyUI.Controls.UILabel lblGeneral;
        private ProxyTools.SunnyUI.Controls.UIComboBox cbLanguage;
        private ProxyTools.SunnyUI.Controls.UIComboBox cbMachine;
        private ProxyTools.SunnyUI.Controls.UIComboBox cbLine;
        private ProxyTools.SunnyUI.Controls.UILabel lblStation;
        private ProxyTools.SunnyUI.Controls.UILabel lblMachine;
        private ProxyTools.SunnyUI.Controls.UILabel lblLanguage;
        private ProxyTools.SunnyUI.Controls.UILabel lblHardware;
        private ProxyTools.SunnyUI.Controls.UITreeView tvHardwareSetting;
        private UISplitContainer splMain;
        private ProxyTools.SunnyUI.Controls.UITableLayoutPanel tlpControl;
        private ProxyTools.SunnyUI.Controls.UIPanel pnlMain;
        private ProxyTools.SunnyUI.Controls.UILine line;
        private UIButton btnLoad;
        private System.Windows.Forms.ImageList imgParam;
        private UIPanel pnlGeneral;
        private UIPanel pnlHardWare;
        private UIComboBox cbStation;
        private UIComboBox cbSite;
        private UIComboBox cbproductionType;
        private UILabel lblproductionType;
        private Sunny.UI.UITabControl tabControl;
        private System.Windows.Forms.TabPage tp_General;
        private System.Windows.Forms.TabPage tp_Maintenance;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UIButton btnEidt;
        private UIButton btnExport;
        private UIButton btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private UIButton btnAddItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tp_HashKey;
        private System.Windows.Forms.BindingSource maintenanceBindingSource;
        private UITableLayoutPanel uiTableLayoutPanel1;
        private UITableLayoutPanel uiTableLayoutPanel2;
        private UITableLayoutPanel uiTableLayoutPanel3;
        private UITextBox tbFunction;
        private UILabel uiLabel8;
        private UIButton btnLogOut;
        private UIButton btnEdit;
        private UIButton btnSave;
        private UILabel uiLabel9;
        private UILabel uiLabel10;
        private UILabel uiLabel11;
        private UITextBox tbUserName;
        private UITextBox tbUid;
        private UITableLayoutPanel uiTableLayoutPanel4;
        private UITableLayoutPanel uiTableLayoutPanel5;
        private UIButton btnUploadMes;
        private UIButton btnCancelHash;
        private UIButton btnExportHash;
        private UIButton btnRefeshHash;
        private System.Windows.Forms.DataGridView dataGridView2;
        private UITableLayoutPanel uiTableLayoutPanel6;
        private UIPanel uiPanel4;
        private UIPanel uiPanel2;
        private UITableLayoutPanel uiTableLayoutPanel7;
        private UIPanel uiPanel3;
        private UIPanel uiPanel1;
        private UILabel uiLabel1;
        private UILabel uiLabel2;
        private UILabel uiLabel3;
        private UILabel uiLabel4;
        private UILabel uiLabel5;
        private UILabel uiLabel6;
        private UILabel uiLabel7;
        private UITextBox tbMainPath;
        private UITextBox tbVisionPath;
        private UITextBox tbLaserPath;
        private UITextBox tbRobotPath;
        private UITextBox tbIdePath;
        private UITextBox tbPlcPath;
        private UIButton btnMainPath;
        private UIButton btnPlcPath;
        private UIButton btnIdePath;
        private UIButton btnRobotPath;
        private UIButton btnLaserPath;
        private UIButton btnVisionPath;
        private UILabel uiLabel13;
        private UILabel uiLabel12;
        private System.Windows.Forms.DataGridViewTextBoxColumn HashKeyItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn HashValue;
        private System.Windows.Forms.TabPage tp_Administration;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvNames;
        private UITableLayoutPanel uiTableLayoutPanel8;
        private UIButton btnImportCSV;
        private UIButton btnAdminEdit;
        private UIButton btnAdminSave;
        private System.Windows.Forms.BindingSource userAccessInfoBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除用户ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn siteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardUIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn functionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processStationIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enrgz;
        private System.Windows.Forms.DataGridViewTextBoxColumn project;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineType;
        private System.Windows.Forms.DataGridViewTextBoxColumn headID;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn period;
        private System.Windows.Forms.DataGridViewTextBoxColumn countdown;
        private System.Windows.Forms.DataGridViewTextBoxColumn threshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn record;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private DataGridViewCustomButtonColumn Add;
        private DataGridViewCustomButtonColumn Remove;
        private System.Windows.Forms.TabPage tb_Test;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private UIPanel uiPanel5;
    }
}
