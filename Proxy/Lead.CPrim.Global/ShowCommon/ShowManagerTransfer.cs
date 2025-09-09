using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Global
{
    public class ShowManagerTransfer
    {
        #region Prop
        /// <summary>基元配置UI</summary>
		public static Form ShowConfigForm => ShowManager.Instance.ShowConfigForm;
        #endregion



        /// <summary>显示基元初始化</summary>
        public static int ShowConfigFormInit(string showAssemblyPath)
        {
            return ShowManager.Instance.ShowConfigFormInit(showAssemblyPath);
        }

        /// <summary>根据GUID获取显示[IShow对象]</summary>
        public static IShow GetShowByGUID(Guid showGuid)
        {
            return ShowManager.Instance.GetShowByGUID(showGuid);
        }

        /// <summary>根据GUID移除显示</summary>
        public static int RemoveShowByGUID(Guid showGuid)
        {
            return ShowManager.Instance.RemoveShowByGUID(showGuid);
        }

        /// <summary>根据名称获取显示</summary>
        public static IShow GetShowByName(string showName)
        {
            return ShowManager.Instance.GetShowByName(showName);
        }

        /// <summary>新增IShow</summary>
        /// <param name="show">显示</param>
        /// <returns></returns>
        public static int AddShow(IShow show)
        {
            return ShowManager.Instance.AddShow(show);
        }

        /// <summary>显示基元保存</summary>
        /// <returns>int</returns>
        public static int Save()
        {
            int result = ShowManager.Instance.Save();
            if(result == 0)
            {
                UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_Global_ShowConfigSaveSuccess", "显示设置保存成功"));
            }
            return result;
        }

        /// <summary>反射加载DLL</summary>
        public static IShowTypeAttributes GetShowTypeInstance(string showFileName, string showClassName)
        {
            return ShowManager.Instance.GetShowTypeInstance(showFileName, showClassName);
        }

        /// <summary>加载显示类库（WelCome调用/ShowToolBar调用）</summary>
        public static int LoadShowTypeAttributes(string showFolderPath)
        {
            return ShowManager.Instance.LoadShowTypeAttributes(showFolderPath);
        }

        /// <summary>通过显示类型获取【IShow】</summary>
        public static IShow GetShow(string showTypeName)
        {
            return ShowManager.Instance.GetShow(showTypeName);
        }

        /// <summary>通过显示类型获取【IShow】并完成显示基元赋值</summary>
        public static IShow GetShow(string showTypeName, XmlNode xmlNode, string showConfigsPath)
        {
            ShowManager.Instance.ConfigFilePath = showConfigsPath;
            return ShowManager.Instance.GetShow(showTypeName,xmlNode);
        }

        /// <summary>通过显示类型获取【IShowCreator】</summary>
        public static IShowCreator GetShowCreator(string showTypeName)
        {
            return ShowManager.Instance.GetShowCreator(showTypeName);
        }

        /// <summary>
        /// 获取所有基元
        /// </summary>
        /// <returns></returns>
        public static List<IShow> GetAllIShow()
        {
            return ShowManager.Instance.GetAllIShow();
        }
    }
}
