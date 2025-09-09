using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.EleCartesian.EleUIs
{
    /// <summary>点位管理UI</summary>
    public partial class AxisesPointsConfig : Form
    {
        #region Field
        /// <summary>轴组管理器</summary>
        private readonly EleCartesian _ele;

        private readonly Dictionary<int, TabPage> _pages;

        private readonly Dictionary<int, DataGridView> _dgv;
        #endregion



        #region Ctor
        public AxisesPointsConfig()
        {
            InitializeComponent();
        }
        public AxisesPointsConfig(EleCartesian ele)
        {
            InitializeComponent();

            _pages = new Dictionary<int, TabPage>();
            _dgv = new Dictionary<int, DataGridView>();
            _ele = ele;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        private void AxisesPointsConfig_Load(object sender, EventArgs e)
        {
            CreatOrUpdateAxisTabPages();
            BtnTableLoad_Click(null, null);
        }
        private void AxisesPointsConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
        #endregion



        #region Button_Event

        #endregion



        #region Others
        private void CreatOrUpdateAxisTabPages()
        {
            if (tabPoints.TabPages.Count > 0)
            {
                foreach (TabPage tab in tabPoints.TabPages)
                {
                    tab.Controls.Clear();
                }
            }
            tabPoints.TabPages.Clear();
            _pages.Clear();
            _dgv.Clear();

            var newPage = new TabPage("Axises");
            newPage.Name = "Axises";
            var newDgv = CreatAxisesTable();
            newPage.Controls.Add(newDgv);
            newPage.Tag = 100;
            tabPoints.TabPages.Add(newPage);
            _dgv.Add(100, newDgv);
            _pages.Add(100, newPage);

            foreach (var axis in _ele.Axises)
            {
                if (_dgv.ContainsKey(axis.Key))
                {
                    continue;
                }
                newPage = new TabPage(axis.Value.Name);
                newPage.Name = axis.Value.Name;
                newDgv = CreatAxisTables(axis);
                newPage.Controls.Add(newDgv);
                newPage.Tag = axis.Key;
                tabPoints.TabPages.Add(newPage);

                _dgv.Add(axis.Key, newDgv);
                _pages.Add(axis.Key, newPage);
            }

            if (!string.IsNullOrEmpty(_ele.PointsPath)) tbPointsPath.Text = _ele.PointsPath;
        }
        private DataGridView CreatAxisesTable()
        {
            var newDgv = new DataGridView
            {
                Name = "dgvAxises",
                Tag = 100,
                ColumnHeadersDefaultCellStyle = { Font = new Font("微软雅黑", 7, FontStyle.Bold) },
                AllowUserToAddRows = false
            };

            newDgv.Columns.Add("dgvColIndex" + 100, "Index");
            newDgv.Columns.Add("dgvColName" + 100, "Name");

            foreach (var axis in _ele.Axises)
            {
                newDgv.Columns.Add("dgvColPosition" + axis.Value.Name, axis.Value.Name);
            }

            for (var i = 0; i < newDgv.Columns.Count; i++)
            {
                newDgv.Columns[i].Width = 120;
                newDgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                newDgv.Columns[i].DefaultCellStyle.Font = new Font("微软雅黑", 7);
            }

            newDgv.Columns[0].Width = 50;

            var teachColumn = new DataGridViewButtonColumn
            {
                Name = "dgvColTeach" + 100,
                HeaderText = "TeachButton",
                Text = "Teach",
                DefaultCellStyle = { NullValue = "Teach", Font = new Font("微软雅黑", 10, FontStyle.Bold) },
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            newDgv.Columns.Add(teachColumn);

            newDgv.CellValueChanged += DgvAxises_CellValueChanged;
            newDgv.CellContentClick += DgvAxises_OnCellContentClick;
            newDgv.RowHeaderMouseDoubleClick += DgvOnRowHeaderMouseDoubleClick;
            newDgv.Dock = DockStyle.Fill;
            return newDgv;
        }
        #endregion




        private DataGridView CreatAxisTables(KeyValuePair<int, IEleAxis> axis)
        {
            var newDgv = new DataGridView
            {
                Name = "dgvAxis" + axis.Key,
                Tag = axis.Key,
                ColumnHeadersDefaultCellStyle = {Font = new Font("微软雅黑", 7, FontStyle.Bold)},
                AllowUserToAddRows = false
            };

            newDgv.Columns.Add("dgvColIndex" + axis.Key, "Index");
            newDgv.Columns.Add("dgvColName" + axis.Key, "Name");
            newDgv.Columns.Add("dgvColPosition" + axis.Key, "Position");
            newDgv.Columns.Add("dgvColVelocity" + axis.Key, "Velocity");
            newDgv.Columns.Add("dgvColAcceleration" + axis.Key, "Acceleration");
            newDgv.Columns.Add("dgvColDeceleration" + axis.Key, "Deceleration");
            newDgv.Columns.Add("dgvColMinVelocity" + axis.Key, "MinVelocity");
            newDgv.Columns.Add("dgvColAccTime" + axis.Key, "AccTime");
            newDgv.Columns.Add("dgvColDecTime" + axis.Key, "DecTime");

            for (var i = 0; i < newDgv.Columns.Count; i++)
            {
                newDgv.Columns[i].Width = 120;
                newDgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                newDgv.Columns[i].DefaultCellStyle.Font = new Font("微软雅黑", 7);
            }

            newDgv.Columns[0].Width = 50;
            newDgv.Columns[0].ReadOnly = true;

            var teachColumn = new DataGridViewButtonColumn
            {
                Name = "dgvColTeach" + axis.Key,
                HeaderText = "TeachButton",
                Text = "Teach",
                DefaultCellStyle = {NullValue = "Teach", Font = new Font("微软雅黑", 10, FontStyle.Bold)},
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            newDgv.Columns.Add(teachColumn);

            SetDgvDataConfigsMode(_ele.VelMode, ref newDgv);

            newDgv.CellValueChanged += DgvSingleAxis_CellValueChanged;
            newDgv.CellContentClick += DgvSingleAxis_OnCellContentClick;
            newDgv.RowHeaderMouseDoubleClick += DgvOnRowHeaderMouseDoubleClick;
            newDgv.Dock = DockStyle.Fill;
            return newDgv;
        }

        

        internal void AddAxis(IEleAxis axis, int num)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<IEleAxis, int>(AddAxis), axis, num);
            }
            else
            {
                var newPage = new TabPage(axis.Name);
                newPage.Name = axis.Name;
                var newDgv = CreatAxisTables(new KeyValuePair<int, IEleAxis>(num, axis));
                newPage.Controls.Add(newDgv);
                newPage.Tag = num;
                tabPoints.TabPages.Add(newPage);

                _dgv.Add(num, newDgv);
                _pages.Add(num, newPage);
            }
        }
        internal void RemoveAxis(IEleAxis axis, int num)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<IEleAxis, int>(RemoveAxis), axis, num);
            }
            else
            {
                if (_pages.Count > 1)
                {
                    foreach (var page in _pages)
                    {
                        if (page.Value.Tag.ToString() == num.ToString())
                        {
                            page.Value.Parent = null;
                            if (tabPoints.Controls.Contains(page.Value))
                            {
                                tabPoints.Controls.Remove(page.Value);
                            }
                            break;
                        }
                    }
                }
            }
        }
        private void DgvOnRowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            if (_ele == null) return;

            var dgv = (DataGridView) sender;
            var rowIndex = e.RowIndex;

            var dgvTag = int.Parse(dgv.Tag.ToString());
            var posName = dgv.Rows[rowIndex].Cells[1].Value.ToString();
            CartesianMovingForm movingForm;
            if (dgvTag == 100)
            {
                var moveRet = MessageBox.Show(
                    string.Format(
                        NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_Tip_ConfirmToMove", "[{0}]确定移动至[{1}]吗?")
                                    , _ele.Name
                                    , posName
                        ),
                    "", MessageBoxButtons.YesNo);
                if (moveRet != DialogResult.Yes) return;
                Cursor = Cursors.WaitCursor;
                if (_ele.GroupMoveAbs(posName, 50) != 0)
                    MessageBox.Show(
                    string.Format(
                        NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ErrMsg_MoveFail", "[{0}]移动至[{1}]失败")
                                    , _ele.Name
                                    , posName
                        ));
                movingForm = new CartesianMovingForm(_ele, posName);
            }
            else
            {
                var moveRet = MessageBox.Show(
                   string.Format(
                       NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_Tip_ConfirmAxisToMove", "[{0}]确定将轴[{1}]移动至[{2}]吗?")
                                   , _ele.Name
                                   , posName
                       ),
                   "", MessageBoxButtons.YesNo);
                if (moveRet != DialogResult.Yes) return;
                Cursor = Cursors.WaitCursor;
                if (_ele.SingleMoveAbs(dgvTag, posName, 50) != 0)
                    MessageBox.Show(
                    string.Format(
                        NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ErrMsg_AxisMoveFail", "[{0}]将轴[{1}]移动至[{2}]失败")
                                    , _ele.Name
                                    , _ele.Axises[dgvTag].Name
                                    , posName
                        ));
                movingForm = new CartesianMovingForm(_ele, posName, false, dgvTag);
            }

            movingForm.ShowDialog();
            Cursor = DefaultCursor;
        }

        private void DgvAxises_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;

            if (int.Parse(dgv.Tag.ToString()) != 100 || columnIndex < 0 || rowIndex < 0) return;

            if (!dgv.Columns[columnIndex].Name.ToLower().Contains("teach")) return;

            if (!_ele.CheckManualEnable())
            {
                return;
            }

            var ret = MessageBox.Show(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ConfirmToChangePos", "确认要更改此点位吗?"), "", MessageBoxButtons.YesNo);
            if (ret != DialogResult.Yes) return;

            var axisIndex = 0;
            foreach (var axis in _ele.Axises)
                dgv.Rows[rowIndex].Cells[2 + axisIndex++].Value = axis.Value.ActualPos.ToString();
        }

        private void DgvSingleAxis_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
            var axisIndex = int.Parse(dgv.Tag.ToString());
            var rowIndex = e.RowIndex;
            var columnIndex = e.ColumnIndex;

            if (columnIndex < 0 || rowIndex < 0) return;

            if (!dgv.Columns[columnIndex].Name.ToLower().Contains("teach")) return;

            if (!_ele.CheckManualEnable())
            {
                return;
            }

            var ret = MessageBox.Show(NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ConfirmToChangePos", "确认要更改此点位吗?"), "", MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
                dgv.Rows[rowIndex].Cells[2].Value = _ele.Axises[axisIndex].ActualPos.ToString();
        }

        private void DgvAxises_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
        }

        private void DgvSingleAxis_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
            var axis = _ele.Axises[(int) dgv.Tag];

            if (e.ColumnIndex != 3 && e.ColumnIndex != 6) return;

            if (string.IsNullOrEmpty(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())) return;
            var ret = double.TryParse(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out var value);
            if (!ret)
            {
                var message = string.Empty;
                if (e.ColumnIndex == 3)
                    message = string.Format(
                        NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ErrMsg_SpeedSetError", "行{0},列{1}的速度值设置有误,请检查")
                                    , e.RowIndex
                                    , e.ColumnIndex
                        );
                else
                    message = string.Format(
                        NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ErrMsg_MinSpeedSetError", "行{0},列{1}的最小速度值设置有误,请检查")
                                    , e.RowIndex
                                    , e.ColumnIndex
                        );
                MessageBox.Show(message);

                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-1.0";
            }
            else
            {
                if (!(value < axis.LimitVelN) || !(value > axis.LimitVelP)) return;

                var message = string.Empty;
                if (e.ColumnIndex == 3)
                    message = string.Format(
                        NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ErrMsg_SpeedSetExceed", "行{0},列{1}的速度值超出限值设定,请检查")
                                    , e.RowIndex
                                    , e.ColumnIndex
                        );
                else
                    message = string.Format(
                        NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ErrMsg_MinSpeedSetExceed", "行{0},列{1}的最小速度值超出限值设定,请检查")
                                    , e.RowIndex
                                    , e.ColumnIndex
                        );
                MessageBox.Show(message);

                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "-1.0";
            }
        }

        internal void RefreshAxises()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshAxises));
            }
            else
            {
                CreatOrUpdateAxisTabPages();

                if (_ele.ImportPointsFromPath() != 0) return;

                PointsTablesUpdate();
            }
        }

        private void SetDgvDataConfigsMode(AccDecType type, ref DataGridView dgvPoints)
        {
            if (dgvPoints == null) return;

            for (var i = 0; i < dgvPoints.Columns.Count; i++)
                if (dgvPoints.Columns[i].Name.ToLower().Contains("acceleration"))
                    dgvPoints.Columns[i].Visible = type != AccDecType.Time;
                else if (dgvPoints.Columns[i].Name.ToLower().Contains("deceleration"))
                    dgvPoints.Columns[i].Visible = type != AccDecType.Time;
                else if (dgvPoints.Columns[i].Name.ToLower().Contains("minvelocity"))
                    dgvPoints.Columns[i].Visible = type != AccDecType.Velocity;
                else if (dgvPoints.Columns[i].Name.ToLower().Contains("acctime"))
                    dgvPoints.Columns[i].Visible = type != AccDecType.Velocity;
                else if (dgvPoints.Columns[i].Name.ToLower().Contains("dectime"))
                    dgvPoints.Columns[i].Visible = type != AccDecType.Velocity;
        }

        private void BtnTableLoad_Click(object sender, EventArgs e)
        {
            if (_ele == null) return;

            if (_ele.ImportPointsFromPath() != 0) return;

            PointsTablesUpdate();
        }

        private void PointsTablesUpdate()
        {
            if (_ele?.Points == null || _ele.Axises.IsEmpty) return;

            var axisCount = _ele.Axises.Count;

            _dgv[100].Rows.Clear();
            foreach (var point in _ele.Points.GroupPoints)
            {
                var index = _dgv[100].Rows.Add();
                _dgv[100].Rows[index].Cells[0].Value = point.Value.Index;
                _dgv[100].Rows[index].Cells[1].Value = point.Value.Name;
                for (var i = 0; i < point.Value.Pos.Length; i++)
                    _dgv[100].Rows[index].Cells[2 + i].Value = point.Value.Pos[i].ToString();
            }

            for (var i = 0; i < axisCount; i++)
            {
                _dgv[i].Rows.Clear();
                if (_ele.Points == null) _ele.Points = new CartesianPoints();

                if (!_ele.Points.SingleAxisPoints.ContainsKey(i) ||
                    _ele.Points.SingleAxisPoints[i].Points.Count < 1) continue;

                foreach (var point in _ele.Points.SingleAxisPoints[i].Points)
                {
                    var index = _dgv[i].Rows.Add();
                    _dgv[i].Rows[index].Cells[0].Value = point.Value.Index;
                    _dgv[i].Rows[index].Cells[1].Value = point.Value.Name;
                    _dgv[i].Rows[index].Cells[2].Value = point.Value.Position.ToString();
                    _dgv[i].Rows[index].Cells[3].Value = point.Value.Velocity.ToString("F3");
                    _dgv[i].Rows[index].Cells[4].Value = point.Value.Acceleration.ToString("F3");
                    _dgv[i].Rows[index].Cells[5].Value = point.Value.Deceleration.ToString("F3");
                    _dgv[i].Rows[index].Cells[6].Value = point.Value.MinVelocity.ToString("F3");
                    _dgv[i].Rows[index].Cells[7].Value = point.Value.AccTime.ToString("F3");
                    _dgv[i].Rows[index].Cells[8].Value = point.Value.DecTime.ToString("F3");
                }
            }
        }

        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable()) return;

            var selectedIndex = int.Parse(tabPoints.SelectedTab.Tag.ToString());
            _dgv[selectedIndex].Rows.Add();
            var rowIndex = _dgv[selectedIndex].Rows.Count - 1;
            _dgv[selectedIndex].Rows[rowIndex].Cells[0].Value = rowIndex;
            _dgv[selectedIndex].Rows[rowIndex].Cells[1].Value = $"Pos{rowIndex}";
            if (selectedIndex == 100)
            {
                for (var i = 2; i < _dgv[selectedIndex].Rows[rowIndex].Cells.Count - 1; i++)
                    _dgv[selectedIndex].Rows[rowIndex].Cells[i].Value = _ele.Axises[i - 2].ActualPos.ToString();
                return;
            }

            _dgv[selectedIndex].Rows[rowIndex].Cells[2].Value = _ele.Axises[selectedIndex].ActualPos.ToString();
            _dgv[selectedIndex].Rows[rowIndex].Cells[3].Value = _ele.Axises[selectedIndex].DefaultMaxVel.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[4].Value = _ele.Axises[selectedIndex].DefaultAcc.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[5].Value = _ele.Axises[selectedIndex].DefaultDec.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[6].Value =
                _ele.Axises[selectedIndex].DefaultStartVel.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[7].Value =
                _ele.Axises[selectedIndex].DefaultAccTime.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[8].Value =
                _ele.Axises[selectedIndex].DefaultDecTime.ToString("F3");
        }

        private void BtnDelRow_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            var selectedIndex = int.Parse(tabPoints.SelectedTab.Tag.ToString());
            if (_dgv[selectedIndex].Rows.Count <= 0) return;

            var selectedRowIndex = _dgv[selectedIndex].CurrentCell.RowIndex;
            _dgv[selectedIndex].Rows.RemoveAt(selectedRowIndex);
        }

        private void BtnTableSaveAs_Click(object sender, EventArgs e)
        {
            if (!_ele.CheckManualEnable())
            {
                return;
            }

            DataApply();
            if (string.IsNullOrEmpty(_ele.PointsPath))
            {
                var saveFile = new SaveFileDialog
                {
                    Filter = @"json File|*.json|All File|"".""",
                    RestoreDirectory = true
                };
                var dialogResult = saveFile.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _ele.ExportPointsToPath(saveFile.FileName);
                    _ele.PointsPath = saveFile.FileName;
                    tbPointsPath.Text = saveFile.FileName;
                    DataApply();
                }
            }
            else
            {
                _ele.ExportPointsToPath(_ele.PointsPath);
            }
            _ele.UpdateDebugPoints();
        }

        private void DataApply()
        {
            if (_ele == null) return;

            if (_ele.Points.GroupPoints == null)
                _ele.Points.GroupPoints = new ConcurrentDictionary<int, PosCartesian>();

            _ele.Points.GroupPoints.Clear();
            for (var j = 0; j < _dgv[100].Rows.Count; j++)
            {
                var point = new PosCartesian
                {
                    Index = int.TryParse(_dgv[100].Rows[j].Cells[0].Value?.ToString(), out var pointIndex) ? pointIndex : -1,
                    Name = !string.IsNullOrEmpty(_dgv[100].Rows[j].Cells[1].Value?.ToString()) ? _dgv[100].Rows[j].Cells[1].Value.ToString() : $"Pos{j}",
                    Pos = new double[_ele.AxisNum]
                };
                for (var k = 0; k < point.Pos.Length; k++)
                    point.Pos[k] = double.TryParse(_dgv[100].Rows[j].Cells[k + 2].Value?.ToString(), out var position) ? position : -1;

                _ele.Points.GroupPoints.TryAdd(point.Index, point);
            }

            for (var i = 0; i < _dgv.Count - 1; i++)
            {
                var rowCount = _dgv[i].Rows.Count;
                if (rowCount < 1) continue;

                if (_ele.Points.SingleAxisPoints == null)
                    _ele.Points.SingleAxisPoints = new ConcurrentDictionary<int, SingleAxisPoints>();

                if (_ele.Points.SingleAxisPoints.ContainsKey(i))
                    _ele.Points.SingleAxisPoints[i].Points.Clear();
                else
                    _ele.Points.SingleAxisPoints.TryAdd(i, new SingleAxisPoints());

                for (var j = 0; j < rowCount; j++)
                {
                    var point = new SingleAxisPoint
                    {
                        Index = int.TryParse(_dgv[i].Rows[j].Cells[0].Value?.ToString(), out var pointIndex) ? pointIndex : -1,
                        Name = !string.IsNullOrEmpty(_dgv[i].Rows[j].Cells[1].Value?.ToString()) ? _dgv[i].Rows[j].Cells[1].Value.ToString() : $"Pos{j}",
                        Position = double.TryParse(_dgv[i].Rows[j].Cells[2].Value?.ToString(), out var pointPos) ? pointPos : -1,
                        Velocity = double.TryParse(_dgv[i].Rows[j].Cells[3].Value?.ToString(), out var pointVel) ? pointVel : -1,
                        Acceleration = double.TryParse(_dgv[i].Rows[j].Cells[4].Value?.ToString(), out var pointAcc) ? pointAcc : -1,
                        Deceleration = double.TryParse(_dgv[i].Rows[j].Cells[5].Value?.ToString(), out var pointDec) ? pointDec : -1,
                        MinVelocity = double.TryParse(_dgv[i].Rows[j].Cells[6].Value?.ToString(), out var pointStartVel) ? pointStartVel : -1,
                        AccTime = double.TryParse(_dgv[i].Rows[j].Cells[7].Value?.ToString(), out var pointAccTime) ? pointAccTime : -1,
                        DecTime = double.TryParse(_dgv[i].Rows[j].Cells[8].Value?.ToString(), out var pointDecTime) ? pointDecTime : -1
                    };

                    _ele.Points.SingleAxisPoints[i].Points.TryAdd(j, point);
                }
            }

            if (File.Exists(tbPointsPath.Text)) _ele.PointsPath = tbPointsPath.Text;

            _ele.GroupToMotion();
            _ele.ExportAxisesConfigToPath(_ele.AxisesConfigPath);
            _ele.ExportPointsToPath(_ele.PointsPath);
        }

        

        public void AddSingleAxisPos(int axisIndex)
        {
            var selectedIndex = axisIndex;
            _dgv[selectedIndex].Rows.Add();
            var rowIndex = _dgv[selectedIndex].Rows.Count - 1;
            _dgv[selectedIndex].Rows[rowIndex].Cells[0].Value = rowIndex;
            _dgv[selectedIndex].Rows[rowIndex].Cells[1].Value = $"Pos{rowIndex}";
            if (selectedIndex == 100)
            {
                for (var i = 2; i < _dgv[selectedIndex].Rows[rowIndex].Cells.Count - 1; i++)
                    _dgv[selectedIndex].Rows[rowIndex].Cells[i].Value = _ele.Axises[i - 2].ActualPos.ToString();
                return;
            }

            _dgv[selectedIndex].Rows[rowIndex].Cells[2].Value = _ele.Axises[selectedIndex].ActualPos.ToString();
            _dgv[selectedIndex].Rows[rowIndex].Cells[3].Value = _ele.Axises[selectedIndex].DefaultMaxVel.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[4].Value = _ele.Axises[selectedIndex].DefaultAcc.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[5].Value = _ele.Axises[selectedIndex].DefaultDec.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[6].Value =
                _ele.Axises[selectedIndex].DefaultStartVel.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[7].Value =
                _ele.Axises[selectedIndex].DefaultAccTime.ToString("F3");
            _dgv[selectedIndex].Rows[rowIndex].Cells[8].Value =
                _ele.Axises[selectedIndex].DefaultDecTime.ToString("F3");
            DataApply();
        }

        internal void UpdatePoints()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(UpdatePoints));
            }
            else
            {
                PointsTablesUpdate();
            }
        }

        public void OnLanguageChanged()
        {
            this.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_AxisesPointsConfig_Title", "点位管理");
            btnTableSave.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_AxisesPointsConfig_Save", "保存");
            btnTableLoad.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_AxisesPointsConfig_Load", "载入");
            btnDataApply.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_AxisesPointsConfig_Debug", "应用");

            if (_pages != null)
            {
                string str_axis = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_Axis", "轴");
                foreach (var item in _pages)
                {
                    switch (item.Value.Name)
                    {
                        case "Axises":
                            item.Value.Text = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_Axises", "轴组");
                            break;
                        case "Axis_X":
                            item.Value.Text = str_axis + "X";
                            break;
                        case "Axis_Y":
                            item.Value.Text = str_axis + "Y";
                            break;
                        case "Axis_Z":
                            item.Value.Text = str_axis + "Z";
                            break;
                        case "Axis_U":
                            item.Value.Text = str_axis + "U";
                            break;
                        case "Axis_V":
                            item.Value.Text = str_axis + "V";
                            break;
                        case "Axis_W":
                            item.Value.Text = str_axis + "W";
                            break;
                    }
                }
            }

            if (_dgv != null)
            {
                try
                {

                    foreach (var item in _dgv)
                    {
                        foreach (DataGridViewColumn column in item.Value.Columns)
                        {
                            if (column.Name.Contains("dgvColIndex"))
                            {
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColIndex", "序号");
                                continue;
                            }
                            if (column.Name.Contains("dgvColName"))
                            {
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColName", "名称");
                                continue;
                            }
                            if (column.Name.Contains("dgvColPosition"))
                            {
                                switch (item.Value.Name)
                                {
                                    case "dgvAxises":
                                        column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColPosition", "位置点") + column.Name.Last();
                                        break;
                                    default:
                                        column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColPosition", "位置点");
                                        break;
                                }

                                continue;
                            }
                            if (column.Name.Contains("dgvColVelocity"))
                            {
                                item.Value.CellValueChanged -= DgvSingleAxis_CellValueChanged;
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColVelocity", "速度");
                                item.Value.CellValueChanged += DgvSingleAxis_CellValueChanged;
                                continue;
                            }
                            if (column.Name.Contains("dgvColAcceleration"))
                            {
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColAcceleration", "加速度");
                                continue;
                            }
                            if (column.Name.Contains("dgvColDeceleration"))
                            {
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColDeceleration", "减速度");
                                continue;
                            }
                            if (column.Name.Contains("dgvColMinVelocity"))
                            {
                                item.Value.CellValueChanged -= DgvSingleAxis_CellValueChanged;
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColMinVelocity", "最小速度");
                                item.Value.CellValueChanged += DgvSingleAxis_CellValueChanged;
                                continue;
                            }
                            if (column.Name.Contains("dgvColAccTime"))
                            {
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColAccTime", "加速时间");
                                continue;
                            }
                            if (column.Name.Contains("dgvColDecTime"))
                            {
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColDecTime", "减速时间");
                                continue;
                            }
                            if (column.Name.Contains("dgvColTeach"))
                            {
                                column.HeaderText = NLocalizer.GetString("Lead_CPrim_EleCartesian_EleUIs_DebugUI_ColTeach", "示教");
                                continue;
                            }
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }
    }
}