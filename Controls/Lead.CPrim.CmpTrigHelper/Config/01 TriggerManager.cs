using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper;
using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;
using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.Global
{
    #region delegate_Define
    public delegate int UiSelected(object obj, ConfigType config);
    #endregion



    public class TriggerManager
    {
        #region Field
        private static readonly TriggerManager _instance = new TriggerManager();

        private Control _cmpTrigConfigUi;

        private StationTrigInfo _config;

        private string _currentProductName;

        private ConcurrentDictionary<string, ProductTrigInfo> _products;

        private string _trigInfoFilePath;
        #endregion



        #region Prop
        public static TriggerManager Instance => _instance;
        public Control CmpTrigConfigUi => _cmpTrigConfigUi;

        /// <summary>
        /// 当前产品名称
        /// </summary>
        public string CurrentProductName => _currentProductName;

        /// <summary>
        /// 当前产品配置
        /// </summary>
        public ProductTrigInfo CurrentProduct
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentProductName) && _products.ContainsKey(_currentProductName))
                {
                    return _products[_currentProductName];
                }
                return null;
            }
        }
        /// <summary>
        /// 所有产品配置文件
        /// </summary>
        public ConcurrentDictionary<string, ProductTrigInfo> Products => _products;
        #endregion






        #region Method_ExternalUsing
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public int Init(string configFilePath)
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    File.Create(configFilePath).Dispose();
                    return -5;
                }
                _trigInfoFilePath = configFilePath;
                StationTrigInfo stationTrigInfo = JsonHelper.DeserializeJsonFileToObject<StationTrigInfo>(configFilePath);
                if (stationTrigInfo != null)
                {
                    _products = stationTrigInfo.Products;
                    _currentProductName = stationTrigInfo.CurrentProductName;
                    return 0;
                }
                _products = new ConcurrentDictionary<string, ProductTrigInfo>();
                _currentProductName = "";
                return -1;
            }
            catch (Exception)
            {
                _products = new ConcurrentDictionary<string, ProductTrigInfo>();
                _currentProductName = "";
                return -10;
            }
            finally
            {
                _cmpTrigConfigUi = new TriggerMain(_instance);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            int result = ExportTrigInfoToPath(_trigInfoFilePath);
            if (result == 0)
            {
                UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_Global_CmpTrigManager_TrigInfoSaveSuccess", "比较触发设置保存成功"));
            }
            return result;
        }

        /// <summary>
        /// 切换产品名称
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public int ChangeCurrentProduct(string productName)
        {
            if (string.IsNullOrEmpty(productName) || !_products.ContainsKey(productName))
            {
                _currentProductName = "";
                ((TriggerMain)_cmpTrigConfigUi).LoadControls(this);
                return -1;
            }

            _currentProductName = productName;
            ((TriggerMain)_cmpTrigConfigUi).LoadControls(this);
            return 0;
        }

        /// <summary>
        /// 触发端口测试
        /// </summary>
        /// <param name="trigName">触发端口名称</param>
        /// <param name="cmpCount">实际触发数量</param>
        /// <param name="productName">当前产品</param>
        /// <param name="timeoutS">超时时间</param>
        /// <param name="asyncMode">true：异步；false：同步；</param>
        /// <param name="task">任务</param>
        /// <param name="otherTriggers"></param>
        /// <returns></returns>
        public int CmpTrigRun(
            string trigName,
            out int cmpCount,
            string productName = null,
            int timeoutS = -1,
            bool asyncMode = false,
            ITask task = null,
            string[] otherTriggers = null)
        {
            if (productName == null)
            {
                productName = CurrentProductName;
            }

            cmpCount = -1;
            if (!Products.ContainsKey(productName))
            {
                throw new Exception(NLocalizer.TriggerNotContainsCurrentProduct);
            }

            if (Products[productName].TriggerDatas.Count == 0)
            {
                throw new Exception(NLocalizer.TriggerPortIsEmpty);
            }

            KeyValuePair<Guid, TriggerPortData> keyValuePair = Products[productName].TriggerDatas.FirstOrDefault(p => p.Value.Name == trigName);
            if (keyValuePair.Key == null || keyValuePair.Value == null)
            {
                throw new Exception(NLocalizer.TriggerPortNotExist);
            }

            if (keyValuePair.Value.Enable)
            {
                return keyValuePair.Value.Run(productName, ref cmpCount, timeoutS, asyncMode, task, otherTriggers);
            }
            else
            {
                throw new Exception(NLocalizer.TriggerPortNotEnabled);
            }
        }


        /// <summary>
        /// 增加产品
        /// </summary>
        /// <param name="newName"></param>
        /// <returns></returns>
        internal int AddNewProdcut(string newName)
        {
            if (_products.ContainsKey(newName))
            {
                Notification.ShowWarn(NLocalizer.ProductNameRepeat);
                return -1;
            }

            ProductTrigInfo value = new ProductTrigInfo(newName);
            if (_products.TryAdd(newName, value))
            {
                ChangeCurrentProduct(newName);
            }

            return 0;
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal int RemoveProdcut(string name)
        {
            if (_products.TryRemove(name, out var _))
            {
                return ChangeCurrentProduct(null);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 复制产品
        /// </summary>
        /// <param name="newName"></param>
        /// <returns></returns>
        internal int CopyProdcut(string newName)
        {
            if (_products.ContainsKey(newName))
            {
                MessageBox.Show("产品名称重复，请重新操作");
                return -1;
            }

            ProductTrigInfo productTrigInfo = new ProductTrigInfo(newName);
            productTrigInfo.InterpolationDatas.Clear();
            foreach (KeyValuePair<Guid, InterPolationCfg> interpolationData in CurrentProduct.InterpolationDatas)
            {
                InterPolationCfg interPolationCfg = new InterPolationCfg(interpolationData.Value.Name, interpolationData.Value.Id, interpolationData.Value.EleName, interpolationData.Value.SpeedRate, interpolationData.Value.TAccDec, _instance);
                foreach (InterPolationPos interPolationPose in interpolationData.Value.InterPolationPoses)
                {
                    interPolationCfg.InterPolationPoses.Add(interPolationPose);
                }
                productTrigInfo.InterpolationDatas.TryAdd(interPolationCfg.Gid, interPolationCfg);
            }

            productTrigInfo.LinearTrigDatas.Clear();
            foreach (KeyValuePair<Guid, LinearTrigData> linearTrigData2 in CurrentProduct.LinearTrigDatas)
            {
                LinearTrigData linearTrigData = new LinearTrigData(linearTrigData2.Value.Name, linearTrigData2.Value.Id, linearTrigData2.Value.Increment, linearTrigData2.Value.TrigCount, linearTrigData2.Value.StartPos, _instance);
                productTrigInfo.LinearTrigDatas.TryAdd(linearTrigData.Gid, linearTrigData);
            }

            //队列触发表
            productTrigInfo.TableTrigDatas.Clear();
            foreach (KeyValuePair<Guid, TriggerTableData> tableTrigData2 in CurrentProduct.TableTrigDatas)
            {
                TriggerTableData tableTrigData = new TriggerTableData(tableTrigData2.Value.Name, tableTrigData2.Value.Id, _instance);
                foreach (KeyValuePair<int, double> trigPoint in tableTrigData2.Value.TrigPoints)
                {
                    tableTrigData.TrigPoints.Add(trigPoint.Key, trigPoint.Value);
                }
                productTrigInfo.TableTrigDatas.TryAdd(tableTrigData.Gid, tableTrigData);
            }

            productTrigInfo.TrajDatas.Clear();
            foreach (KeyValuePair<Guid, TriggerTrackData> trajData2 in CurrentProduct.TrajDatas)
            {
                TriggerTrackData trajData = new TriggerTrackData(trajData2.Value.Name, trajData2.Value.Id, trajData2.Value.EleName, trajData2.Value.TrigAxisName, _instance);
                foreach (KeyValuePair<int, CmpPos> valuePose in trajData2.Value.Poses)
                {
                    if(trajData.Poses == null)
                    {
                        trajData.Poses = new ConcurrentDictionary<int, CmpPos>();
                    }
                    trajData.Poses.AddOrUpdate(valuePose.Key, valuePose.Value, (int i, CmpPos pos) => pos = valuePose.Value);
                }
                productTrigInfo.TrajDatas.TryAdd(trajData.Gid, trajData);
            }

            productTrigInfo.TrigTabMangerDatas.Clear();
            foreach (KeyValuePair<Guid, TrigTabMangerData> trigTabMangerData2 in CurrentProduct.TrigTabMangerDatas)
            {
                TrigTabMangerData trigTabMangerData = new TrigTabMangerData(trigTabMangerData2.Value.Name, trigTabMangerData2.Value.Id, _instance);
                foreach (KeyValuePair<int, TrigTabCfg> trigs in trigTabMangerData2.Value.TrigsList)
                {
                    trigTabMangerData.TrigsList.Add(trigs.Key, trigs.Value);
                }
                productTrigInfo.TrigTabMangerDatas.TryAdd(trigTabMangerData.Gid, trigTabMangerData);
            }

            productTrigInfo.TriggerDatas.Clear();
            foreach (KeyValuePair<Guid, TriggerPortData> triggerData2 in CurrentProduct.TriggerDatas)
            {
                TriggerPortData triggerData = new TriggerPortData(triggerData2.Value.Name, triggerData2.Value.Id, _instance);
                triggerData.AxisName = triggerData2.Value.AxisName;
                triggerData.CmpSource = triggerData2.Value.CmpSource;
                triggerData.EleName = triggerData2.Value.EleName;
                triggerData.Enable = triggerData2.Value.Enable;
                triggerData.InterpolationEnable = triggerData2.Value.InterpolationEnable;
                triggerData.LogicDir = triggerData2.Value.LogicDir;
                triggerData.MoveDir = triggerData2.Value.MoveDir;
                triggerData.PrimMoveName = triggerData2.Value.PrimMoveName;
                triggerData.PrimType = triggerData2.Value.PrimType;
                triggerData.PulseWidth = triggerData2.Value.PulseWidth;
                triggerData.TrajName = triggerData2.Value.TrajName;
                triggerData.TrigChannel = triggerData2.Value.TrigChannel;
                triggerData.TrigMode = triggerData2.Value.TrigMode;
                triggerData.TrigPulse = triggerData2.Value.TrigPulse;
                triggerData.TrigTableName = triggerData2.Value.TrigTableName;
                productTrigInfo.TriggerDatas.TryAdd(triggerData.Gid, triggerData);
            }

            productTrigInfo.ComplexInterPolationDatas.Clear();
            foreach (KeyValuePair<Guid, ComplexInterPolationCfg> complexInterPolationData in CurrentProduct.ComplexInterPolationDatas)
            {
                ComplexInterPolationCfg complexInterPolationCfg = new ComplexInterPolationCfg(complexInterPolationData.Value.Name, complexInterPolationData.Value.Id, _instance);
                complexInterPolationCfg.EleName = complexInterPolationData.Value.EleName;
                complexInterPolationCfg.Crd = complexInterPolationData.Value.Crd;
                complexInterPolationCfg.SpeedRate = complexInterPolationData.Value.SpeedRate;
                complexInterPolationCfg.TAccDec = complexInterPolationData.Value.TAccDec;
                complexInterPolationCfg.Actions = new List<ActionConfig>();
                if (complexInterPolationData.Value.Actions.Count > 0)
                {
                    foreach (ActionConfig action in complexInterPolationData.Value.Actions)
                    {
                        ActionConfig actionConfig = new ActionConfig(action.actionType, complexInterPolationCfg);
                        actionConfig.CartesianName = action.CartesianName;
                        actionConfig.DelayTime1S_1 = action.DelayTime1S_1;
                        actionConfig.DelayTime1S_2 = action.DelayTime1S_2;
                        actionConfig.Index = action.Index;
                        actionConfig.IoAdr = action.IoAdr;
                        actionConfig.On_Off = action.On_Off;
                        actionConfig.Vm = action.Vm;
                        if (action.Pos != null)
                        {
                            actionConfig.Pos = new double[action.Pos.Length];
                            for (int j = 0; j < action.Pos.Length; j++)
                            {
                                actionConfig.Pos[j] = action.Pos[j];
                            }
                        }
                        complexInterPolationCfg.Actions.Add(actionConfig);
                    }
                }
                productTrigInfo.ComplexInterPolationDatas.TryAdd(complexInterPolationCfg.Gid, complexInterPolationCfg);
            }

            if (_products.TryAdd(newName, productTrigInfo))
            {
                ChangeCurrentProduct(newName);
            }
            return 0;
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        internal void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            msg = $"CmpTrigHelper -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.CmpTrigHelper}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.CmpTrigHelper.ToString(), LogClassification.Module, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, NLocalizer.Warn, false, UIStyle.Orange, false, true);
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="saveFileFileName"></param>
        /// <returns></returns>
        public int ExportTrigInfoToPath(string saveFileFileName)
        {
            if (_config == null)
            {
                _config = new StationTrigInfo();
            }
            _config.CurrentProductName = _currentProductName;
            _products.Values.ToList().ForEach(delegate (ProductTrigInfo p)
            {
                p.TrigTabMangerDatas.Values.ToList().ForEach(delegate (TrigTabMangerData pp)
                {
                    pp.RefreshTabs(p);
                });
            });
            _config.Products = _products;
            if (!JsonHelper.SerializeObjectToFile((object)_config, saveFileFileName, (Encoding)null))
            {
                MessageBox.Show("触发配置文件保存不成功!");
                return -1;
            }
            return 0;
        }

        #endregion



        public int CmpTrigClearPoints(string trigName, string productName = null)
        {
            if (productName == null)
            {
                productName = CurrentProductName;
            }
            if (!Products.ContainsKey(productName))
            {
                return -1;
            }
            if (Products[productName].TriggerDatas.Count == 0)
            {
                return -2;
            }
            try
            {
                KeyValuePair<Guid, TriggerPortData> keyValuePair = Products[productName].TriggerDatas.First((KeyValuePair<Guid, TriggerPortData> p) => p.Value.Name == trigName);
                if (keyValuePair.Value.Enable)
                {
                    return keyValuePair.Value.ClearPoints();
                }
                return -20;
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                return -10;
            }
        }

        public int CmpTrigDisable(string trigName, string productName = null)
        {
            if (productName == null)
            {
                productName = CurrentProductName;
            }
            if (!Products.ContainsKey(productName))
            {
                return -1;
            }
            if (Products[productName].TriggerDatas.Count == 0)
            {
                return -2;
            }
            try
            {
                KeyValuePair<Guid, TriggerPortData> keyValuePair = Products[productName].TriggerDatas.First((KeyValuePair<Guid, TriggerPortData> p) => p.Value.Name == trigName);
                if (keyValuePair.Value.Enable)
                {
                    return keyValuePair.Value.Disable();
                }
                return -20;
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                return -10;
            }
        }

        public int CmpTrigGetCmpCount(string trigName, out int CmpCount, string productName = null)
        {
            if (productName == null)
            {
                productName = CurrentProductName;
            }
            if (!Products.ContainsKey(productName))
            {
                CmpCount = -1;
                return -1;
            }
            if (Products[productName].TriggerDatas.Count == 0)
            {
                CmpCount = -1;
                return -2;
            }
            try
            {
                KeyValuePair<Guid, TriggerPortData> keyValuePair = Products[productName].TriggerDatas.First((KeyValuePair<Guid, TriggerPortData> p) => p.Value.Name == trigName);
                if (keyValuePair.Value.Enable)
                {
                    CmpCount = -1;
                    return keyValuePair.Value.GetCmpCount(ref CmpCount);
                }
                CmpCount = -1;
                return -20;
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                CmpCount = -1;
                return -10;
            }
        }

        public int CmpTrigSet(string trigName, string productName = null, double[] offsetes = null)
        {
            if (productName == null)
            {
                productName = CurrentProductName;
            }
            if (!Products.ContainsKey(productName))
            {
                return -1;
            }
            if (Products[productName].TriggerDatas.Count == 0)
            {
                return -2;
            }
            try
            {
                KeyValuePair<Guid, TriggerPortData> keyValuePair = Products[productName].TriggerDatas.First((KeyValuePair<Guid, TriggerPortData> p) => p.Value.Name == trigName);
                if (keyValuePair.Value.Enable)
                {
                    return keyValuePair.Value.Set(productName, offsetes);
                }
                return -20;
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                return -10;
            }
        }

        public int ExportTrigInfoPathToFile(string configFilePath)
        {
            try
            {
                string text = configFilePath?.Substring(configFilePath.LastIndexOf("\\") + 1);
                string path = configFilePath?.Substring(0, configFilePath.LastIndexOf("\\"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(configFilePath))
                {
                    File.Delete(configFilePath);
                }
                using (FileStream fileStream = new FileStream(configFilePath, FileMode.Create))
                {
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.Write(_trigInfoFilePath);
                    streamWriter.Flush();
                    streamWriter.Close();
                    fileStream.Close();
                }
                return 0;
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                return -1;
            }
        }

        public ProductTrigInfo FindProductByNameOrCurrent(string productName)
        {
            return (!string.IsNullOrEmpty(productName) && _products.ContainsKey(productName)) ? _products[productName] : CurrentProduct;
        }

        public TriggerPortData FindTriggerDataByGuid(Guid gId, string productName = null)
        {
            return FindProductByNameOrCurrent(productName)?.TriggerDatas?.FirstOrDefault((KeyValuePair<Guid, TriggerPortData> p) => p.Key == gId).Value;
        }

        public TriggerPortData FindTriggerDataByGuid(int id, string productName = null)
        {
            return FindProductByNameOrCurrent(productName)?.TriggerDatas?.FirstOrDefault((KeyValuePair<Guid, TriggerPortData> p) => p.Value.Id == id).Value;
        }

        public TriggerPortData FindTriggerDataByName(string triggerDataName, string productName = null)
        {
            return FindProductByNameOrCurrent(productName)?.TriggerDatas?.FirstOrDefault((KeyValuePair<Guid, TriggerPortData> p) => p.Value.Name == triggerDataName).Value;
        }

        public List<double> GetTriggerPosList(string trigName, string productName = null)
        {
            List<double> list = new List<double>();
            if (productName == null)
            {
                productName = CurrentProductName;
            }
            if (!Products.ContainsKey(productName))
            {
                return null;
            }
            if (Products[productName].TriggerDatas.Count == 0)
            {
                return null;
            }
            try
            {
                KeyValuePair<Guid, TriggerPortData> trigger = Products[productName].TriggerDatas.First((KeyValuePair<Guid, TriggerPortData> p) => p.Value.Name == trigName);
                if (trigger.Value.TrigMode != 5)
                {
                    return trigger.Value.GetTriggerPos(productName);
                }
                KeyValuePair<Guid, TriggerTrackData> keyValuePair = Products[productName].TrajDatas.First((KeyValuePair<Guid, TriggerTrackData> p) => p.Value.Name == trigger.Value.TrajName);
                KeyValuePair<Guid, LinearTrigData> keyValuePair2 = Products[productName].LinearTrigDatas.First((KeyValuePair<Guid, LinearTrigData> p) => p.Value.Name == trigger.Value.TrigTableName);
                for (int i = 0; i < keyValuePair2.Value.TrigCount; i++)
                {
                    list.Add(keyValuePair2.Value.StartPos + (double)i * keyValuePair2.Value.Increment);
                }
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                return null;
            }
            return list;
        }

        public int MoveTrig(string trigName, string productName = null, int timeoutS = -1, bool asyncMode = false, ITask task = null, Pos[] offsetPos = null, string[] otherTriggers = null, bool continueEnable = true)
        {
            if (productName == null)
            {
                productName = CurrentProductName;
            }
            if (!Products.ContainsKey(productName))
            {
                return -1;
            }
            if (Products[productName].TriggerDatas.Count == 0)
            {
                return -2;
            }
            try
            {
                KeyValuePair<Guid, TriggerPortData> keyValuePair = Products[productName].TriggerDatas.First((KeyValuePair<Guid, TriggerPortData> p) => p.Value.Name == trigName);
                if (keyValuePair.Value.Enable)
                {
                    return keyValuePair.Value.MoveTraj(productName, timeoutS, asyncMode, task, otherTriggers, offsetPos, continueEnable);
                }
                return -20;
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
                return -10;
            }
        }

        public int ReLoad()
        {
            return Init(_trigInfoFilePath);
        }

        public override string ToString()
        {
            return CurrentProductName;
        }

        public int UpdateTriggerData(Guid gId, TriggerPortData newData, string productName = null)
        {
            TriggerPortData triggerData = FindTriggerDataByGuid(gId, productName);
            if (triggerData == null)
            {
                return -10;
            }
            if (string.IsNullOrEmpty(productName) || productName == CurrentProductName)
            {
                return (!_products[CurrentProductName].TriggerDatas.TryUpdate(triggerData.Gid, newData, triggerData)) ? (-5) : 0;
            }
            return (!_products[productName].TriggerDatas.TryUpdate(triggerData.Gid, newData, triggerData)) ? (-1) : 0;
        }
    }
}
