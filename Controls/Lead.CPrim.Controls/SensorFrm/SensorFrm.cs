using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{

    public partial class SensorFrm : UIPage
    {
        private List<StationStatus> stations = new List<StationStatus>();
        private List<SensorStatus> sensors = new List<SensorStatus>();
        private List<Tuple<string, string>> arrows = new List<Tuple<string, string>>();


        private SizeF size;
        private RectangleF rectangleF;
        private Color color_circle;
        private Color color_outline;
        private Pen pen;
        private StringFormat sf;

        public SensorFrm()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            pen = new Pen(ColorTranslator.FromHtml("#5A5A5A"));
            pen.Width = 6;
            AdjustableArrowCap lineArrow = new AdjustableArrowCap(pen.Width / 2, pen.Width / 2, true);
            pen.CustomEndCap = lineArrow;

            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //stations.Add(new StationStatus() { PLCAddressIndex = 0, LocationName = "Sta #1", LocationShowName = "A", Size_Font = 15, Size_Circle = 25, Location_X = 100, Location_Y = 150, HasUnitAtLocation = false });
            //stations.Add(new StationStatus() { PLCAddressIndex = 1, LocationName = "Sta #2", LocationShowName = "B", Size_Font = 15, Size_Circle = 25, Location_X = 300, Location_Y = 150, HasUnitAtLocation = true });
            //stations.Add(new StationStatus() { PLCAddressIndex = 2, LocationName = "Sta #3", LocationShowName = "C1", Size_Font = 15, Size_Circle = 25, Location_X = 300, Location_Y = 350, HasUnitAtLocation = false });
            //stations.Add(new StationStatus() { PLCAddressIndex = 3, LocationName = "Sta #4", LocationShowName = "C2", Size_Font = 15, Size_Circle = 25, Location_X = 300, Location_Y = 550, HasUnitAtLocation = true });
            //stations.Add(new StationStatus() { PLCAddressIndex = 4, LocationName = "Sta #5", LocationShowName = "D1", Size_Font = 15, Size_Circle = 25, Location_X = 600, Location_Y = 350, HasUnitAtLocation = true });
            //stations.Add(new StationStatus() { PLCAddressIndex = 5, LocationName = "Sta #6", LocationShowName = "D2", Size_Font = 15, Size_Circle = 25, Location_X = 600, Location_Y = 550, HasUnitAtLocation = false });
            //stations.Add(new StationStatus() { PLCAddressIndex = 6, LocationName = "Sta #7", LocationShowName = "E", Size_Font = 15, Size_Circle = 25, Location_X = 600, Location_Y = 150, HasUnitAtLocation = true });

            //sensors.Add(new SensorStatus() { PLCAddressIndex = 7, SensorName = "sen #1-1", SensorShowName = "A-1-1", Size_Font = 8, Size_Circle = 8, Location_X = 50, Location_Y = 820, CurrentState = eSensorState.Idle });
            //sensors.Add(new SensorStatus() { PLCAddressIndex = 8, SensorName = "sen #2-1", SensorShowName = "A-2-1", Size_Font = 8, Size_Circle = 8, Location_X = 155, Location_Y = 820, CurrentState = eSensorState.Activated });
            //sensors.Add(new SensorStatus() { PLCAddressIndex = 9, SensorName = "sen #5-1", SensorShowName = "D-1-1", Size_Font = 8, Size_Circle = 8, Location_X = 260, Location_Y = 820, CurrentState = eSensorState.ManuallyDisabled });
            //sensors.Add(new SensorStatus() { PLCAddressIndex = 10, SensorName = "sen #6-1", SensorShowName = "D-1-2", Size_Font = 8, Size_Circle = 8, Location_X = 365, Location_Y = 820, CurrentState = eSensorState.SignalLost });

            //arrows.Add(new Tuple<string, string>("Sta #1", "Sta #2"));
            //arrows.Add(new Tuple<string, string>("Sta #2", "Sta #3"));
            //arrows.Add(new Tuple<string, string>("Sta #3", "Sta #4"));
            //arrows.Add(new Tuple<string, string>("Sta #3", "Sta #5"));
            //arrows.Add(new Tuple<string, string>("Sta #4", "Sta #6"));
            //arrows.Add(new Tuple<string, string>("Sta #6", "Sta #7"));
            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }


        public void UpDateUI(List<StationStatus> stations, List<SensorStatus> sensors, List<Tuple<string, string>> arrows)
        {
            this.stations = stations;
            this.sensors = sensors;
            this.arrows = arrows;
            this.pl_workPanel?.BeginInvoke(new Action(() => UpDateUI()));
        }

        private void UpDateUI()
        {
            BufferedGraphics myBuffer = null;
            Graphics g = null;
            try
            {
                BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
                myBuffer = currentContext.Allocate(pl_workPanel.CreateGraphics(), new Rectangle(0, 0, pl_workPanel.Size.Width, pl_workPanel.Size.Height));

                g = myBuffer.Graphics;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.Clear(pl_workPanel.BackColor);

                //假定 窗口长1000宽1000

                foreach (var item in stations)
                {
                    item.SetActualWindowSize(pl_workPanel.Size);
                }

                foreach (var item in arrows)
                {
                    var startStation = stations.Find(x => x.LocationName == item.Item1);
                    var endStation = stations.Find(x => x.LocationName == item.Item2);

                    double lineLength = Math.Sqrt(Math.Pow((startStation.ActualCircleCenterPos.X - endStation.ActualCircleCenterPos.X), 2) + Math.Pow((startStation.ActualCircleCenterPos.Y - endStation.ActualCircleCenterPos.Y), 2));
                    double proportion = (lineLength - endStation.Size_Circle) / lineLength;

                    var actualendPos = new PointF();
                    actualendPos.X = (float)(startStation.ActualCircleCenterPos.X + proportion * (endStation.ActualCircleCenterPos.X - startStation.ActualCircleCenterPos.X));
                    actualendPos.Y = (float)(startStation.ActualCircleCenterPos.Y + proportion * (endStation.ActualCircleCenterPos.Y - startStation.ActualCircleCenterPos.Y));

                    g.DrawLine(pen, startStation.ActualCircleCenterPos, actualendPos);
                }


                foreach (var item in stations)
                {
                    size = new SizeF(item.Size_Circle * 2, item.Size_Circle * 2);
                    rectangleF = new RectangleF(item.ActualCircleULPos, size);

                    if (item.HasUnitAtLocation)
                    {
                        color_circle = ColorTranslator.FromHtml("#5CD533");//绿
                    }
                    else
                    {
                        color_circle = ColorTranslator.FromHtml("#5A5A5A");//灰
                    }
                    g.FillEllipse(new SolidBrush(color_circle), rectangleF);
                    g.DrawString(item.LocationShowName, new Font("宋体", item.Size_Font, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134))), new SolidBrush(Color.White), rectangleF, sf);
                }

                foreach (var item in sensors)
                {
                    item.SetActualWindowSize(pl_workPanel.Size);

                    size = new SizeF(item.Size_Circle * 2, item.Size_Circle * 2);
                    rectangleF = new RectangleF(item.ActualCircleULPos, size);

                    switch (item.CurrentState)
                    {
                        case eSensorState.Idle:
                            color_circle = color_outline = ColorTranslator.FromHtml("#929292");
                            break;
                        case eSensorState.Activated:
                            color_circle = color_outline = ColorTranslator.FromHtml("#5CD533");
                            break;
                        case eSensorState.ManuallyDisabled:
                            color_circle = Color.White;
                            g.DrawEllipse(new Pen(Color.Black, 2), rectangleF);
                            break;
                        case eSensorState.SignalLost:
                            color_circle = color_outline = Color.Red;
                            break;
                        default:
                            color_circle = color_outline = Color.Black;
                            break;
                    }

                    g.FillEllipse(new SolidBrush(color_circle), rectangleF);
                    g.DrawString(item.SensorShowName, new Font("宋体", item.Size_Font, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134))), new SolidBrush(Color.Black), item.ActualLabelPos.X, item.ActualLabelPos.Y);
                }

                myBuffer.Render(pl_workPanel.CreateGraphics());
                g.Dispose();
                myBuffer.Dispose();
            }
            catch
            {
                if(g != null)
                g.Dispose();
                if(myBuffer != null)
                myBuffer.Dispose();
            }
        }

        private void pl_workPanel_Paint(object sender, PaintEventArgs e)
        {
            UpDateUI(stations, sensors, arrows);
        }

        private void pl_workPanel_Resize(object sender, EventArgs e)
        {
            pl_workPanel_Paint(null, null);
        }

        private void lb_Title_Click(object sender, EventArgs e)
        {
            ProxyData.Instance.ClearSensor();
        }
        /*
        private void timer1_Tick(object sender, EventArgs e)
        {
            var status = GlobalVariable.Instance.SensorStatus;
            if (status != null)
            {
                foreach (var item in stations)
                {
                    if (item.PLCAddressIndex < status.Length)
                    {
                        switch (status[item.PLCAddressIndex])
                        {
                            case 0:
                                item.HasUnitAtLocation = false;
                                break;
                            case 1:
                                item.HasUnitAtLocation = true;
                                break;
                        }
                    }
                }

                foreach (var item in sensors)
                {
                    if (item.PLCAddressIndex < status.Length)
                    {
                        switch (status[item.PLCAddressIndex])
                        {
                            case 0:
                                item.CurrentState = eSensorState.Idle;
                                break;
                            case 1:
                                item.CurrentState = eSensorState.Activated;
                                break;
                        }
                    }
                }
            }
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


        */
        public void OnLanguageChanged()
        {
            lb_Title.Text = NLocalizer.GetString("Lead_CPrim_Controls_SensorFrm_Title", "传感器连接看板");
        }
    }
}




