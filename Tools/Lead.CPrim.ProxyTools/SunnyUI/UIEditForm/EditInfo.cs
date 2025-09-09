using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    /// <summary>
    /// 
    /// </summary>
    public class EditInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string DataPropertyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EditType EditType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool CheckEmpty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HalfWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object DataSource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayMember { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ValueMember { get; set; }
    }
}
