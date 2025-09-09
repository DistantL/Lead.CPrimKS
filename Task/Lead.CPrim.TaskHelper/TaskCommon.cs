using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ProxyTools.Win32;
using Lead.CPrim.StationCommon;

namespace Lead.CPrim.TaskHelper
{
    public class TaskCommon
    {
        #region Field
        private readonly long _abnormalDiMidId;

        private readonly long _eleErrorMidId;

        private readonly long _eleInitMidId;

        private readonly long _eleNotFountMidId;

        private readonly long _estopDiMidId;

        private readonly long _primErrorMidId;

        private readonly long _primInitMidId;

        private readonly long _primNotFountMidId;

        private readonly StationConfig _station;

        private int _eleInitId = 1;

        private int _primInitId = 1;

        private List<IPrim> Prims;

        private List<IEle> Eles;
        #endregion



        #region Prop
        public ConcurrentDictionary<string, IMotionCard> PrimMotionCard { get; }

        public ConcurrentDictionary<string, IVpAssemble> PrimAssemble { get; }

        public ConcurrentDictionary<string, IVpDetector> PrimDetector { get; }

        public ConcurrentDictionary<string, ISuperClient> PrimStationClient { get; }

        public ConcurrentDictionary<string, ISuperServer> PrimStationServer { get; }

        public ConcurrentDictionary<string, ISql> PrimSqlInServer { get; }

        public ConcurrentDictionary<string, IEleCartesian> Cartesians { get; }

        public ConcurrentDictionary<string, IEleCyldLine> Cylinder { get; }

        public ConcurrentDictionary<string, IEleDO> DoLed { get; }

        public ConcurrentDictionary<string, IEleLight> DoSysLight { get; }

        public ConcurrentDictionary<string, IEleCyldLine> Vaccum { get; }

        public ConcurrentDictionary<string, IEleDI> DiPauseSignal { get; }

        public ConcurrentDictionary<string, IEleDI> DiStart { get; }

        public ConcurrentDictionary<string, IEleDI> DiPause { get; }

        public ConcurrentDictionary<string, IEleDI> DiStop { get; }

        public ConcurrentDictionary<string, IEleDI> DiReset { get; }

        public ConcurrentDictionary<string, IEleDI> DiAuto { get; }

        public ConcurrentDictionary<string, IEleDI> DiLock { get; }

        public ConcurrentDictionary<string, IEleDI> DiEmg { get; }

        public ConcurrentDictionary<string, IEleDI> FrontRuning { get; }

        public ConcurrentDictionary<string, IEleDI> BackRunging { get; }

        public ConcurrentDictionary<string, IEleDO> Running { get; }
        #endregion



        #region MethodExternalUsing
        public void ElesAdd()
        {
            if (_station == null)
            {
                return;
            }

            foreach (EleMember value in _station.CurrentRecipe.Eles.Values)
            {
                IEle ele = ElesManagerTransfer.GetEleByName(value.EleName);
                if (ele == null)
                {
                    continue;
                }

                Eles.Add(ele);
                switch (value.EleType)
                {
                    case EleMemberType.Cartesian:
                        if (ele is IEleCartesian)
                        {
                            Cartesians[ele.Name] = (IEleCartesian)ele;
                        }
                        break;

                    case EleMemberType.CyldLine:
                        if (ele is IEleCyldLine)
                        {
                            Cylinder[ele.Name] = (IEleCyldLine)ele;
                        }
                        break;

                    case EleMemberType.Led:
                        if (ele is IEleDO)
                        {
                            DoLed[ele.Name] = (IEleDO)ele;
                        }
                        break;

                    case EleMemberType.SysLight:
                        if (ele is IEleLight)
                        {
                            DoSysLight[ele.Name] = (IEleLight)ele;
                        }
                        break;

                    case EleMemberType.Vacuum:
                        if (ele is IEleCyldLine)
                        {
                            Vaccum[ele.Name] = (IEleCyldLine)ele;
                        }
                        break;

                    case EleMemberType.AbnormalDI:
                        if (ele is IEleDI)
                        {
                            DiPauseSignal[ele.Name] = (IEleDI)ele;
                        }
                        break;

                    case EleMemberType.START:
                        if (ele is IEleDI)
                        {
                            DiStart[ele.Name] = (IEleDI)ele;
                        }
                        break;

                    case EleMemberType.PAUSE:
                        if (ele is IEleDI)
                        {
                            DiPause[ele.Name] = (IEleDI)ele;
                        }
                        break;

                    case EleMemberType.STOP:
                        if (ele is IEleDI)
                        {
                            DiStop[ele.Name] = (IEleDI)ele;
                        }
                        break;

                    case EleMemberType.RESET:
                        if (ele is IEleDI)
                        {
                            DiReset[ele.Name] = (IEleDI)ele;
                        }
                        break;

                    case EleMemberType.AUTO:
                        if (ele is IEleDI)
                        {
                            DiAuto[ele.Name] = (IEleDI)ele;
                        }
                        break;

                    case EleMemberType.LOCK:
                        if (ele is IEleDI)
                        {
                            DiLock[ele.Name] = (IEleDI)ele;
                        }
                        break;

                    case EleMemberType.EMG:
                        if (ele is IEleDI)
                        {
                            DiEmg[ele.Name] = (IEleDI)ele;
                        }
                        break;

                    case EleMemberType.DI:
                    case EleMemberType.DO:
                    case EleMemberType.Other:
                        break;
                }
            }
        }

        public void PrimsAdd()
        {
            if (_station == null)
            {
                return;
            }
            foreach (PrimMember value in _station.CurrentRecipe.Prims.Values)
            {
                IPrim prim = PrimsManagerTransfer.GetPrimByName(value.PrimName);
                if (prim != null)
                {
                    Prims.Add(prim);
                    switch (value.PrimType)
                    {
                        case PrimMemberType.MotionCard:
                            PrimMotionCard[value.PrimName] = (IMotionCard)prim;
                            break;

                        case PrimMemberType.VpAssemble:
                            PrimAssemble[value.PrimName] = (IVpAssemble)prim;
                            break;

                        case PrimMemberType.VpDetector:
                            PrimDetector[value.PrimName] = (IVpDetector)prim;
                            break;

                        case PrimMemberType.StationClient:
                            PrimStationClient[value.PrimName] = (ISuperClient)prim;
                            break;

                        case PrimMemberType.StationServer:
                            PrimStationServer[value.PrimName] = (ISuperServer)prim;
                            break;

                        case PrimMemberType.SqlInServer:
                            PrimSqlInServer[value.PrimName] = (ISql)prim;
                            break;

                        case PrimMemberType.Robot:
                        case PrimMemberType.Protocol:
                        case PrimMemberType.Vision:
                        case PrimMemberType.Sql:
                        case PrimMemberType.Other:
                            break;
                    }
                }
            }
        }

        private void StationOnRemoveAbnormalDi(IEle ele, EleMemberType oldType, EleMemberType newType)
        {
            if (ele is IEleDI)
            {
                DiPauseSignal.TryRemove(ele.Name, out _);
            }
        }

        private void StationOnAddAbnormalDi(IEle ele, EleMemberType oldType, EleMemberType newType)
        {
            if (ele is IEleDI)
            {
                DiPauseSignal[ele.Name] = (IEleDI)ele;
            }
        }

        private void StationOnChangeEleItemType(IEle ele, EleMemberType oldType, EleMemberType newType)
        {
            switch (oldType)
            {
                case EleMemberType.Cartesian:
                    if (ele is IEleCartesian)
                    {
                        Cartesians.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.CyldLine:
                    if (ele is IEleCyldLine)
                    {
                        Cylinder.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.Led:
                    if (ele is IEleDO)
                    {
                        DoLed.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.DI:
                    break;

                case EleMemberType.DO:
                    break;

                case EleMemberType.SysLight:
                    if (ele is IEleLight)
                    {
                        DoSysLight.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.Vacuum:
                    if (ele is IEleCyldLine)
                    {
                        Vaccum.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.AbnormalDI:
                    if (ele is IEleDI)
                    {
                        DiPauseSignal.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.START:
                    if (ele is IEleDI)
                    {
                        DiStart.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.PAUSE:
                    if (ele is IEleDI)
                    {
                        DiPause.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.STOP:
                    if (ele is IEleDI)
                    {
                        DiStop.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.RESET:
                    if (ele is IEleDI)
                    {
                        DiReset.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.AUTO:
                    if (ele is IEleDI)
                    {
                        _ = DiAuto.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.LOCK:
                    if (ele is IEleDI)
                    {
                        DiLock.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.EMG:
                    if (ele is IEleDI)
                    {
                        DiEmg.TryRemove(ele.Name, out _);
                    }
                    break;

                case EleMemberType.Other:
                    break;
            }

            switch (newType)
            {
                case EleMemberType.Cartesian:
                    if (ele is IEleCartesian)
                    {
                        Cartesians[ele.Name] = (IEleCartesian)ele;
                    }
                    break;

                case EleMemberType.CyldLine:
                    if (ele is IEleCyldLine)
                    {
                        Cylinder[ele.Name] = (IEleCyldLine)ele;
                    }
                    break;

                case EleMemberType.Led:
                    if (ele is IEleDO)
                    {
                        DoLed[ele.Name] = (IEleDO)ele;
                    }
                    break;

                case EleMemberType.DI:
                    break;

                case EleMemberType.DO:
                    break;

                case EleMemberType.SysLight:
                    if (ele is IEleLight)
                    {
                        DoSysLight[ele.Name] = (IEleLight)ele;
                    }
                    break;

                case EleMemberType.Vacuum:
                    if (ele is IEleCyldLine)
                    {
                        Vaccum[ele.Name] = (IEleCyldLine)ele;
                    }
                    break;

                case EleMemberType.AbnormalDI:
                    if (ele is IEleDI)
                    {
                        DiPauseSignal[ele.Name] = (IEleDI)ele;
                    }
                    break;

                case EleMemberType.START:
                    if (ele is IEleDI)
                    {
                        DiStart[ele.Name] = (IEleDI)ele;
                    }
                    break;

                case EleMemberType.PAUSE:
                    if (ele is IEleDI)
                    {
                        DiPause[ele.Name] = (IEleDI)ele;
                    }
                    break;

                case EleMemberType.STOP:
                    if (ele is IEleDI)
                    {
                        DiStop[ele.Name] = (IEleDI)ele;
                    }
                    break;

                case EleMemberType.RESET:
                    if (ele is IEleDI)
                    {
                        DiReset[ele.Name] = (IEleDI)ele;
                    }
                    break;

                case EleMemberType.AUTO:
                    if (ele is IEleDI)
                    {
                        DiAuto[ele.Name] = (IEleDI)ele;
                    }
                    break;

                case EleMemberType.LOCK:
                    if (ele is IEleDI)
                    {
                        DiLock[ele.Name] = (IEleDI)ele;
                    }
                    break;

                case EleMemberType.EMG:
                    if (ele is IEleDI)
                    {
                        DiEmg[ele.Name] = (IEleDI)ele;
                    }
                    break;

                case EleMemberType.Other:
                    break;
            }
        }

        public TaskCommon(StationConfig station)
        {
            _station = station;
            _primInitMidId = 1000L;
            _eleInitMidId = 1100L;
            _primNotFountMidId = 3000L;
            _primErrorMidId = 3100L;
            _eleNotFountMidId = 3200L;
            _eleErrorMidId = 4000L;
            _abnormalDiMidId = 5000L;
            _estopDiMidId = 100L;
            PrimMotionCard = new ConcurrentDictionary<string, IMotionCard>();
            PrimStationServer = new ConcurrentDictionary<string, ISuperServer>();
            PrimStationClient = new ConcurrentDictionary<string, ISuperClient>();
            PrimSqlInServer = new ConcurrentDictionary<string, ISql>();
            PrimAssemble = new ConcurrentDictionary<string, IVpAssemble>();
            PrimDetector = new ConcurrentDictionary<string, IVpDetector>();
            DiStart = new ConcurrentDictionary<string, IEleDI>();
            DiStop = new ConcurrentDictionary<string, IEleDI>();
            DiPause = new ConcurrentDictionary<string, IEleDI>();
            DiReset = new ConcurrentDictionary<string, IEleDI>();
            DiAuto = new ConcurrentDictionary<string, IEleDI>();
            DiEmg = new ConcurrentDictionary<string, IEleDI>();
            DiLock = new ConcurrentDictionary<string, IEleDI>();
            DiPauseSignal = new ConcurrentDictionary<string, IEleDI>();
            DoSysLight = new ConcurrentDictionary<string, IEleLight>();
            DoLed = new ConcurrentDictionary<string, IEleDO>();
            FrontRuning = new ConcurrentDictionary<string, IEleDI>();
            BackRunging = new ConcurrentDictionary<string, IEleDI>();
            Running = new ConcurrentDictionary<string, IEleDO>();
            Cartesians = new ConcurrentDictionary<string, IEleCartesian>();
            Cylinder = new ConcurrentDictionary<string, IEleCyldLine>();
            Vaccum = new ConcurrentDictionary<string, IEleCyldLine>();
            Prims = new List<IPrim>();
            Eles = new List<IEle>();
            PrimsAdd();
            ElesAdd();
            _station.OnChangeEleItemType += new Del_ChangeEleItemType(StationOnChangeEleItemType);
            _station.OnAddAbnormalDi += new Del_ChangeEleItemType(StationOnAddAbnormalDi);
            _station.OnRemoveAbnormalDi += new Del_ChangeEleItemType(StationOnRemoveAbnormalDi);
        }
        /// <summary>
        /// 报警检查<br/>
        /// 0：OK；<br/>
        /// -2：元件报警中；<br/>
        /// -3：AbnormalDI报警中；<br/>
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public int CheckAbnormal(out string errMsg)
        {
            errMsg = "";
            foreach (IEle ele in Eles)
            {
                if (CheckEle(ele) != 0)
                {
                    errMsg = $"元件{ele.Info}报警中";
                    return -2;
                }
            }

            foreach (var emg in DiPauseSignal)
            {
                if (emg.Value.Read())
                {
                    if (emg.Value is IEle ele)
                    {
                        errMsg = $"{ele.Info}信号触发";
                    }
                    return -3;
                }
            }

            return 0;
        }

        /// <summary>
        /// 元件检查<br/>
        /// 0：OK；<br/>
        /// -1：报警中；<br/>
        /// -2：元件不存在；<br/>
        /// </summary>
        /// <param name="ele"></param>
        /// <returns></returns>
        public int CheckEle(IEle ele)
        {
            if (ele != null)
            {
                if (ele.EleRunStat == EleRunState.Err)
                {
                    return -1;
                }

                return 0;
            }

            return -2;
        }
        /// <summary>
        /// 基元检查<br/>
        /// 0：OK；<br/>
        /// -1：不在运行中；<br/>
        /// -2：基元不存在；<br/>
        /// </summary>
        /// <param name="prim"></param>
        /// <returns></returns>
        public int CheckPrim(IPrim prim)
        {
            if (prim != null)
            {
                if (prim.PrimRunStat != PrimRunState.Running)
                {
                    return -1;
                }
                return 0;
            }
            return -2;
        }
        /// <summary>
        /// 基元检查<br/>
        /// True：检查通过；<br/>
        /// False：检查不通过；<br/>
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool CheckPrim(out string errMsg)
        {
            errMsg = "";
            foreach (IPrim prim in Prims)
            {
                if (CheckPrim(prim) != 0)
                {
                    errMsg = $"{prim.Name}未运行";
                    return false;
                }
            }
            return true;
        }

        public string DicToString_Socket(Dictionary<string, string> resultItems)
        {
            if (resultItems.Count < 1)
            {
                return null;
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> resultItem in resultItems)
            {
                stringBuilder.Append(resultItem.Key + ":");
                stringBuilder.Append(resultItem.Value);
                stringBuilder.Append(";");
            }
            return stringBuilder.ToString();
        }

        public bool Find<T>(string name, ref T obj) where T : class
        {
            switch (typeof(T).Name)
            {
                case "IPrim":
                    obj = PrimsManagerTransfer.GetPrimByName(name) as T;
                    if (obj == null)
                    {
                        LogAdd("获取IPrim -> " + name + "为空", (LogLevel)3, 0L);
                        return false;
                    }
                    return true;
                case "IEle":
                    obj = ElesManagerTransfer.GetEleByName(name) as T;
                    if (obj == null)
                    {
                        LogAdd("获取IEle -> " + name + "为空", (LogLevel)3, 0L);
                        return false;
                    }
                    return true;
                case "IShow":
                    obj = ShowManagerTransfer.GetShowByName(name) as T;
                    if (obj == null)
                    {
                        LogAdd("获取IShow -> " + name + "为空", (LogLevel)3, 0L);
                        return false;
                    }
                    return true;
                case "ITask":
                    obj = TasksManagerTransfer.GetTaskByName(name) as T;
                    if (obj == null)
                    {
                        LogAdd("获取ITask -> " + name + "为空", (LogLevel)3, 0L);
                        return false;
                    }
                    return true;
                default:
                    obj = null;
                    return false;
            }
        }

        public bool FindElement<T>(string name, ref T obj)
        {
            try
            {
                obj = (T)(object)ElesManagerTransfer.GetEleByName(name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FindPrim<T>(string name, ref T obj)
        {
            try
            {
                obj = (T)(object)PrimsManagerTransfer.GetPrimByName(name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FindPrims(string[] str, IPrim[] prims)
        {
            if (str.Length != prims.Length)
            {
                MessageBox.Show(NLocalizer.GetString("TaskHelper_SystemFunction_PrimsNumberIsInconsistent", "The number of prims is inconsistent, please check."));
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (!Find(str[i], ref prims[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool FindShow<T>(string name, ref T obj)
        {
            try
            {
                obj = (T)(object)ShowManagerTransfer.GetShowByName(name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FindShows(string[] str, IShow[] shows)
        {
            if (str.Length != shows.Length)
            {
                MessageBox.Show("给定的显示基元的数目不一致");
                return false;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (!Find(str[i], ref shows[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Init<T>(T obj) where T : class
        {
            string name = typeof(T).Name;
            string text = name;
            if (!(text == "IPrim"))
            {
                if (text == "IEle")
                {
                    IEle val = (IEle)obj;
                    if (val.IEleInit() == 0)
                    {
                        LogAdd(string.Format(NLocalizer.GetString("TaskHelper_SystemFunction_InitiatedSuccessfully", "{0} Initiated successfully."), val.Name), (LogLevel)4, _eleInitMidId + _eleInitId++);
                        return true;
                    }
                    LogAdd(string.Format(NLocalizer.GetString("TaskHelper_SystemFunction_InitiatedFailed", "{0} Initiated failed."), val.Name), (LogLevel)2, _eleInitMidId + _eleInitId++);
                    return false;
                }
                return false;
            }
            IPrim val2 = (IPrim)obj;
            if (val2.IPrimTaskInit() == 0)
            {
                LogAdd(string.Format(NLocalizer.GetString("TaskHelper_SystemFunction_InitiatedSuccessfully", "{0} Initiated successfully."), val2.Name), (LogLevel)4, _primInitMidId + _primInitId++);
                return true;
            }
            LogAdd(string.Format(NLocalizer.GetString("TaskHelper_SystemFunction_InitiatedFailed", "{0} Initiated failed."), val2.Name), (LogLevel)2, _primInitMidId + _primInitId++);
            return false;
        }

        public void LogAdd(string msg, LogLevel lv, long id = 0L, bool isShowDialog = false)
        {
            msg = "TaskHelper -> " + msg;
            string tempId = $"{(int)lv}{610}0000";
            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.TaskHelper.ToString(), LogClassification.Task, id);
            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }

        public int ResetAbnormal()
        {
            foreach (IPrim prim in Prims)
            {
                if (prim.PrimRunStat != PrimRunState.Running)
                {
                    prim.IPrimTaskReset();
                }
            }
            foreach (IEle ele in Eles)
            {
                if (ele.EleRunStat == EleRunState.Err)
                {
                    ele.IEleReset();
                }
            }
            return 0;
        }
        #endregion
    }
}
