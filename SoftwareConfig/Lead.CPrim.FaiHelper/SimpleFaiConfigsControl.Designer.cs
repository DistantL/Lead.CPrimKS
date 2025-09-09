using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper
{
    partial class SimpleFaiConfigsControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadAgl = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRowDown = new System.Windows.Forms.Button();
            this.btnRowUp = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
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
            this.colEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsOutput = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsUpload = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsParent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsVirtual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsNonnegativeTo0 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsNonnegativeToPositive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTolUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTolLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompensationFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompensation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParent = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaisConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Controls.Add(this.dgvFaisConfig, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1226, 545);
            this.tlpMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadAgl);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnRowDown);
            this.panel1.Controls.Add(this.btnRowUp);
            this.panel1.Controls.Add(this.btnImport);
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
            this.panel1.Size = new System.Drawing.Size(1220, 54);
            this.panel1.TabIndex = 2;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // btnLoadAgl
            // 
            this.btnLoadAgl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLoadAgl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadAgl.Location = new System.Drawing.Point(681, 12);
            this.btnLoadAgl.Name = "btnLoadAgl";
            this.btnLoadAgl.Size = new System.Drawing.Size(99, 29);
            this.btnLoadAgl.TabIndex = 78;
            this.btnLoadAgl.Text = "算法导入";
            this.btnLoadAgl.UseVisualStyleBackColor = false;
            this.btnLoadAgl.Click += new System.EventHandler(this.btnLoadAgl_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnExport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(483, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 29);
            this.btnExport.TabIndex = 77;
            this.btnExport.Text = "CSV导出";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRowDown
            // 
            this.btnRowDown.BackColor = System.Drawing.Color.Gold;
            this.btnRowDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRowDown.Location = new System.Drawing.Point(1020, 12);
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
            this.btnRowUp.Location = new System.Drawing.Point(948, 12);
            this.btnRowUp.Name = "btnRowUp";
            this.btnRowUp.Size = new System.Drawing.Size(47, 29);
            this.btnRowUp.TabIndex = 75;
            this.btnRowUp.Text = "👆";
            this.btnRowUp.UseVisualStyleBackColor = false;
            this.btnRowUp.Click += new System.EventHandler(this.btnRowUp_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnImport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.Location = new System.Drawing.Point(582, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(99, 29);
            this.btnImport.TabIndex = 73;
            this.btnImport.Text = "CSV导入";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // chkIsUpload
            // 
            this.chkIsUpload.AutoSize = true;
            this.chkIsUpload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsUpload.Location = new System.Drawing.Point(327, 16);
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
            this.chkIsOutput.Location = new System.Drawing.Point(251, 16);
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
            this.chkEnable.Location = new System.Drawing.Point(175, 16);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(51, 21);
            this.chkEnable.TabIndex = 70;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbName.Location = new System.Drawing.Point(77, 16);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(77, 21);
            this.tbName.TabIndex = 69;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(18, 16);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(54, 20);
            this.lbName.TabIndex = 68;
            this.lbName.Text = "名称：";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.BackColor = System.Drawing.Color.Red;
            this.btnRemoveRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveRow.Location = new System.Drawing.Point(876, 12);
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
            this.btnAddRow.Location = new System.Drawing.Point(804, 12);
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
            this.btnApply.Location = new System.Drawing.Point(384, 12);
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
            this.colEnable,
            this.colIsOutput,
            this.colIsUpload,
            this.colIsParent,
            this.colIsVirtual,
            this.colIsNonnegativeTo0,
            this.colIsNonnegativeToPositive,
            this.colNormal,
            this.colTolUp,
            this.colTolLow,
            this.colCompensationFactor,
            this.colCompensation,
            this.colParent,
            this.Unit});
            this.dgvFaisConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFaisConfig.Location = new System.Drawing.Point(3, 63);
            this.dgvFaisConfig.Name = "dgvFaisConfig";
            this.dgvFaisConfig.RowHeadersWidth = 51;
            this.dgvFaisConfig.RowTemplate.Height = 23;
            this.dgvFaisConfig.Size = new System.Drawing.Size(1220, 479);
            this.dgvFaisConfig.TabIndex = 3;
            this.dgvFaisConfig.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaisConfig_CellContentClick);
            this.dgvFaisConfig.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvFaisConfig_CurrentCellDirtyStateChanged);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 125;
            // 
            // colEnable
            // 
            this.colEnable.DataPropertyName = "Enable";
            this.colEnable.HeaderText = "开判";
            this.colEnable.MinimumWidth = 6;
            this.colEnable.Name = "colEnable";
            this.colEnable.Width = 40;
            // 
            // colIsOutput
            // 
            this.colIsOutput.DataPropertyName = "IsOutput";
            this.colIsOutput.HeaderText = "输出";
            this.colIsOutput.MinimumWidth = 6;
            this.colIsOutput.Name = "colIsOutput";
            this.colIsOutput.Width = 40;
            // 
            // colIsUpload
            // 
            this.colIsUpload.DataPropertyName = "IsUpload";
            this.colIsUpload.HeaderText = "上传";
            this.colIsUpload.MinimumWidth = 6;
            this.colIsUpload.Name = "colIsUpload";
            this.colIsUpload.Width = 40;
            // 
            // colIsParent
            // 
            this.colIsParent.DataPropertyName = "IsParent";
            this.colIsParent.HeaderText = "集合";
            this.colIsParent.MinimumWidth = 6;
            this.colIsParent.Name = "colIsParent";
            this.colIsParent.Width = 40;
            // 
            // colIsVirtual
            // 
            this.colIsVirtual.DataPropertyName = "IsVirtual";
            this.colIsVirtual.HeaderText = "虚拟";
            this.colIsVirtual.MinimumWidth = 6;
            this.colIsVirtual.Name = "colIsVirtual";
            this.colIsVirtual.Width = 40;
            // 
            // colIsNonnegativeTo0
            // 
            this.colIsNonnegativeTo0.DataPropertyName = "IsNonnegativeTo0";
            this.colIsNonnegativeTo0.HeaderText = "非正取零";
            this.colIsNonnegativeTo0.MinimumWidth = 6;
            this.colIsNonnegativeTo0.Name = "colIsNonnegativeTo0";
            this.colIsNonnegativeTo0.Width = 70;
            // 
            // colIsNonnegativeToPositive
            // 
            this.colIsNonnegativeToPositive.DataPropertyName = "IsNonnegativeToPositive";
            this.colIsNonnegativeToPositive.HeaderText = "非正取正";
            this.colIsNonnegativeToPositive.MinimumWidth = 6;
            this.colIsNonnegativeToPositive.Name = "colIsNonnegativeToPositive";
            this.colIsNonnegativeToPositive.Width = 70;
            // 
            // colNormal
            // 
            this.colNormal.DataPropertyName = "Normal";
            this.colNormal.HeaderText = "Norminal";
            this.colNormal.MinimumWidth = 6;
            this.colNormal.Name = "colNormal";
            this.colNormal.Width = 80;
            // 
            // colTolUp
            // 
            this.colTolUp.DataPropertyName = "TolUp";
            this.colTolUp.HeaderText = "Tol+";
            this.colTolUp.MinimumWidth = 6;
            this.colTolUp.Name = "colTolUp";
            this.colTolUp.Width = 80;
            // 
            // colTolLow
            // 
            this.colTolLow.DataPropertyName = "TolLow";
            this.colTolLow.HeaderText = "Tol-";
            this.colTolLow.MinimumWidth = 6;
            this.colTolLow.Name = "colTolLow";
            this.colTolLow.Width = 80;
            // 
            // colCompensationFactor
            // 
            this.colCompensationFactor.DataPropertyName = "CompensationFactor";
            this.colCompensationFactor.HeaderText = "补偿系数";
            this.colCompensationFactor.MinimumWidth = 6;
            this.colCompensationFactor.Name = "colCompensationFactor";
            this.colCompensationFactor.Width = 80;
            // 
            // colCompensation
            // 
            this.colCompensation.DataPropertyName = "Compensation";
            this.colCompensation.HeaderText = "补偿值";
            this.colCompensation.MinimumWidth = 6;
            this.colCompensation.Name = "colCompensation";
            this.colCompensation.Width = 80;
            // 
            // colParent
            // 
            this.colParent.DataPropertyName = "IsParent";
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
            // SimpleFaiConfigsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SimpleFaiConfigsControl";
            this.Size = new System.Drawing.Size(1226, 545);
            this.Load += new System.EventHandler(this.SimpleFaiConfigsControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaisConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpMain;
        private Panel panel1;
        private Button btnRemoveRow;
        private Button btnAddRow;
        private Button btnApply;
        private TextBox tbName;
        private Label lbName;
        private CheckBox chkIsUpload;
        private CheckBox chkIsOutput;
        private CheckBox chkEnable;
        private Button btnImport;
        private DataGridView dgvFaisConfig;
        private Button btnRowDown;
        private Button btnRowUp;
        private Button btnExport;
        private Button btnLoadAgl;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewCheckBoxColumn colEnable;
        private DataGridViewCheckBoxColumn colIsOutput;
        private DataGridViewCheckBoxColumn colIsUpload;
        private DataGridViewCheckBoxColumn colIsParent;
        private DataGridViewCheckBoxColumn colIsVirtual;
        private DataGridViewCheckBoxColumn colIsNonnegativeTo0;
        private DataGridViewCheckBoxColumn colIsNonnegativeToPositive;
        private DataGridViewTextBoxColumn colNormal;
        private DataGridViewTextBoxColumn colTolUp;
        private DataGridViewTextBoxColumn colTolLow;
        private DataGridViewTextBoxColumn colCompensationFactor;
        private DataGridViewTextBoxColumn colCompensation;
        private DataGridViewButtonColumn colParent;
        private DataGridViewTextBoxColumn Unit;
    }
}
