using System;
using System.Net;
using System.Net.Sockets;

namespace BeanCannon.BusinessLogic.Core.Net
{
	public partial class ChainedProxySocket
	{
		public bool Connected
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.Connected : socket.Connected;
			}
		}

		public AddressFamily AddressFamily
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.AddressFamily : socket.AddressFamily;
			}
		}

		public SocketType SocketType
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.SocketType : socket.SocketType;
			}
		}

		public ProtocolType ProtocolType
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.ProtocolType : socket.ProtocolType;
			}
		}

		public int ReceiveBufferSize
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.ReceiveBufferSize : socket.ReceiveBufferSize;
			}

			set
			{
				if (null != chainedProxySocket)
				{
					chainedProxySocket.ReceiveBufferSize = value;
				}
				else
				{
					socket.ReceiveBufferSize = value;
				}
			}
		}

		public bool Blocking
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.Blocking : socket.Blocking;
			}

			set
			{
				if (null != chainedProxySocket)
				{
					chainedProxySocket.Blocking = value;
				}
				else
				{
					socket.Blocking = value;
				}
			}
		}

		public int ReceiveTimeout
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.ReceiveTimeout : socket.ReceiveTimeout;
			}

			set
			{
				if (null != chainedProxySocket)
				{
					chainedProxySocket.ReceiveTimeout = value;
				}
				else
				{
					socket.ReceiveTimeout = value;
				}
			}
		}

		public bool NoDelay
		{
			get
			{
				return null != chainedProxySocket ? chainedProxySocket.NoDelay : socket.NoDelay;
			}

			set
			{
				if (null != chainedProxySocket)
				{
					chainedProxySocket.NoDelay = value;
				}
				else
				{
					socket.NoDelay = value;
				}
			}
		}

		public int Receive(byte[] buffer)
		{
			if (null != chainedProxySocket)
			{
				return chainedProxySocket.Receive(buffer);
			}
			else
			{
				return socket.Receive(buffer);
			}
		}

		public int Receive(byte[] buffer, int size, SocketFlags socketFlags)
		{
			if (null != chainedProxySocket)
			{
				return chainedProxySocket.Receive(buffer, size, socketFlags);
			}
			else
			{
				return socket.Receive(buffer, size, socketFlags);
			}
		}

		public int Send(byte[] buffer)
		{
			if (null != chainedProxySocket)
			{
				return chainedProxySocket.Send(buffer);
			}
			else
			{
				return socket.Send(buffer);
			}
		}

		public int Send(byte[] buffer, SocketFlags socketFlags)
		{
			if (null != chainedProxySocket)
			{
				return chainedProxySocket.Send(buffer, socketFlags);
			}
			else
			{
				return socket.Send(buffer, socketFlags);
			}
		}

		public int SendTo(byte[] buffer, SocketFlags socketFlags, EndPoint remoteEP)
		{
			if (null != chainedProxySocket)
			{
				return chainedProxySocket.SendTo(buffer, socketFlags, remoteEP);
			}
			else
			{
				return socket.SendTo(buffer, socketFlags, remoteEP);
			}
		}

		public void Close()
		{
			if (null != chainedProxySocket)
			{
				chainedProxySocket.Close();
			}
			else
			{
				socket.Close();
			}
		}
	}
}
