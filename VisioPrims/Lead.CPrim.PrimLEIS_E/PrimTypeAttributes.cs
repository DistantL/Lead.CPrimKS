using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimLEIS_E
{
    internal class PrimTypeAttributes : IPrimTypeAttributes
    {
        public string Name => "LEIS_E";

        public string DisplayName => "MotionCard";

        public string Description => "";

        public string Group => "Dev";

        public string DisplayGroup => "Dev";

        public byte MajorVersion => 1;

        public byte MinorVersion => 0;

        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(ResourceLEIS_E));
                return (Image) manager.GetObject("LEISI");
            }
        }

        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                var manager = new ResourceManager(typeof(ResourceLEIS_E));
                images.Add((Image)manager.GetObject("LEISI"));
                return images;
            }
        }

        public object this[string attrName] => throw new NotImplementedException();

        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}