using BeanCannon.BusinessLogic.Core.Attacks.Settings;
using BeanCannon.BusinessLogic.Core.Extensions;
using BeanCannon.BusinessLogic.Core.Models;
using BeanCannon.BusinessLogic.Core.Net;
using BeanCannon.BusinessLogic.Core.Net.Interfaces;
using BeanCannon.BusinessLogic.Core.Services;
using ImpromptuInterface;
using Org.Mentalis.Network.ProxySocket;
using System;
using System.Net;
using System.Net.Sockets;

namespace BeanCannon.BusinessLogic.Core.Factory
{
	class SocketFactory
	{
		private static readonly Object locker = new Object();

		private SocketFactory()
		{

		}

		private static SocketFactory _Instance;
		public static SocketFactory Instance
		{
			get
			{
				lock (locker)
				{
					if (null == _Instance)
					{
						_Instance = new SocketFactory();
					}

					return _Instance;
				}
			}
		}

		public ISocket GetSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, ProxyConnectionType proxyConnectionType)
		{
			switch (proxyConnectionType)
			{
				case ProxyConnectionType.Random:
					{
						// Create a new ProxySocket
						ProxySocket proxySocket = new ProxySocket(addressFamily, socketType, protocolType);

						ProxyDatum proxy;

						do
						{
							var availableProxies =
								ProxyTester.Instance.GetAvailableProxies(addressFamily, socketType, protocolType);

							proxy = RandomProxy.Instance.GetRandomProxy(availableProxies, addressFamily, socketType, protocolType);

							if (null == proxy)
							{
								System.Threading.Thread.Sleep(500);
							}
						} while (null == proxy);

						proxySocket.ProxyDatum = proxy;

						// Set the proxy settings
						proxySocket.ProxyEndPoint = new IPEndPoint(IPAddress.Parse(proxy.Ip), proxy.Port);
						// proxySocket.ProxyUser = "username";
						// proxySocket.ProxyPass = "password";

						proxySocket.ProxyType = proxy.GetTestedProxyType(addressFamily, socketType, protocolType);

						return proxySocket.ActLike<ISocket>();
					}

				case ProxyConnectionType.Chained:
					{
						// Create a new ChainedProxySocket
						ChainedProxySocket chainedProxySocket = new ChainedProxySocket(addressFamily, socketType, protocolType);

						ProxyDatum[] chain;

						do
						{
							var availableProxies =
								ProxyTester.Instance.GetAvailableProxies(addressFamily, socketType, protocolType);

							chain = RandomChainedProxy.Instance.GetRandomChainedProxy(availableProxies, 2);

							if (null == chain)
							{
								System.Threading.Thread.Sleep(500);
							}
						} while (null == chain);

						//
						//

						for (int idx = 0; idx < chain.Length - 1; ++idx)
						{
							var nextProxy = chain[idx + 1];

							if (idx == 0)
							{
								var proxy = chain[idx];

								chainedProxySocket.ProxyDatum = proxy;

								// Set the proxy settings
								chainedProxySocket.ProxyEndPoint = new IPEndPoint(IPAddress.Parse(proxy.Ip), proxy.Port);
								chainedProxySocket.ProxyType = proxy.GetTestedProxyType(addressFamily, socketType, protocolType);

								chainedProxySocket.NoDelay = true;
							}

							IPEndPoint nextProxyChainEndPoint = new IPEndPoint(IPAddress.Parse(nextProxy.Ip), nextProxy.Port);
							chainedProxySocket.Connect(nextProxyChainEndPoint);

							chainedProxySocket =
								chainedProxySocket.AddChainedProxy(nextProxy, addressFamily, socketType, protocolType);
						}

						return chainedProxySocket.ActLike<ISocket>();
					}

				default:
					{
						var basicSocket = new Socket(addressFamily, socketType, protocolType);

						return basicSocket.ActLike<ISocket>();
					}
			}
		}
	}
}
