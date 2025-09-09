using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.Global
{
    public class PrimsManagerTransfer
    {
        #region Prop
        /// <summary>基元配置UI</summary>
		public static Form PrimsConfigForm => PrimsManager.Instance.PrimsConfigForm;
        #endregion



        #region Method_ExternalUsing
        /// <summary>基元初始化（Welcome调用（不进行基元反射））</summary>
        /// <param name="primsAssemblyPath">基元DLL地址</param>
        /// <returns>int</returns>
        public static int PrimsConfigFormInit(string primsAssemblyPath)
        {
            return PrimsManager.Instance.PrimsConfigFormInit(primsAssemblyPath);
        }

        /// <summary>根据Id获取IPrim</summary>
        /// <param name="id">Id</param>
        /// <returns>IPrim</returns>
        public static IPrim GetPrimByGUID(Guid id)
        {
            return PrimsManager.Instance.GetPrimByGUID(id);
        }

        /// <summary>根据名称获取IPrim</summary>
        /// <param name="primName">基元名称</param>
        /// <returns></returns>
        public static IPrim GetPrimByName(string primName)
        {
            return PrimsManager.Instance.GetPrimByName(primName);
        }

        /// <summary>新增IPrim</summary>
        /// <param name="prim">基元</param>
        /// <returns></returns>
        public static int AddPrim(IPrim prim)
        {
            return PrimsManager.Instance.AddPrim(prim);
        }

        /// <summary>根据Id移除IPrim</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int RemovePrimByGUID(Guid id)
        {
            return PrimsManager.Instance.RemovePrimByGUID(id);
        }

        /// <summary>根据Id设置基元名称</summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int SetPrimNameByGUID(Guid id, string name)
        {
            return SetPrimNameByGUID(id, name);
        }

        /// <summary>基元保存</summary>
        /// <returns>int</returns>
        public static int Save()
        {
            int result = PrimsManager.Instance.Save();
            if(result == 0)
            {
                UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_Global_PrimsManagerTransfer_PrimsConfigSaveSuccess", "基元设置保存成功"));
            }
            return result; 
        }


        /// <summary>加载基元Dll</summary>
        /// <param name="primFolderPath">Dll地址</param>
        /// <returns>int</returns>
        public static int LoadPrimTypeAttributes(string primFolderPath)
        {
            return PrimsManager.Instance.LoadPrimTypeAttributes(primFolderPath);
        }

        /// <summary>根据基元类型获取IPrimCreator</summary>
        /// <param name="devPrimTypeName">基元名称</param>
        /// <returns></returns>
        public static IPrimCreator GetDevPrimCreator(string devPrimTypeName)
        {
            return PrimsManager.Instance.GetDevPrimCreator(devPrimTypeName);
        }

        /// <summary>根据基元类型获取IPrim</summary>
        /// <param name="primTypeName">基元名称</param>
        /// <returns>IPrim</returns>
        public static IPrim GetPrim(string primTypeName)
        {
            return PrimsManager.Instance.GetPrim(primTypeName);
        }

        /// <summary>根据基元名称、配置文件获取IPrim</summary>
        /// <param name="primTypeName">基元名称</param>
        /// <param name="xmlNode">配置文件</param>
        /// <param name="primConfigsPath">基元配置路径</param>
        /// <returns></returns>
        public static IPrim GetPrim(string primTypeName, XmlNode xmlNode, string primConfigsPath)
        {
            PrimsManager.Instance.ConfigPath = primConfigsPath;
            return PrimsManager.Instance.GetPrim(primTypeName,xmlNode);
        }

        /// <summary>
        /// 获取所有基元
        /// </summary>
        /// <returns></returns>
        public static List<IPrim> GetAllIPrim()
        {
            return PrimsManager.Instance.GetAllIPrim();
        }
        #endregion
    }
}
