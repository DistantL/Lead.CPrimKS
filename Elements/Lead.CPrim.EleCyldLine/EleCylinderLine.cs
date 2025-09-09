/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: EleCylinderLine.cs
 * Author: Victor
 * Description: 用来直方图管理（直方图生成/直方图添加数据/直方图清除数据/直方图保存）
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220711
 * 1、气缸执行锁由1个变更为2个，解决死锁问题
******************************************************************************/

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.MachineHelper;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.EleCyldLine
{
    public class EleCylinderLine : IEle, IEleCyldLine
    {
        #region Define_Event
        public event AlarmMsgRevedEventHandler OnMsgReved;
        public event BlowAfterTimeEventHandler OnBlowAfter;
        #endregion



        #region Field
        /// <summary>ConfigUI</summary>
        private readonly ConfigUI _eleConfigUI;
        /// <summary>DebugUI</summary>
        private readonly DebugUI _eleDebugUI;
        /// <summary>气缸配置</summary>
        public EleCyldLineConfig _config;
        /// <summary>被选择</summary>
        private bool _isSelected;
        /// <summary>控制卡</summary>
        private IIoModule _motionCard;
        /// <summary>气缸执行锁</summary>
        private static readonly object objAutoCylinder = new object();
        /// <summary>气缸手动执行锁</summary>
        private static readonly object objManualCylinder = new object();
        /// <summary>气缸UI未启用_使用DataGridView</summary>
        private bool CylinderUIEnable = false;
        /// <summary>true：检查伸位；false：不检查伸位</summary>
        private volatile bool _isCheckStretch = false;
        /// <summary>true：检查原位；false：不检查原位</summary>
        private volatile bool _isCheckRestract = false;
        /// <summary>元件运行</summary>
        private EleRunState _eleRunState;
        #endregion



        #region Ctor
        public EleCylinderLine()
        {
            _config = new EleCyldLineConfig();

            _eleConfigUI = new ConfigUI(this);
            _eleDebugUI = new DebugUI();

            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }
        public EleCylinderLine(XmlNode xmlNode)
        {
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleCyldLineConfig)) as EleCyldLineConfig;
            else
                return;

            _eleConfigUI = new ConfigUI(this);
            _eleDebugUI = new DebugUI();

            _eleConfigUI.SetEleConfig(this);
            _eleDebugUI.SetEleConfig(this);
        }
        #endregion



        //*****************************************************************************
        #region Override IEle
        public Guid Id { get => _config.Id; set => _config.Id = value; }
        public string DevName { get => _config.DevName; set => _config.DevName = value; }
        public string Name { get => _config.Name; set => _config.Name = value; }
        public string Info { get => _config.Info; set => _config.Info = value; }
        public bool IsSelected
        {
            set
            {
                if (value == _isSelected) return;

                _isSelected = value;
                _eleConfigUI.BackColor = value ? Color.Green : Color.LightGray;
            }
            get => _isSelected;
        }
        public Control EleConfigUI => _eleConfigUI;
        public Control EleDebugUI => _eleDebugUI;
        public EleRunState EleRunStat 
        { 
            get => _eleRunState;
            set
            {
                if(_eleRunState == value)
                {
                    return;
                }
                _eleRunState = value;
                OnEleStateChanged?.Invoke(_eleRunState);
                SetEleRunState(value);
            } 
        }
        public bool Enable { get => _config.Enable; set => _config.Enable = value; }
        public string EleTypeName { get => _config.EleTypeName; set => _config.EleTypeName = value; }
        public bool LogEnable { get => _config.LogEnable; set => _config.LogEnable = value; }
        public LogLevel EleAlarmLv { get; set; }
        public bool LogDisplay { get => _config.LogDisplay; set => _config.LogDisplay = value; }
        public bool ManualEnable { get; set; }
        public bool IsSimulateMode
        {
            get => _config.IsSimulateMode;
            set
            {
                _config.IsSimulateMode = value;
                _eleConfigUI?.SetSimulateMode(value);
            }
        }

        public event EleStateChangedEventHandle OnEleStateChanged;

        public PrimRunState IEleCheckPrimRunState()
        {
            if (_motionCard == null) return PrimRunState.Other;
            return ((IPrim)_motionCard).PrimRunStat;
        }
        public int IEleDispose()
        {
            try
            {
                if (_eleConfigUI != null && !_eleConfigUI.Disposing && !_eleConfigUI.IsDisposed) _eleConfigUI.Dispose();

                if (_eleDebugUI != null && !_eleDebugUI.Disposing && !_eleDebugUI.IsDisposed) _eleDebugUI.Dispose();
                EleRunStat = EleRunState.Other;
                return 0;
            }
            catch (Exception)
            {
                EleRunStat = EleRunState.Other;
                return -1;
            }
        }
        public int IEleInit()
        {
            if (!Enable) return 0;
            if (EleRunStat == EleRunState.Running) return 0;

            var prim = PrimsManagerTransfer.GetPrimByName(DevName);
            if (prim == null)
            {
                EleRunStat = EleRunState.Err;
                return (int)SoftWareAlarm.EleCyldLine_元件获取基元失败;
            }

            if (_motionCard != prim) _motionCard = (IIoModule)prim;

            if (prim.PrimRunStat == PrimRunState.Running)
            {
                EleRunStat = EleRunState.Running;
                return 0;
            }

            EleRunStat = EleRunState.Other;
            return -2;
        }
        public int IEleReset()
        {
            try
            {
                if (EleRunStat == EleRunState.Err)
                {
                    var retractDoStatus = ReadRestractDO() == 1;
                    var retractDiStatus = ReadRestractDI() == 1;
                    var stretchDoStatus = ReadStretchDO() == 1;
                    var stretchDiStatus = ReadStretchDI() == 1;

                    if (CyldType == EleCyldType.Vacuum)
                    {
                        if (!stretchDoStatus && !retractDoStatus || !StretchDiEnable ||
                            StretchDoEnable && stretchDoStatus && StretchDiEnable && stretchDiStatus &&
                            (!RestractDoEnable || RestractDoEnable && !retractDoStatus) || 
                            !StretchDiEnable || RestractDoEnable && retractDoStatus && StretchDiEnable && !StretchDiEnable &&
                            (!StretchDoEnable || StretchDoEnable && !stretchDoStatus) //破真空判定
                        )
                        EleRunStat = EleRunState.Running;
                    }
                    else if (CyldType == EleCyldType.Cylinder)
                    {
                        if (!stretchDoStatus && !retractDoStatus || !StretchDiEnable ||
                            StretchDoEnable && stretchDoStatus && StretchDiEnable && stretchDiStatus &&
                            (!RestractDoEnable || RestractDoEnable && !retractDoStatus) || !RestractDiEnable ||
                            RestractDoEnable && retractDoStatus && RestractDiEnable && retractDiStatus &&
                            (!StretchDoEnable || StretchDoEnable && !stretchDoStatus) //缩位判定
                        )
                        EleRunStat = EleRunState.Running;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 1;
        }
        public int IEleStop()
        {
            return 0;
        }
        public int IEleUiRefresh()
        {
            try
            {
                if (_motionCard == null) return 0;

                CheckCylState(out var stretchDiOn, out var restractDiOn, out var stretchDoOn, out var restractDoOn);
                StretchDi_On = stretchDiOn;
                StretchDo_On = stretchDoOn;
                RestractDi_On = restractDiOn;
                RestractDo_On = restractDoOn;

                //气缸ConfigUI及DebugUI暂时未启用
                if (CylinderUIEnable)
                {
                    _eleConfigUI.UiRefresh();
                    _eleDebugUI.UiRefresh();
                }
                _eleDebugUI.UiRefresh();
            }
            catch
            {
                return (int)SoftWareAlarm.EleCyldLine_元件刷新失败;
            }

            return 0;
        }
        public string GetCsvValue()
        {
            return _config.CsvValue();
        }
        public string GetCsvHeader()
        {
            return _config.CsvHeader();
        }
        public int CsvToValue(string csvString)
        {
            _config.CsvToValue(csvString);
            return 0;
        }
        public XmlNode IEleExportConfigXml()
        {
            if (_config == null) return null;

            return ProxyTools.XMLHelper.ObjectToXML(_config);
        }
        public int IEleImportConfigXml(XmlNode xmlNode)
        {
            var iRet = 0;
            if (xmlNode != null)
                _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(EleCyldLineConfig)) as EleCyldLineConfig;
            else
                return -1;

            _eleConfigUI.UpdataEleConfig(_config);
            _eleDebugUI.UpdataEleConfig(_config);
            return iRet;
        }
        #endregion



        //*****************************************************************************
        #region Override IEleCyldLine
        public bool ActionComplete { set; get; } = true;
        public bool AutoMotion { get => _config.AutoMotion; set => _config.AutoMotion = value; }
        public int BlowTime { get => _config.BlowTime; set => _config.BlowTime = value; }
        public EleCyldType CyldType { get => _config.CyldType; set => _config.CyldType = value; }
        public EleCyldState EleCyldState { get => _config.EleCyldState; set => _config.EleCyldState = value; }
        public bool RestractDi_On { get; set; }
        public double RestractDiAddress { get => _config.RestractDiAddress; set => _config.RestractDiAddress = value; }
        public bool RestractDiEnable { get => _config.RestractDiEnable; set => _config.RestractDiEnable = value; }
        public bool RestractDo_On { get; set; }
        public double RestractDoAddress { get => _config.RestractDoAddress; set => _config.RestractDoAddress = value; }
        public bool RestractDoEnable { get => _config.RestractDoEnable; set => _config.RestractDoEnable = value; }
        public int RestractTimeOut { get => _config.RestractTimeOut; set => _config.RestractTimeOut = value; }
        public bool StretchDi_On { get; set; }
        public double StretchDiAddress { get => _config.StretchDiAddress; set => _config.StretchDiAddress = value; }
        public bool StretchDiEnable { get => _config.StretchDiEnable; set => _config.StretchDiEnable = value; }
        public bool StretchDo_On { get; set; }
        public double StretchDoAddress { get => _config.StretchDoAddress; set => _config.StretchDoAddress = value; }
        public bool StretchDoEnable { get => _config.StretchDoEnable; set => _config.StretchDoEnable = value; }
        public int StretchTimeOut { get => _config.StretchTimeOut; set => _config.StretchTimeOut = value; }
        public string LineMark { get => _config.LineMark; set => _config.LineMark = value; }


        public int CheckCylState(out bool stretchDiOn, out bool restractDiOn, out bool stretchDoOn,
            out bool restractDoOn)
        {
            stretchDiOn = ReadStretchDI() == 1;
            restractDiOn = ReadRestractDI() == 1;
            stretchDoOn = ReadStretchDO() == 1;
            restractDoOn = ReadRestractDO() == 1;

            //0-原位、1-伸位、2-未知状态
            if (ActionComplete)
            {
                if (!RestractDiEnable && !StretchDiEnable)
                {
                    if (stretchDoOn && restractDoOn || !stretchDoOn && !restractDoOn) return 2;

                    if (stretchDoOn) return 1;

                    if (restractDoOn) return 0;
                }
                else
                {
                    //原位判定：原位使能且有+伸位未使能，原位使能且有+伸位使能且没有，原位未使能+伸位使能且没有
                    if (RestractDiEnable && restractDiOn && (!StretchDiEnable || StretchDiEnable && !stretchDiOn) ||
                        !RestractDiEnable && StretchDiEnable && !stretchDiOn
                    )
                        return 0;
                    //伸位判定：伸位使能且有+原位未使能，伸位使能且有+原位使能且没有
                    if (StretchDiEnable && stretchDiOn &&
                        (!RestractDiEnable || RestractDiEnable && !restractDiOn)) return 1;
                }
            }

            return 2;
        }
        public int CheckCylState()
        {
            //0-原位，1-伸位，2-原位报错，3-伸位报错，4-未知未知
            int ret = -1;
            
            StretchDi_On = ReadStretchDI() == 1;
            RestractDi_On = ReadRestractDI() == 1;
            StretchDo_On = ReadStretchDO() == 1;
            RestractDo_On = ReadRestractDO() == 1;

            if (StretchDoEnable && RestractDoEnable)
            {
                EleCyldState = StretchDo_On && RestractDo_On ? EleCyldState.Other : (StretchDo_On && !RestractDo_On ? EleCyldState.Stretch : (!StretchDo_On && RestractDo_On ? EleCyldState.Restretch : EleCyldState.Other));
            }
            else if (!StretchDoEnable && RestractDoEnable)
            {
                EleCyldState = RestractDo_On ? EleCyldState.Restretch : EleCyldState.Stretch;
            }
            else if (StretchDoEnable && !RestractDoEnable)
            {
                EleCyldState = StretchDo_On ? EleCyldState.Stretch : EleCyldState.Restretch;
            }
            else
            {
                EleCyldState = EleCyldState.Other;
            }

            switch (EleCyldState)
            {
                case EleCyldState.Stretch:
                    ret = StretchDi_On ? 1 : 3;
                    break;
                case EleCyldState.Restretch:
                    ret = RestractDi_On ? 0 : 2;
                    break;
                case EleCyldState.Other:
                default:
                    ret = 4;
                    break;
            }

            return ret;
        }
        public int CheckStatus()
        {
            return CheckCylState();
        }
        public int CyldRetract()
        {
            return CyldRetract(true);
        }
        public int CyldRetract(bool isCheck)
        {
            SetActionComplete(false);
            try
            {
                if (Enable)
                {
                    if (RestractDoEnable) _motionCard.WriteSingleDOutput(RestractDoAddress, true);
                    if (StretchDoEnable) _motionCard.WriteSingleDOutput(StretchDoAddress, false);

                    if (CyldType == EleCyldType.Vacuum)
                    {
                        Task.Run(BlowOnce);
                    }

                    if (isCheck)
                    {
                        _isCheckRestract = true;
                        _isCheckStretch = false;
                        Task.Run(CheckRetract);
                    }
                    return 0;
                }

                string errorText = CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 未使能" : $"真空 {Name} 未使能";
                LogAdd(errorText, LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_元件未使能;
            }
            catch (Exception ex)
            {
                string errorText = CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 回原位失败：{ex.Message}" : $"真空 {Name} 破失败：{ex.Message}";
                LogAdd(errorText, LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_气缸回原位失败;
            }
            finally
            {
                EleCyldState = EleCyldState.Restretch;
                SetActionComplete(true);
            }
        }
        public int CyldRetract(bool isCheck, bool asyncMode, ITask task = null, EleAlarmLevel eleAlarmLevel = EleAlarmLevel.Warn, string cyldLog = "")
        {
            return CyldRetract(isCheck, asyncMode, (StationTask)task, eleAlarmLevel, cyldLog);
        }
        public int CyldRetract(bool isCheck, bool asyncMode, StationTask task = null, EleAlarmLevel eleLevel = EleAlarmLevel.Warn, string cyldLog = "")
        {
            SetActionComplete(false);
            try
            {
                task?.JoinIfPause();
                task?.AbortIfCancel(Name);

                if (Enable)
                {
                    if (RestractDoEnable) _motionCard.WriteSingleDOutput(RestractDoAddress, true);
                    if (StretchDoEnable) _motionCard.WriteSingleDOutput(StretchDoAddress, false);

                    if (CyldType == EleCyldType.Vacuum)
                    {
                        Task.Run(BlowOnce);
                    }

                    if (isCheck)
                    {
                        if (asyncMode)
                        {
                            _isCheckRestract = true;
                            _isCheckStretch = false;
                            Task.Run(CheckRetract);
                            return 0;
                        }

                        var ret = CheckRetractDone(task);
                        if (ret != 0)
                        {
                            var logLv = LogLevel.Info;
                            if (eleLevel == EleAlarmLevel.Warn)
                                logLv = LogLevel.Warn;
                            else if (eleLevel == EleAlarmLevel.Err)
                                logLv = LogLevel.Error;
                            task?.TaskLog($"{Info}缩回超时" + (string.IsNullOrEmpty(cyldLog) ? "" : $@"，{cyldLog}"), logLv);
                            OnMsgReved?.BeginInvoke(cyldLog, "", null, null);
                        }

                        return ret;
                    }

                    return 0;
                }

                string errorText = CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 未使能" : $"真空 {Name} 未使能";
                LogAdd(errorText, LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_元件未使能;
            }
            catch (Exception ex)
            {
                string errorText = CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 回原位失败：{ex.Message}" : $"真空 {Name} 破失败：{ex.Message}";
                LogAdd(errorText, LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_气缸回原位失败;
            }
            finally
            {
                EleCyldState = EleCyldState.Restretch;
                SetActionComplete(true);
            }
        }
        public int CyldStretch()
        {
            return CyldStretch(true);
        }
        public int CyldStretch(bool isCheck)
        {
            SetActionComplete(false);
            try
            {
                if (Enable)
                {
                    if (RestractDoEnable) _motionCard.WriteSingleDOutput(RestractDoAddress, false);
                    if (StretchDoEnable) _motionCard.WriteSingleDOutput(StretchDoAddress, true);

                    if (isCheck)
                    {
                        _isCheckRestract = false;
                        _isCheckStretch = true;
                        Task.Run(CheckStretch);
                    }
                    return 0;
                }

                string errorText = CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 未使能" : $"真空 {Name} 未使能";
                LogAdd(errorText, LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_元件未使能;
            }
            catch (Exception ex)
            {
                string errorText = CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 去伸位失败：{ex.Message}" : $"真空 {Name} 吸失败：{ex.Message}";
                LogAdd(errorText, LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_气缸去伸位失败;
            }
            finally
            {
                EleCyldState = EleCyldState.Stretch;
                SetActionComplete(true);
            }
        }
        public int CyldStretch(bool isCheck, bool asyncMode, ITask task = null, EleAlarmLevel eleAlarmLevel = EleAlarmLevel.Warn, string cyldLog = "")
        {
            return CyldStretch(isCheck, asyncMode, (StationTask)task, eleAlarmLevel, cyldLog);
        }
        public int CyldStretch(bool isCheck, bool asyncMode, StationTask task, EleAlarmLevel lv = EleAlarmLevel.Warn, string cyldLog = "")
        {
            SetActionComplete(false);
            try
            {
                task?.JoinIfPause();
                task?.AbortIfCancel(Name);

                if (Enable)
                {
                    if (RestractDoEnable) _motionCard.WriteSingleDOutput(RestractDoAddress, false);
                    if (StretchDoEnable) _motionCard.WriteSingleDOutput(StretchDoAddress, true);

                    if (isCheck)
                    {
                        if (asyncMode)
                        {
                            _isCheckRestract = false;
                            _isCheckStretch = true;
                            Task.Run(CheckStretch);
                            return 0;
                        }

                        var ret = CheckStretchDone(task);
                        if (ret != 0)
                        {
                            var loglv = LogLevel.Info;
                            if (lv == EleAlarmLevel.Warn)
                                loglv = LogLevel.Warn;
                            else if (lv == EleAlarmLevel.Err)
                                loglv = LogLevel.Error;
                            task?.TaskLog($"{Info}伸出超时" + (string.IsNullOrEmpty(cyldLog) ? "" : $@"，{cyldLog}"), loglv);
                            OnMsgReved?.BeginInvoke(cyldLog, "", null, null);
                        }

                        return ret;
                    }

                    return 0;
                }

                string errorText = CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 未使能" : $"真空 {Name} 未使能";
                LogAdd(errorText, LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_元件未使能;
            }
            catch (Exception ex)
            {
                string errorText = CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 去伸位失败：{ex.Message}" : $"真空 {Name} 吸失败：{ex.Message}";
                LogAdd(errorText, LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_气缸去伸位失败;
            }
            finally
            {
                EleCyldState = EleCyldState.Stretch;
                SetActionComplete(true);
            }
        }
        public int ReadRestractDI()
        {
            try
            {
                if (!Enable || _motionCard == null || ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running)
                {
                    return 0;
                }

                if(!RestractDiEnable)
                {
                    return 1;
                }

                _motionCard.ReadSingleDInput(RestractDiAddress, out var val);
                return val ? 1 : 0;
            }
            catch (Exception ex)
            {
                LogAdd($"气缸 {Name} 原位DI读取失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_数字量输入读取失败;
            }
        }
        public int ReadRestractDO()
        {
            try
            {
                if (!Enable || !RestractDoEnable || _motionCard == null || ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running)
                {
                    return 0;
                }

                _motionCard.ReadSingleDOutput(RestractDoAddress, out var val);
                return val ? 1 : 0;
            }
            catch (Exception ex)
            {
                LogAdd($"气缸 {Name} 原位DO读取失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_数字量输出读取失败;
            }
        }
        public int ReadStretchDI()
        {
            try
            {
                if (!Enable || _motionCard == null || ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running)
                {
                    return 0;
                }

                if(!StretchDiEnable)
                {
                    return 1;
                }

                _motionCard.ReadSingleDInput(StretchDiAddress, out var val);
                return val ? 1 : 0;
            }
            catch (Exception ex)
            {
                LogAdd($"气缸 {Name} 伸位DI读取失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_数字量输入读取失败;
            }
        }
        public int ReadStretchDO()
        {
            try
            {
                if (!Enable || !StretchDoEnable || _motionCard == null || ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running)
                {
                    return 0;
                }

                _motionCard.ReadSingleDOutput(StretchDoAddress, out var val);
                return val ? 1 : 0;
            }
            catch (Exception ex)
            {
                LogAdd($"气缸 {Name} 伸位DO读取失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_数字量输出读取失败;
            }
        }
        public int Toggle()
        {
            if (StretchDoEnable) return ReadStretchDO() == 1 ? CyldRetract() : CyldStretch();
            if (RestractDoEnable) return ReadRestractDO() == 1 ? CyldStretch() : CyldRetract();
            return (int)SoftWareAlarm.EleCyldLine_元件原位工作位DO均未启用;
        }
        public int WriteRestractDO(bool on_off)
        {
            try
            {
                if (!Enable || !RestractDoEnable || _motionCard == null ||
                    ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running) return 0;
                return _motionCard.WriteSingleDOutput(RestractDoAddress, on_off);
            }
            catch (Exception ex)
            {
                LogAdd($"气缸 {Name} 原位DO写入{on_off}失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_数字量输出控制失败;
            }
        }
        public int WriteStretchDO(bool on_off)
        {
            try
            {
                if (!Enable || !StretchDoEnable || _motionCard == null ||
                    ((IPrim)_motionCard).PrimRunStat != PrimRunState.Running) return 0;
                return _motionCard.WriteSingleDOutput(StretchDoAddress, on_off);
            }
            catch (Exception ex)
            {
                LogAdd($"气缸 {Name} 伸位DO写入{on_off}失败：{ex.Message}", LogLevel.Warn);
                return (int)SoftWareAlarm.EleCyldLine_数字量输出控制失败;
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        /// <summary>日志</summary>
        /// <param name="log">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        public void LogAdd(string log, LogLevel lv, long id = 0)
        {
            if (!LogEnable) return;

            string tempId = $"{(int)lv}{(int)PrimLogId.EleCyldLine}0000";

            if (long.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            ProxyTools.LogHelper.LogAdd(lv, log, Name, LogClassification.Elements, id);
            EleAlarmLv = lv;
            //if(lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn)
            //{
            //    EleRunStat = EleRunState.Err;
            //}
        }
        /// <summary>真空破关闭</summary>
        private void BlowOnce()
        {
            Thread.Sleep(BlowTime);
            WriteRestractDO(false);
            OnBlowAfter?.Invoke();
        }
        /// <summary>异步检查气缸原位</summary>
        public void CheckRetract()
        {
            var start = DateTime.Now.Ticks / 10000;
            while (true)
            {
                var end = DateTime.Now.Ticks / 10000;
                var dt = end - start;
                if (RestractDiEnable)
                {
                    if (CyldType == EleCyldType.Vacuum)
                    {
                        _motionCard.ReadSingleDInput(StretchDiAddress, out var val);
                        if (!val) break;

                        if (dt > RestractTimeOut)
                        {
                            LogAdd($"{Name}破真空超时", LogLevel.Warn);
                            break;
                        }
                    }
                    else if (CyldType == EleCyldType.Cylinder)
                    {
                        _motionCard.ReadSingleDInput(RestractDiAddress, out var val);
                        if (val) break;

                        if (dt > RestractTimeOut)
                        {
                            LogAdd($"{Name}缩回超时", LogLevel.Warn);
                            break;
                        }
                    }
                }
                else
                {
                    if (dt > RestractTimeOut) break;
                }

                if(!_isCheckRestract)
                {
                    break;
                }

                Thread.Sleep(10);
            }
        }
        /// <summary>同步检查气缸原位</summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public int CheckRetractDone(StationTask task = null)
        {
            var start = DateTime.Now.Ticks / 10000;
            while (true)
            {
                task?.JoinIfPause();
                task?.AbortIfCancel(Name);

                var end = DateTime.Now.Ticks / 10000;
                var dt = end - start;
                if (RestractDiEnable)
                {
                    if (CyldType == EleCyldType.Vacuum)
                    {
                        _motionCard.ReadSingleDInput(StretchDiAddress, out var val);
                        if (!val) break;

                        if (dt > RestractTimeOut)
                        {
                            if (task == null)
                            {
                                LogAdd($"{Name}破真空超时", LogLevel.Warn);
                            }
                            return (int)SoftWareAlarm.EleCyldLine_气缸回原位失败;
                        }
                    }
                    else if (CyldType == EleCyldType.Cylinder)
                    {
                        _motionCard.ReadSingleDInput(RestractDiAddress, out var val);
                        if (val) break;

                        if (dt > RestractTimeOut)
                        {
                            if (task == null)
                            {
                                LogAdd($"{Name}缩回超时", LogLevel.Warn);
                            }
                            return (int)SoftWareAlarm.EleCyldLine_气缸回原位失败;
                        }
                    }
                }
                else
                {
                    if (dt > RestractTimeOut) break;
                }

                Thread.Sleep(10);
            }

            return 0;
        }
        /// <summary>异步检查气缸伸位</summary>
        public void CheckStretch()
        {
            var start = DateTime.Now.Ticks / 10000;
            while (true)
            {
                var end = DateTime.Now.Ticks / 10000;
                var dt = end - start;
                if (StretchDiEnable)
                {
                    _motionCard.ReadSingleDInput(StretchDiAddress, out var val);
                    if (val) break;

                    if (dt > StretchTimeOut)
                    {
                        if (CyldType == EleCyldType.Cylinder)
                        {
                            LogAdd($"{Name}伸出超时", LogLevel.Warn);
                        }
                        else if (CyldType == EleCyldType.Vacuum)
                        {
                            LogAdd($"{Name}吸真空超时", LogLevel.Warn);
                        }

                        break;
                    }
                }
                else
                {
                    if (dt > StretchTimeOut) break;
                }

                if(!_isCheckStretch)
                {
                    break;
                }

                Thread.Sleep(10);
            }
        }
        /// <summary>同步检查气缸伸位</summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public int CheckStretchDone(StationTask task = null)
        {
            var start = DateTime.Now.Ticks / 10000;
            while (true)
            {
                task?.JoinIfPause();
                task?.AbortIfCancel(Name);

                var end = DateTime.Now.Ticks / 10000;
                var dt = end - start;
                if (StretchDiEnable)
                {
                    _motionCard.ReadSingleDInput(StretchDiAddress, out var val);
                    if (val) break;

                    if (dt > StretchTimeOut)
                    {
                        if (task == null)
                        {
                            if (CyldType == EleCyldType.Cylinder)
                            {
                                LogAdd($"{Name}伸出超时", LogLevel.Warn);
                            }
                            else if (CyldType == EleCyldType.Vacuum)
                            {
                                LogAdd($"{Name}吸真空超时", LogLevel.Warn);
                            }
                        }

                        return (int)SoftWareAlarm.EleCyldLine_气缸去伸位失败;
                    }
                }
                else
                {
                    if (dt > StretchTimeOut) break;
                }

                Thread.Sleep(10);
            }

            return 0;
        }
        /// <summary>设置完成状态</summary>
        /// <param name="value"></param>
        private void SetActionComplete(bool value)
        {
            lock (objAutoCylinder)
            {
                ActionComplete = value;
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        private void SetEleRunState(EleRunState runState)
        {
            _eleConfigUI?.SetEleRunState(EleRunStat);
            _eleDebugUI?.SetEleRunState(EleRunStat);
        } 
        #endregion
    }
}