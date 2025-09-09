using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleAnalogOutput
{
    public class EleAnalogOutputTypeAttributes : IEleTypeAttributes
    {
        public string Name => "DA";

        public string Description => "DA";

        public string DisplayName => "DA";

        public string Group => "Element";

        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resource1));
                return (Image) manager.GetObject("Digital");
            }
        }

        public byte MajorVersion => 0;

        public byte MinorVersion => 0;
    }
}