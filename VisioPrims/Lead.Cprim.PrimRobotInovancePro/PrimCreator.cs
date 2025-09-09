using Lead.CPrim.PrimRobotInovancePro;
using Lead.CPrim.Interfaces;
using System.Xml;

namespace Lead.Cprim.Interfaces
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new Prim();
        }

        public IPrim Create(XmlNode primConfig)
        {
            return new Prim(primConfig);
        }
    }
}
