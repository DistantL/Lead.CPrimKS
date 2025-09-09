using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.StationCommon.DataArea;
using Lead.CPrim.StationCommon.MainOutput;
using Lead.CPrim.StationCommon.Recipe;
using Lead.CPrim.StationCommon.RtData;
using Lead.CPrim.StationCommon.RtVars;
using Lead.CPrim.StationCommon.CommonUI;
using Newtonsoft.Json;

namespace Lead.CPrim.StationCommon
{
    /// <summary>
    /// 单工站配置
    /// </summary>
    [JsonObject(/*Could not decode attribute arguments.*/)]
    public class StationConfig
    {
        #region Define_Event
        /// <summary>添加一个安全信号</summary>
        public event Del_ChangeEleItemType OnAddAbnormalDi;

        /// <summary>工站主界面中按钮按下</summary>
        public event ButtonPressEventHandle OnButtonPressed;

        /// <summary>修改当前配方</summary>
        public event Action<string, string> OnChangeCurrentRecipe;

        /// <summary>改变元件成员的元件类型</summary>
        public event Del_ChangeEleItemType OnChangeEleItemType;

        /// <summary>切换工站主界面上的TAB选项卡</summary>
        public event Del_ChangeTab OnChangeStateTab;

        /// <summary>新建一个配方</summary>
        public event Action<string, string> OnCreateNewRecipe;

        /// <summary>删除一个配方</summary>
        public event Action<string, string> OnDeleteRecipe;

        /// <summary>
        /// 获取统计界面时发生<br/>
        /// 关联供应商/统计<br/>
        /// </summary>
        public event Func<string, string, int> OnGetStationStatictis;

        /// <summary>移除一个安全信号</summary>
        public event Del_ChangeEleItemType OnRemoveAbnormalDi;

        /// <summary>状态机初始化状态改变时发生</summary>
        public event Action<int> OnStationMachineTaskButton;

        /// <summary>
        /// 设置统计界面时发生<br/>
        /// 关联供应商/统计<br/>
        /// </summary>
        public event Func<string, string, int, int, int, int> OnStationStatictis;

        /// <summary>更新工站主界面三个按钮</summary>
        public event Del_UpdateMainBtn OnUpdateMainBtn;

        /// <summary>上传工站集合</summary>
        public event Del_UploadRecipes OnUploadRecipes;

        /// <summary>选择工站控件</summary>
        internal event UiSelected OnEventSelected;
        #endregion



        #region Field
        /// <summary>已选择</summary>
        private bool _isSelected;

        /// <summary>工站管理器</summary>
        private StationManager _manager = StationManager.Instance;

        /// <summary>全局变量掉电保持加锁</summary>
        private object _objLockSaveDt = new object();

        /// <summary>工站初始化标志</summary>
        private bool _stationMachineInited = false;
        #endregion



        #region Prop
        //按钮
        /// <summary>主界面按钮使能</summary>
        public bool[] BtnEnable { get; set; } = new bool[3];

        /// <summary>主界面按钮名称</summary>
        public string[] BtnInfo { get; set; } = new string[3];

        /// <summary>当前全局变量</summary>
        [JsonIgnore]
        public ConcurrentDictionary<string, DataInfo> CurrentDataInfos
        {
            get
            {
                if (DataInfos != null && !string.IsNullOrEmpty(CurrentRecipeName) && DataInfos.ContainsKey(CurrentRecipeName))
                {
                    return DataInfos[CurrentRecipeName];
                }
                return new ConcurrentDictionary<string, DataInfo>();
            }
        }

        /// <summary>当前主界面配置</summary>
        [JsonIgnore]
        public SingleDisplayConfig CurrentDisplayConfig
        {
            get
            {
                if (CurrentRecipe != null && !string.IsNullOrEmpty(CurrentRecipe.MainGuiConfigName) && MainPrimsDisplay.ContainsKey(CurrentRecipe.MainGuiConfigName))
                {
                    return MainPrimsDisplay[CurrentRecipe.MainGuiConfigName];
                }
                return new SingleDisplayConfig();
            }
        }

        /// <summary>当前配方</summary>
        [JsonIgnore]
        public SingleRecipeCfg CurrentRecipe
        {
            get
            {
                if (!string.IsNullOrEmpty(CurrentRecipeName) && Recipes.ContainsKey(CurrentRecipeName))
                {
                    return Recipes[CurrentRecipeName];
                }
                return new SingleRecipeCfg();
            }
        }

        /// <summary>当前配方名称</summary>
        public string CurrentRecipeName { get; set; }

        /// <summary>当前实时变量</summary>
        [JsonIgnore]
        public RtDataVars CurrentRtDataVars
        {
            get
            {
                if (CurrentRecipe != null && !string.IsNullOrEmpty(CurrentRecipe.OutputValsName) && RtDataVarses.ContainsKey(CurrentRecipe.OutputValsName))
                {
                    return RtDataVarses[CurrentRecipe.OutputValsName];
                }
                return new RtDataVars();
            }
        }

        /// <summary>实时变量控件</summary>
        [JsonIgnore]
        public Control DataControl { get; set; }

        //全局变量
        /// <summary>全局变量集合_配方+全局变量</summary>
        public ConcurrentDictionary<string, ConcurrentDictionary<string, DataInfo>> DataInfos { get; set; }

        /// <summary>工站描述</summary>
        public string Description { get; set; }

        /// <summary>工站使能</summary>
        public bool Enable { get; set; }

        /// <summary>工站ID</summary>
        public Guid Gid { get; set; }

        /// <summary>工站序号</summary>
        public int Index { get; set; }

        //主界面
        /// <summary>主界面集合</summary>
        public ConcurrentDictionary<string, SingleDisplayConfig> MainPrimsDisplay { get; set; }

        /// <summary>工站名称</summary>
        public string Name { get; set; }

        //配方
        /// <summary>配方集合</summary>
        public ConcurrentDictionary<string, SingleRecipeCfg> Recipes { get; set; }

        //实时数据
        /// <summary>实时变量控件</summary>
        [JsonIgnore]
        public Control RtDataControl { get; set; }

        /// <summary>实时变量数据库名称</summary>
        public string RtDataVarsCollection { get; set; } = "RtDataVars";

        //实时变量
        /// <summary>实时变量显示使能</summary>
        public bool RtDataVarsEnable { get; set; }

        /// <summary>实时变量集合（配方名称，实时变量集合管理器）</summary>
        public ConcurrentDictionary<string, RtDataVars> RtDataVarses { get; set; }

        /// <summary>工站初始化标志</summary>
        public bool StationMachineInited
        {
            get
            {
                return _stationMachineInited;
            }
            set
            {
                _stationMachineInited = value;
                ((SingleStationConfigControl)ConfigUi).TaskButtonEnable(value);
            }
        }

        //产能数据
        /// <summary>总产能</summary>
        [JsonIgnore]
        public int TotalCount { get; set; } = 0;

        /// <summary>无效计数</summary>
        [JsonIgnore]
        public int TotalInvalid { get; set; } = 0;

        /// <summary>NG计数</summary>
        [JsonIgnore]
        public int TotalNg { get; set; } = 0;

        /// <summary>OK计数</summary>
        [JsonIgnore]
        public int TotalOk { get; set; } = 0;

        /// <summary>工站界面</summary>
        [JsonIgnore]
        internal Control ConfigUi { get; set; }
        /// <summary>已选择</summary>
        [JsonIgnore]
        internal bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    ConfigUi.BackColor = (value ? Color.Green : Color.LightGray);
                    if (value)
                    {
                        OnEventSelected?.Invoke(this);
                    }
                }
            }
        }
        #endregion



        #region Ctor
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="newName">工站名称</param>
        public StationConfig(string newName)
        {
            Gid = Guid.NewGuid();
            Name = newName;
            Index = 0;
            Description = "";
            Enable = true;
            CurrentRecipeName = "";
            for (int j = 0; j < BtnEnable.Length; j++)
            {
                BtnEnable[j] = false;
            }
            for (int i = 0; i < BtnInfo.Length; i++)
            {
                BtnInfo[i] = "";
            }
            Recipes = new ConcurrentDictionary<string, SingleRecipeCfg>();
            MainPrimsDisplay = new ConcurrentDictionary<string, SingleDisplayConfig>();
            DataInfos = new ConcurrentDictionary<string, ConcurrentDictionary<string, DataInfo>>();
            RtDataVarses = new ConcurrentDictionary<string, RtDataVars>();
            ConfigUi = new SingleStationConfigControl(this);
            RtDataControl = new RtDataControl();
            DataControl = new DataForm(this);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>Data界面添加单条数据<br/>
        /// 目前仅支持ProductInfo类型</summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="entiy">单个对象</param>
        /// <param name="saveDataBase">true：保存数据库；false：不保存数据库；</param>
        /// <param name="productName">产品名称（数据库集合名）</param>
        /// <param name="faiResults">结果集合（用于FAI项OK/NG显示）</param>
        /// <returns>0</returns>
        public int AddRtData<T>(T entiy, bool saveDataBase = false, string productName = null, Dictionary<string, bool> faiResults = null) where T : class
        {
            int iRet = 0;
            List<T> listEntiy = new List<T> { entiy };
            List<Dictionary<string, bool>> listFaiResult = new List<Dictionary<string, bool>> { faiResults };
            ((RtDataControl)RtDataControl).AddMultiPartInfo(listEntiy, saveDataBase, Name, productName, listFaiResult);
            ((DataForm)DataControl).AddMultiPartInfo(listEntiy, saveDataBase, Name, productName, listFaiResult);
            return iRet;
        }

        /// <summary>Data界面添加多条数据<br/>
        /// 目前仅支持ProductInfo类型</summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="listEntiy">对象集合</param>
        /// <param name="saveDataBase">true：保存数据库；false：不保存数据库；</param>
        /// <param name="productName">产品名称（数据库集合名）</param>
        /// <param name="dicFaiResults">结果集合（用于FAI项OK/NG显示）</param>
        /// <returns>0</returns>
        public int AddRtData<T>(List<T> listEntiy, bool saveDataBase = false, string productName = null, List<Dictionary<string, bool>> dicFaiResults = null) where T : class
        {
            int iRet = 0;
            ((RtDataControl)RtDataControl).AddMultiPartInfo(listEntiy, saveDataBase, Name, productName, dicFaiResults);
            ((DataForm)DataControl).AddMultiPartInfo(listEntiy, saveDataBase, Name, productName, dicFaiResults);
            return iRet;
        }

        public int GetStationStatictis(string workName, string valueName)
        {
            return OnGetStationStatictis == null ? -3 : OnGetStationStatictis.Invoke(workName, valueName);
        }

        /// <summary>
        /// 设置统计界面时发生<br/>
        /// 0：成功<br/>
        /// -1：超出报警次数<br/>
        /// -2：超出警告次数<br/>
        /// -3：OnStationStatictis未被注册<br/>
        /// </summary>
        /// <param name="workName"></param>
        /// <param name="valueName"></param>
        /// <param name="count"></param>
        /// <param name="warnCount"></param>
        /// <param name="errorCount"></param>
        /// <returns></returns>
        public int SetStationStatictis(string workName, string valueName, int count, int warnCount = 0, int errorCount = 0)
        {
            if(OnStationStatictis == null)
            {
                return -3;
            }

            return OnStationStatictis.Invoke(workName, valueName, count, warnCount, errorCount);
        }

        /// <summary>
        /// 任务操作<br/>
        /// 1：释放任务<br/>
        /// 2：加载任务<br/>
        /// </summary>
        /// <param name="button"></param>
        public void StationMachineTaskButton(int button)
        {
            OnStationMachineTaskButton?.Invoke(button);
        }

        /// <summary>清除工站事件</summary>
        internal void ClearOnEvent()
        {

        }
        #endregion



        #region Method_InternalUsing
        /// <summary>枚举DataType默认值获取</summary>
        /// <param name="dt">DataType</param>
        /// <param name="info"></param>
        /// <returns>object</returns>
        private object GetDataTypeDefault(DataType dt, DataInfo info)
        {
            object obj = null;
            switch (dt)
            {
                case DataType.BOOL:
                    obj = false;
                    break;

                case DataType.DOUBLE:
                    obj = 0.0;
                    break;

                case DataType.CLASS:
                    obj = new GlobalVariableClass(info.Name, info.Properties);
                    break;

                case DataType.INT:
                    obj = 0;
                    break;

                case DataType.STRING:
                case DataType.Other:
                default:
                    obj = "";
                    break;
            }
            return obj;
        }
        #endregion



        #region 配方相关
        /// <summary>
        /// 注销配方上传事件的已订阅者
        /// </summary>
        public void ClearEventOnUploadRecipes()
        {
            if (this.OnUploadRecipes != null)
            {
                Delegate[] invocationList = this.OnUploadRecipes.GetInvocationList();
                foreach (Delegate d in invocationList)
                    OnUploadRecipes -= d as Del_UploadRecipes;
            }
        }

        /// <summary>
        /// 返回配方集合和当前配方名称
        /// </summary>
        /// <param name="recipes">配方集合</param>
        /// <param name="currentRecipe">当前配方名</param>
        /// <returns></returns>
        public int ReturnRecipes(ref List<string> recipes, ref string currentRecipe)
        {
            recipes = Recipes.Keys.ToList();
            currentRecipe = CurrentRecipeName;
            return 0;
        }

        /// <summary>选择配方</summary>
        /// <param name="recipeName">配方名</param>
        /// <returns>0-成功，1-已是当前配方</returns>
        public int SelectRecipe(string recipeName)
        {
            if (Recipes.ContainsKey(recipeName) && CurrentRecipeName != recipeName)
            {
                CurrentRecipeName = recipeName;
                ChangeCurrentRecipe();
                ((SingleStationConfigControl)ConfigUi).UpdateCurrentRecipe();
                return 0;
            }
            if (CurrentRecipeName == recipeName)
            {
                return 1;
            }
            return -10;
        }

        /// <summary>
        /// 更改当前配方
        /// </summary>
        internal void ChangeCurrentRecipe()
        {
            OnChangeCurrentRecipe?.Invoke(Name, CurrentRecipeName);
            _manager.ChangeCurrentRecipe(Name, CurrentRecipeName);
        }

        /// <summary>
        /// 新建一个配方
        /// </summary>
        /// <param name="newRecipeName">配方名</param>
        internal void CreateNewRecipe(string newRecipeName)
        {
            OnCreateNewRecipe?.Invoke(Name, newRecipeName);
            _manager.CreateNewRecipe(Name, newRecipeName);
        }
        /// <summary>
        /// 删除一个配方
        /// </summary>
        /// <param name="removedRecipeName">配方名</param>
        internal void DeleteRecipe(string removedRecipeName)
        {
            OnDeleteRecipe?.Invoke(Name, removedRecipeName);
            _manager.DeleteRecipe(Name, removedRecipeName);
        }

        /// <summary>
        /// 上传配方集合
        /// </summary>
        internal void UpLoadRecipes()
        {
            OnUploadRecipes?.Invoke(Name, Recipes.Keys.ToList(), CurrentRecipeName);
            _manager.UpLoadRecipes(Name, Recipes.Keys.ToList(), CurrentRecipeName);
        }
        #endregion



        #region 全局变量相关
        /// <summary>获取全局变量当前值_外部调用</summary>
        /// <param name="name">变量名</param>
        /// <returns>变量值</returns>
        public object GetDataInfoVal(string name)
        {
            DataInfo dt = GetDataInfoByName(name);
            return dt == null ? null : dt.Value;
        }

        /// <summary>给全局变量赋值</summary>
        /// <param name="valName">变量名</param>
        /// <param name="value">变量值</param>
        /// <returns>0-成功</returns>
        public int SetDataInfoVal(string valName, object value)
        {
            return SetDataInfoVal(valName, valName, CurrentRecipeName);
        }

        /// <summary>给全局变量赋值_当前集合中无该变量则新增加_外部调用</summary>
        /// <typeparam name="T">支持bool/int/double/string</typeparam>
        /// <param name="valName">变量名</param>
        /// <param name="value">变量值</param>
        /// <returns>0-成功</returns>
        public int SetDataInfoVal<T>(string valName, T value)
        {
            return SetDataInfoVal(valName, value, CurrentRecipeName);
        }

        /// <summary>
        /// 初始化全局变量
        /// </summary>
        internal void DataInfosInit()
        {
            if (DataInfos == null ||
                DataInfos.IsEmpty)
            {
                return;
            }

            foreach (var dataInfo in DataInfos)
            {
                foreach (var dt in dataInfo.Value)
                {
                    dt.Value.OnChanged -= DataInfoChanged;
                    dt.Value.OnChanged += DataInfoChanged;

                    if (dt.Value == null)
                    {
                        continue;
                    }

                    if (dt.Value.Save)
                    {
                        DataInfo dataInfoTmp = null;
                        int ret = MongodbHelper.QueryOneFirst("Name", dt.Value.Name, out dataInfoTmp, UIGlobal.GlobalVariableDb, null);
                        if (ret == 0 && dataInfoTmp != null)
                        {
                            dt.Value.Value = dataInfoTmp.Value;
                        }
                        else
                        {
                            dt.Value.Value = GetDataTypeDefault(dt.Value.Type, dt.Value);
                        }
                    }
                    else
                    {
                        dt.Value.Value = GetDataTypeDefault(dt.Value.Type, dt.Value);
                    }
                    dt.Value.Update = true;
                }
            }
        }

        /// <summary>从当前配方获取全局变量</summary>
        /// <param name="name">变量名</param>
        /// <returns>变量</returns>
        internal DataInfo GetDataInfoByName(string name)
        {
            return GetDataInfoByName(name, CurrentRecipeName);
        }

        /// <summary>从指定配方获取全局变量</summary>
        /// <param name="globalVariableName">全局变量名称</param>
        /// <param name="recipeName">配方名称</param>
        /// <returns>变量</returns>
        internal DataInfo GetDataInfoByName(string globalVariableName, string recipeName)
        {
            if (recipeName.IsNullOrEmpty())
            {
                return null;
            }

            if (DataInfos == null ||
                DataInfos.IsEmpty)
            {
                return null;
            }

            DataInfo dt = null;
            if (DataInfos.ContainsKey(recipeName) &&
                !DataInfos[recipeName].IsEmpty &&
                DataInfos[recipeName].ContainsKey(globalVariableName))
            {
                dt = DataInfos[recipeName][globalVariableName];
            }
            return dt;
        }

        /// <summary>从当前配方移除全局变量</summary>
        /// <param name="name">变量名</param>
        /// <returns>0-成功</returns>
        internal int RemoveDataInfoByName(string name)
        {
            int iRet = 0;
            if (CurrentDataInfos.ContainsKey(name))
            {
                iRet = CurrentDataInfos.TryRemove(name, out var _) ? 0 : -1;
            }
            return iRet;
        }
        /// <summary>
        /// 全局变量赋值
        /// </summary>
        /// <param name="globalVariableName">全局变量名称</param>
        /// <param name="value">值</param>
        /// <param name="recipeName">配方名称</param>
        /// <returns>0-成功</returns>
        internal int SetDataInfoVal(string globalVariableName, object value, string recipeName)
        {
            try
            {
                if (value == null)
                {
                    throw new ArgumentException("Parameter is empty", "value");
                }

                DataInfo dataInfo = GetDataInfoByName(globalVariableName, recipeName);
                if (dataInfo == null)
                {
                    dataInfo = new DataInfo
                    {
                        Name = globalVariableName,
                        Update = true
                    };

                    if (value.GetType().Name.Equals("Boolean"))
                    {
                        dataInfo.Type = DataType.BOOL;
                    }
                    else if (value.GetType().Name.Equals("Int32"))
                    {
                        dataInfo.Type = DataType.INT;
                    }
                    else if (value.GetType().Name.Equals("Double"))
                    {
                        dataInfo.Type = DataType.DOUBLE;
                    }
                    else if (value.GetType().Name.Equals("String"))
                    {
                        dataInfo.Type = DataType.STRING;
                    }
                    //else if (value.GetType().Name.Equals("GlobalVariableClass"))
                    //{
                    //    dataInfo.Type = DataType.CLASS;
                    //}
                    else
                    {
                        throw new ArgumentNullException("Parameter type invalid", "value");
                    }

                    dataInfo.Value = value;

                    CurrentDataInfos.TryAdd(dataInfo.Name, dataInfo);
                    ((SingleStationConfigControl)ConfigUi).TryAddDataInfo(CurrentRecipeName, dataInfo);

                    new Action(() =>
                    {
                        lock (_objLockSaveDt)
                        {
                            _manager.ExportStationsConfigToPath(_manager.ConfigFilePath);
                            _ = MongodbHelper.ReplaceOneAsync("Name", globalVariableName, dataInfo, UIGlobal.GlobalVariableDb, true);
                        }
                    }).BeginInvoke(null, null);
                }
                else
                {
                    switch (dataInfo.Type)
                    {
                        case DataType.BOOL:
                            if (!value.ToString().IsBoolean())
                            {
                                throw new ArgumentNullException("Parameter type invalid", "value");
                            }
                            break;

                        case DataType.DOUBLE:
                            if (!value.ToString().IsDouble())
                            {
                                throw new ArgumentNullException("Parameter type invalid", "value");
                            }
                            break;

                        case DataType.CLASS:
                            //if (!(value is GlobalVariableClass))
                            //{
                            //    throw new ArgumentNullException("Parameter type invalid", "value");
                            //}
                            break;

                        case DataType.INT:
                            if (!value.ToString().IsInt())
                            {
                                throw new ArgumentNullException("Parameter type invalid", "value");
                            }
                            break;

                        case DataType.STRING:
                        case DataType.Other:
                        default:
                            break;
                    }
                    dataInfo.Value = value;
                    dataInfo.Update = true;
                    if (dataInfo.Save)
                    {
                        new Action(() =>
                        {
                            lock (_objLockSaveDt)
                            {
                                _ = MongodbHelper.ReplaceOneAsync("Name", globalVariableName, dataInfo, UIGlobal.GlobalVariableDb, true);
                            }
                        }).BeginInvoke(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                _manager.LogAdd("SetDataInfoVal error：" + ex.Message, LogLevel.Warn);
                return -1;
            }

            return 0;
        }
        #endregion



        #region 实时变量相关
        /// <summary>实时变量获取</summary>
        /// <param name="varName">变量名</param>
        public object GetRtVar(string varName)
        {
            if (CurrentRtDataVars != null && CurrentRtDataVars.DataVars != null && CurrentRtDataVars.DataVars.Count > 0 && CurrentRtDataVars.DataVars.ContainsKey(varName))
            {
                return CurrentRtDataVars.DataVars[varName].Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>实时变量更新</summary>
        /// <param name="varName">变量名</param>
        /// <param name="val">变量值</param>
        public void UpdateRtVar(string varName, object val)
        {
            if (CurrentRtDataVars != null && CurrentRtDataVars.DataVars != null && CurrentRtDataVars.DataVars.Count > 0 && CurrentRtDataVars.DataVars.ContainsKey(varName))
            {
                ((VarControl)CurrentRtDataVars.DataVars[varName].ShowControl).SetVarValue(val);
                if (CurrentRtDataVars.DataVars[varName].Save)
                {
                    CurrentRtDataVars.DataVars[varName].Value = val.ToString();
                    _ = MongodbHelper.UpdateOneAsync<RtDataVar>("Name", varName, "Value", val.ToString(), RtDataVarsCollection, null, false, null);
                }
            }
        }

        /// <summary>初始化实时显示变量</summary>
        internal void RtDataVarsInit()
        {
            RtDataVar rt = new RtDataVar();
            foreach (KeyValuePair<string, RtDataVars> rtDataVarse in RtDataVarses)
            {
                foreach (KeyValuePair<string, RtDataVar> rtVar in rtDataVarse.Value.DataVars)
                {
                    ((VarControl)rtVar.Value.ShowControl).SetVarName(rtVar.Key);
                    if (!rtVar.Value.Save)
                    {
                        continue;
                    }

                    if (MongodbHelper.QueryOneLast<RtDataVar>("Name", rtVar.Value.Name, out rt, RtDataVarsCollection, "Name") != 0)
                    {
                        continue;
                    }

                    if (rt == null)
                    {
                        RtDataVar rtDataVar = new RtDataVar()
                        {
                            Name = rtVar.Value.Name,
                            Type = rtVar.Value.Type,
                            Save = rtVar.Value.Save,
                            Value = "0",
                        };
                        _ = MongodbHelper.InsertOneAsync(rtDataVar, RtDataVarsCollection, null);
                        ((VarControl)rtVar.Value.ShowControl).SetVarValue(rtDataVar.Value);
                        continue;
                    }

                    ((VarControl)rtVar.Value.ShowControl).SetVarValue(rt.Value);
                    rtVar.Value.Value = rt.Value;
                }
            }
        }
        #endregion



        #region 主界面按钮
        /// <summary>注销主界面按钮按下事件的已订阅者</summary>
        public void ClearEventOnButtonPressed()
        {
            if (OnButtonPressed != null)
            {
                foreach (Delegate d in OnButtonPressed.GetInvocationList())
                {
                    OnButtonPressed -= d as ButtonPressEventHandle;
                }
            }
        }
        /// <summary>工站主界面按钮按下</summary>
        /// <param name="btnText">按钮信息</param>
        public void PressButton(string btnText)
        {
            OnButtonPressed?.Invoke(btnText);
        }
        /// <summary>更新主界面三个按钮</summary>
        public void UpdateMainBtn()
        {
            this.OnUpdateMainBtn?.Invoke();
        }
        #endregion



        #region Other
        /// <summary>添加某安全监控信号</summary>
        /// <param name="ele">元件（数字量输入IEleDI）</param>
        public void AddAbnormalDi(IEle ele)
        {
            OnAddAbnormalDi?.Invoke(ele);
        }

        public void ChangeCurrentDisplayConfig(string displayConfigName)
        {
        }

        /// <summary>更改某元件成员的类型</summary>
        /// <param name="ele">元件</param>
        /// <param name="oldType">旧类型</param>
        /// <param name="newType">新类型</param>
        public void ChangeEleItemType(IEle ele, EleMemberType oldType = EleMemberType.Other, EleMemberType newType = EleMemberType.Other)
        {
            OnChangeEleItemType?.Invoke(ele, oldType, newType);
        }

        /// <summary>移除某安全监控信号</summary>
        /// <param name="ele">元件（数字量输入IEleDI）</param>
        public void RemoveAbnormalDi(IEle ele)
        {
            OnRemoveAbnormalDi?.Invoke(ele);
        }

        /// <summary>切换主界面上的TAB页</summary>
        /// <param name="index">The index.</param>
        public void SwitchStateTab(int index)
        {
            this.OnChangeStateTab?.Invoke(Name, index);
        }

        /// <summary>返回工站名称</summary>
        /// <returns>工站名称</returns>
        public override string ToString()
        {
            return Name;
        }
        private void DataInfoChanged(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
