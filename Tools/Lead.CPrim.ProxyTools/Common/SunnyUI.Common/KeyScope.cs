using Lead.CPrim.ProxyTools;

namespace Sunny.UI
{
    public class KeyScope
	{
		public string ScopeString
		{
			get
			{
				return $"{Min}..{Max}";
			}
			set
			{
				SetScopeStr(value);
			}
		}

		public int Max { get; set; } = int.MinValue;


		public int Min { get; set; } = int.MaxValue;


		public KeyScope()
		{
		}

		public KeyScope(int theMin, int theMax)
		{
			Min = theMin;
			Max = theMax;
		}

		public KeyScope(string scopeStr)
		{
			SetScopeStr(scopeStr);
		}

		private void SetScopeStr(string str)
		{
			str = str.Replace("..", ",");
			string[] array = str.Split(',');
			Min = array[0].Trim().ToInt(int.MinValue);
			Max = array[1].Trim().ToInt(int.MaxValue);
		}

		public bool Contains(int val)
		{
			return Min <= val && val <= Max;
		}

		public bool Contains(KeyScope scope)
		{
			return scope.Min >= Min && scope.Max <= Max;
		}

		public bool Intersect(KeyScope scope)
		{
			for (int i = Min; i < Max; i++)
			{
				if (scope.Contains(i))
				{
					return true;
				}
			}
			return false;
		}

		public override string ToString()
		{
			return ScopeString;
		}
	}
}
