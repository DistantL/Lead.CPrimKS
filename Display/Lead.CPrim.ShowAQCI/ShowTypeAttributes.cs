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
using System.Resources;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowAQCI.Properties;

namespace Lead.CPrim.ShowAQCI
{
    /// <summary>AQCI显示属性</summary>
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        public string Name => "AQCI";
        public string DisplayName => "AQCI";
        public string Description => "Show for AQCI";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resources));
                return (Image)manager.GetObject("Default");
            }
        }
        public string DisplayGroup => "PAX";
        public string Group => "PAX";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
    }
}