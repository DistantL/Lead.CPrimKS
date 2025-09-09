using Lead.CPrim.EleCommon.Forms;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Global
{
    /// <summary>元件管理器配置</summary>
    public class ElesConfigSave
    {
        /// <summary>元件管理器配置路径</summary>
        public string ElesConfigPath { get; set; }
        /// <summary>元件管理器配置数据</summary>
        public List<XmlNode> ListEleInfo { get; set; }
    }



    /// <summary>元件管理器</summary>
    public class ElesManager
    {
        #region Field
        /// <summary>元件管理器对象</summary>
        private static readonly ElesManager _instance = new ElesManager();

        /// <summary>ConfigUI</summary>
        private EleConfigForm _elesConfigForm = null;

        /// <summary>DebugUI</summary>
        private EleDebugForm _elesDebugForm = null;

        /// <summary>UserUI</summary>
        private ElementsUserView _eleUserViewForm;

        /// <summary>元件管理器配置路径</summary>
        private string _elesConfigPath = "";

        /// <summary>元件集合</summary>
        private List<IEle> _listEle = new List<IEle>();

        /// <summary>元件DLL地址</summary>
        private string _elesAsmPath;

        /// <summary>元件属性公共接口支持类型【元件名称（AD、DI），IEleTypeAttributes对象】</summary>
        private Dictionary<string, IEleTypeAttributes> _supportedEleTypes = new Dictionary<string, IEleTypeAttributes>();

        /// <summary>元件地址集合【元件名称（AD、DI），dll全路径】</summary>
        internal Dictionary<string, string> DicEles = new Dictionary<string, string>();

        /// <summary>元件创建集合【dll全路径，IEleCreator对象】</summary>
        private Dictionary<string, IEleCreator> _listEleCreator = new Dictionary<string, IEleCreator>();

        /// <summary>元件DLL重复防呆</summary>
        private List<string> _elesFileNameList = new List<string>();

        /// <summary>类名，用于记录错误</summary>
        private string _logHead = "ElesFactory:";

        /// <summary>元件创建公共接口</summary>
        private string _eleClassName = "Lead.CPrim.Interfaces.IEleCreator";
        #endregion



        #region Prop
        /// <summary>元件管理器对象</summary>
        public static ElesManager Instance => _instance;

        /// <summary>ConfigUI</summary>
        public EleConfigForm ElesConfigForm => _elesConfigForm;

        /// <summary>DebugUI</summary>
        public EleDebugForm ElesDebugForm => _elesDebugForm;

        /// <summary>UserUI</summary>
        public ElementsUserView EleUserViewForm => _eleUserViewForm;

        /// <summary>元件管理器配置路径</summary>
        public string ElesCofigPath { get { return _elesConfigPath; } set { _elesConfigPath = value; } }

        /// <summary>元件集合</summary>
        public List<IEle> ListEle => _listEle;

        /// <summary>元件属性公共接口支持类型【元件名称（AD、DI），IEleTypeAttributes对象】</summary>
        internal Dictionary<string, IEleTypeAttributes> SupportedEleTypes => _supportedEleTypes;
        #endregion



        #region Ctor
        public ElesManager()
        {
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
        }
        #endregion



        #region Method_Instance
        /// <summary>响应权限等级改变</summary>
        /// <param name="level"></param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            bool enable = AuthorityManager.Instance.VerifyLevel2Permission();
            SetEnableDebug(enable);
            enable = AuthorityManager.Instance.VerifyLevel3Permission();
            SetEnable(enable);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>通过GUID获取元件</summary>
        public IEle GetEleByGUID(Guid id)
        {
            if (id == null) return null;

            if (ListEle == null || ListEle.Count < 1) return null;

            return ListEle.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>通过名字获取元件</summary>
        public IEle GetEleByName(string eleName)
        {
            if (string.IsNullOrEmpty(eleName)) return null;

            if (ListEle == null || ListEle.Count < 1) return null;

            return ListEle.FirstOrDefault(p => p.Name == eleName);
        }

        /// <summary>通过GUID移除元件</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveEleByGUID(Guid id)
        {
            int count = ListEle.Count;
            int result;
            if (count < 0)
            {
                result = 0;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (ListEle[i].Id == id)
                    {
                        ListEle.RemoveAt(i);
                        return 0;
                    }
                }
                result = 0;
            }
            return result;
        }

        /// <summary>通过GUID设置元件名称</summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SetEleNameByGUID(Guid id, string name)
        {
            int result = 0;
            int count = ListEle.Count;
            if (count < 0)
            {
                return -1;
            }
            for (int i = 0; i < count; i++)
            {
                if (ListEle[i].Id == id)
                {
                    ListEle[i].Name = name;
                }
            }
            return result;
        }

        /// <summary>元件使能_元件配置存在运行（正常模式）</summary>
        /// <param name="elesConfigPath">元件配置目录</param>
        /// <param name="elesAsmPath">元件dll目录</param>
        /// <returns>int</returns>
        public int ElesManagerInit(string elesConfigPath, string elesAsmPath)
        {
            int num = 0;
            num = ElesManager.Instance.LoadPrimTypeAttributes(elesAsmPath);
            if (num != 0)
                return num;

            _elesConfigPath = elesConfigPath;
            if (!File.Exists(_elesConfigPath))
            {
                File.Create(_elesConfigPath);
            }
            else
            {
                try
                {
                    ElesConfigSave elesConfigSave = (ElesConfigSave)ProxyTools.XmlSerializerHelper.ReadXML(_elesConfigPath, typeof(ElesConfigSave));
                    if (elesConfigSave != null)
                    {
                        foreach (XmlNode item in elesConfigSave.ListEleInfo)
                        {
                            IEle val = CreateEle(item);
                            if (val != null && !_listEle.Contains(val)) _listEle.Add(val);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ProxyTools.NLocalizer.GetString("EleCommon_ElesManager_LoadElesConfigSaveError", "Err: LoadElesConfigSave!") + " => " + ex.Message);
                    return -3;
                }
            }
            ElesConfigFormInit();
            return num;
        }

        /// <summary>【元件未使能】||【元件配置不存在】运行（异常模式）</summary>
        public int ElesConfigFormInit()
        {
            int result = 0;
            if (_elesConfigForm == null)
            {
                _elesConfigForm = new EleConfigForm();
                _elesConfigForm.EleToolBarFormLoad();
            }
            if (_elesDebugForm == null)
            {
                _elesDebugForm = new EleDebugForm();
            }
            if (_eleUserViewForm == null)
            {
                _eleUserViewForm = new ElementsUserView();
            }
            return result;
        }

        /// <summary>保存</summary>
        /// <returns></returns>
        public int Save()
        {
            if(!AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
                return -1;
            }
            _elesConfigForm.SaveEleConfigsToFile();
            return 0;
        }

        public int DataInfoManagerExport()
        {
            int result = 0;
            ElesConfigSave elesConfigSave = new ElesConfigSave();
            elesConfigSave.ListEleInfo = new List<XmlNode>();
            elesConfigSave.ListEleInfo.Clear();
            elesConfigSave.ElesConfigPath = _elesConfigPath;
            foreach (IEle item2 in ListEle)
            {
                XmlNode item = item2.IEleExportConfigXml();
                elesConfigSave.ListEleInfo.Add(item);
            }
            XmlSerializerHelper.WriteXML(elesConfigSave, _elesConfigPath, typeof(ElesConfigSave));
            return result;
        }

        public int IoInfosExport()
        {
            foreach (IEle ele in ListEle)
            {
                if (ele.EleTypeName == "DI")
                {
                    IEleDI eleDi = (IEleDI)ele;
                    IIoModule val = (IIoModule)PrimsManager.Instance.GetPrimByName(ele.DevName);
                    if (val == null || val.Equals(null) || val.IoInfos == null || !eleDi.DiEnable)
                    {
                        continue;
                    }
                    IOInfo val2 = val.IoInfos.Di.FirstOrDefault((IOInfo p) => p.Address == eleDi.DiAddress);
                    if (val2?.Equals(null) ?? true)
                    {
                        continue;
                    }
                    val2.EnFallEvent = ((IEleDI)ele).EnFallEvent;
                    val2.EnRiseEvent = ((IEleDI)ele).EnRiseEvent;
                    val2.Info = ele.Name;
                    for (int i = 0; i < val.IoInfos.Di.Count; i++)
                    {
                        if (val2.Address == val.IoInfos.Di[i].Address)
                        {
                            val.IoInfos.Di[i] = val2;
                            break;
                        }
                    }
                    val.ExportIoInfos();
                }
                else if (ele.EleTypeName == "DO")
                {
                    IEleDO eleDo = (IEleDO)ele;
                    IIoModule val3 = (IIoModule)PrimsManager.Instance.GetPrimByName(ele.DevName);
                    if (val3 == null || val3.Equals(null) || val3.IoInfos == null || !eleDo.DoEnable)
                    {
                        continue;
                    }
                    IOInfo val4 = val3.IoInfos.Do.FirstOrDefault((IOInfo p) => p.Address == eleDo.DoAddress);
                    if (val4?.Equals(null) ?? true)
                    {
                        continue;
                    }
                    val4.Info = ele.Name;
                    for (int j = 0; j < val3.IoInfos.Do.Count; j++)
                    {
                        if (val4.Address == val3.IoInfos.Do[j].Address)
                        {
                            val3.IoInfos.Do[j] = val4;
                            break;
                        }
                    }
                    val3.ExportIoInfos();
                }
                else if (ele.EleTypeName == "CylinderLine")
                {
                    IEleCyldLine eleCylinderLine = (IEleCyldLine)ele;
                    IIoModule val5 = (IIoModule)PrimsManager.Instance.GetPrimByName(ele.DevName);
                    if (val5 == null || val5.Equals(null) || val5.IoInfos == null)
                    {
                        continue;
                    }
                    IOInfo val6 = new IOInfo();
                    IOInfo val7 = new IOInfo();
                    IOInfo val8 = new IOInfo();
                    IOInfo val9 = new IOInfo();
                    if ((int)eleCylinderLine.CyldType == 1)
                    {
                        if (eleCylinderLine.StretchDoEnable)
                        {
                            val6 = val5.IoInfos.Do.FirstOrDefault((IOInfo p) => p.Address == eleCylinderLine.StretchDoAddress);
                            if (val6 != null && !val6.Equals(null))
                            {
                                val6.Info = ele.Name + "_伸";
                            }
                        }
                        if (eleCylinderLine.RestractDoEnable)
                        {
                            val7 = val5.IoInfos.Do.FirstOrDefault((IOInfo p) => p.Address == eleCylinderLine.RestractDoAddress);
                            if (val7 != null && !val7.Equals(null))
                            {
                                val7.Info = ele.Name + "_缩";
                            }
                        }
                        if (eleCylinderLine.StretchDiEnable)
                        {
                            val8 = val5.IoInfos.Di.FirstOrDefault((IOInfo p) => p.Address == eleCylinderLine.StretchDiAddress);
                            if (val8 != null && !val8.Equals(null))
                            {
                                val8.Info = ele.Name + "_伸位";
                            }
                        }
                        if (eleCylinderLine.RestractDiEnable)
                        {
                            val9 = val5.IoInfos.Di.FirstOrDefault((IOInfo p) => p.Address == eleCylinderLine.RestractDiAddress);
                            if (val9 != null && !val9.Equals(null))
                            {
                                val9.Info = ele.Name + "_缩位";
                            }
                        }
                    }
                    else if ((int)eleCylinderLine.CyldType == 2)
                    {
                        if (eleCylinderLine.StretchDoEnable)
                        {
                            val6 = val5.IoInfos.Do.FirstOrDefault((IOInfo p) => p.Address == eleCylinderLine.StretchDoAddress);
                            if (val6 != null && !val6.Equals(null))
                            {
                                val6.Info = ele.Name + "_吸";
                            }
                        }
                        if (eleCylinderLine.RestractDoEnable)
                        {
                            val7 = val5.IoInfos.Do.FirstOrDefault((IOInfo p) => p.Address == eleCylinderLine.RestractDoAddress);
                            if (val7?.Equals(null) ?? false)
                            {
                                val7.Info = ele.Name + "_破";
                            }
                        }
                        if (eleCylinderLine.StretchDiEnable)
                        {
                            val8 = val5.IoInfos.Di.FirstOrDefault((IOInfo p) => p.Address == eleCylinderLine.StretchDiAddress);
                            if (val8 != null && !val8.Equals(null))
                            {
                                val8.Info = ele.Name + "_吸检";
                            }
                        }
                        if (eleCylinderLine.RestractDiEnable)
                        {
                            val9 = val5.IoInfos.Di.FirstOrDefault((IOInfo p) => p.Address == eleCylinderLine.RestractDiAddress);
                            if (val9 != null && !val9.Equals(null))
                            {
                                val9.Info = ele.Name + "_破检";
                            }
                        }
                    }
                    for (int k = 0; k < val5.IoInfos.Do.Count; k++)
                    {
                        if (val6 != null && val6.Address == val5.IoInfos.Do[k].Address)
                        {
                            val5.IoInfos.Do[k] = val6;
                        }
                        if (val7 != null && val7.Address == val5.IoInfos.Do[k].Address)
                        {
                            val5.IoInfos.Do[k] = val7;
                        }
                    }
                    for (int l = 0; l < val5.IoInfos.Di.Count; l++)
                    {
                        if (val8 != null && val8.Address == val5.IoInfos.Di[l].Address)
                        {
                            val5.IoInfos.Di[l] = val8;
                        }
                        if (val9 != null && val9.Address == val5.IoInfos.Di[l].Address)
                        {
                            val5.IoInfos.Di[l] = val9;
                        }
                    }
                    val5.ExportIoInfos();
                }
                else
                {
                    if (!(ele.EleTypeName == "Light"))
                    {
                        continue;
                    }
                    IEleLight eleLight = (IEleLight)ele;
                    IIoModule val10 = (IIoModule)PrimsManager.Instance.GetPrimByName(ele.DevName);
                    if (val10 == null || val10.Equals(null) || val10.IoInfos == null)
                    {
                        continue;
                    }
                    IOInfo val11 = new IOInfo();
                    IOInfo val12 = new IOInfo();
                    IOInfo val13 = new IOInfo();
                    IOInfo val14 = new IOInfo();
                    if (eleLight.GreenEnable)
                    {
                        val11 = val10.IoInfos.Di.FirstOrDefault((IOInfo p) => p.Address == eleLight.GreenAddress);
                        if (val11 != null && !val11.Equals(null))
                        {
                            val11.Info = ele.Name + "_绿灯";
                        }
                    }
                    if (eleLight.YellowEnable)
                    {
                        val12 = val10.IoInfos.Di.FirstOrDefault((IOInfo p) => p.Address == eleLight.YellowAddress);
                        if (val12 != null && !val12.Equals((object)null))
                        {
                            val12.Info = ele.Name + "_黄灯";
                        }
                    }
                    if (eleLight.RedEnable)
                    {
                        val13 = val10.IoInfos.Di.FirstOrDefault((IOInfo p) => p.Address == eleLight.RedAddress);
                        if (val13 != null && !((object)val13).Equals((object)null))
                        {
                            val13.Info = ele.Name + "_红灯";
                        }
                    }
                    if (eleLight.BuzzEnable)
                    {
                        val14 = val10.IoInfos.Do.FirstOrDefault((IOInfo p) => p.Address == eleLight.BuzzAddress);
                        if (val14 != null && !((object)val14).Equals((object)null))
                        {
                            val14.Info = ele.Name + "_蜂鸣器";
                        }
                    }
                    for (int m = 0; m < val10.IoInfos.Do.Count; m++)
                    {
                        if (val11 != null && val11.Address == val10.IoInfos.Do[m].Address)
                        {
                            val10.IoInfos.Do[m] = val11;
                        }
                        else if (val12 != null && val12.Address == val10.IoInfos.Do[m].Address)
                        {
                            val10.IoInfos.Do[m] = val12;
                        }
                        else if (val13 != null && val13.Address == val10.IoInfos.Do[m].Address)
                        {
                            val10.IoInfos.Do[m] = val13;
                        }
                        else if (val14 != null && val14.Address == val10.IoInfos.Do[m].Address)
                        {
                            val10.IoInfos.Do[m] = val14;
                        }
                    }
                    val10.ExportIoInfos();
                }
            }
            return 0;
        }

        /// <summary>手自动设置</summary>
        /// <param name="enable">true：手动；false：自动</param>
        public void EnableHandle(bool enable)
        {
            _eleUserViewForm?.EnableHandle(enable);
            _elesConfigForm?.EnableHandle(enable);
            foreach (IEle item in _listEle)
            {
                if (item != null)
                {
                    item.ManualEnable = enable;
                }
            }
        }

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"ElesManager -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.EleCommon}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.EleCommon.ToString(), LogClassification.Elements, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }

        /// <summary>通过DLL反射加载元件属性公共接口</summary>
        /// <param name="eleFolderPath">元件dll目录</param>
        /// <returns>int</returns>
        public int LoadPrimTypeAttributes(string eleFolderPath)
        {
            if (string.IsNullOrEmpty(eleFolderPath))
                throw new Exception(_logHead + ProxyTools.NLocalizer.GetString("EleCommon_ElesFactory_PathIsNull", "Path is null"));

            _elesAsmPath = eleFolderPath;
            DirectoryInfo directoryInfo = new DirectoryInfo(eleFolderPath);
            if (directoryInfo == null)
                return -1;

            FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos("*.dll");
            for (int i = 0; i < fileSystemInfos.Length; i++)
            {
                FileInfo fileInfo = fileSystemInfos[i] as FileInfo;
                if (fileInfo == null)
                    continue;
                string fullName = fileInfo.FullName;
                if (_elesFileNameList.Contains(fullName))
                    continue;

                _elesFileNameList.Add(fullName);

                IEleTypeAttributes eleTypeInstance = GetEleTypeInstance(fullName, _eleClassName);
                if (eleTypeInstance != null && !_supportedEleTypes.ContainsKey(eleTypeInstance.Name))
                {
                    _supportedEleTypes.Add(eleTypeInstance.Name, eleTypeInstance);

                    if (!DicEles.ContainsKey(eleTypeInstance.Name))
                        DicEles.Add(eleTypeInstance.Name, fullName);
                }
            }
            return 0;
        }

        /// <summary>
        /// 根据元件型号获取IEle
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public IEle GetEle(string typeName)
        {
            try
            {
                if (DicEles.ContainsKey(typeName))
                {
                    string key = DicEles[typeName];
                    if (_listEleCreator.ContainsKey(key))
                    {
                        IEleCreator val = _listEleCreator[key];
                        IEle val2 = val.Create();
                        val2.EleTypeName = val.ConcreteEleTypeAttributes.DisplayName;
                        return val2;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 元件调试刷新
        /// </summary>
        public void RefreshDgv()
        {
            EleUserViewForm.RefreshDgv();
        }

        /// <summary>
        /// 获取所有元件
        /// </summary>
        /// <returns></returns>
        public List<IEle> GetAllIEle()
        {
            return ListEle;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        private void SetEnable(bool enable)
        {
            ElesConfigForm?.SetEnable(enable);
        }

        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        private void SetEnableDebug(bool enable)
        {
            EleUserViewForm?.SetEnable(enable);
        }

        /// <summary>反射加载IEleTypeAttributes对象</summary>
        /// <param name="eleFileName">dll全目录</param>
        /// <param name="eleClassName">"Lead.CPrim.Interfaces.IEleCreator"</param>
        /// <returns>IEleTypeAttributes</returns>
        private IEleTypeAttributes GetEleTypeInstance(string eleFileName, string eleClassName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(eleFileName);
                //IEleCreator factoryClass = FactoryCreator<IEleCreator>.GetFactoryClass(fileInfo.FullName, eleClassName);
                IEleCreator factoryClass = ProxyTools.FactoryCreator.GetFactoryClass<IEleCreator>(fileInfo.FullName, eleClassName);
                if (factoryClass == null)
                    return null;

                if (!_listEleCreator.ContainsKey(eleFileName))
                    _listEleCreator.Add(eleFileName, factoryClass);

                return factoryClass.ConcreteEleTypeAttributes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(_logHead + ProxyTools.NLocalizer.GetString("EleCommon_ElesFactory_GetEleInstanceFail", "Get Ele Instance Fail -") + ex.ToString());
                return null;
            }
        }

        private IEle CreateEle(string eleName)
        {
            IEle result = null;
            try
            {
                string text = eleName.Replace("Ele", string.Empty).Replace("Config", string.Empty);
                string text2 = _elesAsmPath + "\\Lead.CPrim.Ele" + text + ".dll";
                if (File.Exists(text2))
                {
                    result = ProxyTools.FactoryCreator.GetFactoryClass<IEle>(text2, "Lead.CPrim.Interfaces.IEle");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(_logHead + ProxyTools.NLocalizer.GetString("EleCommon_ElesFactory_LoadFail", "Load fail - ") + ex.ToString());
            }
            return result;
        }

        private IEle CreateEle(XmlNode xmlNode)
        {
            IEle val = null;
            val = CreateEle(xmlNode.Name);
            if (val != null)
            {
                val.IEleImportConfigXml(xmlNode);
            }
            return val;
        }
        #endregion
    }
}
