using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.StationCommon.DataArea
{
    public class Property
    {
        #region Field
        /// <summary>名称</summary>
        private string _name;
        /// <summary>名称</summary>
        private string _ownerName;
        /// <summary>值</summary>
        private object _propertyValue;
        /// <summary>类型</summary>
        private DataType _valType;
        #endregion



        #region Prop
        /// <summary>名称</summary>
        public string Name { get { return _name; } set { _name = value; } }
        /// <summary>名称</summary>
        public string OwnerName { get { return _ownerName; } set { _ownerName = value; } }
        /// <summary>类型</summary>
        public DataType ValType { get { return _valType; } set { _valType = value; } }
        /// <summary>值</summary>
        public object Value { get { return _propertyValue; } set { _propertyValue = value; } }
        #endregion



        #region Ctor
        /// <summary>
        /// Ctor无参
        /// </summary>
        public Property()
        {
        }
        /// <summary>
        /// Ctor有三个参数
        /// </summary>
        /// <param name="valType"></param>
        /// <param name="valName"></param>
        /// <param name="ownerName"></param>
        public Property(string valType, string valName, string ownerName)
        {
            Array temp = Enum.GetValues(typeof(DataType));
            for (int i = 0; i < temp.Length; i++)
            {
                string info = temp.GetValue(i).ToString();
                if (info == valType)
                {
                    _valType = (DataType)temp.GetValue(i);
                }
            }
            _name = valName;
            _ownerName = ownerName;
        }
        #endregion



        #region Method_ExternalUsing

        public static explicit operator Property(XElement node)
        {
            Property property = new Property();
            try
            {
                List<XElement> elements = node.Elements().ToList();
                Array temp = Enum.GetValues(typeof(DataType));
                for (int i = 0; i < temp.Length; i++)
                {
                    string info = temp.GetValue(i).ToString();
                    if (info == elements.FirstOrDefault((XElement x) => x.Name == "ValType").Value)
                    {
                        property._valType = (DataType)temp.GetValue(i);
                    }
                }
                property.Name = elements.FirstOrDefault((XElement x) => x.Name == "Name").Value;
                property._ownerName = elements.FirstOrDefault((XElement x) => x.Name == "OwnerName").Value;
                return property;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public XElement PropToXElment()
        {
            return new XElement(Name, new XElement("Name", Name), new XElement("ValType", _valType), new XElement("OwnerName", _ownerName));
        }
        #endregion
    }
}
