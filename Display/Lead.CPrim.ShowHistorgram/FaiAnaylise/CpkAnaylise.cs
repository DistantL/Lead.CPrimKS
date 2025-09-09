/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: CpkAnaylise.cs
 * Author: Victor
 * Description: 用来Cpk计算
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 *
 * 3.3.33.0617 -> 
 * <Author>     <Time>
 *  Victor     20220709
 * 1、代码风格重新布局以及增加备注
 * 2、增加方法GetAverage（计算平均值）、GetStdev（计算方差）、GetCp（计算Cp）、GetCa（计算Ca）、GetCpk（计算Cpk）、GetCpkU（计算CpkU）、GetCpkL（计算CpkL）
 * 3、Cpk增加单边规格计算
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lead.CPrim.ShowHistorgram
{
    /// <summary>Cpk帮助类</summary>
    public class CpkAnaylise
    {
        #region Method_ExternalUsing
        /// <summary>双边规格Cpk</summary>
        /// <param name="fais">集合</param>
        /// <param name="lsl">下限</param>
        /// <param name="usl">上限</param>
        /// <param name="Cp">Cp</param>
        /// <param name="Cpk">Cpk</param>
        /// <param name="Ca">Ca</param>
        public static void GetCpk(List<double> fais, double lsl, double usl, out double Cp, out double Cpk, out double Ca)
        {
            //规格公差
            double T = usl - lsl;
            //规格中心
            double U = (usl + lsl) / 2;
            Ca = GetCa(fais, U, usl, lsl);
            Cp = GetCp(fais, usl, lsl);
            Cpk = GetCpk(fais, U, usl, lsl);
        }
        /// <summary>上限规格CpkU</summary>
        /// <param name="fais">集合</param>
        /// <param name="usl">上限</param>
        /// <param name="CpkU">CpkU</param>
        public static void GetCpkU(List<double> fais, double usl, out double CpkU)
        {
            CpkU = GetCpkU(fais, usl);
        }
        /// <summary>下限规格CpkL</summary>
        /// <param name="fais">集合</param>
        /// <param name="lsl">下限</param>
        /// <param name="CpkL"></param>
        public static void GetCpkL(List<double> fais, double lsl, out double CpkL)
        {
            CpkL = GetCpkL(fais, lsl);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>计算平均值</summary>
        /// <param name="l">集合</param>
        /// <returns>平均值</returns>
        private static double GetAverage(List<double> l)
        {
            return l.Average();
        }
        /// <summary>计算方差</summary>
        /// <param name="l">集合</param>
        /// <returns>方差</returns>
        private static double GetStdev(List<double> l)
        {
            double averageValue = GetAverage(l);
            double sum = l.Sum(d => Math.Pow(d - averageValue, 2));
            return Math.Sqrt(sum / (l.Count - 1));
        }
        /// <summary>计算Cp</summary>
        /// <param name="l">集合</param>
        /// <param name="limitMax">上限</param>
        /// <param name="limitMin">下限</param>
        /// <returns>Cp</returns>
        private static double GetCp(List<double> l, double limitMax, double limitMin)
        {
            return (limitMax - limitMin) / (6 * GetStdev(l));
        }
        /// <summary>计算Ca</summary>
        /// <param name="l">集合</param>
        /// <param name="limitNormal">标准值</param>
        /// <param name="limitMax">上限</param>
        /// <param name="limitMin">下限</param>
        /// <returns>Ca</returns>
        private static double GetCa(List<double> l, double limitNormal, double limitMax, double limitMin)
        {
            return (GetAverage(l) - limitNormal) / ((limitMax - limitMin) / 2);
        }
        /// <summary>计算Cpk</summary>
        /// <param name="l">集合</param>
        /// <param name="limitNormal">标准值</param>
        /// <param name="limitMax">上限</param>
        /// <param name="limitMin">下限</param>
        /// <returns>Cpk</returns>
        private static double GetCpk(List<double> l, double limitNormal, double limitMax, double limitMin)
        {
            return GetCp(l, limitMax, limitMin) * (1 - Math.Abs(GetCa(l, limitNormal, limitMax, limitMin)));
        }
        /// <summary>计算CpkU</summary>
        /// <param name="l">集合</param>
        /// <param name="limitMax">上限</param>
        /// <returns>CpkU</returns>
        private static double GetCpkU(List<double> l, double limitMax)
        {
            return Math.Abs(limitMax - GetAverage(l)) / (GetStdev(l) * 3);
        }
        /// <summary>计算CpkL</summary>
        /// <param name="l">集合</param>
        /// <param name="limitMin">下限</param>
        /// <returns>CpkL</returns>
        private static double GetCpkL(List<double> l, double limitMin)
        {
            return Math.Abs(GetAverage(l) - limitMin) / (GetStdev(l) * 3);
        } 
        #endregion
    }
}
