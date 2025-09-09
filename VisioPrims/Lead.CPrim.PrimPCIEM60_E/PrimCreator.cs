using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Lead.CPrim.PrimPCIEM60_E;

namespace Lead.CPrim.Interfaces
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimPCIEM60_E.PrimPCIEM60_E();
        }

        public IPrim Create(XmlNode primConfig)
        {
            return new PrimPCIEM60_E.PrimPCIEM60_E(primConfig);
        }
    }
}
