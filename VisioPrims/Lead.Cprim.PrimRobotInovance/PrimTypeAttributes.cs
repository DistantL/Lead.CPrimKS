using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.Cprim.PrimRobotInovance
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        public string Name => "RobotInovance";
        public string DisplayGroup => "Other";
        public string Description => "";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(ResourceDefault));
                return (Image)manager.GetObject("robot");
            }
        }
        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                var manager = new ResourceManager(typeof(ResourceDefault));
                images.Add((Image)manager.GetObject("robot"));
                return images;
            }
        }
        public string DisplayName => "RobotInovance";
        public string Group => "Other";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
        public object this[string attrName] => throw new NotImplementedException();
        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}
