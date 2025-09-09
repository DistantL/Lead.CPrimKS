using Lead.CPrim.ShowPlcCurve.Properties;
using System.Drawing;

namespace Lead.CPrim.Interfaces
{
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        public string Name => "ShowPlcCurve";
        public string DisplayName => "ShowPlcCurve";
        public string Description => "ShowPlcCurve for Plc";
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
