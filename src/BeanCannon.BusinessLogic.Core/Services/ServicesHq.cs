using System;

namespace BeanCannon.BusinessLogic.Core.Services
{
	public class ServicesHq
	{
		public static readonly ProxyTester SocksProxyTester;

		public static readonly RandomProxy RandomSocksProxy;

		static ServicesHq()
		{
			SocksProxyTester = ProxyTester.Instance;

			RandomSocksProxy = RandomProxy.Instance;
		}
	}
}
