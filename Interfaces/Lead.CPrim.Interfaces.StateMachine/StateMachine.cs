namespace Lead.CPrim.Interfaces.StateMachine
{
	#region Define_Del
	public delegate void Inited(bool success, IStateMachine sender);
	public delegate void StateChange(SmStates sta, IStateMachine sender);
	public delegate void MQRefresh(UserEvent msg, IStateMachine sender);
	#endregion


	#region Enum
	/// <summary>
	/// 状态机状态
	/// </summary>
	public enum SmStates
	{
		WaitReset = 0,
		Resetting,
		WaitRun,
		Running = 3,
		Pause,
		WaitEStopClr = 5,
		WaitClrPrimErr,
		WaitClrErr = 7,
		Auto,
		Manual = 9,
		Local,
		Remote,
		RecipeApply,
		RunningWithNotice = 13,
        RunningToIdle,
    }


	/// <summary>用户事件类型</summary>
	public enum UserEventType
	{
		ESTOP = 0,
		ESTOPOFF,
		START,
		STOP = 3,
		RESET,
		ClrErr,
		Abnormal = 6,
		NoErr,
		PAUSE,
		CONTINUE,
		PrimErr = 10,
		Auto,
		Manual,
		Local,
		Remote,
		RecipeApply, 
		RunningWithNotice = 16,
		Idle,
	}


	/// <summary>自动/手动</summary>
	public enum AutoManuelState
	{
		/// <summary>自动</summary>
		Auto,
		/// <summary>手动</summary>
		Manual
	}


	/// <summary>报警等级</summary>
	public enum EleAlarmLevel
	{
		/// <summary>忽略</summary>
		Ignore,
		/// <summary>暂停</summary>
		Warn,
		/// <summary>停止</summary>
		Err
	}


	public enum PriorityLevel
	{
		Task = 1,
		System,
		User,
	}
	#endregion
}
