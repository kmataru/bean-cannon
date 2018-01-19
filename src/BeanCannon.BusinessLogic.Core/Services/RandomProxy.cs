using BeanCannon.BusinessLogic.Core.Models;
using BeanCannon.BusinessLogic.Core.Randomizers;
using Org.Mentalis.Network.ProxySocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BeanCannon.BusinessLogic.Core.Services
{
	class RandomProxyStoreData
	{
		public int LastListLengthWhenRegenerated { get; set; }

		public int ListIndex { get; set; }

		public List<int> RandomIndexes { get; set; } = new List<int>();
	}

	public class RandomProxy
	{
		private const string NewRandomListFormat = "Generating new random list with {0} elements";
		private const string ExtendRandomListFormat = "Extending current random list from {0} to {1} elements";
		private const string DowngradwRandomListFormat = "Downgrading current random list from {0} to {1} elements";
		private const string AcquiredIndexFormat = "Acquired new index for the proxy list: {0}; Internal index: {1}; Ip: {2}; Port: {3}";

		private static readonly Object locker = new Object();

		static readonly UniqueRandomizer uniqueRandom = new UniqueRandomizer();

		private RandomProxy()
		{
		}

		private static RandomProxy _Instance;
		public static RandomProxy Instance
		{
			get
			{
				lock (locker)
				{
					if (null == _Instance)
					{
						_Instance = new RandomProxy();
					}

					return _Instance;
				}
			}
		}

		private bool IsInit;
		private Dictionary<AddressFamily, Dictionary<SocketType, Dictionary<ProtocolType, RandomProxyStoreData>>> Store { get; set; }

		public ProxyDatum GetRandomProxy(IList<ProxyDatum> proxies, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		{
			lock (locker)
			{
				if (!IsInit)
				{
					if (null == Store)
					{
						Store = new Dictionary<AddressFamily, Dictionary<SocketType, Dictionary<ProtocolType, RandomProxyStoreData>>>();
					}

					if (!Store.ContainsKey(addressFamily))
					{
						Store[addressFamily] = new Dictionary<SocketType, Dictionary<ProtocolType, RandomProxyStoreData>>();
					}

					if (!Store[addressFamily].ContainsKey(socketType))
					{
						Store[addressFamily][socketType] = new Dictionary<ProtocolType, RandomProxyStoreData>();
					}

					if (!Store[addressFamily][socketType].ContainsKey(protocolType))
					{
						Store[addressFamily][socketType][protocolType] = new RandomProxyStoreData();
					}

					IsInit = true;
				}
			}

			var proxiesCount = proxies.Count;
			if (proxiesCount == 0)
			{
				return null;
			}

			lock (locker)
			{
				var storeData = Store[addressFamily][socketType][protocolType];
				var storeDataListLength = storeData.RandomIndexes.Count;

				if (proxiesCount != storeDataListLength)
				{
					if (proxiesCount > storeDataListLength)
					{
						/*
						if (proxiesCount - storeData.LastListLengthWhenRegenerated >= 3)
						{
							Logger.Log.DebugFormat(NewRandomListFormat, proxiesCount);

							storeData.LastListLengthWhenRegenerated = proxiesCount;
							storeData.RandomIndexes = uniqueRandom.GenerateRandom(proxiesCount, 0, proxiesCount);
						}
						else
						//*/
						{
							Logger.Log.DebugFormat(ExtendRandomListFormat, storeDataListLength, proxiesCount);

							var randomIndexes = uniqueRandom.GenerateRandom(proxiesCount - storeDataListLength, storeDataListLength, proxiesCount);
							storeData.RandomIndexes.AddRange(randomIndexes);
						}
					}
					else
					{
						Logger.Log.DebugFormat(DowngradwRandomListFormat, storeDataListLength, proxiesCount);

						storeData.LastListLengthWhenRegenerated = proxiesCount;
						storeData.RandomIndexes.RemoveAll(w => w >= proxiesCount);
					}

					storeData.ListIndex = 0;
				}

				// TODO: == || >= ??
				if (storeData.ListIndex == storeData.RandomIndexes.Count)
				{
					Logger.Log.DebugFormat(NewRandomListFormat, proxiesCount);

					storeData.LastListLengthWhenRegenerated = proxiesCount;
					storeData.RandomIndexes = uniqueRandom.GenerateRandom(proxiesCount, 0, proxiesCount);

					storeData.ListIndex = 0;
				}

				int proxyIndex = storeData.RandomIndexes[storeData.ListIndex];
				var proxyData = proxies[proxyIndex];

				Logger.Log.DebugFormat(
					 AcquiredIndexFormat,
					 proxyIndex,
					 storeData.ListIndex,
					 proxyData.Ip,
					 proxyData.Port
				);

				storeData.ListIndex++;

				return proxyData;
			}
		}
	}
}
