using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.PrimRobotInovancePro
{
    public partial class PrimDebugControl : UserControl
    {
        private Prim _primRobotInovance;
        private Config _config;

        public PrimDebugControl()
        {
            InitializeComponent();
        }

        public PrimDebugControl(Prim prim)
        {
            InitializeComponent();
            _primRobotInovance = prim;
            _config = _primRobotInovance._config;
        }
    }
}
