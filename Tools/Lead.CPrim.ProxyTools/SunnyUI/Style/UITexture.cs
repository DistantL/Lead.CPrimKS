/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UITexture.cs
 * Author: Victor
 * Description: 主题背景纹理类
 * CreateTime: 2020-12-10
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-12-10: V3.0.9 增加文件说明
 * 
 * <3.3.23.0101><Victor><20230107>
 * 1、初版1.0
******************************************************************************/

using System.Drawing;

namespace Lead.CPrim.ProxyTools.SunnyUI.Style
{
    public static class UITexture
    {
        public static TextureBrush CreateTextureBrush(Image img)
        {
            TextureBrush tb = new TextureBrush(img);
            tb.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            return tb;
        }
    }
}
