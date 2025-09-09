using Lead.CPrim.ShowPlcCurve;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
    public class ShowCreator : IShowCreator
    {
        public IShowTypeAttributes ConcreteShowTypeAttributes => new ShowTypeAttributes();
        public IShow Create()
        {
            return new Show();
        }
        public IShow Create(XmlNode showConfig)
        {
            return new Show(showConfig);
        }
    }
}
