using System;
using System.Linq;
using Lead.CPrim.BaseParam;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.DynamicParam
{
    public partial class DynamicParamForm
    {
        private static bool IsStationSwitch(string name)
        {
            return name == "启用工位1" || name == "启用工位2" || name == "启用工位3" || name == "启用工位4";
        }

        private void StationSwitchHiveStateChanged(StateInfo info, HiveTrigger trigger)
        {
            RefreshStationSwitchProtection();
        }

        private void RefreshStationSwitchProtection()
        {
            if (IsDisposed || Disposing || !IsHandleCreated) return;
            if (InvokeRequired)
            {
                try { BeginInvoke(new Action(RefreshStationSwitchProtection)); }
                catch (InvalidOperationException) { /* 窗口关闭过程中不再派发。 */ }
                return;
            }
            // 派发到 UI 后读取最新状态，避免旧的 DT 通知解锁新状态下的参数。
            ApplyStationSwitchReadOnly(HiveManagerV3.Instance.GetCurrentHiveStatus() == HiveStatus.DT);
            pg.Refresh();
            _modeGrid.Refresh();
        }

        private void ApplyStationSwitchReadOnly(bool isDt)
        {
            var modeNames = _modeProperties.Cast<Property>().Select(p => p.Name).ToArray();
            foreach (Property property in Pmcls)
                if (IsStationSwitch(property.Name))
                    property.ReadOnly = !isDt || !property.Visible || modeNames.Contains(property.Name);
            foreach (Property property in _modeProperties)
                if (IsStationSwitch(property.Name))
                    property.ReadOnly = !isDt || !property.Visible;
            // 页面 Enabled/权限控制仍由原有 UIShow 与权限事件负责，不在此放开。
        }
    }
}
