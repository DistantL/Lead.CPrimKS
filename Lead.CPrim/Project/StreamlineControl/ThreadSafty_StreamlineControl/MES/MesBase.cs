using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    public abstract class MesBase
    {
        /// <summary>
        /// 写入锁
        /// </summary>
        static readonly object _objWrite = new object();



        /// <summary>
        /// 作业员工号
        /// </summary>
        public string empNo { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string terminalName { get; set; }
        /// <summary>
        /// MesIP
        /// </summary>
        public string MesIP { get; set; }
        /// <summary>
        /// Mes图片IP
        /// </summary>
        public string MesImageIP { get; set; }



        /// <summary>
        /// 获取辅料数量<br/>
        /// True：辅料可以使用<br/>
        /// False：辅料不可以使用<br/>
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="canUseQty"></param>
        /// <returns></returns>
        public abstract bool GetLotnoCount(string sn, out string canUseQty);



        public virtual void WriteMesLog(string sn, string msg)
        {
            lock (_objWrite)
            {
                string path = $@"D:\MES log\{DateTime.Now:yyyyMMdd}\{sn}.log";
                FileInfo info = new FileInfo(path);
                if (!info.Directory.Exists)
                {
                    info.Directory.Create();
                }

                if (!info.Exists)
                {
                    info.Create().Close();
                    Thread.Sleep(5);
                }

                File.AppendAllText(path, $"{msg}{Environment.NewLine}");
            }
        }
    }



    /// <summary>
    /// Mes返回解析类
    /// </summary>
    public class MesReturnMsg
    {
        public bool Result { get; set; }
        public string RetMsg { get; set; }
    }
}
