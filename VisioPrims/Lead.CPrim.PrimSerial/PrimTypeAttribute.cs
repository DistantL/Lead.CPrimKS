using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;
using Lead.CPrim.PrimSerial.Properties;

namespace Lead.CPrim.PrimSerial
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        public string Name => "Serial";

        public string DisplayName => "Serial";

        public string Description => "";

        public string Group => "Comm";

        public string DisplayGroup => "Comm";

        public byte MajorVersion => 1;

        public byte MinorVersion => 0;

        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resources));
                var img = (Image) manager.GetObject("Default");
                return img;
            }
        }

        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                var manager = new ResourceManager(typeof(Resources));
                images.Add((Image)manager.GetObject("Default"));
                return images;
            }
        }
        public object this[string attrName] => throw new NotImplementedException();

        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}