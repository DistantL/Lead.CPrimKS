using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;

namespace Lead.CPrim.PrimLEIS
{
    public partial class PrimDebugControl : UserControl
    {
        private readonly LEISConfig _config = null;

        private readonly PrimLESI _primLESI;
        private int zero;
        public int _CANNum = 0;
        public int _CANStatus = 0;

        public PrimDebugControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        public PrimDebugControl(PrimLESI prim)
        {
            InitializeComponent();
            InitializeUI();

            _primLESI = prim;
        }

        private delegate void UpdatePrimConnState(PrimConnState state);

        private delegate void UpdatePrimRunState(PrimRunState state);

        public string LESIName
        {
            set => tBoxLESIName.Text = value;
        }

        private void btnAbsoluteMove_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(txtPraVs.Text);
            var speed = Convert.ToInt32(txtPraVm.Text);
            var stop = Convert.ToDouble(txtPraVe.Text);
            var acc = Convert.ToDouble(txtPraAcc.Text);
            var dec = Convert.ToDouble(txtPraDecT.Text);
            var stTime = Convert.ToDouble(textprasT.Text);
            var dDist = Convert.ToInt32(txtAbsolutePulse.Text);
            // _primLESI.dmc_set_profile_unit(boardId, selectAxis, start, speed, acc, dec, stop);//设置起始速度、运行速度、停止速度、加速时间、减速时间

            _primLESI.dmc_set_s_profile(selectAxis, 0, stTime); //设置S段速度参数,0为T
            _primLESI.AxisAbsMove(selectAxis, dDist, speed);
            // _primLESI.dmc_pmove_unit(boardId, selectAxis, dDist, sPosi_mode);//定长运动
        }

        private void btnHoming_Click(object sender, EventArgs e)
        {
            if (_primLESI.PrimConnStat != PrimConnState.Connected)
            {
                MessageBox.Show(NLocalizer.GetString("PrimLEIS_PrimDebugControl_LoadConfigFileFirstly",
                    "Please load the configuration file first."));
                return;
            }

            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(txtPraVs.Text);
            var speed = Convert.ToDouble(txtPraVm.Text);
            var stop = Convert.ToDouble(txtPraVe.Text);
            var acc = Convert.ToDouble(txtPraAcc.Text);
            var dec = Convert.ToDouble(txtPraDecT.Text);
            var homeMode = cmbHomeMode.SelectedIndex;
            var homeDir = cmbHomeDir.SelectedIndex;
            double homeV = cmbHomeVm.SelectedIndex;
            _primLESI.AxisSetAccDec(selectAxis, start, speed, acc, dec, stop); //设置起始速度、运行速度、停止速度、加速时间、减速时间
            _primLESI.AxisSetHomeMode(selectAxis, (ushort)homeDir, (int)homeV, homeMode, 0);
            _primLESI.AxisHomeMove(selectAxis);
            zero = 1;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_primLESI == null) return;

            _primLESI.IPrimInit();

            var result = "";
            _primLESI.IPrimConnect(ref result);
        }

        private void btnRelativeMove_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(txtPraVs.Text);
            var speed = Convert.ToInt32(txtPraVm.Text);
            var stop = Convert.ToDouble(txtPraVe.Text);
            var acc = Convert.ToDouble(txtPraAcc.Text);
            var dec = Convert.ToDouble(txtPraDecT.Text);
            var stTime = Convert.ToDouble(textprasT.Text);
            var dDist = Convert.ToInt32(txtRelativePulse.Text);
            //  _primLESI.dmc_set_profile_unit(boardId, selectAxis, start, speed, acc, dec, stop);//设置起始速度、运行速度、停止速度、加速时间、减速时间

            _primLESI.dmc_set_s_profile(selectAxis, 0, stTime); //设置S段速度参数,0为T
            _primLESI.AxisRelMove(selectAxis, Convert.ToInt32(dDist), speed);
            //_primLESI.dmc_pmove_unit(boardId, selectAxis, dDist, sPosi_mode);//定长运动
        }

        private void btnResetCH0_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            _primLESI.dmc_hcmp_clear_points(boardId, 0);
            //_primLESI.dmc_hcmp_set_mode(boardId, 0, 0);
            _primLESI.dmc_hcmp_fifo_clear_points(boardId, 0);
            //_primLESI.dmc_hcmp_fifo_set_mode(boardId, 0, 0);
        }

        private void btnResetCH1_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            _primLESI.dmc_hcmp_clear_points(boardId, 1);
            // _primLESI.dmc_hcmp_set_mode(boardId, 1, 0);
            _primLESI.dmc_hcmp_fifo_clear_points(boardId, 1);
            // _primLESI.dmc_hcmp_fifo_set_mode(boardId, 1, 0);
        }

        private void btnResetCH2_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            _primLESI.dmc_hcmp_clear_points(boardId, 2);
            // _primLESI.dmc_hcmp_set_mode(boardId, 2, 0);
            _primLESI.dmc_hcmp_fifo_clear_points(boardId, 2);
            // _primLESI.dmc_hcmp_fifo_set_mode(boardId, 2, 0);
        }

        private void btnResetCH3_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            _primLESI.dmc_hcmp_clear_points(boardId, 3);
            //    _primLESI.dmc_hcmp_set_mode(boardId, 3, 0);
            _primLESI.dmc_hcmp_fifo_clear_points(boardId, 3);
            // _primLESI.dmc_hcmp_fifo_set_mode(boardId, 3, 0);
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            _primLESI.IPrimStart();

            //btnLoadConfig_Click(null, null);

            tmrUpdateUI.Start();
        }

        private void btnSetPosZero_Click(object sender, EventArgs e)
        {
            try
            {
                var boardId = Convert.ToUInt16(CardIDcomboB.Text);
                var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
                var position = Convert.ToDouble(txtFeedbackPos.Text);
                _primLESI.SetAxisPositionAndFeedbackPulse(boardId, (int)position);
            }
            catch (Exception ex)
            {
                MessageBox.Show(NLocalizer.GetString("PrimLEIS_PrimDebugControl_Error", "Error: ") + ex);
            }
        }

        private void btnStartDemo_Click(object sender, EventArgs e)
        {
        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            _primLESI.IPrimStop();
        }

        private void butaxisstop_Click(object sender, EventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            _primLESI.AxisStopMove(selectAxis);
            // _primLESI.dmc_stop(boardId, selectAxis, 0);//减速停止
        }

        private void CardIDcomboB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            if (string.IsNullOrEmpty(CardIDcomboB.Text)) return;

            _config.DevIndex = Convert.ToInt32(CardIDcomboB.Text);
        }

        private void CmbSelectAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;
        }

        private void comboBoxCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!VerifyAuthority()) return;

            var str = comboBoxCard.SelectedItem.ToString();
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

        private void combStopMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combStopMode.SelectedIndex == 1)
                _primLESI.StopMode = StopMode.Immediate;
            else
                _primLESI.StopMode = StopMode.Free;
        }

        private Label GetCAN2INLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label _label in grpDi2.Controls)
                if (_label != null && _label.Tag.ToString() == txt)
                    return _label;
            return null;
        }

        private Label GetCAN2OUTLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label _label in grpDo2.Controls)
                if (_label != null && _label.Tag.ToString() == txt)
                    return _label;
            return null;
        }

        private Label GetCAN3INLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label _label in grpDi3.Controls)
                if (_label != null && _label.Tag.ToString() == txt)
                    return _label;
            return null;
        }

        private Label GetCAN3OUTLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label _label in grpDo3.Controls)
                if (_label != null && _label.Tag.ToString() == txt)
                    return _label;
            return null;
        }

        private Label GetCANINLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label _label in grpDi1.Controls)
                if (_label != null && _label.Tag.ToString() == txt)
                    return _label;
            return null;
        }

        private Label GetCANOUTLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label _label in grpDo1.Controls)
                if (_label != null && _label.Tag.ToString() == txt)
                    return _label;
            return null;
        }

        private Label GetINLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label _label in grpDi.Controls)
                if (_label != null && _label.Tag.ToString() == txt)
                    return _label;

            return null;
        }

        private Label GetOUTLabel(int index)
        {
            var txt = index.ToString();
            foreach (Label _label in grpDo.Controls)
                if (_label != null && _label.Tag.ToString() == txt)
                    return _label;

            return null;
        }

        private void InitializeUI()
        {
            lbTitle.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_LESIConfig", "LESI Config");
            label123.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_LESIName", "LESIName");
            label125.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_SelectCard", "Select Card:");
            label1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Id", "Id:");
            label3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_SelectAxis", "Select Axis :");
            label166.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CANNodeNumber", "CAN Node Number:");
            label194.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_BitRate", "Bit Rate:");
            groupBox.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_EXE", "EXE");
            btnInit.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Init", "Init");
            btnRun1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Run", "Run");
            btnStop1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Stop", "Stop");
            tPageAxisMove.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_AxisMove", "AxisMove");
            groupBox3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_MotionCommand", "Motion Command");
            label271.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_FeedbackPosition", "Feedback Position:");
            btnSetPosZero.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Set0", "Set0");
            grpMove.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_MotionParameter", "Motion Parameter");
            label37.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_FeedbackVelocity", "Feedback velocity:");
            label38.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CommandVelocity", "Command velocity :");
            label39.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ErrorPosition", "Error position   :");
            label40.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_TargetPosition", "Target position  :");
            label41.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_FeedbackPosition", "Feedback Position:");
            label42.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CommandPosition", "Command position :");
            label78.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_S_Time", "S_Time/s");
            label36.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Vel_End", "Vel_End");
            label164.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_DecTime", "DecTime/s:");
            label35.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_VelStart", "Vel_Start:");
            label34.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Vel_Max", "Vel_Max:");
            label163.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_AccTime", "AccTime/s:");
            groupBox2.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_JogPtpMove", "JOG/PTP Move");
            label7.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_StopMode", "Stop Mode:");
            butaxisstop.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_StopUpper", "STOP");
            label70.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_HomeVel", "HomeVel");
            btnHoming.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Homing", "Homing");
            btnAbsoluteMove.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Move", "Move");
            btnRelativeMove.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Go", "Go");
            lblServoOn.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ServoOn", "Servo On");
            label47.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_AbsolutePulse", "Absolute(pulse):");
            label48.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_HomeDir", "HomeDir:");
            label44.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_HomeMode", "HomeMode:");
            label46.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_RelativePulse", "Relative(pulse): ");
            grpMotionIo.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_MotionIOStatus", "Motion IO Status");
            label69.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_RDY", "RDY");
            label51.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ERC", "ERC");
            label73.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_EMG", "EMG");
            label82.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_EZ", "EZ");
            label98.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_MEL", "MEL");
            label115.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_INP", "INP");
            label116.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_SMEL", "SMEL");
            label117.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ALM", "ALM");
            label124.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_PEL", "PEL");
            label126.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_SVON", "SVON");
            label52.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ORG", "ORG");
            label71.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_SPEL", "SPEL");
            label133.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_SCL", "SCL");
            tPageIO.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_IO", "IO");
            grpDo.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_GeneralDO", "General DO");
            tPageContinueMove.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ContinueMove", "ContinueMove");
            button4.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_StartMove", "Start Move");
            button3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_StopMove", "Stop Move");
            label108.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_RunningCnt", "RunningCnt");
            label109.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_PointCount", "Point Count:");
            label114.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_BufFreeSpace", "BufFreeSpace:");
            label118.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_bufUsageSpace", "bufUsageSpace:");
            btnStartPt.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_LoadPoint", "Load Point");
            btnLoadFromFile.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_LoadCSV", "Load CSV");
            label120.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_TwoAxisLinearInterpolationPointTable",
                "Two Axis linear interpolation(Point Table): ");
            groupBox1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_TrigChannelTrigSource",
                "Trig Channel - Trig Source");
            tPageCmpTrig.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CmpTrig", "CmpTrig");
            label137.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_CurrenrComparison", "Currenr  comparison:");
            label128.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_CurrenrComparison", "Currenr  comparison:");
            label110.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_CurrenrComparison", "Currenr  comparison:");
            label107.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_CurrenrComparison", "Currenr  comparison:");
            label135.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_ResidualComparison", "Residual comparison:");
            label122.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_ResidualComparison", "Residual comparison:");
            label104.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_ResidualComparison", "Residual comparison:");
            label105.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_ResidualComparison", "Residual comparison:");
            label103.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ModeChoose", "Mode Choose");
            label97.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ModeChoose", "Mode Choose");
            label85.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ModeChoose", "Mode Choose");
            label80.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_ModeChoose", "Mode Choose");
            btnResetCH3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Reset", "Reset");
            btnResetCH2.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Reset", "Reset");
            btnResetCH1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Reset", "Reset");
            btnMCH3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Manual", "Manual");
            btnMCH2.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Manual", "Manual");
            btnMCH1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Manual", "Manual");
            btnMCH0.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Manual", "Manual");
            btnResetCH0.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Reset", "Reset");
            label130.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_AlreadyCompared", "Already  compared: ");
            label112.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_AlreadyCompared", "Already  compared: ");
            label8.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_AlreadyCompared", "Already  compared: ");
            lbTrigCnt0.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_AlreadyCompared", "Already  compared: ");
            label5.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_TrigCH3", "TrigCH3");
            label4.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_TrigCH2", "TrigCH2");
            label2.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_TrigCH1", "TrigCH1");
            lbTrigCH0.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_TrigCH0", "TrigCH0");
            tPageLatch.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_Latch", "Latch");
            btnRun.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_MovingTrigger", "Moving+trigger");
            btnGetLantch.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_GetLatchedData", "Get the latched data");
            btnEnableLatch.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_LatchEnable", "Latch Enable");
            tPageTrigDemo.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_TrigDemo", "TrigDemo");
            checkBoxOnly1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_OnlyToFirstParagraph",
                "Only to the first paragraph");
            btnLineTrigTest.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_LinearTriggerTest", "Linear Trigger Test");
            button5.Text =
                NLocalizer.GetString("PrimLEIS_PrimConfigControl_RotatingBackToZero", "Rotating Back To Zero");
            label121.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_RunningCont", "runningCont");
            btnToStart.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_StartPoint", "Start Point");
            buttonArc3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_StartMove", "Start Move");
            canIO1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CANIO1", "CANIO1");
            grpDo1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CAN_1_DO", "CAN_1_DO");
            grpDi1.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CAN_1_DI", "CAN_1_DI");
            canIO2.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CANIO2", "CANIO2");
            grpDo2.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CAN_2_DO", "CAN_2_DO");
            grpDi2.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CAN_2_DI", "CAN_2_DI");
            canIO3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CANIO3", "CANIO3");
            grpDo3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CAN_3_DO", "CAN_3_DO");
            grpDi3.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_CAN_3_DI", "CAN_3_DI");
            grpDi.Text = NLocalizer.GetString("PrimLEIS_PrimConfigControl_GeneralDI", "General DI");
        }

        /// <summary>
        ///     单个输出点测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            double address = 0;
            foreach (Label _label in grpDo.Controls)
                if (_label == sender)
                {
                    address = 100 + Convert.ToInt32(_label.Tag) * 0.01;
                    break;
                }

            foreach (Label _label in grpDo1.Controls)
                if (_label == sender)
                {
                    address = 101 + Convert.ToInt32(_label.Tag) * 0.01;
                    break;
                }

            foreach (Label _label in grpDo2.Controls)
                if (_label == sender)
                {
                    address = 102 + Convert.ToInt32(_label.Tag) * 0.01;
                    break;
                }

            foreach (Label _label in grpDo3.Controls)
                if (_label == sender)
                {
                    address = 103 + Convert.ToInt32(_label.Tag) * 0.01;
                    break;
                }

            _primLESI.ReadSingleDOutput(address, out var val);

            if (val)
                _primLESI.WriteSingleDOutput(address, false);
            else
                _primLESI.WriteSingleDOutput(address, true);
            //_primLESI.ReadSingleDInput(address, out val);
        }

        private void lblJogNegative_MouseDown(object sender, MouseEventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(txtPraVs.Text);
            var speed = Convert.ToDouble(txtPraVm.Text);
            var stop = Convert.ToDouble(txtPraVe.Text);
            var acc = Convert.ToDouble(txtPraAcc.Text);
            var dec = Convert.ToDouble(txtPraDecT.Text);
            var stTime = Convert.ToDouble(textprasT.Text);
            _primLESI.AxisSetAccDec(selectAxis, start, speed, acc, dec, stop,
                stTime); //设置起始速度、运行速度、停止速度、加速时间、减速时间、S段速度参数
            _primLESI.AxisJogStart(selectAxis, 1, 1);
            lblJogNegative.BackColor = Color.Green;
        }

        private void lblJogNegative_MouseUp(object sender, MouseEventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            _primLESI.AxisStopMove(selectAxis);
            // _primLESI.dmc_stop(boardId, selectAxis, 1);
            lblJogNegative.BackColor = Color.DarkGray;
        }

        private void lblJogPostive_MouseDown(object sender, MouseEventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            var start = Convert.ToDouble(txtPraVs.Text);
            var speed = Convert.ToDouble(txtPraVm.Text);
            var stop = Convert.ToDouble(txtPraVe.Text);
            var acc = Convert.ToDouble(txtPraAcc.Text);
            var dec = Convert.ToDouble(txtPraDecT.Text);
            var stTime = Convert.ToDouble(textprasT.Text);
            _primLESI.AxisSetAccDec(selectAxis, start, speed, acc, dec, stop,
                stTime); //设置起始速度、运行速度、停止速度、加速时间、减速时间、S段速度参数
            _primLESI.AxisJogStart(selectAxis, 1, 0);
            lblJogPostive.BackColor = Color.Green;
        }

        private void lblJogPostive_MouseUp(object sender, MouseEventArgs e)
        {
            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            _primLESI.AxisStopMove(selectAxis);
            //_primLESI.dmc_stop(boardId, selectAxis, 1);
            lblJogPostive.BackColor = Color.DarkGray;
        }

        private void lblServoOn_Click(object sender, EventArgs e)
        {
            if (_primLESI.PrimConnStat != PrimConnState.Connected)
            {
                MessageBox.Show(NLocalizer.GetString("PrimLEIS_PrimDebugControl_LoadConfigFileFirstly",
                    "Please load the configuration file first."));
                return;
            }

            var boardId = Convert.ToUInt16(CardIDcomboB.Text);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            //  short status = _primLESI.dmc_read_sevon_pin(boardId, selectAxis);
            var status = _primLESI.AxisIsEnble(selectAxis);
            //  _primLESI.dmc_write_sevon_pin(boardId, selectAxis, sta);// 0:使能  1：关使能
            _primLESI.AxisSetEnable(selectAxis, !status);
        }

        private void PrimDebugControl_Load(object sender, EventArgs e)
        {
            if (_primLESI.StopMode == StopMode.Immediate)
                combStopMode.SelectedIndex = 1;
            else
                combStopMode.SelectedIndex = 0;

            tBoxLESIName.Text = _primLESI.Name;
            txtPraAcc.Text = _primLESI.Tacc.ToString();
            txtPraDecT.Text = _primLESI.Tdec.ToString();
            txtPraVs.Text = _primLESI.MinVel.ToString();
            txtPraVm.Text = _primLESI.MaxVel.ToString();
            txtPraVe.Text = _primLESI.StopVel.ToString();
            numericUpDown2.Value = _primLESI.CANNode;
            comboBox1.SelectedIndex = _primLESI.ByteStream;

            tPageCmpTrig.Parent = null;
            tPageContinueMove.Parent = null;
            tPageLatch.Parent = null;
            tPageTrigDemo.Parent = null;

            switch (numericUpDown2.Value)
            {
                case 0:
                    canIO1.Parent = null;
                    canIO2.Parent = null;
                    canIO3.Parent = null;
                    break;

                case 1:
                    canIO1.Parent = tabControl1;
                    canIO2.Parent = null;
                    canIO3.Parent = null;
                    break;

                case 2:
                    canIO1.Parent = tabControl1;
                    canIO2.Parent = tabControl1;
                    canIO3.Parent = null;
                    break;

                default:
                    canIO1.Parent = tabControl1;
                    canIO2.Parent = tabControl1;
                    canIO3.Parent = tabControl1;
                    break;
            }
        }

        private void SetLabel(Label label, bool status)
        {
            if (label != null)
            {
                if (status)
                    label.BackColor = Color.DimGray;
                else
                    label.BackColor = Color.Green;
            }
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

                //CAN

                if (_primLESI.CANNode >= 1)
                    for (var i = 0; i < 16; i++)
                    {
                        var _lbelIn = GetCANINLabel(i);
                        var _lbelOut = GetCANOUTLabel(i);
                        if (_lbelIn != null)
                        {
                            var address = 101 + i * 0.01;
                            _primLESI.ReadSingleDInput(address, out var di);
                            SetLabel(_lbelIn, !di);
                        }

                        if (_lbelOut != null)
                        {
                            var address = 101 + i * 0.01;
                            _primLESI.ReadSingleDOutput(address, out var doo);
                            SetLabel(_lbelOut, !doo);
                        }
                    }

                if (_primLESI.CANNode >= 2)
                    for (var i = 0; i < 16; i++)
                    {
                        var _lbelIn = GetCAN2INLabel(i);
                        var _lbelOut = GetCAN2OUTLabel(i);
                        if (_lbelIn != null)
                        {
                            var address = 102 + i * 0.01;
                            _primLESI.ReadSingleDInput(address, out var di);
                            SetLabel(_lbelIn, !di);
                        }

                        if (_lbelOut != null)
                        {
                            var address = 102 + i * 0.01;
                            _primLESI.ReadSingleDOutput(address, out var doo);
                            SetLabel(_lbelOut, !doo);
                        }
                    }

                if (_primLESI.CANNode >= 3)
                    for (var i = 0; i < 16; i++)
                    {
                        var _lbelIn = GetCAN3INLabel(i);
                        var _lbelOut = GetCAN3OUTLabel(i);
                        if (_lbelIn != null)
                        {
                            var address = 103 + i * 0.01;
                            _primLESI.ReadSingleDInput(address, out var di);
                            SetLabel(_lbelIn, !di);
                        }

                        if (_lbelOut != null)
                        {
                            var address = 103 + i * 0.01;
                            _primLESI.ReadSingleDOutput(address, out var doo);
                            SetLabel(_lbelOut, !doo);
                        }
                    }

                //轴状态读取
                fun_axisIo();
                //回零
                if (zero == 1)
                {
                    var boardId = Convert.ToUInt16(CardIDcomboB.Text);
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

        private void txtPraAcc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPraAcc.Text)) return;

            // _config.Tacc = Convert.ToInt32(txtPraAcc.Text);
            _config.Tacc = Convert.ToDouble(txtPraAcc.Text);
        }

        private void txtPraDecT_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPraDecT.Text)) return;

            _config.Tdec = Convert.ToDouble(txtPraDecT.Text);
        }

        private void txtPraVe_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPraVe.Text)) return;

            _config.StopVel = Convert.ToInt32(txtPraVe.Text);
        }

        private void txtPraVm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPraVm.Text)) return;

            _config.MaxVel = Convert.ToInt32(txtPraVm.Text);
        }

        private void txtPraVs_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPraVs.Text)) return;

            _config.MinVel = Convert.ToInt32(txtPraVs.Text);
        }

        private bool VerifyAuthority()
        {
            if (AuthorityManager.Instance.Level < OpLevel.Level3 &&
                AuthorityManager.Instance.Level != OpLevel.Other)
            {
                MessageBox.Show(
                    NLocalizer.GetString("PrimLEIS_PrimDebugControl_ConfirmPermission",
                        "The current user does not have permission. Please confirm that the permission is in operation."),
                    NLocalizer.GetString("PrimLEIS_PrimDebugControl_Info", "Info"), MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        //获取轴状态
        public void fun_axisIo()
        {
            var cardID = Convert.ToUInt16(CardIDcomboB.SelectedItem);
            var selectAxis = Convert.ToUInt16(cmbSelectAxis.SelectedItem);
            double currentPosUnit = 0, currentEncoderUnit = 0;
            _primLESI.GetAxisCommand(selectAxis, ref currentPosUnit);
            _primLESI.GetFeedbackPulse(selectAxis, ref currentEncoderUnit);
            txtCommandPosition.Text = Convert.ToString(currentPosUnit);
            txtFeedbackPosition.Text = Convert.ToString(currentEncoderUnit);

            BT_LED_ALM.BackColor = _primLESI.AxisIsAlarm(selectAxis) ? Color.Red : Color.DimGray;
            BT_LED_ELP.BackColor = _primLESI.AxisInPel(selectAxis) ? Color.Red : Color.DimGray;
            BT_LED_ELN.BackColor = _primLESI.AxisInMel(selectAxis) ? Color.Red : Color.DimGray;
            BT_LED_EMG.BackColor = _primLESI.AxisSignalEmg(selectAxis) ? Color.Red : Color.DimGray;
            BT_LED_ORG.BackColor = _primLESI.AxisInPel(selectAxis) ? Color.Green : Color.DimGray;
            BT_LED_SLP.BackColor = _primLESI.AxisInSPel(selectAxis) ? Color.Red : Color.DimGray;
            BT_LED_SLN.BackColor = _primLESI.AxisInSMel(selectAxis) ? Color.Red : Color.DimGray;
            BT_LED_INP.BackColor = _primLESI.AxisSignalInp(selectAxis) ? Color.Green : Color.DimGray;
            BT_LED_EZ.BackColor = _primLESI.AxisSignalEz(selectAxis) ? Color.Green : Color.DimGray;
            BT_LED_RDY.BackColor = _primLESI.AxisSignalRdy(selectAxis) ? Color.Green : Color.DimGray;
            BT_LED_SON.BackColor = _primLESI.AxisIsEnble(selectAxis) ? Color.Green : Color.DimGray;
            lblServoOn.BackColor = _primLESI.AxisIsEnble(selectAxis) ? Color.Green : Color.DimGray;
        }

        public void SetPrimConnState(PrimConnState state)
        {
            if (tBoxConnState.InvokeRequired)
            {
                UpdatePrimConnState update = SetPrimConnState;
                Invoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        break;

                    case PrimConnState.Connected:
                        tBoxConnState.BackColor = Color.LightGreen;
                        tBoxConnState.Text = "Connected";
                        break;

                    case PrimConnState.Other:
                        tBoxConnState.BackColor = Color.Khaki;
                        tBoxConnState.Text = "UnConnected";
                        break;
                }
            }
        }

        public void SetPrimRunState(PrimRunState state)
        {
            if (tBoxRunState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdatePrimRunState(SetPrimRunState);
                Invoke(update, state);
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
                        break;

                    case PrimRunState.Err:
                        tBoxRunState.BackColor = Color.SandyBrown;
                        tBoxRunState.Text = "Err";
                        break;

                    case PrimRunState.Other:
                        tBoxRunState.BackColor = Color.Khaki;
                        tBoxRunState.Text = "Idle";
                        break;
                }
            }
        }
    }
}