using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public class EventManager
    {
        public static event Func<bool> OnAutoManualCheck;
        /// <summary>
        /// True：显示；False：不显示；
        /// </summary>
        /// <returns></returns>
        public static bool AutoManualCheck()
        {
            try
            {
                return OnAutoManualCheck?.Invoke() ?? true;
            }
            catch
            {
                return true;
            }
        }
        public static void ClearEventHandlers()
        {
            if (OnAutoManualCheck != null)
            {
                foreach (var p in OnAutoManualCheck.GetInvocationList())
                {
                    OnAutoManualCheck -= (Func<bool>)p;
                }
            }
        }



        public static event Func<string, string> OnGetLotno;
        /// <summary>
        /// 根据SN获取辅料数量
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public static string GetLotno(string sn)
        {
            try
            {
                return OnGetLotno?.Invoke(sn) ?? "";
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 清除事件OnGetLotno<br/>
        /// </summary>
        public static void ClearOnGetLotno()
        {
            if (OnGetLotno != null)
            {
                foreach (var d in OnGetLotno.GetInvocationList())
                {
                    OnGetLotno -= d as Func<string, string>;
                }
            }
        }




        public static event Action<SwitchStatus> OnSwitchStatus;
        /// <summary>
        /// 改变状态机状态
        /// </summary>
        /// <param name="status"></param>
        public static void SwitchStatus(SwitchStatus status)
        {
            OnSwitchStatus?.Invoke(status);
        }
    }
}
