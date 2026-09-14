namespace Lead.CPrim.BaseParam
{
    partial class TransferPropertyForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Lead.CPrim.ProxyTools.NLocalizer.LanguageChanged -= OnLanguageChanged;
                if (components != null) components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.lbType = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbDisplay = new System.Windows.Forms.Label();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.lbGroup = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.lbProduct = new System.Windows.Forms.Label();
            this.lbWarning = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // lbType
            this.lbType.Name = "lbType";
            this.lbType.Location = new System.Drawing.Point(28, 64);
            this.lbType.Size = new System.Drawing.Size(240, 28);
            this.lbType.Text = "变量类型";
            // tbType
            this.tbType.Name = "tbType";
            this.tbType.Location = new System.Drawing.Point(28, 98);
            this.tbType.Size = new System.Drawing.Size(240, 30);
            this.tbType.ReadOnly = true;
            // lbName
            this.lbName.Name = "lbName";
            this.lbName.Location = new System.Drawing.Point(302, 64);
            this.lbName.Size = new System.Drawing.Size(240, 28);
            this.lbName.Text = "索引名称";
            // tbName
            this.tbName.Name = "tbName";
            this.tbName.Location = new System.Drawing.Point(302, 98);
            this.tbName.Size = new System.Drawing.Size(240, 30);
            this.tbName.ReadOnly = true;
            // lbDisplay
            this.lbDisplay.Name = "lbDisplay";
            this.lbDisplay.Location = new System.Drawing.Point(28, 154);
            this.lbDisplay.Size = new System.Drawing.Size(240, 28);
            this.lbDisplay.Text = "显示名称";
            // tbDisplay
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Location = new System.Drawing.Point(28, 188);
            this.tbDisplay.Size = new System.Drawing.Size(240, 30);
            this.tbDisplay.ReadOnly = true;
            // lbGroup
            this.lbGroup.Name = "lbGroup";
            this.lbGroup.Location = new System.Drawing.Point(302, 154);
            this.lbGroup.Size = new System.Drawing.Size(240, 28);
            this.lbGroup.Text = "分组";
            // cbGroup
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Location = new System.Drawing.Point(302, 188);
            this.cbGroup.Size = new System.Drawing.Size(240, 30);
            // lbProduct
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Location = new System.Drawing.Point(28, 240);
            this.lbProduct.Size = new System.Drawing.Size(514, 26);
            this.lbProduct.Text = "";
            // lbWarning
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Location = new System.Drawing.Point(28, 275);
            this.lbWarning.Size = new System.Drawing.Size(514, 94);
            this.lbWarning.Text = "";
            // btnOK
            this.btnOK.Name = "btnOK";
            this.btnOK.Location = new System.Drawing.Point(28, 390);
            this.btnOK.Size = new System.Drawing.Size(150, 42);
            this.btnOK.Text = "确定";
            // btnCancel
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Location = new System.Drawing.Point(392, 390);
            this.btnCancel.Size = new System.Drawing.Size(150, 42);
            this.btnCancel.Text = "取消";
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 460);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "TransferPropertyForm";
            this.Text = "转移为换型参数";
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbDisplay);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.lbGroup);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.lbProduct);
            this.Controls.Add(this.lbWarning);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbDisplay;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Label lbGroup;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Label lbProduct;
        private System.Windows.Forms.Label lbWarning;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
