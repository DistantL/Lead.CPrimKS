using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper.CmpTrigUIs
{
    partial class TriggerConfigControl
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
            this.cmbPrimName = new System.Windows.Forms.ComboBox();
            this.cmbPrimType = new System.Windows.Forms.ComboBox();
            this.lbDeviceType = new System.Windows.Forms.Label();
            this.lbDevicePrim = new System.Windows.Forms.Label();
            this.lbTrigChannel = new System.Windows.Forms.Label();
            this.cmbTrigChannel = new System.Windows.Forms.ComboBox();
            this.lbTrigMode = new System.Windows.Forms.Label();
            this.cmbTrigMode = new System.Windows.Forms.ComboBox();
            this.lbAxisIndex = new System.Windows.Forms.Label();
            this.cmbAxisName = new System.Windows.Forms.ComboBox();
            this.lbPosSource = new System.Windows.Forms.Label();
            this.cmbPosSource = new System.Windows.Forms.ComboBox();
            this.cmbLogicDir = new System.Windows.Forms.ComboBox();
            this.lbLogic = new System.Windows.Forms.Label();
            this.lbPulseWidth = new System.Windows.Forms.Label();
            this.tbPulseWidth = new System.Windows.Forms.TextBox();
            this.cmbMoveMode = new System.Windows.Forms.ComboBox();
            this.lbPulseDir = new System.Windows.Forms.Label();
            this.lbTrigTable = new System.Windows.Forms.Label();
            this.cmbTrigTable = new System.Windows.Forms.ComboBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.tbTrigName = new System.Windows.Forms.TextBox();
            this.lbTrigName = new System.Windows.Forms.Label();
            this.btnTestTrig = new System.Windows.Forms.Button();
            this.lbTrigPulse = new System.Windows.Forms.Label();
            this.tbTrigPulse = new System.Windows.Forms.TextBox();
            this.cmbElementName = new System.Windows.Forms.ComboBox();
            this.lbElement = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.cmbTrajTable = new System.Windows.Forms.ComboBox();
            this.lbTrajTable = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.cmbMoveDir = new System.Windows.Forms.ComboBox();
            this.lb_Direction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPrimName
            // 
            this.cmbPrimName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimName.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPrimName.FormattingEnabled = true;
            this.cmbPrimName.Items.AddRange(new object[] {
            "Robot",
            "MotionCard"});
            this.cmbPrimName.Location = new System.Drawing.Point(95, 69);
            this.cmbPrimName.Name = "cmbPrimName";
            this.cmbPrimName.Size = new System.Drawing.Size(96, 24);
            this.cmbPrimName.TabIndex = 6;
            // 
            // cmbPrimType
            // 
            this.cmbPrimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimType.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPrimType.FormattingEnabled = true;
            this.cmbPrimType.Items.AddRange(new object[] {
            "MotionCard"});
            this.cmbPrimType.Location = new System.Drawing.Point(95, 38);
            this.cmbPrimType.Name = "cmbPrimType";
            this.cmbPrimType.Size = new System.Drawing.Size(96, 24);
            this.cmbPrimType.TabIndex = 7;
            // 
            // lbDeviceType
            // 
            this.lbDeviceType.AutoSize = true;
            this.lbDeviceType.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDeviceType.Location = new System.Drawing.Point(5, 40);
            this.lbDeviceType.Name = "lbDeviceType";
            this.lbDeviceType.Size = new System.Drawing.Size(84, 20);
            this.lbDeviceType.TabIndex = 4;
            this.lbDeviceType.Text = "设备类型：";
            // 
            // lbDevicePrim
            // 
            this.lbDevicePrim.AutoSize = true;
            this.lbDevicePrim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDevicePrim.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevicePrim.Location = new System.Drawing.Point(5, 70);
            this.lbDevicePrim.Name = "lbDevicePrim";
            this.lbDevicePrim.Size = new System.Drawing.Size(86, 22);
            this.lbDevicePrim.TabIndex = 5;
            this.lbDevicePrim.Text = "基元关联：";
            this.lbDevicePrim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDevicePrim.Click += new System.EventHandler(this.lbDevicePrim_Click);
            // 
            // lbTrigChannel
            // 
            this.lbTrigChannel.AutoSize = true;
            this.lbTrigChannel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrigChannel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTrigChannel.Location = new System.Drawing.Point(397, 9);
            this.lbTrigChannel.Name = "lbTrigChannel";
            this.lbTrigChannel.Size = new System.Drawing.Size(86, 22);
            this.lbTrigChannel.TabIndex = 8;
            this.lbTrigChannel.Text = "触发通道：";
            this.lbTrigChannel.Click += new System.EventHandler(this.lbTrigChannel_Click);
            // 
            // cmbTrigChannel
            // 
            this.cmbTrigChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrigChannel.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.cmbTrigChannel.FormattingEnabled = true;
            this.cmbTrigChannel.Items.AddRange(new object[] {
            "CH0",
            "CH1",
            "CH2",
            "CH3"});
            this.cmbTrigChannel.Location = new System.Drawing.Point(486, 8);
            this.cmbTrigChannel.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTrigChannel.Name = "cmbTrigChannel";
            this.cmbTrigChannel.Size = new System.Drawing.Size(92, 24);
            this.cmbTrigChannel.TabIndex = 33;
            // 
            // lbTrigMode
            // 
            this.lbTrigMode.AutoSize = true;
            this.lbTrigMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrigMode.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTrigMode.Location = new System.Drawing.Point(340, 39);
            this.lbTrigMode.Name = "lbTrigMode";
            this.lbTrigMode.Size = new System.Drawing.Size(86, 22);
            this.lbTrigMode.TabIndex = 34;
            this.lbTrigMode.Text = "触发模式：";
            this.lbTrigMode.Click += new System.EventHandler(this.lbTrigMode_Click);
            this.lbTrigMode.DoubleClick += new System.EventHandler(this.lbTrigMode_DoubleClick);
            // 
            // cmbTrigMode
            // 
            this.cmbTrigMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrigMode.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.cmbTrigMode.FormattingEnabled = true;
            this.cmbTrigMode.Items.AddRange(new object[] {
            "0:禁止",
            "1:等于",
            "2:小于",
            "3:大于",
            "4:队列",
            "5:线性",
            "6:多队列"});
            this.cmbTrigMode.Location = new System.Drawing.Point(431, 38);
            this.cmbTrigMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTrigMode.Name = "cmbTrigMode";
            this.cmbTrigMode.Size = new System.Drawing.Size(92, 24);
            this.cmbTrigMode.TabIndex = 35;
            // 
            // lbAxisIndex
            // 
            this.lbAxisIndex.AutoSize = true;
            this.lbAxisIndex.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAxisIndex.Location = new System.Drawing.Point(197, 40);
            this.lbAxisIndex.Name = "lbAxisIndex";
            this.lbAxisIndex.Size = new System.Drawing.Size(69, 20);
            this.lbAxisIndex.TabIndex = 36;
            this.lbAxisIndex.Text = "轴名称：";
            // 
            // cmbAxisName
            // 
            this.cmbAxisName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAxisName.Font = new System.Drawing.Font("微软雅黑", 7.5F);
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
            this.cmbAxisName.Location = new System.Drawing.Point(258, 38);
            this.cmbAxisName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAxisName.Name = "cmbAxisName";
            this.cmbAxisName.Size = new System.Drawing.Size(77, 24);
            this.cmbAxisName.TabIndex = 37;
            // 
            // lbPosSource
            // 
            this.lbPosSource.AutoSize = true;
            this.lbPosSource.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPosSource.Location = new System.Drawing.Point(197, 71);
            this.lbPosSource.Name = "lbPosSource";
            this.lbPosSource.Size = new System.Drawing.Size(69, 20);
            this.lbPosSource.TabIndex = 38;
            this.lbPosSource.Text = "位置源：";
            // 
            // cmbPosSource
            // 
            this.cmbPosSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosSource.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.cmbPosSource.FormattingEnabled = true;
            this.cmbPosSource.Items.AddRange(new object[] {
            "命令位置",
            "编码器反馈"});
            this.cmbPosSource.Location = new System.Drawing.Point(258, 69);
            this.cmbPosSource.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPosSource.Name = "cmbPosSource";
            this.cmbPosSource.Size = new System.Drawing.Size(77, 24);
            this.cmbPosSource.TabIndex = 39;
            // 
            // cmbLogicDir
            // 
            this.cmbLogicDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogicDir.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.cmbLogicDir.FormattingEnabled = true;
            this.cmbLogicDir.Items.AddRange(new object[] {
            "低电平",
            "高电平"});
            this.cmbLogicDir.Location = new System.Drawing.Point(431, 69);
            this.cmbLogicDir.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLogicDir.Name = "cmbLogicDir";
            this.cmbLogicDir.Size = new System.Drawing.Size(77, 24);
            this.cmbLogicDir.TabIndex = 43;
            // 
            // lbLogic
            // 
            this.lbLogic.AutoSize = true;
            this.lbLogic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLogic.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLogic.Location = new System.Drawing.Point(340, 70);
            this.lbLogic.Name = "lbLogic";
            this.lbLogic.Size = new System.Drawing.Size(86, 22);
            this.lbLogic.TabIndex = 42;
            this.lbLogic.Text = "电平方向：";
            this.lbLogic.Click += new System.EventHandler(this.lbLogic_Click);
            // 
            // lbPulseWidth
            // 
            this.lbPulseWidth.AutoSize = true;
            this.lbPulseWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPulseWidth.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPulseWidth.Location = new System.Drawing.Point(755, 9);
            this.lbPulseWidth.Name = "lbPulseWidth";
            this.lbPulseWidth.Size = new System.Drawing.Size(86, 22);
            this.lbPulseWidth.TabIndex = 40;
            this.lbPulseWidth.Text = "脉冲宽度：";
            this.lbPulseWidth.Click += new System.EventHandler(this.lbPulseWidth_Click);
            // 
            // tbPulseWidth
            // 
            this.tbPulseWidth.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbPulseWidth.Location = new System.Drawing.Point(844, 10);
            this.tbPulseWidth.Name = "tbPulseWidth";
            this.tbPulseWidth.Size = new System.Drawing.Size(77, 21);
            this.tbPulseWidth.TabIndex = 44;
            // 
            // cmbMoveMode
            // 
            this.cmbMoveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveMode.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.cmbMoveMode.FormattingEnabled = true;
            this.cmbMoveMode.Items.AddRange(new object[] {
            "轨迹表",
            "插补表",
            "复杂插补"});
            this.cmbMoveMode.Location = new System.Drawing.Point(770, 38);
            this.cmbMoveMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMoveMode.Name = "cmbMoveMode";
            this.cmbMoveMode.Size = new System.Drawing.Size(77, 24);
            this.cmbMoveMode.TabIndex = 46;
            // 
            // lbPulseDir
            // 
            this.lbPulseDir.AutoSize = true;
            this.lbPulseDir.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPulseDir.Location = new System.Drawing.Point(686, 40);
            this.lbPulseDir.Name = "lbPulseDir";
            this.lbPulseDir.Size = new System.Drawing.Size(84, 20);
            this.lbPulseDir.TabIndex = 45;
            this.lbPulseDir.Text = "运动模式：";
            // 
            // lbTrigTable
            // 
            this.lbTrigTable.AutoSize = true;
            this.lbTrigTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrigTable.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTrigTable.Location = new System.Drawing.Point(528, 39);
            this.lbTrigTable.Name = "lbTrigTable";
            this.lbTrigTable.Size = new System.Drawing.Size(71, 22);
            this.lbTrigTable.TabIndex = 47;
            this.lbTrigTable.Text = "触发表：";
            this.lbTrigTable.Click += new System.EventHandler(this.lbTrigTable_Click);
            // 
            // cmbTrigTable
            // 
            this.cmbTrigTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrigTable.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.cmbTrigTable.FormattingEnabled = true;
            this.cmbTrigTable.Location = new System.Drawing.Point(604, 38);
            this.cmbTrigTable.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTrigTable.Name = "cmbTrigTable";
            this.cmbTrigTable.Size = new System.Drawing.Size(77, 24);
            this.cmbTrigTable.TabIndex = 48;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.BackColor = System.Drawing.Color.PaleGreen;
            this.chkEnable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEnable.Location = new System.Drawing.Point(927, 9);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(56, 24);
            this.chkEnable.TabIndex = 49;
            this.chkEnable.Text = "使能";
            this.chkEnable.UseVisualStyleBackColor = false;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // tbTrigName
            // 
            this.tbTrigName.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbTrigName.Location = new System.Drawing.Point(95, 10);
            this.tbTrigName.Name = "tbTrigName";
            this.tbTrigName.Size = new System.Drawing.Size(77, 21);
            this.tbTrigName.TabIndex = 51;
            // 
            // lbTrigName
            // 
            this.lbTrigName.AutoSize = true;
            this.lbTrigName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTrigName.Location = new System.Drawing.Point(5, 10);
            this.lbTrigName.Name = "lbTrigName";
            this.lbTrigName.Size = new System.Drawing.Size(84, 20);
            this.lbTrigName.TabIndex = 50;
            this.lbTrigName.Text = "触发名称：";
            this.lbTrigName.DoubleClick += new System.EventHandler(this.TriggerConfigControl_DoubleClick);
            // 
            // btnTestTrig
            // 
            this.btnTestTrig.BackColor = System.Drawing.Color.Bisque;
            this.btnTestTrig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestTrig.Location = new System.Drawing.Point(930, 38);
            this.btnTestTrig.Name = "btnTestTrig";
            this.btnTestTrig.Size = new System.Drawing.Size(56, 53);
            this.btnTestTrig.TabIndex = 52;
            this.btnTestTrig.Text = "测试";
            this.btnTestTrig.UseVisualStyleBackColor = false;
            this.btnTestTrig.Click += new System.EventHandler(this.btnTestTrig_Click);
            // 
            // lbTrigPulse
            // 
            this.lbTrigPulse.AutoSize = true;
            this.lbTrigPulse.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTrigPulse.Location = new System.Drawing.Point(583, 10);
            this.lbTrigPulse.Name = "lbTrigPulse";
            this.lbTrigPulse.Size = new System.Drawing.Size(84, 20);
            this.lbTrigPulse.TabIndex = 53;
            this.lbTrigPulse.Text = "触发脉冲：";
            // 
            // tbTrigPulse
            // 
            this.tbTrigPulse.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.tbTrigPulse.Location = new System.Drawing.Point(672, 10);
            this.tbTrigPulse.Name = "tbTrigPulse";
            this.tbTrigPulse.Size = new System.Drawing.Size(77, 21);
            this.tbTrigPulse.TabIndex = 54;
            // 
            // cmbElementName
            // 
            this.cmbElementName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElementName.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbElementName.FormattingEnabled = true;
            this.cmbElementName.Items.AddRange(new object[] {
            "Robot",
            "MotionCard"});
            this.cmbElementName.Location = new System.Drawing.Point(295, 8);
            this.cmbElementName.Name = "cmbElementName";
            this.cmbElementName.Size = new System.Drawing.Size(96, 24);
            this.cmbElementName.TabIndex = 56;
            this.cmbElementName.SelectedIndexChanged += new System.EventHandler(this.cmbElementName_SelectedIndexChanged);
            // 
            // lbElement
            // 
            this.lbElement.AutoSize = true;
            this.lbElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbElement.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbElement.Location = new System.Drawing.Point(197, 9);
            this.lbElement.Name = "lbElement";
            this.lbElement.Size = new System.Drawing.Size(86, 22);
            this.lbElement.TabIndex = 55;
            this.lbElement.Text = "元件关联：";
            this.lbElement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbElement.Click += new System.EventHandler(this.lbElement_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LimeGreen;
            this.btnApply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(850, 64);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(78, 29);
            this.btnApply.TabIndex = 57;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cmbTrajTable
            // 
            this.cmbTrajTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrajTable.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.cmbTrajTable.FormattingEnabled = true;
            this.cmbTrajTable.Location = new System.Drawing.Point(604, 69);
            this.cmbTrajTable.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTrajTable.Name = "cmbTrajTable";
            this.cmbTrajTable.Size = new System.Drawing.Size(77, 24);
            this.cmbTrajTable.TabIndex = 59;
            // 
            // lbTrajTable
            // 
            this.lbTrajTable.AutoSize = true;
            this.lbTrajTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTrajTable.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTrajTable.Location = new System.Drawing.Point(528, 70);
            this.lbTrajTable.Name = "lbTrajTable";
            this.lbTrajTable.Size = new System.Drawing.Size(71, 22);
            this.lbTrajTable.TabIndex = 58;
            this.lbTrajTable.Text = "轨迹表：";
            this.lbTrajTable.Click += new System.EventHandler(this.lbTrajTable_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.Location = new System.Drawing.Point(850, 33);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(78, 29);
            this.btnSet.TabIndex = 60;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // cmbMoveDir
            // 
            this.cmbMoveDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveDir.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.cmbMoveDir.FormattingEnabled = true;
            this.cmbMoveDir.Items.AddRange(new object[] {
            "负方向",
            "正方向",
            "无方向"});
            this.cmbMoveDir.Location = new System.Drawing.Point(770, 69);
            this.cmbMoveDir.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMoveDir.Name = "cmbMoveDir";
            this.cmbMoveDir.Size = new System.Drawing.Size(77, 24);
            this.cmbMoveDir.TabIndex = 62;
            // 
            // lb_Direction
            // 
            this.lb_Direction.AutoSize = true;
            this.lb_Direction.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Direction.Location = new System.Drawing.Point(686, 71);
            this.lb_Direction.Name = "lb_Direction";
            this.lb_Direction.Size = new System.Drawing.Size(84, 20);
            this.lb_Direction.TabIndex = 61;
            this.lb_Direction.Text = "行进方向：";
            // 
            // TriggerConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmbMoveDir);
            this.Controls.Add(this.lb_Direction);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.cmbTrajTable);
            this.Controls.Add(this.lbTrajTable);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cmbElementName);
            this.Controls.Add(this.lbElement);
            this.Controls.Add(this.tbTrigPulse);
            this.Controls.Add(this.lbTrigPulse);
            this.Controls.Add(this.btnTestTrig);
            this.Controls.Add(this.tbTrigName);
            this.Controls.Add(this.lbTrigName);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.cmbTrigTable);
            this.Controls.Add(this.lbTrigTable);
            this.Controls.Add(this.cmbMoveMode);
            this.Controls.Add(this.lbPulseDir);
            this.Controls.Add(this.tbPulseWidth);
            this.Controls.Add(this.cmbLogicDir);
            this.Controls.Add(this.lbLogic);
            this.Controls.Add(this.lbPulseWidth);
            this.Controls.Add(this.cmbPosSource);
            this.Controls.Add(this.lbPosSource);
            this.Controls.Add(this.cmbAxisName);
            this.Controls.Add(this.lbAxisIndex);
            this.Controls.Add(this.cmbTrigMode);
            this.Controls.Add(this.lbTrigMode);
            this.Controls.Add(this.cmbTrigChannel);
            this.Controls.Add(this.lbTrigChannel);
            this.Controls.Add(this.cmbPrimName);
            this.Controls.Add(this.cmbPrimType);
            this.Controls.Add(this.lbDeviceType);
            this.Controls.Add(this.lbDevicePrim);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TriggerConfigControl";
            this.Size = new System.Drawing.Size(988, 100);
            this.Load += new System.EventHandler(this.TriggerConfigControl_Load);
            this.DoubleClick += new System.EventHandler(this.TriggerConfigControl_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox cmbPrimName;
        private ComboBox cmbPrimType;
        private Label lbDeviceType;
        private Label lbDevicePrim;
        private Label lbTrigChannel;
        private ComboBox cmbTrigChannel;
        private Label lbTrigMode;
        private ComboBox cmbTrigMode;
        private Label lbAxisIndex;
        private ComboBox cmbAxisName;
        private Label lbPosSource;
        private ComboBox cmbPosSource;
        private ComboBox cmbLogicDir;
        private Label lbLogic;
        private Label lbPulseWidth;
        private TextBox tbPulseWidth;
        private ComboBox cmbMoveMode;
        private Label lbPulseDir;
        private Label lbTrigTable;
        private ComboBox cmbTrigTable;
        private CheckBox chkEnable;
        private TextBox tbTrigName;
        private Label lbTrigName;
        private Button btnTestTrig;
        private Label lbTrigPulse;
        private TextBox tbTrigPulse;
        private ComboBox cmbElementName;
        private Label lbElement;
        private Button btnApply;
        private ComboBox cmbTrajTable;
        private Label lbTrajTable;
        private Button btnSet;
        private ComboBox cmbMoveDir;
        private Label lb_Direction;
    }
}