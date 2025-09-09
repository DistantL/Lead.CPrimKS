using CommunicationBase.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.PrimFinsNet
{
    partial class PrimDebugControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBoxReadBathResult = new System.Windows.Forms.TextBox();
            this.btnReadBatch = new System.Windows.Forms.Button();
            this.tBoxReadBatchLength = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tBoxReadBatchAddr = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPressureTest = new System.Windows.Forms.Button();
            this.btnWriteString = new System.Windows.Forms.Button();
            this.btnWriteDouble = new System.Windows.Forms.Button();
            this.btnWriteFloat = new System.Windows.Forms.Button();
            this.btnWriteULong = new System.Windows.Forms.Button();
            this.btnWriteLong = new System.Windows.Forms.Button();
            this.btnWriteUInt = new System.Windows.Forms.Button();
            this.btnWriteInt = new System.Windows.Forms.Button();
            this.btnWriteUShort = new System.Windows.Forms.Button();
            this.btnWriteShort = new System.Windows.Forms.Button();
            this.btnWriteBool = new System.Windows.Forms.Button();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWriteAddr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReadString = new System.Windows.Forms.Button();
            this.txtReadLength = new System.Windows.Forms.TextBox();
            this.btnReadDouble = new System.Windows.Forms.Button();
            this.btnReadFloat = new System.Windows.Forms.Button();
            this.btnULong = new System.Windows.Forms.Button();
            this.btnReadLong = new System.Windows.Forms.Button();
            this.btnReadUInt = new System.Windows.Forms.Button();
            this.btnReadInt = new System.Windows.Forms.Button();
            this.btnReadUShort = new System.Windows.Forms.Button();
            this.btnReadShort = new System.Windows.Forms.Button();
            this.btnReadBool = new System.Windows.Forms.Button();
            this.tBoxReadResult = new System.Windows.Forms.TextBox();
            this.txtReadAddr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.userCurve1 = new CommunicationBase.Controls.UserCurve();
            this.tBoxReadTimingStart = new System.Windows.Forms.Button();
            this.tBoxReadTimingInterval = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tBoxReadTimingAddr = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tBoxMessageResult = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnReadMessage = new System.Windows.Forms.Button();
            this.tBoxMessage = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tlpMain = new UITableLayoutPanel();
            this.tbRunState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnState = new System.Windows.Forms.TextBox();
            this.tTaskBoxName = new System.Windows.Forms.TextBox();
            this.groupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnStop);
            this.groupBox.Controls.Add(this.btnRun);
            this.groupBox.Controls.Add(this.btnInit);
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox.Location = new System.Drawing.Point(560, 294);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(220, 84);
            this.groupBox.TabIndex = 126;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "EXE";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SandyBrown;
            this.btnStop.Location = new System.Drawing.Point(140, 28);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(74, 41);
            this.btnStop.TabIndex = 105;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.LightGreen;
            this.btnRun.Location = new System.Drawing.Point(72, 28);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(60, 41);
            this.btnRun.TabIndex = 105;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.SkyBlue;
            this.btnInit.Location = new System.Drawing.Point(6, 28);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(60, 41);
            this.btnInit.TabIndex = 105;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 300;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(810, 429);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Debug1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tBoxReadBathResult);
            this.groupBox3.Controls.Add(this.btnReadBatch);
            this.groupBox3.Controls.Add(this.tBoxReadBatchLength);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.tBoxReadBatchAddr);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(3, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(518, 154);
            this.groupBox3.TabIndex = 129;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Batch read test";
            // 
            // tBoxReadBathResult
            // 
            this.tBoxReadBathResult.Location = new System.Drawing.Point(11, 60);
            this.tBoxReadBathResult.Multiline = true;
            this.tBoxReadBathResult.Name = "tBoxReadBathResult";
            this.tBoxReadBathResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxReadBathResult.Size = new System.Drawing.Size(497, 78);
            this.tBoxReadBathResult.TabIndex = 10;
            // 
            // btnReadBatch
            // 
            this.btnReadBatch.Location = new System.Drawing.Point(426, 24);
            this.btnReadBatch.Name = "btnReadBatch";
            this.btnReadBatch.Size = new System.Drawing.Size(82, 28);
            this.btnReadBatch.TabIndex = 8;
            this.btnReadBatch.Text = "Batch Read";
            this.btnReadBatch.UseVisualStyleBackColor = true;
            this.btnReadBatch.Click += new System.EventHandler(this.btnReadBatch_Click);
            // 
            // tBoxReadBatchLength
            // 
            this.tBoxReadBatchLength.Location = new System.Drawing.Point(239, 27);
            this.tBoxReadBatchLength.Name = "tBoxReadBatchLength";
            this.tBoxReadBatchLength.Size = new System.Drawing.Size(102, 23);
            this.tBoxReadBatchLength.TabIndex = 7;
            this.tBoxReadBatchLength.Text = "10";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(185, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 17);
            this.label12.TabIndex = 6;
            this.label12.Text = "Length:";
            // 
            // tBoxReadBatchAddr
            // 
            this.tBoxReadBatchAddr.Location = new System.Drawing.Point(63, 27);
            this.tBoxReadBatchAddr.Name = "tBoxReadBatchAddr";
            this.tBoxReadBatchAddr.Size = new System.Drawing.Size(102, 23);
            this.tBoxReadBatchAddr.TabIndex = 5;
            this.tBoxReadBatchAddr.Text = "100";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Addr:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPressureTest);
            this.groupBox2.Controls.Add(this.btnWriteString);
            this.groupBox2.Controls.Add(this.btnWriteDouble);
            this.groupBox2.Controls.Add(this.btnWriteFloat);
            this.groupBox2.Controls.Add(this.btnWriteULong);
            this.groupBox2.Controls.Add(this.btnWriteLong);
            this.groupBox2.Controls.Add(this.btnWriteUInt);
            this.groupBox2.Controls.Add(this.btnWriteInt);
            this.groupBox2.Controls.Add(this.btnWriteUShort);
            this.groupBox2.Controls.Add(this.btnWriteShort);
            this.groupBox2.Controls.Add(this.btnWriteBool);
            this.groupBox2.Controls.Add(this.txtWriteValue);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtWriteAddr);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(401, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 234);
            this.groupBox2.TabIndex = 128;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Single data write test";
            // 
            // btnPressureTest
            // 
            this.btnPressureTest.Location = new System.Drawing.Point(12, 194);
            this.btnPressureTest.Name = "btnPressureTest";
            this.btnPressureTest.Size = new System.Drawing.Size(367, 28);
            this.btnPressureTest.TabIndex = 23;
            this.btnPressureTest.Text = "Stress test, fast reading and writing 3000 times";
            this.btnPressureTest.UseVisualStyleBackColor = true;
            this.btnPressureTest.Click += new System.EventHandler(this.btnPressureTest_Click);
            // 
            // btnWriteString
            // 
            this.btnWriteString.Location = new System.Drawing.Point(107, 118);
            this.btnWriteString.Name = "btnWriteString";
            this.btnWriteString.Size = new System.Drawing.Size(82, 28);
            this.btnWriteString.TabIndex = 16;
            this.btnWriteString.Text = "string";
            this.btnWriteString.UseVisualStyleBackColor = true;
            this.btnWriteString.Click += new System.EventHandler(this.btnWriteString_Click);
            // 
            // btnWriteDouble
            // 
            this.btnWriteDouble.Location = new System.Drawing.Point(297, 83);
            this.btnWriteDouble.Name = "btnWriteDouble";
            this.btnWriteDouble.Size = new System.Drawing.Size(82, 28);
            this.btnWriteDouble.TabIndex = 15;
            this.btnWriteDouble.Text = "double";
            this.btnWriteDouble.UseVisualStyleBackColor = true;
            this.btnWriteDouble.Click += new System.EventHandler(this.btnWriteDouble_Click);
            // 
            // btnWriteFloat
            // 
            this.btnWriteFloat.Location = new System.Drawing.Point(297, 49);
            this.btnWriteFloat.Name = "btnWriteFloat";
            this.btnWriteFloat.Size = new System.Drawing.Size(82, 28);
            this.btnWriteFloat.TabIndex = 14;
            this.btnWriteFloat.Text = "float";
            this.btnWriteFloat.UseVisualStyleBackColor = true;
            this.btnWriteFloat.Click += new System.EventHandler(this.btnWriteFloat_Click);
            // 
            // btnWriteULong
            // 
            this.btnWriteULong.Location = new System.Drawing.Point(202, 83);
            this.btnWriteULong.Name = "btnWriteULong";
            this.btnWriteULong.Size = new System.Drawing.Size(82, 28);
            this.btnWriteULong.TabIndex = 13;
            this.btnWriteULong.Text = "ulong";
            this.btnWriteULong.UseVisualStyleBackColor = true;
            this.btnWriteULong.Click += new System.EventHandler(this.btnWriteULong_Click);
            // 
            // btnWriteLong
            // 
            this.btnWriteLong.Location = new System.Drawing.Point(202, 49);
            this.btnWriteLong.Name = "btnWriteLong";
            this.btnWriteLong.Size = new System.Drawing.Size(82, 28);
            this.btnWriteLong.TabIndex = 12;
            this.btnWriteLong.Text = "long";
            this.btnWriteLong.UseVisualStyleBackColor = true;
            this.btnWriteLong.Click += new System.EventHandler(this.btnWriteLong_Click);
            // 
            // btnWriteUInt
            // 
            this.btnWriteUInt.Location = new System.Drawing.Point(107, 83);
            this.btnWriteUInt.Name = "btnWriteUInt";
            this.btnWriteUInt.Size = new System.Drawing.Size(82, 28);
            this.btnWriteUInt.TabIndex = 11;
            this.btnWriteUInt.Text = "uint";
            this.btnWriteUInt.UseVisualStyleBackColor = true;
            this.btnWriteUInt.Click += new System.EventHandler(this.btnWriteUInt_Click);
            // 
            // btnWriteInt
            // 
            this.btnWriteInt.Location = new System.Drawing.Point(107, 49);
            this.btnWriteInt.Name = "btnWriteInt";
            this.btnWriteInt.Size = new System.Drawing.Size(82, 28);
            this.btnWriteInt.TabIndex = 10;
            this.btnWriteInt.Text = "int";
            this.btnWriteInt.UseVisualStyleBackColor = true;
            this.btnWriteInt.Click += new System.EventHandler(this.btnWriteInt_Click);
            // 
            // btnWriteUShort
            // 
            this.btnWriteUShort.Location = new System.Drawing.Point(12, 83);
            this.btnWriteUShort.Name = "btnWriteUShort";
            this.btnWriteUShort.Size = new System.Drawing.Size(82, 28);
            this.btnWriteUShort.TabIndex = 9;
            this.btnWriteUShort.Text = "ushort";
            this.btnWriteUShort.UseVisualStyleBackColor = true;
            this.btnWriteUShort.Click += new System.EventHandler(this.btnWriteUShort_Click);
            // 
            // btnWriteShort
            // 
            this.btnWriteShort.Location = new System.Drawing.Point(12, 49);
            this.btnWriteShort.Name = "btnWriteShort";
            this.btnWriteShort.Size = new System.Drawing.Size(82, 28);
            this.btnWriteShort.TabIndex = 8;
            this.btnWriteShort.Text = "short";
            this.btnWriteShort.UseVisualStyleBackColor = true;
            this.btnWriteShort.Click += new System.EventHandler(this.btnWriteShort_Click);
            // 
            // btnWriteBool
            // 
            this.btnWriteBool.Location = new System.Drawing.Point(12, 118);
            this.btnWriteBool.Name = "btnWriteBool";
            this.btnWriteBool.Size = new System.Drawing.Size(82, 28);
            this.btnWriteBool.TabIndex = 6;
            this.btnWriteBool.Text = "Bool";
            this.btnWriteBool.UseVisualStyleBackColor = true;
            this.btnWriteBool.Click += new System.EventHandler(this.btnWriteCoil_Click);
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(231, 21);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWriteValue.Size = new System.Drawing.Size(145, 23);
            this.txtWriteValue.TabIndex = 5;
            this.txtWriteValue.Text = "False";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(179, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Value:";
            // 
            // txtWriteAddr
            // 
            this.txtWriteAddr.Location = new System.Drawing.Point(54, 21);
            this.txtWriteAddr.Name = "txtWriteAddr";
            this.txtWriteAddr.Size = new System.Drawing.Size(60, 23);
            this.txtWriteAddr.TabIndex = 3;
            this.txtWriteAddr.Text = "100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Addr:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReadString);
            this.groupBox1.Controls.Add(this.txtReadLength);
            this.groupBox1.Controls.Add(this.btnReadDouble);
            this.groupBox1.Controls.Add(this.btnReadFloat);
            this.groupBox1.Controls.Add(this.btnULong);
            this.groupBox1.Controls.Add(this.btnReadLong);
            this.groupBox1.Controls.Add(this.btnReadUInt);
            this.groupBox1.Controls.Add(this.btnReadInt);
            this.groupBox1.Controls.Add(this.btnReadUShort);
            this.groupBox1.Controls.Add(this.btnReadShort);
            this.groupBox1.Controls.Add(this.btnReadBool);
            this.groupBox1.Controls.Add(this.tBoxReadResult);
            this.groupBox1.Controls.Add(this.txtReadAddr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 234);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single data read test";
            // 
            // btnReadString
            // 
            this.btnReadString.Location = new System.Drawing.Point(106, 118);
            this.btnReadString.Name = "btnReadString";
            this.btnReadString.Size = new System.Drawing.Size(82, 28);
            this.btnReadString.TabIndex = 16;
            this.btnReadString.Text = "string";
            this.btnReadString.UseVisualStyleBackColor = true;
            this.btnReadString.Click += new System.EventHandler(this.btnReadString_Click);
            // 
            // txtReadLength
            // 
            this.txtReadLength.Location = new System.Drawing.Point(227, 21);
            this.txtReadLength.Name = "txtReadLength";
            this.txtReadLength.Size = new System.Drawing.Size(60, 23);
            this.txtReadLength.TabIndex = 17;
            this.txtReadLength.Text = "10";
            // 
            // btnReadDouble
            // 
            this.btnReadDouble.Location = new System.Drawing.Point(296, 83);
            this.btnReadDouble.Name = "btnReadDouble";
            this.btnReadDouble.Size = new System.Drawing.Size(82, 28);
            this.btnReadDouble.TabIndex = 15;
            this.btnReadDouble.Text = "double";
            this.btnReadDouble.UseVisualStyleBackColor = true;
            this.btnReadDouble.Click += new System.EventHandler(this.btnReadDouble_Click);
            // 
            // btnReadFloat
            // 
            this.btnReadFloat.Location = new System.Drawing.Point(296, 49);
            this.btnReadFloat.Name = "btnReadFloat";
            this.btnReadFloat.Size = new System.Drawing.Size(82, 28);
            this.btnReadFloat.TabIndex = 14;
            this.btnReadFloat.Text = "float";
            this.btnReadFloat.UseVisualStyleBackColor = true;
            this.btnReadFloat.Click += new System.EventHandler(this.btnReadFloat_Click);
            // 
            // btnULong
            // 
            this.btnULong.Location = new System.Drawing.Point(201, 83);
            this.btnULong.Name = "btnULong";
            this.btnULong.Size = new System.Drawing.Size(82, 28);
            this.btnULong.TabIndex = 13;
            this.btnULong.Text = "ulong";
            this.btnULong.UseVisualStyleBackColor = true;
            this.btnULong.Click += new System.EventHandler(this.btnULong_Click);
            // 
            // btnReadLong
            // 
            this.btnReadLong.Location = new System.Drawing.Point(201, 49);
            this.btnReadLong.Name = "btnReadLong";
            this.btnReadLong.Size = new System.Drawing.Size(82, 28);
            this.btnReadLong.TabIndex = 12;
            this.btnReadLong.Text = "long";
            this.btnReadLong.UseVisualStyleBackColor = true;
            this.btnReadLong.Click += new System.EventHandler(this.btnReadLong_Click);
            // 
            // btnReadUInt
            // 
            this.btnReadUInt.Location = new System.Drawing.Point(106, 83);
            this.btnReadUInt.Name = "btnReadUInt";
            this.btnReadUInt.Size = new System.Drawing.Size(82, 28);
            this.btnReadUInt.TabIndex = 11;
            this.btnReadUInt.Text = "uint";
            this.btnReadUInt.UseVisualStyleBackColor = true;
            this.btnReadUInt.Click += new System.EventHandler(this.btnReadUInt_Click);
            // 
            // btnReadInt
            // 
            this.btnReadInt.Location = new System.Drawing.Point(106, 49);
            this.btnReadInt.Name = "btnReadInt";
            this.btnReadInt.Size = new System.Drawing.Size(82, 28);
            this.btnReadInt.TabIndex = 10;
            this.btnReadInt.Text = "int";
            this.btnReadInt.UseVisualStyleBackColor = true;
            this.btnReadInt.Click += new System.EventHandler(this.btnReadInt_Click);
            // 
            // btnReadUShort
            // 
            this.btnReadUShort.Location = new System.Drawing.Point(11, 83);
            this.btnReadUShort.Name = "btnReadUShort";
            this.btnReadUShort.Size = new System.Drawing.Size(82, 28);
            this.btnReadUShort.TabIndex = 9;
            this.btnReadUShort.Text = "ushort";
            this.btnReadUShort.UseVisualStyleBackColor = true;
            this.btnReadUShort.Click += new System.EventHandler(this.btnReadUShort_Click);
            // 
            // btnReadShort
            // 
            this.btnReadShort.Location = new System.Drawing.Point(11, 49);
            this.btnReadShort.Name = "btnReadShort";
            this.btnReadShort.Size = new System.Drawing.Size(82, 28);
            this.btnReadShort.TabIndex = 8;
            this.btnReadShort.Text = "short";
            this.btnReadShort.UseVisualStyleBackColor = true;
            this.btnReadShort.Click += new System.EventHandler(this.btnReadShort_Click);
            // 
            // btnReadBool
            // 
            this.btnReadBool.Location = new System.Drawing.Point(11, 118);
            this.btnReadBool.Name = "btnReadBool";
            this.btnReadBool.Size = new System.Drawing.Size(82, 28);
            this.btnReadBool.TabIndex = 6;
            this.btnReadBool.Text = "bool";
            this.btnReadBool.UseVisualStyleBackColor = true;
            this.btnReadBool.Click += new System.EventHandler(this.btnReadCoil_Click);
            // 
            // tBoxReadResult
            // 
            this.tBoxReadResult.Location = new System.Drawing.Point(11, 148);
            this.tBoxReadResult.Multiline = true;
            this.tBoxReadResult.Name = "tBoxReadResult";
            this.tBoxReadResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxReadResult.Size = new System.Drawing.Size(367, 74);
            this.tBoxReadResult.TabIndex = 5;
            // 
            // txtReadAddr
            // 
            this.txtReadAddr.Location = new System.Drawing.Point(61, 21);
            this.txtReadAddr.Name = "txtReadAddr";
            this.txtReadAddr.Size = new System.Drawing.Size(60, 23);
            this.txtReadAddr.TabIndex = 3;
            this.txtReadAddr.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Addr:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Length:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(802, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug2";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.userCurve1);
            this.groupBox5.Controls.Add(this.tBoxReadTimingStart);
            this.groupBox5.Controls.Add(this.tBoxReadTimingInterval);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.tBoxReadTimingAddr);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(4, 127);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(507, 269);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Timed reading, curve display";
            // 
            // userCurve1
            // 
            this.userCurve1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.userCurve1.Location = new System.Drawing.Point(13, 74);
            this.userCurve1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userCurve1.Name = "userCurve1";
            this.userCurve1.Size = new System.Drawing.Size(392, 188);
            this.userCurve1.TabIndex = 10;
            this.userCurve1.ValueMaxLeft = 200F;
            this.userCurve1.ValueMaxRight = 200F;
            // 
            // tBoxReadTimingStart
            // 
            this.tBoxReadTimingStart.Location = new System.Drawing.Point(356, 25);
            this.tBoxReadTimingStart.Name = "tBoxReadTimingStart";
            this.tBoxReadTimingStart.Size = new System.Drawing.Size(70, 28);
            this.tBoxReadTimingStart.TabIndex = 9;
            this.tBoxReadTimingStart.Text = "Start";
            this.tBoxReadTimingStart.UseVisualStyleBackColor = true;
            this.tBoxReadTimingStart.Click += new System.EventHandler(this.tBoxReadTimingStart_Click);
            // 
            // tBoxReadTimingInterval
            // 
            this.tBoxReadTimingInterval.Location = new System.Drawing.Point(268, 28);
            this.tBoxReadTimingInterval.Name = "tBoxReadTimingInterval";
            this.tBoxReadTimingInterval.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxReadTimingInterval.Size = new System.Drawing.Size(82, 23);
            this.tBoxReadTimingInterval.TabIndex = 8;
            this.tBoxReadTimingInterval.Text = "300";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(212, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 17);
            this.label18.TabIndex = 7;
            this.label18.Text = "Interval:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(10, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(426, 17);
            this.label17.TabIndex = 6;
            this.label17.Text = "The assumption here is that the type of the data is determined as short:";
            // 
            // tBoxReadTimingAddr
            // 
            this.tBoxReadTimingAddr.Location = new System.Drawing.Point(64, 27);
            this.tBoxReadTimingAddr.Name = "tBoxReadTimingAddr";
            this.tBoxReadTimingAddr.Size = new System.Drawing.Size(132, 23);
            this.tBoxReadTimingAddr.TabIndex = 5;
            this.tBoxReadTimingAddr.Text = "D100";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 17);
            this.label15.TabIndex = 4;
            this.label15.Text = "Addr:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tBoxMessageResult);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.btnReadMessage);
            this.groupBox4.Controls.Add(this.tBoxMessage);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(518, 118);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Packet read test, here you need to fill in the complete hexadecimal message strin" +
    "g";
            // 
            // tBoxMessageResult
            // 
            this.tBoxMessageResult.Location = new System.Drawing.Point(63, 60);
            this.tBoxMessageResult.Multiline = true;
            this.tBoxMessageResult.Name = "tBoxMessageResult";
            this.tBoxMessageResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxMessageResult.Size = new System.Drawing.Size(445, 52);
            this.tBoxMessageResult.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 17);
            this.label14.TabIndex = 9;
            this.label14.Text = "Result:";
            // 
            // btnReadMessage
            // 
            this.btnReadMessage.Location = new System.Drawing.Point(426, 24);
            this.btnReadMessage.Name = "btnReadMessage";
            this.btnReadMessage.Size = new System.Drawing.Size(82, 28);
            this.btnReadMessage.TabIndex = 8;
            this.btnReadMessage.Text = "Convert";
            this.btnReadMessage.UseVisualStyleBackColor = true;
            this.btnReadMessage.Click += new System.EventHandler(this.btnReadMessage_Click);
            // 
            // tBoxMessage
            // 
            this.tBoxMessage.Location = new System.Drawing.Point(63, 27);
            this.tBoxMessage.Name = "tBoxMessage";
            this.tBoxMessage.Size = new System.Drawing.Size(357, 23);
            this.tBoxMessage.TabIndex = 5;
            this.tBoxMessage.Text = "00 00 00 00 00 06 FF 03 00 00 00 05";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 17);
            this.label16.TabIndex = 4;
            this.label16.Text = "Packet:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 44);
            this.panel1.TabIndex = 28;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(810, 43);
            this.lbTitle.TabIndex = 27;
            this.lbTitle.Text = "FinsNet Debug";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 5;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.Controls.Add(this.tbRunState, 4, 0);
            this.tlpMain.Controls.Add(this.label1, 0, 0);
            this.tlpMain.Controls.Add(this.tbConnState, 3, 0);
            this.tlpMain.Controls.Add(this.tTaskBoxName, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(810, 44);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.TagString = null;
            // 
            // tbRunState
            // 
            this.tbRunState.BackColor = System.Drawing.Color.Khaki;
            this.tbRunState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRunState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbRunState.Location = new System.Drawing.Point(661, 1);
            this.tbRunState.Margin = new System.Windows.Forms.Padding(1);
            this.tbRunState.Multiline = true;
            this.tbRunState.Name = "tbRunState";
            this.tbRunState.Size = new System.Drawing.Size(148, 42);
            this.tbRunState.TabIndex = 14;
            this.tbRunState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 42);
            this.label1.TabIndex = 12;
            this.label1.Text = "FinsNet Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbConnState
            // 
            this.tbConnState.BackColor = System.Drawing.Color.Khaki;
            this.tbConnState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConnState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConnState.Location = new System.Drawing.Point(511, 1);
            this.tbConnState.Margin = new System.Windows.Forms.Padding(1);
            this.tbConnState.Multiline = true;
            this.tbConnState.Name = "tbConnState";
            this.tbConnState.Size = new System.Drawing.Size(148, 42);
            this.tbConnState.TabIndex = 15;
            this.tbConnState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tTaskBoxName
            // 
            this.tTaskBoxName.BackColor = System.Drawing.Color.OldLace;
            this.tTaskBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tTaskBoxName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tTaskBoxName.Location = new System.Drawing.Point(151, 1);
            this.tTaskBoxName.Margin = new System.Windows.Forms.Padding(1);
            this.tTaskBoxName.Multiline = true;
            this.tTaskBoxName.Name = "tTaskBoxName";
            this.tTaskBoxName.Size = new System.Drawing.Size(148, 42);
            this.tTaskBoxName.TabIndex = 13;
            this.tTaskBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PrimDebugControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrimDebugControl";
            this.Size = new System.Drawing.Size(810, 516);
            this.Load += new System.EventHandler(this.PrimDebugControl_Load);
            this.groupBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbConnState;
        private System.Windows.Forms.TextBox tbRunState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tTaskBoxName;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReadLength;
        private System.Windows.Forms.Button btnReadString;
        private System.Windows.Forms.Button btnReadDouble;
        private System.Windows.Forms.Button btnReadFloat;
        private System.Windows.Forms.Button btnULong;
        private System.Windows.Forms.Button btnReadLong;
        private System.Windows.Forms.Button btnReadUInt;
        private System.Windows.Forms.Button btnReadInt;
        private System.Windows.Forms.Button btnReadUShort;
        private System.Windows.Forms.Button btnReadShort;
        private System.Windows.Forms.Button btnReadBool;
        private System.Windows.Forms.TextBox tBoxReadResult;
        private System.Windows.Forms.TextBox txtReadAddr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPressureTest;
        private System.Windows.Forms.Button btnWriteString;
        private System.Windows.Forms.Button btnWriteDouble;
        private System.Windows.Forms.Button btnWriteFloat;
        private System.Windows.Forms.Button btnWriteULong;
        private System.Windows.Forms.Button btnWriteLong;
        private System.Windows.Forms.Button btnWriteUInt;
        private System.Windows.Forms.Button btnWriteInt;
        private System.Windows.Forms.Button btnWriteUShort;
        private System.Windows.Forms.Button btnWriteShort;
        private System.Windows.Forms.Button btnWriteBool;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWriteAddr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tBoxReadBathResult;
        private System.Windows.Forms.Button btnReadBatch;
        private System.Windows.Forms.TextBox tBoxReadBatchLength;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBoxReadBatchAddr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tBoxMessageResult;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnReadMessage;
        private System.Windows.Forms.TextBox tBoxMessage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button tBoxReadTimingStart;
        private System.Windows.Forms.TextBox tBoxReadTimingInterval;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tBoxReadTimingAddr;
        private System.Windows.Forms.Label label15;
        private UserCurve userCurve1;
        private UITableLayoutPanel tlpMain;
    }
}
