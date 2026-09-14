/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: SwManager.cs
 * Author: Victor
 * Description: 软件参数管理类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * <3.3.22.0616><Victor><20220619>
 * 1、事件InstanceSoftwareConfigChangeCurrentProduct优化
 * 
 * <3.3.22.0728><Victor><20220729>
 * 1、增加设备参数定期保存（DataSave）
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.SoftwareConfig;
using Lead.CPrim.ProxyTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ProxyTools.Authority;
using System.Diagnostics;
using System.Drawing;

namespace Lead.CPrim.Global
{
    /// <summary>更新软件名称时发生</summary>
    /// <param name="name">版本号</param>
    public delegate void UpdateSwName(string name);
    /// <summary>改变产品列表时发生</summary>
    /// <param name="products"></param>
    public delegate void UpdateProductsEventHandle(List<string> products);



    /// <summary>软件配置管理器</summary>
    [JsonObject()]
    public class SwManager
    {
        #region Field
        /// <summary>软件配置参数</summary>
        private static SwManager _instance = new SwManager();

        /// <summary>软件配置默认路径</summary>
        private readonly string _defaultConfigFilePath = "D:\\Config\\CPrimConfig\\CPrimConfig.json";

        /// <summary>软件配置路径存储地址</summary>
        private readonly string _swConfigFilePath = Application.StartupPath + "\\Configs\\CPrimConfig.ini";

        /// <summary>软件配置界面</summary>
        private Control _softwareConfigUi;

        /// <summary>Remote Qualification功能使能</summary>
        private bool _remoteQualificationEnable;

        /// <summary>软件名称</summary>
        private string _swName = string.Empty;

        /// <summary>Task版本</summary>
        private string _taskVer = string.Empty;

        /// <summary>压力基元（用于压力曲线使能）</summary>
        private bool _pressPrimEnable = false;

        /// <summary>产品列表</summary>
        private List<string> _products;

        /// <summary>当前产品</summary>
        private string _currentProduct;

        /// <summary>任务日志UI数量</summary>
        private int _taskLogUINo;

        /// <summary>上位机软件Hash码</summary>
        private string _softWareHashCode;


        private string _site;
        #endregion



        #region Prop
        /// <summary>软件配置参数</summary>
        [JsonIgnore]
        public static SwManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SwManager();
                }
                return _instance;
            }
        }
        /// <summary>软件配置界面</summary>
        [JsonIgnore]
        public Control SoftwareConfigUi => _softwareConfigUi;

        public string Site
        {
            get => _site;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || _site == value)
                {
                    return;
                }
                _site = value;
            }
        }

        /// <summary>软件配置路径</summary>
        public string ConfigFilePath { get; set; }

        /// <summary>主题</summary>
        public PaletteMode ThemeMode { get; set; }

        /// <summary>系统描述</summary>
        public string Description { get; set; }

        /// <summary>系统类型</summary>
        public string RemoteCSType { get; set; }

        /// <summary>Remote Qualification功能使能</summary>
        public bool RemoteQualificationEnable
        {
            get => _remoteQualificationEnable;
            set
            {
                _remoteQualificationEnable = value;
                OnChangeRemoteQualificationEnable?.Invoke(value);
            }
        }

        /// <summary>产品列表</summary>
        public List<string> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnUpdateProducts?.Invoke(value);
            }
        }

        /// <summary>当前产品</summary>
        public string CurrentProduct
        {
            get => _currentProduct;
            set
            {
                if (_currentProduct == value)
                {
                    return;
                }
                _currentProduct = value;
                ChangeCurrentProduct(value);
            }
        }
        /// <summary>语言</summary>
        public Language SysLanguage { get; set; }
        /// <summary>上电初始化</summary>
        public bool BootInit { get; set; }
        /// <summary>上电启动</summary>
        public bool BootRun { get; set; }
        /// <summary>Tracking功能使能</summary>
        public bool TrackingEnable { get; set; }
        /// <summary>远程切换配方使能</summary>
        public bool IsRecipeShiftByServer { get; set; }
        /// <summary>配方切换SuperClient名称</summary>
        public string RecipeShiftSuperClientName { get; set; }
        /// <summary>软件标题</summary>
        public string SwName
        {
            get
            {
                return _swName;
            }
            set
            {
                //OnUpdateSwName?.Invoke(value);
                _swName = value;
            }
        }
        /// <summary>Task版本</summary>
        public string TaskVer
        {
            get
            {
                return _taskVer;
            }
            set
            {
                _taskVer = value;
                OnUpdateTaskVer?.Invoke(value);
            }
        }

        /// <summary>权限注销超时时间（秒）</summary>
        public int ExitPermissionTime { get; set; }

        /// <summary>视觉软件名称</summary>
        public string VisionName { get; set; }

        /// <summary>视觉软件路径</summary>
        public string VisionPath { get; set; }

        /// <summary>视觉软件版本</summary>
        public string VisionVersion { get; set; }

        /// <summary>主控</summary>
        public string MasterControl { get; set; }

        public string MasterIp { get; set; }

        /// <summary>任务日志UI数量</summary>
        public int TaskLogUINo
        {
            get => _taskLogUINo;
            set
            {
                if (_taskLogUINo == value)
                {
                    return;
                }
                _taskLogUINo = value;
                OnUpdateTaskLogUINo?.Invoke(value);
            }
        }

        /// <summary>设备参数定期保存</summary>
        public DataSaveMode DataSave { get; set; }
        /// <summary>ConfigFrm绑定FAI名称</summary>
        public string ConfigFrmBindFaiName { get; set; }

        /// <summary>上位机软件Hash码</summary>
        public string SoftWareHashCode
        {
            get => _softWareHashCode;
            set
            {
                if (_softWareHashCode != value)
                {
                    _softWareHashCode = value;
                    OnChangeHashCode?.Invoke(value);
                }
            }
        }

        /// <summary>视觉软件Hash码</summary>
        public string VisionHashCode 
        {
            get;
            set; 
        }

        /// <summary>压力基元（用于压力曲线使能）</summary>
        public bool PressPrimEnable
        {
            get
            {
                return _pressPrimEnable;
            }
            set
            {
                if (_pressPrimEnable.Equals(value))
                {
                    return;
                }
                _pressPrimEnable = value;
            }
        }
        /// <summary>压力基元（用于压力曲线显示）</summary>
        public string PressPrimName { get; set; }
        /// <summary>服务器基元（用于产品切换）</summary>
        public string ServicePrimName { get; set; }
        /// <summary>基元</summary>
        public string PrimsFile { get; set; }
        /// <summary>基元使能</summary>
        public bool PrimsConfigEnable { get; set; }
        /// <summary>显示</summary>
        public string DisplayFile { get; set; }
        /// <summary>显示使能</summary>
        public bool DisplayConfigEnable { get; set; }
        /// <summary>元件</summary>
        public string ElesFile { get; set; }
        /// <summary>元件使能</summary>
        public bool ElesConfigEnable { get; set; }
        /// <summary>任务</summary>
        public string TasksFile { get; set; }
        /// <summary>任务使能</summary>
        public bool TasksConfigEnable { get; set; }
        /// <summary>脉冲比较功能</summary>
        public string CmpTrigFilePath { get; set; }
        /// <summary>脉冲比较功能使能</summary>
        public bool CmpTrigConfigEnable { get; set; }
        /// <summary>参数目录</summary>
        public string DynamicParamDirPath { get; set; }
        /// <summary>换型参数使能</summary>
        public bool DynamicParamEnable { get; set; }
        /// <summary>全局参数使能</summary>
        public bool CommonDynamicParamEnable { get; set; }
        /// <summary>FAI</summary>
        public string FaiConfigFilePath { get; set; }
        /// <summary>FAI使能</summary>
        public bool FaiConfigEnable { get; set; }
        /// <summary>复杂查询任务路径</summary>
        public string ComplexQueryTaskFilePath { get; set; }
        /// <summary>点胶</summary>
        public string DispenserFilePath { get; set; }
        /// <summary>点胶使能</summary>
        public bool DispenserConfigEnable { get; set; }
        /// <summary>全局设置配置文件</summary>
        public string GlobalSettingConfigPath { get; set; } = @"D:\Config\Access Control\Setting.json";
        /// <summary>HashKey配置文件</summary>
        public string HashKeyConfigPath { get; set; } = @"D:\Config\CPrimConfig\HashKey.json";
        /// <summary>权限管理配置文件</summary>
        public string AdministrationConfigPath { get; set; } = @"D:\Config\AdministrationConfig\Administration.csv";

        public string AlertConfigPath { get; set; } = @"D:\Config\AlertConfig\AlertInfo.csv";
        /// <summary>SFL日志</summary>
        public string SFLPath { get; set; }
        /// <summary>PDCA日志</summary>
        public string PDCAPath { get; set; }
        /// <summary>机台日志</summary>
        public string MachinePath { get; set; }
        /// <summary>机台数据</summary>
        public string MachineDataPath { get; set; }

        /// <summary>
        /// 文件夹1
        /// </summary>
        public string Directory1 { get; set; } = @"E:\Image;E:\ImageZip";

        /// <summary>
        /// 文件夹2
        /// </summary>
        public string Directory2 { get; set; } = @"D:\CPrimlog";

        /// <summary>
        /// 文件夹1保存天数
        /// </summary>
        public double Directory1SaveDays { get; set; } = 7;

        /// <summary>
        /// 文件夹2保存天数
        /// </summary>
        public double Directory2SaveDays { get; set; } = 30;
        public bool HasAccessary { get; set; } = true;
        public string AccessaryNames { get; set; } = string.Empty;
        public string AccessaryCodeLength { get; set; } = string.Empty;
        public string TossingReasons { get; set; } = string.Empty;
        public string CurrentProductionType { get; set; } = string.Empty;
        #endregion



        #region Define_Event
        /// <summary>软件配置切换当前产品时发生</summary>
        public event ChangeCurrentProductEventHandle OnSoftwareConfigChangeCurrentProduct;
        /// <summary>改变产品列表时发生</summary>
        public event UpdateProductsEventHandle OnUpdateProducts;
        /// <summary>任务日志UI数量发生变化时发生</summary>
        public event Action<int> OnUpdateTaskLogUINo;
        /// <summary>更新Task版本时发生</summary>
        public event Action<string> OnUpdateTaskVer;
        /// <summary>更新软件名称时发生</summary>
        public event UpdateSwName OnUpdateSwName;

        /// <summary>更新Remote Qualification功能使能时发生</summary>
        public event Action<bool> OnChangeRemoteQualificationEnable;

        /// <summary>更新Hash码时发生</summary>
        public event Action<string> OnChangeHashCode;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        private SwManager()
        {
            Description = "CPrim for ";
            ConfigFilePath = "";
            PrimsFile = "";
            PrimsConfigEnable = true;
            DisplayFile = "";
            DisplayConfigEnable = true;
            ElesFile = "";
            ElesConfigEnable = true;
            TasksFile = "";
            TasksConfigEnable = true;
            CmpTrigFilePath = "";
            CmpTrigConfigEnable = false;
            FaiConfigFilePath = "";
            FaiConfigEnable = false;
            DispenserConfigEnable = false;
            DispenserFilePath = "";
            DynamicParamDirPath = "";
            DynamicParamEnable = false;
            CommonDynamicParamEnable = false;
            Products = new List<string>();
            CurrentProduct = "";
            RemoteCSType = "Client";
            RemoteQualificationEnable = false;
            TrackingEnable = false;
            ThemeMode = PaletteMode.Custom;
            SysLanguage = Language.zh_CN;
            BootInit = false;
            BootRun = false;
            IsRecipeShiftByServer = false;
            RecipeShiftSuperClientName = "";
            ComplexQueryTaskFilePath = "";
            SwName = "CPrim";
            TaskVer = "V1.0";
            ExitPermissionTime = 5 * 60;
            VisionName = "HyEye";
            VisionPath = string.Empty;
            VisionVersion = "V1.0";
            _softwareConfigUi = new SoftwareConfigControl(this);
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
        }
        #endregion



        #region Method_ExternalUsing
        public bool SiteAlert(string site)
        {
            if (Instance.Site != site)
            {
                UIMessageDialog.ShowMessageDialog($"工厂信息设置错误，当前为{Instance.Site}，请重新设置", ULocalize.ErrorTitle, false, UIStyle.Red, false, true);
                return true;
            }
            return false;
        }

        /// <summary>改变当前产品（切换产品后参数自动保存本地）</summary>
        /// <param name="productName"></param>
        /// <param name="eventNotice"></param>
        /// <returns></returns>
        public int ChangeCurrentProduct(string productName, bool eventNotice = true)
        {
            if (string.IsNullOrEmpty(productName))
            {
                LogAdd("SoftwareConfig_当前产品为空", LogLevel.Warn);
                return (int)SoftWareAlarm.SoftwareConfig_当前产品为空;
            }

            _instance.CurrentProduct = productName;
            ((SoftwareConfigControl)_softwareConfigUi).RefreshCurrentProduct(productName);
            if (eventNotice)
            {
                _instance.OnSoftwareConfigChangeCurrentProduct?.Invoke(productName, Products);
            }

            return ExportSWConfigToPath(_instance.ConfigFilePath);
        }
        /// <summary>日志增加</summary>
        /// <param name="msg">消息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示报警弹窗；false：不显示报警弹窗</param>
        private void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            string tempId = $"{(int)lv}{(int)PrimLogId.SoftwareConfig}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.SoftwareConfig.ToString(), LogClassification.Other, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }


        #endregion



        #region Method_Instance
        /// <summary>响应权限等级改变</summary>
        /// <param name="level"></param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            bool enable = AuthorityManager.Instance.VerifyLevel3Permission();
            ((SoftwareConfigControl)_softwareConfigUi).SetEnable(enable);
        }
        #endregion



        #region other

        /// <summary>软件配置初始化</summary>
        /// <param name="configFilePath"></param>
        /// <returns>int</returns>
        public int Init(string configFilePath = null)
        {
            try
            {
                if (configFilePath == null) configFilePath = _swConfigFilePath;
                string text = configFilePath?.Substring(configFilePath.LastIndexOf("\\") + 1);
                string path = configFilePath?.Substring(0, configFilePath.LastIndexOf("\\"));
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "json文件|*.json|所有文件|*.*",
                    RestoreDirectory = true,
                    Title = "请新建CPrim软件配置文件",
                    DefaultExt = ".json"
                };
                if (!File.Exists(configFilePath))
                {
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                    File.Create(configFilePath).Close();
                    _instance.ConfigFilePath = ((saveFileDialog.ShowDialog() != DialogResult.OK) ? _defaultConfigFilePath : saveFileDialog.FileName);
                    Save();
                    return -5;
                }

                using (FileStream fileStream = new FileStream(configFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                {
                    string text2 = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(text2))
                    {
                        if (File.Exists(text2))
                        {
                            SwManager swManager = JsonHelper.DeserializeJsonFileToObject<SwManager>(text2);
                            if (swManager != null)
                            {
                                _instance = swManager;
                                _instance.ConfigFilePath = swManager.ConfigFilePath;
                                return 0;
                            }

                            _instance.ConfigFilePath = ((saveFileDialog.ShowDialog() != DialogResult.OK) ? _defaultConfigFilePath : saveFileDialog.FileName);
                            Save();
                            return -2;
                        }

                        string path2 = text2?.Substring(0, text2.LastIndexOf("\\"));
                        if (!Directory.Exists(path2)) Directory.CreateDirectory(path2);

                        File.Create(text2).Close();
                        _instance.ConfigFilePath = text2;
                        Save();
                        return 1;
                    }

                    _instance.ConfigFilePath = ((saveFileDialog.ShowDialog() != DialogResult.OK) ? _defaultConfigFilePath : saveFileDialog.FileName);
                    Save();
                    return -1;
                }
            }
            catch (Exception)
            {
                _instance.ConfigFilePath = _defaultConfigFilePath;
                Save();
                return -10;
            }
            finally
            {
                _softwareConfigUi = new SoftwareConfigControl(_instance);
            }
        }

        internal int ReLoad()
        {
            return Init(_swConfigFilePath);
        }

        /// <summary>软件配置路径保存</summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        internal int ExportSWConfigsPathToFile(string configFilePath)
        {
            try
            {
                string text = configFilePath?.Substring(configFilePath.LastIndexOf("\\") + 1);
                string path = configFilePath?.Substring(0, configFilePath.LastIndexOf("\\"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = new FileStream(configFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(_instance.ConfigFilePath);
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"SoftwareConfig_软件配置路径保存失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.SoftwareConfig_软件配置路径保存失败;
            }
        }

        /// <summary>软件配置保存</summary>
        /// <param name="saveFileFileName">软件配置路径</param>
        /// <returns></returns>
        internal int ExportSWConfigToPath(string saveFileFileName)
        {
            if (string.IsNullOrEmpty(saveFileFileName))
            {
                LogAdd("SoftwareConfig_软件配置路径不存在", LogLevel.Warn);
                return (int)SoftWareAlarm.SoftwareConfig_软件配置路径不存在;
            }

            if (!File.Exists(saveFileFileName))
            {
                LogAdd("SoftwareConfig_软件配置路径不存在", LogLevel.Warn);
                return (int)SoftWareAlarm.SoftwareConfig_软件配置路径不存在;
            }

            if (JsonHelper.SerializeObjectToFile(_instance, _instance.ConfigFilePath, null))
            {
                return ExportSWConfigsPathToFile(_swConfigFilePath);
            }
            else
            {
                LogAdd("SoftwareConfig_软件配置保存失败", LogLevel.Warn);
                return (int)SoftWareAlarm.SoftwareConfig_软件配置保存失败;
            }
        }

        /// <summary>保存软件配置参数-1</summary>
        /// <returns></returns>
        public int Save()
        {
            if (AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
                ((SoftwareConfigControl)_softwareConfigUi).SaveSWParams();
                int result = ExportSWConfigToPath(ConfigFilePath);
                if (result == 0)
                {
                    UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_Global_SWParamsConfigSaveSuccess", "系统设置保存成功"));
                }
                return result;
            }
            return -1;
        }

        /// <summary>更新产品列表</summary>
        /// <param name="products"></param>
        internal void UpdateProducts(List<string> products)
        {
            OnUpdateProducts?.Invoke(products);
        }

        /// <summary>Override ToString</summary>
        public override string ToString()
        {
            return Description;
        }
        #endregion
    }
}
