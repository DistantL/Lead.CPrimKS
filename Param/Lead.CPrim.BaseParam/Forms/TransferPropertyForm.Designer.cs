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
            this.lbType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tbType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lbName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tbName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lbDisplay = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.tbDisplay = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lbGroup = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cbGroup = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.lbProduct = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lbWarning = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.btnOK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.SuspendLayout();
            // lbType
            this.lbType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbType.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lbType.StyleCustomMode = true;
            this.lbType.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbType.Name = "lbType";
            this.lbType.Location = new System.Drawing.Point(20, 50);
            this.lbType.Size = new System.Drawing.Size(133, 27);
            this.lbType.Text = "变量类型";
            // tbType
            this.tbType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbType.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbType.StyleCustomMode = true;
            this.tbType.RectColor = System.Drawing.Color.Gray;
            this.tbType.Name = "tbType";
            this.tbType.Location = new System.Drawing.Point(20, 86);
            this.tbType.Size = new System.Drawing.Size(133, 28);
            this.tbType.ReadOnly = true;
            // lbName
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lbName.StyleCustomMode = true;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbName.Name = "lbName";
            this.lbName.Location = new System.Drawing.Point(210, 50);
            this.lbName.Size = new System.Drawing.Size(133, 27);
            this.lbName.Text = "索引名称";
            // tbName
            this.tbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbName.StyleCustomMode = true;
            this.tbName.RectColor = System.Drawing.Color.Gray;
            this.tbName.Name = "tbName";
            this.tbName.Location = new System.Drawing.Point(210, 86);
            this.tbName.Size = new System.Drawing.Size(133, 27);
            this.tbName.ReadOnly = true;
            // lbDisplay
            this.lbDisplay.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDisplay.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lbDisplay.StyleCustomMode = true;
            this.lbDisplay.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbDisplay.Name = "lbDisplay";
            this.lbDisplay.Location = new System.Drawing.Point(20, 130);
            this.lbDisplay.Size = new System.Drawing.Size(133, 27);
            this.lbDisplay.Text = "显示名称";
            // tbDisplay
            this.tbDisplay.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDisplay.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tbDisplay.StyleCustomMode = true;
            this.tbDisplay.RectColor = System.Drawing.Color.Gray;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.Location = new System.Drawing.Point(20, 165);
            this.tbDisplay.Size = new System.Drawing.Size(133, 27);
            this.tbDisplay.ReadOnly = true;
            // lbGroup
            this.lbGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbGroup.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lbGroup.StyleCustomMode = true;
            this.lbGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbGroup.Name = "lbGroup";
            this.lbGroup.Location = new System.Drawing.Point(210, 130);
            this.lbGroup.Size = new System.Drawing.Size(133, 27);
            this.lbGroup.Text = "分组";
            // cbGroup
            this.cbGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbGroup.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cbGroup.StyleCustomMode = true;
            this.cbGroup.RectColor = System.Drawing.Color.Gray;
            this.cbGroup.FillColor = System.Drawing.Color.White;
            this.cbGroup.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Location = new System.Drawing.Point(210, 164);
            this.cbGroup.Size = new System.Drawing.Size(133, 28);
            // lbProduct
            this.lbProduct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbProduct.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lbProduct.StyleCustomMode = true;
            this.lbProduct.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Location = new System.Drawing.Point(20, 210);
            this.lbProduct.Size = new System.Drawing.Size(323, 27);
            this.lbProduct.Text = "";
            // lbWarning
            this.lbWarning.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWarning.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lbWarning.StyleCustomMode = true;
            this.lbWarning.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Location = new System.Drawing.Point(20, 244);
            this.lbWarning.Size = new System.Drawing.Size(323, 110);
            this.lbWarning.Text = "";
            // btnOK
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnOK.StyleCustomMode = true;
            this.btnOK.RectColor = System.Drawing.Color.Gray;
            this.btnOK.FillColor = System.Drawing.Color.Gray;
            this.btnOK.Name = "btnOK";
            this.btnOK.Location = new System.Drawing.Point(22, 370);
            this.btnOK.Size = new System.Drawing.Size(111, 41);
            this.btnOK.Text = "确定";
            // btnCancel
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.RectColor = System.Drawing.Color.Gray;
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Location = new System.Drawing.Point(233, 370);
            this.btnCancel.Size = new System.Drawing.Size(111, 41);
            this.btnCancel.Text = "取消";
            this.cbGroup.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDown;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.TitleColor = System.Drawing.Color.Gray;
            this.RectColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(375, 435);
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
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lbType;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox tbType;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lbName;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox tbName;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lbDisplay;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox tbDisplay;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lbGroup;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox cbGroup;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lbProduct;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel lbWarning;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnOK;
        private Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton btnCancel;
    }
}
