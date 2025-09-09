using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;

namespace Lead.CPrim.PrimLEIS_E

{
    public partial class PrimConfigControl : UserControl
    {
        private readonly LESIDataConfigs _dataConfigs = new LESIDataConfigs();

        private readonly PrimLESI_E _primLESI;
        private int zero;

        public PrimConfigControl()
        {
            InitializeComponent();
        }

        public PrimConfigControl(PrimLESI_E prim)
        {
            InitializeComponent();

            _primLESI = prim;
            tBoxConfigFileName.Text = _primLESI.ConfigFilePath;
        }

        public string LESIName
        {
            set => tBoxLESIName.Text = value;
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            dataGridView_conti.Rows.Add();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            var rowCount = dataGridView_conti.Rows.Count;

            if (rowCount < 1) return;

            _primLESI.DataConfigs.ListDataConfig.Clear();

            for (var i = 0; i < rowCount; i++)
            {
                var dtConfig = new LESIDataConfig();

                if (dataGridView_conti.Rows[i].Cells[1].Value == null)
                    dtConfig.X_Pos = 0;
                else
                    dtConfig.X_Pos = double.Parse(dataGridView_conti.Rows[i].Cells[1].Value.ToString());

                if (dataGridView_conti.Rows[i].Cells[2].Value == null)
                    dtConfig.Y_Pos = 0;
                else
                    dtConfig.Y_Pos = double.Parse(dataGridView_conti.Rows[i].Cells[2].Value.ToString());

                if (dataGridView_conti.Rows[i].Cells[3].Value == null)
                    dtConfig.Z_Pos = 0;
                else
                    dtConfig.Z_Pos = double.Parse(dataGridView_conti.Rows[i].Cells[3].Value.ToString());

                _primLESI.DataConfigs.ListDataConfig.Add(dtConfig);
            }
        }

        private void BT_ContiStart_Click_1(object sender, EventArgs e)
        {
        }

        private void BtnAbsoluteMove_Click(object sender, EventArgs e)
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(tbPraVs.Text);
            var speed = Convert.ToInt32(tbPraVm.Text);
            var stop = Convert.ToDouble(tbPraVe.Text);
            var acc = Convert.ToDouble(tbPraAcc.Text);
            var dec = Convert.ToDouble(tbPraDecT.Text);
            var stTime = Convert.ToDouble(textprasT.Text);
            var dDist = Convert.ToInt32(numAbsolutePos.Text);
            _primLESI.AxisSetAccDec(selectAxis, start, speed, acc, dec, stop,
                stTime); //设置起始速度、运行速度、停止速度、加速时间、减速时间、S段速度参数
            _primLESI.AxisAbsMove(selectAxis, dDist, speed);
        }

        private void btnBrower_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            DialogResult result;
            try
            {
                result = openFileDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }

            if (result == DialogResult.OK)
            {
                tBoxConfigFileName.Text = openFileDialog.FileName;

                if (string.IsNullOrEmpty(tBoxConfigFileName.Text)) return;

                if (!File.Exists(tBoxConfigFileName.Text))
                {
                    MessageBox.Show(NLocalizer.GetString("PrimLEIS_PrimConfigControl_SelectedFileNotExist",
                        "The selection file does not exist."));
                    return;
                }

                _primLESI.ConfigFilePath = tBoxConfigFileName.Text;
            }
        }


        private void btnHoming_Click(object sender, EventArgs e)
        {
            if (_primLESI.PrimConnStat != PrimConnState.Connected)
            {
                MessageBox.Show(NLocalizer.GetString("PrimLEIS_PrimConfigControl_LoadConfigFileFirstly",
                    "Please load the configuration file first."));
                return;
            }

            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(tbPraVs.Text);
            var speed = Convert.ToDouble(tbPraVm.Text);
            var stop = Convert.ToDouble(tbPraVe.Text);
            var acc = Convert.ToDouble(tbPraAcc.Text);
            var dec = Convert.ToDouble(tbPraDecT.Text);
            var homeMode = cmbHomeMode.SelectedIndex;
            var homeDir = cmbHomeDir.SelectedIndex;
            _primLESI.AxisSetAccDec(selectAxis, start, speed / 5, acc, dec, stop); //设置起始速度、运行速度、停止速度、加速时间、减速时间
            _primLESI.AxisSetHomeMode(selectAxis, (ushort)homeDir, 1, homeMode);
            _primLESI.AxisHomeMove(selectAxis);
            zero = 1;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_primLESI == null) return;

            _primLESI.IPrimInit();

            var result = "";
            _primLESI.IPrimConnect(ref result);
            btnLoadConfig_Click(null, null);
        }

        private void BtnJogNegative_MouseDown(object sender, MouseEventArgs e)
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(tbPraVs.Text);
            var speed = Convert.ToDouble(tbPraVm.Text);
            var stop = Convert.ToDouble(tbPraVe.Text);
            var acc = Convert.ToDouble(tbPraAcc.Text);
            var dec = Convert.ToDouble(tbPraDecT.Text);
            var stTime = Convert.ToDouble(textprasT.Text);
            _primLESI.AxisSetAccDec(selectAxis, start, speed, acc, dec, stop,
                stTime); //设置起始速度、运行速度、停止速度、加速时间、减速时间、S段速度参数
            _primLESI.AxisJogStart(selectAxis, 1, 1);
            btnJogNegative.BackColor = Color.Green;
        }

        private void BtnJogNegative_MouseUp(object sender, MouseEventArgs e)
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            _primLESI.AxisStopMove(selectAxis);
            btnJogNegative.BackColor = Color.DarkGray;
        }

        private void BtnJogPostive_MouseDown(object sender, MouseEventArgs e)
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(tbPraVs.Text);
            var speed = Convert.ToDouble(tbPraVm.Text);
            var stop = Convert.ToDouble(tbPraVe.Text);
            var acc = Convert.ToDouble(tbPraAcc.Text);
            var dec = Convert.ToDouble(tbPraDecT.Text);
            var stTime = Convert.ToDouble(textprasT.Text);
            _primLESI.AxisSetAccDec(selectAxis, start, speed, acc, dec, stop,
                stTime); //设置起始速度、运行速度、停止速度、加速时间、减速时间、S段速度参数
            _primLESI.AxisJogStart(selectAxis, 1, 0);
            btnJogPositive.BackColor = Color.Green;
        }

        private void BtnJogPostive_MouseUp(object sender, MouseEventArgs e)
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            _primLESI.AxisStopMove(selectAxis);
            btnJogPositive.BackColor = Color.DarkGray;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (_primLESI != null)
            {
                var iRet = _primLESI.ImportDataTable(_primLESI.DataTablePath);
                if (iRet != 0) return;

                DataTableUpdate();
            }
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            if (_primLESI == null || _primLESI.PrimConnStat != PrimConnState.Connected)
            {
                MessageBox.Show(NLocalizer.GetString("PrimLEIS_PrimConfigControl_InitializeCardFirst",
                    "Please initialize the card first! "));
                return;
            }

            ushort boardId = 1000;
            if (!string.IsNullOrEmpty(cmbCardId.Text))
            {
                boardId = Convert.ToUInt16(cmbCardId.Text);
                _primLESI.StopAllAxes();
            }
            else
            {
                return;
            }

            //判断配置文件是否存在
            if (File.Exists(_primLESI.ConfigFilePath))
            {
                var iRet = _primLESI.IPrimInit();

                if (iRet != 0) return;

                if (_primLESI.PrimConnStat == PrimConnState.Connected)
                    btnLoadConfig.BackColor = Color.LawnGreen;
                else
                    btnLoadConfig.BackColor = Color.DimGray;
            }
            else
            {
                MessageBox.Show(tBoxConfigFileName.Text + NLocalizer.GetString(
                    "PrimLEIS_PrimConfigControl_SelectXMLConfigurationFile",
                    " does not exist, please select the XML configuration file."));
                var dialog = new OpenFileDialog();
                dialog.Filter = NLocalizer.GetString("PrimLEIS_PrimConfigControl_OpenFileDialogFilter",
                    "XML File (*.xml)|*.xml|All Files (*.*)|*.*");
                dialog.InitialDirectory = "C:";
                dialog.Title =
                    NLocalizer.GetString("PrimLEIS_PrimConfigControl_OpenFileDialogTitle", "Select a XML File");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _primLESI.ConfigFilePath = dialog.FileName;
                    tBoxConfigFileName.Text = dialog.FileName;
                }
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
        }

        private void btnMCH0_Click(object sender, EventArgs e)
        {
        }

        private void BtnRelativeMove_Click(object sender, EventArgs e)
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(tbPraVs.Text);
            var speed = Convert.ToInt32(tbPraVm.Text);
            var stop = Convert.ToDouble(tbPraVe.Text);
            var acc = Convert.ToDouble(tbPraAcc.Text);
            var dec = Convert.ToDouble(tbPraDecT.Text);
            var stTime = Convert.ToDouble(textprasT.Text);
            var dDist = Convert.ToInt32(numRelativePos.Text);

            _primLESI.AxisSetAccDec(selectAxis, start, speed, acc, dec, stop,
                stTime); //设置起始速度、运行速度、停止速度、加速时间、减速时间、S段速度参数
            _primLESI.AxisRelMove(selectAxis, Convert.ToInt32(dDist), speed);
        }

        private void btnResetCH0_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(cmbCardId.Text);
            _primLESI.dmc_hcmp_clear_points(boardId, 0);
            //_primLESI.dmc_hcmp_set_mode(boardId, 0, 0);
            _primLESI.dmc_hcmp_fifo_clear_points(boardId, 0);
            //_primLESI.dmc_hcmp_fifo_set_mode(boardId, 0, 0);
        }

        private void btnResetCH1_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(cmbCardId.Text);
            _primLESI.dmc_hcmp_clear_points(boardId, 1);
            // _primLESI.dmc_hcmp_set_mode(boardId, 1, 0);
            _primLESI.dmc_hcmp_fifo_clear_points(boardId, 1);
            // _primLESI.dmc_hcmp_fifo_set_mode(boardId, 1, 0);
        }

        private void btnResetCH2_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(cmbCardId.Text);
            _primLESI.dmc_hcmp_clear_points(boardId, 2);
            // _primLESI.dmc_hcmp_set_mode(boardId, 2, 0);
            _primLESI.dmc_hcmp_fifo_clear_points(boardId, 2);
            // _primLESI.dmc_hcmp_fifo_set_mode(boardId, 2, 0);
        }

        private void btnResetCH3_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(cmbCardId.Text);
            _primLESI.dmc_hcmp_clear_points(boardId, 3);
            //    _primLESI.dmc_hcmp_set_mode(boardId, 3, 0);
            _primLESI.dmc_hcmp_fifo_clear_points(boardId, 3);
            // _primLESI.dmc_hcmp_fifo_set_mode(boardId, 3, 0);
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            _primLESI.IPrimStart();
            tmrUpdateUI.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //saveFileDialog.FileName = "DataConfigs";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var savePath = saveFileDialog.FileName;
                    _primLESI.ExportDataTable(savePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    NLocalizer.GetString("PrimLEIS_PrimConfigControl_SystemInfo", "System Info"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnServoOn_Click(object sender, EventArgs e)
        {
            if (_primLESI.PrimConnStat != PrimConnState.Connected)
            {
                MessageBox.Show(NLocalizer.GetString("PrimLEIS_PrimConfigControl_LoadConfigFileFirstly",
                    "Please load the configuration file first."));
                return;
            }

            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var status = _primLESI.AxisIsEnble(selectAxis);
            _primLESI.AxisSetEnable(selectAxis, !status);
        }

        private void BtnSetPosition_Click(object sender, EventArgs e)
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var position = Convert.ToDouble(tBoxSetPos.Text);
            _primLESI.SetAxisPositionAndFeedbackPulse(selectAxis, (int)position);
        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            _primLESI.IPrimStop();
        }

        private void BtnStopAxis_Click(object sender, EventArgs e)
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            _primLESI.AxisStopMove(selectAxis);
        }

        private void btnTableBrowse_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbTableDataPath.Text = openFileDialog.FileName;

                if (string.IsNullOrEmpty(tbTableDataPath.Text)) return;

                if (!File.Exists(tbTableDataPath.Text))
                {
                    MessageBox.Show(NLocalizer.GetString("PrimLEIS_PrimConfigControl_SelectedFileNotExist",
                        "The selection file does not exist."));
                    return;
                }

                _primLESI.DataTablePath = tbTableDataPath.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void CmbBitRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

        }

        private void cmbCardId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!VerifyAuthority()) return;

            if (string.IsNullOrEmpty(cmbCardId.Text)) return;

            _primLESI.DevIndex = Convert.ToInt32(cmbCardId.Text);
        }

        private void comboBoxCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!VerifyAuthority()) return;

            var str = cmbCard.SelectedItem.ToString();
            var cardType = Convert.ToInt32(str, 16); //每个卡有着不同数量的轴
            cmbSelectAxis.Items.Clear();
            if (cardType == 0x3400 || cardType == 0x5400)
                for (var axisNum = 0; axisNum < 4; axisNum++)
                {
                    cmbSelectAxis.Items.Add(axisNum);
                    cmbSelectAxis.SelectedIndex = 0;
                }
            else if (cardType == 0x3600 || cardType == 0x5600)
                for (var axisNum = 0; axisNum < 6; axisNum++)
                {
                    cmbSelectAxis.Items.Add(axisNum);
                    cmbSelectAxis.SelectedIndex = 0;
                }
            else if (cardType == 0x3800 || cardType == 0x5800)
                for (var axisNum = 0; axisNum < 8; axisNum++)
                {
                    cmbSelectAxis.Items.Add(axisNum);
                    cmbSelectAxis.SelectedIndex = 0;
                }
            else if (cardType == 0x3C00 || cardType == 0x5C00)
                for (var axisNum = 0; axisNum < 12; axisNum++)
                {
                    cmbSelectAxis.Items.Add(axisNum);
                    cmbSelectAxis.SelectedIndex = 0;
                }
            else
                cmbSelectAxis.Items.Clear();
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            var curSelectedIdx = dataGridView_conti.CurrentCell.RowIndex;
            dataGridView_conti.Rows.RemoveAt(curSelectedIdx);
        }


        private Label GetINLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label label in grpDi.Controls)
                if (label != null && label.Tag.ToString() == txt)
                    return label;

            return null;
        }

        private Label GetOUTLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label label in grpDo.Controls)
                if (label != null && label.Tag.ToString() == txt)
                    return label;

            return null;
        }

        /// <summary>
        ///     单个输出点测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbelDo_Click(object sender, EventArgs e)
        {
            double address = 0;
            foreach (Label label in grpDo.Controls)
                if (label == sender)
                {
                    address = 100 + Convert.ToInt32(label.Tag) * 0.01;
                    break;
                }

            _primLESI.ReadSingleDOutput(address, out var val);

            _primLESI.WriteSingleDOutput(address, !val);
        }

        private void PrimConfigControl_Load(object sender, EventArgs e)
        {
            cmbStopMode.SelectedIndex = _primLESI.StopMode == StopMode.Immediate ? 1 : 0;

            tBoxLESIName.Text = _primLESI.Name;
            tbPraAcc.Text = "0.2";
            tbPraDecT.Text = "0.2";
            tbPraVs.Text = "0.0";
            tbPraVm.Text = "200";
            tbPraVe.Text = "0.0";

            tbTableDataPath.Text = _primLESI.DataTablePath;
            DataTableUpdate();

            tPageCmpTrig.Parent = null;
            tPageContinueMove.Parent = null;
            tPageLatch.Parent = null;
            tPageTrigDemo.Parent = null;

            tPageContinuousInterpolation.Parent = null;

            tbDiCount.Text = _primLESI.DiCount.ToString();
            tbDoCount.Text = _primLESI.DoCount.ToString();
            tbAiCount.Text = _primLESI.AiCount.ToString();
            tbAoCount.Text = _primLESI.AoCount.ToString();
            tbAxisCount.Text = _primLESI.AxisCount.ToString();
        }

        private void SetLabel(Label label, bool status)
        {
            if (label != null) label.BackColor = status ? Color.DimGray : Color.Green;
        }

        private void tBoxLESIName_TextChanged(object sender, EventArgs e)
        {
            _primLESI.Name = tBoxLESIName.Text;
        }

        private void tmrUpdateUI_Tick(object sender, EventArgs e)
        {
            if (_primLESI.PrimRunStat == PrimRunState.Running)
            {
                //输入口
                for (var i = 0; i < 16; i++)
                {
                    var label = GetINLabel(i);
                    if (label != null)
                    {
                        var address = 100 + i * 0.01;
                        _primLESI.ReadSingleDInput(address, out var di);
                        SetLabel(label, !di);
                    }
                }

                //输出口
                for (var i = 0; i < 16; i++)
                {
                    var label = GetOUTLabel(i);
                    if (label != null)
                    {
                        var address = 100 + i * 0.01;
                        _primLESI.ReadSingleDOutput(address, out var doo);
                        SetLabel(label, !doo);
                    }
                }

                //轴状态读取
                ReadAxisStatus();
                //回零
                if (zero == 1)
                {
                    var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
                    if (_primLESI.AxisIsStop(selectAxis))
                    {
                        Thread.Sleep(100);
                        _primLESI.SetAxisPositionAndFeedbackPulse(selectAxis, 0);
                        zero = 0;
                    }
                }
            }
        }

        private bool VerifyAuthority()
        {
            if (AuthorityManager.Instance.Level < OpLevel.Level2 &&
                AuthorityManager.Instance.Level != OpLevel.Other)
            {
                MessageBox.Show(
                    NLocalizer.GetString("PrimLEIS_PrimConfigControl_ConfirmPermission",
                        "The current user does not have permission. Please confirm that the permission is in operation."),
                    NLocalizer.GetString("PrimLEIS_PrimConfigControl_Info", "Info"), MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        public void DataTableUpdate()
        {
            if (_primLESI?.DataConfigs?.ListDataConfig == null) return;

            dataGridView_conti.Rows.Clear();

            if (_primLESI.DataConfigs.ListDataConfig.Count < 1) return;

            try
            {
                foreach (var config in _primLESI.DataConfigs.ListDataConfig)
                {
                    var index = dataGridView_conti.Rows.Add();
                    dataGridView_conti.Rows[index].Cells[0].Value = dataGridView_conti.Rows.Count;
                    dataGridView_conti.Rows[index].Cells[1].Value = config.X_Pos;
                    dataGridView_conti.Rows[index].Cells[2].Value = config.Y_Pos;
                    dataGridView_conti.Rows[index].Cells[3].Value = config.Z_Pos;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public int ExportDataTable(string filePath)
        {
            var iRet = 0;

            if (dataGridView_conti == null) return -2;

            if (dataGridView_conti.Rows.Count > 0)
            {
                var bRet = XmlSerializerHelper.WriteXML(_dataConfigs, filePath, typeof(LESIDataConfigs));

                if (!bRet) return -1;
            }

            return iRet;
        }

        //获取轴状态
        public void ReadAxisStatus()
        {
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            double currentPosUnit = 0, currentEncoderUnit = 0, targetPosUnit = 0, currentVelocity = 0;

            _primLESI.GetAxisCommand(selectAxis, ref currentPosUnit);
            _primLESI.GetFeedbackPulse(selectAxis, ref currentEncoderUnit);
            _primLESI.GetAxisTargetPosition(selectAxis, ref targetPosUnit);
            _primLESI.GetAxisActualVelocity(selectAxis, ref currentVelocity);

            tbCmdPos.Text = Convert.ToString(currentPosUnit);
            tbFeedbackPos.Text = Convert.ToString(currentEncoderUnit);
            tbTargetPos.Text = Convert.ToString(targetPosUnit);
            tbCurrentVel.Text = Convert.ToString(currentVelocity);

            btnMotionAlm.BackColor = _primLESI.AxisIsAlarm(selectAxis) ? Color.Red : Color.DimGray;
            btnMotionPel.BackColor = _primLESI.AxisInPel(selectAxis) ? Color.Red : Color.DimGray;
            btnMotionMel.BackColor = _primLESI.AxisInMel(selectAxis) ? Color.Red : Color.DimGray;
            btnMotionEmg.BackColor = _primLESI.AxisSignalEmg(selectAxis) ? Color.Red : Color.DimGray;
            btnMotionSPel.BackColor = _primLESI.AxisInSPel(selectAxis) ? Color.Green : Color.DimGray;
            btnMotionSMel.BackColor = _primLESI.AxisInMel(selectAxis) ? Color.Red : Color.DimGray;
            btnMotionInp.BackColor = _primLESI.AxisSignalInp(selectAxis) ? Color.Green : Color.DimGray;
            btnMotionEz.BackColor = _primLESI.AxisSignalEz(selectAxis) ? Color.Green : Color.DimGray;
            btnMotionRdy.BackColor = _primLESI.AxisSignalRdy(selectAxis) ? Color.Green : Color.DimGray;
            btnMotionDStp.BackColor = _primLESI.AxisSignalDStp(selectAxis) ? Color.Green : Color.DimGray;
            btnServoOn.BackColor = _primLESI.AxisIsEnble(selectAxis) ? Color.Green : Color.DimGray;
        }

        public void SetPrimConnState(PrimConnState state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                        tbConnState.BackColor = Color.Khaki;
                        tbConnState.Text = @"UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnRun1.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun1.Enabled = true;
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
                        btnRun1.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun1.Enabled = true;
                        break;
                }
            }
        }

        public void SetPrimRunState(PrimRunState state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = @"Idle";
                        break;

                    case PrimRunState.Running:
                        tBoxRunState.BackColor = Color.LightGreen;
                        tBoxRunState.Text = @"Running";
                        btnRun1.BackColor = Color.Gray;
                        btnRun1.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop1.Enabled = true;
                        btnStop1.BackColor = Color.SandyBrown;
                        break;

                    case PrimRunState.Stop:
                        tBoxRunState.BackColor = Color.Brown;
                        tBoxRunState.Text = @"Stop";
                        btnRun1.BackColor = Color.LightGreen;
                        btnRun1.Enabled = true;
                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnStop1.Enabled = false;
                        btnStop1.BackColor = Color.Gray;
                        break;

                    case PrimRunState.Err:
                        tBoxRunState.BackColor = Color.SandyBrown;
                        tBoxRunState.Text = @"Err";
                        break;

                    case PrimRunState.Other:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = @"Idle";
                        btnRun1.Enabled = false;
                        btnRun1.BackColor = Color.Gray;
                        btnStop1.Enabled = false;
                        btnStop1.BackColor = Color.Gray;
                        break;
                }
            }
        }

        public void UIInit()
        {
            if (_primLESI == null) return;
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UIInit));
            }
            else
            {
                cmbHomeMode.SelectedIndex = 0;
                cmbHomeDir.SelectedIndex = 0;
                cmbCardId.Items.Clear();
                cmbCard.Items.Clear();
                for (var i = 0; i < _primLESI.CardNum; i++)
                {
                    if (_primLESI.CardTypes[i] == 0x80015032)
                    {
                        cmbCardId.Items.Add(_primLESI.CardIds[i]);
                        cmbCard.Items.Add(Convert.ToString(_primLESI.CardTypes[i], 16));
                    }
                }
                if (cmbCard.Items.Count > 0)
                {
                    cmbCardId.SelectedIndex = 0;
                    cmbCard.SelectedIndex = 0;
                }
            }
        }

        private void btnApplyNetModules_Click(object sender, EventArgs e)
        {
            _primLESI.DiCount = int.TryParse(tbDiCount.Text, out var diCount) ? diCount : 0;

            _primLESI.DoCount = int.TryParse(tbDoCount.Text, out var doCount) ? doCount : 0;

            _primLESI.AiCount = int.TryParse(tbAiCount.Text, out var aiCount) ? aiCount : 0;

            _primLESI.AoCount = int.TryParse(tbAoCount.Text, out var aoCount) ? aoCount : 0;

            _primLESI.AxisCount = int.TryParse(tbAxisCount.Text, out var axisCount) ? axisCount : 0;
        }
    }
}