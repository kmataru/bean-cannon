using BeanCannon.BusinessLogic.Core.Models;
using BeanCannon.BusinessLogic.Core.Randomizers;
using System;
using System.Collections.Generic;

namespace BeanCannon.BusinessLogic.Core.Services
{
	class RandomChainedProxy
	{
		private static readonly Object locker = new Object();

		static readonly UniqueRandomizer uniqueRandom = new UniqueRandomizer();

		private RandomChainedProxy()
		{
		}

		private static RandomChainedProxy _Instance;
		public static RandomChainedProxy Instance
		{
			get
			{
				lock (locker)
				{
					if (null == _Instance)
					{
						_Instance = new RandomChainedProxy();
					}

					return _Instance;
				}
			}
		}

		public ProxyDatum[] GetRandomChainedProxy(IList<ProxyDatum> proxies, int length)
		{
			var proxiesCount = proxies.Count;
			if (proxiesCount == 0)
			{
				return null;
			}

			if (length > proxies.Count)
			{
				length = proxies.Count;
			}

			ProxyDatum[] chain = new ProxyDatum[length];

			var randomIndexes = uniqueRandom.GenerateRandom(length, 0, proxies.Count);

			for (int idx = 0; idx < length; ++idx)
			{
				chain[idx] = proxies[randomIndexes[idx]];
			}

			return chain;
		}
	}
}
