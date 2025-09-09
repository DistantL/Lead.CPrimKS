
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;

namespace Lead.CPrim.Controls
{
    partial class GDIFrm
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
            this.btnGradientColors = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIButton();
            this.lblStart = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cpStart = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.lblEnd = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILabel();
            this.cpEnd = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.txtCount = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UITextBox();
            this.uiLine1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UILine();
            this.uiColorPicker1 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker2 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker3 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker4 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker5 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker6 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker7 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker8 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker9 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.uiColorPicker10 = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIColorPicker();
            this.SuspendLayout();
            // 
            // btnGradientColors
            // 
            this.btnGradientColors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGradientColors.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGradientColors.Location = new System.Drawing.Point(38, 58);
            this.btnGradientColors.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnGradientColors.Name = "btnGradientColors";
            this.btnGradientColors.Size = new System.Drawing.Size(139, 35);
            this.btnGradientColors.TabIndex = 0;
            this.btnGradientColors.Text = "GradientColors";
            this.btnGradientColors.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGradientColors.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnGradientColors.Click += new System.EventHandler(this.btnGradientColors_Click);
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStart.Location = new System.Drawing.Point(207, 64);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(100, 23);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "startColor";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cpStart
            // 
            this.cpStart.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cpStart.FillColor = System.Drawing.Color.White;
            this.cpStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpStart.Location = new System.Drawing.Point(337, 60);
            this.cpStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpStart.MinimumSize = new System.Drawing.Size(63, 0);
            this.cpStart.Name = "cpStart";
            this.cpStart.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cpStart.Size = new System.Drawing.Size(115, 31);
            this.cpStart.TabIndex = 2;
            this.cpStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblEnd
            // 
            this.lblEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEnd.Location = new System.Drawing.Point(482, 64);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(100, 23);
            this.lblEnd.TabIndex = 1;
            this.lblEnd.Text = "endColor";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEnd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cpEnd
            // 
            this.cpEnd.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cpEnd.FillColor = System.Drawing.Color.White;
            this.cpEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cpEnd.Location = new System.Drawing.Point(612, 60);
            this.cpEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpEnd.MinimumSize = new System.Drawing.Size(63, 0);
            this.cpEnd.Name = "cpEnd";
            this.cpEnd.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cpEnd.Size = new System.Drawing.Size(115, 31);
            this.cpEnd.TabIndex = 2;
            this.cpEnd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCount
            // 
            this.txtCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCount.Location = new System.Drawing.Point(757, 61);
            this.txtCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCount.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCount.Name = "txtCount";
            this.txtCount.ShowText = false;
            this.txtCount.Size = new System.Drawing.Size(181, 29);
            this.txtCount.TabIndex = 3;
            this.txtCount.Watermark = "颜色数量，最大10种";
            this.txtCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(38, 8);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(900, 29);
            this.uiLine1.TabIndex = 5;
            this.uiLine1.Text = "GradientColors";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker1
            // 
            this.uiColorPicker1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker1.FillColor = System.Drawing.Color.White;
            this.uiColorPicker1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker1.Location = new System.Drawing.Point(38, 113);
            this.uiColorPicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker1.Name = "uiColorPicker1";
            this.uiColorPicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker1.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker1.TabIndex = 6;
            this.uiColorPicker1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker2
            // 
            this.uiColorPicker2.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker2.FillColor = System.Drawing.Color.White;
            this.uiColorPicker2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker2.Location = new System.Drawing.Point(130, 113);
            this.uiColorPicker2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker2.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker2.Name = "uiColorPicker2";
            this.uiColorPicker2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker2.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker2.TabIndex = 6;
            this.uiColorPicker2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker3
            // 
            this.uiColorPicker3.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker3.FillColor = System.Drawing.Color.White;
            this.uiColorPicker3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker3.Location = new System.Drawing.Point(222, 113);
            this.uiColorPicker3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker3.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker3.Name = "uiColorPicker3";
            this.uiColorPicker3.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker3.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker3.TabIndex = 6;
            this.uiColorPicker3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker4
            // 
            this.uiColorPicker4.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker4.FillColor = System.Drawing.Color.White;
            this.uiColorPicker4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker4.Location = new System.Drawing.Point(314, 113);
            this.uiColorPicker4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker4.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker4.Name = "uiColorPicker4";
            this.uiColorPicker4.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker4.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker4.TabIndex = 6;
            this.uiColorPicker4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker5
            // 
            this.uiColorPicker5.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker5.FillColor = System.Drawing.Color.White;
            this.uiColorPicker5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker5.Location = new System.Drawing.Point(406, 113);
            this.uiColorPicker5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker5.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker5.Name = "uiColorPicker5";
            this.uiColorPicker5.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker5.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker5.TabIndex = 6;
            this.uiColorPicker5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker6
            // 
            this.uiColorPicker6.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker6.FillColor = System.Drawing.Color.White;
            this.uiColorPicker6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker6.Location = new System.Drawing.Point(498, 113);
            this.uiColorPicker6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker6.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker6.Name = "uiColorPicker6";
            this.uiColorPicker6.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker6.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker6.TabIndex = 6;
            this.uiColorPicker6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker7
            // 
            this.uiColorPicker7.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker7.FillColor = System.Drawing.Color.White;
            this.uiColorPicker7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker7.Location = new System.Drawing.Point(590, 113);
            this.uiColorPicker7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker7.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker7.Name = "uiColorPicker7";
            this.uiColorPicker7.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker7.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker7.TabIndex = 6;
            this.uiColorPicker7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker8
            // 
            this.uiColorPicker8.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker8.FillColor = System.Drawing.Color.White;
            this.uiColorPicker8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker8.Location = new System.Drawing.Point(682, 113);
            this.uiColorPicker8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker8.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker8.Name = "uiColorPicker8";
            this.uiColorPicker8.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker8.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker8.TabIndex = 6;
            this.uiColorPicker8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker9
            // 
            this.uiColorPicker9.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker9.FillColor = System.Drawing.Color.White;
            this.uiColorPicker9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker9.Location = new System.Drawing.Point(774, 113);
            this.uiColorPicker9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker9.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker9.Name = "uiColorPicker9";
            this.uiColorPicker9.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker9.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker9.TabIndex = 6;
            this.uiColorPicker9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiColorPicker10
            // 
            this.uiColorPicker10.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker10.FillColor = System.Drawing.Color.White;
            this.uiColorPicker10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker10.Location = new System.Drawing.Point(866, 113);
            this.uiColorPicker10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker10.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker10.Name = "uiColorPicker10";
            this.uiColorPicker10.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker10.Size = new System.Drawing.Size(68, 31);
            this.uiColorPicker10.TabIndex = 6;
            this.uiColorPicker10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // GDIFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.uiColorPicker10);
            this.Controls.Add(this.uiColorPicker9);
            this.Controls.Add(this.uiColorPicker8);
            this.Controls.Add(this.uiColorPicker7);
            this.Controls.Add(this.uiColorPicker6);
            this.Controls.Add(this.uiColorPicker5);
            this.Controls.Add(this.uiColorPicker4);
            this.Controls.Add(this.uiColorPicker3);
            this.Controls.Add(this.uiColorPicker2);
            this.Controls.Add(this.uiColorPicker1);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.cpEnd);
            this.Controls.Add(this.cpStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.btnGradientColors);
            this.Name = "GDIFrm";
            this.Size = new System.Drawing.Size(960, 1000);
            this.ResumeLayout(false);

        }

        #endregion

        private ProxyTools.SunnyUI.Controls.UIButton btnGradientColors;
        private ProxyTools.SunnyUI.Controls.UILabel lblStart;
        private UIColorPicker cpStart;
        private ProxyTools.SunnyUI.Controls.UILabel lblEnd;
        private UIColorPicker cpEnd;
        private ProxyTools.SunnyUI.Controls.UITextBox txtCount;
        private ProxyTools.SunnyUI.Controls.UILine uiLine1;
        private UIColorPicker uiColorPicker1;
        private UIColorPicker uiColorPicker2;
        private UIColorPicker uiColorPicker3;
        private UIColorPicker uiColorPicker4;
        private UIColorPicker uiColorPicker5;
        private UIColorPicker uiColorPicker6;
        private UIColorPicker uiColorPicker7;
        private UIColorPicker uiColorPicker8;
        private UIColorPicker uiColorPicker9;
        private UIColorPicker uiColorPicker10;
    }
}
