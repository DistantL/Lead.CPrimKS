using Lead.CPrim.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Display
{
    public interface IShowAudio
    {
        /// <summary>在区域二的表格中添加推送实时数据，ProductInfo类型</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntiy">ProductInfo类型的对象集合</param>
        /// <param name="saveDataBase">true：保存至数据库；false：不保存至数据库；</param>
        /// <param name="proTypeName">产品名称（数据库集合名）</param>
        /// <param name="results">对应各FAI项结果的集合</param>
        /// <returns>int</returns>
        int AddProInfo<T>(List<T> listEntiy, bool saveDataBase = false, string proTypeName = "", Dictionary<string, bool> results = null) where T : class;

        /// <summary>在区域二的表格中添加推送实时数据，ProductInfo类型</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entiy">ProductInfo类型的对象</param>
        /// <param name="saveDataBase">true：保存至数据库；false：不保存至数据库；</param>
        /// <param name="proTypeName">产品名称（数据库集合名）</param>
        /// <param name="results">对应各FAI项结果的集合</param>
        /// <returns>int</returns>
        int AddProInfo<T>(T entiy, bool saveDataBase = false, string proTypeName = "", Dictionary<string, bool> results = null) where T : class;

        /// <summary>更新区域一显示的型号</summary>
        /// <param name="newType">产品类型</param>
        void UpdateProductType(string newType);

        /// <summary>
        /// 设置Hive状态（true：连接成功；false：连接失败；）
        /// </summary>
        /// <param name="state"></param>
        void SetHive(bool state);

        /// <summary>
        /// 设置Mes状态（true：连接成功；false：连接失败；）
        /// </summary>
        /// <param name="state"></param>
        void SetMes(bool state);

        /// <summary>
        /// 设置PDCA状态（true：连接成功；false：连接失败；）
        /// </summary>
        /// <param name="state"></param>
        void SetPDCA(bool state);

        /// <summary>
        /// 获取Remote Qualification功能使能
        /// </summary>
        /// <returns>true：启动；false：禁用</returns>
        bool GetRemoteQualificationEnable();

        /// <summary>获取操作员ID卡号</summary>
        string GetOperatorID();

        /// <summary>获取当前软件数据</summary>
        SoftWareData GetSoftWareData();

        void SetSiteInfo(string site);

        bool SiteAlert(string site);

        void SetSensorStatus(List<StationStatus> stations, List<SensorStatus> sensors, List<Tuple<string, string>> arrows);

        void SetFaiInUIbyFaiName(string faiName);
    }
}
