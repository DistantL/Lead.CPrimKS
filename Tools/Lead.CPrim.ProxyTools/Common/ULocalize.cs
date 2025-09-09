/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UILocalize.cs
 * Author: Victor
 * Description: 软件参数管理类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-04-19: V2.2.0 增加文件说明
 * 2021-07-24: V3.0.5 内置字符串已经处理完国际化
 *
 * <3.3.22.0616><Victor><20220805>
 * 1、将命名空间变更为Lead.CPrim.ProxyTools.Common
 * <3.3.22.1010><Victor><20221016>
 * 1、帮助类文档统一放入Common文件下，命名空间统一变更为Lead.CPrim.ProxyTools
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.ProxyTools
{
    public static class ULocalize
    {
        /// <summary>提示</summary>
        public static string InfoTitle = "提示";

        /// <summary>正确</summary>
        public static string SuccessTitle = "正确";

        /// <summary>警告</summary>
        public static string WarningTitle = "警告";

        /// <summary>错误</summary>
        public static string ErrorTitle = "错误";

        /// <summary>提示</summary>
        public static string AskTitle = "提示";

        /// <summary>输入</summary>
        public static string InputTitle = "输入";

        /// <summary>选择</summary>
        public static string SelectTitle = "选择";

        /// <summary>全部关闭</summary>
        public static string CloseAll = "全部关闭";

        /// <summary>确定</summary>
        public static string OK = "确定";

        /// <summary>取消</summary>
        public static string Cancel = "取消";

        /// <summary>[ 无数据 ]</summary>
        public static string GridNoData = "[ 无数据 ]";

        /// <summary>数据加载中，请稍候...</summary>
        public static string GridDataLoading = "数据加载中，请稍候...";

        /// <summary>数据源必须为DataTable或者List</summary>
        public static string GridDataSourceException = "数据源必须为DataTable或者List";

        /// <summary>"系统正在处理中，请稍候..."</summary>
        public static string SystemProcessing = "系统正在处理中，请稍候...";

        public static string Monday = "一";
        public static string Tuesday = "二";
        public static string Wednesday = "三";
        public static string Thursday = "四";
        public static string Friday = "五";
        public static string Saturday = "六";
        public static string Sunday = "日";

        public static string Prev = "上一页";
        public static string Next = "下一页";
        public static string SelectPageLeft = "第";
        public static string SelectPageRight = "页";

        public static string January = "一月";
        public static string February = "二月";
        public static string March = "三月";
        public static string April = "四月";
        public static string May = "五月";
        public static string June = "六月";
        public static string July = "七月";
        public static string August = "八月";
        public static string September = "九月";
        public static string October = "十月";
        public static string November = "十一月";
        public static string December = "十二月";

        public static string Today = "今天";
    }

    public static class UILocalizeHelper
    {
        public static void SetEN()
        {
            ULocalize.InfoTitle = "Info";
            ULocalize.SuccessTitle = "Success";
            ULocalize.WarningTitle = "Warning";
            ULocalize.ErrorTitle = "Error";
            ULocalize.AskTitle = "Query";
            ULocalize.InputTitle = "Input";
            ULocalize.SelectTitle = "Select";
            ULocalize.CloseAll = "Close all";
            ULocalize.OK = "OK";
            ULocalize.Cancel = "Cancel";
            ULocalize.GridNoData = "[ No data ]";
            ULocalize.GridDataLoading = "Data loading, please wait...";
            ULocalize.GridDataSourceException = "The data source must be DataTable or List";
            ULocalize.SystemProcessing = "The system is processing, please wait...";

            ULocalize.Monday = "Mon.";
            ULocalize.Tuesday = "Tue.";
            ULocalize.Wednesday = "Wed.";
            ULocalize.Thursday = "Thur.";
            ULocalize.Friday = "Fri.";
            ULocalize.Saturday = "Sat.";
            ULocalize.Sunday = "Sun.";

            ULocalize.Prev = "Previous";
            ULocalize.Next = "Next";
            ULocalize.SelectPageLeft = "Page";
            ULocalize.SelectPageRight = "";

            ULocalize.January = "Jan.";
            ULocalize.February = "Feb.";
            ULocalize.March = "Mar.";
            ULocalize.April = "Apr.";
            ULocalize.May = "May";
            ULocalize.June = "Jun.";
            ULocalize.July = "Jul.";
            ULocalize.August = "Aug.";
            ULocalize.September = "Sep.";
            ULocalize.October = "Oct.";
            ULocalize.November = "Nov.";
            ULocalize.December = "Dec.";

            ULocalize.Today = "Today";

            UIStyles.Translate();
        }

        public static void SetCH()
        {
            ULocalize.InfoTitle = "提示";
            ULocalize.SuccessTitle = "正确";
            ULocalize.WarningTitle = "警告";
            ULocalize.ErrorTitle = "错误";
            ULocalize.AskTitle = "提示";
            ULocalize.InputTitle = "输入";
            ULocalize.SelectTitle = "选择";
            ULocalize.CloseAll = "全部关闭";
            ULocalize.OK = "确定";
            ULocalize.Cancel = "取消";
            ULocalize.GridNoData = "[ 无数据 ]";
            ULocalize.GridDataLoading = "数据加载中，请稍候...";
            ULocalize.GridDataSourceException = "数据源必须为DataTable或者List";
            ULocalize.SystemProcessing = "系统正在处理中，请稍候...";

            ULocalize.Monday = "一";
            ULocalize.Tuesday = "二";
            ULocalize.Wednesday = "三";
            ULocalize.Thursday = "四";
            ULocalize.Friday = "五";
            ULocalize.Saturday = "六";
            ULocalize.Sunday = "日";

            ULocalize.Prev = "上一页";
            ULocalize.Next = "下一页";

            ULocalize.SelectPageLeft = "第";
            ULocalize.SelectPageRight = "页";

            ULocalize.January = "一月";
            ULocalize.February = "二月";
            ULocalize.March = "三月";
            ULocalize.April = "四月";
            ULocalize.May = "五月";
            ULocalize.June = "六月";
            ULocalize.July = "七月";
            ULocalize.August = "八月";
            ULocalize.September = "九月";
            ULocalize.October = "十月";
            ULocalize.November = "十一月";
            ULocalize.December = "十二月";

            ULocalize.Today = "今天";

            UIStyles.Translate();
        }

        public static void SetVI()
        {
            ULocalize.InfoTitle = "Gợi ý";
            ULocalize.SuccessTitle = "Chính xác";
            ULocalize.WarningTitle = "Cảnh báo";
            ULocalize.ErrorTitle = "Lỗi";
            ULocalize.AskTitle = "Gợi ý";
            ULocalize.InputTitle = "Nhập";
            ULocalize.SelectTitle = "Chọn";
            ULocalize.CloseAll = "Đóng tất cả";
            ULocalize.OK = "OK";
            ULocalize.Cancel = "Hủy bỏ";
            ULocalize.GridNoData = "[không có dữ liệu]";
            ULocalize.GridDataLoading = "Đang tải dữ liệu, vui lòng chờ...";
            ULocalize.GridDataSourceException = "Nguồn dữ liệu phải là DataTable hoặc List";
            ULocalize.SystemProcessing = "Hệ thống đang xử lý, vui lòng chờ...";
            ULocalize.Monday = "một";
            ULocalize.Tuesday = "hai";
            ULocalize.Wednesday = "ba";
            ULocalize.Thursday = "bốn";
            ULocalize.Friday  = "Năm";
            ULocalize.Saturday = "sáu";
            ULocalize.Sunday = "ngày";
            ULocalize.Prev = "Trang trước";
            ULocalize.Next = "Trang tiếp theo";
            ULocalize.SelectPageLeft = "Phần";
            ULocalize.SelectPageRight = "Trang";
            ULocalize.January = "Tháng Giêng";
            ULocalize.February = "Tháng Hai";
            ULocalize.March = "Tháng ba";
            ULocalize.April = "Tháng Tư";
            ULocalize.May = "có thể";
            ULocalize.June = "Tháng Sáu";
            ULocalize.July = "tháng bảy";
            ULocalize.August = "Tháng Tám";
            ULocalize.September = "Tháng Chín";
            ULocalize.October = "Tháng Mười";
            ULocalize.November = "Tháng Mười Một";
            ULocalize.December = "tháng mười hai";
            ULocalize.Today = "hôm nay";

            UIStyles.Translate();
        }
    }
}