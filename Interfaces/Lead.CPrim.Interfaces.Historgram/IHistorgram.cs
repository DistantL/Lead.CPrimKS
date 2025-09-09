/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: DrawHistorgram.cs
 * Author: Victor
 * Description: 用来绘制直方图
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
******************************************************************************/

namespace Lead.CPrim.Interfaces
{
    public interface IHistorgram
    {
        /// <summary>添加单个FAI（适用于双边规格公差）</summary>
        /// <param name="faiName">FAI名称</param>
        /// <param name="faivalue">FAI值</param>
        /// <param name="Uper">上限</param>
        /// <param name="lower">下限</param>
        void AddSingleFaiVal(string faiName, double faivalue, double Uper, double lower);
        /// <summary>清除数据</summary>
        void ClrData();
        /// <summary>刷新UI</summary>
        void refreshOutputUi();
        /// <summary>获取指定FAI Cp</summary>
        /// <param name="faiName">FAI名称</param>
        /// <param name="cpk">Cpk</param>
        /// <returns></returns>
        int GetCpk(string faiName, out double cpk);
        /// <summary>获取指定FAI Cp</summary>
        /// <param name="faiName">FAI名称</param>
        /// <param name="cp">Cp</param>
        /// <returns></returns>
        int GetCp(string faiName, out double cp);
        /// <summary>获取指定FAI良率</summary>
        /// <param name="faiName">FAI名称</param>
        /// <param name="rate">良率</param>
        /// <returns></returns>
        int GetOkRate(string faiName, out double rate);
    }
}