using Lead.CPrim.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSafty_StreamlineControl
{
    public class StreamlineControl
    {
        #region 下料时共用变量

        private static DateTime _ct_Time;
        private static object locker_ct_time = new object();
        public DateTime CT_Time
        {
            get
            {
                return _ct_Time;
            }
            set
            {
                lock (locker_ct_time)
                {
                    _ct_Time = value;
                }
            }
        }

        private static Dictionary<string, int> dic_ladTestCount = new Dictionary<string, int>();
        private static object locker_CheckDifferentSN = new object();

        /// <summary>
        /// 验证count_DifferentSN个不同SN的料，完成count_NeedTest次测试
        /// </summary>
        /// <param name="count_DifferentSN">不同SN的料</param>
        /// <param name="count_NeedTest">需要完成的次数</param>
        /// <returns></returns>
        public bool CheckDifferentSNCompeleted(int count_DifferentSN, int count_NeedTest)
        {
            lock (locker_CheckDifferentSN)
            {
                int count = 0;
                foreach (var element in dic_ladTestCount)
                {
                    if (element.Value >= count_NeedTest)
                    {
                        count++;
                        if (count >= count_DifferentSN)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int CheckDifferentSN_CountDifferentSN()
        {
            lock (locker_CheckDifferentSN)
            {
                return dic_ladTestCount.Count;
            }
        }

        public void CheckDifferentSN_AddSN(string sn)
        {
            lock (locker_CheckDifferentSN)
            {
                if (dic_ladTestCount.ContainsKey(sn))
                {
                    dic_ladTestCount[sn]++;
                }
                else
                {
                    dic_ladTestCount.Add(sn, 0);
                }
            }
        }

        public void CheckDifferentSN_ClearSN()
        {
            lock (locker_CheckDifferentSN)
            {
                dic_ladTestCount.Clear();
            }

        }

        #endregion


        #region 单例模式

        private readonly static List<StreamlineControl> _instance = new List<StreamlineControl>() { new StreamlineControl(), new StreamlineControl() };
        public static StreamlineControl Instance(int index)
        {
            if (index > 1 || index < 0)
            {
                return null;
            }
            return _instance[index];
        }

        #endregion

        private volatile static object locker = new object();
        private List<IEleDO> steps_IO_Run = new List<IEleDO>();
        private List<IEleDO> steps_IO_Direction = new List<IEleDO>();

        private bool IsRunning = false;

        /// <summary>
        /// 申请保持正转或保持停止
        /// </summary>
        private Dictionary<string, ApplyRunOrStop> dic_Apply = new Dictionary<string, ApplyRunOrStop>();


        public void SetStreamLineControlIO(ref IEleDO step_IO_Run, ref IEleDO step_IO_Direction)
        {
            steps_IO_Run.Clear();
            steps_IO_Run.Add(step_IO_Run);
            steps_IO_Direction.Clear();
            steps_IO_Direction.Add(step_IO_Direction);
        }
        public void SetStreamLineControlIO(ref IEleDO step1_IO_Run, ref IEleDO step1_IO_Direction, ref IEleDO step2_IO_Run, ref IEleDO step2_IO_Direction)
        {
            steps_IO_Run.Clear();
            steps_IO_Run.Add(step1_IO_Run);
            steps_IO_Run.Add(step2_IO_Run);
            steps_IO_Direction.Clear();
            steps_IO_Direction.Add(step1_IO_Direction);
            steps_IO_Direction.Add(step2_IO_Direction);
        }

        public void ClearApplyDic()
        {
            IsRunning = false;

            foreach (var item in dic_Apply)
            {
                item.Value.ApplyToRun = false;
                item.Value.ApplyToStop = false;
            }
        }

        public int PauseToRun()
        {
            foreach (var step_IO_Direction in steps_IO_Direction)
            {
                if (step_IO_Direction == null)
                {
                    return -1;
                }
            }

            foreach (var step_IO_Run in steps_IO_Run)
            {
                if (step_IO_Run == null)
                {
                    return -1;
                }
            }

            if (IsRunning)
            {
                //执行动作
                foreach (var step_IO_Direction in steps_IO_Direction)
                {
                    int ret = step_IO_Direction.Write(false);
                    if (ret != 0)
                    {
                        return ret - 10000;
                    }
                }

                foreach (var step_IO_Run in steps_IO_Run)
                {
                    int ret = step_IO_Run.Write(true);
                    if (ret != 0)
                    {
                        return ret - 10000;
                    }
                }
            }
            return 0;
        }

        public string GetApplyStatus()
        {
            StringBuilder sb = new StringBuilder(500);
            foreach (var item in dic_Apply)
            {
                sb.Append(item.Key);
                sb.Append(',');
                sb.Append(item.Value.Applicant);
                sb.Append(',');
                sb.Append(item.Value.ApplyToRun);
                sb.Append(',');
                sb.Append(item.Value.ApplyToStop);
                sb.Append(';');
            }
            return sb.ToString();
        }

        public int ApplyKeepRun(string applicant, bool flag)
        {

            foreach (var step_IO_Direction in steps_IO_Direction)
            {
                if (step_IO_Direction == null)
                {
                    return -1;
                }
            }

            foreach (var step_IO_Run in steps_IO_Run)
            {
                if (step_IO_Run == null)
                {
                    return -1;
                }
            }

            lock (locker)
            {
                if (!dic_Apply.ContainsKey(applicant))
                {
                    dic_Apply.Add(applicant, new ApplyRunOrStop() { Applicant = applicant });
                }

                //检查是否有申请保持停止
                foreach (var item in dic_Apply)
                {
                    if (item.Value.ApplyToStop)
                    {
                        return -2;
                    }
                }

                if (flag)//申请启动保持正转
                {
                    return ActionToKeepRun(applicant, flag);
                }
                else //申请解除保持正转
                {
                    //检查是否有其他申请保持
                    bool flag_Other = false;
                    foreach (var item in dic_Apply)
                    {
                        if (item.Key != applicant && item.Value.ApplyToRun)
                        {
                            flag_Other = true;
                            break;
                        }
                    }

                    //有其他的申请，标记
                    if (flag_Other)
                    {
                        dic_Apply[applicant].ApplyToRun = false;
                        return 0;
                    }

                    return ActionToKeepRun(applicant, flag);
                }
            }
        }
        private int ActionToKeepRun(string applicant, bool flag_Run)
        {
            foreach (var step_IO_Direction in steps_IO_Direction)
            {
                if (step_IO_Direction == null)
                {
                    return -1;
                }
            }

            foreach (var step_IO_Run in steps_IO_Run)
            {
                if (step_IO_Run == null)
                {
                    return -1;
                }
            }

            //执行动作
            foreach (var step_IO_Direction in steps_IO_Direction)
            {
                int ret = step_IO_Direction.Write(false);
                if (ret != 0)
                {
                    return ret - 10000;
                }
            }

            foreach (var step_IO_Run in steps_IO_Run)
            {
                int ret = step_IO_Run.Write(flag_Run);
                if (ret != 0)
                {
                    return ret - 10000;
                }
            }

            //标记
            dic_Apply[applicant].ApplyToRun = flag_Run;
            return 0;
        }
        private int ActionToKeepStop(string applicant, bool flag_Stop)
        {
            foreach (var step_IO_Direction in steps_IO_Direction)
            {
                if (step_IO_Direction == null)
                {
                    return -1;
                }
            }

            foreach (var step_IO_Run in steps_IO_Run)
            {
                if (step_IO_Run == null)
                {
                    return -1;
                }
            }

            //执行动作
            if (flag_Stop)
            {
                foreach (var step_IO_Direction in steps_IO_Direction)
                {
                    int ret = step_IO_Direction.Write(!flag_Stop);
                    if (ret != 0)
                    {
                        return ret - 10000;
                    }
                }

                foreach (var step_IO_Run in steps_IO_Run)
                {
                    int ret = step_IO_Run.Write(!flag_Stop);
                    if (ret != 0)
                    {
                        return ret - 10000;
                    }
                }
            }

            //标记
            dic_Apply[applicant].ApplyToStop = flag_Stop;
            return 0;
        }
        private int ApplyKeepStop(string applicant, bool flag)
        {
            foreach (var step_IO_Direction in steps_IO_Direction)
            {
                if (step_IO_Direction == null)
                {
                    return -1;
                }
            }

            foreach (var step_IO_Run in steps_IO_Run)
            {
                if (step_IO_Run == null)
                {
                    return -1;
                }
            }

            lock (locker)
            {
                if (!dic_Apply.ContainsKey(applicant))
                {
                    dic_Apply.Add(applicant, new ApplyRunOrStop() { Applicant = applicant });
                }

                //检查是否有申请保持正转
                foreach (var item in dic_Apply)
                {
                    if (item.Value.ApplyToRun)
                    {
                        return -3;
                    }
                }

                return ActionToKeepStop(applicant, flag);
            }
        }
    }

    public class ApplyRunOrStop
    {
        public bool ApplyToRun { get; set; }
        public bool ApplyToStop { get; set; }
        public string Applicant { get; set; }

    }

    public static class GlobalControl
    {
        private static Dictionary<string, bool> dic_IsBusy = new Dictionary<string, bool>();
        private static object locker = new object();

        public static bool ApplyControl(string name)
        {
            lock (locker)
            {
                foreach (var item in dic_IsBusy)
                {
                    if (item.Value)
                    {
                        return false;
                    }
                }
                if (dic_IsBusy.ContainsKey(name))
                {
                    dic_IsBusy[name] = true;
                }
                else
                {
                    dic_IsBusy.Add(name, true);
                }
                return true;
            }
        }

        public static void FreeControl(string name)
        {
            lock (locker)
            {
                if (dic_IsBusy.ContainsKey(name))
                {
                    dic_IsBusy[name] = false;
                }
            }
        }
    }

    public class LADTestInfo
    {
        public int Mode { get; set; }
        public int Operator_ID { get; set; }
        public string TestSeriesID { get; set; }
    }
}
