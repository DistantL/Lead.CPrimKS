using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    public partial class UIAlertInfo : UIUserControl
    {
        private BindingList<AlertInfo> list = new BindingList<AlertInfo>();
        private object locker = new object();
        public UIAlertInfo()
        {
            InitializeComponent();
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;

            string msg;
            if (!GetAlertConfigData(@"D:\Config\AlertConfig\AlertInfo.csv", out msg))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_Controls_UIAlertInfo_ErrMsg_ReadAlertInfoFileFail", "读取报警配置文件失败:") + msg);
            }

            dgv_AlertInfo.DataSource = list;
        }

        public void OnLanguageChanged()
        {
            dgv_AlertInfo.Columns["ErrorCode"].HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlertInfo_ErrorCode", "报警代码");
            dgv_AlertInfo.Columns["ErrorMessage"].HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlertInfo_ErrorMessage", "报警类型");
            dgv_AlertInfo.Columns["ErrorDetail"].HeaderText = NLocalizer.GetString("Lead_CPrim_Controls_UIAlertInfo_ErrorDetail", "报警信息");
        }


        class AlertInfo
        {
            public string ErrorCode { get; set; }

            public string ErrorMessage { get; set; }

            public string ErrorDetail { get; set; }

            public string ErrorDetailInEN { get; set; }

            public string ErrorDetailInVN { get; set; }

        }


        private bool GetAlertConfigData(string path, out string msg)
        {
            msg = string.Empty;
            try
            {
                List<string> data;
                CsvHelper.ReadCsvToListString(path, Encoding.UTF8, false, out data);
                if (data.IsNullOrEmpty())
                {
                    msg = "Read csv File is null";
                    return false;
                }

                data.RemoveAt(0);
                Dictionary<string, AlertInfo> AlertConfigDatas = new Dictionary<string, AlertInfo>();

                AlertConfigDatas.Clear();
                foreach (string info in data)
                {
                    string[] tmp = info.Trim().Split(',');
                    if (tmp == null || tmp.Count() < 6 || string.IsNullOrWhiteSpace(tmp[0]))
                    {
                        continue;
                    }

                    AlertInfo alertConfigData = new AlertInfo
                    {
                        ErrorCode = tmp[0],
                        ErrorMessage = tmp[2],
                        ErrorDetail = tmp[3],
                        ErrorDetailInEN = tmp[4],
                        ErrorDetailInVN = tmp[5],
                    };

                    if (!AlertConfigDatas.ContainsKey(tmp[0]))
                    {
                        AlertConfigDatas.Add(tmp[0], alertConfigData);
                    }
                }

                list = new BindingList<AlertInfo>(AlertConfigDatas.Values.ToList<AlertInfo>());
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }

            return true;
        }

    }
}
