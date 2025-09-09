/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowTypeAttributes.cs
 * Author: Victor
 * Description: 显示基元属性类
 * CreateTime: 2023-1-10
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230110>
 * 1、ListToDataTable增加自定义排序
******************************************************************************/

using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowAudio.Properties;

namespace Lead.CPrim.ShowAudio
{
    /// <summary>AQCI显示属性</summary>
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        string path = Path.Combine(Application.StartupPath, @"Images\ShowAudio\Default.png");
        string backUpPath = Path.Combine(Application.StartupPath, @"Images\Default.png");
        public string Name => "Audio";
        public string DisplayName => "Audio";
        public string Description => "Show for Audio";
        public Image Icon
        {
            get
            {
                if (File.Exists(path))
                {
                    return Image.FromFile(path);
                }
                else
                {
                    if (File.Exists(backUpPath))
                    {
                        return Image.FromFile(backUpPath);
                    }
                    else
                    {
                        var manager = new ResourceManager(typeof(Resources));
                        return (Image)manager.GetObject("Default");
                    }
                }
            }
        }
        public string DisplayGroup => "PAX";
        public string Group => "PAX";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
    }
}