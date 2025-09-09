using Lead.CPrim.Global;
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

namespace Lead.CPrim.ProxyTools
{
    public partial class ProductInfoStatistics : UIPage
    {
        #region Field
        /// <summary>统计控件1</summary>
        private static ProductInfoStatistics _statistics1 = new ProductInfoStatistics();
        /// <summary>统计控件2</summary>
        private static ProductInfoStatistics _statistics2 = new ProductInfoStatistics();
        #endregion


        #region Ctor
        private ProductInfoStatistics()
        {
            InitializeComponent();
            tlpStatic.SetDoubleBuffered();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion


        #region Method_ExternalUsing
        /// <summary>获取统计对象</summary>
        /// <param name="index">0：返回对象1；1：返回对象2；</param>
        /// <returns></returns>
        public static ProductInfoStatistics GetInstance(int index)
        {
            switch (index)
            {
                case 0:
                    return _statistics1;
                case 1:
                    return _statistics2;
                default:
                    return _statistics1;
            }
        }
        /// <summary>更新产品结果</summary>
        /// <param name="result">1：OK；0：NG；other：不显示</param>
        /// <param name="id"></param>
        public void UpdateProductResult(int result, string id = "")
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int, string>(UpdateProductResult), new object[2] { result, id });
            }
            else
            {
                SuspendLayout();
                lblResult.BackColor = result == 1 ? Color.FromArgb(0, 249, 0) : (result == 0 ? Color.FromArgb(236, 93, 87) : Color.Gray);
                lblResult.Text = id.IsNullOrWhiteSpace() ? "-" : id;
                ResumeLayout();
            }
        }
        /// <summary>更新总数量</summary>
        /// <param name="value">数量</param>
        public void UpdateNumCount(string value)
        {
            ControlHelper.SetText(lblInput, value);
        }
        /// <summary>更新良率</summary>
        /// <param name="value">良率</param>
        public void UpdatePassRate(double value)
        {
            ControlHelper.SetText(lblYield, value.ToString("P2"));
        }
        /// <summary>pass/fail统计</summary>
        /// <param name="value">pass/fail</param>
        public void UpdateNum(string value)
        {
            ControlHelper.SetText(lblPass, value);
        }
        /// <summary>更新CT</summary>
        /// <param name="value">CT</param>
        public void UpdateCt(double value)
        {
            ControlHelper.SetText(lblCT, value.ToString("f2"));
        }

        public void UpdateUPH(int value)
        {
            ControlHelper.SetText(lblUPH, value == 0 ? "0" : value.ToString());
        }
        #endregion

        public void OnLanguageChanged()
        {
            lb_IOSummary.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfoStatistics_IOSummary", "输入输出统计");
            lb_InputOutput.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfoStatistics_InputOutput", "输入/输出:");
            lb_Yield.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfoStatistics_Yield", "良率:");
            lb_OKNG.Text = NLocalizer.GetString("Lead_CPrim_ProxyTools_ProductInfoStatistics_PassFail", "成功/失败:");
        }

        public event Action doubleClick;
        private void tlpStatic_DoubleClick(object sender, EventArgs e)
        {
            doubleClick?.Invoke();
        }
    }
}
