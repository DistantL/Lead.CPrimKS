namespace Lead.CPrim.Interfaces.StateMachine
{
    /// <summary>
    /// 任务接口
    /// </summary>
    public interface IStateMachine : IEventHandler
    {
        #region Prop
        /// <summary>【接口IStateMachine】任务名称</summary>
        string Name { get; }
        /// <summary>【接口IStateMachine】运行中</summary>
        bool IsRunning { get; }
        /// <summary>【接口IStateMachine】任务当前状态</summary>
        SmStates State { get; }
        /// <summary>【接口IStateMachine】任务上次状态</summary>
        SmStates LastState { get; }
        /// <summary>【接口IStateMachine】实例</summary>
        IStateMachine systemSM { get; set; }
        #endregion


        #region Define_Event
        /// <summary>【接口IStateMachine】初始化完成时发生</summary>
        event Inited OnInitedSuccess;
        /// <summary>【接口IStateMachine】</summary>
        event MQRefresh MQRefreshEvent;
        /// <summary>【接口IStateMachine】状态机状态切换时发生</summary>
        event StateChange StateChangeEvent;
        #endregion


        #region Method
        /// <summary>【接口IStateMachine】初始化</summary>
        /// <param name="obj"></param>
        void Initialize(object obj);
        /// <summary>【接口IStateMachine】发送事件</summary>
        /// <param name="e">用户事件</param>
        void PostEvent(UserEvent e);
        /// <summary>【接口IStateMachine】发送事件</summary>
        /// <param name="eventType"></param>
        /// <param name="eventHandler"></param>
        /// <param name="TaskName"></param>
        void PostEvent(UserEventType eventType, IEventHandler eventHandler, string TaskName = null);
        /// <summary>【接口IStateMachine】停止</summary>
        void Terminate();
        /// <summary>【接口IStateMachine】清除事件</summary>
        void ClrStateChangeEvent();
        #endregion
    }
}
