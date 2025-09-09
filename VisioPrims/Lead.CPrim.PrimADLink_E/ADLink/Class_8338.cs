using System;
using System.Threading;
using System.Threading.Tasks;
using APS_Define_W32;
using APS168_W64;

namespace PCIe_8338
{
    internal class Class_8338
    {
        internal static int _bufFreeSpace, _bufUsageSpace, _bufRunningCnt;
        internal static int _totaSlaveNum;
        internal static int BusNo = 0;//EtherCAT , BUS_NO=0

        //internal static bool Initialed;
        //internal static bool LoadedXmlFile;
        internal static bool Connected;

        internal static int TotalCardNum;

        /// <summary>
        /// APS_line_all  直线插补
        /// </summary>
        /// <param name="AxisArray"></param>
        /// <param name="Position"></param>
        /// <param name="Option"></param>
        /// <returns></returns>
        public static int _2D_LinearMove_all(int[] AxisArray, double[] Position, int Option)
        {
            var ret = 0;
            //int Option = option;
            //int axis = StartAxis;
            var dimension = 2;
            double TransPara = 0;
            double Vs = 0;
            double Vm = 10000;
            double Ve = 0;
            double Acc = 1000000;
            double Dec = 1000000;
            var Sfac = 0.5;
            var wait = new ASYNCALL();

            var Axis_ID_Array = AxisArray;
            var positionArray = Position;

            for (var i = 0; i < dimension; i++)
            {
                //Check servo on or not

                var motionIoStatus = APS168.APS_motion_io_status(Axis_ID_Array[i]);

                var status = (motionIoStatus & (1 << 7)) != 0;
                if (!status) APS168.APS_set_servo_on(Axis_ID_Array[i], 1);
            }
            Thread.Sleep(500);// Wait stable.

            // Execute 4 interpolation move useing bufferd mode. Note option using "ITP_OPT_BUFFERED"

            ret = APS168.APS_line_all(
                dimension,
                Axis_ID_Array,
                Option,
                positionArray,
                ref TransPara,
                Vs,
                Vm,
                Ve,
                Acc,
                Dec,
                Sfac,
                ref wait
                );
            return ret;
        }

        /// <summary>
        /// 绝对运动
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="Pulse"></param>
        /// <param name="Acc"></param>
        /// <param name="Dec"></param>
        /// <param name="Vm"></param>
        /// <returns></returns>
        public static int AbsluteMove(int Axis, int Pulse, double Acc, double Dec, int Vm)
        {
            //Axis_Status q = new Axis_Status();

            var praAcc = Acc;
            var praDec = Dec;
            var praVm = Vm;

            var axis = Axis;
            var pulse = Pulse;

            APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_ACC, praAcc); // Set acceleration rate
            APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_DEC, praDec); // Set deceleration rate

            var task = new Task(() =>
            {
                APS168.APS_absolute_move(axis, pulse, praVm);

                //等待Motion Down完成
                var motionStatusMdn = 5;
                while ((APS168.APS_motion_status(axis) & (1 << motionStatusMdn)) == 0) Thread.Sleep(100);
            });
            task.Start();
            return 0;
        }

        /// <summary>
        /// Check and Servo On
        /// </summary>
        /// <param name="Axis"></param>
        public static void Check_Servo_ON(int Axis)
        {
            var motionIoStatus = APS168.APS_motion_io_status(Axis);

            var status = (motionIoStatus & (1 << 7)) != 0;
            if (!status) APS168.APS_set_servo_on(Axis, 1);
        }

        public static int Close()
        {
            APS168.APS_close();//Close all card

            return 0;
        }

        public static bool DO_Control(int Card_ID, int nMoudle, int xChannel)
        {
            var Board_ID = Card_ID;
            //int BUS_No = 0;
            var DO_Value = -1;

            //先获取 DO 的输出状态
            var ret = APS168.APS_get_field_bus_d_channel_output(Board_ID, BusNo, nMoudle, xChannel, ref DO_Value);
            if (DO_Value == 0)
                DO_Value = 1;
            else
                DO_Value = 0;
            //设置输出状态
            ret = APS168.APS_set_field_bus_d_channel_output(Board_ID, BusNo, nMoudle, xChannel, DO_Value);
            return true;
        }

        //************************************************************************
        //************************Card  Parameter And Motion**********************
        //************************************************************************
        /// <summary>
        /// EMG Logic
        /// </summary>
        /// <param name="Card_ID"></param>
        public static void EMG_Logic(int Card_ID)
        {
            var BOD_Param = 0;
            var BOD_Param_No = (int)APS_Define.PRB_EMG_LOGIC;//0x00;//卡片参数编号BOD_Param_No=0x00时，为急停信号逻辑
            APS168.APS_get_board_param(Card_ID, BOD_Param_No, ref BOD_Param);

            BOD_Param = 1 - BOD_Param;//取反

            APS168.APS_set_board_param(Card_ID, BOD_Param_No, BOD_Param);
        }

        /// <summary>
        /// 获取伺服报警代码
        /// </summary>
        /// <param name="Axis">轴号</param>
        /// <param name="AlarmCode">报警代码</param>
        public static int GetFieldBusAlarm(int Axis, ref uint AlarmCode)
        {
            uint alarmCode = 0;
            var ret = APS168.APS_get_field_bus_alarm(Axis, ref alarmCode);
            AlarmCode = alarmCode;

            return ret;
        }

        //扫描成功，查看连接的Slave数
        public static int GetFieldBUSInfo(int Card_ID)
        {
            int ret;
            var Info_Array = 0;
            var Info_Count = 0;
            var Slave_Count = -1;
            ret = APS168.APS_get_field_bus_last_scan_info(Card_ID, BusNo, ref Info_Array, 1, ref Info_Count);//get the field bus info after system scanning
            if (ret == (int)APS_Define.ERR_NoError)
                //To get how many slaves number in the fieldbus
                Slave_Count = Info_Array;//返回的是从站数量
            else
                return -1;
            return Slave_Count;
        }

        /// <summary>
        /// This is the lowest level function which you can directely get value from EtherCAT PDO memory and align to EtherCAT cycle time.
        /// </summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="byteOffset">指定PDO数据的偏移地址</param>
        /// <param name="size">PDO数据的大小</param>
        /// <param name="value">返回指定PDO数据的值</param>
        /// <returns></returns>
        public static int GetFieldBusPdo(int Card_ID, ushort byteOffset, ushort size, ref uint value)
        {
            var ret = 0;
            var Board_ID = Card_ID;
            ushort ByteOffset = byteOffset, Size = size;
            uint Value = 0;
            ret = APS168.APS_get_field_bus_pdo(Board_ID, BusNo, ByteOffset, Size, ref Value);
            value = Value;

            return ret;
        }

        /// <summary>
        /// 获取某个模块的SDO数据
        /// </summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="MOD_No">模块号</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static int GetFieldBusSdo(int Card_ID, int MOD_No, ref byte[] data)
        {
            var ret = 0;
            var Board_ID = Card_ID;
            //int BUS_No = 0;
            var SlaveId = MOD_No;
            ushort ODIndex = 0x60fd;
            ushort ODSubIndex = 0;
            var Data = new byte[5];
            uint DataLen = 4;
            uint OutDatalen = 0;
            uint Timeout = 5000;
            uint Flags = 0;
            ret = APS168.APS_get_field_bus_sdo(Board_ID,
                                                BusNo,
                                                SlaveId,
                                                ODIndex,
                                                ODSubIndex,
                                                Data,
                                                DataLen,
                                                ref OutDatalen,
                                                Timeout,
                                                Flags);
            data = Data;
            return ret;
        }

        //*************************************************************************************
        //***************************************SDO******************************************
        //*************************************************************************************
        public static int GetFieldBusSDOData(int Card_ID, int MOD_NO, ushort Index, ushort SubIndex, byte[] data, uint dataLength, out int Val)
        {
            var val = 0;
            var Board_ID = Card_ID;
            var BUS_No = 0;
            var SlaveId = MOD_NO;

            //ushort ODIndex =(ushort)( Index%10+Index/10*16+Index/100*256+Index/1000*4096);
            //ushort ODIndex = Convert.ToUInt32(Index, 16);

            var ODIndex = Index;
            var ODSubIndex = SubIndex;
            var DataLen = dataLength / 8;
            var Data = new byte[DataLen];
            uint OutDatalen = 0;
            uint Timeout = 5000;
            uint Flags = 0;
            var ret = APS168.APS_get_field_bus_sdo(Board_ID,
                                                   BUS_No,
                                                   SlaveId,
                                                   ODIndex,
                                                   ODSubIndex,
                                                   Data,
                                                   DataLen,
                                                   ref OutDatalen,
                                                   Timeout,
                                                   Flags
                                                   );

            //数据处理，函数读取出来的 DATA 是一个 byte[] 数组读出来的，数组里面每个 byte 是 8 位，需要处理之后组合成10 进制数据
            for (var i = 0; i < OutDatalen; i++) val += Data[i] * Convert.ToInt32(Math.Pow(2, i * 8));
            Val = val;

            return ret;
        }

        //************************************************************************
        //*********************************DIO操作*********************************
        //************************************************************************
        public static void GetInputStatus(int Card_ID, int MOD_No_In, int SubMOD_No, int ODIndex, ref uint RawData)
        {
            var Board_ID = Card_ID;
            //uint diValue = 0;
            var BUS_No = 0;
            APS168.APS_get_field_bus_od_data(Board_ID, BUS_No, MOD_No_In, SubMOD_No, ODIndex, ref RawData);

            //APS168.APS_get_field_bus_d_port_input(Board_ID, BUS_NO, MOD_No_In, Port_No, ref DiValue);

            //return diValue;
        }

        public static int GetLct4DiModule(int cardId, int slaveNo, int group, ref uint[] value)
        {
            try
            {
                uint value32 = 0;
                value = new uint[] { 0, 0, 0, 0 };
                if (group < 0 || group > 3) return -99;
                var iRet = APS168.APS_get_field_bus_d_port_input(cardId, 0, slaveNo, group, ref value32);
                var i = 0;
                do
                {
                    switch (i)
                    {
                        case 0:
                            value[0] = value32 & ((uint)Math.Pow(2, 8) - 1);
                            break;

                        case 1:
                            value[1] = (value32 & ((uint)Math.Pow(2, 16) - 1)) >> 8;
                            break;

                        case 2:
                            value[2] = (value32 & ((uint)Math.Pow(2, 24) - 1)) >> 16;
                            break;

                        case 3:
                            value[3] = value32 >> 24;
                            break;
                    }
                } while (i++ < 4);
                return iRet;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -10;
            }
            
        }
        public static int GetLctMiniDiModule(int cardId, int slaveNo, ref uint value)
        {
            try
            {
                var iRet = APS168.APS_get_field_bus_d_port_input(cardId, 0, slaveNo, 0, ref value);
                return iRet;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -10;
            }

        }
        public static int GetLctMiniDoModule(int cardId, int slaveNo, ref uint value)
        {
            try
            {
                var iRet = 0;
                var ports = new uint[4];
                value = 0;
                for (var i = 0; i < 4; i++)
                {
                    iRet = APS168.APS_get_field_bus_d_port_output(cardId, 0, slaveNo, i, ref ports[i]);
                }

                value = ports[0] | (ports[1] << 8) | (ports[2] << 16) | (ports[3] << 24);
                
                return iRet;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -10;
            }

        }
        public static int GetLct4DOModule(int cardId, int slaveNo, int moduleNo, ref uint value)
        {
            return APS168.APS_get_field_bus_d_port_output(cardId, 0, slaveNo, moduleNo, ref value);
        }

        public static void GetLctDiModule(int cardId, int slaveNo, int modNo, ref uint value)
        {
            uint value32 = 0;
            if (modNo >= 1 && modNo <= 4) APS168.APS_get_field_bus_d_port_input(cardId, 0, slaveNo, 0, ref value32);
            if (modNo >= 5 && modNo <= 8)
            {
                APS168.APS_get_field_bus_d_port_input(cardId, 0, slaveNo, 1, ref value32);
                modNo -= 4;
            }
            if (modNo >= 9 && modNo <= 12)
            {
                APS168.APS_get_field_bus_d_port_input(cardId, 0, slaveNo, 2, ref value32);
                modNo -= 8;
            }
            if (modNo >= 13 && modNo <= 16)
            {
                APS168.APS_get_field_bus_d_port_input(cardId, 0, slaveNo, 3, ref value32);
                modNo -= 12;
            }

            switch (modNo)
            {
                case 1:
                    value = value32 & ((uint)Math.Pow(2, 8) - 1);
                    break;

                case 2:
                    value = (value32 & ((uint)Math.Pow(2, 16) - 1)) >> 8;
                    break;

                case 3:
                    value = (value32 & ((uint)Math.Pow(2, 24) - 1)) >> 16;
                    break;

                case 4:
                    value = value32 >> 24;
                    break;

                default:
                    value = 0;
                    break;
            }
        }

        public static void GetLctDoModule(int cardId, int slaveNo, int modNo, ref uint value)
        {
            APS168.APS_get_field_bus_od_data(cardId, 0, slaveNo, modNo, 2, ref value);
        }

        /// <summary>Get loss package percentage of moving average per 1000 packets.</summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="loss_count">每1000个数据包中丢失包的数量 如：值为1，则丢包数为1%，值为90，则丟包数为90%</param>
        /// <returns></returns>
        public static int GetLossPackagePercent(int Card_ID, out int loss_count)
        {
            var ret = 0;
            var Board_ID = Card_ID;
            //int Bus_No = 0;
            var Loss_Count = 0;
            ret = APS168.APS_get_field_bus_loss_package(Board_ID, BusNo, ref Loss_Count);
            loss_count = Loss_Count;

            return ret;
        }
        /// <summary>获取 EtherCAT OD 原始数据</summary>
        /// <param name="cardId">卡号</param>
        /// <param name="slaveNo">节点号</param>
        /// <param name="subModNo">SubModule No.</param>
        /// <param name="OdIndex">Index</param>
        /// <param name="rawData">Value</param>
        /// <returns>错误代码</returns>
        public static int GetODData(int cardId, int slaveNo, int subModNo, int OdIndex, ref uint rawData)
        {
            return APS168.APS_get_field_bus_od_data(cardId, 0, slaveNo, subModNo, OdIndex, ref rawData);
        }

        public static void GetPortOutput(int Card_ID, int MOD_No_Out, int Port_No, ref uint DoValue)
        {
            var Board_ID = Card_ID;

            APS168.APS_get_field_bus_d_port_output(Board_ID, BusNo, MOD_No_Out, Port_No, ref DoValue);
        }

        /// <summary>最后一次扫描成功后，查看Slave信息</summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="MOD_NO">模块号</param>
        /// <param name="venderID">供应商 ID</param>
        /// <param name="totalAxisNum">总轴数</param>
        /// <param name="axisId">轴号</param>
        /// <param name="di_ModuleNum">DI模块总数</param>
        /// <param name="do_ModuleNum">DO模块总数</param>
        public static void GetSlaveInformation(int Card_ID, int MOD_NO, ref int venderID, ref int totalAxisNum, ref int axisId, ref int di_ModuleNum, ref int do_ModuleNum)
        {
            int ret;
            var Board_ID = Card_ID;
            //int BUS_No = 0;//The index of field bus(only support index 0)
            var MOD_No = MOD_NO;

            var Module_info = new EC_MODULE_INFO();
            ret = APS168.APS_get_field_bus_module_info(Board_ID, BusNo, MOD_No, ref Module_info);//get the slave device information after system starting
            if (ret == (int)APS_Define.ERR_NoError)
            {
                venderID = Module_info.VendorID;
                totalAxisNum = Module_info.TotalAxisNum;
                di_ModuleNum = Module_info.DI_ModuleNum;
                do_ModuleNum = Module_info.DO_ModuleNum;
                axisId = Module_info.Axis_ID[0];
            }
        }

        ///// <summary>最后一次扫描成功后，查看Slave信息</summary>
        ///// <param name="Card_ID">卡号</param>
        ///// <param name="MOD_NO">模块号</param>
        ///// <param name="venderID">供应商 ID</param>
        ///// <param name="totalAxisNum">总轴数</param>
        ///// <param name="axisId">轴号</param>
        ///// <param name="di_ModuleNum">DI模块总数</param>
        ///// <param name="do_ModuleNum">DO模块总数</param>
        public static void GetSlaveInformation(int Card_ID, int MOD_NO, ref int venderID, ref int totalAxisNum, ref int[] axisId, ref int di_ModuleNum, ref int[] di_ModuleType, ref int do_ModuleNum, ref int[] do_ModuleType, ref int ai_ModuleNum, ref int[] ai_ModuleType, ref int ao_ModuleNum, ref int[] ao_ModuleType)
        {
            int ret;
            var Board_ID = Card_ID;
            //int BUS_No = 0;//The index of field bus(only support index 0)
            var MOD_No = MOD_NO;

            var Module_info = new EC_MODULE_INFO();
            ret = APS168.APS_get_field_bus_module_info(Board_ID, BusNo, MOD_No, ref Module_info);//get the slave device information after system starting
            if (ret == (int)APS_Define.ERR_NoError)
            {
                venderID = Module_info.VendorID;
                totalAxisNum = Module_info.TotalAxisNum;
                di_ModuleNum = Module_info.DI_ModuleNum - 1;
                do_ModuleNum = Module_info.DO_ModuleNum;
                ai_ModuleNum = Module_info.AI_ModuleNum;
                ao_ModuleNum = Module_info.AO_ModuleNum;
                for (var i = 0; i < Module_info.Axis_ID.Length; i++) axisId[i] = Module_info.Axis_ID[i];

                for (var i = 0; i < Module_info.DI_ModuleType.Length; i++) di_ModuleType[i] = Module_info.DI_ModuleType[i];

                for (var i = 0; i < Module_info.DO_ModuleType.Length; i++) do_ModuleType[i] = Module_info.DO_ModuleType[i];

                for (var i = 0; i < Module_info.AI_ModuleType.Length; i++) ai_ModuleType[i] = Module_info.AI_ModuleType[i];

                for (var i = 0; i < Module_info.AO_ModuleType.Length; i++) ao_ModuleType[i] = Module_info.AO_ModuleType[i];
            }
        }

        //џџџџџџџџџџџџ
        //获取某个从站的在线状态
        // Live值为 33 ，模块为在线状态，值为 16 为不在线状态
        public static int GetSlaveOnlineStatus(int cardId, int modNo, out int live)
        {
            var boardId = cardId;
            //int BUS_No = 0;
            var Live = 0;
            var ret = APS168.APS_get_slave_online_status(boardId, BusNo, modNo, ref Live);
            live = Live;
            return ret;
        }

        //************************************************************************
        //*****************************Card Initial*******************************
        //************************************************************************
        public static int Initial(int Card_ID, ref int startAxisID, ref int totalSlaveNum)
        {
            //System assigned slave number
            int ret;                              // return value
            var BoardID_InBits = 0;
            var Mode = 0;                         //By system assigned
            var CardName = 0;

            ret = APS168.APS_initial(ref BoardID_InBits, Mode);
            if (ret >= 0)
            {
                //Initialed = true;
                TotalCardNum = BoardID_InBits;
                APS168.APS_get_card_name(Card_ID, ref CardName);
                //判断卡片是不是 PCIe-8334 或者 PCIe-8338
                if (CardName != (int)APS_Define.DEVICE_NAME_PCIE_8334 &&
                    CardName != (int)APS_Define.DEVICE_NAME_PCIE_8338 &&
                    CardName != (int)APS_Define.DEVICE_NAME_PCIE_8332)
                    ret = -1;
                //else

                APS168.APS_get_first_axisId(Card_ID, ref startAxisID, ref totalSlaveNum);
                _totaSlaveNum = totalSlaveNum;

                //    totaAxisNum = 64;   //一张卡最多支持64轴
            }

            return ret;
        }

        //************************************************************************
        //*********************************Field BUS*********************************
        //************************************************************************
        /// <summary>APS_arc2_ca 2D圆弧插补</summary>
        /// <param name="Axis_ID_Array"></param>
        /// <param name="CenterArray"></param>
        /// <param name="Angle"></param>
        /// <returns></returns>
        public static int Interpolation_2D_arc_move(int[] Axis_ID_Array, double[] CenterArray, double Angle)
        {
            var centerArray = new double[2] { 1000.0, 0.0 };
            centerArray = CenterArray;
            var angle = 1.0;
            angle = Math.PI / 180 * Angle;//转为弧度值
            double TransPara = 0;

            var wait = new ASYNCALL();
            // config speed profile
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_SF, 0.5);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_ACC, 10000.0);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_DEC, 10000.0);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_VM, 1000.0);

            //Check servo on or not
            for (var i = 0; i < 2; i++)
            {
                var motionIoStatus = APS168.APS_motion_io_status(Axis_ID_Array[i]);

                var status = (motionIoStatus & (1 << 7)) != 0;
                if (!status) APS168.APS_set_servo_on(Axis_ID_Array[i], 1);

                Thread.Sleep(500);
            }

            // Start a 2 dimension linear interpolation
            var ret = APS168.APS_arc2_ca(
                  Axis_ID_Array // I32 *Axis_ID_Array
                , (int)APS_Define.OPT_RELATIVE  // I32 Option
                , centerArray   // F64 *CenterArray
                , angle         // F64 Angle
                , ref TransPara    // F64 *TransPara
                , ref wait // ASYNCALL *Wait
            );
            return ret;
        }

        /// <summary>APS_arc2_ca_all</summary>
        /// <param name="AxisID"></param>
        /// <param name="CenterArray"></param>
        /// <param name="Angle"></param>
        /// <returns></returns>
        public static int Interpolation_2D_arc_move_all(int[] AxisID, double[] CenterArray, double Angle)
        {
            var Axis_ID_Array = new int[2];
            var centerArray = new double[2] { 0, 0 };
            double angle = 0;

            Axis_ID_Array = AxisID;
            centerArray = CenterArray;
            angle = Math.PI / 180 * Angle;//转为弧度值
            double TransPara = 0;

            var Dimension = 2;
            double Vs = 0;
            double Vm = 10000;
            double Ve = 0;
            double Acc = 100000;
            double Dec = 100000;
            var Sfac = 0.5;

            var Wait = new ASYNCALL();

            //Check servo on or not
            for (var i = 0; i < Dimension; i++)
            {
                var motionIoStatus = APS168.APS_motion_io_status(Axis_ID_Array[i]);

                var status = (motionIoStatus & (1 << 7)) != 0;
                if (!status) APS168.APS_set_servo_on(Axis_ID_Array[i], 1);
            }
            Thread.Sleep(500); // Wait stable.

            // Execute 4 interpolation move useing bufferd mode. Note option using "ITP_OPT_BUFFERED"
            var ret = APS168.APS_arc2_ca_all(
                Axis_ID_Array,
                (int)APS_Define.OPT_ABSOLUTE,
                centerArray,
                angle,
                ref TransPara,
                Vs,
                Vm,
                Ve,
                Acc,
                Dec,
                Sfac,
                ref Wait
                );
            return ret;
        }

        /// <summary>APS_line 线性插补</summary>
        /// <param name="Axis_ID_Array"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static int Interpolation_2D_line_move(int[] Axis_ID_Array, double[] Position)
        {
            var PositionArray = new double[2] { 1000.0, 2000.0 };
            PositionArray = Position;
            double TransPara = 0;
            var wait = new ASYNCALL();

            // config speed profile
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_SF, 0.5);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_ACC, 10000.0);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_DEC, 10000.0);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_VM, 1000.0);

            //Check servo on or not
            for (var i = 0; i < 2; i++)
            {
                var motionIoStatus = APS168.APS_motion_io_status(Axis_ID_Array[i]);

                var status = (motionIoStatus & (1 << 7)) != 0;
                if (!status) APS168.APS_set_servo_on(Axis_ID_Array[i], 1);
            }
            Thread.Sleep(500);

            // Start a 2 dimension linear interpolation
            var ret = APS168.APS_line(
                  2 // I32 Dimension
                , Axis_ID_Array // I32 *Axis_ID_Array
                , (int)APS_Define.OPT_RELATIVE  // I32 Option
                , PositionArray // F64 *PositionArray
                , ref TransPara    // F64 *TransPara
                , ref wait // ASYNCALL *Wait
            );
            return ret;
        }

        //3D螺旋未经测试
        /// <summary>APS_spiral_ca  3D螺旋补间运动   //未测试</summary>
        /// <param name="Axis_ID_Array"></param>
        /// <param name="CenterArray"></param>
        /// <param name="Angle"></param>
        /// <returns></returns>
        public static int Interpolation_3D_helical_move(int[] Axis_ID_Array, double[] CenterArray, double Angle)
        {
            var centerArray = new double[3] { 1000.0, 1000.0, 0 };
            var normalArray = new double[3] { 0, 0, 1 };
            var angle = Math.PI / 180 * Angle;
            var DeltaH = 500.0;
            var FinalR = 200.0;
            double TransPara = 0;
            int i;

            var Wait = new ASYNCALL();
            centerArray = CenterArray;
            angle = Angle;

            // config speed profile
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_SF, 0.5);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_ACC, 10000.0);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_DEC, 10000.0);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_VM, 2000.0);

            //Check servo on or not
            for (i = 0; i < 3; i++) APS168.APS_set_servo_on(Axis_ID_Array[i], 1);
            Thread.Sleep(500); // Wait stable.

            var ret = APS168.APS_spiral_ca(
                  Axis_ID_Array // I32 *Axis_ID_Array
                , (int)APS_Define.OPT_RELATIVE  // I32 Option
                , centerArray   // F64 *CenterArray
                , normalArray   // F64 *NormalArray
                , angle         // F64 Angle
                , DeltaH        // F64 DeltaH
                , FinalR        // F64 FinalR
                , ref TransPara // F64 *TransPara
                , ref Wait      // ASYNCALL *Wait
            );
            return ret;
        }

        /// <summary>APS_arc3_ce  3D圆弧插补</summary>
        /// <param name="AxisArray"></param>
        /// <returns></returns>
        public static int Interpolation_3DArcMove(int[] AxisArray)
        {
            //int Dimension = 3;
            var CenterArray = new[] { 1000.0, 1000.0, 0 };
            var EndArray = new[] { 1000.0, 1000.0, 1000.0 * Math.Sqrt(2) };

            var Axis_ID_Array = new int[3];

            Axis_ID_Array = AxisArray;
            short Dir = 0;
            var i = 0;
            double TransPara = 0;
            var p = new ASYNCALL();

            // config speed profile
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_SF, 0.5);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_ACC, 100000.0);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_DEC, 100000.0);
            APS168.APS_set_axis_param_f(Axis_ID_Array[0], (int)APS_Define.PRA_VM, 10000.0);

            //Check servo on or not
            for (i = 0; i < 3; i++) APS168.APS_set_servo_on(Axis_ID_Array[i], 1);
            Thread.Sleep(500); // Wait stable.

            var ret = APS168.APS_arc3_ce(
                  Axis_ID_Array // I32 *Axis_ID_Array
                , (int)APS_Define.OPT_RELATIVE  // I32 Option
                , CenterArray   // F64 *CenterArray
                , EndArray      // F64 *EndArray
                , Dir           // I16 Dir
                , ref TransPara    //F64 *TransPara
                , ref p // ASYNCALL *Wait
            );
            return ret;
        }

        //JOG运动
        public static int JOG_move(int Axis, int STA, int Dir, double Acc, double Dec, double Vm)
        {
            APS168.APS_set_axis_param(Axis, (int)APS_Define.PRA_JG_MODE, 1);//JOG 模式
            APS168.APS_set_axis_param(Axis, (int)APS_Define.PRA_JG_DIR, Dir);//JOG 方向
            APS168.APS_set_axis_param_f(Axis, (int)APS_Define.PRA_JG_ACC, Acc);//JOG 加速度
            APS168.APS_set_axis_param_f(Axis, (int)APS_Define.PRA_JG_DEC, Dec);//JOG 减速度
            APS168.APS_set_axis_param_f(Axis, (int)APS_Define.PRA_JG_VM, Vm);//JOG 最大速度

            Check_Servo_ON(Axis);
            var ret = APS168.APS_jog_start(Axis, STA);

            return ret;
        }

        public static void JOG_Stop(int Axis)
        {
            var motionStatusMdn = 5;
            while ((APS168.APS_motion_status(Axis) & (1 << motionStatusMdn)) == 0) APS168.APS_jog_start(Axis, 0);
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public static int LoadParameter(int cardID)
        {
            var ret = 0;

            //从 flash 加载数据
            //目前只支持从 flash 加载数据
            var Card_ID = cardID;
            ret = APS168.APS_load_parameter_from_flash(Card_ID);
            return ret;
        }

        /// <summary>
        /// Point table 连续运动
        /// </summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="Axis_ID_Array">轴队列</param>
        public static void PointTable_2D_Move(int Card_ID, int[] Axis_ID_Array)
        {
            var boardId = Card_ID;
            var ptbId = 0;          //Point table id 0
            var dimension = 2;      //2D point table

            var Status = new PTSTS();
            var Line = new PTLINE();
            var Arc2 = new PTA2CA();

            var doChannel = 0; //Do channel 0
            var doOn = 0;
            var doOff = 1;
            var i = 0;
            var ret = 0;

            //Check servo on or not
            for (i = 0; i < dimension; i++) ret = APS168.APS_set_servo_on(Axis_ID_Array[i], 1);

            Thread.Sleep(500); // Wait stable.

            //Enable point table
            ret = APS168.APS_pt_disable(boardId, ptbId);
            ret = APS168.APS_pt_enable(boardId, ptbId, dimension, Axis_ID_Array);

            //Configuration
            ret = APS168.APS_pt_set_absolute(boardId, ptbId); //Set to absolute mode
            ret = APS168.APS_pt_set_trans_buffered(boardId, ptbId); //Set to buffer mode
            ret = APS168.APS_pt_set_acc(boardId, ptbId, 10000); //Set acc
            ret = APS168.APS_pt_set_dec(boardId, ptbId, 10000); //Set dec

            //Get status
            //BitSts;	//b0: Is PTB work? [1:working, 0:Stopped]
            //b1: Is point buffer full? [1:full, 0:not full]
            //b2: Is point buffer empty? [1:empty, 0:not empty]
            //b3~b5: reserved

            ret = APS168.APS_get_pt_status(boardId, ptbId, ref Status);
            if ((Status.BitSts & 0x02) == 0) //Buffer is not Full
            {
                //Set 1st move profile
                ret = APS168.APS_pt_set_vm(boardId, ptbId, 10000); //Set vm to 10000
                ret = APS168.APS_pt_set_ve(boardId, ptbId, 5000); //Set ve to 5000

                //Set do command to sync with 1st point
                ret = APS168.APS_pt_ext_set_do_ch(boardId, ptbId, doChannel, doOn); //Set Do channel 0 to on

                //Set pt arc data
                Arc2.Center = new double[] { 1000, 1000 };
                Arc2.Angle = 180 * 3.14159265 / 180.0;   //180 degree
                Arc2.Index = new byte[] { 0, 1 };

                //Push 1st point to buffer
                ret = APS168.APS_pt_arc2_ca(boardId, ptbId, ref Arc2, ref Status);
            }

            //Get status
            ret = APS168.APS_get_pt_status(boardId, ptbId, ref Status);
            if ((Status.BitSts & 0x02) == 0) //Buffer is not Full
            {
                //Set 2nd move profile
                ret = APS168.APS_pt_set_vm(boardId, ptbId, 12000); //Set vm to 12000
                ret = APS168.APS_pt_set_ve(boardId, ptbId, 6000); //Set ve to 6000

                //Set do command to sync with 2nd point
                ret = APS168.APS_pt_ext_set_do_ch(boardId, ptbId, doChannel, doOff); //Set Do channel 0 to on

                //Set pt line data
                Line.Dim = 2;
                Line.Pos = new double[] { 0, 0, 0, 0, 0, 0 };//回到两个位置点 0，0

                //Push 2nd point to buffer
                ret = APS168.APS_pt_line(boardId, ptbId, ref Line, ref Status);
            }

            //Get status
            ret = APS168.APS_get_pt_status(boardId, ptbId, ref Status);
            if ((Status.BitSts & 0x02) == 0) //Buffer is not Full
            {
                //Set 3rd move profile
                ret = APS168.APS_pt_set_vm(boardId, ptbId, 10000); //Set vm to 10000
                ret = APS168.APS_pt_set_ve(boardId, ptbId, 5000); //Set ve to 5000

                //Set do command to sync with 3rd point
                ret = APS168.APS_pt_ext_set_do_ch(boardId, ptbId, doChannel, doOn); //Set Do channel 0 to off

                //Set pt arc data
                Arc2.Center = new double[] { 1000, 1000 };
                Arc2.Angle = 180 * 3.14159265 / 180.0; //180 degree
                Arc2.Index = new byte[] { 0, 1 };

                //Push 3rd point to buffer
                ret = APS168.APS_pt_arc2_ca(boardId, ptbId, ref Arc2, ref Status);
            }

            //Get status
            ret = APS168.APS_get_pt_status(boardId, ptbId, ref Status);
            if ((Status.BitSts & 0x02) == 0) //Buffer is not Full
            {
                //Set 4th move profile
                ret = APS168.APS_pt_set_vm(boardId, ptbId, 12000); //Set vm to 12000
                ret = APS168.APS_pt_set_ve(boardId, ptbId, 500); //Set ve to 500

                //Set do command to sync with 4th point
                ret = APS168.APS_pt_ext_set_do_ch(boardId, ptbId, doChannel, doOff); //Set Do channel 0 to on

                //Set pt line data
                Line.Dim = 2;
                Line.Pos = new double[] { 0, 0, 0, 0, 0, 0 };

                //Push 4th point to buffer
                ret = APS168.APS_pt_line(boardId, ptbId, ref Line, ref Status);
            }

            ret = APS168.APS_pt_start(boardId, ptbId);
            do
            {
                ret = APS168.APS_get_pt_status(boardId, ptbId, ref Status);
                _bufFreeSpace = Status.PntBufFreeSpace;
                _bufUsageSpace = Status.PntBufUsageSpace;
                _bufRunningCnt = (int)Status.RunningCnt;
                Thread.Sleep(100);
            }
            while (Status.PntBufUsageSpace > 0);
        }

        /// <summary>只有LCTE-16DIO-R 模块是一个port 16位</summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="MOD_NO">模块号=序号-1，即按照网线顺序，第一个模块MOD_NO=0</param>
        /// <param name="Port_NO">Port=0</param>
        /// <param name="Value">输出值</param>
        public static void PortOut_16(int Card_ID, int MOD_NO, int Port_NO, uint Value)
        {
            var BordID = Card_ID;
            //int BUS_No = 0;

            ////value=65535   all output
            var Port = Port_NO;
            var MOD_No = MOD_NO;
            APS168.APS_set_field_bus_d_port_output(BordID, BusNo, MOD_NO, Port, Value);//通过port方式输出
        }

        /// <summary>通过Port的方式输出，每个Port 8位</summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="MOD_NO">模块号=序号-1，即按照网线顺序，第一个模块MOD_NO=0</param>
        /// <param name="Port_NO">Port=0，1，2，3</param>
        /// <param name="Value">输出值</param>
        public static void PortOut_8(int Card_ID, int MOD_NO, int Port_NO, uint Value)
        {
            var BordID = Card_ID;
            //int BUS_No = 0;
            var Port = Port_NO;
            var MOD_No = MOD_NO;
            APS168.APS_set_field_bus_d_port_output(BordID, BusNo, MOD_NO, Port, Value);//通过port方式输出
        }

        /// <summary>
        /// 相对运动
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="Pulse"></param>
        /// <param name="Acc"></param>
        /// <param name="Dec"></param>
        /// <param name="Vm"></param>
        /// <returns></returns>
        public static int RelativeMove(int Axis, int Pulse, double Acc, double Dec, int Vm)
        {
            var praAcc = Acc;
            var praDec = Dec;
            var praVm = Vm;
            var axis = Axis;
            var pulse = Pulse;

            APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_ACC, praAcc); // Set acceleration rate
            APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_DEC, praDec); // Set deceleration rate

            var task = new Task(() =>
            {
                APS168.APS_relative_move(axis, pulse, praVm);

                //等待Motion Down完成
                var motionStatusMdn = 5;
                while ((APS168.APS_motion_status(axis) & (1 << motionStatusMdn)) == 0) Thread.Sleep(100);
            });
            task.Start();
            return 0;
        }

        /// <summary>
        /// 相对运动
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="Pulse"></param>
        /// <param name="Vm"></param>
        /// <returns></returns>
        public static int RelativeMove(int Axis, int Pulse, int Vm)
        {
            var praVm = Vm;
            var axis = Axis;
            var pulse = Pulse;

            var task = new Task(() =>
            {
                APS168.APS_relative_move(axis, pulse, praVm);

                //等待Motion Down完成
                var motionStatusMdn = 5;
                while ((APS168.APS_motion_status(axis) & (1 << motionStatusMdn)) == 0) Thread.Sleep(100);
            });
            task.Start();
            return 0;
        }

        //APS_reset_field_bus_alarm
        public static int ResetFieldBusAlarm(int Axis)
        {
            var ret = APS168.APS_reset_field_bus_alarm(Axis);

            return ret;
        }

        //扫描总线
        public static int ScanFieldBUS(int Card_ID)
        {
            var Board_ID = Card_ID;
            var ret = APS168.APS_scan_field_bus(Board_ID, BusNo);// scan field bus and generate new ENI file firstly
            return ret;
        }

        /// <summary>
        /// 用来一次性获取 8 个通道的输出状态值
        /// </summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="MOD_NO">模块号</param>
        /// <param name="Start_ChannelNO">开始的通道号</param>
        /// <param name="DoValue">返回值</param>
        /// <returns></returns>
        public static int SelfDefine_Get_8_Channel_Value(int Card_ID, int MOD_NO, int Start_ChannelNO, out uint DoValue)
        {
            var ret = -1;
            var Board_ID = Card_ID;//卡号
            //int BUS_No = 0;//总线编号，目前只支持 0
            var Moudle = MOD_NO;//模块编号
            var Channel = Start_ChannelNO;//开始的通道值
            var Value = 0;
            var DO_Value = 0;
            var j = 0;

            //先获取 DO 的输出状态
            for (var i = Channel; i < Channel + 8; i++)
            {
                ret = APS168.APS_get_field_bus_d_channel_output(Board_ID, BusNo, Moudle, i, ref DO_Value);
                if (ret == 0 && DO_Value == 1)
                {
                    Value += DO_Value << j;//左移一位保存
                }
                else if (ret != 0)
                {
                    DoValue = (uint)Value;
                    return ret;
                }
                j++;
            }
            DoValue = (uint)Value;

            return 0;
        }

        //使能
        public static int Servo(int Axis)
        {
            var motionIoStatus = APS168.APS_motion_io_status(Axis);
            var status = (motionIoStatus & (1 << 7)) != 0;

            var Status = Convert.ToInt32(!status);

            var ret = APS168.APS_set_servo_on(Axis, Status);

            return ret;
        }

        /// <summary>
        /// This is the lowest level function which you can directely set value to EtherCAT PDO memory and align to EtherCAT cycle time.
        /// </summary>
        /// <param name="Card_ID">ID of the target controller. It’s retrieved by successful call to APS_initial().</param>
        /// <param name="byteOffset">The offset address of specific PDO data, unit is byte.</param>
        /// <param name="size">The size value of PDO data, unit is byte.</param>
        /// <param name="value">The value set to the PDO.</param>
        /// <returns></returns>
        public static int SetFieldBusPdo(int Card_ID, ushort byteOffset, ushort size, uint value)
        {
            var ret = 0;
            var Board_ID = Card_ID;
            //int BUS_No = 0;
            var ByteOffset = byteOffset;
            var Size = size;
            var Value = value;
            ret = APS168.APS_set_field_bus_pdo(Board_ID, BusNo, ByteOffset, Size, Value);

            return ret;
        }

        /// <summary>通过SDO设置数据</summary>
        /// <param name="Card_ID">卡号</param>
        /// <param name="MOD_No">模块号</param>
        /// <param name="ODIndex"></param>
        /// <param name="ODSubIndex"></param>
        /// <param name="data">写入数据</param>
        /// <param name="dataLength"></param>
        /// <returns></returns>
        public static int SetFieldBusSdo(int Card_ID, int MOD_No, ushort ODIndex, ushort ODSubIndex, byte[] data, uint dataLength)
        {
            var ret = 0;
            var Board_ID = Card_ID;
            //int BUS_No = 0;
            var SlaveId = MOD_No;
            var Index = ODIndex;
            //ushort SubIndex = 0;
            var Data = data;
            var DataLen = dataLength;
            uint Timeout = 5000;
            uint Flags = 0;
            ret = APS168.APS_set_field_bus_sdo(Board_ID,
                                                BusNo,
                                                SlaveId,
                                                Index,
                                                ODSubIndex,
                                                Data,
                                                DataLen,
                                                Timeout,
                                                Flags);
            return ret;
        }

        /// <summary>
        /// 写SDO数据
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="slaveNo"></param>
        /// <param name="index"></param>
        /// <param name="subIndex"></param>
        /// <param name="data"></param>
        /// <param name="dataLength"></param>
        /// <returns></returns>
        public static int SetFieldBusSDOData(int cardId, int slaveNo, ushort index, ushort subIndex, int data, uint dataLength)
        {
            //int val = 0;
            var Board_ID = cardId;
            var BUS_No = 0;
            var SlaveId = slaveNo;
            var ODIndex = index;
            var ODSubIndex = subIndex;
            var DataLen = dataLength / 8;
            var Data = new byte[DataLen];
            uint Timeout = 5000;
            uint Flags = 0;

            //数据处理，函数写入的 DATA 是一个 byte[] 类型的数组，数组里面每个 byte 是 8 位，需要处理

            for (var i = 0; i < DataLen; i++) Data[i] = (byte)((data >> (i * 8)) & 0xFF);

            //110000000000101010101010101010=805481130
            var ret = APS168.APS_set_field_bus_sdo(Board_ID,
                                                   BUS_No,
                                                   SlaveId,
                                                   ODIndex,
                                                   ODSubIndex,
                                                   Data,
                                                   DataLen,
                                                   Timeout,
                                                   Flags
                                                   );

            return ret;
        }

        //设置OD数据
        public static int SetODData(int cardId, int slaveNo, int subModNo, int OdIndex, uint rawData)
        {
            return APS168.APS_set_field_bus_od_data(cardId, 0, slaveNo, subModNo, OdIndex, rawData);
        }

        /// <summary>清零</summary>
        /// <param name="Axis"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static int SetToPosition(int Axis, int Position)
        {
            var ret = APS168.APS_set_position(Axis, Position);

            return ret;
        }

        //开始连接总线
        public static int StartFieldBUS(int Card_ID, ref int start_AxisID)
        {
            var startAxisID = start_AxisID;

            var ret = APS168.APS_start_field_bus(Card_ID, BusNo, startAxisID); // start field bus communication
            if (ret < 0)
                return -1;
            Connected = true;
            return 0;
        }

        /// <summary>
        /// 回零
        /// </summary>
        /// <param name="axisId"></param>
        /// <param name="homeMode"></param>
        /// <param name="homeDir"></param>
        /// <param name="praCurve"></param>
        /// <param name="praAcc"></param>
        /// <param name="praVm"></param>
        /// <returns></returns>
        public static int StartHoming(int axisId, int homeMode, int homeDir, double praCurve, double praAcc, double praVm)
        {
            // 1. Select home mode and config home parameters
            APS168.APS_set_axis_param(axisId, (int)APS_Define.PRA_HOME_MODE, homeMode); // Set home mode
            APS168.APS_set_axis_param(axisId, (int)APS_Define.PRA_HOME_DIR, homeDir); // Set home direction
            APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_HOME_CURVE, praCurve); // Set acceleration paten (T-curve)
            APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_HOME_ACC, praAcc); // Set homing acceleration rate
            APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_HOME_VM, praVm); // Set homing maximum velocity.
            APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_HOME_VO, praVm / 5); // Set homing VO speed
            APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_HOME_EZA, 0); // Set EZ signal alignment (yes or no)
            APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_HOME_SHIFT, 0); // Set home position shfit distance.
            APS168.APS_set_axis_param_f(axisId, (int)APS_Define.PRA_HOME_POS, 0); // Set final home position.

            //servo on
            Check_Servo_ON(axisId);
            Thread.Sleep(500); // Wait stable.

            // 2. Start home move
            APS168.APS_home_move(axisId);

            int motionStatusCstp = 0, motionStatusAstp = 16;
            while ((APS168.APS_motion_status(axisId) & (1 << motionStatusCstp)) == 0) Thread.Sleep(100);
            Thread.Sleep(500);

            if ((APS168.APS_motion_status(axisId) & (1 << motionStatusAstp)) != 0) return -1;
            return 0;
        }

        //断开总线连接
        public static int StopFieldBUS(int Card_ID)
        {
            int ret;
            ret = APS168.APS_stop_field_bus(Card_ID, BusNo);//Stop Field BUS  communction
            Connected = false;
            return ret;
        }

        /// <summary>
        /// 停止运动
        /// </summary>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public static int StopMove(int Axis)
        {
            var ret = APS168.APS_stop_move(Axis);
            return ret;
        }

        /// <summary>
        /// 速度运动
        /// </summary>
        /// <param name="Axis_ID">轴号</param>
        /// <param name="Speed">速度</param>
        /// <param name="Option">正方向或者负方向</param>
        /// <param name="Acc">加速度</param>
        /// <param name="Dec">减速度</param>
        /// <param name="Curve">速度曲线</param>
        public static void Velocity_move(int Axis_ID, double Speed, int Option, double Acc, double Dec, double Curve)
        {
            var axis_id = Axis_ID;
            var option = Option;    // 0 is Positive direction,1 is negative direction

            var dec = Dec;
            var acc = Acc;
            var curve = Curve;

            var p = new ASYNCALL();
            var speed = Speed;

            APS168.APS_set_axis_param_f(axis_id, (int)APS_Define.PRA_STP_DEC, dec);
            APS168.APS_set_axis_param_f(axis_id, (int)APS_Define.PRA_CURVE, curve); //Set acceleration rate
            APS168.APS_set_axis_param_f(axis_id, (int)APS_Define.PRA_ACC, acc); //Set acceleration rate
            APS168.APS_set_axis_param_f(axis_id, (int)APS_Define.PRA_DEC, dec); //Set deceleration rate

            //servo on
            Servo(axis_id);
            Thread.Sleep(500); // Wait stable.

            //go
            APS168.APS_vel(axis_id, Option, speed, ref p);
        }

        //*************************************************************************************
        //***************************************中断******************************************
        //*************************************************************************************
        /// <summary>Interrupt 中断</summary>
        /// <param name="Card_ID">Card number</param>
        /// <param name="Item_NO">interrupt axis ID or DI channel</param>
        /// <param name="Factor_NO">Interrupt factor</param>
        /// <returns></returns>
        public int Interrupt_example(int Card_ID, int Item_NO, int Factor_NO)
        {
            // This example shows how interrupt functions work.
            var board_id = Card_ID;
            int int_no;      // Interrupt number
            int return_code; // function return code
            var item = Item_NO;    // Axis #? interrupt
            var factor = Factor_NO; // factor number = 12 IMDN interrupt     /*Look at interrupt factor table*/

            // Step 1: set interrupt factor
            // 設定要等待的中斷事件
            int_no = APS168.APS_set_int_factor(board_id, item, factor, 1);

            // Step 2: set interrupt main switch
            // 設定中斷總開關
            APS168.APS_int_enable(board_id, 1); // Enable the interrupt main switch

            // Step 3: wait interrupt.
            // 等待中斷觸發
            return_code = APS168.APS_wait_single_int(int_no, -1); //Wait interrupt

            if (return_code == 0)
                //Interrupt occurred
                //Step 4: 重置中斷為為觸發狀態
                APS168.APS_reset_int(int_no);

            // Step 5: Disable interrupt at the end of program.
            // 關閉中斷事件和中斷總開關
            APS168.APS_set_int_factor(board_id, item, factor, 0);
            APS168.APS_int_enable(board_id, 0);

            return return_code;
        }

        //internal static int _startAxisID = 0;

        #region

        //连续运动用变量

        #endregion

        //************************************************************************
        //*******************************插补运动**********************************
        //************************************************************************

        //---------------------------------------------------------------------------
        //-------------------------------直线插补-------------------------------------
        //---------------------------------------------------------------------------

        #region

        #endregion

        //---------------------------------------------------------------------------
        //------------------------------圆弧插补--------------------------------------
        //---------------------------------------------------------------------------

        #region

        #endregion

        //3D 圆弧插补   //未测试

        #region

        #endregion

        //*************************************************************************************
        //********************************点表连续运动*****************************************
        //*************************************************************************************
        //尚未测试、、、、、

        #region

        #endregion
    }
}