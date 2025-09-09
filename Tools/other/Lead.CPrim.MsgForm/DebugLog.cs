using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.MsgForm
{
    class DebugLog
    {
        static string _debugLogPath = @"D:\CPrimlog\Debug_Log";
        /// <summary>将日志写入指定的地址</summary>
        /// <param name="Mes">日志</param>
        /// <param name="floor">层级</param>
        public static void WriteLog(ref string Mes, int floor)
        {
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                System.Diagnostics.StackFrame[] sfs = st.GetFrames();

                string _namespaceName = string.Empty;
                string _className = string.Empty;
                string _methodName = string.Empty;

                _namespaceName = sfs[floor].GetMethod().DeclaringType.Namespace;
                _className = sfs[floor].GetMethod().DeclaringType.Name;
                _methodName = sfs[floor].GetMethod().Name;

                Mes = $"[{_namespaceName}].[{_className}].[{_methodName}]\n\n{Mes}";
                Console.WriteLine(Mes);

                if (!Directory.Exists(_debugLogPath))
                {
                    Directory.CreateDirectory(_debugLogPath);
                }
                using (StreamWriter sw = new StreamWriter(_debugLogPath + $"\\{DateTime.Now.ToString("yyyyMMdd")}.Log", true))
                {
                    sw.WriteLine(Mes);
                };
            }
            catch { }
        }
    }
}
