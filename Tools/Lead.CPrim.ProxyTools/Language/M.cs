using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string ModeChangePleaseWait { get; set; }



        public static void InitM()
        {
            ModeChangePleaseWait = GetString("ModeChangePleaseWait", "模式切换中，请稍候……");
        }
    }
}
