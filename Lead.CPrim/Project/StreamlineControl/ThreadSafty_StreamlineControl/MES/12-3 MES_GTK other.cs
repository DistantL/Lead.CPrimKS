using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafty_StreamlineControl
{

    public class Mes_BackData
    {
        public int cmd { get; set; }
        public string Hwd { get; set; }
        public string Indicator { get; set; }
        public string SerializeData { get; set; }
        public string Display { get; set; }
        public Bindinfo BindInfo { get; set; }
    }

    public class MaterialPreparation
    {
        public bool IsForward { get; set; }
        public int Cmd { get; set; }
        public string Value { get; set; }
        public string Notice { get; set; }
    }

    public class Value
    {
        public string Indicator { get; set; }
        public string Title { get; set; }
        public string Notice { get; set; }
        public string QueryPath { get; set; }
        public bool IsMultiSelect { get; set; }
        public List<string> Filters { get; set; }
        public List<ColumnsItem> Columns { get; set; }
        public object Data { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }

    public class ColumnsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Visible { get; set; }
    }

    public class Display
    {
        /// <summary>
        /// 
        /// </summary>
        public List<DisplayNoticesItem> DisplayNotices { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DisplayLabelsItem> DisplayLabels { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DisplayTablesItem> DisplayTables { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CountDisplay CountDisplay { get; set; }
    }

    public class CountDisplay
    {
        /// <summary>
        /// 
        /// </summary>
        public int SuccessCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FailCount { get; set; }
    }

    public class DisplayNoticesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Color { get; set; }
    }

    public class DisplayLabelsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Visiable { get; set; }
    }

    public class DisplayTablesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 工序Bom
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ColumnsItem> Columns { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CurrentPage { get; set; }
    }

    public class Bindinfo
    {
        public string LINE_CODE { get; set; }
        public string SECTION_CODE { get; set; }
        public int STATION_CODE { get; set; }
        public string HWD { get; set; }
        public string BIND_USER { get; set; }
        public DateTime BIND_TIME { get; set; }
        public string DLL_CODE { get; set; }
        public string SERVER_VERSION { get; set; }
        public string LINE_NAME { get; set; }
        public string SECTION_DESC { get; set; }
        public string STATION_NAME { get; set; }
    }


    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string WO_NO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PN_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RAW_PN_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string REAL_PN_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BATCH_NO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int QTY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DATE_BEI { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LINE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SHELF { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int STATION_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ORDERNO { get; set; }
    }

    public class MaterialInfos
    {
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current_index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int page_size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int Cmd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }

    public class OPRequestInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string SOFT_VERSION { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string VENDOR_CODE { get; set; }
    }

    public class OPResponseInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Result { get; set; }
    }

    public class VendorVersion
    {
        /// <summary>
        /// 
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SectionCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StationCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OPCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OPRequestInfo OPRequestInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OPResponseInfo OPResponseInfo { get; set; }
    }




}



