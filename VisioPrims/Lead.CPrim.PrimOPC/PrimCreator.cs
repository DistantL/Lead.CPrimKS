using System.Xml;
using Lead.CPrim.PrimOPC;

namespace Lead.CPrim.Interfaces
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimOPC.PrimOPC();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimOPC.PrimOPC(taskPrimConfig);
        }
    }
}