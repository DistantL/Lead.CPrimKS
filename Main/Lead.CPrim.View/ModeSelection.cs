using Lead.CPrim.Controls;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
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

namespace Lead.CPrim.View
{
    public partial class ModeSelection : Form
    {
        #region Event
        /// <summary>
        /// 点击运行模式时发生
        /// </summary>
        public event Action<运行模式> OnWorkModeClick;
        #endregion



        #region Field
        /// <summary>模式切换按钮</summary>
        private Button[] btns;

        #endregion



        #region Prop
        /// <summary>
        /// 工作模式
        /// </summary>
        public 运行模式 WorkMode { get; set; } = 运行模式.正常生产;
        #endregion



        #region Ctor
        public ModeSelection()
        {
            InitializeComponent();

            BackColor = Colors.PrimaryBackColor236;
            pnlMain.SetStyle(Colors.PrimaryBackColor236, Colors.PrimaryRectColor);

            btns = new Button[9] { btnNormal, btnRunWithFixture, btnRunWithoutFixture, btnCheck, btnAxis, btnDynamic, btnTest,btnSingle, btnDirect };
        }
        #endregion



        #region Event_System
        private void ModeSelection_Load(object sender, EventArgs e)
        {
            DynamicUIShow.Show(this, FormShowAlignment.BottomRight, new Padding(0, 0, 70, 36));
            SetBackColor(WorkMode);
        }
        #endregion



        #region Event_Button
        private void btn_Click(object sender, EventArgs e)
        {
            if (!(sender is Button btn))
            {
                return;
            }

            int mode = btn.Tag.ToString().ToInt(-1);
            if (mode < 0 || mode > 9 || (mode >= 1 && !AuthorityManager.Instance.VerifyLevel2Permission(true)))
            {
                return;
            }

            WorkMode = (运行模式)mode;
            SetBackColor(WorkMode);
            OnWorkModeClick?.Invoke(WorkMode);
            Close();
        }
        #endregion



        #region Method_ExternalUsing
        public void SetWorkMode(运行模式 workMode)
        {
            WorkMode = workMode;
        }

        public bool SetBackColor(运行模式 workMode)
        {
            bool ret = true;

            foreach (var btn in btns)
            {
                btn.SetBackColor(Color.Silver);
            }

            btns[(int)workMode].BackColor = Color.Lime;

            return ret;
        }
        #endregion
    }
}