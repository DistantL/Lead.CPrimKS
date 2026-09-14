using Lead.CPrim.Interfaces;
using Lead.Detect.INIHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    /// <summary>
    /// 抛料管理<br/>
    /// 配置文件路径由启动时的软件配置提供。<br/>
    /// </summary>
    public class TossingControl
    {
        #region Event
        /// <summary>
        /// 日志输出<br/>
        /// LogLevel.Other：报警输出；其它是正常日志记录。<br/>
        /// </summary>
        public event Action<string, LogLevel> Log;
        #endregion



        #region Field
        private int 连续抛料计数 = 0;
        private int 连续抛料阈值 = 3;

        private int 当前取料计数 = 0;
        private int 取料总数 = 100;

        private int 累计抛料计数 = 0;
        private int 累计抛料阈值 = 2;

        private FileInfo _statisticsFile;
        private FileInfo tossingStaticits_FileInfo
        {
            get
            {
                if (_statisticsFile == null)
                    _statisticsFile = new FileInfo(Lead.CPrim.ProxyTools.RuntimeConfigPaths.TossingStatisticsFilePath);
                return _statisticsFile;
            }
        }
        private INIHelper iNIHelper = new INIHelper();
        /// <summary>
        /// INI区域名称
        /// </summary>
        private string tossingName = "Tossing_1";

        private static TossingControl _instance = new TossingControl();
        private object locker = new object();
        #endregion



        #region Prop
        public static TossingControl Instance => _instance;
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="ContinuousTossingThreshold"></param>
        /// <param name="CheckAccessaryNum"></param>
        /// <param name="CheckTossingThreshold"></param>
        public void InitCheckTossingRate(int ContinuousTossingThreshold, int CheckAccessaryNum, int CheckTossingThreshold)
        {
            连续抛料阈值 = ContinuousTossingThreshold;
            取料总数 = CheckAccessaryNum;
            累计抛料阈值 = CheckTossingThreshold;


            lock (locker)
            {
                if (!tossingStaticits_FileInfo.Directory.Exists)
                {
                    tossingStaticits_FileInfo.Directory.Create();
                }
                if (!tossingStaticits_FileInfo.Exists)
                {
                    var filestream = tossingStaticits_FileInfo.Create();
                    filestream.Close();
                    iNIHelper.WriteIniS(tossingName, "ContinuousTossing", "0", tossingStaticits_FileInfo.FullName);
                    iNIHelper.WriteIniS(tossingName, "AccessaryCount", "0", tossingStaticits_FileInfo.FullName);
                    iNIHelper.WriteIniS(tossingName, "TossingCount", "0", tossingStaticits_FileInfo.FullName);
                }
            }

            string str = iNIHelper.GetIniS(tossingName, "ContinuousTossing", tossingStaticits_FileInfo.FullName);
            if (string.IsNullOrWhiteSpace(str) || !int.TryParse(str, out 连续抛料计数))
            {
                Log?.Invoke("ini读取[" + tossingName + "][ContinuousTossing]异常：[" + str + "]", LogLevel.Warn);
            }
            Log?.Invoke("ini读取[" + tossingName + "][ContinuousTossing]：[" + 连续抛料计数 + "]", LogLevel.Trace);

            str = iNIHelper.GetIniS(tossingName, "AccessaryCount", tossingStaticits_FileInfo.FullName);
            if (string.IsNullOrWhiteSpace(str) || !int.TryParse(str, out 当前取料计数))
            {
                Log?.Invoke("ini读取[" + tossingName + "][AccessaryCount]异常：[" + str + "]", LogLevel.Warn);
            }
            Log?.Invoke("ini读取[" + tossingName + "][AccessaryCount]：[" + 当前取料计数 + "]", LogLevel.Trace);

            str = iNIHelper.GetIniS(tossingName, "TossingCount", tossingStaticits_FileInfo.FullName);
            if (string.IsNullOrWhiteSpace(str) || !int.TryParse(str, out 累计抛料计数))
            {
                Log?.Invoke("ini读取[" + tossingName + "][TossingCount]异常：[" + str + "]", LogLevel.Warn);
            }
            Log?.Invoke("ini读取[" + tossingName + "][TossingCount]：[" + 累计抛料计数 + "]", LogLevel.Trace);
        }
        /// <summary>
        /// 抛料检查
        /// </summary>
        /// <param name="ngNum"></param>
        /// <param name="okNum"></param>
        public void CheckTossingRate(int ngNum, int okNum)
        {
            lock (locker)
            {
                当前取料计数 = 当前取料计数 + ngNum + okNum;
                if (ngNum != 0)
                {
                    连续抛料计数 = 连续抛料计数 + ngNum;
                    累计抛料计数 = 累计抛料计数 + ngNum;
                }

                if (okNum != 0)
                {
                    连续抛料计数 = 0;
                }

                //连续抛料超过阈值
                if (连续抛料计数 >= 连续抛料阈值)
                {
                    Log?.Invoke("连续抛料计数超过阈值：" + 连续抛料阈值, LogLevel.Other);
                    连续抛料计数 = 0;
                    累计抛料计数 = 0;
                    当前取料计数 = 0;
                }

                if (累计抛料计数 >= 累计抛料阈值)
                {
                    Log?.Invoke("累计抛料计数超过阈值：" + 累计抛料阈值, LogLevel.Other);
                    连续抛料计数 = 0;
                    累计抛料计数 = 0;
                    当前取料计数 = 0;
                }

                //达到间隔次数
                if (当前取料计数 >= 取料总数)
                {
                    连续抛料计数 = 0;
                    累计抛料计数 = 0;
                    当前取料计数 = 0;
                }

                iNIHelper.WriteIniS(tossingName, "ContinuousTossing", 连续抛料计数.ToString(), tossingStaticits_FileInfo.FullName);
                iNIHelper.WriteIniS(tossingName, "TossingCount", 累计抛料计数.ToString(), tossingStaticits_FileInfo.FullName);
                iNIHelper.WriteIniS(tossingName, "AccessaryCount", 当前取料计数.ToString(), tossingStaticits_FileInfo.FullName);
                Log?.Invoke(string.Format("当前取料计数：{0}；累计抛料计数：{1}；连续抛料计数：{2}；"
                                                   , 当前取料计数
                                                   , 累计抛料计数
                                                   , 连续抛料计数), LogLevel.Info);
            }
        }
        /// <summary>
        /// 清除Log所有事件注册<br/>
        /// </summary>
        public void ClearEvent()
        {
            if(Log != null)
            {
                foreach(var p in Log.GetInvocationList()) 
                { 
                    Log -= p as Action<string, LogLevel>;
                }
            }
        }
        #endregion
    }
}
