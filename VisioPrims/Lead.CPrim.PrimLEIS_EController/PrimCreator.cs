using System.Xml;

namespace Lead.CPrim.Interfaces
{
    public class PrimCreator : IPrimCreator
    {
        public IPrimTypeAttributes ConcretePrimTypeAttributes => new PrimTypeAttributes();

        public IPrim Create()
        {
            return new PrimLESI_EController.PrimLESI_EController();
        }

        public IPrim Create(XmlNode taskPrimConfig)
        {
            return new PrimLESI_EController.PrimLESI_EController(taskPrimConfig);
        }
    }
}