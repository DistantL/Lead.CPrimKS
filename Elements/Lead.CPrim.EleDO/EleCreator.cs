using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleDO
{
    public class EleCreator : IEleCreator
    {
        public IEleTypeAttributes ConcreteEleTypeAttributes => new EleDOTypeAttributes();

        public IEle Create()
        {
            return new EleDO();
        }

        public IEle Create(XmlNode eleConfig)
        {
            return new EleDO(eleConfig);
        }
    }
}