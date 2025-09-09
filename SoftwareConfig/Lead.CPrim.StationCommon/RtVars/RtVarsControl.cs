using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.StationCommon.RtVars
{
	/// <summary>实时变量UI集合</summary>
	public partial class RtVarsControl : UserControl
	{
        #region Field
        /// <summary>实时变量集合管理器</summary>
        private RtDataVars _rtDataVars;
        #endregion



        #region Ctor
        /// <summary>Ctor有1个参数</summary>
        /// <param name="rtDataVars">实时变量集合管理器</param>
        public RtVarsControl(RtDataVars rtDataVars)
        {
            InitializeComponent();
            _rtDataVars = rtDataVars;
        }
        #endregion



        #region System_Event
        /// <summary>Load事件</summary>
        private void RtVarsControl_Load(object sender, EventArgs e)
        {
            var list = _rtDataVars.DataVars.Keys.OrderBy(name => name);
            if(list == null)
            {
                return;
            }

            foreach (var item in list)
            {
                fLPanelVar.Controls.Add(_rtDataVars.DataVars[item].ShowControl);
            }
        }
        #endregion



        #region Others
        /// <summary>实时变量增加</summary>
        /// <param name="varName">实时变量名称</param>
        public void AddVar(string varName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(AddVar), varName);
                return;
            }

            if (!_rtDataVars.DataVars.ContainsKey(varName))
            {
                _rtDataVars.DataVars.TryAdd(varName, new RtDataVar(varName, DataType.Other));
            }
            if (!fLPanelVar.Controls.Contains(_rtDataVars.DataVars[varName].ShowControl))
            {
                ((VarControl)_rtDataVars.DataVars[varName].ShowControl).SetVarName(varName);
                fLPanelVar.Controls.Add(_rtDataVars.DataVars[varName].ShowControl);
            }
        }
        /// <summary>实时变量值更新</summary>
        /// <param name="varName">实时变量名称</param>
        /// <param name="obj">值</param>
        private void UpdateVarInfo(string varName, object obj)
        {
            if (_rtDataVars.DataVars.ContainsKey(varName))
            {
                ((VarControl)_rtDataVars.DataVars[varName].ShowControl).SetVarValue(obj);
            }
        }
        /// <summary>实时变量值更新</summary>
        /// <param name="varName">实时变量名称</param>
        /// <param name="obj">值</param>
        public void UpdateVars(string varName, object obj)
        {
            if (base.InvokeRequired)
            {
                BeginInvoke(new Action<string, object>(UpdateVars), varName, obj);
            }
            else
            {
                UpdateVarInfo(varName, obj);
            }
        }
        /// <summary>实时变量UI清除</summary>
        public void VarControlClear()
        {
            ControlHelper.RemoveControl(fLPanelVar, null);
        } 
        #endregion
    }
}
