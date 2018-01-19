using System;
using System.Net;

namespace BeanCannon.BusinessLogic.Core.Net.Interfaces
{
	public interface IProxySocket : IProxy
	{
		IAsyncResult BeginConnect(EndPoint remoteEP, AsyncCallback callback, object state);
		IAsyncResult BeginConnect(string host, int port, AsyncCallback callback, object state);
		void Connect(EndPoint remoteEP);
		void Connect(string host, int port);
		void EndConnect(IAsyncResult asyncResult);
	}
}
