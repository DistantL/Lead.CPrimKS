using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces
{
    /// <summary>ErrorCodes</summary>
    public class ErrorCodes
    {
        public ErrorCodes()
        {
            CreateTime = DateTime.Now;
            EndTime = DateTime.Now;
            ErrorName = "";
            ErrorCode = "";
            ErrorTime = 0;
        }
        public ErrorCodes(DateTime create, DateTime end, string name, string code)
        {
            CreateTime = create;
            EndTime = end;
            ErrorName = name;
            ErrorCode = code;
            ErrorTime = (end - create).TotalSeconds;
        }

        /// <summary>创建时间</summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { set; get; }
        /// <summary>结束时间</summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndTime { set; get; }
        /// <summary>ErrorCode名称</summary>
        public string ErrorName { get; set; }
        /// <summary>ErrorCode代码</summary>
        public string ErrorCode { get; set; }
        /// <summary>ErrorCode时间</summary>
        public double ErrorTime { get; set; }
    }


    //AQCI
    public enum ShowColor
    {
        Red,
        Black,
        White,
        Yellow,
        Blue,
        Green
    }
}
