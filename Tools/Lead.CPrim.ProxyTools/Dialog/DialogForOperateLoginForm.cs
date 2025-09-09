using Lead.CPrim.ProxyTools.Authority.Forms;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public class DialogForOperateLoginForm
    {
        #region Field
        /// <summary>
        /// 线程安全的队列存储弹窗请求
        /// </summary>
        readonly ConcurrentQueue<DialogRequest> _dialogQueue = new ConcurrentQueue<DialogRequest>();

        /// <summary>
        /// True：弹窗正在显示<br/>
        /// False：无弹窗显示<br/>
        /// </summary>
        bool _isDialogShowing;

        /// <summary>
        /// 当前弹窗的标题
        /// </summary>
        string currentDialogTitle = "";

        static DialogForOperateLoginForm _instance = new DialogForOperateLoginForm();
        #endregion



        #region Prop
        public static DialogForOperateLoginForm Instance => _instance;
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// 添加弹窗到队列
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callback"></param>
        /// <param name="isChangeLightState"></param>
        public void EnqueueDialog(string message, Action<bool> callback = null, bool isChangeLightState = false)
        {
            // 防止已经弹出还要加进队列的弹窗
            // 方案一：仅解决了同一个弹窗的后续弹窗，无法解决不同弹窗之间的后续弹窗
            //if (_isDialogShowing && currentDialogTitle.Equals(message))
            //{
            //    return;
            //}

            // 方案二：
            // q.Message == message：解决已经添加
            // message == currentDialogTitle：解决正在弹出
            // 注意事项：
            var queue = _dialogQueue.FirstOrDefault(q => q.Message == message);
            if (queue != null || message == currentDialogTitle)
            {
                return;
            }

            _dialogQueue.Enqueue(
                new DialogRequest
                {
                    IsChangeLightState = isChangeLightState,
                    Message = message,
                    Callback = callback
                });

            TryShowNextDialog();
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
                Application.OpenForms[0].Invoke(new Action(TryShowNextDialog));
                return;
            }

            // 如果已有弹窗显示或队列为空，则返回
            if (_isDialogShowing)
            {
                return;
            }
            if (_dialogQueue.IsEmpty)
            {
                currentDialogTitle = "";
                return;
            }

            // 标记开始显示
            _isDialogShowing = true;

            if (_dialogQueue.TryDequeue(out DialogRequest request))
            {
                currentDialogTitle = request.Message;

                // 创建弹窗
                var dialog = new OperateLoginForm();
                dialog.IsChangeLightState = request.IsChangeLightState;
                dialog.SetTitle(request.Message);
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.TopMost = true;

                // 显示弹窗
                dialog.ShowDialog();

                // 消息通知
                request.Callback?.Invoke(dialog.IsOK);
                dialog.Dispose();

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
            public Action<bool> Callback { get; set; }
            public bool IsChangeLightState { get; set; }
            public string Message { get; set; }
        }
        #endregion
    }
}
