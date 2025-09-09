using Lead.CPrim.Interfaces;
using System.Xml;

namespace Lead.CPrim.WorkPlan
{
    public class ShowCreator : IShowCreator
    {
        public IShowTypeAttributes ConcreteShowTypeAttributes => new ShowTypeAttributes();
        public IShow Create()
        {
            return new ShowWorkPlan();
        }
        public IShow Create(XmlNode showConfig)
        {
            return new ShowWorkPlan(showConfig);
        }
    }
}
