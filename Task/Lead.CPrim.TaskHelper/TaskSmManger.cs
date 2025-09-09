using System.Collections.Generic;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.TaskHelper
{
    public class TaskSmManger
    {
        #region Field
        public static TaskSmManger Instance = new TaskSmManger();

        public Dictionary<string, IStateMachine> TaskSMs;
        #endregion



        #region Ctor
        private TaskSmManger()
        {
            EventManager.OnSwitchStatus += InstanceSwitchStatus;
        }
        #endregion



        #region MethodOverride
        private void InstanceSwitchStatus(SwitchStatus status)
        {
            var stationName = GlobalVariables.CurrentStationName;
            if (string.IsNullOrWhiteSpace(stationName))
            {
                return;
            }

            switch (status)
            {
                case SwitchStatus.ClrErr:
                    if (TaskSMs.ContainsKey(stationName))
                    {
                        ((TaskStateMachine)TaskSMs[stationName]).ClrErr();
                    }
                    break;
                case SwitchStatus.Abnormal:
                    if (TaskSMs.ContainsKey(stationName))
                    {
                        ((TaskStateMachine)TaskSMs[stationName]).Abnormal();
                    }
                    break;
                case SwitchStatus.RunningWithNotice:
                    if (TaskSMs.ContainsKey(stationName))
                    {
                        ((TaskStateMachine)TaskSMs[stationName]).RunningWithNotice();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion



        #region MethodExternalUsing
        public int Add(string station)
        {
            if (string.IsNullOrEmpty(station))
            {
                return -5;
            }
            if (TaskSMs.ContainsKey(station))
            {
                return -6;
            }
            TaskStationMachine value = new TaskStationMachine
            {
                Name = station
            };
            TaskSMs.Add(station, (IStateMachine)value);
            return 0;
        }

        public int Init(string[] stations)
        {
            if (stations == null || stations.Length < 1)
            {
                return -5;
            }
            TaskSMs = new Dictionary<string, IStateMachine>();
            foreach (string text in stations)
            {
                int ret = Add(text);
                if (ret != 0)
                {
                    return ret;
                }
            }
            return 0;
        }

        public int Remove(string station)
        {
            if (string.IsNullOrEmpty(station))
            {
                return -5;
            }
            if (TaskSMs == null || TaskSMs.Count < 1 || !TaskSMs.ContainsKey(station))
            {
                return -1;
            }
            TaskSMs[station].Terminate();
            if (TaskSMs.Remove(station))
            {
                return 0;
            }
            return -7;
        }
        #endregion
    }
}
