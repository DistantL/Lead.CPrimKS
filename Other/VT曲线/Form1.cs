using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VT曲线
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double s,v,a,v1;
            double t1, t2, t3,t;
            double s1, s2, s3;
            ///方式1:用泛型委托的方法来调用
            //Action<object, EventArgs> action = Form1_Paint;
            //action.Invoke(sender,  e);

            ///方式2: pictureBox1上绘制--最小化后再恢复时会消失
            //Graphics graphics = pictureBox1.CreateGraphics();  //这里的画板是由pictureBox1提供的.
            //Pen pen = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为2的画笔

            ///方式3: 位图上绘制--最小化后再恢复时不会消失
            Bitmap bmp = new Bitmap(this.pictureBox1.ClientRectangle.Width, this.pictureBox1.ClientRectangle.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为2的画笔
            SolidBrush brush = new SolidBrush(Color.Red); //定义了一个红色的单色画刷

            try
            {
                #region //数据计算
                s = Convert.ToDouble(textBox1_s.Text);
                a = Convert.ToDouble(textBox2_a.Text);
                v = Convert.ToDouble(textBox3_v.Text);
                s1 = (v * v) / (2 * a);
                s3 = (v * v) / (2 * a);
                if ((s1 + s3) < s)
                {
                    t1 = v / a;
                    t3 = v / a;
                    t2 = (s - s1 - s3) / v;
                    s2 = v * t2;
                    v1 = v;
                    t = t1 + t2 + t3;
                }
                else
                {
                    t1 = Convert.ToSingle(Math.Sqrt(s / a));
                    t3 = t1;
                    t2 = 0;
                    s1 = a * t1 * t1 / 2;
                    s2 = 0;
                    s3 = s1;
                    v1 = a * t1;
                    t = t1 + t2 + t3;
                }
                textBox4_t1.Text = t1.ToString("0.000");
                textBox5_t2.Text = t2.ToString("0.000");
                textBox6_t3.Text = t3.ToString("0.000");
                textBox7_t.Text = t.ToString("0.000");
                textBox8_s1.Text = s1.ToString("0.000");
                textBox9_s2.Text = s2.ToString("0.000");
                textBox10_s3.Text = s3.ToString("0.000");
                #endregion

                #region  //绘图
                int offsetX = 10;
                int offsetY = 20;
                double kT = ((pictureBox1.Width) * 0.7) / t;      //X轴比例
                double kV = ((pictureBox1.Height) * 0.7) / v1;    //Y轴比例

                int point1X = offsetX;
                int point1Y = pictureBox1.Height - offsetY;
                int point2X = Convert.ToInt32(t1 * kT + offsetX);
                int point2Y = pictureBox1.Height - Convert.ToInt32(v1 * kV + offsetY);
                int point3X = Convert.ToInt32((t1 + t2) * kT + offsetX);
                int point3Y = pictureBox1.Height - Convert.ToInt32(v1 * kV + offsetY);
                int point4X = Convert.ToInt32((t1 + t2 + t3) * kT + offsetX);
                int point4Y = pictureBox1.Height - Convert.ToInt32(0 * kV + offsetY);

                graphics.Clear(Color.White);//清空画图区域

                //画坐标轴
                pen.Color = Color.Black;
                pen.DashStyle = DashStyle.Solid;
                pen.EndCap = LineCap.Triangle;//箭头
                graphics.DrawLine(pen, point1X, point1Y, pictureBox1.Width - point1X, point1Y);   //X轴
                graphics.DrawLine(pen, point1X, point1Y, point1X, pictureBox1.Height - point1Y); //Y轴

                //画v-t曲线
                pen.Color = Color.Blue;
                pen.DashStyle = DashStyle.Solid;//实线
                graphics.DrawLine(pen, point1X, point1Y, point2X, point2Y);//加速段
                graphics.DrawLine(pen, point2X, point2Y, point3X, point3Y);//匀速段
                graphics.DrawLine(pen, point3X, point3Y, point4X, point4Y);//减速段

                //画辅助虚线
                pen.Color = Color.YellowGreen;
                pen.DashStyle = DashStyle.Dot;//虚线
                graphics.DrawLine(pen, point2X, point2Y, point2X, point1Y);
                graphics.DrawLine(pen, point3X, point3Y, point3X, point1Y);
                graphics.DrawLine(pen, point2X, point2Y, point1X, point2Y);

                //文字标注
                graphics.DrawString("t1=" + t1.ToString("0.000"), new Font("宋体", 8), brush, new PointF(point1X + (point2X - point1X) / 2, point1Y));
                graphics.DrawString("t2=" + t2.ToString("0.000"), new Font("宋体", 8), brush, new PointF(point2X + (point3X - point2X) / 2, point1Y));
                graphics.DrawString("t3=" + t3.ToString("0.000"), new Font("宋体", 8), brush, new PointF(point3X + (point4X - point3X) / 2, point1Y));
                graphics.DrawString("v1=" + Convert.ToDouble(v1).ToString("0.00"), new Font("宋体", 8), brush, new PointF(point1X, point2Y));
                graphics.DrawString("单位：S", new Font("宋体", 10), brush, new PointF(point4X, point1Y - 20));
                graphics.DrawString("单位：mm/s", new Font("宋体", 10), brush, new PointF(point1X, point2Y - 20));

                this.pictureBox1.Image = bmp;//采用方式3时必须刷新，否则不显示
                #endregion
            }
            catch (Exception)
            {
                //异常捕捉
                MessageBox.Show("数据输入格式不正确,请重新输入！");
                textBox4_t1.Text = "";
                textBox5_t2.Text = "";
                textBox6_t3.Text = "";
                textBox8_s1.Text = "";
                textBox9_s2.Text = "";
                textBox10_s3.Text = "";
            }
            finally
            {
                //释放资源
                graphics.Dispose();
                brush.Dispose();
                pen.Dispose();
            }
        }
        private void Form1_Paint(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics(); //创建画板,这里的画板是由Form提供的.
            Pen p = new Pen(Color.Blue, 2);//定义了一个蓝色,宽度为的画笔
            g.DrawLine(p, 10, 10, 100, 100);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            g.DrawRectangle(p, 10, 10, 100, 100);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            g.DrawEllipse(p, 10, 10, 100, 100);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为

            /*
                Pen  p = new  Pen(Color.Blue, 5);//设置笔的粗细为,颜色为蓝色
                Graphics  g = this.CreateGraphics();

                //画虚线
                p.DashStyle = DashStyle.Dot;//定义虚线的样式为点
                g.DrawLine(p, 10, 10, 200, 10);

                //自定义虚线
                p.DashPattern = new  float[] { 2, 1 };//设置短划线和空白部分的数组
                g.DrawLine(p, 10, 20, 200, 20);

                //画箭头,只对不封闭曲线有用
                p.DashStyle = DashStyle.Solid;//恢复实线
                p.EndCap = LineCap.ArrowAnchor;//定义线尾的样式为箭头
                g.DrawLine(p, 10, 30, 200, 30);

                g.Dispose();
                p.Dispose();
             */

            /*
                Graphics g = this.CreateGraphics();
                Rectangle rect = new Rectangle(10, 10, 50, 50);//定义矩形,参数为起点横纵坐标以及其长和宽

                //单色填充
                SolidBrush b1 = new SolidBrush(Color.Blue);//定义单色画刷          
                g.FillRectangle(b1, rect);//填充这个矩形

                //字符串
                g.DrawString("字符串", new Font("宋体", 10), b1, new PointF(90, 10));

                //用图片填充
                TextureBrush b2 = new TextureBrush(Image.FromFile(@"e:\picture\1.jpg"));
                rect.Location = new Point(10, 70);//更改这个矩形的起点坐标
                rect.Width = 200;//更改这个矩形的宽来
                rect.Height = 200;//更改这个矩形的高
                g.FillRectangle(b2, rect);

                //用渐变色填充
                rect.Location = new Point(10, 290);
                LinearGradientBrush b3 = new  LinearGradientBrush(rect, Color.Yellow , Color.Black , LinearGradientMode.Horizontal);
                g.FillRectangle(b3, rect);	
            */
        }

        #region 计时器
        private long t = 0;//声明一个长整型变量：t，用于获取毫秒，
        Stopwatch stopWatch = new Stopwatch();
        //计时函数
        public string GetAllTime(long time)
        {
            int ts = (int)((time * 1) / 1000);  // 转化为总秒
            int f = (int)((time * 1) % 1000);   // 毫秒   
            int s = ts % 60;    // 秒 
            int m = s / 60;     // 分
            int h = m / 60;     // 时
            string str_f = (f < 10) ? ("00"+f.ToString()) 
                                    : ((f < 100) ? ("0" + f.ToString()) : (f.ToString()));//毫秒格式000
            string str_s = (s < 10) ? ("0"+s.ToString()) : (s.ToString());  //秒格式00
            string str_m = (m < 10) ? ("0"+m.ToString()) : (m.ToString());//分格式00
            string str_h = (h < 10) ? ("0"+h.ToString()) : (h.ToString());  //时格式00
            return str_h + ":" + str_m + ":" + str_s + "." + str_f; //返回 hh:mm:ss.ff   
        }
        //时钟控件事件
        void timer1_Tick(object sender, System.EventArgs e)
        {
            //t = t + 1;//得到总的毫秒数   计时不准！
            t = stopWatch.ElapsedMilliseconds;
            this.label11.Text = GetAllTime(t);
        }
        //开始计时按钮单击事件
        void btnStar_Click(object sender, System.EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                this.btnStar.Text = "停止计时";
                this.btnStar.BackColor = Color.Red;
                this.timer1.Enabled = true;
                this.stopWatch.Start();
            }
            else
            {
                this.btnStar.Text = "开始计时";
                this.btnStar.BackColor = Color.Green;
                this.timer1.Enabled = false;
                this.stopWatch.Stop();
            }
        }
        //计时器清零
        void btnClear_Click(object sender, System.EventArgs e)
        {
            t = 0;
            //如果正在计时，则先停止再清零，否则直接清零
            if (this.timer1.Enabled == true)
            {
                this.btnStar_Click(sender, e);
                label11.Text = GetAllTime(t);
            }
            else
            {
                label11.Text = GetAllTime(t);
            }
        }
        #endregion

        #region 实现自定义控件随窗口大小改变
        private float X, Y;
        //获得控件的长度、宽度、位置、字体大小的数据
        private void setTag(Control cons)//Control类，定义控件的基类
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;//获取或设置包含有关控件的数据的对象
                if (con.Controls.Count > 0)
                    setTag(con);//递归算法
            }
        }

        private void setControls(float newx, float newy, Control cons)//实现控件以及字体的缩放
        {
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * newy;
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);//递归
                }
            }
        }

        private void MyForm_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;//当前宽度与变化前宽度之比
            float newy = this.Height / Y;//当前高度与变化前宽度之比
            setControls(newx, newy, this);
            this.Text = (this.Text).Split(':')[0] + ":"+this.Width.ToString() + " " + this.Height.ToString();  //窗体标题显示长度和宽度
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Resize += new EventHandler(MyForm_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.timer1.Interval = 1;
        }
        #endregion

    }
}
