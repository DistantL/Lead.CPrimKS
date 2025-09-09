using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string ValueInvalid { get; set; }
        public static string ViewVersionExplanation { get; set; }
        



        public static void InitV()
        {
            ValueInvalid = GetString("ValueInvalid", "值无效");
            ViewVersionExplanation = GetString("ViewVersionExplanation", "查看版本解释");
        }
    }
}
