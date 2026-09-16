using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;

namespace Lead.CPrim.DynamicParam
{
    public partial class DynamicParamForm
    {
        private ParameterUiBinding parameterBinding;
        public XElement ParameterSnapshot { get { FlushParameterAssignments(); return CurrentParameterDocument(); } }
        public long ParameterVersion { get { return ((DynamicParam)DynamicParam.Instance).Updates.Version; } }
        public void FlushParameterAssignments() { parameterBinding?.Flush(); }
        private void RefreshAssignedPoints()
        {
            BtnRefresh_Click(null, null);
        }
        private XElement CurrentParameterDocument()
        {
            return new XElement("Para", Pmcls.Cast<Property>().Select(p => p.PropToXElment()));
        }
        private void ValidateEditorVersion(long version)
        {
            if (!ParameterEditingAllowed || ParameterVersion != version)
                throw new InvalidOperationException("运行状态或参数值已变化，请关闭编辑器并重新打开。");
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DynamicParam.OnUpdateProperty -= InstanceUpdateProperty;
            base.OnFormClosed(e);
        }
    }
}
