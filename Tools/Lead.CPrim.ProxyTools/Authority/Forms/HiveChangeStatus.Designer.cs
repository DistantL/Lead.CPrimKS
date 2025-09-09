
namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class HiveChangeStatus
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
            this.btnRun = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnDT = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnPlanDT = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnIdle = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnEngineering = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.uiLine2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.FillColor = System.Drawing.Color.Transparent;
            this.btnRun.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnRun.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnRun.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnRun.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRun.Location = new System.Drawing.Point(29, 60);
            this.btnRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRun.Name = "btnRun";
            this.btnRun.Radius = 10;
            this.btnRun.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnRun.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnRun.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnRun.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnRun.Size = new System.Drawing.Size(220, 35);
            this.btnRun.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Running";
            this.btnRun.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRun.Click += new System.EventHandler(this.Audio_BtnRun_Click);
            // 
            // btnDT
            // 
            this.btnDT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDT.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDT.Location = new System.Drawing.Point(29, 280);
            this.btnDT.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDT.Name = "btnDT";
            this.btnDT.Size = new System.Drawing.Size(220, 35);
            this.btnDT.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnDT.TabIndex = 1;
            this.btnDT.Text = "Manually Downtime";
            this.btnDT.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDT.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDT.Click += new System.EventHandler(this.Audio_BtnDT_Click);
            // 
            // btnPlanDT
            // 
            this.btnPlanDT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanDT.Enabled = false;
            this.btnPlanDT.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlanDT.Location = new System.Drawing.Point(29, 109);
            this.btnPlanDT.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPlanDT.Name = "btnPlanDT";
            this.btnPlanDT.Size = new System.Drawing.Size(220, 35);
            this.btnPlanDT.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnPlanDT.TabIndex = 2;
            this.btnPlanDT.Text = "Planned Downtime";
            this.btnPlanDT.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlanDT.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnPlanDT.Click += new System.EventHandler(this.Audio_Btn_Hive_PlannedDowntime_Click);
            // 
            // btnIdle
            // 
            this.btnIdle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIdle.Enabled = false;
            this.btnIdle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIdle.Location = new System.Drawing.Point(29, 182);
            this.btnIdle.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnIdle.Name = "btnIdle";
            this.btnIdle.Size = new System.Drawing.Size(220, 35);
            this.btnIdle.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnIdle.TabIndex = 3;
            this.btnIdle.Text = "Idle";
            this.btnIdle.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIdle.Visible = false;
            this.btnIdle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnIdle.Click += new System.EventHandler(this.Audio_BtnIdle_Click);
            // 
            // btnEngineering
            // 
            this.btnEngineering.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEngineering.Enabled = false;
            this.btnEngineering.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEngineering.Location = new System.Drawing.Point(29, 231);
            this.btnEngineering.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEngineering.Name = "btnEngineering";
            this.btnEngineering.Size = new System.Drawing.Size(220, 35);
            this.btnEngineering.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnEngineering.TabIndex = 4;
            this.btnEngineering.Text = "Engineering";
            this.btnEngineering.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEngineering.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEngineering.Click += new System.EventHandler(this.Audio_Btn_Hive_Engineering_Click);
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.FillColor = System.Drawing.Color.Transparent;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.LineColor = System.Drawing.Color.Silver;
            this.uiLine2.Location = new System.Drawing.Point(29, 158);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(220, 10);
            this.uiLine2.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.uiLine2.TabIndex = 5;
            this.uiLine2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // HiveChangeStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(280, 340);
            this.ControlBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.btnEngineering);
            this.Controls.Add(this.btnIdle);
            this.Controls.Add(this.btnPlanDT);
            this.Controls.Add(this.btnDT);
            this.Controls.Add(this.btnRun);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 340);
            this.MinimumSize = new System.Drawing.Size(280, 340);
            this.Name = "HiveChangeStatus";
            this.RectColor = System.Drawing.Color.Gray;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "HIVE state";
            this.TitleColor = System.Drawing.Color.WhiteSmoke;
            this.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 318, 316);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HiveChangeStatus_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnRun;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnDT;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnPlanDT;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnIdle;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnEngineering;
        private SunnyUI.Controls.UILine uiLine2;
    }
}