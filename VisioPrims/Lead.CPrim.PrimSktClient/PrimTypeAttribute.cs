using Lead.CPrim.PrimSktClient.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Lead.CPrim.Interfaces
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        string path = Path.Combine(Application.StartupPath, @"Images\PrimSktClient\Default.png");
        public string Name => "SocketClient";
        public string DisplayName => "SocketClient";
        public string Description => "";
        public Image Icon
        {
            get
            {
                if (!File.Exists(path))
                {
                    var manager = new ResourceManager(typeof(Resources));
                    return (Image)manager.GetObject("Default");
                }

                return Image.FromFile(path);
            }
        }
        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                if (!File.Exists(path))
                {
                    var manager = new ResourceManager(typeof(Resources));
                    images.Add((Image)manager.GetObject("Default"));
                    return images;
                }

                string[] files = Directory.GetFiles(Path.GetDirectoryName(path), "*.png");
                if (files.Length <= 0)
                {
                    var manager = new ResourceManager(typeof(Resources));
                    images.Add((Image)manager.GetObject("Default"));
                    return images;
                }
                Array.Sort(files);
                Array.Reverse(files);
                foreach (var item in files)
                {
                    if (File.Exists(item))
                    {
                        images.Add(Image.FromFile(item));
                    }
                }
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