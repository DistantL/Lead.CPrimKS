using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Lead.CPrim.ProxyTools
{
	public partial class NLocalizer
	{
        #region Event_Define
        public static event Action LanguageChanged;
        #endregion



        #region Field

        private static string languageFilePath = string.Empty;

        private static object lockObj = new object();

        private static Dictionary<string, string> resDictionary = new Dictionary<string, string>();

        private static string resourceDirectory = string.Empty;

        private static string language = string.Empty;
        #endregion



        #region Prop
        /// <summary>语言</summary>
        public static string Language
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(language))
                {
                    return language;
                }
                try
                {
                    if (File.Exists(languageFilePath))
                    {
                        XElement xElement = XElement.Load(languageFilePath);
                        language = ((xElement != null) ? xElement.Value : "zh-CN");
                    }
                }
                finally
                {
                    if (string.IsNullOrWhiteSpace(language))
                    {
                        language = "zh-CN";
                    }
                }
                return language;
            }
            private set
            {
                if (!value.Equals(language))
                {
                    language = value;
                    if (!string.IsNullOrWhiteSpace(languageFilePath))
                    {
                        XElement xElement = new XElement("Language", value);
                        xElement.Save(languageFilePath);
                    }
                }
            }
        }
        #endregion



        #region Method_ExternalUsing

        /// <summary>对应的语言获取</summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>string</returns>
        public static string GetString(string key, string defaultValue)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    result = defaultValue;
                }
                else
                {
                    lock (lockObj)
                    {
                        string strValue = string.Empty;
                        if (resDictionary.TryGetValue(key, out strValue))
                        {
                            result = strValue;
                            return result;
                        }
                        resDictionary.Add(key, defaultValue);
                        result = defaultValue;
                    }
                }
            }
            catch
            {
                result = defaultValue;
            }
            return result;
        }

        /// <summary>语言设置</summary>
        /// <param name="language">语言</param>
        /// <returns>bool</returns>
        public static bool SetLanguage(string languageValue)
        {
            if (languageValue != null
                && (languageValue.Equals("zh-CN")
                || languageValue.Equals("en-US")
                || languageValue.Equals("fr-FR")
                || languageValue.Equals("de-DE")
                || languageValue.Equals("vi-VN")))
            {
                if (string.IsNullOrWhiteSpace(languageFilePath))
                {
                    languageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Language.config");
                }

                Initialize(null, languageValue);

                LanguageChanged?.Invoke();
                return true;
            }
            return false;
        }
        #endregion



        #region Method_InternalUsing

        private static void LoadResourceFile(string resourceFileName)
        {
            if (string.IsNullOrWhiteSpace(resourceFileName))
            {
                return;
            }
            if (!File.Exists(resourceFileName))
            {
                MessageBox.Show($"{resourceFileName} is not exist.", "Tip");
                return;
            }
            string suffixString = $"{Language}.resx";
            if (!resourceFileName.EndsWith(suffixString))
            {
                if (!Language.Equals("en-US"))
                {
                    Console.WriteLine($"{resourceFileName} is not end with {suffixString}.");
                }
                return;
            }
            try
            {
                using (ResXResourceReader resXResourceReader = new ResXResourceReader(resourceFileName))
                {
                    string key = string.Empty;
                    string value = string.Empty;
                    foreach (DictionaryEntry dictionaryEntry in resXResourceReader)
                    {
                        key = dictionaryEntry.Key.ToString();
                        value = dictionaryEntry.Value.ToString();
                        if (!resDictionary.ContainsKey(key))
                        {
                            resDictionary.Add(key, value);
                        }
                        else
                        {
                            resDictionary[key] = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occor during read resource file:" + ex.Message);
            }
        }

        private static void LoadResources(string resourceConfigFile = null)
        {
            if (string.IsNullOrWhiteSpace(resourceConfigFile) || !File.Exists(resourceConfigFile))
            {
                string multipleResourcesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StringResources");
                if (!Directory.Exists(multipleResourcesDirectory))
                {
                    MessageBox.Show($"{multipleResourcesDirectory} is not exist.");
                    return;
                }
                string[] filesPath = Directory.GetFiles(multipleResourcesDirectory, "*.resx", SearchOption.AllDirectories);
                string[] array = filesPath;
                foreach (string filePath in array)
                {
                    LoadResourceFile(filePath);
                }
                return;
            }
            List<string> resourceFileList = new List<string>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(resourceConfigFile);
            XmlNode element = xmlDocument.SelectSingleNode("LC_XML").SelectSingleNode("ResourceFiles");
            XmlElement resourceFileElement = null;
            foreach (XmlNode childNode in element.ChildNodes)
            {
                if (childNode.Name.Equals("ResourceFile"))
                {
                    resourceFileElement = childNode as XmlElement;
                    if (resourceFileElement != null)
                    {
                        resourceFileList.Add(resourceFileElement.GetAttribute("Path"));
                    }
                }
            }
            resourceFileList.RemoveAll((string fileName) => string.IsNullOrWhiteSpace(fileName));
            foreach (string resourceFile in resourceFileList)
            {
                string resourceFileName = string.Empty;
                resourceFileName = ((!Path.IsPathRooted(resourceFile)) ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, resourceFile) : resourceFile);
                LoadResourceFile(resourceFileName);
            }
        }

        /// <summary>
        /// 中英互译初始化
        /// </summary>
        /// <param name="resourceConfigFile">配置文件</param>
        /// <param name="language">语言</param>
        private static void Initialize(string resourceConfigFile = null, string language = null)
        {
            try
            {
                languageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs\\ResourceConfigs", "Language.config");
                resourceDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs\\ResourceConfigs");
                if (language != null
                    && (language.Equals("zh-CN")
                    || language.Equals("en-US")
                    || language.Equals("fr-FR")
                    || language.Equals("de-DE")
                    || language.Equals("vi-VN")))
                {
                    Language = language;
                }
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Language);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Language);
                if (string.IsNullOrWhiteSpace(resourceConfigFile))
                {
                    LoadResources();
                    return;
                }
                string configFileName = string.Empty;
                configFileName = ((!Path.IsPathRooted(resourceConfigFile)) ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, resourceConfigFile) : resourceConfigFile);
                LoadResources(configFileName);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occor during localizer initialization:" + ex.Message);
            }
        }
        #endregion
    }
}
