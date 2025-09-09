using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public partial class NLocalizer
    {
        public static string FileNotFoundWhenViewingTheImage { get; set; }
        public static string Forbid { get; set; }



        public static void InitF()
        {
            FileNotFoundWhenViewingTheImage = GetString("FileNotFoundWhenViewingTheImage", "查看图片时文件不存在");
            Forbid = GetString("Forbid", "禁止");
        }
    }
}
