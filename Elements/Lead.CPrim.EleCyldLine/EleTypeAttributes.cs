using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleCyldLine
{
    public class EleCyldLineTypeAttributes : IEleTypeAttributes
    {
        public string Description => "CylinderLine";
        public string DisplayName => "CylinderLine";
        public string Group => "Element";

        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resource));
                return (Image) manager.GetObject("cylinder");
            }
        }

        public byte MajorVersion => 0;
        public byte MinorVersion => 0;
        public string Name => "CylinderLine";
    }
}