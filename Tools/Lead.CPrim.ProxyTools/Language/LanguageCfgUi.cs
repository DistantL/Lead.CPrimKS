using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public partial class LanguageCfgUi : UIUserControl
    {
        public LanguageCfgUi()
        {
            InitializeComponent();

            //dataGridView1.SetStyle(false, false, false, DataGridViewAutoSizeColumnsMode.None);
        }

        private void ShowUI(BindingList<LanguageInfo> values)
        {
            dataGridView1.SuspendLayout();
            dataGridView1.DataSource = values;
            dataGridView1.ResumeLayout();
        }

        private void LanguageCfgUi_Load(object sender, EventArgs e)
        {
            ShowUI(LanguageManager.Instance.GetLanguageInfo());
        }

        private void toolStripMenuItem_ImportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                if (!FileHelper.OpenFileDialogMethod("", FilterType.XLSX, false, ref path))
                {
                    return;
                }

                List<string> ls = new List<string>();
                BindingList<LanguageInfo> binds = new BindingList<LanguageInfo>();
                if (ExcelHelper.ReadExcelToListString(path, "Sheet1", Encoding.Default, false, out ls, "#") && ls.IsValid())
                {
                    for (int i = 0; i < ls.Count; i++)
                    {
                        string[] re = ls[i].Split('#');
                        if (re.Length < 4)
                        {
                            throw new Exception($"CSV{NLocalizer.GetString("Format", "Format")}");
                        }
                        LanguageInfo bind = new LanguageInfo();
                        bind.Name = re[0];
                        bind.Chinese = re[1];
                        bind.English = re[2];
                        bind.Vn = re[3];

                        if (binds.FirstOrDefault(b => b.Name == re[0]) == null)
                        {
                            binds.Add(bind);
                        }
                    }

                    if (binds.IsValid())
                    {
                        LanguageManager.Instance.LanguageInfos = binds;
                        ShowUI(LanguageManager.Instance.LanguageInfos);
                    }
                }
                else
                {
                    throw new Exception("Data Is Null");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogAdd(LogLevel.Warn, $"{NLocalizer.ImportCSV}：{ex.Message}", PrimLogId.Tool.ToString());
            }
        }

        private void toolStripMenuItem_ExportCSV_Click(object sender, EventArgs e)
        { 
            string path = "";
            if (!FileHelper.SaveFileDialogMethod("", FilterType.XLSX, DefaultExt.XLSX, true, false, true, ref path))
            {
                return;
            }

            List<string> languages = new List<string>();
            if (ControlHelper.GetDgvData(dataGridView1, true, ref languages, strSplit: "#"))
            {
                ExcelHelper.WriteListStringToExcel(path, languages, false, "#");
            }
        }

        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(NLocalizer.GetString("Lead_CPrim_Language_Forms_LanguageConfigForm_ConfirmDeleteLanguage", "确认删除该配置?"),
                NLocalizer.GetString("Lead_CPrim_Language_Forms_LanguageConfigForm_Warnning", "警告!"),
                MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void uiTextBox1_Changed(object sender, EventArgs e)
        {
            timerQuery.Stop();
            timerQuery.Start();
        }

        public int SaveLanguage()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Func<int>(SaveLanguage));
                return 0;
            }

            try
            {
                string errorText = string.Empty;
                if (ControlHelper.CheckDgvCellRepeat(dataGridView1, ref errorText))
                {
                    throw new Exception(errorText);
                }

                string multipleResourcesDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\StringResources";
                if (!Directory.Exists(multipleResourcesDirectory))
                {
                    throw new Exception($"{multipleResourcesDirectory} is not exist.");
                }

                Dictionary<string, string> cnDic = new Dictionary<string, string>();
                Dictionary<string, string> enDic = new Dictionary<string, string>();
                Dictionary<string, string> vnDic = new Dictionary<string, string>();
                foreach (DataGridViewRow data in dataGridView1.Rows)
                {
                    cnDic.Add(data.Cells[0].Value.ToString(), data.Cells[1].Value.ToString());
                    enDic.Add(data.Cells[0].Value.ToString(), data.Cells[2].Value.ToString());
                    vnDic.Add(data.Cells[0].Value.ToString(), data.Cells[3].Value.ToString());
                }

                string[] filesPath = Directory.GetFiles(multipleResourcesDirectory, "*.resx", SearchOption.AllDirectories);
                foreach (string filePath in filesPath)
                {
                    Dictionary<string, string> keyValuePairs;
                    if (filePath.EndsWith("zh-CN.resx"))
                    {
                        keyValuePairs = new Dictionary<string, string>(cnDic);
                    }
                    else if (filePath.EndsWith("en-US.resx"))
                    {
                        keyValuePairs = new Dictionary<string, string>(enDic);
                    }
                    else if (filePath.EndsWith("vi-VN.resx"))
                    {
                        keyValuePairs = new Dictionary<string, string>(vnDic);
                    }
                    else
                    {
                        continue;
                    }

                    using (ResXResourceWriter resXResourceWriter = new ResXResourceWriter(filePath))
                    {
                        foreach (string key in keyValuePairs.Keys)
                        {
                            resXResourceWriter.AddResource(key, keyValuePairs[key]);
                        }

                        resXResourceWriter.Generate();
                        resXResourceWriter.Dispose();
                        resXResourceWriter.Close();
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return -1;
            }
        }

        private void timerQuery_Tick(object sender, EventArgs e)
        {
            timerQuery.Stop();
            string text = uiTextBox1.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(text))
            {
                ShowUI(LanguageManager.Instance.LanguageInfos);
            }
            else
            {
                List<LanguageInfo> infos = LanguageManager.Instance.LanguageInfos.Where(p => p.Name.ToLower().Contains(text) || p.Chinese.ToLower().Contains(text)).ToList();
                if (infos != null) dataGridView1.DataSource = infos;
            }
        }

        public void dataGridViewRefresh()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(dataGridViewRefresh));
                return;
            }
            dataGridView1.Refresh();
        }
    }
}
