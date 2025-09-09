using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.WorkPlan
{
    /// <summary>工单记录表管理器</summary>
    public class WorkPlanDatas
    {
        /// <summary>工单号</summary>
        public string WorkSheetId { get; set; }
        /// <summary>PSASN</summary>
        public string WorkSheetPSASN { get; set; }
        /// <summary>工单数量</summary>
        public int WorkSheetCount { get; set; }
        /// <summary>工单记录表集合</summary>
        public List<ShowWorkPlanConfig> ListWorkPlan { get; set; }
    }


    /// <summary>工单记录表配置</summary>
    public class ShowWorkPlanConfig
    {
        public ShowWorkPlanConfig()
        {
            CreateTime = DateTime.Now;
            WorkSheetId = "";
            WorkSheetPSASN = "";
            WorkSheetCount = 0;
            CountOK = 0;
            CountNG = 0;
            ReMark = "进行中";
        }


        #region Define
        /// <summary>配置地址</summary>
        public string ConfigPath { get; set; }
        /// <summary>工单号</summary>
        public string WorkSheetId { get; set; }
        /// <summary>PSASN</summary>
        public string WorkSheetPSASN { get; set; }
        /// <summary>工单数量</summary>
        public int WorkSheetCount { get; set; }
        /// <summary>创建时间</summary>
        public DateTime CreateTime { get; set; }
        /// <summary>OK计数</summary>
        public int CountOK { get; set; }
        /// <summary>NG计数</summary>
        public int CountNG { get; set; }
        /// <summary>备注</summary>
        public string ReMark { get; set; }
        #endregion


        #region Override IPrim
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShowTypeName { get; set; }
        public bool Enable { get; set; }
        public string Version { get; set; } 
        #endregion
    }
}
