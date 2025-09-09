using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using Lead.CPrim.PrimSktServer;

namespace Lead.CPrim.Interfaces
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        public string Name => "SocketServer";
        public string DisplayName => "SocketServer";
        public string Description => "";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(ResourceSocketServer));
                return (Image)manager.GetObject("server");
            }
        }
        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                var manager = new ResourceManager(typeof(ResourceSocketServer));
                images.Add((Image)manager.GetObject("server"));
                return images;
            }
        }
        public string DisplayGroup => "Comm";
        public string Group => "Comm";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
        public object this[string attrName] => throw new NotImplementedException();
        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}