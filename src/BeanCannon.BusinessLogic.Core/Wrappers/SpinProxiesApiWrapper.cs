using BeanCannon.BusinessLogic.Core.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace BeanCannon.BusinessLogic.Core.Wrappers
{
	enum SpinProxiesProxyClass
	{
		Socks4,
		Socks5,
		Http,
	}

	class SpinProxiesApiWrapper
	{
		const String masterProxyListFilePathFormat = "Resources/proxylist-{0}.json";
		const String tempProxyListFilePathFormat = "Resources/proxylist-{0}-temp.json";

		private static readonly Object locker = new Object();

		public SpinProxiesRootResponse FetchProxyList(SpinProxiesProxyClass proxyClass)
		{
			const string apiKey = "qmml9lwkny4j3x9yyt4ed2oscp20lu";

			var normalizedProxyClass = proxyClass.ToString().ToLower();

			using (var client = new WebClient())
			{
				client.Headers[HttpRequestHeader.Accept] = "application/json";
				string result = client.DownloadString(
					$"https://spinproxies.com/api/v1/proxylist?key={apiKey}&type=anonymous&protocols={normalizedProxyClass}&format=json"
					);

				SpinProxiesRootResponse data = null;

				try
				{
					data = SpinProxiesRootResponse.FromJson(result);
				}
				catch { }

				var masterProxyListFilePath = String.Format(masterProxyListFilePathFormat, normalizedProxyClass);

				if (null != data)
				{
					if (File.Exists(masterProxyListFilePath))
					{
						var temp = File.ReadAllText(masterProxyListFilePath);
						var storedData = SpinProxiesRootResponse.FromJson(temp);

						storedData.Data.Proxies.AddRange(data.Data.Proxies);

						var uniqueProxies = storedData.Data.Proxies.GroupBy(w => new { w.Ip, w.Port }).Select(w => w.FirstOrDefault());
						storedData.Data.Proxies = uniqueProxies.ToList();

						WriteMasterContent(storedData, proxyClass);

						return storedData;
					}
					else
					{
						WriteMasterContent(data, proxyClass);
					}
				}
				else
				{
					if (File.Exists(masterProxyListFilePath))
					{
						var temp = File.ReadAllText(masterProxyListFilePath);
						var storedData = SpinProxiesRootResponse.FromJson(temp);

						return storedData;
					}
				}

				return data;
			}
		}

		private static void WriteMasterContent(SpinProxiesRootResponse data, SpinProxiesProxyClass proxyClass, bool writeOriginalFile = true)
		{
			string content = data.ToJson();

			var normalizedProxyClass = proxyClass.ToString().ToLower();
			var masterProxyListFilePath = String.Format(masterProxyListFilePathFormat, normalizedProxyClass);

			lock (locker)
			{
				File.WriteAllText(masterProxyListFilePath, content);

				if (writeOriginalFile)
				{
					var projectMasterProxyListFilePath = $"../../../{masterProxyListFilePath}";
					if (File.Exists(projectMasterProxyListFilePath))
					{
						File.WriteAllText(projectMasterProxyListFilePath, content);
					}
				}
			}
		}

		internal static void WriteTempContent(SpinProxiesRootResponse data, SpinProxiesProxyClass proxyClass)
		{
			// For viewing live data
			try
			{
				string content = data.ToJson();

				var normalizedProxyClass = proxyClass.ToString().ToLower();
				var tempProxyListFilePath = String.Format(tempProxyListFilePathFormat, normalizedProxyClass);
				lock (locker)
				{
					File.WriteAllText(tempProxyListFilePath, content);
				}
			}
			catch { }
		}
	}
}
