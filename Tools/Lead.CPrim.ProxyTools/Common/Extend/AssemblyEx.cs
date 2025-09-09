using System;
using System.Reflection;

namespace Lead.CPrim.ProxyTools
{
    public static class AssemblyEx
    {
        /// <summary>
        /// 获取包含清单的已加载文件的完整路径或 UNC 位置。
        /// </summary>
        /// <param name="asm"></param>
        /// <returns></returns>
        public static string Location(this Assembly asm)
        {
            if (asm.IsDynamic())
            {
                //asm.GetHashCode()：返回此实例的哈希代码。
                string environmentVariable = Environment.GetEnvironmentVariable("location:" + asm.GetHashCode());
                return environmentVariable ?? "";
            }
            return asm.Location;
        }

        /// <summary>
        /// true：动态程序集；false：非动态程序集；
        /// </summary>
        /// <param name="asm"></param>
        /// <returns></returns>
        public static bool IsDynamic(this Assembly asm)
        {
            //动态程序集的特点：
            //1、类型全名以"AssemblyBuilder"结尾
            //2、Location为空
            return asm.GetType().FullName.EndsWith("AssemblyBuilder") || string.IsNullOrEmpty(asm.Location);
        }

        public static Type GetCurrentType(string typename)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            return executingAssembly.GetType(typename);
        }

        public static Type GetDllType(string dll, string typename)
        {
            Assembly assembly = Assembly.LoadFile(dll);
            return assembly.GetType(typename);
        }

        public static Type[] GetCurrentTypes()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            return executingAssembly.GetTypes();
        }

        public static Type[] GetDllTypes(string dll)
        {
            Assembly assembly = Assembly.LoadFile(dll);
            return assembly.GetExportedTypes();
        }

        public static object CreateInstance(this Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
