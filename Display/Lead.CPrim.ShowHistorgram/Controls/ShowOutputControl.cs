/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowOutputControl.cs
 * Author: Victor
 * Description: 用来直方图显示
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、代码风格重新布局以及增加备注
 * 2、增加模板导出及数据导入功能
 * 3、删除良率图UI，将良率直接显示在直方图上
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ShowHistorgram.FaiAnaylise;

namespace Lead.CPrim.ShowHistorgram.Controls
{
    public partial class ShowOutputControl : UserControl
    {
        #region Prop
        private new ShowHistorgram Show { get; }
        #endregion



        #region Ctor
        public ShowOutputControl()
        {
            InitializeComponent();
            InitializeUI();
            flpMain.SetDoubleBuffered();
        }
        public ShowOutputControl(ShowHistorgram show) : this()
        {
            Show = show;
        }
        #endregion



        //*****************************************************************************
        #region Button_Event
        /// <summary>清除</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClr_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorityManager.Instance.VerifyLevel2Permission(true))
                {
                    return;
                }
                Show.faisDic.Clear();
                flpMain.Controls.Clear();
                RefreshOutput();
            }
            catch (Exception ex)
            {
                Show.LogAdd($"清除失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>排序</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                flpMain.Controls.Clear();
                var fais = new List<FaiCount>();
                foreach (var ct in Show.faisDic)
                {
                    fais.Add(ct.Value);
                }
                switch (cbSort.SelectedItem.ToString())
                {
                    case "名称升序":
                        Show.SortType = SortType.名称升序;
                        fais.Sort((a, b) => a.FaiName.CompareTo(b.FaiName));
                        break;

                    case "名称降序":
                        Show.SortType = SortType.名称降序;
                        fais.Sort((a, b) => b.FaiName.CompareTo(a.FaiName));
                        break;

                    case "良率升序":
                        Show.SortType = SortType.良率升序;
                        fais.Sort((a, b) => a.OkRate.CompareTo(b.OkRate));
                        break;

                    case "良率降序":
                        Show.SortType = SortType.良率降序;
                        fais.Sort((a, b) => b.OkRate.CompareTo(a.OkRate));
                        break;

                    default:
                        Show.SortType = SortType.名称升序;
                        break;
                }
                fais.ForEach(p => AddConrol((HistorgramControl)p.FaiHistControl));
            }
            catch (Exception ex)
            {
                Show.LogAdd($"排序失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>保存小图</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveSmallPicture_Click(object sender, EventArgs e)
        {
            try
            {
                if(flpMain.Controls == null || flpMain.Controls.Count == 0)
                {
                    return;
                }
                var rows = (int)Math.Ceiling(flpMain.Controls.Count / 5.0);
                int width = flpMain.Controls[0].Width;
                int height = flpMain.Controls[0].Height;
                var pic = new Bitmap(5 * width, rows * height);
                var grp = Graphics.FromImage(pic);
                var serisNum = 0;
                foreach (HistorgramControl ctl in flpMain.Controls)
                {
                    grp.DrawImage(ctl.FaiCount.bitmap, new PointF(serisNum % 5 * width, serisNum / 5 * height));
                    serisNum++;
                }

                if (!Directory.Exists(Show.SavePicPath))
                {
                    Directory.CreateDirectory(Show.SavePicPath);
                }
                var picpah = Path.Combine(Show.SavePicPath, $@"Small_{DateTime.Now.ToString("yyyy-MM-dd HHmmss")}.png");
                pic.Save(picpah);
                Show.LogAdd($"保存小图成功", LogLevel.Trace);
            }
            catch (Exception ex)
            {
                Show.LogAdd($"保存小图失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>保存大图</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveBigPicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (flpMain.Controls == null || flpMain.Controls.Count == 0)
                {
                    return;
                }
                var rows = (int)Math.Ceiling(flpMain.Controls.Count / 5.0);
                var fai = (HistorgramControl)flpMain.Controls[0];
                double rate = 1.0;
                if (fai.FaiCount.theXLabel.Length > 14)
                {
                    rate = fai.FaiCount.theXLabel.Length / 14.0;
                }
                int width = (int)Math.Floor(600 * rate);
                int higth = (int)Math.Floor(400 * 1.0);

                var pic = new Bitmap(5 * width, rows * higth);
                var grp = Graphics.FromImage(pic);
                var serisNum = 0;
                foreach (HistorgramControl ctl in flpMain.Controls)
                {
                    ctl.FaiCount.DrawMapString();
                    grp.DrawImage(ctl.FaiCount.bitmapString, new PointF(serisNum % 5 * width, serisNum / 5 * higth));
                    serisNum++;
                }

                if (!Directory.Exists(Show.SavePicPath))
                {
                    Directory.CreateDirectory(Show.SavePicPath);
                }
                var picpah = Path.Combine(Show.SavePicPath, $@"Big_{DateTime.Now.ToString("yyyy-MM-dd HHmmss")}.png");
                pic.Save(picpah);
                Show.LogAdd($"保存大图成功", LogLevel.Trace);
            }
            catch (Exception ex)
            {
                Show.LogAdd($"保存大图失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>随机测试</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }
                FaiTest();
                RefreshOutput();
            }
            catch (Exception ex)
            {
                Show.LogAdd($"随机测试失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        /// <summary>模板导出</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplateExport_Click(object sender, EventArgs e)
        {
            try
            {
                string file = "";
                if (!FileHelper.SaveFileDialogMethod("", FilterType.CSV, DefaultExt.CSV, true, false, true, ref file))
                {
                    return;
                }

                string[] title = new string[] { "名称", "下极限", "上极限", "集合" };
                string value1 = "FAI14,0.793,0.993,0.877,0.887,0.877,0.884,0.876,-5,5,0.693,1,0.758";
                string value2 = "FAI8,0.793,0.993,0.877,0.887,0.877,0.884,0.876,0.895,0.81,0.693,1,0.758";
                string value3 = "FAI24,0.793,0.993,0.884,0.876,-5,5,0.693,1,0.758,,,";
                CsvHelper.WriteStringToCsv(file, string.Join(",", title), false);
                CsvHelper.WriteStringToCsv(file, value1, false);
                CsvHelper.WriteStringToCsv(file, value2, false);
                CsvHelper.WriteStringToCsv(file, value3, false);
                Show.LogAdd("Cpk模板导出成功", LogLevel.Trace);
            }
            catch (Exception ex)
            {
                Show.LogAdd($"Cpk模板导出失败：{ex.Message}", LogLevel.Warn);
            }
        }
        /// <summary>数据导入</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataImport_Click(object sender, EventArgs e)
        {
            try
            {
                if(!AuthorityManager.Instance.VerifyLevel3Permission(true))
                {
                    return;
                }
                string file = "";
                if (!FileHelper.OpenFileDialogMethod("", Interfaces.FilterType.CSV, false, ref file))
                {
                    return;
                }
                List<string> lString = new List<string>();
                if (!CsvHelper.ReadCsvToListString(file, Encoding.Default, false, out lString))
                {
                    throw new Exception("读取失败");
                }
                List<CpkImport> imports = new List<CpkImport>();
                for (int i = 0; i < lString.Count; i++)
                {
                    string msg = lString[i];
                    if (string.IsNullOrEmpty(msg))
                    {
                        throw new Exception("请按照模板格式导入");
                    }
                    string[] inputs = msg.Split(',');
                    if (inputs.Length < 4)
                    {
                        throw new Exception("请按照模板格式导入");
                    }

                    if (i == 0)
                    {
                        if (inputs[0] != "名称" || inputs[1] != "下极限" || inputs[2] != "上极限" || inputs[3] != "集合")
                        {
                            throw new Exception("请按照模板格式导入");
                        }
                    }
                    else
                    {
                        CpkImport cpk = new CpkImport();
                        cpk.FAIName = inputs[0];
                        cpk.LSL = double.TryParse(inputs[1], out var value1) ? value1 : throw new Exception("请按照模板格式导入");
                        cpk.USL = double.TryParse(inputs[2], out var value2) ? value2 : throw new Exception("请按照模板格式导入");
                        for (int j = 3; j < inputs.Length; j++)
                        {
                            if(string.IsNullOrEmpty(inputs[j]))
                            {
                                break;
                            }
                            double value = double.TryParse(inputs[j], out var value3) ? value3 : throw new Exception("请按照模板格式导入");
                            cpk.Datas.Add(value);
                        }
                        imports.Add(cpk);
                    }
                }
                foreach (var item in imports)
                {
                    foreach (var value in item.Datas)
                    {
                        Show.AddSingleFaiVal(item.FAIName, value, item.USL, item.LSL);
                    }
                }
                RefreshOutput();
                Show.LogAdd("Cpk模板导入成功", Interfaces.LogLevel.Trace);
            }
            catch (Exception ex)
            {
                Show.LogAdd($"Cpk模板导入失败：{ex.Message}", Interfaces.LogLevel.Warn);
            }
        }
        /// <summary>打开图片</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Show.SavePicPath))
                {
                    throw new Exception("图片文件夹为空");
                }
                if(!Directory.Exists(Show.SavePicPath))
                {
                    throw new Exception("图片文件夹不存在");
                }
                ProcessHelper.ProcessStart(Show.SavePicPath);
            }
            catch (Exception ex)
            {
                Show.LogAdd($"打开图片失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        #endregion



        #region Method_ExternalUsing
        public void RefreshOutput()
        {
            flpMain.Controls.Clear();
            foreach (var ct in Show.faisDic)
            {
                AddConrol((HistorgramControl)ct.Value.FaiHistControl);
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        private void FaiTest()
        {
            Model md = new Model();
            for (var i = 0; i < 50; i++)
            {
                double val = md.Random_Normal(0.5, 1.0, 0, 10);
                for (var j = 0; j < 20; j++)
                {
                    Show.AddSingleFaiVal($"fai{j.ToString()}", val, 8, -8);
                    Show.AddSingleFaiVal($"fai{j.ToString()}", -val, 8, -8);
                }
            }
        }
        /// <summary>排序初始化</summary>
        private void InitializeUI()
        {
            cbSort.Items.Clear();
            cbSort.Items.Add("");
            foreach (var item in Enum.GetNames(typeof(SortType)))
            {
                cbSort.Items.Add(item);
            }
        }
        private void AddConrol(HistorgramControl ctrl)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<HistorgramControl>(AddConrol), ctrl);
            }
            else
            {
                if (!flpMain.Controls.Contains(ctrl))
                {
                    flpMain.Controls.Add(ctrl);
                    ctrl.RefreshUI();
                }
            }
        }
        #endregion
    }

    public class CpkImport
    {
        public CpkImport()
        {
            FAIName = "";
            LSL = 0;
            USL = 0;
            Datas = new List<double>();
        }
        public string FAIName { get; set; }
        public double LSL { get; set; }
        public double USL { get; set; }
        public List<double> Datas { get; set; }
    }
}