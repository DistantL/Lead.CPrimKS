using Lead.CPrim.Interfaces;
using System.Xml;

namespace Lead.CPrim.PressureCurve
{
    public class ShowCreator : IShowCreator
    {
        public IShowTypeAttributes ConcreteShowTypeAttributes => new ShowTypeAttributes();
        public IShow Create()
        {
            return new ShowPressureCurve();
        }
        public IShow Create(XmlNode showConfig)
        {
            return new ShowPressureCurve(showConfig);
        }
    }
}
