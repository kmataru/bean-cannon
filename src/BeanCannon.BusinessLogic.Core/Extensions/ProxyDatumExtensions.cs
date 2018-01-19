using BeanCannon.BusinessLogic.Core.Models;
using BeanCannon.BusinessLogic.Core.Services;
using Org.Mentalis.Network.ProxySocket;
using System.Linq;
using System.Net.Sockets;

namespace BeanCannon.BusinessLogic.Core.Extensions
{
	// TODO: No need for it to be public
	public static class ProxyDatumExtensions
	{
		public static ProxyTypes GetTestedProxyType(this ProxyDatum proxy, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		{
			var selected = proxy.Tests[addressFamily][socketType][protocolType]
				.Where(w => w.Value >= 0 && w.Value <= ProxyTester.MaximumConnectionTime.TotalSeconds)
				.OrderBy(w => w.Value)
				.FirstOrDefault();

			return selected.Key;
		}
	}
}
