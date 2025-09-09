using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowAtlasCurve.Properties;

namespace Lead.CPrim.ShowAtlasCurve
{
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        public string Name => "ShowAtlasCurve";
        public string DisplayName => "ShowAtlasCurve";
        public string Description => "Show for ShowAtlasCurve";
        public Image Icon
        {
            get
            {
                return Resources.Default;
            }
        }
        public string DisplayGroup => "PAX";
        public string Group => "PAX";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
    }
}
