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
        public IStateMachine AutoSm { get; protected set; }

        public Dictionary<string, IStateMachine> taskSms { get; protected set; }

        public override void HandleEvent(UserEvent e)
        {
            base.HandleEvent(e);
            UserEventType eventType = e.EventType;
            UserEventType val = eventType;
            switch ((int)val)
            {
                case 0:
                    SendToAllSMs(e);
                    break;
                case 1:
                    SendToAllSMs(e);
                    break;
                case 2:
                    if ((int)AutoSm.State == 8)
                    {
                        SendToSm(e);
                    }
                    break;
                case 3:
                    SendToSm(e);
                    break;
                case 4:
                    if ((int)AutoSm.State == 8)
                    {
                        SendToSm(e);
                    }
                    break;
                case 5:
                    SendToSm(e);
                    break;
                case 6:
                    SendToSm(e);
                    break;
                case 7:
                    SendToSm(e);
                    break;
                case 8:
                    SendToSm(e);
                    break;
                case 9:
                    if ((int)AutoSm.State == 8)
                    {
                        SendToSm(e);
                    }
                    break;
                case 10:
                    SendToSm(e);
                    break;
                case 11:
                    SendToSm(e);
                    break;
                case 12:
                    SendToSm(e);
                    SendToAllSMs(new UserEvent
                    {
                        EventSender = e.EventSender,
                        EventType = (UserEventType)8
                    });
                    break;
                case 13:
                    SendToSm(e);
                    break;
                case 14:
                    SendToSm(e);
                    break;
                // 新增20250907
                case 16:
                    SendToSm(e);
                    break;
            }
        }

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
    }
}
