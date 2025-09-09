using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.CPrim.Interfaces;
using Lead.CPrim.PressureCurve.Properties;

namespace Lead.CPrim.PressureCurve
{
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        public string Name => "PressureCurve";
        public string DisplayName => "PressureCurve";
        public string Description => "Show for PressureCurve";
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
