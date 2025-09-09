/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: IShowPlcCurve.cs
 * Author: Victor
 * Description: PLC通讯生成压力曲线（位置与压力曲线）
 * CreateTime: 2022-11-18
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1117><Victor><20221118>
 * 1、时间与压力曲线变更为位置与压力曲线
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lead.CPrim.Interfaces.Display
{
    /// <summary>Lead.CPrim.ShowPlcCurve对外接口</summary>
    public interface IShowPlcCurve
    {
        /// <summary>
        /// 位置压力曲线<br/>
        /// 1、不适用于源数据保存
        /// </summary>
        /// <param name="id">曲线显示位置（1-6）</param>
        /// <param name="sn">SN</param>
        /// <param name="keyValues">位置压力集合</param>
        /// <param name="index">1：曲线位置1；2：曲线位置2；（默认曲线位置1）</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        void ChartControl(int id, string sn, Dictionary<double, double> keyValues, int index = 1, string xName = "", string yName = "");

        /// <summary>
        /// 位置压力曲线<br/>
        /// 1、不适用于源数据保存
        /// </summary>
        /// <param name="id">曲线显示位置（1-6）</param>
        /// <param name="sn">SN</param>
        /// <param name="points">点位集合</param>
        /// <param name="index">1：曲线位置1；2：曲线位置2；（默认曲线位置1）</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        void ChartControl(int id, string sn, List<PointF> points, int index = 1, string xName = "", string yName = "");

        /// <summary>
        /// 时间压力曲线<br/>
        /// 1、不适用于源数据保存
        /// </summary>
        /// <param name="id">曲线显示位置（1-6）</param>
        /// <param name="sn">SN</param>
        /// <param name="keyValues">时间压力集合</param>
        /// <param name="index">1：曲线位置1；2：曲线位置2；（默认曲线位置1）</param>
        /// <param name="xName">X轴名称</param>
        /// <param name="yName">Y轴名称</param>
        void ChartControl(int id, string sn, Dictionary<DateTime, double> keyValues, int index = 1, string xName = "", string yName = "");
    }
}
