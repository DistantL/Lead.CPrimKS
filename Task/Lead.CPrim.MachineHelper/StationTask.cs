/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: StationTask.cs
 * Author: Victor
 * Description: 用来管理线程
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * <3.3.22.0712><Victor><20220726>
 * 1、停止线程时提示日志等级由Error将为Trace
 * 
 * <3.3.23.0101><Victor><20230109>
 * 1、JoinIfPause方法进行优化，防止停止后线程多一次扫描
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.Interfaces.Task;
using Lead.CPrim.ProxyTools;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lead.CPrim.MachineHelper
{
    /// <summary></summary>
    public class StationTask
    {
        #region Define_Event
        public event Action<SmStates> OnRunningState;
        public event Action<int> OnTaskId;
        #endregion


        #region Field
        /// <summary>【StationTask】任务线程</summary>
        private Task _task;
        /// <summary>【StationTask】运行状态</summary>
        public SmStates _runningState;
        /// <summary>TaskId</summary>
        public int _taskId;
        #endregion


        #region Prop
        /// <summary>【TaskStateMachine】状态机</summary>
        public TaskStateMachine Machine { get; set; }
        /// <summary>【StationTask】运行状态</summary>
        public SmStates RunningState
        {
            get => _runningState;
            protected set
            {
                _runningState = value;
                OnRunningState?.Invoke(value);
            }
        }
        /// <summary>【StationTask】任务使能</summary>
        public bool TaskEnable { get; set; }
        /// <summary>【StationTask】任务名称</summary>
        public string TaskName { get; set; }
        /// <summary>TaskId</summary>
        public int TaskId
        {
            get => _taskId;
            set
            {
                _taskId = value;
                OnTaskId?.Invoke(value);
            }
        }
        #endregion


        #region Method_InternalUsing
        /// <summary>获取报警目录</summary>
        /// <param name="exTrace"></param>
        /// <returns></returns>
        private string GetExLocationInfo(string exTrace)
        {
            string locationInfo = "";
            string taskMsg = exTrace.Split('\r').ToList().FirstOrDefault((string p) => p.Contains(TaskName + "\\"));
            string[] s1 = ((taskMsg != null) ? taskMsg.Split(new string[1] { "位置" }, StringSplitOptions.RemoveEmptyEntries) : null);
            if (s1 != null && s1.Length >= 2)
            {
                locationInfo = s1[1];
            }
            return locationInfo;
        }
        /// <summary>抛出任务错误异常，退出线程执行</summary>
        /// <param name="msg"></param>
        private void StationThrowException(string msg = null)
        {
            throw new Exception(msg);
        }
        /// <summary>only called in stateMachine</summary>
        /// <param name="state"></param>
        public void RefreshState(SmStates state)
        {
            RunningState = state;
        }
        #endregion


        #region 发送用户事件
        /// <summary>事件执行(4)</summary>
        /// <param name="e"></param>
        public void HandleEvent(UserEvent e)
        {
            if (e.EventType == UserEventType.ESTOP)
            {
                Stop();
                RunningState = SmStates.WaitEStopClr;
            }
            if (e.EventType == UserEventType.PrimErr)
            {
                Stop();
                RunningState = SmStates.WaitClrPrimErr;
            }
            switch (RunningState)
            {
                case SmStates.WaitReset:
                    if (e.EventType == UserEventType.RESET)
                    {
                        Reset();
                    }
                    else if (e.EventType == UserEventType.STOP)
                    {
                        Stop();
                    }
                    break;
                case SmStates.Resetting:
                    if (e.EventType == UserEventType.STOP)
                    {
                        Stop();
                    }
                    else if (e.EventType == UserEventType.Abnormal)
                    {
                        Stop();
                    }
                    break;
                case SmStates.WaitRun:
                    if (e.EventType == UserEventType.START)
                    {
                        Start();
                    }
                    else if (e.EventType == UserEventType.Abnormal)
                    {
                        RunningState = SmStates.WaitClrErr;
                    }
                    else if (e.EventType == UserEventType.STOP)
                    {
                        Stop();
                    }
                    break;
                case SmStates.Running:
                    if (e.EventType == UserEventType.PAUSE)
                    {
                        RunningState = SmStates.Pause;
                        RunToPause();
                    }
                    if (e.EventType == UserEventType.Abnormal)
                    {
                        if (e.TaskName == null || (e.TaskName != null && e.TaskName.Contains(TaskName)))
                        {
                            RunningState = SmStates.WaitClrErr;
                            RunToPause();
                        }
                    }
                    else if (e.EventType == UserEventType.STOP)
                    {
                        Stop();
                    }
                    break;
                case SmStates.Pause:
                    if (e.EventType == UserEventType.START)
                    {
                        RunningState = SmStates.Running;
                        PauseToRun();
                    }
                    else if (e.EventType == UserEventType.CONTINUE)
                    {
                        RunningState = SmStates.Running;
                        PauseToRun();
                    }
                    else if (e.EventType == UserEventType.Abnormal)
                    {
                        RunningState = SmStates.WaitClrErr;
                    }
                    else if (e.EventType == UserEventType.STOP)
                    {
                        Stop();
                    }
                    else if (e.EventType == UserEventType.PAUSE)
                    {
                        // 线程已经触发暂停，不允许再次触发2025/8/11
                        if(RunningState != SmStates.Pause)
                        {
                            RunningState = SmStates.Pause;
                            RunToPause();
                        }
                    }
                    break;
                case SmStates.WaitClrErr:
                    if (e.EventType == UserEventType.STOP)
                    {
                        Stop();
                    }
                    break;
                case SmStates.WaitEStopClr:
                case SmStates.WaitClrPrimErr:
                    break;
            }
        }
        #endregion


        #region 复位线程
        /// <summary>复位线程1</summary>
        public void Reset()
        {
            if (_task != null)
            {
                Debug.Assert(_task == null);
                StationThrowException(TaskName + " not Stop Normally!");
            }
            RunningState = SmStates.Resetting;
            _task = Task.Run(ResettingLoopTask);
        }
        /// <summary>
        /// 复位线程2
        /// </summary>
        private void ResettingLoopTask()
        {
            try
            {
                TaskId = Thread.CurrentThread.ManagedThreadId;
                RunningState = SmStates.Resetting;
                Machine.RunningStateMessage = NLocalizer.Running;
                TaskLog(TaskName + " ResetLoop Start...", (LogLevel)4);
                if (ResetLoop() != 0)
                {
                    throw new Exception("Resetting Break");
                }
                TaskLog(TaskName + " ResetLoop Finish", (LogLevel)4);
                ResetDone();
                RunningState = SmStates.WaitRun;
            }
            catch (Exception ex)
            {
                TaskLog($"{TaskName} 复位异常：{ex.Message}，异常位置：{GetExLocationInfo(ex.StackTrace)}", LogLevel.Trace);
                RunningState = SmStates.WaitReset;
                Machine.PostEvent(UserEventType.STOP, Machine);
            }
            finally
            {
                _task = null;
            }
        }
        #endregion


        #region 启动线程
        /// <summary>
        /// 启动线程1
        /// </summary>
        public void Start()
        {
            try
            {
                if (_task != null)
                {
                    Debug.Assert(_task == null);
                    StationThrowException(TaskName + " not Stop Normally!");
                }
                RunningState = SmStates.Running;
                FirstRun();
                _task = Task.Factory.StartNew(RunningLoopTask, TaskCreationOptions.LongRunning);
                TaskLog(TaskName + " RunLoop Start...", LogLevel.Info);
            }
            catch (Exception ex)
            {
                TaskLog($"{TaskName} 启动异常：{ex.Message}，异常位置：{GetExLocationInfo(ex.StackTrace)}", LogLevel.Trace);
            }
        }
        /// <summary>
        /// 启动线程2
        /// </summary>
        private void RunningLoopTask()
        {
            try
            {
                TaskId = Thread.CurrentThread.ManagedThreadId;
                RunningState = SmStates.Running;
                while (RunningState == SmStates.Running || RunningState == SmStates.Pause || RunningState == SmStates.WaitClrErr)
                {
                    JoinIfPause();
                    if (RunLoop() != 0)
                    {
                        TaskLog(TaskName + " RunLoop Break", LogLevel.Info);
                        break;
                    }
                    Thread.Sleep(5);
                }
            }
            catch (Exception ex)
            {
                TaskLog($"{TaskName} 运行异常：{ex.Message}，异常位置：{GetExLocationInfo(ex.StackTrace)}", LogLevel.Trace);
                Machine.PostEvent(UserEventType.STOP, Machine);
            }
            finally
            {
                RunningState = SmStates.WaitReset;
                _task = null;
            }
        }
        #endregion


        #region 停止
        private void StopLoopTask()
        {
            try
            {
                StopLoop();
            }
            catch (Exception ex)
            {
                TaskLog("停止异常 详细错误信息: [[" + TaskName + "]:" + ex.Message + "  异常代码位置：" + GetExLocationInfo(ex.StackTrace), (LogLevel)6);
            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            RunningState = SmStates.WaitReset;
            Task.Run(StopLoopTask);
            try
            {
                _task?.Wait(1000);
            }
            catch
            {
            }
            finally
            {
                _task = null;
            }
        }
        #endregion


        #region 清除报警
        /// <summary>
        /// 清除报警
        /// </summary>
        public void ClrErr()
        {
            ClearErr();
        }
        #endregion


        #region 虚方法
        /// <summary>停止函数</summary>
        protected virtual void StopLoop()
        {
        }
        /// <summary>清除报警</summary>
        protected virtual void ClearErr()
        {
        }
        /// <summary>首次启动</summary>
        protected virtual void FirstRun()
        {
        }
        /// <summary>暂停→启动</summary>
        protected virtual void PauseToRun()
        {
        }
        /// <summary>复位完成</summary>
        protected virtual void ResetDone()
        {
        }
        /// <summary>复位中</summary>
        /// <returns></returns>
        protected virtual int ResetLoop()
        {
            return 0;
        }
        /// <summary>运行中</summary>
        /// <returns></returns>
        protected virtual int RunLoop()
        {
            return 0;
        }
        /// <summary>运行→暂停</summary>
        protected virtual void RunToPause()
        {
        }
        #endregion


        /// <summary>当停止信号触发，抛出任务取消异常，来退出线程执行</summary>
        /// <param name="msg"></param>
        public void AbortIfCancel(string msg)
        {
            if (RunningState == SmStates.WaitReset ||
                RunningState == SmStates.WaitClrPrimErr ||
                RunningState == SmStates.WaitEStopClr)
            {
                msg = (msg == null) ? TaskName : (TaskName + ":" + msg);
                throw new Exception(msg);
            }
        }
        /// <summary>当暂停信号触发，卡住线程在此函数，暂停信号取消继续执行；<br/>
        /// 当暂停时，且停止信号触发，抛出任务取消异常</summary>
        public void JoinIfPause()
        {
            if (RunningState == SmStates.Pause || RunningState == SmStates.WaitClrErr)
            {
                while (RunningState == SmStates.Pause || RunningState == SmStates.WaitClrErr)
                {
                    AbortIfCancel(TaskName);
                    Thread.Sleep(5);
                    //新增一个任务取消，防止停止后线程多一次扫描
                    AbortIfCancel(TaskName);
                }
            }
        }
        /// <summary>按任务名称进行日志打印</summary>
        /// <param name="log">日志内容</param>
        /// <param name="level">日志等级</param>
        /// <param name="show">是否UI显示</param>
        public virtual void TaskLog(string log, LogLevel level = (LogLevel)5, bool show = true)
        {
            log = TaskName + " -> " + log;
            if (Machine != null)
            {
                Machine.Log(TaskName, log, level, show);
            }
            LogAdd(log, level);
        }
        /// <summary>自定义名称进行日志打印</summary>
        /// <param name="name">自定义名称</param>
        /// <param name="log">日志内容</param>
        /// <param name="level">日志等级</param>
        /// <param name="type">日志UI绑定</param>
        /// <param name="show">是否UI显示</param>
        public virtual void TaskLog(string name, string log, LogLevel level = (LogLevel)5, LogType type = LogType.A, bool show = true)
        {
            log = TaskName + " -> " + log;
            if (Machine != null)
            {
                Machine.Log(name, log, level, type, show);
            }
            LogAdd(log, level);
        }
        /// <summary></summary>
        /// <param name="info"></param>
        /// <param name="stateFlag"></param>
        public virtual void TaskPushInfo(string info, bool stateFlag)
        {
            if (Machine != null)
            {
                Machine.Push(TaskName, info, stateFlag);
            }
        }
        /// <summary>日志增加</summary>
        /// <param name="log"></param>
        /// <param name="lv"></param>
        /// <param name="id"></param>
        public virtual void LogAdd(string log, LogLevel lv, int id = 0)
        {
            string tempId = $"{(int)lv}{(int)PrimLogId.Task}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, log, TaskName, LogClassification.Task, id);
        }
    }
}
