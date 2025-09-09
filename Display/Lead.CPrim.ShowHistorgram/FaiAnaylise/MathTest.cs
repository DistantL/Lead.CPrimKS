/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2022.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明
 *
 * 3.3.33.0617 -> 
 * 1、代码风格重新布局以及增加备注
******************************************************************************/

using System;

namespace Lead.CPrim.ShowHistorgram
{
    class Model
    {
        #region Field
        /// <summary>随机数生成器</summary>
        static Random aa;
        #endregion



        #region Ctor
        public Model()
        {
            aa = new Random((int)(DateTime.Now.Ticks / 10000));
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>产生正态分布随机数</summary>
        /// <param name="miu"></param>
        /// <param name="sigma"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public double Random_Normal(double miu, double sigma, double min, double max)
        {
            double x;
            double dScope;
            double y;
            do
            {
                x = AverageRandom(min, max);
                y = Normal(x, miu, sigma);
                dScope = AverageRandom(0, Normal(miu, miu, sigma));
            } while (dScope > y);
            return x;
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>产生(min,max)之间均匀分布的随机数</summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        private double AverageRandom(double min, double max)
        {
            int MINnteger = (int)(min * 10000);
            int MAXnteger = (int)(max * 10000);
            int resultInteger = aa.Next(MINnteger, MAXnteger);
            return resultInteger / 10000.0;
        }
        /// <summary>正态分布概率密度函数</summary>
        /// <param name="x"></param>
        /// <param name="miu"></param>
        /// <param name="sigma"></param>
        /// <returns></returns>
        private double Normal(double x, double miu, double sigma)
        {
            return 1.0 / (x * Math.Sqrt(2 * Math.PI) * sigma) * Math.Exp(-1 * (Math.Log(x) - miu) * (Math.Log(x) - miu) / (2 * sigma * sigma));
        }
        #endregion



        #region Method_Obsolete
        /// <summary>指数分布随机数</summary>
        /// <param name="const_a">指数分布的参数λ</param>
        /// <returns></returns>
        [Obsolete]
        public double RandExp(double const_a)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            double p;
            double temp;
            if (const_a != 0)
            {
                temp = 1 / const_a;
            }
            else
            {
                throw new InvalidOperationException("除数不能为零");
            }
            double randres;
            //用于产生随机的密度，保证比参数λ小
            while (true)
            {
                p = rand.NextDouble();
                if (p < const_a)
                {
                    break;
                }
            }
            randres = -temp * Math.Log(temp * p, Math.E);
            return randres;
        }
        /// <summary>泊松分布产生</summary>
        /// <param name="lam">参数</param>
        /// <param name="time">时间</param>
        /// <returns></returns>
        [Obsolete]
        public double poisson(double lam, double time)
        {
            int count = 0;

            while (true)
            {
                time -= ngtIndex(lam);
                if (time > 0)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
        private double ngtIndex(double lam)
        {
            double dec = aa.NextDouble();
            while (dec == 0)
            {
                dec = aa.NextDouble();
            }
            return -Math.Log(dec) / lam;
        }
        #endregion
    }
}
