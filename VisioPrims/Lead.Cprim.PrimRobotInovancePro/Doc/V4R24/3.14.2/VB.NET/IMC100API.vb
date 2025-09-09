Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)> _
Public Structure MOV_IO
    Public ioNo As Int32
    Public ioVa As Int32
    Public kind As Int32
    Public value As Double
End Structure

Public Structure  ROB_POS
    Public RPosData() As double;
    Public ArmParm() As int;
    Public EPosData() As double;
End Structure

Public Structure  ROB_JPOS
    Public RPosData() As double;
    Public EPosData() As double;
End Structure

Public Structure POSE
    Public Data() As double;
End Structure

Public Structure LOAD_DATA
    Public Mass As double;
    Public Cog() As double;
    Public Orient() As double;
    Public Inertia() As double;
End Structure


Public Structure TOOL_DATA
    Public RobHold As int;
    Public TFrame As POSE;	
    Public TLoad As LOAD_DATA;
End Structure


Public Structure WOBJ_DATA
    Public RobHold As int;
    Public UFFix As int;	
    Public UFMec() As char;
    Public UFrame As POSE;
    Public OFrame As POSE;
End Structure


Public Structure SPEED
    Public vTcp As double;
    Public vOri As double;	
    Public vLeax As double;
    Public rReax As double;
    Public bStatic As int;
End Structure



Public Structure VER_DATA
    Public velType As int;  
    Public velPercent As int;	
    Public speed As SPEED;
End Structure

Public Structure MOV_IO 
    Public IONo As int;  
    Public IOVa As int;	
    Public Kind As int;
    Public Kind As double;
End Structure











Module IMC100API
    Declare Function IMC100_Init_ETH Lib "IMC100API.dll" (ByVal ipAddr As UInt32, ByVal ipPort As UInt16, ByVal timeOut As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Exit_ETH Lib "IMC100API.dll" (ByVal comId As Int32) As Int32

    Declare Function IMC100_EmergStop Lib "IMC100API.dll" (ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_MotorEnable Lib "IMC100API.dll" (ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_ResetErr Lib "IMC100API.dll" (ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_Mode Lib "IMC100API.dll" (ByVal mode As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_PrgCtrl Lib "IMC100API.dll" (ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_BackStartLine Lib "IMC100API.dll" (ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_Vel Lib "IMC100API.dll" (ByVal val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_AccRamp Lib "IMC100API.dll" (ByVal startVal As Dobule, ByVal endVal As Dobule, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_RapidMove Lib "IMC100API.dll" (ByVal movType As Int32, ByVal enableFlag As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_SLVSMode Lib "IMC100API.dll" (ByVal mode As Int32, ByVal comId As Int32) As Int32
   
    Declare Function IMC100_Set_FlyMode Lib "IMC100API.dll" (ByVal cpMode As Int32, ByVal flyMode As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_FlyPress Lib "IMC100API.dll" (ByVal flyPressPos As Int32, ByVal flyPressOrient As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_DsMode Lib "IMC100API.dll" (ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_SlewMode Lib "IMC100API.dll" (ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_DO Lib "IMC100API.dll" (ByVal num As Int32, ByVal status As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_DOGroup Lib "IMC100API.dll" (ByVal num As Int32, ByVal status As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_DA Lib "IMC100API.dll" (ByVal num As Int32, ByVal val As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_InchMode Lib "IMC100API.dll" (ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_InchStep Lib "IMC100API.dll" (ByVal val As Int32, ByVal comId As Int32) As Int32

    
    Declare Function IMC100_AxisJog Lib "IMC100API.dll" (ByVal axis As Int32, ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_AxisInch Lib "IMC100API.dll" (ByVal axis As Int32, ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_PoseAlign Lib "IMC100API.dll" (ByVal coord  As Int32, ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_ActiveMechUnit Lib "IMC100API.dll" (ByVal mecUnit As Byte(), ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_ActiveMechUnit Lib "IMC100API.dll" (ByVal mecUnit As Byte(), ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_TeachCoordinate Lib "IMC100API.dll" (ByVal flag As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_TeachCoordinate Lib "IMC100API.dll" (ByRef flag As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Home Lib "IMC100API.dll" (ByVal num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_DynamicBrake Lib"IMC100API.dll"(ByVal flag As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DynamicBrake Lib"IMC100API.dll"(ByRef flag As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_MovJ_P Lib "IMC100API.dll" (ByVal posNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_MovL_P Lib "IMC100API.dll" (ByVal posNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_MovC_P Lib "IMC100API.dll" (ByVal posMidNum As Int32, ByVal posDstNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal comId As Int32) As Int32
    
    Declare Function IMC100_MovJ_P_IO Lib "IMC100API.dll" (ByVal posNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal movIo As MOV_IO(), ByVal ioNum As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_MovJ_P_IO Lib "IMC100API.dll" (ByVal posNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal movIo As MOV_IO(), ByVal ioNum As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_MovJ_P_IO Lib "IMC100API.dll" (ByVal posMidNum As Int32, ByVal posDstNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal movIo As MOV_IO(), ByVal ioNum As Int32, ByVal comId As Int32) As Int32
    

    Declare Function IMC100_Jump_P Lib "IMC100API.dll" (ByVal posNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_JumpL_P Lib "IMC100API.dll" (ByVal posNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal comId As Int32) As Int32
    
    Declare Function IMC100_Jump_P_IO Lib "IMC100API.dll" (ByVal posNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal movIo As MOV_IO(), ByVal ioNum As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Jump_P_IO Lib "IMC100API.dll" (ByVal posNum As Int32, ByVal vel As Int32, ByVal zone As Int32, ByVal movIo As MOV_IO(), ByVal ioNum As Int32, ByVal comId As Int32) As Int32
   

   Declare Function IMC100_MovJ_RobPos Lib "IMC100API.dll" (ByRef pos As ROB_POS, ByRef vel As VER_DATA, ByVal zone As Int32, ByVal ioNum As Int32, ByVal movIo As MOV_IO(), ByVal comId As Int32) As Int32
   Declare Function IMC100_MovL_RobPos Lib "IMC100API.dll" (ByRef pos As ROB_POS, ByRef vel As VER_DATA, ByVal zone As Int32, ByVal ioNum As Int32, ByVal movIo As MOV_IO(), ByVal comId As Int32)  As Int32
   Declare Function IMC100_MovC_RobPos Lib "IMC100API.dll" (ByRef posMid As ROB_POS, ByRef posDst As ROB_POS, ByRef vel As VER_DATA, ByVal zone As Int32, ByVal ioNum As Int32, ByVal movIo As MOV_IO(), ByVal comId As Int32)  As Int32
   Declare Function IMC100_Jump_RobPos Lib "IMC100API.dll" (ByRef pos As ROB_POS, ByRef vel As VER_DATA, ByVal zone As Int32, ByVal ioNum As Int32, ByVal movIo As MOV_IO(), ByVal comId As Int32)  As Int32
   Declare Function IMC100_JumpL_RobPos Lib "IMC100API.dll" (ByRef pos As ROB_POS, ByRef vel As VER_DATA, ByVal zone As Int32, ByVal ioNum As Int32, ByVal movIo As MOV_IO(), ByVal comId As Int32)  As Int32
   Declare Function IMC100_MovJAbs_RobJPos Lib "IMC100API.dll" (ByRef pos As ROB_JPOS, ByRef vel As VER_DATA, ByVal zone As Int32, ByVal ioNum As Int32, ByVal movIo As MOV_IO(), ByVal comId As Int32)  As Int32
   Declare Function IMC100_MovJAbs_JP Lib "IMC100API.dll" (ByVal posNum As Int32, ByRef vel As VER_DATA, ByVal zone As Int32, ByVal ioNum As Int32, ByVal movIo As MOV_IO(), ByVal comId As Int32)  As Int32

    Declare Function IMC100_IndCMove Lib "IMC100API.dll" (ByVal mecUnit As Byte(), ByVal axis As Int32, ByVal speed As Double, ByVal acc As Double, ByVal dec As Double, ByVal comId As Int32) As Int32
    Declare Function IMC100_IndSpeed Lib "IMC100API.dll" (ByVal mecUnit As Byte(), ByVal axis As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_IndResetOld Lib "IMC100API.dll" (ByVal mecUnit As Byte(), ByVal axis As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_IndReset Lib "IMC100API.dll" (ByVal mecUnit As Byte(), ByVal axis As Int32, ByVal refNum As Double, ByVal direction As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_IndCMoveSts Lib "IMC100API.dll" (ByVal mecUnit As Byte(), ByVal axis As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_IndResetSts Lib "IMC100API.dll" (ByVal mecUnit As Byte(), ByVal axis As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_MotionStsExceptIndAxis Lib "IMC100API.dll" (ByRef sts As Int32, ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_RobPosHere Lib "IMC100API.dll" (ByRef pos As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_RobJPosHere Lib "IMC100API.dll" (ByRef pos As ROB_JPOS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_PosHerePulse Lib "IMC100API.dll" (ByVal pos As Double(), ByVal comId As Int32) As Int32    'pos.Length >= 6
    Declare Function IMC100_Set_ActiveMechUnitPosFormat Lib "IMC100API.dll" (ByVal posFormat As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_ActiveMechUnitPos Lib "IMC100API.dll" (ByRef posFormat As Int32, ByRef mechUnitPos As Dobule,  ByVal comId As Int32) As Int32
   
   
    
    Declare Function IMC100_Get_RobJToRobP Lib "IMC100API.dll" (ByRef posSrc As ROB_JPOS, ByVal toolnum As Int32, ByVal wobjnum As Int32, ByVal loadnum As Int32, ByRef posDst As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_RobPToRobJ Lib "IMC100API.dll" (ByRef posSrc As ROB_POS, ByVal toolnum As Int32, ByVal wobjnum As Int32, ByVal loadnum As Int32, ByRef posDst As ROB_JPOS, ByVal comId As Int32)  As Int32
    Declare Function IMC100_Get_FixWobjRobP Lib "IMC100API.dll" (ByRef posBase As ROB_POS, ByVal wobjnum As Int32, ByRef posDst As ROB_POS, ByVal comId As Int32)  As Int32
    Declare Function IMC100_Get_RobHoldWobjRobP Lib "IMC100API.dll" (ByRef posBase As ROB_POS, ByVal wobjnum As Int32, ByRef posRef As ROB_POS, ByRef posRef As ROB_POS, ByVal comId As Int32)  As Int32

    Declare Function IMC100_Get_OffsetJ_RobJP Lib "IMC100API.dll" (ByRef posSrc As ROB_JPOS, ByVal pos As Double(), ByRef posDst As ROB_JPOS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_Offset_RobP Lib "IMC100API.dll" (ByRef posSrc As ROB_POS, ByVal pos As Double(), ByRef posDst As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_OffsetT_RobP Lib "IMC100API.dll" (ByRef posSrc As ROB_POS, ByVal pos As Double(), ByRef posDst As ROB_POS, ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_SysErrSts Lib "IMC100API.dll" (ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_SysErr Lib "IMC100API.dll" (ByRef err As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_TaskPrgPath Lib "IMC100API.dll" (ByVal taskId As Int32, ByVal prgPath As Byte(), ByVal comId As Int32) As Int32    'prgPath.Length >= 128
    Declare Function IMC100_Get_TaskRunSts Lib "IMC100API.dll" (ByVal taskId As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_TaskProgramLine Lib "IMC100API.dll" (ByVal taskId As Int32, ByRef line As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_CurMotionLine Lib "IMC100API.dll" (ByRef line As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_InitSts Lib "IMC100API.dll" (ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_CoordType Lib "IMC100API.dll" (ByRef type As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_AccRamp Lib "IMC100API.dll" (ByRef startVal As Double, ByRef endVal As Double, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_RapidMove Lib "IMC100API.dll" (ByVal movType As Int32, ByRef enableFlag As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_SLVSMode Lib "IMC100API.dll" (ByRef mode As Int32, ByVal comId As Int32) As Int32 
    
    Declare Function IMC100_Get_FlyMode Lib "IMC100API.dll" (ByVal cpMode As Int32, ByRef flyMode As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_FlyPress Lib "IMC100API.dll" (ByRef flyPressPos As Int32, ByRef flyPressOrient As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_Vel Lib "IMC100API.dll" (ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_Mode Lib "IMC100API.dll" (ByRef mode As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DsMode Lib "IMC100API.dll" (ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_InchMode Lib "IMC100API.dll" (ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_SlewMode Lib "IMC100API.dll" (ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_EStopSts Lib "IMC100API.dll" (ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_MotorSts Lib "IMC100API.dll" (ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_MotionSts Lib "IMC100API.dll" (ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_SysMode Lib "IMC100API.dll" (ByRef mode As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_PrgRunTime Lib "IMC100API.dll" (ByRef second As UInt32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_CurCmdNum Lib "IMC100API.dll" (ByRef num As UInt32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_CurCmdSts Lib "IMC100API.dll" (ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_CmdSts Lib "IMC100API.dll" (ByVal num As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_CurCmdCacheNum Lib "IMC100API.dll" (ByVal num As Int32, ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_DINum Lib "IMC100API.dll" (ByRef num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DONum Lib "IMC100API.dll" (ByRef num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_ADNum Lib "IMC100API.dll" (ByRef num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DANum Lib "IMC100API.dll" (ByRef num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DI Lib "IMC100API.dll" (ByVal num As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DIGroup Lib "IMC100API.dll" (ByVal num As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_AD Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DOCfg Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DOGroupCfg Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DO Lib "IMC100API.dll" (ByVal num As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DOGroup Lib "IMC100API.dll" (ByVal num As Int32, ByRef sts As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DACfg Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DA Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_DevSts Lib "IMC100API.dll" (ByVal sts As Int32(), ByVal comId As Int32) As Int32    'sts.Length >= 6
    Declare Function IMC100_Get_FwVersion Lib "IMC100API.dll" (ByVal ver As Byte(), ByVal comId As Int32) As Int32    'ver.Length >= 32
    Declare Function IMC100_Get_SysTime Lib "IMC100API.dll" (ByVal time As Byte(), ByVal comId As Int32) As Int32    'time.Length >= 16    
    Declare Function IMC100_Get_RobotType Lib "IMC100API.dll" (ByVal type As Byte(), ByVal comId As Int32) As Int32    'type.Length >= 128
    Declare Function IMC100_Get_ArmType Lib "IMC100API.dll" (ByVal pos As Double(), ByVal armType As Int32(), ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_ServoSts Lib "IMC100API.dll" (ByVal sts As Int32(), ByVal comId As Int32) As Int32    'sts.Length >= 8
    Declare Function IMC100_Get_ServoErr Lib "IMC100API.dll" (ByVal num As Int32, ByRef err As Int32, ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_StrPara Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_StrPara Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_StrParaComp Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_StrParaComp Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_RdctRatio Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_RdctRatio Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_CpParaM Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_CpParaM Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_CpParaS Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_CpParaS Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_HomeJPos Lib "IMC100API.dll" (ByVal num As Int32, ByRef pos As ROB_JPOS, ByVal comId As Int32) As Int32    
    Declare Function IMC100_Set_HomeJPos Lib "IMC100API.dll" (ByVal num As Int32, ByRef pos As ROB_JPOS,  ByVal comId As Int32) As Int32    
    Declare Function IMC100_Get_ZeroPos Lib "IMC100API.dll" (ByVal pluse As Single(), ByVal comId As Int32) As Int32    'pluse.Length >= 6
    Declare Function IMC100_Set_ZeroPos Lib "IMC100API.dll" (ByVal pluse As Single(), ByVal comId As Int32) As Int32    'pluse.Length >= 6
    Declare Function IMC100_Get_InchStep Lib "IMC100API.dll" (ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_StepMotionJ Lib "IMC100API.dll" (ByRef para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_StepMotionJ Lib "IMC100API.dll" (ByVal para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_StepMotionL Lib "IMC100API.dll" (ByRef para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_StepMotionL Lib "IMC100API.dll" (ByVal para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_StepMotionR Lib "IMC100API.dll" (ByRef para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_StepMotionR Lib "IMC100API.dll" (ByVal para As Single, ByVal comId As Int32) As Int32
    
    Declare Function IMC100_Get_TeachVelLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_TeachVelLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_TeachVelLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Set_TeachVelLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Get_TeachAccLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_TeachAccLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_TeachAccLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Set_TeachAccLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Get_RunVelLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_RunVelLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_RunVelLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Set_RunVelLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Get_RunAccLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_RunAccLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_RunAccLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Set_RunAccLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Get_StopDecLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Set_StopDecLimJ Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 6
    Declare Function IMC100_Get_StopDecLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Set_StopDecLimL Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Get_ZonePara Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2
    Declare Function IMC100_Set_ZonePara Lib "IMC100API.dll" (ByVal para As Single(), ByVal comId As Int32) As Int32    'para.Length >= 2

    Declare Function IMC100_Get_AxisNLim Lib "IMC100API.dll" (ByVal axis As Int32, ByRef para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_AxisNLim Lib "IMC100API.dll" (ByVal axis As Int32, ByVal para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_AxisPLim Lib "IMC100API.dll" (ByVal axis As Int32, ByRef para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_AxisPLim Lib "IMC100API.dll" (ByVal axis As Int32, ByVal para As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_ToolData Lib "IMC100API.dll" (ByVal num As Int32, ByRef para As TOOL_DATA, ByVal comId As Int32) As Int32    
    Declare Function IMC100_Set_ToolData Lib "IMC100API.dll" (ByVal num As Int32, ByRef para As TOOL_DATA, ByVal comId As Int32) As Int32    
    Declare Function IMC100_Get_WobjData Lib "IMC100API.dll" (ByVal num As Int32, ByRef para As WOBJ_DATA, ByVal comId As Int32) As Int32    
    Declare Function IMC100_Set_WobjData Lib "IMC100API.dll" (ByVal num As Int32, ByRef para As WOBJ_DATA, ByVal comId As Int32) As Int32    
    
    Declare Function IMC100_Get_ToolCNum Lib "IMC100API.dll" (ByRef num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_ToolCNum Lib "IMC100API.dll" (ByVal num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_WobjNum Lib "IMC100API.dll" (ByRef num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_WobjNum Lib "IMC100API.dll" (ByVal num As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_CoordType Lib "IMC100API.dll" (ByVal type As Int32, ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_JumpPara Lib "IMC100API.dll" (ByRef lh As Single, ByRef mh As Single, ByRef rh As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_JumpPara Lib "IMC100API.dll" (ByVal lh As Single, ByVal mh As Single, ByVal rh As Single, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_PalletPara Lib "IMC100API.dll" (ByRef rowNum As Int32, ByRef colNum As Int32, ByRef layerNum As Int32, ByRef layerHeight As Double, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_PalletPara Lib "IMC100API.dll" (ByVal rowNum As Int32, ByVal colNum As Int32, ByVal layerNum As Int32, ByVal layerHeight As Double, ByVal comId As Int32) As Int32
    Declare Function IMC100_Clear_PalletPara Lib "IMC100API.dll" (ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_Pallet_RobP Lib "IMC100API.dll" (ByRef pos1 As ROB_POS, ByRef pos2 As ROB_POS, ByRef pos3 As ROB_POS, ByVal rowIndex As Int32, ByVal colIndex As Int32, ByVal layIndex As Int32, ByRef posDst As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_Pallet4_RobP Lib "IMC100API.dll" (ByRef pos1 As ROB_POS, ByRef pos2 As ROB_POS, ByRef pos3 As ROB_POS, ByRef pos4 As ROB_POS, ByVal rowIndex As Int32, ByVal colIndex As Int32, ByVal layIndex As Int32, ByRef posDst As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_SavePara Lib "IMC100API.dll" (ByVal comId As Int32) As Int32
    Declare Function IMC100_RecoverPara Lib "IMC100API.dll" (ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_RobP Lib "IMC100API.dll" (ByVal pNum As Int32, ByRef pos As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_RobP Lib "IMC100API.dll" (ByVal pNum As Int32, ByRef pos As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_MemRobP Lib "IMC100API.dll" (ByVal pNum As Int32, ByRef pos As ROB_POS, ByVal comId As Int32) As Int32
	Declare Function IMC100_Get_RobPFromFile Lib "IMC100API.dll" (ByVal plabelName As Byte(), ByVal pNum As Int32, ByRef pos As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_RobPToFile Lib "IMC100API.dll" (ByVal plabelName As Byte(), ByVal pNum As Int32, ByRef pos As ROB_POS, ByVal comId As Int32) As Int32
	Declare Function IMC100_Get_CurRobPFileName Lib "IMC100API.dll" (ByVal plabelName As Byte(), ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_RobPHere Lib "IMC100API.dll" (ByVal pNum As Int32, ByVal comId As Int32) As Int32
	Declare Function IMC100_Set_RobPHereToFile Lib "IMC100API.dll" (ByVal plabelName As Byte(), ByVal pNum As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_RobJP Lib "IMC100API.dll" (ByVal pNum As Int32, ByRef pos As ROB_JPOS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_RobJP Lib "IMC100API.dll" (ByVal pNum As Int32, ByRef pos As ROB_JPOS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_MemRobJP Lib "IMC100API.dll" (ByVal pNum As Int32, ByRef pos As ROB_JPOS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_RobJPHere Lib "IMC100API.dll" (ByVal pNum As Int32, ByVal comId As Int32) As Int32
    
    Declare Function IMC100_Get_RobP_Label Lib "IMC100API.dll" (ByVal pNum As Int32, ByVal plabelName As Byte(), ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_RobJP_Label Lib "IMC100API.dll" (ByVal pNum As Int32, ByVal plabelName As Byte(), ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_RobLP_Label Lib "IMC100API.dll" (ByVal taskId As Int32, ByVal pProName As Byte(), ByVal pNum As Int32, ByVal plabelName As Byte(), ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_PRVar Lib "IMC100API.dll" (ByVal prNum As Int32, ByRef pos As POSE, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_PRVar Lib "IMC100API.dll" (ByVal prNum As Int32, ByVal pos As POSE, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_B Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_B Lib "IMC100API.dll" (ByVal num As Int32, ByVal val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_R Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_R Lib "IMC100API.dll" (ByVal num As Int32, ByVal val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_D Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Double, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_D Lib "IMC100API.dll" (ByVal num As Int32, ByVal val As Double, ByVal comId As Int32) As Int32

    Declare Function IMC100_Get_ModbusCoil Lib "IMC100API.dll" (ByVal address As Int32, ByVal sum As Int32, ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_ModbusCoil Lib "IMC100API.dll" (ByVal address As Int32, ByVal sum As Int32, ByVal val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_ModbusRegUshort Lib "IMC100API.dll" (ByVal address As Int32, ByVal sum As Int32, ByVal val As UInt16(), ByVal comId As Int32) As Int32    'val.Length >= sum
    Declare Function IMC100_Set_ModbusRegUshort Lib "IMC100API.dll" (ByVal address As Int32, ByVal sum As Int32, ByVal val As UInt16(), ByVal comId As Int32) As Int32    'val.Length >= sum
    Declare Function IMC100_Get_ModbusRegFloat Lib "IMC100API.dll" (ByVal address As Int32, ByVal sum As Int32, ByVal val As Single(), ByVal comId As Int32) As Int32    'val.Length >= sum
    Declare Function IMC100_Set_ModbusRegFloat Lib "IMC100API.dll" (ByVal address As Int32, ByVal sum As Int32, ByVal val As Single(), ByVal comId As Int32) As Int32    'val.Length >= sum
    Declare Function IMC100_Get_PlcVarByte Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Byte, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_PlcVarInt Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Int16, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_PlcVarDInt Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_PlcVarLReal Lib "IMC100API.dll" (ByVal num As Int32, ByRef val As Double, ByVal comId As Int32) As Int32
    Declare Function IMC100_Get_UserAlarm Lib "IMC100API.dll" (ByVal num As Int32, ByVal alarm As Byte(), ByVal comId As Int32) As Int32    'alarm.Length >= 40
    Declare Function IMC100_Set_UserAlarm Lib "IMC100API.dll" (ByVal num As Int32, ByVal alarm As Byte(), ByVal comId As Int32) As Int32    'alarm.Length >= 40
    Declare Function IMC100_Get_Print Lib "IMC100API.dll" (ByVal val As Byte(), ByVal comId As Int32) As Int32    'val.Length >= 128

    Declare Function IMC100_Get_DynamicBrake Lib "IMC100API.dll" (ByRef flag As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_Set_DynamicBrake Lib"IMC100API.dll" (ByVal flag As Int32, ByVal comId As Int32) As Int32
    
    Declare Function IMC100_CurCtrlDev Lib "IMC100API.dll" (ByRef dev As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_CurPermit Lib "IMC100API.dll" (ByRef owner As Int32, ByRef ipAddr As UInt32, ByRef ipPort As UInt16, ByVal comId As Int32) As Int32
    Declare Function IMC100_AcqPermit Lib "IMC100API.dll" (ByVal cmd As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_RemovePermit Lib "IMC100API.dll" (ByVal comId As Int32) As Int32
    Declare Function IMC100_CurUserType Lib "IMC100API.dll" (ByRef type As Int32, ByVal comId As Int32) As Int32
    Declare Function IMC100_UserLogin Lib "IMC100API.dll" (ByVal type As Int32, ByVal password As Byte(), ByVal comId As Int32) As Int32    'password.Length >= 8
    Declare Function IMC100_UserLogout Lib "IMC100API.dll" (ByVal comId As Int32) As Int32

    Declare Function IMC100_Set_SysTime Lib "IMC100API.dll" (ByVal time As Byte(), ByVal comId As Int32) As Int32    'time.Length >= 16

    Declare Function IMC100_LatchEnable Lib "IMC100API.dll" (ByVal cmd As Int32, ByVal comId As Int32) As Int32    
    Declare Function IMC100_Get_LatchSts Lib "IMC100API.dll" (ByRef sts As Int32, ByVal comId As Int32) As Int32   
    Declare Function IMC100_Get_LatchSum Lib "IMC100API.dll" (ByRef sum As Int32, ByVal comId As Int32) As Int32
   
    Declare Function IMC100_Get_LatchRobP Lib "IMC100API.dll" (ByVal index As Int32, ByRef sts As Int32, ByRef pos As ROB_POS, ByVal comId As Int32) As Int32
    Declare Function IMC100_Clr_LatchPos Lib "IMC100API.dll" (ByVal comId As Int32) As Int32
    
    Declare Function IMC100_Set_CollModeAndAction Lib "IMC100API.dll" (ByVal checkflag As Int32, ByVal action As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_CollModeAndAction Lib "IMC100API.dll" (ByRef checkflag As Int32, ByRef action As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Set_AxisCollMode Lib "IMC100API.dll" (ByVal axisNo As Int32, ByVal checkflag As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_AxisCollMode Lib "IMC100API.dll" (ByVal axisNo As Int32, ByRef checkflag As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Set_AxisCollLevel Lib "IMC100API.dll" (ByVal axisNo As Int32, ByVal checkflag As Double, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_AxisCollLevel Lib "IMC100API.dll" (ByVal axisNo As Int32, ByRef checkflag As Double, ByVal comId As Int32) As Int32 
    
    Declare Function IMC100_Set_TeachModeAxisCollMode Lib "IMC100API.dll" (ByVal axisNo As Int32, ByVal checkflag As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_TeachModeAxisCollMode Lib "IMC100API.dll" (ByVal axisNo As Int32, ByRef checkflag As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Set_TeachModeCollAction Lib "IMC100API.dll" (ByVal action As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_TeachModeCollAction Lib "IMC100API.dll" (ByRef action As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Set_TeachModeAxisCollLevel Lib "IMC100API.dll" (ByVal axisNo As Int32, ByVal level As Double, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_TeachModeAxisCollLevel Lib "IMC100API.dll" (ByVal axisNo As Int32, ByRef level As Double, ByVal comId As Int32) As Int32
    
    Declare Function IMC100_Set_PlayBackModeAxisCollMode Lib "IMC100API.dll" (ByVal axisNo As Int32, ByVal checkflag As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_PlayBackModeAxisCollMode Lib "IMC100API.dll" (ByVal axisNo As Int32, ByRef checkflag As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Set_PlayBackModeCollAction Lib "IMC100API.dll" (ByVal action As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_PlayBackModeCollAction Lib "IMC100API.dll" (ByRef action As Int32, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Set_PlayBackModeAxisCollLevel Lib "IMC100API.dll" (ByVal axisNo As Int32, ByVal level As Double, ByVal comId As Int32) As Int32 
    Declare Function IMC100_Get_PlayBackModeAxisCollLevel Lib "IMC100API.dll" (ByVal axisNo As Int32, ByRef level As Double, ByVal comId As Int32) As Int32  
	
	Declare Function IMC100_Get_RobotAxisNum Lib "IMC100API.dll" (ByRef axisNum As Int32, ByVal comId As Int32) As Int32 
    
End Module
