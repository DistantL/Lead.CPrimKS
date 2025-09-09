using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ShowCommon
{
    /// <summary>显示基元UI配置</summary>
    public partial class ShowDisplay : UserControl
    {
        #region Field
        /// <summary>显示图标</summary>
        private Image _icon = null;
        /// <summary>显示名称</summary>
        private string _name = "";
        /// <summary>显示分组</summary>
        private string _showGroup = "";
        /// <summary>显示名称</summary>
        private string _showType = "";
        /// <summary>IShow对象</summary>
        private IShow _show = null;
        /// <summary>GUID</summary>
        private Guid _showID;
        #endregion



        #region Prop
        /// <summary>显示图标</summary>
        internal Image UIShowIcon { get { return _icon; } set { _icon = value; pBoxIcon.Image = value; } }
        /// <summary>显示名称</summary>
        internal string UIShowName { get { return _name; } set { _name = value; txtName.Text = _name; } }
        /// <summary>显示分组</summary>
        internal string UIShowGroup { get { return _showGroup; } set { _showGroup = value; } }
        /// <summary>显示名称</summary>
        internal string UIShowType { get { return _showType; } set { _showType = value; } }
        /// <summary>IShow对象</summary>
        internal IShow UIShow { get { return _show; } set { _show = value; } }
        /// <summary>GUID</summary>
        internal Guid UIShowID { get { return _showID; } set { _showID = value; } }
        #endregion



        #region Define_Event
        /// <summary>改变显示基元名称时发生</summary>
        internal event ShowControlChangeName OnShowControlChangeName;
        /// <summary>选择显示基元控件时发生</summary>
        internal event ShowClickEventHandle OnShowClick;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowDisplay()
        {
            InitializeComponent();
        }
        #endregion



        #region Button_Event
        /// <summary>图标双击</summary>
        private void pBoxIcon_DoubleClick(object sender, EventArgs e)
        {
            OnShowClick?.Invoke(0, UIShowName, UIShowID);
        }
        /// <summary>显示名称变更</summary>
        private void tbName_KeyUp(object sender, KeyEventArgs e)
        {
            if(!AuthorityManager.Instance.VerifyLevel3Permission(false))
            {
                txtName.Text = _show.Name;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string tempName = txtName.Text.Trim();
                    if (string.IsNullOrEmpty(tempName))
                    {
                        throw new Exception("名称不可以为空");
                    }

                    if (_show == null || ShowManager.Instance.GetShowByName(tempName) != null)
                    {
                        return;
                    }

                    UIShowName = tempName;
                    _show.Name = tempName;

                    OnShowControlChangeName?.Invoke(UIShowID, _show.Name);
                }
                catch (Exception ex)
                {
                    txtName.Text = _show.Name;
                    ShowManager.Instance.LogAdd("显示名称保存出错：" + ex.Message, LogLevel.Warn, 0, true);
                }
            }
        }
        /// <summary>配置界面_显示</summary>
        private void tsmShowConfigUi_Click(object sender, EventArgs e)
        {
            OnShowClick?.Invoke(2, UIShowName, UIShowID);
        }
        /// <summary>配置界面_隐藏</summary>
        private void tsmHideConfigUi_Click(object sender, EventArgs e)
        {
            OnShowClick?.Invoke(12, UIShowName, UIShowID);
        }
        /// <summary>输出界面_显示</summary>
        private void tsmShowOutputUi_Click(object sender, EventArgs e)
        {
            OnShowClick?.Invoke(3, UIShowName, UIShowID);
        }
        /// <summary>输出界面_隐藏</summary>
        private void tsmHideOutputUi_Click(object sender, EventArgs e)
        {
            OnShowClick?.Invoke(13, UIShowName, UIShowID);
        }
        /// <summary>显示_移除</summary>
        private void tsmRemoveShow_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
                OnShowClick?.Invoke(4, UIShowName, UIShowID);
            }
        }
        #endregion
    }
}
