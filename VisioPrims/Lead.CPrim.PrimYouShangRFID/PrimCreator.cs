using System.Xml;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimYouShangRFID
{
	public class PrimCreator : IPrimCreator
	{
		public IPrimTypeAttributes ConcretePrimTypeAttributes => (IPrimTypeAttributes)(object)new PrimTypeAttributes();

		public IPrim Create()
		{
			return (IPrim)(object)new PrimRFID();
		}

		public IPrim Create(XmlNode taskPrimConfig)
		{
			return (IPrim)(object)new PrimRFID(taskPrimConfig);
		}
	}
}
