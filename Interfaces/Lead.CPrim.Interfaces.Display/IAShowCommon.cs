using System.Collections.Generic;

namespace Lead.CPrim.Interfaces.Display
{
    #region Define_DEL
    /// <summary>当前颜色切换时发生委托</summary>
    public delegate void ChangeCurrentProColor(string proColorName);
    /// <summary>颜色集合切换时发生委托</summary>
    public delegate void UpdateProColors(List<string> proColors); 
    #endregion



    /// <summary>AQCI用户接口</summary>
    public interface IAShowCommon
    {
        /// <summary>接口【IAShowCommon】当前颜色切换时发生</summary>
        event ChangeCurrentProColor OnChangeCurrentProColor;
        /// <summary>接口【IAShowCommon】颜色集合切换时发生</summary>
        event UpdateProColors OnUpdateProColors;


        /// <summary>接口【IAShowCommon】推送实时数据</summary>
        bool ShowRtData { set; get; }
        /// <summary>接口【IAShowCommon】图片展示</summary>
        bool ShowPic { set; get; }
        /// <summary>接口【IAShowCommon】行1高度</summary>
        float PerRow1 { set; get; }
        /// <summary>接口【IAShowCommon】行2高度</summary>
        float PerRow2 { set; get; }
        /// <summary>接口【IAShowCommon】行3高度</summary>
        float PerRow3 { set; get; }
        /// <summary>接口【IAShowCommon】列1高度</summary>
        float PerCol1 { set; get; }
        /// <summary>接口【IAShowCommon】列2高度</summary>
        float PerCol2 { set; get; }
        /// <summary>接口【IAShowCommon】列3高度</summary>
        float PerCol3 { set; get; }


        /// <summary>在区域三添加FAI标签实时显示</summary>
        /// <param name="faiName">FAI名称</param>
        /// <param name="faiValue">FAI实时值</param>
        /// <param name="xPos">Label的X坐标</param>
        /// <param name="yPos">Label的Y坐标</param>
        /// <param name="labelColor">Label显示的前景色</param>
        /// <returns>int</returns>
        int AddFaiByLocation(string faiName, double faiValue, int xPos, int yPos, ShowColor labelColor = ShowColor.Black);
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
        /// <summary>在区域三添加自定义标签显示</summary>
        /// <param name="labelName">自定义标签名称</param>
        /// <param name="xPos">Label的X坐标</param>
        /// <param name="yPos">Label的Y坐标</param>
        /// <param name="labelColor">Label显示的前景色</param>
        /// <param name="labelFont">Label显示的字体</param>
        /// <returns>int</returns>
        int AddResultByLocation(string labelName, int xPos, int yPos, ShowColor labelColor = ShowColor.Black,
            string labelFont = null);
        /// <summary>移除区域三的图片</summary>
        /// <returns>int</returns>
        int ClearPicture();
        /// <summary>清除区域三上的标签显示</summary>
        /// <returns>int</returns>
        int ClearResults();
        /// <summary>区域三载入图片</summary>
        /// <param name="productName">产品名</param>
        /// <returns>int</returns>
        int LoadPicture(string productName = null);
        /// <summary>更新区域一的条码</summary>
        /// <param name="barCode">条码</param>
        void UpdateBarcode(string barCode);
        /// <summary>更新区域一的CT显示</summary>
        /// <param name="ct"></param>
        void UpdateCt(double ct);
        /// <summary>更新区域一的结果与条码显示</summary>
        /// <param name="result">ok或其他</param>
        /// <param name="barCode">条码</param>
        void UpdateProduct(string result = "ok", string barCode = "");
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