using Lead.CPrim.FaiHelper;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    public partial class ConfigForm : UIPage
    {
        #region Field
        /// <summary>按钮集合</summary>
        UIButton[] btns = new UIButton[] { };
        /// <summary>简单Fai项</summary>
        SimpleFaiConfigs _simpleFaiConfigs;
        #endregion



        #region Ctor
        public ConfigForm()
        {
            InitializeComponent();
            btns = new UIButton[] { btnEdit, btnSave };
            SetStyle();
            KeyName.ReadOnly = true;
            LSL.ReadOnly = true;
            USL.ReadOnly = true;
            AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;

            {
                dgvSpecLimit.SetStyle(false, false, false, DataGridViewAutoSizeColumnsMode.Fill, DataGridViewContentAlignment.MiddleCenter, 10.0f, FontStyle.Regular, Color.FromArgb(211, 211, 211));

                btnEdit.SetStyle(Colors.PrimaryBackColor128);
                btnSave.SetStyle(Colors.PrimaryBackColor128);
            }
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region Event_System
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            InitFai();
        }
        #endregion



        #region Event_Button
        /// <summary>编辑</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgvSpecLimit.ReadOnly = false;
            LSL.ReadOnly = false;
            USL.ReadOnly = false;
        }
        /// <summary>保存</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSpecLimit.Rows)
            {
                string name = row.Cells[0].Value?.ToString();
                if (name.IsNullOrEmpty())
                {
                    continue;
                }
                FaiConfig faiConfig = _simpleFaiConfigs.FaiConfigs.Values.FirstOrDefault(fai => fai.Name == name);
                faiConfig.TolLow = double.TryParse(row.Cells[1].Value?.ToString(), out var lsl) ? lsl : 0;
                faiConfig.TolUp = double.TryParse(row.Cells[2].Value?.ToString(), out var usl) ? usl : 0;
            }
            string currentProduct = SwManager.Instance.CurrentProduct;
            if (FaiManager.Instance.Products.ContainsKey(currentProduct))
            {
                FaiManager.Instance.ChangeCurrentProduct(currentProduct);
            }
            FaiManager.Instance.Save();
            dgvSpecLimit.ReadOnly = true;
            LSL.ReadOnly = true;
            USL.ReadOnly = true;
        }
        /// <summary>加载Fai项</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblName_DoubleClick(object sender, EventArgs e)
        {
            InitFai();
        }
        #endregion



        #region Method_Instance
        /// <summary>响应权限等级改变</summary>
        /// <param name="level"></param>
        private void InstanceUpdateLevel(OpLevel level)
        {
            SetEnable(AuthorityManager.Instance.VerifyLevel3Permission());
        }

        private void SetEnable(bool enable) 
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }

            foreach (var btn in btns)
            {
                btn.Visible = enable;
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>设置样式</summary>
        private void SetStyle()
        {
            //UIForm
            this.BackColor = Color.FromArgb(236, 236, 236);
            tlpMain.BackColor = Color.Transparent;

            pnlMachineConfigs.BackColor = Color.FromArgb(211, 211, 211);
            pnlMachineConfigs.Margin = new Padding(5, 0, 3, 0);

            tlpRight.BackColor = Color.FromArgb(211, 211, 211);
            tlpRight.Margin = new Padding(3, 0, 5, 0);

            //UIButton
            foreach (var btn in btns)
            {
                //btn.Style = UIStyle.Gray;
                //btn.FillColor = Color.FromArgb(168, 168, 168);
                //btn.ForeColor = Color.FromArgb(255, 255, 255);
                //btn.BackColor = Color.FromArgb(211, 211, 211);
                //btn.Radius = 10;
                //btn.ForeHoverColor = BackColor;
                //btn.FillHoverColor = Color.FromArgb(26, 137, 255);
                //btn.FillPressColor = Color.FromArgb(26, 137, 255);
                //btn.FillSelectedColor = Color.FromArgb(26, 137, 255);
                //btn.Font = new Font("微软雅黑", 12.0f, FontStyle.Regular);
            }
        }
        /// <summary>Fai项初始化</summary>
        private void InitFai()
        {
            string currentProduct = SwManager.Instance.CurrentProduct;
            string faiName = SwManager.Instance.ConfigFrmBindFaiName;
            if (faiName.IsNullOrEmpty())
            {
                return;
            }
            if (!FaiManager.Instance.Products.ContainsKey(currentProduct))
            {
                return;
            }
            _simpleFaiConfigs = FaiManager.Instance.Products[currentProduct].SimpleConfigs.Values.FirstOrDefault(fai => fai.Name == faiName);
            if(_simpleFaiConfigs == null)
            {
                return;
            }
            dgvSpecLimit.ClearRows();
            foreach (var fai in _simpleFaiConfigs.FaiConfigs.Values.ToList().OrderBy(f => f.Index))
            {
                int index = dgvSpecLimit.Rows.Add();
                dgvSpecLimit.Rows[index].Cells[0].Value = fai.Name;
                dgvSpecLimit.Rows[index].Cells[1].Value = fai.TolLow;
                dgvSpecLimit.Rows[index].Cells[2].Value = fai.TolUp;
            }

            dgvSpecLimit.ReadOnly = true;
        }
        #endregion
        public void OnLanguageChanged()
        {
            lblName.Text = NLocalizer.GetString("Lead_CPrim_View_ConfigForm_SpecLimits", "规格界限");
            btnEdit.Text = NLocalizer.GetString("Lead_CPrim_View_ConfigForm_Edit", "编辑");
            btnSave.Text = NLocalizer.GetString("Lead_CPrim_View_ConfigForm_Save", "保存");
            KeyName.HeaderText = NLocalizer.GetString("Lead_CPrim_View_ConfigForm_KeyName", "名称");
            LSL.HeaderText = NLocalizer.GetString("Lead_CPrim_View_ConfigForm_LSL", "下限");
            USL.HeaderText = NLocalizer.GetString("Lead_CPrim_View_ConfigForm_USL", "上限");
        }
    }
}
