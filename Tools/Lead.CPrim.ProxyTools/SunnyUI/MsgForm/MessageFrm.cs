using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.CustomControl
{
    public partial class MessageFrm : Form
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
        [DllImport("User32")]
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

        /// <summary>定时器</summary>
        private Timer time = null;
        #endregion



        #region Prop
        /// <summary>
        /// 提醒类型
        /// </summary>
        private UINotifierType NotifierType { get; set; }

        /// <summary>
        /// 消息框显示时间
        /// </summary>
        private int InfoExistTime { get; set; } = -1;

        /// <summary>
        /// 消息内容
        /// </summary>
        private string InfoText { get; set; } = "This is a test message";
        #endregion



        #region Ctor
        public MessageFrm()
        {
            InitializeComponent();
        }
        public MessageFrm(string infotext) : this()
        {
            InfoText = infotext;
        }
        public MessageFrm(string infotext, UINotifierType type) : this(infotext)
        {
            NotifierType = type;
        }
        public MessageFrm(string infotext, UINotifierType type, int existTime) : this(infotext, type)
        {
            InfoExistTime = existTime;

            lblInfo.Text = InfoText;
            lblInfo.BackColor = Color.Transparent;

            btnSymbol.BackColor = Color.Transparent;
            btnSymbol.RectColor = Color.Transparent;

            switch (NotifierType)
            {
                case UINotifierType.INFO:
                    break;

                case UINotifierType.WARNING:
                    btnSymbol.Symbol = 61553;
                    BackColor = Color.Olive;
                    break;

                case UINotifierType.ERROR:
                    btnSymbol.Symbol = 61453;
                    BackColor = Color.Brown;
                    break;

                case UINotifierType.OK:
                default:
                    btnSymbol.Symbol = 61452;
                    BackColor = Color.FromArgb(26, 183, 109);
                    break;
            }
        }
        #endregion



        #region System_Event
        private void FormPopup_Load(object sender, EventArgs e)
        {
            AddNewForm(this);
            DynamicUIShow.Show(this, FormShowAlignment.TopCenter, new Padding(0, 0, 0, 0));
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
            finally
            {
                time = null;
            }
        }
        #endregion



        #region Event_Button
        private void btnSymbol_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// 集合增加消息框时对已有消息框向下布局
        /// </summary>
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

        /// <summary>
        /// 消息框集合重新排序
        /// </summary>
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

        /// <summary>
        /// 集合增加消息框
        /// </summary>
        /// <param name="form">消息框</param>
        private void AddNewForm(MessageFrm form)
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

        /// <summary>
        /// 删除指定消息框后对消息框集合进行重新排列
        /// </summary>
        private void ResetLocation(MessageFrm frm)
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
                BeginInvoke(new Action<object, EventArgs>(FormDispose), sender, e);
            }
            else
            {
                try
                {
                    AnimateWindow(Handle, 300, AW_SLIDE + AW_BLEND + AW_HIDE);
                    if (!IsDisposed)
                    {
                        Close();
                    }
                }
                finally
                {
                    Dispose();
                }
            }
        }
        #endregion
    }
}
