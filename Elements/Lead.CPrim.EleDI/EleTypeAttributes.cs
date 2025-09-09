using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleDI
{
    /// <summary>DI元件属性</summary>
    public class EleDITypeAttributes : IEleTypeAttributes
    {
        public string Name => "DI";
        public string DisplayName => "DI";
        public string Description => "Digital Input";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resource1));
                return (Image)manager.GetObject("DI1");
            }
        }
        public string Group => "Element";
        public byte MajorVersion => 0;
        public byte MinorVersion => 0;
    }
}