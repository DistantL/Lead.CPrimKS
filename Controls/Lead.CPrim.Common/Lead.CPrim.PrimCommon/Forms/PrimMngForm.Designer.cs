using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.PrimCommon
{
    partial class PrimMngForm
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
            TreeNode treeNode1 = new TreeNode("PrimManager");
            treePrimMng = new TreeView();
            btnPrimAdd = new Button();
            btnPrimDel = new Button();
            ((Control)this).SuspendLayout();
            treePrimMng.AllowDrop = true;
            treePrimMng.Dock = DockStyle.Fill;
            treePrimMng.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            treePrimMng.Location = new Point(0, 0);
            treePrimMng.Margin = new Padding(3, 4, 3, 4);
            treePrimMng.Name = "treePrimMng";
            treeNode1.Name = "RootPrim";
            treeNode1.Text = "PrimManager";
            treePrimMng.Nodes.AddRange(new TreeNode[1] { treeNode1 });
            treePrimMng.Size = new Size(222, 723);
            treePrimMng.TabIndex = 0;
            treePrimMng.ItemDrag += treePrimMng_ItemDrag;
            btnPrimAdd.Anchor = AnchorStyles.Right;
            btnPrimAdd.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnPrimAdd.Location = new Point(134, 13);
            btnPrimAdd.Margin = new Padding(3, 4, 3, 4);
            btnPrimAdd.Name = "btnPrimAdd";
            btnPrimAdd.Size = new Size(36, 36);
            btnPrimAdd.TabIndex = 1;
            btnPrimAdd.Text = "+";
            btnPrimAdd.UseVisualStyleBackColor = true;
            btnPrimDel.Anchor = AnchorStyles.Right;
            btnPrimDel.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnPrimDel.Location = new Point(176, 13);
            btnPrimDel.Margin = new Padding(3, 4, 3, 4);
            btnPrimDel.Name = "btnPrimDel";
            btnPrimDel.Size = new Size(36, 36);
            btnPrimDel.TabIndex = 1;
            btnPrimDel.Text = "-";
            btnPrimDel.UseVisualStyleBackColor = true;
            ((Control)(object)this).AllowDrop = true;
            ((ContainerControl)this).AutoScaleDimensions = new SizeF(9f, 20f);
            ((ContainerControl)this).AutoScaleMode = AutoScaleMode.Font;
            ((Form)this).ClientSize = new Size(222, 723);
            ((Control)this).Controls.Add(btnPrimDel);
            ((Control)this).Controls.Add(btnPrimAdd);
            ((Control)this).Controls.Add(treePrimMng);
            ((Control)(object)this).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            ((Form)this).Margin = new Padding(3, 4, 3, 4);
            ((Control)this).Name = "PrimMngForm";
            //((DockContent)this).TabText = "PrimMng";
            ((Control)(object)this).Text = "PrimMng";
            ((Control)this).ResumeLayout(performLayout: false);
        }

        #endregion

        private TreeView treePrimMng;
        private Button btnPrimAdd;
        private Button btnPrimDel;
    }
}
