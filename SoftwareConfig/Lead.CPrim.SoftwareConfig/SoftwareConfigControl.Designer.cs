using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.SoftwareConfig
{
    partial class SoftwareConfigControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftwareConfigControl));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tsStationsConfig = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsl_ConfigFilePath = new System.Windows.Forms.ToolStripLabel();
            this.tsTbSWConfigFilePath = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnOpenConfigFilePath = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLoadStationsConfig = new System.Windows.Forms.ToolStripButton();
            this.tabSwConfig = new System.Windows.Forms.TabControl();
            this.tpConfig = new System.Windows.Forms.TabPage();
            this.tbVisionVer = new System.Windows.Forms.TextBox();
            this.lb_VisionSoftwareVersion = new System.Windows.Forms.Label();
            this.tbVisionPath = new System.Windows.Forms.TextBox();
            this.lb_VisionsoftwareFilePath = new System.Windows.Forms.Label();
            this.tbVisionName = new System.Windows.Forms.TextBox();
            this.lb_VisionSoftwareName = new System.Windows.Forms.Label();
            this.txtVisionHashCode = new System.Windows.Forms.TextBox();
            this.lb_VS_Hash = new System.Windows.Forms.Label();
            this.btnCreateHash = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.txtSoftWareHashCode = new System.Windows.Forms.TextBox();
            this.txtConfigFrmBindFaiName = new System.Windows.Forms.TextBox();
            this.tbTaskVer = new System.Windows.Forms.TextBox();
            this.lb_MS_Hash = new System.Windows.Forms.Label();
            this.lb_BindingFAiName = new System.Windows.Forms.Label();
            this.lb_Taskversion = new System.Windows.Forms.Label();
            this.lb_SoftwareInfo = new System.Windows.Forms.Label();
            this.tbSWDescription = new System.Windows.Forms.TextBox();
            this.lblDataSave = new System.Windows.Forms.Label();
            this.lb_MasterControl = new System.Windows.Forms.Label();
            this.lb_NumberOfTaskLogUI = new System.Windows.Forms.Label();
            this.chkRemoteRecipeShiftEnable = new System.Windows.Forms.CheckBox();
            this.lb_SoftwareName = new System.Windows.Forms.Label();
            this.tbSwName = new System.Windows.Forms.TextBox();
            this.cbDataSave = new System.Windows.Forms.ComboBox();
            this.cbMasterControl = new System.Windows.Forms.ComboBox();
            this.lb_PermissionLogoutTimeout = new System.Windows.Forms.Label();
            this.cbTaskLogUINo = new System.Windows.Forms.ComboBox();
            this.chkBootInit = new System.Windows.Forms.CheckBox();
            this.chkBootRun = new System.Windows.Forms.CheckBox();
            this.chkTrackingEnable = new System.Windows.Forms.CheckBox();
            this.kryptonLabel9 = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lbProducts = new System.Windows.Forms.Label();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.lb_SystemType = new System.Windows.Forms.Label();
            this.cmbSWType = new System.Windows.Forms.ComboBox();
            this.chkRemoteQualificationEnable = new System.Windows.Forms.CheckBox();
            this.tbExitPermissionTime = new System.Windows.Forms.TextBox();
            this.tbSuperClientName = new System.Windows.Forms.TextBox();
            this.lb_ChangeRepiceSuperClientName = new System.Windows.Forms.Label();
            this.tpDisplayParam = new System.Windows.Forms.TabPage();
            this.lab_AccessaryCodeLength = new System.Windows.Forms.Label();
            this.tb_AccessaryCodeLength = new System.Windows.Forms.TextBox();
            this.cb_AccessaryNames = new System.Windows.Forms.CheckBox();
            this.lb_TossingReasons = new System.Windows.Forms.Label();
            this.tb_AccessaryNames = new System.Windows.Forms.TextBox();
            this.tb_TossingReason = new System.Windows.Forms.TextBox();
            this.cbPressPrimEnable = new System.Windows.Forms.CheckBox();
            this.tbServicePrimName = new System.Windows.Forms.TextBox();
            this.lb_ServerPrism = new System.Windows.Forms.Label();
            this.tbPressPrimName = new System.Windows.Forms.TextBox();
            this.lb_Tip_RestartSoftware = new System.Windows.Forms.Label();
            this.tpPath = new System.Windows.Forms.TabPage();
            this.lb_Prims = new System.Windows.Forms.Label();
            this.chkDisConfigEnable = new System.Windows.Forms.CheckBox();
            this.btnBrowsePDCAPath = new System.Windows.Forms.Button();
            this.chkFaiConfigEnable = new System.Windows.Forms.CheckBox();
            this.btnBrowseSFLPath = new System.Windows.Forms.Button();
            this.chkCommonDynamicParamEnable = new System.Windows.Forms.CheckBox();
            this.btnBrowseMachineDataPath = new System.Windows.Forms.Button();
            this.chkDynamicParamEnable = new System.Windows.Forms.CheckBox();
            this.btnBrowseMachinePath = new System.Windows.Forms.Button();
            this.chkCmpTrigConfigEnable = new System.Windows.Forms.CheckBox();
            this.tbMachineData = new System.Windows.Forms.TextBox();
            this.chkTasksConfigEnable = new System.Windows.Forms.CheckBox();
            this.tbSFLPath = new System.Windows.Forms.TextBox();
            this.chkElesConfigEnable = new System.Windows.Forms.CheckBox();
            this.tbMachinePath = new System.Windows.Forms.TextBox();
            this.chkShowConfigEnable = new System.Windows.Forms.CheckBox();
            this.tbPDCAPath = new System.Windows.Forms.TextBox();
            this.chkPrimsConfigEnable = new System.Windows.Forms.CheckBox();
            this.lb_Log_PDCA = new System.Windows.Forms.Label();
            this.btnBrowseDisConfigPath = new System.Windows.Forms.Button();
            this.lb_ProductionData = new System.Windows.Forms.Label();
            this.btnBrowseComplexQueryTaskFilePath = new System.Windows.Forms.Button();
            this.lb_Log_Machine = new System.Windows.Forms.Label();
            this.btnBrowseFaiConfigPath = new System.Windows.Forms.Button();
            this.lb_Log_SFL = new System.Windows.Forms.Label();
            this.btnBrowseDynamicParamDir = new System.Windows.Forms.Button();
            this.tbDispenserConfigPath = new System.Windows.Forms.TextBox();
            this.btnBrowseCmpTrigFile = new System.Windows.Forms.Button();
            this.tbComplexQueryTaskFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseTasksFile = new System.Windows.Forms.Button();
            this.tbFaiConfigPath = new System.Windows.Forms.TextBox();
            this.btnBrowseElesFile = new System.Windows.Forms.Button();
            this.tbDynamicParamDirPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDisplayFile = new System.Windows.Forms.Button();
            this.tbCmpTrigsConfigPath = new System.Windows.Forms.TextBox();
            this.btnBrowsePrimsFile = new System.Windows.Forms.Button();
            this.tbTasksConfigPath = new System.Windows.Forms.TextBox();
            this.lb_Display = new System.Windows.Forms.Label();
            this.tbElesConfigPath = new System.Windows.Forms.TextBox();
            this.lb_Element = new System.Windows.Forms.Label();
            this.tbShowConfigPath = new System.Windows.Forms.TextBox();
            this.lb_Task = new System.Windows.Forms.Label();
            this.tbPrimsConfigPath = new System.Windows.Forms.TextBox();
            this.lb_Trig = new System.Windows.Forms.Label();
            this.lb_Dispensing = new System.Windows.Forms.Label();
            this.lb_ParameterFilePath = new System.Windows.Forms.Label();
            this.lb_ComplexFai = new System.Windows.Forms.Label();
            this.lb_Fai = new System.Windows.Forms.Label();
            this.lblDirectory1 = new System.Windows.Forms.Label();
            this.txtDirectory1 = new System.Windows.Forms.TextBox();
            this.dudDirectory1 = new Sunny.UI.UIDoubleUpDown();
            this.lblDirectory2 = new System.Windows.Forms.Label();
            this.txtDirectory2 = new System.Windows.Forms.TextBox();
            this.dudDirectory2 = new Sunny.UI.UIDoubleUpDown();
            this.tmrOneHour = new System.Windows.Forms.Timer(this.components);
            this.tlpMain.SuspendLayout();
            this.tsStationsConfig.SuspendLayout();
            this.tabSwConfig.SuspendLayout();
            this.tpConfig.SuspendLayout();
            this.tpDisplayParam.SuspendLayout();
            this.tpPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoScroll = true;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tsStationsConfig, 0, 0);
            this.tlpMain.Controls.Add(this.tabSwConfig, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1276, 651);
            this.tlpMain.TabIndex = 0;
            // 
            // tsStationsConfig
            // 
            this.tsStationsConfig.BackColor = System.Drawing.Color.LightGray;
            this.tsStationsConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsStationsConfig.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsStationsConfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsStationsConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.tsl_ConfigFilePath,
            this.tsTbSWConfigFilePath,
            this.tsBtnOpenConfigFilePath,
            this.tsBtnLoadStationsConfig});
            this.tsStationsConfig.Location = new System.Drawing.Point(4, 4);
            this.tsStationsConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.tsStationsConfig.Name = "tsStationsConfig";
            this.tsStationsConfig.Padding = new System.Windows.Forms.Padding(0);
            this.tsStationsConfig.Size = new System.Drawing.Size(1268, 26);
            this.tsStationsConfig.TabIndex = 35;
            this.tsStationsConfig.Text = "脉冲比较触发配置";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 26);
            // 
            // tsl_ConfigFilePath
            // 
            this.tsl_ConfigFilePath.Name = "tsl_ConfigFilePath";
            this.tsl_ConfigFilePath.Size = new System.Drawing.Size(72, 23);
            this.tsl_ConfigFilePath.Text = "配置路径：";
            // 
            // tsTbSWConfigFilePath
            // 
            this.tsTbSWConfigFilePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tsTbSWConfigFilePath.Name = "tsTbSWConfigFilePath";
            this.tsTbSWConfigFilePath.Size = new System.Drawing.Size(600, 26);
            // 
            // tsBtnOpenConfigFilePath
            // 
            this.tsBtnOpenConfigFilePath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnOpenConfigFilePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsBtnOpenConfigFilePath.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOpenConfigFilePath.Image")));
            this.tsBtnOpenConfigFilePath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpenConfigFilePath.Name = "tsBtnOpenConfigFilePath";
            this.tsBtnOpenConfigFilePath.Size = new System.Drawing.Size(25, 23);
            this.tsBtnOpenConfigFilePath.Text = "...";
            this.tsBtnOpenConfigFilePath.Click += new System.EventHandler(this.tsBtnOpenConfigFilePath_Click);
            // 
            // tsBtnLoadStationsConfig
            // 
            this.tsBtnLoadStationsConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnLoadStationsConfig.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsBtnLoadStationsConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLoadStationsConfig.Image")));
            this.tsBtnLoadStationsConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLoadStationsConfig.Name = "tsBtnLoadStationsConfig";
            this.tsBtnLoadStationsConfig.Size = new System.Drawing.Size(42, 23);
            this.tsBtnLoadStationsConfig.Text = "Load";
            this.tsBtnLoadStationsConfig.Click += new System.EventHandler(this.tsBtnLoadSWConfig_Click);
            // 
            // tabSwConfig
            // 
            this.tabSwConfig.Controls.Add(this.tpConfig);
            this.tabSwConfig.Controls.Add(this.tpDisplayParam);
            this.tabSwConfig.Controls.Add(this.tpPath);
            this.tabSwConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSwConfig.Location = new System.Drawing.Point(3, 33);
            this.tabSwConfig.Name = "tabSwConfig";
            this.tabSwConfig.SelectedIndex = 1;
            this.tabSwConfig.Size = new System.Drawing.Size(1270, 615);
            this.tabSwConfig.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSwConfig.TabIndex = 1;
            this.tabSwConfig.Text = "kryptonNavigator1";
            // 
            // tpConfig
            // 
            this.tpConfig.Controls.Add(this.tbVisionVer);
            this.tpConfig.Controls.Add(this.lb_VisionSoftwareVersion);
            this.tpConfig.Controls.Add(this.tbVisionPath);
            this.tpConfig.Controls.Add(this.lb_VisionsoftwareFilePath);
            this.tpConfig.Controls.Add(this.tbVisionName);
            this.tpConfig.Controls.Add(this.lb_VisionSoftwareName);
            this.tpConfig.Controls.Add(this.txtVisionHashCode);
            this.tpConfig.Controls.Add(this.lb_VS_Hash);
            this.tpConfig.Controls.Add(this.btnCreateHash);
            this.tpConfig.Controls.Add(this.txtSoftWareHashCode);
            this.tpConfig.Controls.Add(this.txtConfigFrmBindFaiName);
            this.tpConfig.Controls.Add(this.tbTaskVer);
            this.tpConfig.Controls.Add(this.lb_MS_Hash);
            this.tpConfig.Controls.Add(this.lb_BindingFAiName);
            this.tpConfig.Controls.Add(this.lb_Taskversion);
            this.tpConfig.Controls.Add(this.lb_SoftwareInfo);
            this.tpConfig.Controls.Add(this.tbSWDescription);
            this.tpConfig.Controls.Add(this.lblDataSave);
            this.tpConfig.Controls.Add(this.lb_MasterControl);
            this.tpConfig.Controls.Add(this.lb_NumberOfTaskLogUI);
            this.tpConfig.Controls.Add(this.chkRemoteRecipeShiftEnable);
            this.tpConfig.Controls.Add(this.lb_SoftwareName);
            this.tpConfig.Controls.Add(this.tbSwName);
            this.tpConfig.Controls.Add(this.cbDataSave);
            this.tpConfig.Controls.Add(this.cbMasterControl);
            this.tpConfig.Controls.Add(this.lb_PermissionLogoutTimeout);
            this.tpConfig.Controls.Add(this.cbTaskLogUINo);
            this.tpConfig.Controls.Add(this.chkBootInit);
            this.tpConfig.Controls.Add(this.chkBootRun);
            this.tpConfig.Controls.Add(this.chkTrackingEnable);
            this.tpConfig.Controls.Add(this.kryptonLabel9);
            this.tpConfig.Controls.Add(this.cmbLanguage);
            this.tpConfig.Controls.Add(this.lbProducts);
            this.tpConfig.Controls.Add(this.cmbProducts);
            this.tpConfig.Controls.Add(this.btnAddProduct);
            this.tpConfig.Controls.Add(this.btnRemoveProduct);
            this.tpConfig.Controls.Add(this.lb_SystemType);
            this.tpConfig.Controls.Add(this.cmbSWType);
            this.tpConfig.Controls.Add(this.chkRemoteQualificationEnable);
            this.tpConfig.Controls.Add(this.tbExitPermissionTime);
            this.tpConfig.Controls.Add(this.tbSuperClientName);
            this.tpConfig.Controls.Add(this.lb_ChangeRepiceSuperClientName);
            this.tpConfig.Location = new System.Drawing.Point(4, 26);
            this.tpConfig.MinimumSize = new System.Drawing.Size(49, 49);
            this.tpConfig.Name = "tpConfig";
            this.tpConfig.Size = new System.Drawing.Size(1262, 585);
            this.tpConfig.TabIndex = 0;
            this.tpConfig.Text = "参数设置";
            // 
            // tbVisionVer
            // 
            this.tbVisionVer.Location = new System.Drawing.Point(724, 217);
            this.tbVisionVer.Margin = new System.Windows.Forms.Padding(1);
            this.tbVisionVer.Name = "tbVisionVer";
            this.tbVisionVer.Size = new System.Drawing.Size(99, 23);
            this.tbVisionVer.TabIndex = 344;
            // 
            // lb_VisionSoftwareVersion
            // 
            this.lb_VisionSoftwareVersion.AutoSize = true;
            this.lb_VisionSoftwareVersion.Location = new System.Drawing.Point(631, 220);
            this.lb_VisionSoftwareVersion.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_VisionSoftwareVersion.Name = "lb_VisionSoftwareVersion";
            this.lb_VisionSoftwareVersion.Size = new System.Drawing.Size(92, 17);
            this.lb_VisionSoftwareVersion.TabIndex = 343;
            this.lb_VisionSoftwareVersion.Text = "视觉软件版本：";
            this.lb_VisionSoftwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbVisionPath
            // 
            this.tbVisionPath.Location = new System.Drawing.Point(505, 247);
            this.tbVisionPath.Margin = new System.Windows.Forms.Padding(1);
            this.tbVisionPath.Name = "tbVisionPath";
            this.tbVisionPath.Size = new System.Drawing.Size(238, 23);
            this.tbVisionPath.TabIndex = 342;
            // 
            // lb_VisionsoftwareFilePath
            // 
            this.lb_VisionsoftwareFilePath.AutoSize = true;
            this.lb_VisionsoftwareFilePath.Location = new System.Drawing.Point(412, 250);
            this.lb_VisionsoftwareFilePath.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_VisionsoftwareFilePath.Name = "lb_VisionsoftwareFilePath";
            this.lb_VisionsoftwareFilePath.Size = new System.Drawing.Size(92, 17);
            this.lb_VisionsoftwareFilePath.TabIndex = 341;
            this.lb_VisionsoftwareFilePath.Text = "视觉软件路径：";
            this.lb_VisionsoftwareFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbVisionName
            // 
            this.tbVisionName.Location = new System.Drawing.Point(505, 217);
            this.tbVisionName.Margin = new System.Windows.Forms.Padding(1);
            this.tbVisionName.Name = "tbVisionName";
            this.tbVisionName.Size = new System.Drawing.Size(111, 23);
            this.tbVisionName.TabIndex = 340;
            // 
            // lb_VisionSoftwareName
            // 
            this.lb_VisionSoftwareName.AutoSize = true;
            this.lb_VisionSoftwareName.Location = new System.Drawing.Point(412, 220);
            this.lb_VisionSoftwareName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_VisionSoftwareName.Name = "lb_VisionSoftwareName";
            this.lb_VisionSoftwareName.Size = new System.Drawing.Size(92, 17);
            this.lb_VisionSoftwareName.TabIndex = 339;
            this.lb_VisionSoftwareName.Text = "视觉软件名称：";
            this.lb_VisionSoftwareName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVisionHashCode
            // 
            this.txtVisionHashCode.Location = new System.Drawing.Point(118, 437);
            this.txtVisionHashCode.Margin = new System.Windows.Forms.Padding(1);
            this.txtVisionHashCode.Name = "txtVisionHashCode";
            this.txtVisionHashCode.ReadOnly = true;
            this.txtVisionHashCode.Size = new System.Drawing.Size(326, 23);
            this.txtVisionHashCode.TabIndex = 338;
            this.txtVisionHashCode.Text = "1234567890123456789012345678901234567890";
            // 
            // lb_VS_Hash
            // 
            this.lb_VS_Hash.AutoSize = true;
            this.lb_VS_Hash.Location = new System.Drawing.Point(20, 440);
            this.lb_VS_Hash.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_VS_Hash.Name = "lb_VS_Hash";
            this.lb_VS_Hash.Size = new System.Drawing.Size(85, 17);
            this.lb_VS_Hash.TabIndex = 337;
            this.lb_VS_Hash.Text = "视觉Hash码：";
            this.lb_VS_Hash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCreateHash
            // 
            this.btnCreateHash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateHash.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateHash.Location = new System.Drawing.Point(462, 407);
            this.btnCreateHash.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCreateHash.Name = "btnCreateHash";
            this.btnCreateHash.Size = new System.Drawing.Size(74, 53);
            this.btnCreateHash.TabIndex = 336;
            this.btnCreateHash.Text = "生成";
            this.btnCreateHash.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateHash.Visible = false;
            this.btnCreateHash.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCreateHash.Click += new System.EventHandler(this.btnCreateHash_Click);
            // 
            // txtSoftWareHashCode
            // 
            this.txtSoftWareHashCode.Location = new System.Drawing.Point(118, 407);
            this.txtSoftWareHashCode.Margin = new System.Windows.Forms.Padding(1);
            this.txtSoftWareHashCode.Name = "txtSoftWareHashCode";
            this.txtSoftWareHashCode.ReadOnly = true;
            this.txtSoftWareHashCode.Size = new System.Drawing.Size(326, 23);
            this.txtSoftWareHashCode.TabIndex = 335;
            this.txtSoftWareHashCode.Text = "1234567890123456789012345678901234567890";
            // 
            // txtConfigFrmBindFaiName
            // 
            this.txtConfigFrmBindFaiName.Location = new System.Drawing.Point(209, 367);
            this.txtConfigFrmBindFaiName.Margin = new System.Windows.Forms.Padding(1);
            this.txtConfigFrmBindFaiName.Name = "txtConfigFrmBindFaiName";
            this.txtConfigFrmBindFaiName.Size = new System.Drawing.Size(133, 23);
            this.txtConfigFrmBindFaiName.TabIndex = 335;
            // 
            // tbTaskVer
            // 
            this.tbTaskVer.Location = new System.Drawing.Point(288, 217);
            this.tbTaskVer.Margin = new System.Windows.Forms.Padding(1);
            this.tbTaskVer.Name = "tbTaskVer";
            this.tbTaskVer.Size = new System.Drawing.Size(100, 23);
            this.tbTaskVer.TabIndex = 335;
            // 
            // lb_MS_Hash
            // 
            this.lb_MS_Hash.AutoSize = true;
            this.lb_MS_Hash.Location = new System.Drawing.Point(20, 410);
            this.lb_MS_Hash.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_MS_Hash.Name = "lb_MS_Hash";
            this.lb_MS_Hash.Size = new System.Drawing.Size(97, 17);
            this.lb_MS_Hash.TabIndex = 334;
            this.lb_MS_Hash.Text = "上位机Hash码：";
            this.lb_MS_Hash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_BindingFAiName
            // 
            this.lb_BindingFAiName.AutoSize = true;
            this.lb_BindingFAiName.Location = new System.Drawing.Point(20, 370);
            this.lb_BindingFAiName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_BindingFAiName.Name = "lb_BindingFAiName";
            this.lb_BindingFAiName.Size = new System.Drawing.Size(146, 17);
            this.lb_BindingFAiName.TabIndex = 334;
            this.lb_BindingFAiName.Text = "ConfigFrm绑定FAI名称：";
            this.lb_BindingFAiName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Taskversion
            // 
            this.lb_Taskversion.AutoSize = true;
            this.lb_Taskversion.Location = new System.Drawing.Point(218, 220);
            this.lb_Taskversion.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_Taskversion.Name = "lb_Taskversion";
            this.lb_Taskversion.Size = new System.Drawing.Size(71, 17);
            this.lb_Taskversion.TabIndex = 334;
            this.lb_Taskversion.Text = "Task版本：";
            this.lb_Taskversion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_SoftwareInfo
            // 
            this.lb_SoftwareInfo.AutoSize = true;
            this.lb_SoftwareInfo.Location = new System.Drawing.Point(20, 20);
            this.lb_SoftwareInfo.Name = "lb_SoftwareInfo";
            this.lb_SoftwareInfo.Size = new System.Drawing.Size(68, 17);
            this.lb_SoftwareInfo.TabIndex = 275;
            this.lb_SoftwareInfo.Text = "系统描述：";
            this.lb_SoftwareInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSWDescription
            // 
            this.tbSWDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSWDescription.Location = new System.Drawing.Point(97, 17);
            this.tbSWDescription.Name = "tbSWDescription";
            this.tbSWDescription.Size = new System.Drawing.Size(149, 23);
            this.tbSWDescription.TabIndex = 276;
            this.tbSWDescription.Text = "CPrim";
            // 
            // lblDataSave
            // 
            this.lblDataSave.AutoSize = true;
            this.lblDataSave.Location = new System.Drawing.Point(20, 340);
            this.lblDataSave.Name = "lblDataSave";
            this.lblDataSave.Size = new System.Drawing.Size(116, 17);
            this.lblDataSave.TabIndex = 301;
            this.lblDataSave.Text = "设备参数定期保存：";
            this.lblDataSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_MasterControl
            // 
            this.lb_MasterControl.AutoSize = true;
            this.lb_MasterControl.Location = new System.Drawing.Point(20, 280);
            this.lb_MasterControl.Name = "lb_MasterControl";
            this.lb_MasterControl.Size = new System.Drawing.Size(104, 17);
            this.lb_MasterControl.TabIndex = 301;
            this.lb_MasterControl.Text = "MasterControl：";
            this.lb_MasterControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_NumberOfTaskLogUI
            // 
            this.lb_NumberOfTaskLogUI.AutoSize = true;
            this.lb_NumberOfTaskLogUI.Location = new System.Drawing.Point(20, 310);
            this.lb_NumberOfTaskLogUI.Name = "lb_NumberOfTaskLogUI";
            this.lb_NumberOfTaskLogUI.Size = new System.Drawing.Size(184, 17);
            this.lb_NumberOfTaskLogUI.TabIndex = 301;
            this.lb_NumberOfTaskLogUI.Text = "任务日志UI数量（支持1/2/4）：";
            this.lb_NumberOfTaskLogUI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkRemoteRecipeShiftEnable
            // 
            this.chkRemoteRecipeShiftEnable.AutoSize = true;
            this.chkRemoteRecipeShiftEnable.Location = new System.Drawing.Point(20, 190);
            this.chkRemoteRecipeShiftEnable.Name = "chkRemoteRecipeShiftEnable";
            this.chkRemoteRecipeShiftEnable.Size = new System.Drawing.Size(123, 21);
            this.chkRemoteRecipeShiftEnable.TabIndex = 294;
            this.chkRemoteRecipeShiftEnable.Text = "远程切换配方使能";
            this.chkRemoteRecipeShiftEnable.CheckedChanged += new System.EventHandler(this.chkRemoteRecipeShiftEnable_CheckedChanged);
            // 
            // lb_SoftwareName
            // 
            this.lb_SoftwareName.AutoSize = true;
            this.lb_SoftwareName.Location = new System.Drawing.Point(20, 220);
            this.lb_SoftwareName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_SoftwareName.Name = "lb_SoftwareName";
            this.lb_SoftwareName.Size = new System.Drawing.Size(68, 17);
            this.lb_SoftwareName.TabIndex = 297;
            this.lb_SoftwareName.Text = "软件名称：";
            this.lb_SoftwareName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSwName
            // 
            this.tbSwName.Location = new System.Drawing.Point(96, 217);
            this.tbSwName.Margin = new System.Windows.Forms.Padding(1);
            this.tbSwName.Name = "tbSwName";
            this.tbSwName.Size = new System.Drawing.Size(107, 23);
            this.tbSwName.TabIndex = 298;
            // 
            // cbDataSave
            // 
            this.cbDataSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataSave.DropDownWidth = 85;
            this.cbDataSave.Items.AddRange(new object[] {
            "Other",
            "ByEveryDay",
            "ByEveryWeek"});
            this.cbDataSave.Location = new System.Drawing.Point(209, 336);
            this.cbDataSave.Name = "cbDataSave";
            this.cbDataSave.Size = new System.Drawing.Size(133, 25);
            this.cbDataSave.TabIndex = 302;
            // 
            // cbMasterControl
            // 
            this.cbMasterControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMasterControl.DropDownWidth = 85;
            this.cbMasterControl.Location = new System.Drawing.Point(209, 276);
            this.cbMasterControl.Name = "cbMasterControl";
            this.cbMasterControl.Size = new System.Drawing.Size(133, 25);
            this.cbMasterControl.TabIndex = 302;
            // 
            // lb_PermissionLogoutTimeout
            // 
            this.lb_PermissionLogoutTimeout.AutoSize = true;
            this.lb_PermissionLogoutTimeout.Location = new System.Drawing.Point(20, 250);
            this.lb_PermissionLogoutTimeout.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_PermissionLogoutTimeout.Name = "lb_PermissionLogoutTimeout";
            this.lb_PermissionLogoutTimeout.Size = new System.Drawing.Size(152, 17);
            this.lb_PermissionLogoutTimeout.TabIndex = 299;
            this.lb_PermissionLogoutTimeout.Text = "权限注销超时时间（秒）：";
            this.lb_PermissionLogoutTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTaskLogUINo
            // 
            this.cbTaskLogUINo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTaskLogUINo.DropDownWidth = 85;
            this.cbTaskLogUINo.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.cbTaskLogUINo.Location = new System.Drawing.Point(209, 306);
            this.cbTaskLogUINo.Name = "cbTaskLogUINo";
            this.cbTaskLogUINo.Size = new System.Drawing.Size(133, 25);
            this.cbTaskLogUINo.TabIndex = 302;
            // 
            // chkBootInit
            // 
            this.chkBootInit.AutoSize = true;
            this.chkBootInit.Location = new System.Drawing.Point(20, 140);
            this.chkBootInit.Name = "chkBootInit";
            this.chkBootInit.Size = new System.Drawing.Size(87, 21);
            this.chkBootInit.TabIndex = 291;
            this.chkBootInit.Text = "上电初始化";
            // 
            // chkBootRun
            // 
            this.chkBootRun.AutoSize = true;
            this.chkBootRun.Location = new System.Drawing.Point(200, 140);
            this.chkBootRun.Name = "chkBootRun";
            this.chkBootRun.Size = new System.Drawing.Size(75, 21);
            this.chkBootRun.TabIndex = 292;
            this.chkBootRun.Text = "上电启动";
            // 
            // chkTrackingEnable
            // 
            this.chkTrackingEnable.AutoSize = true;
            this.chkTrackingEnable.Location = new System.Drawing.Point(20, 165);
            this.chkTrackingEnable.Name = "chkTrackingEnable";
            this.chkTrackingEnable.Size = new System.Drawing.Size(125, 21);
            this.chkTrackingEnable.TabIndex = 293;
            this.chkTrackingEnable.Text = "Tracking功能使能";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.AutoSize = true;
            this.kryptonLabel9.Location = new System.Drawing.Point(20, 110);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(44, 17);
            this.kryptonLabel9.TabIndex = 289;
            this.kryptonLabel9.Text = "语言：";
            this.kryptonLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kryptonLabel9.Visible = false;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownWidth = 85;
            this.cmbLanguage.Items.AddRange(new object[] {
            "中文",
            "English"});
            this.cmbLanguage.Location = new System.Drawing.Point(97, 106);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(149, 25);
            this.cmbLanguage.TabIndex = 290;
            this.cmbLanguage.Visible = false;
            // 
            // lbProducts
            // 
            this.lbProducts.AutoSize = true;
            this.lbProducts.Location = new System.Drawing.Point(20, 80);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(68, 17);
            this.lbProducts.TabIndex = 284;
            this.lbProducts.Text = "产品列表：";
            this.lbProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProducts
            // 
            this.cmbProducts.DropDownWidth = 85;
            this.cmbProducts.Location = new System.Drawing.Point(97, 76);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(149, 25);
            this.cmbProducts.TabIndex = 285;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddProduct.Location = new System.Drawing.Point(255, 76);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(40, 25);
            this.btnAddProduct.TabIndex = 286;
            this.btnAddProduct.Text = "+";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveProduct.Location = new System.Drawing.Point(297, 76);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(40, 25);
            this.btnRemoveProduct.TabIndex = 287;
            this.btnRemoveProduct.Text = "-";
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // lb_SystemType
            // 
            this.lb_SystemType.AutoSize = true;
            this.lb_SystemType.Location = new System.Drawing.Point(20, 50);
            this.lb_SystemType.Name = "lb_SystemType";
            this.lb_SystemType.Size = new System.Drawing.Size(68, 17);
            this.lb_SystemType.TabIndex = 277;
            this.lb_SystemType.Text = "系统类型：";
            this.lb_SystemType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSWType
            // 
            this.cmbSWType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSWType.DropDownWidth = 85;
            this.cmbSWType.Items.AddRange(new object[] {
            "Server",
            "Client"});
            this.cmbSWType.Location = new System.Drawing.Point(97, 46);
            this.cmbSWType.Name = "cmbSWType";
            this.cmbSWType.Size = new System.Drawing.Size(149, 25);
            this.cmbSWType.TabIndex = 278;
            // 
            // chkRemoteQualificationEnable
            // 
            this.chkRemoteQualificationEnable.AutoSize = true;
            this.chkRemoteQualificationEnable.Location = new System.Drawing.Point(255, 18);
            this.chkRemoteQualificationEnable.Name = "chkRemoteQualificationEnable";
            this.chkRemoteQualificationEnable.Size = new System.Drawing.Size(196, 21);
            this.chkRemoteQualificationEnable.TabIndex = 283;
            this.chkRemoteQualificationEnable.Text = "Remote Qualification功能使能";
            // 
            // tbExitPermissionTime
            // 
            this.tbExitPermissionTime.Location = new System.Drawing.Point(209, 247);
            this.tbExitPermissionTime.Margin = new System.Windows.Forms.Padding(1);
            this.tbExitPermissionTime.Name = "tbExitPermissionTime";
            this.tbExitPermissionTime.Size = new System.Drawing.Size(133, 23);
            this.tbExitPermissionTime.TabIndex = 300;
            // 
            // tbSuperClientName
            // 
            this.tbSuperClientName.Location = new System.Drawing.Point(357, 189);
            this.tbSuperClientName.Margin = new System.Windows.Forms.Padding(1);
            this.tbSuperClientName.Name = "tbSuperClientName";
            this.tbSuperClientName.Size = new System.Drawing.Size(96, 23);
            this.tbSuperClientName.TabIndex = 296;
            // 
            // lb_ChangeRepiceSuperClientName
            // 
            this.lb_ChangeRepiceSuperClientName.AutoSize = true;
            this.lb_ChangeRepiceSuperClientName.Location = new System.Drawing.Point(199, 192);
            this.lb_ChangeRepiceSuperClientName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_ChangeRepiceSuperClientName.Name = "lb_ChangeRepiceSuperClientName";
            this.lb_ChangeRepiceSuperClientName.Size = new System.Drawing.Size(146, 17);
            this.lb_ChangeRepiceSuperClientName.TabIndex = 295;
            this.lb_ChangeRepiceSuperClientName.Text = "配方切换SuperClient名称";
            this.lb_ChangeRepiceSuperClientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpDisplayParam
            // 
            this.tpDisplayParam.Controls.Add(this.lab_AccessaryCodeLength);
            this.tpDisplayParam.Controls.Add(this.tb_AccessaryCodeLength);
            this.tpDisplayParam.Controls.Add(this.cb_AccessaryNames);
            this.tpDisplayParam.Controls.Add(this.lb_TossingReasons);
            this.tpDisplayParam.Controls.Add(this.tb_AccessaryNames);
            this.tpDisplayParam.Controls.Add(this.tb_TossingReason);
            this.tpDisplayParam.Controls.Add(this.cbPressPrimEnable);
            this.tpDisplayParam.Controls.Add(this.tbServicePrimName);
            this.tpDisplayParam.Controls.Add(this.lb_ServerPrism);
            this.tpDisplayParam.Controls.Add(this.tbPressPrimName);
            this.tpDisplayParam.Controls.Add(this.lb_Tip_RestartSoftware);
            this.tpDisplayParam.Location = new System.Drawing.Point(4, 26);
            this.tpDisplayParam.Name = "tpDisplayParam";
            this.tpDisplayParam.Size = new System.Drawing.Size(1262, 585);
            this.tpDisplayParam.TabIndex = 2;
            this.tpDisplayParam.Text = "界面设置";
            this.tpDisplayParam.UseVisualStyleBackColor = true;
            // 
            // lab_AccessaryCodeLength
            // 
            this.lab_AccessaryCodeLength.AutoSize = true;
            this.lab_AccessaryCodeLength.Location = new System.Drawing.Point(92, 125);
            this.lab_AccessaryCodeLength.Name = "lab_AccessaryCodeLength";
            this.lab_AccessaryCodeLength.Size = new System.Drawing.Size(104, 17);
            this.lab_AccessaryCodeLength.TabIndex = 367;
            this.lab_AccessaryCodeLength.Text = "辅料码长度限定：";
            this.lab_AccessaryCodeLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_AccessaryCodeLength
            // 
            this.tb_AccessaryCodeLength.Location = new System.Drawing.Point(210, 122);
            this.tb_AccessaryCodeLength.Margin = new System.Windows.Forms.Padding(1);
            this.tb_AccessaryCodeLength.Name = "tb_AccessaryCodeLength";
            this.tb_AccessaryCodeLength.Size = new System.Drawing.Size(375, 23);
            this.tb_AccessaryCodeLength.TabIndex = 366;
            // 
            // cb_AccessaryNames
            // 
            this.cb_AccessaryNames.AutoSize = true;
            this.cb_AccessaryNames.Location = new System.Drawing.Point(111, 86);
            this.cb_AccessaryNames.Name = "cb_AccessaryNames";
            this.cb_AccessaryNames.Size = new System.Drawing.Size(87, 21);
            this.cb_AccessaryNames.TabIndex = 365;
            this.cb_AccessaryNames.Text = "辅料名称：";
            this.cb_AccessaryNames.UseVisualStyleBackColor = true;
            this.cb_AccessaryNames.CheckedChanged += new System.EventHandler(this.cb_AccessaryNames_CheckedChanged);
            // 
            // lb_TossingReasons
            // 
            this.lb_TossingReasons.AutoSize = true;
            this.lb_TossingReasons.Location = new System.Drawing.Point(116, 161);
            this.lb_TossingReasons.Name = "lb_TossingReasons";
            this.lb_TossingReasons.Size = new System.Drawing.Size(80, 17);
            this.lb_TossingReasons.TabIndex = 364;
            this.lb_TossingReasons.Text = "抛辅料原因：";
            this.lb_TossingReasons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_AccessaryNames
            // 
            this.tb_AccessaryNames.Location = new System.Drawing.Point(210, 85);
            this.tb_AccessaryNames.Margin = new System.Windows.Forms.Padding(1);
            this.tb_AccessaryNames.Name = "tb_AccessaryNames";
            this.tb_AccessaryNames.Size = new System.Drawing.Size(375, 23);
            this.tb_AccessaryNames.TabIndex = 363;
            // 
            // tb_TossingReason
            // 
            this.tb_TossingReason.Location = new System.Drawing.Point(210, 158);
            this.tb_TossingReason.Margin = new System.Windows.Forms.Padding(1);
            this.tb_TossingReason.Name = "tb_TossingReason";
            this.tb_TossingReason.Size = new System.Drawing.Size(375, 23);
            this.tb_TossingReason.TabIndex = 362;
            // 
            // cbPressPrimEnable
            // 
            this.cbPressPrimEnable.AutoSize = true;
            this.cbPressPrimEnable.Location = new System.Drawing.Point(62, 17);
            this.cbPressPrimEnable.Name = "cbPressPrimEnable";
            this.cbPressPrimEnable.Size = new System.Drawing.Size(135, 21);
            this.cbPressPrimEnable.TabIndex = 361;
            this.cbPressPrimEnable.Text = "曲线显示基元名称：";
            this.cbPressPrimEnable.UseVisualStyleBackColor = true;
            // 
            // tbServicePrimName
            // 
            this.tbServicePrimName.Location = new System.Drawing.Point(210, 50);
            this.tbServicePrimName.Margin = new System.Windows.Forms.Padding(1);
            this.tbServicePrimName.Name = "tbServicePrimName";
            this.tbServicePrimName.Size = new System.Drawing.Size(140, 23);
            this.tbServicePrimName.TabIndex = 357;
            // 
            // lb_ServerPrism
            // 
            this.lb_ServerPrism.AutoSize = true;
            this.lb_ServerPrism.Location = new System.Drawing.Point(36, 53);
            this.lb_ServerPrism.Name = "lb_ServerPrism";
            this.lb_ServerPrism.Size = new System.Drawing.Size(160, 17);
            this.lb_ServerPrism.TabIndex = 356;
            this.lb_ServerPrism.Text = "服务器基元(用于产品切换)：";
            this.lb_ServerPrism.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPressPrimName
            // 
            this.tbPressPrimName.Location = new System.Drawing.Point(210, 15);
            this.tbPressPrimName.Margin = new System.Windows.Forms.Padding(1);
            this.tbPressPrimName.Name = "tbPressPrimName";
            this.tbPressPrimName.Size = new System.Drawing.Size(375, 23);
            this.tbPressPrimName.TabIndex = 337;
            // 
            // lb_Tip_RestartSoftware
            // 
            this.lb_Tip_RestartSoftware.AutoSize = true;
            this.lb_Tip_RestartSoftware.Location = new System.Drawing.Point(362, 53);
            this.lb_Tip_RestartSoftware.Name = "lb_Tip_RestartSoftware";
            this.lb_Tip_RestartSoftware.Size = new System.Drawing.Size(104, 17);
            this.lb_Tip_RestartSoftware.TabIndex = 360;
            this.lb_Tip_RestartSoftware.Text = "（需要重启软件）";
            this.lb_Tip_RestartSoftware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpPath
            // 
            this.tpPath.Controls.Add(this.dudDirectory2);
            this.tpPath.Controls.Add(this.dudDirectory1);
            this.tpPath.Controls.Add(this.lb_Prims);
            this.tpPath.Controls.Add(this.chkDisConfigEnable);
            this.tpPath.Controls.Add(this.btnBrowsePDCAPath);
            this.tpPath.Controls.Add(this.chkFaiConfigEnable);
            this.tpPath.Controls.Add(this.btnBrowseSFLPath);
            this.tpPath.Controls.Add(this.chkCommonDynamicParamEnable);
            this.tpPath.Controls.Add(this.btnBrowseMachineDataPath);
            this.tpPath.Controls.Add(this.chkDynamicParamEnable);
            this.tpPath.Controls.Add(this.btnBrowseMachinePath);
            this.tpPath.Controls.Add(this.chkCmpTrigConfigEnable);
            this.tpPath.Controls.Add(this.txtDirectory2);
            this.tpPath.Controls.Add(this.txtDirectory1);
            this.tpPath.Controls.Add(this.tbMachineData);
            this.tpPath.Controls.Add(this.chkTasksConfigEnable);
            this.tpPath.Controls.Add(this.tbSFLPath);
            this.tpPath.Controls.Add(this.chkElesConfigEnable);
            this.tpPath.Controls.Add(this.tbMachinePath);
            this.tpPath.Controls.Add(this.chkShowConfigEnable);
            this.tpPath.Controls.Add(this.tbPDCAPath);
            this.tpPath.Controls.Add(this.chkPrimsConfigEnable);
            this.tpPath.Controls.Add(this.lb_Log_PDCA);
            this.tpPath.Controls.Add(this.btnBrowseDisConfigPath);
            this.tpPath.Controls.Add(this.lblDirectory2);
            this.tpPath.Controls.Add(this.lblDirectory1);
            this.tpPath.Controls.Add(this.lb_ProductionData);
            this.tpPath.Controls.Add(this.btnBrowseComplexQueryTaskFilePath);
            this.tpPath.Controls.Add(this.lb_Log_Machine);
            this.tpPath.Controls.Add(this.btnBrowseFaiConfigPath);
            this.tpPath.Controls.Add(this.lb_Log_SFL);
            this.tpPath.Controls.Add(this.btnBrowseDynamicParamDir);
            this.tpPath.Controls.Add(this.tbDispenserConfigPath);
            this.tpPath.Controls.Add(this.btnBrowseCmpTrigFile);
            this.tpPath.Controls.Add(this.tbComplexQueryTaskFilePath);
            this.tpPath.Controls.Add(this.btnBrowseTasksFile);
            this.tpPath.Controls.Add(this.tbFaiConfigPath);
            this.tpPath.Controls.Add(this.btnBrowseElesFile);
            this.tpPath.Controls.Add(this.tbDynamicParamDirPath);
            this.tpPath.Controls.Add(this.btnBrowseDisplayFile);
            this.tpPath.Controls.Add(this.tbCmpTrigsConfigPath);
            this.tpPath.Controls.Add(this.btnBrowsePrimsFile);
            this.tpPath.Controls.Add(this.tbTasksConfigPath);
            this.tpPath.Controls.Add(this.lb_Display);
            this.tpPath.Controls.Add(this.tbElesConfigPath);
            this.tpPath.Controls.Add(this.lb_Element);
            this.tpPath.Controls.Add(this.tbShowConfigPath);
            this.tpPath.Controls.Add(this.lb_Task);
            this.tpPath.Controls.Add(this.tbPrimsConfigPath);
            this.tpPath.Controls.Add(this.lb_Trig);
            this.tpPath.Controls.Add(this.lb_Dispensing);
            this.tpPath.Controls.Add(this.lb_ParameterFilePath);
            this.tpPath.Controls.Add(this.lb_ComplexFai);
            this.tpPath.Controls.Add(this.lb_Fai);
            this.tpPath.Location = new System.Drawing.Point(4, 26);
            this.tpPath.MinimumSize = new System.Drawing.Size(49, 49);
            this.tpPath.Name = "tpPath";
            this.tpPath.Size = new System.Drawing.Size(1262, 585);
            this.tpPath.TabIndex = 1;
            this.tpPath.Text = "功能路径";
            // 
            // lb_Prims
            // 
            this.lb_Prims.AutoSize = true;
            this.lb_Prims.Location = new System.Drawing.Point(20, 20);
            this.lb_Prims.Name = "lb_Prims";
            this.lb_Prims.Size = new System.Drawing.Size(44, 17);
            this.lb_Prims.TabIndex = 323;
            this.lb_Prims.Text = "基元：";
            this.lb_Prims.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDisConfigEnable
            // 
            this.chkDisConfigEnable.AutoSize = true;
            this.chkDisConfigEnable.Location = new System.Drawing.Point(533, 260);
            this.chkDisConfigEnable.Name = "chkDisConfigEnable";
            this.chkDisConfigEnable.Size = new System.Drawing.Size(51, 21);
            this.chkDisConfigEnable.TabIndex = 388;
            this.chkDisConfigEnable.Text = "启用";
            // 
            // btnBrowsePDCAPath
            // 
            this.btnBrowsePDCAPath.Location = new System.Drawing.Point(495, 357);
            this.btnBrowsePDCAPath.Name = "btnBrowsePDCAPath";
            this.btnBrowsePDCAPath.Size = new System.Drawing.Size(35, 24);
            this.btnBrowsePDCAPath.TabIndex = 400;
            this.btnBrowsePDCAPath.Text = "...";
            this.btnBrowsePDCAPath.Click += new System.EventHandler(this.btnBrowsePDCAPath_Click);
            // 
            // chkFaiConfigEnable
            // 
            this.chkFaiConfigEnable.AutoSize = true;
            this.chkFaiConfigEnable.Location = new System.Drawing.Point(533, 199);
            this.chkFaiConfigEnable.Name = "chkFaiConfigEnable";
            this.chkFaiConfigEnable.Size = new System.Drawing.Size(51, 21);
            this.chkFaiConfigEnable.TabIndex = 387;
            this.chkFaiConfigEnable.Text = "启用";
            // 
            // btnBrowseSFLPath
            // 
            this.btnBrowseSFLPath.Location = new System.Drawing.Point(495, 327);
            this.btnBrowseSFLPath.Name = "btnBrowseSFLPath";
            this.btnBrowseSFLPath.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseSFLPath.TabIndex = 399;
            this.btnBrowseSFLPath.Text = "...";
            this.btnBrowseSFLPath.Click += new System.EventHandler(this.btnBrowseSFLPath_Click);
            // 
            // chkCommonDynamicParamEnable
            // 
            this.chkCommonDynamicParamEnable.AutoSize = true;
            this.chkCommonDynamicParamEnable.Location = new System.Drawing.Point(636, 169);
            this.chkCommonDynamicParamEnable.Name = "chkCommonDynamicParamEnable";
            this.chkCommonDynamicParamEnable.Size = new System.Drawing.Size(99, 21);
            this.chkCommonDynamicParamEnable.TabIndex = 386;
            this.chkCommonDynamicParamEnable.Text = "全局参数启用";
            // 
            // btnBrowseMachineDataPath
            // 
            this.btnBrowseMachineDataPath.Location = new System.Drawing.Point(495, 417);
            this.btnBrowseMachineDataPath.Name = "btnBrowseMachineDataPath";
            this.btnBrowseMachineDataPath.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseMachineDataPath.TabIndex = 398;
            this.btnBrowseMachineDataPath.Text = "...";
            this.btnBrowseMachineDataPath.Click += new System.EventHandler(this.btnBrowseMachineDataPath_Click);
            // 
            // chkDynamicParamEnable
            // 
            this.chkDynamicParamEnable.AutoSize = true;
            this.chkDynamicParamEnable.Location = new System.Drawing.Point(533, 168);
            this.chkDynamicParamEnable.Name = "chkDynamicParamEnable";
            this.chkDynamicParamEnable.Size = new System.Drawing.Size(99, 21);
            this.chkDynamicParamEnable.TabIndex = 385;
            this.chkDynamicParamEnable.Text = "换型参数启用";
            // 
            // btnBrowseMachinePath
            // 
            this.btnBrowseMachinePath.Location = new System.Drawing.Point(495, 387);
            this.btnBrowseMachinePath.Name = "btnBrowseMachinePath";
            this.btnBrowseMachinePath.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseMachinePath.TabIndex = 397;
            this.btnBrowseMachinePath.Text = "...";
            this.btnBrowseMachinePath.Click += new System.EventHandler(this.btnBrowseMachinePath_Click);
            // 
            // chkCmpTrigConfigEnable
            // 
            this.chkCmpTrigConfigEnable.AutoSize = true;
            this.chkCmpTrigConfigEnable.Location = new System.Drawing.Point(533, 137);
            this.chkCmpTrigConfigEnable.Name = "chkCmpTrigConfigEnable";
            this.chkCmpTrigConfigEnable.Size = new System.Drawing.Size(51, 21);
            this.chkCmpTrigConfigEnable.TabIndex = 384;
            this.chkCmpTrigConfigEnable.Text = "启用";
            // 
            // tbMachineData
            // 
            this.tbMachineData.Location = new System.Drawing.Point(141, 417);
            this.tbMachineData.Margin = new System.Windows.Forms.Padding(1);
            this.tbMachineData.Name = "tbMachineData";
            this.tbMachineData.Size = new System.Drawing.Size(349, 23);
            this.tbMachineData.TabIndex = 396;
            // 
            // chkTasksConfigEnable
            // 
            this.chkTasksConfigEnable.AutoSize = true;
            this.chkTasksConfigEnable.Location = new System.Drawing.Point(533, 108);
            this.chkTasksConfigEnable.Name = "chkTasksConfigEnable";
            this.chkTasksConfigEnable.Size = new System.Drawing.Size(51, 21);
            this.chkTasksConfigEnable.TabIndex = 383;
            this.chkTasksConfigEnable.Text = "启用";
            // 
            // tbSFLPath
            // 
            this.tbSFLPath.Location = new System.Drawing.Point(141, 328);
            this.tbSFLPath.Margin = new System.Windows.Forms.Padding(1);
            this.tbSFLPath.Name = "tbSFLPath";
            this.tbSFLPath.Size = new System.Drawing.Size(349, 23);
            this.tbSFLPath.TabIndex = 395;
            // 
            // chkElesConfigEnable
            // 
            this.chkElesConfigEnable.AutoSize = true;
            this.chkElesConfigEnable.Location = new System.Drawing.Point(533, 79);
            this.chkElesConfigEnable.Name = "chkElesConfigEnable";
            this.chkElesConfigEnable.Size = new System.Drawing.Size(51, 21);
            this.chkElesConfigEnable.TabIndex = 382;
            this.chkElesConfigEnable.Text = "启用";
            // 
            // tbMachinePath
            // 
            this.tbMachinePath.Location = new System.Drawing.Point(141, 388);
            this.tbMachinePath.Margin = new System.Windows.Forms.Padding(1);
            this.tbMachinePath.Name = "tbMachinePath";
            this.tbMachinePath.Size = new System.Drawing.Size(349, 23);
            this.tbMachinePath.TabIndex = 394;
            // 
            // chkShowConfigEnable
            // 
            this.chkShowConfigEnable.AutoSize = true;
            this.chkShowConfigEnable.Location = new System.Drawing.Point(533, 48);
            this.chkShowConfigEnable.Name = "chkShowConfigEnable";
            this.chkShowConfigEnable.Size = new System.Drawing.Size(51, 21);
            this.chkShowConfigEnable.TabIndex = 381;
            this.chkShowConfigEnable.Text = "启用";
            // 
            // tbPDCAPath
            // 
            this.tbPDCAPath.Location = new System.Drawing.Point(141, 359);
            this.tbPDCAPath.Margin = new System.Windows.Forms.Padding(1);
            this.tbPDCAPath.Name = "tbPDCAPath";
            this.tbPDCAPath.Size = new System.Drawing.Size(349, 23);
            this.tbPDCAPath.TabIndex = 393;
            // 
            // chkPrimsConfigEnable
            // 
            this.chkPrimsConfigEnable.AutoSize = true;
            this.chkPrimsConfigEnable.Location = new System.Drawing.Point(533, 17);
            this.chkPrimsConfigEnable.Name = "chkPrimsConfigEnable";
            this.chkPrimsConfigEnable.Size = new System.Drawing.Size(51, 21);
            this.chkPrimsConfigEnable.TabIndex = 380;
            this.chkPrimsConfigEnable.Text = "启用";
            // 
            // lb_Log_PDCA
            // 
            this.lb_Log_PDCA.AutoSize = true;
            this.lb_Log_PDCA.Location = new System.Drawing.Point(20, 361);
            this.lb_Log_PDCA.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_Log_PDCA.Name = "lb_Log_PDCA";
            this.lb_Log_PDCA.Size = new System.Drawing.Size(76, 17);
            this.lb_Log_PDCA.TabIndex = 392;
            this.lb_Log_PDCA.Text = "PDCA日志：";
            this.lb_Log_PDCA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseDisConfigPath
            // 
            this.btnBrowseDisConfigPath.Location = new System.Drawing.Point(495, 257);
            this.btnBrowseDisConfigPath.Name = "btnBrowseDisConfigPath";
            this.btnBrowseDisConfigPath.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseDisConfigPath.TabIndex = 379;
            this.btnBrowseDisConfigPath.Text = "...";
            this.btnBrowseDisConfigPath.Click += new System.EventHandler(this.btnBrowseDisConfigPath_Click);
            // 
            // lb_ProductionData
            // 
            this.lb_ProductionData.AutoSize = true;
            this.lb_ProductionData.Location = new System.Drawing.Point(20, 421);
            this.lb_ProductionData.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_ProductionData.Name = "lb_ProductionData";
            this.lb_ProductionData.Size = new System.Drawing.Size(68, 17);
            this.lb_ProductionData.TabIndex = 391;
            this.lb_ProductionData.Text = "机台数据：";
            this.lb_ProductionData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseComplexQueryTaskFilePath
            // 
            this.btnBrowseComplexQueryTaskFilePath.Location = new System.Drawing.Point(495, 225);
            this.btnBrowseComplexQueryTaskFilePath.Name = "btnBrowseComplexQueryTaskFilePath";
            this.btnBrowseComplexQueryTaskFilePath.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseComplexQueryTaskFilePath.TabIndex = 378;
            this.btnBrowseComplexQueryTaskFilePath.Text = "...";
            this.btnBrowseComplexQueryTaskFilePath.Click += new System.EventHandler(this.btnBrowseComplexQueryTaskFile_Click);
            // 
            // lb_Log_Machine
            // 
            this.lb_Log_Machine.AutoSize = true;
            this.lb_Log_Machine.Location = new System.Drawing.Point(20, 391);
            this.lb_Log_Machine.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_Log_Machine.Name = "lb_Log_Machine";
            this.lb_Log_Machine.Size = new System.Drawing.Size(93, 17);
            this.lb_Log_Machine.TabIndex = 390;
            this.lb_Log_Machine.Text = "Machine日志：";
            this.lb_Log_Machine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseFaiConfigPath
            // 
            this.btnBrowseFaiConfigPath.Location = new System.Drawing.Point(495, 197);
            this.btnBrowseFaiConfigPath.Name = "btnBrowseFaiConfigPath";
            this.btnBrowseFaiConfigPath.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseFaiConfigPath.TabIndex = 377;
            this.btnBrowseFaiConfigPath.Text = "...";
            this.btnBrowseFaiConfigPath.Click += new System.EventHandler(this.btnBrowseFaiConfigPath_Click);
            // 
            // lb_Log_SFL
            // 
            this.lb_Log_SFL.AutoSize = true;
            this.lb_Log_SFL.Location = new System.Drawing.Point(20, 331);
            this.lb_Log_SFL.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_Log_SFL.Name = "lb_Log_SFL";
            this.lb_Log_SFL.Size = new System.Drawing.Size(63, 17);
            this.lb_Log_SFL.TabIndex = 389;
            this.lb_Log_SFL.Text = "SFL日志：";
            this.lb_Log_SFL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseDynamicParamDir
            // 
            this.btnBrowseDynamicParamDir.Location = new System.Drawing.Point(495, 167);
            this.btnBrowseDynamicParamDir.Name = "btnBrowseDynamicParamDir";
            this.btnBrowseDynamicParamDir.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseDynamicParamDir.TabIndex = 376;
            this.btnBrowseDynamicParamDir.Text = "...";
            this.btnBrowseDynamicParamDir.Click += new System.EventHandler(this.btnBrowseDynamicParamDir_Click);
            // 
            // tbDispenserConfigPath
            // 
            this.tbDispenserConfigPath.Location = new System.Drawing.Point(141, 257);
            this.tbDispenserConfigPath.Margin = new System.Windows.Forms.Padding(1);
            this.tbDispenserConfigPath.Name = "tbDispenserConfigPath";
            this.tbDispenserConfigPath.Size = new System.Drawing.Size(349, 23);
            this.tbDispenserConfigPath.TabIndex = 370;
            // 
            // btnBrowseCmpTrigFile
            // 
            this.btnBrowseCmpTrigFile.Location = new System.Drawing.Point(495, 136);
            this.btnBrowseCmpTrigFile.Name = "btnBrowseCmpTrigFile";
            this.btnBrowseCmpTrigFile.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseCmpTrigFile.TabIndex = 375;
            this.btnBrowseCmpTrigFile.Text = "...";
            this.btnBrowseCmpTrigFile.Click += new System.EventHandler(this.btnBrowseCmpTrigFile_Click);
            // 
            // tbComplexQueryTaskFilePath
            // 
            this.tbComplexQueryTaskFilePath.Location = new System.Drawing.Point(141, 227);
            this.tbComplexQueryTaskFilePath.Name = "tbComplexQueryTaskFilePath";
            this.tbComplexQueryTaskFilePath.Size = new System.Drawing.Size(349, 23);
            this.tbComplexQueryTaskFilePath.TabIndex = 369;
            // 
            // btnBrowseTasksFile
            // 
            this.btnBrowseTasksFile.Location = new System.Drawing.Point(495, 105);
            this.btnBrowseTasksFile.Name = "btnBrowseTasksFile";
            this.btnBrowseTasksFile.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseTasksFile.TabIndex = 374;
            this.btnBrowseTasksFile.Text = "...";
            this.btnBrowseTasksFile.Click += new System.EventHandler(this.btnBrowseTasksFile_Click);
            // 
            // tbFaiConfigPath
            // 
            this.tbFaiConfigPath.Location = new System.Drawing.Point(141, 197);
            this.tbFaiConfigPath.Name = "tbFaiConfigPath";
            this.tbFaiConfigPath.Size = new System.Drawing.Size(349, 23);
            this.tbFaiConfigPath.TabIndex = 368;
            // 
            // btnBrowseElesFile
            // 
            this.btnBrowseElesFile.Location = new System.Drawing.Point(495, 76);
            this.btnBrowseElesFile.Name = "btnBrowseElesFile";
            this.btnBrowseElesFile.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseElesFile.TabIndex = 373;
            this.btnBrowseElesFile.Text = "...";
            this.btnBrowseElesFile.Click += new System.EventHandler(this.btnBrowseElesFile_Click);
            // 
            // tbDynamicParamDirPath
            // 
            this.tbDynamicParamDirPath.Location = new System.Drawing.Point(141, 167);
            this.tbDynamicParamDirPath.Name = "tbDynamicParamDirPath";
            this.tbDynamicParamDirPath.Size = new System.Drawing.Size(349, 23);
            this.tbDynamicParamDirPath.TabIndex = 367;
            // 
            // btnBrowseDisplayFile
            // 
            this.btnBrowseDisplayFile.Location = new System.Drawing.Point(495, 47);
            this.btnBrowseDisplayFile.Name = "btnBrowseDisplayFile";
            this.btnBrowseDisplayFile.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseDisplayFile.TabIndex = 372;
            this.btnBrowseDisplayFile.Text = "...";
            this.btnBrowseDisplayFile.Click += new System.EventHandler(this.BtnBrowseDisplayFile_Click);
            // 
            // tbCmpTrigsConfigPath
            // 
            this.tbCmpTrigsConfigPath.Location = new System.Drawing.Point(141, 137);
            this.tbCmpTrigsConfigPath.Name = "tbCmpTrigsConfigPath";
            this.tbCmpTrigsConfigPath.Size = new System.Drawing.Size(349, 23);
            this.tbCmpTrigsConfigPath.TabIndex = 366;
            // 
            // btnBrowsePrimsFile
            // 
            this.btnBrowsePrimsFile.Location = new System.Drawing.Point(495, 16);
            this.btnBrowsePrimsFile.Name = "btnBrowsePrimsFile";
            this.btnBrowsePrimsFile.Size = new System.Drawing.Size(35, 24);
            this.btnBrowsePrimsFile.TabIndex = 371;
            this.btnBrowsePrimsFile.Text = "...";
            this.btnBrowsePrimsFile.Click += new System.EventHandler(this.btnBrowsePrimsFile_Click);
            // 
            // tbTasksConfigPath
            // 
            this.tbTasksConfigPath.Location = new System.Drawing.Point(141, 107);
            this.tbTasksConfigPath.Name = "tbTasksConfigPath";
            this.tbTasksConfigPath.Size = new System.Drawing.Size(349, 23);
            this.tbTasksConfigPath.TabIndex = 365;
            // 
            // lb_Display
            // 
            this.lb_Display.AutoSize = true;
            this.lb_Display.Location = new System.Drawing.Point(20, 49);
            this.lb_Display.Name = "lb_Display";
            this.lb_Display.Size = new System.Drawing.Size(44, 17);
            this.lb_Display.TabIndex = 354;
            this.lb_Display.Text = "显示：";
            this.lb_Display.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbElesConfigPath
            // 
            this.tbElesConfigPath.Location = new System.Drawing.Point(141, 77);
            this.tbElesConfigPath.Name = "tbElesConfigPath";
            this.tbElesConfigPath.Size = new System.Drawing.Size(349, 23);
            this.tbElesConfigPath.TabIndex = 364;
            // 
            // lb_Element
            // 
            this.lb_Element.AutoSize = true;
            this.lb_Element.Location = new System.Drawing.Point(20, 80);
            this.lb_Element.Name = "lb_Element";
            this.lb_Element.Size = new System.Drawing.Size(44, 17);
            this.lb_Element.TabIndex = 355;
            this.lb_Element.Text = "元件：";
            this.lb_Element.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbShowConfigPath
            // 
            this.tbShowConfigPath.Location = new System.Drawing.Point(141, 47);
            this.tbShowConfigPath.Name = "tbShowConfigPath";
            this.tbShowConfigPath.Size = new System.Drawing.Size(349, 23);
            this.tbShowConfigPath.TabIndex = 363;
            // 
            // lb_Task
            // 
            this.lb_Task.AutoSize = true;
            this.lb_Task.Location = new System.Drawing.Point(20, 111);
            this.lb_Task.Name = "lb_Task";
            this.lb_Task.Size = new System.Drawing.Size(44, 17);
            this.lb_Task.TabIndex = 356;
            this.lb_Task.Text = "任务：";
            this.lb_Task.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPrimsConfigPath
            // 
            this.tbPrimsConfigPath.Location = new System.Drawing.Point(141, 17);
            this.tbPrimsConfigPath.Name = "tbPrimsConfigPath";
            this.tbPrimsConfigPath.Size = new System.Drawing.Size(349, 23);
            this.tbPrimsConfigPath.TabIndex = 362;
            // 
            // lb_Trig
            // 
            this.lb_Trig.AutoSize = true;
            this.lb_Trig.Location = new System.Drawing.Point(20, 140);
            this.lb_Trig.Name = "lb_Trig";
            this.lb_Trig.Size = new System.Drawing.Size(92, 17);
            this.lb_Trig.TabIndex = 357;
            this.lb_Trig.Text = "脉冲比较功能：";
            this.lb_Trig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Dispensing
            // 
            this.lb_Dispensing.AutoSize = true;
            this.lb_Dispensing.Location = new System.Drawing.Point(20, 260);
            this.lb_Dispensing.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lb_Dispensing.Name = "lb_Dispensing";
            this.lb_Dispensing.Size = new System.Drawing.Size(44, 17);
            this.lb_Dispensing.TabIndex = 361;
            this.lb_Dispensing.Text = "点胶：";
            this.lb_Dispensing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_ParameterFilePath
            // 
            this.lb_ParameterFilePath.AutoSize = true;
            this.lb_ParameterFilePath.Location = new System.Drawing.Point(20, 169);
            this.lb_ParameterFilePath.Name = "lb_ParameterFilePath";
            this.lb_ParameterFilePath.Size = new System.Drawing.Size(68, 17);
            this.lb_ParameterFilePath.TabIndex = 358;
            this.lb_ParameterFilePath.Text = "参数目录：";
            this.lb_ParameterFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_ComplexFai
            // 
            this.lb_ComplexFai.AutoSize = true;
            this.lb_ComplexFai.Location = new System.Drawing.Point(20, 231);
            this.lb_ComplexFai.Name = "lb_ComplexFai";
            this.lb_ComplexFai.Size = new System.Drawing.Size(116, 17);
            this.lb_ComplexFai.TabIndex = 360;
            this.lb_ComplexFai.Text = "复杂查询任务路径：";
            this.lb_ComplexFai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Fai
            // 
            this.lb_Fai.AutoSize = true;
            this.lb_Fai.Location = new System.Drawing.Point(20, 200);
            this.lb_Fai.Name = "lb_Fai";
            this.lb_Fai.Size = new System.Drawing.Size(62, 17);
            this.lb_Fai.TabIndex = 359;
            this.lb_Fai.Text = "FAI参数：";
            this.lb_Fai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDirectory1
            // 
            this.lblDirectory1.AutoSize = true;
            this.lblDirectory1.Location = new System.Drawing.Point(20, 471);
            this.lblDirectory1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblDirectory1.Name = "lblDirectory1";
            this.lblDirectory1.Size = new System.Drawing.Size(99, 17);
            this.lblDirectory1.TabIndex = 391;
            this.lblDirectory1.Text = "自动删除文件夹1";
            this.lblDirectory1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDirectory1
            // 
            this.txtDirectory1.Location = new System.Drawing.Point(141, 454);
            this.txtDirectory1.Margin = new System.Windows.Forms.Padding(1);
            this.txtDirectory1.Multiline = true;
            this.txtDirectory1.Name = "txtDirectory1";
            this.txtDirectory1.Size = new System.Drawing.Size(349, 50);
            this.txtDirectory1.TabIndex = 396;
            // 
            // dudDirectory1
            // 
            this.dudDirectory1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dudDirectory1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dudDirectory1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dudDirectory1.Location = new System.Drawing.Point(495, 466);
            this.dudDirectory1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dudDirectory1.MinimumSize = new System.Drawing.Size(100, 0);
            this.dudDirectory1.Name = "dudDirectory1";
            this.dudDirectory1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dudDirectory1.ShowText = false;
            this.dudDirectory1.Size = new System.Drawing.Size(100, 26);
            this.dudDirectory1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.dudDirectory1.TabIndex = 401;
            this.dudDirectory1.Text = "uiDoubleUpDown1";
            this.dudDirectory1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dudDirectory1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblDirectory2
            // 
            this.lblDirectory2.AutoSize = true;
            this.lblDirectory2.Location = new System.Drawing.Point(20, 526);
            this.lblDirectory2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblDirectory2.Name = "lblDirectory2";
            this.lblDirectory2.Size = new System.Drawing.Size(99, 17);
            this.lblDirectory2.TabIndex = 391;
            this.lblDirectory2.Text = "自动删除文件夹2";
            this.lblDirectory2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDirectory2
            // 
            this.txtDirectory2.Location = new System.Drawing.Point(141, 509);
            this.txtDirectory2.Margin = new System.Windows.Forms.Padding(1);
            this.txtDirectory2.Multiline = true;
            this.txtDirectory2.Name = "txtDirectory2";
            this.txtDirectory2.Size = new System.Drawing.Size(349, 50);
            this.txtDirectory2.TabIndex = 396;
            // 
            // dudDirectory2
            // 
            this.dudDirectory2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dudDirectory2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dudDirectory2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dudDirectory2.Location = new System.Drawing.Point(495, 521);
            this.dudDirectory2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dudDirectory2.MinimumSize = new System.Drawing.Size(100, 0);
            this.dudDirectory2.Name = "dudDirectory2";
            this.dudDirectory2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dudDirectory2.ShowText = false;
            this.dudDirectory2.Size = new System.Drawing.Size(100, 26);
            this.dudDirectory2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.dudDirectory2.TabIndex = 401;
            this.dudDirectory2.Text = "uiDoubleUpDown1";
            this.dudDirectory2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dudDirectory2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tmrOneHour
            // 
            this.tmrOneHour.Tick += new System.EventHandler(this.tmrOneHour_Tick);
            // 
            // SoftwareConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpMain);
            this.Name = "SoftwareConfigControl";
            this.Size = new System.Drawing.Size(1276, 651);
            this.Load += new System.EventHandler(this.TrigTableControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tsStationsConfig.ResumeLayout(false);
            this.tsStationsConfig.PerformLayout();
            this.tabSwConfig.ResumeLayout(false);
            this.tpConfig.ResumeLayout(false);
            this.tpConfig.PerformLayout();
            this.tpDisplayParam.ResumeLayout(false);
            this.tpDisplayParam.PerformLayout();
            this.tpPath.ResumeLayout(false);
            this.tpPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpMain;
        private TabControl tabSwConfig;
        private TabPage tpConfig;
        private TabPage tpPath;
        private ToolStrip tsStationsConfig;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripLabel tsl_ConfigFilePath;
        private ToolStripTextBox tsTbSWConfigFilePath;
        private ToolStripButton tsBtnOpenConfigFilePath;
        private ToolStripButton tsBtnLoadStationsConfig;
        private Label lb_SoftwareInfo;
        private TextBox tbSWDescription;
        private CheckBox chkRemoteRecipeShiftEnable;
        private Label lb_SoftwareName;
        private TextBox tbSwName;
        private Label lb_PermissionLogoutTimeout;
        private CheckBox chkBootInit;
        private CheckBox chkBootRun;
        private CheckBox chkTrackingEnable;
        private Label kryptonLabel9;
        private ComboBox cmbLanguage;
        private Label lbProducts;
        private ComboBox cmbProducts;
        private Button btnAddProduct;
        private Button btnRemoveProduct;
        private Label lb_SystemType;
        private ComboBox cmbSWType;
        private CheckBox chkRemoteQualificationEnable;
        private TextBox tbExitPermissionTime;
        private TextBox tbSuperClientName;
        private Label lb_ChangeRepiceSuperClientName;
        private ComboBox cbTaskLogUINo;
        private Label lb_NumberOfTaskLogUI;
        private Label lb_Prims;
        private Label lb_Display;
        private Label lb_Fai;
        private Label lb_ParameterFilePath;
        private Label lb_Trig;
        private Label lb_Task;
        private Label lb_Element;
        private Label lb_ComplexFai;
        private Label lb_Dispensing;
        private TextBox tbDispenserConfigPath;
        private TextBox tbComplexQueryTaskFilePath;
        private TextBox tbFaiConfigPath;
        private TextBox tbDynamicParamDirPath;
        private TextBox tbCmpTrigsConfigPath;
        private TextBox tbTasksConfigPath;
        private TextBox tbElesConfigPath;
        private TextBox tbShowConfigPath;
        private TextBox tbPrimsConfigPath;
        private Button btnBrowsePrimsFile;
        private Button btnBrowseDisplayFile;
        private Button btnBrowseElesFile;
        private Button btnBrowseTasksFile;
        private Button btnBrowseCmpTrigFile;
        private Button btnBrowseDynamicParamDir;
        private Button btnBrowseFaiConfigPath;
        private Button btnBrowseComplexQueryTaskFilePath;
        private Button btnBrowseDisConfigPath;
        private CheckBox chkPrimsConfigEnable;
        private CheckBox chkShowConfigEnable;
        private CheckBox chkElesConfigEnable;
        private CheckBox chkTasksConfigEnable;
        private CheckBox chkCmpTrigConfigEnable;
        private CheckBox chkDynamicParamEnable;
        private CheckBox chkCommonDynamicParamEnable;
        private CheckBox chkFaiConfigEnable;
        private CheckBox chkDisConfigEnable;
        private Button btnBrowsePDCAPath;
        private Button btnBrowseSFLPath;
        private Button btnBrowseMachineDataPath;
        private Button btnBrowseMachinePath;
        private TextBox tbMachineData;
        private TextBox tbSFLPath;
        private TextBox tbMachinePath;
        private TextBox tbPDCAPath;
        private Label lb_Log_PDCA;
        private Label lb_ProductionData;
        private Label lb_Log_Machine;
        private Label lb_Log_SFL;
        private TextBox tbTaskVer;
        private Label lb_Taskversion;
        private Label lblDataSave;
        private TabPage tpDisplayParam;
        private CheckBox cbPressPrimEnable;
        private TextBox tbServicePrimName;
        private Label lb_ServerPrism;
        private TextBox tbPressPrimName;
        private Label lb_Tip_RestartSoftware;
        private ComboBox cbDataSave;
        private TextBox txtConfigFrmBindFaiName;
        private Label lb_BindingFAiName;
        private ProxyTools.SunnyUI.Controls.UISymbolButton btnCreateHash;
        private TextBox txtSoftWareHashCode;
        private Label lb_MS_Hash;
        private Label lb_MasterControl;
        private ComboBox cbMasterControl;
        private TextBox txtVisionHashCode;
        private Label lb_VS_Hash;
        private TextBox tbVisionVer;
        private Label lb_VisionSoftwareVersion;
        private TextBox tbVisionPath;
        private Label lb_VisionsoftwareFilePath;
        private TextBox tbVisionName;
        private Label lb_VisionSoftwareName;
        private CheckBox cb_AccessaryNames;
        private Label lb_TossingReasons;
        private TextBox tb_AccessaryNames;
        private TextBox tb_TossingReason;
        private Label lab_AccessaryCodeLength;
        private TextBox tb_AccessaryCodeLength;
        private TextBox txtDirectory1;
        private Label lblDirectory1;
        private Sunny.UI.UIDoubleUpDown dudDirectory2;
        private Sunny.UI.UIDoubleUpDown dudDirectory1;
        private TextBox txtDirectory2;
        private Label lblDirectory2;
        private Timer tmrOneHour;
    }
}
