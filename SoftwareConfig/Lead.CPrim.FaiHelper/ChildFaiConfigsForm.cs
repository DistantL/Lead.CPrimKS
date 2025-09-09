using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.FaiHelper
{
    public class ChildFaiConfigsForm : Form
    {
        private FaiConfig _faiConfig;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewCheckBoxColumn colEnable;
        private DataGridViewCheckBoxColumn colOutput;
        private DataGridViewCheckBoxColumn colUpload;
        private DataGridViewCheckBoxColumn colIsNonnegativeTo0;
        private DataGridViewCheckBoxColumn colIsNonnegativeToPositive;
        private DataGridViewTextBoxColumn colNormal;
        private DataGridViewTextBoxColumn colTolUp;
        private DataGridViewTextBoxColumn colTolLow;
        private DataGridViewTextBoxColumn colCompesationFactor;
        private DataGridViewTextBoxColumn colCompesation;
        private DataGridViewTextBoxColumn Unit;
        private bool _removing;



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ChildFaiConfigsForm()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="faiConfig">简单FAI数据表配置</param>
        public ChildFaiConfigsForm(FaiConfig faiConfig)
        {
            InitializeComponent();
            _faiConfig = faiConfig;
        }
        #endregion


        private void AddConfigsToTable(FaiConfig faiConfig)
        {
            Invoke(new Action(Action1));
            void Action1()
            {
                foreach (KeyValuePair<Guid, ChildFaiConfig> childFaiConfig in faiConfig.ChildFaiConfigs.OrderBy((KeyValuePair<Guid, ChildFaiConfig> p) => p.Value.Index))
                {
                    AddOneFaiConfigToRow(childFaiConfig.Value);
                }
            }
        }

        private void AddOneFaiConfigToRow(ChildFaiConfig childFaiConfig)
        {
            int index = dgvFaisConfig.Rows.Add();
            DataGridViewRow row = dgvFaisConfig.Rows[index];
            row.Cells[0].Value = childFaiConfig.Name;
            row.Cells[1].Value = childFaiConfig.Enable;
            row.Cells[2].Value = childFaiConfig.IsOutput;
            row.Cells[3].Value = childFaiConfig.IsUpload;
            row.Cells[4].Value = childFaiConfig.IsNonnegativeTo0;
            row.Cells[5].Value = childFaiConfig.IsNonnegativeToPositive;
            row.Cells[6].Value = childFaiConfig.Normal.ToString("F3");
            row.Cells[7].Value = childFaiConfig.TolUp.ToString("F3");
            row.Cells[8].Value = childFaiConfig.TolLow.ToString("F3");
            row.Cells[9].Value = childFaiConfig.CompensationFactor.ToString("F3");
            row.Cells[10].Value = childFaiConfig.Compensation.ToString("F3");
            row.Cells[11].Value = childFaiConfig.Unit;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            ChildFaiConfig newChildFai = new ChildFaiConfig();
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
            //    MessageBox.Show("有Fai名称重复，请检查标红项");
            //    return;
            //}
            if (_removing)
            {
                _removing = false;
                btnAddRow.Enabled = true;
                btnAddRow.BackColor = Color.LimeGreen;
            }
            _faiConfig.ChildFaiConfigs.Clear();
            for (int i = 0; i < dgvFaisConfig.Rows.Count; i++)
            {
                DataGridViewRow row = dgvFaisConfig.Rows[i];
                ChildFaiConfig newChildFaiConfig = new ChildFaiConfig();
                if (row.Cells[0].Value != null)
                {
                    newChildFaiConfig.Name = row.Cells[0].Value.ToString();
                }
                newChildFaiConfig.Enable = bool.TryParse(row.Cells[1].Value.ToString(), out var bool1) && bool1;
                newChildFaiConfig.IsOutput = bool.TryParse(row.Cells[2].Value.ToString(), out var bool2) && bool2;
                newChildFaiConfig.IsUpload = bool.TryParse(row.Cells[3].Value.ToString(), out var bool3) && bool3;
                newChildFaiConfig.IsNonnegativeTo0 = bool.TryParse(row.Cells[4].Value.ToString(), out var bool4) && bool4;
                newChildFaiConfig.IsNonnegativeToPositive = bool.TryParse(row.Cells[5].Value.ToString(), out var bool5) && bool5;
                newChildFaiConfig.Normal = (double.TryParse(row.Cells[6].Value.ToString(), out var d1) ? d1 : 0.0);
                newChildFaiConfig.TolUp = (double.TryParse(row.Cells[7].Value.ToString(), out var d2) ? d2 : 999.999);
                newChildFaiConfig.TolLow = (double.TryParse(row.Cells[8].Value.ToString(), out var d3) ? d3 : (-999.999));
                newChildFaiConfig.CompensationFactor = (double.TryParse(row.Cells[9].Value.ToString(), out var d4) ? d4 : 1.0);
                newChildFaiConfig.Compensation = (double.TryParse(row.Cells[10].Value.ToString(), out var d5) ? d5 : 0.0);
                newChildFaiConfig.Index = i;
                newChildFaiConfig.Unit = row.Cells[11].Value.ToString();
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

        private bool CheckConfigsNameRepeated()
        {
            foreach (KeyValuePair<Guid, ChildFaiConfig> childFaiConfig in _faiConfig.ChildFaiConfigs)
            {
                string name = childFaiConfig.Value.Name;
                int nameCount = 0;
                foreach (KeyValuePair<Guid, ChildFaiConfig> childFaiConfig2 in _faiConfig.ChildFaiConfigs)
                {
                    if (name == childFaiConfig2.Value.Name)
                    {
                        nameCount++;
                    }
                }
                if (nameCount > 1)
                {
                    return true;
                }
            }
            return false;
        }

        private void ChildFaiConfigsForm_Load(object sender, EventArgs e)
        {
            tbName.Text = _faiConfig.Name;
            AddConfigsToTable(_faiConfig);
        }

        private void btnLoadAgl_Click(object sender, EventArgs e)
        {
            LoadFaisFromAgl loadForm = new LoadFaisFromAgl(childFlag: true);
            loadForm.ShowDialog();
            if (loadForm.ChildFais.Count <= 0)
            {
                return;
            }
            foreach (ChildFaiConfig fai in loadForm.ChildFais)
            {
                AddOneFaiConfigToRow(fai);
            }
        }








        #region System
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private SplitContainer splitContainer1;

        private Button btnRemoveRow;

        private Button btnAddRow;

        private Button btnApply;

        private TextBox tbName;

        private Label lbName;

        private DataGridView dgvFaisConfig;

        private Button btnRowDown;

        private Button btnRowUp;

        private Button btnLoadAgl;

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLoadAgl = new System.Windows.Forms.Button();
            this.btnRowDown = new System.Windows.Forms.Button();
            this.btnRowUp = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.dgvFaisConfig = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colOutput = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUpload = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsNonnegativeTo0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsNonnegativeToPositive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTolUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTolLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompesationFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompesation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaisConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadAgl);
            this.splitContainer1.Panel1.Controls.Add(this.btnRowDown);
            this.splitContainer1.Panel1.Controls.Add(this.btnRowUp);
            this.splitContainer1.Panel1.Controls.Add(this.tbName);
            this.splitContainer1.Panel1.Controls.Add(this.lbName);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemoveRow);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddRow);
            this.splitContainer1.Panel1.Controls.Add(this.btnApply);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvFaisConfig);
            this.splitContainer1.Size = new System.Drawing.Size(968, 328);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnLoadAgl
            // 
            this.btnLoadAgl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLoadAgl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadAgl.Location = new System.Drawing.Point(344, 6);
            this.btnLoadAgl.Name = "btnLoadAgl";
            this.btnLoadAgl.Size = new System.Drawing.Size(99, 29);
            this.btnLoadAgl.TabIndex = 79;
            this.btnLoadAgl.Text = "算法导入";
            this.btnLoadAgl.UseVisualStyleBackColor = false;
            this.btnLoadAgl.Click += new System.EventHandler(this.btnLoadAgl_Click);
            // 
            // btnRowDown
            // 
            this.btnRowDown.BackColor = System.Drawing.Color.Gold;
            this.btnRowDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRowDown.Location = new System.Drawing.Point(672, 6);
            this.btnRowDown.Name = "btnRowDown";
            this.btnRowDown.Size = new System.Drawing.Size(47, 29);
            this.btnRowDown.TabIndex = 74;
            this.btnRowDown.Text = "👇";
            this.btnRowDown.UseVisualStyleBackColor = false;
            this.btnRowDown.Click += new System.EventHandler(this.btnRowDown_Click);
            // 
            // btnRowUp
            // 
            this.btnRowUp.BackColor = System.Drawing.Color.Gold;
            this.btnRowUp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRowUp.Location = new System.Drawing.Point(605, 6);
            this.btnRowUp.Name = "btnRowUp";
            this.btnRowUp.Size = new System.Drawing.Size(47, 29);
            this.btnRowUp.TabIndex = 73;
            this.btnRowUp.Text = "👆";
            this.btnRowUp.UseVisualStyleBackColor = false;
            this.btnRowUp.Click += new System.EventHandler(this.btnRowUp_Click);
            // 
            // tbName
            // 
            this.tbName.Enabled = false;
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbName.Location = new System.Drawing.Point(116, 9);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(77, 21);
            this.tbName.TabIndex = 72;
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(12, 9);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(98, 20);
            this.lbName.TabIndex = 71;
            this.lbName.Text = "集合名称：";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.BackColor = System.Drawing.Color.Red;
            this.btnRemoveRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveRow.Location = new System.Drawing.Point(538, 6);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(47, 29);
            this.btnRemoveRow.TabIndex = 70;
            this.btnRemoveRow.Text = "-";
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Location = new System.Drawing.Point(471, 6);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(47, 29);
            this.btnAddRow.TabIndex = 69;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(739, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(99, 29);
            this.btnApply.TabIndex = 68;
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
            this.colEnable,
            this.colOutput,
            this.colUpload,
            this.colIsNonnegativeTo0,
            this.colIsNonnegativeToPositive,
            this.colNormal,
            this.colTolUp,
            this.colTolLow,
            this.colCompesationFactor,
            this.colCompesation,
            this.Unit});
            this.dgvFaisConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFaisConfig.Location = new System.Drawing.Point(0, 0);
            this.dgvFaisConfig.Name = "dgvFaisConfig";
            this.dgvFaisConfig.RowTemplate.Height = 23;
            this.dgvFaisConfig.Size = new System.Drawing.Size(968, 288);
            this.dgvFaisConfig.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            // 
            // colEnable
            // 
            this.colEnable.HeaderText = "开判";
            this.colEnable.Name = "colEnable";
            this.colEnable.Width = 70;
            // 
            // colOutput
            // 
            this.colOutput.HeaderText = "输出";
            this.colOutput.Name = "colOutput";
            this.colOutput.Width = 70;
            // 
            // colUpload
            // 
            this.colUpload.HeaderText = "上传";
            this.colUpload.Name = "colUpload";
            this.colUpload.Width = 70;
            // 
            // colIsNonnegativeTo0
            // 
            this.colIsNonnegativeTo0.HeaderText = "非正取零";
            this.colIsNonnegativeTo0.Name = "colIsNonnegativeTo0";
            this.colIsNonnegativeTo0.Width = 70;
            // 
            // colIsNonnegativeToPositive
            // 
            this.colIsNonnegativeToPositive.HeaderText = "非正取正";
            this.colIsNonnegativeToPositive.Name = "colIsNonnegativeToPositive";
            this.colIsNonnegativeToPositive.Width = 70;
            // 
            // colNormal
            // 
            this.colNormal.HeaderText = "Norminal";
            this.colNormal.Name = "colNormal";
            this.colNormal.Width = 80;
            // 
            // colTolUp
            // 
            this.colTolUp.HeaderText = "Tol+";
            this.colTolUp.Name = "colTolUp";
            this.colTolUp.Width = 80;
            // 
            // colTolLow
            // 
            this.colTolLow.HeaderText = "Tol-";
            this.colTolLow.Name = "colTolLow";
            this.colTolLow.Width = 80;
            // 
            // colCompesationFactor
            // 
            this.colCompesationFactor.HeaderText = "补偿系数";
            this.colCompesationFactor.Name = "colCompesationFactor";
            this.colCompesationFactor.Width = 90;
            // 
            // colCompesation
            // 
            this.colCompesation.HeaderText = "补偿值";
            this.colCompesation.Name = "colCompesation";
            this.colCompesation.Width = 90;
            // 
            // Unit
            // 
            this.Unit.FillWeight = 40F;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.Width = 40;
            // 
            // ChildFaiConfigsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 328);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChildFaiConfigsForm";
            this.Text = "子项配置";
            this.Load += new System.EventHandler(this.ChildFaiConfigsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaisConfig)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
