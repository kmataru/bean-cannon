using Org.Mentalis.Network.ProxySocket;
using System.Net;

namespace BeanCannon.BusinessLogic.Core.Net.Interfaces
{
	public interface IProxy
	{
		IPEndPoint ProxyEndPoint { get; set; }

		ProxyTypes ProxyType { get; set; }
		string ProxyPass { get; set; }
		string ProxyUser { get; set; }
	}
}
