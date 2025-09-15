using Lead.CPrim.Interfaces.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.MachineHelper
{
    public abstract class SystemStateMachine : StateMachineBase
    {
        #region Prop
        /// <summary>
        /// 手自动状态机
        /// </summary>
        public IStateMachine AutoSm { get; protected set; }

        /// <summary>
        /// 系统状态机
        /// </summary>
        public Dictionary<string, IStateMachine> taskSms { get; protected set; }
        #endregion



        #region MethodOverride
        /// <summary>
        /// 发送命令（3）<br/>
        /// </summary>
        /// <param name="e"></param>
        public override void HandleEvent(UserEvent e)
        {
            base.HandleEvent(e);
            switch (e.EventType)
            {
                case UserEventType.ESTOP:
                    SendToAllSMs(e);
                    break;
                case UserEventType.ESTOPOFF:
                    SendToAllSMs(e);
                    break;
                case UserEventType.START:
                    if (AutoSm.State == SmStates.Auto)
                    {
                        SendToSm(e);
                    }
                    break;
                case UserEventType.STOP:
                    SendToSm(e);
                    break;
                case UserEventType.RESET:
                    if (AutoSm.State == SmStates.Auto)
                    {
                        SendToSm(e);
                    }
                    break;
                case UserEventType.ClrErr:
                    SendToSm(e);
                    break;
                case UserEventType.Abnormal:
                    SendToSm(e);
                    break;
                case UserEventType.NoErr:
                    SendToSm(e);
                    break;
                case UserEventType.PAUSE:
                    SendToSm(e);
                    break;
                case UserEventType.CONTINUE:
                    if (AutoSm.State == SmStates.Auto)
                    {
                        SendToSm(e);
                    }
                    break;
                case UserEventType.PrimErr:
                    SendToSm(e);
                    break;
                case UserEventType.Auto:
                    SendToSm(e);
                    break;
                case UserEventType.Manual:
                    SendToSm(e);
                    SendToAllSMs(new UserEvent
                    {
                        EventSender = e.EventSender,
                        EventType = UserEventType.PAUSE
                    });
                    break;
                case UserEventType.Local:
                    SendToSm(e);
                    break;
                case UserEventType.Remote:
                    SendToSm(e);
                    break;
                case UserEventType.RunningWithNotice:
                    SendToSm(e);
                    break;
                case UserEventType.Idle:
                    SendToSm(e);
                    break;
            }
        }

        /// <summary>
        /// 系统状态机初始化[2]<br/>
        /// 系统状态机以及手自动状态机<br/>
        /// </summary>
        /// <param name="obj"></param>
        public override void Initialize(object obj)
        {
            base.Name = "SystemSM";
            taskSms.Values.ToList().ForEach(delegate (IStateMachine p)
            {
                p.systemSM = (IStateMachine)(object)this;
            });
            AutoSm.systemSM = (IStateMachine)(object)this;
            AutoSm.Initialize((object)null);
            base.IsRunning = true;
            base.Initialize(obj);
        }
        #endregion



        #region MethodInternalUsing

        private void SendToAllSMs(UserEvent e)
        {
            taskSms.Values.ToList().ForEach(delegate (IStateMachine p)
            {
                p.PostEvent(new UserEvent
                {
                    EventSender = e.EventSender,
                    EventType = e.EventType,
                    EventTarget = (IEventHandler)(object)p
                });
            });
            AutoSm.PostEvent(new UserEvent
            {
                EventSender = e.EventSender,
                EventType = e.EventType,
                EventTarget = (IEventHandler)(object)AutoSm
            });
        }

        /// <summary>
        /// 发送命令（4）<br/>
        /// </summary>
        /// <param name="e"></param>
        private void SendToSm(UserEvent e)
        {
            if (e.EventSender == this)
            {
                SendToAllSMs(e);
                return;
            }
            e.EventTarget = (IEventHandler)(object)e.EventSender;
            e.EventSender.PostEvent(e);
        }
        #endregion
    }
}
