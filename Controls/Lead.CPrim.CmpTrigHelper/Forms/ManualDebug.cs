using Lead.CPrim.Interfaces.Ele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.CmpTrigHelper
{
    public partial class ManualDebug : Form
    {
        #region Field
        /// <summary>
        /// 当前轴组Id
        /// </summary>
        private Guid _controlId;

        IEleCartesian _ele;

        List<Pos> _poss;
        #endregion



        #region Ctor
        public ManualDebug()
        {
            InitializeComponent();
        }

        public ManualDebug(IEleCartesian ele, List<Pos> poss) : this()
        {
            _ele = ele;
            _poss = poss;
        }
        #endregion



        #region Event_System
        private void ManualDebug_Load(object sender, EventArgs e)
        {
            _controlId = Guid.NewGuid();
            var ctl = _ele.NewCartDebugUi(_controlId, _ele, _poss, true);
            ctl.Dock = DockStyle.Fill;
            pnlCtl.Controls.Add(ctl);
        }
        #endregion



        #region Event_Button

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 获取更新后点位
        /// </summary>
        /// <returns></returns>
        public List<Pos> GetPoss()
        {
            return _ele.CartDebugUi_GetPosList(_controlId);
        }
        #endregion
    }
}
