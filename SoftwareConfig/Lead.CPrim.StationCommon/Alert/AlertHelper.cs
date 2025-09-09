using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Lead.CPrim.StationCommon.Alert
{
    public class AlertHelper
    {
        public static void AlertDataTotal(double time, AlertInfo alertInfo, ref List<DowntimeData> datas)
        {
            if (datas.Exists(p => p.Error == alertInfo.ErrorMessage))
            {
                datas.ForEach((p) =>
                {
                    if (p.Error == alertInfo.ErrorMessage)
                    {
                        p.TotalTime += time;
                        p.CountTotal++;
                    }
                });
            }
            else
            {
                string color = string.Empty;
                switch (alertInfo.ErrorMessage)
                {
                    case "Cylinder Error":
                        color = "#6F7980";
                        break;
                    case "Sensor Error":
                        color = "#5497C1";
                        break;
                    case "SW Error":
                        color = "#53AC7A";
                        break;
                    case "Vision Error":
                        color = "#F8C35C";
                        break;
                    case "Safety Error":
                        color = "#F3965B";
                        break;
                    case "Scanning Error":
                        color = "#E45E69";
                        break;
                    case "Motion Error":
                        color = "#7D72BB";
                        break;
                    case "Other":
                        color = "#4CAAE9";
                        break;
                    default:
                        color = "#4CAAE9";
                        break;
                }

                DowntimeData downtimeData = new DowntimeData
                {
                    ColorName = color,
                    Error = alertInfo.ErrorMessage,
                    TotalTime = time,
                    CountTotal = 1
                };
                datas.Add(downtimeData);
            }
        }

        public static void AlertDataTotalDetail(List<AlertInfo> alertInfos, ref List<DowntimeData> data)
        {
            var groups = alertInfos.GroupBy(x => x.ErrorMessage);
            //string，报警类型；string 报警代码； DowntimeData 细分的报警代码对应时间
            Dictionary<string, Dictionary<string, DowntimeData>> dic = new Dictionary<string, Dictionary<string, DowntimeData>>();

            //统计
            foreach (var group in groups)
            {
                dic.Add(group.Key, new Dictionary<string, DowntimeData>());

                //增加报警类型的总计时
                dic[group.Key].Add(group.Key, new DowntimeData() { Error = group.Key, TotalTime = 0.0000001, CountTotal = 0 });

                foreach (var item in group)
                {
                    if (double.TryParse(item.TimeInState, out double time))
                    {
                        //总计时统计
                        dic[group.Key][group.Key].TotalTime += time;
                        dic[group.Key][group.Key].CountTotal++;

                        //报警代码统计
                        if (!dic[group.Key].ContainsKey(item.ErrorCode))
                        {
                            dic[group.Key].Add(item.ErrorCode, new DowntimeData() { Error = item.ErrorCode, TotalTime = 0, CountTotal = 0, ErrorDetail = item.ErrorDetail });
                        }

                        dic[group.Key][item.ErrorCode].TotalTime += time;
                        dic[group.Key][item.ErrorCode].CountTotal++;
                    }
                }
                //子项排序
                dic[group.Key] = dic[group.Key].OrderBy(y => y.Value.TotalTime).ToDictionary(x => x.Key, x => x.Value);
            }

            //排序
            var dic1 = dic.OrderBy(x => x.Value[x.Key].TotalTime);

            //导出
            data = new List<DowntimeData>();
            foreach (var item in dic1)
            {
                foreach (var element in item.Value)
                {
                    data.Add(element.Value);
                }
            }
        }
    }
}
