using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimSerial
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimSerial();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimSerial(taskPrimConfig);
        }
    }
}