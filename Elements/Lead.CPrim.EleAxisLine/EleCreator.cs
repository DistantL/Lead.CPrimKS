using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleAxisLine
{
    public class EleCreator : IEleCreator
    {
        public IEleTypeAttributes ConcreteEleTypeAttributes => new EleAxisLineTypeAttributes();

        public IEle Create()
        {
            return new EleAxisLine();
        }

        public IEle Create(XmlNode eleConfig)
        {
            return new EleAxisLine(eleConfig);
        }
    }
}