using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.CmpTrigHelper.CmpTrigUIs
{
    public class TrigTabMangerControl : UserControl
    {
        private TrigTabMangerData _TrigTabMangerData;

        private IContainer components = null;

        private DataGridView dgTrigTable;

        private TableLayoutPanel tableLayoutPanel1;

        private Panel panel1;

        private Button btnExportTablesToXml;

        private Button btnExportTablesToCsv;

        private Button btnAdd;

        private ComboBox cmbTrigTable;

        private Label labSelectTab;

        private TextBox txbTotalNum;

        private Label lbtTrigPointsCount;

        private Button btnClr;

        private TextBox txbNum;

        private Label lbTrigTableCount;

        private Button btnRemoveRow;

        private Button btnApply;

        private TextBox tbTrigTrigId;

        private Label lbId;

        private TextBox tbTableTrigName;

        private Label lbTrigName;

        private DataGridViewTextBoxColumn colPosIndex;

        private DataGridViewTextBoxColumn colTableName;

        private DataGridViewTextBoxColumn colTabPointNum;

        private DataGridViewTextBoxColumn 标记;

        private DataGridViewComboBoxColumn colOffsetType;

        public TrigTabMangerControl(TrigTabMangerData tableTrigData)
        {
            InitializeComponent();
            _TrigTabMangerData = tableTrigData;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cmbTrigTable.SelectedItem != null)
            {
                dgTrigTable.Rows.Add();
                int count = dgTrigTable.Rows.Count;
                KeyValuePair<Guid, TriggerTableData>? keyValuePair = _TrigTabMangerData.Manager.CurrentProduct?.TableTrigDatas?.ToList().FirstOrDefault((KeyValuePair<Guid, TriggerTableData> p) => p.Value.Name == cmbTrigTable.SelectedItem.ToString());
                dgTrigTable.Rows[count - 1].Cells[0].Value = count;
                dgTrigTable.Rows[count - 1].Cells[1].Value = keyValuePair.Value.Value.Name;
                dgTrigTable.Rows[count - 1].Cells[2].Value = keyValuePair.Value.Value.TrigPoints.Count;
                dgTrigTable.Rows[count - 1].Cells[3].Value = "0";
                dgTrigTable.Rows[count - 1].Cells[4].Value = "-1";
                RefreshUi();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTableTrigName.Text) || string.IsNullOrEmpty(tbTrigTrigId.Text))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_ErrMes_TrigNameIsEmpty", "触发表名称或触发表ID不允许为空!"));
                return;
            }
            _TrigTabMangerData.Name = tbTableTrigName.Text;
            _TrigTabMangerData.Id = int.Parse(tbTrigTrigId.Text);
            DgvTransData(ref _TrigTabMangerData);
            _TrigTabMangerData.RefreshTabs(TriggerManager.Instance.CurrentProduct);
        }

        private void BtnClr_Click(object sender, EventArgs e)
        {
            dgTrigTable.Rows.Clear();
            RefreshUi();
        }

        private void BtnExportTablesToCsv_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_Tip_SelectFile", "请选择文件夹!")
            };
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                MessageBox.Show(this, NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_ErrMes_FilePathIsEmpty", "文件夹路径不能为空!"), "");
                return;
            }
            string selectedPath = folderBrowserDialog.SelectedPath;
            int num = 0;
            foreach (KeyValuePair<int, TrigTabCfg> tab in _TrigTabMangerData.TrigsList)
            {
                num++;
                KeyValuePair<Guid, TriggerTableData>? keyValuePair = _TrigTabMangerData.Manager.CurrentProduct?.TableTrigDatas?.ToList().FirstOrDefault((KeyValuePair<Guid, TriggerTableData> p) => p.Value.Name == tab.Value.TabName);
                if (!keyValuePair.HasValue)
                {
                    continue;
                }
                string filePath = Path.Combine(selectedPath, "T" + num + ".csv");
                List<double> list = new List<double>();
                foreach (KeyValuePair<int, double> trigPoint in keyValuePair.Value.Value.TrigPoints)
                {
                    list.Add(trigPoint.Value);
                }
                //CsvHelper.ObjToCsv(list, filePath, append: false, Encoding.Default);
                CsvHelper.WriteStringToCsv(filePath, string.Join(",", list.ToArray()), false);
            }
        }

        private void BtnExportTablesToXml_Click(object sender, EventArgs e)
        {
            List<CPrimTrigInfo> list = new List<CPrimTrigInfo>();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_Tip_SelectFile", "请选择文件夹!")
            };
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                MessageBox.Show(this, NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_ErrMes_FilePathIsEmpty", "文件夹路径不能为空!"), "");
                return;
            }
            string selectedPath = folderBrowserDialog.SelectedPath;
            int num = 0;
            foreach (KeyValuePair<int, TrigTabCfg> tab in _TrigTabMangerData.TrigsList)
            {
                num++;
                KeyValuePair<Guid, TriggerTableData>? keyValuePair = _TrigTabMangerData.Manager.CurrentProduct?.TableTrigDatas?.ToList().FirstOrDefault((KeyValuePair<Guid, TriggerTableData> p) => p.Value.Name == tab.Value.TabName);
                if (!keyValuePair.HasValue)
                {
                    continue;
                }
                CPrimTrigInfo cPrimTrigInfo = new CPrimTrigInfo();
                cPrimTrigInfo.Name = keyValuePair.Value.Value.Name;
                cPrimTrigInfo.trigNum = keyValuePair.Value.Value.TrigPoints.Count;
                foreach (KeyValuePair<int, double> trigPoint in keyValuePair.Value.Value.TrigPoints)
                {
                    cPrimTrigInfo.trigPointTable.Add(trigPoint.Value);
                }
                list.Add(cPrimTrigInfo);
            }
            XmlSerializerHelper.WriteXML(list, selectedPath + "\\TrigInfoSave.XML", typeof(List<CPrimTrigInfo>));
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            for (int num = dgTrigTable.SelectedRows.Count; num > 0; num--)
            {
                if (!dgTrigTable.SelectedRows[0].IsNewRow)
                {
                    dgTrigTable.Rows.RemoveAt(dgTrigTable.SelectedRows[0].Index);
                }
            }
            RefreshUi();
        }

        private void control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
            MessageBox.Show(NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_ErrMes_OnlyNumber", "只能输入数字!"));
        }

        private void dgTrigTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType().BaseType.Name == "TextBox")
            {
                TextBox textBox = new TextBox();
                textBox = (TextBox)e.Control;
                if (textBox.Text == "0")
                {
                    textBox.KeyPress += control_KeyPress;
                }
            }
        }

        private void DgvFillData(TrigTabMangerData tableTrigData)
        {
            dgTrigTable.Rows.Clear();
            dgTrigTable.Rows.Add(tableTrigData.TrigsList.Count);
            int num = 0;
            foreach (KeyValuePair<int, TrigTabCfg> trigs in tableTrigData.TrigsList)
            {
                dgTrigTable.Rows[num].Cells[0].Value = trigs.Key;
                dgTrigTable.Rows[num].Cells[1].Value = trigs.Value;
                dgTrigTable.Rows[num].Cells[2].Value = trigs.Value.PointNum;
                dgTrigTable.Rows[num].Cells[3].Value = trigs.Value.AglID;
                dgTrigTable.Rows[num].Cells[4].Value = trigs.Value.OffsetType.ToString();
                num++;
            }
        }

        private void DgvTableTrigInit()
        {
            if (_TrigTabMangerData != null && _TrigTabMangerData.TrigsList.Count > 0)
            {
                DgvFillData(_TrigTabMangerData);
            }
        }

        private void DgvTransData(ref TrigTabMangerData tableTrigData)
        {
            tableTrigData.TrigsList.Clear();
            for (int i = 0; i < dgTrigTable.Rows.Count; i++)
            {
                tableTrigData.TrigsList.Add(i, new TrigTabCfg(i + 1, Convert.ToString(dgTrigTable.Rows[i].Cells[1].Value), Convert.ToInt32(dgTrigTable.Rows[i].Cells[2].Value), Convert.ToInt32(dgTrigTable.Rows[i].Cells[3].Value), Convert.ToInt32(dgTrigTable.Rows[i].Cells[4].Value)));
            }
        }

        private void LabSelectTab_Click(object sender, EventArgs e)
        {
            UpdateTrigTable();
            RefreshTab();
        }

        private void Panel1_DoubleClick(object sender, EventArgs e)
        {
            _TrigTabMangerData.IsSelected = !_TrigTabMangerData.IsSelected;
        }

        private void RefreshTab()
        {
            int index;
            for (index = 0; index < dgTrigTable.Rows.Count; index++)
            {
                KeyValuePair<Guid, TriggerTableData>? keyValuePair = _TrigTabMangerData.Manager.CurrentProduct?.TableTrigDatas?.ToList().FirstOrDefault((KeyValuePair<Guid, TriggerTableData> p) => p.Value.Name == dgTrigTable.Rows[index].Cells[1].Value.ToString());
                dgTrigTable.Rows[index].Cells[0].Value = index;
                dgTrigTable.Rows[index].Cells[2].Value = keyValuePair.Value.Value.TrigPoints.Count;
            }
            RefreshUi();
        }

        private void RefreshUi()
        {
            if (dgTrigTable.Rows.Count < 1)
            {
                txbNum.Text = "0";
                txbTotalNum.Text = "0";
                return;
            }
            int num = 0;
            for (int i = 0; i < dgTrigTable.Rows.Count; i++)
            {
                dgTrigTable.Rows[i].Cells[0].Value = i;
                num += Convert.ToInt32(dgTrigTable.Rows[i].Cells[2].Value);
            }
            txbNum.Text = dgTrigTable.Rows.Count.ToString();
            txbTotalNum.Text = num.ToString();
        }

        private void TbCmbInit(TrigTabMangerData tableTrigData)
        {
            tbTableTrigName.Text = tableTrigData.Name;
            tbTrigTrigId.Text = tableTrigData.Id.ToString();
            int num = 0;
            foreach (TrigTabCfg value in tableTrigData.TrigsList.Values)
            {
                num += value.PointNum;
            }
            txbNum.Text = tableTrigData.TrigsList.Count.ToString();
            txbTotalNum.Text = num.ToString();
        }

        private void tbTrigTrigId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void TrigTableControl_Load(object sender, EventArgs e)
        {
            TbCmbInit(_TrigTabMangerData);
            DgvTableTrigInit();
        }

        private void UpdateTrigTable()
        {
            cmbTrigTable.Items.Clear();
            cmbTrigTable.SelectedIndex = -1;
            _TrigTabMangerData.Manager.CurrentProduct?.TableTrigDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, TriggerTableData> p)
            {
                cmbTrigTable.Items.Add(p.Value.Name);
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgTrigTable = new System.Windows.Forms.DataGridView();
            this.colPosIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTabPointNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.标记 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOffsetType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportTablesToXml = new System.Windows.Forms.Button();
            this.btnExportTablesToCsv = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbTrigTable = new System.Windows.Forms.ComboBox();
            this.labSelectTab = new System.Windows.Forms.Label();
            this.txbTotalNum = new System.Windows.Forms.TextBox();
            this.lbtTrigPointsCount = new System.Windows.Forms.Label();
            this.btnClr = new System.Windows.Forms.Button();
            this.txbNum = new System.Windows.Forms.TextBox();
            this.lbTrigTableCount = new System.Windows.Forms.Label();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbTrigTrigId = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.tbTableTrigName = new System.Windows.Forms.TextBox();
            this.lbTrigName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.dgTrigTable).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.dgTrigTable.AllowUserToAddRows = false;
            this.dgTrigTable.AllowUserToDeleteRows = false;
            this.dgTrigTable.Columns.AddRange(this.colPosIndex, this.colTableName, this.colTabPointNum, this.标记, this.colOffsetType);
            this.dgTrigTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTrigTable.Location = new System.Drawing.Point(3, 144);
            this.dgTrigTable.Name = "dgTrigTable";
            this.dgTrigTable.RowTemplate.Height = 23;
            this.dgTrigTable.Size = new System.Drawing.Size(387, 225);
            this.dgTrigTable.TabIndex = 2;
            this.dgTrigTable.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(dgTrigTable_EditingControlShowing);
            this.colPosIndex.Frozen = true;
            this.colPosIndex.HeaderText = "序号";
            this.colPosIndex.Name = "colPosIndex";
            this.colPosIndex.ReadOnly = true;
            this.colPosIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPosIndex.Width = 42;
            this.colTableName.HeaderText = "触发表名称";
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;
            this.colTableName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTableName.Width = 120;
            this.colTabPointNum.HeaderText = "触发点数";
            this.colTabPointNum.Name = "colTabPointNum";
            this.colTabPointNum.ReadOnly = true;
            this.colTabPointNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTabPointNum.Width = 60;
            dataGridViewCellStyle.Format = "N0";
            dataGridViewCellStyle.NullValue = "0";
            this.标记.DefaultCellStyle = dataGridViewCellStyle;
            this.标记.HeaderText = "标识";
            this.标记.Name = "标记";
            this.标记.Width = 40;
            this.colOffsetType.HeaderText = "偏移点选择";
            this.colOffsetType.Items.AddRange("-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10");
            this.colOffsetType.Name = "colOffsetType";
            this.colOffsetType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOffsetType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colOffsetType.Width = 80;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.tableLayoutPanel1.Controls.Add(this.dgTrigTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.06147f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.93853f));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(393, 372);
            this.tableLayoutPanel1.TabIndex = 1;
            this.panel1.Controls.Add(this.btnExportTablesToXml);
            this.panel1.Controls.Add(this.btnExportTablesToCsv);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cmbTrigTable);
            this.panel1.Controls.Add(this.labSelectTab);
            this.panel1.Controls.Add(this.txbTotalNum);
            this.panel1.Controls.Add(this.lbtTrigPointsCount);
            this.panel1.Controls.Add(this.btnClr);
            this.panel1.Controls.Add(this.txbNum);
            this.panel1.Controls.Add(this.lbTrigTableCount);
            this.panel1.Controls.Add(this.btnRemoveRow);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.tbTrigTrigId);
            this.panel1.Controls.Add(this.lbId);
            this.panel1.Controls.Add(this.tbTableTrigName);
            this.panel1.Controls.Add(this.lbTrigName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 135);
            this.panel1.TabIndex = 3;
            this.panel1.DoubleClick += new System.EventHandler(Panel1_DoubleClick);
            this.btnExportTablesToXml.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExportTablesToXml.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.btnExportTablesToXml.Location = new System.Drawing.Point(123, 98);
            this.btnExportTablesToXml.Name = "btnExportTablesToXml";
            this.btnExportTablesToXml.Size = new System.Drawing.Size(77, 29);
            this.btnExportTablesToXml.TabIndex = 97;
            this.btnExportTablesToXml.Text = "导出XML";
            this.btnExportTablesToXml.UseVisualStyleBackColor = false;
            this.btnExportTablesToXml.Click += new System.EventHandler(BtnExportTablesToXml_Click);
            this.btnExportTablesToCsv.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExportTablesToCsv.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.btnExportTablesToCsv.Location = new System.Drawing.Point(47, 98);
            this.btnExportTablesToCsv.Name = "btnExportTablesToCsv";
            this.btnExportTablesToCsv.Size = new System.Drawing.Size(70, 29);
            this.btnExportTablesToCsv.TabIndex = 96;
            this.btnExportTablesToCsv.Text = "导出CSV";
            this.btnExportTablesToCsv.UseVisualStyleBackColor = false;
            this.btnExportTablesToCsv.Click += new System.EventHandler(BtnExportTablesToCsv_Click);
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 8.25f, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(228, 66);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 29);
            this.btnAdd.TabIndex = 95;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(BtnAdd_Click);
            this.cmbTrigTable.FormattingEnabled = true;
            this.cmbTrigTable.Location = new System.Drawing.Point(101, 68);
            this.cmbTrigTable.Name = "cmbTrigTable";
            this.cmbTrigTable.Size = new System.Drawing.Size(121, 25);
            this.cmbTrigTable.TabIndex = 94;
            this.labSelectTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labSelectTab.Font = new System.Drawing.Font("微软雅黑", 8.25f, System.Drawing.FontStyle.Bold);
            this.labSelectTab.Location = new System.Drawing.Point(8, 71);
            this.labSelectTab.Name = "labSelectTab";
            this.labSelectTab.Size = new System.Drawing.Size(79, 20);
            this.labSelectTab.TabIndex = 93;
            this.labSelectTab.Text = "选择触发表：";
            this.labSelectTab.Click += new System.EventHandler(LabSelectTab_Click);
            this.txbTotalNum.Font = new System.Drawing.Font("微软雅黑", 7.5f);
            this.txbTotalNum.Location = new System.Drawing.Point(250, 37);
            this.txbTotalNum.Name = "txbTotalNum";
            this.txbTotalNum.Size = new System.Drawing.Size(77, 21);
            this.txbTotalNum.TabIndex = 92;
            this.lbtTrigPointsCount.Font = new System.Drawing.Font("微软雅黑", 8.25f, System.Drawing.FontStyle.Bold);
            this.lbtTrigPointsCount.Location = new System.Drawing.Point(184, 38);
            this.lbtTrigPointsCount.Name = "lbtTrigPointsCount";
            this.lbtTrigPointsCount.Size = new System.Drawing.Size(60, 20);
            this.lbtTrigPointsCount.TabIndex = 91;
            this.lbtTrigPointsCount.Text = "总点数：";
            this.btnClr.BackColor = System.Drawing.Color.Tomato;
            this.btnClr.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.btnClr.Location = new System.Drawing.Point(206, 98);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(69, 29);
            this.btnClr.TabIndex = 90;
            this.btnClr.Text = "清空";
            this.btnClr.UseVisualStyleBackColor = false;
            this.btnClr.Click += new System.EventHandler(BtnClr_Click);
            this.txbNum.Font = new System.Drawing.Font("微软雅黑", 7.5f);
            this.txbNum.Location = new System.Drawing.Point(101, 39);
            this.txbNum.Name = "txbNum";
            this.txbNum.Size = new System.Drawing.Size(77, 21);
            this.txbNum.TabIndex = 89;
            this.lbTrigTableCount.Font = new System.Drawing.Font("微软雅黑", 8.25f, System.Drawing.FontStyle.Bold);
            this.lbTrigTableCount.Location = new System.Drawing.Point(8, 40);
            this.lbTrigTableCount.Name = "lbTrigTableCount";
            this.lbTrigTableCount.Size = new System.Drawing.Size(79, 20);
            this.lbTrigTableCount.TabIndex = 88;
            this.lbTrigTableCount.Text = "触发表数量：";
            this.btnRemoveRow.BackColor = System.Drawing.Color.Red;
            this.btnRemoveRow.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.btnRemoveRow.Location = new System.Drawing.Point(3, 98);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(38, 29);
            this.btnRemoveRow.TabIndex = 87;
            this.btnRemoveRow.Text = "-";
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            this.btnRemoveRow.Click += new System.EventHandler(btnRemoveRow_Click);
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            this.btnApply.Location = new System.Drawing.Point(281, 98);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(66, 29);
            this.btnApply.TabIndex = 86;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(btnApply_Click);
            this.tbTrigTrigId.Font = new System.Drawing.Font("微软雅黑", 7.5f);
            this.tbTrigTrigId.Location = new System.Drawing.Point(250, 7);
            this.tbTrigTrigId.Name = "tbTrigTrigId";
            this.tbTrigTrigId.Size = new System.Drawing.Size(41, 21);
            this.tbTrigTrigId.TabIndex = 85;
            this.tbTrigTrigId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbTrigTrigId_KeyPress);
            this.lbId.Font = new System.Drawing.Font("微软雅黑", 8.25f, System.Drawing.FontStyle.Bold);
            this.lbId.Location = new System.Drawing.Point(184, 8);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(40, 20);
            this.lbId.TabIndex = 84;
            this.lbId.Text = "ID：";
            this.tbTableTrigName.Font = new System.Drawing.Font("微软雅黑", 7.5f);
            this.tbTableTrigName.Location = new System.Drawing.Point(101, 6);
            this.tbTableTrigName.Name = "tbTableTrigName";
            this.tbTableTrigName.Size = new System.Drawing.Size(77, 21);
            this.tbTableTrigName.TabIndex = 83;
            this.lbTrigName.Font = new System.Drawing.Font("微软雅黑", 8.25f, System.Drawing.FontStyle.Bold);
            this.lbTrigName.Location = new System.Drawing.Point(8, 7);
            this.lbTrigName.Name = "lbTrigName";
            this.lbTrigName.Size = new System.Drawing.Size(79, 20);
            this.lbTrigName.TabIndex = 82;
            this.lbTrigName.Text = "触发表名称：";
            base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            base.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 7.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            base.Name = "TrigTabMangerControl";
            base.Size = new System.Drawing.Size(393, 372);
            base.Load += new System.EventHandler(TrigTableControl_Load);
            ((System.ComponentModel.ISupportInitialize)this.dgTrigTable).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }
        public void OnLanguageChanged()
        {
            lbTrigName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_TrigName", "触发表名称:");

            lbTrigTableCount.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_TrigTableCount", "触发表数量:");
            lbtTrigPointsCount.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_TrigPointsCount", "总点数:");
            labSelectTab.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_SelectTrigTable", "选择触发表:");
            btnAdd.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_Add", "添加");
            btnExportTablesToCsv.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_ExportTablesToCsv", "导出CSV");
            btnExportTablesToXml.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_ExportTablesToXml", "导出XML");
            btnClr.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_Clear", "清空");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_Apply", "应用");
            dgTrigTable.Columns["colPosIndex"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_colPosIndex", "序号");
            dgTrigTable.Columns["colTableName"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_colTableName", "触发表名称");
            dgTrigTable.Columns["colTabPointNum"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_colTabPointNum", "触发点数");
            dgTrigTable.Columns["标记"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_identification", "标识");
            dgTrigTable.Columns["colOffsetType"].HeaderText = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TrigTabMangerControl_colOffsetType", "偏移点选择");
        }
    }
}
