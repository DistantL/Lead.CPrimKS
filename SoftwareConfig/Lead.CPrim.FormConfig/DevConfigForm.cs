using Lead.CPrim.CmpTrigHelper;
using Lead.CPrim.FaiHelper;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.LocalizationService;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.StationCommon;
using System;
using System.ComponentModel;
using System.Windows.Forms;

public class DevConfigForm : UIPage
{
    #region Ctor
    /// <summary>Ctor无参</summary>
    public DevConfigForm()
    {
        InitializeComponent();
        InitilizeUI();
        AuthorityManager.OnUpdateLevel += OnUpdatePermissionLv_Handle;
    }
    #endregion



    #region System_Event
    /// <summary>FormClosing事件</summary>
    private void DevConfigForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
    /// <summary>Load事件</summary>
    private void DevConfigForm_Load(object sender, EventArgs e)
    {
        if (SwManager.Instance.SoftwareConfigUi != null)
        {
            SwManager.Instance.SoftwareConfigUi.Dock = DockStyle.Fill;
            Invoke(new Action(() =>
            {
                tPageSWConfig.Controls.Add(SwManager.Instance.SoftwareConfigUi);
            }));
        }
        StationManager.Instance.StationsConfigUi.Dock = DockStyle.Fill;
        tPageStationConfig.Controls.Add(StationManager.Instance.StationsConfigUi);
        if (SwManager.Instance.CmpTrigConfigEnable && CmpTrigManager.Instance.CmpTrigConfigUi != null)
        {
            CmpTrigManager.Instance.CmpTrigConfigUi.Dock = DockStyle.Fill;
            Invoke(new Action(() =>
            {
                tPageCmpTrig.Controls.Add(CmpTrigManager.Instance.CmpTrigConfigUi);
            }));
        }
        else
        {
            tPageCmpTrig.Parent = null;
        }
        if (SwManager.Instance.FaiConfigEnable && FaiManager.Instance.FaiConfigUi != null)
        {
            FaiManager.Instance.FaiConfigUi.Dock = DockStyle.Fill;
            Invoke(new Action(() =>
            {
                panelFaiConfigs.Controls.Add(FaiManager.Instance.FaiConfigUi);
            }));
        }
        else
        {
            tPageFaiConfig.Parent = null;
        }
        if (!AuthorityManager.Instance.VerifyLevel3Permission(false))
        {
            tPageSWConfig.Parent = null;
        }
        if (!AuthorityManager.Instance.VerifyLevel2Permission(false))
        {
            tPageStationConfig.Parent = null;
        }
    } 
    #endregion



    #region Others
    /// <summary>权限等级改变时发生</summary>
    private void OnUpdatePermissionLv_Handle(OpLevel level)
    {
        if (InvokeRequired)
        {
            BeginInvoke(new Action<OpLevel>(OnUpdatePermissionLv_Handle), level);
            return;
        }
        tPageStationConfig.Parent = null;
        tPageSWConfig.Parent = null;
        tPageFaiConfig.Parent = null;
        tPageCmpTrig.Parent = null;
        //系统设置=》开发者权限
        if (AuthorityManager.Instance.VerifyLevel3Permission(false))
        {
            tPageSWConfig.Parent = tabConfig;
        }
        //工站配置=》管理员权限
        if (AuthorityManager.Instance.VerifyLevel2Permission(false))
        {
            tPageStationConfig.Parent = tabConfig;
        }
        //比较触发&FAI配置=》维护员权限
        if (AuthorityManager.Instance.VerifyLevel1Permission(false))
        {
            if (SwManager.Instance.FaiConfigEnable)
            {
                tPageFaiConfig.Parent = tabConfig;
            }
            if (SwManager.Instance.CmpTrigConfigEnable)
            {
                tPageCmpTrig.Parent = tabConfig;
            }
        }
    }
    /// <summary>英汉互译</summary>
    private void InitilizeUI()
    {
        Text = NLocalizer.GetString("View_DevConfigForm_FormText", "DevConfigForm");
    }
    #endregion










    #region System
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    private ContextMenuStrip contxtMenuStrip;

    private ToolStripMenuItem addToolStripMenuItem;

    private ToolStripMenuItem removeStationToolStripMenuItem;

    private ToolStripMenuItem applyToolStripMenuItem;

    private ToolStripMenuItem applyToolStripMenuItem1;

    private TabControl tabConfig;

    private TabPage tPageCmpTrig;

    private TabPage tPageSWConfig;

    private TabPage tPageFaiConfig;

    private Panel panelFaiConfigs;

    private TabPage tPageStationConfig;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevConfigForm));
            this.contxtMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabConfig = new System.Windows.Forms.TabControl();
            this.tPageSWConfig = new System.Windows.Forms.TabPage();
            this.tPageStationConfig = new System.Windows.Forms.TabPage();
            this.tPageCmpTrig = new System.Windows.Forms.TabPage();
            this.tPageFaiConfig = new System.Windows.Forms.TabPage();
            this.panelFaiConfigs = new System.Windows.Forms.Panel();
            this.contxtMenuStrip.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.tPageFaiConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // contxtMenuStrip
            // 
            this.contxtMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contxtMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeStationToolStripMenuItem,
            this.applyToolStripMenuItem,
            this.applyToolStripMenuItem1});
            this.contxtMenuStrip.Name = "contxtMenuStrip";
            this.contxtMenuStrip.Size = new System.Drawing.Size(194, 92);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addToolStripMenuItem.Text = "Add Station";
            // 
            // removeStationToolStripMenuItem
            // 
            this.removeStationToolStripMenuItem.Name = "removeStationToolStripMenuItem";
            this.removeStationToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.removeStationToolStripMenuItem.Text = "Remove Station";
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.applyToolStripMenuItem.Text = "Show Station Config";
            // 
            // applyToolStripMenuItem1
            // 
            this.applyToolStripMenuItem1.Name = "applyToolStripMenuItem1";
            this.applyToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.applyToolStripMenuItem1.Text = "Create Station";
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.tPageSWConfig);
            this.tabConfig.Controls.Add(this.tPageStationConfig);
            this.tabConfig.Controls.Add(this.tPageCmpTrig);
            this.tabConfig.Controls.Add(this.tPageFaiConfig);
            this.tabConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfig.Location = new System.Drawing.Point(0, 0);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.SelectedIndex = 0;
            this.tabConfig.Size = new System.Drawing.Size(1284, 681);
            this.tabConfig.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabConfig.TabIndex = 2;
            // 
            // tPageSWConfig
            // 
            this.tPageSWConfig.Location = new System.Drawing.Point(4, 26);
            this.tPageSWConfig.Name = "tPageSWConfig";
            this.tPageSWConfig.Size = new System.Drawing.Size(1276, 651);
            this.tPageSWConfig.TabIndex = 7;
            this.tPageSWConfig.Text = "系统配置";
            this.tPageSWConfig.UseVisualStyleBackColor = true;
            // 
            // tPageStationConfig
            // 
            this.tPageStationConfig.Location = new System.Drawing.Point(4, 26);
            this.tPageStationConfig.Name = "tPageStationConfig";
            this.tPageStationConfig.Size = new System.Drawing.Size(1276, 651);
            this.tPageStationConfig.TabIndex = 9;
            this.tPageStationConfig.Text = "工站配置";
            this.tPageStationConfig.UseVisualStyleBackColor = true;
            // 
            // tPageCmpTrig
            // 
            this.tPageCmpTrig.Location = new System.Drawing.Point(4, 26);
            this.tPageCmpTrig.Name = "tPageCmpTrig";
            this.tPageCmpTrig.Size = new System.Drawing.Size(1276, 651);
            this.tPageCmpTrig.TabIndex = 6;
            this.tPageCmpTrig.Text = "比较触发";
            this.tPageCmpTrig.UseVisualStyleBackColor = true;
            // 
            // tPageFaiConfig
            // 
            this.tPageFaiConfig.Controls.Add(this.panelFaiConfigs);
            this.tPageFaiConfig.Location = new System.Drawing.Point(4, 26);
            this.tPageFaiConfig.Name = "tPageFaiConfig";
            this.tPageFaiConfig.Size = new System.Drawing.Size(1276, 651);
            this.tPageFaiConfig.TabIndex = 8;
            this.tPageFaiConfig.Text = "FAI配置";
            this.tPageFaiConfig.UseVisualStyleBackColor = true;
            // 
            // panelFaiConfigs
            // 
            this.panelFaiConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFaiConfigs.Location = new System.Drawing.Point(0, 0);
            this.panelFaiConfigs.Name = "panelFaiConfigs";
            this.panelFaiConfigs.Size = new System.Drawing.Size(1276, 651);
            this.panelFaiConfigs.TabIndex = 0;
            // 
            // DevConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.tabConfig);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DevConfigForm";
            this.Style = UIStyle.Custom;
            this.Text = "软件配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DevConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.DevConfigForm_Load);
            this.contxtMenuStrip.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tPageFaiConfig.ResumeLayout(false);
            this.ResumeLayout(false);

    } 
    #endregion
}