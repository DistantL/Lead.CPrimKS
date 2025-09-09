using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.Core;

namespace IpcConnection
{
    public class TestCommand:AbstractMenuCommand
    {
        public override void Run()
        {
            Form1 frm = (Form1)this.Owner;
            frm.ShowDialog();
        }
    }
}
