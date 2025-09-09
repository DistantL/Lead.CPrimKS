using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Lead.CPrim.FaiHelper.Properties
{
	/// <summary>
	///   一个强类型的资源类，用于查找本地化的字符串等。
	/// </summary>
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		/// <summary>
		///   返回此类使用的缓存的 ResourceManager 实例。
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					ResourceManager temp = (resourceMan = new ResourceManager("Lead.CPrim.FaiHelper.Properties.Resources", typeof(Resources).Assembly));
				}
				return resourceMan;
			}
		}

		/// <summary>
		///   重写当前线程的 CurrentUICulture 属性
		///   重写当前线程的 CurrentUICulture 属性。
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal Resources()
		{
		}
	}
}
