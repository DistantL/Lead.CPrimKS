using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string Loading { get; set; }



        public static void InitL()
        {
            Loading = GetString("Loading", "加载中……");
        }
    }
}
