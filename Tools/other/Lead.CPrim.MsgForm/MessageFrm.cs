using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lead.CPrim.MsgForm
{
    public class MessageFrm : Form
    {
        #region API
        /// <summary>该函数能在显示与隐藏窗口时能产生特殊的效果</summary>
        /// <remarks>有两种类型的动画效果：滚动动画和滑动动画</remarks>
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指明动画持续的时间（以微秒计），完成一个动画的标准时间为200微妙</param>
        /// <param name="dwFlags">指明动画类型。这个参数可以是一个或多个下列标志的组合</param>
        /// <returns>如果函数成功，返回值为非零；如果函数失败，返回值为零
        /// <para>下列情况函数将失败</para>
        /// <para>窗口使用了窗口边界；窗口已经可见仍要显示窗口；窗口已经隐藏仍要隐藏窗口</para>
        /// <para>获得更多错误信息，请调用GetLastError函数</para></returns>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion



        #region Field
        /// <summary>1：自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略</summary>
        private const int AW_HOR_POSITIVE = 0x00000001;
        /// <summary>2：自右向左显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略</summary>
        private const int AW_HOR_NEGATIVE = 0x00000002;
        /// <summary>4：自上向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略</summary>
        private const int AW_VER_POSITIVE = 0x00000004;
        /// <summary>8：自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略</summary>
        private const int AW_VER_NEGATIVE = 0x00000008;
        /// <summary>16：若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展</summary>
        private const int AW_CENTER = 0x00000010;
        /// <summary>65536：隐藏窗口，缺省则显示窗口</summary>
        private const int AW_HIDE = 0x00010000;
        /// <summary>131072：激活窗口。在使用AW_HIDE标志后不要使用这个标志</summary>
        private const int AW_ACTIVE = 0x00020000;
        /// <summary>262144：滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略</summary>
        private const int AW_SLIDE = 0x00040000;
        /// <summary>524288：使用淡出效果。只有当hwnd为顶层窗口的时候才可以使用这个标志</summary>
        private const int AW_BLEND = 0x00080000;


        /// <summary>消息框集合</summary>
        private static List<MessageFrm> FormsPopup = new List<MessageFrm>();
        private Label lblNotice;

        /// <summary>定时器</summary>
        private Timer time = null;
        #endregion



        #region Prop
        /// <summary>消息颜色</summary>
        private Color InfoColor { get; set; } = Color.DimGray;
        /// <summary>消息框显示时间</summary>
        private int InfoExistTime { get; set; } = -1;
        /// <summary>消息内容</summary>
        private string InfoText { get; set; } = "This is a test message";
        #endregion



        #region Ctor
        private MessageFrm()
        {
            InitializeComponent();
        }
        private MessageFrm(string infotext) : this()
        {
            InfoText = infotext;
        }
        private MessageFrm(string infotext, Color infocolor) : this(infotext)
        {
            InfoColor = infocolor;
        }
        private MessageFrm(string infotext, Color infocolor, int existTime) : this(infotext, infocolor)
        {
            InfoExistTime = existTime;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void FormPopup_Load(object sender, EventArgs e)
        {
            label1.Text = InfoText;
            label1.ForeColor = InfoColor;
            label2.Text = "我已知晓";

            int x = (Screen.PrimaryScreen.WorkingArea.Right - Width) / 2;
            int y = Screen.PrimaryScreen.WorkingArea.Top;

            AddNewForm(this);

            Location = new Point(x, y);
            AnimateWindow(Handle, 1000, AW_SLIDE + AW_VER_POSITIVE);
            TopMost = true;

            if (InfoExistTime <= 500)
            {
                return;
            }

            time = new Timer
            {
                Interval = InfoExistTime
            };
            time.Tick += FormDispose;
            time.Start();
        }
        /// <summary>Paint事件</summary>
        private void FormPopup_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.SkyBlue, new Rectangle(0, 0, Width - 1, 30));
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            //g.DrawString("消息提示！", label2.Font, Brushes.DimGray, new Rectangle(5, 0, Width - 1, 30), sf);
            g.DrawRectangle(Pens.DimGray, 0, 0, Width - 1, Height - 1);
        }
        /// <summary>Closing事件</summary>
        private void FormPopup_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ResetLocation(this);
                FormsPopup.Remove(this);

                if (InfoExistTime <= 500)
                {
                    return;
                }

                time.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>关闭</summary>
        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>当鼠标进入控件可见部分时发生</summary>
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            SoftAnimation.BeginBackcolorAnimation(label2, Color.Tomato, 100);
        }
        /// <summary>当鼠标离开控件可见部分时发生</summary>
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            SoftAnimation.BeginBackcolorAnimation(label2, Color.MistyRose, 100);
        }
        #endregion



        #region Others
        /// <summary>集合增加消息框时对已有消息框向下布局</summary>
        private void LocationDownMove()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(LocationDownMove));
            }
            else
            {
                Location = new Point(Location.X, Location.Y + Height);
            }
        }
        /// <summary>集合增加消息框</summary>
        /// <param name="form">消息框</param>
        private static void AddNewForm(MessageFrm form)
        {
            try
            {
                foreach (MessageFrm i in FormsPopup)
                {
                    i.LocationDownMove();
                }
                FormsPopup.Add(form);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>消息框集合重新排序</summary>
        /// <param name="index">序号</param>
        public void LocationUpMove()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(LocationUpMove));
            }
            else
            {
                Location = new Point(Location.X, Location.Y - Height);
            }
        }
        /// <summary>删除指定消息框后对消息框集合进行重新排列</summary>
        private static void ResetLocation(MessageFrm frm)
        {
            try
            {
                int index = -1;
                for (int i = 0; i < FormsPopup.Count; i++)
                {
                    if (FormsPopup[i] == frm)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1 || index == 0)
                {
                    return;
                }

                for (int i = 0; i < index; i++)
                {
                    FormsPopup[i].LocationUpMove();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void FormDispose(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(FormDispose), sender, e);
                return;
            }
            time.Dispose();
            AnimateWindow(Handle, 1000, AW_SLIDE + AW_BLEND + AW_HIDE);
            if (!this.IsDisposed)
            {
                Close();
            }
        }
        #endregion



        #region 外部调用
        /// <summary>弹窗（消息+颜色+时间）</summary>
        /// <param name="infotext">消息</param>
        /// <param name="color">颜色</param>
        /// <param name="tims">时间</param>
        /// <param name="floor">0：不显示命名空间及类；非0：显示指定层级的命名空间及类</param>
        public static void Show(string infotext, Color color, int tims = 0, int floor = 0)
        {
            if (floor != 0)
            {
                DebugLog.WriteLog(ref infotext, floor);
            }
            MessageFrm frm = new MessageFrm(infotext, color, tims);
            frm.Show();
        }
        #endregion








        #region System
        private IContainer components = null;

        private Label label2;

        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Moccasin;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(385, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "关闭";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 66);
            this.label1.TabIndex = 2;
            this.label1.Text = "这是一条测试消息";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblNotice.Location = new System.Drawing.Point(16, 6);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(69, 20);
            this.lblNotice.TabIndex = 3;
            this.lblNotice.Text = "消息提示";
            // 
            // MessageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(500, 110);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 110);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 110);
            this.Name = "MessageFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "消息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPopup_Closing);
            this.Load += new System.EventHandler(this.FormPopup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPopup_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
