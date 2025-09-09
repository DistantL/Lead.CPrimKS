using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThreadSafty_StreamlineControl
{
    public class Hive
    {
        private HiveConfig _config;
        private JsonSerializerSettings sf = new JsonSerializerSettings();
        private JsonSerializerSettings sfwithoutnull = new JsonSerializerSettings();
        private string _errorMesssage;
        public event Action<string> log;
        public string GetErrorMessage
        {
            get
            {
                return _errorMesssage;
            }
        }
        public Hive(HiveConfig config)
        {
            this._config = config;
            sf.Formatting = Formatting.None;
            sfwithoutnull = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };
        }

        public string SoftWareVersion
        {
            get
            {
                return _config.sw_version;
            }
        }
        public string LimitSoftWareVersion
        {
            get
            {
                return _config.limits_version;
            }
        }

        #region log

        public void Log_MachineState(string msg)
        {
            LogHelper.HiveLogAdd(HiveLogLevel.State, msg);
        }

        public void Log_MachineData(string msg)
        {
            LogHelper.HiveLogAdd(HiveLogLevel.Data, msg);
        }

        public void Log_ErrorData(string msg)
        {
            LogHelper.HiveLogAdd(HiveLogLevel.Error, msg);
        }

        public void Log_Remote_MachineState(string msg)
        {
            LogHelper.HiveRemoteLogAdd(HiveLogLevel.State, msg);
        }

        public void Log_Remote_MachineData(string msg)
        {
            LogHelper.HiveRemoteLogAdd(HiveLogLevel.Data, msg);
        }

        public void Log_Remote_ErrorData(string msg)
        {
            LogHelper.HiveRemoteLogAdd(HiveLogLevel.Error, msg);
        }

        #endregion

        #region MachineState

        public bool UpDataMachineState_Running(Data_Running data, DateTime changeTime, string hashKey)
        {
            string jsonData = string.Empty;
            Data_Running data_1 = new Data_Running()
            {
                previous_state = data.previous_state,
                sequence = data.sequence,
                status = data.status,
                degraded_sequence = data.degraded_sequence,
                sw_version = _config.sw_version,
                hashKey = string.Empty,
                u_id = data.u_id
            };
            var obj = new
            {
                machine_state = 1,
                state_change_time = ConvertDateTimeToString(changeTime),
                data = data_1
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sfwithoutnull);
                jsonData = jsonData.Replace("\"hashKey\":\"\",", hashKey);

                //log
                Log_Remote_MachineState(jsonData);
                if (!_config.Enable_Hive)
                {
                    log?.Invoke($"Hive未启用，Hive_MachineState_Running上传");
                    return true;
                }
                log?.Invoke($"Hive_MachineState_Running上传:{jsonData}");
                Log_MachineState($"Hive_MachineState_Running上传:\r\n{jsonData}");

                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_MachineState);
                //log
                Log_MachineState($"Hive_MachineState_Running反馈:\r\n{receiveData}");
                log?.Invoke($"Hive_MachineState_Running反馈:{receiveData}");
                //var hive_backData = JsonConvert.DeserializeObject<Hive_BackData>(receiveData);
                //if (hive_backData == null)
                {
                    //log
                    //log?.Invoke($"Hive_MachineState_Running转换失败");
                    //return false;
                }

                if (receiveData != "{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}\n")
                {
                    log?.Invoke("Hive_MachineState_Running反馈失败：不等于{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}");
                    _errorMesssage = receiveData;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"Hive_MachineState_Running异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        public bool UpDataMachineState_Idle(Data_Idle data, DateTime changeTime, string hashKey)
        {
            string jsonData = string.Empty;
            Data_Idle data_2 = new Data_Idle
            {
                previous_state = data.previous_state,
                sequence = data.sequence,
                status = data.status,
                degraded_sequence = data.degraded_sequence,
                sw_version = _config.sw_version,
                hashKey = string.Empty,
                u_id = data.u_id
            };
            var obj = new
            {
                machine_state = 2,
                state_change_time = ConvertDateTimeToString(changeTime),
                data = data_2,
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sfwithoutnull);
                jsonData = jsonData.Replace("\"hashKey\":\"\",", hashKey);

                //log
                Log_Remote_MachineState(jsonData);
                if (!_config.Enable_Hive)
                {
                    log?.Invoke($"Hive未启用，Hive_MachineState_Idle上传");
                    return true;
                }
                log?.Invoke($"Hive_MachineState_Idle上传:{jsonData}");
                Log_MachineState($"Hive_MachineState_Idle上传:\r\n{jsonData}");
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_MachineState);
                //log
                Log_MachineState($"Hive_MachineState_Idle反馈:\r\n{receiveData}");
                log?.Invoke($"Hive_MachineState_Idle反馈:{receiveData}");
                //var hive_backData = JsonConvert.DeserializeObject<Hive_BackData>(receiveData);
                //if (hive_backData == null)
                {
                    //log
                    //log?.Invoke($"Hive_MachineState_Idle转换失败");
                    //return false;
                }

                if (receiveData != "{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}\n")
                {
                    log?.Invoke("Hive_MachineState_Idle反馈失败：不等于{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}");
                    _errorMesssage = receiveData;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"Hive_MachineState_Idle异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        public bool UpDataMachineState_Engineering(Data_Engineering data, DateTime changeTime, string hashKey)
        {
            string jsonData = string.Empty;
            Data_Engineering data_3 = new Data_Engineering()
            {
                previous_state = data.previous_state,
                sequence = data.sequence,
                status = data.status,
                degraded_sequence = data.degraded_sequence,
                sw_version = _config.sw_version,
                hashKey = string.Empty,
                u_id = data.u_id
            };
            var obj = new
            {
                machine_state = 3,
                state_change_time = ConvertDateTimeToString(changeTime),
                data = data_3,
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sfwithoutnull);
                jsonData = jsonData.Replace("\"hashKey\":\"\",", hashKey);

                //log
                Log_Remote_MachineState(jsonData);
                if (!_config.Enable_Hive)
                {
                    log?.Invoke($"Hive未启用，Hive_MachineState_Engineering上传");
                    return true;
                }
                log?.Invoke($"Hive_MachineState_Engineering上传:{jsonData}");
                Log_MachineState($"Hive_MachineState_Engineering上传:\r\n{jsonData}");
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_MachineState);
                //log
                Log_MachineState($"Hive_MachineState_Engineering反馈:\r\n{receiveData}");
                log?.Invoke($"Hive_MachineState_Engineering反馈:{receiveData}");
                //var hive_backData = JsonConvert.DeserializeObject<Hive_BackData>(receiveData);
                //if (hive_backData == null)
                {
                    //log
                    //log?.Invoke($"Hive_MachineState_Engineering转换失败");
                    //return false;
                }

                if (receiveData != "{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}\n")
                {
                    log?.Invoke("Hive_MachineState_Engineering反馈失败：不等于{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}");
                    _errorMesssage = receiveData;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"Hive_MachineState_Engineering异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        public bool UpDataMachineState_PlanedDowntime(Data_PlanedDowntime data, DateTime changeTime, string hashKey)
        {
            string jsonData = string.Empty;
            Data_PlanedDowntime data_4 = new Data_PlanedDowntime()
            {
                previous_state = data.previous_state,
                sequence = data.sequence,
                status = data.status,
                degraded_sequence = data.degraded_sequence,
                sw_version = _config.sw_version,
                hashKey = string.Empty,
                error_message = data.error_message,
                error_detail = data.error_detail,
                code = data.code,
                u_id = data.u_id,
                new_sn = data.new_sn,
                old_sn = data.old_sn,
            };
            var obj = new
            {
                machine_state = 4,
                state_change_time = ConvertDateTimeToString(changeTime),
                data = data_4,
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sfwithoutnull);
                jsonData = jsonData.Replace("\"hashKey\":\"\",", hashKey);

                //log
                Log_Remote_MachineState(jsonData);
                if (!_config.Enable_Hive)
                {
                    log?.Invoke($"Hive未启用，Hive_MachineState_PlanedDowntime上传");
                    return true;
                }
                log?.Invoke($"Hive_MachineState_PlanedDowntime上传:{jsonData}");
                Log_MachineState($"Hive_MachineState_PlanedDowntime上传:\r\n{jsonData}");
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_MachineState);
                //log
                Log_MachineState($"Hive_MachineState_PlanedDowntime反馈:\r\n{receiveData}");
                log?.Invoke($"Hive_MachineState_PlanedDowntime反馈:{receiveData}");
                //var hive_backData = JsonConvert.DeserializeObject<Hive_BackData>(receiveData);
                //if (hive_backData == null)
                {
                    //log
                    //log?.Invoke($"Hive_MachineState_PlanedDowntime转换失败");
                    //return false;
                }

                if (receiveData != "{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}\n")
                {
                    log?.Invoke("Hive_MachineState_PlanedDowntime反馈失败：不等于{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}");
                    _errorMesssage = receiveData;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"Hive_MachineState_PlanedDowntime异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        public bool UpDataMachineState_Downtime(Data_Downtime data, DateTime changeTime, string hashKey)
        {
            string jsonData = string.Empty;
            Data_Downtime data_5 = new Data_Downtime()
            {
                previous_state = data.previous_state,
                sequence = data.sequence,
                status = data.status,
                degraded_sequence = data.degraded_sequence,
                sw_version = _config.sw_version,
                hashKey = string.Empty,
                error_message = data.error_message,
                error_detail = data.error_detail,
                code = data.code,
                u_id = data.u_id
            };
            var obj = new
            {
                machine_state = 5,
                state_change_time = ConvertDateTimeToString(changeTime),
                data = data_5,
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sfwithoutnull);
                jsonData = jsonData.Replace("\"hashKey\":\"\",", hashKey);

                //log
                Log_Remote_MachineState(jsonData);
                if (!_config.Enable_Hive)
                {
                    log?.Invoke($"Hive未启用，Hive_MachineState_PlanedDowntime上传");
                    return true;
                }
                log?.Invoke($"Hive_MachineState_Downtime上传:{jsonData}");
                Log_MachineState($"Hive_MachineState_Downtime上传:\r\n{jsonData}");
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_MachineState);
                //log
                Log_MachineState($"Hive_MachineState_Downtime反馈:\r\n{receiveData}");
                log?.Invoke($"Hive_MachineState_Downtime反馈:{receiveData}");
                //var hive_backData = JsonConvert.DeserializeObject<Hive_BackData>(receiveData);
                //if (hive_backData == null)
                {
                    //log
                    //log?.Invoke($"Hive_MachineState_Downtime转换失败");
                    //return false;
                }

                if (receiveData != "{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}\n")
                {
                    log?.Invoke("Hive_MachineState_Downtime反馈失败：不等于{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}");
                    _errorMesssage = receiveData;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"Hive_MachineState_Downtime异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        public class Hive_BackData
        {
            public string ErrorCode { get; set; }
            public string ErrorText { get; set; }
            public string Status { get; set; }
        }

        public class Data_Running
        {
            [JsonProperty("previous state")]
            public short previous_state { get; set; }
            public ushort sequence { get; set; }
            public string status { get; set; }
            public string degraded_sequence { get; set; }
            public string sw_version { get; set; }
            public string hashKey { get; set; }
            public string u_id { get; set; }
        }

        public class Data_Idle
        {
            [JsonProperty("previous state")]
            public short previous_state { get; set; }
            public ushort sequence { get; set; }
            public string status { get; set; }
            public string degraded_sequence { get; set; }
            public string sw_version { get; set; }
            public string hashKey { get; set; }
            public string u_id { get; set; }
        }

        public class Data_Engineering
        {
            [JsonProperty("previous state")]
            public short previous_state { get; set; }
            public ushort sequence { get; set; }
            public string status { get; set; }
            public string degraded_sequence { get; set; }
            public string sw_version { get; set; }
            public string hashKey { get; set; }
            public string u_id { get; set; }
        }

        public class Data_PlanedDowntime
        {
            [JsonProperty("previous state")]
            public short previous_state { get; set; }
            public ushort sequence { get; set; }
            public string status { get; set; }
            public string degraded_sequence { get; set; }
            public string sw_version { get; set; }
            public string hashKey { get; set; }
            public string error_message { get; set; }
            public string error_detail { get; set; }
            public string code { get; set; }
            public string u_id { get; set; }

            public string old_sn { get; set; }
            public string new_sn { get; set; }
        }


        public class Data_Downtime
        {
            [JsonProperty("previous state")]
            public short previous_state { get; set; }
            public ushort sequence { get; set; }
            public string status { get; set; }
            public string degraded_sequence { get; set; }
            public string sw_version { get; set; }
            public string hashKey { get; set; }
            public string error_message { get; set; }
            public string error_detail { get; set; }
            public string code { get; set; }
            public string u_id { get; set; }
        }

        #endregion

        #region ErrorData

        public bool UpDataErrorData(ErrorData errorData)
        {
            string jsonData = string.Empty;
            var obj = new
            {
                message = errorData.ErrorMessage,
                code = errorData.ErrorCode,
                severity = errorData.Severity,
                occurrence_time = ConvertDateTimeToString(errorData.StartTime),
                resolved_time = ConvertDateTimeToString(errorData.EndTime),
                data = new
                {
                    hive_state = errorData.HiveState,
                    error_detail = errorData.ErrorDetail,
                }
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sf);
                //log
                Log_Remote_ErrorData(jsonData);
                if (!_config.Enable_Hive)
                {
                    log?.Invoke($"Hive未启用，Hive_ErrorData上传");
                    return true;
                }

                log?.Invoke($"Hive_ErrorData上传:{jsonData}");
                Log_ErrorData($"Hive_ErrorData上传:\r\n{jsonData}");
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_ErrorData);
                //log
                Log_ErrorData($"Hive_ErrorData反馈:\r\n{receiveData}");
                log?.Invoke($"Hive_ErrorData反馈:{receiveData}");
                //var hive_backData = JsonConvert.DeserializeObject<Hive_BackData>(receiveData);
                //if (hive_backData == null)
                {
                    //log
                    //log?.Invoke($"Hive_ErrorData转换失败");
                    //return false;
                }

                if (receiveData != "{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success errordata logged\"}\n")
                {
                    log?.Invoke("Hive_ErrorData反馈失败：不等于{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinestate logged\"}");
                    _errorMesssage = receiveData;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"Hive_ErrorData异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        #endregion

        #region MachineData

        public bool UpDataMachineData(ProductionInfo productionInfo
            , Dictionary<string, object> dic_serials
            , Dictionary<string, object> dic_datas
            , List<FaiItem> fais)
        {
            string jsonData = string.Empty;
            //dynamic _data = new ExpandoObject();
            dynamic _limit = new ExpandoObject();
            var dic_limit = (IDictionary<string, object>)_limit;

            foreach (var item in fais)
            {
                if (item.FaiItemName == "ver_dig")
                {
                    dic_limit.Add(item.FaiItemName, new { upper_limit = item.FaiItemLimitUpper, lower_limit = item.FaiItemLimitLower });
                    continue;
                }
                if (string.IsNullOrEmpty(item.DataType))
                {
                    item.DataType = "";
                }
                switch (item.DataType)
                {
                    case "Int":
                        {
                            if (dic_datas.ContainsKey(item.FaiItemName))
                            {
                                dic_datas[item.FaiItemName] = (int)dic_datas[item.FaiItemName];
                            }
                            if (item.FaiItemLimitLower < -900 && item.FaiItemLimitUpper < 900)
                            {
                                dic_limit.Add(item.FaiItemName, new { upper_limit = (int)item.FaiItemLimitUpper });
                            }
                            else if (item.FaiItemLimitLower > -900 && item.FaiItemLimitUpper > 900)
                            {
                                dic_limit.Add(item.FaiItemName, new { lower_limit = (int)item.FaiItemLimitLower });
                            }
                            else if (item.FaiItemLimitLower > -900 && item.FaiItemLimitUpper < 900)
                            {
                                dic_limit.Add(item.FaiItemName, new { upper_limit = (int)item.FaiItemLimitUpper, lower_limit = (int)item.FaiItemLimitLower });
                            }
                        }
                        break;
                    default:
                        if (item.FaiItemLimitLower < -900 && item.FaiItemLimitUpper < 900)
                        {
                            dic_limit.Add(item.FaiItemName, new { upper_limit = item.FaiItemLimitUpper });
                        }
                        else if (item.FaiItemLimitLower > -900 && item.FaiItemLimitUpper > 900)
                        {
                            dic_limit.Add(item.FaiItemName, new { lower_limit = item.FaiItemLimitLower });
                        }
                        else if (item.FaiItemLimitLower > -900 && item.FaiItemLimitUpper < 900)
                        {
                            dic_limit.Add(item.FaiItemName, new { upper_limit = item.FaiItemLimitUpper, lower_limit = item.FaiItemLimitLower });
                        }
                        break;
                }
            }

            var obj = new
            {
                unit_sn = productionInfo.Sn,
                serials = dic_serials,
                pass = productionInfo.Result == "OK" ? "True" : "False",
                input_time = ConvertDateTimeToString(productionInfo.StartTime), //StartTime 
                output_time = ConvertDateTimeToString(productionInfo.EndTime),//Endtime
                //data = _data,
                data = dic_datas,
                limit = _limit,
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sf);
                //log
                Log_Remote_MachineData(jsonData);
                if (!_config.Enable_Hive)
                {
                    log?.Invoke($"Hive未启用，UpDataMachineData上传");
                    return true;
                }
                log?.Invoke($"UpDataMachineData上传:{jsonData}");
                Log_MachineData($"UpDataMachineData上传:\r\n{jsonData}");
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_MachineData);
                //log
                Log_MachineData($"UpDataMachineData反馈:\r\n{receiveData}");
                log?.Invoke($"UpDataMachineData反馈:{receiveData}");
                //var hive_backData = JsonConvert.DeserializeObject<Hive_BackData>(receiveData);
                //if (hive_backData == null)
                {
                    //log
                    //log?.Invoke($"Hive_MachineDataWithImage转换失败");
                    //return false;
                }

                if (receiveData == "{\"ErrorCode\":null,\"ErrorText\":null,\"Result\":\"PASS\",\"Status\":\"Success machinedata logged\"}"
                   || receiveData == "{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinedata logged\"}")
                {
                    return true;
                }

                log?.Invoke("UpDataMachineDataWithImage反馈失败：不等于{\"ErrorCode\":null,\"ErrorText\":null,\"Result\":\"PASS\",\"Status\":\"Success machinedata logged\"}或{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinedata logged\"}");
                _errorMesssage = receiveData;
                return false;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"UpDataMachineDataWithImage异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        public bool UpDataMachineDataWithImage(ProductionInfo productionInfo
            , Dictionary<string, object> dic_serials
            , Dictionary<string, object> dic_datas
            , List<FaiItem> fais
            , List<FileInfo> fileInfos)
        {
            string jsonData = string.Empty;
            //dynamic _data = new ExpandoObject();
            dynamic _limit = new ExpandoObject();
            var dic_limit = (IDictionary<string, object>)_limit;

            foreach (var item in fais)
            {
                if (item.FaiItemName == "ver_dig")
                {
                    dic_limit.Add(item.FaiItemName, new { upper_limit = item.FaiItemLimitUpper, lower_limit = item.FaiItemLimitLower });
                    continue;
                }
                if (string.IsNullOrEmpty(item.DataType))
                {
                    item.DataType = "";
                }
                switch (item.DataType)
                {
                    case "Int":
                        {
                            if (dic_datas.ContainsKey(item.FaiItemName))
                            {
                                dic_datas[item.FaiItemName] = Convert.ToInt32(dic_datas[item.FaiItemName].ToString());
                                //dic_datas[item.FaiItemName] = (int)dic_datas[item.FaiItemName];
                            }
                            if (item.FaiItemLimitLower < -900 && item.FaiItemLimitUpper < 900)
                            {
                                dic_limit.Add(item.FaiItemName, new { upper_limit = (int)item.FaiItemLimitUpper });
                            }
                            else if (item.FaiItemLimitLower > -900 && item.FaiItemLimitUpper > 900)
                            {
                                dic_limit.Add(item.FaiItemName, new { lower_limit = (int)item.FaiItemLimitLower });
                            }
                            else if (item.FaiItemLimitLower > -900 && item.FaiItemLimitUpper < 900)
                            {
                                dic_limit.Add(item.FaiItemName, new { upper_limit = (int)item.FaiItemLimitUpper, lower_limit = (int)item.FaiItemLimitLower });
                            }
                        }
                        break;
                    default:
                        if (item.FaiItemLimitLower < -900 && item.FaiItemLimitUpper < 900)
                        {
                            dic_limit.Add(item.FaiItemName, new { upper_limit = item.FaiItemLimitUpper });
                        }
                        else if (item.FaiItemLimitLower > -900 && item.FaiItemLimitUpper > 900)
                        {
                            dic_limit.Add(item.FaiItemName, new { lower_limit = item.FaiItemLimitLower });
                        }
                        else if (item.FaiItemLimitLower > -900 && item.FaiItemLimitUpper < 900)
                        {
                            dic_limit.Add(item.FaiItemName, new { upper_limit = item.FaiItemLimitUpper, lower_limit = item.FaiItemLimitLower });
                        }
                        break;
                }
            }

            List<filename> Blobs = new List<filename>();
            List<string> FileList = new List<string>();

            if (fileInfos != null && fileInfos.Count != 0)
            {
                foreach (var fileInfo in fileInfos)
                {
                    FileList.Add(fileInfo.FullName);
                    Blobs.Add(new filename() { file_name = fileInfo.Name });
                }
            }

            var obj = new
            {
                unit_sn = productionInfo.Sn,
                serials = dic_serials,
                pass = productionInfo.Result == "OK" ? "True" : "False",
                input_time = ConvertDateTimeToString(productionInfo.StartTime), //StartTime 
                output_time = ConvertDateTimeToString(productionInfo.EndTime),//Endtime
                //data = _data,
                data = dic_datas,
                limit = _limit,
                blobs = Blobs,
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, sf);
                //log
                Log_Remote_MachineData(jsonData);
                if (!_config.Enable_Hive)
                {
                    log?.Invoke($"Hive未启用，UpDataMachineDataWithImage上传");
                    return true;
                }
                log?.Invoke($"UpDataMachineDataWithImage上传:{jsonData}");
                Log_MachineData($"UpDataMachineDataWithImage上传:\r\n{jsonData}");
                string receiveData = HttpClients.HttpPostMultipartData(jsonData, FileList, _config.Url_MachineData);
                //log
                Log_MachineData($"UpDataMachineDataWithImage反馈:\r\n{receiveData}");
                log?.Invoke($"UpDataMachineDataWithImage反馈:{receiveData}");
                //var hive_backData = JsonConvert.DeserializeObject<Hive_BackData>(receiveData);
                //if (hive_backData == null)
                {
                    //log
                    //log?.Invoke($"Hive_MachineDataWithImage转换失败");
                    //return false;
                }

                if (receiveData == "{\"ErrorCode\":null,\"ErrorText\":null,\"Result\":\"PASS\",\"Status\":\"Success machinedata logged\"}"
                   || receiveData == "{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinedata logged\"}")
                {
                    return true;
                }

                log?.Invoke("UpDataMachineDataWithImage反馈失败：不等于{\"ErrorCode\":null,\"ErrorText\":null,\"Result\":\"PASS\",\"Status\":\"Success machinedata logged\"}或{\"ErrorCode\":null,\"ErrorText\":null,\"Status\":\"Success machinedata logged\"}");
                _errorMesssage = receiveData;
                return false;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"UpDataMachineDataWithImage异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        #endregion

        public class ErrorData
        {
            public string ErrorMessage { get; set; }
            public string ErrorCode { get; set; }
            public string Severity { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public short HiveState { get; set; }
            public string ErrorDetail { get; set; }

            public string OperationID { get; set; }
        }

        private string ConvertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz").Remove(26, 1);
        }
        private class filename
        {
            public string file_name { get; set; }
        }
    }
}

public class HiveConfig
{
    public bool Enable_Hive { get; set; }
    public string sw_version { get; set; }

    public string limits_version { get; set; }
    public string MS_SHA1 { get; set; }
    public string VS_SHA1 { get; set; }

    public string Url_ErrorData = "http://10.0.0.2:5008/v5/capture/errordata";
    public string Url_MachineState = "http://10.0.0.2:5008/v5/capture/machinestate";
    public string Url_MachineData = "http://10.0.0.2:5008/v5/capture/machinedata";
}


