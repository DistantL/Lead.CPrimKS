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
            this.txtMasterIP = new System.Windows.Forms.TextBox();
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
            this.lbProductParamDirPath = new System.Windows.Forms.Label();
            this.tbProductParamDirPath = new System.Windows.Forms.TextBox();
            this.btnBrowseProductParamDirPath = new System.Windows.Forms.Button();
            this.lbLeadVersionFilePath = new System.Windows.Forms.Label();
            this.tbLeadVersionFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseLeadVersionFilePath = new System.Windows.Forms.Button();
            this.lbTossingStatisticsFilePath = new System.Windows.Forms.Label();
            this.tbTossingStatisticsFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseTossingStatisticsFilePath = new System.Windows.Forms.Button();
            this.lbAlertConfigPath = new System.Windows.Forms.Label();
            this.tbAlertConfigPath = new System.Windows.Forms.TextBox();
            this.btnBrowseAlertConfigPath = new System.Windows.Forms.Button();
            this.button1btnBrowseAdminitionConfigPath = new System.Windows.Forms.Button();
            this.tbAdministonConfigPath = new System.Windows.Forms.TextBox();
            this.lb_Administration = new System.Windows.Forms.Label();
            this.btnBrowseHashKeyConfigPath = new System.Windows.Forms.Button();
            this.tbHashKeyConfigPath = new System.Windows.Forms.TextBox();
            this.lb_Hashkey = new System.Windows.Forms.Label();
            this.btnBrowseGlobSettingConfigPath = new System.Windows.Forms.Button();
            this.tbGlobSettingConfigPath = new System.Windows.Forms.TextBox();
            this.lb_GlobSetting = new System.Windows.Forms.Label();
            this.dudDirectory2 = new Sunny.UI.UIDoubleUpDown();
            this.dudDirectory1 = new Sunny.UI.UIDoubleUpDown();
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
            this.txtDirectory2 = new System.Windows.Forms.TextBox();
            this.txtDirectory1 = new System.Windows.Forms.TextBox();
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
            this.lblDirectory2 = new System.Windows.Forms.Label();
            this.lblDirectory1 = new System.Windows.Forms.Label();
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
            this.tlpMain.Margin = new System.Windows.Forms.Padding(4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1914, 976);
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
            this.tsStationsConfig.Location = new System.Drawing.Point(6, 6);
            this.tsStationsConfig.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.tsStationsConfig.Name = "tsStationsConfig";
            this.tsStationsConfig.Padding = new System.Windows.Forms.Padding(0);
            this.tsStationsConfig.Size = new System.Drawing.Size(1902, 39);
            this.tsStationsConfig.TabIndex = 35;
            this.tsStationsConfig.Text = "脉冲比较触发配置";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // tsl_ConfigFilePath
            // 
            this.tsl_ConfigFilePath.Name = "tsl_ConfigFilePath";
            this.tsl_ConfigFilePath.Size = new System.Drawing.Size(107, 34);
            this.tsl_ConfigFilePath.Text = "配置路径：";
            // 
            // tsTbSWConfigFilePath
            // 
            this.tsTbSWConfigFilePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tsTbSWConfigFilePath.Name = "tsTbSWConfigFilePath";
            this.tsTbSWConfigFilePath.Size = new System.Drawing.Size(898, 39);
            // 
            // tsBtnOpenConfigFilePath
            // 
            this.tsBtnOpenConfigFilePath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnOpenConfigFilePath.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsBtnOpenConfigFilePath.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOpenConfigFilePath.Image")));
            this.tsBtnOpenConfigFilePath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpenConfigFilePath.Name = "tsBtnOpenConfigFilePath";
            this.tsBtnOpenConfigFilePath.Size = new System.Drawing.Size(34, 34);
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
            this.tsBtnLoadStationsConfig.Size = new System.Drawing.Size(60, 34);
            this.tsBtnLoadStationsConfig.Text = "Load";
            this.tsBtnLoadStationsConfig.Click += new System.EventHandler(this.tsBtnLoadSWConfig_Click);
            // 
            // tabSwConfig
            // 
            this.tabSwConfig.Controls.Add(this.tpConfig);
            this.tabSwConfig.Controls.Add(this.tpDisplayParam);
            this.tabSwConfig.Controls.Add(this.tpPath);
            this.tabSwConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSwConfig.Location = new System.Drawing.Point(4, 49);
            this.tabSwConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tabSwConfig.Name = "tabSwConfig";
            this.tabSwConfig.SelectedIndex = 1;
            this.tabSwConfig.Size = new System.Drawing.Size(1906, 923);
            this.tabSwConfig.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSwConfig.TabIndex = 1;
            this.tabSwConfig.Text = "kryptonNavigator1";
            // 
            // tpConfig
            // 
            this.tpConfig.Controls.Add(this.txtMasterIP);
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
            this.tpConfig.Location = new System.Drawing.Point(4, 33);
            this.tpConfig.Margin = new System.Windows.Forms.Padding(4);
            this.tpConfig.MinimumSize = new System.Drawing.Size(74, 74);
            this.tpConfig.Name = "tpConfig";
            this.tpConfig.Size = new System.Drawing.Size(1898, 886);
            this.tpConfig.TabIndex = 0;
            this.tpConfig.Text = "参数设置";
            // 
            // txtMasterIP
            // 
            this.txtMasterIP.Location = new System.Drawing.Point(536, 416);
            this.txtMasterIP.Margin = new System.Windows.Forms.Padding(2);
            this.txtMasterIP.Name = "txtMasterIP";
            this.txtMasterIP.Size = new System.Drawing.Size(198, 31);
            this.txtMasterIP.TabIndex = 345;
            this.txtMasterIP.Text = "localhost";
            // 
            // tbVisionVer
            // 
            this.tbVisionVer.Location = new System.Drawing.Point(1086, 326);
            this.tbVisionVer.Margin = new System.Windows.Forms.Padding(2);
            this.tbVisionVer.Name = "tbVisionVer";
            this.tbVisionVer.Size = new System.Drawing.Size(146, 31);
            this.tbVisionVer.TabIndex = 344;
            // 
            // lb_VisionSoftwareVersion
            // 
            this.lb_VisionSoftwareVersion.AutoSize = true;
            this.lb_VisionSoftwareVersion.Location = new System.Drawing.Point(946, 330);
            this.lb_VisionSoftwareVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_VisionSoftwareVersion.Name = "lb_VisionSoftwareVersion";
            this.lb_VisionSoftwareVersion.Size = new System.Drawing.Size(136, 24);
            this.lb_VisionSoftwareVersion.TabIndex = 343;
            this.lb_VisionSoftwareVersion.Text = "视觉软件版本：";
            this.lb_VisionSoftwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbVisionPath
            // 
            this.tbVisionPath.Location = new System.Drawing.Point(758, 370);
            this.tbVisionPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbVisionPath.Name = "tbVisionPath";
            this.tbVisionPath.Size = new System.Drawing.Size(355, 31);
            this.tbVisionPath.TabIndex = 342;
            // 
            // lb_VisionsoftwareFilePath
            // 
            this.lb_VisionsoftwareFilePath.AutoSize = true;
            this.lb_VisionsoftwareFilePath.Location = new System.Drawing.Point(618, 375);
            this.lb_VisionsoftwareFilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_VisionsoftwareFilePath.Name = "lb_VisionsoftwareFilePath";
            this.lb_VisionsoftwareFilePath.Size = new System.Drawing.Size(136, 24);
            this.lb_VisionsoftwareFilePath.TabIndex = 341;
            this.lb_VisionsoftwareFilePath.Text = "视觉软件路径：";
            this.lb_VisionsoftwareFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbVisionName
            // 
            this.tbVisionName.Location = new System.Drawing.Point(758, 326);
            this.tbVisionName.Margin = new System.Windows.Forms.Padding(2);
            this.tbVisionName.Name = "tbVisionName";
            this.tbVisionName.Size = new System.Drawing.Size(164, 31);
            this.tbVisionName.TabIndex = 340;
            // 
            // lb_VisionSoftwareName
            // 
            this.lb_VisionSoftwareName.AutoSize = true;
            this.lb_VisionSoftwareName.Location = new System.Drawing.Point(618, 330);
            this.lb_VisionSoftwareName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_VisionSoftwareName.Name = "lb_VisionSoftwareName";
            this.lb_VisionSoftwareName.Size = new System.Drawing.Size(136, 24);
            this.lb_VisionSoftwareName.TabIndex = 339;
            this.lb_VisionSoftwareName.Text = "视觉软件名称：";
            this.lb_VisionSoftwareName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVisionHashCode
            // 
            this.txtVisionHashCode.Location = new System.Drawing.Point(177, 656);
            this.txtVisionHashCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtVisionHashCode.Name = "txtVisionHashCode";
            this.txtVisionHashCode.ReadOnly = true;
            this.txtVisionHashCode.Size = new System.Drawing.Size(487, 31);
            this.txtVisionHashCode.TabIndex = 338;
            this.txtVisionHashCode.Text = "1234567890123456789012345678901234567890";
            // 
            // lb_VS_Hash
            // 
            this.lb_VS_Hash.AutoSize = true;
            this.lb_VS_Hash.Location = new System.Drawing.Point(30, 660);
            this.lb_VS_Hash.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_VS_Hash.Name = "lb_VS_Hash";
            this.lb_VS_Hash.Size = new System.Drawing.Size(125, 24);
            this.lb_VS_Hash.TabIndex = 337;
            this.lb_VS_Hash.Text = "视觉Hash码：";
            this.lb_VS_Hash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCreateHash
            // 
            this.btnCreateHash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateHash.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateHash.Location = new System.Drawing.Point(693, 610);
            this.btnCreateHash.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateHash.MinimumSize = new System.Drawing.Size(2, 2);
            this.btnCreateHash.Name = "btnCreateHash";
            this.btnCreateHash.Size = new System.Drawing.Size(111, 80);
            this.btnCreateHash.TabIndex = 336;
            this.btnCreateHash.Text = "生成";
            this.btnCreateHash.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateHash.Visible = false;
            this.btnCreateHash.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCreateHash.Click += new System.EventHandler(this.btnCreateHash_Click);
            // 
            // txtSoftWareHashCode
            // 
            this.txtSoftWareHashCode.Location = new System.Drawing.Point(177, 610);
            this.txtSoftWareHashCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoftWareHashCode.Name = "txtSoftWareHashCode";
            this.txtSoftWareHashCode.ReadOnly = true;
            this.txtSoftWareHashCode.Size = new System.Drawing.Size(487, 31);
            this.txtSoftWareHashCode.TabIndex = 335;
            this.txtSoftWareHashCode.Text = "1234567890123456789012345678901234567890";
            // 
            // txtConfigFrmBindFaiName
            // 
            this.txtConfigFrmBindFaiName.Location = new System.Drawing.Point(314, 550);
            this.txtConfigFrmBindFaiName.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfigFrmBindFaiName.Name = "txtConfigFrmBindFaiName";
            this.txtConfigFrmBindFaiName.Size = new System.Drawing.Size(198, 31);
            this.txtConfigFrmBindFaiName.TabIndex = 335;
            // 
            // tbTaskVer
            // 
            this.tbTaskVer.Location = new System.Drawing.Point(432, 326);
            this.tbTaskVer.Margin = new System.Windows.Forms.Padding(2);
            this.tbTaskVer.Name = "tbTaskVer";
            this.tbTaskVer.Size = new System.Drawing.Size(148, 31);
            this.tbTaskVer.TabIndex = 335;
            // 
            // lb_MS_Hash
            // 
            this.lb_MS_Hash.AutoSize = true;
            this.lb_MS_Hash.Location = new System.Drawing.Point(30, 615);
            this.lb_MS_Hash.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_MS_Hash.Name = "lb_MS_Hash";
            this.lb_MS_Hash.Size = new System.Drawing.Size(143, 24);
            this.lb_MS_Hash.TabIndex = 334;
            this.lb_MS_Hash.Text = "上位机Hash码：";
            this.lb_MS_Hash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_BindingFAiName
            // 
            this.lb_BindingFAiName.AutoSize = true;
            this.lb_BindingFAiName.Location = new System.Drawing.Point(30, 555);
            this.lb_BindingFAiName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_BindingFAiName.Name = "lb_BindingFAiName";
            this.lb_BindingFAiName.Size = new System.Drawing.Size(219, 24);
            this.lb_BindingFAiName.TabIndex = 334;
            this.lb_BindingFAiName.Text = "ConfigFrm绑定FAI名称：";
            this.lb_BindingFAiName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Taskversion
            // 
            this.lb_Taskversion.AutoSize = true;
            this.lb_Taskversion.Location = new System.Drawing.Point(327, 330);
            this.lb_Taskversion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Taskversion.Name = "lb_Taskversion";
            this.lb_Taskversion.Size = new System.Drawing.Size(102, 24);
            this.lb_Taskversion.TabIndex = 334;
            this.lb_Taskversion.Text = "Task版本：";
            this.lb_Taskversion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_SoftwareInfo
            // 
            this.lb_SoftwareInfo.AutoSize = true;
            this.lb_SoftwareInfo.Location = new System.Drawing.Point(30, 30);
            this.lb_SoftwareInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_SoftwareInfo.Name = "lb_SoftwareInfo";
            this.lb_SoftwareInfo.Size = new System.Drawing.Size(100, 24);
            this.lb_SoftwareInfo.TabIndex = 275;
            this.lb_SoftwareInfo.Text = "系统描述：";
            this.lb_SoftwareInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSWDescription
            // 
            this.tbSWDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSWDescription.Location = new System.Drawing.Point(146, 26);
            this.tbSWDescription.Margin = new System.Windows.Forms.Padding(4);
            this.tbSWDescription.Name = "tbSWDescription";
            this.tbSWDescription.Size = new System.Drawing.Size(222, 31);
            this.tbSWDescription.TabIndex = 276;
            this.tbSWDescription.Text = "CPrim";
            // 
            // lblDataSave
            // 
            this.lblDataSave.AutoSize = true;
            this.lblDataSave.Location = new System.Drawing.Point(30, 510);
            this.lblDataSave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataSave.Name = "lblDataSave";
            this.lblDataSave.Size = new System.Drawing.Size(172, 24);
            this.lblDataSave.TabIndex = 301;
            this.lblDataSave.Text = "设备参数定期保存：";
            this.lblDataSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_MasterControl
            // 
            this.lb_MasterControl.AutoSize = true;
            this.lb_MasterControl.Location = new System.Drawing.Point(30, 420);
            this.lb_MasterControl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_MasterControl.Name = "lb_MasterControl";
            this.lb_MasterControl.Size = new System.Drawing.Size(152, 24);
            this.lb_MasterControl.TabIndex = 301;
            this.lb_MasterControl.Text = "MasterControl：";
            this.lb_MasterControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_NumberOfTaskLogUI
            // 
            this.lb_NumberOfTaskLogUI.AutoSize = true;
            this.lb_NumberOfTaskLogUI.Location = new System.Drawing.Point(30, 465);
            this.lb_NumberOfTaskLogUI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_NumberOfTaskLogUI.Name = "lb_NumberOfTaskLogUI";
            this.lb_NumberOfTaskLogUI.Size = new System.Drawing.Size(275, 24);
            this.lb_NumberOfTaskLogUI.TabIndex = 301;
            this.lb_NumberOfTaskLogUI.Text = "任务日志UI数量（支持1/2/4）：";
            this.lb_NumberOfTaskLogUI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkRemoteRecipeShiftEnable
            // 
            this.chkRemoteRecipeShiftEnable.AutoSize = true;
            this.chkRemoteRecipeShiftEnable.Location = new System.Drawing.Point(30, 285);
            this.chkRemoteRecipeShiftEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkRemoteRecipeShiftEnable.Name = "chkRemoteRecipeShiftEnable";
            this.chkRemoteRecipeShiftEnable.Size = new System.Drawing.Size(180, 28);
            this.chkRemoteRecipeShiftEnable.TabIndex = 294;
            this.chkRemoteRecipeShiftEnable.Text = "远程切换配方使能";
            this.chkRemoteRecipeShiftEnable.CheckedChanged += new System.EventHandler(this.chkRemoteRecipeShiftEnable_CheckedChanged);
            // 
            // lb_SoftwareName
            // 
            this.lb_SoftwareName.AutoSize = true;
            this.lb_SoftwareName.Location = new System.Drawing.Point(30, 330);
            this.lb_SoftwareName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_SoftwareName.Name = "lb_SoftwareName";
            this.lb_SoftwareName.Size = new System.Drawing.Size(100, 24);
            this.lb_SoftwareName.TabIndex = 297;
            this.lb_SoftwareName.Text = "软件名称：";
            this.lb_SoftwareName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSwName
            // 
            this.tbSwName.Location = new System.Drawing.Point(144, 326);
            this.tbSwName.Margin = new System.Windows.Forms.Padding(2);
            this.tbSwName.Name = "tbSwName";
            this.tbSwName.Size = new System.Drawing.Size(158, 31);
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
            this.cbDataSave.Location = new System.Drawing.Point(314, 504);
            this.cbDataSave.Margin = new System.Windows.Forms.Padding(4);
            this.cbDataSave.Name = "cbDataSave";
            this.cbDataSave.Size = new System.Drawing.Size(198, 32);
            this.cbDataSave.TabIndex = 302;
            // 
            // cbMasterControl
            // 
            this.cbMasterControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMasterControl.DropDownWidth = 85;
            this.cbMasterControl.Location = new System.Drawing.Point(314, 414);
            this.cbMasterControl.Margin = new System.Windows.Forms.Padding(4);
            this.cbMasterControl.Name = "cbMasterControl";
            this.cbMasterControl.Size = new System.Drawing.Size(198, 32);
            this.cbMasterControl.TabIndex = 302;
            // 
            // lb_PermissionLogoutTimeout
            // 
            this.lb_PermissionLogoutTimeout.AutoSize = true;
            this.lb_PermissionLogoutTimeout.Location = new System.Drawing.Point(30, 375);
            this.lb_PermissionLogoutTimeout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_PermissionLogoutTimeout.Name = "lb_PermissionLogoutTimeout";
            this.lb_PermissionLogoutTimeout.Size = new System.Drawing.Size(226, 24);
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
            this.cbTaskLogUINo.Location = new System.Drawing.Point(314, 459);
            this.cbTaskLogUINo.Margin = new System.Windows.Forms.Padding(4);
            this.cbTaskLogUINo.Name = "cbTaskLogUINo";
            this.cbTaskLogUINo.Size = new System.Drawing.Size(198, 32);
            this.cbTaskLogUINo.TabIndex = 302;
            // 
            // chkBootInit
            // 
            this.chkBootInit.AutoSize = true;
            this.chkBootInit.Location = new System.Drawing.Point(30, 210);
            this.chkBootInit.Margin = new System.Windows.Forms.Padding(4);
            this.chkBootInit.Name = "chkBootInit";
            this.chkBootInit.Size = new System.Drawing.Size(126, 28);
            this.chkBootInit.TabIndex = 291;
            this.chkBootInit.Text = "上电初始化";
            // 
            // chkBootRun
            // 
            this.chkBootRun.AutoSize = true;
            this.chkBootRun.Location = new System.Drawing.Point(300, 210);
            this.chkBootRun.Margin = new System.Windows.Forms.Padding(4);
            this.chkBootRun.Name = "chkBootRun";
            this.chkBootRun.Size = new System.Drawing.Size(108, 28);
            this.chkBootRun.TabIndex = 292;
            this.chkBootRun.Text = "上电启动";
            // 
            // chkTrackingEnable
            // 
            this.chkTrackingEnable.AutoSize = true;
            this.chkTrackingEnable.Location = new System.Drawing.Point(30, 248);
            this.chkTrackingEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkTrackingEnable.Name = "chkTrackingEnable";
            this.chkTrackingEnable.Size = new System.Drawing.Size(182, 28);
            this.chkTrackingEnable.TabIndex = 293;
            this.chkTrackingEnable.Text = "Tracking功能使能";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.AutoSize = true;
            this.kryptonLabel9.Location = new System.Drawing.Point(30, 165);
            this.kryptonLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(64, 24);
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
            this.cmbLanguage.Location = new System.Drawing.Point(146, 159);
            this.cmbLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(222, 32);
            this.cmbLanguage.TabIndex = 290;
            this.cmbLanguage.Visible = false;
            // 
            // lbProducts
            // 
            this.lbProducts.AutoSize = true;
            this.lbProducts.Location = new System.Drawing.Point(30, 120);
            this.lbProducts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(100, 24);
            this.lbProducts.TabIndex = 284;
            this.lbProducts.Text = "产品列表：";
            this.lbProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProducts
            // 
            this.cmbProducts.DropDownWidth = 85;
            this.cmbProducts.Location = new System.Drawing.Point(146, 114);
            this.cmbProducts.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(222, 32);
            this.cmbProducts.TabIndex = 285;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddProduct.Location = new System.Drawing.Point(382, 114);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(60, 38);
            this.btnAddProduct.TabIndex = 286;
            this.btnAddProduct.Text = "+";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveProduct.Location = new System.Drawing.Point(446, 114);
            this.btnRemoveProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(60, 38);
            this.btnRemoveProduct.TabIndex = 287;
            this.btnRemoveProduct.Text = "-";
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // lb_SystemType
            // 
            this.lb_SystemType.AutoSize = true;
            this.lb_SystemType.Location = new System.Drawing.Point(30, 75);
            this.lb_SystemType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_SystemType.Name = "lb_SystemType";
            this.lb_SystemType.Size = new System.Drawing.Size(100, 24);
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
            this.cmbSWType.Location = new System.Drawing.Point(146, 69);
            this.cmbSWType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSWType.Name = "cmbSWType";
            this.cmbSWType.Size = new System.Drawing.Size(222, 32);
            this.cmbSWType.TabIndex = 278;
            // 
            // chkRemoteQualificationEnable
            // 
            this.chkRemoteQualificationEnable.AutoSize = true;
            this.chkRemoteQualificationEnable.Location = new System.Drawing.Point(382, 27);
            this.chkRemoteQualificationEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkRemoteQualificationEnable.Name = "chkRemoteQualificationEnable";
            this.chkRemoteQualificationEnable.Size = new System.Drawing.Size(290, 28);
            this.chkRemoteQualificationEnable.TabIndex = 283;
            this.chkRemoteQualificationEnable.Text = "Remote Qualification功能使能";
            // 
            // tbExitPermissionTime
            // 
            this.tbExitPermissionTime.Location = new System.Drawing.Point(314, 370);
            this.tbExitPermissionTime.Margin = new System.Windows.Forms.Padding(2);
            this.tbExitPermissionTime.Name = "tbExitPermissionTime";
            this.tbExitPermissionTime.Size = new System.Drawing.Size(198, 31);
            this.tbExitPermissionTime.TabIndex = 300;
            // 
            // tbSuperClientName
            // 
            this.tbSuperClientName.Location = new System.Drawing.Point(536, 284);
            this.tbSuperClientName.Margin = new System.Windows.Forms.Padding(2);
            this.tbSuperClientName.Name = "tbSuperClientName";
            this.tbSuperClientName.Size = new System.Drawing.Size(142, 31);
            this.tbSuperClientName.TabIndex = 296;
            // 
            // lb_ChangeRepiceSuperClientName
            // 
            this.lb_ChangeRepiceSuperClientName.AutoSize = true;
            this.lb_ChangeRepiceSuperClientName.Location = new System.Drawing.Point(298, 288);
            this.lb_ChangeRepiceSuperClientName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ChangeRepiceSuperClientName.Name = "lb_ChangeRepiceSuperClientName";
            this.lb_ChangeRepiceSuperClientName.Size = new System.Drawing.Size(218, 24);
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
            this.tpDisplayParam.Location = new System.Drawing.Point(4, 33);
            this.tpDisplayParam.Margin = new System.Windows.Forms.Padding(4);
            this.tpDisplayParam.Name = "tpDisplayParam";
            this.tpDisplayParam.Size = new System.Drawing.Size(1898, 886);
            this.tpDisplayParam.TabIndex = 2;
            this.tpDisplayParam.Text = "界面设置";
            this.tpDisplayParam.UseVisualStyleBackColor = true;
            // 
            // lab_AccessaryCodeLength
            // 
            this.lab_AccessaryCodeLength.AutoSize = true;
            this.lab_AccessaryCodeLength.Location = new System.Drawing.Point(138, 188);
            this.lab_AccessaryCodeLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_AccessaryCodeLength.Name = "lab_AccessaryCodeLength";
            this.lab_AccessaryCodeLength.Size = new System.Drawing.Size(154, 24);
            this.lab_AccessaryCodeLength.TabIndex = 367;
            this.lab_AccessaryCodeLength.Text = "辅料码长度限定：";
            this.lab_AccessaryCodeLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_AccessaryCodeLength
            // 
            this.tb_AccessaryCodeLength.Location = new System.Drawing.Point(315, 183);
            this.tb_AccessaryCodeLength.Margin = new System.Windows.Forms.Padding(2);
            this.tb_AccessaryCodeLength.Name = "tb_AccessaryCodeLength";
            this.tb_AccessaryCodeLength.Size = new System.Drawing.Size(560, 31);
            this.tb_AccessaryCodeLength.TabIndex = 366;
            // 
            // cb_AccessaryNames
            // 
            this.cb_AccessaryNames.AutoSize = true;
            this.cb_AccessaryNames.Location = new System.Drawing.Point(166, 129);
            this.cb_AccessaryNames.Margin = new System.Windows.Forms.Padding(4);
            this.cb_AccessaryNames.Name = "cb_AccessaryNames";
            this.cb_AccessaryNames.Size = new System.Drawing.Size(126, 28);
            this.cb_AccessaryNames.TabIndex = 365;
            this.cb_AccessaryNames.Text = "辅料名称：";
            this.cb_AccessaryNames.UseVisualStyleBackColor = true;
            this.cb_AccessaryNames.CheckedChanged += new System.EventHandler(this.cb_AccessaryNames_CheckedChanged);
            // 
            // lb_TossingReasons
            // 
            this.lb_TossingReasons.AutoSize = true;
            this.lb_TossingReasons.Location = new System.Drawing.Point(174, 242);
            this.lb_TossingReasons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TossingReasons.Name = "lb_TossingReasons";
            this.lb_TossingReasons.Size = new System.Drawing.Size(118, 24);
            this.lb_TossingReasons.TabIndex = 364;
            this.lb_TossingReasons.Text = "抛辅料原因：";
            this.lb_TossingReasons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_AccessaryNames
            // 
            this.tb_AccessaryNames.Location = new System.Drawing.Point(315, 128);
            this.tb_AccessaryNames.Margin = new System.Windows.Forms.Padding(2);
            this.tb_AccessaryNames.Name = "tb_AccessaryNames";
            this.tb_AccessaryNames.Size = new System.Drawing.Size(560, 31);
            this.tb_AccessaryNames.TabIndex = 363;
            // 
            // tb_TossingReason
            // 
            this.tb_TossingReason.Location = new System.Drawing.Point(315, 237);
            this.tb_TossingReason.Margin = new System.Windows.Forms.Padding(2);
            this.tb_TossingReason.Name = "tb_TossingReason";
            this.tb_TossingReason.Size = new System.Drawing.Size(560, 31);
            this.tb_TossingReason.TabIndex = 362;
            // 
            // cbPressPrimEnable
            // 
            this.cbPressPrimEnable.AutoSize = true;
            this.cbPressPrimEnable.Location = new System.Drawing.Point(93, 26);
            this.cbPressPrimEnable.Margin = new System.Windows.Forms.Padding(4);
            this.cbPressPrimEnable.Name = "cbPressPrimEnable";
            this.cbPressPrimEnable.Size = new System.Drawing.Size(198, 28);
            this.cbPressPrimEnable.TabIndex = 361;
            this.cbPressPrimEnable.Text = "曲线显示基元名称：";
            this.cbPressPrimEnable.UseVisualStyleBackColor = true;
            // 
            // tbServicePrimName
            // 
            this.tbServicePrimName.Location = new System.Drawing.Point(315, 75);
            this.tbServicePrimName.Margin = new System.Windows.Forms.Padding(2);
            this.tbServicePrimName.Name = "tbServicePrimName";
            this.tbServicePrimName.Size = new System.Drawing.Size(208, 31);
            this.tbServicePrimName.TabIndex = 357;
            // 
            // lb_ServerPrism
            // 
            this.lb_ServerPrism.AutoSize = true;
            this.lb_ServerPrism.Location = new System.Drawing.Point(54, 80);
            this.lb_ServerPrism.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ServerPrism.Name = "lb_ServerPrism";
            this.lb_ServerPrism.Size = new System.Drawing.Size(238, 24);
            this.lb_ServerPrism.TabIndex = 356;
            this.lb_ServerPrism.Text = "服务器基元(用于产品切换)：";
            this.lb_ServerPrism.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPressPrimName
            // 
            this.tbPressPrimName.Location = new System.Drawing.Point(315, 22);
            this.tbPressPrimName.Margin = new System.Windows.Forms.Padding(2);
            this.tbPressPrimName.Name = "tbPressPrimName";
            this.tbPressPrimName.Size = new System.Drawing.Size(560, 31);
            this.tbPressPrimName.TabIndex = 337;
            // 
            // lb_Tip_RestartSoftware
            // 
            this.lb_Tip_RestartSoftware.AutoSize = true;
            this.lb_Tip_RestartSoftware.Location = new System.Drawing.Point(543, 80);
            this.lb_Tip_RestartSoftware.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Tip_RestartSoftware.Name = "lb_Tip_RestartSoftware";
            this.lb_Tip_RestartSoftware.Size = new System.Drawing.Size(154, 24);
            this.lb_Tip_RestartSoftware.TabIndex = 360;
            this.lb_Tip_RestartSoftware.Text = "（需要重启软件）";
            this.lb_Tip_RestartSoftware.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpPath
            // 
            this.tpPath.AutoScroll = true;
            this.tpPath.Controls.Add(this.lbProductParamDirPath);
            this.tpPath.Controls.Add(this.tbProductParamDirPath);
            this.tpPath.Controls.Add(this.btnBrowseProductParamDirPath);
            this.tpPath.Controls.Add(this.lbLeadVersionFilePath);
            this.tpPath.Controls.Add(this.tbLeadVersionFilePath);
            this.tpPath.Controls.Add(this.btnBrowseLeadVersionFilePath);
            this.tpPath.Controls.Add(this.lbTossingStatisticsFilePath);
            this.tpPath.Controls.Add(this.tbTossingStatisticsFilePath);
            this.tpPath.Controls.Add(this.btnBrowseTossingStatisticsFilePath);
            this.tpPath.Controls.Add(this.lbAlertConfigPath);
            this.tpPath.Controls.Add(this.tbAlertConfigPath);
            this.tpPath.Controls.Add(this.btnBrowseAlertConfigPath);
            this.tpPath.Controls.Add(this.button1btnBrowseAdminitionConfigPath);
            this.tpPath.Controls.Add(this.tbAdministonConfigPath);
            this.tpPath.Controls.Add(this.lb_Administration);
            this.tpPath.Controls.Add(this.btnBrowseHashKeyConfigPath);
            this.tpPath.Controls.Add(this.tbHashKeyConfigPath);
            this.tpPath.Controls.Add(this.lb_Hashkey);
            this.tpPath.Controls.Add(this.btnBrowseGlobSettingConfigPath);
            this.tpPath.Controls.Add(this.tbGlobSettingConfigPath);
            this.tpPath.Controls.Add(this.lb_GlobSetting);
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
            this.tpPath.Location = new System.Drawing.Point(4, 33);
            this.tpPath.Margin = new System.Windows.Forms.Padding(4);
            this.tpPath.MinimumSize = new System.Drawing.Size(74, 74);
            this.tpPath.Name = "tpPath";
            this.tpPath.Size = new System.Drawing.Size(1898, 886);
            this.tpPath.TabIndex = 1;
            this.tpPath.Text = "功能路径";
            // 
            // lbProductParamDirPath
            // 
            this.lbProductParamDirPath.AutoSize = true;
            this.lbProductParamDirPath.Location = new System.Drawing.Point(29, 622);
            this.lbProductParamDirPath.Name = "lbProductParamDirPath";
            this.lbProductParamDirPath.Size = new System.Drawing.Size(122, 24);
            this.lbProductParamDirPath.TabIndex = 0;
            this.lbProductParamDirPath.Text = "换型参数目录:";
            // 
            // tbProductParamDirPath
            // 
            this.tbProductParamDirPath.Location = new System.Drawing.Point(211, 617);
            this.tbProductParamDirPath.Name = "tbProductParamDirPath";
            this.tbProductParamDirPath.Size = new System.Drawing.Size(522, 31);
            this.tbProductParamDirPath.TabIndex = 412;
            // 
            // btnBrowseProductParamDirPath
            // 
            this.btnBrowseProductParamDirPath.Location = new System.Drawing.Point(740, 617);
            this.btnBrowseProductParamDirPath.Name = "btnBrowseProductParamDirPath";
            this.btnBrowseProductParamDirPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseProductParamDirPath.TabIndex = 413;
            this.btnBrowseProductParamDirPath.Text = "...";
            this.btnBrowseProductParamDirPath.Click += new System.EventHandler(this.btnBrowseProductParamDirPath_Click);
            // 
            // lbLeadVersionFilePath
            // 
            this.lbLeadVersionFilePath.AutoSize = true;
            this.lbLeadVersionFilePath.Location = new System.Drawing.Point(29, 668);
            this.lbLeadVersionFilePath.Name = "lbLeadVersionFilePath";
            this.lbLeadVersionFilePath.Size = new System.Drawing.Size(122, 24);
            this.lbLeadVersionFilePath.TabIndex = 414;
            this.lbLeadVersionFilePath.Text = "软件版本文件:";
            // 
            // tbLeadVersionFilePath
            // 
            this.tbLeadVersionFilePath.Location = new System.Drawing.Point(211, 663);
            this.tbLeadVersionFilePath.Name = "tbLeadVersionFilePath";
            this.tbLeadVersionFilePath.Size = new System.Drawing.Size(522, 31);
            this.tbLeadVersionFilePath.TabIndex = 414;
            // 
            // btnBrowseLeadVersionFilePath
            // 
            this.btnBrowseLeadVersionFilePath.Location = new System.Drawing.Point(740, 663);
            this.btnBrowseLeadVersionFilePath.Name = "btnBrowseLeadVersionFilePath";
            this.btnBrowseLeadVersionFilePath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseLeadVersionFilePath.TabIndex = 415;
            this.btnBrowseLeadVersionFilePath.Text = "...";
            this.btnBrowseLeadVersionFilePath.Click += new System.EventHandler(this.btnBrowseIniFile_Click);
            // 
            // lbTossingStatisticsFilePath
            // 
            this.lbTossingStatisticsFilePath.AutoSize = true;
            this.lbTossingStatisticsFilePath.Location = new System.Drawing.Point(29, 714);
            this.lbTossingStatisticsFilePath.Name = "lbTossingStatisticsFilePath";
            this.lbTossingStatisticsFilePath.Size = new System.Drawing.Size(122, 24);
            this.lbTossingStatisticsFilePath.TabIndex = 416;
            this.lbTossingStatisticsFilePath.Text = "抛料统计文件:";
            // 
            // tbTossingStatisticsFilePath
            // 
            this.tbTossingStatisticsFilePath.Location = new System.Drawing.Point(211, 709);
            this.tbTossingStatisticsFilePath.Name = "tbTossingStatisticsFilePath";
            this.tbTossingStatisticsFilePath.Size = new System.Drawing.Size(522, 31);
            this.tbTossingStatisticsFilePath.TabIndex = 416;
            // 
            // btnBrowseTossingStatisticsFilePath
            // 
            this.btnBrowseTossingStatisticsFilePath.Location = new System.Drawing.Point(740, 709);
            this.btnBrowseTossingStatisticsFilePath.Name = "btnBrowseTossingStatisticsFilePath";
            this.btnBrowseTossingStatisticsFilePath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseTossingStatisticsFilePath.TabIndex = 417;
            this.btnBrowseTossingStatisticsFilePath.Text = "...";
            this.btnBrowseTossingStatisticsFilePath.Click += new System.EventHandler(this.btnBrowseIniFile_Click);
            // 
            // lbAlertConfigPath
            // 
            this.lbAlertConfigPath.AutoSize = true;
            this.lbAlertConfigPath.Location = new System.Drawing.Point(29, 576);
            this.lbAlertConfigPath.Name = "lbAlertConfigPath";
            this.lbAlertConfigPath.Size = new System.Drawing.Size(122, 24);
            this.lbAlertConfigPath.TabIndex = 418;
            this.lbAlertConfigPath.Text = "报警配置文件:";
            // 
            // tbAlertConfigPath
            // 
            this.tbAlertConfigPath.Location = new System.Drawing.Point(211, 571);
            this.tbAlertConfigPath.Name = "tbAlertConfigPath";
            this.tbAlertConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbAlertConfigPath.TabIndex = 410;
            // 
            // btnBrowseAlertConfigPath
            // 
            this.btnBrowseAlertConfigPath.Location = new System.Drawing.Point(740, 571);
            this.btnBrowseAlertConfigPath.Name = "btnBrowseAlertConfigPath";
            this.btnBrowseAlertConfigPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseAlertConfigPath.TabIndex = 411;
            this.btnBrowseAlertConfigPath.Text = "...";
            this.btnBrowseAlertConfigPath.Click += new System.EventHandler(this.btnBrowseAlertConfigPath_Click);
            // 
            // button1btnBrowseAdminitionConfigPath
            // 
            this.button1btnBrowseAdminitionConfigPath.Location = new System.Drawing.Point(741, 526);
            this.button1btnBrowseAdminitionConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.button1btnBrowseAdminitionConfigPath.Name = "button1btnBrowseAdminitionConfigPath";
            this.button1btnBrowseAdminitionConfigPath.Size = new System.Drawing.Size(52, 36);
            this.button1btnBrowseAdminitionConfigPath.TabIndex = 410;
            this.button1btnBrowseAdminitionConfigPath.Text = "...";
            this.button1btnBrowseAdminitionConfigPath.Click += new System.EventHandler(this.button1btnBrowseAdminitionConfigPath_Click);
            // 
            // tbAdministonConfigPath
            // 
            this.tbAdministonConfigPath.Location = new System.Drawing.Point(211, 526);
            this.tbAdministonConfigPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbAdministonConfigPath.Name = "tbAdministonConfigPath";
            this.tbAdministonConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbAdministonConfigPath.TabIndex = 409;
            // 
            // lb_Administration
            // 
            this.lb_Administration.AutoSize = true;
            this.lb_Administration.Location = new System.Drawing.Point(29, 530);
            this.lb_Administration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Administration.Name = "lb_Administration";
            this.lb_Administration.Size = new System.Drawing.Size(64, 24);
            this.lb_Administration.TabIndex = 408;
            this.lb_Administration.Text = "用户：";
            this.lb_Administration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseHashKeyConfigPath
            // 
            this.btnBrowseHashKeyConfigPath.Location = new System.Drawing.Point(742, 477);
            this.btnBrowseHashKeyConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseHashKeyConfigPath.Name = "btnBrowseHashKeyConfigPath";
            this.btnBrowseHashKeyConfigPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseHashKeyConfigPath.TabIndex = 407;
            this.btnBrowseHashKeyConfigPath.Text = "...";
            this.btnBrowseHashKeyConfigPath.Click += new System.EventHandler(this.btnBrowseHashKeyConfigPath_Click);
            // 
            // tbHashKeyConfigPath
            // 
            this.tbHashKeyConfigPath.Location = new System.Drawing.Point(212, 477);
            this.tbHashKeyConfigPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbHashKeyConfigPath.Name = "tbHashKeyConfigPath";
            this.tbHashKeyConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbHashKeyConfigPath.TabIndex = 406;
            // 
            // lb_Hashkey
            // 
            this.lb_Hashkey.AutoSize = true;
            this.lb_Hashkey.Location = new System.Drawing.Point(30, 481);
            this.lb_Hashkey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Hashkey.Name = "lb_Hashkey";
            this.lb_Hashkey.Size = new System.Drawing.Size(102, 24);
            this.lb_Hashkey.TabIndex = 405;
            this.lb_Hashkey.Text = "HashKey：";
            this.lb_Hashkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseGlobSettingConfigPath
            // 
            this.btnBrowseGlobSettingConfigPath.Location = new System.Drawing.Point(742, 429);
            this.btnBrowseGlobSettingConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseGlobSettingConfigPath.Name = "btnBrowseGlobSettingConfigPath";
            this.btnBrowseGlobSettingConfigPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseGlobSettingConfigPath.TabIndex = 404;
            this.btnBrowseGlobSettingConfigPath.Text = "...";
            this.btnBrowseGlobSettingConfigPath.Click += new System.EventHandler(this.btnBrowseGlobSettingConfigPath_Click);
            // 
            // tbGlobSettingConfigPath
            // 
            this.tbGlobSettingConfigPath.Location = new System.Drawing.Point(212, 429);
            this.tbGlobSettingConfigPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbGlobSettingConfigPath.Name = "tbGlobSettingConfigPath";
            this.tbGlobSettingConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbGlobSettingConfigPath.TabIndex = 403;
            // 
            // lb_GlobSetting
            // 
            this.lb_GlobSetting.AutoSize = true;
            this.lb_GlobSetting.Location = new System.Drawing.Point(30, 433);
            this.lb_GlobSetting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_GlobSetting.Name = "lb_GlobSetting";
            this.lb_GlobSetting.Size = new System.Drawing.Size(100, 24);
            this.lb_GlobSetting.TabIndex = 402;
            this.lb_GlobSetting.Text = "通用设置：";
            this.lb_GlobSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dudDirectory2
            // 
            this.dudDirectory2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dudDirectory2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dudDirectory2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dudDirectory2.Location = new System.Drawing.Point(741, 1071);
            this.dudDirectory2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dudDirectory2.MinimumSize = new System.Drawing.Size(150, 0);
            this.dudDirectory2.Name = "dudDirectory2";
            this.dudDirectory2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dudDirectory2.ShowText = false;
            this.dudDirectory2.Size = new System.Drawing.Size(150, 39);
            this.dudDirectory2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.dudDirectory2.TabIndex = 401;
            this.dudDirectory2.Text = "uiDoubleUpDown1";
            this.dudDirectory2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dudDirectory2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dudDirectory1
            // 
            this.dudDirectory1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dudDirectory1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dudDirectory1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dudDirectory1.Location = new System.Drawing.Point(741, 988);
            this.dudDirectory1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dudDirectory1.MinimumSize = new System.Drawing.Size(150, 0);
            this.dudDirectory1.Name = "dudDirectory1";
            this.dudDirectory1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.dudDirectory1.ShowText = false;
            this.dudDirectory1.Size = new System.Drawing.Size(150, 39);
            this.dudDirectory1.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.dudDirectory1.TabIndex = 401;
            this.dudDirectory1.Text = "uiDoubleUpDown1";
            this.dudDirectory1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.dudDirectory1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_Prims
            // 
            this.lb_Prims.AutoSize = true;
            this.lb_Prims.Location = new System.Drawing.Point(30, 30);
            this.lb_Prims.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Prims.Name = "lb_Prims";
            this.lb_Prims.Size = new System.Drawing.Size(64, 24);
            this.lb_Prims.TabIndex = 323;
            this.lb_Prims.Text = "基元：";
            this.lb_Prims.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDisConfigEnable
            // 
            this.chkDisConfigEnable.AutoSize = true;
            this.chkDisConfigEnable.Location = new System.Drawing.Point(800, 390);
            this.chkDisConfigEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkDisConfigEnable.Name = "chkDisConfigEnable";
            this.chkDisConfigEnable.Size = new System.Drawing.Size(72, 28);
            this.chkDisConfigEnable.TabIndex = 388;
            this.chkDisConfigEnable.Text = "启用";
            // 
            // btnBrowsePDCAPath
            // 
            this.btnBrowsePDCAPath.Location = new System.Drawing.Point(741, 825);
            this.btnBrowsePDCAPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowsePDCAPath.Name = "btnBrowsePDCAPath";
            this.btnBrowsePDCAPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowsePDCAPath.TabIndex = 400;
            this.btnBrowsePDCAPath.Text = "...";
            this.btnBrowsePDCAPath.Click += new System.EventHandler(this.btnBrowsePDCAPath_Click);
            // 
            // chkFaiConfigEnable
            // 
            this.chkFaiConfigEnable.AutoSize = true;
            this.chkFaiConfigEnable.Location = new System.Drawing.Point(800, 298);
            this.chkFaiConfigEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkFaiConfigEnable.Name = "chkFaiConfigEnable";
            this.chkFaiConfigEnable.Size = new System.Drawing.Size(72, 28);
            this.chkFaiConfigEnable.TabIndex = 387;
            this.chkFaiConfigEnable.Text = "启用";
            // 
            // btnBrowseSFLPath
            // 
            this.btnBrowseSFLPath.Location = new System.Drawing.Point(741, 779);
            this.btnBrowseSFLPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseSFLPath.Name = "btnBrowseSFLPath";
            this.btnBrowseSFLPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseSFLPath.TabIndex = 399;
            this.btnBrowseSFLPath.Text = "...";
            this.btnBrowseSFLPath.Click += new System.EventHandler(this.btnBrowseSFLPath_Click);
            // 
            // chkCommonDynamicParamEnable
            // 
            this.chkCommonDynamicParamEnable.AutoSize = true;
            this.chkCommonDynamicParamEnable.Location = new System.Drawing.Point(954, 254);
            this.chkCommonDynamicParamEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkCommonDynamicParamEnable.Name = "chkCommonDynamicParamEnable";
            this.chkCommonDynamicParamEnable.Size = new System.Drawing.Size(144, 28);
            this.chkCommonDynamicParamEnable.TabIndex = 386;
            this.chkCommonDynamicParamEnable.Text = "全局参数启用";
            // 
            // btnBrowseMachineDataPath
            // 
            this.btnBrowseMachineDataPath.Location = new System.Drawing.Point(741, 915);
            this.btnBrowseMachineDataPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseMachineDataPath.Name = "btnBrowseMachineDataPath";
            this.btnBrowseMachineDataPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseMachineDataPath.TabIndex = 398;
            this.btnBrowseMachineDataPath.Text = "...";
            this.btnBrowseMachineDataPath.Click += new System.EventHandler(this.btnBrowseMachineDataPath_Click);
            // 
            // chkDynamicParamEnable
            // 
            this.chkDynamicParamEnable.AutoSize = true;
            this.chkDynamicParamEnable.Location = new System.Drawing.Point(800, 252);
            this.chkDynamicParamEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkDynamicParamEnable.Name = "chkDynamicParamEnable";
            this.chkDynamicParamEnable.Size = new System.Drawing.Size(144, 28);
            this.chkDynamicParamEnable.TabIndex = 385;
            this.chkDynamicParamEnable.Text = "换型参数启用";
            // 
            // btnBrowseMachinePath
            // 
            this.btnBrowseMachinePath.Location = new System.Drawing.Point(741, 869);
            this.btnBrowseMachinePath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseMachinePath.Name = "btnBrowseMachinePath";
            this.btnBrowseMachinePath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseMachinePath.TabIndex = 397;
            this.btnBrowseMachinePath.Text = "...";
            this.btnBrowseMachinePath.Click += new System.EventHandler(this.btnBrowseMachinePath_Click);
            // 
            // chkCmpTrigConfigEnable
            // 
            this.chkCmpTrigConfigEnable.AutoSize = true;
            this.chkCmpTrigConfigEnable.Location = new System.Drawing.Point(800, 206);
            this.chkCmpTrigConfigEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkCmpTrigConfigEnable.Name = "chkCmpTrigConfigEnable";
            this.chkCmpTrigConfigEnable.Size = new System.Drawing.Size(72, 28);
            this.chkCmpTrigConfigEnable.TabIndex = 384;
            this.chkCmpTrigConfigEnable.Text = "启用";
            // 
            // txtDirectory2
            // 
            this.txtDirectory2.Location = new System.Drawing.Point(211, 1053);
            this.txtDirectory2.Margin = new System.Windows.Forms.Padding(2);
            this.txtDirectory2.Multiline = true;
            this.txtDirectory2.Name = "txtDirectory2";
            this.txtDirectory2.Size = new System.Drawing.Size(522, 73);
            this.txtDirectory2.TabIndex = 396;
            // 
            // txtDirectory1
            // 
            this.txtDirectory1.Location = new System.Drawing.Point(211, 970);
            this.txtDirectory1.Margin = new System.Windows.Forms.Padding(2);
            this.txtDirectory1.Multiline = true;
            this.txtDirectory1.Name = "txtDirectory1";
            this.txtDirectory1.Size = new System.Drawing.Size(522, 73);
            this.txtDirectory1.TabIndex = 396;
            // 
            // tbMachineData
            // 
            this.tbMachineData.Location = new System.Drawing.Point(211, 915);
            this.tbMachineData.Margin = new System.Windows.Forms.Padding(2);
            this.tbMachineData.Name = "tbMachineData";
            this.tbMachineData.Size = new System.Drawing.Size(522, 31);
            this.tbMachineData.TabIndex = 396;
            // 
            // chkTasksConfigEnable
            // 
            this.chkTasksConfigEnable.AutoSize = true;
            this.chkTasksConfigEnable.Location = new System.Drawing.Point(800, 162);
            this.chkTasksConfigEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkTasksConfigEnable.Name = "chkTasksConfigEnable";
            this.chkTasksConfigEnable.Size = new System.Drawing.Size(72, 28);
            this.chkTasksConfigEnable.TabIndex = 383;
            this.chkTasksConfigEnable.Text = "启用";
            // 
            // tbSFLPath
            // 
            this.tbSFLPath.Location = new System.Drawing.Point(211, 781);
            this.tbSFLPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbSFLPath.Name = "tbSFLPath";
            this.tbSFLPath.Size = new System.Drawing.Size(522, 31);
            this.tbSFLPath.TabIndex = 395;
            // 
            // chkElesConfigEnable
            // 
            this.chkElesConfigEnable.AutoSize = true;
            this.chkElesConfigEnable.Location = new System.Drawing.Point(800, 118);
            this.chkElesConfigEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkElesConfigEnable.Name = "chkElesConfigEnable";
            this.chkElesConfigEnable.Size = new System.Drawing.Size(72, 28);
            this.chkElesConfigEnable.TabIndex = 382;
            this.chkElesConfigEnable.Text = "启用";
            // 
            // tbMachinePath
            // 
            this.tbMachinePath.Location = new System.Drawing.Point(211, 871);
            this.tbMachinePath.Margin = new System.Windows.Forms.Padding(2);
            this.tbMachinePath.Name = "tbMachinePath";
            this.tbMachinePath.Size = new System.Drawing.Size(522, 31);
            this.tbMachinePath.TabIndex = 394;
            // 
            // chkShowConfigEnable
            // 
            this.chkShowConfigEnable.AutoSize = true;
            this.chkShowConfigEnable.Location = new System.Drawing.Point(800, 72);
            this.chkShowConfigEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowConfigEnable.Name = "chkShowConfigEnable";
            this.chkShowConfigEnable.Size = new System.Drawing.Size(72, 28);
            this.chkShowConfigEnable.TabIndex = 381;
            this.chkShowConfigEnable.Text = "启用";
            // 
            // tbPDCAPath
            // 
            this.tbPDCAPath.Location = new System.Drawing.Point(211, 827);
            this.tbPDCAPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbPDCAPath.Name = "tbPDCAPath";
            this.tbPDCAPath.Size = new System.Drawing.Size(522, 31);
            this.tbPDCAPath.TabIndex = 393;
            // 
            // chkPrimsConfigEnable
            // 
            this.chkPrimsConfigEnable.AutoSize = true;
            this.chkPrimsConfigEnable.Location = new System.Drawing.Point(800, 26);
            this.chkPrimsConfigEnable.Margin = new System.Windows.Forms.Padding(4);
            this.chkPrimsConfigEnable.Name = "chkPrimsConfigEnable";
            this.chkPrimsConfigEnable.Size = new System.Drawing.Size(72, 28);
            this.chkPrimsConfigEnable.TabIndex = 380;
            this.chkPrimsConfigEnable.Text = "启用";
            // 
            // lb_Log_PDCA
            // 
            this.lb_Log_PDCA.AutoSize = true;
            this.lb_Log_PDCA.Location = new System.Drawing.Point(29, 831);
            this.lb_Log_PDCA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Log_PDCA.Name = "lb_Log_PDCA";
            this.lb_Log_PDCA.Size = new System.Drawing.Size(114, 24);
            this.lb_Log_PDCA.TabIndex = 392;
            this.lb_Log_PDCA.Text = "PDCA日志：";
            this.lb_Log_PDCA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseDisConfigPath
            // 
            this.btnBrowseDisConfigPath.Location = new System.Drawing.Point(742, 386);
            this.btnBrowseDisConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseDisConfigPath.Name = "btnBrowseDisConfigPath";
            this.btnBrowseDisConfigPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseDisConfigPath.TabIndex = 379;
            this.btnBrowseDisConfigPath.Text = "...";
            this.btnBrowseDisConfigPath.Click += new System.EventHandler(this.btnBrowseDisConfigPath_Click);
            // 
            // lblDirectory2
            // 
            this.lblDirectory2.AutoSize = true;
            this.lblDirectory2.Location = new System.Drawing.Point(29, 1078);
            this.lblDirectory2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirectory2.Name = "lblDirectory2";
            this.lblDirectory2.Size = new System.Drawing.Size(147, 24);
            this.lblDirectory2.TabIndex = 391;
            this.lblDirectory2.Text = "自动删除文件夹2";
            this.lblDirectory2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDirectory1
            // 
            this.lblDirectory1.AutoSize = true;
            this.lblDirectory1.Location = new System.Drawing.Point(29, 995);
            this.lblDirectory1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirectory1.Name = "lblDirectory1";
            this.lblDirectory1.Size = new System.Drawing.Size(147, 24);
            this.lblDirectory1.TabIndex = 391;
            this.lblDirectory1.Text = "自动删除文件夹1";
            this.lblDirectory1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_ProductionData
            // 
            this.lb_ProductionData.AutoSize = true;
            this.lb_ProductionData.Location = new System.Drawing.Point(29, 921);
            this.lb_ProductionData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ProductionData.Name = "lb_ProductionData";
            this.lb_ProductionData.Size = new System.Drawing.Size(100, 24);
            this.lb_ProductionData.TabIndex = 391;
            this.lb_ProductionData.Text = "机台数据：";
            this.lb_ProductionData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseComplexQueryTaskFilePath
            // 
            this.btnBrowseComplexQueryTaskFilePath.Location = new System.Drawing.Point(742, 338);
            this.btnBrowseComplexQueryTaskFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseComplexQueryTaskFilePath.Name = "btnBrowseComplexQueryTaskFilePath";
            this.btnBrowseComplexQueryTaskFilePath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseComplexQueryTaskFilePath.TabIndex = 378;
            this.btnBrowseComplexQueryTaskFilePath.Text = "...";
            this.btnBrowseComplexQueryTaskFilePath.Click += new System.EventHandler(this.btnBrowseComplexQueryTaskFile_Click);
            // 
            // lb_Log_Machine
            // 
            this.lb_Log_Machine.AutoSize = true;
            this.lb_Log_Machine.Location = new System.Drawing.Point(29, 875);
            this.lb_Log_Machine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Log_Machine.Name = "lb_Log_Machine";
            this.lb_Log_Machine.Size = new System.Drawing.Size(138, 24);
            this.lb_Log_Machine.TabIndex = 390;
            this.lb_Log_Machine.Text = "Machine日志：";
            this.lb_Log_Machine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseFaiConfigPath
            // 
            this.btnBrowseFaiConfigPath.Location = new System.Drawing.Point(742, 296);
            this.btnBrowseFaiConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseFaiConfigPath.Name = "btnBrowseFaiConfigPath";
            this.btnBrowseFaiConfigPath.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseFaiConfigPath.TabIndex = 377;
            this.btnBrowseFaiConfigPath.Text = "...";
            this.btnBrowseFaiConfigPath.Click += new System.EventHandler(this.btnBrowseFaiConfigPath_Click);
            // 
            // lb_Log_SFL
            // 
            this.lb_Log_SFL.AutoSize = true;
            this.lb_Log_SFL.Location = new System.Drawing.Point(29, 785);
            this.lb_Log_SFL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Log_SFL.Name = "lb_Log_SFL";
            this.lb_Log_SFL.Size = new System.Drawing.Size(93, 24);
            this.lb_Log_SFL.TabIndex = 389;
            this.lb_Log_SFL.Text = "SFL日志：";
            this.lb_Log_SFL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseDynamicParamDir
            // 
            this.btnBrowseDynamicParamDir.Location = new System.Drawing.Point(742, 250);
            this.btnBrowseDynamicParamDir.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseDynamicParamDir.Name = "btnBrowseDynamicParamDir";
            this.btnBrowseDynamicParamDir.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseDynamicParamDir.TabIndex = 376;
            this.btnBrowseDynamicParamDir.Text = "...";
            this.btnBrowseDynamicParamDir.Click += new System.EventHandler(this.btnBrowseDynamicParamDir_Click);
            // 
            // tbDispenserConfigPath
            // 
            this.tbDispenserConfigPath.Location = new System.Drawing.Point(212, 386);
            this.tbDispenserConfigPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbDispenserConfigPath.Name = "tbDispenserConfigPath";
            this.tbDispenserConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbDispenserConfigPath.TabIndex = 370;
            // 
            // btnBrowseCmpTrigFile
            // 
            this.btnBrowseCmpTrigFile.Location = new System.Drawing.Point(742, 204);
            this.btnBrowseCmpTrigFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseCmpTrigFile.Name = "btnBrowseCmpTrigFile";
            this.btnBrowseCmpTrigFile.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseCmpTrigFile.TabIndex = 375;
            this.btnBrowseCmpTrigFile.Text = "...";
            this.btnBrowseCmpTrigFile.Click += new System.EventHandler(this.btnBrowseCmpTrigFile_Click);
            // 
            // tbComplexQueryTaskFilePath
            // 
            this.tbComplexQueryTaskFilePath.Location = new System.Drawing.Point(212, 340);
            this.tbComplexQueryTaskFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.tbComplexQueryTaskFilePath.Name = "tbComplexQueryTaskFilePath";
            this.tbComplexQueryTaskFilePath.Size = new System.Drawing.Size(522, 31);
            this.tbComplexQueryTaskFilePath.TabIndex = 369;
            // 
            // btnBrowseTasksFile
            // 
            this.btnBrowseTasksFile.Location = new System.Drawing.Point(742, 158);
            this.btnBrowseTasksFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseTasksFile.Name = "btnBrowseTasksFile";
            this.btnBrowseTasksFile.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseTasksFile.TabIndex = 374;
            this.btnBrowseTasksFile.Text = "...";
            this.btnBrowseTasksFile.Click += new System.EventHandler(this.btnBrowseTasksFile_Click);
            // 
            // tbFaiConfigPath
            // 
            this.tbFaiConfigPath.Location = new System.Drawing.Point(212, 296);
            this.tbFaiConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbFaiConfigPath.Name = "tbFaiConfigPath";
            this.tbFaiConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbFaiConfigPath.TabIndex = 368;
            // 
            // btnBrowseElesFile
            // 
            this.btnBrowseElesFile.Location = new System.Drawing.Point(742, 114);
            this.btnBrowseElesFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseElesFile.Name = "btnBrowseElesFile";
            this.btnBrowseElesFile.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseElesFile.TabIndex = 373;
            this.btnBrowseElesFile.Text = "...";
            this.btnBrowseElesFile.Click += new System.EventHandler(this.btnBrowseElesFile_Click);
            // 
            // tbDynamicParamDirPath
            // 
            this.tbDynamicParamDirPath.Location = new System.Drawing.Point(212, 250);
            this.tbDynamicParamDirPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbDynamicParamDirPath.Name = "tbDynamicParamDirPath";
            this.tbDynamicParamDirPath.Size = new System.Drawing.Size(522, 31);
            this.tbDynamicParamDirPath.TabIndex = 367;
            // 
            // btnBrowseDisplayFile
            // 
            this.btnBrowseDisplayFile.Location = new System.Drawing.Point(742, 70);
            this.btnBrowseDisplayFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseDisplayFile.Name = "btnBrowseDisplayFile";
            this.btnBrowseDisplayFile.Size = new System.Drawing.Size(52, 36);
            this.btnBrowseDisplayFile.TabIndex = 372;
            this.btnBrowseDisplayFile.Text = "...";
            this.btnBrowseDisplayFile.Click += new System.EventHandler(this.BtnBrowseDisplayFile_Click);
            // 
            // tbCmpTrigsConfigPath
            // 
            this.tbCmpTrigsConfigPath.Location = new System.Drawing.Point(212, 206);
            this.tbCmpTrigsConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbCmpTrigsConfigPath.Name = "tbCmpTrigsConfigPath";
            this.tbCmpTrigsConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbCmpTrigsConfigPath.TabIndex = 366;
            // 
            // btnBrowsePrimsFile
            // 
            this.btnBrowsePrimsFile.Location = new System.Drawing.Point(742, 24);
            this.btnBrowsePrimsFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowsePrimsFile.Name = "btnBrowsePrimsFile";
            this.btnBrowsePrimsFile.Size = new System.Drawing.Size(52, 36);
            this.btnBrowsePrimsFile.TabIndex = 371;
            this.btnBrowsePrimsFile.Text = "...";
            this.btnBrowsePrimsFile.Click += new System.EventHandler(this.btnBrowsePrimsFile_Click);
            // 
            // tbTasksConfigPath
            // 
            this.tbTasksConfigPath.Location = new System.Drawing.Point(212, 160);
            this.tbTasksConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbTasksConfigPath.Name = "tbTasksConfigPath";
            this.tbTasksConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbTasksConfigPath.TabIndex = 365;
            // 
            // lb_Display
            // 
            this.lb_Display.AutoSize = true;
            this.lb_Display.Location = new System.Drawing.Point(30, 74);
            this.lb_Display.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Display.Name = "lb_Display";
            this.lb_Display.Size = new System.Drawing.Size(64, 24);
            this.lb_Display.TabIndex = 354;
            this.lb_Display.Text = "显示：";
            this.lb_Display.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbElesConfigPath
            // 
            this.tbElesConfigPath.Location = new System.Drawing.Point(212, 116);
            this.tbElesConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbElesConfigPath.Name = "tbElesConfigPath";
            this.tbElesConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbElesConfigPath.TabIndex = 364;
            // 
            // lb_Element
            // 
            this.lb_Element.AutoSize = true;
            this.lb_Element.Location = new System.Drawing.Point(30, 120);
            this.lb_Element.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Element.Name = "lb_Element";
            this.lb_Element.Size = new System.Drawing.Size(64, 24);
            this.lb_Element.TabIndex = 355;
            this.lb_Element.Text = "元件：";
            this.lb_Element.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbShowConfigPath
            // 
            this.tbShowConfigPath.Location = new System.Drawing.Point(212, 70);
            this.tbShowConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbShowConfigPath.Name = "tbShowConfigPath";
            this.tbShowConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbShowConfigPath.TabIndex = 363;
            // 
            // lb_Task
            // 
            this.lb_Task.AutoSize = true;
            this.lb_Task.Location = new System.Drawing.Point(30, 166);
            this.lb_Task.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Task.Name = "lb_Task";
            this.lb_Task.Size = new System.Drawing.Size(64, 24);
            this.lb_Task.TabIndex = 356;
            this.lb_Task.Text = "任务：";
            this.lb_Task.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPrimsConfigPath
            // 
            this.tbPrimsConfigPath.Location = new System.Drawing.Point(212, 26);
            this.tbPrimsConfigPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPrimsConfigPath.Name = "tbPrimsConfigPath";
            this.tbPrimsConfigPath.Size = new System.Drawing.Size(522, 31);
            this.tbPrimsConfigPath.TabIndex = 362;
            // 
            // lb_Trig
            // 
            this.lb_Trig.AutoSize = true;
            this.lb_Trig.Location = new System.Drawing.Point(30, 210);
            this.lb_Trig.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Trig.Name = "lb_Trig";
            this.lb_Trig.Size = new System.Drawing.Size(136, 24);
            this.lb_Trig.TabIndex = 357;
            this.lb_Trig.Text = "脉冲比较功能：";
            this.lb_Trig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Dispensing
            // 
            this.lb_Dispensing.AutoSize = true;
            this.lb_Dispensing.Location = new System.Drawing.Point(30, 390);
            this.lb_Dispensing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Dispensing.Name = "lb_Dispensing";
            this.lb_Dispensing.Size = new System.Drawing.Size(64, 24);
            this.lb_Dispensing.TabIndex = 361;
            this.lb_Dispensing.Text = "点胶：";
            this.lb_Dispensing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_ParameterFilePath
            // 
            this.lb_ParameterFilePath.AutoSize = true;
            this.lb_ParameterFilePath.Location = new System.Drawing.Point(30, 254);
            this.lb_ParameterFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ParameterFilePath.Name = "lb_ParameterFilePath";
            this.lb_ParameterFilePath.Size = new System.Drawing.Size(100, 24);
            this.lb_ParameterFilePath.TabIndex = 358;
            this.lb_ParameterFilePath.Text = "参数目录：";
            this.lb_ParameterFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_ComplexFai
            // 
            this.lb_ComplexFai.AutoSize = true;
            this.lb_ComplexFai.Location = new System.Drawing.Point(30, 346);
            this.lb_ComplexFai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ComplexFai.Name = "lb_ComplexFai";
            this.lb_ComplexFai.Size = new System.Drawing.Size(172, 24);
            this.lb_ComplexFai.TabIndex = 360;
            this.lb_ComplexFai.Text = "复杂查询任务路径：";
            this.lb_ComplexFai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Fai
            // 
            this.lb_Fai.AutoSize = true;
            this.lb_Fai.Location = new System.Drawing.Point(30, 300);
            this.lb_Fai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Fai.Name = "lb_Fai";
            this.lb_Fai.Size = new System.Drawing.Size(92, 24);
            this.lb_Fai.TabIndex = 359;
            this.lb_Fai.Text = "FAI参数：";
            this.lb_Fai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrOneHour
            // 
            this.tmrOneHour.Tick += new System.EventHandler(this.tmrOneHour_Tick);
            // 
            // SoftwareConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SoftwareConfigControl";
            this.Size = new System.Drawing.Size(1914, 976);
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
        private TextBox txtMasterIP;
        private Button btnBrowseGlobSettingConfigPath;
        private TextBox tbGlobSettingConfigPath;
        private Label lb_GlobSetting;
        private Button btnBrowseHashKeyConfigPath;
        private TextBox tbHashKeyConfigPath;
        private Label lb_Hashkey;
        private Button button1btnBrowseAdminitionConfigPath;
        private TextBox tbAdministonConfigPath;
        private Label lb_Administration;
        private Label lbAlertConfigPath;
        private Label lbProductParamDirPath;
        private TextBox tbProductParamDirPath;
        private Button btnBrowseProductParamDirPath;
        private Label lbLeadVersionFilePath;
        private TextBox tbLeadVersionFilePath;
        private Button btnBrowseLeadVersionFilePath;
        private Label lbTossingStatisticsFilePath;
        private TextBox tbTossingStatisticsFilePath;
        private Button btnBrowseTossingStatisticsFilePath;
        private TextBox tbAlertConfigPath;
        private Button btnBrowseAlertConfigPath;
    }
}
