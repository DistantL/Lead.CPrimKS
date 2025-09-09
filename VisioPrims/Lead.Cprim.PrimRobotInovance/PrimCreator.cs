using Lead.CPrim.Interfaces;
using System.Xml;

namespace Lead.Cprim.PrimRobotInovance
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimRobotInovance();
        }

        public IPrim Create(XmlNode primConfig)
        {
            return new PrimRobotInovance(primConfig);
        }
    }
}
