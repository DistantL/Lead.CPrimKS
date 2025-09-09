using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Global;


namespace Lead.CPrim.ProxyTools
{
    public partial class TossingInfoStatistics : UIPage
    {
        #region Field
        /// <summary>统计控件1</summary>
        private static TossingInfoStatistics _statistics = null;
        private static BindingList<TossingReasonStatictis> list = null;
        #endregion


        #region Ctor
        private TossingInfoStatistics()
        {
            InitializeComponent();
            tlpStatic.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged -= OnLanguageChanged;
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion


        #region Method_ExternalUsing
        /// <summary>获取统计对象</summary>
        /// <param name="tossingReasons">0：返回对象1；1：返回对象2；</param>
        /// <returns></returns>
        public static TossingInfoStatistics GetInstance(string tossingReasons)
        {
            if (_statistics == null)
            {
               
                list = new BindingList<TossingReasonStatictis>();
                if (string.IsNullOrWhiteSpace(tossingReasons))
                {
                    _statistics = new TossingInfoStatistics();
                    return _statistics;
                }
                string[] strs = tossingReasons.Split(";");
                foreach (var item in strs)
                {
                    list.Add(new TossingReasonStatictis()
                    {
                        Name = item
                        ,
                        Count = 0
                    });
                }
                _statistics = new TossingInfoStatistics();
            }
            return _statistics;
        }


        public void UpdateNumber(Dictionary<string, int> dic)
        {
            foreach (var item in dic)
            {
                var row = list.Where(x => x.Name == item.Key);
                if (row != null && row.Count() > 0)
                {
                    row.First().Count = item.Value;
                }
                else
                { 
                list.Add(new TossingReasonStatictis()
                {
                    Name = item.Key,
                    Count = item.Value,
                    DisplayName = NLocalizer.GetString("Lead_CPrim_ProxyTools_TossingInfoStatistics_" + item.Key, item.Key)
                });
                }
            }
        }

        public void OnLanguageChanged()
        {
            lb_Title.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_TossingInfoStatistics_Title", "抛料统计");
            //lb_PickupFail.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_TossingInfoStatistics_PickUpNG", "物料拾取失败");
            //lb_LowCCDNG.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_TossingInfoStatistics_LowCCDNG", "下相机定位失败");
            //lb_TopCCDNG.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_TossingInfoStatistics_TopCCDNG", "上相机定位失败");
            //lb_PositionNGInTray.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_TossingInfoStatistics_PositionNGInTray", "料盘辅料定位失败");
            //lb_SideCCDNG.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_TossingInfoStatistics_SideCCDNG", "侧相机检查失败");
            foreach (var item in list)
            {
                item.DisplayName = NLocalizer.GetString("Lead_CPrim_ProxyTools_TossingInfoStatistics_" + item.Name, item.Name);
            }

            dgv_Tossing.DataSource = list;
        }
        #endregion
    }

    public class TossingReasonStatictis
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public string DisplayName { get; set; }
    }
}