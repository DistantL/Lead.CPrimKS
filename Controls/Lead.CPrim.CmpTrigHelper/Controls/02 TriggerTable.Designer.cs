using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
    partial class TriggerTable
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.txtDelayTime = new System.Windows.Forms.TextBox();
            this.lblDelayTime = new System.Windows.Forms.Label();
            this.txtDelayVelocity = new System.Windows.Forms.TextBox();
            this.lblDelayVelocity = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtAgl = new System.Windows.Forms.TextBox();
            this.lblAgl = new System.Windows.Forms.Label();
            this.btnClr = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dgvPos = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpMain.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.AutoScroll = true;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlTitle, 0, 0);
            this.tlpMain.Controls.Add(this.dgvPos, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(340, 500);
            this.tlpMain.TabIndex = 1;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.txtDelayTime);
            this.pnlTitle.Controls.Add(this.lblDelayTime);
            this.pnlTitle.Controls.Add(this.txtDelayVelocity);
            this.pnlTitle.Controls.Add(this.lblDelayVelocity);
            this.pnlTitle.Controls.Add(this.cmbProduct);
            this.pnlTitle.Controls.Add(this.lblProduct);
            this.pnlTitle.Controls.Add(this.btnCreate);
            this.pnlTitle.Controls.Add(this.txtAgl);
            this.pnlTitle.Controls.Add(this.lblAgl);
            this.pnlTitle.Controls.Add(this.btnClr);
            this.pnlTitle.Controls.Add(this.txtNum);
            this.pnlTitle.Controls.Add(this.lblNum);
            this.pnlTitle.Controls.Add(this.txtInterval);
            this.pnlTitle.Controls.Add(this.lblInterval);
            this.pnlTitle.Controls.Add(this.txtEnd);
            this.pnlTitle.Controls.Add(this.lblEnd);
            this.pnlTitle.Controls.Add(this.txtStart);
            this.pnlTitle.Controls.Add(this.lblStart);
            this.pnlTitle.Controls.Add(this.btnRemoveRow);
            this.pnlTitle.Controls.Add(this.btnAddRow);
            this.pnlTitle.Controls.Add(this.btnApply);
            this.pnlTitle.Controls.Add(this.txtId);
            this.pnlTitle.Controls.Add(this.lblId);
            this.pnlTitle.Controls.Add(this.txtName);
            this.pnlTitle.Controls.Add(this.lblName);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(340, 195);
            this.pnlTitle.TabIndex = 3;
            // 
            // txtDelayTime
            // 
            this.txtDelayTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDelayTime.Location = new System.Drawing.Point(65, 92);
            this.txtDelayTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDelayTime.Name = "txtDelayTime";
            this.txtDelayTime.Size = new System.Drawing.Size(100, 23);
            this.txtDelayTime.TabIndex = 102;
            // 
            // lblDelayTime
            // 
            this.lblDelayTime.AutoSize = true;
            this.lblDelayTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDelayTime.Location = new System.Drawing.Point(5, 95);
            this.lblDelayTime.Name = "lblDelayTime";
            this.lblDelayTime.Size = new System.Drawing.Size(68, 17);
            this.lblDelayTime.TabIndex = 101;
            this.lblDelayTime.Text = "延迟时间：";
            // 
            // txtDelayVelocity
            // 
            this.txtDelayVelocity.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDelayVelocity.Location = new System.Drawing.Point(230, 92);
            this.txtDelayVelocity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDelayVelocity.Name = "txtDelayVelocity";
            this.txtDelayVelocity.Size = new System.Drawing.Size(100, 23);
            this.txtDelayVelocity.TabIndex = 100;
            // 
            // lblDelayVelocity
            // 
            this.lblDelayVelocity.AutoSize = true;
            this.lblDelayVelocity.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDelayVelocity.Location = new System.Drawing.Point(170, 95);
            this.lblDelayVelocity.Name = "lblDelayVelocity";
            this.lblDelayVelocity.Size = new System.Drawing.Size(68, 17);
            this.lblDelayVelocity.TabIndex = 99;
            this.lblDelayVelocity.Text = "延迟速度：";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Items.AddRange(new object[] {
            "-1",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbProduct.Location = new System.Drawing.Point(230, 123);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(100, 25);
            this.cmbProduct.TabIndex = 98;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProduct.Location = new System.Drawing.Point(170, 127);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 17);
            this.lblProduct.TabIndex = 97;
            this.lblProduct.Text = "产品：";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.LightYellow;
            this.btnCreate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreate.Location = new System.Drawing.Point(164, 155);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(80, 35);
            this.btnCreate.TabIndex = 94;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreat_Click);
            // 
            // txtAgl
            // 
            this.txtAgl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAgl.Location = new System.Drawing.Point(65, 124);
            this.txtAgl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAgl.Name = "txtAgl";
            this.txtAgl.Size = new System.Drawing.Size(100, 23);
            this.txtAgl.TabIndex = 93;
            // 
            // lblAgl
            // 
            this.lblAgl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAgl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAgl.Location = new System.Drawing.Point(5, 125);
            this.lblAgl.Name = "lblAgl";
            this.lblAgl.Size = new System.Drawing.Size(50, 20);
            this.lblAgl.TabIndex = 92;
            this.lblAgl.Text = "算法";
            this.lblAgl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgl.DoubleClick += new System.EventHandler(this.labAglSel_DoubleClick);
            // 
            // btnClr
            // 
            this.btnClr.BackColor = System.Drawing.Color.Tomato;
            this.btnClr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClr.Location = new System.Drawing.Point(81, 155);
            this.btnClr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(80, 35);
            this.btnClr.TabIndex = 91;
            this.btnClr.Text = "清空";
            this.btnClr.UseVisualStyleBackColor = false;
            this.btnClr.Click += new System.EventHandler(this.BtnClr_Click);
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNum.Location = new System.Drawing.Point(65, 32);
            this.txtNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            this.txtNum.Size = new System.Drawing.Size(100, 23);
            this.txtNum.TabIndex = 90;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNum.Location = new System.Drawing.Point(5, 35);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(44, 17);
            this.lblNum.TabIndex = 89;
            this.lblNum.Text = "数量：";
            // 
            // txtInterval
            // 
            this.txtInterval.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInterval.Location = new System.Drawing.Point(65, 62);
            this.txtInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 23);
            this.txtInterval.TabIndex = 87;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInterval.Location = new System.Drawing.Point(5, 65);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(44, 17);
            this.lblInterval.TabIndex = 86;
            this.lblInterval.Text = "间隔：";
            // 
            // txtEnd
            // 
            this.txtEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEnd.Location = new System.Drawing.Point(230, 62);
            this.txtEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(100, 23);
            this.txtEnd.TabIndex = 85;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEnd.Location = new System.Drawing.Point(170, 65);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(44, 17);
            this.lblEnd.TabIndex = 84;
            this.lblEnd.Text = "终点：";
            // 
            // txtStart
            // 
            this.txtStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStart.Location = new System.Drawing.Point(230, 32);
            this.txtStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 23);
            this.txtStart.TabIndex = 83;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStart.Location = new System.Drawing.Point(170, 35);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(44, 17);
            this.lblStart.TabIndex = 82;
            this.lblStart.Text = "起点：";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.BackColor = System.Drawing.Color.Red;
            this.btnRemoveRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveRow.Location = new System.Drawing.Point(43, 155);
            this.btnRemoveRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(35, 35);
            this.btnRemoveRow.TabIndex = 81;
            this.btnRemoveRow.Text = "-";
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.Lime;
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Location = new System.Drawing.Point(5, 155);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(35, 35);
            this.btnAddRow.TabIndex = 80;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(247, 155);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 35);
            this.btnApply.TabIndex = 79;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtId.Location = new System.Drawing.Point(230, 2);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 78;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTrigTrigId_KeyPress);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblId.Location = new System.Drawing.Point(170, 5);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(33, 17);
            this.lblId.TabIndex = 77;
            this.lblId.Text = "ID：";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(65, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 23);
            this.txtName.TabIndex = 76;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(5, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 17);
            this.lblName.TabIndex = 75;
            this.lblName.Text = "名称：";
            this.lblName.DoubleClick += new System.EventHandler(this.lblName_DoubleClick);
            // 
            // dgvPos
            // 
            this.dgvPos.AllowUserToAddRows = false;
            this.dgvPos.AllowUserToDeleteRows = false;
            this.dgvPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colValue});
            this.dgvPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPos.Location = new System.Drawing.Point(3, 198);
            this.dgvPos.Name = "dgvPos";
            this.dgvPos.RowTemplate.Height = 23;
            this.dgvPos.Size = new System.Drawing.Size(334, 299);
            this.dgvPos.TabIndex = 4;
            // 
            // colIndex
            // 
            this.colIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colIndex.HeaderText = "序号";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValue.HeaderText = "点位";
            this.colValue.Name = "colValue";
            // 
            // TriggerTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TriggerTable";
            this.Size = new System.Drawing.Size(340, 500);
            this.Load += new System.EventHandler(this.TrigTableControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpMain;
        private Panel pnlTitle;
        private Button btnClr;
        private TextBox txtNum;
        private Label lblNum;
        private TextBox txtInterval;
        private Label lblInterval;
        private TextBox txtEnd;
        private Label lblEnd;
        private TextBox txtStart;
        private Label lblStart;
        private Button btnRemoveRow;
        private Button btnAddRow;
        private Button btnApply;
        private TextBox txtId;
        private Label lblId;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtAgl;
        private Label lblAgl;
        private Button btnCreate;
        private Label lblProduct;
        private ComboBox cmbProduct;
        private TextBox txtDelayTime;
        private Label lblDelayTime;
        private TextBox txtDelayVelocity;
        private Label lblDelayVelocity;
        private DataGridView dgvPos;
        private DataGridViewTextBoxColumn colIndex;
        private DataGridViewTextBoxColumn colValue;
    }
}
