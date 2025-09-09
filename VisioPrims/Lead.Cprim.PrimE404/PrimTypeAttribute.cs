using Lead.CPrim.PrimE404;
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
        string path = Path.Combine(Application.StartupPath, @"Images\PrimE404");
        public string Name => "E404";
        public string DisplayName => "凌臣高速触发模块";
        public string Description => "凌臣高速触发模块";

        public Image Icon
        {
            get
            {
                if (!Directory.Exists(path))
                {
                    var manager = new ResourceManager(typeof(ResourceDefault));
                    return (Image)manager.GetObject("Default");
                }

                string defaultFile = Path.Combine(path, "Default.png");
                if (!File.Exists(defaultFile))
                {
                    var manager = new ResourceManager(typeof(ResourceDefault));
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
                    var manager = new ResourceManager(typeof(ResourceDefault));
                    images.Add((Image)manager.GetObject("Default"));
                    return images;
                }

                string[] files = Directory.GetFiles(path, "*.png");
                if (files.Length <= 0)
                {
                    var manager = new ResourceManager(typeof(ResourceDefault));
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

        public string DisplayGroup => "MotionCard";
        public string Group => "MotionCard";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
        public object this[string attrName] => throw new NotImplementedException();
        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
    }
}