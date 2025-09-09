using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Global
{
    public class ElesManagerTransfer
    {
        #region Prop
        /// <summary>ConfigUI</summary>
        public static Form ElesConfigForm => ElesManager.Instance.ElesConfigForm;

        /// <summary>UserUI</summary>
        public static Form EleUserViewForm => ElesManager.Instance.EleUserViewForm;
        #endregion



        #region Method_ExternalUsing
        /// <summary>通过GUID获取元件</summary>
        public static IEle GetEleByGUID(Guid id)
        {
            return ElesManager.Instance.GetEleByGUID(id);
        }

        /// <summary>通过名字获取元件</summary>
        public static IEle GetEleByName(string name)
        {
            return ElesManager.Instance.GetEleByName(name);
        }

        /// <summary>通过GUID移除元件</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int RemoveEleByGUID(Guid id)
        {
            return ElesManager.Instance.RemoveEleByGUID(id);
        }

        /// <summary>通过GUID设置元件名称</summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int SetEleNameByGUID(Guid id, string name)
        {
            return ElesManager.Instance.SetEleNameByGUID(id, name);
        }

        /// <summary>元件使能_元件配置存在运行（正常模式）</summary>
        /// <param name="elesConfigPath">元件配置目录</param>
        /// <param name="elesAsmPath">元件dll目录</param>
        /// <returns>int</returns>
        public static int ElesManagerInit(string elesConfigPath, string elesAsmPath)
        {
            return ElesManager.Instance.ElesManagerInit(elesConfigPath, elesAsmPath);
        }

        /// <summary>【元件未使能】||【元件配置不存在】运行（异常模式）</summary>
        public static int ElesConfigFormInit()
        {
            return ElesManager.Instance.ElesConfigFormInit();
        }

        /// <summary>保存</summary>
        /// <returns></returns>
        public static int Save()
        {
            return ElesManager.Instance.Save();
        }

        public static int DataInfoManagerExport()
        {
            return ElesManager.Instance.DataInfoManagerExport();
        }

        public static int IoInfosExport()
        {
            return ElesManager.Instance.IoInfosExport();
        }

        /// <summary>手自动设置</summary>
        /// <param name="enable">true：手动；false：自动</param>
        public static void EnableHandle(bool enable)
        {
            ElesManager.Instance.EnableHandle(enable);
        }

        /// <summary>通过DLL反射加载元件属性公共接口</summary>
        /// <param name="eleFolderPath">元件dll目录</param>
        /// <returns>int</returns>
        public static int LoadPrimTypeAttributes(string eleFolderPath)
        {
            return ElesManager.Instance.LoadPrimTypeAttributes(eleFolderPath);
        }

        /// <summary>
        /// 根据元件型号获取IEle
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static IEle GetEle(string typeName)
        {
            return ElesManager.Instance.GetEle(typeName);
        }

        /// <summary>
        /// 元件调试刷新
        /// </summary>
        public static void RefreshDgv()
        {
            ElesManager.Instance.RefreshDgv();
        }

        /// <summary>
        /// 获取所有元件
        /// </summary>
        /// <returns></returns>
        public static List<IEle> GetAllIEle()
        {
            return ElesManager.Instance.GetAllIEle();
        }
        #endregion
    }
}
