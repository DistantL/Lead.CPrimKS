using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.BaseParam
{
    public partial class NewProperty
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labComb = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_DisplayName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.labUdt = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txbComb = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.cmbUdt = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.btnAddProperty = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.txbDisp = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txbName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lb_IndexName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_DataType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_GroupName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cmbVariableType = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.btnCancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.cmbGroup = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.lb_Cartesian = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cmb_Cartesian = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.SuspendLayout();
            // 
            // labComb
            // 
            this.labComb.AutoSize = true;
            this.labComb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labComb.Location = new System.Drawing.Point(20, 290);
            this.labComb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labComb.Name = "labComb";
            this.labComb.Size = new System.Drawing.Size(112, 27);
            this.labComb.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.labComb.TabIndex = 91;
            this.labComb.Text = "下拉框选项";
            this.labComb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labComb.Visible = false;
            this.labComb.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_DisplayName
            // 
            this.lb_DisplayName.AutoSize = true;
            this.lb_DisplayName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DisplayName.Location = new System.Drawing.Point(20, 130);
            this.lb_DisplayName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_DisplayName.Name = "lb_DisplayName";
            this.lb_DisplayName.Size = new System.Drawing.Size(92, 27);
            this.lb_DisplayName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_DisplayName.TabIndex = 90;
            this.lb_DisplayName.Text = "显示名称";
            this.lb_DisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_DisplayName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labUdt
            // 
            this.labUdt.AutoSize = true;
            this.labUdt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labUdt.Location = new System.Drawing.Point(20, 210);
            this.labUdt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUdt.Name = "labUdt";
            this.labUdt.Size = new System.Drawing.Size(152, 27);
            this.labUdt.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.labUdt.TabIndex = 89;
            this.labUdt.Text = "用户自定义数据";
            this.labUdt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labUdt.Visible = false;
            this.labUdt.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txbComb
            // 
            this.txbComb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbComb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbComb.Location = new System.Drawing.Point(20, 325);
            this.txbComb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txbComb.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbComb.Name = "txbComb";
            this.txbComb.RectColor = System.Drawing.Color.Gray;
            this.txbComb.ShowText = false;
            this.txbComb.Size = new System.Drawing.Size(323, 27);
            this.txbComb.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txbComb.StyleCustomMode = true;
            this.txbComb.TabIndex = 88;
            this.txbComb.Visible = false;
            this.txbComb.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmbUdt
            // 
            this.cmbUdt.DataSource = null;
            this.cmbUdt.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmbUdt.FillColor = System.Drawing.Color.White;
            this.cmbUdt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbUdt.FormattingEnabled = true;
            this.cmbUdt.Location = new System.Drawing.Point(20, 250);
            this.cmbUdt.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbUdt.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbUdt.Name = "cmbUdt";
            this.cmbUdt.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbUdt.RectColor = System.Drawing.Color.Gray;
            this.cmbUdt.Size = new System.Drawing.Size(133, 28);
            this.cmbUdt.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cmbUdt.StyleCustomMode = true;
            this.cmbUdt.TabIndex = 87;
            this.cmbUdt.Visible = false;
            this.cmbUdt.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProperty.FillColor = System.Drawing.Color.Gray;
            this.btnAddProperty.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddProperty.Location = new System.Drawing.Point(22, 370);
            this.btnAddProperty.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnAddProperty.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.RectColor = System.Drawing.Color.Gray;
            this.btnAddProperty.Size = new System.Drawing.Size(111, 41);
            this.btnAddProperty.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnAddProperty.StyleCustomMode = true;
            this.btnAddProperty.TabIndex = 86;
            this.btnAddProperty.Text = "确认";
            this.btnAddProperty.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddProperty.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAddProperty.Click += new System.EventHandler(this.BtnAddProperty_Click);
            // 
            // txbDisp
            // 
            this.txbDisp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbDisp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbDisp.Location = new System.Drawing.Point(20, 165);
            this.txbDisp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txbDisp.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbDisp.Name = "txbDisp";
            this.txbDisp.RectColor = System.Drawing.Color.Gray;
            this.txbDisp.ShowText = false;
            this.txbDisp.Size = new System.Drawing.Size(133, 27);
            this.txbDisp.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txbDisp.StyleCustomMode = true;
            this.txbDisp.TabIndex = 85;
            this.txbDisp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txbName
            // 
            this.txbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbName.Location = new System.Drawing.Point(210, 86);
            this.txbName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txbName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbName.Name = "txbName";
            this.txbName.RectColor = System.Drawing.Color.Gray;
            this.txbName.ShowText = false;
            this.txbName.Size = new System.Drawing.Size(133, 27);
            this.txbName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.txbName.StyleCustomMode = true;
            this.txbName.TabIndex = 83;
            this.txbName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_IndexName
            // 
            this.lb_IndexName.AutoSize = true;
            this.lb_IndexName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_IndexName.Location = new System.Drawing.Point(210, 50);
            this.lb_IndexName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_IndexName.Name = "lb_IndexName";
            this.lb_IndexName.Size = new System.Drawing.Size(92, 27);
            this.lb_IndexName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_IndexName.TabIndex = 82;
            this.lb_IndexName.Text = "索引名称";
            this.lb_IndexName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_IndexName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_DataType
            // 
            this.lb_DataType.AutoSize = true;
            this.lb_DataType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DataType.Location = new System.Drawing.Point(20, 50);
            this.lb_DataType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_DataType.Name = "lb_DataType";
            this.lb_DataType.Size = new System.Drawing.Size(92, 27);
            this.lb_DataType.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_DataType.TabIndex = 81;
            this.lb_DataType.Text = "变量类型";
            this.lb_DataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_DataType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_GroupName
            // 
            this.lb_GroupName.AutoSize = true;
            this.lb_GroupName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_GroupName.Location = new System.Drawing.Point(210, 130);
            this.lb_GroupName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_GroupName.Name = "lb_GroupName";
            this.lb_GroupName.Size = new System.Drawing.Size(52, 27);
            this.lb_GroupName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_GroupName.TabIndex = 80;
            this.lb_GroupName.Text = "分组";
            this.lb_GroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_GroupName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmbVariableType
            // 
            this.cmbVariableType.DataSource = null;
            this.cmbVariableType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmbVariableType.FillColor = System.Drawing.Color.White;
            this.cmbVariableType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbVariableType.FormattingEnabled = true;
            this.cmbVariableType.Location = new System.Drawing.Point(20, 85);
            this.cmbVariableType.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbVariableType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbVariableType.Name = "cmbVariableType";
            this.cmbVariableType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbVariableType.RectColor = System.Drawing.Color.Gray;
            this.cmbVariableType.Size = new System.Drawing.Size(133, 28);
            this.cmbVariableType.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cmbVariableType.StyleCustomMode = true;
            this.cmbVariableType.TabIndex = 78;
            this.cmbVariableType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cmbVariableType.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(232, 370);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.Color.Gray;
            this.btnCancel.Size = new System.Drawing.Size(111, 41);
            this.btnCancel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Text = "取消";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.DataSource = null;
            this.cmbGroup.FillColor = System.Drawing.Color.White;
            this.cmbGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(210, 164);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmbGroup.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbGroup.RectColor = System.Drawing.Color.Gray;
            this.cmbGroup.Size = new System.Drawing.Size(133, 28);
            this.cmbGroup.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cmbGroup.StyleCustomMode = true;
            this.cmbGroup.TabIndex = 93;
            this.cmbGroup.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_Cartesian
            // 
            this.lb_Cartesian.AutoSize = true;
            this.lb_Cartesian.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Cartesian.Location = new System.Drawing.Point(210, 210);
            this.lb_Cartesian.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Cartesian.Name = "lb_Cartesian";
            this.lb_Cartesian.Size = new System.Drawing.Size(52, 27);
            this.lb_Cartesian.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_Cartesian.TabIndex = 95;
            this.lb_Cartesian.Text = "轴组";
            this.lb_Cartesian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Cartesian.Visible = false;
            this.lb_Cartesian.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cmb_Cartesian
            // 
            this.cmb_Cartesian.DataSource = null;
            this.cmb_Cartesian.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cmb_Cartesian.FillColor = System.Drawing.Color.White;
            this.cmb_Cartesian.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Cartesian.FormattingEnabled = true;
            this.cmb_Cartesian.Location = new System.Drawing.Point(210, 250);
            this.cmb_Cartesian.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cmb_Cartesian.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmb_Cartesian.Name = "cmb_Cartesian";
            this.cmb_Cartesian.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmb_Cartesian.RectColor = System.Drawing.Color.Gray;
            this.cmb_Cartesian.Size = new System.Drawing.Size(133, 28);
            this.cmb_Cartesian.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cmb_Cartesian.StyleCustomMode = true;
            this.cmb_Cartesian.TabIndex = 94;
            this.cmb_Cartesian.Visible = false;
            this.cmb_Cartesian.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // NewProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(375, 435);
            this.Controls.Add(this.lb_Cartesian);
            this.Controls.Add(this.cmb_Cartesian);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labComb);
            this.Controls.Add(this.lb_DisplayName);
            this.Controls.Add(this.labUdt);
            this.Controls.Add(this.txbComb);
            this.Controls.Add(this.cmbUdt);
            this.Controls.Add(this.btnAddProperty);
            this.Controls.Add(this.txbDisp);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.lb_IndexName);
            this.Controls.Add(this.lb_DataType);
            this.Controls.Add(this.lb_GroupName);
            this.Controls.Add(this.cmbVariableType);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "NewProperty";
            this.RectColor = System.Drawing.Color.Gray;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "添加/修改属性";
            this.TitleColor = System.Drawing.Color.Gray;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 375, 432);
            this.Load += new System.EventHandler(this.NewProperty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

        private UILabel labComb;

        private UILabel lb_DisplayName;

        private UILabel labUdt;

        private UITextBox txbComb;

        private UIComboBox cmbUdt;

        private UIButton btnAddProperty;

        private UITextBox txbDisp;

        private UITextBox txbName;

        private UILabel lb_IndexName;

        private UILabel lb_DataType;

        private UILabel lb_GroupName;

        private UIComboBox cmbVariableType;

        private UIButton btnCancel;

        private UIComboBox cmbGroup;

        private UILabel lb_Cartesian;

        private UIComboBox cmb_Cartesian;
    }
}
