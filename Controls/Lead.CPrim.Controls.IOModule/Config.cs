namespace Lead.CPrim.Controls.IOModule
{
	public class Config
	{
		public class IOConfig
		{
			public double Address { get; set; }

			public string Info { get; set; }

			public IOConfig(double address, string info)
			{
				Address = address;
				Info = info;
			}
		}
	}
}
