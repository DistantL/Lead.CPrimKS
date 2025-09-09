using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.PrimCommon
{
    public partial class PrimConfigForm : UIPage
    {
        #region Field

        private int _createIdx = 0;

        private PrimDisplay _curPrimDisplay = null;

        /// <summary>UI集合用来显示程序使用【基元】</summary>
        private List<PrimDisplay> _primDisplayList = new List<PrimDisplay>();

        /// <summary>基元DLL</summary>
        private string _primFolderPath = "";

        /// <summary>计时器</summary>
        private Stopwatch sw = new Stopwatch();

        /// <summary>基元显示UI</summary>
        private PrimToolBar _primToolBar = null;
        #endregion



        #region Define_Event
        /// <summary>新增基元时发生</summary>
        public event AddPrim OnAddPrim;

        /// <summary>改变基元名称时发生</summary>
        public event ChangePrimName OnChangePrimName;

        /// <summary>移除基元时发生</summary>
        public event RemovePrim OnRemovePrim;
        #endregion



        #region Ctor
        public PrimConfigForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        public PrimConfigForm(string path) : this()
        {
            _primFolderPath = path;
            _primDisplayList.Clear();

            if (_primToolBar == null)
            {
                _primToolBar = new PrimToolBar();
                _primToolBar.Dock = DockStyle.Fill;
                _primToolBar.DevToolBarFormLoad(_primFolderPath);
            }
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void PrimConfigForm_Load(object sender, EventArgs e)
        {
            if (_primToolBar != null)
            {
                _primToolBar.Show();
                _primToolBar.OnCreateDevice += InstanceCreateDevice;
                splUpDown.Panel1.Controls.Add(_primToolBar);
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            string primTypeName = e.Data.GetData(typeof(string)) as string;
            IPrim prim = PrimsManager.Instance.GetPrim(primTypeName);
            if (prim == null)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimCommon_PrimConfigForm_NotFoundDevicePrim", "The device DevPrim was not found, please reload the device Dll!"));
                return;
            }
            prim.Id = Guid.NewGuid();
            prim.Name = _curPrimDisplay.UIPrimName;
            PrimsManager.Instance.ListPrim.Add(prim);
            _curPrimDisplay.UIPrimID = prim.Id;
            _curPrimDisplay.UIPrim = prim;
            _curPrimDisplay.OnPrimDisplayControlSelectClick -= InstancePrimDisplayControlSelectClick;
            _curPrimDisplay.OnPrimDisplayControlSelectClick += InstancePrimDisplayControlSelectClick;

            _curPrimDisplay.OnPrimDisplayControlChangeName -= InstancePrimDisplayControlChangeName;
            _curPrimDisplay.OnPrimDisplayControlChangeName += InstancePrimDisplayControlChangeName;
            _curPrimDisplay.Dock = DockStyle.Top;
            _primDisplayList.Add(_curPrimDisplay);
            OnAddPrim?.Invoke(_curPrimDisplay.UIPrimGroup, _curPrimDisplay.UIPrimType, _curPrimDisplay.UIPrimName, _curPrimDisplay.UIPrimID);
            _createIdx++;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            string primTypeName = e.Data.GetData(typeof(string)) as string;
            IPrimCreator primCreator = PrimsManager.Instance.GetDevPrimCreator(primTypeName);
            if (primCreator == null)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimCommon_PrimConfigForm_ReloadDeviceDll", "The device creator ICreator was not found, please reload the device Dll!"));
                return;
            }
            PrimDisplay primDisplay = new PrimDisplay();
            primDisplay.UIPrimIcon = primCreator.ConcretePrimTypeAttributes.Icon;
            primDisplay.UIPrimName = primCreator.ConcretePrimTypeAttributes.DisplayName + _createIdx;
            primDisplay.UIPrimGroup = primCreator.ConcretePrimTypeAttributes.DisplayGroup;
            primDisplay.UIPrimType = primCreator.ConcretePrimTypeAttributes.DisplayName;
            primDisplay.panel1.AutoSize = false;
            primDisplay.panel1.Size = new Size(56, 52);
            Point pPoint = ((Control)this).PointToClient(Control.MousePosition);
            primDisplay.Location = new Point(pPoint.X - 26, pPoint.Y - 26);
            _curPrimDisplay = primDisplay;
            splLeftRight.Panel1.Controls.Add(primDisplay);
        }
        #endregion



        #region Button_Event
        /// <summary>右键保存</summary>
        private void tsmSavePrimsConfig_Click(object sender, EventArgs e)
        {
            PrimsManager.Instance.Save();
        }
        #endregion



        #region Method_Instance
        /// <summary>响应单击新建基元</summary>
        /// <param name="primTypeName">基元名称</param>
        public void InstanceCreateDevice(string primTypeName)
        {
            IPrimCreator primCreator = PrimsManager.Instance.GetDevPrimCreator(primTypeName);
            IPrim prim = PrimsManager.Instance.GetPrim(primTypeName);
            if (primCreator == null)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimCommon_PrimConfigForm_ReloadDeviceDll", "The device creator ICreator was not found, please reload the device Dll!"));
                return;
            }

            if (prim == null)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimCommon_PrimConfigForm_NotFoundPrimitivePrim", "The primitive Prim was not found, please reload the device Dll!"));
                return;
            }
            _createIdx = PrimsManager.Instance.ListPrim.FindAll(p => p.Name.Contains(primCreator.ConcretePrimTypeAttributes.Name)).Count;

            PrimDisplay primDisplay = new PrimDisplay();
            primDisplay.UIPrimIcon = primCreator.ConcretePrimTypeAttributes.Icon;
            primDisplay.UIPrimName = primCreator.ConcretePrimTypeAttributes.Name + _createIdx;
            primDisplay.UIPrimGroup = primCreator.ConcretePrimTypeAttributes.DisplayGroup;
            primDisplay.UIPrimType = primCreator.ConcretePrimTypeAttributes.DisplayName;
            primDisplay.panel1.AutoSize = false;
            primDisplay.panel1.Size = new Size(56, 52);
            prim.Id = Guid.NewGuid();
            prim.Name = primDisplay.UIPrimName;
            prim.PrimTypeName = primCreator.ConcretePrimTypeAttributes.Name;
            PrimsManager.Instance.ListPrim.Add(prim);
            primDisplay.UIPrimID = prim.Id;
            primDisplay.UIPrim = prim;
            primDisplay.OnPrimDisplayControlSelectClick -= InstancePrimDisplayControlSelectClick;
            primDisplay.OnPrimDisplayControlSelectClick += InstancePrimDisplayControlSelectClick;

            primDisplay.OnPrimDisplayControlChangeName -= InstancePrimDisplayControlChangeName;
            primDisplay.OnPrimDisplayControlChangeName += InstancePrimDisplayControlChangeName;
            primDisplay.Dock = DockStyle.Top;
            splLeftRight.Panel1.Controls.Add(primDisplay);
            _primDisplayList.Add(primDisplay);

            OnAddPrim?.Invoke(primDisplay.UIPrimGroup, primDisplay.UIPrimType, primDisplay.UIPrimName, primDisplay.UIPrimID);
        }

        /// <summary>响应基元名称改变</summary>
        /// <param name="primId">Id</param>
        /// <param name="primName">基元名称</param>
        private void InstancePrimDisplayControlChangeName(Guid primId, string primName)
        {
            OnChangePrimName?.Invoke(primId, primName);
        }

        /// <summary>响应对基元进行操作</summary>
        /// <param name="type">操作类型</param>
        /// <param name="primName">基元名称</param>
        /// <param name="primGuid">基元Id</param>
        private void InstancePrimDisplayControlSelectClick(int type, string primName, Guid primGuid)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, string, Guid>(InstancePrimDisplayControlSelectClick), type, primName, primGuid);
                return;
            }

            IPrim prim = PrimsManager.Instance.GetPrimByGUID(primGuid);
            if (prim == null)
            {
                return;
            }

            switch (type)
            {
                //双击图标
                case 0:
                    Invoke(new Action(() =>
                    {
                        splUpDown.Panel2.Controls.Clear();
                        prim.PrimConfigUI.Dock = DockStyle.Fill;
                        splUpDown.Panel2.Controls.Add(prim.PrimConfigUI);
                    }));
                    break;
                //调试界面显示
                case 1:
                    Invoke(new Action(() =>
                    {
                        splUpDown.Panel2.Controls.Clear();
                        prim.PrimDebugUI.Dock = DockStyle.Fill;
                        splUpDown.Panel2.Controls.Add(prim.PrimDebugUI);
                    }));
                    break;
                //配置界面显示
                case 2:
                    Invoke(new Action(() =>
                    {
                        splUpDown.Panel2.Controls.Clear();
                        prim.PrimConfigUI.Dock = DockStyle.Fill;
                        splUpDown.Panel2.Controls.Add(prim.PrimConfigUI);
                    }));
                    break;
                //输出界面显示
                case 3:
                    Invoke(new Action(() =>
                    {
                        splUpDown.Panel2.Controls.Clear();
                        prim.PrimOutputUI.Dock = DockStyle.Fill;
                        splUpDown.Panel2.Controls.Add(prim.PrimOutputUI);
                    }));
                    break;
                //移除基元
                case 4:
                    Invoke(new Action(() =>
                    {
                        foreach (PrimDisplay primDisplay in _primDisplayList)
                        {
                            if (primDisplay.UIPrimID == primGuid)
                            {
                                if (splUpDown.Panel2.Controls.Contains(prim.PrimConfigUI))
                                {
                                    splUpDown.Panel2.Controls.Remove(prim.PrimConfigUI);
                                }
                                if (splUpDown.Panel2.Controls.Contains(prim.PrimOutputUI))
                                {
                                    splUpDown.Panel2.Controls.Remove(prim.PrimOutputUI);
                                }
                                splLeftRight.Panel1.Controls.Remove(primDisplay);
                                _primDisplayList.Remove(primDisplay);
                                PrimsManager.Instance.RemovePrimByGUID(primGuid);

                                OnRemovePrim?.Invoke(primGuid);
                                break;
                            }
                        }
                    }));
                    break;
                //调试界面隐藏
                case 11:
                    Invoke(new Action(() =>
                    {
                        if (splUpDown.Panel2.Controls.Contains(prim.PrimDebugUI))
                        {
                            splUpDown.Panel2.Controls.Remove(prim.PrimDebugUI);
                        }
                    }));
                    break;
                ////配置界面隐藏
                case 12:
                    Invoke(new Action(() =>
                    {
                        if (splUpDown.Panel2.Controls.Contains(prim.PrimConfigUI))
                        {
                            splUpDown.Panel2.Controls.Remove(prim.PrimConfigUI);
                        }
                    }));
                    break;
                //输出界面隐藏
                case 13:
                    Invoke(new Action(() =>
                    {
                        if (splUpDown.Panel2.Controls.Contains(prim.PrimOutputUI))
                        {
                            splUpDown.Panel2.Controls.Remove(prim.PrimOutputUI);
                        }
                    }));
                    break;
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>使能状态设置</summary>
        /// <param name="enable">true：使能状态；false：非使能状态</param>
        internal void SetEnable(bool enable)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetEnable), enable);
                return;
            }
            splLeftRight.Enabled = enable;
        }
        /// <summary>创建基元UI</summary>
        /// <param name="prim"></param>
        public void CreatePrimDisplay(IPrim prim)
        {
            IPrimCreator primCreator = PrimsManager.Instance.GetDevPrimCreator(prim.PrimTypeName);
            if (primCreator == null)
            {
                MessageBox.Show(ProxyTools.NLocalizer.GetString("PrimCommon_PrimConfigForm_ReloadDeviceDll", "The device creator ICreator was not found, please reload the device Dll!"));
            }
            PrimDisplay primDisplay = new PrimDisplay();
            primDisplay.UIPrimIcon = prim.CurrentImageIndex == -1 ? primCreator.ConcretePrimTypeAttributes.Icon : primCreator.ConcretePrimTypeAttributes.ListIcon[prim.CurrentImageIndex];
            primDisplay.UIPrimName = prim.Name;
            primDisplay.UIPrimGroup = primCreator.ConcretePrimTypeAttributes.DisplayGroup;
            primDisplay.UIPrimType = primCreator.ConcretePrimTypeAttributes.DisplayName;
            primDisplay.panel1.AutoSize = false;
            primDisplay.panel1.Size = new Size(56, 52);
            primDisplay.UIPrimID = prim.Id;
            primDisplay.UIPrim = prim;
            primDisplay.OnPrimDisplayControlSelectClick -= InstancePrimDisplayControlSelectClick;
            primDisplay.OnPrimDisplayControlSelectClick += InstancePrimDisplayControlSelectClick;
            primDisplay.OnPrimDisplayControlChangeName -= InstancePrimDisplayControlChangeName;
            primDisplay.OnPrimDisplayControlChangeName += InstancePrimDisplayControlChangeName;
            primDisplay.Dock = DockStyle.Top;
            splLeftRight.Panel1.Controls.Add(primDisplay);
            _primDisplayList.Add(primDisplay);
            OnAddPrim?.Invoke(primDisplay.UIPrimGroup, primDisplay.UIPrimType, primDisplay.UIPrimName, primDisplay.UIPrimID);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>中英切换</summary>
        private void InitializeUI()
        {
            //TabText = ProxyTools.NLocalizer.GetString("PrimCommon_PrimConfigForm_FormText", "PrimConfigForm");
        }
        #endregion
    }
}
