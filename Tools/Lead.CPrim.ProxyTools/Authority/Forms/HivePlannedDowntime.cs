using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority.Forms
{
    public partial class HivePlannedDowntime : UIForm
    {
        #region Field
        string[] planDtItems = new string[] {
            "Daily Maintenance (PD-01)",
            "Value Change (PD-04)",
            "Stress Test (PD-05)",
            "Consumable Part Replacement (PD-07)",
            "Material Replacement (PD-08)",
            "Weekly Maintenance (PD-09)",
            "LAD (PD-11)",
            "CCD Repeatability Testing (PD-13)",
            "Uploaded Hash Keys to MES (PD-15)",
            /*"Other (PD-101)"*/ };
        UIButton[] btns = new UIButton[] { };
        private List<string> selects = new List<string>();
        #endregion



        #region Ctor
        public HivePlannedDowntime()
        {
            InitializeComponent();
            btns = new UIButton[] { btnOK, btnCancel };
            SetStyle();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region System_Event

        private void HivePlannedDowntime_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        #endregion



        #region Button_Event
        private void bt_OK_Click(object sender, EventArgs e)
        {
            selects.Clear();

            cbGroupPlanDT.SelectedItems.ForEach(p => selects.Add(p.ToString()));
            if (selects.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            selects.Clear();
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>获取点击结果</summary>
        /// <returns>true：已选中；false：未选择</returns>
        public List<string> GetResult()
        {
            List<string> selectItem = new List<string>();

            selects.ForEach(p => selectItem.Add(p));
            return selectItem;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>设置样式</summary>
        private void SetStyle()
        {
            TitleColor = Color.WhiteSmoke;
            TitleForeColor = Color.FromArgb(64, 64, 64);
            TitleFont = new Font("微软雅黑", 14.0f, FontStyle.Bold);
            BackColor = Color.FromArgb(248, 248, 248);
            RectColor = Color.Gray;
            ControlBoxForeColor = Color.FromArgb(64, 64, 64);

            //cbGroupPlanDT.Style = UIStyle.Gray;
            //cbGroupPlanDT.FillColor = this.BackColor;
            //cbGroupPlanDT.RectColor = Color.Transparent;


            foreach (var btn in btns)
            {
                btn.Style = UIStyle.Gray;
                btn.FillColor = BackColor;
                btn.ForeColor = Color.FromArgb(64, 64, 64);
                btn.Radius = 10;
                btn.ForeHoverColor = BackColor;
                btn.FillHoverColor = Color.FromArgb(26, 137, 255);
                btn.FillPressColor = Color.FromArgb(26, 137, 255);
                btn.FillSelectedColor = Color.FromArgb(26, 137, 255);
                btn.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            }
        }
        #endregion

        public void OnLanguageChanged()
        {
            cbGroupPlanDT.Clear();
            planDtItems.ToList().ForEach(p => cbGroupPlanDT.Items.Add(NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HivePlannedDowntime_" + p, p)));
            this.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_Authority_Forms_HivePlannedDowntime_Title", "Planned Downtime 选项");
        }
    }
}
