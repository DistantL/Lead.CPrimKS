using System.Drawing;
using System.Resources;
using System.Xml;
using Lead.CPrim.EleAnalogInput;

namespace Lead.CPrim.Interfaces
{
    /// <summary>模拟量输入元件属性</summary>
    public class EleAnalogInputTypeAttributes : IEleTypeAttributes
    {
        public string Name => "AD";
        public string Description => "AD";
        public string DisplayName => "AD";
        public string Group => "Element";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resource1));
                return (Image)manager.GetObject("Analog");
            }
        }
        public byte MajorVersion => 0;
        public byte MinorVersion => 0;
    }

    /// <summary>模拟量输入元件创建</summary>
    public class EleCreator : IEleCreator
    {
        public IEleTypeAttributes ConcreteEleTypeAttributes => new EleAnalogInputTypeAttributes();
        public IEle Create()
        {
            return new EleAnalogInput.EleAnalogInput();
        }
        public IEle Create(XmlNode eleConfig)
        {
            return new EleAnalogInput.EleAnalogInput(eleConfig);
        }
    }
}