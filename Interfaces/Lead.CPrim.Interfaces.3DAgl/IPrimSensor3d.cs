using System.Collections.Generic;
using CommonStruct.Type3D;

namespace Lead.CPrim.Interfaces.Sensor3d
{
    /// <summary>
    /// 用于3D传感器的通用接口
    /// </summary>
    public interface IPrimSensor3d
    {
        /// <summary>
        /// 开始测量
        /// </summary>
        /// <param name="deviceId">传感器Id，默认为0</param>
        /// <returns></returns>
        int StartMeasure(int deviceId = 0);

        /// <summary>
        /// 结束测量
        /// </summary>
        /// <param name="deviceId">传感器Id，默认为0</param>
        /// <returns></returns>
        int StopMeasure(int deviceId = 0);
        
        /// <summary>
        /// 清除内存中存储的已获取到的点位集合
        /// </summary>
        /// <param name="deviceId">传感器Id，默认为0</param>
        /// <returns></returns>
        int ClearBatchData(int deviceId = 0);

        /// <summary>
        /// 更改传感器控制器运行的当前配方
        /// </summary>
        /// <param name="productType">配方值</param>
        /// <param name="deviceId">传感器Id，默认为0</param>
        /// <returns></returns>
        int ChangeActiveJob(object productType, int deviceId = 0);

        /// <summary>
        /// 获取当前传感器批量处理的点位集合大小
        /// </summary>
        /// <param name="deviceId">传感器Id，默认为0</param>
        /// <returns></returns>
        int GetBatchDataCount(int deviceId = 0);

        /// <summary>
        /// 获取当前传感器批量处理的点位集合
        /// </summary>
        /// <param name="yPoses">Y向坐标集合</param>
        /// <param name="deviceId">传感器Id，默认为0</param>
        /// <param name="isMirror">X向是否镜像</param>
        /// <param name="layerIndex">层数</param>
        /// <returns></returns>
        List<List<PointFS>> GetBatchData(List<double> yPoses, int deviceId = 0, bool isMirror = false, int layerIndex = 0);

        /// <summary>
        /// 获取传感器Z值集合
        /// </summary>传感器编号
        /// <param name="deviceId"></param>
        /// <returns></returns>
         List<int[]> GetBatchArray(int deviceId);

        /// <summary>
        /// 切换配方
        /// </summary>
        /// <param name="device">传感器Id，默认为0</param>
        /// <param name="number">配方编号</param>
        /// <returns></returns>
        int SwitchProgram(int device, int number);
    }
}
