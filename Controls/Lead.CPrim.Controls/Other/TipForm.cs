using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.StationCommon;
using Lead.CPrim.TaskHelper;
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
    public partial class TipForm : Form
    {
        #region Field
        private List<TipSelectItem> _tips; 
        #endregion



        #region Prop
        public string SelectIndex_Level1
        {
            get
            {
                if (cb_SelectItems_Level1.SelectedIndex != -1)
                {
                    return _tips[cb_SelectItems_Level1.SelectedIndex].TipName;
                }
                return null;
            }
        }
        public string SelectIndex_Level2
        {
            get
            {
                if (cb_SelectItems_Level2.SelectedIndex != -1)
                {
                    return cb_SelectItems_Level2.Text;
                }
                return null;
            }
        }
        #endregion



        #region Ctor
        public TipForm()
        {
            InitializeComponent();
            this.TopLevel = true;
            lb_StartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion



        #region EventSystem
        private void TipForm_Load(object sender, EventArgs e)
        {
            cb_SelectItems_Level1.Items.Clear();
            if (_tips != null && _tips.Count > 0)
            {
                foreach (var item in _tips)
                {
                    cb_SelectItems_Level1.Items.Add(item.TipName);
                }
                cb_SelectItems_Level1.SelectedIndex = 0;
                rtb_Message.Text = _tips[0].TipShowInfo;
            }
            EventManager.SwitchStatus(SwitchStatus.RunningWithNotice);
        }

        private void TipForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventManager.SwitchStatus(SwitchStatus.ClrErr);
        }

        private void cb_SelectItems_Level1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_SelectItems_Level1.SelectedIndex != -1)
                {
                    cb_SelectItems_Level2.Items.Clear();
                    if (_tips != null && _tips.Count >= cb_SelectItems_Level1.SelectedIndex)
                    {
                        if (_tips[cb_SelectItems_Level1.SelectedIndex].TipSelectItems_Level2 != null
                            && _tips[cb_SelectItems_Level1.SelectedIndex].TipSelectItems_Level2.Count > 0)
                        {
                            foreach (var item in _tips[cb_SelectItems_Level1.SelectedIndex].TipSelectItems_Level2)
                            {
                                cb_SelectItems_Level2.Items.Add(item);
                            }
                            cb_SelectItems_Level2.SelectedIndex = 0;
                            lb_TipLevel2.Visible = true;
                            cb_SelectItems_Level2.Visible = true;
                            return;
                        }
                    }
                    lb_TipLevel2.Visible = false;
                    cb_SelectItems_Level2.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion



        #region MethodButton
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cb_SelectItems_Level1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择需要执行的动作");
                return;
            }

            if (cb_SelectItems_Level2.Items != null && cb_SelectItems_Level2.Items.Count > 0 && cb_SelectItems_Level2.SelectedIndex == -1)
            {
                MessageBox.Show("请选择需要执行的动作的子选项");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion



        #region MethodExternalUsing

        public void OnLanguageChanged()
        {
            lb_StartTimeLabel.Text = NLocalizer.GetString("Lead_CPrim_Controls_TipForm_StartTime", "开始时间:");
            lb_TipLevel2.Text = NLocalizer.GetString("Lead_CPrim_Controls_TipForm_SubItem", "子选项");
            btnConfirm.Text = NLocalizer.GetString("Lead_CPrim_Controls_TipForm_Confirm", "确认");
        }

        public void SetTips(List<TipSelectItem> tips)
        {
            _tips = tips;
        }

        public void CloseFrom()
        {
            this.BeginInvoke(new Action(() => 
            {
                this.Close();
            }));
        }
        #endregion
    }



    public class TipSelectItem
    {
        public string TipName { get; set; }

        public List<string> TipSelectItems_Level2 { get; set; }

        public string TipShowInfo { get; set; }
    }
}
