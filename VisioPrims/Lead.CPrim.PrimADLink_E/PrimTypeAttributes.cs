using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lead.CPrim.PrimADLink_E
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        #region Field
        private string path = Application.StartupPath + @"\Images\PrimADLink_E";
        #endregion


        #region Prop
        public string Name => "ADLink_E";
        public string DisplayName => "MotionCard";
        public string Description => "凌华运动控制卡";

        public Image Icon
        {
            get
            {
                if (!Directory.Exists(path))
                {
                    return null;
                }

                string defaultFile = Path.Combine(path, "Default.png");
                if (!File.Exists(defaultFile))
                {
                    return null;
                }

                return Image.FromFile(defaultFile);
            }
        }
        public List<Image> ListIcon
        {
            get
            {
                if (!Directory.Exists(path))
                {
                    return null;
                }

                string[] files = Directory.GetFiles(path, "*.png");
                Array.Sort(files);
                Array.Reverse(files);
                List<Image> images = new List<Image>();
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
        public string DisplayGroup => "Dev";
        public string Group => "Dev";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
        public object this[string attrName] => throw new NotImplementedException();
        public IEnumerable<KeyValuePair<string, object>> Attributes => throw new NotImplementedException();
        #endregion
    }
}