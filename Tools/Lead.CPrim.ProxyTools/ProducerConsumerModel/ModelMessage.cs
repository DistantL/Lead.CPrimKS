using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public class ModelMessage
    {
        /// <summary>
        /// 写入内容<br/>
        /// string集合<br/>
        /// </summary>
        public List<string> ContentsString { get; set; } = new List<string>();

        /// <summary>
        /// 写入内容<br/>
        /// StringBuilder集合<br/>
        /// </summary>
        public List<StringBuilder> ContentsStringBuilder { get; set; } = new List<StringBuilder>();

        /// <summary>
        /// 只读，默认True<br/>
        /// True：只读<br/>
        /// False：读写<br/>
        /// </summary>
        public bool IsReadOnly { get; set; } = true;

        /// <summary>
        /// 是否为StringBuilder类型，默认False<br/>
        /// True：StringBuilder<br/>
        /// False：string<br/>
        /// </summary>
        public bool IsStringBuilder { get; set; } = false;

        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 文件标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 写入格式
        /// </summary>
        public ModelFormat ModelFormat { get; set; }
    }
}
