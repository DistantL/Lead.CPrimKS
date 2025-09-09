using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ShowCapacityOfProduction.Controls
{
    public partial class OperateInstruction : UIUserControl
    {
        #region Field
        /// <summary>运行提示栏闪烁标志</summary>
        private bool _isTwinkle = true;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public OperateInstruction()
        {
            InitializeComponent();
            SetStyleFlags();
        }
        #endregion



        #region System_Event
        private void OperateInstruction_Load(object sender, EventArgs e)
        {
            var task = new Task(RunLoop);
            task.Start();
        } 
        #endregion



        #region Button_Event
        /// <summary>运行提示栏双击事件</summary>
        private void labOperate_DoubleClick(object sender, EventArgs e)
        {
            _isTwinkle = !_isTwinkle;
        }
        #endregion



        #region Others
        /// <summary>RunLoop方法，控制运行提示栏闪烁</summary>
        private void RunLoop()
        {
            while (true)
            {
                if (Created && IsHandleCreated)
                {
                    Invoke(new Action(() =>
                    {
                        //string text = labOperate.Text.Trim();
                        //if(string.IsNullOrEmpty(text) && text.Length < 2)
                        //{
                        //    labOperate.Text = _title;
                        //    return;
                        //}
                        //labOperate.Text = text.Substring(1);

                        if (_isTwinkle)
                            labOperate.ForeColor = labOperate.ForeColor == Color.Lime ? Color.Yellow : Color.Lime;
                        else if (labOperate.ForeColor != Color.Lime)
                            labOperate.ForeColor = Color.Lime;
                    }));
                }
                Application.DoEvents();
                Thread.Sleep(500);
            }
        }
        /// <summary>运行状态栏更新</summary>
        /// <param name="sta">更新内容</param>
        /// <param name="color">更新颜色</param>
        public void ChangeState(string sta, Color color)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, Color>(ChangeState), sta, color);
            }
            else
            {
                labRunningSta.Text = sta;
                labRunningSta.ForeColor = color;
            }
        }
        /// <summary>运行提示栏更新</summary>
        /// <param name="msg">更新内容</param>
        /// <param name="IsTwinkle">更新标志</param>
        public void ShowOperaInfo(string msg, bool IsTwinkle)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, bool>(ShowOperaInfo), msg, IsTwinkle);
            }
            else
            {
                _isTwinkle = IsTwinkle;
                labOperate.Text = msg;
            }  
        }
        /// <summary>运行模式更新</summary>
        /// <param name="mode">运行模式模式</param>
        public void ShowOperaMode(string mode)
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action<string>(ShowOperaMode), mode);
            }
            else
            {
                lbState.Text = mode;
            }
        }
        #endregion
    }
}