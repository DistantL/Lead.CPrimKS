using Lead.CPrim.Interfaces;
using System.Xml;

namespace Lead.CPrim.ShowAtlasCurve
{
    public class ShowCreator : IShowCreator
    {
        public IShowTypeAttributes ConcreteShowTypeAttributes => new ShowTypeAttributes();
        public IShow Create()
        {
            return new ShowAtlasCurve();
        }
        public IShow Create(XmlNode showConfig)
        {
            return new ShowAtlasCurve(showConfig);
        }
    }
}
