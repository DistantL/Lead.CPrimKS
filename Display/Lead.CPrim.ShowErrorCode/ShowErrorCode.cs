using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ShowErrorCode.Controls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Lead.CPrim.ShowErrorCode
{
    /// <summary>ErrorCode管理器</summary>
    public class ShowErrorCode : IShow, IErrorCode
    {
        #region Field
        /// <summary>ErrorCode配置管理器</summary>
        private ErrorCodeConfig _config;
        /// <summary>ErrorCode目录</summary>
        private string errorCodePath = $@"D:\CPrimlog\ErrorCode\";
        /// <summary>报警列表（用于查询）</summary>
        private List<Errorthirdmsg> Errorlist = new List<Errorthirdmsg>();
        /// <summary>报警明细（用于UI显示）</summary>
        public List<ErrcodeInfor> lerrcodeInfor = new List<ErrcodeInfor>();
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ShowErrorCode()
        {
            _config = new ErrorCodeConfig();
            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);
        }
        /// <summary>Ctor有1个参数</summary>
        /// <param name="xmlNode"></param>
        public ShowErrorCode(XmlNode xmlNode)
        {
            if (xmlNode == null)
            {
                _config = new ErrorCodeConfig();
            }
            else
            {
                _config = XMLHelper.XMLToObject(xmlNode, typeof(ErrorCodeConfig)) as ErrorCodeConfig;
            }

            ConfigUi = new ShowConfigControl(this);
            OutputUi = new ShowOutputControl(this);
        }
        #endregion



        #region Prop
        public string StationCode { get => _config.StationCode; set => _config.StationCode = value; }
        public string ModuleCode { get => _config.ModuleCode; set => _config.ModuleCode = value; }
        public string ModuleNameEn { get => _config.ModuleNameEn; set => _config.ModuleNameEn = value; }
        public string ModuleNameCn { get => _config.ModuleNameCn; set => _config.ModuleNameCn = value; }
        public BindingList<ErrorCodeInput> LErrorCodeInput { get => _config.LErrorCodeInput; set => _config.LErrorCodeInput = value; }
        #endregion



        #region Override IShow
        public Guid Id { set => _config.Id = value; get => _config.Id; }
        public string Name { set => _config.Name = value; get => _config.Name; }
        public string ShowTypeName { set => _config.ShowTypeName = value; get => _config.ShowTypeName; }
        public bool Enable { set => _config.Enable = value; get => _config.Enable; }
        public string Version { set => _config.Version = value; get => _config.Version; }
        public Control ConfigUi { get; }
        public Control OutputUi { get; }
        public int IShowDispose()
        {
            var iRet = 0;
            return iRet;
        }
        public XmlNode IShowExportConfigXml()
        {
            if (_config == null) return null;
            return ProxyTools.XMLHelper.ObjectToXML(_config);
        }
        public int IShowImportConfigXml(XmlNode xmlNode)
        {
            if (xmlNode == null) return -1;
            _config = ProxyTools.XMLHelper.XMLToObject(xmlNode, typeof(ErrorCodeConfig)) as ErrorCodeConfig;
            return _config == null ? -1 : 0;
        }
        #endregion



        #region Override IErrorCode
        private List<ErrorCodes> _listErrorCodes = new List<ErrorCodes>();

        
        public string ErrorCodeCurrent { get; private set; }
        public ConcurrentDictionary<string, string> DicErrorCode { get; private set; }

        public int ErrorCodeOutput(bool save)
        {
            int iRet = 0;
            lerrcodeInfor = new List<ErrcodeInfor>();
            Errorlist = new List<Errorthirdmsg>();
            if (Directory.Exists(errorCodePath))
            {
                foreach (var item in Directory.GetFiles(errorCodePath, "*.csv"))
                {
                    File.Delete(item);
                }
            }

            #region 元件
            List<IEle> listEle = ElesManagerTransfer.GetAllIEle();
            List<IEle> lDI = listEle.FindAll(e => e.EleTypeName == "DI");
            List<IEle> lCylinder = listEle.FindAll(e => e.EleTypeName == "CylinderLine" && ((IEleCyldLine)e).CyldType == EleCyldType.Cylinder);
            List<IEle> lVacuum = listEle.FindAll(e => e.EleTypeName == "CylinderLine" && ((IEleCyldLine)e).CyldType == EleCyldType.Vacuum);
            List<IEle> lEleCartesian = listEle.FindAll(e => e.EleTypeName == "Cartesian");
            #endregion

            #region 信号
            {
                int diIndex = 1;
                foreach (var item in lDI)
                {
                    foreach (string type in Enum.GetNames(typeof(AlarmTpyes.信号报警)))
                    {
                        SetErrorCode(type, ErrorLevelsecond.其他传感器.ToString(), typeof(AlarmTpyes.信号报警), item.Name, diIndex);
                    }
                    diIndex++;
                }
            }
            #endregion

            #region 气缸
            {
                int cylinderIndex = 1;
                foreach (var item in lCylinder)
                {
                    foreach (string type in Enum.GetNames(typeof(AlarmTpyes.气缸报警)))
                    {
                        SetErrorCode(type, ErrorLevelsecond.气动.ToString(), typeof(AlarmTpyes.气缸报警), item.Name, cylinderIndex);
                    }
                    cylinderIndex++;
                }
            }
            #endregion

            #region 真空
            {
                int vacuumIndex = 1;
                foreach (var item in lVacuum)
                {
                    foreach (string type in Enum.GetNames(typeof(AlarmTpyes.真空报警)))
                    {
                        SetErrorCode(type, ErrorLevelsecond.气动.ToString(), typeof(AlarmTpyes.真空报警), item.Name, vacuumIndex);
                    }
                    vacuumIndex++;
                }
            }
            #endregion

            #region 视觉
            {
                int visionIndex = 1;
                foreach (var item in Enum.GetNames(typeof(相机)))
                {
                    foreach (string type in Enum.GetNames(typeof(AlarmTpyes.视觉报警)))
                    {
                        SetErrorCode(type, ErrorLevelsecond.视觉.ToString(), typeof(AlarmTpyes.视觉报警), item + type, visionIndex);
                    }
                    visionIndex++;
                }
            }
            #endregion

            #region 设备状态
            {
                foreach (string type in Enum.GetNames(typeof(AlarmTpyes.设备状态)))
                {
                    SetErrorCode(type, type, typeof(AlarmTpyes.设备状态));
                }
            }
            #endregion

            #region 维修保养
            {
                foreach (string type in Enum.GetNames(typeof(AlarmTpyes.维修保养)))
                {
                    SetErrorCode(type, ErrorLevelsecond.维护保养.ToString(), typeof(AlarmTpyes.维修保养));
                }
            }
            #endregion

            #region 轴
            {
                int axisIndex = 1;
                foreach (var item in lEleCartesian)
                {
                    if (((IEleCartesian)item).AxisXIndex != -1)
                    {
                        foreach (var type in Enum.GetNames(typeof(AlarmTpyes.轴报警)))
                        {
                            SetErrorCode(type, ErrorLevelsecond.X轴.ToString(), typeof(AlarmTpyes.轴报警), item.Name + ErrorLevelsecond.X轴, axisIndex);
                        }
                    }
                    if (((IEleCartesian)item).AxisYIndex != -1)
                    {
                        foreach (var type in Enum.GetNames(typeof(AlarmTpyes.轴报警)))
                        {
                            SetErrorCode(type, ErrorLevelsecond.Y轴.ToString(), typeof(AlarmTpyes.轴报警), item.Name + ErrorLevelsecond.Y轴, axisIndex);
                        }
                    }
                    if (((IEleCartesian)item).AxisZIndex != -1)
                    {
                        foreach (var type in Enum.GetNames(typeof(AlarmTpyes.轴报警)))
                        {
                            SetErrorCode(type, ErrorLevelsecond.Z轴.ToString(), typeof(AlarmTpyes.轴报警), item.Name + ErrorLevelsecond.Z轴, axisIndex);
                        }
                    }
                    if (((IEleCartesian)item).AxisUIndex != -1)
                    {
                        foreach (var type in Enum.GetNames(typeof(AlarmTpyes.轴报警)))
                        {
                            SetErrorCode(type, ErrorLevelsecond.其他轴.ToString(), typeof(AlarmTpyes.轴报警), item.Name + "U轴", axisIndex);
                        }
                    }
                    if (((IEleCartesian)item).AxisVIndex != -1)
                    {
                        foreach (var type in Enum.GetNames(typeof(AlarmTpyes.轴报警)))
                        {
                            SetErrorCode(type, ErrorLevelsecond.其他轴.ToString(), typeof(AlarmTpyes.轴报警), item.Name + "V轴", axisIndex);
                        }
                    }
                    if (((IEleCartesian)item).AxisWIndex != -1)
                    {
                        foreach (var type in Enum.GetNames(typeof(AlarmTpyes.轴报警)))
                        {
                            SetErrorCode(type, ErrorLevelsecond.其他轴.ToString(), typeof(AlarmTpyes.轴报警), item.Name + "W轴", axisIndex);
                        }
                    }
                    axisIndex++;
                }
            }
            #endregion

            #region 轴组
            {
                int cartesianIndex = 1;
                foreach (var item in lEleCartesian)
                {
                    foreach (string type in Enum.GetNames(typeof(AlarmTpyes.轴组报警)))
                    {
                        SetErrorCode(type, ErrorLevelsecond.其他轴.ToString(), typeof(AlarmTpyes.轴组报警), item.Name, cartesianIndex);
                    }
                    cartesianIndex++;
                }
            }
            #endregion
            return iRet;
        }
        public List<ErrorCodes> ErrorCodeMsg(string msg)
        {
            Errorthirdmsg errorthird = Errorlist.FirstOrDefault(e => msg.Contains(e.third_level_name_cn));
            ErrorCodeCurrent = errorthird == null ? null : errorthird.error_codes;
            if(ErrorCodeCurrent == null)
            {
                return null;
            }

            ErrorCodes error = new ErrorCodes()
            {
                ErrorName = errorthird.third_level_name_cn,
                ErrorCode = ErrorCodeCurrent,
                CreateTime = DateTime.Now,
            };

            _listErrorCodes.Add(error);
            return _listErrorCodes;
        }
        public void ErrorCodeClear()
        {
            if(DicErrorCode == null)
            {
                DicErrorCode = new ConcurrentDictionary<string, string>();
                return;
            }
            DicErrorCode.Clear();
        }
        #endregion



        #region Method_ExtendUsing
        public void InsertMongoDB()
        {
            //if(Errorlist == null || Errorlist.Count == 0)
            //{
            //    ErrorCodeOutput(false);
            //}

            //Random rd = new Random();
            //int max = Errorlist.Count;
            //for (int i = 0; i < 20; i++)
            //{
            //    int rdInt = rd.Next(0, max);
            //    Errorthirdmsg errcode = Errorlist[rdInt];
            //    ErrorCodes errorCode = new ErrorCodes()
            //    {
            //        CreateTime = DateTime.Now.AddMilliseconds(i),
            //        EndTime = DateTime.Now.AddMinutes(i).AddSeconds(10),
            //        ErrorName = errcode.third_level_name_cn,
            //        ErrorCode = errcode.error_codes,
            //        ErrorTime = rdInt * rdInt,
            //    };

            //    _ = MongodbHelper.InsertOneAsync(errorCode, UIGlobal.ErrorCodeDb);
            //}
        }
        #endregion



        #region Others
        /// <summary>生成ErrorCode</summary>
        /// <param name="type"></param>
        /// <param name="second_level_name_cn"></param>
        /// <param name="e"></param>
        /// <param name="name"></param>
        /// <param name="third_level_code"></param>
        private void SetErrorCode(string type, string second_level_name_cn, Type e, string name = null, int third_level_code = 0)
        {
            //三级报警
            ErrcodeInfor errcodeInfor = new ErrcodeInfor();
            errcodeInfor.station_code = StationCode;
            errcodeInfor.module_code = ModuleCode;
            errcodeInfor.module_name_en = ModuleNameEn;
            errcodeInfor.module_name_cn = ModuleNameCn;
            int Numtype = Convert.ToInt16(Enum.Parse(e, type));
            errcodeInfor.third_level_code = third_level_code == 0 ? Numtype.ToString("000") : third_level_code.ToString("00" + Numtype.ToString());
            errcodeInfor.third_level_name_cn = name == null ? type : name + type;

            //二级报警自定义
            errcodeInfor.second_level_name_cn = second_level_name_cn;
            lerrcodeInfor.Add(errcodeInfor);

            //Errorcode List 用于报警映射
            Errorlist.Add(new Errorthirdmsg() { error_codes = errcodeInfor.error_codes, third_level_name_cn = errcodeInfor.third_level_name_cn });
        }
        #endregion
    }

    #region 报警(ErrorCode)结构定义
    public class ErrcodeInfor
    {
        #region Field
        /// <summary>ErrorCode</summary>
        private string _error_codes;
        /// <summary>模块总编号（厂商编号+工站编号+模块编号）</summary>
        private string _module_codes;
        #endregion



        #region Prop
        /// <summary>厂商</summary>
        public string vendor_name { get; set; } = "Lead";
        /// <summary>厂商编号</summary>
        public string vendor_code { get; set; } = "3";

        /// <summary>一级报警代码</summary>
        public string first_level_code { get => ReturnFirstLevelCode(second_level_name_cn); }
        /// <summary>一级报警英文名称</summary>
        public string first_level_name_en { get => ReturnFirstLevelName_En(second_level_name_cn); }
        /// <summary>一级报警中文名称</summary>
        public string first_level_name_cn { get => ReturnFirstLevelName_Ch(second_level_name_cn); }

        /// <summary>二级报警代码</summary>
        public string second_level_code { get => ReturnSecondLevelCode(second_level_name_cn); }
        /// <summary>二级报警英文名称</summary>
        public string second_level_name_en { get => ReturnSecondLevelName_En(second_level_name_cn); }
        /// <summary>二级报警中文名称</summary>
        public string second_level_name_cn { get; set; }

        /// <summary>三级报警代码</summary>
        public string third_level_code { get; set; }
        /// <summary>三级报警英文名称</summary>
        public string third_level_name_en { get; set; }
        /// <summary>三级报警中文名称</summary>
        public string third_level_name_cn { get; set; }

        /// <summary>工站编号（一条线为一个工站）</summary>
        public string station_code { get; set; } = "06";
        /// <summary>模块编号（一台机为一个模块）</summary>
        public string module_code { get; set; }
        /// <summary>模块英文名称（一台机为一个模块）</summary>
        public string module_name_en { get; set; }
        /// <summary>模块中文名称（一台机为一个模块）</summary>
        public string module_name_cn { get; set; }

        /// <summary>ErrorCode</summary>
        public string error_codes { get => _error_codes = first_level_code + second_level_code + vendor_code + third_level_code; set => _error_codes = value; }
        /// <summary>模块总编号（厂商编号+工站编号+模块编号）</summary>
        public string module_codes { get => _module_codes = vendor_code + station_code + module_code; }
        public string trace_process_name { get; set; }
        #endregion



        #region Method
        private string ReturnSecondLevelCode(string secondlevelName)
        {
            switch (secondlevelName)
            {
                case "关机":
                    return "01";
                case "吃飯休息":
                    return "01";
                case "待料":
                    return "01";
                case "首件":
                    return "01";
                case "维护保养":
                    return "01";
                case "机构":
                    return "01";
                case "气动":
                    return "01";
                case "程序设置":
                    return "01";
                case "其他电机":
                    return "02";
                case "其他传感器":
                    return "03";
                case "视觉":
                    return "04";
                case "传送带":
                    return "05";
                case "点胶镭射":
                    return "06";
                case "安全报警":
                    return "07";
                case "其他":
                    return "08";
                case "X轴":
                    return "09";
                case "Y轴":
                    return "10";
                case "Z轴":
                    return "11";
                case "其他轴":
                    return "12";
                case "调试工艺":
                    return "01";
                case "调试设备":
                    return "02";
                case "工艺更换耗材":
                    return "01";
                default:
                    return "";
            }
        }
        private string ReturnSecondLevelName_En(string secondlevelName)
        {
            switch (secondlevelName)
            {
                case "关机":
                    return "MC Off";
                case "吃飯休息":
                    return "Break";
                case "待料":
                    return "Waiting for parts";
                case "首件":
                    return "FAI";
                case "维护保养":
                    return "Maintenace";
                case "机构":
                    return "Mechanical";
                case "气动":
                    return "Pneumatic";
                case "程序设置":
                    return "program setting";
                case "其他电机":
                    return "Other Motors";
                case "其他传感器":
                    return "Other Sensors";
                case "视觉":
                    return "Camera";
                case "传送带":
                    return "Conveyor";
                case "点胶镭焊":
                    return "Applicators";
                case "安全报警":
                    return "Safety Alarm";
                case "其他":
                    return "Other";
                case "X轴":
                    return "X axis";
                case "Y轴":
                    return "Y axis";
                case "Z轴":
                    return "Z axis";
                case "其他轴":
                    return "Other axis";
                case "调试工艺":
                    return "Process - Adjustment";
                case "调试设备":
                    return "Machine - Adjustment";
                case "工艺更换耗材":
                    return "Process - Consumable";
                default:
                    return "";
            }
        }
        private string ReturnFirstLevelCode(string firstlevelName)
        {
            switch (firstlevelName)
            {
                case "关机":
                    return "10";
                case "吃飯休息":
                    return "11";
                case "待料":
                    return "12";
                case "首件":
                    return "20";
                case "维护保养":
                    return "30";
                case "机构":
                    return "40";
                case "气动":
                    return "50";
                case "程序设置":
                    return "60";
                case "其他电机":
                    return "60";
                case "其他传感器":
                    return "60";
                case "视觉":
                    return "60";
                case "传送带":
                    return "60";
                case "点胶镭焊":
                    return "60";
                case "安全报警":
                    return "60";
                case "其他":
                    return "60";
                case "X轴":
                    return "60";
                case "Y轴":
                    return "60";
                case "Z轴":
                    return "60";
                case "其他轴":
                    return "60";
                case "调试工艺":
                    return "70";
                case "调试设备":
                    return "70";
                case "工艺更换耗材":
                    return "80";
                default:
                    return "";
            }
        }
        private string ReturnFirstLevelName_En(string firstlevelName)
        {
            switch (firstlevelName)
            {
                case "关机":
                    return "MC Off";
                case "吃飯休息":
                    return "Break";
                case "待料":
                    return "Waiting for parts";
                case "首件":
                    return "FAI";
                case "维护保养":
                    return "Maintenace";
                case "机构":
                    return "Mechanical";
                case "气动":
                    return "Pneumatic";
                case "程序设置":
                    return "Electronics";
                case "其他电机":
                    return "Electronics";
                case "其他传感器":
                    return "Electronics";
                case "视觉":
                    return "Electronics";
                case "传送带":
                    return "Electronics";
                case "点胶镭焊":
                    return "Electronics";
                case "安全报警":
                    return "Electronics";
                case "其他":
                    return "Electronics";
                case "X轴":
                    return "Electronics";
                case "Y轴":
                    return "Electronics";
                case "Z轴":
                    return "Electronics";
                case "其他轴":
                    return "Electronics";
                case "调试工艺":
                    return "Adjustment";
                case "调试设备":
                    return "Adjustment";
                case "工艺更换耗材":
                    return "Process - Consumable";
                default:
                    return "";
            }
        }
        private string ReturnFirstLevelName_Ch(string firstlevelName)
        {
            switch (firstlevelName)
            {
                case "关机":
                    return "关机";
                case "吃飯休息":
                    return "吃飯休息";
                case "待料":
                    return "待料";
                case "首件":
                    return "首件";
                case "维护保养":
                    return "维护保养";
                case "机构":
                    return "机构";
                case "气动":
                    return "气动";
                case "程序设置":
                    return "电控";
                case "其他电机":
                    return "电控";
                case "其他传感器":
                    return "电控";
                case "视觉":
                    return "电控";
                case "传送带":
                    return "电控";
                case "点胶镭焊":
                    return "电控";
                case "安全报警":
                    return "电控";
                case "其他":
                    return "电控";
                case "X轴":
                    return "电控";
                case "Y轴":
                    return "电控";
                case "Z轴":
                    return "电控";
                case "其他轴":
                    return "电控";
                case "调试工艺":
                    return "调试";
                case "调试设备":
                    return "调试";
                case "工艺更换耗材":
                    return "工艺-更换耗材";
                default:
                    return "";
            }
        }
        #endregion
    }


    public class Errorthirdmsg
    {
        public string error_codes = "";
        public string third_level_name_cn { get; set; }
    }


    public enum 相机
    {
        相机1 = 1,
        相机2 = 3,
        相机3 = 3,
        相机4 = 4
    }
    #endregion

    #region 二级报警定义（固定）
    public enum ErrorLevelsecond : int
    {
        关机,
        吃飯休息,
        待料,
        首件,
        维护保养,
        机构,
        气动,

        程序设置,
        其他电机,
        其他传感器,
        视觉,
        传送带,
        点胶镭焊,
        安全报警,
        其他,
        X轴,
        Y轴,
        Z轴,
        其他轴,

        调试工艺,
        调试设备,
        工艺更换耗材
    }
    #endregion

    #region 报警类型
    public static class AlarmTpyes
    {
        public enum 轴报警
        {
            正限位 = 1,
            负限位 = 2,
            使能 = 3,
            其他报警 = 4,
        }
        public enum 气缸报警
        {
            伸出超时 = 1,
            缩回超时 = 2,
        }
        public enum 信号报警
        {
            信号检测异常 = 1,
        }
        public enum 轴组报警
        {
            到位超时 = 5,
            编码器和规划器位置偏差过大 = 6,
        }
        public enum 视觉报警
        {
            等待返回值超时 = 1,
            拍照NG = 2,
        }
        public enum 真空报警
        {
            异常 = 1,
        }
        public enum 维修保养
        {
            设备保养 = 1,
            治具保养 = 2,
            更換零配件 = 3,
        }
        public enum 设备状态
        {
            关机 = 1,
            吃飯休息 = 1,
            待料 = 1,
            首件 = 1,
        }
    }
    #endregion
}