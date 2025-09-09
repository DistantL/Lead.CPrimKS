using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Lead.CPrim.CommonTools;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.LocalizationService;

namespace Lead.CPrim.EleAxisLine
{
    public partial class ConfigUI : UserControl
    {
        public delegate void UpdateControl();

        private EleAxisLineConfig _config;

        private IEle _ele;
        private EleAxisLine _eleAxisLine;

        public ConfigUI()
        {
            InitializeComponent();
        }

        public ConfigUI(EleAxisLineConfig config)
        {
            _config = config;
        }
        
        private void ConfigUI_Load(object sender, EventArgs e)
        {
            CreatTable();
            if (_eleAxisLine.Enable)
                if (_eleAxisLine.EleRunStat == EleRunState.Other)
                    _eleAxisLine.IEleInit();
            dgvDataConfigs.CellValueChanged -= DgvDataConfigs_CellValueChanged;
            dgvDataConfigs.CellValueChanged += DgvDataConfigs_CellValueChanged;
            btnTableLoad_Click(null, null);
        }

        private void ConfigUI_Click(object sender, EventArgs e)
        {
            _eleAxisLine.IsSelected = !_eleAxisLine.IsSelected;
        }

        public void SetEleConfig(EleAxisLine eleAxisLine)
        {
            _eleAxisLine = eleAxisLine;

            chkEnable.Checked = _eleAxisLine.Enable;
            chkSimulate.Checked = _eleAxisLine.IsSimulateMode;

            tBoxName.Text = _eleAxisLine.Name;
            tBoxInfo.Text = _eleAxisLine.Info;
            tBoxType.Text = _eleAxisLine.EleTypeName;

            if (_eleAxisLine.DriveType == AxisType.Servo)
                cBoxDriveType.Text = "Servo";
            else if (_eleAxisLine.DriveType == AxisType.Step)
                cBoxDriveType.Text = "Step";
            else
                cBoxDriveType.Text = "Other";

            if (_eleAxisLine.ControlType == ControlType.ClosedLoop)
                cBoxControlType.Text = "ClosedLoop";
            else if (_eleAxisLine.ControlType == ControlType.OpendLoop)
                cBoxControlType.Text = "OpendLoop";
            else
                cBoxControlType.Text = "Other";

            if (_eleAxisLine.EncoderType == FeedBackType.Incremental)
                cBoxFeedBackType.Text = "Incremental";
            else if (_eleAxisLine.EncoderType == FeedBackType.Absolute)
                cBoxFeedBackType.Text = "Absolute";
            else
                cBoxFeedBackType.Text = "Other";

            tBoxDevName.Text = _eleAxisLine.DevName;
            tBoxCradNum.Text = _eleAxisLine.CardNum.ToString();
            tBoxAxisNum.Text = _eleAxisLine.AxisNum.ToString();
            tBoxLead.Text = _eleAxisLine.AxisLead.ToString();
            tBoxPlsPerRoll.Text = _eleAxisLine.PlsPerRoll.ToString();
            tbHomeMode.Text = _eleAxisLine.HomeMode.ToString();
            if (_eleAxisLine.AccDecType == AccDecType.Velocity)
            {
                cBoxAccDecMode.Text = "Velocity";
                SetDgvDataConfigsMode(AccDecType.Velocity);
            }
            else if (_eleAxisLine.AccDecType == AccDecType.Time)
            {
                cBoxAccDecMode.Text = "Time";
                SetDgvDataConfigsMode(AccDecType.Time);
            }
            else
            {
                cBoxAccDecMode.Text = "Other";
                SetDgvDataConfigsMode(AccDecType.Other);
            }

            if (_eleAxisLine.StopMode == StopMode.Immediate)
                cBoxStopMode.Text = "Immediate";
            else if (_eleAxisLine.StopMode == StopMode.Free)
                cBoxStopMode.Text = "Free";
            else
                cBoxAccDecMode.Text = "Other";

            tBoxErrChkRange.Text = _eleAxisLine.ErrChkRange.ToString();
            tBoxJogVelocity.Text = _eleAxisLine.JogVelocity.ToString(CultureInfo.InvariantCulture);
            tBoxJogDistance.Text = _eleAxisLine.JogDistance.ToString(CultureInfo.InvariantCulture);
            tBoxHomeVel.Text = _eleAxisLine.HomeVelocity.ToString(CultureInfo.InvariantCulture);

            cBoxSwLimitEnable.Checked = _eleAxisLine.SwLimitEnable;
            cBoxHwLimitEnable.Checked = _eleAxisLine.CheckLimitEnable;
            tBoxSwPot.Text = _eleAxisLine.SPel.ToString(CultureInfo.InvariantCulture);
            tBoxSwNot.Text = _eleAxisLine.SMel.ToString(CultureInfo.InvariantCulture);
            tBoxLimVelP.Text = _eleAxisLine.LimVelP.ToString(CultureInfo.InvariantCulture);
            tBoxLimVelN.Text = _eleAxisLine.LimVelN.ToString(CultureInfo.InvariantCulture);

            tBoxDefaultVel.Text = _eleAxisLine.DefaultParams.Velocity.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultAcc.Text = _eleAxisLine.DefaultParams.Acceleration.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultDec.Text = _eleAxisLine.DefaultParams.Deceleration.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultMinVel.Text = _eleAxisLine.DefaultParams.MinVelocity.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultAccTime.Text = _eleAxisLine.DefaultParams.AccTime.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultDecTime.Text = _eleAxisLine.DefaultParams.DecTime.ToString(CultureInfo.InvariantCulture);
            tBoxStandByIndex.Text = _eleAxisLine.StandByIndex.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultStopVel.Text = _eleAxisLine.DefaultParams.StopVel.ToString(CultureInfo.InvariantCulture);
        }

        private void SetDgvDataConfigsMode(AccDecType type)
        {
            if (dgvDataConfigs == null) return;

            for (var i = 0; i < dgvDataConfigs.Columns.Count; i++)
                if (dgvDataConfigs.Columns[i].Name.ToLower().Contains("acceleration"))
                    dgvDataConfigs.Columns[i].Visible = type != AccDecType.Time;
                else if (dgvDataConfigs.Columns[i].Name.ToLower().Contains("deceleration"))
                    dgvDataConfigs.Columns[i].Visible = type != AccDecType.Time;
                else if (dgvDataConfigs.Columns[i].Name.ToLower().Contains("minvelocity"))
                    dgvDataConfigs.Columns[i].Visible = type != AccDecType.Velocity;
                else if (dgvDataConfigs.Columns[i].Name.ToLower().Contains("acctime"))
                    dgvDataConfigs.Columns[i].Visible = type != AccDecType.Velocity;
                else if (dgvDataConfigs.Columns[i].Name.ToLower().Contains("dectime"))
                    dgvDataConfigs.Columns[i].Visible = type != AccDecType.Velocity;
        }

        public void UpdataEleConfig(EleAxisLineConfig config)
        {
            _config = config;

            tBoxName.Text = _config.Name;
            tBoxInfo.Text = _config.Info;
            tBoxType.Text = _config.EleTypeName;

            chkEnable.Checked = _config.Enable;
            chkSimulate.Checked = _config.IsSimulateMode;
            CreatTable();
            tBoxTableDataPath.Text = _config.DataTablePath;
            var iRet = _eleAxisLine.ImportDataTable(_config.DataTablePath);
            if (iRet != 0) return;
            DataTableUpdate();
            if (_config.DriveType == AxisType.Servo)
                cBoxDriveType.Text = "Servo";
            else if (_config.DriveType == AxisType.Step)
                cBoxDriveType.Text = "Step";
            else
                cBoxDriveType.Text = "Other";

            if (_config.ControlType == ControlType.ClosedLoop)
                cBoxControlType.Text = "ClosedLoop";
            else if (_config.ControlType == ControlType.OpendLoop)
                cBoxControlType.Text = "OpendLoop";
            else
                cBoxControlType.Text = "Other";

            if (_config.EncoderType == FeedBackType.Incremental)
                cBoxFeedBackType.Text = "Incremental";
            else if (_config.EncoderType == FeedBackType.Absolute)
                cBoxFeedBackType.Text = "Absolute";
            else
                cBoxFeedBackType.Text = "Other";

            tBoxDevName.Text = _config.DevName;
            tBoxCradNum.Text = _config.CardNum.ToString();
            tBoxAxisNum.Text = _config.AxisNum.ToString();
            tBoxLead.Text = _eleAxisLine.AxisLead.ToString();
            tBoxPlsPerRoll.Text = _eleAxisLine.PlsPerRoll.ToString();
            tbHomeMode.Text = _config.HomeMode.ToString();
            if (_config.AccDecType == AccDecType.Velocity)
            {
                cBoxAccDecMode.Text = "Velocity";
                SetDgvDataConfigsMode(AccDecType.Velocity);
            }
            else if (_config.AccDecType == AccDecType.Time)
            {
                cBoxAccDecMode.Text = "Time";
                SetDgvDataConfigsMode(AccDecType.Time);
            }
            else
            {
                cBoxAccDecMode.Text = "Other";
                SetDgvDataConfigsMode(AccDecType.Other);
            }

            if (_config.StopMode == StopMode.Immediate)
                cBoxStopMode.Text = "Immediate";
            else if (_config.StopMode == StopMode.Free)
                cBoxStopMode.Text = "Free";
            else
                cBoxStopMode.Text = "Other";

            tBoxErrChkRange.Text = _config.ErrChkRange.ToString();
            tBoxJogVelocity.Text = _config.JogVelocity.ToString(CultureInfo.InvariantCulture);
            tBoxJogDistance.Text = _config.JogDistance.ToString(CultureInfo.InvariantCulture);
            tBoxHomeVel.Text = _config.HomeVelocity.ToString(CultureInfo.InvariantCulture);
            cBoxSwLimitEnable.Checked = _config.SwLimitEnable;
            cBoxHwLimitEnable.Checked = _config.CheckLimitEnable;
            tBoxSwPot.Text = _config.SwPot.ToString(CultureInfo.InvariantCulture);
            tBoxSwNot.Text = _config.SwNot.ToString(CultureInfo.InvariantCulture);

            tBoxLimVelP.Text = _config.LimVelP.ToString(CultureInfo.InvariantCulture);
            tBoxLimVelN.Text = _config.LimVelN.ToString(CultureInfo.InvariantCulture);

            tBoxDefaultVel.Text = _config.DefaultParams.Velocity.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultAcc.Text = _config.DefaultParams.Acceleration.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultDec.Text = _config.DefaultParams.Deceleration.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultMinVel.Text = _config.DefaultParams.MinVelocity.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultAccTime.Text = _config.DefaultParams.AccTime.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultDecTime.Text = _config.DefaultParams.DecTime.ToString(CultureInfo.InvariantCulture);
            tBoxDefaultStopVel.Text = _config.DefaultParams.StopVel.ToString(CultureInfo.InvariantCulture);
        }

        private void cBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkEnable.Checked) return;
            var prim = PrimsManager.Instance.GetPrimByName(_eleAxisLine.DevName);
            if (prim == null)
                //MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_DeviceWithName", "Device with Name：") + _eleAxisLine.DevName + NLocalizer.GetString("EleAxisLine_ConfigUI_NotFound", " not found! "));
                return;

            //_eleAxisLine.Init();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvDataConfigs.Rows.Add();
            var index = dgvDataConfigs.Rows.Count - 1;
            dgvDataConfigs.Rows[index].Cells[0].Value = index;
            dgvDataConfigs.Rows[index].Cells[1].Value = "Pos" + index;
            dgvDataConfigs.Rows[index].Cells[2].Value = _eleAxisLine.ActualPosition.ToString("F2");
            dgvDataConfigs.Rows[index].Cells[3].Value = _eleAxisLine.DefaultParams.Velocity.ToString("F2");
            dgvDataConfigs.Rows[index].Cells[4].Value = _eleAxisLine.DefaultParams.Acceleration.ToString("F2");
            dgvDataConfigs.Rows[index].Cells[5].Value = _eleAxisLine.DefaultParams.Deceleration.ToString("F2");
            dgvDataConfigs.Rows[index].Cells[6].Value = _eleAxisLine.DefaultParams.MinVelocity.ToString("F2");
            dgvDataConfigs.Rows[index].Cells[7].Value = _eleAxisLine.DefaultParams.AccTime.ToString("F2");
            dgvDataConfigs.Rows[index].Cells[8].Value = _eleAxisLine.DefaultParams.DecTime.ToString("F2");
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (dgvDataConfigs.Rows.Count <= 0) return;

            var curSelectedIdx = dgvDataConfigs.CurrentCell.RowIndex;
            dgvDataConfigs.Rows.RemoveAt(curSelectedIdx);
        }

        private void btnTableBrowse_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            tBoxTableDataPath.Text = openFileDialog.FileName;

            if (string.IsNullOrEmpty(tBoxTableDataPath.Text)) return;

            if (!File.Exists(tBoxTableDataPath.Text))
            {
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_SelectedFileNotExist",
                    "The selected file does not exist!"));
                return;
            }

            if (_config?.DataTablePath != null) _config.DataTablePath = tBoxTableDataPath.Text;
        }

        private void btnTableLoad_Click(object sender, EventArgs e)
        {
            if (_config == null || string.IsNullOrEmpty(_config.DataTablePath)) return;

            if (_eleAxisLine == null) return;
            var iRet = _eleAxisLine.ImportDataTable(_config.DataTablePath);
            if (iRet != 0) return;

            DataTableUpdate();
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
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
                dgvDataConfigs.Columns[i].Width = 120;
                dgvDataConfigs.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvDataConfigs.Columns[i].DefaultCellStyle.Font = new Font("微软雅黑", 7);
            }

            dgvDataConfigs.Columns[0].Width = 50;
            dgvDataConfigs.Columns[0].ReadOnly = true;

            var teachColumn = new DataGridViewButtonColumn
            {
                Name = "dgvTeach",
                HeaderText = "TeachButton",
                Text = "Teach",
                DefaultCellStyle = {NullValue = "Teach", Font = new Font("微软雅黑", 10, FontStyle.Bold)},
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            dgvDataConfigs.Columns.Add(teachColumn);
            if (dgvDataConfigs.Rows.Count > 0) dgvDataConfigs.Rows.Clear();

            if (_eleAxisLine.IsSimulateMode)
                if (_eleAxisLine.EleRunStat == EleRunState.Other)
                    _eleAxisLine.IEleInit();
        }

        private void btnTableSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                var savePath = saveFileDialog.FileName;
                _eleAxisLine.ExportDataTable(savePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), NLocalizer.GetString("EleAxisLine_ConfigUI_Info", "Info"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cBoxHomeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnDataApply_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.Level < OpLevel.Maintenance &&
                AuthorityManager.Instance.Level != OpLevel.Other)
            {
                MessageBox.Show(
                    NLocalizer.GetString("EleAxisLine_ConfigUI_ConfirmPermission",
                        "The current user does not have permission. Please confirm that the permission is in operation."),
                    NLocalizer.GetString("EleAxisLine_ConfigUI_Info", "Info"), MessageBoxButtons.OK);
                return;
            }

            var rowCount = dgvDataConfigs.Rows.Count;

            if (rowCount < 1) return;

            _eleAxisLine.DataConfigs.ListAxisDataConfigs.Clear();

            for (var i = 0; i < rowCount; i++)
            {
                var dtConfig = new AxisDataConfig
                {
                    Index = dgvDataConfigs.Rows[i].Cells[0].Value == null
                        ? -1
                        : int.Parse(dgvDataConfigs.Rows[i].Cells[0].Value.ToString()),
                    Name = dgvDataConfigs.Rows[i].Cells[1].Value == null
                        ? ""
                        : dgvDataConfigs.Rows[i].Cells[1].Value.ToString(),
                    Position = dgvDataConfigs.Rows[i].Cells[2].Value == null
                        ? -1
                        : double.Parse(dgvDataConfigs.Rows[i].Cells[2].Value.ToString()),
                    Velocity = dgvDataConfigs.Rows[i].Cells[3].Value == null
                        ? -1
                        : double.Parse(dgvDataConfigs.Rows[i].Cells[3].Value.ToString()),
                    Acceleration = dgvDataConfigs.Rows[i].Cells[4].Value == null
                        ? -1
                        : double.Parse(dgvDataConfigs.Rows[i].Cells[4].Value.ToString()),
                    Deceleration = dgvDataConfigs.Rows[i].Cells[5].Value == null
                        ? -1
                        : double.Parse(dgvDataConfigs.Rows[i].Cells[5].Value.ToString()),
                    MinVelocity = dgvDataConfigs.Rows[i].Cells[6].Value == null
                        ? -1
                        : double.Parse(dgvDataConfigs.Rows[i].Cells[6].Value.ToString()),
                    AccTime = dgvDataConfigs.Rows[i].Cells[7].Value == null
                        ? -1
                        : double.Parse(dgvDataConfigs.Rows[i].Cells[7].Value.ToString()),
                    DecTime = dgvDataConfigs.Rows[i].Cells[8].Value == null
                        ? -1
                        : double.Parse(dgvDataConfigs.Rows[i].Cells[8].Value.ToString())
                };


                _eleAxisLine.DataConfigs.ListAxisDataConfigs.Add(dtConfig);
                _eleAxisLine.ExportDataTable(_config.DataTablePath);
            }
        }

        private void btnConfigApply_Click_1(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.Level < OpLevel.Maintenance &&
                AuthorityManager.Instance.Level != OpLevel.Other)
            {
                MessageBox.Show(
                    NLocalizer.GetString("EleAxisLine_ConfigUI_ConfirmPermission",
                        "The current user does not have permission. Please confirm that the permission is in operation."),
                    NLocalizer.GetString("EleAxisLine_ConfigUI_Info", "Info"), MessageBoxButtons.OK);
                return;
            }

            if (string.IsNullOrEmpty(tBoxName.Text)) return;
            _eleAxisLine.Name = tBoxName.Text;
            _eleAxisLine.Info = tBoxInfo.Text;
            _eleAxisLine.EleTypeName = "EleAxisLine";
            _eleAxisLine.Enable = chkEnable.Checked;
            _eleAxisLine.IsSimulateMode = chkSimulate.Checked;

            switch (cBoxDriveType.Text)
            {
                case "Servo":
                    _eleAxisLine.DriveType = AxisType.Servo;
                    break;
                case "Step":
                    _eleAxisLine.DriveType = AxisType.Step;
                    break;
                default:
                    _eleAxisLine.DriveType = AxisType.Other;
                    break;
            }

            switch (cBoxControlType.Text)
            {
                case "ClosedLoop":
                    _eleAxisLine.ControlType = ControlType.ClosedLoop;
                    break;
                case "OpendLoop":
                    _eleAxisLine.ControlType = ControlType.OpendLoop;
                    break;
                default:
                    _eleAxisLine.ControlType = ControlType.Other;
                    break;
            }

            switch (cBoxFeedBackType.Text)
            {
                case "Incremental":
                    _eleAxisLine.EncoderType = FeedBackType.Incremental;
                    break;
                case "Absolute":
                    _eleAxisLine.EncoderType = FeedBackType.Absolute;
                    break;
                default:
                    _eleAxisLine.EncoderType = FeedBackType.Other;
                    break;
            }

            _eleAxisLine.DevName = tBoxDevName.Text;
            if (!string.IsNullOrEmpty(tBoxCradNum.Text)) _eleAxisLine.CardNum = int.Parse(tBoxCradNum.Text);

            if (!string.IsNullOrEmpty(tBoxAxisNum.Text)) _eleAxisLine.AxisNum = int.Parse(tBoxAxisNum.Text);

            if (!string.IsNullOrEmpty(tBoxLead.Text)) _eleAxisLine.AxisLead = double.Parse(tBoxLead.Text);
            if (!string.IsNullOrEmpty(tBoxPlsPerRoll.Text)) _eleAxisLine.PlsPerRoll = double.Parse(tBoxPlsPerRoll.Text);

            switch (cBoxAccDecMode.Text)
            {
                case "Velocity":
                    _eleAxisLine.AccDecType = AccDecType.Velocity;
                    SetDgvDataConfigsMode(AccDecType.Velocity);
                    break;
                case "Time":
                    _eleAxisLine.AccDecType = AccDecType.Time;
                    SetDgvDataConfigsMode(AccDecType.Time);
                    break;
                default:
                    _eleAxisLine.AccDecType = AccDecType.Other;
                    SetDgvDataConfigsMode(AccDecType.Other);
                    break;
            }

            switch (cBoxStopMode.Text)
            {
                case "Immediate":
                    _eleAxisLine.StopMode = StopMode.Immediate;
                    break;
                case "Free":
                    _eleAxisLine.StopMode = StopMode.Free;
                    break;
                default:
                    _eleAxisLine.StopMode = StopMode.Other;
                    break;
            }

            if (!string.IsNullOrEmpty(tbHomeMode.Text)) _eleAxisLine.HomeMode = int.Parse(tbHomeMode.Text);

            if (!string.IsNullOrEmpty(tBoxErrChkRange.Text)) _eleAxisLine.ErrChkRange = int.Parse(tBoxErrChkRange.Text);

            if (!string.IsNullOrEmpty(tBoxStandByIndex.Text))
                _eleAxisLine.StandByIndex = int.Parse(tBoxStandByIndex.Text);

            if (!string.IsNullOrEmpty(tBoxJogVelocity.Text))
                _eleAxisLine.JogVelocity = double.Parse(tBoxJogVelocity.Text);

            if (!string.IsNullOrEmpty(tBoxJogDistance.Text))
                _eleAxisLine.JogDistance = double.Parse(tBoxJogDistance.Text);

            if (!string.IsNullOrEmpty(tBoxHomeVel.Text)) _eleAxisLine.HomeVelocity = double.Parse(tBoxHomeVel.Text);

            _eleAxisLine.SwLimitEnable = cBoxSwLimitEnable.Checked;
            _eleAxisLine.CheckLimitEnable = cBoxHwLimitEnable.Checked;

            if (!string.IsNullOrEmpty(tBoxSwPot.Text)) _eleAxisLine.SPel = double.Parse(tBoxSwPot.Text);

            if (!string.IsNullOrEmpty(tBoxSwNot.Text)) _eleAxisLine.SMel = double.Parse(tBoxSwNot.Text);

            if (!string.IsNullOrEmpty(tBoxLimVelP.Text)) _eleAxisLine.LimVelP = double.Parse(tBoxLimVelP.Text);

            if (!string.IsNullOrEmpty(tBoxLimVelN.Text)) _eleAxisLine.LimVelN = double.Parse(tBoxLimVelN.Text);

            if (!string.IsNullOrEmpty(tBoxDefaultVel.Text))
                _eleAxisLine.DefaultParams.Velocity = double.Parse(tBoxDefaultVel.Text);
            if (!string.IsNullOrEmpty(tBoxDefaultAcc.Text))
                _eleAxisLine.DefaultParams.Acceleration = double.Parse(tBoxDefaultAcc.Text);
            if (!string.IsNullOrEmpty(tBoxDefaultDec.Text))
                _eleAxisLine.DefaultParams.Deceleration = double.Parse(tBoxDefaultDec.Text);
            if (!string.IsNullOrEmpty(tBoxDefaultAccTime.Text))
                _eleAxisLine.DefaultParams.AccTime = double.Parse(tBoxDefaultAccTime.Text);
            if (!string.IsNullOrEmpty(tBoxDefaultDecTime.Text))
                _eleAxisLine.DefaultParams.DecTime = double.Parse(tBoxDefaultDecTime.Text);
            if (!string.IsNullOrEmpty(tBoxDefaultMinVel.Text))
                _eleAxisLine.DefaultParams.MinVelocity = double.Parse(tBoxDefaultMinVel.Text);
            if (!string.IsNullOrEmpty(tBoxDefaultStopVel.Text))
                _eleAxisLine.DefaultParams.StopVel = double.Parse(tBoxDefaultStopVel.Text);
        }

        private void dgvDataConfigs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var eRowIndex = e.RowIndex;
            var eColumnIndex = e.ColumnIndex;

            if (eColumnIndex < 0) return;

            if (eRowIndex < 0) return;

            if (dgvDataConfigs.Columns[eColumnIndex].Name.ToLower().Contains("teach") && _eleAxisLine.CheckManualEnable())
            {
                var ret = MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ConfirmChangePointPosition",
                    "Are you sure change the point position?"));
                if (ret == DialogResult.OK)
                    dgvDataConfigs.Rows[eRowIndex].Cells[2].Value = _eleAxisLine.ActualPosition.ToString("F2");
            }
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

        public void SetSimulateMode(bool simulate)
        {
            if (tBoxState.InvokeRequired)
            {
                var update = new UpdateEleSimulateMode(SetSimulateMode);
                BeginInvoke(update, simulate);
            }
            else
            {
                chkSimulate.Checked = simulate;
            }
        }

        public void UiRefresh()
        {
            if (_eleAxisLine == null || _config == null) return;

            if (_eleAxisLine.EleRunStat == EleRunState.Other)
            {
                _eleAxisLine.IEleInit();
                return;
            }

            if (_eleAxisLine.EleRunStat == EleRunState.Running)
            {
                ControlHelper.ChangeTextBoxBackColor(ref tBoxDevName, Color.LawnGreen);
            }
            else
            {
                ControlHelper.ChangeTextBoxBackColor(ref tBoxDevName, SystemColors.GradientActiveCaption);
                return;
            }

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
            ControlHelper.ChangeStatusLabelText(ref sStripStatus, ref lbelActualPos1,
                _eleAxisLine.ActualPosition.ToString("F2"));
            ControlHelper.ChangeStatusLabelText(ref sStripStatus, ref lbelActualVel1,
                _eleAxisLine.ActualVelocity.ToString("F2"));
            ControlHelper.ChangeLabelText(ref lbelCmdPos, _eleAxisLine.CmdPosition.ToString("F2"));
            ControlHelper.ChangeLabelText(ref lbelCmdVel, _eleAxisLine.CmdVelocity.ToString("F2"));
            ControlHelper.ChangeLabelText(ref lbelCmdPulsePos, _eleAxisLine.CmdPosPulse.ToString("F0"));
            ControlHelper.ChangeLabelText(ref lbelActPulsePos, _eleAxisLine.ActualPosPulse.ToString("F0"));
            ControlHelper.ChangeLabelText(ref lbelCmdPulseVel, _eleAxisLine.CmdVelPulse.ToString("F0"));
            ControlHelper.ChangeLabelText(ref lbelActPulseVel, _eleAxisLine.CmdVelPulse.ToString("F0"));
        }

        public void UiRefresh1()
        {
            if (_eleAxisLine == null || _config == null) return;

            if (InvokeRequired)
            {
                var update = new UpdateControl(UiRefresh1);
                BeginInvoke(update);
            }
            else
            {
                if (_eleAxisLine.EleRunStat == EleRunState.Running)
                {
                    tBoxDevName.BackColor = Color.LawnGreen;
                }
                else
                {
                    tBoxDevName.BackColor = SystemColors.GradientActiveCaption;
                    return;
                }

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
                lbelCmdPulsePos.Text = _eleAxisLine.CmdPosPulse.ToString("F0");
                lbelActPulsePos.Text = _eleAxisLine.ActualPosPulse.ToString("F0");
                lbelCmdPulseVel.Text = _eleAxisLine.CmdVelPulse.ToString("F0");
                lbelActPulseVel.Text = _eleAxisLine.CmdVelPulse.ToString("F0");
            }
        }

        private void dgvDataConfigs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex, CollumIndex;
            RowIndex = e.RowIndex;
            CollumIndex = e.ColumnIndex;

            if (CollumIndex < 0) return;

            if (RowIndex < 0) return;

            if (_eleAxisLine == null || !_eleAxisLine.IsEnable || !_eleAxisLine.CheckManualEnable()) return;

            if (double.TryParse(dgvDataConfigs.Rows[RowIndex].Cells[2].Value.ToString(), out var pos))
            {
                _eleAxisLine.MC_MoveAbsolute(pos);
            }
        }

        private void btnServoOn_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine != null && _config != null && _eleAxisLine.CheckManualEnable()) _eleAxisLine.MC_Power(!_eleAxisLine.IsEnable);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine != null && _config != null && _eleAxisLine.CheckManualEnable()) _eleAxisLine.MC_Reset();
        }

        private void btnJogDec_Click(object sender, EventArgs e)
        {
        }

        private void btnJogAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnVelDec_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine != null && _config != null && _eleAxisLine.CheckManualEnable())
                _eleAxisLine.MC_MoveRelative(0 - _eleAxisLine.JogDistance, _eleAxisLine.JogVelocity);
        }

        private void btnRelAdd_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine != null && _config != null && _eleAxisLine.CheckManualEnable())
                _eleAxisLine.MC_MoveRelative(_eleAxisLine.JogDistance, _eleAxisLine.JogVelocity);
        }

        private void btnGoPos_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine == null || _config == null || string.IsNullOrEmpty(tBoxGoPos.Text) || !_eleAxisLine.CheckManualEnable()) return;

            double pos1;
            if (!double.TryParse(tBoxGoPos.Text, out pos1))
                _eleAxisLine.MC_MoveAbsolute(tBoxGoPos.Text);
            else
                _eleAxisLine.MC_MoveAbsolute(pos1);
        }

        private void btnSetPos_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine == null || _config == null ||
                string.IsNullOrEmpty(tBoxSetPos.Text) || !_eleAxisLine.CheckManualEnable())
                return;

            var pos = double.Parse(tBoxSetPos.Text);
            _eleAxisLine.MC_SetPosition(pos);
        }

        private void btnJogDec_MouseDown(object sender, MouseEventArgs e)
        {
            if (_eleAxisLine != null && _config != null && _eleAxisLine.CheckManualEnable()) _eleAxisLine.MC_MoveJog(false, _eleAxisLine.JogVelocity);
        }

        private void btnJogDec_MouseUp(object sender, MouseEventArgs e)
        {
            if (_eleAxisLine != null && _config != null && _eleAxisLine.CheckManualEnable()) _eleAxisLine.MC_Stop();
        }

        private void btnJogAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (_eleAxisLine != null && _config != null && _eleAxisLine.CheckManualEnable()) _eleAxisLine.MC_MoveJog(true, _eleAxisLine.JogVelocity);
        }

        private void btnJogAdd_MouseUp(object sender, MouseEventArgs e)
        {
            if (_eleAxisLine != null && _config != null && _eleAxisLine.CheckManualEnable()) _eleAxisLine.MC_Stop();
        }

        private void cBoxSimulate_CheckedChanged(object sender, EventArgs e)
        {
            if (_eleAxisLine == null) return;

            _eleAxisLine.IsSimulateMode = chkSimulate.Checked;
        }

        private void lbState_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine.EleRunStat == EleRunState.Other) _eleAxisLine.IEleInit();

            if (_eleAxisLine.EleRunStat == EleRunState.Err) _eleAxisLine.IEleReset();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine.EleRunStat != EleRunState.Running || !_eleAxisLine.CheckManualEnable()) return;

            if (_eleAxisLine.HomeMode == -1)
                _eleAxisLine.MC_Home();
            else
                _eleAxisLine.MC_Home(_eleAxisLine.HomeMode, 50);
        }

        private void btnStandBy_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine.EleRunStat != EleRunState.Running || !_eleAxisLine.IsEnable || !_eleAxisLine.CheckManualEnable()) return;

            if (_eleAxisLine.StandByIndex == -1 || _eleAxisLine.DataConfigs.ListAxisDataConfigs.Count <= 0)
                _eleAxisLine.MC_MoveAbsolute(0.0);
            else
                _eleAxisLine.MC_MoveAbsolute(_eleAxisLine.StandByIndex);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_eleAxisLine.EleRunStat != EleRunState.Running || !_eleAxisLine.IsEnable || !_eleAxisLine.CheckManualEnable()) return;

            _eleAxisLine.MC_Stop();
        }

        private void TBoxLimVelP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBoxLimVelP.Text)) return;
            var ret = double.TryParse(tBoxLimVelP.Text, out var value);
            if (!ret)
            {
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfLimVelMaxIllegal",
                    "The value of 'LimVelMax' was illegal!"));
                tBoxLimVelP.Text = "-1.0";
            }
            else
            {
                if (value == -1 || value >= 0)
                {
                    //_config.LimVelP = value;
                }
                else
                {
                    MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfLimVelMaxIllegal",
                        "The value of 'LimVelMax' was illegal!"));
                    tBoxLimVelP.Text = "-1.0";
                }
            }
        }

        private void TBoxLimVelN_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBoxLimVelN.Text)) return;
            var ret = double.TryParse(tBoxLimVelN.Text, out var value);
            if (!ret)
            {
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfLimVelMinIllegal",
                    "The value of 'LimVelMin' was illegal!"));
                tBoxLimVelN.Text = "-1.0";
            }
            else
            {
                if (value == -1 || value >= 0)
                {
                    //_config.LimVelN = value;
                }
                else
                {
                    MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfLimVelMinIllegal",
                        "The value of 'LimVelMin' was illegal!"));
                    tBoxLimVelN.Text = "-1.0";
                }
            }
        }

        private void TBoxJogVelocity_TextChanged(object sender, EventArgs e)
        {
            var ret = double.TryParse(tBoxJogVelocity.Text, out var value);
            if (!ret)
            {
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfJogVelocityIllegal",
                    "The value of 'JogVelocity' was illegal!"));
                tBoxJogVelocity.Text = "-1.0";
            }
            else
            {
                if (!(value < _eleAxisLine.LimVelN) || !(value > _eleAxisLine.LimVelP)) return;
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfJogVelocityOverLimit",
                    "The value of 'JogVelocity' was over limit!"));
                tBoxJogVelocity.Text = "-1.0";
            }
        }

        private void TBoxHomeVel_TextChanged(object sender, EventArgs e)
        {
            var ret = double.TryParse(tBoxHomeVel.Text, out var value);
            if (!ret)
            {
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfHomeVelocityIllegal",
                    "The value of 'HomeVelocity' was illegal!"));
                tBoxHomeVel.Text = "-1.0";
            }
            else
            {
                if (!(value < _eleAxisLine.LimVelN) || !(value > _eleAxisLine.LimVelP)) return;
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfHomeVelocityOverLimit",
                    "The value of 'HomeVelocity' was over limit!"));
                tBoxHomeVel.Text = "-1.0";
            }
        }

        private void TBoxDefaultVel_TextChanged(object sender, EventArgs e)
        {
            var ret = double.TryParse(tBoxDefaultVel.Text, out var value);
            if (!ret)
            {
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfDefaultParamsVelocityIllegal",
                    "The value of 'DefaultParams.Velocity' was illegal!"));
                tBoxDefaultVel.Text = "-1.0";
            }
            else
            {
                if (value < _eleAxisLine.LimVelN && value > _eleAxisLine.LimVelP)
                {
                    MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfDefaultParamsVelocityOverLimit",
                        "The value of 'DefaultParams.Velocity' was over limit!"));
                    tBoxDefaultVel.Text = "-1.0";
                }
            }
        }

        private void TBoxDefaultMinVel_TextChanged(object sender, EventArgs e)
        {
            var ret = double.TryParse(tBoxDefaultMinVel.Text, out var value);
            if (!ret)
            {
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfDefaultParamsMinVelocityIllegal",
                    "The value of 'DefaultParams.MinVelocity' was illegal!"));
                tBoxDefaultMinVel.Text = "-1.0";
            }
            else
            {
                if (!(value < _eleAxisLine.LimVelN) || !(value > _eleAxisLine.LimVelP)) return;
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfDefaultParamsMinVelocityOverLimit",
                    "The value of 'DefaultParams.MinVelocity' was over limit!"));
                tBoxDefaultMinVel.Text = "-1.0";
            }
        }

        private void TBoxDefaultStopVel_TextChanged(object sender, EventArgs e)
        {
            var ret = double.TryParse(tBoxDefaultStopVel.Text, out var value);
            if (!ret)
            {
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfDefaultParamsStopVelIllegal",
                    "The value of 'DefaultParams.StopVel' was illegal!"));
                tBoxDefaultStopVel.Text = "-1.0";
            }
            else
            {
                if (!(value < _eleAxisLine.LimVelN) || !(value > _eleAxisLine.LimVelP)) return;
                MessageBox.Show(NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfDefaultParamsStopVelOverLimit",
                    "The value of 'DefaultParams.StopVel' was over limit!"));
                tBoxDefaultStopVel.Text = "-1.0";
            }
        }

        private void DgvDataConfigs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 6)
            {
                if (string.IsNullOrEmpty(dgvDataConfigs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())) return;
                var value = -1.00;
                var ret = double.TryParse(dgvDataConfigs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                    out value);
                if (!ret)
                {
                    MessageBox.Show(e.ColumnIndex == 3
                        ? string.Format(
                            NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfVelocityInTableIllegal",
                                "The value of 'Velocity' at 'Row:{0}, Column:{1}' was illegal!"), e.RowIndex,
                            e.ColumnIndex)
                        : string.Format(
                            NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfMinVelocityInTableIllegal",
                                "The value of 'MinVelocity' at 'Row:{0}, Column:{1}' was illegal!"), e.RowIndex,
                            e.ColumnIndex));

                    dgvDataConfigs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-1.0";
                }
                else
                {
                    if (value < _eleAxisLine.LimVelN && value > _eleAxisLine.LimVelP)
                    {
                        MessageBox.Show(e.ColumnIndex == 3
                            ? string.Format(
                                NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfVelocityInTableOverLimit",
                                    "The value of 'Velocity' at 'Row:{0}, Column:{1}' was over limit!"), e.RowIndex,
                                e.ColumnIndex)
                            : string.Format(
                                NLocalizer.GetString("EleAxisLine_ConfigUI_ValueOfMinVelocityInTableOverLimit",
                                    "The value of 'MinVelocity' at 'Row:{0}, Column:{1}' was over limit!"), e.RowIndex,
                                e.ColumnIndex));

                        dgvDataConfigs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-1.0";
                    }
                }
            }
        }

        private void CBoxHwLimitEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (_eleAxisLine == null) return;
            _eleAxisLine.CheckLimitEnable = cBoxHwLimitEnable.Checked;
            //_config.CheckLimitEnable = cBoxHwLimitEnable.Checked;
            if (_eleAxisLine.CheckLimitEnable)
            {
                //_eleAxisLine.SetElMode(true, true, StopMode.Free, StopMode.Free);
            }
        }

        private delegate void UpdateEleRunState(EleRunState state);

        private delegate void UpdateEleSimulateMode(bool simulate);
    }
}