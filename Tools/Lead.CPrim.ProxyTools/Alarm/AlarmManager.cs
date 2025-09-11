using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MongoDB.Bson.Serialization.Attributes;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools.Authority;

namespace Lead.CPrim.ProxyTools
{
    public class AlarmManager
    {
        #region Event

        public event Action<AlarmInfo> OnAlarm;

        public event Action<string> OnEarlyWarning;

        public event Action OnStatus;
        #endregion



        #region Field
        /// <summary>
        /// 插入、移除报警锁
        /// </summary>
        static readonly object _lockAlarm = new object();

        private static AlarmManager _instance;

        /// <summary>
        /// 警告界面缓存 string:报警代码
        /// </summary>
        private Dictionary<string, AlarmInfo> _alarmDict = new Dictionary<string, AlarmInfo>();

        /// <summary>
        /// 弹窗的报警信息
        /// </summary>
        private AlarmInfo _alarmInfoInDialog;

        /// <summary>
        /// 配置报警信息界面
        /// </summary>
        private AlarmInfoEx _configUI;

        /// <summary>
        /// 外置配置报警信息的文件路径
        /// </summary>
        private string _filePath = @"D:\Config\AlertConfig\AlertInfo.csv";

        private bool _isDisableEarlyAlarm;

        /// <summary>
        /// 保存所有报警信息
        /// </summary>
        private BindingList<AlarmInfo> _list;

        private UIWarnInfoEx _warnInfoUI;
        #endregion



        #region Prop
        /// <summary>
        /// 报警信息管理对象
        /// </summary>
        public static AlarmManager Instance
        {
            get
            {
                _instance ??= new AlarmManager();
                return _instance;
            }
        }

        public string ConfigFilePath => _filePath;

        /// <summary>
        /// 报警信息管理配置
        /// </summary>
        public AlarmInfoEx ConfigUI => _configUI;

        public bool IsDisableEarlyAlarm => _isDisableEarlyAlarm;

        public UIWarnInfoEx WarnInfoUI => _warnInfoUI;
        #endregion



        #region Ctor
        private AlarmManager()
        {
            if (!GetAlertConfigData(_filePath, out string msg))
            {
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_Controls_UIAlarmInfo_ErrMsg_ReadAlarmInfoFileFail", "读取报警配置文件失败:") + msg);
            }

            _configUI = new AlarmInfoEx(ref _list);
            _warnInfoUI = new UIWarnInfoEx();
        }
        #endregion



        #region MethodExternalUsing
        public void ClearAlarmInfoInDialog()
        {
            _alarmInfoInDialog = null;
        }

        public AlarmInfo GetAlarmInfoByErrorMessage(string errorMessage)
        {
            int startIndex = errorMessage.IndexOf('(');
            int endIndex = errorMessage.IndexOf(')');

            string str_errCode = "";
            if (startIndex != -1 && endIndex != -1)
            {
                str_errCode = errorMessage.Substring(startIndex + 1, endIndex - startIndex - 1);
            }

            AlarmInfo alarmInfo = _list?.FirstOrDefault(x => x.ErrorCode == str_errCode || x.ErrorDetail.Contains(errorMessage) || errorMessage.Contains(x.ErrorDetail));
            if (alarmInfo == null)
            {
                return null;
            }

            alarmInfo.LastTime = DateTime.Now;
            var alarmInfoForDisply = DeepCopy(alarmInfo);

            if (alarmInfo.HasParams)
            {
                string[] param = GetSubString(errorMessage);
                if (param != null && param.Length > 0)
                {
                    alarmInfoForDisply.ErrorDetail = alarmInfo.ErrorDetail.Format(param);
                    alarmInfoForDisply.ErrorDetailInEN = alarmInfo.ErrorDetailInEN.Format(param);
                    alarmInfoForDisply.ErrorDetailInVN = alarmInfo.ErrorDetailInVN.Format(param);
                }
            }

            return alarmInfoForDisply;
        }

        public AlarmInfo GetAlarmInfoInDialog()
        {
            if (_alarmInfoInDialog == null)
            {
                return null;
            }
            return DeepCopy(_alarmInfoInDialog);
        }

        public string[] GetSubString(string input)
        {
            var items = Regex.Matches(input, "(\\[).+?(\\])");
            if (items != null && items.Count > 0)
            {
                string[] strs = new string[items.Count];
                for (int i = 0; i < items.Count; i++)
                {
                    strs[i] = items[i].ToString().Trim('[', ']');
                }
                return strs;
            }
            return null;
        }

        /// <summary>
        /// 插入报警信息
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="parameters"></param>
        public void InsertAlarm(string errorMessage, params string[] parameters)
        {
            lock (_lockAlarm)
            {
                try
                {
                    //步骤1：检查是否有（）,有查报警代码；没有，全字符比对，在查报警代码；没有报警代码直接跳过
                    AlarmInfo alarmInfo = GetAlarmInfo(errorMessage);
                    if (alarmInfo == null)
                    {
                        return;
                    }
                    alarmInfo.LastTime = DateTime.Now;

                    //步骤2: 深拷贝报警信息，用于显示和保存
                    AlarmInfo alarmInfoForDisply = DeepCopy(alarmInfo);

                    //步骤3：步骤3：参数替换
                    if (alarmInfo.HasParams)
                    {
                        string[] param = GetSubString(errorMessage);
                        if (param != null && param.Length > 0)
                        {
                            alarmInfoForDisply.ErrorDetail = alarmInfo.ErrorDetail.Format(param);
                            alarmInfoForDisply.ErrorDetailInEN = alarmInfo.ErrorDetailInEN.Format(param);
                            alarmInfoForDisply.ErrorDetailInVN = alarmInfo.ErrorDetailInVN.Format(param);
                        }
                    }

                    //步骤4：判定报警级别：1级直接DT；2级当[当前报警次数]大于等于[报警阈值次数]，DT、否则只记录；3级提示报警
                    switch (alarmInfo.ErrorLevel)
                    {
                        case ErrorLevel.一级报警:
                            {
                                EventManager.SwitchStatus(SwitchStatus.Abnormal);
                            }
                            break;

                        case ErrorLevel.二级报警:
                            {
                                if (alarmInfo.Algorithm.Check(false) == 0)
                                {
                                    return;
                                }
                                EventManager.SwitchStatus(SwitchStatus.Abnormal);
                            }
                            break;
                        case ErrorLevel.三级报警:
                        default:
                            {
                                if (alarmInfo.Algorithm.Check(false) == 0)
                                {
                                    return;
                                }
                            }
                            break;
                    }

                    //步骤5：弹窗
                    if (_alarmInfoInDialog == null)
                    {
                        _alarmInfoInDialog = alarmInfoForDisply;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogAdd(LogLevel.Warn, $"AlarmManager.InsertAlarm：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
                }
            }
        }

        /// <summary>
        /// 清除主界面->供应商->警告界面对应报警代码的报警信息
        /// </summary>
        /// <param name="errorMessage"></param>
        public void RemoveWarnInfoInUI(string errorMessage)
        {
            lock (_lockAlarm)
            {
                try
                {
                    //步骤1：检查是否有（）有，查报警代码；没有，全字符比对，在查报警代码；没有报警代码直接跳过
                    AlarmInfo alarmInfo = GetAlarmInfo(errorMessage);
                    if (alarmInfo == null)
                    {
                        return;
                    }

                    //步骤3：判定报警级别：1级直接DT；2级当[当前报警次数]大于等于[报警阈值次数]，DT、否则只记录；3级提示报警
                    switch (alarmInfo.ErrorLevel)
                    {
                        case ErrorLevel.二级报警:
                            if (alarmInfo.AlarmCount < alarmInfo.CumulativeThreshold)
                            {
                                //alarmInfo.AlarmCount++;
                                return;
                            }
                            else
                            {
                                //alarmInfo.AlarmCount = 0;
                            }
                            break;
                        case ErrorLevel.三级报警:
                            if (alarmInfo.AlarmCount < alarmInfo.CumulativeThreshold)
                            {
                                //alarmInfo.AlarmCount++;
                                return;
                            }
                            else
                            {
                                //alarmInfo.AlarmCount = 0;
                            }

                            if (_alarmDict.ContainsKey(alarmInfo.ErrorCode))
                            {
                                _alarmDict.Remove(alarmInfo.ErrorCode);
                                _warnInfoUI.RemoveInfo(alarmInfo);
                            }

                            return;

                        case ErrorLevel.一级报警:
                        default:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogAdd(LogLevel.Warn, $"AlarmManager.RemoveWarnInfoInUI：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
                }
            }
        }

        public int Save()
        {
            int result = _configUI.Save();
            if (result == 0)
            {
                UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_Language_LanguageConfigSaveSuccess", "语言配置保存成功"));
            }
            return result;
        }

        public void ShowAlert(AlarmInfo alarmInfo)
        {
            _alarmInfoInDialog = alarmInfo ?? throw new ArgumentNullException("显示报警弹窗时，传入报警信息为空");
            OnAlarm?.Invoke(_alarmInfoInDialog);
        }

        public void ShowEarlyWarning(string info)
        {
            if (!string.IsNullOrWhiteSpace(info))
            {
                OnEarlyWarning?.Invoke(info);
            }
        }

        internal void SetEarlyWarning(bool enable)
        {
            if (_isDisableEarlyAlarm != enable)
            {
                _isDisableEarlyAlarm = enable;
            }
        }

        private static T DeepCopy<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, obj);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        private AlarmInfo GetAlarmInfo(string errorMessage)
        {
            int startIndex = errorMessage.IndexOf('(');
            int endIndex = errorMessage.IndexOf(')');

            string str_errCode = "";
            if (startIndex != -1 && endIndex != -1)
            {
                str_errCode = errorMessage.Substring(startIndex + 1, endIndex - startIndex - 1);
            }

            return _list?.FirstOrDefault(x => x.ErrorCode == str_errCode || x.ErrorDetail.Contains(errorMessage) || errorMessage.Contains(x.ErrorDetail));
        }

        private bool GetAlertConfigData(string path, out string msg)
        {
            msg = string.Empty;
            try
            {
                CsvHelper.ReadCsvToListString(path, GlobalVariables.EncodingChinese, false, out List<string> data);
                if (data.IsNullOrEmpty())
                {
                    msg = "Read csv File is null";
                    return false;
                }
                data.RemoveAt(0);
                Dictionary<string, AlarmInfo> AlertConfigDatas = new Dictionary<string, AlarmInfo>();

                AlertConfigDatas.Clear();
                foreach (string info in data)
                {
                    string[] tmp = info.Trim().Split(',');
                    if (tmp == null || tmp.Count() < 15 || string.IsNullOrWhiteSpace(tmp[0]))
                    {
                        continue;
                    }

                    AlarmInfo alertConfigData = new AlarmInfo
                    {
                        ErrorCode = tmp[0].Trim(),
                        ErrorLevelInEN = tmp[1].Trim(),
                        ErrorMessage = tmp[2].Trim(),
                        ErrorDetail = tmp[3].Trim(),
                        ErrorDetailInEN = tmp[4].Trim(),
                        ErrorDetailInVN = tmp[5].Trim(),
                        //AlarmCount = tmp[6].ToInt(),
                        CumulativeThreshold = tmp[7].ToInt(),
                        ErrorLevel = Enum.TryParse(tmp[8].Trim(), out ErrorLevel level) ? level : ErrorLevel.三级报警,
                        PromptMethod = tmp[9].Trim(),
                        Solution = tmp[10].Trim(),
                        SolutionInEN = tmp[11].Trim(),
                        SolutionInVN = tmp[12].Trim(),
                        HasParams = tmp[13].ToBoolean(),
                        Sequence = tmp[14].ToUShort(),
                    };

                    if (!AlertConfigDatas.ContainsKey(tmp[0]))
                    {
                        AlertConfigDatas.Add(tmp[0], alertConfigData);
                    }
                }

                _list = new BindingList<AlarmInfo>(AlertConfigDatas.Values.ToList());
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 插入报警信息
        /// </summary>
        /// <param name="result"></param>
        /// <param name="vendorAlarmCode"></param>
        /// <param name="errorMessage"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool InsertAlarm(bool result, string vendorAlarmCode, string errorMessage, params string[] parameters)
        {
            lock (_lockAlarm)
            {
                bool ret = false;

                try
                {
                    //步骤1：报警匹配
                    int startIndex = errorMessage.IndexOf('(');
                    int endIndex = errorMessage.IndexOf(')');
                    string errorCode = "";
                    if (startIndex != -1 && endIndex != -1)
                    {
                        errorCode = errorMessage.Substring(startIndex + 1, endIndex - startIndex - 1);
                    }

                    AlarmInfo alarmInfo = _list?.FirstOrDefault(x =>
                    x.VendorAlarmCode == vendorAlarmCode ||
                    x.ErrorCode == errorCode ||
                    x.ErrorDetail.Contains(errorMessage) ||
                    errorMessage.Contains(x.ErrorDetail));
                    if (alarmInfo == null)
                    {
                        alarmInfo = new AlarmInfo()
                        {
                            VendorAlarmCode = vendorAlarmCode,
                            ErrorMessage = errorMessage,
                            ErrorLevel = ErrorLevel.三级报警,
                        };
                    }
                    alarmInfo.LastTime = DateTime.Now;

                    //步骤2: 报警拷贝
                    AlarmInfo alarmInfoForDisply = DeepCopy(alarmInfo);

                    //步骤3：参数替换
                    if (parameters != null && parameters.Length > 0)
                    {
                        alarmInfoForDisply.ErrorDetail = alarmInfo.ErrorDetail.Format(parameters);
                        alarmInfoForDisply.ErrorDetailInEN = alarmInfo.ErrorDetailInEN.Format(parameters);
                        alarmInfoForDisply.ErrorDetailInVN = alarmInfo.ErrorDetailInVN.Format(parameters);
                    }

                    //步骤4：判定报警级别
                    switch (alarmInfo.ErrorLevel)
                    {
                        case ErrorLevel.二级报警:
                            if (alarmInfo.Algorithm.Check(result) == 0)
                            {
                                return true;
                            }
                            break;

                        case ErrorLevel.三级报警:
                            if (alarmInfo.Algorithm.Check(result) == 0)
                            {
                                return true;
                            }
                            break;

                        case ErrorLevel.一级报警:
                        default:
                            break;
                    }

                    //步骤5：弹窗
                    if (_alarmInfoInDialog == null)
                    {
                        _alarmInfoInDialog = alarmInfoForDisply;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogAdd(LogLevel.Warn, $"AlarmManager.InsertAlarm：{ex.Message}：{ex.StackTrace}", LogClassification.Tools.ToString());
                }

                return ret;
            }
        }
        #endregion
    }
}