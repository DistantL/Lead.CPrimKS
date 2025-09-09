using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Global
{
    public partial class ProxyData
    {
        #region Filed
        private static readonly ProxyData _Instance = new ProxyData();
        #endregion


        #region Event
        public event Action<string> OnSkipUI;
        public event Action OnShowSensor;
        public event Action OnClrSensor;

        public event Action<List<AlertInfo>> OnShowAudioAlert;
        public event Action<List<StationStatus>, List<SensorStatus>, List<Tuple<string, string>>> OnUpdateSensorStatus;
        #endregion


        #region Prop
        public static ProxyData Instance => _Instance;
        #endregion


        #region Method_ExternalUsing
        public void SkipUI(string name) 
        {
            OnSkipUI?.Invoke(name);
        }

        public void ShowSensor()
        {
            OnShowSensor?.Invoke();
        }

        public void ClearSensor()
        {
            OnClrSensor?.Invoke();
        }

        public void UpdateSensorStatus(List<StationStatus> stations, List<SensorStatus> sensors, List<Tuple<string, string>> arrows)
        {
            OnUpdateSensorStatus?.Invoke(stations, sensors, arrows);
        }
        #endregion
    }


    public class StationStatus
    {
        /// <summary>
        /// 全局变量中传感器状态中的序号
        /// </summary>
        public int PLCAddressIndex { get; set; }

        public string LocationName { get; set; }

        public string LocationShowName { get; set; }

        public bool HasUnitAtLocation { get; set; }
        /// <summary>
        /// 圆的中心X
        /// </summary>
        public int Location_X { get; set; }
        /// <summary>
        /// 圆的中心Y
        /// </summary>
        public int Location_Y { get; set; }
        /// <summary>
        /// 半径
        /// </summary>
        public int Size_Circle { get; set; }

        public int Size_Font { get; set; }

        public Size ActualWindowSize { get; private set; } = new Size(1000, 1000);
        public PointF ActualCircleULPos { get; private set; } = new PointF(1000, 1000);
        public PointF ActualCircleCenterPos { get; private set; } = new PointF(1000, 1000);

        public void SetActualWindowSize(Size size)
        {
            if (size.Width == (int)ActualCircleULPos.X && size.Height == (int)ActualCircleULPos.Y)
            {
                return;
            }

            ActualWindowSize = size;

            //计算实际窗口中位置
            ActualCircleCenterPos = new PointF((float)(Location_X * ActualWindowSize.Width / 1000.0), (float)(Location_Y * ActualWindowSize.Height / 1000.0));
            ActualCircleULPos = new PointF(ActualCircleCenterPos.X - Size_Circle, ActualCircleCenterPos.Y - Size_Circle);
        }
    }

    public class SensorStatus
    {
        /// <summary>
        /// 全局变量中传感器状态中的序号
        /// </summary>
        public int PLCAddressIndex { get; set; }
        public string SensorName { get; set; }
        public string SensorShowName { get; set; }

        public eSensorState CurrentState { get; set; }

        /// <summary>
        /// 圆的中心X
        /// </summary>
        public int Location_X { get; set; }
        /// <summary>
        /// 圆的中心Y
        /// </summary>
        public int Location_Y { get; set; }

        /// <summary>
        /// 圆的左上角开始偏差X
        /// </summary>
        public int Labal_Offset_X { get; set; } = 5;
        /// <summary>
        /// 圆的左上角开始偏差Y
        /// </summary>
        public int Labal_Offset_Y { get; set; } = 3;

        /// <summary>
        /// 半径
        /// </summary>
        public int Size_Circle { get; set; }
        public int Size_Font { get; set; }

        public Size ActualWindowSize { get; private set; } = new Size(1000, 1000);
        public PointF ActualCircleULPos { get; private set; } = new PointF(1000, 1000);
        public PointF ActualLabelPos { get; private set; } = new PointF(1000, 1000);

        public void SetActualWindowSize(Size size)
        {
            if (size.Width == (int)ActualCircleULPos.X && size.Height == (int)ActualCircleULPos.Y)
            {
                return;
            }

            ActualWindowSize = size;

            //计算实际窗口中位置
            ActualCircleULPos = new PointF((float)(Location_X * ActualWindowSize.Width / 1000.0 - Size_Circle), (float)(Location_Y * ActualWindowSize.Height / 1000.0 - Size_Circle));
            ActualLabelPos = new PointF((float)(ActualCircleULPos.X + Size_Circle * 2 + Labal_Offset_X), (float)(ActualCircleULPos.Y + Labal_Offset_Y));
        }
    }

    public enum eSensorState
    {
        Idle,
        Activated,
        ManuallyDisabled,
        SignalLost,
    }
}
