using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Common;
using Lead.CPrim.ProxyTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lead.CPrim.ProxyTools.Win32;
using Sunny.UI.Win32;

namespace ThreadSafty_StreamlineControl
{
    public class Traceability : ImesFuction
    {
        private TraceabilityConfig _config;
        private JsonSerializerSettings sf = new JsonSerializerSettings();
        private string _errorMesssage;
        public event Action<string> log;
        public event Action<string> mesLog;


        public Traceability(TraceabilityConfig config)
        {
            this._config = config;
            sf.Formatting = Formatting.None;
        }

        private TraceabilityBackData CheckMesBackData(string receiveData)
        {
            TraceabilityBackData mes_backData = JsonConvert.DeserializeObject<TraceabilityBackData>(receiveData);
            if (mes_backData == null)
            {
                throw new Exception($"转换失败:{receiveData}");
            }
            if (!mes_backData.Result)
            {
                throw new Exception($"反馈失败:{receiveData}");
            }
            return mes_backData;
        }

        public string GetUserLevel_withBadgeID(string id, int tryCount = 3)
        {
            return GetUserLevel_withBadgeID(id, tryCount, false);
        }

        public string GetUserLevel_withBadgeID(string id, int tryCount = 3, bool isJX = false)
        {
            string funcName = "[获取登录权限]";
            var obj = new
            {
                empNo = "",
                _config.terminalName,
                serial_Number = id,
                machine = "",
                toolingNo = "",
                lotNo = "",
                kpsn = "",
                workOrder = "",
                cavity = "",
                testData = "",
                results = "",
                status = "",
                pCmd = isJX ? "GET_OPA_ACCESS" : "GET_OP_ACCESS",
                defectCode = "",
            };

            try
            {
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_GetUserLevel}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetUserLevel);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);

                    //log
                    return mes_backData.RetMsg;
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }
            return null;
        }

        private class MES_ICT_Attribute
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public bool PutTerminalIP(string ip)
        {
            string funcName = "[上传MES本地IP]";
            var obj = new
            {
                empNo = "",
                _config.terminalName,
                serial_Number = "",
                holdMsg = "",
                clientIp = ip,
                attributeList = new List<MES_ICT_Attribute>() { new MES_ICT_Attribute { name = "", value = "" } }
            };

            try
            {
                string jsonData = JsonConvert.SerializeObject(obj, sf);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_UpMES_IP}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_UpMES_IP);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                TraceabilityBackData mes_backData = CheckMesBackData(receiveData);

                //log
                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 通过ucSN 获取 SN
        /// </summary>
        /// <param name="ucSN"></param>
        /// <returns></returns>
        public string GetSN_withUCSN(string ucSN, int tryCount = 3)
        {
            string funcName = "[获取产品SN]";
            var obj = new
            {
                empNo = _config.empNo,
                terminalName = _config.terminalName,
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
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_GetCmdResult}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetCmdResult);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }


                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);
                    if (!mes_backData.RetMsg.Contains("SN="))
                    {
                        throw new Exception($"反馈失败:不包含\"SN=\":{receiveData}");
                    }


                    //log
                    return mes_backData.RetMsg.Replace("SN=", "").Trim();
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return null;
        }

        /// <summary>
        /// 验证sn是否可以过站
        /// </summary>
        /// <param name="sN"></param>
        /// <returns></returns>
        public bool CheckSN_withSN(string sN, string lotNoSN = "", int tryCount = 3)
        {
            string funcName = "[检查过站信息]";
            var obj = new
            {
                empNo = _config.empNo,
                terminalName = _config.terminalName,
                serial_Number = sN,
                machine = "",
                toolingNo = "",
                lotNo = lotNoSN,
                kpsn = "",
                reelNo = "",
                workOrder = "",
            };

            try
            {
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_AssyCheck}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AssyCheck);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    
                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);
                    if (mes_backData.RetMsg != sN)
                    {
                        throw new Exception($"反馈失败:UCSN不同[{mes_backData.RetMsg}]");
                    }

                    
                    //log
                    return true;
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return false;
        }


        public bool GetSnPartType_withSN(string sN, out string sNPartType, int tryCount = 3)
        {
            string funcName = "[获取产品类型]";
            sNPartType = null;

            var obj = new
            {
                empNo = "",
                terminalName = "",
                serial_Number = sN,
                machine = "",
                toolingNo = "",
                lotNo = "",
                kpsn = "",
                workOrder = "",
                cavity = "",
                testData = "",
                results = "",
                status = "",
                pCmd = "GET_SN_PART_TYPE",
                defectCode = "",
            };

            try
            {
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_GetCmdResult}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetCmdResult);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);
                    if (!mes_backData.RetMsg.Contains("PART_TYPE="))
                    {
                        throw new Exception($"反馈失败:[{mes_backData.RetMsg}]不包含[PART_TYPE=]");
                    }

                    int index = mes_backData.RetMsg.IndexOf("PART_TYPE=");
                    sNPartType = mes_backData.RetMsg.Substring(index + 10);
                    log?.Invoke($"{funcName}反馈成功:[{sNPartType}]");
                    //log
                    return true;
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return false;
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="productionInfo"></param>
        /// <param name="fais"></param>
        /// <returns></returns>
        public bool UpData(ProductionInfo productionInfo, List<FaiItem> fais,string lotNo = "", bool checkOK = true, int tryCount = 3)
        {
            string funcName = "[上传数据]";
            bool itemResult = false;
            bool totalResult = productionInfo.Result == "OK";
            StringBuilder Results = new StringBuilder(10240);
            foreach (var item in fais)
            {
                itemResult = (item.FaiItemLimitLower <= item.FaiItemValue) && (item.FaiItemValue <= item.FaiItemLimitUpper);
                totalResult = totalResult && itemResult;
                string fai_limit_lower = item.FaiItemLimitLower < -900 ? "" : item.FaiItemLimitLower.ToString();
                string fai_limit_upper = item.FaiItemLimitUpper > 900 ? "" : item.FaiItemLimitUpper.ToString();
                Results.AppendFormat("lower_limit={0}$parametric_key=$priority=$result={1}$sub_sub_test=$sub_test=$test={2}$units={3}$upper_limit={4}$value={5}$Message=,"
                          , fai_limit_lower
                          , itemResult == true ? "PASS" : "FAIL"
                          , item.FaiItemName
                          , item.FaiItemUnit
                          , fai_limit_upper
                          , item.FaiItemValue);
            }


            string Testdata = string.Format("test_result={0}$unit_sn={1}$uut_start={2}$uut_stop={3}$limits_version={4}$software_name={5}$software_version={6}$station_id={7}$fixture_id={8}"
                                                      , totalResult == true ? "PASS" : "FAIL"
                                                      , productionInfo.Sn
                                                      , productionInfo.StartTime.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss")//ICT DFX 2023-08-26 要求Hive MES PDCA 时间不同
                                                      , productionInfo.EndTime.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss")
                                                      , _config.Limits_version
                                                      , _config.SoftwareName
                                                      , _config.Software_version
                                                      , _config.terminalName
                                                      , productionInfo.FixtureID);

            var obj = new
            {
                empNo = _config.empNo,
                terminalName = _config.terminalName,
                serial_Number = productionInfo.Sn,
                machine = "",
                toolingNo = productionInfo.FixtureID,
                lotNo = lotNo,
                kpsn = "",
                workOrder = "",
                cavity = "",
                testData = Testdata,
                results = Results.ToString().TrimEnd(',', ' '),
                collectType = "REC",
            };

            try
            {
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_CollectTestData}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_CollectTestData);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);
                    if (mes_backData.RetMsg != "OK" && checkOK)
                    {
                        throw new Exception($"反馈失败:RetMsg不等于OK:[{mes_backData.RetMsg}]");
                    }


                    return true;
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return false;
        }


        public bool UpFile(string sn, FileInfo imageFileInfo)
        {
            string funcName = "[上传图片]";
            try
            {
                byte[] datas = File.ReadAllBytes(imageFileInfo.FullName);

                var obj = new
                {
                    terminal_Name = _config.terminalName,
                    serial_Number = sn,
                    fileName = imageFileInfo.Name,
                    equipmentName = _config.LocalStationName,
                    bytes = datas
                };

                string jsonData = JsonConvert.SerializeObject(obj);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_UploadFile}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_UploadFile);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                TraceabilityBackData mes_backData = CheckMesBackData(receiveData);

                return true;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Pass过站
        /// </summary>
        /// <param name="productionInfo"></param>
        /// <returns></returns>
        public bool GoPass(string ucSN, string sN, string lotNoSN = "", int tryCount = 3)
        {
            string funcName = "[上传过站信息]";
            var obj = new
            {
                empNo = _config.empNo,
                terminalName = _config.terminalName,
                serial_Number = sN,
                machine = _config.machine,
                toolingNo = ucSN,
                lotNo = lotNoSN,
                kpsn = "",
                reelNo = "",
                workOrder = "",
            };

            try
            {
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_AssyGo}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AssyGo);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);
                    if (mes_backData.RetMsg.Contains(_config.NextStationName))
                    {
                        throw new Exception($"反馈失败:SN不同[{mes_backData.RetMsg}]");
                    }

                    //log
                    return true;
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return false;
        }



        public bool Updata_DefectCode_withSN(string sN,string defectCode, int tryCount = 3)
        {
            string funcName = "[上传不良代码]";

            var obj = new
            {
                empNo = _config.empNo,
                terminalName = _config.terminalName,
                serial_Number = sN,
                machine = "",
                toolingNo = "",
                kpsn = "",
                workOrder = "",
                cavity = "",
                testData = "",
                results = "",
                status = "",
                pCmd = "U_SN_DEFECT_BY_ASSYSN",
                defectCode = defectCode,
            };

            try
            {
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_GetCmdResult}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetCmdResult);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);

                    //log
                    return mes_backData.Result;
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return false;
        }

        public string GetLotNoCount_withLotNOSN(string lotNoSN, int tryCount = 3)
        {
            string funcName = "[获取料盘剩余数量]";
            var obj = new
            {
                empNo = "",
                terminalName = "",
                serial_Number = lotNoSN,
                machine = "",
                toolingNo = "",
                lotNo = "",
                kpsn = "",
                workOrder = "",
                cavity = "",
                testData = "",
                results = "",
                status = "",
                pCmd = "GET_LOTNO_COUNT",
                defectCode = "",
            };

            try
            {
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_GetCmdResult}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetCmdResult);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }


                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);
                    //log
                    return mes_backData.RetMsg.Trim();
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return null;
        }

        public bool UpCollMachineUnitSn(ProductionInfo productionInfo, List<int> tossingNums, List<string> tossingNames, int hiveState, int tryCount = 3)
        {
            string funcName = "[上传抛料信息]";

            try
            {
                int num1 = tossingNums.Count;
                int num2 = tossingNames.Count;
                var obj = new
                {
                    data = new
                    {
                        sw_Version = _config.Software_version,
                        hive_State = hiveState,
                        outPut_Ct = Math.Round(productionInfo.Output_CT, 2),
                        //tossing_1 = productionInfo.SlotInfosList[0].TossingAccessaryInfos.Count,
                        tossing_1 = num1 > 0 ? tossingNums[0] : 0,
                        tossing_2 = num1 > 1 ? tossingNums[1] : 0,
                        tossing_3 = num1 > 2 ? tossingNums[2] : 0,
                        tossing_4 = num1 > 3 ? tossingNums[3] : 0,
                        tossing_5 = num1 > 4 ? tossingNums[4] : 0,
                        tossing_6 = num1 > 5 ? tossingNums[5] : 0,
                        tossing_desc1 = num2 > 0 ? tossingNames[0] : "",
                        tossing_desc2 = num2 > 1 ? tossingNames[1] : "",
                        tossing_desc3 = num2 > 2 ? tossingNames[2] : "",
                        tossing_desc4 = num2 > 3 ? tossingNames[3] : "",
                        tossing_desc5 = num2 > 4 ? tossingNames[4] : "",
                        tossing_desc6 = num2 > 5 ? tossingNames[5] : "",
                        limits_Version = _config.Limits_version
                    },
                    terminal_name = _config.terminalName,
                    unit_Sn = productionInfo.Sn,
                    serials = new
                    {
                        sub_id = "",
                        error_Message = "",
                        error_Detail = ""
                    },
                    pass = productionInfo.Result == "OK" ? "True" : "False",
                    input_time = productionInfo.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), //StartTime 
                    output_time = productionInfo.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),//Endtime
                };

                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    //log
                    log?.Invoke($"{funcName}上传:{_config.Url_UpCollMachineUnitSn}:{jsonData}");


                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_UpCollMachineUnitSn);
                    //log
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);

                    //log
                    return true;
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return false;
        }

        public string MaintenceMesUpload(string userId, string project, string line, string headId, string item, string maxTime, string alertTime, bool isAdd)
        {
            string funcName = "[上传点检信息]";

            var obj = new
            {
                empNo = userId,
                _config.terminalName,
                serial_Number = string.Format("{0}_{1}", headId, item),
                machine = string.Empty,
                toolingNo = string.Empty,
                lotNo = string.Empty,
                kpsn = string.Empty,
                workOrder = string.Empty,
                cavity = string.Empty,
                testData = string.Format("MACHINE_CODE={0}_{1}$PROCESS={2}$ENABLE={3}$VALUE={4}$MAX_TIME={5}$ALERT_TIME={6}",
                                         project, line, _config.LocalStationName,
                                         isAdd == true ? "Y" : "N",
                                         userId,
                                         maxTime, alertTime),
                results = string.Empty,
                status = string.Empty,
                pCmd = "EQUIPMENT_MT",
                defectCode = "",
            };

            try
            {
                string jsonData = JsonConvert.SerializeObject(obj, sf);
                log?.Invoke($"{funcName}上传:{_config.Url_GetCmdResult}:{jsonData}");

                
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetCmdResult);
                log?.Invoke($"{funcName}反馈:{receiveData}");
                return receiveData.Trim();
            }
            catch (Exception ex)
            {
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return string.Empty;
        }

        public string HashKeyMesUpload(string id, string project, string result)
        {
            string funcName = "[上传Hash信息]";

            var obj = new
            {
                empNo = string.Empty,
                _config.terminalName,
                serial_Number = "SN",
                machine = string.Empty,
                toolingNo = string.Empty,
                lotNo = string.Empty,
                kpsn = string.Empty,
                workOrder = string.Empty,
                cavity = string.Empty,
                testData = string.Format("site=ITKS$project={0}$approver_id={1}",
                                         project,
                                         id),
                results = result,
                status = string.Empty,
                pCmd = "SAVE_AUDIO_INFO",
                defectCode = "",
            };

            try
            {
                string jsonData = JsonConvert.SerializeObject(obj, sf);
                log?.Invoke($"{funcName}上传:{_config.Url_GetCmdResult}:{jsonData}");
                
                
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetCmdResult);
                log?.Invoke($"{funcName}反馈:{receiveData}");
                return receiveData.Trim();
            }
            catch (Exception ex)
            {
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return string.Empty;
        }

        public bool HashKeyMesCheck(string result, ref string msg, int tryCount = 3)
        {
            string funcName = "[检查Hash信息]";

            var obj = new
            {
                empNo = string.Empty,
                _config.terminalName,
                serial_Number = "SN",
                machine = string.Empty,
                toolingNo = string.Empty,
                lotNo = string.Empty,
                kpsn = string.Empty,
                workOrder = string.Empty,
                cavity = string.Empty,
                testData = string.Empty,
                results = result,
                status = string.Empty,
                pCmd = "CHECK_AUDIO_INFO",
                defectCode = "",
            };

            try
            {
                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    log?.Invoke($"{funcName}上传:{_config.Url_GetCmdResult}:{jsonData}");
                    
                    
                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetCmdResult);
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);

                    return true;
                }
            }
            catch (Exception ex)
            {
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return false;
        }

        public bool UpCollMachineState(MachineStateConfig machineStateConfig, DateTime changeTime, string hashKey, int tryCount = 3)
        {
            string funcName = "[上传HIVE状态]";

            try
            {
                var obj = new
                {
                    uniqueID = machineStateConfig.uniqueID,
                    terminal_Name = _config.terminalName,
                    machine_Name = machineStateConfig.machine_Name,
                    machine_State = machineStateConfig.machine_State,
                    state_Change_Time = changeTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    message = machineStateConfig.message,
                    code = machineStateConfig.code,
                    serverity = machineStateConfig.serverity,
                    occurrence_Time = machineStateConfig.occurrence_Time,
                    resolved_Time = machineStateConfig.resolved_Time,
                    vendor = machineStateConfig.vendor,
                    uid = machineStateConfig.uid,
                    pdline_name = machineStateConfig.pdline_name,
                    data = new
                    {
                        sW_Version = _config.Software_version,
                        code = machineStateConfig.code,
                        error_Detail = machineStateConfig.detail,
                        hashKey = string.Empty,
                        sequence = machineStateConfig.sequence.ToString(),
                    }
                };

                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    jsonData = jsonData.Replace("\"hashKey\":\"\",", hashKey);
                    log?.Invoke($"{funcName}上传:{_config.Url_UpCollMachineState}:{jsonData}");

                    
                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_UpCollMachineState);
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);

                    return true;
                }
            }
            catch (Exception ex)
            {
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }

            return false;
        }

        /// <summary>
        /// 获取已过站次数
        /// </summary>
        /// <param name="sN"></param>
        /// <returns></returns>
        public int GetRECQTY(string sN, int tryCount = 3)
        {
            string funcName = "[获取已过站次数]";

            try
            {
                var obj = new
                {
                    empNo = "",
                    terminalName = _config.terminalName,
                    serial_Number = sN,
                    machine = "",
                    toolingNo = "",
                    lotNo = "",
                    kpsn = "",
                    workOrder = "",
                    cavity = "",
                    testData = "",
                    results = "",
                    status = "",
                    pCmd = "G_PROCESS_RECQTY_BY_ASSYSN",
                    defectCode = "",
                };

                for (int i = 0; i < tryCount; i++)
                {
                    string jsonData = JsonConvert.SerializeObject(obj, sf);
                    log?.Invoke($"{funcName}上传:{_config.Url_GetCmdResult}:{jsonData}");

                    string receiveData = HttpClients.HttpPost(jsonData, _config.Url_GetCmdResult);
                    log?.Invoke($"{funcName}反馈:{receiveData}");
                    if (receiveData.Contains("操作超时"))
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    TraceabilityBackData mes_backData = CheckMesBackData(receiveData);
                    if (!mes_backData.RetMsg.Contains("G_PROCESS_RECQTY_BY_ASSYSN="))
                    {
                        //log
                        log?.Invoke($"{funcName}反馈失败:[{mes_backData.RetMsg}]不包含[G_PROCESS_RECQTY_BY_ASSYSN=]");
                        return -1;
                    }
                    string[] tmp = mes_backData.RetMsg.Split('=');
                    return Convert.ToInt16(tmp[1]);
                }
            }
            catch (Exception ex)
            {
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
            }
            return -1;
        }
    }

    public class TraceabilityConfig
    {
        [DisplayName("作业员工号")]
        public string empNo { get; set; } = "";

        [DisplayName("线体")]
        public string Line { get; set; } = "";

        [DisplayName("工作站名称")]
        public string terminalName { get; set; } = "ITKS_EXX-3FT-MES-XXX";

        [DisplayName("软件名称")]
        public string SoftwareName { get; set; } = "";
        [DisplayName("软件版本")]
        public string Software_version { get; set; } = "V1.4";
        [DisplayName("Limit版本")]
        public string Limits_version { get; set; } = "V1.0";
        [DisplayName("下站名称")]
        public string NextStationName { get; set; } = "";

        [DisplayName("本站名称")]
        public string LocalStationName { get; set; } = "";

        [DisplayName("机台号")]
        public string machine { get; set; } = "";

        public string Url_AssyCheck = "http://10.33.30.55:8080/api/Assy/AssyCheck";
        public string Url_AssyGo = "http://10.33.30.55:8080/api/Assy/AssyGo";
        public string Url_GetCmdResult = "http://10.33.30.55:8080/api/Assy/GetCmdResult";
        public string Url_CollectTestData = "http://10.33.30.55:8080/api/Assy/CollectTestData";
        public string Url_GetUserLevel = "http://10.33.30.55:8080/api/Assy/GetCmdResult";

        public string Url_UploadFile = "http://10.171.30.102/api/File/UploadFile";

        public string Url_UpMES_IP = "http://10.103.10.199/api/common/putterminalip";
        public string Url_UpCollMachineUnitSn = "http://10.103.10.199/api/Machine/CollMachineUnitSn";
        public string Url_UpCollMachineState = "http://10.103.10.199/api/Machine/collmachinestatefromcard";
    }

    public class MachineStateConfig
    {
        /// <summary>
        /// 请求唯⼀编号(制程_时间戳)
        /// </summary>
        public string uniqueID { get; set; } = "";
        /// <summary>
        /// 工作站名称
        /// </summary>
        public string terminal_Name { get; set; } = "ITKS_EXX-3FT-MES-XXX";
        /// <summary>
        /// 制程站ID
        /// </summary>
        public string machine_Name { get; set; } = "P-180";
        /// <summary>
        /// HIVE状态(1, 2, 3, 4, 5)
        /// </summary>
        public string machine_State { get; set; } = "1";
        /// <summary>
        /// HIVE 状态改变时间
        /// </summary>
        public string state_Change_Time { get; set; } = "2024-4-23 08:30:00";
        /// <summary>
        /// 只有在HIVE的状态由Planned downtime或Downtime改变⾄Running时，才需要上传错误消息
        /// </summary>
        public string message { get; set; } = "";
        /// <summary>
        /// 只有在HIVE的状态由Planned downtime或Downtime改变⾄Running时，才需要上传错误消息
        /// </summary>
        public string detail { get; set; } = "";
        /// <summary>
        /// 只有在HIVE的状态由Planned downtime或Downtime改变⾄Running时，才需要上传错误代码
        /// </summary>
        public string code { get; set; } = "F-0010";
        /// <summary>
        /// 从“警告” /“错误” /“关键”中选择
        /// 只有在HIVE的状态由Planned downtime或Downtime改变⾄Running时才需要上传
        /// </summary>
        public string serverity { get; set; } = "F-0010";
        /// <summary>
        /// 机器宕机的开始时间
        /// 只有在HIVE的状态由Planned downtime或Downtime改变⾄Running时才需要上传
        /// </summary>
        public string occurrence_Time { get; set; } = "2024-4-23 08:30:00";
        /// <summary>
        /// 机器宕机的结束时间
        /// 只有在HIVE的状态由Planned downtime或Downtime改变⾄Running时才需要上传
        /// </summary>
        public string resolved_Time { get; set; } = "2024-4-23 08:30:00";
        /// <summary>
        /// 供应商英⽂名称 (全⼤写字⺟)
        /// </summary>
        public string vendor { get; set; } = "";
        /// <summary>
        /// 仅在⼿动改变HIVE状态时赋值，⾃动切换状态禁⽌赋值
        /// </summary>
        public string uid { get; set; } = "";
        /// <summary>
        /// CM 线体编码(简码)
        /// </summary>
        public string pdline_name { get; set; } = "";

        /// <summary>
        /// 主软件版本
        /// </summary>
        public string sW_Version { get; set; } = "";

        public short sequence { get; set; } = 1;
    }

    internal class TraceabilityBackData
    {
        public bool Result { get; set; }
        public string RetMsg { get; set; }
    }
}
