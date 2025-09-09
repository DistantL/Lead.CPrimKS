using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.Controls
{
    public partial class GDIFrm : UIUserControl
    {
        public GDIFrm()
        {
            InitializeComponent();
        }

        private void btnGradientColors_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                string text = txtCount.Text;
                UIColorPicker[] cps = new UIColorPicker[] { uiColorPicker1, uiColorPicker2, uiColorPicker3, uiColorPicker4, uiColorPicker5, uiColorPicker6, uiColorPicker7, uiColorPicker8, uiColorPicker9, uiColorPicker10 };

                if (text.IsNullOrEmpty())
                {
                    throw new Exception("渐变数量为空");
                }

                if (!int.TryParse(text, out count))
                {
                    throw new Exception("渐变数量值无效");
                }

                for (int i = 0; i < cps.Length; i++)
                {
                    cps[i].Value = Color.FromArgb(80, 160, 255);
                }

                count = Math.Max(2, count);
                count = Math.Min(10, count);

                Color start = cpStart.Value;
                Color end = cpEnd.Value;
                Color[] colors = start.GradientColors(end, count);
                for (int i = 0; i < count; i++)
                {
                    cps[i].Value = colors[i];
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog($"生成渐变色失败：{ex.Message}");
            }
        }
    }
}
