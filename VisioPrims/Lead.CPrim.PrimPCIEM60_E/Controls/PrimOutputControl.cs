using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimPCIEM60_E
{
    public partial class PrimOutputControl : UserControl
    {
        public PrimOutputControl()
        {
            InitializeComponent();
        }

        public PrimOutputControl(PrimPCIEM60_E primPCIEM60_E)
        {
        }

        internal void SetPrimConnState(PrimConnState conn)
        {
            throw new NotImplementedException();
        }

        internal void SetPrimRunState(PrimRunState run)
        {
            throw new NotImplementedException();
        }
    }
}
