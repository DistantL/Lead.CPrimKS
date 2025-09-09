using Lead.CPrim.Global;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using Lead.CPrim.CmpTrigHelper;
using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.ProxyTools;

namespace ScerwActionHelper.Common
{
    internal static class ScerwCommon
    {
        #region IO操作方法

        /// <summary>输入</summary>
        private static Dictionary<string, IEleDI> DiDictionary = new Dictionary<string, IEleDI>();
        /// <summary>输出</summary>
        private static Dictionary<string, IEleDO> DoDictionary = new Dictionary<string, IEleDO>();
        /// <summary>DI锁</summary>
        private static readonly object objDi = new object();
        /// <summary>DO锁</summary>
        private static readonly object objDo = new object();

        /// <summary>
        /// IO操作初始化
        /// </summary>
        public static void IniDiDoDictionary()
        {
            DiDictionary.Clear();
            DoDictionary.Clear();   
        }

        /// <summary>获取数字输入状态</summary>
        /// <param name="diName"></param>
        /// <returns></returns>
        public static bool? GetDi(string diName)
        {
            try
            {
                lock (objDi)
                {
                    if (!DiDictionary.ContainsKey(diName))
                    {
                        IEle _elet = ElesManager.Instance.GetEleByName(diName);
                        if (_elet == null)
                        {
                            return null;
                        }
                        _elet.IEleInit();
                        DiDictionary.Add(diName, (IEleDI)_elet);
                    }
                }
                return DiDictionary[diName].Read();
            }
            catch (Exception ex)
            {      
                return null;
            }
        }

        /// <summary>设置数字输出状态</summary>
        /// <param name="doName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int SetDo(string doName, bool value)
        {
            try
            {
                lock (objDo)
                {
                    if (!DoDictionary.ContainsKey(doName))
                    {
                        IEle _elet = ElesManager.Instance.GetEleByName(doName);
                        if (_elet == null)
                        {
                            return -1;
                        }
                        _elet.IEleInit();
                        DoDictionary.Add(doName, (IEleDO)_elet);
                    }
                }
                return DoDictionary[doName].Write(value);
            }
            catch (Exception ex)
            {
      
                return -1;
            }
        }

        /// <summary>
        /// 获取数字输出状态
        /// </summary>
        /// <param name="doName"></param>
        /// <returns></returns>
        public static bool? GetDo(string doName)
        {
            try
            {
                lock (objDo)
                {
                    if (!DoDictionary.ContainsKey(doName))
                    {
                        IEle _elet = ElesManager.Instance.GetEleByName(doName);
                        if (_elet == null)
                        {
                            return null;
                        }
                        _elet.IEleInit();
                        DoDictionary.Add(doName, (IEleDO)_elet);
                    }
                }
                return DoDictionary[doName].Read();
            }
            catch (Exception ex)
            {      
                return null;
            }
        }
        #endregion
        public static void PosCopy(Pos source, out Pos target)
        {
            target = new Pos();
            target.X = source.X;
            target.Y = source.Y;
            target.Z = source.Z;
            target.U = source.U;
            target.V = source.V;
            target.W = source.W;
        }
        /// <summary>
        /// 拷贝插补点位
        /// </summary>
        /// <param name="Lst"></param>
        /// <returns></returns>
        public static List<InterPolationPos> InterPolationPosClone(object Lst)
        {
            string str = JsonHelper.SerializeObject(Lst);
            return JsonHelper.DeserializeJsonToList<InterPolationPos>(str);
        }
    }
}
