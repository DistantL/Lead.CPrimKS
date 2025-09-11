using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string Delete { get; set; }



        public static void InitD()
        {
            Delete = GetString("Delete", "删除");
        }
    }
}
