// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Dev
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IRobot.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Delegate GoPointDelegate
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    /// <remarks>Lead.CPrim</remarks>
    public delegate bool GoPointDelegate(object sender);

    /// <summary>
    ///     Enum Elbow
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum Elbow
    {
        /// <summary>
        ///     The above
        /// </summary>
        Above = 1,

        /// <summary>
        ///     The below
        /// </summary>
        Below = 2
    }

    /// <summary>
    ///     Enum Hand
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum Hand
    {
        /// <summary>
        ///     The righty
        /// </summary>
        Righty = 1,

        /// <summary>
        ///     The lefty
        /// </summary>
        Lefty = 2
    }

    /// <summary>
    ///     Enum PosType
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum PosType
    {
        /// <summary>
        ///     The world
        /// </summary>
        World = 0,

        /// <summary>
        ///     The joint
        /// </summary>
        Joint = 1,

        /// <summary>
        ///     The pulse
        /// </summary>
        Pulse = 2
    }

    /// <summary>
    ///     Enum Wrist
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public enum Wrist
    {
        /// <summary>
        ///     The no flip
        /// </summary>
        NoFlip = 1,

        /// <summary>
        ///     The flip
        /// </summary>
        Flip = 2
    }

    /// <summary>
    ///     Interface IRobot
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IRobot
    {
        /// <summary>
        ///     Gets or sets a value indicating whether [check executing].
        /// </summary>
        /// <value><c>true</c> if [check executing]; otherwise, <c>false</c>.</value>
        /// <remarks>Lead.CPrim</remarks>
        bool CheckExecuting { set; get; }

        /// <summary>
        ///     Gets or sets the configuration file path.
        /// </summary>
        /// <value>The configuration file path.</value>
        /// <remarks>Lead.CPrim</remarks>
        string ConfigFilePath { set; get; }

        /// <summary>
        ///     Gets the current position joint.
        /// </summary>
        /// <value>The current position joint.</value>
        /// <remarks>Lead.CPrim</remarks>
        PosJoint CurPosJoint { get; }

        /// <summary>
        ///     Gets the current position pulse.
        /// </summary>
        /// <value>The current position pulse.</value>
        /// <remarks>Lead.CPrim</remarks>
        PosPulse CurPosPulse { get; }

        /// <summary>
        ///     Gets the current position world.
        /// </summary>
        /// <value>The current position world.</value>
        /// <remarks>Lead.CPrim</remarks>
        PosWorld CurPosWorld { get; }

        /// <summary>
        ///     Gets or sets the index of the dev.
        /// </summary>
        /// <value>The index of the dev.</value>
        /// <remarks>Lead.CPrim</remarks>
        int DevIndex { set; get; }

        /// <summary>
        ///     Gets or sets the object lock.
        /// </summary>
        /// <value>The object lock.</value>
        /// <remarks>Lead.CPrim</remarks>
        object objLock { set; get; }

        /// <summary>
        ///     Gets or sets the points directory path.
        /// </summary>
        /// <value>The points directory path.</value>
        /// <remarks>Lead.CPrim</remarks>
        string PointsDirectoryPath { set; get; }

        /// <summary>
        ///     Gets the robot status.
        /// </summary>
        /// <value>The robot status.</value>
        /// <remarks>Lead.CPrim</remarks>
        RobotStatus RobotStatus { get; }

        /// <summary>
        ///     Occurs when [on go point].
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        event GoPointDelegate OnGoPoint;

        /// <summary>
        ///     Abses the go xyr.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r">The r.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int AbsGoXYR(double x, double y, double r, bool asyncMode);

        /// <summary>
        ///     Abses the go xyzr.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="r">The r.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int AbsGoXYZR(double x, double y, double z, double r, bool asyncMode);

        /// <summary>
        ///     Agls the specified joint index.
        /// </summary>
        /// <param name="JointIndex">Index of the joint.</param>
        /// <returns>System.Single.</returns>
        /// <remarks>Lead.CPrim</remarks>
        float Agl(int JointIndex);

        /// <summary>
        ///     Executes the command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ExecCommand(string cmd);

        /// <summary>
        ///     Executes the command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="reply">The reply.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ExecCommand(string cmd, ref string reply);

        /// <summary>
        ///     Gets the current position.
        /// </summary>
        /// <param name="posType">Type of the position.</param>
        /// <param name="Arm">The arm.</param>
        /// <param name="Tool">Converts to ol.</param>
        /// <param name="Local">The local.</param>
        /// <param name="Value1">The value1.</param>
        /// <param name="Value2">The value2.</param>
        /// <param name="Value3">The value3.</param>
        /// <param name="Value4">The value4.</param>
        /// <param name="Value5">The value5.</param>
        /// <param name="Value6">The value6.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetCurrentPos(PosType posType, int Arm, int Tool, int Local, ref double Value1, ref double Value2,
            ref double Value3, ref double Value4, ref double Value5,
            ref double Value6);

        /// <summary>
        ///     Gets the current position.
        /// </summary>
        /// <param name="posType">Type of the position.</param>
        /// <param name="Value1">The value1.</param>
        /// <param name="Value2">The value2.</param>
        /// <param name="Value3">The value3.</param>
        /// <param name="Value4">The value4.</param>
        /// <param name="Value5">The value5.</param>
        /// <param name="Value6">The value6.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetCurrentPos(PosType posType, ref double Value1, ref double Value2,
            ref double Value3, ref double Value4, ref double Value5,
            ref double Value6);

        /// <summary>
        ///     Gets the input bit.
        /// </summary>
        /// <param name="TargetInputBit">The target input bit.</param>
        /// <param name="IsOn">if set to <c>true</c> [is on].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetInputBit(int TargetInputBit, ref bool IsOn);

        /// <summary>
        ///     Gets the input byte.
        /// </summary>
        /// <param name="TargetInputByte">The target input byte.</param>
        /// <param name="ByteStatus">The byte status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetInputByte(int TargetInputByte, ref byte ByteStatus);

        /// <summary>
        ///     Gets the input word.
        /// </summary>
        /// <param name="TargetInputWord">The target input word.</param>
        /// <param name="WordStatus">The word status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetInputWord(int TargetInputWord, ref ushort WordStatus);

        /// <summary>
        ///     Gets the memory bit.
        /// </summary>
        /// <param name="TargetMemoryBit">The target memory bit.</param>
        /// <param name="IsOn">if set to <c>true</c> [is on].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetMemoryBit(int TargetMemoryBit, ref bool IsOn);

        /// <summary>
        ///     Gets the memory byte.
        /// </summary>
        /// <param name="TargetMemoryByte">The target memory byte.</param>
        /// <param name="ByteStatus">The byte status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetMemoryByte(int TargetMemoryByte, ref byte ByteStatus);

        /// <summary>
        ///     Gets the memory word.
        /// </summary>
        /// <param name="TargetMemoryWord">The target memory word.</param>
        /// <param name="WordStatus">The word status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetMemoryWord(int TargetMemoryWord, ref ushort WordStatus);

        /// <summary>
        ///     Gets the output bit.
        /// </summary>
        /// <param name="TargetInputBit">The target input bit.</param>
        /// <param name="IsOn">if set to <c>true</c> [is on].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetOutputBit(int TargetInputBit, ref bool IsOn);

        /// <summary>
        ///     Gets the p label.
        /// </summary>
        /// <param name="pIndex">Index of the p.</param>
        /// <param name="pLabel">The p label.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetPLabel(int pIndex, ref string pLabel);

        /// <summary>
        ///     Goes the specified expr.
        /// </summary>
        /// <param name="Expr">The expr.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Go(string Expr, bool asyncMode);

        /// <summary>
        ///     Goes the point.
        /// </summary>
        /// <param name="PointName">Name of the point.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GoPoint(string PointName, bool asyncMode);

        /// <summary>
        ///     Goes the point.
        /// </summary>
        /// <param name="PointIndex">Index of the point.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GoPoint(int PointIndex, bool asyncMode);

        /// <summary>
        ///     Goes the y.
        /// </summary>
        /// <param name="PointName">Name of the point.</param>
        /// <param name="y">The y.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GoY(string PointName, double y, bool asyncMode);

        /// <summary>
        ///     Goes the z.
        /// </summary>
        /// <param name="PointName">Name of the point.</param>
        /// <param name="z">The z.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GoZ(string PointName, double z, bool asyncMode);

        /// <summary>
        ///     Goes the z.
        /// </summary>
        /// <param name="PointIndex">Index of the point.</param>
        /// <param name="z">The z.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GoZ(int PointIndex, double z, bool asyncMode);

        /// <summary>
        ///     Jogs the move tool.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="distance">The distance.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int JogMoveTool(string index, float distance, bool asyncMode);

        /// <summary>
        ///     Jogs the move world.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="distance">The distance.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int JogMoveWorld(string index, float distance, bool asyncMode);

        /// <summary>
        ///     Jump3s the point.
        /// </summary>
        /// <param name="PointName">Name of the point.</param>
        /// <param name="PointName1">The point name1.</param>
        /// <param name="PointName2">The point name2.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Jump3Point(string PointName, string PointName1, string PointName2, bool asyncMode);

        /// <summary>
        ///     Motorses the operation.
        /// </summary>
        /// <param name="IsOn">if set to <c>true</c> [is on].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int MotorsOperation(bool IsOn);

        /// <summary>
        ///     Moves the specified expr.
        /// </summary>
        /// <param name="Expr">The expr.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Move(string Expr, bool asyncMode);

        /// <summary>
        ///     Moves the world.
        /// </summary>
        /// <param name="PointName">Name of the point.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int MoveWorld(string PointName, bool asyncMode);

        /// <summary>
        ///     Moves the world.
        /// </summary>
        /// <param name="PointIndex">Index of the point.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int MoveWorld(int PointIndex, bool asyncMode);

        /// <summary>
        ///     Passes the specified pass expr.
        /// </summary>
        /// <param name="PassExpr">The pass expr.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Pass(string PassExpr);

        /// <summary>
        ///     Passes the point.
        /// </summary>
        /// <param name="PointIndex">Index of the point.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int PassPoint(int PointIndex);

        /// <summary>
        ///     Powers the operation.
        /// </summary>
        /// <param name="IsHigh">if set to <c>true</c> [is high].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int PowerOperation(bool IsHigh);

        /// <summary>
        ///     Relatives the go xyr.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r">The r.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RelGoXYR(double x, double y, double r, bool asyncMode);

        /// <summary>
        ///     Relatives the go xyr.
        /// </summary>
        /// <param name="PointName">Name of the point.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="r">The r.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RelGoXYR(string PointName, double x, double y, double r, bool asyncMode);

        /// <summary>
        ///     Relatives the go xyzr.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="r">The r.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RelGoXYZR(double x, double y, double z, double r, bool asyncMode);

        /// <summary>
        ///     Relatives the go xyzr.
        /// </summary>
        /// <param name="PointName">Name of the point.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="r">The r.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RelGoXYZR(string PointName, double x, double y, double z, double r, bool asyncMode);

        /// <summary>
        ///     Relatives the move xyz.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RelMoveXYZ(double x, double y, double z, bool asyncMode);

        /// <summary>
        ///     Relatives the move xyz.
        /// </summary>
        /// <param name="PointName">Name of the point.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="asyncMode">if set to <c>true</c> [asynchronous mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RelMoveXYZ(string PointName, double x, double y, double z, bool asyncMode);

        /// <summary>
        ///     Robots the abort.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RobotAbort();

        /// <summary>
        ///     Robots the continue.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RobotContinue();

        /// <summary>
        ///     Robots the pause.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RobotPause();

        /// <summary>
        ///     Robots the reset.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int RobotReset();

        /// <summary>
        ///     Saves the point position.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SavePointPos();

        /// <summary>
        ///     Selects the tool.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SelectTool(int index);

        /// <summary>
        ///     Sets the accel speed.
        /// </summary>
        /// <param name="TargetAccelSpeed">The target accel speed.</param>
        /// <param name="TargetDecelSpeed">The target decel speed.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetACCELSpeed(ushort TargetAccelSpeed, ushort TargetDecelSpeed);

        /// <summary>
        ///     Sets the accel speed s.
        /// </summary>
        /// <param name="TargetAccelSpeedS">The target accel speed s.</param>
        /// <param name="TargetDecelSpeedS">The target decel speed s.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetACCELSpeedS(ushort TargetAccelSpeedS, ushort TargetDecelSpeedS);

        /// <summary>
        ///     Sets the asynchronous mode.
        /// </summary>
        /// <param name="mode">if set to <c>true</c> [mode].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetAsyncMode(bool mode);

        /// <summary>
        ///     Sets the memory bit.
        /// </summary>
        /// <param name="TargetMemoryBit">The target memory bit.</param>
        /// <param name="TurnOn">if set to <c>true</c> [turn on].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetMemoryBit(int TargetMemoryBit, bool TurnOn);

        /// <summary>
        ///     Sets the memory byte.
        /// </summary>
        /// <param name="TargetMemoryByte">The target memory byte.</param>
        /// <param name="ByteSetStatus">The byte set status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetMemoryByte(int TargetMemoryByte, byte ByteSetStatus);

        /// <summary>
        ///     Sets the memory word.
        /// </summary>
        /// <param name="TargetMemoryWord">The target memory word.</param>
        /// <param name="WordSetStatus">The word set status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetMemoryWord(int TargetMemoryWord, ushort WordSetStatus);

        /// <summary>
        ///     Sets the output bit.
        /// </summary>
        /// <param name="TargetOutputBit">The target output bit.</param>
        /// <param name="TurnOn">if set to <c>true</c> [turn on].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetOutputBit(int TargetOutputBit, bool TurnOn);

        /// <summary>
        ///     Sets the output byte.
        /// </summary>
        /// <param name="TargetOutputByte">The target output byte.</param>
        /// <param name="ByteSetStatus">The byte set status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetOutputByte(int TargetOutputByte, byte ByteSetStatus);

        /// <summary>
        ///     Sets the output word.
        /// </summary>
        /// <param name="TargetOutputWord">The target output word.</param>
        /// <param name="WordSetStatus">The word set status.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetOutputWord(int TargetOutputWord, ushort WordSetStatus);

        /// <summary>
        ///     Sets the speed.
        /// </summary>
        /// <param name="TargetSpeed">The target speed.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetSpeed(int TargetSpeed);

        /// <summary>
        ///     Sets the speed factor.
        /// </summary>
        /// <param name="factor">The factor.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetSpeedFactor(int factor);

        /// <summary>
        ///     Sets the speed s.
        /// </summary>
        /// <param name="TargetSpeedS">The target speed s.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int SetSpeedS(int TargetSpeedS);

        /// <summary>
        ///     Starts the mission.
        /// </summary>
        /// <param name="NumberOfMission">The number of mission.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int StartMission(int NumberOfMission);

        /// <summary>
        ///     Stops the mission.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int StopMission();

        /// <summary>
        ///     Tills the on.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Till_On(string idx);

        /// <summary>
        ///     vs the run.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int VRun(string name);

        /// <summary>
        ///     Waits the command complete.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int WaitCommandComplete();
    }

    /// <summary>
    ///     Struct RobotStatus
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public struct RobotStatus
    {
        /// <summary>
        ///     The automatic
        /// </summary>
        public bool Auto;

        /// <summary>
        ///     The error
        /// </summary>
        public bool Error;

        /// <summary>
        ///     The e stop
        /// </summary>
        public bool EStop;

        /// <summary>
        ///     The motors on
        /// </summary>
        public bool MotorsOn;

        /// <summary>
        ///     The paused
        /// </summary>
        public bool Paused;

        /// <summary>
        ///     The power high
        /// </summary>
        public bool PowerHigh;

        /// <summary>
        ///     The ready
        /// </summary>
        public bool Ready;

        /// <summary>
        ///     The running
        /// </summary>
        public bool Running;

        /// <summary>
        ///     The safeguard
        /// </summary>
        public bool Safeguard;

        /// <summary>
        ///     The s error
        /// </summary>
        public bool SError;

        /// <summary>
        ///     The teach
        /// </summary>
        public bool Teach;

        /// <summary>
        ///     The test
        /// </summary>
        public bool Test;

        /// <summary>
        ///     The warning
        /// </summary>
        public bool Warning;
    }

    /// <summary>
    ///     Class EpsonPoint.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class EpsonPoint
    {
        /// <summary>
        ///     The elbow
        /// </summary>
        public Elbow Elbow;

        /// <summary>
        ///     The hand
        /// </summary>
        public Hand Hand;

        /// <summary>
        ///     The index
        /// </summary>
        public int index;

        /// <summary>
        ///     The j1 angle
        /// </summary>
        public float J1Angle;

        /// <summary>
        ///     The j1 flag
        /// </summary>
        public int J1Flag;

        /// <summary>
        ///     The j2 flag
        /// </summary>
        public int J2Flag;

        /// <summary>
        ///     The j4 angle
        /// </summary>
        public float J4Angle;

        /// <summary>
        ///     The j4 flag
        /// </summary>
        public int J4Flag;

        /// <summary>
        ///     The j6 flag
        /// </summary>
        public int J6Flag;

        /// <summary>
        ///     The label
        /// </summary>
        public string Label;

        /// <summary>
        ///     The local
        /// </summary>
        public int Local;

        /// <summary>
        ///     The u
        /// </summary>
        public float U;

        /// <summary>
        ///     The v
        /// </summary>
        public float V;

        /// <summary>
        ///     The w
        /// </summary>
        public float W;

        /// <summary>
        ///     The wrist
        /// </summary>
        public Wrist Wrist;

        /// <summary>
        ///     The x
        /// </summary>
        public float X;

        /// <summary>
        ///     The y
        /// </summary>
        public float Y;

        /// <summary>
        ///     The z
        /// </summary>
        public float Z;
    }

    /// <summary>
    ///     Class PosJoint.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class PosJoint
    {
        /// <summary>
        ///     The j1
        /// </summary>
        public double J1;

        /// <summary>
        ///     The j2
        /// </summary>
        public double J2;

        /// <summary>
        ///     The j3
        /// </summary>
        public double J3;

        /// <summary>
        ///     The j4
        /// </summary>
        public double J4;

        /// <summary>
        ///     The j5
        /// </summary>
        public double J5;

        /// <summary>
        ///     The j6
        /// </summary>
        public double J6;
    }

    /// <summary>
    ///     Class PosPulse.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class PosPulse
    {
        /// <summary>
        ///     The j1
        /// </summary>
        public double J1;

        /// <summary>
        ///     The j2
        /// </summary>
        public double J2;

        /// <summary>
        ///     The j3
        /// </summary>
        public double J3;

        /// <summary>
        ///     The j4
        /// </summary>
        public double J4;

        /// <summary>
        ///     The j5
        /// </summary>
        public double J5;

        /// <summary>
        ///     The j6
        /// </summary>
        public double J6;
    }

    /// <summary>
    ///     Class PosWorld.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class PosWorld
    {
        /// <summary>
        ///     The elbow
        /// </summary>
        public Elbow Elbow;

        /// <summary>
        ///     The hand
        /// </summary>
        public Hand Hand;

        /// <summary>
        ///     The r
        /// </summary>
        public double R;

        /// <summary>
        ///     The s
        /// </summary>
        public double S;

        /// <summary>
        ///     The t
        /// </summary>
        public double T;

        /// <summary>
        ///     The u
        /// </summary>
        public double U;

        /// <summary>
        ///     The v
        /// </summary>
        public double V;

        /// <summary>
        ///     The w
        /// </summary>
        public double W;

        /// <summary>
        ///     The wrist
        /// </summary>
        public Wrist Wrist;

        /// <summary>
        ///     The x
        /// </summary>
        public double X;

        /// <summary>
        ///     The y
        /// </summary>
        public double Y;

        /// <summary>
        ///     The z
        /// </summary>
        public double Z;
    }

    /// <summary>
    ///     Class XmlPoint.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class XmlPoint
    {
        /// <summary>
        ///     The index
        /// </summary>
        public string Index;

        /// <summary>
        ///     The label
        /// </summary>
        public string Label;

        /// <summary>
        ///     The u
        /// </summary>
        public float U;

        /// <summary>
        ///     The v
        /// </summary>
        public float V;

        /// <summary>
        ///     The w
        /// </summary>
        public float W;

        /// <summary>
        ///     The x
        /// </summary>
        public float X;

        /// <summary>
        ///     The y
        /// </summary>
        public float Y;

        /// <summary>
        ///     The z
        /// </summary>
        public float Z;
    }
}