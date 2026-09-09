/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: DevMainForm.cs
 * Author: Victor
 * Description: 软件主界面UI
 * CreateTime: 2023-1-8
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0617><Victor><20220617>
 * 1、事件InstanceSoftwareConfigChangeCurrentProduct优化
******************************************************************************/
using Lead.CPrim.Controls;
using Lead.CPrim.FormMain.Properties;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.StationCommon;
using Lead.CPrim.StationCommon.MainOutput;
using Lead.CPrim.StationCommon.Recipe;
using Lead.CPrim.TaskHelper;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControls;

namespace Lead.CPrim.FormMain
{
    public partial class DevMainForm : UIPage
    {
        #region Field
        /// <summary>主界面TabPage管理</summary>
        private Dictionary<string, TabPage> _mainPages;

        /// <summary>工站实例</summary>
        private StationConfig _station;

        /// <summary>
        /// 初始化中标志
        /// </summary>
        private bool _initing = false;

        /// <summary>用于启动时暂停或者停止线程</summary>
        CancellationTokenSource _cts = new CancellationTokenSource();

        /// <summary>Vendor界面</summary>
        Vendor _vendor;

        #endregion



        #region Prop
        /// <summary>状态机初始化完成标志</summary>
        public bool StationMachineIntied => _station.StationMachineInited;

        /// <summary>
        /// 初始化中标志
        /// </summary>
        public bool Initing => _initing;
        #endregion



        #region Ctor
        public DevMainForm()
        {
            InitializeComponent();
        }
        public DevMainForm(StationConfig station) : this()
        {
            _station = station;
            _station.OnChangeStateTab += StationOnOnChangeStateTab;
            _station.StationMachineInited = false;

            _vendor = new Vendor(station);
            _vendor.TopMost = false;
            _vendor.TopLevel = false;
            _vendor.Dock = DockStyle.Fill;
            _vendor.FormBorderStyle = FormBorderStyle.None;
            _vendor.Show();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        //*****************************************************************************
        #region System_Event
        /// <summary>Load事件</summary>
        private void DevMainForm_Load(object sender, EventArgs e)
        {
            //界面TabPage管理
            {
                _mainPages = new Dictionary<string, TabPage>();
                foreach (TabPage page in tabMain.TabPages)
                {
                    page.Margin = new Padding(0);
                    page.Padding = new Padding(0);
                    _mainPages.Add(page.Name, page);
                }
            }

            //界面初始化
            {
                btnAutoSw.Checked = false;
            }

            //事件订阅
            {
                _station.OnChangeCurrentRecipe += Instance_OnChangeCurrentRecipe;
            }

            //上电初始化
            {
                if (SwManager.Instance.BootInit)
                {
                    TaskInit(true);//20230520 false 无法加载I3dAgl
                }
            }
        }
        #endregion



        //*****************************************************************************
        #region Button_Event
        /// <summary>
        /// Main/Vendor切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoSw_CheckedChanged(object sender, EventArgs e)
        {
            if (!btnAutoSw.Checked)
            {
                if (!pnlMain.Controls.Contains(tabMain))
                {
                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(tabMain);
                }
            }
            else
            {
                if (pnlMain.Controls.Contains(tabMain))
                {
                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(_vendor);
                }
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_InstanceEvent
        private void StationOnOnChangeStateTab(string stationName, int index)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, int>(StationOnOnChangeStateTab), new object[2] { stationName, index });
            }
            else if (tabState.TabPages.Count > index)
            {
                tabState.SelectedIndex = index;
            }
        }

        /// <summary>更改配方</summary>
        /// <remarks>1、更新当前配方的主界面显示
        /// <para>2、如果是配方产品模式，产品框集合更新并且更新当前配方产品，同时更新当前配方产品</para></remarks>
        /// <param name="stationName">工站名称</param>
        /// <param name="recipeName">配方名称</param>
        private void Instance_OnChangeCurrentRecipe(string stationName, string recipeName)
        {
            DevMainFormLoadMainStationInfo();
        }

        /// <summary>响应初始化完成事件</summary>
        /// <param name="success"></param>
        /// <param name="sender"></param>
        private void OnStateMachineInited(bool success, IStateMachine sender)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool, IStateMachine>(OnStateMachineInited), success, sender);
                return;
            }

            _station.StationMachineInited = success;
            _initing = false;

            if (SwManager.Instance.BootRun)
            {
                Run();
            }

            _vendor.StateMachineInited(success);
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>主界面更新</summary>
        public void DevMainFormLoadMainStationInfo()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(DevMainFormLoadMainStationInfo));
            }
            else if (SwManager.Instance.RemoteCSType == "Client")
            {
                tabMain.TabPages.Clear();
                if (!string.IsNullOrEmpty(_station.CurrentRecipe.OutputValsName) && _station.CurrentRtDataVars.VarsDisplayControl != null)
                {
                    _station.CurrentRtDataVars.VarsDisplayControl.Dock = DockStyle.Fill;
                    _vendor.RtDataControlManager(_station.CurrentRtDataVars.VarsDisplayControl);
                }
                else
                {
                    _vendor.RtDataControlManager(null);
                }

                if (!string.IsNullOrEmpty(_station.CurrentRecipe.MainGuiConfigName))
                {
                    Invoke(new Action(UpdateMainPrimsOutput));
                }
            }
        }

        /// <summary>切换当前产品</summary>
        /// <param name="currentParam">当前产品</param>
        /// <param name="products">产品集合</param>
        public void ChangeCurrentProduct(string currentParam, List<string> products = null)
        {
            _vendor.ChangeCurrentProduct(currentParam, products);
        }

        /// <summary>响应工站按钮点击事件</summary>
        /// <param name="button"></param>
        public void InstanceStationMachineTaskButton(int button)
        {
            if (button == 1)
            {
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[_station.Name]).Stop();
                Thread.Sleep(50);
                TaskSmManger.Instance.TaskSMs[_station.Name].Terminate();
                _station.StationMachineInited = false;
            }
            else if (button == 2)
            {
                TaskInit(asyncMode: true);
            }
        }

        /// <summary>响应清除报警</summary>
        public void InstanceClrErr(AlertInfo alertInfo)
        {
            TaskSmManger.Instance.TaskSMs[_station.Name].PostEvent(UserEventType.ClrErr, TaskSmManger.Instance.TaskSMs[_station.Name]);
        }

        /// <summary>启动</summary>
        public void Run()
        {
            if (AutoManualStationSM.Instance.State == SmStates.Manual)
            {
                Notification.ShowWarn(NLocalizer.PleaseSwitchAutoMode);
                return;
            }

            SmStates currentState = TaskSmManger.Instance.TaskSMs[_station.Name].State;
            _cts = new CancellationTokenSource();
            if (currentState == SmStates.WaitReset)
            {
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[_station.Name]).Reset();
                LogMain.Instance.Flag_MonitorAlterInfo = false;
                Thread.Sleep(100);
                while (true)
                {
                    currentState = TaskSmManger.Instance.TaskSMs[_station.Name].State;
                    if (_cts.IsCancellationRequested)
                    {
                        LogMain.Instance.Flag_MonitorAlterInfo = false;
                        return;
                    }

                    if (currentState == SmStates.WaitRun || currentState != SmStates.Resetting)
                    {
                        if (currentState == SmStates.WaitRun)
                        {
                            if (UIMessageDialog.ShowMessageDialog(NLocalizer.InitDoneConfirmEnterRunningMode, "提示", true, NLocalizer.Yes, NLocalizer.No, UIStyle.Orange))
                            {
                                _idleCts?.Cancel();
                                LogMain.Instance.Flag_MonitorAlterInfo = false;
                                break;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            LogMain.Instance.Flag_MonitorAlterInfo = false;
                            break;
                        }
                    }

                    Application.DoEvents();
                    Thread.Sleep(5);
                }

                Thread.Sleep(20);
            }

            currentState = TaskSmManger.Instance.TaskSMs[_station.Name].State;
            if (currentState == SmStates.WaitRun || currentState == SmStates.Pause)
            {
                ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[_station.Name]).Start();
            }
        }

        private CancellationTokenSource _idleCts;
        /// <summary>暂停</summary>
        public void Pause()
        {
            _cts.Cancel();
            ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[_station.Name]).Pause();
            #region Idle判断
            // 取消之前的任务
            _idleCts?.Cancel();
            _idleCts = new CancellationTokenSource();
            try
            {
                Task.Delay(TimeSpan.FromSeconds(90), _idleCts.Token).ContinueWith((p =>
                {
                    try
                    {
                        if (p.IsCompleted && !p.IsCanceled && !p.IsFaulted)
                        {

                            HiveManagerV3.Instance.Fire(HiveTrigger.Pause);
                            //this.HiveState = HiveManagerV2.Instance.CurrentState;
                        }
                        else if (p.IsCanceled)
                        {
                            Debug.WriteLine("任务已被取消，不执行Fire");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($@"取消计时{ex}");
                    }
                }));
                // 如果没有被取消，则设置状态

            }
            catch (OperationCanceledException)
            {
                // 任务被取消，什么都不做
            }
            #endregion
        }

        /// <summary>停止</summary>
        public void Stop()
        {
            _cts.Cancel();
            ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[_station.Name]).Stop();
        }

        /// <summary>机台状态设置</summary>
        /// <param name="state"></param>
        public void SetState(string state)
        {
            _vendor.SetState(state);
        }

        /// <summary>产品换型使能设置</summary>
        /// <param name="enable"></param>
        public void SetProductsEnable(bool enable)
        {
            _vendor.SetProductsEnable(enable);
        }

        /// <summary>获取所有线程的Idle状态</summary>
        /// <returns></returns>
        public bool GetAllTaskThreadState()
        {
            return TasksManagerTransfer.GetAllITask().All(t => t.ThreadIdleState == true);
        }

        public override void Init()
        {
            base.Init();
            btnAutoSw.Checked = false;
        }

        public void ChangeToVendorPage(string pageName)
        {
            btnAutoSw.Checked = true;
            _vendor.ChangeToPage(pageName);
        }

        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        /// <summary>初始化</summary>
        /// <param name="asyncMode">是否异步</param>
        public void TaskInit(bool asyncMode)
        {
            Action a = delegate
            {
                SingleRecipeCfg currentRecipe = _station.CurrentRecipe;
                if (currentRecipe.Tasks.Count < 1)
                {
                    Notification.ShowWarn(string.Format(NLocalizer.GetString("Lead_CPrim_FormMain_DevMainForm_ErrMsg_LoadConfigFail", "工站={0}未配置任务成员，请检查并重新配置！！！"), _station.Name));
                }
                else
                {
                    _initing = true;
                    ((TaskStationMachine)TaskSmManger.Instance.TaskSMs[_station.Name]).OnInitedSuccess += OnStateMachineInited;
                    TaskSmManger.Instance.TaskSMs[_station.Name].Initialize(_station);
                }
            };
            if (asyncMode)
            {
                a.BeginInvoke(null, null);
            }
            else
            {
                a();
            }
        }
        /// <summary>工站主界面更新</summary>
        private void UpdateMainPrimsOutput()
        {
            try
            {
                tlpMain.Margin = new Padding(0);
                tlpMain.Padding = new Padding(0);

                tabMain.Margin = new Padding(0);
                tabMain.Padding = new Point(0, 0);

                tPageState.Margin = new Padding(0);
                tPageState.Padding = new Padding(0);
                tPageQualify.Margin = new Padding(0);
                tPageQualify.Padding = new Padding(0);

                SingleDisplayConfig currentDisplay = _station.CurrentDisplayConfig;
                if (currentDisplay == null)
                {
                    return;
                }
                if (currentDisplay.Name.ToLower().Contains("qualify"))
                {
                    tabMain.TabPages.Clear();
                    tabMain.TabPages.Add(_mainPages["tPageQualify"]);
                    AddTablePanelDisplay(ref tlpQualify, currentDisplay.TabPagesDisplayConfig.First((KeyValuePair<Guid, TabDisplayConfig> p) => p.Value != null).Value);
                    return;
                }
                if (Settings1.Default.IsShowState)
                {
                    tabMain.TabPages.Add(_mainPages["tPageState"]);
                    if (currentDisplay.TabPagesDisplayConfig.Count <= 1)
                    {
                        tPageState.Controls.Clear();
                        TableLayoutPanel newTablePanelPrims2 = new TableLayoutPanel
                        {
                            Dock = DockStyle.Fill,
                            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                            Margin = new Padding(0),
                            Padding = new Padding(0),
                        };
                        AddTablePanelDisplay(ref newTablePanelPrims2, currentDisplay.TabPagesDisplayConfig.FirstOrDefault((KeyValuePair<Guid, TabDisplayConfig> p) => p.Value != null).Value);
                        tPageState.Controls.Add(newTablePanelPrims2);
                    }
                    else
                    {
                        tabState.TabPages.Clear();
                        foreach (KeyValuePair<Guid, TabDisplayConfig> tabDisplayConfig in currentDisplay.TabPagesDisplayConfig.OrderBy((KeyValuePair<Guid, TabDisplayConfig> p) => p.Value.TabIndex))
                        {
                            if (!tabDisplayConfig.Value.Enable)
                            {
                                continue;
                            }
                            tabState.TabPages.Add(tabDisplayConfig.Value.Name, tabDisplayConfig.Value.Name);
                            TableLayoutPanel newTablePanelPrims = new TableLayoutPanel
                            {
                                Dock = DockStyle.Fill,
                                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                                Margin = new Padding(0),
                                Padding = new Padding(0),
                            };
                            AddTablePanelDisplay(ref newTablePanelPrims, tabDisplayConfig.Value);
                            tabState.TabPages[tabDisplayConfig.Value.Name].Controls.Add(newTablePanelPrims);
                        }
                        if (!tPageState.Controls.Contains(tabState))
                        {
                            tPageState.Controls.Add(tabState);
                        }
                    }
                }
                else
                {
                    tabState.TabPages.Clear();
                    foreach (KeyValuePair<Guid, TabDisplayConfig> tabDisplayConfig in currentDisplay.TabPagesDisplayConfig.OrderBy((KeyValuePair<Guid, TabDisplayConfig> p) => p.Value.TabIndex))
                    {
                        if (!tabDisplayConfig.Value.Enable)
                        {
                            if (tabMain.TabPages.ContainsKey(tabDisplayConfig.Value.Name))
                            {
                                tabMain.TabPages.RemoveByKey(tabDisplayConfig.Value.Name);
                            }
                            continue;
                        }
                        if (!tabMain.TabPages.ContainsKey(tabDisplayConfig.Value.Name))
                        {
                            tabMain.TabPages.Add(tabDisplayConfig.Value.Name, tabDisplayConfig.Value.Name);
                        }
                        tabMain.TabPages[tabDisplayConfig.Value.Name].Controls.Clear();
                        TableLayoutPanel newTablePanelPrims = new TableLayoutPanel
                        {
                            Dock = DockStyle.Fill,
                            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                            Margin = new Padding(0),
                            Padding = new Padding(0),
                        };
                        AddTablePanelDisplay(ref newTablePanelPrims, tabDisplayConfig.Value);
                        tabMain.TabPages[tabDisplayConfig.Value.Name].Controls.Add(newTablePanelPrims);
                        tabMain.SelectedTab = tabMain.TabPages[tabDisplayConfig.Value.Name];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(_station.Name + NLocalizer.GetString("Lead_CPrim_FormMain_DevMainForm_ErrMsg_LoadConfigFail", "的主界面显示配置加载失败！") + ex.Message);
            }
        }
        /// <summary>TableLayoutPanel增加控件</summary>
        /// <param name="newTablePanelPrims"></param>
        /// <param name="tabConfig"></param>
        private void AddTablePanelDisplay(ref TableLayoutPanel newTablePanelPrims, TabDisplayConfig tabConfig)
        {
            if (tabConfig == null)
            {
                return;
            }
            newTablePanelPrims.ColumnCount = tabConfig.ColCount;
            newTablePanelPrims.RowCount = tabConfig.RowCount;
            newTablePanelPrims.ColumnStyles.Clear();
            if (tabConfig.ColCount > 0)
            {
                for (int i = 0; i < tabConfig.ColCount; i++)
                {
                    newTablePanelPrims.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)Math.Round(1.0 / (double)tabConfig.ColCount, 2)));
                }
            }
            newTablePanelPrims.RowStyles.Clear();
            if (tabConfig.RowCount > 0)
            {
                for (int j = 0; j < tabConfig.RowCount; j++)
                {
                    newTablePanelPrims.RowStyles.Add(new RowStyle(SizeType.Percent, (float)Math.Round(1.0 / (double)tabConfig.RowCount, 2)));
                }
            }
            IPrim[] prims = new IPrim[tabConfig.Prims.Count];
            IShow[] shows = new IShow[tabConfig.Prims.Count];
            for (int k = 0; k < tabConfig.Prims.Count; k++)
            {
                prims[k] = PrimsManagerTransfer.GetPrimByName(tabConfig.Prims[k].Name);
                shows[k] = ShowManagerTransfer.GetShowByName(tabConfig.Prims[k].Name);
                if (!tabConfig.Prims[k].Enable)
                {
                    continue;
                }
                if (prims[k] != null)
                {
                    if (prims[k].Name.ToLower().Contains("testreal"))
                    {
                        Map3D map3d = new Map3D();
                        ColorRuler colorRule = new ColorRuler();
                        ((I3DAgl)prims[k]).LogicControl.Graph3D = map3d;
                        ((I3DAgl)prims[k]).LogicControl.ColorRuler3D = colorRule;
                        ((Control)(object)map3d).Dock = DockStyle.Fill;
                        newTablePanelPrims.Controls.Add((Control)(object)map3d, tabConfig.Prims[k].ColNum, tabConfig.Prims[k].RowNum);
                        newTablePanelPrims.SetColumnSpan((Control)(object)map3d, tabConfig.Prims[k].ColSpan);
                        newTablePanelPrims.SetRowSpan((Control)(object)map3d, tabConfig.Prims[k].RowSpan);
                    }
                    else if (prims[k]?.PrimOutputUI != null)
                    {
                        prims[k].PrimOutputUI.Dock = DockStyle.Fill;
                        newTablePanelPrims.Controls.Add(prims[k].PrimOutputUI, tabConfig.Prims[k].ColNum, tabConfig.Prims[k].RowNum);
                        newTablePanelPrims.SetColumnSpan(prims[k].PrimOutputUI, tabConfig.Prims[k].ColSpan);
                        newTablePanelPrims.SetRowSpan(prims[k].PrimOutputUI, tabConfig.Prims[k].RowSpan);
                    }
                }
                else if (shows[k] != null && shows[k]?.OutputUi != null)
                {
                    shows[k].OutputUi.Dock = DockStyle.Fill;
                    newTablePanelPrims.Controls.Add(shows[k].OutputUi, tabConfig.Prims[k].ColNum, tabConfig.Prims[k].RowNum);
                    newTablePanelPrims.SetColumnSpan(shows[k].OutputUi, tabConfig.Prims[k].ColSpan);
                    newTablePanelPrims.SetRowSpan(shows[k].OutputUi, tabConfig.Prims[k].RowSpan);
                }
            }
        }

        /// <summary>日志</summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public void LogAdd(string msg, LogLevel lv, long id = 0, bool isShowDialog = false)
        {
            msg = $"DevMainForm -> " + msg;
            string tempId = $"{(int)lv}{(int)PrimLogId.FormMain}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.PrimCommon.ToString(), LogClassification.Module, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                ShowWarningDialog(msg);
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        private void CloseStationForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CloseStationForm));
            }
            else if (_station != null && TaskSmManger.Instance.TaskSMs.ContainsKey(_station.Name))
            {
                Stop();
                Thread.Sleep(1000);
                InstanceStationMachineTaskButton(1);
            }
        }
        #endregion

        public void OnLanguageChanged()
        {
            btnAutoSw.UnCheckedText = NLocalizer.GetString("Lead_CPrim_FormMain_DevMainForm_Main", "主页面");
            btnAutoSw.CheckedText = NLocalizer.GetString("Lead_CPrim_FormMain_DevMainForm_Vendor", "供应商");
        }

        private void DevMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            NLocalizer.LanguageChanged -= OnLanguageChanged;
        }
    }
}
