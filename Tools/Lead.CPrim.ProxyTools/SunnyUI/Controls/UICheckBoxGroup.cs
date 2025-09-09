/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UICheckBoxGroup.cs
 * Author: Victor
 * Description: 多选框组
 * CreateTime: 2020-01-01
 * Inherit：UIPanel
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-04-19: V2.2.3 增加单元
 * 2020-04-25: V2.2.4 更新主题配置类
 * 2020-07-03: V2.2.6 修正调整ItemSize无效的Bug
 * 2020-07-04: V2.2.6 可以设置初始选中值
 * 
 * <3.3.23.0101><Victor><20230111>
 * 1、初版1.0
******************************************************************************/



using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Controls
{
    /// <summary>
    /// 多选框组
    /// </summary>
    [DefaultProperty("Items")]
    [DefaultEvent("ValueChanged")]
    public class UICheckBoxGroup : UIGroupBox
    {
        #region EventHandle & Event
        /// <summary>值切换委托</summary>
        /// <param name="sender">sender</param>
        /// <param name="index">索引</param>
        /// <param name="text">文字</param>
        /// <param name="isChecked">是否选中</param>
        public delegate void OnValueChanged(object sender, int index, string text, bool isChecked);
        /// <summary>值切换事件</summary>
        public event OnValueChanged ValueChanged;
        #endregion



        #region Field
        private readonly List<UICheckBox> boxes = new List<UICheckBox>();
        private bool multiChange;
        #endregion



        #region Prop
        private readonly UIObjectCollection items = new UIObjectCollection();
        /// <summary>获取该多选框组中项的集合</summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false)]
        [Description("获取该多选框组中项的集合"), Category("SunnyUI")]
        public UIObjectCollection Items => items;

        [Browsable(false)]
        public List<int> SelectedIndexes
        {
            get
            {
                List<int> indexes = new List<int>();

                for (int i = 0; i < boxes.Count; i++)
                {
                    if (boxes[i].Checked)
                        indexes.Add(i);
                }

                return indexes;
            }
            set
            {
                if (boxes.Count != Items.Count)
                {
                    CreateBoxes();
                }

                foreach (int i in value)
                {
                    if (i >= 0 && i < boxes.Count)
                    {
                        boxes[i].Checked = true;
                    }
                }
            }
        }

        [Browsable(false)]
        public List<object> SelectedItems
        {
            get
            {
                List<object> objects = new List<object>();

                for (int i = 0; i < boxes.Count; i++)
                {
                    if (boxes[i].Checked)
                        objects.Add(Items[i]);
                }

                return objects;
            }
        }

        /// <summary>显示列的个数</summary>
        private int columnCount = 1;
        [DefaultValue(1)]
        [Description("显示列的个数"), Category("SunnyUI")]
        public int ColumnCount
        {
            get => columnCount;
            set
            {
                columnCount = value;
                Invalidate();
            }
        }

        /// <summary>显示项的大小</summary>
        private Size _itemSize = new Size(150, 35);
        [DefaultValue(typeof(Size), "150, 35")]
        [Description("显示项的大小"), Category("SunnyUI")]
        public Size ItemSize
        {
            get => _itemSize;
            set
            {
                _itemSize = value;
                Invalidate();
            }
        }

        /// <summary>显示项的起始位置</summary>
        private Point startPos = new Point(12, 12);
        [DefaultValue(typeof(Point), "12, 12")]
        [Description("显示项的起始位置"), Category("SunnyUI")]
        public Point StartPos
        {
            get => startPos;
            set
            {
                startPos = value;
                Invalidate();
            }
        }

        /// <summary>显示项列之间的间隔</summary>
        public int columnInterval;
        [DefaultValue(0)]
        [Description("显示项列之间的间隔"), Category("SunnyUI")]
        public int ColumnInterval
        {
            get => columnInterval;
            set
            {
                columnInterval = value;
                Invalidate();
            }
        }

        /// <summary>显示项行之间的间隔</summary>
        private int rowInterval;
        [DefaultValue(0)]
        [Description("显示项行之间的间隔"), Category("SunnyUI")]
        public int RowInterval
        {
            get => rowInterval;
            set
            {
                rowInterval = value;
                Invalidate();
            }
        }

        /// <summary>多选模式</summary>
        private bool multiSelectionMode;
        [DefaultValue(false)]
        [Description("true：多选模式；false：单选模式"), Category("SunnyUI")]
        public bool MultiSelectionMode
        {
            get => multiSelectionMode;
            set
            {
                multiSelectionMode = value;
                Invalidate();
            }
        }
        #endregion



        #region Ctor
        public UICheckBoxGroup()
        {
            items.CountChange += Items_CountChange;
        }
        #endregion



        #region System_Event
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            CreateBoxes();

            if (Items.Count == 0) return;
            int startX = StartPos.X;
            int startY = TitleTop + StartPos.Y;
            for (int i = 0; i < Items.Count; i++)
            {
                boxes[i].Text = Items[i].ToString();

                int rowIndex = i / ColumnCount;
                int columnIndex = i % ColumnCount;

                boxes[i].Left = startX + ItemSize.Width * columnIndex + ColumnInterval * columnIndex;
                boxes[i].Top = startY + ItemSize.Height * rowIndex + RowInterval * rowIndex;
                boxes[i].Size = ItemSize;
                boxes[i].Show();
            }
        }
        /// <summary>析构事件</summary>
        ~UICheckBoxGroup()
        {
            ClearBoxes();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>获取index的选中状态</summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool this[int index]
        {
            get => GetItemCheckState(index);
            set => SetItemCheckState(index, value);
        }
        /// <summary>全部清除</summary>
        public void Clear()
        {
            Items.Clear();
            ClearBoxes();
            Invalidate();
        }
        /// <summary>设置index的状态</summary>
        /// <param name="index"></param>
        /// <param name="isChecked"></param>
        public void SetItemCheckState(int index, bool isChecked)
        {
            if (index >= 0 && index < boxes.Count)
            {
                boxes[index].Checked = isChecked;
            }
        }
        /// <summary>获取index的状态</summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetItemCheckState(int index)
        {
            if (index >= 0 && index < items.Count)
                return boxes[index].Checked;

            return false;
        }
        /// <summary>全部选择</summary>
        public void SelectAll()
        {
            multiChange = true;
            foreach (var box in boxes)
            {
                box.Checked = true;
            }

            multiChange = false;
        }

        /// <summary>全部不选</summary>
        public void UnSelectAll()
        {
            multiChange = true;
            foreach (var box in boxes)
            {
                box.Checked = false;
            }

            multiChange = false;
        }

        /// <summary>反转选择</summary>
        public void ReverseSelected()
        {
            multiChange = true;
            foreach (var box in boxes)
            {
                box.Checked = !box.Checked;
            }

            multiChange = false;
        }
        #endregion



        #region Method_InternalUsing
        private void Items_CountChange(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void ClearBoxes()
        {
            foreach (var box in boxes)
            {
                box.Hide();
                box.Dispose();
            }

            boxes.Clear();
        }
        private void CreateBoxes()
        {
            if (Items.Count != boxes.Count)
            {
                ClearBoxes();

                for (int i = 0; i < Items.Count; i++)
                {
                    UICheckBox box = new UICheckBox();
                    box.BackColor = Color.Transparent;
                    box.Font = Font;
                    box.Parent = this;
                    box.Tag = i;
                    box.Style = Style;
                    box.IsScaled = IsScaled;
                    box.ValueChanged += Box_ValueChanged;
                    boxes.Add(box);
                }
            }
        }
        private void Box_ValueChanged(object sender, bool value)
        {
            UICheckBox checkBox = (UICheckBox)sender;

            if (!multiChange)
            {
                ValueChanged?.Invoke(this, checkBox.Tag.ToString().ToInt(), checkBox.Text, checkBox.Checked);
            }
            if (!MultiSelectionMode && value)
            {
                foreach (var box in boxes)
                {
                    if(box.Text != checkBox.Text)
                    {
                        box.Checked = false;
                    }
                }
            }
        }
        #endregion
    }
}