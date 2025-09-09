using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.PrimCommon
{
    public partial class PrimDisplay : UserControl
    {
        #region Field
        /// <summary>基元图标</summary>
        private Image _icon = null;

        /// <summary>基元名称</summary>
        private string _name = "";

        /// <summary>基元</summary>
        private IPrim _prim = null;

        /// <summary>基元显示分组</summary>
        private string _primGroup = "";

        /// <summary>基元Id</summary>
        private Guid _primID;

        /// <summary>基元显示名称</summary>
        private string _primType = "";

        /// <summary>图标索引</summary>
        private int _primIndex = 0;
        #endregion



        #region Prop
        /// <summary>基元</summary>
        public IPrim UIPrim { get { return _prim; } set { _prim = value; } }
        /// <summary>基元显示分组</summary>
        public string UIPrimGroup { get { return _primGroup; } set { _primGroup = value; } }
        /// <summary>基元图标</summary>
        public Image UIPrimIcon { get { return _icon; } set { _icon = value; pBoxIcon.Image = value; } }
        /// <summary>基元Id</summary>
        public Guid UIPrimID { get { return _primID; } set { _primID = value; } }
        /// <summary>基元名称</summary>
        public string UIPrimName { get { return _name; } set { _name = value; txtName.Text = _name; } }
        /// <summary>基元显示名称</summary>
        public string UIPrimType { get { return _primType; } set { _primType = value; } }
        #endregion



        #region Define_Event
        /// <summary>基元名称改变时发生</summary>
        public event PrimDisplayControlChangeName OnPrimDisplayControlChangeName;

        /// <summary>对基元进行操作时发生</summary>
        public event PrimClickEventHander OnPrimDisplayControlSelectClick;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public PrimDisplay()
        {
            InitializeComponent();
        }
        #endregion


        #region System_Event
        /// <summary>Load事件</summary>
        private void PrimDisplay_Load(object sender, EventArgs e)
        {
            _primIndex = UIPrim.CurrentImageIndex;
        }

        /// <summary>基元名称修改</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if(!AuthorityManager.Instance.VerifyLevel3Permission())
            {
                txtName.Text = _prim.Name;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string name = txtName.Text.Trim();
                    if (string.IsNullOrEmpty(name))
                    {
                        throw new Exception(NLocalizer.GetString("Lead_CPrim_PrimCommon_PrimDisplay_PrimNameIsEmpty", "名称不可以为空"));
                    }

                    if (_prim == null || PrimsManager.Instance.GetPrimByName(name) != null)
                    {
                        return;
                    }

                    UIPrimName = txtName.Text;
                    _prim.Name = txtName.Text;

                    OnPrimDisplayControlChangeName?.Invoke(UIPrimID, _prim.Name);
                }
                catch (Exception ex)
                {
                    txtName.Text = _prim.Name;
                    PrimsManager.Instance.LogAdd(NLocalizer.GetString("Lead_CPrim_PrimCommon_PrimDisplay_PrimNameSaveFail", "基元名称保存出错:")+ ex.Message, LogLevel.Warn, 0, true);
                }
            }
        }
        #endregion



        #region Button_Event
        /// <summary>图标双击</summary>
        private void pBoxIcon_DoubleClick(object sender, EventArgs e)
        {
            OnPrimDisplayControlSelectClick?.Invoke(0, UIPrimName, UIPrimID);
        }
        /// <summary>配置界面_显示</summary>
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnPrimDisplayControlSelectClick?.Invoke(2, UIPrimName, UIPrimID);
        }
        /// <summary>配置界面_隐藏</summary>
        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnPrimDisplayControlSelectClick?.Invoke(12, UIPrimName, UIPrimID);
        }
        /// <summary>输出界面_显示</summary>
        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OnPrimDisplayControlSelectClick?.Invoke(3, UIPrimName, UIPrimID);
        }
        /// <summary>输出界面_隐藏</summary>
        private void hideToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OnPrimDisplayControlSelectClick?.Invoke(13, UIPrimName, UIPrimID);
        }
        /// <summary>调试界面_显示</summary>
        private void showToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OnPrimDisplayControlSelectClick?.Invoke(1, UIPrimName, UIPrimID);
        }
        /// <summary>调试界面_隐藏</summary>
        private void hideToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OnPrimDisplayControlSelectClick?.Invoke(11, UIPrimName, UIPrimID);
        }
        /// <summary>切换图标</summary>
        private void tsmiChangeIcon_Click(object sender, EventArgs e)
        {
            try
            {
                IPrimCreator primCreator = PrimsManager.Instance.GetDevPrimCreator(UIPrim.PrimTypeName);
                if (primCreator == null)
                {
                    return;
                }

                if (primCreator.ConcretePrimTypeAttributes.ListIcon.Count == 1)
                {
                    return;
                }

                if (++_primIndex >= primCreator.ConcretePrimTypeAttributes.ListIcon.Count)
                {
                    _primIndex = 0;
                }
                UIPrimIcon = primCreator.ConcretePrimTypeAttributes.ListIcon[_primIndex];

                UIPrim.CurrentImageIndex = _primIndex;
            }
            catch (Exception ex)
            {
                ProxyTools.Notification.ShowError(NLocalizer.GetString("Lead_CPrim_PrimCommon_PrimDisplay_IconChangeFail", "图标切换失败 -> ") + ex.Message);
            }
        }
        /// <summary>移除</summary>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
                OnPrimDisplayControlSelectClick?.Invoke(4, UIPrimName, UIPrimID);
            }
        }
        #endregion
    }
}
