using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.DynamicParam
{
	public sealed class DynamicParam : DynamicObject
    {
        #region Event
        /// <summary>
        /// 更新参数时发生
        /// </summary>
        public static Action<Property> OnUpdateProperty;
        public static event Action<string> OnModeSwitch;
        public static event Action<string> OnModeSwitchView;

        // 仅在产品及模式参数完整加载成功后通知；观察者异常不能把成功切换报告为失败。
        internal static void NotifyModeChanged(string mode)
        {
            foreach (var handler in new[] { OnModeSwitchView, OnModeSwitch })
            {
                if (handler == null) continue;
                foreach (Action<string> callback in handler.GetInvocationList())
                {
                    try { callback(mode); }
                    catch (Exception ex) { LogHelper.Warn("运行模式通知失败：" + ex); }
                }
            }
        }

        internal static XElement WithRunMode(XElement document, string mode)
        {
            if (string.IsNullOrWhiteSpace(mode)) throw new ArgumentException("运行模式不能为空。", nameof(mode));
            var result = new XElement(document);
            var existing = result.Elements().FirstOrDefault(p => p.Name.LocalName == "运行模式" || (string)p.Element("Name") == "运行模式");
            var property = new Property
            {
                Name = "运行模式", DisplayName = (string)existing?.Element("DisplayName") ?? "运行模式",
                Category = (string)existing?.Element("Category") ?? "00 设备",
                Value = mode, valType = BaseParam.DataType.Comb, ReadOnly = true, Visible = true,
                CombMsg = string.Join(",", Enum.GetNames(typeof(运行模式)))
            };
            result.Elements().Where(p => p.Name.LocalName == "运行模式" || (string)p.Element("Name") == "运行模式").Remove();
            result.Add(property.PropToXElment());
            return result;
        }
        public readonly ParameterChangeFeed Updates = new ParameterChangeFeed(new object());
        #endregion

        public void LoadSnapshot(XElement document, string path)
        {
            lock (Updates.SyncRoot)
            {
                Load(document);
                _paramPath = Path.GetDirectoryName(path);
                _currentProduct = Path.GetFileNameWithoutExtension(path);
            }
        }



        #region Field
        public static dynamic Instance = new DynamicParam();

		/// <summary>
		/// 当前产品
		/// </summary>
		private string _currentProduct;

		/// <summary>
		/// 换型参数文件夹
		/// </summary>
		private string _paramPath;

		public List<Property> _xElementPropList = null;

		public XElement Node;
        #endregion




        private void AssignChild(Property owner, string[] path, object value)
        {
            Property notification;
            lock (Updates.SyncRoot)
            {
                if (!_xElementPropList.Contains(owner)) throw new InvalidOperationException("参数已重新加载，不能通过旧对象赋值。");
                notification = ParameterChangeFeed.Assign(owner, Node.Elements().First(p => (string)p.Element("Name") == owner.Name), path, value);
                Updates.Publish(notification);
            }
            OnUpdateProperty?.Invoke(ParameterChangeFeed.Clone(notification));
        }

        #region Ctor
        private DynamicParam()
        {
        }
		#endregion



		#region Method_Override
		/// <summary>
		/// 获取参数
		/// </summary>
		/// <param name="binder"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
            lock (Updates.SyncRoot)
            {
                var property = _xElementPropList?.FirstOrDefault(p => p.Name == binder.Name);
                if (property == null) { result = null; return false; }
                var children = property.Value as List<Property>;
                if (children == null) result = property.Value;
                else
                {
                    var owner = property;
                    result = ParameterChangeFeed.Proxy(children, (path, value) => AssignChild(owner, path, value));
                }
                return true;
            }
        }

		/// <summary>
		/// 设置参数
		/// </summary>
		/// <param name="binder"></param>
		/// <param name="value"></param>
		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			return SetMember(binder.Name, value);
		}

		/// <summary>
		/// 获取当前产品
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this._currentProduct;
		}

		#endregion



		#region Method_ExternalUsing
		/// <summary>
		/// 根据当前产品获取参数
		/// </summary>
		public void Load()
		{
            try
            {
                string path = Path.Combine(_paramPath, SwManager.Instance.CurrentProduct + ".para");
                LoadSnapshot(XElement.Load(path), path);
            }
            catch (Exception e)
            {
                LogAdd(NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParam_ErrMsg_DynamicParamLoadFail", "换型参数加载失败:") + e.Message, LogLevel.Warn, 0, false);
            }
        }

		/// <summary>
		/// 根据路径获取参数
		/// </summary>
		/// <param name="path"></param>
		public void Load(string path)
		{
			try
			{
				Load(XElement.Load(path));

				_paramPath = Path.GetDirectoryName(path);
				_currentProduct = Path.GetFileNameWithoutExtension(path);
			}
			catch (Exception e)
			{
				LogAdd(NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParam_ErrMsg_DynamicParamLoadFail", "换型参数加载失败:") + e.Message, LogLevel.Warn, 0, false);
			}
		}

		/// <summary>
		/// 根据XElement获取参数
		/// </summary>
		/// <param name="CurNode"></param>
        public void Load(XElement CurNode)
		{
            lock (Updates.SyncRoot)
            {
                var copy = new XElement(CurNode);
                var parsed = copy.Elements().Select(p => (Property)p).ToList();
                Node = copy;
                _xElementPropList = parsed;
                Updates.Reset();
            }
        }

		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="path"></param>
		public void Save(string path)
		{
			lock (Updates.SyncRoot) new XElement(Node).Save(path);
		}

		/// <summary>
		/// 设置参数
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value">值</param>
		/// <returns>bool</returns>
		public bool SetMember(string propertyName, object value)
		{
            Property notification;
            lock (Updates.SyncRoot)
            {
                var property = _xElementPropList?.FirstOrDefault(p => p.Name == propertyName);
                if (property == null) return false;
                var snapshot = Node.Elements().First(p => (string)p.Element("Name") == property.Name);
                notification = ParameterChangeFeed.Assign(property, snapshot, new string[0], value);
                Updates.Publish(notification);
            }
            OnUpdateProperty?.Invoke(ParameterChangeFeed.Clone(notification));
            return true;
        }

		/// <summary>
		/// true：包含属性；false：不包含属性；
		/// </summary>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public bool IsPropertyContain(string propertyName)
		{
			Property p = _xElementPropList.FirstOrDefault(x => x.Name == propertyName);
			return p != null;
		}

		/// <summary>
		/// 按文档顺序返回此元素或文档的子元素集合
		/// </summary>
		/// <returns></returns>
		public List<XElement> GetParaMembers()
		{
			return Node.Elements().ToList<XElement>();
		}

		/// <summary>
		/// 日志
		/// </summary>
		/// <param name="msg">信息</param>
		/// <param name="lv">日志等级</param>
		/// <param name="id">id</param>
		/// <param name="isShowDialog">true：显示弹窗；false：不显示弹窗；</param>
		public void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
		{
			msg = $"DynamicParam -> " + msg;
			string tempId = $"{(int)lv}{(int)PrimLogId.DynamicParam}0000";

			if (int.TryParse(tempId, out var intId))
			{
				id += intId;
			}

			LogHelper.LogAdd(lv, msg, PrimLogId.DynamicParam.ToString(), LogClassification.Parameter, id);

			if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
			{
				UIMessageDialog.ShowMessageDialog(msg, ULocalize.WarningTitle, false, UIStyle.Orange, false, true);
			}
		}
		#endregion



		#region Method_InternalUsing
		private XElement GetXElementByName(XElement elementP, string name)
        {
            XElement element = null;
            foreach (XElement xEle in elementP.Elements())
            {
                if (!(xEle.Name != name))
                {
                    return xEle;
                }
                element = this.GetXElementByName(xEle, name);
                if (element != null)
                {
                    return xEle;
                }
            }
            return element;
        }

        private void UpdateElementOnMyPropListChanged(Property p, string ownName)
        {
            var owner = _xElementPropList?.FirstOrDefault(item => item.Name == ownName);
            if (owner != null) AssignChild(owner, new[] { p.Name }, p.Value);
        } 
        #endregion
    }
}
