using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.TaskCommon
{
    partial class TaskConfigForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.tsTitle = new System.Windows.Forms.ToolStrip();
            this.tStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tStripBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tStripBtnDel = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnTaskSpacePath = new System.Windows.Forms.Button();
            this.tbTaskSpacePath = new System.Windows.Forms.TextBox();
            this.lb_TaskDirPath = new System.Windows.Forms.Label();
            this.tabTask = new System.Windows.Forms.TabControl();
            this.tPageProcTask = new System.Windows.Forms.TabPage();
            this.flpTask = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.tsTitle.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.tPageProcTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Margin = new System.Windows.Forms.Padding(0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.tsTitle);
            this.spcMain.Panel1.Controls.Add(this.btnTaskSpacePath);
            this.spcMain.Panel1.Controls.Add(this.tbTaskSpacePath);
            this.spcMain.Panel1.Controls.Add(this.lb_TaskDirPath);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.tabTask);
            this.spcMain.Size = new System.Drawing.Size(1408, 664);
            this.spcMain.SplitterDistance = 76;
            this.spcMain.TabIndex = 0;
            // 
            // tsTitle
            // 
            this.tsTitle.AutoSize = false;
            this.tsTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsTitle.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripBtnSave,
            this.tStripBtnAdd,
            this.tStripBtnDel,
            this.tsBtnEdit});
            this.tsTitle.Location = new System.Drawing.Point(0, 0);
            this.tsTitle.Name = "tsTitle";
            this.tsTitle.Padding = new System.Windows.Forms.Padding(0);
            this.tsTitle.Size = new System.Drawing.Size(1406, 32);
            this.tsTitle.TabIndex = 5;
            this.tsTitle.Text = "toolStrip1";
            // 
            // tStripBtnSave
            // 
            this.tStripBtnSave.AutoSize = false;
            this.tStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtnSave.Image = global::Lead.CPrim.Common.Properties.Resources.tStripBtnSave_Image;
            this.tStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtnSave.Name = "tStripBtnSave";
            this.tStripBtnSave.Size = new System.Drawing.Size(50, 24);
            this.tStripBtnSave.Text = "toolStripButton1";
            this.tStripBtnSave.ToolTipText = "保存配置";
            this.tStripBtnSave.Visible = false;
            this.tStripBtnSave.Click += new System.EventHandler(this.tStripBtnSave_Click);
            // 
            // tStripBtnAdd
            // 
            this.tStripBtnAdd.AutoSize = false;
            this.tStripBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtnAdd.Image = global::Lead.CPrim.Common.Properties.Resources.tStripBtnAdd_Image;
            this.tStripBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtnAdd.Name = "tStripBtnAdd";
            this.tStripBtnAdd.Size = new System.Drawing.Size(50, 24);
            this.tStripBtnAdd.Text = "新建任务";
            this.tStripBtnAdd.ToolTipText = "新建任务";
            this.tStripBtnAdd.Click += new System.EventHandler(this.tStripBtnAdd_Click);
            // 
            // tStripBtnDel
            // 
            this.tStripBtnDel.AutoSize = false;
            this.tStripBtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tStripBtnDel.Image = global::Lead.CPrim.Common.Properties.Resources.tStripBtnDel_Image;
            this.tStripBtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripBtnDel.Name = "tStripBtnDel";
            this.tStripBtnDel.Size = new System.Drawing.Size(50, 24);
            this.tStripBtnDel.Text = "删除任务";
            this.tStripBtnDel.ToolTipText = "删除任务";
            this.tStripBtnDel.Click += new System.EventHandler(this.tStripBtnDel_Click);
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.AutoSize = false;
            this.tsBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnEdit.Image = global::Lead.CPrim.Common.Properties.Resources.tsBtnEdit_Image;
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(50, 29);
            this.tsBtnEdit.Text = "toolStripSplitButton1";
            this.tsBtnEdit.Click += new System.EventHandler(this.tStripBtnEdit_Click);
            // 
            // btnTaskSpacePath
            // 
            this.btnTaskSpacePath.Location = new System.Drawing.Point(592, 39);
            this.btnTaskSpacePath.Name = "btnTaskSpacePath";
            this.btnTaskSpacePath.Size = new System.Drawing.Size(60, 26);
            this.btnTaskSpacePath.TabIndex = 3;
            this.btnTaskSpacePath.Text = "...";
            this.btnTaskSpacePath.UseVisualStyleBackColor = true;
            this.btnTaskSpacePath.Click += new System.EventHandler(this.btnTaskSpacePath_Click);
            // 
            // tbTaskSpacePath
            // 
            this.tbTaskSpacePath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTaskSpacePath.Location = new System.Drawing.Point(91, 41);
            this.tbTaskSpacePath.Name = "tbTaskSpacePath";
            this.tbTaskSpacePath.Size = new System.Drawing.Size(478, 27);
            this.tbTaskSpacePath.TabIndex = 2;
            this.tbTaskSpacePath.Text = "D:\\Task";
            // 
            // lb_TaskDirPath
            // 
            this.lb_TaskDirPath.Location = new System.Drawing.Point(3, 40);
            this.lb_TaskDirPath.Name = "lb_TaskDirPath";
            this.lb_TaskDirPath.Size = new System.Drawing.Size(93, 24);
            this.lb_TaskDirPath.TabIndex = 1;
            this.lb_TaskDirPath.Text = "任务路径：";
            this.lb_TaskDirPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.tPageProcTask);
            this.tabTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTask.ItemSize = new System.Drawing.Size(100, 24);
            this.tabTask.Location = new System.Drawing.Point(0, 0);
            this.tabTask.Margin = new System.Windows.Forms.Padding(0);
            this.tabTask.Name = "tabTask";
            this.tabTask.Padding = new System.Drawing.Point(0, 0);
            this.tabTask.SelectedIndex = 0;
            this.tabTask.Size = new System.Drawing.Size(1406, 582);
            this.tabTask.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabTask.TabIndex = 0;
            // 
            // tPageProcTask
            // 
            this.tPageProcTask.Controls.Add(this.flpTask);
            this.tPageProcTask.Location = new System.Drawing.Point(4, 28);
            this.tPageProcTask.Name = "tPageProcTask";
            this.tPageProcTask.Padding = new System.Windows.Forms.Padding(3);
            this.tPageProcTask.Size = new System.Drawing.Size(1398, 550);
            this.tPageProcTask.TabIndex = 0;
            this.tPageProcTask.Text = "任务列表";
            this.tPageProcTask.UseVisualStyleBackColor = true;
            // 
            // flpTask
            // 
            this.flpTask.AutoScroll = true;
            this.flpTask.BackColor = System.Drawing.SystemColors.Control;
            this.flpTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTask.Location = new System.Drawing.Point(3, 3);
            this.flpTask.Margin = new System.Windows.Forms.Padding(0);
            this.flpTask.Name = "flpTask";
            this.flpTask.Size = new System.Drawing.Size(1392, 544);
            this.flpTask.TabIndex = 2;
            // 
            // TaskConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1408, 664);
            this.Controls.Add(this.spcMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TaskConfigForm";
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.Text = "任务配置";
            this.Load += new System.EventHandler(this.TaskConfigForm_Load);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.tsTitle.ResumeLayout(false);
            this.tsTitle.PerformLayout();
            this.tabTask.ResumeLayout(false);
            this.tPageProcTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer spcMain;
        private Button btnTaskSpacePath;
        private TextBox tbTaskSpacePath;
        private Label lb_TaskDirPath;
        private ToolStrip tsTitle;
        private ToolStripButton tStripBtnSave;
        private ToolStripButton tStripBtnAdd;
        private ToolStripButton tStripBtnDel;
        private TabControl tabTask;
        private TabPage tPageProcTask;
        private FlowLayoutPanel flpTask;
        private ToolStripButton tsBtnEdit;
    }
}
