using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    public class Traceability
    {
        private TraceabilityConfig _config;
        private JsonSerializerSettings sf = new JsonSerializerSettings();
        public event Action<string> log;



        public Traceability(TraceabilityConfig config)
        {
            this._config = config;
            sf.Formatting = Formatting.None;
        }

        public string GetSN_withUCSN(string ucSN)
        {
            string jsonData = string.Empty;
            var obj = new
            {
                empNo = "",
                terminalName = "",
                serial_Number = ucSN,
                machine = "",
                toolingNo = "",
                lotNo = "",
                kpsn = "",
                workOrder = "",
                cavity = "",
                testData = "",
                results = "",
                status = "",
                pCmd = "RFID_GET_SN",
                defectCode = "",
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sf);
                //log
                log?.Invoke($"ucSN[{ucSN}],GETSN上传:{jsonData}");
                string receiveData = HttpClient.HttpPost(jsonData, _config.Uri_AssyCheck);
                //log
                log?.Invoke($"ucSN[{ucSN}],GETSN反馈:{jsonData}");
                var sn = JsonConvert.DeserializeObject<TraceabilityBackData>(receiveData);
                if (sn == null)
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],GETSN转换失败");
                    return null;
                }
                if (!sn.Result)
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],GETSN反馈失败:{sn.RetMsg}");
                    return null;
                }
                if (!sn.RetMsg.Contains("SN="))
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],GETSN反馈失败:不包含\"SN=\"");
                    return null;
                }
                //log
                return sn.RetMsg.Replace("SN=", "").Trim();
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"ucSN[{ucSN}],GETSN异常:{ex.Message}");
                return null;
            }
        }

        public bool CheckUCSN_withUCSN(string ucSN)
        {
            string jsonData = string.Empty;
            var obj = new
            {
                empNo = _config.empNo,
                terminalName = _config.terminalName,
                serial_Number = ucSN,
                machine = "",
                toolingNo = "",
                lotNo = _config.lotNo,
                kpsn = "",
                reelNo = "",
                workOrder = "",
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sf);
                //log
                log?.Invoke($"ucSN[{ucSN}],CheckUCSN上传:{jsonData}");
                string receiveData = HttpClient.HttpPost(jsonData, _config.Uri_AssyCheck);
                //log
                log?.Invoke($"ucSN[{ucSN}],CheckUCSN反馈:{jsonData}");
                var sn = JsonConvert.DeserializeObject<TraceabilityBackData>(receiveData);
                if (sn == null)
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],CheckUCSN转换失败");
                    return false;
                }
                if (!sn.Result)
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],CheckUCSN反馈失败:{sn.RetMsg}");
                    return false;
                }
                if (sn.RetMsg != ucSN)
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],CheckUCSN反馈失败:UCSN不同[{sn.RetMsg}]");
                    return false;
                }
                //log
                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"ucSN[{ucSN}],CheckUCSN异常:{ex.Message}");
                return false;
            }

        }

        public bool UpData(ProductionInfo productionInfo)
        {
            /*
            string jsonData = string.Empty;
            string Testdata = string.Format("test_result={0}$unit_sn={1}$uut_start={2}$uut_stop={3}$limits_version={4}$software_name={5}$software_version={6}$station_id={7}$fixture_id={8}",
                                                      result, sn, HandleTime(startTime), HandleTime(endTime), "V1.0", softWareData.SoftWareName, "V1.4", TerminalName, ucSn);
            string Limit = string.Format("lower_limit={0}$parametric_key=$priority=$result=PASS$sub_sub_test=$sub_test=$test={1}$units={2}$upper_limit={3}$value={4}$Message=",
                                          LimitLower, LimitName, LimitUnit, LimitUpper, torqueValue);
            string Results = Limit;
            var objMesData = new
            {
                empNo = EmpNo,
                terminalName = TerminalName,
                serial_Number = sn,
                machine = "",
                toolingNo = ucSn,
                lotNo = lotNO,
                kpsn = "",
                workOrder = "",
                cavity = convey.ToString(),
                testData = Testdata,
                results = Results,
                collectType = "REC",
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sf);
                //log
                log?.Invoke($"ucSN[{ucSN}],CheckUCSN上传:{jsonData}");
                string receiveData = HttpClient.HttpPost(jsonData, _config.Uri_AssyCheck);
                //log
                log?.Invoke($"ucSN[{ucSN}],CheckUCSN反馈:{jsonData}");
                var sn = JsonConvert.DeserializeObject<TraceabilityBackData>(receiveData);
                if (sn == null)
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],CheckUCSN转换失败");
                    return false;
                }
                if (!sn.Result)
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],CheckUCSN反馈失败:{sn.RetMsg}");
                    return false;
                }
                if (sn.RetMsg != ucSN)
                {
                    //log
                    log?.Invoke($"ucSN[{ucSN}],CheckUCSN反馈失败:UCSN不同[{sn.RetMsg}]");
                    return false;
                }
                //log
                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"ucSN[{ucSN}],CheckUCSN异常:{ex.Message}");
                return false;
            }
            */
            return false;
        }
    }
    public class TraceabilityConfig
    {
        [DisplayName("作业员工号")]
        public string empNo { get; set; } = "";

        [DisplayName("工作站名称")]
        public string terminalName { get; set; } = "ITKS_EXX-3FT-MES-XXX";

        [DisplayName("产品序号")]
        public string serial_Number { get; set; } = "KSH37FATPP10393";

        [DisplayName("机台号")]
        public string machine { get; set; } = "";
        [DisplayName("治具号")]
        public string toolingNo { get; set; } = "";
        [DisplayName("批次物料")]
        public string lotNo { get; set; } = "";
        [DisplayName("材料序号")]
        public string kpsn { get; set; } = "";
        [DisplayName("工单号")]
        public string workOrder { get; set; } = "";
        [DisplayName("模穴号")]
        public string cavity { get; set; } = "";
        [DisplayName("测试站主属性参数")]
        public string testData { get; set; } = "";
        [DisplayName("测试项目信息及相对应参数值")]
        public string results { get; set; } = "";
        [DisplayName(@"传状态 OK\FAIL\START\STOP")]
        public string status { get; set; } = "";
        [DisplayName("不良代码")]
        public string defectCode { get; set; } = "";

        public string Uri_AssyCheck = "http://10.33.30.55:8080/api/Assy/AssyCheck";
        public string Uri_AssyGo = "http://10.33.30.55:8080/api/Assy/AssyGo";
        public string Uri_GetCmdResult = "http://10.33.30.55:8080/api/Assy/GetCmdResult";
        public string Uri_CollectTestData = "http://10.33.30.55:8080/api/Assy/CollectTestData";
    }

    internal class TraceabilityBackData
    {
        public bool Result { get; set; }
        public string RetMsg { get; set; }
    }
}
