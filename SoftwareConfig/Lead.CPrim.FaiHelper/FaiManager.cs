using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.FaiHelper.ComplexFais;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;

namespace Lead.CPrim.FaiHelper
{
	/// <summary>FAI管理器</summary>
	public class FaiManager
	{
		#region Field
		/// <summary>FAI管理器对象</summary>
		private static readonly FaiManager _instance = new FaiManager();
		/// <summary>当前产品名称</summary>
		private string _currentProductName;
		/// <summary>产品集合配置</summary>
		private ConcurrentDictionary<string, ProductFaiConfigs> _products;
		/// <summary>工站级_配置管理器</summary>
		private StationFaiConfigs _config;
		
        private string _faiConfigsFilePath;
		/// <summary>FAI参数配置</summary>
        private Control _faiConfigUi;
		#endregion



		#region Prop
		/// <summary>FAI管理器对象</summary>
		public static FaiManager Instance => _instance;
		/// <summary>当前产品名称</summary>
		public string CurrentProductName => _currentProductName;
		/// <summary>当前产品</summary>
		public ProductFaiConfigs CurrentProduct
		{
			get
			{
				if (!string.IsNullOrEmpty(_currentProductName) && _products.ContainsKey(_currentProductName))
				{
					return _products[_currentProductName];
				}
				return null;
			}
		}
		/// <summary>产品集合配置</summary>
		public ConcurrentDictionary<string, ProductFaiConfigs> Products => _products;
		/// <summary>FAI参数配置</summary>
		public Control FaiConfigUi => _faiConfigUi;
        #endregion



        #region Ctor
        public FaiManager()
        {
			AuthorityManager.OnUpdateLevel += InstanceUpdateLevel;
		}
        #endregion



        #region [FaiConfigControl]调用
        /// <summary>改变当前产品</summary>
        /// <param name="productName">产品名称</param>
        /// <returns>int</returns>
        public int ChangeCurrentProduct(string productName)
        {
            if (string.IsNullOrEmpty(productName) || !_products.ContainsKey(productName))
            {
                _currentProductName = "";
                ((FaiConfigControl)_faiConfigUi).LoadControls(this);
                return -1;
            }
            _currentProductName = productName;
            ((FaiConfigControl)_faiConfigUi).LoadControls(this);
            return 0;
        }
		/// <summary>增加产品</summary>
		/// <param name="newName">产品名称</param>
		/// <returns>int</returns>
		public int AddNewProdcut(string newName)
		{
			if (_products.ContainsKey(newName))
			{
				MessageBox.Show("产品名称重复，请重新操作");
				return -1;
			}
			ProductFaiConfigs newProdcut = new ProductFaiConfigs(newName);
			if (_products.TryAdd(newName, newProdcut))
			{
				ChangeCurrentProduct(newName);
			}
			return 0;
		}
		/// <summary>移除产品</summary>
		/// <param name="name">名称</param>
		/// <returns>int</returns>
		public int RemoveProdcut(string name)
		{
			if (MessageBox.Show("确定要删除该产品信息吗？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes && _products.ContainsKey(name))
			{
				if (_products.TryRemove(name, out var _))
				{
					ChangeCurrentProduct(null);
				}
				return 0;
			}
			return -1;
		}
		/// <summary>复制产品</summary>
		/// <param name="newName">名称</param>
		/// <returns>int</returns>
		public int CopyProdcut(string newName)
		{
			if (_products.ContainsKey(newName))
			{
				MessageBox.Show("产品名称重复，请重新操作");
				return -1;
			}

			ProductFaiConfigs newProdcut = new ProductFaiConfigs(newName);
			newProdcut.SimpleConfigs.Clear();

            foreach (KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfigs in CurrentProduct.SimpleConfigs)
            {
                SimpleFaiConfigs newSimpleFaiConfig = new SimpleFaiConfigs(simpleFaiConfigs.Value.Name, _instance);
                foreach (KeyValuePair<Guid, FaiConfig> faiConfig in simpleFaiConfigs.Value.FaiConfigs)
                {
                    newSimpleFaiConfig.FaiConfigs.TryAdd(faiConfig.Key, faiConfig.Value);
                }
                newProdcut.SimpleConfigs.TryAdd(newSimpleFaiConfig.Gid, newSimpleFaiConfig);
            }

            if (_products.TryAdd(newName, newProdcut))
			{
				ChangeCurrentProduct(newName);
			}
			return 0;
		}
		#endregion



		#region Method_Instance
		/// <summary>响应权限等级改变</summary>
		/// <param name="level"></param>
		private void InstanceUpdateLevel(OpLevel level)
        {
			SetEnable(AuthorityManager.Instance.VerifyLevel3Permission());
        }
		#endregion



		#region Method_ExternalUsing
		public int Save()
		{
			if(!AuthorityManager.Instance.VerifyLevel3Permission(true))
            {
				return -1;
            }
			SaveConfirmForm newSaveConfirmForm = new SaveConfirmForm();
			DialogResult formResult = newSaveConfirmForm.ShowDialog();
			if (formResult != DialogResult.Yes)
			{
				return -1;
			}

			if (string.IsNullOrEmpty(_faiConfigsFilePath))
			{
				MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiManager_ErrMsg_FaiConfigFilePathIsEmpty", "FAI配置文件存储路径为空，不能保存!"));
				return -2;
			}
			if (_config == null)
			{
				_config = new StationFaiConfigs();
			}
			_config.CurrentProductName = _currentProductName;
			_config.Products = _products;
			if (!JsonHelper.SerializeObjectToFile(_config, _faiConfigsFilePath))
			{
				MessageBox.Show(NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiManager_ErrMsg_FaiConfigSaveFail", "FAI配置文件保存不成功!"));
				return -1;
			}
			UIMessageTip.ShowOk(NLocalizer.GetString("Lead_CPrim_FaiHelper_FaiManager_FaiConfigSaveSuccess", "FAI设置保存成功"));
			return 0;
		}
		#endregion



		#region Method_InternalUsing
		/// <summary>使能状态设置</summary>
		/// <param name="enable">true：使能状态；false：非使能状态</param>
		internal void SetEnable(bool enable)
		{
			((FaiConfigControl)FaiConfigUi)?.SetEnable(enable);
		}
		#endregion



		public int Init(string configFilePath)
		{
			try
			{
				if (!File.Exists(configFilePath))
				{
					File.Create(configFilePath).Dispose();
					return -5;
				}
				_faiConfigsFilePath = configFilePath;
				StationFaiConfigs obj = JsonHelper.DeserializeJsonFileToObject<StationFaiConfigs>(configFilePath);
				if (obj != null)
				{
					_products = obj.Products;
					_currentProductName = obj.CurrentProductName;
					return 0;
				}
				_products = new ConcurrentDictionary<string, ProductFaiConfigs>();
				_currentProductName = "";
				return -1;
			}
			catch (Exception)
			{
				_products = new ConcurrentDictionary<string, ProductFaiConfigs>();
				_currentProductName = "";
				return -10;
			}
			finally
			{
				_faiConfigUi = new FaiConfigControl(_instance);
			}
		}

		public Dictionary<string, double> OutputCompensationValues(string faiConfigsName, Dictionary<string, double> dicsFai, string productName = null)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return dicsFai;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return dicsFai;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				if (simpleFaiConfig.Value.Enable)
				{
					return simpleFaiConfig.Value.OutputCompensationValues(dicsFai);
				}
				return dicsFai;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Dictionary<object, object> OutputCompensationValues(string faiConfigsName, Dictionary<object, object> dicsFai, string productName = null)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return dicsFai;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return dicsFai;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				if (simpleFaiConfig.Value.Enable)
				{
					return simpleFaiConfig.Value.OutputCompensationValues(dicsFai);
				}
				return dicsFai;
			}
			catch (Exception)
			{
				return null;
			}
		}


		public bool SimpleJudgeResult(string faiConfigsName, Dictionary<string, double> dicsFai, string productName = null, bool compensateEnable = true)
		{
			return SimpleJudgeResult(faiConfigsName, new Dictionary<string, double>[1] { dicsFai }, productName, compensateEnable);
		}

		public bool SimpleJudgeResult(string faiConfigsName, Dictionary<object, object> dicsFai, string productName = null, bool compensateEnable = true)
		{
			return SimpleJudgeResult(faiConfigsName, new Dictionary<object, object>[1] { dicsFai }, productName, compensateEnable);
		}

		public bool SimpleJudgeResult(string faiConfigsName, Dictionary<string, double>[] arrayDicsFai, string productName = null, bool compensateEnable = true)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResult(arrayDicsFai, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResult(string faiConfigsName, Dictionary<object, object>[] arrayDicsFai, string productName = null, bool compensateEnable = true)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResult(arrayDicsFai, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutAllFais(string faiConfigsName, Dictionary<string, double> dicsFai, out Dictionary<string, bool> allFais, string productName = null, bool compensateEnable = true)
		{
			return SimpleJudgeResultOutAllFais(faiConfigsName, new Dictionary<string, double>[1] { dicsFai }, out allFais, productName, compensateEnable);
		}

		public bool SimpleJudgeResultOutAllFais(string faiConfigsName, Dictionary<object, object> dicsFai, out Dictionary<string, bool> allFais, string productName = null, bool compensateEnable = true)
		{
			return SimpleJudgeResultOutAllFais(faiConfigsName, new Dictionary<object, object>[1] { dicsFai }, out allFais, productName, compensateEnable);
		}

		public bool SimpleJudgeResultOutAllFais(string faiConfigsName, Dictionary<string, double> dicsFai, out Dictionary<string, bool> allFais, out Dictionary<object, object> newFais, string productName = null, bool compensateEnable = true)
		{
			return SimpleJudgeResultOutAllFais(faiConfigsName, new Dictionary<string, double>[1] { dicsFai }, out allFais, out newFais, productName, compensateEnable);
		}

		public bool SimpleJudgeResultOutAllFais(string faiConfigsName, Dictionary<object, object> dicsFai, out Dictionary<string, bool> allFais, out Dictionary<object, object> newFais, string productName = null, bool compensateEnable = true)
		{
			return SimpleJudgeResultOutAllFais(faiConfigsName, new Dictionary<object, object>[1] { dicsFai }, out allFais, out newFais, productName, compensateEnable);
		}

		public bool SimpleJudgeResultOutAllFais(string faiConfigsName, Dictionary<string, double>[] dicsFai, out Dictionary<string, bool> allFais, string productName = null, bool compensateEnable = true)
		{
			allFais = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutAllFais(dicsFai, out allFais, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutAllFais(string faiConfigsName, Dictionary<object, object>[] dicsFai, out Dictionary<string, bool> allFais, string productName = null, bool compensateEnable = true)
		{
			allFais = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutAllFais(dicsFai, out allFais, compensateEnable);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}

		public bool SimpleJudgeResultOutAllFais(string faiConfigsName, Dictionary<string, double>[] dicsFai, out Dictionary<string, bool> allFais, out Dictionary<object, object> newFais, string productName = null, bool compensateEnable = true)
		{
			allFais = null;
			newFais = Core.DicsToAll2(dicsFai);
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutAllFais(dicsFai, out allFais, out newFais, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutAllFais(string faiConfigsName, Dictionary<object, object>[] dicsFai, out Dictionary<string, bool> allFais, out Dictionary<object, object> newFais, string productName = null, bool compensateEnable = true)
		{
			allFais = null;
			newFais = Core.DicsToAll2(dicsFai);
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutAllFais(dicsFai, out allFais, out newFais, compensateEnable);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}

		public bool SimpleJudgeResultOutAllFaisCount(string faiConfigsName, List<Dictionary<string, double>> dicsFai, out Dictionary<string, int> allFaisCount, string productName = null, bool compensateEnable = true)
		{
			allFaisCount = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutAllFaisCount(dicsFai, out allFaisCount, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutAllFaisCount(string faiConfigsName, List<Dictionary<object, object>> dicsFai, out Dictionary<string, int> allFaisCount, string productName = null, bool compensateEnable = true)
		{
			allFaisCount = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutAllFaisCount(dicsFai, out allFaisCount, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutAllFaisCount(string faiConfigsName, List<Dictionary<string, double>[]> dicsFai, out Dictionary<string, int> allFaisCount, string productName = null, bool compensateEnable = true)
		{
			allFaisCount = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutAllFaisCount(dicsFai, out allFaisCount, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutAllFaisCount(string faiConfigsName, List<Dictionary<object, object>[]> dicsFai, out Dictionary<string, int> allFaisCount, string productName = null, bool compensateEnable = true)
		{
			allFaisCount = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutAllFaisCount(dicsFai, out allFaisCount, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutParentFais(string faiConfigsName, Dictionary<string, double> dicsFai, out Dictionary<string, bool> parentFais, string productName = null, bool compensateEnable = true)
		{
			return SimpleJudgeResultOutParentFais(faiConfigsName, new Dictionary<string, double>[1] { dicsFai }, out parentFais, productName, compensateEnable);
		}

		public bool SimpleJudgeResultOutParentFais(string faiConfigsName, Dictionary<object, object> dicsFai, out Dictionary<string, bool> parentFais, string productName = null, bool compensateEnable = true)
		{
			return SimpleJudgeResultOutParentFais(faiConfigsName, new Dictionary<object, object>[1] { dicsFai }, out parentFais, productName, compensateEnable);
		}

		public bool SimpleJudgeResultOutParentFais(string faiConfigsName, Dictionary<string, double>[] dicsFai, out Dictionary<string, bool> parentFais, string productName = null, bool compensateEnable = true)
		{
			parentFais = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutParentFais(dicsFai, out parentFais, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutParentFais(string faiConfigsName, Dictionary<object, object>[] dicsFai, out Dictionary<string, bool> parentFais, string productName = null, bool compensateEnable = true)
		{
			parentFais = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutParentFais(dicsFai, out parentFais, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutParentFaisCount(string faiConfigsName, List<Dictionary<string, double>> dicsFai, out Dictionary<string, int> parentFaisCount, string productName = null, bool compensateEnable = true)
		{
			parentFaisCount = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutParentFaisCount(dicsFai, out parentFaisCount, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutParentFaisCount(string faiConfigsName, List<Dictionary<object, object>> dicsFai, out Dictionary<string, int> parentFaisCount, string productName = null, bool compensateEnable = true)
		{
			parentFaisCount = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutParentFaisCount(dicsFai, out parentFaisCount, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutParentFaisCount(string faiConfigsName, List<Dictionary<string, double>[]> dicsFai, out Dictionary<string, int> parentFaisCount, string productName = null, bool compensateEnable = true)
		{
			parentFaisCount = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutParentFaisCount(dicsFai, out parentFaisCount, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SimpleJudgeResultOutParentFaisCount(string faiConfigsName, List<Dictionary<object, object>[]> dicsFai, out Dictionary<string, int> parentFaisCount, string productName = null, bool compensateEnable = true)
		{
			parentFaisCount = null;
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return false;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return false;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> simpleFaiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				return !simpleFaiConfig.Value.Enable || simpleFaiConfig.Value.JudgeResultOutParentFaisCount(dicsFai, out parentFaisCount, compensateEnable);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public FaiConfig GetFaiConfig(string faiConfigsName, string faiName, string productName = null)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return null;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return null;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> faiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				if (faiConfig.Value == null)
				{
					return null;
				}
				return faiConfig.Value.GetFaiConfig(faiName);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public ChildFaiConfig GetChildFaiConfig(string faiConfigsName, string faiName, string productName = null)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return null;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return null;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> faiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				if (faiConfig.Value == null)
				{
					return null;
				}
				return faiConfig.Value.GetChildFaiConfig(faiName);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public List<ChildFaiConfig> GetAllChildFaiConfig(string faiConfigsName, string faiName = null, string productName = null)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				return null;
			}
			if (Products[productName].SimpleConfigs.Count == 0)
			{
				return null;
			}
			try
			{
				KeyValuePair<Guid, SimpleFaiConfigs> faiConfig = Products[productName].SimpleConfigs.FirstOrDefault((KeyValuePair<Guid, SimpleFaiConfigs> p) => p.Value.Name == faiConfigsName);
				if (faiConfig.Value == null)
				{
					return null;
				}
				return faiConfig.Value.GetAllChildFaiConfig(faiName);
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// 利用复杂FAI配置判断FAI结果
		/// </summary>
		/// <param name="faiConfigsName">复杂FAI配置的名称</param>
		/// <param name="dicsFai">传入的FAI值集合</param>
		/// <param name="allFaiResults">输出每一个FAI项的判断结果</param>
		/// <param name="sortedFais">将传入的FAI值集合根据配置排序后输出</param>
		/// <param name="dicFaisForHistorgam">输出用于传入直方图显示基元</param>
		/// <param name="cavityNum">穴位号</param>
		/// <param name="productName">产品名</param>
		/// <param name="compensateEnable">是否补偿运算</param>
		/// <param name="overStepValue">公差超出值</param>
		/// <returns>利用当前复杂FAI配置判断的总体结果：1-公差范围以内，2-尺寸收严，-1-超出图纸公差（overStepValue）以内，-2-超出图纸公差（overStepValue）以外，-3-有异常值</returns>
		public int ComplexJudgeResult(string faiConfigsName, Dictionary<string, double> dicsFai, out Dictionary<string, int> allFaiResults, out Dictionary<object, object> sortedFais, out Dictionary<string, Fai> dicFaisForHistorgam, int cavityNum = 1, string productName = null, bool compensateEnable = true, double overStepValue = 0.01)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				allFaiResults = null;
				sortedFais = null;
				dicFaisForHistorgam = null;
				return -10;
			}
			if (Products[productName].ComplexConfigs.Count == 0)
			{
				allFaiResults = null;
				sortedFais = null;
				dicFaisForHistorgam = null;
				return -20;
			}
			try
			{
				KeyValuePair<Guid, ComplexFaiConfigs> complexFaiConfig = Products[productName].ComplexConfigs.FirstOrDefault((KeyValuePair<Guid, ComplexFaiConfigs> p) => p.Value.Name == faiConfigsName);
				if (!complexFaiConfig.Value.Enable)
				{
					allFaiResults = null;
					sortedFais = null;
					dicFaisForHistorgam = null;
					return -110;
				}
				return complexFaiConfig.Value.JudgeResult(dicsFai, out allFaiResults, out sortedFais, out dicFaisForHistorgam, cavityNum, compensateEnable, overStepValue);
			}
			catch (Exception)
			{
				allFaiResults = null;
				sortedFais = null;
				dicFaisForHistorgam = null;
				return -30;
			}
		}

		/// <summary>
		/// 利用复杂FAI配置判断FAI结果
		/// </summary>
		/// <param name="faiConfigsName">复杂FAI配置的名称</param>
		/// <param name="dicsFai">传入的FAI值集合</param>
		/// <param name="allFaiResults">输出每一个FAI项的判断结果</param>
		/// <param name="sortedFais">将传入的FAI值集合根据配置排序后输出</param>
		/// <param name="dicFaisForHistorgam">输出用于传入直方图显示基元</param>
		/// <param name="cavityNum">穴位号</param>
		/// <param name="productName">产品名</param>
		/// <param name="compensateEnable">是否补偿运算</param>
		/// <param name="overStepValue">公差超出值</param>
		/// <returns>利用当前复杂FAI配置判断的总体结果：1-公差范围以内，2-尺寸收严，-1-超出图纸公差（overStepValue）以内，-2-超出图纸公差（overStepValue）以外，-3-有异常值</returns>
		public int ComplexJudgeResult(string faiConfigsName, Dictionary<object, object> dicsFai, out Dictionary<string, int> allFaiResults, out Dictionary<object, object> sortedFais, out Dictionary<string, Fai> dicFaisForHistorgam, int cavityNum = 1, string productName = null, bool compensateEnable = true, double overStepValue = 0.01)
		{
			if (productName == null)
			{
				productName = CurrentProductName;
			}
			if (!Products.ContainsKey(productName))
			{
				allFaiResults = null;
				sortedFais = null;
				dicFaisForHistorgam = null;
				return -10;
			}
			if (Products[productName].ComplexConfigs.Count == 0)
			{
				allFaiResults = null;
				sortedFais = null;
				dicFaisForHistorgam = null;
				return -20;
			}
			try
			{
				KeyValuePair<Guid, ComplexFaiConfigs> complexFaiConfig = Products[productName].ComplexConfigs.FirstOrDefault((KeyValuePair<Guid, ComplexFaiConfigs> p) => p.Value.Name == faiConfigsName);
				if (!complexFaiConfig.Value.Enable)
				{
					allFaiResults = null;
					sortedFais = null;
					dicFaisForHistorgam = null;
					return -110;
				}
				return complexFaiConfig.Value.JudgeResult(dicsFai, out allFaiResults, out sortedFais, out dicFaisForHistorgam, cavityNum, compensateEnable, overStepValue);
			}
			catch (Exception)
			{
				allFaiResults = null;
				sortedFais = null;
				dicFaisForHistorgam = null;
				return -30;
			}
		}

		public override string ToString()
		{
			return CurrentProductName;
		}
	}
}
