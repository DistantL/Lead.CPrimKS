using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Lead.CPrim.CommonTools
{
	/// <summary>NetHelper（支持各种网络处理）</summary>
	public class NetHelper
	{
		public static string GetIpAddress()
		{
			string hostName = Dns.GetHostName();
			IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
			IPAddress iPAddress = hostEntry.AddressList[0];
			return iPAddress.ToString();
		}

		public static string GetIPv4AddressByAdapterName(string adapterName)
		{
			UnicastIPAddressInformation unicastIPAddressInformation = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault((NetworkInterface p) => p.Name == adapterName)?.GetIPProperties().UnicastAddresses.FirstOrDefault((UnicastIPAddressInformation p) => p.Address.AddressFamily == AddressFamily.InterNetwork);
			return (unicastIPAddressInformation != null) ? unicastIPAddressInformation.Address.ToString() : string.Empty;
		}
	}
}
