 using System.Drawing;
using System.Resources;
using System.Xml;
using Lead.CPrim.EleAnalogInput.Properties;
using Lead.CPrim.EleAnalogInputPro;

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
                return Resources.A;
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
            return new EleAnalogInputPro.EleAnalogInput();
        }
        public IEle Create(XmlNode eleConfig)
        {
            return new EleAnalogInputPro.EleAnalogInput(eleConfig);
        }
    }
}