/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: HistorgramControl.cs
 * Author: Victor
 * Description: 用来显示单项直方图
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、代码风格重新布局以及增加备注
 * 
 * * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220710
 * 2、方法内部增加日志
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowHistorgram.FaiAnaylise;
using System;
using System.Windows.Forms;

namespace Lead.CPrim.ShowHistorgram.Controls
{
    public partial class HistorgramControl : UserControl
    {
        #region Field
        public FaiCount FaiCount;
        #endregion



        #region Ctor
        public HistorgramControl()
        {
            InitializeComponent();
        }
        public HistorgramControl(FaiCount faiCfg):this()
        {
            FaiCount = faiCfg;
        } 
        #endregion



        #region Button_Event
        /// <summary>查看大图</summary>
        private void 查看大图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                FaiCount.DrawMapString();
                var frm = new BigPicture(FaiCount.bitmapString)
                {
                    Text = FaiCount.FaiName,
                    Size = FaiCount.bitmapString.Size,
                };
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                FaiCount._show.LogAdd($"查看大图失败：{ex.Message}", LogLevel.Warn);
            }
        }
        /// <summary>保存图片</summary>
        private void 保存图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FaiCount.SavePic();
                FaiCount._show.LogAdd("保存图片成功", LogLevel.Trace);
            }
            catch (Exception ex)
            {
                FaiCount._show.LogAdd($"保存图片失败：{ex.Message}", LogLevel.Warn, 0, true);
            }
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        public void RefreshUI()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)RefreshUI);
            }
            else
            {
                try
                {
                    FaiCount.DrawMap();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = FaiCount.bitmap;
                }
                catch (Exception ex)
                {
                    FaiCount._show.LogAdd($"绘小图失败：{ex.Message}", LogLevel.Warn);
                }
            }
        }
        #endregion
    }
}