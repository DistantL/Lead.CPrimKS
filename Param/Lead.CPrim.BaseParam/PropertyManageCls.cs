using Lead.CPrim.ProxyTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace Lead.CPrim.BaseParam
{
	/// <summary>属性表绑定源</summary>
	public class PropertyManageCls : CollectionBase, ICustomTypeDescriptor
	{
		public Property this[int index]
		{
			get
			{
				return (Property)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, true);
		}

		public string GetClassName()
		{
			return TypeDescriptor.GetClassName(this, true);
		}

		public string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		public EventDescriptor GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		public PropertyDescriptor GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		public object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptor[] newProps = new PropertyDescriptor[base.Count];
			for (int i = 0; i < base.Count; i++)
			{
				Property prop = this[i];
				newProps[i] = new CustomPropertyDescriptor(ref prop, attributes);
			}
			return new PropertyDescriptorCollection(newProps);
		}

		public PropertyDescriptorCollection GetProperties()
		{
			return TypeDescriptor.GetProperties(this, true);
		}

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}

        /// <summary>属性表增加值（具有重名防呆功能）</summary>
        /// <param name="value">增加值</param>
        public void Add(Property value)
		{
			int flag = -1;
			if (!(value == null))
			{
				if (base.List.Count > 0)
				{
					for (int i = 0; i < base.List.Count; i++)
					{
						Property p = base.List[i] as Property;
						if (value.Name == p.Name)
						{
							flag = i;
						}
					}
					if (flag == -1)
					{
						base.List.Add(value);
					}
				}
				else
				{
					base.List.Add(value);
				}
			}
		}

        /// <summary>全局变量移除一条（按照全局变量）</summary>
        /// <param name="value">全局变量</param>
        public int Remove(Property value)
		{
			if (value == null)
			{
				return -1;
            }

			return Remove(value.Name);
        }

        /// <summary>全局变量移除（按照全局变量名称）</summary>
        /// <param name="name">名称</param>
        /// <param name="isFirst">是否第一条</param>
        /// <returns>int</returns>
        public int Remove(string name, bool isFirst = false)
		{
			if (string.IsNullOrWhiteSpace(name)) 
			{
				return -1;
			}

            for (int i = 0; i < base.List.Count; i++)
            {
                try
                {
                    if (((Property)List[i]).Name == name)
                    {
                        base.List.RemoveAt(i);
						if (isFirst) 
						{
							break;
						}
                    }
                }
                catch (Exception)
                {
					return -1;
                }
            }

			return 0;
		}

        public int Updata(Property oldValue, Property newValue)
        {
            if (newValue == null)
            {
                return -1;
            }

            int ret = Remove(oldValue);
            if (ret == 0)
            {
                Add(newValue);
            }

            return ret;
        }

        public XElement SaveToXml()
		{
			this.XElement = new XElement("Paras", null);
			foreach (object obj in base.List)
			{
				Property p = (Property)obj;
				this.XElement.Add(p.PropToXElment());
			}
			return this.XElement;
		}

		private XElement XElement;
	}
}
