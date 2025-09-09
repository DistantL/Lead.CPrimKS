using Lead.CPrim.Interfaces;
using System.Xml;

namespace Lead.CPrim.PrimRobotMitsubishi
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimRobotMitsubishi();
        }

        public IPrim Create(XmlNode primConfig)
        {
            return new PrimRobotMitsubishi(primConfig);
        }
    }
}
