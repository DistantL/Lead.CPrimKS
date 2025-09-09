using Newtonsoft.Json;

namespace Lead.CPrim.Interfaces
{
	/// <summary>
	/// 任务结构
	/// </summary>
	public struct TaskMember
	{
		/// <summary>任务名称</summary>
		public string TaskName { get; set; }
		/// <summary>任务</summary>
		[JsonIgnore]
		public ITask Task { get; set; }
		/// <summary>任务是否启动</summary>
		public bool Statup { get; set; }

		public TaskMember(string taskName, bool statup, ITask task)
		{
			TaskName = taskName;
			Task = task;
			Statup = statup;
		}
	}
}
