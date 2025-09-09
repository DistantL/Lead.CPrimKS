using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.Windows.Forms;

namespace Lead.CPrim.EleCommon.Forms
{
    partial class EleConfigForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsEles = new System.Windows.Forms.ToolStrip();
            this.tabElements = new System.Windows.Forms.TabControl();
            this.tpDI = new System.Windows.Forms.TabPage();
            this.dgvEleDi = new System.Windows.Forms.DataGridView();
            this.colEleDiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleDiInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleDiEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEleDiSimulate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEleDiPrimType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEleDiPrimName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEleDiAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleDiDiEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEleDiType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEleDiEnableRise = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEleDiEnableFall = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEleDiState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleDiLineMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入CSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpDO = new System.Windows.Forms.TabPage();
            this.dgvEleDo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEleDoType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEleDoTest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleDoLineMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpCylinderLine = new System.Windows.Forms.TabPage();
            this.dgvEleCylinder = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colStretchDiAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStretchDiEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRestractDiAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRestractDiEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colStretchDoAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStretchDoEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colStretchDoTest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRestractDoAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRestractDoEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRestractDoTest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colStretchTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRestractTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBlowTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEleCylinderLineMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAD = new System.Windows.Forms.TabPage();
            this.tpDA = new System.Windows.Forms.TabPage();
            this.tpLight = new System.Windows.Forms.TabPage();
            this.tpAxisLine = new System.Windows.Forms.TabPage();
            this.tpCartesian = new System.Windows.Forms.TabPage();
            this.tabCartesians = new System.Windows.Forms.TabControl();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tsTitle = new System.Windows.Forms.ToolStrip();
            this.tStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tStripBtnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnSortByName = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnSortByAddress = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Axis数量 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Cylinder数量 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.DO数量 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DI数量 = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnShowModeDI1 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowModeDI2 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowModeDO1 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowModeDO2 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowModeCylinder1 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnShowModeCylinder2 = new System.Windows.Forms.ToolStripButton();
            this.tsb_Debug = new System.Windows.Forms.ToolStripButton();
            this.tsb_Config = new System.Windows.Forms.ToolStripButton();
            this.tabElements.SuspendLayout();
            this.tpDI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleDi)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tpDO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleDo)).BeginInit();
            this.tpCylinderLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleCylinder)).BeginInit();
            this.tpCartesian.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tsTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1UiRefresh_Tick);
            // 
            // tsEles
            // 
            this.tsEles.BackColor = System.Drawing.SystemColors.Control;
            this.tsEles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsEles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsEles.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsEles.Location = new System.Drawing.Point(3, 3);
            this.tsEles.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tsEles.Name = "tsEles";
            this.tsEles.Padding = new System.Windows.Forms.Padding(0);
            this.tsEles.Size = new System.Drawing.Size(1540, 37);
            this.tsEles.TabIndex = 0;
            // 
            // tabElements
            // 
            this.tabElements.Controls.Add(this.tpDI);
            this.tabElements.Controls.Add(this.tpDO);
            this.tabElements.Controls.Add(this.tpCylinderLine);
            this.tabElements.Controls.Add(this.tpAD);
            this.tabElements.Controls.Add(this.tpDA);
            this.tabElements.Controls.Add(this.tpLight);
            this.tabElements.Controls.Add(this.tpAxisLine);
            this.tabElements.Controls.Add(this.tpCartesian);
            this.tabElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabElements.Location = new System.Drawing.Point(3, 80);
            this.tabElements.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tabElements.Name = "tabElements";
            this.tabElements.SelectedIndex = 0;
            this.tabElements.Size = new System.Drawing.Size(1540, 578);
            this.tabElements.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabElements.TabIndex = 2;
            // 
            // tpDI
            // 
            this.tpDI.Controls.Add(this.dgvEleDi);
            this.tpDI.Location = new System.Drawing.Point(4, 26);
            this.tpDI.Margin = new System.Windows.Forms.Padding(4);
            this.tpDI.Name = "tpDI";
            this.tpDI.Size = new System.Drawing.Size(1532, 548);
            this.tpDI.TabIndex = 0;
            this.tpDI.Text = "数字输入";
            this.tpDI.UseVisualStyleBackColor = true;
            // 
            // dgvEleDi
            // 
            this.dgvEleDi.AllowUserToAddRows = false;
            this.dgvEleDi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEleDi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEleDi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEleDi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEleDiName,
            this.colEleDiInfo,
            this.colEleDiEnable,
            this.colEleDiSimulate,
            this.colEleDiPrimType,
            this.colEleDiPrimName,
            this.colEleDiAddress,
            this.colEleDiDiEnable,
            this.colEleDiType,
            this.colEleDiEnableRise,
            this.colEleDiEnableFall,
            this.colEleDiState,
            this.colEleDiLineMark});
            this.dgvEleDi.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvEleDi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEleDi.Location = new System.Drawing.Point(0, 0);
            this.dgvEleDi.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEleDi.Name = "dgvEleDi";
            this.dgvEleDi.RowHeadersWidth = 51;
            this.dgvEleDi.RowTemplate.Height = 23;
            this.dgvEleDi.Size = new System.Drawing.Size(1532, 548);
            this.dgvEleDi.TabIndex = 0;
            this.dgvEleDi.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleDi_CellEnter);
            this.dgvEleDi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleDi_CellValueChanged);
            this.dgvEleDi.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEleDi_ColumnHeaderMouseClick);
            this.dgvEleDi.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ColumnHeaderMouseDoubleClick);
            this.dgvEleDi.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvEleDi_CurrentCellDirtyStateChanged);
            this.dgvEleDi.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvEleDi_RowStateChanged);
            // 
            // colEleDiName
            // 
            this.colEleDiName.HeaderText = "名称";
            this.colEleDiName.MinimumWidth = 6;
            this.colEleDiName.Name = "colEleDiName";
            this.colEleDiName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEleDiName.Width = 125;
            // 
            // colEleDiInfo
            // 
            this.colEleDiInfo.HeaderText = "信息";
            this.colEleDiInfo.MinimumWidth = 6;
            this.colEleDiInfo.Name = "colEleDiInfo";
            this.colEleDiInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEleDiInfo.Width = 125;
            // 
            // colEleDiEnable
            // 
            this.colEleDiEnable.HeaderText = "使能";
            this.colEleDiEnable.MinimumWidth = 6;
            this.colEleDiEnable.Name = "colEleDiEnable";
            this.colEleDiEnable.Width = 125;
            // 
            // colEleDiSimulate
            // 
            this.colEleDiSimulate.HeaderText = "模拟";
            this.colEleDiSimulate.MinimumWidth = 6;
            this.colEleDiSimulate.Name = "colEleDiSimulate";
            this.colEleDiSimulate.Width = 125;
            // 
            // colEleDiPrimType
            // 
            this.colEleDiPrimType.HeaderText = "基元类型";
            this.colEleDiPrimType.Items.AddRange(new object[] {
            "MotionCard"});
            this.colEleDiPrimType.MinimumWidth = 6;
            this.colEleDiPrimType.Name = "colEleDiPrimType";
            this.colEleDiPrimType.Width = 125;
            // 
            // colEleDiPrimName
            // 
            this.colEleDiPrimName.HeaderText = "基元名称";
            this.colEleDiPrimName.MinimumWidth = 6;
            this.colEleDiPrimName.Name = "colEleDiPrimName";
            this.colEleDiPrimName.Width = 125;
            // 
            // colEleDiAddress
            // 
            this.colEleDiAddress.HeaderText = "地址";
            this.colEleDiAddress.MinimumWidth = 6;
            this.colEleDiAddress.Name = "colEleDiAddress";
            this.colEleDiAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEleDiAddress.Width = 125;
            // 
            // colEleDiDiEnable
            // 
            this.colEleDiDiEnable.HeaderText = "输入使能";
            this.colEleDiDiEnable.MinimumWidth = 6;
            this.colEleDiDiEnable.Name = "colEleDiDiEnable";
            this.colEleDiDiEnable.Width = 70;
            // 
            // colEleDiType
            // 
            this.colEleDiType.HeaderText = "输入类型";
            this.colEleDiType.Items.AddRange(new object[] {
            "NO",
            "NC"});
            this.colEleDiType.MinimumWidth = 6;
            this.colEleDiType.Name = "colEleDiType";
            this.colEleDiType.Width = 70;
            // 
            // colEleDiEnableRise
            // 
            this.colEleDiEnableRise.HeaderText = "上升沿";
            this.colEleDiEnableRise.MinimumWidth = 6;
            this.colEleDiEnableRise.Name = "colEleDiEnableRise";
            this.colEleDiEnableRise.Width = 70;
            // 
            // colEleDiEnableFall
            // 
            this.colEleDiEnableFall.HeaderText = "下降沿";
            this.colEleDiEnableFall.MinimumWidth = 6;
            this.colEleDiEnableFall.Name = "colEleDiEnableFall";
            this.colEleDiEnableFall.Width = 70;
            // 
            // colEleDiState
            // 
            this.colEleDiState.HeaderText = "状态";
            this.colEleDiState.MinimumWidth = 6;
            this.colEleDiState.Name = "colEleDiState";
            this.colEleDiState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEleDiState.Width = 125;
            // 
            // colEleDiLineMark
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEleDiLineMark.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEleDiLineMark.HeaderText = "线号";
            this.colEleDiLineMark.Name = "colEleDiLineMark";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出CSVToolStripMenuItem,
            this.导入CSVToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 48);
            // 
            // 导出CSVToolStripMenuItem
            // 
            this.导出CSVToolStripMenuItem.Name = "导出CSVToolStripMenuItem";
            this.导出CSVToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.导出CSVToolStripMenuItem.Text = "导出CSV";
            this.导出CSVToolStripMenuItem.Click += new System.EventHandler(this.导出CSVToolStripMenuItem_Click);
            // 
            // 导入CSVToolStripMenuItem
            // 
            this.导入CSVToolStripMenuItem.Name = "导入CSVToolStripMenuItem";
            this.导入CSVToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.导入CSVToolStripMenuItem.Text = "导入CSV";
            this.导入CSVToolStripMenuItem.Click += new System.EventHandler(this.导入CSVToolStripMenuItem_Click);
            // 
            // tpDO
            // 
            this.tpDO.Controls.Add(this.dgvEleDo);
            this.tpDO.Location = new System.Drawing.Point(4, 26);
            this.tpDO.Margin = new System.Windows.Forms.Padding(4);
            this.tpDO.Name = "tpDO";
            this.tpDO.Size = new System.Drawing.Size(1532, 548);
            this.tpDO.TabIndex = 1;
            this.tpDO.Text = "数字输出";
            this.tpDO.UseVisualStyleBackColor = true;
            // 
            // dgvEleDo
            // 
            this.dgvEleDo.AllowUserToAddRows = false;
            this.dgvEleDo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEleDo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewComboBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn3,
            this.colEleDoType,
            this.colEleDoTest,
            this.dataGridViewTextBoxColumn4,
            this.colEleDoLineMark});
            this.dgvEleDo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvEleDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEleDo.Location = new System.Drawing.Point(0, 0);
            this.dgvEleDo.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEleDo.Name = "dgvEleDo";
            this.dgvEleDo.RowHeadersWidth = 51;
            this.dgvEleDo.RowTemplate.Height = 23;
            this.dgvEleDo.Size = new System.Drawing.Size(1532, 548);
            this.dgvEleDo.TabIndex = 1;
            this.dgvEleDo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleDo_CellContentClick);
            this.dgvEleDo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleDo_CellEnter);
            this.dgvEleDo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleDo_CellValueChanged);
            this.dgvEleDo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEleDo_ColumnHeaderMouseClick);
            this.dgvEleDo.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ColumnHeaderMouseDoubleClick);
            this.dgvEleDo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvEleDo_CurrentCellDirtyStateChanged);
            this.dgvEleDo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvEleDo_RowStateChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "名称";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "信息";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "使能";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 125;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "模拟";
            this.dataGridViewCheckBoxColumn2.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 125;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "基元类型";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "MotionCard"});
            this.dataGridViewComboBoxColumn1.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 125;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.HeaderText = "基元名称";
            this.dataGridViewComboBoxColumn2.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "地址";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.FillWeight = 80F;
            this.dataGridViewCheckBoxColumn3.HeaderText = "输出使能";
            this.dataGridViewCheckBoxColumn3.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Width = 125;
            // 
            // colEleDoType
            // 
            this.colEleDoType.FillWeight = 80F;
            this.colEleDoType.HeaderText = "输出类型";
            this.colEleDoType.Items.AddRange(new object[] {
            "NO",
            "NC"});
            this.colEleDoType.MinimumWidth = 6;
            this.colEleDoType.Name = "colEleDoType";
            this.colEleDoType.Width = 125;
            // 
            // colEleDoTest
            // 
            this.colEleDoTest.HeaderText = "测试";
            this.colEleDoTest.MinimumWidth = 6;
            this.colEleDoTest.Name = "colEleDoTest";
            this.colEleDoTest.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEleDoTest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEleDoTest.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "状态";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // colEleDoLineMark
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEleDoLineMark.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEleDoLineMark.HeaderText = "线号";
            this.colEleDoLineMark.Name = "colEleDoLineMark";
            // 
            // tpCylinderLine
            // 
            this.tpCylinderLine.Controls.Add(this.dgvEleCylinder);
            this.tpCylinderLine.Location = new System.Drawing.Point(4, 26);
            this.tpCylinderLine.Margin = new System.Windows.Forms.Padding(4);
            this.tpCylinderLine.Name = "tpCylinderLine";
            this.tpCylinderLine.Size = new System.Drawing.Size(1532, 548);
            this.tpCylinderLine.TabIndex = 6;
            this.tpCylinderLine.Text = "气缸&真空";
            this.tpCylinderLine.UseVisualStyleBackColor = true;
            // 
            // dgvEleCylinder
            // 
            this.dgvEleCylinder.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEleCylinder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEleCylinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEleCylinder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn4,
            this.dataGridViewCheckBoxColumn5,
            this.dataGridViewComboBoxColumn3,
            this.dataGridViewComboBoxColumn4,
            this.colType,
            this.colStretchDiAddress,
            this.colStretchDiEnable,
            this.colRestractDiAddress,
            this.colRestractDiEnable,
            this.colStretchDoAddress,
            this.colStretchDoEnable,
            this.colStretchDoTest,
            this.colRestractDoAddress,
            this.colRestractDoEnable,
            this.colRestractDoTest,
            this.colStretchTime,
            this.colRestractTime,
            this.colBlowTime,
            this.dataGridViewTextBoxColumn8,
            this.colEleCylinderLineMark});
            this.dgvEleCylinder.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvEleCylinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEleCylinder.Location = new System.Drawing.Point(0, 0);
            this.dgvEleCylinder.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEleCylinder.Name = "dgvEleCylinder";
            this.dgvEleCylinder.RowHeadersWidth = 51;
            this.dgvEleCylinder.RowTemplate.Height = 23;
            this.dgvEleCylinder.Size = new System.Drawing.Size(1532, 548);
            this.dgvEleCylinder.TabIndex = 1;
            this.dgvEleCylinder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleCylinder_CellContentClick);
            this.dgvEleCylinder.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleCylinder_CellEnter);
            this.dgvEleCylinder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleCylinder_CellValueChanged);
            this.dgvEleCylinder.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEleCylinder_ColumnHeaderMouseClick);
            this.dgvEleCylinder.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ColumnHeaderMouseDoubleClick);
            this.dgvEleCylinder.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvEleCylinder_CurrentCellDirtyStateChanged);
            this.dgvEleCylinder.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvEleCylinder_RowStateChanged);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "名称";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "信息";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.HeaderText = "使能";
            this.dataGridViewCheckBoxColumn4.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.Width = 30;
            // 
            // dataGridViewCheckBoxColumn5
            // 
            this.dataGridViewCheckBoxColumn5.HeaderText = "模拟";
            this.dataGridViewCheckBoxColumn5.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
            this.dataGridViewCheckBoxColumn5.Width = 30;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.HeaderText = "基元类型";
            this.dataGridViewComboBoxColumn3.Items.AddRange(new object[] {
            "MotionCard"});
            this.dataGridViewComboBoxColumn3.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Width = 90;
            // 
            // dataGridViewComboBoxColumn4
            // 
            this.dataGridViewComboBoxColumn4.HeaderText = "基元名称";
            this.dataGridViewComboBoxColumn4.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
            this.dataGridViewComboBoxColumn4.Width = 90;
            // 
            // colType
            // 
            this.colType.HeaderText = "类型";
            this.colType.MinimumWidth = 6;
            this.colType.Name = "colType";
            this.colType.Width = 125;
            // 
            // colStretchDiAddress
            // 
            this.colStretchDiAddress.HeaderText = "伸位地址";
            this.colStretchDiAddress.MinimumWidth = 6;
            this.colStretchDiAddress.Name = "colStretchDiAddress";
            this.colStretchDiAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStretchDiAddress.Width = 60;
            // 
            // colStretchDiEnable
            // 
            this.colStretchDiEnable.HeaderText = "伸位使能";
            this.colStretchDiEnable.MinimumWidth = 6;
            this.colStretchDiEnable.Name = "colStretchDiEnable";
            this.colStretchDiEnable.Width = 30;
            // 
            // colRestractDiAddress
            // 
            this.colRestractDiAddress.HeaderText = "原位地址";
            this.colRestractDiAddress.MinimumWidth = 6;
            this.colRestractDiAddress.Name = "colRestractDiAddress";
            this.colRestractDiAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRestractDiAddress.Width = 60;
            // 
            // colRestractDiEnable
            // 
            this.colRestractDiEnable.HeaderText = "原位使能";
            this.colRestractDiEnable.MinimumWidth = 6;
            this.colRestractDiEnable.Name = "colRestractDiEnable";
            this.colRestractDiEnable.Width = 30;
            // 
            // colStretchDoAddress
            // 
            this.colStretchDoAddress.HeaderText = "伸出地址";
            this.colStretchDoAddress.MinimumWidth = 6;
            this.colStretchDoAddress.Name = "colStretchDoAddress";
            this.colStretchDoAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStretchDoAddress.Width = 60;
            // 
            // colStretchDoEnable
            // 
            this.colStretchDoEnable.HeaderText = "伸出使能";
            this.colStretchDoEnable.MinimumWidth = 6;
            this.colStretchDoEnable.Name = "colStretchDoEnable";
            this.colStretchDoEnable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStretchDoEnable.Width = 30;
            // 
            // colStretchDoTest
            // 
            this.colStretchDoTest.HeaderText = "伸出测试";
            this.colStretchDoTest.MinimumWidth = 6;
            this.colStretchDoTest.Name = "colStretchDoTest";
            this.colStretchDoTest.Width = 30;
            // 
            // colRestractDoAddress
            // 
            this.colRestractDoAddress.HeaderText = "缩回地址";
            this.colRestractDoAddress.MinimumWidth = 6;
            this.colRestractDoAddress.Name = "colRestractDoAddress";
            this.colRestractDoAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRestractDoAddress.Width = 60;
            // 
            // colRestractDoEnable
            // 
            this.colRestractDoEnable.HeaderText = "缩回使能";
            this.colRestractDoEnable.MinimumWidth = 6;
            this.colRestractDoEnable.Name = "colRestractDoEnable";
            this.colRestractDoEnable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRestractDoEnable.Width = 30;
            // 
            // colRestractDoTest
            // 
            this.colRestractDoTest.HeaderText = "缩回测试";
            this.colRestractDoTest.MinimumWidth = 6;
            this.colRestractDoTest.Name = "colRestractDoTest";
            this.colRestractDoTest.Width = 30;
            // 
            // colStretchTime
            // 
            this.colStretchTime.HeaderText = "伸延时";
            this.colStretchTime.MinimumWidth = 6;
            this.colStretchTime.Name = "colStretchTime";
            this.colStretchTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStretchTime.Width = 60;
            // 
            // colRestractTime
            // 
            this.colRestractTime.HeaderText = "缩延时";
            this.colRestractTime.MinimumWidth = 6;
            this.colRestractTime.Name = "colRestractTime";
            this.colRestractTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRestractTime.Width = 60;
            // 
            // colBlowTime
            // 
            this.colBlowTime.HeaderText = "吹气延时";
            this.colBlowTime.MinimumWidth = 6;
            this.colBlowTime.Name = "colBlowTime";
            this.colBlowTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBlowTime.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "状态";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // colEleCylinderLineMark
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEleCylinderLineMark.DefaultCellStyle = dataGridViewCellStyle5;
            this.colEleCylinderLineMark.HeaderText = "编号";
            this.colEleCylinderLineMark.Name = "colEleCylinderLineMark";
            // 
            // tpAD
            // 
            this.tpAD.Location = new System.Drawing.Point(4, 26);
            this.tpAD.Margin = new System.Windows.Forms.Padding(4);
            this.tpAD.Name = "tpAD";
            this.tpAD.Size = new System.Drawing.Size(1532, 548);
            this.tpAD.TabIndex = 2;
            this.tpAD.Text = "模拟输入";
            this.tpAD.UseVisualStyleBackColor = true;
            // 
            // tpDA
            // 
            this.tpDA.Location = new System.Drawing.Point(4, 26);
            this.tpDA.Margin = new System.Windows.Forms.Padding(4);
            this.tpDA.Name = "tpDA";
            this.tpDA.Size = new System.Drawing.Size(1532, 548);
            this.tpDA.TabIndex = 3;
            this.tpDA.Text = "模拟输出";
            this.tpDA.UseVisualStyleBackColor = true;
            // 
            // tpLight
            // 
            this.tpLight.Location = new System.Drawing.Point(4, 26);
            this.tpLight.Margin = new System.Windows.Forms.Padding(4);
            this.tpLight.Name = "tpLight";
            this.tpLight.Size = new System.Drawing.Size(1532, 548);
            this.tpLight.TabIndex = 4;
            this.tpLight.Text = "系统指示灯";
            this.tpLight.UseVisualStyleBackColor = true;
            // 
            // tpAxisLine
            // 
            this.tpAxisLine.Location = new System.Drawing.Point(4, 26);
            this.tpAxisLine.Margin = new System.Windows.Forms.Padding(4);
            this.tpAxisLine.Name = "tpAxisLine";
            this.tpAxisLine.Size = new System.Drawing.Size(1532, 548);
            this.tpAxisLine.TabIndex = 7;
            this.tpAxisLine.Text = "单轴";
            this.tpAxisLine.UseVisualStyleBackColor = true;
            // 
            // tpCartesian
            // 
            this.tpCartesian.AutoScroll = true;
            this.tpCartesian.Controls.Add(this.tabCartesians);
            this.tpCartesian.Location = new System.Drawing.Point(4, 26);
            this.tpCartesian.Margin = new System.Windows.Forms.Padding(4);
            this.tpCartesian.Name = "tpCartesian";
            this.tpCartesian.Size = new System.Drawing.Size(1532, 548);
            this.tpCartesian.TabIndex = 5;
            this.tpCartesian.Text = "轴组";
            this.tpCartesian.UseVisualStyleBackColor = true;
            // 
            // tabCartesians
            // 
            this.tabCartesians.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCartesians.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCartesians.Location = new System.Drawing.Point(0, 0);
            this.tabCartesians.Margin = new System.Windows.Forms.Padding(2);
            this.tabCartesians.Multiline = true;
            this.tabCartesians.Name = "tabCartesians";
            this.tabCartesians.SelectedIndex = 0;
            this.tabCartesians.Size = new System.Drawing.Size(1532, 548);
            this.tabCartesians.TabIndex = 1;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tabElements, 0, 2);
            this.tlpMain.Controls.Add(this.tsTitle, 0, 1);
            this.tlpMain.Controls.Add(this.tsEles, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(5, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1546, 661);
            this.tlpMain.TabIndex = 1;
            // 
            // tsTitle
            // 
            this.tsTitle.BackColor = System.Drawing.SystemColors.Control;
            this.tsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsTitle.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripBtnSave,
            this.tStripBtnDel,
            this.toolStripSeparator1,
            this.tsBtnSortByName,
            this.toolStripSeparator2,
            this.tsBtnSortByAddress,
            this.toolStripSeparator4,
            this.Axis数量,
            this.toolStripSeparator5,
            this.Cylinder数量,
            this.toolStripSeparator6,
            this.DO数量,
            this.toolStripSeparator3,
            this.DI数量,
            this.tsbtnShowModeDI1,
            this.tsbtnShowModeDI2,
            this.tsbtnShowModeDO1,
            this.tsbtnShowModeDO2,
            this.tsbtnShowModeCylinder1,
            this.tsbtnShowModeCylinder2,
            this.tsb_Debug,
            this.tsb_Config});
            this.tsTitle.Location = new System.Drawing.Point(3, 40);
            this.tsTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tsTitle.Name = "tsTitle";
            this.tsTitle.Padding = new System.Windows.Forms.Padding(0);
            this.tsTitle.Size = new System.Drawing.Size(1540, 40);
            this.tsTitle.TabIndex = 6;
            this.tsTitle.Text = "toolStrip1";
            // 
            // tStripBtnSave
            // 
            this.tStripBtnSave.AutoSize = false;
            this.tStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtnSave.Image = global::Lead.CPrim.Common.Properties.Resources.tStripBtnSave_Image;
            this.tStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtnSave.Name = "tStripBtnSave";
            this.tStripBtnSave.Size = new System.Drawing.Size(50, 37);
            this.tStripBtnSave.Text = "保存元件配置";
            this.tStripBtnSave.Visible = false;
            this.tStripBtnSave.Click += new System.EventHandler(this.tStripBtnSave_Click);
            // 
            // tStripBtnDel
            // 
            this.tStripBtnDel.AutoSize = false;
            this.tStripBtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtnDel.Image = global::Lead.CPrim.Common.Properties.Resources.tStripBtnDel_Image;
            this.tStripBtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtnDel.Name = "tStripBtnDel";
            this.tStripBtnDel.Size = new System.Drawing.Size(50, 37);
            this.tStripBtnDel.Text = "删除当前选中的元件";
            this.tStripBtnDel.Click += new System.EventHandler(this.tStripBtnDel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsBtnSortByName
            // 
            this.tsBtnSortByName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSortByName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSortByName.Name = "tsBtnSortByName";
            this.tsBtnSortByName.Size = new System.Drawing.Size(76, 37);
            this.tsBtnSortByName.Text = "按名称排序";
            this.tsBtnSortByName.Click += new System.EventHandler(this.tsBtnSortByName_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tsBtnSortByAddress
            // 
            this.tsBtnSortByAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnSortByAddress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSortByAddress.Name = "tsBtnSortByAddress";
            this.tsBtnSortByAddress.Size = new System.Drawing.Size(89, 37);
            this.tsBtnSortByAddress.Text = "按主地址排序";
            this.tsBtnSortByAddress.Click += new System.EventHandler(this.tsBtnSortByAddress_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
            // 
            // Axis数量
            // 
            this.Axis数量.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Axis数量.AutoSize = false;
            this.Axis数量.AutoToolTip = true;
            this.Axis数量.Name = "Axis数量";
            this.Axis数量.Size = new System.Drawing.Size(120, 22);
            this.Axis数量.Text = "Axis数量";
            this.Axis数量.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
            this.toolStripSeparator5.Visible = false;
            // 
            // Cylinder数量
            // 
            this.Cylinder数量.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Cylinder数量.AutoSize = false;
            this.Cylinder数量.AutoToolTip = true;
            this.Cylinder数量.Name = "Cylinder数量";
            this.Cylinder数量.Size = new System.Drawing.Size(120, 22);
            this.Cylinder数量.Text = "Cylinder数量";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // DO数量
            // 
            this.DO数量.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DO数量.AutoSize = false;
            this.DO数量.AutoToolTip = true;
            this.DO数量.Name = "DO数量";
            this.DO数量.Size = new System.Drawing.Size(120, 22);
            this.DO数量.Text = "DO数量";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // DI数量
            // 
            this.DI数量.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DI数量.AutoSize = false;
            this.DI数量.AutoToolTip = true;
            this.DI数量.Name = "DI数量";
            this.DI数量.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DI数量.Size = new System.Drawing.Size(120, 22);
            this.DI数量.Text = "DI数量";
            // 
            // tsbtnShowModeDI1
            // 
            this.tsbtnShowModeDI1.AutoSize = false;
            this.tsbtnShowModeDI1.BackColor = System.Drawing.Color.Lime;
            this.tsbtnShowModeDI1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnShowModeDI1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowModeDI1.Name = "tsbtnShowModeDI1";
            this.tsbtnShowModeDI1.Size = new System.Drawing.Size(76, 37);
            this.tsbtnShowModeDI1.Text = "输入显示1";
            this.tsbtnShowModeDI1.Visible = false;
            this.tsbtnShowModeDI1.Click += new System.EventHandler(this.tsbtnShowModeDI1_Click);
            // 
            // tsbtnShowModeDI2
            // 
            this.tsbtnShowModeDI2.AutoSize = false;
            this.tsbtnShowModeDI2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnShowModeDI2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowModeDI2.Name = "tsbtnShowModeDI2";
            this.tsbtnShowModeDI2.Size = new System.Drawing.Size(76, 37);
            this.tsbtnShowModeDI2.Text = "输入显示2";
            this.tsbtnShowModeDI2.Visible = false;
            this.tsbtnShowModeDI2.Click += new System.EventHandler(this.tsbtnShowModeDI2_Click);
            // 
            // tsbtnShowModeDO1
            // 
            this.tsbtnShowModeDO1.AutoSize = false;
            this.tsbtnShowModeDO1.BackColor = System.Drawing.Color.Lime;
            this.tsbtnShowModeDO1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnShowModeDO1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowModeDO1.Name = "tsbtnShowModeDO1";
            this.tsbtnShowModeDO1.Size = new System.Drawing.Size(76, 37);
            this.tsbtnShowModeDO1.Text = "输出显示1";
            this.tsbtnShowModeDO1.Visible = false;
            this.tsbtnShowModeDO1.Click += new System.EventHandler(this.tsbtnShowModeDO1_Click);
            // 
            // tsbtnShowModeDO2
            // 
            this.tsbtnShowModeDO2.AutoSize = false;
            this.tsbtnShowModeDO2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnShowModeDO2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowModeDO2.Name = "tsbtnShowModeDO2";
            this.tsbtnShowModeDO2.Size = new System.Drawing.Size(76, 37);
            this.tsbtnShowModeDO2.Text = "输出显示2";
            this.tsbtnShowModeDO2.Visible = false;
            this.tsbtnShowModeDO2.Click += new System.EventHandler(this.tsbtnShowModeDO2_Click);
            // 
            // tsbtnShowModeCylinder1
            // 
            this.tsbtnShowModeCylinder1.AutoSize = false;
            this.tsbtnShowModeCylinder1.BackColor = System.Drawing.Color.Lime;
            this.tsbtnShowModeCylinder1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnShowModeCylinder1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowModeCylinder1.Name = "tsbtnShowModeCylinder1";
            this.tsbtnShowModeCylinder1.Size = new System.Drawing.Size(76, 37);
            this.tsbtnShowModeCylinder1.Text = "气缸显示1";
            this.tsbtnShowModeCylinder1.Visible = false;
            this.tsbtnShowModeCylinder1.Click += new System.EventHandler(this.tsbtnShowModeCylinder1_Click);
            // 
            // tsbtnShowModeCylinder2
            // 
            this.tsbtnShowModeCylinder2.AutoSize = false;
            this.tsbtnShowModeCylinder2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnShowModeCylinder2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnShowModeCylinder2.Name = "tsbtnShowModeCylinder2";
            this.tsbtnShowModeCylinder2.Size = new System.Drawing.Size(76, 37);
            this.tsbtnShowModeCylinder2.Text = "气缸显示2";
            this.tsbtnShowModeCylinder2.Visible = false;
            this.tsbtnShowModeCylinder2.Click += new System.EventHandler(this.tsbtnShowModeCylinder2_Click);
            // 
            // tsb_Debug
            // 
            this.tsb_Debug.AutoSize = false;
            this.tsb_Debug.BackColor = System.Drawing.Color.Lime;
            this.tsb_Debug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Debug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Debug.Name = "tsb_Debug";
            this.tsb_Debug.Size = new System.Drawing.Size(76, 37);
            this.tsb_Debug.Text = "调试";
            this.tsb_Debug.Click += new System.EventHandler(this.tsb_Debug_Click);
            // 
            // tsb_Config
            // 
            this.tsb_Config.AutoSize = false;
            this.tsb_Config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Config.Name = "tsb_Config";
            this.tsb_Config.Size = new System.Drawing.Size(76, 37);
            this.tsb_Config.Text = "配置";
            this.tsb_Config.Click += new System.EventHandler(this.tsb_Config_Click);
            // 
            // EleConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1556, 664);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EleConfigForm";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "元件配置";
            this.Load += new System.EventHandler(this.EleConfigForm_Load);
            this.VisibleChanged += new System.EventHandler(this.EleConfigForm_VisibleChanged);
            this.tabElements.ResumeLayout(false);
            this.tpDI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleDi)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tpDO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleDo)).EndInit();
            this.tpCylinderLine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleCylinder)).EndInit();
            this.tpCartesian.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tsTitle.ResumeLayout(false);
            this.tsTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Timer timer1;
        private ToolStrip tsEles;
        private TabControl tabElements;
        private TabPage tpDI;
        private DataGridView dgvEleDi;
        private TabPage tpDO;
        private TabPage tpAD;
        private TabPage tpDA;
        private TabPage tpLight;
        private TabPage tpCartesian;
        private DataGridView dgvEleDo;
        private TabPage tpCylinderLine;
        private DataGridView dgvEleCylinder;
        private TabPage tpAxisLine;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 导出CSVToolStripMenuItem;
        private ToolStripMenuItem 导入CSVToolStripMenuItem;
        private TableLayoutPanel tlpMain;
        private TabControl tabCartesians;
        private ToolStrip tsTitle;
        private ToolStripButton tStripBtnSave;
        private ToolStripButton tStripBtnDel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsBtnSortByName;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsBtnSortByAddress;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel Axis数量;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel Cylinder数量;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripLabel DO数量;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel DI数量;
        private ToolStripButton tsbtnShowModeDI1;
        private ToolStripButton tsbtnShowModeDI2;
        private ToolStripButton tsbtnShowModeDO1;
        private ToolStripButton tsbtnShowModeDO2;
        private ToolStripButton tsbtnShowModeCylinder1;
        private ToolStripButton tsbtnShowModeCylinder2;
        private ToolStripButton tsb_Debug;
        private ToolStripButton tsb_Config;
        private DataGridViewTextBoxColumn colEleDiName;
        private DataGridViewTextBoxColumn colEleDiInfo;
        private DataGridViewCheckBoxColumn colEleDiEnable;
        private DataGridViewCheckBoxColumn colEleDiSimulate;
        private DataGridViewComboBoxColumn colEleDiPrimType;
        private DataGridViewComboBoxColumn colEleDiPrimName;
        private DataGridViewTextBoxColumn colEleDiAddress;
        private DataGridViewCheckBoxColumn colEleDiDiEnable;
        private DataGridViewComboBoxColumn colEleDiType;
        private DataGridViewCheckBoxColumn colEleDiEnableRise;
        private DataGridViewCheckBoxColumn colEleDiEnableFall;
        private DataGridViewTextBoxColumn colEleDiState;
        private DataGridViewTextBoxColumn colEleDiLineMark;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private DataGridViewComboBoxColumn colEleDoType;
        private DataGridViewButtonColumn colEleDoTest;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn colEleDoLineMark;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
        private DataGridViewComboBoxColumn colType;
        private DataGridViewTextBoxColumn colStretchDiAddress;
        private DataGridViewCheckBoxColumn colStretchDiEnable;
        private DataGridViewTextBoxColumn colRestractDiAddress;
        private DataGridViewCheckBoxColumn colRestractDiEnable;
        private DataGridViewTextBoxColumn colStretchDoAddress;
        private DataGridViewCheckBoxColumn colStretchDoEnable;
        private DataGridViewButtonColumn colStretchDoTest;
        private DataGridViewTextBoxColumn colRestractDoAddress;
        private DataGridViewCheckBoxColumn colRestractDoEnable;
        private DataGridViewButtonColumn colRestractDoTest;
        private DataGridViewTextBoxColumn colStretchTime;
        private DataGridViewTextBoxColumn colRestractTime;
        private DataGridViewTextBoxColumn colBlowTime;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn colEleCylinderLineMark;
    }
}