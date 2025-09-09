using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.CommonUI
{
    partial class SingleStationConfigControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsInterlock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddInterlockRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveInterlockRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.timerDataInfo = new System.Windows.Forms.Timer(this.components);
            this.tlpMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tlpTitle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.chkStationEnable = new System.Windows.Forms.CheckBox();
            this.tbCurrentRecipe = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbStationName = new System.Windows.Forms.TextBox();
            this.lb_CurrentStationRecipe = new System.Windows.Forms.Label();
            this.lb_StationIndex = new System.Windows.Forms.Label();
            this.tbStationIndex = new System.Windows.Forms.TextBox();
            this.lb_StationInfo = new System.Windows.Forms.Label();
            this.tbStationDescription = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tlpConfig = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRecipeInfo = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.lb_SelectRecipeInfo = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.rtbRecipe = new System.Windows.Forms.RichTextBox();
            this.tlpTask = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.btnTaskDown = new System.Windows.Forms.Button();
            this.btnTaskUp = new System.Windows.Forms.Button();
            this.cmbTasks = new System.Windows.Forms.ComboBox();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnRefreshTasks = new System.Windows.Forms.Button();
            this.lb_Task = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tlpButton = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.btnDispose = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.btnInit = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.dgvTasks = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskStatup = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlpStationButton = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tbEventInfo3 = new System.Windows.Forms.TextBox();
            this.tbEventInfo2 = new System.Windows.Forms.TextBox();
            this.tbEventInfo1 = new System.Windows.Forms.TextBox();
            this.chkEventEnable1 = new System.Windows.Forms.CheckBox();
            this.chkEventEnable2 = new System.Windows.Forms.CheckBox();
            this.chkEventEnable3 = new System.Windows.Forms.CheckBox();
            this.lb_StationButton = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tlpRecipe = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.btnRecipeElesConfig = new System.Windows.Forms.Button();
            this.cmbRtVals = new System.Windows.Forms.ComboBox();
            this.lb_RecipeInfo = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cmbMainGui = new System.Windows.Forms.ComboBox();
            this.cmbVariableSel = new System.Windows.Forms.ComboBox();
            this.lb_CommonParam = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_MainGUI = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_RtValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnRecipePrimsConfig = new System.Windows.Forms.Button();
            this.tlpRecipeButton = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.btnDeleteRecipe = new System.Windows.Forms.Button();
            this.btnRecipeUpload = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreateRecipe = new System.Windows.Forms.Button();
            this.dgvRecipes = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIDataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpVariable = new System.Windows.Forms.TabPage();
            this.tlpVariable = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tsDataInfo = new System.Windows.Forms.ToolStrip();
            this.tsl_DataInfo = new System.Windows.Forms.ToolStripLabel();
            this.tsCmbDataInfo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAddDataInfo = new System.Windows.Forms.ToolStripButton();
            this.tsDelDataInfo = new System.Windows.Forms.ToolStripButton();
            this.tsDataInfoStartMonitor = new System.Windows.Forms.ToolStripButton();
            this.tsDataInfoStopMonitor = new System.Windows.Forms.ToolStripButton();
            this.dgvDataInfo = new System.Windows.Forms.DataGridView();
            this.colDtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDtValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtInputVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtInput = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDtSave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tpOutputUI = new System.Windows.Forms.TabPage();
            this.tlpMainUi = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.tabDisplayConfigs = new System.Windows.Forms.TabControl();
            this.tPageDisplayConfig = new System.Windows.Forms.TabPage();
            this.flowSimpleFaiConfigs = new System.Windows.Forms.FlowLayoutPanel();
            this.tsMainUiConfig = new System.Windows.Forms.ToolStrip();
            this.tsl_MainGUItable = new System.Windows.Forms.ToolStripLabel();
            this.tsCmbDisplayConfigs = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnAddSingleConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnRemoveSingleConfig = new System.Windows.Forms.ToolStripButton();
            this.tpRtVals = new System.Windows.Forms.TabPage();
            this.tlpRtVars = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITableLayoutPanel();
            this.dgvRtVars = new System.Windows.Forms.DataGridView();
            this.colRtVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRtVarType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRtVarSave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tsRtVarsConfig = new System.Windows.Forms.ToolStrip();
            this.tsl_RtVars = new System.Windows.Forms.ToolStripLabel();
            this.tsCmbRtVars = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnAddRtVar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRemoveRtVar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnRefreshRtVar = new System.Windows.Forms.ToolStripButton();
            this.dataInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmsInterlock.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpTitle.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tlpConfig.SuspendLayout();
            this.tlpRecipeInfo.SuspendLayout();
            this.tlpTask.SuspendLayout();
            this.tlpButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.tlpStationButton.SuspendLayout();
            this.tlpRecipe.SuspendLayout();
            this.tlpRecipeButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).BeginInit();
            this.tpVariable.SuspendLayout();
            this.tlpVariable.SuspendLayout();
            this.tsDataInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataInfo)).BeginInit();
            this.tpOutputUI.SuspendLayout();
            this.tlpMainUi.SuspendLayout();
            this.tabDisplayConfigs.SuspendLayout();
            this.tPageDisplayConfig.SuspendLayout();
            this.tsMainUiConfig.SuspendLayout();
            this.tpRtVals.SuspendLayout();
            this.tlpRtVars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRtVars)).BeginInit();
            this.tsRtVarsConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsInterlock
            // 
            this.cmsInterlock.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInterlock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddInterlockRecord,
            this.tsmRemoveInterlockRecord});
            this.cmsInterlock.Name = "cmsInterlock";
            this.cmsInterlock.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmAddInterlockRecord
            // 
            this.tsmAddInterlockRecord.Name = "tsmAddInterlockRecord";
            this.tsmAddInterlockRecord.Size = new System.Drawing.Size(100, 22);
            this.tsmAddInterlockRecord.Text = "添加";
            // 
            // tsmRemoveInterlockRecord
            // 
            this.tsmRemoveInterlockRecord.Name = "tsmRemoveInterlockRecord";
            this.tsmRemoveInterlockRecord.Size = new System.Drawing.Size(100, 22);
            this.tsmRemoveInterlockRecord.Text = "删除";
            // 
            // timerDataInfo
            // 
            this.timerDataInfo.Interval = 30;
            this.timerDataInfo.Tick += new System.EventHandler(this.timerDataInfo_Tick);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpTitle, 0, 0);
            this.tlpMain.Controls.Add(this.tabMain, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 700);
            this.tlpMain.TabIndex = 1;
            this.tlpMain.TagString = null;
            // 
            // tlpTitle
            // 
            this.tlpTitle.ColumnCount = 9;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00002F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00002F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00002F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00002F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00002F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00002F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00002F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00002F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.99984F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTitle.Controls.Add(this.chkStationEnable, 0, 0);
            this.tlpTitle.Controls.Add(this.tbCurrentRecipe, 7, 0);
            this.tlpTitle.Controls.Add(this.btnApply, 8, 0);
            this.tlpTitle.Controls.Add(this.tbStationName, 1, 0);
            this.tlpTitle.Controls.Add(this.lb_CurrentStationRecipe, 6, 0);
            this.tlpTitle.Controls.Add(this.lb_StationIndex, 2, 0);
            this.tlpTitle.Controls.Add(this.tbStationIndex, 3, 0);
            this.tlpTitle.Controls.Add(this.lb_StationInfo, 4, 0);
            this.tlpTitle.Controls.Add(this.tbStationDescription, 5, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlpTitle.Location = new System.Drawing.Point(0, 0);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(1000, 28);
            this.tlpTitle.TabIndex = 241;
            this.tlpTitle.TagString = null;
            // 
            // chkStationEnable
            // 
            this.chkStationEnable.AutoSize = true;
            this.chkStationEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkStationEnable.Location = new System.Drawing.Point(1, 1);
            this.chkStationEnable.Margin = new System.Windows.Forms.Padding(1);
            this.chkStationEnable.Name = "chkStationEnable";
            this.chkStationEnable.Size = new System.Drawing.Size(98, 26);
            this.chkStationEnable.TabIndex = 238;
            this.chkStationEnable.Text = "工站名称:";
            this.chkStationEnable.UseVisualStyleBackColor = true;
            // 
            // tbCurrentRecipe
            // 
            this.tbCurrentRecipe.BackColor = System.Drawing.Color.LightGreen;
            this.tbCurrentRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCurrentRecipe.Location = new System.Drawing.Point(701, 1);
            this.tbCurrentRecipe.Margin = new System.Windows.Forms.Padding(1);
            this.tbCurrentRecipe.Name = "tbCurrentRecipe";
            this.tbCurrentRecipe.ReadOnly = true;
            this.tbCurrentRecipe.Size = new System.Drawing.Size(98, 26);
            this.tbCurrentRecipe.TabIndex = 240;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LawnGreen;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(801, 1);
            this.btnApply.Margin = new System.Windows.Forms.Padding(1);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(198, 26);
            this.btnApply.TabIndex = 237;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tbStationName
            // 
            this.tbStationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStationName.Location = new System.Drawing.Point(101, 1);
            this.tbStationName.Margin = new System.Windows.Forms.Padding(1);
            this.tbStationName.Name = "tbStationName";
            this.tbStationName.Size = new System.Drawing.Size(98, 26);
            this.tbStationName.TabIndex = 232;
            this.tbStationName.Text = "Station1";
            // 
            // lb_CurrentStationRecipe
            // 
            this.lb_CurrentStationRecipe.AutoSize = true;
            this.lb_CurrentStationRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CurrentStationRecipe.Location = new System.Drawing.Point(601, 1);
            this.lb_CurrentStationRecipe.Margin = new System.Windows.Forms.Padding(1);
            this.lb_CurrentStationRecipe.Name = "lb_CurrentStationRecipe";
            this.lb_CurrentStationRecipe.Size = new System.Drawing.Size(98, 26);
            this.lb_CurrentStationRecipe.TabIndex = 239;
            this.lb_CurrentStationRecipe.Text = "当前配方:";
            this.lb_CurrentStationRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_StationIndex
            // 
            this.lb_StationIndex.AutoSize = true;
            this.lb_StationIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_StationIndex.Location = new System.Drawing.Point(201, 1);
            this.lb_StationIndex.Margin = new System.Windows.Forms.Padding(1);
            this.lb_StationIndex.Name = "lb_StationIndex";
            this.lb_StationIndex.Size = new System.Drawing.Size(98, 26);
            this.lb_StationIndex.TabIndex = 233;
            this.lb_StationIndex.Text = "工站序号:";
            this.lb_StationIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbStationIndex
            // 
            this.tbStationIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStationIndex.Location = new System.Drawing.Point(301, 1);
            this.tbStationIndex.Margin = new System.Windows.Forms.Padding(1);
            this.tbStationIndex.Name = "tbStationIndex";
            this.tbStationIndex.Size = new System.Drawing.Size(98, 26);
            this.tbStationIndex.TabIndex = 234;
            this.tbStationIndex.Text = "0";
            // 
            // lb_StationInfo
            // 
            this.lb_StationInfo.AutoSize = true;
            this.lb_StationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_StationInfo.Location = new System.Drawing.Point(401, 1);
            this.lb_StationInfo.Margin = new System.Windows.Forms.Padding(1);
            this.lb_StationInfo.Name = "lb_StationInfo";
            this.lb_StationInfo.Size = new System.Drawing.Size(98, 26);
            this.lb_StationInfo.TabIndex = 235;
            this.lb_StationInfo.Text = "工站描述:";
            this.lb_StationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbStationDescription
            // 
            this.tbStationDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStationDescription.Location = new System.Drawing.Point(501, 1);
            this.tbStationDescription.Margin = new System.Windows.Forms.Padding(1);
            this.tbStationDescription.Name = "tbStationDescription";
            this.tbStationDescription.Size = new System.Drawing.Size(98, 26);
            this.tbStationDescription.TabIndex = 236;
            this.tbStationDescription.Text = "Station1";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpMain);
            this.tabMain.Controls.Add(this.tpVariable);
            this.tabMain.Controls.Add(this.tpOutputUI);
            this.tabMain.Controls.Add(this.tpRtVals);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(3, 31);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(994, 666);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.tlpConfig);
            this.tpMain.Location = new System.Drawing.Point(4, 26);
            this.tpMain.Name = "tpMain";
            this.tpMain.Size = new System.Drawing.Size(986, 636);
            this.tpMain.TabIndex = 4;
            this.tpMain.Text = "主配置";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // tlpConfig
            // 
            this.tlpConfig.ColumnCount = 3;
            this.tlpConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpConfig.Controls.Add(this.tlpRecipeInfo, 2, 2);
            this.tlpConfig.Controls.Add(this.tlpTask, 2, 0);
            this.tlpConfig.Controls.Add(this.tlpStationButton, 0, 0);
            this.tlpConfig.Controls.Add(this.tlpRecipe, 1, 0);
            this.tlpConfig.Controls.Add(this.tlpRecipeButton, 0, 3);
            this.tlpConfig.Controls.Add(this.dgvRecipes, 0, 1);
            this.tlpConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConfig.Location = new System.Drawing.Point(0, 0);
            this.tlpConfig.Margin = new System.Windows.Forms.Padding(0);
            this.tlpConfig.Name = "tlpConfig";
            this.tlpConfig.RowCount = 4;
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpConfig.Size = new System.Drawing.Size(986, 636);
            this.tlpConfig.TabIndex = 0;
            // 
            // tlpRecipeInfo
            // 
            this.tlpRecipeInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpRecipeInfo.ColumnCount = 1;
            this.tlpRecipeInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipeInfo.Controls.Add(this.lb_SelectRecipeInfo, 0, 0);
            this.tlpRecipeInfo.Controls.Add(this.rtbRecipe, 0, 1);
            this.tlpRecipeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipeInfo.Location = new System.Drawing.Point(591, 339);
            this.tlpRecipeInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRecipeInfo.Name = "tlpRecipeInfo";
            this.tlpRecipeInfo.RowCount = 2;
            this.tlpConfig.SetRowSpan(this.tlpRecipeInfo, 2);
            this.tlpRecipeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpRecipeInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipeInfo.Size = new System.Drawing.Size(395, 297);
            this.tlpRecipeInfo.TabIndex = 25;
            this.tlpRecipeInfo.TagString = null;
            // 
            // lb_SelectRecipeInfo
            // 
            this.lb_SelectRecipeInfo.BackColor = System.Drawing.Color.White;
            this.lb_SelectRecipeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_SelectRecipeInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SelectRecipeInfo.Location = new System.Drawing.Point(2, 2);
            this.lb_SelectRecipeInfo.Margin = new System.Windows.Forms.Padding(1);
            this.lb_SelectRecipeInfo.Name = "lb_SelectRecipeInfo";
            this.lb_SelectRecipeInfo.Size = new System.Drawing.Size(391, 28);
            this.lb_SelectRecipeInfo.TabIndex = 0;
            this.lb_SelectRecipeInfo.Text = "选中的配方信息";
            this.lb_SelectRecipeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_SelectRecipeInfo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // rtbRecipe
            // 
            this.rtbRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRecipe.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbRecipe.Location = new System.Drawing.Point(2, 33);
            this.rtbRecipe.Margin = new System.Windows.Forms.Padding(1);
            this.rtbRecipe.Name = "rtbRecipe";
            this.rtbRecipe.ReadOnly = true;
            this.rtbRecipe.Size = new System.Drawing.Size(391, 262);
            this.rtbRecipe.TabIndex = 24;
            this.rtbRecipe.Text = "2019-02-02 12:12:11";
            // 
            // tlpTask
            // 
            this.tlpTask.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpTask.ColumnCount = 6;
            this.tlpTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpTask.Controls.Add(this.btnTaskDown, 5, 1);
            this.tlpTask.Controls.Add(this.btnTaskUp, 4, 1);
            this.tlpTask.Controls.Add(this.cmbTasks, 0, 1);
            this.tlpTask.Controls.Add(this.btnRemoveTask, 2, 1);
            this.tlpTask.Controls.Add(this.btnAddTask, 1, 1);
            this.tlpTask.Controls.Add(this.btnRefreshTasks, 3, 1);
            this.tlpTask.Controls.Add(this.lb_Task, 0, 0);
            this.tlpTask.Controls.Add(this.tlpButton, 0, 3);
            this.tlpTask.Controls.Add(this.dgvTasks, 0, 2);
            this.tlpTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTask.Location = new System.Drawing.Point(591, 0);
            this.tlpTask.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTask.Name = "tlpTask";
            this.tlpTask.RowCount = 4;
            this.tlpConfig.SetRowSpan(this.tlpTask, 2);
            this.tlpTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTask.Size = new System.Drawing.Size(395, 339);
            this.tlpTask.TabIndex = 23;
            this.tlpTask.TagString = null;
            // 
            // btnTaskDown
            // 
            this.btnTaskDown.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Down;
            this.btnTaskDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTaskDown.Location = new System.Drawing.Point(215, 37);
            this.btnTaskDown.Margin = new System.Windows.Forms.Padding(1);
            this.btnTaskDown.Name = "btnTaskDown";
            this.btnTaskDown.Size = new System.Drawing.Size(33, 28);
            this.btnTaskDown.TabIndex = 10;
            this.btnTaskDown.UseVisualStyleBackColor = true;
            this.btnTaskDown.Click += new System.EventHandler(this.btnTaskDown_Click);
            // 
            // btnTaskUp
            // 
            this.btnTaskUp.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Up;
            this.btnTaskUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTaskUp.Location = new System.Drawing.Point(179, 37);
            this.btnTaskUp.Margin = new System.Windows.Forms.Padding(1);
            this.btnTaskUp.Name = "btnTaskUp";
            this.btnTaskUp.Size = new System.Drawing.Size(32, 28);
            this.btnTaskUp.TabIndex = 9;
            this.btnTaskUp.UseVisualStyleBackColor = true;
            this.btnTaskUp.Click += new System.EventHandler(this.btnTaskUp_Click);
            // 
            // cmbTasks
            // 
            this.cmbTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTasks.FormattingEnabled = true;
            this.cmbTasks.Location = new System.Drawing.Point(2, 37);
            this.cmbTasks.Margin = new System.Windows.Forms.Padding(1);
            this.cmbTasks.Name = "cmbTasks";
            this.cmbTasks.Size = new System.Drawing.Size(66, 25);
            this.cmbTasks.TabIndex = 4;
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_2;
            this.btnRemoveTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveTask.Location = new System.Drawing.Point(107, 37);
            this.btnRemoveTask.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(32, 28);
            this.btnRemoveTask.TabIndex = 7;
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Add_2;
            this.btnAddTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddTask.Location = new System.Drawing.Point(71, 37);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(32, 28);
            this.btnAddTask.TabIndex = 6;
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnRefreshTasks
            // 
            this.btnRefreshTasks.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Refresh_1;
            this.btnRefreshTasks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshTasks.Location = new System.Drawing.Point(143, 37);
            this.btnRefreshTasks.Margin = new System.Windows.Forms.Padding(1);
            this.btnRefreshTasks.Name = "btnRefreshTasks";
            this.btnRefreshTasks.Size = new System.Drawing.Size(32, 28);
            this.btnRefreshTasks.TabIndex = 5;
            this.btnRefreshTasks.UseVisualStyleBackColor = true;
            this.btnRefreshTasks.Click += new System.EventHandler(this.btnRefreshTasks_Click);
            // 
            // lb_Task
            // 
            this.lb_Task.BackColor = System.Drawing.Color.White;
            this.tlpTask.SetColumnSpan(this.lb_Task, 6);
            this.lb_Task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Task.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Task.Location = new System.Drawing.Point(2, 2);
            this.lb_Task.Margin = new System.Windows.Forms.Padding(1);
            this.lb_Task.Name = "lb_Task";
            this.lb_Task.Size = new System.Drawing.Size(391, 32);
            this.lb_Task.TabIndex = 0;
            this.lb_Task.Text = "任务";
            this.lb_Task.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Task.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpButton
            // 
            this.tlpButton.ColumnCount = 2;
            this.tlpTask.SetColumnSpan(this.tlpButton, 6);
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButton.Controls.Add(this.btnDispose, 0, 0);
            this.tlpButton.Controls.Add(this.btnInit, 1, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(4, 301);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpButton.Size = new System.Drawing.Size(387, 34);
            this.tlpButton.TabIndex = 11;
            this.tlpButton.TagString = null;
            // 
            // btnDispose
            // 
            this.btnDispose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDispose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDispose.Location = new System.Drawing.Point(15, 3);
            this.btnDispose.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.btnDispose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(163, 28);
            this.btnDispose.Symbol = 61453;
            this.btnDispose.TabIndex = 0;
            this.btnDispose.Text = "释放任务";
            this.btnDispose.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDispose.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            // 
            // btnInit
            // 
            this.btnInit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInit.Location = new System.Drawing.Point(208, 3);
            this.btnInit.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.btnInit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(164, 28);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "加载任务";
            this.btnInit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // dgvTasks
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvTasks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTasks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvTasks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTasks.ColumnHeadersHeight = 32;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.TaskStatup});
            this.tlpTask.SetColumnSpan(this.dgvTasks, 6);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTasks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.EnableHeadersVisualStyles = false;
            this.dgvTasks.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvTasks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvTasks.Location = new System.Drawing.Point(4, 71);
            this.dgvTasks.Name = "dgvTasks";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTasks.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvTasks.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTasks.RowTemplate.Height = 23;
            this.dgvTasks.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvTasks.SelectedIndex = -1;
            this.dgvTasks.Size = new System.Drawing.Size(387, 223);
            this.dgvTasks.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.dgvTasks.TabIndex = 12;
            this.dgvTasks.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvTasks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasks_CellContentClick);
            // 
            // TaskName
            // 
            this.TaskName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaskName.HeaderText = "Name";
            this.TaskName.MinimumWidth = 8;
            this.TaskName.Name = "TaskName";
            this.TaskName.ReadOnly = true;
            this.TaskName.Width = 200;
            // 
            // TaskStatup
            // 
            this.TaskStatup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaskStatup.HeaderText = "Statup";
            this.TaskStatup.MinimumWidth = 8;
            this.TaskStatup.Name = "TaskStatup";
            this.TaskStatup.Width = 150;
            // 
            // tlpStationButton
            // 
            this.tlpStationButton.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpStationButton.ColumnCount = 2;
            this.tlpStationButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStationButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStationButton.Controls.Add(this.tbEventInfo3, 1, 3);
            this.tlpStationButton.Controls.Add(this.tbEventInfo2, 1, 2);
            this.tlpStationButton.Controls.Add(this.tbEventInfo1, 1, 1);
            this.tlpStationButton.Controls.Add(this.chkEventEnable1, 0, 1);
            this.tlpStationButton.Controls.Add(this.chkEventEnable2, 0, 2);
            this.tlpStationButton.Controls.Add(this.chkEventEnable3, 0, 3);
            this.tlpStationButton.Controls.Add(this.lb_StationButton, 0, 0);
            this.tlpStationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStationButton.Location = new System.Drawing.Point(1, 1);
            this.tlpStationButton.Margin = new System.Windows.Forms.Padding(1);
            this.tlpStationButton.Name = "tlpStationButton";
            this.tlpStationButton.RowCount = 4;
            this.tlpStationButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpStationButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpStationButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpStationButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpStationButton.Size = new System.Drawing.Size(244, 137);
            this.tlpStationButton.TabIndex = 20;
            this.tlpStationButton.TagString = null;
            // 
            // tbEventInfo3
            // 
            this.tbEventInfo3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEventInfo3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbEventInfo3.Location = new System.Drawing.Point(123, 101);
            this.tbEventInfo3.Margin = new System.Windows.Forms.Padding(1);
            this.tbEventInfo3.Name = "tbEventInfo3";
            this.tbEventInfo3.Size = new System.Drawing.Size(119, 29);
            this.tbEventInfo3.TabIndex = 5;
            // 
            // tbEventInfo2
            // 
            this.tbEventInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEventInfo2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbEventInfo2.Location = new System.Drawing.Point(123, 69);
            this.tbEventInfo2.Margin = new System.Windows.Forms.Padding(1);
            this.tbEventInfo2.Name = "tbEventInfo2";
            this.tbEventInfo2.Size = new System.Drawing.Size(119, 29);
            this.tbEventInfo2.TabIndex = 3;
            // 
            // tbEventInfo1
            // 
            this.tbEventInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEventInfo1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbEventInfo1.Location = new System.Drawing.Point(123, 37);
            this.tbEventInfo1.Margin = new System.Windows.Forms.Padding(1);
            this.tbEventInfo1.Name = "tbEventInfo1";
            this.tbEventInfo1.Size = new System.Drawing.Size(119, 29);
            this.tbEventInfo1.TabIndex = 1;
            // 
            // chkEventEnable1
            // 
            this.chkEventEnable1.AutoSize = true;
            this.chkEventEnable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEventEnable1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEventEnable1.Location = new System.Drawing.Point(2, 37);
            this.chkEventEnable1.Margin = new System.Windows.Forms.Padding(1);
            this.chkEventEnable1.Name = "chkEventEnable1";
            this.chkEventEnable1.Size = new System.Drawing.Size(118, 29);
            this.chkEventEnable1.TabIndex = 0;
            this.chkEventEnable1.Text = "工站按钮1";
            this.chkEventEnable1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEventEnable1.UseVisualStyleBackColor = true;
            // 
            // chkEventEnable2
            // 
            this.chkEventEnable2.AutoSize = true;
            this.chkEventEnable2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEventEnable2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEventEnable2.Location = new System.Drawing.Point(2, 69);
            this.chkEventEnable2.Margin = new System.Windows.Forms.Padding(1);
            this.chkEventEnable2.Name = "chkEventEnable2";
            this.chkEventEnable2.Size = new System.Drawing.Size(118, 29);
            this.chkEventEnable2.TabIndex = 2;
            this.chkEventEnable2.Text = "工站按钮2";
            this.chkEventEnable2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEventEnable2.UseVisualStyleBackColor = true;
            // 
            // chkEventEnable3
            // 
            this.chkEventEnable3.AutoSize = true;
            this.chkEventEnable3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEventEnable3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEventEnable3.Location = new System.Drawing.Point(2, 101);
            this.chkEventEnable3.Margin = new System.Windows.Forms.Padding(1);
            this.chkEventEnable3.Name = "chkEventEnable3";
            this.chkEventEnable3.Size = new System.Drawing.Size(118, 34);
            this.chkEventEnable3.TabIndex = 4;
            this.chkEventEnable3.Text = "工站按钮3";
            this.chkEventEnable3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEventEnable3.UseVisualStyleBackColor = true;
            // 
            // lb_StationButton
            // 
            this.lb_StationButton.BackColor = System.Drawing.Color.White;
            this.tlpStationButton.SetColumnSpan(this.lb_StationButton, 2);
            this.lb_StationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_StationButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_StationButton.Location = new System.Drawing.Point(2, 2);
            this.lb_StationButton.Margin = new System.Windows.Forms.Padding(1);
            this.lb_StationButton.Name = "lb_StationButton";
            this.lb_StationButton.Size = new System.Drawing.Size(240, 32);
            this.lb_StationButton.TabIndex = 6;
            this.lb_StationButton.Text = "工站按钮";
            this.lb_StationButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_StationButton.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpRecipe
            // 
            this.tlpRecipe.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpRecipe.ColumnCount = 6;
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpRecipe.Controls.Add(this.btnRecipeElesConfig, 3, 3);
            this.tlpRecipe.Controls.Add(this.cmbRtVals, 4, 2);
            this.tlpRecipe.Controls.Add(this.lb_RecipeInfo, 0, 0);
            this.tlpRecipe.Controls.Add(this.cmbMainGui, 2, 2);
            this.tlpRecipe.Controls.Add(this.cmbVariableSel, 0, 2);
            this.tlpRecipe.Controls.Add(this.lb_CommonParam, 0, 1);
            this.tlpRecipe.Controls.Add(this.lb_MainGUI, 2, 1);
            this.tlpRecipe.Controls.Add(this.lb_RtValue, 4, 1);
            this.tlpRecipe.Controls.Add(this.btnRecipePrimsConfig, 0, 3);
            this.tlpRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipe.Location = new System.Drawing.Point(246, 0);
            this.tlpRecipe.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRecipe.Name = "tlpRecipe";
            this.tlpRecipe.RowCount = 4;
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpRecipe.Size = new System.Drawing.Size(345, 139);
            this.tlpRecipe.TabIndex = 21;
            this.tlpRecipe.TagString = null;
            // 
            // btnRecipeElesConfig
            // 
            this.tlpRecipe.SetColumnSpan(this.btnRecipeElesConfig, 3);
            this.btnRecipeElesConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipeElesConfig.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecipeElesConfig.Location = new System.Drawing.Point(173, 101);
            this.btnRecipeElesConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnRecipeElesConfig.Name = "btnRecipeElesConfig";
            this.btnRecipeElesConfig.Size = new System.Drawing.Size(170, 36);
            this.btnRecipeElesConfig.TabIndex = 23;
            this.btnRecipeElesConfig.Text = "元件配置";
            this.btnRecipeElesConfig.UseVisualStyleBackColor = true;
            this.btnRecipeElesConfig.Click += new System.EventHandler(this.btnRecipeElesConfig_Click);
            // 
            // cmbRtVals
            // 
            this.tlpRecipe.SetColumnSpan(this.cmbRtVals, 2);
            this.cmbRtVals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRtVals.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbRtVals.FormattingEnabled = true;
            this.cmbRtVals.Location = new System.Drawing.Point(230, 69);
            this.cmbRtVals.Margin = new System.Windows.Forms.Padding(1);
            this.cmbRtVals.Name = "cmbRtVals";
            this.cmbRtVals.Size = new System.Drawing.Size(113, 29);
            this.cmbRtVals.TabIndex = 1;
            // 
            // lb_RecipeInfo
            // 
            this.lb_RecipeInfo.BackColor = System.Drawing.Color.White;
            this.tlpRecipe.SetColumnSpan(this.lb_RecipeInfo, 6);
            this.lb_RecipeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_RecipeInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_RecipeInfo.Location = new System.Drawing.Point(2, 2);
            this.lb_RecipeInfo.Margin = new System.Windows.Forms.Padding(1);
            this.lb_RecipeInfo.Name = "lb_RecipeInfo";
            this.lb_RecipeInfo.Size = new System.Drawing.Size(341, 32);
            this.lb_RecipeInfo.TabIndex = 0;
            this.lb_RecipeInfo.Text = "配方相关";
            this.lb_RecipeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_RecipeInfo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmbMainGui
            // 
            this.tlpRecipe.SetColumnSpan(this.cmbMainGui, 2);
            this.cmbMainGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMainGui.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbMainGui.FormattingEnabled = true;
            this.cmbMainGui.Location = new System.Drawing.Point(116, 69);
            this.cmbMainGui.Margin = new System.Windows.Forms.Padding(1);
            this.cmbMainGui.Name = "cmbMainGui";
            this.cmbMainGui.Size = new System.Drawing.Size(111, 29);
            this.cmbMainGui.TabIndex = 1;
            // 
            // cmbVariableSel
            // 
            this.tlpRecipe.SetColumnSpan(this.cmbVariableSel, 2);
            this.cmbVariableSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbVariableSel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbVariableSel.FormattingEnabled = true;
            this.cmbVariableSel.Location = new System.Drawing.Point(2, 69);
            this.cmbVariableSel.Margin = new System.Windows.Forms.Padding(1);
            this.cmbVariableSel.Name = "cmbVariableSel";
            this.cmbVariableSel.Size = new System.Drawing.Size(111, 29);
            this.cmbVariableSel.TabIndex = 1;
            // 
            // lb_CommonParam
            // 
            this.lb_CommonParam.BackColor = System.Drawing.Color.White;
            this.tlpRecipe.SetColumnSpan(this.lb_CommonParam, 2);
            this.lb_CommonParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CommonParam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_CommonParam.Location = new System.Drawing.Point(2, 37);
            this.lb_CommonParam.Margin = new System.Windows.Forms.Padding(1);
            this.lb_CommonParam.Name = "lb_CommonParam";
            this.lb_CommonParam.Size = new System.Drawing.Size(111, 29);
            this.lb_CommonParam.TabIndex = 2;
            this.lb_CommonParam.Text = "全局变量";
            this.lb_CommonParam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_CommonParam.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_MainGUI
            // 
            this.lb_MainGUI.BackColor = System.Drawing.Color.White;
            this.tlpRecipe.SetColumnSpan(this.lb_MainGUI, 2);
            this.lb_MainGUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_MainGUI.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_MainGUI.Location = new System.Drawing.Point(116, 37);
            this.lb_MainGUI.Margin = new System.Windows.Forms.Padding(1);
            this.lb_MainGUI.Name = "lb_MainGUI";
            this.lb_MainGUI.Size = new System.Drawing.Size(111, 29);
            this.lb_MainGUI.TabIndex = 2;
            this.lb_MainGUI.Text = "主界面";
            this.lb_MainGUI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_MainGUI.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_RtValue
            // 
            this.lb_RtValue.BackColor = System.Drawing.Color.White;
            this.tlpRecipe.SetColumnSpan(this.lb_RtValue, 2);
            this.lb_RtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_RtValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_RtValue.Location = new System.Drawing.Point(230, 37);
            this.lb_RtValue.Margin = new System.Windows.Forms.Padding(1);
            this.lb_RtValue.Name = "lb_RtValue";
            this.lb_RtValue.Size = new System.Drawing.Size(113, 29);
            this.lb_RtValue.TabIndex = 2;
            this.lb_RtValue.Text = "实时变量";
            this.lb_RtValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_RtValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnRecipePrimsConfig
            // 
            this.tlpRecipe.SetColumnSpan(this.btnRecipePrimsConfig, 3);
            this.btnRecipePrimsConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipePrimsConfig.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecipePrimsConfig.Location = new System.Drawing.Point(2, 101);
            this.btnRecipePrimsConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnRecipePrimsConfig.Name = "btnRecipePrimsConfig";
            this.btnRecipePrimsConfig.Size = new System.Drawing.Size(168, 36);
            this.btnRecipePrimsConfig.TabIndex = 22;
            this.btnRecipePrimsConfig.Text = "基元配置";
            this.btnRecipePrimsConfig.UseVisualStyleBackColor = true;
            this.btnRecipePrimsConfig.Click += new System.EventHandler(this.btnRecipePrimsConfig_Click);
            // 
            // tlpRecipeButton
            // 
            this.tlpRecipeButton.ColumnCount = 5;
            this.tlpConfig.SetColumnSpan(this.tlpRecipeButton, 2);
            this.tlpRecipeButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeButton.Controls.Add(this.btnDeleteRecipe, 4, 0);
            this.tlpRecipeButton.Controls.Add(this.btnRecipeUpload, 3, 0);
            this.tlpRecipeButton.Controls.Add(this.btnSelect, 2, 0);
            this.tlpRecipeButton.Controls.Add(this.btnEdit, 1, 0);
            this.tlpRecipeButton.Controls.Add(this.btnCreateRecipe, 0, 0);
            this.tlpRecipeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipeButton.Location = new System.Drawing.Point(0, 589);
            this.tlpRecipeButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRecipeButton.Name = "tlpRecipeButton";
            this.tlpRecipeButton.RowCount = 1;
            this.tlpRecipeButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipeButton.Size = new System.Drawing.Size(591, 47);
            this.tlpRecipeButton.TabIndex = 22;
            this.tlpRecipeButton.TagString = null;
            // 
            // btnDeleteRecipe
            // 
            this.btnDeleteRecipe.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDeleteRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteRecipe.Location = new System.Drawing.Point(473, 1);
            this.btnDeleteRecipe.Margin = new System.Windows.Forms.Padding(1);
            this.btnDeleteRecipe.Name = "btnDeleteRecipe";
            this.btnDeleteRecipe.Size = new System.Drawing.Size(117, 45);
            this.btnDeleteRecipe.TabIndex = 4;
            this.btnDeleteRecipe.Text = "删除选中的配方";
            this.btnDeleteRecipe.UseVisualStyleBackColor = false;
            this.btnDeleteRecipe.Click += new System.EventHandler(this.btnDeleteRecipe_Click);
            // 
            // btnRecipeUpload
            // 
            this.btnRecipeUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipeUpload.Location = new System.Drawing.Point(355, 1);
            this.btnRecipeUpload.Margin = new System.Windows.Forms.Padding(1);
            this.btnRecipeUpload.Name = "btnRecipeUpload";
            this.btnRecipeUpload.Size = new System.Drawing.Size(116, 45);
            this.btnRecipeUpload.TabIndex = 3;
            this.btnRecipeUpload.Text = "上传配方列表";
            this.btnRecipeUpload.UseVisualStyleBackColor = true;
            this.btnRecipeUpload.Click += new System.EventHandler(this.btnRecipeUpload_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelect.Location = new System.Drawing.Point(237, 1);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(1);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(116, 45);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选择配方";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(119, 1);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(116, 45);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑配方";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreateRecipe
            // 
            this.btnCreateRecipe.BackColor = System.Drawing.Color.LawnGreen;
            this.btnCreateRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateRecipe.Location = new System.Drawing.Point(1, 1);
            this.btnCreateRecipe.Margin = new System.Windows.Forms.Padding(1);
            this.btnCreateRecipe.Name = "btnCreateRecipe";
            this.btnCreateRecipe.Size = new System.Drawing.Size(116, 45);
            this.btnCreateRecipe.TabIndex = 0;
            this.btnCreateRecipe.Text = "新建配方";
            this.btnCreateRecipe.UseVisualStyleBackColor = false;
            this.btnCreateRecipe.Click += new System.EventHandler(this.btnCreateRecipe_Click);
            // 
            // dgvRecipes
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvRecipes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRecipes.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecipes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecipes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRecipes.ColumnHeadersHeight = 32;
            this.dgvRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecipes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colCreator,
            this.colCreatTime,
            this.colEditTime});
            this.tlpConfig.SetColumnSpan(this.dgvRecipes, 2);
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecipes.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecipes.EnableHeadersVisualStyles = false;
            this.dgvRecipes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvRecipes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvRecipes.Location = new System.Drawing.Point(5, 144);
            this.dgvRecipes.Margin = new System.Windows.Forms.Padding(5);
            this.dgvRecipes.Name = "dgvRecipes";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecipes.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRecipes.RowHeadersWidth = 62;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvRecipes.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.tlpConfig.SetRowSpan(this.dgvRecipes, 2);
            this.dgvRecipes.RowTemplate.Height = 23;
            this.dgvRecipes.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvRecipes.SelectedIndex = -1;
            this.dgvRecipes.Size = new System.Drawing.Size(581, 440);
            this.dgvRecipes.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvRecipes.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.dgvRecipes.TabIndex = 26;
            this.dgvRecipes.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvRecipes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecipes_CellContentClick);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colName.HeaderText = "配方名称";
            this.colName.MinimumWidth = 8;
            this.colName.Name = "colName";
            this.colName.Width = 120;
            // 
            // colCreator
            // 
            this.colCreator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCreator.HeaderText = "创建者";
            this.colCreator.MinimumWidth = 8;
            this.colCreator.Name = "colCreator";
            this.colCreator.Width = 120;
            // 
            // colCreatTime
            // 
            this.colCreatTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCreatTime.HeaderText = "创建时间";
            this.colCreatTime.MinimumWidth = 8;
            this.colCreatTime.Name = "colCreatTime";
            this.colCreatTime.Width = 150;
            // 
            // colEditTime
            // 
            this.colEditTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEditTime.HeaderText = "编辑时间";
            this.colEditTime.MinimumWidth = 8;
            this.colEditTime.Name = "colEditTime";
            this.colEditTime.Width = 150;
            // 
            // tpVariable
            // 
            this.tpVariable.Controls.Add(this.tlpVariable);
            this.tpVariable.Location = new System.Drawing.Point(4, 26);
            this.tpVariable.Name = "tpVariable";
            this.tpVariable.Padding = new System.Windows.Forms.Padding(3);
            this.tpVariable.Size = new System.Drawing.Size(986, 636);
            this.tpVariable.TabIndex = 1;
            this.tpVariable.Text = "全局变量";
            this.tpVariable.UseVisualStyleBackColor = true;
            // 
            // tlpVariable
            // 
            this.tlpVariable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tlpVariable.ColumnCount = 1;
            this.tlpVariable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVariable.Controls.Add(this.tsDataInfo, 0, 0);
            this.tlpVariable.Controls.Add(this.dgvDataInfo, 0, 1);
            this.tlpVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVariable.Location = new System.Drawing.Point(3, 3);
            this.tlpVariable.Name = "tlpVariable";
            this.tlpVariable.Padding = new System.Windows.Forms.Padding(1);
            this.tlpVariable.RowCount = 3;
            this.tlpVariable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpVariable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVariable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVariable.Size = new System.Drawing.Size(980, 630);
            this.tlpVariable.TabIndex = 3;
            this.tlpVariable.TagString = null;
            // 
            // tsDataInfo
            // 
            this.tsDataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsDataInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsDataInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsDataInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_DataInfo,
            this.tsCmbDataInfo,
            this.toolStripSeparator1,
            this.tsAddDataInfo,
            this.tsDelDataInfo,
            this.tsDataInfoStartMonitor,
            this.tsDataInfoStopMonitor});
            this.tsDataInfo.Location = new System.Drawing.Point(5, 5);
            this.tsDataInfo.Margin = new System.Windows.Forms.Padding(1);
            this.tsDataInfo.Name = "tsDataInfo";
            this.tsDataInfo.Size = new System.Drawing.Size(970, 28);
            this.tsDataInfo.TabIndex = 0;
            this.tsDataInfo.Text = "toolStrip1";
            // 
            // tsl_DataInfo
            // 
            this.tsl_DataInfo.Name = "tsl_DataInfo";
            this.tsl_DataInfo.Size = new System.Drawing.Size(85, 25);
            this.tsl_DataInfo.Text = "全局变量表：";
            // 
            // tsCmbDataInfo
            // 
            this.tsCmbDataInfo.Name = "tsCmbDataInfo";
            this.tsCmbDataInfo.Size = new System.Drawing.Size(121, 28);
            this.tsCmbDataInfo.ToolTipText = "选择变量表";
            this.tsCmbDataInfo.SelectedIndexChanged += new System.EventHandler(this.tsCmbDataInfo_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tsAddDataInfo
            // 
            this.tsAddDataInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAddDataInfo.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Add_1;
            this.tsAddDataInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddDataInfo.Name = "tsAddDataInfo";
            this.tsAddDataInfo.Size = new System.Drawing.Size(24, 25);
            this.tsAddDataInfo.Text = "toolStripButton2";
            this.tsAddDataInfo.ToolTipText = "添加变量";
            this.tsAddDataInfo.Click += new System.EventHandler(this.tsAddDataInfo_Click);
            // 
            // tsDelDataInfo
            // 
            this.tsDelDataInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelDataInfo.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_1;
            this.tsDelDataInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelDataInfo.Name = "tsDelDataInfo";
            this.tsDelDataInfo.Size = new System.Drawing.Size(24, 25);
            this.tsDelDataInfo.Text = "toolStripButton3";
            this.tsDelDataInfo.ToolTipText = "删除变量";
            this.tsDelDataInfo.Click += new System.EventHandler(this.tsDelDataInfo_Click);
            // 
            // tsDataInfoStartMonitor
            // 
            this.tsDataInfoStartMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.tsDataInfoStartMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDataInfoStartMonitor.Image = global::Lead.CPrim.StationCommon.Properties.Resources.StartMonitor;
            this.tsDataInfoStartMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDataInfoStartMonitor.Name = "tsDataInfoStartMonitor";
            this.tsDataInfoStartMonitor.Size = new System.Drawing.Size(24, 25);
            this.tsDataInfoStartMonitor.Text = "toolStripButton4";
            this.tsDataInfoStartMonitor.ToolTipText = "开始监控";
            this.tsDataInfoStartMonitor.Click += new System.EventHandler(this.tsDataInfoStartMonitor_Click);
            // 
            // tsDataInfoStopMonitor
            // 
            this.tsDataInfoStopMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDataInfoStopMonitor.Image = global::Lead.CPrim.StationCommon.Properties.Resources.StopMonitor;
            this.tsDataInfoStopMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDataInfoStopMonitor.Name = "tsDataInfoStopMonitor";
            this.tsDataInfoStopMonitor.Size = new System.Drawing.Size(24, 25);
            this.tsDataInfoStopMonitor.Text = "toolStripButton5";
            this.tsDataInfoStopMonitor.ToolTipText = "停止监控";
            this.tsDataInfoStopMonitor.Click += new System.EventHandler(this.tsDataInfoStopMonitor_Click);
            // 
            // dgvDataInfo
            // 
            this.dgvDataInfo.AllowUserToAddRows = false;
            this.dgvDataInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDtName,
            this.colDtType,
            this.colDtValue,
            this.colDtInputVal,
            this.colDtInput,
            this.colDtSave});
            this.dgvDataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataInfo.Location = new System.Drawing.Point(5, 38);
            this.dgvDataInfo.Margin = new System.Windows.Forms.Padding(1);
            this.dgvDataInfo.Name = "dgvDataInfo";
            this.dgvDataInfo.RowHeadersWidth = 51;
            this.tlpVariable.SetRowSpan(this.dgvDataInfo, 2);
            this.dgvDataInfo.RowTemplate.Height = 27;
            this.dgvDataInfo.Size = new System.Drawing.Size(970, 587);
            this.dgvDataInfo.TabIndex = 2;
            this.dgvDataInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataInfo_CellContentClick);
            this.dgvDataInfo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataInfo_CellEnter);
            this.dgvDataInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataInfo_CellValueChanged);
            this.dgvDataInfo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDataInfo_CurrentCellDirtyStateChanged);
            this.dgvDataInfo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDataInfo_EditingControlShowing);
            // 
            // colDtName
            // 
            this.colDtName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDtName.FillWeight = 243.6548F;
            this.colDtName.HeaderText = "变量名";
            this.colDtName.MinimumWidth = 6;
            this.colDtName.Name = "colDtName";
            this.colDtName.Width = 200;
            // 
            // colDtType
            // 
            this.colDtType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDtType.FillWeight = 167.9685F;
            this.colDtType.HeaderText = "变量类型";
            this.colDtType.MinimumWidth = 6;
            this.colDtType.Name = "colDtType";
            this.colDtType.Width = 80;
            // 
            // colDtValue
            // 
            this.colDtValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDtValue.FillWeight = 40.73236F;
            this.colDtValue.HeaderText = "当前值";
            this.colDtValue.MinimumWidth = 6;
            this.colDtValue.Name = "colDtValue";
            this.colDtValue.Width = 300;
            // 
            // colDtInputVal
            // 
            this.colDtInputVal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDtInputVal.FillWeight = 40.73236F;
            this.colDtInputVal.HeaderText = "更改值";
            this.colDtInputVal.MinimumWidth = 6;
            this.colDtInputVal.Name = "colDtInputVal";
            this.colDtInputVal.Width = 300;
            // 
            // colDtInput
            // 
            this.colDtInput.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDtInput.FillWeight = 40.73236F;
            this.colDtInput.HeaderText = "更改";
            this.colDtInput.MinimumWidth = 6;
            this.colDtInput.Name = "colDtInput";
            this.colDtInput.Width = 80;
            // 
            // colDtSave
            // 
            this.colDtSave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDtSave.FillWeight = 66.17959F;
            this.colDtSave.HeaderText = "掉电保持";
            this.colDtSave.MinimumWidth = 6;
            this.colDtSave.Name = "colDtSave";
            this.colDtSave.Width = 80;
            // 
            // tpOutputUI
            // 
            this.tpOutputUI.Controls.Add(this.tlpMainUi);
            this.tpOutputUI.Location = new System.Drawing.Point(4, 26);
            this.tpOutputUI.Name = "tpOutputUI";
            this.tpOutputUI.Size = new System.Drawing.Size(986, 636);
            this.tpOutputUI.TabIndex = 2;
            this.tpOutputUI.Text = "主界面";
            this.tpOutputUI.UseVisualStyleBackColor = true;
            // 
            // tlpMainUi
            // 
            this.tlpMainUi.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tlpMainUi.ColumnCount = 1;
            this.tlpMainUi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainUi.Controls.Add(this.tabDisplayConfigs, 0, 1);
            this.tlpMainUi.Controls.Add(this.tsMainUiConfig, 0, 0);
            this.tlpMainUi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainUi.Location = new System.Drawing.Point(0, 0);
            this.tlpMainUi.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMainUi.Name = "tlpMainUi";
            this.tlpMainUi.RowCount = 2;
            this.tlpMainUi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMainUi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainUi.Size = new System.Drawing.Size(986, 636);
            this.tlpMainUi.TabIndex = 3;
            this.tlpMainUi.TagString = null;
            // 
            // tabDisplayConfigs
            // 
            this.tabDisplayConfigs.Controls.Add(this.tPageDisplayConfig);
            this.tabDisplayConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDisplayConfigs.Location = new System.Drawing.Point(4, 37);
            this.tabDisplayConfigs.Margin = new System.Windows.Forms.Padding(1);
            this.tabDisplayConfigs.Name = "tabDisplayConfigs";
            this.tabDisplayConfigs.SelectedIndex = 0;
            this.tabDisplayConfigs.Size = new System.Drawing.Size(978, 595);
            this.tabDisplayConfigs.TabIndex = 35;
            // 
            // tPageDisplayConfig
            // 
            this.tPageDisplayConfig.Controls.Add(this.flowSimpleFaiConfigs);
            this.tPageDisplayConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tPageDisplayConfig.Location = new System.Drawing.Point(4, 26);
            this.tPageDisplayConfig.Name = "tPageDisplayConfig";
            this.tPageDisplayConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tPageDisplayConfig.Size = new System.Drawing.Size(970, 565);
            this.tPageDisplayConfig.TabIndex = 0;
            this.tPageDisplayConfig.Text = "显示配置";
            this.tPageDisplayConfig.UseVisualStyleBackColor = true;
            // 
            // flowSimpleFaiConfigs
            // 
            this.flowSimpleFaiConfigs.AutoScroll = true;
            this.flowSimpleFaiConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSimpleFaiConfigs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowSimpleFaiConfigs.Location = new System.Drawing.Point(3, 3);
            this.flowSimpleFaiConfigs.Name = "flowSimpleFaiConfigs";
            this.flowSimpleFaiConfigs.Size = new System.Drawing.Size(964, 559);
            this.flowSimpleFaiConfigs.TabIndex = 0;
            // 
            // tsMainUiConfig
            // 
            this.tsMainUiConfig.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsMainUiConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsMainUiConfig.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsMainUiConfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMainUiConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_MainGUItable,
            this.tsCmbDisplayConfigs,
            this.toolStripSeparator2,
            this.tsBtnAddSingleConfig,
            this.toolStripSeparator3,
            this.tsBtnRemoveSingleConfig});
            this.tsMainUiConfig.Location = new System.Drawing.Point(4, 4);
            this.tsMainUiConfig.Margin = new System.Windows.Forms.Padding(1);
            this.tsMainUiConfig.Name = "tsMainUiConfig";
            this.tsMainUiConfig.Size = new System.Drawing.Size(978, 28);
            this.tsMainUiConfig.TabIndex = 34;
            this.tsMainUiConfig.Text = "脉冲比较触发配置";
            // 
            // tsl_MainGUItable
            // 
            this.tsl_MainGUItable.Name = "tsl_MainGUItable";
            this.tsl_MainGUItable.Size = new System.Drawing.Size(72, 25);
            this.tsl_MainGUItable.Text = "主界面表：";
            // 
            // tsCmbDisplayConfigs
            // 
            this.tsCmbDisplayConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCmbDisplayConfigs.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsCmbDisplayConfigs.Name = "tsCmbDisplayConfigs";
            this.tsCmbDisplayConfigs.Size = new System.Drawing.Size(80, 28);
            this.tsCmbDisplayConfigs.ToolTipText = "选择配置表";
            this.tsCmbDisplayConfigs.SelectedIndexChanged += new System.EventHandler(this.tsCmbDisplayConfigs_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tsBtnAddSingleConfig
            // 
            this.tsBtnAddSingleConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnAddSingleConfig.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Add_2;
            this.tsBtnAddSingleConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddSingleConfig.Name = "tsBtnAddSingleConfig";
            this.tsBtnAddSingleConfig.Size = new System.Drawing.Size(141, 25);
            this.tsBtnAddSingleConfig.Text = "添加一个新的显示选项";
            this.tsBtnAddSingleConfig.Click += new System.EventHandler(this.tsBtnAddSingleConfig_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // tsBtnRemoveSingleConfig
            // 
            this.tsBtnRemoveSingleConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnRemoveSingleConfig.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_1;
            this.tsBtnRemoveSingleConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemoveSingleConfig.Name = "tsBtnRemoveSingleConfig";
            this.tsBtnRemoveSingleConfig.Size = new System.Drawing.Size(154, 25);
            this.tsBtnRemoveSingleConfig.Text = "删除当前选中的显示选项";
            this.tsBtnRemoveSingleConfig.Click += new System.EventHandler(this.tsBtnRemoveSingleConfig_Click);
            // 
            // tpRtVals
            // 
            this.tpRtVals.Controls.Add(this.tlpRtVars);
            this.tpRtVals.Location = new System.Drawing.Point(4, 26);
            this.tpRtVals.Name = "tpRtVals";
            this.tpRtVals.Size = new System.Drawing.Size(986, 636);
            this.tpRtVals.TabIndex = 3;
            this.tpRtVals.Text = "实时变量";
            this.tpRtVals.UseVisualStyleBackColor = true;
            // 
            // tlpRtVars
            // 
            this.tlpRtVars.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tlpRtVars.ColumnCount = 1;
            this.tlpRtVars.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRtVars.Controls.Add(this.dgvRtVars, 0, 1);
            this.tlpRtVars.Controls.Add(this.tsRtVarsConfig, 0, 0);
            this.tlpRtVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRtVars.Location = new System.Drawing.Point(0, 0);
            this.tlpRtVars.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRtVars.Name = "tlpRtVars";
            this.tlpRtVars.RowCount = 2;
            this.tlpRtVars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpRtVars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRtVars.Size = new System.Drawing.Size(986, 636);
            this.tlpRtVars.TabIndex = 1;
            this.tlpRtVars.TagString = null;
            // 
            // dgvRtVars
            // 
            this.dgvRtVars.AllowUserToAddRows = false;
            this.dgvRtVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRtVars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRtVarName,
            this.colRtVarType,
            this.colRtVarSave});
            this.dgvRtVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRtVars.Location = new System.Drawing.Point(4, 37);
            this.dgvRtVars.Margin = new System.Windows.Forms.Padding(1);
            this.dgvRtVars.Name = "dgvRtVars";
            this.dgvRtVars.RowHeadersWidth = 51;
            this.dgvRtVars.RowTemplate.Height = 27;
            this.dgvRtVars.Size = new System.Drawing.Size(978, 595);
            this.dgvRtVars.TabIndex = 3;
            // 
            // colRtVarName
            // 
            this.colRtVarName.FillWeight = 243.6548F;
            this.colRtVarName.HeaderText = "变量名";
            this.colRtVarName.MinimumWidth = 6;
            this.colRtVarName.Name = "colRtVarName";
            this.colRtVarName.Width = 200;
            // 
            // colRtVarType
            // 
            this.colRtVarType.FillWeight = 167.9685F;
            this.colRtVarType.HeaderText = "变量类型";
            this.colRtVarType.MinimumWidth = 6;
            this.colRtVarType.Name = "colRtVarType";
            this.colRtVarType.Width = 200;
            // 
            // colRtVarSave
            // 
            this.colRtVarSave.HeaderText = "掉电保持";
            this.colRtVarSave.MinimumWidth = 8;
            this.colRtVarSave.Name = "colRtVarSave";
            this.colRtVarSave.Width = 150;
            // 
            // tsRtVarsConfig
            // 
            this.tsRtVarsConfig.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsRtVarsConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsRtVarsConfig.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsRtVarsConfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsRtVarsConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsl_RtVars,
            this.tsCmbRtVars,
            this.toolStripSeparator4,
            this.tsBtnAddRtVar,
            this.tsBtnRemoveRtVar,
            this.toolStripSeparator5,
            this.tsBtnRefreshRtVar});
            this.tsRtVarsConfig.Location = new System.Drawing.Point(4, 4);
            this.tsRtVarsConfig.Margin = new System.Windows.Forms.Padding(1);
            this.tsRtVarsConfig.Name = "tsRtVarsConfig";
            this.tsRtVarsConfig.Size = new System.Drawing.Size(978, 28);
            this.tsRtVarsConfig.TabIndex = 35;
            this.tsRtVarsConfig.Text = "脉冲比较触发配置";
            // 
            // tsl_RtVars
            // 
            this.tsl_RtVars.Name = "tsl_RtVars";
            this.tsl_RtVars.Size = new System.Drawing.Size(85, 25);
            this.tsl_RtVars.Text = "实时变量表：";
            // 
            // tsCmbRtVars
            // 
            this.tsCmbRtVars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCmbRtVars.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsCmbRtVars.Name = "tsCmbRtVars";
            this.tsCmbRtVars.Size = new System.Drawing.Size(80, 28);
            this.tsCmbRtVars.ToolTipText = "选择显示配置";
            this.tsCmbRtVars.SelectedIndexChanged += new System.EventHandler(this.tsCmbRtVars_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // tsBtnAddRtVar
            // 
            this.tsBtnAddRtVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddRtVar.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Add_1;
            this.tsBtnAddRtVar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddRtVar.Name = "tsBtnAddRtVar";
            this.tsBtnAddRtVar.Size = new System.Drawing.Size(24, 25);
            this.tsBtnAddRtVar.Text = "toolStripButton2";
            this.tsBtnAddRtVar.ToolTipText = "新增变量";
            this.tsBtnAddRtVar.Click += new System.EventHandler(this.tsAddRtVar_Click);
            // 
            // tsBtnRemoveRtVar
            // 
            this.tsBtnRemoveRtVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRemoveRtVar.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_1;
            this.tsBtnRemoveRtVar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemoveRtVar.Name = "tsBtnRemoveRtVar";
            this.tsBtnRemoveRtVar.Size = new System.Drawing.Size(24, 25);
            this.tsBtnRemoveRtVar.Text = "toolStripButton3";
            this.tsBtnRemoveRtVar.ToolTipText = "删除变量";
            this.tsBtnRemoveRtVar.Click += new System.EventHandler(this.tsDelRtVar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // tsBtnRefreshRtVar
            // 
            this.tsBtnRefreshRtVar.BackColor = System.Drawing.SystemColors.Control;
            this.tsBtnRefreshRtVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRefreshRtVar.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Refresh_2;
            this.tsBtnRefreshRtVar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefreshRtVar.Name = "tsBtnRefreshRtVar";
            this.tsBtnRefreshRtVar.Size = new System.Drawing.Size(24, 25);
            this.tsBtnRefreshRtVar.Text = "toolStripButton4";
            this.tsBtnRefreshRtVar.ToolTipText = "刷新界面";
            this.tsBtnRefreshRtVar.Click += new System.EventHandler(this.tsBtnRefreshRtVar_Click);
            // 
            // dataInfoBindingSource
            // 
            this.dataInfoBindingSource.DataSource = typeof(Lead.CPrim.StationCommon.DataArea.DataInfo);
            // 
            // SingleStationConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SingleStationConfigControl";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Load += new System.EventHandler(this.SingleStationConfigControl_Load);
            this.DoubleClick += new System.EventHandler(this.Control_DoubleClick);
            this.cmsInterlock.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpTitle.ResumeLayout(false);
            this.tlpTitle.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tlpConfig.ResumeLayout(false);
            this.tlpRecipeInfo.ResumeLayout(false);
            this.tlpTask.ResumeLayout(false);
            this.tlpButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.tlpStationButton.ResumeLayout(false);
            this.tlpStationButton.PerformLayout();
            this.tlpRecipe.ResumeLayout(false);
            this.tlpRecipeButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).EndInit();
            this.tpVariable.ResumeLayout(false);
            this.tlpVariable.ResumeLayout(false);
            this.tlpVariable.PerformLayout();
            this.tsDataInfo.ResumeLayout(false);
            this.tsDataInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataInfo)).EndInit();
            this.tpOutputUI.ResumeLayout(false);
            this.tlpMainUi.ResumeLayout(false);
            this.tlpMainUi.PerformLayout();
            this.tabDisplayConfigs.ResumeLayout(false);
            this.tPageDisplayConfig.ResumeLayout(false);
            this.tsMainUiConfig.ResumeLayout(false);
            this.tsMainUiConfig.PerformLayout();
            this.tpRtVals.ResumeLayout(false);
            this.tlpRtVars.ResumeLayout(false);
            this.tlpRtVars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRtVars)).EndInit();
            this.tsRtVarsConfig.ResumeLayout(false);
            this.tsRtVarsConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox tbStationDescription;
        private Label lb_StationInfo;
        private TextBox tbStationIndex;
        private Label lb_StationIndex;
        private TextBox tbStationName;
        private Button btnApply;
        private TabControl tabMain;
        private TabPage tpVariable;
        private TabPage tpOutputUI;
        private TabPage tpRtVals;
        private ToolStrip tsDataInfo;
        private ToolStripLabel tsl_DataInfo;
        private ToolStripComboBox tsCmbDataInfo;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsAddDataInfo;
        private ToolStripButton tsDelDataInfo;
        private ToolStripButton tsDataInfoStartMonitor;
        private ToolStripButton tsDataInfoStopMonitor;
        private DataGridView dgvDataInfo;
        private Timer timerDataInfo;
        private ToolStrip tsMainUiConfig;
        private ToolStripLabel tsl_MainGUItable;
        private ToolStripComboBox tsCmbDisplayConfigs;
        private TabControl tabDisplayConfigs;
        private TabPage tPageDisplayConfig;
        private FlowLayoutPanel flowSimpleFaiConfigs;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsBtnAddSingleConfig;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsBtnRemoveSingleConfig;
        private ToolStrip tsRtVarsConfig;
        private ToolStripLabel tsl_RtVars;
        private ToolStripComboBox tsCmbRtVars;
        private DataGridView dgvRtVars;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsBtnAddRtVar;
        private ToolStripButton tsBtnRemoveRtVar;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton tsBtnRefreshRtVar;
        private CheckBox chkStationEnable;
        private TabPage tpMain;
        private TableLayoutPanel tlpConfig;
        private Button btnTaskDown;
        private Button btnTaskUp;
        private Button btnRemoveTask;
        private Button btnAddTask;
        private Button btnRefreshTasks;
        private ComboBox cmbTasks;
        private Button btnCreateRecipe;
        private Button btnEdit;
        private Button btnSelect;
        private Button btnRecipeUpload;
        private Button btnDeleteRecipe;
        private Button btnRecipePrimsConfig;
        private ComboBox cmbRtVals;
        private ComboBox cmbMainGui;
        private ComboBox cmbVariableSel;
        private Button btnRecipeElesConfig;
        private TextBox tbCurrentRecipe;
        private Label lb_CurrentStationRecipe;
        private TextBox tbEventInfo3;
        private CheckBox chkEventEnable3;
        private TextBox tbEventInfo2;
        private CheckBox chkEventEnable2;
        private TextBox tbEventInfo1;
        private CheckBox chkEventEnable1;
        private ContextMenuStrip cmsInterlock;
        private ToolStripMenuItem tsmAddInterlockRecord;
        private ToolStripMenuItem tsmRemoveInterlockRecord;
        private DataGridViewTextBoxColumn colRtVarName;
        private DataGridViewComboBoxColumn colRtVarType;
        private DataGridViewCheckBoxColumn colRtVarSave;
        private UITableLayoutPanel tlpStationButton;
        private UITableLayoutPanel tlpMain;
        private UILabel lb_StationButton;
        private UITableLayoutPanel tlpRecipe;
        private UILabel lb_RecipeInfo;
        private UILabel lb_CommonParam;
        private UILabel lb_MainGUI;
        private UILabel lb_RtValue;
        private UITableLayoutPanel tlpRecipeButton;
        private UITableLayoutPanel tlpTask;
        private UILabel lb_Task;
        private RichTextBox rtbRecipe;
        private UITableLayoutPanel tlpRecipeInfo;
        private UILabel lb_SelectRecipeInfo;
        private UITableLayoutPanel tlpVariable;
        private UITableLayoutPanel tlpRtVars;
        private UITableLayoutPanel tlpMainUi;
        private UITableLayoutPanel tlpButton;
        private UISymbolButton btnDispose;
        private UISymbolButton btnInit;
        private UITableLayoutPanel tlpTitle;
        private UIDataGridView dgvRecipes;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCreator;
        private DataGridViewTextBoxColumn colCreatTime;
        private DataGridViewTextBoxColumn colEditTime;
        private UIDataGridView dgvTasks;
        private BindingSource dataInfoBindingSource;
        private DataGridViewTextBoxColumn colDtName;
        private DataGridViewComboBoxColumn colDtType;
        private DataGridViewTextBoxColumn colDtValue;
        private DataGridViewTextBoxColumn colDtInputVal;
        private DataGridViewButtonColumn colDtInput;
        private DataGridViewCheckBoxColumn colDtSave;
        private DataGridViewTextBoxColumn TaskName;
        private DataGridViewCheckBoxColumn TaskStatup;
    }
}
