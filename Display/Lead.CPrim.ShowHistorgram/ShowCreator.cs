using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.ShowHistorgram
{
    public class ShowCreator : IShowCreator
    {
        public IShowTypeAttributes ConcreteShowTypeAttributes => new ShowTypeAttributes();
        IShow IShowCreator.Create()
        {
            return new ShowHistorgram();
        }
        IShow IShowCreator.Create(XmlNode showConfig)
        {
            return new ShowHistorgram(showConfig);
        }
    }
}