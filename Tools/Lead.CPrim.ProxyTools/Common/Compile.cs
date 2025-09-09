using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
	public static class Compile
	{
		/// <summary>
		/// 动态生成dll
		/// </summary>
		/// <param name="code"></param>
		/// <param name="path"></param>
		/// <param name="dlls">引用dll数组</param>
		/// <returns></returns>
		public static CompilerResults CreateDll(this string code, string path, string[] dlls = null)
		{
			CSharpCodeProvider complier = new CSharpCodeProvider();

			//设置编译参数
			CompilerParameters paras = new CompilerParameters();
			//引入第三方dll
			paras.ReferencedAssemblies.Add(@"System.dll");
			paras.ReferencedAssemblies.Add(@"System.Configuration.dll");
			paras.ReferencedAssemblies.Add(@"System.Data.dll");
			paras.ReferencedAssemblies.Add(@"System.Management.dll");
			paras.ReferencedAssemblies.Add(@"System.Web.dll");
			paras.ReferencedAssemblies.Add(@"System.Xml.dll");
			paras.ReferencedAssemblies.Add(@"System.IO.dll");
			if (dlls.IsValid())
			{
				foreach (var item in dlls)
				{
					paras.ReferencedAssemblies.Add(item);
				}
			}

			//引入自定义dll

			//是否内存中生成输出
			paras.GenerateInMemory = false;
			//是否生成可执行文件
			paras.GenerateExecutable = false;
			paras.IncludeDebugInformation = true;
			paras.OutputAssembly = path;

			//编译代码
			return complier.CompileAssemblyFromSource(paras, code);
		}
	}
}
