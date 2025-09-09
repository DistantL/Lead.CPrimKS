/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UFontImageDefine.cs
 * Author: Victor
 * Description: 字体图片定义类
 * CreateTime: 2020-01-01
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 * 2021-07-18: V3.0.5 将字体图标最大尺寸从64调整到128
 *
 * 3.3.22.0728 -> 
 * <Author> (Victor)    <Time> (20220807)
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Fonts
******************************************************************************/

using System.Drawing;

namespace Lead.CPrim.ProxyTools.SunnyUI.Fonts
{
    public interface ISymbol
    {
        int Symbol { get; set; }

        int SymbolSize { get; set; }

        Point SymbolOffset { get; set; }
    }

    public enum UISymbolType
    {
        FontAwesomeV4 = 0,
        FontAwesomeV5Brands = 1,
        FontAwesomeV5Regular = 2,
        FontAwesomeV5Solid = 3
    }

    public enum ImageFont
    {
        FontAwesome,
        Elegant,
    }
}