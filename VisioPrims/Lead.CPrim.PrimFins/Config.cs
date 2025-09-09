/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PrimFinsConfig.cs
 * Author: Victor
 * Description: 欧姆龙Fins通讯本地配置管理类，负责数据存储
 * CreateTime: 2022-09-21
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0904><Victor><20220921>
 * 1、初版1.0
******************************************************************************/

using System;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Dev;

namespace Lead.CPrim.PrimFinsNet
{
    /// <summary>本地配置管理类</summary>
    public class Config
    {
        public Config()
        {
            IP = "192.168.250.100";
            Port = "9600";
            SA1 = "0";
            DA1 = "100";
            DA2 = "0";
            CycleTime = 10;
            ReconnectCnt = 3;
            DataTablePath = "";
            FinsTypeSelect = FinsType.FinsNet;
            NotifyMode = SktNotifyMode.DataEvent;
            LogEnable = true;
        }



        #region Define_Prop
        /// <summary>Ip</summary>
        public string IP { set; get; }

        /// <summary>Port</summary>
        public string Port { set; get; }

        /// <summary>上位机的节点地址，假如你的电脑的Ip地址为192.168.0.13，那么这个值就是13</summary>
        public string SA1 { set; get; }

        /// <summary>PLC的节点地址，这个值在配置了ip地址之后是默认赋值的，默认为Ip地址的最后一位</summary>
        public string DA1 { set; get; }

        /// <summary>PLC的单元号地址，通常都为0</summary>
        public string DA2 { set; get; }

        /// <summary>循环时间</summary>
        public int CycleTime { set; get; }

        /// <summary>重连次数</summary>
        public int ReconnectCnt { set; get; }

        /// <summary>数据表地址</summary>
        public string DataTablePath { set; get; }

        /// <summary>Fins类型</summary>
        public FinsType FinsTypeSelect { set; get; }

        /// <summary>通知模式</summary>
        public SktNotifyMode NotifyMode { set; get; }

        /// <summary>日志开启</summary>
        public bool LogEnable { set; get; } = true;

        /// <summary>读起始地址</summary>
        public string ReadStartAddress { get; set; }

        /// <summary>读长度</summary>
        public ushort ReadLength { get; set; }

        /// <summary>写起始地址</summary>
        public string WriteStartAddress { get; set; }

        /// <summary>写长度</summary>
        public ushort WriteLength { get; set; }
        #endregion



        #region Override IPrim
        public Guid Id { set; get; }
        public string Name { set; get; }
        public bool PrimEnable { set; get; }
        public string PrimTypeName { set; get; }
        public int CurrentImageIndex { get; set; }
        #endregion
    }
}