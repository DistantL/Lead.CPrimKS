/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIColorPicker.cs
 * Author: Victor
 * Description: 颜色选择框（Color picker with color wheel and eye dropper）
 * CreateTime: 2023-1-2
 * Inherit：
 * 开源协议: CPOL
 * 引用地址: https://www.codeproject.com/Articles/21965/Color-Picker-with-Color-Wheel-and-Eye-Dropper
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-05-31: V2.2.5 增加文件
 * 2021-03-13: V3.0.2 增加单击事件以选中颜色
 * 2022-03-10: V3.1.1 修复选中颜色不显示
 * 
 * <3.3.23.0101><Victor><20230116>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.ProxyTools.SunnyUI.DropItem;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Sunny.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    [DefaultProperty("ValueChanged")]
    [ToolboxItem(true)]
    public sealed class UIColorPicker : UIDropControl
    {
        private void InitializeComponent()
        {
            SuspendLayout();
            //
            // UIColorPicker
            //
            DropDownStyle = UIDropDownStyle.DropDownList;
            Name = "UIColorPicker";
            Padding = new Padding(0, 0, 30, 0);
            ButtonClick += UIColorPicker_ButtonClick;
            ResumeLayout(false);
            PerformLayout();
        }

        public delegate void OnColorChanged(object sender, Color value);

        public event OnColorChanged ValueChanged;

        public UIColorPicker()
        {
            InitializeComponent();
            Value = UIColor.Blue;
        }

        private void UIColorPicker_ButtonClick(object sender, EventArgs e)
        {
            item.SelectedColor = Value;
            item.Translate();
            item.SetDPIScale();
            ItemForm.Show(this);
        }

        [DefaultValue(false)]
        [Description("整个控件点击下拉选择颜色"), Category("SunnyUI")]
        public bool FullControlSelect
        {
            get => fullControlSelect;
            set => fullControlSelect = value;
        }

        protected override void ItemForm_ValueChanged(object sender, object value)
        {
            if (Value != (Color)value)
            {
                Value = (Color)value;
                Invalidate();
                ValueChanged?.Invoke(this, Value);
            }
        }

        private readonly UIColorItem item = new UIColorItem();

        protected override void CreateInstance()
        {
            ItemForm = new UIDropDown(item);
        }

        private Color selectColor;

        [DefaultValue(typeof(Color), "80, 160, 255")]
        [Description("选中颜色"), Category("SunnyUI")]
        public Color Value
        {
            get => selectColor;
            set
            {
                selectColor = value;
                item.SelectedColor = value;
                Invalidate();
            }
        }

        protected override void OnPaintFore(Graphics g, System.Drawing.Drawing2D.GraphicsPath path)
        {
            base.OnPaintFore(g, path);
            if (Text.IsValid()) Text = "";
            var pathColor = g.CreateRoundedRectanglePath(new Rectangle(3, 3, Width - 32, Height - 7), 3, UICornerRadiusSides.All);
            g.FillPath(Value, pathColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DropDownStyle != UIDropDownStyle.DropDownList)
                DropDownStyle = UIDropDownStyle.DropDownList;
        }
    }
}