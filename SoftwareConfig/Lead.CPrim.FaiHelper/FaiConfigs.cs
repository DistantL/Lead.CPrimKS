using System;
using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace Lead.CPrim.FaiHelper
{
	[JsonObject()]
	public class FaiConfigs
	{
        public ConcurrentDictionary<string, FaiConfig> DicFais { get; set; }

        public bool Enable { get; set; }

        public Guid Gid { get; set; }

        public bool IsOutput { get; set; }

        public bool IsUpload { get; set; }

        public string Name { get; set; }

        public FaiConfigs()
        {
            Gid = Guid.NewGuid();
            Name = "";
            Enable = true;
            IsOutput = true;
            IsUpload = true;
            DicFais = new ConcurrentDictionary<string, FaiConfig>();
        }
    }
}
