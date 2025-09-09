using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.CmpTrigHelper;

namespace Lead.CPrim.Global
{
    [JsonObject(/*Could not decode attribute arguments.*/)]
    public class TriggerPortData
    {
        #region Event_Define
        public event UiSelected OnEventSelected;
        #endregion



        #region Field
        private TriggerManager _instance;

        private Control _configUi;

        private bool _isSelected;
        #endregion



        #region prop
        [JsonIgnore]
        public TriggerManager Instance => _instance;

        /// <summary>
        /// GUID
        /// </summary>
        public Guid Gid { get; set; }

        /// <summary>
        /// 触发名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 基元类型
        /// </summary>
        public int PrimType { get; set; }

        /// <summary>
        /// 运动基元名称
        /// </summary>
        public string PrimMoveName { get; set; }

        /// <summary>
        /// 触发基元名称
        /// </summary>
        public string PrimTriggerName { get; set; }

        /// <summary>
        /// 触发脉冲
        /// </summary>
        public double TrigPulse { get; set; }

        /// <summary>
        /// 触发通道
        /// </summary>
        public int TrigChannel { get; set; }

        /// <summary>
        /// 触发模式
        /// </summary>
        public int TrigMode { get; set; }

        /// <summary>
        /// 触发表
        /// </summary>
        public string TrigTableName { get; set; }

        /// <summary>
        /// 电平方向
        /// </summary>
        public int LogicDir { get; set; }

        /// <summary>
        /// 脉冲宽度
        /// </summary>
        public double PulseWidth { get; set; }

        /// <summary>
        /// 运动模式
        /// </summary>
        public int MoveMode { get; set; }

        /// <summary>
        /// 轨迹表
        /// </summary>
        public string TrajName { get; set; }

        /// <summary>
        /// 元件名称
        /// </summary>
        public string EleName { get; set; }

        /// <summary>
        /// 轴名称
        /// </summary>
        public string AxisName { get; set; }

        /// <summary>
        /// 行进方向<br/>
        /// 0-负方向，1-正方向，2-无方向
        /// </summary>
        public int MoveDir { get; set; }

        /// <summary>
        /// 位置源
        /// </summary>
        public int CmpSource { get; set; }

        /// <summary>
        /// true：启用；false：不启用；
        /// </summary>
        public bool Enable { get; set; }

        [JsonIgnore]
        public Control ConfigUi => _configUi;

        public int Id { get; set; }

        public bool InterpolationEnable { get; set; }

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
                    _configUi.BackColor = value ? Color.Green : Colors.PrimaryBackColor236;
                    if (value)
                    {
                        OnEventSelected?.Invoke(this, ConfigType.Traj);
                    }
                }
            }
        }
        #endregion



        #region Ctor
        public TriggerPortData()
        {
            Gid = Guid.NewGuid();
            Name = "";
            Id = -1;
            Enable = true;
            PrimType = 0;
            PrimMoveName = "";
            EleName = "";
            AxisName = "";
            CmpSource = 0;
            TrigChannel = 0;
            TrigMode = 0;
            LogicDir = 0;
            TrigPulse = 0.0;
            TrigTableName = "";
            InterpolationEnable = false;
            TrajName = "";
            PulseWidth = 200.0;
            MoveDir = 2;
            _instance = TriggerManager.Instance;
            _configUi = new TriggerPort(this)
            {
                Dock = DockStyle.Top
            };
        }

        public TriggerPortData(TriggerManager manager) : this()
        {
            _instance = manager;
        }

        public TriggerPortData(string name, TriggerManager manager) : this(manager)
        {
            Name = name;
        }

        public TriggerPortData(string name, int id, TriggerManager manager) : this(name, manager)
        {
            Id = id;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 触发端口设置
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="offsets"></param>
        /// <returns></returns>
        public int Set(string productName, double[] offsets = null)
        {
            IPrim prim = null;
            if (PrimType == 0)
            {
                prim = PrimsManagerTransfer.GetPrimByName(PrimMoveName);
            }
            else if (PrimType == 1)
            {
                prim = PrimsManagerTransfer.GetPrimByName(PrimTriggerName);
            }
            if (prim == null)
            {
                throw new Exception(NLocalizer.PrimNotExist);
            }

            IEle ele = ElesManagerTransfer.GetEleByName(EleName);
            if (ele == null)
            {
                throw new Exception(NLocalizer.EleNotExist);
            }

            KeyValuePair<int, IEleAxis> keyValuePair = ((IEleCartesian)ele).Axises.FirstOrDefault((p) => p.Value.Name == AxisName);
            if (keyValuePair.Key < 0 || keyValuePair.Value == null)
            {
                throw new Exception(NLocalizer.AxisNotExist);
            }

            if (productName == null)
            {
                productName = Instance.CurrentProductName;
            }

            ICmpTrig primTrig = prim as ICmpTrig;
            if (primTrig == null)
            {
                throw new Exception(NLocalizer.TriggerPrimNotExist);
            }

            primTrig.SetTriggerChannelMode(TrigChannel, 0);
            int ret = primTrig.SetTrigDir(TrigChannel, MoveDir);
            if (ret != 0)
            {
                throw new Exception($"SetTrigDir <= {ret}");
            }

            ret = primTrig.ResetTriggerCount(TrigChannel);
            if (ret != 0)
            {
                throw new Exception($"ResetTriggerCount <= {ret}");
            }

            if (TrigMode == 6)
            {
                ret = primTrig.SetTriggerChannelMode(TrigChannel, 4);
                if (ret != 0)
                {
                    throw new Exception($"SetTriggerChannelMode <= {ret}");
                }
            }
            else
            {
                ret = primTrig.SetTriggerChannelMode(TrigChannel, TrigMode);
                if (ret != 0)
                {
                    throw new Exception($"SetTriggerChannelMode <= {ret}");
                }
            }

            int temp = 0;
            if (PrimType != 0)
            {
                temp = (int)(keyValuePair.Value.ActualPos * keyValuePair.Value.GearRatio);
            }
            ret = primTrig.SetTriggerConfig(TrigChannel, keyValuePair.Value.Id, temp, LogicDir, PulseWidth);
            if (ret != 0)
            {
                throw new Exception($"SetTriggerConfig <= {ret}");
            }

            if (TrigMode == 1 || TrigMode == 2 || TrigMode == 3)
            {
                ret = primTrig.AddTrigPoint(TrigChannel, (int)TrigPulse);
                if (ret != 0)
                {
                    throw new Exception($"AddTrigPoint <= {ret}");
                }
            }
            else if (TrigMode == 4)
            {
                if (!Instance.Products.ContainsKey(productName))
                {
                    throw new Exception(NLocalizer.TriggerNotContainsCurrentProduct);
                }

                if (Instance.Products[productName].TableTrigDatas.IsEmpty)
                {
                    throw new Exception(NLocalizer.TriggerTableTrigDatasIsEmpty);
                }

                var table = Instance.Products[productName].TableTrigDatas.FirstOrDefault(p => p.Value.Name == TrigTableName);
                if (table.Key == null || table.Value == null)
                {
                    throw new Exception(NLocalizer.TriggerTableTrigDatasNotExist);
                }

                ret = table.Value.AddPoints(primTrig, keyValuePair.Value, TrigChannel, 0.0);
                if (ret != 0)
                {
                    throw new Exception($"AddPoints <= {ret}");
                }
            }
            else if (TrigMode == 5)
            {
                if (!Instance.Products.ContainsKey(productName))
                {
                    throw new Exception(NLocalizer.TriggerNotContainsCurrentProduct);
                }

                if (Instance.Products[productName].LinearTrigDatas.IsEmpty)
                {
                    throw new Exception(NLocalizer.TriggerLinearTrigDatasIsEmpty);
                }

                var table = Instance.Products[productName].LinearTrigDatas.FirstOrDefault(p => p.Value.Name == TrigTableName);
                if (table.Key == null || table.Value == null)
                {
                    throw new Exception(NLocalizer.TriggerLinearTrigDatasNotExist);
                }

                ret = primTrig.SetLinearCompareTrig(TrigChannel, (int)(table.Value.StartPos * keyValuePair.Value.GearRatio), (int)(table.Value.Increment * keyValuePair.Value.GearRatio), table.Value.TrigCount);
                if (ret != 0)
                {
                    throw new Exception($"SetLinearCompareTrig <= {ret}");
                }
            }
            if (TrigMode == 6)
            {

                KeyValuePair<Guid, TrigTabMangerData> keyValuePair3 = Instance.Products[productName].TrigTabMangerDatas.First((p) => p.Value.Name == TrigTableName);
                List<double> list = new List<double>();
                foreach (KeyValuePair<int, TrigTabCfg> trigTable in keyValuePair3.Value.TrigsList)
                {
                    double num = 0.0;
                    if (offsets != null && trigTable.Value.OffsetType > -1 && offsets.Length > trigTable.Value.OffsetType)
                    {
                        num = offsets[trigTable.Value.OffsetType];
                    }
                    KeyValuePair<Guid, TriggerTableData> keyValuePair4 = Instance.Products[productName].TableTrigDatas.First((p) => p.Value.Name == trigTable.Value.TabName);
                    if (keyValuePair4.Value.TrigPoints.First().Value > keyValuePair4.Value.TrigPoints.Last().Value)
                    {
                        foreach (KeyValuePair<int, double> trigPoint in keyValuePair4.Value.TrigPoints)
                        {
                            list.Add((trigPoint.Value + keyValuePair4.Value.DelayVelocity * keyValuePair4.Value.DelayTime * 1E-06 + num) * keyValuePair.Value.GearRatio);
                        }
                        continue;
                    }
                    foreach (KeyValuePair<int, double> trigPoint2 in keyValuePair4.Value.TrigPoints)
                    {
                        list.Add((trigPoint2.Value - keyValuePair4.Value.DelayVelocity * keyValuePair4.Value.DelayTime * 1E-06 + num) * keyValuePair.Value.GearRatio);
                    }
                }
                    ((ICmpTrig)prim).SetTriggerTable(TrigChannel, list.ToArray(), list.Count);
            }
            return 0;
        }

        /// <summary>
        /// 触发端口测试
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="cmpCount"></param>
        /// <param name="timeoutS"></param>
        /// <param name="asyncMode"></param>
        /// <param name="task"></param>
        /// <param name="otherTriggers"></param>
        /// <param name="offsetPoses"></param>
        /// <returns></returns>
        public int Run(string productName, ref int cmpCount, int timeoutS = -1, bool asyncMode = false, ITask task = null, string[] otherTriggers = null, Pos[] offsetPoses = null)
        {
            IPrim prim = PrimsManagerTransfer.GetPrimByName(PrimMoveName);
            if (prim == null)
            {
                throw new Exception($"{NLocalizer.PrimNotExist} -> {PrimMoveName}");
            }

            IEle ele = ElesManagerTransfer.GetEleByName(EleName);
            if (ele == null)
            {
                throw new Exception($"{NLocalizer.EleNotExist} -> {EleName}");
            }

            KeyValuePair<int, IEleAxis> keyValuePair = ((IEleCartesian)ele).Axises.FirstOrDefault((p) => p.Value.Name == AxisName);
            if (keyValuePair.Key < 0 || keyValuePair.Value == null)
            {
                throw new Exception($"{NLocalizer.AxisNotExist} -> {AxisName}");
            }

            ((ICmpTrig)prim).SetTriggerChannelMode(TrigChannel, 0);
            if (otherTriggers != null)
            {
                foreach (string trigName in otherTriggers)
                {
                    _instance.CmpTrigDisable(trigName, productName);
                }
            }

            if (MoveMode == 0)
            {
                try
                {
                    int num = Instance.Products[productName].TrajDatas.First((p) => p.Value.Name == TrajName).Value.MoveToStartTraj(timeoutS, asyncMode, task);
                    if (num != 0)
                    {
                        cmpCount = -1;
                        return -121;
                    }
                }
                catch (Exception)
                {
                    cmpCount = -1;
                    return -120;
                }
            }
            int num2 = Set(productName);
            if (num2 != 0)
            {
                Disable();
                return num2;
            }
            if (otherTriggers != null)
            {
                int[] array = new int[otherTriggers.Length];
                for (int j = 0; j < otherTriggers.Length; j++)
                {
                    array[j] = _instance.CmpTrigSet(otherTriggers[j], productName);
                    if (array[j] != 0)
                    {
                        _instance.CmpTrigDisable(otherTriggers[j], productName);
                    }
                }
                if (array.Any((p) => p != 0))
                {
                    return -100;
                }
            }
            switch (MoveMode)
            {
                case 0:
                    try
                    {
                        if (Instance.Products[productName].TrajDatas.First((p) => p.Value.Name == TrajName).Value.Run(timeoutS, asyncMode, task, productName, Name) != 0)
                        {
                            break;
                        }

                        if (PrimType == 1)
                        {
                            prim = PrimsManagerTransfer.GetPrimByName(PrimTriggerName);
                        }
                        ((ICmpTrig)prim).GetTriggerCount(TrigChannel, ref cmpCount);
                        Disable();
                        if (otherTriggers != null)
                        {
                            int[] array4 = new int[otherTriggers.Length];
                            for (int m = 0; m < otherTriggers.Length; m++)
                            {
                                array4[m] = _instance.CmpTrigDisable(otherTriggers[m], productName);
                            }
                        }
                        return 0;
                    }
                    catch (Exception)
                    {
                        cmpCount = -1;
                        Disable();
                        if (otherTriggers != null)
                        {
                            int[] array5 = new int[otherTriggers.Length];
                            for (int n = 0; n < otherTriggers.Length; n++)
                            {
                                array5[n] = _instance.CmpTrigDisable(otherTriggers[n], productName);
                            }
                        }
                        return -120;
                    }
                case 1:
                    try
                    {
                        if (Instance.Products[productName].InterpolationDatas.First((p) => p.Value.Name == TrajName).Value.Move((IEleCartesian)ele, timeoutS, asyncMode, task, productName, Name, offsetPoses, continueEnable: false) == 0)
                        {
                            break;
                        }
                        ((ICmpTrig)prim).GetTriggerCount(TrigChannel, ref cmpCount);
                        Disable();
                        if (otherTriggers != null)
                        {
                            int[] array3 = new int[otherTriggers.Length];
                            for (int l = 0; l < otherTriggers.Length; l++)
                            {
                                array3[l] = _instance.CmpTrigDisable(otherTriggers[l], productName);
                            }
                        }
                        return -121;
                    }
                    catch (Exception)
                    {
                        return -125;
                    }
                case 2:
                    try
                    {
                        if (Instance.Products[productName].ComplexInterPolationDatas.First((p) => p.Value.Name == TrajName).Value.Move((IEleCartesian)ele, timeoutS, asyncMode, task, productName, Name) == 0)
                        {
                            break;
                        }
                        ((ICmpTrig)prim).GetTriggerCount(TrigChannel, ref cmpCount);
                        Disable();
                        if (otherTriggers != null)
                        {
                            int[] array2 = new int[otherTriggers.Length];
                            for (int k = 0; k < otherTriggers.Length; k++)
                            {
                                array2[k] = _instance.CmpTrigDisable(otherTriggers[k], productName);
                            }
                        }
                        return -121;
                    }
                    catch (Exception)
                    {
                        return -126;
                    }
            }
            ((ICmpTrig)prim).GetTriggerCount(TrigChannel, ref cmpCount);
            ((ICmpTrig)prim).SetTriggerChannelMode(TrigChannel, 0);
            Disable();
            if (otherTriggers != null)
            {
                int[] array6 = new int[otherTriggers.Length];
                for (int num3 = 0; num3 < otherTriggers.Length; num3++)
                {
                    array6[num3] = _instance.CmpTrigDisable(otherTriggers[num3], productName);
                }
            }
            return 0;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 获取触发基元
        /// </summary>
        /// <param name="triggerName"></param>
        /// <returns></returns>
        private ICmpTrig GetPrimTrigger(ref string triggerName)
        {
            IPrim prim = null;
            if (PrimType == 0)
            {
                triggerName = PrimMoveName;
            }
            else if (PrimType == 1)
            {
                triggerName = PrimTriggerName;
            }

            prim = PrimsManagerTransfer.GetPrimByName(triggerName);
            if (prim == null)
            {
                return null;
            }

            return (ICmpTrig)prim;
        }
        #endregion



        #region Method_Override
        /// <summary>
        /// 返回名称
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion



        public int ClearPoints()
        {
            //IL_0021: Unknown result type (might be due to invalid IL or missing references)
            IPrim primByName = PrimsManagerTransfer.GetPrimByName(PrimMoveName);
            if (primByName == null)
            {
                return -101;
            }
            return ((ICmpTrig)primByName).ResetTriggerCount(TrigChannel);
        }

        public int Disable(ICmpTrig prim = null)
        {
            ICmpTrig primTmp;
            if (prim == null)
            {
                if (prim == null || PrimType == 0)
                {
                    primTmp = (ICmpTrig)PrimsManagerTransfer.GetPrimByName(PrimMoveName);
                }
                else
                {
                    primTmp = (ICmpTrig)PrimsManagerTransfer.GetPrimByName(PrimTriggerName);
                }
            }
            else
            {
                primTmp = prim;
            }

            if (primTmp == null)
            {
                throw new Exception(NLocalizer.PrimNotExist);
            }

            return primTmp.SetTriggerChannelMode(TrigChannel, 0);
        }

        public int GetCmpCount(ref int cmpCount)
        {
            //IL_0021: Unknown result type (might be due to invalid IL or missing references)
            IPrim primByName = PrimsManagerTransfer.GetPrimByName(PrimMoveName);
            if (primByName == null)
            {
                return -101;
            }
            return ((ICmpTrig)primByName).GetTriggerCount(TrigChannel, ref cmpCount);
        }

        public List<double> GetTriggerPos(string productName)
        {
            List<double> list = new List<double>();
            if (TrigMode == 4)
            {
                try
                {
                    foreach (double value in Instance.Products[productName].TableTrigDatas.First((p) => p.Value.Name == TrigTableName).Value.TrigPoints.Values)
                    {
                        list.Add(value);
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            if (TrigMode == 6)
            {
                try
                {
                    foreach (KeyValuePair<int, TrigTabCfg> trigTable in Instance.Products[productName].TrigTabMangerDatas.First((p) => p.Value.Name == TrigTableName).Value.TrigsList)
                    {
                        foreach (double value2 in Instance.Products[productName].TableTrigDatas.First((p) => p.Value.Name == trigTable.Value.TabName).Value.TrigPoints.Values)
                        {
                            list.Add(value2);
                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return list;
        }

        public int MoveTraj(string productName, int timeoutS = -1, bool asyncMode = false, ITask task = null, string[] otherTriggers = null, Pos[] offsetPos = null, bool continueEnable = true)
        {
            IPrim primByName = PrimsManagerTransfer.GetPrimByName(PrimMoveName);
            IEle eleByName = ElesManagerTransfer.GetEleByName(EleName);
            if (primByName == null || eleByName == null)
            {
                return -101;
            }
            KeyValuePair<int, IEleAxis> keyValuePair = ((IEleCartesian)eleByName).Axises.FirstOrDefault((p) => p.Value.Name == AxisName);
            if (keyValuePair.Key < 0 || keyValuePair.Value == null)
            {
                return -102;
            }
            switch (MoveMode)
            {
                case 0:
                    try
                    {
                        if (Instance.Products[productName].TrajDatas.First((p) => p.Value.Name == TrajName).Value.Run(timeoutS, asyncMode, task, productName, Name) != 0)
                        {
                            return -122;
                        }
                    }
                    catch (Exception)
                    {
                        return -120;
                    }
                    break;
                case 1:
                    try
                    {
                        if (Instance.Products[productName].InterpolationDatas.First((p) => p.Value.Name == TrajName).Value.Move((IEleCartesian)eleByName, timeoutS, asyncMode, task, productName, Name, offsetPos, continueEnable) != 0)
                        {
                            return -121;
                        }
                    }
                    catch (Exception)
                    {
                        return -125;
                    }
                    break;
                case 2:
                    try
                    {
                        if (Instance.Products[productName].ComplexInterPolationDatas.First((p) => p.Value.Name == TrajName).Value.Move((IEleCartesian)eleByName, timeoutS, asyncMode, task, productName, Name) != 0)
                        {
                            return -121;
                        }
                    }
                    catch (Exception)
                    {
                        return -126;
                    }
                    break;
            }
            return 0;
        }
    }
}
