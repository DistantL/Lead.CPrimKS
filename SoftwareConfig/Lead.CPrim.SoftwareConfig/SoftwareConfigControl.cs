using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.SoftwareConfig
{
    public partial class SoftwareConfigControl : UserControl
    {
        #region Field
        /// <summary>软件配置管理器</summary>
        private SwManager _manager;
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="manager">软件配置管理器</param>
        public SoftwareConfigControl(SwManager manager)
        {
            InitializeComponent();
            _manager = manager;
            SetStyleFlags();
            tlpMain.SetDoubleBuffered();

            this.SetStyleALL(ControlStyle.Light);

            cbMasterControl.Items.AddRange(Enum.GetNames(typeof(MasterControlEnum)));

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            {
                tmrOneHour.Interval = 60 * 60 * 1000;
                tmrOneHour.Enabled = true;
                tmrOneHour_Tick(null, null);
            }

        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void TrigTableControl_Load(object sender, EventArgs e)
        {
            TbCmbInit(_manager);
            FilePathsInit(_manager);
        }
        #endregion



        #region Button_Event
        /// <summary>配置路径选择</summary>
        private void tsBtnOpenConfigFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = @"json File|*.json|All File|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tsTbSWConfigFilePath.Text = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ErrMsg_SelectFilePathFail", "配置路径选择失败:") + ex.Message);
            }
        }

        /// <summary>加载软件配置</summary>
        private void tsBtnLoadSWConfig_Click(object sender, EventArgs e)
        {
            _manager.ReLoad();
            TbCmbInit(_manager);
            FilePathsInit(_manager);
            if (SwManager.Instance.HasAccessary)
            {
                string[] strs = SwManager.Instance.AccessaryNames.Trim(';').Split(';');
                string[] strc = SwManager.Instance.AccessaryCodeLength.Trim(';').Split(';');
                if (strs != null && strc != null)
                {
                    List<(string, string)> values = new List<(string, string)>();
                    for (int i = 0; i < strs.Length; i++)
                    {
                        values.Add((strs[i], string.Empty));
                        for (int j = 0; j < strc.Length; j++)
                        {
                            if (i == j)
                            {
                                values[i] = (strs[i], strc[j]);
                                break;
                            }
                        }
                    }

                    AuthorityManager.Instance.AccessaryInfos = values;
                    AuthorityManager.Instance.AccessaryNames = new List<string>(strs);
                }
            }
        }

        /// <summary>增加产品-此事件仅做界面显示</summary>
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string text = cmbProducts.Text;
            if (!string.IsNullOrEmpty(text) && !cmbProducts.Items.Contains(text) && MessageBox.Show(
               NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Tip_AddNewProduction", "是否要添加新产品:") + text,
               NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Tip_NeedRestart", "提示，重启软件后生效"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmbProducts.Items.Add(text);
            }
        }
        /// <summary>删除产品-此事件仅做界面显示</summary>
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            string text = cmbProducts.Text;
            if (!string.IsNullOrEmpty(text) && cmbProducts.Items.Contains(text) && MessageBox.Show(
               NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Tip_DeleteProduction", "是否要删除产品:") + text,
               NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Tip_NeedRestart", "提示，重启软件后生效"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmbProducts.Items.Remove(text);
                cmbProducts.SelectedIndex = -1;
            }
        }
        /// <summary>远程切换配方使能</summary>
        private void chkRemoteRecipeShiftEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemoteRecipeShiftEnable.Checked)
            {
                lb_ChangeRepiceSuperClientName.Visible = true;
                tbSuperClientName.Visible = true;
            }
            else
            {
                lb_ChangeRepiceSuperClientName.Visible = false;
                tbSuperClientName.Visible = false;
            }
        }

        /// <summary>创建Hash码</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateHash_Click(object sender, EventArgs e)
        {
            txtSoftWareHashCode.Text = AudioSwVersion.Instance.GetSHA1InFile(AudioSwVersion.Instance.Main_SW_filePath);
            if (!string.IsNullOrWhiteSpace(_manager.VisionPath))
            {
                txtVisionHashCode.Text = AudioSwVersion.Instance.GetSHA1InFile(_manager.VisionPath);
            }
        }

        //功能路径
        /// <summary>基元路径选择</summary>
        private void btnBrowsePrimsFile_Click(object sender, EventArgs e)
        {
            string text = tbPrimsConfigPath.Text;
            FileHelper.OpenFileDialogMethod(ref text);
            tbPrimsConfigPath.Text = text;
        }
        /// <summary>显示路径选择</summary>
        private void BtnBrowseDisplayFile_Click(object sender, EventArgs e)
        {
            string text = tbShowConfigPath.Text;
            FileHelper.OpenFileDialogMethod(ref text);
            tbShowConfigPath.Text = text;
        }
        /// <summary>元件路径选择</summary>
        private void btnBrowseElesFile_Click(object sender, EventArgs e)
        {
            string text = tbElesConfigPath.Text;
            FileHelper.OpenFileDialogMethod(ref text);
            tbElesConfigPath.Text = text;
        }
        /// <summary>任务路径选择</summary>
        private void btnBrowseTasksFile_Click(object sender, EventArgs e)
        {
            string text = tbTasksConfigPath.Text;
            FileHelper.OpenFileDialogMethod(ref text);
            tbTasksConfigPath.Text = text;
        }
        /// <summary>脉冲比较功能路径选择</summary>
        private void btnBrowseCmpTrigFile_Click(object sender, EventArgs e)
        {
            string text = tbCmpTrigsConfigPath.Text;
            FileHelper.OpenFileDialogMethod(ref text);
            tbCmpTrigsConfigPath.Text = text;
        }
        /// <summary>参数目录路径选择</summary>
        private void btnBrowseDynamicParamDir_Click(object sender, EventArgs e)
        {
            string text = tbDynamicParamDirPath.Text;
            if (FileHelper.OpenFolderDialogMethod(ref text))
            {
                tbDynamicParamDirPath.Text = text;
            }
        }
        /// <summary>FAI参数</summary>
        private void btnBrowseFaiConfigPath_Click(object sender, EventArgs e)
        {
            string text = tbFaiConfigPath.Text;
            FileHelper.OpenFileDialogMethod(ref text);
            tbFaiConfigPath.Text = text;
        }
        /// <summary>复杂查询任务路径</summary>
        private void btnBrowseComplexQueryTaskFile_Click(object sender, EventArgs e)
        {
            string text = tbComplexQueryTaskFilePath.Text;
            FileHelper.OpenFileDialogMethod(ref text);
            tbComplexQueryTaskFilePath.Text = text;
        }
        /// <summary>点胶</summary>
        private void btnBrowseDisConfigPath_Click(object sender, EventArgs e)
        {
            string text = tbDispenserConfigPath.Text;
            FileHelper.OpenFileDialogMethod(ref text);
            tbDispenserConfigPath.Text = text;
        }
        /// <summary>SFL日志目录</summary>
        private void btnBrowseSFLPath_Click(object sender, EventArgs e)
        {
            string text = tbSFLPath.Text;
            if (FileHelper.OpenFolderDialogMethod(ref text))
            {
                tbSFLPath.Text = text;
            }
        }
        /// <summary>PDCA日志目录</summary>
        private void btnBrowsePDCAPath_Click(object sender, EventArgs e)
        {
            string text = tbPDCAPath.Text;
            if (FileHelper.OpenFolderDialogMethod(ref text))
            {
                tbPDCAPath.Text = text;
            }
        }
        /// <summary>机台日志目录</summary>
        private void btnBrowseMachinePath_Click(object sender, EventArgs e)
        {
            string text = tbMachinePath.Text;
            if (FileHelper.OpenFolderDialogMethod(ref text))
            {
                tbMachinePath.Text = text;
            }
        }
        /// <summary>机台数据目录</summary>
        private void btnBrowseMachineDataPath_Click(object sender, EventArgs e)
        {
            string text = tbMachineData.Text;
            if (FileHelper.OpenFolderDialogMethod(ref text))
            {
                tbMachineData.Text = text;
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>软件配置保存</summary>
        public void SaveSWParams()
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(SaveSWParams));
                    return;
                }

                string path = tsTbSWConfigFilePath.Text.Trim();
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ErrMsg_PathIsEmpty", "软件路径路径不能为空"));
                }
                _manager.ConfigFilePath = path;
                _manager.ExportSWConfigToPath(path);

                //功能路径
                _manager.PrimsFile = tbPrimsConfigPath.Text;
                _manager.PrimsConfigEnable = chkPrimsConfigEnable.Checked;
                _manager.DisplayFile = tbShowConfigPath.Text;
                _manager.DisplayConfigEnable = chkShowConfigEnable.Checked;
                _manager.ElesFile = tbElesConfigPath.Text;
                _manager.ElesConfigEnable = chkElesConfigEnable.Checked;
                _manager.TasksFile = tbTasksConfigPath.Text;
                _manager.TasksConfigEnable = chkTasksConfigEnable.Checked;
                _manager.CmpTrigFilePath = tbCmpTrigsConfigPath.Text;
                _manager.CmpTrigConfigEnable = chkCmpTrigConfigEnable.Checked;
                _manager.DynamicParamDirPath = tbDynamicParamDirPath.Text;
                _manager.DynamicParamEnable = chkDynamicParamEnable.Checked;
                _manager.CommonDynamicParamEnable = chkCommonDynamicParamEnable.Checked;
                _manager.FaiConfigFilePath = tbFaiConfigPath.Text;
                _manager.FaiConfigEnable = chkFaiConfigEnable.Checked;
                _manager.ComplexQueryTaskFilePath = tbComplexQueryTaskFilePath.Text;
                _manager.DispenserFilePath = tbDispenserConfigPath.Text;
                _manager.DispenserConfigEnable = chkDisConfigEnable.Checked;
                _manager.SFLPath = tbSFLPath.Text.Trim();
                _manager.PDCAPath = tbPDCAPath.Text.Trim();
                _manager.MachinePath = tbMachinePath.Text.Trim();
                _manager.MachineDataPath = tbMachineData.Text.Trim();
                _manager.Directory1 = txtDirectory1.Text.Trim();
                _manager.Directory2 = txtDirectory2.Text.Trim();
                _manager.Directory1SaveDays = dudDirectory1.Value;
                _manager.Directory2SaveDays = dudDirectory2.Value;

                //参数设置
                _manager.Description = tbSWDescription.Text;

                SwManager manager = _manager;
                object selectedItem = cmbSWType.SelectedItem;
                manager.RemoteCSType = ((selectedItem != null) ? selectedItem.ToString() : null);
                _manager.RemoteQualificationEnable = chkRemoteQualificationEnable.Checked;


                //保存产品列表并生成产品文件
                _manager.Products.Clear();
                foreach (var p in cmbProducts.Items)
                {
                    _manager.Products.Add(p.ToString());
                }

                if (_manager.DynamicParamEnable && !string.IsNullOrEmpty(_manager.DynamicParamDirPath))
                {
                    string tempPath = _manager.DynamicParamDirPath + "\\ProductCfg";
                    if (!Directory.Exists(tempPath))
                    {
                        Directory.CreateDirectory(_manager.DynamicParamDirPath + "\\ProductCfg");
                    }
                    if (File.Exists(Application.StartupPath + "\\Configs\\Template.para"))
                    {
                        foreach (string product in _manager.Products)
                        {
                            if (!File.Exists(_manager.DynamicParamDirPath + "\\ProductCfg\\" + product + ".para"))
                            {
                                File.Copy(Application.StartupPath + "\\Configs\\Template.para", _manager.DynamicParamDirPath + "\\ProductCfg\\" + product + ".para");
                            }
                        }
                    }
                }
                SwManager manager2 = _manager;
                object selectedItem2 = cmbProducts.SelectedItem;
                manager2.CurrentProduct = ((selectedItem2 != null) ? selectedItem2.ToString() : null);

                if (cmbLanguage.SelectedText != null)
                {
                    if (Enum.TryParse(cmbLanguage.SelectedText, out Language lag))
                    {
                        _manager.SysLanguage = lag;
                    }
                }

                _manager.BootInit = chkBootInit.Checked;
                _manager.BootRun = chkBootRun.Checked;
                _manager.TrackingEnable = chkTrackingEnable.Checked;

                _manager.IsRecipeShiftByServer = chkRemoteRecipeShiftEnable.Checked;
                _manager.RecipeShiftSuperClientName = tbSuperClientName.Text.Trim();

                _manager.SwName = tbSwName.Text;
                _manager.TaskVer = string.IsNullOrEmpty(tbTaskVer.Text.Trim()) ? "V1.0" : tbTaskVer.Text.Trim();

                _manager.ExitPermissionTime = ((!string.IsNullOrEmpty(tbExitPermissionTime.Text) && int.TryParse(tbExitPermissionTime.Text, out int result)) ? result : 300000);

                _manager.VisionName = tbVisionName.Text;
                _manager.VisionPath = tbVisionPath.Text;
                _manager.VisionVersion = string.IsNullOrEmpty(tbVisionVer.Text.Trim()) ? "V1.0" : tbVisionVer.Text.Trim();

                _manager.MasterControl = cbMasterControl.SelectedItem == null ? MasterControlEnum.PC.ToString() : cbMasterControl.SelectedItem?.ToString();
                _manager.TaskLogUINo = int.TryParse(cbTaskLogUINo.SelectedItem != null ? cbTaskLogUINo.SelectedItem.ToString() : "1", out int result1) ? result1 : 1;
                _manager.DataSave = cbDataSave.SelectedIndex == 1 ? DataSaveMode.ByEveryDay : (cbDataSave.SelectedIndex == 2 ? DataSaveMode.ByEveryWeek : DataSaveMode.Other);
                _manager.ConfigFrmBindFaiName = txtConfigFrmBindFaiName.Text;
                _manager.SoftWareHashCode = txtSoftWareHashCode.Text;
                _manager.VisionHashCode = txtVisionHashCode.Text;

                _manager.PressPrimEnable = cbPressPrimEnable.Checked;
                _manager.PressPrimName = tbPressPrimName.Text.Trim();
                _manager.ServicePrimName = tbServicePrimName.Text.Trim();

                _manager.HasAccessary = cb_AccessaryNames.Checked;

                _manager.AccessaryNames = tb_AccessaryNames.Text;
                _manager.AccessaryCodeLength = tb_AccessaryCodeLength.Text;
                _manager.TossingReasons = tb_TossingReason.Text;
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ErrMsg_SaveFail", "保存失败:") + ex.Message);
            }
        }

        /// <summary>使能设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        public void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }
            foreach (Control con in tpConfig.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpDisplayParam.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpPath.Controls)
            {
                con.Enabled = enable;
            }
            tsStationsConfig.Enabled = enable;
        }
        #endregion




        #region Method_InternalUsing
        /// <summary>样式设置</summary>
        /// <param name="supportTransparent">true：支持透明；false：不支持透明</param>
        /// <param name="selectable">true：可以被选择；false：不可以被选择</param>
        /// <param name="resizeRedraw">true：调整大小时重绘该控件；false：调整大小时不重绘该控件</param>
        protected void SetStyleFlags(bool supportTransparent = true, bool selectable = true, bool resizeRedraw = false)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            if (supportTransparent) SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            if (selectable) SetStyle(ControlStyles.Selectable, true);
            if (resizeRedraw) SetStyle(ControlStyles.ResizeRedraw, true);
            base.DoubleBuffered = true;
            UpdateStyles();
        }
        /// <summary>软件配置_参数设置初始化</summary>
        /// <param name="config">软件配置管理器</param>
        private void TbCmbInit(SwManager config)
        {
            tsTbSWConfigFilePath.Text = config.ConfigFilePath;

            tbSWDescription.Text = config.Description;
            if (!string.IsNullOrEmpty(config.RemoteCSType) && cmbSWType.Items.Contains(config.RemoteCSType))
                cmbSWType.SelectedItem = config.RemoteCSType;
            else
                cmbSWType.SelectedIndex = -1;
            chkRemoteQualificationEnable.Checked = config.RemoteQualificationEnable;

            //加载产品列表
            cmbProducts.Items.Clear();
            config.Products.ForEach(p => cmbProducts.Items.Add(p));
            if (!string.IsNullOrEmpty(config.CurrentProduct) && cmbProducts.Items.Contains(config.CurrentProduct))
                cmbProducts.SelectedItem = config.CurrentProduct;
            else
                cmbProducts.SelectedIndex = -1;

            cmbLanguage.SelectedText = config.SysLanguage.ToString();

            chkBootInit.Checked = config.BootInit;
            chkBootRun.Checked = config.BootRun;
            chkTrackingEnable.Checked = config.TrackingEnable;

            chkRemoteRecipeShiftEnable.Checked = config.IsRecipeShiftByServer;
            chkRemoteRecipeShiftEnable_CheckedChanged(null, null);
            tbSuperClientName.Text = config.RecipeShiftSuperClientName;

            tbSwName.Text = config.SwName;
            tbTaskVer.Text = config.TaskVer;
            tbExitPermissionTime.Text = config.ExitPermissionTime.ToString();

            tbVisionName.Text = config.VisionName?.ToString();
            tbVisionPath.Text = config.VisionPath?.ToString();
            tbVisionVer.Text = config.VisionVersion?.ToString();

            cbMasterControl.SelectedItem = config.MasterControl?.ToString();
            cbTaskLogUINo.SelectedItem = config.TaskLogUINo.ToString();
            cbDataSave.SelectedIndex = config.DataSave == DataSaveMode.ByEveryDay ? 1 : (config.DataSave == DataSaveMode.ByEveryWeek ? 2 : 0);
            txtConfigFrmBindFaiName.Text = config.ConfigFrmBindFaiName;
            txtSoftWareHashCode.Text = config.SoftWareHashCode;
            txtVisionHashCode.Text = config.VisionHashCode;

            cbPressPrimEnable.Checked = config.PressPrimEnable;
            tbPressPrimName.Text = config.PressPrimName;
            tbServicePrimName.Text = config.ServicePrimName;

            cb_AccessaryNames.Checked = config.HasAccessary;
            tb_AccessaryNames.Text = config.AccessaryNames;
            tb_AccessaryCodeLength.Text = config.AccessaryCodeLength;
            tb_TossingReason.Text = config.TossingReasons;
        }
        /// <summary>软件配置_功能路径初始化</summary>
        /// <param name="config">软件配置管理器</param>
        private void FilePathsInit(SwManager config)
        {
            if (!string.IsNullOrEmpty(config.PrimsFile)) tbPrimsConfigPath.Text = config.PrimsFile;
            chkPrimsConfigEnable.Checked = config.PrimsConfigEnable;
            if (!string.IsNullOrEmpty(config.DisplayFile)) tbShowConfigPath.Text = config.DisplayFile;
            chkShowConfigEnable.Checked = config.DisplayConfigEnable;
            if (!string.IsNullOrEmpty(config.ElesFile)) tbElesConfigPath.Text = config.ElesFile;
            chkElesConfigEnable.Checked = config.ElesConfigEnable;
            if (!string.IsNullOrEmpty(config.TasksFile)) tbTasksConfigPath.Text = config.TasksFile;
            chkTasksConfigEnable.Checked = config.TasksConfigEnable;
            if (!string.IsNullOrEmpty(config.CmpTrigFilePath)) tbCmpTrigsConfigPath.Text = config.CmpTrigFilePath;
            chkCmpTrigConfigEnable.Checked = config.CmpTrigConfigEnable;
            if (!string.IsNullOrEmpty(config.DynamicParamDirPath)) tbDynamicParamDirPath.Text = config.DynamicParamDirPath;
            chkDynamicParamEnable.Checked = config.DynamicParamEnable;
            chkCommonDynamicParamEnable.Checked = config.CommonDynamicParamEnable;
            if (!string.IsNullOrEmpty(config.FaiConfigFilePath)) tbFaiConfigPath.Text = config.FaiConfigFilePath;
            chkFaiConfigEnable.Checked = config.FaiConfigEnable;
            if (!string.IsNullOrEmpty(config.ComplexQueryTaskFilePath)) tbComplexQueryTaskFilePath.Text = config.ComplexQueryTaskFilePath;
            if (!string.IsNullOrEmpty(config.DispenserFilePath)) tbDispenserConfigPath.Text = config.DispenserFilePath;
            chkDisConfigEnable.Checked = config.DispenserConfigEnable;

            tbSFLPath.Text = string.IsNullOrEmpty(config.SFLPath) ? string.Empty : config.SFLPath;
            tbPDCAPath.Text = string.IsNullOrEmpty(config.PDCAPath) ? string.Empty : config.PDCAPath;
            tbMachinePath.Text = string.IsNullOrEmpty(config.MachinePath) ? string.Empty : config.MachinePath;
            tbMachineData.Text = string.IsNullOrEmpty(config.MachineDataPath) ? string.Empty : config.MachineDataPath;

            txtDirectory1.Text = config.Directory1;
            txtDirectory2.Text = config.Directory2;
            dudDirectory1.Value = config.Directory1SaveDays;
            dudDirectory2.Value = config.Directory2SaveDays;
        }
        /// <summary>当前产品更新</summary>
        /// <param name="productName">当前产品</param>
        public void RefreshCurrentProduct(string productName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(RefreshCurrentProduct), productName);
                return;
            }
            if (!cmbProducts.Items.Contains(productName))
            {
                cmbProducts.Items.Add(productName);
            }
            cmbProducts.SelectedItem = productName;
        }

        private void tbProductIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void OnLanguageChanged()
        {
            tsl_ConfigFilePath.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ConfigFilePath", "配置路径:");
            tsBtnLoadStationsConfig.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_LoadStationsConfig", "Load");
            tpConfig.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_tpConfig", "参数设置");
            tpDisplayParam.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_tpDisplayParam", "界面设置");
            tpPath.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_tpPath", "功能路径");
            lb_SoftwareInfo.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_SoftwareInfo", "系统描述:");
            chkRemoteQualificationEnable.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_chkRemoteQualificationEnable", "Remote Qualification功能使能");
            lb_SystemType.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_SystemType", "系统类型:");
            lbProducts.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Products", "产品列表:");
            chkBootInit.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_BootInit", "上电初始化");
            chkBootRun.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_BootRun", "上电启动");
            chkTrackingEnable.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_TrackingEnable", "Tracking功能使能");
            chkRemoteRecipeShiftEnable.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_RemoteRecipeShiftEnable", "远程切换配方使能");
            lb_ChangeRepiceSuperClientName.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ChangeRepiceSuperClientName", "配方切换SuperClient名称");
            lb_SoftwareName.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_SoftwareName", "软件名称:");
            lb_Taskversion.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Taskversion", "Task版本:");
            lb_VisionSoftwareName.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_VisionSoftwareName", "视觉软件名称:");
            lb_VisionSoftwareVersion.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_VisionSoftwareVersion", "视觉软件版本:");
            lb_PermissionLogoutTimeout.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_PermissionLogoutTimeout", "权限注销超时时间(秒)");
            lb_VisionsoftwareFilePath.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_VisionsoftwareFilePath", "视觉软件路径");
            lb_MasterControl.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_MasterControl", "主控类型");
            lb_NumberOfTaskLogUI.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_NumberOfTaskLogUI", "任务日志UI数量");
            lblDataSave.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_DataSave", "设备参数定期保存");
            lb_BindingFAiName.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_BindingFAiName", "绑定FAI名称");
            lb_MS_Hash.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_MS_Hash", "上位机Hash码:");
            lb_VS_Hash.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_VS_Hash", "视觉Hash码:");
            btnCreateHash.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_CreateHash", "生成");

            cbPressPrimEnable.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_PressPrimEnable", "曲线显示基元名称:");
            lb_ServerPrism.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ServerPrism", "服务器基元(用于产品切换):");
            lb_Tip_RestartSoftware.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Tip_RestartSoftware", "(需要重启软件)");

            lb_Prims.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Prims", "基元:");
            lb_Display.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Display", "显示:");
            lb_Element.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Element", "元件:");
            lb_Task.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Task", "任务:");
            lb_Trig.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Trig", "脉冲比较功能:");
            lb_ParameterFilePath.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ParameterFilePath", "参数目录:");
            lb_Fai.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Fai", "FAI参数:");
            lb_ComplexFai.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ComplexFai", "复杂查询任务路径:");
            lb_Dispensing.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Dispensing", "点胶:");
            lb_Log_SFL.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Log_SFL", "SFL日志:");
            lb_Log_PDCA.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Log_PDCA", "PDCA日志:");
            lb_Log_Machine.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Log_Machine", "设备日志:");
            lb_ProductionData.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_ProductionData", "机台数据:");


            chkPrimsConfigEnable.Text
                = chkShowConfigEnable.Text
                = chkElesConfigEnable.Text
                = chkTasksConfigEnable.Text
                = chkCmpTrigConfigEnable.Text
                = chkFaiConfigEnable.Text
                = chkDisConfigEnable.Text
                = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_Tip_Enable", "启用");

            chkDynamicParamEnable.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_DynamicParamEnable", "换型参数启用");
            chkCommonDynamicParamEnable.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_CommonDynamicParamEnable", "全局参数启用");
            cb_AccessaryNames.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_AccessaryNames", "辅料名称：");
            lb_TossingReasons.Text = NLocalizer.GetString("Lead_CPrim_SoftwareConfig_SoftwareConfigControl_TossingReasons", "抛辅料原因：");
        }

        private void cb_AccessaryNames_CheckedChanged(object sender, EventArgs e)
        {
            lb_TossingReasons.Visible = tb_TossingReason.Visible = cb_AccessaryNames.Checked;
        }

        Task _taskDirectory1 = null;
        Task _taskDirectory2 = null;
        /// <summary>
        /// 定期删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrOneHour_Tick(object sender, EventArgs e)
        {

            //文件夹1删除
            if (_taskDirectory1 == null ||
                (_taskDirectory1.Status == TaskStatus.RanToCompletion
                || _taskDirectory1.Status == TaskStatus.Canceled
                || _taskDirectory1.Status == TaskStatus.Faulted))
            {
                _taskDirectory1 = Task.Factory.StartNew(delegate
                {
                    try
                    {
                        string[] dirTops = _manager?.Directory1?.Split(';');
                        if (dirTops != null && dirTops?.Length > 0)
                        {
                            foreach (var dirTop in dirTops)
                            {
                                /*
                                string[] dirs = Directory.GetDirectories(dirTop, "*", SearchOption.AllDirectories);
                                if (dirs != null && dirs.Length > 0)
                                {
                                    foreach (var dir in dirs)
                                    {
                                        DeleteFile(dir, _manager.Directory1SaveDays);
                                        Thread.Sleep(1);
                                    }
                                }
                                */

                                // IO操作会占用大量CPU线程，此处变更为批处理删除
                                dirTop.GetBatchStringForDeleteFiles(_manager.Directory1SaveDays).RunBatchProcessing();
                            }
                        }
                    }
                    catch { }

                }, TaskCreationOptions.LongRunning);
            }

            if (_taskDirectory2 == null ||
                (_taskDirectory2.Status == TaskStatus.RanToCompletion
                || _taskDirectory2.Status == TaskStatus.Canceled
                || _taskDirectory2.Status == TaskStatus.Faulted))
            {
                _taskDirectory2 = Task.Factory.StartNew(delegate
                {
                    try
                    {
                        string[] dirTops = _manager?.Directory2?.Split(';');
                        if (dirTops != null && dirTops?.Length > 0)
                        {
                            foreach (var dirTop in dirTops)
                            {
                                /*
                                string[] dirs = Directory.GetDirectories(dirTop, "*", SearchOption.AllDirectories);
                                if (dirs != null && dirs.Length > 0)
                                {
                                    foreach (var dir in dirs)
                                    {
                                        DeleteFile(dir, _manager.Directory2SaveDays);
                                        Thread.Sleep(1);
                                    }
                                }
                                */

                                // IO操作会占用大量CPU线程，此处变更为批处理删除
                                dirTop.GetBatchStringForDeleteFiles(_manager.Directory2SaveDays).RunBatchProcessing();
                            }
                        }
                    }
                    catch { }
                }, TaskCreationOptions.LongRunning);
            }
        }

        /// <summary>
        /// 删除超过指定日期的文件
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="days"></param>
        void DeleteFile(string directory, double days)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                {
                    return;
                }

                DirectoryInfo dir = new DirectoryInfo(directory);
                if ((DateTime.Now.Subtract(dir.CreationTime)).TotalDays >= days)
                {
                    if (!DeleteNullDirectory(directory))
                    {
                        string[] files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
                        foreach (var file in files)
                        {
                            FileInfo info = new FileInfo(file);
                            if (DateTime.Now.Subtract(info.CreationTime).TotalDays >= days)
                            {
                                try
                                {
                                    info.Attributes = FileAttributes.Normal;
                                    info.Delete();
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 删除空目录<br/>
        /// True：删除空目录成功；<br/>
        /// False：删除空目录失败；<br/>
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        bool DeleteNullDirectory(string dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
            {
                return true;
            }

            try
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                if (!info.Exists)
                {
                    return true;
                }

                info.Delete();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
        }
        #endregion
    }
}
