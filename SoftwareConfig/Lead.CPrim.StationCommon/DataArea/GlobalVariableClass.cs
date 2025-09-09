using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace Lead.CPrim.StationCommon.DataArea
{
	/// <summary>
	/// 全局变量自定义类类型管理器
	/// </summary>
	public class GlobalVariableClass : DynamicObject
	{
		#region Field
		/// <summary>类名</summary>
		private string _className;

		/// <summary>值集合</summary>
		private List<Property> _properties = null;
		#endregion



		#region Prop
		/// <summary>类名</summary>
		public string ClassName { get { return _className; } set { _className = value; } }
		/// <summary>值集合</summary>
		public List<Property> Properties { get { return _properties; } set { _properties = value; } }
		#endregion



		#region Ctor
		public GlobalVariableClass()
		{
			_properties = new List<Property>();
		}
		public GlobalVariableClass(string name) : this()
		{
			_className = name;
		}
		public GlobalVariableClass(string name, List<Property> properties) : this(name)
        {
			_properties = properties;
        }
		#endregion



		#region Method
		private XElement GetXElementByName(XElement elementP, string name)
		{
			XElement element = null;
			foreach (XElement xEle in elementP.Elements())
			{
				if (xEle.Name != name)
				{
					element = GetXElementByName(xEle, name);
					if (element != null)
					{
						return xEle;
					}
					continue;
				}
				return xEle;
			}
			return element;
		}

		private void UpdateElementOnMyPropListChanged(Property p, string ownName)
		{
		}

		public void Load(List<Property> properties)
		{
			_properties = properties;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			Property p = _properties.FirstOrDefault((Property x) => x.Name == binder.Name);
			if (p != null)
			{
				if (!(p.Value is List<Property>))
				{
					result = p.Value;
				}
				else
				{
					MyPropList list = new MyPropList(binder.Name);
					list.OnPropChanged += UpdateElementOnMyPropListChanged;
					list.PropertyList = (List<Property>)p.Value;
					result = list;
				}
				return true;
			}
			result = null;
			return false;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			Property p = _properties.FirstOrDefault((Property x) => x.Name == binder.Name);
			if (p != null)
			{
				p.Value = value;
				return true;
			}
			return false;
		} 
		#endregion
	}
}
