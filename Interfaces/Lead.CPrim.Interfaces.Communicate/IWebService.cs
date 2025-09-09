using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Communicate
{
    public delegate object InvokeMethodAsync(string className, string methodName, params object[] paramters);

    public interface IWebService
    {
        string Url { get; set; }

        bool InvokeAsync { get; set; }

        MethodInfo GetMethod(string className, string methodName);

        IList<MethodInfo> GetAllMethods(string className);

        IList<MethodInfo> GetAllMethods();

        IList<Type> GetExportedTypes();

        string GetServerName();

        Object InvokeMethod(string className, string methodName, params object[] paramaters);
    }
}
