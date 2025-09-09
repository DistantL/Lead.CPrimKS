using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper.ComplexFais
{
	public class ComplexFaiControl : UserControl
	{
		private bool _removing;

		public ComplexFaiConfigs _complexFaiConfigs;

		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private IContainer components = null;

		private TableLayoutPanel tablePanelFaiConfig;

		private Panel panel1;

		private Button btnRowDown;

		private Button btnRowUp;

		private CheckBox chkIsUpload;

		private CheckBox chkIsOutput;

		private CheckBox chkEnable;

		private TextBox tbName;

		private Label lbName;

		private Button btnRemoveRow;

		private Button btnAddRow;

		private Button btnApply;

		private DataGridView dgvFaisConfig;

		private Button btnExport;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAlias;
        private DataGridViewCheckBoxColumn colEnable;
        private DataGridViewCheckBoxColumn colIsOutput;
        private DataGridViewCheckBoxColumn colIsDishist;
        private DataGridViewCheckBoxColumn colIsParent;
        private DataGridViewComboBoxColumn colFaiType;
        private DataGridViewCheckBoxColumn colIsNonnegativeTo0;
        private DataGridViewCheckBoxColumn colIsNonnegativeToPositive;
        private DataGridViewTextBoxColumn colNormal;
        private DataGridViewTextBoxColumn colTolUp;
        private DataGridViewTextBoxColumn colTolLow;
        private DataGridViewTextBoxColumn colTolUp2;
        private DataGridViewTextBoxColumn dgvTolLow2;
        private DataGridViewButtonColumn colOffset;
        private DataGridViewButtonColumn colParent;
        private DataGridViewTextBoxColumn Unit;
        private Button btnImport;

		public ComplexFaiControl()
		{
			InitializeComponent();
		}

		public ComplexFaiControl(ComplexFaiConfigs complexFai)
		{
			InitializeComponent();
			_complexFaiConfigs = complexFai;

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}

		private void AddConfigsToTable(ComplexFaiConfigs complexFais)
		{
			ClearTable();
			foreach (KeyValuePair<Guid, ComplexFai> item in complexFais.FaiConfigs.OrderBy((KeyValuePair<Guid, ComplexFai> p) => p.Value.Index))
			{
				AddOneFaiConfigToRow(item.Value);
			}
		}

		private void AddOneFaiConfigToRow(ComplexFai faiConfig)
		{
			int index = dgvFaisConfig.Rows.Add();
			DataGridViewRow row = dgvFaisConfig.Rows[index];
			row.Cells[0].Value = faiConfig.Name;
			row.Cells[1].Value = faiConfig.Alias;
			row.Cells[2].Value = faiConfig.Enable;
			row.Cells[3].Value = faiConfig.IsOutput;
			row.Cells[4].Value = faiConfig.IsDishist;
			row.Cells[5].Value = faiConfig.IsParent;
			row.Cells[6].Value = faiConfig.AglSelect.ToString();
			row.Cells[7].Value = faiConfig.IsNonnegativeTo0;
			row.Cells[8].Value = faiConfig.IsNonnegativeToPositive;
			row.Cells[9].Value = faiConfig.Normal.ToString("F3");
			row.Cells[10].Value = faiConfig.TolUp.ToString("F3");
			row.Cells[11].Value = faiConfig.TolLow.ToString("F3");
			row.Cells[12].Value = faiConfig.TolUp2.ToString("F3");
			row.Cells[13].Value = faiConfig.TolLow2.ToString("F3");
		}

		private void ClearTable()
		{
			dgvFaisConfig.Rows.Clear();
			dgvFaisConfig.Refresh();
		}

		private void btnAddRow_Click(object sender, EventArgs e)
		{
			ComplexFai newFai = new ComplexFai(dgvFaisConfig.Rows.Count, _complexFaiConfigs.CaveCnt);
			AddOneFaiConfigToRow(newFai);
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			string errorText = "";
			if (ControlHelper.CheckDgvCellRepeat(dgvFaisConfig, ref errorText))
			{
				ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_ErrMes_FaiNameRepeat", "FAI名称重复:") + errorText);
				return;
			}
			//if (ControlHelper.CheckDgvCellRepeat(ref dgvFaisConfig, 0))
			//{
			//	MessageBox.Show("有Fai名称重复，请检查标红项");
			//	return;
			//}
			if (_removing)
			{
				_removing = false;
				btnAddRow.Enabled = true;
				btnAddRow.BackColor = Color.LimeGreen;
			}
			_complexFaiConfigs.Name = tbName.Text;
			_complexFaiConfigs.Enable = chkEnable.Checked;
			_complexFaiConfigs.IsOutput = chkIsOutput.Checked;
			_complexFaiConfigs.IsUpload = chkIsUpload.Checked;
			ConcurrentDictionary<string, ComplexFai> oldFaiConfigs = new ConcurrentDictionary<string, ComplexFai>();
			foreach (KeyValuePair<Guid, ComplexFai> faiConfig in _complexFaiConfigs.FaiConfigs)
			{
				oldFaiConfigs.TryAdd(faiConfig.Value.Name, faiConfig.Value);
			}
			_complexFaiConfigs.FaiConfigs.Clear();
			for (int i = 0; i < dgvFaisConfig.Rows.Count; i++)
			{
				DataGridViewRow row = dgvFaisConfig.Rows[i];
				ComplexFai newFaiConfigs = new ComplexFai(i, _complexFaiConfigs.CaveCnt);
				if (row.Cells[0].Value != null)
				{
					newFaiConfigs.Name = row.Cells[0].Value.ToString();
				}
				if (row.Cells[1].Value != null)
				{
					newFaiConfigs.Alias = row.Cells[1].Value.ToString();
				}
				newFaiConfigs.Enable = bool.TryParse(row.Cells[2].Value.ToString(), out var bool1) && bool1;
				newFaiConfigs.IsOutput = bool.TryParse(row.Cells[3].Value.ToString(), out var bool2) && bool2;
				newFaiConfigs.IsDishist = bool.TryParse(row.Cells[4].Value.ToString(), out var bool3) && bool3;
				newFaiConfigs.IsParent = bool.TryParse(row.Cells[5].Value.ToString(), out var bool4) && bool4;
				newFaiConfigs.AglSelect = (Enum.TryParse<AglType>(row.Cells[6].Value.ToString(), out var aglsel) ? aglsel : AglType.None);
				newFaiConfigs.IsNonnegativeTo0 = bool.TryParse(row.Cells[7].Value.ToString(), out var bool5) && bool5;
				newFaiConfigs.IsNonnegativeToPositive = bool.TryParse(row.Cells[8].Value.ToString(), out var bool6) && bool6;
				newFaiConfigs.Normal = (double.TryParse(row.Cells[9].Value.ToString(), out var d1) ? d1 : 0.0);
				newFaiConfigs.TolUp = (double.TryParse(row.Cells[10].Value.ToString(), out var d2) ? d2 : 999.999);
				newFaiConfigs.TolLow = (double.TryParse(row.Cells[11].Value.ToString(), out var d4) ? d4 : (-999.999));
				newFaiConfigs.TolUp2 = (double.TryParse(row.Cells[12].Value.ToString(), out var d3) ? d3 : 0.0);
				newFaiConfigs.TolLow2 = (double.TryParse(row.Cells[13].Value.ToString(), out var d5) ? d5 : 0.0);
				_complexFaiConfigs.FaiConfigs.TryAdd(Guid.NewGuid(), newFaiConfigs);
			}
			foreach (KeyValuePair<Guid, ComplexFai> faiConfig2 in _complexFaiConfigs.FaiConfigs)
			{
				if (oldFaiConfigs.ContainsKey(faiConfig2.Value.Name))
				{
					faiConfig2.Value.Offsets = oldFaiConfigs[faiConfig2.Value.Name].Offsets;
					faiConfig2.Value.Ki = oldFaiConfigs[faiConfig2.Value.Name].Ki;
					faiConfig2.Value.ChildFaiConfigs = oldFaiConfigs[faiConfig2.Value.Name].ChildFaiConfigs;
				}
				if (faiConfig2.Value.Offsets == null || faiConfig2.Value.Offsets.Count != _complexFaiConfigs.CaveCnt)
				{
					for (int j = 0; j < _complexFaiConfigs.CaveCnt; j++)
					{
						faiConfig2.Value.Offsets.Add(new Offset(j));
					}
				}
			}
		}

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

		private void btnRowDown_Click(object sender, EventArgs e)
		{
			ControlHelper.DgvDownRows(ref dgvFaisConfig);
		}

		private void btnRowUp_Click(object sender, EventArgs e)
		{
			ControlHelper.DgvUpRows(ref dgvFaisConfig);
		}

		private void dgvFaisConfig_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 15)
			{
				if (!bool.Parse(dgvFaisConfig.Rows[e.RowIndex].Cells[5].Value.ToString()))
				{
					return;
				}
				string nameFai2 = dgvFaisConfig.Rows[e.RowIndex].Cells[0].Value.ToString();
				if (_complexFaiConfigs.FaiConfigs.All((KeyValuePair<Guid, ComplexFai> p) => p.Value.Name != nameFai2))
				{
					MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_ErrMes_FaiSubsetNoFind", "Fai配置集合中未找到该集合定义，请先应用保存，然后配置集合成员"));
				}
				else
				{
					KeyValuePair<Guid, ComplexFai> fai2 = _complexFaiConfigs.FaiConfigs.FirstOrDefault((KeyValuePair<Guid, ComplexFai> p) => p.Value.Name == nameFai2);
					fai2.Value.IsParent = true;
					switch (fai2.Value.AglSelect)
					{
					case AglType.None:
					case AglType.Parallelism:
					case AglType.Profile:
					case AglType.Flatness:
					{
						ComplexChildFrm frm2 = new ComplexChildFrm(fai2.Value);
						frm2.ShowDialog();
						break;
					}
					case AglType.Distance:
					{
						DistanceForm frm3 = new DistanceForm(fai2.Value, _complexFaiConfigs);
						frm3.ShowDialog();
						break;
					}
					}
				}
			}
			if (e.ColumnIndex == 5 && !bool.TryParse(dgvFaisConfig.Rows[e.RowIndex].Cells[5].Value.ToString(), out var boolResult))
			{
				dgvFaisConfig.Rows[e.RowIndex].Cells[15].ReadOnly = !boolResult;
			}
			if (e.ColumnIndex != 14)
			{
				return;
			}
			string nameFai = dgvFaisConfig.Rows[e.RowIndex].Cells[0].Value.ToString();
			KeyValuePair<Guid, ComplexFai> fai = _complexFaiConfigs.FaiConfigs.FirstOrDefault((KeyValuePair<Guid, ComplexFai> p) => p.Value.Name == nameFai);
			if (fai.Value != null)
			{
				if (fai.Value.Offsets == null)
				{
					fai.Value.Offsets = new List<Offset>();
				}
				if (fai.Value.Offsets.Count != _complexFaiConfigs.CaveCnt)
				{
					MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_ErrMes_SlotNumberNoSame", "当前设置的穴位数与导入的CSV穴位数不相等，请检查！") , "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				FormOffset frm = new FormOffset(fai.Value.Offsets);
				frm.ShowDialog();
			}
		}

		private void panel1_DoubleClick(object sender, EventArgs e)
		{
			_complexFaiConfigs.IsSelected = !_complexFaiConfigs.IsSelected;
		}

		private void ComplexFaiConfigsControl_Load(object sender, EventArgs e)
		{
			tbName.Text = _complexFaiConfigs.Name;
			chkEnable.Checked = _complexFaiConfigs.Enable;
			chkIsUpload.Checked = _complexFaiConfigs.IsUpload;
			chkIsOutput.Checked = _complexFaiConfigs.IsOutput;
			AddConfigsToTable(_complexFaiConfigs);
			foreach (KeyValuePair<Guid, ComplexFai> complexFaiConfig in _complexFaiConfigs.FaiConfigs)
			{
				if (complexFaiConfig.Value.Offsets == null)
				{
					complexFaiConfig.Value.Offsets = new List<Offset>(complexFaiConfig.Value.CaveCount);
				}
				if (complexFaiConfig.Value.Offsets.Count != complexFaiConfig.Value.CaveCount)
				{
					for (int j = 0; j < complexFaiConfig.Value.CaveCount; j++)
					{
						complexFaiConfig.Value.Offsets.Add(new Offset(j));
					}
				}
				if (!complexFaiConfig.Value.IsParent || complexFaiConfig.Value.ChildFaiConfigs.Count <= 0)
				{
					continue;
				}
				foreach (KeyValuePair<Guid, ComplexChildFai> childFaiConfig in complexFaiConfig.Value.ChildFaiConfigs)
				{
					if (childFaiConfig.Value.Offsets == null)
					{
						childFaiConfig.Value.Offsets = new List<Offset>(complexFaiConfig.Value.CaveCount);
					}
					if (childFaiConfig.Value.Offsets.Count != complexFaiConfig.Value.CaveCount)
					{
						for (int i = 0; i < complexFaiConfig.Value.CaveCount; i++)
						{
							childFaiConfig.Value.Offsets.Add(new Offset(i));
						}
					}
				}
			}
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			try
			{
				string csvString = "";
				foreach (KeyValuePair<Guid, ComplexFai> fai in _complexFaiConfigs.FaiConfigs.OrderBy((KeyValuePair<Guid, ComplexFai> p) => p.Value.Index))
				{
					if (csvString == "")
					{
						csvString = fai.Value.CsvHeader() + "\r\n";
					}
					csvString = csvString + fai.Value.CsvValue() + "\r\n";
					if (!fai.Value.IsParent || fai.Value.ChildFaiConfigs == null)
					{
						continue;
					}
					foreach (KeyValuePair<Guid, ComplexChildFai> child in fai.Value.ChildFaiConfigs.OrderBy((KeyValuePair<Guid, ComplexChildFai> p) => p.Value.Index))
					{
						if (child.Value != null)
						{
							csvString = csvString + child.Value.CsvValue() + "\r\n";
						}
					}
				}
				SaveFileDialog std = new SaveFileDialog();
				std.AddExtension = true;
				std.Filter = "*.csv|";
				std.DefaultExt = ".csv";
				if (std.ShowDialog() == DialogResult.OK)
				{
					string path = std.FileName.ToString();
					FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
					StreamWriter reader = new StreamWriter(fs, GlobalVariables.EncodingChinese);
					reader.WriteLine(csvString);
					reader.Flush();
					reader.Close();
					fs.Close();
				}
			}
			catch (Exception ex)
			{
				string message = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_ErrMes_ExportFail", "导出时发生错误，错误信息：") + ex.ToString();
				MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				if (!btnAddRow.Enabled)
				{
					MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_ErrMes_CurrentSettingNoSet", "请先应用当前配置，方可导入配置文件"));
					return;
				}
				string path = "";
				OpenFileDialog fd = new OpenFileDialog
				{
					Filter = "(Product Param)|*.csv",
					Multiselect = false
				};
				if (fd.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				path = fd.FileName;
				List<string> faiStrList = new List<string>();
				StreamReader reader = new StreamReader(path, GlobalVariables.EncodingChinese);
				int parentIndex = 0;
				int childIndex = 0;
				while (true)
				{
					string str = reader.ReadLine();
					if (str != null)
					{
						if (str.Split(',')[0] != "名称")
						{
							faiStrList.Add(str);
						}
						continue;
					}
					break;
				}
				reader.Close();
				ComplexFai faiParent = new ComplexFai();
				_complexFaiConfigs.FaiConfigs.Clear();
				foreach (string faiLine in faiStrList)
				{
					if (faiLine.Length < 10)
					{
						continue;
					}
					if (!faiLine.Contains("子集"))
					{
						ComplexFai fai = new ComplexFai();
						fai.CsvToValue(faiLine);
						fai.Index = parentIndex++;
						faiParent = fai;
						_complexFaiConfigs.CaveCnt = fai.CaveCount;
						_complexFaiConfigs.FaiConfigs.TryAdd(Guid.NewGuid(), fai);
						continue;
					}
					ComplexChildFai childfai = new ComplexChildFai();
					childfai.CsvToValue(faiLine);
					if (faiParent.ChildFaiConfigs.Count == 0)
					{
						childIndex = 0;
					}
					childfai.Index = childIndex++;
					faiParent.ChildFaiConfigs.TryAdd(Guid.NewGuid(), childfai);
				}
				AddConfigsToTable(_complexFaiConfigs);
			}
			catch (Exception ex)
			{
				string message = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_ErrMes_ImportFail", "导入时发生错误，错误信息：") + ex.ToString();
				MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.tablePanelFaiConfig = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnRowDown = new System.Windows.Forms.Button();
            this.btnRowUp = new System.Windows.Forms.Button();
            this.chkIsUpload = new System.Windows.Forms.CheckBox();
            this.chkIsOutput = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.dgvFaisConfig = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsOutput = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsDishist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsParent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFaiType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colIsNonnegativeTo0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsNonnegativeToPositive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTolUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTolLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTolUp2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTolLow2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOffset = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colParent = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablePanelFaiConfig.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaisConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanelFaiConfig
            // 
            this.tablePanelFaiConfig.ColumnCount = 1;
            this.tablePanelFaiConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelFaiConfig.Controls.Add(this.panel1, 0, 0);
            this.tablePanelFaiConfig.Controls.Add(this.dgvFaisConfig, 0, 1);
            this.tablePanelFaiConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelFaiConfig.Location = new System.Drawing.Point(0, 0);
            this.tablePanelFaiConfig.Name = "tablePanelFaiConfig";
            this.tablePanelFaiConfig.RowCount = 2;
            this.tablePanelFaiConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tablePanelFaiConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanelFaiConfig.Size = new System.Drawing.Size(1312, 723);
            this.tablePanelFaiConfig.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnRowDown);
            this.panel1.Controls.Add(this.btnRowUp);
            this.panel1.Controls.Add(this.chkIsUpload);
            this.panel1.Controls.Add(this.chkIsOutput);
            this.panel1.Controls.Add(this.chkEnable);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.btnRemoveRow);
            this.panel1.Controls.Add(this.btnAddRow);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1306, 44);
            this.panel1.TabIndex = 2;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(728, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 29);
            this.btnExport.TabIndex = 79;
            this.btnExport.Text = "CSV导出";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnImport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.Location = new System.Drawing.Point(845, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(99, 29);
            this.btnImport.TabIndex = 78;
            this.btnImport.Text = "CSV导入";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnRowDown
            // 
            this.btnRowDown.BackColor = System.Drawing.Color.Gold;
            this.btnRowDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRowDown.Location = new System.Drawing.Point(515, 4);
            this.btnRowDown.Name = "btnRowDown";
            this.btnRowDown.Size = new System.Drawing.Size(47, 29);
            this.btnRowDown.TabIndex = 76;
            this.btnRowDown.Text = "👇";
            this.btnRowDown.UseVisualStyleBackColor = false;
            this.btnRowDown.Click += new System.EventHandler(this.btnRowDown_Click);
            // 
            // btnRowUp
            // 
            this.btnRowUp.BackColor = System.Drawing.Color.Gold;
            this.btnRowUp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRowUp.Location = new System.Drawing.Point(450, 4);
            this.btnRowUp.Name = "btnRowUp";
            this.btnRowUp.Size = new System.Drawing.Size(47, 29);
            this.btnRowUp.TabIndex = 75;
            this.btnRowUp.Text = "👆";
            this.btnRowUp.UseVisualStyleBackColor = false;
            this.btnRowUp.Click += new System.EventHandler(this.btnRowUp_Click);
            // 
            // chkIsUpload
            // 
            this.chkIsUpload.AutoSize = true;
            this.chkIsUpload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsUpload.Location = new System.Drawing.Point(250, 9);
            this.chkIsUpload.Name = "chkIsUpload";
            this.chkIsUpload.Size = new System.Drawing.Size(51, 21);
            this.chkIsUpload.TabIndex = 72;
            this.chkIsUpload.Text = "上传";
            this.chkIsUpload.UseVisualStyleBackColor = true;
            // 
            // chkIsOutput
            // 
            this.chkIsOutput.AutoSize = true;
            this.chkIsOutput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsOutput.Location = new System.Drawing.Point(193, 9);
            this.chkIsOutput.Name = "chkIsOutput";
            this.chkIsOutput.Size = new System.Drawing.Size(51, 21);
            this.chkIsOutput.TabIndex = 71;
            this.chkIsOutput.Text = "输出";
            this.chkIsOutput.UseVisualStyleBackColor = true;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEnable.Location = new System.Drawing.Point(136, 9);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(51, 21);
            this.chkEnable.TabIndex = 70;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbName.Location = new System.Drawing.Point(52, 8);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(77, 21);
            this.tbName.TabIndex = 69;
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(3, 8);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(60, 20);
            this.lbName.TabIndex = 68;
            this.lbName.Text = "名称：";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.BackColor = System.Drawing.Color.Red;
            this.btnRemoveRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveRow.Location = new System.Drawing.Point(385, 4);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(47, 29);
            this.btnRemoveRow.TabIndex = 67;
            this.btnRemoveRow.Text = "-";
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Location = new System.Drawing.Point(320, 4);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(47, 29);
            this.btnAddRow.TabIndex = 66;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(590, 5);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(99, 29);
            this.btnApply.TabIndex = 65;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // dgvFaisConfig
            // 
            this.dgvFaisConfig.AllowUserToAddRows = false;
            this.dgvFaisConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaisConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colAlias,
            this.colEnable,
            this.colIsOutput,
            this.colIsDishist,
            this.colIsParent,
            this.colFaiType,
            this.colIsNonnegativeTo0,
            this.colIsNonnegativeToPositive,
            this.colNormal,
            this.colTolUp,
            this.colTolLow,
            this.colTolUp2,
            this.dgvTolLow2,
            this.colOffset,
            this.colParent,
            this.Unit});
            this.dgvFaisConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFaisConfig.Location = new System.Drawing.Point(3, 53);
            this.dgvFaisConfig.Name = "dgvFaisConfig";
            this.dgvFaisConfig.RowHeadersWidth = 51;
            this.dgvFaisConfig.RowTemplate.Height = 23;
            this.dgvFaisConfig.Size = new System.Drawing.Size(1306, 667);
            this.dgvFaisConfig.TabIndex = 3;
            this.dgvFaisConfig.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaisConfig_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 90;
            // 
            // colAlias
            // 
            this.colAlias.HeaderText = "别名";
            this.colAlias.MinimumWidth = 6;
            this.colAlias.Name = "colAlias";
            this.colAlias.Width = 90;
            // 
            // colEnable
            // 
            this.colEnable.HeaderText = "开判";
            this.colEnable.MinimumWidth = 6;
            this.colEnable.Name = "colEnable";
            this.colEnable.Width = 40;
            // 
            // colIsOutput
            // 
            this.colIsOutput.HeaderText = "输出";
            this.colIsOutput.MinimumWidth = 6;
            this.colIsOutput.Name = "colIsOutput";
            this.colIsOutput.Width = 40;
            // 
            // colIsDishist
            // 
            this.colIsDishist.HeaderText = "直方图";
            this.colIsDishist.Name = "colIsDishist";
            this.colIsDishist.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsDishist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsDishist.Width = 70;
            // 
            // colIsParent
            // 
            this.colIsParent.HeaderText = "集合";
            this.colIsParent.MinimumWidth = 6;
            this.colIsParent.Name = "colIsParent";
            this.colIsParent.Width = 50;
            // 
            // colFaiType
            // 
            this.colFaiType.HeaderText = "算法类型";
            this.colFaiType.Items.AddRange(new object[] {
            "None",
            "Parallelism",
            "Profile",
            "Flatness",
            "Distance"});
            this.colFaiType.MinimumWidth = 6;
            this.colFaiType.Name = "colFaiType";
            this.colFaiType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFaiType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colFaiType.Width = 125;
            // 
            // colIsNonnegativeTo0
            // 
            this.colIsNonnegativeTo0.HeaderText = "非正取零";
            this.colIsNonnegativeTo0.MinimumWidth = 6;
            this.colIsNonnegativeTo0.Name = "colIsNonnegativeTo0";
            this.colIsNonnegativeTo0.Width = 70;
            // 
            // colIsNonnegativeToPositive
            // 
            this.colIsNonnegativeToPositive.HeaderText = "非正取正";
            this.colIsNonnegativeToPositive.MinimumWidth = 6;
            this.colIsNonnegativeToPositive.Name = "colIsNonnegativeToPositive";
            this.colIsNonnegativeToPositive.Width = 70;
            // 
            // colNormal
            // 
            this.colNormal.HeaderText = "Norminal";
            this.colNormal.MinimumWidth = 6;
            this.colNormal.Name = "colNormal";
            this.colNormal.Width = 80;
            // 
            // colTolUp
            // 
            this.colTolUp.HeaderText = "Tol+";
            this.colTolUp.MinimumWidth = 6;
            this.colTolUp.Name = "colTolUp";
            this.colTolUp.Width = 80;
            // 
            // colTolLow
            // 
            this.colTolLow.HeaderText = "Tol-";
            this.colTolLow.MinimumWidth = 6;
            this.colTolLow.Name = "colTolLow";
            this.colTolLow.Width = 80;
            // 
            // colTolUp2
            // 
            this.colTolUp2.HeaderText = "严收+";
            this.colTolUp2.MinimumWidth = 6;
            this.colTolUp2.Name = "colTolUp2";
            this.colTolUp2.Width = 80;
            // 
            // dgvTolLow2
            // 
            this.dgvTolLow2.HeaderText = "严收-";
            this.dgvTolLow2.MinimumWidth = 6;
            this.dgvTolLow2.Name = "dgvTolLow2";
            this.dgvTolLow2.Width = 80;
            // 
            // colOffset
            // 
            this.colOffset.HeaderText = "补偿值";
            this.colOffset.MinimumWidth = 6;
            this.colOffset.Name = "colOffset";
            this.colOffset.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOffset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colOffset.Width = 70;
            // 
            // colParent
            // 
            this.colParent.HeaderText = "子集";
            this.colParent.MinimumWidth = 6;
            this.colParent.Name = "colParent";
            this.colParent.Width = 50;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // ComplexFaiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tablePanelFaiConfig);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ComplexFaiControl";
            this.Size = new System.Drawing.Size(1312, 723);
            this.Load += new System.EventHandler(this.ComplexFaiConfigsControl_Load);
            this.tablePanelFaiConfig.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaisConfig)).EndInit();
            this.ResumeLayout(false);

		}

		public void OnLanguageChanged()
		{
			lbName.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_Name", "名称:");
			chkEnable.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_Enable", "使能");
			chkIsOutput.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_IsOutput", "输出");
			chkIsUpload.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_IsUpload", "上传");
			btnApply.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_Apply", "应用");
			btnExport.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_Export", "CSV导出");
			btnImport.Text = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_Import", "CSV导入");

            dgvFaisConfig.Columns["colName"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colName", "名称");
            dgvFaisConfig.Columns["colAlias"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colAlias", "别名");
            dgvFaisConfig.Columns["colEnable"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colEnable", "开判");
            dgvFaisConfig.Columns["colAlias"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colAlias", "别名");
            dgvFaisConfig.Columns["colIsOutput"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colIsOutput", "输出");
            dgvFaisConfig.Columns["colIsDishist"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colIsDishist", "直方图");
            dgvFaisConfig.Columns["colIsParent"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colIsParent", "集合");
            dgvFaisConfig.Columns["colFaiType"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colFaiType", "算法类型");
            dgvFaisConfig.Columns["colIsNonnegativeTo0"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colIsNonnegativeTo0", "非正取零");
            dgvFaisConfig.Columns["colIsNonnegativeToPositive"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colIsNonnegativeToPositive", "非正取正");
            dgvFaisConfig.Columns["colNormal"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colNormal", "标准值");
            dgvFaisConfig.Columns["colTolUp"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colTolUp", "上限");
            dgvFaisConfig.Columns["colTolLow"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colTolLow", "下限");
            dgvFaisConfig.Columns["colTolUp2"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colTolUp2", "严收上限");
            dgvFaisConfig.Columns["dgvTolLow2"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_dgvTolLow2", "严收下限");
            dgvFaisConfig.Columns["colOffset"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colOffset", "补偿值");
            dgvFaisConfig.Columns["colParent"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_colParent", "子集");
            dgvFaisConfig.Columns["Unit"].HeaderText = NLocalizer.GetString("Lead_CPrim_FaiHelper_ComplexFais_ComplexFaiControl_Unit", "单位");
        }
	}
}
