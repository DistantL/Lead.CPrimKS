using Lead.CPrim.ProxyTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public class LanguageManager
    {
        private static readonly LanguageManager _instance = new LanguageManager();

        private LanguageCfgUi _languageCfgUi = null;

        private BindingList<LanguageInfo> _languageInfos = null;

        public static LanguageManager Instance => _instance;

        public LanguageCfgUi LanguageCfgUi => _languageCfgUi;

        public BindingList<LanguageInfo> LanguageInfos { get => _languageInfos; set => _languageInfos = value; }

        private List<string> ReadResourceFile(ref Dictionary<string, string> cnDic, ref Dictionary<string, string> enDic, ref Dictionary<string, string> vnDic)
        {
            List<string> keyList = new List<string>();
            string multipleResourcesDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}\\StringResources";
            if (!Directory.Exists(multipleResourcesDirectory))
            {
                MessageBox.Show($"{multipleResourcesDirectory} is not exist.");
                return keyList;
            }

            string[] filesPath = Directory.GetFiles(multipleResourcesDirectory, "*.resx", SearchOption.AllDirectories);
            foreach (string filePath in filesPath)
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    continue;
                }
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"{filePath} is not exist.", "Tip");
                    continue;
                }
                try
                {
                    using (ResXResourceReader resXResourceReader = new ResXResourceReader(filePath))
                    {
                        string key = string.Empty;
                        string value = string.Empty;
                        foreach (DictionaryEntry dictionaryEntry in resXResourceReader)
                        {
                            key = dictionaryEntry.Key.ToString();
                            value = dictionaryEntry.Value.ToString();
                            if (filePath.EndsWith("zh-CN.resx"))
                            {
                                keyList.Add(key);
                                cnDic.Add(key, value);
                            }
                            else if (filePath.EndsWith("en-US.resx"))
                            {
                                enDic.Add(key, value);
                            }
                            else if (filePath.EndsWith("vi-VN.resx"))
                            {
                                vnDic.Add(key, value);
                            }
                        }

                        resXResourceReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception occor during read resource file:" + ex.Message, "Error");
                }
            }

            return keyList;
        }

        private static object lockObj = new object();

        public void UpdateLanguage(LanguageInfo language)
        {
            lock (lockObj)
            {
                _languageInfos.Add(language);
                _languageCfgUi ??= new LanguageCfgUi();
                _languageCfgUi.dataGridViewRefresh();
            }
        }

        public BindingList<LanguageInfo> GetLanguageInfo()
        {
            if (_languageInfos == null)
            {
                _languageInfos = new BindingList<LanguageInfo>();
                Dictionary<string, string> cnDic = new Dictionary<string, string>();
                Dictionary<string, string> enDic = new Dictionary<string, string>();
                Dictionary<string, string> vnDic = new Dictionary<string, string>();
                List<string> keyList = ReadResourceFile(ref cnDic, ref enDic, ref vnDic);
                foreach (string item in keyList)
                {
                    LanguageInfo info = new LanguageInfo
                    {
                        Name = item
                    };
                    if (cnDic.ContainsKey(item))
                    {
                        info.Chinese = cnDic[item];
                    }
                    else
                    {
                        info.Chinese = string.Empty;
                    }
                    if (enDic.ContainsKey(item))
                    {
                        info.English = enDic[item];
                    }
                    else
                    {
                        info.English = string.Empty;
                    }
                    if (vnDic.ContainsKey(item))
                    {
                        info.Vn = vnDic[item];
                    }
                    else
                    {
                        info.Vn = string.Empty;
                    }

                    _languageInfos.Add(info);
                }
            }
            return _languageInfos;
        }

        public void Init()
        {
            if (_languageCfgUi == null)
            {
                _languageCfgUi = new LanguageCfgUi();
            }
        }

        public int Save()
        {
            if (_languageCfgUi == null)
            {
                _languageCfgUi = new LanguageCfgUi();
            }

            int result = _languageCfgUi.SaveLanguage();
            if (result == 0)
            {
                UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_Language_LanguageConfigSaveSuccess", "语言配置保存成功"));
            }
            return result;
        }
    }

    public class LanguageInfo
    {
        public string Name { get; set; } = string.Empty;

        public string Chinese { get; set; } = string.Empty;

        public string English { get; set; } = string.Empty;

        public string Vn { get; set; } = string.Empty;
    }
}
