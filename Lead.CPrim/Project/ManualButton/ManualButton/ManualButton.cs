using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ManualButton
{
    public delegate void ButtonManualTest(Button btn);



    public partial class ManualButton : Form
    {
        #region Event_Define
        public event ButtonManualTest OnButtonManualTest;
        #endregion



        #region Field
        private static ManualButton _instance;
        private Dictionary<string, List<string>> _dicGroupBtnName = new Dictionary<string, List<string>>();
        private object objLock = new object();
        private int _max_groupHeight = 0;
        #endregion



        #region Prop
        public bool IsRuning { get; set; }
        public static ManualButton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManualButton();
                }
                return _instance;
            }
        }
        public string GetSN1 => txtSN1.Text.Trim();
        public string GetSN2 => txtSN2.Text.Trim();
        #endregion



        #region Ctor
        private ManualButton()
        {
            InitializeComponent();
        }
        #endregion



        #region System_Event
        private void ManualTestFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsRuning = false;
            e.Cancel = true;
            Hide();
        }
        #endregion



        #region Button_Event
        private void BtnStop_Click(object sender, EventArgs e)
        {
            IsRuning = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                rtbMsg.Clear();
            }
            catch
            { }
        }

        private void lblSn1_DoubleClick(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 清除所有按钮
        /// </summary>
        public void ClearControl()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClearControl));
            }
            else
            {
                plMain.Controls.Clear();
                _dicGroupBtnName.Clear();
            }
        }

        /// <summary>
        /// 输出消息
        /// </summary>
        /// <param name="msg"></param>
        public void Show(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Show), msg);
            }
            else
            {
                msg = $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}：{msg}\r\n";
                rtbMsg.AppendText(msg);
                rtbMsg.ScrollToCaret();
            }
        }

        /// <summary>
        /// 增加按钮
        /// </summary>
        /// <param name="groupName">分组</param>
        /// <param name="buttonName">按钮名称</param>
        public void AddFromBtnName(string groupName, string buttonName)
        {
            if (InvokeRequired)
            {
                plMain.BeginInvoke(new Action<string, string>(AddFromBtnName), groupName, buttonName);
                return;
            }

            lock (objLock)
            {
                try
                {
                    if (_dicGroupBtnName == null)
                    {
                        _dicGroupBtnName = new Dictionary<string, List<string>>();
                    }

                    GroupBox groupBox = null;
                    if (_dicGroupBtnName.ContainsKey(groupName))
                    {
                        if (_dicGroupBtnName[groupName] == null)
                        {
                            _dicGroupBtnName[groupName] = new List<string>();
                        }

                        if (_dicGroupBtnName[groupName].Contains(buttonName))
                        {
                            return;
                        }

                        _dicGroupBtnName[groupName].Add(buttonName);

                        foreach (object control in plMain.Controls)
                        {
                            if (control is GroupBox && ((GroupBox)control).Text == groupName)
                            {
                                groupBox = (GroupBox)control;
                                break;
                            }
                        }

                        if (groupBox != null)
                        {
                            addButton(groupBox, buttonName);
                        }
                        else
                        {
                            groupBox = addGroupBox(plMain, groupName);
                            addButton(groupBox, buttonName);
                        }
                    }
                    else
                    {
                        groupBox = addGroupBox(plMain, groupName);
                        addButton(groupBox, buttonName);
                        _dicGroupBtnName.Add(groupName, new List<string> { buttonName });
                    }

                    if (groupBox != null)
                    {
                        groupBox.ClientSize = new Size(groupBox.ClientSize.Width,
                            26 + 40*_dicGroupBtnName[groupName].Count);
                    }
                }
                catch(Exception ex)
                {
                    Show($"AddFromBtnName error：{ex.Message}");
                }
            }
        }

        /// <summary>
        /// 清除所有事件
        /// </summary>
        public void OnButtonManualTestClearAll()
        {
            if(OnButtonManualTest == null)
            {
                return;
            }
            foreach (var item in OnButtonManualTest.GetInvocationList())
            {
                OnButtonManualTest -= item as ButtonManualTest;
            }
        }

        /// <summary>
        /// 设置SN1描述
        /// </summary>
        /// <param name="sn"></param>
        public void SetSn1Description(string sn)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetSn1Description), sn);
            }
            else
            {
                lblSn1.Text = sn;
            }
        }

        /// <summary>
        /// 设置SN2描述
        /// </summary>
        /// <param name="sn"></param>
        public void SetSn2Description(string sn)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetSn2Description), sn);
            }
            else
            {
                lblSn2.Text = sn;
            }
        }
        #endregion



        #region Method_InternalUsing
        private void addButton(GroupBox group, string buttonName)
        {
            Application.OpenForms[0].Invoke((Action)delegate
            {
                Button button = new Button();
                button.Size = new Size(280, 40);
                button.Dock = DockStyle.Top;
                button.Text = buttonName;
                button.Click += Button_Click;
                group.Controls.Add(button);
            });
        }
        private GroupBox addGroupBox(Panel flp, string groupName)
        {
            GroupBox group = new GroupBox();
            Application.OpenForms[0].Invoke((Action)delegate
            {
                group.Size = new Size(285, flp.ClientSize.Height);
                group.Dock = DockStyle.None;
                group.Text = groupName;

                int num = 0;
                foreach (object control in flp.Controls)
                {
                    if (control is GroupBox)
                    {
                        num++;
                    }
                }
                group.Location = new Point(285*num, 0);
                flp.Controls.Add(group);
            });
            return group;
        }
        private async void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.SuspendLayout();
            foreach (object item2 in plMain.Controls)
            {
                if (item2 is GroupBox)
                {
                    ((GroupBox)item2).Enabled = false;
                }
            }
            this.ResumeLayout();

            int I = ((!int.TryParse(txtNum.Text, out var value)) ? 1 : value);
            await Task.Factory.StartNew(delegate
            {
                IsRuning = true;
                for (int i = 0; (i < I) & IsRuning; i++)
                {
                    try
                    {
                        BeginInvoke((Action<int>)delegate (int x)
                        {
                            lblInfo.Text = $"{button.Text}第{x}次开始";
                        }, i + 1);
                        OnButtonManualTest?.Invoke((Button)sender);
                        BeginInvoke((Action<int>)delegate (int x)
                        {
                            lblInfo.Text = $"{button.Text}第{x}次结束";
                        }, i + 1);
                    }
                    catch (Exception ex)
                    {
                        Show(ex.Message);
                    }
                }
            });
            IsRuning = false;

            this.SuspendLayout();
            foreach (Control item in plMain.Controls)
            {
                if (item is GroupBox)
                {
                    ((GroupBox)item).Enabled = true;
                }
            }
            button.Focus();
            this.ResumeLayout();
        }
        #endregion
    }
}

/*
 * 2025-03-20 25997
 * 1. group‘s high change by button number
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */