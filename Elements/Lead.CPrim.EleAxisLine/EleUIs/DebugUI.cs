using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.CommonTools;
using Lead.CPrim.Interfaces;
using Lead.CPrim.LocalizationService;

namespace Lead.CPrim.EleAxisLine
{
    public partial class DebugUI : UserControl
    {
        public delegate void UpdateControl();

        private EleAxisLineConfig _config;

        private IEle _ele;

        private EleAxisLine _eleAxisLine;

        private string msg = "";

        public DebugUI()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void btnGoPos_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine == null || _config == null || string.IsNullOrEmpty(tBoxGoPos.Text)) return;

            var pos = double.Parse(tBoxGoPos.Text);
            _eleAxisLine.MC_MoveAbsolute(pos);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine.EleRunStat != EleRunState.Running || !_eleAxisLine.IsEnable) return;

            if (_eleAxisLine.HomeMode == -1)
                _eleAxisLine.MC_Home();
            else
                _eleAxisLine.MC_Home(_eleAxisLine.HomeMode);
        }

        private void btnJogAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (_eleAxisLine != null && _config != null) _eleAxisLine.MC_MoveJog(true, _eleAxisLine.JogVelocity);
        }

        private void btnJogAdd_MouseUp(object sender, MouseEventArgs e)
        {
            if (_eleAxisLine != null && _config != null) _eleAxisLine.MC_Stop();
        }

        private void btnJogDec_Click(object sender, EventArgs e)
        {
        }

        private void btnJogDec_MouseDown(object sender, MouseEventArgs e)
        {
            if (_eleAxisLine != null && _config != null) _eleAxisLine.MC_MoveJog(false, _eleAxisLine.JogVelocity);
        }

        private void btnJogDec_MouseUp(object sender, MouseEventArgs e)
        {
            if (_eleAxisLine != null && _config != null) _eleAxisLine.MC_Stop();
        }

        private void btnMovePos_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine == null || _config == null || string.IsNullOrEmpty(tBoxGoPos.Text)) return;

            var pos = int.Parse(cBoxPosIndex.Text);
            _eleAxisLine.MC_MoveAbsolute(pos);
        }

        private void btnRelAdd_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine != null && _config != null)
                _eleAxisLine.MC_MoveRelative(_eleAxisLine.JogDistance, _eleAxisLine.JogVelocity);
        }

        private void btnRelDec_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine != null && _config != null)
                _eleAxisLine.MC_MoveRelative(0 - _eleAxisLine.JogDistance, _eleAxisLine.JogVelocity);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine != null && _config != null) _eleAxisLine.MC_Reset();
        }

        private void btnServoOn_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine != null && _config != null) _eleAxisLine.MC_Power(_eleAxisLine.IsEnable);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine.EleRunStat != EleRunState.Running || !_eleAxisLine.IsEnable) return;
            _eleAxisLine.MC_Stop();
        }

        private void DebugUI_Load(object sender, EventArgs e)
        {
            if (_eleAxisLine.EleRunStat == EleRunState.Other) _eleAxisLine.IEleInit();
            CreatTable();
        }

        private void InitializeUI()
        {
            lbName.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Name", "Name");
            lbState.Text = NLocalizer.GetString("EleAxisLine_DebugUI_State", "State");
            tabPage1.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Config", "Config");
            tabPage2.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Data", "Data");
            groupBox4.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Target", "Target");
            label1.Text = NLocalizer.GetString("EleAxisLine_DebugUI_CommandPosition", "CmmandPos:");
            label2.Text = NLocalizer.GetString("EleAxisLine_DebugUI_CommandVelocity", "CmmandVel:");
            groupBox3.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Actual", "Actual");
            label3.Text = NLocalizer.GetString("EleAxisLine_DebugUI_ActualPosition", "ActualPos:");
            label4.Text = NLocalizer.GetString("EleAxisLine_DebugUI_ActualVelocity", "ActualVel:");
            groupBox1.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Move", "Move");
            label32.Text = NLocalizer.GetString("EleAxisLine_DebugUI_RelativeDistance", "RelDistance:");
            label8.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Positiion", "Pos:");
            label7.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Positiion", "Pos:");
            btnGoPos.Text = NLocalizer.GetString("EleAxisLine_DebugUI_GO", "GO");
            btnMovePos.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Move", "Move");
            groupBox2.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Control", "Control");
            btnServoOn.Text = NLocalizer.GetString("EleAxisLine_DebugUI_ServoOn", "ServoOn");
            btnHome.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Home", "Home");
            btnReset.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Reset", "Reset");
            btnStop.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Stop", "Stop");
            toolStripStatusLabel3.Text = NLocalizer.GetString("EleAxisLine_DebugUI_Status", "Status");
        }

        private void tBoxJogDistance_TextChanged(object sender, EventArgs e)
        {
            _eleAxisLine.JogDistance = double.Parse(tBoxJogDistance.Text);
        }

        public void CreatTable()
        {
            if (dgvDataConfigs.Columns.Count > 0) return;

            dgvDataConfigs.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 7, FontStyle.Bold);
            dgvDataConfigs.Columns.Add("dgvIndex", "Index");
            dgvDataConfigs.Columns.Add("dgvName", "Name");
            dgvDataConfigs.Columns.Add("dgvPosition", "Position");
            dgvDataConfigs.Columns.Add("dgvVelocity", "Velocity");
            dgvDataConfigs.Columns.Add("dgvAcceleration", "Acceleration");
            dgvDataConfigs.Columns.Add("dgvDeceleration", "Deceleration");
            dgvDataConfigs.Columns.Add("dgvMinVelocity", "MinVelocity");
            dgvDataConfigs.Columns.Add("dgvAccTime", "AccTime");
            dgvDataConfigs.Columns.Add("dgvDecTime", "DecTime");

            for (var i = 0; i < dgvDataConfigs.Columns.Count; i++)
            {
                dgvDataConfigs.Columns[i].Width = 60;
                dgvDataConfigs.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvDataConfigs.Columns[i].DefaultCellStyle.Font = new Font("微软雅黑", 7);
            }

            dgvDataConfigs.Columns[0].Width = 50;
            dgvDataConfigs.Columns[0].ReadOnly = true;

            //var teachColumn = new DataGridViewButtonColumn();
            //teachColumn.Name = "dgvTeach";
            //teachColumn.HeaderText = "TeachButton";
            //teachColumn.Text = "Teach";
            //teachColumn.DefaultCellStyle.NullValue = "Teach";
            //teachColumn.DefaultCellStyle.Font = new Font("微软雅黑", 10, FontStyle.Bold);
            //teachColumn.Width = 100;
            //teachColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //dgvDataConfigs.Columns.Add(teachColumn);
            if (dgvDataConfigs.Rows.Count > 0) dgvDataConfigs.Rows.Clear();

            if (_eleAxisLine.IsSimulateMode)
                if (_eleAxisLine.EleRunStat == EleRunState.Other)
                    _eleAxisLine.IEleInit();
        }

        public void DataTableUpdate()
        {
            if (_eleAxisLine?.DataConfigs?.ListAxisDataConfigs == null) return;

            dgvDataConfigs.Rows.Clear();

            if (_eleAxisLine.DataConfigs.ListAxisDataConfigs.Count < 1) return;

            try
            {
                foreach (var config in _eleAxisLine.DataConfigs.ListAxisDataConfigs)
                {
                    var index = dgvDataConfigs.Rows.Add();
                    dgvDataConfigs.Rows[index].Cells[0].Value = config.Index;
                    dgvDataConfigs.Rows[index].Cells[1].Value = config.Name;
                    dgvDataConfigs.Rows[index].Cells[2].Value = config.Position.ToString("F2");
                    dgvDataConfigs.Rows[index].Cells[3].Value = config.Velocity.ToString("F2");
                    dgvDataConfigs.Rows[index].Cells[4].Value = config.Acceleration.ToString("F2");
                    dgvDataConfigs.Rows[index].Cells[5].Value = config.Deceleration.ToString("F2");
                    dgvDataConfigs.Rows[index].Cells[6].Value = config.MinVelocity.ToString("F2");
                    dgvDataConfigs.Rows[index].Cells[7].Value = config.AccTime.ToString("F2");
                    dgvDataConfigs.Rows[index].Cells[8].Value = config.DecTime.ToString("F2");
                    cBoxPosIndex.Items.Add(config.Index);
                }

                dgvDataConfigs.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetEleConfig(EleAxisLine eleAxisLine)
        {
            _eleAxisLine = eleAxisLine;
            tBoxName.Text = _eleAxisLine.Name;
        }

        public void SetEleRunState(EleRunState state)
        {
            if (tBoxState.InvokeRequired) //指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中
            {
                var update = new UpdateEleRunState(SetEleRunState);
                BeginInvoke(update, state);
            }
            else
            {
                switch (state)
                {
                    case EleRunState.Idle:
                        tBoxState.BackColor = Color.Khaki;
                        tBoxState.Text = "Idle";
                        break;

                    case EleRunState.Running:
                        tBoxState.BackColor = Color.LightGreen;
                        tBoxState.Text = "Running";
                        break;

                    case EleRunState.Err:
                        tBoxState.BackColor = Color.SandyBrown;
                        tBoxState.Text = "Err";
                        break;

                    case EleRunState.Other:
                        tBoxState.BackColor = Color.Khaki;
                        tBoxState.Text = "Other";
                        break;
                }
            }
        }

        public void UiRefresh()
        {
            if (_eleAxisLine == null || _config == null) return;

            if (_eleAxisLine.EleRunStat == EleRunState.Other) _eleAxisLine.IEleInit();
            if (_eleAxisLine.IsEnable)
            {
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelServoOn, Color.Green);
                ControlHelper.ChangeButtonBackColor(ref btnServoOn, Color.Green);
                ControlHelper.ChangeButtonText(ref btnServoOn, "ServoOn");
            }
            else
            {
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelServoOn, Color.Red);
                ControlHelper.ChangeButtonBackColor(ref btnServoOn, Color.Red);
                ControlHelper.ChangeButtonText(ref btnServoOn, "ServoOff");
            }

            SetEleRunState(_eleAxisLine.EleRunStat);

            if (_eleAxisLine.IsStop)
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelStop, Color.Red);
            else
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelStop, Color.Gray);
            if (_eleAxisLine.IsAlarm)
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelAlarm, Color.Red);
            else
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelAlarm, Color.Gray);
            if (_eleAxisLine.InPel)
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelPel, Color.Red);
            else
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelPel, Color.Gray);
            if (_eleAxisLine.InOrigin)
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelOrigin, Color.Green);
            else
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelOrigin, Color.Gray);
            if (_eleAxisLine.InMel)
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelMel, Color.Red);
            else
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelMel, Color.Gray);
            if (_eleAxisLine.SignalInp)
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelInp, Color.Green);
            else
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelInp, Color.Gray);
            if (_eleAxisLine.SignalEz)
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelEz, Color.Green);
            else
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelEz, Color.Gray);
            if (_eleAxisLine.SignalEmg)
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelEmg, Color.Red);
            else
                ControlHelper.ChangeStatusLabelBackColor(ref sStripStatus, ref lbelEmg, Color.Gray);
            ControlHelper.ChangeLabelText(ref lbelCmdPos, _eleAxisLine.CmdPosition.ToString("F2"));
            ControlHelper.ChangeLabelText(ref lbelCmdVel, _eleAxisLine.CmdVelocity.ToString("F2"));
            ControlHelper.ChangeLabelText(ref lbelActualPos1, _eleAxisLine.ActualPosition.ToString("F2"));
            ControlHelper.ChangeLabelText(ref lbelActualVel1, _eleAxisLine.ActualVelocity.ToString("F2"));
            DataTableUpdate();
        }

        public void UiRefresh1()
        {
            if (_eleAxisLine == null || _config == null || !_config.IsSimulateMode) return;

            if (_eleAxisLine.EleRunStat == EleRunState.Other) _eleAxisLine.IEleInit();

            if (InvokeRequired)
            {
                var update = new UpdateControl(UiRefresh1);
                BeginInvoke(update);
            }
            else
            {
                if (_eleAxisLine.IsEnable)
                {
                    lbelServoOn.BackColor = Color.Green;
                    btnServoOn.BackColor = Color.Green;
                    btnServoOn.Text = "ServoOn";
                }
                else
                {
                    lbelServoOn.BackColor = Color.Red;
                    btnServoOn.BackColor = Color.Red;
                    btnServoOn.Text = "ServoOff";
                }

                lbelStop.BackColor = _eleAxisLine.IsStop ? Color.Red : Color.Gray;
                lbelAlarm.BackColor = _eleAxisLine.IsAlarm ? Color.Red : Color.Gray;
                lbelPel.BackColor = _eleAxisLine.InPel ? Color.Red : Color.Gray;
                lbelOrigin.BackColor = _eleAxisLine.InOrigin ? Color.Green : Color.Gray;
                lbelMel.BackColor = _eleAxisLine.InMel ? Color.Red : Color.Gray;
                lbelInp.BackColor = _eleAxisLine.SignalInp ? Color.Green : Color.Gray;
                lbelEz.BackColor = _eleAxisLine.SignalEz ? Color.Green : Color.Gray;
                lbelEmg.BackColor = _eleAxisLine.SignalEmg ? Color.Red : Color.Gray;
                lbelActualPos1.Text = _eleAxisLine.ActualPosition.ToString("F2");
                lbelActualVel1.Text = _eleAxisLine.ActualVelocity.ToString("F2");
                lbelCmdPos.Text = _eleAxisLine.CmdPosition.ToString("F2");
                lbelCmdVel.Text = _eleAxisLine.CmdVelocity.ToString("F2");
                SetEleRunState(_eleAxisLine.EleRunStat);
                DataTableUpdate();
            }
        }

        public void UpdataEleConfig(EleAxisLineConfig Config)
        {
            _config = Config;
            tBoxName.Text = _config.Name;
            //tBoxTableDataPath.Text = _config.DataTablePath;
            CreatTable();
            var iRet = _eleAxisLine.ImportDataTable(_config.DataTablePath);
            if (iRet != 0) return;
            DataTableUpdate();
        }

        private delegate void UpdateEleRunState(EleRunState state);
    }
}