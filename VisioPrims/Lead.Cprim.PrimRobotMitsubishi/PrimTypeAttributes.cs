using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimRobotMitsubishi
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        public string Name => "RobotMitsubishi";
        public string DisplayGroup => "Other";
        public string Description => "";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(ResourceDefault));
                return (Image)manager.GetObject("robot2");
            }
        }
        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                var manager = new ResourceManager(typeof(ResourceDefault));
                images.Add((Image)manager.GetObject("robot"));
                images.Add((Image)manager.GetObject("robot1"));
                images.Add((Image)manager.GetObject("robot2"));
                images.Add((Image)manager.GetObject("robot3"));
                images.Add((Image)manager.GetObject("robot4"));
                return images;
            }
        }
        public string DisplayName => "RobotMitsubishi";
        public string Group => "Other";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
        public object this[string attrName] => throw new NotImplementedException();
        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}
