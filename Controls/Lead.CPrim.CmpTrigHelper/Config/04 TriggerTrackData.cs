using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.Global;
using Lead.CPrim.MachineHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.CmpTrigHelper.ConfigClass
{
    [JsonObject(/*Could not decode attribute arguments.*/)]
    public class TriggerTrackData
    {
        #region Event_Define
        public event UiSelected OnEventSelected;
        #endregion



        #region Field
        private TriggerManager _instance;

        private Control _configUi;

        private bool _isSelected;
        #endregion



        #region Prop
        [JsonIgnore]
        public TriggerManager Instance => _instance;

        /// <summary>
        /// GUID
        /// </summary>
        public Guid Gid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 元件名称
        /// </summary>
        public string EleName { get; set; }

        /// <summary>
        /// 触发轴名称
        /// </summary>
        public string TrigAxisName { get; set; }

        /// <summary>
        /// 点位
        /// </summary>
        public ConcurrentDictionary<int, CmpPos> Poses { get; set; }

        [JsonIgnore]
        public Control ConfigUi => _configUi;

        [JsonIgnore]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    _configUi.BackColor = (value ? Color.Green : Colors.PrimaryBackColor236);
                    if (value)
                    {
                        OnEventSelected?.Invoke(this, ConfigType.Traj);
                    }
                }
            }
        }
        #endregion



        #region Ctor
        public TriggerTrackData()
        {
            Gid = Guid.NewGuid();
            Name = "";
            Id = -1;
            EleName = "";
            TrigAxisName = "";
            _instance = TriggerManager.Instance;
            _configUi = new TriggerTrack(this)
            {
                Dock = DockStyle.Top
            };
        }

        public TriggerTrackData(TriggerManager manager) : this()
        {
            _instance = manager;
        }

        public TriggerTrackData(string name, TriggerManager manager) : this(manager)
        {
            Name = name;
        }

        public TriggerTrackData(string name, int id, TriggerManager manager) : this(name, manager)
        {
            Id = id;
        }

        public TriggerTrackData(string name, int id, string eleName, string axisName, TriggerManager manager) : this(name, id, manager)
        {
            EleName = eleName;
            TrigAxisName = axisName;
        }
        #endregion



        #region Method_ExternalUsing

        public int MoveToEndTraj(int timeoutS = -1, bool asyncMode = false, ITask task = null)
        {
            IEle ele = ElesManagerTransfer.GetEleByName(EleName);
            if (ele == null)
            {
                throw new Exception(NLocalizer.EleNotExist);
            }

            return ((IEleCartesian)ele).GroupMoveAbs(Poses[3].Pos, Poses[3].Vel, 100, timeoutS, asyncMode, true, task, (EleAlarmLevel)2);
        }

        public int MoveToEndTrig(int timeoutS = -1, bool asyncMode = false, ITask task = null)
        {
            IEle ele = ElesManagerTransfer.GetEleByName(EleName);
            if (ele == null)
            {
                throw new Exception(NLocalizer.EleNotExist);
            }

            return ((IEleCartesian)ele).GroupMoveAbs(Poses[2].Pos, Poses[2].Vel, 100, timeoutS, asyncMode, true, task, (EleAlarmLevel)2);
        }

        public int MoveToStartTrig(int timeoutS = -1, bool asyncMode = false, ITask task = null)
        {
            IEle ele = ElesManagerTransfer.GetEleByName(EleName);
            if (ele == null)
            {
                throw new Exception(NLocalizer.EleNotExist);
            }

            return ((IEleCartesian)ele).GroupMoveAbs(Poses[1].Pos, Poses[1].Vel, 100, timeoutS, asyncMode, true, task, (EleAlarmLevel)2);
        }

        public int MoveToStartTraj(int timeoutS = -1, bool asyncMode = false, ITask task = null)
        {
            IEle ele = ElesManagerTransfer.GetEleByName(EleName);
            if (ele == null)
            {
                throw new Exception(NLocalizer.EleNotExist);
            }

            return ((IEleCartesian)ele).GroupMoveAbs(Poses[0].Pos, Poses[0].Vel, 100, timeoutS, asyncMode, true, task, (EleAlarmLevel)2);
        }

        public int Run(int timeoutS = -1, bool asyncMode = false, ITask task = null, string productName = null, string triggerName = null)
        {
            IEle ele = ElesManagerTransfer.GetEleByName(EleName);
            if (ele == null)
            {
                throw new Exception(NLocalizer.EleNotExist);
            }

            KeyValuePair<int, IEleAxis> axis = ((IEleCartesian)ele).Axises.FirstOrDefault((KeyValuePair<int, IEleAxis> p) => p.Value.Name == TrigAxisName);
            if (axis.Key < 0 || axis.Value == null)
            {
                throw new Exception(NLocalizer.AxisNotExist);
            }

            IPrim prim = PrimsManagerTransfer.GetPrimByName(axis.Value.DevName);
            if (prim == null)
            {
                throw new Exception(NLocalizer.PrimNotExist);
            }

            StationTask val = (StationTask)task;
            if (val != null)
            {
                val.JoinIfPause();
            }

            int ret = ((IEleCartesian)ele).GroupMoveAbs(Poses[0].Pos, Poses[0].Vel, 100, timeoutS, false, true, task, (EleAlarmLevel)1);
            if (ret != 0)
            {
                throw new Exception($"GroupMoveAbs <= {ret}");
            }

            ret = ((IEleCartesian)ele).GroupMoveAbs(Poses[3].Pos, Poses[3].Vel, 100, timeoutS, false, true, task, (EleAlarmLevel)1);
            if (ret != 0)
            {
                throw new Exception($"GroupMoveAbs <= {ret}");
            }

            //bool flag = false;
            //bool flag2 = false;
            //int num2 = 0;
            //timeoutS = ((timeoutS < 0) ? 100 : timeoutS);
            //while (num2++ <= timeoutS * 1000)
            //{
            //    if (!flag && ((IEleCartesian)ele).InLocation(Poses[1].Pos, 5))
            //    {
            //        flag = true;
            //        ((IEleCartesian)ele).GroupChangeVel(Poses[2].Vel);
            //    }
            //    if (!flag2 && ((IEleCartesian)ele).InLocation(Poses[2].Pos, 5))
            //    {
            //        flag2 = true;
            //        ((IEleCartesian)ele).GroupChangeVel(Poses[3].Vel);
            //    }
            //    if (axis.Value.IsStop && ((IEleCartesian)ele).InLocation(Poses[3].Pos))
            //    {
            //        break;
            //    }
            //    if ((int)ele.EleRunStat == 4 || ((IEleCartesian)ele).AxisHasAlarm(true) != 0)
            //    {
            //        return -5;
            //    }
            //    if (task != null)
            //    {
            //        if ((int)((StationTask)task).RunningState != 3 && (int)((StationTask)task).RunningState != 1)
            //        {
            //            ((IEleCartesian)ele).GroupStop();
            //        }
            //        if ((int)((StationTask)task).RunningState == 4 || (int)((StationTask)task).RunningState == 7)
            //        {
            //            ((IEleCartesian)ele).GroupStop();
            //            ((StationTask)task).JoinIfPause();
            //            flag = false;
            //            flag2 = false;
            //            ((IEleCartesian)ele).GroupMoveAbs(Poses[0].Pos, Poses[0].Vel, 100, timeoutS, false, true, task, (EleAlarmLevel)2);
            //            ((IEleCartesian)ele).GroupMoveAbs(Poses[3].Pos, Poses[1].Vel, 100, timeoutS, true, true, task, (EleAlarmLevel)2);
            //        }
            //    }
            //    else
            //    {
            //        Application.DoEvents();
            //    }
            //    Thread.Sleep(1);
            //}
            return 0;
        }

        /// <summary>
        /// 返回当前名称
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
