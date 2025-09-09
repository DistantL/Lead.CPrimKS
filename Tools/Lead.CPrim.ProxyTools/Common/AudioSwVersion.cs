using Lead.CPrim.ProxyTools;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Global
{
    public class AudioSwVersion
    {
        public enum SW_Type
        {
            /// <summary>
            /// SW for POR machine
            /// </summary>
            POR,
            /// <summary>
            /// SW for backup machine
            /// </summary>
            BKP,
            /// <summary>
            /// SW for retrofit machine
            /// </summary>
            RTF,
            /// <summary>
            /// SW version under validation
            /// </summary>
            VAL,
        }

        #region Field
        private readonly static AudioSwVersion instance = new AudioSwVersion();
        #endregion

        #region Prop
        public static AudioSwVersion Instance => instance;

        public int Main_SW_versionIndex { get; set; } = 1;

        public int Vision_SW_versionIndex { get; set; } = 1;

        public int Laser_SW_versionIndex { get; set; } = 0;

        public int Robot_SW_versionIndex { get; set; } = 1;

        public string SW_releaseDate { get; set; } = "250320";

        public string Main_SW_filePath { get; set; } = Application.ExecutablePath;

        public string Limits_version { get; set; }

        public string Main_SW_versionName
        {
            get
            {
                try
                {
                    string version = "";
                    using (StreamReader sr = new StreamReader(@"D:\Config\IniConfig\Lead.ini"))
                    {
                        version = sr.ReadLine();
                    }
                    if (string.IsNullOrWhiteSpace(version))
                    {
                        version = "";
                    }
                    string pattern = @"[0-9]\.[0-9]\.0\.[0-9]_(\d+)_[POR,VAL,BKP,RTF]";

                    Match match = Regex.Match(version, pattern);
                    if (match.Success)
                    {
                        return version;
                    }
                    else
                    {
                        return $"LEA_{Main_SW_versionIndex}.{Vision_SW_versionIndex}.{Laser_SW_versionIndex}.{Robot_SW_versionIndex}_{SW_releaseDate}_{CurrentSW_Type}";
                    }
                }
                catch (Exception)
                {
                    return $"LEA_{Main_SW_versionIndex}.{Vision_SW_versionIndex}.{Laser_SW_versionIndex}.{Robot_SW_versionIndex}_{SW_releaseDate}_{CurrentSW_Type}";
                }
            }
        }

        public SW_Type CurrentSW_Type { get; set; } = SW_Type.POR;
        #endregion

        public string GetSHA1InFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return string.Empty;
            }

            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                return string.Empty;
            }

            using var fileStream = fileInfo.OpenRead();
            var hash = System.Security.Cryptography.SHA1.Create();
            return BitConverter.ToString(hash.ComputeHash(fileStream)).Replace("-", "").ToLower();
        }
    }
}
