using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    public class MesKS : MesBase
    {
        /// <summary>
        /// 查询辅料数量
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="canUseQty">可使用数量</param>
        /// <returns></returns>
        public override bool GetLotnoCount(string sn, out string canUseQty)
        {
            var obj = new
            {
                cavity = "",
                testData = "",
                results = "",
                status = "",
                pCmd = "GET_LOTNO_COUNT_NEW",
                defectCode = "",
                empNo = empNo,
                terminalName = terminalName,
                serial_Number = sn,
                machine = "",
                toolingNo = "",
                lotNo = "",
                kpsn = "",
                workOrder = ""
            };

            canUseQty = "";
            DateTime now = DateTime.Now;
            try
            {
                string send = JsonConvert.SerializeObject(obj, new JsonSerializerSettings());
                WriteMesLog(sn, $"{now:yyyy-MM-dd HH:mm:ss fff} -> 查询辅料数量 -> {send}");

                string receive = HttpClients.HttpPost(send, $"http://{MesIP}/api/Assy/GetCmdResult");
                WriteMesLog(sn, $"{now:yyyy-MM-dd HH:mm:ss fff} <- 查询辅料数量 <- {receive}");

                if (receive.Contains("操作超时"))
                {
                    throw new Exception("操作超时");
                }

                MesReturnMsg result = JsonConvert.DeserializeObject<MesReturnMsg>(receive);
                if (result == null)
                {
                    throw new Exception($"转换失败");
                }

                if (result.Result)
                {
                    if (!string.IsNullOrEmpty(result.RetMsg))
                    {
                        if(result.RetMsg.Contains("PART_NO=N/A"))
                        {
                            canUseQty = "新料，可使用";
                            return true;
                        }
                        else
                        {
                            string[] resultArray = result.RetMsg.Split(',');
                            foreach (string str in resultArray)
                            {
                                if (!string.IsNullOrEmpty(str) && str.Contains("ABLE_QTY="))
                                {
                                    int qty = 0;
                                    string[] qtys = str.Split('=');
                                    if (qtys.Length > 1 && int.TryParse(qtys[1], out qty))
                                    {
                                        canUseQty = qty.ToString();
                                    }
                                    return qty > 0;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteMesLog(sn, $"{now:yyyy-MM-dd HH:mm:ss fff}，查询辅料数量失败：{ex.Message}");
            }

            return false;
        }
    }
}
