/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: BigPicture.cs
 * Author: Victor
 * Description: 用来直方图大图显示
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、图片显示模式由StretchImage变更为Zoom
******************************************************************************/

using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.ShowHistorgram
{
    public partial class BigPicture : Form
    {
        public BigPicture(Bitmap bp)
        {
            InitializeComponent();
            pictureBox1.Image = bp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}