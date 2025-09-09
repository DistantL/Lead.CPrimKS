using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.MsgForm
{
	public class SoftAnimation
	{
		/// <summary>每段延迟的时间</summary>
		private static int TimeFragment { get; set; } = 20;
		/// <summary>颜色分段</summary>
		/// <param name="Start">开始颜色</param>
		/// <param name="End">结束颜色</param>
		/// <param name="i">第i段</param>
		/// <param name="count">段数</param>
		/// <returns>byte</returns>
		private static byte GetValue(byte Start, byte End, int i, int count)
		{
			if (Start == End)
			{
				return Start;
			}
			return (byte)((End - Start) * i / count + Start);
		}
		/// <summary>多线程分批次进行颜色设置</summary>
		/// <param name="obj">object</param>
		private static void ThreadPoolColorAnimation(object obj)
		{
			object[] objs = obj as object[];

			Control control = objs[0] as Control;
			Color color = (Color)objs[1];
			int time = (int)objs[2];
			Func<Control, Color> getColor = (Func<Control, Color>)objs[3];
			Action<Control, Color> setcolor = (Action<Control, Color>)objs[4];

			int count = (time + TimeFragment - 1) / TimeFragment;
			Color color_old = getColor(control);
			try
			{
				int i;
				for (i = 0; i < count; i++)
				{
					control.Invoke((Action)delegate
					{
						setcolor(control, Color.FromArgb(GetValue(color_old.R, color.R, i, count), GetValue(color_old.G, color.G, i, count), GetValue(color_old.B, color.B, i, count)));
					});
					Thread.Sleep(TimeFragment);
				}
				control?.Invoke((Action)delegate
				{
					setcolor(control, color);
				});
			}
			catch
			{
			}
		}
		/// <summary>Control颜色设置</summary>
		/// <param name="control">Control</param>
		/// <param name="color">颜色</param>
		/// <param name="time">时间</param>
		public static void BeginBackcolorAnimation(Control control, Color color, int time)
		{
			if (control.BackColor != color)
			{
				Func<Control, Color> getcolor = m => m.BackColor;

				Action<Control, Color> setcolor = (Control m, Color n) => m.BackColor = n;

				ThreadPool.QueueUserWorkItem(ThreadPoolColorAnimation, new object[5] { control, color, time, getcolor, setcolor });
			}
		}
	}
}
