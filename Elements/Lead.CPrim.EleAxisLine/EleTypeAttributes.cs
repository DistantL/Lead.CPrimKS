using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleAxisLine
{
    public class EleAxisLineTypeAttributes : IEleTypeAttributes
    {
        public string Description => "Axis";
        public string DisplayName => "AxisLine";
        public string Group => "Element";

        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resource1));
                return (Image) manager.GetObject("axis");
            }
        }

        public byte MajorVersion => 0;
        public byte MinorVersion => 0;
        public string Name => "AxisLine";
    }
}