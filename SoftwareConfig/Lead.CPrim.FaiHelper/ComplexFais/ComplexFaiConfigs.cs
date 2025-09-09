using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lead.CPrim.FaiHelper.ComplexFais
{
	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class ComplexChildFai
	{
		private string _alias;

		public bool Enable { get; set; }

		public int Index { get; set; }

		public bool IsNonnegativeTo0 { get; set; }

		public bool IsNonnegativeToPositive { get; set; }

		public bool IsOutput { get; set; }

		public bool IsDishist { get; set; }

		public string Name { get; set; }

		public string Alias
		{
			get
			{
				return string.IsNullOrEmpty(_alias) ? Name : _alias;
			}
			set
			{
				_alias = value;
			}
		}

		public int CaveCount { get; set; }

		public double Normal { get; set; }

		public double TolLow { get; set; }

		public double TolUp { get; set; }

		public double TolLow2 { get; set; }

		public double TolUp2 { get; set; }

		public List<Offset> Offsets { get; set; }

		public ComplexChildFai()
		{
			Name = "";
			Alias = "";
			Enable = true;
			IsOutput = true;
			IsDishist = false;
			IsNonnegativeTo0 = false;
			IsNonnegativeToPositive = false;
			Normal = 0.0;
			TolUp = 999.999;
			TolLow = -999.999;
			TolUp2 = 0.0;
			TolLow2 = 0.0;
			Index = -1;
			CaveCount = 1;
			Offsets = new List<Offset>();
		}

		public ComplexChildFai(int index, int caveCount)
		{
			Name = "";
			Alias = "";
			Enable = true;
			IsOutput = true;
			IsDishist = false;
			IsNonnegativeTo0 = false;
			IsNonnegativeToPositive = false;
			Normal = 0.0;
			TolUp = 999.999;
			TolLow = -999.999;
			TolUp2 = 0.0;
			TolLow2 = 0.0;
			Index = index;
			CaveCount = caveCount;
			Offsets = new List<Offset>();
			for (int i = 0; i < caveCount; i++)
			{
				Offsets.Add(new Offset(i));
			}
		}

		public ComplexChildFai(string name, string alias, bool enable, bool isOutput, bool isDishist, bool isNonnegativeTo0, bool isNonnegativeToPositive, double normal, double tolUp, double tolLow, int index)
		{
			Name = name;
			Alias = alias;
			Enable = enable;
			IsOutput = isOutput;
			IsDishist = isDishist;
			IsNonnegativeTo0 = isNonnegativeTo0;
			IsNonnegativeToPositive = isNonnegativeToPositive;
			Normal = normal;
			TolUp = tolUp;
			TolLow = tolLow;
			TolUp2 = 0.0;
			TolLow2 = 0.0;
			Index = index;
			CaveCount = 1;
			Offsets = new List<Offset>();
		}

		public string CsvValue()
		{
			string valueStr = "";
			valueStr = valueStr + Name + ",";
			valueStr = valueStr + Alias + ",";
			valueStr = valueStr + Enable + ",";
			valueStr = valueStr + IsOutput + ",";
			valueStr = valueStr + IsDishist + ",";
			valueStr += " ,";
			valueStr += " ,";
			valueStr = valueStr + IsNonnegativeTo0 + ",";
			valueStr = valueStr + IsNonnegativeToPositive + ",";
			valueStr = valueStr + Normal + ",";
			valueStr = valueStr + TolUp + ",";
			valueStr = valueStr + TolLow + ",";
			valueStr = valueStr + TolUp2 + ",";
			valueStr = valueStr + TolLow2 + ",";
			valueStr += "子集,";
			valueStr += " ,";
			CaveCount = Offsets.Count;
			valueStr += CaveCount;
			for (int j = 0; j < CaveCount; j++)
			{
				valueStr = valueStr + "," + Offsets[j].Compensation;
			}
			for (int i = 0; i < CaveCount; i++)
			{
				valueStr = valueStr + "," + Offsets[i].CompensationFactor;
			}
			return valueStr;
		}

		public void CsvToValue(string strValue)
		{
			string[] valuses = strValue.Split(',');
			Name = valuses[0];
			Alias = valuses[1];
			Enable = !bool.TryParse(valuses[2], out var en) || en;
			IsOutput = !bool.TryParse(valuses[3], out var output) || output;
			IsDishist = bool.TryParse(valuses[4], out var dishis) && dishis;
			IsNonnegativeTo0 = bool.TryParse(valuses[7], out var t0) && t0;
			IsNonnegativeToPositive = bool.TryParse(valuses[8], out var tPostive) && tPostive;
			Normal = (double.TryParse(valuses[9], out var normal) ? normal : 0.0);
			TolUp = (double.TryParse(valuses[10], out var up) ? up : 999.99);
			TolLow = (double.TryParse(valuses[11], out var low) ? low : (-999.99));
			TolUp2 = (double.TryParse(valuses[12], out var up2) ? up2 : 0.0);
			TolLow2 = (double.TryParse(valuses[13], out var low2) ? low2 : 0.0);
			CaveCount = (int.TryParse(valuses[16], out var caveCount) ? caveCount : 0);
			for (int i = 0; i < CaveCount; i++)
			{
				Offset offset = new Offset
				{
					Index = i,
					Compensation = double.Parse(valuses[17 + i]),
					CompensationFactor = double.Parse(valuses[17 + CaveCount + i])
				};
				Offsets.Add(offset);
			}
		}
	}



	[JsonObject(/*Could not decode attribute arguments.*/)]
	public class ComplexFai
	{
		private string _alias;

		public ConcurrentDictionary<Guid, ComplexChildFai> ChildFaiConfigs { get; set; }

		public List<Offset> Offsets { get; set; }

		public bool Enable { get; set; } = true;


		public int Index { get; set; } = -1;


		public bool IsNonnegativeTo0 { get; set; }

		public bool IsNonnegativeToPositive { get; set; }

		public bool IsOutput { get; set; } = true;


		public bool IsDishist { get; set; } = false;


		public bool IsParent { get; set; } = false;


		public string Name { get; set; } = "";


		public string Alias
		{
			get
			{
				return string.IsNullOrEmpty(_alias) ? Name : _alias;
			}
			set
			{
				_alias = value;
			}
		}

		public double Normal { get; set; } = 0.0;


		public double TolLow { get; set; } = -999.999;


		public double TolUp { get; set; } = 999.999;


		public double TolLow2 { get; set; } = 0.0;


		public double TolUp2 { get; set; } = 0.0;


		public int CaveCount { get; set; } = 5;


		public AglType AglSelect { get; set; } = AglType.None;


		public double Ki { get; set; } = 0.0;


		public ComplexFai(int caveCnt = 1)
		{
			Name = "";
			Alias = "";
			Enable = true;
			IsOutput = true;
			IsDishist = false;
			IsParent = false;
			IsNonnegativeTo0 = false;
			IsNonnegativeToPositive = false;
			Normal = 0.0;
			TolUp = 999.999;
			TolLow = -999.999;
			TolUp2 = 0.0;
			TolLow2 = 0.0;
			ChildFaiConfigs = new ConcurrentDictionary<Guid, ComplexChildFai>();
			Index = -1;
			Offsets = new List<Offset>();
			CaveCount = caveCnt;
			Ki = 0.0;
			for (int i = 0; i < caveCnt; i++)
			{
				Offsets.Add(new Offset(i));
			}
		}

		public ComplexFai()
		{
			Name = "";
			Alias = "";
			Enable = true;
			IsOutput = true;
			IsDishist = false;
			IsParent = false;
			IsNonnegativeTo0 = false;
			IsNonnegativeToPositive = false;
			Normal = 0.0;
			TolUp = 999.999;
			TolLow = -999.999;
			TolUp2 = 0.0;
			TolLow2 = 0.0;
			ChildFaiConfigs = new ConcurrentDictionary<Guid, ComplexChildFai>();
			Index = -1;
			Ki = 0.0;
			Offsets = new List<Offset>();
			CaveCount = 1;
		}

		public ComplexFai(int index, int caveCnt = 1)
		{
			Name = "";
			Alias = "";
			Enable = true;
			IsOutput = true;
			IsDishist = false;
			IsParent = false;
			IsNonnegativeTo0 = false;
			IsNonnegativeToPositive = false;
			Normal = 0.0;
			TolUp = 999.999;
			TolLow = -999.999;
			ChildFaiConfigs = new ConcurrentDictionary<Guid, ComplexChildFai>();
			Index = index;
			Offsets = new List<Offset>();
			CaveCount = caveCnt;
			Ki = 0.0;
			for (int i = 0; i < caveCnt; i++)
			{
				Offsets.Add(new Offset(i));
			}
		}

		public ComplexFai(string name, string alias, bool enable, bool isOutput, bool isDishist, bool isParent, bool isNonnegativeTo0, bool isNonnegativeToPositive, double normal, double tolUp, double tolLow, double tolUp2, double tolLow2, double ki, List<Offset> offsets, int index)
		{
			Name = name;
			Alias = alias;
			Enable = enable;
			IsOutput = isOutput;
			IsDishist = isDishist;
			IsParent = isParent;
			IsNonnegativeTo0 = isNonnegativeTo0;
			IsNonnegativeToPositive = isNonnegativeToPositive;
			Normal = normal;
			TolUp = tolUp;
			TolLow = tolLow;
			TolUp2 = tolUp2;
			TolLow2 = tolLow2;
			Index = index;
			Ki = ki;
			Offsets = offsets;
			CaveCount = offsets.Count;
			ChildFaiConfigs = new ConcurrentDictionary<Guid, ComplexChildFai>();
		}

		public string CsvHeader()
		{
			string header = "名称,别名,开判,输出,直方图,集合,算法类型,非正取零,非正取正,Norminal,Tol+,Tol-,严收+,严收-,是否子集,Ki,穴位数";
			for (int j = 0; j < CaveCount; j++)
			{
				header += $",穴位{j}补偿值";
			}
			for (int i = 0; i < CaveCount; i++)
			{
				header += $",穴位{i}补偿系数";
			}
			return header;
		}

		public string CsvValue()
		{
			string valueStr = "";
			valueStr = valueStr + Name + ",";
			valueStr = valueStr + Alias + ",";
			valueStr = valueStr + Enable + ",";
			valueStr = valueStr + IsOutput + ",";
			valueStr = valueStr + IsDishist + ",";
			valueStr = valueStr + IsParent + ",";
			valueStr = string.Concat(valueStr, AglSelect, ",");
			valueStr = valueStr + IsNonnegativeTo0 + ",";
			valueStr = valueStr + IsNonnegativeToPositive + ",";
			valueStr = valueStr + Normal + ",";
			valueStr = valueStr + TolUp + ",";
			valueStr = valueStr + TolLow + ",";
			valueStr = valueStr + TolUp2 + ",";
			valueStr = valueStr + TolLow2 + ",";
			valueStr += "父集,";
			valueStr = ((!(AglSelect.ToString() == AglType.Profile.ToString())) ? (valueStr + " ,") : (valueStr + Ki + ","));
			CaveCount = Offsets.Count;
			valueStr += CaveCount;
			for (int j = 0; j < CaveCount; j++)
			{
				valueStr = valueStr + "," + Offsets[j].Compensation;
			}
			for (int i = 0; i < CaveCount; i++)
			{
				valueStr = valueStr + "," + Offsets[i].CompensationFactor;
			}
			return valueStr;
		}

		public void CsvToValue(string strValue)
		{
			string[] valuses = strValue.Split(',');
			Name = valuses[0];
			Alias = valuses[1];
			Enable = !bool.TryParse(valuses[2], out var en) || en;
			IsOutput = !bool.TryParse(valuses[3], out var output) || output;
			IsDishist = bool.TryParse(valuses[4], out var isDishist) && isDishist;
			IsParent = bool.TryParse(valuses[5], out var isparent) && isparent;
			AglSelect = (Enum.TryParse<AglType>(valuses[6], out var aglType) ? aglType : AglType.None);
			IsNonnegativeTo0 = bool.TryParse(valuses[7], out var t0) && t0;
			IsNonnegativeToPositive = bool.TryParse(valuses[8], out var tPostive) && tPostive;
			Normal = (double.TryParse(valuses[9], out var normal) ? normal : 0.0);
			TolUp = (double.TryParse(valuses[10], out var up) ? up : 999.99);
			TolLow = (double.TryParse(valuses[11], out var low) ? low : (-999.99));
			TolUp2 = (double.TryParse(valuses[12], out var up2) ? up2 : 0.0);
			TolLow2 = (double.TryParse(valuses[13], out var low2) ? low2 : 0.0);
			if (AglSelect == AglType.Profile)
			{
				Ki = double.Parse(valuses[15]);
			}
			CaveCount = int.Parse(valuses[16]);
			for (int i = 0; i < CaveCount; i++)
			{
				Offset offset = new Offset
				{
					Index = i,
					Compensation = double.Parse(valuses[17 + i]),
					CompensationFactor = double.Parse(valuses[17 + CaveCount + i])
				};
				Offsets.Add(offset);
			}
		}

		private List<Offset> GetOffsets(string value)
		{
			string[] offsets = value.Split(')');
			List<Offset> offsetList = new List<Offset>();
			for (int i = 0; i < offsets.Length; i++)
			{
				if (!string.IsNullOrEmpty(offsets[i]))
				{
					Offset offset = new Offset();
					string[] result = offsets[i].Remove(0, 1).Split(' ');
					offset.Index = int.Parse(result[0]);
					offset.Compensation = double.Parse(result[1]);
					offset.CompensationFactor = double.Parse(result[2]);
					offsetList.Add(offset);
				}
			}
			return offsetList;
		}
	}



	public class ComplexFaiConfigs
	{
		private Control _configUi;

		private bool _isSelected;

		private FaiManager _manager;

		[JsonIgnore]
		public Control ConfigUi => _configUi;

		public bool Enable { get; set; }

		public ConcurrentDictionary<Guid, ComplexFai> FaiConfigs { get; set; }

		public Guid Gid { get; set; }

		public bool IsOutput { get; set; }

		public int CaveCnt { get; set; }

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
						this.OnEventSelected?.Invoke(this);
					}
				}
			}
		}

		public bool IsUpload { get; set; }

		[JsonIgnore]
		public FaiManager Manager => _manager;

		public string Name { get; set; }

		public event UiSelected OnEventSelected;

		public ComplexFaiConfigs(int caveCnt = 1)
		{
			Gid = Guid.NewGuid();
			Name = "";
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			FaiConfigs = new ConcurrentDictionary<Guid, ComplexFai>();
			_isSelected = false;
			_configUi = new ComplexFaiControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = FaiManager.Instance;
			CaveCnt = caveCnt;
		}

		public ComplexFaiConfigs()
		{
			Gid = Guid.NewGuid();
			Name = "";
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			FaiConfigs = new ConcurrentDictionary<Guid, ComplexFai>();
			_isSelected = false;
			_configUi = new ComplexFaiControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = FaiManager.Instance;
			CaveCnt = 1;
		}

		public ComplexFaiConfigs(Guid gid, string name, ConcurrentDictionary<Guid, ComplexFai> faiConfigs, FaiManager manager, int caveCnt = 1)
		{
			Gid = gid;
			Name = name;
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			FaiConfigs = faiConfigs;
			_isSelected = false;
			_configUi = new ComplexFaiControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
			CaveCnt = caveCnt;
		}

		public ComplexFaiConfigs(string name, ConcurrentDictionary<Guid, ComplexFai> faiConfigs, FaiManager manager, int caveCnt = 1)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			FaiConfigs = faiConfigs;
			_isSelected = false;
			_configUi = new ComplexFaiControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
			CaveCnt = caveCnt;
		}

		public ComplexFaiConfigs(string name, FaiManager manager, int caveCnt = 1)
		{
			Gid = Guid.NewGuid();
			Name = name;
			Enable = true;
			IsOutput = true;
			IsUpload = true;
			FaiConfigs = new ConcurrentDictionary<Guid, ComplexFai>();
			_isSelected = false;
			_configUi = new ComplexFaiControl(this)
			{
				Dock = DockStyle.Top
			};
			_manager = manager;
			CaveCnt = caveCnt;
		}

		/// <summary>
		/// 对传入的Fai值进行补偿和计算处理
		/// </summary>
		/// <param name="dicsFai">FAI原始值</param>
		/// <param name="childFais">处理过后的各集合项的FAI子集</param>
		/// <param name="cavityNum">穴位号</param>
		/// <param name="compensateEnable">是否补偿运算</param>
		/// <returns>处理过后的FAI集合（不包含子集）</returns>
		internal Dictionary<string, double> GetComplexFais(Dictionary<string, double> dicsFai, out Dictionary<string, double> childFais, int cavityNum = 1, bool compensateEnable = true)
		{
			Dictionary<string, double> outputValues = new Dictionary<string, double>();
			childFais = new Dictionary<string, double>();
			foreach (KeyValuePair<Guid, ComplexFai> faiConfig in FaiConfigs)
			{
				if (!faiConfig.Value.IsParent)
				{
					double newFaiValue2 = 0.0;
					if (!dicsFai.TryGetValue(faiConfig.Value.Name, out var faiValue))
					{
						continue;
					}
					if (compensateEnable)
					{
						newFaiValue2 = faiValue * faiConfig.Value.Offsets[cavityNum - 1].CompensationFactor + faiConfig.Value.Offsets[cavityNum - 1].Compensation;
					}
					if (faiValue < 0.0)
					{
						if (faiConfig.Value.IsNonnegativeTo0)
						{
							newFaiValue2 = 0.0;
						}
						else if (faiConfig.Value.IsNonnegativeToPositive)
						{
							newFaiValue2 = 0.0 - faiValue;
						}
					}
					outputValues[faiConfig.Value.Name] = newFaiValue2;
					continue;
				}
				foreach (KeyValuePair<Guid, ComplexChildFai> childFaiConfig in faiConfig.Value.ChildFaiConfigs.OrderBy((KeyValuePair<Guid, ComplexChildFai> p) => p.Value.Index))
				{
					double newFaiValue3 = 0.0;
					string childName = "";
					childName = ((faiConfig.Value.AglSelect == AglType.Distance) ? childFaiConfig.Value.Name.Split(';')[1] : childFaiConfig.Value.Name);
					if (childFais.ContainsKey(childName) || !dicsFai.TryGetValue(childName, out var childFaiValue))
					{
						continue;
					}
					if (compensateEnable)
					{
						newFaiValue3 = childFaiValue * childFaiConfig.Value.Offsets[cavityNum - 1].CompensationFactor + childFaiConfig.Value.Offsets[cavityNum - 1].Compensation;
					}
					if (childFaiValue < 0.0)
					{
						if (childFaiConfig.Value.IsNonnegativeTo0)
						{
							newFaiValue3 = 0.0;
						}
						else if (childFaiConfig.Value.IsNonnegativeToPositive)
						{
							newFaiValue3 = 0.0 - childFaiValue;
						}
					}
					childFais[childFaiConfig.Value.Name] = newFaiValue3;
				}
			}
			foreach (KeyValuePair<Guid, ComplexFai> faiConfig2 in FaiConfigs)
			{
				double parentFaiValue = 0.0;
				if (!faiConfig2.Value.IsParent)
				{
					continue;
				}
				if (faiConfig2.Value.AglSelect == AglType.Distance)
				{
					string firstChildName = faiConfig2.Value.ChildFaiConfigs.FirstOrDefault().Value.Name.Split(';')[1];
					string lastChildName = faiConfig2.Value.ChildFaiConfigs.LastOrDefault().Value.Name.Split(';')[1];
					parentFaiValue = Math.Abs((childFais.ContainsKey(firstChildName) ? childFais[firstChildName] : 666.6) - (childFais.ContainsKey(lastChildName) ? childFais[lastChildName] : 0.0));
				}
				else if (faiConfig2.Value.AglSelect == AglType.Flatness)
				{
					List<double> lstValues3 = new List<double>();
					foreach (KeyValuePair<Guid, ComplexChildFai> child3 in faiConfig2.Value.ChildFaiConfigs)
					{
						if (childFais.TryGetValue(child3.Value.Name, out var childValue3))
						{
							lstValues3.Add(childValue3);
						}
					}
					parentFaiValue = ((lstValues3.Count > 0) ? (lstValues3.Max() - lstValues3.Min()) : 666.6);
				}
				else if (faiConfig2.Value.AglSelect == AglType.Parallelism)
				{
					List<double> lstValues2 = new List<double>();
					foreach (KeyValuePair<Guid, ComplexChildFai> child2 in faiConfig2.Value.ChildFaiConfigs)
					{
						if (childFais.TryGetValue(child2.Value.Name, out var childValue2))
						{
							lstValues2.Add(childValue2);
						}
					}
					parentFaiValue = ((lstValues2.Count > 0) ? (lstValues2.Max() - lstValues2.Min()) : 666.6);
				}
				else if (faiConfig2.Value.AglSelect == AglType.Profile)
				{
					List<double> lstValues = new List<double>();
					foreach (KeyValuePair<Guid, ComplexChildFai> child in faiConfig2.Value.ChildFaiConfigs)
					{
						if (childFais.TryGetValue(child.Value.Name, out var childValue))
						{
							lstValues.Add(Math.Abs(faiConfig2.Value.Ki - Math.Abs(childValue)));
						}
					}
					parentFaiValue = ((lstValues.Count > 0) ? (2.0 * lstValues.Max()) : 666.6);
				}
				double value;
				if (faiConfig2.Value.AglSelect != 0)
				{
					outputValues[faiConfig2.Value.Name] = parentFaiValue;
				}
				else if (dicsFai.TryGetValue(faiConfig2.Value.Name, out value))
				{
					outputValues[faiConfig2.Value.Name] = value;
				}
				if (!outputValues.ContainsKey(faiConfig2.Value.Name))
				{
					continue;
				}
				double oldFaiValue = outputValues[faiConfig2.Value.Name];
				double newFaiValue = 0.0;
				if (compensateEnable)
				{
					newFaiValue = oldFaiValue * faiConfig2.Value.Offsets[cavityNum - 1].CompensationFactor + faiConfig2.Value.Offsets[cavityNum - 1].Compensation;
				}
				if (oldFaiValue < 0.0)
				{
					if (faiConfig2.Value.IsNonnegativeTo0)
					{
						newFaiValue = 0.0;
					}
					else if (faiConfig2.Value.IsNonnegativeToPositive)
					{
						newFaiValue = 0.0 - oldFaiValue;
					}
				}
				outputValues[faiConfig2.Value.Name] = newFaiValue;
			}
			return outputValues;
		}

		/// <summary>
		/// 判断结果
		/// </summary>
		/// <param name="dicsFai">FAI原始值</param>
		/// <param name="allFaiResults">各FAI项的结果</param>
		/// <param name="sortedFais">已排序后的FAI带补偿值（按Index升序）</param>
		/// <param name="dicFaisForHistorgam">已补偿并排序后的FAI配置与值（按Index升序），多用于直方图显示</param>
		/// <param name="cavityNum">穴位号</param>
		/// <param name="compensateEnable">是否补偿运算</param>
		/// <param name="overStepValue">公差超出值</param>
		/// <returns>利用当前复杂FAI配置判断的总体结果：1-公差范围以内，2-尺寸收严，-1-超出图纸公差（overStepValue）以内，-2-超出图纸公差（overStepValue）以外，-3-有异常值</returns>
		internal int JudgeResult(Dictionary<string, double> dicsFai, out Dictionary<string, int> allFaiResults, out Dictionary<string, double> sortedFais, out Dictionary<string, Fai> dicFaisForHistorgam, int cavityNum = 1, bool compensateEnable = true, double overStepValue = 0.01)
		{
			allFaiResults = new Dictionary<string, int>();
			sortedFais = new Dictionary<string, double>();
			dicFaisForHistorgam = new Dictionary<string, Fai>();
			Dictionary<string, double> sortFais = new Dictionary<string, double>();
			Dictionary<string, double> childFais;
			Dictionary<string, double> processedFais = GetComplexFais(dicsFai, out childFais, cavityNum, compensateEnable);
			Dictionary<string, int> dicSort = new Dictionary<string, int>();
			List<string> lstNotOutput = new List<string>();
			foreach (KeyValuePair<Guid, ComplexFai> faiConfig in FaiConfigs)
			{
				dicSort[faiConfig.Value.Alias] = faiConfig.Value.Index;
				if (!faiConfig.Value.IsOutput)
				{
					lstNotOutput.Add(faiConfig.Value.Alias);
				}
				if (!processedFais.TryGetValue(faiConfig.Value.Name, out var faiValue))
				{
					continue;
				}
				if (faiConfig.Value.Alias != faiConfig.Value.Name && dicsFai.ContainsKey(faiConfig.Value.Name))
				{
					dicsFai[faiConfig.Value.Alias] = dicsFai[faiConfig.Value.Name];
					dicsFai.Remove(faiConfig.Value.Name);
				}
				sortFais[faiConfig.Value.Alias] = faiValue;
				if (faiConfig.Value.IsDishist)
				{
					dicFaisForHistorgam[faiConfig.Value.Alias] = new Fai(faiConfig.Value.Alias, faiValue, faiConfig.Value.Normal, faiConfig.Value.TolUp, faiConfig.Value.TolLow, faiConfig.Value.Index);
				}
				if (faiConfig.Value.IsParent)
				{
					int lastIndex = (faiConfig.Value.Index + 1) * 1000;
					foreach (KeyValuePair<Guid, ComplexChildFai> childFaiConfig in faiConfig.Value.ChildFaiConfigs)
					{
						string childName = ((faiConfig.Value.AglSelect == AglType.Distance) ? childFaiConfig.Value.Name.Split(';')[1] : childFaiConfig.Value.Name);
						if (!childFais.TryGetValue(childName, out var childFaiValue))
						{
							continue;
						}
						if (faiConfig.Value.AglSelect == AglType.Distance && !string.IsNullOrEmpty(childFaiConfig.Value.Alias))
						{
							string[] arrayName = childFaiConfig.Value.Alias.Split(';');
							if (arrayName.Length >= 2)
							{
								childFaiConfig.Value.Alias = arrayName[1];
							}
						}
						if (childFaiConfig.Value.Alias != childName && dicsFai.ContainsKey(childName))
						{
							dicsFai[childFaiConfig.Value.Alias] = dicsFai[childName];
							dicsFai.Remove(childName);
						}
						sortFais[childFaiConfig.Value.Alias] = childFaiValue;
						if (childFaiConfig.Value.IsOutput)
						{
							if (!dicSort.ContainsKey(childFaiConfig.Value.Alias) || dicSort[childFaiConfig.Value.Alias] > lastIndex + childFaiConfig.Value.Index)
							{
								dicSort[childFaiConfig.Value.Alias] = lastIndex + childFaiConfig.Value.Index;
								if (faiConfig.Value.AglSelect != AglType.Distance && childFaiConfig.Value.IsDishist && !dicFaisForHistorgam.ContainsKey(childFaiConfig.Value.Alias))
								{
									dicFaisForHistorgam[childFaiConfig.Value.Alias] = new Fai(childFaiConfig.Value.Alias, childFaiValue, childFaiConfig.Value.Normal, childFaiConfig.Value.TolUp, childFaiConfig.Value.TolLow, lastIndex + childFaiConfig.Value.Index);
								}
							}
						}
						else
						{
							lstNotOutput.Add(childFaiConfig.Value.Alias);
						}
					}
				}
				if (!faiConfig.Value.Enable)
				{
					continue;
				}
				if (faiConfig.Value.IsParent && faiConfig.Value.AglSelect == AglType.None)
				{
					List<int> lstResults = new List<int>();
					foreach (KeyValuePair<Guid, ComplexChildFai> childFaiConfig2 in faiConfig.Value.ChildFaiConfigs)
					{
						if (!childFais.TryGetValue(childFaiConfig2.Value.Name, out var childFaiValue2) || !childFaiConfig2.Value.Enable)
						{
							continue;
						}
						if (childFaiValue2 >= 900.0 || childFaiValue2 <= -900.0)
						{
							allFaiResults[childFaiConfig2.Value.Alias] = -3;
							lstResults.Add(-3);
							continue;
						}
						double newTolUp = childFaiConfig2.Value.TolUp - childFaiConfig2.Value.TolUp2;
						double newTolLow = childFaiConfig2.Value.TolLow - childFaiConfig2.Value.TolLow2;
						if (Core.DoubleEquals(childFaiValue2, childFaiConfig2.Value.Normal + newTolUp) || Core.DoubleEquals(childFaiValue2, childFaiConfig2.Value.Normal + newTolLow))
						{
							allFaiResults[childFaiConfig2.Value.Alias] = 2;
							lstResults.Add(2);
							continue;
						}
						if (childFaiValue2 < childFaiConfig2.Value.Normal + newTolUp && childFaiValue2 > childFaiConfig2.Value.Normal + newTolLow)
						{
							allFaiResults[childFaiConfig2.Value.Alias] = 2;
							lstResults.Add(2);
							continue;
						}
						if (Core.DoubleEquals(childFaiValue2, childFaiConfig2.Value.Normal + childFaiConfig2.Value.TolUp) || Core.DoubleEquals(childFaiValue2, childFaiConfig2.Value.Normal + childFaiConfig2.Value.TolLow))
						{
							allFaiResults[childFaiConfig2.Value.Alias] = 1;
							lstResults.Add(1);
							continue;
						}
						if (childFaiValue2 < childFaiConfig2.Value.Normal + childFaiConfig2.Value.TolUp && childFaiValue2 > childFaiConfig2.Value.Normal + childFaiConfig2.Value.TolLow)
						{
							allFaiResults[childFaiConfig2.Value.Alias] = 1;
							lstResults.Add(1);
							continue;
						}
						double newTolUp3 = childFaiConfig2.Value.TolUp + overStepValue;
						double newTolLow3 = childFaiConfig2.Value.TolLow - overStepValue;
						if (Core.DoubleEquals(childFaiValue2, childFaiConfig2.Value.Normal + newTolUp3) || Core.DoubleEquals(childFaiValue2, childFaiConfig2.Value.Normal + newTolLow3))
						{
							allFaiResults[childFaiConfig2.Value.Alias] = -1;
							lstResults.Add(-1);
						}
						else if (childFaiValue2 < childFaiConfig2.Value.Normal + newTolUp3 && childFaiValue2 > childFaiConfig2.Value.Normal + newTolLow3)
						{
							allFaiResults[childFaiConfig2.Value.Alias] = -1;
							lstResults.Add(-1);
						}
						else
						{
							allFaiResults[childFaiConfig2.Value.Alias] = -2;
							lstResults.Add(-2);
						}
					}
					if (lstResults.All((int p) => p == 2))
					{
						allFaiResults[faiConfig.Value.Alias] = 2;
					}
					else if (lstResults.All((int p) => p == 1))
					{
						allFaiResults[faiConfig.Value.Alias] = 1;
					}
					else if (lstResults.Any((int p) => p == -3))
					{
						allFaiResults[faiConfig.Value.Alias] = -3;
					}
					else if (lstResults.Any((int p) => p == -2))
					{
						allFaiResults[faiConfig.Value.Alias] = -2;
					}
					else if (lstResults.Any((int p) => p == -1))
					{
						allFaiResults[faiConfig.Value.Alias] = -1;
					}
					else
					{
						allFaiResults[faiConfig.Value.Alias] = 1;
					}
					continue;
				}
				if (faiValue >= 900.0 || faiValue <= -900.0)
				{
					allFaiResults[faiConfig.Value.Alias] = -3;
					continue;
				}
				double newTolUp2 = faiConfig.Value.TolUp - faiConfig.Value.TolUp2;
				double newTolLow2 = faiConfig.Value.TolLow - faiConfig.Value.TolLow2;
				if (Core.DoubleEquals(faiValue, faiConfig.Value.Normal + newTolUp2) || Core.DoubleEquals(faiValue, faiConfig.Value.Normal + newTolLow2))
				{
					allFaiResults[faiConfig.Value.Alias] = 2;
					continue;
				}
				if (faiValue < faiConfig.Value.Normal + newTolUp2 && faiValue > faiConfig.Value.Normal + newTolLow2)
				{
					allFaiResults[faiConfig.Value.Alias] = 2;
					continue;
				}
				if (Core.DoubleEquals(faiValue, faiConfig.Value.Normal + faiConfig.Value.TolUp) || Core.DoubleEquals(faiValue, faiConfig.Value.Normal + faiConfig.Value.TolLow))
				{
					allFaiResults[faiConfig.Value.Alias] = 1;
					continue;
				}
				if (faiValue < faiConfig.Value.Normal + faiConfig.Value.TolUp && faiValue > faiConfig.Value.Normal + faiConfig.Value.TolLow)
				{
					allFaiResults[faiConfig.Value.Alias] = 1;
					continue;
				}
				double newTolUp4 = faiConfig.Value.TolUp + overStepValue;
				double newTolLow4 = faiConfig.Value.TolLow - overStepValue;
				if (Core.DoubleEquals(faiValue, faiConfig.Value.Normal + newTolUp4) || Core.DoubleEquals(faiValue, faiConfig.Value.Normal + newTolLow4))
				{
					allFaiResults[faiConfig.Value.Alias] = -1;
				}
				else if (faiValue < faiConfig.Value.Normal + newTolUp4 && faiValue > faiConfig.Value.Normal + newTolLow4)
				{
					allFaiResults[faiConfig.Value.Alias] = -1;
				}
				else
				{
					allFaiResults[faiConfig.Value.Alias] = -2;
				}
			}
			if (dicSort.Count > 0)
			{
				IOrderedEnumerable<KeyValuePair<string, int>> dicSorted = dicSort.OrderBy((KeyValuePair<string, int> p) => p.Value);
				foreach (KeyValuePair<string, int> sort in dicSorted)
				{
					if (sortFais.ContainsKey(sort.Key) && !lstNotOutput.Contains(sort.Key))
					{
						sortedFais.Add(sort.Key, sortFais[sort.Key]);
					}
				}
				foreach (KeyValuePair<string, double> fai in dicsFai)
				{
					if (!sortedFais.ContainsKey(fai.Key) && !lstNotOutput.Contains(fai.Key))
					{
						sortedFais.Add(fai.Key, fai.Value);
					}
				}
			}
			if (dicFaisForHistorgam.Count > 0)
			{
				dicFaisForHistorgam = dicFaisForHistorgam.OrderBy((KeyValuePair<string, Fai> p) => p.Value.Index).ToDictionary((KeyValuePair<string, Fai> o) => o.Key, (KeyValuePair<string, Fai> p) => p.Value);
			}
			if (allFaiResults.Count > 0)
			{
				if (allFaiResults.All((KeyValuePair<string, int> p) => p.Value == 2))
				{
					return 2;
				}
				if (allFaiResults.All((KeyValuePair<string, int> p) => p.Value == 1))
				{
					return 1;
				}
				if (allFaiResults.Any((KeyValuePair<string, int> p) => p.Value == -3))
				{
					return -3;
				}
				if (allFaiResults.Any((KeyValuePair<string, int> p) => p.Value == -2))
				{
					return -2;
				}
				if (allFaiResults.Any((KeyValuePair<string, int> p) => p.Value == -1))
				{
					return -1;
				}
				return 1;
			}
			return 0;
		}

		internal int JudgeResult(Dictionary<string, double> dicsFai, out Dictionary<string, int> allFaiResults, out Dictionary<object, object> sortedFais, out Dictionary<string, Fai> dicFaisForHistorgam, int cavityNum = 1, bool compensateEnable = true, double overStepValue = 0.01)
		{
			Dictionary<string, double> dicSorted;
			int result = JudgeResult(dicsFai, out allFaiResults, out dicSorted, out dicFaisForHistorgam, cavityNum, compensateEnable, overStepValue);
			sortedFais = Core.DicsToAll2(new Dictionary<string, double>[1] { dicSorted });
			return result;
		}

		internal int JudgeResult(Dictionary<object, object> dicsFai, out Dictionary<string, int> allFaiResults, out Dictionary<object, object> sortedFais, out Dictionary<string, Fai> dicFaisForHistorgam, int cavityNum = 1, bool compensateEnable = true, double overStepValue = 0.01)
		{
			return JudgeResult(Core.DicsToAll(new Dictionary<object, object>[1] { dicsFai }), out allFaiResults, out sortedFais, out dicFaisForHistorgam, cavityNum, compensateEnable, overStepValue);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
