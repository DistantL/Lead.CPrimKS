using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.EleDO
{
    partial class DebugUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            this.panel2 = new Panel();
            this.tBoxName = new TextBox();
            this.lbName = new Label();
            this.btnReSet = new Button();
            this.btnSet = new Button();
            this.tmrUpdateLight = new Timer(this.components);
            this.textBox1 = new TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tBoxName);
            this.panel2.Controls.Add(this.lbName);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Margin = new Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(179, 33);
            this.panel2.TabIndex = 8;
            // 
            // tBoxName
            // 
            this.tBoxName.Location = new Point(79, 3);
            this.tBoxName.Margin = new Padding(3, 4, 3, 4);
            this.tBoxName.Multiline = true;
            this.tBoxName.Name = "tBoxName";
            this.tBoxName.ReadOnly = true;
            this.tBoxName.Size = new Size(95, 25);
            this.tBoxName.TabIndex = 19;
            this.tBoxName.TextAlign = HorizontalAlignment.Center;
            // 
            // lbName
            // 
            this.lbName.BackColor = SystemColors.Highlight;
            this.lbName.BorderStyle = BorderStyle.FixedSingle;
            this.lbName.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.lbName.ForeColor = SystemColors.ButtonFace;
            this.lbName.Location = new Point(2, 3);
            this.lbName.Name = "lbName";
            this.lbName.Size = new Size(73, 25);
            this.lbName.TabIndex = 18;
            this.lbName.Text = "Name";
            this.lbName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReSet
            // 
            this.btnReSet.Location = new Point(3, 41);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new Size(32, 28);
            this.btnReSet.TabIndex = 9;
            this.btnReSet.Text = "R";
            this.btnReSet.UseVisualStyleBackColor = true;
            this.btnReSet.Click += new EventHandler(this.btnReSet_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new Point(144, 41);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new Size(32, 28);
            this.btnSet.TabIndex = 9;
            this.btnSet.Text = "S";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new EventHandler(this.btnSet_Click);
            // 
            // tmrUpdateLight
            // 
            this.tmrUpdateLight.Interval = 50;
            this.tmrUpdateLight.Tick += new EventHandler(this.tmrLightUpdate_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new Point(38, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(100, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // DebugUI
            // 
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnReSet);
            this.Controls.Add(this.panel2);
            this.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new Padding(3, 4, 3, 4);
            this.Name = "DebugUI";
            this.Size = new Size(179, 74);
            this.Load += new EventHandler(this.DebugUI_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel2;
        private Button btnReSet;
        private Button btnSet;
        public TextBox tBoxName;
        private Label lbName;
        private Timer tmrUpdateLight;
        private TextBox textBox1;
    }
}
