
namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    partial class InputAccessarySN_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Operator = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtNewSN = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.bt_Cancel = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.bt_OK = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.tb_Opeartor = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtOldSN = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.lb_Old_SN = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.lb_New_SN = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.labSelect = new System.Windows.Forms.Label();
            this.lb_AccessaryName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cb_AccessaryName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIComboBox();
            this.lblState = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.SuspendLayout();
            // 
            // lb_Operator
            // 
            this.lb_Operator.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Operator.Location = new System.Drawing.Point(22, 147);
            this.lb_Operator.Name = "lb_Operator";
            this.lb_Operator.Size = new System.Drawing.Size(121, 35);
            this.lb_Operator.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_Operator.TabIndex = 0;
            this.lb_Operator.Text = "操作员卡号 :";
            this.lb_Operator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Operator.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtNewSN
            // 
            this.txtNewSN.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtNewSN.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtNewSN.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtNewSN.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtNewSN.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtNewSN.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtNewSN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewSN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtNewSN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewSN.Location = new System.Drawing.Point(150, 250);
            this.txtNewSN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewSN.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtNewSN.Name = "txtNewSN";
            this.txtNewSN.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtNewSN.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtNewSN.ShowText = false;
            this.txtNewSN.Size = new System.Drawing.Size(307, 29);
            this.txtNewSN.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.txtNewSN.StyleCustomMode = true;
            this.txtNewSN.TabIndex = 1;
            this.txtNewSN.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtNewSN.TextChanged += new System.EventHandler(this.txtNewSN_TextChanged);
            this.txtNewSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewSN_KeyDown);
            this.txtNewSN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewSN_KeyUp);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Cancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Cancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Cancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_Cancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Cancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Cancel.Location = new System.Drawing.Point(357, 311);
            this.bt_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_Cancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_Cancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Cancel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_Cancel.Size = new System.Drawing.Size(100, 35);
            this.bt_Cancel.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.bt_Cancel.StyleCustomMode = true;
            this.bt_Cancel.TabIndex = 2;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Cancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_OK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_OK.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_OK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_OK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_OK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_OK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_OK.Location = new System.Drawing.Point(240, 311);
            this.bt_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.bt_OK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.bt_OK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_OK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.bt_OK.Size = new System.Drawing.Size(100, 35);
            this.bt_OK.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.bt_OK.StyleCustomMode = true;
            this.bt_OK.TabIndex = 3;
            this.bt_OK.Text = "OK";
            this.bt_OK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_OK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // tb_Opeartor
            // 
            this.tb_Opeartor.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tb_Opeartor.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.tb_Opeartor.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.tb_Opeartor.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tb_Opeartor.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.tb_Opeartor.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.tb_Opeartor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Opeartor.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tb_Opeartor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Opeartor.Location = new System.Drawing.Point(150, 150);
            this.tb_Opeartor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Opeartor.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_Opeartor.Name = "tb_Opeartor";
            this.tb_Opeartor.ReadOnly = true;
            this.tb_Opeartor.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tb_Opeartor.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.tb_Opeartor.ShowText = false;
            this.tb_Opeartor.Size = new System.Drawing.Size(307, 29);
            this.tb_Opeartor.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.tb_Opeartor.StyleCustomMode = true;
            this.tb_Opeartor.TabIndex = 3;
            this.tb_Opeartor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtOldSN
            // 
            this.txtOldSN.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtOldSN.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtOldSN.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtOldSN.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtOldSN.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.txtOldSN.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.txtOldSN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldSN.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtOldSN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldSN.Location = new System.Drawing.Point(150, 200);
            this.txtOldSN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOldSN.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtOldSN.Name = "txtOldSN";
            this.txtOldSN.ReadOnly = true;
            this.txtOldSN.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtOldSN.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.txtOldSN.ShowText = false;
            this.txtOldSN.Size = new System.Drawing.Size(307, 29);
            this.txtOldSN.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Gray;
            this.txtOldSN.StyleCustomMode = true;
            this.txtOldSN.TabIndex = 3;
            this.txtOldSN.Text = " ";
            this.txtOldSN.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_Old_SN
            // 
            this.lb_Old_SN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Old_SN.Location = new System.Drawing.Point(22, 197);
            this.lb_Old_SN.Name = "lb_Old_SN";
            this.lb_Old_SN.Size = new System.Drawing.Size(121, 35);
            this.lb_Old_SN.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_Old_SN.TabIndex = 4;
            this.lb_Old_SN.Text = "旧料号 :";
            this.lb_Old_SN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Old_SN.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lb_New_SN
            // 
            this.lb_New_SN.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_New_SN.Location = new System.Drawing.Point(22, 247);
            this.lb_New_SN.Name = "lb_New_SN";
            this.lb_New_SN.Size = new System.Drawing.Size(121, 35);
            this.lb_New_SN.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_New_SN.TabIndex = 5;
            this.lb_New_SN.Text = "新料号 :";
            this.lb_New_SN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_New_SN.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // labSelect
            // 
            this.labSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labSelect.AutoSize = true;
            this.labSelect.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSelect.ForeColor = System.Drawing.Color.OrangeRed;
            this.labSelect.Location = new System.Drawing.Point(36, 34);
            this.labSelect.Name = "labSelect";
            this.labSelect.Size = new System.Drawing.Size(56, 19);
            this.labSelect.TabIndex = 6;
            this.labSelect.Text = "PD-01";
            // 
            // lb_AccessaryName
            // 
            this.lb_AccessaryName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_AccessaryName.Location = new System.Drawing.Point(22, 88);
            this.lb_AccessaryName.Name = "lb_AccessaryName";
            this.lb_AccessaryName.Size = new System.Drawing.Size(121, 35);
            this.lb_AccessaryName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lb_AccessaryName.TabIndex = 7;
            this.lb_AccessaryName.Text = "辅料名称 :";
            this.lb_AccessaryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_AccessaryName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cb_AccessaryName
            // 
            this.cb_AccessaryName.DataSource = null;
            this.cb_AccessaryName.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cb_AccessaryName.FillColor = System.Drawing.Color.White;
            this.cb_AccessaryName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_AccessaryName.Location = new System.Drawing.Point(150, 90);
            this.cb_AccessaryName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_AccessaryName.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb_AccessaryName.Name = "cb_AccessaryName";
            this.cb_AccessaryName.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cb_AccessaryName.RectColor = System.Drawing.Color.Black;
            this.cb_AccessaryName.Size = new System.Drawing.Size(307, 31);
            this.cb_AccessaryName.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.cb_AccessaryName.StyleCustomMode = true;
            this.cb_AccessaryName.TabIndex = 8;
            this.cb_AccessaryName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cb_AccessaryName.SelectedIndexChanged += new System.EventHandler(this.cb_AccessaryName_SelectedIndexChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblState.Location = new System.Drawing.Point(22, 318);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(58, 20);
            this.lblState.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.lblState.TabIndex = 5;
            this.lblState.Text = "新料号 :";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // InputAccessarySN_Form
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(494, 366);
            this.ControlBox = false;
            this.ControlBoxFillHoverColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.cb_AccessaryName);
            this.Controls.Add(this.lb_AccessaryName);
            this.Controls.Add(this.labSelect);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lb_New_SN);
            this.Controls.Add(this.lb_Old_SN);
            this.Controls.Add(this.txtOldSN);
            this.Controls.Add(this.tb_Opeartor);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.txtNewSN);
            this.Controls.Add(this.lb_Operator);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputAccessarySN_Form";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.RectColor = System.Drawing.Color.Gray;
            this.ShowTitle = false;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.Gray;
            this.TitleHeight = 29;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 494, 139);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        private ProxyTools.SunnyUI.Controls.UILabel lb_Operator;
        private ProxyTools.SunnyUI.Controls.UITextBox txtNewSN;
        private ProxyTools.SunnyUI.Controls.UIButton bt_Cancel;
        private ProxyTools.SunnyUI.Controls.UIButton bt_OK;
        private SunnyUI.Controls.UITextBox tb_Opeartor;
        private SunnyUI.Controls.UITextBox txtOldSN;
        private SunnyUI.Controls.UILabel lb_Old_SN;
        private SunnyUI.Controls.UILabel lb_New_SN;
        private System.Windows.Forms.Label labSelect;
        private SunnyUI.Controls.UILabel lb_AccessaryName;
        private SunnyUI.Controls.UIComboBox cb_AccessaryName;
        private SunnyUI.Controls.UILabel lblState;
    }
}