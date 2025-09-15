using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Task;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.MachineHelper
{
    /// <summary>状态机</summary>
    public abstract class TaskStateMachine : StateMachineBase
    {
        //*****************************************************************************
        #region Field
        /// <summary>
        /// 日志锁
        /// </summary>
        static readonly object _logObj = new object();

        /// <summary>
        /// log集合
        /// </summary>
        static List<LogShow> _logs = new List<LogShow>();

        /// <summary>
        /// 锁（灯进行切换）
        /// </summary>
        private readonly object obj = new object();

        /// <summary>
        /// 蜂鸣器<br/>
        /// 0：常灭；<br/>
        /// 1：常亮；<br/>
        /// 其它：闪烁；<br/>
        /// </summary>
        private int BeeState;

        /// <summary>
        /// 蜂鸣器次数
        /// </summary>
        private int BeeTim;

        /// <summary>
        /// 绿灯<br/>
        /// 0：常灭；<br/>
        /// 1：常亮；<br/>
        /// 其它：闪烁；<br/>
        /// </summary>
        private int GreenLightState;

        /// <summary>灯刷新Task</summary>
        private Task LightRefresh;

        /// <summary>
        /// 红灯<br/>
        /// 0：常灭；<br/>
        /// 1：常亮；<br/>
        /// 其它：闪烁；<br/>
        /// </summary>
        private int RedLightState;

        private UserMsgQueue userMsgs = new UserMsgQueue();

        /// <summary>
        /// 黄灯<br/>
        /// 0：常灭；<br/>
        /// 1：常亮；<br/>
        /// 其它：闪烁；<br/>
        /// </summary>
        private int YellowLightState;
        #endregion



        #region Prop
        public string RunningStateMessage = "运行中";
        /// <summary>任务集合</summary>
        public ConcurrentDictionary<int, StationTask> Tasks { get; } = new ConcurrentDictionary<int, StationTask>();
        #endregion



        #region Define_Event
        /// <summary>改变当前状态时发生</summary>
        public event Action<string, Color> ChangeUIStateEvent;

        /// <summary>任务日志UI写日志时发生（按照任务名称触发）</summary>
        public event Action<string, string, LogLevel> LogEvent;

        /// <summary>任务日志UI写日志时发生（自定义名称进行日志打印）</summary>
        public event Action<string, string, LogType, LogLevel> LogEventType;

        public event Action<string, bool> RefreshOperaInfoEvent;

        /// <summary>任务报警日志UI写日志时发生</summary>
        public event Action<string, LogLevel> ShowAlarmEvent;
        #endregion



        //*****************************************************************************
        #region override
        /// <summary>
        /// 事件执行(2)
        /// </summary>
        /// <param name="e"></param>
        public override void HandleEvent(UserEvent e)
        {
            base.HandleEvent(e);

            if (e.EventType == UserEventType.ESTOP)
            {
                PassEvents(e);
                foreach (KeyValuePair<int, StationTask> task in Tasks)
                {
                    task.Value.RefreshState(SmStates.WaitEStopClr);
                }
                LightChange(SmStates.WaitEStopClr);
                ChangeState(SmStates.WaitEStopClr);
                return;
            }
            if (e.EventType == UserEventType.PrimErr)
            {
                PassEvents(e);
                foreach (KeyValuePair<int, StationTask> task in Tasks)
                {
                    task.Value.RefreshState(SmStates.WaitClrPrimErr);
                }
                LightChange(SmStates.WaitClrPrimErr);
                ChangeState(SmStates.WaitClrPrimErr);
                return;
            }

            switch (base.State)
            {
                case SmStates.WaitReset:
                    {
                        if (e.EventType != UserEventType.RESET)
                        {
                            break;
                        }

                        foreach (KeyValuePair<int, StationTask> task in Tasks)
                        {
                            task.Value.RefreshState(SmStates.WaitReset);
                        }
                        PassEvents(e);
                        LightChange(SmStates.Resetting);
                        ChangeState(SmStates.Resetting);
                        break;
                    }

                case SmStates.Resetting:
                    {
                        if (e.EventType == UserEventType.STOP || e.EventType == UserEventType.PAUSE || e.EventType == UserEventType.Abnormal)
                        {
                            e.EventType = UserEventType.STOP;
                            PassEvents(e);
                            LightChange(SmStates.WaitReset);
                            ChangeState(SmStates.WaitReset);
                            ResetAbnormal();
                        }
                        break;
                    }

                case SmStates.WaitRun:
                    {
                        if (e.EventType == UserEventType.START)
                        {
                            foreach (KeyValuePair<int, StationTask> task in Tasks)
                            {
                                task.Value.RefreshState(SmStates.WaitRun);
                            }
                            PassEvents(e);
                            LightChange(SmStates.Running);
                            ChangeState(SmStates.Running);
                        }
                        else if (e.EventType == UserEventType.STOP)
                        {
                            PassEvents(e);
                            LightChange(SmStates.WaitReset);
                            ChangeState(SmStates.WaitReset);
                        }
                        break;
                    }

                case SmStates.Running:
                    {
                        if (e.EventType == UserEventType.Abnormal)
                        {
                            PassEvents(e);
                            LightChange(SmStates.WaitClrErr);
                            ChangeState(SmStates.WaitClrErr);
                        }
                        else if (e.EventType == UserEventType.PAUSE)
                        {
                            PassEvents(e);
                            LightChange(SmStates.Pause);
                            ChangeState(SmStates.Pause);
                        }
                        else if (e.EventType == UserEventType.STOP)
                        {
                            PassEvents(e);
                            LightChange(SmStates.WaitReset);
                            ChangeState(SmStates.WaitReset);
                        }
                        else if (e.EventType == UserEventType.RunningWithNotice)
                        {
                            LightChange(SmStates.RunningWithNotice);
                        }
                        else if (e.EventType == UserEventType.Idle)
                        {
                            LightChange(SmStates.RunningToIdle);
                        }
                        else if (e.EventType == UserEventType.ClrErr)
                        {
                            LightChange(SmStates.Running);
                        }
                        break;
                    }

                case SmStates.Pause:
                    {
                        if (e.EventType == UserEventType.Abnormal)
                        {
                            PassEvents(e);
                            LightChange(SmStates.WaitClrErr);
                            ChangeState(SmStates.WaitClrErr);
                        }
                        else if (e.EventType == UserEventType.START)
                        {
                            PassEvents(e);
                            LightChange(SmStates.Running);
                            ChangeState(SmStates.Running);
                        }
                        else if (e.EventType == UserEventType.STOP)
                        {
                            PassEvents(e);
                            ChangeState(SmStates.WaitReset);
                            LightChange(base.State);
                        }
                        else if (e.EventType == UserEventType.PAUSE)
                        {
                            PassEvents(e);
                            LightChange(SmStates.Pause);
                            ChangeState(SmStates.Pause);
                        }
                        break;
                    }

                case SmStates.WaitEStopClr:
                    {
                        if (e.EventType != UserEventType.ClrErr)
                        {
                            break;
                        }

                        ResetAbnormal();
                        if (!CheckNoEStop())
                        {
                            break;
                        }

                        foreach (KeyValuePair<int, StationTask> task7 in Tasks)
                        {
                            task7.Value.RefreshState(SmStates.WaitReset);
                        }
                        foreach (KeyValuePair<int, StationTask> task8 in Tasks)
                        {
                            task8.Value.ClrErr();
                        }
                        ChangeState(SmStates.WaitReset);
                        LightChange(base.State);
                        break;
                    }

                case SmStates.WaitClrPrimErr:
                    {
                        if (e.EventType != UserEventType.ClrErr)
                        {
                            break;
                        }

                        ResetAbnormal();
                        if (!CheckPrim())
                        {
                            break;
                        }

                        foreach (KeyValuePair<int, StationTask> task in Tasks)
                        {
                            task.Value.RefreshState(SmStates.WaitReset);
                        }
                        foreach (KeyValuePair<int, StationTask> task in Tasks)
                        {
                            task.Value.ClrErr();
                        }
                        ChangeState(SmStates.WaitReset);
                        LightChange(base.State);
                        break;
                    }

                case SmStates.WaitClrErr:
                    {
                        if (e.EventType == UserEventType.STOP)
                        {
                            PassEvents(e);
                            ChangeState(SmStates.WaitReset);
                            LightChange(base.State);
                        }
                        else if (e.EventType == UserEventType.ClrErr)
                        {
                            ResetAbnormal();
                            if (CheckAbnormal() != 0)
                            {
                                break;
                            }

                            foreach (KeyValuePair<int, StationTask> task in Tasks)
                            {
                                if (task.Value.RunningState != SmStates.Running)
                                {
                                    task.Value.RefreshState(SmStates.Pause);
                                }
                            }
                            foreach (KeyValuePair<int, StationTask> task in Tasks)
                            {
                                if (task.Value.RunningState != SmStates.Running)
                                {
                                    task.Value.ClrErr();
                                }
                            }
                            ChangeState(SmStates.Pause);
                            LightChange(base.State);
                        }
                        else if (e.EventType == UserEventType.Abnormal)
                        {
                            PassEvents(e);
                        }
                        else if (e.EventType == UserEventType.PAUSE)
                        {
                            PassEvents(e);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 任务状态机初始化[流程2](灯线程)
        /// </summary>
        /// <param name="task"></param>
        public override void Initialize(object task)
        {
            if (_machineInitSucess)
            {
                if (LightRefresh == null || LightRefresh.IsCompleted || LightRefresh.IsFaulted || LightRefresh.IsCanceled)
                {
                    LightRefresh = new Task(LithtResfrsh);
                    LightRefresh.Start();
                }
            }

            base.Initialize(task);
        }

        public override void runSmLoop()
        {
            //急停状态检查
            if ((int)base.State != 5 && !CheckNoEStop())
            {
                PostEvent(UserEventType.ESTOP, systemSM);
                return;
            }
            //基元报错检查
            if ((int)base.State != 6 && (int)base.State != 5 && !CheckPrim())
            {
                PostEvent(UserEventType.PrimErr, systemSM);
                return;
            }

            switch ((int)base.State)
            {
                //WaitReset
                //检测到复位信号，发送复位事件（未实现）
                //检测到所有任务状态 == Resetting，切换到Resetting状态
                case 0:
                    if (CheckResetSignal() && CheckAbnormal() == 0)
                    {
                        PostEvent(UserEventType.RESET, systemSM);
                    }
                    else if (Tasks.All((KeyValuePair<int, StationTask> s) => !s.Value.TaskEnable | (s.Value.TaskEnable & ((int)s.Value.RunningState == 1))) && Tasks.Any((KeyValuePair<int, StationTask> s) => (int)s.Value.RunningState == 1))
                    {
                        ChangeState(SmStates.Resetting);
                    }
                    break;

                //Resetting
                //检测到停止信号，发送停止事件
                //检测到暂停信号，发送停止事件
                //检测到异常信号，发送停止事件
                //检测到所有任务状态 == WaitRun，切换到WaitRun状态
                //检测到任何一个任务状态 == WaitReset，发送停止事件
                case 1:
                    if (CheckStopSignal())
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    else if (CheckPauseSignal())
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    else if (CheckAbnormal() != 0)
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    else if (CheckAllTasksState(SmStates.WaitRun))
                    {
                        ChangeState(SmStates.WaitRun);
                        LightChange(base.State);
                    }
                    else if (CheckAnyTasksState(SmStates.WaitReset))
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    break;

                //WaitRun
                //检测到启动信号，发送启动事件
                //检测到停止信号，发送停止事件
                //检测到所有任务状态 == Running，切换到Running状态
                //检测到任何一个任务状态 == WaitReset，发送停止事件
                case 2:
                    if (CheckStartSignal())
                    {
                        PostEvent(UserEventType.START, systemSM);
                    }
                    else if (CheckStopSignal())
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    else if (CheckAllTasksState(SmStates.Running))
                    {
                        ChangeState(SmStates.Running);
                    }
                    else if (CheckAnyTasksState(SmStates.WaitReset))
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    break;

                //Running
                //检测到停止信号，发送停止事件
                //检测到异常信号，发送报警事件
                //检测到暂停信号，发送暂停事件
                //检测到清报警信号，发送清报警事件  新增20250907
                //检测到任何一个任务状态 == WaitReset，发送停止事件
                //检测到任何一个任务状态 == Pause，切换到Pause状态
                //检测到任何一个任务状态 == WaitClrErr，发送报警事件（暂停屏蔽 => 为实现任务独立运行）
                case 3:
                    if (CheckStopSignal())
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    else if (CheckAbnormal() != 0)
                    {
                        PostEvent(UserEventType.Abnormal, systemSM);
                    }
                    else if (CheckPauseSignal())
                    {
                        PostEvent(UserEventType.PAUSE, systemSM);
                    }
                    else if (CheckClrErrSignal())
                    {
                        PostEvent(UserEventType.ClrErr, systemSM);
                    }
                    else if (CheckAnyTasksState(SmStates.WaitReset))
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    else if (CheckAnyTasksState(SmStates.Pause))
                    {
                        ChangeState(SmStates.Pause);
                    }
                    else if (CheckAnyTasksState(SmStates.WaitClrErr))
                    {
                        //PostEvent(UserEventType.Abnormal, systemSM);
                    }
                    break;

                //Pause
                //检测到启动信号，发送启动事件
                //检测到异常信号，发送报警事件
                //检测到停止信号，发送停止事件
                //检测到暂停信号，发送暂停事件
                //检测到所有任务状态 == Running，切换到Running状态
                //检测到任何一个任务状态 == WaitClrErr，发送报警事件
                //检测到任何一个任务状态 == WaitReset，发送停止事件
                case 4:
                    if (CheckStartSignal())
                    {
                        PostEvent(UserEventType.START, systemSM);
                        OnShowAlarmEvent(string.Empty, LogLevel.Trace);
                    }
                    else if (CheckAbnormal() != 0)
                    {
                        PostEvent(UserEventType.Abnormal, systemSM);
                    }
                    else if (CheckStopSignal())
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    else if (CheckPauseSignal())
                    {
                        PostEvent(UserEventType.PAUSE, systemSM);
                    }
                    else if (CheckAllTasksState(SmStates.Running))
                    {
                        ChangeState(SmStates.Running);
                    }
                    else if (CheckAnyTasksState(SmStates.WaitClrErr))
                    {
                        PostEvent(UserEventType.Abnormal, systemSM);
                    }
                    else if (CheckAnyTasksState(SmStates.WaitReset))
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    break;

                //WaitClrErr
                //检测到复位||清除报警信号，发送报警清除事件
                //检测到异常信号，发送报警事件
                //检测到暂停信号，发送暂停事件
                //检测到所有任务状态 == Pause，切换到Pause状态
                //检测到任何一个任务状态 == WaitReset，发送停止事件
                case 7:
                    if (CheckClrErrSignal())
                    {
                        PostEvent(UserEventType.ClrErr, systemSM);
                    }
                    else if (CheckAbnormal() != 0)
                    {
                        PostEvent(UserEventType.Abnormal, systemSM);
                    }
                    else if (CheckPauseSignal())
                    {
                        PostEvent(UserEventType.PAUSE, systemSM);
                    }
                    else if (CheckAllTasksState(SmStates.Pause))
                    {
                        ChangeState(SmStates.Pause);
                    }
                    else if (CheckAnyTasksState(SmStates.WaitReset))
                    {
                        PostEvent(UserEventType.STOP, systemSM);
                    }
                    break;

                //WaitClrPrimErr
                //检测到复位信号，发送报警清除事件
                //检测到所有任务状态 == WaitReset，切换到WaitReset状态
                //检测到所有任务状态 == WaitEStopClr，切换到WaitEStopClr状态
                case 6:
                    if (CheckClrErrSignal())
                    {
                        PostEvent(UserEventType.ClrErr, systemSM);
                    }
                    else if (CheckAllTasksState(SmStates.WaitReset))
                    {
                        ChangeState(SmStates.WaitReset);
                    }
                    else if (CheckAllTasksState(SmStates.WaitEStopClr))
                    {
                        ChangeState(SmStates.WaitEStopClr);
                    }
                    break;

                //WaitEStopClr
                //检测到复位信号，发送报警清除事件
                //检测到所有任务状态 == WaitReset，切换到WaitReset状态
                //检测到所有任务状态 == WaitClrPrimErr，切换到WaitClrPrimErr状态
                case 5:
                    if (CheckClrErrSignal())
                    {
                        PostEvent(UserEventType.ClrErr, systemSM);
                    }
                    else if (CheckAllTasksState(SmStates.WaitReset))
                    {
                        ChangeState(SmStates.WaitReset);
                    }
                    else if (CheckAllTasksState(SmStates.WaitClrPrimErr))
                    {
                        ChangeState(SmStates.WaitClrPrimErr);
                    }
                    break;
            }
        }
        #endregion



        //*****************************************************************************
        #region 此类虚方法
        /// <summary>异常信号检查</summary>
        /// <returns>int（0：未检测到异常；非0：检测到异常；）</returns>
        public virtual int CheckAbnormal()
        {
            return 0;
        }

        /// <summary>报警清除检查</summary>
        /// <returns>bool（true：检测到复位信号；false：未检测到复位信号；）</returns>
        public virtual bool CheckClrErrSignal()
        {
            return false;
        }

        public virtual int CheckManualSignal()
        {
            return 0;
        }

        /// <summary>
        /// 急停状态检查<br/>
        /// bool（true：非急停状态；false：急停状态；）
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckNoEStop()
        {
            return false;
        }

        /// <summary>暂停信号检查</summary>
        /// <returns>bool（true：检测到暂停信号；false：未检测到暂停信号；）</returns>
        public virtual bool CheckPauseSignal()
        {
            return false;
        }

        /// <summary>
        /// 基元报错检查<br/>
        /// bool（true：非报错状态；false：报错状态；）
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckPrim()
        {
            return false;
        }

        /// <summary>
        /// 复位信号检查（未实现）<br/>
        /// True：检测到复位信号<br/>
        /// False：未检测到复位信号<br/>
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckResetSignal()
        {
            return false;
        }

        /// <summary>
        /// 启动信号检查<br/>
        /// True：检测到启动信号<br/>
        /// False：未检测到启动信号<br/>
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckStartSignal()
        {
            return false;
        }

        /// <summary>
        /// 停止信号检查<br/>
        /// True：检测到停止信号<br/>
        /// False：未检测到停止信号<br/>
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckStopSignal()
        {
            return false;
        }

        /// <summary>
        /// 灯控制
        /// </summary>
        /// <param name="R">红灯</param>
        /// <param name="G">绿灯</param>
        /// <param name="Y">黄</param>
        /// <param name="Bee">蜂鸣器</param>
        public virtual void Light(bool R, bool G, bool Y, bool Bee)
        {
        }

        /// <summary>
        /// 报警UI显示
        /// </summary>
        /// <param name="alarm">报警内容</param>
        /// <param name="level">报警等级</param>
        /// <param name="show">是否UI显示</param>
        public virtual void OnShowAlarmEvent(string alarm, LogLevel level, bool show = true)
        {
            if (SitesManager.CurrentSite == Sites.嘉善)
            {
                DateTime now = DateTime.Now;
                lock (_logObj)
                {
                    _logs.RemoveAll(log => (now - log.TimeStamp).TotalMilliseconds > 3000);
                    if (_logs.FirstOrDefault(log => log.Message.Equals(alarm)) != null)
                    {
                        return;
                    }
                    _logs.Add(new LogShow { TimeStamp = now, Message = alarm });
                }
            }

            if (show)
            {
                ShowAlarmEvent?.Invoke(alarm, level);
            }
        }

        public virtual int ResetAbnormal()
        {
            return 0;
        }
        #endregion



        //*****************************************************************************
        #region 状态机
        /// <summary>
        /// 清报警
        /// </summary>
        public void ClrErr()
        {
            PostEvent(UserEventType.ClrErr, systemSM);
        }

        /// <summary>
        /// 手动触发报警
        /// </summary>
        /// <param name="alarm"></param>
        public void ManualAlarm(string alarm)
        {
            PostEvent(UserEventType.Abnormal, systemSM);
            OnShowAlarmEvent(alarm, LogLevel.Warn, true);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            PostEvent(UserEventType.PAUSE, systemSM);
        }

        /// <summary>
        /// 复位
        /// </summary>
        public void Reset()
        {
            if (CheckAbnormal() != 0)
            {
                Log(_machineLog, "复位时检测到异常信号，请确认安全后进行复位", LogLevel.Warn, true);
            }
            else
            {
                PostEvent(UserEventType.RESET, systemSM);
            }
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            if (CheckAbnormal() != 0)
            {
                Log(_machineLog, "启动时检测到异常信号，请确认安全后进行启动", LogLevel.Warn, true);
            }
            else
            {
                PostEvent(UserEventType.START, systemSM);
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            PostEvent(UserEventType.STOP, systemSM);
        }

        /// <summary>
        /// 提醒
        /// </summary>
        public void RunningWithNotice()
        {
            PostEvent(UserEventType.RunningWithNotice, systemSM);
        }

        /// <summary>
        /// 报警
        /// </summary>
        public void Abnormal()
        {
            PostEvent(UserEventType.Abnormal, systemSM);
        }

        /// <summary>
        /// 急停
        /// </summary>
        public void ESTOP()
        {
            PostEvent(UserEventType.ESTOP, systemSM);
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>当前状态值更新</summary>
        /// <param name="sta">当前状态值</param>
        public void ChangeUIState(string sta)
        {
            string msg = sta;
            Color color = Color.Green;
            switch (base.State)
            {
                case SmStates.WaitReset:
                    color = Color.Yellow;
                    break;
                case SmStates.Resetting:
                    color = Color.Yellow;
                    break;
                case SmStates.WaitRun:
                    color = Color.GreenYellow;
                    break;
                case SmStates.Running:
                    color = Color.Green;
                    msg = RunningStateMessage;
                    break;
                case SmStates.Pause:
                    color = Color.Yellow;
                    break;
                case SmStates.WaitEStopClr:
                case SmStates.WaitClrPrimErr:
                case SmStates.WaitClrErr:
                    color = Color.Red;
                    break;
            }
            ChangeUIStateEvent?.Invoke(msg, color);
        }

        /// <summary>
        /// 按任务名称进行日志打印
        /// <para>1、【任务日志UI写日志时发生】事件触发</para>
        /// <para>2、触发停止或者暂停</para>
        /// </summary>
        /// <param name="taskName">任务名称</param>
        /// <param name="s">日志内容</param>
        /// <param name="level">日志等级</param>
        /// <param name="show">是否UI显示</param>
        public void Log(string taskName, string s, LogLevel level, bool show = true)
        {
            if (show)
            {
                LogEvent?.Invoke(taskName, s, level);
            }
            TaskAlarm(taskName, s, level, show);
        }

        /// <summary>自定义名称进行日志打印
        /// <para>1、【任务日志UI写日志时发生】事件触发</para>
        /// <para>2、触发停止或者暂停</para>
        /// </summary>
        /// <param name="taskName">自定义名称</param>
        /// <param name="s">日志内容</param>
        /// <param name="level">日志等级</param>
        /// <param name="type">日志UI绑定</param>
        /// <param name="show">是否UI显示</param>
        public void Log(string taskName, string s, LogLevel level, LogType type, bool show = true)
        {
            if (show)
            {
                LogEventType?.Invoke(taskName, s, type, level);
            }
            TaskAlarm(taskName, s, level, show);
        }

        public virtual void OnLogEvent(string taskName, string log, LogLevel level, bool show = true)
        {
            if (show)
            {
                LogEvent?.Invoke(taskName, log, level);
            }
        }

        public void Push(string taskName, string s, bool stateFlag)
        {
            OnLogEvent(taskName, s, (LogLevel)4);
            if (stateFlag)
            {
                RunningStateMessage = s;
                ChangeUIState(s);
            }
            else
            {
                RefreshOperate(s, isTw: true, (PriorityLevel)3);
            }
        }

        /// <summary>操作指引值更新</summary>
        /// <param name="msg">操作指引值</param>
        /// <param name="isTw">true：闪烁；false：不进行闪烁</param>
        /// <param name="level"></param>
        public void RefreshOperate(string msg, bool isTw, PriorityLevel level = (PriorityLevel)1)
        {
            string str = userMsgs.GetMesg(new UserMsg(msg, level));
            this.RefreshOperaInfoEvent?.Invoke(str, isTw);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>确定是否对序列中的所有元素都满足条件（任务未使能或者任务状态等于指定状态）</summary>
        /// <param name="state">状态机状态</param>
        /// <returns>bool（true：所有满足条件；false：任何一个不满足条件；）</returns>
        bool CheckAllTasksState(SmStates state)
        {
            return Tasks.All((KeyValuePair<int, StationTask> s) => !s.Value.TaskEnable || s.Value.RunningState == state);
        }

        /// <summary>确定是否序列中的任何一个元素满足条件（任务使能同时任务状态等于指定状态）</summary>
        /// <param name="state">状态机状态</param>
        /// <returns>bool（true：任何一个满足条件；false：所有不满足条件；）</returns>
        bool CheckAnyTasksState(SmStates state)
        {
            return Tasks.Any((KeyValuePair<int, StationTask> s) => s.Value.TaskEnable && s.Value.RunningState == state);
        }

        void LightChange(SmStates e)
        {
            lock (obj)
            {
                switch (e)
                {
                    case SmStates.WaitReset:
                        {
                            RedLightState = 0;
                            GreenLightState = 0;
                            YellowLightState = 1;
                            BeeState = 2;
                            BeeTim = 2;
                        }
                        break;
                    case SmStates.Resetting:
                        {
                            RedLightState = 0;
                            GreenLightState = 0;
                            YellowLightState = 2;
                            BeeState = 0;
                            BeeTim = 0;
                        }
                        break;
                    case SmStates.WaitRun:
                        {
                            RedLightState = 0;
                            GreenLightState = 2;
                            YellowLightState = 0;
                            BeeState = 0;
                            BeeTim = 0;
                        }
                        break;
                    case SmStates.Running:
                        {
                            RedLightState = 0;
                            GreenLightState = 1;
                            YellowLightState = 0;
                            BeeState = 0;
                            BeeTim = 0;
                        }
                        break;
                    case SmStates.RunningToIdle:
                    case SmStates.Pause:
                        {
                            RedLightState = 0;
                            GreenLightState = 0;
                            YellowLightState = 1;
                            BeeState = 2;
                            BeeTim = 2;
                        }
                        break;
                    case SmStates.WaitEStopClr:
                        {
                            RedLightState = 1;
                            GreenLightState = 0;
                            YellowLightState = 0;
                            BeeState = 2;
                            BeeTim = 30;
                        }
                        break;
                    case SmStates.WaitClrPrimErr:
                        {
                            RedLightState = 1;
                            GreenLightState = 0;
                            YellowLightState = 0;
                            BeeState = 2;
                            BeeTim = 30;
                        }
                        break;
                    case SmStates.WaitClrErr:
                        {
                            RedLightState = 1;
                            GreenLightState = 0;
                            YellowLightState = 0;
                            BeeState = 2;
                            BeeTim = 30;
                        }
                        break;
                    case SmStates.RunningWithNotice:
                        {
                            RedLightState = 0;
                            GreenLightState = 1;
                            YellowLightState = 2;
                            BeeState = 2;
                            BeeTim = 30;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        void LithtResfrsh()
        {
            bool R2 = false;
            bool G2 = false;
            bool Y2 = false;
            bool Bee2 = false;
            bool flash = true;

            while (true)
            {
                bool R = RedLightState != 0 && (RedLightState == 1 || flash);
                bool G = GreenLightState != 0 && (GreenLightState == 1 || flash);
                bool Y = YellowLightState != 0 && (YellowLightState == 1 || flash);
                bool Bee;
                if (BeeState == 0)
                {
                    Bee = false;
                }
                else if (BeeState == 1)
                {
                    Bee = true;
                }
                else if (BeeTim > 0)
                {
                    Bee = flash;
                    BeeTim--;
                }
                else
                {
                    Bee = false;
                }

                flash = !flash;
                if (R != R2 || G != G2 || Y != Y2 || Bee != Bee2)
                {
                    Light(R, G, Y, Bee);
                }

                R2 = R;
                G2 = G;
                Y2 = Y;
                Bee2 = Bee;
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 事件执行(3)<br/>
        /// 任务操作<br/>
        /// </summary>
        /// <param name="e">用户事件</param>
        void PassEvents(UserEvent e)
        {
            if (Tasks.Count < 1)
            {
                return;
            }

            foreach (var task in Tasks)
            {
                task.Value.HandleEvent(e);
            }
        }

        /// <summary>
        /// 根据日志等级触发报警
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="s"></param>
        /// <param name="level"></param>
        /// <param name="show"></param>
        void TaskAlarm(string taskName, string s, LogLevel level, bool show = true)
        {
            if (level == LogLevel.Error || level == LogLevel.Fatal)
            {
                PostEvent(UserEventType.STOP, systemSM, taskName);
                if (SitesManager.CurrentSite == Sites.嘉善)
                {
                    OnShowAlarmEvent(s, level, show);
                }
            }
            else if (level == LogLevel.Warn)
            {
                PostEvent(UserEventType.Abnormal, systemSM, taskName);
                if (SitesManager.CurrentSite == Sites.嘉善)
                {
                    OnShowAlarmEvent(s, level, show);
                }
            }
        }
        #endregion
    }
}