using System.Net.Sockets;
using BeanCannon.BusinessLogic.Core.Models;

namespace BeanCannon.BusinessLogic.Core.Net.Interfaces
{
	public interface IChainedProxySocket : IProxy, ISocket
	{
		ChainedProxySocket AddChainedProxy(ProxyDatum proxy, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType);
		ChainedProxySocket AddChainedProxy(ProxyDatum proxy, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, string proxyUsername);
		ChainedProxySocket AddChainedProxy(ProxyDatum proxy, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, string proxyUsername, string proxyPassword);
	}
}
