using Lead.CPrim.StationCommon.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.Recipe
{
    partial class RecipePrimsConfigForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpPrims = new System.Windows.Forms.GroupBox();
            this.dgvPrims = new System.Windows.Forms.DataGridView();
            this.cmbPrims = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRemoveAllPrims = new System.Windows.Forms.Button();
            this.btnAddAllPrims = new System.Windows.Forms.Button();
            this.btnPrimDown = new System.Windows.Forms.Button();
            this.btnPrimUp = new System.Windows.Forms.Button();
            this.btnRemovePrim = new System.Windows.Forms.Button();
            this.btnAddPrim = new System.Windows.Forms.Button();
            this.btnRefreshPrims = new System.Windows.Forms.Button();
            this.grpPrims.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrims)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPrims
            // 
            this.grpPrims.Controls.Add(this.btnRemoveAllPrims);
            this.grpPrims.Controls.Add(this.btnAddAllPrims);
            this.grpPrims.Controls.Add(this.btnPrimDown);
            this.grpPrims.Controls.Add(this.btnPrimUp);
            this.grpPrims.Controls.Add(this.dgvPrims);
            this.grpPrims.Controls.Add(this.btnRemovePrim);
            this.grpPrims.Controls.Add(this.btnAddPrim);
            this.grpPrims.Controls.Add(this.btnRefreshPrims);
            this.grpPrims.Controls.Add(this.cmbPrims);
            this.grpPrims.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrims.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPrims.Location = new System.Drawing.Point(0, 0);
            this.grpPrims.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPrims.Name = "grpPrims";
            this.grpPrims.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPrims.Size = new System.Drawing.Size(404, 521);
            this.grpPrims.TabIndex = 2;
            this.grpPrims.TabStop = false;
            this.grpPrims.Text = "基元";
            // 
            // dgvPrims
            // 
            this.dgvPrims.AllowUserToAddRows = false;
            this.dgvPrims.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrims.Location = new System.Drawing.Point(3, 70);
            this.dgvPrims.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPrims.Name = "dgvPrims";
            this.dgvPrims.RowHeadersWidth = 25;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPrims.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPrims.RowTemplate.Height = 23;
            this.dgvPrims.Size = new System.Drawing.Size(387, 443);
            this.dgvPrims.TabIndex = 8;
            this.dgvPrims.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPrims_DataError);
            // 
            // cmbPrims
            // 
            this.cmbPrims.DropDownWidth = 200;
            this.cmbPrims.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmbPrims.FormattingEnabled = true;
            this.cmbPrims.Location = new System.Drawing.Point(3, 27);
            this.cmbPrims.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPrims.Name = "cmbPrims";
            this.cmbPrims.Size = new System.Drawing.Size(108, 27);
            this.cmbPrims.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmbPrims, "基元列表");
            // 
            // btnRemoveAllPrims
            // 
            this.btnRemoveAllPrims.BackColor = System.Drawing.Color.Red;
            this.btnRemoveAllPrims.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_2;
            this.btnRemoveAllPrims.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveAllPrims.Location = new System.Drawing.Point(363, 23);
            this.btnRemoveAllPrims.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveAllPrims.Name = "btnRemoveAllPrims";
            this.btnRemoveAllPrims.Size = new System.Drawing.Size(35, 35);
            this.btnRemoveAllPrims.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnRemoveAllPrims, "移除所有成员");
            this.btnRemoveAllPrims.UseVisualStyleBackColor = false;
            this.btnRemoveAllPrims.Click += new System.EventHandler(this.btnRemoveAllPrims_Click);
            // 
            // btnAddAllPrims
            // 
            this.btnAddAllPrims.BackColor = System.Drawing.Color.Lime;
            this.btnAddAllPrims.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Add_2;
            this.btnAddAllPrims.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAllPrims.Location = new System.Drawing.Point(322, 23);
            this.btnAddAllPrims.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddAllPrims.Name = "btnAddAllPrims";
            this.btnAddAllPrims.Size = new System.Drawing.Size(35, 35);
            this.btnAddAllPrims.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnAddAllPrims, "添加所有成员");
            this.btnAddAllPrims.UseVisualStyleBackColor = false;
            this.btnAddAllPrims.Click += new System.EventHandler(this.btnAddAllPrims_Click);
            // 
            // btnPrimDown
            // 
            this.btnPrimDown.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Down;
            this.btnPrimDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrimDown.Location = new System.Drawing.Point(281, 23);
            this.btnPrimDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrimDown.Name = "btnPrimDown";
            this.btnPrimDown.Size = new System.Drawing.Size(35, 35);
            this.btnPrimDown.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnPrimDown, "将表格中选中的成员向下移动");
            this.btnPrimDown.UseVisualStyleBackColor = true;
            this.btnPrimDown.Click += new System.EventHandler(this.btnPrimDown_Click);
            // 
            // btnPrimUp
            // 
            this.btnPrimUp.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Up;
            this.btnPrimUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrimUp.Location = new System.Drawing.Point(240, 23);
            this.btnPrimUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrimUp.Name = "btnPrimUp";
            this.btnPrimUp.Size = new System.Drawing.Size(35, 35);
            this.btnPrimUp.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnPrimUp, "将表格中选中的成员向上移动");
            this.btnPrimUp.UseVisualStyleBackColor = true;
            this.btnPrimUp.Click += new System.EventHandler(this.btnPrimUp_Click);
            // 
            // btnRemovePrim
            // 
            this.btnRemovePrim.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_2;
            this.btnRemovePrim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemovePrim.Location = new System.Drawing.Point(158, 23);
            this.btnRemovePrim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemovePrim.Name = "btnRemovePrim";
            this.btnRemovePrim.Size = new System.Drawing.Size(35, 35);
            this.btnRemovePrim.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnRemovePrim, "删除表格中已选中的成员");
            this.btnRemovePrim.UseVisualStyleBackColor = true;
            this.btnRemovePrim.Click += new System.EventHandler(this.btnRemovePrim_Click);
            // 
            // btnAddPrim
            // 
            this.btnAddPrim.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Add_2;
            this.btnAddPrim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddPrim.Location = new System.Drawing.Point(117, 23);
            this.btnAddPrim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddPrim.Name = "btnAddPrim";
            this.btnAddPrim.Size = new System.Drawing.Size(35, 35);
            this.btnAddPrim.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnAddPrim, "添加下拉框中已选中的成员");
            this.btnAddPrim.UseVisualStyleBackColor = true;
            this.btnAddPrim.Click += new System.EventHandler(this.btnAddPrim_Click);
            // 
            // btnRefreshPrims
            // 
            this.btnRefreshPrims.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Refresh_1;
            this.btnRefreshPrims.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshPrims.Location = new System.Drawing.Point(199, 23);
            this.btnRefreshPrims.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefreshPrims.Name = "btnRefreshPrims";
            this.btnRefreshPrims.Size = new System.Drawing.Size(35, 35);
            this.btnRefreshPrims.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnRefreshPrims, "刷新下拉框成员");
            this.btnRefreshPrims.UseVisualStyleBackColor = true;
            this.btnRefreshPrims.Click += new System.EventHandler(this.btnRefreshPrims_Click);
            // 
            // RecipePrimsConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 521);
            this.Controls.Add(this.grpPrims);
            this.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecipePrimsConfigForm";
            this.Text = "基元配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecipePrimsConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.RecipePrimsConfigForm_Load);
            this.grpPrims.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrims)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private GroupBox grpPrims;
        private Button btnPrimDown;
        private Button btnPrimUp;
        private DataGridView dgvPrims;
        private Button btnRemovePrim;
        private Button btnAddPrim;
        private Button btnRefreshPrims;
        private ComboBox cmbPrims;
        private Button btnRemoveAllPrims;
        private ToolTip toolTip1;
        private Button btnAddAllPrims;
    }
}
