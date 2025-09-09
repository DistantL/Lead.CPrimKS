using System.Xml;
using Lead.CPrim.PrimSktClient;

namespace Lead.CPrim.Interfaces
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimClient();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimClient(taskPrimConfig);
        }
    }
}