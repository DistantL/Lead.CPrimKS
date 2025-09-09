using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
    partial class TriggerTrack
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
            this.dgvTrack = new System.Windows.Forms.DataGridView();
            this.colPosType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colVelX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVelY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVelZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVelU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVelV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVelW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnTeach = new System.Windows.Forms.Button();
            this.cmbAxisName = new System.Windows.Forms.ComboBox();
            this.lblAxisName = new System.Windows.Forms.Label();
            this.cmbElementName = new System.Windows.Forms.ComboBox();
            this.lblElement = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtTrackName = new System.Windows.Forms.TextBox();
            this.lblTrigName = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrack)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.dgvTrack, 0, 1);
            this.tlpMain.Controls.Add(this.pnlTitle, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(950, 185);
            this.tlpMain.TabIndex = 0;
            // 
            // dgvTrack
            // 
            this.dgvTrack.AllowUserToAddRows = false;
            this.dgvTrack.AllowUserToDeleteRows = false;
            this.dgvTrack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPosType,
            this.colPosX,
            this.colPosY,
            this.colPosZ,
            this.colPosU,
            this.colPosV,
            this.colPosW,
            this.colTest,
            this.colVelX,
            this.colVelY,
            this.colVelZ,
            this.colVelU,
            this.colVelV,
            this.colVelW});
            this.dgvTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrack.Location = new System.Drawing.Point(3, 40);
            this.dgvTrack.Name = "dgvTrack";
            this.dgvTrack.RowTemplate.Height = 23;
            this.dgvTrack.Size = new System.Drawing.Size(944, 142);
            this.dgvTrack.TabIndex = 2;
            this.dgvTrack.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTraj_CellContentClick);
            // 
            // colPosType
            // 
            this.colPosType.Frozen = true;
            this.colPosType.HeaderText = "点位类型";
            this.colPosType.Name = "colPosType";
            this.colPosType.ReadOnly = true;
            this.colPosType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPosX
            // 
            this.colPosX.HeaderText = "Pos_X";
            this.colPosX.Name = "colPosX";
            this.colPosX.Width = 80;
            // 
            // colPosY
            // 
            this.colPosY.HeaderText = "Pos_Y";
            this.colPosY.Name = "colPosY";
            this.colPosY.Width = 80;
            // 
            // colPosZ
            // 
            this.colPosZ.HeaderText = "Pos_Z";
            this.colPosZ.Name = "colPosZ";
            this.colPosZ.Width = 80;
            // 
            // colPosU
            // 
            this.colPosU.HeaderText = "Pos_U";
            this.colPosU.Name = "colPosU";
            this.colPosU.Width = 80;
            // 
            // colPosV
            // 
            this.colPosV.HeaderText = "Pos_V";
            this.colPosV.Name = "colPosV";
            this.colPosV.Width = 80;
            // 
            // colPosW
            // 
            this.colPosW.HeaderText = "Pos_W";
            this.colPosW.Name = "colPosW";
            this.colPosW.Width = 80;
            // 
            // colTest
            // 
            this.colTest.HeaderText = "测试移动";
            this.colTest.Name = "colTest";
            this.colTest.Text = "移动";
            // 
            // colVelX
            // 
            this.colVelX.HeaderText = "Vel_X";
            this.colVelX.Name = "colVelX";
            // 
            // colVelY
            // 
            this.colVelY.HeaderText = "Vel_Y";
            this.colVelY.Name = "colVelY";
            // 
            // colVelZ
            // 
            this.colVelZ.HeaderText = "Vel_Z";
            this.colVelZ.Name = "colVelZ";
            // 
            // colVelU
            // 
            this.colVelU.HeaderText = "Vel_U";
            this.colVelU.Name = "colVelU";
            // 
            // colVelV
            // 
            this.colVelV.HeaderText = "Vel_V";
            this.colVelV.Name = "colVelV";
            // 
            // colVelW
            // 
            this.colVelW.HeaderText = "Vel_W";
            this.colVelW.Name = "colVelW";
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.btnApply);
            this.pnlTitle.Controls.Add(this.btnTeach);
            this.pnlTitle.Controls.Add(this.cmbAxisName);
            this.pnlTitle.Controls.Add(this.lblAxisName);
            this.pnlTitle.Controls.Add(this.cmbElementName);
            this.pnlTitle.Controls.Add(this.lblElement);
            this.pnlTitle.Controls.Add(this.txtId);
            this.pnlTitle.Controls.Add(this.lblId);
            this.pnlTitle.Controls.Add(this.txtTrackName);
            this.pnlTitle.Controls.Add(this.lblTrigName);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(950, 37);
            this.pnlTitle.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(840, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 29);
            this.btnApply.TabIndex = 72;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnTeach
            // 
            this.btnTeach.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTeach.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTeach.Location = new System.Drawing.Point(730, 4);
            this.btnTeach.Name = "btnTeach";
            this.btnTeach.Size = new System.Drawing.Size(100, 29);
            this.btnTeach.TabIndex = 71;
            this.btnTeach.Text = "示教";
            this.btnTeach.UseVisualStyleBackColor = false;
            this.btnTeach.Click += new System.EventHandler(this.btnTeach_Click);
            // 
            // cmbAxisName
            // 
            this.cmbAxisName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxisName.DropDownWidth = 77;
            this.cmbAxisName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbAxisName.FormattingEnabled = true;
            this.cmbAxisName.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmbAxisName.Location = new System.Drawing.Point(587, 6);
            this.cmbAxisName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAxisName.Name = "cmbAxisName";
            this.cmbAxisName.Size = new System.Drawing.Size(100, 25);
            this.cmbAxisName.TabIndex = 70;
            this.cmbAxisName.Click += new System.EventHandler(this.cmbAxisName_SelectedIndexChanged);
            // 
            // lblAxisName
            // 
            this.lblAxisName.AutoSize = true;
            this.lblAxisName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAxisName.Location = new System.Drawing.Point(526, 10);
            this.lblAxisName.Name = "lblAxisName";
            this.lblAxisName.Size = new System.Drawing.Size(56, 17);
            this.lblAxisName.TabIndex = 69;
            this.lblAxisName.Text = "轴名称：";
            this.lblAxisName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbElementName
            // 
            this.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElementName.DropDownWidth = 96;
            this.cmbElementName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbElementName.FormattingEnabled = true;
            this.cmbElementName.Items.AddRange(new object[] {
            "Robot",
            "MotionCard"});
            this.cmbElementName.Location = new System.Drawing.Point(421, 6);
            this.cmbElementName.Name = "cmbElementName";
            this.cmbElementName.Size = new System.Drawing.Size(100, 25);
            this.cmbElementName.TabIndex = 68;
            this.cmbElementName.SelectedIndexChanged += new System.EventHandler(this.cmbElementName_SelectedIndexChanged);
            // 
            // lblElement
            // 
            this.lblElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblElement.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblElement.Location = new System.Drawing.Point(326, 6);
            this.lblElement.Name = "lblElement";
            this.lblElement.Size = new System.Drawing.Size(90, 25);
            this.lblElement.TabIndex = 67;
            this.lblElement.Text = "元件关联：";
            this.lblElement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblElement.Click += new System.EventHandler(this.lbElement_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtId.Location = new System.Drawing.Point(221, 7);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 66;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTrajId_KeyPress);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblId.Location = new System.Drawing.Point(183, 10);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(33, 17);
            this.lblId.TabIndex = 65;
            this.lblId.Text = "ID：";
            // 
            // txtTrackName
            // 
            this.txtTrackName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTrackName.Location = new System.Drawing.Point(78, 7);
            this.txtTrackName.Name = "txtTrackName";
            this.txtTrackName.Size = new System.Drawing.Size(100, 23);
            this.txtTrackName.TabIndex = 64;
            // 
            // lblTrigName
            // 
            this.lblTrigName.AutoSize = true;
            this.lblTrigName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTrigName.Location = new System.Drawing.Point(5, 10);
            this.lblTrigName.Name = "lblTrigName";
            this.lblTrigName.Size = new System.Drawing.Size(68, 17);
            this.lblTrigName.TabIndex = 63;
            this.lblTrigName.Text = "轨迹名称：";
            this.lblTrigName.DoubleClick += new System.EventHandler(this.lblTrigName_DoubleClick);
            // 
            // TriggerTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TriggerTrack";
            this.Size = new System.Drawing.Size(950, 185);
            this.Load += new System.EventHandler(this.TrajConfigControl_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrack)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlpMain;
        private DataGridView dgvTrack;
        private DataGridViewTextBoxColumn colPosType;
        private DataGridViewTextBoxColumn colPosX;
        private DataGridViewTextBoxColumn colPosY;
        private DataGridViewTextBoxColumn colPosZ;

        private DataGridViewTextBoxColumn colPosU;

        private DataGridViewTextBoxColumn colPosV;

        private DataGridViewTextBoxColumn colPosW;

        private DataGridViewButtonColumn colTest;

        private DataGridViewTextBoxColumn colVelX;

        private DataGridViewTextBoxColumn colVelY;

        private DataGridViewTextBoxColumn colVelZ;

        private DataGridViewTextBoxColumn colVelU;

        private DataGridViewTextBoxColumn colVelV;

        private DataGridViewTextBoxColumn colVelW;

        private Panel pnlTitle;

        private Button btnApply;

        private Button btnTeach;

        private ComboBox cmbAxisName;

        private Label lblAxisName;

        private ComboBox cmbElementName;

        private Label lblElement;

        private TextBox txtId;

        private Label lblId;

        private TextBox txtTrackName;

        private Label lblTrigName;
    }
}
