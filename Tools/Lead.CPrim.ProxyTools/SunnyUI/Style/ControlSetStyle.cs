using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// SetStyle<br/>
    /// UIComboBox<br/>
    /// UISymbolButton<br/>
    /// UITextBox<br/>
    /// UIDatetimePicker<br/>
    /// UITabControl<br/>
    /// UIButton<br/>
    /// UILabel<br/>
    /// UICheckBox
    /// </summary>
    public static class ControlSetStyle
    {
        /// <summary>
        /// Control内部控件样式设置
        /// </summary>
        /// <param name="control"></param>
        /// <param name="style"></param>
        public static void SetStyleALL(this Control control, ControlStyle style)
        {
            foreach (Control ctl in control.Controls)
            {
                if(ctl.Controls.Count > 0)
                {
                    SetStyleALL(ctl, style);
                }

                if (ctl is UIComboBox)
                {
                    ((UIComboBox)ctl).SetStyle(style);
                }
                else if (ctl is UISymbolButton)
                {
                    UISymbolButton btn = (UISymbolButton)ctl;
                    if (!btn.Name.IsNullOrEmpty())
                    {
                        ((UISymbolButton)ctl).SetStyle(style);
                    }
                }
                else if (ctl is UITextBox)
                {
                    ((UITextBox)ctl).SetStyle(style);
                }
                else if (ctl is UIDatetimePicker)
                {
                    ((UIDatetimePicker)ctl).SetStyle(style);
                }
                else if (ctl is UITabControl)
                {
                    ((UITabControl)ctl).SetStyle(style);
                }
                else if (ctl is UIButton)
                {
                    ((UIButton)ctl).SetStyle(style);
                }
                else if (ctl is UILabel)
                {
                    ((UILabel)ctl).SetStyle();
                }
                else if (ctl is UICheckBox)
                {
                    ((UICheckBox)ctl).SetStyle(style);
                    ((UICheckBox)ctl).AutoSize = true;
                }
                else if(ctl is UILine)
                {
                    ((UILine)ctl).SetStyle();
                }
                else if(ctl is UIRadioButton)
                {
                    ((UIRadioButton)ctl).SetStyle();
                }
            }
        }

        

        const int padding = 2;
        const int radius = 8;



        /// <summary>
        /// UIForm样式设置<br/>
        /// 12号加粗字体
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="fontSize"></param>
        /// <param name="fontStyle"></param>
        /// <param name="style"></param>
        public static void SetStyle(this UIForm frm, float fontSize = 12.0f, FontStyle fontStyle = FontStyle.Bold, ControlStyle style = ControlStyle.Light)
        {
            frm.TitleColor = style == ControlStyle.Light ? Colors.PrimaryFillColorLight : Colors.PrimaryFillColorDark;
            frm.TitleForeColor = Colors.PrimaryForeColorDark;
            frm.BackColor = style == ControlStyle.Light ? Colors.PrimaryFillColorLight : Colors.PrimaryFillColorDark; ;
            frm.RectColor = Colors.PrimaryRectColor;
            frm.ControlBoxForeColor = Colors.PrimaryForeColorDark;

            frm.TitleFont = new Font(UIGlobal.FontName, fontSize, fontStyle);

            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// UIComboBox设置样式<br/>
        /// 10号常规字体<br/>
        /// </summary>
        /// <param name="cb">UIComboBox</param>
        /// <param name="style"></param>
        public static void SetStyle(this UIComboBox cb, ControlStyle style = ControlStyle.Light)
        {
            cb.SetStyle(10.0f, FontStyle.Regular, style);
        }

        /// <summary>
        /// UIComboBox设置样式
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="cb">UIComboBox</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="style"></param>
        public static void SetStyle(this UIComboBox cb, float fontSize, FontStyle fontStyle, ControlStyle style = ControlStyle.Light)
        {
            cb.Style = UIStyle.Gray;

            cb.ForeColor = Colors.PrimaryForeColorDark;
            cb.FillColor = style == ControlStyle.Light ? Colors.PrimaryBackColorLight : Colors.PrimaryBackColorDark;
            cb.ItemFillColor = Colors.PrimaryBackColorLight;
            cb.RectColor = Colors.PrimaryRectColor;
            cb.BackColor = Color.Transparent;

            cb.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            cb.Radius = radius;
            cb.RectSize = 1;
            cb.Margin = new Padding(padding);
        }

        /// <summary>
        /// UISymbolButton样式设置<br/>
        /// 10号加粗字体<br/>
        /// </summary>
        /// <param name="btn">UISymbolButton</param>
        /// <param name="style"></param>
        public static void SetStyle(this UISymbolButton btn, ControlStyle style = ControlStyle.Light)
        {
            btn.SetStyle(10.0f, FontStyle.Bold, style);
        }

        /// <summary>
        /// UISymbolButton样式设置<br/>
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="btn">UISymbolButton</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="style"></param>
        public static void SetStyle(this UISymbolButton btn, float fontSize, FontStyle fontStyle, ControlStyle style = ControlStyle.Light)
        {
            btn.Style = UIStyle.Gray;

            btn.ForeColor = Colors.PrimaryForeColorDark;
            btn.FillColor = style == ControlStyle.Light ? Colors.PrimaryBackColorLight : Colors.PrimaryBackColorDark;
            btn.RectColor = Colors.PrimaryRectColor;
            btn.BackColor = Color.Transparent;
            btn.SymbolColor = Colors.PrimaryForeColorDark;

            btn.SymbolSize = (int)fontSize;
            btn.Radius = radius;
            btn.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            btn.Margin = new Padding(padding);
        }

        /// <summary>
        /// UITextBox样式设置<br/>
        /// 10号常规字体<br/>
        /// 默认字体：64, 64, 64<br/>
        /// 默认边框：180, 180, 180<br/>
        /// </summary>
        /// <param name="txt">UITextBox</param>
        /// <param name="fillColor">背景色（默认211, 211, 211）</param>
        public static void SetStyle(this UITextBox txt, Color fillColor)
        {
            txt.SetStyle(10.0f, FontStyle.Regular, ControlStyle.Light);
            txt.FillColor = fillColor;
        }

        /// <summary>
        /// UITextBox样式设置<br/>
        /// 10号常规字体<br/>
        /// 默认背景色：236, 236, 236<br/>
        /// 默认字体：64, 64, 64<br/>
        /// 默认边框：180, 180, 180<br/>
        /// </summary>
        /// <param name="txt">UITextBox</param>
        /// <param name="style"></param>
        public static void SetStyle(this UITextBox txt, ControlStyle style = ControlStyle.Light)
        {
            txt.SetStyle(10.0f, FontStyle.Regular, style);
        }

        /// <summary>
        /// UITextBox样式设置<br/>
        /// 自定义字体<br/>
        /// 默认背景色：236, 236, 236<br/>
        /// 默认字体：64, 64, 64<br/>
        /// 默认边框：180, 180, 180<br/>
        /// </summary>
        /// <param name="txt">UITextBox</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="style"></param>
        public static void SetStyle(this UITextBox txt, float fontSize, FontStyle fontStyle, ControlStyle style = ControlStyle.Light)
        {
            txt.Style = UIStyle.Gray;

            txt.ForeColor = Colors.PrimaryForeColorDark;
            txt.FillColor = style == ControlStyle.Light ? Colors.PrimaryBackColorLight : Colors.PrimaryBackColorDark;
            txt.RectColor = Colors.PrimaryRectColor;
            txt.BackColor = Color.Transparent;

            txt.Radius = radius;
            txt.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            txt.Margin = new Padding(padding);
        }

        /// <summary>
        /// UIDatetimePicker样式设置<br/>
        /// 10号常规字体<br/>
        /// 默认边框：180, 180, 180<br/>
        /// </summary>
        /// <param name="dtp">UIDatetimePicker</param>
        /// <param name="style"></param>
        public static void SetStyle(this UIDatetimePicker dtp, ControlStyle style = ControlStyle.Light)
        {
            dtp.SetStyle(10.0f, FontStyle.Regular, style);
        }

        /// <summary>
        /// UIDatetimePicker样式设置<br/>
        /// 自定义字体<br/>
        /// 默认边框：180, 180, 180<br/>
        /// </summary>
        /// <param name="dtp">UIDatetimePicker</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="style"></param>
        public static void SetStyle(this UIDatetimePicker dtp, float fontSize, FontStyle fontStyle, ControlStyle style = ControlStyle.Light)
        {
            dtp.Style = UIStyle.Gray;

            dtp.ForeColor = Colors.PrimaryForeColorDark;
            dtp.FillColor = style == ControlStyle.Light ? Colors.PrimaryBackColorLight : Colors.PrimaryBackColorDark;
            dtp.RectColor = Colors.PrimaryRectColor;
            dtp.BackColor = Color.Transparent;

            dtp.Radius = radius;
            dtp.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            dtp.Margin = new Padding(padding);
        }

        /// <summary>
        /// UITabControl样式设置<br/>
        /// 10号常规字体<br/>
        /// </summary>
        /// <param name="tab">UITabControl</param>
        /// <param name="style"></param>
        public static void SetStyle(this UITabControl tab, ControlStyle style = ControlStyle.Light)
        {
            tab.SetStyle(10.0f, FontStyle.Regular, style);
        }

        /// <summary>
        /// UITabControl样式设置<br/>
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="tab">UITabControl</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="style"></param>
        public static void SetStyle(this UITabControl tab, float fontSize, FontStyle fontStyle, ControlStyle style = ControlStyle.Light)
        {
            tab.Style = UIStyle.Gray;

            tab.TabSelectedForeColor = Colors.PrimaryForeColorDark;
            tab.TabUnSelectedForeColor = Color.FromArgb(128, 128, 128);
            tab.FillColor = style == ControlStyle.Light ? Colors.PrimaryFillColorLight : Colors.PrimaryFillColorDark;
            tab.TabBackColor = style == ControlStyle.Light ? Colors.PrimaryFillColorLight : Colors.PrimaryFillColorDark;
            tab.TabSelectedColor = Color.FromArgb(192, 192, 192);
            tab.TabSelectedHighColor = Color.FromArgb(192, 192, 192);

            tab.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            tab.Margin = new Padding(0);
        }

        /// <summary>
        /// UIButton样式设置<br/>
        /// 10号加粗字体<br/>
        /// </summary>
        /// <param name="btn">UIButton</param>
        /// <param name="fillColor"></param>
        public static void SetStyle(this UIButton btn, Color fillColor)
        {
            btn.SetStyle(10.0f, FontStyle.Bold, ControlStyle.Light);
            btn.FillColor = fillColor;
        }

        /// <summary>
        /// UIButton样式设置<br/>
        /// 10号加粗字体<br/>
        /// </summary>
        /// <param name="btn">UIButton</param>
        /// <param name="style"></param>
        public static void SetStyle(this UIButton btn, ControlStyle style = ControlStyle.Light)
        {
            btn.SetStyle(10.0f, FontStyle.Bold, style);
        }

        /// <summary>
        /// UIButton样式设置<br/>
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="btn">UIButton</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="style"></param>
        public static void SetStyle(this UIButton btn, float fontSize, FontStyle fontStyle, ControlStyle style = ControlStyle.Light)
        {
            btn.Style = UIStyle.Gray;

            btn.ForeColor = Colors.PrimaryForeColorDark;
            btn.FillColor = style == ControlStyle.Light ? Colors.PrimaryBackColorLight : Colors.PrimaryBackColorDark;
            btn.RectColor = Colors.PrimaryRectColor;
            btn.BackColor = Color.Transparent;

            btn.Radius = radius;
            btn.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            btn.Margin = new Padding(padding);
        }

        /// <summary>
        /// UILabel样式设置<br/>
        /// 10号常规字体<br/>
        /// </summary>
        /// <param name="lbl">UILabel</param>
        public static void SetStyle(this UILabel lbl)
        {
            lbl.SetStyle(12.0f, FontStyle.Bold);
        }

        /// <summary>
        /// UILabel样式设置<br/>
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="lbl">UILabel</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        public static void SetStyle(this UILabel lbl, float fontSize, FontStyle fontStyle)
        {
            lbl.Style = UIStyle.Gray;

            lbl.ForeColor = Colors.PrimaryForeColorDark;
            lbl.BackColor = Color.Transparent;

            lbl.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            lbl.Margin = new Padding(padding);
        }

        /// <summary>
        /// UICheckBox样式设置<br/>
        /// 10号常规字体<br/>
        /// </summary>
        /// <param name="chk">UICheckBox</param>
        /// <param name="style"></param>
        public static void SetStyle(this UICheckBox chk, ControlStyle style = ControlStyle.Light)
        {
            chk.SetStyle(10.0f, FontStyle.Regular, style);
        }

        /// <summary>
        /// UICheckBox样式设置<br/>
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="chk">UICheckBox</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="style"></param>
        public static void SetStyle(this UICheckBox chk, float fontSize, FontStyle fontStyle, ControlStyle style = ControlStyle.Light)
        {
            chk.Style = UIStyle.Gray;

            chk.ForeColor= Colors.PrimaryForeColorDark;
            chk.BackColor = Color.Transparent;

            chk.Radius = radius;
            chk.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            chk.Margin = new Padding(padding);
        }

        /// <summary>
        /// UILine样式设置<br/>
        /// 透明填充<br/>
        /// 10号常规字体<br/>
        /// </summary>
        /// <param name="line">UILine</param>
        /// <param name="lineColor">线条颜色（默认180, 180, 180）</param>
        public static void SetStyle(this UILine line, Color lineColor = default)
        {
            line.SetStyle(10.0f, FontStyle.Bold, lineColor);
        }

        /// <summary>
        /// UILine样式设置<br/>
        /// 透明填充<br/>
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="line">UILine</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="lineColor">线条颜色（默认180, 180, 180）</param>
        public static void SetStyle(this UILine line, float fontSize, FontStyle fontStyle, Color lineColor = default)
        {
            line.Style = UIStyle.Gray;
            line.FillColor = Color.Transparent;
            line.LineColor = lineColor == default ? Colors.PrimaryBackColor180 : lineColor;
            line.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
        }

        /// <summary>
        /// UIRadioButton样式设置<br/>
        /// 默认10号常规字体<br/>
        /// </summary>
        /// <param name="btn"></param>
        public static void SetStyle(this UIRadioButton btn)
        {
            btn.SetStyle(10.0f, FontStyle.Regular);
        }

        /// <summary>
        /// UIRadioButton样式设置<br/>
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="fontSize"></param>
        /// <param name="fontStyle"></param>
        public static void SetStyle(this UIRadioButton btn, float fontSize, FontStyle fontStyle)
        {
            btn.Style = UIStyle.Gray;
            btn.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
            btn.BackColor = Color.Transparent;
        }

        /// <summary>
        /// UISwitch样式设置<br/>
        /// 默认10号常规字体<br/>
        /// </summary>
        /// <param name="switch"></param>
        public static void SetStyle(this UISwitch @switch)
        {
            @switch.SetStyle(10.0f, FontStyle.Regular);
        }

        /// <summary>
        /// UISwitch样式设置<br/>
        /// 自定义字体<br/>
        /// </summary>
        /// <param name="switch"></param>
        /// <param name="fontSize"></param>
        /// <param name="fontStyle"></param>
        public static void SetStyle(this UISwitch @switch, float fontSize, FontStyle fontStyle)
        {
            @switch.Style = UIStyle.Gray;
            @switch.Font = new Font(UIGlobal.FontName, fontSize, fontStyle);
        }




        //*****************************************************************************
        /// <summary>
        /// UIPanel样式设置<br/>
        /// 填充颜色与边框颜色默认透明
        /// </summary>
        /// <param name="pnl">UIPanel</param>
        /// <param name="fillColor">填充颜色（默认透明）</param>
        /// <param name="rectColor">边框颜色（默认透明）</param>
        public static void SetStyle(this UIPanel pnl, Color fillColor = default, Color rectColor = default)
        {
            pnl.FillColor = fillColor == default ? Color.Transparent : fillColor;
            pnl.RectColor = rectColor == default ? Color.Transparent : rectColor;
        }

        /// <summary>
        /// UITableLayoutPanel样式设置
        /// </summary>
        /// <param name="tlp">UITableLayoutPanel</param>
        /// <param name="style"></param>
        public static void SetStyle(this UITableLayoutPanel tlp, ControlStyle style = ControlStyle.Light)
        {
            tlp.BackColor = style == ControlStyle.Light ? Colors.PrimaryFillColorLight : Colors.PrimaryBackColorDark;
        }

        /// <summary>UITreeView样式设置（填充颜色与边框颜色默认透明）</summary>
        /// <param name="tvw">UITreeView</param>
        /// <param name="fillColor">填充颜色（默认透明）</param>
        /// <param name="rectColor">边框颜色（默认透明）</param>
        public static void SetStyle(this UITreeView tvw, Color fillColor = default, Color rectColor = default)
        {
            tvw.FillColor = fillColor == default(Color) ? Color.Transparent : fillColor;
            tvw.RectColor = rectColor == default(Color) ? Color.Transparent : rectColor;
            tvw.Font = new Font(UIGlobal.FontName, 9.0f, FontStyle.Bold);
            tvw.ForeColor = Color.FromArgb(32, 32, 32);
        }

        /// <summary>UIGroupBox样式设置（填充颜色与边框颜色默认透明）</summary>
        /// <param name="grp">UIGroupBox</param>
        /// <param name="fillColor">填充颜色（默认透明）</param>
        /// <param name="rectColor">边框颜色（默认透明）</param>
        public static void SetStyle(this UIGroupBox grp, Color fillColor = default, Color rectColor = default)
        {
            grp.FillColor = fillColor == default ? Color.Transparent : fillColor;
            grp.RectColor = rectColor == default ? Color.Transparent : rectColor;
            grp.Font = new Font(UIGlobal.FontName, 10.0f, FontStyle.Regular);
        }

        /// <summary>
        /// UIDataGridView设置样式（默认10常规236颜色字体）
        /// </summary>
        /// <param name="dgv">UIDataGridView</param>
        /// <param name="autoGenerateColumns">默认true（true：自动生成列头；false：不生成列头）</param>
        /// <param name="showRowHeaders">默认true（true：显示行头；false：不显示行头）</param>
        /// <param name="fullRowSelect">默认true（true：整行选中；false：单个单元格选中）</param>
        /// <param name="mode">默认None</param>
        /// <param name="alignment">单元格默认对齐方式（默认MiddleCenter）</param>
        /// <param name="fontSize">字体大小（默认10.0）</param>
        /// <param name="fontStyle">字体样式（默认常规）</param>
        /// <param name="color">背景色（默认236, 236, 236）</param>
        public static void SetStyle(
            this UIDataGridView dgv,
            bool autoGenerateColumns = true,
            bool showRowHeaders = false,
            bool fullRowSelect = false,
            DataGridViewAutoSizeColumnsMode mode = DataGridViewAutoSizeColumnsMode.None,
            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleCenter,
            float fontSize = 10.0f,
            FontStyle fontStyle = FontStyle.Regular,
            Color color = default)
        {
            dgv.Style = UIStyle.Gray;
            dgv.Init(autoGenerateColumns, showRowHeaders, fullRowSelect, mode);
            dgv.BackgroundColor = color == default ? Colors.PrimaryFillColorLight : color;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font(UIGlobal.FontName, fontSize, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = color == default ? Colors.PrimaryFillColorLight : color,
                WrapMode = DataGridViewTriState.True,
            };
            dgv.RowsDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = alignment,
                Font = new Font(UIGlobal.FontName, fontSize, fontStyle),
                WrapMode = DataGridViewTriState.True,
            };
            dgv.RowTemplate = new DataGridViewRow
            {
                Height = 27,
                //Resizable = DataGridViewTriState.True,
            };
            dgv.RectColor = Color.FromArgb(147, 153, 157);
            dgv.GridColor = Color.FromArgb(147, 153, 157);
            dgv.StripeOddColor = color == default ? Colors.PrimaryFillColorLight : color;
            dgv.StripeEvenColor = color == default ? Colors.PrimaryFillColorLight : color;
        }

        /// <summary>
        /// DataGridView设置样式（默认10常规236颜色字体）
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="autoGenerateColumns">默认true（true：自动生成列头；false：不生成列头）</param>
        /// <param name="showRowHeaders">默认true（true：显示行头；false：不显示行头）</param>
        /// <param name="fullRowSelect">默认true（true：整行选中；false：单个单元格选中）</param>
        /// <param name="mode">默认None</param>
        /// <param name="alignment">单元格默认对齐方式（默认MiddleCenter）</param>
        /// <param name="fontSize">字体大小（默认10.0）</param>
        /// <param name="fontStyle">字体样式（默认常规）</param>
        /// <param name="color">背景色（默认236, 236, 236）</param>
        public static void SetStyle(
            this DataGridView dgv,
            bool autoGenerateColumns = true,
            bool showRowHeaders = false,
            bool fullRowSelect = false,
            DataGridViewAutoSizeColumnsMode mode = DataGridViewAutoSizeColumnsMode.None,
            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleCenter,
            float fontSize = 10.0f,
            FontStyle fontStyle = FontStyle.Regular,
            Color color = default)
        {
            //自动生成列头
            dgv.AutoGenerateColumns = autoGenerateColumns;

            //列占满行
            dgv.AutoSizeColumnsMode = mode;

            //禁止调整数据行行高
            dgv.AllowUserToResizeRows = false;

            //允许调整标题行行宽
            dgv.AllowUserToResizeColumns = true;

            //禁用最后一行空白，自动新增行
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = true;

            //禁止行多选
            dgv.MultiSelect = showRowHeaders;

            //显示数据行标题
            dgv.RowHeadersVisible = showRowHeaders;

            //禁止只读
            dgv.ReadOnly = false;

            //行选
            dgv.SelectionMode = fullRowSelect ? DataGridViewSelectionMode.FullRowSelect : DataGridViewSelectionMode.RowHeaderSelect;

            dgv.BackgroundColor = color == default ? Colors.PrimaryFillColorLight : color;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font(UIGlobal.FontName, fontSize, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = color == default ? Colors.PrimaryFillColorLight : color,
                WrapMode = DataGridViewTriState.True,
            };
            dgv.RowsDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = alignment,
                Font = new Font(UIGlobal.FontName, fontSize, fontStyle),
                WrapMode = DataGridViewTriState.True,
            };
            dgv.RowTemplate = new DataGridViewRow
            {
                Height = 27,
                //Resizable = DataGridViewTriState.True,
            };
            dgv.GridColor = Color.FromArgb(147, 153, 157);
        }

        /// <summary>
        /// UIDoubleUpDown样式设置
        /// </summary>
        /// <param name="upDown">UIDoubleUpDown</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="step">步进值</param>
        /// <param name="decimalPlaces">小数位数</param>
        public static void SetStyle(
            this UIDoubleUpDown upDown,
            double min,
            double max,
            double step,
            int decimalPlaces)
        {
            upDown.Style = UIStyle.Gray;
            upDown.MinimumEnabled = true;
            upDown.Minimum = min;
            upDown.MaximumEnabled = true;
            upDown.Maximum = max;
            upDown.Step = step;
            upDown.DecimalPlaces = decimalPlaces;
        }

        /// <summary>
        /// UIPage样式设置（默认14号加粗字体）
        /// </summary>
        /// <param name="page">UIPage</param>
        /// <param name="style"></param>
        public static void SetStyle(this UIPage page, ControlStyle style = ControlStyle.Light)
        {
            page.BackColor = style == ControlStyle.Light ? Colors.PrimaryFillColorLight : Colors.PrimaryBackColorDark;
            page.RectColor = Colors.PrimaryRectColor;
        }
    }
}