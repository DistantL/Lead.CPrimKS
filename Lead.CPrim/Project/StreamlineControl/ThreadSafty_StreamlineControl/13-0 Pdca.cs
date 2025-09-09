using Lead.CPrim.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    public class PDCA
    {
        private ISktClient _client;
        private PDCAconfig _config;
        private JsonSerializerSettings sf = new JsonSerializerSettings();
        public event Action<string> log;


        private bool flag_CallBackComplete = false;
        private bool flag_UpDataSuccess = false;
        private string receivedBuffer = "";
        private string _errorMesssage;
        public string Local_IP
        {
            get
            {
                return _config.Local_IP;
            }
        }
        public string GetErrorMessage
        {
            get
            {
                return _errorMesssage;
            }
        }

        /// <summary>
        /// 阻塞锁，防止多线程冲突
        /// </summary>
        public object locker = new object();

        public PDCA(ISktClient client, PDCAconfig config)
        {
            _config = config;

            if (_config.IP != client.Ip || _config.Port != client.Port)
            {
                throw new Exception($"请检查PDCA设置IP:Port[{_config.IP}:{_config.Port}]与传入的isktClient[{client.Ip}:{client.Port}]不同");
            }
            _client = client;
            _client.ClearEventOnMsgReved(); //清除订阅
            _client.OnMsgReved += _client_OnMsgReved;//订阅
        }

        /// <summary>
        /// PDCA基元接收数据处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        private void _client_OnMsgReved(string send, object msg)
        {
            log("PDCA接收:" + msg.ToString());
            if (string.IsNullOrWhiteSpace(msg.ToString()))
            {
                return;
            }
            receivedBuffer += msg;
            if (receivedBuffer.Contains("err@")
                || receivedBuffer.Contains("bad@")
                || receivedBuffer.Contains("unit_status=FAIL"))
            {
                flag_UpDataSuccess = false;
                flag_CallBackComplete = true;
                return;//反馈异常
            }

            if (receivedBuffer.Contains("ok@{}@\n}")) //正常结束标记
            {
                flag_UpDataSuccess = true;
                flag_CallBackComplete = true;
                return;//反馈正常
            }
        }

        /// <summary>
        /// PDCA数据处理
        /// </summary>
        /// <param name="PDCAdata">物料数据</param>
        /// <param name="SN">物料SN</param>
        internal string ConvertToPDCAdata(ProductionInfo productionInfo, List<FaiItem> fais, string logFilePath)
        {
            try
            {
                string sn = productionInfo.Sn;
                StringBuilder sb = new StringBuilder();
                sb.Append("{\n");
                sb.AppendFormat("{0}@start\n", sn);
                sb.AppendFormat("{0}@start_time@{1}\n", sn, productionInfo.StartTime.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss"));
                sb.AppendFormat("{0}@stop_time@{1}\n", sn, productionInfo.EndTime.AddSeconds(4).ToString("yyyy-MM-dd HH:mm:ss"));
                foreach (var item in fais)
                {
                    sb.AppendFormat("{0}@pdata@{1}@{2}@{3}@{4}\n"
                        , sn
                        , item.FaiItemName
                        , item.FaiItemValue
                        , item.FaiItemLimitLower
                        , item.FaiItemLimitUpper);
                }
                switch (productionInfo.StreamLineIndex)
                {
                    case 1:
                        sb.AppendFormat("{0}@dut_pos@{1}@Left\n"
                        , sn
                        , productionInfo.FixtureID);
                        break;
                    case 2:
                        sb.AppendFormat("{0}@dut_pos@{1}@Right\n"
                        , sn
                        , productionInfo.FixtureID);
                        break;
                }
                sb.AppendFormat("{0}@log_file@smb:{1}@user@{2}\n"
                    , sn
                    , logFilePath
                    , _config.User);
                sb.AppendFormat("{0}@submit@{1}\n"
                    , sn
                    , _config.SoftwareVersion);
                sb.Append("}\n");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                log?.Invoke("转换PDCA数据失败：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 数据上传
        /// </summary>
        /// <param name="UploadContent"></param>
        /// <returns></returns>
        public bool UpData(ProductionInfo productionInfo, List<FaiItem> fais, string logFilePath, CancellationToken token)
        {
            try
            {
                if (!File.Exists(logFilePath))
                {
                    log?.Invoke("PDCA上传失败未找到文件:" + logFilePath);
                    return false;
                }
                lock (locker)
                {
                    Delay _delay = new Delay();
                    _delay.SetStartTime();

                    string sendData = ConvertToPDCAdata(productionInfo, fais, logFilePath);
                    if (string.IsNullOrWhiteSpace(sendData))
                    {
                        log?.Invoke("PDCA上传失败转换发送数据失败");
                        return false;
                    }
                    receivedBuffer = "";
                    flag_UpDataSuccess = false;
                    flag_CallBackComplete = false;

                    log?.Invoke("PDCA上传:" + sendData);
                    _client.SendInfo("", sendData);

                    while (!token.IsCancellationRequested)
                    {
                        if (flag_CallBackComplete)
                        {
                            log?.Invoke("PDCA上传反馈：" + flag_UpDataSuccess);
                            if(!flag_UpDataSuccess)
                            {
                                _errorMesssage = receivedBuffer;
                            }
                            return flag_UpDataSuccess;
                        }
                        else if (_delay.TimeIsUp(_config.TimeOut))
                        {
                            //断开重新连接
                            ((IPrim)_client).IPrimStop();
                            Thread.Sleep(2000);
                            ((IPrim)_client).IPrimTaskInit();
                            _client.ClearEventOnMsgReved(); //清除订阅
                            _client.OnMsgReved += _client_OnMsgReved;//订阅

                            log?.Invoke("PDCA上传失败：PDCA反馈超时");
                            return false;
                        }
                        Thread.Sleep(10);
                    }

                    log?.Invoke("PDCA上传失败:外部取消等待反馈信息");
                    return false;
                }
            }
            catch (Exception ex)
            {
                log?.Invoke("PDCA上传失败:" + ex.Message);
                return false;
            }
        }
    }

    internal class Delay
    {
        private int _startTime = 0;

        [DllImport("kernel32.dll")]
        public static extern int GetTickCount();

        public Delay()
        {
            _startTime = GetTickCount();
        }

        public void SetStartTime()
        {
            _startTime = GetTickCount();
        }

        public int GetTimeCount()
        {
            return GetTickCount() - _startTime;
        }

        public bool TimeIsUp(int delayTime)
        {
            if (GetTickCount() - _startTime > delayTime)
            {
                return true;
            }
            return false;
        }
    }


    public class PDCAconfig
    {
        public string IP { get; set; }
        public string Port { get; set; }

        public string User { get; set; } = "1";

        public string SoftwareVersion { get; set; } = "v1";

        public int TimeOut { get; set; } = 8000;

        public string Local_IP { get; set; }
    }
}
