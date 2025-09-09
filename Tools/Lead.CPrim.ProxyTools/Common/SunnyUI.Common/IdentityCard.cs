using System;
using System.Collections.Generic;

namespace Sunny.UI
{
	public class IdentityCard
	{
		public enum SexType
		{
			Man,
			Woman
		}

		private static readonly Dictionary<string, IdentityCard> Cache = new Dictionary<string, IdentityCard>();

		private static readonly List<int> AreaList = new List<int>(new int[35]
		{
			11, 22, 35, 44, 53, 12, 23, 36, 45, 54,
			13, 31, 37, 46, 61, 14, 32, 41, 50, 62,
			15, 33, 42, 51, 63, 21, 34, 43, 52, 64,
			65, 71, 81, 82, 91
		});

		public DateTime Birthday { get; set; }

		public SexType Sex { get; set; }

		public bool IsOld { get; set; }

		public string AreaNum { get; set; }

		public static bool Valid(string card)
		{
			try
			{
				if (Parse(card) != null)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		public static IdentityCard Parse(string card)
		{
			if (string.IsNullOrEmpty(card))
			{
				return null;
			}
			if (card.Length != 15 && card.Length != 18)
			{
				return null;
			}
			card = card.ToLower();
			if (Cache.TryGetValue(card, out var value))
			{
				return value;
			}
			lock (Cache)
			{
				if (Cache.TryGetValue(card, out value))
				{
					return value;
				}
				IdentityCard identityCard = Parse2(card);
				Cache.Add(card, identityCard);
				return identityCard;
			}
		}

		private static IdentityCard Parse2(string card)
		{
			string area = card.Substring(0, 6);
			IdentityCard identityCard = new IdentityCard
			{
				AreaNum = ParseArea(area)
			};
			if (card.Length == 15)
			{
				identityCard.ParseBirthdayAndSex15(card);
			}
			else if (card.Length == 18)
			{
				identityCard.ParseBirthdayAndSex18(card);
				string[] array = "1,0,x,9,8,7,6,5,4,3,2".Split(',');
				int[] array2 = new int[17]
				{
					7, 9, 10, 5, 8, 4, 2, 1, 6, 3,
					7, 9, 10, 5, 8, 4, 2
				};
				char[] array3 = card.Remove(17).ToCharArray();
				int num = 0;
				for (int i = 0; i < 17; i++)
				{
					num += array2[i] * (array3[i] - 48);
				}
				Math.DivRem(num, 11, out var result);
				if (array[result] != card.Substring(17, 1).ToLower())
				{
					throw new Exception("验证码校验失败！");
				}
			}
			return identityCard;
		}

		private static string ParseArea(string area)
		{
			if (!int.TryParse(area, out var result))
			{
				throw new Exception("非法地区编码！");
			}
			string s = area.Substring(0, 2);
			if (!int.TryParse(s, out result))
			{
				throw new Exception("非法省份编码！");
			}
			if (!AreaList.Contains(result))
			{
				throw new Exception("没有找到该省份！");
			}
			return area;
		}

		private void ParseBirthdayAndSex15(string card)
		{
			string s = card.Substring(6, 2);
			int num = int.Parse(s);
			string s2 = ((num < 20) ? 20 : 19) + card.Substring(6, 6).Insert(2, "-").Insert(5, "-");
			if (!DateTime.TryParse(s2, out var result))
			{
				throw new Exception("生日不正确！");
			}
			Birthday = result;
			num = Convert.ToInt32(card.Substring(card.Length - 1, 1));
			bool flag = num % 2 != 0;
			Sex = ((!flag) ? SexType.Woman : SexType.Man);
		}

		private void ParseBirthdayAndSex18(string card)
		{
			string s = card.Substring(6, 8).Insert(4, "-").Insert(7, "-");
			if (!DateTime.TryParse(s, out var result))
			{
				throw new Exception("生日不正确！");
			}
			Birthday = result;
			int num = Convert.ToInt32(card.Substring(card.Length - 2, 1));
			bool flag = num % 2 != 0;
			Sex = ((!flag) ? SexType.Woman : SexType.Man);
		}
	}
}
