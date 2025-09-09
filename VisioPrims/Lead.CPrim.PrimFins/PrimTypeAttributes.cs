/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: PrimCreator.cs
 * Author: Victor
 * Description: 框架dll属性类，为每个dll属性赋值，每个基元相同，保持不变
 * CreateTime: 2022-09-21
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0904><Victor><20220921>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.Interfaces;
using Lead.CPrim.PrimFins.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Lead.CPrim.PrimFinsNet
{
    public class PrimTypeAttributes : IPrimTypeAttributes
    {
        string path = Path.Combine(Application.StartupPath, @"Images\PrimFins");
        public string Name => "FinsNet";
        public string DisplayName => "Fins通讯协议";
        public string Description => "Fins通讯协议";
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
                if(files.Length <= 0)
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