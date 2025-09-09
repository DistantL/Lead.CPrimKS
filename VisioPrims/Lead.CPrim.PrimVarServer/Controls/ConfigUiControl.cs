using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.PrimVarManager.Controls
{
    /// <summary>ConfigUiControl</summary>
    public partial class ConfigUiControl : UserControl
    {
        #region Field
        /// <summary>通讯基元管理器</summary>
        private readonly VarManager _manager;
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="variableServer">通讯基元管理器</param>
        public ConfigUiControl(VarManager variableServer)
        {
            InitializeComponent();
            _manager = variableServer;

            dgvVars.SetDoubleBuffered();
            dgvVars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void ConfigUiControl_Load(object sender, EventArgs e)
        {
            tbName.Text = _manager.Name;
            tbParamsPath.Text = _manager.ValsSavePath;
            tbServerPCName.Text = _manager.ServerPCName;
            tbServerIp.Text = _manager.ServerIp;
            tbServerName.Text = _manager.ServerName;
            chkCycleEnable.Checked = _manager.CycleEnable;
            tbCycleTime.Text = _manager.CycleTime.ToString();
            cmbVarsType.SelectedItem = _manager.VarsType == VarManagerType.Server ? "Server" : "Client";

            dgvVars.Rows.Clear();
            foreach (var val in _manager.Vals) AddVarToDgv(val.Value);

            for (int i = 0; i < dgvVars.Columns.Count; i++)
            {
                if (i == 0)
                {
                    dgvVars.Columns[i].Width = 200;
                }
                else if (i == 1 || i == 2 || i == 5 || i == 6)
                {
                    dgvVars.Columns[i].Width = 100;
                }
                else if (i == 3 || i == 4)
                {
                    dgvVars.Columns[i].Width = 200;
                }
            }

            if(_manager.PrimRunStat == PrimRunState.Running)
            {
                foreach (var val in _manager.Vals)
                {
                    var obj = _manager.Read(val.Key);
                    if (val.Value.ReadMode == DataReadMode.Cycle)
                    {
                        UpdateVariableValue(val.Key, obj);
                    }
                    if (val.Value.ReadMode == DataReadMode.Queue)
                    {
                        var count = _manager.QueueCount(val.Key);
                        UpdateVariableValue(val.Key, count);
                    }
                }
            }

            SetPrimConnState(_manager.PrimConnStat);
            SetPrimRunState(_manager.PrimRunStat);
        }
        #endregion



        #region Button_Event
        /// <summary>增加一行</summary>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            var newVal = new RemoteVar
            {
                Name = "",
                DataType = DataType.BOOL,
                Permission = DataPermission.RW,
                ReadMode = DataReadMode.NonCycle,
                IsEventNotify = false
            };
            AddVarToDgv(newVal);
        }
        /// <summary>删除一行</summary>
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dgvVars.Rows.Count <= 0 || dgvVars.SelectedRows.Count <= 0) return;
            foreach (DataGridViewRow row in dgvVars.SelectedRows)
            {
                dgvVars.Rows.Remove(row);
            }
        }
        /// <summary>更改控件Text属性时发生</summary>
        private void tbParamsPath_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbParamsPath.Text.Trim()))
                {
                btnLoadParams.Text = "浏览";
            }
            else
            {
                btnLoadParams.Text = "加载";
            }
        }
        /// <summary>载入</summary>
        private void btnLoadParams_Click(object sender, EventArgs e)
        {
            try
            {
                string path = tbParamsPath.Text.Trim();
                if (string.IsNullOrEmpty(_manager.ValsSavePath) || string.IsNullOrEmpty(path))
                {
                    if (!FileHelper.SaveFileDialogMethod("", FilterType.JSON, DefaultExt.JSON, true, true, true, ref path))
                    {
                        return;
                    }

                    if (!string.IsNullOrEmpty(path))
                    {
                        tbParamsPath.Text = path;
                        _manager.ValsSavePath = path;
                    }
                }
                else
                {
                    _manager.ImportValsFromFile();
                    dgvVars.Rows.Clear();
                    if (_manager.Vals != null && _manager.Vals.Count > 0)
                    {
                        foreach (var val in _manager.Vals) AddVarToDgv(val.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Notification.ShowError("载入失败：" + ex.Message);
            }
        }
        /// <summary>保存</summary>
        private void btnSaveParams_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_manager.ValsSavePath))
            {
                var saveFile = new SaveFileDialog
                {
                    Filter = @"json File|*.json|All File|"".""",
                    RestoreDirectory = true
                };
                var dialogResult = saveFile.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    btnApply_Click(null, null);
                    _manager.ValsSavePath = saveFile.FileName;
                    tbParamsPath.Text = saveFile.FileName;
                    _manager.ExportValsToFile();
                }
            }
            else
            {
                btnApply_Click(null, null);
                _manager.ExportValsToFile();
            }
        }
        /// <summary>初始化</summary>
        private void btnInit_Click(object sender, EventArgs e)
        {
            int iRet = 0;
            iRet = _manager.IPrimInit();
            if (iRet != 0)
            {
                Notification.ShowError("初始化失败！！！");
                return;
            }

            var result = "";
            iRet = _manager.IPrimConnect(ref result);
            if (iRet != 0)
            {
                Notification.ShowError("连接失败！！！");
            }
        }
        /// <summary>运行</summary>
        private void btnRun_Click(object sender, EventArgs e)
        {
            int iRet = _manager.IPrimStart();
            if (iRet != 0)
            {
                Notification.ShowError("运行失败！！！");
            }
        }
        /// <summary>停止</summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            int iRet = _manager.IPrimTaskStop();
            if (iRet != 0)
            {
                Notification.ShowError("基元停止失败！！！");
            }
        }
        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_manager.PrimRunStat == PrimRunState.Running)
                {
                    throw new Exception("基元运行中，请停止后进行保存");
                }

                if (string.IsNullOrEmpty(_manager.ValsSavePath) || string.IsNullOrEmpty(tbParamsPath.Text.Trim()))
                {
                    throw new Exception("保存文件路径不能为空");
                }

                string errorText = "";
                if (ControlHelper.CheckDgvCellRepeat(dgvVars, ref errorText))
                {
                    throw new Exception(errorText);
                }

                for (var j = 0; j < dgvVars.Rows.Count; j++) dgvVars.Rows[j].Cells[0].Style.BackColor = Color.AntiqueWhite;

                VarManagerType oldType = _manager.VarsType;
                var oldServerName = _manager.ServerName;
                var oldServerPcNamePath = _manager.ServerPCName;
                var oldServerIp = _manager.ServerIp;

                if (cmbVarsType.SelectedItem != null && cmbVarsType.SelectedItem.ToString() == "Client")
                {
                    _manager.VarsType = VarManagerType.Client;
                }
                else
                {
                    _manager.VarsType = VarManagerType.Server;
                }
                _manager.ServerName = tbServerName.Text;
                _manager.ServerPCName = tbServerPCName.Text;
                _manager.ServerIp = tbServerIp.Text;
                if (int.TryParse(tbCycleTime.Text.Trim(), out var outTime))
                {
                    _manager.CycleTime = outTime;
                }
                chkCycleEnable_CheckedChanged(null, null);

                if ((oldType != _manager.VarsType || oldServerName != _manager.ServerName || oldServerPcNamePath != _manager.ServerPCName || oldServerIp != _manager.ServerIp) && _manager.PrimRunStat == PrimRunState.Running)
                {
                    _manager.SetConn_RunState(PrimConnState.UnConnected, PrimRunState.Other);
                    _manager.IPrimInit();
                    var strConn = "";
                    _manager.IPrimConnect(ref strConn);
                    _manager.IPrimStart();
                }

                _manager.Vals.Clear();
                for (var i = 0; i < dgvVars.Rows.Count; i++)
                {
                    var newVal = new RemoteVar
                    {
                        Name = dgvVars.Rows[i].Cells[0].Value.ToString(),
                        DataType = DataHelper.StringToDataType(dgvVars.Rows[i].Cells[1].Value.ToString()),
                        Permission = DataHelper.StringToPermission(dgvVars.Rows[i].Cells[2].Value.ToString()),
                        ReadMode = DataHelper.StringToDataReadMode(dgvVars.Rows[i].Cells[5].Value.ToString()),
                        IsEventNotify = (bool)dgvVars.Rows[i].Cells[6].Value
                    };

                    if (_manager.PrimRunStat == PrimRunState.Running)
                    {
                        _manager.AddVar(newVal);
                    }
                    else
                    {
                        if (_manager.Vals.ContainsKey(newVal.Name))
                        {
                            _manager.Vals.TryUpdate(newVal.Name, newVal, newVal);
                        }
                        else
                        {
                            _manager.Vals.TryAdd(newVal.Name, newVal);
                        }
                    }
                }
                _manager.ExportValsToFile();
                Notification.ShowInfo("应用成功！！！");
            }
            catch (Exception ex)
            {
                Notification.ShowError("应用失败：" + ex.Message);
            }
        }
        /// <summary>循环扫描使能切换</summary>
        private void chkCycleEnable_CheckedChanged(object sender, EventArgs e)
        {
            _manager.CycleEnable = chkCycleEnable.Checked;
        }
        /// <summary>当前选定单元格的编辑模式停止时发生</summary>
        private void dgvVars_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (dgvVars.Rows[e.RowIndex].Cells[1].Value.ToString() == "CLASS" ||
                    dgvVars.Rows[e.RowIndex].Cells[1].Value.ToString() == "Other")
                {
                    dgvVars.Rows[e.RowIndex].Cells[3].ReadOnly = true;
                    dgvVars.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                }
            }
            else if (e.ColumnIndex == 4)
            {
                var newValue = dgvVars.Rows[e.RowIndex].Cells[4].Value;
                if (newValue != null && !string.IsNullOrEmpty(newValue.ToString()))
                {
                    _manager.Write(dgvVars.Rows[e.RowIndex].Cells[0].Value.ToString(), newValue.ToString());
                }
            }
        }
        /// <summary>当前选定单元格的编辑模式停止时发生</summary>
        private void dgvVars_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVars.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
                SendKeys.Send("{F4}");
        }
        #endregion





        #region Others
        /// <summary>DataGridView增加数据</summary>
        /// <param name="val"></param>
        private void AddVarToDgv(RemoteVar val)
        {
            var index = dgvVars.Rows.Add();
            dgvVars.Rows[index].Cells[0].Value = val.Name;
            dgvVars.Rows[index].Cells[1].Value = val.DataType.ToString();
            if (val.DataType == DataType.Other || val.DataType == DataType.CLASS)
            {
                dgvVars.Rows[index].Cells[3].ReadOnly = true;
                dgvVars.Rows[index].Cells[4].ReadOnly = true;
            }

            dgvVars.Rows[index].Cells[2].Value = val.Permission.ToString();
            dgvVars.Rows[index].Cells[5].Value = val.ReadMode.ToString();
            dgvVars.Rows[index].Cells[6].Value = val.IsEventNotify;
        }
        /// <summary>界面更新</summary>
        /// <param name="valName">名称</param>
        /// <param name="obj">内容</param>
        public void UpdateVariableValue(string valName, object obj)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, object>(UpdateVariableValue), valName, obj);
            }
            else
            {
                for (var i = 0; i < dgvVars.Rows.Count; i++)
                {
                    if (dgvVars.Rows[i].Cells[0].Value.ToString() == valName)
                    {
                        dgvVars.Rows[i].Cells[3].Value = obj;
                        break;
                    }
                }
                dgvVars.Refresh();
            }
        }
        /// <summary>连接状态设置</summary>
        /// <param name="conn">连接状态</param>
        internal void SetPrimConnState(PrimConnState conn)
        {
            if (tbConnState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), conn);
            }
            else
            {
                switch (conn)
                {
                    case PrimConnState.UnConnected:
                        tbConnState.BackColor = Color.Khaki;
                        tbConnState.Text = @"UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnRun.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.Enabled = true;
                        break;
                    case PrimConnState.Connected:
                        tbConnState.BackColor = Color.LightGreen;
                        tbConnState.Text = @"Connected";
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        break;
                    case PrimConnState.Other:
                        tbConnState.BackColor = Color.Khaki;
                        tbConnState.Text = @"UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnRun.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.Enabled = true;
                        break;
                }
            }
        }
        /// <summary>运行状态设置</summary>
        /// <param name="run">运行状态</param>
        internal void SetPrimRunState(PrimRunState run)
        {
            if (tbRunState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), run);
            }
            else
            {
                switch (run)
                {
                    case PrimRunState.Idle:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = @"Idle";
                        break;
                    case PrimRunState.Running:
                        tbRunState.BackColor = Color.LightGreen;
                        tbRunState.Text = @"Running";
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Stop:
                        tbRunState.BackColor = Color.Brown;
                        tbRunState.Text = @"Stop";
                        btnRun.BackColor = Color.LightGreen;
                        btnRun.Enabled = true;
                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                    case PrimRunState.Err:
                        tbRunState.BackColor = Color.SandyBrown;
                        tbRunState.Text = @"Err";
                        break;
                    case PrimRunState.Other:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = @"Idle";
                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }
        #endregion
    }
}