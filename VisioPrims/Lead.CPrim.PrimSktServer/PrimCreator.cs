using System.Xml;
using Lead.CPrim.PrimSktServer;

namespace Lead.CPrim.Interfaces
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimServer();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimServer(taskPrimConfig);
        }
    }
}