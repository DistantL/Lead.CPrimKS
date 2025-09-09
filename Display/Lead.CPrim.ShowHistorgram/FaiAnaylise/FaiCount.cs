/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: FaiCount.cs
 * Author: Victor
 * Description: 用来直方图管理（直方图生成/直方图添加数据/直方图清除数据/直方图保存）
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
 * 2、增加属性NANum（无效值数量）
******************************************************************************/


using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowHistorgram.Controls;

namespace Lead.CPrim.ShowHistorgram.FaiAnaylise
{
    public class FaiCount : IComparable<FaiCount>
    {
        #region Field
        public readonly ShowHistorgram _show;
        /// <summary>坐标Y计数</summary>
        private readonly int[] eachFaiValueNum;
        /// <summary>下限</summary>
        private readonly double lowLimit;
        /// <summary>坐标X最小值</summary>
        private readonly double minXlabel;
        /// <summary>总分组数</summary>
        private readonly int parts;
        /// <summary>X坐标集合</summary>
        public readonly double[] theXLabel;
        /// <summary>上限</summary>
        private readonly double upLimit;

        /// <summary>柱状图UI</summary>
        public Control FaiHistControl;
        /// <summary>良率统计UI</summary>
        public Control FaiStaticsControl;
        /// <summary>Fai值集合</summary>
        private List<double> _fais = new List<double>();
        /// <summary>Cpk值集合</summary>
        private List<double> _faisCpk = new List<double>();

        /// <summary>绘图帮助类</summary>
        private DrawHistorgram _drawHistorgram;
        /// <summary>小图</summary>
        public Bitmap bitmap;
        /// <summary>小图</summary>
        public Graphics GraMap;
        /// <summary>大图</summary>
        public Bitmap bitmapString;
        /// <summary>大图</summary>
        public Graphics graMapString;
        #endregion



        #region Prop
        /// <summary>FAI名称</summary>
        public string FaiName { get; set; }
        /// <summary>柱状图间隔</summary>
        public double Space { get; }
        /// <summary>正常区域分组数</summary>
        public int NormalNum { get; }
        /// <summary>超下限分组数</summary>
        public int LowerNum { get; } 
        /// <summary>超上限分组数</summary>
        public int UperNum { get; }
        /// <summary>良率（已乘以100）</summary>
        public double OkRate => TotalNum == 0 ? 0 : OkNum * 100.0 / TotalNum;
        /// <summary>OK数量</summary>
        public int OkNum { get; set; }
        /// <summary>总数量</summary>
        public int TotalNum { get; set; }
        /// <summary>无效值数量</summary>
        public int NANum { get; set; }
        /// <summary>Cp</summary>
        public double Cp;
        /// <summary>Cpk</summary>
        public double Cpk;
        /// <summary>Ca</summary>
        public double Ca;
        #endregion



        #region Ctor
        /// <summary></summary>
        /// <param name="faiName">FAI名称</param>
        /// <param name="uperValue">上限</param>
        /// <param name="lowerValue">下限</param>
        /// <param name="show"></param>
        public FaiCount(string faiName, double uperValue, double lowerValue, ShowHistorgram show)
        {
            _show = show;
            TotalNum = 0;
            OkNum = 0;

            FaiName = faiName;
            NormalNum = _show.NormalParts;
            LowerNum = _show.LowerParts;
            UperNum = _show.UperParts;
            upLimit = uperValue;
            lowLimit = lowerValue;
            parts = NormalNum + LowerNum + UperNum;
            Space = (uperValue - lowerValue) / NormalNum;

            minXlabel = lowerValue - Space * LowerNum;
            theXLabel = new double[parts];

            //规格公差
            double T = upLimit - lowLimit;
            if(LowerNum == 5)
            {
                theXLabel[0] = lowLimit - T * 5;
                theXLabel[1] = lowLimit - T * 1;
                theXLabel[2] = lowLimit - T * 0.6;
                theXLabel[3] = lowLimit - T * 0.4;
                theXLabel[4] = lowLimit - T * 0.2;
                theXLabel[5] = lowLimit;
            }
            else if(LowerNum == 3)
            {
                theXLabel[0] = lowLimit - T * 5;
                theXLabel[1] = lowLimit - T * 1;
                theXLabel[2] = lowLimit - T * 0.2;
                theXLabel[3] = lowLimit;
            }
            for (var i = LowerNum + 1; i < LowerNum + NormalNum; i++)
            {
                theXLabel[i] = minXlabel + i * Space;
            }
            if(UperNum == 5)
            {
                theXLabel[parts - 5] = upLimit;
                theXLabel[parts - 4] = upLimit + T * 0.2;
                theXLabel[parts - 3] = upLimit + T * 0.4;
                theXLabel[parts - 2] = upLimit + T * 0.6;
                theXLabel[parts - 1] = upLimit + T * 1;
            }
            else if(UperNum == 3)
            {
                theXLabel[parts - 3] = upLimit;
                theXLabel[parts - 2] = upLimit + T * 0.2;
                theXLabel[parts - 1] = upLimit + T * 1;
            }
            eachFaiValueNum = new int[parts];

            FaiHistControl = new HistorgramControl(this);
        }
        #endregion



        //*****************************************************************************
        #region Method_ExternalUsing
        /// <summary>增加Fai</summary>
        /// <param name="faiValue"></param>
        public void AddFai(double faiValue)
        {
            _fais.Add(faiValue);
            //只计算最近32PCS良品Cpk
            if (faiValue >= lowLimit && faiValue <= upLimit)
            {
                if (_faisCpk.Count >= 32)
                {
                    _faisCpk.RemoveAt(0);
                }

                _faisCpk.Add(faiValue);
                CpkAnaylise.GetCpk(_faisCpk, lowLimit, upLimit, out Cp, out Cpk, out Ca);
            }
            for (var i = theXLabel.Length - 1; i >= 0; i--)
            {
                //临界值属于下个直方图，最大值除外
                if (DoubleEquals(faiValue, theXLabel[i]) || faiValue > theXLabel[i])
                {
                    if (DoubleEquals(faiValue, upLimit))
                    {
                        continue;
                    }
                    eachFaiValueNum[i]++;
                    if ((DoubleEquals(faiValue, lowLimit) || faiValue > lowLimit) && (DoubleEquals(faiValue, upLimit) || faiValue < upLimit))
                    {
                        OkNum++;
                    }
                    TotalNum++;
                    return;
                }
            }
            TotalNum++;
            eachFaiValueNum[0]++;
        }
        /// <summary>绘大图</summary>
        public void DrawMapString()
        {
            try
            {
                double rate = 1.0;
                if (theXLabel.Length > 14)
                {
                    rate = theXLabel.Length / 14.0;
                }
                int width = (int)Math.Floor(600 * rate);
                int higth = (int)Math.Floor(400 * 1.0);
                bitmapString = new Bitmap(width, higth);
                graMapString = Graphics.FromImage(bitmapString);
                _drawHistorgram = new DrawHistorgram(0, 0, width, higth, $"{FaiName}#{OkRate.ToString("f2")}%", LowerNum, NormalNum, theXLabel, eachFaiValueNum, Cpk, Cp, Ca, OkNum, TotalNum);
                _drawHistorgram.StartDrawingAll(graMapString);
            }
            catch (Exception ex)
            {
                _show.LogAdd($"大图绘制失败：{ex.Message}", LogLevel.Warn);
            }
        }
        /// <summary>绘小图</summary>
        public void DrawMap()
        {
            int width = FaiHistControl.Width;
            int higth = FaiHistControl.Height;
            bitmap = new Bitmap(width, higth);
            GraMap = Graphics.FromImage(bitmap);
            _drawHistorgram = new DrawHistorgram(0, 0, width, higth, $"{FaiName}#{OkRate.ToString("f2")}%", LowerNum, NormalNum, theXLabel, eachFaiValueNum, Cpk, Cp, Ca, OkNum, TotalNum);
            _drawHistorgram.StartDrawingPic(GraMap);
        }
        /// <summary>清除数据</summary>
        public void clrData()
        {
            for (var i = 0; i < eachFaiValueNum.Length; i++)
            {
                eachFaiValueNum[i] = 0;
            }
            TotalNum = 0;
            OkNum = 0;
        }
        /// <summary>保存图片</summary>
        public void SavePic()
        {
            DrawMapString();
            if (!Directory.Exists(_show.SavePicPath))
            {
                Directory.CreateDirectory(_show.SavePicPath);
            }
            var picpah = Path.Combine(_show.SavePicPath, $@"{FaiName}{DateTime.Now.ToString("HHmmss")}.jpg");
            bitmapString.Save(picpah);
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>double比较大小 </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns>true：相等或者接近相等；false：不相等</returns>
        private bool DoubleEquals(double value1, double value2)
        {
            double customError = 1E-3;
            return value1 == value2 || Math.Abs(value1 - value2) < customError;
        }
        #endregion



        #region Method_Obsolete
        [Obsolete]
        public int CompareTo(FaiCount other)
        {
            var compare = 0;
            switch (_show.SortType)
            {
                case SortType.名称升序:
                    compare = FaiName?.CompareTo(other?.FaiName) ?? -1;
                    break;
                case SortType.名称降序:
                    compare = other?.FaiName.CompareTo(FaiName) ?? -1;
                    break;
                case SortType.良率升序:
                    compare = OkRate.CompareTo(other.OkRate);
                    break;
                case SortType.良率降序:
                    compare = other.OkRate.CompareTo(OkRate);
                    break;
            }

            return compare;
        }
        #endregion
    }


    public enum SortType
    {
        名称升序,
        名称降序,
        良率升序,
        良率降序,
        默认排序,
    }
}