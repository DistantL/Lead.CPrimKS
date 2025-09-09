using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimLEIS_E
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimLESI_E();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimLESI_E(taskPrimConfig);
        }
    }
}