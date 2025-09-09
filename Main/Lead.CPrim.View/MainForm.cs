/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: MainForm.cs
 * Author: Victor
 * Description: 主界面
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0617><Victor><20220718>
 * 1、事件OnGetLog/OnGetAlarm/OnSoftwareConfigChangeCurrentProduct/OnUpdateProducts/InstanceDynamicParamChangeCurrentProduct优化
 * 
 * <Victor><20220725>
 * 2、全局参数、换型参数编辑状态优化
 * 
 * <3.3.22.0728><Victor><20220729>
 * 1、增加设备参数定期保存（CopyMachineConfig）
 * 2、报警日志滚动优化
 * <Victor><20220903>
 * 1、软件主界面新增软件打开持续时间
******************************************************************************/

using Lead.CPrim.CommonParam;
using Lead.CPrim.Controls;
using Lead.CPrim.FormMain;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Register;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.StationCommon;
using Lead.CPrim.StationCommon.Alert;
using Lead.CPrim.StationControl;
using Lead.CPrim.TaskHelper;
using Lead.CPrim.View.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lead.CPrim.View
{
    public partial class MainForm : Form
    {
        #region Field
        //地址
        /// <summary>应用程序起始地址</summary>
        private static readonly string _curDominStartPath = Application.StartupPath;
        /// <summary>软件Logo地址</summary>
        private readonly string _mainLogoPath = Environment.CurrentDirectory + "\\Configs\\ProjectConfigs\\MainLogo.png";
        /// <summary>基元地址</summary>
        private readonly string _primsAssemblyPath = _curDominStartPath + "\\InnerLibs\\VisioPrims";
        /// <summary>显示地址</summary>
        private readonly string _showAssemblyPath = _curDominStartPath + "\\InnerLibs\\Display";


        //表单
        /// <summary>主界面</summary>
        private DevMainForm mainForm;
        /// <summary>设备参数</summary>
        SettingFrm setting;//= new SettingFrm();

        /// <summary>
        /// 模式切换
        /// </summary>
        ModeSelection modeSelection;

        /// <summary>工艺参数</summary>
        ConfigForm _configForm;

        //变量
        /// <summary>计时进行权限退出</summary>
        static int iOperCount = 0;
        /// <summary>截获本程序向系统发出的消息的次数</summary>
        int msgTims = 0;
        /// <summary>判断有无操作，退出高级权限</summary>
        MyMessager msg = new MyMessager();
        /// <summary>报警信息</summary>
        public string _alarm;
        /// <summary>报警计时</summary>
        private int _alarmCount = 0;
        /// <summary>报警锁</summary>
        private static readonly object _objAlarm = new object();
        /// <summary>基元配置管理器</summary>
        private PrimConfigs _primConfigs = new PrimConfigs();
        /// <summary>显示配置管理器</summary>
        private ShowConfigs _showConfigs = new ShowConfigs();
        /// <summary>软件开启时间</summary>
        private DateTime _softWareOpenTime = DateTime.Now;
        /// <summary>主界面按钮集合</summary>
        private Dictionary<string, UIImageButton> _mainFormButton = new Dictionary<string, UIImageButton>();
        /// <summary>记录报警时间</summary>
        private Queue<DateTime> _queueAlarmTime = new Queue<DateTime>();

        /// <summary>
        /// true：按钮显示；false：按钮不显示；
        /// </summary>
        private bool _showBtn = false;

        private bool flag_Light = true;

        /// <summary>
        /// 状态机当前状态
        /// </summary>
        SmStates _currentState = SmStates.Manual;

        /// <summary>
        /// 当前工作模式
        /// </summary>
        运行模式 _currentWorkMode = 运行模式.Other;

        /// <summary>
        /// true:切换模式使能；false：切换模式禁止
        /// </summary>
        bool _changeModeEnable;

        /// <summary>
        /// 软件首次打开
        /// </summary>
        bool _softFirstOpen = true;
        #endregion



        #region Prop
        /// <summary>
        /// 报警信息
        /// </summary>
        public string Alarm
        {
            get => _alarm;
            set
            {
                lock (_objAlarm)
                {
                    if (_alarm == value || (tmrAlarm.Enabled && _currentState != SmStates.Running))
                    {
                        return;
                    }

                    tmrAlarm.Stop();
                    string temp = $"                {value}";
                    _alarm = temp;
                    lblAlarm.Text = temp;
                    _alarmCount = 0;
                    tmrAlarm.Start();
                }
            }
        }

        /// <summary>
        /// 当前工作模式
        /// </summary>
        public 运行模式 CurrentWorkMode
        {
            get => _currentWorkMode;
            set
            {
                if (_currentWorkMode != value)
                {
                    if (!_softFirstOpen)
                    {
                        DialogForOperateLoginForm.Instance.EnqueueDialog($"运行模式切换至{value}", ok =>
                        {
                            if (ok &&
                            !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID) &&
                            CommonParamForm.Instance.ModeChange(value.ToString()) == 0)
                            {
                                UIWaitFormService.ShowWaitForm(NLocalizer.ModeChangePleaseWait);
                                SpinWait.SpinUntil(() => HiveManager.GetCurrentHiveStatus() == HiveStatus.Plan_DT, 2 * 1000);
                                mainForm.InstanceStationMachineTaskButton(1);
                                Thread.Sleep(1000);
                                mainForm.InstanceStationMachineTaskButton(2);
                                Thread.Sleep(1000);
                                UIWaitFormService.HideWaitForm();

                                _currentWorkMode = value;
                            }
                        });
                    }
                    else
                    {
                        _softFirstOpen = false;
                        _currentWorkMode = value;
                    }
                }
            }
        }
        #endregion



        #region Ctor
        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            tlpMain.SetDoubleBuffered();
            tlpState.SetDoubleBuffered();
            tlpButton.SetDoubleBuffered();
        }
        #endregion



        #region System_Event
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (HiveManager.GetCurrentHiveStatus() != HiveStatus.Idle)
                {
                    if (!this.ShowAskDialog(NLocalizer.GetString("Lead_CPrim_View_MainForm_ErrMsg_ConfirmCloseMainFromWithNoIdle", "         当前Hive状态非Idle\r\n                您确定要关闭软件吗?"), UIStyle.Red))
                    {
                        e.Cancel = true;
                        return;
                    }

                    CloseTask();

                    LogHelper.LogAdd(LogLevel.Info, "关闭软件：" + HiveManager.GetCurrentHiveStatus(), "mainform");
                    Thread.Sleep(200);
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
                else
                {
                    if (!this.ShowAskDialog(NLocalizer.GetString("Lead_CPrim_View_MainForm_ConfirmCloseMainFrom", "您确定要关闭软件吗?"), UIStyle.LayuiOrange))
                    {
                        e.Cancel = true;
                        return;
                    }

                    CloseTask();

                    LogHelper.LogAdd(LogLevel.Info, "关闭软件：" + HiveManager.GetCurrentHiveStatus(), "mainform");
                    Thread.Sleep(200);
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
            }
            catch
            {
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            //UIStatusFormService.ShowStatusForm(100, "加载 -> 软件配置");
            //主题
            {
                //dockFramePanel.Theme = blue;
                //if (dockFramePanel.Theme.ColorPalette != null)
                //{
                //    //msTool.BackColor = dockFramePanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
                //    msTool.BackColor = SystemColors.ControlDark;
                //}
            }

            //主界面增加登录模块
            {
                AuthorityManager.Instance.LvlShowUI.Dock = DockStyle.Fill;
                panelAuthority.Controls.Add(AuthorityManager.Instance.LvlShowUI);
            }

            if (!ServiceHelper.MongoDBServiceIsRunning())
            {
                UIMessageTip.ShowError("请开启MongoDB服务", -1, false, new Point(Width / 2, Height / 2), true);
                await Task.Delay(3000);
                Process.GetCurrentProcess().Kill();
                Environment.Exit(0);
            }

            //软件配置
            {
                try
                {
                    if (AuthorityManager.Instance.GetSoftLockConfig() != 0)
                    {
                        throw new Exception("获取软件加密狗配置失败");
                    }

                    if (SwManager.Instance.Init() != 0)
                    {
                        throw new Exception("初始化失败");
                    }

                    if (SwManager.Instance == null)
                    {
                        throw new Exception("软件配置对象为Null");
                    }

                    if (SwManager.Instance.HasAccessary)
                    {
                        string[] strs = SwManager.Instance.AccessaryNames.Trim(';').Split(';');
                        string[] strc = SwManager.Instance.AccessaryCodeLength.Trim(';').Split(';');
                        if (strs != null && strc != null)
                        {
                            List<(string, string)> values = new List<(string, string)>();
                            for (int i = 0; i < strs.Length; i++)
                            {
                                values.Add((strs[i], string.Empty));
                                for (int j = 0; j < strc.Length; j++)
                                {
                                    if (i == j)
                                    {
                                        values[i] = (strs[i], strc[j]);
                                        break;
                                    }
                                }
                            }

                            AuthorityManager.Instance.AccessaryInfos = values;
                            AuthorityManager.Instance.AccessaryNames = new List<string>(strs);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogAdd($"软件配置加载失败 => {ex.Message}", LogLevel.Warn);
                }
            }

            //全局参数加载
            CommonParamForm.Instance.OnModeSwitchView += InstanceOnModeSwitch;

            {
                UIStatusFormService.SetInfo("加载 -> 工站", 10);
                StationManager.Instance.Init();
            }

            //系统状态机
            {
                try
                {
                    TaskSmManger.Instance.Init(StationManager.Instance.Stations.Keys.ToArray());
                    SysStationSM.Instance.Initialize(null);
                }
                catch (Exception ex)
                {
                    this.ShowErrorDialog(NLocalizer.TaskStationMachineInitError + ex.Message);
                }
            }

            {
                try
                {
                    UIStatusFormService.SetInfo("加载 -> 基元", 10);
                    int num = -1;
                    if (PrimsManagerTransfer.LoadPrimTypeAttributes(_primsAssemblyPath) != 0)
                    {
                        throw new Exception($"反射基元dll失败！！！");
                    }
                    Thread.Sleep(20);
                    if (SwManager.Instance.PrimsConfigEnable && File.Exists(SwManager.Instance.PrimsFile))
                    {
                        _primConfigs = (XmlSerializerHelper.ReadXML(SwManager.Instance.PrimsFile, typeof(PrimConfigs)) as PrimConfigs);
                        if (_primConfigs == null)
                        {
                            throw new Exception("基元配置文件读取失败！！！");
                        }
                        num = SystemCreatePrims(SwManager.Instance.PrimsFile);
                        if (num != 0)
                        {
                            throw new Exception("基元集合生成失败！！！");
                        }
                        num = PrimsManagerTransfer.PrimsConfigFormInit(_primsAssemblyPath);
                        if (num != 0)
                        {
                            throw new Exception("基元UI生成失败！！！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogAdd($"基元加载失败，异常信息：{ex.Message}", LogLevel.Warn);
                }
            }

            //第三方Dll
            {
                if (!UIGlobal.DefinePath.IsNullOrWhiteSpace() && Directory.Exists(UIGlobal.DefinePath))
                {
                    string[] paths = Directory.GetFiles(UIGlobal.DefinePath, "*", SearchOption.TopDirectoryOnly);
                    string pathDestination = UIGlobal.DefinePath.Substring(0, UIGlobal.DefinePath.LastIndexOf("\\"));
                    foreach (var item in paths)
                    {
                        FileInfo info = new FileInfo(item);
                        string pathTmp = Path.Combine(pathDestination, info.Name);
                        if (File.Exists(pathTmp))
                        {
                            File.Delete(pathTmp);
                        }
                        File.Move(info.FullName, pathTmp);
                    }
                }
                else if (!UIGlobal.DefinePath.IsNullOrWhiteSpace())
                {
                    Directory.CreateDirectory(UIGlobal.DefinePath);
                }
            }

            {
                try
                {
                    UIStatusFormService.SetInfo("加载 -> 显示", 10);
                    if (ShowManagerTransfer.LoadShowTypeAttributes(_showAssemblyPath) != 0)
                    {
                        throw new Exception("显示类库加载失败！");
                    }
                    Thread.Sleep(100);

                    if (SwManager.Instance.DisplayConfigEnable && File.Exists(SwManager.Instance.DisplayFile))
                    {
                        _showConfigs = XmlSerializerHelper.ReadXML(SwManager.Instance.DisplayFile, typeof(ShowConfigs)) as ShowConfigs;
                        int num5 = SystemCreateShow(SwManager.Instance.DisplayFile);
                        int num6 = ShowManagerTransfer.ShowConfigFormInit(_showAssemblyPath);
                        if (_showConfigs == null || num5 != 0 || num6 != 0)
                        {
                            throw new Exception("显示基元配置加载失败！");
                        }
                    }
                }
                catch (Exception ex3)
                {
                    LogAdd($"显示基元加载失败，异常信息：{ex3.Message}", LogLevel.Warn);
                }
            }

            //欢迎界面
            {
                var welcome = new WelcomeForm();
                welcome.ShowDialog();
            }

            //事件订阅
            {
                //权限
                _mainFormButton.Clear();
                _mainFormButton.Add(BtnEnum.BtnHome.ToString(), BtnHome);
                _mainFormButton.Add(BtnEnum.BtnAlert.ToString(), BtnAlert);
                _mainFormButton.Add(BtnEnum.BtnConfig.ToString(), BtnConfig);
                _mainFormButton.Add(BtnEnum.BtnData.ToString(), BtnData);
                _mainFormButton.Add(BtnEnum.BtnVision.ToString(), BtnVision);
                _mainFormButton.Add(BtnEnum.BtnSetting.ToString(), BtnSetting);
                AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
                AuthorityManager.OnUpdateLevelOther += InstanceUpdateLevel;
                AuthorityManager.Instance.ChangeLevel(OpLevel.NoLogin);
                BtnHome.Selected = true;

                //工站
                StationManager.Instance.OnAddNewStation += InstanceOnOnAddNewStation;
                StationManager.Instance.OnRemoveStation += InstanceOnOnRemoveStation;
                StationManager.Instance.OnUpdateStation += InstanceOnOnUpdateStation;

                //软件配置
                SwManager.Instance.OnUpdateSwName += InstanceOnUpdateSwName;
                InstanceOnUpdateSwName(UIGlobal.Version); // SwManager.Instance.SwName
                SwManager.Instance.OnSoftwareConfigChangeCurrentProduct += InstanceSoftwareConfigChangeCurrentProduct;

                //日志
                InstanceOnUpdateTaskLogUINo(SwManager.Instance.TaskLogUINo);
                SwManager.Instance.OnUpdateTaskLogUINo += InstanceOnUpdateTaskLogUINo;
                LogHelper.OnGetLog += InstanceGetLog;
                LogHelper.OnGetAlarm += InstanceGetAlarm;
                foreach (var t in TaskSmManger.Instance.TaskSMs.Values)
                {
                    ((TaskStationMachine)t).LogEvent += UpdateTaskLog;
                    ((TaskStationMachine)t).LogEventType += InstanceLogEventType;
                    ((TaskStationMachine)t).ShowAlarmEvent += InstanceShowAlarmEvent;
                }

                //参数
                setting = new SettingFrm();
                setting.OnInformationChange += InstanceInformationChange;
                InstanceInformationChange(4, setting._setting.CurrentStation);
                _configForm = new ConfigForm();

                ProxyData.Instance.OnSkipUI += InstanceSkipUI;
                ProxyData.Instance.OnShowSensor += InstanceShowSensor;
                ProxyData.Instance.OnClrSensor += InstanceCloseSensor;

                //状态机
                TaskSmManger.Instance.TaskSMs[StationManager.Instance.CurrentStationName].StateChangeEvent += InstanceStateChangeEvent;
                AutoManualStationSM.Instance.StateChangeEvent += InstanceAutoManualChange;
                InstanceAutoManualChange(SmStates.Auto, null);

                //HIVE
                HiveManager.OnHiveChange += InstanceHiveChange;
            }


            //初始化配方上传、切换
            {
                if (SwManager.Instance.IsRecipeShiftByServer)
                {
                    int ret = StationControlManager.Insantace.IntiStationControl(StationManager.Instance.Stations, SwManager.Instance.RecipeShiftSuperClientName);
                    if (ret == 0)
                    {
                        StationControlManager.Insantace.StartListenCmdFromServer();
                    }
                }
            }

            //工站UI更新
            {
                AddNewStationForm(StationManager.Instance.CurrentStation);
                AlertFrm.Instance.OnAfterClrErrorInfo += mainForm.InstanceClrErr;
                AlertFrm.Instance.OnBeforeDisplayAlertFrmDialog += InstanceShowAudioAlarm;
                lblAlarm.ForeColor = Color.DarkRed;
                AuthorityManager.Instance.LvlShowUI.OnToolStripStatus += InstanceToolStripStatus;
                InstanceToolStripStatus(HiveManager.GetCurrentHiveStatus());
            }

            //CPU、内存
            {
                CurrentWorkMode = 运行模式.正常生产;

                tsbtn.DropDownDirection = ToolStripDropDownDirection.AboveLeft;
                tsmiTest.Visible = false;
                tsmiAuthority.Visible = false;
                tsmiTesuFuc.Visible = false;

                stuStatus.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                tslblMode.Alignment = ToolStripItemAlignment.Right;
                tslblMemory.Alignment = ToolStripItemAlignment.Right;
                tslblCpuRate.Alignment = ToolStripItemAlignment.Right;
                tslblTimer.Alignment = ToolStripItemAlignment.Right;
                tslblAutoManual.Alignment = ToolStripItemAlignment.Right;
                tmrSoftWare.Start();
                tmrUIRefresh.Start();
                UIStatusFormService.SetInfo("加载 -> 结束", 100);
            }

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        /// <summary>
        /// 组合快捷键<br/>
        /// 需配合this.KeyPreview = true;否则不生效<br/>
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.F12)
            {
                bool verify = AuthorityManager.Instance.VerifyLevel3Permission(false);
                if (verify)
                {
                    _showBtn = !_showBtn;
                    tsmiTest.Visible = _showBtn;
                    tsmiAuthority.Visible = _showBtn;
                    tsmiTesuFuc.Visible = _showBtn;
                }
                else
                {
                    _showBtn = false;
                    tsmiTest.Visible = false;
                    tsmiAuthority.Visible = false;
                    tsmiTesuFuc.Visible = false;
                }
            }
            else if (e.Control & e.KeyCode == Keys.F11)
            {
                AuthorityManager.Instance.LvlShowUI.EnableLogin = !AuthorityManager.Instance.LvlShowUI.EnableLogin;
                if (AuthorityManager.Instance.LvlShowUI.EnableLogin)
                {
                    Notification.ShowInfo(NLocalizer.Enable);
                }
                else
                {
                    Notification.ShowError(NLocalizer.Forbid);
                }
            }
        }
        #endregion



        #region Button_Event
        // 菜单栏

        /// <summary>注册</summary>
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorityManager.Instance.OpenRegisterForm();
        }


        // 操作栏
        /// <summary>操作栏按钮</summary>
        private void BtnBar_Click(object sender, EventArgs e)
        {
            modeSelection?.Close();
            UIImageButton btn = (UIImageButton)sender;
            if (btn == null)
            {
                return;
            }
            UIPage page;
            if (btn.Name == BtnEnum.BtnHome.ToString())
            {
                page = mainForm;
                mainForm?.Init();
            }
            else if (btn.Name == BtnEnum.BtnAlert.ToString())
            {
                page = AlertFrm.Instance;
            }
            else if (btn.Name == BtnEnum.BtnConfig.ToString())
            {
                page = _configForm;
            }
            else if (btn.Name == BtnEnum.BtnData.ToString())
            {
                page = (DataForm)StationManager.Instance.CurrentStation.DataControl;
                ((DataForm)StationManager.Instance.CurrentStation.DataControl).Init();
            }
            else if (btn.Name == BtnEnum.BtnVision.ToString())
            {
                page = new VisionFrm();
            }
            else if (btn.Name == BtnEnum.BtnSetting.ToString())
            {
                page = setting;
            }
            else
            {
                Notification.ShowWarn("功能未开发");
                return;
            }

            if (page != null)
            {
                pnlMain.Controls.Clear();
                page.TopMost = false;
                page.TopLevel = false;
                page.Dock = DockStyle.Fill;
                page.Show();
                pnlMain.Controls.Add(page);
            }
            ButtonStyleChange(btn.Name);
        }

        /// <summary>启动</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            modeSelection?.Close();
            tsbtnClear_Click(null, null);
            mainForm.Run();
        }

        /// <summary>暂停</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaused_Click(object sender, EventArgs e)
        {
            modeSelection?.Close();
            mainForm.Pause();
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            modeSelection?.Close();
            string msg = NLocalizer.GetString("Lead_CPrim_View_MainForm_Confirm_to_change_HIVE_state_to_Downtime", "确认切换HIVE状态到[Downtime]!");
            DialogForOperateLoginForm.Instance.EnqueueDialog(msg, ok =>
            {
                if (ok && !string.IsNullOrWhiteSpace(AuthorityManager.Instance.CurrentOperatorID))
                {
                    LogHelper.LogAdd(LogLevel.Warn, "(Y-1)Manually Downtime In Main Page", "UI");
                    HiveManager.SetHiveStatusByManual(HiveStatus.DT);
                    mainForm.Stop();
                }
            });
        }

        /// <summary>
        /// 软件测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTest_Click(object sender, EventArgs e)
        {
            Dialog notice = new Dialog(15);
            for (int i = 0; i < 10; i++)
            {
                Dialog.ShowMessageDialogNoNotice("扫码NG");
            }
        }

        /// <summary>
        /// 超级权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAuthority_Click(object sender, EventArgs e)
        {
            SuperPermissions super = new SuperPermissions();
            super.StartPosition = FormStartPosition.CenterScreen;
            super.ShowDialog();
        }

        /// <summary>
        /// 方法测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTesuFuc_Click(object sender, EventArgs e)
        {
            //IShow show = ShowManagerTransfer.GetShowByName("Audio0");
            //((Interfaces.Display.IShowAudio)show).SetHiveStatus(0, HiveStatus.Idle, false);
            //((Interfaces.Display.IShowAudio)show).SetHiveStatus(HiveStatus.Running, HiveStatus.Idle, false);
            //LogAdd("测试成功", LogLevel.Info);
        }

        /// <summary>
        /// 教程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiLesson_Click(object sender, EventArgs e)
        {
            Learns.Instance.Show();
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            //LogAdd("(O-2)在规定时间[00:30:00],NG物料次数超过[5]个", LogLevel.Warn);
            //LogAdd("中国欢迎你", LogLevel.Warn);
            //return;

            //CsvHelper.ReadCsvToListString(@"D:\Destop\曲线\GMVHL50CF9800016ZQ\时间压力曲线.csv", Encoding.UTF8, true, out List<string> datas);
            //if (datas.IsNullOrEmpty())
            //{
            //    return;
            //}
            //IShow show = ShowManagerTransfer.GetShowByName("ShowPlcCurve0");
            //var s = (IShowPlcCurve)show;
            //Dictionary<double, double> dics = new Dictionary<double, double>();
            //foreach (var data in datas)
            //{
            //    var dataArray = data.Split(',');
            //    if (dataArray.Length < 2)
            //    {
            //        continue;
            //    }
            //    dics.Add(dataArray[0].ToDouble(), dataArray[1].ToDouble());
            //}
            //s.ChartControl(1, "123", dics);
            //return;

            //List<string> list = new List<string>();
            //for (int i = 0; i < 500; i++)
            //{
            //    list.Add("111,222,333,444,555,666,777,888,999,111,222,333,444,555,666,777,888,999,111,222,333,444,555,666,777,888,999,111,222,333,444,555,666,777,888,999,111,222,333,444,555,666,777,888,999");
            //}
            //for (int i = 0; i < 10000; i++)
            //{
            //    ModelMessage message = new ModelMessage
            //    {
            //        Path = Path.Combine(@"D:\Destop\Write", $"{i}.csv"),
            //        WriteServiceFormat = ModelFormat.CSV,
            //        IsReadOnly = true,
            //        IsStringBuilder = false,
            //        ContentsString = list,
            //        Title = "中,国,欢,迎,你",
            //    };
            //    ProducerConsumerModel.Instance.Add(message);
            //}
            //return;

            //StationManager.Instance.CurrentStation.SetStationStatictis("CCC", "DDD", 1);
            //StationManager.Instance.CurrentStation.SetStationStatictis("AAA", "BBB", 0, 10000, 11000);
            //return;

            string path = Path.Combine(Application.StartupPath, "version.log");
            if (!File.Exists(path))
            {
                return;
            }

            string msg = File.ReadAllText(path);
            VersionForm.Instance.SetInfo("Auout", "Main", "Lead", msg);
            VersionForm frm = VersionForm.Instance;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        /// <summary>清除报警</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            tmrAlarm.Stop();
            _alarmCount = 999;
            lblAlarm.Text = "";
            EventManager.SwitchStatus(SwitchStatus.ClrErr);
        }

        /// <summary>登出</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnLogOut_Click(object sender, EventArgs e)
        {
            AuthorityManager.Instance.ChangeLevel(OpLevel.NoLogin);
        }

        /// <summary>手自动切换</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslblAutoManual_Click(object sender, EventArgs e)
        {
            if (AutoManualStationSM.Instance.State == SmStates.Manual)
            {
                AutoManualStationSM.Instance.ToAutoMode();
            }
            else
            {
                AutoManualStationSM.Instance.ToManualMode();
            }
        }

        /// <summary>
        /// 模式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslblMode_Click(object sender, EventArgs e)
        {
            try
            {
                tslblMode.Enabled = false;
                if (!_changeModeEnable)
                {
                    Notification.ShowWarn(NLocalizer.OnlyWaitResetStateCanBeSwitched);
                    return;
                }

                Form findFrm = null;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "ModeSelection")
                    {
                        findFrm = frm;
                        break;
                    }
                }

                if (findFrm != null)
                {
                    findFrm.Close();
                    findFrm.Dispose();
                    findFrm = null;
                }
                else
                {
                    modeSelection = new ModeSelection();
                    modeSelection.OnWorkModeClick += ModeSelection_OnWorkModeClick;

                    modeSelection.SetWorkMode(CurrentWorkMode);
                    modeSelection.TopMost = true;
                    modeSelection.Show();
                }
            }
            finally
            {
                tslblMode.Enabled = true;
            }
        }

        private void tsmlViewVersionExplanation_Click(object sender, EventArgs e)
        {
            ProcessHelper.ViewPicture(Path.Combine(Application.StartupPath, @"Images\Main\VersionExplanation.png"));
        }
        #endregion



        //*****************************************************************************
        #region Method_Instance
        /// <summary>权限等级改变时发生响应</summary>
        /// <param name="level">登录级别</param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<OpLevel>(InstanceUpdateLevel), level);
            }
            else
            {
                bool verify = level >= OpLevel.Level1;
                foreach (var btn in _mainFormButton.Values)
                {
                    if (btn.Name == BtnEnum.BtnConfig.ToString() || btn.Name == BtnEnum.BtnSetting.ToString())
                    {
                        btn.Enabled = verify;
                    }
                }

                if (level < OpLevel.Level1)
                {
                    BtnBar_Click(BtnHome, null);
                }

                //如果高权限 则进行操作检测
                if (verify)
                {
                    //截获本程序向系统发出的消息
                    Application.AddMessageFilter(msg);
                    tmrAuthority.Start();
                    msgTims++;
                }
                else
                {
                    //停止 截获本程序向系统发出的消息
                    for (int i = 0; i < msgTims; i++)
                    {
                        Application.RemoveMessageFilter(msg);
                    }
                    msgTims = 0;
                    tmrAuthority.Stop();
                }
            }
        }

        /// <summary>增加工站事件响应</summary>
        /// <param name="name"></param>
        private void InstanceOnOnAddNewStation(string name)
        {
            TaskSmManger.Instance.Add(name);
            AddNewStationForm(StationManager.Instance.Stations[name]);
            //if (SwManager.Instance.RecipeByProductMode && SwManager.Instance.DynamicParamEnable)
            //{
            //    _dynamicParamForm.Init(SwManager.Instance.DynamicParamDirPath);
            //}
        }
        /// <summary>删除工站事件响应</summary>
        /// <param name="name"></param>
        private void InstanceOnOnRemoveStation(string name)
        {
            TaskSmManger.Instance.Remove(name);
        }
        /// <summary>改变配方事件响应</summary>
        /// <param name="stationName"></param>
        /// <param name="recipeName"></param>
        private void Instance_OnChangeCurrentRecipe(string stationName, string recipeName)
        {
            if (SwManager.Instance != null)
            {
            }
        }
        /// <summary>新建配方事件响应</summary>
        /// <param name="stationName"></param>
        /// <param name="newRecipeName"></param>
        private void Instance_OnCreateNewRecipe(string stationName, string newRecipeName)
        {
            if (SwManager.Instance != null)
            {
            }
        }
        /// <summary>删除配方事件响应</summary>
        /// <param name="stationName"></param>
        /// <param name="removedRecipeName"></param>
        private void Instance_OnDeleteRecipe(string stationName, string removedRecipeName)
        {
        }
        /// <summary>响应更新软件名称事件</summary>
        /// <param name="name">名称</param>
        public void InstanceOnUpdateSwName(string name)
        {
            string tempName = string.IsNullOrEmpty(name) ? "CPrim." : name;
            this.SetText(tempName);
        }
        /// <summary>响应更新工站事件</summary>
        private void InstanceOnOnUpdateStation()
        {
            mainForm.DevMainFormLoadMainStationInfo();
        }

        /// <summary>报警显示(Audio)</summary>
        private void InstanceShowAudioAlarm()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(InstanceShowAudioAlarm));
            }
            else
            {
                BtnBar_Click(BtnAlert, null);
            }
        }

        /// <summary>
        /// 任务日志显示
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="log"></param>
        /// <param name="level"></param>
        public void UpdateTaskLog(string tab, string log, LogLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, string, LogLevel>(UpdateTaskLog), tab, log, level);
            }
            else
            {
                LogTask.Instance.UpdateLog(tab, log, level);
            }
        }
        /// <summary>自定义任务日志显示</summary>
        /// <param name="tab"></param>
        /// <param name="log"></param>
        /// <param name="type"></param>
        /// <param name="level"></param>
        public void InstanceLogEventType(string tab, string log, LogType type, LogLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, string, LogType, LogLevel>(InstanceLogEventType), tab, log, type, level);
            }
            else
            {
                LogTask.Instance.UpdateLogType(tab, log, type, level);
            }
        }
        void InstanceShowAlarmEvent(string msg, LogLevel level)
        {
            DialogForUIMessageFormOnlyOne.Instance.EnqueueDialog(msg);
        }
        //ProxyTools_日志帮助类事件订阅响应
        /// <summary>获取日志时发生</summary>
        /// <param name="msg"></param>
        /// <param name="lv"></param>
        /// <param name="classification"></param>
        private void InstanceGetLog(string msg, LogLevel lv, LogClassification classification)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, LogLevel, LogClassification>(InstanceGetLog), msg, lv, classification);
                return;
            }

            DateTime time = DateTime.Now;
            LogMain.Instance.LogAdd(lv, time.ToString("yyyyMMdd HH:mm:ss fff"), classification.ToString(), msg);
            lblLog.Text = $"{time.ToString("HH:mm:ss")} -> {msg.Trim()}";
        }

        /// <summary>获取报警时发生</summary>
        /// <param name="msg"></param>
        /// <param name="lv"></param>
        /// <param name="classification"></param>
        private void InstanceGetAlarm(string msg, LogLevel lv, LogClassification classification)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, LogLevel, LogClassification>(InstanceGetAlarm), msg, lv, classification);
                return;
            }

            DateTime time = DateTime.Now;
            LogMain.Instance.LogAdd(lv, time.ToString("yyyyMMdd HH:mm:ss fff"), classification.ToString(), msg);
            Alarm = $"{time.ToString("HH:mm:ss")} -> {msg.Trim()}";
        }

        //参数事件订阅响应
        /// <summary>模式切换时发生响应</summary>
        /// <param name="mode">模式</param>
        private void InstanceOnModeSwitch(string mode)
        {
            tslblMode.Text = mode;
        }
        /// <summary>换型参数切换当前产品时发生</summary>
        /// <param name="currentParam"></param>
        private void InstanceDynamicParamChangeCurrentProduct(string currentParam)
        {
            if (SwManager.Instance == null)
            {
                LogAdd("软件配置管理器为空", LogLevel.Warn);
                return;
            }
            //软件配置管理器切换产品
            SwManager.Instance.ChangeCurrentProduct(currentParam, false);
            //主界面切换产品
            mainForm.ChangeCurrentProduct(currentParam);
        }

        //软件配置事件订阅响应
        /// <summary>软件配置切换当前产品时发生</summary>
        /// <param name="productname"></param>
        /// <param name="products">产品集合</param>
        private void InstanceSoftwareConfigChangeCurrentProduct(string productname, List<string> products)
        {
            //换型参数切换产品
            setting.ReLoadDynamicParam();

            //主界面切换产品
            mainForm.ChangeCurrentProduct(productname, products);
        }

        //状态机
        /// <summary>响应工站状态机状态切换时发生事件</summary>
        /// <param name="state"></param>
        /// <param name="sender"></param>
        private void InstanceStateChangeEvent(SmStates state, IStateMachine sender)
        {
            if (state == SmStates.WaitClrErr)
            {
                _queueAlarmTime.Enqueue(DateTimeOffset.Now.LocalDateTime);
            }
            else if (state == SmStates.WaitReset)
            {
                _queueAlarmTime.Clear();
            }

            BtnAlert.ImageSelected = state == SmStates.WaitClrErr ? Resources.Alarm_Alerted : Resources.Alarm_Energized;
        }
        /// <summary>响应手自动状态机状态切换时发生事件</summary>
        /// <param name="state"></param>
        /// <param name="sender"></param>
        private void InstanceAutoManualChange(SmStates state, IStateMachine sender)
        {
            if (state == SmStates.Auto)
            {
                ElesManagerTransfer.EnableHandle(false);
                //_historyQueryForm?.EnableHandle(false);
                //tslblAutoManual.BackColor = Color.LawnGreen;
            }
            else if (state == SmStates.Manual)
            {
                ElesManagerTransfer.EnableHandle(true);
                //_historyQueryForm?.EnableHandle(true);
                //tslblAutoManual.BackColor = Color.IndianRed;
            }
            BeginInvoke(new Action(() =>
            {
                tslblAutoManual.BackColor = state == SmStates.Auto ? Color.LawnGreen : Color.IndianRed;
                if (state == SmStates.Auto)
                {
                    tslblAutoManual.Text = NLocalizer.GetString("Lead_CPrim_View_MainForm_Auto", "自动");
                }
                else if (state == SmStates.Manual)
                {
                    tslblAutoManual.Text = NLocalizer.GetString("Lead_CPrim_View_MainForm_Manual", "手动");
                }
            }));
        }

        /// <summary>响应任务日志UI数量发生变化时发生事件</summary>
        /// <param name="no"></param>
        private void InstanceOnUpdateTaskLogUINo(int no)
        {
            LogTask.Instance.UpdateLogUINo(no);
        }

        SensorFrm sensor = null;
        /// <summary>
        /// 
        /// </summary>
        private void InstanceShowSensor()
        {
            pnlMain.Controls.Clear();
            if (sensor == null)
            {
                sensor = new SensorFrm
                {
                    TopLevel = false,
                    TopMost = false,
                    Dock = DockStyle.Fill
                };
                ProxyData.Instance.OnUpdateSensorStatus += sensor.UpDateUI;
            }
            sensor.Show();
            pnlMain.Controls.Add(sensor);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InstanceSkipUI(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(InstanceSkipUI), name);
            }
            else
            {
                if (name == "BtnAlert")
                {
                    BtnBar_Click(BtnAlert, null);
                }
                else if (name == "BtnData")
                {
                    BtnBar_Click(BtnData, null);
                }
            }
        }

        private void InstanceCloseSensor()
        {
            UIPage page = mainForm;
            if (page != null)
            {
                pnlMain.Controls.Clear();
                page.TopMost = false;
                page.TopLevel = false;
                page.Dock = DockStyle.Fill;
                page.Show();
                pnlMain.Controls.Add(page);
            }
            ButtonStyleChange(BtnEnum.BtnHome.ToString());
        }

        private void InstanceToolStripStatus(HiveStatus status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<HiveStatus>(InstanceToolStripStatus), status);
            }
            else
            {
                tlpButton.BackColor = status switch
                {
                    HiveStatus.Engineering => Color.FromArgb(204, 171, 216),
                    HiveStatus.Plan_DT => Color.FromArgb(255, 215, 212),
                    HiveStatus.DT => Color.FromArgb(235, 115, 115),
                    _ => Color.Transparent,
                };
            }
        }

        //setting
        private void InstanceInformationChange(int index, string info)
        {
            if (index == 4)
            {
                string dir = @"D:\Config\Image";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string path = Path.Combine(dir, info + ".png");
                pnlTitle.Controls.Clear();
                if (File.Exists(path))
                {
                    PictureBox pictureBox = new PictureBox()
                    {
                        Dock = DockStyle.Fill,
                        Image = Image.FromFile(path),
                        SizeMode = PictureBoxSizeMode.Zoom,
                    };
                    pnlTitle.Controls.Add(pictureBox);
                }
                else
                {
                    pnlTitle.Margin = new Padding(1, 5, 1, 5);
                    pnlTitle.Font = new Font("@等线", 40.0F, FontStyle.Bold);
                    pnlTitle.ForeColor = Color.FromArgb(204, 204, 204);
                    pnlTitle.Text = info;
                }
            }
        }

        //ModeSelection
        private void ModeSelection_OnWorkModeClick(运行模式 workMode)
        {
            CurrentWorkMode = workMode;
            modeSelection.Dispose();
        }

        //Hive
        private void InstanceHiveChange(string mode)
        {
            if (mode.Contains("PD-13"))
            {
                CurrentWorkMode = 运行模式.CCD动静态模式;
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>日志增加</summary>
        /// <param name="msg">消息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示报警弹窗；false：不显示报警弹窗</param>
        private void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            string tempId = $"{(int)lv}{(int)PrimLogId.View}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.View.ToString(), LogClassification.Other, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }

        /// <summary>
        /// 增加新工站界面
        /// </summary>
        /// <param name="station"></param>
        private void AddNewStationForm(StationConfig station)
        {
            mainForm = new DevMainForm(station);
            mainForm.Show();
            pnlMain.Controls.Add(mainForm);
            mainForm.DevMainFormLoadMainStationInfo();

            station.OnChangeCurrentRecipe += Instance_OnChangeCurrentRecipe;
            station.OnCreateNewRecipe += Instance_OnCreateNewRecipe;
            station.OnDeleteRecipe += Instance_OnDeleteRecipe;
            station.OnStationMachineTaskButton += mainForm.InstanceStationMachineTaskButton;
        }

        /// <summary>报警日志滚动</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrAlarm_Tick(object sender, EventArgs e)
        {
            string text = lblAlarm.Text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (text.MeasureString(lblAlarm.Font).Width < lblAlarm.Width / 2)
            {
                lblAlarm.Text = Alarm;
                text = Alarm;
            }

            lblAlarm.Text = text.Substring(1, text.Length - 1);

            _alarmCount++;
            if (_alarmCount >= 200)
            {
                tmrAlarm.Stop();
                lblAlarm.Text = "";
            }
        }

        /// <summary>定时器_用于计时退出权限登录</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrAuthority_Tick(object sender, EventArgs e)
        {
            iOperCount++;
            // 此处增加如果强制登录的，30s自动退出
            var exitTime = AuthorityManager.Instance.LvlShowUI.EnableLogin ? 30 : SwManager.Instance.ExitPermissionTime;
            if (iOperCount > exitTime)
            {
                switch (AuthorityManager.Instance.Level)
                {
                    case OpLevel.Level2:
                    case OpLevel.Level3:
                        tsbtnLogOut_Click(null, null);
                        break;
                }
            }
        }

        /// <summary>鼠标键盘消息捕捉_用于软件操作时计时器重新计数</summary>
        internal class MyMessager : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                //如果检测到有鼠标或则键盘的消息，则使计数为0.....
                if (m.Msg == 0x0200 || m.Msg == 0x0201 || m.Msg == 0x0204 || m.Msg == 0x0207)
                {
                    iOperCount = 0;
                }
                return false;
            }
        }

        /// <summary>CPU/内存/打开时间统计及定期保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrSoftWare_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            #region 获取CPU、内部使用率
            try
            {
                tslblMemory.Text = $"{SystemEx.ProcessRamUsed().ToString("0.0")}MB";
            }
            catch
            {
                tslblMemory.Visible = false;
            }

            try
            {
                tslblCpuRate.Text = $"{SystemEx.CpuUsed().ToString("P1")}";
            }
            catch
            {
                tslblCpuRate.Visible = false;
            }
            #endregion

            #region 设备参数定期保存
            try
            {
                if (SwManager.Instance.DataSave != DataSaveMode.Other)
                {
                    if (SwManager.Instance.DataSave == DataSaveMode.ByEveryDay && time.Minute == 0 && time.Second == 0)
                    {
                        Task.Run(CopyMachineConfig);
                    }
                    else if (SwManager.Instance.DataSave == DataSaveMode.ByEveryWeek && time.DayOfWeek == DayOfWeek.Monday && time.Minute == 0 && time.Second == 0)
                    {
                        Task.Run(CopyMachineConfig);
                    }
                }
            }
            catch { }
            #endregion

            DateTime softWareOnTime = DateTime.Now;
            TimeSpan softWareDuration = softWareOnTime.Subtract(_softWareOpenTime);
            tslblTimer.Text = string.Format(NLocalizer.GetString("Lead_CPrim_View_MainForm_ShowTime", "{0}天{1}时{2}分{3}秒")
                , softWareDuration.Days
                , softWareDuration.Hours
                , softWareDuration.Minutes
                , softWareDuration.Seconds);
        }

        /// <summary>状态机定时刷新</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrUIRefresh_Tick(object sender, EventArgs e)
        {
            _changeModeEnable = false;
            if (mainForm == null)
            {
                return;
            }
            string state = "";
            bool enable = false;
            bool show = AuthorityManager.Instance.VerifyLevel2Permission();
            if (mainForm.Initing)
            {
                btnRun.Enabled = false;
                btnRun.ImageDisabled = Resources.Running_Disabled;
                btnPaused.Enabled = false;
                btnPaused.ImageDisabled = Resources.Paused_Disabled;
                btnStop.Enabled = false;
                btnStop.ImageDisabled = Resources.Stopped_Disabled;

                state = NLocalizer.GetString("Lead_CPrim_View_MainForm_Initing", "初始化中");
                setting.ParamEnable(false);
                return;
            }
            //初始化完成前（模式切换：允许；参数变更：权限确认）
            if (!mainForm.StationMachineIntied)
            {
                btnRun.Enabled = false;
                btnRun.ImageDisabled = Resources.Running_Disabled;
                btnPaused.Enabled = false;
                btnPaused.ImageDisabled = Resources.Paused_Disabled;
                btnStop.Enabled = false;
                btnStop.ImageDisabled = Resources.Stopped_Disabled;

                state = NLocalizer.GetString("Lead_CPrim_View_MainForm_StationMachineIntied", "等待初始化");
                setting.ParamEnable(show);
                return;
            }

            if (TaskSmManger.Instance.TaskSMs == null || !TaskSmManger.Instance.TaskSMs.ContainsKey(StationManager.Instance.CurrentStationName))
            {
                return;
            }

            _currentState = TaskSmManger.Instance.TaskSMs[StationManager.Instance.CurrentStationName].State;
            switch (_currentState)
            {
                //复位中、运行中（模式切换：不允许；参数变更：不允许）
                case SmStates.Resetting:
                    btnRun.Enabled = false;
                    btnRun.ImageDisabled = Resources.Running_Disabled;
                    btnPaused.Enabled = true;
                    btnStop.Enabled = true;

                    state = NLocalizer.GetString("Lead_CPrim_View_MainForm_Resetting", "复位中");
                    setting.ParamEnable(false);

                    break;
                case SmStates.Running:
                    btnRun.Enabled = false;
                    btnRun.ImageDisabled = Resources.Running_Energized;
                    btnPaused.Enabled = true;
                    btnStop.Enabled = true;

                    state = NLocalizer.GetString("Lead_CPrim_View_MainForm_Running", "运行中");
                    setting.ParamEnable(false);

                    if (_queueAlarmTime.Count > 0)
                    {
                        DateTime alarmTime = _queueAlarmTime.Dequeue();
                        double dt = Math.Round((DateTimeOffset.Now.LocalDateTime - alarmTime).TotalSeconds, 3);
                        LogAdd(string.Format("{0}, 工站发生宕机，共{1}秒", DateTime.Now.ToString("HH:mm:ss.fff"), dt), LogLevel.Info);
                    }

                    break;
                case SmStates.WaitEStopClr:
                    btnRun.Enabled = false;
                    btnRun.ImageDisabled = Resources.Running_Disabled;
                    btnPaused.Enabled = false;
                    btnPaused.ImageDisabled = Resources.Paused_Disabled;
                    btnStop.Enabled = false;
                    btnStop.ImageDisabled = Resources.Stopped_Disabled;

                    state = NLocalizer.GetString("Lead_CPrim_View_MainForm_WaitEStopClr", "急停");
                    setting.ParamEnable(false);

                    break;
                case SmStates.WaitClrPrimErr:
                    btnRun.Enabled = false;
                    btnRun.ImageDisabled = Resources.Running_Disabled;
                    btnPaused.Enabled = false;
                    btnPaused.ImageDisabled = Resources.Paused_Disabled;
                    btnStop.Enabled = false;
                    btnStop.ImageDisabled = Resources.Stopped_Disabled;

                    state = NLocalizer.GetString("Lead_CPrim_View_MainForm_WaitClrPrimErr", "硬件报错");
                    setting.ParamEnable(false);

                    break;

                //等待允许、暂停（模式切换：不允许；参数变更：权限确认）
                case SmStates.WaitRun:
                    btnRun.Enabled = true;
                    btnPaused.Enabled = false;
                    btnPaused.ImageDisabled = Resources.Paused_Energized;
                    btnStop.Enabled = true;

                    state = NLocalizer.GetString("Lead_CPrim_View_MainForm_WaitRun", "等待运行");
                    setting.ParamEnable(show);

                    break;
                case SmStates.Pause:
                    btnRun.Enabled = true;
                    btnPaused.Enabled = false;
                    btnPaused.ImageDisabled = Resources.Paused_Energized;
                    btnStop.Enabled = true;

                    state = NLocalizer.GetString("Lead_CPrim_View_MainForm_Pause", "暂停中");
                    setting.ParamEnable(show);

                    break;
                case SmStates.WaitClrErr:
                    btnRun.Enabled = false;
                    btnRun.ImageDisabled = Resources.Running_Disabled;
                    btnPaused.Enabled = false;
                    btnPaused.ImageDisabled = Resources.Paused_Disabled;
                    btnStop.Enabled = true;

                    state = NLocalizer.GetString("Lead_CPrim_View_MainForm_WaitClrErr", "报警中");
                    setting.ParamEnable(show);

                    break;

                //（模式切换：允许；参数变更：权限确认）
                case SmStates.WaitReset:
                    btnRun.Enabled = true;
                    btnPaused.Enabled = false;
                    btnPaused.ImageDisabled = Resources.Paused_Disabled;
                    btnStop.Enabled = false;
                    btnStop.ImageDisabled = Resources.Stopped_Energized;

                    _changeModeEnable = true;
                    enable = true;
                    state = NLocalizer.GetString("Lead_CPrim_View_MainForm_WaitReset", "等待复位");
                    setting.ParamEnable(show);

                    break;
                case SmStates.Auto:
                case SmStates.Manual:
                case SmStates.Local:
                case SmStates.Remote:
                case SmStates.RecipeApply:
                default:
                    setting.ParamEnable(show);
                    break;
            }

            mainForm.SetState(state);
            mainForm.SetProductsEnable(enable);

            if (AlarmManager.Instance.WarnInfoUI.HasWarning())
            {
                tssl_Warning.BackColor = Color.Yellow;
            }
            else
            {
                tssl_Warning.BackColor = SystemColors.Control;
            }

            tslblAutoManual.Visible =
                        (AuthorityManager.Instance.Level <= OpLevel.Level1 ||
                        _currentState == SmStates.Resetting ||
                        _currentState == SmStates.Running ||
                        _currentState == SmStates.Auto ||
                        !EventManager.AutoManualCheck()) ? false : true;
        }

        /// <summary>设备参数复制</summary>
        private void CopyMachineConfig()
        {
            string sourcePathConfig = @"D:\Config";
            string sourcePathTask = @"D:\Task";
            string path = @"D:\CPrim定期备份";
            string destinationPath = Path.Combine(path, $"{DateTime.Now.ToString("yyyyMMdd")}");
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            else
            {
                return;
            }

            FileHelper.CopyDirectory(sourcePathConfig, destinationPath, true);
            FileHelper.CopyDirectory(sourcePathTask, destinationPath, true);
        }

        /// <summary>按钮样式变更</summary>
        /// <param name="name"></param>
        private void ButtonStyleChange(string name)
        {
            foreach (var btn in _mainFormButton)
            {
                if (btn.Key == name)
                {
                    btn.Value.Selected = true;
                }
                else
                {
                    btn.Value.Selected = false;
                }
            }
        }

        /// <summary>加载[程序使用基元集合]</summary>
        private int SystemCreatePrims(string configPath)
        {
            int result = 0;
            if (_primConfigs == null) return -5;

            foreach (SinglePrimConfig primConfig in _primConfigs.PrimConfigList)
            {
                IPrim prim = PrimsManagerTransfer.GetPrim(primConfig.VisioPrimType, primConfig.PrimXmlNode, configPath);
                if (prim == null)
                {
                    MessageBox.Show(primConfig.VisioPrimType + NLocalizer.GetString("View_WelcomeForm_CannotBeLoaded", " couldn't be loaded!"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    PrimsManagerTransfer.AddPrim(prim);
                }
            }
            return result;
        }

        /// <summary>加载程序使用显示集合</summary>
        private int SystemCreateShow(string configPath)
        {
            int result = 0;
            if (_showConfigs == null) return -5;

            foreach (SingleShowConfig listShowConfig in _showConfigs.ListShowConfigs)
            {
                IShow show = ShowManagerTransfer.GetShow(listShowConfig.ShowType, listShowConfig.ShowXmlNode, configPath);
                if (show == null)
                    MessageBox.Show(listShowConfig.ShowType + " 不能加载", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                else
                    ShowManagerTransfer.AddShow(show);
            }
            return result;
        }

        /// <summary>
        /// 关闭脚本编译器
        /// </summary>
        private void CloseTask()
        {
            string processName = "LeadDevelop";
            if (ProcessHelper.SearchProc(processName))
            {
                ProcessHelper.KillProc(processName);
            }
        }
        #endregion

        private void tslbl_Light_Click(object sender, EventArgs e)
        {
            try
            {
                var eles = ElesManagerTransfer.GetAllIEle();
                foreach (var _elet in eles)
                {
                    if (_elet.Enable && _elet.Name.Contains("照明灯") && _elet.EleTypeName == "DO")
                    {
                        _elet.IEleInit();
                        IEleDO _do_1 = (IEleDO)_elet;
                        _do_1.Write(flag_Light);
                    }
                }
                flag_Light = !flag_Light;
            }
            catch (Exception)
            {
            }
        }

        public void OnLanguageChanged()
        {
            tslbl_Light.Text = NLocalizer.GetString("Lead_CPrim_View_MainForm_Light", "照明");
            tsmiViewVersionExplanation.Text = NLocalizer.ViewVersionExplanation;
            ttConfig.SetToolTip(this.BtnHome, NLocalizer.GetString("Lead_CPrim_View_MainForm_BtnHome", "主页"));
            ttConfig.SetToolTip(this.BtnAlert, NLocalizer.GetString("Lead_CPrim_View_MainForm_BtnAlert", "报警页"));
            ttConfig.SetToolTip(this.BtnConfig, NLocalizer.GetString("Lead_CPrim_View_MainForm_BtnConfig", "配置页"));
            ttConfig.SetToolTip(this.BtnData, NLocalizer.GetString("Lead_CPrim_View_MainForm_BtnData", "数据页"));
            ttConfig.SetToolTip(this.BtnVision, NLocalizer.GetString("Lead_CPrim_View_MainForm_BtnVision", "视觉页"));
            ttConfig.SetToolTip(this.BtnSetting, NLocalizer.GetString("Lead_CPrim_View_MainForm_BtnSetting", "设置页"));

            if (StationManager.Instance.CurrentStation != null)
            {
                if (AutoManualStationSM.Instance.State == SmStates.Manual)
                {
                    tslblAutoManual.Text = NLocalizer.GetString("Lead_CPrim_View_MainForm_Manual", "手动");
                }
                else
                {
                    tslblAutoManual.Text = NLocalizer.GetString("Lead_CPrim_View_MainForm_Auto", "自动");
                }
                tmrUIRefresh_Tick(null, null);
            }
        }

        private void tssl_Warning_Click(object sender, EventArgs e)
        {
            BtnBar_Click(BtnHome, null);
            mainForm.ChangeToVendorPage("警告信息");
        }

        private void tssl_DisplayNGInfo_Click(object sender, EventArgs e)
        {
            BtnBar_Click(BtnHome, null);
            mainForm.ChangeToVendorPage("抛料信息");
        }

        private void tssl_LogTask_Click(object sender, EventArgs e)
        {
            BtnBar_Click(BtnHome, null);
            mainForm.ChangeToVendorPage("任务日志");
        }
    }

    /// <summary>按钮枚举</summary>
    public enum BtnEnum
    {
        BtnHome,
        BtnAlert,
        BtnConfig,
        BtnData,
        BtnVision,
        BtnSetting,
    }
}