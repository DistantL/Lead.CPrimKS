using Lead.CPrim.ProxyTools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper.ComplexFais
{
	public class ComplexChildFrm : Form
	{
		private ComplexFai _faiConfig;

		private bool _removing;

		

		public ComplexChildFrm()
		{
			InitializeComponent();
		}

		public ComplexChildFrm(ComplexFai faiConfig)
		{
			InitializeComponent();
			_faiConfig = faiConfig;
		}

		private void AddConfigsToTable(ComplexFai faiConfig)
		{
			Invoke(new Action(Action1));
			void Action1()
			{
				foreach (KeyValuePair<Guid, ComplexChildFai> childFaiConfig in faiConfig.ChildFaiConfigs.OrderBy((KeyValuePair<Guid, ComplexChildFai> p) => p.Value.Index))
				{
					AddOneFaiConfigToRow(childFaiConfig.Value);
				}
			}
		}

		private void AddOneFaiConfigToRow(ComplexChildFai childFaiConfig)
		{
			int index = dgvFaisConfig.Rows.Add();
			DataGridViewRow row = dgvFaisConfig.Rows[index];
			row.Cells[0].Value = childFaiConfig.Name;
			row.Cells[1].Value = childFaiConfig.Alias;
			row.Cells[2].Value = childFaiConfig.Enable;
			row.Cells[3].Value = childFaiConfig.IsOutput;
			row.Cells[4].Value = childFaiConfig.IsDishist;
			row.Cells[5].Value = childFaiConfig.IsNonnegativeTo0;
			row.Cells[6].Value = childFaiConfig.IsNonnegativeToPositive;
			row.Cells[7].Value = childFaiConfig.Normal.ToString("F3");
			row.Cells[8].Value = childFaiConfig.TolUp.ToString("F3");
			row.Cells[9].Value = childFaiConfig.TolLow.ToString("F3");
			row.Cells[10].Value = childFaiConfig.TolUp2.ToString("F3");
			row.Cells[11].Value = childFaiConfig.TolLow2.ToString("F3");
		}

		private void btnAddRow_Click(object sender, EventArgs e)
		{
			ComplexChildFai newChildFai = new ComplexChildFai(dgvFaisConfig.Rows.Count, _faiConfig.CaveCount);
			AddOneFaiConfigToRow(newChildFai);
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
            string errorText = "";
            if (ControlHelper.CheckDgvCellRepeat(dgvFaisConfig, ref errorText))
            {
                ProxyTools.Notification.ShowError("FAI名称重复：" + errorText);
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
			ConcurrentDictionary<string, ComplexChildFai> oldFaiConfigs = new ConcurrentDictionary<string, ComplexChildFai>();
			foreach (KeyValuePair<Guid, ComplexChildFai> faiConfig in _faiConfig.ChildFaiConfigs)
			{
				oldFaiConfigs.TryAdd(faiConfig.Value.Name, faiConfig.Value);
			}
			_faiConfig.ChildFaiConfigs.Clear();
			_faiConfig.Ki = (double.TryParse(tbKi.Text, out var dk) ? dk : 0.0);
			for (int i = 0; i < dgvFaisConfig.Rows.Count; i++)
			{
				DataGridViewRow row = dgvFaisConfig.Rows[i];
				ComplexChildFai newChildFaiConfig = new ComplexChildFai();
				if (row.Cells[0].Value != null)
				{
					newChildFaiConfig.Name = row.Cells[0].Value.ToString();
				}
				if (row.Cells[1].Value != null)
				{
					newChildFaiConfig.Alias = row.Cells[1].Value.ToString();
				}
				newChildFaiConfig.Enable = bool.TryParse(row.Cells[2].Value.ToString(), out var bool1) && bool1;
				newChildFaiConfig.IsOutput = bool.TryParse(row.Cells[3].Value.ToString(), out var bool2) && bool2;
				newChildFaiConfig.IsDishist = bool.TryParse(row.Cells[4].Value.ToString(), out var bool3) && bool3;
				newChildFaiConfig.IsNonnegativeTo0 = bool.TryParse(row.Cells[5].Value.ToString(), out var bool4) && bool4;
				newChildFaiConfig.IsNonnegativeToPositive = bool.TryParse(row.Cells[6].Value.ToString(), out var bool5) && bool5;
				newChildFaiConfig.Normal = (double.TryParse(row.Cells[7].Value.ToString(), out var d1) ? d1 : 0.0);
				newChildFaiConfig.TolUp = (double.TryParse(row.Cells[8].Value.ToString(), out var d2) ? d2 : 999.999);
				newChildFaiConfig.TolLow = (double.TryParse(row.Cells[9].Value.ToString(), out var d3) ? d3 : (-999.999));
				newChildFaiConfig.TolUp2 = (double.TryParse(row.Cells[10].Value.ToString(), out var d4) ? d4 : 0.0);
				newChildFaiConfig.TolLow2 = (double.TryParse(row.Cells[11].Value.ToString(), out var d5) ? d5 : 0.0);
				newChildFaiConfig.Index = i;
				if (oldFaiConfigs.Keys.Contains(newChildFaiConfig.Name))
				{
					newChildFaiConfig.Offsets = oldFaiConfigs[newChildFaiConfig.Name].Offsets;
				}
				if (newChildFaiConfig.Offsets == null || newChildFaiConfig.Offsets.Count == 0)
				{
					newChildFaiConfig.Offsets = new List<Offset>();
					for (int j = 0; j < _faiConfig.CaveCount; j++)
					{
						newChildFaiConfig.Offsets.Add(new Offset(j));
					}
				}
				_faiConfig.ChildFaiConfigs.TryAdd(Guid.NewGuid(), newChildFaiConfig);
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

		private void ComplexChildFrm_Load(object sender, EventArgs e)
		{
			tbKi.Text = _faiConfig.Ki.ToString("f3");
			lbAglDesc.Text = Core.GetDescription(_faiConfig.AglSelect);
			AddConfigsToTable(_faiConfig);
			switch (_faiConfig.AglSelect)
			{
			case AglType.Profile:
				break;
			case AglType.None:
			case AglType.Parallelism:
			case AglType.Flatness:
			case AglType.Distance:
				lbKi.Visible = false;
				tbKi.Visible = false;
				break;
			}
		}

		private void dgvFaisConfig_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 12)
			{
				return;
			}
			string nameFai = dgvFaisConfig.Rows[e.RowIndex].Cells[0].Value.ToString();
			KeyValuePair<Guid, ComplexChildFai> fai = _faiConfig.ChildFaiConfigs.FirstOrDefault((KeyValuePair<Guid, ComplexChildFai> p) => p.Value.Name == nameFai);
			if (fai.Value != null)
			{
				if (fai.Value.Offsets == null)
				{
					fai.Value.Offsets = new List<Offset>();
				}
				FormOffset frm = new FormOffset(fai.Value.Offsets);
				frm.ShowDialog();
			}
		}








        #region System
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private TableLayoutPanel tableLayoutPanel1;

        private DataGridView dgvFaisConfig;

        private Panel panel1;

        private Button btnRowDown;

        private Button btnRowUp;

        private Button btnRemoveRow;

        private Button btnAddRow;

        private Button btnApply;

        private Label lbAglDesc;

        private TextBox tbKi;

        private Label lbKi;

        private Label label1;

        private DataGridViewTextBoxColumn colName;

        private DataGridViewTextBoxColumn colAlias;

        private DataGridViewCheckBoxColumn colEnable;

        private DataGridViewCheckBoxColumn colIsOutput;

        private DataGridViewCheckBoxColumn colIsDishist;

        private DataGridViewCheckBoxColumn colIsNonnegativeTo0;

        private DataGridViewCheckBoxColumn colIsNonnegativeToPositive;

        private DataGridViewTextBoxColumn colNormal;

        private DataGridViewTextBoxColumn colTolUp;

        private DataGridViewTextBoxColumn colTolLow;

        private DataGridViewTextBoxColumn colTolUp2;

        private DataGridViewTextBoxColumn colTolLow2;

        private DataGridViewButtonColumn colOffset;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            dgvFaisConfig = new System.Windows.Forms.DataGridView();
            panel1 = new System.Windows.Forms.Panel();
            lbAglDesc = new System.Windows.Forms.Label();
            tbKi = new System.Windows.Forms.TextBox();
            lbKi = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            btnRowDown = new System.Windows.Forms.Button();
            btnRowUp = new System.Windows.Forms.Button();
            btnRemoveRow = new System.Windows.Forms.Button();
            btnAddRow = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colIsOutput = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colIsDishist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colIsNonnegativeTo0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colIsNonnegativeToPositive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTolUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTolLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTolUp2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTolLow2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOffset = new System.Windows.Forms.DataGridViewButtonColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFaisConfig).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            tableLayoutPanel1.Controls.Add(dgvFaisConfig, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.51515f));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.48485f));
            tableLayoutPanel1.Size = new System.Drawing.Size(1098, 460);
            tableLayoutPanel1.TabIndex = 0;
            dgvFaisConfig.AllowUserToAddRows = false;
            dgvFaisConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFaisConfig.Columns.AddRange(colName, colAlias, colEnable, colIsOutput, colIsDishist, colIsNonnegativeTo0, colIsNonnegativeToPositive, colNormal, colTolUp, colTolLow, colTolUp2, colTolLow2, colOffset);
            dgvFaisConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvFaisConfig.Location = new System.Drawing.Point(3, 102);
            dgvFaisConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgvFaisConfig.Name = "dgvFaisConfig";
            dgvFaisConfig.RowTemplate.Height = 23;
            dgvFaisConfig.Size = new System.Drawing.Size(1092, 354);
            dgvFaisConfig.TabIndex = 4;
            dgvFaisConfig.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvFaisConfig_CellContentClick);
            panel1.Controls.Add(lbAglDesc);
            panel1.Controls.Add(tbKi);
            panel1.Controls.Add(lbKi);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnRowDown);
            panel1.Controls.Add(btnRowUp);
            panel1.Controls.Add(btnRemoveRow);
            panel1.Controls.Add(btnAddRow);
            panel1.Controls.Add(btnApply);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 4);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1092, 90);
            panel1.TabIndex = 0;
            lbAglDesc.AutoSize = true;
            lbAglDesc.Location = new System.Drawing.Point(93, 14);
            lbAglDesc.Name = "lbAglDesc";
            lbAglDesc.Size = new System.Drawing.Size(58, 17);
            lbAglDesc.TabIndex = 88;
            lbAglDesc.Text = "Max(1:n)";
            tbKi.Location = new System.Drawing.Point(93, 50);
            tbKi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbKi.Name = "tbKi";
            tbKi.Size = new System.Drawing.Size(116, 23);
            tbKi.TabIndex = 87;
            lbKi.AutoSize = true;
            lbKi.Location = new System.Drawing.Point(16, 54);
            lbKi.Name = "lbKi";
            lbKi.Size = new System.Drawing.Size(56, 17);
            lbKi.TabIndex = 86;
            lbKi.Text = "常量数值";
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 17);
            label1.TabIndex = 85;
            label1.Text = "计算公式";
            btnRowDown.BackColor = System.Drawing.Color.Gold;
            btnRowDown.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnRowDown.Location = new System.Drawing.Point(580, 40);
            btnRowDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRowDown.Name = "btnRowDown";
            btnRowDown.Size = new System.Drawing.Size(55, 41);
            btnRowDown.TabIndex = 84;
            btnRowDown.Text = "\ud83d\udc47";
            btnRowDown.UseVisualStyleBackColor = false;
            btnRowDown.Click += new System.EventHandler(btnRowDown_Click);
            btnRowUp.BackColor = System.Drawing.Color.Gold;
            btnRowUp.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnRowUp.Location = new System.Drawing.Point(502, 40);
            btnRowUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRowUp.Name = "btnRowUp";
            btnRowUp.Size = new System.Drawing.Size(55, 41);
            btnRowUp.TabIndex = 83;
            btnRowUp.Text = "\ud83d\udc46";
            btnRowUp.UseVisualStyleBackColor = false;
            btnRowUp.Click += new System.EventHandler(btnRowUp_Click);
            btnRemoveRow.BackColor = System.Drawing.Color.Red;
            btnRemoveRow.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnRemoveRow.Location = new System.Drawing.Point(423, 40);
            btnRemoveRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRemoveRow.Name = "btnRemoveRow";
            btnRemoveRow.Size = new System.Drawing.Size(55, 41);
            btnRemoveRow.TabIndex = 82;
            btnRemoveRow.Text = "-";
            btnRemoveRow.UseVisualStyleBackColor = false;
            btnRemoveRow.Click += new System.EventHandler(btnRemoveRow_Click);
            btnAddRow.BackColor = System.Drawing.Color.LimeGreen;
            btnAddRow.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnAddRow.Location = new System.Drawing.Point(345, 40);
            btnAddRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new System.Drawing.Size(55, 41);
            btnAddRow.TabIndex = 81;
            btnAddRow.Text = "+";
            btnAddRow.UseVisualStyleBackColor = false;
            btnAddRow.Click += new System.EventHandler(btnAddRow_Click);
            btnApply.BackColor = System.Drawing.Color.LimeGreen;
            btnApply.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnApply.Location = new System.Drawing.Point(658, 40);
            btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(115, 41);
            btnApply.TabIndex = 80;
            btnApply.Text = "应用";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += new System.EventHandler(btnApply_Click);
            colName.HeaderText = "名称";
            colName.Name = "colName";
            colAlias.HeaderText = "别名";
            colAlias.Name = "colAlias";
            colEnable.HeaderText = "开判";
            colEnable.Name = "colEnable";
            colEnable.Width = 40;
            colIsOutput.HeaderText = "输出";
            colIsOutput.Name = "colIsOutput";
            colIsOutput.Width = 40;
            colIsDishist.HeaderText = "直方图";
            colIsDishist.Name = "colIsDishist";
            colIsDishist.Width = 80;
            colIsNonnegativeTo0.HeaderText = "非正取零";
            colIsNonnegativeTo0.Name = "colIsNonnegativeTo0";
            colIsNonnegativeTo0.Width = 70;
            colIsNonnegativeToPositive.HeaderText = "非正取正";
            colIsNonnegativeToPositive.Name = "colIsNonnegativeToPositive";
            colIsNonnegativeToPositive.Width = 70;
            colNormal.HeaderText = "Norminal";
            colNormal.Name = "colNormal";
            colNormal.Width = 80;
            colTolUp.HeaderText = "Tol+";
            colTolUp.Name = "colTolUp";
            colTolUp.Width = 80;
            colTolLow.HeaderText = "Tol-";
            colTolLow.Name = "colTolLow";
            colTolLow.Width = 80;
            colTolUp2.HeaderText = "严收+";
            colTolUp2.Name = "colTolUp2";
            colTolLow2.HeaderText = "严收-";
            colTolLow2.Name = "colTolLow2";
            colOffset.HeaderText = "补偿值";
            colOffset.Name = "colOffset";
            colOffset.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            colOffset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            colOffset.Width = 70;
            base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            base.ClientSize = new System.Drawing.Size(1098, 460);
            base.Controls.Add(tableLayoutPanel1);
            Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            base.Name = "ComplexChildFrm";
            Text = "复杂FAI配置子项";
            base.Load += new System.EventHandler(ComplexChildFrm_Load);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFaisConfig).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        } 
        #endregion
    }
}
