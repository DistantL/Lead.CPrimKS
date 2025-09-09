using System.Collections.Generic;

namespace Lead.CPrim.Interfaces.Display
{
    /// <summary>AQCI用户接口</summary>
    public interface IShowCapacityOfProduction
    {
        /// <summary>接口【IAShowCommon】当前颜色切换时发生</summary>
        event ChangeCurrentProColor OnChangeCurrentProColor;
        /// <summary>接口【IAShowCommon】颜色集合切换时发生</summary>
        event UpdateProColors OnUpdateProColors;


        /// <summary>在区域二的表格中添加推送实时数据，ProductInfo类型</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntiy">ProductInfo类型的对象集合</param>
        /// <param name="saveDataBase">保存至数据库</param>
        /// <param name="proTypeName">产品名称（数据库集合名）</param>
        /// <param name="updateStatistic">更新区域一的产品统计信息</param>
        /// <param name="results">对应各FAI项结果的集合</param>
        /// <returns>int</returns>
        int AddProInfo<T>(List<T> listEntiy, bool saveDataBase = false, string proTypeName = "",
            bool updateStatistic = false, Dictionary<string, bool> results = null) where T : class;
        /// <summary>在区域二的表格中添加推送实时数据，ProductInfo类型</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entiy">ProductInfo类型的对象</param>
        /// <param name="saveDataBase">保存至数据库</param>
        /// <param name="proTypeName">产品名称（数据库集合名）</param>
        /// <param name="updateStatistic">更新区域一的产品统计信息</param>
        /// <param name="results">对应各FAI项结果的集合</param>
        /// <returns>int</returns>
        int AddProInfo<T>(T entiy, bool saveDataBase = false, string proTypeName = "", bool updateStatistic = false,
            Dictionary<string, bool> results = null) where T : class;
        /// <summary>更新区域一的条码</summary>
        /// <param name="barCode">条码</param>
        void UpdateBarcode(string barCode);
        /// <summary>更新区域一的CT显示</summary>
        /// <param name="ct"></param>
        void UpdateCt(double ct);
        /// <summary>更新区域一的结果与条码显示</summary>
        /// <param name="result">1为OK，其他为NG</param>
        /// <param name="barCode">条码</param>
        void UpdateProduct(int result = 1, string barCode = "");
        /// <summary>更新区域一显示的型号</summary>
        /// <param name="newType">产品类型</param>
        void UpdateProductType(string newType);
        /// <summary>改变运行模式</summary>
        /// <param name="mode">模式</param>
        void RefreshOperaMode(string mode);
    }
}