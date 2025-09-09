namespace Lead.CPrim.Interfaces.StateMachine
{
	/// <summary>用户事件</summary>
	public class UserEvent
	{
		#region Prop
		/// <summary>事件类型</summary>
		public UserEventType EventType;
		/// <summary>信息载体</summary>
		public IStateMachine EventSender;
		/// <summary>事件载体</summary>
		public IEventHandler EventTarget;
		/// <summary>任务名称</summary>
		public string TaskName = null;
		#endregion


		#region Method
		/// <summary>事件执行(1)</summary>
		public void Execute()
		{
			EventTarget.HandleEvent(this);
		} 
		#endregion
	}
}
