/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: IShowAtlasCurve.cs、ScrewData.cs、WatchData.cs
 * Author: Victor
 * Description: Atlas曲线对外接口及数据结构
 * CreateTime: 2022-11-18
 * Inherit：
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.1125><Victor><20221125>
 * 1、ScrewData.cs、WatchData.cs数据结构变更，增加Hsg长宽及SPK长宽角度等
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Display
{
    /// <summary>Lead.CPrim.ShowPressureCurve对外接口</summary>
    public interface IShowAtlasCurve
    {
        /// <summary>启动压力采集</summary>
        /// <param name="watchData">手表数据</param>
        /// <param name="index">默认为1（1|2）</param>
        /// <returns>int</returns>
        void ChartControl(WatchData watchData, int index = 1);

        void ChartControl(WatchData watchData, int chartIndex, string snIndex,double limit_up,double limit_down,double normal, int index = 1);


        /// <summary>Atlas状态设置</summary>
        /// <param name="num">1/2/3/4</param>
        /// <param name="state">true：连接成功；false：连接失败</param>
        void AtlasStatusSet(int num, bool state);
    }


    /// <summary>螺丝数据</summary>
    public class ScrewData
    {
        public ScrewData()
        {
            Name = string.Empty;
            Result = string.Empty;
            Index = -1;
            FillDataOK = false;
            FinalTorque = -1;
            FinalAngle = -1;
            StepSeatingPoint = -1;
            StepClampTorque = -1;
            StepClampAngle = -1;
            MaxAngle = -1;
            MinAngle = -1;
            ScrewNum = -1;
            PostPressForce = string.Empty ;
            TorqueData = new List<double>();
            AngleData = new List<double>();
        }
        /// <summary>名称</summary>
        public string Name { get; set; }
        /// <summary>锁螺丝的结果</summary>
        public string Result { get; set; }
        /// <summary>第几个螺丝</summary>
        public int Index { get; set; }
        /// <summary>数据填充是否完成</summary>
        public bool FillDataOK { get; set; }
        /// <summary>最终扭矩</summary>
        public double FinalTorque { get; set; }
        /// <summary>最终角度</summary>
        public double FinalAngle { get; set; }

        /// <summary>贴合点 扭矩值</summary>
        public double StepSeatingPoint { get; set; }
        /// <summary>步骤夹紧扭矩</summary>
        public double StepClampTorque { get; set; }

        /// <summary>步骤夹紧角度</summary>
        public double StepClampAngle { get; set; }
								                   
        /// <summary>最大角度</summary>
        public double MaxAngle { get; set; }
        /// <summary>最小角度</summary>
        public double MinAngle { get; set; }
        /// <summary>退锁次数</summary>
        public int ScrewNum { get; set; }
        /// <summary>锁螺丝压力</summary>
        public string PostPressForce { get; set; }
        /// <summary>曲线的扭矩值集合</summary>
        public List<double> TorqueData { get; set; }
        /// <summary>曲线的角度值集合</summary>
        public List<double> AngleData { get; set; }
    }
    /// <summary>Watch数据</summary>
    public class WatchData
    {
        public WatchData()
        {
            PdcaOK = false;
            SFCOK = false;
            WatchId = string.Empty;
            CarrierId = string.Empty;
            CarrierSn = string.Empty;
            AtlasIndex = string.Empty;
            SPKSn = string.Empty;
            HsgSn = string.Empty;
            HSG_W = string.Empty;
            HSG_L = string.Empty;
            SPK_W = string.Empty;
            SPK_L = string.Empty;
            SPK_A = string.Empty;
            atlasData = new ScrewData[] { new ScrewData(), new ScrewData(), new ScrewData(), new ScrewData(), new ScrewData(), new ScrewData() };
        }

        /// <summary>pdca是否上传成功</summary>
        public bool PdcaOK { get; set; }
        /// <summary>SFC是否过站成功</summary>
        public bool SFCOK { get; set; }
        /// <summary>产品数据存储的唯一标识_PLC生成</summary>
        public string WatchId { get; set; }
        /// <summary>加工载具编号</summary>
        public string CarrierId { get; set; }
        /// <summary>Carrier SN</summary>
        public string CarrierSn { get; set; }
        /// <summary>螺丝枪编号</summary>
        public string AtlasIndex { get; set; }
        /// <summary>SPK SN</summary>
        public string SPKSn { get; set; }
        /// <summary>HSG SN</summary>
        public string HsgSn { get; set; }
        /// <summary>Hsg宽</summary>
        public string HSG_W { get; set; }
        /// <summary>Hsg长</summary>
        public string HSG_L { get; set; }
        /// <summary>SPK宽</summary>
        public string SPK_W { get; set; }
        /// <summary>SPK长</summary>
        public string SPK_L { get; set; }
        /// <summary>SPK角度</summary>
        public string SPK_A { get; set; }
        /// <summary>每个产品的4个螺丝的数据</summary>
        public ScrewData[] atlasData { get; set; }
    }
}
