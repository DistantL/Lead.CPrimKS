using Lead.CPrim.Interfaces;
using System.Xml;

namespace Lead.CPrim.PrimADLink_E
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimADLink_E();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimADLink_E(taskPrimConfig);
        }
    }
}