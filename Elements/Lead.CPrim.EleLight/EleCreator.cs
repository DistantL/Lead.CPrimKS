using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleLight
{
    public class EleCreator : IEleCreator
    {
        public IEleTypeAttributes ConcreteEleTypeAttributes => new EleLightTypeAttributes();

        public IEle Create()
        {
            return new EleLight();
        }

        public IEle Create(XmlNode eleConfig)
        {
            return new EleLight(eleConfig);
        }
    }
}