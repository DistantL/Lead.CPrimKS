using System;
using System.Collections.Concurrent;
using Lead.CPrim.Interfaces;
using NLog;

namespace Lead.CPrim.LogHelper
{
    public class Log
    {
        #region Field
        private static Logger _MachineLogger = LogManager.GetLogger("MachineLog");
        private static Logger _logError = LogManager.GetLogger("MachineLogError");
        private static Logger _Hive_MachineErrorLogger = LogManager.GetLogger("HiveLogMachineError");
        private static Logger _Hive_MachineDataLogger = LogManager.GetLogger("HiveLogMachineData");
        private static Logger _Hive_MachineStateLogger = LogManager.GetLogger("HiveLogMachineState");
        private static Logger _RemoteQualification_MachineErrorLogger = LogManager.GetLogger("RemoteLogMachineError");
        private static Logger _RemoteQualification_MachineDataLogger = LogManager.GetLogger("RemoteLogMachineData");
        private static Logger _RemoteQualification_MachineStateLogger = LogManager.GetLogger("RemoteLogMachineState");

        #endregion



        #region Method_ExternalUsing
        /// <summary>Fatal</summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Fatal(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(Interfaces.LogLevel.Fatal, msg, location, classification, id);
        }

        /// <summary>Error</summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Error(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(Interfaces.LogLevel.Error, msg, location, classification, id);
        }

        /// <summary>Warn</summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Warn(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(Interfaces.LogLevel.Warn, msg, location, classification, id);
        }

        /// <summary>Info</summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Info(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(Interfaces.LogLevel.Info, msg, location, classification, id);
        }

        /// <summary>Debug</summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Debug(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(Interfaces.LogLevel.Debug, msg, location, classification, id);
        }

        /// <summary>Trace</summary>
        /// <param name="id">id</param>
        /// <param name="msg">消息</param>
        /// <param name="classification">日志分类</param>
        /// <param name="location">日志位置</param>
        public static void Trace(long id, string msg, LogClassification classification, string location)
        {
            LogAdd(Interfaces.LogLevel.Trace, msg, location, classification, id);
        }

        /// <summary>
        /// ALL<br/>
        /// 针对所有日志
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="msg">消息</param>
        /// <param name="location">日志位置</param>
        /// <param name="classification">日志分类</param>
        /// <param name="id">id</param>
        public static void LogAdd(Interfaces.LogLevel level, string msg, string location, LogClassification classification = LogClassification.Other, long id = 0L)
        {
            try
            {
                LogEventInfo val = new LogEventInfo();
                val.Properties["LogId"] = id;
                val.Properties["Classification"] = classification;
                val.Properties["Location"] = location;
                switch (level)
                {
                    case Interfaces.LogLevel.Fatal:
                        val.Level = NLog.LogLevel.Fatal;
                        break;
                    case Interfaces.LogLevel.Error:
                        val.Level = NLog.LogLevel.Error;
                        break;
                    case Interfaces.LogLevel.Warn:
                        val.Level = NLog.LogLevel.Warn;
                        break;
                    case Interfaces.LogLevel.Info:
                        val.Level = NLog.LogLevel.Info;
                        break;
                    case Interfaces.LogLevel.Debug:
                        val.Level = NLog.LogLevel.Debug;
                        break;
                    case Interfaces.LogLevel.Trace:
                        val.Level = NLog.LogLevel.Trace;
                        break;
                    case Interfaces.LogLevel.Other:
                        val.Level = NLog.LogLevel.Off;
                        break;
                    default:
                        val.Level = NLog.LogLevel.Off;
                        break;
                }
                val.Properties["Message"] = msg;

                _MachineLogger.Log(val);

                if(level == Interfaces.LogLevel.Warn || level == Interfaces.LogLevel.Error || level == Interfaces.LogLevel.Fatal)
                {
                    LogAddError(msg);
                }
            }
            catch { }
        }

        /// <summary>
        /// 仅记录错误日志
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="msg">消息</param>
        /// <param name="location">日志位置</param>
        /// <param name="classification">日志分类</param>
        /// <param name="id">id</param>
        public static void LogAddError(string msg)
        {
            try
            {
                LogEventInfo val = new LogEventInfo()
                {
                    Level = NLog.LogLevel.Info,
                };
                val.Properties["Message"] = msg;
                _logError.Log(val);
            }
            catch { }
        }

        /// <summary>
        /// HIVE
        /// </summary>
        /// <param name="level">Hive日志分类</param>
        /// <param name="msg">消息</param>
        public static void HiveLogAdd(HiveLogLevel level, string msg)
        {
            try
            {
                LogEventInfo val = new LogEventInfo
                {
                    Level = NLog.LogLevel.Info
                };
                val.Properties["Message"] = msg;

                Logger logger;
                switch (level)
                {
                    case HiveLogLevel.Error:
                        logger = _Hive_MachineErrorLogger;
                        break;
                    case HiveLogLevel.Data:
                        logger = _Hive_MachineDataLogger;
                        break;
                    case HiveLogLevel.State:
                        logger = _Hive_MachineStateLogger;
                        break;
                    case HiveLogLevel.Other:
                        logger = _Hive_MachineDataLogger;
                        break;
                    default:
                        logger = _MachineLogger;
                        break;
                }

                logger.Log(val);
            }
            catch { }
        }

        /// <summary>
        /// HIVE
        /// </summary>
        /// <param name="level">Hive日志分类</param>
        /// <param name="msg">消息</param>
        public static void HiveRemoteLogAdd(HiveLogLevel level, string msg)
        {
            try
            {
                LogEventInfo val = new LogEventInfo
                {
                    Level = NLog.LogLevel.Info
                };
                val.Properties["Message"] = msg;

                Logger logger;
                switch (level)
                {
                    case HiveLogLevel.Error:
                        logger = _RemoteQualification_MachineErrorLogger;
                        break;
                    case HiveLogLevel.Data:
                        logger = _RemoteQualification_MachineDataLogger;
                        break;
                    case HiveLogLevel.State:
                        logger = _RemoteQualification_MachineStateLogger;
                        break;
                    case HiveLogLevel.Other:
                        logger = _RemoteQualification_MachineDataLogger;
                        break;
                    default:
                        logger = _MachineLogger;
                        break;
                }

                logger.Log(val);
            }
            catch { }
        }
        #endregion
    }
}
