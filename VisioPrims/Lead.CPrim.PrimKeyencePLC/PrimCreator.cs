using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimKeyencePLC
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();
        public IPrim Create()
        {
            return new PrimKeyencePLC();
        }
        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimKeyencePLC(taskPrimConfig);
        }
    }
}