using System.Xml;
using Lead.CPrim.PrimSSZN;

namespace Lead.CPrim.Interfaces
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimSSZN.Prim();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimSSZN.Prim(taskPrimConfig);
        }
    }
}