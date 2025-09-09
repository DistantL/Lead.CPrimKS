using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Lead.CPrim.Interfaces.Display
{
    public interface IErrorCode
    {
        /// <summary>当前报警代码</summary>
        string ErrorCodeCurrent { get;}

        /// <summary>当前报警代码集合</summary>
        ConcurrentDictionary<string, string> DicErrorCode { get;}

        /// <summary>根据工站导出Errorlist</summary>
        /// <param name="save">true：导出到本地；false：不导出到本地</param>
        /// <returns>0：成功；非0：失败</returns>
        int ErrorCodeOutput(bool save);

        /// <summary>普通报警转化为ErrorCode</summary>
        /// <param name="msg">普通报警</param>
        /// <returns>ErrorCode</returns>
        List<ErrorCodes> ErrorCodeMsg(string msg);

        /// <summary>ErrorCode清除</summary>
        void ErrorCodeClear();
    }
}
