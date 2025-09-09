using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;

namespace Lead.CPrim.EleCartesian.EleUIs
{
    public partial class CartesianMovingForm : Form
    {
        private IEleCartesian _cart;
        private string _posName;
        private bool _groupMove;
        private int _axisIndex;
        private DateTime _startTime;
        public CartesianMovingForm()
        {
            InitializeComponent();
        }
        public CartesianMovingForm(IEleCartesian cart, string posName, bool groupMove = true, int axisIndex = -1)
        {
            _cart = cart;
            _posName = posName;
            _groupMove = groupMove;
            _axisIndex = axisIndex;
            InitializeComponent();
            Text = ((IEle)cart).Name + "  移动中......";
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_groupMove)
            {
                _cart.GroupStop();
            }
            else
            {
                _cart.SingleStop(_axisIndex);
            }

            DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ExecDateDiff(_startTime, DateTime.Now) > 100)
            {
                _cart.GroupStop();
                DialogResult = DialogResult.Cancel;
                this.Close();
            }

            if (_groupMove)
            {
                if (_cart.IsStop)
                {
                    DialogResult = _cart.InLocation(_posName) ? DialogResult.Yes : DialogResult.No;
                    this.Close();
                }
            }
            else
            {
                if (_cart.Axises.ContainsKey(_axisIndex) && _cart.Axises[_axisIndex].IsStop)
                {
                    DialogResult = _cart.AxisInLocation(_axisIndex, _posName) ? DialogResult.Yes : DialogResult.No;
                    this.Close();
                }
            }
        }

        private void CartesianMovingForm_Load(object sender, EventArgs e)
        {
            _startTime = DateTime.Now;
        }

        /// <summary>
        /// 程序执行时间测试
        /// </summary>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
        private double ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            //你想转的格式
            return ts3.TotalSeconds;
        }
    }
}
