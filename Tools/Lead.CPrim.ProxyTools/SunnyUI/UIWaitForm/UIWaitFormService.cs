using Lead.CPrim.ProxyTools.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools
{
    public class UIWaitFormService
    {
        #region Field
        private static UIWaitFormService _instance;
        private static bool IsRun;
        private Thread thread;
        private UIWaitForm form;
        private static readonly object syncLock = new object();
        #endregion



        #region Prop
        private static UIWaitFormService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        _instance = new UIWaitFormService();
                    }
                }

                return _instance;
            }
        }

        #endregion



        #region Method_ExternalUsing
        public static void ShowWaitForm(string desc = "系统正在处理中，请稍候...")
        {
            if (IsRun)
            {
                return;
            }

            IsRun = true;
            Instance.CreateForm(desc);
        }

        public static void HideWaitForm()
        {
            if (!IsRun)
            {
                return;
            }

            Instance.CloseForm();
            IsRun = false;
        }

        public static void SetDescription(string desc)
        {
            if (!IsRun)
            {
                return;
            }

            Instance.SetFormDescription(desc);
        }
        #endregion



        #region Method_InternalUsing
        private void CreateForm(string desc)
        {
            CloseForm();
            thread = new Thread(delegate ()
            {
                form = new UIWaitForm(desc);
                form.Render();
                form.Show();
                if (IsRun)
                {
                    form.SetDescription(desc);
                    Application.Run(form);
                }
            });

            if (IsRun)
            {
                thread.Start();
            }
            else
            {
                CloseForm();
            }
        }

        private void CloseForm()
        {
            if (form != null)
            {
                form.NeedClose = true;
            }
        }

        private void SetFormDescription(string desc)
        {
            form?.SetDescription(desc);
        } 
        #endregion
    }
}
