// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.Dev
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="IFesto.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Net.Sockets;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Interface IFesto
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface IFesto
    {
        /// <summary>
        ///     Gets the festo status.
        /// </summary>
        /// <value>The festo status.</value>
        /// <remarks>Lead.CPrim</remarks>
        FestoStatus FestoStatus { get; }

        /// <summary>
        ///     Aborts the press process.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Abort_Press_Process(bool state);

        /// <summary>
        ///     Automatics the matic mode.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int AutoMatic_Mode(bool state);

        /// <summary>
        ///     Backs the home.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int BackHome();

        /// <summary>
        ///     Checks the connection.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int CheckConn();

        /// <summary>
        ///     Enables the specified state.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Enable(bool state);

        /// <summary>
        ///     Festoes the press.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int FestoPress();

        /// <summary>
        ///     Gets the press result.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int GetPressResult();

        /// <summary>
        ///     is the prim initialize.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int IPrimInit();

        /// <summary>
        ///     is the prim start.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int IPrimStart();

        /// <summary>
        ///     Jogs the neg.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Jog_Neg(bool state);

        /// <summary>
        ///     Jogs the position.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Jog_Pos(bool state);

        /// <summary>
        ///     Loads the hardware configuration.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Load_Hardware_Config(bool state);

        /// <summary>
        ///     Loads the program.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Load_Program(bool state);

        /// <summary>
        ///     Loggings the sd card.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Logging_SD_Card(bool state);

        /// <summary>
        ///     Loggings the usb.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Logging_USB(bool state);

        /// <summary>
        ///     Manuels the mode.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Manuel_Mode(bool state);

        /// <summary>
        ///     Motions the stop.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int MotionStop();

        /// <summary>
        ///     Moves the specified state.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Move(bool state);

        /// <summary>
        ///     Moves up.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int MoveUp();

        /// <summary>
        ///     Prepares the festo.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int PrepareFesto();

        /// <summary>
        ///     Qiuts the error.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Qiut_Err(bool state);

        /// <summary>
        ///     Res the connection.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ReConn();

        /// <summary>
        ///     Reserveds the specified state.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Reserved(bool state);

        /// <summary>
        ///     Resets the statistic.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Reset_Statistic(bool state);

        /// <summary>
        ///     Resets the festo.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ResetFesto();

        /// <summary>
        ///     Starts the homing.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Start_Homing(bool state);

        /// <summary>
        ///     Starts the press process.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Start_Press_Process(bool state);

        /// <summary>
        ///     Steps the mode.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Step_Mode(bool state);

        /// <summary>
        ///     Stops the move.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Stop_Move(bool state);

        /// <summary>
        ///     Systems the reset.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int System_Reset(bool state);

        /// <summary>
        ///     Tares the specified state.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int Tare(bool state);
    }

    /// <summary>
    ///     Class AcyclicMessage.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class AcyclicMessage
    {
        /// <summary>
        ///     Enum DataTypes
        /// </summary>
        /// <remarks>Lead.CPrim</remarks>
        public enum DataTypes
        {
            dtBOOL = 1,
            dtINT8 = 2,
            dtUINT8 = 3,
            dtINT16 = 4,
            dtUINT16 = 5,
            dtINT32 = 6,
            dtUINT32 = 7,
            dtBYTE = 8,
            dtWORD = 9,
            dtUWORD = 10,
            dtREAL = 11
        }

        /// <summary>
        ///     The BLOB
        /// </summary>
        public byte[] Blob = new byte[22];

        /// <summary>
        ///     Gets or sets the acknowledge.
        /// </summary>
        /// <value>The acknowledge.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte Acknowledge
        {
            get => Blob[9];
            set => Blob[9] = value;
        }

        /// <summary>
        ///     Gets the size of the BLOB.
        /// </summary>
        /// <value>The size of the BLOB.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int BlobSize
        {
            get
            {
                var ret = 0;

                switch (Datentyp)
                {
                    case DataTypes.dtINT32:
                    case DataTypes.dtUINT32:
                    case DataTypes.dtUWORD:
                    case DataTypes.dtREAL:
                        ret = 0x12 + 4;
                        break;

                    case DataTypes.dtINT16:
                    case DataTypes.dtUINT16:
                    case DataTypes.dtWORD:
                        ret = 0x12 + 2;
                        break;

                    case DataTypes.dtINT8:
                    case DataTypes.dtUINT8:
                    case DataTypes.dtBOOL:
                    case DataTypes.dtBYTE:
                        ret = 0x12 + 1;
                        break;
                }

                return ret;
            }
        }

        /// <summary>
        ///     Gets or sets the length of the data.
        /// </summary>
        /// <value>The length of the data.</value>
        /// <remarks>Lead.CPrim</remarks>
        public uint DataLength
        {
            get => BitConverter.ToUInt32(Blob, 5);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[5] = byteArray[0];
                Blob[6] = byteArray[1];
                Blob[7] = byteArray[2];
                Blob[8] = byteArray[3];
            }
        }

        /// <summary>
        ///     Gets or sets the daten.
        /// </summary>
        /// <value>The daten.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte[] Daten
        {
            get
            {
                var byteArray = new byte[4];

                switch (Datentyp)
                {
                    case DataTypes.dtINT32:
                        byteArray[3] = Blob[21];
                        byteArray[2] = Blob[20];
                        byteArray[1] = Blob[19];
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtUINT32:
                        byteArray[3] = Blob[21];
                        byteArray[2] = Blob[20];
                        byteArray[1] = Blob[19];
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtREAL:
                        byteArray[3] = Blob[21];
                        byteArray[2] = Blob[20];
                        byteArray[1] = Blob[19];
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtUWORD:
                        byteArray[3] = Blob[21];
                        byteArray[2] = Blob[20];
                        byteArray[1] = Blob[19];
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtWORD:
                        byteArray[3] = 0;
                        byteArray[2] = 0;
                        byteArray[1] = Blob[19];
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtINT16:
                        byteArray[3] = 0;
                        byteArray[2] = 0;
                        byteArray[1] = Blob[19];
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtUINT16:
                        byteArray[3] = 0;
                        byteArray[2] = 0;
                        byteArray[1] = Blob[19];
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtINT8:
                        byteArray[3] = 0;
                        byteArray[2] = 0;
                        byteArray[1] = 0;
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtUINT8:
                        byteArray[3] = 0;
                        byteArray[2] = 0;
                        byteArray[1] = 0;
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtBOOL:
                        byteArray[3] = 0;
                        byteArray[2] = 0;
                        byteArray[1] = 0;
                        byteArray[0] = Blob[18];
                        break;

                    case DataTypes.dtBYTE:
                        byteArray[3] = 0;
                        byteArray[2] = 0;
                        byteArray[1] = 0;
                        byteArray[0] = Blob[18];
                        break;
                }

                return byteArray;
            }
            set
            {
                switch (Datentyp)
                {
                    case DataTypes.dtINT32:
                        Blob[18] = value[0];
                        Blob[19] = value[1];
                        Blob[20] = value[2];
                        Blob[21] = value[3];
                        break;

                    case DataTypes.dtUINT32:
                        Blob[18] = value[0];
                        Blob[19] = value[1];
                        Blob[20] = value[2];
                        Blob[21] = value[3];
                        break;

                    case DataTypes.dtREAL:
                        Blob[18] = value[0];
                        Blob[19] = value[1];
                        Blob[20] = value[2];
                        Blob[21] = value[3];
                        break;

                    case DataTypes.dtUWORD:
                        Blob[18] = value[0];
                        Blob[19] = value[1];
                        Blob[20] = value[2];
                        Blob[21] = value[3];
                        break;

                    case DataTypes.dtINT16:
                        Blob[18] = value[0];
                        Blob[19] = value[1];
                        Blob[20] = 0;
                        Blob[21] = 0;
                        break;

                    case DataTypes.dtUINT16:
                        Blob[18] = value[0];
                        Blob[19] = value[1];
                        Blob[20] = 0;
                        Blob[21] = 0;
                        break;

                    case DataTypes.dtWORD:
                        Blob[18] = value[0];
                        Blob[19] = value[1];
                        Blob[20] = 0;
                        Blob[21] = 0;
                        break;

                    case DataTypes.dtINT8:
                        Blob[18] = value[0];
                        Blob[19] = 0;
                        Blob[20] = 0;
                        Blob[21] = 0;
                        break;

                    case DataTypes.dtUINT8:
                        Blob[18] = value[0];
                        Blob[19] = 0;
                        Blob[20] = 0;
                        Blob[21] = 0;
                        break;

                    case DataTypes.dtBOOL:
                        Blob[18] = value[0];
                        Blob[19] = 0;
                        Blob[20] = 0;
                        Blob[21] = 0;
                        break;

                    case DataTypes.dtBYTE:
                        Blob[18] = value[0];
                        Blob[19] = 0;
                        Blob[20] = 0;
                        Blob[21] = 0;
                        break;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the datentyp.
        /// </summary>
        /// <value>The datentyp.</value>
        /// <remarks>Lead.CPrim</remarks>
        public DataTypes Datentyp
        {
            get => (DataTypes) Blob[17];
            set => Blob[17] = (byte) value;
        }

        /// <summary>
        ///     Gets or sets the message identifier.
        /// </summary>
        /// <value>The message identifier.</value>
        /// <remarks>Lead.CPrim</remarks>
        public uint MessageID
        {
            get => BitConverter.ToUInt32(Blob, 1);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[1] = byteArray[0];
                Blob[2] = byteArray[1];
                Blob[3] = byteArray[2];
                Blob[4] = byteArray[3];
            }
        }

        /// <summary>
        ///     Gets or sets the index of the object.
        /// </summary>
        /// <value>The index of the object.</value>
        /// <remarks>Lead.CPrim</remarks>
        public ushort ObjectIndex
        {
            get => BitConverter.ToUInt16(Blob, 14);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[14] = byteArray[0];
                Blob[15] = byteArray[1];
            }
        }

        /// <summary>
        ///     Gets or sets the object subindex.
        /// </summary>
        /// <value>The object subindex.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte ObjectSubindex
        {
            get => Blob[16];
            set => Blob[16] = value;
        }

        /// <summary>
        ///     Gets or sets the type of the read.
        /// </summary>
        /// <value>The type of the read.</value>
        /// <remarks>Lead.CPrim</remarks>
        public uint ReadType
        {
            get => BitConverter.ToUInt32(Blob, 10);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[10] = byteArray[0];
                Blob[11] = byteArray[1];
                Blob[12] = byteArray[2];
                Blob[13] = byteArray[3];
            }
        }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte ServiceID
        {
            get => Blob[0];
            set => Blob[0] = value;
        }

        /// <summary>
        ///     Gets the length.
        /// </summary>
        /// <returns>System.UInt32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        public uint GetLength()
        {
            uint ret = 4;

            switch (Datentyp)
            {
                case DataTypes.dtINT32:
                case DataTypes.dtUINT32:
                case DataTypes.dtUWORD:
                case DataTypes.dtREAL:
                    ret = 4;
                    break;

                case DataTypes.dtINT16:
                case DataTypes.dtUINT16:
                case DataTypes.dtWORD:
                    ret = 2;
                    break;

                case DataTypes.dtINT8:
                case DataTypes.dtUINT8:
                case DataTypes.dtBOOL:
                case DataTypes.dtBYTE:
                    ret = 1;
                    break;
            }

            return 4 + ret;
        }
    }

    /// <summary>
    ///     Class CyclicRecieveMessage.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class CyclicRecieveMessage
    {
        /// <summary>
        ///     The BLOB
        /// </summary>
        public byte[] Blob = new byte[48];

        /// <summary>
        ///     Gets the acknowledge.
        /// </summary>
        /// <value>The acknowledge.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte Acknowledge => Blob[3];

        /// <summary>
        ///     Gets the actual force.
        /// </summary>
        /// <value>The actual force.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int ActualForce => BitConverter.ToInt32(Blob, 30);

        /// <summary>
        ///     Gets the actual position.
        /// </summary>
        /// <value>The actual position.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int ActualPosition => BitConverter.ToInt32(Blob, 26);

        /// <summary>
        ///     Gets the actual velocity.
        /// </summary>
        /// <value>The actual velocity.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int ActualVelocity => BitConverter.ToInt32(Blob, 34);

        /// <summary>
        ///     Gets the communication mode.
        /// </summary>
        /// <value>The communication mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte CommunicationMode => Blob[9];

        /// <summary>
        ///     Gets the length of the data.
        /// </summary>
        /// <value>The length of the data.</value>
        /// <remarks>Lead.CPrim</remarks>
        public ushort DataLength => BitConverter.ToUInt16(Blob, 1);

        /// <summary>
        ///     Gets the digital outputs.
        /// </summary>
        /// <value>The digital outputs.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte DigitalOutputs => Blob[25];

        /// <summary>
        ///     Gets the maxinum force.
        /// </summary>
        /// <value>The maxinum force.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int MaxinumForce => BitConverter.ToInt32(Blob, 42);

        /// <summary>
        ///     Gets the maxinum position.
        /// </summary>
        /// <value>The maxinum position.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int MaxinumPosition => BitConverter.ToInt32(Blob, 38);

        /// <summary>
        ///     Gets the message identifier.
        /// </summary>
        /// <value>The message identifier.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte MessageID => Blob[4];

        /// <summary>
        ///     Gets the motion mode.
        /// </summary>
        /// <value>The motion mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte MotionMode => Blob[14];

        /// <summary>
        ///     Gets the motion position.
        /// </summary>
        /// <value>The motion position.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int MotionPosition => BitConverter.ToInt32(Blob, 19);

        /// <summary>
        ///     Gets the motion velocity.
        /// </summary>
        /// <value>The motion velocity.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int MotionVelocity => BitConverter.ToInt32(Blob, 15);

        /// <summary>
        ///     Gets the nok reason.
        /// </summary>
        /// <value>The nok reason.</value>
        /// <remarks>Lead.CPrim</remarks>
        public ushort NOKReason => BitConverter.ToUInt16(Blob, 46);

        /// <summary>
        ///     Gets the offset force sensor.
        /// </summary>
        /// <value>The offset force sensor.</value>
        /// <remarks>Lead.CPrim</remarks>
        public uint OffsetForceSensor => BitConverter.ToUInt32(Blob, 10);

        /// <summary>
        ///     Gets the problem selection.
        /// </summary>
        /// <value>The problem selection.</value>
        /// <remarks>Lead.CPrim</remarks>
        public ushort ProblemSelection => BitConverter.ToUInt16(Blob, 23);

        /// <summary>
        ///     Gets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte ServiceID => Blob[0];

        /// <summary>
        ///     Gets the status word.
        /// </summary>
        /// <value>The status word.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int StatusWord => BitConverter.ToInt32(Blob, 5);
    }

    /// <summary>
    ///     Class CyclicSendMessage.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class CyclicSendMessage
    {
        /// <summary>
        ///     The BLOB
        /// </summary>
        public byte[] Blob = new byte[26];

        /// <summary>
        ///     Gets or sets the acknowledge.
        /// </summary>
        /// <value>The acknowledge.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte Acknowledge
        {
            get => Blob[3];
            set => Blob[3] = value;
        }

        /// <summary>
        ///     Gets or sets the communication mode.
        /// </summary>
        /// <value>The communication mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte CommunicationMode
        {
            get => Blob[9];
            set => Blob[9] = value;
        }

        /// <summary>
        ///     Gets or sets the control word.
        /// </summary>
        /// <value>The control word.</value>
        /// <remarks>Lead.CPrim</remarks>
        public uint ControlWord
        {
            get => BitConverter.ToUInt32(Blob, 5);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[5] = byteArray[0];
                Blob[6] = byteArray[1];
                Blob[7] = byteArray[2];
                Blob[8] = byteArray[3];
            }
        }

        /// <summary>
        ///     Gets or sets the length of the data.
        /// </summary>
        /// <value>The length of the data.</value>
        /// <remarks>Lead.CPrim</remarks>
        public ushort DataLength
        {
            get => BitConverter.ToUInt16(Blob, 1);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[1] = byteArray[0];
                Blob[2] = byteArray[1];
            }
        }

        /// <summary>
        ///     Gets or sets the digital inputs.
        /// </summary>
        /// <value>The digital inputs.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte DigitalInputs
        {
            get => Blob[25];
            set => Blob[25] = value;
        }

        /// <summary>
        ///     Gets or sets the message identifier.
        /// </summary>
        /// <value>The message identifier.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte MessageID
        {
            get => Blob[4];
            set => Blob[4] = value;
        }

        /// <summary>
        ///     Gets or sets the motion mode.
        /// </summary>
        /// <value>The motion mode.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte MotionMode
        {
            get => Blob[14];
            set => Blob[14] = value;
        }

        /// <summary>
        ///     Gets or sets the motion position.
        /// </summary>
        /// <value>The motion position.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int MotionPosition
        {
            get => BitConverter.ToInt32(Blob, 19);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[19] = byteArray[0];
                Blob[20] = byteArray[1];
                Blob[21] = byteArray[2];
                Blob[22] = byteArray[3];
            }
        }

        /// <summary>
        ///     Gets or sets the motion velocity.
        /// </summary>
        /// <value>The motion velocity.</value>
        /// <remarks>Lead.CPrim</remarks>
        public int MotionVelocity
        {
            get => BitConverter.ToInt32(Blob, 15);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[15] = byteArray[0];
                Blob[16] = byteArray[1];
                Blob[17] = byteArray[2];
                Blob[18] = byteArray[3];
            }
        }

        /// <summary>
        ///     Gets or sets the offset force sensor.
        /// </summary>
        /// <value>The offset force sensor.</value>
        /// <remarks>Lead.CPrim</remarks>
        public uint OffsetForceSensor
        {
            get => BitConverter.ToUInt32(Blob, 10);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[10] = byteArray[0];
                Blob[11] = byteArray[1];
                Blob[12] = byteArray[2];
                Blob[13] = byteArray[3];
            }
        }

        /// <summary>
        ///     Gets or sets the problem selection.
        /// </summary>
        /// <value>The problem selection.</value>
        /// <remarks>Lead.CPrim</remarks>
        public ushort ProblemSelection
        {
            get => BitConverter.ToUInt16(Blob, 23);
            set
            {
                var byteArray = BitConverter.GetBytes(value);
                Blob[23] = byteArray[0];
                Blob[24] = byteArray[1];
            }
        }

        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        /// <remarks>Lead.CPrim</remarks>
        public byte ServiceID
        {
            get => Blob[0];
            set => Blob[0] = value;
        }
    }

    /// <summary>
    ///     Class FestoStatus.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class FestoStatus
    {
        /// <summary>
        ///     The act force
        /// </summary>
        public int ActForce;

        /// <summary>
        ///     The act position
        /// </summary>
        public int ActPosition;

        /// <summary>
        ///     The act speed
        /// </summary>
        public int ActSpeed;

        /// <summary>
        ///     The change mode
        /// </summary>
        public bool ChangeMode;

        /// <summary>
        ///     The command position
        /// </summary>
        public int CmdPosition;

        /// <summary>
        ///     The command speed
        /// </summary>
        public int CmdSpeed;

        /// <summary>
        ///     The cw abort press
        /// </summary>
        public bool CW_AbortPress;

        /// <summary>
        ///     The cw auot mode
        /// </summary>
        public bool CW_AuotMode;

        /// <summary>
        ///     The cw enable press
        /// </summary>
        public bool CW_EnablePress;

        /// <summary>
        ///     The cw jog n
        /// </summary>
        public bool CW_JogN;

        /// <summary>
        ///     The cw jog p
        /// </summary>
        public bool CW_JogP;

        /// <summary>
        ///     The cw load hw configuration
        /// </summary>
        public bool CW_LoadHWConfig;

        /// <summary>
        ///     The cw load program
        /// </summary>
        public bool CW_LoadProgram;

        /// <summary>
        ///     The cw logging sd card
        /// </summary>
        public bool CW_LoggingSD_Card;

        /// <summary>
        ///     The cw logging usb
        /// </summary>
        public bool CW_LoggingUSB;

        /// <summary>
        ///     The cw manual mode
        /// </summary>
        public bool CW_ManualMode;

        /// <summary>
        ///     The cw move
        /// </summary>
        public bool CW_Move;

        /// <summary>
        ///     The cw quit error
        /// </summary>
        public bool CW_QuitError;

        /// <summary>
        ///     The cw reset statistic
        /// </summary>
        public bool CW_ResetStatistic;

        /// <summary>
        ///     The cw start homing
        /// </summary>
        public bool CW_StartHoming;

        /// <summary>
        ///     The cw start press
        /// </summary>
        public bool CW_StartPress;

        /// <summary>
        ///     The cw step mode
        /// </summary>
        public bool CW_StepMode;

        /// <summary>
        ///     The cw stop move
        /// </summary>
        public bool CW_StopMove;

        /// <summary>
        ///     The cw system reset
        /// </summary>
        public bool CW_SystemReset;

        /// <summary>
        ///     The cw tare
        /// </summary>
        public bool CW_Tare;

        /// <summary>
        ///     The cycle
        /// </summary>
        public bool Cycle;

        /// <summary>
        ///     The input1
        /// </summary>
        public bool Input1;

        /// <summary>
        ///     The input2
        /// </summary>
        public bool Input2;

        /// <summary>
        ///     The input3
        /// </summary>
        public bool Input3;

        /// <summary>
        ///     The input4
        /// </summary>
        public bool Input4;

        /// <summary>
        ///     The input5
        /// </summary>
        public bool Input5;

        /// <summary>
        ///     The input6
        /// </summary>
        public bool Input6;

        /// <summary>
        ///     The input7
        /// </summary>
        public bool Input7;

        /// <summary>
        ///     The input8
        /// </summary>
        public bool Input8;

        /// <summary>
        ///     The maximum force
        /// </summary>
        public int MaxForce;

        /// <summary>
        ///     The maximum position
        /// </summary>
        public int MaxPosition;

        /// <summary>
        ///     The motion mode
        /// </summary>
        public byte MotionMode;

        /// <summary>
        ///     The no ok reason
        /// </summary>
        public ushort NoOKReason;

        /// <summary>
        ///     The offset force
        /// </summary>
        public int OffsetForce;

        /// <summary>
        ///     The output1
        /// </summary>
        public bool Output1;

        /// <summary>
        ///     The output2
        /// </summary>
        public bool Output2;

        /// <summary>
        ///     The output3
        /// </summary>
        public bool Output3;

        /// <summary>
        ///     The output4
        /// </summary>
        public bool Output4;

        /// <summary>
        ///     The output5
        /// </summary>
        public bool Output5;

        /// <summary>
        ///     The output6
        /// </summary>
        public bool Output6;

        /// <summary>
        ///     The output7
        /// </summary>
        public bool Output7;

        /// <summary>
        ///     The output8
        /// </summary>
        public bool Output8;

        /// <summary>
        ///     The program select
        /// </summary>
        public ushort ProgramSelect;

        /// <summary>
        ///     The selected program
        /// </summary>
        public ushort SelectedProgram;

        /// <summary>
        ///     The sw automatic mode
        /// </summary>
        public bool SW_AutoMode;

        /// <summary>
        ///     The sw error
        /// </summary>
        public bool SW_Error;

        /// <summary>
        ///     The sw homing required
        /// </summary>
        public bool SW_HomingRequired;

        /// <summary>
        ///     The sw hw configuration
        /// </summary>
        public bool SW_HWConfig;

        /// <summary>
        ///     The sw in operation
        /// </summary>
        public bool SW_InOperation;

        /// <summary>
        ///     The sw logging sd card
        /// </summary>
        public bool SW_LoggingSD_Card;

        /// <summary>
        ///     The sw logging usb
        /// </summary>
        public bool SW_LoggingUSB;

        /// <summary>
        ///     The sw manual mode
        /// </summary>
        public bool SW_ManualMode;

        /// <summary>
        ///     The sw no ok
        /// </summary>
        public bool SW_NoOK;

        /// <summary>
        ///     The sw ok
        /// </summary>
        public bool SW_OK;

        /// <summary>
        ///     The sw pragram loaded
        /// </summary>
        public bool SW_PragramLoaded;

        /// <summary>
        ///     The sw press enabled
        /// </summary>
        public bool SW_PressEnabled;

        /// <summary>
        ///     The sw ready
        /// </summary>
        public bool SW_Ready;

        /// <summary>
        ///     The sw safety
        /// </summary>
        public bool SW_Safety;

        /// <summary>
        ///     The sw servo ready
        /// </summary>
        public bool SW_ServoReady;

        /// <summary>
        ///     The sw step done
        /// </summary>
        public bool SW_StepDone;

        /// <summary>
        ///     The sw step mode
        /// </summary>
        public bool SW_StepMode;

        /// <summary>
        ///     The sw tared
        /// </summary>
        public bool SW_Tared;

        /// <summary>
        ///     The sw warning
        /// </summary>
        public bool SW_Warning;
    }

    /// <summary>
    ///     Class PrimFesto_CyClicObject.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class PrimFesto_CyClicObject
    {
        /// <summary>
        ///     The acknowledge identifier
        /// </summary>
        public byte AcknowledgeID;

        /// <summary>
        ///     The actual force
        /// </summary>
        public int ActualForce;

        /// <summary>
        ///     The actual position
        /// </summary>
        public int ActualPosition;

        /// <summary>
        ///     The actual velocity
        /// </summary>
        public int ActualVelocity;

        /// <summary>
        ///     The communication mode
        /// </summary>
        public byte CommunicationMode;

        /// <summary>
        ///     The control word
        /// </summary>
        public uint ControlWord;

        /// <summary>
        ///     The data length
        /// </summary>
        public ushort DataLength;

        /// <summary>
        ///     The digital outputs
        /// </summary>
        public byte DigitalOutputs;

        /// <summary>
        ///     The maxinum force
        /// </summary>
        public int MaxinumForce;

        /// <summary>
        ///     The maxinum position
        /// </summary>
        public int MaxinumPosition;

        /// <summary>
        ///     The motion mode
        /// </summary>
        public byte MotionMode;

        /// <summary>
        ///     The motion position
        /// </summary>
        public int MotionPosition;

        /// <summary>
        ///     The motion velocity
        /// </summary>
        public int MotionVelocity;

        /// <summary>
        ///     The nok reason
        /// </summary>
        public ushort NOKReason;

        /// <summary>
        ///     The offset force sensor
        /// </summary>
        public uint OffsetForceSensor;

        /// <summary>
        ///     The problem selection
        /// </summary>
        public ushort ProblemSelection;

        /// <summary>
        ///     The status word
        /// </summary>
        public int StatusWord;

        /// <summary>
        ///     The updatetime
        /// </summary>
        public string Updatetime;

        /// <summary>
        ///     Sends the specified motion m.
        /// </summary>
        /// <param name="MotionM">The motion m.</param>
        /// <param name="ControlW">The control w.</param>
        /// <param name="offSensor1">The off sensor1.</param>
        /// <param name="problemsel">The problemsel.</param>
        /// <param name="DigitalInput">The digital input.</param>
        /// <param name="MotionPos">The motion position.</param>
        /// <param name="MotionVel">The motion vel.</param>
        /// <param name="stream">The stream.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        public int Send(byte MotionM, uint ControlW, uint offSensor1, ushort problemsel, byte DigitalInput,
            int MotionPos, int MotionVel, ref NetworkStream stream)
        {
            var SendM = new CyclicSendMessage();
            var ReciM = new CyclicRecieveMessage();

            SendM.ServiceID = 0x12;
            SendM.MessageID = 0x00;
            SendM.DataLength = 21;
            SendM.Acknowledge = 0x00;
            SendM.MessageID = 0x00;
            SendM.ControlWord = ControlW;
            SendM.CommunicationMode = 0x01;
            SendM.OffsetForceSensor = offSensor1;
            SendM.ProblemSelection = problemsel;
            SendM.MotionMode = MotionM;
            SendM.MotionPosition = MotionPos;
            SendM.MotionVelocity = MotionVel;
            SendM.DigitalInputs = DigitalInput;

            try
            {
                lock (stream)
                {
                    stream.Write(SendM.Blob, 0, SendM.Blob.Length);
                    stream.Read(ReciM.Blob, 0, ReciM.Blob.Length);
                    Updatetime = ControlW + "-" + DateTime.Now.ToString("HH:mm:ss");
                }

                StatusWord = ReciM.StatusWord;
                ActualForce = ReciM.ActualForce;
                ActualPosition = ReciM.ActualPosition;
                ActualVelocity = ReciM.ActualVelocity;
                DigitalOutputs = ReciM.DigitalOutputs;
                MaxinumForce = ReciM.MaxinumForce;
                MaxinumPosition = ReciM.MaxinumPosition;
                OffsetForceSensor = ReciM.OffsetForceSensor;
                ProblemSelection = ReciM.ProblemSelection;
                MotionPosition = ReciM.MotionPosition;
                MotionVelocity = ReciM.MotionVelocity;
                NOKReason = ReciM.NOKReason;
                AcknowledgeID = ReciM.Acknowledge;
                DataLength = ReciM.DataLength;
                CommunicationMode = ReciM.CommunicationMode;
            }
            catch (Exception)
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        ///     Send1s the specified motion m.
        /// </summary>
        /// <param name="MotionM">The motion m.</param>
        /// <param name="ControlW">The control w.</param>
        /// <param name="offSensor1">The off sensor1.</param>
        /// <param name="problemsel">The problemsel.</param>
        /// <param name="DigitalInput">The digital input.</param>
        /// <param name="MotionPos">The motion position.</param>
        /// <param name="MotionVel">The motion vel.</param>
        /// <param name="stream">The stream.</param>
        /// <remarks>Lead.CPrim</remarks>
        public void Send1(byte MotionM, uint ControlW, uint offSensor1, ushort problemsel, byte DigitalInput,
            int MotionPos, int MotionVel, ref NetworkStream stream)
        {
            var SendM = new CyclicSendMessage();
            var ReciM = new CyclicRecieveMessage();

            SendM.ServiceID = 0x12;
            SendM.MessageID = 0x00;
            SendM.DataLength = 21;
            SendM.Acknowledge = 0x00;
            SendM.MessageID = 0x00;
            SendM.ControlWord = ControlW;
            SendM.CommunicationMode = 0x01;
            SendM.OffsetForceSensor = offSensor1;
            SendM.ProblemSelection = problemsel;
            SendM.MotionMode = MotionM;
            SendM.MotionPosition = MotionPos;
            SendM.MotionVelocity = MotionVel;
            SendM.DigitalInputs = DigitalInput;

            try
            {
                lock (stream)
                {
                    stream.Write(SendM.Blob, 0, SendM.Blob.Length);
                    stream.Read(ReciM.Blob, 0, ReciM.Blob.Length);
                    Updatetime = ControlW + "-" + DateTime.Now.ToString("HH:mm:ss");
                }

                StatusWord = ReciM.StatusWord;
                ActualForce = ReciM.ActualForce;
                ActualPosition = ReciM.ActualPosition;
                ActualVelocity = ReciM.ActualVelocity;
                DigitalOutputs = ReciM.DigitalOutputs;
                MaxinumForce = ReciM.MaxinumForce;
                MaxinumPosition = ReciM.MaxinumPosition;
                OffsetForceSensor = ReciM.OffsetForceSensor;
                ProblemSelection = ReciM.ProblemSelection;
                MotionPosition = ReciM.MotionPosition;
                MotionVelocity = ReciM.MotionVelocity;
                NOKReason = ReciM.NOKReason;
                AcknowledgeID = ReciM.Acknowledge;
                DataLength = ReciM.DataLength;
                CommunicationMode = ReciM.CommunicationMode;
            }
            catch (Exception)
            {
            }
        }
    }

    /// <summary>
    ///     Class PrimFesto_Object.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class PrimFesto_Object
    {
        /// <summary>
        ///     The data type
        /// </summary>
        public AcyclicMessage.DataTypes DataType;

        /// <summary>
        ///     The index
        /// </summary>
        public ushort index;

        /// <summary>
        ///     The subindex
        /// </summary>
        public ushort subindex;

        /// <summary>
        ///     The value
        /// </summary>
        public int value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrimFesto_Object" /> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="subindex">The subindex.</param>
        /// <param name="DataType">Type of the data.</param>
        /// <remarks>Lead.CPrim</remarks>
        public PrimFesto_Object(ushort index, ushort subindex, AcyclicMessage.DataTypes DataType)
        {
            this.index = index;
            this.subindex = subindex;
            this.DataType = DataType;
        }

        /// <summary>
        ///     Reads the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <remarks>Lead.CPrim</remarks>
        public void Read(ref NetworkStream stream)
        {
            var M = new AcyclicMessage();

            M.ServiceID = 0x10;
            M.ObjectIndex = index;
            M.ObjectSubindex = (byte) subindex;
            M.Datentyp = DataType;
            M.DataLength = 4;
            lock (stream)
            {
                stream.Write(M.Blob, 0, 0x12);
                stream.Read(M.Blob, 0, 0x12 + (int) M.GetLength() - 4);
            }

            value = M.Daten[0] | (M.Daten[1] << 8) | (M.Daten[2] << 16) | (M.Daten[3] << 24);
        }

        /// <summary>
        ///     Sends the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="stream">The stream.</param>
        /// <remarks>Lead.CPrim</remarks>
        public void Send(int value, ref NetworkStream stream)
        {
            var M = new AcyclicMessage();

            M.ServiceID = 0x11;
            M.ObjectIndex = index;
            M.ObjectSubindex = (byte) subindex;
            M.Datentyp = DataType;
            M.DataLength = M.GetLength();
            M.Daten = BitConverter.GetBytes(value);

            lock (stream)
            {
                stream.Write(M.Blob, 0, 0x12 + (int) M.GetLength() - 4);
                stream.Read(M.Blob, 0, 0x12);
            }

            this.value = value;
        }
    }
}