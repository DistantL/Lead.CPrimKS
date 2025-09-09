using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Lead.CPrim.StationCommon.DataArea
{
	internal class MyPropList : DynamicObject
	{
		private string ownName;

		public List<Property> PropertyList { get; set; } = new List<Property>();


		public event MyPropListChangedEventHandler OnPropChanged;

		public MyPropList()
		{
		}

		public MyPropList(string ownName)
		{
			this.ownName = ownName;
		}

		public void Add(Property p)
		{
			try
			{
				PropertyList.Add(p);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Clear()
		{
			try
			{
				PropertyList.Clear();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			try
			{
				Property prop = PropertyList.FirstOrDefault((Property x) => x.Name == binder.Name);
				if (prop != null)
				{
					result = prop.Value;
					return true;
				}
				result = null;
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			try
			{
				Property prop = PropertyList.FirstOrDefault((Property x) => x.Name == binder.Name);
				if (prop != null)
				{
					prop.Value = value;
					this.OnPropChanged(prop, ownName);
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
