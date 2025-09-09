using System.Xml;
using Lead.CPrim.EleDI;

namespace Lead.CPrim.Interfaces
{
    /// <summary>DI元件创建</summary>
    public class EleCreator : IEleCreator
    {
        public IEleTypeAttributes ConcreteEleTypeAttributes => new EleDITypeAttributes();
        public IEle Create()
        {
            return new EleDI.EleDI();
        }
        public IEle Create(XmlNode eleConfig)
        {
            return new EleDI.EleDI(eleConfig);
        }
    }
}