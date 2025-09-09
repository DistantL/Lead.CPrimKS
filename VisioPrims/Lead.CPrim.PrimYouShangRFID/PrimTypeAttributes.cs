using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;
using Lead.CPrim.PrimYouShangRFID.Properties;

namespace Lead.CPrim.PrimYouShangRFID
{
	public class PrimTypeAttributes : IPrimTypeAttributes
	{
		public string Name => "YouShangRFID";

		public string DisplayName => "YouShangRFID";

		public string Description => "RFID通讯助手";

		public Image Icon
		{
			get
			{
				ResourceManager manager = new ResourceManager(typeof(Resources));
				return (Image)manager.GetObject("rfid4");
			}
		}

		public List<Image> ListIcon
		{
			get
			{
				List<Image> images = new List<Image>();
				ResourceManager manager = new ResourceManager(typeof(Resources));
				images.Add((Image)manager.GetObject("rfid1"));
				images.Add((Image)manager.GetObject("rfid2"));
				images.Add((Image)manager.GetObject("rfid3"));
				images.Add((Image)manager.GetObject("rfid4"));
				return images;
			}
		}

		public string DisplayGroup => "Comm";

		public string Group => "Comm";

		public byte MajorVersion => 1;

		public byte MinorVersion => 0;

		public object this[string attrName]
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IEnumerable<KeyValuePair<string, object>> Attributes
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
