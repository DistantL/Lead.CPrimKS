using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Lead.CPrim.Interfaces;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace ThreadSafty_StreamlineControl
{
    public partial class PressCurve : UserControl, IDisposable
    {
        private IEleAD eleAD;
        private Task task;
        private CancellationTokenSource cts;
        private object locker = new object();
        private bool IsCaptureing;
        private PressCurvePoint[] points;
        private int count = 0;
        private Stopwatch stopWatch = new Stopwatch(); 
        public PressCurve(IEleAD eleAD)
        {
            this.eleAD = eleAD;
            InitializeComponent();
            cts = new CancellationTokenSource();
            task = new Task(CaptureLoop, cts.Token, TaskCreationOptions.LongRunning);
            task.Start();
        }

        public void SaveCurve(string sn, string filePath, PressCurvePoint[] points)
        {
            chart1.Titles[0].Text = sn;
            chart1.Series[0].Points.Clear();
            foreach (var item in points)
            {
                if(item != null)
                {
                    chart1.Series[0].Points.AddXY(item.X, item.Y);
                }
            }
            chart1.SaveImage(filePath, ChartImageFormat.Png);
        }

        private void CaptureLoop()
        {
            while (!cts.IsCancellationRequested)
            {
                if (!IsCaptureing)
                {
                    Application.DoEvents();
                    Thread.Sleep(5);
                    continue;
                }
                points[count].X = stopWatch.ElapsedMilliseconds / 1000.0;
                points[count].Y = eleAD.Read();
                count++;
                if (count > points.Length)
                {
                    stopWatch.Stop();
                    IsCaptureing = false;
                }
                Application.DoEvents();
                Thread.Sleep(1);
            }
        }

        public void StartCapture()
        {
            lock (locker)
            {
                count = 0;
                stopWatch.Restart();
                points = new PressCurvePoint[10 * 1000];
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = new PressCurvePoint();
                }
                IsCaptureing = true;
            }
        }
        public PressCurvePoint[] StopCapture()
        {
            lock (locker)
            {
                count = 0;
                stopWatch.Stop();
                IsCaptureing = false;
            }
            return points;
        }

        public new void Dispose()
        {
            cts.Cancel();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }

    public class PressCurvePoint
    {
        public double X { get; set; }
        public double Y { get; set; }

    }
}
