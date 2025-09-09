using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleLight
{
    public class EleLightTypeAttributes : IEleTypeAttributes
    {
        public string Description => "Digital Output";
        public string DisplayName => "Light";
        public string Group => "Element";

        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resource1));
                return (Image) manager.GetObject("light1");
            }
        }

        public byte MajorVersion => 0;
        public byte MinorVersion => 0;
        public string Name => "Light";
    }
}