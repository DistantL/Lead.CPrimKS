using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.ShowErrorCode
{
    /// <summary>AQCIœ‘ æ¥¥Ω®</summary>
    public class ShowCreator : IShowCreator
    {
        public IShowTypeAttributes ConcreteShowTypeAttributes => new ShowTypeAttributes();
        IShow IShowCreator.Create()
        {
            return new ShowErrorCode();
        }
        IShow IShowCreator.Create(XmlNode showConfig)
        {
            return new ShowErrorCode(showConfig);
        }
    }
}