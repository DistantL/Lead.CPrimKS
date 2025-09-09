using System;
using System.Drawing;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.EleCyldLine
{
    public partial class DebugUI : UserControl
    {
        #region Field
        private EleCyldLineConfig _config;
        private EleCylinderLine _eleCyldLine;
        #endregion


        #region Ctor
        public DebugUI()
        {
            InitializeComponent();
        }
        #endregion


        //*****************************************************************************
        #region Button_Event

        private void lblName_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleCyldLine.Enable)
                {
                    _eleCyldLine.Toggle();
                }
                else
                {
                    string errorText = _eleCyldLine.CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 未使能" : $"真空 {Name} 未使能";
                    _eleCyldLine.LogAdd(errorText, LogLevel.Warn);
                }
            }
            catch (Exception ex)
            {
                _eleCyldLine.LogAdd($"{_eleCyldLine.Name}切换失败：{ex.Message}", LogLevel.Warn);
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                if (_eleCyldLine.Enable)
                {
                    _eleCyldLine.Toggle() ;
                }
                else
                {
                    string errorText = _eleCyldLine.CyldType == EleCyldType.Cylinder ? $"气缸 {Name} 未使能" : $"真空 {Name} 未使能";
                    _eleCyldLine.LogAdd(errorText, LogLevel.Warn);
                }
            }
            catch (Exception ex)
            {
                _eleCyldLine.LogAdd($"{_eleCyldLine.Name}切换失败：{ex.Message}", LogLevel.Warn);
            }
        }
        #endregion


        //*****************************************************************************
        #region System_Event
        private void DebugUI_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_eleCyldLine.DevName))
            {
                if (_eleCyldLine.EleRunStat == EleRunState.Other)
                {
                    _eleCyldLine.IEleInit();
                }
            }
        }
        #endregion


        //*****************************************************************************
        #region Method_ExternalUsing
        public void SetEleConfig(EleCylinderLine eleCyldLine)
        {
            _eleCyldLine = eleCyldLine;
            lblName.Text = _eleCyldLine.Name;
        }
        public void UpdataEleConfig(EleCyldLineConfig Config)
        {
            _config = Config;
            lblName.Text = _config.Name;
        }
        public void SetEleRunState(EleRunState state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<EleRunState>(SetEleRunState), state);
            }
            else
            {
                switch (state)
                {
                    case EleRunState.Idle:
                        lblName.BackColor = Color.Khaki;
                        break;

                    case EleRunState.Running:
                        lblName.BackColor = Color.LightGreen;
                        break;

                    case EleRunState.Err:
                        lblName.BackColor = Color.SandyBrown;
                        break;

                    case EleRunState.Other:
                        lblName.BackColor = Color.Khaki;
                        break;
                }
            }
        }
        public void UiRefresh()
        {
            if(InvokeRequired)
            {
                BeginInvoke(new Action(UiRefresh));
                return;
            }

            if (_eleCyldLine == null || _config == null || _config.IsSimulateMode) return;

            switch (_eleCyldLine.EleRunStat)
            {
                case EleRunState.Running:
                    int num = _eleCyldLine.CheckCylState();

                    StretchDI.BackColor = num == 1 ? Color.Lime : (num == 3 ? Color.Red : Color.Gray);
                    RestractDI.BackColor = num == 0 ? Color.Lime : (num == 2 ? Color.Red : Color.Gray);
                    break;
                case EleRunState.Err:
                    StretchDI.BackColor = Color.Red;
                    RestractDI.BackColor = Color.Red;
                    break;
                case EleRunState.Idle:
                case EleRunState.Suspend:
                case EleRunState.Stop:
                case EleRunState.Other:
                default:
                    StretchDI.BackColor = Color.Gray;
                    RestractDI.BackColor = Color.Gray;
                    _eleCyldLine.IEleInit();
                    break;
            }
        }
        #endregion
    }
}