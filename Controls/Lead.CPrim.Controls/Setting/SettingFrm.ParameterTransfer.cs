using System;
using System.IO;
using System.Linq;
using Lead.CPrim.BaseParam;
using Lead.CPrim.CommonParam;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces.StateMachine;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.TaskHelper;

namespace Lead.CPrim.Controls
{
    public partial class SettingFrm
    {
        private ParameterTransferSession CreateParameterTransferSession(string sourcePath)
        {
            var common = CommonParamForm.Instance;
            Action checkEditable = () =>
            {
                if (!AuthorityManager.Instance.VerifyLevel3Permission(false)
                    || !common.ParameterEditingAllowed || !_dynamicParamForm.ParameterEditingAllowed
                    || TaskSmManger.Instance.TaskSMs.Any(p => p.Value.State == SmStates.Running))
                    throw new InvalidOperationException("当前权限或设备状态不允许转移参数。");
                if (common.HasUnsavedParameterChanges || _dynamicParamForm.HasUnsavedParameterChanges)
                    throw new InvalidOperationException("全局或换型参数页面存在未保存修改，请先保存，再重新进入编辑参数。");
            };
            checkEditable();
            string product = _dynamicParamForm.ActiveProduct;
            string target = _dynamicParamForm.ActiveParameterPath;
            if (string.IsNullOrWhiteSpace(product) || string.IsNullOrWhiteSpace(target))
                throw new InvalidOperationException("当前产品参数尚未加载。");
            string modePath = _dynamicParamForm.ActiveModePath;
            byte[] modeBytes = File.ReadAllBytes(modePath);
            var session = new ParameterTransferSession(sourcePath, target, product);
            session.ValidateContext = () =>
            {
                checkEditable();
                if (product != _dynamicParamForm.ActiveProduct || product != SwManager.Instance.CurrentProduct
                    || !string.Equals(target, _dynamicParamForm.ActiveParameterPath, StringComparison.OrdinalIgnoreCase)
                    || !string.Equals(modePath, _dynamicParamForm.ActiveModePath, StringComparison.OrdinalIgnoreCase)
                    || !File.ReadAllBytes(modePath).SequenceEqual(modeBytes))
                    throw new InvalidOperationException("产品、模式或模式文件已变化，请放弃当前编辑并重新打开。");
            };
            session.ValidateDocuments = (global, productDocument) =>
                _dynamicParamForm.ValidateTransferredParameters(productDocument);
            session.RefreshCommitted = (global, productDocument) =>
            {
                common.RefreshTransferredParameters(global);
                _dynamicParamForm.RefreshTransferredParameters(productDocument);
            };
            session.CheckCurrent();
            return session;
        }
    }
}
