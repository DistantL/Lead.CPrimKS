using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces
{
    /// <summary>信息交换（用户接口）</summary>
    public interface IVarManager
    {
        #region Define_Event
        /// <summary>队列模式值改变时发生</summary>
        event RemoteQueueVariableChanged OnQueueVariableChanged;
        /// <summary>循环模式值改变时发生</summary>
        event RemoteVariableChanged OnVariableChanged;
        #endregion



        #region Method
        /// <summary>值读取（支持循环模式）</summary>
        /// <param name="varName">键</param>
        /// <returns>object</returns>
        object Read(string varName);
        /// <summary>值读取（支持循环模式泛型类）</summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="varName">键</param>
        /// <returns>T</returns>
        T ReadMultiVar<T>(string varName) where T : class;
        /// <summary>值写入</summary>
        /// <param name="varName">键</param>
        /// <param name="value">值</param>
        /// <returns>int</returns>
        int Write(string varName, object value);
        /// <summary>值写入（不支持Class与Other）</summary>
        /// <param name="varName">键</param>
        /// <param name="value">值</param>
        /// <returns>int</returns>
        int Write(string varName, string value);
        int Enqueue(string varName, object value);
        int Dequeue(string varName, out object obj);
        int DequeueMultiVar<T>(string varName, out T obj) where T : class;
        int Peek(string varName, out object obj);
        int ClearQueue(string varName);
        int QueueCount(string varName);
        int AddVar(RemoteVar newVar); 
        #endregion
    }
}
