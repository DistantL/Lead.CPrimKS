using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lead.CPrim.PrimE404
{
    class MiniEcatLib
    {
        /// <summary>
        /// 获取模块版本信息
        /// </summary>
        /// <param name="version">版本号</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_GetLibVersion(ref double version);

        /// <summary>
        /// 连接模块总线
        /// </summary>
        /// <param name="slavenum">从站数量反馈值</param>
        /// <param name="option">是否开启别名，0-不开启 ，1-开启</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_InitEcat(ref int slavenum, int option);//静态方法，作为类的共享方法，无需实例化

        /// <summary>
        /// 获取从站名称
        /// </summary>
        /// <param name="slaveno">从站号，自动从1开始</param>
        /// <returns>从站名称指针</returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Mb_GetSlaveName(int slaveno);

        /// <summary>
        /// 获取别名开启下从站的别名
        /// </summary>
        /// <param name="slavealiasarray">别名数组首地址</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_GetSlaveAlias(ref int slavealiasarray);

        /*=====================================================
        添加日期：20210223
        获取总线连接状态
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_GetConnectStatus(int SlaveNo, ref int ConnectStatus);

        /// <summary>
        /// 从文件加载配置参数，配置文件由调试工具生成
        /// </summary>
        /// <param name="filename">文件地址</param>
        /// <returns>设置报错信息，详见说明书</returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_LoadParamFromFile(string filename);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16_LoadParamFromFile(string filename);

        /// <summary>
        /// 获取编码器当前数值
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="EncoderNo">编码器通道号，从0开始计数</param>
        /// <param name="data_out">编码器数值</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4Encoder_GetEncoderData(int SlaveNo, int EncoderNo, ref int data_out);

        /// <summary>
        /// 设置编码器当前值
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="EncoderNo">编码器通道号，从0开始计数</param>
        /// <param name="EncoderData">编码器设定值</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4Encoder_SetCurrentData(int SlaveNo, int EncoderNo, int EncoderData);

        /// <summary>
        /// 设置编码器的计数方式和方向以及使能状态
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="EncoderNo">编码器通道号，从0开始计数</param>
        /// <param name="EncoderMode">编码器计数方式:1-1倍频，2-2倍频，4-4倍频</param>
        /// <param name="dir">编码器计数方向：0-正向，1-反向</param>
        /// <param name="enable">是否启用编码器计数通道：1-启用，0-不启用</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4Encoder_Initial(int SlaveNo, int EncoderNo, int EncoderMode, int dir, int enable);

        /// <summary>
        /// 获取编码器的设置参数
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="EncoderNo">编码器通道号，从0开始计数</param>
        /// <param name="EncoderMode">编码器计数方式:1-1倍频，2-2倍频，4-4倍频</param>
        /// <param name="dir">编码器计数方向：0-正向，1-反向</param>
        /// <param name="enable">是否启用编码器计数通道：1-启用，0-不启用</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4Encoder_GetParam(int SlaveNo, int EncoderNo, ref int EncoderMode, ref int dir, ref int enable);


        /// <summary>
        /// 设置触发输出口输出模式
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="Mode">输出口模式选择，0-GPIO,1-脉冲输出，2-PWM输出</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_SetOutMode(int SlaveNo, int Mode);

        /// <summary>
        /// 获取触发输出口输出模式
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="Mode">输出口模式选择，0-GPIO,1-脉冲输出，2-PWM输出</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_GetOutMode(int SlaveNo, ref int Mode);

        /*=====================================================
        添加日期：20210510
        设置触发输出模式为电平翻转模式还是脉冲模式 0-脉冲 1-电平翻转
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_SetTrigMode(int SlaveNo, int TriggerOutNum, int TrigMode);

        /*=====================================================
       添加日期：20210510
       获取当前触发通道的触发电平 0-负电平 1-正电平
       返回值：无
       =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_GetCurrentTrigLevel(int SlaveNo, int TriggerOutNum, ref int TrigLevel);

        /*=====================================================
        添加日期：20210510
        获取触发输出模式为电平翻转模式还是脉冲模式 0-脉冲 1-电平翻转
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_GetTrigMode(int SlaveNo, int TriggerOutNum, ref int TrigMode);

        /// <summary>
        /// 设置触发输出口输出脉宽
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        /// <param name="PulseWidth">脉冲宽度，单位10ns ，设定范围100~9999999</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_SetPulseWidth(int SlaveNo, int TriggerOutNum, int PulseWidth);

        /// <summary>
        /// 获取触发输出口设定脉宽
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        /// <param name="PulseWidth">脉冲宽度，单位10ns ，设定范围100~9999999</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_GetPulseWidth(int SlaveNo, int TriggerOutNum, ref int PulseWidth);


        /// <summary>
        /// 设置触发输出通道绑定比较器
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        /// <param name="LineCompareMask">绑定的线性比较器号0-9，每一位对应一个线性比较器，bit0对应比较器0</param>
        /// <param name="PreCompareMask">绑定的预设定比较器号0-3，每一位对应一个预设定比较器,bit0对应预设比较器0</param>
        /// <param name="PulsePolarity">输出极性 0：不取反 1：取反</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_BandingCompare(int SlaveNo, int TriggerOutNum, uint LineCompareMask, uint PreCompareMask, uint PulsePolarity = 0);

        /// <summary>
        /// 获取触发输出通道绑定比较器
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        /// <param name="LineCompareMask">绑定的线性比较器号0-9，每一位对应一个线性比较器，bit0对应比较器0</param>
        /// <param name="PreCompareMask">绑定的预设定比较器号0-3，每一位对应一个预设定比较器,bit0对应预设比较器0</param>
        /// <param name="PulsePolarity">输出极性 0：不取反 1：取反</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_GetBanding(int SlaveNo, int TriggerOutNum, ref uint LineCompareMask, ref uint PreCompareMask, ref int PulsePolarity);

        /// <summary>
        /// 重置触发输出口计数值
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_ResetCounter(int SlaveNo, int TriggerOutNum);

        /// <summary>
        /// 获取触发输出口计数值
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        /// <param name="TrigCount">触发输出计数值</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_GetCounter(int SlaveNo, int TriggerOutNum, ref int TrigCount);

        /// <summary>
        /// 输出指定输出口一个长脉宽脉冲
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_SetManualOutput(int SlaveNo, int TriggerOutNum);

        /// <summary>
        /// 输出指定输出口一个设定脉宽脉冲
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_SetManualPulseOutput(int SlaveNo, int TriggerOutNum);

        /// <summary>
        /// 指定输出口绑定2D比较器
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        /// <param name="IsOpen2DCompare">是否开启2D比较功能，0-不开启 1-开启</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_Set2DCompare(int SlaveNo, int TriggerOutNum, uint IsOpen2DCompare);

        /// <summary>
        /// 获取指定输出口绑定2D比较器
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="TriggerOutNum">触发输出口，从0开始计数</param>
        /// <param name="IsOpen2DCompare">是否开启2D比较功能，0-不开启 1-开启</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4TrigOut_Get2DCompareEnable(int SlaveNo, int TriggerOutNum, ref int IsOpen2DCompare);

        /// <summary>
        /// 重置预设定比较器比较坐标
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="PreCompareNo">预设定比较器号，从0开始计数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PreCmp_ResetTrigData(int SlaveNo, int PreCompareNo);

        /// <summary>
        /// 设置预设定比较器绑定编码器
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="EncoderNo">编码器通道号</param>
        /// <param name="PreCompareNo">预设定比较器号，从0开始计数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PreCmp_BindingEncoder(int SlaveNo, int EncoderNo, int PreCompareNo);

        /// <summary>
        /// 获取预设定比较器绑定编码器
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="PreCompareNo">预设定比较器号</param>
        /// <param name="EncoderNo">编码器通道号</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PreCmp_GetBindingEncoder(int SlaveNo, int PreCompareNo, ref int EncoderNo);

        /// <summary>
        /// 设置预设定比较器触发时编码器运行方向
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="PreCompareNo">预设定比较器号</param>
        /// <param name="dir">方向 0-正向，1-反向，2-双向</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PreCmp_SetTrigDir(int SlaveNo, int PreCompareNo, int dir);

        /// <summary>
        /// 设置预设定比较器触发点位
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="PreCompareNo">预设定比较器号</param>
        /// <param name="Pos_Array">触发点位数组</param>
        /// <param name="ArrayCount">触发点位个数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PreCmp_SetTrigData(int SlaveNo, int PreCompareNo, ref int Pos_Array, int ArrayCount);

        /// <summary>
        /// 获取预设定比较器触发数据个数
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="PreCompareNo">预设定比较器号</param>
        /// <param name="ArrayCount">触发点位个数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PreCmp_GetTrigDataCnt(int SlaveNo, int PreCompareNo, ref int ArrayCount);

        /// <summary>
        /// 获取预设定比较器触发数据
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="PreCompareNo">预设定比较器号</param>
        /// <param name="Pos_Array">触发点位数组首地址</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PreCmp_GetTrigData(int SlaveNo, int PreCompareNo, ref int Pos_Array);

        /// <summary>
        /// 设置预设定比较器使能状态
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="PreCompareNo">预设定比较器号</param>
        /// <param name="Enable">使能状态，0-关闭，1-开启</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PreCmp_SetEnable(int SlaveNo, int PreCompareNo, int Enable);


        /// <summary>
        /// 设置线性比较器绑定编码器
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="EncoderNo">编码器号从0开始</param>
        /// <param name="LineCompareNo">线性比较器号，从0开始</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LineCmp_BingdingEncoder(int SlaveNo, int EncoderNo, int LineCompareNo);

        /// <summary>
        /// 获取线性比较器绑定的编码器
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LineCompareNo">线性比较器号，从0开始</param>
        /// <param name="EncoderNo">编码器号从0开始</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LineCmp_GetBingdingEncoder(int SlaveNo, int LineCompareNo, ref int EncoderNo);

        /// <summary>
        /// 设置线性比较器触发的数据
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LineCompareNo">线性比较器号，从0开始</param>
        /// <param name="StartPos">线性触发开始坐标</param>
        /// <param name="EndPos">线性触发终点坐标</param>
        /// <param name="Interval">线性触发间隔距离</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LineCmp_SetTriggerData(int SlaveNo, int LineCompareNo, int StartPos, int EndPos, int Interval);

        /// <summary>
        /// 获取线性比较器触发的数据
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LineCompareNo">线性比较器号，从0开始</param>
        /// <param name="StartPos">线性触发开始坐标</param>
        /// <param name="EndPos">线性触发终点坐标</param>
        /// <param name="Interval">线性触发间隔距离</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LineCmp_GetTriggerData(int SlaveNo, int LineCompareNo, ref int StartPos, ref int EndPos, ref int Interval);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LineCmp_SetEnable(int SlaveNo, int LineCompareNo, int Enable);



        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O42DCmp_SetCompareSource(int SlaveNo, uint X_Source, uint Y_Source);



        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O42DCmp_SetTrigPoint(int SlaveNo, ref int X_Array, ref int Y_Array, int PointCount);


        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O42DCmp_SetTrigRegionWindow(int SlaveNo, uint RegionWindow);


        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O42DCmp_SetEnable(int SlaveNo, int Enable);



        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O42DCmp_GetTrigFifoCnt(int SlaveNo, ref uint X_FIFO, ref uint Y_FIFO);



        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O42DCmp_GetTrigLTCPoint(int SlaveNo, ref int X_LTCPoint, ref int Y_LTCPoint);


        /// <summary>
        /// 设置位置锁存信号的输入滤波时间
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="FilterTime">滤波时间，当输入脉宽大于该值时，触发锁存；设定范围100-999999，单位10ns</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LTC_SetFilterTime(int SlaveNo, int FilterTime);


        /// <summary>
        /// 重置位置锁存FIFO中已锁存的坐标
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LtcFifoNo">锁存FIFO通道号</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LTC_ResetFifo(int SlaveNo, int LtcFifoNo);

        /// <summary>
        /// 获取位置锁存FIFO中已锁存的数据个数
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LtcFifoNo">锁存FIFO通道号</param>
        /// <param name="FifoNum">FIFO中已锁存数据个数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LTC_GetFifoNum(int SlaveNo, int LtcFifoNo, ref int FifoNum);


        /// <summary>
        /// 获取位置锁存FIFO中锁存的数据
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LtcFifoNo">锁存FIFO通道号</param>
        /// <param name="FifoData">锁存位置，当前获取的数据会从FIFO中剔除</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4LTC_GetFifoData(int SlaveNo, int LtcFifoNo, ref int FifoData);



        /// <summary>
        /// 获取高速脉冲计数器计数值
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LtcInNo">高速脉冲计数通道号，从0开始计数</param>
        /// <param name="Count">计数值</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PulseCounter_GetCounter(int SlaveNo, int LtcInNo, ref long Count);

        /// <summary>
        /// 重置高速脉冲计数器数值
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LtcInNo">高速脉冲计数通道号，从0开始计数</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PulseCounter_ResetCounter(int SlaveNo, int LtcInNo);

        /// <summary>
        /// 设置高速脉冲计数器输入脉宽
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LtcInNo">高速脉冲计数通道号，从0开始计数</param>
        /// <param name="PulseWidth">输入脉宽，当输入信号脉宽大于该设定值，计数+1</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PulseCounter_SetPulseWidth(int SlaveNo, int LtcInNo, int PulseWidth);

        /// <summary>
        /// 获取高速脉冲计数器输入脉宽设定值
        /// </summary>
        /// <param name="SlaveNo">从站号，自动从1开始</param>
        /// <param name="LtcInNo">高速脉冲计数通道号，从0开始计数</param>
        /// <param name="PulseWidth">输入脉宽，当输入信号脉宽大于该设定值，计数+1</param>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E4O4PulseCounter_GetPulseWidth(int SlaveNo, int LtcInNo, ref int PulseWidth);



        /*
         * E1O16lib
         * 
         * encoder
         */
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Encoder_GetCurrentData(int SlaveNo, ref long EncData);


        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Encoder_SetCurrentData(int SlaveNo, long EncoderData);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Encoder_SetCountMode(int SlaveNo, int CountMode);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Encoder_GetCountMode(int SlaveNo, ref int CountMode);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16OutPut_SetOpModeGPIO(int SlaveNo);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Output_GetOpMode(int SlaveNo, ref int OpMode);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16OutPut_SetOpModePulse(int SlaveNo);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16OutPut_SetGPIOOutput(int SlaveNo, int GPIOOutput);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16OutPut_GetGPIOOutput(int SlaveNo, ref int GPIOOutput);

        /*=====================================================
        添加日期：20201229
        初始化E1O16编码器
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Encoder_Initial(int SlaveNo);

        /*=====================================================
        添加日期：20201229
        设置E1O16触发输出绑定锁存通道，并设置触发输出类型
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_BingLtc(int SlaveNo, int TrigNo, int LTCNo, int Type);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetBindSts(int SlaveNo, int TrigNo, ref int LTCNo, ref int Type);

        /*=====================================================
        添加日期：20201229
        设置E1O16触发输出脉冲宽度，单位10ns，范围100~10000000
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_SetPulseWidth(int SlaveNo, int TrigNo, int Width);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetPulseWidth(int SlaveNo, int TrigNo, ref int Width);

        /*=====================================================
        添加日期：20201229
        获取E1O16触发输出计数
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetCount(int SlaveNo, int TrigNo, ref int Count);

        /// <summary>
        /// 获取所有通道的触发计数值
        /// </summary>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="pCountArray">触发计数数组首地址</param>
        /// <returns>参见手册</returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetAllChnTrigCount(int SlaveNo, ref int pCountArray);

        /// <summary>
        /// 重置指定通道的触发输出计数
        /// </summary>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="TrigNo">触发通道号</param>
        /// <returns>参见手册</returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_ResetCount(int SlaveNo, int TrigNo);

        /// <summary>
        /// 获取触发输出瞬间的回锁坐标
        /// </summary>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="TrigNo">触发通道号</param>
        /// <param name="LTCValue">回锁位置值</param>
        /// <returns></returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetLtcValue(int SlaveNo, int TrigNo, ref long LTCValue);

        /*=====================================================
        添加日期：20201229
        设置E1O16踢料触发坐标，坐标值为绝对坐标
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_SetClassifyPosition(int SlaveNo, int TrigNo, long ClassifyPosition);

        /// <summary>
        /// 获取触发的踢料FIFO中缓存的数据个数
        /// </summary>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="TrigNo">触发通道号</param>
        /// <param name="FifoCount">FIFO计数值</param>
        /// <returns></returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetClassifyFifoCount(int SlaveNo, int TrigNo, ref int FifoCount);

        /// <summary>
        /// 获取所有通道的踢料FIFO中的数据个数
        /// </summary>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="pFifoCountArray">踢料FIFO数据个数数组首地址</param>
        /// <returns></returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetAllChnClassifyFifoCount(int SlaveNo, ref int pFifoCountArray);

        /*=====================================================
        添加日期：20201229
        获取E1O16相机触发FIFO计数
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetCameraFifoCount(int SlaveNo, int TrigNo, ref int FifoCount);

        /// <summary>
        /// 获取所有通道的相机缓存FIFO中的数据个数
        /// </summary>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="pFifoCountArray">相机FIFO中的数据个数数组首地址</param>
        /// <returns></returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetAllChnCameraFifoCount(int SlaveNo, ref int pFifoCountArray);



        /*=====================================================
        添加日期：20201229
        设置E1O16相机触发相对于光电的距离，坐标值为相对距离
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_SetCameraOffset(int SlaveNo, int TrigNo, long CameraOffset);

        /*=====================================================
        添加日期：20210302
        获取E1O16相机触发相对于光电的距离，坐标值为相对距离
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetCameraOffset(int SlaveNo, int TrigNo, ref long CameraOffset);

        /*=====================================================
        添加日期：20210226
        设置脉冲输出的安全间距，输出后间隔内无法再输出
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_SetSafeDistance(int SlaveNo, uint SafeDistance);

        /*=====================================================
       添加日期：20210302
       获取脉冲输出的安全间距，输出后间隔内无法再输出
       返回值：无
       =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Trigger_GetSafeDistance(int SlaveNo, ref uint SafeDistance);

        /*=====================================================
        添加日期：20201229
        设置E1O16产品间安全距离
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_SetSafetyClearDistance(int SlaveNo, int SafeDistance);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_GetSafetyClearDistance(int SlaveNo, ref int SafeDistance);

        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_GetFilterWidth(int SlaveNo, ref int FilterWidth);

        /*=====================================================
        添加日期：20201229
        设置E1O16锁存的滤波时间
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_SetFilterWidth(int SlaveNo, int FilterWidth);


        /*=====================================================
        添加日期：20210221
        重置E1O16锁存FIFO数据
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_ResetLTCFifoData(int SlaveNo, int LTCNo);

        /*=====================================================
        添加日期：20210221
        重置E1O16锁存计数器计数
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_ClearLTCCounter(int SlaveNo, int LTCNo);

        /*=====================================================
        添加日期：20210221
        设置锁存输入间隔时间
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_SetLTCGapTime(int SlaveNo, int GapTime);

        /*=====================================================
        添加日期：20210221
        获取锁存计数器计数值
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_GetLTCCounterData(int SlaveNo, int LTCNo, ref int Count);

        /// <summary>
        /// 获取所有通道的锁存计数器计数值
        /// </summary>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="pCountArray">计数值数组首地址</param>
        /// <returns></returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_GetAllChnLTCCounterData(int SlaveNo, ref int pCountArray);

        /*=====================================================
        添加日期：20210221
        获取锁存FIFO数据数量
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_GetLTCFifoCount(int SlaveNo, int LTCNo, ref int Count);

        /// <summary>
        /// 获取所有通道的锁存FIFO计数值
        /// </summary>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="pLTCFifoCountArray">锁存FIFO计数值首地址</param>
        /// <returns></returns>
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_GetAllChnLTCFifoCount(int SlaveNo, ref int pLTCFifoCountArray);

        /*=====================================================
        添加日期：20210221
        获取锁存FIFO中的数据
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16LTC_GetLTCFifoData(int SlaveNo, int LTCNo, ref long FifoData);


        /*=====================================================
        添加日期：20210402
        设置补偿参数
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Compens_SetCompensationParam(int SlaveNo, int CompensDir, int CalCycle, int ReferenceDis, int ReferenceVel);

        /*=====================================================
        添加日期：20210402
        获取补偿参数设置值
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Compens_GetCompensationParam(int SlaveNo, ref int CompensDir, ref int CalCycle, ref int ReferenceDis, ref int ReferenceVel);

        /*=====================================================
        添加日期：20210402
        获取补偿参数实际运算值
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_E1O16Compens_GetCompensationActVal(int SlaveNo, ref int ActualCycle, ref int ActualDis, ref int ActualVel);


        /*=====================================================
        添加日期：20210105
        按32bit设置数字量模块的输出信号
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_DigitalIO_SetPortOutput(int SlaveNo, uint PortOutput);


        /*=====================================================
        添加日期：20210105
        按32bit读取数字量模块的输入信号
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_DigitalIO_GetPortInput(int SlaveNo, ref uint PortInput);



        /*=====================================================
        添加日期：20210105
        初始化IO模块
        返回值：无
        =======================================================*/
        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_DigitalIO_Initial(int SlaveNo);


        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_DigitalIO_GetPortOutput(int SlaveNo, ref uint PortOutput);


        [DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Mb_DigitalIO_SetChannelOutput(int SlaveNo, int ChannelNum, int ChannelOutput);


        //[DllImport("MiniEcatLib.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Mb_E3A4_GetEncData(int SlaveNo, int EncCnt, ref int EncData);



    }
}
