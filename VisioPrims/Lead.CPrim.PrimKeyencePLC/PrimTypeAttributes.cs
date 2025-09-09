
using Lead.CPrim.Interfaces;
using Lead.CPrim.PrimKeyencePLC.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Lead.CPrim.PrimKeyencePLC
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        string path = Path.Combine(Application.StartupPath, @"Images\PrimKeyencePLC");
        public string Name => "KeyencePLC";
        public string DisplayName => "KeyencePLC通讯协议";
        public string Description => "KeyencePLC通讯协议";
        public Image Icon
        {
            get
            {
                if (!Directory.Exists(path))
                {
                    var manager = new ResourceManager(typeof(Resources));
                    return (Image)manager.GetObject("Default");
                }

                string defaultFile = Path.Combine(path, "Default.png");
                if (!File.Exists(defaultFile))
                {
                    var manager = new ResourceManager(typeof(Resources));
                    return (Image)manager.GetObject("Default");
                }

                return Image.FromFile(defaultFile);
            }
        }
        public List<Image> ListIcon
        {
            get
            {
                List<Image> images = new List<Image>();
                if (!Directory.Exists(path))
                {
                    var manager = new ResourceManager(typeof(Resources));
                    images.Add((Image)manager.GetObject("Default"));
                    return images;
                }

                string[] files = Directory.GetFiles(path, "*.png");
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
        public string DisplayGroup => "Protocol";
        public string Group => "Protocol";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
        public object this[string attrName] => throw new NotImplementedException();
        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}