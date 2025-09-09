using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
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
    public partial class VisionFrm : UIPage
    {
        #region Field
        UIPanel[] pnls = new UIPanel[] { };
        #endregion



        #region Ctor
        public VisionFrm()
        {
            InitializeComponent();
            pnls = new UIPanel[] { pnl1, pnl2, pnl3, pnl4, pnl5, pnl6 };
            SetStyle();
        }
        #endregion



        #region Method_InternalUsing

        /// <summary>设置样式</summary>
        private void SetStyle()
        {
            //TableLayoutPanel
            tlpMain.BackColor = Color.FromArgb(236, 236, 236);

            //UIPanel
            foreach (var pnl in pnls)
            {
                pnl.FillColor = Color.FromArgb(211, 211, 211);
                pnl.RectColor = Color.Transparent;
            }
        }
        #endregion
    }
}
