using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;

namespace Lead.CPrim.CommonParam
{
    public partial class CommonParamForm
    {
        private ParameterUiBinding parameterBinding;
        public XElement ParameterSnapshot { get { FlushParameterAssignments(); return CurrentParameterDocument(); } }
        public long ParameterVersion { get { return ((CommonParam)CommonParam.Instance).Updates.Version; } }
        public void FlushParameterAssignments() { parameterBinding?.Flush(); }
        private void RefreshAssignedPoints()
        {
            DicPos.Clear(); DicCartesian.Clear();
            foreach (Property p in Pmcls)
            {
                var positions = p.Value as System.Collections.Generic.List<Lead.CPrim.Interfaces.Ele.Pos>;
                if (positions == null) continue;
                DicPos[p.DisplayName] = positions; DicCartesian[p.DisplayName] = p.Cartesian;
            }
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
            CommonParam.OnUpdateProperty -= InstanceUpdateProperty;
            base.OnFormClosed(e);
        }
    }
}
