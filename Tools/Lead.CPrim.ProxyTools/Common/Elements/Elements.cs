using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public static class Elements
    {
        //*****************************************************************************
        #region 轴组
        /// <summary>
        /// 根据距离，速度，加减速得到运行时间
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="vel"></param>
        /// <param name="acc"></param>
        /// <returns></returns>
        private static double GetRunTime(double distance, double vel, double acc)
        {
            double time = 0;

            double s1 = (vel * vel) / (2 * acc);
            double s3 = (vel * vel) / (2 * acc);
            if ((s1 + s3) < distance)
            {
                time = vel / acc + (distance - s1 - s3) / vel + vel / acc;
            }
            else
            {
                time = Math.Sqrt(distance / acc) * 2;
            }

            return time;
        }
        #endregion
    }
}
