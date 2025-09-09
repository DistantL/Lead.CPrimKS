using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// Mongodb帮助类<br/>
    /// </summary>
    public class MongodbHelper
    {
        #region Field
        /// <summary>数据库表名</summary>
        private static string _collectionName;

        /// <summary>数据库连接字符串（默认本地）</summary>
        private static string _connStr;

        /// <summary>默认数据库（Lead）</summary>
        private static string _databaseName;

        /// <summary>数据库初始化出错标志（true：出错；false：无错误）</summary>
        private static bool _initedError = true;

        /// <summary>数据库客户端</summary>
        public static MongoClient _client;

        /// <summary>数据库</summary>
        public static IMongoDatabase _database;

        /// <summary>数据库连接记录</summary>
        public static List<IpClientDb> _connectionrRecord = new List<IpClientDb>();
        #endregion



        #region Ctor
        static MongodbHelper()
        {
            _collectionName = "parts";
            _connStr = "mongodb://localhost:27017/authdb?serverSelectionTimeoutMS=5000&connectTimeoutMS=3000&socketTimeoutMS=3000";
            _databaseName = "Lead";

            try
            {
                _client = new MongoClient(_connStr);
                _database = _client.GetDatabase(_databaseName, null);
                _initedError = false;
            }
            catch (Exception ex)
            {
                LogAdd($"构造方法异常：{ex.Message},{ex.StackTrace}");
                _initedError = true;
            }
        }
        #endregion



        #region 增
        /// <summary>插入单条数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">插入对象</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int InsertOne<T>(T entity, string collectionName = null, string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;

            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (entity == null)
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            try
            {
                collection.InsertOne(entity, null, default);
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(InsertOne)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>插入单条数据（异步操作）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">插入对象</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static async Task<int> InsertOneAsync<T>(T entity, string collectionName = null, string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;

            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (entity == null)
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            try
            {
                await collection.InsertOneAsync(entity, null, default(CancellationToken));
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(InsertOneAsync)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>插入多组数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entityList">插入对象列表</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int InsertMany<T>(List<T> entityList, string collectionName = null, string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;

            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (entityList == null || entityList.Count == 0)
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            try
            {
                collection.InsertMany(entityList, null, default(CancellationToken));
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(InsertMany)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>插入多组数据（异步操作）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entityList">插入对象列表</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static async Task<int> InsertManyAsync<T>(List<T> entityList, string collectionName = null, string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;

            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (entityList == null || entityList.Count == 0)
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            try
            {
                await collection.InsertManyAsync(entityList, null, default(CancellationToken));
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(InsertManyAsync)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }
        #endregion



        #region 删
        /// <summary>
        /// 删除通用方法（同步）
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">字段值</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="deleteEnum">删除选项</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0成功</returns>
        private static int DeleteCommon<T>(
            DateTime startTime,
            DateTime endTime,
            string fieldName,
            string value,
            string sortField = null,
            DeleteEnum deleteEnum = DeleteEnum.DeleteOne,
            string collectionName = null,
            string connectIp = null)
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "CreateTime";
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);

            FilterDefinition<T> filter;
            //某时间段内单条件删除
            if (!fieldName.IsNullOrEmpty() && startTime != default && endTime != default)
            {
                filter = Builders<T>.Filter.Eq(fieldName, value) & Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
            }
            //某时间段内全部删除
            else if (fieldName.IsNullOrEmpty() && startTime != default && endTime != default)
            {
                filter = Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
            }
            //某时间后全部删除
            else if (fieldName.IsNullOrEmpty() && startTime != default && endTime == default)
            {
                filter = Builders<T>.Filter.Gte(sortField, startTime);
            }
            //某时间前全部删除
            else if (fieldName.IsNullOrEmpty() && startTime == default && endTime != default)
            {
                filter = Builders<T>.Filter.Lte(sortField, endTime);
            }
            //单条件删除
            else if (!fieldName.IsNullOrEmpty() && startTime == default && endTime == default)
            {
                filter = Builders<T>.Filter.Eq(fieldName, value);
            }
            //清空所有数据
            else
            {
                filter = Builders<T>.Filter.Ne("_id", "");
            }

            try
            {
                DeleteResult result;
                switch (deleteEnum)
                {
                    case DeleteEnum.DeleteMany:
                        result = collection.DeleteMany(filter, default);
                        break;

                    case DeleteEnum.DeleteOne:
                    default:
                        result = collection.DeleteOne(filter, default);
                        break;
                }
                if (result == DeleteResult.Unacknowledged.Instance)
                {
                    return (int)SoftWareAlarm.MongoDB_删除失败;
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(DeleteCommon)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>删除通用方法（异步）</summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">字段值</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="deleteEnum">删除选项</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0成功</returns>
        private static async Task<int> DeleteCommonAsync<T>(
            DateTime startTime,
            DateTime endTime,
            string fieldName,
            string value,
            string sortField = null,
            DeleteEnum deleteEnum = DeleteEnum.DeleteOneAsync,
            string collectionName = null,
            string connectIp = null)
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "CreateTime";
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);

            FilterDefinition<T> filter;
            //某时间段内单条件删除
            if (!fieldName.IsNullOrEmpty() && startTime != default && endTime != default)
            {
                filter = Builders<T>.Filter.Eq(fieldName, value) & Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
            }
            //某时间段内全部删除
            else if (fieldName.IsNullOrEmpty() && startTime != default && endTime != default)
            {
                filter = Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
            }
            //某时间后全部删除
            else if (fieldName.IsNullOrEmpty() && startTime != default && endTime == default)
            {
                filter = Builders<T>.Filter.Gte(sortField, startTime);
            }
            //某时间前全部删除
            else if (fieldName.IsNullOrEmpty() && startTime == default && endTime != default)
            {
                filter = Builders<T>.Filter.Lte(sortField, endTime);
            }
            //单条件删除
            else if (!fieldName.IsNullOrEmpty() && startTime == default && endTime == default)
            {
                filter = Builders<T>.Filter.Eq(fieldName, value);
            }
            //清空所有数据
            else
            {
                filter = Builders<T>.Filter.Ne("_id", "");
            }

            try
            {
                DeleteResult result;
                switch (deleteEnum)
                {
                    case DeleteEnum.DeleteManyAsync:
                        result = await collection.DeleteManyAsync(filter, default);
                        break;

                    case DeleteEnum.DeleteOneAsync:
                    default:
                        result = await collection.DeleteOneAsync(filter, default);
                        break;
                }
                if (result == DeleteResult.Unacknowledged.Instance)
                {
                    return (int)SoftWareAlarm.MongoDB_删除失败;
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(DeleteCommonAsync)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>
        /// 按单条件删除单条数据
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int DeleteOne<T>(string fieldName, string value, string collectionName = null, string connectIp = null) where T : class
        {
            if (fieldName.IsNullOrEmpty() || value.IsNullOrEmpty())
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            return DeleteCommon<T>(default, default, fieldName, value, null, DeleteEnum.DeleteOne, collectionName, connectIp);
        }

        /// <summary>按单条件删除单条数据（异步）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static async Task<int> DeleteOneAsync<T>(string fieldName, string value, string collectionName = null, string connectIp = null) where T : class
        {
            if (fieldName.IsNullOrEmpty() || value.IsNullOrEmpty())
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            return await DeleteCommonAsync<T>(default, default, fieldName, value, null, DeleteEnum.DeleteOneAsync, collectionName, connectIp);
        }

        /// <summary>按单条件删除多组数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int DeleteMany<T>(string fieldName, string value, string collectionName = null, string connectIp = null) where T : class
        {
            if (fieldName.IsNullOrEmpty() || value.IsNullOrEmpty())
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            return DeleteCommon<T>(default, default, fieldName, value, null, DeleteEnum.DeleteMany, collectionName, connectIp);
        }

        /// <summary>按单条件删除多组数据（异步）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static async Task<int> DeleteManyAsync<T>(string fieldName, string value, string collectionName = null, string connectIp = null) where T : class
        {
            if (fieldName.IsNullOrEmpty() || value.IsNullOrEmpty())
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            return await DeleteCommonAsync<T>(default, default, fieldName, value, null, DeleteEnum.DeleteManyAsync, collectionName, connectIp);
        }

        /// <summary>按单条件删除多组数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int DeleteAll<T>(string collectionName = null, string connectIp = null) where T : class
        {
            return DeleteCommon<T>(default, default, null, null, null, DeleteEnum.DeleteMany, collectionName, connectIp);
        }

        /// <summary>按单条件删除多组数据（异步）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static async Task<int> DeleteAllAsync<T>(string collectionName = null, string connectIp = null) where T : class
        {
            return await DeleteCommonAsync<T>(default, default, null, null, null, DeleteEnum.DeleteManyAsync, collectionName, connectIp);
        }

        /// <summary>通过起止时间删除数据 （默认异步）</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="startTime">起始时间（为null时，删除endtime之前的数据，两者都为null删除所有数据）</param>
        /// <param name="endTime">终止时间（为null是，删除starttime之后的数据，两者都为null删除所有数据）</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static async Task<int> DeleteAllByTime<T>(string startTime, string endTime, string collectionName = null, string connectIp = null) where T : class
        {
            DateTime start;
            DateTime end;

            if (startTime == null)
            {
                start = default;
            }
            if (endTime == null)
            {
                end = default;
            }

            if (!DateTime.TryParse(startTime, out start) || !DateTime.TryParse(endTime, out end))
            {
                return (int)SoftWareAlarm.MongoDB_查询时字符串转换为时间格式失败;
            }

            if (startTime != null && endTime != null && start > end)
            {
                return (int)SoftWareAlarm.MongoDB_开始时间大于结束时间;
            }

            return await DeleteCommonAsync<T>(start, end, null, null, null, DeleteEnum.DeleteManyAsync, collectionName, connectIp);
        }

        /// <summary>通过起止时间删除数据（默认异步）</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="startTime">起始时间（为Default时,删除endtime之前的数据,两者都为null删除所有数据）</param>
        /// <param name="endTime">终止时间（为null是,删除starttime之后的数据,两者都为null删除所有数据）</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static async Task<int> DeleteAllByTime<T>(DateTime startTime, DateTime endTime, string collectionName = null, string connectIp = null) where T : class
        {
            if (startTime != default && endTime != default && startTime > endTime)
            {
                return (int)SoftWareAlarm.MongoDB_开始时间大于结束时间;
            }

            return await DeleteCommonAsync<T>(startTime, endTime, null, null, null, DeleteEnum.DeleteManyAsync, collectionName, connectIp);
        }
        #endregion



        #region 改
        /// <summary>替换一条数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="chosedField">查询数据的字段名</param>
        /// <param name="chosedValue">查询数据的字段值</param>
        /// <param name="entiy">新对象</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int ReplaceOne<T>(string chosedField, string chosedValue, T entiy, string collectionName = null, string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(chosedField) || entiy == null)
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(chosedField, chosedValue);
            try
            {
                ReplaceOneResult result = collection.ReplaceOne(filter, entiy, new ReplaceOptions { IsUpsert = true }, default);
                if (!result.IsAcknowledged)
                {
                    return (int)SoftWareAlarm.MongoDB_更新失败;
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(ReplaceOne)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>
        /// 替换一条数据<br/>
        /// 注意1：查找失败时默认不进行插入操作，如果进行插入操作，需将isUpsert设置为true
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="chosedField">查询数据的字段名</param>
        /// <param name="chosedValue">查询数据的字段值</param>
        /// <param name="entiy">新的对象</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="isUpsert">true：查找失败进行插入操作；false：查找失败不进行插入操作</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <returns>SoftWareReturns</returns>
        public static async Task<int> ReplaceOneAsync<T>(
            string chosedField,
            string chosedValue,
            T entiy,
            string collectionName = null,
            bool isUpsert = false,
            string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(chosedField) || entiy == null)
            {
                throw new ArgumentNullException("chosedField");
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(chosedField, chosedValue);
            try
            {
                ReplaceOneResult result = await collection.ReplaceOneAsync(filter, entiy, new ReplaceOptions() { IsUpsert = isUpsert }, default(CancellationToken));
                if (!result.IsAcknowledged)
                {
                    throw new Exception("IsAcknowledged == false");
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(ReplaceOneAsync)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>更新多条数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="chosedField">查询数据的字段名</param>
        /// <param name="chosedValue">查询数据的字段值</param>
        /// <param name="updateField">更新数据的字段名</param>
        /// <param name="updateValue">更新数据的字段值</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <param name="isUpdateTime"></param>
        /// <param name="timeField"></param>
        /// <returns>0-成功</returns>
        public static int UpdateMany<T>(string chosedField, string chosedValue, string updateField, string updateValue, string collectionName = null, string connectIp = null, bool isUpdateTime = false, string timeField = "dateTime") where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(chosedField) || string.IsNullOrEmpty(updateField))
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(chosedField, chosedValue);
            UpdateDefinition<T> updated;
            if (isUpdateTime)
            {
                updated = Builders<T>.Update.Set(updateField, updateValue).CurrentDate(timeField);
            }
            else
            {
                updated = Builders<T>.Update.Set(updateField, updateValue);
            }
            try
            {
                UpdateResult result = collection.UpdateMany(filter, updated, (UpdateOptions)null, default(CancellationToken));
                if (!result.IsAcknowledged)
                {
                    return (int)SoftWareAlarm.MongoDB_更新失败;
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(UpdateMany)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>更新多条数据（异步）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="chosedField">查询数据的字段名</param>
        /// <param name="chosedValue">查询数据的字段值</param>
        /// <param name="updateField">更新数据的字段名</param>
        /// <param name="updateValue">更新数据的字段值</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <param name="isUpdateTime"></param>
        /// <param name="timeField"></param>
        /// <returns>0-成功</returns>
        public static async Task<int> UpdateManyAsync<T>(string chosedField, string chosedValue, string updateField, string updateValue, string collectionName = null, string connectIp = null, bool isUpdateTime = false, string timeField = "dateTime") where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(chosedField) || string.IsNullOrEmpty(updateField))
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(chosedField, chosedValue);
            UpdateDefinition<T> updated;
            if (isUpdateTime)
            {
                updated = Builders<T>.Update.Set(updateField, updateValue).CurrentDate(timeField);
            }
            else
            {
                updated = Builders<T>.Update.Set(updateField, updateValue);
            }
            try
            {
                UpdateResult result = await collection.UpdateManyAsync(filter, updated, (UpdateOptions)null, default(CancellationToken));
                if (!result.IsAcknowledged)
                {
                    return (int)SoftWareAlarm.MongoDB_更新失败;
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(UpdateManyAsync)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>更新一条数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="chosedField">查询数据的字段名</param>
        /// <param name="chosedValue">查询数据的字段值</param>
        /// <param name="updateField">更新数据的字段名</param>
        /// <param name="updateValue">更新数据的字段值</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <param name="isUpdateTime"></param>
        /// <param name="timeField"></param>
        /// <returns>0-成功</returns>
        public static int UpdateOne<T>(string chosedField, string chosedValue, string updateField, string updateValue, string collectionName = null, string connectIp = null, bool isUpdateTime = false, string timeField = "dateTime") where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(chosedField) || string.IsNullOrEmpty(updateField))
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(chosedField, chosedValue);
            UpdateDefinition<T> updated;
            if (isUpdateTime)
            {
                updated = Builders<T>.Update.Set(updateField, updateValue).CurrentDate(timeField);
            }
            else
            {
                updated = Builders<T>.Update.Set(updateField, updateValue);
            }

            try
            {
                UpdateResult result = collection.UpdateOne(filter, updated, (UpdateOptions)null, default(CancellationToken));
                if (!result.IsAcknowledged)
                {
                    return (int)SoftWareAlarm.MongoDB_更新失败;
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(UpdateOne)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>更新一条数据（异步）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="chosedField">查询数据的字段名</param>
        /// <param name="chosedValue">查询数据的字段值</param>
        /// <param name="updateField">更新数据的字段名</param>
        /// <param name="updateValue">更新数据的字段值</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <param name="isUpdateTime"></param>
        /// <param name="timeField"></param>
        /// <returns>0-成功</returns>
        public static async Task<int> UpdateOneAsync<T>(string chosedField, string chosedValue, string updateField, string updateValue, string collectionName = null, string connectIp = null, bool isUpdateTime = false, string timeField = "dateTime") where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(chosedField) || string.IsNullOrEmpty(updateField))
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(chosedField, chosedValue);
            UpdateDefinition<T> updated;
            if (isUpdateTime)
            {
                updated = Builders<T>.Update.Set(updateField, updateValue).CurrentDate(timeField);
            }
            else
            {
                updated = Builders<T>.Update.Set(updateField, updateValue);
            }

            try
            {
                UpdateResult result = await collection.UpdateOneAsync(filter, updated, (UpdateOptions)null, default(CancellationToken));
                if (!result.IsAcknowledged)
                {
                    return (int)SoftWareAlarm.MongoDB_更新失败;
                }
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(UpdateOneAsync)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }
        #endregion



        #region 查
        /// <summary>普通查询通用方法</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldArray">字段名数组</param>
        /// <param name="valueArray">字段值数组</param>
        /// <param name="result">查询到的对象（List T）</param>
        /// <param name="dataSort">数据排序（默认降序）</param>
        /// <param name="sortField">排序字段（默认为CreateTime）</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        private static int QueryCommon<T>(
            string[] fieldArray,
            string[] valueArray,
            out List<T> result,
            DataSort dataSort = DataSort.Descending,
            string sortField = "CreateTime",
            string collectionName = null,
            string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRet = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRet != 0)
            {
                result = null;
                return iRet;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);

            FilterDefinition<T> filter;
            if (fieldArray != null && fieldArray.Length > 0 && valueArray != null && valueArray.Length > 0)
            {
                FilterDefinition<T>[] filterAll = new FilterDefinition<T>[fieldArray.Length];
                for (int i = 0; i < fieldArray.Length; i++)
                {
                    filterAll[i] = Builders<T>.Filter.Eq(fieldArray[i], valueArray[i]);
                }
                filter = Builders<T>.Filter.And(filterAll);
            }
            else if (fieldArray == null && valueArray == null)
            {
                filter = Builders<T>.Filter.Ne("_id", "");
            }
            else
            {
                result = null;
                return 666;
            }
            ProjectionDefinition<T> projection = Builders<T>.Projection.Exclude("_id");
            SortDefinition<T> sort = null;
            if (!sortField.IsNullOrEmpty())
            {
                sort = CreateSortDefinition<T>(dataSort, sortField);
            }

            FindOptions findOption = CreateFindOptionsDefault();
            result = null;
            try
            {
                var document = !string.IsNullOrEmpty(sortField)
                    ? collection.Find<T>(filter, findOption).Project<T>(projection).Sort(sort)
                    : collection.Find<T>(filter, findOption).Project<T>(projection);
                result = document.ToList();
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(QueryCommon)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>按时间查询通用方法</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="fieldArray">字段名称数组</param>
        /// <param name="valueArray">字段值数组</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="result">查询结果</param>
        /// <param name="timeOrder">时间顺序,默认Eq</param>
        /// <param name="dataSort">数据排序,默认Descending</param>
        /// <param name="sortField"></param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// 
        /// <returns>0-成功</returns>
        private static int QueryManyByTimeCommon<T>(
            string[] fieldArray,
            string[] valueArray,
            DateTime startTime,
            DateTime endTime,
            out List<T> result,
            TimeOrder timeOrder = TimeOrder.Eq,
            DataSort dataSort = DataSort.Descending,
            string sortField = null,
            string collectionName = null,
            string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                result = null;
                return iRetReturn;
            }

            if (fieldArray != null && valueArray != null)
            {
                if (fieldArray.Length != valueArray.Length)
                {
                    result = null;
                    return (int)SoftWareAlarm.MongoDB_条件与值计数不一致;
                }
            }

            if (startTime > endTime)
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_开始时间大于结束时间;
            }

            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "CreateTime";
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filter;
            FilterDefinition<T> filterTime = Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
            if (fieldArray != null && fieldArray.Length >= 1)
            {
                FilterDefinition<T>[] subFilters = new FilterDefinition<T>[fieldArray.Length + 1];
                for (int i = 0; i < subFilters.Length - 1; i++)
                {
                    switch (timeOrder)
                    {
                        case TimeOrder.Gt:
                            subFilters[i] = Builders<T>.Filter.Gt(fieldArray[i], valueArray[i]);
                            break;

                        case TimeOrder.Gte:
                            subFilters[i] = Builders<T>.Filter.Gte(fieldArray[i], valueArray[i]);
                            break;

                        case TimeOrder.Eq:
                            subFilters[i] = Builders<T>.Filter.Eq(fieldArray[i], valueArray[i]);
                            break;

                        case TimeOrder.Lt:
                            subFilters[i] = Builders<T>.Filter.Lt(fieldArray[i], valueArray[i]);
                            break;

                        case TimeOrder.Lte:
                            subFilters[i] = Builders<T>.Filter.Lte(fieldArray[i], valueArray[i]);
                            break;

                        case TimeOrder.Ne:
                            subFilters[i] = Builders<T>.Filter.Ne(fieldArray[i], valueArray[i]);
                            break;

                        case TimeOrder.Other:
                        default:
                            subFilters[i] = Builders<T>.Filter.Eq(fieldArray[i], valueArray[i]);
                            break;
                    }
                }
                subFilters[fieldArray.Length] = filterTime;
                filter = Builders<T>.Filter.And(subFilters);
            }
            else
            {
                filter = filterTime;
            }

            SortDefinition<T> sort = CreateSortDefinition<T>(dataSort, sortField);
            ProjectionDefinition<T> projection = Builders<T>.Projection.Exclude("_id");
            FindOptions findOption = CreateFindOptionsDefault();
            result = null;
            try
            {
                var document = collection.Find<T>(filter, findOption).Project<T>(projection).Sort(sort);
                result = document.ToList();
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"{nameof(QueryManyByTimeCommon)}：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>查询第一个</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">查询字段名</param>
        /// <param name="value">查询字段值</param>
        /// <param name="result">查询到的对象，没有或出错则为null</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="sortField">排序字段（默认CreateTime，为null时不进行排序）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryOneFirst<T>(string fieldName, string value, out T result, string collectionName = null, string sortField = "CreateTime", string connectIp = null) where T : class
        {
            if (fieldName.IsNullOrEmpty())
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            List<T> listResult = new List<T>();
            int iRet = QueryCommon<T>(new string[1] { fieldName }, new string[1] { value }, out listResult, DataSort.Ascending, sortField, collectionName, connectIp);
            result = (iRet == 0 && listResult != null && listResult.Count > 0) ? listResult.First() : null;
            return iRet;
        }

        /// <summary>查询最后一个</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">查询字段名</param>
        /// <param name="value">查询字段值</param>
        /// <param name="result">查询到的对象，没有或出错则为null</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryOneLast<T>(string fieldName, string value, out T result, string collectionName = null, string connectIp = null, string sortField = "CreateTime") where T : class
        {
            if (fieldName.IsNullOrEmpty())
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            int iRet = QueryCommon<T>(new string[1] { fieldName }, new string[1] { value }, out List<T> listResult, DataSort.Descending, sortField, collectionName, connectIp);
            result = (iRet == 0 && listResult != null && listResult.Count > 0) ? listResult.First() : null;
            return iRet;
        }

        /// <summary>单一条件查询数据（返回泛型List集合）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">字段值</param>
        /// <param name="result">查询到的对象（List T）</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="sortField">排序字段（默认为CreateTime）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryMany<T>(string fieldName, string value, out List<T> result, string collectionName = null, string sortField = "CreateTime", string connectIp = null) where T : class
        {
            if (fieldName.IsNullOrEmpty())
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            return QueryCommon<T>(new string[1] { fieldName }, new string[1] { value }, out result, DataSort.Descending, sortField, collectionName, connectIp);
        }

        /// <summary>多组条件查询数据（返回泛型List集合）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldArray">字段名称数组</param>
        /// <param name="valueArray">字段值数组</param>
        /// <param name="result">查询到的对象（List T）</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="sortField">排序字段（默认为CreateTime）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryMany<T>(string[] fieldArray, string[] valueArray, out List<T> result, string collectionName = null, string sortField = "CreateTime", string connectIp = null) where T : class
        {
            if (fieldArray == null || valueArray == null || fieldArray.Length <= 0 || valueArray.Length <= 0)
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (fieldArray.Length != valueArray.Length)
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_条件与值计数不一致;
            }

            return QueryCommon<T>(fieldArray, valueArray, out result, DataSort.Descending, sortField, collectionName, connectIp);
        }

        /// <summary>查询所有数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="result">查询到的对象（List T）</param>
        /// <param name="dataSort">数据排序</param>
        /// <param name="sortField">排序字段（默认为CreateTime）</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryAll<T>(out List<T> result, DataSort dataSort, string sortField = "CreateTime", string collectionName = null, string connectIp = null) where T : class
        {
            return QueryCommon<T>(null, null, out result, dataSort, sortField, collectionName, connectIp);
        }

        /// <summary>查询所有数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="result">查询到的对象（List T）</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryAll<T>(out List<T> result, string collectionName = null, string connectIp = null) where T : class
        {
            return QueryCommon<T>(null, null, out result, DataSort.Descending, null, collectionName, connectIp);
        }

        /// <summary>通过起止时间查询数据（返回泛型List集合）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="startTime">起始时间（可为null）</param>
        /// <param name="endTime">终止时间（可为null）</param>
        /// <param name="result">查询结果</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(string startTime, string endTime, out List<T> result, string collectionName = null, string connectIp = null) where T : class
        {
            if (startTime == null)
            {
                startTime = "2000-01-01 01:01:01Z";
            }
            if (endTime == null)
            {
                endTime = "2200-01-01 01:01:01Z";
            }

            DateTime start;
            DateTime end;

            if (!DateTime.TryParse(startTime, out start) || !DateTime.TryParse(endTime, out end))
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_查询时字符串转换为时间格式失败;
            }

            return QueryManyByTimeCommon<T>(null, null, start, end, out result, TimeOrder.Eq, DataSort.Descending, null, collectionName, connectIp);
        }

        /// <summary>通过起止时间查询数据（返回DataTable）</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="startTime">起始时间（可为null）</param>
        /// <param name="endTime">终止时间（可为null）</param>
        /// <param name="dtResult">查询到的对象,DataTable类型，没有或出错则为null</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(string startTime, string endTime, out DataTable dtResult, string collectionName = null, string connectIp = null) where T : class
        {
            List<T> listResult;
            int iRet = QueryManyByTime<T>(startTime, endTime, out listResult, collectionName, (string)null);
            dtResult = (listResult != null && iRet == 0) ? DataHelper.ListToDataTable(listResult) : null;
            return iRet;
        }

        /// <summary>通过起止时间查询数据（返回泛型List集合）</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">终止时间）</param>
        /// <param name="result">查询结果</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(DateTime startTime, DateTime endTime, out List<T> result, string collectionName = null, string connectIp = null) where T : class
        {
            return QueryManyByTimeCommon<T>(null, null, startTime, endTime, out result, TimeOrder.Eq, DataSort.Descending, null, collectionName, connectIp);
        }

        /// <summary>通过起止时间查询数据（返回DataTable）</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">终止时间）</param>
        /// <param name="dtResult">查询到的对象,DataTable类型，没有或出错则为null</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(DateTime startTime, DateTime endTime, out DataTable dtResult, string collectionName = null, string connectIp = null) where T : class
        {
            List<T> listResult;
            int iRet = QueryManyByTime<T>(startTime, endTime, out listResult, collectionName, (string)null);
            dtResult = ((listResult != null && iRet == 0) ? DataHelper.ListToDataTable(listResult) : null);
            return iRet;
        }

        /// <summary>通过起止时间_多组条件查询数据（返回泛型List集合）</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="fieldArray">字段名称数组</param>
        /// <param name="valueArray">字段值数组</param>
        /// <param name="startTime">起始时间（可为null）</param>
        /// <param name="endTime">终止时间（可为null）</param>
        /// <param name="result">查询结果</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(string[] fieldArray, string[] valueArray, string startTime, string endTime, out List<T> result, string collectionName = null, string connectIp = null) where T : class
        {
            if (startTime == null)
            {
                startTime = "2000-01-01 01:01:01Z";
            }
            if (endTime == null)
            {
                endTime = "2200-01-01 01:01:01Z";
            }

            DateTime start;
            DateTime end;

            if (!DateTime.TryParse(startTime, out start) || !DateTime.TryParse(endTime, out end))
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_查询时字符串转换为时间格式失败;
            }
            return QueryManyByTimeCommon<T>(fieldArray, valueArray, start, end, out result, TimeOrder.Eq, DataSort.Descending, null, collectionName, connectIp);
        }

        /// <summary>通过起止时间_多组条件查询数据（返回DataTable）</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="fieldArray">字段名称数组</param>
        /// <param name="valueArray">字段值数组</param>
        /// <param name="startTime">起始时间（可为null）</param>
        /// <param name="endTime">终止时间（可为null）</param>
        /// <param name="dtResult">查询到的对象,DataTable类型，没有或出错则为null</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(string[] fieldArray, string[] valueArray, string startTime, string endTime, out DataTable dtResult, string collectionName = null, string connectIp = null) where T : class
        {
            List<T> listResult;
            int iRet = QueryManyByTime<T>(fieldArray, valueArray, startTime, endTime, out listResult, collectionName, (string)null);
            dtResult = ((listResult != null && iRet == 0) ? DataHelper.ListToDataTable(listResult) : null);
            return iRet;
        }

        /// <summary>通过起止时间_多组条件查询数据（返回泛型List集合）</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="fieldArray">字段名称数组</param>
        /// <param name="valueArray">字段值数组</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="result">查询结果</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(string[] fieldArray, string[] valueArray, DateTime startTime, DateTime endTime, out List<T> result, string collectionName = null, string connectIp = null) where T : class
        {
            return QueryManyByTimeCommon<T>(fieldArray, valueArray, startTime, endTime, out result, TimeOrder.Eq, DataSort.Descending, null, collectionName, connectIp);
        }

        /// <summary>通过起止时间_多组条件查询数据（返回DataTable）</summary>
        /// <typeparam name="T">类型（必须包含CreateTime字段）</typeparam>
        /// <param name="fieldArray">字段名称数组</param>
        /// <param name="valueArray">字段值数组</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="dtResult">查询到的对象,DataTable类型，没有或出错则为null</param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(string[] fieldArray, string[] valueArray, DateTime startTime, DateTime endTime, out DataTable dtResult, string collectionName = null, string connectIp = null) where T : class
        {
            List<T> listResult;
            int iRet = QueryManyByTime<T>(fieldArray, valueArray, startTime, endTime, out listResult, collectionName, (string)null);
            dtResult = ((listResult != null && iRet == 0) ? DataHelper.ListToDataTable(listResult) : null);
            return iRet;
        }

        /// <summary>对含Result字段的数据进行查询</summary>
        /// <typeparam name="T">类型（必须包含Result和CreateTime字段）</typeparam>
        /// <param name="startTime">起始时间（可为null）</param>
        /// <param name="endTime">终止时间（可为null）</param>
        /// <param name="result">查询结果</param>
        /// <param name="okCount">OK结果统计（字段值为OK或1）</param>
        /// <param name="ngCount">NG结果统计（字段值为NG或0）</param>
        /// <param name="uph">UPH统计</param>
        /// <param name="noOk"></param>
        /// <param name="noNg"></param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(string startTime, string endTime, out List<T> result, out long okCount, out long ngCount, out double uph, bool noOk = false, bool noNg = false, string collectionName = null, string connectIp = null) where T : class
        {
            if (!FactoryCreator.PropertyExist<T>("Result"))
            {
                result = null;
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                return (int)SoftWareAlarm.MongoDB_查询时类中不包含Result字段;
            }

            List<string> listField = new List<string>();
            List<string> listValue = new List<string>();
            string[] fieldArray;
            string[] valueArray;
            if (noOk && noNg)
            {
                listField.Clear();
                listValue.Clear();
                listField.Add("Result");
                listField.Add("Result");
                listField.Add("Result");
                listField.Add("Result");
                listField.Add("Result");
                listField.Add("Result");
                listField.Add("Result");
                listValue.Add("OK");
                listValue.Add("True");
                listValue.Add("1");
                listValue.Add("NG");
                listValue.Add("0");
                listValue.Add("False");
                listValue.Add("NA");
            }
            else if (!noOk && noNg)
            {
                listField.Clear();
                listValue.Clear();
                listField.Add("Result");
                listField.Add("Result");
                listField.Add("Result");
                listField.Add("Result");
                listValue.Add("NG");
                listValue.Add("0");
                listValue.Add("False");
                listValue.Add("NA");
            }
            else if (noOk && !noNg)
            {
                listField.Clear();
                listValue.Clear();
                listField.Add("Result");
                listField.Add("Result");
                listField.Add("Result");
                listValue.Add("OK");
                listValue.Add("1");
                listValue.Add("True");
            }

            if (listField != null && listField.Count > 0)
            {
                fieldArray = listField.ToArray();
                valueArray = listValue.ToArray();
            }
            else
            {
                fieldArray = null;
                valueArray = null;
            }

            if (startTime == null)
            {
                startTime = "2000-01-01 01:01:01Z";
            }
            if (endTime == null)
            {
                endTime = "2200-01-01 01:01:01Z";
            }

            DateTime start;
            DateTime end;

            if (!DateTime.TryParse(startTime, out start) || !DateTime.TryParse(endTime, out end))
            {
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                result = null;
                return (int)SoftWareAlarm.MongoDB_查询时字符串转换为时间格式失败;
            }

            int iRet = QueryManyByTimeCommon<T>(fieldArray, valueArray, start, end, out result, TimeOrder.Ne, DataSort.Ascending, null, collectionName, connectIp);

            if (iRet != 0 || result == null || result.Count == 0)
            {
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                return iRet;
            }


            okCount = result.Count((T t) => t.GetModelValue("Result").ToUpper() == "OK" || t.GetModelValue("Result").ToUpper() == "1" || t.GetModelValue("Result").ToUpper() == "TRUE");
            ngCount = result.Count - okCount;

            if (DateTime.TryParse(result.First().GetModelValue("CreateTime"), out var uphStartTime) && DateTime.TryParse(result.Last().GetModelValue("CreateTime"), out var uphEndTime))
            {
                double time = (uphEndTime - uphStartTime).TotalHours;
                if (time > 8)
                {
                    uph = -1.0;
                }
                else
                {

                    uph = result.Count / time;
                }
            }
            else
            {
                uph = -10.0;
            }
            return 0;
        }

        /// <summary>对含Result字段的数据进行查询</summary>
        /// <typeparam name="T">类型（必须包含Result和CreateTime字段）</typeparam>
        /// <param name="startTime">起始时间（可为null）</param>
        /// <param name="endTime">终止时间（可为null）</param>
        /// <param name="dtResult">查询到的对象,DataTable类型，没有或出错则为null</param>
        /// <param name="okCount">OK结果统计（字段值为OK或1）</param>
        /// <param name="ngCount">NG结果统计（字段值为NG或0）</param>
        /// <param name="uph">UPH统计</param>
        /// <param name="noOk"></param>
        /// <param name="noNg"></param>
        /// <param name="collectionName">数据表名称（为null时写入parts）</param>
        /// <param name="connectIp">连接的数据库IP地址（为null时是本地）</param>
        /// <returns>0-成功</returns>
        public static int QueryManyByTime<T>(string startTime, string endTime, out DataTable dtResult, out long okCount, out long ngCount, out double uph, bool noOk = false, bool noNg = false, string collectionName = null, string connectIp = null) where T : class
        {
            List<T> listResult;
            int iRet = QueryManyByTime(startTime, endTime, out listResult, out okCount, out ngCount, out uph, noOk, noNg, collectionName, null);
            dtResult = (listResult != null && iRet == 0) ? DataHelper.ListToDataTable(listResult) : null;
            return iRet;
        }

        /// <summary>通过起止时间查询日志数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="startTime">起始时间（可为null）</param>
        /// <param name="endTime">终止时间（可为null）</param>
        /// <param name="result">查询结果</param>
        /// <param name="collectionName">日志数据库表名</param>
        /// <returns>0-成功</returns>
        public static int QueryLogsByTime<T>(string startTime, string endTime, out List<T> result, string collectionName = null) where T : class
        {
            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = "CPrimLog";
            }

            if (startTime == null)
            {
                startTime = "2000-01-01 01:01:01Z";
            }
            if (endTime == null)
            {
                endTime = "2200-01-01 01:01:01Z";
            }

            DateTime start;
            DateTime end;

            if (!DateTime.TryParse(startTime, out start) || !DateTime.TryParse(endTime, out end))
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_查询时字符串转换为时间格式失败;
            }

            return QueryManyByTimeCommon<T>(null, null, start, end, out result, TimeOrder.Eq, DataSort.Descending, "TimeStamp", collectionName, null);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 客户端/数据库获取（通过连接IP判定）
        /// </summary>
        /// <param name="connectIp">IP</param>
        /// <param name="client">客户端</param>
        /// <param name="database">数据库</param>
        /// <returns>0-查询成功 1-添加成功</returns>
        private static int ReturnClientAndDatabase(string connectIp, out MongoClient client, out IMongoDatabase database)
        {
            client = null;
            database = null;

            if (connectIp == null)
            {
                if (!_initedError && _client != null && _database != null)
                {
                    client = _client;
                    database = _database;
                    return 0;
                }

                return _client == null ? (int)SoftWareAlarm.MongoDB_客户端为空 : (_database == null ? (int)SoftWareAlarm.MongoDB_数据库为空 : (int)SoftWareAlarm.MongoDB_基元未初始化);
            }

            try
            {
                foreach (IpClientDb record in _connectionrRecord)
                {
                    if (record.connectIp == connectIp)
                    {
                        client = record.client;
                        database = record.database;
                        return 0;
                    }
                }

                _initedError = true;
                client = new MongoClient("mongodb://" + connectIp + ":27017/authdb?serverSelectionTimeoutMS=3000&connectTimeoutMS=3000&socketTimeoutMS=3000");
                database = client.GetDatabase(_databaseName, null);
                _connectionrRecord.Add(new IpClientDb
                {
                    connectIp = connectIp,
                    client = client,
                    database = database
                });
                _initedError = false;
                return 0;
            }
            catch (Exception ex)
            {
                LogAdd($"远程服务器初始化失败：{ex.Message},{ex.StackTrace}");
                return (int)SoftWareAlarm.MongoDB_基元未初始化;
            }
        }

        private static string GetModelValue<T>(string fieldName, T obj)
        {
            try
            {
                Type ts = obj.GetType();
                object o = ts.GetProperty(fieldName)?.GetValue(obj, null);
                string value = Convert.ToString(o);
                return string.IsNullOrEmpty(value) ? "" : value;
            }
            catch
            {
                return null;
            }
        }

        private static DataTable ToDataTable(List<BsonDocument> bsons)
        {
            if (bsons == null)
            {
                return null;
            }
            DataTable newDt = new DataTable();
            foreach (BsonElement element3 in bsons[0].Elements)
            {
                BsonElement element2 = element3;
                DataColumn col = new DataColumn();
                col.ColumnName = ((BsonElement)(element2)).Name;
                newDt.Columns.Add(col);
            }
            foreach (BsonDocument document in bsons)
            {
                DataRow dr = newDt.NewRow();
                int i = 0;
                foreach (BsonElement element4 in document.Elements)
                {
                    BsonElement element = element4;
                    dr[i] = element.ToString();
                    i++;
                }
                newDt.Rows.Add(dr);
            }
            return newDt;
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
        public static void LogAdd(string msg, LogLevel lv = LogLevel.Trace, int id = 0, bool isShowDialog = false)
        {
            msg = $"{nameof(MongodbHelper)} -> {msg}";
            string tempId = $"{(int)lv}{(int)PrimLogId.Tool}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, nameof(MongodbHelper), LogClassification.Tools, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
            }
        }

        /// <summary>
        /// 创建排序<br/>
        /// 默认降序<br/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSort"></param>
        /// <param name="sortField"></param>
        /// <returns></returns>
        static SortDefinition<T> CreateSortDefinition<T>(DataSort dataSort, string sortField)
        {
            return dataSort switch
            {
                DataSort.Ascending => Builders<T>.Sort.Ascending(sortField),
                _ => Builders<T>.Sort.Descending(sortField),
            };
        }

        /// <summary>
        /// 创建默认查找选项<br/>
        /// </summary>
        /// <returns></returns>
        static FindOptions CreateFindOptionsDefault()
        {
            return new FindOptions()
            {
                AllowPartialResults = true,
                Collation = Collation.Simple,
                BatchSize = int.MaxValue,
            };
        }
        #endregion



        #region Method_New
        /// <summary>多条件删除通用方法（同步）</summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="fieldName">字段名称数组</param>
        /// <param name="value">字段值数组</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="deleteEnum">删除选项</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <returns>int</returns>
        private static int DeleteCommon1<T>(DateTime startTime, DateTime endTime, string[] fieldName, string[] value, string sortField = null, DeleteEnum deleteEnum = DeleteEnum.DeleteOne, string collectionName = null, string connectIp = null)
        {
            #region 连接
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "CreateTime";
            }
            #endregion
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T>[] filterAll = new FilterDefinition<T>[fieldName.Length];
            FilterDefinition<T> filter;
            if (fieldName != null && startTime != default && endTime != default)
            {
                for (int i = 0; i < fieldName.Length; i++)
                {
                    filterAll[i] = Builders<T>.Filter.Eq(fieldName[i], value[i]) & Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
                }
                filter = Builders<T>.Filter.And(filterAll);

            }
            else if (fieldName == null && startTime != default && endTime != default)
            {
                for (int i = 0; i < fieldName.Length; i++)
                {
                    filterAll[i] = Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
                }
                filter = Builders<T>.Filter.And(filterAll);
            }
            else if (fieldName != null && (startTime == default || endTime == default))
            {
                for (int i = 0; i < fieldName.Length; i++)
                {
                    filterAll[i] = Builders<T>.Filter.Eq(fieldName[i], value[i]);
                }
                filter = Builders<T>.Filter.And(filterAll);
            }
            else
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            try
            {
                DeleteResult result;
                switch (deleteEnum)
                {
                    case DeleteEnum.DeleteOne:
                        result = collection.DeleteOne(filter, default);
                        break;

                    case DeleteEnum.DeleteMany:
                        result = collection.DeleteMany(filter, default);
                        break;

                    default:
                        result = collection.DeleteOne(filter, default);
                        break;
                }
                if (result == DeleteResult.Unacknowledged.Instance)
                {
                    return (int)SoftWareAlarm.MongoDB_删除失败;
                }
                return 0;
            }
            catch (Exception)
            {
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        /// <summary>多条件删除通用方法（异步）</summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="fieldName">字段名称数组</param>
        /// <param name="value">字段值数组</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="deleteEnum">删除选项</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <returns>int</returns>
        private static async Task<int> DeleteCommonAsync1<T>(DateTime startTime, DateTime endTime,
                                            string[] fieldName, string[] value, string sortField = null, DeleteEnum deleteEnum = DeleteEnum.DeleteOne,
                                            string collectionName = null, string connectIp = null)
        {
            #region 连接
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "CreateTime";
            }
            #endregion
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T>[] filterAll = new FilterDefinition<T>[fieldName.Length];
            FilterDefinition<T> filter;
            if (fieldName != null && startTime != default && endTime != default)
            {
                for (int i = 0; i < fieldName.Length; i++)
                {
                    filterAll[i] = Builders<T>.Filter.Eq(fieldName[i], value[i]) & Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
                }
                filter = Builders<T>.Filter.And(filterAll);

            }
            else if (fieldName == null && startTime != default && endTime != default)
            {
                for (int i = 0; i < fieldName.Length; i++)
                {
                    filterAll[i] = Builders<T>.Filter.Gte(sortField, startTime) & Builders<T>.Filter.Lte(sortField, endTime);
                }
                filter = Builders<T>.Filter.And(filterAll);
            }
            else if (fieldName != null && (startTime == default || endTime == default))
            {
                for (int i = 0; i < fieldName.Length; i++)
                {
                    filterAll[i] = Builders<T>.Filter.Eq(fieldName[i], value[i]);
                }
                filter = Builders<T>.Filter.And(filterAll);
            }
            else
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            try
            {
                DeleteResult result;
                switch (deleteEnum)
                {
                    case DeleteEnum.DeleteOne:
                        result = await collection.DeleteOneAsync(filter, default);
                        break;

                    case DeleteEnum.DeleteMany:
                        result = await collection.DeleteManyAsync(filter, default);
                        break;

                    default:
                        result = await collection.DeleteOneAsync(filter, default);
                        break;
                }
                if (result == DeleteResult.Unacknowledged.Instance)
                {
                    return (int)SoftWareAlarm.MongoDB_删除失败;
                }
                return 0;
            }
            catch (Exception)
            {
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }


        /// <summary>通过多条件数组删除第一条单条数据</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">字段名数组</param>
        /// <param name="value">字段值数组</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <returns>0-成功</returns>
        public static int DeleteOne<T>(string[] fieldName, string[] value, string collectionName = null, string connectIp = null) where T : class
        {
            if (fieldName == null)
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            DateTime start = default;
            DateTime end = default;

            return DeleteCommon1<T>(start, end, fieldName, value, null, DeleteEnum.DeleteOne, collectionName, connectIp);
        }

        /// <summary>通过多条件数组删除第一条单条数据(异步)</summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldName">字段名数组</param>
        /// <param name="value">字段值数组</param>
        /// <param name="collectionName">集合名，为null时写入parts</param>
        /// <param name="connectIp">连接的数据库IP地址，为null时是本地</param>
        /// <returns>0-成功</returns>
        public static async Task<int> DeleteOneAsync<T>(string[] fieldName, string[] value, string collectionName = null, string connectIp = null) where T : class
        {
            if (fieldName == null)
            {
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            DateTime start = default;
            DateTime end = default;

            return await DeleteCommonAsync1<T>(start, end, fieldName, value, null, DeleteEnum.DeleteOne, collectionName, connectIp);
        }
        #endregion



        #region Method_Obsote
        [Obsolete]
        public static int InsertOneLog<T>(T entity) where T : class
        {
            if (_initedError || _client == null || _database == null)
            {
                return -1;
            }
            IMongoCollection<T> collection = _database.GetCollection<T>("CPrimLog", null);
            try
            {
                collection.InsertOne(entity, null, default(CancellationToken));
                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }

        [Obsolete]
        public static int InserByBsonDucument(string collectionName, IDictionary<string, object> values, string connectIp = null)
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                return iRetReturn;
            }
            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }
            try
            {
                IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName, null);
                BsonDocument document = new BsonDocument();
                BsonElement bsonElement = default(BsonElement);
                foreach (KeyValuePair<string, object> item in values)
                {
                    BsonValue value = BsonValue.Create(item.Value);
                    bsonElement = new BsonElement(item.Key, value);
                    document.Add(bsonElement);
                }
                collection.InsertOne(document, (InsertOneOptions)null, default(CancellationToken));
                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }

        [Obsolete]
        public static int QueryOne<T>(string fieldName, string value, out T result, string collectionName = null, string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                result = null;
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(fieldName))
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_参数为空;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(fieldName, value);
            ProjectionDefinition<T> projection = Builders<T>.Projection.Exclude("_id");
            FindOptions findOption = new FindOptions()
            {
                AllowPartialResults = true,
                Collation = Collation.Simple,
                BatchSize = int.MaxValue,
            };
            try
            {
                IFindFluent<T, T> document = IMongoCollectionExtensions.Find<T>(collection, filter, findOption).Project<T>(projection);
                result = IFindFluentExtensions.First<T, T>(document, default(CancellationToken));
                return 0;
            }
            catch
            {
                result = null;
                return (int)SoftWareAlarm.MongoDB_API函数运行时报错;
            }
        }

        [Obsolete]
        public static int QueryManyByTime1<T>(string startTime, string endTime, out List<T> result, out long okCount, out long ngCount, out double uph, bool noOk = false, bool noNg = false, string collectionName = null, string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                result = null;
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                return iRetReturn;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }

            if (startTime == null)
            {
                startTime = "2000-01-01 01:01:01Z";
            }

            if (endTime == null)
            {
                endTime = "2200-01-01 01:01:01Z";
            }

            DateTime start = Convert.ToDateTime(startTime);
            DateTime end = Convert.ToDateTime(endTime);
            if (start > end)
            {
                MessageBox.Show("终止日期应该比起始日期晚！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result = null;
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                return -10;
            }

            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, null);
            FilterDefinition<T> filterTime = Builders<T>.Filter.Gte("CreateTime", start) & Builders<T>.Filter.Lte("CreateTime", end) & Builders<T>.Filter.Exists("Result", true);
            List<FilterDefinition<T>> subFilters = new List<FilterDefinition<T>> { filterTime };
            FilterDefinition<T> filterNoOk = Builders<T>.Filter.Ne("Result", "OK") & Builders<T>.Filter.Ne("Result", "1");
            FilterDefinition<T> filterNoNg = Builders<T>.Filter.Ne("Result", "NG") & Builders<T>.Filter.Ne("Result", "0");
            if (noOk)
            {
                subFilters.Add(filterNoOk);
            }
            if (noNg)
            {
                subFilters.Add(filterNoNg);
            }
            FilterDefinition<T> filter = Builders<T>.Filter.And(subFilters);
            SortDefinition<T> sort = Builders<T>.Sort.Ascending("CreateTime");
            ProjectionDefinition<T> projection = Builders<T>.Projection.Exclude("_id");
            FindOptions findOption = new FindOptions()
            {
                AllowPartialResults = true,
                Collation = Collation.Simple,
                BatchSize = int.MaxValue,
            };
            try
            {
                IFindFluent<T, T> document = IMongoCollectionExtensions.Find<T>(collection, filter, findOption).Project<T>(projection).Sort(sort);
                result = IAsyncCursorSourceExtensions.ToList<T>((IAsyncCursorSource<T>)(object)document, default(CancellationToken));
                okCount = result.Count((T t) => GetModelValue("Result", t).ToUpper() == "OK" || GetModelValue("Result", t).ToUpper() == "1");
                ngCount = result.Count - okCount;

                if (result.Count == 0)
                {
                    uph = -20.0;
                    return -20;
                }

                if (DateTime.TryParse(GetModelValue("CreateTime", result.First()), out var uphStartTime) && DateTime.TryParse(GetModelValue("CreateTime", result.Last()), out var uphEndTime))
                {
                    TimeSpan time = uphEndTime - uphStartTime;
                    if (time.Hours > 8)
                    {
                        uph = -1.0;
                    }
                    uph = (double)result.Count / time.TotalHours;
                }
                else
                {
                    uph = -10.0;
                }
                return 0;
            }
            catch (Exception)
            {
                result = null;
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                return -2;
            }
        }

        [Obsolete]
        public static int QueryManyByTime(string startTime, string endTime, out string result, out long okCount, out long ngCount, out double uph, bool noOk = false, bool noNg = false, string collectionName = null, string connectIp = null)
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                result = null;
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                return iRetReturn;
            }
            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }
            if (startTime == null)
            {
                startTime = "2000-01-01 01:01:01Z";
            }
            if (endTime == null)
            {
                endTime = "2200-01-01 01:01:01Z";
            }
            DateTime start = Convert.ToDateTime(startTime);
            DateTime end = Convert.ToDateTime(endTime);
            if (start > end)
            {
                MessageBox.Show("终止日期应该比起始日期晚！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result = null;
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                return -10;
            }
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName, (MongoCollectionSettings)null);
            FilterDefinition<BsonDocument> filterTime = Builders<BsonDocument>.Filter.Gte("CreateTime", start) & Builders<BsonDocument>.Filter.Lte("CreateTime", end) & Builders<BsonDocument>.Filter.Exists("Result", true);
            List<FilterDefinition<BsonDocument>> subFilters = new List<FilterDefinition<BsonDocument>> { filterTime };
            FilterDefinition<BsonDocument> filterNoOk = Builders<BsonDocument>.Filter.Ne("Result", "OK") & Builders<BsonDocument>.Filter.Ne("Result", "1");
            FilterDefinition<BsonDocument> filterNoNg = Builders<BsonDocument>.Filter.Ne("Result", "NG") & Builders<BsonDocument>.Filter.Ne("Result", "0");
            if (noOk)
            {
                subFilters.Add(filterNoOk);
            }
            if (noNg)
            {
                subFilters.Add(filterNoNg);
            }
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.And(subFilters);
            SortDefinition<BsonDocument> sort = Builders<BsonDocument>.Sort.Ascending("CreateTime");
            ProjectionDefinition<BsonDocument> projection = Builders<BsonDocument>.Projection.Exclude("_id");
            FindOptions findOption = new FindOptions()
            {
                AllowPartialResults = true,
                Collation = Collation.Simple,
                BatchSize = int.MaxValue,
            };
            try
            {
                List<BsonDocument> document = IAsyncCursorSourceExtensions.ToList((IAsyncCursorSource<BsonDocument>)(object)IMongoCollectionExtensions.Find(collection, filter, findOption).Project<BsonDocument>(projection).Sort(sort), default(CancellationToken));
                result = BsonExtensionMethods.ToJson(document, JsonWriterSettings.Defaults, null, null, default(BsonSerializationArgs));
                okCount = result.Count((char t) => GetModelValue("Result", t).ToUpper() == "OK" || GetModelValue("Result", t).ToUpper() == "1");
                ngCount = document.Count - okCount;
                if (DateTime.TryParse(GetModelValue("CreateTime", result.First()), out var uphStartTime) && DateTime.TryParse(GetModelValue("CreateTime", result.Last()), out var uphEndTime))
                {
                    TimeSpan time = uphEndTime - uphStartTime;
                    if (time.Hours > 8)
                    {
                        uph = -1.0;
                    }
                    uph = (double)document.Count / time.TotalHours;
                }
                else
                {
                    uph = -10.0;
                }
                return 0;
            }
            catch (Exception)
            {
                result = null;
                okCount = -1L;
                ngCount = -1L;
                uph = -1.0;
                return -2;
            }
        }

        [Obsolete]
        public static int QueryManyByTime<T>(string[] fieldArray, string[] valueArray, string filteredTime, DateTime startTime, DateTime endTime, out List<T> result, string collectionName = null, string connectIp = null) where T : class
        {
            MongoClient client;
            IMongoDatabase database;
            int iRetReturn = ReturnClientAndDatabase(connectIp, out client, out database);
            if (iRetReturn != 0)
            {
                result = null;
                return iRetReturn;
            }
            if (fieldArray.Length != valueArray.Length)
            {
                result = null;
                return -1;
            }
            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = _collectionName;
            }
            FilterDefinition<T> filterTime = Builders<T>.Filter.Gte(filteredTime, startTime) & Builders<T>.Filter.Lte(filteredTime, endTime);
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName, (MongoCollectionSettings)null);
            FilterDefinition<T>[] subFilters = new FilterDefinition<T>[fieldArray.Length + 1];
            for (int i = 0; i < subFilters.Length - 1; i++)
            {
                subFilters[i] = Builders<T>.Filter.Eq(fieldArray[i], valueArray[i]);
            }
            subFilters[fieldArray.Length] = filterTime;
            FilterDefinition<T> filter = Builders<T>.Filter.And(subFilters);
            SortDefinition<T> sort = Builders<T>.Sort.Descending(filteredTime);
            ProjectionDefinition<T> projection = Builders<T>.Projection.Exclude("_id");
            FindOptions findOption = new FindOptions()
            {
                AllowPartialResults = true,
                Collation = Collation.Simple,
                BatchSize = int.MaxValue,
            };
            try
            {
                IFindFluent<T, T> document = IMongoCollectionExtensions.Find<T>(collection, filter, findOption).Project<T>(projection).Sort(sort);
                result = IAsyncCursorSourceExtensions.ToList<T>((IAsyncCursorSource<T>)(object)document, default(CancellationToken));
                return 0;
            }
            catch (Exception)
            {
                result = null;
                return -2;
            }
        }
        #endregion
    }
}