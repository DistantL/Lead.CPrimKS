using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.CmpTrigHelper;
using Lead.CPrim.CmpTrigHelper.CmpTrigUIs;
using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.ProxyTools;
using Newtonsoft.Json;

namespace Lead.CPrim.Global
{
    public class TriggerTableData
    {
        #region Event_Define
        public event UiSelected OnEventSelected;
        #endregion



        #region Field

        private Control _configUi;

        private bool _isSelected;

        private TriggerManager _instance;
        #endregion



        #region Prop

        [JsonIgnore]
        public TriggerManager Manager => _instance;

        /// <summary>
        /// GUID
        /// </summary>
        public Guid Gid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 起点
        /// </summary>
        public double StartPos { get; set; }

        /// <summary>
        /// 间隔
        /// </summary>
        public double Gap { get; set; }

        /// <summary>
        /// 终点
        /// </summary>
        public double EndPos { get; set; }

        /// <summary>
        /// 算法集合
        /// </summary>
        public List<string> AglList { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public int productID { get; set; }

        /// <summary>
        /// 触发点集合
        /// </summary>
        public SortedList<int, double> TrigPoints { get; set; }

        public double DelayTime { get; set; }

        public double DelayVelocity { get; set; }

        [JsonIgnore]
        public Control ConfigUi => _configUi;

        [JsonIgnore]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    _configUi.BackColor = value ? Color.Green : Colors.PrimaryBackColor236;
                    if (value)
                    {
                        OnEventSelected?.Invoke(this, ConfigType.Traj);
                    }
                }
            }
        }
        #endregion



        #region Ctor

        public TriggerTableData()
        {
            Gid = Guid.NewGuid();
            Name = "";
            Id = -1;
            TrigPoints = new SortedList<int, double>();
            _instance = TriggerManager.Instance;
            AglList = new List<string>();
            productID = -1;
            _configUi = new TriggerTable(this)
            {
                Dock = DockStyle.Top
            };
        }

        public TriggerTableData(TriggerManager manager) : this()
        {
            _instance = manager;
        }

        public TriggerTableData(string name, TriggerManager manager) : this(manager)
        {
            Name = name;
        }

        public TriggerTableData(string name, int id, TriggerManager manager) : this(name, manager)
        {
            Id = id;
        }

        public TriggerTableData(string name, int id, SortedList<int, double> trigPoints, TriggerManager manager) : this(name, id, manager)
        {
            TrigPoints = trigPoints;
        }

        #endregion



        #region Method_ExternalUsing

        /// <summary>
        /// 压触发点
        /// </summary>
        /// <param name="prim"></param>
        /// <param name="axis"></param>
        /// <param name="trigChannel"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        internal int AddPoints(ICmpTrig prim, IEleAxis axis, int trigChannel, double offset)
        {
            if (prim == null || axis == null)
            {
                return -601;
            }
            double[] array = new double[TrigPoints.Count];
            int num = 0;
            if (TrigPoints.First().Value > TrigPoints.Last().Value)
            {
                foreach (KeyValuePair<int, double> trigPoint in TrigPoints)
                {
                    array[num++] = (trigPoint.Value + DelayVelocity * DelayTime * 1E-06 + offset) * axis.GearRatio;
                }
            }
            else
            {
                foreach (KeyValuePair<int, double> trigPoint2 in TrigPoints)
                {
                    array[num++] = (trigPoint2.Value - DelayVelocity * DelayTime * 1E-06 + offset) * axis.GearRatio;
                }
            }
            return prim.SetTriggerTable(trigChannel, array, array.Length);
        }

        #endregion



        public int AddTable(IPrim prim, IEleAxis axis, int trigChannel)
        {
            return 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
