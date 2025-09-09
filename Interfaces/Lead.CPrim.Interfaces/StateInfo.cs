using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces
{
	/// <summary>Hive枚举</summary>
	public enum HiveStatus
	{
		/// <summary>运行中</summary>
		Running = 1,

		/// <summary>空闲</summary>
		Idle,

		/// <summary>维修</summary>
		Engineering,

		/// <summary>计划停机</summary>
		Plan_DT,

		/// <summary>非计划停机</summary>
		DT,

		Disable = 9,
	}



	/// <summary>
	/// Hive状态
	/// </summary>
	public class StateInfo
    {
		/// <summary>
		/// 创建时间
		/// </summary>
		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 前持续状态
		/// </summary>
		public HiveStatus Status { get; set; }

		/// <summary>
		/// 持续时间
		/// </summary>
		public double Duration { get; set; }

		/// <summary>
		/// 切换到状态 当前状态
		/// </summary>
		public HiveStatus ChangeToStatus { get; set; }

		/// <summary>
		/// 状态附加信息json格式
		/// DT 或 Plan_DT 包含error_message 、 error_detail  
		/// Running 包含sequence
		/// 所有状态中包含badge 在手动状态时，填入操作员ID
		/// </summary>
		public string Tip { get; set; }


		public StateInfo()
		{
			CreateTime = DateTime.Now;
			Status = HiveStatus.Disable;
			Duration = 0.0;
		}

		public StateInfo(StateInfo stateInfo)
		{
			CreateTime = stateInfo.CreateTime;
			Status = stateInfo.Status;
			Duration = stateInfo.Duration;
			ChangeToStatus = stateInfo.ChangeToStatus;
			Tip = stateInfo.Tip;
		}
	}
}
