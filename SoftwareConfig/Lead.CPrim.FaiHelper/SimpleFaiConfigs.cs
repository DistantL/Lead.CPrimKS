using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lead.CPrim.FaiHelper
{
	/// <summary>简单FAI_子项管理器</summary>
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class ChildFaiConfig
	{
        #region Prop
        /// <summary>名称</summary>
        public string Name { get; set; }
        /// <summary>开判</summary>
        public bool Enable { get; set; }
        /// <summary>输出</summary>
        public bool IsOutput { get; set; }
        /// <summary>上传</summary>
        public bool IsUpload { get; set; }
        /// <summary>非正取零</summary>
        public bool IsNonnegativeTo0 { get; set; }
        /// <summary>非正取正</summary>
        public bool IsNonnegativeToPositive { get; set; }
        /// <summary>标准值</summary>
        public double Normal { get; set; }
		/// <summary>单位</summary>
		public string Unit { get; set; }
		/// <summary>上限</summary>
		public double TolUp { get; set; }
        /// <summary>下限</summary>
        public double TolLow { get; set; }
        /// <summary>补偿系数</summary>
        public double CompensationFactor { get; set; }
        /// <summary>补偿值</summary>
        public double Compensation { get; set; }
        /// <summary>行数</summary>
        public int Index { get; set; } 
        #endregion



        #region Ctor
        /// <summary>Ctor无参</summary>
        public ChildFaiConfig()
        {
            Name = "";
            Enable = true;
            IsOutput = true;
            IsUpload = true;
            IsNonnegativeTo0 = false;
            IsNonnegativeToPositive = false;
            Normal = 0.0;
            TolUp = 999.999;
            TolLow = -999.999;
            Compensation = 0.0;
            CompensationFactor = 1.0;
            Index = -1;
        }
		/// <summary>Ctor有12个参数</summary>
		/// <param name="name"></param>
		/// <param name="enable"></param>
		/// <param name="isOutput"></param>
		/// <param name="isUpload"></param>
		/// <param name="isNonnegativeTo0"></param>
		/// <param name="isNonnegativeToPositive"></param>
		/// <param name="normal"></param>
		/// <param name="tolUp"></param>
		/// <param name="tolLow"></param>
		/// <param name="compensation"></param>
		/// <param name="compensationFactor"></param>
		/// <param name="index"></param>
        public ChildFaiConfig(string name, bool enable, bool isOutput, bool isUpload, bool isNonnegativeTo0, bool isNonnegativeToPositive, double normal, double tolUp, double tolLow, double compensation, double compensationFactor, int index)
        {
            Name = name;
            Enable = enable;
            IsOutput = isOutput;
            IsUpload = isUpload;
            IsNonnegativeTo0 = isNonnegativeTo0;
            IsNonnegativeToPositive = isNonnegativeToPositive;
            Normal = normal;
            TolUp = tolUp;
            TolLow = tolLow;
            Compensation = compensation;
            CompensationFactor = compensationFactor;
            Index = index;
        }
        #endregion



        #region Others
		/// <summary>获取值</summary>
		/// <returns>string</returns>
        public string CsvValue()
        {
            string valueStr = "";
            valueStr += Name + ",";
            valueStr += Enable + ",";
            valueStr += IsOutput + ",";
            valueStr += IsUpload + ",";
            valueStr += ",";
            valueStr += ",";
            valueStr += IsNonnegativeTo0 + ",";
            valueStr += IsNonnegativeToPositive + ",";
            valueStr += Normal + ",";
            valueStr += TolUp + ",";
            valueStr += TolLow + ",";
            valueStr += CompensationFactor + ",";
            valueStr += Compensation + ",";
            return valueStr + "子集";
        }
		/// <summary>赋值</summary>
		/// <param name="strValue">值</param>
        public void CsvToValue(string strValue)
        {
            string[] valuses = strValue.Split(',');
            Name = valuses[0];
            Enable = !bool.TryParse(valuses[1], out var en) || en;
            IsOutput = !bool.TryParse(valuses[2], out var output) || output;
            IsUpload = !bool.TryParse(valuses[3], out var upload) || upload;
            IsNonnegativeTo0 = bool.TryParse(valuses[6], out var t0) && t0;
            IsNonnegativeToPositive = bool.TryParse(valuses[7], out var tPostive) && tPostive;
            Normal = (double.TryParse(valuses[8], out var normal) ? normal : 0.0);
            TolUp = (double.TryParse(valuses[9], out var up) ? up : 999.99);
            TolLow = (double.TryParse(valuses[10], out var low) ? low : (-999.99));
            CompensationFactor = (double.TryParse(valuses[11], out var kp) ? kp : 1.0);
            Compensation = (double.TryParse(valuses[12], out var offset) ? offset : 0.0);
        }
		/// <summary>获取标题</summary>
		/// <returns>string</returns>
		public string CsvHeader()
		{
			return "名称,使能,输出,上传,集合,虚拟,非正取零,非正取正,Normal,TolUp,TolLow,补偿系数,补偿值,是否子集";
		}
		#endregion
	}



	/// <summary>具体行_简单FAI数据行配置</summary>
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class FaiConfig
	{
		#region Prop
		/// <summary>名称</summary>
		public string Name { get; set; }
		/// <summary>开判</summary>
		public bool Enable { get; set; }
		/// <summary>输出</summary>
		public bool IsOutput { get; set; }
		/// <summary>上传</summary>
		public bool IsUpload { get; set; }
		/// <summary>true：包含子集合；false：不包含子集合</summary>
		public bool IsParent { get; set; }
		/// <summary>虚拟</summary>
		public bool IsVirtual { get; set; }
		/// <summary>非正取零</summary>
		public bool IsNonnegativeTo0 { get; set; }
		/// <summary>非正取正</summary>
		public bool IsNonnegativeToPositive { get; set; }
		/// <summary>正常值</summary>
		public double Normal { get; set; }
		/// <summary>单位</summary>
		public string Unit { get; set; }
		/// <summary>上限</summary>
		public double TolUp { get; set; }
		/// <summary>下限</summary>
		public double TolLow { get; set; }
		/// <summary>补偿系数</summary>
		public double CompensationFactor { get; set; }
		/// <summary>补偿值</summary>
		public double Compensation { get; set; }
		/// <summary>子项</summary>
		public ConcurrentDictionary<Guid, ChildFaiConfig> ChildFaiConfigs { get; set; }
		/// <summary>行号</summary>
		public int Index { get; set; }
		#endregion



		#region Ctor
		/// <summary>Ctor无参</summary>
		public FaiConfig()
		{
			Name = "";
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			IsParent = false;
			IsVirtual = false;
			IsNonnegativeTo0 = false;
			IsNonnegativeToPositive = false;
			Normal = 0.0;
			TolUp = 999.999;
			TolLow = -999.999;
			Compensation = 0.0;
			CompensationFactor = 1.0;
			ChildFaiConfigs = new ConcurrentDictionary<Guid, ChildFaiConfig>();
			Index = -1;
			Unit = "";
		}
		/// <summary>Ctor无参有1个参数</summary>
		/// <param name="index">行号</param>
		public FaiConfig(int index)
		{
			Name = "";
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			IsParent = false;
			IsVirtual = false;
			IsNonnegativeTo0 = false;
			IsNonnegativeToPositive = false;
			Normal = 0.0;
			TolUp = 999.999;
			TolLow = -999.999;
			Compensation = 0.0;
			CompensationFactor = 1.0;
			ChildFaiConfigs = new ConcurrentDictionary<Guid, ChildFaiConfig>();
			Index = index;
			Unit = "";
		}
		/// <summary>Ctor无参有14个参数</summary>
		/// <param name="name">名称</param>
		/// <param name="enable">开判</param>
		/// <param name="isOutput">输出</param>
		/// <param name="isUpload">上传</param>
		/// <param name="isParent">集合</param>
		/// <param name="isVirtual">虚拟</param>
		/// <param name="isNonnegativeTo0">非正取零</param>
		/// <param name="isNonnegativeToPositive">非正取正</param>
		/// <param name="normal">正常值</param>
		/// <param name="tolUp">上限</param>
		/// <param name="tolLow">下限</param>
		/// <param name="compensation">补偿值</param>
		/// <param name="compensationFactor">补偿系数</param>
		/// <param name="index">行号</param>
		public FaiConfig(string name, bool enable, bool isOutput, bool isUpload, bool isParent, bool isVirtual, bool isNonnegativeTo0, bool isNonnegativeToPositive, double normal, double tolUp, double tolLow, double compensation, double compensationFactor, int index)
		{
			Name = name;
			Enable = enable;
			IsOutput = isOutput;
			IsUpload = isUpload;
			IsParent = isParent;
			IsVirtual = isVirtual;
			IsNonnegativeTo0 = isNonnegativeTo0;
			IsNonnegativeToPositive = isNonnegativeToPositive;
			Normal = normal;
			TolUp = tolUp;
			TolLow = tolLow;
			Compensation = compensationFactor;
			CompensationFactor = 1.0;
			Index = index;
			ChildFaiConfigs = new ConcurrentDictionary<Guid, ChildFaiConfig>();
		}
		#endregion



		#region Others
		/// <summary>获取值</summary>
		/// <returns>string</returns>
		public string CsvValue()
		{
			string valueStr = "";
			valueStr += Name + ",";
			valueStr += Enable + ",";
			valueStr += IsOutput + ",";
			valueStr += IsUpload + ",";
			valueStr += IsParent + ",";
			valueStr += IsVirtual + ",";
			valueStr += IsNonnegativeTo0 + ",";
			valueStr += IsNonnegativeToPositive + ",";
			valueStr += Normal + ",";
			valueStr += TolUp + ",";
			valueStr += TolLow + ",";
			valueStr += CompensationFactor + ",";
			valueStr += Compensation + ",";
			return valueStr ?? "";
		}
		/// <summary>赋值</summary>
		/// <param name="strValue">内容</param>
		public void CsvToValue(string strValue)
		{
			string[] valuses = strValue.Split(',');
			Name = valuses[0];
			Enable = !bool.TryParse(valuses[1], out var en) || en;
			IsOutput = !bool.TryParse(valuses[2], out var output) || output;
			IsUpload = !bool.TryParse(valuses[3], out var upload) || upload;
			IsParent = bool.TryParse(valuses[4], out var isparent) && isparent;
			IsVirtual = bool.TryParse(valuses[5], out var isvir) && isvir;
			IsNonnegativeTo0 = bool.TryParse(valuses[6], out var t0) && t0;
			IsNonnegativeToPositive = bool.TryParse(valuses[7], out var tPostive) && tPostive;
			Normal = (double.TryParse(valuses[8], out var normal) ? normal : 0.0);
			TolUp = (double.TryParse(valuses[9], out var up) ? up : 999.99);
			TolLow = (double.TryParse(valuses[10], out var low) ? low : (-999.99));
			CompensationFactor = (double.TryParse(valuses[11], out var kp) ? kp : 1.0);
			Compensation = (double.TryParse(valuses[12], out var offset) ? offset : 0.0);
		}
		/// <summary>获取标题</summary>
		/// <returns>string</returns>
		public string CsvHeader()
		{
			return "名称,使能,输出,上传,集合,虚拟,非正取零,非正取正,Normal,TolUp,TolLow,补偿系数,补偿值,是否子集";
		}
		#endregion
	}



	/// <summary>具体级_简单FAI数据表配置</summary>
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class SimpleFaiConfigs
	{
		#region Field
		/// <summary>FAI管理器对象</summary>
		private FaiManager _manager;
		/// <summary>已选择</summary>
		private bool _isSelected;
		/// <summary>UI[SimpleFaiConfigsControl]</summary>
		private Control _configUi;
        #endregion



        #region Prop
        /// <summary>Id</summary>
        public Guid Gid { get; set; }
        /// <summary>名称</summary>
        public string Name { get; set; }
        /// <summary>是否启用</summary>
        public bool Enable { get; set; }
		/// <summary>是否输出</summary>
		public bool IsOutput { get; set; }
		/// <summary>是否上传</summary>
		public bool IsUpload { get; set; }
		/// <summary>数据集合</summary>
		public ConcurrentDictionary<Guid, FaiConfig> FaiConfigs { get; set; }
        /// <summary>UI[SimpleFaiConfigsControl]</summary>
        [JsonIgnore]
        public Control ConfigUi => _configUi;
		/// <summary>已选择</summary>
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
                    _configUi.BackColor = (value ? Color.Green : Color.LightGray);
                    if (value)
                    {
                        OnEventSelected?.Invoke(this);
                    }
                }
            }
        }
		/// <summary>FAI管理器对象</summary>
		[JsonIgnore]
        public FaiManager Manager => _manager; 
        #endregion



        #region Define_Event
		/// <summary>UI被选择时发生</summary>
        public event UiSelected OnEventSelected;
        #endregion



        #region Ctor
		/// <summary>Ctor无参</summary>
        public SimpleFaiConfigs()
        {
            Gid = Guid.NewGuid();
            Name = "";
            Enable = true;
            IsOutput = true;
            IsUpload = true;
            FaiConfigs = new ConcurrentDictionary<Guid, FaiConfig>();
            _isSelected = false;
            _configUi = new SimpleFaiConfigsControl(this)
            {
                Dock = DockStyle.Top
            };
            _manager = FaiManager.Instance;
		}
		/// <summary>Ctor有2个参数</summary>
		/// <param name="name"></param>
		/// <param name="manager"></param>
		public SimpleFaiConfigs(string name, FaiManager manager)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			FaiConfigs = new ConcurrentDictionary<Guid, FaiConfig>();
			_isSelected = false;
			_configUi = new SimpleFaiConfigsControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}
		/// <summary>Ctor有3个参数</summary>
		/// <param name="name"></param>
		/// <param name="faiConfigs"></param>
		/// <param name="manager"></param>
		public SimpleFaiConfigs(string name, ConcurrentDictionary<Guid, FaiConfig> faiConfigs, FaiManager manager)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			FaiConfigs = faiConfigs;
			_isSelected = false;
			_configUi = new SimpleFaiConfigsControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
		}
		/// <summary>Ctor有4个参数</summary>
		/// <param name="gid"></param>
		/// <param name="name"></param>
		/// <param name="faiConfigs"></param>
		/// <param name="manager"></param>
		public SimpleFaiConfigs(Guid gid, string name, ConcurrentDictionary<Guid, FaiConfig> faiConfigs, FaiManager manager)
        {
            Gid = gid;
            Name = name;
            Enable = true;
            IsOutput = true;
            IsUpload = true;
            FaiConfigs = faiConfigs;
            _isSelected = false;
            _configUi = new SimpleFaiConfigsControl(this)
            {
                Dock = DockStyle.Top
            };
            _manager = manager;
        }
        #endregion


        private bool JudgeResult(Dictionary<string, double> dicsFai, bool compensateEnable = true)
		{
			int iRet = 0;
			Parallel.ForEach(dicsFai, delegate(KeyValuePair<string, double> item1, ParallelLoopState loopState)
			{
				Parallel.ForEach(FaiConfigs, delegate(KeyValuePair<Guid, FaiConfig> item2)
				{
					if (item2.Value.Enable)
					{
						if (!item2.Value.IsParent)
						{
							if (item2.Value.Name == item1.Key)
							{
								double num = (compensateEnable ? (item1.Value * item2.Value.CompensationFactor + item2.Value.Compensation) : item1.Value);
								if (compensateEnable && num < 0.0)
								{
									if (item2.Value.IsNonnegativeTo0)
									{
										num = 0.0;
									}
									else if (item2.Value.IsNonnegativeToPositive)
									{
										num = 0.0 - num;
									}
								}
								if (!Core.DoubleEquals(num, item2.Value.Normal + item2.Value.TolUp) && !Core.DoubleEquals(num, item2.Value.Normal + item2.Value.TolLow) && (num > item2.Value.Normal + item2.Value.TolUp || num < item2.Value.Normal + item2.Value.TolLow))
								{
									int num2 = iRet;
									iRet = num2 + 1;
									loopState.Break();
								}
							}
						}
						else
						{
							foreach (KeyValuePair<Guid, ChildFaiConfig> current in item2.Value.ChildFaiConfigs)
							{
								if (current.Value.Enable && current.Value.Name == item1.Key)
								{
									double num3 = (compensateEnable ? (item1.Value * current.Value.CompensationFactor + current.Value.Compensation) : item1.Value);
									if (compensateEnable && num3 < 0.0)
									{
										if (current.Value.IsNonnegativeTo0)
										{
											num3 = 0.0;
										}
										else if (current.Value.IsNonnegativeToPositive)
										{
											num3 = 0.0 - num3;
										}
									}
									if (!Core.DoubleEquals(num3, current.Value.Normal + current.Value.TolUp) && !Core.DoubleEquals(num3, current.Value.Normal + current.Value.TolLow) && (num3 > current.Value.Normal + current.Value.TolUp || num3 < current.Value.Normal + current.Value.TolLow))
									{
										int num2 = iRet;
										iRet = num2 + 1;
										loopState.Break();
									}
								}
							}
							if (!item2.Value.IsVirtual && item2.Value.Name == item1.Key)
							{
								double num4 = (compensateEnable ? (item1.Value * item2.Value.CompensationFactor + item2.Value.Compensation) : item1.Value);
								if (compensateEnable && num4 < 0.0)
								{
									if (item2.Value.IsNonnegativeTo0)
									{
										num4 = 0.0;
									}
									else if (item2.Value.IsNonnegativeToPositive)
									{
										num4 = 0.0 - num4;
									}
								}
								if (!Core.DoubleEquals(num4, item2.Value.Normal + item2.Value.TolUp) && !Core.DoubleEquals(num4, item2.Value.Normal + item2.Value.TolLow) && (num4 > item2.Value.Normal + item2.Value.TolUp || num4 < item2.Value.Normal + item2.Value.TolLow))
								{
									int num2 = iRet;
									iRet = num2 + 1;
									loopState.Break();
								}
							}
						}
					}
				});
			});
			return iRet == 0;
		}

		private bool JudgeResultOutAllFais(Dictionary<string, double> dicsFai, out Dictionary<string, bool> allFais, bool compensateEnable = true)
		{
			int iRet = 0;
			allFais = new Dictionary<string, bool>();
			foreach (KeyValuePair<string, double> item1 in dicsFai)
			{
				foreach (KeyValuePair<Guid, FaiConfig> item2 in FaiConfigs)
				{
					if (!item2.Value.Enable)
					{
						continue;
					}
					if (!item2.Value.IsVirtual && item2.Value.Name == item1.Key)
					{
						if (item2.Value.IsOutput && !allFais.ContainsKey(item2.Value.Name))
						{
							allFais.Add(item2.Value.Name, value: true);
						}
						double faiValue = (compensateEnable ? (item1.Value * item2.Value.CompensationFactor + item2.Value.Compensation) : item1.Value);
						if (compensateEnable && faiValue < 0.0)
						{
							if (item2.Value.IsNonnegativeTo0)
							{
								faiValue = 0.0;
							}
							else if (item2.Value.IsNonnegativeToPositive)
							{
								faiValue = 0.0 - faiValue;
							}
						}
						if (!Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolUp) && !Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolLow) && (faiValue > item2.Value.Normal + item2.Value.TolUp || faiValue < item2.Value.Normal + item2.Value.TolLow))
						{
							if (item2.Value.IsOutput)
							{
								allFais[item2.Value.Name] = false;
							}
							iRet++;
						}
					}
					if (!item2.Value.IsParent)
					{
						continue;
					}
					if (item2.Value.IsOutput && !allFais.ContainsKey(item2.Value.Name))
					{
						allFais.Add(item2.Value.Name, value: true);
					}
					foreach (KeyValuePair<Guid, ChildFaiConfig> item3 in item2.Value.ChildFaiConfigs)
					{
						if (!item3.Value.Enable || !(item3.Value.Name == item1.Key))
						{
							continue;
						}
						if (item3.Value.IsOutput && !allFais.ContainsKey(item3.Value.Name))
						{
							allFais.Add(item3.Value.Name, value: true);
						}
						double faiValue2 = (compensateEnable ? (item1.Value * item3.Value.CompensationFactor + item3.Value.Compensation) : item1.Value);
						if (compensateEnable && faiValue2 < 0.0)
						{
							if (item3.Value.IsNonnegativeTo0)
							{
								faiValue2 = 0.0;
							}
							else if (item3.Value.IsNonnegativeToPositive)
							{
								faiValue2 = 0.0 - faiValue2;
							}
						}
						if (!Core.DoubleEquals(faiValue2, item3.Value.Normal + item3.Value.TolUp) && !Core.DoubleEquals(faiValue2, item3.Value.Normal + item3.Value.TolLow) && (faiValue2 > item3.Value.Normal + item3.Value.TolUp || faiValue2 < item3.Value.Normal + item3.Value.TolLow))
						{
							if (item3.Value.IsOutput)
							{
								allFais[item3.Value.Name] = false;
							}
							if (item2.Value.IsOutput)
							{
								allFais[item2.Value.Name] = false;
							}
							iRet++;
						}
					}
				}
			}
			return iRet == 0;
		}

		private bool JudgeResultOutAllFais(Dictionary<string, double> dicsFai, out Dictionary<string, bool> allFais, out Dictionary<object, object> newFais, bool compensateEnable = true)
		{
			int iRet = 0;
			allFais = new Dictionary<string, bool>();
			newFais = new Dictionary<object, object>();
			foreach (KeyValuePair<string, double> item1 in dicsFai)
			{
				newFais.Add(item1.Key, item1.Value);
				foreach (KeyValuePair<Guid, FaiConfig> item2 in FaiConfigs)
				{
					if (!item2.Value.Enable)
					{
						continue;
					}
					if (!item2.Value.IsVirtual && item2.Value.Name == item1.Key)
					{
						if (item2.Value.IsOutput)
						{
							allFais.Add(item2.Value.Name, value: true);
						}
						double faiValue = (compensateEnable ? (item1.Value * item2.Value.CompensationFactor + item2.Value.Compensation) : item1.Value);
						newFais[item1.Key] = faiValue;
						if (compensateEnable && faiValue < 0.0)
						{
							if (item2.Value.IsNonnegativeTo0)
							{
								faiValue = 0.0;
							}
							else if (item2.Value.IsNonnegativeToPositive)
							{
								faiValue = 0.0 - faiValue;
							}
						}
						if (!Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolUp) && !Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolLow) && (faiValue > item2.Value.Normal + item2.Value.TolUp || faiValue < item2.Value.Normal + item2.Value.TolLow))
						{
							if (item2.Value.IsOutput)
							{
								allFais[item2.Value.Name] = false;
							}
							iRet++;
						}
					}
					if (!item2.Value.IsParent)
					{
						continue;
					}
					if (item2.Value.IsOutput)
					{
						allFais.Add(item2.Value.Name, value: true);
					}
					foreach (KeyValuePair<Guid, ChildFaiConfig> item3 in item2.Value.ChildFaiConfigs)
					{
						if (!item3.Value.Enable || !(item3.Value.Name == item1.Key))
						{
							continue;
						}
						if (item3.Value.IsOutput)
						{
							allFais.Add(item3.Value.Name, value: true);
						}
						double faiValue2 = (compensateEnable ? (item1.Value * item3.Value.CompensationFactor + item3.Value.Compensation) : item1.Value);
						newFais[item1.Key] = faiValue2;
						if (compensateEnable && faiValue2 < 0.0)
						{
							if (item3.Value.IsNonnegativeTo0)
							{
								faiValue2 = 0.0;
							}
							else if (item3.Value.IsNonnegativeToPositive)
							{
								faiValue2 = 0.0 - faiValue2;
							}
						}
						if (!Core.DoubleEquals(faiValue2, item3.Value.Normal + item3.Value.TolUp) && !Core.DoubleEquals(faiValue2, item3.Value.Normal + item3.Value.TolLow) && (faiValue2 > item3.Value.Normal + item3.Value.TolUp || faiValue2 < item3.Value.Normal + item3.Value.TolLow))
						{
							if (item3.Value.IsOutput)
							{
								allFais[item3.Value.Name] = false;
							}
							if (item2.Value.IsOutput)
							{
								allFais[item2.Value.Name] = false;
							}
							iRet++;
						}
					}
				}
			}
			return iRet == 0;
		}

		internal Dictionary<string, double> OutputCompensationValues(Dictionary<string, double> dicsFai)
		{
			Dictionary<string, double> outputValues = new Dictionary<string, double>();
			foreach (KeyValuePair<string, double> item1 in dicsFai)
			{
				double faiValue = item1.Value;
				foreach (KeyValuePair<Guid, FaiConfig> item2 in FaiConfigs)
				{
					if (!item2.Value.IsParent)
					{
						if (!(item2.Value.Name == item1.Key))
						{
							continue;
						}
						faiValue = item1.Value * item2.Value.CompensationFactor + item2.Value.Compensation;
						if (faiValue < 0.0)
						{
							if (item2.Value.IsNonnegativeTo0)
							{
								faiValue = 0.0;
							}
							else if (item2.Value.IsNonnegativeToPositive)
							{
								faiValue = 0.0 - faiValue;
							}
						}
						break;
					}
					bool flag = false;
					foreach (KeyValuePair<Guid, ChildFaiConfig> item3 in item2.Value.ChildFaiConfigs)
					{
						if (!(item3.Value.Name == item1.Key))
						{
							continue;
						}
						flag = true;
						faiValue = item1.Value * item3.Value.CompensationFactor + item3.Value.Compensation;
						if (faiValue < 0.0)
						{
							if (item3.Value.IsNonnegativeTo0)
							{
								faiValue = 0.0;
							}
							else if (item3.Value.IsNonnegativeToPositive)
							{
								faiValue = 0.0 - faiValue;
							}
						}
						break;
					}
					if (flag)
					{
						break;
					}
					if (!(item2.Value.Name == item1.Key))
					{
						continue;
					}
					faiValue = item1.Value * item2.Value.CompensationFactor + item2.Value.Compensation;
					if (faiValue < 0.0)
					{
						if (item2.Value.IsNonnegativeTo0)
						{
							faiValue = 0.0;
						}
						else if (item2.Value.IsNonnegativeToPositive)
						{
							faiValue = 0.0 - faiValue;
						}
					}
					break;
				}
				outputValues.Add(item1.Key, faiValue);
			}
			return outputValues;
		}

		public bool JudgeOne(string faiName, double faiValue, bool compensateEnable = true)
		{
			int iRet = 0;
			Parallel.ForEach(FaiConfigs, delegate(KeyValuePair<Guid, FaiConfig> item2, ParallelLoopState loopState)
			{
				if (item2.Value.Enable)
				{
					if (!item2.Value.IsParent)
					{
						if (item2.Value.Name == faiName)
						{
							faiValue = (compensateEnable ? (faiValue * item2.Value.CompensationFactor + item2.Value.Compensation) : faiValue);
							if (compensateEnable && faiValue < 0.0)
							{
								if (item2.Value.IsNonnegativeTo0)
								{
									faiValue = 0.0;
								}
								else if (item2.Value.IsNonnegativeToPositive)
								{
									faiValue = 0.0 - faiValue;
								}
							}
							if (!Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolUp) && !Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolLow) && (faiValue > item2.Value.Normal + item2.Value.TolUp || faiValue < item2.Value.Normal + item2.Value.TolLow))
							{
								iRet++;
								loopState.Break();
							}
						}
					}
					else
					{
						foreach (KeyValuePair<Guid, ChildFaiConfig> current in item2.Value.ChildFaiConfigs)
						{
							if (current.Value.Enable && current.Value.Name == faiName)
							{
								faiValue = (compensateEnable ? (faiValue * current.Value.CompensationFactor + current.Value.Compensation) : faiValue);
								if (compensateEnable && faiValue < 0.0)
								{
									if (current.Value.IsNonnegativeTo0)
									{
										faiValue = 0.0;
									}
									else if (current.Value.IsNonnegativeToPositive)
									{
										faiValue = 0.0 - faiValue;
									}
								}
								if (!Core.DoubleEquals(faiValue, current.Value.Normal + current.Value.TolUp) && !Core.DoubleEquals(faiValue, current.Value.Normal + current.Value.TolLow) && (faiValue > current.Value.Normal + current.Value.TolUp || faiValue < current.Value.Normal + current.Value.TolLow))
								{
									iRet++;
									loopState.Break();
								}
							}
						}
						if (!item2.Value.IsVirtual && item2.Value.Name == faiName)
						{
							faiValue = (compensateEnable ? (faiValue * item2.Value.CompensationFactor + item2.Value.Compensation) : faiValue);
							if (compensateEnable && faiValue < 0.0)
							{
								if (item2.Value.IsNonnegativeTo0)
								{
									faiValue = 0.0;
								}
								else if (item2.Value.IsNonnegativeToPositive)
								{
									faiValue = 0.0 - faiValue;
								}
							}
							if (!Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolUp) && !Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolLow) && (faiValue > item2.Value.Normal + item2.Value.TolUp || faiValue < item2.Value.Normal + item2.Value.TolLow))
							{
								iRet++;
								loopState.Break();
							}
						}
					}
				}
			});
			return iRet == 0;
		}

		public bool JudgeResult(Dictionary<object, object>[] dicsFai, bool compensateEnable = true)
		{
			return JudgeResult(dicsFai, compensateEnable);
		}

		public bool JudgeResult(Dictionary<string, double>[] dicsFai, bool compensateEnable = true)
		{
			return JudgeResult(dicsFai, compensateEnable);
		}

		public bool JudgeResultOutAllFais(Dictionary<object, object>[] dicsFai, out Dictionary<string, bool> allFais, bool compensateEnable = true)
		{
			return JudgeResultOutAllFais(Core.DicsToAll(dicsFai), out allFais, compensateEnable);
		}

		public bool JudgeResultOutAllFais(Dictionary<string, double>[] dicsFai, out Dictionary<string, bool> allFais, bool compensateEnable = true)
		{
			return JudgeResultOutAllFais(Core.DicsToAll(dicsFai), out allFais, compensateEnable);
		}

		public bool JudgeResultOutAllFais(Dictionary<object, object>[] dicsFai, out Dictionary<string, bool> allFais, out Dictionary<object, object> newFais, bool compensateEnable = true)
		{
			return JudgeResultOutAllFais(Core.DicsToAll(dicsFai), out allFais, out newFais, compensateEnable);
		}

		public bool JudgeResultOutAllFais(Dictionary<string, double>[] dicsFai, out Dictionary<string, bool> allFais, out Dictionary<object, object> newFais, bool compensateEnable = true)
		{
			return JudgeResultOutAllFais(Core.DicsToAll(dicsFai), out allFais, out newFais, compensateEnable);
		}

		public bool JudgeResultOutAllFais(Dictionary<object, object> dicsFai, out Dictionary<string, bool> allFais, bool compensateEnable = true)
		{
			return JudgeResultOutAllFais(Core.DicsToAll(new Dictionary<object, object>[1] { dicsFai }), out allFais, compensateEnable);
		}

		public bool JudgeResultOutAllFais(Dictionary<object, object> dicsFai, out Dictionary<string, bool> allFais, out Dictionary<object, object> newFais, bool compensateEnable = true)
		{
			return JudgeResultOutAllFais(Core.DicsToAll(new Dictionary<object, object>[1] { dicsFai }), out allFais, out newFais, compensateEnable);
		}

		public bool JudgeResultOutAllFaisCount(List<Dictionary<string, double>[]> listArrayDicsFai, out Dictionary<string, int> allFaisCount, bool compensateEnable = true)
		{
			List<Dictionary<string, double>> listDicsFai = new List<Dictionary<string, double>>();
			foreach (Dictionary<string, double>[] item in listArrayDicsFai)
			{
				listDicsFai.Add(Core.DicsToAll(item));
			}
			return JudgeResultOutAllFaisCount(listDicsFai, out allFaisCount, compensateEnable);
		}

		public bool JudgeResultOutAllFaisCount(List<Dictionary<string, double>> listDicsFai, out Dictionary<string, int> allFaisCount, bool compensateEnable = true)
		{
			int iRet = 0;
			allFaisCount = new Dictionary<string, int>();
			JudgeResultOutAllFais(listDicsFai[0], out var firstAllFais, compensateEnable);
			foreach (KeyValuePair<string, bool> item in firstAllFais)
			{
				allFaisCount.Add(item.Key, (!item.Value) ? 1 : 0);
			}
			for (int i = 1; i < listDicsFai.Count; i++)
			{
				JudgeResultOutAllFais(listDicsFai[i], out var allFais, compensateEnable);
				foreach (KeyValuePair<string, bool> item2 in allFais)
				{
					if (allFaisCount.ContainsKey(item2.Key) && !item2.Value)
					{
						allFaisCount[item2.Key]++;
					}
				}
			}
			return iRet == 0;
		}

		public bool JudgeResultOutAllFaisCount(List<Dictionary<object, object>> listDicsFai, out Dictionary<string, int> allFaisCount, bool compensateEnable = true)
		{
			int iRet = 0;
			allFaisCount = new Dictionary<string, int>();
			JudgeResultOutAllFais(listDicsFai[0], out var firstAllFais, compensateEnable);
			foreach (KeyValuePair<string, bool> item in firstAllFais)
			{
				allFaisCount.Add(item.Key, (!item.Value) ? 1 : 0);
			}
			for (int i = 1; i < listDicsFai.Count; i++)
			{
				JudgeResultOutAllFais(listDicsFai[i], out var allFais, compensateEnable);
				foreach (KeyValuePair<string, bool> item2 in allFais)
				{
					if (allFaisCount.ContainsKey(item2.Key) && !item2.Value)
					{
						allFaisCount[item2.Key]++;
					}
				}
			}
			return iRet == 0;
		}

		public bool JudgeResultOutAllFaisCount(List<Dictionary<object, object>[]> listArrayDicsFai, out Dictionary<string, int> allFaisCount, bool compensateEnable = true)
		{
			List<Dictionary<string, double>> listDicsFai = new List<Dictionary<string, double>>();
			foreach (Dictionary<object, object>[] item in listArrayDicsFai)
			{
				listDicsFai.Add(Core.DicsToAll(item));
			}
			return JudgeResultOutAllFaisCount(listDicsFai, out allFaisCount, compensateEnable);
		}

		public bool JudgeResultOutParentFais(Dictionary<object, object>[] dicsFai, out Dictionary<string, bool> parentFais, bool compensateEnable = true)
		{
			return JudgeResultOutParentFais(Core.DicsToAll(dicsFai), out parentFais, compensateEnable);
		}

		public bool JudgeResultOutParentFais(Dictionary<string, double>[] dicsFai, out Dictionary<string, bool> parentFais, bool compensateEnable = true)
		{
			return JudgeResultOutParentFais(Core.DicsToAll(dicsFai), out parentFais, compensateEnable);
		}

		public bool JudgeResultOutParentFais(Dictionary<string, double> dicsFai, out Dictionary<string, bool> parentFais, bool compensateEnable = true)
		{
			int iRet = 0;
			parentFais = new Dictionary<string, bool>();
			foreach (KeyValuePair<string, double> item1 in dicsFai)
			{
				foreach (KeyValuePair<Guid, FaiConfig> item2 in FaiConfigs)
				{
					if (!item2.Value.Enable)
					{
						continue;
					}
					if (!item2.Value.IsParent)
					{
						if (!(item2.Value.Name == item1.Key))
						{
							continue;
						}
						double faiValue = (compensateEnable ? (item1.Value * item2.Value.CompensationFactor + item2.Value.Compensation) : item1.Value);
						if (compensateEnable && faiValue < 0.0)
						{
							if (item2.Value.IsNonnegativeTo0)
							{
								faiValue = 0.0;
							}
							else if (item2.Value.IsNonnegativeToPositive)
							{
								faiValue = 0.0 - faiValue;
							}
						}
						if (!Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolUp) && !Core.DoubleEquals(faiValue, item2.Value.Normal + item2.Value.TolLow) && (faiValue > item2.Value.Normal + item2.Value.TolUp || faiValue < item2.Value.Normal + item2.Value.TolLow))
						{
							iRet++;
						}
						continue;
					}
					if (item2.Value.IsOutput)
					{
						parentFais.Add(item2.Value.Name, value: true);
					}
					foreach (KeyValuePair<Guid, ChildFaiConfig> item3 in item2.Value.ChildFaiConfigs)
					{
						if (!item3.Value.Enable || !(item3.Value.Name == item1.Key))
						{
							continue;
						}
						double faiValue3 = (compensateEnable ? (item1.Value * item3.Value.CompensationFactor + item3.Value.Compensation) : item1.Value);
						if (compensateEnable && faiValue3 < 0.0)
						{
							if (item3.Value.IsNonnegativeTo0)
							{
								faiValue3 = 0.0;
							}
							else if (item3.Value.IsNonnegativeToPositive)
							{
								faiValue3 = 0.0 - faiValue3;
							}
						}
						if (!Core.DoubleEquals(faiValue3, item3.Value.Normal + item3.Value.TolUp) && !Core.DoubleEquals(faiValue3, item3.Value.Normal + item3.Value.TolLow) && (faiValue3 > item3.Value.Normal + item3.Value.TolUp || faiValue3 < item3.Value.Normal + item3.Value.TolLow))
						{
							if (item2.Value.IsOutput)
							{
								parentFais[item2.Value.Name] = false;
							}
							iRet++;
							break;
						}
					}
					if (!parentFais[item2.Value.Name] || item2.Value.IsVirtual || !(item2.Value.Name == item1.Key))
					{
						continue;
					}
					double faiValue2 = (compensateEnable ? (item1.Value * item2.Value.CompensationFactor + item2.Value.Compensation) : item1.Value);
					if (compensateEnable && faiValue2 < 0.0)
					{
						if (item2.Value.IsNonnegativeTo0)
						{
							faiValue2 = 0.0;
						}
						else if (item2.Value.IsNonnegativeToPositive)
						{
							faiValue2 = 0.0 - faiValue2;
						}
					}
					if (!Core.DoubleEquals(faiValue2, item2.Value.Normal + item2.Value.TolUp) && !Core.DoubleEquals(faiValue2, item2.Value.Normal + item2.Value.TolLow) && (faiValue2 > item2.Value.Normal + item2.Value.TolUp || faiValue2 < item2.Value.Normal + item2.Value.TolLow))
					{
						if (item2.Value.IsOutput)
						{
							parentFais[item2.Value.Name] = false;
						}
						iRet++;
					}
				}
			}
			return iRet == 0;
		}

		public bool JudgeResultOutParentFais(Dictionary<object, object> dicsFai, out Dictionary<string, bool> parentFais, bool compensateEnable = true)
		{
			return JudgeResultOutParentFais(Core.DicsToAll(new Dictionary<object, object>[1] { dicsFai }), out parentFais, compensateEnable);
		}

		public bool JudgeResultOutParentFaisCount(List<Dictionary<string, double>[]> listArrayDicsFai, out Dictionary<string, int> parentFaisCount, bool compensateEnable = true)
		{
			List<Dictionary<string, double>> listDicsFai = new List<Dictionary<string, double>>();
			foreach (Dictionary<string, double>[] item in listArrayDicsFai)
			{
				listDicsFai.Add(Core.DicsToAll(item));
			}
			return JudgeResultOutParentFaisCount(listDicsFai, out parentFaisCount, compensateEnable);
		}

		public bool JudgeResultOutParentFaisCount(List<Dictionary<string, double>> listDicsFai, out Dictionary<string, int> parentFaisCount, bool compensateEnable = true)
		{
			int iRet = 0;
			parentFaisCount = new Dictionary<string, int>();
			JudgeResultOutParentFais(listDicsFai[0], out var firstParentFais, compensateEnable);
			foreach (KeyValuePair<string, bool> item in firstParentFais)
			{
				parentFaisCount.Add(item.Key, (!item.Value) ? 1 : 0);
			}
			for (int i = 1; i < listDicsFai.Count; i++)
			{
				JudgeResultOutParentFais(listDicsFai[i], out var parentFais, compensateEnable);
				foreach (KeyValuePair<string, bool> item2 in parentFais)
				{
					if (parentFaisCount.ContainsKey(item2.Key) && !item2.Value)
					{
						parentFaisCount[item2.Key]++;
					}
				}
			}
			return iRet == 0;
		}

		public bool JudgeResultOutParentFaisCount(List<Dictionary<object, object>> listDicsFai, out Dictionary<string, int> parentFaisCount, bool compensateEnable = true)
		{
			int iRet = 0;
			parentFaisCount = new Dictionary<string, int>();
			JudgeResultOutParentFais(listDicsFai[0], out var firstParentFais, compensateEnable);
			foreach (KeyValuePair<string, bool> item in firstParentFais)
			{
				parentFaisCount.Add(item.Key, (!item.Value) ? 1 : 0);
			}
			for (int i = 1; i < listDicsFai.Count; i++)
			{
				JudgeResultOutParentFais(listDicsFai[i], out var parentFais, compensateEnable);
				foreach (KeyValuePair<string, bool> item2 in parentFais)
				{
					if (parentFaisCount.ContainsKey(item2.Key) && !item2.Value)
					{
						parentFaisCount[item2.Key]++;
					}
				}
			}
			return iRet == 0;
		}

		public bool JudgeResultOutParentFaisCount(List<Dictionary<object, object>[]> listArrayDicsFai, out Dictionary<string, int> parentFaisCount, bool compensateEnable = true)
		{
			List<Dictionary<string, double>> listDicsFai = new List<Dictionary<string, double>>();
			foreach (Dictionary<object, object>[] item in listArrayDicsFai)
			{
				listDicsFai.Add(Core.DicsToAll(item));
			}
			return JudgeResultOutParentFaisCount(listDicsFai, out parentFaisCount, compensateEnable);
		}

		public Dictionary<object, object> OutputCompensationValues(Dictionary<object, object> dicsFai)
		{
			Dictionary<string, double> retOutput = OutputCompensationValues(Core.DicsToAll(new Dictionary<object, object>[1] { dicsFai }));
			Dictionary<object, object> allDicFai = new Dictionary<object, object>();
			foreach (KeyValuePair<string, double> t in retOutput)
			{
				allDicFai.Add(t.Key, t.Value);
			}
			return allDicFai;
		}

		public FaiConfig GetFaiConfig(string faiName)
		{
			try
			{
				return FaiConfigs.First((KeyValuePair<Guid, FaiConfig> p) => p.Value.Name == faiName).Value;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public ChildFaiConfig GetChildFaiConfig(string faiName)
		{
			try
			{
				foreach (KeyValuePair<Guid, FaiConfig> fais in FaiConfigs)
				{
					if (fais.Value.IsParent)
					{
						ChildFaiConfig child = GetChildFaiConfig(fais.Value, faiName);
						if (child != null)
						{
							return child;
						}
					}
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		private ChildFaiConfig GetChildFaiConfig(FaiConfig parentFai, string faiName)
		{
			try
			{
				return parentFai.ChildFaiConfigs.First((KeyValuePair<Guid, ChildFaiConfig> p) => p.Value.Name == faiName).Value;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<ChildFaiConfig> GetAllChildFaiConfig(string parentFaiName = null)
		{
			try
			{
				List<ChildFaiConfig> listChilds = new List<ChildFaiConfig>();
				if (string.IsNullOrEmpty(parentFaiName))
				{
					foreach (KeyValuePair<Guid, FaiConfig> faiConfig in FaiConfigs)
					{
						List<ChildFaiConfig> childFais = GetAllChildFaiConfig(faiConfig.Value.Name);
						if (childFais.Count > 0)
						{
							listChilds.AddRange(childFais);
						}
					}
					return listChilds;
				}
				FaiConfig parentFai = GetFaiConfig(parentFaiName);
				if (parentFai.ChildFaiConfigs.Count > 0)
				{
					foreach (KeyValuePair<Guid, ChildFaiConfig> childFaiConfig in parentFai.ChildFaiConfigs)
					{
						listChilds.Add(childFaiConfig.Value);
					}
				}
				return listChilds;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
