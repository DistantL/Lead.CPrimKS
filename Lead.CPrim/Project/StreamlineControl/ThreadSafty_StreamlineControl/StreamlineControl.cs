using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace ThreadSafty_StreamlineControl
{
    public class Streamline1Control
    {
        #region 单例模式

        private readonly static Streamline1Control instance = new Streamline1Control();
        public static Streamline1Control Instance
        {
            get { return instance; }
        }

        #endregion

        private volatile static object locker = new object();
        private IEleDO step_IO_Run = null;
        private IEleDO step_IO_Direction = null;

        private bool IsRunning = false;

        /// <summary>
        /// 申请保持正转或保持停止
        /// </summary>
        private Dictionary<string, ApplyRunOrStop> dic_Apply = new Dictionary<string, ApplyRunOrStop>();


        public void SetStreamLineControlIO(ref IEleDO step_IO_Run, ref IEleDO step_IO_Direction)
        {
            this.step_IO_Run = step_IO_Run;
            this.step_IO_Direction = step_IO_Direction;
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
            if (IsRunning)
            {
                //执行动作
                int ret = step_IO_Direction.Write(false);
                if (ret != 0)
                {
                    return ret - 10000;
                }
                ret = step_IO_Run.Write(true);
                if (ret != 0)
                {
                    return ret - 10000;
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
            if (step_IO_Run == null || step_IO_Direction == null)
            {
                return -1;
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
            //执行动作
            int ret = step_IO_Direction.Write(false);
            if (ret != 0)
            {
                return ret - 10000;
            }
            ret = step_IO_Run.Write(flag_Run);
            if (ret != 0)
            {
                return ret - 10000;
            }

            //标记
            dic_Apply[applicant].ApplyToRun = flag_Run;
            return 0;
        }
        private int ActionToKeepStop(string applicant, bool flag_Stop)
        {
            //执行动作
            if (flag_Stop)
            {
                int ret = step_IO_Direction.Write(!flag_Stop);
                if (ret != 0)
                {
                    return ret - 10000;
                }
                ret = step_IO_Run.Write(!flag_Stop);
                if (ret != 0)
                {
                    return ret - 10000;
                }
            }

            //标记
            dic_Apply[applicant].ApplyToStop = flag_Stop;
            return 0;
        }
        public int ApplyKeepStop(string applicant, bool flag)
        {
            if (step_IO_Run == null || step_IO_Direction == null)
            {
                return -1;
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
                        return -2;
                    }
                }

                return ActionToKeepStop(applicant, flag);
            }

        }
    }

    public class Streamline2Control
    {
        #region 单例模式

        private readonly static Streamline2Control instance = new Streamline2Control();
        public static Streamline2Control Instance
        {
            get { return instance; }
        }

        #endregion

        private volatile static object locker = new object();
        private IEleDO step_IO_Run = null;
        private IEleDO step_IO_Direction = null;

        private bool IsRunning = false;

        /// <summary>
        /// 申请保持正转或保持停止
        /// </summary>
        private Dictionary<string, ApplyRunOrStop> dic_Apply = new Dictionary<string, ApplyRunOrStop>();


        public void SetStreamLineControlIO(ref IEleDO step_IO_Run, ref IEleDO step_IO_Direction)
        {
            this.step_IO_Run = step_IO_Run;
            this.step_IO_Direction = step_IO_Direction;
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
            if (IsRunning)
            {
                //执行动作
                int ret = step_IO_Direction.Write(false);
                if (ret != 0)
                {
                    return ret - 10000;
                }
                ret = step_IO_Run.Write(true);
                if (ret != 0)
                {
                    return ret - 10000;
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
            if (step_IO_Run == null || step_IO_Direction == null)
            {
                return -1;
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
            //执行动作
            int ret = step_IO_Direction.Write(false);
            if (ret != 0)
            {
                return ret - 10000;
            }
            ret = step_IO_Run.Write(flag_Run);
            if (ret != 0)
            {
                return ret - 10000;
            }

            //标记
            dic_Apply[applicant].ApplyToRun = flag_Run;
            return 0;
        }
        private int ActionToKeepStop(string applicant, bool flag_Stop)
        {
            //执行动作
            if (flag_Stop)
            {
                int ret = step_IO_Direction.Write(!flag_Stop);
                if (ret != 0)
                {
                    return ret - 10000;
                }
                ret = step_IO_Run.Write(!flag_Stop);
                if (ret != 0)
                {
                    return ret - 10000;
                }
            }

            //标记
            dic_Apply[applicant].ApplyToStop = flag_Stop;
            return 0;
        }
        public int ApplyKeepStop(string applicant, bool flag)
        {
            if (step_IO_Run == null || step_IO_Direction == null)
            {
                return -1;
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
                        return -2;
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

    public class ProductionInfo
    {
        /// <summary>
        /// 总结果,true,OK;false:NG;
        /// </summary>
        public bool TotalResult { get; set; }

        /// <summary>
        /// UCSN
        /// </summary>
        public string UCSN { get; set; }

        /// <summary>
        /// 物料SN
        /// </summary>
        public string SN { get; set; }

        /// <summary>
        /// 内部SN标记,SN_yyyyMMddHHmmssff
        /// </summary>
        public string SnIndex { get; set; }

        /// <summary>
        /// 流线编号,1;2;
        /// </summary>
        public int StreamLineIndex { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public bool? Slot1_2D_Result { get; set; }
        public string Slot1StartTime { get; set; }
        public string Slot1EndTime { get; set; }

        public bool? Slot2_2D_Result { get; set; }
        public bool? Slot2_3D_Result { get; set; }
        public string Slot2StartTime { get; set; }
        public string Slot2EndTime { get; set; }

        public bool? CheckSN_Result_PDCA { get; set; }
        public bool? CheckSN_Result_MES { get; set; }
        public bool? UpData_Result_PDCA { get; set; }
        public bool? UpData_Result_MES { get; set; }

        public string Reason_NG { get; set; }

        public double Offset_X1 { get; set; }
        public double Offset_Y1 { get; set; }
        public double Offset_X2 { get; set; }
        public double Offset_Y2 { get; set; }
    }
}
