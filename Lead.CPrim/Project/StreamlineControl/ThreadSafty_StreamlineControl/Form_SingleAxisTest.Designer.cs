
namespace ThreadSafty_StreamlineControl
{
    partial class Form_SingleAxisTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lb_CurrentTestCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_TestCount = new System.Windows.Forms.TextBox();
            this.lb_TestCount = new System.Windows.Forms.Label();
            this.lb_AxisName = new System.Windows.Forms.Label();
            this.lb_CurrentPauseTime = new System.Windows.Forms.Label();
            this.lb_CurrentSpeed = new System.Windows.Forms.Label();
            this.lb_CurrentPosition = new System.Windows.Forms.Label();
            this.tb_Pos2PauseTime = new System.Windows.Forms.TextBox();
            this.tb_Pos2 = new System.Windows.Forms.TextBox();
            this.tb_Speed = new System.Windows.Forms.TextBox();
            this.tb_Pos1PauseTime = new System.Windows.Forms.TextBox();
            this.tb_Pos1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.bt_Start = new System.Windows.Forms.Button();
            this.lb_Speed = new System.Windows.Forms.Label();
            this.lb_Pos2PauseTime = new System.Windows.Forms.Label();
            this.lb_Pos1PauseTime = new System.Windows.Forms.Label();
            this.lb_Pos2 = new System.Windows.Forms.Label();
            this.lb_Pos1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tb_cmd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tb_cmd);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lb_CurrentTestCount);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.tb_TestCount);
            this.splitContainer1.Panel2.Controls.Add(this.lb_TestCount);
            this.splitContainer1.Panel2.Controls.Add(this.lb_AxisName);
            this.splitContainer1.Panel2.Controls.Add(this.lb_CurrentPauseTime);
            this.splitContainer1.Panel2.Controls.Add(this.lb_CurrentSpeed);
            this.splitContainer1.Panel2.Controls.Add(this.lb_CurrentPosition);
            this.splitContainer1.Panel2.Controls.Add(this.tb_Pos2PauseTime);
            this.splitContainer1.Panel2.Controls.Add(this.tb_Pos2);
            this.splitContainer1.Panel2.Controls.Add(this.tb_Speed);
            this.splitContainer1.Panel2.Controls.Add(this.tb_Pos1PauseTime);
            this.splitContainer1.Panel2.Controls.Add(this.tb_Pos1);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.bt_Stop);
            this.splitContainer1.Panel2.Controls.Add(this.bt_Start);
            this.splitContainer1.Panel2.Controls.Add(this.lb_Speed);
            this.splitContainer1.Panel2.Controls.Add(this.lb_Pos2PauseTime);
            this.splitContainer1.Panel2.Controls.Add(this.lb_Pos1PauseTime);
            this.splitContainer1.Panel2.Controls.Add(this.lb_Pos2);
            this.splitContainer1.Panel2.Controls.Add(this.lb_Pos1);
            this.splitContainer1.Size = new System.Drawing.Size(600, 389);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(199, 389);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // lb_CurrentTestCount
            // 
            this.lb_CurrentTestCount.AutoSize = true;
            this.lb_CurrentTestCount.Location = new System.Drawing.Point(160, 310);
            this.lb_CurrentTestCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CurrentTestCount.Name = "lb_CurrentTestCount";
            this.lb_CurrentTestCount.Size = new System.Drawing.Size(53, 12);
            this.lb_CurrentTestCount.TabIndex = 24;
            this.lb_CurrentTestCount.Text = "当前次数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 286);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "当前次数";
            // 
            // tb_TestCount
            // 
            this.tb_TestCount.Location = new System.Drawing.Point(176, 116);
            this.tb_TestCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_TestCount.Name = "tb_TestCount";
            this.tb_TestCount.Size = new System.Drawing.Size(76, 21);
            this.tb_TestCount.TabIndex = 22;
            this.tb_TestCount.Text = "10";
            // 
            // lb_TestCount
            // 
            this.lb_TestCount.AutoSize = true;
            this.lb_TestCount.Location = new System.Drawing.Point(200, 99);
            this.lb_TestCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_TestCount.Name = "lb_TestCount";
            this.lb_TestCount.Size = new System.Drawing.Size(29, 12);
            this.lb_TestCount.TabIndex = 21;
            this.lb_TestCount.Text = "次数";
            // 
            // lb_AxisName
            // 
            this.lb_AxisName.AutoSize = true;
            this.lb_AxisName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_AxisName.Location = new System.Drawing.Point(41, 7);
            this.lb_AxisName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_AxisName.Name = "lb_AxisName";
            this.lb_AxisName.Size = new System.Drawing.Size(72, 16);
            this.lb_AxisName.TabIndex = 19;
            this.lb_AxisName.Text = "当前轴名";
            // 
            // lb_CurrentPauseTime
            // 
            this.lb_CurrentPauseTime.AutoSize = true;
            this.lb_CurrentPauseTime.Location = new System.Drawing.Point(272, 254);
            this.lb_CurrentPauseTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CurrentPauseTime.Name = "lb_CurrentPauseTime";
            this.lb_CurrentPauseTime.Size = new System.Drawing.Size(53, 12);
            this.lb_CurrentPauseTime.TabIndex = 18;
            this.lb_CurrentPauseTime.Text = "等待时间";
            // 
            // lb_CurrentSpeed
            // 
            this.lb_CurrentSpeed.AutoSize = true;
            this.lb_CurrentSpeed.Location = new System.Drawing.Point(160, 254);
            this.lb_CurrentSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CurrentSpeed.Name = "lb_CurrentSpeed";
            this.lb_CurrentSpeed.Size = new System.Drawing.Size(53, 12);
            this.lb_CurrentSpeed.TabIndex = 17;
            this.lb_CurrentSpeed.Text = "当前速度";
            // 
            // lb_CurrentPosition
            // 
            this.lb_CurrentPosition.AutoSize = true;
            this.lb_CurrentPosition.Location = new System.Drawing.Point(41, 254);
            this.lb_CurrentPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CurrentPosition.Name = "lb_CurrentPosition";
            this.lb_CurrentPosition.Size = new System.Drawing.Size(53, 12);
            this.lb_CurrentPosition.TabIndex = 16;
            this.lb_CurrentPosition.Text = "当前位置";
            // 
            // tb_Pos2PauseTime
            // 
            this.tb_Pos2PauseTime.Location = new System.Drawing.Point(272, 116);
            this.tb_Pos2PauseTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Pos2PauseTime.Name = "tb_Pos2PauseTime";
            this.tb_Pos2PauseTime.Size = new System.Drawing.Size(76, 21);
            this.tb_Pos2PauseTime.TabIndex = 15;
            this.tb_Pos2PauseTime.Text = "5000";
            // 
            // tb_Pos2
            // 
            this.tb_Pos2.Location = new System.Drawing.Point(272, 61);
            this.tb_Pos2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Pos2.Name = "tb_Pos2";
            this.tb_Pos2.Size = new System.Drawing.Size(76, 21);
            this.tb_Pos2.TabIndex = 14;
            this.tb_Pos2.Text = "1";
            // 
            // tb_Speed
            // 
            this.tb_Speed.Location = new System.Drawing.Point(176, 61);
            this.tb_Speed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Speed.Name = "tb_Speed";
            this.tb_Speed.Size = new System.Drawing.Size(76, 21);
            this.tb_Speed.TabIndex = 13;
            this.tb_Speed.Text = "10";
            // 
            // tb_Pos1PauseTime
            // 
            this.tb_Pos1PauseTime.Location = new System.Drawing.Point(41, 116);
            this.tb_Pos1PauseTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Pos1PauseTime.Name = "tb_Pos1PauseTime";
            this.tb_Pos1PauseTime.Size = new System.Drawing.Size(76, 21);
            this.tb_Pos1PauseTime.TabIndex = 12;
            this.tb_Pos1PauseTime.Text = "5000";
            // 
            // tb_Pos1
            // 
            this.tb_Pos1.Location = new System.Drawing.Point(41, 61);
            this.tb_Pos1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Pos1.Name = "tb_Pos1";
            this.tb_Pos1.Size = new System.Drawing.Size(76, 21);
            this.tb_Pos1.TabIndex = 11;
            this.tb_Pos1.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 230);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "等待时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(160, 230);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "当前速度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 230);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "当前位置";
            // 
            // bt_Stop
            // 
            this.bt_Stop.Location = new System.Drawing.Point(272, 162);
            this.bt_Stop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(56, 40);
            this.bt_Stop.TabIndex = 6;
            this.bt_Stop.Text = "停止";
            this.bt_Stop.UseVisualStyleBackColor = true;
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click);
            // 
            // bt_Start
            // 
            this.bt_Start.Location = new System.Drawing.Point(41, 162);
            this.bt_Start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(56, 40);
            this.bt_Start.TabIndex = 5;
            this.bt_Start.Text = "开始";
            this.bt_Start.UseVisualStyleBackColor = true;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // lb_Speed
            // 
            this.lb_Speed.AutoSize = true;
            this.lb_Speed.Location = new System.Drawing.Point(200, 45);
            this.lb_Speed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Speed.Name = "lb_Speed";
            this.lb_Speed.Size = new System.Drawing.Size(29, 12);
            this.lb_Speed.TabIndex = 4;
            this.lb_Speed.Text = "速度";
            // 
            // lb_Pos2PauseTime
            // 
            this.lb_Pos2PauseTime.AutoSize = true;
            this.lb_Pos2PauseTime.Location = new System.Drawing.Point(272, 99);
            this.lb_Pos2PauseTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Pos2PauseTime.Name = "lb_Pos2PauseTime";
            this.lb_Pos2PauseTime.Size = new System.Drawing.Size(119, 12);
            this.lb_Pos2PauseTime.TabIndex = 3;
            this.lb_Pos2PauseTime.Text = "位置点2停留时间(ms)";
            // 
            // lb_Pos1PauseTime
            // 
            this.lb_Pos1PauseTime.AutoSize = true;
            this.lb_Pos1PauseTime.Location = new System.Drawing.Point(41, 99);
            this.lb_Pos1PauseTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Pos1PauseTime.Name = "lb_Pos1PauseTime";
            this.lb_Pos1PauseTime.Size = new System.Drawing.Size(119, 12);
            this.lb_Pos1PauseTime.TabIndex = 2;
            this.lb_Pos1PauseTime.Text = "位置点1停留时间(ms)";
            // 
            // lb_Pos2
            // 
            this.lb_Pos2.AutoSize = true;
            this.lb_Pos2.Location = new System.Drawing.Point(272, 45);
            this.lb_Pos2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Pos2.Name = "lb_Pos2";
            this.lb_Pos2.Size = new System.Drawing.Size(47, 12);
            this.lb_Pos2.TabIndex = 1;
            this.lb_Pos2.Text = "位置点2";
            // 
            // lb_Pos1
            // 
            this.lb_Pos1.AutoSize = true;
            this.lb_Pos1.Location = new System.Drawing.Point(41, 45);
            this.lb_Pos1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Pos1.Name = "lb_Pos1";
            this.lb_Pos1.Size = new System.Drawing.Size(47, 12);
            this.lb_Pos1.TabIndex = 0;
            this.lb_Pos1.Text = "位置点1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tb_cmd
            // 
            this.tb_cmd.Location = new System.Drawing.Point(41, 357);
            this.tb_cmd.Margin = new System.Windows.Forms.Padding(2);
            this.tb_cmd.Name = "tb_cmd";
            this.tb_cmd.Size = new System.Drawing.Size(307, 21);
            this.tb_cmd.TabIndex = 26;
            this.tb_cmd.Text = "Acq,1,1,1,0,0,sn,0,12,12,12;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 340);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "位置点2 触发指令";
            // 
            // Form_SingleAxisTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 389);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_SingleAxisTest";
            this.Text = "单轴测试";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lb_Speed;
        private System.Windows.Forms.Label lb_Pos2PauseTime;
        private System.Windows.Forms.Label lb_Pos1PauseTime;
        private System.Windows.Forms.Label lb_Pos2;
        private System.Windows.Forms.Label lb_Pos1;
        private System.Windows.Forms.Label lb_CurrentPauseTime;
        private System.Windows.Forms.Label lb_CurrentSpeed;
        private System.Windows.Forms.Label lb_CurrentPosition;
        private System.Windows.Forms.TextBox tb_Pos2PauseTime;
        private System.Windows.Forms.TextBox tb_Pos2;
        private System.Windows.Forms.TextBox tb_Speed;
        private System.Windows.Forms.TextBox tb_Pos1PauseTime;
        private System.Windows.Forms.TextBox tb_Pos1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_AxisName;
        private System.Windows.Forms.Label lb_CurrentTestCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_TestCount;
        private System.Windows.Forms.Label lb_TestCount;
        private System.Windows.Forms.TextBox tb_cmd;
        private System.Windows.Forms.Label label1;
    }
}