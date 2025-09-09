using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 远程数据库
    /// </summary>
    public class IpClientDb
    {
        public string connectIp { get; set; }
        public MongoClient client { get; set; }
        public IMongoDatabase database { get; set; }
    }
}
