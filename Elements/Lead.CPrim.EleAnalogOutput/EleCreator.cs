using System.Xml;
using Lead.CPrim.EleAnalogOutput;

namespace Lead.CPrim.Interfaces
{
    public class EleCreator : IEleCreator
    {
        public IEleTypeAttributes ConcreteEleTypeAttributes => new EleAnalogOutputTypeAttributes();

        public IEle Create()
        {
            return new EleAnalogOutput.EleAnalogOutput();
        }

        public IEle Create(XmlNode eleConfig)
        {
            return new EleAnalogOutput.EleAnalogOutput(eleConfig);
        }
    }
}