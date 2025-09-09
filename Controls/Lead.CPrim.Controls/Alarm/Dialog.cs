using Lead.CPrim.Controls;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.CustomControl;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using Lead.CPrim.TaskHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Global
{
    public class Dialog
    {
        #region Field
        ContinuousCumulativeStatisticsAlgorithm _algorithm;
        #endregion



        #region Prop
        /// <summary>
        /// 退出时间<br/>
        /// 单位（s）<br/>
        /// </summary>
        public int ExistTime { get; private set; }
        #endregion



        #region Ctor
        public Dialog()
        {
            ExistTime = 0;
        }
        public Dialog(int existTime) : this()
        {
            ExistTime = existTime;
        }
        public Dialog(ContinuousCumulativeStatisticsAlgorithm algorithm) : this()
        {
            _algorithm = algorithm.DeepCopyByJson();
            if(_algorithm == null)
            {
                _algorithm = new ContinuousCumulativeStatisticsAlgorithm();
            }
        }
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// 带提示灯弹窗，可直接使用<br/>
        /// 弹窗期间，线程处于阻塞状态<br/>
        /// Running状态<br/>
        /// 绿灯常亮<br/>
        /// 黄灯闪烁<br/>
        /// 蜂鸣器闪烁5s<br/>
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="btnOKName">确认名称</param>
        /// <param name="btnCancelName">取消名称</param>
        /// <returns></returns>
        public bool ShowMessageDialog(string message, string btnOKName, string btnCancelName = "")
        {
            AlarmHelper.LogAdd(message, LogLevel.Warn);

            // 切换状态机
            EventManager.SwitchStatus(SwitchStatus.RunningWithNotice);

            // 弹窗
            bool isOK = UIMessageDialog.ShowMessageDialog(message, ULocalize.AskTitle, !string.IsNullOrEmpty(btnCancelName), btnOKName, btnCancelName, ExistTime, UIStyle.Orange);

            // 还原状态机
            EventManager.SwitchStatus(SwitchStatus.ClrErr);

            return isOK;
        }

        /// <summary>
        /// 带提示灯弹窗，配合统计算法使用<br/>
        /// 构造方法必须传入连续累计算法<br/>
        /// 弹窗期间，线程处于阻塞状态<br/>
        /// 0：检查通过；<br/>
        /// 1：连续统计NG；<br/>
        /// 2：累计统计NG；<br/>
        /// 3：Algorithm为空；<br/>
        /// </summary>
        /// <param name="ok"></param>
        /// <returns></returns>
        public bool? ShowMessageDialog(bool isOK, string message, string btnOKName, string btnCancelName = "")
        {
            if (_algorithm == null)
            {
                return null;
            }

            if (isOK)
            {
                _algorithm.Check(isOK);
                return null;
            }

            int result = _algorithm.Check(isOK);
            if (result == 0)
            {
                ExistTime = 5;
                AlarmHelper.LogAdd(message, LogLevel.Warn);
                return null;
            }
            else if (result == 1)
            {
                ExistTime = 0;
                message = $"连续NG{_algorithm.ContinuousThreshold}次：{message}";
                return ShowMessageDialog(message, btnOKName, btnCancelName);
            }
            else if (result == 2)
            {
                ExistTime = 0;
                message = $"累计NG{_algorithm.CumulativeThreshold}次：{message}";
                return ShowMessageDialog(message, btnOKName, btnCancelName);
            }

            return null;
        }

        /// <summary>
        /// 定时弹窗<br/>
        /// 线程不处于阻塞状态<br/>
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="existTime">确认名称</param>
        /// <returns></returns>
        public static void ShowMessageDialogNoNotice(string message, int existTime = 5)
        {
            AlarmHelper.LogAdd(message, LogLevel.Warn);

            Application.OpenForms[0].Invoke((Action)delegate
            {
                UIMessageForm frm = new UIMessageForm();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowMessage(message, ULocalize.AskTitle, false, existTime, UIStyle.Orange);
                frm.ShowInTaskbar = false;
                frm.TopMost = true;
                frm.Show();
            });
        }
        #endregion
    }
}
