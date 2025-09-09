using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.ShowAtlasCurve.Controls
{
    partial class ShowConfigControl
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
            this.btnApply = new System.Windows.Forms.Button();
            this.cbChartNum = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtAtlas4Name = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtAtlas3Name = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtAtlas2Name = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.txtAtlas1Name = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAtlasNum = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAtlasPath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnSavePath = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.lblName = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.uiLabel1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.txtAtlasPath2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.btnSavePath2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISymbolButton();
            this.uiLabel2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cbEnableYValue = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UICheckBox();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnApply.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApply.Location = new System.Drawing.Point(0, 414);
            this.btnApply.Margin = new System.Windows.Forms.Padding(1);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(750, 35);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbChartNum
            // 
            this.cbChartNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChartNum.FormattingEnabled = true;
            this.cbChartNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbChartNum.Location = new System.Drawing.Point(200, 66);
            this.cbChartNum.Name = "cbChartNum";
            this.cbChartNum.Size = new System.Drawing.Size(124, 35);
            this.cbChartNum.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(38, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "曲线数量";
            // 
            // txtYValue
            // 
            this.txtYValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYValue.Location = new System.Drawing.Point(200, 117);
            this.txtYValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtYValue.Name = "txtYValue";
            this.txtYValue.ShowText = false;
            this.txtYValue.Size = new System.Drawing.Size(124, 29);
            this.txtYValue.Style = UIStyle.Custom;
            this.txtYValue.TabIndex = 13;
            this.txtYValue.Watermark = "默认值：0.4";
            this.txtYValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAtlas4Name
            // 
            this.txtAtlas4Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAtlas4Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAtlas4Name.Location = new System.Drawing.Point(495, 261);
            this.txtAtlas4Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAtlas4Name.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAtlas4Name.Name = "txtAtlas4Name";
            this.txtAtlas4Name.ShowText = false;
            this.txtAtlas4Name.Size = new System.Drawing.Size(165, 29);
            this.txtAtlas4Name.Style = UIStyle.Custom;
            this.txtAtlas4Name.TabIndex = 13;
            this.txtAtlas4Name.Watermark = "Atlas4名称";
            this.txtAtlas4Name.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAtlas3Name
            // 
            this.txtAtlas3Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAtlas3Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAtlas3Name.Location = new System.Drawing.Point(495, 213);
            this.txtAtlas3Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAtlas3Name.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAtlas3Name.Name = "txtAtlas3Name";
            this.txtAtlas3Name.ShowText = false;
            this.txtAtlas3Name.Size = new System.Drawing.Size(165, 29);
            this.txtAtlas3Name.Style = UIStyle.Custom;
            this.txtAtlas3Name.TabIndex = 13;
            this.txtAtlas3Name.Watermark = "Atlas3名称";
            this.txtAtlas3Name.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAtlas2Name
            // 
            this.txtAtlas2Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAtlas2Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAtlas2Name.Location = new System.Drawing.Point(495, 165);
            this.txtAtlas2Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAtlas2Name.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAtlas2Name.Name = "txtAtlas2Name";
            this.txtAtlas2Name.ShowText = false;
            this.txtAtlas2Name.Size = new System.Drawing.Size(165, 29);
            this.txtAtlas2Name.Style = UIStyle.Custom;
            this.txtAtlas2Name.TabIndex = 13;
            this.txtAtlas2Name.Watermark = "Atlas2名称";
            this.txtAtlas2Name.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAtlas1Name
            // 
            this.txtAtlas1Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAtlas1Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAtlas1Name.Location = new System.Drawing.Point(495, 117);
            this.txtAtlas1Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAtlas1Name.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAtlas1Name.Name = "txtAtlas1Name";
            this.txtAtlas1Name.ShowText = false;
            this.txtAtlas1Name.Size = new System.Drawing.Size(165, 29);
            this.txtAtlas1Name.Style = UIStyle.Custom;
            this.txtAtlas1Name.TabIndex = 13;
            this.txtAtlas1Name.Watermark = "Atlas1名称";
            this.txtAtlas1Name.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(374, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 27);
            this.label9.TabIndex = 12;
            this.label9.Text = "Atlas1名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(374, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Atlas数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(374, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "Atlas2名称";
            // 
            // cbAtlasNum
            // 
            this.cbAtlasNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtlasNum.FormattingEnabled = true;
            this.cbAtlasNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbAtlasNum.Location = new System.Drawing.Point(495, 66);
            this.cbAtlasNum.Name = "cbAtlasNum";
            this.cbAtlasNum.Size = new System.Drawing.Size(165, 35);
            this.cbAtlasNum.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(374, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 27);
            this.label6.TabIndex = 9;
            this.label6.Text = "Atlas3名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(374, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 27);
            this.label8.TabIndex = 10;
            this.label8.Text = "Atlas4名称";
            // 
            // txtAtlasPath
            // 
            this.txtAtlasPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAtlasPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAtlasPath.Location = new System.Drawing.Point(125, 318);
            this.txtAtlasPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAtlasPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAtlasPath.Name = "txtAtlasPath";
            this.txtAtlasPath.ShowText = false;
            this.txtAtlasPath.Size = new System.Drawing.Size(435, 29);
            this.txtAtlasPath.Style = UIStyle.Custom;
            this.txtAtlasPath.TabIndex = 16;
            this.txtAtlasPath.Watermark = "Atlas曲线保存位置1";
            this.txtAtlasPath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSavePath.Location = new System.Drawing.Point(571, 315);
            this.btnSavePath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(38, 35);
            this.btnSavePath.Style = UIStyle.Custom;
            this.btnSavePath.Symbol = 61761;
            this.btnSavePath.TabIndex = 17;
            this.btnSavePath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSavePath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(1);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(750, 30);
            this.lblName.Style = UIStyle.Custom;
            this.lblName.TabIndex = 18;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(38, 319);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(84, 27);
            this.uiLabel1.Style = UIStyle.Custom;
            this.uiLabel1.TabIndex = 19;
            this.uiLabel1.Text = "位置1：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAtlasPath2
            // 
            this.txtAtlasPath2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAtlasPath2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAtlasPath2.Location = new System.Drawing.Point(125, 364);
            this.txtAtlasPath2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAtlasPath2.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAtlasPath2.Name = "txtAtlasPath2";
            this.txtAtlasPath2.ShowText = false;
            this.txtAtlasPath2.Size = new System.Drawing.Size(435, 29);
            this.txtAtlasPath2.Style = UIStyle.Custom;
            this.txtAtlasPath2.TabIndex = 16;
            this.txtAtlasPath2.Watermark = "Atlas曲线保存位置2";
            this.txtAtlasPath2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSavePath2
            // 
            this.btnSavePath2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePath2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSavePath2.Location = new System.Drawing.Point(571, 361);
            this.btnSavePath2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSavePath2.Name = "btnSavePath2";
            this.btnSavePath2.Size = new System.Drawing.Size(38, 35);
            this.btnSavePath2.Style = UIStyle.Custom;
            this.btnSavePath2.Symbol = 61761;
            this.btnSavePath2.TabIndex = 17;
            this.btnSavePath2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSavePath2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSavePath2.Click += new System.EventHandler(this.btnSavePath2_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(38, 365);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(84, 27);
            this.uiLabel2.Style = UIStyle.Custom;
            this.uiLabel2.TabIndex = 19;
            this.uiLabel2.Text = "位置2：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbEnableYValue
            // 
            this.cbEnableYValue.BackColor = System.Drawing.Color.Transparent;
            this.cbEnableYValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbEnableYValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbEnableYValue.Location = new System.Drawing.Point(43, 117);
            this.cbEnableYValue.MinimumSize = new System.Drawing.Size(1, 1);
            this.cbEnableYValue.Name = "cbEnableYValue";
            this.cbEnableYValue.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.cbEnableYValue.Size = new System.Drawing.Size(150, 29);
            this.cbEnableYValue.Style = UIStyle.Custom;
            this.cbEnableYValue.TabIndex = 21;
            this.cbEnableYValue.Text = "曲线Y限位";
            this.cbEnableYValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ShowConfigControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cbEnableYValue);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.txtAtlas4Name);
            this.Controls.Add(this.txtAtlas3Name);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAtlas2Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAtlas1Name);
            this.Controls.Add(this.txtYValue);
            this.Controls.Add(this.btnSavePath2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbChartNum);
            this.Controls.Add(this.txtAtlasPath2);
            this.Controls.Add(this.cbAtlasNum);
            this.Controls.Add(this.txtAtlasPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnApply);
            this.FillColor = System.Drawing.SystemColors.Control;
            this.Name = "ShowConfigControl";
            this.Size = new System.Drawing.Size(750, 449);
            this.Style = UIStyle.Custom;
            this.Load += new System.EventHandler(this.ShowConfigControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbChartNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAtlasNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private UITextBox txtAtlas1Name;
        private System.Windows.Forms.Label label9;
        private UITextBox txtAtlas4Name;
        private UITextBox txtAtlas3Name;
        private UITextBox txtAtlas2Name;
        private UITextBox txtAtlasPath;
        private UISymbolButton btnSavePath;
        private UILabel lblName;
        private UITextBox txtYValue;
        private UILabel uiLabel1;
        private UITextBox txtAtlasPath2;
        private UISymbolButton btnSavePath2;
        private UILabel uiLabel2;
        private UICheckBox cbEnableYValue;
    }
}
