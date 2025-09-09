using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public enum EditType
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text,

        /// <summary>
        /// 整数
        /// </summary>
        Integer,

        /// <summary>
        /// 浮点数
        /// </summary>
        Double,

        Date,
        DateTime,

        /// <summary>
        /// 密码
        /// </summary>
        Password,
        Combobox,
        Switch,
        ComboTreeView,
        ComboCheckedListBox
    }
}
