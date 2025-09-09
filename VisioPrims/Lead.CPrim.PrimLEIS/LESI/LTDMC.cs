using System;
using System.Runtime.InteropServices;

namespace csLTDMC //命名空间根据应用程序修改
{
    public class LTDMC
    {
        //---------------------   板卡初始和配置函数  ----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_init", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_init();

        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_reset", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_reset();

        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_close", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_close();

        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_init_onecard", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_init_onecard(ushort CardNo);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_close_onecard", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_close_onecard(ushort CardNo);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_reset_onecard", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_reset_onecard(ushort CardNo);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_soft_reset(ushort CardNo);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_cool_reset(ushort CardNo);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_original_reset", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_original_reset(ushort CardNo);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_CardInfList", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_CardInfList(ref ushort CardNum, uint[] CardTypeList, ushort[] CardIdList);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_version", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_version(ushort CardNo, ref uint CardVersion);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_soft_version", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_soft_version(ushort CardNo, ref uint FirmID, ref uint SubFirmID);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_lib_version", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_lib_version(ref uint LibVer);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_release_version", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_release_version(ushort ConnectNo, byte[] ReleaseVersion); //读取发布版本号

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_axes", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_axes(ushort CardNo, ref uint TotalAxis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_ionum", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_ionum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_adcnum", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_adcnum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_liners", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_liners(ushort CardNo, ref uint TotalLiner);

        // 轴IO映射配置
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_AxisIoMap", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_AxisIoMap(ushort CardNo, ushort Axis, ushort IoType, ushort MapIoType,
            ushort MapIoIndex, uint Filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_AxisIoMap", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_AxisIoMap(ushort CardNo, ushort Axis, ushort IoType, ref ushort MapIoType,
            ref ushort MapIoIndex, ref uint Filter);

        //以上函数以毫秒为单位可继续使用，新函数将时间统一到秒为单位
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_axis_io_map", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_axis_io_map(ushort CardNo, ushort Axis, ushort IoType, ushort MapIoType,
            ushort MapIoIndex, double Filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_axis_io_map", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_axis_io_map(ushort CardNo, ushort Axis, ushort IoType, ref ushort MapIoType,
            ref ushort MapIoIndex, ref double Filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_special_input_filter", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_special_input_filter(ushort CardNo, double Filter); //设置所有专用IO滤波时间

        // 虚拟IO映射  用于读取滤波后的IO口电平状态
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_map_virtual", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_map_virtual(ushort CardNo, ushort bitno, ushort MapIoType,
            ushort MapIoIndex, double Filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_map_virtual", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_map_virtual(ushort CardNo, ushort bitno, ref ushort MapIoType,
            ref ushort MapIoIndex, ref double Filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inbit_virtual", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_inbit_virtual(ushort CardNo, ushort bitno);

        //下载参数文件
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_configfile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_configfile(ushort CardNo, string FileName);

        //下载固件文件
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_firmware", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_firmware(ushort CardNo, string FileName);

        //----------------------限位异常设置-------------------------------	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_softlimit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_softlimit(ushort CardNo, ushort axis, ushort enable, ushort source_sel,
            ushort SL_action, int N_limit, int P_limit);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_softlimit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_softlimit(ushort CardNo, ushort axis, ref ushort enable,
            ref ushort source_sel, ref ushort SL_action, ref int N_limit, ref int P_limit);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_el_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_el_mode(ushort CardNo, ushort axis, ushort el_enable, ushort el_logic,
            ushort el_mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_el_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_el_mode(ushort CardNo, ushort axis, ref ushort el_enable,
            ref ushort el_logic, ref ushort el_mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_emg_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_emg_mode(ushort CardNo, ushort axis, ushort enable, ushort emg_logic);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_emg_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_get_emg_mode(ushort CardNo, ushort axis, ref ushort enbale, ref ushort emg_logic);

        //外部减速停止信号及减速停止时间设置
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dstp_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_set_dstp_mode(ushort CardNo, ushort axis, ushort enable, ushort logic, uint time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dstp_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dstp_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort logic,
            ref uint time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dstp_time", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_dstp_time(ushort CardNo, ushort axis, uint time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dstp_time", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dstp_time(ushort CardNo, ushort axis, ref uint time);

        //以上函数以毫秒为单位可继续使用，新函数将时间统一到秒为单位
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_dstp_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_dstp_mode(ushort CardNo, ushort axis, ushort enable, ushort logic);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_dstp_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_get_io_dstp_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort logic);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dec_stop_time", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_dec_stop_time(ushort CardNo, ushort axis, double stop_time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dec_stop_time", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dec_stop_time(ushort CardNo, ushort axis, ref double stop_time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_dec_stop_time(ushort CardNo, ushort Crd, double stop_time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_dec_stop_time(ushort CardNo, ushort Crd, ref double stop_time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_dec_stop_dist(ushort CardNo, ushort axis, int dist);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_dec_stop_dist(ushort CardNo, ushort axis, ref int dist);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_dstp_bitno(ushort CardNo, ushort axis, ushort bitno, double filter);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_dstp_bitno(ushort CardNo, ushort axis, ref ushort bitno,
            ref double filter);

        //---------------------------速度设置----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile(ushort CardNo, ushort axis, double Min_Vel, double Max_Vel,
            double Tacc, double Tdec, double stop_vel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile(ushort CardNo, ushort axis, ref double Min_Vel, ref double Max_Vel,
            ref double Tacc, ref double Tdec, ref double stop_vel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_acc_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_acc_profile(ushort CardNo, ushort axis, double Min_Vel, double Max_Vel,
            double Tacc, double Tdec, double stop_vel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_acc_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_acc_profile(ushort CardNo, ushort axis, ref double Min_Vel,
            ref double Max_Vel, ref double Tacc, ref double Tdec, ref double stop_vel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_s_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_s_profile(ushort CardNo, ushort axis, ushort s_mode, double s_para);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_s_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_s_profile(ushort CardNo, ushort axis, ushort s_mode, ref double s_para);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_profile_multicoor", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_profile_multicoor(ushort CardNo, ushort Crd, double Min_Vel,
            double Max_Vel, double Tacc, double Tdec, double Stop_Vel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_profile_multicoor", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_vector_profile_multicoor(ushort CardNo, ushort Crd, ref double Min_Vel,
            ref double Max_Vel, ref double Taccdec, ref double Tdec, ref double Stop_Vel);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_s_profile_multicoor(ushort CardNo, ushort Crd, ushort s_mode,
            double s_para);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_s_profile_multicoor(ushort CardNo, ushort Crd, ushort s_mode,
            ref double s_para);

        //---------------------运动模块脉冲模式------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pulse_outmode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pulse_outmode(ushort CardNo, ushort axis, ushort outmode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pulse_outmode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pulse_outmode(ushort CardNo, ushort axis, ref ushort outmode);

        //-----------------------点位运动-----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_pmove", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_pmove(ushort CardNo, ushort axis, int Dist, ushort posi_mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_extern(ushort CardNo, ushort axis, double dist, double Min_Vel,
            double Max_Vel, double Tacc, double Tdec, double stop_Vel, double s_para, ushort posi_mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_target_position", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_target_position(ushort CardNo, ushort axis, int dist, ushort posi_mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_change_speed", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_change_speed(ushort CardNo, ushort axis, double Curr_Vel, double Taccdec);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_update_target_position", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_update_target_position(ushort CardNo, ushort axis, int dist, ushort posi_mode);

        //----------------------PVT运动---------------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtTable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtTable(ushort CardNo, ushort iaxis, uint count, double[] pTime, int[] pPos,
            double[] pVel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_PtsTable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PtsTable(ushort CardNo, ushort iaxis, uint count, double[] pTime, int[] pPos,
            double[] pPercent);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtsTable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtsTable(ushort CardNo, ushort iaxis, uint count, double[] pTime, int[] pPos,
            double velBegin, double velEnd);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_PttTable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PttTable(ushort CardNo, ushort iaxis, uint count, double[] pTime, int[] pPos);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtMove", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtMove(ushort CardNo, ushort AxisNum, ushort[] AxisList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_PttTable_add(ushort CardNo, ushort iaxis, ushort count, double[] pTime,
            long[] pPos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_PtsTable_add(ushort CardNo, ushort iaxis, ushort count, double[] pTime,
            long[] pPos, double[] pPercent);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_get_remain_space(ushort CardNo, ushort iaxis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_table_unit(ushort CardNo, ushort iaxis, uint count, double[] pTime,
            double[] pPos, double[] pVel);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_pts_table_unit(ushort CardNo, ushort iaxis, uint count, double[] pTime,
            double[] pPos, double[] pPercent);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvts_table_unit(ushort CardNo, ushort iaxis, uint count, double[] pTime,
            double[] pPos, double velBegin, double velEnd);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_ptt_table_unit(ushort CardNo, ushort iaxis, uint count, double[] pTime,
            double[] pPos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_move(ushort CardNo, ushort AxisNum, ushort[] AxisList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_SetGearProfile(ushort CardNo, ushort axis, ushort MasterType, ushort MasterIndex,
            int MasterEven, int SlaveEven, uint MasterSlope);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_GetGearProfile(ushort CardNo, ushort axis, ref ushort MasterType,
            ref ushort MasterIndex, ref uint MasterEven, ref uint SlaveEven, ref uint MasterSlope);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_GearMove(ushort CardNo, ushort AxisNum, ushort[] AxisList);

        //---------------------JOG运动--------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_vmove", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_vmove(ushort CardNo, ushort axis, ushort dir);

        //直线插补		
        [DllImport("LTDMC.dll", EntryPoint = "dmc_line_multicoor", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_line_multicoor(ushort CardNo, ushort crd, ushort axisNum, ushort[] axisList,
            int[] DistList, ushort posi_mode);

        //平面圆弧
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_multicoor", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_multicoor(ushort CardNo, ushort crd, ushort[] AxisList,
            int[] Target_Pos, int[] Cen_Pos, ushort Arc_Dir, ushort posi_mode);

        //--------------------回零运动---------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_home_pin_logic", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_home_pin_logic(ushort CardNo, ushort axis, ushort org_logic, double filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_home_pin_logic", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_home_pin_logic(ushort CardNo, ushort axis, ref ushort org_logic,
            ref double filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_homemode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_homemode(ushort CardNo, ushort axis, ushort home_dir, double vel,
            ushort mode, ushort EZ_count);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homemode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homemode(ushort CardNo, ushort axis, ref ushort home_dir, ref double vel,
            ref ushort home_mode, ref ushort EZ_count);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_home_move", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_home_move(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_profile_unit(ushort CardNo, ushort axis, double Low_Vel,
            double High_Vel, double Tacc, double Tdec);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_profile_unit(ushort CardNo, ushort axis, ref double Low_Vel,
            ref double High_Vel, ref double Tacc, ref double Tdec);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_result(ushort CardNo, ushort axis, ref ushort state);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_position_unit(ushort CardNo, ushort axis, ushort enable,
            double position);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_position_unit(ushort CardNo, ushort axis, ref ushort enable,
            ref double position);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_el_home(ushort CardNo, ushort axis, ushort mode);

        // 回原点减速信号配置
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_sd_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_sd_mode(ushort CardNo, ushort axis, ushort sd_logic, ushort sd_mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_sd_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_sd_mode(ushort CardNo, ushort axis, ref ushort sd_logic, ref ushort sd_mode);

        //--------------------3800,3600,5800,5600专用 原点锁存-------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_homelatch_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_homelatch_mode(ushort CardNo, ushort axis, ushort enable, ushort logic,
            ushort source);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homelatch_mode(ushort CardNo, ushort axis, ref ushort enable,
            ref ushort logic, ref ushort source);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_flag", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homelatch_flag(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_homelatch_flag", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_homelatch_flag(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_value", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int dmc_get_homelatch_value(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_ezlatch_mode(ushort CardNo, ushort axis, ushort enable, ushort logic,
            ushort source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort logic,
            ref ushort source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_flag(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_ezlatch_flag(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_value(ushort CardNo, ushort axis);

        //--------------------手轮运动---------------------	
        //3800,3600,5800,5600专用 手轮通道选择
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_channel", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_channel(ushort CardNo, ushort index);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_channel", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_channel(ushort CardNo, ref ushort index);

        //一个手轮信号控制单个轴运动	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode(ushort CardNo, ushort axis, ushort inmode, int multi,
            double vh);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode(ushort CardNo, ushort axis, ref ushort inmode,
            ref int multi, ref double vh);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode_decimals", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode_decimals(ushort CardNo, ushort axis, ushort inmode,
            double multi, double vh);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode_decimals", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode_decimals(ushort CardNo, ushort axis, ref ushort inmode,
            ref double multi, ref double vh);

        //3800,3600,5800,5600专用 一个手轮信号控制多个轴运动
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode_extern(ushort CardNo, ushort inmode, ushort AxisNum,
            ushort[] AxisList, int[] multi);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode_extern(ushort CardNo, ref ushort inmode, ref ushort AxisNum,
            ushort[] AxisList, int[] multi);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_inmode_extern_decimals(ushort CardNo, ushort inmode,
            ushort AxisNum, ushort[] AxisList, double[] multi);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_inmode_extern_decimals(ushort CardNo, ref ushort inmode,
            ref ushort AxisNum, ushort[] AxisList, double[] multi);

        //启动手轮运动
        [DllImport("LTDMC.dll", EntryPoint = "dmc_handwheel_move", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_handwheel_move(ushort CardNo, ushort axis);

        //
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_encoder(ushort CardNo, ushort channel, int pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_encoder(ushort CardNo, ushort channel, ref int pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_axislist(ushort CardNo, ushort AxisSelIndex, ushort AxisNum,
            ushort[] AxisList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_axislist(ushort CardNo, ushort AxisSelIndex, ref ushort AxisNum,
            ushort[] AxisList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_ratiolist(ushort CardNo, ushort AxisSelIndex,
            ushort StartRatioIndex, ushort RatioSelNum, double[] RatioList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_ratiolist(ushort CardNo, ushort AxisSelIndex,
            ushort StartRatioIndex, ushort RatioSelNum, double[] RatioList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_mode(ushort CardNo, ushort InMode, ushort IfHardEnable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_mode(ushort CardNo, ref ushort InMode, ref ushort IfHardEnable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_index(ushort CardNo, ushort AxisSelIndex, ushort RatioSelIndex);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_index(ushort CardNo, ref ushort AxisSelIndex,
            ref ushort RatioSelIndex);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_stop(ushort CardNo);

        //---------------------编码器---------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_counter_inmode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_counter_inmode(ushort CardNo, ushort axis, ushort mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_counter_inmode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_counter_inmode(ushort CardNo, ushort axis, ref ushort mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int dmc_get_encoder(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder(ushort CardNo, ushort axis, int encoder_value);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_ez_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_ez_mode(ushort CardNo, ushort axis, ushort ez_logic, ushort ez_mode,
            double filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_ez_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_ez_mode(ushort CardNo, ushort axis, ref ushort ez_logic, ref ushort ez_mode,
            ref double filter);

        //---------------------辅助编码器---------------------
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_extra_encoder_mode(ushort CardNo, ushort channel, ushort inmode,
            ushort multi);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_extra_encoder_mode(ushort CardNo, ushort channel, ref ushort inmode,
            ref ushort multi);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_extra_encoder(ushort CardNo, ushort channel, int pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_extra_encoder(ushort CardNo, ushort channel, ref int pos);

        //-------------------------高速锁存(旧)-------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_ltc_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_ltc_mode(ushort CardNo, ushort axis, ushort ltc_logic, ushort ltc_mode,
            double filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_ltc_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_ltc_mode(ushort CardNo, ushort axis, ref ushort ltc_logic,
            ref ushort ltc_mode, ref double filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_latch_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_latch_mode(ushort CardNo, ushort axis, ushort all_enable,
            ushort latch_source, ushort triger_chunnel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_mode(ushort CardNo, ushort axis, ref ushort all_enable,
            ref ushort latch_source, ref ushort triger_chunnel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_value", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int dmc_get_latch_value(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_value_unit(ushort CardNo, ushort axis, ref double pos_by_mm);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_flag", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_flag(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_latch_flag", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_latch_flag(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_value_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int dmc_get_latch_value_extern(ushort CardNo, ushort axis, ushort Index);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_flag_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_flag_extern(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_SetLtcOutMode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_SetLtcOutMode(ushort CardNo, ushort axis, ushort enable, ushort bitno);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_GetLtcOutMode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_GetLtcOutMode(ushort CardNo, ushort axis, ref ushort enable, ref ushort bitno);

        //LTC端口触发延时急停时间 单位us
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_latch_stop_time", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_latch_stop_time(ushort CardNo, ushort axis, int time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_stop_time", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_stop_time(ushort CardNo, ushort axis, ref int time);

        //----------------------高速锁存(新)---------------------------
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_set_mode(ushort CardNo, ushort latch, ushort ltc_mode, ushort ltc_logic,
            double filter);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_mode(ushort CardNo, ushort latch, ref ushort ltc_mode,
            ref ushort ltc_logic, ref double filter);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_set_source(ushort CardNo, ushort latch, ushort axis, ushort ltc_source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_source(ushort CardNo, ushort latch, ushort axis, ref ushort ltc_source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_reset(ushort CardNo, ushort latch);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_number(ushort CardNo, ushort latch, ushort axis, ref int number);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_value_unit(ushort CardNo, ushort latch, ushort axis, ref double value);

        //-----------------------软锁存---------------------------------
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_set_mode(ushort ConnectNo, ushort latch, ushort ltc_enable,
            ushort ltc_mode, ushort ltc_inbit, ushort ltc_logic, double filter);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_mode(ushort ConnectNo, ushort latch, ref ushort ltc_enable,
            ref ushort ltc_mode, ref ushort ltc_inbit, ref ushort ltc_logic, ref double filter);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_set_source(ushort ConnectNo, ushort latch, ushort axis,
            ushort ltc_source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_source(ushort ConnectNo, ushort latch, ushort axis,
            ref ushort ltc_source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_reset(ushort ConnectNo, ushort latch);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_number(ushort ConnectNo, ushort latch, ushort axis, ref int number);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_value_unit(ushort ConnectNo, ushort latch, ushort axis,
            ref double value);

        //----------------------单轴低速位置比较-----------------------	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_set_config", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_set_config(ushort CardNo, ushort axis, ushort enable, ushort cmp_source);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_config", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_config(ushort CardNo, ushort axis, ref ushort enable,
            ref ushort cmp_source);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_clear_points", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_clear_points(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_add_point", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_add_point(ushort CardNo, ushort axis, int pos, ushort dir, ushort action,
            uint actpara);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_current_point", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_current_point(ushort CardNo, ushort axis, ref int pos);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_runned", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_runned(ushort CardNo, ushort axis, ref int pointNum);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_remained", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_remained(ushort CardNo, ushort axis, ref int pointNum);

        //-------------------二维低速位置比较-----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_set_config_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_set_config_extern(ushort CardNo, ushort enable, ushort cmp_source);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_config_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_config_extern(ushort CardNo, ref ushort enable,
            ref ushort cmp_source);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_clear_points_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_clear_points_extern(ushort CardNo);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_add_point_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_add_point_extern(ushort CardNo, ushort[] axis, int[] pos, ushort[] dir,
            ushort action, uint actpara);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_current_point_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_current_point_extern(ushort CardNo, int[] pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_extern_unit(ushort CardNo, ushort[] axis, double[] pos,
            ushort[] dir, ushort action, uint actpara);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_current_point_extern_unit(ushort CardNo, double[] pos);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_runned_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_runned_extern(ushort CardNo, ref int pointNum);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_remained_extern", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_remained_extern(ushort CardNo, ref int pointNum);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_set_config_multi(ushort CardNo, ushort queue, ushort enable, ushort axis,
            ushort cmp_source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_config_multi(ushort CardNo, ushort queue, ref ushort enable,
            ref ushort axis, ref ushort cmp_source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_multi(ushort CardNo, ushort cmp, int pos, ushort dir,
            ushort action, uint actpara, double times);

        //----------- 单轴高速位置比较-----------------------        
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_mode(ushort CardNo, ushort hcmp, ushort cmp_enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_mode(ushort CardNo, ushort hcmp, ref ushort cmp_enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_config", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_config(ushort CardNo, ushort hcmp, ushort axis, ushort cmp_source,
            ushort cmp_logic, int time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_config", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_config(ushort CardNo, ushort hcmp, ref ushort axis,
            ref ushort cmp_source, ref ushort cmp_logic, ref int time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_config_extern(ushort CardNo, ushort hcmp, ushort axis,
            ushort cmp_source, ushort cmp_logic, ushort cmp_mode, int dist, int time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_config_extern(ushort CardNo, ushort hcmp, ref ushort axis,
            ref ushort cmp_source, ref ushort cmp_logic, ref ushort cmp_mode, ref int dist, ref int time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_add_point", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_add_point(ushort CardNo, ushort hcmp, int cmp_pos);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_liner", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_liner(ushort CardNo, ushort hcmp, int Increment, int Count);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_liner", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_liner(ushort CardNo, ushort hcmp, ref int Increment, ref int Count);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_current_state", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_current_state(ushort CardNo, ushort hcmp, ref int remained_points,
            ref int current_point, ref int runned_points);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_clear_points", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_clear_points(ushort CardNo, ushort hcmp);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_cmp_pin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_cmp_pin(ushort CardNo, ushort hcmp);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_cmp_pin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_cmp_pin(ushort CardNo, ushort hcmp, ushort on_off);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_enable(ushort CardNo, ushort hcmp, ushort cmp_enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_enable(ushort CardNo, ushort hcmp, ref ushort cmp_enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_config(ushort CardNo, ushort hcmp, ushort cmp_mode, ushort x_axis,
            ushort x_cmp_source, ushort y_axis, ushort y_cmp_source, int error, ushort cmp_logic, int time,
            ushort pwm_enable, double duty, int freq, ushort port_sel, ushort pwm_number);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_config(ushort CardNo, ushort hcmp, ref ushort cmp_mode,
            ref ushort x_axis, ref ushort x_cmp_source, ref ushort y_axis, ref ushort y_cmp_source, ref int error,
            ref ushort cmp_logic, ref int time, ref ushort pwm_enable, ref double duty, ref int freq,
            ref ushort port_sel, ref ushort pwm_number);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_add_point(ushort CardNo, ushort hcmp, int x_cmp_pos, int y_cmp_pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_current_state(ushort CardNo, ushort hcmp, ref int remained_points,
            ref int x_current_point, ref int y_current_point, ref int runned_points, ref ushort current_state);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_clear_points(ushort CardNo, ushort hcmp);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_force_output(ushort CardNo, ushort hcmp, ushort enable);

        //------------------------通用IO-----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inbit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_inbit(ushort CardNo, ushort bitno);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outbit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outbit(ushort CardNo, ushort bitno, ushort on_off);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_outbit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_outbit(ushort CardNo, ushort bitno);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inport", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern uint dmc_read_inport(ushort CardNo, ushort portno);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_outport", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern uint dmc_read_outport(ushort CardNo, ushort portno);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outport", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outport(ushort CardNo, ushort portno, uint outport_val);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outport_16X", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outport_16X(ushort CardNo, ushort portno, uint outport_val);

        //3800,3600,5800,5600专用 IO辅助功能
        [DllImport("LTDMC.dll", EntryPoint = "dmc_IO_TurnOutDelay", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_IO_TurnOutDelay(ushort CardNo, ushort bitno, uint DelayTime);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_SetIoCountMode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_SetIoCountMode(ushort CardNo, ushort bitno, ushort mode, uint filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_GetIoCountMode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_GetIoCountMode(ushort CardNo, ushort bitno, ref ushort mode, ref uint filter);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_SetIoCountValue", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_SetIoCountValue(ushort CardNo, ushort bitno, uint CountValue);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_GetIoCountValue", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_GetIoCountValue(ushort CardNo, ushort bitno, ref uint CountValue);

        //以上函数以毫秒为单位可继续使用，新函数将时间统一到秒为单位
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reverse_outbit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reverse_outbit(ushort CardNo, ushort bitno, double reverse_time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_count_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_count_mode(ushort CardNo, ushort bitno, ushort mode, double filter_time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_count_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_count_mode(ushort CardNo, ushort bitno, ref ushort mode,
            ref double filter_time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_count_value", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_count_value(ushort CardNo, ushort bitno, uint CountValue);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_count_value", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_count_value(ushort CardNo, ushort bitno, ref uint CountValue);

        //-----------------------专用IO-------------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_inp_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_inp_mode(ushort CardNo, ushort axis, ushort enable, ushort inp_logic);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_inp_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_get_inp_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort inp_logic);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_rdy_mode(ushort CardNo, ushort axis, ushort enable, ushort rdy_logic);

        [DllImport("LTDMC.dll")]
        public static extern short
            dmc_get_rdy_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort rdy_logic);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_erc_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_erc_mode(ushort CardNo, ushort axis, ushort enable, ushort erc_logic,
            ushort erc_width, ushort erc_off_time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_erc_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_erc_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort erc_logic,
            ref ushort erc_width, ref ushort erc_off_time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_alm_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_alm_mode(ushort CardNo, ushort axis, ushort enable, ushort alm_logic,
            ushort alm_action);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_alm_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_alm_mode(ushort CardNo, ushort axis, ref ushort enable, ref ushort alm_logic,
            ref ushort alm_action);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_sevon_pin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_sevon_pin(ushort CardNo, ushort axis, ushort on_off);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_sevon_pin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_sevon_pin(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_erc_pin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_erc_pin(ushort CardNo, ushort axis, ushort sel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_erc_pin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_erc_pin(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_rdy_pin", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_rdy_pin(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_sevrst_pin(ushort CardNo, ushort axis, ushort on_off);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_sevrst_pin(ushort CardNo, ushort axis);

        //--------------------运动状态----------------------	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_current_speed", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern double dmc_read_current_speed(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_position", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int dmc_get_position(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_position", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_position(ushort CardNo, ushort axis, int current_position);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_target_position", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int dmc_get_target_position(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_done", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_done(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_done_multicoor", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_done_multicoor(ushort CardNo, ushort crd);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_axis_io_status", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern uint dmc_axis_io_status(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_stop", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_stop(ushort CardNo, ushort axis, ushort stop_mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_stop_multicoor", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_stop_multicoor(ushort CardNo, ushort crd, ushort stop_mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_emg_stop", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_emg_stop(ushort CardNo);

        //检测轴到位状态
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_factor_error", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_factor_error(ushort CardNo, ushort axis, double factor, int error);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_factor_error", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_factor_error(ushort CardNo, ushort axis, ref double factor, ref int error);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_success_pulse", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_success_pulse(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_success_encoder", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_success_encoder(ushort CardNo, ushort axis);

        //3800,3600,5800,5600专用 主卡与接线盒通讯状态
        [DllImport("LTDMC.dll", EntryPoint = "dmc_LinkState", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_LinkState(ushort CardNo, ref ushort State);

        //3800,3600,5800,5600专用 CAN-IO扩展
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_can_state", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_can_state(ushort CardNo, ushort NodeNum, ushort state, ushort Baud);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_can_state", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_can_state(ushort CardNo, ref ushort NodeNum, ref ushort state);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_can_outbit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_can_outbit(ushort CardNo, ushort Node, ushort bitno, ushort on_off);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_outbit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_can_outbit(ushort CardNo, ushort Node, ushort bitno);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_inbit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_can_inbit(ushort CardNo, ushort Node, ushort bitno);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_can_outport", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_can_outport(ushort CardNo, ushort Node, ushort PortNo, uint outport_val);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_outport", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern uint dmc_read_can_outport(ushort CardNo, ushort Node, ushort PortNo);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_inport", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern uint dmc_read_can_inport(ushort CardNo, ushort Node, ushort PortNo);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_can_errcode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_can_errcode(ushort CardNo, ref ushort Errcode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_can_errcode_extern(ushort CardNo, ref ushort Errcode, ref ushort msg_losed,
            ref ushort emg_msg_num, ref ushort lostHeartB, ref ushort EmgMsg);

        //CAN-ADDA
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_output(ushort CardNo, ushort NoteID, ushort channel, double Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_output(ushort CardNo, ushort NoteID, ushort channel, ref double Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_input(ushort CardNo, ushort NoteID, ushort channel, ref double Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_ad_mode(ushort CardNo, ushort NoteID, ushort channel, ushort mode,
            uint buffer_nums);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_mode(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode,
            uint buffer_nums);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_mode(ushort CardNo, ushort NoteID, ushort channel, ushort mode,
            uint buffer_nums);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_mode(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode,
            uint buffer_nums);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_to_flash(ushort CardNo, ushort PortNum, ushort NodeNum);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_connect_state(ushort CardNo, ushort NodeNum, ushort state, ushort baud);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_connect_state(ushort CardNo, ref ushort NodeNum, ref ushort state);

        //密码管理
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_sn", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_sn(ushort CardNo, string new_sn);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_sn", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_sn(ushort CardNo, string check_sn);

        //函数库打印输出
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_debug_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_debug_mode(ushort mode, string FileName);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_debug_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_debug_mode(ref ushort mode, IntPtr FileName);

        //DMC5000系列专用，基于脉冲当量的高级运动，连续插补等功能
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_axis_run_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_axis_run_mode(ushort CardNo, ushort axis, ref ushort run_mode); //轴运动模式

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_trace", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_trace(ushort CardNo, ushort axis, ushort enable); //trace功能

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_trace", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_trace(ushort CardNo, ushort axis, ref ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_trace_data", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_trace_data(ushort CardNo, ushort axis, ushort data_option,
            ref int ReceiveSize, double[] time, double[] data, ref int remain_num);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_equiv", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_equiv(ushort CardNo, ushort axis, ref double equiv); //脉冲当量

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_equiv", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_equiv(ushort CardNo, ushort axis, double equiv);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_backlash_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_backlash_unit(ushort CardNo, ushort axis, double backlash); //反向间隙

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_backlash_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_backlash_unit(ushort CardNo, ushort axis, ref double backlash);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_position_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_position_unit(ushort CardNo, ushort axis, double pos); //当前指令位置

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_position_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_position_unit(ushort CardNo, ushort axis, ref double pos);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder_unit(ushort CardNo, ushort axis, double pos); //当前反馈位置

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_encoder_unit(ushort CardNo, ushort axis, ref double pos);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_pmove_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode); //定长

        [DllImport("LTDMC.dll", EntryPoint = "dmc_t_pmove_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_t_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode); //对称T型定长

        [DllImport("LTDMC.dll", EntryPoint = "dmc_ex_t_pmove_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_ex_t_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode); //非对称T型定长

        [DllImport("LTDMC.dll", EntryPoint = "dmc_s_pmove_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_s_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode); //对称S型定长

        [DllImport("LTDMC.dll", EntryPoint = "dmc_ex_s_pmove_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_ex_s_pmove_unit(ushort CardNo, ushort axis, double Dist, ushort posi_mode); //非对称S型定长

        [DllImport("LTDMC.dll", EntryPoint = "dmc_line_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_line_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList,
            double[] Target_Pos, ushort posi_mode); //单段直线

        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_center_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_center_unit(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, int Circle,
            ushort posi_mode); //圆心终点式圆弧/螺旋线/渐开线

        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_radius_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_radius_unit(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] Target_Pos, double Arc_Radius, ushort Arc_Dir, int Circle,
            ushort posi_mode); //半径终点式圆弧/螺旋线

        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_3points_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_3points_unit(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, int Circle, ushort posi_mode); //三点式圆弧/螺旋线

        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_current_speed_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_read_current_speed_unit(ushort CardNo, ushort Axis, ref double current_speed); //轴当前运行速度

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_profile_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_profile_unit(ushort CardNo, ushort Crd, double Min_Vel,
            double Max_Vel, double Tacc, double Tdec, double Stop_Vel); //单段插补速度参数

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_profile_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_vector_profile_unit(ushort CardNo, ushort Crd, ref double Min_Vel,
            ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile_unit(ushort CardNo, ushort Axis, double Min_Vel, double Max_Vel,
            double Tacc, double Tdec, double Stop_Vel); //单轴速度参数

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile_unit(ushort CardNo, ushort Axis, ref double Min_Vel,
            ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile_unit_acc", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile_unit_acc(ushort CardNo, ushort Axis, double Min_Vel, double Max_Vel,
            double Tacc, double Tdec, double Stop_Vel); //单轴速度参数

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile_unit_acc", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile_unit_acc(ushort CardNo, ushort Axis, ref double Min_Vel,
            ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_target_position_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_target_position_unit(ushort CardNo, ushort Axis, double New_Pos); //在线变位

        [DllImport("LTDMC.dll", EntryPoint = "dmc_update_target_position_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_update_target_position_unit(ushort CardNo, ushort Axis, double New_Pos); //强行变位

        [DllImport("LTDMC.dll", EntryPoint = "dmc_change_speed_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_change_speed_unit(ushort CardNo, ushort Axis, double New_Vel, double Taccdec); //在线变速

        //连续插补
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_open_list", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_conti_open_list(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList); //打开连续缓存区

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_close_list", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_close_list(ushort CardNo, ushort Crd); //关闭连续缓存区

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_reset_list(ushort CardNo, ushort Crd);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_stop_list", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_stop_list(ushort CardNo, ushort Crd, ushort stop_mode); //连续插补中停止

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_pause_list", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_pause_list(ushort CardNo, ushort Crd); //连续插补中暂停

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_start_list", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_start_list(ushort CardNo, ushort Crd); //开始连续插补

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_remain_space", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int dmc_conti_remain_space(ushort CardNo, ushort Crd); //查连续插补剩余缓存数

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_read_current_mark", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int dmc_conti_read_current_mark(ushort CardNo, ushort Crd); //读取当前连续插补段的标号

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_blend", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_blend(ushort CardNo, ushort Crd, ushort enable); //blend拐角过度模式

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_blend", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_blend(ushort CardNo, ushort Crd, ref ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_lookahead_end_vel_zero", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_lookahead_end_vel_zero(ushort CardNo, ushort Crd, ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_profile_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_profile_unit(ushort CardNo, ushort Crd, double Min_Vel, double Max_vel,
            double Tacc, double Tdec, double Stop_Vel); //设置连续插补速度

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_s_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_conti_set_s_profile(ushort CardNo, ushort Crd, ushort s_mode, double s_para); //设置连续插补平滑时间

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_s_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_s_profile(ushort CardNo, ushort Crd, ushort s_mode, ref double s_para);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pause_output", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pause_output(ushort CardNo, ushort Crd, ushort action, int mask,
            int state); //暂停时IO输出 action 0, 不工作；1， 暂停时输出io_state; 2 暂停时输出io_state, 继续运行时首先恢复原来的io; 3,在2的基础上，停止时也生效。

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_pause_output", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_pause_output(ushort CardNo, ushort Crd, ref ushort action,
            ref int mask, ref int state);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_override", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_override(ushort CardNo, ushort Crd, double Percent); //设置每段速度比例  缓冲区指令

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_change_speed_ratio", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_change_speed_ratio(ushort CardNo, ushort Crd, double Percent); //连续插补动态变速

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_run_state", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_conti_get_run_state(ushort CardNo, ushort Crd); //读取连续插补状态：0-运行，1-暂停，2-正常停止，3-异常停止

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_check_done", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_check_done(ushort CardNo, ushort Crd); //检测连续插补运动状态：0-运行，1-停止

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_wait_input", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_wait_input(ushort CardNo, ushort Crd, ushort bitno, ushort on_off,
            double TimeOut, int mark); //设置连续插补等待输入

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_outbit_to_start", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_outbit_to_start(ushort CardNo, ushort Crd, ushort bitno,
            ushort on_off, double delay_value, ushort delay_mode, double ReverseTime); //相对于轨迹段起点IO滞后输出

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_outbit_to_stop", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_outbit_to_stop(ushort CardNo, ushort Crd, ushort bitno,
            ushort on_off, double delay_time, double ReverseTime); //相对于轨迹段终点IO滞后输出

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_ahead_outbit_to_stop", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_ahead_outbit_to_stop(ushort CardNo, ushort Crd, ushort bitno,
            ushort on_off, double ahead_value, ushort ahead_mode, double ReverseTime); //相对轨迹段终点IO提前输出

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_accurate_outbit_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_accurate_outbit_unit(ushort CardNo, ushort Crd, ushort cmp_no,
            ushort on_off, ushort map_axis, double abs_pos, ushort pos_source, double ReverseTime); //确定位置精确输出

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_write_outbit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_write_outbit(ushort CardNo, ushort Crd, ushort bitno, ushort on_off,
            double ReverseTime); //缓冲区立即IO输出

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay(ushort CardNo, ushort Crd, double delay_time, int mark); //添加延时指令

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_reverse_outbit(ushort CardNo, ushort Crd, ushort bitno,
            double reverse_time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_outbit(ushort CardNo, ushort Crd, ushort bitno, ushort on_off,
            double delay_time);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_pmove_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_pmove_unit(ushort CardNo, ushort Crd, ushort Axis, double dist,
            ushort posi_mode, ushort mode, int mark); //连续插补中控制指定外轴运动

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_line_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_line_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList,
            double[] Target_Pos, ushort posi_mode, int mark); //连续插补直线

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_center_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_center_unit(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, int Circle, ushort posi_mode,
            int mark); //圆心终点式圆弧/螺旋线/渐开线

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_radius_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_radius_unit(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] Target_Pos, double Arc_Radius, ushort Arc_Dir, int Circle, ushort posi_mode,
            int mark); //半径终点式圆弧/螺旋线

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_3points_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_3points_unit(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, int Circle, ushort posi_mode,
            int mark); //三点式圆弧/螺旋线

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_clear_io_action", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_clear_io_action(ushort CardNo, ushort Crd, uint IoMask); //清除段内未执行完的IO动作

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_stop_reason", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_stop_reason(ushort CardNo, ushort axis, ref int StopReason); //读取轴停止原因

        [DllImport("LTDMC.dll", EntryPoint = "dmc_clear_stop_reason", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_clear_stop_reason(ushort CardNo, ushort axis); //清除轴停止原因

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_involute_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_involute_mode(ushort CardNo, ushort Crd, ushort mode); //设置螺旋线是否封闭

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_involute_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_conti_get_involute_mode(ushort CardNo, ushort Crd, ref ushort mode); //读取螺旋线是否封闭设置

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_rectangle_move_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_rectangle_move_unit(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] TargetPos, double[] MaskPos, int Count, ushort rect_mode, ushort posi_mode,
            int mark); //矩形区域插补，连续插补指令

        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_center", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_center(double[] start_pos, double[] target_pos,
            double[] cen_pos, ushort arc_dir, double circle, ref double ArcLength); //计算圆心圆弧弧长

        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_3point", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_3point(double[] start_pos, double[] mid_pos,
            double[] target_pos, double circle, ref double ArcLength); //计算三点圆弧弧长

        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_radius", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_radius(double[] start_pos, double[] target_pos,
            double arc_radius, ushort arc_dir, double circle, ref double ArcLength); //计算半径圆弧弧长

        [DllImport("LTDMC.dll", EntryPoint = "dmc_rectangle_move_unit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_rectangle_move_unit(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList,
            double[] TargetPos, double[] MaskPos, int Count, ushort rect_mode, ushort posi_mode); //矩形区域插补，单段插补指令

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_gear_follow_profile(ushort CardNo, ushort axis, ushort enable,
            ushort master_axis, double ratio); //双Z轴

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gear_follow_profile(ushort CardNo, ushort axis, ref ushort enable,
            ref ushort master_axis, ref double ratio);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit_extern(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort posi_mode, int mark);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_center_unit_extern(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, double Arc_Radius, ushort posi_mode, int mark);

        //DA输出

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_da_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_da_enable(ushort CardNo, ushort enable); //开启DA输出       

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_da_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_da_enable(ushort CardNo, ref ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_da_output", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_da_output(ushort CardNo, ushort channel, double Vout); //设置DA输出      

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_da_output", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_da_output(ushort CardNo, ushort channel, ref double Vout);

        //DA跟随
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_da_output(ushort CardNo, ushort Crd, ushort channel, double Vout);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_da_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_da_enable(ushort CardNo, ushort Crd, ushort enable, ushort channel,
            int mark);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder_da_follow_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder_da_follow_enable(ushort CardNo, ushort axis, ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder_da_follow_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_encoder_da_follow_enable(ushort CardNo, ushort axis, ref ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_da_follow_speed", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_da_follow_speed(ushort CardNo, ushort Crd, ushort da_no, double MaxVel,
            double MaxValue, double acc_offset, double dec_offset, double acc_dist, double dec_dist);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_da_follow_speed", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_da_follow_speed(ushort CardNo, ushort Crd, ushort da_no,
            ref double MaxVel, ref double MaxValue, ref double acc_offset, ref double dec_offset, ref double acc_dist,
            ref double dec_dist);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_encoder_da_follow_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_encoder_da_follow_enable(ushort CardNo, ushort Crd, ushort axis,
            ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_encoder_da_follow_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_encoder_da_follow_enable(ushort CardNo, ushort Crd, ushort axis,
            ref ushort enable);

        //AD输入
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ad_input(ushort CardNo, ushort channel, ref double Vout);

        //设置插补运动速度曲线的平滑时间
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_s_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_s_profile(ushort CardNo, ushort Crd, ushort s_mode, double s_para);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_s_profile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short
            dmc_get_vector_s_profile(ushort CardNo, ushort Crd, ushort s_mode, ref double s_para);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_lookahead_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_lookahead_mode(ushort CardNo, ushort Crd, ushort enable,
            int LookaheadSegments, double PathError, double LookaheadAcc);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_lookahead_mode", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_lookahead_mode(ushort CardNo, ushort Crd, ref ushort enable,
            ref int LookaheadSegments, ref double PathError, ref double LookaheadAcc);

        //PWM输出
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_pin(ushort CardNo, ushort portno, ushort ON_OFF, double dfreqency,
            double dduty);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_pin(ushort CardNo, ushort portno, ref ushort ON_OFF,
            ref double dfreqency, ref double dduty);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_enable(ushort CardNo, ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_enable", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_enable(ushort CardNo, ref ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_output", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_output(ushort CardNo, ushort pwm_no, double fDuty, double fFre);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_output", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_output(ushort CardNo, ushort pwm_no, ref double fDuty, ref double fFre);

        //连续插补PWM输出
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_onoff_duty", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_onoff_duty(ushort CardNo, ushort PwmNo, double fOnDuty, double fOffDuty);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_onoff_duty", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_onoff_duty(ushort CardNo, ushort PwmNo, ref double fOnDuty,
            ref double fOffDuty);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pwm_output", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pwm_output(ushort CardNo, ushort Crd, ushort pwm_no, double fDuty,
            double fFre);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_enable_extern(ushort CardNo, ushort channel, ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_enable_extern(ushort CardNo, ushort channel, ref ushort enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pwm_follow_speed", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pwm_follow_speed(ushort CardNo, ushort Crd, ushort pwm_no, ushort mode,
            double MaxVel, double MaxValue, double OutValue);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_pwm_follow_speed", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_pwm_follow_speed(ushort CardNo, ushort Crd, ushort pwm_no,
            ref ushort mode, ref double MaxVel, ref double MaxValue, ref double OutValue);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_pwm_to_start", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_pwm_to_start(ushort CardNo, ushort Crd, ushort pwmno, ushort on_off,
            double delay_value, ushort delay_mode, double ReverseTime);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_ahead_pwm_to_stop", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_ahead_pwm_to_stop(ushort CardNo, ushort Crd, ushort pwmno, ushort on_off,
            double ahead_value, ushort ahead_mode, double ReverseTime);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_write_pwm", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_write_pwm(ushort CardNo, ushort Crd, ushort pwmno, ushort on_off,
            double ReverseTime);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_arc_limit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_arc_limit(ushort CardNo, ushort Crd, ushort Enable, double MaxCenAcc,
            double MaxArcError);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_arc_limit", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_arc_limit(ushort CardNo, ushort Crd, ref ushort Enable, ref double MaxCenAcc,
            ref double MaxArcError);

        //trace
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_start(ushort CardNo, ushort AxisNum, ushort[] AxisList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_stop(ushort CardNo);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_IoFilter(ushort CardNo, ushort bitno, double filter);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_IoFilter(ushort CardNo, ushort bitno, ref double filter);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_lsc_index_value(ushort CardNo, ushort axis, ushort IndexID, int IndexValue);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_lsc_index_value(ushort CardNo, ushort axis, ushort IndexID,
            ref int IndexValue);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_lsc_config(ushort CardNo, ushort axis, ushort Origin, uint Interal,
            uint NegIndex, uint PosIndex, double Ratio);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_lsc_config(ushort CardNo, ushort axis, ref ushort Origin, ref uint Interal,
            ref uint NegIndex, ref uint PosIndex, ref double Ratio);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_watchdog(ushort CardNo, ushort enable, uint time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_call_watchdog(ushort CardNo);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_diagnoseData(ushort CardNo);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_cmd_end(ushort CardNo, ushort Crd, ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_zone_limit_config(ushort CardNo, ushort[] axis, ushort[] Source, int x_pos_p,
            int x_pos_n, int y_pos_p, int y_pos_n, ushort action_para);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_zone_limit_config(ushort CardNo, ushort[] axis, ushort[] Source,
            ref int x_pos_p, ref int x_pos_n, ref int y_pos_p, ref int y_pos_n, ref ushort action_para);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_zone_limit_enable(ushort CardNo, ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interlock_config(ushort CardNo, ushort[] axis, ushort[] Source,
            int delta_pos, ushort action_para);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_interlock_config(ushort CardNo, ushort[] axis, ushort[] Source,
            ref int delta_pos, ref ushort action_para);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interlock_enable(ushort CardNo, ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_grant_error_protect(ushort CardNo, ushort axis, ushort enable,
            uint dstp_error, uint emg_error);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_grant_error_protect(ushort CardNo, ushort axis, ref ushort enable,
            ref uint dstp_error, ref uint emg_error);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_camerablow_config(ushort CardNo, ushort camerablow_en, int cameraPos,
            ushort piece_num, int piece_distance, ushort axis_sel, int latch_distance_min);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_camerablow_config(ushort CardNo, ref ushort camerablow_en, ref int cameraPos,
            ref ushort piece_num, ref int piece_distance, ref ushort axis_sel, ref int latch_distance_min);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_camerablow_errorcode(ushort CardNo);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_camerablow_errorcode(ushort CardNo, ref ushort errorcode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_limit_config(ushort CardNo, ushort portno, ushort enable, ushort axis_sel,
            ushort el_mode, ushort el_logic);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_limit_config(ushort CardNo, ushort portno, ref ushort enable,
            ref ushort axis_sel, ref ushort el_mode, ref ushort el_logic);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_filter(ushort CardNo, ushort axis, double filter_factor);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_filter(ushort CardNo, ushort axis, ref double filter_factor);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_interp_map(ushort CardNo, ushort Crd, ref ushort AxisNum,
            ushort[] AxisList, double[] pPosList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_crd_errcode(ushort CardNo, ushort Crd, ref ushort errcode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_line_unit_follow(ushort CardNo, ushort Crd, ushort AxisNum, ushort[] AxisList,
            double[] Dist, ushort posi_mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit_follow(ushort CardNo, ushort Crd, ushort AxisNum,
            ushort[] AxisList, double[] pPosList, ushort posi_mode, int mark);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_da_action(ushort CardNo, ushort Crd, ushort mode, ushort portno,
            double dvalue);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_encoder_speed(ushort CardNo, ushort Axis, ref double current_speed);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_axis_follow_line_enable(ushort CardNo, ushort Crd, ushort enable_flag);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interp_compensation(ushort CardNo, ushort axis, double dvalue, double time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_interp_compensation(ushort CardNo, ushort axis, ref double dvalue,
            ref double time);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_exactstop(ushort CardNo, ushort axis, ushort ioNum, ushort[] ioList,
            ushort enable, ushort valid_logic, ushort action);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_distance_to_start(ushort CardNo, ushort Crd, ref double distance_x,
            ref double distance_y, int imark);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_start_distance_flag(ushort CardNo, ushort Crd, ushort flag);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_soft_limit(ushort CardNo, ushort Axis, int N_limit, int P_limit);

        [DllImport("LTDMC.dll")]
        public static extern short
            dmc_get_home_soft_limit(ushort CardNo, ushort Axis, ref int N_limit, ref int P_limit);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_gear_unit(ushort CardNo, ushort Crd, ushort axis, double dist,
            ushort follow_mode, int imark);

        //轨迹拟合使能设置
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_path_fitting_enable(ushort CardNo, ushort Crd, ushort enable);

        //螺距补偿功能(新)
        [DllImport("LTDMC.dll")]
        public static extern short dmc_enable_leadscrew_comp(ushort CardNo, ushort axis, ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_leadscrew_comp_config(ushort CardNo, ushort axis, ushort n, int startpos,
            int lenpos, int[] pCompPos, int[] pCompNeg);

        //指定轴做定长位移运动 按固定曲线运动
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern(ushort CardNo, ushort axis, double MidPos, double TargetPos,
            double Min_Vel, double Max_Vel, double stop_Vel, double acc, double dec, ushort posi_mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pulse_encoder_count_error(ushort CardNo, ushort axis, ushort error);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pulse_encoder_count_error(ushort CardNo, ushort axis, ref ushort error);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_pulse_encoder_count_error(ushort CardNo, ushort axis,
            ref int pulse_position, ref int enc_position);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_update_target_position_extern(ushort CardNo, ushort axis, double mid_pos,
            double aim_pos, double vel, ushort posi_mode);

        //新物件分拣功能
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_close(ushort CardNo);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_start(ushort CardNo);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_init_config(ushort CardNo, ushort cameraCount, int[] pCameraPos,
            ushort[] pCamIONo, uint cameraTime, ushort cameraTrigLevel, ushort blowCount, int[] pBlowPos,
            ushort[] pBlowIONo, uint blowTime, ushort blowTrigLevel, ushort axis, ushort dir, ushort checkMode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_camera_trig_count(ushort CardNo, ushort cameraNum,
            uint cameraTrigCnt);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_trig_count(ushort CardNo, ushort cameraNum,
            ref uint pCameraTrigCnt, ushort count);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_count(ushort CardNo, ushort blowNum, uint blowTrigCnt);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_trig_count(ushort CardNo, ushort blowNum, ref uint pBlowTrigCnt,
            ushort count);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_config(ushort CardNo, ushort index, ref int pos,
            ref uint trigTime, ref ushort ioNo, ref ushort trigLevel);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_config(ushort CardNo, ushort index, ref int pos,
            ref uint trigTime, ref ushort ioNo, ref ushort trigLevel);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_status(ushort CardNo, ref int trigCntAll, ref ushort trigMore,
            ref ushort trigLess);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_trig_blow(ushort CardNo, ushort blowNum);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_enable(ushort CardNo, ushort blowNum, ushort enable);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_piece_config(ushort CardNo, uint maxWidth, uint minWidth,
            uint minDistance, uint minTimeIntervel);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_piece_status(ushort CardNo, ref uint pieceFind,
            ref uint piecePassCam, ref uint dist2next, ref uint pieceWidth);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_cam_trig_phase(ushort CardNo, ushort blowNo, double coef);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_phase(ushort CardNo, ushort blowNo, double coef);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_sevon_enable(ushort CardNo, ushort axis, ushort on_off);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sevon_enable(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_cycle(ushort CardNo, ushort cmp, int pos, ushort dir,
            uint bitno, uint cycle, ushort level); //添加比较点

        //通用文件下载
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_file", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_file(ushort CardNo, string pfilename, byte[] pfilenameinControl,
            ushort filetype);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_memfile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_memfile(ushort CardNo, byte[] pbuffer, uint buffsize,
            byte[] pfilenameinControl, ushort filetype);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_upload_file", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_upload_file(ushort CardNo, string pfilename, byte[] pfilenameinControl,
            ushort filetype);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_upload_memfile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_upload_memfile(ushort CardNo, byte[] pbuffer, uint buffsize,
            byte[] pfilenameinControl, ref uint puifilesize, ushort filetype);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_progress(ushort CardNo, ref float process);

        //总线参数
        [DllImport("LTDMC.dll", EntryPoint = "nmc_download_configfile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_download_configfile(ushort CardNo, ushort PortNum, string FileName); //总线ENI配置文件

        [DllImport("LTDMC.dll", EntryPoint = "nmc_download_mapfile", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_download_mapfile(ushort CardNo, string FileName);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_upload_configfile(ushort CardNo, ushort PortNum, string FileName);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_set_manager_para", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_set_manager_para(ushort CardNo, ushort PortNum, int baudrate, ushort ManagerID);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_manager_para", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_manager_para(ushort CardNo, ushort PortNum, ref uint baudrate,
            ref ushort ManagerID);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_set_manager_od", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_set_manager_od(ushort CardNo, ushort PortNum, ushort index, ushort subindex,
            ushort valuelength, uint value);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_manager_od", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_manager_od(ushort CardNo, ushort PortNum, ushort index, ushort subindex,
            ushort valuelength, ref uint value);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_total_axes", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_total_axes(ushort CardNo, ref uint TotalAxis);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_total_ionum", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_total_ionum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_LostHeartbeat_Nodes", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_LostHeartbeat_Nodes(ushort CardNo, ushort PortNum, ushort[] NodeID,
            ref ushort NodeNum);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_EmergeneyMessege_Nodes", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_EmergeneyMessege_Nodes(ushort CardNo, ushort PortNum, uint[] NodeMsg,
            ref ushort MsgNum);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_SendNmtCommand", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_SendNmtCommand(ushort CardNo, ushort PortNum, ushort NodeID, ushort NmtCommand);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_syn_move", CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_syn_move(ushort CardNo, ushort AxisNum, ushort[] AxisList, int[] Position,
            ushort[] PosiMode);

        //
        [DllImport("LTDMC.dll")]
        public static extern short nmc_syn_move_unit(ushort CardNo, ushort AxisNum, ushort[] AxisList,
            double[] Position, ushort[] PosiMode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_pmove_unit(ushort CardNo, ushort AxisNum, ushort[] AxisList, double[] Dist,
            ushort[] PosiMode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_vmove_unit(ushort CardNo, ushort AxisNum, ushort[] AxisList, ushort[] Dir);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_master_para(ushort CardNo, ushort PortNum, ushort Baudrate, uint NodeCnt,
            ushort MasterId);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_master_para(ushort CardNo, ushort PortNum, ref ushort Baudrate,
            ref uint NodeCnt, ref ushort MasterId);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_total_adcnum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_controller_workmode(ushort CardNo, ushort controller_mode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_controller_workmode(ushort CardNo, ref ushort controller_mode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_cycletime(ushort CardNo, ushort FieldbusType, int CycleTime);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_cycletime(ushort CardNo, ushort FieldbusType, ref int CycleTime);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_node_od(ushort CardNo, ushort PortNum, ushort nodenum, ushort index,
            ushort subindex, ushort valuelength, ref int value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_node_od(ushort CardNo, ushort PortNum, ushort nodenum, ushort index,
            ushort subindex, ushort valuelength, int value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_to_factory(ushort CardNo, ushort PortNum, ushort NodeNum);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_alarm_clear(ushort CardNo, ushort PortNum, ushort nodenum);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_nodes(ushort CardNo, ushort PortNum, ushort BaudRate,
            ref ushort NodeId, ref ushort NodeNum);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outbit(ushort CardNo, ushort NodeID, ushort IoBit, ushort IoValue);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outbit(ushort CardNo, ushort NodeID, ushort IoBit, ref ushort IoValue);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inbit(ushort CardNo, ushort NodeID, ushort IoBit, ref ushort IoValue);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outport(ushort CardNo, ushort NodeID, ushort PortNo, int IoValue);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outport(ushort CardNo, ushort NodeID, ushort PortNo, ref int IoValue);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inport(ushort CardNo, ushort NodeID, ushort PortNo, ref int IoValue);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_state_machine(ushort CardNo, ushort axis, ref ushort Axis_StateMachine);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_statusword(ushort CardNo, ushort axis, ref int statusword);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_setting_contrlmode(ushort CardNo, ushort axis, ref int contrlmode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_contrlword(ushort CardNo, ushort axis, ref int contrlword);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_type(ushort CardNo, ushort axis, ref ushort Axis_Type);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_consume_time_fieldbus(ushort CardNo, ushort Fieldbustype,
            ref uint Average_time, ref uint Max_time, ref ulong Cycles);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_consume_time_fieldbus(ushort CardNo, ushort Fieldbustype);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_enable(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_disable(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_node_address(ushort CardNo, ushort axis, ref ushort SlaveAddr,
            ref ushort Sub_SlaveAddr);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_total_slaves(ushort CardNo, ushort PortNum, ref ushort TotalSlaves);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_home_profile(ushort CardNo, ushort axis, ushort home_mode, double Low_Vel,
            double High_Vel, double Tacc, double Tdec, double offsetpos);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_home_profile(ushort CardNo, ushort axis, ref ushort home_mode,
            ref double Low_Vel, ref double High_Vel, ref double Tacc, ref double Tdec, ref double offsetpos);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_home_move(ushort CardNo, ushort axis);

        //
        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_scan_ethercat(ushort CardNo, ushort AddressID);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_stop_scan_ethercat(ushort CardNo, ushort AddressID);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_run_mode(ushort CardNo, ushort axis, ushort run_mode);

        //
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_alarm_fieldbus(ushort CardNo, ushort PortNum);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_stop_etc(ushort CardNo, ref ushort ETCState);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_contrlmode(ushort CardNo, ushort Axis, ref int Contrlmode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_io_in(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_io_out(ushort CardNo, ushort axis, uint iostate);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_io_out(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_errcode(ushort CardNo, ushort channel, ref ushort errcode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_errcode(ushort CardNo, ushort channel);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_errcode(ushort CardNo, ushort axis, ref ushort Errcode);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_axis_errcode(ushort CardNo, ushort axis);

        //RTEX卡添加函数
        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_connect(ushort CardNo, ushort chan, ref ushort info, ref ushort len);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_vendor_info(ushort CardNo, ushort axis, byte[] info, ref ushort len);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_type_info(ushort CardNo, ushort axis, byte[] info, ref ushort len);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_name_info(ushort CardNo, ushort axis, byte[] info, ref ushort len);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_version_info(ushort CardNo, ushort axis, byte[] info, ref ushort len);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_parameter(ushort CardNo, ushort axis, ushort index, ushort subindex,
            uint para_data);

        /**************************************************************
        *功能说明：RTEX驱动器写EEPROM操作
        **************************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_slave_eeprom(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_parameter(ushort CardNo, ushort axis, ushort index, ushort subindex,
            ref uint para_data);

        /**************************************************************
         * *index:rtex驱动器的参数分类
         * *subindex:rtex驱动器在index类别下的参数编号
         * *para_data:读出的参数值
         * **************************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_parameter_attributes(ushort CardNo, ushort axis, ushort index,
            ushort subindex, ref uint para_data);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_cmdcycletime(ushort CardNo, ushort PortNum, uint cmdtime);

        //设置RTEX总线周期比(us)
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_cmdcycletime(ushort CardNo, ushort PortNum, ref uint cmdtime);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_config_atuo_log(ushort CardNo, ushort ifenable, ushort dir, ushort byte_index,
            ushort mask, ushort condition, uint counter);

        //扩展PDO
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_rxpdo_extra(ushort CardNo, ushort PortNum, ushort address, ushort DataLen,
            int Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_rxpdo_extra(ushort CardNo, ushort PortNum, ushort address, ushort DataLen,
            ref int Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_txpdo_extra(ushort CardNo, ushort PortNum, ushort address, ushort DataLen,
            ref int Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_rxpdo_extra_uint(ushort CardNo, ushort PortNum, ushort address,
            ushort DataLen, uint Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_rxpdo_extra_uint(ushort CardNo, ushort PortNum, ushort address,
            ushort DataLen, ref uint Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_txpdo_extra_uint(ushort CardNo, ushort PortNum, ushort address,
            ushort DataLen, ref uint Value);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_log_state(ushort CardNo, ushort chan, ref uint state);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_driver_reset(ushort CardNo, ushort axis);

        //add 250000
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_set_mode(ushort ConnectNo, ushort hcmp, ushort fifo_mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_get_mode(ushort ConnectNo, ushort hcmp, ref ushort fifo_mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_get_state(ushort ConnectNo, ushort hcmp, ref long remained_points);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_add_point_unit(ushort ConnectNo, ushort hcmp, ushort num,
            double[] cmp_pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_add_table(ushort ConnectNo, ushort hcmp, ushort num, double[] cmp_pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_clear_points(ushort ConnectNo, ushort hcmp);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_el_return(ushort CardNo, ushort axis, ushort enable);
    }
}