using Lead.CPrim.ProxyTools.Authority.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public class DialogForUIMessageFormOnlyOne
    {
        #region Field
        /// <summary>
        /// 线程安全的队列存储弹窗请求
        /// </summary>
        private readonly ConcurrentQueue<DialogRequest> _dialogQueue = new ConcurrentQueue<DialogRequest>();

        /// <summary>
        /// True：弹窗正在显示<br/>
        /// False：无弹窗显示<br/>
        /// </summary>
        private bool _isDialogShowing;

        private static DialogForUIMessageFormOnlyOne _instance = new DialogForUIMessageFormOnlyOne();
        #endregion



        #region Prop
        public static DialogForUIMessageFormOnlyOne Instance => _instance;
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// 添加弹窗到队列
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callback"></param>
        public void EnqueueDialog(string message, Action<bool> callback = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            if (!_isDialogShowing && _dialogQueue.IsEmpty)
            {
                _dialogQueue.Enqueue(
                    new DialogRequest
                    {
                        Message = message,
                        Callback = callback
                    });

                TryShowNextDialog();
            }
        }
        #endregion



        #region MethodInternalUsing
        /// <summary>
        /// 尝试显示下一个弹窗
        /// </summary>
        void TryShowNextDialog()
        {
            // 确保在主线程执行
            if (Application.OpenForms.Count > 0 && Application.OpenForms[0].InvokeRequired)
            {
                Application.OpenForms[0].BeginInvoke(new Action(TryShowNextDialog));
                return;
            }

            // 如果已有弹窗显示或队列为空，则返回
            if (_isDialogShowing || _dialogQueue.IsEmpty)
            {
                return;
            }

            // 标记开始显示
            _isDialogShowing = true;

            if (_dialogQueue.TryDequeue(out DialogRequest request))
            {
                // 显示弹窗
                var result = UIMessageDialog.ShowMessageDialog(request.Message, ULocalize.AskTitle, false, UIStyle.Red);

                // 消息通知
                request.Callback?.Invoke(result);

                // 标记结束显示
                _isDialogShowing = false;

                // 显示下一个
                TryShowNextDialog();
            }
            else
            {
                _isDialogShowing = false;
            }
        }
        #endregion



        #region class
        /// <summary>
        /// 弹窗请求结构
        /// </summary>
        private class DialogRequest
        {
            public string Message { get; set; }
            public Action<bool> Callback { get; set; }
        }
        #endregion
    }
}
