using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ShowCommon
{
    /// <summary>显示总集合UI</summary>
    public partial class ShowToolBar : UserControl
    {
        #region Define_Del
        #endregion



        #region Define_Event
        /// <summary>单击新建显示基元时发生</summary>
        internal event CreateShowEventHandler CreateShow;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        internal ShowToolBar()
        {
            InitializeComponent();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>[ShowConfigForm]调用</summary>
        /// <param name="path">显示dll地址</param>
        /// <returns>int</returns>
        public int ShowToolBarFormLoad(string path)
        {
            int ret = ShowManager.Instance.LoadShowTypeAttributes(path);

            if (ret != 0)
            {
                return ret;
            }
            foreach (var item in ShowManager.Instance.SupportedShowTypes)
            {
                ToolStripButton btnShow = new ToolStripButton
                {
                    ImageScaling = ToolStripItemImageScaling.None,
                    AutoSize = false,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    DisplayStyle = ToolStripItemDisplayStyle.Image,
                    Image = item.Value.Icon,
                    Tag = item.Key,
                    Size = new Size(56, 52),
                    Text = item.Key
                };
                btnShow.Click += btnShow_Click;
                toolStrip.Items.Add(btnShow);
            }
            return ret;
        }
        #endregion 



        #region Method_InternalUsing
        /// <summary>显示基元单击新建按钮</summary>
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
                ToolStripButton tmp = sender as ToolStripButton;
                string devTypeName = tmp.Tag.ToString();
                this.CreateShow?.Invoke(devTypeName);
            }
        }
        /// <summary>通过拖放进行复制（未使用）</summary>
        private void btnShow_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripButton tmp = sender as ToolStripButton;
            string devTypeName = tmp.Tag.ToString();
            DoDragDrop(devTypeName, DragDropEffects.Copy);
        }
        #endregion
    }
}
