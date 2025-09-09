/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: ShowConfigForm.cs
 * Author: Victor
 * Description: 显示基元显示总窗口，用来反射加载显示基元dll
 * CreateTime: 2022-09-28
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 3.3.22.0925 -> 
 * <Author> (Victor)    <Time> (20220925)
 * 1、显示基元显示方式由Top变更为Fill
 * 2、双击显示基元显示配置UI及输出UI变更为只显示配置UI
******************************************************************************/

using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lead.CPrim.ShowCommon
{
    /// <summary>显示基元配置</summary>
    public partial class ShowConfigForm : UIPage
    {
        #region Field
        /// <summary>显示基元名称后面自动加序号</summary>
        private int _createIdx = 0;

        /// <summary>UI集合用来显示程序使用【显示基元】</summary>
        private List<ShowDisplay> _listShowDisplay = new List<ShowDisplay>();

        /// <summary>显示基元dll地址</summary>
        private string _showFolderPath = "";

        /// <summary>UI用来显示所有【显示基元】</summary>
        private ShowToolBar _showToolBar = null;

        /// <summary>计时器</summary>
        private Stopwatch sw = new Stopwatch();
        #endregion



        #region Define_Event
        /// <summary>新增显示基元时发生</summary>
        internal event AddShow OnAddShow;
        /// <summary>改变基元显示名称时发生</summary>
        internal event ChangeShowName OnChangeShowName;
        /// <summary>移除显示基元时发生</summary>
        internal event RemoveShow OnRemoveShow;
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowConfigForm()
        {
            InitializeComponent();
            //DockHandler.HideOnClose = true;
        }
        /// <summary>Ctor有2个参数</summary>
        public ShowConfigForm(string path) : this()
        {
            _showFolderPath = path;
            _listShowDisplay.Clear();

            if (_showToolBar == null)
            {
                _showToolBar = new ShowToolBar { Dock = DockStyle.Fill };
                _showToolBar.ShowToolBarFormLoad(_showFolderPath);
            }
        }
        #endregion



        //*****************************************************************************
        #region System_Event
        /// <summary>Load事件</summary>
        private void ShowConfigForm_Load(object sender, EventArgs e)
        {
            if (_showToolBar != null)
            {
                _showToolBar.Show();
                _showToolBar.CreateShow += OnCreateShow;
                splUpDown.Panel1.Controls.Add(_showToolBar);
            }

            #region 备用
            //sw.Reset();
            //sw.Start();
            //if (_showToolBar == null)
            //{
            //    _showToolBar = new ShowToolBar { Dock = DockStyle.Fill };
            //    _showToolBar.ShowToolBarFormLoad(_showFolderPath, _assemblyLoaded);
            //    _showToolBar.Show();
            //    _showToolBar.CreateShow += OnCreateShow;
            //    splitDisplay.Panel1.Controls.Add(_showToolBar);
            //}
            //sw.Stop();
            //LogAdd("Load加载耗时：" + sw.ElapsedMilliseconds, LogLevel.Debug); 
            #endregion
        }
        #endregion



        //*****************************************************************************
        #region Button_Event
        /// <summary>右键保存显示配置</summary>
        private void tsmSaveShowConfig_Click(object sender, EventArgs e)
        {
            if (ShowManager.Instance.Save() == 0)
                MessageBox.Show(this, NLocalizer.GetString("Lead_CPrim_ShowCommon_ShowConfigForm_ShowPrimSaveSuccess", "显示基元保存成功"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(this, NLocalizer.GetString("Lead_CPrim_ShowCommon_ShowConfigForm_ShowPrimSaveFail", "显示基元保存失败") , "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// <summary> 程序使用显示基元UI显示以及事件注册</summary>
        /// <param name="show">[IShow对象]</param>
        public void CreateShowDisplay(IShow show)
        {
            IShowCreator showCreator = ShowManager.Instance.GetShowCreator(show.ShowTypeName);
            if (showCreator == null) MessageBox.Show(
                NLocalizer.GetString("Lead_CPrim_ShowCommon_ShowConfigForm_NoFindInterface", "未发现接口ICreate，请重新加载Dll！"));
            ShowDisplay showDisplay = new ShowDisplay
            {
                UIShowIcon = showCreator.ConcreteShowTypeAttributes.Icon,
                UIShowName = show.Name,
                UIShowGroup = showCreator.ConcreteShowTypeAttributes.DisplayGroup,
                UIShowType = showCreator.ConcreteShowTypeAttributes.DisplayName,
                panel1 = { AutoSize = false, Size = new Size(56, 52) },
                UIShowID = show.Id,
                UIShow = show
            };
            showDisplay.OnShowClick -= OnShowControlSelectClick;
            showDisplay.OnShowClick += OnShowControlSelectClick;
            showDisplay.OnShowControlChangeName -= OnShowControlChangeName;
            showDisplay.OnShowControlChangeName += OnShowControlChangeName;
            showDisplay.Dock = DockStyle.Top;
            splLeftRight.Panel1.Controls.Add(showDisplay);
            _listShowDisplay.Add(showDisplay);
            OnAddShow?.Invoke(showDisplay.UIShowGroup, showDisplay.UIShowType, showDisplay.UIShowName, showDisplay.UIShowID);
        }
        #endregion



        //*****************************************************************************
        #region Method_InternalUsing
        /// <summary>单击新建显示基元时发生响应（新建显示基元）</summary>
        /// <param name="showTypeName"></param>
        private void OnCreateShow(string showTypeName)
        {
            IShowCreator showCreator = ShowManager.Instance.GetShowCreator(showTypeName);
            IShow show = ShowManager.Instance.GetShow(showTypeName);
            if (showCreator == null)
            {
                MessageBox.Show(
                NLocalizer.GetString("Lead_CPrim_ShowCommon_ShowConfigForm_NoFindInterface", "未发现接口ICreate，请重新加载Dll！"));
                return;
            }
            if (show == null)
            {
                MessageBox.Show(
                    NLocalizer.GetString("Lead_CPrim_ShowCommon_ShowConfigForm_NoFindMainGUI", "未发现主界面，请重新加载Dll！")); 
                return;
            }
            _createIdx = ShowManager.Instance.ListShow.FindAll(s => s.Name.Contains(showCreator.ConcreteShowTypeAttributes.Name)).Count;
            ShowDisplay showDisplay = new ShowDisplay
            {
                UIShowIcon = showCreator.ConcreteShowTypeAttributes.Icon,
                UIShowName = showCreator.ConcreteShowTypeAttributes.Name + _createIdx,
                UIShowGroup = showCreator.ConcreteShowTypeAttributes.DisplayGroup,
                UIShowType = showCreator.ConcreteShowTypeAttributes.DisplayName,
                panel1 = { AutoSize = false, Size = new Size(56, 52) }
            };
            show.Id = Guid.NewGuid();
            show.Name = showDisplay.UIShowName;
            show.ShowTypeName = showCreator.ConcreteShowTypeAttributes.Name;
            ShowManager.Instance.ListShow.Add(show);
            showDisplay.UIShowID = show.Id;
            showDisplay.UIShow = show;
            showDisplay.OnShowClick -= OnShowControlSelectClick;
            showDisplay.OnShowClick += OnShowControlSelectClick;
            showDisplay.OnShowControlChangeName -= OnShowControlChangeName;
            showDisplay.OnShowControlChangeName += OnShowControlChangeName;
            showDisplay.Dock = DockStyle.Top;
            splLeftRight.Panel1.Controls.Add(showDisplay);
            _listShowDisplay.Add(showDisplay);
            OnAddShow?.Invoke(showDisplay.UIShowGroup, showDisplay.UIShowType, showDisplay.UIShowName, showDisplay.UIShowID);
        }
        /// <summary>选择显示基元控件时发生</summary>
        /// <param name="type">类型
        /// <para>0：图标双击</para>
        /// <para>2：配置界面显示</para>
        /// <para>3：输出界面显示</para>
        /// <para>4：显示基元移除</para>
        /// <para>12：配置界面隐藏</para>
        /// <para>13：输出界面隐藏</para>
        /// </param>
        /// <param name="showName">显示名称</param>
        /// <param name="showGuid">Id</param>
        private void OnShowControlSelectClick(int type, string showName, Guid showGuid)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int, string, Guid>(OnShowControlSelectClick), new object[3] { type, showName, showGuid });
                return;
            }
            IShow show = ShowManager.Instance.GetShowByGUID(showGuid);
            if (show == null) return;

            switch (type)
            {
                case 0:
                    splUpDown.Panel2.Controls.Clear();
                    show.ConfigUi.Dock = DockStyle.Fill;
                    splUpDown.Panel2.Controls.Add(show.ConfigUi);
                    break;
                //配置界面显示
                case 2:
                    //Invoke(new Action(() =>
                    //{
                        
                    //}));
                    splUpDown.Panel2.Controls.Clear();
                    show.ConfigUi.Dock = DockStyle.Fill;
                    splUpDown.Panel2.Controls.Add(show.ConfigUi);
                    break;
                //输出界面显示
                case 3:
                    splUpDown.Panel2.Controls.Clear();
                    show.OutputUi.Dock = DockStyle.Fill;
                    splUpDown.Panel2.Controls.Add(show.OutputUi);
                    break;
                //移除
                case 4:
                    if (splUpDown.Panel2.Controls.Contains(show.ConfigUi))
                        splUpDown.Panel2.Controls.Remove(show.ConfigUi);
                    if (splUpDown.Panel2.Controls.Contains(show.OutputUi))
                        splUpDown.Panel2.Controls.Remove(show.OutputUi);
                    ShowDisplay showDisplay = _listShowDisplay.FirstOrDefault(s => s.UIShowID == showGuid);
                    if (showDisplay != null)
                    {
                        splLeftRight.Panel1.Controls.Remove(showDisplay);
                        _listShowDisplay.Remove(showDisplay);
                    }
                    ShowManager.Instance.RemoveShowByGUID(showGuid);
                    this.OnRemoveShow?.Invoke(showGuid);
                    break;
                //配置界面隐藏
                case 12:
                    if (splUpDown.Panel2.Controls.Contains(show.ConfigUi))
                        splUpDown.Panel2.Controls.Remove(show.ConfigUi);
                    break;
                //输出界面隐藏
                case 13:
                    if (splUpDown.Panel2.Controls.Contains(show.OutputUi))
                        splUpDown.Panel2.Controls.Remove(show.OutputUi);
                    break;
                default:
                    break;
            }
        }
        /// <summary>改变基元显示名称时发生响应</summary>
        /// <param name="showId">Id</param>
        /// <param name="showName">显示名称</param>
        private void OnShowControlChangeName(Guid showId, string showName)
        {
            OnChangeShowName?.Invoke(showId, showName);
        }
        #endregion
    }
}
