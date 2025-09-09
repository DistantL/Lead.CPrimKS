using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.PrimADLink_E.Controls;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.PrimADLink_E
{
    public partial class PrimConfigControl : UserControl
    {
        #region Delegate
        private delegate void UpdateControls();

        private delegate void UpdateElement(ComboBox box);

        private delegate void UpdatePrimConnState(PrimConnState state);

        private delegate void UpdatePrimRunState(PrimRunState state);
        #endregion



        #region Field
        private IOControl _aiControlForm;

        private IOControl _aoControlForm;

        private Dictionary<int, AxisControl> _axisControlForms = new Dictionary<int, AxisControl>();

        private IOControl _diControlForm;

        private IOControl _doControlForm;

        private IOInfos _infos = null;

        private bool _numAiModuleTotalValueChanged = false;

        private bool _numAiModuleTotalValueChangedByCode = false;

        private bool _numAoModuleTotalValueChanged = false;

        private bool _numAoModuleTotalValueChangedByCode = false;

        private bool _numDiModuleTotalValueChanged = false;

        private bool _numDiModuleTotalValueChangedByCode = false;

        private bool _numDoModuleTotalValueChanged = false;

        private bool _numDoModuleTotalValueChangedByCode = false;

        private PrimADLink_E _prim;

        private EAxis SelectAxis;
        #endregion



        #region Ctor
        public PrimConfigControl()
        {
            InitializeComponent();
            InitializeUI();
        }
        public PrimConfigControl(PrimADLink_E prim)
        {
            InitializeComponent();
            InitializeUI();
            _prim = prim;
            if (File.Exists(_prim.IOInfosFilePath))
            {
                tbIOInfosPath.Text = _prim.IOInfosFilePath;
            }

            if (File.Exists(_prim.EBusConfigFilePath))
            {
                tbEBusConfigPath.Text = _prim.EBusConfigFilePath;
            }

            _infos = _prim?.IoInfos ?? new IOInfos();

            CalcCount();
            UpdateAxisConfig();

            chkCycleScanEnable.Checked = _prim.CycleScanEnable;
            tbCycleScanTime.Text = _prim.CycleScanTime.ToString();
        }
        #endregion



        #region System_Event
        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            cmbAxisType.Enabled = false;
            numDiModuleTotal.Enabled = false;
            cBoxDiModuleType.Enabled = false;
            numDoModuleTotal.Enabled = false;
            cBoxDoModuleType.Enabled = false;
            numAiModuleTotal.Enabled = false;
            cBoxAiModuleType.Enabled = false;
            numAoModuleTotal.Enabled = false;
            cBoxAoModuleType.Enabled = false;
            btnClearConfig.Enabled = false;
            btnConnect.Enabled = false;

            //轴类型更新
            cmbAxisType.Items.Clear();
            var types = Enum.GetNames(typeof(AxisType));
            foreach (var typ in types)
            {
                cmbAxisType.Items.Add(typ);
            }
            //卡号
            txtCardId.Text = _prim.DevIndex.ToString();
            //停止模式
            switch (_prim.StopMode)
            {
                case StopMode.Immediate:
                    cmbStopMode.SelectedIndex = 1;
                    break;
                case StopMode.Free:
                    cmbStopMode.SelectedIndex = 0;
                    break;
                case StopMode.Other:
                    cmbStopMode.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
            tBoxADLinkName.Text = _prim.Name;
            chkLog.Checked = _prim.LogEnable;

           var tPages = new TabPage[4] { tPageMiniCmp0, tPageMiniCmp1, tPageMiniCmp2, tPageMiniCmp3 };
            for (int i = 0; i < tPages.Length; i++)
            {
                _prim.MiniCmpModules[i].MiniCmpControl = new MiniCmpModuleControl(_prim, i);
                _prim.MiniCmpModules[i].MiniCmpControl.Dock = DockStyle.Fill;
                tPages[i].Controls.Add(_prim.MiniCmpModules[i].MiniCmpControl);
            }
        }
        #endregion



        #region Button_Event
        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_prim == null)
            {
                return;
            }

            _prim.IPrimInit();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_prim == null)
            {
                return;
            }

            _prim.IPrimStart();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_prim == null)
            {
                return;
            }

            _prim.IPrimStop();
        }
        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (_prim == null)
                {
                    return;
                }

                _prim.DevIndex = int.TryParse(txtCardId.Text, out var id) ? id : throw new Exception("卡号转换成INT失败");


                if (_prim.PrimRunStat == PrimRunState.Running)
                {
                    string errorText = NLocalizer.GetString("PrimADLinkE_PrimConfigControl_StopPrimFirst", "Stop running the primitive first.");
                    UIMessageTip.ShowWarning(errorText);
                    _prim.LogAdd(errorText, LogLevel.Warn);
                    return;
                }

                if (checkConfigMode.Checked)
                {
                    string errorText = NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ExitConfigurationMode", "Please exit configuration mode firstly.");
                    UIMessageTip.ShowWarning(errorText);
                    _prim.LogAdd(errorText, LogLevel.Warn);
                    return;
                }

                CalcCount();
                ReloadIoInfos();
                _prim.IoInfos.Di.Sort((x, y) => x.Address.CompareTo(y.Address));
                _prim.IoInfos.Do.Sort((x, y) => x.Address.CompareTo(y.Address));
                _prim.IoInfos.Ai.Sort((x, y) => x.Address.CompareTo(y.Address));
                _prim.IoInfos.Ao.Sort((x, y) => x.Address.CompareTo(y.Address));
                _prim.ExportEBusConfig();
                _prim.ExportIoInfos();
                _prim.SaveParamToFlash();
                _diControlForm?.ReloadControls();
                _doControlForm?.ReloadControls();
                _aiControlForm?.ReloadControls();
                _aoControlForm?.ReloadControls();

                foreach (var axis in _prim.Axises)
                {
                    if (_axisControlForms.ContainsKey(axis.Key))
                    {
                        _axisControlForms[axis.Key]?.ReloadControls();
                    }
                }

                _prim.CycleScanEnable = chkCycleScanEnable.Checked;
                _prim.CycleScanTime = int.TryParse(tbCycleScanTime.Text, out var time) ? time : 5;
                _prim.LogEnable = chkLog.Checked;

                switch (cmbStopMode.SelectedIndex)
                {
                    case 1:
                        _prim.StopMode = StopMode.Immediate;
                        break;
                    case 2:
                        _prim.StopMode = StopMode.Other;
                        break;
                    case 0:
                    default:
                        _prim.StopMode = StopMode.Free;
                        break;
                }
                _prim.LogAdd(_prim.Name + "保存成功", LogLevel.Trace);
            }
            catch (Exception ex)
            {
                _prim.LogAdd(_prim.Name + "保存失败" + ex.Message, LogLevel.Warn);
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>中英转换</summary>
        private void InitializeUI()
        {
            lbTitle.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ADLinkEConfig", "ADLinkE Config");
            label123.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ADLinkName", "ADLinkEName");
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
            checkConfigMode.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ConfigMode", "Config Mode");
            btnClearConfig.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ClearConfig", "Clear Config");
            groupSingleMove.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Axis", "Axis");
            label18.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SlaveNo", "Slave_No:");
            label17.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AxisID", "Axis_ID:");
            label29.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AxisType", "Axis_Type:");
            btnAxisControl.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AxisControl", "Axis Control");
            gBoxDiModule.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DiModule", "DiModule");
            label15.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SlaveNo", "Slave_No:");
            label30.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Count", "Count:");
            label16.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ID", "ID:");
            label19.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Type", "Type:");
            btnDiControl.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DIStatus", "DI Status");
            gBoxDoModule.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DoModule", "DoModule");
            label22.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SlaveNo", "Slave_No:");
            label21.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Count", "Count:");
            label33.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ID", "ID:");
            label20.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Type", "Type:");
            btnDoControl.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DoControl", "DO Control");
            gBoxAiModule.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AiModule", "AiModule");
            label28.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SlaveNo", "Slave_No:");
            label27.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Count", "Count:");
            label31.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ID", "ID:");
            label26.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Type", "Type:");
            btnAiControl.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AIStatus", "AI Status");
            gBoxAoModule.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AoModule", "AoModule");
            label25.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SlaveNo", "Slave_No:");
            label24.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Count", "Count:");
            label32.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ID", "ID:");
            label23.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Type", "Type:");
            btnAoControl.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_AOControl", "AO Control");

            grpDi.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_IsolatedInputDI", "Isolated input DI(0-3 connects terminal block through 100pin line and 8-23 connects terminal block via 37pin line)");
            grpDo.Text = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_IsolatedOutputDO", "Isolated output DO(0-3 connects terminal block through 100pin line and 8-23 connects terminal block via 37pin line)");

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
        /// <summary>总线信息更新</summary>
        private void CalcCount()
        {
            _prim.TotalAxisNum = _prim.Axises.Count;
            _prim.TotalDiModuleNum = _prim.DiModules.Count;
            _prim.TotalDoModuleNum = _prim.DoModules.Count;
            _prim.TotalAiModuleNum = _prim.AiModules.Count;
            _prim.TotalAoModuleNum = _prim.AoModules.Count;

            tBoxTotalSlaveNum.Text = _prim.TotalSlaveNum.ToString();
            tBoxTotalAxisNum.Text = _prim.TotalAxisNum.ToString();
            tBoxTotalDiModuleNum.Text = _prim.TotalDiModuleNum.ToString();
            tBoxTotalDoModuleNum.Text = _prim.TotalDoModuleNum.ToString();
            tBoxTotalAiModuleNum.Text = _prim.TotalAiModuleNum.ToString();
            tBoxTotalAoModuleNum.Text = _prim.TotalAoModuleNum.ToString();
        }
        private void UpdateAxisConfig()
        {
            cmbAxisSlaveNo.SelectedIndex = -1;
            cmbAxisSlaveNo.Items.Clear();
            cmbAxisId.SelectedIndex = -1;
            cmbAxisId.Items.Clear();
            cmbAxisType.SelectedIndex = -1;
            foreach (var axis in _prim.Axises)
            {
                cmbAxisSlaveNo.Items.Add(axis.Value.SlaveNo);
                cmbAxisId.Items.Add(axis.Value.Id);
            }
            if (_prim.Axises.Count <= 0)
            {
                SelectAxis = new EAxis();
                SelectAxis.Id = -1;
                SelectAxis.SlaveNo = -1;
            }
        }
        #endregion



        #region Controls event

        private void BbtnConnect_Click(object sender, EventArgs e)
        {
            if (_prim == null || !checkConfigMode.Checked)
            {
                return;
            }

            var ret = MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_RescanBusSlaveDevice", "Are you sure you want to re-scan bus slave devices?"), ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Tip", "Tip"), MessageBoxButtons.YesNo);

            if (ret != DialogResult.Yes)
            {
                return;
            }

            tBoxTotalSlaveNum.Text = "-1";
            if (_prim.FirstScanField() != 0)
            {
                return;
            }
            tBoxTotalSlaveNum.Text = _prim.TotalSlaveNum.ToString();
            tBoxTotalAxisNum.Text = _prim.TotalAxisNum.ToString();
            //UpdateConfigControls();
            UpdateAxisConfig();
        }


        private void BtnAxisControl_Click(object sender, EventArgs e)
        {
            if (_prim == null || _prim.Axises.Count == 0 || SelectAxis == null)
            {
                return;
            }

            if (_axisControlForms == null || !_axisControlForms.ContainsKey(SelectAxis.Id) || _axisControlForms[SelectAxis.Id].IsDisposed)
            {
                var formAxisControl = new AxisControl(_prim, SelectAxis);
                if (_axisControlForms.ContainsKey(SelectAxis.Id))
                {
                    _axisControlForms.Remove(SelectAxis.Id);
                }
                _axisControlForms.Add(SelectAxis.Id, formAxisControl);
                _axisControlForms[SelectAxis.Id].Show();
            }
            else
            {
                _axisControlForms[SelectAxis.Id].TopMost = true;
                _axisControlForms[SelectAxis.Id].Visible = true;
                _axisControlForms[SelectAxis.Id].Activate();
                if (_axisControlForms[SelectAxis.Id].WindowState == FormWindowState.Minimized)
                {
                    _axisControlForms[SelectAxis.Id].WindowState = FormWindowState.Normal;
                }
            }
            _axisControlForms[SelectAxis.Id].TmrStart();
        }

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

                    if (string.IsNullOrEmpty(tbEBusConfigPath.Text))
                    {
                        return;
                    }

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

                    if (string.IsNullOrEmpty(tbIOInfosPath.Text))
                    {
                        return;
                    }

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

        private void BtnClearConfig_Click(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || !checkConfigMode.Checked)
            {
                return;
            }

            _diControlForm.TmrStop();

            var ret = MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ClearAllBusConfiguration", "Are you sure to clear all bus configurations?"), ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret != DialogResult.Yes)
            {
                return;
            }

            _prim.Axises.Clear();
            _prim.DiModules.Clear();
            _prim.DoModules.Clear();
            _prim.AiModules.Clear();
            _prim.AoModules.Clear();
            _infos.Di.RemoveAll(p => p.PrimName == _prim.Name);
            _infos.Do.RemoveAll(p => p.PrimName == _prim.Name);
            _infos.Ai.RemoveAll(p => p.PrimName == _prim.Name);
            _infos.Ao.RemoveAll(p => p.PrimName == _prim.Name);
            tBoxTotalSlaveNum.Text = "";
            tBoxTotalAxisNum.Text = "";
            tBoxTotalDiModuleNum.Text = "";
            tBoxTotalDoModuleNum.Text = "";
            tBoxTotalAiModuleNum.Text = "";
            tBoxTotalAoModuleNum.Text = "";
            cmbAxisSlaveNo.SelectedIndex = -1;
            cmbAxisId.SelectedIndex = -1;
            cmbAxisType.SelectedIndex = -1;
            SelectAxis.Id = -1;
            SelectAxis.SlaveNo = -1;
            numDiModuleSlaveNo.Value = -1;
            numDiModuleTotal.Value = -1;
            cBoxDiModuleId.Items.Clear();
            cBoxDiModuleType.SelectedIndex = -1;
            numDoModuleSlaveNo.Value = -1;
            numDoModuleTotal.Value = -1;
            cBoxDoModuleId.Items.Clear();
            cBoxDoModuleType.SelectedIndex = -1;
            numAiModuleSlaveNo.Value = -1;
            numAiModuleTotal.Value = -1;
            cBoxAiModuleId.Items.Clear();
            cBoxAiModuleType.SelectedIndex = -1;
            numAoModuleSlaveNo.Value = -1;
            numAoModuleTotal.Value = -1;
            cBoxAoModuleId.Items.Clear();
            cBoxAoModuleType.SelectedIndex = -1;
            CalcCount();
            ReloadIoInfos();
        }

        private void btnLoadEbusConfig_Click(object sender, EventArgs e)
        {
            if (File.Exists(_prim.EBusConfigFilePath))
            {
                _prim.ImportEBusConfig();
                UpdateConfigControls();
            }
            else
            {
                MessageBox.Show(tbEBusConfigPath.Text + ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SelectXMLConfigurationFile", " does not exist, please select the XML configuration file."));
                var dialog = new OpenFileDialog();
                dialog.Filter = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DiaglogFormatFile", "JSON File (*.json)|*.json|All Files (*.*)|*.*");
                dialog.InitialDirectory = "D:";
                dialog.Title = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DialogTitle", "Select a JSON File");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _prim.EBusConfigFilePath = dialog.FileName;
                    tbEBusConfigPath.Text = dialog.FileName;
                }
            }
        }

        private void btnLoadIoInfos_Click(object sender, EventArgs e)
        {
            if (File.Exists(_prim.IOInfosFilePath))
            {
                _prim.ImportIoInfos();
                UpdateConfigControls();
            }
            else
            {
                MessageBox.Show(tbEBusConfigPath.Text + ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_SelectXMLConfigurationFile", " does not exist, please select the XML configuration file."));
                var dialog = new OpenFileDialog();
                dialog.Filter = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DiaglogFormatFile", "JSON File (*.json)|*.json|All Files (*.*)|*.*");
                dialog.InitialDirectory = "D:";
                dialog.Title = ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_DialogTitle", "Select a JSON File");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _prim.EBusConfigFilePath = dialog.FileName;
                    tbEBusConfigPath.Text = dialog.FileName;
                }
            }
        }

        private void CmbAxisType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || SelectAxis == null || cmbAxisType.SelectedItem == null)
            {
                return;
            }

            SelectAxis.Type = Enum.TryParse(cmbAxisType.SelectedItem.ToString(), out AxisType typ) ? typ : AxisType.Other;
        }

        private void CheckConfigMode_CheckedChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ConfirmCurrentPrimNotRunning", "Please confirm that the current prim is not running."));
                return;
            }

            if (checkConfigMode.Checked)
            {
                var ret = MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ReconfigureParameters", "Are you sure to reconfigure the parameters? This may cause the original configuration parameters to be cleared."), ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_Warning", "Warning"), MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (ret != DialogResult.Yes)
                {
                    checkConfigMode.Checked = false;
                    return;
                }

                _diControlForm?.TmrStop();
                _doControlForm?.TmrStop();
                _aiControlForm?.TmrStop();
                _aoControlForm?.TmrStop();

                foreach (var axisForm in _axisControlForms)
                {
                    axisForm.Value?.TmrStop();
                    axisForm.Value?.Hide();
                }

                _diControlForm?.ClearControls();
                _doControlForm?.ClearControls();
                _aiControlForm?.ClearControls();
                _aoControlForm?.ClearControls();

                _diControlForm?.Hide();
                _doControlForm?.Hide();
                _aiControlForm?.Hide();
                _aoControlForm?.Hide();

                numDiModuleTotal.Enabled = true;
                cBoxDiModuleType.Enabled = true;
                numDoModuleTotal.Enabled = true;
                cBoxDoModuleType.Enabled = true;
                numAiModuleTotal.Enabled = true;
                cBoxAiModuleType.Enabled = true;
                numAoModuleTotal.Enabled = true;
                cBoxAoModuleType.Enabled = true;

                btnClearConfig.Enabled = true;
                btnConnect.Enabled = true;

                cmbAxisType.Enabled = true;
                cBoxDiModuleType.Enabled = true;
                cBoxDoModuleType.Enabled = true;
                cBoxAiModuleType.Enabled = true;
                cBoxAoModuleType.Enabled = true;
            }
            else
            {
                numDiModuleTotal.Enabled = false;
                cBoxDiModuleType.Enabled = true;
                numDoModuleTotal.Enabled = false;
                cBoxDoModuleType.Enabled = true;
                numAiModuleTotal.Enabled = false;
                cBoxAiModuleType.Enabled = true;
                numAoModuleTotal.Enabled = false;
                cBoxAoModuleType.Enabled = true;

                cmbAxisType.Enabled = false;
                cBoxDiModuleType.Enabled = false;
                cBoxDoModuleType.Enabled = false;
                cBoxAiModuleType.Enabled = false;
                cBoxAoModuleType.Enabled = false;

                btnClearConfig.Enabled = false;
                btnConnect.Enabled = false;
                CalcCount();
                ReloadIoInfos();
            }
        }

        private void CmbAxisId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || cmbAxisId.SelectedItem == null || !int.TryParse(s: cmbAxisId.SelectedItem.ToString(), result: out var id) || id == -1)
            {
                return;
            }

            SelectAxis = _prim.Axises.FirstOrDefault(p => p.Value.Id == id).Value;
            cmbAxisSlaveNo.SelectedItem = SelectAxis.SlaveNo;
            cmbAxisType.SelectedItem = SelectAxis.Type.ToString();
        }

        private void CmbAxisSlaveNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || cmbAxisSlaveNo.SelectedItem == null || !int.TryParse(s: cmbAxisSlaveNo.SelectedItem.ToString(), result: out var slaveNo) || slaveNo == -1)
            {
                return;
            }

            SelectAxis = _prim.Axises.FirstOrDefault(p => p.Value.SlaveNo == slaveNo).Value;
            cmbAxisId.SelectedItem = SelectAxis.Id;
            cmbAxisType.SelectedItem = SelectAxis.Type.ToString();
        }


        #endregion Controls event

        #region DiModules

        private void BtnDiControl_Click(object sender, EventArgs e)
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
                {
                    _diControlForm.WindowState = FormWindowState.Normal;
                }
            }
            _diControlForm.TmrStart();
        }

        private void cBoxDiModuleId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || cBoxDiModuleId.SelectedItem == null || string.IsNullOrEmpty(cBoxDiModuleId.SelectedItem.ToString()))
            {
                return;
            }

            cBoxDiModuleType.SelectedIndex = -1;

            foreach (var diModule in _prim.DiModules)
            {
                if (diModule.Value.SlaveNo == numDiModuleSlaveNo.Value &&
                    diModule.Value.Id == int.Parse(cBoxDiModuleId.SelectedItem.ToString()))
                {
                    cBoxDiModuleType.Enabled = true;
                    cBoxDiModuleType.SelectedItem = diModule.Value.TypeName;
                    break;
                }
            }

            if (!checkConfigMode.Checked)
            {
                cBoxDiModuleType.Enabled = false;
            }
        }

        private void CBoxDiModuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || cBoxDiModuleType.SelectedItem == null || string.IsNullOrEmpty(cBoxDiModuleType.SelectedItem.ToString()))
            {
                return;
            }

            if (!checkConfigMode.Checked)
            {
                return;
            }

            foreach (var diModule in _prim.DiModules)
            {
                if (diModule.Value.SlaveNo != numDiModuleSlaveNo.Value ||
                    diModule.Value.Id != int.Parse(cBoxDiModuleId.SelectedItem.ToString()))
                {
                    continue;
                }

                diModule.Value.TypeName = cBoxDiModuleType.SelectedItem.ToString();
                switch (diModule.Value.TypeName)
                {
                    case "LC1408":
                        diModule.Value.Num = 8;
                        diModule.Value.Value = 0;
                        break;

                    case "LC1488":
                        diModule.Value.Num = 8;
                        diModule.Value.Value = 0;
                        break;

                    case "MINIIN32":
                        diModule.Value.Num = 32;
                        diModule.Value.Value = 0;
                        break;

                    case "MINIIO16":
                        diModule.Value.Num = 16;
                        diModule.Value.Value = 0;
                        break;

                    default:
                        diModule.Value.Num = 8;
                        diModule.Value.Value = 0;
                        break;
                }
            }
        }

        private void NumDiModuleSlaveNo_ValueChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || numDiModuleSlaveNo.Value < 0)
            {
                return;
            }

            var count = 0;
            cBoxDiModuleId.Items.Clear();
            foreach (var primDiModule in _prim.DiModules)
            {
                if (primDiModule.Value.SlaveNo == numDiModuleSlaveNo.Value)
                {
                    count++;
                    cBoxDiModuleId.Items.Add(primDiModule.Value.Id);
                }
            }

            numDiModuleTotal.Value = count;
            _numDiModuleTotalValueChangedByCode = true;

            cBoxDiModuleId.SelectedIndex = -1;
            cBoxDiModuleType.SelectedIndex = -1;
        }

        private void numDiModuleTotal_KeyUp(object sender, KeyEventArgs e)
        {
            NumDiModuleTotalValueChanged();
        }

        private void numDiModuleTotal_MouseUp(object sender, MouseEventArgs e)
        {
            NumDiModuleTotalValueChanged();
        }

        private void NumDiModuleTotal_ValueChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ConfirmCurrentPrimNotRunning", "Please confirm that the current prim is not running."));
                return;
            }

            if (_numDiModuleTotalValueChangedByCode)
            {
                _numDiModuleTotalValueChangedByCode = false;
            }
            _numDiModuleTotalValueChanged = true;
        }

        private void NumDiModuleTotalValueChanged()
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || numDiModuleTotal.Value < 0 || numDiModuleSlaveNo.Value < 0 || !_numDiModuleTotalValueChanged)
            {
                return;
            }

            _numDiModuleTotalValueChanged = false;

            if (checkConfigMode.Checked)
            {
                cBoxDiModuleId.Items.Clear();

                foreach (var diModule in _prim.DiModules)
                {
                    if (diModule.Value.SlaveNo == numDiModuleSlaveNo.Value)
                    {
                        _prim.DiModules.TryRemove(diModule.Key, out var removed);
                    }
                }

                for (var i = 0; i < numDiModuleTotal.Value; i++)
                {
                    var di = new EDiModule((int)numDiModuleSlaveNo.Value, ((int)numDiModuleSlaveNo.Value + 1) * 100 + i, "", 0, 0);
                    cBoxDiModuleId.Items.Add(di.Id);
                    _prim.DiModules.TryAdd(di.Id, di);
                }
            }

            cBoxDiModuleId.SelectedIndex = -1;
            cBoxDiModuleType.SelectedIndex = -1;
        }

        #endregion DiModules

        #region DoModules

        private void BtnDoControl_Click(object sender, EventArgs e)
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
                {
                    _doControlForm.WindowState = FormWindowState.Normal;
                }
            }
            _doControlForm.TmrStart();
        }

        private void cBoxDoModuleId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || cBoxDoModuleId.SelectedItem == null || string.IsNullOrEmpty(cBoxDoModuleId.SelectedItem.ToString()))
            {
                return;
            }
            cBoxDoModuleType.SelectedIndex = -1;

            foreach (var doModule in _prim.DoModules)
            {
                if (doModule.Value.SlaveNo == numDoModuleSlaveNo.Value &&
                    doModule.Value.Id == int.Parse(cBoxDoModuleId.SelectedItem.ToString()))
                {
                    cBoxDoModuleType.Enabled = true;
                    cBoxDoModuleType.SelectedItem = doModule.Value.TypeName;
                    break;
                }
            }

            if (!checkConfigMode.Checked)
            {
                cBoxDoModuleType.Enabled = false;
            }
        }

        private void CBoxDoModuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || cBoxDoModuleType.SelectedItem == null || string.IsNullOrEmpty(cBoxDoModuleType.SelectedItem.ToString()))
            {
                return;
            }

            if (!checkConfigMode.Checked)
            {
                return;
            }

            foreach (var doModule in _prim.DoModules)
            {
                if (doModule.Value.SlaveNo != numDoModuleSlaveNo.Value ||
                    doModule.Value.Id != int.Parse(cBoxDoModuleId.SelectedItem.ToString()))
                {
                    continue;
                }

                doModule.Value.TypeName = cBoxDoModuleType.SelectedItem.ToString();
                switch (doModule.Value.TypeName)
                {
                    case "LC2408":
                        doModule.Value.Num = 8;
                        doModule.Value.Value = 0;
                        break;

                    case "LC2488":
                        doModule.Value.Num = 8;
                        doModule.Value.Value = 0;
                        break;

                    case "MINIOUT32":
                        doModule.Value.Num = 32;
                        doModule.Value.Value = 0;
                        break;

                    case "MINIIO16":
                        doModule.Value.Num = 16;
                        doModule.Value.Value = 0;
                        break;

                    default:
                        doModule.Value.Num = 8;
                        doModule.Value.Value = 0;
                        break;
                }
            }
        }

        private void NumDoModuleSlaveNo_ValueChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || numDoModuleSlaveNo.Value < 0)
            {
                return;
            }

            var count = 0;
            cBoxDoModuleId.Items.Clear();
            foreach (var primDoModule in _prim.DoModules)
            {
                if (primDoModule.Value.SlaveNo == numDoModuleSlaveNo.Value)
                {
                    count++;
                    cBoxDoModuleId.Items.Add(primDoModule.Key);
                }
            }

            numDoModuleTotal.Value = count;
            _numDoModuleTotalValueChangedByCode = true;

            cBoxDoModuleId.SelectedIndex = -1;
            cBoxDoModuleType.SelectedIndex = -1;
        }

        private void numDoModuleTotal_KeyUp(object sender, KeyEventArgs e)
        {
            NumDoModuleTotalValueChanged();
        }

        private void numDoModuleTotal_MouseUp(object sender, MouseEventArgs e)
        {
            NumDoModuleTotalValueChanged();
        }

        private void NumDoModuleTotal_ValueChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ConfirmCurrentPrimNotRunning", "Please confirm that the current prim is not running."));
                return;
            }

            if (_numDoModuleTotalValueChangedByCode)
            {
                _numDoModuleTotalValueChangedByCode = false;
            }
            _numDoModuleTotalValueChanged = true;
        }

        private void NumDoModuleTotalValueChanged()
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || numDoModuleTotal.Value < 0 || numDoModuleSlaveNo.Value < 0 || !_numDoModuleTotalValueChanged)
            {
                return;
            }

            _numDoModuleTotalValueChanged = false;

            if (checkConfigMode.Checked)
            {
                cBoxDoModuleId.Items.Clear();

                foreach (var doModule in _prim.DoModules)
                {
                    if (doModule.Value.SlaveNo == numDoModuleSlaveNo.Value)
                    {
                        _prim.DoModules.TryRemove(doModule.Key, out var removed);
                    }
                }

                for (var i = 0; i < numDoModuleTotal.Value; i++)
                {
                    var doo = new EDoModule((int)numDoModuleSlaveNo.Value, ((int)numDoModuleSlaveNo.Value + 1) * 100 + i, "", 0, 0);
                    cBoxDoModuleId.Items.Add(doo.Id);
                    _prim.DoModules.TryAdd(doo.Id, doo);
                }
            }

            cBoxDoModuleId.SelectedIndex = -1;
            cBoxDoModuleType.SelectedIndex = -1;
        }

        #endregion DoModules

        #region AiModules

        private void BtnAiControl_Click(object sender, EventArgs e)
        {
            if (_prim == null || _aiControlForm == null || _aiControlForm.IsDisposed)
            {
                _aiControlForm = new IOControl(ControlEnum.IOType.AI, _prim);
                _aiControlForm.Show();
            }
            else
            {
                _aiControlForm.TopMost = true;
                _aiControlForm.Visible = true;
                _aiControlForm.Activate();
                if (_aiControlForm.WindowState == FormWindowState.Minimized)
                {
                    _aiControlForm.WindowState = FormWindowState.Normal;
                }
            }
            _aiControlForm.TmrStart();
        }

        private void cBoxAiModuleId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || cBoxAiModuleId.SelectedItem == null || string.IsNullOrEmpty(cBoxAiModuleId.SelectedItem.ToString()))
            {
                return;
            }
            cBoxAiModuleType.SelectedIndex = -1;

            foreach (var aiModule in _prim.AiModules)
            {
                if (aiModule.Value.SlaveNo == numAiModuleSlaveNo.Value &&
                    aiModule.Value.Id == int.Parse(cBoxAiModuleId.SelectedItem.ToString()))
                {
                    cBoxAiModuleType.Enabled = true;
                    cBoxAiModuleType.SelectedItem = aiModule.Value.TypeName;
                    break;
                }
            }

            if (!checkConfigMode.Checked)
            {
                cBoxAiModuleType.Enabled = false;
            }
        }

        private void CBoxAiModuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || cBoxAiModuleType.SelectedItem == null || string.IsNullOrEmpty(cBoxAiModuleType.SelectedItem.ToString()))
            {
                return;
            }

            if (!checkConfigMode.Checked)
            {
                return;
            }

            foreach (var aiModule in _prim.AiModules)
            {
                if (aiModule.Value.SlaveNo != numAiModuleSlaveNo.Value ||
                    aiModule.Value.Id != int.Parse(cBoxAiModuleId.SelectedItem.ToString()))
                {
                    continue;
                }

                aiModule.Value.TypeName = cBoxAiModuleType.SelectedItem.ToString();
                switch (aiModule.Value.TypeName)
                {
                    case "LC3134":
                        aiModule.Value.Num = 4;
                        aiModule.Value.Value = new double[4];
                        break;

                    case "LC3114":
                        aiModule.Value.Num = 4;
                        aiModule.Value.Value = new double[4];
                        break;

                    case "LC3162":
                        aiModule.Value.Num = 2;
                        aiModule.Value.Value = new double[2];
                        break;

                    case "LC3172":
                        aiModule.Value.Num = 2;
                        aiModule.Value.Value = new double[2];
                        break;

                    default:
                        aiModule.Value.Num = 8;
                        aiModule.Value.Value = new double[8];
                        break;
                }
            }
        }

        private void NumAiModuleSlaveNo_ValueChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || numAiModuleSlaveNo.Value < 0)
            {
                return;
            }

            var count = 0;
            cBoxAiModuleId.Items.Clear();
            foreach (var primAiModule in _prim.AiModules)
            {
                if (primAiModule.Value.SlaveNo == numAiModuleSlaveNo.Value)
                {
                    count++;
                    cBoxAiModuleId.Items.Add(primAiModule.Key);
                }
            }

            numAiModuleTotal.Value = count;
            _numAiModuleTotalValueChangedByCode = true;

            cBoxAiModuleId.SelectedIndex = -1;
            cBoxAiModuleType.SelectedIndex = -1;
        }

        private void numAiModuleTotal_KeyUp(object sender, KeyEventArgs e)
        {
            NumAiModuleTotalValueChanged();
        }

        private void numAiModuleTotal_MouseUp(object sender, MouseEventArgs e)
        {
            NumAiModuleTotalValueChanged();
        }

        private void NumAiModuleTotal_ValueChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ConfirmCurrentPrimNotRunning", "Please confirm that the current prim is not running."));
                return;
            }

            if (_numAiModuleTotalValueChangedByCode)
            {
                _numAiModuleTotalValueChangedByCode = false;
            }
            _numAiModuleTotalValueChanged = true;
        }

        private void NumAiModuleTotalValueChanged()
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || numAiModuleTotal.Value < 0 || numAiModuleSlaveNo.Value < 0 || !_numAiModuleTotalValueChanged)
            {
                return;
            }

            _numAiModuleTotalValueChanged = false;

            if (checkConfigMode.Checked)
            {
                cBoxAiModuleId.Items.Clear();

                foreach (var aiModule in _prim.AiModules)
                {
                    if (aiModule.Value.SlaveNo == numAiModuleSlaveNo.Value)
                    {
                        _prim.AiModules.TryRemove(aiModule.Key, out var removed);
                    }
                }

                for (var i = 0; i < numAiModuleTotal.Value; i++)
                {
                    var ai = new EAiModule((int)numAiModuleSlaveNo.Value, ((int)numAiModuleSlaveNo.Value + 1) * 100 + i);
                    cBoxAiModuleId.Items.Add(ai.Id);
                    _prim.AiModules.TryAdd(ai.Id, ai);
                }
            }

            cBoxAiModuleId.SelectedIndex = -1;
            cBoxAiModuleType.SelectedIndex = -1;
        }

        #endregion AiModules

        #region AoModules

        private void BtnAoControl_Click(object sender, EventArgs e)
        {
            if (_prim == null || _aoControlForm == null || _aoControlForm.IsDisposed)
            {
                _aoControlForm = new IOControl(ControlEnum.IOType.AO, _prim);
                _aoControlForm.Show();
            }
            else
            {
                _aoControlForm.TopMost = true;
                _aoControlForm.Visible = true;
                _aoControlForm.Activate();
                if (_aoControlForm.WindowState == FormWindowState.Minimized)
                {
                    _aoControlForm.WindowState = FormWindowState.Normal;
                }
            }
            _aoControlForm.TmrStart();
        }

        private void cBoxAoModuleId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || cBoxAoModuleId.SelectedItem == null || string.IsNullOrEmpty(cBoxAoModuleId.SelectedItem.ToString()))
            {
                return;
            }
            cBoxAoModuleType.SelectedIndex = -1;

            foreach (var aoModule in _prim.AoModules)
            {
                if (aoModule.Value.SlaveNo == numAoModuleSlaveNo.Value &&
                    aoModule.Value.Id == int.Parse(cBoxAoModuleId.SelectedItem.ToString()))
                {
                    cBoxAoModuleType.Enabled = true;
                    cBoxAoModuleType.SelectedItem = aoModule.Value.TypeName;
                    break;
                }
            }

            if (!checkConfigMode.Checked)
            {
                cBoxAoModuleType.Enabled = false;
            }
        }

        private void CBoxAoModuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || cBoxAoModuleType.SelectedItem == null || string.IsNullOrEmpty(cBoxAoModuleType.SelectedItem.ToString()))
            {
                return;
            }

            if (!checkConfigMode.Checked)
            {
                return;
            }

            foreach (var aoModule in _prim.AoModules)
            {
                if (aoModule.Value.SlaveNo != numAoModuleSlaveNo.Value ||
                    aoModule.Value.Id != int.Parse(cBoxAoModuleId.SelectedItem.ToString()))
                {
                    continue;
                }

                aoModule.Value.TypeName = cBoxAoModuleType.SelectedItem.ToString();
                switch (aoModule.Value.TypeName)
                {
                    case "LC4124":
                        aoModule.Value.Num = 4;
                        aoModule.Value.Value = new double[4];
                        break;

                    case "LC4114":
                        aoModule.Value.Num = 4;
                        aoModule.Value.Value = new double[4];
                        break;

                    default:
                        aoModule.Value.Num = 8;
                        aoModule.Value.Value = new double[8];
                        break;
                }
            }
        }

        private void NumAoModuleSlaveNo_ValueChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || numAoModuleSlaveNo.Value < 0)
            {
                return;
            }

            var count = 0;
            cBoxAoModuleId.Items.Clear();
            foreach (var primAoModule in _prim.AoModules)
            {
                if (primAoModule.Value.SlaveNo == numAoModuleSlaveNo.Value)
                {
                    count++;
                    cBoxAoModuleId.Items.Add(primAoModule.Key);
                }
            }

            numAoModuleTotal.Value = count;
            _numAoModuleTotalValueChangedByCode = true;

            cBoxAoModuleId.SelectedIndex = -1;
            cBoxAoModuleType.SelectedIndex = -1;
        }

        private void numAoModuleTotal_KeyUp(object sender, KeyEventArgs e)
        {
            NumAoModuleTotalValueChanged();
        }

        private void numAoModuleTotal_MouseUp(object sender, MouseEventArgs e)
        {
            NumAoModuleTotalValueChanged();
        }

        private void NumAoModuleTotal_ValueChanged(object sender, EventArgs e)
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimADLinkE_PrimConfigControl_ConfirmCurrentPrimNotRunning", "Please confirm that the current prim is not running."));
                return;
            }

            if (_numAoModuleTotalValueChangedByCode)
            {
                _numAoModuleTotalValueChangedByCode = false;
            }
            _numAoModuleTotalValueChanged = true;
        }

        private void NumAoModuleTotalValueChanged()
        {
            if (_prim == null || _prim.PrimRunStat == PrimRunState.Running || numAoModuleTotal.Value < 0 || numAoModuleSlaveNo.Value < 0 || !_numAoModuleTotalValueChanged)
            {
                return;
            }

            _numAoModuleTotalValueChanged = false;

            if (checkConfigMode.Checked)
            {
                cBoxAoModuleId.Items.Clear();

                foreach (var aoModule in _prim.AoModules)
                {
                    if (aoModule.Value.SlaveNo == numAoModuleSlaveNo.Value)
                    {
                        _prim.AoModules.TryRemove(aoModule.Key, out var removed);
                    }
                }

                for (var i = 0; i < numAoModuleTotal.Value; i++)
                {
                    var ao = new EAoModule((int)numAoModuleSlaveNo.Value, ((int)numAoModuleSlaveNo.Value + 1) * 100 + i);
                    cBoxAoModuleId.Items.Add(ao.Id);
                    _prim.AoModules.TryAdd(ao.Id, ao);
                }
            }

            cBoxAoModuleId.SelectedIndex = -1;
            cBoxAoModuleType.SelectedIndex = -1;
        }

        #endregion AoModules

        #region Others
        

        private void ReloadIoInfos()
        {
            if (_infos == null)
            {
                return;
            }

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

        private void UpdateConfigControls()
        {
            if (InvokeRequired)
            {
                var update = new UpdateControls(UpdateConfigControls);
                BeginInvoke(update, args: null);
            }
            else
            {
                if (_prim == null)
                {
                    return;
                }

                tBoxTotalSlaveNum.Text = _prim.TotalSlaveNum.ToString();
                tBoxTotalAxisNum.Text = _prim.TotalAxisNum.ToString();
                tBoxTotalDiModuleNum.Text = _prim.TotalDiModuleNum.ToString();
                tBoxTotalDoModuleNum.Text = _prim.TotalDoModuleNum.ToString();
                tBoxTotalAiModuleNum.Text = _prim.TotalAiModuleNum.ToString();
                tBoxTotalAoModuleNum.Text = _prim.TotalAoModuleNum.ToString();

                cmbAxisId.Items.Clear();
                cmbAxisSlaveNo.Items.Clear();
                foreach (var axis in _prim.Axises)
                {
                    if (cmbAxisSlaveNo.Items.Contains(axis.Value.SlaveNo))
                    {
                        continue;
                    }

                    cmbAxisSlaveNo.Items.Add(axis.Value.SlaveNo);
                }

                foreach (var axis in _prim.Axises)
                {
                    if (cmbAxisId.Items.Contains(axis.Value.Id))
                    {
                        continue;
                    }

                    cmbAxisId.Items.Add(axis.Value.Id);
                }

                cmbAxisId.SelectedIndex = -1;
                cmbAxisSlaveNo.SelectedIndex = -1;
                cmbAxisType.SelectedIndex = -1;
                CalcCount();
            }
        }

        #endregion Others

        #region general method

        public void SetPrimConnState(PrimConnState state)
        {
            if (tBoxConnState.InvokeRequired)
            {
                var update = new UpdatePrimConnState(SetPrimConnState);
                Invoke(update, new object[1] { state });
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

        public void SetPrimRunState(PrimRunState state)
        {
            if (tBoxRunState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdatePrimRunState(SetPrimRunState);
                Invoke(update, new object[1] { state });
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

        #endregion general method
    }
}