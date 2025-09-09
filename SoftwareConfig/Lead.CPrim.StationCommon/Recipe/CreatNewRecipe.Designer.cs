using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.StationCommon.Recipe
{
    partial class CreatNewRecipe
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
            labRecipeName = new System.Windows.Forms.Label();
            txbRecipeName = new System.Windows.Forms.TextBox();
            txbCreator = new System.Windows.Forms.TextBox();
            labCreator = new System.Windows.Forms.Label();
            btnEnter = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            labRecipeName.AutoSize = true;
            labRecipeName.Font = new System.Drawing.Font("宋体", 15.75f);
            labRecipeName.Location = new System.Drawing.Point(72, 48);
            labRecipeName.Name = "labRecipeName";
            labRecipeName.Size = new System.Drawing.Size(94, 21);
            labRecipeName.TabIndex = 0;
            labRecipeName.Text = "配方名：";
            txbRecipeName.Font = new System.Drawing.Font("宋体", 18f);
            txbRecipeName.Location = new System.Drawing.Point(214, 42);
            txbRecipeName.Name = "txbRecipeName";
            txbRecipeName.Size = new System.Drawing.Size(180, 35);
            txbRecipeName.TabIndex = 1;
            txbRecipeName.Text = "Recipe1";
            txbCreator.Font = new System.Drawing.Font("宋体", 18f);
            txbCreator.Location = new System.Drawing.Point(214, 103);
            txbCreator.Name = "txbCreator";
            txbCreator.Size = new System.Drawing.Size(180, 35);
            txbCreator.TabIndex = 3;
            txbCreator.Text = "Administrator";
            labCreator.AutoSize = true;
            labCreator.Font = new System.Drawing.Font("宋体", 15.75f);
            labCreator.Location = new System.Drawing.Point(72, 109);
            labCreator.Name = "labCreator";
            labCreator.Size = new System.Drawing.Size(94, 21);
            labCreator.TabIndex = 2;
            labCreator.Text = "创建者：";
            btnEnter.Location = new System.Drawing.Point(118, 182);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new System.Drawing.Size(116, 39);
            btnEnter.TabIndex = 4;
            btnEnter.Text = "新建";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += new System.EventHandler(btnEnter_Click);
            btnCancel.Location = new System.Drawing.Point(302, 182);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(116, 39);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += new System.EventHandler(btnCancel_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(527, 233);
            base.ControlBox = false;
            base.Controls.Add(btnCancel);
            base.Controls.Add(btnEnter);
            base.Controls.Add(txbCreator);
            base.Controls.Add(labCreator);
            base.Controls.Add(txbRecipeName);
            base.Controls.Add(labRecipeName);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "CreatNewRecipe";
            Text = "新建配方";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labRecipeName;
        private TextBox txbRecipeName;
        private TextBox txbCreator;
        private Label labCreator;
        private Button btnEnter;
        private Button btnCancel;
    }
}
