using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManualChangeCompesation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ManualChangeCompesationPickupPosForm.Instance.SetPos_Slot1(12.23, 232, 23, 0.1, 0.2, 0.3
                ,
                null);
            Application.Run(ManualChangeCompesationPickupPosForm.Instance);
        }
    }
}
