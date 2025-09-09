using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using Lead.CPrim.PrimLESI_EController;

namespace Lead.CPrim.Interfaces
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        public string Name => "LESI_EController";
        public string DisplayName => "MotionCard";
        public string Description => "";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(PrimLESI_EControler_Resource));
                return (Image)manager.GetObject("icn_轴运动");
            }
        }
        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                var manager = new ResourceManager(typeof(PrimLESI_EControler_Resource));
                images.Add((Image)manager.GetObject("icn_轴运动"));
                return images;
            }
        }
        public string DisplayGroup => "Dev";
        public string Group => "Dev";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
        public object this[string attrName] => throw new NotImplementedException();
        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}