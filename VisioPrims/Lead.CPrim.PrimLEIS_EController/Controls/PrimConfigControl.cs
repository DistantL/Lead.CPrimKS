using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.PrimLESI_EController.Controls;
using Lead.CPrim.ProxyTools;
//using Microsoft.Office.Interop.PowerPoint;

namespace Lead.CPrim.PrimLESI_EController
{
    public partial class PrimConfigControl : UserControl
    {
        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Field
        /// <summary>雷赛控制器管理器</summary>
        private PrimLESI_EController _prim;
        /// <summary>自定义定时器</summary>
        private System.Timers.Timer _timer1;
        /// <summary>IO管理器</summary>
        private IOInfos _infos = null;

        private IOControl _diControlForm;
        private IOControl _doControlForm;


        #endregion


        #region Ctor
        /// <summary>Ctor无参</summary>
        public PrimConfigControl()
        {
            InitializeComponent();
            InitializeUI();
        }
        /// <summary>Ctor有一个参数</summary>
        public PrimConfigControl(PrimLESI_EController prim)
        {
            InitializeComponent();
            InitializeUI();
            _prim = prim;
            if (File.Exists(_prim.IOInfosFilePath))
                tbIOInfosPath.Text = _prim.IOInfosFilePath;

            if (File.Exists(_prim.EBusConfigFilePath))
                tbEBusConfigPath.Text = _prim.EBusConfigFilePath;

            _infos = _prim?.IoInfos ?? new IOInfos();

            CalcCount();
        }
        #endregion



        //*****************************************************************************
        #region System_Event_Son
        /// <summary>自定义定时器</summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_prim != null && _prim.PrimRunStat == PrimRunState.Running && _prim.ExtraEncoderEnable)
            {
                Invoke(new Action(() =>
                {
                    tbExtraEncoderPos.Text = _prim.Axises[5000].ActualPos.ToString();
                }));
            }
        }
        #endregion


        #region System_Event
        /// <summary>Load事件</summary>
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            btnClearConfig.Enabled = false;
            btnConnect.Enabled = false;

            tbCardId.Text = _prim.DevIndex.ToString();
            tbControllerName.Text = _prim.Name;

            tPageCmpTrig.Parent = null;
            tPageContinueMove.Parent = null;
            tPageIO.Parent = null;
            tPageInterrupt.Parent = null;
            tPageLatch.Parent = null;
            tPageTrigDemo.Parent = null;

            tbIpAddress.Text = _prim.IpAddress;
            ckbCheckError.Checked = _prim.CheckEBusError;
            cbOnLineChangeSpeed.Checked = _prim.OnLineChangeSpeed;

            chkLogEnable.Checked = _prim.LogEnable;

            chkCycleScanEnable.Checked = _prim.CycleScanEnable;
            tbCycleScanTime.Text = _prim.CycleScanTime.ToString();

            chkDecStopEnable.Checked = _prim.DecStopEnable;
            tbDecStopTime.Text = _prim.DecStopTime.ToString();

            chkExtraEncoderEnable.Checked = _prim.ExtraEncoderEnable;
            cmbExtraEncoderInmode.SelectedIndex = _prim.ExtraEncoderInMode;
            cmbExtraEncoderMulti.SelectedIndex = _prim.ExternEncoderMulti;

            _prim.ImportEBusConfig();
            _prim.ImportIoInfos();
            UpdateConfigControls();
            //刷新节点内容ToolStripMenuItem_Click(null, null);

            _timer1 = new System.Timers.Timer(100);
            _timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            _timer1.AutoReset = true;
            _timer1.Enabled = _prim.ExtraEncoderEnable;
        }
        #endregion



        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region Button_Event
        /// <summary>CardId进行切换</summary>
        private void tbCardId_TextChanged(object sender, EventArgs e)
        {
            _prim.DevIndex = int.TryParse(tbCardId.Text, out var index) ? index : 0;
        }
        /// <summary>EBus Config路径选择</summary>
        private void btnBrowerEBusConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEBusConfigPath.Text))
            {
                if (saveEBusConfigFile.ShowDialog() == DialogResult.OK)
                {
                    tbEBusConfigPath.Text = saveEBusConfigFile.FileName;
                    _prim.EBusConfigFilePath = tbEBusConfigPath.Text;
                }
            }
            else
            {
                openEBusConfigFile.InitialDirectory = Path.GetDirectoryName(tbEBusConfigPath.Text);
                if (openEBusConfigFile.ShowDialog() == DialogResult.OK)
                {
                    tbEBusConfigPath.Text = openEBusConfigFile.FileName;
                    if (!File.Exists(tbEBusConfigPath.Text))
                    {
                        MessageBox.Show($@"文件{tbEBusConfigPath.Text} 不存在");
                        return;
                    }
                    _prim.EBusConfigFilePath = tbEBusConfigPath.Text;
                }
            }
            BtnApply_Click(null, null);
        }
        /// <summary>EBus Config加载</summary>
        private void btnLoadEbusConfig_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbEBusConfigPath.Text))
            {
                _prim.ImportEBusConfig();
                UpdateConfigControls();
            }
            else
            {
                MessageBox.Show(tbEBusConfigPath.Text + $@"文件不存在，请重新选择配置文件");
                var dialog = new OpenFileDialog();
                dialog.Filter = "JSON File (*.json)|*.json|All Files (*.*)|*.*";
                dialog.InitialDirectory = "D:";
                dialog.Title = "选择配置文件";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _prim.EBusConfigFilePath = dialog.FileName;
                    tbEBusConfigPath.Text = dialog.FileName;
                    _prim.ImportEBusConfig();
                    UpdateConfigControls();
                }
            }
        }
        /// <summary>IO Infos路径选择</summary>
        private void btnBrowserInfoInfos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbIOInfosPath.Text))
            {
                if (saveIOInfosFile.ShowDialog() == DialogResult.OK)
                {
                    tbIOInfosPath.Text = saveIOInfosFile.FileName;
                    _prim.IOInfosFilePath = tbIOInfosPath.Text;
                }
            }
            else
            {
                openIOInfosFile.InitialDirectory = Path.GetDirectoryName(tbIOInfosPath.Text);
                if (openIOInfosFile.ShowDialog() == DialogResult.OK)
                {
                    tbIOInfosPath.Text = openIOInfosFile.FileName;
                    if (!File.Exists(tbIOInfosPath.Text))
                    {
                        MessageBox.Show($@"文件{tbIOInfosPath.Text} 不存在");
                        return;
                    }
                    _prim.IOInfosFilePath = tbIOInfosPath.Text;
                }
            }
            BtnApply_Click(null, null);
        }
        /// <summary>IoInfos加载</summary>
        private void btnLoadIoInfos_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbIOInfosPath.Text))
            {
                _prim.ImportIoInfos();
                UpdateConfigControls();
            }
            else
            {
                MessageBox.Show(tbEBusConfigPath.Text + $@"文件不存在，请重新选择配置文件");
                var dialog = new OpenFileDialog();
                dialog.Filter = "JSON File (*.json)|*.json|All Files (*.*)|*.*";
                dialog.InitialDirectory = "D:";
                dialog.Title = "选择配置文件";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _prim.IOInfosFilePath = dialog.FileName;
                    tbIOInfosPath.Text = dialog.FileName;
                    _prim.ImportIoInfos();
                    UpdateConfigControls();
                }
            }
        }
        /// <summary>初始化</summary>
        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_prim == null)
                return;

            _prim.IPrimInit();
        }
        /// <summary>启动</summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_prim == null)
                return;

            _prim.IPrimStart();
        }
        /// <summary>停止</summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_prim == null)
            {
                return;
            }

            _prim.IPrimStop();
            Thread.Sleep(50);
            _prim.IPrimDispose();
        }
        /// <summary>应用</summary>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prim == null)
                    return;

                _prim.Name = tbControllerName.Text;
                if (int.TryParse(tbCardId.ToString(), out var id))
                    _prim.DevIndex = id;

                if (_prim.PrimRunStat == PrimRunState.Running)
                    throw new Exception("请先将当前基元切换至非运行状态。");

                if (chkConfigMode.Checked)
                    throw new Exception("请先退出配置模式。");

                CalcCount();
                ReloadIoInfos();
                _prim.IoInfos.Di.Sort((x, y) => x.Address.CompareTo(y.Address));
                _prim.IoInfos.Do.Sort((x, y) => x.Address.CompareTo(y.Address));
                _prim.IoInfos.Ai.Sort((x, y) => x.Address.CompareTo(y.Address));
                _prim.IoInfos.Ao.Sort((x, y) => x.Address.CompareTo(y.Address));
                _prim.ExportEBusConfig();
                _prim.ExportIoInfos();
                _diControlForm?.ReloadControls();
                _doControlForm?.ReloadControls();

                _prim.IpAddress = tbIpAddress.Text;
                _prim.CheckEBusError = ckbCheckError.Checked;
                _prim.OnLineChangeSpeed = cbOnLineChangeSpeed.Checked;

                _prim.CycleScanEnable = chkCycleScanEnable.Checked;
                _prim.CycleScanTime = int.TryParse(tbCycleScanTime.Text, out var time) ? time : 5;
                _prim.LogEnable = chkLogEnable.Checked;

                _prim.DecStopEnable = chkDecStopEnable.Checked;
                _prim.DecStopTime = double.TryParse(tbDecStopTime.Text, out var decResult) ? decResult : 0.1;

                _prim.ExtraEncoderEnable = chkExtraEncoderEnable.Checked;
                _prim.ExtraEncoderInMode = cmbExtraEncoderInmode.SelectedIndex;
                _prim.ExternEncoderMulti = cmbExtraEncoderMulti.SelectedIndex;
                _prim.LogAdd("应用成功", LogLevel.Trace);
            }
            catch (Exception ex)
            {
                _prim.LogAdd($"应用失败：{ex.Message}", LogLevel.Trace);
            }
        }
        /// <summary>清除配置</summary>
        private void BtnClearConfig_Click(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || !chkConfigMode.Checked) return;

            if (MessageBox.Show($@"确定要清除当前所有配置吗？", $@"警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            _diControlForm.TmrStop();
            _doControlForm.TmrStop();

            _prim.Axises.Clear();
            _prim.DiModules.Clear();
            _prim.DoModules.Clear();
            _prim.AiModules.Clear();
            _prim.AoModules.Clear();
            _infos.Di.RemoveAll(p => p.PrimName == _prim.Name);
            _infos.Do.RemoveAll(p => p.PrimName == _prim.Name);
            _infos.Ai.RemoveAll(p => p.PrimName == _prim.Name);
            _infos.Ao.RemoveAll(p => p.PrimName == _prim.Name);
            tbTotalSlaveNum.Text = "";
            tbTotalAxisNum.Text = "";
            tbTotalDiModuleNum.Text = "";
            tbTotalDoModuleNum.Text = "";
            tbTotalAiModuleNum.Text = "";
            tbTotalAoModuleNum.Text = "";
            CalcCount();
            ReloadIoInfos();
        }
        /// <summary>配置模式</summary>
        private void CheckConfigMode_CheckedChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running)
            {
                MessageBox.Show($@"请先确保当前基元不在运行状态");
                return;
            }

            if (chkConfigMode.Checked)
            {
                var ret = MessageBox.Show($@"请确保要进行总线配置吗？这可能会清除当前配置。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ret != DialogResult.Yes)
                {
                    chkConfigMode.Checked = false;
                    return;
                }

                _diControlForm?.TmrStop();
                _doControlForm?.TmrStop();

                _diControlForm?.ClearControls();
                _doControlForm?.ClearControls();

                _diControlForm?.Hide();
                _doControlForm?.Hide();

                btnClearConfig.Enabled = true;
                btnConnect.Enabled = true;
            }
            else
            {
                btnClearConfig.Enabled = false;
                btnConnect.Enabled = false;
                CalcCount();
                ReloadIoInfos();
            }
        }
        /// <summary>初始化连接</summary>
        private void BbtnConnect_Click(object sender, EventArgs e)
        {
            if (_prim == null || !chkConfigMode.Checked) return;

            if (MessageBox.Show($@"你确定要重新扫描EtherCAT从站设备吗？", $@"提示", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            tbTotalSlaveNum.Text = "-1";
            if (_prim.FirstScanField() != 0) return;

            tbTotalSlaveNum.Text = _prim.TotalSlaveNum.ToString();
            tbTotalAxisNum.Text = _prim.TotalAxisNum.ToString();
            UpdateNodesConfig();
        }
        /// <summary>刷新节点内容</summary>
        private void 刷新节点内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chkConfigMode.Checked)
            {
                UpdateModuleAddress();
                GetNodesInfo();
                _prim.UpdateAxisesAndModules();
                CalcCount();
            }
        }
        /// <summary>删除节点内容</summary>
        private void 删除节点数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!chkConfigMode.Checked || dgvEbusInfo.Rows.Count <= 0 || dgvEbusInfo.SelectedRows.Count <= 0) return;
            foreach (DataGridViewRow row in dgvEbusInfo.SelectedRows)
                dgvEbusInfo.Rows.Remove(row);
        }
        /// <summary>清除表格内容</summary>
        private void 清除表格内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!chkConfigMode.Checked) return;

            while (dgvEbusInfo.Rows.Count != 0)
            {
                dgvEbusInfo.Rows.RemoveAt(0);
            }
        }
        /// <summary>粘贴数据</summary>
        private void 粘贴数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!chkConfigMode.Checked) return;
            清除表格内容ToolStripMenuItem_Click(null, null);
            ControlHelper.DgvPaste(ref dgvEbusInfo);
            GetNodesInfo();
            _prim.UpdateAxisesAndModules();
            CalcCount();
        }
        /// <summary>清除报警</summary>
        private void btnClearError_Click(object sender, EventArgs e)
        {
            _prim.IPrimReset();
        }
        /// <summary>辅助编码器设置当前位置</summary>
        private void btnSetExtraEncoderPos_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbExtraEncoderPos.Text, out var setPosition))
            {
                _prim.SetAxisPositionAndFeedbackPulse(5000, setPosition);
            }
        }
        /// <summary>辅助编码器启用</summary>
        private void chkExtraEncoderEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtraEncoderEnable.Checked)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    _timer1?.Start();
                }));
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    _timer1?.Stop();
                }));
            }
        }
        #endregion



        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************
        #region UI更新
        /// <summary>界面刷新（包含了CalcCount方法）（模块数量/配置表）</summary>
        private void UpdateConfigControls()
        {
            if (!Created || !IsHandleCreated)
                return;

            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdateConfigControls));
            }
            else
            {
                if (_prim == null)
                    return;

                UpdateNodesConfig();
                CalcCount();
            }
        }
        /// <summary>界面刷新（模块数量）</summary>
        private void CalcCount()
        {
            tbTotalSlaveNum.Text = _prim.TotalSlaveNum.ToString();
            tbTotalAxisNum.Text = _prim.TotalAxisNum.ToString();
            tbTotalDiModuleNum.Text = _prim.TotalDiModuleNum.ToString();
            tbTotalDoModuleNum.Text = _prim.TotalDoModuleNum.ToString();
            tbTotalAiModuleNum.Text = _prim.TotalAiModuleNum.ToString();
            tbTotalAoModuleNum.Text = _prim.TotalAoModuleNum.ToString();
        }
        /// <summary>界面刷新（配置表）</summary>
        private void UpdateNodesConfig()
        {
            dgvEbusInfo.Rows.Clear();
            if (_prim == null)
                return;

            if (_prim.Nodes == null || _prim.Nodes.Count < 1)
                return;

            foreach (var node in _prim.Nodes)
            {
                var rowIndex = dgvEbusInfo.Rows.Add();
                dgvEbusInfo.Rows[rowIndex].Cells[0].Value = node.NodeID;
                dgvEbusInfo.Rows[rowIndex].Cells[1].Value = node.NodeType.ToString();
                dgvEbusInfo.Rows[rowIndex].Cells[2].Value = node.InputCount;
                dgvEbusInfo.Rows[rowIndex].Cells[3].Value = node.InAddress;
                dgvEbusInfo.Rows[rowIndex].Cells[4].Value = node.OutputCount;
                dgvEbusInfo.Rows[rowIndex].Cells[5].Value = node.OutAddress;
                dgvEbusInfo.Rows[rowIndex].Cells[6].Value = node.AxisId;
                dgvEbusInfo.Rows[rowIndex].Cells[7].Value = node.AxisType.ToString();
                dgvEbusInfo.Rows[rowIndex].Cells[8].Value = node.ScanEnable;
            }
        }
        /// <summary>连接状态设置</summary>
        public void SetPrimConnState(PrimConnState state)
        {
            if (!IsHandleCreated || !Created)
                return;

            if (tBoxConnState.InvokeRequired)
            {
                tBoxConnState.BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnLatchStart.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnLatchStart.Enabled = true;
                        break;
                    case PrimConnState.Connected:
                        tBoxConnState.BackColor = Color.LightGreen;
                        tBoxConnState.Text = "Connected";
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        break;
                    case PrimConnState.Other:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnLatchStart.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnLatchStart.Enabled = true;
                        break;
                }
            }
        }
        /// <summary>设置运行状态</summary>
        public void SetPrimRunState(PrimRunState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }

            if (tBoxRunState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = "Idle";
                        break;
                    case PrimRunState.Running:
                        tBoxRunState.BackColor = Color.LightGreen;
                        tBoxRunState.Text = "Running";
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Stop:
                        tBoxRunState.BackColor = Color.Brown;
                        tBoxRunState.Text = "Stop";
                        btnRun.BackColor = Color.LightGreen;
                        btnRun.Enabled = true;
                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                    case PrimRunState.Err:
                        tBoxRunState.BackColor = Color.SandyBrown;
                        tBoxRunState.Text = "Err";
                        break;
                    case PrimRunState.Other:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = "Idle";
                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }
        #endregion



        #region dgvEbusInfo_Event
        /// <summary>单击单元格时发生（调试界面按钮）</summary>
        private void dgvEbusInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;
            if (columnIndex != 9) return;

            var row = dgvEbusInfo.Rows[rowIndex];
            var nodeType = GetValue<EcatNodeType>(row.Cells[1].Value.ToString());
            ushort axisId = 0;
            if (row.Cells[6].Value != null && ushort.TryParse(row.Cells[6].Value.ToString(), out var id))
                axisId = id;

            if (nodeType == EcatNodeType.DI)
            {
                if (_prim == null || _diControlForm == null || _diControlForm.IsDisposed)
                {
                    _diControlForm = new IOControl(ControlEnum.IOType.DI, _prim);
                    _diControlForm.Show();
                }
                else
                {
                    _diControlForm.TopMost = true;
                    _diControlForm.Visible = true;
                    _diControlForm.Activate();
                    if (_diControlForm.WindowState == FormWindowState.Minimized)
                        _diControlForm.WindowState = FormWindowState.Normal;
                }
                _diControlForm.TmrStart();
            }

            if (nodeType == EcatNodeType.DO)
            {
                if (_prim == null || _doControlForm == null || _doControlForm.IsDisposed)
                {
                    _doControlForm = new IOControl(ControlEnum.IOType.DO, _prim);
                    _doControlForm.Show();
                }
                else
                {
                    _doControlForm.TopMost = true;
                    _doControlForm.Visible = true;
                    _doControlForm.Activate();
                    if (_doControlForm.WindowState == FormWindowState.Minimized)
                        _doControlForm.WindowState = FormWindowState.Normal;
                }
                _doControlForm.TmrStart();
            }

            if (nodeType == EcatNodeType.Axis)
            {
                if (_prim != null && _prim.Axises != null && _prim.Axises.ContainsKey(axisId))
                {
                    var axisControlForm = new AxisControl(_prim, _prim.Axises[axisId]);
                    axisControlForm.Show();
                }
            }
        }
        /// <summary>当单元格收到输入焦点发生（实现单击一次显示下拉列表框）</summary>
        private void dgvEbusInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEbusInfo.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
                SendKeys.Send("{F4}");
        }
        /// <summary>外部数据分析或验证操作引发异常时发生（未实现）</summary>
        private void dgvEbusInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //
        }
        /// <summary>显示用于编辑单元格的控件时发生（保存当前的事件源。为了触发事件后。在取消）</summary>
        private void dgvEbusInfo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvEbusInfo.CurrentCell.OwningColumn.Name == "colType" && dgvEbusInfo.CurrentCell.RowIndex != -1)
            {
                var cbo = e.Control as ComboBox;
                if (cbo != null)
                    cbo.SelectedIndexChanged += new EventHandler(cbo_SelectedIndexChanged);
            }
        }
        /// <summary>在首次按下某个键时发生（复制与粘贴）</summary>
        private void dgvEbusInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                dgvEbusInfo.Copy();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                ControlHelper.DgvPaste(ref dgvEbusInfo);
            }
        }
        #endregion



        #region Other
        /// <summary>刷新节点内容_IO模块地址更新</summary>
        private void UpdateModuleAddress()
        {
            var rowIndex = 0;
            var startDiAddress = 100;
            var startDoAddress = 100;
            var startAiAddress = 100;
            var startAoAddress = 100;

            do
            {
                var row = dgvEbusInfo.Rows[rowIndex];
                for (var j = 0; j < row.Cells.Count; j++)
                    if (row.Cells[j].Value == null)
                        row.Cells[j].Value = 0;

                //节点号
                var nodeId = Convert.ToUInt16(row.Cells[0].Value);
                //节点类型
                var selectedNodeType = GetValue<EcatNodeType>(row.Cells[1].Value.ToString());
                //输入个数
                var inputCount = Convert.ToUInt16(row.Cells[2].Value);
                //输出个数
                var outputCount = Convert.ToUInt16(row.Cells[4].Value);

                bool isDICal = false;
                bool isDOCal = false;
                bool isAICal = false;
                bool isAOCal = false;

                //如果是耦合器
                if (selectedNodeType == EcatNodeType.Coupler_A || selectedNodeType == EcatNodeType.Coupler_B || selectedNodeType == EcatNodeType.Coupler_C)
                {
                    //总的模块个数
                    var moduleCount = inputCount + outputCount;

                    //耦合器附属模块地址分配
                    for (var i = 0; i < moduleCount; i++)
                    {
                        //下一行
                        var newRowIndex = rowIndex + 1 + i;
                        if (newRowIndex >= dgvEbusInfo.Rows.Count) continue;

                        var newRow = dgvEbusInfo.Rows[newRowIndex];
                        var newSelectedNodeType = GetValue<EcatNodeType>(newRow.Cells[1].Value.ToString());
                        switch (newSelectedNodeType)
                        {
                            case EcatNodeType.DI:
                                newRow.Cells[3].Value = startDiAddress++;
                                newRow.Cells[5].Value = 0;
                                isDICal = true;
                                break;
                            case EcatNodeType.DO:
                                newRow.Cells[5].Value = startDoAddress++;
                                newRow.Cells[3].Value = 0;
                                isDOCal = true;
                                break;
                            case EcatNodeType.AI:
                                newRow.Cells[3].Value = startAiAddress++;
                                newRow.Cells[5].Value = 0;
                                isAICal = true;
                                break;
                            case EcatNodeType.AO:
                                newRow.Cells[5].Value = startAoAddress++;
                                newRow.Cells[3].Value = 0;
                                isAOCal = true;
                                break;
                            default:
                                break;
                        }
                    }

                    rowIndex += moduleCount;    //将dgv行数重新赋值

                    #region 将地址设置为整数
                    if (isDICal)
                    {
                        startDiAddress += 100;
                        startDiAddress = startDiAddress - startDiAddress % 100;
                    }
                    if (isDOCal)
                    {
                        startDoAddress += 100;
                        startDoAddress = startDoAddress - startDoAddress % 100;
                    }
                    if (isAICal)
                    {
                        startAiAddress += 100;
                        startAiAddress = startAiAddress - startAiAddress % 100;
                    }
                    if (isAOCal)
                    {
                        startAoAddress += 100;
                        startAoAddress = startAoAddress - startAoAddress % 100;
                    }
                    #endregion
                    continue;
                }
                rowIndex++;
            } while (rowIndex < dgvEbusInfo.Rows.Count);
        }
        /// <summary>配置表数据集合更新</summary>
        private void GetNodesInfo()
        {
            _prim.Nodes = new List<EcatNode>();
            for (var i = 0; i < dgvEbusInfo.Rows.Count; i++)
            {
                var row = dgvEbusInfo.Rows[i];
                var newNode = new EcatNode
                {
                    NodeID = Convert.ToUInt16(row.Cells[0].Value),
                    NodeType = GetValue<EcatNodeType>(row.Cells[1].Value.ToString()),
                    InputCount = Convert.ToUInt16(row.Cells[2].Value),
                    InAddress = Convert.ToUInt16(row.Cells[3].Value),
                    OutputCount = Convert.ToUInt16(row.Cells[4].Value),
                    OutAddress = Convert.ToUInt16(row.Cells[5].Value),
                    AxisId = Convert.ToUInt16(row.Cells[6].Value),
                    AxisType = GetValue<EcatAxisType>(row.Cells[7].Value.ToString()),
                    ScanEnable = Convert.ToBoolean(row.Cells[8].Value),
                };
                _prim.Nodes.Add(newNode);
            }
        }
        /// <summary>字符串→枚举</summary>
        public T GetValue<T>(string value) where T : struct
        {
            T result;
            if (Enum.TryParse(value, true, out result))
                return result;
            return new T();
        }
        /// <summary>耦合器B或耦合器C时插入指定数量的行</summary>
        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;

            if (dgvEbusInfo.CurrentCell == null)
            {
                combox.SelectedIndexChanged -= new EventHandler(cbo_SelectedIndexChanged);
                return;
            }
            var rowIndex = dgvEbusInfo.CurrentCell.RowIndex;
            var columnIndex = dgvEbusInfo.CurrentCell.ColumnIndex;
            var curRow = dgvEbusInfo.Rows[rowIndex];
            var curNodeId = Convert.ToUInt16(curRow.Cells[0].Value);
            //打开节点类型下拉列表
            if (columnIndex == 1)
            {
                var selectNodeType = GetValue<EcatNodeType>(dgvEbusInfo.CurrentCell.Value.ToString());
                if (selectNodeType == EcatNodeType.Coupler_A)    //耦合器A，模块占用节点方式
                {
                    //将定义为该耦合器节点的行删除
                    //for (var i = rowIndex + 1; i < dgvEbusInfo.Rows.Count; i++)
                    //{
                    //    var nodeId = Convert.ToUInt16(dgvEbusInfo.Rows[i].Cells[0].Value);
                    //    if (nodeId == curNodeId)
                    //    {
                    //        dgvEbusInfo.Rows.RemoveAt(i);
                    //    }
                    //}
                }

                //耦合器B或耦合器C，模块不占用节点方式，则需按模块数量新增行
                if (selectNodeType == EcatNodeType.Coupler_B || selectNodeType == EcatNodeType.Coupler_C)
                {
                    var inputModuleCount = Convert.ToInt32(curRow.Cells[2].Value);
                    var outputModuleCount = Convert.ToInt32(curRow.Cells[4].Value);
                    var moduleCount = inputModuleCount + outputModuleCount;

                    //用于检查是否已经添加指定数量的行
                    var addedRowCount = 0;
                    for (var i = 0; i < moduleCount; i++)
                    {
                        if (dgvEbusInfo.Rows.Count <= rowIndex + i + 1) break;

                        var nodeId = Convert.ToUInt16(dgvEbusInfo.Rows[rowIndex + i + 1].Cells[0].Value);
                        //与耦合器节点地址一致，则认为已添加该模块
                        if (nodeId == curNodeId) addedRowCount++;
                    }

                    for (var i = 0; i < moduleCount - addedRowCount; i++)
                    {
                        //配置表插入
                        dgvEbusInfo.Rows.Insert(rowIndex + i + 1, new DataGridViewRow());

                        var addedNewRowIndex = rowIndex + i + 1;
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[0].Value = curNodeId;
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[1].Value = EcatNodeType.Other.ToString();
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[2].Value = 0;
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[3].Value = 0;
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[4].Value = 0;
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[5].Value = 0;
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[6].Value = 0;
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[7].Value = EcatAxisType.Other.ToString();
                        dgvEbusInfo.Rows[addedNewRowIndex].Cells[8].Value = true;
                    }
                }
            }
            combox.SelectedIndexChanged -= new EventHandler(cbo_SelectedIndexChanged);
        }
        /// <summary>IOInfos更新</summary>
        private void ReloadIoInfos()
        {
            if (_infos == null) return;

            _infos.Di.RemoveAll(p => p.PrimName == _prim.Name);

            foreach (var diModule in _prim.DiModules)
            {
                for (var i = 0; i < diModule.Value.Num; i++)
                {
                    var diInfo = new IOInfo(_prim.Name, diModule.Key + 0.01 * i, "");
                    _infos.Di.Add(diInfo);
                }
            }

            _infos.Do.RemoveAll(p => p.PrimName == _prim.Name);

            foreach (var doModule in _prim.DoModules)
            {
                for (var i = 0; i < doModule.Value.Num; i++)
                {
                    var doInfo = new IOInfo(_prim.Name, doModule.Key + 0.01 * i, "");
                    _infos.Do.Add(doInfo);
                }
            }

            _infos.Ai.RemoveAll(p => p.PrimName == _prim.Name);

            foreach (var aiModule in _prim.AiModules)
            {
                for (var i = 0; i < aiModule.Value.Num; i++)
                {
                    var aiInfo = new IOInfo(_prim.Name, aiModule.Key + 0.01 * i, "");
                    _infos.Ai.Add(aiInfo);
                }
            }

            _infos.Ao.RemoveAll(p => p.PrimName == _prim.Name);

            foreach (var aoModule in _prim.AoModules)
            {
                for (var i = 0; i < aoModule.Value.Num; i++)
                {
                    var aoInfo = new IOInfo(_prim.Name, aoModule.Key + 0.01 * i, "");
                    _infos.Ao.Add(aoInfo);
                }
            }
            _prim.IoInfos = _infos;
        }
        /// <summary>英汉互译</summary>
        private void InitializeUI()
        {
            label1.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_CardID", "Card Id:");
            label3.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_EBusConfigPath", "EBus Config Path:");
            label34.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_IOInfoPath", "IO Infos Path:");
            btnLoadEbusConfig.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Load", "Load");
            btnLoadIoInfos.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Load", "Load");
            btnInit.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Initialize", "Init");
            btnRun.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Run", "Run");
            btnStop.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Stop", "Stop");
            btnApply.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Apply", "Apply");
            tPageConfig.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Config", "Config");
            tPageIO.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_IO", "IO");
            tPageContinueMove.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ContinueMove", "ContinueMove");
            tPageCmpTrig.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_CmpTrig", "CmpTrig");
            tPageInterrupt.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Interrupt", "Interrupt");
            tPageLatch.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Latch", "Latch");
            tPageTrigDemo.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_TrigDemo", "TrigDemo");
            groupFieldBUSInfo.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_FieldBusInfo", "Field BUS Info");
            label12.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_FieldConnect", "Field Connect:");
            btnConnect.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_InitialConnect", "Initial Connect");
            label13.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SlaveCount", "Slave Count:");
            groupBox3.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SlaveInfo", "Slave Info");
            label9.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AxisCount", "Axis Count:");
            label_DINum.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DIModuleCount", "DI Module Count:");
            label7.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DOModuleCount", "DO Module Count:");
            label14.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AIModuleCount", "AI Module Count:");
            label11.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AoModuleCount", "AO Module Count:");
            chkConfigMode.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ConfigMode", "Config Mode");
            btnClearConfig.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ClearConfig", "Clear Config");

            label120.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_TwoAxisContinuousLinearMotion", "Two Axis Continuous Linear Motion(Point Table)：");
            btnLoadFromFile.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_LoadingCsvFormatFile", "Loading CSV format file");
            btnStartPt.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_LoadingPoints", "Loading points(delay time over 50)");
            button4.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_StartMotion", "Start motion");
            button3.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_StopMotion", "Stop motion");
            label109.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_MotionPointsCount", "Motion points count:");
            label114.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_BufFreeSpace", "BufFreeSpace:");
            label118.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_BufUsageSpace", "BufUsageSpace:");
            label108.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_RunningCnt", "RunningCnt:");

            label106.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_InterruptCount0", "Interrupt count 0:");
            label105.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_InterruptCount1", "Interrupt count 1:");
            label103.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_InterruptCount2", "Interrupt count 2:");
            label111.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_InterruptCount3", "Interrupt count 3:");
            label112.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_InterruptCount4", "Interrupt count 4:");
            label113.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_InterruptCount5", "Interrupt count 5:");
            btnSetInterrupt.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_SetDIInterrupt", "Set DI interrupt");
            btnDisableInterrupt.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_CloseInterrupt", "Close Interrupt");

            btnEnableLatch.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_OpenLatch", "Open latch");
            btnSetInt.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_OpenInterrupt", "Open interrupt");
            btnGetLantch.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_GetLatchedData", "Get latched data");
            btnLatchStart.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_MotionAndTrigger", "Motion & Trigger");

            label121.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_RunningCount", "Running count");
            buttonArc3.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_MotionStart", "Motion Start");
            btnToStart.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_StartPoint", "Start point");
            btnLineTrigTest.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_LinearTriggerTest", "Linear trigger test");
            checkBoxOnly1.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_OnlyToFirstParagraph", "Only to the first paragraph");
            button5.Text = ProxyTools.NLocalizer.GetString("PrimADLinkP_PrimConfigControl_RotateBackToZero", "Rotate back to zero");
        }
        #endregion
    }
}