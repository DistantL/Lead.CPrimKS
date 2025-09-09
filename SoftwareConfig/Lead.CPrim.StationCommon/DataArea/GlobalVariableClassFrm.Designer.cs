using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.DataArea
{
    partial class GlobalVariableClassFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonApply = new System.Windows.Forms.ToolStripButton();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(900, 29);
            this.label1.TabIndex = 2;
            this.label1.Tag = "ClassName:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonAdd,
            this.toolStripButtonRemove,
            this.toolStripButtonApply});
            this.toolStrip1.Location = new System.Drawing.Point(0, 35);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonSave.Text = "toolStripButton1";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Add_1;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonAdd.Text = "toolStripButton2";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_1;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonRemove.Text = "toolStripButton3";
            this.toolStripButtonRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
            // 
            // toolStripButtonApply
            // 
            this.toolStripButtonApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonApply.Image = global::Lead.CPrim.StationCommon.Properties.Resources.Apply;
            this.toolStripButtonApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonApply.Name = "toolStripButtonApply";
            this.toolStripButtonApply.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonApply.Text = "toolStripButton4";
            this.toolStripButtonApply.Click += new System.EventHandler(this.toolStripButtonApply_Click);
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyName,
            this.PropertyType,
            this.PropertyValue});
            this.dgvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProperties.Location = new System.Drawing.Point(0, 29);
            this.dgvProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.RowHeadersWidth = 51;
            this.dgvProperties.RowTemplate.Height = 27;
            this.dgvProperties.Size = new System.Drawing.Size(900, 445);
            this.dgvProperties.TabIndex = 1;
            this.dgvProperties.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProperties_CellEnter);
            this.dgvProperties.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvProperties_CurrentCellDirtyStateChanged);
            // 
            // PropertyName
            // 
            this.PropertyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PropertyName.FillWeight = 25F;
            this.PropertyName.HeaderText = "PropertyName";
            this.PropertyName.MinimumWidth = 6;
            this.PropertyName.Name = "PropertyName";
            // 
            // PropertyType
            // 
            this.PropertyType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PropertyType.FillWeight = 20F;
            this.PropertyType.HeaderText = "PropertyType";
            this.PropertyType.MinimumWidth = 6;
            this.PropertyType.Name = "PropertyType";
            // 
            // PropertyValue
            // 
            this.PropertyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PropertyValue.FillWeight = 55F;
            this.PropertyValue.HeaderText = "PropertyValue";
            this.PropertyValue.MinimumWidth = 6;
            this.PropertyValue.Name = "PropertyValue";
            this.PropertyValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PropertyValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProperties);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 474);
            this.panel1.TabIndex = 3;
            // 
            // GlobalVariableClassFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GlobalVariableClassFrm";
            this.Text = "GlobalVariableClassFrm";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 900, 540);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dgvProperties;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonSave;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonRemove;
        private ToolStripButton toolStripButtonApply;
        private Panel panel1;
        private DataGridViewTextBoxColumn PropertyName;
        private DataGridViewComboBoxColumn PropertyType;
        private DataGridViewTextBoxColumn PropertyValue;
        private Label label1;
    }
}
