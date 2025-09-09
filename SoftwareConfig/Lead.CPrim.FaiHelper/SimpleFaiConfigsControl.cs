using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.FaiHelper
{
    public partial class SimpleFaiConfigsControl : UserControl
    {
        #region Field
        /// <summary>简单FAI管理器</summary>
        private SimpleFaiConfigs _simpleFaiConfigs;
        /// <summary>移除标志</summary>
        private bool _removing;
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="simpleFaiConfigs">简单FAI管理器</param>
        public SimpleFaiConfigsControl(SimpleFaiConfigs simpleFaiConfigs)
        {
            InitializeComponent();
            _simpleFaiConfigs = simpleFaiConfigs;
            tlpMain.SetDoubleBuffered();
            dgvFaisConfig.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void SimpleFaiConfigsControl_Load(object sender, EventArgs e)
        {
            tbName.Text = _simpleFaiConfigs.Name;
            chkEnable.Checked = _simpleFaiConfigs.Enable;
            chkIsUpload.Checked = _simpleFaiConfigs.IsUpload;
            chkIsOutput.Checked = _simpleFaiConfigs.IsOutput;

            AddConfigsToTable(_simpleFaiConfigs);
            //dgvFaisConfig.DataSource = _simpleFaiConfigs.FaiConfigs.Values.ToList();
        }
        private void dgvFaisConfig_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                if (!bool.Parse(dgvFaisConfig.Rows[e.RowIndex].Cells[4].Value.ToString()))
                {
                    return;
                }
                string nameFai = dgvFaisConfig.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (_simpleFaiConfigs.FaiConfigs.All((KeyValuePair<Guid, FaiConfig> p) => p.Value.Name != nameFai))
                {
                    MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_ErrMsg_NoFindCollectionInfo", "Fai配置集合中未找到该集合定义，请先应用保存，然后配置集合成员"));
                }
                else
                {
                    KeyValuePair<Guid, FaiConfig> fai = _simpleFaiConfigs.FaiConfigs.FirstOrDefault((KeyValuePair<Guid, FaiConfig> p) => p.Value.Name == nameFai);
                    fai.Value.IsParent = true;
                    ChildFaiConfigsForm form = new ChildFaiConfigsForm(fai.Value);
                    form.ShowDialog(this);
                }
            }
            if (e.ColumnIndex == 4 && !bool.TryParse(dgvFaisConfig.Rows[e.RowIndex].Cells[4].Value.ToString(), out var boolResult))
            {
                dgvFaisConfig.Rows[e.RowIndex].Cells[13].ReadOnly = !boolResult;
            }

            if (dgvFaisConfig.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }
        /// <summary>DataGridViewCheckBoxColumn数据实时生效</summary>
        private void dgvFaisConfig_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFaisConfig.IsCurrentCellDirty)
            {
                dgvFaisConfig.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion



        #region Button_Event
        /// <summary>CSV导出</summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string csvString = "";
            foreach (KeyValuePair<Guid, FaiConfig> fai in _simpleFaiConfigs.FaiConfigs.OrderBy((KeyValuePair<Guid, FaiConfig> p) => p.Value.Index))
            {
                if (csvString == "")
                {
                    csvString = fai.Value.CsvHeader() + "\r\n";
                }

                csvString += fai.Value.CsvValue() + "\r\n";

                if (!fai.Value.IsParent || fai.Value.ChildFaiConfigs == null)
                {
                    continue;
                }

                foreach (KeyValuePair<Guid, ChildFaiConfig> child in fai.Value.ChildFaiConfigs.OrderBy((KeyValuePair<Guid, ChildFaiConfig> p) => p.Value.Index))
                {
                    if (child.Value != null)
                    {
                        csvString += child.Value.CsvValue() + "\r\n";
                    }
                }
            }

            string path = null;

            FileHelper.SaveFileDialogMethod("", FilterType.CSV, DefaultExt.CSV, true, true, true, ref path);

            if (!string.IsNullOrEmpty(path))
            {
                CsvHelper.WriteStringToCsv(path, csvString, true);
            }
        }
        /// <summary>CSV导入</summary>
        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (!btnAddRow.Enabled)
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_ErrMsg_NoSelect", "请先应用当前配置，方可导入配置文件"));
                return;
            }

            string path = "";
            FileHelper.OpenFileDialogMethod("", FilterType.CSV, false, ref path);
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            List<string> faiStrList = new List<string>();
            CsvHelper.ReadCsvToListString(path, GlobalVariables.EncodingChinese, true, out faiStrList);


            int parentIndex = 0;
            int childIndex = 0;
            FaiConfig faiParent = new FaiConfig();
            foreach (string faiLine in faiStrList)
            {
                if (faiLine.Length < 10)
                {
                    continue;
                }

                if (!faiLine.Contains("子集"))
                {
                    FaiConfig fai = new FaiConfig();
                    fai.CsvToValue(faiLine);
                    fai.Index = parentIndex++;
                    faiParent = fai;
                    _simpleFaiConfigs.FaiConfigs.TryAdd(Guid.NewGuid(), fai);
                    continue;
                }

                ChildFaiConfig childfai = new ChildFaiConfig();
                childfai.CsvToValue(faiLine);
                if (faiParent.ChildFaiConfigs.Count == 0)
                {
                    childIndex = 0;
                }

                childfai.Index = childIndex++;
                faiParent.ChildFaiConfigs.TryAdd(Guid.NewGuid(), childfai);
            }
            AddConfigsToTable(_simpleFaiConfigs);
            //dgvFaisConfig.DataSource = _simpleFaiConfigs.FaiConfigs.Values.ToList();
        }
        /// <summary>算法导入</summary>
        private void btnLoadAgl_Click(object sender, EventArgs e)
        {
            LoadFaisFromAgl loadForm = new LoadFaisFromAgl(childFlag: false);
            loadForm.ShowDialog();
            if (loadForm.Fais.Count <= 0)
            {
                return;
            }

            //dgvFaisConfig.DataSource = loadForm.Fais;
            foreach (FaiConfig fai in loadForm.Fais)
            {
                AddOneFaiConfigToRow(fai);
            }
        }
        /// <summary>增加一行</summary>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            FaiConfig newFai = new FaiConfig(dgvFaisConfig.Rows.Count);
            AddOneFaiConfigToRow(newFai);
        }
        /// <summary>移除一行</summary>
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvFaisConfig.SelectedRows;
            if (selectedRows.Count == 0)
            {
                return;
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                dgvFaisConfig.Rows.Remove(row);
            }

            _removing = true;
            btnAddRow.Enabled = false;
            btnAddRow.BackColor = Color.DimGray;
        }
        /// <summary>上移一行</summary>
        private void btnRowUp_Click(object sender, EventArgs e)
        {
            if (!ControlHelper.DgvUpRows(ref dgvFaisConfig))
            {
                ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_ErrMsg_MoveUpFail", "上移失败！！！"));
            }
        }
        /// <summary>下移一行</summary>
        private void btnRowDown_Click(object sender, EventArgs e)
        {
            if (!ControlHelper.DgvDownRows(ref dgvFaisConfig))
            {
                ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_ErrMsg_MoveDownFail", "下移失败！！！"));
            }
        }
        /// <summary>应用</summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (ControlHelper.CheckDgvCellRepeat(dgvFaisConfig, ref errorText))
            {
                Notification.ShowError(errorText);
                return;
            }

            if (_removing)
            {
                _removing = false;
                btnAddRow.Enabled = true;
                btnAddRow.BackColor = Color.LimeGreen;
            }

            _simpleFaiConfigs.Name = tbName.Text;
            _simpleFaiConfigs.Enable = chkEnable.Checked;
            _simpleFaiConfigs.IsOutput = chkIsOutput.Checked;
            _simpleFaiConfigs.IsUpload = chkIsUpload.Checked;

            //子项数据保存
            ConcurrentDictionary<string, FaiConfig> oldChinldFaiConfigs = new ConcurrentDictionary<string, FaiConfig>();
            foreach (KeyValuePair<Guid, FaiConfig> faiConfig2 in _simpleFaiConfigs.FaiConfigs)
            {
                if (faiConfig2.Value.IsParent && faiConfig2.Value.ChildFaiConfigs.Count > 0)
                {
                    oldChinldFaiConfigs.TryAdd(faiConfig2.Value.Name, faiConfig2.Value);
                }
            }

            _simpleFaiConfigs.FaiConfigs.Clear();
            for (int i = 0; i < dgvFaisConfig.Rows.Count; i++)
            {
                DataGridViewRow row = dgvFaisConfig.Rows[i];
                FaiConfig newFaiConfigs = new FaiConfig();
                if (row.Cells[0].Value != null)
                {
                    newFaiConfigs.Name = row.Cells[0].Value.ToString();
                }
                newFaiConfigs.Enable = bool.TryParse(row.Cells[1].Value.ToString(), out var bool1) && bool1;
                newFaiConfigs.IsOutput = bool.TryParse(row.Cells[2].Value.ToString(), out var bool2) && bool2;
                newFaiConfigs.IsUpload = bool.TryParse(row.Cells[3].Value.ToString(), out var bool3) && bool3;
                newFaiConfigs.IsParent = bool.TryParse(row.Cells[4].Value.ToString(), out var bool4) && bool4;
                newFaiConfigs.IsVirtual = bool.TryParse(row.Cells[5].Value.ToString(), out var bool5) && bool5;
                newFaiConfigs.IsNonnegativeTo0 = bool.TryParse(row.Cells[6].Value.ToString(), out var bool6) && bool6;
                newFaiConfigs.IsNonnegativeToPositive = bool.TryParse(row.Cells[7].Value.ToString(), out var bool7) && bool7;
                newFaiConfigs.Normal = (double.TryParse(row.Cells[8].Value.ToString(), out var d1) ? d1 : 0.0);
                newFaiConfigs.TolUp = (double.TryParse(row.Cells[9].Value.ToString(), out var d2) ? d2 : 999.999);
                newFaiConfigs.TolLow = (double.TryParse(row.Cells[10].Value.ToString(), out var d3) ? d3 : (-999.999));
                newFaiConfigs.CompensationFactor = (double.TryParse(row.Cells[11].Value.ToString(), out var d4) ? d4 : 1.0);
                newFaiConfigs.Compensation = (double.TryParse(row.Cells[12].Value.ToString(), out var d5) ? d5 : 0.0);
                newFaiConfigs.Index = i;
                newFaiConfigs.Unit = row.Cells[14].Value.ToString();
                
                _simpleFaiConfigs.FaiConfigs.TryAdd(Guid.NewGuid(), newFaiConfigs);
            }

            foreach (KeyValuePair<Guid, FaiConfig> faiConfig in _simpleFaiConfigs.FaiConfigs)
            {
                if (oldChinldFaiConfigs.ContainsKey(faiConfig.Value.Name))
                {
                    faiConfig.Value.ChildFaiConfigs = oldChinldFaiConfigs[faiConfig.Value.Name].ChildFaiConfigs;
                }
            }
        }
        /// <summary>Panel控件双击</summary>
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            _simpleFaiConfigs.IsSelected = !_simpleFaiConfigs.IsSelected;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>添加所有数据至DataGridView（Load事件/CSV导入）</summary>
        /// <param name="simpleFaiConfigs">简单FAI管理器</param>
        private void AddConfigsToTable(SimpleFaiConfigs simpleFaiConfigs)
        {
            foreach (var item in simpleFaiConfigs.FaiConfigs.OrderBy((KeyValuePair<Guid, FaiConfig> p) => p.Value.Index))
            {
                AddOneFaiConfigToRow(item.Value);
            }
        }
        /// <summary>添加一行数据至DataGridView</summary>
        /// <param name="faiConfig">简单FAI数据行配置（Load事件/增加一行/算法导入）</param>
        private void AddOneFaiConfigToRow(FaiConfig faiConfig)
        {
            int index = dgvFaisConfig.Rows.Add();
            DataGridViewRow row = dgvFaisConfig.Rows[index];
            row.Cells[0].Value = faiConfig.Name;
            row.Cells[1].Value = faiConfig.Enable;
            row.Cells[2].Value = faiConfig.IsOutput;
            row.Cells[3].Value = faiConfig.IsUpload;
            row.Cells[4].Value = faiConfig.IsParent;
            row.Cells[5].Value = faiConfig.IsVirtual;
            row.Cells[6].Value = faiConfig.IsNonnegativeTo0;
            row.Cells[7].Value = faiConfig.IsNonnegativeToPositive;
            row.Cells[8].Value = faiConfig.Normal.ToString("F3");
            row.Cells[9].Value = faiConfig.TolUp.ToString("F3");
            row.Cells[10].Value = faiConfig.TolLow.ToString("F3");
            row.Cells[11].Value = faiConfig.CompensationFactor.ToString("F3");
            row.Cells[12].Value = faiConfig.Compensation.ToString("F3");
            row.Cells[13].ReadOnly = faiConfig.IsParent;
            row.Cells[14].Value = faiConfig.Unit;
        }
        #endregion

        public void OnLanguageChanged()
        {
            lbName.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_Name", "名称:");
            chkEnable.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_Enable", "使能");
            chkIsOutput.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_IsOutput", "输出");
            chkIsUpload.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_IsUpload", "上传");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_Apply", "应用");
            btnExport.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_Export", "CSV导出");
            btnImport.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_Import", "CSV导入");

            dgvFaisConfig.Columns["colName"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colName", "名称");
            dgvFaisConfig.Columns["colEnable"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colEnable", "开判");
             dgvFaisConfig.Columns["colIsOutput"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colIsOutput", "输出");
            dgvFaisConfig.Columns["colIsUpload"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colIsUpload", "上传");
            dgvFaisConfig.Columns["colIsParent"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colIsParent", "集合");
            dgvFaisConfig.Columns["colIsVirtual"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colIsVirtual", "虚拟");
            dgvFaisConfig.Columns["colIsNonnegativeTo0"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colIsNonnegativeTo0", "非正取零");
            dgvFaisConfig.Columns["colIsNonnegativeToPositive"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colIsNonnegativeToPositive", "非正取正");
            dgvFaisConfig.Columns["colNormal"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colNormal", "标准值");
            dgvFaisConfig.Columns["colTolUp"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colTolUp", "上限");
            dgvFaisConfig.Columns["colTolLow"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colTolLow", "下限");
            dgvFaisConfig.Columns["colCompensationFactor"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colCompensationFactor", "补偿系数");
            dgvFaisConfig.Columns["colCompensation"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colCompensation", "补偿值");
            dgvFaisConfig.Columns["colParent"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_colParent", "子集");
            dgvFaisConfig.Columns["Unit"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_SimpleFaiConfigsControl_Unit", "单位");
        }
    }
}
