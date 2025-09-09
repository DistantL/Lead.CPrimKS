/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PrimsManager.cs
 * Author: Victor
 * Description: 基元管理类
 * CreateTime: 2020-01-01
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1017><Victor><20221023>
 * 1、增加文件说明
 * 2、增加日志
 * 
 * <3.3.23.0101><Victor><20230204>
 * 1、基元增加权限管理，保存，增加，删除属于三级权限，测试属于二级权限，一级权限无功能
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.PrimCommon;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Threading;

namespace Lead.CPrim.Global
{
    /// <summary>基元管理器</summary>
    public class PrimsManager
    {
        #region Field
        /// <summary>基元管理器实例</summary>
        private static readonly PrimsManager _instance = new PrimsManager();

        /// <summary>程序使用基元集合</summary>
        private List<IPrim> _listPrim = new List<IPrim>();

        /// <summary>基元配置UI</summary>
		private PrimConfigForm _primsConfigForm = null;

        /// <summary>基元其它UI未使用</summary>
		private PrimMngForm _primsMngForm = new PrimMngForm();

        /// <summary>基元配置路径</summary>
        private string _configPath;

        /// <summary>基元全路径集合[基元名称，dll全路径]</summary>
        private Dictionary<string, string> _dicPrim = new Dictionary<string, string>();

        /// <summary>基元创建公共接口集合[dll全路径，基元创建公共接口IPrimCreator]</summary>
        private Dictionary<string, IPrimCreator> _listPrimCreator = new Dictionary<string, IPrimCreator>();

        /// <summary>基元属性公共接口集合[基元名称，基元属性公共接口IPrimTypeAttributes]</summary>
        private Dictionary<string, IPrimTypeAttributes> _supportedDevTaskPrimTypes = new Dictionary<string, IPrimTypeAttributes>();

        /// <summary>基元创建公共接口</summary>
        private string _primClassName = "Lead.CPrim.Interfaces.IPrimCreator";

        /// <summary>基元重复防呆</summary>
        private List<string> _primFileNameList = new List<string>();
        #endregion



        #region Prop
        /// <summary>基元管理器实例</summary>
        public static PrimsManager Instance => _instance;

        /// <summary>程序使用基元集合</summary>
        public List<IPrim> ListPrim => _listPrim;

        /// <summary>基元配置UI</summary>
		public PrimConfigForm PrimsConfigForm => _primsConfigForm;

        /// <summary>基元其它UI未使用</summary>
		public PrimMngForm PrimsMngForm => _primsMngForm;

        /// <summary>基元配置路径</summary>
        public string ConfigPath { get => _configPath; set => _configPath = value; }

        /// <summary>基元属性公共接口集合[基元名称，基元属性公共接口IPrimTypeAttributes]</summary>
        public Dictionary<string, IPrimTypeAttributes> SupportedDevTaskPrimTypes => _supportedDevTaskPrimTypes;
        #endregion



        #region Ctor
        public PrimsManager()
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
            SetEnable(enable);
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>基元初始化（Welcome调用（不进行基元反射））</summary>
        /// <param name="primsAssemblyPath">基元DLL地址</param>
        /// <returns>int</returns>
        public int PrimsConfigFormInit(string primsAssemblyPath)
        {
            int iRet = 0;

            if (_primsConfigForm != null)
            {
                return iRet;
            }

            _primsConfigForm = new PrimConfigForm(primsAssemblyPath);

            _primsConfigForm.OnAddPrim -= OnAddPrimConfigForm;
            _primsConfigForm.OnAddPrim += OnAddPrimConfigForm;

            _primsConfigForm.OnChangePrimName -= OnChangePrimNameConfigForm;
            _primsConfigForm.OnChangePrimName += OnChangePrimNameConfigForm;

            _primsConfigForm.OnRemovePrim -= OnRemovePrimConfigForm;
            _primsConfigForm.OnRemovePrim += OnRemovePrimConfigForm;

            foreach (IPrim prim in Instance.ListPrim)
            {
                _primsConfigForm.CreatePrimDisplay(prim);
            }

            LogAdd("基元UI初始化成功", LogLevel.Trace);
            return iRet;
        }

        /// <summary>根据Id获取IPrim</summary>
        /// <param name="id">Id</param>
        /// <returns>IPrim</returns>
        public IPrim GetPrimByGUID(Guid id)
        {
            if (ListPrim.Count <= 0)
            {
                return null;
            }

            return ListPrim.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>根据名称获取IPrim</summary>
        /// <param name="primName">基元名称</param>
        /// <returns></returns>
        public IPrim GetPrimByName(string primName)
        {
            if (ListPrim.Count <= 0)
            {
                return null;
            }

            return ListPrim.FirstOrDefault(p => p.Name == primName);
        }

        /// <summary>新增IPrim</summary>
        /// <param name="prim">基元</param>
        /// <returns></returns>
        public int AddPrim(IPrim prim)
        {
            if (prim == null)
            {
                return -1;
            }

            ListPrim.Add(prim);

            return 0;
        }

        /// <summary>根据Id移除IPrim</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemovePrimByGUID(Guid id)
        {
            if (ListPrim.Count <= 0)
            {
                return 0;
            }

            IPrim prim = ListPrim.FirstOrDefault(p => p.Id == id);
            if (prim == null)
            {
                return 0;
            }

            ListPrim.Remove(prim);
            return 0;
        }

        /// <summary>根据Id设置基元名称</summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SetPrimNameByGUID(Guid id, string name)
        {
            if (ListPrim.Count <= 0)
            {
                return -1;
            }

            IPrim prim = ListPrim.FirstOrDefault(p => p.Id == id);
            if (prim == null)
            {
                return -1;
            }

            prim.Name = name;
            return 0;
        }

        /// <summary>基元保存</summary>
        /// <returns>int</returns>
        public int Save()
        {
            if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
                return -1;
            }
            return SaveConfigFile(ReturnPrimConfigs()) ? 0 : -1;
        }

        /// <summary>获取【程序已使用基元集合】之【基元配置集合】</summary>
        /// <returns></returns>
        public PrimConfigs ReturnPrimConfigs()
        {
            PrimConfigs primConfigs = new PrimConfigs();
            if (_listPrim.Count > 0)
            {
                primConfigs.PrimConfigList.Clear();
                foreach (IPrim prim in _listPrim)
                {
                    XmlNode xmlNode = prim.IPrimExportConfigXml();
                    primConfigs.PrimConfigList.Add(new SinglePrimConfig
                    {
                        VisioPrimType = prim.PrimTypeName,
                        PrimXmlNode = xmlNode
                    });
                }
            }
            return primConfigs;
        }

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"PrimCommon -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.PrimCommon}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimCommon.ToString(), LogClassification.Module, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }

        /// <summary>加载基元Dll</summary>
        /// <param name="primFolderPath">Dll地址</param>
        /// <returns>int</returns>
        public int LoadPrimTypeAttributes(string primFolderPath)
        {
            int ret = 0;

            try
            {
                if (string.IsNullOrEmpty(primFolderPath))
                {
                    throw new Exception("基元Dll路径为空");
                }

                DirectoryInfo dir = new DirectoryInfo(primFolderPath);
                if (dir == null)
                {
                    return -1;
                }

                FileSystemInfo[] files = dir.GetFileSystemInfos("*.dll");
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = files[i] as FileInfo;
                    if (file == null)
                    {
                        continue;
                    }

                    string primFileName = file.FullName;
                    if (_primFileNameList.Contains(primFileName))
                    {
                        continue;
                    }

                    _primFileNameList.Add(primFileName);

                    IPrimTypeAttributes primAttr = GetPrimTypeInstance(primFileName, _primClassName);
                    if (primAttr != null && !_supportedDevTaskPrimTypes.ContainsKey(primAttr.Name))
                    {
                        PrimsManager.Instance.LogAdd($"反射加载Dll：{primAttr.Name}成功", LogLevel.Trace);
                        _supportedDevTaskPrimTypes.Add(primAttr.Name, primAttr);
                        if (!_dicPrim.ContainsKey(primAttr.Name))
                        {
                            _dicPrim.Add(primAttr.Name, primFileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PrimsManager.Instance.LogAdd($"加载基元Dll失败：{ex.Message}", LogLevel.Warn);
            }
            return ret;
        }

        /// <summary>根据基元类型获取IPrimCreator</summary>
        /// <param name="devPrimTypeName">基元名称</param>
        /// <returns></returns>
        public IPrimCreator GetDevPrimCreator(string devPrimTypeName)
        {
            try
            {
                if (_dicPrim.ContainsKey(devPrimTypeName))
                {
                    string primFile = _dicPrim[devPrimTypeName];
                    if (_listPrimCreator.ContainsKey(primFile))
                    {
                        return _listPrimCreator[primFile];
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                PrimsManager.Instance.LogAdd($"获取IPrimCreator失败：{ex.Message}", LogLevel.Warn);
                return null;
            }
        }

        /// <summary>根据基元类型获取IPrim</summary>
        /// <param name="primTypeName">基元名称</param>
        /// <returns>IPrim</returns>
        public IPrim GetPrim(string primTypeName)
        {
            try
            {
                if (_dicPrim.ContainsKey(primTypeName))
                {
                    string primFile = _dicPrim[primTypeName];
                    if (_listPrimCreator.ContainsKey(primFile))
                    {
                        IPrimCreator primCreator = _listPrimCreator[primFile];
                        return primCreator.Create();
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                PrimsManager.Instance.LogAdd($"获取IPrim失败：{ex.Message}", LogLevel.Warn);
                return null;
            }
        }

        /// <summary>根据基元名称、配置文件获取IPrim</summary>
        /// <param name="primTypeName">基元名称</param>
        /// <param name="xmlNode">配置文件</param>
        /// <returns></returns>
        public IPrim GetPrim(string primTypeName, XmlNode xmlNode)
        {
            try
            {
                if (_dicPrim.ContainsKey(primTypeName))
                {
                    string primFile = _dicPrim[primTypeName];
                    if (_listPrimCreator.ContainsKey(primFile))
                    {
                        IPrimCreator primCreator = _listPrimCreator[primFile];
                        return primCreator.Create(xmlNode);
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                PrimsManager.Instance.LogAdd($"获取IPrim失败：{ex.Message}", LogLevel.Warn);
                return null;
            }
        }

        /// <summary>
        /// 获取所有基元
        /// </summary>
        /// <returns></returns>
        public List<IPrim> GetAllIPrim()
        {
            return ListPrim;
        }

        /// <summary>
        /// 基元运行
        /// </summary>
        /// <param name="name">基元名称</param>
        /// <param name="timeOut">超时时间（默认5000ms）</param>
        /// <returns></returns>
        public IPrim Run(string name, int timeOut = 5 * 1000)
        {
            IPrim prim = GetPrimByName(name);
            if (prim == null)
            {
                throw new Exception(NLocalizer.PrimNotExist + "：" + name);
            }

            prim.IPrimTaskInit();
            if (!SpinWait.SpinUntil(() => prim.PrimRunStat == PrimRunState.Running, timeOut))
            {
                throw new Exception(NLocalizer.PrimRunFail + "：" + name);
            }

            return prim;
        }
        #endregion



        #region Method_PrimMngForm
        /// <summary>新增基元时发生响应</summary>
        /// <param name="primGroup">分组</param>
        /// <param name="primType">基元显示名称</param>
        /// <param name="primName">基元名称</param>
        /// <param name="primID">Id</param>
        private void OnAddPrimConfigForm(string primGroup, string primType, string primName, Guid primID)
        {
            PrimsMngForm.PrimAdd(primGroup, primType, primName, primID);
        }

        /// <summary>改变基元名称时发生</summary>
        /// <param name="primID">Id</param>
        /// <param name="dstName">基元名称</param>
        private void OnChangePrimNameConfigForm(Guid primID, string dstName)
        {
            PrimsMngForm.PrimNameChange(primID, dstName);
        }

        /// <summary>移除基元时发生</summary>
        /// <param name="primID">Id</param>
        private void OnRemovePrimConfigForm(Guid primID)
        {
            PrimsMngForm.PrimRemove(primID);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        private void SetEnable(bool enable)
        {
            PrimsConfigForm?.SetEnable(enable);
        }

        /// <summary>基元保存</summary>
        /// <param name="primConfigs"></param>
        /// <returns>bool</returns>
        private bool SaveConfigFile(PrimConfigs primConfigs)
        {
            return XmlSerializerHelper.WriteXML(primConfigs, _configPath, typeof(PrimConfigs));
        }

        /// <summary>反射加载DLL</summary>
        /// <param name="primFileName">dll全路径</param>
        /// <param name="primClassName">IPrimCreator接口</param>
        /// <returns></returns>
        private IPrimTypeAttributes GetPrimTypeInstance(string primFileName, string primClassName)
        {
            FileInfo f = new FileInfo(primFileName);
            IPrimCreator primCreator = ProxyTools.FactoryCreator.GetFactoryClass<IPrimCreator>(f.FullName, primClassName);
            if (primCreator == null)
            {
                return null;
            }
            if (!_listPrimCreator.ContainsKey(primFileName))
            {
                _listPrimCreator.Add(primFileName, primCreator);
            }
            return primCreator.ConcretePrimTypeAttributes;
        }
        #endregion
    }
}
