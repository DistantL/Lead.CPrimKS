using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority
{
    public partial class UIWarnInfoEx : UIUserControl
    {
        private int _count = 0;
        private Dictionary<string, AlarmInfo> _dic = new Dictionary<string, AlarmInfo>();
        private static readonly object _locker = new object();

        public UIWarnInfoEx()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }

        public bool HasWarning()
        {
            return _count != 0;
        }

        public void InsertInfo(AlarmInfo info)
        {
            lock (_locker)
            {
                if (!_dic.ContainsKey(info.ErrorCode))
                {
                    _dic.Add(info.ErrorCode, info);
                    _count++;
                    UpdateData();
                }
            }
        }

        public void RemoveInfo(AlarmInfo info)
        {
            lock (_locker)
            {
                if (_dic.ContainsKey(info.ErrorCode))
                {
                    _dic.Remove(info.ErrorCode);
                    _count--;
                    UpdateData();
                }
            }
        }

        public bool HasAlarmInfoInUI(string errCode)
        {
            lock (_locker)
            {
                return _dic.ContainsKey(errCode);
            }
        }

        public void UpdateData()
        {
            if (rtb_WarnInfo.InvokeRequired)
            {
                rtb_WarnInfo.BeginInvoke(new Action(UpdateData));
                return;
            }
            rtb_WarnInfo.Clear();
            foreach (var item in _dic.Values)
            {
                switch (NLocalizer.Language)
                {

                    case "en-US":
                        rtb_WarnInfo.AppendText($"{item.LastTime.ToString("yyyy-MM-dd HH:mm:ss.ff")} {item.ErrorCode.PadLeft(8)} {item.ErrorDetailInEN}" + Environment.NewLine);
                        break;
                    case "vi-VN":
                        rtb_WarnInfo.AppendText($"{item.LastTime.ToString("yyyy-MM-dd HH:mm:ss.ff")} {item.ErrorCode.PadLeft(8)} {item.ErrorDetailInVN}" + Environment.NewLine);
                        break;
                    case "zh-CN":
                        rtb_WarnInfo.AppendText($"{item.LastTime.ToString("yyyy-MM-dd HH:mm:ss.ff")} {item.ErrorCode.PadLeft(8)} {item.ErrorDetail}" + Environment.NewLine);
                        break;
                    default:
                        break;

                }
            }
        }
    }
}