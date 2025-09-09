using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Common;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ProxyTools.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lead.CPrim.ProxyTools.Authority
{
    public class MesManager
    {
        public static event Func<string, string, string, string, string, string, bool, string> OnMesCheck;

        public static event Func<List<HashKeyInfos>, string> OnMesHashKeyUpload;

        public static event Func<string, string, string> OnMesAlarmCheckReq;

        public static event Func<string> OnMesAlarmCheckRet;

        private static List<HashKeyInfos> _hashKeyInfos = new List<HashKeyInfos>();

        public static List<HashKeyInfos> GetHashKeyInfos() 
        {
            _hashKeyInfos.ForEach(p => p.ItemValue = AudioSwVersion.Instance.GetSHA1InFile(p.ItemPath));
            return _hashKeyInfos; 
        }

        public static void SetHashKeyInfos(List<HashKeyInfos> hashKeyInfos) 
        {
            _hashKeyInfos.Clear();
            hashKeyInfos.ForEach(p => _hashKeyInfos.Add(p));
        }

        public static string MesCheck(string project, string line, string headId, string item, string maxTime, string alertTime, bool isAdd) 
        {
            return OnMesCheck?.Invoke(project, line, headId, item, maxTime, alertTime, isAdd);
        }

        public static string HashKeyUpload(List<HashKeyInfos> hashKeyInfos)
        {
            return OnMesHashKeyUpload?.Invoke(hashKeyInfos);
        }

        public static string AlarmCheckReq(string Id, string sn)
        {
            return OnMesAlarmCheckReq?.Invoke(Id, sn);
        }

        public static string AlarmCheckRet()
        {
            return OnMesAlarmCheckRet?.Invoke();
        }

        public static void ClearEventHandlers()
        {
            var handlers = OnMesCheck?.GetInvocationList();
            if (handlers != null)
            {
                foreach (Delegate handler in handlers)
                {
                    OnMesCheck -= (Func<string, string, string, string, string, string, bool, string>)handler;
                }
            }

            handlers = OnMesHashKeyUpload?.GetInvocationList();
            if (handlers != null)
            {
                foreach (Delegate handler in handlers)
                {
                    OnMesHashKeyUpload -= (Func<List<HashKeyInfos>, string>)handler;
                }
            }
        }
    }
}
