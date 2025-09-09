using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleCartesian
{
    /// <summary>轴组元件创建</summary>
    public class EleCreator : IEleCreator
    {
        public IEleTypeAttributes ConcreteEleTypeAttributes => new EleCartesianTypeAttributes();
        public IEle Create()
        {
            return new EleCartesian();
        }
        public IEle Create(XmlNode eleConfig)
        {
            return new EleCartesian(eleConfig);
        }
    }
}