using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimVarManager
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new VarManager();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new VarManager(taskPrimConfig);
        }
    }
}