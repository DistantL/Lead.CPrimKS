
using Lead.CPrim.ProxyTools.SunnyUI.Controls;

namespace Lead.CPrim.ShowAtlasCurve.Controls
{
    partial class ShowOutputControl
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpAtlasName = new UITableLayoutPanel();
            this.lblAtlas1Status = new UILabel();
            this.lblAtlas4Status = new UILabel();
            this.lblAtlas2Status = new UILabel();
            this.lblAtlas3Status = new UILabel();
            this.tlpLayout = new UITableLayoutPanel();
            this.tlpAtlasName.SuspendLayout();
            this.tlpLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(880, 600);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpAtlasName
            // 
            this.tlpAtlasName.ColumnCount = 1;
            this.tlpAtlasName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAtlasName.Controls.Add(this.lblAtlas1Status, 0, 2);
            this.tlpAtlasName.Controls.Add(this.lblAtlas4Status, 0, 8);
            this.tlpAtlasName.Controls.Add(this.lblAtlas2Status, 0, 4);
            this.tlpAtlasName.Controls.Add(this.lblAtlas3Status, 0, 6);
            this.tlpAtlasName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAtlasName.Location = new System.Drawing.Point(880, 0);
            this.tlpAtlasName.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAtlasName.Name = "tlpAtlasName";
            this.tlpAtlasName.RowCount = 11;
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpAtlasName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpAtlasName.Size = new System.Drawing.Size(120, 600);
            this.tlpAtlasName.TabIndex = 1;
            this.tlpAtlasName.TagString = null;
            // 
            // lblAtlas1Status
            // 
            this.lblAtlas1Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAtlas1Status.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAtlas1Status.Location = new System.Drawing.Point(3, 134);
            this.lblAtlas1Status.Name = "lblAtlas1Status";
            this.lblAtlas1Status.Size = new System.Drawing.Size(114, 67);
            this.lblAtlas1Status.TabIndex = 0;
            this.lblAtlas1Status.Text = "Atlas1Status";
            this.lblAtlas1Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAtlas1Status.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblAtlas4Status
            // 
            this.lblAtlas4Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAtlas4Status.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAtlas4Status.Location = new System.Drawing.Point(3, 395);
            this.lblAtlas4Status.Name = "lblAtlas4Status";
            this.lblAtlas4Status.Size = new System.Drawing.Size(114, 67);
            this.lblAtlas4Status.TabIndex = 0;
            this.lblAtlas4Status.Text = "Atlas1Status";
            this.lblAtlas4Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAtlas4Status.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblAtlas2Status
            // 
            this.lblAtlas2Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAtlas2Status.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAtlas2Status.Location = new System.Drawing.Point(3, 221);
            this.lblAtlas2Status.Name = "lblAtlas2Status";
            this.lblAtlas2Status.Size = new System.Drawing.Size(114, 67);
            this.lblAtlas2Status.TabIndex = 0;
            this.lblAtlas2Status.Text = "Atlas1Status";
            this.lblAtlas2Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAtlas2Status.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblAtlas3Status
            // 
            this.lblAtlas3Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAtlas3Status.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAtlas3Status.Location = new System.Drawing.Point(3, 308);
            this.lblAtlas3Status.Name = "lblAtlas3Status";
            this.lblAtlas3Status.Size = new System.Drawing.Size(114, 67);
            this.lblAtlas3Status.TabIndex = 0;
            this.lblAtlas3Status.Text = "Atlas1Status";
            this.lblAtlas3Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAtlas3Status.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 2;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpLayout.Controls.Add(this.tlpMain, 0, 0);
            this.tlpLayout.Controls.Add(this.tlpAtlasName, 1, 0);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 1;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Size = new System.Drawing.Size(1000, 600);
            this.tlpLayout.TabIndex = 2;
            this.tlpLayout.TagString = null;
            // 
            // ShowOutputControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tlpLayout);
            this.Name = "ShowOutputControl";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Text = "压力曲线";
            this.Load += new System.EventHandler(this.ShowOutputControl_Load);
            this.tlpAtlasName.ResumeLayout(false);
            this.tlpLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private UILabel lblAtlas1Status;
        private UILabel lblAtlas4Status;
        private UILabel lblAtlas3Status;
        private UILabel lblAtlas2Status;
        private UITableLayoutPanel tlpAtlasName;
        private UITableLayoutPanel tlpLayout;
    }
}
