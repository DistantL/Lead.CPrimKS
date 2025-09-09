using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimLEIS
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimLESI();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimLESI(taskPrimConfig);
        }
    }
}