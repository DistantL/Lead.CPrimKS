using Lead.CPrim.PrimPCIEM60_E;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.Interfaces
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        string path = Path.Combine(Application.StartupPath, @"Images\PrimRobotInovancePro");
        public string Name => "PrimPCIEM60_E";
        public string DisplayName => "凌臣M60板卡";
        public string Description => "凌臣M60板卡";

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
