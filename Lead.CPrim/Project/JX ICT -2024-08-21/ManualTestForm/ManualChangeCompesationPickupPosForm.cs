using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManualChangeCompesation
{

    public class ManualChangeCompesationPickupPosForm : Form
    {
        #region Field
        private static ManualChangeCompesationPickupPosForm _instance;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private MaskedTextBox mtb_password;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button bt_Slot1_Save;
        private Label lb_Slot1_当前保存补偿;
        private Label lb_Slot1_当前保存坐标;
        private TextBox tb_Slot1_补偿X;
        private Label lb_Slot1_补偿Y;
        private TextBox tb_Slot1_补偿Y;
        private Label lb_Slot1_补偿Z;
        private TextBox tb_Slot1_补偿Z;
        private Label lb_Slot1_修改后取料位置;
        private Label lb_Slot1_补偿X;
        private Label lb_Slot1_实际取料位置;
        private Button bt_Slot1_Clear;
        private Button bt_Slot2_Clear;
        private TextBox tb_Slot2_补偿X;
        private Label lb_Slot2_补偿Y;
        private Button bt_Slot2_Save;
        private TextBox tb_Slot2_补偿Y;
        private Label label15;
        private Label lb_Slot2_当前保存坐标;
        private Label lb_Slot2_补偿Z;
        private Label lb_Slot2_当前保存补偿;
        private TextBox tb_Slot2_补偿Z;
        private Label lb_Slot2_实际取料位置;
        private Label lb_Slot2_修改后取料位置;
        private Label lb_Slot2_补偿X;
        private static object objLock = new object();

        private double _slot1_pickUp_x;
        private double _slot1_pickUp_y;
        private double _slot1_pickUp_z;
        private double _slot1_compensation_x;
        private double _slot1_compensation_y;
        private double _slot1_compensation_z;
        private double _slot2_pickUp_x;
        private double _slot2_pickUp_y;
        private double _slot2_pickUp_z;
        private double _slot2_compensation_x;
        private double _slot2_compensation_y;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button bt_Slot2_Cancel;
        private Button bt_Slot1_Cancel;
        private Timer timer1;
        private double _slot2_compensation_z;

        #endregion


        #region Prop
        public bool IsRuning { get; set; }
        public static ManualChangeCompesationPickupPosForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManualChangeCompesationPickupPosForm();
                }
                return _instance;
            }
        }

        #endregion


        #region Event_Define
        private event Action<string, double, double, double> ChangeCompesation_slot1;
        private event Action<string, double, double, double> ChangeCompesation_slot2;
        #endregion


        #region System_Event
        private void ManualTestFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsRuning = false;
            e.Cancel = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            Hide();
        }
        #endregion


        #region Ctor
        private ManualChangeCompesationPickupPosForm()
        {
            InitializeComponent();
        }
        #endregion


        #region Button_Event

        #endregion


        #region Method_ExternalUsing

        public void SetPos_Slot1(
              double slot1_pickUp_x
            , double slot1_pickUp_y
            , double slot1_pickUp_z
            , double slot1_compensation_x
            , double slot1_compensation_y
            , double slot1_compensation_z
            , Action<string, double, double, double> action
            )
        {
            _slot1_pickUp_x = slot1_pickUp_x;
            _slot1_pickUp_y = slot1_pickUp_y;
            _slot1_pickUp_z = slot1_pickUp_z;
            _slot1_compensation_x = slot1_compensation_x;
            _slot1_compensation_y = slot1_compensation_y;
            _slot1_compensation_z = slot1_compensation_z;
            ChangeCompesation_slot1 -= action;
            ChangeCompesation_slot1 += action;
            groupBox1.Enabled = true;
        }

        public void SetPos_Slot2(
              double slot2_pickUp_x
            , double slot2_pickUp_y
            , double slot2_pickUp_z
            , double slot2_compensation_x
            , double slot2_compensation_y
            , double slot2_compensation_z
            , Action<string, double, double, double> action
    )
        {
            _slot2_pickUp_x = slot2_pickUp_x;
            _slot2_pickUp_y = slot2_pickUp_y;
            _slot2_pickUp_z = slot2_pickUp_z;
            _slot2_compensation_x = slot2_compensation_x;
            _slot2_compensation_y = slot2_compensation_y;
            _slot2_compensation_z = slot2_compensation_z;
            _slot2_compensation_z = slot2_compensation_z;
            ChangeCompesation_slot2 -= action;
            ChangeCompesation_slot2 += action;
            groupBox2.Enabled = true;

        }

        #endregion


        #region Method_InternalUsing

        #endregion


        #region System
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_Slot2_Cancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_Slot2_Clear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Slot2_补偿X = new System.Windows.Forms.TextBox();
            this.lb_Slot2_补偿Y = new System.Windows.Forms.Label();
            this.bt_Slot2_Save = new System.Windows.Forms.Button();
            this.tb_Slot2_补偿Y = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lb_Slot2_当前保存坐标 = new System.Windows.Forms.Label();
            this.lb_Slot2_补偿Z = new System.Windows.Forms.Label();
            this.lb_Slot2_当前保存补偿 = new System.Windows.Forms.Label();
            this.tb_Slot2_补偿Z = new System.Windows.Forms.TextBox();
            this.lb_Slot2_实际取料位置 = new System.Windows.Forms.Label();
            this.lb_Slot2_修改后取料位置 = new System.Windows.Forms.Label();
            this.lb_Slot2_补偿X = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mtb_password = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Slot1_Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_Slot1_Clear = new System.Windows.Forms.Button();
            this.lb_Slot1_补偿Y = new System.Windows.Forms.Label();
            this.tb_Slot1_补偿Y = new System.Windows.Forms.TextBox();
            this.lb_Slot1_补偿Z = new System.Windows.Forms.Label();
            this.tb_Slot1_补偿Z = new System.Windows.Forms.TextBox();
            this.lb_Slot1_修改后取料位置 = new System.Windows.Forms.Label();
            this.lb_Slot1_补偿X = new System.Windows.Forms.Label();
            this.lb_Slot1_实际取料位置 = new System.Windows.Forms.Label();
            this.lb_Slot1_当前保存补偿 = new System.Windows.Forms.Label();
            this.lb_Slot1_当前保存坐标 = new System.Windows.Forms.Label();
            this.bt_Slot1_Save = new System.Windows.Forms.Button();
            this.tb_Slot1_补偿X = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_Slot2_Cancel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.bt_Slot2_Clear);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tb_Slot2_补偿X);
            this.groupBox2.Controls.Add(this.lb_Slot2_补偿Y);
            this.groupBox2.Controls.Add(this.bt_Slot2_Save);
            this.groupBox2.Controls.Add(this.tb_Slot2_补偿Y);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lb_Slot2_当前保存坐标);
            this.groupBox2.Controls.Add(this.lb_Slot2_补偿Z);
            this.groupBox2.Controls.Add(this.lb_Slot2_当前保存补偿);
            this.groupBox2.Controls.Add(this.tb_Slot2_补偿Z);
            this.groupBox2.Controls.Add(this.lb_Slot2_实际取料位置);
            this.groupBox2.Controls.Add(this.lb_Slot2_修改后取料位置);
            this.groupBox2.Controls.Add(this.lb_Slot2_补偿X);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(281, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 255);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工位2";
            // 
            // bt_Slot2_Cancel
            // 
            this.bt_Slot2_Cancel.Location = new System.Drawing.Point(187, 95);
            this.bt_Slot2_Cancel.Name = "bt_Slot2_Cancel";
            this.bt_Slot2_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Slot2_Cancel.TabIndex = 40;
            this.bt_Slot2_Cancel.Text = "取消";
            this.bt_Slot2_Cancel.UseVisualStyleBackColor = true;
            this.bt_Slot2_Cancel.Click += new System.EventHandler(this.bt_Slot2_Cancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "mm";
            // 
            // bt_Slot2_Clear
            // 
            this.bt_Slot2_Clear.Location = new System.Drawing.Point(106, 95);
            this.bt_Slot2_Clear.Name = "bt_Slot2_Clear";
            this.bt_Slot2_Clear.Size = new System.Drawing.Size(75, 23);
            this.bt_Slot2_Clear.TabIndex = 39;
            this.bt_Slot2_Clear.Text = "补偿清零";
            this.bt_Slot2_Clear.UseVisualStyleBackColor = true;
            this.bt_Slot2_Clear.Click += new System.EventHandler(this.bt_Slot2_Clear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "mm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "mm";
            // 
            // tb_Slot2_补偿X
            // 
            this.tb_Slot2_补偿X.Location = new System.Drawing.Point(92, 156);
            this.tb_Slot2_补偿X.Name = "tb_Slot2_补偿X";
            this.tb_Slot2_补偿X.Size = new System.Drawing.Size(100, 21);
            this.tb_Slot2_补偿X.TabIndex = 28;
            // 
            // lb_Slot2_补偿Y
            // 
            this.lb_Slot2_补偿Y.AutoSize = true;
            this.lb_Slot2_补偿Y.Location = new System.Drawing.Point(25, 190);
            this.lb_Slot2_补偿Y.Name = "lb_Slot2_补偿Y";
            this.lb_Slot2_补偿Y.Size = new System.Drawing.Size(59, 12);
            this.lb_Slot2_补偿Y.TabIndex = 38;
            this.lb_Slot2_补偿Y.Text = "修改补偿Y";
            // 
            // bt_Slot2_Save
            // 
            this.bt_Slot2_Save.Location = new System.Drawing.Point(25, 95);
            this.bt_Slot2_Save.Name = "bt_Slot2_Save";
            this.bt_Slot2_Save.Size = new System.Drawing.Size(75, 23);
            this.bt_Slot2_Save.TabIndex = 29;
            this.bt_Slot2_Save.Text = "保存修改";
            this.bt_Slot2_Save.UseVisualStyleBackColor = true;
            this.bt_Slot2_Save.Click += new System.EventHandler(this.bt_Slot2_Save_Click);
            // 
            // tb_Slot2_补偿Y
            // 
            this.tb_Slot2_补偿Y.Location = new System.Drawing.Point(92, 186);
            this.tb_Slot2_补偿Y.Name = "tb_Slot2_补偿Y";
            this.tb_Slot2_补偿Y.Size = new System.Drawing.Size(100, 21);
            this.tb_Slot2_补偿Y.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(-255, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 22;
            this.label15.Text = "修改后取料位置";
            // 
            // lb_Slot2_当前保存坐标
            // 
            this.lb_Slot2_当前保存坐标.AutoSize = true;
            this.lb_Slot2_当前保存坐标.Location = new System.Drawing.Point(25, 20);
            this.lb_Slot2_当前保存坐标.Name = "lb_Slot2_当前保存坐标";
            this.lb_Slot2_当前保存坐标.Size = new System.Drawing.Size(77, 12);
            this.lb_Slot2_当前保存坐标.TabIndex = 30;
            this.lb_Slot2_当前保存坐标.Text = "当前保存坐标";
            // 
            // lb_Slot2_补偿Z
            // 
            this.lb_Slot2_补偿Z.AutoSize = true;
            this.lb_Slot2_补偿Z.Location = new System.Drawing.Point(25, 220);
            this.lb_Slot2_补偿Z.Name = "lb_Slot2_补偿Z";
            this.lb_Slot2_补偿Z.Size = new System.Drawing.Size(59, 12);
            this.lb_Slot2_补偿Z.TabIndex = 36;
            this.lb_Slot2_补偿Z.Text = "修改补偿Z";
            // 
            // lb_Slot2_当前保存补偿
            // 
            this.lb_Slot2_当前保存补偿.AutoSize = true;
            this.lb_Slot2_当前保存补偿.Location = new System.Drawing.Point(25, 45);
            this.lb_Slot2_当前保存补偿.Name = "lb_Slot2_当前保存补偿";
            this.lb_Slot2_当前保存补偿.Size = new System.Drawing.Size(77, 12);
            this.lb_Slot2_当前保存补偿.TabIndex = 31;
            this.lb_Slot2_当前保存补偿.Text = "当前保存补偿";
            // 
            // tb_Slot2_补偿Z
            // 
            this.tb_Slot2_补偿Z.Location = new System.Drawing.Point(92, 216);
            this.tb_Slot2_补偿Z.Name = "tb_Slot2_补偿Z";
            this.tb_Slot2_补偿Z.Size = new System.Drawing.Size(100, 21);
            this.tb_Slot2_补偿Z.TabIndex = 35;
            // 
            // lb_Slot2_实际取料位置
            // 
            this.lb_Slot2_实际取料位置.AutoSize = true;
            this.lb_Slot2_实际取料位置.Location = new System.Drawing.Point(25, 70);
            this.lb_Slot2_实际取料位置.Name = "lb_Slot2_实际取料位置";
            this.lb_Slot2_实际取料位置.Size = new System.Drawing.Size(77, 12);
            this.lb_Slot2_实际取料位置.TabIndex = 32;
            this.lb_Slot2_实际取料位置.Text = "实际取料位置";
            // 
            // lb_Slot2_修改后取料位置
            // 
            this.lb_Slot2_修改后取料位置.AutoSize = true;
            this.lb_Slot2_修改后取料位置.Location = new System.Drawing.Point(25, 135);
            this.lb_Slot2_修改后取料位置.Name = "lb_Slot2_修改后取料位置";
            this.lb_Slot2_修改后取料位置.Size = new System.Drawing.Size(89, 12);
            this.lb_Slot2_修改后取料位置.TabIndex = 34;
            this.lb_Slot2_修改后取料位置.Text = "修改后取料位置";
            // 
            // lb_Slot2_补偿X
            // 
            this.lb_Slot2_补偿X.AutoSize = true;
            this.lb_Slot2_补偿X.Location = new System.Drawing.Point(25, 160);
            this.lb_Slot2_补偿X.Name = "lb_Slot2_补偿X";
            this.lb_Slot2_补偿X.Size = new System.Drawing.Size(59, 12);
            this.lb_Slot2_补偿X.TabIndex = 33;
            this.lb_Slot2_补偿X.Text = "修改补偿X";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mtb_password);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 33);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "密码";
            // 
            // mtb_password
            // 
            this.mtb_password.Location = new System.Drawing.Point(124, 6);
            this.mtb_password.Name = "mtb_password";
            this.mtb_password.PasswordChar = '*';
            this.mtb_password.Size = new System.Drawing.Size(243, 21);
            this.mtb_password.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Slot1_Cancel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bt_Slot1_Clear);
            this.groupBox1.Controls.Add(this.lb_Slot1_补偿Y);
            this.groupBox1.Controls.Add(this.tb_Slot1_补偿Y);
            this.groupBox1.Controls.Add(this.lb_Slot1_补偿Z);
            this.groupBox1.Controls.Add(this.tb_Slot1_补偿Z);
            this.groupBox1.Controls.Add(this.lb_Slot1_修改后取料位置);
            this.groupBox1.Controls.Add(this.lb_Slot1_补偿X);
            this.groupBox1.Controls.Add(this.lb_Slot1_实际取料位置);
            this.groupBox1.Controls.Add(this.lb_Slot1_当前保存补偿);
            this.groupBox1.Controls.Add(this.lb_Slot1_当前保存坐标);
            this.groupBox1.Controls.Add(this.bt_Slot1_Save);
            this.groupBox1.Controls.Add(this.tb_Slot1_补偿X);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 255);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工位1";
            // 
            // bt_Slot1_Cancel
            // 
            this.bt_Slot1_Cancel.Location = new System.Drawing.Point(187, 95);
            this.bt_Slot1_Cancel.Name = "bt_Slot1_Cancel";
            this.bt_Slot1_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Slot1_Cancel.TabIndex = 31;
            this.bt_Slot1_Cancel.Text = "取消";
            this.bt_Slot1_Cancel.UseVisualStyleBackColor = true;
            this.bt_Slot1_Cancel.Click += new System.EventHandler(this.bt_Slot1_Cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "mm";
            // 
            // bt_Slot1_Clear
            // 
            this.bt_Slot1_Clear.Location = new System.Drawing.Point(106, 95);
            this.bt_Slot1_Clear.Name = "bt_Slot1_Clear";
            this.bt_Slot1_Clear.Size = new System.Drawing.Size(75, 23);
            this.bt_Slot1_Clear.TabIndex = 27;
            this.bt_Slot1_Clear.Text = "补偿清零";
            this.bt_Slot1_Clear.UseVisualStyleBackColor = true;
            this.bt_Slot1_Clear.Click += new System.EventHandler(this.bt_Slot1_Clear_Click);
            // 
            // lb_Slot1_补偿Y
            // 
            this.lb_Slot1_补偿Y.AutoSize = true;
            this.lb_Slot1_补偿Y.Location = new System.Drawing.Point(25, 190);
            this.lb_Slot1_补偿Y.Name = "lb_Slot1_补偿Y";
            this.lb_Slot1_补偿Y.Size = new System.Drawing.Size(59, 12);
            this.lb_Slot1_补偿Y.TabIndex = 26;
            this.lb_Slot1_补偿Y.Text = "修改补偿Y";
            // 
            // tb_Slot1_补偿Y
            // 
            this.tb_Slot1_补偿Y.Location = new System.Drawing.Point(91, 186);
            this.tb_Slot1_补偿Y.Name = "tb_Slot1_补偿Y";
            this.tb_Slot1_补偿Y.Size = new System.Drawing.Size(100, 21);
            this.tb_Slot1_补偿Y.TabIndex = 25;
            // 
            // lb_Slot1_补偿Z
            // 
            this.lb_Slot1_补偿Z.AutoSize = true;
            this.lb_Slot1_补偿Z.Location = new System.Drawing.Point(25, 220);
            this.lb_Slot1_补偿Z.Name = "lb_Slot1_补偿Z";
            this.lb_Slot1_补偿Z.Size = new System.Drawing.Size(59, 12);
            this.lb_Slot1_补偿Z.TabIndex = 24;
            this.lb_Slot1_补偿Z.Text = "修改补偿Z";
            // 
            // tb_Slot1_补偿Z
            // 
            this.tb_Slot1_补偿Z.Location = new System.Drawing.Point(91, 216);
            this.tb_Slot1_补偿Z.Name = "tb_Slot1_补偿Z";
            this.tb_Slot1_补偿Z.Size = new System.Drawing.Size(100, 21);
            this.tb_Slot1_补偿Z.TabIndex = 23;
            // 
            // lb_Slot1_修改后取料位置
            // 
            this.lb_Slot1_修改后取料位置.AutoSize = true;
            this.lb_Slot1_修改后取料位置.Location = new System.Drawing.Point(25, 135);
            this.lb_Slot1_修改后取料位置.Name = "lb_Slot1_修改后取料位置";
            this.lb_Slot1_修改后取料位置.Size = new System.Drawing.Size(89, 12);
            this.lb_Slot1_修改后取料位置.TabIndex = 22;
            this.lb_Slot1_修改后取料位置.Text = "修改后取料位置";
            // 
            // lb_Slot1_补偿X
            // 
            this.lb_Slot1_补偿X.AutoSize = true;
            this.lb_Slot1_补偿X.Location = new System.Drawing.Point(25, 160);
            this.lb_Slot1_补偿X.Name = "lb_Slot1_补偿X";
            this.lb_Slot1_补偿X.Size = new System.Drawing.Size(59, 12);
            this.lb_Slot1_补偿X.TabIndex = 21;
            this.lb_Slot1_补偿X.Text = "修改补偿X";
            // 
            // lb_Slot1_实际取料位置
            // 
            this.lb_Slot1_实际取料位置.AutoSize = true;
            this.lb_Slot1_实际取料位置.Location = new System.Drawing.Point(25, 70);
            this.lb_Slot1_实际取料位置.Name = "lb_Slot1_实际取料位置";
            this.lb_Slot1_实际取料位置.Size = new System.Drawing.Size(77, 12);
            this.lb_Slot1_实际取料位置.TabIndex = 20;
            this.lb_Slot1_实际取料位置.Text = "实际取料位置";
            // 
            // lb_Slot1_当前保存补偿
            // 
            this.lb_Slot1_当前保存补偿.AutoSize = true;
            this.lb_Slot1_当前保存补偿.Location = new System.Drawing.Point(25, 45);
            this.lb_Slot1_当前保存补偿.Name = "lb_Slot1_当前保存补偿";
            this.lb_Slot1_当前保存补偿.Size = new System.Drawing.Size(77, 12);
            this.lb_Slot1_当前保存补偿.TabIndex = 19;
            this.lb_Slot1_当前保存补偿.Text = "当前保存补偿";
            // 
            // lb_Slot1_当前保存坐标
            // 
            this.lb_Slot1_当前保存坐标.AutoSize = true;
            this.lb_Slot1_当前保存坐标.Location = new System.Drawing.Point(25, 20);
            this.lb_Slot1_当前保存坐标.Name = "lb_Slot1_当前保存坐标";
            this.lb_Slot1_当前保存坐标.Size = new System.Drawing.Size(77, 12);
            this.lb_Slot1_当前保存坐标.TabIndex = 16;
            this.lb_Slot1_当前保存坐标.Text = "当前保存坐标";
            // 
            // bt_Slot1_Save
            // 
            this.bt_Slot1_Save.Location = new System.Drawing.Point(25, 95);
            this.bt_Slot1_Save.Name = "bt_Slot1_Save";
            this.bt_Slot1_Save.Size = new System.Drawing.Size(75, 23);
            this.bt_Slot1_Save.TabIndex = 9;
            this.bt_Slot1_Save.Text = "保存修改";
            this.bt_Slot1_Save.UseVisualStyleBackColor = true;
            this.bt_Slot1_Save.Click += new System.EventHandler(this.bt_Slot1_Save_Click);
            // 
            // tb_Slot1_补偿X
            // 
            this.tb_Slot1_补偿X.Location = new System.Drawing.Point(91, 156);
            this.tb_Slot1_补偿X.Name = "tb_Slot1_补偿X";
            this.tb_Slot1_补偿X.Size = new System.Drawing.Size(100, 21);
            this.tb_Slot1_补偿X.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ManualChangeCompesationPickupPosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ManualChangeCompesationPickupPosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "补偿取料点位";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualTestFrm_FormClosing);
            this.Load += new System.EventHandler(this.ManualChangeCompesationPickupPosForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void ManualChangeCompesationPickupPosForm_Load(object sender, EventArgs e)
        {
            IsRuning = true;

            lb_Slot1_当前保存坐标.Text = "当前保存坐标:" + _slot1_pickUp_x.ToString("0.000") + ","
                + _slot1_pickUp_y.ToString("0.000") + ","
                + _slot1_pickUp_z.ToString("0.000");
            lb_Slot1_当前保存补偿.Text = "当前保存补偿:" + _slot1_compensation_x.ToString("0.000") + ","
                + _slot1_compensation_y.ToString("0.000") + ","
                + _slot1_compensation_z.ToString("0.000");
            lb_Slot1_实际取料位置.Text = "实际取料位置:" + (_slot1_pickUp_x + _slot1_compensation_x).ToString("0.000") + ","
                + (_slot1_pickUp_y + _slot1_compensation_y).ToString("0.000") + ","
                + (_slot1_pickUp_z + _slot1_compensation_z).ToString("0.000");

            tb_Slot1_补偿X.Text = _slot1_compensation_x.ToString();
            tb_Slot1_补偿Y.Text = _slot1_compensation_y.ToString();
            tb_Slot1_补偿Z.Text = _slot1_compensation_z.ToString();


            lb_Slot2_当前保存坐标.Text = "当前保存坐标:" + _slot2_pickUp_x.ToString("0.000") + ","
                + _slot2_pickUp_y.ToString("0.000") + ","
                + _slot2_pickUp_z.ToString("0.000");
            lb_Slot2_当前保存补偿.Text = "当前保存补偿:" + _slot2_compensation_x.ToString("0.000") + ","
                + _slot2_compensation_y.ToString("0.000") + ","
                + _slot2_compensation_z.ToString("0.000");
            lb_Slot2_实际取料位置.Text = "实际取料位置:" + (_slot2_pickUp_x + _slot2_compensation_x).ToString("0.000") + ","
                + (_slot2_pickUp_y + _slot2_compensation_y).ToString("0.000") + ","
                + (_slot2_pickUp_z + _slot2_compensation_z).ToString("0.000");

            tb_Slot2_补偿X.Text = _slot2_compensation_x.ToString();
            tb_Slot2_补偿Y.Text = _slot2_compensation_y.ToString();
            tb_Slot2_补偿Z.Text = _slot2_compensation_z.ToString();

            mtb_password.Text = "";
        }

        private bool CheckInput(TextBox textBox, out double val, string textBoxName, double compensation)
        {
            val = 0;
            if (string.IsNullOrWhiteSpace(textBox.Text) || !double.TryParse(textBox.Text, out val))
            {
                MessageBox.Show("工位1的" + textBoxName + "为空或无法识别为数字，请重新输入");
                textBox.Text = compensation.ToString();
                return false;
            }

            if (Math.Abs(compensation - val) > 1)
            {
                MessageBox.Show("工位1的" + textBoxName + "与原补偿值偏差超过1mm，请重新输入");
                textBox.Text = compensation.ToString();
                return false;
            }

            return true;
        }


        private void bt_Slot1_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtb_password.Text) || mtb_password.Text != "LEADchina")
            {
                MessageBox.Show("请输入正确的密码！");
                return;
            }
            mtb_password.Text = "";

            try
            {
                bt_Slot1_Save.Enabled = false;
                bt_Slot1_Clear.Enabled = false;
                bt_Slot1_Cancel.Enabled = false;

                double x = 0;
                double y = 0;
                double z = 0;

                if (!CheckInput(tb_Slot1_补偿X, out x, "修改补偿X", _slot1_compensation_x))
                {
                    return;
                }
                if (!CheckInput(tb_Slot1_补偿Y, out y, "修改补偿Y", _slot1_compensation_y))
                {
                    return;
                }
                if (!CheckInput(tb_Slot1_补偿Z, out z, "修改补偿Z", _slot1_compensation_z))
                {
                    return;
                }

                DialogResult result = MessageBox.Show("是否修改", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    ChangeCompesation_slot1?.Invoke("工位1", x, y, z);
                    lb_Slot1_修改后取料位置.Text = "修改后取料位置:" + (_slot1_pickUp_x + x).ToString("0.000") + ","
                    + (_slot1_pickUp_y + y).ToString("0.000") + ","
                    + (_slot1_pickUp_z + z).ToString("0.000");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                bt_Slot1_Save.Enabled = true;
                bt_Slot1_Clear.Enabled = true;
                bt_Slot1_Cancel.Enabled = true;
            }
        }

        private void bt_Slot1_Clear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtb_password.Text) || mtb_password.Text != "LEADchina")
            {
                MessageBox.Show("请输入正确的密码！");
                return;
            }
            mtb_password.Text = "";

            try
            {
                bt_Slot1_Save.Enabled = false;
                bt_Slot1_Clear.Enabled = false;
                bt_Slot1_Cancel.Enabled = false;

                double x = 0;
                double y = 0;
                double z = 0;
                tb_Slot1_补偿X.Text = "0";
                tb_Slot1_补偿Y.Text = "0";
                tb_Slot1_补偿Z.Text = "0";

                if (!CheckInput(tb_Slot1_补偿X, out x, "修改补偿X", _slot1_compensation_x))
                {
                    return;
                }
                if (!CheckInput(tb_Slot1_补偿Y, out y, "修改补偿Y", _slot1_compensation_y))
                {
                    return;
                }
                if (!CheckInput(tb_Slot1_补偿Z, out z, "修改补偿Z", _slot1_compensation_z))
                {
                    return;
                }

                DialogResult result = MessageBox.Show("是否修改", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    ChangeCompesation_slot1?.Invoke("工位1", x, y, z);
                    lb_Slot1_修改后取料位置.Text = "修改后取料位置:" + (_slot1_pickUp_x + x).ToString("0.000") + ","
                    + (_slot1_pickUp_y + y).ToString("0.000") + ","
                    + (_slot1_pickUp_z + z).ToString("0.000");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                bt_Slot1_Save.Enabled = true;
                bt_Slot1_Clear.Enabled = true;
                bt_Slot1_Cancel.Enabled = true;
            }
        }

        private void bt_Slot1_Cancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtb_password.Text) || mtb_password.Text != "LEADchina")
            {
                MessageBox.Show("请输入正确的密码！");
                return;
            }
            mtb_password.Text = "";

            try
            {
                bt_Slot1_Save.Enabled = false;
                bt_Slot1_Clear.Enabled = false;
                bt_Slot1_Cancel.Enabled = false;

                double x = 0;
                double y = 0;
                double z = 0;
                tb_Slot1_补偿X.Text = _slot1_compensation_x.ToString();
                tb_Slot1_补偿Y.Text = _slot1_compensation_y.ToString();
                tb_Slot1_补偿Z.Text = _slot1_compensation_z.ToString();

                if (!CheckInput(tb_Slot1_补偿X, out x, "修改补偿X", _slot1_compensation_x))
                {
                    return;
                }
                if (!CheckInput(tb_Slot1_补偿Y, out y, "修改补偿Y", _slot1_compensation_y))
                {
                    return;
                }
                if (!CheckInput(tb_Slot1_补偿Z, out z, "修改补偿Z", _slot1_compensation_z))
                {
                    return;
                }

                DialogResult result = MessageBox.Show("是否修改", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    ChangeCompesation_slot1?.Invoke("工位1", x, y, z);
                    lb_Slot1_修改后取料位置.Text = "修改后取料位置:" + (_slot1_pickUp_x + x).ToString("0.000") + ","
                    + (_slot1_pickUp_y + y).ToString("0.000") + ","
                    + (_slot1_pickUp_z + z).ToString("0.000");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                bt_Slot1_Save.Enabled = true;
                bt_Slot1_Clear.Enabled = true;
                bt_Slot1_Cancel.Enabled = true;
            }
        }

        private void bt_Slot2_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtb_password.Text) || mtb_password.Text != "LEADchina")
            {
                MessageBox.Show("请输入正确的密码！");
                return;
            }
            mtb_password.Text = "";

            try
            {
                bt_Slot2_Save.Enabled = false;
                bt_Slot2_Clear.Enabled = false;
                bt_Slot2_Cancel.Enabled = false;

                double x = 0;
                double y = 0;
                double z = 0;

                if (!CheckInput(tb_Slot2_补偿X, out x, "修改补偿X", _slot2_compensation_x))
                {
                    return;
                }
                if (!CheckInput(tb_Slot2_补偿Y, out y, "修改补偿Y", _slot2_compensation_y))
                {
                    return;
                }
                if (!CheckInput(tb_Slot2_补偿Z, out z, "修改补偿Z", _slot2_compensation_z))
                {
                    return;
                }

                DialogResult result = MessageBox.Show("是否修改", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    ChangeCompesation_slot2?.Invoke("工位2", x, y, z);
                    lb_Slot2_修改后取料位置.Text = "修改后取料位置:" + (_slot2_pickUp_x + x).ToString("0.000") + ","
                    + (_slot2_pickUp_y + y).ToString("0.000") + ","
                    + (_slot2_pickUp_z + z).ToString("0.000");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                bt_Slot2_Save.Enabled = true;
                bt_Slot2_Clear.Enabled = true;
                bt_Slot2_Cancel.Enabled = true;
            }
        }

        private void bt_Slot2_Clear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtb_password.Text) || mtb_password.Text != "LEADchina")
            {
                MessageBox.Show("请输入正确的密码！");
                return;
            }
            mtb_password.Text = "";

            try
            {
                bt_Slot2_Save.Enabled = false;
                bt_Slot2_Clear.Enabled = false;
                bt_Slot2_Cancel.Enabled = false;

                double x = 0;
                double y = 0;
                double z = 0;
                tb_Slot2_补偿X.Text = "0";
                tb_Slot2_补偿Y.Text = "0";
                tb_Slot2_补偿Z.Text = "0";

                if (!CheckInput(tb_Slot2_补偿X, out x, "修改补偿X", _slot2_compensation_x))
                {
                    return;
                }
                if (!CheckInput(tb_Slot2_补偿Y, out y, "修改补偿Y", _slot2_compensation_y))
                {
                    return;
                }
                if (!CheckInput(tb_Slot2_补偿Z, out z, "修改补偿Z", _slot2_compensation_z))
                {
                    return;
                }

                DialogResult result = MessageBox.Show("是否修改", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    ChangeCompesation_slot2?.Invoke("工位2", x, y, z);
                    lb_Slot2_修改后取料位置.Text = "修改后取料位置:" + (_slot2_pickUp_x + x).ToString("0.000") + ","
                    + (_slot2_pickUp_y + y).ToString("0.000") + ","
                    + (_slot2_pickUp_z + z).ToString("0.000");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                bt_Slot2_Save.Enabled = true;
                bt_Slot2_Clear.Enabled = true;
                bt_Slot2_Cancel.Enabled = true;
            }
        }

        private void bt_Slot2_Cancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtb_password.Text) || mtb_password.Text != "LEADchina")
            {
                MessageBox.Show("请输入正确的密码！");
                return;
            }
            mtb_password.Text = "";

            try
            {
                bt_Slot2_Save.Enabled = false;
                bt_Slot2_Clear.Enabled = false;
                bt_Slot2_Cancel.Enabled = false;

                double x = 0;
                double y = 0;
                double z = 0;
                tb_Slot2_补偿X.Text = _slot2_compensation_x.ToString();
                tb_Slot2_补偿Y.Text = _slot2_compensation_y.ToString();
                tb_Slot2_补偿Z.Text = _slot2_compensation_z.ToString();

                if (!CheckInput(tb_Slot2_补偿X, out x, "修改补偿X", _slot2_compensation_x))
                {
                    return;
                }
                if (!CheckInput(tb_Slot2_补偿Y, out y, "修改补偿Y", _slot2_compensation_y))
                {
                    return;
                }
                if (!CheckInput(tb_Slot2_补偿Z, out z, "修改补偿Z", _slot2_compensation_z))
                {
                    return;
                }

                DialogResult result = MessageBox.Show("是否修改", "提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    ChangeCompesation_slot2?.Invoke("工位2", x, y, z);
                    lb_Slot2_修改后取料位置.Text = "修改后取料位置:" + (_slot2_pickUp_x + x).ToString("0.000") + ","
                    + (_slot2_pickUp_y + y).ToString("0.000") + ","
                    + (_slot2_pickUp_z + z).ToString("0.000");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                bt_Slot2_Save.Enabled = true;
                bt_Slot2_Clear.Enabled = true;
                bt_Slot2_Cancel.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_Slot1_当前保存坐标.Text = "当前保存坐标:" + _slot1_pickUp_x.ToString("0.000") + ","
    + _slot1_pickUp_y.ToString("0.000") + ","
    + _slot1_pickUp_z.ToString("0.000");
            lb_Slot1_当前保存补偿.Text = "当前保存补偿:" + _slot1_compensation_x.ToString("0.000") + ","
                + _slot1_compensation_y.ToString("0.000") + ","
                + _slot1_compensation_z.ToString("0.000");
            lb_Slot1_实际取料位置.Text = "实际取料位置:" + (_slot1_pickUp_x + _slot1_compensation_x).ToString("0.000") + ","
                + (_slot1_pickUp_y + _slot1_compensation_y).ToString("0.000") + ","
                + (_slot1_pickUp_z + _slot1_compensation_z).ToString("0.000");

            lb_Slot2_当前保存坐标.Text = "当前保存坐标:" + _slot2_pickUp_x.ToString("0.000") + ","
                + _slot2_pickUp_y.ToString("0.000") + ","
                + _slot2_pickUp_z.ToString("0.000");
            lb_Slot2_当前保存补偿.Text = "当前保存补偿:" + _slot2_compensation_x.ToString("0.000") + ","
                + _slot2_compensation_y.ToString("0.000") + ","
                + _slot2_compensation_z.ToString("0.000");
            lb_Slot2_实际取料位置.Text = "实际取料位置:" + (_slot2_pickUp_x + _slot2_compensation_x).ToString("0.000") + ","
                + (_slot2_pickUp_y + _slot2_compensation_y).ToString("0.000") + ","
                + (_slot2_pickUp_z + _slot2_compensation_z).ToString("0.000");
        }
    }
}
