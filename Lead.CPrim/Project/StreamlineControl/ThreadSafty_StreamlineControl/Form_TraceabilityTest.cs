using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSafty_StreamlineControl
{
    public partial class Form_TraceabilityTest : Form
    {
        private Traceability _traceability;
        public Form_TraceabilityTest(Traceability traceability)
        {
            _traceability = traceability;
            InitializeComponent();


        }
    }
}
