/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIDPIScale.cs
 * Author: Victor
 * Description: DPI自适应类
 * CreateTime: 2021-12-01
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.23.0101><Victor><20230107>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Style
{
    public static class UIDPIScale
    {
        public static float DPIScale()
        {
            return GDI.Graphics().DpiX / 96.0f / (UIStyles.FontSize / 12.0f);
        }

        public static bool DPIScaleIsOne()
        {
            return DPIScale().EqualsFloat(1);
        }

        internal static float DPIScaleFontSize(this Font font)
        {
            if (UIStyles.DPIScale)
                return font.Size / DPIScale();
            else
                return font.Size;
        }

        internal static Font DPIScaleFont(this Font font)
        {
            return font.DPIScaleFont(font.Size);
        }

        internal static Font DPIScaleFont(this Font font, float fontSize)
        {
            if (UIStyles.DPIScale)
            {
                if (font.GdiCharSet == 134)
                    return new Font(font.FontFamily, fontSize / DPIScale(), font.Style, font.Unit, font.GdiCharSet);
                else
                    return new Font(font.FontFamily, fontSize / DPIScale());
            }
            else
            {
                if (font.GdiCharSet == 134)
                    return new Font(font.FontFamily, fontSize, font.Style, font.Unit, font.GdiCharSet);
                else
                    return new Font(font.FontFamily, fontSize);
            }
        }

        internal static void SetDPIScaleFont(this Control control)
        {
            if (!UIStyles.DPIScale) return;
            if (!DPIScaleIsOne())
            {
                if (control is IStyleInterface ctrl)
                {
                    if (!ctrl.IsScaled)
                        control.Font = control.Font.DPIScaleFont();
                }
            }
        }

        internal static List<Control> GetAllDPIScaleControls(this Control control)
        {
            var list = new List<Control>();
            foreach (Control con in control.Controls)
            {
                list.Add(con);

                if (con is UITextBox) continue;
                if (con is UIDropControl) continue;
                if (con is UIListBox) continue;
                if (con is UIImageListBox) continue;
                if (con is UIPagination) continue;
                if (con is UIRichTextBox) continue;
                if (con is UITreeView) continue;

                if (con.Controls.Count > 0)
                {
                    list.AddRange(con.GetAllDPIScaleControls());
                }
            }

            return list;
        }

        internal static List<Control> GetAllZoomScaleControls(this Control control)
        {
            var list = new List<Control>();
            foreach (Control con in control.Controls)
            {
                if (con is IZoomScale)
                    list.Add(con);

                if (con is UITextBox) continue;
                if (con is UIDropControl) continue;
                if (con is UIListBox) continue;
                if (con is UIImageListBox) continue;
                if (con is UIPagination) continue;
                if (con is UIRichTextBox) continue;
                if (con is UITreeView) continue;

                if (con.Controls.Count > 0)
                {
                    list.AddRange(con.GetAllZoomScaleControls());
                }
            }

            return list;
        }
    }
}
