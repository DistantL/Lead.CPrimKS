using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Lead.CPrim.DynamicParam.Properties
{
	/// <summary>
	///   一个强类型的资源类，用于查找本地化的字符串等。
	/// </summary>
	// Token: 0x02000017 RID: 23
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x00008B29 File Offset: 0x00006D29
		internal Resources()
		{
		}

		/// <summary>
		///   返回此类使用的缓存的 ResourceManager 实例。
		/// </summary>
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00008B34 File Offset: 0x00006D34
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager temp = new ResourceManager("Lead.CPrim.DynamicParam.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = temp;
				}
				return Resources.resourceMan;
			}
		}

		/// <summary>
		///   重写当前线程的 CurrentUICulture 属性，对
		///   使用此强类型资源类的所有资源查找执行重写。
		/// </summary>
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00008B7C File Offset: 0x00006D7C
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00008B93 File Offset: 0x00006D93
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		/// <summary>
		///   查找 System.Drawing.Bitmap 类型的本地化资源。
		/// </summary>
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00008B9C File Offset: 0x00006D9C
		internal static Bitmap toolStripButtonAdd_Image
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("toolStripButtonAdd.Image", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		/// <summary>
		///   查找 System.Drawing.Bitmap 类型的本地化资源。
		/// </summary>
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00008BCC File Offset: 0x00006DCC
		internal static Bitmap toolStripButtonDel_Image
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("toolStripButtonDel.Image", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		/// <summary>
		///   查找 System.Drawing.Bitmap 类型的本地化资源。
		/// </summary>
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00008BFC File Offset: 0x00006DFC
		internal static Bitmap toolStripButtonSave_Image
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("toolStripButtonSave.Image", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		/// <summary>
		///   查找 System.Drawing.Bitmap 类型的本地化资源。
		/// </summary>
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00008C2C File Offset: 0x00006E2C
		internal static Bitmap tsBtnCopyPasteParam_Image
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("tsBtnCopyPasteParam.Image", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		/// <summary>
		///   查找 System.Drawing.Bitmap 类型的本地化资源。
		/// </summary>
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00008C5C File Offset: 0x00006E5C
		internal static Bitmap tsBtnEditProductParam_Image
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("tsBtnEditProductParam.Image", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		/// <summary>
		///   查找 System.Drawing.Bitmap 类型的本地化资源。
		/// </summary>
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00008C8C File Offset: 0x00006E8C
		internal static Bitmap tsBtnEditUdt_Image
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("tsBtnEditUdt.Image", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		/// <summary>
		///   查找 System.Drawing.Bitmap 类型的本地化资源。
		/// </summary>
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00008CBC File Offset: 0x00006EBC
		internal static Bitmap tsBtnNewUdt_Image
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("tsBtnNewUdt.Image", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}

		// Token: 0x0400008B RID: 139
		private static ResourceManager resourceMan;

		// Token: 0x0400008C RID: 140
		private static CultureInfo resourceCulture;
	}
}
