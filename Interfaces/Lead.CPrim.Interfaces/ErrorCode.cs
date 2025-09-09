using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Lead.CPrim.Interfaces
{
    public class AlertInfo
    {
        public AlertInfo()
        {
            ErrorDealHandle = new List<string>();
        }

        /// <summary>日期</summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }

        /// <summary>开始时间</summary>
       [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        /// <summary>结束时间</summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndTime { get; set; }

        /// <summary>报警时长</summary>
        public string TimeInState { get; set; }

        /// <summary>ErrorCode</summary>
        public string ErrorCode { get; set; }

        /// <summary>报警信息</summary>
        public string ErrorMessage { get; set; }

        /// <summary>ErrorDetail</summary>
        public string ErrorDetail { get; set; }

        /// <summary>报警分类</summary>
        public string Severity { get; set; }

        /// <summary>处理选项</summary>
        public List<string> ErrorDealHandle { get; set; }
    }


    public class DowntimeData
    {
        /// <summary>颜色名称</summary>
        public string ColorName { get; set; }
        /// <summary>报警分类</summary>
        public string Error { get; set; }
        /// <summary>总时间</summary>
        public double TotalTime { get; set; }
        /// <summary>总次数</summary>
        public int CountTotal { get; set; }
        /// <summary>报警信息</summary>
        public string ErrorDetail { get; set; }
    }
}
