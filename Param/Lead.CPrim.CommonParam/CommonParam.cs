using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Style;

namespace Lead.CPrim.CommonParam
{
    /// <summary>全局参数管理器</summary>
    public sealed class CommonParam : DynamicObject
    {
        #region Event
        /// <summary>
        /// 更新参数时发生
        /// </summary>
        public static Action<Property> OnUpdateProperty;
        #endregion



        #region Field
        /// <summary>
        /// 全局参数集合
        /// </summary>
        public List<Property> xElementPropList = null;

        /// <summary>
        /// 全局参数（XElement）
        /// </summary>
        public XElement Node;

        /// <summary>
        /// 参数读写锁
        /// </summary>
        public static readonly object LockPara = new object();
        #endregion



        #region Prop
        public static dynamic Instance = new CommonParam();
        #endregion



        #region Ctor
        private CommonParam()
        {
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 日志增加
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="lv">日志等级</param>
        /// <param name="id">id</param>
        /// <param name="isShowDialog">true：显示报警弹窗；false：不显示报警弹窗</param>
        public static void LogAdd(string msg, LogLevel lv, int id = 0, bool isShowDialog = false)
        {
            msg = $"CommonParam -> {msg}";
            string tempId = $"{(int)lv}{(int)PrimLogId.CommonParam}0000";

            if (int.TryParse(tempId, out var intId))
            {
                id += intId;
            }

            LogHelper.LogAdd(lv, msg, PrimLogId.CommonParam.ToString(), LogClassification.Parameter, id);

            if ((lv == LogLevel.Fatal || lv == LogLevel.Error || lv == LogLevel.Warn) && isShowDialog)
            {
                UIMessageDialog.ShowMessageDialog(msg, NLocalizer.Warn, false, UIStyle.Orange, false, true);
            }
        }

        /// <summary>
        /// 本地获取数据，更新Node及xElementPropList<br/>
        /// </summary>
        /// <param name="path">全局参数全路径</param>
        public void Load(string path)
        {
            var node = XElement.Load(path);
            Load(node);
        }

        /// <summary>
        /// 更新Node及xElementPropList<br/>
        /// </summary>
        /// <param name="node"></param>
        public void Load(XElement node)
        {
            Node = node;

            xElementPropList = new List<Property>();
            foreach (XElement element in GetParaMembers())
            {
                Property p = (Property)element;
                xElementPropList.Add(p);
            }
        }

        /// <summary>
        /// 按文档顺序返回集合的子元素的此元素或文档<br/>
        /// </summary>
        /// <returns></returns>
        public List<XElement> GetParaMembers()
        {
            return Node.Elements().ToList();
        }

        /// <summary>
        /// 保存Node<br/>
        /// </summary>
        /// <param name="path">路径</param>
        public void Save(string path)
        {
            Node.Save(path);
        }

        /// <summary>值获取</summary>
        /// <param name="binder"></param>
        /// <param name="result">值</param>
        /// <returns>bool</returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            lock (LockPara)
            {
                if (Node == null)
                {
                    MessageBox.Show(binder.ToString() + "Param未加载！");
                    result = 0;
                    return false;
                }
                Property p = xElementPropList.FirstOrDefault((Property x) => x.Name == binder.Name);
                if (p != null)
                {
                    if (!(p.Value is List<Property>))
                    {
                        result = p.Value;
                    }
                    else
                    {
                        MyPropList list = new MyPropList(binder.Name);
                        list.OnPropChanged += UpdateElementOnMyPropListChanged;
                        list.PropertyList = (List<Property>)p.Value;
                        result = list;
                    }
                    return true;
                }
                result = null;
                return false;
            }
        }

        /// <summary>值设置</summary>
        /// <param name="str"></param>
        /// <param name="value">值</param>
        /// <returns>bool</returns>
        public bool SetMember(string str, object value)
        {
            lock (LockPara)
            {
                Property p = xElementPropList.FirstOrDefault((Property x) => x.Name == str);
                if (p != null)
                {
                    p.Value = value;
                    OnUpdateProperty?.Invoke(p);
                    //Node.Elements().FirstOrDefault((XElement x) => x.Name == str).Remove();
                    //Node.Add(p.PropToXElment());
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 值设置
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value">值</param>
        /// <returns>bool</returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return SetMember(binder.Name, value);
        }

        /// <summary>
        /// 是否包含属性名称<br/>
        /// True：包含；False：不包含；
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool IsPropertyContain(string propertyName)
        {
            Property p = xElementPropList.FirstOrDefault((Property x) => x.Name == propertyName);
            return p != null;
        }
        #endregion



        #region Method_InternalUsing
        private XElement GetXElementByName(XElement elementP, string name)
        {
            XElement element = null;
            foreach (XElement xEle in elementP.Elements())
            {
                if (xEle.Name != name)
                {
                    element = GetXElementByName(xEle, name);
                    if (element != null)
                    {
                        return xEle;
                    }
                    continue;
                }
                return xEle;
            }
            return element;
        }

        private void UpdateElementOnMyPropListChanged(Property p, string ownName)
        {
            XElement elementOwn = GetXElementByName(Node, ownName);
            if (elementOwn != null)
            {
                XElement element = GetXElementByName(elementOwn, p.Name);
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
