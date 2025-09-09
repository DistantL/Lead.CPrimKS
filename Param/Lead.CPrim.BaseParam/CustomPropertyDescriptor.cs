using Lead.CPrim.ProxyTools;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Lead.CPrim.BaseParam
{
	public class CustomPropertyDescriptor : PropertyDescriptor
    {
        private Property m_Property;

        public override string Category => m_Property.Category;

        public override Type ComponentType => null;

        public override TypeConverter Converter => m_Property.Converter;

        public override string Description => m_Property.Name;

        public override string DisplayName => (m_Property.DisplayName != "") ? m_Property.DisplayName : m_Property.Name;

        public override bool IsReadOnly => m_Property.ReadOnly;

        public override Type PropertyType => m_Property.Value.GetType();


        public CustomPropertyDescriptor(ref Property myProperty, Attribute[] attrs):base(myProperty.Name,attrs) 
		{
			m_Property = myProperty;
        }

		public override bool CanResetValue(object component)
		{
			return false;
		}

		public override object GetEditor(Type editorBaseType)
		{
			return (m_Property.Editor == null) ? base.GetEditor(editorBaseType) : m_Property.Editor;
		}

		public override object GetValue(object component)
		{
			return m_Property.Value;
		}

		public override void ResetValue(object component)
		{
		}

		public override void SetValue(object component, object value)
		{
			m_Property.Value = value;
		}

		public override bool ShouldSerializeValue(object component)
		{
			return false;
		}
	}
}
