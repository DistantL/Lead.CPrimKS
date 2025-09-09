using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.PrimRobotMitsubishi
{
    public partial class PrimDebugControl : UserControl
    {
        private PrimRobotMitsubishi _primRobotInovance;
        private RobotMitSubishiConfig _config;

        public PrimDebugControl()
        {
            InitializeComponent();
        }

        public PrimDebugControl(PrimRobotMitsubishi prim)
        {
            InitializeComponent();
            _primRobotInovance = prim;
            _config = _primRobotInovance._config;
        }

       

      
    }
}
