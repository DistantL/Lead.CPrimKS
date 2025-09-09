/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ServiceHelper.cs
 * Author: Victor
 * Description: 服务帮助类
 * CreateTime: 2023-2-20
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230220>
 * 1、初版1.0
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 服务帮助类
    /// </summary>
    public static class ServiceHelper
    {
        #region Field
        /// <summary>
        /// MongoDB服务名称
        /// </summary>
        static string _mongodbServiceName = "MongoDB";
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// MongoDB服务开启判断（true：开启状态；false：未开启状态；）
        /// </summary>
        /// <returns></returns>
        public static bool MongoDBServiceIsRunning()
        {
            return _mongodbServiceName.ServiceIsRunning();
        }

        /// <summary>
        /// 检测Windows服务是否处于运行状态
        /// </summary>
        /// <param name="serviceName">Windows服务名称</param>
        /// <returns>true：运行状态；false：非运行状态；</returns>
        public static bool ServiceIsRunning(this string serviceName)
        {
            bool result = false;
            ServiceController[] services = ServiceController.GetServices();
            foreach (var service in services)
            {
                if (service.ServiceName.ToLower().Contains(serviceName.ToLower()))
                {
                    result = service.Status == ServiceControllerStatus.Running;
                    break;
                }
            }
            return result;
        } 
        #endregion
    }
}
