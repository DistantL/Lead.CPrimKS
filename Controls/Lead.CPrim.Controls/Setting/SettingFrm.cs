using Lead.CPrim.CommonParam;
using Lead.CPrim.DynamicParam;
using Lead.CPrim.FaiHelper;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.Authority.Forms;
using Lead.CPrim.ProxyTools.Common;
using Lead.CPrim.ProxyTools.SunnyUI;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.ProxyTools.Win32;
using Lead.CPrim.StationCommon;
using Lead.CPrim.StationCommon.RtVars;
using Lead.CPrim.TaskHelper;
using ScriptLibrary;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lead.CPrim.Controls
{
    public partial class SettingFrm : UIPage
    {
        /// <summary>
        /// 基本信息切换时发生
        /// </summary>
        public event Action<int, string> OnInformationChange;

        // 点检界面实例
        private SpotCheckForm _spotCheckForm;

        #region Field
        private readonly HashPathSetting _hashPathSetting1;

        private readonly HashPathSetting _hashPathSetting2;

        private readonly HashKeyInfo _hashKeyInfo1;

        private readonly HashKeyInfo _hashKeyInfo2;

        /// <summary>换型参数</summary>
        private readonly DynamicParamForm _dynamicParamForm = new DynamicParamForm();

        /// <summary>应用程序起始地址</summary>
        private static readonly string _curDominStartPath = Application.StartupPath;

        /// <summary>软件Logo地址</summary>
        private readonly string _mainLogoPath = Environment.CurrentDirectory + "\\Configs\\ProjectConfigs\\MainLogo.png";

        /// <summary>基元地址</summary>
        private readonly string _primsAssemblyPath = _curDominStartPath + "\\InnerLibs\\VisioPrims";

        /// <summary>显示地址</summary>
        private readonly string _showAssemblyPath = _curDominStartPath + "\\InnerLibs\\Display";

        /// <summary>Setting配置</summary>
        public SettingUse _setting = new SettingUse();

        /// <summary>Setting路径</summary>
        private readonly string _settingPath;

        private readonly string _hashKeyPath;

        private readonly string _administrationPath;

        private int _selAdministrationIndex = -1;

        private int _selMaintenceIndex = -1;

        private BindingList<UserAccessInfo> _administrationList = new BindingList<UserAccessInfo>();

        private BindingList<Maintenance> _maintenanceList = new BindingList<Maintenance>();

        private List<HashKeyInfos> _hashKeyInfos = new List<HashKeyInfos>();

        private Stopwatch _stopWatch = new Stopwatch();

        TreeNode treeNodeConfig;
        TreeNode treeNodeConfigSystem;
        TreeNode treeNodeConfigStation;
        TreeNode treeNodeConfigFai;
        TreeNode treeNodeConfigAuthority;
        TreeNode treeNodeConfigAlarmInfo;
        TreeNode treeNodeLanguage;
        TreeNode treeNodeTrigger;
        TreeNode treeNodePrim;
        TreeNode treeNodeShow;
        TreeNode treeNodeTask;
        TreeNode treeNodeEle;
        TreeNode treeNodeEleConfig;
        TreeNode treeNodeEleDebug;
        TreeNode treeNodeParam;
        TreeNode treeNodeCommonParam;
        TreeNode treeNodeDynamicParam;
        #endregion


        #region
        private TabPage _spotTab;
        /// <summary>
        /// 加载 Spot Check 点检界面
        /// </summary>
        private void LoadSpotCheckUI()
        {
            try
            {
                // 找到你真实的 Spot Check 标签页 ✅ 已修正为 tb_SpotCheck
                //TabPage spotTab = tabControl.TabPages["tb_SpotCheck"];
                if (_spotTab == null) return;

                // 清空页面防止重复添加
                _spotTab.Controls.Clear();

                // 初始化点检窗体
                if (_spotCheckForm == null || _spotCheckForm.IsDisposed)
                {
                    _spotCheckForm = new SpotCheckForm();
                    //_spotCheckForm.TopLevel = false;         // 允许嵌入
                    //_spotCheckForm.FormBorderStyle = FormBorderStyle.None; // 无边框
                    _spotCheckForm.Dock = DockStyle.Fill;    // 充满整个标签页
                }

                // 直接加入标签页
                _spotTab.Controls.Add(_spotCheckForm);
                _spotCheckForm.Show();
                _spotCheckForm.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载点检界面失败：" + ex.Message);
            }
        }
        #endregion

        #region Ctor
        public SettingFrm()
        {
            InitializeComponent();
            _settingPath = SwManager.Instance.GlobalSettingConfigPath;
            _hashKeyPath = SwManager.Instance.HashKeyConfigPath;
            _administrationPath = SwManager.Instance.AdministrationConfigPath;
            _globalParameterDir = SwManager.Instance.GlobalParamDirPath;
            _productParameterDir = SwManager.Instance.ProductParamDirPath;
            _dynamicParamForm.OnDynamicParamChangeCurrentProduct += (product, products) =>
                OnParameterProductChanged?.Invoke(product);

            pnlGeneral.SetStyle(Color.FromArgb(229, 229, 229), default(Color));
            tlpGeneral.BackColor = Color.FromArgb(229, 229, 229);
            pnlHardWare.SetStyle(Color.FromArgb(229, 229, 229), default(Color));
            tvHardwareSetting.SetStyle(Color.FromArgb(255, 255, 255), default(Color));
            pnlMain.SetStyle(default(Color), Color.Silver);

            lblGeneral.SetStyle(10.5f, FontStyle.Bold);
            lblHardware.SetStyle(10.5f, FontStyle.Bold);
            lblSite.SetStyle(9.0f, FontStyle.Bold);
            lblLine.SetStyle(9.0f, FontStyle.Bold);
            lblStation.SetStyle(9.0f, FontStyle.Bold);
            lblMachine.SetStyle(9.0f, FontStyle.Bold);
            lblLanguage.SetStyle(9.0f, FontStyle.Bold);
            //lblSite.SetStyle(9.0f, FontStyle.Bold, Color.FromArgb(64, 64, 64));
            //lblLine.SetStyle(9.0f, FontStyle.Bold, Color.FromArgb(64, 64, 64));
            //lblStation.SetStyle(9.0f, FontStyle.Bold, Color.FromArgb(64, 64, 64));
            //lblMachine.SetStyle(9.0f, FontStyle.Bold, Color.FromArgb(64, 64, 64));
            //lblLanguage.SetStyle(9.0f, FontStyle.Bold, Color.FromArgb(64, 64, 64));
            cbSite.SetStyle(9.0f, FontStyle.Regular);
            cbproductionType.SetStyle(9.0f, FontStyle.Regular);
            cbLine.SetStyle(9.0f, FontStyle.Regular);
            cbStation.SetStyle(9.0f, FontStyle.Regular);
            cbMachine.SetStyle(9.0f, FontStyle.Regular);
            cbLanguage.SetStyle(9.0f, FontStyle.Regular);

            line.LineColor = Color.DarkGray;
            line.LineSize = 1;

            dgvNames.SetDoubleBuffered();

            if (!File.Exists(_settingPath))
            {
                return;
            }

            _setting.SiteSelects = new List<string>();
            _setting.StationSelects = new List<string>();
            _setting.LanguageSelects = new List<string>();
            _setting = JsonHelper.DeserializeJsonFileToObject<SettingUse>(_settingPath);
            if (_setting == null)
            {
                return;
            }

            cbSite.Items.Clear();
            cbLine.Items.Clear();
            cbStation.Items.Clear();
            cbMachine.Items.Clear();
            cbLanguage.Items.Clear();

            _setting.SiteSelects?.ForEach(p => cbSite.Items.Add(p));
            for (int i = 1; i < 10; i++)
            {
                cbLine.Items.Add("Line #" + i);
            }
            _setting.StationSelects?.ForEach(p => cbStation.Items.Add(p));
            for (int i = 1; i < 20; i++)
            {
                cbMachine.Items.Add("#" + i);
            }
            _setting.LanguageSelects?.ForEach(p => cbLanguage.Items.Add(p));

            if (!_setting.CurrentSite.IsNullOrEmpty())
            {
                cbSite.SelectedItem = _setting.CurrentSite;
            }
            if (!_setting.CurrentLine.IsNullOrEmpty() && cbLine.Items.Contains(_setting.CurrentLine))
            {
                cbLine.SelectedItem = _setting.CurrentLine;
            }
            if (!_setting.CurrentStation.IsNullOrEmpty())
            {
                cbStation.SelectedItem = _setting.CurrentStation;
            }
            if (!_setting.CurrentQPL.IsNullOrEmpty() && cbMachine.Items.Contains(_setting.CurrentQPL))
            {
                cbMachine.SelectedItem = _setting.CurrentQPL;
            }
            if (!_setting.CurrentLanguage.IsNullOrEmpty() && cbLanguage.Items.Contains(_setting.CurrentLanguage))
            {
                cbLanguage.SelectedItem = _setting.CurrentLanguage;
            }

            SwManager.Instance.Site = _setting.CurrentSite;
            SoftWareInfo.Instance.SetSite(_setting.CurrentSite);
            SoftWareInfo.Instance.SetStation(_setting.CurrentStation + " " + _setting.CurrentQPL);

            cbproductionType.Items.Clear();
            if (_setting.ListProductionType != null)
            {
                foreach (var item in _setting.ListProductionType)
                {
                    cbproductionType.Items.Add(item);
                }
                cbproductionType.Items.Add("Common");
            }

            if (_setting.CurrentProductionType != null && _setting.ListProductionType.Contains(_setting.CurrentProductionType))
            {
                cbproductionType.Text = _setting.CurrentProductionType;
            }
            else
            {
                cbproductionType.Text = "Common";
            }
            SwManager.Instance.CurrentProductionType = _setting.CurrentProductionType;


            TreeViewShow();


            SetSoftWareHashKeyStyle();
            {
                _hashPathSetting1 = HashPathSetting.GetInstance(0);
                _hashPathSetting1.SetStyle(false);
                _hashPathSetting1.TopMost = false;
                _hashPathSetting1.TopLevel = false;
                _hashPathSetting1.Dock = DockStyle.Fill;
                _hashPathSetting1.Show();
                uiPanel1.Controls.Add(_hashPathSetting1);
            }

            {
                _hashPathSetting2 = HashPathSetting.GetInstance(1);
                _hashPathSetting2.SetStyle(true);
                _hashPathSetting2.TopMost = false;
                _hashPathSetting2.TopLevel = false;
                _hashPathSetting2.Dock = DockStyle.Fill;
                _hashPathSetting2.Show();
                uiPanel3.Controls.Add(_hashPathSetting2);
            }

            {
                _hashKeyInfo1 = HashKeyInfo.GetInstance(0);
                _hashKeyInfo1.SetStyle(false, 20);
                _hashKeyInfo1.TopMost = false;
                _hashKeyInfo1.TopLevel = false;
                _hashKeyInfo1.Dock = DockStyle.Fill;
                _hashKeyInfo1.Show();
                uiPanel2.Controls.Add(_hashKeyInfo1);
            }

            {
                _hashKeyInfo2 = HashKeyInfo.GetInstance(1);
                _hashKeyInfo2.SetStyle(true, 20);
                _hashKeyInfo2.TopMost = false;
                _hashKeyInfo2.TopLevel = false;
                _hashKeyInfo2.Dock = DockStyle.Fill;
                _hashKeyInfo2.Show();
                uiPanel4.Controls.Add(_hashKeyInfo2);
            }

            //{
            //    AlarmTest alarmTest = new AlarmTest()
            //    {
            //        TopLevel = false,
            //        TopMost = false,
            //        Dock = DockStyle.Fill,
            //    };
            //    alarmTest.Show();
            //    uiPanel5.Controls.Add(alarmTest);
            //}

            GetHashKeyData();
            SetSoftWareHashKey();
            GetMaintanceData();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns[countdown.Name].HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 255);
            dataGridView1.Columns[record.Name].HeaderCell.Style.BackColor = Color.FromArgb(255, 128, 255);
            dataGridView1.Columns[time.Name].HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 255);
            dataGridView1.Columns[status.Name].HeaderCell.Style.BackColor = Color.FromArgb(128, 255, 255);
            GetAdministrationData();

            LanguageChange(_setting.CurrentLanguage);
            OnLanguageChange();
            HiveManagerV3.Instance.HiveStateChanged += (info, trigger) => HiveChange(info.ChangeToStatus, HiveManagerV3.Instance.PlanedDowntimeSelect);
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
            NLocalizer.LanguageChanged += OnLanguageChange;
        }
        #endregion



        #region System_Event
        #region AdministrationTab
        private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_selAdministrationIndex == -1)
            {
                dgvNames.ClearSelection();
            }
            SelectionAdministrationChanged(_selAdministrationIndex);
        }
        #endregion

        #region MaintenanceTab
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_selMaintenceIndex == -1)
            {
                dataGridView1.ClearSelection();
            }
            SelectionMaintenceChanged(_selMaintenceIndex);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _maintenanceList.AsParallel().ForEach(p =>
            {
                int index = _maintenanceList.IndexOf(p);
                if (_stopWatch.ElapsedMilliseconds >= 3600 * 1000)
                {
                    _ = p.Status;
                    _stopWatch.Restart();
                }

                if (dataGridView1.Rows[index].DefaultCellStyle.BackColor == Color.FromArgb(213, 213, 213))
                {
                    dataGridView1.Rows[index].Cells[1].ReadOnly = true;
                    dataGridView1.Rows[index].Cells[2].ReadOnly = true;
                    dataGridView1.Rows[index].Cells[3].ReadOnly = true;
                    dataGridView1.Rows[index].Cells[4].ReadOnly = true;
                    dataGridView1.Rows[index].Cells[5].ReadOnly = true;
                    dataGridView1.Rows[index].Cells[7].ReadOnly = true;
                    return;
                }

                bool isRepeat = false;
                bool isOk = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == index && dataGridView1.Rows.Count != 1)
                    {
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(p.Project) &&
                        !string.IsNullOrWhiteSpace(p.LineType) &&
                        !string.IsNullOrWhiteSpace(p.HeadID) &&
                        !string.IsNullOrWhiteSpace(p.Item) &&
                        !string.IsNullOrWhiteSpace(p.Period) &&
                        !string.IsNullOrWhiteSpace(p.Threshold))
                    {
                        if (row.Index == index ||
                        row.Cells[3].Value.ToString().Trim() + row.Cells[4].Value.ToString().Trim() != p.HeadID.Trim() + p.Item.Trim())
                        {
                            isOk = true;
                        }
                        else
                        {
                            isRepeat = true;
                        }
                    }
                    else
                    {
                        if (row.Index != index &&
                        !string.IsNullOrWhiteSpace(p.HeadID) &&
                        !string.IsNullOrWhiteSpace(p.Item) &&
                        (row.Cells[3].Value.ToString().Trim() + row.Cells[4].Value.ToString().Trim()) == p.HeadID.Trim() + p.Item.Trim())
                        {
                            isRepeat = true;
                        }
                    }
                }

                dataGridView1.Rows[index].Cells[3].Style.ForeColor = !isOk && isRepeat ? Color.Red : Color.Black;
                dataGridView1.Rows[index].Cells[4].Style.ForeColor = !isOk && isRepeat ? Color.Red : Color.Black;
                dataGridView1.Rows[index].Cells[3].Style.SelectionForeColor = index == _selMaintenceIndex && !isOk && isRepeat ? Color.Red : Color.Black;
                dataGridView1.Rows[index].Cells[4].Style.SelectionForeColor = index == _selMaintenceIndex && !isOk && isRepeat ? Color.Red : Color.Black;
                SetButtonEnable(index, 11, isOk && index == _selMaintenceIndex);
                SetButtonEnable(index, 12, isOk && index == _selMaintenceIndex);
            });
        }
        #endregion

        /// <summary>TreeView点击按钮</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvHardwareSetting_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnlMain.Controls.Clear();
            switch (tvHardwareSetting.SelectedNode.Name)
            {
                case "系统设置":
                    {
                        SwManager.Instance.SoftwareConfigUi.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(SwManager.Instance.SoftwareConfigUi);
                    }
                    break;
                case "工站设置":
                    {
                        StationManager.Instance.StationsConfigUi.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(StationManager.Instance.StationsConfigUi);
                    }
                    break;
                case "Fai设置":
                    {
                        if (SwManager.Instance.FaiConfigEnable && FaiManager.Instance.FaiConfigUi != null)
                        {
                            FaiManager.Instance.FaiConfigUi.Dock = DockStyle.Fill;
                            pnlMain.Controls.Add(FaiManager.Instance.FaiConfigUi);
                        }
                    }
                    break;
                case "权限管理":
                    if (AuthorityManager.Instance.VerifyLevel3Permission(false))
                    {
                        AuthorityManagerUI frm = new AuthorityManagerUI();
                        frm.TopLevel = false;
                        frm.TopMost = false;
                        frm.Dock = DockStyle.Fill;
                        frm.Show();
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "报警信息管理":
                    if (AuthorityManager.Instance.VerifyLevel3Permission(false))
                    {
                        AlarmInfoEx control = AlarmManager.Instance.ConfigUI;
                        control.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(control);
                    }
                    break;
                case "语言配置":
                    {
                        var frm = LanguageManager.Instance.LanguageCfgUi;
                        frm.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "比较触发":
                    {
                        var frm = TriggerManager.Instance.CmpTrigConfigUi;
                        frm.Dock = DockStyle.Fill;
                        frm.Show();
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "基元":
                    {
                        var frm = PrimsManagerTransfer.PrimsConfigForm;
                        if (frm == null || frm.IsDisposed)
                        {
                            var iRet = PrimsManagerTransfer.PrimsConfigFormInit(_primsAssemblyPath);
                            if (iRet < 0) return;
                        }
                        frm.TopMost = false;
                        frm.TopLevel = false;
                        frm.Padding = new Padding(0);
                        frm.Dock = DockStyle.Fill;
                        frm?.Show();
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "显示":
                    {
                        var frm = ShowManagerTransfer.ShowConfigForm;
                        if (frm == null || frm.IsDisposed)
                        {
                            var iRet = ShowManagerTransfer.ShowConfigFormInit(_showAssemblyPath);
                            if (iRet < 0) return;
                        }
                        frm.TopMost = false;
                        frm.TopLevel = false;
                        frm.Padding = new Padding(0);
                        frm.Dock = DockStyle.Fill;
                        frm?.Show();
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "任务":
                    {
                        var frm = TasksManagerTransfer.TasksConfigForm;
                        if (frm == null || frm.IsDisposed)
                        {
                            return;
                        }
                        frm.TopMost = false;
                        frm.TopLevel = false;
                        frm.Padding = new Padding(0);
                        frm.Dock = DockStyle.Fill;
                        frm?.Show();
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "元件配置":
                    {
                        var frm = ElesManagerTransfer.ElesConfigForm;
                        if (frm == null || frm.IsDisposed)
                        {
                            return;
                        }
                        frm.Padding = new Padding(0);
                        frm.Dock = DockStyle.Fill;
                        frm?.Show();
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "元件调试":
                    {
                        var frm = ElesManagerTransfer.EleUserViewForm;
                        if (frm == null || frm.IsDisposed)
                        {
                            return;
                        }
                        ElesManagerTransfer.RefreshDgv();
                        frm.Padding = new Padding(0);
                        frm.Dock = DockStyle.Fill;
                        frm?.Show();
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "全局参数":
                    {
                        var frm = CommonParamForm.Instance;
                        frm.TopLevel = false;
                        frm.TopMost = false;
                        frm.Padding = new Padding(0);
                        frm.Dock = DockStyle.Fill;
                        frm.Show();
                        pnlMain.Controls.Add(frm);
                    }
                    break;
                case "换型参数":
                    {
                        _dynamicParamForm.TopLevel = false;
                        _dynamicParamForm.TopMost = false;
                        _dynamicParamForm.Padding = new Padding(0);
                        _dynamicParamForm.Dock = DockStyle.Fill;
                        _dynamicParamForm.Show();
                        pnlMain.Controls.Add(_dynamicParamForm);
                    }
                    break;
                default:
                    break;
            }
            //splMain.SplitPanelState = UISplitContainer.UISplitPanelState.Collapsed;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            splMain.SplitterDistance = splMain.Width / 4;

            //选择第一个节点
            if (tvHardwareSetting.Nodes.IsValid())
            {
                tvHardwareSetting.SelectedNode = tvHardwareSetting.Nodes[0];
            }
            tabControl.SelectedIndex = 0;
            _spotTab = tabControl.TabPages["tb_SpotCheck"];
            tabControl.TabPages.RemoveByKey("tb_SpotCheck");
            dgvNames.DataSource = _administrationList;
            dataGridView1.DataSource = _maintenanceList;
            var stateTemp = HiveManagerV3.Instance.GetLastHiveStatusInfo();
            if (stateTemp != null)
            {
                HiveChange(stateTemp.ChangeToStatus, HiveManagerV3.Instance.PlanedDowntimeSelect);
            }
        }
        #endregion



        #region Button_Event
        private void tabControl_Select(object sender, TabControlEventArgs e)
        {
            if (tabControl.Controls.Contains(tp_HashKey) && e.TabPage.Name != tp_HashKey.Name)
            {
                SetHashKeyEnable(false);
            }

            if (tabControl.Controls.Contains(tp_Maintenance))
            {
                if (e.TabPage.Name == tp_Maintenance.Name)
                {
                    _stopWatch.Start();
                    timer1.Enabled = true;
                }
                else
                {
                    ClearMaintenceSelection(ref _selMaintenceIndex);
                    dataGridView1.Enabled = false;
                    btnAddItem.Visible = false;
                    timer1.Enabled = false;
                    _stopWatch.Stop();
                }
            }
            else
            {
                timer1.Enabled = false;
                _stopWatch.Stop();
            }

            if (e.TabPage.Name != tp_Administration.Name)
            {
                ClearAdministrationSelection(ref _selAdministrationIndex);
            }

            // ===================== SPOT CHECK =====================
            if (e.TabPage.Name == "tb_SpotCheck")
            {
                LoadSpotCheckUI();  // 点击标签自动加载点检界面
            }
        }

        #region AdministrationTab
        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string path = string.Empty;
                if (!FileHelper.OpenFileDialogMethod("", FilterType.CSV, false, ref path))
                {
                    return;
                }
                List<string> ls = new List<string>();
                if (CsvHelper.ReadCsvToListString(path, Encoding.Default, true, out ls))
                {
                    Dictionary<string, UserAccessInfo> dic = new Dictionary<string, UserAccessInfo>();
                    bool flag_empty_Card_UID = false;
                    bool flag_SameID_Card_UID = false;
                    bool flag_empty_Station_ID = false;
                    _administrationList.Clear();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        string[] re = ls[i].Split(',');
                        if (re.Length < 8)
                        {
                            continue;
                        }
                        if (string.IsNullOrWhiteSpace(re[5]))
                        {
                            flag_empty_Card_UID = true;
                            continue;
                        }
                        if (string.IsNullOrWhiteSpace(re[7]))
                        {
                            flag_empty_Station_ID = true;
                            continue;
                        }
                        if (dic.ContainsKey(re[5].PadLeft(10, '0') + re[7]))
                        {
                            flag_SameID_Card_UID = true;
                            continue;
                        }

                        UserAccessInfo userAccessInfo = new UserAccessInfo
                        {
                            Site = re[0],
                            Project = re[1],
                            Vendor_Name = re[2],
                            Name = re[3],
                            Access_Level = re[4],
                            Card_UID = re[5].PadLeft(10, '0'),
                            Function = re[6],
                            Station_ID = re[7]
                        };

                        dic.Add(userAccessInfo.Card_UID + userAccessInfo.Station_ID, userAccessInfo);
                    }

                    foreach (var item in dic)
                    {
                        _administrationList.Add(item.Value);
                    }

                    btnAdminSave_Click(null, null);

                    string msg = "请检查输入的信息:";
                    if (flag_empty_Card_UID)
                    {
                        msg += "包含空的卡号;";
                    }
                    if (flag_empty_Station_ID)
                    {
                        msg += "包含空的站号;";
                    }
                    if (flag_SameID_Card_UID)
                    {
                        msg += "同一工站同一卡号多次输入;";
                    }

                    if (msg != "请检查输入的信息:")
                    {
                        ShowWarningDialog("导入表格", "导入表格完成：" + msg);
                    }
                }
                else
                {
                    throw new Exception("Data Is Null");
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog("Import", ex.Message);
            }
        }

        private void btnAdminEdit_Click(object sender, EventArgs e)
        {
            dgvNames.Rows[_selAdministrationIndex].ReadOnly = false;
        }

        private void btnAdminSave_Click(object sender, EventArgs e)
        {
            if (_administrationList.Where(p => string.IsNullOrWhiteSpace(p.Card_UID)).ToList().Count > 0)
            {
                ShowErrorDialog("Save", "含有空值的卡号");
                return;
            }
            if (_administrationList.Where(p => string.IsNullOrWhiteSpace(p.Station_ID)).ToList().Count > 0)
            {
                ShowErrorDialog("Save", "含有空值的站号");
                return;
            }
            if (_administrationList.GroupBy(p => (p.Card_UID + p.Station_ID)).Where(g => g.Count() > 1).ToList().Count > 0)
            {
                ShowErrorDialog("Save", "含有重复的[卡号+站号]");
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Site,Project,Vendor_Name,Name,Access_Level,Card_UID,Function,Station_ID\r\n");
            _administrationList.ForEach(p => stringBuilder.Append($"{p.Site},{p.Project},{p.Vendor_Name},{p.Name},{p.Access_Level},{p.Card_UID},{p.Function},{p.Station_ID}\r\n"));
            if (CsvHelper.WriteStringToCsv(_administrationPath, stringBuilder.ToString(), false, true))
            {
                ShowSuccessDialog("Save", "Save Success");
            }
            else
            {
                ShowErrorDialog("Save", "Save Error");
            }
            ClearAdministrationSelection(ref _selAdministrationIndex);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (_selAdministrationIndex != e.RowIndex)
            {
                SelectionAdministrationChanged(e.RowIndex);
            }
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccessInfo userAccessInfo = new UserAccessInfo();
            _administrationList.Add(userAccessInfo);
            dgvNames.Rows[_administrationList.Count - 1].ReadOnly = true;
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvNames.ClearSelection();
            _administrationList.RemoveAt(_selAdministrationIndex);
            _selAdministrationIndex = -1;
            SelectionAdministrationChanged(_selAdministrationIndex);
        }
        #endregion

        #region HashKeyTab
        private void btnHashPath_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (!FileHelper.OpenFileDialogMethod(ref path))
            {
                return;
            }
            foreach (Control control in uiTableLayoutPanel2.Controls)
            {
                if (control is UITextBox && control.Name.Substring(2) == ((UIButton)sender).Name.Substring(3))
                {
                    control.Text = path;
                    break;
                }
            }
        }

        private void tbHashPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            UITextBox uITextBox = sender as UITextBox;
            if (e.KeyChar == '\b' && uITextBox.SelectionLength == uITextBox.TextLength && !string.IsNullOrWhiteSpace(uITextBox.Text))
            {
                uITextBox.Text = string.Empty;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!cbSite.SelectedItem.ToString().Contains("GTK"))
            {
                var form = new AudioPassWord2StepForm(Color.WhiteSmoke);
                AuthorityManager.Instance.ShowLevelLoginUI = true;
                DialogResult dialogResult = form.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                AuthorityManager.Instance.CurrentAuthorizeName = "Super Admin";
                AuthorityManager.Instance.CurrentAuthorizeID = "88888888";
                AuthorityManager.Instance.CurrentAuthorizeVendor = "LEAD";
            }
            SetHashKeyEnable(true);
        }

        private void btnLogOut_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (UIMessageDialog.ShowMessageDialog("Confirm to log out?", "Dialog", true, UIStyle.Gray))
                {
                    SetHashKeyEnable(false);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _hashKeyInfos = GetAllHashKeyPath();
            SetAllHashKeyInfos(true, ref _hashKeyInfos);
            SetSoftWareHashKey();
            HashKeySave(_hashKeyInfos);
        }

        private void btnRefeshHash_Click(object sender, EventArgs e)
        {
            List<HashKeyInfos> hashKeyInfos = GetAllHashKeyPath();
            SetAllHashKeyInfos(true, ref hashKeyInfos);

            hashKeyInfos = hashKeyInfos.FindAll(p => !string.IsNullOrWhiteSpace(p.ItemPath) && string.IsNullOrWhiteSpace(p.ItemValue));
            if (hashKeyInfos.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                hashKeyInfos.ForEach(p => stringBuilder.Append($"{p.ItemName}_Path:{p.ItemPath}\r\n"));
                ShowWarningDialog("以下配置路径文件不存在，请检查", stringBuilder.ToString());
            }
        }

        private void btnExportHash_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (!FileHelper.SaveFileDialogMethod("", FilterType.CSV, DefaultExt.CSV, false, false, true, ref path))
            {
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();
            List<HashKeyInfos> hashKeyInfos = GetAllHashKeyPath();
            GetAllHashKeyInfos(ref hashKeyInfos);

            stringBuilder.Append("HashKeyItem,HashKeyPath,HashKeyValue\r\n");
            hashKeyInfos.ForEach(p => stringBuilder.Append($"{p.ItemName}_SHA1,{p.ItemPath},{p.ItemValue}\r\n"));
            if (CsvHelper.WriteStringToCsv(path, stringBuilder.ToString(), false, true))
            {
                ShowSuccessDialog("Export", "Export Success");
            }
            else
            {
                ShowErrorDialog("Export", "Export Error");
            }
        }

        private void btnCancelHash_Click(object sender, EventArgs e)
        {
            GetHashKeyData();
            SetHashKeyEnable(false);
        }

        private void btnUploadMes_Click(object sender, EventArgs e)
        {
            SetAllHashKeyPath(_hashKeyInfos);
            SetAllHashKeyInfos(false, ref _hashKeyInfos);

            List<HashKeyInfos> hashKeyInfos = _hashKeyInfos.FindAll(p => !string.IsNullOrWhiteSpace(p.ItemPath) && string.IsNullOrWhiteSpace(p.ItemValue));
            if (hashKeyInfos.Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                hashKeyInfos.ForEach(p => stringBuilder.Append($"{p.ItemName}_Path:{p.ItemPath}\r\n"));
                ShowWarningDialog("以下配置路径文件不存在，请检查", stringBuilder.ToString());
            }
            else
            {
                string msg = MesManager.HashKeyUpload(_hashKeyInfos);
                if (msg.Contains("OK"))
                {
                    ShowSuccessDialog("MES Response", msg);
                }
                else
                {
                    ShowErrorDialog("MES Response", msg);
                }
            }
            SetHashKeyEnable(false);
        }
        #endregion

        #region MaintenanceTab
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (_selMaintenceIndex == e.RowIndex && e.ColumnIndex == 11) // 新增行
            {
                if (!((CustomButtonCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]).IsButtonEnabled)
                {
                    return;
                }

                string msg = MesManager.MesCheck(_maintenanceList[e.RowIndex].Project,
                    _maintenanceList[e.RowIndex].LineType,
                    _maintenanceList[e.RowIndex].HeadID,
                    _maintenanceList[e.RowIndex].Item,
                    _maintenanceList[e.RowIndex].Period,
                    _maintenanceList[e.RowIndex].Threshold, true);
                if (msg.Contains("OK"))
                {
                    ShowSuccessDialog("MES feedback message", msg);
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(213, 213, 213);
                    _maintenanceList[e.RowIndex].Record = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                    _ = _maintenanceList[e.RowIndex].Status;
                    MongodbHelper.ReplaceOne("GuId", _maintenanceList[e.RowIndex].GuId, _maintenanceList[e.RowIndex], "Maintance");
                    return;
                }
                else
                {
                    ShowErrorDialog("MES feedback message", msg);
                }
            }
            else if (_selMaintenceIndex == e.RowIndex && e.ColumnIndex == 12) // 删除行
            {
                if (!((CustomButtonCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]).IsButtonEnabled)
                {
                    return;
                }

                MongodbHelper.QueryOneLast("GuId", _maintenanceList[e.RowIndex].GuId, out Maintenance result, "Maintance");
                if (result == null)
                {
                    RemoveMaintenceSelection(ref _selMaintenceIndex);
                    return;
                }
                else
                {
                    string msg = MesManager.MesCheck(_maintenanceList[e.RowIndex].Project,
                    _maintenanceList[e.RowIndex].LineType,
                    _maintenanceList[e.RowIndex].HeadID,
                    _maintenanceList[e.RowIndex].Item,
                    _maintenanceList[e.RowIndex].Period,
                    _maintenanceList[e.RowIndex].Threshold, false);
                    if (msg.Contains("OK"))
                    {
                        ShowSuccessDialog("MES feedback message", msg);
                        MongodbHelper.DeleteOne<Maintenance>("GuId", _maintenanceList[e.RowIndex].GuId, "Maintance");
                        RemoveMaintenceSelection(ref _selMaintenceIndex);
                        return;
                    }
                    else
                    {
                        ShowErrorDialog("MES feedback message", msg);
                    }
                }
            }

            if (_selMaintenceIndex != e.RowIndex)
            {
                SelectionMaintenceChanged(e.RowIndex);
            }
        }

        private void btnEidt_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnAddItem.Visible = AuthorityManager.Instance.VerifyLevel3Permission();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (!FileHelper.SaveFileDialogMethod("", FilterType.CSV, DefaultExt.CSV, false, false, true, ref path))
            {
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("项目代码,线别,治具编号,保养项目,保养周期,保养倒计时,预警阀值,最近的维护记录,计划保养时间,健康状态\r\n");
            _maintenanceList.ForEach(p =>
            stringBuilder.Append($"{p.Project},{p.LineType},{p.HeadID},{p.Item},{p.Period},{p.Countdown},{p.Threshold},{p.Record},{p.Time},{p.Status}\r\n"));
            if (CsvHelper.WriteStringToCsv(path, stringBuilder.ToString(), false, true))
            {
                ShowSuccessDialog("Export", "Export Success");
            }
            else
            {
                ShowErrorDialog("Export", "Export Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearMaintenceSelection(ref _selMaintenceIndex);
            dataGridView1.Enabled = false;
            btnAddItem.Visible = false;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Maintenance maintenance = new Maintenance();
            _maintenanceList.Add(maintenance);
            dataGridView1.Rows[_maintenanceList.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(245, 242, 215);
        }
        #endregion

        /// <summary>保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (TaskSmManger.Instance.TaskSMs[StationManager.Instance.CurrentStation.Name].State == SmStates.Running)
            {
                UIMessageTip.ShowWarning("请勿在运行中保存参数");
                return;
            }
            Save();
        }

        /// <summary>
        /// 基本信息切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIComboBox cb = sender as UIComboBox;
            if (cb == null)
            {
                return;
            }

            switch (cb.Tag.ToString())
            {
                case "1":

                    break;

                case "2":

                    break;

                case "3":

                    break;

                case "4":
                    #region 工站

                    break;
                #endregion

                case "5":

                    break;

                case "6":
                    #region 语言

                    break;
                #endregion

                default:
                    break;
            }

            object select = cb.SelectedItem;
            if (select != null && !select.ToString().IsNullOrEmpty())
            {
                OnInformationChange?.Invoke(cb.Tag.ToString().ToInt(), select.ToString());
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>保存</summary>
        public void Save()
        {
            try
            {
                string msg = "";
                if (AuthorityManager.Instance.VerifyLevel3Permission())
                {
                    //站卡相关信息
                    if (!SwManager.Instance.SiteAlert(cbSite.SelectedItem?.ToString()))
                    {
                        _setting.CurrentSite = cbSite.SelectedItem?.ToString();
                    }
                    _setting.CurrentSite = cbSite.SelectedItem?.ToString();
                    _setting.CurrentLine = cbLine.SelectedItem?.ToString();
                    _setting.CurrentStation = cbStation.SelectedItem?.ToString();
                    _setting.CurrentQPL = cbMachine.SelectedItem?.ToString();
                    _setting.CurrentProductionType = cbproductionType.Text;

                    SoftWareInfo.Instance.SetSite(_setting.CurrentSite);
                    SoftWareInfo.Instance.SetStation(_setting.CurrentStation + " " + _setting.CurrentQPL);
                    msg += "站卡信息设置成功, ";
                }

                _setting.CurrentLanguage = cbLanguage.SelectedItem?.ToString();
                LanguageChange(_setting.CurrentLanguage);
                if (JsonHelper.SerializeObjectToFile(_setting, _settingPath))
                {
                    msg += "语言设置成功, ";
                }

                TreeNode node = tvHardwareSetting.SelectedNode;
                if (node != null && !string.IsNullOrWhiteSpace(node.Name))
                {
                    //显示，基元，任务需要开发者权限修改

                    //系统设置
                    if (node.Name == "系统设置" && SwManager.Instance.Save() == 0)
                    {
                        msg += "系统设置成功, ";
                    }

                    //工站设置
                    if (node.Name == "工站设置" && StationManager.Instance.Save() == 0)
                    {
                        msg += "工站设置成功, ";
                    }

                    //Fai设置
                    if (node.Name == "Fai设置" && FaiManager.Instance.Save() == 0)
                    {
                        msg += "Fai设置成功, ";
                    }

                    //报警信息管理
                    if (node.Name == "报警信息管理" && AlarmManager.Instance.Save() == 0)
                    {
                        msg += "报警信息管理设置成功, ";
                    }

                    // 语言配置
                    if (node.Name == "语言配置" && LanguageManager.Instance.Save() == 0)
                    {
                        msg += "语言配置保存成功, ";
                    }

                    //比较触发
                    if (node.Name == "比较触发" && TriggerManager.Instance.Save() == 0)
                    {
                        msg += "比较触发保存成功，";
                    }

                    //基元
                    if (node.Name == "基元" && PrimsManagerTransfer.Save() == 0)
                    {
                        msg += "基元保存成功, ";
                    }

                    //显示
                    if (node.Name == "显示" && ShowManagerTransfer.Save() == 0)
                    {
                        msg += "显示基元保存成功, ";
                    }

                    //任务
                    if (node.Name == "任务" && TasksManagerTransfer.Save() == 0)
                    {
                        msg += "任务保存成功, ";
                    }

                    //元件
                    if (node.Name == "元件配置")
                    {
                        ElesManagerTransfer.RefreshDgv();
                        if (ElesManagerTransfer.Save() == 0)
                        {
                            msg += "元件保存成功, ";
                        }
                    }

                    //全局参数
                    if (node.Name == "全局参数")
                    {
                        if (CommonParamForm.Instance.Save() == 0)
                        {
                            UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_CommonParam_CommonParamForm_CommonParamSaveSuccess", "全局参数保存成功"));
                            msg += "全局参数保存成功, ";
                        }
                    }

                    //全局参数
                    if (node.Name == "换型参数")
                    {
                        if (_dynamicParamForm.Save() == 0)
                        {
                            msg += "换型参数保存成功, ";
                        }
                    }
                }

                if (!msg.IsNullOrWhiteSpace())
                {
                    LogAdd(msg, LogLevel.Trace);
                }
            }
            catch (Exception ex)
            {
                LogAdd($"保存失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }

        /// <summary>显示</summary>
        public void TreeViewShow()
        {
            int imageIndex = 0;
            int selectedImageIndex = 0;

            treeNodeConfig = new TreeNode("软件配置", imageIndex++, selectedImageIndex++);
            treeNodeConfig.Name = "软件配置";
            treeNodeConfigSystem = new TreeNode("系统设置", imageIndex++, selectedImageIndex++);
            treeNodeConfigSystem.Name = "系统设置";
            treeNodeConfigStation = new TreeNode("工站设置", imageIndex++, selectedImageIndex++);
            treeNodeConfigStation.Name = "工站设置";
            treeNodeConfigFai = new TreeNode("Fai设置", imageIndex++, selectedImageIndex++);
            treeNodeConfigFai.Name = "Fai设置";
            //treeNodeConfigAuthority = new TreeNode("权限管理", imageIndex++, selectedImageIndex++);
            //treeNodeConfigAuthority.Name = "权限管理";
            treeNodeConfigAlarmInfo = new TreeNode("报警信息管理", imageIndex++, selectedImageIndex++);
            treeNodeConfigAlarmInfo.Name = "报警信息管理";
            treeNodeLanguage = new TreeNode("语言配置", imageIndex++, selectedImageIndex++);
            treeNodeLanguage.Name = "语言配置";
            treeNodeTrigger = new TreeNode("比较触发", imageIndex++, selectedImageIndex++);
            treeNodeTrigger.Name = "比较触发";
            treeNodePrim = new TreeNode("基元", imageIndex++, selectedImageIndex++);
            treeNodePrim.Name = "基元";
            treeNodeShow = new TreeNode("显示", imageIndex++, selectedImageIndex++);
            treeNodeShow.Name = "显示";
            treeNodeTask = new TreeNode("任务", imageIndex++, selectedImageIndex++);
            treeNodeTask.Name = "任务";
            treeNodeEle = new TreeNode("元件", imageIndex++, selectedImageIndex++);
            treeNodeEle.Name = "元件";
            treeNodeEleConfig = new TreeNode("元件配置", imageIndex++, selectedImageIndex++);
            treeNodeEleConfig.Name = "元件配置";
            treeNodeEleDebug = new TreeNode("元件调试", imageIndex++, selectedImageIndex++);
            treeNodeEleDebug.Name = "元件调试";

            treeNodeParam = new TreeNode("参数", imageIndex++, selectedImageIndex++);
            treeNodeParam.Name = "参数";
            treeNodeCommonParam = new TreeNode("全局参数", imageIndex++, selectedImageIndex++);
            treeNodeCommonParam.Name = "全局参数";
            treeNodeDynamicParam = new TreeNode("换型参数", imageIndex++, selectedImageIndex++);
            treeNodeDynamicParam.Name = "换型参数";

            tvHardwareSetting.Nodes.Clear();
            tvHardwareSetting.Nodes.Add(treeNodeConfig);
            treeNodeConfig.Nodes.Add(treeNodeConfigSystem);
            treeNodeConfig.Nodes.Add(treeNodeConfigStation);
            if (SwManager.Instance.FaiConfigEnable && FaiManager.Instance.FaiConfigUi != null)
            {
                treeNodeConfig.Nodes.Add(treeNodeConfigFai);
            }
            //treeNodeConfig.Nodes.Add(treeNodeConfigAuthority);
            treeNodeConfig.Nodes.Add(treeNodeConfigAlarmInfo);

            if (LanguageManager.Instance.LanguageCfgUi != null)
            {
                tvHardwareSetting.Nodes.Add(treeNodeLanguage);
            }

            if (SwManager.Instance.CmpTrigConfigEnable && TriggerManager.Instance.CmpTrigConfigUi != null)
            {
                tvHardwareSetting.Nodes.Add(treeNodeTrigger);
            }

            if (SwManager.Instance.PrimsConfigEnable)
            {
                tvHardwareSetting.Nodes.Add(treeNodePrim);
            }

            if (SwManager.Instance.DisplayConfigEnable)
            {
                tvHardwareSetting.Nodes.Add(treeNodeShow);
            }

            if (SwManager.Instance.TasksConfigEnable)
            {
                tvHardwareSetting.Nodes.Add(treeNodeTask);
            }

            if (SwManager.Instance.ElesConfigEnable)
            {
                tvHardwareSetting.Nodes.Add(treeNodeEle);
                treeNodeEle.Nodes.Add(treeNodeEleConfig);
                treeNodeEle.Nodes.Add(treeNodeEleDebug);
            }

            //参数
            tvHardwareSetting.Nodes.Add(treeNodeParam);
            if (SwManager.Instance.CommonDynamicParamEnable)
            {
                try
                {
                    CommonParamForm.Instance.Init(_globalParameterDir);
                }
                catch (Exception ex)
                {
                    LogAdd($"{NLocalizer.CommonParamInitError}：{ex.Message}", LogLevel.Warn);
                }

                treeNodeParam.Nodes.Add(treeNodeCommonParam);
            }
            if (SwManager.Instance.DynamicParamEnable)
            {
                if (_dynamicParamForm.Init(_productParameterDir, _dynamicParamForm.GetRunMode()) != 0)
                    throw new InvalidOperationException("运行模式初始化失败：请检查当前产品及换型参数文件。");
                treeNodeParam.Nodes.Add(treeNodeDynamicParam);
            }
            else
            {
                throw new InvalidOperationException("运行模式已归属换型参数，必须启用换型参数并配置当前产品后重启。");
            }
            CommonParamForm.Instance.CreateTransferSession = SwManager.Instance.CommonDynamicParamEnable && SwManager.Instance.DynamicParamEnable
                ? (Func<string, Lead.CPrim.BaseParam.ParameterTransferSession>)CreateParameterTransferSession : null;
            _dynamicParamForm.CreateTransferSession = SwManager.Instance.CommonDynamicParamEnable && SwManager.Instance.DynamicParamEnable
                ? (Func<string, Lead.CPrim.BaseParam.ParameterTransferSession>)CreateGlobalParameterTransferSession : null;
            Func<bool> canSaveParameters = () => !TaskSmManger.Instance.TaskSMs.Any(p =>
                p.Value.State == SmStates.Running || p.Value.State == SmStates.Resetting);
            CommonParamForm.Instance.CanSaveParameters = canSaveParameters;
            _dynamicParamForm.CanSaveParameters = canSaveParameters;
            tvHardwareSetting.ExpandAll();
        }

        /// <summary>状态机及权限对参数界面控制</summary>
        /// <param name="enable"></param>
        public void ParamEnable(bool enable)
        {
            CommonParamForm.Instance.UIShow(enable);
            _dynamicParamForm.UIShow(enable);
        }

        /// <summary>重新加载换型参数</summary>
        public void ReLoadDynamicParam()
        {
            if (SwManager.Instance != null && SwManager.Instance.DynamicParamEnable)
            {
                if (_dynamicParamForm.Init(_productParameterDir, _dynamicParamForm.GetRunMode()) != 0)
                    throw new InvalidOperationException("换型参数加载失败，请检查产品及模式文件。");
            }
        }

        private readonly string _globalParameterDir;
        private readonly string _productParameterDir;
        public event Action<string> OnParameterProductChanged;

        public int ChangeParameterMode(string mode)
        {
            if (!SwManager.Instance.DynamicParamEnable)
            {
                MessageBox.Show("运行模式已归属换型参数，请启用换型参数并加载当前产品。");
                return -1;
            }
            return _dynamicParamForm.ModeChange(mode);
        }

        public Color GetColorOfCurrentProductionType()
        {
            try
            {
                if (_setting.ListProductionType != null && _setting.ListProductionTypeBackColor != null)
                {
                    var index = _setting.ListProductionType.FindIndex(x => _setting.CurrentProductionType == x);
                    if (index != -1 && _setting.ListProductionTypeBackColor.Count > index)
                    {
                        return ColorTranslator.FromHtml(_setting.ListProductionTypeBackColor[index]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Color.Transparent;
            }

            return Color.Transparent;
        }

        public string GetCurrentProductionType
        {
            get
            {
                return _setting.CurrentProductionType;
            }
        }
        #endregion



        #region Method_InternalUsing
        private void SetSoftWareHashKeyStyle()
        {
            for (int i = 0; i < 6; i++)
            {
                string itemName = string.Empty;
                switch (i)
                {
                    case 0:
                        itemName = "MS_SHA1";
                        break;
                    case 1:
                        itemName = "VS_SHA1";
                        break;
                    case 2:
                        itemName = "LS_SHA1";
                        break;
                    case 3:
                        itemName = "RS_SHA1";
                        break;
                    case 4:
                        itemName = "IS_SHA1";
                        break;
                    case 5:
                        itemName = "PLC_SHA1";
                        break;
                }

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView2);
                row.Cells[0].Value = itemName;
                row.Cells[1].Value = string.Empty;
                dataGridView2.Rows.Add(row);
            }
        }

        private void SetSoftWareHashKey()
        {
            MesManager.SetHashKeyInfos(_hashKeyInfos);
            HashKeyInfos hashKeyInfos = _hashKeyInfos.FirstOrDefault(p => p.ItemName == "MS");
            SwManager.Instance.SoftWareHashCode = hashKeyInfos == null || string.IsNullOrWhiteSpace(hashKeyInfos.ItemPath) ? AudioSwVersion.Instance.GetSHA1InFile(AudioSwVersion.Instance.Main_SW_filePath) : hashKeyInfos.ItemValue;
            hashKeyInfos = _hashKeyInfos.FirstOrDefault(p => p.ItemName == "VS");
            SwManager.Instance.VisionHashCode = hashKeyInfos == null || string.IsNullOrWhiteSpace(hashKeyInfos.ItemPath) ? AudioSwVersion.Instance.GetSHA1InFile(SwManager.Instance.VisionPath) : hashKeyInfos.ItemValue;
        }

        private void SetHashKeyInfos(bool isRefresh, ref List<HashKeyInfos> hashKeyInfos)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                int index = hashKeyInfos.FindIndex(p => row.Cells[0].Value.ToString().Replace("_SHA1", "").Trim() == p.ItemName);
                if (index > -1)
                {
                    row.Cells[1].Value = isRefresh ? hashKeyInfos[index].ItemValue = AudioSwVersion.Instance.GetSHA1InFile(hashKeyInfos[index].ItemPath) : hashKeyInfos[index].ItemValue;
                }
            }
        }

        private void GetHashKeyInfos(ref List<HashKeyInfos> hashKeyInfos)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                int index = hashKeyInfos.FindIndex(p => row.Cells[0].Value.ToString().Replace("_SHA1", "").Trim() == p.ItemName);
                if (index > -1)
                {
                    hashKeyInfos[index].ItemValue = row.Cells[1].Value.ToString();
                }
            }
        }

        private List<HashKeyInfos> GetAllHashKeyPath()
        {
            List<HashKeyInfos> hashKeyInfos = new List<HashKeyInfos>
            {
                new HashKeyInfos { ItemName = "MS", ItemPath = tbMainPath.Text.Trim() },
                new HashKeyInfos { ItemName = "VS", ItemPath = tbVisionPath.Text.Trim() },
                new HashKeyInfos { ItemName = "LS", ItemPath = tbLaserPath.Text.Trim() },
                new HashKeyInfos { ItemName = "RS", ItemPath = tbRobotPath.Text.Trim() },
                new HashKeyInfos { ItemName = "IS", ItemPath = tbIdePath.Text.Trim() },
                new HashKeyInfos { ItemName = "PLC", ItemPath = tbPlcPath.Text.Trim() }
            };
            _hashPathSetting1.GetHashKeyInfos().ForEach(p => hashKeyInfos.Add(p));
            _hashPathSetting2.GetHashKeyInfos().ForEach(p => hashKeyInfos.Add(p));
            return hashKeyInfos;
        }

        private void SetAllHashKeyPath(List<HashKeyInfos> hashKeyInfos)
        {
            tbMainPath.Text = hashKeyInfos.FirstOrDefault(p => p.ItemName == "MS") == null ? string.Empty : hashKeyInfos.FirstOrDefault(p => p.ItemName == "MS").ItemPath;
            tbVisionPath.Text = hashKeyInfos.FirstOrDefault(p => p.ItemName == "VS") == null ? string.Empty : hashKeyInfos.FirstOrDefault(p => p.ItemName == "VS").ItemPath;
            tbLaserPath.Text = hashKeyInfos.FirstOrDefault(p => p.ItemName == "LS") == null ? string.Empty : hashKeyInfos.FirstOrDefault(p => p.ItemName == "LS").ItemPath;
            tbRobotPath.Text = hashKeyInfos.FirstOrDefault(p => p.ItemName == "RS") == null ? string.Empty : hashKeyInfos.FirstOrDefault(p => p.ItemName == "RS").ItemPath;
            tbIdePath.Text = hashKeyInfos.FirstOrDefault(p => p.ItemName == "IS") == null ? string.Empty : hashKeyInfos.FirstOrDefault(p => p.ItemName == "IS").ItemPath;
            tbPlcPath.Text = hashKeyInfos.FirstOrDefault(p => p.ItemName == "PLC") == null ? string.Empty : hashKeyInfos.FirstOrDefault(p => p.ItemName == "PLC").ItemPath;
            _hashPathSetting1.SetHashKeyInfos(hashKeyInfos);
            _hashPathSetting2.SetHashKeyInfos(hashKeyInfos);
        }

        private void SetAllHashKeyInfos(bool isRefresh, ref List<HashKeyInfos> hashKeyInfos)
        {
            SetHashKeyInfos(isRefresh, ref hashKeyInfos);
            _hashKeyInfo1.SetHashKeyInfos(isRefresh, ref hashKeyInfos);
            _hashKeyInfo2.SetHashKeyInfos(isRefresh, ref hashKeyInfos);
        }

        private void GetAllHashKeyInfos(ref List<HashKeyInfos> hashKeyInfos)
        {
            GetHashKeyInfos(ref hashKeyInfos);
            _hashKeyInfo1.GetHashKeyInfos(ref hashKeyInfos);
            _hashKeyInfo2.GetHashKeyInfos(ref hashKeyInfos);
        }

        private void HashKeySave(List<HashKeyInfos> hashKeyInfos)
        {
            if (JsonHelper.SerializeObjectToFile(hashKeyInfos, _hashKeyPath))
            {
                LogAdd("HashKey配置保存成功", LogLevel.Trace);
            }
            else
            {
                LogAdd("HashKey配置保存失败", LogLevel.Trace);
            }
        }

        private void RemoveMaintenceSelection(ref int index)
        {
            dataGridView1.ClearSelection();
            _maintenanceList.RemoveAt(index);
            index = -1;
            SelectionMaintenceChanged(index);
        }

        private void ClearMaintenceSelection(ref int index)
        {
            if (index > -1)
            {
                dataGridView1.ClearSelection();
                index = -1;
                SelectionMaintenceChanged(index);
            }

            List<int> indexList = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.FromArgb(245, 242, 215))
                {
                    indexList.Insert(0, row.Index);
                }
            }
            indexList.ForEach(p => _maintenanceList.RemoveAt(p));
        }

        private void SelectionMaintenceChanged(int rowIndex)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == rowIndex)
                {
                    _selMaintenceIndex = row.Index;
                    row.Cells[0].Value = "√";
                    SetButtonEnable(row.Index, 11);
                    SetButtonEnable(row.Index, 12, AuthorityManager.Instance.VerifyLevel3Permission());
                }
                else
                {
                    row.Cells[0].Value = string.Empty;
                    SetButtonEnable(row.Index, 11, false);
                    SetButtonEnable(row.Index, 12, false);
                }
            }
        }

        private void ClearAdministrationSelection(ref int index)
        {
            index = -1;
            GetAdministrationData();
        }

        private void SelectionAdministrationChanged(int rowIndex)
        {
            foreach (DataGridViewRow row in dgvNames.Rows)
            {
                if (row.Index == rowIndex)
                {
                    _selAdministrationIndex = row.Index;
                    row.Cells[0].Value = "√";
                }
                else
                {
                    row.Cells[0].Value = string.Empty;
                }
                row.ReadOnly = true;
            }
        }

        private void SetButtonEnable(int rowIndex, int colIndex, bool enable = true)
        {
            if (dataGridView1.Rows[rowIndex].Cells[colIndex] is CustomButtonCell customButtonCell)
            {
                customButtonCell.IsButtonEnabled = enable;
            }

            dataGridView1.InvalidateCell(colIndex, rowIndex);
        }

        private void SetHashKeyEnable(bool isLogin)
        {
            tbUserName.Text = isLogin ? AuthorityManager.Instance.CurrentAuthorizeName : AuthorityManager.Instance.CurrentAuthorizeName = string.Empty;
            tbUid.Text = isLogin ? AuthorityManager.Instance.CurrentAuthorizeID : AuthorityManager.Instance.CurrentAuthorizeID = string.Empty;
            tbFunction.Text = isLogin ? AuthorityManager.Instance.CurrentAuthorizeVendor : AuthorityManager.Instance.CurrentAuthorizeVendor = string.Empty;
            btnEdit.Visible = !isLogin;
            btnSave.Visible = isLogin;
            btnLogOut.Visible = isLogin;
            btnRefeshHash.Visible = isLogin;
            btnExportHash.Visible = isLogin;
            btnCancelHash.Visible = isLogin;
            btnUploadMes.Visible = isLogin;

            foreach (Control control1 in uiTableLayoutPanel1.Controls)
            {
                if (control1.Name == "uiTableLayoutPanel3")
                {
                    foreach (Control control2 in control1.Controls)
                    {
                        if (control2.Name == "btnEdit")
                        {
                            control2.Enabled = true;
                        }
                        else
                        {
                            control2.Enabled = isLogin;
                        }
                    }
                }
                else
                {
                    control1.Enabled = isLogin;
                }
            }
        }

        private void SetMaintenanceEnable(bool isLevel2, HiveStatus hive, string mode)
        {
            if (isLevel2 && hive == HiveStatus.Plan_DT && !string.IsNullOrWhiteSpace(mode) &&
                (mode.Contains("PD-01") ||
                 mode.Contains("PD-09") ||
                 mode.Contains("Daily Maintenance") ||
                 mode.Contains("Weekly Maintenance")))
            {
                ClearMaintenceSelection(ref _selMaintenceIndex);
                dataGridView1.Enabled = false;
                btnEidt.Visible = true;
                btnAddItem.Visible = false;
            }
            else
            {
                ClearMaintenceSelection(ref _selMaintenceIndex);
                dataGridView1.Enabled = false;
                btnEidt.Visible = false;
                btnAddItem.Visible = false;
            }
        }

        private void SetHashKeyEnable(bool isLevel3, HiveStatus hiveStatus, string mode)
        {
            if (isLevel3 &&
                hiveStatus == HiveStatus.Plan_DT &&
                !string.IsNullOrWhiteSpace(mode) &&
                (mode.Contains("PD-15") || mode.Contains("Uploaded Hash Keys to MES")))
            {
                if (!tabControl.Controls.Contains(tp_HashKey))
                {
                    tabControl.Controls.Add(tp_HashKey);
                }

                SetHashKeyEnable(false);
            }
            else
            {
                if (tabControl.Controls.Contains(tp_HashKey))
                {
                    tabControl.Controls.Remove(tp_HashKey);
                }
            }
        }

        private void SetSpotCheckEnable(HiveStatus hiveStatus, string mode)
        {
            try
            {
                if (hiveStatus == HiveStatus.Plan_DT &&
                    !string.IsNullOrWhiteSpace(mode) &&
                    mode.Contains("PD-01") &&
                    _spotTab != null)
                {
                    tabControl.TabPages.Add(_spotTab);
                }
                else
                {
                    if (tabControl.TabPages.Contains(_spotTab)) tabControl.TabPages.Remove(_spotTab);
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void GetHashKeyData()
        {
            try
            {
                _hashKeyInfos = JsonHelper.DeserializeJsonFileToObject<List<HashKeyInfos>>(_hashKeyPath);
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, "获取Hashkey.json文件[" + _hashKeyPath + "]异常：" + ex.Message, "other");
            }

            _hashKeyInfos = _hashKeyInfos ?? new List<HashKeyInfos>();
            SetAllHashKeyPath(_hashKeyInfos);
            SetAllHashKeyInfos(false, ref _hashKeyInfos);
        }

        private void GetMaintanceData()
        {
            _maintenanceList.Clear();
            MongodbHelper.QueryAll(out List<Maintenance> resultlist, "Maintance");
            resultlist = resultlist ?? new List<Maintenance>();
            resultlist.ForEach(p => _maintenanceList.Add(p));
        }

        private void GetAdministrationData()
        {
            try
            {
                List<string> ls = new List<string>();
                if (CsvHelper.ReadCsvToListString(_administrationPath, Encoding.Default, true, out ls))
                {
                    _administrationList.Clear();
                    for (int i = 0; i < ls.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(ls[i]))
                        {
                            continue;
                        }

                        string[] re = ls[i].Split(',');
                        UserAccessInfo userAccessInfo = new UserAccessInfo
                        {
                            Site = re[0],
                            Project = re[1],
                            Vendor_Name = re[2],
                            Name = re[3],
                            Access_Level = re[4],
                            Card_UID = re[5],
                            Function = re[6],
                            Station_ID = re[7]
                        };
                        _administrationList.Add(userAccessInfo);
                    }
                }
                else
                {
                    throw new Exception("Administration Data Is Null");
                }
            }
            catch (Exception ex)
            {
                LogAdd(ex.Message, LogLevel.Trace);
            }
        }

        private void HiveChange(HiveStatus hive, string mode)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action<HiveStatus, string>(HiveChange), hive, mode);
                }
                else
                {
                    SetHashKeyEnable(AuthorityManager.Instance.VerifyLevel3Permission(), hive, mode);
                    SetMaintenanceEnable(AuthorityManager.Instance.VerifyLevel2Permission(), hive, mode);
                    SetSpotCheckEnable(hive, mode);

                }
            }
            catch (Exception ex)
            {
                LogHelper.Warn(ex.ToString());
            }
            
        }

        /// <summary>响应权限等级改变</summary>
        /// <param name="level"></param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<OpLevel>(InstanceUpdateLevel), level);
                return;
            }

            foreach (Control control in tlpGeneral.Controls)
            {
                if (!control.Name.Contains("Language"))
                {
                    control.Enabled = level >= OpLevel.Level3;
                }
            }

            btnImportCSV.Visible = level >= OpLevel.Level2;
            btnAdminEdit.Visible = level >= OpLevel.Level3;
            btnAdminSave.Visible = level >= OpLevel.Level3;
            ClearAdministrationSelection(ref _selAdministrationIndex);

            if (level >= OpLevel.Level2)
            {
                if (!tabControl.Controls.Contains(tp_Maintenance))
                {
                    tabControl.Controls.Add(tp_Maintenance);
                }

                SetMaintenanceEnable(true, HiveManagerV3.Instance.GetCurrentHiveStatus(), HiveManagerV3.Instance.PlanedDowntimeSelect);
            }
            else
            {
                if (tabControl.Controls.Contains(tp_Maintenance))
                {
                    tabControl.Controls.Remove(tp_Maintenance);
                }
            }

            SetHashKeyEnable(level >= OpLevel.Level3, HiveManagerV3.Instance.GetCurrentHiveStatus(), HiveManagerV3.Instance.PlanedDowntimeSelect);
        }

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

        private void LanguageChange(string language)
        {
            switch (language)
            {
                case "中文简体":
                    UILocalizeHelper.SetCH();
                    NLocalizer.SetLanguage("zh-CN");
                    break;
                case "EngLish":
                    UILocalizeHelper.SetEN();
                    NLocalizer.SetLanguage("en-US");
                    break;
                case "Tiếng Việt":
                    UILocalizeHelper.SetVI();
                    NLocalizer.SetLanguage("vi-VN");
                    break;
            }
        }
        #endregion



        #region  语言设置
        public void OnLanguageChange()
        {
            lblGeneral.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_General", "基本信息:");
            lblSite.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_Site", "工厂:");
            lblproductionType.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_ProductionType", "类型:");
            lblLine.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_Line", "线体:");
            lblStation.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_Station", "工站:");
            lblMachine.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_Machine", "设备:");
            lblLanguage.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_Language", "语言:");
            lblHardware.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_Hardware", "软件配置:");
            btnLoad.Text = NLocalizer.GetString("Lead_CPrim_Controls_SettingFrm_Load", "保存");

            treeNodeConfig.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_SWconfig", "设置");
            treeNodeConfigSystem.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Systemconfig", "系统设置");
            treeNodeConfigStation.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Statioinconfig", "工站设置");
            treeNodeConfigFai.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_FAIconfig", "Fai设置");
            //treeNodeConfigAuthority.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Authorityconfig", "权限管理");
            treeNodeConfigAlarmInfo.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_ConfigAlarmInfo", "报警信息管理");
            treeNodeLanguage.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Languageconfig", "语言配置");
            treeNodeTrigger.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Triggerconfig", "比较触发");
            treeNodePrim.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Primeconfig", "基元");
            treeNodeShow.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Displayshowconfig", "显示");
            treeNodeTask.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Taskconfig", "任务");
            treeNodeEle.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Element", "元件");
            treeNodeEleConfig.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Elementconfig", "元件配置");
            treeNodeEleDebug.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Elementdebug", "元件调试");
            treeNodeParam.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Parameter", "参数");
            treeNodeCommonParam.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Commonparameterconfig", "全局参数");
            treeNodeDynamicParam.Text = NLocalizer.GetString("Lead_Cprim_Controls_SettingFrm_Dynamicparamterconfig", "换型参数");
        }
        #endregion


        private void SettingFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorityManager.OnUpdateLevel -= InstanceUpdateLevel;
            NLocalizer.LanguageChanged -= OnLanguageChange;
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNames.Columns[e.ColumnIndex].Name == "cardUIDDataGridViewTextBoxColumn")
            {
                string str = dgvNames.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                dgvNames.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = str.PadLeft(10, '0');
            }
        }

        private void uiLabel8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
