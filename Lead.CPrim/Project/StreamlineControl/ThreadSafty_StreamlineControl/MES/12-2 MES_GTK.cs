using Lead.CPrim.ProxyTools;
using Newtonsoft.Json;
using Sunny.UI.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ThreadSafty_StreamlineControl
{
    public class Mes_GTK : ImesFuction
    {
        private MES_Config_GTK _config;
        //private JsonSerializerSettings sf = new JsonSerializerSettings();
        public event Action<string> log;

        private static string hwd = "";
        private string _errorMesssage;

        public Mes_GTK(MES_Config_GTK config)
        {
            this._config = config;
        }
        public string GetErrorMessage
        {
            get
            {
                return _errorMesssage;
            }
        }

        private void CheckHwd()
        {
            if (string.IsNullOrWhiteSpace(hwd))
            {
                hwd = User_Login();
                if (string.IsNullOrWhiteSpace(hwd))
                {
                    throw new Exception("获取令牌失败");
                }
            }
        }

        private object CheckFristProtocol(string receiveData)
        {
            dynamic mes_backData = JsonConvert.DeserializeObject(receiveData);
            if (mes_backData == null)
            {
                throw new Exception($"转换失败:{receiveData}");
            }
            if (mes_backData.cmd == (int)eProtocolCommand.LoginFailed || mes_backData.cmd == (int)eProtocolCommand.BindFailed || mes_backData.cmd == (int)eProtocolCommand.Error)
            {
                throw new Exception($"反馈失败:{receiveData}");
            }
            return mes_backData;
        }

        private object CheckSecondaryProtocol(object receiveData)
        {
            dynamic secondaryProtocol = JsonConvert.DeserializeObject(receiveData.ToString());
            if (secondaryProtocol == null)
            {
                throw new Exception($"解析二级协议失败:{receiveData}");
            }
            return secondaryProtocol;
        }

        #region 登录模块

        /// <summary>
        /// 接口 1:用户登录
        /// </summary>
        /// <returns>HWD:返回令牌</returns>
        private string User_Login()
        {
            string funcName = "[登录模块:接口1:用户登录]";

            try
            {
                string jsonData = string.Empty;
                string indicator = null;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.UserLogin,
                    Hwd = "",
                    Indicator = indicator,
                    SerializeData = JsonConvert.SerializeObject(new { user = _config.Username, pwd = _config.Password })
                };
                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_Gate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_Gate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);


                //log
                log?.Invoke($"{funcName}反馈成功:{mes_backData.Hwd}");
                File.WriteAllText(@"D:\Config\IniConfig\HWD.txt", (string)mes_backData.Hwd);
                return mes_backData.Hwd;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return null;
            }
        }


        #endregion


        #region 自动化接口

        /// <summary>
        /// 接口1:依据载具码获得产品SN信息
        /// </summary>
        /// <returns></returns>
        public string GetSN_withUCSN(string ucSN, int tryCount = 3)
        {
            string funcName = "[自动化接口1:依据载具码获得产品SN信息]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "QUERY_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "GET_SN_BY_SN_FIXTURE",
                        OPRequestInfo = new
                        {
                            REF_VALUE = ucSN,
                            REF_TYPE = "SN_FIXTURE"
                        },
                        OPResponseInfo = new { }
                    })
                };
                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (string.IsNullOrWhiteSpace(secondaryProtocol.OPResponseInfo.SN.ToString().Trim('\"')))
                {
                    throw new Exception($"反馈二级协议失败:产品SN为空:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功:{secondaryProtocol.OPResponseInfo.SN.ToString().Trim('\"')}");
                return secondaryProtocol.OPResponseInfo.SN.ToString().Trim('\"');
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// 接口3: 依据SN检查路由，确认产品是否允许过站
        /// </summary>
        /// <returns></returns>
        public bool CheckSN_withSN(string sN, string lotNoSN = "", int tryCount = 3)
        {
            string funcName = "[自动化接口3:依据SN检查路由,确认产品是否允许过站]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "QUERY_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "UNIT_PROCESS_CHECK",
                        OPRequestInfo = new
                        {
                            SN = sN,
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功");
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
        /// 接口4:依据SN,上传设备参数信息
        /// </summary>
        /// <returns></returns>
        public bool UpData(ProductionInfo productionInfo, List<FaiItem> fais, string lotNo = "", bool checkOK = true, int tryCount = 3)
        {
            string funcName = "[自动化接口4:依据SN,上传设备参数信息]";

            try
            {
                CheckHwd();

                Dictionary<string, object> dicValue = new Dictionary<string, object>();
                foreach (var item in fais)
                {
                    dicValue.Add(item.FaiItemName, string.Format("{0}#{1}#{2}", item.FaiItemValue, item.FaiItemLimitLower, item.FaiItemLimitUpper));
                }
                dicValue.Add("SN", productionInfo.Sn);
                dicValue.Add("failure_code", "NA");
                dicValue.Add("hive_state", "1");
                dicValue.Add("mac_addr", GetIP_MAC("HIVE"));
                dicValue.Add("machine_type", "NA");
                dicValue.Add("tossing_1", productionInfo.SlotInfosList[0].TossingAccessaryInfos != null ? productionInfo.SlotInfosList[0].TossingAccessaryInfos.Count : 0);
                dicValue.Add("ver_dig", "NA");
                dicValue.Add("output_ct", "NA");
                dicValue.Add("unit_ct", "NA");

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "ADD_ATTR",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "UPLOAD_INFOS",
                        OPRequestInfo = dicValue,
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功");
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
        /// 接口5:依据SN,上传设备BOM物料数据
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="raw_sn">子物料值</param>
        /// <returns></returns>
        public bool UpBomData(string sN, string raw_sn)
        {
            string funcName = "[自动化接口5:依据SN,上传设备BOM物料数据]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "ADD_ATTR",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "ADD_BOM_DATA",
                        OPRequestInfo = new
                        {
                            SN = sN,
                            RAW_SN = raw_sn
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功");
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
        /// 接口6:依据SN,提交过站数据
        /// </summary>
        /// <returns></returns>
        public bool GoPass(string ucSN, string sN,  string lotNoSN = "", int tryCount = 3)
        {
            string funcName = "[自动化接口6:依据SN,提交过站数据]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "ADD_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "UNIT_PROCESS_COMMIT",
                        OPRequestInfo = new
                        {
                            SN = sN,
                        },
                        OPResponseInfo = new { }
                    })
                };
                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功");
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
        /// 接口6:依据SN,提交过站数据
        /// </summary>
        /// <returns></returns>
        public bool GoPassNg(string ucSN, string sN, string Nginfo = "", int tryCount = 3)
        {
            string funcName = "[自动化接口6:依据SN,提交过站数据]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "ADD_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "UNIT_PROCESS_COMMIT",
                        OPRequestInfo = new
                        {
                            MACHINE_NO = 1,
                            SN = sN,
                            result = "FAIL",
                            list_of_failing_tests = Nginfo,
                            failure_message = Nginfo
                        },
                        OPResponseInfo = new { }
                    })
                };
                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功");
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
        /// 接口11:依据SN获得当前工站工装/设备参数信息
        /// </summary>
        /// <returns></returns>
        public string GetInputData(string sN)
        {
            string funcName = "[自动化接口11:依据SN获得当前工站工装/设备参数信息]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "QUERY_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "GET_INPUT_DATA",
                        OPRequestInfo = new
                        {
                            SN = sN,
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                string strTemp = secondaryProtocol.OPResponseInfo.ToString();
                if (strTemp.Contains("NG"))
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }

                //log
                log?.Invoke($"{funcName}反馈成功:{strTemp}");
                return strTemp;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// 接口16:供应商版本上传接口
        /// </summary>
        /// <returns></returns>
        public bool Check_section_soft_version()
        {
            string funcName = "[自动化接口16:供应商版本上传接口]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "QUERY_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "CHECK_SECTION_SOFT_VERSION",
                        OPRequestInfo = new
                        {
                            SOFT_VERSION = _config.ServerVersion,
                            VENDOR_CODE = _config.VendorCode
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功");
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
        /// 接口19:依据stationCode获取stationName信息
        /// </summary>
        /// <returns></returns>
        public string GetStationNameByStationCode()
        {
            string funcName = "[自动化接口19:依据stationCode获取stationName信息]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "QUERY_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "GET_STATIONNAME_BY_STATIONCODE",
                        OPRequestInfo = new
                        {
                            STATIONCODE = _config.StationCode,
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功:{secondaryProtocol.OPResponseInfo.RetMsg}");
                return secondaryProtocol.OPResponseInfo.RetMsg;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return null;
            }
        }

        #endregion


        #region 其他

        /// <summary>
        /// 从MES获取权限级别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUserLevel_withBadgeID(string userID, int tryCount = 3)
        {
            string funcName = "[从MES获取权限级别]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "QUERY_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "GET_OP_ACCESS",
                        OPRequestInfo = new
                        {
                            empNo = "AUTOM02",
                            serial_Number = userID
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke(funcName + "上传:" + _config.Url_Gate + ":" + jsonData);


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_Gate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);


                //log
                log?.Invoke($"{funcName}反馈成功");
                return receiveData;
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// MES获取产品类型(通过MES获取产品类型，"E" 或 "M")
        /// </summary>
        /// <param name="sN"></param>
        /// <returns></returns>
        public bool GetSnPartType_withSN(string sN, out string sNPartType, int tryCount = 3)
        {
            string funcName = "[MES获取产品类型]";
            sNPartType = null;

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "QUERY_RECORD",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "GET_SN_PART_TYPE",
                        OPRequestInfo = new
                        {
                            empNo = "",
                            serial_Number = sN
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke(funcName + "上传:" + _config.Url_Gate + ":" + jsonData);


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_Gate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK" && secondaryProtocol.OPResponseInfo.RetMsg.Contains("PART_TYPE="))
                {
                    throw new Exception($"反馈NG或不包含[PART_TYPE=]:{mes_backData.SerializeData}");
                }


                sNPartType = secondaryProtocol.OPResponseInfo.RetMsg.Replace("PART_TYPE=", "").Trim();
                //log
                log?.Invoke($"{funcName}反馈成功");
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

        public string GetIP_MAC(string ip_name)
        {
            if (string.IsNullOrWhiteSpace(ip_name))
            {
                return null;
            }

            foreach (NetworkInterface element in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (element.Name == ip_name)
                {
                    return BitConverter.ToString(element.GetPhysicalAddress().GetAddressBytes()).Replace('-', ':');
                }
            }
            return null;
        }

        /// <summary>
        /// 接口23:退还子物料接口
        /// </summary>
        /// <param name="sN"></param>
        /// <returns></returns>
        public bool Input_Raw_return(string sN)
        {
            string funcName = "[退还子物料]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "Add_Record",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "INPUT_RAW_RETURN",
                        OPRequestInfo = new
                        {
                            SN = sN
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }

                //log
                log?.Invoke($"{funcName}反馈成功");
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
        /// 接口14: 提供给供应商清除临时数据的接口
        /// </summary>
        /// <param name="sN"></param>
        /// <returns></returns>
        public bool Clear_SN_tmp_data(string sN)
        {
            string funcName = "[清除临时数据]";

            try
            {
                CheckHwd();

                string jsonData = string.Empty;
                var obj = new
                {
                    cmd = (int)eProtocolCommand.NormalOperate,
                    Hwd = hwd,
                    Indicator = "Add_Attr",
                    SerializeData = JsonConvert.SerializeObject(new
                    {
                        LineCode = _config.LineCode,
                        SectionCode = _config.SectionCode,
                        StationCode = _config.StationCode,
                        OPCategory = "CLEAR_SN_TMP_DATA",
                        OPRequestInfo = new
                        {
                            SN = sN
                        },
                        OPResponseInfo = new { }
                    })
                };

                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log?.Invoke($"{funcName}上传:{_config.Url_AutoGate}:{jsonData}");


                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log?.Invoke($"{funcName}反馈:{receiveData}");


                dynamic mes_backData = CheckFristProtocol(receiveData);
                dynamic secondaryProtocol = CheckSecondaryProtocol(mes_backData.SerializeData);
                if (secondaryProtocol.OPResponseInfo.Result.ToString() != "OK")
                {
                    throw new Exception($"反馈NG:{mes_backData.SerializeData}");
                }


                //log
                log?.Invoke($"{funcName}反馈成功");
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

        public int GetRECQTY(string sN)
        {
            string funcName = "[获取回流次数]";
            CheckHwd();
            if (string.IsNullOrWhiteSpace(hwd))
            {
                //hwd = User_Login();
                if (string.IsNullOrWhiteSpace(hwd))
                {
                    //log
                    log.Invoke(funcName + "获取令牌失败");
                    return -1;
                }
            }

            string jsonData = string.Empty;
            var obj = new
            {
                cmd = (int)eProtocolCommand.NormalOperate,
                Hwd = hwd,
                Indicator = "QUERY_RECORD",
                SerializeData = JsonConvert.SerializeObject(new
                {
                    LineCode = _config.LineCode,
                    SectionCode = _config.SectionCode,
                    StationCode = _config.StationCode,
                    OPCategory = "G_PROCESS_RECQTY_BY_ASSYSN",
                    OPRequestInfo = new
                    {
                        SN = sN
                    },
                    OPResponseInfo = new { }
                })
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log.Invoke(funcName + "上传:" + _config.Url_AutoGate + ":" + jsonData);
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log.Invoke(funcName + "反馈:" + receiveData);
                Mes_BackData mes_backData = JsonConvert.DeserializeObject<Mes_BackData>(receiveData);
                if (mes_backData == null)
                {
                    //log
                    log.Invoke(funcName + "转换失败");
                    return -1;
                }
                if (mes_backData.cmd != (int)eProtocolCommand.NormalOperate)
                {
                    //log
                    log.Invoke(funcName + "反馈失败:" + mes_backData.cmd);
                    return -1;
                }

                dynamic secondaryProtocol = JsonConvert.DeserializeObject(mes_backData.SerializeData);
                if (secondaryProtocol == null)
                {
                    //log
                    log.Invoke(funcName + "解析二级协议失败");
                    return -1;
                }
                if (secondaryProtocol.OPResponseInfo.Result != "OK")
                {
                    //log
                    log.Invoke(funcName + "反馈NG");
                    return -1;
                }

                //log
                log.Invoke(funcName + "反馈成功");
                return Convert.ToInt16(secondaryProtocol.OPResponseInfo.RetMsg);
            }
            catch (Exception ex)
            {
                //log
                log.Invoke(funcName + "异常:" + ex.Message + ":" + ex.StackTrace);
                return -1;
            }
        }

        public bool DT_Report_Upload(int errorCategory, string errorMessage, string errorCode, string errorDetail, string cardid)
        {
            string funcName = "[DT设备异常信息上传]";
            CheckHwd();
            if (string.IsNullOrWhiteSpace(hwd))
            {
                //hwd = User_Login();
               
                if (string.IsNullOrWhiteSpace(hwd))
                {
                    //log
                    log.Invoke(funcName + "获取令牌失败");
                    return false;
                }
            }

            string jsonData = string.Empty;
            var obj = new
            {
                cmd = (int)eProtocolCommand.NormalOperate,
                Hwd = hwd,
                Indicator = "ADD_RECORD",
                SerializeData = JsonConvert.SerializeObject(new
                {
                    LineCode = _config.LineCode,
                    SectionCode = _config.SectionCode,
                    StationCode = _config.StationCode,
                    OPCategory = "DT_REPORT_UPLOAD",
                    OPRequestInfo = new
                    {
                        ERROR_CODE = errorCode,
                        ERROR_MESSAGE = errorMessage,
                        MACHINE_NO = _config.StationCode,
                        VENDOR_CODE = _config.VendorCode,
                        ISSUE_CATEGORY = errorCategory,
                        ROOT_CAUSE = errorDetail,
                        ACTION = "",
                        DRI = cardid,
                        //FUNCTION = ,
                        UPLOAD_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        STATUS_FLAG = "END"
                    },
                    OPResponseInfo = new { }
                })
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log.Invoke(funcName + "上传:" + _config.Url_AutoGate + ":" + jsonData);
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log.Invoke(funcName + "反馈:" + receiveData);
                Mes_BackData mes_backData = JsonConvert.DeserializeObject<Mes_BackData>(receiveData);
                if (mes_backData == null)
                {
                    //log
                    log.Invoke(funcName + "转换失败");
                    return false;
                }
                if (mes_backData.cmd != (int)eProtocolCommand.NormalOperate)
                {
                    //log
                    log.Invoke(funcName + "反馈失败:" + mes_backData.cmd);
                    return false;
                }

                dynamic secondaryProtocol = JsonConvert.DeserializeObject(mes_backData.SerializeData);
                if (secondaryProtocol == null)
                {
                    //log
                    log.Invoke(funcName + "解析二级协议失败");
                    return false;
                }
                if (secondaryProtocol.OPResponseInfo.Result != "OK")
                {
                    //log
                    log.Invoke(funcName + "反馈NG");
                    return false;
                }

                //log
                log.Invoke(funcName + "反馈成功");
                return true;
            }
            catch (Exception ex)
            {
                //log
                log.Invoke(funcName + "异常:" + ex.Message + ":" + ex.StackTrace);
                return false;
            }
        }

        #endregion


        #region GTK图片上传

        public bool ImageToBase64(string SN, string sourceDirPath)
        {
            string funcName = "[图片上传]";
            try
            {
                string url = _config.Url_UploadImg+"?sn="+SN+"&stationCode="+_config.StationCode+"&imageType=1";
                string[] files = Directory.GetFiles(sourceDirPath, "*.jpg");

                using (var client = new HttpClient() {Timeout = TimeSpan.FromSeconds(3)})
                {

                    using (var content = new MultipartFormDataContent())
                    {
                        foreach (var item in files)
                        {
                            byte[] imageBytes = File.ReadAllBytes(item);
                            var byteArrayContent = new ByteArrayContent(imageBytes);
                            content.Add(byteArrayContent, "imgList", Path.GetFileName(item));
                        }

                        string cmd = content.Headers.ToString();

                        foreach (var item in content)
                        {
                            cmd = cmd + item.Headers.ToString();
                        }
                        log.Invoke(funcName + "上传:" + url + ":" + cmd);
                        var response = client.PostAsync(url, content).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string result = response.Content.ReadAsStringAsync().Result;
                            log.Invoke(funcName + "反馈:" + url + ":" + result);
                            return true;
                        }
                        else
                        {
                            string result = response.Content.ReadAsStringAsync().Result;
                            log.Invoke(funcName + "反馈:" + url + ":" + result);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log
                log?.Invoke($"{funcName}异常:{ex.Message + ex.StackTrace}");
                _errorMesssage = ex.Message;
                return false;
            }
        }

        public string ImageHttpPost(string url, string cmd, Dictionary<string, string> header = null)
        {
            try
            {
                string result = string.Empty;
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                if (header != null)
                {
                    foreach (KeyValuePair<string, string> item in header)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }
                if (!string.IsNullOrWhiteSpace(cmd))
                {
                    byte[] buffer = encoding.GetBytes(cmd);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                response.Close();
                return result;
            }
            catch (WebException ex)
            {
                string result = string.Empty;
                HttpWebResponse resp = ex.Response as HttpWebResponse;
                if (resp != null)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                        reader.Close();
                    }
                }
                return "Error:" + ex.Message + ":" + result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string MaintenceMesUpload(string userId, string project, string line, string headId, string item, string maxTime, string alertTime, bool isAdd)
        {
            throw new NotImplementedException();
        }

        public string HashKeyMesUpload(string id, string project, string result)
        {
            string funcName = "[HASH值上传]";
            string sw_Hash1 = string.Empty;
            string sw_Hash2 = string.Empty;
            CheckHwd();
            if (string.IsNullOrWhiteSpace(hwd))
            {
                //log
                log.Invoke(funcName + "获取令牌失败");
                return funcName + "获取令牌失败";
            }

            if (!result.IsNullOrWhiteSpace())
            {
                string[] splitHash = result.Split(',');
                if (splitHash.Length > 1)
                {
                    sw_Hash1 = splitHash[0].Split('$')[1].Split('=')[1];
                    sw_Hash2 = splitHash[1].Split('$')[1].Split('=')[1];
                }
            }

            string jsonData = string.Empty;
            var obj = new
            {
                cmd = (int)eProtocolCommand.NormalOperate,
                Hwd = hwd,
                Indicator = "ADD_RECORD",
                SerializeData = JsonConvert.SerializeObject(new
                {
                    LineCode = _config.LineCode,
                    SectionCode = _config.SectionCode,
                    StationCode = _config.StationCode,
                    OPCategory = "UPLOAD_EQUIP_HASH_INFO",
                    OPRequestInfo = new
                    {
                        vendor = _config.VendorCode,
                        sw_version = _config.ServerVersion,
                        u_id = id,
                        MS_SHA1 = sw_Hash1,
                        MS_SHA2 = sw_Hash2,
                    },
                    OPResponseInfo = new
                    {
                        //Result = ""
                    }
                })
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log.Invoke(funcName + "上传:" + _config.Url_AutoGate + ":" + jsonData);
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log.Invoke(funcName + "反馈:" + receiveData);

                return receiveData;
            }
            catch (Exception ex)
            {
                //log
                log.Invoke(funcName + "异常:" + ex.Message + ":" + ex.StackTrace);
                return funcName + "异常:" + ex.Message + ":" + ex.StackTrace;
            }
        }

        public bool HashKeyMesCheck(string result, ref string msg, int tryCount = 3)
        {
            string funcName = "[HASH值检查]";
            string sw_Hash1 = string.Empty;
            string sw_Hash2 = string.Empty;
            CheckHwd();
            if (string.IsNullOrWhiteSpace(hwd))
            {
                //log
                log.Invoke(funcName + "获取令牌失败");
                return false;
            }

            if (!result.IsNullOrWhiteSpace())
            {
                string[] splitHash = result.Split(',');
                if (splitHash.Length > 1)
                {
                    sw_Hash1 = splitHash[0].Split('$')[1].Split('=')[1];
                    sw_Hash2 = splitHash[1].Split('$')[1].Split('=')[1];
                }
            }

            string jsonData = string.Empty;
            var obj = new
            {
                cmd = (int)eProtocolCommand.NormalOperate,
                Hwd = hwd,
                Indicator = "QUERY_RECORD",
                SerializeData = JsonConvert.SerializeObject(new
                {
                    LineCode = _config.LineCode,
                    SectionCode = _config.SectionCode,
                    StationCode = _config.StationCode,
                    OPCategory = "CHECK_EQUIP_HASH_INFO",
                    OPRequestInfo = new
                    {
                        vendor = _config.VendorCode,
                        sw_version = _config.ServerVersion,
                        MS_SHA1 = sw_Hash1,
                        MS_SHA2 = sw_Hash2,
                    },
                    OPResponseInfo = new
                    {
                        //Result = ""
                    }
                })
            };

            try
            {
                jsonData = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //log
                log.Invoke(funcName + "上传:" + _config.Url_Gate + ":" + jsonData);
                string receiveData = HttpClients.HttpPost(jsonData, _config.Url_AutoGate);
                //log
                log.Invoke(funcName + "反馈:" + receiveData);
                Mes_BackData mes_backData = JsonConvert.DeserializeObject<Mes_BackData>(receiveData);
                if (mes_backData == null)
                {
                    //log
                    log.Invoke(funcName + "转换失败");
                    return false;
                }
                if (mes_backData.cmd != (int)eProtocolCommand.NormalOperate)
                {
                    //log
                    log.Invoke(funcName + "反馈失败:" + mes_backData.cmd);
                    return false;
                }

                dynamic secondaryProtocol = JsonConvert.DeserializeObject(mes_backData.SerializeData);
                if (secondaryProtocol == null)
                {
                    //log
                    log.Invoke(funcName + "解析二级协议失败");
                    return false;
                }
                if (secondaryProtocol.OPResponseInfo.Result != "true")
                {
                    //log
                    log.Invoke(funcName + "反馈NG");
                    return false;
                }

                //log
                log.Invoke(funcName + "反馈成功");
                return true;
            }
            catch (Exception ex)
            {
                //log
                log.Invoke(funcName + "异常:" + ex.Message + ":" + ex.StackTrace);
                return false;
            }
        }

        public bool UpCollMachineState(MachineStateConfig machineStateConfig, DateTime changeTime, string hashKey, int tryCount)
        {
            throw new NotImplementedException();
        }

        public class ImageGroupInfo
        {
            public string Sn { get; set; }
            public string SectionCode { get; set; }
            public string StationCode { get; set; }
            public string User { get; set; }
            public string ImageType { get; set; }
            public DateTime UploadDate { get; set; }
            public List<byte[]> ImgByteList { get; set; }
        }

        public class resultClass
        {
            public int code { get; set; }

            public string msg { get; set; }

            public string data { get; set; }
        }

        #endregion
    }

    public class MES_Config_GTK
    {
        //[DisplayName("作业员用户名")]
        public string Username { get; set; }
        //[DisplayName("作业员密码")]
        public string Password { get; set; }
        //[DisplayName("线体编码")]
        public string LineCode { get; set; }
        //[DisplayName("工站编码")]
        public string SectionCode { get; set; }
        //[DisplayName("工位编码")]
        public string StationCode { get; set; }
        //[DisplayName("服务端版本")]
        public string ServerVersion { get; set; }
        //[DisplayName("供应商编码")]
        public string VendorCode { get; set; }

        public string Url_Gate = @"http://172.28.1.2:8080/api/gate";
        public string Url_AutoGate = @"http://172.28.1.2:8080/api/autogate";
        public string Url_UploadImg = @"http://172.28.1.121/api/image/upload";
    }

    public enum eProtocolCommand
    {
        Content = 0,                //正常消息
        Error = -1,                 //发生错误
        Welcome = 1,                //欢迎登录
        UserLogin = 2,              //用户第一次登录
        UserReLogin = 3,            //用户非第一次登录
        LoginSuccess = 4,           //登录成功
        LoginFailed = 5,            //登录失败
        BindStation = 10,           //绑定工位
        BindSuccess = 11,           //绑定工位成功
        BindFailed = 12,            //绑定工位失败
        GetQuery = 13,              //获取查询
        GetVersions = 14,           //获取版本信息
        GetVersionInfo = 15,        //获取版本信息内容
        NormalOperate = 16,         //普通接口操作
    }

    public enum eRequestCommandType
    {
        ClientClearCount = -1,      //终端端计数复位
        ClientReady = 0,            //终端就绪/复位工作流程
        TxtInput = 1,               //文本扫码输入成功
        WindowTxtInput = 2,         //弹窗文本扫码输入成功
        WindowTxtInputCancel = 3,   //弹窗文本输入取消
        WindowListSelect = 4,       //弹窗列表选择成功
        WindowListCancel = 5,       //登弹窗列表选择取消
        WindowYes = 6,              //弹窗选择是
        WindowNo = 7,               //弹窗选择否
        PrintSucess = 8,            //终端打印执行成功
        PrintFailure = 9,           //终端打印执行失败
        SetInputGlobalValue = 100,  //设置全局信息
        UploadInfo = 11,            //上传工位参数信息
        SubmitInputData = 10,       //组装完成，提交上料组装数据
    }

    public enum eResponseCommandType
    {
        Error = -1,                        //Error,服务端处理该消息发生错误    
        ListSelect = 0,                    //服务端需要终端进行列表选择，并提供信息
        TextInput = 1,                     //服务端需要终端扫码输入，并提供信息
        WindowInput = 2,                   //服务端需要终端弹出页面，在新页面扫码输入并提供信息
        WindowListSelect = 3,              //服务端需要终端弹出页面，在新页面列表选择并提供信息
        WindowYesNo = 4,                   //服务端需要终端弹出页面，在新页面选择是否并提供信息
        Notice = 5,                        //服务端仅更新终端的提示信息
        Print = 6,                         //服务端需要终端执行打印操作
        ClientClearCountSuccess = 10,      //服务端清除了终端的计数反馈
        VoidExecuteSuccess = 11,           //无返回值的操作成功响应
        VoidExecuteFailure = 12,           //无返回值的操作失败响应
        WaitUploadInfo = 14,               //等待上传设备参数等数据
        WaitSubmitInputData = 13,          //组装完成等待提交上料数据
    }

    public enum eBusinessPointEnum
    {
        Default = 0,            //默认值，返回该值无实际意义
        GetSN = 1,              //服务端当前需要客户端输入产品流转码
        GetRawSN = 2,           //服务端当前需要客户端输入子物料条码
        GetRawSNBatch = 3,      //服务端当前需要客户端输入子物料批次号
        WaitSubmitInputData = 4,//组装完成，等待提交数据
        WaitUploadInfo = 5,     //等待上传设备参数等信息
    }
}