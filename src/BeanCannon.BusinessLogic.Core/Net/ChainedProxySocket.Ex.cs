using BeanCannon.BusinessLogic.Core.Extensions;
using BeanCannon.BusinessLogic.Core.Models;
using System;
using System.Net;
using System.Net.Sockets;

namespace BeanCannon.BusinessLogic.Core.Net
{
	public partial class ChainedProxySocket
	{
		Socket socket;
		ChainedProxySocket chainedProxySocket;

		bool _IsConnected;
		bool IsConnected
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.IsConnected : _IsConnected;
			}

			set
			{
				if (null != chainedProxySocket)
				{
					chainedProxySocket.IsConnected = value;
				}
				else
				{
					_IsConnected = value;
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ChainedProxySocket"/> class.
		/// </summary>
		/// <param name="chainedProxySocket">Other instance of this class.</param>
		/// <param name="addressFamily">One of the AddressFamily values.</param>
		/// <param name="socketType">One of the SocketType values.</param>
		/// <param name="protocolType">One of the ProtocolType values.</param>
		/// <exception cref="SocketException">The combination of addressFamily, socketType, and protocolType results in an invalid socket.</exception>
		private ChainedProxySocket(ChainedProxySocket chainedProxySocket, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : this(chainedProxySocket, addressFamily, socketType, protocolType, "") { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ChainedProxySocket"/> class.
		/// </summary>
		/// <param name="chainedProxySocket">Other instance of this class.</param>
		/// <param name="addressFamily">One of the AddressFamily values.</param>
		/// <param name="socketType">One of the SocketType values.</param>
		/// <param name="protocolType">One of the ProtocolType values.</param>
		/// <param name="proxyUsername">The username to use when authenticating with the proxy server.</param>
		/// <exception cref="SocketException">The combination of addressFamily, socketType, and protocolType results in an invalid socket.</exception>
		/// <exception cref="ArgumentNullException"><c>proxyUsername</c> is null.</exception>
		private ChainedProxySocket(ChainedProxySocket chainedProxySocket, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, string proxyUsername) : this(chainedProxySocket, addressFamily, socketType, protocolType, proxyUsername, "") { }

		/// <summary>
		/// Initializes a new instance of the <see cref="ChainedProxySocket"/> class.
		/// </summary>
		/// <param name="chainedProxySocket">Other instance of this class.</param>
		/// <param name="addressFamily">One of the AddressFamily values.</param>
		/// <param name="socketType">One of the SocketType values.</param>
		/// <param name="protocolType">One of the ProtocolType values.</param>
		/// <param name="proxyUsername">The username to use when authenticating with the proxy server.</param>
		/// <param name="proxyPassword">The password to use when authenticating with the proxy server.</param>
		/// <exception cref="SocketException">The combination of addressFamily, socketType, and protocolType results in an invalid socket.</exception>
		/// <exception cref="ArgumentNullException"><c>proxyUsername</c> -or- <c>proxyPassword</c> is null.</exception>
		private ChainedProxySocket(ChainedProxySocket chainedProxySocket, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, string proxyUsername, string proxyPassword)
		{
			this.chainedProxySocket = chainedProxySocket;

			ProxyUser = proxyUsername;
			ProxyPass = proxyPassword;
			ToThrow = new InvalidOperationException();
		}

		public ChainedProxySocket AddChainedProxy(ProxyDatum proxy, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		{
			return AddChainedProxy(proxy, addressFamily, socketType, protocolType, String.Empty, String.Empty);
		}

		public ChainedProxySocket AddChainedProxy(ProxyDatum proxy, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, string proxyUsername)
		{
			return AddChainedProxy(proxy, addressFamily, socketType, protocolType, proxyUsername, String.Empty);
		}

		public ChainedProxySocket AddChainedProxy(ProxyDatum proxy, AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, string proxyUsername, string proxyPassword)
		{
			// Create a new ChainedProxySocket
			var chainedProxySocket = new ChainedProxySocket(this, addressFamily, socketType, protocolType, proxyUsername, proxyPassword);

			chainedProxySocket.ProxyDatum = proxy;

			// Set the proxy settings
			chainedProxySocket.ProxyEndPoint = new IPEndPoint(IPAddress.Parse(proxy.Ip), proxy.Port);
			chainedProxySocket.ProxyType = proxy.GetTestedProxyType(addressFamily, socketType, protocolType);

			return chainedProxySocket;
		}

		private Socket Socket
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.Socket : socket;
			}
		}

		private IAsyncResult WrappedBeginConnect(EndPoint remoteEP, AsyncCallback callback, object state)
		{
			return null != chainedProxySocket ? chainedProxySocket.WrappedBeginConnect(remoteEP, callback, state) : socket.BeginConnect(remoteEP, callback, state);
		}

		private void WrappedConnect(EndPoint remoteEP)
		{
			// Avoid reconnecting after initial proxy has deal with this
			if (!IsConnected)
			{
				if (null != chainedProxySocket)
				{
					chainedProxySocket.WrappedConnect(remoteEP);
				}
				else
				{
					socket.Connect(remoteEP);
				}

				IsConnected = true;
			}
		}

		private void WrappedEndConnect(IAsyncResult asyncResult)
		{
			if (null != chainedProxySocket)
			{
				chainedProxySocket.WrappedEndConnect(asyncResult);
			}
			else
			{
				socket.EndConnect(asyncResult);
			}
		}

		private void WrappedClose()
		{
			if (null != chainedProxySocket)
			{
				chainedProxySocket.WrappedClose();
			}
			else
			{
				socket.Close();
			}
		}
	}
}
