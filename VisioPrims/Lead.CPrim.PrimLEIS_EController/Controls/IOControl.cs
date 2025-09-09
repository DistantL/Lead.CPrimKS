using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Controls.IOModule;

namespace Lead.CPrim.PrimLESI_EController.Controls
{
    public partial class IOControl : Form
    {
        #region Field
        /// <summary>雷赛控制器管理器</summary>
        private PrimLESI_EController _prim;
        /// <summary>IO类型</summary>
        private ControlEnum.IOType _type;
        #endregion


        #region Ctor
        /// <summary>Ctor无参</summary>
        public IOControl()
        {
            InitializeComponent();
        }
        /// <summary>Ctor有2个参数</summary>
        /// <param name="type">IO类型</param>
        /// <param name="prim"></param>
        public IOControl(ControlEnum.IOType type, PrimLESI_EController prim)
        {
            InitializeComponent();
            _prim = prim;
            _type = type;
            switch (_type)
            {
                case ControlEnum.IOType.DI:
                    Text = "DIStatus";
                    AddDIoControl("DI");
                    break;
                case ControlEnum.IOType.DO:
                    Text = "DOControl";
                    AddDIoControl("DO");
                    break;
                case ControlEnum.IOType.AI:
                    Text = "AIStatus";
                    AddAIoControl("AI");
                    break;
                case ControlEnum.IOType.AO:
                    Text = "AOControl";
                    AddAIoControl("AO");
                    break;
                case ControlEnum.IOType.Other:
                    break;
            }
        }
        #endregion


        #region Define_Del
        private delegate void TmrStatusChange();

        private delegate void UpdateControls();
        #endregion


        #region Define_Event
        //public event Del_AIOControl Event_AIoControl;

        //public event Del_DIOControl Event_DIoControl; 
        #endregion


        private void AddAIoControl(string type)
        {
            var height = 0;
            var count = 0;
            switch (type)
            {
                case "AI":
                    count = _prim.AiModules.Count;
                    break;

                case "AO":
                    count = _prim.AoModules.Count;
                    break;

                default:
                    break;
            }
            tablePanelControl.Controls.Clear();
            for (var i = 0; i < count; i++)
            {
                tablePanelControl.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            }
            var index = 0;

            if (type == "AI")
            {
                foreach (var aiModule in _prim.AiModules)
                {
                    tablePanelControl.RowStyles[index].Height = index / count;
                    var info = new Dictionary<int, string>();
                    var num = -1;
                    var id = -1;
                    var typeName = "";

                    for (var j = 0; j < aiModule.Value.Num; j++)
                    {
                        var aiInfo = _prim.IoInfos.Ai.FirstOrDefault(p => (p.PrimName == _prim.Name) && (p.Address == aiModule.Value.Id + 0.01 * j));
                        if (aiInfo != null)
                        {
                            if (string.IsNullOrEmpty(aiInfo.Info))
                            {
                                aiInfo.Info = "";
                            }
                            info.Add(j, aiInfo.Info);
                        }
                    }
                    num = aiModule.Value.Num;
                    id = aiModule.Value.Id;
                    typeName = aiModule.Value.TypeName;

                    var io1 = new HorModule(type, num, id, typeName, info);
                    io1.Event_AIoModuleControlClick -= new Del_AIOControl(AIoControl);
                    io1.Event_AIoModuleControlClick += new Del_AIOControl(AIoControl);
                    io1.Dock = DockStyle.Top;
                    tablePanelControl.Controls.Add(io1, 0, index);
                    height += io1.Height;

                    if (index++ == _prim.AiModules.Count)
                    {
                        break;
                    }
                }
            }
            else if (type == "AO")
            {
                foreach (var aoModule in _prim.AoModules)
                {
                    tablePanelControl.RowStyles[index].Height = index / count;
                    var info = new Dictionary<int, string>();
                    var num = -1;
                    var id = -1;
                    var typeName = "";

                    for (var j = 0; j < aoModule.Value.Num; j++)
                    {
                        var aoInfo = _prim.IoInfos.Ao.FirstOrDefault(p => (p.PrimName == _prim.Name) && (p.Address == aoModule.Value.Id + 0.01 * j));
                        if (aoInfo != null)
                        {
                            if (string.IsNullOrEmpty(aoInfo.Info))
                            {
                                aoInfo.Info = "";
                            }
                            info.Add(j, aoInfo.Info);
                        }
                    }
                    num = aoModule.Value.Num;
                    id = aoModule.Value.Id;
                    typeName = aoModule.Value.TypeName;

                    var io1 = new HorModule(type, num, id, typeName, info);
                    io1.Event_AIoModuleControlClick -= new Del_AIOControl(AIoControl);
                    io1.Event_AIoModuleControlClick += new Del_AIOControl(AIoControl);
                    io1.Dock = DockStyle.Top;
                    tablePanelControl.Controls.Add(io1, 0, index);
                    height += io1.Height;

                    if (index++ == _prim.AoModules.Count)
                    {
                        break;
                    }
                }
            }
            tablePanelControl.Height = height;
            tablePanelControl.RowCount = count;

            tablePanelControl.Refresh();
            //this.Height = height;
        }

        private void AddDIoControl(string type)
        {
            var height = 0;
            var count = 0;
            switch (type)
            {
                case "DI":
                    count = _prim.DiModules.Count;
                    break;
                case "DO":
                    count = _prim.DoModules.Count;
                    break;
                default:
                    break;
            }
            tablePanelControl.Controls.Clear();
            for (var i = 0; i < count; i++)
                tablePanelControl.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));

            var index = 0;

            if (type == "DI")
            {
                foreach (var diModule in _prim.DiModules)
                {
                    tablePanelControl.RowStyles[index].Height = index / count;
                    var info = new Dictionary<int, string>();
                    var num = -1;
                    var id = -1;
                    var typeName = "";

                    for (var j = 0; j < diModule.Value.Num; j++)
                    {
                        var diInfo = _prim.IoInfos.Di.FirstOrDefault(p => (p.PrimName == _prim.Name) && (p.Address == diModule.Value.Id + 0.01 * j));
                        if (diInfo != null)
                        {
                            if (string.IsNullOrEmpty(diInfo.Info))
                            {
                                diInfo.Info = "";
                            }
                            info.Add(j, diInfo.Info);
                        }
                    }
                    num = diModule.Value.Num;
                    id = diModule.Value.Id;

                    var io1 = new HorModule(type, num, id, typeName, info);
                    io1.Event_DIoModuleControlClick -= new Del_DIOControl(DIoControl);
                    io1.Event_DIoModuleControlClick += new Del_DIOControl(DIoControl);
                    io1.Dock = DockStyle.Top;
                    tablePanelControl.Controls.Add(io1, 0, index);
                    height += io1.Height;

                    if (index++ == _prim.DiModules.Count)
                    {
                        break;
                    }
                }
            }
            else if (type == "DO")
            {
                foreach (var doModule in _prim.DoModules)
                {
                    tablePanelControl.RowStyles[index].Height = index / count;
                    var info = new Dictionary<int, string>();
                    var num = -1;
                    var id = -1;
                    var typeName = "";

                    for (var j = 0; j < doModule.Value.Num; j++)
                    {
                        var doInfo = _prim.IoInfos.Do.FirstOrDefault(p => (p.PrimName == _prim.Name) && (p.Address == doModule.Value.Id + 0.01 * j));
                        if (doInfo != null)
                        {
                            if (string.IsNullOrEmpty(doInfo.Info))
                            {
                                doInfo.Info = "";
                            }
                            info.Add(j, doInfo.Info);
                        }
                    }
                    num = doModule.Value.Num;
                    id = doModule.Value.Id;

                    var io1 = new HorModule(type, num, id, typeName, info);
                    io1.Event_DIoModuleControlClick -= new Del_DIOControl(DIoControl);
                    io1.Event_DIoModuleControlClick += new Del_DIOControl(DIoControl);
                    io1.Dock = DockStyle.Top;
                    tablePanelControl.Controls.Add(io1, 0, index);
                    height += io1.Height;

                    if (index++ == _prim.DoModules.Count)
                    {
                        break;
                    }
                }
            }

            tablePanelControl.Height = height;
            tablePanelControl.RowCount = count;

            tablePanelControl.Refresh();
            //this.Height = height;
        }

        private void AIoControl(string tag, double value)
        {
            //MessageBox.Show($"{tag} : {value}");
        }

        private void DIoControl(string tag, bool status)
        {
            //MessageBox.Show($"{tag} : {status}");
            var type = tag.Substring(0, 2);
            var address = double.Parse(tag.Substring(2));
            if (type == "DO")
            {
                _prim.WriteSingleDOutput(address, status);
            }
        }

        private void IOControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrCycle.Stop();
            Hide();
            e.Cancel = true;
        }

        public void ClearControls()
        {
            if (InvokeRequired)
            {
                var update = new UpdateControls(ClearControls);
                BeginInvoke(update, null);
            }
            else
            {
                tablePanelControl.Controls.Clear();
                tablePanelControl.Refresh();
            }
        }

        public void ReloadControls()
        {
            if (InvokeRequired)
            {
                var update = new UpdateControls(ReloadControls);
                BeginInvoke(update, null);
            }
            else
            {
                tablePanelControl.Controls.Clear();
                switch (_type)
                {
                    case ControlEnum.IOType.DI:
                        Text = "DIStatus";
                        AddDIoControl("DI");
                        break;

                    case ControlEnum.IOType.DO:
                        Text = "DOControl";
                        AddDIoControl("DO");
                        break;

                    case ControlEnum.IOType.AI:
                        Text = "AIStatus";
                        AddAIoControl("AI");
                        break;

                    case ControlEnum.IOType.AO:
                        Text = "AOControl";
                        AddAIoControl("AO");
                        break;

                    case ControlEnum.IOType.Other:
                        break;
                }
                tablePanelControl.Refresh();
                if (Enabled)
                {
                    tmrCycle.Start();
                }
            }
        }

        /// <summary>IO监控启动</summary>
        public void TmrStart()
        {
            if (InvokeRequired)
            {
                var update = new TmrStatusChange(TmrStart);
                BeginInvoke(update, null);
            }
            else
            {
                if (tmrCycle != null) tmrCycle.Start();
            }
        }
        /// <summary>IO监控停止</summary>
        public void TmrStop()
        {
            if (InvokeRequired)
            {
                var update = new TmrStatusChange(TmrStop);
                BeginInvoke(update, null);
            }
            else
            {
                if (tmrCycle != null) tmrCycle.Stop();
            }
        }
        /// <summary>IO监控定时器</summary>
        private void TmrCycle_Tick(object sender, EventArgs e)
        {
            foreach (var ioModule in tablePanelControl.Controls.OfType<HorModule>())
            {
                if (ioModule.Type == "DI")
                {
                    if (_prim.ReadDiModule(ioModule.StartAddr, out var value) == 0)
                    {
                        ioModule.UpdateDIoStatus(value, 0);
                    }
                }
                else if (ioModule.Type == "DO")
                {
                    if (_prim.ReadDoModule(ioModule.StartAddr, out var value) == 0)
                    {
                        ioModule.UpdateDIoStatus(value, 0);
                    }
                }
                else if (ioModule.Type == "AI")
                {
                    if (_prim.ReadAiModule(ioModule.StartAddr, out var value) == 0)
                    {
                        ioModule.UpdateAIoValues(value);
                    }
                }
                else if (ioModule.Type == "AO")
                {
                    if (_prim.ReadAoModule(ioModule.StartAddr, out var value) == 0)
                    {
                        ioModule.UpdateAIoValues(value);
                    }
                }
            }
        }
    }
}