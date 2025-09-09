using System;
using System.Collections.Concurrent;
using Lead.CPrim.CmpTrigHelper;
using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Newtonsoft.Json;

namespace Lead.CPrim.Global
{
    [JsonObject(/*Could not decode attribute arguments.*/)]
    public class ProductTrigInfo
    {
        #region Prop
        /// <summary>
        /// Guid
        /// </summary>
        public Guid Gid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 轨迹表集合
        /// </summary>
        public ConcurrentDictionary<Guid, TriggerTrackData> TrajDatas { get; set; }

        /// <summary>
        /// 插补表集合
        /// </summary>
        public ConcurrentDictionary<Guid, InterPolationCfg> InterpolationDatas { get; set; }

        /// <summary>
        /// 复杂插补表集合
        /// </summary>
        public ConcurrentDictionary<Guid, ComplexInterPolationCfg> ComplexInterPolationDatas { get; set; }

        /// <summary>
        /// 队列触发点
        /// </summary>
        public ConcurrentDictionary<Guid, TriggerTableData> TableTrigDatas { get; set; }

        /// <summary>
        /// 线性触发点
        /// </summary>
        public ConcurrentDictionary<Guid, LinearTrigData> LinearTrigDatas { get; set; }

        /// <summary>
        /// 多队列触发表
        /// </summary>
        public ConcurrentDictionary<Guid, TrigTabMangerData> TrigTabMangerDatas { get; set; }

        /// <summary>
        /// 触发端口集合
        /// </summary>
        public ConcurrentDictionary<Guid, TriggerPortData> TriggerDatas { get; set; }
        #endregion



        #region Ctor
        public ProductTrigInfo()
        {
            Gid = Guid.NewGuid();
            Name = "";
            TrajDatas = new ConcurrentDictionary<Guid, TriggerTrackData>();
            InterpolationDatas = new ConcurrentDictionary<Guid, InterPolationCfg>();
            ComplexInterPolationDatas = new ConcurrentDictionary<Guid, ComplexInterPolationCfg>();


            LinearTrigDatas = new ConcurrentDictionary<Guid, LinearTrigData>();
            TableTrigDatas = new ConcurrentDictionary<Guid, TriggerTableData>();
            TrigTabMangerDatas = new ConcurrentDictionary<Guid, TrigTabMangerData>();
            TriggerDatas = new ConcurrentDictionary<Guid, TriggerPortData>();
        }
        public ProductTrigInfo(string name) : this()
        {
            Name = name;
        }
        #endregion



        #region Method_Override
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
