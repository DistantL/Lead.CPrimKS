using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.ShowAQCI
{
    /// <summary>AQCI显示创建</summary>
    public class ShowCreator : IShowCreator
    {
        public IShowTypeAttributes ConcreteShowTypeAttributes => new ShowTypeAttributes();
        IShow IShowCreator.Create()
        {
            return new ShowAQCI();
        }
        IShow IShowCreator.Create(XmlNode showConfig)
        {
            return new ShowAQCI(showConfig);
        }
    }
}