using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.Cprim.PrimRobotInovance
{
    public partial class PrimDebugControl : UserControl
    {
        private PrimRobotInovance _primRobotInovance;
        private RobotInovanceConfig _config;

        public PrimDebugControl()
        {
            InitializeComponent();
        }

        public PrimDebugControl(PrimRobotInovance prim)
        {
            InitializeComponent();
            _primRobotInovance = prim;
            _config = _primRobotInovance._config;
        }
    }
}
