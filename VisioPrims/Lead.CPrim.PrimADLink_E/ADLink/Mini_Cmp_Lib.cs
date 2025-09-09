using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APS168_W64;

namespace lct_mini
{


    enum Cmd
    {
        Read_PL_REG = 0,
        Write_PL_REG = 1,
        Read_eeprom = 2,
        Write_eeprom = 3,
        Read_SRAM = 4,
        Write_SRAM = 5
    }

    enum Register_Address
    {
        Encoder_Ctl = 0xc,//编码器设置

        Encoder_ch0 = 0x100,//编码器通道数值
        Encoder_ch1 = 0x104,
        Encoder_ch2 = 0x108,
        Encoder_ch3 = 0x10c,

        //编码器初始0
        Encoder_Set0 = 0x10,
        Encoder_Set1 = 0x14,
        Encoder_Set2 = 0x18,
        Encoder_Set3 = 0x1c,

        MODE_OUT = 0x138,//输出口模式

        //线性比较器输入设置
        Mask_line0 = 0x20,
        Mask_line1 = 0x24,

        //线性比较器0~9初始位置
        Start_line0 = 0x28,
        Start_line1 = 0x2C,
        Start_line2 = 0x30,
        Start_line3 = 0x34,
        Start_line4 = 0x38,
        Start_line5 = 0x3C,
        Start_line6 = 0x40,
        Start_line7 = 0x44,
        Start_line8 = 0x48,
        Start_line9 = 0x4C,

        //线性比较器0~9结束位置
        End_line0 = 0x50,
        End_line1 = 0x54,
        End_line2 = 0x58,
        End_line3 = 0x5C,
        End_line4 = 0x60,
        End_line5 = 0x64,
        End_line6 = 0x68,
        End_line7 = 0x6C,
        End_line8 = 0x70,
        End_line9 = 0x74,

        //线性比较器0~9间隔位置
        Gap_line0 = 0x78,
        Gap_line1 = 0x7c,
        Gap_line2 = 0x80,
        Gap_line3 = 0x84,
        Gap_line4 = 0x88,
        Gap_line5 = 0x8C,
        Gap_line6 = 0x90,
        Gap_line7 = 0x94,
        Gap_line8 = 0x98,
        Gap_line9 = 0x9C,

        //触发输出口0~3设置
        Mask_map0 = 0xcc,
        Mask_map1 = 0xd0,

        //0~3脉冲输出宽度  单位:10ns
        Pulse_width0 = 0xBC,
        Pulse_width1 = 0xC0,
        Pulse_width2 = 0xC4,
        Pulse_width3 = 0xC8,

        //0~3脉冲输出重置
        Pulse_counter_reset = 0x200,

        //0~3脉冲输出计数
        Pulse_counter_ch0 = 0x204,
        Pulse_counter_ch1 = 0x208,
        Pulse_counter_ch2 = 0x20c,
        Pulse_counter_ch3 = 0x210,

        //预设比较器FIFO清零
        Pre_Reset = 0xA0,

        //预设比较器信号源
        Mask_Pre = 0xA8,

        //0~9比较器使能设置
        Compare_en = 0xA4,

        //预设比较器数据区域
        PreCompare0_fifo = 0x1000,
        PreCompare1_fifo = 0x2000,
        PreCompare2_fifo = 0x3000,
        PreCompare3_fifo = 0x4000,

        //预设定比较器比较方向
        PreCompare_dir = 0xAC
    }
    public class Mini_Cmp_Lib
    {
        static uint[] PreCompareMask = new uint[256];
        static uint[] LineCompareMask = new uint[256];
        static int[] Encoder_Ctl_Data = new int[256];
        static uint[] Mask_Line0_Data = new uint[256];
        static uint[] Mask_Line1_Data = new uint[256];
        static int[] Mask_Pre_Data = new int[256];
        static uint[] Mask_map0_Data = new uint[256];
        static uint[] Mask_map1_Data = new uint[256];
        static uint[] Compare_enable_status = new uint[256];
        static int[] PreCompare_dir = new int[256];
        static Object locker = new Object();
        static Object lockerenable = new Object();
        /// <summary>
        /// 获取编码器坐标
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="EncoderNo">编码器号</param>
        /// <param name="data_out">数据</param>
        /// <returns></returns>
        public static int Encoder_GetEncoderData(int CardNo, int SlaveNo, int EncoderNo, ref int data_out)
        {
            int ret = 0; uint data = 0;
            ret = APS168.APS_get_field_bus_od_data(CardNo, 0, SlaveNo, 0, EncoderNo + 1, ref data);
            data_out = (int)data;
            return ret;

        }


        /// <summary>
        /// 设置指定通道的编码器计数值
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="EncoderNo">编码器通道号：0~3</param>
        /// <param name="Position">设置当前值</param>
        /// <returns></returns>
        public static int Encoder_SetCurrentData(int CardNo, int SlaveNo, int EncoderNo, int Position)
        {
            int ret = 0;
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Encoder_Set0 + EncoderNo * 4, Position);
            return ret;

        }


        /// <summary>
        /// 初始化编码器通道
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="EncoderNo">编码器通道号</param>
        /// <param name="EncoderMode">编码器计数方式:1-1倍频，2-2倍频，4-4倍频</param>
        /// <param name="dir">编码器计数方向：0-正向，1-反向</param>
        /// <param name="enable">是否启用编码器计数通道：1-启用，0-不启用</param>
        /// <returns></returns>
        public static int Encoder_Initial(int CardNo, int SlaveNo, int EncoderNo, int EncoderMode, int dir, int enable)
        {
            int ret = 0;
            //修改EncoderMode
            Encoder_Ctl_Data[SlaveNo] = Encoder_Ctl_Data[SlaveNo] & (int.MaxValue ^ (int)(15 * Math.Pow(256, EncoderNo))) | EncoderMode * (int)(Math.Pow(256, EncoderNo));
            //修改DIR
            Encoder_Ctl_Data[SlaveNo] = Encoder_Ctl_Data[SlaveNo] & (int.MaxValue ^ (int)(16 * Math.Pow(256, EncoderNo))) | dir * 16 * (int)(Math.Pow(256, EncoderNo));
            //修改Enable
            Encoder_Ctl_Data[SlaveNo] = Encoder_Ctl_Data[SlaveNo] & (int.MaxValue ^ (int)(128 * Math.Pow(256, EncoderNo))) | enable * 128 * (int)(Math.Pow(256, EncoderNo));
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Encoder_Ctl, Encoder_Ctl_Data[SlaveNo]);
            return ret;

        }

        /// <summary>
        /// 重置预设定比较器触发数据
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="PreCompareNo">预设定比较器号0-3</param>
        /// <returns></returns>
        public static int PreCmp_ResetTrigData(int CardNo, int SlaveNo, int PreCompareNo)
        {
            int ret = 0;
            int data = (int)Math.Pow(2, PreCompareNo);
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Pre_Reset, data);
            return ret;
        }

        /// <summary>将预设定比较器和编码器绑定</summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="EncoderNo"></param>
        /// <param name="PreCompareNo">预设定比较器号</param>
        /// <returns></returns>
        public static int PreCmp_BindingEncoder(int CardNo, int SlaveNo, int EncoderNo, int PreCompareNo)
        {
            int ret = 0;
            //设置编码器输入映射到比较器
            Mask_Pre_Data[SlaveNo] = Mask_Pre_Data[SlaveNo] & (int.MaxValue ^ (int)(15 * Math.Pow(16, PreCompareNo))) | (int)Math.Pow(2, EncoderNo) * (int)(Math.Pow(16, PreCompareNo));
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_Pre, Mask_Pre_Data[SlaveNo]);
            return ret;
        }

        /// <summary>
        /// 设定预设定比较器触发运行方向
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="PreCompareNo">预设定比较器号0-3</param>
        /// <param name="dir">预设定比较器号比较方向：0-正向，1-反向，2-双向</param>
        /// <returns></returns>
        public static int PreCmp_SetTrigDir(int CardNo, int SlaveNo, int PreCompareNo, int dir)
        {
            int ret = 0;
            PreCompare_dir[SlaveNo] = PreCompare_dir[SlaveNo] & (int.MaxValue ^ (int)(3 * Math.Pow(4, PreCompareNo))) | dir * (int)(Math.Pow(4, PreCompareNo));
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.PreCompare_dir, PreCompare_dir[SlaveNo]);
            return ret;

        }

        /// <summary>
        /// 压入预设定比较器触发点位
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="PreCompareNo">预设定比较器号0-3</param>
        /// <param name="Pos_Array">位置数组，长度1-1023</param>
        /// <returns></returns>
        public static int PreCmp_SetTrigData(int CardNo, int SlaveNo, int PreCompareNo, int[] Pos_Array)
        {
            int ret = 0;
            ret = PreCmp_ResetTrigData(CardNo, SlaveNo, PreCompareNo);
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.PreCompare0_fifo + 0x1000 * PreCompareNo, Pos_Array.Length);
            int address = 0;
            for (int i = 1; i <= Pos_Array.Length; i++)
            {
                address = (int)Register_Address.PreCompare0_fifo + 0x1000 * PreCompareNo + 0x4 * i;
                SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)address, Pos_Array[i - 1]);
            }
            return ret;

        }

        /// <summary>
        /// 设置预设定比较器使能状态
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">CMP从站号</param>
        /// <param name="PreCompareNo">预设定比较器号0~3</param>
        /// <param name="Enable">使能状态 0-关闭 1-使能</param>
        /// <returns></returns>
        public static int PreCmp_SetEnable(int CardNo, int SlaveNo, int PreCompareNo, int Enable)
        {
            lock (lockerenable)
            {
                int ret = 0;
                int slaveid = SlaveNo;
                if (Enable == 0)
                {
                    PreCompareMask[slaveid] = PreCompareMask[slaveid] ^ (uint)Math.Pow(2, PreCompareNo);//按位置0
                    Compare_enable_status[slaveid] = (Compare_enable_status[slaveid] & (uint.MaxValue ^ 0xf)) | PreCompareMask[slaveid];
                    ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Compare_en, Compare_enable_status[slaveid]);
                    System.Threading.Thread.Sleep(5);
                    PreCompareMask[slaveid] = PreCompareMask[slaveid] ^ (uint)Math.Pow(2, PreCompareNo);//按位置0
                    Compare_enable_status[slaveid] = Compare_enable_status[slaveid] & (uint.MaxValue ^ 0xf) | PreCompareMask[slaveid];
                    ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Compare_en, Compare_enable_status[slaveid]);
                }
                else if (Enable == 1)
                {
                    PreCompareMask[slaveid] = PreCompareMask[slaveid] | (uint)Math.Pow(2, PreCompareNo);//按位置1
                    Compare_enable_status[slaveid] = Compare_enable_status[slaveid] & (uint.MaxValue ^ 0xf) | PreCompareMask[slaveid];
                    ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Compare_en, Compare_enable_status[slaveid]);
                }
                return ret;
            }
        }

        /// <summary>
        /// 线性比较器和编码器绑定
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="EncoderNo">编码器号：0-3</param>
        /// <param name="LineCompareNo">线性比较器号：0-9</param>
        /// <returns></returns>
        public static int LineCmp_BingdingEncoder(int CardNo, int SlaveNo, int EncoderNo, int LineCompareNo)
        {
            int ret = 0;
            //设置编码器输入映射到比较器0
            if (0 <= EncoderNo && EncoderNo <= 3)
            {
                if (LineCompareNo >= 0 && LineCompareNo <= 7)
                {
                    Mask_Line0_Data[SlaveNo] = Mask_Line0_Data[SlaveNo] & (uint.MaxValue ^ (uint)(15 * Math.Pow(16, LineCompareNo))) | (uint)Math.Pow(2, EncoderNo) * (uint)(Math.Pow(16, LineCompareNo));
                    ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_line0, Mask_Line0_Data[SlaveNo]);
                }
                else if (LineCompareNo >= 8 && LineCompareNo <= 9)
                {
                    Mask_Line1_Data[SlaveNo] = Mask_Line1_Data[SlaveNo] & (uint.MaxValue ^ (uint)(15 * Math.Pow(16, LineCompareNo - 8))) | (uint)Math.Pow(2, EncoderNo) * (uint)(Math.Pow(16, LineCompareNo - 8));
                    ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_line1, Mask_Line1_Data[SlaveNo]);
                }
            }
            return ret;

        }

        /// <summary>
        /// 设置线性比较器比较触发参数
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="LineCompareNo">线性比较器：0~9</param>
        /// <param name="StartPos">线性触发起始点</param>
        /// <param name="EndPos">线性触发终止点</param>
        /// <param name="Interval">线性触发间隔</param>
        /// <returns></returns>
        public static int LineCmp_SetTriggerData(int CardNo, int SlaveNo, int LineCompareNo, int StartPos, int EndPos, int Interval)
        {
            int ret = 0;
            //设置线性触发起始坐标
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)(Register_Address.Start_line0 + 0x4 * LineCompareNo), StartPos);
            if (ret < 0)
                return ret;

            //设置线性触发结束坐标
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)(Register_Address.End_line0 + 0x4 * LineCompareNo), EndPos);
            if (ret < 0)
                return ret;

            //设置线性触发触发间隔
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)(Register_Address.Gap_line0 + 0x4 * LineCompareNo), Interval);


            return ret;


        }

        /// <summary>
        /// 设置线性比较器使能状态
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">cmp从站号</param>
        /// <param name="LineCompareNo">线性比较器号 0~9</param>
        /// <param name="Enable">使能状态：0-关闭 1-使能</param>
        /// <returns></returns>
        public static int LineCmp_SetEnable(int CardNo, int SlaveNo, int LineCompareNo, int Enable)
        {
            lock (lockerenable)
            {
                int ret = 0;
                int slaveid = SlaveNo;
                if (Enable == 0)
                {

                    {
                        LineCompareMask[slaveid] = LineCompareMask[slaveid] ^ (uint)Math.Pow(2, LineCompareNo);//按位置0
                        Compare_enable_status[slaveid] = Compare_enable_status[slaveid] & (uint.MaxValue ^ 0x3FF0000) | (LineCompareMask[slaveid] * 0x10000);//|PreCompareMask;
                        ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Compare_en, Compare_enable_status[slaveid]);
                        System.Threading.Thread.Sleep(5);
                        LineCompareMask[slaveid] = LineCompareMask[slaveid] ^ (uint)Math.Pow(2, LineCompareNo);//按位置0
                        Compare_enable_status[slaveid] = Compare_enable_status[slaveid] & (uint.MaxValue ^ 0x3FF0000) | (LineCompareMask[slaveid] * 0x10000);//|PreCompareMask;
                        ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Compare_en, Compare_enable_status[slaveid]);

                    }
                }
                else if (Enable == 1)
                {
                    LineCompareMask[slaveid] = LineCompareMask[slaveid] | (uint)Math.Pow(2, LineCompareNo); //按位置1
                    Compare_enable_status[slaveid] = Compare_enable_status[slaveid] & (uint.MaxValue ^ 0x3FF0000) | (LineCompareMask[slaveid] * 0x10000);//|PreCompareMask;
                    SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Compare_en, Compare_enable_status[slaveid]);

                }
                return ret;
            }
        }


        /// <summary>
        /// 设置触发输出口的输出模式
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="Mode">模式：0-通用DO，1-位置比较输出，2-PWM输出</param>
        /// <returns></returns>
        public static int TriggerOut_SetOutMode(int CardNo, int SlaveNo, int Mode)
        {
            int ret = 0;
            //设置输出口模式为编码器比较输出
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.MODE_OUT, Mode);
            return ret;
        }

        /// <summary>
        /// 设置脉冲输出口的脉冲宽度
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="TriggerOutNum">脉冲输出口</param>
        /// <param name="PulseWidth">脉冲宽度</param>
        /// <returns></returns>
        public static int TriggerOut_SetPulseWidth(int CardNo, int SlaveNo, int TriggerOutNum, int PulseWidth)
        {
            int ret = 0;
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)(Register_Address.Pulse_width0 + 0x4 * TriggerOutNum), PulseWidth);
            return ret;

        }


        /// <summary>
        /// 设置触发输出口的功能
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="TriggerOutNum">触发输出通道号</param>
        /// <param name="LineCompareMask">绑定的线性比较器号0-9，每一位对应一个线性比较器，bit0对应比较器0</param>
        /// <param name="PreCompareMask">绑定的预设定比较器号0-3，每一位对应一个预设定比较器，bit0对应预设比较器0</param>
        /// <param name="PulsePolarity">输出极性 0：不取反 1：取反</param>
        /// <returns></returns>
        public static int TriggerOut_SetParam(int CardNo, int SlaveNo, int TriggerOutNum, uint LineCompareMask, uint PreCompareMask, uint PulsePolarity = 0)
        {
            int ret = 0;

            if (TriggerOutNum == 0)
            {
                Mask_map0_Data[SlaveNo] = Mask_map0_Data[SlaveNo] & (UInt32.MaxValue ^ 65535) | (LineCompareMask * ((uint)Math.Pow(0x10000, (uint)TriggerOutNum))) | (0x400 * PreCompareMask * ((uint)Math.Pow(0x10000, (uint)TriggerOutNum))) | (PulsePolarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum)));
                ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map0, Mask_map0_Data[SlaveNo]);
            }
            else if (TriggerOutNum == 1)
            {
                Mask_map0_Data[SlaveNo] = Mask_map0_Data[SlaveNo] & (UInt32.MaxValue ^ 4294901760) | (LineCompareMask * ((uint)Math.Pow(0x10000, (uint)TriggerOutNum))) | (0x400 * PreCompareMask * ((uint)Math.Pow(0x10000, (uint)TriggerOutNum))) | (PulsePolarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum)));
                ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map0, Mask_map0_Data[SlaveNo]);
            }



            else if (TriggerOutNum == 2)
            {
                Mask_map1_Data[SlaveNo] = Mask_map1_Data[SlaveNo] & (UInt32.MaxValue ^ 65535) | (LineCompareMask * ((uint)Math.Pow(0x10000, (uint)TriggerOutNum - 2))) | (0x400 * PreCompareMask * ((uint)Math.Pow(0x10000, (uint)TriggerOutNum - 2))) | (PulsePolarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum - 2)));
                ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map1, Mask_map1_Data[SlaveNo]);

            }

            else if (TriggerOutNum == 3)
            {
                Mask_map1_Data[SlaveNo] = Mask_map1_Data[SlaveNo] & (UInt32.MaxValue ^ 4294901760) | (LineCompareMask * ((uint)Math.Pow(0x10000, (uint)TriggerOutNum - 2))) | (0x400 * PreCompareMask * ((uint)Math.Pow(0x10000, (uint)TriggerOutNum - 2))) | (PulsePolarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum - 2)));
                ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map1, Mask_map1_Data[SlaveNo]);
            }

            return ret;

        }


        /// <summary>
        /// 重置触发输出计数
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="TriggerOutNum">触发输出通道</param>
        /// <returns></returns>
        public static int TriggerOut_ResetCounter(int CardNo, int SlaveNo, uint TriggerOutNum)
        {
            int ret = 0;
            int data = 0;
            data = (int)Math.Pow(2, TriggerOutNum);
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Pulse_counter_reset, data);
            ret = SetData(CardNo, SlaveNo, (int)Cmd.Write_PL_REG, (int)Register_Address.Pulse_counter_reset, 0);
            return ret;
        }


        /// <summary>
        /// 获取触发输出计数
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="SlaveNo">从站号</param>
        /// <param name="TriggerOutNum">触发通道号</param>
        /// <param name="TrigCount">触发计数值</param>
        /// <returns></returns>
        public static int TriggerOut_GetCounter(int CardNo, int SlaveNo, int TriggerOutNum, ref uint TrigCount)
        {
            int ret = 0;
            uint data = 0;
            ret = APS168.APS_get_field_bus_od_data(CardNo, 0, SlaveNo, 0, 5 + TriggerOutNum, ref data);
            TrigCount = data;
            return ret;
        }

        public static int TriggerOut_SetManualOutput(int CardNo, int SlaveNo, int TriggerOutNum)
        {
            int slaveid = SlaveNo;
            int ret = 0;
            uint bit_polarity = 0;
            if (TriggerOutNum == 0)
            {
                bit_polarity = (~(Mask_map0_Data[slaveid] >> 15) & 1) & 1;
                Mask_map0_Data[slaveid] = Mask_map0_Data[slaveid] & (uint.MaxValue ^ 65535) | (bit_polarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum)));
                ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map0, Mask_map0_Data[slaveid]);
                System.Threading.Thread.Sleep(5);
                bit_polarity = (~(Mask_map0_Data[slaveid] >> 15) & 1) & 1;
                Mask_map0_Data[slaveid] = Mask_map0_Data[slaveid] & (uint.MaxValue ^ 65535) | (bit_polarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum)));
                ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map0, Mask_map0_Data[slaveid]);
            }
            else if (TriggerOutNum == 1)
            {
                bit_polarity = (~(Mask_map0_Data[slaveid] >> 31) & 1) & 1;
                Mask_map0_Data[slaveid] = Mask_map0_Data[slaveid] & (uint.MaxValue ^ 4294901760) | (bit_polarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum)));
                ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map0, Mask_map0_Data[slaveid]);
                System.Threading.Thread.Sleep(5);
                bit_polarity = (~(Mask_map0_Data[slaveid] >> 31) & 1) & 1;
                Mask_map0_Data[slaveid] = Mask_map0_Data[slaveid] & (uint.MaxValue ^ 4294901760) | (bit_polarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum)));
                ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map0, Mask_map0_Data[slaveid]);
            }


            else if (TriggerOutNum == 2)
            {
                bit_polarity = (~(Mask_map1_Data[slaveid] >> 15) & 1) & 1;
                Mask_map1_Data[slaveid] = Mask_map1_Data[slaveid] & (uint.MaxValue ^ 65535) | (bit_polarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum - 2)));
                ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map1, Mask_map1_Data[slaveid]);
                System.Threading.Thread.Sleep(5);
                bit_polarity = (~(Mask_map1_Data[slaveid] >> 15) & 1) & 1;
                Mask_map1_Data[slaveid] = Mask_map1_Data[slaveid] & (uint.MaxValue ^ 65535) | (bit_polarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum - 2)));
                ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map1, Mask_map1_Data[slaveid]);
            }

            else if (TriggerOutNum == 3)
            {
                bit_polarity = (~(Mask_map1_Data[slaveid] >> 31) & 1) & 1;
                Mask_map1_Data[slaveid] = Mask_map1_Data[slaveid] & (uint.MaxValue ^ 4294901760) | (bit_polarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum - 2)));
                ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map1, Mask_map1_Data[slaveid]);
                System.Threading.Thread.Sleep(5);
                bit_polarity = (~(Mask_map1_Data[slaveid] >> 31) & 1) & 1;
                Mask_map1_Data[slaveid] = Mask_map1_Data[slaveid] & (uint.MaxValue ^ 4294901760) | (bit_polarity * (0x8000 * (uint)Math.Pow(0x10000, TriggerOutNum - 2)));
                ret = SetData(CardNo, slaveid, (int)Cmd.Write_PL_REG, (int)Register_Address.Mask_map1, Mask_map1_Data[slaveid]);
            }

            return ret;

        }

        private static int addresstodata(int cmd, int address)
        {

            return cmd + address * 0x100;

        }


        public static int SetData(int CardID, int SlaveNo, int cmd, int address, long data)
        {
            lock (locker)
            {
                int ret = 0;
                uint data1 = 0;
                ret = APS168.APS_set_field_bus_od_data(CardID, 0, SlaveNo, 0, 1, data1);
                System.Threading.Thread.Sleep(2);
                uint data2 = (uint)Math.Pow(2, 31) | (uint)(cmd * Math.Pow(2, 24)) | (uint)address;
                ret = APS168.APS_set_field_bus_od_data(CardID, 0, SlaveNo, 0, 2, (uint)data);
                System.Threading.Thread.Sleep(2);
                ret = APS168.APS_set_field_bus_od_data(CardID, 0, SlaveNo, 0, 1, data2);
                System.Threading.Thread.Sleep(2);
                return ret;
            }
        }
        public static int GetData(int CardID, int SlaveNo, int cmd, int address, ref uint dataout)
        {
            lock (locker)
            {
                int ret = 0;
                uint data1 = 0;
                ret = APS168.APS_set_field_bus_od_data(CardID, 0, SlaveNo, 0, 1, data1);
                System.Threading.Thread.Sleep(2);
                uint data2 = (uint)Math.Pow(2, 31) | (uint)(cmd * Math.Pow(2, 24)) | (uint)address;
                ret = APS168.APS_set_field_bus_od_data(CardID, 0, SlaveNo, 0, 1, data1);
                System.Threading.Thread.Sleep(2);
                ret = APS168.APS_get_field_bus_od_data(CardID, 0, SlaveNo, 0, 9, ref dataout);
                System.Threading.Thread.Sleep(2);
                return ret;
            }
        }

    }


}
