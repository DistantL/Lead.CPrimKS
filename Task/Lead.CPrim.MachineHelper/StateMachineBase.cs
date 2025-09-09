using Lead.CPrim.Interfaces.StateMachine;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lead.CPrim.MachineHelper
{
    public abstract class StateMachineBase : IStateMachine, IEventHandler
    {
        private readonly ConcurrentPriorityQueue<int, UserEvent> priorityQueueEvents = new ConcurrentPriorityQueue<int, UserEvent>();

        private Thread _mainThread;

        protected static bool _machineInitSucess;

        protected string _machineLog = "状态机";

        public SmStates LastState { get; set; }

        public string Name { get; set; }

        public SmStates State { get; set; }

        public bool IsRunning { get; protected set; } = false;

        public IStateMachine systemSM { get; set; }

        public event Inited OnInitedSuccess;

        public event MQRefresh MQRefreshEvent;

        public event StateChange StateChangeEvent;

        public virtual void ChangeState(SmStates sta)
        {
            LastState = State;
            State = sta;
            StateChangeEvent?.Invoke(sta, (IStateMachine)(object)this);
        }

        public virtual void HandleEvent(UserEvent e)
        {
            MQRefreshEvent?.Invoke(e, (IStateMachine)(object)this);
        }

        public virtual void Initialize(object obj)
        {
            if (Name == "SystemSM" || Name == "AutoSM")
            {
                IsRunning = true;
                _mainThread = new Thread(RunStateMachine)
                {
                    IsBackground = true
                };
                _mainThread.Start();
                OnInitedSuccess?.Invoke(true, (IStateMachine)(object)this);
                return;
            }
            if (_machineInitSucess)
            {
                IsRunning = true;
                _mainThread = new Thread(RunStateMachine)
                {
                    IsBackground = true
                };
                _mainThread.Start();
            }
            OnInitedSuccess?.Invoke(_machineInitSucess, (IStateMachine)(object)this);
        }

        public virtual void PostEvent(UserEvent e)
        {
            if (IsRunning)
            {
                if (e.EventTarget == this)
                {
                    priorityQueueEvents.Enqueue(1, e);
                }
                else
                {
                    ((IEventHandler)systemSM).HandleEvent(e);
                }
            }
        }

        public virtual void PostEvent(UserEventType eventType, IEventHandler eventHandler, string TaskName = null)
        {
            UserEvent e = new UserEvent
            {
                EventSender = (IStateMachine)(object)this,
                EventType = eventType,
                EventTarget = eventHandler,
                TaskName = TaskName
            };
            PostEvent(e);
        }

        public virtual void Terminate()
        {
            PostEvent((UserEventType)3, (IEventHandler)(object)this);
            IsRunning = false;
            if (_mainThread != null)
            {
                if (_mainThread.IsAlive)
                {
                    _mainThread.Join(new TimeSpan(0, 0, 2));
                }
                OnInitedSuccess?.Invoke(false, (IStateMachine)(object)this);
            }
            State = (SmStates)0;
        }

        public void ClrStateChangeEvent()
        {
            if (StateChangeEvent == null)
            {
                return;
            }
            foreach (var d in StateChangeEvent.GetInvocationList())
            {
                StateChangeEvent -= d as StateChange;
            }
        }

        public virtual void runSmLoop()
        {
        }

        public virtual void RunStateMachine()
        {
            while (IsRunning || priorityQueueEvents.Count > 0)
            {
                runSmLoop();
                while (priorityQueueEvents.Count > 0)
                {
                    if (priorityQueueEvents.TryDequeue(out KeyValuePair<int, UserEvent> e))
                    {
                        e.Value.Execute();
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
