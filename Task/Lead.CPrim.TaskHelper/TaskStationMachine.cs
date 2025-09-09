using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.StationCommon;
using Lead.CPrim.StationCommon.Recipe;

namespace Lead.CPrim.TaskHelper
{
    public class TaskStationMachine : TaskStateMachine
    {
        public SingleRecipeCfg _currentRecipe;

        public StationConfig _station;

        public TaskCommon TaskFuncCommon;

        private DateTime dtRestButtonLastTime = DateTime.Now;

        private DateTime _clrBtnPushTim = DateTime.Now;

        private Task _task;

        public Guid Gid { get; set; }

        public TaskStationMachine()
        {
            Gid = Guid.NewGuid();
        }

        public override void ChangeState(SmStates sta)
        {
            base.ChangeState(sta);
            switch (sta)
            {
                case SmStates.WaitReset:
                    ChangeUIState("等待复位");
                    RefreshOperate("请确认机台安全后，执行复位操作", true, PriorityLevel.Task);
                    break;
                case SmStates.Resetting:
                    ChangeUIState("复位中");
                    RefreshOperate("复位执行中，请等待...", true, PriorityLevel.Task);
                    break;
                case SmStates.WaitRun:
                    ChangeUIState("等待运行");
                    RefreshOperate("复位完成，请按开始按钮...", true, PriorityLevel.Task);
                    break;
                case SmStates.Running:
                    ChangeUIState(RunningStateMessage);
                    RefreshOperate("运行中", false, PriorityLevel.Task);
                    break;
                case SmStates.Pause:
                    ChangeUIState("暂停");
                    RefreshOperate("如要继续执行，请按开始按钮...", true, PriorityLevel.Task);
                    break;
                case SmStates.WaitEStopClr:
                    ChangeUIState("急停被按下！");
                    RefreshOperate("请弹出急停后，按下清报警按钮", true, PriorityLevel.Task);
                    break;
                case SmStates.WaitClrPrimErr:
                    ChangeUIState("硬件报错！");
                    RefreshOperate("按清报警尝试清除...", true, PriorityLevel.Task);
                    break;
                case SmStates.WaitClrErr:
                    ChangeUIState("等待确认报警");
                    RefreshOperate("确认报警后，按下清除报警按钮", true, PriorityLevel.Task);
                    break;
            }
        }

        public override void Terminate()
        {
            base.Terminate();
            TaskFuncCommon?.DoSysLight?.ToList().ForEach(delegate (KeyValuePair<string, IEleLight> d)
            {
                d.Value.AllOff();
            });
            if (Tasks.Count > 0)
            {
                foreach (StationTask value in Tasks.Values)
                {
                    ITask taskByName = TasksManagerTransfer.GetTaskByName(value.TaskName);
                    taskByName?.ITaskDispose();
                }
            }
            ChangeUIState("未初始化");
            RefreshOperate("系统被终止，如需启动请执行初始化操作...", isTw: true, PriorityLevel.System);
        }

        public override void Initialize(object station)
        {
            try
            {
                ChangeUIState("初始化中");
                RefreshOperate("正在初始化...", true, PriorityLevel.Task);
                _station = (StationConfig)station;
                TaskFuncCommon = new TaskCommon(_station);
                _currentRecipe = _station.CurrentRecipe;
                Tasks.Clear();
                TasksManagerTransfer.ClearRunningITask();
                int num = 0;
                if (SysMemberInit() != 0)
                {
                    throw new Exception(_station.Name + "的 基元配置 初始化失败！");
                }
                foreach (KeyValuePair<int, TaskMember> task in _currentRecipe.Tasks)
                {
                    TaskMember value = task.Value;
                    ITask taskByName = TasksManagerTransfer.GetTaskByName(value.TaskName);
                    if (taskByName != null)
                    {
                        TasksManagerTransfer.AddTask(taskByName);
                        ((StationTask)(object)taskByName).Machine = this;
                        ((StationTask)(object)taskByName).TaskEnable = true;
                        ((StationTask)(object)taskByName).TaskName = taskByName.Name;
                        Tasks.TryAdd(num++, (StationTask)(object)taskByName);
                        if (taskByName.ITaskInit() != 0)
                        {
                            throw new Exception($"脚本 {taskByName.Name} 初始化出错");
                        }
                    }
                }
                //if (initResult != 0)
                //{
                //	throw new Exception("脚本INIT初始化出错");
                //}
                TaskFuncCommon.DoSysLight?.ToList().ForEach(delegate (KeyValuePair<string, IEleLight> d)
                {
                    d.Value.AllOff();
                });
                _machineInitSucess = true;
            }
            catch (Exception ex)
            {
                _machineInitSucess = false;
                UIMessageDialog.ShowMessageDialog("初始化出错：" + ex.Message, ULocalize.ErrorTitle, false, (UIStyle)4, false, true);
            }
            base.Initialize(_currentRecipe);
            if (_machineInitSucess)
            {
                ChangeUIState("等待复位");
                RefreshOperate("初始化完成,请确保安全后，按下复位进行复位操作...", isTw: true, (PriorityLevel)1);
            }
            else
            {
                ChangeUIState("初始化失败");
                RefreshOperate("初始化失败,请确认原因后，按下初始化再次进行初始化操作...", isTw: true, (PriorityLevel)1);
            }
        }

        public override bool CheckNoEStop()
        {
            if (TaskFuncCommon == null)
            {
                Initialize(_station);
            }

            if (TaskFuncCommon.DiEmg.IsEmpty)
            {
                return true;
            }

            bool flag = true;
            foreach (var emg in TaskFuncCommon.DiEmg)
            {
                if (emg.Value.Read())
                {
                    if (emg.Value is IEle ele)
                    {
                        OnShowAlarmEvent($"{ele.Info}信号触发", LogLevel.Warn);
                    }
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        public override bool CheckPrim()
        {
            bool flag = TaskFuncCommon.CheckPrim(out string errMsg);
            if (!flag)
            {
                OnShowAlarmEvent(errMsg, LogLevel.Warn);
            }
            return flag;
        }

        public override int CheckAbnormal()
        {
            // 防止频繁弹窗
            // 不再监控报警的情况：
            // 1、发生报警
            // 2、发生急停
            // 3、待复位
            // 4、手动
            if (State == SmStates.WaitClrErr
                || State == SmStates.WaitClrPrimErr
                || State == SmStates.WaitEStopClr
                || State == SmStates.WaitReset
                || AutoManualStationSM.Instance.State == SmStates.Manual)
            {
                return 0;
            }

            int num = TaskFuncCommon.CheckAbnormal(out string errMsg);
            if (num != 0)
            {
                OnShowAlarmEvent(errMsg, LogLevel.Warn);
            }
            return num;
        }

        public override bool CheckStopSignal()
        {
            if (TaskFuncCommon == null)
            {
                Initialize(_station);
            }

            if (TaskFuncCommon.DiStop.IsEmpty)
            {
                return false;
            }

            bool flag = false;
            foreach (var stop in TaskFuncCommon.DiStop)
            {
                if (stop.Value.Read())
                {
                    if (stop.Value is IEle ele)
                    {
                        OnShowAlarmEvent($"{ele.Info}信号触发", LogLevel.Warn);
                    }
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        public override bool CheckPauseSignal()
        {
            bool flag = false;
            flag = !TaskFuncCommon.DiPause.IsEmpty && TaskFuncCommon.DiPause.Any((KeyValuePair<string, IEleDI> e) => e.Value.Read());
            if (!flag)
            {
                return flag;
            }
            KeyValuePair<string, IEleDI> keyValuePair = TaskFuncCommon.DiPause.FirstOrDefault((KeyValuePair<string, IEleDI> p) => p.Value.Read());
            return flag;
        }

        public override bool CheckStartSignal()
        {
            bool flag = false;
            flag = !TaskFuncCommon.DiStart.IsEmpty && TaskFuncCommon.DiStart.Any((KeyValuePair<string, IEleDI> e) => e.Value.Read());
            if (!flag)
            {
                return flag;
            }
            KeyValuePair<string, IEleDI> keyValuePair = TaskFuncCommon.DiStart.FirstOrDefault((KeyValuePair<string, IEleDI> p) => p.Value.Read());
            return flag;
        }

        public override bool CheckClrErrSignal()
        {
            bool flag = false;
            flag = !TaskFuncCommon.DiReset.IsEmpty && TaskFuncCommon.DiReset.Any((KeyValuePair<string, IEleDI> e) => e.Value.Read());
            if (!flag)
            {
                return flag;
            }
            double totalMilliseconds = (DateTime.Now - _clrBtnPushTim).TotalMilliseconds;
            if (totalMilliseconds < 300.0)
            {
                return false;
            }
            _clrBtnPushTim = DateTime.Now;
            return flag;
        }

        public override int CheckManualSignal()
        {
            if (TaskFuncCommon == null)
            {
                return 0;
            }
            if (TaskFuncCommon.DiAuto.IsEmpty || TaskFuncCommon.DiAuto.Any((KeyValuePair<string, IEleDI> p) => (int)((IEle)p.Value).EleRunStat != 1 || PrimsManagerTransfer.GetPrimByName(((IEle)p.Value).DevName) == null))
            {
                return 0;
            }
            if (TaskFuncCommon.DiAuto.Any((KeyValuePair<string, IEleDI> p) => !p.Value.Read()))
            {
                return 2;
            }
            return 1;
        }

        public override void Light(bool R, bool G, bool Y, bool Bee)
        {
            foreach (KeyValuePair<string, IEleLight> item in TaskFuncCommon.DoSysLight)
            {
                item.Value.WriteRed(R);
                item.Value.WriteGreen(G);
                item.Value.WriteYellow(Y);
                item.Value.WriteBuzz(Bee);
            }
        }

        public override void OnShowAlarmEvent(string alarm, LogLevel level, bool show = true)
        {
            base.OnShowAlarmEvent(alarm, level, show);
        }

        public override int ResetAbnormal()
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = now - dtRestButtonLastTime;
            dtRestButtonLastTime = now;
            if (timeSpan.Milliseconds < 100)
            {
                return TaskFuncCommon.ResetAbnormal();
            }
            return TaskFuncCommon.ResetAbnormal();
        }

        public void StartOperateInstruction()
        {
            if (_task == null)
            {
                _task = new Task(RunOperateInstruction);
                _task.Start();
            }
        }

        private void RunOperateInstruction()
        {
            while (true)
            {
                Thread.Sleep(500);
            }
        }

        private int SysMemberInit()
        {
            foreach (KeyValuePair<string, IMotionCard> item in TaskFuncCommon.PrimMotionCard)
            {
                if (!TaskFuncCommon.Init((IPrim)item.Value))
                {
                    throw new Exception(_station.Name + "的运动控制卡基元初始化失败，请检查！");
                }
            }
            foreach (PrimMember value in _station.CurrentRecipe.Prims.Values)
            {
                try
                {
                    IPrim primByName = PrimsManagerTransfer.GetPrimByName(value.PrimName);
                    if (!TaskFuncCommon.Init(primByName))
                    {
                        MessageBox.Show(_station.Name + "：" + NLocalizer.GetString("TaskHelper_SystemFunction_PrimsCannotInitiated", "Other Prims can't be initiated."));
                        return 3;
                    }
                }
                catch
                {
                    MessageBox.Show("Init Prims Err PrimName: " + value.PrimName);
                    return 2;
                }
            }
            foreach (EleMember value in _station.CurrentRecipe.Eles.Values)
            {
                try
                {
                    IEle eleByName = ElesManagerTransfer.GetEleByName(value.EleName);
                    if (!TaskFuncCommon.Init(eleByName))
                    {
                        MessageBox.Show(_station.Name + "：" + NLocalizer.GetString("TaskHelper_SystemFunction_ElementCannotInitiated", "Some Element can't be initiated."));
                        return 2;
                    }
                }
                catch
                {
                    MessageBox.Show("Init Element Err EleName: " + value.EleName);
                    return 2;
                }
            }
            return 0;
        }
    }
}
