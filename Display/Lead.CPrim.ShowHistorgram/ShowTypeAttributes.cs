/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowTypeAttributes.cs
 * Author: Victor
 * Description: 直方图实现类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、资源图片放至Properties
******************************************************************************/

using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowHistorgram.Properties;

namespace Lead.CPrim.ShowHistorgram
{
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        public string Name => "Historgram";
        public string DisplayName => "Historgram";
        public string Description => "Show Fai";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resources));
                return (Image)manager.GetObject("Default");
            }
        }
        public string DisplayGroup => "Test";
        public string Group => "Test";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
    }
}