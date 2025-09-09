using System.Xml;
using Lead.CPrim.EleCyldLine;

namespace Lead.CPrim.Interfaces
{
    public class EleCreator : IEleCreator
    {
        public IEleTypeAttributes ConcreteEleTypeAttributes => new EleCyldLineTypeAttributes();

        public IEle Create()
        {
            return new EleCylinderLine();
        }

        public IEle Create(XmlNode eleConfig)
        {
            return new EleCylinderLine(eleConfig);
        }
    }
}