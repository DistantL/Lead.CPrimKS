using System;
using System.Linq;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;

namespace Lead.CPrim.DynamicParam
{
    public partial class DynamicParamForm
    {
        private string transferBaseline;
        private string transferModeBaseline;
        public string ActiveProduct { get { return _activeProduct; } }
        public string ActiveParameterPath { get { return _curParaPath; } }
        public string ActiveModePath { get { return ProductModeFiles.ModePath(_productsCfgDir, _activeProduct, _currentMode); } }
        public bool ParameterEditingAllowed { get { return tsTitle.Enabled && pg.Enabled; } }
        public bool HasUnsavedParameterChanges
        {
            get
            {
                return transferBaseline == null
                    || transferBaseline != ParameterTransferSession.ValueSnapshot(Pmcls.Cast<Property>())
                    || transferModeBaseline != ParameterTransferSession.ValueSnapshot(_modeProperties.Cast<Property>());
            }
        }
        private void CaptureTransferBaseline()
        {
            transferBaseline = ParameterTransferSession.ValueSnapshot(Pmcls.Cast<Property>());
            transferModeBaseline = ParameterTransferSession.ValueSnapshot(_modeProperties.Cast<Property>());
        }
        public void ValidateTransferredParameters(XElement product)
        {
            ParameterTransferSession.ValidateDocument(ProductModeFiles.Apply(product, CurrentModeValues()));
        }
        /// <summary>刷新提交结果；不调用会写回产品文件的 LoadProductMode。</summary>
        public void RefreshTransferredParameters(XElement product)
        {
            var merged = ProductModeFiles.Apply(product, CurrentModeValues());
            ParameterTransferSession.ValidateDocument(merged);
            DynamicParam.Instance.Load(new XElement(merged));
            UpdateUi(merged);
            BtnRefresh_Click(null, null);
            RefreshModeEditor();
            CaptureTransferBaseline();
        }
    }
}
