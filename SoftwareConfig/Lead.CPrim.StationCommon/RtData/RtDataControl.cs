using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.StationCommon.RtData
{
    public partial class RtDataControl : UserControl
    {
        #region Field
        /// <summary>总数</summary>
        private int _totalCount;
        /// <summary>OK计数</summary>
        private int _totalOk;
        /// <summary>NG计数</summary>
        private int _totalNg;
        /// <summary>无效计数</summary>
        private int _totalInvalid;
        /// <summary>最近10片CT</summary>
        private List<double> _lCt = new List<double>();
        /// <summary>列表模式</summary>
        private ProductInfoList _listMode = new ProductInfoList();
        #endregion



        #region Ctor
        public RtDataControl()
        {
            InitializeComponent();
            _listMode.TopLevel = false;
            _listMode.TopMost = false;
            _listMode.Show();
            pnlMain.Controls.Add(_listMode);
        }
        #endregion



        #region System_Event
        private void MainSingleControl_Load(object sender, EventArgs e)
        {
        } 
        #endregion



        #region Method_ExternalUsing
        /// <summary>插入数据</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listEntiy"></param>
        /// <param name="saveDataBase"></param>
        /// <param name="stationName"></param>
        /// <param name="productName"></param>
        /// <param name="faiResults"></param>
        public void AddMultiPartInfo<T>(List<T> listEntiy, bool saveDataBase = false, string stationName = null, string productName = null, List<Dictionary<string, bool>> faiResults = null) where T : class
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<List<T>, bool, string, string, List<Dictionary<string, bool>>>(AddMultiPartInfo), listEntiy, saveDataBase, stationName, productName, faiResults);
            }
            else
            {
                if (listEntiy == null || listEntiy.Count == 0)
                {
                    return;
                }

                if (!stationName.IsNullOrEmpty())
                {
                    if (productName.IsNullOrEmpty())
                    {
                        productName = "parts";
                    }
                    productName = stationName + "_" + productName;
                }

                if (saveDataBase)
                {
                    if (listEntiy.Count > 1)
                    {
                        _ = MongodbHelper.InsertManyAsync(listEntiy, productName);
                    }
                    else
                    {
                        _ = MongodbHelper.InsertOneAsync(listEntiy[0], productName);
                    }
                }

                PropertyInfo[] propInfo = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if(propInfo == null || propInfo.Length <= 0)
                {
                    return;
                }

                var propertyResult = typeof(T).GetProperty("Result");
                var propertyCt = typeof(T).GetProperty("CT");

                Dictionary<int, string> dicColName = DataHelper.GetDataTableColumns(listEntiy, ref propInfo);
                
                int partIndex = 0;
                foreach (var item in listEntiy)
                {
                    object[] values = DataHelper.GetDataTableRowValue(item, propInfo, dicColName);
                    _listMode.InsertData(dicColName, values, faiResults[partIndex]);
                    _totalCount++;
                    if (propertyResult != null)
                    {
                        if (propertyResult.GetValue(item).ToString().ToLower()
                            .Contains("ok") || propertyResult.GetValue(item).ToString() == "1")
                        {
                            _totalOk++;
                        }
                        else if (propertyResult.GetValue(item).ToString().ToLower()
                            .Contains("ng") || propertyResult.GetValue(item).ToString() == "-1")
                        {
                            _totalNg++;
                        }
                        else
                        {
                            _totalInvalid++;
                        }
                    }
                    if (propertyCt != null && double.TryParse(propertyCt.GetValue(item).ToString(), out var retCt))
                    {
                        if (_lCt.Count > 10)
                        {
                            _lCt.RemoveAt(0);
                        }
                        _lCt.Add(retCt);
                    }
                    partIndex++;
                }
                tbRtNumTotal.Text = _totalCount.ToString();
                tbRtNumOk.Text = _totalOk.ToString();
                tbRtNumNg.Text = _totalNg.ToString();
                tbInValidValueCount.Text = _totalInvalid.ToString();
                tbRtAverageCt.Text = _lCt == null || _lCt.Count <= 0 ? "0" : _lCt.Average().ToString("F1");
                tbRtPassRate.Text = ((double)_totalOk / (_totalOk + _totalNg)).ToString("P");
                tbRtPassRate1.Text = ((double)_totalOk / _totalCount).ToString("P");
            }
        }
        #endregion



        #region Method_InternalUsing
        private void ListControlClear()
        {
            _totalCount = 0;
            _totalInvalid = 0;
            _totalNg = 0;
            _totalOk = 0;
            _lCt.Clear();
            tbRtNumNg.Text = "0";
            tbRtNumTotal.Text = "0";
            tbRtNumOk.Text = "0";
            tbInValidValueCount.Text = "0";
            tbRtAverageCt.Text = "0";
            tbRtPassRate.Text = "0%";
            tbRtPassRate1.Text = "0%";
        }
        #endregion



        #region Method_Obsolete
        //public void AddPartInfo(object obj)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new Action<object>(AddPartInfo), obj);
        //        return;
        //    }
        //    List<PropertyInfo> perList = obj.GetType().GetProperties().ToList();
        //    if (dgRtData.ColumnCount == 0)
        //    {
        //        string headerStr = "";
        //        foreach (PropertyInfo per2 in perList)
        //        {
        //            object[] objs = per2.GetCustomAttributes(typeof(DescriptionAttribute), inherit: true);
        //            if (objs.Length != 0)
        //            {
        //                if (headerStr != "")
        //                {
        //                    headerStr += ",";
        //                }
        //                headerStr += ((DescriptionAttribute)objs[0]).Description;
        //            }
        //        }
        //        string[] col = headerStr.Split(',');
        //        string[] array = col;
        //        foreach (string a in array)
        //        {
        //            dgRtData.Columns.Add(a, a);
        //        }
        //    }
        //    string valStr = "";
        //    foreach (PropertyInfo per in perList)
        //    {
        //        if (valStr != "")
        //        {
        //            valStr += ",";
        //        }
        //        valStr += per.GetValue(obj).ToString();
        //    }
        //    string[] val = valStr.Split(',');
        //    DataGridViewRowCollection rows = dgRtData.Rows;
        //    object[] values = val;
        //    rows.Insert(0, values);
        //    bool result = false;
        //    try
        //    {
        //        result = (bool)obj.GetType().GetProperty("Result").GetValue(obj);
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //    for (int i = 0; i < val.Length; i++)
        //    {
        //        if (result)
        //        {
        //            dgRtData.Rows[0].Cells[i].Style.BackColor = Color.Green;
        //        }
        //        else
        //        {
        //            dgRtData.Rows[0].Cells[i].Style.BackColor = Color.Red;
        //        }
        //    }
        //}

        //public void AddPartInfo<T>(T entiy, bool saveDataBase = false) where T : class
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new Action<T, bool>(AddPartInfo), entiy, saveDataBase);
        //        return;
        //    }
        //    if (saveDataBase)
        //    {
        //        MongodbHelper.InsertOne<T>(entiy, null, null);
        //    }
        //    List<PropertyInfo> perList = typeof(T).GetProperties().ToList();
        //    if (dgRtData.ColumnCount == 0)
        //    {
        //        string headerStr = "";
        //        foreach (PropertyInfo per2 in perList)
        //        {
        //            object[] objs = per2.GetCustomAttributes(typeof(DescriptionAttribute), inherit: true);
        //            if (objs.Length != 0)
        //            {
        //                if (headerStr != "")
        //                {
        //                    headerStr += ",";
        //                }
        //                headerStr += ((DescriptionAttribute)objs[0]).Description;
        //            }
        //        }
        //        string[] col = headerStr.Split(',');
        //        string[] array = col;
        //        foreach (string a in array)
        //        {
        //            dgRtData.Columns.Add(a, a);
        //        }
        //    }
        //    string valStr = "";
        //    foreach (PropertyInfo per in perList)
        //    {
        //        if (valStr != "")
        //        {
        //            valStr += ",";
        //        }
        //        valStr += per.GetValue(entiy).ToString();
        //    }
        //    string[] val = valStr.Split(',');
        //    DataGridViewRowCollection rows = dgRtData.Rows;
        //    object[] values = val;
        //    rows.Insert(0, values);
        //    bool result = false;
        //    try
        //    {
        //        string str = (string)typeof(T).GetProperty("Result")?.GetValue(entiy);
        //        result = ((str == "OK") ? true : false);
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //    for (int i = 0; i < dgRtData.ColumnCount; i++)
        //    {
        //        dgRtData.Rows[0].Cells[i].Style.BackColor = (result ? Color.Green : Color.Red);
        //    }
        //}


        //private DataTable GetDgvToTable(DataGridView dgv)
        //{
        //    DataTable dt = new DataTable();
        //    for (int i = 0; i < dgv.Columns.Count; i++)
        //    {
        //        DataColumn dc = new DataColumn(dgv.Columns[i].Name.ToString());
        //        dt.Columns.Add(dc);
        //    }
        //    for (int j = 0; j < dgv.Rows.Count; j++)
        //    {
        //        DataRow dr = dt.NewRow();
        //        for (int k = 0; k < dgv.Columns.Count; k++)
        //        {
        //            dr[k] = Convert.ToString(dgv.Rows[j].Cells[k].Value);
        //        }
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //} 
        #endregion
    }
}
