using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    [Serializable]
    public class AlarmInfo
    {
        /// <summary>
        /// 当前计数
        /// </summary>
        public int AlarmCount => Algorithm.CumulativeCounting;

        /// <summary>
        /// 连续累计算法
        /// </summary>
        public ContinuousCumulativeStatisticsAlgorithm Algorithm { get; set; }

        /// <summary>
        /// 连续阈值
        /// </summary>
        public int ContinuousThreshold { get; set; }

        /// <summary>
        /// 累计阈值
        /// </summary>
        public int CumulativeThreshold { get; set; }

        /// <summary>
        /// 报警代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 报警详细信息-中文
        /// </summary>
        public string ErrorDetail { get; set; }

        /// <summary>
        /// 报警详细信息-英文
        /// </summary>
        public string ErrorDetailInEN { get; set; }

        /// <summary>
        /// 报警详细信息-越南语
        /// </summary>
        public string ErrorDetailInVN { get; set; }

        /// <summary>
        /// 报警等级-中文
        /// </summary>
        public ErrorLevel ErrorLevel { get; set; } = ErrorLevel.三级报警;

        /// <summary>
        /// 报警等级-英文<br/>
        /// 暂不使用
        /// </summary>
        public string ErrorLevelInEN { get; set; }

        /// <summary>
        /// 报警类型
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// True：有参<br/>
        /// False：无参<br/>
        /// </summary>
        public bool HasParams { get; set; }

        /// <summary>
        /// 上次发生时间<br/>
        /// 暂不使用
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LastTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 提示方式
        /// </summary>
        public string PromptMethod { get; set; }

        /// <summary>
        /// 序列<br/>
        /// 暂不使用
        /// </summary>
        public ushort Sequence { get; set; }

        /// <summary>
        /// 解决方案-中文
        /// </summary>
        public string Solution { get; set; }

        /// <summary>
        /// 解决方案-英文
        /// </summary>
        public string SolutionInEN { get; set; }

        /// <summary>
        /// 解决方案-越南语
        /// </summary>
        public string SolutionInVN { get; set; }

        /// <summary>
        /// 切换HIVE状态
        /// </summary>
        public bool ToggleHiveStatus => (ErrorLevel == ErrorLevel.一级报警) || (ErrorLevel == ErrorLevel.二级报警);

        /// <summary>
        /// 供应商报警编号
        /// </summary>
        public string VendorAlarmCode { get; set; }



        public AlarmInfo()
        {
            Algorithm = new ContinuousCumulativeStatisticsAlgorithm(VendorAlarmCode, StatisticsMode.StatisticsByTime);
            Algorithm.Init(ContinuousThreshold, CumulativeThreshold, 60);
        }
    }
}
