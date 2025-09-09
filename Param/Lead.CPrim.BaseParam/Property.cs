using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using Lead.CPrim.BaseParam;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.BaseParam
{
    /// <summary>全局参数属性</summary>
    public class Property
    {
        /// <summary>名称</summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        /// <summary>显示名称</summary>
        public string DisplayName
        {
            get
            {
                return this._displayname;
            }
            set
            {
                this._displayname = value;
            }
        }

        /// <summary>分组</summary>
        public string Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }
       
        /// <summary>
        /// 点位时 轴组名称
        /// </summary>
        public string Cartesian
        {
            get
            {
                return this._cartesian;
            }
            set
            {
                this._cartesian = value;
            }
        }

        /// <summary>是否只读</summary>
        public bool ReadOnly
        {
            get
            {
                return this._readonly;
            }
            set
            {
                this._readonly = value;
            }
        }

        /// <summary>是否可见</summary>
        public bool Visible
        {
            get
            {
                return this._visible;
            }
            set
            {
                this._visible = value;
            }
        }

        /// <summary>值</summary>
        public object Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        /// <summary>值类型</summary>
        public DataType valType { get; set; }

        /// <summary>下拉框值</summary>
        public string CombMsg { get; set; } = "";

        public TypeConverter Converter
        {
            get
            {
                return this._converter;
            }
            set
            {
                this._converter = value;
            }
        }

        public virtual object Editor
        {
            get
            {
                return this._editor;
            }
            set
            {
                this._editor = value;
            }
        }

        /// <summary>Ctor无参</summary>
        public Property()
        {
        }

        public Property(Property p)
        {
            Name = p.Name;
            DisplayName = p.DisplayName;
            Category = p.Category;
            Cartesian = p.Cartesian;
            ReadOnly = p.ReadOnly;
            Visible = p.Visible;
            Value = p.Value;
            valType = p.valType;
            CombMsg = p.CombMsg;
            Converter = p.Converter;
            Editor = p.Editor;
        }

        /// <summary>Ctor有2个参数</summary>
        /// <param name="sName">名称</param>
        /// <param name="sValue">值</param>
        public Property(string sName, object sValue)
        {
            this._name = sName;
            this._value = sValue;
        }

        /// <summary>Ctor有5个参数</summary>
        /// <param name="sName">名称</param>
        /// <param name="sValue">值</param>
        /// <param name="type">值类型</param>
        /// <param name="sReadonly">是否只读</param>
        /// <param name="sVisible">是否可见</param>
        public Property(string sName, object sValue, DataType type, bool sReadonly = false, bool sVisible = false) : this(sName, sValue)
        {
            this._readonly = sReadonly;
            this._visible = sVisible;
            this.valType = type;
        }

        /// <summary></summary>
        /// <param name="node"></param>
        public static explicit operator Property(XElement node)
        {
            Property property = new Property();
            List<XElement> elements = node.Elements().ToList<XElement>();
            Array temp = Enum.GetValues(typeof(DataType));
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp.GetValue(i).ToString() == elements.FirstOrDefault((XElement x) => x.Name == "valType").Value)
                {
                    property.valType = (DataType)temp.GetValue(i);
                }
            }
            string strValue = elements.FirstOrDefault((XElement x) => x.Name == "Value").Value;
            object val = null;
            switch (property.valType)
            {
                case DataType.BOOL:
                    val = bool.Parse(strValue);
                    break;
                case DataType.DOUBLE:
                    val = double.Parse(strValue);
                    break;
                case DataType.STRING:
                    val = strValue;
                    break;
                case DataType.Point:
                    {
                        XElement b = elements.FirstOrDefault((XElement x) => x.Name == "Value");
                        List<XElement> c = b.Elements().ToList<XElement>();
                        val = (List<Pos>)XMLHelper.XMLToObject(c[0].GetXmlNode(), typeof(List<Pos>));
                        break;
                    }
                case DataType.INT:
                    val = int.Parse(strValue);
                    break;
                case DataType.BYTE:
                    val = byte.Parse(strValue);
                    break;
                case DataType.Comb:
                    {
                        val = strValue;
                        string text = property.CombMsg = elements.FirstOrDefault((XElement x) => x.Name == "CombMsg").Value;
                        string[] GroupStr = property.CombMsg.Split(new char[]
                        {
                    ','
                        });
                        object[] array = GroupStr;
                        object[] objects = array;
                        property.Converter = new DropDownListConverter(objects);
                        break;
                    }
                case DataType.PathString:
                    val = strValue;
                    property.Editor = new PropertyGridFileItem();
                    break;
                case DataType.DirPath:
                    val = strValue;
                    property.Editor = new PropertyGridDirItem();
                    break;
                case DataType.UserDefine:
                    {
                        List<Property> ParList = new List<Property>();
                        XElement xel = elements.FirstOrDefault((XElement x) => x.Name == "Value");
                        List<XElement> xels = xel.Elements().ToList<XElement>();
                        foreach (XElement a in xels)
                        {
                            ParList.Add((Property)a);
                        }
                        val = ParList;
                        property.Editor = new OpenPropertyGrid();
                        break;
                    }
            }
            property.Value = val;
            property.Name = elements.FirstOrDefault((XElement x) => x.Name == "Name").Value;
            property.DisplayName = elements.FirstOrDefault((XElement x) => x.Name == "DisplayName").Value;
            property.Category = elements.FirstOrDefault((XElement x) => x.Name == "Category").Value;
            if (elements.FirstOrDefault((XElement x) => x.Name == "Cartesian") != null)
            {
                property.Cartesian = elements.FirstOrDefault((XElement x) => x.Name == "Cartesian").Value;
            }
            property.Visible = bool.Parse(elements.FirstOrDefault((XElement x) => x.Name == "Visible").Value);
            property.ReadOnly = bool.Parse(elements.FirstOrDefault((XElement x) => x.Name == "ReadOnly").Value);
            return property;
        }

        /// <summary>全局参数添加属性</summary>
        /// <param name="ValType">类型</param>
        /// <param name="ValName">名称</param>
        /// <param name="Group">分组</param>
        /// <param name="DispName">显示名称</param>
        /// <param name="DropComb">下拉框选项</param>
        /// <param name="UDTPath">自定义名称路径</param>
        /// <param name="Cartesian">自定义名称路径</param>
        /// <param name="val">自定义名称路径</param>
        /// <param name="readOnly">自定义名称路径</param>
        /// <param name="visible">自定义名称路径</param>
        /// <returns></returns>
        public Property AddProperty(
            string ValType, 
            string ValName, 
            string Group, 
            string DispName, 
            string DropComb = "", 
            string UDTPath = "",
            string Cartesian = "", 
            object val = null, 
            bool readOnly = false, 
            bool visible = true)
        {
            Property property = new Property();
            Array temp = Enum.GetValues(typeof(DataType));
            for (int i = 0; i < temp.Length; i++)
            {
                string info = temp.GetValue(i).ToString();
                if (info == ValType)
                {
                    property.valType = (DataType)temp.GetValue(i);
                }
            }

            switch (property.valType)
            {
                case DataType.BOOL:
                    val = val ?? false;
                    break;
                case DataType.DOUBLE:
                    val = val ?? 0.0;
                    break;
                case DataType.STRING:
                    val = val ?? "NULL";
                    break;
                case DataType.Point:
                    val = val ?? new List<Pos>
                    {
                        new Pos("NewPos")
                    };
                    break;
                case DataType.INT:
                    val = val ?? 0;
                    break;
                case DataType.BYTE:
                    val = val ?? 1;
                    break;
                case DataType.Comb:
                    {
                        if (string.IsNullOrEmpty(DropComb))
                        {
                            return null;
                        }
                        string[] SelectItems = DropComb.Split(new char[]
                        {
                    ','
                        });
                        val = val ?? SelectItems[0];
                        object[] array = SelectItems;
                        object[] objects = array;
                        property.Converter = new DropDownListConverter(objects);
                        break;
                    }
                case DataType.PathString:
                    val = val ?? "Null";
                    property.Editor = new PropertyGridFileItem();
                    break;
                case DataType.DirPath:
                    val = val ?? "Null";
                    property.Editor = new PropertyGridDirItem();
                    break;
                case DataType.UserDefine:
                    {
                        List<Property> ParList = new List<Property>();
                        XElement xel = XElement.Load(UDTPath);
                        List<XElement> xels = xel.Elements().ToList<XElement>();
                        foreach (XElement a in xels)
                        {
                            ParList.Add((Property)a);
                        }
                        val = val ?? ParList;
                        property.Editor = new OpenPropertyGrid();
                        break;
                    }
            }
            property.Value = val;
            property.Name = ValName;
            property.DisplayName = DispName;
            property.Category = Group;
            property.ReadOnly = readOnly;
            property.Visible = visible;
            property.CombMsg = DropComb;
            property.Cartesian = Cartesian;
            return property;
        }

        public XElement PropToXElment()
        {
            XElement result;
            if (!(Value is List<Property>))
            {
                if (valType == DataType.Point)
                {
                    result = new XElement(this.Name, new object[]
                    {
                        new XElement("Name", this.Name),
                        new XElement("DisplayName", this.DisplayName),
                        new XElement("Category", this.Category),
                        new XElement("ReadOnly", this.ReadOnly),
                        new XElement("Visible", this.Visible),
                        new XElement("Value", XMLHelper.ObjectToXML(this.Value).GetXElement()),
                        new XElement("valType", this.valType),
                        new XElement("CombMsg", this.CombMsg),
                        new XElement("Cartesian", this.Cartesian),
                    });
                }
                else
                {
                    result = new XElement(this.Name, new object[]
                    {
                        new XElement("Name", this.Name),
                        new XElement("DisplayName", this.DisplayName),
                        new XElement("Category", this.Category),
                        new XElement("ReadOnly", this.ReadOnly),
                        new XElement("Visible", this.Visible),
                        new XElement("Value", this.Value),
                        new XElement("valType", this.valType),
                        new XElement("CombMsg", this.CombMsg),
                    });
                }
            }
            else
            {
                XElement ele = new XElement(this.Name, new object[]
                {
                    new XElement("Name", this.Name),
                    new XElement("DisplayName", this.DisplayName),
                    new XElement("Category", this.Category),
                    new XElement("ReadOnly", this.ReadOnly),
                    new XElement("Visible", this.Visible),
                    new XElement("valType", this.valType),
                    new XElement("CombMsg", this.CombMsg),
                });
                XElement eleValues = new XElement("Value", "");
                foreach (Property p in ((List<Property>)this.Value))
                {
                    eleValues.Add(p.PropToXElment());
                }
                ele.Add(eleValues);
                result = ele;
            }
            return result;
        }

        /// <summary>名称</summary>
        private string _name = string.Empty;

        /// <summary>显示名称</summary>
        private string _displayname = string.Empty;

        /// <summary>分组</summary>
        private string _category = string.Empty;

        /// <summary>是否只读</summary>
        private bool _readonly = false;

        /// <summary>是否可见</summary>
        private bool _visible = true;

        /// <summary>值</summary>
        private object _value = null;

        private TypeConverter _converter = null;

        private object _editor = null;

        private string _cartesian = string.Empty;

    }
}
