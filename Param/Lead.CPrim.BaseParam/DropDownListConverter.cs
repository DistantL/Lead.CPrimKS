using System;
using System.ComponentModel;

namespace Lead.CPrim.BaseParam
{
	public class DropDownListConverter : StringConverter
	{
		public DropDownListConverter(object[] objects)
		{
			this.m_Objects = objects;
		}

		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new TypeConverter.StandardValuesCollection(this.m_Objects);
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		private object[] m_Objects;
	}
}
