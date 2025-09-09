using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 连续累计统计算法
    /// </summary>
    [Serializable]
    public class ContinuousCumulativeStatisticsAlgorithm
    {
        #region Field
        /// <summary>
        /// 当前计数
        /// </summary>
        int _currentCount = 0;

        /// <summary>
        /// 结束时间
        /// </summary>
        DateTime _endTime;
        #endregion



        #region Prop
        /// <summary>
        /// 连续计数
        /// </summary>
        public int ContinuousCounting { get; private set; } = 0;

        /// <summary>
        /// 连续阈值
        /// </summary>
        public int ContinuousThreshold { get; private set; } = 3;

        /// <summary>
        /// 累计计数
        /// </summary>
        public int CumulativeCounting { get; private set; } = 0;

        /// <summary>
        /// 累计阈值
        /// </summary>
        public int CumulativeThreshold { get; private set; } = 8;

        /// <summary>
        /// 当前模式
        /// </summary>
        public StatisticsMode Mode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 统计时间间隔
        /// </summary>
        public TimeSpan StatisticsTimeInterval { get; set; } = new TimeSpan(0, 60, 0);

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalQuantity { get; private set; } = 100;
        #endregion



        #region Ctor
        public ContinuousCumulativeStatisticsAlgorithm()
        {
            Name = "";
            Mode = StatisticsMode.StatisticsByTime;
            StatisticsTimeInterval = new TimeSpan(0, 30, 0);
        }
        public ContinuousCumulativeStatisticsAlgorithm(string name) : this()
        {
            Name = name;
        }
        public ContinuousCumulativeStatisticsAlgorithm(string name, StatisticsMode mode) : this(name)
        {
            Mode = mode;
        }
        #endregion



        #region MethodExternalUsing
        /// <summary>
        /// 0：检查通过；<br/>
        /// 1：连续统计NG；<br/>
        /// 2：累计统计NG；<br/>
        /// </summary>
        /// <param name="isOK"></param>
        /// <returns></returns>
        public int Check(bool isOK)
        {
            int result = 0;
            // 刷新计数标志
            bool flag = false;
            if (isOK)
            {
                ContinuousCounting = 0;
            }

            if (!isOK)
            {
                ContinuousCounting++;
                CumulativeCounting++;

                if (ContinuousCounting >= ContinuousThreshold)
                {
                    flag = true;
                    result = 1;
                }

                if (CumulativeCounting >= CumulativeThreshold)
                {
                    flag = true;
                    result = 2;
                }
            }

            if (Mode == StatisticsMode.StatisticsByQuantity)
            {
                _currentCount++;
                if (_currentCount >= TotalQuantity)
                {
                    flag = true;
                    result = 0;
                }
            }
            else if (Mode == StatisticsMode.StatisticsByTime)
            {
                if (DateTime.Now.CompareTo(_endTime) >= 0)
                {
                    flag = true;
                    result = 0;
                }
            }

            if (flag)
            {
                ContinuousCounting = 0;
                CumulativeCounting = 0;
                _currentCount = 0;
                _endTime = DateTime.Now.Add(StatisticsTimeInterval);
            }

            return result;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="continuousThreshold">连续阈值</param>
        /// <param name="cumulativeThreshold">累计阈值</param>
        /// <param name="statistics">按数量统计：总数量；按时间统计：分钟；</param>
        public void Init(int continuousThreshold, int cumulativeThreshold, int statistics)
        {
            ContinuousCounting = 0;
            CumulativeCounting = 0;
            _currentCount = 0;

            this.ContinuousThreshold = continuousThreshold;
            this.CumulativeThreshold = cumulativeThreshold;

            if (Mode == StatisticsMode.StatisticsByTime)
            {
                this.StatisticsTimeInterval = new TimeSpan(0, statistics, 0);
                _endTime = DateTime.Now.Add(StatisticsTimeInterval);
            }
            else
            {
                this.TotalQuantity = statistics;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="patterns">常用统计模式</param>
        public void Init(CommonStatisticalPatterns patterns)
        {
            switch (patterns)
            {
                case CommonStatisticalPatterns.连一不连二:
                    ContinuousCounting = 1;
                    CumulativeCounting = 2;
                    break;

                case CommonStatisticalPatterns.连三不连八:
                    ContinuousCounting = 3;
                    CumulativeCounting = 8;
                    break;

                case CommonStatisticalPatterns.连三不连五:
                default:
                    ContinuousCounting = 3;
                    CumulativeCounting = 5;
                    break;
            }

            TotalQuantity = 100;
            StatisticsTimeInterval = new TimeSpan(0, 30, 0);
        }
        #endregion
    }
}
