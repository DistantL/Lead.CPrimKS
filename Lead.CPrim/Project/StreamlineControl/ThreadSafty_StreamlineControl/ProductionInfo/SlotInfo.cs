using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{
    /// <summary>
    /// 工位信息
    /// </summary>
    public class SlotInfo
    {
        /// <summary>
        /// 辅料SN<br/>
        /// 适用于主料SN未生成时，生成时间戳SN发送给视觉，最终将辅料图片移入主料文件夹
        /// </summary>
        public List<string> AccessaryVisionImageFilenames { get; set; } = new List<string>();
        /// <summary>
        /// 结束时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndTime { get; set; } = DateTime.Now;
        /// <summary>
        /// FAI项
        /// </summary>
        public List<FaiItem> Fais { get; set; } = new List<FaiItem>();
        /// <summary>
        /// 吸嘴编号<br/>
        /// 螺丝枪编号等等<br/>
        /// </summary>
        public int Head_Id { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 工位
        /// </summary>
        public int SlotIndex { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 抛料信息
        /// </summary>
        public Dictionary<string, string> TossingAccessaryInfos { get; set; } = new Dictionary<string, string>();
    }
}
