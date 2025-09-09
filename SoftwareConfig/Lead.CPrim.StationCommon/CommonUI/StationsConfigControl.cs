/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: StationsConfigControl.cs
 * Author: Victor
 * Description: 工站总UI
 * CreateTime: 2021-07-18
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1207><Victor><20221228>
 * 1、tsBtnSaveStaionsConfig_Click优化，解决工站名称重命名不能保存问题
******************************************************************************/

using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.CommonUI
{
    public partial class StationsConfigControl : UIUserControl
    {
        #region Field
        private StationManager _manager;
        #endregion


        #region Ctor
        public StationsConfigControl()
        {
            InitializeComponent();
            tlpMain.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        public StationsConfigControl(StationManager manager) : this()
        {
            _manager = manager;

            RectColor = Color.FromArgb(236, 236, 236);
            fillColor = Color.FromArgb(236, 236, 236);
        }
        #endregion


        #region System_Event
        private void StationsConfigControl_Load(object sender, EventArgs e)
        {
            LoadTbCmb(_manager);
            LoadControls(_manager);
        }
        #endregion


        #region Button_Event
        /// <summary>
        /// 工站下拉框切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCmbStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tempStationName = tsCmbStations.SelectedItem.ToString();
                if (string.IsNullOrEmpty(tempStationName))
                    return;

                if (!StationManager.Instance.Stations.ContainsKey(tempStationName))
                    throw new Exception(string.Format(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinConfigNoFindInCollection", "工站管理器_工站集合_不包含工站={0}:"), tempStationName));

                if (!tabStations.TabPages.ContainsKey(tempStationName))
                    throw new Exception(string.Format(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinConfigNoFindInTabPage", "工站选项卡_不包含工站={0}:"), tempStationName));


                _manager.ChangeCurrentStationwithoutClear(tsCmbStations.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinConfigChangeFail", "工站选项卡切换失败:") + ex.Message);
            }
        }
        /// <summary>
        /// 增加工站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAddStation_Click(object sender, EventArgs e)
        {
            try
            {
                NewStation f = new NewStation();
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    string newName = f.GetNewStationName();
                    _manager.AddNewStation(newName);
                    LoadTbCmb(_manager);
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinNameAddFail", "添加工站失败:") + ex.Message);
            }
        }
        /// <summary>
        /// 删除工站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string tempStationName = tsCmbStations.SelectedItem.ToString();
                if (string.IsNullOrEmpty(tempStationName))
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_NoSelectStationConfig", "未选择工站，请先选择工站"));

                else if (MessageBox.Show(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_ConfirmDeleteStationConfig", "确定要删除当前工站吗？")
                    , NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_Warning", "警告"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tsCmbStations.SelectedIndexChanged -= tsCmbStations_SelectedIndexChanged;
                    _manager.RemoveStation(tempStationName);
                    tsCmbStations.Items.Remove(tempStationName);
                    tsCmbStations.SelectedIndex = -1;
                    tsCmbStations.SelectedIndexChanged += tsCmbStations_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinNameDeleteFail", "删除工站失败:") + ex.Message);
            }
        }
        /// <summary>
        /// 工站路径配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnOpenConfigFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinConfigDefaultPath", @"工站管理器默认路径 = D:\Config\StationConfig\StationConfigs.json，请慎重修改"),
                Filter = "json File|*.json|All File|*.*",
                RestoreDirectory = true,
                InitialDirectory = @"D:\Config\StationConfig\",
            };
            DialogResult dialogResult = ofd.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                _manager.ExportStationsConfigToPath(ofd.FileName, true);
                tsTbStationsConfigFilePath.Text = ofd.FileName;
            }
        }
        /// <summary>工站载入</summary>
        private void tsBtnLoadCmpTrigConfig_Click(object sender, EventArgs e)
        {
            _manager.ReLoad();
            LoadTbCmb(_manager);
            LoadControls(_manager);
        }
        /// <summary>
        /// 工站选项卡进行切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tempStationName = tabStations.SelectedTab.Name;
                if (!StationManager.Instance.Stations.ContainsKey(tempStationName))
                    throw new Exception(string.Format(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinConfigNoFindInCollection", "工站管理器_工站集合_不包含工站={0}:"), tempStationName));

                if (!tsCmbStations.Items.Contains(tempStationName))
                    throw new Exception(string.Format(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinConfigNoFindInComboBox", "工站选择_下拉框_不包含工站={0}:"), tempStationName));

                tsCmbStations.SelectedItem = tempStationName;
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinConfigChangeFail", "工站选项卡切换失败:") + ex.Message);
            }
        }
        #endregion


        #region 自身调用
        /// <summary>
        /// 工站界面显示（委托调用\工站载入\Load事件\增加工站\移除工站）
        /// </summary>
        /// <param name="instance"></param>
        public void LoadControls(StationManager instance)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new Action<StationManager>(LoadControls), instance);
                return;
            }

            this.tabStations.SelectedIndexChanged -= new System.EventHandler(this.tabStations_SelectedIndexChanged);
            tabStations.TabPages.Clear();
            foreach (KeyValuePair<string, StationConfig> station in _manager.Stations)
            {
                tabStations.TabPages.Add(station.Key, station.Key);
                station.Value.ConfigUi.Dock = DockStyle.Fill;
                tabStations.TabPages[station.Key].Controls.Add(station.Value.ConfigUi);
            }
            if (_manager.CurrentStation != null && tabStations.TabPages.ContainsKey(_manager.CurrentStation.Name))
            {
                tabStations.SelectedTab = tabStations.TabPages[_manager.CurrentStation.Name];
            }
            this.tabStations.SelectedIndexChanged += new System.EventHandler(this.tabStations_SelectedIndexChanged);
        }
        /// <summary>工站界面显示（更改工站）</summary>
        public void LoadControlsWithoutClear()
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new Action(LoadControlsWithoutClear));
                return;
            }

            tabStations.SelectedTab = tabStations.TabPages[_manager.CurrentStation.Name];
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        internal void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }
            tsStationsConfig.Enabled = enable;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>初始化工站名称及路径（委托调用\工站载入\Load事件\增加工站）</summary>
        /// <param name="instance"></param>
        private void LoadTbCmb(StationManager instance)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<StationManager>(LoadTbCmb), instance);
                return;
            }

            tsCmbStations.SelectedIndexChanged -= tsCmbStations_SelectedIndexChanged;
            tsCmbStations.Items.Clear();
            tsCmbStations.SelectedIndex = -1;
            if (instance.Stations == null || instance.Stations.Count == 0)
            {
                return;
            }
            _manager.Stations.Keys.ToList().ForEach(s => tsCmbStations.Items.Add(s));
            if (!string.IsNullOrEmpty(instance.CurrentStationName))
            {
                if (!tsCmbStations.Items.Contains(instance.CurrentStationName))
                {
                    tsCmbStations.Items.Add(instance.CurrentStationName);
                }
                tsCmbStations.SelectedItem = instance.CurrentStationName;
            }
            tsCmbStations.SelectedIndexChanged += this.tsCmbStations_SelectedIndexChanged;

            if (!string.IsNullOrEmpty(instance.ConfigFilePath))
            {
                tsTbStationsConfigFilePath.Text = instance.ConfigFilePath;
            }
        }
        /// <summary>保存前处理</summary>
        public void BeforeSave()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(BeforeSave));
                return;
            }
            if (tsTbStationsConfigFilePath.Text.IsNullOrEmpty())
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_StatioinConfigFilePathIsEmpty", "工站路径不能为空"));
            }
            if (_manager.CurrentStation != null)
            {
                if (string.IsNullOrEmpty(_manager.CurrentStationName) || string.IsNullOrEmpty(tsCmbStations.Text))
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_ErrMsg_NoStationConfigSelect", "请选择工站后再进行保存"));

                if (_manager.CurrentStationName == tsCmbStations.Text)
                {
                    tsCmbStations.Items.Clear();
                    tsCmbStations.SelectedItem = null;
                    _manager.Stations.Keys.ToList().ForEach(s => tsCmbStations.Items.Add(s));
                    if (!string.IsNullOrEmpty(_manager.CurrentStationName) && tsCmbStations.Items.Contains(_manager.CurrentStationName))
                    {
                        tsCmbStations.SelectedItem = _manager.CurrentStationName;
                    }

                    if (tsCmbStations.SelectedItem != null)
                    {
                        _manager.CurrentStationName = tsCmbStations.SelectedItem.ToString();
                    }
                }
            }
            _manager.ConfigFilePath = tsTbStationsConfigFilePath.Text;
        }
        #endregion

        public void OnLanguageChanged()
        {
            tsl_StationSelect.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_StationSelect", "工站选择:");
            tsl_SettingPath.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_SettingPath", "配置路径:");
            tsBtnLoadStationsConfig.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_StationsConfigControl_LoadStationsConfig", "载入");
        }
    }
}
