using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSafty_StreamlineControl
{
    internal static class Program
    {
        /// <summary>应用程序的主入口点。</summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //  Application.Run(new Form_TraceabilityTest(new TraceabilityConfig()));
            Application.Run(new Form_HiveTest(new HiveConfig()));
        }
    }
}
