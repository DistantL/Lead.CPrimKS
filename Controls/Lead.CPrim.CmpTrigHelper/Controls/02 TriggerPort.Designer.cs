using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
    partial class TriggerPort
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
            this.cmbPrimMove = new System.Windows.Forms.ComboBox();
            this.cmbPrimType = new System.Windows.Forms.ComboBox();
            this.lblPrimType = new System.Windows.Forms.Label();
            this.lblPrimMove = new System.Windows.Forms.Label();
            this.lblTrigChannel = new System.Windows.Forms.Label();
            this.cmbTrigChannel = new System.Windows.Forms.ComboBox();
            this.lblTrigMode = new System.Windows.Forms.Label();
            this.cmbTrigMode = new System.Windows.Forms.ComboBox();
            this.lblAxisName = new System.Windows.Forms.Label();
            this.cmbAxisName = new System.Windows.Forms.ComboBox();
            this.lblPosSource = new System.Windows.Forms.Label();
            this.cmbPosSource = new System.Windows.Forms.ComboBox();
            this.cmbLogicDir = new System.Windows.Forms.ComboBox();
            this.lblLogicDir = new System.Windows.Forms.Label();
            this.lblPulseWidth = new System.Windows.Forms.Label();
            this.txtPulseWidth = new System.Windows.Forms.TextBox();
            this.cmbMoveMode = new System.Windows.Forms.ComboBox();
            this.lblMoveMode = new System.Windows.Forms.Label();
            this.lblTrigTable = new System.Windows.Forms.Label();
            this.cmbTrigTable = new System.Windows.Forms.ComboBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.txtTrigName = new System.Windows.Forms.TextBox();
            this.lblTrigName = new System.Windows.Forms.Label();
            this.btnTestTrig = new System.Windows.Forms.Button();
            this.lblTrigPulse = new System.Windows.Forms.Label();
            this.txtTrigPulse = new System.Windows.Forms.TextBox();
            this.cmbElementName = new System.Windows.Forms.ComboBox();
            this.lblEleName = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.cmbMoveTable = new System.Windows.Forms.ComboBox();
            this.lblMoveTable = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.cmbMoveDir = new System.Windows.Forms.ComboBox();
            this.lblMoveDir = new System.Windows.Forms.Label();
            this.lblPrimTrigger = new System.Windows.Forms.Label();
            this.cmbPrimTrigger = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbPrimMove
            // 
            this.cmbPrimMove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimMove.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPrimMove.FormattingEnabled = true;
            this.cmbPrimMove.Items.AddRange(new object[] {
            "Robot",
            "MotionCard"});
            this.cmbPrimMove.Location = new System.Drawing.Point(465, 6);
            this.cmbPrimMove.Name = "cmbPrimMove";
            this.cmbPrimMove.Size = new System.Drawing.Size(100, 27);
            this.cmbPrimMove.TabIndex = 6;
            // 
            // cmbPrimType
            // 
            this.cmbPrimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimType.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPrimType.FormattingEnabled = true;
            this.cmbPrimType.Items.AddRange(new object[] {
            "MotionCard",
            "CmpTrig"});
            this.cmbPrimType.Location = new System.Drawing.Point(275, 6);
            this.cmbPrimType.Name = "cmbPrimType";
            this.cmbPrimType.Size = new System.Drawing.Size(100, 27);
            this.cmbPrimType.TabIndex = 7;
            this.cmbPrimType.SelectedIndexChanged += new System.EventHandler(this.cmbPrimType_SelectedIndexChanged);
            // 
            // lblPrimType
            // 
            this.lblPrimType.AutoSize = true;
            this.lblPrimType.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrimType.Location = new System.Drawing.Point(195, 10);
            this.lblPrimType.Name = "lblPrimType";
            this.lblPrimType.Size = new System.Drawing.Size(74, 19);
            this.lblPrimType.TabIndex = 4;
            this.lblPrimType.Text = "基元类型：";
            // 
            // lblPrimMove
            // 
            this.lblPrimMove.AutoSize = true;
            this.lblPrimMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrimMove.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrimMove.Location = new System.Drawing.Point(385, 9);
            this.lblPrimMove.Name = "lblPrimMove";
            this.lblPrimMove.Size = new System.Drawing.Size(76, 21);
            this.lblPrimMove.TabIndex = 5;
            this.lblPrimMove.Text = "运动基元：";
            this.lblPrimMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPrimMove.Click += new System.EventHandler(this.lbDevicePrim_Click);
            // 
            // lblTrigChannel
            // 
            this.lblTrigChannel.AutoSize = true;
            this.lblTrigChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrigChannel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTrigChannel.Location = new System.Drawing.Point(5, 40);
            this.lblTrigChannel.Name = "lblTrigChannel";
            this.lblTrigChannel.Size = new System.Drawing.Size(76, 21);
            this.lblTrigChannel.TabIndex = 8;
            this.lblTrigChannel.Text = "触发通道：";
            this.lblTrigChannel.Click += new System.EventHandler(this.lbTrigChannel_Click);
            // 
            // cmbTrigChannel
            // 
            this.cmbTrigChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrigChannel.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTrigChannel.FormattingEnabled = true;
            this.cmbTrigChannel.Items.AddRange(new object[] {
            "CH0",
            "CH1",
            "CH2",
            "CH3"});
            this.cmbTrigChannel.Location = new System.Drawing.Point(85, 37);
            this.cmbTrigChannel.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTrigChannel.Name = "cmbTrigChannel";
            this.cmbTrigChannel.Size = new System.Drawing.Size(100, 27);
            this.cmbTrigChannel.TabIndex = 33;
            // 
            // lblTrigMode
            // 
            this.lblTrigMode.AutoSize = true;
            this.lblTrigMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrigMode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTrigMode.Location = new System.Drawing.Point(195, 40);
            this.lblTrigMode.Name = "lblTrigMode";
            this.lblTrigMode.Size = new System.Drawing.Size(76, 21);
            this.lblTrigMode.TabIndex = 34;
            this.lblTrigMode.Text = "触发模式：";
            this.lblTrigMode.Click += new System.EventHandler(this.lbTrigMode_Click);
            // 
            // cmbTrigMode
            // 
            this.cmbTrigMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrigMode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTrigMode.FormattingEnabled = true;
            this.cmbTrigMode.Items.AddRange(new object[] {
            "0:禁止",
            "1:等于",
            "2:小于",
            "3:大于",
            "4:队列",
            "5:线性",
            "6:多队列"});
            this.cmbTrigMode.Location = new System.Drawing.Point(275, 37);
            this.cmbTrigMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTrigMode.Name = "cmbTrigMode";
            this.cmbTrigMode.Size = new System.Drawing.Size(100, 27);
            this.cmbTrigMode.TabIndex = 35;
            this.cmbTrigMode.SelectedIndexChanged += new System.EventHandler(this.cmbTrigMode_SelectedIndexChanged);
            // 
            // lblAxisName
            // 
            this.lblAxisName.AutoSize = true;
            this.lblAxisName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAxisName.Location = new System.Drawing.Point(575, 70);
            this.lblAxisName.Name = "lblAxisName";
            this.lblAxisName.Size = new System.Drawing.Size(61, 19);
            this.lblAxisName.TabIndex = 36;
            this.lblAxisName.Text = "轴名称：";
            // 
            // cmbAxisName
            // 
            this.cmbAxisName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxisName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.cmbAxisName.Location = new System.Drawing.Point(655, 66);
            this.cmbAxisName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAxisName.Name = "cmbAxisName";
            this.cmbAxisName.Size = new System.Drawing.Size(100, 27);
            this.cmbAxisName.TabIndex = 37;
            // 
            // lblPosSource
            // 
            this.lblPosSource.AutoSize = true;
            this.lblPosSource.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPosSource.Location = new System.Drawing.Point(5, 100);
            this.lblPosSource.Name = "lblPosSource";
            this.lblPosSource.Size = new System.Drawing.Size(61, 19);
            this.lblPosSource.TabIndex = 38;
            this.lblPosSource.Text = "位置源：";
            // 
            // cmbPosSource
            // 
            this.cmbPosSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosSource.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPosSource.FormattingEnabled = true;
            this.cmbPosSource.Items.AddRange(new object[] {
            "命令位置",
            "编码器反馈"});
            this.cmbPosSource.Location = new System.Drawing.Point(85, 96);
            this.cmbPosSource.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPosSource.Name = "cmbPosSource";
            this.cmbPosSource.Size = new System.Drawing.Size(100, 27);
            this.cmbPosSource.TabIndex = 39;
            // 
            // cmbLogicDir
            // 
            this.cmbLogicDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicDir.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLogicDir.FormattingEnabled = true;
            this.cmbLogicDir.Items.AddRange(new object[] {
            "低电平",
            "高电平"});
            this.cmbLogicDir.Location = new System.Drawing.Point(655, 37);
            this.cmbLogicDir.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLogicDir.Name = "cmbLogicDir";
            this.cmbLogicDir.Size = new System.Drawing.Size(100, 27);
            this.cmbLogicDir.TabIndex = 43;
            // 
            // lblLogicDir
            // 
            this.lblLogicDir.AutoSize = true;
            this.lblLogicDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLogicDir.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLogicDir.Location = new System.Drawing.Point(575, 40);
            this.lblLogicDir.Name = "lblLogicDir";
            this.lblLogicDir.Size = new System.Drawing.Size(76, 21);
            this.lblLogicDir.TabIndex = 42;
            this.lblLogicDir.Text = "电平方向：";
            this.lblLogicDir.Click += new System.EventHandler(this.lbLogic_Click);
            // 
            // lblPulseWidth
            // 
            this.lblPulseWidth.AutoSize = true;
            this.lblPulseWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPulseWidth.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPulseWidth.Location = new System.Drawing.Point(765, 40);
            this.lblPulseWidth.Name = "lblPulseWidth";
            this.lblPulseWidth.Size = new System.Drawing.Size(76, 21);
            this.lblPulseWidth.TabIndex = 40;
            this.lblPulseWidth.Text = "脉冲宽度：";
            this.lblPulseWidth.Click += new System.EventHandler(this.lbPulseWidth_Click);
            // 
            // txtPulseWidth
            // 
            this.txtPulseWidth.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPulseWidth.Location = new System.Drawing.Point(845, 38);
            this.txtPulseWidth.Name = "txtPulseWidth";
            this.txtPulseWidth.Size = new System.Drawing.Size(100, 25);
            this.txtPulseWidth.TabIndex = 44;
            // 
            // cmbMoveMode
            // 
            this.cmbMoveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveMode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMoveMode.FormattingEnabled = true;
            this.cmbMoveMode.Items.AddRange(new object[] {
            "轨迹表",
            "插补表",
            "复杂插补"});
            this.cmbMoveMode.Location = new System.Drawing.Point(85, 66);
            this.cmbMoveMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMoveMode.Name = "cmbMoveMode";
            this.cmbMoveMode.Size = new System.Drawing.Size(100, 27);
            this.cmbMoveMode.TabIndex = 46;
            this.cmbMoveMode.SelectedIndexChanged += new System.EventHandler(this.cmbMoveMode_SelectedIndexChanged);
            // 
            // lblMoveMode
            // 
            this.lblMoveMode.AutoSize = true;
            this.lblMoveMode.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoveMode.Location = new System.Drawing.Point(5, 70);
            this.lblMoveMode.Name = "lblMoveMode";
            this.lblMoveMode.Size = new System.Drawing.Size(74, 19);
            this.lblMoveMode.TabIndex = 45;
            this.lblMoveMode.Text = "运动模式：";
            // 
            // lblTrigTable
            // 
            this.lblTrigTable.AutoSize = true;
            this.lblTrigTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrigTable.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTrigTable.Location = new System.Drawing.Point(385, 40);
            this.lblTrigTable.Name = "lblTrigTable";
            this.lblTrigTable.Size = new System.Drawing.Size(63, 21);
            this.lblTrigTable.TabIndex = 47;
            this.lblTrigTable.Text = "触发表：";
            this.lblTrigTable.Click += new System.EventHandler(this.lblTrigTable_Click);
            // 
            // cmbTrigTable
            // 
            this.cmbTrigTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrigTable.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTrigTable.FormattingEnabled = true;
            this.cmbTrigTable.Location = new System.Drawing.Point(465, 37);
            this.cmbTrigTable.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTrigTable.Name = "cmbTrigTable";
            this.cmbTrigTable.Size = new System.Drawing.Size(100, 27);
            this.cmbTrigTable.TabIndex = 48;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.BackColor = System.Drawing.Color.Transparent;
            this.chkEnable.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEnable.Location = new System.Drawing.Point(385, 98);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(54, 23);
            this.chkEnable.TabIndex = 49;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = false;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // txtTrigName
            // 
            this.txtTrigName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTrigName.Location = new System.Drawing.Point(85, 7);
            this.txtTrigName.Name = "txtTrigName";
            this.txtTrigName.Size = new System.Drawing.Size(100, 25);
            this.txtTrigName.TabIndex = 51;
            // 
            // lblTrigName
            // 
            this.lblTrigName.AutoSize = true;
            this.lblTrigName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTrigName.Location = new System.Drawing.Point(5, 10);
            this.lblTrigName.Name = "lblTrigName";
            this.lblTrigName.Size = new System.Drawing.Size(74, 19);
            this.lblTrigName.TabIndex = 50;
            this.lblTrigName.Text = "触发名称：";
            this.lblTrigName.DoubleClick += new System.EventHandler(this.TriggerConfigControl_DoubleClick);
            // 
            // btnTestTrig
            // 
            this.btnTestTrig.BackColor = System.Drawing.Color.Bisque;
            this.btnTestTrig.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestTrig.Location = new System.Drawing.Point(845, 95);
            this.btnTestTrig.Name = "btnTestTrig";
            this.btnTestTrig.Size = new System.Drawing.Size(100, 29);
            this.btnTestTrig.TabIndex = 52;
            this.btnTestTrig.Text = "测试";
            this.btnTestTrig.UseVisualStyleBackColor = false;
            this.btnTestTrig.Click += new System.EventHandler(this.btnTestTrig_Click);
            // 
            // lblTrigPulse
            // 
            this.lblTrigPulse.AutoSize = true;
            this.lblTrigPulse.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTrigPulse.Location = new System.Drawing.Point(765, 10);
            this.lblTrigPulse.Name = "lblTrigPulse";
            this.lblTrigPulse.Size = new System.Drawing.Size(74, 19);
            this.lblTrigPulse.TabIndex = 53;
            this.lblTrigPulse.Text = "触发脉冲：";
            // 
            // txtTrigPulse
            // 
            this.txtTrigPulse.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTrigPulse.Location = new System.Drawing.Point(845, 7);
            this.txtTrigPulse.Name = "txtTrigPulse";
            this.txtTrigPulse.Size = new System.Drawing.Size(100, 25);
            this.txtTrigPulse.TabIndex = 54;
            // 
            // cmbElementName
            // 
            this.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElementName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbElementName.FormattingEnabled = true;
            this.cmbElementName.Items.AddRange(new object[] {
            "Robot",
            "MotionCard"});
            this.cmbElementName.Location = new System.Drawing.Point(465, 66);
            this.cmbElementName.Name = "cmbElementName";
            this.cmbElementName.Size = new System.Drawing.Size(100, 27);
            this.cmbElementName.TabIndex = 56;
            this.cmbElementName.SelectedIndexChanged += new System.EventHandler(this.cmbElementName_SelectedIndexChanged);
            // 
            // lblEleName
            // 
            this.lblEleName.AutoSize = true;
            this.lblEleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEleName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEleName.Location = new System.Drawing.Point(385, 69);
            this.lblEleName.Name = "lblEleName";
            this.lblEleName.Size = new System.Drawing.Size(76, 21);
            this.lblEleName.TabIndex = 55;
            this.lblEleName.Text = "元件名称：";
            this.lblEleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEleName.Click += new System.EventHandler(this.lblEleName_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(575, 95);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 29);
            this.btnApply.TabIndex = 57;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cmbMoveTable
            // 
            this.cmbMoveTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveTable.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMoveTable.FormattingEnabled = true;
            this.cmbMoveTable.Location = new System.Drawing.Point(275, 66);
            this.cmbMoveTable.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMoveTable.Name = "cmbMoveTable";
            this.cmbMoveTable.Size = new System.Drawing.Size(100, 27);
            this.cmbMoveTable.TabIndex = 59;
            // 
            // lblMoveTable
            // 
            this.lblMoveTable.AutoSize = true;
            this.lblMoveTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveTable.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoveTable.Location = new System.Drawing.Point(195, 69);
            this.lblMoveTable.Name = "lblMoveTable";
            this.lblMoveTable.Size = new System.Drawing.Size(63, 21);
            this.lblMoveTable.TabIndex = 58;
            this.lblMoveTable.Text = "运动表：";
            this.lblMoveTable.Click += new System.EventHandler(this.lblMoveTable_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.Location = new System.Drawing.Point(710, 95);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(100, 29);
            this.btnSet.TabIndex = 60;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // cmbMoveDir
            // 
            this.cmbMoveDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveDir.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMoveDir.FormattingEnabled = true;
            this.cmbMoveDir.Items.AddRange(new object[] {
            "负方向",
            "正方向",
            "无方向"});
            this.cmbMoveDir.Location = new System.Drawing.Point(845, 66);
            this.cmbMoveDir.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMoveDir.Name = "cmbMoveDir";
            this.cmbMoveDir.Size = new System.Drawing.Size(100, 27);
            this.cmbMoveDir.TabIndex = 62;
            // 
            // lblMoveDir
            // 
            this.lblMoveDir.AutoSize = true;
            this.lblMoveDir.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoveDir.Location = new System.Drawing.Point(765, 70);
            this.lblMoveDir.Name = "lblMoveDir";
            this.lblMoveDir.Size = new System.Drawing.Size(74, 19);
            this.lblMoveDir.TabIndex = 61;
            this.lblMoveDir.Text = "行进方向：";
            // 
            // lblPrimTrigger
            // 
            this.lblPrimTrigger.AutoSize = true;
            this.lblPrimTrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrimTrigger.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrimTrigger.Location = new System.Drawing.Point(575, 9);
            this.lblPrimTrigger.Name = "lblPrimTrigger";
            this.lblPrimTrigger.Size = new System.Drawing.Size(76, 21);
            this.lblPrimTrigger.TabIndex = 5;
            this.lblPrimTrigger.Text = "触发基元：";
            this.lblPrimTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPrimTrigger.Click += new System.EventHandler(this.lblPrimTrigger_Click);
            // 
            // cmbPrimTrigger
            // 
            this.cmbPrimTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimTrigger.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPrimTrigger.FormattingEnabled = true;
            this.cmbPrimTrigger.Location = new System.Drawing.Point(655, 6);
            this.cmbPrimTrigger.Name = "cmbPrimTrigger";
            this.cmbPrimTrigger.Size = new System.Drawing.Size(100, 27);
            this.cmbPrimTrigger.TabIndex = 6;
            // 
            // TriggerPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmbMoveDir);
            this.Controls.Add(this.lblMoveDir);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.cmbMoveTable);
            this.Controls.Add(this.lblMoveTable);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cmbElementName);
            this.Controls.Add(this.lblEleName);
            this.Controls.Add(this.txtTrigPulse);
            this.Controls.Add(this.lblTrigPulse);
            this.Controls.Add(this.btnTestTrig);
            this.Controls.Add(this.txtTrigName);
            this.Controls.Add(this.lblTrigName);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.cmbTrigTable);
            this.Controls.Add(this.lblTrigTable);
            this.Controls.Add(this.cmbMoveMode);
            this.Controls.Add(this.lblMoveMode);
            this.Controls.Add(this.txtPulseWidth);
            this.Controls.Add(this.cmbLogicDir);
            this.Controls.Add(this.lblLogicDir);
            this.Controls.Add(this.lblPulseWidth);
            this.Controls.Add(this.cmbPosSource);
            this.Controls.Add(this.lblPosSource);
            this.Controls.Add(this.cmbAxisName);
            this.Controls.Add(this.lblAxisName);
            this.Controls.Add(this.cmbTrigMode);
            this.Controls.Add(this.lblTrigMode);
            this.Controls.Add(this.cmbTrigChannel);
            this.Controls.Add(this.lblTrigChannel);
            this.Controls.Add(this.cmbPrimTrigger);
            this.Controls.Add(this.cmbPrimMove);
            this.Controls.Add(this.cmbPrimType);
            this.Controls.Add(this.lblPrimType);
            this.Controls.Add(this.lblPrimTrigger);
            this.Controls.Add(this.lblPrimMove);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TriggerPort";
            this.Size = new System.Drawing.Size(950, 130);
            this.Load += new System.EventHandler(this.TriggerConfigControl_Load);
            this.DoubleClick += new System.EventHandler(this.TriggerConfigControl_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox cmbPrimMove;
        private ComboBox cmbPrimType;
        private Label lblPrimType;
        private Label lblPrimMove;
        private Label lblTrigChannel;
        private ComboBox cmbTrigChannel;
        private Label lblTrigMode;
        private ComboBox cmbTrigMode;
        private Label lblAxisName;
        private ComboBox cmbAxisName;
        private Label lblPosSource;
        private ComboBox cmbPosSource;
        private ComboBox cmbLogicDir;
        private Label lblLogicDir;
        private Label lblPulseWidth;
        private TextBox txtPulseWidth;
        private ComboBox cmbMoveMode;
        private Label lblMoveMode;
        private Label lblTrigTable;
        private ComboBox cmbTrigTable;
        private CheckBox chkEnable;
        private TextBox txtTrigName;
        private Label lblTrigName;
        private Button btnTestTrig;
        private Label lblTrigPulse;
        private TextBox txtTrigPulse;
        private ComboBox cmbElementName;
        private Label lblEleName;
        private Button btnApply;
        private ComboBox cmbMoveTable;
        private Label lblMoveTable;
        private Button btnSet;
        private ComboBox cmbMoveDir;
        private Label lblMoveDir;
        private Label lblPrimTrigger;
        private ComboBox cmbPrimTrigger;
    }
}