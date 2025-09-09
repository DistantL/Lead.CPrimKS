using Lead.CPrim.Interfaces;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Authority
{
    public class HiveManager
    {
        #region Event_Define
        /// <summary>
        /// Hive状态改变时发生
        /// </summary>
        public static event Action<string> OnHiveChange;

        public static event Action<bool> OnHiveStatusChangeToDT;
        #endregion



        #region Field
        /// <summary>
        /// Hive系统计时
        /// </summary>
        private static Dictionary<HiveStatus, DateTime> _dicStates = new Dictionary<HiveStatus, DateTime>();

        private static HiveStatus _currentHiveState = 0;
        private static HiveStatus _lastHiveState = 0;
        private static HiveStatus _manualSetHiveState = 0;

        private static bool hiveMode_Normal = true;
        private static bool hiveMode_Engineering = false;

        /// <summary>
        /// 计划停机选择项
        /// </summary>
        private static string _planedDowntimeSelect;

        /// <summary>
        /// Hive disable 或 disconnect 为 true
        /// </summary>
        private static bool _flag_HiveDisable = false;
        #endregion



        #region Ctor
        static HiveManager()
        {
            _dicStates.Add(HiveStatus.Running, DateTime.Now);
            _dicStates.Add(HiveStatus.Idle, DateTime.Now);
            _dicStates.Add(HiveStatus.Engineering, DateTime.Now);
            _dicStates.Add(HiveStatus.Plan_DT, DateTime.Now);
            _dicStates.Add(HiveStatus.DT, DateTime.Now);

            var result = GetLastHiveStatusInfo();
            if (result != null)
            {
                switch (result.ChangeToStatus)
                {
                    case HiveStatus.Idle:
                        {
                            _lastHiveState = result.Status;
                            _currentHiveState = result.ChangeToStatus;
                            break;
                        }
                    case HiveStatus.Running:
                        {
                            _lastHiveState = result.Status;
                            _currentHiveState = result.ChangeToStatus;
                            break;
                        }
                    case HiveStatus.Plan_DT:
                        {
                            _lastHiveState = result.Status;
                            _currentHiveState = result.ChangeToStatus;
                            break;
                        }
                    case HiveStatus.DT:
                        {
                            _lastHiveState = result.Status;
                            _currentHiveState = result.ChangeToStatus;
                            break;
                        }
                    case HiveStatus.Engineering:
                        {
                            hiveMode_Normal = false;
                            hiveMode_Engineering = true;
                            _lastHiveState = result.Status;
                            _currentHiveState = result.ChangeToStatus;
                            break;
                        }
                    default:
                        _lastHiveState = HiveStatus.Idle;
                        _currentHiveState = HiveStatus.Idle;
                        break;
                }
            }
            else
            {
                _lastHiveState = HiveStatus.Idle;
                _currentHiveState = HiveStatus.Idle;
            }
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 计划停机选择项
        /// </summary>
        public static string PlanedDowntimeSelect
        {
            get => _planedDowntimeSelect;
            set
            {
                if (_planedDowntimeSelect != value)
                {
                    _planedDowntimeSelect = value;
                    OnHiveChange?.Invoke(value);
                }
            }
        }

        public static void SetHiveStatusByManual(HiveStatus status)
        {
            if (ControlHiveState(status, _currentHiveState, true))
            {
                _manualSetHiveState = status;
            }
            else
            {
                UIMessageDialog.ShowMessageDialog($"手动从当前状态【{_currentHiveState}】切换到【{status}】失败", ULocalize.WarningTitle, false, SunnyUI.Style.UIStyle.Orange);
            }
        }

        public static HiveStatus GetCurrentHiveStatus()
        {
            return _currentHiveState;
        }

        public static StateInfo GetLastHiveStatusInfo()
        {
            try
            {
                IMongoCollection<StateInfo> collection = new MongoClient("mongodb://localhost:27017").GetDatabase("Lead", null).GetCollection<StateInfo>("StateMachinePcDb");
                SortDefinition<StateInfo> sort = Builders<StateInfo>.Sort.Descending("CreateTime");
                ProjectionDefinition<StateInfo> projection = Builders<StateInfo>.Projection.Exclude("_id");
                FilterDefinition<StateInfo> filter = Builders<StateInfo>.Filter.Empty;
                var document = collection.Find(filter).Project<StateInfo>(projection).Sort(sort).Limit(1);
                var result = document.ToList();
                if (result != null && result.Count > 0)
                {
                    return result[0];
                }
            }
            catch
            {
                UIMessageDialog.ShowMessageDialog("读取数据表【StateMachinePcDb】异常", ULocalize.ErrorTitle, false, SunnyUI.Style.UIStyle.Red);
            }

            return null;
        }


        public static HiveStatus GetManualChangeStatus(out bool changeFlag)
        {
            if (_manualSetHiveState != 0)
            {
                changeFlag = true;
            }
            else
            {
                changeFlag = false;
            }

            var result = _manualSetHiveState;
            _manualSetHiveState = 0;
            return result;
        }

        public static void SetHiveStatus(HiveStatus current, string tip)
        {
            HiveStatus last = _currentHiveState;

            DateTime now = DateTime.Now;
            if (!_dicStates.ContainsKey(current))
            {
                _dicStates.Add(current, now);
            }
            else
            {
                _dicStates[current] = now;
            }

            if (!_dicStates.ContainsKey(last))
            {
                _dicStates.Add(last, DateTime.Now);
                return;
            }

            string db = UIGlobal.StateMachinePcDb;
            _ = MongodbHelper.InsertOneAsync(new StateInfo
            {
                Status = last,
                Duration = (_dicStates[current] - _dicStates[last]).TotalMilliseconds / 60000,
                ChangeToStatus = current,
                Tip = tip
            }, db);

            _lastHiveState = _currentHiveState;
            _currentHiveState = current;
            if (_currentHiveState == HiveStatus.DT)
            {
                OnHiveStatusChangeToDT?.Invoke(true);
            }
            else
            {
                OnHiveStatusChangeToDT?.Invoke(false);
            }
        }

        public static void SetHiveDisable(bool flag)
        {
            _flag_HiveDisable = flag;
        }

        public static bool GetHiveDisableStatus()
        {
            return _flag_HiveDisable;
        }

        public static string GetHiveMode()
        {
            if (hiveMode_Engineering == true && hiveMode_Normal == false)
            {
                return "Engineering";
            }
            else
            {
                return "Normal";
            }
        }

        #endregion



        #region Method_InternalUsing

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetHiveState">目标状态</param>
        /// <param name="currentHiveState">当前状态</param>
        /// <param name="isManualSet"></param>
        /// <returns></returns>
        private static bool ControlHiveState(HiveStatus targetHiveState, HiveStatus currentHiveState, bool isManualSet)
        {
            if (currentHiveState == HiveStatus.DT)
            {
                string windowTitle = "DownTime报警弹窗"; // 替换为你想要检查的窗口标题
                IntPtr windowHandle = FindWindow(null, windowTitle);

                //从DT状态转其他状态时检查报警弹窗是否已经关闭
                if (windowHandle != IntPtr.Zero)
                {
                    UIMessageDialog.ShowMessageDialog("从DT状态转其他状态时，检查报警弹窗【DownTime报警弹窗】是否已经关闭", ULocalize.WarningTitle, false, SunnyUI.Style.UIStyle.Orange);
                    return false;
                }
            }

            switch (currentHiveState)
            {
                case HiveStatus.Running:
                    return DealWithRunning(targetHiveState, currentHiveState, isManualSet);
                case HiveStatus.Idle:
                    return DealWithIdle(targetHiveState, currentHiveState, isManualSet);
                case HiveStatus.Engineering:
                    return DealWithEngineering(targetHiveState, currentHiveState, isManualSet);
                case HiveStatus.Plan_DT:
                    return DealWithPlan_DT(targetHiveState, currentHiveState, isManualSet);
                case HiveStatus.DT:
                    return DealWithDT(targetHiveState, currentHiveState, isManualSet);
            }

            return false;
        }

        private static bool DealWithRunning(HiveStatus targetHiveState, HiveStatus currentHiveState, bool isManualSet)
        {
            switch (targetHiveState)
            {
                case HiveStatus.Idle:
                    //自动切换 由running下状态转换
                    //手动切换 必须Level3
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel3Permission(true))
                    {
                        return true;
                    }
                    if (!isManualSet)
                    {
                        return true;
                    }
                    break;
                case HiveStatus.Running:
                    //自动切换 All sensors arenot activity 90s to idle
                    //手动切换 无意义
                    break;
                case HiveStatus.Engineering:
                    //自动切换 禁止
                    //手动切换 禁止
                    break;
                case HiveStatus.DT:
                    //必须包含报警信息
                    //自动切换
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        return true;
                    }
                    if (!isManualSet)
                    {
                        return true;
                    }
                    break;
                case HiveStatus.Plan_DT:
                    //自动切换 Auto change to planned DT subjects to actual Apple AME approval status
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        private static bool DealWithIdle(HiveStatus targetHiveState, HiveStatus currentHiveState, bool isManualSet)
        {
            switch (targetHiveState)
            {
                case HiveStatus.Idle:
                    //自动切换 ( Under normal mode ) Auto change to running if machine is under running state and unit is coming.
                    //自动切换 ( Under engineering mode ) Auto change to running if machine is under running state and unit is coming.
                    //手动切换 无意义
                    break;
                case HiveStatus.Running:
                    //自动切换 由idle下状态转换
                    //手动切换 必须Level3
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel3Permission(true))
                    {
                        hiveMode_Normal = true;
                        hiveMode_Engineering = false;
                        return true;
                    }
                    if (!isManualSet)
                    {
                        hiveMode_Normal = true;
                        hiveMode_Engineering = false;
                        return true;
                    }
                    break;
                case HiveStatus.Engineering:
                    //自动切换 由idle下状态转换
                    //手动切换 必须Level3
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel3Permission(true))
                    {
                        hiveMode_Normal = false;
                        hiveMode_Engineering = true;
                        return true;
                    }
                    if (!isManualSet)
                    {
                        hiveMode_Normal = false;
                        hiveMode_Engineering = true;
                        return true;
                    }
                    break;
                case HiveStatus.DT:
                    //必须包含报警信息
                    //自动切换
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        return true;
                    }
                    if (!isManualSet)
                    {
                        return true;
                    }
                    break;
                case HiveStatus.Plan_DT:
                    //自动切换 Auto change to planned DT subjects to actual Apple AME approval status
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        private static bool DealWithEngineering(HiveStatus targetHiveState, HiveStatus currentHiveState, bool isManualSet)
        {
            switch (targetHiveState)
            {
                case HiveStatus.Idle:
                    //自动切换 由Engineering下状态转换
                    //手动切换 必须Level3
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel3Permission(true))
                    {
                        return true;
                    }
                    if (!isManualSet)
                    {
                        return true;
                    }
                    break;
                case HiveStatus.Running:
                    //自动切换 禁止
                    //手动切换 禁止
                    return false;
                case HiveStatus.Engineering:
                    //自动切换 All sensors arenot activity 90s to idle
                    //手动切换 无意义
                    break;
                case HiveStatus.DT:
                    //必须包含报警信息
                    //自动切换
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        return true;
                    }
                    if (!isManualSet)
                    {
                        return true;
                    }
                    break;
                case HiveStatus.Plan_DT:
                    //自动切换 Auto change to planned DT subjects to actual Apple AME approval status
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        private static bool DealWithPlan_DT(HiveStatus targetHiveState, HiveStatus currentHiveState, bool isManualSet)

        {
            switch (targetHiveState)
            {
                case HiveStatus.Idle:
                    //自动切换 禁止
                    //手动切换 禁止
                    return false;
                case HiveStatus.Running:
                    //自动切换 禁止
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        hiveMode_Normal = true;
                        hiveMode_Engineering = false;
                        return true;
                    }
                    if (!isManualSet)
                    {
                        hiveMode_Normal = true;
                        hiveMode_Engineering = false;
                        return true;
                    }
                    break;
                case HiveStatus.Engineering:
                    //自动切换 禁止
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        hiveMode_Normal = false;
                        hiveMode_Engineering = true;
                        return true;
                    }
                    if (!isManualSet)
                    {
                        hiveMode_Normal = false;
                        hiveMode_Engineering = true;
                        return true;
                    }
                    break;
                case HiveStatus.DT:
                    //自动切换 禁止
                    //手动切换 禁止
                    return false;
                case HiveStatus.Plan_DT:
                    //自动切换 无意义
                    //手动切换 无意义
                    return false;
                default:
                    break;
            }
            return false;
        }

        private static bool DealWithDT(HiveStatus targetHiveState, HiveStatus currentHiveState, bool isManualSet)

        {
            switch (targetHiveState)
            {
                case HiveStatus.Idle:
                    //自动切换 禁止
                    //手动切换 禁止
                    return false;
                case HiveStatus.Running:
                    //自动切换 禁止
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        hiveMode_Normal = true;
                        hiveMode_Engineering = false;
                        return true;
                    }
                    if (!isManualSet)
                    {
                        hiveMode_Normal = true;
                        hiveMode_Engineering = false;
                        return true;
                    }
                    break;
                case HiveStatus.Engineering:
                    //自动切换 禁止
                    //手动切换 必须Level2
                    if (isManualSet && AuthorityManager.Instance.VerifyLevel2Permission(true))
                    {
                        hiveMode_Normal = false;
                        hiveMode_Engineering = true;
                        return true;
                    }
                    if (!isManualSet)
                    {
                        hiveMode_Normal = false;
                        hiveMode_Engineering = true;
                        return true;
                    }
                    break;
                case HiveStatus.DT:
                    //自动切换 无意义
                    //手动切换 无意义
                    return false;
                case HiveStatus.Plan_DT:
                    //自动切换 禁止
                    //手动切换 禁止
                    return false;
                default:
                    break;
            }
            return false;
        }
        #endregion
    }
}


/*
 * 2025-04015 25997
 * 1. function [DealWithDT] DT To Running Bug : miss sign hive_mode 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */