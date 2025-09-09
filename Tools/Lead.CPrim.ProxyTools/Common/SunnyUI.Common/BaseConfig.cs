using Lead.CPrim.ProxyTools;
using System;

namespace Sunny.UI
{
    public abstract class BaseConfig<TConfig> where TConfig : BaseConfig<TConfig>, new()
	{
		protected static TConfig current;

		public static string Description
		{
			get
			{
				Tuple<string, string> configFile = ConfigHelper.GetConfigFile<TConfig>();
				return configFile.Item2;
			}
		}

		public static string ConfigFile
		{
			get
			{
				Tuple<string, string> configFile = ConfigHelper.GetConfigFile<TConfig>();
				return configFile.Item1;
			}
		}

		public static TConfig Current
		{
			get
			{
				if (current != null)
				{
					return current;
				}
				current = CreateNew();
				if (!current.Load(CurrentDir() + ConfigFile))
				{
					try
					{
						current.Save();
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				return current;
			}
			set
			{
				current = value;
			}
		}

		private static string CurrentDir()
		{
			return Environment.CurrentDirectory.DealPath();
		}

		private static TConfig CreateNew()
		{
			TConfig val = new TConfig();
			val.SetDefault();
			return val;
		}

		public void Save()
		{
			Save(null);
		}

		public bool Load()
		{
			return Load(null);
		}

		public string Encrypt(string str)
		{
			string s = str + RandomEx.RandomNumber(6);
			return s.DesEncrypt();
		}

		public string Decrypt(string str)
		{
			string text = str.DesDecrypt();
			return text.Left(text.Length - 6);
		}

		public abstract bool Load(string filename);

		public abstract void Save(string filename);

		public virtual void SetDefault()
		{
		}
	}
}
