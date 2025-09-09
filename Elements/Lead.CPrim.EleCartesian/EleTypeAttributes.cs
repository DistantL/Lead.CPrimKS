using System.Drawing;
using System.Resources;
using Lead.CPrim.EleCartesian.Properties;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleCartesian
{
    /// <summary>轴组元件属性</summary>
    public class EleCartesianTypeAttributes : IEleTypeAttributes
    {
        public string Name => "Cartesian";
        public string DisplayName => "Cartesian";
        public string Description => "Cartesian";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resources));
                return (Image)manager.GetObject("xyz");
            }
        }
        public string Group => "Element";
        public byte MajorVersion => 0;
        public byte MinorVersion => 0;
    }
}