using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimVarManager
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        public string Name => "VarManager";
        public string DisplayName => "VarManager";
        public string Description => "";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(PrimVarManager));
                return (Image)manager.GetObject("remote");
            }
        }
        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                var manager = new ResourceManager(typeof(PrimVarManager));
                images.Add((Image)manager.GetObject("remote"));
                return images;
            }
        }
        public string DisplayGroup => "Communicate";
        public string Group => "Communicate";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
        public object this[string attrName] => throw new NotImplementedException();
        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}