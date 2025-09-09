using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManualTestForm
{
    public delegate void ButtonManualTest(Button btn);
    public class ManualDoeForm : Form
    {
        #region Field
        private static ManualDoeForm _instance;
        private Dictionary<string, List<string>> _dicGroupBtnName = new Dictionary<string, List<string>>();
        private Panel panel3;
        private RichTextBox rtbMsg;
        private Button btnClear;
        private object objLock = new object();
        #endregion


        #region Prop
        public bool IsRuning { get; set; }
        public static ManualDoeForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManualDoeForm();
                }
                return _instance;
            }
        }
        public string GetBCSN => txtBcSN.Text.Trim();
        public string GetANTSN => txtAntSn.Text.Trim();
        #endregion


        #region Event_Define
        public event ButtonManualTest OnButtonManualTest;
        #endregion


        #region System_Event
        private void ManualTestFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsRuning = false;
            e.Cancel = true;
            Hide();
        }
        #endregion


        #region Ctor
        private ManualDoeForm()
        {
            InitializeComponent();
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
        #endregion


        #region Method_ExternalUsing
        public void ClearControl()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(ClearControl));
                return;
            }
            flpMain.Controls.Clear();
            _dicGroupBtnName.Clear();
        }
        public void Show(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(Show), msg);
                return;
            }
            msg = $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}：{msg}\r\n";
            rtbMsg.AppendText(msg);
            rtbMsg.ScrollToCaret();
        }
        public void AddFromBtnName(string groupName, string buttonName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, string>(AddFromBtnName), groupName, buttonName);
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
                    FlowLayoutPanel flowLayoutPanel = flpMain;
                    if (_dicGroupBtnName.ContainsKey(groupName))
                    {
                        if (_dicGroupBtnName[groupName] == null)
                        {
                            _dicGroupBtnName[groupName] = null;
                        }
                        if (_dicGroupBtnName[groupName].Contains(buttonName))
                        {
                            return;
                        }
                        _dicGroupBtnName[groupName].Add(buttonName);

                        GroupBox groupBox = null;
                        foreach (object control in flowLayoutPanel.Controls)
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
                            return;
                        }
                        groupBox = addGroupBox(flowLayoutPanel, groupName);
                        foreach (string item in _dicGroupBtnName[groupName])
                        {
                            addButton(groupBox, item);
                        }
                    }
                    else
                    {
                        addButton(addGroupBox(flowLayoutPanel, groupName), buttonName);
                        _dicGroupBtnName.Add(groupName, new List<string> { buttonName });
                    }
                }
                catch
                {
                }
            }
        }
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
        #endregion


        #region Method_InternalUsing
        private void addButton(GroupBox group, string buttonName)
        {
            Application.OpenForms[0].BeginInvoke((Action)delegate
            {
                Button button = new Button();
                button.Size = new Size(280, 45);
                button.Dock = DockStyle.Top;
                button.Text = buttonName;
                button.Click += Button1_Click;
                group.Controls.Add(button);
            });
        }
        private GroupBox addGroupBox(FlowLayoutPanel panTemp, string groupName)
        {
            GroupBox group = new GroupBox();
            Application.OpenForms[0].Invoke((Action)delegate
            {
                group.Size = new Size(285, 400);
                group.Dock = DockStyle.None;
                group.Text = groupName;
                int num = 0;
                foreach (object control in panTemp.Controls)
                {
                    if (control is GroupBox)
                    {
                        num++;
                    }
                }
                if (num != 0)
                {
                    group.Dock = DockStyle.Left;
                }
                panTemp.Controls.Add(group);
            });
            return group;
        }
        private async void Button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.SuspendLayout();
            foreach (object item2 in flpMain.Controls)
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
                            labTxtInfo.Text = $"{button.Text}第{x}次开始";
                        }, i + 1);
                        OnButtonManualTest?.Invoke((Button)sender);
                        BeginInvoke((Action<int>)delegate (int x)
                        {
                            labTxtInfo.Text = $"{button.Text}第{x}次结束";
                        }, i + 1);
                    }
                    catch { }
                }
            });
            IsRuning = false;

            this.SuspendLayout();
            foreach (Control item in flpMain.Controls)
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







        #region System
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.btnStop = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.labTxtInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAntSn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBcSN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.AutoSize = true;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(170, 3);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(126, 34);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止所有";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panel1, 0, 1);
            this.tlpMain.Controls.Add(this.labTxtInfo, 0, 4);
            this.tlpMain.Controls.Add(this.panel2, 0, 0);
            this.tlpMain.Controls.Add(this.panel3, 0, 3);
            this.tlpMain.Controls.Add(this.rtbMsg, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Size = new System.Drawing.Size(984, 661);
            this.tlpMain.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 405);
            this.panel1.TabIndex = 0;
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 0);
            this.flpMain.Margin = new System.Windows.Forms.Padding(2);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(980, 405);
            this.flpMain.TabIndex = 6;
            this.flpMain.WrapContents = false;
            // 
            // labTxtInfo
            // 
            this.labTxtInfo.AutoSize = true;
            this.labTxtInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.labTxtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTxtInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.labTxtInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labTxtInfo.Location = new System.Drawing.Point(2, 620);
            this.labTxtInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTxtInfo.Name = "labTxtInfo";
            this.labTxtInfo.Size = new System.Drawing.Size(980, 41);
            this.labTxtInfo.TabIndex = 1;
            this.labTxtInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtAntSn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBcSN);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 35);
            this.panel2.TabIndex = 3;
            // 
            // txtAntSn
            // 
            this.txtAntSn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAntSn.Location = new System.Drawing.Point(534, 2);
            this.txtAntSn.Name = "txtAntSn";
            this.txtAntSn.Size = new System.Drawing.Size(348, 30);
            this.txtAntSn.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(447, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "ANTSN：";
            // 
            // txtBcSN
            // 
            this.txtBcSN.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBcSN.Location = new System.Drawing.Point(84, 2);
            this.txtBcSN.Name = "txtBcSN";
            this.txtBcSN.Size = new System.Drawing.Size(348, 30);
            this.txtBcSN.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "BCSN：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtNum);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnStop);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 580);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 40);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "次数:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNum.Location = new System.Drawing.Point(68, 5);
            this.txtNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(98, 29);
            this.txtNum.TabIndex = 2;
            this.txtNum.Text = "1";
            // 
            // rtbMsg
            // 
            this.rtbMsg.BackColor = System.Drawing.SystemColors.Control;
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbMsg.Location = new System.Drawing.Point(0, 444);
            this.rtbMsg.Margin = new System.Windows.Forms.Padding(0);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(984, 136);
            this.rtbMsg.TabIndex = 4;
            this.rtbMsg.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.AutoSize = true;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(300, 3);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(126, 34);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ManualDoeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ManualDoeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手动测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualTestFrm_FormClosing);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }
        private Button btnStop;
        private TableLayoutPanel tlpMain;
        private Panel panel1;
        private Label labTxtInfo;
        private ToolTip toolTip1;
        private TextBox txtNum;
        private Label label1;
        private FlowLayoutPanel flpMain;
        private Panel panel2;
        private Label label3;
        private TextBox txtBcSN;
        private TextBox txtAntSn;
        private Label label2;
        #endregion
    }
}
