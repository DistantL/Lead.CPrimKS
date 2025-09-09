/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIStatusFormService.cs
 * Author: Victor
 * Description: 进度提示窗体用户类
 * CreateTime: 2020-01-01
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1010><Victor><20221015>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Forms
******************************************************************************/

using Sunny.UI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI.Forms
{


    /// <summary>进度提示窗体用户类</summary>
    public class UIStatusFormService
    {
        #region Field
        private static bool IsRun;
        private static UIStatusFormService _instance;
        private static readonly object syncLock = new object();
        private Thread thread;
        /// <summary>进度条</summary>
        private UIStatusForm form;
        #endregion



        #region Prop
        private static UIStatusFormService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        _instance = new UIStatusFormService();
                    }
                }

                return _instance;
            }
        }
        #endregion



        #region System_Event
        /// <summary>进度条不可见时关闭进度条</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaitForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!form.Visible)
            {
                form.Close();
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>显示进度条</summary>
        /// <param name="maximum"></param>
        /// <param name="desc"></param>
        /// <param name="decimalCount"></param>
        public static void ShowStatusForm(int maximum = 100, string desc = "系统正在处理中，请稍候...", int decimalCount = 1)
        {
            if (IsRun) return;
            Instance.CreateForm(maximum, desc, decimalCount);
            IsRun = true;
        }
        /// <summary>隐藏进度条</summary>
        public static void HideStatusForm()
        {
            if (!IsRun) return;
            Instance.CloseForm();
            IsRun = false;
        }
        /// <summary>设置进度信息</summary>
        /// <param name="desc"></param>
        public static void SetDescription(string desc)
        {
            if (!IsRun) return;
            Instance.SetFormDescription(desc);
        }
        /// <summary>设置进度</summary>
        public static void StepIt(int step = 1)
        {
            if (!IsRun) return;
            Instance.SetFormStepIt(step);
        }
        /// <summary>设置进度信息以及进度</summary>
        /// <param name="desc"></param>
        /// <param name="step"></param>
        public static void SetInfo(string desc, int step)
        {
            SetDescription(desc);
            StepIt(step);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>创建进度条</summary>
        /// <param name="max">最大值</param>
        /// <param name="desc">进度条信息</param>
        /// <param name="decimalCount">当前进度</param>
        private void CreateForm(int max, string desc, int decimalCount = 1)
        {
            CloseForm();
            thread = new Thread(delegate ()
            {
                form = new UIStatusForm(max, desc, decimalCount);
                form.Render();
                form.TopMost = true;
                form.VisibleChanged += WaitForm_VisibleChanged;
                Application.Run(form);
                IsRun = false;
            });

            thread.Start();
        }
        /// <summary>关闭进度条</summary>
        private void CloseForm()
        {
            form?.StepIt(form.Maximum);
        }
        /// <summary>设置进度信息</summary>
        /// <param name="desc"></param>
        private void SetFormDescription(string desc)
        {
            try
            {
                form?.SetDescription(desc);
            }
            catch (Exception)
            {
                // ignored
            }
        }
        /// <summary>设置进度</summary>
        private void SetFormStepIt(int step)
        {
            try
            {
                form?.StepIt(step);
            }
            catch (Exception)
            {
                // ignored
            }
        }
        #endregion
    }
}