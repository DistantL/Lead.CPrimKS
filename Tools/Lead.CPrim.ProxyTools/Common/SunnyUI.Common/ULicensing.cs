using Lead.CPrim.ProxyTools;
using System;
using System.Security.Cryptography;

namespace Sunny.UI
{
    public static class ULicensing
	{
		public static string CreateKey(Func<int, long> f, int mod)
		{
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			byte[] array = new byte[4];
			rNGCryptoServiceProvider.GetBytes(array);
			int num = modulo(BitConverter.ToInt32(array, 0), mod);
			int num2 = modulo(f(num), mod);
			rNGCryptoServiceProvider.GetBytes(array);
			int num3 = modulo(BitConverter.ToInt32(array, 0), mod);
			int num4 = modulo(f(num3), mod);
			rNGCryptoServiceProvider.GetBytes(array);
			int num5 = modulo(BitConverter.ToInt32(array, 0), mod);
			int num6 = modulo(f(num5), mod);
			decimal num7 = 1m;
			num7 *= (decimal)Math.Pow(10.0, mod.ToString().Length);
			num7 += (decimal)num;
			num7 *= (decimal)Math.Pow(10.0, mod.ToString().Length);
			num7 += (decimal)num2;
			num7 *= (decimal)Math.Pow(10.0, mod.ToString().Length);
			num7 += (decimal)num3;
			num7 *= (decimal)Math.Pow(10.0, mod.ToString().Length);
			num7 += (decimal)num4;
			num7 *= (decimal)Math.Pow(10.0, mod.ToString().Length);
			num7 += (decimal)num5;
			num7 *= (decimal)Math.Pow(10.0, mod.ToString().Length);
			return MathEx.Base10ToBase26((num7 + (decimal)num6).ToString());
		}

		public static bool ValidateKey(string key, Func<int, long> f, int mod)
		{
			//string text = MathEx.Base26ToBase10(key);
			string text = "";
			int length = mod.ToString().Length;
			for (int i = 0; i < 3; i++)
			{
				if (modulo(f(Convert.ToInt32(text.Substring(1, length))), mod) == Convert.ToInt32(text.Substring(length + 1, length)))
				{
					text = text.Substring(2 * length);
					continue;
				}
				return false;
			}
			return true;
		}

		private static decimal maxModValue()
		{
			return (decimal.MaxValue.ToString().Length - 1) / 6;
		}

		private static int modulo(long _num, long _base)
		{
			return (int)(_num - _base * Convert.ToInt64(Math.Floor((decimal)_num / (decimal)_base)));
		}
	}
}
