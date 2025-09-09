using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.FormMain
{
    partial class DevMainForm
    {

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;



        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.tBoxStationIdx = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabState = new System.Windows.Forms.TabControl();
            this.tlpQualify = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnAutoSw = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UISwitchStyle();
            this.pnlMain = new Lead.CPrim.ProxyTools.SunnyUI.Controls.UIPanel();
            this.tabMain = new Sunny.UI.UITabControl();
            this.tPageState = new System.Windows.Forms.TabPage();
            this.tPageQualify = new System.Windows.Forms.TabPage();
            this.tlpMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tPageState.SuspendLayout();
            this.tPageQualify.SuspendLayout();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(388, 2);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(1305, 28);
            this.miniToolStrip.TabIndex = 0;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(171, 40);
            this.textBox11.Margin = new System.Windows.Forms.Padding(4);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(129, 21);
            this.textBox11.TabIndex = 20;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tBoxStationIdx
            // 
            this.tBoxStationIdx.Location = new System.Drawing.Point(486, 40);
            this.tBoxStationIdx.Margin = new System.Windows.Forms.Padding(4);
            this.tBoxStationIdx.Name = "tBoxStationIdx";
            this.tBoxStationIdx.Size = new System.Drawing.Size(129, 21);
            this.tBoxStationIdx.TabIndex = 20;
            this.tBoxStationIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Location = new System.Drawing.Point(7, 43);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 19, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 15);
            this.label17.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(322, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 19, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(6, 79);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 19, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 23;
            // 
            // tabState
            // 
            this.tabState.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabState.Font = new System.Drawing.Font("微软雅黑", 8.8F, System.Drawing.FontStyle.Bold);
            this.tabState.Location = new System.Drawing.Point(0, 0);
            this.tabState.Margin = new System.Windows.Forms.Padding(0);
            this.tabState.Name = "tabState";
            this.tabState.Padding = new System.Drawing.Point(0, 0);
            this.tabState.SelectedIndex = 0;
            this.tabState.Size = new System.Drawing.Size(1000, 574);
            this.tabState.TabIndex = 1;
            // 
            // tlpQualify
            // 
            this.tlpQualify.ColumnCount = 1;
            this.tlpQualify.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQualify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQualify.Location = new System.Drawing.Point(0, 0);
            this.tlpQualify.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQualify.Name = "tlpQualify";
            this.tlpQualify.RowCount = 1;
            this.tlpQualify.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQualify.Size = new System.Drawing.Size(1000, 574);
            this.tlpQualify.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.LightGray;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.btnAutoSw, 0, 0);
            this.tlpMain.Controls.Add(this.pnlMain, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 600);
            this.tlpMain.TabIndex = 12;
            // 
            // btnAutoSw
            // 
            this.btnAutoSw.BackColor = System.Drawing.Color.LightGray;
            this.btnAutoSw.Checked = true;
            this.btnAutoSw.CornerRadius = 3;
            this.btnAutoSw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoSw.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAutoSw.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAutoSw.Location = new System.Drawing.Point(0, 0);
            this.btnAutoSw.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutoSw.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAutoSw.Name = "btnAutoSw";
            this.btnAutoSw.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnAutoSw.Size = new System.Drawing.Size(150, 26);
            this.btnAutoSw.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.btnAutoSw.TabIndex = 7;
            this.btnAutoSw.Text = "uiSwitchStyle3";
            this.btnAutoSw.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAutoSw.CheckedChanged += new System.EventHandler(this.btnAutoSw_CheckedChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.tabMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlMain.Location = new System.Drawing.Point(0, 26);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Radius = 0;
            this.pnlMain.RadiusSides = Lead.CPrim.ProxyTools.UICornerRadiusSides.None;
            this.pnlMain.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.pnlMain.Size = new System.Drawing.Size(1000, 574);
            this.pnlMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.pnlMain.TabIndex = 14;
            this.pnlMain.Text = null;
            this.pnlMain.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tPageState);
            this.tabMain.Controls.Add(this.tPageQualify);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabMain.FillColor = System.Drawing.Color.Transparent;
            this.tabMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.MainPage = "";
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1000, 574);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.tabMain.StyleCustomMode = true;
            this.tabMain.TabIndex = 13;
            this.tabMain.TabVisible = false;
            this.tabMain.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tPageState
            // 
            this.tPageState.BackColor = System.Drawing.Color.Transparent;
            this.tPageState.Controls.Add(this.tabState);
            this.tPageState.Location = new System.Drawing.Point(0, 0);
            this.tPageState.Margin = new System.Windows.Forms.Padding(0);
            this.tPageState.Name = "tPageState";
            this.tPageState.Size = new System.Drawing.Size(1000, 574);
            this.tPageState.TabIndex = 0;
            this.tPageState.Text = "状态";
            // 
            // tPageQualify
            // 
            this.tPageQualify.BackColor = System.Drawing.Color.Transparent;
            this.tPageQualify.Controls.Add(this.tlpQualify);
            this.tPageQualify.Location = new System.Drawing.Point(0, 0);
            this.tPageQualify.Name = "tPageQualify";
            this.tPageQualify.Size = new System.Drawing.Size(1000, 574);
            this.tPageQualify.TabIndex = 2;
            this.tPageQualify.Text = "验证";
            // 
            // DevMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DevMainForm";
            this.RectColor = System.Drawing.Color.Transparent;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "Lead";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DevMainForm_FormClosed);
            this.Load += new System.EventHandler(this.DevMainForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tPageState.ResumeLayout(false);
            this.tPageQualify.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private ToolStrip miniToolStrip;

        private TextBox textBox11;

        private TextBox tBoxStationIdx;

        private Label label17;

        private Label label2;

        private Label label10;

        private TableLayoutPanel tlpQualify;

        private TableLayoutPanel tlpMain;
        private TabControl tabState;
        private Sunny.UI.UITabControl tabMain;
        private TabPage tPageState;
        private TabPage tPageQualify;
        private ProxyTools.SunnyUI.Controls.UIPanel pnlMain;
        private ProxyTools.SunnyUI.Controls.UISwitchStyle btnAutoSw;
    }
}
