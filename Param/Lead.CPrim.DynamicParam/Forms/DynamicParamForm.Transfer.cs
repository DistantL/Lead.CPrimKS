using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.DynamicParam
{
    public partial class DynamicParamForm
    {
        public Func<string, ParameterTransferSession> CreateTransferSession { get; set; }
        public string[] ProductModePaths
        {
            get { return Enum.GetNames(typeof(运行模式)).Select(mode => ProductModeFiles.ModePath(_productsCfgDir, _activeProduct, mode)).ToArray(); }
        }
        public void ValidateTransferOutName(string name)
        {
            foreach (var path in ProductModePaths)
            {
                if (!File.Exists(path)) continue;
                if (XElement.Load(path).Elements().Any(p => p.Name.LocalName == name || (string)p.Element("Name") == name))
                    throw new InvalidOperationException("参数“" + name + "”仍被模式文件引用，请先从对应模式参数中移除并保存：\n" + path);
            }
        }
        private string transferBaseline;
        private string transferModeBaseline;
        public string ActiveProduct { get { return _activeProduct; } }
        public string ActiveParameterPath { get { return _curParaPath; } }
        public string ActiveModePath { get { return ProductModeFiles.ModePath(_productsCfgDir, _activeProduct, _currentMode); } }
        public Func<bool> CanSaveParameters { get; set; }
        public bool ParameterEditingAllowed { get { return tsTitle.Enabled && pg.Enabled && (CanSaveParameters?.Invoke() ?? true); } }
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
            var normalized = PrepareParameterDocument(product);
            ParameterTransferSession.ValidateDocument(ProductModeFiles.Apply(normalized, CurrentModeValues()));
            product.ReplaceNodes(normalized.Nodes());
        }
        /// <summary>刷新提交结果；不重新应用模式覆盖。</summary>
        public void RefreshTransferredParameters(XElement product)
        {
            ProductModeFiles.Apply(product, CurrentModeValues()); // 仅验证模式引用，不应用旧值。
            var merged = PrepareParameterDocument(product);
            ParameterTransferSession.ValidateDocument(merged);
            DynamicParam.Instance.LoadSnapshot(new XElement(merged), _curParaPath);
            UpdateUi(merged);
            BtnRefresh_Click(null, null);
            RefreshModeEditor();
            parameterBinding.AcceptLoaded();
            CaptureTransferBaseline();
        }
    }
}
