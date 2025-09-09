using Lead.CPrim.StationCommon.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.Recipe
{
    partial class RecipeElesConfigForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpEles = new System.Windows.Forms.GroupBox();
            this.dgvEles = new System.Windows.Forms.DataGridView();
            this.cmbEles = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRemoveAllPrims = new System.Windows.Forms.Button();
            this.btnAddAllPrims = new System.Windows.Forms.Button();
            this.btnEleDown = new System.Windows.Forms.Button();
            this.btnEleUp = new System.Windows.Forms.Button();
            this.btnRemoveEle = new System.Windows.Forms.Button();
            this.btnAddEle = new System.Windows.Forms.Button();
            this.btnRefreshEles = new System.Windows.Forms.Button();
            this.grpEles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEles)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEles
            // 
            this.grpEles.Controls.Add(this.btnRemoveAllPrims);
            this.grpEles.Controls.Add(this.btnAddAllPrims);
            this.grpEles.Controls.Add(this.btnEleDown);
            this.grpEles.Controls.Add(this.btnEleUp);
            this.grpEles.Controls.Add(this.dgvEles);
            this.grpEles.Controls.Add(this.btnRemoveEle);
            this.grpEles.Controls.Add(this.btnAddEle);
            this.grpEles.Controls.Add(this.btnRefreshEles);
            this.grpEles.Controls.Add(this.cmbEles);
            this.grpEles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEles.Location = new System.Drawing.Point(0, 0);
            this.grpEles.Name = "grpEles";
            this.grpEles.Size = new System.Drawing.Size(404, 521);
            this.grpEles.TabIndex = 5;
            this.grpEles.TabStop = false;
            this.grpEles.Text = "元件";
            // 
            // dgvEles
            // 
            this.dgvEles.AllowUserToAddRows = false;
            this.dgvEles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEles.Location = new System.Drawing.Point(3, 70);
            this.dgvEles.Name = "dgvEles";
            this.dgvEles.RowHeadersWidth = 25;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEles.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEles.RowTemplate.Height = 23;
            this.dgvEles.Size = new System.Drawing.Size(398, 448);
            this.dgvEles.TabIndex = 8;
            this.dgvEles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvEles_DataError);
            // 
            // cmbEles
            // 
            this.cmbEles.DropDownWidth = 200;
            this.cmbEles.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmbEles.FormattingEnabled = true;
            this.cmbEles.Location = new System.Drawing.Point(5, 28);
            this.cmbEles.Name = "cmbEles";
            this.cmbEles.Size = new System.Drawing.Size(111, 27);
            this.cmbEles.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cmbEles, "元件列表");
            // 
            // btnRemoveAllPrims
            // 
            this.btnRemoveAllPrims.BackColor = System.Drawing.Color.Red;
            this.btnRemoveAllPrims.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_2;
            this.btnRemoveAllPrims.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveAllPrims.Location = new System.Drawing.Point(363, 24);
            this.btnRemoveAllPrims.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRemoveAllPrims.Name = "btnRemoveAllPrims";
            this.btnRemoveAllPrims.Size = new System.Drawing.Size(35, 35);
            this.btnRemoveAllPrims.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnRemoveAllPrims, "移除所有成员");
            this.btnRemoveAllPrims.UseVisualStyleBackColor = false;
            this.btnRemoveAllPrims.Click += new System.EventHandler(this.btnRemoveAllPrims_Click);
            // 
            // btnAddAllPrims
            // 
            this.btnAddAllPrims.BackColor = System.Drawing.Color.Lime;
            this.btnAddAllPrims.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Add_2;
            this.btnAddAllPrims.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAllPrims.Location = new System.Drawing.Point(322, 24);
            this.btnAddAllPrims.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddAllPrims.Name = "btnAddAllPrims";
            this.btnAddAllPrims.Size = new System.Drawing.Size(35, 35);
            this.btnAddAllPrims.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnAddAllPrims, "添加所有成员");
            this.btnAddAllPrims.UseVisualStyleBackColor = false;
            this.btnAddAllPrims.Click += new System.EventHandler(this.btnAddAllPrims_Click);
            // 
            // btnEleDown
            // 
            this.btnEleDown.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Down;
            this.btnEleDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEleDown.Location = new System.Drawing.Point(281, 24);
            this.btnEleDown.Name = "btnEleDown";
            this.btnEleDown.Size = new System.Drawing.Size(35, 35);
            this.btnEleDown.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnEleDown, "将表格中选中的成员向下移动");
            this.btnEleDown.UseVisualStyleBackColor = true;
            this.btnEleDown.Click += new System.EventHandler(this.btnEleDown_Click);
            // 
            // btnEleUp
            // 
            this.btnEleUp.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Up;
            this.btnEleUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEleUp.Location = new System.Drawing.Point(240, 24);
            this.btnEleUp.Name = "btnEleUp";
            this.btnEleUp.Size = new System.Drawing.Size(35, 35);
            this.btnEleUp.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnEleUp, "将表格中选中的成员向上移动");
            this.btnEleUp.UseVisualStyleBackColor = true;
            this.btnEleUp.Click += new System.EventHandler(this.btnEleUp_Click);
            // 
            // btnRemoveEle
            // 
            this.btnRemoveEle.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Remove_2;
            this.btnRemoveEle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveEle.Location = new System.Drawing.Point(158, 24);
            this.btnRemoveEle.Name = "btnRemoveEle";
            this.btnRemoveEle.Size = new System.Drawing.Size(35, 35);
            this.btnRemoveEle.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnRemoveEle, "删除表格中已选中的成员");
            this.btnRemoveEle.UseVisualStyleBackColor = true;
            this.btnRemoveEle.Click += new System.EventHandler(this.btnRemoveEle_Click);
            // 
            // btnAddEle
            // 
            this.btnAddEle.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Add_2;
            this.btnAddEle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddEle.Location = new System.Drawing.Point(117, 24);
            this.btnAddEle.Name = "btnAddEle";
            this.btnAddEle.Size = new System.Drawing.Size(35, 35);
            this.btnAddEle.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnAddEle, "添加下拉框中已选中的成员");
            this.btnAddEle.UseVisualStyleBackColor = true;
            this.btnAddEle.Click += new System.EventHandler(this.btnAddEle_Click);
            // 
            // btnRefreshEles
            // 
            this.btnRefreshEles.BackgroundImage = global::Lead.CPrim.StationCommon.Properties.Resources.Refresh_1;
            this.btnRefreshEles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshEles.Location = new System.Drawing.Point(199, 24);
            this.btnRefreshEles.Name = "btnRefreshEles";
            this.btnRefreshEles.Size = new System.Drawing.Size(35, 35);
            this.btnRefreshEles.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnRefreshEles, "刷新下拉框成员");
            this.btnRefreshEles.UseVisualStyleBackColor = true;
            this.btnRefreshEles.Click += new System.EventHandler(this.btnRefreshEles_Click);
            // 
            // RecipeElesConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 521);
            this.Controls.Add(this.grpEles);
            this.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecipeElesConfigForm";
            this.Text = "元件配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecipeElesConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.RecipeElesConfigForm_Load);
            this.grpEles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEles)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private GroupBox grpEles;
        private Button btnEleDown;
        private Button btnEleUp;
        private DataGridView dgvEles;
        private Button btnRemoveEle;
        private Button btnAddEle;
        private Button btnRefreshEles;
        private ComboBox cmbEles;
        private Button btnRemoveAllPrims;
        private Button btnAddAllPrims;
        private ToolTip toolTip1;
    }
}
