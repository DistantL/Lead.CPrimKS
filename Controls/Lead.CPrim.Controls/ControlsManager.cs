using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>Controls管理类</summary>
    public class ControlsManager
    {
        #region Prop
        public static ControlsManager Instance => new ControlsManager();
        #endregion


        #region Method_ExternalUsing
        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"Controls -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.Controls}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimCommon.ToString(), LogClassification.Module, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }
        #endregion
    }


    /// <summary>Setting界面使用</summary>
    public class SettingUse
    {
        /// <summary>工厂列表</summary>
        public List<string> SiteSelects { get; set; }

        /// <summary>站位列表</summary>
        public List<string> StationSelects { get; set; }

        /// <summary>语言列表</summary>
        public List<string> LanguageSelects { get; set; }

        /// <summary>当前Site</summary>
        public string CurrentSite { get; set; }

        /// <summary>当前线体</summary>
        public string CurrentLine { get; set; }

        /// <summary>当前工站</summary>
        public string CurrentStation { get; set; }

        /// <summary>当前QPL</summary>
        public string CurrentQPL { get; set; }

        /// <summary>当前语言</summary>
        public string CurrentLanguage { get; set; }

        public List<string> ListProductionType { get; set; } = new List<string>();
        public List<string> ListProductionTypeBackColor { get; set; } = new List<string>();
        public string CurrentProductionType { get; set; } = "";

        public bool AccessControlWithMES { get; set; } = true;
    }

    public class Maintenance
    {
        public Maintenance()
        {
            Project = string.Empty;
            LineType = string.Empty;
            HeadID = string.Empty;
            Item = string.Empty;
            Period = string.Empty;
            Threshold = string.Empty;
            Record = string.Empty;
            GuId = Guid.NewGuid().ToString();
        }

        public string Project { get; set; }

        public string LineType { get; set; }

        public string HeadID { get; set; }

        public string Item { get; set; }

        /// <summary>
        /// 保养周期
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// 保养倒计时
        /// </summary>
        [BsonIgnore]
        public string Countdown { get; set; }

        /// <summary>
        /// 预警阈值
        /// </summary>
        public string Threshold { get; set; }

        /// <summary>
        /// 最近维护记录
        /// </summary>
        public string Record { get; set; }

        /// <summary>
        /// 计划保养时间
        /// </summary>
        [BsonIgnore]
        public string Time { get; set; }

        /// <summary>
        /// 健康状态
        /// </summary>
        [BsonIgnore]
        public string Status
        {
            get
            {
                if (string.IsNullOrEmpty(Record)
                    || !double.TryParse(Period, out double hours)
                    || !DateTime.TryParse(Record, out DateTime recordTemp)
                    || !double.TryParse(Threshold, out double thresholdTemp))
                {
                    return string.Empty;
                }

                Time = (recordTemp + TimeSpan.FromHours(hours)).ToString("yyyy/MM/dd HH:mm");

                //计算保养倒计时
                var temp = (int)((recordTemp + TimeSpan.FromHours(hours)) - DateTime.Now).TotalHours;
                Countdown = temp.ToString();

                if (temp < 0) return "Overdue maintenance";
                else if (temp > thresholdTemp) return "Good health";
                else return "Need to maintain";
            }
        }

        public string GuId { get; set; }
    }

    public class UserAccessInfo 
    {
        public string Site {  get; set; } = string.Empty;

        public string Project { get; set; } = string.Empty;

        public string Vendor_Name { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Access_Level { get; set; } = string.Empty;

        public string Card_UID { get; set; } = string.Empty;

        public string Function { get; set; } = string.Empty;

        public string Station_ID { get; set; } = string.Empty;
    }
}
