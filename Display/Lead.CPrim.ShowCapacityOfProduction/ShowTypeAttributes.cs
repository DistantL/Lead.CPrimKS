/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowTypeAttributes.cs
 * Author: Victor
 * Description: AQCI显示属性类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220710
 * 1、基元图片移动至Properties
******************************************************************************/

using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowCapacityOfProduction.Properties;

namespace Lead.CPrim.ShowCapacityOfProduction
{
    /// <summary>AQCI显示属性</summary>
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        string path = Path.Combine(Application.StartupPath, @"Images\ShowCapacityOfProduction\Default.png");
        string backUpPath = Path.Combine(Application.StartupPath, @"Images\Default.png");
        public string Name => "CapacityOfProduction";
        public string DisplayName => "CapacityOfProduction";
        public string Description => "Show for CapacityOfProduction";
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