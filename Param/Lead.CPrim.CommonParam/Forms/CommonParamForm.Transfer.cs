using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.CommonParam
{
    public partial class CommonParamForm
    {
        public Func<string, ParameterTransferSession> CreateTransferSession { get; set; }
        private string transferBaseline;
        public bool ParameterEditingAllowed { get { return tsTitle.Enabled && pg.Enabled; } }
        public bool HasUnsavedParameterChanges
        {
            get { return transferBaseline == null || transferBaseline != ParameterTransferSession.ValueSnapshot(Pmcls.Cast<Property>()); }
        }
        private void CaptureTransferBaseline()
        {
            transferBaseline = ParameterTransferSession.ValueSnapshot(Pmcls.Cast<Property>());
        }
        /// <summary>仅刷新已提交内容，不写文件、不触发模式切换。</summary>
        public void RefreshTransferredParameters(XElement document)
        {
            ParameterTransferSession.ValidateDocument(document);
            CommonParam.Instance.Load(new XElement(document));
            Pmcls.Clear();
            foreach (var item in document.Elements()) Pmcls.Add((Property)item);
            OnLanguageChanged();
            OnHiveChangeToDT(HiveManagerV3.Instance.GetCurrentHiveStatus() == HiveStatus.DT);
            DicPos.Clear();
            DicCartesian.Clear();
            foreach (Property property in Pmcls)
            {
                var positions = property.Value as List<Pos>;
                if (positions == null) continue;
                DicPos[property.DisplayName] = positions;
                DicCartesian[property.DisplayName] = property.Cartesian;
            }
            pg.SelectedObject = Pmcls;
            pg.Refresh();
            CaptureTransferBaseline();
        }
    }
}
