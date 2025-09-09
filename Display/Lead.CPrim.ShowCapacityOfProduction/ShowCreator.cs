using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.ShowCapacityOfProduction
{
    /// <summary>显示创建</summary>
    public class ShowCreator : IShowCreator
    {
        public IShowTypeAttributes ConcreteShowTypeAttributes => new ShowTypeAttributes();
        IShow IShowCreator.Create()
        {
            return new ShowCapacityOfProduction();
        }
        IShow IShowCreator.Create(XmlNode showConfig)
        {
            return new ShowCapacityOfProduction(showConfig);
        }
    }
}