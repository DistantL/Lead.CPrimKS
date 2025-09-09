using Lead.CPrim.PrimE404;
using System.Xml;

namespace Lead.CPrim.Interfaces
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new Prim();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new Prim(taskPrimConfig);
        }
    }
}