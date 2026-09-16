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
            return CreateParameterTransferSession(sourcePath, false);
        }

        private ParameterTransferSession CreateGlobalParameterTransferSession(string sourcePath)
        {
            return CreateParameterTransferSession(sourcePath, true);
        }

        private ParameterTransferSession CreateParameterTransferSession(string sourcePath, bool toGlobal)
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
            common.FlushParameterAssignments();
            _dynamicParamForm.FlushParameterAssignments();
            checkEditable();
            long globalVersion = common.ParameterVersion;
            long productVersion = _dynamicParamForm.ParameterVersion;
            string product = _dynamicParamForm.ActiveProduct;
            string productPath = _dynamicParamForm.ActiveParameterPath;
            string globalPath = common.ActiveParameterPath;
            string target = toGlobal ? globalPath : productPath;
            if (string.IsNullOrWhiteSpace(product) || string.IsNullOrWhiteSpace(target))
                throw new InvalidOperationException("当前产品参数尚未加载。");
            if (!string.Equals(Path.GetFullPath(sourcePath), Path.GetFullPath(toGlobal ? productPath : globalPath), StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("参数编辑路径与当前已加载路径不一致。");
            string modePath = _dynamicParamForm.ActiveModePath;

            var modeSnapshots = (toGlobal ? _dynamicParamForm.ProductModePaths : new[] { modePath })
                .ToDictionary(path => path, path => File.Exists(path) ? File.ReadAllBytes(path) : null);
            var session = new ParameterTransferSession(sourcePath, target, product, toGlobal);
            session.SetViewSnapshots(toGlobal ? _dynamicParamForm.ParameterSnapshot : common.ParameterSnapshot,
                toGlobal ? common.ParameterSnapshot : _dynamicParamForm.ParameterSnapshot);
            session.CommitGuard = commit =>
            {
                lock (((Lead.CPrim.CommonParam.CommonParam)Lead.CPrim.CommonParam.CommonParam.Instance).Updates.SyncRoot)
                lock (((Lead.CPrim.DynamicParam.DynamicParam)Lead.CPrim.DynamicParam.DynamicParam.Instance).Updates.SyncRoot)
                    commit();
            };
            session.ValidateContext = () =>
            {
                if (globalVersion != common.ParameterVersion || productVersion != _dynamicParamForm.ParameterVersion)
                    throw new InvalidOperationException("脚本已修改参数，请关闭编辑器并重新打开。");
                checkEditable();
                if (product != _dynamicParamForm.ActiveProduct || product != SwManager.Instance.CurrentProduct
                    || !string.Equals(productPath, _dynamicParamForm.ActiveParameterPath, StringComparison.OrdinalIgnoreCase)
                    || !string.Equals(globalPath, common.ActiveParameterPath, StringComparison.OrdinalIgnoreCase)
                    || !string.Equals(modePath, _dynamicParamForm.ActiveModePath, StringComparison.OrdinalIgnoreCase)
                    )
                    throw new InvalidOperationException("产品、模式或模式文件已变化，请放弃当前编辑并重新打开。");
                foreach (var snapshot in modeSnapshots)
                    if (snapshot.Value == null ? File.Exists(snapshot.Key)
                        : !File.Exists(snapshot.Key) || !File.ReadAllBytes(snapshot.Key).SequenceEqual(snapshot.Value))
                        throw new InvalidOperationException("模式文件已变化，请重新打开编辑器：" + snapshot.Key);
            };
            if (toGlobal) session.ValidateTransferName = _dynamicParamForm.ValidateTransferOutName;
            session.ValidateDocuments = (source, destination) =>
            {
                _dynamicParamForm.ValidateTransferredParameters(toGlobal ? source : destination);
            };
            session.RefreshCommitted = (source, destination) =>
            {
                common.RefreshTransferredParameters(toGlobal ? destination : source);
                _dynamicParamForm.RefreshTransferredParameters(toGlobal ? source : destination);
                globalVersion = common.ParameterVersion;
                productVersion = _dynamicParamForm.ParameterVersion;
            };
            session.CheckCurrent();
            return session;
        }
    }
}
