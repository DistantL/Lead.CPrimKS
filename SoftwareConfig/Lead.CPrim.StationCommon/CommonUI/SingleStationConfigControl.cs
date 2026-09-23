using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.StationCommon.DataArea;
using Lead.CPrim.StationCommon.MainOutput;
using Lead.CPrim.StationCommon.Recipe;
using Lead.CPrim.StationCommon.RtVars;
using Lead.CPrim.CommonParam;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Lead.CPrim.StationCommon.CommonUI
{
    public partial class SingleStationConfigControl : UIUserControl
    {
        #region Field
        /// <summary>当前配方</summary>
        private SingleRecipeCfg _selectedRecipe;

        /// <summary>当前工站</summary>
        private readonly StationConfig _station;

        /// <summary>当前工站三个按钮使能</summary>
        private CheckBox[] _chkBtnEnable;

        /// <summary>当前工站三个按钮名称</summary>
        private TextBox[] _tbBtnInfo;

        /// <summary>全局变量自定义类属性</summary>
        private List<DataArea.Property> _properties = new List<DataArea.Property>();

        private bool _isSetByConfigForm;
        #endregion



        #region Ctor
        public SingleStationConfigControl(StationConfig station)
        {
            InitializeComponent();
            _station = station;
            _chkBtnEnable = new CheckBox[3] { chkEventEnable1, chkEventEnable2, chkEventEnable3 };
            _tbBtnInfo = new TextBox[3] { tbEventInfo1, tbEventInfo2, tbEventInfo3 };
            StationManager.Instance.OnAddNewStation += InstanceOnOnAddNewStation;
            StationManager.Instance.OnRemoveStation += InstanceOnOnRemoveStation;

            dgvRecipes.SetStyle(false, false);
            dgvRecipes.MultiSelect = false;
            dgvRecipes.ReadOnly = true;

            dgvTasks.SetStyle(false, true);
            dgvTasks.MultiSelect = true;

            tabMain.SetDoubleBuffered();
            tlpMain.SetDoubleBuffered();
            tlpConfig.SetDoubleBuffered();
            tlpStationButton.SetDoubleBuffered();
            tlpRecipeButton.SetDoubleBuffered();
            tlpRecipe.SetDoubleBuffered();
            tlpTask.SetDoubleBuffered();

            dgvDataInfo.SetDoubleBuffered();
            tlpVariable.SetDoubleBuffered();

            tlpMainUi.SetDoubleBuffered();
            flowSimpleFaiConfigs.SetDoubleBuffered();

            dgvRtVars.SetDoubleBuffered();
            tlpRtVars.SetDoubleBuffered();

            Array temp = Enum.GetValues(typeof(Interfaces.DataType));
            for (int i = 0; i < temp.Length; i++)
            {
                string info = temp.GetValue(i).ToString();
                colDtType.Items.Add(info);
                colRtVarType.Items.Add(info);
            }

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            //全局参数加载
            Lead.CPrim.DynamicParam.DynamicParam.OnModeSwitch += InstanceOnModeSwitch;
            Disposed += (sender, args) => Lead.CPrim.DynamicParam.DynamicParam.OnModeSwitch -= InstanceOnModeSwitch;
        }
        #endregion

        public void InstanceOnModeSwitch(string runMode)
        {
            //当前配方
            _selectedRecipe = _station.CurrentRecipe;
            dgvTasks.Rows.Clear();
            if (_selectedRecipe.RunMode_Tasks.ContainsKey(runMode))
            {
                _selectedRecipe.Tasks = _selectedRecipe.RunMode_Tasks[runMode];
            }

            foreach (var task in _selectedRecipe.Tasks)
            {
                int index = dgvTasks.Rows.Add();
                dgvTasks.Rows[index].Cells[0].Value = task.Value.TaskName;
                dgvTasks.Rows[index].Cells[1].Value = task.Value.Statup;
            }
            btnRefreshTasks_Click(null, null);
            if (StationManager.Instance.OnlySave() != 0)
            {
                MessageBox.Show(string.Format("切换到[{0}]时，更换工站中当前task后保存失败",runMode));
            }
        }


        #region System_Event
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SingleStationConfigControl_Load(object sender, EventArgs e)
        {
            //工站
            chkStationEnable.Checked = _station.Enable;
            tbStationName.Text = _station.Name;
            tbStationIndex.Text = _station.Index.ToString();
            tbStationDescription.Text = _station.Description;

            for (int i = 0; i < _chkBtnEnable.Length; i++)
            {
                _chkBtnEnable[i].Checked = _station.BtnEnable[i];
                _tbBtnInfo[i].Text = _station.BtnInfo[i];
            }

            btnDispose.SetStyle();
            btnDispose.SetStyle(9.0f, FontStyle.Regular);
            btnInit.SetStyle();
            btnInit.SetStyle(9.0f, FontStyle.Regular);

            //当前配方
            _selectedRecipe = _station.CurrentRecipe;
            if (_selectedRecipe != null)
            {
                dgvTasks.Rows.Clear();
                if (_selectedRecipe.RunMode_Tasks.ContainsKey(Lead.CPrim.DynamicParam.DynamicParam.Instance.运行模式))
                {
                    _selectedRecipe.Tasks = _selectedRecipe.RunMode_Tasks[Lead.CPrim.DynamicParam.DynamicParam.Instance.运行模式];
                }
                foreach (var task in _selectedRecipe.Tasks)
                {
                    int index = dgvTasks.Rows.Add();
                    dgvTasks.Rows[index].Cells[0].Value = task.Value.TaskName;
                    dgvTasks.Rows[index].Cells[1].Value = task.Value.Statup;
                }
                btnRefreshTasks_Click(null, null);

                foreach (var dataInfo in _station.DataInfos)
                {
                    cmbVariableSel.Items.Add(dataInfo.Key);
                    tsCmbDataInfo.Items.Add(dataInfo.Key);
                }
                cmbVariableSel.Items.Add("");
                cmbVariableSel.SelectedItem = cmbVariableSel.Items.Contains(_selectedRecipe.VariableName) ? _selectedRecipe.VariableName : null;
                tsCmbDataInfo.SelectedItem = tsCmbDataInfo.Items.Contains(_selectedRecipe.VariableName) ? _selectedRecipe.VariableName : null;

                tabDisplayConfigs.TabPages.Clear();
                foreach (var primsDisplay in _station.MainPrimsDisplay)
                {
                    tabDisplayConfigs.TabPages.Add(primsDisplay.Key, primsDisplay.Key);
                    tabDisplayConfigs.TabPages[primsDisplay.Key].AutoScroll = true;

                    cmbMainGui.Items.Add(primsDisplay.Key);
                    tsCmbDisplayConfigs.Items.Add(primsDisplay.Key);
                }
                cmbMainGui.Items.Add("");
                cmbMainGui.SelectedItem = cmbMainGui.Items.Contains(_selectedRecipe.MainGuiConfigName) ? _selectedRecipe.MainGuiConfigName : null;
                tsCmbDisplayConfigs.SelectedItem = tsCmbDisplayConfigs.Items.Contains(_selectedRecipe.MainGuiConfigName) ? _selectedRecipe.MainGuiConfigName : null;
                tabDisplayConfigs.SelectedTab = tabDisplayConfigs.TabPages[_selectedRecipe.MainGuiConfigName];

                foreach (var dataVarse in _station.RtDataVarses)
                {
                    cmbRtVals.Items.Add(dataVarse.Key);
                    tsCmbRtVars.Items.Add(dataVarse.Key);
                }
                cmbRtVals.Items.Add("");
                cmbRtVals.SelectedItem = cmbRtVals.Items.Contains(_selectedRecipe.OutputValsName) ? _selectedRecipe.OutputValsName : null;
                tsCmbRtVars.SelectedItem = tsCmbRtVars.Items.Contains(_selectedRecipe.OutputValsName) ? _selectedRecipe.OutputValsName : null;

                rtbRecipe.Text = _selectedRecipe.ToString();
            }

            UpdateCurrentRecipe();
            UpdateDgv();
        }

        /// <summary>
        /// 配方点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRecipes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }


            string name = dgvRecipes.Rows[e.RowIndex].Cells[0].Value?.ToString();
            if (name.IsNullOrEmpty())
            {
                return;
            }

            if (_station.Recipes.ContainsKey(name))
            {
                rtbRecipe.Text = _station.Recipes[name].ToString();
            }
        }

        //任务
        /// <summary>
        /// 任务点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 || _selectedRecipe == null)
            {
                return;
            }
            string taskName = dgvTasks.Rows[e.RowIndex].Cells[0].Value.ToString();
            foreach (KeyValuePair<int, TaskMember> task in _selectedRecipe.Tasks)
            {
                if (task.Value.TaskName == taskName && bool.TryParse(dgvTasks.Rows[e.RowIndex].Cells[1].ToString(), out var bRet))
                {
                    TaskMember newTaskMember = new TaskMember(taskName, !bRet, TasksManagerTransfer.GetTaskByName(taskName));
                    _selectedRecipe.Tasks.TryUpdate(task.Key, newTaskMember, newTaskMember);
                }
            }
        }

        //全局变量
        /// <summary>
        /// 全局变量点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int collumIndex = e.ColumnIndex;
            string name = dgvDataInfo.Rows[rowIndex].Cells[0].Value?.ToString();
            if (collumIndex < 0 || rowIndex < 0 || name.IsNullOrEmpty())
            {
                return;
            }

            Interfaces.DataType dtType = DataHelper.StringToDataType(dgvDataInfo.Rows[rowIndex].Cells[1].Value?.ToString());
            string setValue = dgvDataInfo.Rows[rowIndex].Cells[3].Value?.ToString();
            if (collumIndex != 4 || setValue.IsNullOrEmpty())
            {
                return;
            }

            if (dgvDataInfo.Rows[rowIndex].Cells[1].Value.ToString().ToLower() == "class")
            {
                DataInfo dataInfo = _station.GetDataInfoByName(name, tsCmbDataInfo.SelectedItem.ToString());
                dataInfo.Value = new GlobalVariableClass(dataInfo.Name, dataInfo.Properties);
            }
            else
            {
                string strValue = dgvDataInfo.Rows[rowIndex].Cells[3].Value?.ToString();
                object value = DataHelper.StringToObjectByDataType(strValue, dtType);
                _station.SetDataInfoVal(name, value, tsCmbDataInfo.SelectedItem.ToString());
            }
        }

        /// <summary>
        /// 全局变量值变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataInfo.CurrentRow?.Cells[1].Value?.ToString().ToLower() == "class")
            {
                if (_isSetByConfigForm)
                {
                    _isSetByConfigForm = false;
                    return;
                }
                dgvDataInfo.CurrentRow.Cells[3].Value = dgvDataInfo.CurrentRow.Cells[3].Tag;
                _isSetByConfigForm = false;
            }
        }

        /// <summary>全局变量单元格增加按钮</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataInfo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.Controls.Clear();
            if (dgvDataInfo.CurrentRow.Cells[1].Value != null &&
                dgvDataInfo.CurrentRow.Cells[1].Value.ToString().ToLower() == "class" &&
                dgvDataInfo.CurrentCell.RowIndex != -1 &&
                (dgvDataInfo.CurrentCell.OwningColumn.Index == 0 || dgvDataInfo.CurrentCell.OwningColumn.Index == 2 || dgvDataInfo.CurrentCell.OwningColumn.Index == 3))
            {
                Button btn = new Button
                {
                    BackColor = SystemColors.Control,
                    Text = "...",
                    Width = 25,
                    Height = e.Control.Height,
                    Dock = DockStyle.Right
                };
                e.Control.Controls.Add(btn);
                btn.Click += OpenClassSetting_Click;
            }
        }

        /// <summary>
        /// 当单元格收到焦点时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataInfo.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }

        /// <summary>
        /// 单元格状态因其内容更改而更改时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDataInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDataInfo.IsCurrentCellDirty)
            {
                dgvDataInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion



        #region Button_Event
        /// <summary>应用</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                //停止扫描
                tsDataInfoStopMonitor_Click(null, null);

                //错误检查
                string name = tbStationName.Text.Trim();
                if (name.IsNullOrEmpty())
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_StationNameIsEmpty", "工站名称不允许为空"));

                if (StationManager.Instance.CurrentStation == null || string.IsNullOrEmpty(StationManager.Instance.CurrentStationName))
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_NoSelectStation", "请选择工站后再进行保存"));

                if (string.IsNullOrEmpty(tbStationIndex.Text.Trim()))
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_StationIndexIsEmpty", "工站序号不允许为空"));

                if (_station.Name != name && StationManager.Instance.Stations.ContainsKey(name))
                    throw new Exception(
                        string.Format(
                        NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_StationNameAlreadyExists", "工站名=[{0}]已存在，请重命名后进行保存")));

                if (_selectedRecipe == null)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_CurrentRecipeIsEmpty", "当前配方为空"));
                }

                if (_selectedRecipe != null)
                {
                    btnRefreshTasks_Click(null, null);

                    _station.Recipes[_selectedRecipe.Name].VariableName = cmbVariableSel.SelectedItem?.ToString();
                    _station.Recipes[_selectedRecipe.Name].MainGuiConfigName = cmbMainGui.SelectedItem.ToString();
                    _station.Recipes[_selectedRecipe.Name].OutputValsName = cmbRtVals.SelectedItem.ToString();

                    _selectedRecipe.Tasks.Clear();
                    int keyI = 0;
                    for (int i = 0; i < dgvTasks.Rows.Count; i++)
                    {
                        ITask task = TasksManagerTransfer.GetTaskByName(dgvTasks.Rows[i].Cells[0].Value.ToString());
                        if (task != null)
                        {
                            bool check = (Convert.ToBoolean(dgvTasks.Rows[i].Cells[1].Value.ToString()) ? true : false);
                            TaskMember newTaskMember = new TaskMember(task.Name, check, task);

                            _selectedRecipe.Tasks.TryAdd(keyI++, newTaskMember);
                        }
                    }

                    ConcurrentDictionary<int, TaskMember> temp = new ConcurrentDictionary<int, TaskMember>();
                    foreach (var item in _selectedRecipe.Tasks)
                    {
                        temp.TryAdd(item.Key, new TaskMember(item.Value.TaskName, item.Value.Statup, item.Value.Task));
                    }

                    if (_station.Recipes[_selectedRecipe.Name].RunMode_Tasks.ContainsKey(Lead.CPrim.DynamicParam.DynamicParam.Instance.运行模式))
                    {
                        _station.Recipes[_selectedRecipe.Name].RunMode_Tasks[Lead.CPrim.DynamicParam.DynamicParam.Instance.运行模式] = temp;
                    }
                    else
                    {
                        _station.Recipes[_selectedRecipe.Name].RunMode_Tasks.TryAdd(Lead.CPrim.DynamicParam.DynamicParam.Instance.运行模式, temp);
                    }
                }

                SaveDataInfo();
                SaveRtVars();

                tsBtnRefreshRtVar_Click(null, null);
                SaveStationParams();
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_CurrentStationSaveFail", "当前工站保存失败:") + ex.Message);
            }
        }

        /// <summary>
        /// 控件双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_DoubleClick(object sender, EventArgs e)
        {
            _station.IsSelected = !_station.IsSelected;
        }


        //配方
        /// <summary>新建配方</summary>
        private void btnCreateRecipe_Click(object sender, EventArgs e)
        {
            CreatNewRecipe frm = new CreatNewRecipe(_station);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.NewRecipe == null)
            {
                return;
            }

            string name = frm.NewRecipe.Name;
            _station.Recipes.TryAdd(name, frm.NewRecipe);
            _selectedRecipe = _station.Recipes[name];
            _selectedRecipe.EditTime = DateTime.Now;

            //配方Dgv刷新
            UpdateDgv();

            //全局变量
            if (!_station.DataInfos.ContainsKey(name))
            {
                _station.DataInfos.TryAdd(name, new ConcurrentDictionary<string, DataInfo>());

                //配方相关全局变量
                cmbVariableSel.Items.Insert(cmbVariableSel.Items.Count - 1, name);

                //全局变量表
                tsCmbDataInfo.Items.Add(name);

                _selectedRecipe.VariableName = name;
            }

            //主界面集合管理（配方相关主界面更新\主界面增加标签\主界面）
            if (!_station.MainPrimsDisplay.ContainsKey(name))
            {
                _station.MainPrimsDisplay.TryAdd(name, new SingleDisplayConfig(name));

                //增加Page
                tabDisplayConfigs.TabPages.Add(name, name);
                tabDisplayConfigs.TabPages[name].AutoScroll = true;

                //配方相关主界面
                cmbMainGui.Items.Insert(cmbMainGui.Items.Count - 1, name);

                //主界面表
                tsCmbDisplayConfigs.Items.Add(name);

                _selectedRecipe.MainGuiConfigName = name;
            }

            //实时变量
            if (!_station.RtDataVarses.ContainsKey(name))
            {
                _station.RtDataVarses.TryAdd(name, new RtDataVars());

                //配方相关实时变量
                cmbRtVals.Items.Insert(cmbRtVals.Items.Count - 1, name);

                //实时变量表
                tsCmbRtVars.Items.Add(name);

                _selectedRecipe.OutputValsName = name;
            }

            RecipeInit(_selectedRecipe);
            _station.CreateNewRecipe(name);
        }

        /// <summary>编辑配方</summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRecipes.Rows == null || dgvRecipes.Rows.Count <= 0)
            {
                return;
            }

            var row = dgvRecipes.CurrentCell.RowIndex;
            var col = dgvRecipes.CurrentCell.ColumnIndex;
            if (row < 0 || col < 0)
            {
                return;
            }

            string name = dgvRecipes.Rows[row].Cells[0].Value?.ToString();
            DateTime now = DateTime.Now;
            if (name.IsNullOrEmpty())
            {
                return;
            }

            if (_station.Recipes.ContainsKey(name))
            {
                _selectedRecipe = _station.Recipes[name];
                _selectedRecipe.EditTime = now;
                dgvRecipes.Rows[row].Cells[3].Value = now.ToString("yyyy-MM-dd HH:mm:ss");
                rtbRecipe.Text = _selectedRecipe.ToString();
            }
        }

        /// <summary>
        /// 选择配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
            if (_station.CurrentRecipeName != _selectedRecipe.Name)
            {
                _station.CurrentRecipeName = _selectedRecipe.Name;
                UpdateCurrentRecipe();
                _station.ChangeCurrentRecipe();
                RecipeInit(_selectedRecipe);
            }
        }

        /// <summary>
        /// 删除配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecipes.Rows == null || dgvRecipes.Rows.Count <= 0)
                {
                    return;
                }

                var row = dgvRecipes.CurrentCell.RowIndex;
                var col = dgvRecipes.CurrentCell.ColumnIndex;
                if (row < 0 || col < 0)
                {
                    return;
                }

                string name = dgvRecipes.Rows[row].Cells[0].Value?.ToString();
                if (name.IsNullOrEmpty())
                {
                    return;
                }

                if (name == _station.CurrentRecipeName)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_CannotDeleteRecipe", "不允许删除当前配方"));
                }
                else
                {
                    if (!this.ShowAskDialog(
                        string.Format(
                        NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_Tip_ConfirmToDeleteRecipe", "确认要删除该项配方[{0}]?"),name)))
                    {
                        return;
                    }

                    _station.Recipes.TryRemove(name, out var _);

                    //全局变量
                    _station.DataInfos.TryRemove(name, out var _);
                    cmbVariableSel.Items.Remove(name);
                    tsCmbDataInfo.Items.Remove(name);
                    tsCmbDataInfo.SelectedItem = null;

                    //主界面
                    _station.RtDataVarses.TryRemove(name, out var _);
                    cmbMainGui.Items.Remove(name);
                    tabDisplayConfigs.TabPages.Remove(tabDisplayConfigs.TabPages[name]);
                    tsCmbDisplayConfigs.Items.Remove(name);
                    tsCmbDisplayConfigs.SelectedItem = null;

                    //实时变量
                    _station.MainPrimsDisplay.TryRemove(name, out var _);
                    cmbRtVals.Items.Remove(name);
                    tsCmbRtVars.Items.Remove(name);
                    tsCmbRtVars.SelectedItem = null;


                    foreach (KeyValuePair<string, SingleRecipeCfg> recipe in _station.Recipes)
                    {
                        if (recipe.Value.VariableName == name)
                        {
                            recipe.Value.VariableName = "";
                        }
                        if (recipe.Value.MainGuiConfigName == name)
                        {
                            recipe.Value.MainGuiConfigName = "";
                        }
                        if (recipe.Value.OutputValsName == name)
                        {
                            recipe.Value.OutputValsName = "";
                        }
                    }

                    dgvRecipes.Rows.Remove(dgvRecipes.Rows[row]);
                    //RecipeInit(new SingleRecipeCfg());
                    //_selectedRecipe = null;
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_RecipeDeleteFail", "删除配方失败:") + ex.Message);
            }
        }

        /// <summary>上传配方</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecipeUpload_Click(object sender, EventArgs e)
        {
            _station.UpLoadRecipes();
        }


        //任务
        /// <summary>增加任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                string name = cmbTasks.SelectedItem?.ToString();
                if (name.IsNullOrEmpty())
                {
                    return;
                }

                if (_selectedRecipe == null)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_NoSelectRecipe", "请选择配方"));
                }

                ITask newTask = TasksManagerTransfer.GetTaskByName(name);
                if (newTask != null)
                {
                    int index = dgvTasks.Rows.Add();
                    dgvTasks.Rows[index].Cells[0].Value = newTask.Name;
                    dgvTasks.Rows[index].Cells[1].Value = true;

                    TaskMember newTaskMember = new TaskMember(newTask.Name, true, newTask);
                    _selectedRecipe.Tasks.TryAdd(dgvTasks.Rows.Count - 1, newTaskMember);

                    btnRefreshTasks_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                this.ShowWarningDialog(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_TaskAddFail", "增加任务失败:") + ex.Message);
            }
        }

        /// <summary>移除任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedRecipe == null)
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_NoSelectRecipe", "请选择配方"));
                }

                if (dgvTasks.SelectedRows.Count != 0)
                {
                    int i;
                    for (i = 0; i < dgvTasks.SelectedRows.Count; i++)
                    {
                        int index = dgvTasks.SelectedRows[i].Index;
                        dgvTasks.Rows.Remove(dgvTasks.Rows[index]);
                        _selectedRecipe.Tasks.TryRemove(index, out var _);
                        i--;
                    }

                    dgvTasks.Refresh();
                    btnRefreshTasks_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                this.ShowWarningDialog(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_TaskDeleteFail", "移除任务失败:")+ ex.Message);
            }
        }

        /// <summary>刷新任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshTasks_Click(object sender, EventArgs e)
        {
            RefreshTasks(_selectedRecipe.Tasks);
        }

        /// <summary>上移任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaskUp_Click(object sender, EventArgs e)
        {
            dgvTasks.DgvRowUp();
        }

        /// <summary>下移任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaskDown_Click(object sender, EventArgs e)
        {
            dgvTasks.DgvRowDown();
        }

        /// <summary>释放任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDispose_Click(object sender, EventArgs e)
        {
            _station.StationMachineTaskButton(1);
        }

        /// <summary>加载任务</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            _station.StationMachineTaskButton(2);
        }


        //全局变量
        /// <summary>
        /// 全局变量切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCmbDataInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string name = tsCmbDataInfo.SelectedItem?.ToString();
                if (name.IsNullOrEmpty())
                {
                    return;
                }

                if (!_station.Recipes.ContainsKey(name))
                {
                    throw new Exception(
                        string.Format(
                        NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_DataInfoCollectionHasnoName", "全局变量集合中不含有名称={0}")
                        ,name
                        ));
                }

                tsDataInfoStopMonitor_Click(null, null);

                dgvDataInfo.Rows.Clear();
                foreach (var keyDataInfo in _station.DataInfos[name].OrderBy(p => p.Value.Name))
                {
                    int index = dgvDataInfo.Rows.Add();
                    dgvDataInfo.Rows[index].Cells[0].Value = keyDataInfo.Value.Name;
                    dgvDataInfo.Rows[index].Cells[1].Value = keyDataInfo.Value.Type.ToString();
                    dgvDataInfo.Rows[index].Cells[5].Value = keyDataInfo.Value.Save;
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_DataInfoChangeFail", "全局变量切换失败:") + ex.Message);
            }
        }

        /// <summary>
        /// 全局变量增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAddDataInfo_Click(object sender, EventArgs e)
        {
            dgvDataInfo.Rows.Add();
        }

        /// <summary>
        /// 全局变量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelDataInfo_Click(object sender, EventArgs e)
        {
            if (dgvDataInfo.Rows.Count > 0)
            {
                int index = dgvDataInfo.CurrentCell.RowIndex;
                dgvDataInfo.Rows.RemoveAt(index);
            }
        }

        /// <summary>
        /// 全局变量开始监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDataInfoStartMonitor_Click(object sender, EventArgs e)
        {
            timerDataInfo.Start();
            tsCmbDataInfo.Enabled = false;
            tsDataInfo.BackColor = SystemColors.ActiveCaption;
        }

        /// <summary>
        /// 全局变量停止监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDataInfoStopMonitor_Click(object sender, EventArgs e)
        {
            timerDataInfo.Stop();
            tsCmbDataInfo.Enabled = true;
            tsDataInfo.BackColor = SystemColors.Control;
        }


        //主界面
        /// <summary>
        /// 主界面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCmbDisplayConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = tsCmbDisplayConfigs.SelectedItem?.ToString();
            if (name.IsNullOrEmpty())
            {
                return;
            }

            if (tabDisplayConfigs.SelectedTab.Name != name)
            {
                tabDisplayConfigs.SelectedTab = tabDisplayConfigs.TabPages[name];
            }

            var tabConfig = _station.MainPrimsDisplay.FirstOrDefault(display => display.Key == name);
            if (tabConfig.Key == null || tabConfig.Value == null)
            {
                return;
            }

            foreach (var item in tabConfig.Value.TabPagesDisplayConfig)
            {
                tabDisplayConfigs.TabPages[name].Controls.Add(item.Value.ConfigUi);
            }
        }

        /// <summary>
        /// 添加显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAddSingleConfig_Click(object sender, EventArgs e)
        {
            string name = tabDisplayConfigs.SelectedTab.Name;
            KeyValuePair<string, SingleDisplayConfig> currentConfig = _station.MainPrimsDisplay.FirstOrDefault(p => p.Key == name);

            TabDisplayConfig newTabConfig = new TabDisplayConfig();
            tabDisplayConfigs.TabPages[name].Controls.Add(newTabConfig.ConfigUi);
            currentConfig.Value.TabPagesDisplayConfig.TryAdd(Guid.NewGuid(), newTabConfig);
        }

        /// <summary>
        /// 删除显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnRemoveSingleConfig_Click(object sender, EventArgs e)
        {
            string name = tabDisplayConfigs.SelectedTab.Name;
            KeyValuePair<string, SingleDisplayConfig> currentConfig = _station.MainPrimsDisplay.FirstOrDefault(p => p.Key == name);

            foreach (var tabDisplay in currentConfig.Value.TabPagesDisplayConfig)
            {
                if (tabDisplay.Value.IsSelected)
                {
                    tabDisplayConfigs.TabPages[name].Controls.Remove(tabDisplay.Value.ConfigUi);
                    currentConfig.Value.TabPagesDisplayConfig.TryRemove(tabDisplay.Key, out var _);
                }
            }
        }


        //实时变量
        /// <summary>
        /// 实时变量切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCmbRtVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = tsCmbRtVars.SelectedItem?.ToString();
            if (name.IsNullOrEmpty())
            {
                return;
            }

            dgvRtVars.Rows.Clear();
            foreach (var keyRtVar in _station.RtDataVarses[name].DataVars.OrderBy(p => p.Key))
            {
                int index = dgvRtVars.Rows.Add();
                dgvRtVars.Rows[index].Cells[0].Value = keyRtVar.Value.Name;
                dgvRtVars.Rows[index].Cells[1].Value = keyRtVar.Value.Type.ToString();
            }
        }

        /// <summary>增加一行</summary>
        private void tsAddRtVar_Click(object sender, EventArgs e)
        {
            dgvRtVars.Rows.Add();
        }

        /// <summary>删除一行</summary>
        private void tsDelRtVar_Click(object sender, EventArgs e)
        {
            if (dgvRtVars.Rows.Count > 0)
            {
                int index = dgvRtVars.CurrentCell.RowIndex;
                dgvRtVars.Rows.RemoveAt(index);
            }
        }

        /// <summary>刷新（按钮/应用）</summary>
        private void tsBtnRefreshRtVar_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tsCmbRtVars.SelectedItem?.ToString();
                if (name.IsNullOrEmpty())
                {
                    return;
                }

                if (!_station.RtDataVarses.ContainsKey(name))
                {
                    throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_RtValueCollectionHasnoName", "实时变量集合中不包含=")+name);
                }

                ((RtVarsControl)_station.RtDataVarses[name].VarsDisplayControl).VarControlClear();
                if (_station.RtDataVarses[name].DataVars.Count <= 0)
                {
                    return;
                }

                foreach (var item in _station.RtDataVarses[name].DataVars)
                {
                    ((RtVarsControl)_station.RtDataVarses[name].VarsDisplayControl).AddVar(item.Key);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_UpDataFail", "刷新失败:") + ex.Message);
            }
        }
        #endregion



        #region Method_Instance
        /// <summary>增加工站事件响应</summary>
        /// <param name="name"></param>
        private void InstanceOnOnAddNewStation(string name)
        {

        }

        /// <summary>删除工站事件响应</summary>
        /// <param name="name"></param>
        private void InstanceOnOnRemoveStation(string name)
        {

        }

        /// <summary>响应类型CLASS全局变量保存</summary>
        /// <param name="globalVariable"></param>
        /// <param name="tempProperties"></param>
        private void InstancePropertiesValueSet(GlobalVariableClass globalVariable, List<DataArea.Property> tempProperties)
        {
            _properties = tempProperties;
            string value = JsonHelper.SerializeObject(_properties);
            foreach (DataGridViewRow row in dgvDataInfo.Rows)
            {
                string name = row.Cells[0].Value?.ToString();
                if (name.IsNullOrEmpty())
                {
                    continue;
                }

                if (name == globalVariable.ClassName)
                {
                    _isSetByConfigForm = true;
                    row.Cells[3].Value = value;
                    row.Cells[3].Tag = value;
                    break;
                }
            }

            DataInfo dataInfo = _station.GetDataInfoByName(globalVariable.ClassName, tsCmbDataInfo.SelectedItem.ToString());
            if (dataInfo == null)
            {
                dataInfo = new DataInfo
                {
                    Name = globalVariable.ClassName,
                    Type = Interfaces.DataType.CLASS,
                };
                _station.DataInfos[tsCmbDataInfo.SelectedItem.ToString()].TryAdd(globalVariable.ClassName, dataInfo);
            }
            dataInfo.Properties = _properties;
            dataInfo.Value = new GlobalVariableClass(globalVariable.ClassName, _properties);
            _station.SetDataInfoVal(globalVariable.ClassName, dataInfo.Value, tsCmbDataInfo.SelectedItem.ToString());
        }

        /// <summary>全局变量值改变时发生</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstanceDataInfoChanged(object sender, EventArgs e)
        {
        }
        #endregion



        #region Method_ExternalUsing
        //任务
        /// <summary>任务按钮使能变更</summary>
        /// <param name="enable"></param>
        public void TaskButtonEnable(bool enable)
        {
            btnDispose.Enabled = enable;
            btnInit.Enabled = !enable;
        }

        //全局变量
        /// <summary>全局变量表中增加</summary>
        /// <param name="currentRecipeName"></param>
        /// <param name="newDt"></param>
        internal void TryAddDataInfo(string currentRecipeName, DataInfo newDt)
        {
            if (dgvDataInfo.InvokeRequired)
            {
                BeginInvoke(new Action<string, DataInfo>(TryAddDataInfo), currentRecipeName, newDt);
            }
            else
            {
                if (tsCmbDataInfo.SelectedItem == null)
                {
                    return;
                }

                if (tsCmbDataInfo.SelectedItem.ToString() != currentRecipeName)
                {
                    return;
                }

                bool noContain = true;
                foreach (DataGridViewRow row in dgvDataInfo.Rows)
                {
                    if (row.Cells[0].Value.ToString() == newDt.Name)
                    {
                        noContain = false;
                        break;
                    }
                }
                if (noContain)
                {
                    int index = dgvDataInfo.Rows.Add();
                    dgvDataInfo.Rows[index].Cells[0].Value = newDt.Name;
                    dgvDataInfo.Rows[index].Cells[1].Value = newDt.Type.ToString();
                    dgvDataInfo.Rows[index].Cells[2].Value = newDt.Value.ToString();
                    dgvDataInfo.Rows[index].Cells[5].Value = newDt.Save;
                }
            }
        }

        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        internal void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }

            tlpTitle.Enabled = enable;
            foreach (Control con in tpMain.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpVariable.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpOutputUI.Controls)
            {
                con.Enabled = enable;
            }
            foreach (Control con in tpRtVals.Controls)
            {
                con.Enabled = enable;
            }
        }
        #endregion



        #region Method_InternalUsing
        //工站
        /// <summary>
        /// 保存工站参数
        /// </summary>
        private void SaveStationParams()
        {
            if (_station.Name != tbStationName.Text)
            {
                StationManager.Instance.Stations.TryRemove(_station.Name, out var _);
                _station.Name = tbStationName.Text;
                StationManager.Instance.Stations.TryAdd(tbStationName.Text, _station);
                StationManager.Instance.CurrentStationName = _station.Name;
                this.ShowWarningDialog(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_Tip_NeedRestart", "请注意：更改工站名后需重启软件，否则系统会有报错！"));
            }
            _station.Index = int.Parse(tbStationIndex.Text);
            _station.Description = tbStationDescription.Text;
            _station.Enable = chkStationEnable.Checked;

            //主界面按钮保存
            for (int i = 0; i < _chkBtnEnable.Length; i++)
            {
                _station.BtnEnable[i] = _chkBtnEnable[i].Checked;
                _station.BtnInfo[i] = _tbBtnInfo[i].Text;
            }
        }

        //配方
        /// <summary>配方目录更新</summary>
        private void UpdateDgv()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdateDgv));
                return;
            }

            SuspendLayout();
            dgvRecipes.Rows.Clear();
            foreach (SingleRecipeCfg recipe in _station.Recipes.Values)
            {
                dgvRecipes.Rows.Add(recipe.Name, recipe.Creator, recipe.CreatTime.ToString("yyyy-MM-dd HH:mm:ss"), recipe.EditTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            ResumeLayout();
        }

        /// <summary>
        /// 根据配方初始化（新建配方\编辑配方\删除配方）
        /// </summary>
        /// <param name="recipe"></param>
        private void RecipeInit(SingleRecipeCfg recipe)
        {
            rtbRecipe.Text = recipe.ToString();

            //全局变量
            cmbVariableSel.SelectedItem = (cmbVariableSel.Items.Contains(recipe.VariableName) ? recipe.VariableName : null);

            //主界面
            cmbMainGui.SelectedItem = (cmbMainGui.Items.Contains(recipe.MainGuiConfigName) ? recipe.MainGuiConfigName : null);

            //实时变量
            cmbRtVals.SelectedItem = (cmbRtVals.Items.Contains(recipe.OutputValsName) ? recipe.OutputValsName : null);

            dgvTasks.Rows.Clear();
            foreach (KeyValuePair<int, TaskMember> task in recipe.Tasks)
            {
                int index = dgvTasks.Rows.Add();
                dgvTasks.Rows[index].Cells[0].Value = task.Value.TaskName;
                dgvTasks.Rows[index].Cells[1].Value = task.Value.Statup;
            }

            RefreshTasks(recipe.Tasks);
        }

        /// <summary>
        /// 更新配方信息
        /// </summary>
        internal void UpdateCurrentRecipe()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdateCurrentRecipe));
                return;
            }
            tbCurrentRecipe.Text = _station.CurrentRecipeName;
            rtbRecipe.Text = _station.CurrentRecipe.ToString();
        }

        /// <summary>
        /// 配方基元配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecipePrimsConfig_Click(object sender, EventArgs e)
        {
            if (_selectedRecipe == null)
            {
                MessageBox.Show("配方未选择，请先选择一个配方");
                return;
            }
            RecipePrimsConfigForm primsConfigForm = new RecipePrimsConfigForm(_selectedRecipe);
            primsConfigForm.StartPosition = FormStartPosition.CenterParent;
            primsConfigForm.ShowDialog();
        }

        /// <summary>
        /// 配方元件配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecipeElesConfig_Click(object sender, EventArgs e)
        {
            if (_selectedRecipe == null)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_NoSelectRecipe", "配方未选择，请先选择一个配方"));
                return;
            }
            RecipeElesConfigForm elesConfigForm = new RecipeElesConfigForm(_selectedRecipe);
            elesConfigForm.StartPosition = FormStartPosition.CenterParent;
            elesConfigForm.ShowDialog();
        }

        //任务
        /// <summary>
        /// 任务刷新
        /// </summary>
        /// <param name="tasks"></param>
        private void RefreshTasks(ConcurrentDictionary<int, TaskMember> tasks)
        {
            if (TasksManagerTransfer.GetAllITask().Count >= 1 && _selectedRecipe != null)
            {
                //添加所有项
                cmbTasks.Items.Clear();
                cmbTasks.Items.AddRange(TasksManagerTransfer.GetAllITask().Select(t => t.Name).ToArray());

                //添加任务项
                tasks.Clear();
                for (int i = 0; i < dgvTasks.Rows.Count; i++)
                {
                    ITask task = TasksManagerTransfer.GetTaskByName(dgvTasks.Rows[i].Cells[0].Value?.ToString());
                    if (task != null)
                    {
                        bool check = (Convert.ToBoolean(dgvTasks.Rows[i].Cells[1].Value?.ToString()) ? true : false);
                        tasks.TryAdd(i, new TaskMember(task.Name, check, task));
                    }
                }

                //移除任务项
                foreach (KeyValuePair<int, TaskMember> item in tasks)
                {
                    if (cmbTasks.Items.Contains(item.Value.TaskName))
                    {
                        cmbTasks.Items.Remove(item.Value.TaskName);
                        cmbTasks.SelectedIndex = -1;
                    }
                }
            }
        }

        //全局变量
        /// <summary>
        /// 全局变量刷新定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDataInfo_Tick(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, DataInfo> dataInfo in _station.DataInfos[tsCmbDataInfo.SelectedItem.ToString()])
            {
                if (dataInfo.Value.Update)
                {
                    OnDataInfoShowUpdate_Handle2(dataInfo.Value.Name, dataInfo.Value.Value);
                    dataInfo.Value.Update = false;
                }
            }
        }

        /// <summary>
        /// 全局变量刷新定时器子方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void OnDataInfoShowUpdate_Handle(string name, object value)
        {
            if (dgvDataInfo.InvokeRequired)
            {
                BeginInvoke(new Action<string, object>(OnDataInfoShowUpdate_Handle), name, value);
                return;
            }

            int rowCount = dgvDataInfo.Rows.Count;
            if (rowCount < 1)
            {
                return;
            }

            for (int i = 0; i < rowCount; i++)
            {
                if (dgvDataInfo.Rows[i].Cells[0].Value.ToString() == name)
                {
                    if (dgvDataInfo.Rows[i].Cells[1].Value.ToString().ToLower() == "class")
                    {
                        dgvDataInfo.Rows[i].Cells[2].Value = JsonHelper.SerializeObject(((GlobalVariableClass)value).Properties);
                    }
                    else
                    {
                        dgvDataInfo.Rows[i].Cells[2].Value = value;
                    }
                }
            }
        }

        private void OnDataInfoShowUpdate_Handle2(string name, object value)
        {
            if (dgvDataInfo.InvokeRequired)
            {
                BeginInvoke(new Action<string, object>(OnDataInfoShowUpdate_Handle2), name, value);
                return;
            }

            int rowCount = dgvDataInfo.Rows.Count;
            if (rowCount < 1)
            {
                return;
            }

            for (int i = 0; i < rowCount; i++)
            {
                if (dgvDataInfo.Rows[i].Cells[0].Value.ToString() == name)
                {
                    if (dgvDataInfo.Rows[i].Cells[1].Value.ToString().ToLower() == "class")
                    {
                        dgvDataInfo.Rows[i].Cells[2].Value = JsonHelper.SerializeObject(value);
                    }
                    else
                    {
                        dgvDataInfo.Rows[i].Cells[2].Value = value;
                    }
                }
            }
        }

        /// <summary>
        /// 全局变量为类时点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenClassSetting_Click(object sender, EventArgs e)
        {
            try
            {
                string name = dgvDataInfo.CurrentRow.Cells[0].Value?.ToString();
                if (name.IsNullOrEmpty())
                {
                    return;
                }

                GlobalVariableClass globalVariableClass;
                DataInfo dataInfo = _station.GetDataInfoByName(name, tsCmbDataInfo.SelectedItem.ToString());
                if (dataInfo != null)
                {
                    if (dataInfo.Value == null)
                    {
                        globalVariableClass = new GlobalVariableClass(name);
                    }
                    else
                    {
                        globalVariableClass = new GlobalVariableClass(name, dataInfo.Properties);
                    }
                }
                else
                {

                    globalVariableClass = new GlobalVariableClass(name);
                }

                GlobalVariableClassFrm configForm = new GlobalVariableClassFrm();
                configForm.StartPosition = FormStartPosition.CenterScreen;
                if (dgvDataInfo.CurrentCell.ColumnIndex == 0)
                {
                    configForm.IntiForm(OperationMode.ConfigProperty, globalVariableClass);
                }
                else if (dgvDataInfo.CurrentCell.ColumnIndex == 2)
                {
                    configForm.IntiForm(OperationMode.ReadProperty, globalVariableClass);
                }
                else if (dgvDataInfo.CurrentCell.ColumnIndex == 3)
                {
                    configForm.IntiForm(OperationMode.SetPropertyValue, globalVariableClass);
                }

                configForm.OnPropertiesValueSet -= InstancePropertiesValueSet;
                configForm.OnPropertiesValueSet += InstancePropertiesValueSet;
                configForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Notification.ShowError(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_UIFail", "类UI点击失败:") + ex.Message);
            }
        }

        /// <summary>
        /// 全局变量保存
        /// </summary>
        private void SaveDataInfo()
        {
            int rowCount = dgvDataInfo.Rows.Count;
            if (rowCount < 1)
            {
                return;
            }

            string dicName = "";
            if (tsCmbDataInfo.SelectedItem != null)
            {
                dicName = tsCmbDataInfo.SelectedItem.ToString();
            }

            if (!_station.DataInfos.ContainsKey(dicName))
            {
                throw new Exception(
                    string.Format(
                    NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_DataInfoCollectionHasnoName", "全局变量集合中不含有名称={0}")
                    , dicName
                ));
            }

            string tempError = null;
            if (ControlHelper.CheckDgvCellRepeat(dgvDataInfo, ref tempError))
            {
                throw new Exception(tempError);
            }

            for (int i = 0; i < rowCount; i++)
            {
                string valName = dgvDataInfo.Rows[i].Cells[0].Value?.ToString();
                string valType = dgvDataInfo.Rows[i].Cells[1].Value?.ToString();
                if (valType.IsNullOrEmpty())
                {
                    throw new Exception(
                        string.Format(
                            NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_dgvDataInfoColumnsIn2IsEmpty", "第[{0}]行，第[2]列为空")
                            ,i+1
                        ));
                }

                //对现有数据进行更新
                if (_station.DataInfos[dicName].ContainsKey(valName))
                {
                    DataInfo data = _station.GetDataInfoByName(valName, dicName);
                    DataType tempDataType = DataHelper.StringToDataType(valType);
                    if (data.Type != tempDataType)
                    {
                        data.Type = tempDataType;
                    }

                    if (valType.ToLower() == "class")
                    {
                        if (data.Properties == null)
                        {
                            data.Value = new GlobalVariableClass(valName);
                        }
                        else
                        {
                            data.Value = new GlobalVariableClass(valName, data.Properties);
                        }
                    }
                    data.Save = dgvDataInfo.Rows[i].Cells[5].Value == null ? false : bool.Parse(dgvDataInfo.Rows[i].Cells[5].Value.ToString());
                    continue;
                }

                //对新数据进行追加
                DataInfo dataInfo = new DataInfo();
                dataInfo.OnChanged += InstanceDataInfoChanged;
                dataInfo.Name = valName;
                dataInfo.Type = DataHelper.StringToDataType(valType);
                if (valType.ToLower() == "class")
                {
                    DataInfo tempData2 = _station.GetDataInfoByName(dgvDataInfo.Rows[i].Cells[0].Value.ToString(), tsCmbDataInfo.SelectedItem.ToString());
                    if (((GlobalVariableClass)tempData2.Value).Properties == null)
                    {
                        dataInfo.Value = new GlobalVariableClass(dgvDataInfo.Rows[i].Cells[0].Value.ToString());
                    }
                    else
                    {
                        dataInfo.Value = ((GlobalVariableClass)tempData2.Value).Properties;
                    }
                    //object varObj = (dataInfo.Value = new VariableObj(dgvDataInfo.Rows[i].Cells[0].Value.ToString()));
                }
                else
                {
                    dataInfo.Value = dgvDataInfo.Rows[i].Cells[2].Value;
                }
                dataInfo.Update = true;
                dataInfo.Save = dgvDataInfo.Rows[i].Cells[5].Value == null ? false : bool.Parse(dgvDataInfo.Rows[i].Cells[5].Value.ToString());

                if (!_station.DataInfos[dicName].TryAdd(dataInfo.Name, dataInfo))
                {
                    throw new Exception(
                        string.Format(
                        NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_RtValueCollectionNoName", "安全队列在添加{0}时发生错误")
                        , dataInfo.Name
                       ));
                }
            }
            List<string> removeDataInfos = new List<string>();
            foreach (KeyValuePair<string, DataInfo> data2 in _station.DataInfos[dicName])
            {
                bool isExist = false;
                foreach (DataGridViewRow row in (IEnumerable)dgvDataInfo.Rows)
                {
                    if (row.Cells[0].Value.ToString() == data2.Key)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    removeDataInfos.Add(data2.Key);
                }
            }
            foreach (string name in removeDataInfos)
            {
                _station.DataInfos[dicName].TryRemove(name, out var _);
            }

            //动态生成dll
            string path = Application.StartupPath + @"\ExtLibs\Third\GlobalVariable.dll";
            if (!File.Exists(path))
            {
                CompilerResults cr = GenerateCode().CreateDll(path);
                List<string> strs = new List<string>();
                if (cr.Errors.HasErrors)
                {
                    foreach (CompilerError err in cr.Errors)
                    {
                        strs.Add(err.ErrorText);
                    }
                    this.ShowErrorDialog(string.Join("/n", strs.ToArray()));
                }
            }
        }

        /// <summary>
        /// 生成全局变量枚举
        /// </summary>
        /// <returns></returns>
        private string GenerateCode()
        {
            StringBuilder text = new StringBuilder();
            text.Append(" using System; ");
            text.Append(Environment.NewLine);
            text.Append(" namespace GlobalVariable ");
            text.Append(Environment.NewLine);
            text.Append(" { ");
            text.Append(Environment.NewLine);
            text.Append("     public enum GlobalVariableEnum ");
            text.Append(Environment.NewLine);
            text.Append("     { ");
            text.Append(Environment.NewLine);
            foreach (var item in _station.DataInfos[tsCmbDataInfo.SelectedItem.ToString()])
            {
                text.Append($"         {item.Value.Name}, ");
                text.Append(Environment.NewLine);
            }
            text.Append("     } ");
            text.Append(Environment.NewLine);
            text.Append(" } ");
            return text.ToString();
        }


        //主界面


        // 实时变量
        /// <summary>实时变量保存（应用/刷新）</summary>
        internal void SaveRtVars()
        {
            tsCmbRtVars.SelectedItem = _selectedRecipe.OutputValsName;
            string errorText = "";
            string dicName = tsCmbRtVars.SelectedItem?.ToString(); ;
            if (dicName.IsNullOrEmpty())
            {
                return;
            }

            if (!_station.RtDataVarses.ContainsKey(dicName))
            {
                throw new Exception(NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_ErrMsg_RtValueCollectionNoName", "实时变量集合中不包含名称:") + dicName);
            }

            if (ControlHelper.CheckDgvCellRepeat(dgvRtVars, ref errorText))
            {
                throw new Exception(errorText);
            }

            for (int i = 0; i < dgvRtVars.Rows.Count; i++)
            {
                string valName = dgvRtVars.Rows[i].Cells[0].Value.ToString();
                if (_station.RtDataVarses[dicName].DataVars.ContainsKey(valName))
                {
                    object value1 = dgvRtVars.Rows[i].Cells[1].Value;
                    object value2 = dgvRtVars.Rows[i].Cells[2].Value;
                    if (value1 != null && DataHelper.StringToDataType(value1.ToString()) != _station.RtDataVarses[dicName].DataVars[valName].Type)
                    {
                        _station.RtDataVarses[dicName].DataVars[valName].Type = DataHelper.StringToDataType(value1.ToString());
                    }
                    if (value2 != null && bool.Parse(value2.ToString()) != _station.RtDataVarses[dicName].DataVars[valName].Save)
                    {
                        _station.RtDataVarses[dicName].DataVars[valName].Save = bool.Parse(value2.ToString());
                    }
                    continue;
                }
                RtDataVar newRtVar = new RtDataVar();
                newRtVar.Name = dgvRtVars.Rows[i].Cells[0].Value.ToString();
                if (dgvRtVars.Rows[i].Cells[1].Value != null)
                {
                    newRtVar.Type = DataHelper.StringToDataType(dgvRtVars.Rows[i].Cells[1].Value.ToString());
                }
                if (dgvRtVars.Rows[i].Cells[2].Value != null)
                {
                    newRtVar.Save = bool.Parse(dgvRtVars.Rows[i].Cells[2].Value.ToString());
                }
                _station.RtDataVarses[dicName].DataVars.TryAdd(newRtVar.Name, newRtVar);
            }

            List<string> removeDataInfos = new List<string>();
            foreach (KeyValuePair<string, RtDataVar> data in _station.RtDataVarses[dicName].DataVars)
            {
                bool isExist = false;
                foreach (DataGridViewRow row in dgvRtVars.Rows)
                {
                    if (row.Cells[0].Value.ToString() == data.Key)
                    {
                        isExist = true;
                        break;
                    }
                }
                if (!isExist)
                {
                    removeDataInfos.Add(data.Key);
                }
            }

            foreach (string name in removeDataInfos)
            {
                _station.RtDataVarses[dicName].DataVars.TryRemove(name, out var _);
                _ = MongodbHelper.DeleteOneAsync<RtDataVar>("Name", name, _station.RtDataVarsCollection, null);
            }
        }
        #endregion

        public void OnLanguageChanged()
        {
            chkStationEnable.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_StationEnable", "工站名称:");
            lb_StationIndex.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_StationIndex", "工站序号:");
            lb_StationInfo.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_StationInfo", "工站描述:");
            lb_CurrentStationRecipe.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_CurrentStationRecipe", "当前配方:");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_Apply", "应用");
            tpMain.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tpMain", "主配置");
            tpVariable.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tpVariable", "全局变量");
            tpOutputUI.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tpOutputUI", "主界面");
            tpRtVals.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tpRtVals", "实时变量");

            lb_StationButton.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_lb_StationButton", "工站按钮");
            chkEventEnable1.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_chkEventEnable1", "工站按钮1");
            chkEventEnable2.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_chkEventEnable2", "工站按钮2");
            chkEventEnable3.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_chkEventEnable3", "工站按钮3");
            lb_RecipeInfo.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_lb_RecipeInfo", "配方相关");
            lb_CommonParam.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_lb_CommonParam", "全局变量");
            lb_MainGUI.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_lb_MainGUI", "主界面");
            lb_RtValue.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_lb_RtValue", "实时变量");
            btnRecipePrimsConfig.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnRecipePrimsConfig", "基元配置");
            btnRecipeElesConfig.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnRecipeElesConfig", "元件配置");
            lb_Task.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_lb_Task", "任务");

            dgvRecipes.Columns["colName"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colName", "配方名称");
            dgvRecipes.Columns["colCreator"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colCreator", "创建者");
            dgvRecipes.Columns["colCreatTime"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colCreatTime", "创建时间");
            dgvRecipes.Columns["colEditTime"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colEditTime", "编辑时间");


            dgvTasks.Columns["TaskName"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_TaskName", "名称");
            dgvTasks.Columns["TaskStatup"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_TaskStatup", "启用");

            btnCreateRecipe.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnCreateRecipe", "新建配方");
            btnEdit.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnEdit", "编辑配方");
            btnSelect.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnSelect", "选择配方");
            btnRecipeUpload.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnRecipeUpload", "上传配方列表");
            btnDeleteRecipe.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnDeleteRecipe", "删除选中的配方");
            btnDispose.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnDispose", "释放任务");
            btnInit.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_btnInit", "加载任务");
            lb_SelectRecipeInfo.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_lb_SelectRecipeInfo", "选中的配方信息");

            tsl_DataInfo.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tsl_DataInfo", "全局变量表:");

            dgvDataInfo.Columns["colDtName"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colDtName", "变量名");
            dgvDataInfo.Columns["colDtType"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colDtType", "变量类型");
            dgvDataInfo.Columns["colDtValue"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colDtValue", "当前值");
            dgvDataInfo.Columns["colDtInputVal"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colDtInputVal", "更改值");
            dgvDataInfo.Columns["colDtInput"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colDtInput", "更改");
            dgvDataInfo.Columns["colDtSave"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colDtSave", "掉电保持");

            tsl_MainGUItable.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tsl_MainGUItable", "主界面表:");
            tsBtnAddSingleConfig.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tsBtnAddSingleConfig", "添加一个新的显示选项");
            tsBtnRemoveSingleConfig.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tsBtnRemoveSingleConfig", "删除当前选中的显示选项");
            tsBtnRemoveSingleConfig.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tsBtnRemoveSingleConfig", "删除当前选中的显示选项");
            tPageDisplayConfig.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tPageDisplayConfig", "显示配置");

            tsl_RtVars.Text = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_tsl_RtVars", "实时变量表:");

            dgvRtVars.Columns["colRtVarName"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colRtVarName", "变量名");
            dgvRtVars.Columns["colRtVarType"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colRtVarType", "变量类型");
            dgvRtVars.Columns["colRtVarSave"].HeaderText = NLocalizer.GetString("Lead_CPrim_StationCommon_CommonUI_SingleStationConfigControl_colRtVarSave", "掉电保持");
        }
    }
}
