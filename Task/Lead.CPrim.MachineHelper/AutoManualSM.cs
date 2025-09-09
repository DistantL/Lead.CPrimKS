using System.Collections.Concurrent;
using Lead.CPrim.Interfaces.StateMachine;

namespace Lead.CPrim.MachineHelper
{
    public abstract class AutoManualSM : StateMachineBase
    {
        private readonly ConcurrentPriorityQueue<int, UserEvent> priorityQueueEvents = new ConcurrentPriorityQueue<int, UserEvent>();

        public override void ChangeState(SmStates sta)
        {
            PostEvent((UserEventType)8, (IEventHandler)(object)base.systemSM);
            base.ChangeState(sta);
        }

        public virtual bool CheckSwitchButton()
        {
            if ((int)base.State == 8)
            {
                return true;
            }
            return false;
        }

        public override void HandleEvent(UserEvent e)
        {
            base.HandleEvent(e);
            SmStates state = base.State;
            SmStates val = state;
            if ((int)val != 8)
            {
                if ((int)val == 9 && (int)e.EventType == 11)
                {
                    ChangeState((SmStates)8);
                }
            }
            else if ((int)e.EventType == 12)
            {
                ChangeState((SmStates)9);
            }
        }

        public override void Initialize(object obj)
        {
            base.Name = "AutoSM";
            base.State = (SmStates)8;
            base.LastState = (SmStates)9;
            base.Initialize(obj);
        }

        public override void runSmLoop()
        {
            SmStates state = base.State;
            SmStates val = state;
            if ((int)val != 8)
            {
                if ((int)val == 9 && CheckSwitchButton())
                {
                    PostEvent((UserEventType)11, (IEventHandler)(object)base.systemSM);
                }
            }
            else if (!CheckSwitchButton())
            {
                PostEvent((UserEventType)12, (IEventHandler)(object)base.systemSM);
            }
        }

        public virtual void ToAutoMode()
        {
            PostEvent((UserEventType)11, (IEventHandler)(object)base.systemSM);
        }

        public virtual void ToManualMode()
        {
            PostEvent((UserEventType)12, (IEventHandler)(object)base.systemSM);
        }
    }
}
