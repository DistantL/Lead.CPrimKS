using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleDO
{
    public class EleDOTypeAttributes : IEleTypeAttributes
    {
        public string Description => "Digital Output";
        public string DisplayName => "DO";
        public string Group => "Element";

        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resource1));
                return (Image) manager.GetObject("DO1");
            }
        }

        public byte MajorVersion => 0;
        public byte MinorVersion => 0;
        public string Name => "DO";
    }
}