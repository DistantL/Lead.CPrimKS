using System;
using System.Collections.Generic;

namespace Lead.CPrim.Interfaces.OPC
{
    public delegate void DelSingleSubscription(string nodeId, object obj);

    public delegate void DelBatchSubscription(string key, Dictionary<string, object> objs);
    public interface IOPC
    {
        /// <summary>
        /// 单个节点订阅事件节点内容改变时触发
        /// </summary>
        event DelSingleSubscription OnSingleSubscription;
        /// <summary>
        /// 多个节点订阅事件节点内容改变时触发
        /// </summary>
        event DelBatchSubscription OnBatchSubscription;
        /// <summary>
        /// 读单个节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        T Read<T>(string nodeId);
        /// <summary>
        /// 写单个节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodeId"></param>
        /// <param name="updateValue"></param>
        /// <returns></returns>
        bool Write<T>(string nodeId, T updateValue);
        /// <summary>
        /// 批量节点订阅
        /// </summary>
        /// <param name="key"></param>
        /// <param name="nodes"></param>
        void BatchSubscription(string key, string[] nodes);
        /// <summary>
        /// 单个节点订阅
        /// </summary>
        /// <param name="key"></param>
        /// <param name="nodeId"></param>
        void SingleSubscription(string key, string nodeId);
        /// <summary>
        /// 取消单个节点订阅
        /// </summary>
        /// <param name="key"></param>
        void CancelSingleSubscription(string key);
        /// <summary>
        /// 取消多个节点订阅
        /// </summary>
        void CancelAllSubscription();
        /// <summary>
        /// 清除订阅事件
        /// </summary>
        /// <returns></returns>
        int ClearEventOnMsgReved();

        object ReadByNodeName(string nodeName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int IPrimTaskInit();
        /// <summary>
        /// 批量写入
        /// </summary>
        /// <param name="NodeIdArray">节点ID数组</param>
        /// <param name="NodeidvalueArray">待写入数据</param>
        /// <returns></returns>
        int BatchWrite(string[] NodeIdArray, Object[] NodeidvalueArray);
        /// <summary>
        /// 批量读取
        /// </summary>
        /// <param name="nodeIdlist"></param>
        /// <returns></returns>
        Dictionary<string, object> BatchRead(List<string> nodeIdlist);
    }
}
