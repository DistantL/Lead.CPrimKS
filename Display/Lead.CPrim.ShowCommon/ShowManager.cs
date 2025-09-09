using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ShowCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Lead.CPrim.Global
{
    /// <summary>显示管理器（仅用来管理【程序已使用显示集合】）</summary>
    public class ShowManager
    {
        #region Field
        /// <summary>显示管理器对象</summary>
        private static readonly ShowManager _instance = new ShowManager();

        /// <summary>程序已使用显示集合</summary>
        private List<IShow> _listShow = new List<IShow>();

        /// <summary>显示基元配置UI</summary>
        private ShowConfigForm _showConfigForm;

        /// <summary>显示配置路径</summary>
        private string _configFilePath;

        /// <summary>显示全路径集合[显示名称，dll全路径]</summary>
        private Dictionary<string, string> _dicShow = new Dictionary<string, string>();

        /// <summary>显示创建公共接口集合[dll全路径，显示创建公共接口]</summary>
        private Dictionary<string, IShowCreator> _dicShowCreator = new Dictionary<string, IShowCreator>();

        /// <summary>显示属性公共接口集合[显示名称，显示属性公共接口IShowTypeAttributes]</summary>
        private Dictionary<string, IShowTypeAttributes> _dicSupportedShowType = new Dictionary<string, IShowTypeAttributes>();

        /// <summary>显示创建公共接口</summary>
        private string _showClassName = "Lead.CPrim.Interfaces.IShowCreator";

        /// <summary>防呆</summary>
        private List<string> _listShowFileName = new List<string>();
        #endregion



        #region Porp
        /// <summary>显示管理器对象</summary>
        public static ShowManager Instance => _instance;

        /// <summary>程序已使用显示集合</summary>
        public List<IShow> ListShow => _listShow;

        /// <summary>显示基元配置UI</summary>
        public ShowConfigForm ShowConfigForm => _showConfigForm;

        /// <summary>显示属性公共接口集合[显示名称，显示属性公共接口]</summary>
        public Dictionary<string, IShowTypeAttributes> SupportedShowTypes => _dicSupportedShowType;
        #endregion



        #region Ctor
        public ShowManager()
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
        /// <summary>显示基元初始化</summary>
        public int ShowConfigFormInit(string showAssemblyPath)
        {
            int iRet = 0;
            if (_showConfigForm != null) return iRet;

            _showConfigForm = new ShowConfigForm(showAssemblyPath);

            _showConfigForm.OnAddShow -= OnAddShowInConfigForm;
            _showConfigForm.OnAddShow += OnAddShowInConfigForm;

            _showConfigForm.OnChangeShowName -= OnChangeShowNameInConfigForm;
            _showConfigForm.OnChangeShowName += OnChangeShowNameInConfigForm;

            _showConfigForm.OnRemoveShow -= OnRemoveShowInConfigForm;
            _showConfigForm.OnRemoveShow += OnRemoveShowInConfigForm;

            foreach (IShow show in Instance.ListShow)
                _showConfigForm.CreateShowDisplay(show);
            return iRet;
        }

        /// <summary>根据GUID获取显示[IShow对象]</summary>
        public IShow GetShowByGUID(Guid showGuid)
        {
            if (ListShow.Count < 1) return null;
            return ListShow.FirstOrDefault(p => p.Id == showGuid);
        }

        /// <summary>根据GUID移除显示</summary>
        public int RemoveShowByGUID(Guid showGuid)
        {
            if (ListShow.Count < 1)
            {
                return 0;
            }

            IShow prim = ListShow.FirstOrDefault(p => p.Id == showGuid);
            if (prim == null)
            {
                return 0;
            }

            ListShow.Remove(prim);
            return 0;
        }

        /// <summary>根据名称获取显示</summary>
        public IShow GetShowByName(string showName)
        {
            if (ListShow.Count < 1) return null;
            return ListShow.FirstOrDefault(p => p.Name == showName);
        }

        /// <summary>新增IShow</summary>
        /// <param name="show">显示</param>
        /// <returns></returns>
        public int AddShow(IShow show)
        {
            if (show == null)
            {
                return -1;
            }

            ListShow.Add(show);

            return 0;
        }

        /// <summary>显示基元保存</summary>
        /// <returns>int</returns>
        public int Save()
        {
            if(!AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
                return -1;
            }
            return SaveConfigFile(GetShowConfigs()) ? 0 : -1;
        }

        /// <summary>获取【程序已使用显示集合】之【显示配置集合】</summary>
        /// <returns>ShowConfigs</returns>
        public ShowConfigs GetShowConfigs()
        {
            ShowConfigs showConfigs = new ShowConfigs();
            if (_listShow.Count > 0)
            {
                showConfigs.ListShowConfigs.Clear();
                foreach (IShow show in _listShow)
                {
                    XmlNode xmlNode = show.IShowExportConfigXml();
                    showConfigs.ListShowConfigs.Add(new SingleShowConfig { ShowType = show.ShowTypeName, ShowXmlNode = xmlNode });
                }
            }
            return showConfigs;
        }

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"ShowCommon -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.ShowCommon}0000";

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

        /// <summary>反射加载DLL</summary>
        public IShowTypeAttributes GetShowTypeInstance(string showFileName, string showClassName)
        {
            try
            {
                IShowCreator showCreator = ProxyTools.FactoryCreator.GetFactoryClass<IShowCreator>(showFileName, showClassName);
                if (showCreator == null) return null;
                if (!_dicShowCreator.ContainsKey(showFileName)) _dicShowCreator.Add(showFileName, showCreator);
                return showCreator.ConcreteShowTypeAttributes;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>加载显示类库（WelCome调用/ShowToolBar调用）</summary>
        public int LoadShowTypeAttributes(string showFolderPath)
        {
            int ret = 0;
            if (string.IsNullOrEmpty(showFolderPath)) return -1;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(showFolderPath);
                FileSystemInfo[] files = dir.GetFileSystemInfos("*.dll");
                FileSystemInfo[] array = files;
                foreach (FileSystemInfo t in array)
                {
                    FileInfo file = t as FileInfo;
                    if (file == null) continue;
                    string showFileName = file.FullName;
                    if (_listShowFileName.Contains(showFileName)) continue;
                    _listShowFileName.Add(showFileName);
                    IShowTypeAttributes showAttr = GetShowTypeInstance(showFileName, _showClassName);
                    if (showAttr != null && !_dicSupportedShowType.ContainsKey(showAttr.Name))
                    {
                        _dicSupportedShowType.Add(showAttr.Name, showAttr);
                        if (!_dicShow.ContainsKey(showAttr.Name))
                            _dicShow.Add(showAttr.Name, showFileName);
                    }
                }
            }
            catch
            {
                return -1;
            }
            return ret;
        }

        /// <summary>通过显示类型获取【IShow】</summary>
        public IShow GetShow(string showTypeName)
        {
            try
            {
                if (_dicShow.ContainsKey(showTypeName))
                {
                    string showFile = _dicShow[showTypeName];
                    if (_dicShowCreator.ContainsKey(showFile))
                    {
                        IShowCreator showCreator = _dicShowCreator[showFile];
                        return showCreator.Create();
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>通过显示类型获取【IShow】并完成显示基元赋值</summary>
        public IShow GetShow(string showTypeName, XmlNode xmlNode, string showConfigsPath)
        {
            _configFilePath = showConfigsPath;
            try
            {
                if (_dicShow.ContainsKey(showTypeName))
                {
                    string showFile = _dicShow[showTypeName];
                    if (_dicShowCreator.ContainsKey(showFile))
                    {
                        IShowCreator showCreator = _dicShowCreator[showFile];
                        return showCreator.Create(xmlNode);
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>通过显示类型获取【IShowCreator】</summary>
        public IShowCreator GetShowCreator(string showTypeName)
        {
            try
            {
                if (_dicShow.ContainsKey(showTypeName))
                {
                    string showFile = _dicShow[showTypeName];
                    if (_dicShowCreator.ContainsKey(showFile))
                    {
                        return _dicShowCreator[showFile];
                    }
                    return null;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取所有基元
        /// </summary>
        /// <returns></returns>
        public List<IShow> GetAllIShow()
        {
            return ListShow;
        }
        #endregion



        #region Method_UI2
        /// <summary>新增显示基元时发生响应</summary>
        /// <param name="group">分组</param>
        /// <param name="type">显示名称</param>
        /// <param name="showname">显示名称</param>
        /// <param name="showid">Id</param>
        private void OnAddShowInConfigForm(string group, string type, string showname, Guid showid)
        {

        }
        /// <summary>改变基元显示名称时发生响应</summary>
        /// <param name="showid">Id</param>
        /// <param name="dstshowname">显示名称</param>
        private void OnChangeShowNameInConfigForm(Guid showid, string dstshowname)
        {

        }
        /// <summary>移除显示基元时发生响应</summary>
        /// <param name="showid">Id</param>
        private void OnRemoveShowInConfigForm(Guid showid)
        {

        }
        #endregion



        #region Method_InternalUsing
        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        private void SetEnable(bool enable)
        {
            ShowConfigForm?.SetEnable(enable);
        }

        /// <summary>保存</summary>
        public bool SaveConfigFile(ShowConfigs showConfigs)
        {
            return XmlSerializerHelper.WriteXML(showConfigs, _configFilePath, typeof(ShowConfigs));
        }
        #endregion
    }
}
