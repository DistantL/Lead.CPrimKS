/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: UIDropEditor.cs
 * Author: Victor
 * Description: 控件属性编辑面板基类
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * 2020-01-01: V2.2.0 增加文件说明
 *
 * 3.3.22.0728 -> 
 * <Author> (Victor)    <Time> (20220807)
 * 1、增加文件说明
 * 2、命名空间变更为Lead.CPrim.ProxyTools.SunnyUI.Controls.TypeEditor
******************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 提供设置的编辑器 <see cref="P:System.Windows.Forms.ToolStripStatusLabel.RectSides" /> 属性。
    /// </summary>
    [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public abstract class UIDropEditor : UITypeEditor
    {
        protected UIDropEditorUI EditorUI;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (service != null)
                {
                    if (EditorUI == null)
                    {
                        EditorUI = CreateUI();
                    }

                    EditorUI.Start(service, value);
                    service.DropDownControl(EditorUI);
                    if (EditorUI.Value != null)
                    {
                        value = EditorUI.Value;
                    }

                    EditorUI.End();
                }
            }

            return value;
        }

        protected abstract UIDropEditorUI CreateUI();

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }

    public abstract class UIDropEditorUI : UserControl
    {
        #region Field
        private IWindowsFormsEditorService edSvc;
        protected object currentValue;
        protected bool updateCurrentValue;
        #endregion


        #region Prop
        public object Value => currentValue;
        public IWindowsFormsEditorService EditorService => edSvc;
        #endregion


        #region Method
        public void Start(IWindowsFormsEditorService editorService, object value)
        {
            edSvc = editorService;
            currentValue = value;
            InitValue(value);
            updateCurrentValue = true;
        }
        public void End()
        {
            edSvc = null;
            currentValue = null;
            updateCurrentValue = false;
        }
        #endregion


        #region Method_Abstract
        protected abstract void InitValue(object value);
        protected abstract void UpdateCurrentValue();
        #endregion
    }
}