using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.StationCommon.CommonUI;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon
{
    /// <summary>
    /// 工站管理器
    /// </summary>
    [JsonObject(/*Could not decode attribute arguments.*/)]
    public class StationManager
    {
        #region Field
        /// <summary>工站管理器</summary>
        private static readonly StationManager _instance = new StationManager();
        /// <summary>软件配置_工站配置路径</summary>
        private readonly string _defaultConfigFilePath = @"D:\Config\StationConfig\StationConfigs.json";
        /// <summary>软件内部_工站配置路径</summary>
        private readonly string StationsConfigFilePath = Application.StartupPath + "\\Configs\\StationsConfig.ini";

        /// <summary>
        /// 当前工站名称
        /// </summary>
        string _currentStationName;
        #endregion


        #region Define_Event
        /// <summary>增加工站事件</summary>
        public event Del_ChangeStation OnAddNewStation;
        /// <summary>删除工站事件</summary>
        public event Del_ChangeStation OnRemoveStation;
        /// <summary>更新工站事件</summary>
        public event Del_UpdateStation OnUpdateStation;
        /// <summary>更新主界面UI</summary>
        public event Del_UpdateStationForm OnUpdateStationForm;
        #endregion


        #region Prop
        /// <summary>工站管理器的静态实例</summary>
        [JsonIgnore]
        public static StationManager Instance => _instance;
        /// <summary>工站管理器界面</summary>
        [JsonIgnore]
        public Control StationsConfigUi { get; set; }
        /// <summary>工站集合</summary>
        public ConcurrentDictionary<string, StationConfig> Stations { get; set; }
        /// <summary>当前工站</summary>
        [JsonIgnore]
        public StationConfig CurrentStation
        {
            get
            {
                if (!string.IsNullOrEmpty(CurrentStationName) && Stations.ContainsKey(CurrentStationName))
                {
                    return Stations[CurrentStationName];
                }
                return null;
            }
        }
        /// <summary>当前工站名称</summary>
        public string CurrentStationName 
        { 
            get => _currentStationName; 
            set
            {
                _currentStationName = value;
                GlobalVariables.CurrentStationName = value;
            }
        }
        /// <summary>工站配置文件路径</summary>
        public string ConfigFilePath { get; set; }
        #endregion



        #region Ctor
        public StationManager()
        {
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 初始化工站配置（软件路径均以软件内部为主）
        /// </summary>
        /// <param name="configFilePath">软件内部_工站配置路径</param>
        /// <returns>0-成功</returns>
        public int Init(string configFilePath = null)
        {
            try
            {
                if (configFilePath == null)
                {
                    configFilePath = StationsConfigFilePath;
                }
                string fileName = configFilePath?.Substring(configFilePath.LastIndexOf("\\") + 1);
                string dirPath = configFilePath?.Substring(0, configFilePath.LastIndexOf("\\"));
                SaveFileDialog fileSaveDialog = new SaveFileDialog
                {
                    Filter = "json文件|*.json|所有文件|*.*",
                    RestoreDirectory = true,
                    Title = $"请新建工站管理器配置文件，建议取消使用默认地址：{_defaultConfigFilePath} ",
                    DefaultExt = ".json"
                };

                //[软件内部_工站配置路径]不存在，使用默认路径
                if (!File.Exists(configFilePath))
                {
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    File.WriteAllText(configFilePath, _defaultConfigFilePath);
                }

                using (FileStream fs = new FileStream(configFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    string path = sr.ReadLine();

                    //文件存在，但是读出来为空
                    if (string.IsNullOrEmpty(path))
                    {
                        path = _defaultConfigFilePath;
                    }

                    //文件可以正常读出路径，判断读出路径是否存在
                    if (!File.Exists(path))
                    {
                        throw new Exception($"工站管理器路径存储地址={configFilePath}存储地址={path}不存在");
                    }

                    StationManager obj = JsonHelper.DeserializeJsonFileToObject<StationManager>(path);
                    if (obj == null)
                    {
                        throw new Exception($"工站管理器路径存储地址={configFilePath}存储地址={path}不能正常解析");
                    }
                    Stations = obj.Stations;
                    CurrentStationName = obj.CurrentStationName;
                    //ConfigFilePath = obj.ConfigFilePath;
                    ConfigFilePath = path;
                    //初始化全局变量
                    Stations.ToList().ForEach(p => p.Value.DataInfosInit());
                    //初始化实时变量
                    Stations.ToList().ForEach(p => p.Value.RtDataVarsInit());

                    return 0;
                }
            }
            catch
            {
                Stations = new ConcurrentDictionary<string, StationConfig>();
                StationConfig newStation = new StationConfig("Station1");
                Stations.TryAdd(newStation.Name, newStation);
                CurrentStationName = "Station1";
                ConfigFilePath = _defaultConfigFilePath;
                //ConfigFilePath = ((fileSaveDialog.ShowDialog() != DialogResult.OK) ? _defaultConfigFilePath : fileSaveDialog.FileName);

                Save();
                return -10;
            }
            finally
            {
                StationsConfigUi = new StationsConfigControl(_instance);
                ((DataForm)Instance.CurrentStation.DataControl).DataInit();
            }
        }
        #endregion



        #region 工站相关
        /// <summary>
        /// 重新载入工站配置
        /// </summary>
        /// <returns>0-成功</returns>
        internal int ReLoad()
        {
            return Init(StationsConfigFilePath);
        }

        /// <summary>
        /// 添加一个工站
        /// </summary>
        /// <param name="newName">新建的工站名</param>
        /// <returns></returns>
        internal int AddNewStation(string newName)
        {
            if (string.IsNullOrEmpty(newName.Trim()))
                throw new Exception("工站名为空，请重新添加");

            if (Stations.ContainsKey(newName))
                throw new Exception("工站名称重复，请重新添加");

            StationConfig newStation = new StationConfig(newName);
            if (Stations.TryAdd(newName, newStation))
            {
                ChangeCurrentStation(newName);
                ((StationsConfigControl)StationsConfigUi).LoadControls(this);
            }
            this.OnAddNewStation?.Invoke(newName);
            return 0;
        }

        /// <summary>
        /// 更改当前工站名称
        /// </summary>
        /// <param name="stationName">工站名</param>
        /// <returns>0-成功</returns>
        internal int ChangeCurrentStation(string stationName)
        {
            if (string.IsNullOrEmpty(stationName) || !Stations.ContainsKey(stationName))
            {
                CurrentStationName = "";
                ((StationsConfigControl)StationsConfigUi).LoadControls(this);
                return -1;
            }
            else
            {
                CurrentStationName = stationName;
                ((StationsConfigControl)StationsConfigUi).LoadControls(this);
                CurrentStation.ClearOnEvent();
                return 0;
            }
        }

        /// <summary>
        /// 更改当前工站名称
        /// </summary>
        /// <param name="stationName">工站名</param>
        /// <returns>0-成功</returns>
        internal int ChangeCurrentStationwithoutClear(string stationName)
        {
            CurrentStationName = stationName;
            ((StationsConfigControl)StationsConfigUi).LoadControlsWithoutClear();
            CurrentStation.ClearOnEvent();
            return 0;
        }

        /// <summary>
        /// 移除一个工站
        /// </summary>
        /// <param name="name">工站名称</param>
        /// <returns>0-成功</returns>
        internal int RemoveStation(string name)
        {
            if (Stations.TryRemove(name, out _))
            {
                ChangeCurrentStation(null);
                ((StationsConfigControl)StationsConfigUi).LoadControls(this);
                this.OnRemoveStation?.Invoke(name);
            }
            return 0;
        }

        /// <summary>
        /// 返回当前工站名
        /// </summary>
        /// <returns>当前工站名</returns>
        public override string ToString()
        {
            return CurrentStationName;
        }

        /// <summary>
        /// 获取工站集合
        /// </summary>
        /// <returns>工站集合</returns>
        public List<string> GetStations()
        {
            return Stations.Keys.ToList();
        }
        #endregion



        #region 配方相关
        /// <summary>
        /// 切换当前配方
        /// </summary>
        /// <param name="name">工站名</param>
        /// <param name="currentRecipeName">需切换到的配方名</param>
        internal void ChangeCurrentRecipe(string name, string currentRecipeName)
        {
            Save();
        }

        /// <summary>
        /// 选择一个配方
        /// </summary>
        /// <param name="stationName">工站名</param>
        /// <param name="recipeName">配方名</param>
        /// <returns>0-成功</returns>
        internal int SelectRecipe(string stationName, string recipeName)
        {
            if (Stations.ContainsKey(stationName) && Stations[stationName].Recipes.ContainsKey(recipeName))
            {
                return Stations[stationName].SelectRecipe(recipeName);
            }
            return -10;
        }

        /// <summary>
        /// 获取相应工站的配方集合
        /// </summary>
        /// <param name="stationName">工站名</param>
        /// <returns>配方集合</returns>
        internal List<string> GetRecipes(string stationName)
        {
            if (Stations.ContainsKey(stationName))
            {
                List<string> recipes = new List<string>();
                string curRecipe = "";
                Stations[stationName].ReturnRecipes(ref recipes, ref curRecipe);
                return recipes;
            }
            return null;
        }
        #endregion



        #region 工站管理器保存
        /// <summary>保存工站地址至指定路径</summary>
        /// <param name="configFilePath">软件内部_工站配置路径</param>
        /// <returns>0-成功</returns>
        internal int ExportStationConfigsPathToFile(string configFilePath)
        {
            try
            {
                string fileName = configFilePath?.Substring(configFilePath.LastIndexOf("\\") + 1);
                string dirPath = configFilePath?.Substring(0, configFilePath.LastIndexOf("\\"));
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                using (FileStream fs = new FileStream(configFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(ConfigFilePath);
                }
                return 0;
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError("保存失败：" + ex.Message);
                return -1;
            }
        }

        /// <summary>保存工站配置文件至指定路径（全局变量赋值/）</summary>
        /// <param name="saveFileFileName"></param>
        /// <param name="exportStationConfigsPathToFile"></param>
        /// <returns>int</returns>
        internal int ExportStationsConfigToPath(string saveFileFileName, bool exportStationConfigsPathToFile = false)
        {
            if (string.IsNullOrEmpty(saveFileFileName))
            {
                MessageBox.Show("工站配置文件存储路径为空，不能保存。");
                return -2;
            }
            if (!File.Exists(saveFileFileName))
            {
                string tempPath = saveFileFileName.Substring(0, saveFileFileName.LastIndexOf("\\"));
                if (!Directory.Exists(tempPath)) Directory.CreateDirectory(tempPath);
                File.Create(saveFileFileName).Close();
            }

            ConfigFilePath = saveFileFileName;
            if (!exportStationConfigsPathToFile)
            {
                JsonHelper.SerializeObjectToFile(_instance, ConfigFilePath);
            }

            return exportStationConfigsPathToFile ? ExportStationConfigsPathToFile(StationsConfigFilePath) : 0;
        }
        #endregion



        #region Method_Instance
        /// <summary>响应权限等级改变</summary>
        /// <param name="level"></param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            bool enable = AuthorityManager.Instance.VerifyLevel2Permission();
            SetEnable(enable);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>保存工站管理器配置（如果是配方产品模式同时处理换型参数）</summary>
        /// <returns>0-成功</returns>
        public int Save()
        {
            if (AuthorityManager.Instance.VerifyLevel2Permission(true))
            {
                ((StationsConfigControl)StationsConfigUi).BeforeSave();
                if (ExportStationsConfigToPath(ConfigFilePath) == 0)
                {
                    OnUpdateStation?.Invoke();
                    CurrentStation?.UpdateMainBtn();
                    OnUpdateStationForm?.Invoke();
                    UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_StationCommon_StationManager_StationConfigSaveSuccess", "工站设置保存成功"));
                    return 0;
                }
            }
            return -1;
        }

        public int OnlySave()
        {
            return ExportStationsConfigToPath(ConfigFilePath);
        }

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"StationManager -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.StationCommon}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.StationCommon.ToString(), LogClassification.Station, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, ProxyTools.SunnyUI.Style.UIStyle.Orange, false, true);
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        private void SetEnable(bool enable)
        {
            if (Stations == null || Stations.Count <= 0)
            {
                return;
            }
            foreach (StationConfig station in Stations.Values)
            {
                ((SingleStationConfigControl)(station.ConfigUi))?.SetEnable(enable);
            }
            ((StationsConfigControl)StationsConfigUi)?.SetEnable(enable);
        }
        #endregion



        #region 待删除
        /// <summary>
        /// 新建一个配方
        /// </summary>
        /// <param name="name">工站名</param>
        /// <param name="newRecipeName">新建配方的名称</param>
        internal void CreateNewRecipe(string name, string newRecipeName)
        {
            //this.OnCreateNewRecipe?.Invoke(name, newRecipeName);
        }

        /// <summary>
        /// 删除一个配方
        /// </summary>
        /// <param name="name">工站名</param>
        /// <param name="removedRecipeName">删除的配方名称</param>
        internal void DeleteRecipe(string name, string removedRecipeName)
        {
            //this.OnDeleteRecipe?.Invoke(name, removedRecipeName);
        }

        /// <summary>
        /// 上传配方集合
        /// </summary>
        /// <param name="name">工站名称</param>
        /// <param name="recipes">配方名的集合</param>
        /// <param name="currentRecipeName">当前配方名</param>
        internal void UpLoadRecipes(string name, List<string> recipes, string currentRecipeName)
        {
            //this.OnUploadRecipes?.Invoke(name, recipes, currentRecipeName);
        }
        #endregion
    }
}
