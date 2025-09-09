using Lead.CPrim.BaseParam;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;

namespace Lead.CPrim.BaseParam
{
	public class MyPropList : DynamicObject
	{
		/// <summary>值改变时发生</summary>
		public event Action<Property, string> OnPropChanged;

		public List<Property> PropertyList { get; set; } = new List<Property>();

		public MyPropList()
		{
		}

		public MyPropList(string ownName)
		{
			this.ownName = ownName;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			Property prop = this.PropertyList.FirstOrDefault((Property x) => x.Name == binder.Name);
			bool result2;
			if (prop != null)
			{
				result = prop.Value;
				result2 = true;
			}
			else
			{
				result = null;
				result2 = false;
			}
			return result2;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			Property prop = this.PropertyList.FirstOrDefault((Property x) => x.Name == binder.Name);
			bool result;
			if (prop != null)
			{
				prop.Value = value;
				this.OnPropChanged(prop, this.ownName);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void Add(Property p)
		{
			this.PropertyList.Add(p);
		}

		public void Clear()
		{
			this.PropertyList.Clear();
		}

		private string ownName;
	}
}
