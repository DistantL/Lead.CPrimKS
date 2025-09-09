/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIStatusForm.cs
 * Author: Victor
 * Description: 进度提示窗体
 * CreateTime: 2020-05-05
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-05-05: V2.2.5 增加文件
 *
 * <3.3.22.1010><Victor><20221015>
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Controls
******************************************************************************/

using System;
using System.ComponentModel;

namespace Lead.CPrim.ProxyTools.SunnyUI.Forms
{
    public sealed partial class UIStatusForm : UIForm
    {
        public UIStatusForm()
        {
            InitializeComponent();
            Text = ULocalize.InfoTitle;
            Description = ULocalize.SystemProcessing;
        }

        public UIStatusForm(int max, string desc, int decimalPlaces = 1)
        {
            InitializeComponent();

            Maximum = max;
            Description = desc;
            Value = 0;
            DecimalPlaces = decimalPlaces;
        }

        [DefaultValue(100)]
        public int Maximum
        {
            get => processBar.Maximum;
            set => processBar.Maximum = value;
        }

        [DefaultValue(0)]
        public int Value
        {
            get => processBar.Value;
            set => processBar.Value = value;
        }

        [DefaultValue(1)]
        public int Step
        {
            get => processBar.Step;
            set => processBar.Step = value;
        }

        [DefaultValue(true)]
        public bool ShowValue
        {
            get => processBar.ShowValue;
            set => processBar.ShowValue = value;
        }

        /// <summary>进度到达最大值时自动隐藏</summary>
        [DefaultValue(true)]
        public bool MaxAutoHide { get; set; } = true;

        private void processBar_ValueChanged(object sender, int value)
        {
            if (MaxAutoHide && value == Maximum)
            {
                Hide();
            }
        }

        public void Show(string title, string desc, int max = 100, int value = 0)
        {
            Text = title;
            labelDescription.Text = desc;
            processBar.Maximum = max;
            processBar.Value = value;
            Show();
        }

        public string Description
        {
            get => labelDescription.Text;
            set => labelDescription.Text = value;
        }

        public int DecimalPlaces
        {
            get => processBar.DecimalPlaces;
            set => processBar.DecimalPlaces = value;
        }


        [Obsolete("请用DecimalPlaces代替。")]
        public int DecimalCount
        {
            get => processBar.DecimalPlaces;
            set => processBar.DecimalPlaces = value;
        }

        private delegate void SetTextHandler(string text);

        public void SetDescription(string text)
        {
            if (labelDescription.InvokeRequired)
            {
                Invoke(new SetTextHandler(SetDescription), text);
            }
            else
            {
                labelDescription.Text = text;
                labelDescription.Invalidate();
            }
        }

        public void StepIt(int step = 1)
        {
            if (processBar.InvokeRequired)
            {
                Invoke(new Action<int>(StepIt), step);
            }
            else
            {
                processBar.Step = step;
                processBar.StepIt();
            }
        }
    }
}
