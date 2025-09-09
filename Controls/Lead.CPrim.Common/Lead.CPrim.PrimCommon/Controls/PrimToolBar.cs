using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.PrimCommon
{
    /// <summary>
    /// 基元总集合UI
    /// </summary>
    public partial class PrimToolBar : UserControl
	{
        #region Define_Event
        /// <summary>单击新建基元时发生</summary>
        public event CreateDeviceEventHandler OnCreateDevice;
        #endregion



        #region Ctor
        public PrimToolBar()
        {
            InitializeComponent();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>[PrimConfigForm]调用</summary>
        /// <param name="path">基元DLL</param>
        /// <returns>int</returns>
        public int DevToolBarFormLoad(string path)
        {
            int ret = PrimsManager.Instance.LoadPrimTypeAttributes(path);
            if (ret != 0)
            {
                return ret;
            }

            foreach (KeyValuePair<string, IPrimTypeAttributes> item in PrimsManager.Instance.SupportedDevTaskPrimTypes)
            {
                ToolStripButton btnPrim = new ToolStripButton
                {
                    ImageScaling = ToolStripItemImageScaling.None,
                    AutoSize = false,
                    BackgroundImageLayout = ImageLayout.Center,
                    DisplayStyle = ToolStripItemDisplayStyle.Image,
                    BackgroundImage = item.Value.Icon,
                    Tag = item.Key,
                    Size = new Size(56, 52),
                    Text = item.Key
                };
                btnPrim.Click += btnPrim_Click;
                btnPrim.MouseEnter += BtnPrim_MouseEnter;
                btnPrim.MouseLeave += BtnPrim_MouseLeave;
                toolStrip.Items.Add(btnPrim);
            }
            return ret;
        }

        /// <summary>通过拖放进行复制（未使用）</summary>
        private void btnPrim_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripButton tmp = sender as ToolStripButton;
            string devTypeName = tmp.Tag.ToString();
            DoDragDrop(devTypeName, DragDropEffects.Copy);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>基元单击新建按钮</summary>
        private void btnPrim_Click(object sender, EventArgs e)
        {
            if (AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
                ToolStripButton tmp = sender as ToolStripButton;
                string devTypeName = tmp.Tag.ToString();
                OnCreateDevice?.Invoke(devTypeName);
            }
        }

        private void BtnPrim_MouseLeave(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if(btn == null)
            {
                return;
            }

            btn.Size = new Size(56, 52);
        }

        private void BtnPrim_MouseEnter(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn == null)
            {
                return;
            }

            btn.Size = new Size(100, 52);
        }
        #endregion
    }
}
