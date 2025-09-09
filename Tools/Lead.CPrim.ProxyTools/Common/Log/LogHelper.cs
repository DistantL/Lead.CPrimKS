using Lead.CPrim.Interfaces;
using Lead.CPrim.LogHelper;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.IO;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        #region Event
        /// <summary>
        /// 获取日志时发生
        /// </summary>
        public static event Action<string, LogLevel, LogClassification> OnGetLog;
        /// <summary>
        /// 获取报警时发生<br/>
        /// 只能在框架内使用，不能在脚本中使用，如果脚本需要，请使用OnGetAlarmTask
        /// </summary>
        public static event Action<string, LogLevel, LogClassification> OnGetAlarm;
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Fatal(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(LogLevel.Fatal, msg, location, classification, id);
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Error(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(LogLevel.Error, msg, location, classification, id);
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Warn(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(LogLevel.Warn, msg, location, classification, id);
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Info(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(LogLevel.Info, msg, location, classification, id);
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Debug(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(LogLevel.Debug, msg, location, classification, id);
        }

        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Trace(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(LogLevel.Trace, msg, location, classification, id);
        }

        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="ex"></param>
        public static void Fatal(string msg, Exception ex = null)
        {
            if (ex != null)
            {
                msg = $"{msg}：{ex.Message}：{ex.StackTrace}";
            }
            LogAdd(LogLevel.Fatal, msg, nameof(LogHelper), LogClassification.Tools);
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="ex"></param>
        public static void Error(string msg, Exception ex = null)
        {
            if (ex != null)
            {
                msg = $"{msg}：{ex.Message}：{ex.StackTrace}";
            }
            LogAdd(LogLevel.Error, msg, nameof(LogHelper), LogClassification.Tools);
        }

        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="ex"></param>
        public static void Warn(string msg, Exception ex = null)
        {
            if (ex != null)
            {
                msg = $"{msg}：{ex.Message}：{ex.StackTrace}";
            }
            LogAdd(LogLevel.Warn, msg, nameof(LogHelper), LogClassification.Tools);
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="msg">消息</param>
        public static void Info(string msg)
        {
            LogAdd(LogLevel.Info, msg, nameof(LogHelper), LogClassification.Tools);
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="msg">消息</param>
        public static void Debug(string msg)
        {
            LogAdd(LogLevel.Debug, msg, nameof(LogHelper), LogClassification.Tools);
        }

        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="msg">消息</param>
        public static void Trace(string msg)
        {
            LogAdd(LogLevel.Trace, msg, nameof(LogHelper), LogClassification.Tools);
        }

        /// <summary>
        /// ALL
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="msg">消息</param>
        /// <param name="location">日志位置</param>
        /// <param name="classification">日志分类</param>
        /// <param name="id">id</param>
        public static void LogAdd(LogLevel level, string msg, string location, LogClassification classification = LogClassification.Other, long id = 0L)
        {
            if (level == LogLevel.Fatal || level == LogLevel.Error || level == LogLevel.Warn)
            {
                OnGetAlarm?.Invoke(msg, level, classification);
                AlarmManager.Instance.InsertAlarm(msg);
            }
            else
            {
                OnGetLog?.Invoke(msg, level, classification);
            }

            string strs = string.Format("User:{0} Function:{1} UID:{2} Authorize:{3} Function:{4} UID:{5} "
                , AuthorityManager.Instance?.CurrentUserName == "" ? "null" : AuthorityManager.Instance.CurrentUserName
                , AuthorityManager.Instance?.CurrentVendor == "" ? "null" : AuthorityManager.Instance.CurrentVendor
                , AuthorityManager.Instance?.CurrentUserID == "" ? "null" : AuthorityManager.Instance.CurrentUserID
                , AuthorityManager.Instance?.CurrentAuthorizeName == "" ? "null" : AuthorityManager.Instance.CurrentAuthorizeName
                , AuthorityManager.Instance?.CurrentAuthorizeVendor == "" ? "null" : AuthorityManager.Instance.CurrentAuthorizeVendor
                , AuthorityManager.Instance?.CurrentAuthorizeID == "" ? "null" : AuthorityManager.Instance.CurrentAuthorizeID);

            if (level == LogLevel.Fatal || level == LogLevel.Error || level == LogLevel.Warn)
            {
                strs = strs + "[Error/Alert]";
            }

            Log.LogAdd(level, strs + msg, location, classification, id);
        }

        /// <summary>
        /// HIVE
        /// </summary>
        /// <param name="level">Hive日志分类</param>
        /// <param name="msg">消息</param>
        public static void HiveLogAdd(HiveLogLevel level, string msg)
        {
            Log.HiveLogAdd(level, msg);
        }

        /// <summary>
        /// HIVE
        /// </summary>
        public static void HiveRemoteLogAdd(HiveLogLevel level, string msg)
        {
            Log.HiveRemoteLogAdd(level, msg);
        }

        /// <summary>写日志</summary>
        /// <param name="path">路径</param>
        /// <param name="mes">日志</param>
        public static void WriteLog(string path, string mes)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, $"{DateTime.Now.ToString("yyyy-MM-dd")}.log");
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(mes);
            }
        }
        #endregion
    }
}
