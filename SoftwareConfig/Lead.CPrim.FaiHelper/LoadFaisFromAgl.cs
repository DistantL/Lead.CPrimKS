using CommonStruct.TypePrim;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.FaiHelper
{
    public class LoadFaisFromAgl : Form
	{
        #region Field
        private bool _childFlag;

        internal List<FaiConfig> Fais = new List<FaiConfig>();

        internal List<ChildFaiConfig> ChildFais = new List<ChildFaiConfig>();
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public LoadFaisFromAgl()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="childFlag"></param>
        public LoadFaisFromAgl(bool childFlag)
        {
            InitializeComponent();
            _childFlag = childFlag;
        }
        #endregion


        #region Button_Event
        /// <summary>选择产品</summary>
        private void lbChooseProduct_DoubleClick(object sender, EventArgs e)
        {
            if (SwManager.Instance == null)
            {
                return;
            }
            cmbProducts.Items.Clear();
            if (SwManager.Instance.Products != null && SwManager.Instance.Products.Count > 0)
            {
                SwManager.Instance.Products.ForEach(p => cmbProducts.Items.Add(p));
                cmbProducts.SelectedItem = SwManager.Instance.CurrentProduct;
            }
        }
        /// <summary>选择3D算法基元</summary>
        private void lblChoose3dAgl_DoubleClick(object sender, EventArgs e)
        {
            cmb3dAgls.Items.Clear();
            foreach (IPrim prim in PrimsManagerTransfer.GetAllIPrim())
            {
                if (prim is I3DAgl)
                {
                    cmb3dAgls.Items.Add(prim.Name);
                }
            }
        }
        /// <summary>3D导入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad3d_Click(object sender, EventArgs e)
        {
            string product = ((cmbProducts.SelectedItem == null) ? "" : cmbProducts.SelectedItem.ToString());
            if (cmb3dAgls.SelectedItem == null)
            {
                MessageBox.Show("3D算法基元不得为空，请检查");
                return;
            }
            IPrim agl = PrimsManagerTransfer.GetPrimByName(cmb3dAgls.SelectedItem.ToString());
            if (agl == null)
            {
                MessageBox.Show("3D算法基元未找到，请检查");
                return;
            }
            Cursor = Cursors.WaitCursor;
            List<FaiValue> fais = ((I3DAgl)agl).GetFaisFromTask(true, product);
            if (fais != null && fais.Count > 0)
            {
                if (!_childFlag)
                {
                    Fais.Clear();
                    foreach (FaiValue fai2 in fais)
                    {
                        Fais.Add(new FaiConfig(fai2.remark, enable: true, isOutput: true, isUpload: true, isParent: false, isVirtual: false, isNonnegativeTo0: false, isNonnegativeToPositive: false, fai2.normal, fai2.tolUp, fai2.tolLow, 0.0, fai2.factor, -1));
                    }
                }
                else
                {
                    ChildFais.Clear();
                    foreach (FaiValue fai in fais)
                    {
                        ChildFais.Add(new ChildFaiConfig(fai.remark, enable: true, isOutput: true, isUpload: true, isNonnegativeTo0: false, isNonnegativeToPositive: false, fai.normal, fai.tolUp, fai.tolLow, 0.0, fai.factor, -1));
                    }
                }
            }
            Cursor = Cursors.Default;
            Close();
        }
        /// <summary>选择2D算法基元</summary>
        private void lblChoose2dAgl_DoubleClick(object sender, EventArgs e)
        {
        }
        #endregion





        







        #region System
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private ComboBox cmbProducts;

        private Label lbChooseProduct;

        private ComboBox cmb3dAgls;

        private Label lblChoose3dAgl;

        private Button btnLoad3d;

        private Button btnLoad2d;

        private ComboBox cmb2dAgls;

        private Label lblChoose2dAgl;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.lbChooseProduct = new System.Windows.Forms.Label();
            this.cmb3dAgls = new System.Windows.Forms.ComboBox();
            this.lblChoose3dAgl = new System.Windows.Forms.Label();
            this.btnLoad3d = new System.Windows.Forms.Button();
            this.btnLoad2d = new System.Windows.Forms.Button();
            this.cmb2dAgls = new System.Windows.Forms.ComboBox();
            this.lblChoose2dAgl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbProducts
            // 
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(175, 23);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(123, 20);
            this.cmbProducts.TabIndex = 81;
            // 
            // lbChooseProduct
            // 
            this.lbChooseProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbChooseProduct.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbChooseProduct.Location = new System.Drawing.Point(12, 19);
            this.lbChooseProduct.Name = "lbChooseProduct";
            this.lbChooseProduct.Size = new System.Drawing.Size(146, 29);
            this.lbChooseProduct.TabIndex = 80;
            this.lbChooseProduct.Text = "选择产品：";
            this.lbChooseProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbChooseProduct.DoubleClick += new System.EventHandler(this.lbChooseProduct_DoubleClick);
            // 
            // cmb3dAgls
            // 
            this.cmb3dAgls.FormattingEnabled = true;
            this.cmb3dAgls.Location = new System.Drawing.Point(175, 61);
            this.cmb3dAgls.Name = "cmb3dAgls";
            this.cmb3dAgls.Size = new System.Drawing.Size(123, 20);
            this.cmb3dAgls.TabIndex = 83;
            // 
            // lblChoose3dAgl
            // 
            this.lblChoose3dAgl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChoose3dAgl.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChoose3dAgl.Location = new System.Drawing.Point(12, 57);
            this.lblChoose3dAgl.Name = "lblChoose3dAgl";
            this.lblChoose3dAgl.Size = new System.Drawing.Size(146, 29);
            this.lblChoose3dAgl.TabIndex = 82;
            this.lblChoose3dAgl.Text = "选择3D算法基元：";
            this.lblChoose3dAgl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChoose3dAgl.DoubleClick += new System.EventHandler(this.lblChoose3dAgl_DoubleClick);
            // 
            // btnLoad3d
            // 
            this.btnLoad3d.Location = new System.Drawing.Point(322, 60);
            this.btnLoad3d.Name = "btnLoad3d";
            this.btnLoad3d.Size = new System.Drawing.Size(75, 23);
            this.btnLoad3d.TabIndex = 84;
            this.btnLoad3d.Text = "3D导入";
            this.btnLoad3d.UseVisualStyleBackColor = true;
            this.btnLoad3d.Click += new System.EventHandler(this.btnLoad3d_Click);
            // 
            // btnLoad2d
            // 
            this.btnLoad2d.Location = new System.Drawing.Point(322, 98);
            this.btnLoad2d.Name = "btnLoad2d";
            this.btnLoad2d.Size = new System.Drawing.Size(75, 23);
            this.btnLoad2d.TabIndex = 87;
            this.btnLoad2d.Text = "2D导入";
            this.btnLoad2d.UseVisualStyleBackColor = true;
            this.btnLoad2d.Visible = false;
            // 
            // cmb2dAgls
            // 
            this.cmb2dAgls.FormattingEnabled = true;
            this.cmb2dAgls.Location = new System.Drawing.Point(175, 99);
            this.cmb2dAgls.Name = "cmb2dAgls";
            this.cmb2dAgls.Size = new System.Drawing.Size(123, 20);
            this.cmb2dAgls.TabIndex = 86;
            this.cmb2dAgls.Visible = false;
            // 
            // lblChoose2dAgl
            // 
            this.lblChoose2dAgl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChoose2dAgl.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChoose2dAgl.Location = new System.Drawing.Point(12, 95);
            this.lblChoose2dAgl.Name = "lblChoose2dAgl";
            this.lblChoose2dAgl.Size = new System.Drawing.Size(146, 29);
            this.lblChoose2dAgl.TabIndex = 85;
            this.lblChoose2dAgl.Text = "选择2D算法基元：";
            this.lblChoose2dAgl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChoose2dAgl.Visible = false;
            this.lblChoose2dAgl.DoubleClick += new System.EventHandler(this.lblChoose2dAgl_DoubleClick);
            // 
            // LoadFaisFromAgl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 147);
            this.Controls.Add(this.btnLoad2d);
            this.Controls.Add(this.cmb2dAgls);
            this.Controls.Add(this.lblChoose2dAgl);
            this.Controls.Add(this.btnLoad3d);
            this.Controls.Add(this.cmb3dAgls);
            this.Controls.Add(this.lblChoose3dAgl);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.lbChooseProduct);
            this.MaximizeBox = false;
            this.Name = "LoadFaisFromAgl";
            this.Text = "算法导入Fai项";
            this.ResumeLayout(false);

        } 
        #endregion
    }
}
