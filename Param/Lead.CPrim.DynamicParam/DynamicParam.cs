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
        #endregion



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
			bool result2;
			if (Node == null)
			{
				MessageBox.Show(binder.ToString() + NLocalizer.GetString("Lead_CPrim_DynamicParam_DynamicParam_ErrMsg_DynamicParamNoLoad", "换型参数未加载!"));
				result = 0;
				result2 = false;
			}
			else
			{
				Property p = this._xElementPropList.FirstOrDefault((Property x) => x.Name == binder.Name);
				if (p != null)
				{
					if (!(p.Value is List<Property> l))
					{
						result = p.Value;
					}
					else
					{
						MyPropList list = new MyPropList(binder.Name);
						list.OnPropChanged += this.UpdateElementOnMyPropListChanged;
						list.PropertyList = l;
						result = list;
					}
					result2 = true;
				}
				else
				{
					result = null;
					result2 = false;
				}
			}
			return result2;
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
				_currentProduct = SwManager.Instance.CurrentProduct;
				Node = XElement.Load(_paramPath + "\\" + _currentProduct + ".para");
				Load(Node);
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
				Node = XElement.Load(path);
				Load(Node);

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
			Node = CurNode;
			_xElementPropList = new List<Property>();
			foreach (XElement element in Node.Elements().ToList<XElement>())
			{
				Property p = (Property)element;
				_xElementPropList.Add(p);
			}
		}

		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="path"></param>
		public void Save(string path)
		{
			Node.Save(path);
		}

		/// <summary>
		/// 设置参数
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="value">值</param>
		/// <returns>bool</returns>
		public bool SetMember(string propertyName, object value)
		{
			bool result = true;

			Property p = _xElementPropList.FirstOrDefault(x => x.Name == propertyName);
			if (p != null)
			{
				p.Value = value;
				OnUpdateProperty?.Invoke(p);
				//Node.Elements().FirstOrDefault(x => x.Name == propertyName).Remove();
				//Node.Add(p.PropToXElment());
			}
			else
			{
				result = false;
			}

			return result;
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
            XElement elementOwn = this.GetXElementByName(this.Node, ownName);
            if (elementOwn != null)
            {
                XElement element = this.GetXElementByName(elementOwn, p.Name);
                if (element != null)
                {
                    element.Remove();
                    elementOwn.Add(p.PropToXElment());
                }
            }
        } 
        #endregion
    }
}