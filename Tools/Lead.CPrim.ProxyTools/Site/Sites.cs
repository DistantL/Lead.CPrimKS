using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public static class SitesManager
    {
        public static Sites CurrentSite { get; set; } = Sites.昆山;
    }



    public enum Sites
    {
        昆山,

        嘉善,
    }
}
